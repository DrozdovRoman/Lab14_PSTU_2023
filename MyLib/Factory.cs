using System;
using System.Collections.Generic;

namespace MyLib
{
    public class Factory: Manufacture,IRandomCreate
    {
        private int amountProducedPerHours;
        
        public Factory() : base()
        {
            this.amountProducedPerHours = 0;
        }
        
        public Factory(string x):base("r")
        {
            CreateRandom();
        }

        public Factory(int floorArea, int tax, List<Person>employeesFullNameList, string companyName, string companySpecialize, int amountProducedPerHours)
            : base(floorArea, tax, employeesFullNameList, companyName, companySpecialize)
        {
            this.AmountProducedPerHours = amountProducedPerHours;
        }
        
        public void CreateRandom()
        {
            Random rand = new Random();
            this.amountProducedPerHours = rand.Next() % 100;
        }
        
        public override string ToString()
        {
            return (base.ToString() + $"Количество производимой продукции в час: {this.amountProducedPerHours}\n");
        }
        
        public int AmountProducedPerHours
        {
            get => amountProducedPerHours;
            set
            {
                if (value < 1)
                {
                    Console.WriteLine("Ошибка! Минимальное количество производимой продукции равно 0.");
                    this.amountProducedPerHours = 0;
                }
                else this.amountProducedPerHours = value;

            }
        }
    }
}