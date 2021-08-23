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
    public partial class Furniture : Form
    {
        public Furniture(String username)
        {
            InitializeComponent();
            lblUser.Text = username;

            string connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();

            string upit = "SELECT * FROM users WHERE username='"+username+"'";
            OracleCommand comm = new OracleCommand(upit, conn);
            OracleDataAdapter da = new OracleDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string id = dt.Rows[0]["id"].ToString();
            lblId.Text = id;
            conn.Close();

            if (username == "admin")
            {
                btnAdmin.Enabled = true;
                btnEdit.Enabled = true;
            }
            else
            {
                btnUser.Enabled = true;
            }

            connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
            conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();

            upit = "SELECT f.name AS Name, c.name AS Producer, m.name AS Material,u.username AS Seller, f.price AS Price FROM furniture f,users u,material m,company c WHERE f.material = m.id AND f.company = c.id AND f.seller = u.id";
            comm = new OracleCommand(upit, conn);
            da = new OracleDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

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

        private void Furniture_Load(object sender, EventArgs e)
        {

        }

        private void BtnAdmin_Click(object sender, EventArgs e)
        {
            AdminS a = new AdminS();
            a.Show();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Edit ed = new Edit();
            ed.Show();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Add a = new Add(lblId.Text.ToString());
            a.Show();
        }

        private void BtnUser_Click(object sender, EventArgs e)
        {
            UserSettings us = new UserSettings(lblId.Text.ToString());
            us.Show();
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            string connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();

            string upit = "SELECT f.name AS Name, c.name AS Producer, m.name AS Material,u.username AS Seller, f.price AS Price FROM furniture f,users u,material m,company c WHERE f.material = m.id AND f.company = c.id AND f.seller = u.id";
            if (!String.IsNullOrEmpty(txtName.Text.ToString()))
            {
                upit += " AND lower(f.name) LIKE '"+ txtName.Text.ToString().ToLower() + "%'";
            }

            if (comboMaterial.SelectedItem != null)
            {
                upit += " AND m.id = "+comboMaterial.SelectedValue;
            }

            if (comboProducer.SelectedItem != null)
            {
                upit += " AND c.id = " + comboProducer.SelectedValue;
            }

            OracleCommand comm = new OracleCommand(upit, conn);
            OracleDataAdapter da = new OracleDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            comboMaterial.SelectedItem = null;
            comboProducer.SelectedItem = null;
            string connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();
            string upit = "SELECT f.name AS Name, c.name AS Producer, m.name AS Material,u.username AS Seller, f.price AS Price FROM furniture f,users u,material m,company c WHERE f.material = m.id AND f.company = c.id AND f.seller = u.id";
            OracleCommand comm = new OracleCommand(upit, conn);
            OracleDataAdapter da = new OracleDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void ComboMaterial_SelectedValueChanged(object sender, EventArgs e)
        {
            string connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();

            string upit = "SELECT f.name AS Name, c.name AS Producer, m.name AS Material,u.username AS Seller, f.price AS Price FROM furniture f,users u,material m,company c WHERE f.material = m.id AND f.company = c.id AND f.seller = u.id";
            if (!String.IsNullOrEmpty(txtName.Text.ToString()))
            {
                upit += " AND lower(f.name) LIKE '" + txtName.Text.ToString().ToLower() + "%'";
            }

            if (comboMaterial.SelectedItem != null)
            {
                upit += " AND m.id = " + comboMaterial.SelectedValue;
            }

            if (comboProducer.SelectedItem != null)
            {
                upit += " AND c.id = " + comboProducer.SelectedValue;
            }

            OracleCommand comm = new OracleCommand(upit, conn);
            OracleDataAdapter da = new OracleDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void ComboProducer_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();

            string upit = "SELECT f.name AS Name, c.name AS Producer, m.name AS Material,u.username AS Seller, f.price AS Price FROM furniture f,users u,material m,company c WHERE f.material = m.id AND f.company = c.id AND f.seller = u.id";
            if (!String.IsNullOrEmpty(txtName.Text.ToString()))
            {
                upit += " AND lower(f.name) LIKE '" + txtName.Text.ToString().ToLower() + "%'";
            }

            if (comboMaterial.SelectedItem != null)
            {
                upit += " AND m.id = " + comboMaterial.SelectedValue;
            }

            if (comboProducer.SelectedItem != null)
            {
                upit += " AND c.id = " + comboProducer.SelectedValue;
            }

            OracleCommand comm = new OracleCommand(upit, conn);
            OracleDataAdapter da = new OracleDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
