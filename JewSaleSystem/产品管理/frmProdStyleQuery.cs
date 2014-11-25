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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraEditors.Repository;

using System.Reflection;
using DevExpress.XtraGrid.Controls;

namespace JewSaleSystem
{
    public partial class frmProdStyleQuery : DevExpress.XtraEditors.XtraForm
    {
        public frmProdStyleQuery()
        {
            InitializeComponent();
        }

        readonly SQLHelper sqlhelper = new SQLHelper();
        int ProdNature = -1;
        int ProdStyle = -1;
        int SuppName = -1;
        /// <summary>进入款式页面编辑
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = DxCtlHelper.OpenChildFromNew(this.MdiParent, "frmProdStyleEdit");
            frm.Text = "款式编辑";
        }

        private void frmProdStyleQuery_Load(object sender, EventArgs e)
        {
            Combox(luSuppName, "SuppName");
            Combox(luProdNature, "ProdNature");
            Combox(luProdStyle, "ProdStyle");

            ReplaceCombox(ReluSuppName, "SuppName");
            ReplaceCombox(ReluProdNature, "ProdNature");
            ReplaceCombox(ReluProdStyle, "ProdStyle");

        }
        /// <summary>查看
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@flag", 1),  
                     new SqlParameter("@StyleName", StyleName.Text),
                      new SqlParameter("@ProdNature",ProdNature),
                       new SqlParameter("@SuppName",SuppName ),
                        new SqlParameter("@ProdStyle",ProdStyle )
                };
            DataTable dtProd = sqlhelper.ExecuteQueryTable("Sys_H_ProdStyle_Add_Edit_Del", paras, CommandType.StoredProcedure);
            gridControl1.DataSource = dtProd.DefaultView;
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
        /// <summary>下拉绑定函数
        /// 
        /// </summary>
        /// <param name="lookupdedit"></param>
        /// <param name="Name"></param>
        public void Combox(LookUpEdit lookupdedit, String Name)
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
        /// <summary>下拉取数
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void luProdStyle_EditValueChanged(object sender, EventArgs e)
        {
           ProdStyle =  Convert.ToInt32(luProdStyle.EditValue.ToString());
        }
        private void luProdNature_EditValueChanged(object sender, EventArgs e)
        {
            ProdNature = Convert.ToInt32(luProdNature.EditValue.ToString());
        }
        private void luSuppName_EditValueChanged(object sender, EventArgs e)
        {
            SuppName = Convert.ToInt32(luSuppName.EditValue.ToString());
        }     
    }
}