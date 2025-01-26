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
    public partial class ToReview : Form
    {
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);


        private int userid;
        private int orderId;

        public ToReview( int userid, int orderId)
        {
            this.userid = userid;
            this.orderId = orderId;
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



        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveFeedback_Click(object sender, EventArgs e)
        {
            try
            {
                if (feedbackTb.Text == null)
                {
                    MessageBox.Show("Feedback feild is empty !", "Notice !", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    cmd = new SqlCommand("UPDATE [CompletedTb] SET feedback = @feedback WHERE userid = @userid AND order_id = @orderid", con);
                    cmd.Parameters.AddWithValue("feedback", feedbackTb.Text);
                    cmd.Parameters.AddWithValue("userid", userid);
                    cmd.Parameters.AddWithValue("orderid", orderId);
                    con.Open();
                    int k = cmd.ExecuteNonQuery();
                    if (k > 0)
                    {
                        MessageBox.Show("Thank for your valuable response  !", "Thank You !", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("your response not saved  !", "Oops", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
           
        }
    }
}
