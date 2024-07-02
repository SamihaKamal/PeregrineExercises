using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpClientWinForms
{
  
    public partial class Form1 : Form
    {
        HttpClient a;
        
        public Form1()
        {
            InitializeComponent();
            a = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:51118/api/")
            };
            
    
        }


        private async void postBtn_Click(object sender, EventArgs e)
        {

            int num1 = System.Convert.ToInt32(textBox1.Text);
            int num2 = System.Convert.ToInt32(textBox2.Text);
            int sum = num1 + num2;

            var data = new Addition
            {
                FirstNumber = num1,
                SecondNumber = num2,
                Sum = sum
            };

            HttpResponseMessage response = await a.PostAsJsonAsync("Addition", data);
            response.EnsureSuccessStatusCode();

            label5.Text = sum.ToString();

        }

        private async void SubPostBtn_Click(object sender, EventArgs e)
        {
            int num1 = System.Convert.ToInt32(textBox4.Text);
            int num2 = System.Convert.ToInt32(textBox3.Text);
            int sum = num1 - num2;

            var data = new Addition
            {
                FirstNumber = num1,
                SecondNumber = num2,
                Sum = sum
            };

            HttpResponseMessage response = await a.PostAsJsonAsync("Subtraction", data);
            response.EnsureSuccessStatusCode();

            label6.Text = sum.ToString();
        }

        private async void MultPostBtn_Click(object sender, EventArgs e)
        {
            int num1 = System.Convert.ToInt32(textBox6.Text);
            int num2 = System.Convert.ToInt32(textBox5.Text);
            int sum = num1 * num2;

            var data = new Addition
            {
                FirstNumber = num1,
                SecondNumber = num2,
                Sum = sum
            };

            HttpResponseMessage response = await a.PostAsJsonAsync("Multiply", data);
            response.EnsureSuccessStatusCode();

            label11.Text = sum.ToString();
        }

        private async void DivPostBtn_Click(object sender, EventArgs e)
        {
            int num1 = System.Convert.ToInt32(textBox8.Text);
            int num2 = System.Convert.ToInt32(textBox7.Text);
            int sum = num1 / num2;

            var data = new Addition
            {
                FirstNumber = num1,
                SecondNumber = num2,
                Sum = sum
            };

            HttpResponseMessage response = await a.PostAsJsonAsync("Division", data);
            response.EnsureSuccessStatusCode();

            label16.Text = sum.ToString();
        }
    }

    public class Addition
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public int Sum { get; set; }
    }
}
