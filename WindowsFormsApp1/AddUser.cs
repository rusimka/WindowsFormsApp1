using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LT-4;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("addUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = username.Text;
                    cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = password.Text;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            Korisnici korisnici = new Korisnici();
            korisnici.Show();
        }
    }
}
