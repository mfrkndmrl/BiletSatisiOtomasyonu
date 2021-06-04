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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {

                progressBar1.Value += 2;

            }
            else
            {
                timer1.Enabled = false;
                Form KullanıcıGiris = new KullanıcıGiris();
                KullanıcıGiris.Show();
                this.Hide();
            }
        }
    }
}
