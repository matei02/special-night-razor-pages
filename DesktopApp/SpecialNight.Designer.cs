namespace DesktopApp
{
    partial class SpecialNight
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTest = new Label();
            btnOrders = new Button();
            btnAccounts = new Button();
            btnProducts = new Button();
            panel1 = new Panel();
            label2 = new Label();
            button5 = new Button();
            button4 = new Button();
            pictureBox1 = new PictureBox();
            pnlMain = new Panel();
            panel3 = new Panel();
            lblUser = new Label();
            button1 = new Button();
            btnReviews = new Button();
            btnShowBorder = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // lblTest
            // 
            lblTest.AutoSize = true;
            lblTest.Location = new Point(436, 238);
            lblTest.Name = "lblTest";
            lblTest.Size = new Size(0, 15);
            lblTest.TabIndex = 1;
            // 
            // btnOrders
            // 
            btnOrders.Location = new Point(0, 193);
            btnOrders.Name = "btnOrders";
            btnOrders.Size = new Size(189, 28);
            btnOrders.TabIndex = 0;
            btnOrders.Text = "Orders";
            btnOrders.UseVisualStyleBackColor = true;
            btnOrders.Click += button1_Click;
            // 
            // btnAccounts
            // 
            btnAccounts.Location = new Point(0, 244);
            btnAccounts.Name = "btnAccounts";
            btnAccounts.Size = new Size(189, 28);
            btnAccounts.TabIndex = 1;
            btnAccounts.Text = "Accounts";
            btnAccounts.UseVisualStyleBackColor = true;
            btnAccounts.Click += button1_Click;
            // 
            // btnProducts
            // 
            btnProducts.Location = new Point(0, 218);
            btnProducts.Name = "btnProducts";
            btnProducts.Size = new Size(189, 28);
            btnProducts.TabIndex = 2;
            btnProducts.Text = "Products";
            btnProducts.UseVisualStyleBackColor = true;
            btnProducts.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MidnightBlue;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(button4);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1075, 35);
            panel1.TabIndex = 3;
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
            button5.Click += button5_Click;
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
            button4.Click += button4_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.Logo;
            pictureBox1.Location = new Point(0, 34);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(189, 160);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pnlMain
            // 
            pnlMain.BorderStyle = BorderStyle.FixedSingle;
            pnlMain.Location = new Point(186, 34);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(889, 536);
            pnlMain.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblUser);
            panel3.Controls.Add(button1);
            panel3.Location = new Point(0, 507);
            panel3.Name = "panel3";
            panel3.Size = new Size(187, 63);
            panel3.TabIndex = 5;
            // 
            // lblUser
            // 
            lblUser.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            lblUser.Location = new Point(3, 9);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(176, 23);
            lblUser.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(3, 35);
            button1.Name = "button1";
            button1.Size = new Size(176, 23);
            button1.TabIndex = 0;
            button1.Text = "Sign out";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // btnReviews
            // 
            btnReviews.Location = new Point(-2, 269);
            btnReviews.Name = "btnReviews";
            btnReviews.Size = new Size(189, 28);
            btnReviews.TabIndex = 6;
            btnReviews.Text = "Reviews";
            btnReviews.UseVisualStyleBackColor = true;
            btnReviews.Click += button1_Click;
            // 
            // btnShowBorder
            // 
            btnShowBorder.BackColor = Color.LightBlue;
            btnShowBorder.FlatStyle = FlatStyle.Flat;
            btnShowBorder.ForeColor = Color.LightBlue;
            btnShowBorder.Location = new Point(4, 464);
            btnShowBorder.Name = "btnShowBorder";
            btnShowBorder.Size = new Size(176, 37);
            btnShowBorder.TabIndex = 7;
            btnShowBorder.UseVisualStyleBackColor = false;
            btnShowBorder.Click += btnShowBorder_Click;
            // 
            // SpecialNight
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightBlue;
            ClientSize = new Size(1075, 570);
            Controls.Add(btnShowBorder);
            Controls.Add(btnReviews);
            Controls.Add(panel3);
            Controls.Add(pnlMain);
            Controls.Add(pictureBox1);
            Controls.Add(panel1);
            Controls.Add(btnProducts);
            Controls.Add(btnAccounts);
            Controls.Add(btnOrders);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SpecialNight";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlNavbar;
        private Label lblTest;
        private Button btnOrders;
        private Button btnAccounts;
        private Button btnProducts;
        private Panel panel1;
        private Button button5;
        private Button button4;
        private PictureBox pictureBox1;
        private Panel pnlMain;
        private Panel panel3;
        private Button btnReviews;
        private Label label2;
        private Label lblUser;
        private Button button1;
        private Button btnShowBorder;
    }
}