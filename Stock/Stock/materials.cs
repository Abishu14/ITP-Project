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
namespace Stock
{
    public partial class materials : Form
    {
      //  SqlConnection con;
        public materials()
        {
            InitializeComponent();
        }
        

      SqlConnection con = new SqlConnection("Data Source=LAPTOP-FHF1FD24;Initial Catalog=KSL;Integrated Security=True");
     // SqlCommand command = new SqlCommand();
     

        string MaterialID = "MD";
        //AutoGenerate MaterialID
        public void GenerateAutoID()
        {
          //  con = connection.Activecon();
          con.Open();
            SqlCommand cmd = new SqlCommand("Select Count(Material_ID) from Materials_Stock", con);
            int i = Convert.ToInt32(cmd.ExecuteScalar());
           
            i++;
            lableID.Text = MaterialID + i.ToString();
            con.Close();


        }


private void button1_Click(object sender, EventArgs e)
{
this.Hide();
Stock sb1 = new Stock();
sb1.Show();
}

private void textBox1_TextChanged(object sender, EventArgs e)
{

}

private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
{

}

private void button2_Click(object sender, EventArgs e)
{

}

private void button7_Click(object sender, EventArgs e)
{

}

private void tabPage1_Click(object sender, EventArgs e)
{

}

private void button9_Click(object sender, EventArgs e)
{

}

private void tabPage1_Click_1(object sender, EventArgs e)
{

}

private void button6_Click(object sender, EventArgs e)
{
this.Hide();
Stock h1 = new Stock();
h1.Show();
}

private void panel2_Paint(object sender, PaintEventArgs e)
{

}

private void panel1_Paint(object sender, PaintEventArgs e)
{

}

private void label1_Click(object sender, EventArgs e)
{

}

private void label3_Click(object sender, EventArgs e)
{

}

private void button31_Click(object sender, EventArgs e)
{

}

private void button32_Click(object sender, EventArgs e)
{
this.Hide();
Received re = new Received();
re.ShowDialog();
}

private void button33_Click(object sender, EventArgs e)
{
this.Hide();
Supply su = new Supply();
su.ShowDialog();
}

private void button34_Click(object sender, EventArgs e)
{
this.Hide();
Return re = new Return();
re.ShowDialog();

}

private void label4_Click(object sender, EventArgs e)
{

}

private void label5_Click(object sender, EventArgs e)
{

}

private void label6_Click(object sender, EventArgs e)
{

}

private void label7_Click(object sender, EventArgs e)
{

}

private void label8_Click(object sender, EventArgs e)
{

}

private void button2_Click_1(object sender, EventArgs e)
{

}

private void textBox1_TextChanged_1(object sender, EventArgs e)
{

}

private void button9_Click_1(object sender, EventArgs e)
{

}

private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
{

}

private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
{

}

private void panel3_Paint(object sender, PaintEventArgs e)
{

}

private void textBox2_TextChanged(object sender, EventArgs e)
{

}

private void textBox3_TextChanged(object sender, EventArgs e)
{

}

private void button7_Click_1(object sender, EventArgs e)
{

}

private void button8_Click(object sender, EventArgs e)
{

}

private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
{

}

private void textBox4_TextChanged(object sender, EventArgs e)
{

}

private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
{

}


    //Materials Maintanance
    //Add materials
    private void button2_Click_2(object sender, EventArgs e)
    {
            AddMaterials_Stock();
           // MaterialGridView();
            GenerateAutoID();

        }

    
       public void AddMaterials_Stock()
        {

            if ( string.IsNullOrEmpty(cmbMaterialType.Text)  || string.IsNullOrEmpty(cmb_MaterialName.Text) || string.IsNullOrEmpty(textQty.Text) || string.IsNullOrEmpty(txtDqty.Text) || string.IsNullOrEmpty(comboUnit.Text) || string.IsNullOrEmpty(textUPrice.Text))
            {
                MessageBox.Show("One or more Fields are Empty..!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
             
            }

            else
            {
                con.Open();
                int mkQ = Convert.ToInt32(textQty.Text);
                int dmQ = Convert.ToInt32(txtDqty.Text);
                if (mkQ > dmQ)
                {
                   // connection.Activecon();
                   // con.Open();
                    string q = "Insert into Materials_Stock(Material_Type,Material_Name,Stored_Date,Quantity,Damage_Quantity,Unit,Unit_Price,Available_StockQty)values('" + cmbMaterialType.Text + "','" + cmb_MaterialName.Text + "' ,'" + dtp_StoreDate.Value.ToString("yyyy-MM-dd") + "','" + textQty.Text + "','" + txtDqty.Text + "','" + comboUnit.Text + "','" + textUPrice.Text + "','" + textAQty.Text + "')";
                    SqlCommand com = new SqlCommand(q,con);
                    
                    com.ExecuteNonQuery();
                   
                    MessageBox.Show("Data Add Succed....!!!");
                }
                else
                {
                    MessageBox.Show("Materials Quanity must be Greater than Damage Quantity..!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Asterisk); 
                }
                con.Close();
            }
           MaterialGridView();


        }


        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }


        private void materials_Load(object sender, EventArgs e)
        {
            //command.Connection = con;
            GenerateAutoID(); 
            load_comboType();

        }

        //Calculate Available Stock Quantity

        public void Calculate_Available_Stock_Qty()
        {
            if (!(String.IsNullOrWhiteSpace(textQty.Text) && String.IsNullOrWhiteSpace(txtDqty.Text)))
            {
                int MaQ;
                int DQ;

                try
                {


                    MaQ = Convert.ToInt32(textQty.Text);
                    DQ = Convert.ToInt32(txtDqty.Text);


                    if (DQ < MaQ)
                    {
                        int Available_StockQty = (MaQ - DQ);
                        textAQty.Text = Available_StockQty.ToString();

                    }
                    else
                    {
                        MessageBox.Show("Damage Quantity must be less than Materials Quantity");
                    }

                }

                catch (Exception ms1)
                {
                    MessageBox.Show(ms1.Message);
                }
            }

        }


        //load type
        public void load_comboType()
            {
            try
            {
                cmbMaterialType.Items.Clear();
                con.Open();
                string query = "Select DISTINCT Material_Type from Material_New_Type";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmbMaterialType.Items.Add(dr["Material_Type"].ToString());
                }
                dr.Close();



            }
            catch (SqlException x)
            {
                MessageBox.Show(x.Message);
            }
            finally
            {
                con.Close();
            }
            }

        //load name
        public void load_comboName()
        {
            try
            {
                cmb_MaterialName.Items.Clear();
                con.Open();
                string query = "select Material_Name from Material_New_Type  where Material_Type = '" + cmbMaterialType.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    cmb_MaterialName.Items.Add(dr["Material_Name"].ToString());
                }
                dr.Close();
                //con.Close();


            }
            catch (SqlException x)
            {
                MessageBox.Show(x.Message);
            }

            finally
            {
                con.Close();
            }

        }

       


        //Update Materials

        private void button7_Click_2(object sender, EventArgs e)
        {
           UpdateMaterial_Stock();
            MaterialGridView();
            GenerateAutoID();
        }


       public void UpdateMaterial_Stock()

        {
            if (MessageBox.Show("Do you Want to Update This data ", "Update data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
                int mkQ = Convert.ToInt32(textQty.Text);
                int dmQ = Convert.ToInt32(txtDqty.Text);

                if (mkQ > dmQ)
                {

                    
                    //connection con = new connection();
                    SqlCommand cmd = new SqlCommand(@"UPDATE [Materials_Stock]
   SET [Material_Type] = '" + cmbMaterialType.Text + "',[Stored_Date] = '" + dtp_StoreDate.Value.ToString() + "',[Quantity] = '" + textQty.Text + "',[Damage_Quantity] = '" + txtDqty.Text + " ',[Unit] ='" + comboUnit.Text + "',[Unit_Price] = '" + textUPrice.Text + "',[Available_StockQty] = '" + textAQty.Text + "' WHERE [Material_Id] = '" + lableID.Text + "'",con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Materials Updated Sucessfully...!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    MaterialGridView();
                }
                else
                {
                    MessageBox.Show("Materials Quanity must be Greater than Damage Quantity..!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                
                
                    con.Close();
                

            }
            else
            {
                MessageBox.Show("Data not Updated", "Update Data", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
           // Materials_Clear_Stock();
            
        }

    //clear the Materials_Details
       public void Materials_Clear_Stock()
        {
           // lableID.Text = "";
            cmbMaterialType.SelectedIndex= -1;
            cmb_MaterialName.SelectedIndex = -1;
            dtp_StoreDate.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            textQty.Clear();
            txtDqty.Clear();
            comboUnit.SelectedIndex = -1 ;
            textUPrice.Clear();
            textAQty.Clear();
            dtp_StoreDate.Value = DateTime.Now;


        }

        //Clear Materials details in interface
        private void button8_Click_1(object sender, EventArgs e)
        {
            Materials_Clear_Stock();
          
            textSearch.Clear();
            

        }

        //Delete

        private void button11_Click(object sender, EventArgs e)
        {
            Delete_Materials_Stock();
            GenerateAutoID();
        }


        void Delete_Materials_Stock()
        {
            if (MessageBox.Show("Do you Want to Delete This data ", "Delete data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                con.Open();
              //  Sqlconnection con = new Sqlconnection();
                

                SqlDataAdapter sda = new SqlDataAdapter(@"Select * from [Materials_Stock] WHERE [Material_ID] = '" + lableID.Text + "'",con);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    SqlCommand cmd = new SqlCommand(@"UPDATE [Materials_Stock] SET status = 0 WHERE [Material_ID] = '" + lableID.Text + "'", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Materials Deleted Sucessfully...!", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    MaterialGridView();
                    buttonAdd.Enabled = false;
                    buttonUpdate.Enabled = false;
                    Materials_Clear_Stock();
                }
                else
                {
                    MessageBox.Show("No Company  Materials Selected for Remove...!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                con.Close();
            }

            else
            {
                MessageBox.Show("Data not remove", "Remove Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        //Search
        private void button10_Click(object sender, EventArgs e)
        {
            MaterialGridView();
            Materials_Search_Stock();
            GenerateAutoID();
        }

       public void Materials_Search_Stock()
        {
            if (string.IsNullOrEmpty(textSearch.Text))
            {
                MessageBox.Show("Please Enter the Material ID...!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                con.Open();
                String query = "Select Material_ID,Material_Type,Material_Name,Stored_Date,Quantity,Damage_Quantity,Unit,Unit_Price,Available_StockQty from Materials_Stock where [Material_ID] ='" + lableID.Text + "'";
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(query, con);

                sda.Fill(dt);
                MaterialView.DataSource = dt;
                con.Close();
            }

         }
               
            

        //Retrieve data from database
        //view all material details

        private void buttonView_Click(object sender, EventArgs e)
        {
            MaterialGridView();

           // UpdateMaterial_Stock();
        }

        public void MaterialGridView()
        {
            try
            {
                con.Open();
                String query = "Select Material_ID , Material_Type , Material_Name , Stored_Date , Quantity , Damage_Quantity, Unit , Unit_Price, Available_StockQty  from Materials_Stock where status = 1 ";
                DataTable dt = new DataTable();
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);

                sda.Fill(dt);
                MaterialView.DataSource = dt;
            }
            catch (Exception ex)
            {
               // MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
            

        }

        private void MaterialView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Material_StockGridView_MouseClick(object sender, MouseEventArgs e)
        {
            lableID.Text = MaterialView.CurrentRow.Cells[0].Value.ToString();
            cmbMaterialType.Text = MaterialView.CurrentRow.Cells[1].Value.ToString();
            cmb_MaterialName.Text = MaterialView.CurrentRow.Cells[2].Value.ToString();
            dtp_StoreDate.Text = MaterialView.CurrentRow.Cells[3].Value.ToString();
            textQty.Text = MaterialView.CurrentRow.Cells[4].Value.ToString();
            txtDqty.Text = MaterialView.CurrentRow.Cells[5].Value.ToString();
            comboUnit.Text = MaterialView.CurrentRow.Cells[6].Value.ToString();
            textUPrice.Text = MaterialView.CurrentRow.Cells[7].Value.ToString();
            textAQty.Text = MaterialView.CurrentRow.Cells[8].Value.ToString();

        }

      

        private void btnType_Click(object sender, EventArgs e)
        {
          
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void SelectedIndexChanged_Material_Type(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cm1 = new SqlCommand("select Material_Name from Material_New_Type  where Material_Type = '" + cmbMaterialType.Text + "'", con);
          cm1.ExecuteScalar();


      
            con.Close();

            load_comboName();
        }

        public void load_comboUnit()
        {
            try
            {
                comboUnit.Items.Clear();
                con.Open();
                string query = "select DISTINCT Unit from Material_New_Type  where Material_Name = '" + cmb_MaterialName.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    comboUnit.Items.Add(dr["Unit"].ToString());
                }
                dr.Close();
              //  con.Close();


            }
            catch (SqlException x)
            {
                MessageBox.Show(x.Message);
            }

            finally
            {
                con.Close();
            }
        }

        private void cmb_MaterialName_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cm1 = new SqlCommand("select DISTINCT Unit from Material_New_Type  where Material_Name = '" + cmb_MaterialName.Text + "'", con);
            cm1.ExecuteScalar();
            con.Close();

            load_comboUnit();
        }

        private void SelectedIndexChanged_ComboUnit(object sender, EventArgs e)
        {
           
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            MaterialGridView();
            BindingSource bs = new BindingSource();
            bs.DataSource = MaterialView.DataSource;

            bs.Filter = "Material_ID like '%" + textSearch.Text + "%' OR Material_Type like '"+ textSearch.Text +"' OR Material_Name like '"+ textSearch.Text +"'";

            MaterialView.DataSource = bs;
        }

        private void textQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtDqty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void textUPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtDqty_TextChanged(object sender, EventArgs e)
        {
            Calculate_Available_Stock_Qty();
        }
    }
}
