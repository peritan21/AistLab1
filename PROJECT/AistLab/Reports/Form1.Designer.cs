namespace ReportsKDL
{
    partial class Form1
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.LABARATORIJDataSet = new ReportsKDL.LABARATORIJDataSet();
            this.VBAKTERIOSBIOMAT_RUBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.VBAKTERIOSBIOMAT_RUTableAdapter = new ReportsKDL.LABARATORIJDataSetTableAdapters.VBAKTERIOSBIOMAT_RUTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.LABARATORIJDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VBAKTERIOSBIOMAT_RUBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "LABARATORIJDataSet_VBAKTERIOSBIOMAT_RU";
            reportDataSource1.Value = this.VBAKTERIOSBIOMAT_RUBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ReportsKDL.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(682, 386);
            this.reportViewer1.TabIndex = 0;
            // 
            // LABARATORIJDataSet
            // 
            this.LABARATORIJDataSet.DataSetName = "LABARATORIJDataSet";
            this.LABARATORIJDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // VBAKTERIOSBIOMAT_RUBindingSource
            // 
            this.VBAKTERIOSBIOMAT_RUBindingSource.DataMember = "VBAKTERIOSBIOMAT_RU";
            this.VBAKTERIOSBIOMAT_RUBindingSource.DataSource = this.LABARATORIJDataSet;
            // 
            // VBAKTERIOSBIOMAT_RUTableAdapter
            // 
            this.VBAKTERIOSBIOMAT_RUTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 386);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LABARATORIJDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VBAKTERIOSBIOMAT_RUBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource VBAKTERIOSBIOMAT_RUBindingSource;
        private LABARATORIJDataSet LABARATORIJDataSet;
        private ReportsKDL.LABARATORIJDataSetTableAdapters.VBAKTERIOSBIOMAT_RUTableAdapter VBAKTERIOSBIOMAT_RUTableAdapter;
    }
}

