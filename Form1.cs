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
    public partial class Form1 : Form
    {
        public Form1 ()
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
            object header = this.dataGridView.Rows[index].HeaderCell.Value;
            if (header == null || header.Equals(indexStr))
                this.dataGridView.Rows[index].Cells[0].Value = indexStr;
        }

        private void checkTableToolStripMenuItem_Click (object sender, EventArgs e)
        {
            CheckTable(dataGridView);
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
                    MessageBox.Show(ex.Message);
                    return false;
                }               
            }
            return true;
        }

        private bool CheckRow (DataGridViewRow row)
        {
            bool result = false;
            if (ValidateCell (row.Cells[1]) && ValidateCell(row.Cells[2]))
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

        private List<Proces> readProcesesFromTable (DataGridView dataGrid )
        {
            if (CheckTable(dataGridView))
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
            return new Proces(GetIDFromRow(row.Cells[0]), GetTFromRow(row.Cells[1]), GetTFromRow(row.Cells[2]));
        }

        private int GetIDFromRow (DataGridViewCell data)
        {
            return Convert.ToInt32(data.Value.ToString());
        }

        private double GetTFromRow (DataGridViewCell data)
        {
            return Convert.ToDouble(data.Value.ToString());
        }

        private void executeToolStripMenuItem_Click (object sender, EventArgs e)
        {
            Executer executer = new Executer(readProcesesFromTable(dataGridView));
            executer.Execute();
            UpdateTableFromExecuter(dataGridView, executer);
            executer.Dispose();
        }

        private void UpdateTableFromExecuter (DataGridView dataGrid, Executer executer)
        {
            for (int i=0; i<executer.proceses.Count; i++)
            {
                UpdateRowFromProces(dataGrid.Rows[executer.proceses[i].ID - 1], executer.proceses[i]);
            }
        }

        private void UpdateRowFromProces (DataGridViewRow row, Proces proces)
        {
            row.Cells["WaitingTime"].Value = proces.WaitTime;
            row.Cells["ExectTime"].Value = proces.ExectTime;
        }


    }
}
