using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe_1
{
    public partial class Form1 : Form
    {
        bool turn = true;
        int turn_count = 0;

        public Form1()
        {
            InitializeComponent();

            // Map designer-created buttons to the logical field names used by the game logic.
            // These fields were declared in this class but not initialized, which caused the NullReferenceException.
            a1 = button1;
            a2 = button2;
            a3 = button3;
            b1 = button4;
            b2 = button5;
            b3 = button6;
            c1 = button7;
            c2 = button8;
            c3 = button9;
        }

        private void button_click(object sender, EventArgs e)
        {
            // Defensive cast: the Form was wired to this handler in the designer,
            // so guard against non-Button senders (prevents invalid cast exceptions).
            var b = sender as Button;
            if (b == null) return;

            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "0";
            }
            turn = !turn;
            b.Enabled = false;
            turn_count++;
            checkforwinner();
        }

        private void checkforwinner()
        {
            bool winner = false;

            //horizontal check
            if ((a1.Text == a2.Text) && (a2.Text == a3.Text) && (!a1.Enabled))
            {
                winner = true;
            }
            else if ((b1.Text == b2.Text) && (b2.Text == b3.Text) && (!b1.Enabled))
            {
                winner = true;
            }
            else if ((c1.Text == c2.Text) && (c2.Text == c3.Text) && (!c1.Enabled))
            {
                winner = true;
            }

            //vertical checks
            else if ((a1.Text == b1.Text) && (b1.Text == c1.Text) && (!a1.Enabled))
            {
                winner = true;
            }
            else if ((a2.Text == b2.Text) && (b2.Text == c2.Text) && (!a2.Enabled))
            {
                winner = true;
            }
            else if ((a3.Text == b3.Text) && (b3.Text == c3.Text) && (!a3.Enabled))
            {
                winner = true;
            }

            //diagonal check
            else if ((a1.Text == b2.Text) && (b2.Text == c3.Text) && (!a1.Enabled))
            {
                winner = true;
            }
            else if ((a3.Text == b2.Text) && (b2.Text == c1.Text) && (!c1.Enabled))
            {
                winner = true;
            }
            if (winner)
            {
                disablebutton();
                string w = "";
                if (turn)
                {
                    w = "O";
                }
                else
                {
                    w = "X";
                }
                MessageBox.Show(w + " Won !");
            }
            else
            {
                if (turn_count == 9)
                {
                    MessageBox.Show("Match Draw !");
                }
            }
        }
        private void disablebutton()
        {
            // Only operate on Button controls to avoid invalid casts.
            foreach (Control c in Controls)
            {
                if (c is Button b)
                {
                    b.Enabled = false;
                }
            }
        }


        private Button a1;
        private Button a2;
        private Button a3;
        private Button b1;
        private Button b2;
        private Button b3;
        private Button c1;
        private Button c2;
        private Button c3;

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            turn = true;
            turn_count = 0;

            // Only reset Button controls.
            foreach (Control c in Controls)
            {
                if (c is Button b)
                {
                    b.Enabled = true;
                    b.Text = "";
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Developed by Bilal");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
