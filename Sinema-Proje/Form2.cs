using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinema_Proje
{
    public partial class Form2 : Form
    {
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\sinemailk.mdb");
        public static DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        BindingSource bs2 = new BindingSource();
        BindingSource bs3 = new BindingSource();
        BindingSource bs4 = new BindingSource();



        ArrayList koltuklar = new ArrayList();

        Button BasılanButon1;

        string[] yolcular = new string[100];

        string[] koltukcins = new string[100];
        int koltukSayisi = 0;

        public Form2()
        {
            InitializeComponent();
        }
        void koltuksay()
        {
            koltukno.Text = "";
            groupBox1.Controls.Clear();
            groupBox1.Visible = true;

            string sayi = textBox2.Text;
            bool devam = false;

            for (int i = 0; i < sayi.Length; i++)
            {
                if (!char.IsDigit(sayi[i]))
                    devam = true;
            }

            if (!devam && sayi.Length != 0)
            {
                if (int.Parse(textBox2.Text) <= Convert.ToInt32(textBox2.Text) && int.Parse(textBox2.Text) > 0)
                {
                    koltukSayisi = int.Parse(textBox2.Text);
                    koltukCiz(koltukSayisi);

                    for (int i = 0; i <= koltukSayisi; i++)
                    {
                        koltukcins[i] = " ";
                    }
                }
            }
        }
        void koltukCiz(int koltukSayisi)
        {
            koltukSayisi = Convert.ToInt32(textBox2.Text);
            int sutun = 0, b = 0, satir = 0; ;
            int i;
            for (i = 0; i < koltukSayisi; i++)
            {
                if (i % 9 == 0 && i != 0)
                {
                    satir++;
                    sutun = 0;
                    b = 0;
                }
                else
                    if (i % 2 == 0 && i != 0)
                        b = 5;
                Button koltuk1 = new Button();
                koltuk1.Name = i.ToString();
                koltuk1.TabIndex = i;
                koltuk1.TabStop = false;
                koltuk1.Text = (i + 1).ToString();
                koltuk1.Size = new System.Drawing.Size(30, 30);
                Point p = new System.Drawing.Point(30 + sutun * koltuk1.Width + sutun * 10 + b, 30 + satir * koltuk1.Height * 3 / 2);
                koltuk1.Location = p;
                koltuk1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
                koltuk1.Visible = true;
                koltuk1.MouseDown += new MouseEventHandler(this.koltuklarClick);
                koltuk1.BackColor = Color.Gray;
                koltuk1.BringToFront();
                groupBox1.Controls.Add(koltuk1);
                this.AutoSize = true;
                koltuklar.Add(koltuk1);
                sutun++;
                string seckomutu = "select * from satis";
                OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
                if (ds.Tables["satis"] != null)
                    ds.Tables["satis"].Clear();
                da.Fill(ds, "satis");
                int koltuksayisi1 = ds.Tables["satis"].Rows.Count;
                for (int a = 0; a < koltuksayisi1; a++)
                {
                    if (i + 1 == int.Parse(ds.Tables["satis"].Rows[a]["koltukno"].ToString()) && textBox1.Text == ds.Tables["satis"].Rows[a]["salon_kodu"].ToString())
                    {
                        if (ds.Tables["satis"].Rows[a]["turu"].ToString() == "Satış")
                        {
                            //koltuk1.Text = "S";

                            koltuk1.BackColor = Color.Red;
                        }
                        else
                        {
                            //koltuk1.Text = "R";

                            koltuk1.BackColor = Color.Blue;
                        }



                    }

                }
            }
            satir += koltukSayisi / 8;
            groupBox1.Size = new Size(400, (int)satir * 30 + 300);
        }

        private void koltuklarClick(object sender, MouseEventArgs e)
        {


            try
            {
                BasılanButon1 = (Button)sender;
                if (BasılanButon1.BackColor == Color.Red)
                {
                    MessageBox.Show(" Koltuk Zaten Satış Yapılmıştır.");

                }
                else if (BasılanButon1.BackColor == Color.Blue)
                {
                    MessageBox.Show("Koltuk Zaten Rezerve Edilmiştir.Satış Yapmak İstiyorsanız aşağıdaki tablodan satış yapılmak istenen koltuğu seçip Satış Yap butonuna tıklayınız.");
                }
                else
                {
                    ad.Text = ""; ucret.Text = "";
                    BasılanButon1 = (Button)sender;
                    koltukno.Text = BasılanButon1.Text;
                    groupBox2.Visible = true;
                    radioButton1.Checked = true;

                    bs4.DataSource = ds.Tables["satis"];
                    ad.DataBindings.Add("Text", bs4, "satis_adi");
                    ucret.DataBindings.Add("Text", bs4, "ücret");
                    satiskodu.DataBindings.Add("Text", bs4, "satis_kodu");

                }
            }
            catch
            {


            }


        }










        void verileri_cek()
        {
            string seckomutu = "select f.*,s.seans,s.saat,s.tarih,tt.tur_kodu,tt.tur_adi from film_kayit as f , seans as s ,tur_tanimlari as tt where f.seans=s.seans and f.tur_kodu=tt.tur_kodu";//  "* tümünü al..."
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            if (ds.Tables["film_kayit1"] != null) ds.Tables["film_kayit1"].Clear();
            da.Fill(ds, "film_kayit1"); da.Fill(ds, "film_kayit2");


        }

        void verileri_cek2()
        {
            string seckomutu = "select * from salon_tanimlari";//  "* tümünü al..."
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            if (ds.Tables["salon_tanimlari"] != null) ds.Tables["salon_tanimlari"].Clear();
            da.Fill(ds, "salon_tanimlari"); da.Fill(ds, "salon_tanimlari1");


        }

        void verileri_cek3()
        {
            string seckomutu = "select s.*,f.film_adi,f.film_kodu,st.salon_kodu,st.salon_adi from satis as s,film_kayit as f,salon_tanimlari as st where s.film_kodu=f.film_kodu and s.salon_kodu=st.salon_kodu";//  "* tümünü al..."
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            if (ds.Tables["satis"] != null) ds.Tables["satis"].Clear();
            da.Fill(ds, "satis");

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            if (baglan.State == ConnectionState.Closed) baglan.Open();

            verileri_cek();
            bs.DataSource = ds.Tables["film_kayit1"];
            dataGridView2.DataSource = bs;
            tarih.DataBindings.Add("Text", bs, "tarih");
            saat.DataBindings.Add("Text", bs, "saat");
            filmadi.DataBindings.Add("Text", bs, "film_kodu");
            verileri_cek2();

            bs2.DataSource = ds.Tables["salon_tanimlari"];
            dataGridView1.DataSource = bs2;
            textBox1.DataBindings.Add("Text", bs2, "salon_kodu");
            textBox2.DataBindings.Add("Text", bs2, "koltuk");
            tbsadi.DataBindings.Add("Text", bs2, "salon_adi");

            verileri_cek3();
            bs4.DataSource = ds.Tables["satis"];
            dataGridView3.DataSource = bs4;

            string seckomutu1 = "select *from salon_tanimlari";
            OleDbDataAdapter da1 = new OleDbDataAdapter(seckomutu1, baglan);
            da1.Fill(ds, "salon_tanimlari1");
            cbsadi.DataSource = ds.Tables["salon_tanimlari"];
            cbsadi.ValueMember = "salon_kodu";
            cbsadi.DisplayMember = "salon_adi";



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add(textBox1.Text);
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string seckomutu = "select f.*,s.seans,s.saat,s.tarih from film_kayit as f , seans as s where f.seans=s.seans and  f.salon_kodu like '%" + comboBox1.SelectedItem + "%'";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            if (ds.Tables["film_kayit1"] != null) ds.Tables["film_kayit1"].Clear();
            da.Fill(ds, "film_kayit1");


        }





        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            koltuksay();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = baglan;
            if (radioButton1.Checked == true)
            {
                cmd.CommandText = "insert into satis (film_kodu,salon_kodu,satis_adi,ücret,tarih,saat,koltukno,turu) Values (@film_kodu,@salon_kodu,@satis_adi,@ücret,@seans_tarih,@seans_saat,@koltukno,@turu)";
                cmd.Parameters.AddWithValue("@film_kodu", filmadi.Text);
                cmd.Parameters.AddWithValue("@salon_kodu", textBox1.Text);
                cmd.Parameters.AddWithValue("@satis_adi", ad.Text);
                cmd.Parameters.AddWithValue("@ücret", ucret.Text);
                cmd.Parameters.AddWithValue("@tarih", tarih.Text);
                cmd.Parameters.AddWithValue("@saat", saat.Text);
                cmd.Parameters.AddWithValue("@koltukno", koltukno.Text);
                cmd.Parameters.AddWithValue("@turu", radioButton1.Text);



            }
            else
            {
                cmd.CommandText = "insert into satis (film_kodu,salon_kodu,satis_adi,ücret,tarih,saat,koltukno,turu) Values (@film_kodu,@salon_kodu,@satis_adi,@ücret,@seans_tarih,@seans_saat,@koltukno,@turu)";
                cmd.Parameters.AddWithValue("@film_kodu", filmadi.Text);
                cmd.Parameters.AddWithValue("@salon_kodu", textBox1.Text);
                cmd.Parameters.AddWithValue("@satis_adi", ad.Text);
                cmd.Parameters.AddWithValue("@ücret", ucret.Text);
                cmd.Parameters.AddWithValue("@tarih", tarih.Text);
                cmd.Parameters.AddWithValue("@saat", saat.Text);
                cmd.Parameters.AddWithValue("@koltukno", koltukno.Text);
                cmd.Parameters.AddWithValue("@turu", radioButton2.Text);

            }
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Yapıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            verileri_cek();
            if (radioButton1.Checked == true)
            {
                BasılanButon1.BackColor = Color.Red;
                BasılanButon1.Enabled = false;
                //BasılanButon1.Text = "S";
            }
            else if (radioButton2.Checked == true)
            {
                BasılanButon1.BackColor = Color.Blue;
                BasılanButon1.Enabled = false;
                //BasılanButon1.Text = "R";

            }
            ad.Text = "";

            ucret.Text = "";



            {
                groupBox2.Visible = false;
                ad.Text = "";



            }
            verileri_cek2();
        }




        private void duzelt_Click(object sender, EventArgs e)
        {
            try
            {
                BasılanButon1 = (Button)sender;

                groupBox2.Visible = true;
                kaydet.Visible = iptal.Visible = true;
                ad.Focus();
                bs4.DataSource = ds.Tables["satis"];
                ad.DataBindings.Add("Text", bs4, "satis_adi");
                ucret.DataBindings.Add("Text", bs4, "ücret");
                satiskodu.DataBindings.Add("Text", bs4, "satis_kodu");
                koltukno.DataBindings.Add("Text", bs4, "koltukno");

            }
            catch { }






        }

        private void ileri_Click(object sender, EventArgs e)
        {
            if (++bs4.Position >= ds.Tables["satis"].Rows.Count - 1)
                ileri.Enabled = false;
            geri.Enabled = true;
        }

        private void geri_Click(object sender, EventArgs e)
        {
            if (--bs4.Position <= 0)
                geri.Enabled = false;
            ileri.Enabled = true;
        }

        private void btnsatis_Click(object sender, EventArgs e)
        {


            try
            {
                groupBox2.Visible = true;

                bs3.DataSource = ds.Tables["satis"];
                ad.DataBindings.Add("Text", bs3, "satis_adi");
                ucret.DataBindings.Add("Text", bs3, "ücret");
                satiskodu.DataBindings.Add("Text", bs3, "satis_kodu");
            }
            catch { }

            BasılanButon1 = (Button)sender;
            DialogResult cevap = MessageBox.Show("Satış Yapmak İstediğinize Eminmisiniz ?", "Uyarı", MessageBoxButtons.YesNo);
            if (cevap == DialogResult.Yes)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baglan;
                cmd.CommandText = "update satis set turu=@turu where satis_kodu=@satis_kodu";
                cmd.Parameters.AddWithValue("@turu", radioButton1.Text);
                cmd.Parameters.AddWithValue("@salon_kodu", satiskodu.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Satış Yapıldı");
                verileri_cek2();
                groupBox2.Visible = false;





            }


        }

        private void kaydet_Click(object sender, EventArgs e)
        {
            //update satis set film_kodu=@film_kodu,salon_kodu=@salon_kodu,satis_adi=@satis_adi,ücret=@ücret,tarih=@tarih,saat=@saat,koltukno=@koltukno,turu=@turu where satis_kodu=@satis_kodu";


            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = baglan;
            // cmd.CommandText = " update satis set film_kodu=@film_kodu,salon_kodu=@salon_kodu,satis_adi=@satis_adi,ücret=@ücret,tarih=@tarih,saat=@saat,koltukno=@koltukno,turu=@turu where satis_kodu=@satis_kodu";

            BasılanButon1 = (Button)sender;
            cmd.CommandText = "update satis set film_kodu=@film_kodu,salon_kodu=@salon_kodu,satis_adi=@satis_adi,ücret=@ücret,tarih=@tarih,saat=@saat,koltukno=@koltukno,turu=@turu where satis_kodu=@satis_kodu";
            //cmd.Parameters.AddWithValue("@salon_adi", tbsadi.Text);


            cmd.Parameters.AddWithValue("@film_kodu", filmadi.Text);
            cmd.Parameters.AddWithValue("@salon_kodu", tbsadi.Text);
            cmd.Parameters.AddWithValue("@satis_adi", ad.Text);
            cmd.Parameters.AddWithValue("@ücret", ucret.Text);
            cmd.Parameters.AddWithValue("@tarih", tarih.Text);
            cmd.Parameters.AddWithValue("@saat", saat.Text);
            cmd.Parameters.AddWithValue("@koltukno", koltukno.Text);
            cmd.Parameters.AddWithValue("@turu", radioButton1.Text);
            cmd.Parameters.AddWithValue("@turu", radioButton2.Text);
            //cmd.ExecuteNonQuery();
            MessageBox.Show("Düzeltme Yapıldı");

            cmd.ExecuteNonQuery();
            verileri_cek2();


        }

        private void cikis_Click(object sender, EventArgs e)
        {
            Form AnaMenü = new AnaMenü();
            AnaMenü.Show();
            this.Hide();
        }

        private void sil_Click(object sender, EventArgs e)
        {
            try
            {
                groupBox2.Visible = true;
                // kaydet.Visible = iptal.Visible = true;
                //ad.Focus();
                bs3.DataSource = ds.Tables["satis"];
                ad.DataBindings.Add("Text", bs3, "satis_adi");
                ucret.DataBindings.Add("Text", bs3, "ücret");
                satiskodu.DataBindings.Add("Text", bs3, "satis_kodu");
            }
            catch { }

            BasılanButon1 = (Button)sender;
            DialogResult cevap = MessageBox.Show("Silmek İstediğinize Eminmisiniz ?", "Uyarı", MessageBoxButtons.YesNo);
            if (cevap == DialogResult.Yes)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baglan;
                cmd.CommandText = "delete from satis where satis_kodu=@satis_kodu";
                cmd.Parameters.AddWithValue("@satis_kodu", satiskodu.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kayıt Silindi");

                verileri_cek2();
                groupBox2.Visible = false;





            }
        }

        private void cbsadi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string seckomutu = "select s.*,f.film_adi,f.film_kodu,st.salon_kodu,st.salon_adi from satis as s,film_kayit as f,salon_tanimlari as st where s.film_kodu=f.film_kodu and s.salon_kodu=st.salon_kodu and st.salon_kodu=" + cbsadi.SelectedValue;//as a anabilimdalı al as b bolumler al...
                OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
                if (ds.Tables["satis"] != null) ds.Tables["satis"].Clear();
                da.Fill(ds, "satis");

            }
            catch { }
        }

        private void btnraporsatis_Click(object sender, EventArgs e)
        {
            Form RaporSatıis = new RaporSatıis();
            RaporSatıis.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            ad.Text = "";
            ucret.Text = "";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            ad.Text = "";
            ucret.Text = "";
        }

        private void iptal_Click(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            kaydet.Visible = iptal.Visible = false;

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) verileri_cek2();
            else
            {
                if (cbsadi.Text != "") cbsadi_SelectedIndexChanged(sender, e);
                //else if (yadiara.Text != "") yadiara_TextChanged(sender, e);
            }




        }
    }
}

