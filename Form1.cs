using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Game
{
    public partial class Form1 : Form
    {
        int pTurn = 1; // whose turn it is
        int p1Wins = 0; // games that player one has won
        int p2Wins = 0; // games that player two has won
        int p3Wins = 0; // games that player three has won
        string p1Char = " "; // identifying char for player 1
        string p2Char = " "; // identifying char for player 2
        string p3Char = " "; // identifying char for player 3
        Button[,] btnArray = new Button[8, 8]; // array for the buttons
        string[] playerChars = {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"}; // array for possible player characters

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Initialize the array of buttons
            btnArray[0, 0] = button1;
            btnArray[0, 1] = button2;
            btnArray[0, 2] = button3;
            btnArray[0, 3] = button4;
            btnArray[0, 4] = button5;
            btnArray[0, 5] = button6;
            btnArray[0, 6] = button7;
            btnArray[0, 7] = button8;
            btnArray[1, 0] = button9;
            btnArray[1, 1] = button10;
            btnArray[1, 2] = button11;
            btnArray[1, 3] = button12;
            btnArray[1, 4] = button13;
            btnArray[1, 5] = button14;
            btnArray[1, 6] = button15;
            btnArray[1, 7] = button16;
            btnArray[2, 0] = button17;
            btnArray[2, 1] = button18;
            btnArray[2, 2] = button19;
            btnArray[2, 3] = button20;
            btnArray[2, 4] = button21;
            btnArray[2, 5] = button22;
            btnArray[2, 6] = button23;
            btnArray[2, 7] = button24;
            btnArray[3, 0] = button25;
            btnArray[3, 1] = button26;
            btnArray[3, 2] = button27;
            btnArray[3, 3] = button28;
            btnArray[3, 4] = button29;
            btnArray[3, 5] = button30;
            btnArray[3, 6] = button31;
            btnArray[3, 7] = button32;
            btnArray[4, 0] = button33;
            btnArray[4, 1] = button34;
            btnArray[4, 2] = button35;
            btnArray[4, 3] = button36;
            btnArray[4, 4] = button37;
            btnArray[4, 5] = button38;
            btnArray[4, 6] = button39;
            btnArray[4, 7] = button40;
            btnArray[5, 0] = button41;
            btnArray[5, 1] = button42;
            btnArray[5, 2] = button43;
            btnArray[5, 3] = button44;
            btnArray[5, 4] = button45;
            btnArray[5, 5] = button46;
            btnArray[5, 6] = button47;
            btnArray[5, 7] = button48;
            btnArray[6, 0] = button49;
            btnArray[6, 1] = button50;
            btnArray[6, 2] = button51;
            btnArray[6, 3] = button52;
            btnArray[6, 4] = button53;
            btnArray[6, 5] = button54;
            btnArray[6, 6] = button55;
            btnArray[6, 7] = button56;
            btnArray[7, 0] = button57;
            btnArray[7, 1] = button58;
            btnArray[7, 2] = button59;
            btnArray[7, 3] = button60;
            btnArray[7, 4] = button61;
            btnArray[7, 5] = button62;
            btnArray[7, 6] = button63;
            btnArray[7, 7] = button64;
            #endregion
            // load the comboBoxes with the playerChar arrays
            p1combobox.BeginUpdate();
            p2combobox.BeginUpdate();
            p3combobox.BeginUpdate();

            for (int i = 0; i < playerChars.Length; i++)
            {
                p1combobox.Items.Add(playerChars[i]);
                p2combobox.Items.Add(playerChars[i]);
                p3combobox.Items.Add(playerChars[i]);
            }

            p1combobox.EndUpdate();
            p2combobox.EndUpdate();
            p3combobox.EndUpdate();
        }


        private void setPlayerLetter(object sender, EventArgs e)
        {
            int i;

            if (p1combobox.SelectedIndex >= 0) // check and change p1 character
            {
                i = p1combobox.SelectedIndex;
                p1Char = playerChars[i];
            }

            if (p2combobox.SelectedIndex >= 0) // check and change p2 character
            {
                i = p2combobox.SelectedIndex;
                p2Char = playerChars[i];
            }

            if (p3combobox.SelectedIndex >= 0) // check and change p3 character
            {
                i = p3combobox.SelectedIndex;
                p3Char = playerChars[i];
            }

            // if all player characters set, ready the board
            if (p1combobox.SelectedIndex >= 0 && p2combobox.SelectedIndex >= 0 && p3combobox.SelectedIndex >= 0)
            {
                // make sure players don't have the same character
                if (p1Char == p2Char || p1Char == p3Char || p2Char == p3Char)
                {
                    MessageBox.Show("Please ensure that each player is using a unique character.", "Error");
                }
                else
                {
                    p1combobox.Enabled = false;
                    p2combobox.Enabled = false;
                    p3combobox.Enabled = false;
                    foreach (Button btn in btnArray)
                    {
                        btn.Enabled = true;
                    }
                }
            }
        }

        private void buttonPress(object sender, EventArgs e)
        {
            Button pressedButton = (Button)sender;

            switch (pTurn)
            {
                case 1:
                    {
                        pressedButton.Text = p1Char;
                        pressedButton.Enabled = false;
                        if (!checkWinner(p1Char))
                        {
                            pTurn = 2;
                            turnLabel.Text = "Player Two Turn";
                        }
                        else
                        {
                            displayWinner();
                        }
                        break;
                    }
                case 2:
                    {
                        pressedButton.Text = p2Char;
                        pressedButton.Enabled = false;
                        if (!checkWinner(p2Char))
                        {
                            pTurn = 3;
                            turnLabel.Text = "Player Three Turn";
                        } else
                        {
                            displayWinner();
                        }
                        break;
                    }
                case 3:
                    {
                        pressedButton.Text = p3Char;
                        pressedButton.Enabled = false;
                        if (!checkWinner(p3Char))
                        {
                            pTurn = 1;
                            turnLabel.Text = "Player One Turn";
                        } else
                        {
                            displayWinner();
                        }
                        break;
                    }
            }
        }

        private bool checkWinner(string p)
        {
            string player = p + p + p + p;
            string line = ""; // string to search for winner

            // check rows
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++) // add a row to the line
                {
                    line += btnArray[row, col].Text;
                }

                if (line.Contains(player)) // check line for winner
                {
                    return true;
                } else
                {
                    line = ""; // no winner = clear the line
                }
            }

            // check columns
            for (int col = 0; col < 8; col++)
            {
                for (int row = 0; row < 8; row++) // add a column to the line
                {
                    line += btnArray[row, col].Text;
                }

                if (line.Contains(player)) // check line for winner
                {
                    return true;
                } else
                {
                    line = ""; // no winner = clear the line
                }
            }

            #region //check diagonals

            // \ diagonals
            for (int row = 4, col = 0; row < 8; row++, col++)
            {
                line += btnArray[row, col].Text;
            }

            if (line.Contains(player)) // check line for winner
            {
                return true;
            }
            else
            {
                line = ""; // no winner = clear the line
            }

            for (int row = 3, col = 0; row < 8; row++, col++)
            {
                line += btnArray[row, col].Text;
            }

            if (line.Contains(player)) // check line for winner
            {
                return true;
            }
            else
            {
                line = ""; // no winner = clear the line
            }

            for (int row = 2, col = 0; row < 8; row++, col++)
            {
                line += btnArray[row, col].Text;
            }

            if (line.Contains(player)) // check line for winner
            {
                return true;
            }
            else
            {
                line = ""; // no winner = clear the line
            }

            for (int row = 1, col = 0; row < 8; row++, col++)
            {
                line += btnArray[row, col].Text;
            }

            if (line.Contains(player)) // check line for winner
            {
                return true;
            }
            else
            {
                line = ""; // no winner = clear the line
            }

            for (int row = 0, col = 0; row < 8; row++, col++)
            {
                line += btnArray[row, col].Text;
            }

            if (line.Contains(player)) // check line for winner
            {
                return true;
            }
            else
            {
                line = ""; // no winner = clear the line
            }

            for (int row = 0, col = 1; col < 8; row++, col++)
            {
                line += btnArray[row, col].Text;
            }

            if (line.Contains(player)) // check line for winner
            {
                return true;
            }
            else
            {
                line = ""; // no winner = clear the line
            }

            for (int row = 0, col = 2; col < 8; row++, col++)
            {
                line += btnArray[row, col].Text;
            }

            if (line.Contains(player)) // check line for winner
            {
                return true;
            }
            else
            {
                line = ""; // no winner = clear the line
            }

            for (int row = 0, col = 3; col < 8; row++, col++)
            {
                line += btnArray[row, col].Text;
            }

            if (line.Contains(player)) // check line for winner
            {
                return true;
            }
            else
            {
                line = ""; // no winner = clear the line
            }

            for (int row = 0, col = 4; col < 8; row++, col++)
            {
                line += btnArray[row, col].Text;
            }

            if (line.Contains(player)) // check line for winner
            {
                return true;
            }
            else
            {
                line = ""; // no winner = clear the line
            }

            // / diagonals
            for (int row = 0, col = 3; col >= 0; row++, col--)
            {
                line += btnArray[row, col].Text;
            }

            if (line.Contains(player)) // check line for winner
            {
                return true;
            }
            else
            {
                line = ""; // no winner = clear the line
            }

            for (int row = 0, col = 4; col >= 0; row++, col--)
            {
                line += btnArray[row, col].Text;
            }

            if (line.Contains(player)) // check line for winner
            {
                return true;
            }
            else
            {
                line = ""; // no winner = clear the line
            }

            for (int row = 0, col = 5; col >= 0; row++, col--)
            {
                line += btnArray[row, col].Text;
            }

            if (line.Contains(player)) // check line for winner
            {
                return true;
            }
            else
            {
                line = ""; // no winner = clear the line
            }

            for (int row = 0, col = 6; col >= 0; row++, col--)
            {
                line += btnArray[row, col].Text;
            }

            if (line.Contains(player)) // check line for winner
            {
                return true;
            }
            else
            {
                line = ""; // no winner = clear the line
            }

            for (int row = 0, col = 7; col >= 0; row++, col--)
            {
                line += btnArray[row, col].Text;
            }

            if (line.Contains(player)) // check line for winner
            {
                return true;
            }
            else
            {
                line = ""; // no winner = clear the line
            }

            for (int row = 1, col = 7; row < 8; row++, col--)
            {
                line += btnArray[row, col].Text;
            }

            if (line.Contains(player)) // check line for winner
            {
                return true;
            }
            else
            {
                line = ""; // no winner = clear the line
            }

            for (int row = 2, col = 7; row < 8; row++, col--)
            {
                line += btnArray[row, col].Text;
            }

            if (line.Contains(player)) // check line for winner
            {
                return true;
            }
            else
            {
                line = ""; // no winner = clear the line
            }

            for (int row = 3, col = 7; row < 8; row++, col--)
            {
                line += btnArray[row, col].Text;
            }

            if (line.Contains(player)) // check line for winner
            {
                return true;
            }
            else
            {
                line = ""; // no winner = clear the line
            }

            for (int row = 4, col = 7; row < 8; row++, col--)
            {
                line += btnArray[row, col].Text;
            }

            if (line.Contains(player)) // check line for winner
            {
                return true;
            }
            else
            {
                line = ""; // no winner = clear the line
            }
            #endregion

            return false;
        }

        private void displayWinner()
        {
            foreach (Button btn in btnArray)
            {
                btn.Enabled = false;
            }

            switch (pTurn)
            {
                case 1:
                    {
                        p1Wins++;
                        p1WinsLabel.Text = "Games Won: " + p1Wins;
                        break;
                    }
                case 2:
                    {
                        p2Wins++;
                        p2WinsLabel.Text = "Games Won: " + p2Wins;
                        break;
                    }
                case 3:
                    {
                        p3Wins++;
                        p3WinsLabel.Text = "Games Won: " + p3Wins;
                        break;
                    }
            }

            MessageBox.Show("Player " + pTurn + " has won!", "Congratulations!");
        }

        private void newGameStarted(object sender, EventArgs e)
        {
            foreach (Button btn in btnArray)
            {
                btn.Text = " ";
                btn.Enabled = true;
            }

            DialogResult dr = MessageBox.Show("Would you like to reset your characters?", "Reset Characters?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                p1combobox.Enabled = true;
                p2combobox.Enabled = true;
                p3combobox.Enabled = true;
                p1combobox.SelectedIndex = -1;
                p2combobox.SelectedIndex = -1;
                p3combobox.SelectedIndex = -1;
            }
        }

        private void showInstructions(object sender, EventArgs e)
        {
            MessageBox.Show("First, have each player select a unique character to identify themselves.\n\nNext, take turns placing your character on the grid of buttons.\n\nThe first player to get four in a row, either horizontally, vertically, or diagonally, wins!\n\nGood Luck!", "Instructions");
        }
    }
}
