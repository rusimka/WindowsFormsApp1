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
    public partial class Izvestaj : Form
    {
        public Izvestaj()
        {
            InitializeComponent();
        }

        private void Izvestaj_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LT-4;Integrated Security=True");
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "select * from Knizenje";
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;

            }
            reader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LT-4;Integrated Security=True");
            string brSmetka = brojSmetka.Text;
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "select nalogodavacSmetkaBroj,nalogodavacPrimacSmetkaBroj,iznos from Transakcii join Knizenje k on k.idTransakcija = Transakcii.idTransakcija WHERE brojSmetka = '" + brSmetka + "'";

            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;

            }
            reader.Close();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LT-4;Integrated Security=True");
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "select * from Knizenje";
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridView1.DataSource = dt;

            }
            reader.Close();
        }
    }
    
}
