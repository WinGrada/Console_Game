using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Console_Game
{
    public class Player : Character
    {
        public Queue<int> PlayerHits { get; private set; } = new Queue<int>();
        public int ChoiceToHit { get; private set; }

        public void PressButtonToHit()
        {
            string playerChoice = "";
            int playerChoiceConvertedToInt = 0;
            int attempt = 3;  // Попытки для неверного ввода.

            while (true)
            {
                ShowButtonToHit();
                playerChoice = Console.ReadLine();
                if (IsValidString(playerChoice) && attempt > 0)
                {
                    playerChoiceConvertedToInt = ConvertStrToInt(playerChoice);
                    RecordPlayerHit(playerChoiceConvertedToInt);
                    ChoiceToHit = playerChoiceConvertedToInt;
                    break;
                }
                else
                {
                    Console.WriteLine($"Вы ввели не существующий вариант, осталось попыток \"{(attempt - 1)}\"");
                    attempt--;
                    if (attempt > 0) continue;
                    ChoiceToHit = 0;
                    break;
                }
            }

            void ShowButtonToHit()
            {
                Console.WriteLine("Нажмите:");
                Console.WriteLine("> 1 - для удара в голову.");
                Console.WriteLine("> 2 - для удара в тело.");
                Console.WriteLine("> 3 - для удара в ноги.");
            }
        }

        private void RecordPlayerHit(int hit)
        {
            PlayerHits.Enqueue(hit);
        }

        private int ConvertStrToInt(string str)
        {
            return int.Parse(str);
        }

        private bool IsDigit(string str)
        {
            return new Regex(@"\d").IsMatch(str);
        }

        private bool IsValidString(string str)
        {
            if (str.Length != 1)
                return false;
            if (!IsDigit(str))
                return false;
            if (str != "1" && str != "2" && str != "3")
                return false;

            return true;
        }

        public void EnterUserName()
        {
            Console.Write("Введи свое имя рыцарь: ");
            Name = Console.ReadLine();
        }
    }
}
