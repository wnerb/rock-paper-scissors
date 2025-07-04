using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static rock_paper_scissors.Singleton;

namespace rock_paper_scissors
{
    public partial class Form1: Form
    {
        private Game game;
        public Form1()
        {
            InitializeComponent();
            game = Game.GetSingleton();
            UpdateInterface();
        }
        private void UpdateInterface()
        {
            lblScore.Text = $"Вы: {game.UserWins} - Компьютер: {game.ComputerWins}";
            lblRound.Text = $"Раунд: {game.RoundsPlayed}";
            if (game.IsGameOver)
            {
                string winner = game.UserWins >= 3 ? "Вы выиграли матч!" : "Компьютер выиграл матч!";
                lblResult.Text = $"{winner} Счёт: {game.UserWins}-{game.ComputerWins}";
                btnRock.Enabled = btnScissors.Enabled = btnPaper.Enabled = false;
                btnNewGame.Enabled = true;
            }
        }
        private void MakeChoice(string choice)
        {
            (string computerChoice, string result) roundResult = game.PlayRound(choice);
            lblComputerChoice.Text = roundResult.computerChoice != null ? $"Компьютер выбрал: {roundResult.computerChoice}" : roundResult.result;
            lblRoundResult.Text = roundResult.computerChoice != null ? roundResult.result : "";
            UpdateInterface();
        }
        private void btnScissors_Click(object sender, EventArgs e)
        {
            MakeChoice("Ножницы");
        }
        private void btnPaper_Click(object sender, EventArgs e)
        {
            MakeChoice("Бумага");
        }
        private void btnRock_Click(object sender, EventArgs e)
        {
            MakeChoice("Камень");
        }
        private void btnNewGame_Click(object sender, EventArgs e)
        {
            btnRock.Enabled = true;
            btnScissors.Enabled = true;
            btnPaper.Enabled = true;
            btnNewGame.Enabled = false;
            game.ResetGame();
            lblComputerChoice.Text = "Компьютер выбрал:";
            lblRoundResult.Text = "";
            lblResult.Text = "";
            UpdateInterface();
    }
    }
}
