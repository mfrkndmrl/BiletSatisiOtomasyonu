namespace Sinema_Proje
{
    partial class TürEkle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.aranan = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cikis = new System.Windows.Forms.Button();
            this.raportur = new System.Windows.Forms.Button();
            this.sil = new System.Windows.Forms.Button();
            this.iptal = new System.Windows.Forms.Button();
            this.kaydet = new System.Windows.Forms.Button();
            this.duzelt = new System.Windows.Forms.Button();
            this.ileri = new System.Windows.Forms.Button();
            this.yenikayit = new System.Windows.Forms.Button();
            this.geri = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbtadi = new System.Windows.Forms.TextBox();
            this.tbtkodu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 427);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(471, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.aranan);
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Font = new System.Drawing.Font("Kalam", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox3.Location = new System.Drawing.Point(5, 105);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(225, 319);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kayıt Arama ve Listeleme";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Kalam", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.checkBox1.Location = new System.Drawing.Point(159, 37);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(45, 28);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "TK";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Kalam", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tür Adı:";
            // 
            // aranan
            // 
            this.aranan.Location = new System.Drawing.Point(6, 40);
            this.aranan.Name = "aranan";
            this.aranan.Size = new System.Drawing.Size(137, 19);
            this.aranan.TabIndex = 1;
            this.aranan.TextChanged += new System.EventHandler(this.aranan_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dataGridView1.Location = new System.Drawing.Point(28, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(171, 241);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "tur_adi";
            this.Column1.HeaderText = "Tür Adı";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "tur_kodu";
            this.Column2.HeaderText = "Tür Kodu";
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cikis);
            this.groupBox2.Controls.Add(this.raportur);
            this.groupBox2.Controls.Add(this.sil);
            this.groupBox2.Controls.Add(this.iptal);
            this.groupBox2.Controls.Add(this.kaydet);
            this.groupBox2.Controls.Add(this.duzelt);
            this.groupBox2.Controls.Add(this.ileri);
            this.groupBox2.Controls.Add(this.yenikayit);
            this.groupBox2.Controls.Add(this.geri);
            this.groupBox2.Font = new System.Drawing.Font("Kalam", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox2.Location = new System.Drawing.Point(260, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(203, 421);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "İşlemler";
            // 
            // cikis
            // 
            this.cikis.Font = new System.Drawing.Font("Kalam Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.cikis.Image = global::Sinema_Proje.Properties.Resources.home_icon;
            this.cikis.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.cikis.Location = new System.Drawing.Point(16, 368);
            this.cikis.Name = "cikis";
            this.cikis.Size = new System.Drawing.Size(116, 38);
            this.cikis.TabIndex = 8;
            this.cikis.Text = "      Ana Menü";
            this.cikis.UseVisualStyleBackColor = true;
            this.cikis.Click += new System.EventHandler(this.cikis_Click);
            // 
            // raportur
            // 
            this.raportur.Font = new System.Drawing.Font("Kalam Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.raportur.Image = global::Sinema_Proje.Properties.Resources.rapor;
            this.raportur.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.raportur.Location = new System.Drawing.Point(15, 324);
            this.raportur.Name = "raportur";
            this.raportur.Size = new System.Drawing.Size(116, 38);
            this.raportur.TabIndex = 7;
            this.raportur.Text = "    Raporla";
            this.raportur.UseVisualStyleBackColor = true;
            this.raportur.Click += new System.EventHandler(this.raportur_Click);
            // 
            // sil
            // 
            this.sil.Font = new System.Drawing.Font("Kalam Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sil.Image = global::Sinema_Proje.Properties.Resources.çöp;
            this.sil.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sil.Location = new System.Drawing.Point(15, 177);
            this.sil.Name = "sil";
            this.sil.Size = new System.Drawing.Size(88, 34);
            this.sil.TabIndex = 6;
            this.sil.Text = "  Sil";
            this.sil.UseVisualStyleBackColor = true;
            this.sil.Click += new System.EventHandler(this.sil_Click);
            // 
            // iptal
            // 
            this.iptal.Font = new System.Drawing.Font("Kalam Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.iptal.Image = global::Sinema_Proje.Properties.Resources.sil1;
            this.iptal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iptal.Location = new System.Drawing.Point(15, 261);
            this.iptal.Name = "iptal";
            this.iptal.Size = new System.Drawing.Size(88, 38);
            this.iptal.TabIndex = 5;
            this.iptal.Text = "    İptal";
            this.iptal.UseVisualStyleBackColor = true;
            this.iptal.Click += new System.EventHandler(this.iptal_Click);
            // 
            // kaydet
            // 
            this.kaydet.Font = new System.Drawing.Font("Kalam Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kaydet.Image = global::Sinema_Proje.Properties.Resources.kaydet;
            this.kaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.kaydet.Location = new System.Drawing.Point(15, 217);
            this.kaydet.Name = "kaydet";
            this.kaydet.Size = new System.Drawing.Size(100, 38);
            this.kaydet.TabIndex = 4;
            this.kaydet.Text = "       Kaydet";
            this.kaydet.UseVisualStyleBackColor = true;
            this.kaydet.Click += new System.EventHandler(this.kaydet_Click);
            // 
            // duzelt
            // 
            this.duzelt.Font = new System.Drawing.Font("Kalam Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.duzelt.Image = global::Sinema_Proje.Properties.Resources.düzenle;
            this.duzelt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.duzelt.Location = new System.Drawing.Point(15, 133);
            this.duzelt.Name = "duzelt";
            this.duzelt.Size = new System.Drawing.Size(101, 38);
            this.duzelt.TabIndex = 3;
            this.duzelt.Text = "   Düzelt";
            this.duzelt.UseVisualStyleBackColor = true;
            this.duzelt.Click += new System.EventHandler(this.duzelt_Click);
            // 
            // ileri
            // 
            this.ileri.Font = new System.Drawing.Font("Kalam Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ileri.Image = global::Sinema_Proje.Properties.Resources.ileri1;
            this.ileri.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ileri.Location = new System.Drawing.Point(109, 19);
            this.ileri.Name = "ileri";
            this.ileri.Size = new System.Drawing.Size(88, 37);
            this.ileri.TabIndex = 2;
            this.ileri.Text = "   İleri";
            this.ileri.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ileri.UseVisualStyleBackColor = true;
            this.ileri.Click += new System.EventHandler(this.ileri_Click);
            // 
            // yenikayit
            // 
            this.yenikayit.Font = new System.Drawing.Font("Kalam Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.yenikayit.Image = global::Sinema_Proje.Properties.Resources.ekle;
            this.yenikayit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.yenikayit.Location = new System.Drawing.Point(15, 87);
            this.yenikayit.Name = "yenikayit";
            this.yenikayit.Size = new System.Drawing.Size(116, 40);
            this.yenikayit.TabIndex = 1;
            this.yenikayit.Text = "      Yeni Kayıt";
            this.yenikayit.UseVisualStyleBackColor = true;
            this.yenikayit.Click += new System.EventHandler(this.yenikayit_Click);
            // 
            // geri
            // 
            this.geri.Font = new System.Drawing.Font("Kalam Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.geri.Image = global::Sinema_Proje.Properties.Resources.geri;
            this.geri.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.geri.Location = new System.Drawing.Point(16, 19);
            this.geri.Name = "geri";
            this.geri.Size = new System.Drawing.Size(88, 38);
            this.geri.TabIndex = 0;
            this.geri.Text = "    Geri";
            this.geri.UseVisualStyleBackColor = true;
            this.geri.Click += new System.EventHandler(this.geri_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbtadi);
            this.groupBox1.Controls.Add(this.tbtkodu);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Kalam", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.groupBox1.Location = new System.Drawing.Point(5, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 96);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tür Tanımları";
            // 
            // tbtadi
            // 
            this.tbtadi.Location = new System.Drawing.Point(99, 62);
            this.tbtadi.Name = "tbtadi";
            this.tbtadi.Size = new System.Drawing.Size(100, 19);
            this.tbtadi.TabIndex = 3;
            // 
            // tbtkodu
            // 
            this.tbtkodu.Location = new System.Drawing.Point(99, 29);
            this.tbtkodu.Name = "tbtkodu";
            this.tbtkodu.Size = new System.Drawing.Size(100, 19);
            this.tbtkodu.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Kalam", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(24, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tür Adı:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Kalam", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tür Kodu:";
            // 
            // TürEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 449);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TürEkle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TürEkle";
            this.Load += new System.EventHandler(this.TürEkle_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox aranan;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button sil;
        private System.Windows.Forms.Button iptal;
        private System.Windows.Forms.Button kaydet;
        private System.Windows.Forms.Button duzelt;
        private System.Windows.Forms.Button ileri;
        private System.Windows.Forms.Button yenikayit;
        private System.Windows.Forms.Button geri;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbtadi;
        private System.Windows.Forms.TextBox tbtkodu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button raportur;
        private System.Windows.Forms.Button cikis;

    }
}