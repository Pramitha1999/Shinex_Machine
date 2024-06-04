using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace shinex_machin
{
    public partial class add_item : Form
    {
        private SqlConnection con;
        private MemoryStream ms;
        private BindingList<issue_machinecs > bi;

        public add_item()
        {
            InitializeComponent();
        }

        private void add_item_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=DESKTOP-M6275H1\\PRAMITHA; Initial Catalog=cleaning_machine1;Integrated Security=True;");
            InitializeComboBoxes();
            LoadTable();
        }

        private void InitializeComboBoxes()
        {
            comMT.Items.AddRange(new string[] { "FP", "GC", "NB", "VSM", "VDM", "VTM", "PG", "RM", "LB", "BPV", "GCM", "AS", "BH", "FM", "CC", "WC" });
            comboBox2.Items.AddRange(new string[] { "Floor polisher", "Grass Cutter", "Normal Blower", "Vaccume Single Motor", "Vaccume Double Motor", "Vaccume Triple Motor", "Pressure Gun", "Ring Machine", "Leaf Blower", "BackPack Vaccume", "Glass Cleaner Machine", "Auto Scrubber", "Blower Heater", "Foam Machine", "Cleaning Cart", "Waste Cart" });
            comboMiC.Items.AddRange(new string[]
            {
                "Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Antigua and Barbuda", "Argentina",
                "Armenia", "Australia", "Austria", "Azerbaijan", "The Bahamas", "Bahrain", "Bangladesh", "Barbados",
                "Belarus", "Belgium", "Belize", "Benin", "Bhutan", "Bolivia", "Bosnia and Herzegovina", "Botswana",
                "Brazil", "Brunei", "Bulgaria", "Burkina Faso", "Burundi", "Canada", "Central African Republic",
                "Chad", "Chile", "China", "Colombia", "Denmark", "France", "Germany", "Hungary", "Iceland", "India",
                "Indonesia", "Iran", "Iraq", "Ireland", "Israel", "Italy", "Jamaica", "Japan", "Jordan", "Kazakhstan",
                "Kenya", "North Korea", "South Korea", "Kosovo", "Kuwait", "Lebanon", "Liberia", "Malawi", "Malaysia",
                "Maldives", "Marshall Islands", "Mexico", "Micronesia", "Moldova", "Monaco", "Mongolia", "Morocco",
                "Namibia", "Myanmar", "Nepal", "Netherlands", "New Zealand", "Nicaragua", "Niger", "Nigeria",
                "Norway", "Oman", "Pakistan", "Panama", "Philippines", "Poland", "Romania", "Russia", "Rwanda",
                "Saudi Arabia", "Singapore", "South Africa", "South Sudan", "Sri Lanka", "Swaziland", "Sweden",
                "Switzerland", "Taiwan", "Thailand", "Ukraine", "United Arab Emirates", "United Kingdom", "United States of America",
                "Uruguay", "Vietnam", "Zimbabwe", "Venezuela"
            });
        }

        private void LoadTable()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Machinesitem";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnex_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                machine_information login = new machine_information();
                login.Show();
                this.Close();
            }
        }

        private void btnchoice_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png) | *.jpg; *.jpeg; *.png";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    picturemi.Image = new Bitmap(openFileDialog.FileName);
                    picturemi.ImageLocation = openFileDialog.FileName;
                }
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Are you sure to Update?", "Update Record", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE Machinesitem SET MachineType = @MachineType, MachineCode = @MachineCode, MachineName = @MachineName, MachineImage = @MachineImage, DeliveredDate = @DeliveredDate, MadeInCountry = @MadeInCountry, OtherMachineDetails = @OtherMachineDetails WHERE MachineID = @MachineID", con);

                    SetParameters(cmd);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Record has been Updated!");
                    ClearFields();
                    LoadTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnSA_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Machinesitem (MachineType, MachineCode, MachineName, MachineImage, DeliveredDate, MadeInCountry, OtherMachineDetails) VALUES (@MachineType, @MachineCode, @MachineName, @MachineImage, @DeliveredDate, @MadeInCountry, @OtherMachineDetails)", con);

                SetParameters(cmd);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Record has been inserted!");
                ClearFields();
                LoadTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void SetParameters(SqlCommand cmd)
        {
            cmd.Parameters.AddWithValue("@MachineID", txtid.Text);
            cmd.Parameters.AddWithValue("@MachineType", comMT.Text);
            cmd.Parameters.AddWithValue("@MachineCode", txtMC.Text);
            cmd.Parameters.AddWithValue("@MachineName", comboBox2.Text);
            cmd.Parameters.AddWithValue("@MachineImage", ImageToByteArray(picturemi.Image));
            cmd.Parameters.AddWithValue("@DeliveredDate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@MadeInCountry", comboMiC.Text);
            cmd.Parameters.AddWithValue("@OtherMachineDetails", txtOMD.Text);
        }

        private byte[] ImageToByteArray(Image image)
        {
            if (image == null) return null;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, image.RawFormat);
                return memoryStream.ToArray();
            }
        }

        private void ClearFields()
        {
            txtMC.Clear();
            txtOMD.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtid.Text = row.Cells["MachineID"].Value.ToString();
                comMT.Text = row.Cells["MachineType"].Value.ToString();
                txtMC.Text = row.Cells["MachineCode"].Value.ToString();
                comboBox2.Text = row.Cells["MachineName"].Value.ToString();
                comboMiC.Text = row.Cells["MadeInCountry"].Value.ToString();
                txtOMD.Text = row.Cells["OtherMachineDetails"].Value.ToString();

                picturemi.Image = row.Cells["MachineImage"].Value != DBNull.Value ? ByteArrayToImage((byte[])row.Cells["MachineImage"].Value) : null;
                dateTimePicker1.Value = row.Cells["DeliveredDate"].Value != DBNull.Value ? Convert.ToDateTime(row.Cells["DeliveredDate"].Value) : DateTime.Now;
            }
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                return Image.FromStream(ms);
            }
        }

        private void btnPR_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(Pd_PrintPage);
            PrintDialog pdi = new PrintDialog
            {
                Document = pd
            };
            if (pdi.ShowDialog() == DialogResult.OK)
            {
                pd.Print();
            }
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            string companyName = "Shinex Facility Management (pvt) Ltd.";
            String Page = "Add A New Item";
            string contentToPrint = $"Company Name: {companyName}\n\n" +
                                    $"Machine Type: {comMT.Text}\n" +
                                    $"Machine Code: {txtMC.Text}\n" +
                                    $"Machine Name: {comboBox2.Text}\n" +
                                    $"Delivered Date: {dateTimePicker1.Value}\n" +
                                    $"Made In Country: {comboMiC.Text}\n" +
                                    $"Other Machine Details: {txtOMD.Text}\n";

            int imageWidth = 400;
            int imageHeight = 400;
            int x = 150;
            int y = 150;

            if (picturemi.Image != null)
            {
                e.Graphics.DrawImage(picturemi.Image, new Rectangle(x, y, imageWidth, imageHeight));
                y += imageHeight + 20;
            }

            e.Graphics.DrawString(contentToPrint, new Font("Arial", 14), Brushes.Black, new PointF(10, 10));
        }
    }
}
