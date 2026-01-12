using CsvHelper.Configuration.Attributes;
using System.Drawing;

namespace WebApplication1.Dto
{
    public class EnergyData
    {
        [Name("time")]
        public DateTime Time { get; set; }
        [Name("generation biomass")]
        public int generation_biomass_generation { get; set; }
        [Name("generation fossil brown coal/lignite")]

        public int generation_fossil_brown_coal { get; set; }
        [Name("generation fossil gas")]
        public int generation_fossil_gas { get; set; }
        [Name("generation fossil hard coal")]
        public int generation_fossil_hard_coal { get; set; }
        [Name("generation fossil oil")]
        public int generation_fossil_oil { get; set; }
        [Name("generation hydro pumped storage consumption")]
        public int generation_hydro_pumped_storage_consumption { get; set; }
        [Name("generation hydro run-of-river and poundage")]
        public int generation_hydro_run_of_river_and_poundage { get; set; }
        [Name("generation hydro water reservoir\r\n")]
        public int generation_hydro_water_reservoir { get; set; }
        [Name("generation nuclear")]
        public int generation_nuclear { get; set; }
        [Name("generation other")]
        public int generation_other { get; set; }
        [Name("generation other renewable")]
        public int generation_other_renewable { get; set; }
        [Name("generation solar")]
        public int generation_solar { get; set; }
        [Name("generation waste")]
        public int generation_waste { get; set; }
        [Name("generation wind onshore")]
        public int generation_wind_onshore { get; set; }
        [Name("forecast solar day ahead")]
        public int forecast_solar_day_ahead { get; set; }
        [Name("forecast wind onshore day ahead")]
        public int forecast_wind_onshore_day_ahead { get; set; }
        [Name("total load forecast")]
        public int total_load_forecast { get; set; }
        [Name("total load actual")]
        public int total_load_actual { get; set; }
        [Name("price day ahead")]
        public int price_day_ahead { get; set; }
        [Name("price actual")]
        public int price_actual { get; set; }


    }
}

time generation biomass	generation fossil brown coal/lignite	generation fossil gas	generation fossil hard coal	generation fossil oil	generation hydro pumped storage consumption	generation hydro run-of-river and poundage	generation hydro water reservoir	generation nuclear	generation other	generation other renewable	generation solar	generation waste	generation wind onshore	forecast solar day ahead	forecast wind offshore eday ahead	forecast wind onshore day ahead	total load forecast	total load actual	price day ahead	price actual
