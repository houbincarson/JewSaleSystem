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
    public partial class frmProdStockQty : DevExpress.XtraEditors.XtraForm
    {
        //private bool blInit = false;
        //private DataTable dtProd = null;
        //private string strKeyId = "ProdId";
        public frmProdStockQty()
        {
            InitializeComponent();
        }
        SQLHelper sqlhelper = new SQLHelper();
        private void frmProdStockQty_Load(object sender, EventArgs e)
        {
            Combox(luSuppName, "SuppName");
            Combox(luProdStyle, "ProdStyle");
            Combox(luProdNature, "ProdNature");
            Combox(luStockId,     "StockId");


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
        int ProdNature = -1;
        int ProdSyle = -1;
        int SuppName = -1;

        /// <summary>查看库存
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
            DataTable dt = sqlhelper.ExecuteQueryTable("Sys_H_ProdInStockQty_Query", paras, CommandType.StoredProcedure);
            txCount.Text = dt.Rows[0]["Count"].ToString();
            button2_Click(null, null);
        }

        private void luStockId_EditValueChanged(object sender, EventArgs e)
        {
            StockId = Convert.ToInt32(luStockId.EditValue.ToString());
        }

        private void luProdNature_EditValueChanged(object sender, EventArgs e)
        {
            ProdNature = Convert.ToInt32(luProdNature.EditValue.ToString());
        }

        private void luProdStyle_EditValueChanged(object sender, EventArgs e)
        {
            ProdSyle = Convert.ToInt32(luProdStyle.EditValue.ToString());
        }

        private void luSuppName_EditValueChanged(object sender, EventArgs e)
        {
            SuppName = Convert.ToInt32(luSuppName.EditValue.ToString());
        }
        /// <summary>条件搜索
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            string Barcode = txBarcode.Text;
            string ProdName = txProdName.Text;
            if (txWgtMin.Text == "")
            {
                txWgtMin.Text = "0.00";
            }
            if (txWgtMax.Text == "")
            {
                txWgtMax.Text = "0.00";
            }
            if (txPriceMin.Text == "")
            {
                txPriceMin.Text = "0.00";
            }
            if (txPriceMax.Text == "")
            {
                txPriceMax.Text = "0.00";
            }
            decimal WgtMin = Convert.ToDecimal(txWgtMin.Text);
            decimal WgtMax = Convert.ToDecimal(txWgtMax.Text);
            decimal PriceMin = Convert.ToDecimal(txPriceMin.Text);
            decimal PriceMax = Convert.ToDecimal(txPriceMax.Text);
            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@flag", 2),
                    new SqlParameter("@StockId", StockId),
                     new SqlParameter("@Barcode",Barcode ),
                      new SqlParameter("@ProdName", ProdName),
                      new SqlParameter("@ProdNature", ProdNature),
                      new SqlParameter("@ProdSyle", ProdSyle),
                      new SqlParameter("@SuppName", SuppName),
                      new SqlParameter("@WgtMin",WgtMin ),
                      new SqlParameter("@WgtMax", WgtMax),
                      new SqlParameter("@PriceMin", PriceMin),
                      new SqlParameter("@PriceMax", PriceMax)                    
                };
            DataTable dt = sqlhelper.ExecuteQueryTable("Sys_H_ProdInStockQty_Query", paras, CommandType.StoredProcedure);
            gridControl1.DataSource = dt.DefaultView;
            gridView1.BestFitColumns();
        }
       
    }
}