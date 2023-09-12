namespace S2PtoExcelAndExcelDataAnalysisChartingProject
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnS2PSaveFileSelect = new System.Windows.Forms.Button();
            this.btnS2PFileSelect = new System.Windows.Forms.Button();
            this.btnS2PFileConverter = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnS2POpen = new System.Windows.Forms.Button();
            this.btnS2PConverter = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lblLimitLineName = new System.Windows.Forms.Label();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButtonS11 = new System.Windows.Forms.RadioButton();
            this.btnLimitlineEkle = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_LimitLine_MaxMHz = new System.Windows.Forms.TextBox();
            this.textBox_LimitLine_MinMHz = new System.Windows.Forms.TextBox();
            this.textBox_LimitLine_dB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBoxSheetNames = new System.Windows.Forms.ComboBox();
            this.btnExcelOpen = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMaxMHz = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxMinMHz = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSorgula = new System.Windows.Forms.Button();
            this.textBoxSaveName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(750, 564);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 18);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(744, 543);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Location = new System.Drawing.Point(759, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(750, 564);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 18);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(744, 543);
            this.dataGridView2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox6);
            this.groupBox3.Controls.Add(this.groupBox5);
            this.groupBox3.Location = new System.Drawing.Point(1515, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(307, 564);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "S2P To Excel";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.progressBar1);
            this.groupBox6.Controls.Add(this.btnS2PSaveFileSelect);
            this.groupBox6.Controls.Add(this.btnS2PFileSelect);
            this.groupBox6.Controls.Add(this.btnS2PFileConverter);
            this.groupBox6.Location = new System.Drawing.Point(6, 146);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(295, 191);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Tüm S2P Dosyaları";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 153);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(283, 23);
            this.progressBar1.TabIndex = 3;
            // 
            // btnS2PSaveFileSelect
            // 
            this.btnS2PSaveFileSelect.Location = new System.Drawing.Point(164, 32);
            this.btnS2PSaveFileSelect.Name = "btnS2PSaveFileSelect";
            this.btnS2PSaveFileSelect.Size = new System.Drawing.Size(125, 52);
            this.btnS2PSaveFileSelect.TabIndex = 2;
            this.btnS2PSaveFileSelect.Text = "S2P Kayıt \r\nKlasör Seç";
            this.btnS2PSaveFileSelect.UseVisualStyleBackColor = true;
            this.btnS2PSaveFileSelect.Click += new System.EventHandler(this.btnS2PSaveFileSelect_Click);
            // 
            // btnS2PFileSelect
            // 
            this.btnS2PFileSelect.Location = new System.Drawing.Point(6, 32);
            this.btnS2PFileSelect.Name = "btnS2PFileSelect";
            this.btnS2PFileSelect.Size = new System.Drawing.Size(125, 52);
            this.btnS2PFileSelect.TabIndex = 0;
            this.btnS2PFileSelect.Text = "S2P Klasör Seç";
            this.btnS2PFileSelect.UseVisualStyleBackColor = true;
            this.btnS2PFileSelect.Click += new System.EventHandler(this.btnS2PKlasorSec_Click);
            // 
            // btnS2PFileConverter
            // 
            this.btnS2PFileConverter.Location = new System.Drawing.Point(91, 90);
            this.btnS2PFileConverter.Name = "btnS2PFileConverter";
            this.btnS2PFileConverter.Size = new System.Drawing.Size(125, 52);
            this.btnS2PFileConverter.TabIndex = 1;
            this.btnS2PFileConverter.Text = "Excele Dönüştür";
            this.btnS2PFileConverter.UseVisualStyleBackColor = true;
            this.btnS2PFileConverter.Click += new System.EventHandler(this.btnS2PFileConverter_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnS2POpen);
            this.groupBox5.Controls.Add(this.btnS2PConverter);
            this.groupBox5.Location = new System.Drawing.Point(6, 28);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(295, 112);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tek Dosya";
            // 
            // btnS2POpen
            // 
            this.btnS2POpen.Location = new System.Drawing.Point(6, 32);
            this.btnS2POpen.Name = "btnS2POpen";
            this.btnS2POpen.Size = new System.Drawing.Size(125, 52);
            this.btnS2POpen.TabIndex = 0;
            this.btnS2POpen.Text = "S2P Dosya Seç";
            this.btnS2POpen.UseVisualStyleBackColor = true;
            this.btnS2POpen.Click += new System.EventHandler(this.btnS2POpen_Click);
            // 
            // btnS2PConverter
            // 
            this.btnS2PConverter.Location = new System.Drawing.Point(164, 32);
            this.btnS2PConverter.Name = "btnS2PConverter";
            this.btnS2PConverter.Size = new System.Drawing.Size(125, 52);
            this.btnS2PConverter.TabIndex = 1;
            this.btnS2PConverter.Text = "Excele Dönüştür";
            this.btnS2PConverter.UseVisualStyleBackColor = true;
            this.btnS2PConverter.Click += new System.EventHandler(this.btnS2PConverter_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1843, 840);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox8);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1835, 811);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "File Operators";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lblLimitLineName);
            this.groupBox8.Controls.Add(this.radioButton4);
            this.groupBox8.Controls.Add(this.radioButton3);
            this.groupBox8.Controls.Add(this.radioButton2);
            this.groupBox8.Controls.Add(this.radioButtonS11);
            this.groupBox8.Controls.Add(this.btnLimitlineEkle);
            this.groupBox8.Controls.Add(this.label9);
            this.groupBox8.Controls.Add(this.textBox_LimitLine_MaxMHz);
            this.groupBox8.Controls.Add(this.textBox_LimitLine_MinMHz);
            this.groupBox8.Controls.Add(this.textBox_LimitLine_dB);
            this.groupBox8.Controls.Add(this.label8);
            this.groupBox8.Controls.Add(this.label2);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox8.Location = new System.Drawing.Point(907, 570);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(602, 240);
            this.groupBox8.TabIndex = 33;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Limitline Ekle";
            // 
            // lblLimitLineName
            // 
            this.lblLimitLineName.AutoSize = true;
            this.lblLimitLineName.Location = new System.Drawing.Point(14, 174);
            this.lblLimitLineName.Name = "lblLimitLineName";
            this.lblLimitLineName.Size = new System.Drawing.Size(62, 20);
            this.lblLimitLineName.TabIndex = 37;
            this.lblLimitLineName.Text = "label10";
            this.lblLimitLineName.Visible = false;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(18, 133);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(131, 24);
            this.radioButton4.TabIndex = 36;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "S22_Limitline";
            this.radioButton4.UseVisualStyleBackColor = true;
            this.radioButton4.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(18, 103);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(131, 24);
            this.radioButton3.TabIndex = 35;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "S12_Limitline";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(18, 73);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(131, 24);
            this.radioButton2.TabIndex = 34;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "S21_Limitline";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButtonS11
            // 
            this.radioButtonS11.AutoSize = true;
            this.radioButtonS11.Location = new System.Drawing.Point(18, 43);
            this.radioButtonS11.Name = "radioButtonS11";
            this.radioButtonS11.Size = new System.Drawing.Size(131, 24);
            this.radioButtonS11.TabIndex = 33;
            this.radioButtonS11.TabStop = true;
            this.radioButtonS11.Text = "S11_Limitline";
            this.radioButtonS11.UseVisualStyleBackColor = true;
            this.radioButtonS11.CheckedChanged += new System.EventHandler(this.radioButtonS11_CheckedChanged);
            // 
            // btnLimitlineEkle
            // 
            this.btnLimitlineEkle.Location = new System.Drawing.Point(354, 120);
            this.btnLimitlineEkle.Name = "btnLimitlineEkle";
            this.btnLimitlineEkle.Size = new System.Drawing.Size(116, 43);
            this.btnLimitlineEkle.TabIndex = 28;
            this.btnLimitlineEkle.Text = "Ekle";
            this.btnLimitlineEkle.UseVisualStyleBackColor = true;
            this.btnLimitlineEkle.Click += new System.EventHandler(this.btnLimitlineEkle_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(363, 72);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 29);
            this.label9.TabIndex = 28;
            this.label9.Text = "||";
            // 
            // textBox_LimitLine_MaxMHz
            // 
            this.textBox_LimitLine_MaxMHz.Location = new System.Drawing.Point(394, 75);
            this.textBox_LimitLine_MaxMHz.Name = "textBox_LimitLine_MaxMHz";
            this.textBox_LimitLine_MaxMHz.Size = new System.Drawing.Size(76, 26);
            this.textBox_LimitLine_MaxMHz.TabIndex = 4;
            // 
            // textBox_LimitLine_MinMHz
            // 
            this.textBox_LimitLine_MinMHz.Location = new System.Drawing.Point(284, 75);
            this.textBox_LimitLine_MinMHz.Name = "textBox_LimitLine_MinMHz";
            this.textBox_LimitLine_MinMHz.Size = new System.Drawing.Size(76, 26);
            this.textBox_LimitLine_MinMHz.TabIndex = 3;
            // 
            // textBox_LimitLine_dB
            // 
            this.textBox_LimitLine_dB.Location = new System.Drawing.Point(284, 34);
            this.textBox_LimitLine_dB.Name = "textBox_LimitLine_dB";
            this.textBox_LimitLine_dB.Size = new System.Drawing.Size(186, 26);
            this.textBox_LimitLine_dB.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(171, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 20);
            this.label8.TabIndex = 1;
            this.label8.Text = "MHz Aralığı :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(183, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "dB Değeri :";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.comboBoxSheetNames);
            this.groupBox4.Controls.Add(this.btnExcelOpen);
            this.groupBox4.Location = new System.Drawing.Point(6, 570);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(361, 240);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Excel İşlemleri";
            // 
            // comboBoxSheetNames
            // 
            this.comboBoxSheetNames.FormattingEnabled = true;
            this.comboBoxSheetNames.Location = new System.Drawing.Point(8, 103);
            this.comboBoxSheetNames.Name = "comboBoxSheetNames";
            this.comboBoxSheetNames.Size = new System.Drawing.Size(288, 24);
            this.comboBoxSheetNames.TabIndex = 6;
            this.comboBoxSheetNames.SelectedIndexChanged += new System.EventHandler(this.comboBoxSheetNames_SelectedIndexChanged);
            // 
            // btnExcelOpen
            // 
            this.btnExcelOpen.Location = new System.Drawing.Point(171, 45);
            this.btnExcelOpen.Name = "btnExcelOpen";
            this.btnExcelOpen.Size = new System.Drawing.Size(125, 52);
            this.btnExcelOpen.TabIndex = 4;
            this.btnExcelOpen.Text = "Excel Aç";
            this.btnExcelOpen.UseVisualStyleBackColor = true;
            this.btnExcelOpen.Click += new System.EventHandler(this.btnExcelOpen_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnSave);
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.textBoxMaxMHz);
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.textBoxMinMHz);
            this.groupBox7.Controls.Add(this.label5);
            this.groupBox7.Controls.Add(this.label6);
            this.groupBox7.Controls.Add(this.btnSorgula);
            this.groupBox7.Controls.Add(this.textBoxSaveName);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox7.Location = new System.Drawing.Point(407, 571);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(457, 240);
            this.groupBox7.TabIndex = 31;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "MHz Aralığı seçin:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(311, 127);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 52);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Min";
            // 
            // textBoxMaxMHz
            // 
            this.textBoxMaxMHz.Location = new System.Drawing.Point(161, 53);
            this.textBoxMaxMHz.Name = "textBoxMaxMHz";
            this.textBoxMaxMHz.Size = new System.Drawing.Size(121, 25);
            this.textBoxMaxMHz.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Max";
            // 
            // textBoxMinMHz
            // 
            this.textBoxMinMHz.Location = new System.Drawing.Point(11, 53);
            this.textBoxMinMHz.Name = "textBoxMinMHz";
            this.textBoxMinMHz.Size = new System.Drawing.Size(117, 25);
            this.textBoxMinMHz.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(134, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 29);
            this.label5.TabIndex = 21;
            this.label5.Text = "||";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(8, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(249, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Kaydedilecek sayfa adını belirleyin:";
            // 
            // btnSorgula
            // 
            this.btnSorgula.Location = new System.Drawing.Point(311, 40);
            this.btnSorgula.Name = "btnSorgula";
            this.btnSorgula.Size = new System.Drawing.Size(125, 52);
            this.btnSorgula.TabIndex = 22;
            this.btnSorgula.Text = "Sorgula";
            this.btnSorgula.UseVisualStyleBackColor = true;
            this.btnSorgula.Click += new System.EventHandler(this.btnSorgula_Click);
            // 
            // textBoxSaveName
            // 
            this.textBoxSaveName.Location = new System.Drawing.Point(12, 140);
            this.textBoxSaveName.Name = "textBoxSaveName";
            this.textBoxSaveName.Size = new System.Drawing.Size(270, 25);
            this.textBoxSaveName.TabIndex = 24;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chart1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1835, 811);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Data Chart";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 3);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(1829, 805);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1843, 840);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "S2PtoExcel And Excel Data Analysis Charting App";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button btnS2PConverter;
        private System.Windows.Forms.Button btnS2POpen;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnS2PFileSelect;
        private System.Windows.Forms.Button btnS2PFileConverter;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnS2PSaveFileSelect;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox comboBoxSheetNames;
        private System.Windows.Forms.Button btnExcelOpen;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox textBoxMaxMHz;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBoxMinMHz;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSorgula;
        private System.Windows.Forms.TextBox textBoxSaveName;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label lblLimitLineName;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButtonS11;
        public System.Windows.Forms.Button btnLimitlineEkle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_LimitLine_MaxMHz;
        private System.Windows.Forms.TextBox textBox_LimitLine_MinMHz;
        private System.Windows.Forms.TextBox textBox_LimitLine_dB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
    }
}

