using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace JewSaleSystem
{
    public partial class frmInStockQuery : DevExpress.XtraEditors.XtraForm
    {
        public frmInStockQuery()
        {
            InitializeComponent();
        }

        private void frmInStockQuery_Load(object sender, EventArgs e)
        {
            Combox(luStockId, "StockId");
            this.reportViewer1.RefreshReport();
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
        SQLHelper sqlhelper = new SQLHelper();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlParameter[] paras = new SqlParameter[]
                {                
                    //new SqlParameter("@flag", 1),
                    new SqlParameter("@Stock", luStockId.EditValue),
                    new SqlParameter("@StDate", StDate.Text),
                    new SqlParameter("@EndDate", EndDate.Text)                  
                };

            DataSet ds = sqlhelper.ExecuteQuery("Sys_Rpt_ProdInStock_Query", paras, CommandType.StoredProcedure);
            bindingSource1.DataSource = ds.Tables[0].DefaultView;

            this.reportViewer1.RefreshReport();
        }
    }
}