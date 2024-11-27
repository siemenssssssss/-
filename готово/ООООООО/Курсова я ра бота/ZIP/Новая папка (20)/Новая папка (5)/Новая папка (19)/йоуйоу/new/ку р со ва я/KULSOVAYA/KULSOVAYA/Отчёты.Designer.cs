
namespace KULSOVAYA
{
    partial class Отчёты
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.komandirovkiDataSet = new KULSOVAYA.komandirovkiDataSet();
            this.расходыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.расходыTableAdapter = new KULSOVAYA.komandirovkiDataSetTableAdapters.РасходыTableAdapter();
            this.общаяИнформацияBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.общая_информацияTableAdapter = new KULSOVAYA.komandirovkiDataSetTableAdapters.Общая_информацияTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.командировкиЗапросBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.командировкиЗапросTableAdapter = new KULSOVAYA.komandirovkiDataSetTableAdapters.КомандировкиЗапросTableAdapter();
            this.командировкиЗапросBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.Регион = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Суточные = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.кодКомандировкиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.фИОDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.кодСотрудникаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.цельпоездкиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаначалаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаокончанияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.местоНазначенияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.предполагаемыерасходыDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.названиеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.регионDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.суточныеDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.komandirovkiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.расходыBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.общаяИнформацияBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.командировкиЗапросBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.командировкиЗапросBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(735, 377);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(727, 348);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Расходы";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(727, 348);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Период";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // komandirovkiDataSet
            // 
            this.komandirovkiDataSet.DataSetName = "komandirovkiDataSet";
            this.komandirovkiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // расходыBindingSource
            // 
            this.расходыBindingSource.DataMember = "Расходы";
            this.расходыBindingSource.DataSource = this.komandirovkiDataSet;
            // 
            // расходыTableAdapter
            // 
            this.расходыTableAdapter.ClearBeforeFill = true;
            // 
            // общаяИнформацияBindingSource
            // 
            this.общаяИнформацияBindingSource.DataMember = "Общая информация";
            this.общаяИнформацияBindingSource.DataSource = this.komandirovkiDataSet;
            // 
            // общая_информацияTableAdapter
            // 
            this.общая_информацияTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(240, 30);
            this.button1.TabIndex = 1;
            this.button1.Text = "Рассчитать cуммарные суточные";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Регион,
            this.Суточные,
            this.кодКомандировкиDataGridViewTextBoxColumn,
            this.фИОDataGridViewTextBoxColumn,
            this.кодСотрудникаDataGridViewTextBoxColumn,
            this.цельпоездкиDataGridViewTextBoxColumn,
            this.датаначалаDataGridViewTextBoxColumn,
            this.датаокончанияDataGridViewTextBoxColumn,
            this.местоНазначенияDataGridViewTextBoxColumn,
            this.предполагаемыерасходыDataGridViewTextBoxColumn,
            this.названиеDataGridViewTextBoxColumn,
            this.регионDataGridViewTextBoxColumn,
            this.суточныеDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.командировкиЗапросBindingSource1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(735, 376);
            this.dataGridView1.TabIndex = 5;
            // 
            // командировкиЗапросBindingSource
            // 
            this.командировкиЗапросBindingSource.DataMember = "КомандировкиЗапрос";
            this.командировкиЗапросBindingSource.DataSource = this.komandirovkiDataSet;
            // 
            // командировкиЗапросTableAdapter
            // 
            this.командировкиЗапросTableAdapter.ClearBeforeFill = true;
            // 
            // командировкиЗапросBindingSource1
            // 
            this.командировкиЗапросBindingSource1.DataMember = "КомандировкиЗапрос";
            this.командировкиЗапросBindingSource1.DataSource = this.komandirovkiDataSet;
            // 
            // Регион
            // 
            this.Регион.DataPropertyName = "Регион";
            this.Регион.HeaderText = "Регион";
            this.Регион.MinimumWidth = 6;
            this.Регион.Name = "Регион";
            this.Регион.Width = 125;
            // 
            // Суточные
            // 
            this.Суточные.DataPropertyName = "Суточные";
            this.Суточные.HeaderText = "Суточные";
            this.Суточные.MinimumWidth = 6;
            this.Суточные.Name = "Суточные";
            this.Суточные.Width = 125;
            // 
            // кодКомандировкиDataGridViewTextBoxColumn
            // 
            this.кодКомандировкиDataGridViewTextBoxColumn.DataPropertyName = "Код_Командировки";
            this.кодКомандировкиDataGridViewTextBoxColumn.HeaderText = "Код_Командировки";
            this.кодКомандировкиDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.кодКомандировкиDataGridViewTextBoxColumn.Name = "кодКомандировкиDataGridViewTextBoxColumn";
            this.кодКомандировкиDataGridViewTextBoxColumn.Width = 125;
            // 
            // фИОDataGridViewTextBoxColumn
            // 
            this.фИОDataGridViewTextBoxColumn.DataPropertyName = "ФИО";
            this.фИОDataGridViewTextBoxColumn.HeaderText = "ФИО";
            this.фИОDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.фИОDataGridViewTextBoxColumn.Name = "фИОDataGridViewTextBoxColumn";
            this.фИОDataGridViewTextBoxColumn.Width = 125;
            // 
            // кодСотрудникаDataGridViewTextBoxColumn
            // 
            this.кодСотрудникаDataGridViewTextBoxColumn.DataPropertyName = "Код_Сотрудника";
            this.кодСотрудникаDataGridViewTextBoxColumn.HeaderText = "Код_Сотрудника";
            this.кодСотрудникаDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.кодСотрудникаDataGridViewTextBoxColumn.Name = "кодСотрудникаDataGridViewTextBoxColumn";
            this.кодСотрудникаDataGridViewTextBoxColumn.Width = 125;
            // 
            // цельпоездкиDataGridViewTextBoxColumn
            // 
            this.цельпоездкиDataGridViewTextBoxColumn.DataPropertyName = "Цель_поездки";
            this.цельпоездкиDataGridViewTextBoxColumn.HeaderText = "Цель_поездки";
            this.цельпоездкиDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.цельпоездкиDataGridViewTextBoxColumn.Name = "цельпоездкиDataGridViewTextBoxColumn";
            this.цельпоездкиDataGridViewTextBoxColumn.Width = 125;
            // 
            // датаначалаDataGridViewTextBoxColumn
            // 
            this.датаначалаDataGridViewTextBoxColumn.DataPropertyName = "Дата_начала";
            this.датаначалаDataGridViewTextBoxColumn.HeaderText = "Дата_начала";
            this.датаначалаDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.датаначалаDataGridViewTextBoxColumn.Name = "датаначалаDataGridViewTextBoxColumn";
            this.датаначалаDataGridViewTextBoxColumn.Width = 125;
            // 
            // датаокончанияDataGridViewTextBoxColumn
            // 
            this.датаокончанияDataGridViewTextBoxColumn.DataPropertyName = "Дата_окончания";
            this.датаокончанияDataGridViewTextBoxColumn.HeaderText = "Дата_окончания";
            this.датаокончанияDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.датаокончанияDataGridViewTextBoxColumn.Name = "датаокончанияDataGridViewTextBoxColumn";
            this.датаокончанияDataGridViewTextBoxColumn.Width = 125;
            // 
            // местоНазначенияDataGridViewTextBoxColumn
            // 
            this.местоНазначенияDataGridViewTextBoxColumn.DataPropertyName = "Место_Назначения";
            this.местоНазначенияDataGridViewTextBoxColumn.HeaderText = "Место_Назначения";
            this.местоНазначенияDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.местоНазначенияDataGridViewTextBoxColumn.Name = "местоНазначенияDataGridViewTextBoxColumn";
            this.местоНазначенияDataGridViewTextBoxColumn.Width = 125;
            // 
            // предполагаемыерасходыDataGridViewTextBoxColumn
            // 
            this.предполагаемыерасходыDataGridViewTextBoxColumn.DataPropertyName = "Предполагаемые_расходы";
            this.предполагаемыерасходыDataGridViewTextBoxColumn.HeaderText = "Предполагаемые_расходы";
            this.предполагаемыерасходыDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.предполагаемыерасходыDataGridViewTextBoxColumn.Name = "предполагаемыерасходыDataGridViewTextBoxColumn";
            this.предполагаемыерасходыDataGridViewTextBoxColumn.Width = 125;
            // 
            // названиеDataGridViewTextBoxColumn
            // 
            this.названиеDataGridViewTextBoxColumn.DataPropertyName = "Название";
            this.названиеDataGridViewTextBoxColumn.HeaderText = "Название";
            this.названиеDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.названиеDataGridViewTextBoxColumn.Name = "названиеDataGridViewTextBoxColumn";
            this.названиеDataGridViewTextBoxColumn.Width = 125;
            // 
            // регионDataGridViewTextBoxColumn
            // 
            this.регионDataGridViewTextBoxColumn.DataPropertyName = "Регион";
            this.регионDataGridViewTextBoxColumn.HeaderText = "Регион";
            this.регионDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.регионDataGridViewTextBoxColumn.Name = "регионDataGridViewTextBoxColumn";
            this.регионDataGridViewTextBoxColumn.Width = 125;
            // 
            // суточныеDataGridViewTextBoxColumn
            // 
            this.суточныеDataGridViewTextBoxColumn.DataPropertyName = "Суточные";
            this.суточныеDataGridViewTextBoxColumn.HeaderText = "Суточные";
            this.суточныеDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.суточныеDataGridViewTextBoxColumn.Name = "суточныеDataGridViewTextBoxColumn";
            this.суточныеDataGridViewTextBoxColumn.Width = 125;
            // 
            // Отчёты
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Отчёты";
            this.Text = "Отчёты";
            this.Load += new System.EventHandler(this.Отчёты_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.komandirovkiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.расходыBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.общаяИнформацияBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.командировкиЗапросBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.командировкиЗапросBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private komandirovkiDataSet komandirovkiDataSet;
        private System.Windows.Forms.BindingSource расходыBindingSource;
        private komandirovkiDataSetTableAdapters.РасходыTableAdapter расходыTableAdapter;
        private System.Windows.Forms.BindingSource общаяИнформацияBindingSource;
        private komandirovkiDataSetTableAdapters.Общая_информацияTableAdapter общая_информацияTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource командировкиЗапросBindingSource;
        private komandirovkiDataSetTableAdapters.КомандировкиЗапросTableAdapter командировкиЗапросTableAdapter;
        private System.Windows.Forms.BindingSource командировкиЗапросBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Регион;
        private System.Windows.Forms.DataGridViewTextBoxColumn Суточные;
        private System.Windows.Forms.DataGridViewTextBoxColumn кодКомандировкиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn фИОDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn кодСотрудникаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn цельпоездкиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаначалаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаокончанияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn местоНазначенияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn предполагаемыерасходыDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn названиеDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn регионDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn суточныеDataGridViewTextBoxColumn;
    }
}