using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shapes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                //Area selected
                switch (listBox2.SelectedItem)
                {
                    case "Triangle":
                        label6.Visible = true;
                        label8.Visible = true;
                        label7.Visible = true;
                        textBox10.Visible = true;
                        textBox12.Visible = true;
                        textBox8.Visible = true;
                        break;
                    case "Rectangle":
                        label9.Visible = true;
                        label10.Visible = true;
                        textBox9.Visible = true;
                        textBox11.Visible = true;
                        
                        break;
                    case "Circle":
                        textBox7.Visible = true;
                        label11.Visible = true;
                       
                        break;
                }
            }
            else if (radioButton6.Checked == true)
            {
                //Perimetre selected
                switch (listBox2.SelectedItem)
                {
                    case "Triangle":
                        label6.Visible = true;
                        label8.Visible = true;
                        label7.Visible = true;
                        textBox10.Visible = true;
                        textBox12.Visible = true;
                        textBox8.Visible = true;
                        break;
                    case "Rectangle":
                        label9.Visible = true;
                        label10.Visible = true;
                        textBox9.Visible = true;
                        textBox11.Visible = true;

                        break;
                    case "Circle":
                        textBox7.Visible = true;
                        label11.Visible = true;

                        break;
                }
            }
            else
            {
                label12.Text = "Please select either area or perimetre";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            switch (listBox2.SelectedItem)
            {
                case "Triangle":
                    double sideA = double.Parse(textBox8.Text);
                    double sideB = double.Parse(textBox10.Text);
                    double sideC = double.Parse(textBox12.Text);
                    double s = (sideA + sideB + sideC) / 2;
                    if ((s - sideA < 0) || (s - sideB < 0) || (s - sideC < 0))
                    {
                        label12.Text = "Thats not a triangle...";
                    }
                    else
                    {
                        if (radioButton5.Checked == true)
                        {
                            double area = Math.Sqrt(s * (s - sideA) * (s - sideB) * (s - sideC));
                            label12.Text = area.ToString();
                        }
                        else
                        {
                            double peri = sideA + sideB + sideC;
                            label12.Text = peri.ToString();
                        }
                    }
                    break;
                case "Rectangle":
                    double height = double.Parse(textBox9.Text);
                    double length = double.Parse(textBox11.Text);
                    if (radioButton5.Checked == true)
                    {
                        double area = height * length;
                        label12.Text = area.ToString();
                    }
                    else
                    {
                        double peri = (2 * height)+(2*length);
                        label12.Text = peri.ToString();
                    }
                    break;
                case "Circle":
                    double radius = double.Parse(textBox7.Text);
                    if (radioButton5.Checked == true)
                    {
                        double area = Math.PI * Math.Pow(radius, 2);
                        label12.Text = area.ToString();
                    }
                    else
                    {
                        double peri = 2 * Math.PI * radius;
                        label12.Text = peri.ToString();
                    }
                    break;

            }
        }
    }
}
