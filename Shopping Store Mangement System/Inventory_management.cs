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
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics.Tracing;
using static System.Net.Mime.MediaTypeNames;



namespace Shopping_Store_Mangement_System
{
    public partial class Inventory_management : Form
    {

        private bool isDragging = false;
        private Point startPoint = new Point(0, 0);


        private string uname;

        string imageLoaction;
        public Inventory_management(string uname)
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



        private void load_data()
        {
            try
            {
                cmd = new SqlCommand("SELECT * FROM [ItemTb]", con);
                sda = new SqlDataAdapter();
                sda.SelectCommand = cmd;
                dt = new DataTable();
                dt.Clear();
                sda.Fill(dt);
                itemDataGrid.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Nclear()
        {
            itemNoTb.Text = itemNameTb.Text = categoryTb.Text = quantityTb.Text =  priceTb.Text = descriptionTb.Text = discountTb.Text = "";
        }



        private void Inventory_management_Load(object sender, EventArgs e)
        {
            load_data();
        }

        private void itemDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            itemDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            int index;
            index = e.RowIndex;
            

            if (e.RowIndex >= 0)
            {
          
                DataGridViewRow selectedRow = itemDataGrid.Rows[index];
                itemNoTb.Text = selectedRow.Cells[0].Value.ToString();
                itemNameTb.Text = selectedRow.Cells[1].Value.ToString();
                categoryTb.Text = selectedRow.Cells[2].Value.ToString();
                quantityTb.Text = selectedRow.Cells[3].Value.ToString();
                priceTb.Text = selectedRow.Cells[4].Value.ToString();
                descriptionTb.Text = selectedRow.Cells[5].Value.ToString();
                discountTb.Text = selectedRow.Cells[6].Value.ToString();

                itemimg.Image = null;
                if (selectedRow.Cells[7].Value != DBNull.Value)
                {
                    byte[] imgbytes = (byte[])selectedRow.Cells[7].Value;
                    MemoryStream stream = new MemoryStream(imgbytes);
                    itemimg.Image = System.Drawing.Image.FromStream(stream);
                    itemimg.BackgroundImageLayout = ImageLayout.Zoom;
                }
            }        

        }

        private void parameters()
        {
            cmd.Parameters.AddWithValue("ITEMNO", itemNoTb.Text);
            cmd.Parameters.AddWithValue("ITEMNAME", itemNameTb.Text);
            cmd.Parameters.AddWithValue("CATEGORY", categoryTb.Text);
            cmd.Parameters.AddWithValue("QUANTITY", quantityTb.Text);
            cmd.Parameters.AddWithValue("PRICE", priceTb.Text);
            cmd.Parameters.AddWithValue("DESCRIPTION", descriptionTb.Text);
            cmd.Parameters.AddWithValue("DISCOUNT", discountTb.Text);
        }







        private void RemoveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(itemNameTb.Text) || String.IsNullOrEmpty(categoryTb.Text) || String.IsNullOrEmpty(quantityTb.Text) || String.IsNullOrEmpty(priceTb.Text) || String.IsNullOrEmpty(descriptionTb.Text) || String.IsNullOrEmpty(discountTb.Text))
                {
                    MessageBox.Show("No field selected to delete !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    cmd = new SqlCommand("DELETE FROM [itemTb] WHERE item_no = @ITEMNO", con);
                    parameters();
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    load_data();
                    MessageBox.Show("   Record deleted Successfully !     ", "Done", MessageBoxButtons.OK);
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
                if (String.IsNullOrEmpty(itemNameTb.Text) || String.IsNullOrEmpty(categoryTb.Text) || String.IsNullOrEmpty(quantityTb.Text) || String.IsNullOrEmpty(priceTb.Text) || String.IsNullOrEmpty(descriptionTb.Text) || String.IsNullOrEmpty(discountTb.Text))
                {
                    MessageBox.Show("Complete all the required fields !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {                                             //item_no = @ITEMNO ,
                    cmd = new SqlCommand("UPDATE [itemTb] SET  item_name = @ITEMNAME , category = @CATEGORY , quantity = @QUANTITY , price = @PRICE , description = @DESCRIPTION , discount = @DISCOUNT WHERE item_no = @ITEMNO" , con);
                    parameters();
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                                                      
                    insertImage();//insert the picure to db

                    load_data();
                    Nclear();
                    MessageBox.Show("   Record Updated Successfully !     ", "Done", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
        }





        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //String.IsNullOrEmpty(itemNoTb.Text) || 
                if (String.IsNullOrEmpty(itemNameTb.Text) || String.IsNullOrEmpty(categoryTb.Text) || String.IsNullOrEmpty(quantityTb.Text) || String.IsNullOrEmpty(priceTb.Text) || String.IsNullOrEmpty(descriptionTb.Text) || String.IsNullOrEmpty(discountTb.Text))

                {
                    MessageBox.Show("Complete all the required fields !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {                                                  
                    cmd = new SqlCommand("INSERT INTO [itemTb] (item_name, category, quantity, price, description, discount) VALUES (@ITEMNAME, @CATEGORY, @QUANTITY, @PRICE, @DESCRIPTION, @DISCOUNT)", con);
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


        private void searchBtn_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("SELECT * FROM [itemTb] WHERE item_no LIKE @SEARCH + '%' OR item_name LIKE @SEARCH + '%' OR category LIKE @SEARCH + '%' OR description LIKE  '%' + @SEARCH + '%'", con);
            cmd.Parameters.AddWithValue("SEARCH", searchTb.Text);
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            dt = new DataTable();
            dt.Clear();
            sda.Fill(dt);
            itemDataGrid.DataSource = dt;
        }




       /*rivate void closeBtn_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }*/

        private void homeBtn_Click(object sender, EventArgs e)
        {
            /*Store_mangement store_Mangement = new Store_mangement(uname);
            store_Mangement.setVisibale(false);
            store_Mangement.Show();*/
            this.Close();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("DBCC CHECKIDENT ('itemTb', RESEED, 0)", con);
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

        private void addimgbtn_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "Image file (*.png; *.jpg; *.jpeg;) | *.png; *.jpg; *.jpeg;)";

                if(dlg.ShowDialog() == DialogResult.OK)
                {
                    imageLoaction = dlg.FileName.ToString();
                    itemimg.ImageLocation = imageLoaction;
                    //itemimg.BackgroundImage = null;
                    itemimg.BackgroundImageLayout = ImageLayout.Zoom;                   
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void insertImage()
        {
            try
            {
                if (imageLoaction != null)
                {
                    byte[] image = null;
                    FileStream stream = new FileStream(imageLoaction, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(stream);
                    image = br.ReadBytes((int)stream.Length);

                    cmd = new SqlCommand("Update [itemTb] SET item_pic = @pic WHERE item_no = @itemno", con);
                    cmd.Parameters.AddWithValue("itemno", itemNoTb.Text);
                    cmd.Parameters.AddWithValue("pic", image);
                    con.Open();
                    int k = cmd.ExecuteNonQuery();

                    if (k > 0)
                    {

                        MessageBox.Show("Picture Inserted Successfully", "Done", MessageBoxButtons.OK);
                    }
                    else
                    {
                        MessageBox.Show("Picture Not inserted ! ", "Try again", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void removeimgbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(itemimg.Image != null)
                {
                    cmd = new SqlCommand("Update [itemTb] SET item_pic = Null WHERE item_no = @itemno", con);
                    cmd.Parameters.AddWithValue("itemno", itemNoTb.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("  Item image removed ", "Done", MessageBoxButtons.OK);

                    load_data();
                    Nclear();

                }
                else
                {
                    MessageBox.Show("  Please select an item from the item table to remove image", "No images to remove!",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch( Exception ex )
            {
                MessageBox.Show(ex.Message, "Error !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
