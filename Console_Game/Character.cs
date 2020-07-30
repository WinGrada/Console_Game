using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Game
{
    public class Character
    {
        public string Name { get; set; }
        public int Healt { get; set; } = 200;
        public int Damage { get; private set; } = 0;

        public void GetHit(int damage)
        {
            if (damage > Healt)
                damage = Healt;

            Healt -= damage;
        }

        public bool IsDeath(string name)
        {
            if (Healt == 0)
            {
                Console.WriteLine($"\t****{name} ПОГИБ В БОЮ****");
                return true;
            }

            return false;
        }

        public void GenerateRandomDamage()
        {
            Random random = new Random();
            Damage = random.Next(100);
        }

        public void GenerateRandomDamage(int playerChoice)
        {
            int range = 0;
            switch (playerChoice)
            {
                case 1:
                    range = 83;
                    break;
                case 2:
                    range = 91;
                    break;
                case 3:
                    range = 100;
                    break;
                default:
                    range = 70;
                    break;
            }

            Random random = new Random();
            Damage = random.Next(60, range);
        }

        public void ShowBattleReport(string name, int healt, int damage)
        {
            Console.WriteLine($"{name} получил {damage} урона. \nОсталось {healt} ХП\n");
        }
    }
}
