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
    public partial class Uplatnica10 : Form
    {
        public Uplatnica10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LT-4;Integrated Security=True");
            string brojSmetka = smetkaPrimac.Text;
            string kolku = "+";
            kolku += iznos.Text;
            int clientId = 0;
            string blagajnaSmetka = "210000000000009";
            string blagajnaIme = "Blagajna";
            int blagajnaId = 4;
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "SELECT clientId FROM Smetki WHERE brojSmetka = '" + brojSmetka + "'";
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    clientId = (int)reader["clientId"];
                }
            }
            //  Console.WriteLine(clientId);
            reader.Close();
            string clientName = "";
            com.CommandText = "SELECT clientName FROM Smetki WHERE brojSmetka = '" + brojSmetka + "'";
            reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    clientName =reader["clientName"].ToString();
                }
            }
            //Console.WriteLine(clientName);
            reader.Close();
            using (con)
            {
                using (SqlCommand cmd = new SqlCommand("AddTransanction_PP10", con))
                {
                    
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_nalod", 1);
                    cmd.Parameters.AddWithValue("@nalogodavacPrimacId", clientId);
                    cmd.Parameters.AddWithValue("@nalogodavacPrimacIme", clientName) ;
                    cmd.Parameters.AddWithValue("@nalogodavacPrimacSmetkaBroj", brojSmetka);
                    cmd.Parameters.AddWithValue("@iznosSmetka", kolku);
                    cmd.ExecuteNonQuery();
                    cmd.Cancel();
                    

                    //cmd.Parameters.Add("@idTransakcija", SqlDbType.Int).Value = null;
                }

                int idTransakcija = 0;

                com.CommandText = "SELECT idTransakcija FROM Transakcii WHERE nalogodavacPrimacSmetkaBroj = '" + brojSmetka + "'";
                reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        idTransakcija = (int)reader["idTransakcija"];
                    }
                }
                //Console.WriteLine(clientName);
                reader.Close();

                using(SqlCommand cmd = new SqlCommand("AddKnizenje", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTransakcija", idTransakcija);
                    cmd.Parameters.AddWithValue("@brojSmetka", brojSmetka);
                    cmd.Parameters.AddWithValue("@iznos", kolku);
                    cmd.ExecuteNonQuery();
                    cmd.Cancel();
                }


                using (SqlCommand cmd = new SqlCommand("AddTransanction_PP10", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_nalod", 1);
                    cmd.Parameters.AddWithValue("@nalogodavacPrimacId", blagajnaId);
                    cmd.Parameters.AddWithValue("@nalogodavacPrimacIme", blagajnaIme);
                    cmd.Parameters.AddWithValue("@nalogodavacPrimacSmetkaBroj", blagajnaSmetka);
                    cmd.Parameters.AddWithValue("@iznosSmetka", kolku);
                    cmd.ExecuteNonQuery();
                    cmd.Cancel();


                    //cmd.Parameters.Add("@idTransakcija", SqlDbType.Int).Value = null;
                }


                idTransakcija = 0;

                com.CommandText = "SELECT idTransakcija FROM Transakcii WHERE nalogodavacPrimacIme = '" + blagajnaIme + "'";
                reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        idTransakcija = (int)reader["idTransakcija"];
                    }
                }
                //Console.WriteLine(clientName);
                reader.Close();

                using (SqlCommand cmd = new SqlCommand("AddKnizenje", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTransakcija", idTransakcija);
                    cmd.Parameters.AddWithValue("@brojSmetka", blagajnaSmetka);
                    cmd.Parameters.AddWithValue("@iznos", kolku);
                    cmd.ExecuteNonQuery();
                    cmd.Cancel();
                }




            }
            
        







        }
    }
}
