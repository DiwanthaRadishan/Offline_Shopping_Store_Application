using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping_Store_Mangement_System
{
    public partial class Add_Admin : Form
    {
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);


        private string uname;
        public Add_Admin(string uname)
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
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataTable dt;



        private void load_data()
        {
            try
            {
                cmd = new SqlCommand("SELECT * FROM [ADMINTB]", con);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                dt = new DataTable();
                dt.Clear();
                sda.Fill(dt);
                adminDataGridView.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        private void Nclear()
        {
            adminidTb.Text = gmailTb.Text = unameTb.Text = gmailTb.Text = telNoTb.Text = pwTb.Text = "";
        }


        



        private void parameters()
        {
            cmd.Parameters.AddWithValue("ADMINID", adminidTb.Text);
            cmd.Parameters.AddWithValue("GMAIL", gmailTb.Text);
            cmd.Parameters.AddWithValue("UNAME", unameTb.Text);
            cmd.Parameters.AddWithValue("TELLNO", telNoTb.Text);
            cmd.Parameters.AddWithValue("PW", pwTb.Text);
        }


        

        private void Add_Admin_Load(object sender, EventArgs e)
        {
            load_data();
        }

        

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //String.IsNullOrEmpty(userIdTb.Text) || 
                if (String.IsNullOrEmpty(adminidTb.Text) || String.IsNullOrEmpty(gmailTb.Text) || String.IsNullOrEmpty(unameTb.Text) || String.IsNullOrEmpty(telNoTb.Text) || String.IsNullOrEmpty(pwTb.Text))
                {
                    MessageBox.Show("Complete all the required fields !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {                                                  //User_Id, @UID,
                    cmd = new SqlCommand("INSERT INTO [ADMINTB] (adminID, gmail, username, telno, password) VALUES (@ADMINID,@GMAIL,@UNAME,@TELLNO,@PW)", con);
                    parameters();
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    load_data();
                    MessageBox.Show("   Record Inserted Successfully !     ", "Done", MessageBoxButtons.OK);
                    Nclear();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }




        private void RemoveBtn_Click(object sender, EventArgs e)
        {
        try
        {
            if (String.IsNullOrEmpty(adminidTb.Text) || String.IsNullOrEmpty(gmailTb.Text) || String.IsNullOrEmpty(unameTb.Text) || String.IsNullOrEmpty(telNoTb.Text) || String.IsNullOrEmpty(pwTb.Text))
            {
                MessageBox.Show("No field selected to delete !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                cmd = new SqlCommand("DELETE FROM [ADMINTB] WHERE adminID = @ADMINID", con);
                parameters();
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                load_data();
                MessageBox.Show("   Record deleted Successfully !     ",  "Done !", MessageBoxButtons.OK);
                Nclear();
            }
        }
        catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(adminidTb.Text) || String.IsNullOrEmpty(gmailTb.Text) || String.IsNullOrEmpty(unameTb.Text) || String.IsNullOrEmpty(telNoTb.Text) || String.IsNullOrEmpty(pwTb.Text))
                {
                    MessageBox.Show("Complete all the required fields !","Warning !",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {                                               
                    cmd = new SqlCommand("UPDATE [ADMINTB] SET  adminID = @ADMINID, gmail = @GMAIL, username = @UNAME, telno = @TELLNO , password = @PW WHERE adminID = @ADMINID ", con);
                    parameters();
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    load_data();
                    MessageBox.Show("   Record Updated Successfully !     " ,"Done !",MessageBoxButtons.OK);
                    Nclear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }





        /*private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }*/



        private void SearchBtn_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT * FROM [ADMINTB] WHERE adminID LIKE @SEARCH + '%' OR gmail LIKE @SEARCH + '%' OR username LIKE @SEARCH + '%' OR telno LIKE @SEARCH + '%'", con);
            cmd.Parameters.AddWithValue("SEARCH", searchTb.Text);
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            dt = new DataTable();
            dt.Clear();
            sda.Fill(dt);
            adminDataGridView.DataSource = dt;
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
        }

        

        private void adminDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
               int index;
                index = e.RowIndex;
                DataGridViewRow selectedRow = adminDataGridView.Rows[index];
                adminidTb.Text = selectedRow.Cells[0].Value.ToString();
                gmailTb.Text = selectedRow.Cells[1].Value.ToString();
                unameTb.Text = selectedRow.Cells[2].Value.ToString();
                telNoTb.Text = selectedRow.Cells[3].Value.ToString();
                pwTb.Text = selectedRow.Cells[4].Value.ToString();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            /*Store_mangement store_Mangement = new Store_mangement(uname);
            store_Mangement.Show();*/
            this.Close();
        }
    }
}
