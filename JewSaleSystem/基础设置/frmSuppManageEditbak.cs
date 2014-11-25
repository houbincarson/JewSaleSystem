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
    public partial class frmSuppManageEditbak : DevExpress.XtraEditors.XtraForm
    {
        public frmSuppManageEditbak()
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
            SuppInfo.SuppName =     textBox1.Text;
            SuppInfo.SuppCity =     textBox2.Text;
            SuppInfo.SuppMaster =   textBox5.Text;
            SuppInfo.SuppTel =      textBox4.Text;
            SuppInfo.SuppAdd =      textBox3.Text;
            SuppInfo.Remark =       textBox6.Text;

            string bstr1 = "'" + SuppInfo.SuppName + "'";
            string bstr2 = "'" + SuppInfo.SuppCity + "'";
            string bstr3 = "'" + SuppInfo.SuppAdd + "'";
            string bstr4 = "'" + SuppInfo.SuppTel + "'";
            string bstr5 = "'" + SuppInfo.SuppMaster + "'";
            string bstr6 = "'" + SuppInfo.Remark + "'";


            string str1 = "SuppName =" + bstr1;
            string str2 = "SuppCity =" + bstr2;
            string str3 = "SuppAdd =" + bstr3;
            string str4 = "SuppTel =" + bstr4;
            string str5 = "SuppMaster =" + bstr5;
            string str6 = "Remark =" + bstr6;

            SuppInfo.StrFields = "SuppName" + "," + "SuppCity" + "," + "SuppAdd" + "," + "SuppTel" + "," + "SuppMaster" + "," + "Remark";
            SuppInfo.StrFieldValues = bstr1 + "," + bstr2 + "," + bstr3 + "," + bstr4 + ","
                        + bstr5 + "," + bstr6;

            SuppInfo.StrEditSql = str1 + "," + str2 + "," + str3 + "," + str4 + "," + str5 + "," + str6;


            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false; 
            MessageBox.Show("录入成功!");
            if (SuppInfo.flag == 3)
            {
                    SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@flag", SuppInfo.flag),
                    new SqlParameter("@StrFields", SuppInfo.StrFields),
                    new SqlParameter("@StrFieldValues", SuppInfo.StrFieldValues)
                };
                    DataTable dt = sqlhelper.ExecuteQueryTable("Sys_Base_SuppInfo_Add_Edit_Del", paras, CommandType.StoredProcedure);
                    gridControl1.DataSource = dt.DefaultView;
            }
            if (SuppInfo.flag == 4 && SuppInfo.Key_Id != 0) 
            {
                SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@flag", SuppInfo.flag),
                    new SqlParameter("@StrEditSql", SuppInfo.StrEditSql),
                    new SqlParameter("@Key_Id", SuppInfo.Key_Id)
                };
                DataTable dt = sqlhelper.ExecuteQueryTable("Sys_Base_SuppInfo_Add_Edit_Del", paras, CommandType.StoredProcedure);
                gridControl1.DataSource = dt.DefaultView;
            }
                
                gridView1.BestFitColumns();
            
        }
        private void frmSuppManageEdit_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false; 
        }
        /// <summary>创建
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            button3.Text = "继续创建";
            SuppInfo.flag = 3;
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
            DataTable dtEmployee = sqlhelper.ExecuteQueryTable("Sys_Base_SuppInfo_Add_Edit_Del", paras, CommandType.StoredProcedure);
            gridControl1.DataSource = dtEmployee.DefaultView;
            gridView1.BestFitColumns();
        }
        /// <summary>修改
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            if (SuppInfo.Key_Id == 0)
            {
                MessageBox.Show("丢失焦点，没有选中！");
                return;
            }
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            SuppInfo.flag = 4;
        }
        /// <summary>单击选中某行
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectClick(object sender, EventArgs e)
        {
            int[] a = this.gridView1.GetSelectedRows(); //传递实体类过去 获取选中的行
            if (a[0] >= 0)
            {
                string SuppId = gridView1.GetRowCellValue(a[0], "SuppId").ToString();
                textBox1.Text = gridView1.GetRowCellValue(a[0], "SuppName").ToString();
                textBox2.Text = gridView1.GetRowCellValue(a[0], "SuppCity").ToString();
                textBox5.Text = gridView1.GetRowCellValue(a[0], "SuppMaster").ToString();
                textBox4.Text = gridView1.GetRowCellValue(a[0], "SuppTel").ToString();
                textBox3.Text = gridView1.GetRowCellValue(a[0], "SuppAdd").ToString();
                textBox6.Text = gridView1.GetRowCellValue(a[0], "Remark").ToString();
                SuppInfo.Key_Id = Convert.ToInt32(SuppId);
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
        /// <summary>删除
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            if (SuppInfo.Key_Id > 0)
            {
                if (MessageBox.Show("确定要删除？", "JewSaleSystem", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    SqlParameter[] paras = new SqlParameter[]
                        { 
                        new SqlParameter("@Key_Id", SuppInfo.Key_Id),
                        new SqlParameter("@flag",5) 
                        };
                    DataTable dt = sqlhelper.ExecuteQueryTable("Sys_Base_SuppInfo_Add_Edit_Del", paras, CommandType.StoredProcedure);
                    gridControl1.DataSource = dt.DefaultView;
                    gridView1.BestFitColumns();
                }
                else
                {
                    MessageBox.Show("没有选中某行，无法删除！！");
                }
            }
        }
    }
}