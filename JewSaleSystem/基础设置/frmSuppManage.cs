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


namespace JewSaleSystem
{
    public partial class frmSuppManage : DevExpress.XtraEditors.XtraForm
    {
        public frmSuppManage()
        {
            InitializeComponent();
        }
        readonly SQLHelper sqlhelper = new SQLHelper();
        private string strKeyId = "SuppId";
        DataRow dr = null;
        DataTable dtEmployee = null;
        private void frmSuppManage_Load(object sender, EventArgs e)
        {
        }
      /// <summary>刷新
      /// 
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
        private void frmSuppManage_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                frmSuppManage_Load(null, null);
            }
        }
        /// <summary>查询
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id) ,
                    new SqlParameter("@flag", 1) 
                };
             dtEmployee = sqlhelper.ExecuteQueryTable("Sys_Base_SuppInfo_Add_Edit_Del", paras, CommandType.StoredProcedure);
            gridControl1.DataSource = dtEmployee.DefaultView;
            gridView1.BestFitColumns();
        }
        /// <summary>编辑
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Form frm=DxCtlHelper.OpenChildFromNew(this.MdiParent, "frmSuppManageEdit");
            frm.Text = "供应商编辑";
        }
        /// <summary>双击进入编辑页面
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {           
            GlobalUserInfo.Key_Id = Convert.ToInt32(dr[strKeyId].ToString());
            Form frm = DxCtlHelper.OpenChildFromNew(this.MdiParent, "frmSuppManageEdit");
            frm.Text = "供应商编辑";         
            
        }
        /// <summary>单击选中某行
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
             dr = gridView1.GetFocusedDataRow();
        }
       
       
    }
}