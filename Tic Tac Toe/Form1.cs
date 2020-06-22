using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        bool turn = true; // true = X turn , false = O turn
        int turn_counter = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by Ivan Popov", "Tic Tac Toe about");
        }

        private void rToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The player who is playing \"X\" always goes first. Players alternate placing Xs and Os on the board until either player has three in a row, horizontally, vertically, or diagonally or until all squares on the grid are filled. If a player is able to draw three Xs or three Os in a row, then that player wins. If all squares are filled and neither player has made a complete row of Xs or Os, then the game is a draw.", "Tic Tac Toe rules");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            string message = "";
            string winner = "";
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
                b.Enabled = false;
            }
            else
            {
                b.Text = "O";
                b.Enabled = false;
            }
            turn_counter++;
            if (Has_Winn())
            {
                Disable_Buttons();
                if (turn)
                {
                    winner = "X";
                }
                else
                {
                    winner = "O";
                }

                /*  foreach (Control c in Controls)
                  {
                      Button b = (Button)c;
                      b.Enabled = false;
                  }*/

                message = " - Wins !";
                MessageBox.Show(winner + message);
            }
            else if (!Has_Winn() && turn_counter == 9)
            {
                message = "Draw";
                MessageBox.Show(message);
            }

            turn = !turn;
        }

        private bool Has_Winn()
        {
            //  Horizontal
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            {
                return true;
            }
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            {
                return true;
            }
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            {
                return true;
            }
            // Vertical
            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))
            {
                return true;
            }
            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))
            {
                return true;
            }
            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))
            {
                return true;
            }
            // Diagonal
            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))
            {
                return true;
            }
            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))
            {
                return true;
            }
            return false;
        }

        private void Disable_Buttons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch (Exception)
            {
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch (Exception)
            {
            }
            turn_counter = 0;
            turn = true;
        }
    }
}