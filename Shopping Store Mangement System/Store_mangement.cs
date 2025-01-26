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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Shopping_Store_Mangement_System
{
    public partial class Store_mangement : Form
    {
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);


        private string adminName;
        public Store_mangement(string uname)
        {
            InitializeComponent();
            adminName = uname;


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


        private void Inventory_mangement_Load(object sender, EventArgs e)
        {
            loadpic();
            Managerloadpic();


        }

        public void setVisibale (bool isvisible)
        {
            AddNewAdminBtn.Visible = isvisible;
            managerdetails.Visible = isvisible;
            managerdetailslbl.Visible = isvisible;
           // UserMangementBtn.Location = new Point(612, 131);
            ordersHistoryBtn.Location = new Point(612, 234);
        }

        public void hideFromOwner(bool ishide)
        {
            pictureBox1.Visible = ishide;
            label4.Visible = ishide;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logOutBtn_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Close();
        }

        public void loadpic()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Prof_Pic  FROM [ADMINTB] WHERE username = @uname", con);
                cmd.Parameters.AddWithValue("@uname", adminName);
                con.Open();
                object result = cmd.ExecuteScalar();              
                con.Close();

                if (result != null && result != DBNull.Value)
                {
                    byte[] imgbytes = (byte[])result;
                    MemoryStream ms = new MemoryStream(imgbytes);                   
                    pictureBox1.Image = Image.FromStream(ms);
                    
                }
                else
                {
                   // pictureBox1.Image = null; 
                   // MessageBox.Show("No image found for the given username.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void inventoryMangementBtn_Click(object sender, EventArgs e)
        {
           
            Inventory_management inventory = new Inventory_management(adminName);
            inventory.Show();
            //this.Hide();
           
        }

        private void UserMangementBtn_Click(object sender, EventArgs e)
        {
            User_management user = new User_management(adminName);
            user.Show();
            //this.Hide();
        }

        private void orderBtn_Click(object sender, EventArgs e)
        {
            Order_management order = new Order_management(adminName);
            order.Show();
            //this.Hide();
        }

        private void AddNewAdminBtn_Click(object sender, EventArgs e)
        {
            Add_Admin add_Admin = new Add_Admin(adminName);
            add_Admin.Show();
            //this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            profile profile = new profile(adminName);
            profile.adminload_data();
            profile.Show();
            //this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            profile profile = new profile(adminName);
            profile.adminload_data();
            profile.Show();
            //this.Hide();
        }

        private void ordersHistoryBtn_Click(object sender, EventArgs e)
        {
           OrderHistory orderHistory = new OrderHistory(adminName);
            orderHistory.Show();         
            //this.Hide();
        }

        private void managerdetails_Click(object sender, EventArgs e)
        {
            managerDetails mangerdetails = new managerDetails(adminName);
            mangerdetails.Managerload_data();
            mangerdetails.Show();
        }

        private void managerdetailslbl_Click(object sender, EventArgs e)
        {
            managerdetails_Click(sender, e);
        }


        public void Managerloadpic()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT profPic  FROM [ManagerTb] WHERE UserName = @uname", con);
                cmd.Parameters.AddWithValue("@uname", adminName);
                con.Open();
                object result = cmd.ExecuteScalar();
                con.Close();

                if (result != null && result != DBNull.Value)
                {
                    byte[] imgbytes = (byte[])result;
                    MemoryStream ms = new MemoryStream(imgbytes);
                    managerdetails.Image = Image.FromStream(ms);

                }
                else
                {
                    // pictureBox1.Image = null; 
                    // MessageBox.Show("No image found for the given username.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
    }
}
