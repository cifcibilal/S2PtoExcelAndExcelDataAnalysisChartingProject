﻿using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S2PtoExcelAndExcelDataAnalysisChartingProject
{
    public class DataFilter
    {
        /**
         * @brief Verilen veri tablosunu belirli MHz aralığına göre filtreler.
         * 
         * @param originalTable:DataTable, Filtrelenmek istenen orijinal veri tablosu.
         * @param minMHz:double, Minimum MHz değeri (dahil) ile filtreleme işlemi yapar.
         * @param maxMHz:double, Maximum MHz değeri (dahil) ile filtreleme işlemi yapar.
         * 
         * @return: Filtrelenmiş veri tablosu. (DataTable)
         */
        public DataTable FilterByMHz(DataTable originalTable, double minMHz, double maxMHz)
        {
            DataTable filteredTable = originalTable.Clone();

            string mhzColumnName = filteredTable.Columns[0].ColumnName;
            DataColumn mhzColumn = originalTable.Columns[mhzColumnName];

            if (mhzColumn == null)
            {
                throw new ArgumentException("Sütun başlığı 'Freq' bulunamadı.");
            }

            foreach (DataRow row in originalTable.Rows)
            {
                if (mhzColumn.DataType == typeof(double))
                {
                    double MHz = Convert.ToDouble(row[mhzColumn]);
                    if (MHz >= minMHz && MHz <= maxMHz)
                    {
                        filteredTable.ImportRow(row);
                    }
                }
                else if (mhzColumn.DataType == typeof(string))
                {
                    string mhzValue = row[mhzColumn].ToString();
                    if (double.TryParse(mhzValue, out double MHz))
                    {
                        if (MHz >= minMHz && MHz <= maxMHz)
                        {
                            filteredTable.ImportRow(row);
                        }
                    }
                }
            }
            return filteredTable;
        }
        /**
         * @brief Filtrelenmiş verileri belirtilen Excel dosyasına kaydeder.
         * 
         * Bu metod, verilen veri tablosunu belirli bir Excel dosyasının belirli bir sayfasına kaydeder. 
         * Eğer sayfa adı belirtilen sayfa adında bir sayfa varsa, kullanıcıya verilerin üzerine yazılıp yazılmaması sorulur.
         * 
         * @param originalData:DataTable, Kaydedilecek veri tablosu.
         * @param saveFilePath:string Verilerin kaydedileceği Excel dosyasının yolu.
         * @param saveSheetName:string, Verilerin kaydedileceği sayfanın adı.
         * @param minMHz:double, Minimum MHz değeri (dahil) ile filtreleme işlemi yapar.
         * @param maxMHz:double, Maximum MHz değeri (dahil) ile filtreleme işlemi yapar.
         * 
         * @return void
         */
        public void SaveFilteredData(DataTable originalData, string saveFilePath, string saveSheetName, double minMHz, double maxMHz)
        {
            DataTable filteredData = FilterByMHz(originalData, minMHz, maxMHz);

            using (var package = new ExcelPackage(new FileInfo(saveFilePath)))
            {
                ExcelWorksheet exitisingWorkSheet = package.Workbook.Worksheets[saveSheetName];

                if (exitisingWorkSheet != null)
                {
                    DialogResult result = MessageBox.Show("Girilen sayfa adında bir sayfa zaten var. Verileri üzerine yazmak istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        package.Workbook.Worksheets.Delete(exitisingWorkSheet);
                        SaveFilteredDataToWorksheet(package, filteredData, saveSheetName);
                        package.Save();
                        MessageBox.Show("Sorgulanmış veriler sayfaya kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("veriler sayfaya kaydedilmedi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    SaveFilteredDataToWorksheet(package, filteredData, saveSheetName);
                    package.Save();
                    MessageBox.Show("Sorgulanmış veriler sayfaya kaydedildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }
        private void SaveFilteredDataToWorksheet(ExcelPackage package, DataTable filteredData, string sheetName)
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(sheetName); // Yeni bir sayfa oluştur

            // Başlık satırını ekle
            for (int col = 0; col < 6; col++)
            {
                //worksheet.Cells[1, col + 1].Value = filteredData.Columns[col].ColumnName;
                worksheet.Cells[1, 1].Value = "Freq";
                worksheet.Cells[1, 2].Value = "S11:dB";
                worksheet.Cells[1, 3].Value = "Ang(F2)";
                worksheet.Cells[1, 4].Value = "S21:dB";
                worksheet.Cells[1, 5].Value = "Ang(F2)";
                worksheet.Cells[1, 6].Value = "S12:dB";
                worksheet.Cells[1, 7].Value = "Ang(F2)";
                worksheet.Cells[1, 8].Value = "S22:dB";
                worksheet.Cells[1, 9].Value = "Ang(F2)";
                
            }
            // Verileri ekle

            for (int row = 0; row < filteredData.Rows.Count; row++)
            {
                for (int col = 0; col < filteredData.Columns.Count; col++)
                {
                    worksheet.Cells[row + 2, col + 1].Value = Convert.ToDouble(filteredData.Rows[row][col]);
                }
            }
            for (int i = 3; i < 10; i+=2)
            {
                worksheet.Column(i).Hidden = true;
            }

        }
        public void Swap(ref double minMHz, ref double maxMHz)
        {
            double temp = minMHz;
            minMHz = maxMHz;
            maxMHz = temp;
        }
    }
}
