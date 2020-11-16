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
    public partial class Korisnici : Form
    {
        public Korisnici()
        {
            InitializeComponent();
        }

        private void Korisnici_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LT-4;Integrated Security=True");
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "select id,username from Users";
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;

            }

           




            // TODO: This line of code loads data into the '_LT_4DataSet11.Users' table. You can move, or remove it, as needed.
            //this.usersTableAdapter.Fill(this._LT_4DataSet11.Users);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.Show();
        }
    }
}
