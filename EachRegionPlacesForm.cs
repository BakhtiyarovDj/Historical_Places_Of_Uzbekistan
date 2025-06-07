using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace HistoricalPlacesOfUzb
{
    public partial class EachRegionPlacesForm : Form
    {
        Query q = new Query();
        DataTable dataTable = null;
        Dictionary<int, ImageInfo> dictionary = null;
        private string region;
        private int imageCounter = 0;
        private string imagePath;
        private string description;
        private string objectName;
        public EachRegionPlacesForm(string region)
        {
            this.region = region;
            InitializeComponent();
            dataTable = q.Select($"SELECT * FROM Places WHERE REGION = '{region.Replace("'", "''")}'");
            if ( dataTable.Rows.Count > 0)
            {
                dictionary = Tools.BuildImageDictionary(dataTable);
                LoadImage();
            }
            else
            {
                var controlsToRemove = Controls.Cast<Control>()
                                       .Where(control => control.Name != "exitBtn")
                                       .ToList();

                // Remove the controls
                foreach (var control in controlsToRemove)
                {
                    Controls.Remove(control);
                    control.Dispose(); // Dispose the removed control to release resources
                }
                Label label = new Label();
                label.Text = "Ma'lumot yoq".ToUpper();
                label.Font = new Font("Times new roman",55, FontStyle.Regular);
                label.Size = new Size(Width, Height);
                label.TextAlign = ContentAlignment.MiddleCenter;
                Controls.Add(label);
            }

        }
        ImageInfo imageInfo = null;
        private void LoadImage()
        {
            if (dictionary.Keys.Contains(imageCounter))
            {
                pagesLabel.Text = $"{imageCounter + 1}/{dictionary.Keys.Count}";
                imageInfo = dictionary[imageCounter];
                imagePath = imageInfo.ImagePath;
                description = imageInfo.Description;
                objectName = imageInfo.ObjectName;
                descriptionLabel.Text = description;
                objectNameLabel.Text = objectName;
                regionLabel.Text = region;
                try
                {
                    mainPictureBox.Image = Image.FromFile(Environment.CurrentDirectory.Remove(Environment.CurrentDirectory.Length - 10) + "\\Places\\" + imagePath);
                }
                catch
                {

                }
            }
            
        }

        private void toRight_Click(object sender, EventArgs e)
        {
            if (imageCounter == dictionary.Keys.Count - 1)
            {
                imageCounter = -1;
            }
            imageCounter++;
            LoadImage();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
            if (imageCounter == 0)
            {
                imageCounter = dictionary.Keys.Count;
            }
            imageCounter--;
            LoadImage();
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            new UzbMapForm().Show();
            Hide();
        }
    }
}
