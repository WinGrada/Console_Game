using System;
using System.Threading.Tasks;

namespace Console_Game
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            Character enemy = new Character();
            enemy.Name = "Jadua";

            Player player = new Player();
            player.EnterUserName();


            while (true)
            {
                //===========================================================================================>
                //----> Игрок бьет врага.
                player.PressButtonToHit();
                if (player.ChoiceToHit == 0) // Если попыток ввода не осталось, ChoiceToHit равен 0.
                {
                    Console.WriteLine($"\n\t____Увы, но {player.Name} не справился, и ПРОИГРАЛ битву!____");
                    break;
                }
                player.GenerateRandomDamage(player.ChoiceToHit);
                enemy.GetHit(player.Damage);
                enemy.ShowBattleReport(player.Name, enemy.Name, enemy.Healt, player.Damage);
                if (enemy.IsDeath(enemy.Name))
                    break;

                await Task.Delay(1500);

                //===========================================================================================>
                //----> Враг бьет героя.
                enemy.GenerateRandomDamage();
                player.GetHit(enemy.Damage);
                player.ShowBattleReport(enemy.Name, player.Name, player.Healt, enemy.Damage);
                if (player.IsDeath(player.Name))
                    break;
            }
        }
    }
}
