using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//上面是模板自动添加，下面两项手动添加
using System.Data;
using System.Data.SqlClient;

namespace Will.VegetableShop.DataAccess
{
    internal class SqlServerAccess
    {
        #region 获取连接
        /// <summary>
        ///     使用连接配置项SQLServer中的连接字符串创建数据库连接
        /// </summary>
        /// <returns>数据库连接</returns>
        private static System.Data.SqlClient.SqlConnection GetConnection()
        {
            SqlConnection conn = null;

            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["SqlServer"].ConnectionString;

            if (!String.IsNullOrEmpty(connString))
            {
                conn = new SqlConnection(connString);
            }

            return conn;

        }
        #endregion

        #region 获取DataSet
        /// <summary>
        ///     
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="paras"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataSet(String sql, List<SqlParameter> paras)
        {
            DataSet ds = null;

            SqlConnection conn = GetConnection();

            if (conn != null)
            {
                ds = new DataSet();

                SqlCommand cmd = new SqlCommand(sql, conn);

                if (paras != null && paras.Count > 0)
                {
                    cmd.Parameters.AddRange(paras.ToArray());
                }

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);
            }

            return ds;
        }
        #endregion

        #region 获取DataTable
        public static DataTable ExecuteDataTable(String sql, List<SqlParameter> paras)
        {
            DataTable dt = null;

            SqlConnection conn = GetConnection();

            if (conn != null)
            {
                DataSet ds = new DataSet();

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddRange(paras.ToArray());

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(ds);

                if (ds != null && ds.Tables.Count > 0)
                {
                    dt = ds.Tables[0];
                }
            }

            return dt;
        }
        #endregion

        #region 执行操作
        public static Int32 ExecuteNonQuery(String sql, List<SqlParameter> paras)
        {
            Int32 count = 0;

            SqlConnection conn = GetConnection();

            if (conn != null)
            {
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddRange(paras.ToArray());

                count = cmd.ExecuteNonQuery();
            }

            return count;
        }
        #endregion
    }
}
