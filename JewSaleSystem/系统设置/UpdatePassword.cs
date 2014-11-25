using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace JewSaleSystem
{
    public partial class UpdatePassword : DevExpress.XtraEditors.XtraForm
    {
        public UpdatePassword()
        {
            InitializeComponent();
        }
        readonly SQLHelper sqlhelper = new SQLHelper();
        //修改密码保存按钮
        private void simpleButton1_Click(object sender, EventArgs e)
        {

            SqlParameter[] Oldparas = new SqlParameter[]{
             new SqlParameter("@flag",2),
             new SqlParameter("@UserId",Convert.ToInt32(GlobalUserInfo.loginuser_Id))
            };
            DataTable Olddt = sqlhelper.ExecuteQueryTable("Sys_UserLogin_Check", Oldparas, CommandType.StoredProcedure);
            string OldPassword = Olddt.Rows[0]["Password"].ToString();

            if (textEdit1.Text.Trim() != OldPassword)
            {
                MessageBox.Show("原密码错误！请重新输入");
                textEdit1.Text = null;
                textEdit1.Focus();
                return;
            }
            if (textEdit2.Text.Trim() == string.Empty)
            {
                MessageBox.Show("新密码不能为空！");
                textEdit1.Focus();
                return;
            }
            if (textEdit3.Text.Trim() != textEdit2.Text.Trim())
            {
                MessageBox.Show("新密码和第二次输入密码不相等！");
                textEdit2.Focus();
                return;
            }
            
            SqlParameter[] Newparas = new SqlParameter[]{
             new SqlParameter("@flag",3),
             new SqlParameter("@UserId",Convert.ToInt32(GlobalUserInfo.loginuser_Id)),
             new SqlParameter("@UserPassword",textEdit3.Text.Trim())
            };
            DataTable Newdt = sqlhelper.ExecuteQueryTable("Sys_UserLogin_Check", Newparas, CommandType.StoredProcedure);
            string NewPassword = Newdt.Rows[0]["Password"].ToString();
            if (textEdit3.Text.Trim() == NewPassword)
            {
                MessageBox.Show("修改成功！");
                this.Close();
            }
            else
            {
                return;
            }
         
        }

        private void UpdatePassword_Load(object sender, EventArgs e)
        {
            textEdit1.Focus();

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            textEdit1.Text = null;
            textEdit2.Text = null;
            textEdit3.Text = null;
        }
      
     

      
    }
}