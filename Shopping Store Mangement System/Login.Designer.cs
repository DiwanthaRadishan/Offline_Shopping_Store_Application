namespace Shopping_Store_Mangement_System
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.panel1 = new System.Windows.Forms.Panel();
            this.errorLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UnameLbl = new System.Windows.Forms.Label();
            this.showPw = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.signUp = new System.Windows.Forms.Label();
            this.clear = new System.Windows.Forms.Label();
            this.loginBtn = new System.Windows.Forms.Button();
            this.pwTb = new System.Windows.Forms.TextBox();
            this.unameTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.closeBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.errorLbl);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.UnameLbl);
            this.panel1.Controls.Add(this.showPw);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.signUp);
            this.panel1.Controls.Add(this.clear);
            this.panel1.Controls.Add(this.loginBtn);
            this.panel1.Controls.Add(this.pwTb);
            this.panel1.Controls.Add(this.unameTb);
            this.panel1.Location = new System.Drawing.Point(82, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 342);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // errorLbl
            // 
            this.errorLbl.AutoSize = true;
            this.errorLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorLbl.ForeColor = System.Drawing.Color.Red;
            this.errorLbl.Location = new System.Drawing.Point(47, 238);
            this.errorLbl.Name = "errorLbl";
            this.errorLbl.Size = new System.Drawing.Size(0, 16);
            this.errorLbl.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // UnameLbl
            // 
            this.UnameLbl.AutoSize = true;
            this.UnameLbl.BackColor = System.Drawing.Color.Transparent;
            this.UnameLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UnameLbl.Location = new System.Drawing.Point(76, 60);
            this.UnameLbl.Name = "UnameLbl";
            this.UnameLbl.Size = new System.Drawing.Size(78, 16);
            this.UnameLbl.TabIndex = 1;
            this.UnameLbl.Text = "Username";
            // 
            // showPw
            // 
            this.showPw.AutoSize = true;
            this.showPw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.showPw.ForeColor = System.Drawing.Color.DodgerBlue;
            this.showPw.Location = new System.Drawing.Point(156, 204);
            this.showPw.Name = "showPw";
            this.showPw.Size = new System.Drawing.Size(115, 17);
            this.showPw.TabIndex = 4;
            this.showPw.Text = "Show Password";
            this.showPw.UseVisualStyleBackColor = true;
            this.showPw.CheckedChanged += new System.EventHandler(this.showPw_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(68, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Don\'t have an account ?";
            // 
            // signUp
            // 
            this.signUp.AutoSize = true;
            this.signUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signUp.Location = new System.Drawing.Point(196, 312);
            this.signUp.Name = "signUp";
            this.signUp.Size = new System.Drawing.Size(52, 13);
            this.signUp.TabIndex = 3;
            this.signUp.Text = "Sign Up";
            this.signUp.Click += new System.EventHandler(this.signUp_Click);
            // 
            // clear
            // 
            this.clear.AutoSize = true;
            this.clear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clear.Font = new System.Drawing.Font("Impact", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clear.ForeColor = System.Drawing.Color.White;
            this.clear.Location = new System.Drawing.Point(96, 201);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(44, 20);
            this.clear.TabIndex = 3;
            this.clear.Text = "Clear";
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // loginBtn
            // 
            this.loginBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.loginBtn.Location = new System.Drawing.Point(105, 275);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(110, 34);
            this.loginBtn.TabIndex = 2;
            this.loginBtn.Text = "Login";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // pwTb
            // 
            this.pwTb.BackColor = System.Drawing.Color.DodgerBlue;
            this.pwTb.Font = new System.Drawing.Font("Microsoft JhengHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwTb.ForeColor = System.Drawing.Color.Black;
            this.pwTb.Location = new System.Drawing.Point(79, 154);
            this.pwTb.MaxLength = 20;
            this.pwTb.Name = "pwTb";
            this.pwTb.Size = new System.Drawing.Size(182, 27);
            this.pwTb.TabIndex = 1;
            this.pwTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pwTb.UseSystemPasswordChar = true;
            // 
            // unameTb
            // 
            this.unameTb.BackColor = System.Drawing.Color.DodgerBlue;
            this.unameTb.Font = new System.Drawing.Font("Microsoft YaHei UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unameTb.ForeColor = System.Drawing.Color.Black;
            this.unameTb.Location = new System.Drawing.Point(79, 79);
            this.unameTb.MaxLength = 30;
            this.unameTb.Name = "unameTb";
            this.unameTb.Size = new System.Drawing.Size(182, 27);
            this.unameTb.TabIndex = 1;
            this.unameTb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Impact", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(212, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.Color.Red;
            this.closeBtn.Location = new System.Drawing.Point(464, -1);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(36, 27);
            this.closeBtn.TabIndex = 6;
            this.closeBtn.Text = "❌";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(500, 600);
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.login_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox unameTb;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.TextBox pwTb;
        private System.Windows.Forms.CheckBox showPw;
        private System.Windows.Forms.Label clear;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label signUp;
        private System.Windows.Forms.Label UnameLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label errorLbl;
        private System.Windows.Forms.Button closeBtn;
    }
}

