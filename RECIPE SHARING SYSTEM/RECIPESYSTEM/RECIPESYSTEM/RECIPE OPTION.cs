using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace RECIPESYSTEM
{
    public partial class RECIPE_OPTION : Form
    {
        public RECIPE_OPTION()
        {
            InitializeComponent();
        }
        OleDbCommand cmd;
        OleDbConnection conn;

        private void RECIPE_OPTION_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\L5G1\Documents\RECIPES SYSTEM.accdb");
                cmd = new OleDbCommand();
                cmd.Connection = conn;
                timer1.Start();

                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM RECIPES";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM RECIPES WHERE TYPE = '"+ textBox1.Text +"'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string pdfPath = @"C:\Users\L5G1\Documents\RECIPE SHARING SYSTEM\LASAGNA.pdf";
                pdfPath = @"C:\Users\L5G1\Documents\RECIPE SHARING SYSTEM\Brushetta.pdf";
                pdfPath = @"C:\Users\L5G1\Documents\RECIPE SHARING SYSTEM\Chicken Noodle Soup.pdf";
                pdfPath = @"C:\Users\L5G1\Documents\RECIPE SHARING SYSTEM\Greek Salad.pdf";
                pdfPath = @"C:\Users\L5G1\Documents\RECIPE SHARING SYSTEM\Ceasar Salad.pdf";
                pdfPath = @"C:\Users\L5G1\Documents\RECIPE SHARING SYSTEM\Beef Stroganoff.pdf";
                pdfPath = @"C:\Users\L5G1\Documents\RECIPE SHARING SYSTEM\Vegetable Stir.pdf";
                pdfPath = @"C:\Users\L5G1\Documents\RECIPE SHARING SYSTEM\Garlic Mashed Potatoes.pdf";
                pdfPath = @"C:\Users\L5G1\Documents\RECIPE SHARING SYSTEM\Apple Pie.pdf";
                pdfPath = @"C:\Users\L5G1\Documents\RECIPE SHARING SYSTEM\Chocolate Chip Cookies.pdf";
                
           
                
                
                LoadPdf(pdfPath);

                if (dataGridView1.SelectedRows != null)
                {
                    
                    
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        // Skip the header row
                        if (row.Index == dataGridView1.Rows.Count - 1) continue;

                        // Assuming the table has columns "Column1", "Column2", etc.
                        string value1 = row.Cells["TITLE"].Value.ToString();
                        string value2 = row.Cells["TYPE"].Value.ToString();
                        string value3 = row.Cells["CUISINE"].Value.ToString();
                        string value4 = row.Cells["COOKINGTIME"].Value.ToString();
                        string value5 = row.Cells["SERVINGS"].Value.ToString();
                        
                    }
                    conn.Close();
                    // Inform the user
                    MessageBox.Show("Thank you");
                }
            }
                

            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
            }
        }

        private void LoadPdf(string filePath)
        {
            webBrowser1.Navigate(filePath);
        }
    

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                Form1 f = new Form1();
                f.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR");
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
