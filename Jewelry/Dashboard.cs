using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Jewelry
{
    public partial class Dashboard : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
             int nLeftRect,
             int nTopRect,
             int nRightRect,
             int nBottomRect,
             int nWidthEllipse,
                int nHeightEllipse
         );
        public Dashboard()
        {
            InitializeComponent();
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.PnlFormLoader.Controls.Clear();
            Logo frm3 = new Logo() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm3.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(frm3);
            frm3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.PnlFormLoader.Controls.Clear();
            Product frm4 = new Product() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm4.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(frm4);
            frm4.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.PnlFormLoader.Controls.Clear();
            Spravka frm = new Spravka() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(frm);
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.PnlFormLoader.Controls.Clear();
            Client frm4 = new Client() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm4.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(frm4);
            frm4.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.PnlFormLoader.Controls.Clear();
            Sale frm5 = new Sale() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm5.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(frm5);
            frm5.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
