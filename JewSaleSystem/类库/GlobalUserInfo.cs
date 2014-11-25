using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace JewSaleSystem
{
    public class GlobalUserInfo
    {
        /// <summary>登录用户名
        /// 
        /// </summary>
        private static string User_Name;
        public static string user_Name
        {
            get;
            set;
        }

        /// <summary>存储过程标签flag
        /// 
        /// </summary>
        private static int Flag;
        public static int flag
        {
            get;
            set;
        }
        /// <summary>存储过程标签Key_Id
        /// 
        /// </summary>
        private static int key_Id;
        public static int Key_Id
        {
            get;
            set;
        }

        /// <summary>登录账号
        /// 
        /// </summary>
        private static string User_Number;
        public static string user_Number
        {
            get;
            set;
        }

        /// <summary>登录用户ID
        /// 
        /// </summary>
        private static string LoginUser_Id;
        public static string loginuser_Id
        {
            get;
            set;
        }

        /// <summary>登录密码
        /// 
        /// </summary>
        private static string User_Password;
        public static string user_Password
        {
            get;
            set;
        }

        /// <summary>用于判断是否已经登录了数据字典服务端（True为已登录，False为未登录）
        /// 
        /// </summary>
        private static bool Is_Visible_Dictionary;
        public static bool is_Visible_Dictionary
        {
            get;
            set;
        }

        /// <summary>登录数据字典服务端当前的Ip
        /// 
        /// </summary>
        private static string Svr_Ip;
        public static string svr_Ip
        {
            get;
            set;
        }

        /// <summary>登录数据字典后，再次切换服务端时，记录上一次登录的服务端Ip
        /// 
        /// </summary>
        private static string PreSvr_Ip;
        public static string preSvr_Ip
        {
            get;
            set;
        }

        /// <summary>登录数据字典服务端的Sa账号
        /// 
        /// </summary>
        private static string Svr_Sa;
        public static string svr_Sa
        {
            get;
            set;
        }

        /// <summary>登录数据字典服务端的Sa密码
        /// 
        /// </summary>
        private static string Svr_Pwd;
        public static string svr_Pwd
        {
            get;
            set;
        }

        /// <summary>未登录数据字典服务端时，就点击存储过程，或者视图或者表菜单的记录
        /// 
        /// </summary>
        //private static string DicWithoutLogin;
        //public static string dicWithoutLogin
        //{
        //    get;
        //    set;
        //}

        /// <summary>登录数据字典服务端的数据库连接字符串
        /// 
        /// </summary>
        private static string Conn_Temp;
        public static string conn_Temp
        {
            get;
            set;
        }

        /// <summary>登录数据字典服务端后获取该服务端下所有数据库的集合表
        /// 
        /// </summary>
        private static DataTable DtServer;
        public static DataTable dtServer
        {
            get;
            set;
        }

        /// <summary>单位名称
        /// 
        /// </summary>
        public static string CompanyName;
        public static string companyName
        {
            get;
            set;
        }

        /// <summary>电话
        /// 
        /// </summary>
        public static string Telephone;
        public static string telephone
        {
            get;
            set;
        }

        /// <summary>QQ群
        /// 
        /// </summary>
        public static string QQ;
        public static string qQ
        {
            get;
            set;
        }

        /// <summary>默认皮肤
        /// 
        /// </summary>
        public static string Skin;
        public static string skin
        {
            get;
            set;
        }

        /// <summary>欢迎信息
        /// 
        /// </summary>
        public static string Welcome;
        public static string welcome
        {
            get;
            set;
        }

        /// <summary>登录界面背景图片
        /// 
        /// </summary>
        public static string BackgroundImage;
        public static string backgroundImage
        {
            get;
            set;
        }
  
        /// <summary>窗体左上角图标
        /// 
        /// </summary>
        public static string LogoIco;
        public static string logoIco
        {
            get;
            set;
        }

        /// <summary>系统名称
        /// 
        /// </summary>
        public static string SystemName;
        public static string systemName
        {
            get;
            set;
        }

        /// <summary>主界面Logo
        /// 
        /// </summary>
        public static string MainLogo;
        public static string mainLogo
        {
            get;
            set;
        }

        /// <summary>主界面系统主题名称
        /// 
        /// </summary>
        public static string SystemTheme;
        public static string systemTheme
        {
            get;
            set;
        }
        /// <summary>状态标示
        /// 
        /// </summary>
        private static int Status;
        public static int status
        {
            get;
            set;
        }
    }
}
