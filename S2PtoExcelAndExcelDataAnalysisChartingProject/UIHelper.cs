using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S2PtoExcelAndExcelDataAnalysisChartingProject
{
    public class UIHelper
    {
        private DataGridView datagridView;
        public UIHelper(DataGridView dataGridView) 
        {
            this.datagridView = dataGridView;
        }
        public void dataGridSutunDuzenle()
        {
            for (int i = 2; i < datagridView.Columns.Count; i+=2)
            {
                datagridView.Columns[i].Visible = false;
            }
        }
    }
}
