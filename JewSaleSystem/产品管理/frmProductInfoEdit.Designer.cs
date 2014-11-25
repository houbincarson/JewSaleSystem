namespace JewSaleSystem
{
    partial class frmProductInfoEdit
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txProcessCost = new System.Windows.Forms.TextBox();
            this.luSuppName = new DevExpress.XtraEditors.LookUpEdit();
            this.luProdStyle = new DevExpress.XtraEditors.LookUpEdit();
            this.luProdNature = new DevExpress.XtraEditors.LookUpEdit();
            this.txRemark = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txCostPrice = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txWgt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txSalePrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txProdName = new System.Windows.Forms.TextBox();
            this.txBarcode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luSuppName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProdStyle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProdNature.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.gridControl1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 198);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1052, 268);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 18);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1046, 247);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 14);
            this.label2.TabIndex = 1;
            this.label2.Text = "商品名称：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "商品条码：";
            // 
            // button6
            // 
            this.button6.Image = global::JewSaleSystem.Properties.Resources.trash;
            this.button6.Location = new System.Drawing.Point(657, 16);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 47);
            this.button6.TabIndex = 5;
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1052, 74);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // button5
            // 
            this.button5.Image = global::JewSaleSystem.Properties.Resources.edit;
            this.button5.Location = new System.Drawing.Point(375, 16);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 47);
            this.button5.TabIndex = 4;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Image = global::JewSaleSystem.Properties.Resources.filesearch;
            this.button4.Location = new System.Drawing.Point(93, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 47);
            this.button4.TabIndex = 3;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Image = global::JewSaleSystem.Properties.Resources.add1;
            this.button3.Location = new System.Drawing.Point(234, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 47);
            this.button3.TabIndex = 2;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = global::JewSaleSystem.Properties.Resources.back;
            this.button2.Location = new System.Drawing.Point(798, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 47);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = global::JewSaleSystem.Properties.Resources.saveas;
            this.button1.Location = new System.Drawing.Point(516, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 47);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txProcessCost);
            this.groupBox2.Controls.Add(this.luSuppName);
            this.groupBox2.Controls.Add(this.luProdStyle);
            this.groupBox2.Controls.Add(this.luProdNature);
            this.groupBox2.Controls.Add(this.txRemark);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txCostPrice);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txWgt);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txSalePrice);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txProdName);
            this.groupBox2.Controls.Add(this.txBarcode);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1052, 124);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // txProcessCost
            // 
            this.txProcessCost.Location = new System.Drawing.Point(305, 87);
            this.txProcessCost.Name = "txProcessCost";
            this.txProcessCost.Size = new System.Drawing.Size(126, 22);
            this.txProcessCost.TabIndex = 27;
            this.txProcessCost.Tag = "ProcessCost";
            // 
            // luSuppName
            // 
            this.luSuppName.Location = new System.Drawing.Point(905, 34);
            this.luSuppName.Name = "luSuppName";
            this.luSuppName.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luSuppName.Size = new System.Drawing.Size(119, 21);
            this.luSuppName.TabIndex = 26;
            this.luSuppName.Tag = "SuppName";
            // 
            // luProdStyle
            // 
            this.luProdStyle.Location = new System.Drawing.Point(714, 34);
            this.luProdStyle.Name = "luProdStyle";
            this.luProdStyle.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luProdStyle.Size = new System.Drawing.Size(119, 21);
            this.luProdStyle.TabIndex = 25;
            this.luProdStyle.Tag = "ProdStyle";
            // 
            // luProdNature
            // 
            this.luProdNature.Location = new System.Drawing.Point(516, 33);
            this.luProdNature.Name = "luProdNature";
            this.luProdNature.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luProdNature.Size = new System.Drawing.Size(119, 21);
            this.luProdNature.TabIndex = 24;
            this.luProdNature.Tag = "ProdNature";
            // 
            // txRemark
            // 
            this.txRemark.Location = new System.Drawing.Point(910, 89);
            this.txRemark.Name = "txRemark";
            this.txRemark.Size = new System.Drawing.Size(117, 22);
            this.txRemark.TabIndex = 23;
            this.txRemark.Tag = "Remark";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(849, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 14);
            this.label10.TabIndex = 22;
            this.label10.Text = "备注：";
            // 
            // txCostPrice
            // 
            this.txCostPrice.Location = new System.Drawing.Point(516, 86);
            this.txCostPrice.Name = "txCostPrice";
            this.txCostPrice.Size = new System.Drawing.Size(119, 22);
            this.txCostPrice.TabIndex = 21;
            this.txCostPrice.Tag = "CostPrice";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(447, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 14);
            this.label4.TabIndex = 20;
            this.label4.Text = "进价成本：";
            // 
            // txWgt
            // 
            this.txWgt.Location = new System.Drawing.Point(85, 90);
            this.txWgt.Name = "txWgt";
            this.txWgt.Size = new System.Drawing.Size(117, 22);
            this.txWgt.TabIndex = 19;
            this.txWgt.Tag = "Wgt";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(648, 91);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 14);
            this.label9.TabIndex = 18;
            this.label9.Text = "建议售价:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(844, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 14);
            this.label8.TabIndex = 16;
            this.label8.Text = "供应商：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(646, 36);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 14);
            this.label7.TabIndex = 14;
            this.label7.Text = "商品款式:";
            // 
            // txSalePrice
            // 
            this.txSalePrice.Location = new System.Drawing.Point(713, 89);
            this.txSalePrice.Name = "txSalePrice";
            this.txSalePrice.Size = new System.Drawing.Size(128, 22);
            this.txSalePrice.TabIndex = 12;
            this.txSalePrice.Tag = "SalePrice";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(232, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "进价工费：";
            // 
            // txProdName
            // 
            this.txProdName.Location = new System.Drawing.Point(302, 33);
            this.txProdName.Name = "txProdName";
            this.txProdName.Size = new System.Drawing.Size(126, 22);
            this.txProdName.TabIndex = 6;
            this.txProdName.Tag = "ProdName";
            // 
            // txBarcode
            // 
            this.txBarcode.Enabled = false;
            this.txBarcode.Location = new System.Drawing.Point(84, 33);
            this.txBarcode.Name = "txBarcode";
            this.txBarcode.Size = new System.Drawing.Size(126, 22);
            this.txBarcode.TabIndex = 5;
            this.txBarcode.Tag = "Barcode";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "商品重量：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(447, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "商品性质：";
            // 
            // frmProductInfoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 466);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmProductInfoEdit";
            this.Text = "frmProductInfoEdit";
            this.Load += new System.EventHandler(this.frmProductInfoEdit_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.luSuppName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProdStyle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.luProdNature.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txSalePrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txProdName;
        private System.Windows.Forms.TextBox txBarcode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txRemark;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txCostPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txWgt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.LookUpEdit luSuppName;
        private DevExpress.XtraEditors.LookUpEdit luProdStyle;
        private DevExpress.XtraEditors.LookUpEdit luProdNature;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.TextBox txProcessCost;
    }
}