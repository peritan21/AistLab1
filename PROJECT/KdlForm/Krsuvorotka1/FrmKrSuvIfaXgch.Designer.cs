using CustomControlLib;

namespace KdlForm.Krsuvorotka1
{
    partial class FrmKrSuvIfaXgch
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
            System.Windows.Forms.Label dataLabel;
            System.Windows.Forms.Label igmLabel;
            System.Windows.Forms.Label iggLabel;
            System.Windows.Forms.Label dataLabel1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKrSuvIfaXgch));
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.dataTimeEdit = new DevExpress.XtraEditors.TimeEdit();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.tabImageComboBoxEdit2 = new CustomControlLib.TabImageComboBoxEdit();
            this.tabSpinEdit4 = new CustomControlLib.TabSpinEdit();
            this.tabImageComboBoxEdit1 = new CustomControlLib.TabImageComboBoxEdit();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            dataLabel = new System.Windows.Forms.Label();
            igmLabel = new System.Windows.Forms.Label();
            iggLabel = new System.Windows.Forms.Label();
            dataLabel1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTimeEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabImageComboBoxEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSpinEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabImageComboBoxEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dataLabel
            // 
            dataLabel.AutoSize = true;
            dataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataLabel.Location = new System.Drawing.Point(23, 12);
            dataLabel.Name = "dataLabel";
            dataLabel.Size = new System.Drawing.Size(43, 16);
            dataLabel.TabIndex = 2;
            dataLabel.Text = "Дата:";
            // 
            // igmLabel
            // 
            igmLabel.AutoSize = true;
            igmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            igmLabel.Location = new System.Drawing.Point(23, 42);
            igmLabel.Name = "igmLabel";
            igmLabel.Size = new System.Drawing.Size(139, 16);
            igmLabel.TabIndex = 11;
            igmLabel.Text = "Антитела к ХГЧ Ig M:";
            // 
            // iggLabel
            // 
            iggLabel.AutoSize = true;
            iggLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            iggLabel.Location = new System.Drawing.Point(23, 67);
            iggLabel.Name = "iggLabel";
            iggLabel.Size = new System.Drawing.Size(138, 16);
            iggLabel.TabIndex = 12;
            iggLabel.Text = "Антитела к ХГЧ ig G:";
            // 
            // dataLabel1
            // 
            dataLabel1.AutoSize = true;
            dataLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataLabel1.Location = new System.Drawing.Point(179, 12);
            dataLabel1.Name = "dataLabel1";
            dataLabel1.Size = new System.Drawing.Size(52, 16);
            dataLabel1.TabIndex = 14;
            dataLabel1.Text = "Время:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label2.Location = new System.Drawing.Point(291, 11);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(87, 16);
            label2.TabIndex = 185;
            label2.Text = "(взятия мат.)";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            label3.Location = new System.Drawing.Point(23, 96);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(275, 16);
            label3.TabIndex = 186;
            label3.Text = "Суммарные антитела к IgM+IgA+IgG:";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.EnterMoveNextControl = true;
            this.dateEdit1.Location = new System.Drawing.Point(67, 8);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dateEdit1.Properties.Appearance.Options.UseFont = true;
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dateEdit1.Size = new System.Drawing.Size(100, 22);
            this.dateEdit1.TabIndex = 0;
            // 
            // dataTimeEdit
            // 
            this.dataTimeEdit.EditValue = new System.DateTime(2010, 2, 17, 0, 0, 0, 0);
            this.dataTimeEdit.EnterMoveNextControl = true;
            this.dataTimeEdit.Location = new System.Drawing.Point(236, 8);
            this.dataTimeEdit.Name = "dataTimeEdit";
            this.dataTimeEdit.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataTimeEdit.Properties.Appearance.Options.UseFont = true;
            this.dataTimeEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.dataTimeEdit.Properties.Mask.EditMask = "t";
            this.dataTimeEdit.Size = new System.Drawing.Size(52, 22);
            this.dataTimeEdit.TabIndex = 1;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton2.Location = new System.Drawing.Point(292, 183);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(70, 20);
            this.simpleButton2.TabIndex = 7;
            this.simpleButton2.Text = "Отмена";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.simpleButton1.Location = new System.Drawing.Point(217, 183);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(70, 20);
            this.simpleButton1.TabIndex = 6;
            this.simpleButton1.Text = "Ок";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl3.Location = new System.Drawing.Point(38, 156);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(62, 16);
            this.labelControl3.TabIndex = 181;
            this.labelControl3.Text = "Лаборант:";
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(106, 155);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("fio", "Лаборант")});
            this.lookUpEdit1.Properties.DisplayMember = "fio";
            this.lookUpEdit1.Properties.ValueMember = "laborant_id";
            this.lookUpEdit1.Size = new System.Drawing.Size(215, 20);
            this.lookUpEdit1.TabIndex = 5;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl5.Location = new System.Drawing.Point(294, 116);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(27, 16);
            this.labelControl5.TabIndex = 188;
            this.labelControl5.Text = "Е/мл";
            // 
            // tabImageComboBoxEdit2
            // 
            this.tabImageComboBoxEdit2.EnterMoveNextControl = true;
            this.tabImageComboBoxEdit2.Location = new System.Drawing.Point(167, 64);
            this.tabImageComboBoxEdit2.Name = "tabImageComboBoxEdit2";
            this.tabImageComboBoxEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tabImageComboBoxEdit2.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("нет значения", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Отрицательно", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Положительно", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Слабо положит.", 3, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Резко положит.", 4, -1)});
            this.tabImageComboBoxEdit2.Size = new System.Drawing.Size(121, 20);
            this.tabImageComboBoxEdit2.TabIndex = 3;
            // 
            // tabSpinEdit4
            // 
            this.tabSpinEdit4.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tabSpinEdit4.EnterMoveNextControl = true;
            this.tabSpinEdit4.Location = new System.Drawing.Point(167, 115);
            this.tabSpinEdit4.Name = "tabSpinEdit4";
            this.tabSpinEdit4.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.tabSpinEdit4.Properties.Mask.EditMask = "f1";
            this.tabSpinEdit4.Size = new System.Drawing.Size(121, 20);
            this.tabSpinEdit4.TabIndex = 4;
            // 
            // tabImageComboBoxEdit1
            // 
            this.tabImageComboBoxEdit1.EnterMoveNextControl = true;
            this.tabImageComboBoxEdit1.Location = new System.Drawing.Point(167, 40);
            this.tabImageComboBoxEdit1.Name = "tabImageComboBoxEdit1";
            this.tabImageComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.tabImageComboBoxEdit1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("нет значения", 0, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Отрицательно", 1, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Положительно", 2, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Слабо положит.", 3, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Резко положит.", 4, -1)});
            this.tabImageComboBoxEdit1.Size = new System.Drawing.Size(121, 20);
            this.tabImageComboBoxEdit1.TabIndex = 2;
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
            // FrmKrSuvIfaXgch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 215);
            this.Controls.Add(this.tabImageComboBoxEdit2);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.tabSpinEdit4);
            this.Controls.Add(label3);
            this.Controls.Add(label2);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.lookUpEdit1);
            this.Controls.Add(this.tabImageComboBoxEdit1);
            this.Controls.Add(this.simpleButton2);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(dataLabel1);
            this.Controls.Add(this.dataTimeEdit);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(iggLabel);
            this.Controls.Add(igmLabel);
            this.Controls.Add(dataLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Name = "FrmKrSuvIfaXgch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmKrSuvIfaXgch_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTimeEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabImageComboBoxEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabSpinEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabImageComboBoxEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.TimeEdit dataTimeEdit;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private TabImageComboBoxEdit tabImageComboBoxEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private TabSpinEdit tabSpinEdit4;
        private TabImageComboBoxEdit tabImageComboBoxEdit2;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}