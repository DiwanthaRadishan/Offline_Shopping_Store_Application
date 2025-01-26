namespace Shopping_Store_Mangement_System
{
    partial class View_My_Orders
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View_My_Orders));
            this.viewMyOrdersDataGrid = new System.Windows.Forms.DataGridView();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.closeBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cancleOrderBtn = new System.Windows.Forms.Button();
            this.cancleorderLbl = new System.Windows.Forms.Label();
            this.resetorder = new System.Windows.Forms.Button();
            this.itemlistTb = new System.Windows.Forms.TextBox();
            this.itemlistlb = new System.Windows.Forms.Label();
            this.subtotalLb = new System.Windows.Forms.Label();
            this.subtotalTb = new System.Windows.Forms.TextBox();
            this.recievedbtn = new System.Windows.Forms.Button();
            this.OrderHistoryBtn = new System.Windows.Forms.Button();
            this.detailslbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.viewMyOrdersDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // viewMyOrdersDataGrid
            // 
            this.viewMyOrdersDataGrid.AllowUserToAddRows = false;
            this.viewMyOrdersDataGrid.AllowUserToDeleteRows = false;
            this.viewMyOrdersDataGrid.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.viewMyOrdersDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.viewMyOrdersDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.viewMyOrdersDataGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.viewMyOrdersDataGrid.BackgroundColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.viewMyOrdersDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.viewMyOrdersDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.viewMyOrdersDataGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.viewMyOrdersDataGrid.GridColor = System.Drawing.Color.White;
            this.viewMyOrdersDataGrid.Location = new System.Drawing.Point(85, 16);
            this.viewMyOrdersDataGrid.Name = "viewMyOrdersDataGrid";
            this.viewMyOrdersDataGrid.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.viewMyOrdersDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.viewMyOrdersDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.viewMyOrdersDataGrid.Size = new System.Drawing.Size(430, 169);
            this.viewMyOrdersDataGrid.TabIndex = 0;
            this.viewMyOrdersDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.viewMyOrdersDataGrid_CellContentClick);
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.Color.Red;
            this.closeBtn.Location = new System.Drawing.Point(582, 12);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(36, 27);
            this.closeBtn.TabIndex = 33;
            this.closeBtn.Text = "❌";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(-31, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(706, 18);
            this.button1.TabIndex = 34;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button2.Location = new System.Drawing.Point(-5, -6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(15, 371);
            this.button2.TabIndex = 34;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button3.Location = new System.Drawing.Point(621, -6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(15, 371);
            this.button3.TabIndex = 34;
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button4.Location = new System.Drawing.Point(-48, -15);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(723, 25);
            this.button4.TabIndex = 34;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // cancleOrderBtn
            // 
            this.cancleOrderBtn.BackColor = System.Drawing.Color.Red;
            this.cancleOrderBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancleOrderBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cancleOrderBtn.Location = new System.Drawing.Point(422, 191);
            this.cancleOrderBtn.Name = "cancleOrderBtn";
            this.cancleOrderBtn.Size = new System.Drawing.Size(93, 38);
            this.cancleOrderBtn.TabIndex = 37;
            this.cancleOrderBtn.Text = "Cancle Order";
            this.cancleOrderBtn.UseVisualStyleBackColor = false;
            this.cancleOrderBtn.Click += new System.EventHandler(this.cancleOrderBtn_Click);
            // 
            // cancleorderLbl
            // 
            this.cancleorderLbl.AutoSize = true;
            this.cancleorderLbl.BackColor = System.Drawing.Color.White;
            this.cancleorderLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancleorderLbl.ForeColor = System.Drawing.Color.Red;
            this.cancleorderLbl.Location = new System.Drawing.Point(180, 213);
            this.cancleorderLbl.Name = "cancleorderLbl";
            this.cancleorderLbl.Size = new System.Drawing.Size(0, 16);
            this.cancleorderLbl.TabIndex = 43;
            // 
            // resetorder
            // 
            this.resetorder.Location = new System.Drawing.Point(16, 326);
            this.resetorder.Name = "resetorder";
            this.resetorder.Size = new System.Drawing.Size(52, 22);
            this.resetorder.TabIndex = 44;
            this.resetorder.Text = "reset";
            this.resetorder.UseVisualStyleBackColor = true;
            this.resetorder.Click += new System.EventHandler(this.resetorder_Click);
            // 
            // itemlistTb
            // 
            this.itemlistTb.BackColor = System.Drawing.Color.Black;
            this.itemlistTb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.itemlistTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemlistTb.ForeColor = System.Drawing.Color.White;
            this.itemlistTb.Location = new System.Drawing.Point(142, 275);
            this.itemlistTb.Multiline = true;
            this.itemlistTb.Name = "itemlistTb";
            this.itemlistTb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.itemlistTb.Size = new System.Drawing.Size(292, 73);
            this.itemlistTb.TabIndex = 46;
            // 
            // itemlistlb
            // 
            this.itemlistlb.AutoSize = true;
            this.itemlistlb.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.itemlistlb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemlistlb.ForeColor = System.Drawing.Color.White;
            this.itemlistlb.Location = new System.Drawing.Point(223, 240);
            this.itemlistlb.Name = "itemlistlb";
            this.itemlistlb.Size = new System.Drawing.Size(105, 16);
            this.itemlistlb.TabIndex = 45;
            this.itemlistlb.Text = "Ordered Items";
            // 
            // subtotalLb
            // 
            this.subtotalLb.AutoSize = true;
            this.subtotalLb.BackColor = System.Drawing.Color.Black;
            this.subtotalLb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtotalLb.ForeColor = System.Drawing.Color.White;
            this.subtotalLb.Location = new System.Drawing.Point(459, 304);
            this.subtotalLb.Name = "subtotalLb";
            this.subtotalLb.Size = new System.Drawing.Size(98, 16);
            this.subtotalLb.TabIndex = 45;
            this.subtotalLb.Text = "   Sub Total   ";
            // 
            // subtotalTb
            // 
            this.subtotalTb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtotalTb.Location = new System.Drawing.Point(457, 319);
            this.subtotalTb.Name = "subtotalTb";
            this.subtotalTb.Size = new System.Drawing.Size(100, 22);
            this.subtotalTb.TabIndex = 47;
            // 
            // recievedbtn
            // 
            this.recievedbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.recievedbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recievedbtn.ForeColor = System.Drawing.Color.White;
            this.recievedbtn.Location = new System.Drawing.Point(85, 187);
            this.recievedbtn.Name = "recievedbtn";
            this.recievedbtn.Size = new System.Drawing.Size(89, 32);
            this.recievedbtn.TabIndex = 48;
            this.recievedbtn.Text = "Received";
            this.recievedbtn.UseVisualStyleBackColor = false;
            this.recievedbtn.Click += new System.EventHandler(this.recievedbtn_Click);
            // 
            // OrderHistoryBtn
            // 
            this.OrderHistoryBtn.BackColor = System.Drawing.Color.Black;
            this.OrderHistoryBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OrderHistoryBtn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.OrderHistoryBtn.Location = new System.Drawing.Point(16, 275);
            this.OrderHistoryBtn.Name = "OrderHistoryBtn";
            this.OrderHistoryBtn.Size = new System.Drawing.Size(75, 45);
            this.OrderHistoryBtn.TabIndex = 49;
            this.OrderHistoryBtn.Text = "Order History";
            this.OrderHistoryBtn.UseVisualStyleBackColor = false;
            this.OrderHistoryBtn.Click += new System.EventHandler(this.OrderHistoryBtn_Click);
            // 
            // detailslbl
            // 
            this.detailslbl.AutoSize = true;
            this.detailslbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailslbl.Location = new System.Drawing.Point(143, 256);
            this.detailslbl.Name = "detailslbl";
            this.detailslbl.Size = new System.Drawing.Size(289, 16);
            this.detailslbl.TabIndex = 50;
            this.detailslbl.Text = "Item Name         Quantity            Price        ";
            // 
            // View_My_Orders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(630, 360);
            this.Controls.Add(this.detailslbl);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.OrderHistoryBtn);
            this.Controls.Add(this.recievedbtn);
            this.Controls.Add(this.subtotalTb);
            this.Controls.Add(this.itemlistTb);
            this.Controls.Add(this.subtotalLb);
            this.Controls.Add(this.itemlistlb);
            this.Controls.Add(this.resetorder);
            this.Controls.Add(this.cancleorderLbl);
            this.Controls.Add(this.cancleOrderBtn);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.viewMyOrdersDataGrid);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(630, 360);
            this.MinimumSize = new System.Drawing.Size(630, 360);
            this.Name = "View_My_Orders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "View_My_Orders";
            this.Load += new System.EventHandler(this.View_My_Orders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.viewMyOrdersDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView viewMyOrdersDataGrid;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button cancleOrderBtn;
        private System.Windows.Forms.Label cancleorderLbl;
        private System.Windows.Forms.Button resetorder;
        private System.Windows.Forms.TextBox itemlistTb;
        private System.Windows.Forms.Label itemlistlb;
        private System.Windows.Forms.Label subtotalLb;
        private System.Windows.Forms.TextBox subtotalTb;
        private System.Windows.Forms.Button recievedbtn;
        private System.Windows.Forms.Button OrderHistoryBtn;
        private System.Windows.Forms.Label detailslbl;
    }
}