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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {
                   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double m = Convert.ToDouble(textBox1.Text);
            double v = Convert.ToDouble(textBox2.Text);

            // Вычисляем результат по формуле
            double result = 0.5 * m * Math.Pow(v, 2);
            textBox6.Text = result.ToString(); // Выводим результат в textBox6
            textBox3.Text = result.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = textBox1.Text; // Обновляем textBox4 при изменении textBox1
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = textBox2.Text; // Обновляем textBox4 при изменении textBox1
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = ""; // Очищаем textBox1
            textBox5.Text = ""; // Очищаем textBox4
            textBox6.Text = ""; // Очищаем textBox6
            textBox1.Text = ""; // Очищаем textBox6
            textBox3.Text = ""; // Очищаем textBox6
            textBox2.Text = ""; // Очищаем textBox6
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); // Скрываем текущую форму
                         // Предположим, что Form1 - это ваша главная форма
            Form1 mainForm = new Form1();
        }
    }
}
