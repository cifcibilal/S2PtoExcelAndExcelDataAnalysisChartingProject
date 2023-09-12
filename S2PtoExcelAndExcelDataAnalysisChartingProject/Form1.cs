using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;

namespace S2PtoExcelAndExcelDataAnalysisChartingProject
{
    public partial class Form1 : Form
    {
        string selectedFolderPath;
        string selectedS2PPath;

        string s2pTekPath;
        DataTable S2P_dataTable;

        string excelPath;
        DataTable excelDatatable;
        public Form1()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region Tüm S2P Dosyaları Buton ayarı
            btnS2PSaveFileSelect.Enabled = false;
            btnS2PFileConverter.Enabled = false;
            btnS2PFileSelect.Enabled = true;
            #endregion
            btnS2PConverter.Enabled = false;
        }
        private void btnS2PKlasorSec_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.selectedS2PPath = dialog.SelectedPath;
            }
            else
            {

            }
            btnS2PSaveFileSelect.Enabled = true;
        }   

        private void btnS2PSaveFileSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.selectedFolderPath = dialog.SelectedPath;
            }
            else
            {

            }
            btnS2PFileConverter.Enabled = true;
        }
        private void btnS2PFileConverter_Click(object sender, EventArgs e)
        {
            S2PManager s2PManager = new S2PManager(progressBar1,chart1);

            string sourceFolder = this.selectedS2PPath;
            string outputFolder = this.selectedFolderPath;

            s2PManager.ConvertS2PToExcelAndSave(sourceFolder, outputFolder);

        }
        private void btnS2POpen_Click(object sender, EventArgs e)
        {
            S2PManager s2PManager = new S2PManager();


            string s2pPath = s2PManager.s2pOpenDialog();
            this.s2pTekPath = s2pPath;
            if (s2pPath != null)
            {
                DataTable s2p_dataTable;
                s2p_dataTable = s2PManager.ConvertS2PToDataTable(s2pPath);
                this.S2P_dataTable = s2p_dataTable;
                dataGridView1.DataSource = s2p_dataTable;
                // DataGridView'deki tüm hücreleri döngü ile kontrol edin
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        // Başlıkları atlayın
                        if (cell.ColumnIndex != -1)
                        {
                            // Hücrenin değerini alın
                            if (cell.Value != null && double.TryParse(cell.Value.ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out double cellValue))
                            {
                                // Değerin 1,000,000'e bölünmesi
                                double newValue = cellValue / 1_000_000;

                                // Yeni değeri hücreye yerleştirin
                                cell.Value = newValue;
                            }
                        }
                    }
                }

                UIHelper uIHelper = new UIHelper(dataGridView1);
                uIHelper.dataGridSutunDuzenle();

                ChartProcessor chartProcessor = new ChartProcessor(chart1);
                chartProcessor.createChart(this.S2P_dataTable);
            }
            btnS2PConverter.Enabled = true;
        }
        private void btnS2PConverter_Click(object sender, EventArgs e)
        {
            ExcelManager excelPathAndName = new ExcelManager(Path.GetFileNameWithoutExtension(this.s2pTekPath),chart1);

            excelPathAndName.S2PtoExcelSave(this.S2P_dataTable);

            
        }

        private void btnExcelOpen_Click(object sender, EventArgs e)
        {

            if (comboBoxSheetNames.Items != null)
            {
                comboBoxSheetNames.Items.Clear();
            }

            ExcelManager excelManager = new ExcelManager(chart1);
            this.excelPath = excelManager.OpenExcelFileDialog();
            if (excelPath != null)
            {
                this.excelDatatable = excelManager.ReaderExcelFile(excelPath);
            }
            else
            {
                excelDatatable = null;  
            }
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = excelDatatable;

            UIHelper uiHelper = new UIHelper(dataGridView1);
            uiHelper.dataGridSutunDuzenle();

            ChartProcessor processor = new ChartProcessor(chart1,textBoxMinMHz,textBoxMaxMHz);
            processor.ShowDataOnChart(excelDatatable);

            foreach (var item in excelManager.GetSheetNames(excelPath))
            {
                comboBoxSheetNames.Items.Add(item);
            }
            comboBoxSheetNames.SelectedIndex = 0;

        }

        private void comboBoxSheetNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            ExcelManager excel = new ExcelManager(chart1);
            string selectedSheetName = comboBoxSheetNames.SelectedItem.ToString();
            if (selectedSheetName != null)
            {
                dataTable = excel.ReaderExcelFile(this.excelPath, selectedSheetName);
            }
            else
            {
                dataTable = null;
            }
            dataGridView1.DataSource = dataTable;

            ChartProcessor chartProcessor = new ChartProcessor(chart1, textBoxMinMHz, textBoxMaxMHz);
            chartProcessor.ShowDataOnChart(dataTable);
        }

        private void btnSorgula_Click(object sender, EventArgs e)
        {
            dataGridView2.Columns.Clear();

            DataFilter filter = new DataFilter();
            DataTable originalData = (DataTable)dataGridView1.DataSource;

            string selectedMinValue = textBoxMinMHz.Text;
            string selectedMaxValue = textBoxMaxMHz.Text;

            double minMHz = string.IsNullOrEmpty(selectedMinValue) ? 0 : double.Parse(selectedMinValue);
            double maxMHz = string.IsNullOrEmpty(selectedMaxValue) ? 0 : double.Parse(selectedMaxValue);

            if (minMHz > maxMHz)
            {
                filter.Swap(ref minMHz, ref maxMHz);
            }
            try
            {
                DataTable filteredData = filter.FilterByMHz(originalData, minMHz, maxMHz);
                dataGridView2.DataSource = filteredData;

                UIHelper uIHelper = new UIHelper(dataGridView2);
                uIHelper.dataGridSutunDuzenle();

                ChartProcessor chartProcessor = new ChartProcessor(chart1, textBoxMinMHz, textBoxMaxMHz);
                chartProcessor.ShowDataOnChart(filteredData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string saveSheetName = textBoxSaveName.Text;

            string filePath = this.excelPath;

            string selectedMinValue = textBoxMinMHz.Text;
            string selectedMaxValue = textBoxMaxMHz.Text;

            double minMHz = string.IsNullOrEmpty(selectedMinValue) ? 0 : double.Parse(selectedMinValue);
            double maxMHz = string.IsNullOrEmpty(selectedMaxValue) ? 0 : double.Parse(selectedMaxValue);

            DataFilter filterSave = new DataFilter();

            filterSave.SaveFilteredData((DataTable)dataGridView1.DataSource,filePath,saveSheetName,minMHz,maxMHz);

            using (ExcelPackage package = new ExcelPackage(new System.IO.FileInfo(filePath)))
            {              
                ChartProcessor processor = new ChartProcessor();
                processor.saveChart(package, chart1, saveSheetName);
                package.Save();
            }

            ExcelManager excelManager = new ExcelManager();
            comboBoxSheetNames.Items.Clear();
            foreach (var item in excelManager.GetSheetNames(filePath))
            {
                comboBoxSheetNames.Items.Add(item);
            }
        }

        private void btnLimitlineEkle_Click(object sender, EventArgs e)
        {
            ChartProcessor chart = new ChartProcessor(chart1, textBox_LimitLine_MinMHz, textBox_LimitLine_MaxMHz, textBox_LimitLine_dB);
            chart.LimitLineEkle(lblLimitLineName.Text);
        }

        private void radioButtonS11_CheckedChanged(object sender, EventArgs e)
        {
            textBox_LimitLine_dB.Text = "0";
            textBox_LimitLine_MinMHz.Text = "0";
            textBox_LimitLine_MaxMHz.Text = "0";
            lblLimitLineName.Text = "S11_Limitline";
            btnLimitlineEkle.Enabled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox_LimitLine_dB.Text = "0";
            textBox_LimitLine_MinMHz.Text = "0";
            textBox_LimitLine_MaxMHz.Text = "0";
            lblLimitLineName.Text = "S21_Limitline";
            btnLimitlineEkle.Enabled = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox_LimitLine_dB.Text = "0";
            textBox_LimitLine_MinMHz.Text = "0";
            textBox_LimitLine_MaxMHz.Text = "0";
            lblLimitLineName.Text = "S12_Limitline";
            btnLimitlineEkle.Enabled = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox_LimitLine_dB.Text = "0";
            textBox_LimitLine_MinMHz.Text = "0";
            textBox_LimitLine_MaxMHz.Text = "0";
            lblLimitLineName.Text = "S22_Limitline";
            btnLimitlineEkle.Enabled = true;
        }
    }
}
