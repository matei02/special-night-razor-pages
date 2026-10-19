using DomainsLayer;
using DomainsLayer.Classes;
using LogicLayer;

namespace DesktopApp
{
    public partial class UC_Products : UserControl
    {
        ProductManager productManager;
        public UC_Products(ProductManager productManager)
        {
            InitializeComponent();
            this.productManager = productManager;
            lbxProducts.SelectedIndex = -1;
            foreach (Product p in productManager.GetAllProductsFromDatabase())
            {
                lbxProducts.Items.Add(p);
            }
        }


        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            Products productForm = new Products(productManager);
            productForm.Show();
            productForm.TopLevel = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lbxProducts.Items.Clear();

            lbxProducts.SelectedIndex = -1;
            foreach (Product p in productManager.GetAllProductsFromDatabase())
            {
                if (p is Dress)
                    lbxProducts.Items.Add((Dress)p);
                else if (p is Suit)
                    lbxProducts.Items.Add((Suit)p);
                else if (p is Necklace)
                    lbxProducts.Items.Add((Necklace)p);
                else if (p is Bracelet)
                    lbxProducts.Items.Add((Bracelet)p);
                else lbxProducts.Items.Add((Earring)p);

            }
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            if (lbxProducts.Items.Count != 0)
            {
                if (lbxProducts.SelectedIndex >= 0)
                {
                    Products productForm = new Products((Product)lbxProducts.SelectedItem, productManager);
                    productForm.Show();
                    productForm.TopLevel = true;
                }
                else MessageBox.Show("You haven't selected any product!");
            }
            else MessageBox.Show("There are no products available.");
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            if (lbxProducts.SelectedIndex >= 0)
            {
                if (lbxProducts.SelectedItem is Dress)
                {
                    if (productManager.RemoveDressFromDatabase(productManager.GetDressID((Dress)lbxProducts.SelectedItem)))
                    {
                        MessageBox.Show("Dress deleted succesfully!");
                    }
                    else MessageBox.Show("Item couldn't be deleted!");
                }
                else if (lbxProducts.SelectedItem is Suit)
                {
                    if (productManager.RemoveSuitFromDatabase(productManager.GetSuitID((Suit)lbxProducts.SelectedItem)))
                    {
                        MessageBox.Show("Suit deleted succesfully!");
                    }
                    else MessageBox.Show("Item couldn't be deleted!");
                }
                else if (lbxProducts.SelectedItem is Necklace)
                {
                    if (productManager.RemoveNecklaceFromDatabase(productManager.GetNecklaceID((Necklace)lbxProducts.SelectedItem)))
                    {
                        MessageBox.Show("Necklace deleted succesfully!");
                    }
                    else MessageBox.Show("Item couldn't be deleted!");
                }
                else if (lbxProducts.SelectedItem is Bracelet)
                {
                    if (productManager.RemoveBraceletFromDatabase(productManager.GetBraceletID((Bracelet)lbxProducts.SelectedItem)))
                    {
                        MessageBox.Show("Bracelet deleted succesfully!");
                    }
                    else MessageBox.Show("Item couldn't be deleted!");
                }
                else if (lbxProducts.SelectedItem is Earring)
                {
                    if (productManager.RemoveEarringFromDatabase(productManager.GetEarringsID((Earring)lbxProducts.SelectedItem)))
                    {
                        MessageBox.Show("Earrings deleted succesfully!");
                    }
                    else MessageBox.Show("Item couldn't be deleted!");
                }
                Refresh();
            }
            else MessageBox.Show("???");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            foreach (Product item in lbxProducts.Items)
            {
                productManager.DeleteProductByID(item.GetID());
            }
        }
    }
}
