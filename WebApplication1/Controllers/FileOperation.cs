using CsvHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;
using WebApplication1.Dto;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileOperation : ControllerBase
    {

        public IActionResult UploadFile()
        {
            try
            {
                string fileName = "energy_dataset.csv";
                string path = "C:\\Users\\singh\\Downloads\\EnergyDataSet";

                using var sr = new StreamReader(path+ fileName);
                using var csv = new CsvReader(sr, CultureInfo.InvariantCulture);
                var records = csv.GetRecords<EnergyData>().ToList();
            }
            catch(Exception ex)
            {

            }
        }
        private static string ConvertCsvToJson(string csvFilePath)
        {
            using (var reader = new StreamReader(csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<dynamic>();
                string json = JsonConvert.SerializeObject(records, Formatting.Indented);
                return json;
            }
        }


    }
}
