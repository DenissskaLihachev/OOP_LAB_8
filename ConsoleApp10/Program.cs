//Создайте несколько объектов каждого класса Person, Company и Product (заполните
//данными) и поместите их в общий массив из объектов интерфейса IClonable.

//Создайте локальную функцию (или метод), которая принимает массив объектов IClonable и
//возвращает копию данного массива. Для этого используйте метод Clone() объектов массива.

//Создайте копию заполненного массива IClonable с помощью данной функции. В копии
//массива измените данные некоторых элементов (чтобы массивы немного различались).

//Выведите на консоль данные обоих массивов для демонстрации результата. Для вывода
//используйте интерфейс IWriteble (метод Print()).

using ConsoleApp10.Classes;
using ConsoleApp10.Classes2;
using ConsoleApp10.Interface;
using ConsoleApp10.Interface2;

using System.Threading;

namespace ConsoleApp10
{
    static class Lab
    {
        static void Main()
        {
            while(true)
            {
                Console.Write("1) Задание 1\n2) Задание 2\nВыбор: "); int choice = Convert.ToInt32(Console.ReadLine()); Console.Clear();
                switch (choice)
                {
                    case 1:
                        {
                            Task1();
                            break;
                        }
                    case 2:
                        {
                            Task2();
                            break;
                        }
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        static void Task1()
        {
            //создаем объекты каждого класса
            Person person = new Person("Denis", "Denisov", 77);
            Company company = new Company("OOO 'CompanyName'", person, 1999);
            Product product = new Product("Product", company, 999);

            //добавляем их в список
            List<IClonable> cloneables = new List<IClonable>();
            cloneables.Add(person);
            cloneables.Add(company);
            cloneables.Add(product);

            //создаем второй список, в который клонируем из первого
            List<IClonable> cloneables_2 = (List<IClonable>)IClonable.Clone(cloneables);

            //немного изменяем клонированный список
            cloneables.Add(person);
            ((Person)cloneables_2[0]).FirstName = "CloneFirstName";
            ((Person)cloneables_2[0]).LastName = "CloneLastName";

            //выводим
            for (int i = 0; i < cloneables.Count; i++)
                ((IWriteble)cloneables[i]).Print();
            Console.WriteLine();
            for (int i = 0; i < cloneables_2.Count; i++)
                ((IWriteble)cloneables_2[i]).Print();
        }
        static void Task2()
        {
            Random rand = new();
            List<Character> characters = new();

            //добаволяем двух персонажей с рандомными характеристиками
            characters.Add(new Character(rand.Next(100, 500), rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10)));
            characters.Add(new Character(rand.Next(100, 500), rand.Next(1, 10), rand.Next(1, 10), rand.Next(1, 10)));

            //вывод характеристик
            Console.WriteLine();
            for (int i = 0; i < characters.Count; i++)
                Console.WriteLine(characters[i].ToString());
            Console.WriteLine();

            //осуществляем выбор 1-го игрока
            Console.Write("0) Warrior\n1) Archer\n2) Mage\nВыбирает игрок 1: ");
            int choicePlayer1 = ReadLineToInt();

            //осуществляем выбор 2-го игрока
            Console.Write("0) Warrior\n1) Archer\n2) Mage\nВыбирает игрок 2: ");
            int choicePlayer2 = ReadLineToInt();

            //в зависимости от выбора игроков, выбирается их персонаж
            characters[0].Role = (Role)choicePlayer1;
            characters[1].Role = (Role)choicePlayer2;

            //выводим характеристики, но уже с выбором ролями игроков
            Console.WriteLine();
            for (int i = 0; i < characters.Count; i++)
                Console.WriteLine(characters[i].ToString());
            Console.WriteLine();

            //начинаем битву
            IRole.Battle(characters[0], characters[0].Role, characters[1], characters[1].Role);
        }

        //для преобразования строкового значения к целочисленному. Нужно для выбора
        public static int ReadLineToInt()
        {
            string str;

            do str = Console.ReadLine();
            while (!int.TryParse(str, out _));

            return int.Parse(str);
        }
    }
}