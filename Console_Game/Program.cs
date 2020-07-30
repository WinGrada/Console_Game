using System;

namespace Console_Game
{
    public class Program
    {
        static void Main(string[] args)
        {
            Character enemy = new Character();
            enemy.Name = "Jadua";

            Player player = new Player();
            player.Name = "Sergey";


            while (true)
            {
                //----> Игрок бьет врага.
                if(player.PressButtonToHit() == 0)
                {
                    Console.WriteLine($"Увы, но {player.Name} не справился, и ПРОИГРАЛ битву!");
                    break;
                }

                player.GenerateRandomDamage(player.PressButtonToHit());
                enemy.GetHit(player.Damage);
                enemy.ShowBattleReport(enemy.Name, enemy.Healt, player.Damage);
                if (enemy.IsDeath(enemy.Name)) break;

                //----> Враг бьет героя.
                enemy.GenerateRandomDamage();
                player.GetHit(enemy.Damage);
                player.ShowBattleReport(player.Name, player.Healt, enemy.Damage);
                if (player.IsDeath(player.Name)) break;
            }
        }
    }
}
