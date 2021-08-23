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
    public partial class Add : Form
    {
        public Add(string id)
        {
            InitializeComponent();
            lblId.Text = id;
            //combo material
            string connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();
            string upit = "SELECT id, name FROM material";
            OracleCommand comm = new OracleCommand(upit, conn);
            OracleDataAdapter da = new OracleDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboMaterial.ValueMember = "id";
            comboMaterial.DisplayMember = "name";
            comboMaterial.DataSource = dt;
            comboMaterial.SelectedItem = null;
            conn.Close();
            //combo producer
            connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
            conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();
            upit = "SELECT id, name FROM company";
            comm = new OracleCommand(upit, conn);
            da = new OracleDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            comboProducer.ValueMember = "id";
            comboProducer.DisplayMember = "name";
            comboProducer.DataSource = dt;
            comboProducer.SelectedItem = null;
            conn.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Boolean check = true;
            string name ="";
            int price=-1;
            string material = "";
            string producer = "";
            if (String.IsNullOrEmpty(txtPrice.Text))
            {
                priceErr.Text = "You must enter a price";
                check = false;
            }
            else
            {
                try
                {
                    price = Convert.ToInt32(txtPrice.Text.ToString());
                    priceErr.Text = "";
                }
                catch (FormatException)
                {
                    priceErr.Text = "You must enter a number";
                    check = false;
                }
            }

            if (String.IsNullOrEmpty(txtName.Text))
            {
                nameErr.Text = "You must enter a name";
                check = false;
            }
            else
            {
                if (txtName.Text.ToString().Length > 20)
                {
                    nameErr.Text = "That name is too long";
                    check = false;
                }
                else
                {
                    nameErr.Text = "";
                    name = txtName.Text.ToString();
                }
            }

            if (comboMaterial.SelectedItem == null)
            {
                materialErr.Text = "You must select a material";
                check = false;
            }
            else
            {
                materialErr.Text = "";
                material = comboMaterial.SelectedValue.ToString();
            }

            if (comboProducer.SelectedItem == null)
            {
                producerErr.Text = "You must select a producer";
                check = false;
            }
            else
            {
                producerErr.Text = "";
                producer = comboProducer.SelectedValue.ToString();
            }

            if (check)
            {
                string connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = connString;
                conn.Open();
                string upit = "INSERT INTO furniture VALUES((select max(id)+1 from furniture),'" + name + "'," + price + "," + material + "," + producer + "," + lblId.Text.ToString() +")";
                OracleCommand comm = new OracleCommand(upit, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                this.Close();
            }

        }
    }
}
