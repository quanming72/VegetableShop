using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Data;

namespace Will.VegetableShop.Entities
{
    [DataContract]
    public class DataOperateLog
    {
        #region 公共属性

        private String _logId = "";

        /// <summary>
        ///    GUID
        /// </summary>
        [DataMember]
        public String LogId
        {
            get { return _logId; }
            set { _logId = value; }
        }

        private String _editFlag = "";

        /// <summary>
        ///    同步修改多个字段标识，GUID
        /// </summary>
        [DataMember]
        public String EditFlag
        {
            get { return _editFlag; }
            set { _editFlag = value; }
        }

        private String _objectId = "";

        /// <summary>
        ///    对象ID
        /// </summary>
        [DataMember]
        public String ObjectId
        {
            get { return _objectId; }
            set { _objectId = value; }
        }

        private String _objectTitle = "";

        /// <summary>
        ///     对象标题
        /// </summary>
        [DataMember]
        public String ObjectTitle
        {
            get { return _objectTitle; }
            set { _objectTitle = value; }
        }

        private OperaKindEnum _operateKind = OperaKindEnum.Add;

        /// <summary>
        ///    操作类型，新增，修改，删除
        /// </summary>
        [DataMember]
        public OperaKindEnum OperateKind
        {
            get { return _operateKind; }
            set { _operateKind = value; }
        }

        private StateEnum _state = StateEnum.Undisposed;

        /// <summary>
        ///    状态，未处置，已保存，被拒绝，已取消
        /// </summary>
        [DataMember]
        public StateEnum State
        {
            get { return _state; }
            set { _state = value; }
        }

        private String _fieldName = "";

        /// <summary>
        ///    字段名
        /// </summary>
        [DataMember]
        public String FieldName
        {
            get { return _fieldName; }
            set { _fieldName = value; }
        }

        private String _fieldTitle = "";

        /// <summary>
        ///    字段显示标题
        /// </summary>
        [DataMember]
        public String FieldTitle
        {
            get { return _fieldTitle; }
            set { _fieldTitle = value; }
        }

        private String _oldValue = "";

        /// <summary>
        ///    原值
        /// </summary>
        [DataMember]
        public String OldValue
        {
            get { return _oldValue; }
            set { _oldValue = value; }
        }

        private String _oldTitle = "";

        /// <summary>
        ///    原值标题
        /// </summary>
        [DataMember]
        public String OldTitle
        {
            get { return _oldTitle; }
            set { _oldTitle = value; }
        }

        private String _newValue = "";

        /// <summary>
        ///    新值
        /// </summary>
        [DataMember]
        public String NewValue
        {
            get { return _newValue; }
            set { _newValue = value; }
        }

        private String _newTitle = "";

        /// <summary>
        ///    新值标题
        /// </summary>
        [DataMember]
        public String NewTitle
        {
            get { return _newTitle; }
            set { _newTitle = value; }
        }

        private String _description = "";

        [DataMember]
        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private String _requestId = "";

        [DataMember]
        public String RequestId
        {
            get { return _requestId; }
            set { _requestId = value; }
        }

        private String _inputUserId = "";

        /// <summary>
        ///    修改人ID
        /// </summary>
        [DataMember]
        public String InputUserId
        {
            get { return _inputUserId; }
            set { _inputUserId = value; }
        }

        private String _inputUserName = "";

        /// <summary>
        ///    修改人姓名
        /// </summary>
        [DataMember]
        public String InputUserName
        {
            get { return _inputUserName; }
            set { _inputUserName = value; }
        }

        private DateTime _inputTime = new DateTime(1900, 1, 1);

        /// <summary>
        ///    修改时间
        /// </summary>
        [DataMember]
        public DateTime InputTime
        {
            get { return _inputTime; }
            set { _inputTime = value; }
        }
        #endregion

        #region 生成实例
        /// <summary>
        ///     生成实例
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static DataOperateLog CreateInstance(DataRow dr)
        {
            DataOperateLog instance = null;

            if (dr != null)
            {
                instance = new DataOperateLog();

                instance.LogId = dr["Log_Id"].ToString();
                instance.EditFlag = dr["Edit_Flag"].ToString();
                instance.ObjectId = dr["Object_Id"].ToString();

                if (dr.Table.Columns.Contains("Object_Title"))
                {
                    instance.ObjectTitle = dr["Object_Title"].ToString();
                }

                Int32 operateKindValue= GetValueUtility.GetInteger(dr["Operate_Kind"].ToString());
                instance.OperateKind = ConvertOperaKindValueToEnum(operateKindValue);

                Int32 stateValue = GetValueUtility.GetInteger(dr["State"].ToString());
                instance.State = ConvertStateValueToEnum(stateValue);

                instance.FieldName = dr["Field_Name"].ToString();
                instance.FieldTitle = dr["Field_Title"].ToString();
                instance.OldValue = dr["Old_Value"].ToString();
                instance.OldTitle = dr["Old_Title"].ToString();
                instance.NewValue = dr["New_Value"].ToString();
                instance.NewTitle = dr["New_Title"].ToString();

                if (dr.Table.Columns.Contains("Description"))
                {
                    instance.Description = dr["Description"].ToString();
                }

                if (dr.Table.Columns.Contains("Request_Id"))
                {
                    instance.RequestId = dr["Request_Id"].ToString();
                }

                instance.InputUserId = dr["Input_User_Id"].ToString();
                instance.InputUserName = dr["Input_User_Name"].ToString();
                instance.InputTime = GetValueUtility.GetDateTime(dr["Input_Time"].ToString());
            }

            return instance;
        }
        #endregion

        #region 筛选条件
        /// <summary>
        ///     筛选条件
        /// </summary>
        /// <filed>LogId,ObjectId,State,EditFlag,OperateKind</filed>
        [DataContract]
        public class Filter
        {
            private String _logId = "";

            /// <summary>
            ///    GUID
            /// </summary>
            [DataMember]
            public String LogId
            {
                get { return _logId; }
                set { _logId = value; }
            }

            private String _editFlag = "";

            /// <summary>
            ///    同步修改多个字段标识，GUID
            /// </summary>
            [DataMember]
            public String EditFlag
            {
                get { return _editFlag; }
                set { _editFlag = value; }
            }

            private String _objectId = "";

            /// <summary>
            ///    对象ID
            /// </summary>
            [DataMember]
            public String ObjectId
            {
                get { return _objectId; }
                set { _objectId = value; }
            }

            private String _objectTitleLike = "";

            /// <summary>
            ///     对象标题
            /// </summary>
            [DataMember]
            public String ObjectTitleLike
            {
                get { return _objectTitleLike; }
                set { _objectTitleLike = value; }
            }

            private Int32 _operateKind = -1;

            /// <summary>
            ///    操作类型，1新增，2修改，3删除
            /// </summary>
            [DataMember]
            public Int32 OperateKind
            {
                get { return _operateKind; }
                set { _operateKind = value; }
            }

            private Int32 _state = -1;

            /// <summary>
            ///    状态，1未处置，2已保存，3确认中,98被拒绝，99已取消，默认1
            /// </summary>
            [DataMember]
            public Int32 State
            {
                get { return _state; }
                set { _state = value; }
            }

            private String _formTitle = "";

            /// <summary>
            ///     表单标题
            /// </summary>
            [DataMember]
            public String FormTitle
            {
                get { return _formTitle; }
                set { _formTitle = value; }
            }

            private String _fieldName = "";

            /// <summary>
            ///     字段名
            /// </summary>
            [DataMember]
            public String FieldName
            {
                get { return _fieldName; }
                set { _fieldName = value; }
            }

            private Int32 _pageIndex = 0;

            /// <summary>
            /// 页码
            /// </summary>
            [DataMember]
            public Int32 PageIndex
            {
                get { return _pageIndex; }
                set { _pageIndex = value; }
            }

            private Int32 _pageSize = 0;

            /// <summary>
            ///  每页记录数
            /// </summary>
            [DataMember]
            public Int32 PageSize
            {
                get { return _pageSize; }
                set { _pageSize = value; }
            }

            private String _orderField = "";

            [DataMember]
            public String OrderField
            {
                get { return _orderField; }
                set { _orderField = value; }
            }
        }
        #endregion

        #region 状态枚举
        public enum StateEnum
        {
            /// <summary>
            ///     1 未处置
            /// </summary>
            Undisposed = 1,
            /// <summary>
            ///     2 已保存
            /// </summary>
            Saved = 2,
            /// <summary>
            ///     3确认中
            /// </summary>
            Checking = 3,
            /// <summary>
            /// 98 被拒绝
            /// </summary>
            Rejected = 98,
            /// <summary>
            /// 99 已取消
            /// </summary>
            Cancel = 99
        }

        public static String ConvertStateEnumToTitle(StateEnum state)
        {
            String title = "未处置";

            switch (state)
            {
                case StateEnum.Undisposed:
                    title = "未处置";
                    break;
                case StateEnum.Saved:
                    title = "已保存";
                    break;
                case StateEnum.Checking:
                    title = "确认中";
                    break;
                case StateEnum.Rejected:
                    title = "被拒绝";
                    break;
                case StateEnum.Cancel:
                    title = "已取消";
                    break;
            }

            return title;
        }

        public static StateEnum ConvertStateTitleToEnum(String title)
        {
            StateEnum state = StateEnum.Undisposed;
            switch (title)
            {
                case "未处置":
                    state = StateEnum.Undisposed;
                    break;
                case "已保存":
                    state = StateEnum.Saved;
                    break;
                case "确认中":
                    state = StateEnum.Checking;
                    break;
                case "被拒绝":
                    state = StateEnum.Rejected;
                    break;
                case "已取消":
                    state = StateEnum.Cancel;
                    break;
            }

            return state;
        }

        public static StateEnum ConvertStateValueToEnum(Int32 value)
        {
            StateEnum state = StateEnum.Undisposed;

            switch (value)
            {
                case 1:
                    state = StateEnum.Undisposed;
                    break;
                case 2:
                    state = StateEnum.Saved;
                    break;
                case 3:
                    state = StateEnum.Checking;
                    break;
                case 98:
                    state = StateEnum.Rejected;
                    break;
                case 99:
                    state = StateEnum.Cancel;
                    break;
            }

            return state;
        }
        #endregion

        #region 操作类型枚举
        public enum OperaKindEnum
        {
            /// <summary>
            /// 1 新增
            /// </summary>
            Add = 1,
            /// <summary>
            /// 2 修改
            /// </summary>
            Edit = 2,
            /// <summary>
            /// 3 删除
            /// </summary>
            Remove = 3
        }

        public static String ConvertOperaKindEnumToTitle(OperaKindEnum operaKind)
        {
            String title = "新增";
            switch (operaKind)
            {
                case OperaKindEnum.Add:
                    title = "新增";
                    break;
                case OperaKindEnum.Edit:
                    title = "修改";
                    break;
                case OperaKindEnum.Remove:
                    title = "删除";
                    break;
            }

            return title;
        }

        public static OperaKindEnum ConvertOperaKindTitleToEnum(String title)
        {
            OperaKindEnum operaKind = OperaKindEnum.Add;
            switch (title)
            {
                case "新增":
                    operaKind = OperaKindEnum.Add;
                    break;
                case "修改":
                    operaKind = OperaKindEnum.Edit;
                    break;
                case "删除":
                    operaKind = OperaKindEnum.Remove;
                    break;
            }

            return operaKind;
        }

        public static OperaKindEnum ConvertOperaKindValueToEnum(Int32 value)
        {
            OperaKindEnum kind = OperaKindEnum.Add;

            if (value > 0 && value < 4)
            {
                kind = (OperaKindEnum)value;
            }

            return kind;
        }
        #endregion
    }
}
