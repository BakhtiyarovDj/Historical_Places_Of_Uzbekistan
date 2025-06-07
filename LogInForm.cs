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
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
            pictureBox2.Image = Properties.Resources.hide;
            paroltxt.PasswordChar = '*';
            Tools.ToCenter(panel, this);
        }
        Query q = new Query();
        private bool hiden;

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (q.Select($"select * from users where login = '{logintxt.Text}' and parol = '{paroltxt.Text}'").Rows.Count > 0)
            {
                new NewPlaceForm().Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Tog'ri tering");
            }
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            new UzbMapForm().Show();
            Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (hiden)
            {
                pictureBox2.Image = Properties.Resources.eye;
                paroltxt.PasswordChar = '\0';
                hiden = false;
            }
            else
            {
                pictureBox2.Image = Properties.Resources.hide;
                paroltxt.PasswordChar = '*';
                hiden = true;
            }
        }
    }
}
