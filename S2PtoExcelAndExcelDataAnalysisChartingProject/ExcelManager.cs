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

namespace S2PtoExcelAndExcelDataAnalysisChartingProject
{
    public class ExcelManager
    {
        private SaveFileDialog saveFileDialog;
        OpenFileDialog openFileDialog;
        private string dosyaAd;
        private Chart chart;
        public ExcelManager(Chart chart)
        {

            this.chart = chart;

            this.openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = "Excel Files|*.xlsx";

        }
        public ExcelManager(string dosyaAd, Chart chart)
        {
            this.dosyaAd = dosyaAd;
            this.saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Dosya Kayıt|*.xlsx";
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog.FileName = dosyaAd + ".xlsx";

            this.chart = chart;

        }

        public string excelSaveFileDialog()
        {
            string filePath;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
                return filePath;
            }
            else
            {
                return null;
            }
        }
        public void S2PtoExcelSave(DataTable S2P_dataTable)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add(dosyaAd);

                for (int col = 0; col < S2P_dataTable.Columns.Count; col++)
                {
                    worksheet.Cells[1, col + 1].Value = S2P_dataTable.Columns[col].ColumnName;
                }

                // DataTable verilerini Excel sayfasına ekleyin
                for (int row = 0; row < S2P_dataTable.Rows.Count; row++)
                {
                    for (int col = 0; col < S2P_dataTable.Columns.Count; col++)
                    {
                        //double doubLeValue;
                        if (double.TryParse(S2P_dataTable.Rows[row][col].ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out double doubleValue))
                        {
                            if (col == 0)
                            {
                                worksheet.Cells[row + 2, col + 1].Value = doubleValue / 1_000_000;
                            }
                            else
                            {
                                worksheet.Cells[row + 2, col + 1].Value = doubleValue;
                            }

                        }
                        //double doubleValue = double.Parse(S2P_dataTable.Rows[row][col].ToString());
                        //worksheet.Cells[row + 2, col + 1].Value = doubleValue;
                    }
                }
                for (int i = 3; i < worksheet.Columns.Count() + 1; i += 2)
                {
                    worksheet.Column(i).Hidden = true;

                }
                string path = excelSaveFileDialog();


                excelPackage.SaveAs(new FileInfo(path));
                ChartProcessor chartProcessor = new ChartProcessor(chart);
                chartProcessor.createChart(S2P_dataTable);
                chartProcessor.saveChart(excelPackage, chart, dosyaAd);
                excelPackage.Save();
                MessageBox.Show("Başarıyla Kaydedildi.");

            }
        }
        public string OpenExcelFileDialog()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                return openFileDialog.FileName;
            }
            else
            {
                return null;
            }
        }
        public DataTable ReaderExcelFile(string filePath, string selectedSheet = "0")
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet excelWorksheet;
                    if (selectedSheet.Equals("0"))
                    {
                        excelWorksheet = package.Workbook.Worksheets[0];
                    }
                    else
                    {
                        excelWorksheet = package.Workbook.Worksheets[selectedSheet];
                    }
                    string[] dataTableColumnName = { "Freq", "S11_db", "Ang_F2_S11", "S21_dB", "Ang_F2_S21", "S12_dB", "Ang_F2_S12", "S22_dB", "Ang_F2_S22" };
                    int startRow = 1;
                    int endRow = excelWorksheet.Dimension.Rows;
                    int endColum = excelWorksheet.Dimension.Columns;
                    string columnHeader;
                    for (int columnIndex = 0; columnIndex < dataTableColumnName.Length; columnIndex++)
                    {
                        //farklı tarzda excel için columnindex 1, columheader için aşağısı, bu döngünün uzunluğu endcolumn
                        //columnHeader = excelWorksheet.Cells[startRow, columnIndex].Text;
                        columnHeader = dataTableColumnName[columnIndex];

                        dataTable.Columns.Add(columnHeader);
                    }
                    for (var rowNumber = (startRow + 1); rowNumber <= endRow; rowNumber++)
                    {
                        var row = excelWorksheet.Cells[rowNumber, 1, rowNumber, endColum];
                        var newRow = dataTable.NewRow();
                        foreach (var cell in row)
                        {
                            if (double.TryParse(cell.Text, out double numericValue))
                            {
                                newRow[cell.Start.Column - 1] = numericValue;
                            }
                            else
                            {
                                newRow[cell.Start.Column - 1] = cell.Text;
                            }
                        }
                        dataTable.Rows.Add(newRow);
                    }
                    
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ReaderExcelFile içerisinde hata oluştu: " + e.Message);
            }
            return dataTable;
        }
        public List<string> GetSheetNames(string filePath)
        {
            List<string> sheetNames = new List<string>();
            try
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    if (package != null)
                    {
                        foreach (var sheet in package.Workbook.Worksheets)//hatalı
                        {
                            sheetNames.Add(sheet.Name);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("GetSheetNames içerisinde hata oluştu: " + e.Message);
            }
            return sheetNames;
        }
    }
}
