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
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Controls;


namespace JewSaleSystem
{
    public partial class frmProdCheckStockEdit : DevExpress.XtraEditors.XtraForm
    {
        public frmProdCheckStockEdit()
        {
            InitializeComponent();
        }

        DataTable dtMaster = null;
        DataTable dtDtl = null;
        private bool blInit = false;
        private bool blInitDtl = false;    
        private string strKeyId = "CheckId";
        private string strKeyDtlId = "CheckDtlId";
        private string Ord_Id = "";
        SQLHelper sqlhelper = new SQLHelper();

        List<string> arr1 = new List<string>();
        List<string> arr2 = new List<string>();
        /// <summary>加载
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmProdCheckStockEdit_Load(object sender, EventArgs e)
        {
            ReplaceCombox(ReluState, "CheckState");
            ReplaceCombox(DtlReluState, "CheckState");

            DxCtlHelper.SetControlEnabledNew(groupBox2, false);
            DxCtlHelper.SetControlEnabledNew(groupBox3, false);

            foreach (Control ctrl in groupBox2.Controls)
            {
                if (Convert.ToString(ctrl.Tag) == string.Empty)
                    continue;
                arr1.Add(ctrl.Tag.ToString());
            }

            LoadMaster(GlobalUserInfo.Key_Id);
            LoadDtl(GlobalUserInfo.Key_Id);
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
        /// <summary>加载数据
        /// 
        /// </summary>
        /// <param name="Key_Id"></param>
        private void LoadMaster(int Key_Id)
        {
            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                    new SqlParameter("@flag", 10),
                    new SqlParameter("@Key_Id", Key_Id) 
                };
            dtMaster = sqlhelper.ExecuteQueryTable("Sys_H_ProdCheckStock_Add_Edit_Del", paras, CommandType.StoredProcedure);
            blInit = true;
            gridControl1.DataSource = dtMaster.DefaultView;//可能引发事件gridView1_FocusedRowChanged
            gridView1.BestFitColumns();
            blInit = false;
            DxCtlHelper.SetControlBindings(groupBox2, dtMaster.DefaultView);
            gridView1_FocusedRowChanged(null, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(-1, gridView1.FocusedRowHandle));
            
        }
        /// <summary>加载明细数据
        /// 
        /// </summary>
        private void LoadDtl(int Key_Id)
        {
            if (Ord_Id == "")
            {
                Ord_Id = Key_Id.ToString();
                SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                    new SqlParameter("@flag", 2),
                    new SqlParameter("@Key_Id", Key_Id) 
                };
                dtDtl = sqlhelper.ExecuteQueryTable("Sys_H_ProdCheckStock_Add_Edit_Del", paras, CommandType.StoredProcedure);
                blInitDtl = true;
                gridControl2.DataSource = dtDtl.DefaultView;
                gridView2.BestFitColumns();
                blInitDtl = false;
                DxCtlHelper.SetControlBindings(groupBox3, dtDtl.DefaultView);
                gridView2_FocusedRowChanged(null, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(-1, gridView2.FocusedRowHandle));
            }
            else
            {
                SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                    new SqlParameter("@flag", 2),
                    new SqlParameter("@Key_Id", Convert.ToInt32(Ord_Id)) 
                };
                dtDtl = sqlhelper.ExecuteQueryTable("Sys_H_ProdCheckStock_Add_Edit_Del", paras, CommandType.StoredProcedure);
                blInitDtl = true;
                gridControl2.DataSource = dtDtl.DefaultView;//可能引发事件gridView2_FocusedRowChanged
                gridView2.BestFitColumns();
                blInitDtl = false;
                DxCtlHelper.SetControlBindings(groupBox3, dtDtl.DefaultView);
                gridView2_FocusedRowChanged(null, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(-1, gridView2.FocusedRowHandle));
            }
        }

        /// <summary>查看
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {

        }
        /// <summary>回车添加
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {     
                SqlParameter[] paras = new SqlParameter[]
                    { 
                        new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                        new SqlParameter("@flag", 31),
                        new SqlParameter("@Barcode",txBarcode.Text),
                        new SqlParameter("@Ord_Id", Ord_Id)
                    };
                dtDtl = sqlhelper.ExecuteQueryTable("Sys_H_ProdCheckStock_Add_Edit_Del", paras, CommandType.StoredProcedure);
                   gridControl2.DataSource = dtDtl.DefaultView;
                   gridView2.BestFitColumns();
               
            }
        }
        /// <summary>单击选中
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (blInit)
                return;
            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr == null)
                return;

            if (dr.RowState != DataRowState.Added)
            {
                dtMaster.RejectChanges();
                DxCtlHelper.SetControlEnabledNew(groupBox2, false);
            }
            DxCtlHelper.SetControlBindings(groupBox2, dr.Table.DefaultView);
        }
        /// <summary>单击选中明细
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView2_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (blInit)
                return;
            DataRow dr = gridView2.GetFocusedDataRow();
            if (dr == null)
                return;

            if (dr.RowState != DataRowState.Added)
            {
                dtDtl.RejectChanges();
                DxCtlHelper.SetControlEnabledNew(groupBox3, false);
            }
            DxCtlHelper.SetControlBindings(groupBox3, dr.Table.DefaultView);
        }
        /// <summary>激活时加载数据
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmProdCheckStockEdit_Activated(object sender, EventArgs e)
        {
            //加载主表数据
            LoadMaster(GlobalUserInfo.Key_Id);
            //加载明细数据
            LoadDtl(GlobalUserInfo.Key_Id);
        }
        /// <summary>创建
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            DataRow drNew = dtMaster.NewRow();
            dtMaster.Rows.Add(drNew);
            gridView1.MoveLast();
            //控制部分面板可见
            DxCtlHelper.SetControlEnabledNew(groupBox2, true, "txCheckCode,txQty,txWgt,txChkOverage,txChkDeficit,txChkNormal");
            //清空面板上所有值
            DxCtlHelper.SetControlEmpty(groupBox2);
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
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                    new SqlParameter("@flag", 3),
                    new SqlParameter("@StrFields", strField),
                    new SqlParameter("@StrFieldValues", strValue)
                };

                DataSet ds = sqlhelper.ExecuteQuery("Sys_H_ProdCheckStock_Add_Edit_Del", paras, CommandType.StoredProcedure);
                dtnew = ds.Tables[1];
                dr[strKeyId] = ds.Tables[1].Rows[0][strKeyId];
          
            }
            dr.AcceptChanges();
            gridControl1.DataSource = dtnew.DefaultView;
            DxCtlHelper.SetControlBindings(groupBox2, dtnew.DefaultView);
            Ord_Id = dr[strKeyId].ToString();
            gridView1.BestFitColumns();
            DxCtlHelper.SetControlEnabledNew(groupBox2, false);
        }
        /// <summary>开始盘点
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            if (Ord_Id == "" && GlobalUserInfo.Key_Id < 0)
            {
                MessageBox.Show("没有保存或者选中表头！");
                return;
            }
            else
            {
                if (Ord_Id == "")
                {
                    Ord_Id = GlobalUserInfo.Key_Id.ToString();
                }
                DataRow drNew = dtDtl.NewRow();
                dtDtl.Rows.Add(drNew);
                gridView2.MoveLast();
                //控制部分面板可见
                DxCtlHelper.SetControlEnabledNew(groupBox3, true);
                //清空面板上所有值
                DxCtlHelper.SetControlEmpty(groupBox3);
            }

        }
        /// <summary>完成盘点
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            DxCtlHelper.SetControlEnabledNew(groupBox2, false);
            SqlParameter[] paras = new SqlParameter[]
                    { 
                        new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                        new SqlParameter("@flag", 55),                        
                        new SqlParameter("@Ord_Id", Ord_Id)
                    };
            DataSet ds = sqlhelper.ExecuteQuery("Sys_H_ProdCheckStock_Add_Edit_Del", paras, CommandType.StoredProcedure);
            if (ds.Tables.Count < 2)
            {
                MessageBox.Show(ds.Tables[0].Rows[0].ToString());
            }
            gridControl1.DataSource = ds.Tables[0].DefaultView;
            gridControl2.DataSource = ds.Tables[1].DefaultView;
            gridView2.BestFitColumns();
            gridView1.BestFitColumns();

            string str = "本次盘点结果为，盘点正常为："+ds.Tables[2].Rows[0]["a"].ToString()+"件"+";盘点亏损为："+ds.Tables[3].Rows[0]["b"].ToString()+"件";
            MessageBox.Show(str);

        }
        /// <summary>显示未盘点
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {            
            SqlParameter[] paras = new SqlParameter[]
                    { 
                        new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                        new SqlParameter("@flag", 20),                        
                        new SqlParameter("@Key_Id", Ord_Id)
                    };
            DataSet ds = sqlhelper.ExecuteQuery("Sys_H_ProdCheckStock_Add_Edit_Del", paras, CommandType.StoredProcedure);
            gridControl2.DataSource = ds.Tables[0].DefaultView;
            gridView2.BestFitColumns();
        }
    }
}