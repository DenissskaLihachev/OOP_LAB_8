using ConsoleApp10.Classes;
using ConsoleApp10.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Company – данные о компании: название, директор(Person), год основания.

namespace ConsoleApp10.Classes
{
    internal class Company : IClonable, IWriteble
    {
        public Company(string name, Person person, int yearOfFoundation)
        {
            Name = name;
            Person = person;
            YearOfFoundation = yearOfFoundation;
        }

        public string Name { get; set; }
        public Person Person { get; set; }
        public int YearOfFoundation { get; set; }

        public object Clone() => MemberwiseClone();

        public void Print() => Console.WriteLine(ToString());

        public override string ToString()
        {
            return "Название - [" + Name + "] Директор - [" + Person.ToString() + "] | Год основания - [" + YearOfFoundation + "]";
        }
    }
}
