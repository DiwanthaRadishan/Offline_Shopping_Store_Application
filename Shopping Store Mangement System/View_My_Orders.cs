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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace Shopping_Store_Mangement_System
{
    public partial class View_My_Orders : Form
    {
        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);


        int userid;
        int orderId;
        public View_My_Orders(int userid)
        {
            InitializeComponent();
            this.userid = userid;


            cancleOrderBtn.MouseHover += new EventHandler(cancleOrderBtn_MouseHover);
            cancleOrderBtn.MouseLeave += new EventHandler(cancleOrderBtn_MouseLeave);

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

        private void ShowMyOrders()
        {
            try
            {
                cmd = new SqlCommand("SELECT Order_Id , Order_Date , Status , Total_Amount FROM [ORDERTB] WHERE User_Id = @userid", con);
                cmd.Parameters.AddWithValue("userid",userid);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                dt = new DataTable();
                dt.Clear();
                sda.Fill(dt);
                viewMyOrdersDataGrid.DataSource = dt;
                con.Close();

                if (viewMyOrdersDataGrid.Rows.Count == 0)
                {
                    viewMyOrdersDataGrid.Visible = false;
                    cancleorderLbl.Text = "No Orders Found !";
                    cancleorderLbl.Location = new Point(200, 140);
                    cancleorderLbl.ForeColor = Color.Black;
                    cancleorderLbl.BackColor = Color.Red;
                    cancleorderLbl.Font = new Font(cancleorderLbl.Font.FontFamily, 20,FontStyle.Bold);
                    recievedbtn.Visible = false;
                    cancleOrderBtn.Visible = false;
                    itemlistlb.Visible = false;
                    detailslbl.Visible = false;
                    
                    //MessageBox.Show("No orders found.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void View_My_Orders_Load(object sender, EventArgs e)
        {
            ShowMyOrders();
            resetorder.Visible = false;
            itemlistTb.Visible = false;
            subtotalLb.Visible = false;
            subtotalTb.Visible = false;
            detailslbl.Visible = false;


            itemlistlb.Text = "Select a row to view Ordered Items. ";
        }


        
        private void recievedbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (viewMyOrdersDataGrid.SelectedRows.Count > 0)
                {
                    //viewMyOrdersDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    var selectedrow = viewMyOrdersDataGrid.SelectedRows[0];
                    string orderstatus = selectedrow.Cells["Status"].Value.ToString();

                    if (orderstatus != "Pending" && orderstatus != "Order confirmed" && orderstatus != "Order processing" && orderstatus != "Shipped" && orderstatus != "Canceled")
                    {


                        DialogResult result = MessageBox.Show("Do you really received the order ? ", "Confirmation !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        
                        if (result == DialogResult.Yes)
                        {
                            ToReview toReview = new ToReview(userid, orderId);
                            //toReview.Show();                            
                            DialogResult rslt = toReview.ShowDialog();

                            if (rslt == DialogResult.Yes)
                            {
                                MessageBox.Show("yessss");
                            }
                            else
                            {
                                removeFromOrderItemTb();
                                removeFromOrderTb();
                                ShowMyOrders();
                                //MessageBox.Show("Doneeeeeeeeeeeeeeeeee!");
                            }

                            itemlistTb.Visible = false;
                            itemlistlb.Visible = false;
                            detailslbl.Visible = false;
                            subtotalLb.Visible = false;
                            subtotalTb.Visible = false;

                        }


                    }
                    else
                    {
                       // recievedbtn.Enabled = false;
                        MessageBox.Show("Still You Haven't recieved the order !");

                    }
                }
                else
                {
                    MessageBox.Show("Please select a row .", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }




        //cancle button pressed
        private void cancleOrderBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Do you really want cancel this Order ? ", "Confirmation !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                    viewMyOrdersDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    if (viewMyOrdersDataGrid.SelectedRows.Count > 0)
                    {
                        var selectedrow = viewMyOrdersDataGrid.SelectedRows[0];
                        string orderstatus = selectedrow.Cells["Status"].Value.ToString();

                        if (orderstatus != "Shipped" && orderstatus != "Delivered")
                        {

                            foreach (DataGridViewRow row in viewMyOrdersDataGrid.SelectedRows)
                            {
                                if (!row.IsNewRow)
                                {
                                    //viewMyOrdersDataGrid.Rows.Remove(row);   waguwen data ain krnwa database ekem Iin wenne nh
                                    UpdateItemTb();
                                    removeFromOrderItemTb();
                                    removeFromOrderTb();

                                    ShowMyOrders();

                                    MessageBox.Show("Selected Order removed ", "Done !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    itemlistTb.Visible = false;
                                    itemlistlb.Visible = false;
                                    detailslbl.Visible = false;
                                    subtotalLb.Visible = false;
                                    subtotalTb.Visible = false;
                                    

                                }
                            }
                        }
                        else
                        {
                            //cancleOrderBtn.Enabled = false;
                            MessageBox.Show(" You cannot Cancle order now ! ");

                        }

                    }
                    else
                    {
                        MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //remove order from order table
        private void removeFromOrderTb()
        {
            try
            {
                cmd = new SqlCommand("DELETE FROM [ORDERTB] WHERE  User_Id = @userid And Order_Id = @orderid", con);
                cmd.Parameters.AddWithValue("userid", userid);
                cmd.Parameters.AddWithValue("orderid", orderId);
                con.Open();
                int k = cmd.ExecuteNonQuery();
                if (k > 0)
                {
                    //MessageBox.Show("record  deleted from order tb  !");
                    
                }
                else
                {
                    MessageBox.Show("reocred  cant deleted from order tb !");
                }
                con.Close();
                //MessageBox.Show("Selected Order removed ", "Done !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }

        //remove from orderitem table
        private void removeFromOrderItemTb()
        {
            try
            {
                cmd = new SqlCommand("DELETE FROM [ORDERITEMTB] WHERE  Order_Id = @orderid", con);
                cmd.Parameters.AddWithValue("orderid", orderId);
                con.Open();
                int k = cmd.ExecuteNonQuery();
                if (k > 0)
                {
                    //MessageBox.Show("record  deleted from order tb  !");

                }
                else
                {
                    MessageBox.Show("reocred  cant deleted from order tb !");
                }
                con.Close();
                //MessageBox.Show("Selected Order removed ", "Done !", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        //update the item table after cancle a order
        private void UpdateItemTb()
        {
            try
            {
                con.Open();
                List<(int itemId, int quantity)> orderItems = new List<(int itemId, int quantity)>();

                cmd = new SqlCommand("SELECT item_no, quantity FROM [ORDERITEMTB] WHERE Order_Id = @orderid", con);
                cmd.Parameters.AddWithValue("orderid", orderId);

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int itemId = reader.GetInt32(0);
                    int quantity = reader.GetInt32(1);
                    orderItems.Add((itemId, quantity));
                }
                reader.Close();

                foreach (var items in orderItems)
                {
                    int itemid = items.itemId;
                    int itemquantity = items.quantity;

                    cmd = new SqlCommand("SELECT quantity FROM [itemTb] WHERE item_no = @itemno", con);
                    cmd.Parameters.AddWithValue("itemno", itemid);
                    int avaQuantity = Convert.ToInt32(cmd.ExecuteScalar());

                    if (avaQuantity < itemquantity)
                    {
                        throw new Exception($"Insufficient stock for ItemNo: {itemid}. Available: {avaQuantity}, Required: {itemquantity}");
                    }

                    //if not an error,  update  
                    int newQuantity = avaQuantity + itemquantity;
                    SqlCommand cmd2 = new SqlCommand("UPDATE [itemTb] SET quantity = @quantity WHERE item_no = @itemno", con);
                    cmd2.Parameters.AddWithValue("itemno", itemid);
                    cmd2.Parameters.AddWithValue("quantity", newQuantity);
                    cmd2.ExecuteNonQuery();

                }

                

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        //mouse hover
        private void cancleOrderBtn_MouseHover(object sender, EventArgs e)
        {
            
            cancleorderLbl.Text = " Select a Row and press delete button !";
        }
        private void cancleOrderBtn_MouseLeave(object sender, EventArgs e)
        {
            cancleorderLbl.Text = "";
        }


        //get order id

        
        private void viewMyOrdersDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0)
                {
                    itemlistTb.Visible = true;
                    subtotalLb.Visible = true;
                    subtotalTb.Visible = true;
                    detailslbl.Visible = true;
                    itemlistTb.Text = "";
                    itemlistlb.Text = "Ordered Items";

                    List<string> itemlist = new List<string>();

                    viewMyOrdersDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    DataGridViewRow selectedRow = viewMyOrdersDataGrid.Rows[e.RowIndex];
                    orderId = Convert.ToInt32(selectedRow.Cells["Order_Id"].Value);

                    cmd = new SqlCommand("SELECT itemTb.item_name, ORDERITEMTB.quantity, ORDERITEMTB.price, ORDERTB.Total_Amount FROM [itemTb] INNER JOIN [ORDERITEMTB] ON  itemTb.item_no = ORDERITEMTB.item_no INNER JOIN [ORDERTB] ON ORDERITEMTB.Order_Id = ORDERTB.Order_Id WHERE ORDERTB.Order_Id = @orderid", con);
                    cmd.Parameters.AddWithValue("orderid", orderId);
                    con.Open();
                    string totalPrice;



                    SqlDataReader reader = cmd.ExecuteReader();                   
                    while (reader.Read())
                    {
                        string itemName = reader["item_name"].ToString();
                        string quantity = reader["quantity"].ToString();
                        string itemPrice = reader["price"].ToString();
                        totalPrice = reader["Total_Amount"].ToString();
                        subtotalTb.Text = totalPrice;

                        itemlist.Add($"{itemName} \t \t  {quantity} \t {itemPrice}\n");

                    }

                    reader.Close();
                    con.Close();

                    itemlistTb.Text = string.Join("\n ",itemlist);

                   
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                 con.Close();
            }
        }







        //reset the number
        private void resetorder_Click(object sender, EventArgs e)
        {
           
           
           

            try
            {
                cmd = new SqlCommand("DBCC CHECKIDENT('ORDERTB', RESEED, 0)", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Identity column reseeded to start from 1.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }


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

        private void OrderHistoryBtn_Click(object sender, EventArgs e)
        {
            User_order_history user_Order_History = new User_order_history(userid);
            user_Order_History.Show();
        }
    }


    
}
