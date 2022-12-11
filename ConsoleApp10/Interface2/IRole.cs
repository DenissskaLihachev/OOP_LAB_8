using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10.Interface2
{
    internal enum Role
    {
        Warrior,
        Archer,
        Mage
    }
    internal interface IRole
    {
        public virtual int Damage { get => 0; }
        bool Alive { get; }
        void getDamage(int damage);
        static void Battle(IRole irole_1, Role role_1, IRole irole_2, Role role_2)
        {
            int role_1_damage = role_1 switch
            {
                Role.Warrior => ((IWarrior)irole_1).Damage,
                Role.Archer => ((IArcher)irole_1).Damage,
                Role.Mage => ((IMage)irole_1).Damage,
                _ => 0
            };

            int role_2_damage = role_2 switch
            {
                Role.Warrior => ((IWarrior)irole_2).Damage,
                Role.Archer => ((IArcher)irole_2).Damage,
                Role.Mage => ((IMage)irole_2).Damage,
                _ => 0
            };

            do
            {
                Console.WriteLine("Первый игрок ");
                irole_1.getDamage(role_2_damage);

                Console.WriteLine("Второй игрок ");
                irole_2.getDamage(role_1_damage);

                Thread.Sleep(700);

                Console.WriteLine();
            } while (irole_1.Alive && irole_2.Alive);

            if (irole_1.Alive) Console.WriteLine("Победу одержал: ИГРОК 1");
            else if (irole_2.Alive) Console.WriteLine("Победу одержал: ИГРОК 2");
            else Console.WriteLine("НИЧЬЯ");
        }
    }
}
