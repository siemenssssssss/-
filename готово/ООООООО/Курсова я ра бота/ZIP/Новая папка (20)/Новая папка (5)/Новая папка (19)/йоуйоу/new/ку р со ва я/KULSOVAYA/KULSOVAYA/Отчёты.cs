using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace KULSOVAYA
{
    public partial class Отчёты : Form
    {
        private string connectionString;

        public Отчёты()
        {
            InitializeComponent();

            string databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "komandirovki.mdb"); // Или .accdb
            connectionString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={databasePath}"; // Или Provider=Microsoft.ACE.OLEDB.12.0 для .accdb

        }

        private void Отчёты_Load(object sender, EventArgs e)
        {
            LoadData();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();

        }
        private void LoadData()
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Ваш запрос для "КомандировкиЗапрос"
                    string query = "SELECT Регион, Суточные FROM Населенный_пункт"; // Или ваш актуальный запрос


                    using (OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView1.DataSource = dt;


                        Dictionary<string, decimal> sumsByRegion = new Dictionary<string, decimal>();

                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.IsNewRow) continue;

                            string region = row.Cells["Регион"].Value?.ToString();
                            decimal dailyAllowance;
                            if (decimal.TryParse(row.Cells["Суточные"].Value?.ToString(), out dailyAllowance))
                            {
                                if (sumsByRegion.ContainsKey(region))
                                {
                                    sumsByRegion[region] += dailyAllowance;
                                }
                                else
                                {
                                    sumsByRegion[region] = dailyAllowance;
                                }
                            }
                        }


                        string message = "";
                        foreach (var kvp in sumsByRegion)
                        {
                            message += $"{kvp.Key}: {kvp.Value:C}\n";
                        }
                        MessageBox.Show(message, "Сумма суточных по регионам");

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}