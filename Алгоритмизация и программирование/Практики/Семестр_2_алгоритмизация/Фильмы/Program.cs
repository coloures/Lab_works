namespace cinema
{
    internal class Program
    {
        struct Film 
        {
            public string Name;
            public DateTime Start;
            public int Quantity_of_bought_places;
            public int Quantity_of_free_places;
            public Film(string s, DateTime st, int qobp, int qofp) 
            {
                Name = s;
                Start = st;
                Quantity_of_bought_places = qobp;
                Quantity_of_free_places = qofp;
            }

        }
        static void Main(string[] args)
        {
            List<Film> cinema = new List<Film>();
            cinema.Add(new Film("The Shawchank Redemption", 
                new DateTime(2024,5,30,13,30,00), 35, 15));
            cinema.Add(new Film("The Godfather",
                new DateTime(2024, 5, 30, 15, 45, 00), 25, 25));
            cinema.Add(new Film("Schindlers list",
                new DateTime(2024, 5, 30, 16, 30, 00), 35, 65));
            cinema.Add(new Film("Inception",
                new DateTime(2024, 5, 30, 22, 55, 00), 50, 0));
            cinema.Add(new Film("The Dark Knight",
                new DateTime(2024, 5, 30, 11, 30, 00), 44, 6));
            cinema.Add(new Film("Fight club",
                new DateTime(2024, 5, 30, 10, 30, 00), 25, 75));
            cinema.Add(new Film("The silence of the lambs",
                new DateTime(2024, 5, 30, 20, 10, 00), 65, 35));
            var popular_films = from film in cinema 
                                where (film.Quantity_of_bought_places*1.0)
                                /
                                (film.Quantity_of_bought_places+film.Quantity_of_free_places) >= 0.5
            select film;
            Console.WriteLine("Film with 50% of places bought");
            Console.WriteLine();

            foreach (Film film in popular_films) 
            {
                Console.WriteLine($"{film.Name} -- {film.Start.Hour}:{film.Start.Minute}\n" +
                    $"\tquantity of bought places = {film.Quantity_of_bought_places}\n" +
                    $"\tquantity of free places = {film.Quantity_of_free_places}");
            }

            var films_after_15_00 = from film in cinema
                                    where film.Start.Subtract(new DateTime(film.Start.Year, film.Start.Month, film.Start.Day, 15, 00, 00)).Minutes > 0
                                    select film;
            Console.WriteLine();
            Console.WriteLine("Film starting after 15:00");
            Console.WriteLine();
            foreach (Film film in films_after_15_00) 
            {
                Console.WriteLine($"{film.Name} -- {film.Start.Hour}:{film.Start.Minute}\n" +
                    $"\tquantity of bought places = {film.Quantity_of_bought_places}\n" +
                    $"\tquantity of free places = {film.Quantity_of_free_places}");
            }
        }
    }
}