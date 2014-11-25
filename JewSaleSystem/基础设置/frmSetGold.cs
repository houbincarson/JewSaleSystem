using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Data.SqlClient;
using DevExpress.XtraBars;
using System.Reflection;


namespace JewSaleSystem
{
    public partial class frmSetGold : DevExpress.XtraEditors.XtraForm
    {
        public frmSetGold()
        {
            InitializeComponent();
        }
        double y = 0;
        double x = 0;
        private void frmSetGold_Load(object sender, EventArgs e)
        {
            dateEdit1.Text =  DateTime.Now.Date.ToShortDateString();
            dateEdit2.Text = DateTime.Now.Date.ToShortDateString();

        }
     
        /// <summary>日金价走势
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
          
            DateTime dtNow = DateTime.Now;
            DateTime[] date = new DateTime[7];
            for (int i = 0; i <7; i++)
            {
                date[i] = dtNow.AddDays(-i).Date;                
            }
            double[] dbValue = new double[7];
            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@flag", 1),
                    new SqlParameter("@StDate", date[6]),
                    new SqlParameter("@EdDate", date[0])
                };
            dtGold = sqlhelper.ExecuteQueryTable("Sys_SetGold_Add_Edit_Del", paras, CommandType.StoredProcedure);
            string [] strDate =new  string[7];           
            for (int i = 0; i < date.Length; i++)
            {
                strDate[i] = date[i].ToString("MMdd");
            }

                for (int i = 0; i < 7; i++)
                {
                    dbValue[i] = Convert.ToDouble(dtGold.Rows[i]["GoldValue"].ToString());
                }
            //将dbValue排序按大到小
            double[] YValue = new double[7];
            YValue = Sort(dbValue);


            Bitmap bmap = new Bitmap(pictureBox1.Size.Width,pictureBox1.Size.Height);
            Graphics gph = Graphics.FromImage(bmap);
            gph.Clear(Color.White);

            PointF cpt = new PointF(100, 420);//中心点
            PointF[] xpt = new PointF[3] { new PointF(800 + 15, 420), new PointF(800, 420 - 8), new PointF(800, 420 + 8) };//x轴三角形
            PointF[] ypt = new PointF[3] { new PointF(100, 40 - 15), new PointF(100 - 8, 40), new PointF(100 + 8, 40) };//y轴三角形
            //画X轴
            gph.DrawLine(Pens.Black, 100, 420, 800, 420);
            gph.DrawPolygon(Pens.Black, xpt);
            gph.FillPolygon(new SolidBrush(Color.Black), xpt);
            gph.DrawString("日期", new Font("宋体", 12), Brushes.Black, new PointF(800 + 10, 420 + 10));

           // 画y轴
            gph.DrawLine(Pens.Black, 100, 420, 100, 40);
            gph.DrawPolygon(Pens.Black, ypt);
            gph.FillPolygon(new SolidBrush(Color.Black), ypt);
            gph.DrawString("人民币(圆)", new Font("宋体", 12), Brushes.Black, new PointF(0, 7));
            for (int i = 7; i > 0; i--)
            {
                //画y轴刻度
                gph.DrawString(Convert.ToInt32((YValue[0]+(i-1)*(YValue[6] - YValue[0])/7)).ToString(), new Font("宋体", 11), Brushes.Black, new PointF(cpt.X - 50, cpt.Y - i * 50 - 6));
                gph.DrawLine(Pens.Black, cpt.X - 3, cpt.Y - i * 50, cpt.X, cpt.Y - i * 50);
                // 画x轴项目               
                gph.DrawString(strDate[i - 1].Substring(0, 4), new Font("宋体", 11), Brushes.Black, new PointF(740 - i * 80 - 5, 420 + 20));
                gph.DrawLine(Pens.Black, 740 - i * 80, cpt.Y, 740 - i * 80, cpt.Y + 3);
                int k = Convert.ToInt32((dbValue[i - 1] - YValue[0]) / ((YValue[6] - YValue[0])/7))+1;
               
                gph.DrawEllipse(Pens.Black, Convert.ToInt32(740 - i * 80), Convert.ToInt32(cpt.Y - 50 * k), 3, 3);
                gph.FillEllipse(new SolidBrush(Color.Black), Convert.ToInt32(740 - i * 80), Convert.ToInt32(cpt.Y - 50 * k), 3, 3);
                //画数值
                gph.DrawString(dbValue[i - 1].ToString(), new Font("宋体", 11), Brushes.Black, new PointF(Convert.ToInt32(740 - i * 80)-3, Convert.ToInt32(cpt.Y - 50 * k)+5));
                if (i > 1)
                {
                    int kk = Convert.ToInt32((dbValue[i - 2] - YValue[0]) / ((YValue[6] - YValue[0]) / 7)) + 1;
                    gph.DrawLine(Pens.Red, Convert.ToInt32(740 - i * 80), Convert.ToInt32(cpt.Y - 50 * k), Convert.ToInt32(740 - (i-1) * 80), Convert.ToInt32(cpt.Y - 50 * kk));
                }
            }         
            pictureBox1.Image = bmap;

        }
        //排序
        private double[] Sort(double [] value)
        {

            double [] dbY =  new double [7];
            for(int j = 0;j<value.Length;j++)
            {
                dbY[j] = value[j];
            }
            double temp = 0;            
            for (int i = 0; i < dbY.Length -1; i++)
            {
                for (int j = 0; j < dbY.Length - i - 1; j++)
                {
                    if (dbY[j] >= dbY[j+1])
                    {
                        temp = dbY[j];
                        dbY[j] = dbY[j+1];
                        dbY[j+1] = temp;
                    }
                }
            }
            return dbY;
        }
        SQLHelper sqlhelper = new SQLHelper();
        DataTable dtGold = null;
        /// <summary>录入金价
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string strGold = textBox1.Text;
            string strFields = "GoldValue";
            string strFieldValues = strGold;


            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@flag", 3),
                    new SqlParameter("@strFields",strFields),                    
                    new SqlParameter("@strFieldValues",strFieldValues)
                };
            dtGold = sqlhelper.ExecuteQueryTable("Sys_SetGold_Add_Edit_Del", paras, CommandType.StoredProcedure);
            gridControl1.DataSource = dtGold.DefaultView;
        }
        /// <summary>查询金价
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            string StDate = dateEdit1.Text;
            string EdDate = dateEdit2.Text;
            SqlParameter[] paras = new SqlParameter[]
                { 
                    new SqlParameter("@flag", 1),
                    new SqlParameter("@StDate", StDate),
                    new SqlParameter("@EdDate", EdDate)
                };
            dtGold = sqlhelper.ExecuteQueryTable("Sys_SetGold_Add_Edit_Del", paras, CommandType.StoredProcedure);
            gridControl1.DataSource = dtGold.DefaultView;
        }
        /// <summary>周金价走势
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("数据不足，暂未统计！");
        }
        /// <summary>月金价走势
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("数据不足，暂未统计！");
        }

     
       

    }
}