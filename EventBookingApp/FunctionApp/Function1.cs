using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FunctionApp
{
    public class Function1
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _config;

        public Function1(ILoggerFactory loggerFactory,IConfiguration config)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
            _config = config;
        }

        [Function("TimeSlotsGenerationFunction")]
        public async Task Run([TimerTrigger("0 */12 * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
            try
            {
                string connectionString = _config.GetValue<string>("DbContext");
                using (SqlConnection connection=new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string getlastReservationDateQuery = @"select diningtables.Restaurantbranchid,max(timeslots.ReservationDay) as LastReservationDay from diningtables
left outer join TimeSlots on diningtables.id=timeslots.diningtableid
group by diningtables.restaurantbranchid";
                    SqlCommand getLastReservationDataCommand = new SqlCommand(getlastReservationDateQuery);
                    List<(int BranchId, DateTime LastReservationDate)> branchData = new List<(int, DateTime)>();
                    using (SqlDataReader reader = await getLastReservationDataCommand.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            int branchId = (int)reader["Restaurantbranchid"];
                            DateTime lastReservationDate = (DateTime)reader["LastReservationDay"];
                            branchData.Add((branchId, lastReservationDate));
                        }
                    }
                    foreach (var data in branchData)
                    {
                        int branchId = data.BranchId;
                        DateTime lastReservationDate = data.LastReservationDate;

                        DateTime currentDate = DateTime.Now.Date;
                        DateTime reservationEndDate = currentDate > lastReservationDate ? currentDate.AddDays(2) : lastReservationDate.AddDays(2);
                        if (lastReservationDate <= currentDate.AddDays(2))
                        {
                            string getdiningTableIdQuery = @"select Id as DiningTableId
from diningTables where RestaurantBranchId=@BranchId";
                            SqlCommand getDiningTablesIdCmd = new SqlCommand(getdiningTableIdQuery, connection);
                            getDiningTablesIdCmd.Parameters.AddWithValue("@BranchId", branchId);

                            List<int> diningTableIds = new List<int>();
                            using (SqlDataReader diningTableIdReader = await getDiningTablesIdCmd.ExecuteReaderAsync())
                            {
                                while (await diningTableIdReader.ReadAsync())
                                {
                                    int diningTableId = (int)diningTableIdReader["DiningTableId"];
                                    diningTableIds.Add(diningTableId);
                                }
                            }
                            foreach (int diningTableId in diningTableIds)
                            {
                                for (DateTime reservationDate = lastReservationDate.AddDays(1); reservationDate <= reservationEndDate; reservationDate = reservationDate.AddDays(1))
                                {
                                    // Insert available slots into the Timeslots table for each meal type
                                    foreach (string mealType in new string[] { "Breakfast", "Lunch", "Dinner" })
                                    {
                                        string insertTimeslotQuery = @"
                            INSERT INTO TimeSlots (DiningTableId, ReservationDay, MealType, TableStatus)
                            VALUES (@DiningTableId, @ReservationDay, @MealType, @TableStatus)";

                                        SqlCommand insertTimeslotCommand = new SqlCommand(insertTimeslotQuery, connection);
                                        insertTimeslotCommand.Parameters.AddWithValue("@DiningTableId", diningTableId);
                                        insertTimeslotCommand.Parameters.AddWithValue("@ReservationDay", reservationDate);
                                        insertTimeslotCommand.Parameters.AddWithValue("@MealType", mealType);
                                        insertTimeslotCommand.Parameters.AddWithValue("@TableStatus", "Available");

                                        await insertTimeslotCommand.ExecuteNonQueryAsync();
                                    }
                                }
                            }
                        }
                    }
                }

            }
            
            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }
        }
    }
}
