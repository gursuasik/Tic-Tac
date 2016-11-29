using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tic_Tac
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] TicTac = new int[9];
        int c = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                Button button = new Button();
                this.Controls.Add(button);
                button.Name = i.ToString();
                button.Click += new EventHandler(b_Click);
                button.Size = new Size(100, 100);
                button.Location = new Point(i % 3 * 100 + 25, (i - (i % 3)) / 3 * 100 + 25);
                button.Font = new Font(new FontFamily("Comic Sans MS"), 40.0f);
                button.BringToFront();
            }
        }
        private void b_Click(object sender, EventArgs e)
        {
            if (TicTac[Convert.ToInt16((sender as Button).Name)] == 0)
            {
                if (c == 0)
                {
                    TicTac[Convert.ToInt16((sender as Button).Name)] = 1;//O
                    (sender as Button).Text = "O";
                }
                else
                {
                    TicTac[Convert.ToInt16((sender as Button).Name)] = 2;//X
                    (sender as Button).Text = "X";
                }
            }
            c = (c + 1) % 2;
            Tic_Tac();
        }
        private void Tic_Tac()
        {
            for (int i = 0; i < 3; i++)
            {
                if (TicTac[i * 3] != 0 && TicTac[i * 3] == TicTac[i * 3 + 1] && TicTac[i * 3 + 1] == TicTac[i * 3 + 2])//Horizantal
                {
                    NewGame();

                }
                if (TicTac[i] != 0 && TicTac[i] == TicTac[i + 3] && TicTac[i + 3] == TicTac[i + 6])//Vertical
                {
                    NewGame();
                }
            }
            if (TicTac[0] != 0 && TicTac[0] == TicTac[4] && TicTac[4] == TicTac[8])
            {
                NewGame();
            }
            if (TicTac[2] != 0 && TicTac[2] == TicTac[4] && TicTac[4] == TicTac[6])
            {
                NewGame();
            }
        }
        private void NewGame()
        {
            MessageBox.Show("New Game");
            for (int i = 0; i < 9; i++)
            {
                this.Controls[i].Text = "";
                TicTac[i] = 0;
            }
            c = 0;
        }
    }
}