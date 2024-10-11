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
    public partial class SIGNUP : Form
    {
        public SIGNUP()
        {
            InitializeComponent();
        }

        OleDbCommand cmd;
        OleDbConnection conn;

        private void SIGNUP_Load(object sender, EventArgs e)
        {
            conn = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\L5G1\Documents\RECIPES SYSTEM.accdb");
            cmd = new OleDbCommand();
            cmd.Connection = conn;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM CUSTOMER WHERE CUSTCELLNUMBER = '" + textBox4.Text + "'";
                OleDbDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("Duplicate");
                }
                else
                {
                    dr.Close();
                    /*cmd.CommandText = "INSERT INTO CUSTOMER (NAME, SURNAME, IDNUMBER, CELLNUMBER, USERNAME, PASSWORD) VALUES (@name, @surname, @idnumber, @cellnumber, @username, @password)";
                    cmd.Parameters.AddWithValue("@name", textBox1.Text);
                    cmd.Parameters.AddWithValue("@surname", textBox2.Text);
                    cmd.Parameters.AddWithValue("@idnumber", textBox3.Text);
                    cmd.Parameters.AddWithValue("@cellnumber", textBox4.Text);
                    cmd.Parameters.AddWithValue("@username", textBox5.Text);
                    cmd.Parameters.AddWithValue("@password", textBox6.Text);

                    cmd.ExecuteNonQuery();*/
                    cmd.CommandText = "INSERT INTO CUSTOMER(CUSTNAME,CUSTSURNAME,CUSTIDNUMBER,CUSTCELLNUMBER,CUSTUSERNAME,CUSTPASSWORD) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("SUCCESFULLY ADDED");
                }

                conn.Close();
                Form1 f = new Form1();
                f.Show();
                this.Hide();

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
                Form1 f = new Form1();
                f.Show();
                this.Hide();
            }
            catch (Exception)
            {
                MessageBox.Show("ERROR");
            }
            
        }
    }
}
