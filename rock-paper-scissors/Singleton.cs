using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace rock_paper_scissors
{
    class Singleton
    {
        public class Game
        {
            static Game Singleton = new Game();
            private int user;
            private int computer;
            private int roundsPlayed;
            public int UserWins
            {
                get { return user; }
            }
            public int ComputerWins
            {
                get { return computer; }
            }
            public int RoundsPlayed
            {
                get { return roundsPlayed; }
            }
            public bool IsGameOver
            {
                get { return user >= 3 || computer >= 3; }
            }
            private string GetComputerChoice()
            {
                string[] choices = { "Камень", "Ножницы", "Бумага" };
                Random random = new Random();
                return choices[random.Next(choices.Length)];
            }
            private string DetermineWinner(string userChoice, string computerChoice)
            {

                if (userChoice == computerChoice)
                    return "Ничья!";
                bool userWins = (userChoice == "Камень" && computerChoice == "Ножницы") || (userChoice == "Ножницы" && computerChoice == "Бумага") || (userChoice == "Бумага" && computerChoice == "Камень");
                if (userWins) user++;
                else computer++;
                return userWins ? "Вы победили!" : "Вы проиграли!";
            }
            private Game()
            {
                ResetGame();
            }
            public static Game GetSingleton()
            {
                return Singleton;
            }
            public void ResetGame()
            {
                user = 0;
                computer = 0;
                roundsPlayed = 0;
            }
            public (string computerChoice, string result) PlayRound(string userChoice)
            {
                roundsPlayed++;
                string computerChoice = GetComputerChoice();
                string result = DetermineWinner(userChoice, computerChoice);
                return (computerChoice, result);
            }
        }
    }
}
