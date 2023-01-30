using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Will.VegetableShop.DataAccess
{
    public class MeasureUnit
    {
        #region 新增
        #endregion

        #region 获取数据
        public static DataSet GetData(Entities.MeasureUnitView.Filter filter)
        {
            DataSet ds = null;

            String sql = SqlText.MeasureUnitGetSql;

            List<SqlParameter> sqlParas = new List<SqlParameter>();

            if (!String.IsNullOrEmpty(filter.UnitId))
            {
                sql += " and Unit_Id=@unitId";
                sqlParas.Add(new SqlParameter("@unitId", filter.UnitId));
            }
            else if (!String.IsNullOrEmpty(filter.Code))
            {
                sql += " and Code=@code";
                sqlParas.Add(new SqlParameter("@code", filter.Code));
            }
            else
            {
                if (filter.ActivityState != Entities.ThreeStateEnum.NotSet)
                {
                    sql += " and Is_Activity=@activityState";
                    sqlParas.Add(new SqlParameter("@activityState", (Int32)filter.ActivityState));
                }

                if (filter.IsBase != Entities.ThreeStateEnum.NotSet)
                {
                    sql += " and Is_Base=@isBase";
                    sqlParas.Add(new SqlParameter("@isBase", filter.IsBase));
                }

                if (filter.Kind > -1)
                {
                    sql += " and Kind=@kind";
                    sqlParas.Add(new SqlParameter("@kind", filter.Kind));
                }

                if (!String.IsNullOrEmpty(filter.Keywords))
                {
                    sql += " and Title+Code like @keywords";
                    sqlParas.Add(new SqlParameter("@keywords", "%" + filter.Keywords + "%"));
                }
            }

            ds = SqlServerAccess.ExecuteDataSet(sql, sqlParas);

            return ds;
        }
        #endregion

        #region 设置活动性
        #endregion

        #region 删除
        #endregion

        #region 保存修改信息
        #endregion
    }
}
