using KULSOVAYA.Controller;
using System;
using System.Data;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Linq;
using System.Globalization;

namespace KULSOVAYA
{
    public partial class Form1 : Form
    {
        private Query controller;
        private BindingSource bindingSource1 = new BindingSource();
        private OleDbConnection connection;
        private int mode = 0;
        private int n;
        private object tipRashoda;
        private object summa;
        private object dataRashoda;


        public Form1()
        {
            InitializeComponent();
            LoadTipRashoda();

            controller = new Query();
            connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=komandirovki.mdb");
            try
            {
                connection.Open();

                // Загрузка данных в comboBox3
                DataTable dtSotrudniki = controller.GetSotrudniki();
                if (dtSotrudniki != null)
                {
                    comboBox3.DataSource = dtSotrudniki;
                    comboBox3.DisplayMember = "ФИО";
                    comboBox3.ValueMember = "Код_Сотрудника";


                    DataTable R = controller.GetR();
                    if (R != null)
                    {
                        comboBox1.DataSource = R;
                        comboBox1.DisplayMember = "Тип_расхода";
                        comboBox1.ValueMember = "Тип_расхода";

                    }
                    DataTable L = controller.GetL();
                    if (L != null)
                    {
                        comboBox2.DataSource = L;
                        comboBox2.DisplayMember = "Код_Командировки";
                        comboBox2.ValueMember = "Код_Командировки";

                    }
                   

                    // Инициализация DataGridView
                    dataGridView1.DataSource = controller.GetData("КомандировкиЗапрос");
                    dataGridView2.DataSource = controller.GetData("Командировки"); // Загрузка данных в DataGridView2

                    // Загрузка данных в TreeView (уникальные отделы)
                    TreeNode rootNode = new TreeNode("Название отделов");
                    if (komandirovkiDataSet1?.Сотрудники != null)
                    {
                        var uniqueDepartments = komandirovkiDataSet1.Сотрудники.AsEnumerable()
                            .Select(row => row.Field<string>("Отдел"))
                            .Where(department => !string.IsNullOrEmpty(department))
                            .Distinct()
                            .OrderBy(department => department);

                        foreach (string department in uniqueDepartments)
                        {
                            rootNode.Nodes.Add(new TreeNode(department));
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при инициализации формы: " + ex.Message);
            }
        }


        private void button7_Click(object sender, EventArgs e) // Фильтрация
        {
            DataTable dt = dataGridView1.DataSource as DataTable;
            if (dt == null)
            {
                MessageBox.Show("DataSource is not a DataTable.");
                return;
            }

            string fioFilter = textBox12.Text;
            string отделFilter = textBox11.Text; // Теперь это фильтр по Названию отдела
            string должностьFilter = textBox10.Text; // Теперь это фильтр по Региону

            string filterExpression = "";

            if (checkBox7.Checked && !string.IsNullOrEmpty(fioFilter))
            {
                filterExpression += $"[ФИО] LIKE '%{fioFilter}%'";
            }

            // Фильтрация по Названию отдела
            if (checkBox6.Checked && !string.IsNullOrEmpty(отделFilter))
            {
                if (!string.IsNullOrEmpty(filterExpression))
                {
                    filterExpression += " AND ";
                }
                filterExpression += $"[Название] LIKE '%{отделFilter}%'"; // Фильтруем по Названию
            }


            // Фильтрация по Региону
            if (checkBox5.Checked && !string.IsNullOrEmpty(должностьFilter))
            {
                if (!string.IsNullOrEmpty(filterExpression))
                {
                    filterExpression += " AND ";
                }
                filterExpression += $"[Регион] LIKE '%{должностьFilter}%'"; // Фильтруем по Региону
            }


            // Фильтрация по дате (только если checkBox4 отмечен)
            if (checkBox4.Checked)
            {
                DateTime startDate;
                DateTime endDate;
                if (!DateTime.TryParse(textBox9.Text, out startDate) || !DateTime.TryParse(textBox8.Text, out endDate))
                {
                    MessageBox.Show("Введите корректные даты.");
                    checkBox4.Checked = false;
                    return;
                }
                if (startDate > endDate)
                {
                    MessageBox.Show("Начальная дата не может быть больше конечной.");
                    checkBox4.Checked = false;
                    return;
                }
                if (!string.IsNullOrEmpty(filterExpression))
                {
                    filterExpression += " AND ";
                }
                filterExpression += $"[Дата_начала] >= #{startDate.ToShortDateString()}# AND [Дата_окончания] <= #{endDate.ToShortDateString()}#";
            }

            // Применение фильтра
            try
            {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = filterExpression;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при фильтрации: {ex.Message}");
            }




            bindingSource1.DataSource = dt;
            dataGridView1.DataSource = bindingSource1;

            bindingSource1.Filter = filterExpression;

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Rows[0].Selected = true;
            }
        }



        private void button1_Click_1(object sender, EventArgs e) // Добавление записи
        {
            try
            {
                int kodSotrudnika = (int)comboBox3.SelectedValue;
                string celPoezdki = textBox1.Text;

                if (!int.TryParse(textBox3.Text, out int mestoNaznacheniya))
                {
                    MessageBox.Show("Некорректное значение для 'Место назначения'. Введите число.");
                    return;
                }

                if (!decimal.TryParse(textBox2.Text, out decimal predpolagaemyeRashody))
                {
                    MessageBox.Show("Некорректное значение для 'Предполагаемые расходы'. Введите число.");
                    return;
                }

                // Получаем значения даты начала и окончания
                DateTime dataNachala;
                DateTime dataOkonchaniya;

                if (!DateTime.TryParse(dateTimePicker1.Text, out dataNachala)) // textBox4 для даты начала
                {
                    MessageBox.Show("Некорректный формат даты начала.");
                    return;
                }

                if (!DateTime.TryParse(dateTimePicker2.Text, out dataOkonchaniya)) // textBox5 для даты окончания
                {
                    MessageBox.Show("Некорректный формат даты окончания.");
                    return;
                }

                // Передаем dataGridView2 в метод Add
                controller.Add(kodSotrudnika, celPoezdki, mestoNaznacheniya, predpolagaemyeRashody, dataNachala, dataOkonchaniya, dataGridView1);

                MessageBox.Show("Запись добавлена!");

                // Обновление dataGridView1
                dataGridView1.DataSource = controller.GetData("КомандировкиЗапрос");

                // Если нужно обновить dataGridView2 (например, если он отображает связанные расходы)
                // dataGridView2.DataSource = controller.GetData("Расходы"); // или другой соответствующий запрос
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Ошибка базы данных: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|komandirovki.mdb";

                // Изменяем запрос на выборку расходов по коду сотрудника
                string query = "SELECT * FROM Расходы WHERE Код_Командировки = @Код_Командировки";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    var kodSotrudnika = selectedRow.Cells["Код_Командировки"].Value;
                    MessageBox.Show($"Выбранный Код Командировки: {kodSotrudnika}"); // Для отладки

                    // Добавляем параметр с кодом сотрудника
                    command.Parameters.AddWithValue("@Код_Сотрудника", Convert.ToInt32(kodSotrudnika));

                    try
                    {
                        connection.Open();
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView2.DataSource = dt; // Заполняем dataGridView2 данными о расходах

                            if (dt.Rows.Count == 0)
                            {
                                MessageBox.Show("Нет расходов для выбранного сотрудника.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                }
            }
            else
            {
                dataGridView2.DataSource = null; // Очищаем DataGridView2, если ничего не выбрано
                MessageBox.Show("Выберите строку в dataGridView1.");
            }
        }


        private void справочникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 Form2 = new Form2();
            Form2.Show();
        }


        public DataTable GetData(string tableName)
        {
            try
            {
                string query = $"SELECT * FROM {tableName}"; // SQL запрос для выбора всех данных из таблицы
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (OleDbException ex)
            {
                throw new Exception("Ошибка при получении данных: " + ex.Message);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\komandirovki.mdb;";
                this.расходыTableAdapter.Connection = new OleDbConnection(connectionString); // Устанавливаем строку подключения
                this.расходыTableAdapter.Fill(this.komandirovkiDataSet.Расходы);
                dataGridView2.DataSource = this.komandirovkiDataSet.Расходы; // Привязка данных к DataGridView
                dataGridView2.AutoGenerateColumns = true;
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                mode = 1; // Устанавливаем режим редактирования
                n = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Код_командировки"].Value);
                panel1.Visible = true;
                LoadEditData(n);
            }
            else
            {
                MessageBox.Show("Выберите запись для редактирования.");
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            {

            }
        }
        private void LoadEditData(int kod_kom)
        {
            try
            {
                // Используем параметризованный запрос
                using (OleDbConnection connection = new OleDbConnection(controller.connectionString))
                using (OleDbCommand command = new OleDbCommand("SELECT * FROM Командировки WHERE Код_командировки = @Код_командировки", connection))
                {
                    command.Parameters.AddWithValue("@Код_командировки", kod_kom);
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            comboBox3.SelectedValue = reader.GetInt32(reader.GetOrdinal("Код_Сотрудника"));
                            dateTimePicker1.Value = reader.GetDateTime(reader.GetOrdinal("Дата_начала"));
                            dateTimePicker2.Value = reader.GetDateTime(reader.GetOrdinal("Дата_окончания"));
                            textBox1.Text = reader.GetString(reader.GetOrdinal("Цель_поездки"));

                            // Проверяем на DBNull перед преобразованием
                            if (!reader.IsDBNull(reader.GetOrdinal("Место_назначения")))
                            {
                                textBox3.Text = reader.GetInt32(reader.GetOrdinal("Место_назначения")).ToString();
                            }
                            else
                            {
                                textBox3.Text = ""; // Или другое значение по умолчанию
                            }

                            if (!reader.IsDBNull(reader.GetOrdinal("Предполагаемые_расходы")))
                            {
                                textBox2.Text = reader.GetDecimal(reader.GetOrdinal("Предполагаемые_расходы")).ToString();
                            }
                            else
                            {
                                textBox2.Text = ""; // Или другое значение по умолчанию
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (mode == 0) // Добавление новой записи
                {
                    // ... (ваш код для добавления новой записи)
                }
                else if (mode == 1) // Редактирование существующей записи
                {
                    int kodKom = n; // n содержит Код_командировки редактируемой записи

                    int kodSotrudnika = (int)comboBox3.SelectedValue;
                    DateTime dataNachala = dateTimePicker1.Value;
                    DateTime dataOkonchaniya = dateTimePicker2.Value;
                    string celPoezdki = textBox1.Text;

                    // Безопасное преобразование текста в числа с учетом возможности null
                    int parsedMesto;
                    int? mestoNaznacheniya = int.TryParse(textBox3.Text, out parsedMesto) ? (int?)parsedMesto : null;

                    decimal parsedRashody;
                    decimal? predpolagaemyeRashody = decimal.TryParse(textBox2.Text, out parsedRashody) ? parsedRashody : default(decimal?);


                    // Вызов UpdateQuery с nullable типами
                    controller.UpdateQuery(kodKom, kodSotrudnika, dataNachala, dataOkonchaniya, celPoezdki, mestoNaznacheniya, predpolagaemyeRashody);

                    MessageBox.Show("Изменения сохранены!");
                    dataGridView2.DataSource = controller.GetData("Командировки"); // Обновление DataGridView
                    panel1.Visible = false; // Закрытие панели редактирования
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.ToString()); // Обработка исключений
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dcsdToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string tipRashoda = comboBox1.Text; // Получаем тип расхода
            if (!decimal.TryParse(textBox4.Text, out decimal summa))
            {
                MessageBox.Show("Некорректное значение для 'Сумма'. Введите число.");
                return;
            }

            DateTime dataRashoda = dateTimePicker1.Value; // Получаем дату напрямую

            // Здесь нужно получить ID командировки. Предположим, что вы используете comboBox для выбора командировки.
            if (comboBox2.SelectedValue is int idKomandirovki) // Убедитесь, что вы используете правильный способ получения ID
            {
                // Вызов метода для добавления расхода
                AddRashod(tipRashoda, summa, dataRashoda, idKomandirovki);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите командировку из списка.");
            }
        }
            public void AddRashod(string tipRashoda, decimal summa, DateTime dataRashoda, int idKomandirovki)
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=komandirovki.mdb";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                // Проверка существования командировки
                string checkQuery = "SELECT COUNT(*) FROM Командировки WHERE ID = @ID";
                using (OleDbCommand checkCommand = new OleDbCommand(checkQuery, connection))
                {
                    checkCommand.Parameters.Add("@ID", OleDbType.Integer).Value = idKomandirovki;

                    connection.Open();
                    int count = (int)checkCommand.ExecuteScalar();
                    if (count == 0)
                    {
                        MessageBox.Show("Запись о командировке не найдена. Проверьте данные.");
                        return;
                    }
                }

                // Выполнение вставки
                string query = "INSERT INTO Расходы (Тип_расхода, Сумма, Дата_расхода, Код_Командировки) VALUES (@Тип_расхода, @Сумма, @Дата_расхода, @Код_Командировки)";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.Add("@Тип_расхода", OleDbType.VarChar).Value = tipRashoda;
                    command.Parameters.Add("@Сумма", OleDbType.Currency).Value = summa;
                    command.Parameters.Add("@Дата_расхода", OleDbType.Date).Value = dataRashoda;
                    command.Parameters.Add("@ID_Командировки", OleDbType.Integer).Value = idKomandirovki; // добавляем ID командировки

                    try
                    {
                        command.ExecuteNonQuery();
                        MessageBox.Show("Расход добавлен!");
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Ошибка базы данных: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Произошла ошибка: " + ex.Message);
                    }
                }
            }
        }



        private void LoadTipRashoda()
        {
         
        }
            private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                mode = 1; // Устанавливаем режим редактирования
                n = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["Код_Расхода"].Value);
                panel2.Visible = true;
                LoadEdit(n);
            }
            else
            {
                MessageBox.Show("Выберите запись для редактирования.");
            }
        }
        private void LoadEdit(int kod_rashoda)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(controller.connectionString))
                using (OleDbCommand command = new OleDbCommand("SELECT * FROM Расходы WHERE Код_Расхода = @Код_Расхода", connection))
                {
                    command.Parameters.AddWithValue("@Код_Расхода", kod_rashoda);
                    connection.Open();
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // GetInt32 для Код_Командировки (предполагается, что это число)
                            comboBox2.SelectedValue = reader.GetInt32(reader.GetOrdinal("Код_Командировки"));

                            // GetString для Тип_расхода, если это строка, или соответствующий тип данных
                            // (например, int, если это код типа расхода)
                            // **ВАЖНО:** Убедитесь, что comboBox1 заполнен значениями, соответствующими типу данных в базе.
                            comboBox1.SelectedValue = Convert.ChangeType(reader["Тип_расхода"], comboBox1.ValueMember.GetType());



                            // GetDecimal для Сумма, так как это денежная величина
                            textBox4.Text = reader.GetDecimal(reader.GetOrdinal("Сумма")).ToString();

                            // GetDateTime для Дата_расхода
                            dateTimePicker3.Value = reader.GetDateTime(reader.GetOrdinal("Дата_расхода"));



                            // textBox3 и textBox2 - обработка DBNull та же


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке данных: " + ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(controller.connectionString))
                using (OleDbCommand command = new OleDbCommand("UPDATE Расходы SET Код_Командировки = ?, Тип_расхода = ?, Сумма = ?, Дата_расхода = ? WHERE Код_Расхода = ?", connection))
                {
                    command.Parameters.Add(new OleDbParameter("@Код_Командировки", OleDbType.Integer) { Value = (int)comboBox2.SelectedValue }); // Приведение типа обязательно
                    command.Parameters.Add(new OleDbParameter("@Тип_расхода", OleDbType.VarWChar) { Value = comboBox1.SelectedValue?.ToString() });
                    command.Parameters.Add(new OleDbParameter("@Сумма", OleDbType.Decimal) { Value = Convert.ToDecimal(textBox4.Text) }); // Или попробуйте double
                    command.Parameters.Add(new OleDbParameter("@Дата_расхода", OleDbType.Date) { Value = dateTimePicker3.Value });
                    command.Parameters.Add(new OleDbParameter("@Код_Расхода", OleDbType.Integer) { Value = n }); // n ДОЛЖЕН быть int


                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Запись успешно изменена.");
                        // Обновляем DataGridView
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Расходы", connection))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dataGridView2.DataSource = dt;
                        }
                    } // <-- Перемещено сюда
                    else
                    {
                        MessageBox.Show("Запись не найдена или не изменена.");
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show($"Ошибка базы данных: {ex.Message}\n{ex.StackTrace}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Общая ошибка: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void отчToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Отчёты Отчёты = new Отчёты();
            Отчёты.Show();
        }
    }

}