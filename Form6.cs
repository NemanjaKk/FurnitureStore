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
    public partial class UserSettings : Form
    {
        public UserSettings(string id)
        {
            InitializeComponent();
            
            string connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();

            string upit = "SELECT * FROM users WHERE id = "+id;
            OracleCommand comm = new OracleCommand(upit, conn);
            OracleDataAdapter da = new OracleDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            txtUsername.Text = dt.Rows[0]["username"].ToString();
            txtPassword.Text = dt.Rows[0]["password"].ToString();
            lblId.Text = id;
            conn.Close();

            connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
            conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();

            upit = "SELECT f.id AS ID, f.name AS Name, c.name AS Producer, m.name AS Material,f.price AS Price FROM furniture f,users u,material m,company c WHERE f.material = m.id AND f.company = c.id AND f.seller = u.id AND f.seller = "+id;
            comm = new OracleCommand(upit, conn);
            da = new OracleDataAdapter(comm);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void BtnChange_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.ToString().ToLower();
            string password = txtPassword.Text.ToString().ToLower();

            string connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();

            string upit = "SELECT * FROM users";
            OracleCommand comm = new OracleCommand(upit, conn);
            OracleDataAdapter da = new OracleDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Boolean check = true;
            nameErr.Text = "";
            passErr.Text = "";
            foreach (DataRow users in dt.Rows)
            {
                if (username == users["username"].ToString().ToLower())
                {
                    nameErr.Text = "That username is taken";
                    check = false;
                    break;
                }
            }
            conn.Close();
            if (String.IsNullOrEmpty(txtUsername.Text))
            {
                nameErr.Text = "You must enter a username";
                check = false;
            }

            if (String.IsNullOrEmpty(txtPassword.Text))
            {
                passErr.Text = "You must enter a password";
                check = false;
            }

            if (username.Length > 20)
            {
                nameErr.Text = "That username is too long";
                check = false;
            }

            if (password.Length > 20)
            {
                passErr.Text = "That password is too long";
                check = false;
            }

            if (check)
            {
                nameErr.Text = "";
                passErr.Text = "";
                connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
                conn = new OracleConnection();
                conn.ConnectionString = connString;
                conn.Open();
                upit = "UPDATE users SET username ='"+username+"',password ='"+password+"' WHERE id="+lblId.Text.ToString()+"";
                comm = new OracleCommand(upit, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Successfully edited!");
                this.Close();
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                string id = row.Cells[0].Value.ToString();
                lblItemId.Text = id;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(lblItemId.Text.ToString()))
            {
                MessageBox.Show("You must select a row");
                return;
            }
            string connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();
            string upit = "DELETE FROM furniture WHERE id="+lblItemId.Text.ToString()+"";
            OracleCommand comm = new OracleCommand(upit, conn);
            comm.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Successfully deleted!");
            connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
            conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();
            upit = "SELECT f.id AS ID, f.name AS Name, c.name AS Producer, m.name AS Material,f.price AS Price FROM furniture f,users u,material m,company c WHERE f.material = m.id AND f.company = c.id AND f.seller = u.id AND f.seller = " + lblId.Text.ToString();
            comm = new OracleCommand(upit, conn);
            OracleDataAdapter da = new OracleDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }
    }
}
