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

namespace SqlInjection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=.;Initial Catalog=Fabrika;Integrated Security=True;";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand();
            //command.CommandText = "UPDATE Addresses SET City='" + textBox1.Text + "' WHERE AddressId=5";
            command.Connection = connection;
            command.Parameters.AddWithValue("@City", textBox1.Text);
            command.CommandText = "UPDATE Addresses SET City=@City WHERE AddressId=5";
            connection.Open(); //Baglanti acilir.
            int donen = command.ExecuteNonQuery();
            if (donen > 0)
               MessageBox.Show("Update islemi gerceklesti");
            connection.Close();
        }
    }
}
