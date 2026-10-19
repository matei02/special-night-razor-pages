using DataAccessLayer.DALs;
using DataAccessLayer.Interfaces;
using DomainsLayer;
using DomainsLayer.Classes;
using LogicLayer;
using Org.BouncyCastle.Asn1.X509;
using System.Text.RegularExpressions;

namespace DesktopApp
{
    public partial class UC_Accounts : UserControl
    {
        private AccountManager accountManager;

        public UC_Accounts()
        {
            InitializeComponent();

            IAccountDAL accountDAL = new AccountDAL();
            accountManager = new AccountManager(accountDAL);
            foreach (Customer acc in accountManager.GetAllCustomers())
            {
                lbxCustomers.Items.Add(acc);
            }
            foreach (Admin acc in accountManager.GetAllAdmins())
            {
                lbxAdmins.Items.Add(acc);
            }
            cbxCustomerGender.DataSource = Enum.GetValues(typeof(Gender));
            btnSaveEdit.Hide();
            lblConfirmPassword.Hide();
            tbxConfirmPassword.Hide();

            lblCustomerAge.Hide();
            numCustomerAge.Hide();
            lblCustomerGender.Hide();
            cbxCustomerGender.Hide();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lbxCustomers.Items.Clear();
            lbxAdmins.Items.Clear();
            lblAccountInfo.Text = "";
            foreach (Customer acc in accountManager.GetAllCustomers())
            {
                lbxCustomers.Items.Add(acc);
            }
            foreach (Admin acc in accountManager.GetAllAdmins())
            {
                lbxAdmins.Items.Add(acc);
            }
            tbxName.Text = "";
            tbxPassword.Text = "";
            tbxConfirmPassword.Hide();
            tbxEmail.Text = "";
            tbxAddress.Text = "";
            tbxPhoneNumber.Text = "";
            groupBox1.Text = "Add Account";
            rbAdmin.Show();
            rbAdmin.Checked = false;
            rbCustomer.Show();
            rbCustomer.Checked = false;
            btnAddAccount.Show();
            btnSaveEdit.Hide();
            lbxAdmins.Enabled = true;
            lbxCustomers.Enabled = true;
            btnRemoveAccount.Enabled = true;
            btnGetAccountInfo.Enabled = true;
            lblConfirmPassword.Hide();

            lblCustomerAge.Hide();
            lblCustomerGender.Hide();
            cbxCustomerGender.Hide();
            numCustomerAge.Hide();
            label2.Show();
            tbxPassword.Show();
        }

        private void btnGetAccountInfo_Click(object sender, EventArgs e)
        {

            if (lbxCustomers.SelectedIndex >= 0)
            {
                lblAccountInfo.Text = "";
                Customer acc = (Customer)lbxCustomers.SelectedItem;
                lblAccountInfo.Text = acc.GetInfo();
            }
            else if (lbxAdmins.SelectedIndex >= 0)
            {
                lblAccountInfo.Text = "";
                Admin acc = (Admin)lbxAdmins.SelectedItem;
                lblAccountInfo.Text = acc.GetInfo();
            }
            else MessageBox.Show("You haven't selected an account!");

        }

        private void btnRemoveAccount_Click(object sender, EventArgs e)
        {
            IReviewDAL reviewDAL = new ReviewDAL();
            ReviewManager reviewManager = new ReviewManager(reviewDAL);
            if (lbxCustomers.SelectedIndex >= 0)
            {
                Customer acc = (Customer)lbxCustomers.SelectedItem;
                if (accountManager.DeleteCustomer(acc.Id))
                {
                    MessageBox.Show("Removal succesful!");
                    if (reviewManager.DeleteReviewFromDatabase(acc.Id))
                    {
                        lbxCustomers.SelectedIndex = -1;
                    }
                }
                else MessageBox.Show("Account doesn't exist?????");
            }
            else if (lbxAdmins.SelectedIndex >= 0)
            {
                Admin acc = (Admin)lbxAdmins.SelectedItem;
                if (accountManager.DeleteAdmin(acc.Id))
                {
                    lbxAdmins.SelectedIndex = -1;
                    MessageBox.Show("Removal succesful!");
                }
                else MessageBox.Show("Account doesn't exist?????");
            }
            else MessageBox.Show("You haven't selected an account!");
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxName.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxPassword.Text) && !string.IsNullOrEmpty(tbxAddress.Text) && !string.IsNullOrEmpty(tbxPhoneNumber.Text))
            {
                if (accountManager.DoesAccountExist(tbxEmail.Text))
                {
                    MessageBox.Show("Account already exists.");
                }
                else if (rbAdmin.Checked)
                {
                    if (accountManager.AddAdminAccount(tbxName.Text, tbxPassword.Text, tbxEmail.Text, tbxAddress.Text, tbxPhoneNumber.Text))
                    {
                        MessageBox.Show("Added admin succesfully!");
                        tbxName.Text = "";
                        tbxPassword.Text = "";
                        tbxEmail.Text = "";
                        tbxAddress.Text = "";
                        tbxPhoneNumber.Text = "";
                        rbAdmin.Checked = false;
                    }
                    else MessageBox.Show("Operation failed.");
                }
                else if (rbCustomer.Checked)
                {
                    if (accountManager.AddCustomerAccount(tbxName.Text, tbxPassword.Text, tbxEmail.Text, tbxAddress.Text, tbxPhoneNumber.Text, (int)numCustomerAge.Value, (Gender)cbxCustomerGender.SelectedValue))
                    {
                        MessageBox.Show("Added customer succesfully!");
                        tbxName.Text = "";
                        tbxPassword.Text = "";
                        tbxEmail.Text = "";
                        tbxAddress.Text = "";
                        tbxPhoneNumber.Text = "";
                        numCustomerAge.Value = 16;
                        cbxCustomerGender.SelectedIndex = -1;
                        rbCustomer.Checked = false;

                        lblCustomerGender.Hide();
                        lblCustomerAge.Hide();
                        numCustomerAge.Hide();
                        cbxCustomerGender.Hide();
                    }
                }
                else MessageBox.Show("Select account type.");
            }
            else
            {
                MessageBox.Show("Please input all fields correctly!");
            }
        }

        private void lbxAdmins_Enter(object sender, EventArgs e)
        {
            lbxCustomers.SelectedIndex = -1;
        }

        private void lbxCustomers_Enter(object sender, EventArgs e)
        {
            lbxAdmins.SelectedIndex = -1;
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            if (lbxAdmins.SelectedIndex >= 0)
            {
                Admin admin = (Admin)lbxAdmins.SelectedItem;
                tbxName.Text = admin.Name;
                tbxEmail.Text = admin.Email;
                tbxPassword.Text = admin.Password;
                tbxConfirmPassword.Show();
                lblConfirmPassword.Show();
                tbxConfirmPassword.Text = "";
                tbxAddress.Text = admin.Address;
                tbxPhoneNumber.Text = admin.PhoneNumber;
                groupBox1.Text = "Edit Account";

                btnRemoveAccount.Enabled = false;
                btnGetAccountInfo.Enabled = false;
                rbAdmin.Checked = true;
                rbCustomer.Hide();
                rbAdmin.Hide();
                btnAddAccount.Hide();
                btnSaveEdit.Show();
                lbxCustomers.Enabled = false;
                lbxAdmins.Enabled = false;
            }
            else if (lbxCustomers.SelectedIndex >= 0)
            {
                Customer customer = (Customer)lbxCustomers.SelectedItem;
                tbxName.Text = customer.Name;
                tbxEmail.Text = customer.Email;
                /*tbxPassword.Text = customer.Password;
				tbxConfirmPassword.Show();
				lblConfirmPassword.Show();
				tbxConfirmPassword.Text = "";*/
                label2.Hide();
                tbxPassword.Hide();
                tbxAddress.Text = customer.Address;
                tbxPhoneNumber.Text = customer.PhoneNumber;
                groupBox1.Text = "Edit Account";

                btnRemoveAccount.Enabled = false;
                btnGetAccountInfo.Enabled = false;
                rbCustomer.Checked = true;
                rbCustomer.Hide();
                rbAdmin.Hide();
                btnAddAccount.Hide();
                btnSaveEdit.Show();
                cbxCustomerGender.Show();
                numCustomerAge.Show();
                lbxCustomers.Enabled = false;
                lbxAdmins.Enabled = false;
                cbxCustomerGender.SelectedItem = customer.Gender;
                numCustomerAge.Value = customer.Age;
            }
            else MessageBox.Show("You haven't selected anyone!");

        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (rbAdmin.Checked)
                {
                    if (!string.IsNullOrEmpty(tbxName.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxPassword.Text) && !string.IsNullOrEmpty(tbxAddress.Text) && !string.IsNullOrEmpty(tbxPhoneNumber.Text))
                    {
                        if (string.Equals(tbxPassword.Text, tbxConfirmPassword.Text) && !string.IsNullOrEmpty(tbxPassword.Text))
                        {
                            Admin admin = (Admin)lbxAdmins.SelectedItem;
                            if (accountManager.UpdateAdmin(tbxName.Text, tbxPassword.Text, tbxEmail.Text, tbxAddress.Text, tbxPhoneNumber.Text, admin.Id))
                            {
                                MessageBox.Show("Admin updated succesfully!");
                                tbxConfirmPassword.Hide();
                                lblConfirmPassword.Hide();

                                btnRemoveAccount.Enabled = true;
                                btnGetAccountInfo.Enabled = true;
                                rbAdmin.Show();
                                rbCustomer.Show();
                                rbAdmin.Checked = false;
                                btnAddAccount.Show();
                                btnSaveEdit.Hide();
                                lbxCustomers.Enabled = true;
                                lbxAdmins.Enabled = true;
                                groupBox1.Text = "Add Account";
                                tbxName.Text = "";
                                tbxPassword.Text = "";
                                tbxEmail.Text = "";
                                tbxAddress.Text = "";
                                tbxPhoneNumber.Text = "";
                            }
                        }
                        else MessageBox.Show("Passwords must match!");
                    }
                }
                else if (rbCustomer.Checked)
                {
                    if (!string.IsNullOrEmpty(tbxName.Text) && !string.IsNullOrEmpty(tbxEmail.Text) && !string.IsNullOrEmpty(tbxAddress.Text) && !string.IsNullOrEmpty(tbxPhoneNumber.Text))
                    {
                        Customer customer = (Customer)lbxCustomers.SelectedItem;
                        if (accountManager.UpdateCustomer(tbxName.Text, customer.Password, tbxEmail.Text, tbxAddress.Text, tbxPhoneNumber.Text, customer.Id, (int)numCustomerAge.Value, (Gender)cbxCustomerGender.SelectedItem))
                        {
                            MessageBox.Show("Customer updated succesfully!");
                            /*tbxConfirmPassword.Hide();
                            lblConfirmPassword.Hide();*/

                            btnRemoveAccount.Enabled = true;
                            btnGetAccountInfo.Enabled = true;
                            rbCustomer.Show();
                            rbCustomer.Checked = true;
                            rbAdmin.Show();
                            btnAddAccount.Show();
                            btnSaveEdit.Hide();
                            lbxCustomers.Enabled = true;
                            lbxAdmins.Enabled = true;
                            groupBox1.Text = "Add Account";
                            tbxName.Text = "";
                            /*tbxPassword.Text = "";*/
                            tbxEmail.Text = "";
                            tbxAddress.Text = "";
                            tbxPhoneNumber.Text = "";
                            tbxPassword.Show();
                            label2.Show();

                        }
                    }
                    else MessageBox.Show("Please input all the fields correctly.");

                }
                else MessageBox.Show("Select account type.");
            }
            catch
            {
                MessageBox.Show("Error.");
            }
        }

        private void tbxName_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxName.Text))
            {
                if (!Regex.IsMatch(tbxName.Text, @"^[a-zA-Z\s]+$"))
                {
                    tbxName.Text = tbxName.Text.Remove(tbxName.Text.Length - 1);
                    tbxName.SelectionStart = tbxName.Text.Length;
                }
            }
        }

        private void tbxPassword_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxPassword.Text))
            {
                if (!Regex.IsMatch(tbxPassword.Text, @"^[a-zA-Z0-9\s!.,?]+$"))
                {
                    tbxPassword.Text = tbxPassword.Text.Remove(tbxPassword.Text.Length - 1);
                    tbxPassword.SelectionStart = tbxPassword.Text.Length;
                }
            }
        }

        private void tbxConfirmPassword_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxConfirmPassword.Text))
            {
                if (!Regex.IsMatch(tbxConfirmPassword.Text, @"^[a-zA-Z0-9\s!.,?]+$"))
                {
                    tbxConfirmPassword.Text = tbxConfirmPassword.Text.Remove(tbxConfirmPassword.Text.Length - 1);
                    tbxConfirmPassword.SelectionStart = tbxConfirmPassword.Text.Length;
                }
            }
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
        }

        private void tbxAddress_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxAddress.Text))
            {
                if (!Regex.IsMatch(tbxAddress.Text, @"^[a-zA-Z0-9\s]*$"))
                {
                    tbxAddress.Text = tbxAddress.Text.Remove(tbxAddress.Text.Length - 1);
                    tbxAddress.SelectionStart = tbxAddress.Text.Length;
                }
            }
        }

        private void tbxPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxPhoneNumber.Text))
            {
                if (!Regex.IsMatch(tbxPhoneNumber.Text, @"^[0-9\+]+$"))
                {
                    tbxPhoneNumber.Text = tbxPhoneNumber.Text.Remove(tbxPhoneNumber.Text.Length - 1);
                    tbxPhoneNumber.SelectionStart = tbxPhoneNumber.Text.Length;
                }
            }
        }

        private void btnEndRental_Click(object sender, EventArgs e)
        {
            if (lbxCustomers.SelectedIndex >= 0)
            {
                Customer customer = (Customer)lbxCustomers.SelectedItem;
                if (accountManager.GetOrderID(customer.Id) != -1)
                {
                    IOrderDAL orderDAL = new OrderDAL();
                    OrderManager orderManager = new OrderManager(orderDAL);

                    int orderID = accountManager.GetOrderID(customer.Id);

                    Order order = orderManager.GetOrderByID(orderID);

                    if (accountManager.EndRental(customer.Id) && orderManager.SetOrderStatusFinished(order))
                    {
                        MessageBox.Show("The rental has been ended!");
                    }
                    else
                    {
                        MessageBox.Show("Rental couldn't be ended.");
                    }
                }
                else
                {
                    MessageBox.Show("Customer doesn't have a rental in progress.");
                }
            }
            else MessageBox.Show("Select a customer first.");
        }

        private void rbCustomer_CheckedChanged(object sender, EventArgs e)
        {
            numCustomerAge.Show();
            lblCustomerAge.Show();

            cbxCustomerGender.Show();
            lblCustomerGender.Show();
        }

        private void rbAdmin_CheckedChanged(object sender, EventArgs e)
        {
            numCustomerAge.Hide();
            lblCustomerAge.Hide();

            cbxCustomerGender.Hide();
            lblCustomerGender.Hide();
        }
    }
}
