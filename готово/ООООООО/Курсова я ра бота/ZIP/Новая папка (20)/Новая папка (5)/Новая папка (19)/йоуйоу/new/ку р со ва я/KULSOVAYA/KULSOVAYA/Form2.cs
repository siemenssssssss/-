using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO; // Для File и Path

namespace KULSOVAYA
{
    public partial class Form2 : Form
    {
        private string connectionString; // Объявление без инициализации
        private int _selectedRowindex = -1; // Объявление вне методов
        private int _selectedEmployeeIndex = -1; // Индекс выбранной строки сотрудника



        public Form2()
        {

            InitializeComponent();

            string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "komandirovki.mdb");
            if (!File.Exists(databasePath))
            {
                MessageBox.Show($"Файл базы данных не найден: {databasePath}");
                return;
            }

            connectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={databasePath};";


            // Установите connectionString для каждого TableAdapter:
            командировкиTableAdapter.Connection.ConnectionString = connectionString;
            сотрудникиTableAdapter.Connection.ConnectionString = connectionString;
            населенный_пунктTableAdapter.Connection.ConnectionString = connectionString;
            расходыTableAdapter.Connection.ConnectionString = connectionString;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                this.командировкиTableAdapter.Fill(this.komandirovkiDataSet.Командировки);
                this.сотрудникиTableAdapter.Fill(this.komandirovkiDataSet.Сотрудники);
                this.населенный_пунктTableAdapter.Fill(this.komandirovkiDataSet.Населенный_пункт);
                this.расходыTableAdapter.Fill(this.komandirovkiDataSet.Расходы);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
            }
        }
        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string s = населенныйпунктBindingSource.Filter = "Регион Like \'" + textBox1.Text + "*\'" + "or Название Like \'" + textBox1.Text + "*\'" + "or Суточные Like \'" + textBox1.Text + "*\'";
            населенныйпунктBindingSource1.Filter = s;
        }

        private void добавлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string query = "INSERT INTO Населенный_пункт (Название, Суточные, Регион) VALUES (@Название, @Суточные, @Регион)";

            using (OleDbConnection dbConnection = new OleDbConnection(connectionString))
            {
                try
                {
                    dbConnection.Open();
                    using (OleDbCommand command = new OleDbCommand(query, dbConnection))
                    {
                        // Убрали int.TryParse
                        if (!string.IsNullOrEmpty(textBox2.Text)) // Проверка на пустое значение
                        {
                            command.Parameters.AddWithValue("@Название", textBox2.Text); // Текстовое значение напрямую
                            command.Parameters.AddWithValue("@Суточные", textBox5.Text);
                            command.Parameters.AddWithValue("@Регион", textBox6.Text);


                            int n = command.ExecuteNonQuery();
                            if (n > 0)
                            {
                                MessageBox.Show("Запись добавлена успешно!");
                                tabControl1.SelectedIndex = 0; // Переключение на первую вкладку
                                this.населенный_пунктTableAdapter.Fill(this.komandirovkiDataSet.Населенный_пункт); // Обновление DataGridView
                                textBox2.Clear(); // Очистка полей ввода
                                textBox5.Clear();
                                textBox6.Clear();

                                // Другой код, который вы хотите выполнить после успешной вставки, 
                            }
                            else
                            {
                                MessageBox.Show("Не удалось добавить запись.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ошибка: Поле 'Название' не должно быть пустым.");
                        }


                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении данных: {ex.Message}");
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string s = сотрудникиBindingSource.Filter = "ФИО Like \'" + textBox3.Text + "*\'" + "or Должность Like \'" + textBox3.Text + "*\'" + "or Отдел Like \'" + textBox3.Text + "*\'";
            сотрудникиBindingSource.Filter = s;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Сотрудники (ФИО, Должность, Отдел, Контактный_телефон, Дата_рожд) VALUES ( @ФИО, @Должность, @Отдел, @Контактный_телефон, @Дата_рожд)";

            using (OleDbConnection dbConnection = new OleDbConnection(connectionString))
            {
                try
                {
                    dbConnection.Open();
                    using (OleDbCommand command = new OleDbCommand(query, dbConnection))
                    {
                        // Проверка на пустые значения
                        if (
                            !string.IsNullOrEmpty(textBox7.Text) &&
                            !string.IsNullOrEmpty(textBox8.Text) &&
                            !string.IsNullOrEmpty(textBox9.Text) &&
                            !string.IsNullOrEmpty(textBox10.Text) &&
                            !string.IsNullOrEmpty(dateTimePicker1.Text)) // Проверка на пустое значение
                        {
                            
                            command.Parameters.AddWithValue("@ФИО", textBox7.Text);
                            command.Parameters.AddWithValue("@Должность", textBox8.Text);
                            command.Parameters.AddWithValue("@Отдел", textBox9.Text);
                            command.Parameters.AddWithValue("@Контактный_телефон", textBox10.Text);

                            // Преобразование текста в DateTime для даты рождения
                            if (DateTime.TryParse(dateTimePicker1.Text, out DateTime датаРожд))
                            {
                                command.Parameters.AddWithValue("@Дата_рожд", датаРожд);
                            }
                            else
                            {
                                MessageBox.Show("Ошибка: Неверный формат даты.");
                                return;
                            }

                            int n = command.ExecuteNonQuery();
                            if (n > 0)
                            {
                                MessageBox.Show("Запись добавлена успешно!");
                                tabControl1.SelectedIndex = 0; // Переключение на первую вкладку
                                this.сотрудникиTableAdapter.Fill(this.komandirovkiDataSet.Сотрудники); // Обновление DataGridView
                                

                                // Другой код, который вы хотите выполнить после успешной вставки,
                            }
                            else
                            {
                                MessageBox.Show("Не удалось добавить запись.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ошибка: Все поля должны быть заполнены.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при добавлении данных: {ex.Message}");
                }
            }
        }

        private void удалениеToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // 1. Используем Dictionary для хранения информации о таблицах
            var tableInfo = new Dictionary<DataGridView, Tuple<string, string, OleDbDataAdapter>>()
{
    { dataGridView2, Tuple.Create("Сотрудники", "Код_Сотрудника", this.сотрудникиTableAdapter.Adapter) },
    { dataGridView3, Tuple.Create("Населенный_пункт", "Код_Населенного_пункта", this.населенный_пунктTableAdapter.Adapter) }
};

            // 2. Определяем активный DataGridView и получаем информацию о таблице
            if (!tableInfo.TryGetValue(GetActiveDataGridView(dataGridView2, dataGridView3), out var info))
            {
                MessageBox.Show("Выберите таблицу для удаления записи.");
                return;
            }

            var (tableName, idColumnName, tableAdapter) = info;
            var activeDataGridView = tableInfo.FirstOrDefault(x => x.Value == info).Key;


            // 3. Проверяем выбранную строку и получаем ID
            if (activeDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите запись для удаления.");
                return;
            }

            if (!int.TryParse(activeDataGridView.SelectedRows[0].Cells[0].Value?.ToString()?.Trim(), out int selectedId))
            {
                MessageBox.Show("Пожалуйста, выберите запись, в которой заполнен ID.");
                return;
            }


            // 4. Подтверждение удаления
            if (MessageBox.Show("Вы уверены, что хотите удалить запись?", "Подтверждение", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;


            // 5. Выполняем запрос на удаление
            try
            {
                using (var dbConnection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=komandirovki.mdb"))
                {
                    try
                    {
                        dbConnection.Open(); // Попытка открыть соединение

                        using (var command = new OleDbCommand($"DELETE FROM [{tableName}] WHERE {idColumnName} = @{idColumnName}", dbConnection))
                        {
                            command.Parameters.AddWithValue($"@{idColumnName}", selectedId);
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Запись удалена успешно!");
                                tableAdapter.Fill(this.komandirovkiDataSet.Tables[tableName]); // Обновляем DataGridView
                            }
                            else
                            {
                                MessageBox.Show("Не удалось удалить запись. Проверьте, существует ли она.");
                            }
                        }
                    }
                    catch (OleDbException ex) // Ловим специфические ошибки подключения
                    {
                        MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при удалении записи: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        private DataGridView GetActiveDataGridView(params DataGridView[] dataGridViews)
        {
            foreach (var dgv in dataGridViews)
                if (dgv.Focused) return dgv;
            return null;
        }

        private void button3_Click(object sender, EventArgs e)
        {


        }

        private void редактированиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3.Visible = !button3.Visible; // Переключает 
            button4.Visible = !button4.Visible; // Переключает 
            button5.Visible = !button5.Visible; // Переключает 
            button6.Visible = !button6.Visible; // Переключает 
            label2.Visible = !label2.Visible; // Переключает 
            label10.Visible = !label10.Visible; // Переключает 
        }


        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = checkBox1.Checked;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {

                _selectedRowindex = dataGridView3.SelectedRows[0].Index;

                // Заполняем текстовые поля значениями из выбранной строки
                textBox2.Text = dataGridView3.SelectedRows[0].Cells["Название"].Value.ToString();
                textBox5.Text = dataGridView3.SelectedRows[0].Cells["Суточные"].Value.ToString();
                textBox6.Text = dataGridView3.SelectedRows[0].Cells["Регион"].Value.ToString();

                // Делаем текстовые поля доступными для редактирования
                textBox2.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = true;

                
            }
            else
            {
                MessageBox.Show("Выберите строку для редактирования.");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (_selectedRowindex != -1)
            {

                try
                {

                    using (OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\komandirovki.mdb"))
                    {
                        connection.Open();

                        string query = "UPDATE Населенный_пункт SET Название = @Название, Суточные = @Суточные, Регион = @Регион WHERE Код_Населенного_пункта = @Код_Населенного_пункта";


                        using (OleDbCommand command = new OleDbCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Название", textBox2.Text);

                            if (decimal.TryParse(textBox5.Text, out decimal суточные))
                            {
                                command.Parameters.AddWithValue("@Суточные", суточные);
                            }
                            else
                            {
                                command.Parameters.AddWithValue("@Суточные", DBNull.Value); // Или другое значение по умолчанию
                                MessageBox.Show("Некорректное значение для 'Суточные'.");
                                return; // Прерываем выполнение, если значение некорректно
                            }

                            command.Parameters.AddWithValue("@Регион", textBox6.Text);
                            command.Parameters.AddWithValue("@Код_Населенного_пункта", dataGridView3.Rows[_selectedRowindex].Cells["Код_Населенного_пункта"].Value);

                            command.ExecuteNonQuery();
                        }
                    }



                    MessageBox.Show("Изменения сохранены.");

                    


                    // Очищаем текстовые поля и сбрасываем индекс выбранной строки
                    textBox2.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    _selectedRowindex = -1;


                    textBox2.Enabled = false;
                    textBox5.Enabled = false;
                    textBox6.Enabled = false;

                    


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении изменений: " + ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                _selectedEmployeeIndex = dataGridView2.SelectedRows[0].Index;

                // Заполняем поля данными из выбранной строки
                textBox7.Text = dataGridView2.SelectedRows[0].Cells["ФИО"].Value.ToString();
                textBox8.Text = dataGridView2.SelectedRows[0].Cells["Должность"].Value.ToString();
                textBox9.Text = dataGridView2.SelectedRows[0].Cells["Отдел"].Value.ToString();
                textBox10.Text = dataGridView2.SelectedRows[0].Cells["Контактный_телефон"].Value.ToString();
                dateTimePicker1.Value = Convert.ToDateTime(dataGridView2.SelectedRows[0].Cells["Дата_рожд"].Value);


                // Включаем редактирование полей
                textBox7.Enabled = true;
                textBox8.Enabled = true;
                textBox9.Enabled = true;
                textBox10.Enabled = true;
                dateTimePicker1.Enabled = true;

                // Показываем кнопку "Сохранить" и скрываем кнопку "Редактировать"
               

            }
            else
            {
                MessageBox.Show("Выберите строку для редактирования.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (_selectedEmployeeIndex != -1)
            {
                try
                {
                    using (OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\komandirovki.mdb"))
                    {
                        connection.Open();

                        string query = "UPDATE Сотрудники SET ФИО = @ФИО, Должность = @Должность, Отдел = @Отдел, Контактный_телефон = @Контактный_телефон, Дата_рожд = @Дата_рожд WHERE Код_Сотрудника = @Код_Сотрудника";

                        using (OleDbCommand command = new OleDbCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ФИО", textBox7.Text);
                            command.Parameters.AddWithValue("@Должность", textBox8.Text);
                            command.Parameters.AddWithValue("@Отдел", textBox9.Text);
                            command.Parameters.AddWithValue("@Контактный_телефон", textBox10.Text);
                            command.Parameters.AddWithValue("@Дата_рожд", dateTimePicker1.Value);
                            command.Parameters.AddWithValue("@Код_Сотрудника", dataGridView2.Rows[_selectedEmployeeIndex].Cells["Код_Сотрудника"].Value);

                            command.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Изменения сохранены.");

                    

                    // Очищаем поля и сбрасываем индекс
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    textBox10.Clear();
                    dateTimePicker1.Value = DateTime.Now; // Или другое значение по умолчанию
                    _selectedEmployeeIndex = -1;


                    // Выключаем редактирование и скрываем/показываем кнопки
                    textBox7.Enabled = false;
                    textBox8.Enabled = false;
                    textBox9.Enabled = false;
                    textBox10.Enabled = false;
                    dateTimePicker1.Enabled = false;

                 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при сохранении изменений: " + ex.Message);
                }
            }
        }
    }
    }
    
    

        
    
  
    

