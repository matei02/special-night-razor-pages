using LogicLayer;
using DataAccessLayer.Interfaces;
using DataAccessLayer.DALs;
using DomainsLayer;

namespace DesktopApp
{
    public partial class UC_Reviews : UserControl
    {
        private ReviewManager reviewManager;
        private AccountManager accountManager;
        public UC_Reviews()
        {
            InitializeComponent();
            Refresh();
        }

        public void Refresh()
        {
            IReviewDAL reviewDAL = new ReviewDAL();
            IAccountDAL accountDAL = new AccountDAL();

            cbUsers.DataSource = accountDAL.GetAllCustomers();
            cbUsers.SelectedIndex = -1;
            lbxReviews.Items.Clear();
            reviewManager = new ReviewManager(reviewDAL);
            accountManager = new AccountManager(accountDAL);
            foreach (var review in reviewManager.GetReviews())
            {
                lbxReviews.Items.Add(accountManager.GetCustomerByID(review.Key).Name + " said:");
                foreach (var item in review.Value)
                {
                    lbxReviews.Items.Add("\t" + item.ToString());
                    lbxReviews.Items.Add("\n");
                }
                lbxReviews.Items.Add("----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            }
        }

        private void btnDeleteReviews_Click(object sender, EventArgs e)
        {
            if (cbUsers.SelectedIndex > -1)
            {
                Customer customer = cbUsers.SelectedItem as Customer;
                if (reviewManager.DeleteReviewFromDatabase(customer.Id))
                {
                    MessageBox.Show("Reviews written by " + customer.Name + " have been deleted successfully!");
                }
                else MessageBox.Show("Error. Try again.");
            }
            else MessageBox.Show("You haven't selected a user!");
            Refresh();
        }
    }
}
