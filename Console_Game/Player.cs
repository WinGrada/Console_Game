using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Console_Game
{
    public class Player : Character
    {
        public List<int> PlayerHits { get; private set; } = new List<int>();
        public List<int> RandomSuperHit { get; private set; } = new List<int>();
        public int ChoiceToHit { get; private set; }


        public void PressButtonToHit()
        {
            string playerChoice = "";
            int playerChoiceConvertedToInt = 0;
            int attempt = 3;  // Попытки для неверного ввода.

            while (true)
            {
                ShowOrderForSuperHit();
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
                if(MatchSuperHits())
                    Console.WriteLine(">> 4 - ДЛЯ СУПЕР УДАРА");
            }

            void ShowOrderForSuperHit()
            {
                Console.WriteLine($"Порядок ударов для СУПЕР удара: {RandomSuperHit[0]}, {RandomSuperHit[1]}, {RandomSuperHit[2]}\n");
            }
        }

        private void RecordPlayerHit(int hit)
        {
            PlayerHits.Add(hit);
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
            if (PlayerHits.Count < 3 && !IsStandartChoiceToHit(str))
                    return false;

            if (PlayerHits.Count > 3 )
            {
                if (IsStandartChoiceToHit(str) || str != "4")
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsStandartChoiceToHit(string str)
        {
            if (str == "1")
                return true;
            if (str == "2")
                return true;
            if (str == "3")
                return true;

            return false;
        }
        public void GenerateSuperHit()
        {
            var random = new Random();

            for (int i = 0; i < 3; i++)
            {
                RandomSuperHit.Add(random.Next(1, 4));
            }
        }

        public void EnterUserName()
        {
            Console.Write("Введи свое имя рыцарь: ");
            Name = Console.ReadLine();
        }

        private bool MatchSuperHits()
        {
            return PlayerHits.SequenceEqual(RandomSuperHit);
        }
    }
}
