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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double m = Convert.ToDouble(textBox1.Text);
            double g = 9.81;
            double h = Convert.ToDouble(textBox3.Text);

            // Вычисляем U1 и U2
            double U1 = m * g * h;

            // Суммируем U1 и U2 для получения общей энергии U
            
            textBox2.Text = U1.ToString(); // Выводим результат в textBox6
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = textBox1.Text; // Обновляем textBox4 при изменении textBox1
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox7.Text = textBox3.Text; // Обновляем textBox4 при изменении textBox1
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double m = Convert.ToDouble(textBox8.Text);
            double g = 9.81;
            double h = Convert.ToDouble(textBox10.Text);

            // Вычисляем U1 и U2
            
            double U2 = m * g * h;
            textBox11.Text = U2.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double U1 = Convert.ToDouble(textBox9.Text);
            double U2 = Convert.ToDouble(textBox12.Text);

            // Суммируем U1 и U2 для получения общей энергии U
            double U = U1 + U2;
            textBox13.Text = U.ToString();
            textBox4.Text = U.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Text = ""; // Очищаем textBox1
            textBox5.Text = ""; // Очищаем textBox4
            textBox1.Text = ""; // Очищаем textBox6
            textBox3.Text = ""; // Очищаем textBox6
            textBox2.Text = ""; // Очищаем textBox6
            textBox8.Text = ""; // Очищаем textBox6
            textBox10.Text = ""; // Очищаем textBox6
            textBox11.Text = ""; // Очищаем textBox6
            textBox2.Text = ""; // Очищаем textBox6
            textBox9.Text = ""; // Очищаем textBox6
            textBox12.Text = ""; // Очищаем textBox6
            textBox13.Text = ""; // Очищаем textBox6
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide(); // Скрываем текущую форму
                         // Предположим, что Form1 - это ваша главная форма
            Form1 mainForm = new Form1();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox9.Text = textBox2.Text;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            textBox12.Text = textBox11.Text;
        }
    }
}
