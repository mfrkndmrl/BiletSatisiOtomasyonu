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
    public partial class KullanıcıGiris : Form
    {
        public KullanıcıGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbkullanıcı.Text == "mfd" && tbsifre.Text == "1453")
            {
                MessageBox.Show("Hoşgeldin Muhammet Furkan");
                Form AnaMenü = new AnaMenü();
                AnaMenü.ShowDialog();
                this.Hide();
            }
            else if (tbkullanıcı.Text == "" && tbsifre.Text == "")
            {
                MessageBox.Show("Kullanıcı Adı ve Şifre Girilmedi.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (tbkullanıcı.Text == "")
            {
                MessageBox.Show("Kullanıcı Adı Girilmedi.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbkullanıcı.Focus();
            }
            else if (tbsifre.Text == "")
            {
                MessageBox.Show("Şifre Girilmedi.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbsifre.Focus();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbkullanıcı.Clear(); tbsifre.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                tbsifre.PasswordChar = '\0';
            }
            else
            {
                tbsifre.PasswordChar = '*';
            }
        }

        private void KullanıcıGiris_Load(object sender, EventArgs e)
        {
            tbsifre.PasswordChar = '*';
        }

        private void cikis_Click(object sender, EventArgs e)
        {
            DialogResult cevap = MessageBox.Show("Çıkmak İstediğinize Emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cevap == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
