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
    public partial class User_order_history : Form
    {
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);


        int userid;
        int orderid;

        public User_order_history(int userid)
        {
            this.userid = userid;
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
        SqlDataAdapter sda;
        DataTable dt;
        SqlCommand cmd;

        private void load_data()
        {
            try
            {
                cmd = new SqlCommand("SELECT  order_id, order_date, items_sold, total_amount, feedback,order_notes FROM [CompletedTb] WHERE userid = @userid", con);
                cmd.Parameters.AddWithValue("userid", userid);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                dt = new DataTable();
                dt.Clear();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();

                hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void User_order_history_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void hide()
        {
            itemlistTb.Visible = false;
            itemlbl.Visible = false;
            addfeddbackTb.Visible = false;
            addfeedbackBtn.Visible = false;
            label.Text = "Select a row to see more tetails";
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (e.RowIndex >= 0)
                {
                    

                    itemlistTb.Visible = true;
                    itemlbl.Visible = true;
                    label.Text = "Item List";

                    var selectedRow = dataGridView1.Rows[e.RowIndex];

                    string items = selectedRow.Cells["items_sold"].Value.ToString();
                    itemlistTb.Text = items;

                    orderid = (int)selectedRow.Cells["order_id"].Value;

                    string feedback = selectedRow.Cells["feedback"].Value.ToString();

                    if (feedback == "")
                    {
                        addfeddbackTb.Visible = true;
                        addfeedbackBtn.Visible = true;
                    }
                    else
                    {
                        addfeddbackTb.Visible = false;
                        addfeedbackBtn.Visible = false;
                    }
                }
                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        
    }

        private void addfeedbackBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (addfeddbackTb.Text != "")
                {
                    cmd = new SqlCommand("UPDATE [CompletedTb] SET feedback = @feedback WHERE userid = @userid AND order_id = @orderid", con);
                    cmd.Parameters.AddWithValue("feedback", addfeddbackTb.Text);
                    cmd.Parameters.AddWithValue("userid", userid);
                    cmd.Parameters.AddWithValue("orderid", orderid);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Thank you for valuable response. \n Your feedback is saved.", "Thank you !", MessageBoxButtons.OK);
                    load_data();
                }
                else
                {
                    MessageBox.Show("Feedback feild is empty", "Cannot save your feedback !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
