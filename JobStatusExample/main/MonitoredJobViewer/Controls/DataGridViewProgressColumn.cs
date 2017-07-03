using System.Windows.Forms;

namespace MonitoredJobViewer.Controls
{
    public class DataGridViewProgressColumn : DataGridViewImageColumn
    {
        public DataGridViewProgressColumn()
        {
            CellTemplate = new DataGridViewProgressCell();
        }

        public sealed override DataGridViewCell CellTemplate
        {
            get { return base.CellTemplate; }
            set { base.CellTemplate = value; }
        }
    }
}