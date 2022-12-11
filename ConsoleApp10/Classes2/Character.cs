using ConsoleApp10.Interface2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Создайте класс Character, представляющий собой некоторого персонажа для игры. У
//персонажа должны быть следующие характеристики, представленные свойствами:
// Количество здоровья(HP) – сколько повреждений выдержит персонаж.
// Интеллект (Intellect) – показатель, особенно важный для Мага.
// Ловкость (Agility) – показатель, особенно важный для Лучника.
// Сила (Strength) – показатель, особенно важный для Война.

namespace ConsoleApp10.Classes2
{
    internal class Character : IWarrior, IArcher, IMage
    {
        public int HP { get; private set; } //здоровье
        public int Intellect { get; private set; } //интеллект
        public int Agility { get; private set; } //ловкость
        public int Strength { get; private set; } //сила
        public Role Role { get; set; }
        public Character(int hP, int intellect, int agility, int strength)
        {
            HP = hP;
            Intellect = intellect;
            Agility = agility;
            Strength = strength;
        }

        //определяем урон персонажа
        int IMage.Damage => 3 * Intellect + 2 * Agility + 1 * Strength; 
        int IWarrior.Damage => 1 * Intellect + 2 * Agility + 3 * Strength;
        int IArcher.Damage => 2 * Intellect + 3 * Agility + 1 * Strength;

        //переменная, указывающая жив ли игрок
        bool IRole.Alive => HP > 0;

        //метод, получения урона персонажем
        void IRole.getDamage(int damage)
        {
            this.HP -= damage;
            if (this.HP < 0)
                this.HP = 0;
            Console.WriteLine("  HP - '" + damage + "'| HP = {" + HP + "}");
        }
        public override string ToString()
        {
            return "Здоровье - [" + HP + "] | Интелект - [" + Intellect + "] | Ловкость - [" + Agility + "] | Сила - [" + Strength + "] | Роль - [" + Role + "]";
        }
    }
}
