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
    public partial class Product : Form
    {
        public Product()
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
            adapt = new SqlDataAdapter("Select * FROM Product", myConnection);
            adapt.Fill(dt);
            guna2DataGridView2.DataSource = dt;
            myConnection.Close();
        }
        private void Product_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.Product' table. You can move, or remove it, as needed.
            this.productTableAdapter.Fill(this.database1DataSet.Product);

        }

        private void guna2DataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Добави_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(frm.cs);
                myCommand = new SqlCommand("INSERT INTO Product(Product_Name,Product_Description,Product_Date,Price,Product_Quantity) Values(@Product_Name,@Product_Description,@Product_Date,@Price,@Product_Quantity)", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@Product_Name", guna2TextBox2.Text);
                myCommand.Parameters.AddWithValue("@Product_Description", guna2TextBox6.Text);
                myCommand.Parameters.AddWithValue("@Product_Date", guna2DateTimePicker1.Value);
                myCommand.Parameters.AddWithValue("@Price", guna2TextBox3.Text);
                myCommand.Parameters.AddWithValue("@Product_Quantity", guna2TextBox5.Text);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                MessageBox.Show("Успешно добавихте нов продукт!");
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
                myCommand = new SqlCommand("Update Product SET Product_Name=@Product_Name,Product_Description = @Product_Description,Product_Date = @Product_Date, Price=@Price, Product_Quantity = @Product_Quantity WHERE Product_ID=@Product_ID", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@Product_ID", guna2TextBox4.Text);
                myCommand.Parameters.AddWithValue("@Product_Name", guna2TextBox2.Text);
                myCommand.Parameters.AddWithValue("@Product_Description", guna2TextBox6.Text);
                myCommand.Parameters.AddWithValue("@Product_Date", guna2DateTimePicker1.Value);
                myCommand.Parameters.AddWithValue("@Price", guna2TextBox3.Text);
                myCommand.Parameters.AddWithValue("@Product_Quantity", guna2TextBox5.Text);
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(frm.cs);
                myCommand = new SqlCommand("Delete Product Where Product_ID=@Product_ID", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@Product_ID", guna2TextBox4.Text);
                myCommand.ExecuteNonQuery();
                myConnection.Close();
                MessageBox.Show("Успешно изтрихте продукт!");
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
