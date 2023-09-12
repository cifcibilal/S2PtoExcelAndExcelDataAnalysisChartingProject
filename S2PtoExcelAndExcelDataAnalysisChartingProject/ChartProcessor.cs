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
using System.Windows.Forms;
using System.Drawing;

namespace S2PtoExcelAndExcelDataAnalysisChartingProject
{
    public class ChartProcessor
    {
        private Chart chart;
        private TextBox textBoxMin;
        private TextBox textBoxMax;
        private TextBox textBoxdB;
        public ChartProcessor()
        {
            
        }
        public ChartProcessor(Chart chart)
        {
            this.chart = chart;
        }
        public ChartProcessor(Chart chart, TextBox textBoxMin, TextBox textBoxMax, TextBox textBoxdB)
        {
            this.chart = chart;
            this.textBoxMin = textBoxMin;
            this.textBoxMax = textBoxMax;
            this.textBoxdB = textBoxdB;

        }
        public ChartProcessor(Chart chart, TextBox textBoxMin, TextBox textBoxMax)
        {
            this.chart = chart;
            this.textBoxMin = textBoxMin;
            this.textBoxMax = textBoxMax;
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
        public void ShowDataOnChart(DataTable dataTable)
        {
            chart.Series.Clear();
            SetChatAxisProperties(dataTable);

            string[] seriesNames = { "S11 - dB", "S21 - dB", "S12 - dB", "S22 - dB" };
            string[] dataTableColumnName = { "Freq", "S11_db", "Ang_F2_S11", "S21_dB", "Ang_F2_S21", "S12_dB", "Ang_F2_S12", "S22_dB", "Ang_F2_S22" };

            Series series1 = new Series("S11:dB");
            Series series2 = new Series("S21:dB");
            Series series3 = new Series("S12:dB");
            Series series4 = new Series("S22:dB");
            chart.Series.Add(series2);
            chart.Series.Add(series3);
            chart.Series.Add(series4);
            chart.Series.Add(series1);
            series1.ChartType = SeriesChartType.Line; // Çizgi grafiği
            series1.BorderWidth = 2; // Çizgi kalınlığı
            series2.ChartType = SeriesChartType.Line; // Çizgi grafiği
            series2.BorderWidth = 2; // Çizgi kalınlığı
            series3.ChartType = SeriesChartType.Line; // Çizgi grafiği
            series3.BorderWidth = 2; // Çizgi kalınlığı
            series4.ChartType = SeriesChartType.Line; // Çizgi grafiği
            series4.BorderWidth = 2; // Çizgi kalınlığı

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                double xDegeri = Convert.ToDouble(dataTable.Rows[i][dataTable.Columns[0].ColumnName]);
                for (int j = 1; j < dataTableColumnName.Length; j+=2)
                {
                    double yDegeri = 0;
                    if (dataTable.Rows[i][dataTableColumnName[j]] != DBNull.Value)
                    {
                        if (double.TryParse(dataTable.Rows[i][dataTableColumnName[j]].ToString(), out double parsedValue))
                        {
                            yDegeri = parsedValue;
                        }
                        else
                        {

                        }

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
        private void SetChatAxisProperties(DataTable dataTable)
        {
            string[] columnName = { "Freq", "S11_db", "Ang_F2_S11", "S21_dB", "Ang_F2_S21", "S12_dB", "Ang_F2_S12", "S22_dB", "Ang_F2_S22" };

            double minX = double.MaxValue;
            double maxX = double.MinValue;
            double minY = double.MaxValue;
            double maxY = double.MinValue;

            foreach (DataRow row in dataTable.Rows)
            {
                double xDegeri = Convert.ToDouble(row[dataTable.Columns[0].ColumnName]);

                if (xDegeri < minX)
                    minX = xDegeri;

                if (xDegeri > maxX)
                    maxX = xDegeri;

                for (int j = 1; j < columnName.Length; j+=2)
                {
                    if (row[columnName[j]] != DBNull.Value)
                    {
                        if (double.TryParse(row[columnName[j]].ToString(), out double parsedValue))
                        {
                            double yDegeri = parsedValue;

                            if (yDegeri < minY)
                                minY = yDegeri;

                            if (yDegeri > maxY)
                                maxY = yDegeri;
                        }
                    }
                }
            }

            chart.ChartAreas[0].AxisX.Title = "MHz";
            if (textBoxMax.Text.Equals(""))
            {
                chart.ChartAreas[0].AxisX.Maximum = maxX+5;
            }
            else
            {
                chart.ChartAreas[0].AxisX.Maximum = int.Parse(textBoxMax.Text) + 5;
            }
            if (textBoxMin.Text.Equals(""))
            {
                chart.ChartAreas[0].AxisX.Minimum = minX-5;
            }
            else
            {
                chart.ChartAreas[0].AxisX.Minimum = int.Parse(textBoxMin.Text) - 5;
            }
            chart.ChartAreas[0].AxisY.Maximum = maxY + 5;
            chart.ChartAreas[0].AxisY.Minimum = minY - 5;
            chart.ChartAreas[0].AxisY.Title = "dB";
            chart.ChartAreas[0].AxisX.LabelStyle.Format = "N2"; // X ekseni için
            chart.ChartAreas[0].AxisY.LabelStyle.Format = "N2"; // Y ekseni için
        }

        public void LimitLineEkle(string limitLineName)
        {
            double x1 = double.Parse(textBoxMin.Text);
            double x2 = double.Parse(textBoxMax.Text);
            double y = double.Parse(textBoxdB.Text);

            Series existingSeries = chart.Series.FindByName(limitLineName);

            if (existingSeries != null)
            {
                chart.Series.Remove(existingSeries);
            }

            Series series = new Series();
            series.Name = limitLineName;
            series.ChartType = SeriesChartType.Line;
            series.BorderWidth = 1;

            if (series.Name.Equals("S11_Limitline"))
            {
                series.Color = Color.Black;
            }
            else if (series.Name.Equals("S21_Limitline"))
            {
                series.Color = Color.MidnightBlue;
            }
            else if (series.Name.Equals("S12_Limitline"))
            {
                series.Color = Color.DarkRed;
            }
            else if (series.Name.Equals("S22_Limitline"))
            {
                series.Color = Color.DarkGreen;
            }
            series.BorderDashStyle = ChartDashStyle.Dash;
            series.Points.AddXY(x1, y);
            series.Points.AddXY(x2, y);

            chart.Series.Add(series);

            chart.Invalidate();
        }
    }
}
