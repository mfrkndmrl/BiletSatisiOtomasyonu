using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinema_Proje
{
    public partial class RaporTür : Form
    {
        public RaporTür()
        {
            InitializeComponent();
        }

        private void RaporTür_Load(object sender, EventArgs e)
        {
            ReportDataSource rds=new ReportDataSource("DataSet1", TürEkle.ds.Tables["tur_tanimlari"]);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.LocalReport.Refresh();
            this.reportViewer1.RefreshReport();
            //this.reportViewer2.RefreshReport();
        }
    }
}
