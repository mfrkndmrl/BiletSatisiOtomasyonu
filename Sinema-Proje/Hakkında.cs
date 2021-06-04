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
    public partial class Hakkında : Form
    {
        public Hakkında()
        {
            InitializeComponent();
        }

        private void cikis_Click(object sender, EventArgs e)
        {
            Form AnaMenü = new AnaMenü();
            AnaMenü.Show();
            this.Hide(); 
        }

        private void Hakkında_Load(object sender, EventArgs e)
        {

        }
    }
}
