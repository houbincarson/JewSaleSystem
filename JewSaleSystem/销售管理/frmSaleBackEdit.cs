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
    public partial class frmSaleBackEdit : DevExpress.XtraEditors.XtraForm
    {
        public frmSaleBackEdit()
        {
            InitializeComponent();
        }
        private bool blInit = false;
        private bool blInitDtl = false;
        private DataTable dtSaleBack = null;
        private DataTable dtSaleBackDtl = null;
        private string strKeyId = "SaleBackId";
        private string strKeyDtlId = "SaleBackDtlId";
        private string Ord_Id = "";
        SQLHelper sqlhelper = new SQLHelper();

        List<string> arr1 = new List<string>();
        List<string> arr2 = new List<string>();
        private void frmSaleBackEdit_Load(object sender, EventArgs e)
        {

            DxCtlHelper.SetControlEnabledNew(groupBox2, false);
            DxCtlHelper.SetControlEnabledNew(groupBox3, false);
            ReplaceCombox(ReluState, "State");
            foreach (Control ctrl in groupBox2.Controls)
            {
                if (Convert.ToString(ctrl.Tag) == string.Empty)
                    continue;
                arr1.Add(ctrl.Tag.ToString());
            }

            foreach (Control ctrl in groupBox3.Controls)
            {
                if (Convert.ToString(ctrl.Tag) == string.Empty)
                    continue;
                arr2.Add(ctrl.Tag.ToString());
            }
            //加载主表数据
            LoadMaster(GlobalUserInfo.Key_Id);
            ////加载明细数据
            LoadDtl(GlobalUserInfo.Key_Id);
        }
        //-------------------------------------------------------------------------------------------------------------------------------
        /// <summary>ReplaceCombox下拉绑定函数
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
        /// <summary>加载主表信息
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
            dtSaleBack = sqlhelper.ExecuteQueryTable("Sys_H_ProdSaleBack_Add_Edit_Del", paras, CommandType.StoredProcedure);
            blInit = true;
            gridControl1.DataSource = dtSaleBack.DefaultView;//可能引发事件gridView1_FocusedRowChanged
            gridView1.BestFitColumns();
            blInit = false;
            DxCtlHelper.SetControlBindings(groupBox2, dtSaleBack.DefaultView);
            gridView1_FocusedRowChanged(null, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(-1, gridView1.FocusedRowHandle));
        }
        /// <summary>查看
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuery_Click(object sender, EventArgs e)
        {
            if (Ord_Id == "")
            {
                Ord_Id = GlobalUserInfo.Key_Id.ToString();
            }
            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                    new SqlParameter("@flag", 10),
                    new SqlParameter("@Key_Id", Ord_Id) 
                };
            dtSaleBack = sqlhelper.ExecuteQueryTable("Sys_H_ProdSaleBack_Add_Edit_Del", paras, CommandType.StoredProcedure);
            blInit = true;
            gridControl1.DataSource = dtSaleBack.DefaultView;//可能引发事件gridView1_FocusedRowChanged
            gridView1.BestFitColumns();
            blInit = false;
            gridView1_FocusedRowChanged(null, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(-1, gridView1.FocusedRowHandle));



            SqlParameter[] parasdtl = new SqlParameter[]
                { 
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                    new SqlParameter("@Key_Id",Ord_Id),
                    new SqlParameter("@flag", 2)
                };
            dtSaleBackDtl = sqlhelper.ExecuteQueryTable("Sys_H_ProdSaleBack_Add_Edit_Del", parasdtl, CommandType.StoredProcedure);
            blInitDtl = true;
            gridControl2.DataSource = dtSaleBackDtl.DefaultView;//可能引发事件gridView1_FocusedRowChanged
            gridView2.BestFitColumns();
            blInitDtl = false;
            gridView2_FocusedRowChanged(null, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(-1, gridView2.FocusedRowHandle));
        }
        /// <summary>主表单击选中
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
                dtSaleBack.RejectChanges();
                DxCtlHelper.SetControlEnabledNew(groupBox2, false);
            }
            DxCtlHelper.SetControlBindings(groupBox2, dr.Table.DefaultView);
        }      
        /// <summary>主表新增
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow drNew = dtSaleBack.NewRow();
            dtSaleBack.Rows.Add(drNew);
            gridView1.MoveLast();
            //控制部分面板可见
            DxCtlHelper.SetControlEnabledNew(groupBox2, true, "txSaleBackCode,txQty,txWgt,txSalePrice,txBackPrice");
            //清空面板上所有值
            DxCtlHelper.SetControlEmpty(groupBox2);
        }
        /// <summary>主表保存
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
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

                DataTable dt = sqlhelper.ExecuteQueryTable("Sys_H_ProdSaleBack_Add_Edit_Del", paras, CommandType.StoredProcedure);
                dtnew = dt;
                dr[strKeyId] = dt.Rows[0][strKeyId];
            }
            else
            {
                string strUpdate = DxCtlHelper.GetUpdateValues(dtSaleBack, dr, arr);
                SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                    new SqlParameter("@flag", 4),
                    new SqlParameter("@StrEditSql", strUpdate),
                    new SqlParameter("@Key_Id", dr[strKeyId].ToString())
                };
                DataTable dt = sqlhelper.ExecuteQueryTable("Sys_H_ProdSaleBack_Add_Edit_Del", paras, CommandType.StoredProcedure);
                dtnew = dt;
            }
            dr.AcceptChanges();
            gridControl1.DataSource = dtnew.DefaultView;
            DxCtlHelper.SetControlBindings(groupBox2, dtnew.DefaultView);
            Ord_Id = dr[strKeyId].ToString();
            gridView1.BestFitColumns();
            DxCtlHelper.SetControlEnabledNew(groupBox2, false);
        }
        /// <summary>主表修改
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            DxCtlHelper.SetControlEnabledNew(groupBox2, true, "txSaleBackCode,txQty,txWgt,txSalePrice,txBackPrice");
        }
        /// <summary>主表删除
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelt_Click(object sender, EventArgs e)
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
                        new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                        new SqlParameter("@Key_Id", dr[strKeyId].ToString()),
                        new SqlParameter("@flag",5) 
                        };
                    DataTable dt = sqlhelper.ExecuteQueryTable("Sys_H_ProdSaleBack_Add_Edit_Del", paras, CommandType.StoredProcedure);
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
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>加载明细数据
        /// 
        /// </summary>
        private void LoadDtl(int Key_Id)
        {
            if (Ord_Id == "")
            {
                SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                    new SqlParameter("@flag", 2),
                    new SqlParameter("@Key_Id", Key_Id) 
                };
                dtSaleBackDtl = sqlhelper.ExecuteQueryTable("Sys_H_ProdSaleBack_Add_Edit_Del", paras, CommandType.StoredProcedure);
                blInitDtl = true;
                gridControl2.DataSource = dtSaleBackDtl.DefaultView;
                gridView2.BestFitColumns();
                blInitDtl = false;
                DxCtlHelper.SetControlBindings(groupBox3, dtSaleBackDtl.DefaultView);
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
                dtSaleBackDtl = sqlhelper.ExecuteQueryTable("Sys_H_ProdSaleBack_Add_Edit_Del", paras, CommandType.StoredProcedure);
                blInitDtl = true;
                gridControl2.DataSource = dtSaleBackDtl.DefaultView;//可能引发事件gridView2_FocusedRowChanged
                gridView2.BestFitColumns();
                blInitDtl = false;
                DxCtlHelper.SetControlBindings(groupBox3, dtSaleBackDtl.DefaultView);
                gridView2_FocusedRowChanged(null, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(-1, gridView2.FocusedRowHandle));
            }
        }
        /// <summary>明细单击选中
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView2_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            if (blInitDtl)
                return;
            DataRow dr = gridView2.GetFocusedDataRow();
            if (dr == null)
                return;
            if (dr.RowState != DataRowState.Added)
            {
                dtSaleBackDtl.RejectChanges();
                DxCtlHelper.SetControlEnabledNew(groupBox3, false);
            }
            DxCtlHelper.SetControlBindings(groupBox3, dr.Table.DefaultView);
        }
        /// <summary>明细新增
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddInfo_Click(object sender, EventArgs e)
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
                DataRow drNew = dtSaleBackDtl.NewRow();
                dtSaleBackDtl.Rows.Add(drNew);
                gridView2.MoveLast();
                DxCtlHelper.SetControlEnabledNew(groupBox3, true, "texProdName,texQty,texWgt,texSalePrice,texBackPrice");
                //清空面板上所有值
                DxCtlHelper.SetControlEmpty(groupBox3);
            }
        }
        /// <summary>修改明细
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            DxCtlHelper.SetControlEnabledNew(groupBox3, true, "texProdName,texQty,texWgt,texSalePrice,texBackPrice");
        }
        /// <summary>保存明细
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            DataTable dtnew = null;
            if (texBarcode.Text == "")
            {
                MessageBox.Show("没有录入条码！，不可保存！");
                return;
            }
            DataRow dr = gridView2.GetFocusedDataRow();

            if (dr == null)
                return;
            List<string> arr = DxCtlHelper.GetField(groupBox3);
            if (dr[strKeyDtlId].ToString() == string.Empty)
            {
                string strField = string.Empty;
                string strValue = DxCtlHelper.GetAddValues(dr, arr, out strField);

                SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                    new SqlParameter("@flag", 31),
                    new SqlParameter("@StrFields", strField),
                    new SqlParameter("@StrFieldValues", strValue),
                    new SqlParameter("@Ord_Id", Ord_Id)
                };
                DataTable dt = sqlhelper.ExecuteQueryTable("Sys_H_ProdSaleBack_Add_Edit_Del", paras, CommandType.StoredProcedure);
                dtnew = dt;
                dr[strKeyDtlId] = dt.Rows[0][strKeyDtlId];
            }
            else
            {
                string strUpdate = DxCtlHelper.GetUpdateValues(dtSaleBackDtl, dr, arr);
                SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                    new SqlParameter("@flag", 32),
                    new SqlParameter("@StrEditSql", strUpdate),
                    new SqlParameter("@Key_Id", dr[strKeyDtlId].ToString())                  
                };
                DataTable dt = sqlhelper.ExecuteQueryTable("Sys_H_ProdSaleBack_Add_Edit_Del", paras, CommandType.StoredProcedure);
                dtnew = dt;
            }
            dr.AcceptChanges();
            gridControl2.DataSource = dtnew.DefaultView;
            DxCtlHelper.SetControlBindings(groupBox3, dtnew.DefaultView);
            gridView2.BestFitColumns();
            DxCtlHelper.SetControlEnabledNew(groupBox3, false);
        }
        /// <summary>审核
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (Ord_Id == "" && GlobalUserInfo.Key_Id < 0)
            {
                MessageBox.Show("没有保存表头,或者选中，不可审核！");
                return;
            }
            if (Ord_Id == string.Empty)
            {
                Ord_Id = GlobalUserInfo.Key_Id.ToString();
            }
            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                    new SqlParameter("@flag", 55),                    
                    new SqlParameter("@Ord_Id",Ord_Id)                 
                };
            DataSet ds = sqlhelper.ExecuteQuery("Sys_H_ProdSaleBack_Add_Edit_Del", paras, CommandType.StoredProcedure);

            if (ds.Tables[0].Rows.Count > 0 && ds.Tables[1].Rows.Count > 0)
            {
                MessageBox.Show("销售退货，系统入库成功！");
                gridControl1.DataSource = ds.Tables[0].DefaultView;
                gridControl2.DataSource = ds.Tables[1].DefaultView;
            }
        }
        /// <summary>撤销
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelInfo_Click(object sender, EventArgs e)
        {

        }
        /// <summary>回车检索
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void texBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SqlParameter[] paras = new SqlParameter[] { 
                     new SqlParameter("@Name", "SaleBackBarcode"),
                     new SqlParameter("@Code",  texBarcode.Text) };
                DataTable dtInfo = sqlhelper.ExecuteQueryTable("Sys_GetCodeInfo_Query", paras, CommandType.StoredProcedure);
                if (dtInfo.Rows.Count <= 0)
                {
                    MessageBox.Show("没有检索到信息");
                }
                else
                {
                    DataRow dr = gridView2.GetFocusedDataRow();
                    dr["Qty"] = dtInfo.Rows[0]["Qty"].ToString();
                    dr["Wgt"] = dtInfo.Rows[0]["Wgt"].ToString();                
                    dr["ProdName"] = dtInfo.Rows[0]["ProdName"].ToString();
                    dr["Barcode"] = dtInfo.Rows[0]["Barcode"].ToString();
                    dr["SalePrice"] = dtInfo.Rows[0]["SalePrice"].ToString();
                    DxCtlHelper.SetControlBindings(groupBox3, dr.Table.DefaultView);
                }
            }
        }
        /// <summary>页面激活时自动加载
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSaleBackEdit_Activated(object sender, EventArgs e)
        {
            //加载主表数据
            LoadMaster(GlobalUserInfo.Key_Id);
            //加载明细数据
            LoadDtl(GlobalUserInfo.Key_Id);
        }

        private void texChangeFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            string SalePrice ="0";
            string ChangeFee ="0";
            if(texSalePrice.Text== string.Empty)
            {
                SalePrice = "0";
            }
            else
            {
                SalePrice = texSalePrice.Text;
            }
             if(texChangeFee.Text== string.Empty)
            {
                ChangeFee = "0";
            }
            else
            {
                ChangeFee = texChangeFee.Text;
            }

            if (e.KeyChar == 13)
            {
                DataRow dr = gridView2.GetFocusedDataRow();
                dr["BackPrice"] = Convert.ToDecimal(SalePrice) - Convert.ToDecimal(ChangeFee);
                texBackPrice.Text = dr["BackPrice"].ToString();
                dr["ChangeFee"] = ChangeFee;
                DxCtlHelper.SetControlBindings(groupBox3, dr.Table.DefaultView);
            }
        }
        

    }
}