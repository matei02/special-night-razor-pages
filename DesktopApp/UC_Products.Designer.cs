namespace DesktopApp
{
    partial class UC_Products
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnRefresh = new Button();
            lblInfo = new Label();
            btnAddProduct = new Button();
            lbxProducts = new ListBox();
            btnEditProduct = new Button();
            btnDeleteProduct = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.ActiveBorder;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnRefresh.ForeColor = SystemColors.ActiveCaptionText;
            btnRefresh.Location = new Point(33, 470);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(75, 30);
            btnRefresh.TabIndex = 7;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += button1_Click;
            // 
            // lblInfo
            // 
            lblInfo.AutoSize = true;
            lblInfo.FlatStyle = FlatStyle.Popup;
            lblInfo.Font = new Font("Segoe UI", 11.25F, FontStyle.Underline, GraphicsUnit.Point);
            lblInfo.Location = new Point(528, 148);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(0, 20);
            lblInfo.TabIndex = 9;
            // 
            // btnAddProduct
            // 
            btnAddProduct.BackColor = SystemColors.ActiveBorder;
            btnAddProduct.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddProduct.ForeColor = SystemColors.ActiveCaptionText;
            btnAddProduct.Location = new Point(694, 343);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(120, 43);
            btnAddProduct.TabIndex = 21;
            btnAddProduct.Text = "Add product";
            btnAddProduct.UseVisualStyleBackColor = false;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // lbxProducts
            // 
            lbxProducts.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lbxProducts.FormattingEnabled = true;
            lbxProducts.ItemHeight = 20;
            lbxProducts.Location = new Point(12, 15);
            lbxProducts.Name = "lbxProducts";
            lbxProducts.Size = new Size(859, 304);
            lbxProducts.TabIndex = 23;
            // 
            // btnEditProduct
            // 
            btnEditProduct.BackColor = SystemColors.ActiveBorder;
            btnEditProduct.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditProduct.ForeColor = SystemColors.ActiveCaptionText;
            btnEditProduct.Location = new Point(694, 408);
            btnEditProduct.Name = "btnEditProduct";
            btnEditProduct.Size = new Size(120, 43);
            btnEditProduct.TabIndex = 24;
            btnEditProduct.Text = "Edit product";
            btnEditProduct.UseVisualStyleBackColor = false;
            btnEditProduct.Click += btnEditProduct_Click;
            // 
            // btnDeleteProduct
            // 
            btnDeleteProduct.BackColor = SystemColors.ActiveBorder;
            btnDeleteProduct.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteProduct.ForeColor = SystemColors.ActiveCaptionText;
            btnDeleteProduct.Location = new Point(694, 470);
            btnDeleteProduct.Name = "btnDeleteProduct";
            btnDeleteProduct.Size = new Size(120, 43);
            btnDeleteProduct.TabIndex = 25;
            btnDeleteProduct.Text = "Delete product";
            btnDeleteProduct.UseVisualStyleBackColor = false;
            btnDeleteProduct.Click += btnDeleteProduct_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveBorder;
            button1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(156, 457);
            button1.Name = "button1";
            button1.Size = new Size(137, 43);
            button1.TabIndex = 26;
            button1.Text = "Delete all products";
            button1.UseVisualStyleBackColor = false;
            button1.Visible = false;
            button1.Click += button1_Click_1;
            // 
            // UC_Products
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(button1);
            Controls.Add(btnDeleteProduct);
            Controls.Add(btnEditProduct);
            Controls.Add(lbxProducts);
            Controls.Add(btnAddProduct);
            Controls.Add(lblInfo);
            Controls.Add(btnRefresh);
            Name = "UC_Products";
            Size = new Size(886, 533);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnRefresh;
        private Label lblInfo;
        private Button btnAddProduct;
        private ListBox lbxProducts;
        private Button btnEditProduct;
        private Button btnDeleteProduct;
        private Button button1;
    }
}
