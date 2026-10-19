namespace DesktopApp
{
    partial class UC_Accounts
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
            lbxCustomers = new ListBox();
            lblAccountInfo = new Label();
            btnRefresh = new Button();
            btnGetAccountInfo = new Button();
            label1 = new Label();
            groupBox1 = new GroupBox();
            cbxCustomerGender = new ComboBox();
            numCustomerAge = new NumericUpDown();
            lblCustomerGender = new Label();
            lblCustomerAge = new Label();
            tbxConfirmPassword = new TextBox();
            lblConfirmPassword = new Label();
            btnSaveEdit = new Button();
            rbAdmin = new RadioButton();
            rbCustomer = new RadioButton();
            btnAddAccount = new Button();
            tbxPhoneNumber = new TextBox();
            label5 = new Label();
            tbxAddress = new TextBox();
            label4 = new Label();
            tbxEmail = new TextBox();
            label3 = new Label();
            tbxPassword = new TextBox();
            label2 = new Label();
            tbxName = new TextBox();
            btnRemoveAccount = new Button();
            lbxAdmins = new ListBox();
            label6 = new Label();
            label7 = new Label();
            btnEditAccount = new Button();
            btnEndRental = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCustomerAge).BeginInit();
            SuspendLayout();
            // 
            // lbxCustomers
            // 
            lbxCustomers.FormattingEnabled = true;
            lbxCustomers.ItemHeight = 15;
            lbxCustomers.Location = new Point(12, 35);
            lbxCustomers.Name = "lbxCustomers";
            lbxCustomers.Size = new Size(298, 319);
            lbxCustomers.TabIndex = 0;
            lbxCustomers.Enter += lbxCustomers_Enter;
            // 
            // lblAccountInfo
            // 
            lblAccountInfo.BorderStyle = BorderStyle.FixedSingle;
            lblAccountInfo.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblAccountInfo.Location = new Point(316, 320);
            lblAccountInfo.Name = "lblAccountInfo";
            lblAccountInfo.Size = new Size(260, 206);
            lblAccountInfo.TabIndex = 1;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = SystemColors.ActiveCaption;
            btnRefresh.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnRefresh.ForeColor = Color.Black;
            btnRefresh.Location = new Point(328, 51);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(87, 31);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // btnGetAccountInfo
            // 
            btnGetAccountInfo.BackColor = SystemColors.ActiveCaptionText;
            btnGetAccountInfo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnGetAccountInfo.ForeColor = SystemColors.ControlLightLight;
            btnGetAccountInfo.Location = new Point(316, 278);
            btnGetAccountInfo.Name = "btnGetAccountInfo";
            btnGetAccountInfo.Size = new Size(87, 31);
            btnGetAccountInfo.TabIndex = 3;
            btnGetAccountInfo.Text = "Get Info";
            btnGetAccountInfo.UseVisualStyleBackColor = false;
            btnGetAccountInfo.Click += btnGetAccountInfo_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label1.Location = new Point(6, 78);
            label1.Name = "label1";
            label1.Size = new Size(55, 20);
            label1.TabIndex = 4;
            label1.Text = "Name:";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ActiveCaption;
            groupBox1.Controls.Add(cbxCustomerGender);
            groupBox1.Controls.Add(numCustomerAge);
            groupBox1.Controls.Add(lblCustomerGender);
            groupBox1.Controls.Add(lblCustomerAge);
            groupBox1.Controls.Add(tbxConfirmPassword);
            groupBox1.Controls.Add(lblConfirmPassword);
            groupBox1.Controls.Add(btnSaveEdit);
            groupBox1.Controls.Add(rbAdmin);
            groupBox1.Controls.Add(rbCustomer);
            groupBox1.Controls.Add(btnAddAccount);
            groupBox1.Controls.Add(tbxPhoneNumber);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(tbxAddress);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(tbxEmail);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(tbxPassword);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(tbxName);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            groupBox1.Location = new Point(582, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(290, 514);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Add Account";
            // 
            // cbxCustomerGender
            // 
            cbxCustomerGender.FormattingEnabled = true;
            cbxCustomerGender.Location = new Point(82, 316);
            cbxCustomerGender.Name = "cbxCustomerGender";
            cbxCustomerGender.Size = new Size(121, 26);
            cbxCustomerGender.TabIndex = 22;
            // 
            // numCustomerAge
            // 
            numCustomerAge.Location = new Point(82, 288);
            numCustomerAge.Minimum = new decimal(new int[] { 16, 0, 0, 0 });
            numCustomerAge.Name = "numCustomerAge";
            numCustomerAge.Size = new Size(120, 25);
            numCustomerAge.TabIndex = 21;
            numCustomerAge.Value = new decimal(new int[] { 16, 0, 0, 0 });
            // 
            // lblCustomerGender
            // 
            lblCustomerGender.AutoSize = true;
            lblCustomerGender.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            lblCustomerGender.Location = new Point(6, 316);
            lblCustomerGender.Name = "lblCustomerGender";
            lblCustomerGender.Size = new Size(65, 20);
            lblCustomerGender.TabIndex = 20;
            lblCustomerGender.Text = "Gender:";
            // 
            // lblCustomerAge
            // 
            lblCustomerAge.AutoSize = true;
            lblCustomerAge.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            lblCustomerAge.Location = new Point(6, 288);
            lblCustomerAge.Name = "lblCustomerAge";
            lblCustomerAge.Size = new Size(41, 20);
            lblCustomerAge.TabIndex = 19;
            lblCustomerAge.Text = "Age:";
            // 
            // tbxConfirmPassword
            // 
            tbxConfirmPassword.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            tbxConfirmPassword.Location = new Point(92, 160);
            tbxConfirmPassword.Name = "tbxConfirmPassword";
            tbxConfirmPassword.PasswordChar = '*';
            tbxConfirmPassword.Size = new Size(192, 27);
            tbxConfirmPassword.TabIndex = 18;
            tbxConfirmPassword.TextChanged += tbxConfirmPassword_TextChanged;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            lblConfirmPassword.Location = new Point(6, 147);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(80, 43);
            lblConfirmPassword.TabIndex = 17;
            lblConfirmPassword.Text = "Confirm password:";
            // 
            // btnSaveEdit
            // 
            btnSaveEdit.Location = new Point(170, 480);
            btnSaveEdit.Name = "btnSaveEdit";
            btnSaveEdit.Size = new Size(114, 28);
            btnSaveEdit.TabIndex = 16;
            btnSaveEdit.Text = "Save edit";
            btnSaveEdit.UseVisualStyleBackColor = true;
            btnSaveEdit.Click += btnSaveEdit_Click;
            // 
            // rbAdmin
            // 
            rbAdmin.AutoSize = true;
            rbAdmin.Location = new Point(170, 39);
            rbAdmin.Name = "rbAdmin";
            rbAdmin.Size = new Size(69, 22);
            rbAdmin.TabIndex = 15;
            rbAdmin.TabStop = true;
            rbAdmin.Text = "Admin";
            rbAdmin.UseVisualStyleBackColor = true;
            rbAdmin.CheckedChanged += rbAdmin_CheckedChanged;
            // 
            // rbCustomer
            // 
            rbCustomer.AutoSize = true;
            rbCustomer.Location = new Point(28, 39);
            rbCustomer.Name = "rbCustomer";
            rbCustomer.Size = new Size(95, 22);
            rbCustomer.TabIndex = 14;
            rbCustomer.TabStop = true;
            rbCustomer.Text = "Customer";
            rbCustomer.UseVisualStyleBackColor = true;
            rbCustomer.CheckedChanged += rbCustomer_CheckedChanged;
            // 
            // btnAddAccount
            // 
            btnAddAccount.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddAccount.Location = new Point(92, 430);
            btnAddAccount.Name = "btnAddAccount";
            btnAddAccount.Size = new Size(121, 44);
            btnAddAccount.TabIndex = 6;
            btnAddAccount.Text = "Add Account";
            btnAddAccount.UseVisualStyleBackColor = true;
            btnAddAccount.Click += btnAddAccount_Click;
            // 
            // tbxPhoneNumber
            // 
            tbxPhoneNumber.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            tbxPhoneNumber.Location = new Point(6, 381);
            tbxPhoneNumber.Name = "tbxPhoneNumber";
            tbxPhoneNumber.Size = new Size(217, 27);
            tbxPhoneNumber.TabIndex = 13;
            tbxPhoneNumber.TextChanged += tbxPhoneNumber_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label5.Location = new Point(6, 348);
            label5.Name = "label5";
            label5.Size = new Size(117, 20);
            label5.TabIndex = 12;
            label5.Text = "Phone number:";
            // 
            // tbxAddress
            // 
            tbxAddress.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            tbxAddress.Location = new Point(82, 250);
            tbxAddress.Name = "tbxAddress";
            tbxAddress.Size = new Size(202, 27);
            tbxAddress.TabIndex = 11;
            tbxAddress.TextChanged += tbxAddress_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label4.Location = new Point(6, 253);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 10;
            label4.Text = "Address:";
            // 
            // tbxEmail
            // 
            tbxEmail.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            tbxEmail.Location = new Point(67, 206);
            tbxEmail.Name = "tbxEmail";
            tbxEmail.Size = new Size(217, 27);
            tbxEmail.TabIndex = 9;
            tbxEmail.TextChanged += tbxEmail_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label3.Location = new Point(6, 209);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 8;
            label3.Text = "Email:";
            // 
            // tbxPassword
            // 
            tbxPassword.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            tbxPassword.Location = new Point(92, 117);
            tbxPassword.Name = "tbxPassword";
            tbxPassword.PasswordChar = '*';
            tbxPassword.Size = new Size(192, 27);
            tbxPassword.TabIndex = 7;
            tbxPassword.TextChanged += tbxPassword_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label2.Location = new Point(6, 120);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 6;
            label2.Text = "Password:";
            // 
            // tbxName
            // 
            tbxName.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            tbxName.Location = new Point(67, 75);
            tbxName.Name = "tbxName";
            tbxName.Size = new Size(217, 27);
            tbxName.TabIndex = 5;
            tbxName.TextChanged += tbxName_TextChanged;
            // 
            // btnRemoveAccount
            // 
            btnRemoveAccount.BackColor = Color.Salmon;
            btnRemoveAccount.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnRemoveAccount.ForeColor = Color.Black;
            btnRemoveAccount.Location = new Point(328, 103);
            btnRemoveAccount.Name = "btnRemoveAccount";
            btnRemoveAccount.Size = new Size(125, 31);
            btnRemoveAccount.TabIndex = 6;
            btnRemoveAccount.Text = "Remove account";
            btnRemoveAccount.UseVisualStyleBackColor = false;
            btnRemoveAccount.Click += btnRemoveAccount_Click;
            // 
            // lbxAdmins
            // 
            lbxAdmins.FormattingEnabled = true;
            lbxAdmins.ItemHeight = 15;
            lbxAdmins.Location = new Point(12, 387);
            lbxAdmins.Name = "lbxAdmins";
            lbxAdmins.Size = new Size(298, 139);
            lbxAdmins.TabIndex = 7;
            lbxAdmins.Enter += lbxAdmins_Enter;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label6.Location = new Point(12, 12);
            label6.Name = "label6";
            label6.Size = new Size(84, 20);
            label6.TabIndex = 8;
            label6.Text = "Customers";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label7.Location = new Point(12, 364);
            label7.Name = "label7";
            label7.Size = new Size(63, 20);
            label7.TabIndex = 9;
            label7.Text = "Admins";
            // 
            // btnEditAccount
            // 
            btnEditAccount.BackColor = Color.YellowGreen;
            btnEditAccount.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnEditAccount.ForeColor = Color.Black;
            btnEditAccount.Location = new Point(328, 158);
            btnEditAccount.Name = "btnEditAccount";
            btnEditAccount.Size = new Size(125, 31);
            btnEditAccount.TabIndex = 10;
            btnEditAccount.Text = "Edit Account";
            btnEditAccount.UseVisualStyleBackColor = false;
            btnEditAccount.Click += btnEditAccount_Click;
            // 
            // btnEndRental
            // 
            btnEndRental.BackColor = Color.Orange;
            btnEndRental.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnEndRental.ForeColor = Color.Black;
            btnEndRental.Location = new Point(328, 215);
            btnEndRental.Name = "btnEndRental";
            btnEndRental.Size = new Size(125, 31);
            btnEndRental.TabIndex = 11;
            btnEndRental.Text = "End rental";
            btnEndRental.UseVisualStyleBackColor = false;
            btnEndRental.Click += btnEndRental_Click;
            // 
            // UC_Accounts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnEndRental);
            Controls.Add(btnEditAccount);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(lbxAdmins);
            Controls.Add(btnRemoveAccount);
            Controls.Add(groupBox1);
            Controls.Add(btnGetAccountInfo);
            Controls.Add(btnRefresh);
            Controls.Add(lblAccountInfo);
            Controls.Add(lbxCustomers);
            Name = "UC_Accounts";
            Size = new Size(886, 533);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCustomerAge).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbxCustomers;
        private Label lblAccountInfo;
        private Button btnRefresh;
        private Button btnGetAccountInfo;
        private Label label1;
        private GroupBox groupBox1;
        private TextBox tbxPassword;
        private Label label2;
        private TextBox tbxName;
        private TextBox tbxEmail;
        private Label label3;
        private TextBox tbxAddress;
        private Label label4;
        private TextBox tbxPhoneNumber;
        private Label label5;
        private Button btnAddAccount;
        private Button btnRemoveAccount;
        private RadioButton rbAdmin;
        private RadioButton rbCustomer;
        private ListBox lbxAdmins;
        private Label label6;
        private Label label7;
        private Button btnSaveEdit;
        private Button btnEditAccount;
        private TextBox tbxConfirmPassword;
        private Label lblConfirmPassword;
        private Button btnEndRental;
        private ComboBox cbxCustomerGender;
        private NumericUpDown numCustomerAge;
        private Label lblCustomerGender;
        private Label lblCustomerAge;
    }
}
