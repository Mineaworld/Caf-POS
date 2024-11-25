using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace Cafe
{
    public partial class Cafe : Form
    {
        public Cafe()
        {
            InitializeComponent();
        }


        private void Cafe_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("dddd,dd-MM-yyyy");
            lbldate.Visible = true;
        }

        private void BtnDash_Click(object sender, EventArgs e)
        {
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            POSForm frm = new POSForm();
            frm.Show();
            this.Hide();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("តើអ្នកចង់បន្ថែមផលិតផលថ្មីមែនទេ? សូមទាក់ទងមកយើងខ្ញុំនៅទីនេះ។",
                "ព័ត៌មាន",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {

            Form background = new Form();
            CustomersForm Model = new CustomersForm();
            using (Model)
            {
                background.StartPosition = FormStartPosition.Manual;
            background.FormBorderStyle = FormBorderStyle.None;
            background.Opacity = 0.5d;
            background.BackColor = Color.Black;
            background.Size = this.Size;
            background.Location = this.Location;
            background.ShowInTaskbar = false;
            background.Show(this);
            Model.Owner = background;
            Model.ShowDialog(background);
            background.Dispose();
            }
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            Form background = new Form();
            Reporting Model = new Reporting();
            using (Model)
            {
                background.StartPosition = FormStartPosition.Manual;
                background.FormBorderStyle = FormBorderStyle.None;
                background.Opacity = 0.5d;
                background.BackColor = Color.Black;
                background.Size = this.Size;
                background.Location = this.Location;
                background.ShowInTaskbar = false;
                background.Show(this);
                Model.Owner = background;
                Model.ShowDialog(background);
                background.Dispose();
            }


        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Authform frm = new Authform();
            frm.Show();
            this.Hide();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
