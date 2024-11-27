using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System;
using System.IO;

namespace KULSOVAYA.Controller
{
    public class Query
    {
        public string connectionString;
        private OleDbConnection connection;

        public Query()
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string databasePath = Path.Combine(appPath, "komandirovki.mdb");
            connectionString = $@"Provider=Microsoft.Jet.OLEDB.4.0; Data Source={databasePath}";

            connection = new OleDbConnection(connectionString);
        }

        public void OpenConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при открытии соединения: {ex.Message}");
            }
        }

        internal DataTable GetTipRashoda()
        {
            throw new NotImplementedException();
        }

        public void CloseConnection()
        {
            try
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при закрытии соединения: {ex.Message}");
            }
        }

        public void Add(int kodSotrudnika, string celPoezdki, int mestoNaznacheniya, decimal predpolagaemyeRashody, DateTime dataNachala, DateTime dataOkonchaniya, DataGridView dataGridView1)
        {
            try
            {
                using (var connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO Командировки (Код_Сотрудника, Цель_поездки, Место_назначения, Предполагаемые_расходы, Дата_начала, Дата_окончания) " +
                                   "VALUES (@Код_Сотрудника, @Цель_поездки, @Место_назначения, @Предполагаемые_расходы, @Дата_начала, @Дата_окончания)";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Код_Сотрудника", kodSotrudnika);
                        command.Parameters.AddWithValue("@Цель_поездки", celPoezdki);
                        command.Parameters.AddWithValue("@Место_назначения", mestoNaznacheniya);
                        command.Parameters.AddWithValue("@Предполагаемые_расходы", predpolagaemyeRashody);
                        command.Parameters.AddWithValue("@Дата_начала", dataNachala);
                        command.Parameters.AddWithValue("@Дата_окончания", dataOkonchaniya);

                        command.ExecuteNonQuery();
                    }

                    dataGridView1.DataSource = GetData("Командировки"); // Или "КомандировкиЗапрос"
                }
            }
            catch (OleDbException ex)
            {
                string errorMessage = $"Ошибка при добавлении данных: {ex.Message}\n" +
                                      $"Код ошибки: {ex.ErrorCode}\n" +
                                      $"Источник ошибки: {ex.Source}";
                MessageBox.Show(errorMessage, "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GetSotrudniki()
        {
            try
            {
                OpenConnection();
                string query = "SELECT Код_Сотрудника, ФИО FROM Сотрудники";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении списка сотрудников: " + ex.Message);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataTable GetData(string tableName, string filter = "")
        {
            try
            {
                OpenConnection();
                string query = $"SELECT * FROM {tableName}";
                if (!string.IsNullOrEmpty(filter))
                {
                    query += $" WHERE {filter}";
                }

                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (OleDbException ex)
            {

                string errorMessage = $"Ошибка при получении данных: {ex.Message}\n" +
                                      $"Код ошибки: {ex.ErrorCode}\n" +
                                       $"Источник ошибки: {ex.Source}";

                MessageBox.Show(errorMessage, "Ошибка базы данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void UpdateDataGrid(DataGridView dataGridView, string tableName, string filter = "")
        {
            try
            {
                DataTable dataTable = GetData(tableName, filter);
                dataGridView.DataSource = dataTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении DataGridView: {ex.Message}");
            }
        }


        public bool ExecuteNonQuery(string query, OleDbParameter[] parameters = null)
        {
            try
            {
                OpenConnection();
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    int rowsAffected = command.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при выполнении запроса: {ex.Message}");
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }
        public void UpdateQuery(int kod_kom, int kodSotrudnika, DateTime dataNachala, DateTime dataOkonchaniya, string celPoezdki, int? mestoNaznacheniya, decimal? predpolagaemyeRashody)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (OleDbCommand command = new OleDbCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = "UPDATE Командировки SET " +
                                              "Код_Сотрудника = @Код_Сотрудника, " +
                                              "Дата_начала = @Дата_начала, " +
                                              "Дата_окончания = @Дата_окончания, " +
                                              "Цель_поездки = @Цель_поездки, " +
                                              "Место_назначения = @Место_назначения, " +
                                              "Предполагаемые_расходы = @Предполагаемые_расходы " +
                                              "WHERE Код_командировки = @Код_командировки";

                    command.Parameters.AddWithValue("@Код_Сотрудника", kodSotrudnika);
                    command.Parameters.AddWithValue("@Дата_начала", dataNachala);
                    command.Parameters.AddWithValue("@Дата_окончания", dataOkonchaniya);
                    command.Parameters.AddWithValue("@Цель_поездки", celPoezdki);

                    // Обработка null для Место_назначения
                    command.Parameters.AddWithValue("@Место_назначения", mestoNaznacheniya == null ? DBNull.Value : (object)mestoNaznacheniya);

                    // Обработка null для Предполагаемые_расходы
                    command.Parameters.AddWithValue("@Предполагаемые_расходы", predpolagaemyeRashody == null ? DBNull.Value : (object)predpolagaemyeRashody);

                    command.Parameters.AddWithValue("@Код_командировки", kod_kom);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Вместо MessageBox лучше выбросить исключение
                throw new Exception("Ошибка при обновлении записи: ", ex); // Более информативный вывод ошибки
            }
        }



        public int GetLastInsertedId()
        {
            using (var connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (var command = new OleDbCommand("SELECT @@IDENTITY", connection))
                {
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public DataTable GetDataById(string query, OleDbParameter[] parameters = null)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                using (OleDbCommand command = new OleDbCommand(query, connection)) using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }

            }
            catch (Exception ex)
            {

                throw new Exception("Ошибка при получении данных: " + ex.Message);

            }

        }
        public void AddRashod(string tipRashoda, decimal summa, DateTime dataRashoda)
        {
            // Замените строку подключения на вашу
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=komandirovki.mdb";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "INSERT INTO Расходы (Тип_расхода, Сумма, Дата_расхода) VALUES (@Тип_расхода, @Сумма, @Дата_расхода)";

                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    // Указание типов параметров и задание их значений
                    command.Parameters.Add("@Тип_расхода", OleDbType.VarChar).Value = tipRashoda; // Короткий текст
                    command.Parameters.Add("@Сумма", OleDbType.Currency).Value = summa; // Денежный
                    command.Parameters.Add("@Дата_расхода", OleDbType.Date).Value = dataRashoda; // Дата и время

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (OleDbException ex)
                    {
                        // Обработка исключений базы данных
                        MessageBox.Show("Ошибка базы данных: " + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        // Обработка других исключений
                        MessageBox.Show("Произошла ошибка: " + ex.Message);
                    }
                }
            }
        }
        public DataTable GetR()
        {
            try
            {
                OpenConnection();
                string query = "SELECT Тип_расхода, Тип_расхода FROM Расходы";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении списка сотрудников: " + ex.Message);
                return null;
            }
            finally
            {
                CloseConnection();
            }
        }
        public DataTable GetL()
        {
            try
            {
                OpenConnection();
                string query = "SELECT Код_Командировки, Код_Командировки FROM Командировки";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении списка сотрудников: " + ex.Message);
                return null;
            }
            finally
            {
                CloseConnection();
            }
    
        }
        
    
    }
}

