using System;
using System.Collections.Generic;


namespace MyLib
{
    public class Manufacture : IRandomCreate, IComparable, ICloneable
    {
        protected int countEmployees, floorArea, tax;
        protected string companyName, companySpecialize;
        private List<Person> employeesFullNameList;

        public Manufacture()
        {
            this.FloorArea = 1;
            this.Tax = 0;
            this.EmployeesFullNameList = new List<Person>();
            this.countEmployees = 0;
            this.CompanyName = "";
            this.CompanySpecialize = "";
        }

        public Manufacture(string x)
        {
            CreateRandom();
        }
        
        public Manufacture(int floorArea, int tax, List<Person>employeesFullNameList, string companyName, string companySpecialize)
        {
            this.FloorArea = floorArea;
            this.Tax = tax;
            this.EmployeesFullNameList = employeesFullNameList;
            this.countEmployees = this.EmployeesFullNameList.Count;
            this.CompanyName = companyName;
            this.CompanySpecialize = companySpecialize;
        }
        
        public int CompareTo(object obj)
        {
            Manufacture temp = (Manufacture)obj;
            if (this.tax > temp.tax) return 1;
            if (this.tax < temp.tax) return -1;
            return 0;
        }

        public void CreateRandom()
        {
            List<string> companyNameList = new List<string>()
            {
                "Лукойл", "Сургутн", "Татн",
                "Новатэк", "Норильский нил", "Сибур",
                "Северталь", "Металлоинвест", "Стройгазмонтаж",
                "Катрен", "Merlion", "Евросибэнерго",
                "Нижнекамскнефтехим", "Ташир", "Уралкалий",
                "Сибирь", "Илим", "Сэтл Групп"
            };
            
            
            List<string> specializeNameList = new List<string>()
            {
                "Нефать", "Газ", "Детские игрушки",
                "Кофе", "Дерево", "Столы и стулья",
                "автопилотируемые автомобили", "ноутбуки",
                "бейсбольные биты", "водяные пистолеты"
            };
            Random rand = new Random();
            this.countEmployees = rand.Next() % 10;
            this.FloorArea = rand.Next() % 1500;
            this.tax = rand.Next() % 100;
            this.CompanyName = companyNameList[rand.Next() % 18];
            this.CompanySpecialize = specializeNameList[rand.Next() % 9 + 1];
            this.EmployeesFullNameList = new List<Person>();
            for (int i = 0; i < countEmployees; i++)
            {
                employeesFullNameList.Add(new Person());
            }


        }

        public Manufacture ShallowCopy()
        {
            return this;
        }

        public object Clone()
        {
            return new Manufacture(this.FloorArea, this.Tax, this.EmployeesFullNameList,
                "Клон " + this.CompanyName, this.CompanySpecialize);
        } 

        public override string ToString()
        {
            return ($"Название компании: {this.CompanyName}\n" +
                    $"Специализация компании: {this.CompanySpecialize}\n" +
                    $"Количество работников: {this.countEmployees}\n" +
                    $"Размер помещения: {this.FloorArea}\n" +
                    $"Размер налога: {this.Tax}\n");
        }
        public void PrintEmployeesFullName()
        {
            Console.WriteLine("Список работников:");
            foreach (var element in this.EmployeesFullNameList)
            {
                Console.WriteLine(element);
            }
        }

        public int FloorArea
        {
            get => floorArea;
            set
            {
                if (value < 1)
                {
                    Console.WriteLine("Ошибка! Минимальный размер площади 1 кв/м.");
                    this.floorArea = 1;
                }
                else this.floorArea = value;

            }
        }
        
        public int Tax
        {
            get => tax;
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Ошибка! Минимальный размер налога равен 0% .");
                    this.tax = 0;
                }
                else this.tax = value;

            }
        }
        public List<Person> EmployeesFullNameList
        {
            get => employeesFullNameList;
            set
            {
                employeesFullNameList = new List<Person>(value);
            }
        }

        public string CompanyName
        { get => companyName; set => companyName = value; }
        
        public int CountEmployees
        { get => countEmployees; set => countEmployees = value; }

        public string CompanySpecialize
        { set; get; }
    }
}