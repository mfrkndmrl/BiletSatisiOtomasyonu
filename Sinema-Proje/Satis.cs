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
using System.Collections;

namespace Sinema_Proje
{
    public partial class Satis : Form
    {

        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + Application.StartupPath + "\\sinemailk.mdb");
        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();
        BindingSource bs1 = new BindingSource();
        string a;




        ArrayList koltuklar = new ArrayList();

        Button BasılanButon1;

        string[] yolcular = new string[100];

        string[] koltukcins = new string[100];
        int koltukSayisi = 0;
        public Satis()
        {
            InitializeComponent();
        }
        void verileri_cek()
        {
            string seckomutu = "select * from salon_tanimlari";//  "* tümünü al..."
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            ds.Clear();
            da.Fill(ds, "salon_tanimlari");
          

        }

        void otobusCiz(int koltukSayisi)
        {
            koltukSayisi = Convert.ToInt32(koltuk.Text);
            int sutun = 0, b = 0, satir = 0; ;
            int i;
            for (i = 0; i < koltukSayisi; i++)
            {
                if (i % 8 == 0 && i != 0)
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
                grpbkoltuklar.Controls.Add(koltuk1);
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
                    if (i + 1 == int.Parse(ds.Tables["satis"].Rows[a]["koltukno"].ToString()) && salonkodu.Text == ds.Tables["satis"].Rows[a]["salon_kodu"].ToString())
                    {
                        if (ds.Tables["satis"].Rows[a]["turu"].ToString() == "Satış")
                        {
                            koltuk1.Text = "S";
                            koltuk1.Enabled = false;
                            koltuk1.BackColor = Color.Red;
                        }
                        else
                        {
                            koltuk1.Text = "R";
                            koltuk1.Enabled = false;
                            koltuk1.BackColor = Color.Blue;
                        }



                    }
                   
                }
            }
            satir += koltukSayisi / 8;
            grpbkoltuklar.Size = new Size(400, (int)satir * 30 + 300);
        }

        private void koltuklarClick(object sender, MouseEventArgs e)
        {
            BasılanButon1 = (Button)sender;
            groupBox2.Visible = true;
            koltukno.Text = BasılanButon1.Text;
            
            
        }



        private void Satis_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            radioButton1.Checked = true;
            grpbkoltuklar.Visible = false;
            if (baglan.State == ConnectionState.Closed) baglan.Open();

            verileri_cek();

            bs.DataSource = ds.Tables["salon_tanimlari"];
            dataGridView1.DataSource = bs;
            salon.DataBindings.Add("Text", bs, "salon_adi");
            salonkodu.DataBindings.Add("Text", bs, "salon_kodu");
            koltuk.DataBindings.Add("Text", bs, "koltuk");

            

            string seckomutu2 = "select * from seans";
            OleDbDataAdapter da2 = new OleDbDataAdapter(seckomutu2, baglan);
            da2.Fill(ds, "seans"); da2.Fill(ds, "seans1");
            comboBox1.DataSource = ds.Tables["seans"];
            comboBox1.DisplayMember = "saat";
            comboBox1.ValueMember = "seans";

            comboBox2.DataSource = ds.Tables["seans1"];
            comboBox2.DisplayMember = "tarih";
            comboBox2.ValueMember = "seans";

            string seckomutu11 = "select * from film_kayit";
            OleDbDataAdapter da11 = new OleDbDataAdapter(seckomutu11, baglan);
            da11.Fill(ds, "film_kayit"); da2.Fill(ds, "film_kayit");
            film.DataSource = ds.Tables["film_kayit"];
            film.DisplayMember = "film_adi";
            film.ValueMember = "film_kodu";

           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
             

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
          
        }
       
           
        

        

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {


            grpbkoltuklar.Controls.Clear();
            grpbkoltuklar.Visible = true;
            string sayi = koltuk.Text;
            bool devam = false;

            for (int i = 0; i < sayi.Length; i++)
            {
                if (!char.IsDigit(sayi[i]))
                    devam = true;
            }

            if (!devam && sayi.Length != 0)
            {
                if (int.Parse(koltuk.Text) <= Convert.ToInt32(koltuk.Text) && int.Parse(koltuk.Text) > 0)
                {
                    koltukSayisi = int.Parse(koltuk.Text);
                    otobusCiz(koltukSayisi);

                    for (int i = 0; i <= koltukSayisi; i++)
                    {
                        koltukcins[i] = " ";
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = baglan;
           if(radioButton1.Checked==true)
            {
                cmd.CommandText = "insert into satis (film_kodu,salon_kodu,satis_adi,ücret,seans_tarih,seans_saat,koltukno,turu) Values (@film_kodu,@salon_kodu,@satis_adi,@ücret,@seans_tarih,@seans_saat,@koltukno,@turu)";
                cmd.Parameters.AddWithValue("@film_kodu", film.SelectedValue);
                cmd.Parameters.AddWithValue("@salon_kodu", salonkodu.Text);
                cmd.Parameters.AddWithValue("@satis_adi", ad.Text + " " + soyad.Text);
                cmd.Parameters.AddWithValue("@ücret", ucret.Text);
                cmd.Parameters.AddWithValue("@seans_tarih", comboBox2.SelectedValue);
                cmd.Parameters.AddWithValue("@seans_saat", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@koltukno", koltukno.Text);
                cmd.Parameters.AddWithValue("@turu", radioButton1.Text);

            }
            else
            {
                cmd.CommandText = "insert into satis (film_kodu,salon_kodu,satis_adi,ücret,seans_tarih,seans_saat,koltukno,turu) Values (@film_kodu,@salon_kodu,@satis_adi,@ücret,@seans_tarih,@seans_saat,@koltukno,@turu)";
                cmd.Parameters.AddWithValue("@film_kodu", film.SelectedValue);
                cmd.Parameters.AddWithValue("@salon_kodu", salonkodu.Text);
                cmd.Parameters.AddWithValue("@satis_adi", ad.Text + " " + soyad.Text);
                cmd.Parameters.AddWithValue("@ücret", ucret.Text);
                cmd.Parameters.AddWithValue("@seans_tarih", comboBox2.SelectedValue);
                cmd.Parameters.AddWithValue("@seans_saat", comboBox1.SelectedValue);
                cmd.Parameters.AddWithValue("@koltukno", koltukno.Text);
                cmd.Parameters.AddWithValue("@turu", radioButton2.Text);

            }
            cmd.ExecuteNonQuery();
            MessageBox.Show("Kaydınız Yapıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            verileri_cek();
            if (radioButton1.Checked==true)
            {
                BasılanButon1.BackColor = Color.Red;
                BasılanButon1.Enabled = false;
                BasılanButon1.Text = "S";
            }
            else if (radioButton2.Checked==true)
            {
                BasılanButon1.BackColor = Color.Blue;
                BasılanButon1.Enabled = false;
                BasılanButon1.Text = "R";

            }
            ad.Text = "";
            soyad.Text = "";
            ucret.Text="";



            {
                groupBox2.Visible = false;
               ad.Text = "";
                soyad.Text = "";


            }

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            grpbkoltuklar.Visible = false;
            dataGridView1.Enabled = true;
            groupBox2.Visible = false;
            ad.Text = "";
            soyad.Text = "";
            BasılanButon1.BackColor = Color.Gray;
            BasılanButon1.Enabled = true;
        }
    }
        }

       


