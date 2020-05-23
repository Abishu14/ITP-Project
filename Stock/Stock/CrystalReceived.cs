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
    public partial class CrystalReceived : Form
    {
       // SqlConnection con;
        
        public CrystalReceived()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-FHF1FD24;Initial Catalog=KSL;Integrated Security=True");
      //  SqlCommand command = new SqlCommand();

        private void btnReceivedReport_Click(object sender, EventArgs e)
        {
            CrystalReport2 cr = new CrystalReport2();
            con.Open();
            //con = connection.Activecon();
            //SqlConnection con = new SqlConnection();

            //con.ConnectionString = ConfigurationManager.ConnectionStrings["Stock.Properties.Settings.KSLConnectionString"].ToString();

            String sql = "Select * from ReceivedView";
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            adapter.Fill(ds, "ReceivedView");
            DataTable dt = ds.Tables["ReceivedView"];

            cr.SetDataSource(ds.Tables["ReceivedView"]);
            crystalReportViewer2.ReportSource = cr;
            crystalReportViewer2.Refresh();
            con.Close();
        }

        private void btnReceivedBack_Click(object sender, EventArgs e)
        {
            Stock s = new Stock();
            s.Show();
            this.Hide();
        }

        private void textReceivedShow_TextChanged(object sender, EventArgs e)
        {

            CrystalReport2 cr = new CrystalReport2();
         //   con = connection.Activecon();
            con.Open();
            String sql = "Select * from ReceivedView where Received_Id = '" + textReceivedShow.Text + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
            adapter.Fill(ds, "ReceivedView");
            DataTable dt = ds.Tables["ReceivedView"];

            cr.SetDataSource(ds.Tables["ReceivedView"]);
            crystalReportViewer2.ReportSource = cr;
            crystalReportViewer2.Refresh();
            con.Close();
        }

        private void btnReceivedClear_Click(object sender, EventArgs e)
        {
            textReceivedShow.Clear();
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
            Received r = new Received();
            r.Show();
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
            Return rt = new Return();
            rt.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Crystal c = new Crystal();
            c.Show();
            this.Hide();
        }

        private void CrystalReceived_Load(object sender, EventArgs e)
        {

        }
    }
}
