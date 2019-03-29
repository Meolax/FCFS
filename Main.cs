using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FCFS.Models;

namespace FCFS
{
    public partial class Main : Form
    {
        public Main ()
        {
            InitializeComponent();
        }

        public static readonly string EmptyTable = "Пустая таблица";
        public static readonly string errorConvertingArgument = "Это не число";
        public static readonly string matchOfTc = "Время уже занято";

        List<int> TcList = new List<int>();
        List<Proces> processes = new List<Proces> ();

        int RowNumber
        {
            get { return RowNumber; }
            set
            {
                //Добавить цвет в ячейку обработки
            }
        }

        private void dataGridView_RowPrePaint (object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int index = e.RowIndex;
            string indexStr = (index + 1).ToString();
            object header = this.dataGridMain.Rows[index].HeaderCell.Value;
            if (header == null || header.Equals(indexStr))
                this.dataGridMain.Rows[index].Cells[0].Value = indexStr;
        }

        private void checkTableToolStripMenuItem_Click (object sender, EventArgs e)
        {
            CheckTable(dataGridMain);
        }

        #region CheckTable
        private bool CheckTable (DataGridView dataGrid)
        {
            TcList.Clear();
            int RowNumber = 0;
            int RowsCount = dataGrid.Rows.Count == 1 ? 1 : dataGrid.Rows.Count -1;
            while ( RowNumber < RowsCount )
            {
               try
                {
                    CheckRow(dataGrid.Rows[RowNumber]);
                    RowNumber++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message+"Check Table");
                    return false;
                }               
            }
            return true;
        }

        private bool CheckRow (DataGridViewRow row)
        {
            bool result = false;
            if (ValidateCell (row.Cells[1]) && ValidateCell(row.Cells[2]) && ValidateCell(row.Cells[3]))
            {
                return true;
            }
            return result;
        }

        private bool ValidateCell (DataGridViewCell data)
        {
            try
            {
                Convert.ToDouble(data.Value.ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message+" [" + data.RowIndex + ", " + data.ColumnIndex+"]");
            }
        }
        #endregion

        #region ReadProceses
        private List<Proces> readProcesesFromTable (DataGridView dataGrid )
        {
            if (CheckTable(dataGridMain))
            {
                List<Proces> proceses = new List<Proces>();
                int RowsCount = dataGrid.Rows.Count == 1 ? 1 : dataGrid.Rows.Count - 1;
                for (int row = 0; row < RowsCount; row++)
                {
                    proceses.Add(readProceseFromRow(dataGrid.Rows[row]));
                }
                return proceses;
            }
            return null;
        }

        private Proces readProceseFromRow (DataGridViewRow row)
        {
            return new Proces(GetIDFromRow(row.Cells[0]), GetTFromRow(row.Cells[1]), GetTFromRow(row.Cells[2]), GetTFromRow(row.Cells[3]));
        }

        private int GetIDFromRow (DataGridViewCell data)
        {
            return Convert.ToInt32(data.Value.ToString());
        }

        private int GetTFromRow (DataGridViewCell data)
        {
            return Convert.ToInt32(data.Value.ToString());
        }
        #endregion

        private void executeToolStripMenuItem_Click (object sender, EventArgs e)
        {
            
            
            try
            {
                Executer executer = new Executer(readProcesesFromTable(dataGridMain));
                Proces.TcList.Clear();
                executer.Execute();
                UpdateTableFromExecuter(dataGridMain, executer);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Proces.TcList.Clear();
            }
        }

        private void UpdateTableFromExecuter (DataGridView dataGrid, Executer executer)
        {
            UpdateColumsDiagram(executer.EndTime);
            for (int i=0; i<executer.CompleteProceses.Count; i++)
            {
                UpdateRowFromProces(dataGrid.Rows[executer.CompleteProceses[i].ID - 1], executer.CompleteProceses[i]);
            }
            UpdateAvgTimeIndicators(executer);
        }


        private void UpdateAvgTimeIndicators (Executer executer)
        {
            dataGridAvgTime.Rows.Clear();
            dataGridAvgTime.Rows.Add();
            dataGridAvgTime.Rows[0].Cells[0].Value = executer.AvgWaitTime;
            dataGridAvgTime.Rows[0].Cells[1].Value = executer.AvgExectTime;
        }
        private void UpdateRowFromProces (DataGridViewRow row, Proces proces)
        {
            row.Cells["WaitingTime"].Value = proces.WaitTime;
            row.Cells["ExectTime"].Value = proces.ExectTime;
            DrawDiagramProces(proces);
        }

        private void DrawDiagramProces (Proces proces)
        {
            for (int i= 0; i< proces.History.Count; i++)
            {
                DrawCell(proces.ID, proces.Tc+i, proces.Tc+i+1, proces.History[i] == 1 ? Color.Green : Color.Red);
            }
            
        }

        public void DrawCell (int ID, int from, int to, Color color)
        {
            for (int i = from;  i < to; i++)
            {
                dataGridMain.Rows[ID - 1].Cells[i+6].Style.BackColor = color;
                dataGridMain.Rows[ID - 1].Cells[i+6].Style.ForeColor = color;
                dataGridMain.Rows[ID - 1].Cells[i+6].Style.SelectionBackColor = color;
                dataGridMain.Rows[ID - 1].Cells[i+6].Style.SelectionForeColor = color;
            }
        }
        private void UpdateColumsDiagram (int count)
        {
            ClearColumns();
            for (int i=0; i<count; i++)
            {
                dataGridMain.Columns.Add(i.ToString(), i.ToString());
                dataGridMain.Columns[i.ToString()].Width = dataGridMain.Rows[1].Height;
            }
        }

        private void ClearColumns ()
        {
            while (dataGridMain.Columns.Count > 6)
            {
                dataGridMain.Columns.RemoveAt(6);
            }
        }
    }
}
