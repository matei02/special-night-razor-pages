namespace DesktopApp
{
    partial class UC_Reviews
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
            this.lbxReviews = new System.Windows.Forms.ListBox();
            this.btnDeleteReviews = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUsers = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbxReviews
            // 
            this.lbxReviews.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lbxReviews.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbxReviews.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lbxReviews.FormattingEnabled = true;
            this.lbxReviews.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.lbxReviews.ItemHeight = 20;
            this.lbxReviews.Location = new System.Drawing.Point(13, 13);
            this.lbxReviews.Name = "lbxReviews";
            this.lbxReviews.Size = new System.Drawing.Size(870, 422);
            this.lbxReviews.TabIndex = 0;
            // 
            // btnDeleteReviews
            // 
            this.btnDeleteReviews.BackColor = System.Drawing.Color.IndianRed;
            this.btnDeleteReviews.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteReviews.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDeleteReviews.Location = new System.Drawing.Point(727, 462);
            this.btnDeleteReviews.Name = "btnDeleteReviews";
            this.btnDeleteReviews.Size = new System.Drawing.Size(139, 49);
            this.btnDeleteReviews.TabIndex = 1;
            this.btnDeleteReviews.Text = "Delete Reviews";
            this.btnDeleteReviews.UseVisualStyleBackColor = false;
            this.btnDeleteReviews.Click += new System.EventHandler(this.btnDeleteReviews_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(521, 447);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select User:";
            // 
            // cbUsers
            // 
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Location = new System.Drawing.Point(521, 478);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(200, 23);
            this.cbUsers.TabIndex = 3;
            // 
            // UC_Reviews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Controls.Add(this.cbUsers);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteReviews);
            this.Controls.Add(this.lbxReviews);
            this.Name = "UC_Reviews";
            this.Size = new System.Drawing.Size(886, 533);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox lbxReviews;
        private Button btnDeleteReviews;
        private Label label1;
        private ComboBox cbUsers;
    }
}
