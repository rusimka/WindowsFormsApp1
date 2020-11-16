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
    public partial class Uplatnica30 : Form
    {
        public Uplatnica30()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LT-4;Integrated Security=True");
            // ovde si nemas rabota so blagajnata
            string SmetkaNalogodavac = smetkaNalogodavac.Text;
            string SmetkaNalogoPrimac = smetkaNalogoPrimac.Text;
            // treba da proveris dali ima tolku pari za da ja izvrsi transakcija
            string kolkuDaPrefrli = iznos.Text;
            int kolkuDaPrefrliInt = int.Parse(kolkuDaPrefrli);
            String kolkuIma = "";
            int kolkuImaInt = 0;
            SqlCommand com = new SqlCommand();
            com.Connection = con;
            com.CommandText = "SELECT iznosSmetka FROM Smetki WHERE brojSmetka = '" + SmetkaNalogodavac + "'";
            con.Open();
            SqlDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    kolkuIma = reader["iznosSmetka"].ToString();
                }
            }
            //  Console.WriteLine(clientId);
            reader.Close();

            kolkuImaInt = int.Parse(kolkuIma);
            if(kolkuImaInt > kolkuDaPrefrliInt)
            {
                //Console.WriteLine("Transakcijata moze da se izvrsi");

                // vo knizenje od ednata smetka + 
                // od drugata - 
                // ako ima provizija stavas provizija


                com.CommandText = "SELECT clientId FROM Smetki WHERE brojSmetka = '" + SmetkaNalogodavac + "'";
                int clientIdNalogodavac = 0;
                reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        clientIdNalogodavac = (int)reader["clientId"];
                    }
                }
                reader.Close();


                string clientNameNalogodavac = "";
                com.CommandText = "SELECT clientName FROM Smetki WHERE brojSmetka = '" + SmetkaNalogodavac + "'";
                reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        clientNameNalogodavac = reader["clientName"].ToString();
                    }
                }
                reader.Close();


                com.CommandText = "SELECT clientId FROM Smetki WHERE brojSmetka = '" + SmetkaNalogoPrimac + "'";
                int clientIdNalogoPrimac = 0;
                reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        clientIdNalogoPrimac = (int)reader["clientId"];
                    }
                }
                reader.Close();



                string clientNameNalogoPrimac = "";
                com.CommandText = "SELECT clientName FROM Smetki WHERE brojSmetka = '" + SmetkaNalogoPrimac + "'";
                reader = com.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        clientNameNalogoPrimac = reader["clientName"].ToString();
                    }
                }
                reader.Close();



                string naKrajMesec = "";

                if (radioButton1.Checked)
                {
                    naKrajMesec = "DA";
                    // prvo moras transakcijata da ja vnesis pa podocna vo provizii 
                }
                else
                {
                    naKrajMesec = "NE";
                   
                }

                string odzemi = "-";
                //odzemi += iznos.Text;
                string dodadi = "+";
                //dodadi += iznos.Text;

               

                if(naKrajMesec == "NE")
                {

                    string kolkuIznos = iznos.Text;
                    int kolkuIznosInt = int.Parse(kolkuIznos);
                    string provizijaIznos = provizija.Text;
                    int provizijaIznosInt = int.Parse(provizijaIznos);
                    int vkupno = provizijaIznosInt + kolkuIznosInt;

                    odzemi += vkupno;
                    dodadi += kolkuIznosInt;

                    using (con)
                    {
                        using (SqlCommand cmd = new SqlCommand("AddTransanction_PP30", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id_nalod", 3);
                            /*
                             * @nalogodavacId int ,
                            @nalogodavacIme varchar(100),
                              @nalogodavacSmetkaBroj varchar(100),
                             */
                            cmd.Parameters.AddWithValue("@nalogodavacId", clientIdNalogodavac);
                            cmd.Parameters.AddWithValue("@nalogodavacIme", clientNameNalogodavac);
                            cmd.Parameters.AddWithValue("@nalogodavacSmetkaBroj", SmetkaNalogodavac);

                            cmd.Parameters.AddWithValue("@nalogodavacPrimacId", clientIdNalogoPrimac);
                            cmd.Parameters.AddWithValue("@nalogodavacPrimacIme", clientNameNalogoPrimac);
                            cmd.Parameters.AddWithValue("@nalogodavacPrimacSmetkaBroj", SmetkaNalogoPrimac);
                            cmd.Parameters.AddWithValue("@iznosSmetka", dodadi);
                            cmd.Parameters.AddWithValue("@imaProvizija", "DA");
                            cmd.Parameters.AddWithValue("@provizija", provizijaIznos);
                            cmd.Parameters.AddWithValue("@naKrajMesec", naKrajMesec);
                            cmd.Parameters.AddWithValue("@nalogodavacSmetkaIznos", odzemi);

                            cmd.ExecuteNonQuery();
                            cmd.Cancel();
                        }

                        int idTransakcija = 0;

                        com.CommandText = "SELECT idTransakcija FROM Transakcii WHERE nalogodavacSmetkaBroj = '" + SmetkaNalogodavac + "'";
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
                            cmd.Parameters.AddWithValue("@brojSmetka", SmetkaNalogodavac);
                            cmd.Parameters.AddWithValue("@iznos", odzemi);
                            cmd.ExecuteNonQuery();
                            cmd.Cancel();
                        }


                        com.CommandText = "SELECT idTransakcija FROM Transakcii WHERE nalogodavacPrimacSmetkaBroj = '" + SmetkaNalogoPrimac + "'";
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
                            cmd.Parameters.AddWithValue("@brojSmetka", SmetkaNalogoPrimac);
                            cmd.Parameters.AddWithValue("@iznos", dodadi);
                            cmd.ExecuteNonQuery();
                            cmd.Cancel();
                        }

                    }

                }


                else
                {

                    string kolkuIznos = iznos.Text;
                    int kolkuIznosInt = int.Parse(kolkuIznos);
                    string provizijaIznos = provizija.Text;
                    int provizijaIznosInt = int.Parse(provizijaIznos);
                    //int vkupno = provizijaIznosInt + kolkuIznosInt;

                    odzemi += kolkuIznosInt;
                    dodadi += kolkuIznosInt;

                    using (con)
                    {
                        using (SqlCommand cmd = new SqlCommand("AddTransanction_PP30", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@id_nalod", 3);
                            /*
                             * @nalogodavacId int ,
                            @nalogodavacIme varchar(100),
                              @nalogodavacSmetkaBroj varchar(100),
                             */
                            cmd.Parameters.AddWithValue("@nalogodavacId", clientIdNalogodavac);
                            cmd.Parameters.AddWithValue("@nalogodavacIme", clientNameNalogodavac);
                            cmd.Parameters.AddWithValue("@nalogodavacSmetkaBroj", SmetkaNalogodavac);

                            cmd.Parameters.AddWithValue("@nalogodavacPrimacId", clientIdNalogoPrimac);
                            cmd.Parameters.AddWithValue("@nalogodavacPrimacIme", clientNameNalogoPrimac);
                            cmd.Parameters.AddWithValue("@nalogodavacPrimacSmetkaBroj", SmetkaNalogoPrimac);
                            cmd.Parameters.AddWithValue("@iznosSmetka", dodadi);
                            cmd.Parameters.AddWithValue("@imaProvizija", "DA");
                            cmd.Parameters.AddWithValue("@provizija", provizijaIznos);
                            cmd.Parameters.AddWithValue("@naKrajMesec", naKrajMesec);
                            cmd.Parameters.AddWithValue("@nalogodavacSmetkaIznos", odzemi);

                            cmd.ExecuteNonQuery();
                            cmd.Cancel();
                        }

                        //odzemi od smetka

                        int idTransakcija = 0;

                        com.CommandText = "SELECT idTransakcija FROM Transakcii WHERE nalogodavacSmetkaBroj = '" + SmetkaNalogodavac + "'";
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
                            cmd.Parameters.AddWithValue("@brojSmetka", SmetkaNalogodavac);
                            cmd.Parameters.AddWithValue("@iznos", odzemi);
                            cmd.ExecuteNonQuery();
                            cmd.Cancel();
                        }


                        com.CommandText = "SELECT idTransakcija FROM Transakcii WHERE nalogodavacPrimacSmetkaBroj = '" + SmetkaNalogoPrimac + "'";
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

                        // dodadi vo edna smetka 

                        using (SqlCommand cmd = new SqlCommand("AddKnizenje", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@idTransakcija", idTransakcija);
                            cmd.Parameters.AddWithValue("@brojSmetka", SmetkaNalogoPrimac);
                            cmd.Parameters.AddWithValue("@iznos", dodadi);
                            cmd.ExecuteNonQuery();
                            cmd.Cancel();
                        }


                        // dodaj vo provizi

                        com.CommandText = "SELECT idTransakcija FROM Transakcii WHERE nalogodavacSmetkaBroj = '" + SmetkaNalogodavac + "'";
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

                        using (SqlCommand cmd = new SqlCommand("AddProvision", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@idTransakcija", idTransakcija);
                            cmd.Parameters.AddWithValue("@brojSmetka", SmetkaNalogodavac);
                            cmd.Parameters.AddWithValue("@provizijaIznos", provizijaIznos);
                            cmd.ExecuteNonQuery();
                            cmd.Cancel();
                        }


                    }

                }

            }


            else
            {
                MessageBox.Show("Transakcijata ne moze  da se izvrsi zaradi toa sto nemate dovolno pari ");
            }



        }

        
    }
}
