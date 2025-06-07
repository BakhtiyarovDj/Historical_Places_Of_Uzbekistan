using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HistoricalPlacesOfUzb
{
    internal class Tools
    {
        Query q = new Query();
        public static void ToCenter(Control control, Form form)
        {
            control.Location = new Point((form.Width - control.Width) / 2, (form.Height - control.Height) / 2);
        }

        public static string[] GetImagesPath(string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
                string[] imageFiles = Directory.GetFiles(directoryPath, "*.*")
                                .Where(file => file.ToLower().EndsWith(".jpg") || file.ToLower().EndsWith(".png"))
                                .ToArray();
                return imageFiles;
            }
            else
            {
                return null;
            }
        }

        public static Dictionary<int, ImageInfo> BuildImageDictionary(DataTable dataTable)
        {
            var imageDictionary = new Dictionary<int, ImageInfo>();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                string imagePath = dataTable.Rows[i][2].ToString(); 
                string description = dataTable.Rows[i][3].ToString();
                string objectName = dataTable.Rows[i][4].ToString(); 

                imageDictionary.Add(i, new ImageInfo { ImagePath = imagePath, Description = description , ObjectName = objectName });
            }
            return imageDictionary;
        }

        public static void CopyImageFile(string oldpath,string newpath)
        {
            if (File.Exists(oldpath))
            {
                if (!File.Exists(newpath)) 
                {
                    File.Copy(oldpath, newpath);
                }

            }
        }
    }
}
