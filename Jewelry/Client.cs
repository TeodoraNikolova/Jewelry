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
    public partial class Client : Form
    {
        public Client()
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
            adapt = new SqlDataAdapter("Select * FROM Client", myConnection);
            adapt.Fill(dt);
            guna2DataGridView2.DataSource = dt;
            myConnection.Close();
        }

        private void Client_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet2.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter1.Fill(this.database1DataSet2.Client);
            // TODO: This line of code loads data into the 'database1DataSet1.Client' table. You can move, or remove it, as needed.
            this.clientTableAdapter.Fill(this.database1DataSet1.Client);

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Добави_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(frm.cs);
                myCommand = new SqlCommand("INSERT INTO Client(Client_Name,Client_Address,Client_Phone) Values(@Client_Name,@Client_Address,@Client_Phone)", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@Client_Name", guna2TextBox3.Text);
                myCommand.Parameters.AddWithValue("@Client_Address", guna2TextBox4.Text);
                myCommand.Parameters.AddWithValue("@Client_Phone", guna2TextBox2.Text);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                MessageBox.Show("Успешно добавихте нов клиент!");
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

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(frm.cs);
                myCommand = new SqlCommand("Update Client SET Client_Name=@Client_Name, Client_Address=@Client_Address,Client_Phone=@Client_Phone WHERE Client_Id=@Client_Id", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@Client_Id", guna2TextBox1.Text);
                myCommand.Parameters.AddWithValue("@Client_Name", guna2TextBox3.Text);
                myCommand.Parameters.AddWithValue("@Client_Address", guna2TextBox4.Text);
                myCommand.Parameters.AddWithValue("@Client_Phone", guna2TextBox2.Text);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                MessageBox.Show("Успешно направихте корекция!");
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

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(frm.cs);
                myCommand = new SqlCommand("Delete Client Where Client_Id=@Client_Id", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@Client_Id", guna2TextBox1.Text);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                MessageBox.Show("Изтрихте успешно!");
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
    }
}
