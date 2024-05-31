using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
namespace DatabaseConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection cnn;
            SqlCommand command;
            SqlDataReader dataReader;
            String output;

            String connString = "Data Source=.\\; Initial Catalog=Northwind;User ID=sa;Password=1234";
            //READ
            //String query = "Select Name, Age from Student"; 
            //CREATE
            String query = "Create Table Yuuchu (id int Not Null Identity(1,1), Firstname nvarchar(50), LastName nvarchar(50), Primary Key(id));";
            //String query = "Insert Into Yuuchu (Firstname, Lastname) Values ('Yuu', 'Chu')";
            //UPDATE
            //String query = "Update Yuuchu Set Firstname = 'Chu', Lastname='Yuu' Where id = 1;";
            //DELETE
            //String query = "Delete from Yuuchu";
            //String query = "Drop Table Yuuchu";
            cnn = new SqlConnection(connString);
            cnn.Open();
            Console.WriteLine("Connection is Open");
            command = new SqlCommand(query, cnn);
            command.Connection = cnn;
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                output = (String)dataReader.GetValue(0) + "\t" + dataReader.GetValue(1) + "\n";
                Console.WriteLine(output);
            }
            Console.ReadLine();
            dataReader.Close();
            command.Dispose();
            cnn.Close();
        }
    }
}
