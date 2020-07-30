using System;
using System.Collections.Generic;
using System.Text;

namespace Console_Game
{
    public class Character
    {
        public string Name { get; set; }
        public int Healt { get; set; } = 350;
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
            Damage = random.Next(80, 100);
        }

        public void GenerateRandomDamage(int playerChoice)
        {
            int range = 0;
            switch (playerChoice)
            {
                case 1:
                    range = 80;
                    break;
                case 2:
                    range = 85;
                    break;
                case 3:
                    range = 90;
                    break;
                case 4:
                    range = 150;
                    break;
                default:
                    range = 70;
                    break;
            }

            Random random = new Random();
            Damage = random.Next(70, range);
        }

        public void ShowBattleReport(string userName, string botName, int healt, int damage)
        {
            Console.WriteLine($"{userName} нанес {damage} урона {botName}. У {botName} осталось [ {healt} ] хп\n");
        }
    }
}
