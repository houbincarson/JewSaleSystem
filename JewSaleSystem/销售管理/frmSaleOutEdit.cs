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



namespace JewSaleSystem
{
    public partial class frmSaleOutEdit : DevExpress.XtraEditors.XtraForm
    {
        public frmSaleOutEdit()
        {
            InitializeComponent();
        }
        readonly SQLHelper sqlhelper = new SQLHelper();
     

        private bool blInit = false;
        private bool blInitDtl = false;
        private DataTable dtMaster = null;
        private DataTable dtDtl = null;
        private string strKeyId = "SaleId";
        private string strKeyDtlId = "SaleDtlId";
        private string Ord_Id = "";
        private string Key_Id = "";
        List<string> arr1 = new List<string>();
        private void frmSaleOutEdit_Load(object sender, EventArgs e)
        {

            //设置所有控件的可操作性
            DxCtlHelper.SetControlEnabledNew(groupBox2, false);
            foreach (Control ctrl in groupBox2.Controls)
            {
                if (Convert.ToString(ctrl.Tag) == string.Empty)
                    continue;
                arr1.Add(ctrl.Tag.ToString());
            }
            DxCtlHelper.SetControlEnabledNew(groupBox1, false);
            DxCtlHelper.SetControlEnabledNew(groupBox2, false);
            DxCtlHelper.SetControlEnabledNew(groupBox3, false);
            //加载数据
            LoadDtl(GlobalUserInfo.Key_Id);
            LoadMaster(GlobalUserInfo.Key_Id);
        }
        /// <summary>加载数据
        /// 
        /// </summary>
        /// <param name="Key_Id"></param>
        private void LoadDtl(int Key_Id)
        {
            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                    new SqlParameter("@flag", 2),
                    new SqlParameter("@Key_Id", Key_Id) 
                };
            dtDtl = sqlhelper.ExecuteQueryTable("Sys_H_ProdSale_Add_Edit_Del", paras, CommandType.StoredProcedure);
            gridControl1.DataSource = dtDtl.DefaultView;//可能引发事件gridView1_FocusedRowChanged
            gridView1.BestFitColumns();
            DxCtlHelper.SetControlBindings(groupBox2, dtDtl.DefaultView);
        }
        private void LoadMaster(int Key_Id)
        {
            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                    new SqlParameter("@flag", 10),
                    new SqlParameter("@Key_Id", Key_Id) 
                };
            dtMaster = sqlhelper.ExecuteQueryTable("Sys_H_ProdSale_Add_Edit_Del", paras, CommandType.StoredProcedure);
            DxCtlHelper.SetControlBindings(groupBox1, dtMaster.DefaultView);
            DxCtlHelper.SetControlBindings(groupBox3, dtMaster.DefaultView); 
        }
        /// <summary>新增添加
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            DataRow drNew = dtDtl.NewRow();
            dtDtl.Rows.Add(drNew);
            gridView1.MoveLast();
            //控制部分面板可见
            DxCtlHelper.SetControlEnabledNew(groupBox2, true, "txProdName,txQty,txWgt,txCostPrice");
            //清空面板上所有值
            DxCtlHelper.SetControlEmpty(groupBox2);
        }
        /// <summary>选中行
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr == null)
                return;
            if (dr.RowState != DataRowState.Added)
            {
                dtDtl.RejectChanges();
                DxCtlHelper.SetControlEnabledNew(groupBox2, false);
            }
            DxCtlHelper.SetControlBindings(groupBox2, dr.Table.DefaultView);
        }
        /// <summary>保存
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (Ord_Id == string.Empty)
            {
                Ord_Id = GlobalUserInfo.Key_Id.ToString(); 
            }
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
                    new SqlParameter("@flag", 31),
                    new SqlParameter("@StrFields", strField),
                    new SqlParameter("@StrFieldValues", strValue),
                    new SqlParameter("@Ord_Id", Convert.ToInt32(Ord_Id))
                };
                DataTable dt = sqlhelper.ExecuteQueryTable("Sys_H_ProdSale_Add_Edit_Del", paras, CommandType.StoredProcedure);
                dtnew = dt;
                //新销售单主键
                Key_Id = dt.Rows[0][strKeyId].ToString();
                
            }          
            dr.AcceptChanges();
            gridControl1.DataSource = dtnew.DefaultView;
            DxCtlHelper.SetControlBindings(groupBox2, dtnew.DefaultView);
            gridView1.BestFitColumns();
            DxCtlHelper.SetControlEnabledNew(groupBox2, false);
            MessageBox.Show("添加成功！");  
            //显示详细支付金额！
            ShowCash(Convert.ToInt32(Key_Id));
            DxCtlHelper.SetControlEnabledNew(groupBox1, true, "txSSalePrice,txChange");
            DxCtlHelper.SetControlEnabledNew(groupBox3, true);
        }
        private void ShowCash(int Key_Id )
        {
            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                    new SqlParameter("@flag", 10),
                    new SqlParameter("@Key_Id", Key_Id) 
                };
            DataTable dt = sqlhelper.ExecuteQueryTable("Sys_H_ProdSale_Add_Edit_Del", paras, CommandType.StoredProcedure);
            txSSalePrice.Text = dt.Rows[0]["SalePrice"].ToString();
        }
        /// <summary>回车检索条码信息
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>   
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                SqlParameter[] paras = new SqlParameter[] { 
                     new SqlParameter("@Name", "SaleBarcode"),
                     new SqlParameter("@Code",  txBarcode.Text) };
                DataTable dtInfo = sqlhelper.ExecuteQueryTable("Sys_GetCodeInfo_Query", paras, CommandType.StoredProcedure);
                if (dtInfo.Rows.Count <= 0)
                {
                    MessageBox.Show("没有检索到信息");
                }
                else
                {
                    DataRow dr = gridView1.GetFocusedDataRow();        
                    dr["Qty"] = dtInfo.Rows[0]["Qty"].ToString();
                    dr["Wgt"] = dtInfo.Rows[0]["Wgt"].ToString();
                    dr["CostPrice"] = dtInfo.Rows[0]["CostPrice"].ToString();
                    dr["ProdName"] = dtInfo.Rows[0]["ProdName"].ToString();
                    dr["Barcode"] = dtInfo.Rows[0]["Barcode"].ToString();
                    dr["GoldPrice"] = dtInfo.Rows[0]["GoldPrice"].ToString();
                    dr["ProcessSale"] = dtInfo.Rows[0]["ProcessSale"].ToString();
                    dr["SalePrice"] = dtInfo.Rows[0]["SalePrice"].ToString();
                    DxCtlHelper.SetControlBindings(groupBox2, dr.Table.DefaultView);
                }
            }
        }

        /// <summary>保存打印小票
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                    new SqlParameter("@flag", 32),
                    new SqlParameter("@SSalePrice",txSSalePrice.Text),
                    new SqlParameter("@Cash",   txCash.Text),
                    new SqlParameter("@Card",   txCard.Text),
                    new SqlParameter("@Change", txChange.Text),
                    new SqlParameter("@Ord_Id", Key_Id)                  
                };
            DataTable dt = sqlhelper.ExecuteQueryTable("Sys_H_ProdSale_Add_Edit_Del", paras, CommandType.StoredProcedure);
            string RowNumber = "Jew001" + dt.Rows[0]["SaleCode"].ToString();
            MessageBox.Show(RowNumber);
            //小票流水号
            //
            DxCtlHelper.SetControlEnabledNew(groupBox1, false);
            txSaleDate.EditValue = DateTime.Now.Date;           
        }
        /// <summary>取消添加
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        decimal Change = 0;
        decimal SSalePrice = 0;
        /// <summary>数值的动态变化
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txCash_TextChanged(object sender, EventArgs e)
        {
            if (txCash.Text == string.Empty || txCard.Text == string.Empty)
            {
                txCash.Text = "0.0";
                txCard.Text = "0.0"; 
            }
            string strSSalePrice = txSSalePrice.Text;
            SSalePrice = Convert.ToDecimal(strSSalePrice);
            Change = SSalePrice-Convert.ToDecimal(txCash.Text) - Convert.ToDecimal(txCard.Text)  ;
            txChange.Text = Change.ToString();
           

        }
        /// <summary>数值的动态变化
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txCard_TextChanged(object sender, EventArgs e)
        {
            if (txCash.Text == string.Empty || txCard.Text == string.Empty)
            {
                txCash.Text = "0.0";
                txCard.Text = "0.0";
            }
            string strSSalePrice = txSSalePrice.Text;
            SSalePrice = Convert.ToDecimal(strSSalePrice);
            Change = SSalePrice - Convert.ToDecimal(txCash.Text) - Convert.ToDecimal(txCard.Text);
            txChange.Text = Change.ToString();
           
        }
        /// <summary>销售确认
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@UserId", GlobalUserInfo.loginuser_Id),
                    new SqlParameter("@flag", 55),
                    new SqlParameter("@SaleName",txSaleName.Text),
                    new SqlParameter("@CashCode",  txCashCode.Text),                 
                    new SqlParameter("@TicketCode", txTicketCode.Text),
                    new SqlParameter("@Ord_Id", Key_Id)                  
                };
            DataTable dt = sqlhelper.ExecuteQueryTable("Sys_H_ProdSale_Add_Edit_Del", paras, CommandType.StoredProcedure);
           
            MessageBox.Show("销售完成！");
            DxCtlHelper.SetControlEnabledNew(groupBox1, false);
            DxCtlHelper.SetControlEnabledNew(groupBox2, false);
            DxCtlHelper.SetControlEnabledNew(groupBox3, false);
        }


     
       
     

        
    }
}