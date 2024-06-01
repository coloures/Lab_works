using System.Text.Json;
using System.Text.Json.Serialization;

namespace First_sorting
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
            Console.WriteLine("Введите букву, с которой должны начинаться города (из английского алфавита):");
            string letter = Console.ReadLine().ToUpper();
            Cities from_definite_letter = new Cities();
            List<City> cities = (from city in all.cityList where city.Name.ToUpper().StartsWith(letter) select city).ToList<City>();
            from_definite_letter.cityList = cities;
            string json_after = JsonSerializer.Serialize(from_definite_letter);
            File.WriteAllText("E:\\Projects_VS\\Algorithmisation\\Algorithmisation\\My_test1.json", json_after);
        }
    }
}