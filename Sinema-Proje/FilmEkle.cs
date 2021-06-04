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
    public partial class FilmEkle : Form
    {

        string numara_tut;

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\sinemailk.mdb");
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();

        Boolean yenikayitmi;
        int kayitno;


        public FilmEkle()
        {
            InitializeComponent();
        }

        void verileri_cek()//anabilim dalı tablosundaki verileri dataset tablosuna aktarıyor.
        {
            string seckomutu = "select fk.*,sa.salon_adi,tt.tur_adi,se.saat,se.tarih from film_kayit as fk,salon_tanimlari as sa,tur_tanimlari as tt,seans as se where fk.tur_kodu=tt.tur_kodu and fk.salon_kodu=sa.salon_kodu and fk.seans=se.seans";//as a anabilimdalı al as b bolumler al...
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            if (ds.Tables["film_kayit"] != null) ds.Tables["film_kayit"].Clear();
            da.Fill(ds, "film_kayit");
            toolStripStatusLabel1.Text = "Kayıt Sayısı=" + ds.Tables["film_kayit"].Rows.Count.ToString();
        }

        void veritabanina_bagla()
        {
            tbfkodu.DataBindings.Add("Text", bs, "film_kodu");
            tbfadi.DataBindings.Add("Text", bs, "film_adi");
            cbfturu.DataBindings.Add("SelectedValue", bs, "tur_kodu");
            cbsalon.DataBindings.Add("SelectedValue", bs, "salon_kodu");
            tbyadi.DataBindings.Add("Text", bs, "yonetmen_adi");
            cbsaat.DataBindings.Add("SelectedValue", bs, "seans");           
            dataGridView1.DataSource = bs;
        }

        bool ayni_isim_varmi()
        {
            string seckomutu = "select*from film_kayit where film_adi='" + tbfadi.Text + "'";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            if (ds.Tables["fadiara"] != null) ds.Tables["fadiara"].Clear();
            da.Fill(ds, "fadiara");
            if (ds.Tables["fadiara"].Rows.Count > 0) return true;
            else return false;
        }

        void cbdoldur()
        {
            string seckomutu = "select *from tur_tanimlari";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            da.Fill(ds, "tur_tanimlari"); da.Fill(ds, "tur_tanimlari1");
            cbfturu.DataSource = ds.Tables["tur_tanimlari"];
            cbfturu.ValueMember = "tur_kodu";
            cbfturu.DisplayMember = "tur_adi";

            fturuara.DataSource = ds.Tables["tur_tanimlari1"];
            fturuara.ValueMember = "tur_kodu";
            fturuara.DisplayMember = "tur_adi";


            string seckomutu1 = "select *from salon_tanimlari";
            OleDbDataAdapter da1 = new OleDbDataAdapter(seckomutu1, baglan);            
            da1.Fill(ds, "salon_tanimlari");
            cbsalon.DataSource = ds.Tables["salon_tanimlari"];
            cbsalon.ValueMember = "salon_kodu";
            cbsalon.DisplayMember = "salon_adi";

            string seckomutu2 = "select *from seans";
            OleDbDataAdapter da2 = new OleDbDataAdapter(seckomutu2, baglan);
            da2.Fill(ds, "seans"); da2.Fill(ds, "seans1");
            cbsaat.DataSource = ds.Tables["seans"];
            cbsaat.ValueMember = "seans";
            cbsaat.DisplayMember = "saat";

            cbtarih.DataSource = ds.Tables["seans1"];
            cbtarih.ValueMember = "seans";
            cbtarih.DisplayMember = "tarih";
        }

        private void FilmEkle_Load(object sender, EventArgs e)
        {
            if (baglan.State == ConnectionState.Closed)
                baglan.Open();

            cbdoldur();


            verileri_cek();
            bs.DataSource = ds.Tables["film_kayit"];
            veritabanina_bagla();

            
            kaydet.Visible = iptal.Visible = false;
        }

        private void yenikayit_Click(object sender, EventArgs e)
        {
            tbfadi.Clear(); tbyadi.Clear();
            tbfadi.Focus();
            yenikayitmi = true;
            kayitno = ds.Tables["film_kayit"].Rows.Count;
            kaydet.Visible = iptal.Visible = true;
            //pictureBox1.ImageLocation = "";
        }

        private void duzelt_Click(object sender, EventArgs e)
        {
            tbfadi.Focus();
            yenikayitmi = false;
            kayitno = ds.Tables["film_kayit"].Rows.Count;
            kaydet.Visible = iptal.Visible = true;
        }

        private void sil_Click(object sender, EventArgs e)
        {
            kayitno = bs.Position;
            DialogResult cevap = MessageBox.Show("Silmek İstediğinize Eminmisiniz ?", "Uyarı", MessageBoxButtons.YesNo);
            if (cevap == DialogResult.Yes)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baglan;
                cmd.CommandText = "delete from film_kayit where film_kodu=@film_kodu";
                cmd.Parameters.AddWithValue("@film_kodu", int.Parse(tbfkodu.Text));
                cmd.ExecuteNonQuery();

                MessageBox.Show("Kayıt Silindi");

                verileri_cek();
                bs.Position = kayitno;
            }
        }

        private void kaydet_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = baglan;
            if (yenikayitmi)
            {
                cmd.CommandText = "insert into film_kayit (film_adi,tur_kodu,salon_kodu,yonetmen_adi,seans) Values (@film_adi,@tur_kodu,@salon_kodu,@yonetmen_adi,@seans)";
                cmd.Parameters.AddWithValue("@film_adi", tbfadi.Text);
                cmd.Parameters.AddWithValue("@tur_kodu", cbfturu.SelectedValue);
                cmd.Parameters.AddWithValue("@salon_kodu", cbsalon.SelectedValue);
                cmd.Parameters.AddWithValue("@yonetmen_adi", tbyadi.Text);
                cmd.Parameters.AddWithValue("@seans", cbsaat.SelectedValue);
                cmd.Parameters.AddWithValue("@seans", cbtarih.SelectedValue);
                //cmd.Parameters.AddWithValue("@film_kodu", tbfkodu.Text);
            }
            else
            {
                cmd.CommandText = "update film_kayit set film_adi=@film_adi,tur_kodu=@tur_kodu,salon_kodu=@salon_kodu,yonetmen_adi=@yonetmen_adi,seans=@seans where film_kodu=@film_kodu";
                cmd.Parameters.AddWithValue("@film_adi", tbfadi.Text);
                cmd.Parameters.AddWithValue("@tur_kodu", cbfturu.SelectedValue);
                cmd.Parameters.AddWithValue("@salon_kodu", cbsalon.SelectedValue);
                cmd.Parameters.AddWithValue("@yonetmen_adi", tbyadi.Text);
                cmd.Parameters.AddWithValue("@seans", cbsaat.SelectedValue);
                cmd.Parameters.AddWithValue("@film_turu", tbfkodu.Text);

                
            }
            cmd.ExecuteNonQuery();//programı çalıştırır.
            MessageBox.Show("Kaydınız Yapıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            kaydet.Visible = iptal.Visible = false;

            verileri_cek();

            bs.Position = kayitno;
            }

        private void fturuara_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string seckomutu = "select fk.*,sa.salon_adi,tt.tur_adi,se.saat,se.tarih from film_kayit as fk,salon_tanimlari as sa,tur_tanimlari as tt,seans as se where fk.tur_kodu=tt.tur_kodu and fk.salon_kodu=sa.salon_kodu and fk.seans=se.seans and fk.tur_kodu=" + fturuara.SelectedValue;//as a anabilimdalı al as b bolumler al...
                OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
                if (ds.Tables["film_kayit"] != null) ds.Tables["film_kayit"].Clear();
                da.Fill(ds, "film_kayit");
                toolStripStatusLabel1.Text = "Kayıt Sayısı=" + ds.Tables["film_kayit"].Rows.Count.ToString();
            }
            catch { }
          }

        private void iptal_Click(object sender, EventArgs e)
        {
            kaydet.Visible = iptal.Visible = false;
            verileri_cek();
        }

        private void ileri_Click(object sender, EventArgs e)
        {
            if (++bs.Position >= ds.Tables["film_kayit"].Rows.Count - 1)
                ileri.Enabled = false;
            geri.Enabled = true;
        }

        private void geri_Click(object sender, EventArgs e)
        {
            if (--bs.Position <= 0)
                geri.Enabled = false;
            ileri.Enabled = true;
        }

        private void fadiara_TextChanged(object sender, EventArgs e)
        {

            string seckomutu = "select*from film_kayit where film_adi like '%" + fadiara.Text + "%' ";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            ds.Clear();
            da.Fill(ds, "film_kayit");
            cbdoldur();
            
            
        }

        private void yadiara_TextChanged(object sender, EventArgs e)
        {
            string seckomutu = "select*from film_kayit where yonetmen_adi like '%" + yadiara.Text + "%' ";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            ds.Clear();
            da.Fill(ds, "film_kayit");
            cbdoldur();
        }

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) verileri_cek();
            else
            {
                if (fadiara.Text != "") fadiara_TextChanged(sender, e);
                else if (yadiara.Text != "") yadiara_TextChanged(sender, e);
               
            }
        }

        private void cikis_Click(object sender, EventArgs e)
        {
            Form AnaMenü = new AnaMenü();
            AnaMenü.Show();
            this.Hide();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

      
    }
      }


