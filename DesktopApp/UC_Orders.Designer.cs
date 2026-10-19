namespace DesktopApp
{
    partial class UC_Orders
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
            lbxAllOrders = new ListBox();
            btnRefreshOrders = new Button();
            btnOrderInfo = new Button();
            btnRemoveOrder = new Button();
            lblSearchOrder = new Label();
            tbxSearchOrderID = new TextBox();
            btnSearchOrderID = new Button();
            label1 = new Label();
            rtbxOrderInfo = new RichTextBox();
            SuspendLayout();
            // 
            // lbxAllOrders
            // 
            lbxAllOrders.FormattingEnabled = true;
            lbxAllOrders.ItemHeight = 15;
            lbxAllOrders.Location = new Point(43, 37);
            lbxAllOrders.Name = "lbxAllOrders";
            lbxAllOrders.Size = new Size(384, 214);
            lbxAllOrders.TabIndex = 0;
            // 
            // btnRefreshOrders
            // 
            btnRefreshOrders.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnRefreshOrders.Location = new Point(463, 46);
            btnRefreshOrders.Name = "btnRefreshOrders";
            btnRefreshOrders.Size = new Size(110, 34);
            btnRefreshOrders.TabIndex = 1;
            btnRefreshOrders.Text = "Refresh";
            btnRefreshOrders.UseVisualStyleBackColor = true;
            btnRefreshOrders.Click += btnRefreshOrders_Click;
            // 
            // btnOrderInfo
            // 
            btnOrderInfo.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnOrderInfo.Location = new Point(463, 95);
            btnOrderInfo.Name = "btnOrderInfo";
            btnOrderInfo.Size = new Size(110, 34);
            btnOrderInfo.TabIndex = 2;
            btnOrderInfo.Text = "See order info";
            btnOrderInfo.UseVisualStyleBackColor = true;
            btnOrderInfo.Click += btnOrderInfo_Click;
            // 
            // btnRemoveOrder
            // 
            btnRemoveOrder.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnRemoveOrder.Location = new Point(463, 145);
            btnRemoveOrder.Name = "btnRemoveOrder";
            btnRemoveOrder.Size = new Size(110, 34);
            btnRemoveOrder.TabIndex = 3;
            btnRemoveOrder.Text = "Remove Order";
            btnRemoveOrder.UseVisualStyleBackColor = true;
            btnRemoveOrder.Click += btnRemoveOrder_Click;
            // 
            // lblSearchOrder
            // 
            lblSearchOrder.AutoSize = true;
            lblSearchOrder.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblSearchOrder.Location = new Point(463, 208);
            lblSearchOrder.Name = "lblSearchOrder";
            lblSearchOrder.Size = new Size(123, 20);
            lblSearchOrder.TabIndex = 4;
            lblSearchOrder.Text = "Search order (id):";
            // 
            // tbxSearchOrderID
            // 
            tbxSearchOrderID.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            tbxSearchOrderID.Location = new Point(592, 207);
            tbxSearchOrderID.Name = "tbxSearchOrderID";
            tbxSearchOrderID.Size = new Size(109, 25);
            tbxSearchOrderID.TabIndex = 5;
            tbxSearchOrderID.TextChanged += tbxSearchOrderID_TextChanged;
            // 
            // btnSearchOrderID
            // 
            btnSearchOrderID.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnSearchOrderID.Location = new Point(591, 251);
            btnSearchOrderID.Name = "btnSearchOrderID";
            btnSearchOrderID.Size = new Size(110, 34);
            btnSearchOrderID.TabIndex = 6;
            btnSearchOrderID.Text = "Search";
            btnSearchOrderID.UseVisualStyleBackColor = true;
            btnSearchOrderID.Click += btnSearchOrderID_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(43, 15);
            label1.Name = "label1";
            label1.Size = new Size(70, 19);
            label1.TabIndex = 8;
            label1.Text = "All orders";
            // 
            // rtbxOrderInfo
            // 
            rtbxOrderInfo.Enabled = false;
            rtbxOrderInfo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            rtbxOrderInfo.Location = new Point(43, 272);
            rtbxOrderInfo.Name = "rtbxOrderInfo";
            rtbxOrderInfo.Size = new Size(384, 239);
            rtbxOrderInfo.TabIndex = 9;
            rtbxOrderInfo.Text = "";
            // 
            // UC_Orders
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(rtbxOrderInfo);
            Controls.Add(label1);
            Controls.Add(btnSearchOrderID);
            Controls.Add(tbxSearchOrderID);
            Controls.Add(lblSearchOrder);
            Controls.Add(btnRemoveOrder);
            Controls.Add(btnOrderInfo);
            Controls.Add(btnRefreshOrders);
            Controls.Add(lbxAllOrders);
            Name = "UC_Orders";
            Size = new Size(886, 533);
            Load += Orders_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbxAllOrders;
        private Button btnRefreshOrders;
        private Button btnOrderInfo;
        private Button btnRemoveOrder;
        private Label lblSearchOrder;
        private TextBox tbxSearchOrderID;
        private Button btnSearchOrderID;
        private Label label1;
        private RichTextBox rtbxOrderInfo;
    }
}
