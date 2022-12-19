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
using System.Data.Sql;

namespace Jewelry
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        public string cs = @"Data Source = (LocalDB)\MSSQLLocalDB;AttachDbFilename = C:\USERS\ACER\SOURCE\REPOS\JEWELRY\JEWELRY\DATABASE1.MDF;Integrated Security=True";
        public SqlConnection myConnection = default(SqlConnection);
        public SqlCommand myCommand = default(SqlCommand);

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(cs);
                myCommand = new SqlCommand("SELECT * FROM Registration WHERE username = @username AND password = @password", myConnection);
                SqlParameter uName = new SqlParameter("@username", SqlDbType.VarChar);
                SqlParameter uPassword = new SqlParameter("@password", SqlDbType.VarChar);
                uName.Value = guna2TextBox1.Text;
                uPassword.Value = guna2TextBox2.Text;
                myCommand.Parameters.Add(uName);
                myCommand.Parameters.Add(uPassword);
                myCommand.Connection.Open();
                SqlDataReader myReader = myCommand.ExecuteReader(CommandBehavior.CloseConnection);
                if (myReader.Read() == true)
                {
                    this.Hide();
                    Dashboard dsh = new Dashboard();
                    dsh.Show();
                }
                else
                {
                    MessageBox.Show("Грешно потребителско име или парола", "Грешка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    guna2TextBox1.Clear();
                    guna2TextBox2.Clear();
                    guna2TextBox1.Focus();
                }
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

        private void label2_Click(object sender, EventArgs e)
        {
            Registration frm = new Registration();
            frm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
           // Form13 frm = new Form13();
           // frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (guna2TextBox2.PasswordChar == '*')
            {
                button1.BringToFront();
                guna2TextBox2.PasswordChar = '\0';
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

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
