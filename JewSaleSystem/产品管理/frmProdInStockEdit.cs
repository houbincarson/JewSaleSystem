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
    public partial class frmProdInStockEdit : DevExpress.XtraEditors.XtraForm
    {
        public frmProdInStockEdit()
        {
            InitializeComponent();
        }
        private bool blInit = false;
        private bool blInitDtl = false;
        private DataTable dtInStock = null;
        private DataTable dtInStockDtl = null;
        private string strKeyId = "ProdInStockId";
        private string strKeyDtlId = "ProdInStockDtlId";
        private string Ord_Id = "";
        SQLHelper sqlhelper = new SQLHelper();

        List<string> arr1 = new List<string>();
        List<string> arr2 = new List<string>();
        /// <summary>页面加载内容
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmProdInStockEdit_Load(object sender, EventArgs e)
        {
            //groupbox2
            Combox(luStockId, "StockId");
            Combox(luProdNature, "ProdNature");
            Combox(luSuppName, "SuppName");
            //groupbox3
            Combox(DtluProdStyle, "ProdStyle");
            Combox(DtluProdNature, "ProdNature");
            Combox(DtluSuppName, "SuppName");
            //gridview1
            ReplaceCombox(ReluStockId, "StockId");
            ReplaceCombox(ReluProdNature, "ProdNature");
            ReplaceCombox(ReluSuppName, "SuppName");
            ReplaceCombox(ReluState, "State");
            //gridview2
            ReplaceCombox(ReluDtProdNature, "ProdNature");
            ReplaceCombox(ReluDtSuppName, "SuppName");
            ReplaceCombox(ReluDtProdStyle, "ProdStyle");

            DxCtlHelper.SetControlEnabledNew(groupBox2, false);
            DxCtlHelper.SetControlEnabledNew(groupBox3, false);

            
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
            //加载明细数据
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
        //-------------------------------------------------------------------------------------------------------------------------------
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
            dtInStock = sqlhelper.ExecuteQueryTable("Sys_H_ProdInStock_Add_Edit_Del", paras, CommandType.StoredProcedure);
            blInit = true;
            gridControl1.DataSource = dtInStock.DefaultView;//可能引发事件gridView1_FocusedRowChanged
            gridView1.BestFitColumns();
            blInit = false;
            DxCtlHelper.SetControlBindings(groupBox2, dtInStock.DefaultView);
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
            dtInStock = sqlhelper.ExecuteQueryTable("Sys_H_ProdInStock_Add_Edit_Del", paras, CommandType.StoredProcedure);
            blInit = true;         
            gridControl1.DataSource = dtInStock.DefaultView;//可能引发事件gridView1_FocusedRowChanged
            gridView1.BestFitColumns(); 
            blInit = false;
            gridView1_FocusedRowChanged(null, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(-1, gridView1.FocusedRowHandle));



            SqlParameter[] parasdtl = new SqlParameter[]
                {  
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                    new SqlParameter("@Key_Id",Ord_Id),
                    new SqlParameter("@flag", 2)
                };
            dtInStockDtl = sqlhelper.ExecuteQueryTable("Sys_H_ProdInStock_Add_Edit_Del", parasdtl, CommandType.StoredProcedure);
            blInitDtl = true;
            gridControl2.DataSource = dtInStockDtl.DefaultView;//可能引发事件gridView1_FocusedRowChanged
            gridView2.BestFitColumns();
            blInitDtl = false;

            gridView2_FocusedRowChanged(null, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(-1, gridView2.FocusedRowHandle));
        }
        /// <summary>新增
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow drNew = dtInStock.NewRow();
            dtInStock.Rows.Add(drNew);
            gridView1.MoveLast();
            //控制部分面板可见
            DxCtlHelper.SetControlEnabledNew(groupBox2, true, "txProdInStockCode,txQty,txWgt,txSCostPrice");
            //清空面板上所有值
            DxCtlHelper.SetControlEmpty(groupBox2);
        }
        /// <summary>修改
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            DxCtlHelper.SetControlEnabledNew(groupBox2, true);
        }
        /// <summary>保存
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

                DataTable dt = sqlhelper.ExecuteQueryTable("Sys_H_ProdInStock_Add_Edit_Del", paras, CommandType.StoredProcedure);
                dtnew = dt;
                dr[strKeyId] = dt.Rows[0][strKeyId];               
            }
            else
            {
                string strUpdate = DxCtlHelper.GetUpdateValues(dtInStock, dr, arr);
                SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                    new SqlParameter("@flag", 4),
                    new SqlParameter("@StrEditSql", strUpdate),
                    new SqlParameter("@Key_Id", dr[strKeyId].ToString())
                };
                DataTable dt = sqlhelper.ExecuteQueryTable("Sys_H_ProdInStock_Add_Edit_Del", paras, CommandType.StoredProcedure);
                dtnew = dt;
            }
            dr.AcceptChanges();
            Ord_Id = dr[strKeyId].ToString();
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
                    DataTable dt = sqlhelper.ExecuteQueryTable("Sys_H_ProdInStock_Add_Edit_Del", paras, CommandType.StoredProcedure);
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
        /// <summary>主表单击选中某行
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
                dtInStock.RejectChanges();
                DxCtlHelper.SetControlEnabledNew(groupBox2, false);
            }
            DxCtlHelper.SetControlBindings(groupBox2, dr.Table.DefaultView);
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
                dtInStockDtl = sqlhelper.ExecuteQueryTable("Sys_H_ProdInStock_Add_Edit_Del", paras, CommandType.StoredProcedure);
                blInitDtl = true;
                gridControl2.DataSource = dtInStockDtl.DefaultView;
                gridView2.BestFitColumns();
                blInitDtl = false;
                DxCtlHelper.SetControlBindings(groupBox3, dtInStockDtl.DefaultView);
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
                dtInStockDtl = sqlhelper.ExecuteQueryTable("Sys_H_ProdInStock_Add_Edit_Del", paras, CommandType.StoredProcedure);
                blInitDtl = true;
                gridControl2.DataSource = dtInStockDtl.DefaultView;//可能引发事件gridView2_FocusedRowChanged
                gridView2.BestFitColumns();
                blInitDtl = false;
                DxCtlHelper.SetControlBindings(groupBox3, dtInStockDtl.DefaultView);
                gridView2_FocusedRowChanged(null, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(-1, gridView2.FocusedRowHandle));
            }
        }
        /// <summary>明细新增
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddInfo_Click(object sender, EventArgs e)
        {
            if (Ord_Id == ""&&GlobalUserInfo.Key_Id<0)
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
                DataRow drNew = dtInStockDtl.NewRow();
                dtInStockDtl.Rows.Add(drNew);
                gridView2.MoveLast();
                DxCtlHelper.SetControlEnabledNew(groupBox3, true, "texBarcode,texProdName,texCostPrice,texSalePrice,DtluProdNature,DtluProdStyle,DtluSuppName");
                //清空面板上所有值
                DxCtlHelper.SetControlEmpty(groupBox3);        
                
            }
        }
       /// <summary>明细选择中行
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
                dtInStockDtl.RejectChanges();
                DxCtlHelper.SetControlEnabledNew(groupBox3, false);
            }
            DxCtlHelper.SetControlBindings(groupBox3, dr.Table.DefaultView);
        }        
        /// <summary>明细保存
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            if(texCostPrice.Text==""&&texSalePrice.Text =="")
            {
                MessageBox.Show("没有算价，不可以保存");
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
                DataTable dt = sqlhelper.ExecuteQueryTable("Sys_H_ProdInStock_Add_Edit_Del", paras, CommandType.StoredProcedure);
                dr[strKeyDtlId] = dt.Rows[0][strKeyDtlId];
            }
            else
            {
                string strUpdate = DxCtlHelper.GetUpdateValues(dtInStockDtl, dr, arr);
                SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                    new SqlParameter("@flag", 32),
                    new SqlParameter("@StrEditSql", strUpdate),
                    new SqlParameter("@Key_Id", dr[strKeyDtlId].ToString())                  
                };
                DataTable dt = sqlhelper.ExecuteQueryTable("Sys_H_ProdInStock_Add_Edit_Del", paras, CommandType.StoredProcedure);
            }
            dr.AcceptChanges();
            gridView2.BestFitColumns();
            DxCtlHelper.SetControlEnabledNew(groupBox3, false);
        }
        /// <summary>明细修改
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditInfo_Click(object sender, EventArgs e)
        {
            DxCtlHelper.SetControlEnabledNew(groupBox3, true);
        }
        /// <summary>审核入库
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (Ord_Id==""&&GlobalUserInfo.Key_Id<0)
            {
                MessageBox.Show("没有保存表头,或者选中，不可审核！");
                return;
            }

            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                    new SqlParameter("@flag", 55),                    
                    new SqlParameter("@Ord_Id",Ord_Id)                 
                };
            DataSet ds = sqlhelper.ExecuteQuery("Sys_H_ProdInStock_Add_Edit_Del", paras, CommandType.StoredProcedure);
    
            if (ds.Tables[0].Rows.Count > 0&&ds.Tables[1].Rows.Count>0)
            {
                MessageBox.Show("入库成功！");
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
        /// <summary>算价
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCount_Click(object sender, EventArgs e)
        {
            if (texGoldPrice.Text == "")
            {
                MessageBox.Show("金价不能为空！");
                return;
            }
            texCostPrice.Text = Convert.ToString(Convert.ToDecimal(texWgt.Text) * (Convert.ToDecimal(texProcessCost.Text)+ Convert.ToDecimal(texGoldPrice.Text)));
            texSalePrice.Text = Convert.ToString(Convert.ToDecimal(texWgt.Text) * (Convert.ToDecimal(texProcessSale.Text)+ Convert.ToDecimal(texGoldPrice.Text)));
        }
        /// <summary>当编辑页面处于激活状态时，加载页面数据！
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmProdInStockEdit_Activated(object sender, EventArgs e)
        {
            //加载明细数据
            LoadDtl(GlobalUserInfo.Key_Id);
            //加载主表数据
            LoadMaster(GlobalUserInfo.Key_Id); 
        }
        /// <summary>回车检索事件
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void texStyleCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SqlParameter[] paras = new SqlParameter[] 
                { 
                    new SqlParameter("@Name", "StyleCode"),
                    new SqlParameter("@Code", texStyleCode.Text)
                };
                DataTable dtInfo = sqlhelper.ExecuteQueryTable("Sys_GetCodeInfo_Query", paras, CommandType.StoredProcedure);
                if (dtInfo.Rows.Count <= 0)
                {
                    MessageBox.Show("没有检索到信息");
                    return;
                }
                else
                {
                    DtluProdNature.EditValue = dtInfo.Rows[0]["ProdNature"].ToString();
                    DtluProdStyle.EditValue  = dtInfo.Rows[0]["ProdStyle"].ToString();
                    DtluSuppName.EditValue   = dtInfo.Rows[0]["SuppName"];
                    texProdName.Text         = dtInfo.Rows[0]["StyleName"].ToString();
                   
                }
            }
        }

     


    }
}