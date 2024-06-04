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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Shinex_Machine
{
    public partial class Add_item : Form
    {
        SqlConnection con = null;
        public Add_item()
        {
            con = new SqlConnection("Data Source=DESKTOP-M6275H1\\PRAMITHA; Initial Catalog=cleaning_machine1;Integrated Security=True;");
            InitializeComponent();
        }

        private void Add_item_Load(object sender, EventArgs e)
        {

             loadtable();

          

            comMT.Items.AddRange(new string[] { "FP", "GC", "NB", "VSM", "VDM", "VTM", "PG", "RM", "LB", "BPV", "GCM", "AS", "BH", "FM", "CC", "WC" });

            comboMn.Items.AddRange(new string[] { "Floor polisher", "Grass Cutter", "Normal Blowet", "Vaccume Singale Moter", "Vaccume Double Moter", "Vaccume Thrible Moter",
                "Presure Gun", "Ring Machine", "Leaf Blower", "BackPack Vaccume", "Glass Clener Machine", "Auto Scrubber", "Blower Heater", "Form Machine", "Cleaning Cart", "West Cart" });

            comboMiC.Items.AddRange(new string[] { "Afghanistan", "Albania", "Albania", "Algeria", "Andorra", "Angola", "Antigua and Barbuda", "Argentina", "Argentina", "Armenia", "Australia", 
                "Austria", "Austria", "Azerbaijan", "The Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bhutan", "Bolivia", 
                "Bosnia and Herzegovina", "Botswana", "Brazil", "Brunei", "Bulgaria", "Burkina Faso", "Burundi", "Canada", "Central African Republic", "Chad", "Chile", "China", "Colombia", 
                "Denmark", "France", "Germany", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Israel", "Italy", "Jamaica", "Japan", "Jordan",
                "Kazakhstan", "Kenya", "Korea, North", "Korea, South", "Kosovo", "Kuwait", "Lebanon", "Liberia", "Malawi", "Malaysia", "Maldives", "Marshall Islands", "Mexico", "Micronesia, " +
                "Federated States of", "Moldova", "Monaco", "Mongolia", "Morocco", "Namibia", "Myanmar (Burma)", "Nepal", "Netherlands", "New Zealand", "Nicaragua", "Niger", "Nigeria", "Norway", "Oman", "Pakistan", "Panama", 
                "Philippines", "Poland", "Romania", "Russia", "Rwanda", "Saudi Arabia", "Singapore", "South Africa", "South Sudan", "Sri Lanka", 
                "Swaziland", "Sweden", "Switzerland", "Taiwan", "Thailand", "Ukraine", "United Arab Emirates", "United Kingdom", "United States of America", "Uruguay", "Vietnam", "Zimbabwe", "Venezuela" });
            
        }

        private void loadtable()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select MachineType,MachineCode,MachineName,DeliveredDate,MadeInCountry,OtherMachineDetails from Machinesitem";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void btnSA_Click(object sender, EventArgs e)
        {
            try
            {

                con.Open();
                //label4.Text = "Connection Successfull!";
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                string MachineType = comMT.Text;
                string MachineCode = txtMC.Text;
                string MachineName = comboMn.Text;

                Image img = picturemi.Image;
                
                DateTime DeliveredDate = dateTimeDD.Value;
                string MadeInCountry = comboMiC.Text;
                string OtherMachineDetails = txtOMD.Text;
                cmd.CommandText = "insert into data Machinesitem (MachineType,MachineCode,MachineName,MachineImage,DeliveredDate,MadeInCountry,OtherMachineDetails) values ('" + MachineType + "', '" + MachineCode + "','"+MachineName+"', '"+img+"', '"+DeliveredDate+"', '"+MadeInCountry+"', '"+OtherMachineDetails+"' )";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record has been inserted!");

                txtid.Clear();
                comMT.Items.Clear();
                txtMC.Clear();
                comboMn.Items.Clear();
                picturemi.Image = null;
                comboMiC.Items.Clear();
                txtOMD.Clear();


                loadtable();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex);
            }
        }

        private void btnchoice_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected file path
                    string imagePath = openFileDialog.FileName;

                    // Assign the path to the PictureBox
                    picturemi.ImageLocation = imagePath;
                }
            }
        }
    }
}
