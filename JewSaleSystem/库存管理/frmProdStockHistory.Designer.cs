namespace JewSaleSystem
{
    partial class frmProdStockHistory
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReluStockId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReluProdNature = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReluProdStyle = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReluSuppName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReluState = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.label5 = new System.Windows.Forms.Label();
            this.txBarcode = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.luStockId = new DevExpress.XtraEditors.LookUpEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReluStockId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReluProdNature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReluProdStyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReluSuppName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReluState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luStockId.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 49);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ReluStockId,
            this.ReluProdNature,
            this.ReluProdStyle,
            this.ReluSuppName,
            this.ReluState});
            this.gridControl1.Size = new System.Drawing.Size(1043, 377);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "柜台";
            this.gridColumn1.ColumnEdit = this.ReluStockId;
            this.gridColumn1.FieldName = "StockId";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // ReluStockId
            // 
            this.ReluStockId.AutoHeight = false;
            this.ReluStockId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ReluStockId.Name = "ReluStockId";
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "条码";
            this.gridColumn2.FieldName = "Barcode";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "商品名称";
            this.gridColumn3.FieldName = "ProdName";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "商品性质";
            this.gridColumn4.ColumnEdit = this.ReluProdNature;
            this.gridColumn4.FieldName = "ProdNature";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // ReluProdNature
            // 
            this.ReluProdNature.AutoHeight = false;
            this.ReluProdNature.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ReluProdNature.Name = "ReluProdNature";
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "款式类型";
            this.gridColumn5.ColumnEdit = this.ReluProdStyle;
            this.gridColumn5.FieldName = "ProdStyle";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // ReluProdStyle
            // 
            this.ReluProdStyle.AutoHeight = false;
            this.ReluProdStyle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ReluProdStyle.Name = "ReluProdStyle";
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "标签价";
            this.gridColumn6.FieldName = "SalePrice";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 7;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "供应商";
            this.gridColumn7.ColumnEdit = this.ReluSuppName;
            this.gridColumn7.FieldName = "SuppName";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 8;
            // 
            // ReluSuppName
            // 
            this.ReluSuppName.AutoHeight = false;
            this.ReluSuppName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ReluSuppName.Name = "ReluSuppName";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "去向";
            this.gridColumn8.FieldName = "Direction";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 5;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "备注";
            this.gridColumn9.FieldName = "Remark";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 6;
            // 
            // ReluState
            // 
            this.ReluState.AutoHeight = false;
            this.ReluState.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ReluState.Name = "ReluState";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 14);
            this.label5.TabIndex = 17;
            this.label5.Text = "商品条码：";
            // 
            // txBarcode
            // 
            this.txBarcode.Location = new System.Drawing.Point(79, 17);
            this.txBarcode.Name = "txBarcode";
            this.txBarcode.Size = new System.Drawing.Size(100, 22);
            this.txBarcode.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(185, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 14);
            this.label10.TabIndex = 24;
            this.label10.Text = "柜台名称：";
            // 
            // luStockId
            // 
            this.luStockId.Location = new System.Drawing.Point(258, 16);
            this.luStockId.Name = "luStockId";
            this.luStockId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luStockId.Size = new System.Drawing.Size(100, 21);
            this.luStockId.TabIndex = 25;
            this.luStockId.Tag = "StockId";
            this.luStockId.EditValueChanged += new System.EventHandler(this.luStockId_EditValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.luStockId);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txBarcode);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1043, 49);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询条件";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(421, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "查看";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmProdStockHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1043, 426);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmProdStockHistory";
            this.Text = "frmProdStockHistory";
            this.Load += new System.EventHandler(this.frmProdStockHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReluStockId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReluProdNature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReluProdStyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReluSuppName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReluState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luStockId.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ReluStockId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ReluProdNature;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ReluProdStyle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ReluSuppName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ReluState;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txBarcode;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.LookUpEdit luStockId;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
    }
}