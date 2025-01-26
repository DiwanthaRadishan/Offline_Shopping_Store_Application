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
    public partial class OrderHistory : Form
    {
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);


        string uname;
        public OrderHistory(string uname)
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


        private void OrderHistory_Load(object sender, EventArgs e)
        {
            loadCompletedTable();
            itemlistlb.Visible = false;
            itemlistLbl.Visible = false;
        }

        private void loadCompletedTable()
        {
            try
            {
                cmd = new SqlCommand("SELECT *  FROM [CompletedTb]", con);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                dt = new DataTable();
                dt.Clear();
                sda.Fill(dt);
                orderHistoryDatagrid.DataSource = dt;      
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void orderHistoryDatagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                orderHistoryDatagrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                if (e.RowIndex >= 0)
                {
      
                    int index;
                    index = e.RowIndex;
                    DataGridViewRow selectedRow = orderHistoryDatagrid.Rows[index];

                    itemlistlb.Visible = true;
                    itemlistLbl.Visible = true;

                    itemlistLbl.Text = selectedRow.Cells[4].Value.ToString();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       /*private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }*/

        private void homeBtn_Click(object sender, EventArgs e)
        {
           /* Store_mangement store_Mangement = new Store_mangement(uname);
            store_Mangement.setVisibale(false);
            store_Mangement.Show();*/
            this.Close();
        }

        private void resetid_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("DBCC CHECKIDENT ('CompletedTb', RESEED, 0)", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Identity column reseeded to start from 1.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void resetorderitemtb_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("DBCC CHECKIDENT('ORDERITEMTB', RESEED, 0)", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Identity column reseeded to start from 1.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
    }
}
