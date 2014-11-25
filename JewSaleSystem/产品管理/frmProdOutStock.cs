using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraEditors.Repository;
using System.Data.SqlClient;
using System.Reflection;
using DevExpress.XtraGrid.Controls;


namespace JewSaleSystem
{
    public partial class frmProdOutStock : DevExpress.XtraEditors.XtraForm
    {
        public frmProdOutStock()
        {
            InitializeComponent();
        }
        SQLHelper sqlhelper = new SQLHelper();
        DataTable dtMaster = null;  // 主表
        DataTable dtDtl = null;     //明细表
        DataRow dr = null;
        private string Key_Id = "";
        private string strKeyId = "ProdOutStockId";//主表主键

        private void frmProdOutStock_Load(object sender, EventArgs e)
        {
            //gridView1
            ReplaceCombox(ReluSuppName, "SuppName");
            ReplaceCombox(ReluState, "State");
            ReplaceCombox(ReluStockId, "StockId");
            //gridView2
            ReplaceCombox(DtReluProdNature, "ProdNature");  
            ReplaceCombox(DtReluProdStyle, "ProdStyle");

            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
        }
        /// <summary>下拉绑定函数
        /// 
        /// </summary>
        /// <param name="lookupdedit"></param>
        /// <param name="Name"></param>
        public void ReplaceCombox(RepositoryItemLookUpEdit lookupdedit, String Name)
        {
            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@flag", 1),
                    new SqlParameter("@Name", Name)
                };
            DataTable dt = sqlhelper.ExecuteQueryTable("Sys_Base_Combox_Add_Edit_Del", paras, CommandType.StoredProcedure);
            lookupdedit.DataSource = dt;
            lookupdedit.NullText = "";
            lookupdedit.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("名称"));
            lookupdedit.ValueMember = dt.Columns["Value"].ColumnName;
            lookupdedit.DisplayMember = dt.Columns["名称"].ColumnName;
        } 
        /// <summary>查看主表
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {

            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id) ,
                    new SqlParameter("@flag", 1),
                    new SqlParameter("@ChkDel",ChkDel.Checked)
                };
            dtMaster = sqlhelper.ExecuteQueryTable("Sys_H_ProdOutStock_Add_Edit_Del", paras, CommandType.StoredProcedure);
            gridControl1.DataSource = dtMaster.DefaultView;
            gridView1.BestFitColumns();
        }
        /// <summary>查看明细表
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (splitContainerControl1.PanelVisibility == SplitPanelVisibility.Panel1)
            {
                splitContainerControl1.PanelVisibility = SplitPanelVisibility.Both;
                SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@Key_Id",Key_Id),
                    new SqlParameter("@flag", 2)
                };
                dtDtl = sqlhelper.ExecuteQueryTable("Sys_H_ProdOutStock_Add_Edit_Del", paras, CommandType.StoredProcedure);
                gridControl2.DataSource = dtDtl.DefaultView;
                gridView2.BestFitColumns();
            }
            else
            {
                splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel1;
            }
        }
        /// <summary>进入编辑页面
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            GlobalUserInfo.Key_Id = -1;
            Form frm = DxCtlHelper.OpenChildFromNew(this.MdiParent, "frmProdOutStockEdit");
            frm.Text = "产品退库编辑";
           
        }
        /// <summary>单击选中某行
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            dr = gridView1.GetFocusedDataRow();
            if (dr == null)
                return;
            else
            {
                Key_Id = dr[strKeyId].ToString();
            }
        }
        /// <summary>双击进入编辑页面
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GlobalUserInfo.Key_Id = Convert.ToInt32(Key_Id);
            Form frm = DxCtlHelper.OpenChildFromNew(this.MdiParent, "frmProdOutStockEdit");
            frm.Text = "产品退库编辑";
        }
    }
}