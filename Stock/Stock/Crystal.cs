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
using System.Configuration;

namespace Stock
{
    public partial class Crystal : Form
    {
     //   SqlConnection con;
        public Crystal()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-FHF1FD24;Initial Catalog=KSL;Integrated Security=True");
       // SqlCommand command = new SqlCommand();


        private void btnReport_Click(object sender, EventArgs e)
        {
            CrystalReport1 cr = new CrystalReport1();
            con.Open();
           // con = connection.Activecon();
            //SqlConnection con = new SqlConnection();

            //con.ConnectionString = ConfigurationManager.ConnectionStrings["Stock.Properties.Settings.KSLConnectionString"].ToString();

            String sql = "Select * from SupplyMaterialView";
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            adapter.Fill(ds, "SupplyMaterialView");
            DataTable dt = ds.Tables["SupplyMaterialView"];

            cr.SetDataSource(ds.Tables["SupplyMaterialView"]);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();

            con.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            CrystalReceived cr = new CrystalReceived();
            cr.Show();
            this.Hide();
        //    Stock s = new Stock();
        //    s.Show();
        //    this.Hide();
        }

        private void textShow_TextChanged(object sender, EventArgs e)
        {
            CrystalReport1 cr = new CrystalReport1();
           // con = connection.Activecon();
            con.Open();
            String sql = "Select * from SupplyMaterialView where Supply_Id = '" +textShow.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            adapter.Fill(ds, "SupplyMaterialView");
            DataTable dt = ds.Tables["SupplyMaterialView"];
            
            cr.SetDataSource(ds.Tables["SupplyMaterialView"]);
            crystalReportViewer1.ReportSource = cr;
            crystalReportViewer1.Refresh();
            con.Close();
            // bs.Filter = "Supply_Id like '%" + text_Supply_Search.Text + "%' OR ProjectId like '" + text_Supply_Search.Text + "'";

            // SupplyView.DataSource = bs;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            textShow.Clear();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Stock s = new Stock();
            s.Show();
            this.Hide();
        }

        private void btnMaterials_Click(object sender, EventArgs e)
        {
            materials m = new materials();
            m.Show();
            this.Hide();
        }

        private void btnReceived_Click(object sender, EventArgs e)
        {
            Received re = new Received();
            re.Show();
            this.Hide();
        }

        private void btnSupply_Click(object sender, EventArgs e)
        {
            Supply s = new Supply();
            s.Show();
            this.Hide();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Return r = new Return();
            r.Show();
            this.Hide();
        }

        private void Crystal_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
