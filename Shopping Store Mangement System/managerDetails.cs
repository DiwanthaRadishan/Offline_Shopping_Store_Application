using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping_Store_Mangement_System
{
    public partial class managerDetails : Form
    {

        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);

        private string uname;

        string imageLoaction;
        public managerDetails(string uname)
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


        public void Managerload_data()
        {
            try
            {
                cmd = new SqlCommand("SELECT UserName,password,profPic  FROM [ManagerTb] WHERE UserName = @uname", con);
                cmd.Parameters.AddWithValue("@uname", uname);
                DataTable dt = new DataTable();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                

                if (dt.Rows.Count > 0)
                {
                   
                    unameTb.Text = dt.Rows[0]["UserName"].ToString();
                    
                    passTb.Text = dt.Rows[0]["password"].ToString();
                    

                    if (dt.Rows[0]["profPic"] != DBNull.Value)
                    {
                        byte[] imagebytes = (byte[])dt.Rows[0]["profPic"];
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



        private void profilePicBox_Click(object sender, EventArgs e)
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
            catch (Exception ex)
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
                
               cmd = new SqlCommand("UPDATE [ManagerTb] SET profPic = @image WHERE UserName = @username", con);
               con.Open();
                cmd.Parameters.AddWithValue("image", image);
                cmd.Parameters.AddWithValue("username", uname);

                int k = cmd.ExecuteNonQuery();

                if (k > 0)
                {

                    MessageBox.Show("Picture Inserted Successfully");
                }
                else
                {
                    MessageBox.Show("Picture Not inserted ! ");
                }
            }
            catch (Exception ex)
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
            profilePicBox_Click(sender, e);
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {

            try
            {
                if ( String.IsNullOrEmpty(unameTb.Text) || String.IsNullOrEmpty(passTb.Text))
                {
                    MessageBox.Show("Complete all the required fields !");
                }
                else
                {

                    cmd = new SqlCommand("UPDATE [ManagerTb] SET  username = @UNAME , password = @PASS WHERE UserName = @uname", con);
                    cmd.Parameters.AddWithValue("UNAME", unameTb.Text);
                    cmd.Parameters.AddWithValue("PASS", passTb.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("   Your profile Updated Successfully !     ");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
                con.Close();
            }
        }

        private void managerDetails_Load(object sender, EventArgs e)
        {
            Managerload_data();
        }
    }
}
