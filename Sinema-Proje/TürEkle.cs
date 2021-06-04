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
    public partial class TürEkle : Form
    {

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\sinemailk.mdb");
        public static DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();

        Boolean yenikayitmi;
        int kayitno;


        public TürEkle()
        {
            InitializeComponent();
        }

        void verileri_cek()
        {
            string seckomutu = "select *from tur_tanimlari";//  "* tümünü al..."
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            ds.Clear();
            da.Fill(ds, "tur_tanimlari");
            toolStripStatusLabel1.Text = "Kayıt Sayısı=" + ds.Tables["tur_tanimlari"].Rows.Count.ToString();
        }


        private void TürEkle_Load(object sender, EventArgs e)
        {
            if (baglan.State == ConnectionState.Closed) baglan.Open();
            tbtadi.ReadOnly = tbtkodu.ReadOnly = true;
            kaydet.Visible = iptal.Visible = false;

            verileri_cek();

            bs.DataSource = ds.Tables["tur_tanimlari"];
            dataGridView1.DataSource = bs;
            tbtkodu.DataBindings.Add("Text", bs, "tur_kodu");
            tbtadi.DataBindings.Add("Text", bs, "tur_adi");
        }

        private void yenikayit_Click(object sender, EventArgs e)
        {
            tbtadi.Text = "";
            yenikayitmi = true;
            kaydet.Visible = iptal.Visible = true;
            tbtadi.ReadOnly = false;
            tbtadi.Focus();
            kayitno = ds.Tables["tur_tanimlari"].Rows.Count;
        }

        private void kaydet_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = baglan;
            if (yenikayitmi)
            {
                cmd.CommandText = "insert into tur_tanimlari (tur_adi) Values (@tur_adi)";
                cmd.Parameters.AddWithValue("@tur_adi", tbtadi.Text);
            }
            else
            {
                cmd.CommandText = "update tur_tanimlari set tur_adi=@tur_adi where tur_kodu=@tur_kodu";
                cmd.Parameters.AddWithValue("@tur_adi", tbtadi.Text);
                cmd.Parameters.AddWithValue("@tur_kodu", tbtkodu.Text);
            }
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Yapıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            verileri_cek();
            bs.Position = kayitno;
            kaydet.Visible = iptal.Visible = false;
        }

        private void duzelt_Click(object sender, EventArgs e)
        {
            yenikayitmi = false;
            kaydet.Visible = iptal.Visible = true;
            tbtadi.ReadOnly = false;
            tbtadi.Focus();
            kayitno = bs.Position;
        }

        private void sil_Click(object sender, EventArgs e)
        {
            kayitno = bs.Position;
            DialogResult cevap = MessageBox.Show("Silmek İstediğinize Eminmisiniz ?", "Uyarı", MessageBoxButtons.YesNo);
            if (cevap == DialogResult.Yes)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baglan;
                cmd.CommandText = "delete from tur_tanimlari where tur_kodu=@tur_kodu";
                cmd.Parameters.AddWithValue("@tur_kodu", int.Parse(tbtkodu.Text));
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Silindi");
                verileri_cek();
                bs.Position = kayitno;
            }
        }

        private void iptal_Click(object sender, EventArgs e)
        {
            tbtadi.ReadOnly = true;
            kaydet.Visible = iptal.Visible = false;
            verileri_cek();
        }

        private void ileri_Click(object sender, EventArgs e)
        {
            if (++bs.Position >= ds.Tables["tur_tanimlari"].Rows.Count - 1)
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
            string seckomutu = "select*from tur_tanimlari where tur_adi like '%" + aranan.Text + "%' ";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            ds.Clear();
            da.Fill(ds, "tur_tanimlari");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) verileri_cek();
            else
            {
                if (aranan.Text != "") aranan_TextChanged(sender, e);                

            }
        }

        private void raportur_Click(object sender, EventArgs e)
        {
            Form RaporTür = new RaporTür();
            RaporTür.ShowDialog();
        }

        private void cikis_Click(object sender, EventArgs e)
        {
            Form AnaMenü = new AnaMenü();
            AnaMenü.Show();
            this.Hide();
        }
    }
}
