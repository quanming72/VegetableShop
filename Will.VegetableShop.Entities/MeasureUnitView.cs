using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Data;

namespace Will.VegetableShop.Entities
{
    /// <summary>
    ///     计量单位视图类
    /// </summary>
    /// <table>measure_unit</table>
    [DataContract]
    public class MeasureUnitView : MeasureUnit
    {
        #region 公共属性
        private String _unitId = "";

        [DataMember]
        public String UnitId
        {
            get { return _unitId; }
            set { _unitId = value; }
        }

        private Boolean _isActivity = true;

        [DataMember]
        public Boolean IsActivity
        {
            get { return _isActivity; }
            set { _isActivity = value; }
        }

        private DateTime _inputTime = DateTime.Now;

        [DataMember]
        public DateTime InputTime
        {
            get { return _inputTime; }
            set { _inputTime = value; }
        }

        private DateTime _lastUpdateTime = DateTime.Now;

        [DataMember]
        public DateTime LastUpdateTime
        {
            get { return _lastUpdateTime; }
            set { _lastUpdateTime = value; }
        }
        #endregion

        #region 生成实例
        public static MeasureUnitView CreateViewInstance(DataRow dr)
        {
            MeasureUnitView instance = null;

            if (dr != null)
            {
                instance = new MeasureUnitView();

                instance.Title = dr["Title"].ToString();
                instance.Code = dr["Code"].ToString();
                instance.IsBase = GetValueUtility.GetBoolean(dr["Is_Base"].ToString());

                Int32 kindValue = GetValueUtility.GetInteger(dr["Kind"].ToString());
                instance.Kind = MeasureUnit.ConvertKindValueToEnum(kindValue);

                instance.ToBase = GetValueUtility.GetNumeric(dr["To_Base"].ToString());

                instance.Description = dr["Description"].ToString();
                instance.IsActivity = GetValueUtility.GetBoolean(dr["Is_Activity"].ToString());
                instance.InputTime = GetValueUtility.GetDateTime(dr["Input_Time"].ToString());
                instance.LastUpdateTime = GetValueUtility.GetDateTime(dr["Last_Update_Time"].ToString());
            }

            return instance;
        }
        #endregion

        #region 筛选条件
        [DataContract]
        public class Filter
        {
            private String _unitId = "";

            [DataMember]
            public String UnitId
            {
                get { return _unitId; }
                set { _unitId = value; }
            }

            private ThreeStateEnum _activityState = ThreeStateEnum.Yes;

            [DataMember]
            public ThreeStateEnum ActivityState
            {
                get { return _activityState; }
                set { _activityState = value; }
            }

            private String _code = "";

            [DataMember]
            public String Code
            {
                get { return _code; }
                set { _code = value; }
            }

            private Int32 _kind = -1;

            [DataMember]
            public Int32 Kind
            {
                get { return _kind; }
                set { _kind = value; }
            }

            private ThreeStateEnum _isBase = ThreeStateEnum.NotSet;

            [DataMember]
            public ThreeStateEnum IsBase
            {
                get { return _isBase; }
                set { _isBase = value; }
            }

            private String _keywords = "";

            [DataMember]
            public String Keywords
            {
                get { return _keywords; }
                set { _keywords = value; }
            }
        }
        #endregion
    }
}
