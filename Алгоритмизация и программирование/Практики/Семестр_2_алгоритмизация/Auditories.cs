using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace BASE_OMGTU
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool cond = true;
            Menu menu_ = new Menu();
            while (cond) 
            {
                menu_.Main_writer();
                Console.WriteLine("Ввод: ");
                string an = Console.ReadLine();
                cond = menu_.Main_menu(an);
            }

        }
    }
    internal class Menu 
    {
        List<Auditory> base_of_auditories = new List<Auditory>();
        int quantity = 0;
        public Menu() 
        {
            Console.WriteLine("Появление базы данных по аудиториям");
        }
        public void Main_writer() 
        {
            Console.WriteLine("Здравствуйте, вы находитесь в основном меню\nВы можете выбрать следующие пункты:\n" +
                "1) Добавить аудиторию\n2) Проверить аудиторию на наличие в списке\n" +
                "3) Увидеть весь перечень аудиторий\n4) Выйти из программы\n5) Найти аудитории с большим кол-вом мест, чем задано" +
                "\n6) Найти аудитории по наличию проектора\n7) Найти аудитории по наличию компьютеров и количеству мест"); 
        }
        public bool Main_menu(string answer) 
        {
            if (answer == "Добавить аудиторию" || answer == "1" || answer == "1)")
            {
                Console.Write("Введите данные аудитории: ");
                string answer_ = Console.ReadLine();
                if (answer_.Length < 7)
                {
                    Add(answer_.Substring(0, 2), Convert.ToInt32(answer_.Substring(4, 2)));
                }
                else
                {
                    string[] answ = answer_.Split(',');
                    if (answ.Length == 3)
                    {
                        Add(answ[0], Convert.ToInt32(answ[1]), Convert.ToBoolean(answ[2]));
                    }
                    else
                    {
                        Add(answ[0], Convert.ToInt32(answ[1]), Convert.ToBoolean(answ[2]), Convert.ToBoolean(answ[3]));
                    }
                }
                return true;
            }
            else if (answer == "Проверить аудиторию на наличие в списке" || answer == "2" || answer == "2)")
            {
                Console.Write("Введите номер аудитории: ");
                string answer_ = Console.ReadLine();
                Show(base_of_auditories[Search(answer_)].Name_of_auditory);
                return true;
            }
            else if (answer == "Увидеть весь перечень аудиторий" || answer == "3" || answer == "3)")
            {
                Console.WriteLine($"Всего аудиторий {quantity}");
                All();
                return true;
            }
            else if (answer == "Выйти из программы" || answer == "4" || answer == "4)")
            {
                Exit();
                Console.WriteLine("Выхожу из программы");
                return false;
            }
            else if (answer == "Найти аудитории с большим кол-вом мест, чем задано" || answer == "5" || answer == "5)")
            {
                Console.Write("Введите минимальное количество мест: ");
                int quantity_of_places = Convert.ToInt32(Console.ReadLine());
                foreach (Auditory aud in Search_by_places(quantity_of_places))
                {
                    Console.WriteLine($"Номер аудитории: {aud.Name_of_auditory}\n" +
                        $"Наличие проектора: {aud.Projector}\n" +
                        $"Наличие компьютеров: {aud.Computers}");
                }
                return true;
            }
            else if (answer == "Найти аудитории по наличию проектора" || answer == "6" || answer == "6)")
            {
                Console.Write("Введите наличие проектора (true - проектор необходим; false - проектор не нужен): ");
                bool projector = Convert.ToBoolean(Console.ReadLine());
                foreach (Auditory aud in Search_by_projector(projector))
                {
                    Console.WriteLine($"Номер аудитории: {aud.Name_of_auditory}\n" +
                        $"Количество мест {aud.Places}\n" +
                        $"Наличие компьютеров: {aud.Computers}");
                }
                return true;
            }
            else if (answer == "Найти аудитории по наличию компьютеров и количеству мест" || answer == "7" || answer == "7)")
            {
                Console.Write("Введите количество мест: ");
                int places = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите наличие компьютеров (true - компьютеры есть; false - компьтеров нет): ");
                bool computer = Convert.ToBoolean(Console.ReadLine());
                foreach (Auditory aud in Search_by_pcs_and_places(places, computer))
                {
                    Console.WriteLine($"Номер аудитории: {aud.Name_of_auditory}\n" +
                        $"Наличие проектора: {aud.Projector}");
                }
                return true;
            }
            else 
            {
                Console.WriteLine("Вы ввели команду неверно!");
                return true;
            }



        }
        public void Add(string name_of_auditory, int places, bool computers = false, bool projector = false) 
        {
            base_of_auditories.Add(new Auditory(name_of_auditory, places, computers, projector));
            Console.WriteLine($"Создана аудитория {name_of_auditory}");
            quantity++;
        }
        public int Search(string name_of_auditory) 
        {
            int index = -1;
            foreach (Auditory auditory in base_of_auditories) 
            {
                if (auditory.Name_of_auditory == name_of_auditory) 
                {
                    index =  base_of_auditories.IndexOf(auditory);
                }
            }
            return index;
        }
        public List<Auditory> Search_by_places(int places) 
        {
            List <Auditory> auditories = new List<Auditory>();
            foreach (Auditory auditory in base_of_auditories) 
            {
                if (auditory.Places >= places) 
                {
                    auditories.Add(auditory);
                }
            }
            return auditories;
        }
        public List<Auditory> Search_by_projector (bool projector) 
        {
            List<Auditory> auditories = new List<Auditory>();
            foreach (Auditory auditory in base_of_auditories)
            {
                if (auditory.Projector == projector)
                {
                    auditories.Add(auditory);
                }
            }
            return auditories;
        }
        public List<Auditory> Search_by_pcs_and_places(int places, bool computer) 
        {
            List<Auditory> auditories = new List<Auditory>();
            foreach (Auditory auditory in base_of_auditories)
            {
                if (auditory.Places == places && auditory.Computers == computer)
                {
                    auditories.Add(auditory);
                }
            }
            return auditories;
        }
        public List<Auditory> Search_by_floor(int floor) 
        {
            List<Auditory> auditories = new List<Auditory>();
            foreach (Auditory auditory in base_of_auditories)
            {
                if (auditory.Floor == floor)
                {
                    auditories.Add(auditory);
                }
            }
            return auditories;
        }
        public void All() 
        {
            foreach (Auditory auditory in base_of_auditories) 
            {
                Show(auditory.Name_of_auditory);
            }
        }
        public void Changing_name(string name_of_auditory, string new_name_of_auditory) 
        {
            if (Search(name_of_auditory) != -1)
            {
                base_of_auditories[Search(name_of_auditory)].Name_of_auditory = new_name_of_auditory;
                Console.WriteLine($"Аудитория {name_of_auditory} заменена на {new_name_of_auditory}");
            }
            else { Console.WriteLine("Такой аудитории не существует!"); }
        }
        public void Changing_places(string name_of_auditory, int places) 
        {
            if (Search(name_of_auditory) != -1) 
            {
                base_of_auditories[Search(name_of_auditory)].Places = places;
                Console.WriteLine($"Количество мест в аудитории {name_of_auditory} заменено на {places}");
            }
            else { Console.WriteLine("Такой аудитории не существует!"); }
        }
        public void Changing_projector(string name_of_auditory, bool projector) 
        {
            if (Search(name_of_auditory) != -1) 
            {
                base_of_auditories[Search(name_of_auditory)].Projector = projector;
            }
            else { Console.WriteLine("Такой аудитории не существует!"); }
        }
        public void Changing_floor(string name_of_auditory, int floor) 
        {
            if (Search(name_of_auditory) != -1) 
            {
                base_of_auditories[Search(name_of_auditory)].Floor = floor;
                Console.WriteLine($"Аудитория {name_of_auditory} поднята на {floor} этаж ");
            }
            else { Console.WriteLine("Такой аудитории не существует!"); }
        }
        public void Changing_computers(string name_of_auditory, bool computers) 
        {
            if (Search(name_of_auditory) != -1) 
            {
                base_of_auditories[Search(name_of_auditory)].Computers = computers;
            }
            else { Console.WriteLine("Такой аудитории не существует!"); }
        }
        public void Show(string name_of_auditory) 
        {
            if (Search(name_of_auditory) != -1) 
            {
                Console.WriteLine($"Название аудитории: {base_of_auditories[Search(name_of_auditory)].Name_of_auditory}\n" +
                $"Количество мест: {base_of_auditories[Search(name_of_auditory)].Places}\n" +
                $"Наличие проектора: {base_of_auditories[Search(name_of_auditory)].Projector}\n" +
                $"Номер этажа: {base_of_auditories[Search(name_of_auditory)].Floor}\n" +
                $"Наличие компьютеров: {base_of_auditories[Search(name_of_auditory)].Computers}");
            }
            else { Console.WriteLine("Такой аудитории не существует!"); }
        }
        public void Exit() 
        {
            Console.WriteLine("Отчистка памяти");
            base_of_auditories.Clear();
        }

    }
    internal class Auditory 
    {
        string name_of_auditory;
        int places;
        bool projector;
        int floor;
        bool computers;
        public string Name_of_auditory 
        {
            get { return name_of_auditory; }
            set { if (value.Length >= 3) { name_of_auditory = string.Empty; }
                else { name_of_auditory = value; Floor = Convert.ToInt32(name_of_auditory[0]+""); }
            }
        }
        public int Places 
        {
            get { return places; }
            set { places = value; }
        }
        public bool Projector 
        {
            get { return projector; }
            set { projector = value; }
        }
        public int Floor 
        {
            get { return floor; }
            set
            {
                floor = value;
                if (Convert.ToInt32(Name_of_auditory) / 10 != floor)
                {
                    Name_of_auditory = floor.ToString() + Name_of_auditory[1].ToString();
                }
            }
        }
        public bool Computers 
        {
            get { return computers; }
            set { computers = value; }
        }

        public Auditory(string name_of_auditory, int places, bool computers = false, bool projector = false)
        {
            Name_of_auditory = name_of_auditory;
            this.projector = projector;
            this.floor = Convert.ToInt32(name_of_auditory[0] + "");
            this.places = places;
            this.computers = computers;
        }
    }
}
