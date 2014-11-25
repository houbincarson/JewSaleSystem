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
    public partial class frmRoleManageEdit : DevExpress.XtraEditors.XtraForm
    {
        public frmRoleManageEdit()
        {
            InitializeComponent();
        }
        SQLHelper sqlhelper = new SQLHelper();

        private void frmRoleManageEdit_Load(object sender, EventArgs e)
        {
            groupBox2.Visible = false;
            Combox(luRoleId, "RoleId");
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
        int RoleId = -1;
        /// <summary>下拉改变值
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void luRoleId_EditValueChanged(object sender, EventArgs e)
        {
            groupBox2.Visible = true;
            RoleId = Convert.ToInt32(luRoleId.EditValue.ToString());
            loadData(RoleId);
        }
        private void loadData(int RoleId)
        {
            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@flag", 2),
                    new SqlParameter("@RoleId",RoleId)
                };
            DataTable dt = sqlhelper.ExecuteQueryTable("Sys_RoleManage_Add_Edit_Del", paras, CommandType.StoredProcedure);
            if (dt == null)
                return;
            foreach (Control c in groupBox2.Controls)
            {
                if (!(c is CheckBox))
                {
                    continue;
                }
                CheckBox ckb = c as CheckBox;
                ckb.Checked = false;
                DataRow[] drExist = dt.Select("RDtlfrmName='" + Convert.ToString(c.Tag) + "'");
                if (drExist.Length > 0)
                {
                    ckb.Checked = true;
                }
            }
        }
        /// <summary>保存
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control c in groupBox2.Controls)
            {
                if (!(c is CheckBox))
                {
                    continue;
                }                
                CheckBox ckb = c as CheckBox;
                SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@flag", 3),
                    new SqlParameter("@RDtlfrmName", Convert.ToString(c.Tag)),
                    new SqlParameter("@RoleId",RoleId),
                    new SqlParameter("@IsAllow",ckb.Checked)
                };
                DataTable dt = sqlhelper.ExecuteQueryTable("Sys_RoleManage_Add_Edit_Del", paras, CommandType.StoredProcedure);               
            }
        }
        /// <summary>全选
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ckbSeleAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control c in groupBox2.Controls)
            {
                if (!(c is CheckBox))
                {
                    continue;
                }
                CheckBox ckb = c as CheckBox;
                ckb.Checked = ckbSeleAll.Checked;
            }
        }

    }
}