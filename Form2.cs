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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string username = txtNewUser.Text.ToString().ToLower();
            string password = txtNewPassword.Text.ToString().ToLower();

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

            foreach (DataRow users in dt.Rows)
            {
                if (username == users["username"].ToString().ToLower())
                {
                    lblUser.Text = "That username is taken";
                    check = false;
                    break;
                }
            }

            if (String.IsNullOrEmpty(txtNewUser.Text))
            {
                lblUser.Text = "You must enter a username";
                check = false;
            }

            if (String.IsNullOrEmpty(txtNewPassword.Text))
            {
                lblPass.Text = "You must enter a password";
                check = false;
            }

            if (username.Length > 20)
            {
                lblUser.Text = "That username is too long";
                check = false;
            }

            if (password.Length > 20)
            {
                lblPass.Text = "That password is too long";
                check = false;
            }

            if (check)
            {
                lblPass.Text = "";
                lblUser.Text = "";
                upit = "INSERT INTO users VALUES((select max(id)+1 from users),'" + username + "','" + password + "',2)";
                comm = new OracleCommand(upit, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Registered");
                this.Hide();
                var fur = new Furniture(username);
                fur.Closed += (s, args) => this.Close();
                fur.Show();
            }
        }
    }
}
