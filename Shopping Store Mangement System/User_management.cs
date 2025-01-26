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
using System.Security.Policy;

namespace Shopping_Store_Mangement_System
{
    public partial class User_management : Form
    {
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);


        private String uname;
        public User_management(string uname)
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


        private void homeBtn_Click(object sender, EventArgs e)
        {
            /*Store_mangement store_Mangement = new Store_mangement(uname);
            store_Mangement.setVisibale(false);
            store_Mangement.Show();*/
            this.Close();
        }



        private void User_management_Load(object sender, EventArgs e)
        {
            load_data();
            RemoveBtn.Visible = false;
        }

        private void load_data()
        {
            try
            {
                cmd = new SqlCommand("SELECT * FROM [UserTb1]", con);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                dt = new DataTable();
                dt.Clear();
                sda.Fill(dt);
                userDataGrid.DataSource = dt;
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
           userIdTb.Text = userNameTb.Text = tellNoTb.Text = gmailTb.Text =passTb.Text ="";
        }


        private void userDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            userDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (e.RowIndex >= 0)
            {
                int index;
                index = e.RowIndex;
                DataGridViewRow selectedRow = userDataGrid.Rows[index];
                userIdTb.Text = selectedRow.Cells[0].Value.ToString();
                userNameTb.Text = selectedRow.Cells[1].Value.ToString();
                tellNoTb.Text = selectedRow.Cells[2].Value.ToString();
                gmailTb.Text = selectedRow.Cells[3].Value.ToString();
                passTb.Text = selectedRow.Cells[4].Value.ToString();
            }
        }



        private void parameters()
        {
            cmd.Parameters.AddWithValue("UID",userIdTb.Text);
            cmd.Parameters.AddWithValue("UNAME", userNameTb.Text);
            cmd.Parameters.AddWithValue("TELLNO",tellNoTb.Text);
            cmd.Parameters.AddWithValue("GMAIL",gmailTb.Text);
            cmd.Parameters.AddWithValue("PASS",passTb.Text);
        }






        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //String.IsNullOrEmpty(userIdTb.Text) || 
                if (String.IsNullOrEmpty(userNameTb.Text) || String.IsNullOrEmpty(tellNoTb.Text) || String.IsNullOrEmpty(passTb.Text))
                {
                    MessageBox.Show("Complete all the required fields !","Notice !",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {                                                  //User_Id, @UID,
                    cmd = new SqlCommand("INSERT INTO [UserTb1] (User_name, Tel_no, Gmail, Password) VALUES (@UNAME,@TELLNO,@GMAIL,@PASS)", con);
                    parameters();
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    load_data();
                    MessageBox.Show("   Record Inserted Successfully !     ", "Done !" ,MessageBoxButtons.OK);
                    Nclear();
                }
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }





        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(userIdTb.Text) || String.IsNullOrEmpty(userNameTb.Text) || String.IsNullOrEmpty(tellNoTb.Text) || String.IsNullOrEmpty(passTb.Text))
                {
                    MessageBox.Show("Complete all the required fields !","Notice !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {                                               //User_Id = @UID,
                    cmd = new SqlCommand("UPDATE [UserTb1] SET  User_name = @UNAME, Tel_no=@TELLNO, Gmail = @GMAIL, Password = @PASS WHERE User_Id = @UID", con);
                    parameters();
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    load_data();
                    MessageBox.Show("   Record Updated Successfully !     ", "Done !" ,MessageBoxButtons.OK);
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
                if (String.IsNullOrEmpty(userIdTb.Text) || String.IsNullOrEmpty(userNameTb.Text) || String.IsNullOrEmpty(tellNoTb.Text) || String.IsNullOrEmpty(passTb.Text))
                {
                    MessageBox.Show("No field selected to delete !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cmd = new SqlCommand("DELETE FROM [UserTb1] WHERE User_Id = @UID", con);
                    parameters();
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    load_data();
                    MessageBox.Show("   Record deleted Successfully ! "  ,  " Done ! " ,MessageBoxButtons.OK);
                    Nclear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void SearchBtn_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT * FROM [UserTb1] WHERE User_Id LIKE @SEARCH + '%' OR User_name LIKE @SEARCH + '%' OR Tel_no LIKE @SEARCH + '%' OR Gmail LIKE @SEARCH + '%'",con);
            cmd.Parameters.AddWithValue("SEARCH", searchTb.Text);
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            dt = new DataTable();   
            dt.Clear();
            sda.Fill(dt);
            userDataGrid.DataSource = dt;
            
        }




        /*private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }*/

        private void showPw_CheckedChanged(object sender, EventArgs e)
        {
            if(showPw.Checked == true)
            {
                passTb.UseSystemPasswordChar = false;
            }
            else
            {
                passTb.UseSystemPasswordChar = true;
            }
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("DBCC CHECKIDENT ('UserTb1', RESEED, 0)", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Identity column reseeded to start from 1.");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





    }



    //UserId INT IDENTITY(1,1) PRIMARY KEY,     ---table eka hdana thanata

    /*cmd = new SqlCommand("DBCC CHECKIDENT ('UserTb1', RESEED, 0)", con);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();*/



    //ekk withark adu krnn nm idntity ain krla delete ekata yrin dannna
    /*cmd = new SqlCommand("UPDATE UserTb1 SET UserId = UserId - 1 WHERE UserId > @ID", con);
        cmd.Parameters.AddWithValue("@ID", idToDelete);
        con.Open();
        cmd.ExecuteNonQuery();
        con.Close();*/
}