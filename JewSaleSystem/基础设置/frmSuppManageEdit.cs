﻿using System;
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
    public partial class frmSuppManageEdit : DevExpress.XtraEditors.XtraForm
    {
        private bool blInit = false;
        private DataTable dtSupp = null;
        private string strKeyId = "SuppId";
        public int IntKey_Id = -1;
        public frmSuppManageEdit()
        {
            InitializeComponent();
        }
        SQLHelper sqlhelper = new SQLHelper();
        /// <summary>保存
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
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

                DataTable dt = sqlhelper.ExecuteQueryTable("Sys_Base_SuppInfo_Add_Edit_Del", paras, CommandType.StoredProcedure);
                dr[strKeyId] = dt.Rows[0][strKeyId];
            }
            else
            {
                string strUpdate = DxCtlHelper.GetUpdateValues(dtSupp, dr, arr);
                SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@flag", 4),
                    new SqlParameter("@StrEditSql", strUpdate),
                    new SqlParameter("@Key_Id", dr[strKeyId].ToString())
                };
                DataTable dt = sqlhelper.ExecuteQueryTable("Sys_Base_SuppInfo_Add_Edit_Del", paras, CommandType.StoredProcedure);
            }
            dr.AcceptChanges();
            gridView1.BestFitColumns();
            IntKey_Id = Convert.ToInt32(dr[strKeyId].ToString());//记录主键
            DxCtlHelper.SetControlEnabledNew(groupBox2, false);
        }
        private void frmSuppManageEdit_Load(object sender, EventArgs e)
        {
            DxCtlHelper.SetControlEnabledNew(groupBox2, false);
            ///加载初始数据内容
            loadDataMaster(GlobalUserInfo.Key_Id);
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
            dtSupp = sqlhelper.ExecuteQueryTable("Sys_Base_SuppInfo_Add_Edit_Del", paras, CommandType.StoredProcedure);
            //blInit = true;
            gridControl1.DataSource = dtSupp.DefaultView;//可能引发事件gridView1_FocusedRowChanged
            gridView1.BestFitColumns();
            DxCtlHelper.SetControlBindings(groupBox2, dtSupp.DefaultView);
            //blInit = false;
            //gridView1_FocusedRowChanged(null, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(-1, gridView1.FocusedRowHandle));
        }
        /// <summary>创建
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            DataRow drNew = dtSupp.NewRow();
            dtSupp.Rows.Add(drNew);
            gridView1.MoveLast();

            DxCtlHelper.SetControlEnabledNew(groupBox2, true);
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
                    new SqlParameter("@flag", 1),
                    new SqlParameter("@Key_Id", IntKey_Id)
                };
            dtSupp = sqlhelper.ExecuteQueryTable("Sys_Base_SuppInfo_Add_Edit_Del", paras, CommandType.StoredProcedure);
            blInit = true;
            gridControl1.DataSource = dtSupp.DefaultView;//可能引发事件gridView1_FocusedRowChanged
            gridView1.BestFitColumns();
            blInit = false;
            gridView1_FocusedRowChanged(null, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(-1, gridView1.FocusedRowHandle));
        }
        /// <summary>修改
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            DxCtlHelper.SetControlEnabledNew(groupBox2, true);
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
                    DataTable dt = sqlhelper.ExecuteQueryTable("Sys_Base_SuppInfo_Add_Edit_Del", paras, CommandType.StoredProcedure);
                    gridControl1.DataSource = dt.DefaultView;
                    gridView1.BestFitColumns();
                }
            }
            else
            {
                MessageBox.Show("记录未保存，不用删除！！");
            }
        }

        /// <summary>单击选中某行
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
                dtSupp.RejectChanges();
                DxCtlHelper.SetControlEnabledNew(groupBox2, false);
            }
            DxCtlHelper.SetControlBindings(groupBox2, dr.Table.DefaultView);
        }
        /// <summary>页面激活
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSuppManageEdit_Activated(object sender, EventArgs e)
        {
            loadDataMaster(GlobalUserInfo.Key_Id);
        }

        
    }
}