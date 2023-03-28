using System;
using System.Collections.Generic;

namespace MyLib
{
    public class Workshop: Manufacture,IRandomCreate
    {
        private int amountProducedPerDay;
        
        public Workshop() : base()
        {
            this.amountProducedPerDay = 0;
        }
        
        public Workshop(string x):base("r")
        {
            CreateRandom();
        }

        public Workshop(int floorArea, int tax, List<Person>employeesFullNameList, string companyName, string companySpecialize, int amountProducedPerDay)
            : base(floorArea, tax, employeesFullNameList, companyName, companySpecialize)
        {
            this.AmountProducedPerDay = amountProducedPerDay;
        }

        public void CreateRandom()
        {
            Random rand = new Random();
            this.amountProducedPerDay = rand.Next() % 10;
        }

        public override string ToString()
        {
            return (base.ToString() + $"Количество производимой продукции в день: {this.amountProducedPerDay}\n");
        }

        public int AmountProducedPerDay
        {
            get => amountProducedPerDay;
            set
            {
                if (value < 1)
                {
                    Console.WriteLine("Ошибка! Минимальное количество производимой продукции равно 0.");
                    this.amountProducedPerDay = 0;
                }
                else this.amountProducedPerDay = value;

            }
        }

    }
}