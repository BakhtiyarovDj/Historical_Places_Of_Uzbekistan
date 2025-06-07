using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace HistoricalPlacesOfUzb   
{
    class Query
    {
        static string path = Environment.CurrentDirectory.Remove(Environment.CurrentDirectory.Length - 10);
        SqlConnection sqlConnection = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={path}\Places.mdf;Integrated Security=True");

        public DataTable Select(string query)
        {
            sqlConnection.Open();
            
            SqlCommand selectcmd = new SqlCommand(query, sqlConnection);
            DataTable dataTable = new DataTable();
            dataTable.Load(selectcmd.ExecuteReader());
            sqlConnection.Close();
            return dataTable;
        }
        public void Insert(string query)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand insertcmd = new SqlCommand(query, sqlConnection);
                insertcmd.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update(string query)
        {
            sqlConnection.Open();
            SqlCommand updatecmd = new SqlCommand(query, sqlConnection);
            updatecmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void Delete(string query)
        {
            sqlConnection.Open();
            SqlCommand deletecmd = new SqlCommand(query, sqlConnection);
            deletecmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
        public void FillComboBox(string col, string table, ComboBox comboBox)
        {
            comboBox.Items.Clear();
            var data = Select($"select {col} from {table}");
            for (int i = 0; i < data.Rows.Count; i++)
            {
                comboBox.Items.Add(data.Rows[i][0]);
            }
        }
        public void FillListBox(string col, string table, ListBox listbox)
        {
            listbox.Items.Clear();
            var data = Select($"select {col} from {table}");
            for (int i = 0; i < data.Rows.Count; i++)
            {
                listbox.Items.Add(data.Rows[i][0]);
            }
        }

    }
}
