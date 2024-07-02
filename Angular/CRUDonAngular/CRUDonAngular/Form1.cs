using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace CRUDonAngular
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'northwindDataSet.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.northwindDataSet.Student);

        }

        private void createbtn_Click(object sender, EventArgs e)
        {
            String name = textBox1.Text;
            int age = System.Convert.ToInt32(textBox2.Text);

            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            con.ConnectionString = "Data Source=DESKTOP-PCDU919;Initial Catalog=Northwind;User ID=sa; password=1234;Encrypt=False;TrustServerCertificate=True";
            con.Open();

            com.Connection = con;
            com.CommandText = (@"INSERT INTO Student (Name, Age) VALUES ('" + name + "', '" + age + "' );");
            com.ExecuteNonQuery();

            this.studentTableAdapter.Fill(this.northwindDataSet.Student);

            con.Close();
        }

        private void namebtn_Click(object sender, EventArgs e)
        {
            int id = System.Convert.ToInt32(textBox4.Text);
            String name = textBox3.Text;
            int age = System.Convert.ToInt32(textBox5.Text);

            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            con.ConnectionString = "Data Source=DESKTOP-PCDU919;Initial Catalog=Northwind;User ID=sa; password=1234;Encrypt=False;TrustServerCertificate=True";
            con.Open();

            com.Connection = con;
            com.CommandText = (@"UPDATE Student SET Name = '" + name + "', Age = '" + age + "' WHERE StudentId = '" + id + "';");
            com.ExecuteNonQuery();

            this.studentTableAdapter.Fill(this.northwindDataSet.Student);

            con.Close();
        }

        private void deletebtn_Click(object sender, EventArgs e)
        {
            int id = System.Convert.ToInt32(textBox8.Text);

            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            con.ConnectionString = "Data Source=DESKTOP-PCDU919;Initial Catalog=Northwind;User ID=sa; password=1234;Encrypt=False;TrustServerCertificate=True";
            con.Open();
            com.Connection = con;
            com.CommandText = (@"DELETE FROM Student WHERE StudentId = '" + id + "';");
            com.ExecuteNonQuery();

            this.studentTableAdapter.Fill(this.northwindDataSet.Student);

            con.Close();
        }
    }
}
