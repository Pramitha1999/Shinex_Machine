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

namespace Shinex_Machine
{
    public partial class service : Form
    {
        SqlConnection con = null;
        public service()
        {
            con = new SqlConnection("Data Source=DESKTOP-M6275H1\\PRAMITHA; Initial Catalog=cleaning_machine1;Integrated Security=True;");
            InitializeComponent();
        }

        private void service_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-M6275H1\\PRAMITHA; Initial Catalog=cleaning_machine1;Integrated Security=True;");

            comboBox5.Items.AddRange(new string[] { "FP", "GC", "NB", "VSM", "VDM", "VTM", "PG", "RM", "LB", "BPV", "GCM", "AS", "BH", "FM", "CC", "WC" });

            comboBox2.Items.AddRange(new string[] { "Brandix Girithale", "Brandix Ridigaa", "Brandix Katunayaka", "Brandix Mirigama", "Brandix Batticalo", "Brandix Nivithigala", "Brandix Rathmalana", "Brandix Koggala", "Brandix Polonnaruwa", "Brandix Rabukkana", "Brandix Unit", "Brandix Kahawatta", "Vilpattu", "Global Park", "GTB", "Alumex", "Wariyapola", "Hunasgiriya", "Mulathiu", "Mihinthale", "Walpola", "Thomas", "Asain", "Varuna", "Kolonnawa", "Yala", "Horten Place", "Minneriya Natioanl Park", "Kaluthara", "Ridigama", "Girithale Wild Life", "Udawalawa Natioanal Park", "Homoyopathi", "Hadala Laduru", "Maleriya", "Medi Houes", "Helth Ministry", "A & E", "Balangoda Hospitel", "Eheliyagoda Hospitel", "Kollonna Hospitel", "Rakwana Hospitel", "Ayagama Hospitel", "Kalthota Hospitel", "Kiriella Hospitel", "Kiriporuwa Hospitel", "Nivitigala Hospitel", "Kithulgala Hospitel", "Rathnapura Director", "Godakwela Hospitel", "Monaraghayata Hospitel", "Pallebaddha Hospitel", "Weligepola Hospitel", "Karawanalla Hospitel", "Mawanalla Hospitel", "Warakapola Hospitel", "Thangalla - Hospitel", "Eththurusewana Park", "Chandrika Wawa Park", "Chest Hospitel -Walisara", "Chest Hospitel - Boralla", "Chest Hospitel - Narahayenpita" });
        }
    }
}
