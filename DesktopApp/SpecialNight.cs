using System.Data.SqlClient;
using DataAccessLayer.Interfaces;
using DataAccessLayer.DALs;
using LogicLayer;
using DomainsLayer;

namespace DesktopApp
{
    public partial class SpecialNight : Form
    {
        Admin? account;
        AccountManager accountManager;
        OrderManager orderManager;
        ReviewManager reviewManager;
        ProductManager productManager;
        IAccountDAL accountDAL = new AccountDAL();

        public SpecialNight(Admin acc)
        {
            InitializeComponent();

            IAccountDAL accountDAL = new AccountDAL();
            IProductDAL productDAL = new ProductDAL();
            IReviewDAL reviewDAL = new ReviewDAL();
            IOrderDAL orderDAL = new OrderDAL();

            accountManager = new AccountManager(accountDAL);
            orderManager = new OrderManager(orderDAL);
            reviewManager = new ReviewManager(reviewDAL);
            productManager = new ProductManager(productDAL);
            lblUser.Text = acc.Name;
        }

        public UC_Accounts UC_Accounts
        {
            get => default;
            set
            {
            }
        }

        public UC_Reviews UC_Reviews
        {
            get => default;
            set
            {
            }
        }

        public UC_Orders UC_Orders
        {
            get => default;
            set
            {
            }
        }

        public UC_Products UC_Products
        {
            get => default;
            set
            {
            }
        }

        public Products Products
        {
            get => default;
            set
            {
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void UC_Controls(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Name)
            {
                case "btnOrders":
                    UC_Controls(new UC_Orders(orderManager));
                    break;
                case "btnProducts":
                    UC_Controls(new UC_Products(productManager));
                    break;
                case "btnAccounts":
                    UC_Controls(new UC_Accounts());
                    break;
                case "btnReviews":
                    UC_Controls(new UC_Reviews());
                    break;
                default:
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*db = new Database();
            if (db.ConnectToDatabase() == true)
            {
                MessageBox.Show("Connection succesful!");
            }
            else MessageBox.Show("Connection failed!");
            db.CloseConnection();*/

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*int q;
            Database db = new Database();
            if (db.ConnectToDatabase() == true)
            {
                q = db.GetDressQuantity();
                label1.Text = q.ToString();
            }
            db.CloseConnection();*/
        }

        private void button6_Click(object sender, EventArgs e)
        {
            /*db = new Database();
            if (db.ConnectToDatabase() == true)
            {
                label1.Text = "";
                foreach(string s in db.GetAllEmails())
                {
                    label1.Text += s + "\n";
                }
            }
            db.CloseConnection();*/
        }

        private void button7_Click(object sender, EventArgs e)
        {
            /*try
            {
                if (db.CloseConnection() == true)
                    MessageBox.Show("Connection terminated.");
                else MessageBox.Show("error.");
                db.CloseConnection();
            }
            catch (Exception)
            {
                MessageBox.Show("error.");
            }*/
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Login form_login = new Login();
            this.Hide();
            form_login.Show();
        }

        private void btnShowBorder_Click(object sender, EventArgs e)
        {
            if (FormBorderStyle == FormBorderStyle.FixedSingle)
            {
                FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.FixedSingle;
            }
        }
    }
}