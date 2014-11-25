namespace JewSaleSystem
{
    partial class frmRoleManageEdit
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.luRoleId = new DevExpress.XtraEditors.LookUpEdit();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SubChgPassword = new System.Windows.Forms.CheckBox();
            this.SubChgUser = new System.Windows.Forms.CheckBox();
            this.SubSysClose = new System.Windows.Forms.CheckBox();
            this.SubSaleOut = new System.Windows.Forms.CheckBox();
            this.SubSaleBack = new System.Windows.Forms.CheckBox();
            this.SubGetOldGold = new System.Windows.Forms.CheckBox();
            this.SubProdStyle = new System.Windows.Forms.CheckBox();
            this.SubProduct = new System.Windows.Forms.CheckBox();
            this.SubInStock = new System.Windows.Forms.CheckBox();
            this.SubOutStock = new System.Windows.Forms.CheckBox();
            this.SubStockQty = new System.Windows.Forms.CheckBox();
            this.SubStockHis = new System.Windows.Forms.CheckBox();
            this.SubStockChk = new System.Windows.Forms.CheckBox();
            this.SubRights = new System.Windows.Forms.CheckBox();
            this.SubEmployee = new System.Windows.Forms.CheckBox();
            this.SubSupport = new System.Windows.Forms.CheckBox();
            this.SubRepInStock = new System.Windows.Forms.CheckBox();
            this.SubRepOutStock = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SubRepSaleBack = new System.Windows.Forms.CheckBox();
            this.SubRepProdCheck = new System.Windows.Forms.CheckBox();
            this.SubRepProfits = new System.Windows.Forms.CheckBox();
            this.SubRepSaleOut = new System.Windows.Forms.CheckBox();
            this.SubSetGoldPirce = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ckbSeleAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.luRoleId.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(282, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "确认";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(425, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // luRoleId
            // 
            this.luRoleId.Location = new System.Drawing.Point(84, 22);
            this.luRoleId.Name = "luRoleId";
            this.luRoleId.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.luRoleId.Size = new System.Drawing.Size(154, 21);
            this.luRoleId.TabIndex = 1;
            this.luRoleId.Tag = "RoleId";
            this.luRoleId.EditValueChanged += new System.EventHandler(this.luRoleId_EditValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.luRoleId);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(586, 67);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // SubChgPassword
            // 
            this.SubChgPassword.AutoSize = true;
            this.SubChgPassword.Location = new System.Drawing.Point(113, 42);
            this.SubChgPassword.Name = "SubChgPassword";
            this.SubChgPassword.Size = new System.Drawing.Size(74, 18);
            this.SubChgPassword.TabIndex = 0;
            this.SubChgPassword.Tag = "SubChgPassword";
            this.SubChgPassword.Text = "修改密码";
            this.SubChgPassword.UseVisualStyleBackColor = true;
            // 
            // SubChgUser
            // 
            this.SubChgUser.AutoSize = true;
            this.SubChgUser.Location = new System.Drawing.Point(244, 42);
            this.SubChgUser.Name = "SubChgUser";
            this.SubChgUser.Size = new System.Drawing.Size(74, 18);
            this.SubChgUser.TabIndex = 1;
            this.SubChgUser.Tag = "SubChgUser";
            this.SubChgUser.Text = "切换用户";
            this.SubChgUser.UseVisualStyleBackColor = true;
            // 
            // SubSysClose
            // 
            this.SubSysClose.AutoSize = true;
            this.SubSysClose.Location = new System.Drawing.Point(373, 42);
            this.SubSysClose.Name = "SubSysClose";
            this.SubSysClose.Size = new System.Drawing.Size(74, 18);
            this.SubSysClose.TabIndex = 2;
            this.SubSysClose.Tag = "SubSysClose";
            this.SubSysClose.Text = "注销系统";
            this.SubSysClose.UseVisualStyleBackColor = true;
            // 
            // SubSaleOut
            // 
            this.SubSaleOut.AutoSize = true;
            this.SubSaleOut.Location = new System.Drawing.Point(113, 77);
            this.SubSaleOut.Name = "SubSaleOut";
            this.SubSaleOut.Size = new System.Drawing.Size(74, 18);
            this.SubSaleOut.TabIndex = 5;
            this.SubSaleOut.Tag = "SubSaleOut";
            this.SubSaleOut.Text = "商品销售";
            this.SubSaleOut.UseVisualStyleBackColor = true;
            // 
            // SubSaleBack
            // 
            this.SubSaleBack.AutoSize = true;
            this.SubSaleBack.Location = new System.Drawing.Point(244, 77);
            this.SubSaleBack.Name = "SubSaleBack";
            this.SubSaleBack.Size = new System.Drawing.Size(74, 18);
            this.SubSaleBack.TabIndex = 6;
            this.SubSaleBack.Tag = "SubSaleBack";
            this.SubSaleBack.Text = "销售退货";
            this.SubSaleBack.UseVisualStyleBackColor = true;
            // 
            // SubGetOldGold
            // 
            this.SubGetOldGold.AutoSize = true;
            this.SubGetOldGold.Location = new System.Drawing.Point(373, 77);
            this.SubGetOldGold.Name = "SubGetOldGold";
            this.SubGetOldGold.Size = new System.Drawing.Size(74, 18);
            this.SubGetOldGold.TabIndex = 7;
            this.SubGetOldGold.Tag = "SubGetOldGold";
            this.SubGetOldGold.Text = "旧金回收";
            this.SubGetOldGold.UseVisualStyleBackColor = true;
            // 
            // SubProdStyle
            // 
            this.SubProdStyle.AutoSize = true;
            this.SubProdStyle.Location = new System.Drawing.Point(113, 115);
            this.SubProdStyle.Name = "SubProdStyle";
            this.SubProdStyle.Size = new System.Drawing.Size(74, 18);
            this.SubProdStyle.TabIndex = 10;
            this.SubProdStyle.Tag = "SubProdStyle";
            this.SubProdStyle.Text = "款式管理";
            this.SubProdStyle.UseVisualStyleBackColor = true;
            // 
            // SubProduct
            // 
            this.SubProduct.AutoSize = true;
            this.SubProduct.Location = new System.Drawing.Point(244, 115);
            this.SubProduct.Name = "SubProduct";
            this.SubProduct.Size = new System.Drawing.Size(74, 18);
            this.SubProduct.TabIndex = 11;
            this.SubProduct.Tag = "SubProduct";
            this.SubProduct.Text = "产品查询";
            this.SubProduct.UseVisualStyleBackColor = true;
            // 
            // SubInStock
            // 
            this.SubInStock.AutoSize = true;
            this.SubInStock.Location = new System.Drawing.Point(373, 115);
            this.SubInStock.Name = "SubInStock";
            this.SubInStock.Size = new System.Drawing.Size(74, 18);
            this.SubInStock.TabIndex = 12;
            this.SubInStock.Tag = "SubInStock";
            this.SubInStock.Text = "产品入库";
            this.SubInStock.UseVisualStyleBackColor = true;
            // 
            // SubOutStock
            // 
            this.SubOutStock.AutoSize = true;
            this.SubOutStock.Location = new System.Drawing.Point(499, 115);
            this.SubOutStock.Name = "SubOutStock";
            this.SubOutStock.Size = new System.Drawing.Size(74, 18);
            this.SubOutStock.TabIndex = 13;
            this.SubOutStock.Tag = "SubOutStock";
            this.SubOutStock.Text = "产品退库";
            this.SubOutStock.UseVisualStyleBackColor = true;
            // 
            // SubStockQty
            // 
            this.SubStockQty.AutoSize = true;
            this.SubStockQty.Location = new System.Drawing.Point(113, 152);
            this.SubStockQty.Name = "SubStockQty";
            this.SubStockQty.Size = new System.Drawing.Size(74, 18);
            this.SubStockQty.TabIndex = 15;
            this.SubStockQty.Tag = "SubStockQty";
            this.SubStockQty.Text = "实时库存";
            this.SubStockQty.UseVisualStyleBackColor = true;
            // 
            // SubStockHis
            // 
            this.SubStockHis.AutoSize = true;
            this.SubStockHis.Location = new System.Drawing.Point(244, 152);
            this.SubStockHis.Name = "SubStockHis";
            this.SubStockHis.Size = new System.Drawing.Size(74, 18);
            this.SubStockHis.TabIndex = 16;
            this.SubStockHis.Tag = "SubStockHis";
            this.SubStockHis.Text = "历史库存";
            this.SubStockHis.UseVisualStyleBackColor = true;
            // 
            // SubStockChk
            // 
            this.SubStockChk.AutoSize = true;
            this.SubStockChk.Location = new System.Drawing.Point(373, 152);
            this.SubStockChk.Name = "SubStockChk";
            this.SubStockChk.Size = new System.Drawing.Size(74, 18);
            this.SubStockChk.TabIndex = 17;
            this.SubStockChk.Tag = "SubStockChk";
            this.SubStockChk.Text = "库存盘点";
            this.SubStockChk.UseVisualStyleBackColor = true;
            // 
            // SubRights
            // 
            this.SubRights.AutoSize = true;
            this.SubRights.Location = new System.Drawing.Point(113, 193);
            this.SubRights.Name = "SubRights";
            this.SubRights.Size = new System.Drawing.Size(74, 18);
            this.SubRights.TabIndex = 20;
            this.SubRights.Tag = "SubRights";
            this.SubRights.Text = "权限管理";
            this.SubRights.UseVisualStyleBackColor = true;
            // 
            // SubEmployee
            // 
            this.SubEmployee.AutoSize = true;
            this.SubEmployee.Location = new System.Drawing.Point(244, 193);
            this.SubEmployee.Name = "SubEmployee";
            this.SubEmployee.Size = new System.Drawing.Size(74, 18);
            this.SubEmployee.TabIndex = 21;
            this.SubEmployee.Tag = "SubEmployee";
            this.SubEmployee.Text = "员工管理";
            this.SubEmployee.UseVisualStyleBackColor = true;
            // 
            // SubSupport
            // 
            this.SubSupport.AutoSize = true;
            this.SubSupport.Location = new System.Drawing.Point(373, 193);
            this.SubSupport.Name = "SubSupport";
            this.SubSupport.Size = new System.Drawing.Size(86, 18);
            this.SubSupport.TabIndex = 22;
            this.SubSupport.Tag = "SubSupport";
            this.SubSupport.Text = "供应商管理";
            this.SubSupport.UseVisualStyleBackColor = true;
            // 
            // SubRepInStock
            // 
            this.SubRepInStock.AutoSize = true;
            this.SubRepInStock.Location = new System.Drawing.Point(113, 228);
            this.SubRepInStock.Name = "SubRepInStock";
            this.SubRepInStock.Size = new System.Drawing.Size(74, 18);
            this.SubRepInStock.TabIndex = 23;
            this.SubRepInStock.Tag = "SubRepInStock";
            this.SubRepInStock.Text = "入库报表";
            this.SubRepInStock.UseVisualStyleBackColor = true;
            // 
            // SubRepOutStock
            // 
            this.SubRepOutStock.AutoSize = true;
            this.SubRepOutStock.Location = new System.Drawing.Point(244, 228);
            this.SubRepOutStock.Name = "SubRepOutStock";
            this.SubRepOutStock.Size = new System.Drawing.Size(74, 18);
            this.SubRepOutStock.TabIndex = 24;
            this.SubRepOutStock.Tag = "SubRepOutStock";
            this.SubRepOutStock.Text = "退库报表";
            this.SubRepOutStock.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 25;
            this.label1.Text = "系统设置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 14);
            this.label2.TabIndex = 26;
            this.label2.Text = "销售管理";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 14);
            this.label3.TabIndex = 27;
            this.label3.Text = "产品管理";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 14);
            this.label4.TabIndex = 28;
            this.label4.Text = "基础设置";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 14);
            this.label5.TabIndex = 29;
            this.label5.Text = "报表管理";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 14);
            this.label7.TabIndex = 30;
            this.label7.Text = "库存管理";
            // 
            // SubRepSaleBack
            // 
            this.SubRepSaleBack.AutoSize = true;
            this.SubRepSaleBack.Location = new System.Drawing.Point(113, 265);
            this.SubRepSaleBack.Name = "SubRepSaleBack";
            this.SubRepSaleBack.Size = new System.Drawing.Size(74, 18);
            this.SubRepSaleBack.TabIndex = 31;
            this.SubRepSaleBack.Tag = "SubRepSaleBack";
            this.SubRepSaleBack.Text = "退货报表";
            this.SubRepSaleBack.UseVisualStyleBackColor = true;
            // 
            // SubRepProdCheck
            // 
            this.SubRepProdCheck.AutoSize = true;
            this.SubRepProdCheck.Location = new System.Drawing.Point(244, 265);
            this.SubRepProdCheck.Name = "SubRepProdCheck";
            this.SubRepProdCheck.Size = new System.Drawing.Size(74, 18);
            this.SubRepProdCheck.TabIndex = 32;
            this.SubRepProdCheck.Tag = "SubRepProdCheck";
            this.SubRepProdCheck.Text = "盘点报表";
            this.SubRepProdCheck.UseVisualStyleBackColor = true;
            // 
            // SubRepProfits
            // 
            this.SubRepProfits.AutoSize = true;
            this.SubRepProfits.Location = new System.Drawing.Point(373, 265);
            this.SubRepProfits.Name = "SubRepProfits";
            this.SubRepProfits.Size = new System.Drawing.Size(74, 18);
            this.SubRepProfits.TabIndex = 33;
            this.SubRepProfits.Tag = "SubRepProfits";
            this.SubRepProfits.Text = "利润报表";
            this.SubRepProfits.UseVisualStyleBackColor = true;
            // 
            // SubRepSaleOut
            // 
            this.SubRepSaleOut.AutoSize = true;
            this.SubRepSaleOut.Location = new System.Drawing.Point(373, 228);
            this.SubRepSaleOut.Name = "SubRepSaleOut";
            this.SubRepSaleOut.Size = new System.Drawing.Size(74, 18);
            this.SubRepSaleOut.TabIndex = 34;
            this.SubRepSaleOut.Tag = "SubRepSaleOut";
            this.SubRepSaleOut.Text = "销售报表";
            this.SubRepSaleOut.UseVisualStyleBackColor = true;
            // 
            // SubSetGoldPirce
            // 
            this.SubSetGoldPirce.AutoSize = true;
            this.SubSetGoldPirce.Location = new System.Drawing.Point(499, 192);
            this.SubSetGoldPirce.Name = "SubSetGoldPirce";
            this.SubSetGoldPirce.Size = new System.Drawing.Size(74, 18);
            this.SubSetGoldPirce.TabIndex = 35;
            this.SubSetGoldPirce.Tag = "SubSetGoldPirce";
            this.SubSetGoldPirce.Text = "金价设置";
            this.SubSetGoldPirce.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ckbSeleAll);
            this.groupBox2.Controls.Add(this.SubSetGoldPirce);
            this.groupBox2.Controls.Add(this.SubRepSaleOut);
            this.groupBox2.Controls.Add(this.SubRepProfits);
            this.groupBox2.Controls.Add(this.SubRepProdCheck);
            this.groupBox2.Controls.Add(this.SubRepSaleBack);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.SubRepOutStock);
            this.groupBox2.Controls.Add(this.SubRepInStock);
            this.groupBox2.Controls.Add(this.SubSupport);
            this.groupBox2.Controls.Add(this.SubEmployee);
            this.groupBox2.Controls.Add(this.SubRights);
            this.groupBox2.Controls.Add(this.SubStockChk);
            this.groupBox2.Controls.Add(this.SubStockHis);
            this.groupBox2.Controls.Add(this.SubStockQty);
            this.groupBox2.Controls.Add(this.SubOutStock);
            this.groupBox2.Controls.Add(this.SubInStock);
            this.groupBox2.Controls.Add(this.SubProduct);
            this.groupBox2.Controls.Add(this.SubProdStyle);
            this.groupBox2.Controls.Add(this.SubGetOldGold);
            this.groupBox2.Controls.Add(this.SubSaleBack);
            this.groupBox2.Controls.Add(this.SubSaleOut);
            this.groupBox2.Controls.Add(this.SubSysClose);
            this.groupBox2.Controls.Add(this.SubChgUser);
            this.groupBox2.Controls.Add(this.SubChgPassword);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(586, 298);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "权限列表";
            // 
            // ckbSeleAll
            // 
            this.ckbSeleAll.AutoSize = true;
            this.ckbSeleAll.Location = new System.Drawing.Point(65, 0);
            this.ckbSeleAll.Name = "ckbSeleAll";
            this.ckbSeleAll.Size = new System.Drawing.Size(54, 18);
            this.ckbSeleAll.TabIndex = 36;
            this.ckbSeleAll.Tag = "";
            this.ckbSeleAll.Text = " 全选";
            this.ckbSeleAll.UseVisualStyleBackColor = true;
            this.ckbSeleAll.CheckedChanged += new System.EventHandler(this.ckbSeleAll_CheckedChanged);
            // 
            // frmRoleManageEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 365);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmRoleManageEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRoleManageEdit";
            this.Load += new System.EventHandler(this.frmRoleManageEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.luRoleId.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraEditors.LookUpEdit luRoleId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox SubChgPassword;
        private System.Windows.Forms.CheckBox SubChgUser;
        private System.Windows.Forms.CheckBox SubSysClose;
        private System.Windows.Forms.CheckBox SubSaleOut;
        private System.Windows.Forms.CheckBox SubSaleBack;
        private System.Windows.Forms.CheckBox SubGetOldGold;
        private System.Windows.Forms.CheckBox SubProdStyle;
        private System.Windows.Forms.CheckBox SubProduct;
        private System.Windows.Forms.CheckBox SubInStock;
        private System.Windows.Forms.CheckBox SubOutStock;
        private System.Windows.Forms.CheckBox SubStockQty;
        private System.Windows.Forms.CheckBox SubStockHis;
        private System.Windows.Forms.CheckBox SubStockChk;
        private System.Windows.Forms.CheckBox SubRights;
        private System.Windows.Forms.CheckBox SubEmployee;
        private System.Windows.Forms.CheckBox SubSupport;
        private System.Windows.Forms.CheckBox SubRepInStock;
        private System.Windows.Forms.CheckBox SubRepOutStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox SubRepSaleBack;
        private System.Windows.Forms.CheckBox SubRepProdCheck;
        private System.Windows.Forms.CheckBox SubRepProfits;
        private System.Windows.Forms.CheckBox SubRepSaleOut;
        private System.Windows.Forms.CheckBox SubSetGoldPirce;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox ckbSeleAll;
    }
}