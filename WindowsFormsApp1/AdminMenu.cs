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
    public partial class AdminMenu : Form
    {
        public AdminMenu()
        {
            InitializeComponent();
        }

        private void кориснициToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Korisnici korisnici = new Korisnici();
            korisnici.Show();
        }

        private void AdminMenu_Load(object sender, EventArgs e)
        {
            
        }

        private void пП10УплатницаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uplatnica10 uplatnica10 = new Uplatnica10();
            uplatnica10.Show();




        }

        private void пП40УплатницаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uplatnica40 uplatnica40 = new Uplatnica40();
            uplatnica40.Show();
        }

        private void пП30УплатницаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uplatnica30 uplatnica30 = new Uplatnica30();
            uplatnica30.Show();
        }

        private void извештајToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Izvestaj izvestaj = new Izvestaj();
            izvestaj.Show();
        }
    }
}
