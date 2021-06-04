using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Sinema_Proje
{
    public partial class SalonEkle : Form
    {

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\sinemailk.mdb");
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();

        Boolean yenikayitmi;
        int kayitno;


        public SalonEkle()
        {
            InitializeComponent();
        }


        void verileri_cek()
        {
            string seckomutu = "select *from salon_tanimlari";//  "* tümünü al..."
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            ds.Clear();
            da.Fill(ds, "salon_tanimlari");
            toolStripStatusLabel1.Text = "Kayıt Sayısı=" + ds.Tables["salon_tanimlari"].Rows.Count;

        }


        private void SalonEkle_Load(object sender, EventArgs e)
        {
            if (baglan.State == ConnectionState.Closed) baglan.Open();
            tbsadi.ReadOnly = tbskodu.ReadOnly = tbkoltuk.ReadOnly=true;
            kaydet.Visible = iptal.Visible = false;

            verileri_cek();

            bs.DataSource = ds.Tables["salon_tanimlari"];
            dataGridView1.DataSource = bs;
            tbskodu.DataBindings.Add("Text", bs, "salon_kodu");
            tbsadi.DataBindings.Add("Text", bs, "salon_adi");
            tbkoltuk.DataBindings.Add("Text", bs, "koltuk");
            
        }

        private void yenikayit_Click(object sender, EventArgs e)
        {
            tbsadi.Text = ""; tbkoltuk.Text = "";
            yenikayitmi = true;
            kaydet.Visible = iptal.Visible = true;
            tbsadi.ReadOnly =tbkoltuk.ReadOnly=false;
            tbsadi.Focus();
            kayitno = ds.Tables["salon_tanimlari"].Rows.Count;
        }

        private void kaydet_Click(object sender, EventArgs e)
        {

            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = baglan;
            if (int.Parse(tbkoltuk.Text) <= 80)
            {
                if (yenikayitmi)
                {

                    cmd.CommandText = "insert into salon_tanimlari (salon_adi,koltuk) Values (@salon_adi,@koltuk)";
                    cmd.Parameters.AddWithValue("@salon_adi", tbsadi.Text);
                    cmd.Parameters.AddWithValue("@koltuk", tbkoltuk.Text);

                }

                else
                {
                    cmd.CommandText = "update salon_tanimlari set salon_adi=@salon_adi,koltuk=@koltuk where salon_kodu=@salon_kodu";
                    cmd.Parameters.AddWithValue("@salon_adi", tbsadi.Text);
                    cmd.Parameters.AddWithValue("@koltuk", tbkoltuk.Text);
                    cmd.Parameters.AddWithValue("@salon_kodu", tbskodu.Text);

                }
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kaydınız Yapıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                verileri_cek();

                bs.Position = kayitno;
                kaydet.Visible = iptal.Visible = false;
                tbkoltuk.ReadOnly = tbsadi.ReadOnly = true;
            }
            else
            {
                MessageBox.Show("Programın Düzgün Çalışması İçin 80 ve daha az koltuk girilmelidir.");
                tbsadi.ReadOnly = true; tbkoltuk.ReadOnly = true;
                kaydet.Visible = iptal.Visible = false;
                verileri_cek();
            }
        }

        private void duzelt_Click(object sender, EventArgs e)
        {
            yenikayitmi = false;
            kaydet.Visible = iptal.Visible = true;
            tbsadi.ReadOnly = tbkoltuk.ReadOnly=false;
            tbsadi.Focus();
            kayitno = bs.Position;
        }

        private void iptal_Click(object sender, EventArgs e)
        {
            tbsadi.ReadOnly = true; tbkoltuk.ReadOnly = true;
            kaydet.Visible = iptal.Visible = false;
            verileri_cek();
        }

        private void sil_Click(object sender, EventArgs e)
        {
            kayitno = bs.Position;
            DialogResult cevap = MessageBox.Show("Silmek İstediğinize Eminmisiniz ?", "Uyarı", MessageBoxButtons.YesNo);
            if (cevap == DialogResult.Yes)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baglan;
                cmd.CommandText = "delete from salon_tanimlari where salon_kodu=@salon_kodu";
                cmd.Parameters.AddWithValue("@salon_kodu", int.Parse(tbskodu.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Silindi");

                verileri_cek();

                bs.Position = kayitno;
            }
        }

        private void ileri_Click(object sender, EventArgs e)
        {
            if (++bs.Position >= ds.Tables["salon_tanimlari"].Rows.Count - 1)
                ileri.Enabled = false;
            geri.Enabled = true;
        }

        private void geri_Click(object sender, EventArgs e)
        {
            if (--bs.Position <= 0)
                geri.Enabled = false;
            ileri.Enabled = true;
        }

        private void aranan_TextChanged(object sender, EventArgs e)
        {
            string seckomutu = "select*from salon_tanimlari where salon_adi like '%" + aranan.Text + "%' ";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            ds.Clear();
            da.Fill(ds, "salon_tanimlari");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) verileri_cek();
            else
            {
                if (aranan.Text != "") aranan_TextChanged(sender, e);                

            }
        }

        private void cikis_Click(object sender, EventArgs e)
        {
            Form AnaMenü = new AnaMenü();
            AnaMenü.Show();
            this.Hide();
        }
    }
}
