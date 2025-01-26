using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Shopping_Store_Mangement_System
{
    public partial class Create_Acount : Form
    {

        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);

        public Create_Acount()
        {
            InitializeComponent();

            this.MouseDown += login_MouseDown;
            this.MouseMove += login_MouseMove;
            this.MouseUp += login_MouseUp;
        }


        private void login_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                startPoint = new Point(e.X, e.Y);
            }
        }

        private void login_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentScreenPos = PointToScreen(e.Location);
                this.Location = new Point(currentScreenPos.X - startPoint.X, currentScreenPos.Y - startPoint.Y);
            }
        }

        private void login_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }















       SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""|DataDirectory|\inventory_db.mdf"";Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;

        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""|DataDirectory|\inventory_db.mdf"";Integrated Security=True");
        //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""|DataDirectory|\inventory_db.mdf"";Integrated Security=True");
        private void parameters()
        {
            cmd.Parameters.AddWithValue("@uname", unameTb.Text);
            cmd.Parameters.AddWithValue("@telno", telNoTb.Text);
            cmd.Parameters.AddWithValue("@gmail", gmailTb.Text);
            cmd.Parameters.AddWithValue("@pw", pwTb.Text);
            
        }

        private void Nclear()
        {
            unameTb.Text = telNoTb.Text = gmailTb.Text = pwTb.Text = confirmPwTb.Text = "";
        }

        private void createAccBtn_Click(object sender, EventArgs e)
        {
            if (gmailTb.Text == "" || unameTb.Text == "" || telNoTb.Text == "")
            {
                errorLbl.Text = "You must Fill all the field";
            }
            else if (pwTb.Text == "")
            {
                errorLbl.Text = "You must enter a password";
            }
            else if (confirmPwTb.Text == "")
            {
                errorLbl.Text = "Re-enter your password";
            }
            else if(pwTb.Text != confirmPwTb.Text)
            {
                errorLbl.Text = "Password Deosn't match";
            }
            
            else
            {
                //if dala acc eka database eken check krnna one thiyenwd kiyala
                try
                {
                    cmd = new SqlCommand("SELECT COUNT(*) FROM [UserTb1] WHERE User_name = @uname OR Tel_no = @telno OR Gmail = @gmail",con);
                    parameters();
                    con.Open();
                    int readCount = (int)cmd.ExecuteScalar();
                    con.Close();

                    if (readCount > 0)
                    {
                        errorLbl.Text = "User already exists !";
                    }
                    else
                    {
                        cmd = new SqlCommand("INSERT INTO [UserTb1]  ( User_name, Tel_no, Gmail, Password) VALUES (@uname,@telno,@gmail,@pw)", con);
                        parameters();
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        Nclear();
                        errorLbl.Text = "";
                        MessageBox.Show("Your Account is Created ! \n login now. " ,"SuccessFully created an Account" , MessageBoxButtons.OK , MessageBoxIcon.Information);

                        login login = new login();
                        login.Show();
                        this.Close();
                    }



                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                    con.Close();
                }
            }
        }

        private void Create_Acount_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }




        private void showPw_CheckedChanged(object sender, EventArgs e)
        {
            if(showPw.Checked == true ) 
            {
                pwTb.UseSystemPasswordChar = false;
                confirmPwTb.UseSystemPasswordChar = false;
            }
            else
            {
                pwTb.UseSystemPasswordChar = true;
                confirmPwTb.UseSystemPasswordChar= true;
            }
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Close();
        }
    }
}
