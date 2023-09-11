using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static OfficeOpenXml.ExcelErrorValue;

namespace S2PtoExcelAndExcelDataAnalysisChartingProject
{
    public class S2PManager
    {
        private OpenFileDialog openFileDialog;
        private ProgressBar progressBar;
        private Chart chart;
        public S2PManager(ProgressBar progressBar,Chart chart)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = "S2P Files|*.s2p";

            this.progressBar = progressBar;
            this.chart = chart;
        }
        public S2PManager()
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = "S2P Files|*.s2p";
        }

        public string s2pOpenDialog()
        {
            string filePath;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }
            else
            {
                filePath = null;
            }
            return filePath;
        }
        /**
         * @brief S2P Dosyasının ismini dönderir.
         * 
         * @param filePath:string, S2P Dosyasının yolu.
         * 
         * @return fileName or null
         */
        public string s2pReturnFileName(string filePath)
        {
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                return fileName;
            }
            catch (Exception e)
            {
                return "s2pReturnFileName Hata : " + e.Message;
            }
        }
        /**
         * @brief S2P Dosyasını bir datatable a dönüştürür.
         * 
         * @param s2pFile:string, S2P Dosyasının yolu.
         * 
         * @return DataTable or null.
         */
        public DataTable ConvertS2PToDataTable(string s2pFile)
        {
            try
            {
                DataTable dataTable = new DataTable();
                using (StreamReader streamReader = new StreamReader(s2pFile))
                {

                    for (int i = 0; i < 4; i++)
                    {
                        streamReader.ReadLine();
                    }

                    string headerLine = streamReader.ReadLine();
                    string[] headersData = headerLine.Split('\t');
                    string[] headers = new string[9];
                    string[] kontrol;
                    string[] dataTableColumnName = { "Freq", "S11_db", "Ang_F2_S11", "S21_dB", "Ang_F2_S21", "S12_dB", "Ang_F2_S12", "S22_dB", "Ang_F2_S22" };
                    for (int i = 0; i < headersData.Length; i++)
                    {
                        kontrol = headersData[i].Split('/');
                        foreach (string item in kontrol)
                        {
                            int j = 0;
                            headers[j] = item;
                            j++;
                        }
                    }
                    foreach (string header in headers)
                    {
                        dataTable.Columns.Add(header);
                    }
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dataTable.Columns[i].ColumnName = dataTableColumnName[i];
                    }
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string[] values = line.Split('\t');
                        for (int i = 0; i<values.Length;i++)
                        {
                            double doubleValue;
                            if (double.TryParse(values[i].ToString(),NumberStyles.Float,CultureInfo.InvariantCulture,out doubleValue))
                            {
                                //values[i] = (doubleValue / 1_000_000).ToString(); ;
                            }
                        }
                        dataTable.Rows.Add(values);
                    }
                }
                return dataTable;
            }
            catch (Exception e)
            {
                MessageBox.Show("ConvertS2PToDataTable içerisinde hata oluştu." + e.Message);
                return null;
            }
        }
        public void ConvertS2PToExcel(string s2pFilePath, string excelFilePath)
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(s2pFilePath))
                {
                    for (int i = 0; i < 4; i++)
                    {
                        streamReader.ReadLine();
                    }
                    using (var package = new ExcelPackage(new FileInfo(excelFilePath)))
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(s2pReturnFileName(s2pFilePath));

                        string headerLine = streamReader.ReadLine();
                        string[] headers = headerLine.Split('\t');
                        for (int i = 0; i < headers.Length; i++)
                        {
                            if (headers.Length == 5)
                            {
                                string line2 = "";
                                foreach (string item in headers)
                                {
                                    line2 += "/" + item;
                                }
                                string[] columHeader = line2.Split('/');
                                for (int j = 0; j < columHeader.Length - 1; j++)
                                {
                                    worksheet.Cells[1, j + 1].Value = columHeader[j + 1];
                                }
                            }
                            //worksheet.Cells[1, i + 1].Value = headers[i];
                        }
                        int row = 2;

                        string line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            string[] values = line.Split('\t');

                            for (int i = 0; i < values.Length; i++)
                            {
                                if (double.TryParse(values[i], NumberStyles.Float, CultureInfo.InvariantCulture, out double numericValue))
                                {
                                    if (i == 0)
                                    {
                                        worksheet.Cells[row, i + 1].Value = numericValue/1_000_000;
                                    }
                                    else
                                    {
                                        worksheet.Cells[row, i + 1].Value = numericValue;
                                    }
                                    
                                }
                                else
                                {
                                    if (values.Length==5)
                                    {
                                        string line2 = "";
                                        foreach (string item in values)
                                        {
                                            line2 += "/"+item;
                                        }
                                        string[] columHeader = line2.Split('/');
                                        for (int j = 0; j < columHeader.Length-1; j++)
                                        {
                                            worksheet.Cells[row, j + 1].Value = columHeader[j + 1];
                                        }
                                    }
                                    if (values.Length != 5)
                                    {
                                        worksheet.Cells[row, i + 1].Value = values[i];
                                    }
                                }
                            }
                            row++;
                        }
                        for (int i = 3; i < worksheet.Columns.Count()+1; i+=2)
                        {
                            worksheet.Column(i).Hidden = true;
                            
                        }
                        ChartProcessor processor = new ChartProcessor(chart);
                        processor.createChart(ConvertS2PToDataTable(s2pFilePath));
                        processor.saveChart(package, chart, s2pReturnFileName(s2pFilePath));
                        package.Save();
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ConvertS2PToExcel içinde hata oluştu.");
            }
        }
        public void ConvertS2PToExcelAndSave(string mainFilePath, string outputFilePath)
        {
            try
            {
                string mainFileDirectory = Path.GetDirectoryName(mainFilePath);
                string[] s2pFiles = Directory.GetFiles(mainFilePath, "*.s2p");
                progressBar.Minimum = 0;
                progressBar.Maximum = s2pFiles.Length;
                foreach (string s2pFile in s2pFiles)
                {
                    progressBar.Value += 1;
                    string dosyaAdi = s2pReturnFileName(s2pFile);
                    string excelFileName = dosyaAdi + ".xlsx";
                    string excelFilePath = Path.Combine(outputFilePath, excelFileName);

                    ConvertS2PToExcel(s2pFile, excelFilePath);
                }
                MessageBox.Show("Tüm S2P Dosyaları excel olarak kaydedildi");
            }
            catch (Exception e)
            {
                MessageBox.Show("ConvertS2PToExcelAndSave içinde hata oluştu." + e.Message);
            }
        }
    }
}
