using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HistoricalPlacesOfUzb
{
    public partial class UzbMapForm : Form
    {
        public UzbMapForm()
        {
            InitializeComponent();
        }
        
        private void label4_Click(object sender, EventArgs e)
        {
            Label clickedLabel = (Label)sender;
            new EachRegionPlacesForm(clickedLabel.Text).Show();
            Hide();

        }
        
        private void label4_MouseEnter(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            lbl.Font = new Font(lbl.Font, FontStyle.Underline);
            lbl.ForeColor = Color.White;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            lbl.Font = new Font(lbl.Font, FontStyle.Regular);
            lbl.ForeColor = Color.Maroon;
        }
        private void label13_Click(object sender, EventArgs e)
        {
            new LogInForm().Show();
            Hide();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
