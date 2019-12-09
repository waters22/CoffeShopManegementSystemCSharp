using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CoffeShopManegementSystemCSharp
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\documents\visual studio 2015\Projects\CoffeShopManegementSystemCSharp\CoffeShopManegementSystemCSharp\coffee.mdf;Integrated Security=True");
            con.Open();

            string gen = string.Empty;
            if (radioButton1.Checked)
            {
                gen = "Male";
            }
            else if (radioButton2.Checked)
            {
                gen = "Female";
            }
            try
            {
                string str = " INSERT INTO emp(name,addr,city,contact,gender,email,doj,salary) VALUES('" + textBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox2.Text + "','" + gen + "','" + textBox3.Text + "','" + textBox6.Text + "','" + textBox7.Text + "'); ";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

                //-------------------------------------------//

                string str1 = "select max(Id) from emp;";

                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Employee Information Registered Successfully..");

                }
                this.Close();
            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();
        }
    }
}
