using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace Furniture
{
    public partial class AdminS : Form
    {
        public AdminS()
        {
            InitializeComponent();
        }

        private void BtnMaterial_Click(object sender, EventArgs e)
        {
            string name = txtMaterial.Text.ToString().ToLower();
            string connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();

            string upit = "SELECT * FROM material";
            OracleCommand comm = new OracleCommand(upit, conn);
            OracleDataAdapter da = new OracleDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Boolean check = true;

            foreach (DataRow materials in dt.Rows)
            {
                if (name == materials["name"].ToString().ToLower())
                {
                    materialErr.Text = "That material is already added";
                    check = false;
                    break;
                }
            }

            if (String.IsNullOrEmpty(txtMaterial.Text))
            {
                materialErr.Text = "You must enter a material";
                check = false;
            }

            if (name.Length > 20)
            {
                materialErr.Text = "That name is too long";
                check = false;
            }

            if (check)
            {
                upit = "INSERT INTO material VALUES((select max(id)+1 from material),'" + name + "')";
                comm = new OracleCommand(upit, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                materialErr.Text = "";
                MessageBox.Show("Successfully added!");
            }
        }

        private void BtnProducer_Click(object sender, EventArgs e)
        {
            string name = txtProducer.Text.ToString();
            string connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();

            string upit = "SELECT * FROM company";
            OracleCommand comm = new OracleCommand(upit, conn);
            OracleDataAdapter da = new OracleDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Boolean check = true;

            foreach (DataRow producers in dt.Rows)
            {
                if (name == producers["name"].ToString().ToLower())
                {
                    producerErr.Text = "That producer is already added";
                    check = false;
                    break;
                }
            }

            if (String.IsNullOrEmpty(txtProducer.Text))
            {
                producerErr.Text = "You must enter a producer";
                check = false;
            }

            if (name.Length > 20)
            {
                producerErr.Text = "That name is too long";
                check = false;
            }

            if (check)
            {
                upit = "INSERT INTO company VALUES((select max(id)+1 from material),'" + name + "')";
                comm = new OracleCommand(upit, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                producerErr.Text = "";
                MessageBox.Show("Successfully added!");
            }
        }
    }
}
