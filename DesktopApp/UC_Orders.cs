using System.Text.RegularExpressions;
using DataAccessLayer.DALs;
using DataAccessLayer.Interfaces;
using DomainsLayer;
using DomainsLayer.Classes;
using LogicLayer;

namespace DesktopApp
{
    public partial class UC_Orders : UserControl
    {
        OrderManager orderManager;
        AccountManager accountManager;
        public UC_Orders(OrderManager orderManager)
        {
            InitializeComponent();
            this.orderManager = orderManager;
            IAccountDAL accountDAL = new AccountDAL();
            this.accountManager = new AccountManager(accountDAL);
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            rtbxOrderInfo.ScrollBars = RichTextBoxScrollBars.Vertical;

            btnRefreshOrders_Click(sender, e);
        }

        private void btnRefreshOrders_Click(object sender, EventArgs e)
        {
            lbxAllOrders.Items.Clear();
            rtbxOrderInfo.Text = "";
            tbxSearchOrderID.Text = "";

            foreach (Order order in orderManager.GetAllOrders())
            {
                lbxAllOrders.Items.Add(order);
            }
        }

        private void btnOrderInfo_Click(object sender, EventArgs e)
        {
            if (lbxAllOrders.SelectedIndex > -1)
            {
                rtbxOrderInfo.Text = "";
                Order order = (Order)lbxAllOrders.SelectedItem;
                foreach (Product p in order.GetProducts())
                {
                    rtbxOrderInfo.Text += $"{p.GetInfo()}\n";
                }
            }
            else MessageBox.Show("You haven't selected any order.");
        }

        private void btnRemoveOrder_Click(object sender, EventArgs e)
        {
            rtbxOrderInfo.Text = "";

            if (lbxAllOrders.SelectedIndex > -1)
            {
                if (orderManager.DeleteOrder((Order)lbxAllOrders.SelectedItem))
                {
                    MessageBox.Show("Order deleted succesfully!");
                }
                else MessageBox.Show("Cannot delete order.");
            }
        }

        private void btnSearchOrderID_Click(object sender, EventArgs e)
        {
            int ok = 0;

            rtbxOrderInfo.Text = "";

            if (tbxSearchOrderID.Text.Length > 0)
            {
                foreach (Order o in orderManager.GetAllOrders())
                {
                    if (Convert.ToInt32(tbxSearchOrderID.Text) == o.GetOrderID())
                    {
                        Order order = orderManager.GetOrderByID(Convert.ToInt32(tbxSearchOrderID.Text));
                        foreach (Product p in order.GetProducts())
                        {
                            rtbxOrderInfo.Text += $"{p.GetInfo()}\n";
                            ok = 1;
                        }
                    }
                }
                if (ok == 0)
                {
                    rtbxOrderInfo.Text = "Order doesn't exist.";
                }
            }
        }

        private void tbxSearchOrderID_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxSearchOrderID.Text))
            {
                if (!Regex.IsMatch(tbxSearchOrderID.Text, @"^[0-9]+$"))
                {
                    tbxSearchOrderID.Text = tbxSearchOrderID.Text.Remove(tbxSearchOrderID.Text.Length - 1);
                    tbxSearchOrderID.SelectionStart = tbxSearchOrderID.Text.Length;
                }
            }
            else MessageBox.Show("Please input an ID.");
        }
    }
}
