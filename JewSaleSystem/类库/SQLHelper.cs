using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Windows.Forms;

namespace JewSaleSystem
{
    public class SQLHelper
    {
        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        private SqlDataAdapter sda = null;
        private DataSet ds = null;

        /// <summary>构造函数定义连接字符串
        /// 
        /// </summary>
        public SQLHelper()
        {
            string connStr = JewSaleSystem.ConfigHelper.GetConfig();
            conn = new SqlConnection(connStr);
        }

        /// <summary>打开连接 
        /// 
        /// </summary>
        /// <returns></returns>
        private SqlConnection getconn()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        /// <summary>执行带参数的增删改sql语句或存储过程返回受影响行数
        ///
        /// </summary>
        /// <param name="cmdText">增删改sql语句或存储过程</param>
        /// <param name="paras">参数成员</param>
        /// <returns>受影响行数</returns>
        public int ExecuteNonQuery(string cmdText, SqlParameter[] paras, CommandType ct)
        {
            int i;
            try
            {
                //执行存储过程命令
                cmd = new SqlCommand(cmdText, getconn());
                //cmd访问类型
                cmd.CommandType = ct;
                //传递存储过程参数
                cmd.Parameters.AddRange(paras);
                //返回受影响行数
                i = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { 
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return i;
        }

        /// <summary>执行带参数的查询sql语句或存储过程返回DataSet
        ///
        /// </summary>
        /// <param name="cmdText">查询的sql语句或存储过程</param>
        /// <param name="paras">参数成员</param>
        /// <returns>返回查询表</returns>
        public DataSet ExecuteQuery(string cmdText, SqlParameter[] paras, CommandType ct)
        {

            try
            {
                //执行存储过程命令
                cmd = new SqlCommand(cmdText, getconn());
                //cmd访问类型
                cmd.CommandType = ct;
                //传递存储过程参数
                cmd.Parameters.AddRange(paras);
                //读取数据
                sda = new SqlDataAdapter(cmd);
                //填充数据表
                ds = new DataSet();
                sda.Fill(ds);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }

        /// <summary> 执行不带参数的查询sql语句或存储过程(方法重载)
        ///
        /// </summary>
        /// <param name="cmdText">查询的sql语句或存储过程</param>
        /// <returns>返回DataSet</returns>
        public DataSet ExecuteQuery(string cmdText, CommandType ct)
        {
            try
            {
                //执行存储过程命令
                cmd = new SqlCommand(cmdText, getconn());
                //cmd访问类型
                cmd.CommandType = ct;
                //读取数据
                sda = new SqlDataAdapter(cmd);
                //填充数据表
                ds = new DataSet();
                sda.Fill(ds);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return ds;
        }

        /// <summary>执行带参数的返回受影响行数的sql语句或存储过程返回受影响行
        ///
        /// </summary>
        /// <param name="cmdText">sql语句或存储过程</param>
        /// <param name="paras">参数成员</param>
        /// <returns>返回受影响行数</returns>
        public int ExecuteScalar(string cmdText, SqlParameter[] paras, CommandType ct)
        {
            int i;
            try
            {
                //执行存储过程命令
                cmd = new SqlCommand(cmdText, getconn());
                //cmd访问类型
                cmd.CommandType = ct;
                //传递存储过程参数
                cmd.Parameters.AddRange(paras);
                //返回受影响行数
                i = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return i;
        }

        /// <summary>执行不带参数的返回受影响行数的sql语句或存储过程（方法重载）
        ///
        /// </summary>
        /// <param name="cmdText">sql语句或存储过程</param>
        /// <param name="paras">参数成员</param>
        /// <returns>返回行数</returns>
        public int ExecuteScalar(string cmdText, CommandType ct)
        {
            int i;
            try
            {
                cmd = new SqlCommand(cmdText, getconn());

                //cmd访问类型
                cmd.CommandType = ct;
                //返回受影响行数
                i = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return i;
        }

        /// <summary>执行带参数的查询sql语句或存储过程返回查询表
        ///
        /// </summary>
        /// <param name="cmdText">查询的sql语句或存储过程</param>
        /// <param name="paras">参数成员</param>
        /// <returns>返回查询表</returns>
        public DataTable ExecuteQueryTable(string cmdText, SqlParameter[] paras, CommandType ct)
        {
            DataTable dt = new DataTable();
            try
            {
                //执行存储过程命令
                cmd = new SqlCommand(cmdText, getconn());
                //cmd访问类型
                cmd.CommandType = ct;
                //获取参数类型
                //  SqlCommandBuilder.DeriveParameters(cmd);
                //传递存储过程参数
                cmd.Parameters.AddRange(paras);
                //读取数据
                sda = new SqlDataAdapter(cmd);
                //填充数据表
                ds = new DataSet();
                sda.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        /// <summary> 执行不带参数的查询sql语句或存储过程(方法重载)
        ///
        /// </summary>
        /// <param name="cmdText">查询的sql语句或存储过程</param>
        /// <returns>返回数据表</returns>
        public DataTable ExecuteQueryTable(string cmdText, CommandType ct)
        {
            DataTable dt = new DataTable();
            try
            {
                //执行存储过程命令
                cmd = new SqlCommand(cmdText, getconn());
                //cmd访问类型
                cmd.CommandType = ct;
                //读取数据
                sda = new SqlDataAdapter(cmd);
                //填充数据表
                ds = new DataSet();
                sda.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        /// <summary>执行带参数的查询sql语句或存储过程返回查询表的第一行第一列的值
        ///
        /// </summary>
        /// <param name="cmdText">查询的sql语句或存储过程</param>
        /// <param name="paras">参数成员</param>
        /// <returns>返回查询表第一行第一列的值</returns>
        public string ExecuteQueryFirst(string cmdText, SqlParameter[] paras, CommandType ct)
        {
            DataTable dt = new DataTable();
            try
            {
                //执行存储过程命令
                cmd = new SqlCommand(cmdText, getconn());
                //cmd访问类型
                cmd.CommandType = ct;
                //传递存储过程参数
                cmd.Parameters.AddRange(paras);
                //读取数据
                sda = new SqlDataAdapter(cmd);
                //填充数据表
                ds = new DataSet();
                sda.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dt.Rows[0][0].ToString();
        }

        /// <summary> 执行不带参数的查询sql语句或存储过程(方法重载)返回数据表第一行第一列的值。
        ///
        /// </summary>
        /// <param name="cmdText">查询的sql语句或存储过程</param>
        /// <returns>返回数据表第一行第一列的值。</returns>
        public string ExecuteQueryFirst(string cmdText, CommandType ct)
        {
            DataTable dt = new DataTable();
            try
            {
                //执行存储过程命令
                cmd = new SqlCommand(cmdText, getconn());
                //cmd访问类型
                cmd.CommandType = ct;
                //读取数据
                sda = new SqlDataAdapter(cmd);
                //填充数据表
                ds = new DataSet();
                sda.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dt.Rows[0][0].ToString();
        }

        /// <summary>执行带参数的查询sql语句或存储过程返回查询表的第RowNumber行列名为ColumnName的值
        ///
        /// </summary>
        /// <param name="cmdText">查询的sql语句或存储过程</param>
        /// <param name="paras">参数成员</param>
        /// <param name="paras">第几行</param>
        /// <param name="paras">列名</param>
        /// <returns>返回查询表第RowNumber行列名为ColumnName的值</returns>
        public string ExecuteQueryTable(string cmdText, SqlParameter[] paras, int RowNumber, string ColumnName, CommandType ct)
        {
            DataTable dt = new DataTable();
            try
            {
                //执行存储过程命令
                cmd = new SqlCommand(cmdText, getconn());
                //cmd访问类型
                cmd.CommandType = ct;
                //传递存储过程参数
                cmd.Parameters.AddRange(paras);
                //读取数据
                sda = new SqlDataAdapter(cmd);
                //填充数据表
                ds = new DataSet();
                sda.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dt.Rows[RowNumber][ColumnName].ToString();
        }

        /// <summary> 执行不带参数的查询sql语句或存储过程(方法重载)返回查询表的第RowNumber行列名为ColumnName的值。
        ///
        /// </summary>
        /// <param name="cmdText">查询的sql语句或存储过程</param>
        /// <param name="paras">第几行</param>
        /// <param name="paras">列名</param>
        /// <returns>返回数据表第RowNumber行列名为ColumnName的值。</returns>
        public string ExecuteQueryTable(string cmdText, int RowNumber, string ColumnName, CommandType ct)
        {
            DataTable dt = new DataTable();
            try
            {
                //执行存储过程命令
                cmd = new SqlCommand(cmdText, getconn());
                //cmd访问类型
                cmd.CommandType = ct;
                //读取数据
                sda = new SqlDataAdapter(cmd);
                //填充数据表
                ds = new DataSet();
                sda.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dt.Rows[RowNumber][ColumnName].ToString();
        }

        /// <summary>快速创建SqlParameter[]基类
        /// 
        /// </summary>
        /// <param name="PramsName"></param>
        /// <param name="DbType"></param>
        /// <param name="_size"></param>
        /// <param name="_value"></param>
        /// <returns></returns>
        public static SqlParameter[] CreateParms(string[] PramsName, SqlDbType[] DbType, int[] _size, string[] _value)
        {
            SqlParameter[] Prams = new SqlParameter[PramsName.Length];
            for (int i = 0; i < PramsName.Length; i++)
            {
                Prams[i] = new SqlParameter(PramsName[i], _value[i]);
                Prams[i].SqlDbType = DbType[i];
                if (_size[i] > 0)
                {
                    Prams[i].Size = _size[i];
                }
            }
            return Prams;
        }

        /// <summary>快速创建SqlParameter数组
        /// 
        /// </summary>
        /// <param name="_value">value[] like "name|type|size|value", "name|type|size|value"</param>
        /// <returns>SqlParameter数组</returns> 
        public static SqlParameter[] QuickCreatePrams(string[] _value)
        {
            //string[]_value={"name|type|size|value","name|type|size|value"};
            string[] name = new string[_value.Length];
            SqlDbType[] DbType = new SqlDbType[_value.Length];
            int[] size = new int[_value.Length];
            string[] values = new string[_value.Length];
            for (int i = 0; i < _value.Length; i++)
            {
                name[i] = _value[i].Split('|')[0];
                DbType[i] = (SqlDbType)Enum.Parse(typeof(SqlDbType), _value[i].Split('|')[1]);
                size[i] = int.Parse(_value[i].Split('|')[2]);
                values[i] = _value[i].Split('|')[3];
            }
            SqlParameter[] Prams = CreateParms(name, DbType, size, values);
            return Prams;
        }

        /// <summary>根据传入的字典 自动生成 SqlParameter
        /// 
        /// </summary>
        /// <param name="prms"></param>
        public static SqlParameter[] CreateSqlParameterByDictionary(Dictionary<string, object> prms)
        {
            List<SqlParameter> listParas = new List<SqlParameter>();
            foreach (var item in prms)
            {
                listParas.Add(new SqlParameter(item.Key, item.Value));
            }
            SqlParameter[] paras = listParas.ToArray();
            return paras; 
        }

        public string[] GetArguments()
        {
            string connStr = JewSaleSystem.ConfigHelper.GetConfig();
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Sp_Bse_User_Add_Edit_Del";
            cmd.CommandType = CommandType.StoredProcedure; 
            conn.Open();
            SqlCommandBuilder.DeriveParameters(cmd);
            string[] aa = new string[cmd.Parameters.Count - 1]; 
            for (int i = 0; i < cmd.Parameters.Count; i++)
            {
                if (cmd.Parameters.IndexOf(cmd.Parameters[i]) == 0)
                    continue;  
                aa[i - 1] =  cmd.Parameters[i].ParameterName + "|" + cmd.Parameters[i].SqlDbType.ToString() + "|" + cmd.Parameters[i].Size.ToString() + "|" + "1" ; 
            }
            return aa;
        }

        /// <summary>从数据库获取表
        /// 
        /// </summary>
        /// <param name="ConnStr">数据库连接字符串</param>
        /// <param name="SqlServer">数据库语句或者存储过程</param>
        /// <param name="paras">存储过程参数或者T-Sql语句参数</param>
        /// <param name="cmdType">类型</param>
        /// <returns>返回DataTable</returns>
        public DataTable ExecuteQueryTableWithConn(string ConnStr, string SqlServer, SqlParameter[] paras, CommandType cmdType)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection Conn = new SqlConnection(ConnStr))
                {
                    Conn.Open();
                    using (SqlCommand cmd = new SqlCommand(SqlServer, Conn))
                    {
                        cmd.Parameters.AddRange(paras);
                        cmd.CommandType = cmdType;
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                JewSaleSystem.MessageDxUtil.ShowWarning(ex.Message);
            }
            return dt;
        }

        /// <summary>从数据库获取表
        /// 
        /// </summary>
        /// <param name="ConnStr">数据库连接字符串</param>
        /// <param name="SqlServer">数据库语句或者存储过程</param> 
        /// <param name="cmdType">类型</param>
        /// <returns>返回DataTable</returns>
        public DataTable ExecuteQueryTableWithConn(string ConnStr, string SqlServer, CommandType cmdType)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection Conn = new SqlConnection(ConnStr))
                {
                    Conn.Open();
                    using (SqlCommand cmd = new SqlCommand(SqlServer, Conn))
                    {
                        cmd.CommandType = cmdType;
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                JewSaleSystem.MessageDxUtil.ShowWarning(ex.Message);
            }
            return dt;
        }

        /// <summary>获取SQL Server身份数据库连接字符串
        /// 
        /// </summary>
        /// <param name="Server">服务端IP或者名称</param>
        /// <param name="DbName">数据库名称</param>
        /// <param name="UserName">用户名</param>
        /// <param name="Password">密码</param>
        /// <returns></returns>
        public string GetConnstrSql(string Server, string DbName, string UserName, string Password)
        {
            string ConnStr = "server=" + Server + ";" + "database=" + DbName + ";" + "uid=" + UserName + ";" + "pwd=" + Password;
            return ConnStr;
        }

        /// <summary>获取Windows身份数据库连接字符串
        /// 
        /// </summary>
        /// <param name="Server">服务端IP或者名称</param>
        /// <param name="DbName">数据库名称</param> 
        /// <returns></returns>
        public string GetConnstrLocal(string Server, string DbName)
        {
            string ConnStr = "server=" + Server + ";" + "database=" + DbName + ";" + "integrated security=true";
            return ConnStr;
        }

        /// <summary>执行不带参数的返回受影响行数的sql语句或存储过程返回受影响行
        ///
        /// </summary>
        /// <param name="cmdText">sql语句或存储过程</param>
        /// <param name="paras">参数成员</param>
        /// <returns>返回受影响行数</returns> 
        public int ExecuteScalarWithConn(string cmdText, string Conn, CommandType ct)
        {
            int i = 0;
            try
            {
                SqlConnection connect = new SqlConnection(Conn);
                if (connect.State == ConnectionState.Closed)
                {
                    connect.Open();
                }
                //执行存储过程命令 
                cmd = new SqlCommand(cmdText, connect);
                //cmd访问类型
                cmd.CommandType = ct;
                //返回受影响行数
                i = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                JewSaleSystem.MessageDxUtil.ShowWarning(ex.Message);
                i = -1;
                return i;
            }
            finally
            {
                conn.Close();
            }
            return i;
        }
          
        /// <summary>执行带参数的查询sql语句或存储过程返回查询表的第一行第一列的值
        ///
        /// </summary>
        /// <param name="cmdText">查询的sql语句或存储过程</param>
        /// <param name="paras">参数成员</param>
        /// <returns>返回查询表第一行第一列的值</returns>
        public DataTable  AutoExecuteQueryFirst(string cmdText, CommandType ct)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlParameter[] paras = QuickCreatePrams(GetArguments());
                //执行存储过程命令
                cmd = new SqlCommand(cmdText, getconn());
                //cmd访问类型
                cmd.CommandType = ct;
                //传递存储过程参数
                cmd.Parameters.AddRange(paras);
                //读取数据
                sda = new SqlDataAdapter(cmd);
                //填充数据表
                ds = new DataSet();
                sda.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
    }
}
