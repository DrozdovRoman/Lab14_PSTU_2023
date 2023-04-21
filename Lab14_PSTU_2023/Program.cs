using System;
using System.Collections.Generic;
using System.Linq;
using MyLib;

namespace Lab14_PSTU_2023
{
    class Program
    {
        static Dictionary<Manufacture, Workshop> createCollectionDictionary(int countManufacture)
        {
            Dictionary<Manufacture, Workshop> branch = new Dictionary<Manufacture, Workshop>();
            int i = 0;
            while (i < countManufacture)
            {
                Workshop s = new Workshop("r");
                Manufacture x = s;
                if (!branch.ContainsKey(x))
                {
                    branch.Add(x, s);
                    i++;
                }
            }
            return branch;
        }

        static Stack<Dictionary<Manufacture, Workshop>> createCollectionStack(int countBranch,int countManufacture)
        {
            Stack<Dictionary<Manufacture, Workshop>> corporation = new();
            for (int i = 0; i < countBranch; i++)
            {
                corporation.Push(createCollectionDictionary(countManufacture));
            }
            return corporation;
        }

        static void PrintCollection(Stack<Dictionary<Manufacture, Workshop>> corpotation)
        {
            foreach (var branch in corpotation)
            {
                foreach (var element in branch)
                {
                    Console.WriteLine(element.Key);
                }
                Console.WriteLine("");
            }
        }

        static void QuerySelection(Stack<Dictionary<Manufacture, Workshop>> corporation)
        {
            Console.WriteLine("Запрос № 1 на выборку данных");
            Console.WriteLine("Список компаний с количеством работников больше 5: \n");

            var resLINQ = from branch in corporation from  element in branch where ((Manufacture)element.Value).CountEmployees > 5 select element;

            var resExtention = corporation.SelectMany(branch => branch).Select(element => element)
                .Where(element => element.Value.CountEmployees > 5);

            Console.WriteLine("Фильтрация LINQ: \n");
            foreach (var s in resLINQ)
                Console.WriteLine(s.Key);
            
            Console.WriteLine("\nФильтрация Extention: \n");
            foreach (var s in resExtention) 
                Console.WriteLine(s.Key);
        }

        static void QueryCount(Stack<Dictionary<Manufacture, Workshop>> corporation)
        {
            Console.WriteLine("\n\nЗапрос № 2 счетчик");
            Console.WriteLine("Количество помещений суммарной площадью больше 300");
            
            var resLINQ = (from branch in corporation from  element in branch where ((Manufacture)element.Value).FloorArea > 300 select element).Count();
            
            var resExtention = corporation.SelectMany(branch => branch)
                .Select(element => element).Count(element => element.Value.FloorArea > 300);
            
            Console.WriteLine("Фильтрация LINQ: ");
            Console.WriteLine(resLINQ);
            
            Console.WriteLine("Фильтрация Extention: ");
            Console.WriteLine(resExtention);
        }
        
        static void QueryUnion(Stack<Dictionary<Manufacture, Workshop>> corporation)
        {
            Console.WriteLine("\n\nЗапрос № 3 использование операций над множествами");
            Console.WriteLine("Объединение двух филиалов: \n");
            var temp = corporation.Pop();

            var resLINQ = (from element in temp select element).Union(from element in corporation.Peek() select element);  // LINQ
            corporation.Push(temp);
            
            temp = corporation.Pop();
            
            var resExtention = (temp.Select(element => element)).Union(corporation.Peek().Select(element => element));
            corporation.Push(temp);

            Console.WriteLine("LINQ: ");
            foreach (var element in resLINQ)
                Console.WriteLine(element.Key);

            Console.WriteLine("\nExtention: \n");
            foreach (var element in resExtention)
                Console.WriteLine(element);
        }
        
        static void QueryAgregate(Stack<Dictionary<Manufacture, Workshop>> corporation)
        {
            Console.WriteLine(" \n\nЗапрос № 4 агрегирование данных");
            Console.WriteLine("Средняя площадь предприятий:");

            double resLINQ = (from branch in corporation from element in branch select element.Value.FloorArea).Average();

            Console.WriteLine($"LINQ: {Math.Round(resLINQ, 2)}");

            double resExtention = corporation.SelectMany(branch => branch).Select(element => element.Value.FloorArea).Average();

            Console.WriteLine($"Extention: {Math.Round(resExtention, 2)}");
        }
        
        static void QueryGroupBy(Stack<Dictionary<Manufacture, Workshop>> corporation)
        {
            Console.WriteLine(" \n\nЗапрос № 5 группирование данных");
            Console.WriteLine("Группировка по сферам предприятий:");
            
            var resLINQ = from branch in corporation from element in branch group element by element.Value.CompanySpecialize;
            
            Console.WriteLine("LINQ: ");
            foreach (var element in resLINQ)
            {
                Console.WriteLine("\n"+element.Key + "\n");
                foreach (var company in element)
                {
                    Console.WriteLine(company.Value);
                }
            }

            var resExtention = corporation.SelectMany(branch => branch).Select(element => element).GroupBy(st => st.Value.CompanySpecialize);
            
            Console.WriteLine("Extention:");
            foreach (var element in resExtention)
            {
                Console.WriteLine("\n" + element.Key + "\n");
                foreach (var company in element)
                {
                    Console.WriteLine(company.Value);
                }
            }
            
        }
        
        static void Main(string[] args)
        {
            int sizeCorparation = 3;
            int sizeManufacture = 5;
            Stack<Dictionary<Manufacture, Workshop>> collection = createCollectionStack(3, 5);
            
            PrintCollection(collection);
            Console.Read();
            QuerySelection(collection);
            Console.Read();
            QueryCount(collection);
            Console.Read();
            QueryUnion(collection);
            Console.Read();
            QueryAgregate(collection);
            Console.Read();
            QueryGroupBy(collection);
        }
    }
}