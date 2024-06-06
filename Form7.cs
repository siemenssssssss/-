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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Объявляем переменные для хранения значений a, m и Fтр
            double a, m, Fтр;

            // Преобразуем введенные пользователем значения из текстовых полей в числа
            a = Convert.ToDouble(textBox1.Text);
            m = Convert.ToDouble(textBox3.Text);
            Fтр = Convert.ToDouble(textBox2.Text);

            // Вычисляем значение Fрез по заданной формуле
            double Fрез = (m * a) + Fтр;

            // Отображаем результат вычислений
            textBox4.Text = Fрез.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = textBox1.Text; // Обновляем textBox5 при изменении textBox1
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text = textBox3.Text; // Обновляем textBox6 при изменении textBox3
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox7.Text = textBox2.Text; // Обновляем textBox7 при изменении textBox2
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox8.Text = textBox4.Text; // Обновляем textBox8 при изменении textBox4
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; // Очищаем textBox6
            textBox3.Text = ""; // Очищаем textBox6
            textBox2.Text = ""; // Очищаем textBox6
            textBox8.Text = ""; // Очищаем textBox6
            textBox4.Text = ""; // Очищаем textBox6
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
        