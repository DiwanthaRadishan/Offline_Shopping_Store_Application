namespace Shopping_Store_Mangement_System
{
    partial class OrderHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderHistory));
            this.orderHistoryDatagrid = new System.Windows.Forms.DataGridView();
            this.Summery = new System.Windows.Forms.Label();
            this.resetid = new System.Windows.Forms.Button();
            this.homeBtn = new System.Windows.Forms.Button();
            this.itemlistlb = new System.Windows.Forms.Label();
            this.itemlistLbl = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.resetorderitemtb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.orderHistoryDatagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // orderHistoryDatagrid
            // 
            this.orderHistoryDatagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.orderHistoryDatagrid.BackgroundColor = System.Drawing.Color.DarkGoldenrod;
            this.orderHistoryDatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderHistoryDatagrid.Location = new System.Drawing.Point(217, 87);
            this.orderHistoryDatagrid.Name = "orderHistoryDatagrid";
            this.orderHistoryDatagrid.Size = new System.Drawing.Size(571, 217);
            this.orderHistoryDatagrid.TabIndex = 0;
            this.orderHistoryDatagrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.orderHistoryDatagrid_CellContentClick);
            // 
            // Summery
            // 
            this.Summery.AutoSize = true;
            this.Summery.BackColor = System.Drawing.Color.Transparent;
            this.Summery.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Summery.Location = new System.Drawing.Point(430, 29);
            this.Summery.Name = "Summery";
            this.Summery.Size = new System.Drawing.Size(236, 55);
            this.Summery.TabIndex = 1;
            this.Summery.Text = "OrderLog";
            // 
            // resetid
            // 
            this.resetid.BackColor = System.Drawing.Color.Red;
            this.resetid.Location = new System.Drawing.Point(737, 428);
            this.resetid.Name = "resetid";
            this.resetid.Size = new System.Drawing.Size(60, 23);
            this.resetid.TabIndex = 2;
            this.resetid.Text = "Reset";
            this.resetid.UseVisualStyleBackColor = false;
            this.resetid.Click += new System.EventHandler(this.resetid_Click);
            // 
            // homeBtn
            // 
            this.homeBtn.BackColor = System.Drawing.Color.Yellow;
            this.homeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.homeBtn.ForeColor = System.Drawing.Color.Red;
            this.homeBtn.Location = new System.Drawing.Point(12, 12);
            this.homeBtn.Name = "homeBtn";
            this.homeBtn.Size = new System.Drawing.Size(105, 32);
            this.homeBtn.TabIndex = 5;
            this.homeBtn.Text = " 🏠︎ Home";
            this.homeBtn.UseVisualStyleBackColor = false;
            this.homeBtn.Click += new System.EventHandler(this.homeBtn_Click);
            // 
            // itemlistlb
            // 
            this.itemlistlb.AutoSize = true;
            this.itemlistlb.BackColor = System.Drawing.Color.Transparent;
            this.itemlistlb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemlistlb.ForeColor = System.Drawing.Color.Red;
            this.itemlistlb.Location = new System.Drawing.Point(500, 316);
            this.itemlistlb.Name = "itemlistlb";
            this.itemlistlb.Size = new System.Drawing.Size(105, 16);
            this.itemlistlb.TabIndex = 6;
            this.itemlistlb.Text = "Ordered Items";
            // 
            // itemlistLbl
            // 
            this.itemlistLbl.BackColor = System.Drawing.Color.Goldenrod;
            this.itemlistLbl.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemlistLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemlistLbl.Location = new System.Drawing.Point(449, 352);
            this.itemlistLbl.Multiline = true;
            this.itemlistLbl.Name = "itemlistLbl";
            this.itemlistLbl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.itemlistLbl.Size = new System.Drawing.Size(229, 69);
            this.itemlistLbl.TabIndex = 7;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(449, 333);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(229, 16);
            this.label.TabIndex = 8;
            this.label.Text = "Product Name             Quantity    ";
            // 
            // resetorderitemtb
            // 
            this.resetorderitemtb.BackColor = System.Drawing.Color.Goldenrod;
            this.resetorderitemtb.ForeColor = System.Drawing.Color.White;
            this.resetorderitemtb.Location = new System.Drawing.Point(1, 427);
            this.resetorderitemtb.Name = "resetorderitemtb";
            this.resetorderitemtb.Size = new System.Drawing.Size(116, 23);
            this.resetorderitemtb.TabIndex = 9;
            this.resetorderitemtb.Text = "Reset orderitemTb";
            this.resetorderitemtb.UseVisualStyleBackColor = false;
            this.resetorderitemtb.Click += new System.EventHandler(this.resetorderitemtb_Click);
            // 
            // OrderHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.resetorderitemtb);
            this.Controls.Add(this.label);
            this.Controls.Add(this.itemlistLbl);
            this.Controls.Add(this.itemlistlb);
            this.Controls.Add(this.homeBtn);
            this.Controls.Add(this.resetid);
            this.Controls.Add(this.Summery);
            this.Controls.Add(this.orderHistoryDatagrid);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(800, 450);
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "OrderHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OrderHistory";
            this.Load += new System.EventHandler(this.OrderHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.orderHistoryDatagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView orderHistoryDatagrid;
        private System.Windows.Forms.Label Summery;
        private System.Windows.Forms.Button resetid;
        private System.Windows.Forms.Button homeBtn;
        private System.Windows.Forms.Label itemlistlb;
        private System.Windows.Forms.TextBox itemlistLbl;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button resetorderitemtb;
    }
}