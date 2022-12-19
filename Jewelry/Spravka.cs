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
using System.IO;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace Jewelry
{
    public partial class Spravka : Form
    {
        public Spravka()
        {
            InitializeComponent();
        }

        public SqlConnection myConnection;
        public SqlCommand myCommand;
        Login frm = new Login();

        private void Spravka_Load(object sender, EventArgs e)
        {

        }

        private void Справка_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(frm.cs);
                myCommand = new SqlCommand("SELECT s.S_Quantity, s.S_Date, s.Price_DDS, p.Product_Name, c.Client_Name FROM Sale s JOIN Product p ON s.Product_Id = p.Product_Id JOIN Client c ON s.Client_Id = c.Client_Id WHERE s.S_Date BETWEEN '25-MARCH-22' AND '27-MARCH-22'", myConnection);
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                SqlDataReader rd = myCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                guna2DataGridView1.DataSource = dt;
                myConnection.Close();

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Справка_Продажби_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(frm.cs);
                myCommand = new SqlCommand("Select * FROM (select s.S_Date, c.Client_Name, p.Product_Name, s.Price_DDS FROM Sale s JOIN Client c ON s.Client_Id = c.Client_Id JOIN Product p ON s.Product_Id = p.Product_Id WHERE c.Client_Name = @Client_Name ORDER BY s.S_Date DESC) WHERE ROWNUM<=2", myConnection);
                myConnection.Open();
               // myCommand.Parameters.AddWithValue("@Client_Name", guna2TextBox3.Text);
                myCommand.ExecuteNonQuery();

                SqlDataReader rd = myCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                guna2DataGridView1.DataSource = dt;
                myConnection.Close();

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Справкаа_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(frm.cs);
                myCommand = new SqlCommand("Select s.S_Date,c.Client_Name,p.Product_Name, s.Price_DDS FROM Sale s JOIN Client c ON s.Client_Id = c.Client_Id JOIN Product p ON s.Product_Id=p.Product_Id WHERE s.S_Date BETWEEN '01-MARCH-22' AND '30-JUNE-22' AND c.Client_Name = @Client_Name ", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@Client_Name", guna2TextBox2.Text);
                myCommand.ExecuteNonQuery();

                SqlDataReader rd = myCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                guna2DataGridView1.DataSource = dt;
                myConnection.Close();

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Рекапитулация_Click(object sender, EventArgs e)
        {
            try
            {
                myConnection = new SqlConnection(frm.cs);
                myCommand = new SqlCommand("Select s.S_Date, p.Product_Name, s.Price_DDS FROM Sale s JOIN Product p ON s.Product_Id = p.Product_ID WHERE s.S_Date BETWEEN '01-MARCH-22' AND '30-JUNE-22' AND Price_DDS = @Price_DDS", myConnection);
                myConnection.Open();
                myCommand.Parameters.AddWithValue("@Price_DDS", guna2TextBox4.Text);
                myCommand.ExecuteNonQuery();

                SqlDataReader rd = myCommand.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                guna2DataGridView1.DataSource = dt;
                myConnection.Close();

                if (myConnection.State == ConnectionState.Open)
                    myConnection.Dispose();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.Rows.Count > 0)

            {

                SaveFileDialog save = new SaveFileDialog();

                save.Filter = "PDF (*.pdf)|*.pdf";

                save.FileName = "Result.pdf";

                bool ErrorMessage = false;

                if (save.ShowDialog() == DialogResult.OK)

                {

                    if (File.Exists(save.FileName))

                    {

                        try

                        {

                            File.Delete(save.FileName);

                        }

                        catch (Exception ex)

                        {

                            ErrorMessage = true;

                            MessageBox.Show("Unable to wride data in disk" + ex.Message);

                        }

                    }

                    if (!ErrorMessage)

                    {

                        try

                        {

                            PdfPTable pTable = new PdfPTable(guna2DataGridView1.Columns.Count);

                            pTable.DefaultCell.Padding = 2;

                            pTable.WidthPercentage = 100;

                            pTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            foreach (DataGridViewColumn col in guna2DataGridView1.Columns)

                            {

                                PdfPCell pCell = new PdfPCell(new Phrase(col.HeaderText));

                                pTable.AddCell(pCell);

                            }

                            foreach (DataGridViewRow viewRow in guna2DataGridView1.Rows)

                            {

                                foreach (DataGridViewCell dcell in viewRow.Cells)

                                {

                                    pTable.AddCell(dcell.Value.ToString());

                                }

                            }

                            using (FileStream fileStream = new FileStream(save.FileName, FileMode.Create))

                            {

                                Document document = new Document(PageSize.A4, 8f, 16f, 16f, 8f);

                                PdfWriter.GetInstance(document, fileStream);

                                document.Open();

                                document.Add(pTable);

                                document.Close();

                                fileStream.Close();

                            }

                            MessageBox.Show("Data Export Successfully", "info");

                        }

                        catch (Exception ex)

                        {

                            MessageBox.Show("Error while exporting Data" + ex.Message);

                        }

                    }

                }

            }

            else

            {

                MessageBox.Show("No Record Found", "Info");

            }
        }
    }
}
