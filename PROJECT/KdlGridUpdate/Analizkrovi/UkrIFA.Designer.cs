namespace KdlGridUpdate.Analizkrovi
{
    partial class UkrIFA
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UkrIFA));
            this.kRIFABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BnKRIFA = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.kRIFABindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.kRIFAGridControl = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.coldata = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTimeEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colb2glikoigm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colb2glikoigg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprotrigm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colprotrigg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colkardioigm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colkardioigg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colanneksigm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colanneksigg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colgemocestian = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.kRIFABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BnKRIFA)).BeginInit();
            this.BnKRIFA.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kRIFAGridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // kRIFABindingNavigator
            // 
            this.BnKRIFA.AddNewItem = this.bindingNavigatorAddNewItem;
            this.BnKRIFA.BindingSource = this.kRIFABindingSource;
            this.BnKRIFA.CountItem = this.bindingNavigatorCountItem;
            this.BnKRIFA.CountItemFormat = "по {0}";
            this.BnKRIFA.DeleteItem = this.bindingNavigatorDeleteItem;
            this.BnKRIFA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BnKRIFA.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.kRIFABindingNavigatorSaveItem,
            this.toolStripButton1,
            this.bindingNavigatorDeleteItem});
            this.BnKRIFA.Location = new System.Drawing.Point(0, 0);
            this.BnKRIFA.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.BnKRIFA.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.BnKRIFA.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.BnKRIFA.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.BnKRIFA.Name = "kRIFABindingNavigator";
            this.BnKRIFA.PositionItem = this.bindingNavigatorPositionItem;
            this.BnKRIFA.Size = new System.Drawing.Size(867, 25);
            this.BnKRIFA.TabIndex = 0;
            this.BnKRIFA.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Добавление";
            this.bindingNavigatorAddNewItem.Click += new System.EventHandler(this.BindingNavigatorAddNewItemClick);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(51, 22);
            this.bindingNavigatorCountItem.Text = "по {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Удаление";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 21);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // kRIFABindingNavigatorSaveItem
            // 
            this.kRIFABindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.kRIFABindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("kRIFABindingNavigatorSaveItem.Image")));
            this.kRIFABindingNavigatorSaveItem.Name = "kRIFABindingNavigatorSaveItem";
            this.kRIFABindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.kRIFABindingNavigatorSaveItem.Text = "Сохранить данные";
            this.kRIFABindingNavigatorSaveItem.Click += new System.EventHandler(this.KRifaBindingNavigatorSaveItemClick);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "Редактирование, просмотр";
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1Click);
            // 
            // kRIFAGridControl
            // 
            this.kRIFAGridControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.kRIFAGridControl.Location = new System.Drawing.Point(3, 27);
            this.kRIFAGridControl.MainView = this.gridView1;
            this.kRIFAGridControl.Name = "kRIFAGridControl";
            this.kRIFAGridControl.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemDateEdit1,
            this.repositoryItemTimeEdit1,
            this.repositoryItemLookUpEdit1});
            this.kRIFAGridControl.Size = new System.Drawing.Size(861, 350);
            this.kRIFAGridControl.TabIndex = 4;
            this.kRIFAGridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.coldata,
            this.gridColumn1,
            this.gridColumn2,
            this.colb2glikoigm,
            this.colb2glikoigg,
            this.colprotrigm,
            this.colprotrigg,
            this.colkardioigm,
            this.colkardioigg,
            this.colanneksigm,
            this.colanneksigg,
            this.colgemocestian});
            this.gridView1.GridControl = this.kRIFAGridControl;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // coldata
            // 
            this.coldata.Caption = "Дата";
            this.coldata.ColumnEdit = this.repositoryItemDateEdit1;
            this.coldata.FieldName = "data";
            this.coldata.Name = "coldata";
            this.coldata.Visible = true;
            this.coldata.VisibleIndex = 0;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Время";
            this.gridColumn1.ColumnEdit = this.repositoryItemTimeEdit1;
            this.gridColumn1.FieldName = "data";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // repositoryItemTimeEdit1
            // 
            this.repositoryItemTimeEdit1.AutoHeight = false;
            this.repositoryItemTimeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemTimeEdit1.Mask.EditMask = "t";
            this.repositoryItemTimeEdit1.Name = "repositoryItemTimeEdit1";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Регистратор";
            this.gridColumn2.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.gridColumn2.FieldName = "laborant_id";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 2;
            this.gridColumn2.Width = 130;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("fio", "Лаборант")});
            this.repositoryItemLookUpEdit1.DisplayMember = "fio";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.ValueMember = "laborant_id";
            // 
            // colb2glikoigm
            // 
            this.colb2glikoigm.Caption = "Опред. антител к анти-В2 гликлпротеину IgM";
            this.colb2glikoigm.FieldName = "b2glikoigm";
            this.colb2glikoigm.Name = "colb2glikoigm";
            this.colb2glikoigm.Visible = true;
            this.colb2glikoigm.VisibleIndex = 3;
            // 
            // colb2glikoigg
            // 
            this.colb2glikoigg.Caption = "Опред. антител к анти-В2 гликлпротеину IgG";
            this.colb2glikoigg.FieldName = "b2glikoigg";
            this.colb2glikoigg.Name = "colb2glikoigg";
            this.colb2glikoigg.Visible = true;
            this.colb2glikoigg.VisibleIndex = 4;
            // 
            // colprotrigm
            // 
            this.colprotrigm.Caption = "Опред. антител к протромбину IgM";
            this.colprotrigm.FieldName = "protrigm";
            this.colprotrigm.Name = "colprotrigm";
            this.colprotrigm.Visible = true;
            this.colprotrigm.VisibleIndex = 5;
            // 
            // colprotrigg
            // 
            this.colprotrigg.Caption = "Опред. антител к протромбину IgG";
            this.colprotrigg.FieldName = "protrigg";
            this.colprotrigg.Name = "colprotrigg";
            this.colprotrigg.Visible = true;
            this.colprotrigg.VisibleIndex = 6;
            // 
            // colkardioigm
            // 
            this.colkardioigm.Caption = "Опред. антител к кардиолипину IgM";
            this.colkardioigm.FieldName = "kardioigm";
            this.colkardioigm.Name = "colkardioigm";
            this.colkardioigm.Visible = true;
            this.colkardioigm.VisibleIndex = 7;
            // 
            // colkardioigg
            // 
            this.colkardioigg.Caption = "Опред. антител к кардиолипину IgG";
            this.colkardioigg.FieldName = "kardioigg";
            this.colkardioigg.Name = "colkardioigg";
            this.colkardioigg.Visible = true;
            this.colkardioigg.VisibleIndex = 8;
            // 
            // colanneksigm
            // 
            this.colanneksigm.Caption = "Опред. антител к аннексину IgM";
            this.colanneksigm.FieldName = "anneksigm";
            this.colanneksigm.Name = "colanneksigm";
            this.colanneksigm.Visible = true;
            this.colanneksigm.VisibleIndex = 9;
            // 
            // colanneksigg
            // 
            this.colanneksigg.Caption = "Опред. антител к аннексину IgG";
            this.colanneksigg.FieldName = "anneksigg";
            this.colanneksigg.Name = "colanneksigg";
            this.colanneksigg.Visible = true;
            this.colanneksigg.VisibleIndex = 10;
            // 
            // colgemocestian
            // 
            this.colgemocestian.Caption = "Гомоцестеин";
            this.colgemocestian.FieldName = "gemocestian";
            this.colgemocestian.Name = "colgemocestian";
            this.colgemocestian.Visible = true;
            this.colgemocestian.VisibleIndex = 11;
            // 
            // UkrIFA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.kRIFAGridControl);
            this.Controls.Add(this.BnKRIFA);
            this.Name = "UkrIFA";
            this.Size = new System.Drawing.Size(867, 379);
            ((System.ComponentModel.ISupportInitialize)(this.kRIFABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BnKRIFA)).EndInit();
            this.BnKRIFA.ResumeLayout(false);
            this.BnKRIFA.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.kRIFAGridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource kRIFABindingSource;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton kRIFABindingNavigatorSaveItem;
        private DevExpress.XtraGrid.GridControl kRIFAGridControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn coldata;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colb2glikoigm;
        private DevExpress.XtraGrid.Columns.GridColumn colb2glikoigg;
        private DevExpress.XtraGrid.Columns.GridColumn colprotrigm;
        private DevExpress.XtraGrid.Columns.GridColumn colprotrigg;
        private DevExpress.XtraGrid.Columns.GridColumn colkardioigm;
        private DevExpress.XtraGrid.Columns.GridColumn colkardioigg;
        private DevExpress.XtraGrid.Columns.GridColumn colanneksigm;
        private DevExpress.XtraGrid.Columns.GridColumn colanneksigg;
        private DevExpress.XtraGrid.Columns.GridColumn colgemocestian;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;


    }
}
