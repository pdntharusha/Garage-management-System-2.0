using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Garage_management_System_2._0
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private int incorrectAttempts = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;

            // You can implement your authentication logic here.
            // For demonstration purposes, we'll use a simple check.
            if (username == "admin" && password == "admin")
            {
                // Successful login action (open a new form or perform some other action)
                MainForm mainForm = new MainForm();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                incorrectAttempts++;

                // Check if it's the last attempt (2nd attempt)
                if (incorrectAttempts == 2)
                {
                    MessageBox.Show("This is your last incorrect attempt. After this, the application will exit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (incorrectAttempts < 3)
                {
                    MessageBox.Show("Login failed. Please check your credentials.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // If incorrectAttempts reaches 3, exit the application
                if (incorrectAttempts >= 3)
                {
                    Application.Exit();
                }
            }

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SuspendLayout(); // Suspend layout updates temporarily

            if (checkBox1.Checked)
            {
                // Show the password characters
                textBox2.PasswordChar = '\0';
            }
            else
            {
                // Hide the password characters
                textBox2.PasswordChar = '*'; // You can use any character you prefer to mask the password.
            }

            ResumeLayout(); // Resume layout updates
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
