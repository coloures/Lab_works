namespace tovari
{
    internal class Program
    {
        struct tovar 
        {
            public string Articul { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public int Quantity { get; set; }
            public decimal Price { get; set; }
            public int Stock { get; set; }
        }
        static void Main(string[] args)
        {
            List<tovar> tovars = new List<tovar>() 
            { new tovar() {Articul = "001", Name = "Pen", Category = "chancery",
            Quantity = 100, Price = 10, Stock = 1},
            new tovar() {Articul = "043", Name = "Pde", Category = "chandecery",
            Quantity = 100, Price = 10, Stock = 1} ,
            new tovar() {Articul = "002", Name = "Pen2", Category = "chancery",
            Quantity = 100000, Price = 1000, Stock = 2},
            new tovar() {Articul = "03211", Name = "Pen3", Category = "chandecery",
            Quantity = 100, Price = 10, Stock = 2} };




            var value_of_each_stock = from stock in (from tovar in tovars group (tovar.Price*tovar.Quantity) by tovar.Stock) // объем каждого товара
                                      // в каждом складе
                                      select new {
                                          Key = stock.Key, 
                                          Value = stock.Sum() 
                                      };

            foreach (var value in value_of_each_stock) { Console.WriteLine($"{value.Key} {value.Value}"); }





            var biggest_by_each_category = from category in (from tovar in tovars group tovar.Price by tovar.Category) // группировка по цене в
                                           // каждой категории
                                           select new { 
                                               Key = category.Key, 
                                               Value = category.Max() 
                                           };

            foreach (var biggest in biggest_by_each_category) { Console.WriteLine($"{biggest.Key} {biggest.Value}"); }





            var average_by_each_category = from category in (from tovar in tovars group tovar.Price by tovar.Category)// группировка по цене в
                                           // каждой категории
                                           select new { 
                                               Key = category.Key, 
                                               Value = category.Average() 
                                           };

            foreach (var average in average_by_each_category) { Console.WriteLine($"{average.Key} {average.Value}"); }




            var cheapest_by_each_category = from category in (from tovar in tovars group new { Price = tovar.Price, Name = tovar.Name } by tovar.Category)
                                            // Группировка по категориям, где товары представлены "структурой" из её цены и названия товара
                                            select new { 
                                                Key = category.Key,
                                                Value = (from tov in category orderby tov.Price descending select tov).First() 
                                                // в каждой отдельной категории идет сортировка по цене товара по убыванию.
                                                // берется наименьшее значение
                                            };

            foreach (var cheapest in cheapest_by_each_category) { Console.WriteLine($"{cheapest.Key} {cheapest.Value.Name} {cheapest.Value.Price}"); }
            


            var cheapest_of_each_stock = from stock in (from tovar in tovars group new { Price = tovar.Price, Name = tovar.Name } by tovar.Stock) 
                                         // группировка по складам, где товары представлены "структурой" из её цены и названия товара
                                         select new { 
                                             Key = stock.Key, 
                                             Value = (from tov in stock orderby tov.Price ascending select tov).First()
                                             // сортировка товара по цене по возрастанию. Берется первое значение
                                         };

            foreach (var cheapest in cheapest_of_each_stock) { Console.WriteLine($"{cheapest.Key} {cheapest.Value.Name} {cheapest.Value.Price}"); }
        }
    }
}