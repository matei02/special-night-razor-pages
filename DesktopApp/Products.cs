using DataAccessLayer;
using DomainsLayer;
using DomainsLayer.Classes;
using LogicLayer;
using System.Text.RegularExpressions;

namespace DesktopApp
{
    public partial class Products : Form
    {
        ProductManager productManager;
        Product originalProduct;
        public Products(ProductManager productManager)
        {
            InitializeComponent();
            this.productManager = productManager;
            cbMaterial.DataSource = Enum.GetValues(typeof(Material));
            btnSaveEdit.Hide();
        }

        public Products(Product product, ProductManager productManager)
        {
            InitializeComponent();
            this.productManager = productManager;
            originalProduct = product;
            cbProducts.SelectedItem = product;
            tbxName.Text = product.GetName();
            tbxPrice.Text = product.GetPrice().ToString();
            tbxQuantity.Text = product.Quantity.ToString();

            label1.Text = "Edit product";
            cbProducts.Hide();

            if (product is Bracelet)
            {
                Bracelet bracelet = (Bracelet)product;
                cbMaterial.DataSource = Enum.GetValues(typeof(Material));
                cbMaterial.SelectedItem = bracelet.Material;
                numBust.Enabled = false;
                numHips.Enabled = false;
                numWaist.Enabled = false;
                cbColors.Enabled = false;
            }
            else if (product is Necklace)
            {
                Necklace necklace = (Necklace)product;
                cbMaterial.DataSource = Enum.GetValues(typeof(Material));
                cbMaterial.SelectedItem = necklace.Material;
                numBust.Enabled = false;
                numHips.Enabled = false;
                numWaist.Enabled = false;
                cbColors.Enabled = false;
            }
            else if (product is Earring)
            {
                Earring earring = (Earring)product;
                cbMaterial.DataSource = Enum.GetValues(typeof(Material));
                cbMaterial.SelectedItem = earring.Material;
                numBust.Enabled = false;
                numHips.Enabled = false;
                numWaist.Enabled = false;
                cbColors.Enabled = false;
            }
            else if (product is Dress)
            {
                Dress dress = (Dress)product;
                cbColors.DataSource = Enum.GetValues(typeof(DressColors));
                cbColors.SelectedItem = dress.GetColor();
                numBust.Value = dress.GetSizeB();
                numHips.Value = dress.GetSizeH();
                numWaist.Value = dress.GetSizeW();
                cbMaterial.Enabled = false;
            }
            else if (product is Suit)
            {
                Suit suit = (Suit)product;
                cbColors.DataSource = Enum.GetValues(typeof(SuitColors));
                cbColors.SelectedItem = suit.GetColor();
                numBust.Value = suit.GetSizeB();
                numHips.Value = suit.GetSizeH();
                numWaist.Value = suit.GetSizeW();
                cbMaterial.Enabled = false;
            }

            btnAddProduct.Hide();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbProducts.Text == "Dress")
                {
                    int bust, waist, hips;
                    bust = (int)numBust.Value;
                    waist = (int)numWaist.Value;
                    hips = (int)numHips.Value;
                    Product dress = new Dress(1, (DressColors)cbColors.SelectedItem, bust, waist, hips, tbxName.Text, Convert.ToInt32(tbxQuantity.Text), Convert.ToInt32(tbxPrice.Text));
                    if (productManager.AddDressToDatabase((Dress)dress))
                    {
                        MessageBox.Show("Dress succesfully added!");
                        this.Close();
                    }
                    else MessageBox.Show("Cannot add dress.");
                }
                else if (cbProducts.Text == "Suit")
                {
                    int bust, waist, hips;
                    bust = (int)numBust.Value;
                    waist = (int)numWaist.Value;
                    hips = (int)numHips.Value;
                    Product suit = new Suit(1, (SuitColors)cbColors.SelectedItem, bust, waist, hips, tbxName.Text, Convert.ToInt32(tbxQuantity.Text), Convert.ToInt32(tbxPrice.Text));

                    if (productManager.AddSuitToDatabase((Suit)suit))
                    {
                        MessageBox.Show("Suit succesfully added!");
                        this.Close();
                    }
                    else MessageBox.Show("Cannot add suit.");
                }
                else if (cbProducts.Text == "Bracelet")
                {
                    Product bracelet = new Bracelet(1, (Material)cbMaterial.SelectedItem, Convert.ToInt32(tbxPrice.Text), tbxName.Text, Convert.ToInt32(tbxQuantity.Text));

                    if (productManager.AddBraceletToDatabase((Bracelet)bracelet))
                    {
                        MessageBox.Show("Product succesfully added!");
                        this.Close();
                    }
                    else MessageBox.Show("Cannot add bracelet.");
                }
                else if (cbProducts.Text == "Necklace")
                {
                    Product necklace = new Necklace(1, (Material)cbMaterial.SelectedItem, Convert.ToInt32(tbxPrice.Text), tbxName.Text, Convert.ToInt32(tbxQuantity.Text));

                    if (productManager.AddNecklaceToDatabase((Necklace)necklace))
                    {
                        MessageBox.Show("Product succesfully added!");
                        this.Close();
                    }
                    else MessageBox.Show("Cannot add necklace.");
                }
                else if (cbProducts.Text == "Earrings")
                {
                    Product earrings = new Earring(1, (Material)cbMaterial.SelectedItem, Convert.ToInt32(tbxPrice.Text), tbxName.Text, Convert.ToInt32(tbxQuantity.Text));

                    if (productManager.AddEarringsToDatabase((Earring)earrings))
                    {
                        MessageBox.Show("Product succesfully added!");
                        this.Close();
                    }
                    else MessageBox.Show("Cannot add bracelet.");
                }
                else if (cbProducts.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a product.");
                }

            }
            catch
            {
                MessageBox.Show("Make sure to input all info correctly.");
            }
        }

        private void cbProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbProducts.Text == "Dress")
            {
                cbColors.DataSource = Enum.GetValues(typeof(DressColors));

                cbMaterial.Enabled = false;
                cbMaterial.BackColor = Color.DarkGray;

                cbColors.Enabled = true;
                numBust.Enabled = true;
                numBust.BackColor = Color.White;
                numWaist.Enabled = true;
                numWaist.BackColor = Color.White;
                numHips.Enabled = true;
                numHips.BackColor = Color.White;
                cbColors.BackColor = Color.White;
            }
            else if (cbProducts.Text == "Suit")
            {
                cbColors.DataSource = Enum.GetValues(typeof(SuitColors));

                cbMaterial.Enabled = false;
                cbMaterial.BackColor = Color.DarkGray;

                cbColors.Enabled = true;
                numBust.Enabled = true;
                numBust.BackColor = Color.White;
                numWaist.Enabled = true;
                numWaist.BackColor = Color.White;
                numHips.Enabled = true;
                numHips.BackColor = Color.White;
                cbColors.BackColor = Color.White;

            }
            else if (cbProducts.Text == "Bracelet" || cbProducts.Text == "Necklace" || cbProducts.Text == "Earrings")
            {
                cbColors.Enabled = false;
                cbColors.BackColor = Color.DarkGray;
                numBust.Enabled = false;
                numBust.BackColor = Color.DarkGray;
                numWaist.Enabled = false;
                numWaist.BackColor = Color.DarkGray;
                numHips.Enabled = false;
                numHips.BackColor = Color.DarkGray;

                cbMaterial.Enabled = true;
                cbMaterial.BackColor = Color.White;
            }
        }

        private void btnSaveEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (originalProduct is Dress)
                {
                    int productID = productManager.GetDressID((Dress)originalProduct);
                    int bust, waist, hips;
                    bust = (int)numBust.Value;
                    waist = (int)numWaist.Value;
                    hips = (int)numHips.Value;
                    Product dress = new Dress(1, (DressColors)cbColors.SelectedItem, bust, waist, hips, tbxName.Text, Convert.ToInt32(tbxQuantity.Text), Convert.ToInt32(tbxPrice.Text));

                    if (productManager.UpdateDressInDatabase((Dress)dress, productID))
                    {
                        MessageBox.Show("Dress succesfully updated!");
                        this.Close();
                    }
                    else MessageBox.Show("Cannot edit dress.");
                }
                else if (originalProduct is Suit)
                {
                    int productID = productManager.GetSuitID((Suit)originalProduct);
                    int bust, waist, hips;
                    bust = (int)numBust.Value;
                    waist = (int)numWaist.Value;
                    hips = (int)numHips.Value;
                    Product suit = new Suit(1, (SuitColors)cbColors.SelectedItem, bust, waist, hips, tbxName.Text, Convert.ToInt32(tbxQuantity.Text), Convert.ToInt32(tbxPrice.Text));

                    if (productManager.UpdateSuitInDatabase((Suit)suit, productID))
                    {
                        MessageBox.Show("Suit succesfully updated!");
                        this.Close();
                    }
                    else MessageBox.Show("Cannot edit suit.");
                }
                else if (originalProduct is Bracelet)
                {
                    int productID = productManager.GetBraceletID((Bracelet)originalProduct);
                    Product bracelet = new Bracelet(1, (Material)cbMaterial.SelectedItem, Convert.ToInt32(tbxPrice.Text), tbxName.Text, Convert.ToInt32(tbxQuantity.Text));

                    if (productManager.UpdateBraceletInDatabase((Bracelet)bracelet, productID))
                    {
                        MessageBox.Show("Bracelet succesfully updated!");
                        this.Close();
                    }
                    else MessageBox.Show("Cannot edit bracelet.");
                }
                else if (originalProduct is Necklace)
                {
                    int productID = productManager.GetNecklaceID((Necklace)originalProduct);
                    Product necklace = new Necklace(1, (Material)cbMaterial.SelectedItem, Convert.ToInt32(tbxPrice.Text), tbxName.Text, Convert.ToInt32(tbxQuantity.Text));

                    if (productManager.UpdateNecklaceInDatabase((Necklace)necklace, productID))
                    {
                        MessageBox.Show("Necklace succesfully updated!");
                        this.Close();
                    }
                    else MessageBox.Show("Cannot edit necklace.");
                }
                else if (originalProduct is Earring)
                {
                    int productID = productManager.GetEarringsID((Earring)originalProduct);
                    Product earrings = new Earring(1, (Material)cbMaterial.SelectedItem, Convert.ToInt32(tbxPrice.Text), tbxName.Text, Convert.ToInt32(tbxQuantity.Text));

                    if (productManager.UpdateEarringsInDatabase((Earring)earrings, productID))
                    {
                        MessageBox.Show("Earrings succesfully updated!");
                        this.Close();
                    }
                    else MessageBox.Show("Cannot edit earrings.");
                }
                else if (cbProducts.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a product.");
                }

            }
            catch
            {
                MessageBox.Show("Make sure to input all info correctly.");
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

        private void tbxPrice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbxPrice.Text))
            {
                if (!Regex.IsMatch(tbxPrice.Text, @"^[0-9]+$"))
                {
                    tbxPrice.Text = tbxPrice.Text.Remove(tbxPrice.Text.Length - 1);
                    tbxPrice.SelectionStart = tbxPrice.Text.Length;
                }
            }
        }

        private void tbxQuantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(tbxQuantity.Text))
                {
                    if (!Regex.IsMatch(tbxQuantity.Text, @"^[0-9]+$"))
                    {
                        tbxQuantity.Text = tbxQuantity.Text.Remove(tbxQuantity.Text.Length - 1);
                        tbxQuantity.SelectionStart = tbxQuantity.Text.Length;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }



        /// ADD IN BULK BUTTON
        private void button2_Click(object sender, EventArgs e)
        {
            List<Product> products = new List<Product>()
            {
                new Bracelet(1, Material.GOLD, 60, "bracelet", 30),
                new Bracelet(1, Material.SILVER, 50, "bracelet", 30),
                new Necklace(1, Material.GOLD, 40, "necklace", 30),
                new Necklace(1, Material.SILVER, 25, "necklace", 30),
                new Earring(1, Material.GOLD, 70, "earrings", 30),
                new Earring(1, Material.SILVER, 60, "earrings", 30)
            };
            int ok = 1;
            foreach (Product p in products)
            {
                if (p is Bracelet)
                {
                    if (productManager.AddBraceletToDatabase((Bracelet)p) == false)
                    {
                        ok = 0;
                    }
                }
                else if (p is Necklace)
                {
                    if (productManager.AddNecklaceToDatabase((Necklace)p) == false)
                    {
                        ok = 0;
                    }
                }
                else
                {
                    if (productManager.AddEarringsToDatabase((Earring)p) == false)
                    {
                        ok = 0;
                    }
                }
            }
            if (ok == 1)
            { MessageBox.Show("Success!"); }
            else
            {
                MessageBox.Show("Error.");
            }
        }
    }
}
