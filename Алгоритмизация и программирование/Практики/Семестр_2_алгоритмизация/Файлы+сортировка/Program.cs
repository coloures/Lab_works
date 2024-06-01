using System.Text.Json;
using System.Text.Json.Serialization;

namespace Third_sorting
{
    struct Cities
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
            Console.WriteLine("Введите минимальное количество населения для города:");
            int country = Convert.ToInt32(Console.ReadLine());
            Cities with_bigger_quantity = new Cities();
            List<City> cities = (from city in all.cityList where city.Quantity_of_citizens >= country select city).ToList<City>();
            with_bigger_quantity.cityList = cities;
            string json_after = JsonSerializer.Serialize(with_bigger_quantity);
            File.WriteAllText("E:\\Projects_VS\\Algorithmisation\\Algorithmisation\\My_test3.json", json_after);
        }
    }
}