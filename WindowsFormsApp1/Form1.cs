using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string player1, player2;
        int mode;
        int player = 1;
        int Xcounter, Ocounter, turnCounter, button_number = 0;
        string[,] buttons = new string[3, 3];
        public Form1(string _player1, string _player2, int _mode)
        {
            player1 = (_player1 == "") ? "Player1" : _player1;
            mode = _mode;
            player2 = (mode == 1) ? "Computer" : (_player2 == "") ? "Player2" : _player2;
            InitializeComponent();
            label1.Text = player1;
        }//End of function


        void start(Button b)
        {
            if (player == 1 && Xcounter < 3)
            {
                toggleButton(b);
                return;
            }
            else if (mode == 2 && player == 2 && Ocounter < 3)
            {
                toggleButton(b);
                return;
            }
            if (player == 1 && turnCounter >= 5 && Xcounter == 3)
            {
                label2.Text = "choose place to remove";
                checkPlaceOwner(b);
            }
            else if (mode == 2 && player == 2 && turnCounter > 5 && Ocounter == 3)
            {
                label2.Text = "choose place to remove";
                checkPlaceOwner(b);
            }

        }//End of function

        void toggleButton(Button b)
        {
            if (b.Text.Equals("X") || b.Text.Equals("O")) 
            {
                label2.Text = "choose another place";
            }
            else if (!b.Text.Equals("X") && !b.Text.Equals("O")) 
            {
                b.Text = (player == 1) ? "X" : "O";
                if (player == 1)
                {
                    Xcounter++;
                }
                else if (player == 2 && mode == 2)
                {
                    Ocounter++;
                }
                label2.Text = "";
                turnCounter++;
                checkWinner();
                label1.Text = (label1.Text == player2) ? player1 : player2;
                player = (player == 1) ? 2 : 1;
                if (mode == 1)
                    Computer();
            }
        }//End of function

        void checkPlaceOwner(Button b)
        {
            if (turnCounter % 2 == 0)
            {
                if (b.Text != "X")
                {
                    label2.Text = "This is not your place, choose another to remove";
                    return;
                }
                b.Text = "" + button_number;
                Xcounter--;
                label2.Text = "Choose where you want to set";

            }
            else
            {
                if (b.Text != "O")
                {
                    label2.Text = "This is not your place, choose another to remove";
                    return;
                }
                b.Text = "" + button_number;
                Ocounter--;
                label2.Text = "Choose where you want to set";
            }
        }//End of function

        void checkForComputer(Button b, out bool flag)
        {
            //if the button has number and O's less than 3
            if (!b.Text.Equals("O") && !b.Text.Equals("X") && Ocounter < 3)
            {
                b.Text = "O";
                Ocounter++;
                turnCounter++;
                label1.Text = player1;
                flag = true;
                return;
            }
            if (turnCounter >= 5 && b.Text.Equals("O") && Ocounter == 3)
            {
                b.Text = "" + button_number;
                Ocounter--;
                flag = false;
                return;
            }
            

            flag = false;
        }//End of function

        void Computer()
        {

            bool flag = false;
            Random rnd = new Random();
            int place = -1;

            while (flag == false)
            {
                place = rnd.Next(1, 10);


                switch (place)
                {
                    case 1:
                        //set the button number
                        button_number = 1;
                        //call the method checkforcomputer
                        checkForComputer(button1, out flag);
                        break;
                    case 2:
                        //set the button number
                        button_number = 2;
                        //call the method checkforcomputer
                        checkForComputer(button2, out flag);
                        break;
                    case 3:
                        //set the button number
                        button_number = 3;
                        //call the method checkforcomputer
                        checkForComputer(button3, out flag);
                        break;
                    case 4:
                        //set the button number
                        button_number = 4;
                        //call the method checkforcomputer
                        checkForComputer(button4, out flag);
                        break;
                    case 5:
                        //set the button number
                        button_number = 5;
                        //call the method checkforcomputer
                        checkForComputer(button5, out flag);
                        break;
                    case 6:
                        //set the button number
                        button_number = 6;
                        //call the method checkforcomputer
                        checkForComputer(button6, out flag);
                        break;
                    case 7:
                        //set the button number
                        button_number = 7;
                        //call the method checkforcomputer
                        checkForComputer(button7, out flag);
                        break;
                    case 8:
                        //set the button number
                        button_number = 8;
                        //call the method checkforcomputer
                        checkForComputer(button8, out flag);
                        break;
                    case 9:
                        //set the button number
                        button_number = 9;
                        //call the method checkforcomputer
                        checkForComputer(button9, out flag);
                        break;

                }

            }
            checkWinner();
            player = 1;
        }///End of function

        void checkWinner()
        {
            bool flag = false;
            
            if (turnCounter >= 5)
            {
                
                fillButtonText(buttons);
                string play = (player == 1) ? "X" : "O";
                
                if (buttons[0, 0] == play && buttons[1, 1] == play && buttons[2, 2] == play)
                {
                    flag = true;
                }
                else if (buttons[0, 2] == play && buttons[1, 1] == play && buttons[2, 0] == play)
                {
                    
                    flag = true;
                }
                //if(buttons[0,0]== player && [0,1])
                for (int i = 0; i < buttons.GetLength(0); i++)
                {

                    //vertical
                    if (buttons[0, i] == play && buttons[1, i] == play && buttons[2, i] == play)
                    {
                        flag = true;
                    }

                }
                //horizontal
                for (int i = 0; i < buttons.GetLength(0); i++)
                {

                    if (buttons[i, 0] == play && buttons[i, 1] == play && buttons[i, 2] == play)
                    {

                        flag = true;
                        
                    }
                }
            }


            if (flag)
            {
                string winner = (player == 1) ? player1 : player2;
                winner += " is the WINNER!!";
                MessageBox.Show(winner);
                Environment.Exit(0);
            }
        }//End of function

        void fillButtonText(string [,] buttons)
        {
            buttons[0, 0] = button1.Text;
            buttons[0, 1] = button2.Text;
            buttons[0, 2] = button3.Text;
            buttons[1, 0] = button4.Text;
            buttons[1, 1] = button5.Text;
            buttons[1, 2] = button6.Text;
            buttons[2, 0] = button7.Text;
            buttons[2, 1] = button8.Text;
            buttons[2, 2] = button9.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button_number = 1;
            start(button1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button_number = 2;
            start(button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button_number = 3;
            start(button3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button_number = 4;
            start(button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button_number = 5;
            start(button5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button_number = 6;
            start(button6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button_number = 7;
            start(button7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button_number = 8;
            start(button8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            button_number = 9;
            start(button9);
        }
    }
}
