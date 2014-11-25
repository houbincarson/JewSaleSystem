using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace JewSaleSystem
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            DevExpress.UserSkins.OfficeSkins.Register(); //注册office的皮肤 请先加入引用office的dll文件，关于如何引用 请看下文
            DevExpress.UserSkins.BonusSkins.Register(); //注册BonusSkins的皮肤
            DevExpress.Skins.SkinManager.EnableFormSkins(); //改变标题栏默认样式
            DevExpress.UserSkins.BonusSkins.Register();   //注册皮肤事件
            Application.SetCompatibleTextRenderingDefault(false);
            using (LoginForm loginform = new LoginForm())
            {
                if (loginform.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new MainForm());
                }
            }
        }
    }
}
