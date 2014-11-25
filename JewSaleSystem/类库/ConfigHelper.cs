using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Xml;


namespace JewSaleSystem
{
    public class ConfigHelper
    {
        /// <summary>获取当前运行项目所对应的config信息
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetConfig()
        {
            ExeConfigurationFileMap file = new ExeConfigurationFileMap(); 
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return config.ConnectionStrings.ConnectionStrings["connStr"].ConnectionString;
        }

        /// <summary>获取当前运行项目所对应的config里的Setting里Key为'SetKey'所对应的value值
        /// 
        /// </summary>
        /// <param name="SetKey">App.config里设置的key值</param>
        /// <returns></returns>
        public static string GetConfigKeyValue(string SetKey)
        {
            ExeConfigurationFileMap file = new ExeConfigurationFileMap();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return config.AppSettings.Settings[SetKey].Value.ToString();
        }
         

        /// <summary>对Config进行写操作
        /// 
        /// </summary>
        /// <param name="strExecutablePath">运行项目路径</param>
        /// <param name="AppKey">设置项</param>
        /// <param name="AppValue">设置值</param>
        public static void ConfigSetValue(string strExecutablePath, string AppKey, string AppValue)
        {
            XmlDocument xDoc = new XmlDocument();
            //获取可执行文件的路径和名称
            xDoc.Load(strExecutablePath + ".config");
            XmlNode xNode;
            XmlElement xElem1;
            XmlElement xElem2;
            xNode = xDoc.SelectSingleNode("//connectionStrings");
            xElem1 = (XmlElement)xNode.SelectSingleNode("//add[@name='" + AppKey + "']");
            if (xElem1 != null) xElem1.SetAttribute("connectionString", AppValue);
            else
            {
                xElem2 = xDoc.CreateElement("add");
                xElem2.SetAttribute("name", AppKey);
                xElem2.SetAttribute("connectionString", AppValue);
                xNode.AppendChild(xElem2);
            }
            xDoc.Save(strExecutablePath + ".config");
        }


        /// <summary>对本地项目代码的Config进行写操作
        /// 
        /// </summary>
        /// <param name="strExecutablePath">本地项目路径</param>
        /// <param name="AppKey">设置项</param>
        /// <param name="AppValue">设置值</param>
        public static void LocalConfigSetValue(string AppKey, string AppValue)
        {
            XmlDocument xDoc = new XmlDocument();
            //获取可执行文件的路径和名称
            string strExecutablePath = System.Windows.Forms.Application.ExecutablePath.Substring(0, System.Windows.Forms.Application.ExecutablePath.LastIndexOf("bin")) + "App.config";
            xDoc.Load(strExecutablePath);
            XmlNode xNode;
            XmlElement xElem1;
            XmlElement xElem2;
            xNode = xDoc.SelectSingleNode("//connectionStrings");
            xElem1 = (XmlElement)xNode.SelectSingleNode("//add[@name='" + AppKey + "']");
            if (xElem1 != null) xElem1.SetAttribute("connectionString", AppValue);
            else
            {
                xElem2 = xDoc.CreateElement("add");
                xElem2.SetAttribute("name", AppKey);
                xElem2.SetAttribute("connectionString", AppValue);
                xNode.AppendChild(xElem2);
            }
            xDoc.Save(strExecutablePath + ".config");
        }


        /// <summary>设置当前运行项目所对应的config里的Setting里Key为'SetKey'所对应的value值
        /// 
        /// </summary>
        /// <param name="SetKey">App.config里设置的key值</param>
        /// <param name="SetKey">设置后的Value值</param>
        /// <returns></returns>
        public static void SetConfigKeyValue(string SetKey, string NewValue)
        {
            ExeConfigurationFileMap file = new ExeConfigurationFileMap();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[SetKey].Value = NewValue;
            config.Save();
        }

    }
}
