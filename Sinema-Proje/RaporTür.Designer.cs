﻿namespace Sinema_Proje
{
    partial class RaporTür
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.tur_tanimlariBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sinemailkDataSet = new Sinema_Proje.sinemailkDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tur_tanimlariTableAdapter = new Sinema_Proje.sinemailkDataSetTableAdapters.tur_tanimlariTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tur_tanimlariBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sinemailkDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tur_tanimlariBindingSource
            // 
            this.tur_tanimlariBindingSource.DataMember = "tur_tanimlari";
            this.tur_tanimlariBindingSource.DataSource = this.sinemailkDataSet;
            // 
            // sinemailkDataSet
            // 
            this.sinemailkDataSet.DataSetName = "sinemailkDataSet";
            this.sinemailkDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            reportDataSource2.Name = "DataSet1";
            reportDataSource2.Value = this.tur_tanimlariBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Sinema_Proje.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 12);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(561, 303);
            this.reportViewer1.TabIndex = 0;
            // 
            // tur_tanimlariTableAdapter
            // 
            this.tur_tanimlariTableAdapter.ClearBeforeFill = true;
            // 
            // RaporTür
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 327);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RaporTür";
            this.Text = "RaporTür";
            this.Load += new System.EventHandler(this.RaporTür_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tur_tanimlariBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sinemailkDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource tur_tanimlariBindingSource;
        private sinemailkDataSet sinemailkDataSet;
        private sinemailkDataSetTableAdapters.tur_tanimlariTableAdapter tur_tanimlariTableAdapter;
    }
}