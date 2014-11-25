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
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {           
            InitializeComponent();
        }
        readonly SQLHelper sqlhelper = new SQLHelper();
        private void MainForm_Load(object sender, EventArgs e)
        {
            //菜单权限显示，加载权限表显示，该用户的所有可操作模块和，各个模块下对应的功能.
            SqlParameter[] rights = new SqlParameter[]{
                new SqlParameter("@flag", 1 ),
             new SqlParameter("@UserId", Convert.ToInt32(GlobalUserInfo.loginuser_Id) )};
            DataTable dtRights = sqlhelper.ExecuteQueryTable("Sys_RoleManage_Add_Edit_Del", rights, CommandType.StoredProcedure);
            foreach (BarItem barItem in barManager1.Items)
            {
                barItem.Visibility = BarItemVisibility.Never;
            }
            for (int i = 0; i < dtRights.Rows.Count; i++)
            {
                string strBtnName = dtRights.Rows[i]["RDtlfrmName"].ToString();
                barManager1.Items[strBtnName].Visibility = BarItemVisibility.Always;
                string strSubName = dtRights.Rows[i]["RTypefrmName"].ToString();
                barManager1.Items[strSubName].Visibility = BarItemVisibility.Always;
            }
        
            
            SqlParameter[] paras = new SqlParameter[]{
             new SqlParameter("@flag", 1 )};
            using (DataTable dsInterface = sqlhelper.ExecuteQueryTable("Sys_InterfaceView_Add_Edit_Del", paras, CommandType.StoredProcedure))
            {
                GlobalUserInfo.skin = dsInterface.Rows[3]["SetValue"].ToString();
            }
           
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle(GlobalUserInfo.skin);
            barStaticItem1.Visibility = BarItemVisibility.Always;
            barStaticItem2.Visibility = BarItemVisibility.Always;
            barStaticItem1.Caption = "欢迎:" + GlobalUserInfo.user_Name;
            barStaticItem2.Caption = DateTime.Now.Date.ToShortDateString();
        }

        /// <summary>销售出货
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSaleOutMaster frmsale = new frmSaleOutMaster();          
            frmsale.Text = "销售出货查询";
            DxCtlHelper.OpenChildFrom(this, frmsale);            
        }
        /// <summary>销售退货
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmSaleBackMaster frmsale = new frmSaleBackMaster();
            frmsale.Text = "销售退货查询";
            DxCtlHelper.OpenChildFrom(this, frmsale); 
        }
        /// <summary>员工管理
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmPersonManageMaster frmsale = new frmPersonManageMaster();
            frmsale.Text = "员工信息查询";
            DxCtlHelper.OpenChildFrom(this, frmsale); 
        }        
        /// <summary>产品查询
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmProductInfo frmprod = new frmProductInfo();
            frmprod.Text = "产品信息查询";
            DxCtlHelper.OpenChildFrom(this, frmprod); 
        }            
        /// <summary>注销退出
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }       
        /// <summary>权限管理
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
           
            frmRoleManage rolemg = new frmRoleManage();
            rolemg.Text = "角色维护管理";
            DxCtlHelper.OpenChildFrom(this, rolemg);
        }
        /// <summary>供应商管理
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSuppManage frms = new frmSuppManage();
            frms.Text = "供应商管理";
            DxCtlHelper.OpenChildFrom(this, frms);
        }
        /// <summary>产品入库
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProdInStock prodinstock = new frmProdInStock();
            prodinstock.Text = "产品入库查询";
            DxCtlHelper.OpenChildFrom(this, prodinstock);
        }
        /// <summary>金价设置
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem24_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmSetGold setgold = new frmSetGold();
            setgold.Text = "金价设置管理";
            DxCtlHelper.OpenChildFrom(this, setgold);
        }
        /// <summary>库存查询
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem15_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProdStockQty StockQty = new frmProdStockQty();
            StockQty.Text = "实时库存查询";
            DxCtlHelper.OpenChildFrom(this, StockQty);
        }
        /// <summary>款式管理
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem25_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProdStyleQuery ProdStyle = new frmProdStyleQuery();
            ProdStyle.Text = "产品款式查询";
            DxCtlHelper.OpenChildFrom(this, ProdStyle);
        }
        /// <summary>入库报表
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem17_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmInStockQuery instock = new frmInStockQuery();
            instock.Text = "入库报表";
            DxCtlHelper.OpenChildFrom(this, instock);
        }
        /// <summary>产品退库
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem21_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProdOutStock prodOutstock = new frmProdOutStock();
            prodOutstock.Text = "产品退库查询";
            DxCtlHelper.OpenChildFrom(this, prodOutstock);
        }
        /// <summary>历史存储查询
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem16_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProdStockHistory prodhistory = new frmProdStockHistory();
            prodhistory.Text = "历史库存查询";
            DxCtlHelper.OpenChildFrom(this, prodhistory);
        }
        /// <summary>修改密码
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem1_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            UpdatePassword up = new UpdatePassword();
            up.Show();
        
        }
        /// <summary>切换用户
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {          
            LoginForm lf = new LoginForm();
            if (lf.ShowDialog() == DialogResult.OK)
            {
                this.Hide();
                MainForm_Load(sender, e);
                this.Show();
            }

        }
        /// <summary>旧金回收
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem23_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmRecOldGold recgold = new frmRecOldGold();
            recgold.Text = "旧金回收查询";
            DxCtlHelper.OpenChildFrom(this, recgold);
        }
        /// <summary>产品盘点
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubStockChk_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmProdCheckStock ChkStock = new frmProdCheckStock();
            ChkStock.Text = "产品盘点查询";
            DxCtlHelper.OpenChildFrom(this, ChkStock);
        }

     

       
    }
}