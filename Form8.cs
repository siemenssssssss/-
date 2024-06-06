using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LBLBLBLBLBLBLBLBLBLBLBLBLBLBLBLBLBLB
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double S = Convert.ToDouble(textBox1.Text);
            double v = Convert.ToDouble(textBox2.Text);
            double t = Convert.ToDouble(textBox3.Text);

            double a = 2 * (S - v * t) / (t * t);

            textBox5.Text = a.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text = textBox1.Text; // Обновляем textBox6 при изменении textBox1
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox7.Text = textBox2.Text; // Обновляем textBox7 при изменении textBox2
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox9.Text = textBox8.Text = textBox3.Text; // Обновляем textBox9 и textBox8 при изменении textBox3
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = textBox4.Text; // Обновляем textBox5 при изменении textBox4
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = textBox5.Text; // Обновляем textBox5 при изменении textBox4
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = ""; // Очищаем textBox1
            textBox5.Text = ""; // Очищаем textBox4
            textBox6.Text = ""; // Очищаем textBox6
            textBox1.Text = ""; // Очищаем textBox6
            textBox3.Text = ""; // Очищаем textBox6
            textBox2.Text = ""; // Очищаем textBox6
            textBox9.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); // Скрываем текущую форму
                         // Предположим, что Form1 - это ваша главная форма
            Form1 mainForm = new Form1();
        }
    }
}
