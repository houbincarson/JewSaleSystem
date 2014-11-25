using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;

namespace JewSaleSystem
{
    public class StaticFunction
    {
        /// <summary>获取客户端IP地址
        /// 
        /// </summary>
        /// <returns></returns>
        public static string GetIp()
        {
            string HostNmae = Dns.GetHostName();
            System.Net.IPAddress[] AdressCol = Dns.GetHostAddresses(HostNmae);
            string Ips = string.Empty;
            foreach (IPAddress Address in AdressCol)
            {
                if (Address.ToString().Contains('.'))
                {
                    Ips = Address.ToString() + ",";
                }
                continue;
            }
            return Ips.TrimEnd(',');
        }
    }
}
