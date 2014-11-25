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
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        //登录按钮
        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (txtUserName.Text.Trim() == string.Empty)
            {
                MessageBox.Show("账号不能为空！");
                txtUserName.Focus();
                return;
            }
            if (txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("密码不能为空！");
                txtPassword.Focus();
                return;
            }
            SQLHelper sqlhelper = new SQLHelper();
            SqlParameter[] paras = new SqlParameter[]{
             new SqlParameter("@flag",1),
             new SqlParameter("@UserNumber",txtUserName.Text.Trim()),
             new SqlParameter("@UserPassword",txtPassword.Text.Trim())
            };
            DataTable dt = sqlhelper.ExecuteQueryTable("Sys_UserLogin_Check", paras, CommandType.StoredProcedure);
            
          

            if (dt.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
                //获得当前登录用户User_Id和用户的姓名
                GlobalUserInfo.loginuser_Id = dt.Rows[0]["UserId"].ToString();
                GlobalUserInfo.user_Name = dt.Rows[0]["Name"].ToString();
            }
            else
            {
                MessageBox.Show(" 登录失败！密码错误或者账号不存在！");
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnLogin_Click(null, null);
            }
        }

     
    }
}