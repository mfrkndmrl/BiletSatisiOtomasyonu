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
    public partial class SeansEkle : Form
    {

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\sinemailk.mdb");
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();

        Boolean yenikayitmi;
        int kayitno;


        public SeansEkle()
        {
            InitializeComponent();
        }

        void verileri_cek()
        {
            string seckomutu = "select *from seans";//  "* tümünü al..."
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            ds.Clear();
            da.Fill(ds, "seans");
            toolStripStatusLabel1.Text = "Kayıt Sayısı=" + ds.Tables["seans"].Rows.Count;

        }

        private void SeansEkle_Load(object sender, EventArgs e)
        {
            if (baglan.State == ConnectionState.Closed) baglan.Open();
            tbsaat.ReadOnly = tbsekodu.ReadOnly = true;
            kaydet.Visible = iptal.Visible = false;

            verileri_cek();

            bs.DataSource = ds.Tables["seans"];
            dataGridView1.DataSource = bs;
            tbsekodu.DataBindings.Add("Text", bs, "seans");
            tbsaat.DataBindings.Add("Text", bs, "saat");
            //tarih.DataBindings.Add("SelectedValue", bs, Convert.ToDateTime((tarih.Text));
        }

        private void yenikayit_Click(object sender, EventArgs e)
        {
            tbsaat.Text = "";
            yenikayitmi = true;
            kaydet.Visible = iptal.Visible = true;
            tbsaat.ReadOnly = false;
            kayitno = ds.Tables["seans"].Rows.Count;
        }

        private void duzelt_Click(object sender, EventArgs e)
        {
            yenikayitmi = false;
            kaydet.Visible = iptal.Visible = true;
            tbsaat.ReadOnly = false;
            tbsaat.Focus();
            kayitno = bs.Position;
        }

        private void kaydet_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = baglan;
            if (yenikayitmi)
            {
                cmd.CommandText = "insert into seans (saat,tarih) Values (@saat,@tarih)";
                cmd.Parameters.AddWithValue("@saat", tbsaat.Text);
                cmd.Parameters.AddWithValue("@tarih", tarih.Text);
            }
            else
            {
                cmd.CommandText = "update seans set saat=@saat,tarih=@tarih where seans=@seans";
                cmd.Parameters.AddWithValue("@saat", tbsaat.Text);
                cmd.Parameters.AddWithValue("@tarih", tarih.Text);
                cmd.Parameters.AddWithValue("@seans", tbsekodu.Text);
            }
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Yapıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            verileri_cek();

            bs.Position = kayitno;
            kaydet.Visible = iptal.Visible = false;
        }

        private void iptal_Click(object sender, EventArgs e)
        {
            tbsaat.ReadOnly = true;
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
                cmd.CommandText = "delete from seans where seans=@seans";
                cmd.Parameters.AddWithValue("@seans", tbsekodu.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Silindi");

                verileri_cek();

                bs.Position = kayitno;
            }
        }

        private void ileri_Click(object sender, EventArgs e)
        {
            if (++bs.Position >= ds.Tables["seans"].Rows.Count - 1)
                ileri.Enabled = false;
            geri.Enabled = true;
        }

        private void geri_Click(object sender, EventArgs e)
        {
            if (--bs.Position <= 0)
                geri.Enabled = false;
            ileri.Enabled = true;
        }

        private void saranan_TextChanged(object sender, EventArgs e)
        {
            string seckomutu = "select*from seans where saat like '%" + saranan.Text + "%' ";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            ds.Clear();
            da.Fill(ds, "seans");
        }

        private void taranan_TextChanged(object sender, EventArgs e)
        {
            string seckomutu = "select*from seans where tarih like '%" + taranan.Text + "%' ";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            ds.Clear();
            da.Fill(ds, "seans");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) verileri_cek();
            else
            {
                if (saranan.Text != "") saranan_TextChanged(sender, e);
                else if (taranan.Text != "") taranan_TextChanged(sender, e);
                
            }
        }

        private void cikis_Click(object sender, EventArgs e)
        {
            Form AnaMenü = new AnaMenü();
            AnaMenü.Show();
            this.Hide();
        }

        private void raportur_Click(object sender, EventArgs e)
        {

        }


    }
}
