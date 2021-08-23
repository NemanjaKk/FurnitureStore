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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string connString = "User id = baze; Password = baze; Data Source = localhost:1521/xe; Pooling = false";
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connString;
            conn.Open();

            string upit = "SELECT * FROM users";
            OracleCommand comm = new OracleCommand(upit, conn);
            OracleDataAdapter da = new OracleDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            string username = txtUsername.Text.ToString().ToLower();
            string password = txtPassword.Text.ToString().ToLower();

            foreach (DataRow users in dt.Rows)
            {
                if(username == users["username"].ToString().ToLower() && password == users["password"].ToString().ToLower())
                {
                    this.Hide();
                    var fur = new Furniture(username);
                    fur.Closed += (s, args) => this.Close();
                    fur.Show();
                    return;
                }
            }
            txtUsername.Text = "";
            txtPassword.Text = "";
            MessageBox.Show("Wrong information");
            conn.Close();
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            this.Hide();
            var reg = new Register();
            reg.Closed += (s, args) => this.Close();
            reg.Show();
        }
    }
}
