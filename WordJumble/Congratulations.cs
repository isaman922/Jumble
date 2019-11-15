using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordJumble
{
    public partial class Congratulations : Form
    {
        public Congratulations(string theTitle, string theSubtitle, string sup)
        {
            InitializeComponent();
            title.Text = theTitle;
            subtitle.Text = theSubtitle;
            callToAction.Text = $"Email a screenshot to {sup} to be entered to win a fabulous prize at the end of the month!";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
