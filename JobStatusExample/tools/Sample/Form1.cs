using System.Windows.Forms;
using MonitoredJobViewer.Controls;
using SampleJobs;

namespace Sample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var ctl = new JobStatusViewGrid();
            Controls.Add(ctl);
            ctl.Dock = DockStyle.Fill;
            var job = new SampleJob();
            ctl.Start(job);
        }
    }
}
