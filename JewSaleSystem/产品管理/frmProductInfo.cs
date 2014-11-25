using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using DevExpress.XtraBars;
using System.Reflection;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraEditors.Repository;

using System.Reflection;
using DevExpress.XtraGrid.Controls;


namespace JewSaleSystem
{
    public partial class frmProductInfo : DevExpress.XtraEditors.XtraForm
    {
        public frmProductInfo()
        {
            InitializeComponent();
        }
       readonly SQLHelper sqlhelper = new SQLHelper();

        private void frmProductInfo_Load(object sender, EventArgs e)
        { 
            //下拉绑定
            Combox(lookUpEdit3,"SuppName");
            Combox(lookUpEdit2, "ProdNature");
            Combox(lookUpEdit1, "ProdStyle");

            ReplaceCombox(luProdStyle, "ProdStyle");
            ReplaceCombox(luProdNature, "ProdNature");
            ReplaceCombox(luSuppName, "SuppName");
            ReplaceCombox(luState, "ProdState");


        }
        /// <summary>下拉绑定函数
        /// 
        /// </summary>
        /// <param name="lookupdedit"></param>
        /// <param name="Name"></param>
        public void Combox (LookUpEdit lookupdedit,String Name)
        {
            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@flag", 1),
                    new SqlParameter("@Name", Name)
                };
            DataTable dt = sqlhelper.ExecuteQueryTable("Sys_Base_Combox_Add_Edit_Del", paras, CommandType.StoredProcedure);
            lookupdedit.Properties.DataSource = dt.DefaultView;
            lookupdedit.Properties.NullText = "";
            lookupdedit.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("名称"));
            lookupdedit.Properties.ValueMember = dt.Columns["Value"].ColumnName;
            lookupdedit.Properties.DisplayMember = dt.Columns["名称"].ColumnName;
            
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
        /// <summary>进入编辑页面
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = DxCtlHelper.OpenChildFromNew(this.MdiParent, "frmProductInfoEdit");
            frm.Text = "产品信息编辑";
        }
        /// <summary>查看商品
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@flag", 1)                    
                };
           DataTable dtProd = sqlhelper.ExecuteQueryTable("Sys_H_JewProductInfo_Add_Edit_Del", paras, CommandType.StoredProcedure);
           gridControl1.DataSource = dtProd.DefaultView;
        }
        /// <summary>获得供应商信息
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lookUpEdit3_EditValueChanged(object sender, EventArgs e)
        {
            ProductInfo.SuppName = Convert.ToInt32(lookUpEdit3.EditValue.ToString());
        }
        /// <summary>获得商品款式
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            ProductInfo.ProdStyle = Convert.ToInt32(lookUpEdit1.EditValue.ToString());
        }
        /// <summary>获得商品性质
        /// h
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lookUpEdit2_EditValueChanged(object sender, EventArgs e)
        {
            ProductInfo.ProdNature = Convert.ToInt32(lookUpEdit2.EditValue.ToString());
        }


       
    }
}