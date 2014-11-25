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
    public partial class frmProductInfoEdit : DevExpress.XtraEditors.XtraForm
    {
        private bool blInit = false;
        private DataTable dtProd = null;
        private string strKeyId = "ProdId";
        public frmProductInfoEdit()
        {
            InitializeComponent();

        }
       readonly SQLHelper sqlhelper = new SQLHelper();
        
       
        private void frmProductInfoEdit_Load(object sender, EventArgs e)
        {
            DxCtlHelper.SetControlEnabledNew(groupBox2, false);
            //下拉绑定
            Combox(luSuppName, "SuppName");
            Combox(luProdStyle, "ProdNature");
            Combox(luProdNature, "ProdStyle");

            List<string> arr = new List<string>();
            foreach (Control ctrl in groupBox2.Controls)
            {
                if (Convert.ToString(ctrl.Tag) == string.Empty)
                    continue;
                arr.Add(ctrl.Tag.ToString());
            }            
        }

        //string strField = string.Empty;
        //string strValue = GetAddValues(gridVMain.GetFocusedDataRow(), arr, out strField);

        public static string GetAddValues(DataRow dr, List<string> strFileds, out string strField)
        {
            StringBuilder sbFileds = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();

            foreach (string strFiled in strFileds)
            {
                if (dr[strFiled] == DBNull.Value || dr[strFiled].ToString() == string.Empty
                    || dr[strFiled].ToString() == "-9999"
                   )
                    continue;

                sbFileds.Append("," + strFiled);
                sbValues.Append(",'" + dr[strFiled].ToString().Replace("'", "''") + "'");
            }
            if (sbValues.Length > 0)
            {
                strField = sbFileds.ToString().Remove(0, 1);
                return sbValues.ToString().Remove(0, 1);
            }
            strField = string.Empty;
            return string.Empty;
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
      
        /// <summary>创建
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
           
            if (dtProd == null)
            {
                button4_Click(null, null);
            }

            DataRow drNew = dtProd.NewRow();
            dtProd.Rows.Add(drNew);
            gridView1.MoveLast();
            DxCtlHelper.SetControlEnabledNew(groupBox2, true);
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
                    new SqlParameter("@strFields", strField),
                    new SqlParameter("@strFieldValues", strValue)
                };
                DataTable dt = sqlhelper.ExecuteQueryTable("Sys_H_JewProductInfo_Add_Edit_Del", paras, CommandType.StoredProcedure);
                dr[strKeyId] = dt.Rows[0][strKeyId];
            }
            else
            {
                string strUpdate = DxCtlHelper.GetUpdateValues(dtProd, dr, arr);
                SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@flag", 4),
                    new SqlParameter("@StrEditSql", strUpdate),
                    new SqlParameter("@Key_Id", dr[strKeyId].ToString())
                };
                DataTable dt = sqlhelper.ExecuteQueryTable("Sys_H_JewProductInfo_Add_Edit_Del", paras, CommandType.StoredProcedure);
            }
            dr.AcceptChanges();
            gridView1.BestFitColumns();
            DxCtlHelper.SetControlEnabledNew(groupBox2, false);          
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
                    new SqlParameter("@flag", 1)                    
                };
            dtProd = sqlhelper.ExecuteQueryTable("Sys_H_JewProductInfo_Add_Edit_Del", paras, CommandType.StoredProcedure);
            blInit = true;
            gridControl1.DataSource = dtProd.DefaultView;//可能引发事件gridView1_FocusedRowChanged
            gridView1.BestFitColumns();
            blInit = false;
            gridView1_FocusedRowChanged(null, new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs(-1, gridView1.FocusedRowHandle));
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (blInit)
                return;

            DataRow dr = gridView1.GetFocusedDataRow();
            if (dr == null)
                return;

            if (dr.RowState != DataRowState.Added)
            {
                dtProd.RejectChanges();
                DxCtlHelper.SetControlEnabledNew(groupBox2, false);
            }
            DxCtlHelper.SetControlBindings(groupBox2, dr.Table.DefaultView);
        }
        /// <summary>删除操作
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
                    DataTable dt = sqlhelper.ExecuteQueryTable("Sys_H_JewProductInfo_Add_Edit_Del", paras, CommandType.StoredProcedure);
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
    }
}