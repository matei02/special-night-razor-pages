namespace DesktopApp
{
    partial class Products
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button1 = new Button();
            label2 = new Label();
            button5 = new Button();
            button4 = new Button();
            tbxName = new TextBox();
            cbProducts = new ComboBox();
            label1 = new Label();
            btnAddProduct = new Button();
            label3 = new Label();
            label4 = new Label();
            tbxPrice = new TextBox();
            label5 = new Label();
            tbxQuantity = new TextBox();
            label6 = new Label();
            cbMaterial = new ComboBox();
            numBust = new NumericUpDown();
            numWaist = new NumericUpDown();
            numHips = new NumericUpDown();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            cbColors = new ComboBox();
            label10 = new Label();
            btnSaveEdit = new Button();
            button2 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numBust).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numWaist).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numHips).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top;
            panel1.BackColor = Color.RoyalBlue;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(653, 35);
            panel1.TabIndex = 4;
            // 
            // button1
            // 
            button1.BackColor = Color.Black;
            button1.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = SystemColors.ControlLightLight;
            button1.Location = new Point(611, -1);
            button1.Name = "button1";
            button1.Size = new Size(37, 35);
            button1.TabIndex = 4;
            button1.Text = "X";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BorderStyle = BorderStyle.FixedSingle;
            label2.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = Color.White;
            label2.Location = new Point(11, 8);
            label2.Name = "label2";
            label2.Size = new Size(103, 20);
            label2.TabIndex = 2;
            label2.Text = "Special Night";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button5
            // 
            button5.BackColor = Color.Black;
            button5.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            button5.ForeColor = SystemColors.ControlLightLight;
            button5.Location = new Point(1033, -1);
            button5.Name = "button5";
            button5.Size = new Size(37, 35);
            button5.TabIndex = 1;
            button5.Text = "X";
            button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = Color.Black;
            button4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button4.ForeColor = SystemColors.ControlLightLight;
            button4.Location = new Point(991, -1);
            button4.Name = "button4";
            button4.Size = new Size(36, 35);
            button4.TabIndex = 0;
            button4.Text = "__";
            button4.UseVisualStyleBackColor = false;
            // 
            // tbxName
            // 
            tbxName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tbxName.Location = new Point(128, 102);
            tbxName.Name = "tbxName";
            tbxName.Size = new Size(121, 25);
            tbxName.TabIndex = 5;
            tbxName.TextChanged += tbxName_TextChanged;
            // 
            // cbProducts
            // 
            cbProducts.FormattingEnabled = true;
            cbProducts.Items.AddRange(new object[] { "Dress", "Suit", "Necklace", "Bracelet", "Earrings" });
            cbProducts.Location = new Point(128, 59);
            cbProducts.Name = "cbProducts";
            cbProducts.Size = new Size(121, 23);
            cbProducts.TabIndex = 6;
            cbProducts.SelectedIndexChanged += cbProducts_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(12, 60);
            label1.Name = "label1";
            label1.Size = new Size(110, 19);
            label1.TabIndex = 7;
            label1.Text = "Choose product:";
            // 
            // btnAddProduct
            // 
            btnAddProduct.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAddProduct.Location = new Point(480, 348);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(126, 40);
            btnAddProduct.TabIndex = 8;
            btnAddProduct.Text = "Add product";
            btnAddProduct.UseVisualStyleBackColor = true;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(12, 105);
            label3.Name = "label3";
            label3.Size = new Size(48, 19);
            label3.TabIndex = 9;
            label3.Text = "Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 147);
            label4.Name = "label4";
            label4.Size = new Size(41, 19);
            label4.TabIndex = 11;
            label4.Text = "Price:";
            // 
            // tbxPrice
            // 
            tbxPrice.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tbxPrice.Location = new Point(128, 144);
            tbxPrice.Name = "tbxPrice";
            tbxPrice.Size = new Size(121, 25);
            tbxPrice.TabIndex = 10;
            tbxPrice.TextChanged += tbxPrice_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(12, 193);
            label5.Name = "label5";
            label5.Size = new Size(66, 19);
            label5.TabIndex = 13;
            label5.Text = "Quantity:";
            // 
            // tbxQuantity
            // 
            tbxQuantity.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tbxQuantity.Location = new Point(128, 190);
            tbxQuantity.Name = "tbxQuantity";
            tbxQuantity.Size = new Size(121, 25);
            tbxQuantity.TabIndex = 12;
            tbxQuantity.TextChanged += tbxQuantity_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(12, 246);
            label6.Name = "label6";
            label6.Size = new Size(111, 19);
            label6.TabIndex = 15;
            label6.Text = "Choose material:";
            // 
            // cbMaterial
            // 
            cbMaterial.FormattingEnabled = true;
            cbMaterial.Location = new Point(128, 245);
            cbMaterial.Name = "cbMaterial";
            cbMaterial.Size = new Size(121, 23);
            cbMaterial.TabIndex = 14;
            // 
            // numBust
            // 
            numBust.Location = new Point(128, 286);
            numBust.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numBust.Minimum = new decimal(new int[] { 30, 0, 0, 0 });
            numBust.Name = "numBust";
            numBust.Size = new Size(120, 23);
            numBust.TabIndex = 16;
            numBust.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // numWaist
            // 
            numWaist.Location = new Point(128, 325);
            numWaist.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numWaist.Minimum = new decimal(new int[] { 30, 0, 0, 0 });
            numWaist.Name = "numWaist";
            numWaist.Size = new Size(120, 23);
            numWaist.TabIndex = 17;
            numWaist.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // numHips
            // 
            numHips.Location = new Point(129, 365);
            numHips.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            numHips.Minimum = new decimal(new int[] { 30, 0, 0, 0 });
            numHips.Name = "numHips";
            numHips.Size = new Size(120, 23);
            numHips.TabIndex = 18;
            numHips.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label7.Location = new Point(11, 286);
            label7.Name = "label7";
            label7.Size = new Size(66, 19);
            label7.TabIndex = 19;
            label7.Text = "Size bust:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label8.Location = new Point(11, 325);
            label8.Name = "label8";
            label8.Size = new Size(70, 19);
            label8.TabIndex = 20;
            label8.Text = "Size waist:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label9.Location = new Point(11, 365);
            label9.Name = "label9";
            label9.Size = new Size(64, 19);
            label9.TabIndex = 21;
            label9.Text = "Size hips:";
            // 
            // cbColors
            // 
            cbColors.FormattingEnabled = true;
            cbColors.Location = new Point(335, 245);
            cbColors.Name = "cbColors";
            cbColors.Size = new Size(121, 23);
            cbColors.TabIndex = 22;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(272, 246);
            label10.Name = "label10";
            label10.Size = new Size(45, 19);
            label10.TabIndex = 23;
            label10.Text = "Color:";
            // 
            // btnSaveEdit
            // 
            btnSaveEdit.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnSaveEdit.Location = new Point(480, 302);
            btnSaveEdit.Name = "btnSaveEdit";
            btnSaveEdit.Size = new Size(126, 40);
            btnSaveEdit.TabIndex = 24;
            btnSaveEdit.Text = "Save edit";
            btnSaveEdit.UseVisualStyleBackColor = true;
            btnSaveEdit.Click += btnSaveEdit_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkCyan;
            button2.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = SystemColors.Control;
            button2.Location = new Point(378, 85);
            button2.Name = "button2";
            button2.Size = new Size(213, 111);
            button2.TabIndex = 25;
            button2.Text = "Add all in bulk";
            button2.UseVisualStyleBackColor = false;
            button2.Visible = false;
            button2.Click += button2_Click;
            // 
            // Products
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSeaGreen;
            ClientSize = new Size(652, 410);
            Controls.Add(button2);
            Controls.Add(btnSaveEdit);
            Controls.Add(label10);
            Controls.Add(cbColors);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(numHips);
            Controls.Add(numWaist);
            Controls.Add(numBust);
            Controls.Add(label6);
            Controls.Add(cbMaterial);
            Controls.Add(label5);
            Controls.Add(tbxQuantity);
            Controls.Add(label4);
            Controls.Add(tbxPrice);
            Controls.Add(label3);
            Controls.Add(btnAddProduct);
            Controls.Add(label1);
            Controls.Add(cbProducts);
            Controls.Add(tbxName);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Products";
            Text = "AddProducts";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numBust).EndInit();
            ((System.ComponentModel.ISupportInitialize)numWaist).EndInit();
            ((System.ComponentModel.ISupportInitialize)numHips).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Button button5;
        private Button button4;
        private Button button1;
        private TextBox tbxName;
        private ComboBox cbProducts;
        private Label label1;
        private Button btnAddProduct;
        private Label label3;
        private Label label4;
        private TextBox tbxPrice;
        private Label label5;
        private TextBox tbxQuantity;
        private Label label6;
        private ComboBox cbMaterial;
        private NumericUpDown numBust;
        private NumericUpDown numWaist;
        private NumericUpDown numHips;
        private Label label7;
        private Label label8;
        private Label label9;
        private ComboBox cbColors;
        private Label label10;
        private Button btnSaveEdit;
        private Button button2;
    }
}