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
//-----------------------------------------------------------员工管理模块编辑-（frmPersonManageEdit）-------------------------------------------------------------
//--------------------------------------------------------------------------------------------------------------------------------------------------------------
//--------------------------------------------------------------------------------------------------------------------------------------------------------------

namespace JewSaleSystem
{
    public partial class frmPersonManageEdit : DevExpress.XtraEditors.XtraForm
    {
        private bool blInit = false;
        private DataTable dtEmployee = null;
        private string strKeyId = "EmpId";

        public frmPersonManageEdit()
        {

            InitializeComponent();
        }
        readonly SQLHelper sqlhelper = new SQLHelper();

        private void frmPersonManageEdit_Load(object sender, EventArgs e)
        {

            DxCtlHelper.SetControlEnabledNew(groupBox2, false);
            //下拉绑定
            Combox(luEmpSex, "Base_SexType");
            Combox(luEmpRole, "RoleId");

            ReplaceCombox(ReluEmpRole, "RoleId");
            ReplaceCombox(ReluEmpSex, "Base_SexType"); 

            List<string> arr = new List<string>();
            foreach (Control ctrl in groupBox2.Controls)
            {
                if (Convert.ToString(ctrl.Tag) == string.Empty)
                    continue;
                arr.Add(ctrl.Tag.ToString());
            }
            ///加载初始数据内容
            loadDataMaster(GlobalUserInfo.Key_Id);
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
        /// <summary>下拉函数
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
        /// <summary>加载初始数据内容
        /// 
        /// </summary>
        /// <param name="Key_Id"></param>
        private void loadDataMaster(int Key_Id)
        {
            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id) ,
                    new SqlParameter("@flag", 1),
                     new SqlParameter("@Key_Id", Key_Id) 
                };
           dtEmployee = sqlhelper.ExecuteQueryTable("sys_Base_Employee_Add_Edit_Del", paras, CommandType.StoredProcedure);
           blInit = true;
           gridControl1.DataSource = dtEmployee.DefaultView;//可能引发事件gridView1_FocusedRowChanged
          gridView1.BestFitColumns();
          blInit = false;         
          DxCtlHelper.SetControlBindings(groupBox2, dtEmployee.DefaultView);
          gridView1_FocusedRowChanged(null, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(-1, gridView1.FocusedRowHandle));
        }


        /// <summary>查看所有
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id) ,
                    new SqlParameter("@flag", 1) 
                };
            dtEmployee = sqlhelper.ExecuteQueryTable("sys_Base_Employee_Add_Edit_Del", paras, CommandType.StoredProcedure);
            blInit = true;
            gridControl1.DataSource = dtEmployee.DefaultView;//可能引发事件gridView1_FocusedRowChanged
            gridView1.BestFitColumns();
            blInit = false;
            gridView1_FocusedRowChanged(null, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(-1, gridView1.FocusedRowHandle));
        }
        /// <summary>新增
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            DataRow drNew = dtEmployee.NewRow();
            dtEmployee.Rows.Add(drNew);
            gridView1.MoveLast();
            DxCtlHelper.SetControlEnabledNew(groupBox2, true, "txEmpNo");
        }
        /// <summary>修改
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            DxCtlHelper.SetControlEnabledNew(groupBox2, true,"txEmpNo");
        }
        /// <summary>保存
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dtnew = null;
            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr == null)
                return;

            List<string> arr = DxCtlHelper.GetField(groupBox2);
            if (dr[strKeyId].ToString() == string.Empty)
            {
                string strField = string.Empty;
                string strValue = DxCtlHelper.GetAddValues(dr, arr, out strField);

                SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@flag", 3),
                    new SqlParameter("@StrFields", strField),
                    new SqlParameter("@StrFieldValues", strValue)
                };

                DataTable dt = sqlhelper.ExecuteQueryTable("sys_Base_Employee_Add_Edit_Del", paras, CommandType.StoredProcedure);
                dr[strKeyId] = dt.Rows[0][strKeyId];
                dtnew = dt;
            }
            else
            {
                string strUpdate = DxCtlHelper.GetUpdateValues(dtEmployee, dr, arr);
                SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@flag", 4),
                    new SqlParameter("@StrEditSql", strUpdate),
                    new SqlParameter("@Key_Id", dr[strKeyId].ToString())
                };
                DataTable dt = sqlhelper.ExecuteQueryTable("sys_Base_Employee_Add_Edit_Del", paras, CommandType.StoredProcedure);
                dtnew = dt;
            }
            dr.AcceptChanges();
            gridControl1.DataSource = dtnew.DefaultView;
            DxCtlHelper.SetControlBindings(groupBox2, dtnew.DefaultView);
            gridView1.BestFitColumns();
            DxCtlHelper.SetControlEnabledNew(groupBox2, false);
        }
        /// <summary>删除
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr == null)
            {
                MessageBox.Show("没有选中某行，无法删除！！");
                return;
            }

            if (dr[strKeyId].ToString() != string.Empty)
            {
                if (MessageBox.Show("确定要删除？", "JewSaleSystem", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    SqlParameter[] paras = new SqlParameter[]
                        { 
                        new SqlParameter("@Key_Id", dr[strKeyId].ToString()),
                        new SqlParameter("@flag",5) 
                        };
                    DataTable dt = sqlhelper.ExecuteQueryTable("sys_Base_Employee_Add_Edit_Del", paras, CommandType.StoredProcedure);
                    gridControl1.DataSource = dt.DefaultView;
                    gridView1.BestFitColumns();
                }
            }
            else
            {
                MessageBox.Show("记录未保存，不用删除！！");
            }
        }
        /// <summary>关闭
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>点击选中某行
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (blInit)
                return;
            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr == null)
                return;

            if (dr.RowState != DataRowState.Added)
            {
                dtEmployee.RejectChanges();
                DxCtlHelper.SetControlEnabledNew(groupBox2, false);
            }
            DxCtlHelper.SetControlBindings(groupBox2, dr.Table.DefaultView);
        }

    }
   
}