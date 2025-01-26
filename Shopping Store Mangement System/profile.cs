using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping_Store_Mangement_System
{
    public partial class profile : Form
    {
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);

        private string uname;

        private bool custuser;
        private bool adminuser;
       



        string imageLoaction;
        public profile(string uname)
        {
            InitializeComponent();
            this.uname = uname;


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
        
        SqlDataAdapter sda;
        DataTable dt;
        SqlCommand cmd;


        public void userload_data()
        {
            try
            {
                cmd = new SqlCommand("SELECT Gmail,User_name,Tel_no,Password,Prof_Pic  FROM [UserTb1] WHERE User_name = @uname", con);
                cmd.Parameters.AddWithValue("@uname", uname);
                DataTable dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                custuser = true;

                if (dt.Rows.Count > 0)
                {
                    gmailTb.Text = dt.Rows[0]["Gmail"].ToString();
                    unameTb.Text = dt.Rows[0]["User_name"].ToString();
                    telnoTb.Text = dt.Rows[0]["Tel_no"].ToString();
                    passTb.Text = dt.Rows[0]["Password"].ToString();
                    //profilePicBox.Image = dt.Rows[0]["Prof_Pic"];

                    if (dt.Rows[0]["Prof_Pic"] != DBNull.Value)
                    {
                        byte[] imagebytes = (byte[])dt.Rows[0]["Prof_Pic"];
                        MemoryStream ms = new MemoryStream(imagebytes);
                        profilePicBox.Image = Image.FromStream(ms);
                        profilePicBox.BackgroundImageLayout = ImageLayout.Zoom;
                    }
                }
                else
                {
                    MessageBox.Show("No data found for the given username.", "Data Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void adminload_data()
        {
            try
            {
                cmd = new SqlCommand("SELECT gmail,username,telno,password,Prof_Pic  FROM [ADMINTB] WHERE username = @uname", con);
                cmd.Parameters.AddWithValue("@uname", uname);
                DataTable dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                adminuser = true;

                if (dt.Rows.Count > 0)
                {
                    gmailTb.Text = dt.Rows[0]["gmail"].ToString();
                    unameTb.Text = dt.Rows[0]["username"].ToString();
                    telnoTb.Text = dt.Rows[0]["telno"].ToString();
                    passTb.Text = dt.Rows[0]["password"].ToString();

                    if (dt.Rows[0]["Prof_Pic"] != DBNull.Value)
                    {
                        byte[] imagebytes = (byte[])dt.Rows[0]["Prof_Pic"];
                        MemoryStream ms = new MemoryStream(imagebytes);
                        profilePicBox.Image = Image.FromStream(ms);
                        profilePicBox.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                }
                else
                {
                    MessageBox.Show("No data found for the given username.", "Data Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            /* if(adminuser)
             {
                 Store_mangement store_Mangement = new Store_mangement(uname);
                 store_Mangement.setVisibale(false);
                 store_Mangement.Show();
                 this.Close();
             } */
            /* else
             {
                 /*shopping_store shopping_Store = new shopping_store(uname);
                 shopping_Store.Show();
                 this.Close();
             }*/
            this.Close();

        }

        private void profile_Load(object sender, EventArgs e)
        {

        }


        private void parameters()
        {
            cmd.Parameters.AddWithValue("GMAIL", gmailTb.Text);
            cmd.Parameters.AddWithValue("UNAME", unameTb.Text);
            cmd.Parameters.AddWithValue("TELLNO", telnoTb.Text);
            cmd.Parameters.AddWithValue("PASS", passTb.Text);
            
        }


        private void updateBtn_Click(object sender, EventArgs e)
        {


            try
            {
                if (String.IsNullOrEmpty(gmailTb.Text) || String.IsNullOrEmpty(unameTb.Text) || String.IsNullOrEmpty(telnoTb.Text) || String.IsNullOrEmpty(passTb.Text) )
                {
                    MessageBox.Show("Complete all the required fields !");
                }
                else
                {                                             
                   
                    if (adminuser)
                    {
                       
                        cmd = new SqlCommand("UPDATE [ADMINTB] SET gmail = @GMAIL , username = @UNAME , telno = @TELLNO , password = @PASS WHERE username = @uname" , con);
                        parameters();
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("   Your profile Updated Successfully !     ");
                    }
                    else
                    {//Gmail,User_name,Tel_no,Password  FROM 
                        cmd = new SqlCommand("UPDATE [UserTb1] SET Gmail = @GMAIL , User_name = @UNAME , Tel_no = @TELLNO , Password = @PASS WHERE User_name = @uname", con);
                        parameters();
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("    Your profile Updated Successfully !    ");
                    }                  
                                                                       
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                con.Close();
            }
           
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "Image file (*.png; *.jpg; *.jpeg;) | *.png; *.jpg; *.jpeg;";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imageLoaction = ofd.FileName.ToString();
                    profilePicBox.ImageLocation = imageLoaction;
                    profilePicBox.BackgroundImageLayout = ImageLayout.Stretch;
    
                    AddPicture();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void AddPicture()
        {
            try
            {
                byte[] image = null;
                FileStream stream = new FileStream(imageLoaction, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(stream);
                image = br.ReadBytes((int)stream.Length);
                if(custuser == true)
                {
                    cmd = new SqlCommand("UPDATE [UserTb1] SET Prof_Pic = @image WHERE User_name = @username", con);
                }
                else
                {
                    cmd = new SqlCommand("UPDATE [ADMINTB] SET Prof_Pic = @image WHERE username = @username", con);
                }
                con.Open();
                cmd.Parameters.AddWithValue("image",image);
                cmd.Parameters.AddWithValue("username", uname);

                int k = cmd.ExecuteNonQuery();

                if (k > 0)
                {

                    MessageBox.Show("Picture Inserted Successfully");
                }
                else
                {
                    MessageBox.Show("Picture Not inserted ! " );
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();              
            }
        }





        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1_Click(sender, e);
        }


    }
}
