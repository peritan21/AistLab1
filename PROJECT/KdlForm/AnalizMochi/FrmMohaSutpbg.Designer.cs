using CustomControlLib;

namespace KdlForm.AnalizMochi
{
    partial class FrmMohaSutpbg
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
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label dataLabel;
            System.Windows.Forms.Label diurezLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMohaSutpbg));
            this.timeEdit1 = new DevExpress.XtraEditors.TimeEdit();
            this.dataDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.tabSpinEdit2 = new CustomControlLib.TabSpinEdit();
            this.tabSpinEdit1 = new CustomControlLib.TabSpinEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            label1 = new System.Windows.Forms.Label();
            dataLabel = new System.Windows.Forms.Label();
            diurezLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSpinEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSpinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label1.Location = new System.Drawing.Point(189, 7);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(49, 16);
            label1.TabIndex = 8;
            label1.Text = "Время:";
            // 
            // dataLabel
            // 
            dataLabel.AutoSize = true;
            dataLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataLabel.Location = new System.Drawing.Point(5, 7);
            dataLabel.Name = "dataLabel";
            dataLabel.Size = new System.Drawing.Size(42, 16);
            dataLabel.TabIndex = 6;
            dataLabel.Text = "Дата:";
            // 
            // diurezLabel
            // 
            diurezLabel.AutoSize = true;
            diurezLabel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            diurezLabel.Location = new System.Drawing.Point(5, 34);
            diurezLabel.Name = "diurezLabel";
            diurezLabel.Size = new System.Drawing.Size(112, 16);
            diurezLabel.TabIndex = 9;
            diurezLabel.Text = "Коичество белка:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label2.Location = new System.Drawing.Point(6, 58);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(128, 16);
            label2.TabIndex = 11;
            label2.Text = "Коичество глюкозы:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label3.Location = new System.Drawing.Point(304, 6);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(87, 16);
            label3.TabIndex = 184;
            label3.Text = "(взятия мат.)";
            // 
            // timeEdit1
            // 
            this.timeEdit1.EditValue = new System.DateTime(2010, 2, 18, 0, 0, 0, 0);
            this.timeEdit1.EnterMoveNextControl = true;
            this.timeEdit1.Location = new System.Drawing.Point(235, 3);
            this.timeEdit1.Name = "timeEdit1";
            this.timeEdit1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeEdit1.Properties.Appearance.Options.UseFont = true;
            this.timeEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEdit1.Properties.Mask.EditMask = "t";
            this.timeEdit1.Size = new System.Drawing.Size(63, 22);
            this.timeEdit1.TabIndex = 1;
            // 
            // dataDateEdit
            // 
            this.dataDateEdit.EditValue = null;
            this.dataDateEdit.EnterMoveNextControl = true;
            this.dataDateEdit.Location = new System.Drawing.Point(80, 3);
            this.dataDateEdit.Name = "dataDateEdit";
            this.dataDateEdit.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataDateEdit.Properties.Appearance.Options.UseFont = true;
            this.dataDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dataDateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dataDateEdit.Size = new System.Drawing.Size(100, 22);
            this.dataDateEdit.TabIndex = 0;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton2.Location = new System.Drawing.Point(320, 123);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(70, 20);
            this.simpleButton2.TabIndex = 5;
            this.simpleButton2.Text = "Отмена";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButton1.Location = new System.Drawing.Point(245, 123);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(70, 20);
            this.simpleButton1.TabIndex = 4;
            this.simpleButton1.Text = "Ок";
            // 
            // tabSpinEdit2
            // 
            this.tabSpinEdit2.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tabSpinEdit2.EnterMoveNextControl = true;
            this.tabSpinEdit2.Location = new System.Drawing.Point(140, 57);
            this.tabSpinEdit2.Name = "tabSpinEdit2";
            this.tabSpinEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tabSpinEdit2.Properties.Mask.EditMask = "f1";
            this.tabSpinEdit2.Size = new System.Drawing.Size(100, 20);
            this.tabSpinEdit2.TabIndex = 3;
            // 
            // tabSpinEdit1
            // 
            this.tabSpinEdit1.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tabSpinEdit1.EnterMoveNextControl = true;
            this.tabSpinEdit1.Location = new System.Drawing.Point(139, 33);
            this.tabSpinEdit1.Name = "tabSpinEdit1";
            this.tabSpinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tabSpinEdit1.Properties.Mask.EditMask = "f1";
            this.tabSpinEdit1.Size = new System.Drawing.Size(100, 20);
            this.tabSpinEdit1.TabIndex = 2;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl3.Location = new System.Drawing.Point(7, 84);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(62, 16);
            this.labelControl3.TabIndex = 183;
            this.labelControl3.Text = "Лаборант:";
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(80, 83);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("fio", "Лаборант")});
            this.lookUpEdit1.Properties.DisplayMember = "fio";
            this.lookUpEdit1.Properties.ValueMember = "laborant_id";
            this.lookUpEdit1.Size = new System.Drawing.Size(234, 20);
            this.lookUpEdit1.TabIndex = 182;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // FrmMohaSutpbg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 155);
            this.Controls.Add(label3);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lookUpEdit1);
            this.Controls.Add(this.tabSpinEdit2);
            this.Controls.Add(label2);
            this.Controls.Add(this.tabSpinEdit1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(diurezLabel);
            this.Controls.Add(this.timeEdit1);
            this.Controls.Add(label1);
            this.Controls.Add(dataLabel);
            this.Controls.Add(this.dataDateEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmMohaSutpbg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Суточная потеря белка";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmMohaSutpbg_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSpinEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSpinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TimeEdit timeEdit1;
        private DevExpress.XtraEditors.DateEdit dataDateEdit;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private TabSpinEdit tabSpinEdit1;
        private TabSpinEdit tabSpinEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}