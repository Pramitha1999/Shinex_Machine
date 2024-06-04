using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shinex_Machine
{
    public partial class Login_Item : Form
    {
        public Login_Item()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                {
                    Add_item login = new Add_item();
                    login.Show();

                }

                try
                {
                    MessageBox.Show("Message logged successfully!", "Log Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error logging message: {ex.Message}", "Log Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                {
                    issue login = new issue();
                    login.Show();


                }

                try
                {
                    MessageBox.Show("Message logged successfully!", "Log Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error logging message: {ex.Message}", "Log Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            {
                {
                    service login = new service();
                    login.Show();

                }

                try
                {
                    MessageBox.Show("Message logged successfully!", "Log Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error logging message: {ex.Message}", "Log Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                {
                    complited login = new complited();
                    login.Show();


                }

                try
                {
                    MessageBox.Show("Message logged successfully!", "Log Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error logging message: {ex.Message}", "Log Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            {
                {
                    stores login = new stores();
                    login.Show();

                }

                try
                {
                    MessageBox.Show("Message logged successfully!", "Log Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error logging message: {ex.Message}", "Log Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            {
                {
                    genarate login = new genarate();
                    login.Show();

                }

                try
                {
                    MessageBox.Show("Message logged successfully!", "Log Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error logging message: {ex.Message}", "Log Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                // Code to exit the customer page and go back to the main dashboard
                Form1 login = new Form1();
                login.Show();
                this.Close(); // Close the customer form
            }
        }
    }
}
