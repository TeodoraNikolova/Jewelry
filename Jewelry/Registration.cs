using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Jewelry
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        public SqlConnection myConnection;
        public SqlCommand myCommand;
        SqlDataAdapter adapt;
        Login frm = new Login();

        private void displayData()
        {
            myConnection.Open();
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("Select username from Registration where username = '" + guna2TextBox1.Text + "'", myConnection);
            adapt.Fill(dt);
            myConnection.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(frm.cs);
                myCommand = new SqlCommand("Insert INTO Registration Values('" + guna2TextBox1.Text + "','" + guna2TextBox2.Text + "')", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@username", guna2TextBox1.Text);
                myCommand.Parameters.AddWithValue("@password", guna2TextBox2.Text);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                displayData();

                if (myConnection.State == ConnectionState.Open)
                {
                    myConnection.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox2.PasswordChar == '\0')
            {
                button2.BringToFront();
                guna2TextBox2.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (guna2TextBox2.PasswordChar == '*')
            {
                button1.BringToFront();
                guna2TextBox2.PasswordChar = '\0';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login frm = new Login();
            frm.Show();
        }

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
