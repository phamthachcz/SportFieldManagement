
using BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace VIS_UI
{
    public partial class fTimeTable : Form
    {
        private int test;
        public fTimeTable()
        {
            InitializeComponent();
            loadDataGridView();
        }

        void loadDataGridView()
        {
            DataTable dt = new DataTable();

            var lst = TimeTableService.Instance.GetTimeTableByDay(12, 1);

            Dictionary<int, List<string>> sportStatus = new Dictionary<int, List<string>>();
            foreach(var item in lst)
            {
                if (!sportStatus.ContainsKey(item.Facility_id))
                {
                    sportStatus[item.Facility_id] = new List<string>();
                    sportStatus[item.Facility_id].Add(item.Facility_id.ToString());
                }
                if (!dt.Columns.Contains("Name"))
                {
                    dt.Columns.Add("Name");
                }
                if(!dt.Columns.Contains(item.Start_time.ToString("HH:mm") + " To " + item.End_time.ToString("HH:mm"))){
                    dt.Columns.Add(item.Start_time.ToString("HH:mm") + " To " + item.End_time.ToString("HH:mm"));
                }
                
                if(item.Status == 0)
                {
                    sportStatus[item.Facility_id].Add("Available");
                }
                else if(item.Status == 1)
                {
                    sportStatus[item.Facility_id].Add("Occupied");
                }
                else
                {
                    sportStatus[item.Facility_id].Add("Over");
                }

            }

            foreach(var key in sportStatus)
            {
                dt.Rows.Add(key.Value.ToArray());
                
            }



            test = 1;
            dtgvTimeTable.DataSource = dt;
            


        }

        private void dtgvTimeTable_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            
        }

        private void dtgvTimeTable_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            
        }
    }
}
