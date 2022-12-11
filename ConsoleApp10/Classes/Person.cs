using ConsoleApp10.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Person – данные о человеке: имя, фамилия, возраст.

namespace ConsoleApp10.Classes
{
    internal class Person : IClonable, IWriteble
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Person(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }
        public object Clone() => MemberwiseClone();

        public void Print() => Console.WriteLine(ToString());

        public override string ToString()
        {
            return "Имя - [" + FirstName + "] | Фамилия - [" + LastName + "] | Возраст - [" + Age + "]";
        }
    }
}
