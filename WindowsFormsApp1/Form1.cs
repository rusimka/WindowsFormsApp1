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
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=LT-4;Integrated Security=True");
            string Password = "";
            bool IsExist = false;
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Users where username='" + username.Text + "'", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                byte[] pass = (byte[])sdr["passHash"];
                Password = "0x" + BitConverter.ToString(pass).Replace("-", "");
                //Password = sdr.GetString(2);  //get the user password from db if the user name is exist in that.  
                IsExist = true;
            }
            con.Close();
            if (IsExist)  //if record exis in db , it will return true, otherwise it will return false  
            {
                String hashed = "0x";
                string actualResult512 = Cryptography.GenerateSHA512String(password.Text);
                hashed += actualResult512;
                if (hashed.Equals(Password))
                {
                    if (username.Text.Equals("admin"))
                    {
                        MessageBox.Show("Successfully loged in");
                        AdminMenu adminMenu = new AdminMenu();
                        adminMenu.Show();
                    }
                    //Console.WriteLine("Welcome admin");
                }
                else
                {
                    MessageBox.Show("Wrong password");
                }

            }
            else  //showing the error message if user credential is wrong  
            {
                MessageBox.Show("Please check your username");
            }
        }
    }
}
