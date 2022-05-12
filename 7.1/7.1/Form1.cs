using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _7._1
{
/*
 label4
label15
label17
label19
label18
 */
    public partial class Form1 : Form
    {
        private Paralelogram mainObject;
        private bool choice;
        private int exhist = 0; // 0 - none; 1 - diamond; 2 - rectangle 

        public Form1()
        {
            InitializeComponent();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            groupBox2.Hide();
            groupBox3.Hide();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Show();
            groupBox2.Show();
            label2.Hide();
            textBox2.Hide();
            button1.Show();
            choice = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Show();
            groupBox2.Show();
            label2.Show();
            textBox2.Show();
            button1.Show();
            choice = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double side = double.Parse(textBox1.Text);

                if (!choice)
                {
                    double alpha = double.Parse(textBox3.Text);
                    mainObject = new Diamond(alpha, side);
                    exhist = 1;
                }
                else
                {
                    double height = double.Parse(textBox2.Text);
                    mainObject = new Rectangle(height, side);
                    exhist = 2;
                }

                Update();
                button1.Hide();
            }
            catch
            {
                MessageBox.Show("Введите корректные значения");
            }
        }

        private void Update()
        {
            label4.Text = mainObject.Side.ToString("0.00");
            label15.Text = mainObject.Diagonal.ToString("0.00");
            label17.Text = mainObject.Area.ToString("0.00");
            label19.Text = mainObject.Perimeter.ToString("0.00");
            label18.Text = mainObject.IsSquare ? "Да" : "Нет";
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            AnyTextBoxChanged();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            AnyTextBoxChanged();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            AnyTextBoxChanged();
        }
        
        private void AnyTextBoxChanged()
        {
            if (exhist != 0)
            {
                try
                {
                    mainObject.Width = double.Parse(textBox1.Text);
                    if (!choice)
                        mainObject.Alpha = double.Parse(textBox3.Text);
                    else
                        mainObject.Height = double.Parse(textBox2.Text);

                    Update();
                }
                catch
                {
                    MessageBox.Show("Введите корректные значения");
                }
            }
        }
    }
}
