using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using TheArtOfDev.HtmlRenderer.Adapters;

namespace Cafe
{
    public partial class Authform : Form
    {
        public Authform()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string user = TxtUser.Text;
            string pass = TxtPassword.Text;

            // Check if the input fields are empty
            if (string.IsNullOrWhiteSpace(user))
            {
                MessageBox.Show("Username cannot be empty.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtUser.Text = string.Empty; TxtPassword.Text = string.Empty;
                return;
            }

            if (string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Password cannot be empty.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                TxtUser.Text = string.Empty; TxtPassword.Text = string.Empty;
                return;

            }
            Cursor.Current = Cursors.WaitCursor;

            try
            {
                if (user == "admin" && pass == "123")
                {
                    Cafe cafe = new Cafe();
                    cafe.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid username or password. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    TxtUser.Text = string.Empty; TxtPassword.Text = string.Empty;
                }
            }
            finally
            {
                // Reset cursor
                Cursor.Current = Cursors.Default;
            }
        }


        private bool isKhmer = false;

        private void KhmerLang_Click(object sender, EventArgs e)
        {
            if (isKhmer)
            {
                SwitchLanguage("en");
                KhmerLang.Image = Properties.Resources.Khmericon; // Change to Khmer icon
            }
            else
            {
                SwitchLanguage("kh");
                KhmerLang.Image = Properties.Resources.Englishicon; // Change to English icon
            }
            isKhmer = !isKhmer;
        }

        private void SwitchLanguage(string languageCode)
        {
            if (languageCode == "kh")
            {
                SetControlTextAndFont(lblHead, "ចូលប្រើប្រាស់", new Font("Kantumruy Pro", 30, FontStyle.Bold));
                SetControlTextAndFont(lblUser, "ឈ្មោះ", new Font("Kantumruy Pro SemiBold", 14));
                SetControlTextAndFont(lblPass, "ពាក្យសម្ងាត់", new Font("Kantumruy Pro SemiBold", 14));
                SetControlTextAndFont(BtnLogin, "ចូល", new Font("Kantumruy Pro", 15, FontStyle.Bold));
                SetBunifuTextBoxProperties(TxtUser, new Font("Kantumruy Pro SemiBold", 11), "សូមបញ្ចូលឈ្មោះអ្នកប្រើប្រាស់");
                SetBunifuTextBoxProperties(TxtPassword, new Font("Kantumruy Pro SemiBold", 11), "សូមបញ្ចូល​ពាក្យ​សម្ងាត់​​!");

            }
            else if (languageCode == "en")
            {
                SetControlTextAndFont(lblHead, "User login", new Font("Poppins", 25, FontStyle.Bold));
                SetControlTextAndFont(lblUser, "Username", new Font("Poppins", 12, FontStyle.Regular));
                SetControlTextAndFont(lblPass, "Password", new Font("Poppins", 12, FontStyle.Regular));
                SetControlTextAndFont(BtnLogin, "Login", new Font("Poppins", 15, FontStyle.Bold));
                SetBunifuTextBoxProperties(TxtUser, new Font("Poppins", 9, FontStyle.Regular), "Enter your username");
                SetBunifuTextBoxProperties(TxtPassword, new Font("Poppins", 9, FontStyle.Regular), "Enter your password");
            }
        }
        private void SetControlTextAndFont(Control control, string text, Font font, string placeholderText = null)
        {
            control.Text = text;
            control.Font = font;
        }
        private void SetBunifuTextBoxProperties(BunifuTextBox textBox, Font font, string placeholderText)
        {
            textBox.Font = font;
            textBox.PlaceholderText = placeholderText;
        }
    }
}
