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
    public partial class NewPlaceForm : Form
    {
        public NewPlaceForm()
        {
            InitializeComponent();
        }

        Query q = new Query();
        string selectedFilePath = "";
        string selectedFileTitle = "";
        private void openImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Rasmlar (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 1; 

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFilePath = openFileDialog.FileName;
                selectedFileTitle = Path.GetFileName(selectedFilePath);
                pathTxt.Text = selectedFilePath;
            }
        }
        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (regiontxt.SelectedIndex != -1 && IsFull(pathTxt) && IsFull(placetxt) && IsFull(descriptionTxt))
            {
                string newpath = $"{Environment.CurrentDirectory.Remove(Environment.CurrentDirectory.Length - 10)}\\Places\\{selectedFileTitle}";
                Tools.CopyImageFile(selectedFilePath,newpath);
                q.Insert($"INSERT INTO PLACES VALUES(N'{regiontxt.SelectedItem.ToString().Replace("'","''")}',N'{selectedFileTitle.Replace("'", "''")}',N'{descriptionTxt.Text.Replace("'", "''")}',N'{placetxt.Text.Replace("'", "''")}')");
                regiontxt.SelectedIndex = -1;
                pathTxt.Text = descriptionTxt.Text = placetxt.Text = selectedFilePath = selectedFileTitle = "";
                MessageBox.Show("Qo'shildi");
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
            new UpdatePlaceForm().Show();
            Close();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            new UzbMapForm().Show();
            Close();
        }
    }
}

