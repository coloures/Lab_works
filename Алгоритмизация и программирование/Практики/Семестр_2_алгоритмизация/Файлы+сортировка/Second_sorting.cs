using System.Diagnostics.Metrics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Second_sorting
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
    internal class Program
    {
        static void Main(string[] args)
        {
            string json_c = File.ReadAllText("E:\\Projects_VS\\Algorithmisation\\Algorithmisation\\My_test.json");
            Cities all = JsonSerializer.Deserialize<Cities>(json_c);
            Console.WriteLine("Введите название страны, города которой вас интересуют (на английском языке):");
            string country = Console.ReadLine().ToUpper();
            Cities from_one_country = new Cities();
            List<City> cities = (from city in all.cityList where city.Country.ToUpper() == country  select city).ToList<City>();
            from_one_country.cityList = cities;
            string json_after = JsonSerializer.Serialize(from_one_country);
            File.WriteAllText("E:\\Projects_VS\\Algorithmisation\\Algorithmisation\\My_test2.json", json_after);
        }
    }
}