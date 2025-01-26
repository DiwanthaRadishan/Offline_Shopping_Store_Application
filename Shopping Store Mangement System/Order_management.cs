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
    public partial class Order_management : Form
    {
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);


        private string uname;
        public Order_management(string uname)
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

        private void homeBtn_Click(object sender, EventArgs e)
        {
            /*Store_mangement store_Mangement = new Store_mangement(uname);
            store_Mangement.setVisibale(false);
            store_Mangement.Show();*/
            this.Close();
        }

        private void Order_management_Load(object sender, EventArgs e)
        {
            LoadOrderTb();
        }

       

        private void LoadOrderTb()
        {
            try
            {
                cmd = new SqlCommand("SELECT Order_Id , User_Id,Order_Date,Status , Total_Amount  FROM [ORDERTB]", con);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                dt = new DataTable();
                dt.Clear();
                sda.Fill(dt);
                OrderDatagrid.DataSource = dt;
                //OrderDatagrid.Columns["Order_Id"].Visible = false;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        int orderid;

        private void OrderDatagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                OrderDatagrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (e.RowIndex >= 0)
                {
                

                    int index;
                    index = e.RowIndex;
                    DataGridViewRow selectedRow = OrderDatagrid.Rows[index];
                    orderidTb1.Text = selectedRow.Cells[0].Value.ToString();
                    orderidTb2.Text = selectedRow.Cells[0].Value.ToString();
                    orderid = Convert.ToInt32(orderidTb1.Text);

                    UseridTB.Text = selectedRow.Cells[1].Value.ToString();
                    dateTb.Text = selectedRow.Cells[2].Value.ToString();

                    ordersttsTb.Text = selectedRow.Cells[3].Value.ToString();
                    OrderStatus.Text = selectedRow.Cells[3].Value.ToString();

                    totalTb.Text = selectedRow.Cells[4].Value.ToString();

                    LoadOrderItems();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void LoadOrderItems()
        {
            try
            {
                cmd = new SqlCommand("SELECT Order_Item_Id , item_no , quantity , price   FROM [ORDERITEMTB] WHERE Order_Id = @id", con);
                cmd.Parameters.AddWithValue("id", orderid);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                dt = new DataTable();
                dt.Clear();
                sda.Fill(dt);
                OrderItemDataGrid.DataSource = dt;
                OrderItemDataGrid.Columns["Order_Item_Id"].Visible = false;



                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void updateOrderStatus_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("UPDATE [ORDERTB] SET Status = @status WHERE Order_Id = @id", con);
                cmd.Parameters.AddWithValue("status", OrderStatus.Text);
                cmd.Parameters.AddWithValue("id", orderid);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();


                LoadOrderTb();

                /*if(OrderStatus.Text == "Delivered")
                {
                    completedBtn_Click(sender, e);
                }*/
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();   
        }*/


        List<string> itemlist = new List<string>();
        string itemsSold;

        private void MakeItemList()
        {
            try
            {
               

                cmd = new SqlCommand("SELECT itemTb.item_name , ORDERITEMTB.quantity FROM [itemTb] INNER JOIN [ORDERITEMTB] ON itemTb.item_no = ORDERITEMTB.item_no WHERE ORDERITEMTB.Order_Id = @orderid ",con);
                cmd.Parameters.AddWithValue("orderid", orderid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    string productName = reader["item_name"].ToString();
                    string quantity = reader["quantity"].ToString();

                    itemlist.Add($"{productName}\t \t \t {quantity}  \n");
                }
                reader.Close();
                con.Close();
                itemsSold = string.Join("\n ",itemlist);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void completedBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (orderidTb1.Text != "")
                {
                    if (ordersttsTb.Text == "Delivered" || ordersttsTb.Text == "Canceled")
                    {

                        MakeItemList();

                        cmd = new SqlCommand("INSERT INTO [CompletedTb] (userid, order_date , total_amount, items_sold,order_notes,order_id)  VALUES (@userid,@date,@total,@items,@notes,@orderid)  ", con);
                        cmd.Parameters.AddWithValue("userid", UseridTB.Text);
                        cmd.Parameters.AddWithValue("date", dateTb.Text);
                        cmd.Parameters.AddWithValue("total", totalTb.Text);
                        cmd.Parameters.AddWithValue("items", itemsSold);
                        cmd.Parameters.AddWithValue("notes", OrderStatus.Text);
                        cmd.Parameters.AddWithValue("orderid", orderid);

                        con.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Order completed and added it to CompletedTb successfully.","SuccessFully Added !",MessageBoxButtons.OK);
                        }
                        else
                        {
                            MessageBox.Show("Failed to complete the order.","Error Occured",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        }
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("You cannot complete the the order. \n Order is not  delivered yet.","Failed to complete the order !",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Select an order from Order list before complete !","Notice !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error !",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }













        //wadk nh,,,,,,,,,,,,,,,,,,,,,,,,,
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Orders_Click(object sender, EventArgs e)
        {

        }

        private void totalTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void OrderItemDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void OrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       
    }
}
