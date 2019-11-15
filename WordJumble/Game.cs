using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WordJumble
{
    public partial class Game : Form
    {
        /// <summary>
        /// Rules:
        /// Words must be <= 12 characters
        /// Use 5 words and a final word
        /// XML file must contain title, subtitle, 5 words, 5 hints, final word, final clue, and reference to the used letters from the first 5 words
        /// </summary>

        private string word1;
        public string Word1 { set => word1 = value; }
        private string word2;
        public string Word2 { set => word2 = value; }
        private string word3;
        public string Word3 { set => word3 = value; }
        private string word4;
        public string Word4 { set => word4 = value; }
        private string word5;
        public string Word5 { set => word5 = value; }
        private string finalWord;
        public string FinalWord { set => finalWord = value; }
        private string manager;
        public string Manager { set => manager = value; }

        public Game()
        {
            InitializeComponent();
            new GetPuzzle(this);
            jumbleFinal.Text = "";
            HideBoxes();
        }

        private void HideBoxes()
        {
            //Trim the textboxes to match the length of the words
            char[] marker = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L' };

            for (int i = word1.Length; i < 12; i++)
            {
                groupBox1.Controls.Find($"guess1{marker[i].ToString()}", true)[0].Visible = false;
            }
            for (int i = word2.Length; i < 12; i++)
            {
                groupBox1.Controls.Find($"guess2{marker[i].ToString()}", true)[0].Visible = false;
            }
            for (int i = word3.Length; i < 12; i++)
            {
                groupBox1.Controls.Find($"guess3{marker[i].ToString()}", true)[0].Visible = false;
            }
            for (int i = word4.Length; i < 12; i++)
            {
                groupBox1.Controls.Find($"guess4{marker[i].ToString()}", true)[0].Visible = false;
            }
            for (int i = word5.Length; i < 12; i++)
            {
                groupBox1.Controls.Find($"guess5{marker[i].ToString()}", true)[0].Visible = false;
            }
            for (int i = finalWord.Length; i < 12; i++)
            {
                groupBox3.Controls.Find($"final{marker[i].ToString()}", true)[0].Visible = false;
            }

        }

        private void Input1(TextBox txt)
        {
            //Script to run whenever text in the first 5 questions is changed

            //Whenever the text in the first 5 words is changed, update the jumble of the final to reflect items in the gray boxes
            Regex firstFive = new Regex(@"guess[1-5][A-L]");
            jumbleFinal.Text = " ";

            foreach (TextBox box in groupBox1.Controls.OfType<TextBox>())
            {
                if ((firstFive.Match(box.Name.ToString()).ToString() == box.Name.ToString()) && (box.BackColor == Color.Silver) && box.Text != "")
                {
                    jumbleFinal.Text += box.Text.ToUpper();
                    jumbleFinal.Text += " ";
                }
            }
            Input2(txt);
        }

        private void Input2(TextBox txt)
        { 
            //Test to make sure that the changed text is appropriate and alphabetic
            Regex alpha = new Regex(@"[a-z]|[A-Z]");
            if (txt.Text.Length > 1)
            {
                MessageBox.Show("Only one letter allowed per space!", "Invalid Character", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt.Text = "";
            }
            else if (alpha.Match(txt.Text).ToString().ToUpper() != txt.Text.ToUpper())
            {
                MessageBox.Show("Please enter an alphabetic character!", "Invalid Character", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txt.Text = "";
            }
            else
            {
                //Move to the next box if a letter was typed
                if (txt.Text != "") { SelectNextControl(txt, true, false, true, false); }
                txt.Text = txt.Text.ToUpper();
            }
        }

        private void CheckAnswers_Click(object sender, EventArgs e)
        {
            //Checks whether the submitted answers match the actual answers
            bool q1 = false;
            bool q2 = false;
            bool q3 = false;
            bool q4 = false;
            bool q5 = false;
            bool qF = false;

            char[] marker = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L' };
            string word = "";

            //Test the regular words
            for (int w = 1; w <= 5; w++)
            {
                word = "";
                for (int i = 0; i < 12; i++)
                {
                    word += Controls.Find($"guess{w}{marker[i].ToString()}", true)[0].Text;
                }
                switch (w)
                {
                    case 1:
                        if (word1 == word) { q1 = true; }
                        break;
                    case 2:
                        if (word2 == word) { q2 = true; }
                        break;
                    case 3:
                        if (word3 == word) { q3 = true; }
                        break;
                    case 4:
                        if (word4 == word) { q4 = true; }
                        break;
                    case 5:
                        if (word5 == word) { q5 = true; }
                        break;
                }
            }

            //Test the final word
            word = "";
            for (int i = 0; i < 12; i++)
            {
                word += Controls.Find($"final{marker[i].ToString()}", true)[0].Text;
            }
            if (finalWord == word) { qF = true; }

            if (q1 == true && q2 == true && q3 == true && q4 == true && q5 == true && qF == true)
            {
                GameWon();
            }
            else
            {
                string message = "I'm sorry, but one or more of the answers you provided is incorrect. Please keep trying.";
                MessageBox.Show(message, "Invalid Answers", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void GameWon()
        {
            //Indicates that the correct answers were submitted
            Congratulations gameOver = new Congratulations(title.Text, subtitle.Text, manager);
            Hide();
            gameOver.Show();
        }

        //TextChanged events to handle each textBox
        private void Guess1A_TextChanged(object sender, EventArgs e)
        {
            Input1(guess1A);
        }

        private void Guess1B_TextChanged(object sender, EventArgs e)
        {
            Input1(guess1B);
        }

        private void Guess1C_TextChanged(object sender, EventArgs e)
        {
            Input1(guess1C);
        }

        private void Guess1D_TextChanged(object sender, EventArgs e)
        {
            Input1(guess1D);
        }

        private void Guess1E_TextChanged(object sender, EventArgs e)
        {
            Input1(guess1E);
        }

        private void Guess1F_TextChanged(object sender, EventArgs e)
        {
            Input1(guess1F);
        }

        private void Guess1G_TextChanged(object sender, EventArgs e)
        {
            Input1(guess1G);
        }

        private void Guess1H_TextChanged(object sender, EventArgs e)
        {
            Input1(guess1H);
        }

        private void Guess1I_TextChanged(object sender, EventArgs e)
        {
            Input1(guess1I);
        }

        private void Guess1J_TextChanged(object sender, EventArgs e)
        {
            Input1(guess1J);
        }

        private void Guess1K_TextChanged(object sender, EventArgs e)
        {
            Input1(guess1K);
        }

        private void Guess1L_TextChanged(object sender, EventArgs e)
        {
            Input1(guess1L);
        }

        private void Guess2A_TextChanged(object sender, EventArgs e)
        {
            Input1(guess2A);
        }

        private void Guess2B_TextChanged(object sender, EventArgs e)
        {
            Input1(guess2B);
        }

        private void Guess2C_TextChanged(object sender, EventArgs e)
        {
            Input1(guess2C);
        }

        private void Guess2D_TextChanged(object sender, EventArgs e)
        {
            Input1(guess2D);
        }

        private void Guess2E_TextChanged(object sender, EventArgs e)
        {
            Input1(guess2E);
        }

        private void Guess2F_TextChanged(object sender, EventArgs e)
        {
            Input1(guess2F);
        }

        private void Guess2G_TextChanged(object sender, EventArgs e)
        {
            Input1(guess2G);
        }

        private void Guess2H_TextChanged(object sender, EventArgs e)
        {
            Input1(guess2H);
        }

        private void Guess2I_TextChanged(object sender, EventArgs e)
        {
            Input1(guess2I);
        }

        private void Guess2J_TextChanged(object sender, EventArgs e)
        {
            Input1(guess2J);
        }

        private void Guess2K_TextChanged(object sender, EventArgs e)
        {
            Input1(guess2K);
        }

        private void Guess2L_TextChanged(object sender, EventArgs e)
        {
            Input1(guess2L);
        }

        private void Guess3A_TextChanged(object sender, EventArgs e)
        {
            Input1(guess3A);
        }

        private void Guess3B_TextChanged(object sender, EventArgs e)
        {
            Input1(guess3B);
        }

        private void Guess3C_TextChanged(object sender, EventArgs e)
        {
            Input1(guess3C);
        }

        private void Guess3D_TextChanged(object sender, EventArgs e)
        {
            Input1(guess3D);
        }

        private void Guess3E_TextChanged(object sender, EventArgs e)
        {
            Input1(guess3E);
        }

        private void Guess3F_TextChanged(object sender, EventArgs e)
        {
            Input1(guess3F);
        }

        private void Guess3G_TextChanged(object sender, EventArgs e)
        {
            Input1(guess3G);
        }

        private void Guess3H_TextChanged(object sender, EventArgs e)
        {
            Input1(guess3H);
        }

        private void Guess3I_TextChanged(object sender, EventArgs e)
        {
            Input1(guess3I);
        }

        private void Guess3J_TextChanged(object sender, EventArgs e)
        {
            Input1(guess3J);
        }

        private void Guess3K_TextChanged(object sender, EventArgs e)
        {
            Input1(guess3K);
        }

        private void Guess3L_TextChanged(object sender, EventArgs e)
        {
            Input1(guess3L);
        }

        private void Guess4A_TextChanged(object sender, EventArgs e)
        {
            Input1(guess4A);
        }

        private void Guess4B_TextChanged(object sender, EventArgs e)
        {
            Input1(guess4B);
        }

        private void Guess4C_TextChanged(object sender, EventArgs e)
        {
            Input1(guess4C);
        }

        private void Guess4D_TextChanged(object sender, EventArgs e)
        {
            Input1(guess4D);
        }

        private void Guess4E_TextChanged(object sender, EventArgs e)
        {
            Input1(guess4E);
        }

        private void Guess4F_TextChanged(object sender, EventArgs e)
        {
            Input1(guess4F);
        }

        private void Guess4G_TextChanged(object sender, EventArgs e)
        {
            Input1(guess4G);
        }

        private void Guess4H_TextChanged(object sender, EventArgs e)
        {
            Input1(guess4H);
        }

        private void Guess4I_TextChanged(object sender, EventArgs e)
        {
            Input1(guess4I);
        }

        private void Guess4J_TextChanged(object sender, EventArgs e)
        {
            Input1(guess4J);
        }

        private void Guess4K_TextChanged(object sender, EventArgs e)
        {
            Input1(guess4K);
        }

        private void Guess4L_TextChanged(object sender, EventArgs e)
        {
            Input1(guess4L);
        }

        private void Guess5A_TextChanged(object sender, EventArgs e)
        {
            Input1(guess5A);
        }

        private void Guess5B_TextChanged(object sender, EventArgs e)
        {
            Input1(guess5B);
        }

        private void Guess5C_TextChanged(object sender, EventArgs e)
        {
            Input1(guess5C);
        }

        private void Guess5D_TextChanged(object sender, EventArgs e)
        {
            Input1(guess5D);
        }

        private void Guess5E_TextChanged(object sender, EventArgs e)
        {
            Input1(guess5E);
        }

        private void Guess5F_TextChanged(object sender, EventArgs e)
        {
            Input1(guess5F);
        }

        private void Guess5G_TextChanged(object sender, EventArgs e)
        {
            Input1(guess5G);
        }

        private void Guess5H_TextChanged(object sender, EventArgs e)
        {
            Input1(guess5H);
        }

        private void Guess5I_TextChanged(object sender, EventArgs e)
        {
            Input1(guess5I);
        }

        private void Guess5J_TextChanged(object sender, EventArgs e)
        {
            Input1(guess5J);
        }

        private void Guess5K_TextChanged(object sender, EventArgs e)
        {
            Input1(guess5K);
        }

        private void Guess5L_TextChanged(object sender, EventArgs e)
        {
            Input1(guess5L);
        }

        private void FinalA_TextChanged(object sender, EventArgs e)
        {
            Input1(finalA);
        }

        private void FinalB_TextChanged(object sender, EventArgs e)
        {
            Input1(finalB);
        }

        private void FinalC_TextChanged(object sender, EventArgs e)
        {
            Input1(finalC);
        }

        private void FinalD_TextChanged(object sender, EventArgs e)
        {
            Input1(finalD);
        }

        private void FinalE_TextChanged(object sender, EventArgs e)
        {
            Input1(finalE);
        }

        private void FinalF_TextChanged(object sender, EventArgs e)
        {
            Input1(finalF);
        }

        private void FinalG_TextChanged(object sender, EventArgs e)
        {
            Input1(finalG);
        }

        private void FinalH_TextChanged(object sender, EventArgs e)
        {
            Input1(finalH);
        }

        private void FinalI_TextChanged(object sender, EventArgs e)
        {
            Input1(finalI);
        }

        private void FinalJ_TextChanged(object sender, EventArgs e)
        {
            Input1(finalJ);
        }

        private void FinalK_TextChanged(object sender, EventArgs e)
        {
            Input1(finalK);
        }

        private void FinalL_TextChanged(object sender, EventArgs e)
        {
            Input1(finalL);
        }
    }
}
