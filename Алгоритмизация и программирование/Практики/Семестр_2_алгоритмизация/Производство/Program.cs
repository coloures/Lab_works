namespace Proizvodstvo
{
    struct Worker 
    {
        public int id;
        public string name;
        public string categ_of_producing_products;
        public decimal salary;
        public int quantity;
        public decimal price;
        public Worker(int id = 1, string name = "IVAN IVANOV",
            string categ_of_producing_products = "office things", decimal salary = 10000.0m,
            int quantity = 100, decimal price = 100.0m)
        {
            this.id = id;
            this.name = name;
            this.categ_of_producing_products = categ_of_producing_products;
            this.salary = salary;
            this.quantity = quantity;
            this.price = price;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker(name :"Andrew Michaels", categ_of_producing_products: "building materials", salary: 15000.0m, quantity: 1000, price: 300.0m));
            workers.Add(new Worker(id : 2, name: "James Brown", categ_of_producing_products: "fastfood", salary: 13000.0m, quantity: 750, price: 475.0m));
            workers.Add(new Worker(id : 3, name: "Joe Jamerson", categ_of_producing_products: "finances", salary: 150000.0m, quantity: 40, price: 3000.0m));
            workers.Add(new Worker(id : 4, name: "Nick Emerson", categ_of_producing_products: "building materials", salary: 45000.0m, quantity: 10, price: 4300.0m));
            workers.Add(new Worker(id : 5, name: "Sam Samsonov", categ_of_producing_products: "building materials", salary: 35600.0m, quantity: 1000, price: 320.0m));
            workers.Add(new Worker(id : 6, name: "Alex Montgomery", categ_of_producing_products: "finances", salary: 70000.0m, quantity: 5000, price: 300.0m));
            
            var profitable_employees = from worker in workers where (worker.quantity * worker.price - worker.salary) > 0 
                                         select new { Key = worker, Value = worker.quantity * worker.price - worker.salary };

            foreach (var worker in profitable_employees) { Console.WriteLine($"{worker.Key.name} with id {worker.Key.id} has profit with amount of {worker.Value}"); }

            // (from worker in workers select worker.categ_of_producing_products).Distinct() - возвращает категории
            var produced_products = from category in (from worker in workers group worker.quantity by worker.categ_of_producing_products) 
                                    select new { Key = category.Key, Value = category.Sum() };

            foreach(var categories in produced_products) { Console.WriteLine($"In category {categories.Key} {categories.Value} have been produced"); }

            var total_price_of_products_in_category = from category in (from worker in workers group (worker.quantity*worker.price) by worker.categ_of_producing_products)
                                    select new { Key = category.Key, Value = category.Sum() };

            foreach (var categories in total_price_of_products_in_category) { Console.WriteLine($"In category {categories.Key} {categories.Value} rubles have been earned"); }

            int quantity_of_workers_with_50_percent_salary_from_profit = 
                (from worker in workers where decimal.ToDouble(worker.salary) / ((1.0) * decimal.ToDouble(worker.price) * worker.quantity) - 1E-8 >= 0.5 select worker).Count();

            Console.WriteLine($"There are {quantity_of_workers_with_50_percent_salary_from_profit} workers, who earn more than 50% from their profit!");
        } 
    }
}