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
    public partial class AnaMenü : Form
    {
        public AnaMenü()
        {
            InitializeComponent();
        }

        private void salon_ekle_Click(object sender, EventArgs e)
        {
            Form SalonEkle = new SalonEkle();
            SalonEkle.ShowDialog();
            this.Hide();
        }

        private void tür_ekle_Click(object sender, EventArgs e)
        {
            Form TürEkle = new TürEkle();
            TürEkle.ShowDialog();
            this.Hide();
        }

        private void cikis_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Çıkmak İstediğinize Emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (cevap == DialogResult.Yes)
            {
                Application.Exit();
            }
            
        }

        private void film_ekle_Click(object sender, EventArgs e)
        {
            Form FilmEkle = new FilmEkle();
            FilmEkle.ShowDialog();
            this.Hide();
        }

       

        private void hakkinda_Click(object sender, EventArgs e)
        {
            Form Hakkında = new Hakkında();
            Hakkında.ShowDialog();
            this.Hide();
        }

        private void satis_Click(object sender, EventArgs e)
        {
            Form Satis = new Form2();
            Satis.ShowDialog();
            this.Hide();
        }

        private void seans_ekle_Click(object sender, EventArgs e)
        {
            Form SeansEkle = new SeansEkle();
            SeansEkle.ShowDialog();
            this.Hide();
        }

        
    }
}
