using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class Form1 : Form
    {
        bool turn = true; //If it is X's Turn
        int turn_count = 0;
        

        public Form1()
        {
            InitializeComponent();



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By Rajiv", "Tic Tac Toe");
        }

        private void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";

            }
            else
            {
                b.Text = "O";
            }
            turn = !turn;       //Next Player's turn
            b.Enabled = false; //Ensures that once a button is clicked, it cannot be changed.
            turn_count++;
            checkforwinner();
        }

        private void checkforwinner()
        {

            bool thewinner = false;
            //Horizontal Check
            if ((A1.Text == A2.Text) && (A2.Text == A3.Text) && (!A1.Enabled))
            
                thewinner = true;
            
            else if ((B1.Text == B2.Text) && (B2.Text == B3.Text) && (!B1.Enabled))
            
                thewinner = true;
            
            else if ((C1.Text == C2.Text) && (C2.Text == C3.Text) && (!C1.Enabled))
            
                thewinner = true;

            //Vertical Checks

            else if ((A1.Text == B1.Text) && (B1.Text == C1.Text) && (!A1.Enabled))

                thewinner = true;

            else if ((A2.Text == B2.Text) && (B2.Text == C2.Text) && (!A2.Enabled))

                thewinner = true;

            else if ((A3.Text == B3.Text) && (B3.Text == C3.Text) && (!A3.Enabled))

                thewinner = true;

            //Diagonal Checks

            else if ((A1.Text == B2.Text) && (B2.Text == C3.Text) && (!A1.Enabled))

                thewinner = true;

            else if ((A3.Text == B2.Text) && (B2.Text == C1.Text) && (!A3.Enabled))

                thewinner = true;


            if (thewinner) {
                disableButton(); //disables button, when winner is declared.
                String winnername = "";
                if (turn)
                {
                    winnername = "O";
                }
                else {
                    winnername = "X";
                }

                MessageBox.Show(winnername+" Wins!!", "Congratulations!!");
            }
            else if (turn_count == 9) {
                MessageBox.Show("It's a Draw", "Draw");
            }
        }

        //This method disables all the buttons which are enabled
        private void disableButton() {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch { 
            
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch
            {

            }
        }
    }
}
