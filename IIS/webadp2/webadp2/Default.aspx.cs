using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace webadp2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Response.Write("<center><h1>Read data from a database</h1></center><hr/>");
                Response.Write("<br/>");

                String s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;

                SqlConnection con = new SqlConnection(s);
                string sqlString = "Select * from Customers;";
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlString, con);
                cmd.Connection = con;

                //Executereader for select, executenonquery for insert update and delete, execute scalar for count or single numbers
                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
                dr.Close();
                string sqlStringDropDownList = "Select Country from Customers";
                SqlCommand cmd2 = new SqlCommand(sqlStringDropDownList, con);
                SqlDataReader dr2 = cmd2.ExecuteReader();
                while (dr2.Read() == true)
                {
                    DropDownList1.Items.Add(new ListItem(dr2["Country"].ToString(), dr2["Country"].ToString()));
                }
                dr2.Close();
                con.Close();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Write("<center><h1>Read data from a database</h1></center><hr/>");
            Response.Write("<br/>");
            String txtValue = TextBox1.Text;
            String s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
            string sqlString = "Select * from Customers where Country=@Country;";
            SqlConnection con = new SqlConnection(s);

            SqlCommand cmd = new SqlCommand(sqlString, con);
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@Country", txtValue);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            GridView1.DataSource = dr;
            GridView1.DataBind();
            dr.Close();
            con.Close();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Response.Write("<br/>");
                String txtValue = DropDownList1.SelectedValue.ToString();
                String s = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString;
                SqlConnection con = new SqlConnection(s);
                string sqlString = "Select * from Customers where Country=@Country;";


                SqlCommand cmd = new SqlCommand(sqlString, con);
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Country", txtValue);
                con.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
                dr.Close();
                con.Close();
            }
        }
    }
}