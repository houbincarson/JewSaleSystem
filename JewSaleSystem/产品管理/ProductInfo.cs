using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JewSaleSystem
{
    class ProductInfo
    {
        private static int Flag;
        public static int flag
        {
            get;
            set;
        }
        private static int key_Id;
        public static int Key_Id
        {
            get;
            set;
        }
        private static bool enable;
        public static bool Enable
        {
            set;
            get;
        }
        private static string strEditSql;
        public static string StrEditSql
        {
            set;
            get;
        }
        private static string strFields;
        public static string StrFields
        {
            set;
            get;
        }
        private static string strFieldValues;
        public static string StrFieldValues
        {
            set;
            get;
        }
        private static int prodId;
        public static int ProdId
        {
            get;
            set;
        }
        private static string barcode;
        public static string Barcode
        {
            set;
            get;
        }
        private static string prodName;
        public static string ProdName
        {
            set;
            get;
        }
        private static string remark;
        public static string Remark
        {
            set;
            get;
        }
        private static int prodNature;
        public static int ProdNature
        {
            set;
            get;
        }
        private static int prodStyle;
        public static int ProdStyle
        {
            set;
            get;
        }
        private static int suppName;
        public static int SuppName
        {
            set;
            get;
        }
        private static int qty;
        public static int Qty
        {
            set;
            get;
        }
        private static string wgt;
        public static string Wgt
        {
            set;
            get;
        }
        private static string processCost;
        public static string ProcessCost
        {
            set;
            get;
        }
        private static string costPrice;
        public static string CostPrice
        {
            set;
            get;
        }
        private static string salePrice;
        public static string SalePrice
        {
            set;
            get;
        }
    }
}
