using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraEditors;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraGrid;
using System.Data;
using DevExpress.XtraEditors.Controls;
using System.Data.SqlClient;
using System.Reflection;
using DevExpress.XtraBars;

namespace JewSaleSystem
{
    /*   DxCtlHelper类是对Devexpress控件的使用方便的方法集合。
     *    编写人：卢华明
     *    编写日期：2012-11-4
     */
    public class DxCtlHelper
    {
        /// <summary>判断子窗体是否在父窗体中已经打开(true为已打开，false为未打开)
        /// 
        /// </summary>
        /// <param name="FrmParent">父窗体</param>
        /// <param name="ChildName">子窗体名称</param>
        /// <returns>返回bool值</returns>
        public static bool HaveOpenedFrom(Form FrmParent, string ChildName)
        {
            bool Result = false;
            for (int i = 0; i < FrmParent.MdiChildren.Length; i++)
            {
                if (FrmParent.MdiChildren[i].Name == ChildName)
                {
                    FrmParent.MdiChildren[i].BringToFront();
                    Result = true;
                    break;
                }
            }
            return Result;
        }
        public static Form HaveOpenedFromNew(Form FrmParent, string ChildName)
        {
            Form frm = null;
            for (int i = 0; i < FrmParent.MdiChildren.Length; i++)
            {
                if (FrmParent.MdiChildren[i].Name == ChildName)
                {
                    frm = FrmParent.MdiChildren[i] as Form;
                    frm.Activate();
                    break;
                }
            }
            return frm;
        }

        /// <summary>根据上面HaveOpenedFrom方法判断后来决定是否打开窗体
        /// 
        /// </summary>
        /// <param name="FrmParent">父窗体</param>
        /// <param name="FrmChid">子窗体</param>
        public static void OpenChildFrom(Form FrmParent, Form FrmChid)
        {
            if (HaveOpenedFrom(FrmParent, FrmChid.Name))
            {
                FrmChid.Activate();
            }
            else
            {
                FrmChid.MdiParent = FrmParent;
                FrmChid.Show();
                FrmChid.Activate();
            }
        }

        /// <summary>根据上面HaveOpenedFrom方法判断后来决定是否打开窗体
        /// 
        /// </summary>
        /// <param name="FrmParent">父窗体</param>
        /// <param name="FrmChid">子窗体</param>
        public static Form OpenChildFromNew(Form FrmParent,string strFormName)
        {
            Form frm=null;
            frm=HaveOpenedFromNew(FrmParent, strFormName);
            if (frm == null)
            {
                Assembly asm = Assembly.Load("JewSaleSystem");//程序集名"MC.Fds"
                object frmObj = asm.CreateInstance("JewSaleSystem" + "." + strFormName, true);//程序集+form的类名。
                if (frmObj is Form)
                {
                    frm = frmObj as Form;
                    frm.MdiParent = FrmParent;
                    frm.Show();
                    frm.Activate();
                }
            }

            return frm;
        }

        public static void OpenChildFrom_H(Form FrmParent, Form FrmChid)
        {
            if (HaveOpenedFrom(FrmParent, FrmChid.Name))
            {
                FrmChid.Activate();
            }
            else
            {
                FrmChid.MdiParent = FrmParent;
                FrmChid.Show();
                FrmChid.Activate();
            }
        }

        /// <summary>绑定GridControl控件
        /// 
        /// </summary>
        /// <param name="GridControl">GridControl控件</param>
        /// <param name="Grid">GridView控件</param>
        /// <param name="dt">传入的表</param>
        public static void BindGridControl(DevExpress.XtraGrid.GridControl GridControl, DevExpress.XtraGrid.Views.Grid.GridView Grid, DataTable dt)
        {
            GridControl.DataSource = dt;
            Grid.BestFitColumns();
        }

        /// <summary>导出Excel
        /// 
        /// </summary>
        /// <param name="GridControl">GridControl控件实例</param>
        /// <param name="Frm">窗体</param>
        /// <param name="FileName">导出Excel的名称</param>
        public static void ImportExcel(DevExpress.XtraGrid.GridControl GridControl, Form Frm, string FileName)
        {
            SaveFileDialog FileDia = new SaveFileDialog();
            FileDia.Title = "导出Excel数据字典";
            FileDia.Filter = "Excel文件(*.xls)|*.xls";
            FileDia.FileName = FileName;
            DialogResult DialogRes = FileDia.ShowDialog(Frm);
            if (DialogRes == DialogResult.OK)
            {
                DevExpress.XtraPrinting.XlsExportOptions options = new DevExpress.XtraPrinting.XlsExportOptions();
                GridControl.ExportToXls(FileDia.FileName);
                DevExpress.XtraEditors.XtraMessageBox.Show("导出成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>LookUpEdit绑定
        /// 
        /// </summary>
        /// <param name="LookUpEdit">LookUpEdit控件</param>
        /// <param name="dt">数据源</param>
        /// <param name="strTxtField">显示字段</param>
        /// <param name="strValueField">有效值字段</param>
        /// <param name="strfieldNames">显示字段数组</param>
        /// <param name="strHeadTexts">显示名称数组</param>
        /// <param name="blShowHeader">是否显示头</param>
        /// <param name="strSort">排序</param>
        /// <param name="strFilter">过滤dt</param>
        /// <param name="blAddNone">是否显示空</param>
        /// <param name="NullText">NullText的显示文本替换</param>
        /// <param name="TextEditStyle">是否可以填写</param>
        public static void BindLookUpEdit(DevExpress.XtraEditors.LookUpEdit LookUpEdit, DataTable dt, string strTxtField, string strValueField, string[] strfieldNames, string[] strHeadTexts, bool blShowHeader, string strSort, string strFilter, bool blAddNone, string NullText, bool TextEditStyle)
        {
            LookUpEdit.Properties.DataSource = null;
            DataView dv = dt.Copy().DefaultView;
            dv.RowFilter = strFilter;
            dv.Sort = strSort;
            LookUpEdit.Properties.Columns.Clear();
            LookUpEdit.Properties.NullText = NullText;
            if (TextEditStyle == true)
            {
                LookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            }
            else
            {
                LookUpEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            }
            for (int i = 0; i < strfieldNames.Length; i++)
            {
                LookUpEdit.Properties.Columns.Add(new LookUpColumnInfo(strfieldNames[i], strHeadTexts[i]));
            }
            LookUpEdit.Properties.ShowHeader = blShowHeader;
            LookUpEdit.Properties.ValueMember = strValueField;
            LookUpEdit.Properties.DisplayMember = strTxtField;
            if (blAddNone)
            {
                DataRowView dr = dv.AddNew();
                if (dv.Table.Columns.IndexOf("Number") != -1)
                {
                    dr["Number"] = " ";
                }
                dr[strTxtField] = "空";
                dr[strValueField] = "-2";
            }

            LookUpEdit.Properties.DataSource = dv;
            LookUpEdit.EditValue = "-2";
        }

        /// <summary>ComboBoxEdit绑定
        /// 
        /// </summary>
        /// <param name="ComboBoxEdit">ComboBoxEdit控件</param>
        /// <param name="dt">数据源</param>
        /// <param name="FirstRowText">除了数据源之外显示在第一行的文本（可写：请选择）</param>
        /// <param name="bSelectFirstItem">是否选中第一行</param>
        /// <param name="TextEditStyle">是否可以写</param>
        public static void BindComboBoxEdit(DevExpress.XtraEditors.ComboBoxEdit ComboBoxEdit, DataTable dt, string FirstRowText, bool bSelectFirstItem, bool TextEditStyle)
        {
            ComboBoxEdit.Properties.Items.Clear();
            if (!string.IsNullOrEmpty(FirstRowText))
            {
                ComboBoxEdit.Properties.Items.Add(FirstRowText);
            }

            if (TextEditStyle == true)
            {
                ComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;
            }
            else
            {
                ComboBoxEdit.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            }

            int intCount = (dt != null) ? dt.Rows.Count : 0;
            if (intCount > 0)
            {
                for (int i = 0; i < intCount; i++)
                {
                    ComboBoxEdit.Properties.Items.Add(dt.Rows[i][0].ToString());
                }
            }
            if (bSelectFirstItem)
            {
                ComboBoxEdit.SelectedIndex = 0; // 设置选中第1项  
            }
        }

        /// <summary>ComboBoxEdit 模仿LookUpEdit，但可以模糊搜索。LookUpEdit只能首字母搜索（在comboBoxEdit1_KeyUp事件添加）
        /// 
        /// </summary>
        /// <param name="ComboBoxEdit">ComboBoxEdit控件</param>
        /// <param name="dt">数据源</param>
        /// <param name="FilterValue">ComboBoxEdit绑定值</param>
        public static void ComboBoxEditSerachMode(DevExpress.XtraEditors.ComboBoxEdit ComboBoxEdit, DataTable dt, string FilterValue)
        {
            try
            {
                string str = ComboBoxEdit.Text.ToString();
                ComboBoxEdit.Properties.Items.Clear();//无论有没有过滤，都要清空原来的值
                string Filter = "" + FilterValue + " like '%" + str + "%'";
                DataView View = dt.DefaultView;
                View.RowFilter = Filter;
                DataTable dtView = View.ToTable();
                if (dtView.Rows.Count > 0)//如果输入的值过滤后有满足的值，则加载满足条件的值,否则加载全部
                {
                    for (int i = 0; i < dtView.Rows.Count; i++)
                    {
                        ComboBoxEdit.Properties.Items.Add(dtView.Rows[i][FilterValue].ToString());
                    }
                }
                else
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ComboBoxEdit.Properties.Items.Add(dt.Rows[i][FilterValue].ToString());
                    }
                }
                ComboBoxEdit.ShowPopup();
            }
            catch (Exception)
            {
                //TODO
            }
        }

        /// <summary>设置面板所有控件的可编辑性
        /// 
        /// </summary>
        /// <param name="oContainerOfControls">承载控件的面板</param>
        /// <param name="blEnable">可编辑为true，只读为false</param>
        public static void SetControlEnabled(Control oContainerOfControls, bool blEnable)
        {
            SetControlEnabled(oContainerOfControls, blEnable, string.Empty);
        }

        /// <summary> 设置面板部分控件的可编辑性
        ///
        /// </summary>
        /// <param name="oContainerOfControls">承载控件的面板</param>
        /// <param name="blEnable">可编辑为true，只读为false</param>
        /// <param name="strNoCluIds">控件ID列表，逗号分隔，此列表中的的对应ID的控件的可编辑性将不会被设置</param>
        public static void SetControlEnabled(Control oContainerOfControls, bool blEnable, string strNoCluIds)
        {
            foreach (Control c in oContainerOfControls.Controls)
            {
                if (strNoCluIds != string.Empty && ("," + strNoCluIds + ",").IndexOf("," + c.Name + ",") != -1)
                    continue;

                if (c is DevExpress.XtraEditors.BaseEdit)
                {
                    ((DevExpress.XtraEditors.BaseEdit)c).Properties.ReadOnly = !blEnable;
                }
            }
        }

        /// <summary>清空面板中所有控件的值
        ///
        /// </summary>
        /// <param name="oContainerOfControls">承载控件的面板</param>
        public static void SetControlEmpty(Control oContainerOfControls)
        {
            SetControlEmpty(oContainerOfControls, string.Empty);
        }

        /// <summary>清空面板中部分控件的值
        /// 
        /// </summary>
        /// <param name="oContainerOfControls">承载控件的面板</param>
        /// <param name="strNoCluIds">控件ID列表，逗号分隔，此列表中的的对应ID的控件的值将不会被清空</param>
        public static void SetControlEmpty(Control oContainerOfControls, string strNoCluIds)
        {
            foreach (Control c in oContainerOfControls.Controls)
            {
                if (strNoCluIds != string.Empty && ("," + strNoCluIds + ",").IndexOf("," + c.Name + ",") != -1)
                    continue;

                switch (c.GetType().ToString())
                {
                    case "DevExpress.XtraEditors.LookUpEdit":
                        (c as DevExpress.XtraEditors.LookUpEdit).EditValue = null;
                        break;
                    case "DevExpress.XtraEditors.DateEdit":
                        (c as DevExpress.XtraEditors.DateEdit).EditValue = null;
                        break;
                    case "DevExpress.XtraEditors.TextEdit":
                        (c as DevExpress.XtraEditors.TextEdit).EditValue = string.Empty;
                        break;
                    case "DevExpress.XtraEditors.ImageComboBoxEdit":
                        (c as DevExpress.XtraEditors.ImageComboBoxEdit).EditValue = string.Empty;
                        break;
                    case "DevExpress.XtraEditors.CheckEdit":
                        (c as DevExpress.XtraEditors.CheckEdit).Checked = false;
                        break;
                    case "DevExpress.XtraEditors.MemoEdit":
                        (c as DevExpress.XtraEditors.MemoEdit).EditValue = string.Empty;
                        break;
                    case "System.Windows.Forms.TextBox":
                        (c as System.Windows.Forms.TextBox).Text = string.Empty;
                        break;
                    case "DevExpress.XtraEditors.CheckedComboBoxEdit":
                        DevExpress.XtraEditors.CheckedComboBoxEdit chb = c as DevExpress.XtraEditors.CheckedComboBoxEdit;
                        chb.Text = string.Empty;
                        chb.EditValue = null;
                        chb.RefreshEditValue();
                        break;
                    //case "ExtendControl.ExtPopupTree":
                    //    ExtendControl.ExtPopupTree ext = c as ExtendControl.ExtPopupTree;
                    //    ext.EditValue = null;
                    //    break;
                    //case "ProduceManager.UcTxtPopup":
                    //    ProduceManager.UcTxtPopup ucp = c as ProduceManager.UcTxtPopup;
                    //    ucp.EditValue = string.Empty;
                    //    break;

                    default:
                        break;
                }
            }
        }

        public static void SetControlBindings(DevExpress.XtraTab.XtraTabControl oContainerOfControls, DataView dv)
        {
            foreach (DevExpress.XtraTab.XtraTabPage tpage in oContainerOfControls.TabPages)
            {
                foreach (Control c in tpage.Controls)
                {
                    if (Convert.ToString(c.Tag) == string.Empty)
                        continue;
                    c.DataBindings.Clear();
                    c.DataBindings.Add("EditValue", dv, c.Tag.ToString());
                }
            }
        }
        public static void SetControlBindings(DevExpress.XtraEditors.GroupControl oContainerOfControls, DataView dv)
        {
            foreach (Control c in oContainerOfControls.Controls)
            {
                if (Convert.ToString(c.Tag) == string.Empty)
                    continue;

                c.DataBindings.Clear();
                c.DataBindings.Add("EditValue", dv, c.Tag.ToString());
            }
        }
        public static void SetControlBindings(DevExpress.XtraEditors.PanelControl oContainerOfControls, DataView dv)
        {
            foreach (Control c in oContainerOfControls.Controls)
            {
                if (Convert.ToString(c.Tag) == string.Empty)
                    continue;

                c.DataBindings.Clear();
                c.DataBindings.Add("EditValue", dv, c.Tag.ToString());
            }
        }
        public static void SetControlBindings(DevExpress.XtraEditors.GroupControl oContainerOfControls, DataTable dt)
        {
            foreach (Control c in oContainerOfControls.Controls)
            {
                if (Convert.ToString(c.Tag) == string.Empty)
                    continue;

                c.DataBindings.Clear();
                c.DataBindings.Add("EditValue", dt, c.Tag.ToString());
            }
        }

        public static void SetControlBindings(GroupBox oContainerOfControls, DataTable dt)
        {
            foreach (Control c in oContainerOfControls.Controls)
            {
                if (Convert.ToString(c.Tag) == string.Empty)
                    continue;

                switch (c.GetType().ToString())
                {
                    case "System.Windows.Forms.TextBox":
                        c.DataBindings.Add("Text", dt, c.Tag.ToString());
                        break;
                    case "DevExpress.XtraEditors.LookUpEdit":
                        c.DataBindings.Add("EditValue", dt, c.Tag.ToString());
                        break;
                    case "DevExpress.XtraEditors.DateEdit":
                        c.DataBindings.Add("EditValue", dt, c.Tag.ToString());
                        break;
                    case "System.Windows.Forms.CheckBox":
                        c.DataBindings.Add("Checked", dt, c.Tag.ToString());
                        break;
                    default:
                        break;
                }
            }
        }
        public static void SetControlBindings(GroupBox oContainerOfControls, DataView dv)
        {
            foreach (Control c in oContainerOfControls.Controls)
            {
                if (Convert.ToString(c.Tag) == string.Empty)
                    continue;

                c.DataBindings.Clear();
                switch (c.GetType().ToString())
                {
                    case "System.Windows.Forms.TextBox":
                        c.DataBindings.Add("Text", dv, c.Tag.ToString());
                        break;
                    case "DevExpress.XtraEditors.LookUpEdit":
                        c.DataBindings.Add("EditValue", dv, c.Tag.ToString());
                        break;
                    case "DevExpress.XtraEditors.DateEdit":
                        c.DataBindings.Add("EditValue", dv, c.Tag.ToString());
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>控制所有控件所见性
        /// 
        /// </summary>
        /// <param name="oContainerOfControls"></param>
        /// <param name="blEnable"></param>
        public static void SetControlEnabledNew(Control oContainerOfControls, bool blEnable)
        {

            foreach (Control c in oContainerOfControls.Controls)
            {
                c.Enabled = blEnable;
              
            }
        }
        /// <summary>设置部分控件可见性
        /// 
        /// </summary>
        /// <param name="oContainerOfControls"></param>
        /// <param name="blEnable"></param>
        /// <param name="strNoCluIds"></param>
        public static void SetControlEnabledNew(Control oContainerOfControls, bool blEnable, string strNoCluIds)
        {
            string[] strNo = strNoCluIds.Split(new Char[] { ',' });
            bool exist = false;
            
                foreach (Control c in oContainerOfControls.Controls)
                {
                    for (int i = 0; i < strNo.Length; i++)
                    {
                        if (c.Name == strNo[i])
                        {
                            c.Enabled = !blEnable;
                            exist = true;
                            break;                           
                        }
                        else
                            exist = false;
                    }
                    if(exist ==false)
                    c.Enabled = blEnable;
                }            
        }

        /// <summary>
        /// 获取新增的数据库语句
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="strFileds"></param>
        /// <param name="strField">字段列表</param>
        /// <returns>值列表</returns>
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
        /// <summary>
        /// 获取被修改过的更新语句
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="dr"></param>
        /// <param name="strFileds"></param>
        /// <returns></returns>
        public static string GetUpdateValues(DataTable dt, DataRow dr, List<string> strFileds)
        {
            StringBuilder sbValues = new StringBuilder();

            foreach (string strFiled in strFileds)
            {
                if (dr[strFiled].ToString() == dr[strFiled, DataRowVersion.Original].ToString())
                    continue;

                string strType = dt.Columns[strFiled].DataType.ToString();

                if (dr[strFiled].ToString() == string.Empty
                    || dr[strFiled].ToString() == "-9999")
                {
                    sbValues.Append("," + strFiled + "=default");
                }
                else
                {
                    sbValues.Append("," + strFiled + "='" + dr[strFiled].ToString().Replace("'", "''") + "'");
                }
            }
            if (sbValues.Length > 0)
            {
                return sbValues.ToString().Remove(0, 1);
            }
            return string.Empty;
        }

        public static List<string> GetField(Control gcInfo)
        {
            List<string> arr = new List<string>();

            foreach (Control ctrl in gcInfo.Controls)
            {
                if (Convert.ToString(ctrl.Tag) == string.Empty)
                    continue;

                arr.Add(ctrl.Tag.ToString());
            }
            return arr;
        }

        //public static void IsVisible(DevExpress.XtraBars.BarManager bar)
        //{

        //    foreach (DevExpress.XtraBars.BarButtonItem barbtn in bar)
        //    {
 
        //    }
        //}
		
 	/// <summary>
        /// 拼接成SQL中Insert into语句
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="gcInfo"></param>
        /// <param name="strFields"></param>
        /// <returns></returns>
        public static  string GetstrValues(DataTable dt,Control gcInfo,out string strFields)
        {
            StringBuilder sbFields = new StringBuilder();
            StringBuilder sbValues = new StringBuilder();            
            string strValues = "";

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                foreach (Control ctrl in gcInfo.Controls)
                {
                    if (ctrl.Tag.ToString() == dt.Columns[i].ColumnName && Convert.ToString(ctrl.Tag) != string.Empty)
                    {
                        sbFields.Append(',' + ctrl.Tag.ToString());
                        if (ctrl.GetType().ToString()=="System.Windows.Forms.CheckBox")
                        {
                             sbValues.Append(",'" + (ctrl as CheckBox).Checked.ToString().Replace("'", "''") + "'");
                        }
                        else if (ctrl.GetType().ToString() == "System.Windows.Forms.TextBox")
                        {
                            sbValues.Append(",'" + ctrl.Text.ToString().Replace("'", "''") + "'");
                        }
                        else if (ctrl.GetType().ToString() == "System.Windows.Forms.ComboBox")
                        {
                            sbValues.Append(",'" + (ctrl as ComboBox).SelectedValue.ToString().Replace("'", "''") + "'");
                        }
                    }
                }
            }
            if (sbValues.Length > 0)
            {
                strValues = sbValues.ToString().Remove(0, 1);                
            }
            strFields = sbFields.ToString().Remove(0, 1);
            return strValues;
        }

    }
}
