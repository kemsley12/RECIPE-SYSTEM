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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbCommand cmd;
        OleDbConnection conn;

        public string username;
        public string password;

        private void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\L5G1\Documents\RECIPES SYSTEM.accdb");
                cmd = new OleDbCommand();
                cmd.Connection = conn;
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string username = textBox1.Text;
                string password = textBox2.Text;
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM CUSTOMER WHERE CUSTUSERNAME = '" + username + "' AND CUSTPASSWORD = '" + password + "' ";
                cmd.ExecuteNonQuery();
                OleDbDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("SUCCESFULLY LOGIN");
                    RECIPE_OPTION rp = new RECIPE_OPTION();
                    rp.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("INVALID LOGIN");
                }
                conn.Close();
                Clear();
            }
            catch (Exception X)
            {
                MessageBox.Show("ERROR" + X);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SIGNUP sp = new SIGNUP();
                sp.Show();
            }
            catch (Exception X)
            {
                MessageBox.Show("ERROR" + X);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception X)
            {
                MessageBox.Show("ERROR" + X);
            }
        }
    }
}
