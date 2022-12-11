using ConsoleApp10.Classes;
using ConsoleApp10.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Product – данные о товаре: наименование, компания производитель(Company), количество.

namespace ConsoleApp10.Classes
{
    internal class Product : IClonable, IWriteble
    {
        public Product(string name, Company company, int count)
        {
            Name = name;
            Company = company;
            Count = count;
        }

        public string Name { get; set; }
        public Company Company { get; set; }
        public int Count { get; set; }

        public object Clone() => MemberwiseClone();

        public void Print() => Console.WriteLine(ToString());

        public override string ToString()
        {
            return "Наименование - [" + Name + "] | Компания производитель - [" + Company.ToString() + "] | Кол-во - [" + Count + "] " ;
        }
    }
}
