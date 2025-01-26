using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace Shopping_Store_Mangement_System
{
    public partial class login : Form
    {
        private bool isDragging = false;
        private Point startPoint = new Point(0,0);

        public login()
        {
            InitializeComponent();

            this.MouseDown += login_MouseDown;
            this.MouseMove += login_MouseMove;
            this.MouseUp += login_MouseUp;
        }

        private void login_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
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
        SqlCommand cmd1;
        SqlCommand cmd2;
        SqlCommand cmd3;
        SqlDataAdapter sda;
        DataTable dt;



        private void parameters1()
        {
            cmd1.Parameters.AddWithValue("@uname", unameTb.Text);
            cmd1.Parameters.AddWithValue("@pw", pwTb.Text);
        }

        private void parameters2()
        {
            cmd2.Parameters.AddWithValue("@uname", unameTb.Text);
            cmd2.Parameters.AddWithValue("@pw", pwTb.Text);
        }

        private void parameters3()
        {
            cmd3.Parameters.AddWithValue("@uname", unameTb.Text);
            cmd3.Parameters.AddWithValue("@pw", pwTb.Text);
        }

        private void Nclear()
        {
            unameTb.Text = pwTb.Text = "";
            errorLbl.Text = "";
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            try
            {
                 string username = unameTb.Text;

                if (unameTb.Text == "")
                {
                    errorLbl.Text = "Username is required ! ";
                    con.Close();
                }
                else if (pwTb.Text == "")
                {
                    errorLbl.Text = "Password is required ! ";
                    con.Close();
                }
                else
                {
                    con.Open();
                    // COLLATE Latin1_General_BIN    used for  get casesensive data(WHERE BINARY User_name = @uname)
                    cmd1 = new SqlCommand("SELECT COUNT(*) FROM [UserTb1] WHERE User_name = @uname  COLLATE Latin1_General_BIN AND  Password = @pw  COLLATE Latin1_General_BIN ", con);
                    parameters1();

                    cmd2 = new SqlCommand("SELECT COUNT(*) FROM [ADMINTB] WHERE username = @uname  COLLATE Latin1_General_BIN AND  Password = @pw  COLLATE Latin1_General_BIN ", con);                   
                    parameters2();

                    cmd3 = new SqlCommand("SELECT COUNT(*) FROM [ManagerTb] WHERE username = @uname  COLLATE Latin1_General_BIN AND  Password = @pw  COLLATE Latin1_General_BIN ", con);
                    parameters3();

                    int readCount1 = (int)cmd1.ExecuteScalar();  //user
                    int readCount2 = (int)cmd2.ExecuteScalar(); //admin
                    int readCount3 = (int)cmd3.ExecuteScalar(); //manager
                    con.Close();
                    if (readCount1 > 0)
                    {                        

                        
                        MessageBox.Show("You are successfully logged in ! ", $"Hello  {username} !", MessageBoxButtons.OK);
                        
                        
                        shopping_store shoppingStore = new shopping_store(username);
                        shoppingStore.Show();
                        this.Hide();

                    }
                    else if(readCount2 > 0)
                    {
                        
                        
                        MessageBox.Show("You are successfully logged in ! ", $"Hello  {username} !", MessageBoxButtons.OK);
                       
                        
                        
                        Store_mangement storeMangement = new Store_mangement(username);
                        storeMangement.setVisibale(false);
                        storeMangement.Show();
                        this.Hide();



                    }
                    else if(readCount3 > 0)
                    {
                        MessageBox.Show("You are successfully logged in ! ", $"Hello  {username} !", MessageBoxButtons.OK);

                        Store_mangement storeMangement = new Store_mangement(username);
                        storeMangement.hideFromOwner(false);
                        storeMangement.Show();
                        this.Hide();
                    }
                    else
                    {
                        errorLbl.Text = "Invalid username or password.";
                        
                        con.Close();
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                con.Close();
            }
        }




        private void showPw_CheckedChanged(object sender, EventArgs e)
        {
            if (showPw.Checked == true)
            {
                pwTb.UseSystemPasswordChar = false;
            }
            else
            {
                pwTb.UseSystemPasswordChar = true;
            }

            //pwTb.UseSystemPasswordChar = !showPw.Checked;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            Nclear();
        }





        private void signUp_Click(object sender, EventArgs e)
        {
            Create_Acount create_Acount = new Create_Acount();
            create_Acount.Show();
            Visible = false;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void login_Load(object sender, EventArgs e)
        {

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
