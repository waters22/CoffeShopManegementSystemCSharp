using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeShopManegementSystemCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Neeta Kadam" || textBox2.Text == "kneeta")
            {
                MessageBox.Show("You are logged in successfully..");
                this.Visible = false;
                Home obj1 = new Home();
                obj1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Enter Valid Username and Password.");
            }
        }
    }
}
