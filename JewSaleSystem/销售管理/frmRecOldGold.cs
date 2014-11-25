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
using DevExpress.XtraGrid.Controls;

namespace JewSaleSystem
{
    public partial class frmRecOldGold : DevExpress.XtraEditors.XtraForm
    {
        public frmRecOldGold()
        {
            InitializeComponent();
        }
        readonly SQLHelper sqlhelper = new SQLHelper();
        DataRow dr = null;
        string strKeyId = "RecId";
        string Key_Id = null;
        /// <summary>加载
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRecOldGold_Load(object sender, EventArgs e)
        {
            ReplaceCombox(ReluProdNature, "ProdNature");  
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
        /// <summary>查看
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
            DataTable dtProd = sqlhelper.ExecuteQueryTable("Sys_H_RecOldGold_Add_Edit_Del", paras, CommandType.StoredProcedure);
            gridControl1.DataSource = dtProd.DefaultView;
        }
        /// <summary>进入编辑页面
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = DxCtlHelper.OpenChildFromNew(this.MdiParent, "frmRecOldGoldEdit");
            frm.Text = "旧金回收编辑";
        }
        /// <summary>单击选中
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            dr = gridView1.GetFocusedDataRow();
            if (dr == null)
                return;
            else
            {
                Key_Id = dr[strKeyId].ToString();
            }  
        }
        /// <summary>双击进入
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GlobalUserInfo.Key_Id = Convert.ToInt32(Key_Id);
            Form frm = DxCtlHelper.OpenChildFromNew(this.MdiParent, "frmRecOldGoldEdit");
            frm.Text = "销售操作编辑";
        }
    }
}