using System.Text.Json;
using System.IO;
using System.Text.Json.Serialization;
using System.ComponentModel;
using System.Xml;

namespace Algorithmisation
{
    internal class Program
    {
        class Cities 
        {
            [JsonPropertyName("Cities")]
            public List<City> cityList { get; set; }
            public Cities() { cityList = new List<City>(); }
            public void Adding(City city) { cityList.Add(city); }
        }
        struct City
        {
            [JsonPropertyName("City")]
            public string Name { get; set; }
            [JsonPropertyName("Country")]
            public string Country { get; set; }
            [JsonPropertyName("Quantity_of_citizens")]
            public int Quantity_of_citizens { get; set; }
        }
        static void Main(string[] args)
        {
            Cities c = new Cities();
            c.Adding(new City() { Name = "Vein", Country = "Austria", Quantity_of_citizens = 1982097 });
            c.Adding(new City() { Name = "Geneva", Country = "Switzerland", Quantity_of_citizens = 203840 });
            c.Adding(new City() { Name = "Zurich", Country = "Switzerland", Quantity_of_citizens = 447082 });
            string json_c = JsonSerializer.Serialize(c);
            File.WriteAllText("E:\\Projects_VS\\Algorithmisation\\Algorithmisation\\My_test.json", json_c);
            Cities got = JsonSerializer.Deserialize<Cities>(json_c);
            foreach (City city in got.cityList) { Console.WriteLine(city.Name); }
        }
    }
}