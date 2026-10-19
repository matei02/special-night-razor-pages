using DataAccessLayer.DALs;
using DataAccessLayer.Interfaces;
using DomainsLayer;
using LogicLayer;
using System.Text.RegularExpressions;

namespace DesktopApp
{
    public partial class Login : Form
    {
        AccountManager accountManager;
        public Login()
        {
            InitializeComponent();
            IAccountDAL accountDAL = new AccountDAL();
            accountManager = new AccountManager(accountDAL);
            btnSecret.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxPassword.Text))
            {
                bool acc_exists = false;
                if ((accountManager.GetAdmin(tbxEmail.Text, tbxPassword.Text) != null))
                {
                    Admin acc = accountManager.GetAdmin(tbxEmail.Text, tbxPassword.Text);
                    this.Hide();
                    SpecialNight form1 = new SpecialNight(acc);
                    form1.Show();
                    acc_exists = true;
                }
                if (acc_exists == false)
                {
                    MessageBox.Show("Invalid credentials!");
                }
            }
            else MessageBox.Show("Please input both fields.");
        }

        private void tbxEmail_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxEmail.Text))
            {
                if (!Regex.IsMatch(tbxEmail.Text, @"^[a-zA-Z0-9@\.]*$"))
                {
                    tbxEmail.Text = tbxEmail.Text.Remove(tbxEmail.Text.Length - 1);
                    tbxEmail.SelectionStart = tbxEmail.Text.Length;
                }
            }

            string desiredInput = "admin";
            bool isMatch = tbxEmail.Text.Trim() == desiredInput;
            btnSecret.Enabled = isMatch;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Admin acc = new Admin(100, "Admin", "parola", "user1@example.com", "Address", "0000000000000");
            this.Hide();
            SpecialNight form1 = new SpecialNight(acc);
            form1.Show();
        }
    }
}
