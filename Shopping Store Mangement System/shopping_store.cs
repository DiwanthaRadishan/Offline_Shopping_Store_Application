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
    public partial class shopping_store : Form
    {
        private string username;
        private int userid;
        private int cartid;

        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);

        public shopping_store(string data)
        {
            InitializeComponent();
            username = data;


            removeBtn.MouseHover += new EventHandler(removeBtn_MouseHover);
            removeBtn.MouseLeave += new EventHandler(removeBtn_MouseLeave);



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
        



        private void shopping_store_Load(object sender, EventArgs e)
        {
            load_data();
            loadCart();
            loadpic();
            resetcart.Visible = false;

        }

        public  void load_data()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT item_no , item_name,category,quantity,price,description,discount,item_pic  FROM [ItemTb]", con);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                dt = new DataTable();
                dt.Clear();
                sda.Fill(dt);
                itemlistdatagrid.DataSource = dt;
                itemlistdatagrid.Columns["item_no"].Visible = false;
                itemlistdatagrid.Columns["item_pic"].Visible = false;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void loadpic()
        {
            try
            {
                cmd = new SqlCommand("SELECT Prof_Pic  FROM [UserTb1] WHERE User_name = @uname", con);
                cmd.Parameters.AddWithValue("@uname", username);
                con.Open();
                object result = cmd.ExecuteScalar();
                con.Close() ;
                if (result != null && result != DBNull.Value) 
                {
                    byte[] imgbytes = (byte[])result;
                    MemoryStream ms = new MemoryStream(imgbytes);                   
                    profile.Image = Image.FromStream(ms);
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT * FROM [itemTb] WHERE item_no LIKE @SEARCH + '%' OR item_name LIKE @SEARCH + '%' OR category LIKE @SEARCH + '%' OR description LIKE  '%' + @SEARCH + '%'", con);
            cmd.Parameters.AddWithValue("SEARCH", searchTb.Text);
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            dt = new DataTable();
            dt.Clear();
            sda.Fill(dt);
            itemlistdatagrid.DataSource = dt;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        

        int itemno;

        private void itemlistdatagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                itemlistdatagrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                if (e.RowIndex >= 0)
                {
                

                    int index;
                    index = e.RowIndex;
                    DataGridViewRow selectedRow = itemlistdatagrid.Rows[index];
                    itemnameTb.Text = selectedRow.Cells[1].Value.ToString();
                    descriptionTb.Text = selectedRow.Cells[5].Value.ToString();
                    availablequantityTb.Text = selectedRow.Cells[3].Value.ToString();
                    itemno = (int)selectedRow.Cells[0].Value;

                    pictureBox.Image = null;
                    if (selectedRow.Cells[7].Value != DBNull.Value)
                    {
                        byte[] imgbytes = (byte[])selectedRow.Cells[7].Value;
                        MemoryStream stream = new MemoryStream(imgbytes);
                        pictureBox.Image = Image.FromStream(stream);
                        pictureBox.BackgroundImageLayout = ImageLayout.Zoom;
                    }

                    if ((int)selectedRow.Cells[3].Value <= 0)
                    {
                        quantityTb.Text = "0";
                        errorlbl.Text = "selected item, Out of stock";
                        addtocartTb.Visible = false;
                    }
                    else
                    {
                        addtocartTb.Visible = true;
                        quantityTb.Text = "1";
                        priceTb.Text = selectedRow.Cells[4].Value.ToString();
                        discountTb.Text = selectedRow.Cells[6].Value.ToString();

                        cal_amount();
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void cal_amount()
        {
            double price = double.Parse(priceTb.Text);
            double discount = double.Parse(discountTb.Text);
            int Quantity = int.Parse(quantityTb.Text);

            amountTb.Text = ((price * (100 - discount) / 100) * Quantity).ToString();
        }


        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int currentQuantity = int.Parse(quantityTb.Text);
                int maxQuantity = int.Parse(availablequantityTb.Text);
                if (currentQuantity < maxQuantity)
                {
                    quantityTb.Text = (currentQuantity + 1).ToString();
                    cal_amount();

                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void minBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int currentQuantity = int.Parse(quantityTb.Text);

                if (currentQuantity > 1)
                {
                    quantityTb.Text = (currentQuantity - 1).ToString();
                    cal_amount();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logout_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
            this.Close();
        }

        private void profile_Click(object sender, EventArgs e)
        {
            profile profile = new profile(username);
            profile.userload_data();
            profile.Show();
            //this.Hide();
        }

        private void profileLbl_Click(object sender, EventArgs e)
        {
            profile profile = new profile(username);
            profile.userload_data();
            profile.Show();
            //this.Hide();
        }



        private void addtocartTb_Click(object sender, EventArgs e)
        {
            try
            {
                if (quantityTb.Text != "")
                {
                    //insert records to cartitem table
                    cmd = new SqlCommand("INSERT INTO [CARTITEMTB] (Cart_Id,item_no,quantity,price) VALUES (@cartid,@itemno,@quantity,@total)", con);
                    cmd.Parameters.AddWithValue("cartid", cartid);
                    cmd.Parameters.AddWithValue("itemno", itemno);
                    cmd.Parameters.AddWithValue("quantity", quantityTb.Text);
                    cmd.Parameters.AddWithValue("total", amountTb.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Selected Item inserted into cart","Successfully Inserted",MessageBoxButtons.OK);
                    loadcartitemtable(cartid);
                }
                else
                {
                    MessageBox.Show("Please select and item form the Item List !","Notice",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }

        // load the cart when user login 
        private void loadCart()
        {
            try
            {
                getuserid();

                GetCartIdUsingUserid(userid);

                if (cartid == 0)
                {
                    //add new reocord to cart table using  user id
                    cmd = new SqlCommand("insert into [CARTTb] (User_Id) VALUES (@USERID)", con);
                    cmd.Parameters.AddWithValue("USERID", userid);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    //MessageBox.Show("user id inserted into cart table");
                    loadCart();
                }
                else
                {
                    loadcartitemtable(cartid);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //load cart items of the user 
        private void loadcartitemtable(int cartid)
        {

            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT  CARTITEMTB.Cart_Item_Id , ItemTb.item_name , CARTITEMTB.quantity  ,CARTITEMTB.price  FROM [ItemTb] , [CARTITEMTB] WHERE ItemTb.item_no = CARTITEMTB.item_no  AND CARTITEMTB.Cart_Id = @cartid", con);
                cmd.Parameters.AddWithValue("cartid", cartid);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                dt = new DataTable();
                dt.Clear();
                sda.Fill(dt);
                cartdatagrid.DataSource = dt;
                cartdatagrid.Columns["Cart_Item_Id"].Visible = false;

                con.Close();
                SubTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //get cart id  by using the user id
        private int GetCartIdUsingUserid(int userid)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Cart_Id FROM CARTTb WHERE User_Id = @userid", con);
                cmd.Parameters.AddWithValue("@userid", userid); // Corrected the parameter name
                object result = cmd.ExecuteScalar();
                cartid = result != null ? Convert.ToInt32(result) : 0; // If result is null, return 0
                //return cartid;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
                
            }
            return cartid;



        }

        //get user id from user table
        private int getuserid()
        {
            try
            {
                con.Open();

                cmd = new SqlCommand("SELECT User_Id  FROM [UserTb1] WHERE User_name = @uname", con);
                cmd.Parameters.AddWithValue("uname", username);
                userid = (int)cmd.ExecuteScalar();
                con.Close();
                return userid;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return userid;
            }
           
        }


        int cartitemid;       
        

        //remove item from cart
        private void removeBtn_Click(object sender, EventArgs e)
        {
            try
            {
                cartdatagrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                if (cartdatagrid.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in cartdatagrid.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            //cartdatagrid.Rows.Remove(row);   waguwen data ain krnwa database ekem Iin wenne nh
                            
                            cmd = new SqlCommand("DELETE FROM [CARTITEMTB] WHERE  Cart_Item_Id = @cartitemid", con);

                            // cmd.Parameters.AddWithValue("cartid",cartid); Cart_Id = @cartid AND

                            cmd.Parameters.AddWithValue("cartitemid", cartitemid);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                            MessageBox.Show("Selected Item deleted from cart","Done !", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            loadcartitemtable(cartid);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        
        private void cartdatagrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cartdatagrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                if (e.RowIndex >= 0)
                {
                
                    int index;
                    index = e.RowIndex;
                    DataGridViewRow selectedRow = cartdatagrid.Rows[index];
                    cartitemid = Convert.ToInt32(selectedRow.Cells[0].Value.ToString());
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        
        //mouse hover
        private void removeBtn_MouseHover(object sender, EventArgs e)
        {
            removelbl.Text = " Select a Row and press delete button !";
        }
        private void removeBtn_MouseLeave(object sender, EventArgs e)
        {
            removelbl.Text = ""; 
        }

        //find sub total
        private void SubTotal()
        {
            try
            {
                cmd = new SqlCommand("SELECT SUM(price) FROM [CARTITEMTB] WHERE Cart_Id = @cartid ",con);
                cmd.Parameters.AddWithValue("cartid", cartid);
                con.Open();
                object sub = cmd.ExecuteScalar();
                subtotalTb.Text = Convert.ToString(sub);

                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        
       

        //place the order
        private void placeorderBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Press Yes to  place the order ! ", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (cartdatagrid.RowCount == 0)//check cart is empty or not
                    {
                        MessageBox.Show("Your Cart is empty .\n Can't place the order !");
                    }
                    else
                    {
                        AddToOrderTb();
                        getOrderId();
                        AddToOrderItemTb();
                        updateItemTb();
                        removeItensFromCartItemTb();

                        load_data();
                        MessageBox.Show("Your Order is Placed successfully !", "Successfully added", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                 }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        DateTime ordertime;
        private void AddToOrderTb()
        {
            try
            {
                ordertime = DateTime.Now;
                con.Open();
                cmd = new SqlCommand("INSERT INTO [ORDERTB] (User_Id,Order_Date,Total_Amount) VALUES (@userid , @orderdate , @total) ", con);
                cmd.Parameters.AddWithValue("userid", userid);
                cmd.Parameters.AddWithValue("orderdate", ordertime);
                cmd.Parameters.AddWithValue("total", subtotalTb.Text);

                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
           
        }


        //get   orderid
        int orderid;
        private void getOrderId()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("SELECT Order_Id FROM [ORDERTB] WHERE User_Id = @userid AND Order_Date = @orderdate",con);
                cmd.Parameters.AddWithValue("userid", userid);
                cmd.Parameters.AddWithValue("orderdate", ordertime);
                orderid = (int)cmd.ExecuteScalar();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }





        private void AddToOrderItemTb()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("INSERT INTO [ORDERITEMTB] (Order_Id, item_no , quantity, price) SELECT @orderid , item_no , quantity , price FROM [CARTITEMTB] WHERE Cart_Id = @cartid ;  ", con);
                cmd.Parameters.AddWithValue("orderid", orderid);
                cmd.Parameters.AddWithValue("cartid", cartid);
                
                cmd.ExecuteNonQuery();
                con.Close();

                //MessageBox.Show("Your Order is Placed successfully !", "Successfully added");

                //VALUES (@orderid , @itemno , @quantity ,@price)
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }



        //update item table when placed a order
        public void updateItemTb()
        {
            try
            {
                con.Open();
                List<(int itemId, int quantity)> cartItems = new List<(int itemId, int quantity)>();

                cmd = new SqlCommand("SELECT item_no, quantity FROM [CARTITEMTB] WHERE Cart_Id = @cartid", con);
                cmd.Parameters.AddWithValue("cartid", cartid);

                

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int itemId = reader.GetInt32(0);
                    int quantity = reader.GetInt32(1);
                    cartItems.Add((itemId , quantity));
                }
                reader.Close();

                foreach(var items  in cartItems)
                {
                    int itemid = items.itemId;
                    int itemquantity = items.quantity;

                    cmd = new SqlCommand("SELECT quantity FROM [itemTb] WHERE item_no = @itemno",con);
                    cmd.Parameters.AddWithValue("itemno", itemid);
                    int avaQuantity = Convert.ToInt32(cmd.ExecuteScalar());

                    if (avaQuantity < itemquantity)
                    {
                        throw new Exception($"Insufficient stock for ItemNo: {itemid}. Available: {avaQuantity}, Required: {itemquantity}");
                    }

                    //if not an error, update 
                    int newQuantity = avaQuantity - itemquantity;
                    SqlCommand cmd2 = new SqlCommand("UPDATE [itemTb] SET quantity = @quantity WHERE item_no = @itemno", con);
                    cmd2.Parameters.AddWithValue("itemno", itemid);
                    cmd2.Parameters.AddWithValue("quantity", newQuantity);
                    cmd2.ExecuteNonQuery();
                    
                }
                con.Close();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }

        }



        //remove records from order item table when place the order
        private void removeItensFromCartItemTb()
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("DELETE FROM [CARTITEMTB] WHERE  Cart_Id = @cartid", con);
                cmd.Parameters.AddWithValue("cartid", cartid);
                
                cmd.ExecuteNonQuery();
                con.Close();
               
                loadcartitemtable(cartid);
            }
            catch( Exception ex )
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }



        private void viewMyOrdes_Click(object sender, EventArgs e)
        {
            View_My_Orders view_My_Orders = new View_My_Orders(userid);
            view_My_Orders.Show();

        }

       


        private void resetcart_Click(object sender, EventArgs e)
        {
            
               
                
            try
            {
                cmd = new SqlCommand("DBCC CHECKIDENT('CARTITEMTB', RESEED, 0)", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Identity column reseeded to start from 1.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }


            try
            {
                cmd = new SqlCommand("DBCC CHECKIDENT ('CARTTb', RESEED, 0)", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Identity column reseeded to start from 1.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }

        }

        private void clearchart_Click(object sender, EventArgs e)
        {
            removeItensFromCartItemTb();
            loadcartitemtable(cartid);
        }
    }

















    /*//get cartid from cart table
                int ccartid;
                cmd = new SqlCommand("SELECT Cart_Id FROM CARTTb where User_Id = @USERID",con);
                cmd.Parameters.AddWithValue("USERID", userid);
                con.Open();
                ccartid = (int)cmd.ExecuteScalar();
                con.Close();*/
}
