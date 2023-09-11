using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Numerics;
using System.Globalization;

namespace S2PtoExcelAndExcelDataAnalysisChartingProject
{
    public class ChartProcessor
    {
        private Chart chart;
        public ChartProcessor()
        {
            
        }
        public ChartProcessor(Chart chart)
        {
            this.chart = chart;
        }
        public void createChart(DataTable dataTable)
        {
            chart.Series.Clear();
            chartProperties(dataTable);

            string[] dataTableColumnName = { "Freq", "S11_db", "Ang_F2_S11", "S21_dB", "Ang_F2_S21", "S12_dB", "Ang_F2_S12", "S22_dB", "Ang_F2_S22" };

            Series series1 = new Series("S11:dB");
            Series series2 = new Series("S21:dB");
            Series series3 = new Series("S12:dB");
            Series series4 = new Series("S22:dB");

            chart.Series.Add(series1);
            chart.Series.Add(series2);
            chart.Series.Add(series3);
            chart.Series.Add(series4);

            series1.ChartType = SeriesChartType.Line;
            series1.BorderWidth = 2;
            series1.XValueType = ChartValueType.Double;

            series2.ChartType = SeriesChartType.Line;
            series2.BorderWidth = 2;
            series2.XValueType = ChartValueType.Double;

            series3.ChartType = SeriesChartType.Line;
            series3.BorderWidth = 2;
            series3.XValueType = ChartValueType.Double;

            series4.ChartType = SeriesChartType.Line;
            series4.BorderWidth = 2;
            series4.XValueType = ChartValueType.Double;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                double xDegeri; //= Convert.ToDouble(dataTable.Rows[i][dataTable.Columns[0].ColumnName]);
                if (double.TryParse(dataTable.Rows[i][dataTable.Columns[0].ColumnName].ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out xDegeri ))
                {
                    for (int j = 1; j < dataTableColumnName.Length; j += 2)
                    {
                        double yDegeri = 0;
                        if (dataTable.Rows[i][dataTableColumnName[j]] != DBNull.Value)
                        {
                            if (double.TryParse(dataTable.Rows[i][dataTableColumnName[j]].ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out double parsedValue))
                            {
                                yDegeri = parsedValue;
                            }
                        }
                        if (j == 1)
                        {
                            xDegeri /= 1_000_000;
                        }
                        switch (j)
                        {
                            case 1:
                                series1.Points.AddXY(xDegeri, yDegeri);
                                break;
                            case 3:
                                series2.Points.AddXY(xDegeri, yDegeri);
                                break;
                            case 5:
                                series3.Points.AddXY(xDegeri, yDegeri);
                                break;
                            case 7:
                                series4.Points.AddXY(xDegeri, yDegeri);
                                break;
                            default:
                                break;
                        }
                    }
                }
                
            }

        }

        private void chartProperties(DataTable dataTable)
        {
            string[] dataTableColumnName = { "Freq", "S11_db", "Ang_F2_S11", "S21_dB", "Ang_F2_S21", "S12_dB", "Ang_F2_S12", "S22_dB", "Ang_F2_S22" };


            double minX = double.MinValue;
            double minY = double.MinValue;
            double maxX = double.MaxValue;
            double maxY = double.MaxValue;

            double maxFreq = double.MaxValue; 
            double minFreq = double.MinValue;

            foreach (DataRow row in dataTable.Rows)
            {
                double xDegeri;
                    //= Convert.ToDouble(row[dataTable.Columns[0].ColumnName]);

                if (double.TryParse(row[dataTable.Columns[0].ColumnName].ToString(),NumberStyles.Float,CultureInfo.InvariantCulture,out xDegeri))
                {
                    if (xDegeri > minX)
                    {
                        minX = xDegeri;
                    }

                    if (xDegeri < maxX)
                    {
                        maxX = xDegeri;
                    }

                    for (int j = 1; j < dataTableColumnName.Length; j+=2)
                    {
                        if (row[dataTableColumnName[j]] != DBNull.Value)
                        {
                            if (double.TryParse(row[dataTableColumnName[j]].ToString(), NumberStyles.Float, CultureInfo.InvariantCulture, out double parsedValue))
                            {
                                double yDegeri = parsedValue;

                                if (yDegeri > minY)
                                {
                                    minY = yDegeri;
                                }

                                if (yDegeri < maxY)
                                {
                                    maxY = yDegeri;
                                }
                            }
                        }
                    }
                }

                
            }

            
            
            chart.ChartAreas[0].AxisX.Title = "MHz";
            chart.ChartAreas[0].AxisX.Minimum = maxX/1_000_000-5;
            chart.ChartAreas[0].AxisX.Maximum = minX/1_000_000+5;
            chart.ChartAreas[0].AxisY.Maximum = minY+5;
            chart.ChartAreas[0].AxisY.Minimum = maxY-5;
            chart.ChartAreas[0].AxisY.Title = "dB";
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "N2"; // X ekseni için
            chart.ChartAreas[0].AxisY.LabelStyle.Format = "N2"; // Y ekseni için

        }
        public void saveChart(ExcelPackage package,Chart chart1, string sheetName)
        {
            var worksheet = package.Workbook.Worksheets[sheetName];
            int rowIndex = 5;
            int colIndex = 13;
            using(MemoryStream stream = new MemoryStream())
            {
                chart1.SaveImage(stream,ChartImageFormat.Png);
                var picture = worksheet.Drawings.AddPicture(sheetName, stream);
                picture.SetPosition(rowIndex, 0, colIndex, 0);
                picture.SetSize(1000, 475);
            }
        }
    }
}
