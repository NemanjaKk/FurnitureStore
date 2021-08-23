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
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
            //combo furnitures
            string connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();
            string upit = "SELECT id, name FROM furniture";
            OracleCommand comm = new OracleCommand(upit, conn);
            OracleDataAdapter da = new OracleDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboFurnitures.ValueMember = "id";
            comboFurnitures.DisplayMember = "name";
            comboFurnitures.DataSource = dt;
            conn.Close();

            //edit
            string id = comboFurnitures.SelectedValue.ToString();
            connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
            conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();
            upit = "SELECT f.name AS Name, c.name AS Producer,c.id AS producerId, m.name AS Material,m.id AS materialId,u.username AS Seller,u.id AS sellerId, f.price AS Price FROM furniture f,users u,material m,company c WHERE f.material = m.id AND f.company = c.id AND f.seller = u.id AND f.id = "+id;
            comm = new OracleCommand(upit, conn);
            da = new OracleDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            string name = dt.Rows[0]["Name"].ToString();
            string price = dt.Rows[0]["Price"].ToString();
            string seller = dt.Rows[0]["Seller"].ToString();
            string sellerId = dt.Rows[0]["sellerId"].ToString();
            string materialId = dt.Rows[0]["materialId"].ToString();
            string material = dt.Rows[0]["Material"].ToString();
            string producerId = dt.Rows[0]["producerId"].ToString();
            string producer = dt.Rows[0]["Producer"].ToString();

            txtName.Text = name;
            txtPrice.Text = price;
            txtSeller.Text = seller;

            //combo material
            connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
            conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();
            upit = "SELECT id, name FROM material";
            comm = new OracleCommand(upit, conn);
            da = new OracleDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            comboMaterial.ValueMember = "id";
            comboMaterial.DisplayMember = "name";
            comboMaterial.DataSource = dt;
            comboMaterial.SelectedValue = materialId;
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
            comboProducer.SelectedValue = producerId;
            conn.Close();
        }

        private void ComboFurnitures_SelectedIndexChanged(object sender, EventArgs e)
        {
            //edit
            string id = comboFurnitures.SelectedValue.ToString();
            string connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();
            string upit = "SELECT f.name AS Name, c.name AS Producer,c.id AS producerId, m.name AS Material,m.id AS materialId,u.username AS Seller,u.id AS sellerId, f.price AS Price FROM furniture f,users u,material m,company c WHERE f.material = m.id AND f.company = c.id AND f.seller = u.id AND f.id = " + id;
            OracleCommand comm = new OracleCommand(upit, conn);
            OracleDataAdapter da = new OracleDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string name = dt.Rows[0]["Name"].ToString();
            string price = dt.Rows[0]["Price"].ToString();
            string seller = dt.Rows[0]["Seller"].ToString();
            string sellerId = dt.Rows[0]["sellerId"].ToString();
            string materialId = dt.Rows[0]["materialId"].ToString();
            string producerId = dt.Rows[0]["producerId"].ToString();

            txtName.Text = name;
            txtPrice.Text = price;
            txtSeller.Text = seller;
            lblSellerId.Text = sellerId;

            //combo material
            connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
            conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();
            upit = "SELECT id, name FROM material";
            comm = new OracleCommand(upit, conn);
            da = new OracleDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            comboMaterial.ValueMember = "id";
            comboMaterial.DisplayMember = "name";
            comboMaterial.DataSource = dt;
            comboMaterial.SelectedValue = materialId;
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
            comboProducer.SelectedValue = producerId;
            conn.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Boolean check = true;
            string name = "";
            int price = -1;
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

            if (check)
            {
                string producer = comboProducer.SelectedValue.ToString();
                string material = comboMaterial.SelectedValue.ToString();
                string seller = lblSellerId.Text.ToString();
                string connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
                OracleConnection conn = new OracleConnection();
                conn.ConnectionString = connString;
                conn.Open();
                string upit = "UPDATE furniture SET name = '"+name+"',price="+price+", material="+material+", company="+producer+", seller="+seller+" WHERE id = "+seller;
                OracleCommand comm = new OracleCommand(upit, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully edited!");
                this.Close();
            }
        }
    }
}
