using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HistoricalPlacesOfUzb
{
    public partial class UpdatePlaceForm : Form
    {
        private DataTable dataTable;
        public UpdatePlaceForm()
        {
            InitializeComponent();
        }

        private void openImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Rasmlar (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;
                selectedFileTitle = Path.GetFileName(selectedFilePath);
                pictureBox.Image = Image.FromFile(selectedFilePath);
                pathTxt.Text = selectedFilePath;
            }
        }
        Query q = new Query();
        private string selectedFilePath = "";
        private string selectedFileTitle = "";

        private void regiontxt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (regionCombo.SelectedItem != null)
            {
                q.FillComboBox($"DISTINCT objectName",$"places where region = '{regionCombo.SelectedItem.ToString().Replace("'", "''")}'",placeCombo);
            }
        }
        private void placeCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (placeCombo.SelectedItem != null)
                {
                    var table = q.Select($"SELECT * FROM Places where objectname = '{placeCombo.SelectedItem.ToString().Replace("'", "''")}'");
                    pictureBox.Image = Image.FromFile(Environment.CurrentDirectory + "\\Places\\" + table.Rows[0][2].ToString());
                    descriptionTxt.Text = table.Rows[0][3].ToString();
                    pathTxt.Text = table.Rows[0][2].ToString();
                }
            }
            catch 
            {

            }
            
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (regionCombo.SelectedIndex != -1 && IsFull(pathTxt) && placeCombo.SelectedIndex != -1 && IsFull(descriptionTxt))
            {
                string newpath = $"{Environment.CurrentDirectory}\\Places\\{selectedFileTitle}";
                Tools.CopyImageFile(selectedFilePath, newpath);
                q.Update($"UPDATE PLACES SET imagePath = N'{selectedFileTitle.Replace("'", "''")}', discription = N'{descriptionTxt.Text.Replace("'", "''")}' where objectname = '{placeCombo.SelectedItem.ToString().Replace("'", "''")}'");
                regionCombo.SelectedIndex = -1;
                placeCombo.SelectedIndex = -1;
                pathTxt.Text = descriptionTxt.Text = selectedFilePath = selectedFileTitle = "";
                pictureBox.Image = null;
                MessageBox.Show("O'zgartirildi");
            }
            else
            {
                MessageBox.Show("Maydonlarni to'ldiring");
            }
        }
        private bool IsFull(Control control)
        {
            if (string.IsNullOrWhiteSpace(control.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (placeCombo.SelectedItem != null)
            {
                if (MessageBox.Show($"<<{placeCombo.SelectedItem}>>ni o'chirishga rozimisiz?", "Diqqat!",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    q.Delete($"DELETE FROM Places where objectName = '{placeCombo.SelectedItem.ToString().Replace("'", "''")}'");
                    regionCombo.SelectedIndex = -1;
                    placeCombo.Items.Clear();
                    pathTxt.Text = descriptionTxt.Text = selectedFilePath = selectedFileTitle = "";
                    pictureBox.Image = null;
                }
            }
        }
        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            new NewPlaceForm().Show();
            Close();
        }
    }
}
