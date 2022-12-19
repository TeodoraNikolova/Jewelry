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
    public partial class Sale : Form
    {
        public Sale()
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
            adapt = new SqlDataAdapter("Select * FROM Sale", myConnection);
            adapt.Fill(dt);
            guna2DataGridView2.DataSource = dt;
            myConnection.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet8.Sale' table. You can move, or remove it, as needed.
            this.saleTableAdapter3.Fill(this.database1DataSet8.Sale);
            // TODO: This line of code loads data into the 'database1DataSet7.Sale' table. You can move, or remove it, as needed.
            this.saleTableAdapter2.Fill(this.database1DataSet7.Sale);
            // TODO: This line of code loads data into the 'database1DataSet6.Sale' table. You can move, or remove it, as needed.
            this.saleTableAdapter1.Fill(this.database1DataSet6.Sale);
            // TODO: This line of code loads data into the 'database1DataSet3.Sale' table. You can move, or remove it, as needed.
            this.saleTableAdapter.Fill(this.database1DataSet3.Sale);

        }

        private void Добави_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(frm.cs);
                myCommand = new SqlCommand("INSERT INTO Sale(S_Date,Client_Id,Product_Id,Price_DDS,S_Quantity) Values(@S_Date,@Client_Id,@Product_Id,@Price_DDS,@S_Quantity)", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@S_Date", guna2DateTimePicker1.Value);
                myCommand.Parameters.AddWithValue("@Client_Id", guna2TextBox6.Text);
                myCommand.Parameters.AddWithValue("@Product_Id", guna2TextBox1.Text);
                myCommand.Parameters.AddWithValue("@Price_DDS", guna2TextBox3.Text);
                myCommand.Parameters.AddWithValue("@S_Quantity", guna2TextBox4.Text);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                MessageBox.Show("Успешно добавихте нова продажба!");
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
                myCommand = new SqlCommand("Update Sale SET S_Date=@S_Date, Client_Id=@Client_Id, Product_Id = @Product_Id, S_Quantity = @S_Quantity, Price_DDS = @Price_DDS WHERE Sale_Id=@Sale_Id", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@Sale_Id", guna2TextBox5.Text);
                myCommand.Parameters.AddWithValue("@S_Date", guna2DateTimePicker1.Text);
                myCommand.Parameters.AddWithValue("@S_Quantity", guna2TextBox4.Text);
                myCommand.Parameters.AddWithValue("@Price_DDS", guna2TextBox3.Text);
                myCommand.Parameters.AddWithValue("@Client_Id", guna2TextBox6.Text);
                myCommand.Parameters.AddWithValue("@Product_Id", guna2TextBox1.Text);
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
                myCommand = new SqlCommand("Delete Sale Where Sale_Id=@Sale_Id", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@Sale_Id", guna2TextBox5.Text);
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
    }
}
