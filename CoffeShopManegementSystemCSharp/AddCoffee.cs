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
    public partial class AddCoffee : Form
    {
        public AddCoffee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\documents\visual studio 2015\Projects\CoffeShopManegementSystemCSharp\CoffeShopManegementSystemCSharp\coffee.mdf;Integrated Security=True");
            con.Open();

            try
            {
                string str = " INSERT INTO acoffee(name,type,price) VALUES('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "'); ";

                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();

                //-------------------------------------------//

                string str1 = "select max(Id) from acoffee;";

                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Add Coffee Details Successfully..");

                }
                this.Close();
            }
            catch (SqlException excep)
            {
                MessageBox.Show(excep.Message);
            }
            con.Close();
        }

        private void AddCoffee_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dell\documents\visual studio 2015\Projects\CoffeShopManegementSystemCSharp\CoffeShopManegementSystemCSharp\coffee.mdf;Integrated Security=True");
            con.Open();
            string str1 = "select max(id) from acoffee;";

            SqlCommand cmd1 = new SqlCommand(str1, con);
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    textBox1.Text = "1";
                }
                else
                {
                    int a;
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    textBox1.Text = a.ToString();
                }

            }
        }
    }
}
