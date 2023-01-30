using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Will.VegetableShop.DataAccess
{
    public class VegetableInfo
    {
        #region 新增
        public Entities.OperateEventArgs Add(Entities.VegetableInfo vegetable)
        {
            Entities.OperateEventArgs args = new Entities.OperateEventArgs();

            String errorString = "";

            if (vegetable == null)
            {
                errorString += "没有指定要保存的对象。";
            }
            else
            {
                if (String.IsNullOrEmpty(vegetable.Title))
                {
                    errorString += "没有指定菜品标题。";
                }

                if (String.IsNullOrEmpty(vegetable.CategoryId))
                {
                    errorString += "没有指定菜品分类。";
                }
            }

            if (String.IsNullOrEmpty(errorString))
            {
                String sql = SqlText.VegetableInfoAddSql;

                List<SqlParameter> sqlParas = new List<SqlParameter>();

                String id = Guid.NewGuid().ToString("D");

                sqlParas.Add(new SqlParameter("@vegetableId", id));
                sqlParas.Add(new SqlParameter("@categoryId", vegetable.CategoryId));
                sqlParas.Add(new SqlParameter("@title", vegetable.Title));
                sqlParas.Add(new SqlParameter("@proftMargin", vegetable.ProfitMargin));
                sqlParas.Add(new SqlParameter("@description", vegetable.Description));

                SqlParameter pError = new SqlParameter();
                pError.Direction = ParameterDirection.Output;
                pError.ParameterName = "@errorString";
                pError.SqlDbType = SqlDbType.NVarChar;

                sqlParas.Add(pError);

                SqlServerAccess.ExecuteNonQuery(sql, sqlParas);

                errorString = Convert.ToString(pError.Value);

                if (errorString.ToLower() == "success")
                {
                    errorString = "";
                    args.GUID = id;
                }
            }

            if (String.IsNullOrEmpty(errorString))
            {
                args.OperateSuccess = true;
            }

            args.ErrorString = errorString;

            return args;
        }
        #endregion

        #region 获取数据
        public static DataSet GetData(Entities.VegetableInfoView.Filter filter)
        {
            DataSet ds = null;

            String sql = SqlText.VegetableInfoGetSql;

            List<SqlParameter> sqlParas = new List<SqlParameter>();

            if (!String.IsNullOrEmpty(filter.VegetableId))
            {
                sql += " and v.Vegetable_Id=@vegetableId";
                sqlParas.Add(new SqlParameter("@vegetableId", filter.VegetableId));
            }
            else
            {
                if (!String.IsNullOrEmpty(filter.CategoryId))
                {
                    sql += " and v.Category_Id=@categoryId";
                    sqlParas.Add(new SqlParameter("@categoryId", filter.CategoryId));
                }

                if (!String.IsNullOrEmpty(filter.Keywords))
                {
                    sql += " and v.Title like @keywords";
                    sqlParas.Add(new SqlParameter("@keywords", "%" + filter.Keywords + "%"));
                }

                if (filter.ActivityState != Entities.ThreeStateEnum.NotSet)
                {
                    sql += " and v.Is_Activity=@activityState";
                    sqlParas.Add(new SqlParameter("@activityState", (Int32)filter.ActivityState));
                }
            }

            ds = SqlServerAccess.ExecuteDataSet(sql, sqlParas);

            return ds;
        }
        #endregion

        #region 设置活动性
        public static Entities.OperateEventArgs SetActivity(String vegetableId)
        {
            Entities.OperateEventArgs args = new Entities.OperateEventArgs();

            String errorString = "";

            if (String.IsNullOrEmpty(vegetableId))
            {
                errorString = "没有指定要设置的菜品。";
            }
            else
            {
                String sql = SqlText.VegetableInfoSetActivitySql;

                List<SqlParameter> sqlParas = new List<SqlParameter>();

                sqlParas.Add(new SqlParameter("@vegetableId", vegetableId));

                SqlParameter pError = new SqlParameter();
                pError.Direction = ParameterDirection.Output;
                pError.ParameterName = "@errorString";
                pError.SqlDbType = SqlDbType.NVarChar;

                sqlParas.Add(pError);

                SqlServerAccess.ExecuteNonQuery(sql, sqlParas);

                errorString = Convert.ToString(pError.Value);

                if (errorString.ToLower() == "success")
                {
                    errorString = "";
                }
            }

            if (String.IsNullOrEmpty(errorString))
            {
                args.OperateSuccess = true;
            }

            args.ErrorString = errorString;

            return args;
        }
        #endregion

        #region 删除
        public static Entities.OperateEventArgs Remove(String vegetableId)
        {
            Entities.OperateEventArgs args = new Entities.OperateEventArgs();

            String errorString = "";

            if (String.IsNullOrEmpty(vegetableId))
            {
                errorString += "没有指定要删除的菜品。";
            }
            else
            {
                String sql = SqlText.VegetableInfoRemoveSql;

                List<SqlParameter> sqlParas = new List<SqlParameter>();

                sqlParas.Add(new SqlParameter("@vegetableId", vegetableId));

                SqlParameter pError = new SqlParameter();
                pError.Direction = ParameterDirection.Output;
                pError.ParameterName = "@errorString";
                pError.SqlDbType = SqlDbType.NVarChar;

                sqlParas.Add(pError);

                SqlServerAccess.ExecuteNonQuery(sql, sqlParas);

                errorString = Convert.ToString(pError.Value);

                if (errorString.ToLower() == "success")
                {
                    errorString = "";
                }
            }

            if (String.IsNullOrEmpty(errorString))
            {
                args.OperateSuccess = true;
            }

            args.ErrorString = errorString;

            return args;
        }
        #endregion

        #region 保存修改信息
        public static Entities.OperateEventArgs CheckEditInfo(Entities.DataOperateLog editInfo)
        {
            Entities.OperateEventArgs args = new Entities.OperateEventArgs();

            String errorString = "";

            //

            switch (editInfo.FieldName.ToLower())
            {
                case "title":
                    //不能为空，同一项目不能重复
                    if (String.IsNullOrEmpty(editInfo.NewValue))
                    {
                        errorString += "标题不能为空。";
                    }
                    else
                    {
                        String sqlCheckTitle = "select Error_Code from (select max(1) as Error_Code from Vegetable_Info where Title=:title and Vegetable_Id<>@vegetableId)) where Error_Code is not null";

                        List<SqlParameter> checkTitleParas = new List<SqlParameter>();
                        checkTitleParas.Add(new SqlParameter("@title", editInfo.NewValue));
                        checkTitleParas.Add(new SqlParameter(":vegetableId", editInfo.ObjectId));

                        DataTable dt = SqlServerAccess.ExecuteDataTable(sqlCheckTitle, checkTitleParas);

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            errorString += "标题已存在。";
                        }
                    }
                    break;
                case "category_id":
                case "profit_margin":
                case "description":
                    break;
                default:
                    errorString = "不允许修改的字段：" + editInfo.FieldName;
                    break;
            }

            if (String.IsNullOrEmpty(errorString))
            {
                args.OperateSuccess = true;
            }

            args.ErrorString = errorString;

            return args;
        }

        public static Entities.OperateEventArgs SaveEditInfo(Entities.DataOperateLog editInfo)
        {
            Entities.OperateEventArgs args = CheckEditInfo(editInfo);

            if (args.OperateSuccess)
            {
                String sql = SqlText.VegetableInfoEditInfoSaveOra;

                String logId = editInfo.LogId;

                if (String.IsNullOrEmpty(logId))
                {
                    logId = Guid.NewGuid().ToString("D");
                }

                if (String.IsNullOrEmpty(editInfo.EditFlag))
                {
                    editInfo.EditFlag = Guid.NewGuid().ToString("D");
                }

                List<SqlParameter> sqlParas = new List<SqlParameter>();

                sqlParas.Add(new SqlParameter(":LogId", logId));
                sqlParas.Add(new SqlParameter(":editFlag", editInfo.EditFlag));
                sqlParas.Add(new SqlParameter(":objectId", editInfo.ObjectId));
                sqlParas.Add(new SqlParameter(":fieldName", editInfo.FieldName));
                sqlParas.Add(new SqlParameter(":fieldTitle", editInfo.FieldTitle));
                sqlParas.Add(new SqlParameter(":oldValue", editInfo.OldValue));
                sqlParas.Add(new SqlParameter(":oldTitle", editInfo.OldTitle));
                sqlParas.Add(new SqlParameter(":newValue", editInfo.NewValue));
                sqlParas.Add(new SqlParameter(":newTitle", editInfo.NewTitle));
                sqlParas.Add(new SqlParameter(":description", editInfo.Description));
                sqlParas.Add(new SqlParameter(":requestId", editInfo.RequestId));
                sqlParas.Add(new SqlParameter(":inputUserId", editInfo.InputUserId));

                //同时改多个字段时处理
                String fieldName = editInfo.FieldName.ToLower();

                //switch (fieldName)
                //{
                //    case "supplier_id":
                //        fieldName = "Supplier_Name=:newTitle,Supplier_Id";
                //        break;
                //    case "approve_condition_id":
                //        fieldName = "Approve_Condition_Code=(select Code from Investment_Approve_Condition where Condition_Id=:newValue),Approve_Condition_Title=(select Title from Investment_Approve_Condition where Condition_Id=:newValue),Approve_Condition_Id";
                //        break;
                //}

                //直接修改数据
                String otherUpdate = "";

                sql = String.Format(sql, fieldName, otherUpdate);

                SqlServerAccess.ExecuteNonQuery(sql, sqlParas);

                args.GUID = logId;
                args.OperateSuccess = true;
                args.ErrorString = "";
            }

            return args;
        }
        #endregion

        #region 获取图案
        public static byte[] GetImage(String vegetableId)
        {
            byte[] image = null;

            if (!String.IsNullOrEmpty(vegetableId))
            {
                String sql = "select Image from Vegetable_Info where Vegetable_Id=@vegetableId";

                List<SqlParameter> sqlParas = new List<SqlParameter>();

                sqlParas.Add(new SqlParameter("@vegetableId", vegetableId));

                DataTable dt = SqlServerAccess.ExecuteDataTable(sql, sqlParas);

                if (dt != null && dt.Rows.Count > 0)
                {
                    image = dt.Rows[0][0] as byte[];
                }
            }

            return image;
        }
        #endregion

        #region 设置图案
        public static Entities.OperateEventArgs SetImage(String vegetableId, byte[] image)
        {
            Entities.OperateEventArgs args = new Entities.OperateEventArgs();

            String errorString = "";

            if (String.IsNullOrEmpty(vegetableId))
            {
                errorString += "没有指定菜品。";
            }

            if (image == null)
            {
                errorString += "没有指定图片。";
            }

            if (String.IsNullOrEmpty(errorString))
            {
                String sql = "update Vegetable_Info set Image=@image where Vegetable_Id=@vegetableId";

                List<SqlParameter> sqlParas = new List<SqlParameter>();

                sqlParas.Add(new SqlParameter("@vegetableId", vegetableId));

                SqlParameter pImage = new SqlParameter("@image", image);
                pImage.SqlDbType = SqlDbType.Image;

                sqlParas.Add(pImage);

                SqlParameter pError = new SqlParameter();
                pError.Direction = ParameterDirection.Output;
                pError.ParameterName = "@errorString";
                pError.SqlDbType = SqlDbType.NVarChar;

                sqlParas.Add(pError);

                SqlServerAccess.ExecuteNonQuery(sql, sqlParas);

                errorString = Convert.ToString(pError.Value);

                if (errorString.ToLower() == "success")
                {
                    errorString = "";
                }
            }

            args.GUID = vegetableId;

            if (String.IsNullOrEmpty(errorString))
            {
                args.OperateSuccess = true;
            }

            args.ErrorString = errorString;

            return args;
        }
        #endregion
    }
}
