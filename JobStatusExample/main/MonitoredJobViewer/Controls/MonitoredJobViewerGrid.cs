using System.Drawing;
using System.Windows.Forms;
using MonitoredJobs;

// ReSharper disable LocalizableElement

namespace MonitoredJobViewer.Controls
{
    public partial class JobStatusViewGrid : UserControl
    {
        public JobStatusViewGrid()
        {
            InitializeComponent();
        }

        public void Start(IMonitoredJob job)
        {
            FormatTable();
            job.JobStarted += job_JobStarted;
            job.JobCompleted += job_JobCompleted;
            job.JobFailed += job_JobFailed;
            job.JobProgressed += job_JobProgressed;
            job.JobOverallStatusUpdated += job_JobOverallStatusUpdated;
            job.JobOverallCompleted += job_JobOverallCompleted;
            job.Start();
        }

        private void job_JobOverallCompleted(string msg)
        {
            MessageBox.Show(msg, "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void job_JobOverallStatusUpdated(string msg)
        {
            toolStripStatusLabel1.Text = msg;
        }

        private void job_JobProgressed(string name, string msg, int percent)
        {
            var row = GetRow(name);
            if (row == null) return;
            row.Cells[1].Value = "In Progress";
            row.Cells[2].Value = msg;
            row.Cells[3].Value = percent;
            row.DefaultCellStyle.BackColor = Color.LightBlue;
        }

        private void job_JobFailed(string name, string msg)
        {
            var row = GetRow(name);
            if (row == null) return;
            row.Cells[1].Value = "Failed";
            row.Cells[2].Value = msg;
            row.DefaultCellStyle.BackColor = Color.LightCoral;
        }

        private void job_JobCompleted(string name, string msg)
        {
            var row = GetRow(name);
            if (row == null) return;
            row.Cells[1].Value = "Completed";
            row.Cells[2].Value = msg;
            row.Cells[3].Value = 100;
            row.DefaultCellStyle.BackColor = Color.LightGreen;    
        }

        private void job_JobStarted(string name, string msg)
        {
            var obj = new object[] { name, "Started", msg, 0 };
            dataGridView1.Rows.Add(obj);
        }

        private void FormatTable()
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "Name";
            dataGridView1.Columns[1].Name = "Status";
            dataGridView1.Columns[2].Name = "Message";
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            var column = new DataGridViewProgressColumn();
            dataGridView1.Columns.Add(column);
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            column.HeaderText = @"Progress";
        }
        
        private DataGridViewRow GetRow(string name)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(name))
                {
                    return row;
                }
            }
            return null;
        }
    }
}
