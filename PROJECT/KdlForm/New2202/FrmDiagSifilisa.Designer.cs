namespace KdlForm.New2202
{
    partial class FrmDiagSifilisa
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
            System.Windows.Forms.Label rprLabel;
            System.Windows.Forms.Label rpgaLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label dataLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDiagSifilisa));
            this.rprImageComboBoxEdit = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.rpgaImageComboBoxEdit = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.timeEdit1 = new DevExpress.XtraEditors.TimeEdit();
            this.dataDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.imageComboBoxEdit1 = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.imageComboBoxEdit2 = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            rprLabel = new System.Windows.Forms.Label();
            rpgaLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            dataLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.rprImageComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpgaImageComboBoxEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDateEdit.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // rprLabel
            // 
            rprLabel.AutoSize = true;
            rprLabel.Location = new System.Drawing.Point(8, 41);
            rprLabel.Name = "rprLabel";
            rprLabel.Size = new System.Drawing.Size(27, 13);
            rprLabel.TabIndex = 1;
            rprLabel.Text = "RPR";
            // 
            // rpgaLabel
            // 
            rpgaLabel.AutoSize = true;
            rpgaLabel.Location = new System.Drawing.Point(8, 70);
            rpgaLabel.Name = "rpgaLabel";
            rpgaLabel.Size = new System.Drawing.Size(37, 13);
            rpgaLabel.TabIndex = 3;
            rpgaLabel.Text = "РПГА:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(177, 16);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(41, 13);
            label1.TabIndex = 26;
            label1.Text = "Время:";
            // 
            // dataLabel
            // 
            dataLabel.AutoSize = true;
            dataLabel.Location = new System.Drawing.Point(7, 15);
            dataLabel.Name = "dataLabel";
            dataLabel.Size = new System.Drawing.Size(37, 13);
            dataLabel.TabIndex = 25;
            dataLabel.Text = "Дата:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label2.Location = new System.Drawing.Point(294, 14);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(87, 16);
            label2.TabIndex = 182;
            label2.Text = "(взятия мат.)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(8, 99);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(64, 13);
            label3.TabIndex = 184;
            label3.Text = "Результат:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(8, 130);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(125, 13);
            label4.TabIndex = 186;
            label4.Text = "ИХА-анти -ТП-ФАКТОР:";
            // 
            // rprImageComboBoxEdit
            // 
            this.rprImageComboBoxEdit.Location = new System.Drawing.Point(70, 37);
            this.rprImageComboBoxEdit.Name = "rprImageComboBoxEdit";
            this.rprImageComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rprImageComboBoxEdit.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("нет значения", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("слабо положительно", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("положительно", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("отрицательно", 3, -1)});
            this.rprImageComboBoxEdit.Size = new System.Drawing.Size(311, 20);
            this.rprImageComboBoxEdit.TabIndex = 2;
            // 
            // rpgaImageComboBoxEdit
            // 
            this.rpgaImageComboBoxEdit.Location = new System.Drawing.Point(70, 66);
            this.rpgaImageComboBoxEdit.Name = "rpgaImageComboBoxEdit";
            this.rpgaImageComboBoxEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.rpgaImageComboBoxEdit.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("нет значения", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("слабо положительно", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("положительно", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("отрицательно", 3, -1)});
            this.rpgaImageComboBoxEdit.Size = new System.Drawing.Size(311, 20);
            this.rpgaImageComboBoxEdit.TabIndex = 3;
            // 
            // timeEdit1
            // 
            this.timeEdit1.EditValue = new System.DateTime(2010, 2, 18, 0, 0, 0, 0);
            this.timeEdit1.EnterMoveNextControl = true;
            this.timeEdit1.Location = new System.Drawing.Point(220, 12);
            this.timeEdit1.Name = "timeEdit1";
            this.timeEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.timeEdit1.Properties.Mask.EditMask = "t";
            this.timeEdit1.Size = new System.Drawing.Size(62, 20);
            this.timeEdit1.TabIndex = 1;
            // 
            // dataDateEdit
            // 
            this.dataDateEdit.EditValue = null;
            this.dataDateEdit.EnterMoveNextControl = true;
            this.dataDateEdit.Location = new System.Drawing.Point(51, 12);
            this.dataDateEdit.Name = "dataDateEdit";
            this.dataDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dataDateEdit.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dataDateEdit.Size = new System.Drawing.Size(118, 20);
            this.dataDateEdit.TabIndex = 0;
            // 
            // simpleButton2
            // 
            this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton2.Location = new System.Drawing.Point(319, 207);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(70, 20);
            this.simpleButton2.TabIndex = 8;
            this.simpleButton2.Text = "Отмена";
            // 
            // simpleButton1
            // 
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButton1.Location = new System.Drawing.Point(244, 207);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(70, 20);
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Text = "Ок";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl3.Location = new System.Drawing.Point(10, 161);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(62, 16);
            this.labelControl3.TabIndex = 181;
            this.labelControl3.Text = "Лаборант:";
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(73, 160);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("fio", "Лаборант")});
            this.lookUpEdit1.Properties.DisplayMember = "fio";
            this.lookUpEdit1.Properties.ValueMember = "laborant_id";
            this.lookUpEdit1.Size = new System.Drawing.Size(308, 20);
            this.lookUpEdit1.TabIndex = 6;
            // 
            // imageComboBoxEdit1
            // 
            this.imageComboBoxEdit1.Location = new System.Drawing.Point(70, 95);
            this.imageComboBoxEdit1.Name = "imageComboBoxEdit1";
            this.imageComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.imageComboBoxEdit1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("нет значения", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("слабо положительно", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("положительно", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("отрицательно", 3, -1)});
            this.imageComboBoxEdit1.Size = new System.Drawing.Size(311, 20);
            this.imageComboBoxEdit1.TabIndex = 4;
            // 
            // imageComboBoxEdit2
            // 
            this.imageComboBoxEdit2.Location = new System.Drawing.Point(141, 126);
            this.imageComboBoxEdit2.Name = "imageComboBoxEdit2";
            this.imageComboBoxEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.imageComboBoxEdit2.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("нет значения", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("положительно", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("отрицательно", 2, -1)});
            this.imageComboBoxEdit2.Size = new System.Drawing.Size(240, 20);
            this.imageComboBoxEdit2.TabIndex = 5;
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
            // FrmDiagSifilisa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 233);
            this.Controls.Add(label4);
            this.Controls.Add(this.imageComboBoxEdit2);
            this.Controls.Add(label3);
            this.Controls.Add(this.imageComboBoxEdit1);
            this.Controls.Add(label2);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lookUpEdit1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.timeEdit1);
            this.Controls.Add(label1);
            this.Controls.Add(dataLabel);
            this.Controls.Add(this.dataDateEdit);
            this.Controls.Add(rpgaLabel);
            this.Controls.Add(this.rpgaImageComboBoxEdit);
            this.Controls.Add(rprLabel);
            this.Controls.Add(this.rprImageComboBoxEdit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmDiagSifilisa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Диагноз на сифилис";
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmDiagSifilisa_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.rprImageComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rpgaImageComboBoxEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDateEdit.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageComboBoxEdit2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ImageComboBoxEdit rprImageComboBoxEdit;
        private DevExpress.XtraEditors.ImageComboBoxEdit rpgaImageComboBoxEdit;
        private DevExpress.XtraEditors.TimeEdit timeEdit1;
        private DevExpress.XtraEditors.DateEdit dataDateEdit;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.ImageComboBoxEdit imageComboBoxEdit1;
        private DevExpress.XtraEditors.ImageComboBoxEdit imageComboBoxEdit2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}