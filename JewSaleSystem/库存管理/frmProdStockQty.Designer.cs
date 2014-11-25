namespace JewSaleSystem
{
    partial class frmProdStockQty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProdStockQty));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txCount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.luSuppName = new DevExpress.XtraEditors.LookUpEdit();
            this.luProdNature = new DevExpress.XtraEditors.LookUpEdit();
            this.txWgtMax = new System.Windows.Forms.TextBox();
            this.txWgtMin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txProdName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.luStockId = new DevExpress.XtraEditors.LookUpEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.luProdStyle = new DevExpress.XtraEditors.LookUpEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txPriceMax = new System.Windows.Forms.TextBox();
            this.txPriceMin = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txBarcode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReluStockId = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReluProdNature = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ReluProdStyle = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.ReluSuppName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ReluState = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luSuppName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProdNature.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luStockId.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProdStyle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReluStockId)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReluProdNature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReluProdStyle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReluSuppName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReluState)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txCount);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(934, 45);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作区域";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(399, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 14);
            this.label8.TabIndex = 9;
            this.label8.Text = "件";
            // 
            // txCount
            // 
            this.txCount.Enabled = false;
            this.txCount.Location = new System.Drawing.Point(293, 17);
            this.txCount.Name = "txCount";
            this.txCount.Size = new System.Drawing.Size(100, 22);
            this.txCount.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(226, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 14);
            this.label7.TabIndex = 7;
            this.label7.Text = "库存数量：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(79, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "查看";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // luSuppName
            // 
            this.luSuppName.Location = new System.Drawing.Point(472, 46);
            this.luSuppName.Name = "luSuppName";
            this.luSuppName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luSuppName.Size = new System.Drawing.Size(100, 21);
            this.luSuppName.TabIndex = 16;
            this.luSuppName.Tag = "SuppName";
            this.luSuppName.EditValueChanged += new System.EventHandler(this.luSuppName_EditValueChanged);
            // 
            // luProdNature
            // 
            this.luProdNature.Location = new System.Drawing.Point(471, 14);
            this.luProdNature.Name = "luProdNature";
            this.luProdNature.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luProdNature.Size = new System.Drawing.Size(100, 21);
            this.luProdNature.TabIndex = 15;
            this.luProdNature.Tag = "ProdNature";
            this.luProdNature.EditValueChanged += new System.EventHandler(this.luProdNature_EditValueChanged);
            // 
            // txWgtMax
            // 
            this.txWgtMax.Location = new System.Drawing.Point(730, 13);
            this.txWgtMax.Name = "txWgtMax";
            this.txWgtMax.Size = new System.Drawing.Size(57, 22);
            this.txWgtMax.TabIndex = 11;
            // 
            // txWgtMin
            // 
            this.txWgtMin.Location = new System.Drawing.Point(664, 13);
            this.txWgtMin.Name = "txWgtMin";
            this.txWgtMin.Size = new System.Drawing.Size(60, 22);
            this.txWgtMin.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(602, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 14);
            this.label6.TabIndex = 9;
            this.label6.Text = "重量范围：";
            // 
            // txProdName
            // 
            this.txProdName.Location = new System.Drawing.Point(79, 47);
            this.txProdName.Name = "txProdName";
            this.txProdName.Size = new System.Drawing.Size(100, 22);
            this.txProdName.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(387, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 14);
            this.label4.TabIndex = 3;
            this.label4.Text = "供应商名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(384, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "商品性质：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "商品名称：";
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
            this.gridColumn9,
            this.gridColumn10});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.RowAutoHeight = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 18);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ReluStockId,
            this.ReluProdNature,
            this.ReluProdStyle,
            this.ReluSuppName,
            this.ReluState});
            this.gridControl1.Size = new System.Drawing.Size(928, 305);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridControl1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 125);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(934, 326);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "商品详细显示";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.luStockId);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.luProdStyle);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txPriceMax);
            this.groupBox2.Controls.Add(this.txPriceMin);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txBarcode);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.luSuppName);
            this.groupBox2.Controls.Add(this.luProdNature);
            this.groupBox2.Controls.Add(this.txWgtMax);
            this.groupBox2.Controls.Add(this.txWgtMin);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txProdName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 45);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(934, 80);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "查询条件";
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(808, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 53);
            this.button2.TabIndex = 26;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(185, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 14);
            this.label10.TabIndex = 24;
            this.label10.Text = "柜台名称：";
            // 
            // luProdStyle
            // 
            this.luProdStyle.Location = new System.Drawing.Point(258, 48);
            this.luProdStyle.Name = "luProdStyle";
            this.luProdStyle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luProdStyle.Size = new System.Drawing.Size(100, 21);
            this.luProdStyle.TabIndex = 23;
            this.luProdStyle.Tag = "ProdStyle";
            this.luProdStyle.EditValueChanged += new System.EventHandler(this.luProdStyle_EditValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(185, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 22;
            this.label2.Text = "商品款式：";
            // 
            // txPriceMax
            // 
            this.txPriceMax.Location = new System.Drawing.Point(730, 45);
            this.txPriceMax.Name = "txPriceMax";
            this.txPriceMax.Size = new System.Drawing.Size(57, 22);
            this.txPriceMax.TabIndex = 21;
            // 
            // txPriceMin
            // 
            this.txPriceMin.Location = new System.Drawing.Point(664, 45);
            this.txPriceMin.Name = "txPriceMin";
            this.txPriceMin.Size = new System.Drawing.Size(60, 22);
            this.txPriceMin.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(602, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 14);
            this.label9.TabIndex = 19;
            this.label9.Text = "价格范围：";
            // 
            // txBarcode
            // 
            this.txBarcode.Location = new System.Drawing.Point(79, 17);
            this.txBarcode.Name = "txBarcode";
            this.txBarcode.Size = new System.Drawing.Size(100, 22);
            this.txBarcode.TabIndex = 18;
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
            // gridColumn1
            // 
            this.gridColumn1.Caption = "柜台";
            this.gridColumn1.ColumnEdit = this.ReluStockId;
            this.gridColumn1.FieldName = "StockId";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
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
            // gridColumn5
            // 
            this.gridColumn5.Caption = "款式类型";
            this.gridColumn5.ColumnEdit = this.ReluProdStyle;
            this.gridColumn5.FieldName = "ProdStyle";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "数量";
            this.gridColumn6.FieldName = "Qty";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "重量";
            this.gridColumn7.FieldName = "Wgt";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // ReluStockId
            // 
            this.ReluStockId.AutoHeight = false;
            this.ReluStockId.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ReluStockId.Name = "ReluStockId";
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "标签价";
            this.gridColumn8.FieldName = "SalePrice";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "供应商";
            this.gridColumn9.ColumnEdit = this.ReluSuppName;
            this.gridColumn9.FieldName = "SuppName";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            // 
            // ReluProdNature
            // 
            this.ReluProdNature.AutoHeight = false;
            this.ReluProdNature.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ReluProdNature.Name = "ReluProdNature";
            // 
            // ReluProdStyle
            // 
            this.ReluProdStyle.AutoHeight = false;
            this.ReluProdStyle.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ReluProdStyle.Name = "ReluProdStyle";
            // 
            // ReluSuppName
            // 
            this.ReluSuppName.AutoHeight = false;
            this.ReluSuppName.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ReluSuppName.Name = "ReluSuppName";
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "状态";
            this.gridColumn10.ColumnEdit = this.ReluState;
            this.gridColumn10.FieldName = "State";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 9;
            // 
            // ReluState
            // 
            this.ReluState.AutoHeight = false;
            this.ReluState.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ReluState.Name = "ReluState";
            // 
            // frmProdStockQty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(934, 451);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmProdStockQty";
            this.Text = "frmProdStockQty";
            this.Load += new System.EventHandler(this.frmProdStockQty_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luSuppName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProdNature.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luStockId.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProdStyle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReluStockId)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReluProdNature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReluProdStyle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReluSuppName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReluState)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraEditors.LookUpEdit luSuppName;
        private DevExpress.XtraEditors.LookUpEdit luProdNature;
        private System.Windows.Forms.TextBox txWgtMax;
        private System.Windows.Forms.TextBox txWgtMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txProdName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txCount;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.LookUpEdit luStockId;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.LookUpEdit luProdStyle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txPriceMax;
        private System.Windows.Forms.TextBox txPriceMin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txBarcode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ReluStockId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ReluProdNature;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ReluProdStyle;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ReluSuppName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit ReluState;


    }
}