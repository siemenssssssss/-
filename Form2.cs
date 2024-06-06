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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double L = double.Parse(textBox1.Text); // Получаем значение L из текстового поля
            double g = 9.81; // Задаем значение ускорения свободного падения
            double Pi = Math.PI; // Задаем значение числа Пи

            double result = 2 * Pi * Math.Sqrt(L / g); // Вычисляем результат по формуле

            textBox6.Text = result.ToString(); // Выводим результат в textBox6
            textBox3.Text = result.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = textBox1.Text; // Обновляем textBox4 при изменении textBox1
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; // Очищаем textBox1
            textBox4.Text = ""; // Очищаем textBox4
            textBox6.Text = ""; // Очищаем textBox6
            textBox3.Text = ""; // Очищаем textBox6
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide(); // Скрываем текущую форму
                         // Предположим, что Form1 - это ваша главная форма
            Form1 mainForm = new Form1();
            
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
        
    

