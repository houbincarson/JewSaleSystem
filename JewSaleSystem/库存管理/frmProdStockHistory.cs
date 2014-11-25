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

namespace JewSaleSystem
{
    public partial class frmProdStockHistory : DevExpress.XtraEditors.XtraForm
    {
        public frmProdStockHistory()
        {
            InitializeComponent();
        }
        SQLHelper sqlhelper = new SQLHelper();
        private void frmProdStockHistory_Load(object sender, EventArgs e)
        {
            Combox(luStockId, "StockId");

            ReplaceCombox(ReluStockId, "StockId");
            ReplaceCombox(ReluProdNature, "ProdNature");
            ReplaceCombox(ReluSuppName, "SuppName");
            ReplaceCombox(ReluProdStyle, "ProdStyle");
            ReplaceCombox(ReluState, "ProdState");

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
        int StockId = -1;
        private void button2_Click(object sender, EventArgs e)
        {
            string Barcode = txBarcode.Text;
            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@flag", 2),
                    new SqlParameter("@StockId", StockId),
                     new SqlParameter("@Barcode",Barcode ),                
                };
            DataTable dt = sqlhelper.ExecuteQueryTable("Sys_H_ProdInStockHistory_Query", paras, CommandType.StoredProcedure);
            gridControl1.DataSource = dt.DefaultView;
            gridView1.BestFitColumns();
        }

        private void luStockId_EditValueChanged(object sender, EventArgs e)
        {
            StockId = Convert.ToInt32(luStockId.EditValue.ToString());
        }
    }
}