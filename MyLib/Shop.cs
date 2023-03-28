using System;
using System.Collections.Generic;

namespace MyLib
{
    public class Shop: Manufacture,IRandomCreate
    {
        private int amountProducedPerMonth;
        
        public Shop() : base()
        {
            this.amountProducedPerMonth = 0;
        }
        
        public Shop(string x):base("r")
        {
            CreateRandom();
        }

        public Shop(int floorArea, int tax, List<Person>employeesFullNameList, string companyName, string companySpecialize, int amountProducedPerMonth)
            : base(floorArea, tax, employeesFullNameList, companyName, companySpecialize)
        {
            this.AmountProducedPerMonth = amountProducedPerMonth;
        }
        
        public void CreateRandom()
        {
            Random rand = new Random();
            this.amountProducedPerMonth = rand.Next() % 5;
        }
        
        public override string ToString()
        {
            return (base.ToString() + $"Количество производимой продукции в месяц: {this.amountProducedPerMonth}\n");
        }

        public int AmountProducedPerMonth
        {
            get => amountProducedPerMonth;
            set
            {
                if (value < 1)
                {
                    Console.WriteLine("Ошибка! Минимальное количество производимой продукции равно 0.");
                    this.amountProducedPerMonth = 0;
                }
                else this.amountProducedPerMonth = value;

            }
        }

    }
}