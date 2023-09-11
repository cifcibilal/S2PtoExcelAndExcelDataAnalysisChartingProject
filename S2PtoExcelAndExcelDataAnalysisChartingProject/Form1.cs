using System;
using System.Data;
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
            dataGridView1.ClearSelection();
            dataGridView1.DataSource = excelDatatable;

            UIHelper uiHelper = new UIHelper(dataGridView1);
            uiHelper.dataGridSutunDuzenle();

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
        }
    }
}
