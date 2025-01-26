namespace Shopping_Store_Mangement_System
{
    partial class Store_mangement
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Store_mangement));
            this.panel1 = new System.Windows.Forms.Panel();
            this.managerdetailslbl = new System.Windows.Forms.Label();
            this.managerdetails = new System.Windows.Forms.PictureBox();
            this.closeBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.inventoryMangementBtn = new System.Windows.Forms.Button();
            this.UserMangementBtn = new System.Windows.Forms.Button();
            this.orderBtn = new System.Windows.Forms.Button();
            this.AddNewAdminBtn = new System.Windows.Forms.Button();
            this.logOutBtn = new System.Windows.Forms.Button();
            this.ordersHistoryBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.managerdetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.managerdetailslbl);
            this.panel1.Controls.Add(this.managerdetails);
            this.panel1.Controls.Add(this.closeBtn);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(790, 100);
            this.panel1.TabIndex = 0;
            // 
            // managerdetailslbl
            // 
            this.managerdetailslbl.AutoSize = true;
            this.managerdetailslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.managerdetailslbl.ForeColor = System.Drawing.Color.White;
            this.managerdetailslbl.Location = new System.Drawing.Point(722, 83);
            this.managerdetailslbl.Name = "managerdetailslbl";
            this.managerdetailslbl.Size = new System.Drawing.Size(52, 16);
            this.managerdetailslbl.TabIndex = 6;
            this.managerdetailslbl.Text = "Profile";
            this.managerdetailslbl.Click += new System.EventHandler(this.managerdetailslbl_Click);
            // 
            // managerdetails
            // 
            this.managerdetails.BackColor = System.Drawing.Color.White;
            this.managerdetails.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("managerdetails.BackgroundImage")));
            this.managerdetails.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.managerdetails.Location = new System.Drawing.Point(725, 42);
            this.managerdetails.Name = "managerdetails";
            this.managerdetails.Size = new System.Drawing.Size(39, 38);
            this.managerdetails.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.managerdetails.TabIndex = 5;
            this.managerdetails.TabStop = false;
            this.managerdetails.Click += new System.EventHandler(this.managerdetails_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.Color.Red;
            this.closeBtn.Location = new System.Drawing.Point(744, 3);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(36, 27);
            this.closeBtn.TabIndex = 4;
            this.closeBtn.Text = "❌";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.ImageLocation = "";
            this.pictureBox1.Location = new System.Drawing.Point(12, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 41);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Location = new System.Drawing.Point(8, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Profile";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(349, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "[Admin]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(484, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 33);
            this.label2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(201, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(425, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Shopping Store Management \r\n";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(12, 439);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(768, 10);
            this.panel3.TabIndex = 10;
            // 
            // inventoryMangementBtn
            // 
            this.inventoryMangementBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.inventoryMangementBtn.Font = new System.Drawing.Font("Microsoft New Tai Lue", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryMangementBtn.ForeColor = System.Drawing.Color.White;
            this.inventoryMangementBtn.Location = new System.Drawing.Point(19, 234);
            this.inventoryMangementBtn.Name = "inventoryMangementBtn";
            this.inventoryMangementBtn.Size = new System.Drawing.Size(149, 58);
            this.inventoryMangementBtn.TabIndex = 11;
            this.inventoryMangementBtn.Text = "Inventory Magement";
            this.inventoryMangementBtn.UseVisualStyleBackColor = false;
            this.inventoryMangementBtn.Click += new System.EventHandler(this.inventoryMangementBtn_Click);
            // 
            // UserMangementBtn
            // 
            this.UserMangementBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.UserMangementBtn.Font = new System.Drawing.Font("Microsoft New Tai Lue", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserMangementBtn.ForeColor = System.Drawing.Color.White;
            this.UserMangementBtn.Location = new System.Drawing.Point(326, 130);
            this.UserMangementBtn.Name = "UserMangementBtn";
            this.UserMangementBtn.Size = new System.Drawing.Size(149, 58);
            this.UserMangementBtn.TabIndex = 11;
            this.UserMangementBtn.Text = "User Mangement";
            this.UserMangementBtn.UseVisualStyleBackColor = false;
            this.UserMangementBtn.Click += new System.EventHandler(this.UserMangementBtn_Click);
            // 
            // orderBtn
            // 
            this.orderBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.orderBtn.Font = new System.Drawing.Font("Microsoft New Tai Lue", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.orderBtn.ForeColor = System.Drawing.Color.White;
            this.orderBtn.Location = new System.Drawing.Point(326, 347);
            this.orderBtn.Name = "orderBtn";
            this.orderBtn.Size = new System.Drawing.Size(149, 58);
            this.orderBtn.TabIndex = 11;
            this.orderBtn.Text = "Order Mangement";
            this.orderBtn.UseVisualStyleBackColor = false;
            this.orderBtn.Click += new System.EventHandler(this.orderBtn_Click);
            // 
            // AddNewAdminBtn
            // 
            this.AddNewAdminBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.AddNewAdminBtn.Font = new System.Drawing.Font("Microsoft New Tai Lue", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddNewAdminBtn.ForeColor = System.Drawing.Color.White;
            this.AddNewAdminBtn.Location = new System.Drawing.Point(612, 234);
            this.AddNewAdminBtn.Name = "AddNewAdminBtn";
            this.AddNewAdminBtn.Size = new System.Drawing.Size(149, 58);
            this.AddNewAdminBtn.TabIndex = 11;
            this.AddNewAdminBtn.Text = "Add new Admin";
            this.AddNewAdminBtn.UseVisualStyleBackColor = false;
            this.AddNewAdminBtn.Click += new System.EventHandler(this.AddNewAdminBtn_Click);
            // 
            // logOutBtn
            // 
            this.logOutBtn.BackColor = System.Drawing.Color.Red;
            this.logOutBtn.Font = new System.Drawing.Font("Microsoft New Tai Lue", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logOutBtn.ForeColor = System.Drawing.Color.White;
            this.logOutBtn.Location = new System.Drawing.Point(649, 404);
            this.logOutBtn.Name = "logOutBtn";
            this.logOutBtn.Size = new System.Drawing.Size(131, 29);
            this.logOutBtn.TabIndex = 11;
            this.logOutBtn.Text = "⛔ Log Out";
            this.logOutBtn.UseVisualStyleBackColor = false;
            this.logOutBtn.Click += new System.EventHandler(this.logOutBtn_Click);
            // 
            // ordersHistoryBtn
            // 
            this.ordersHistoryBtn.BackColor = System.Drawing.Color.Yellow;
            this.ordersHistoryBtn.Font = new System.Drawing.Font("Microsoft New Tai Lue", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ordersHistoryBtn.ForeColor = System.Drawing.Color.Black;
            this.ordersHistoryBtn.Location = new System.Drawing.Point(326, 234);
            this.ordersHistoryBtn.Name = "ordersHistoryBtn";
            this.ordersHistoryBtn.Size = new System.Drawing.Size(149, 58);
            this.ordersHistoryBtn.TabIndex = 12;
            this.ordersHistoryBtn.Text = "Orders History";
            this.ordersHistoryBtn.UseVisualStyleBackColor = false;
            this.ordersHistoryBtn.Click += new System.EventHandler(this.ordersHistoryBtn_Click);
            // 
            // Store_mangement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(790, 460);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.ordersHistoryBtn);
            this.Controls.Add(this.logOutBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.AddNewAdminBtn);
            this.Controls.Add(this.inventoryMangementBtn);
            this.Controls.Add(this.orderBtn);
            this.Controls.Add(this.UserMangementBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(790, 460);
            this.MinimumSize = new System.Drawing.Size(790, 460);
            this.Name = "Store_mangement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory_mangement";
            this.Load += new System.EventHandler(this.Inventory_mangement_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.managerdetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Label managerdetailslbl;
        private System.Windows.Forms.PictureBox managerdetails;
        private System.Windows.Forms.Button ordersHistoryBtn;
        private System.Windows.Forms.Button logOutBtn;
        private System.Windows.Forms.Button AddNewAdminBtn;
        private System.Windows.Forms.Button orderBtn;
        private System.Windows.Forms.Button UserMangementBtn;
        private System.Windows.Forms.Button inventoryMangementBtn;
        private System.Windows.Forms.Panel panel3;
    }
}