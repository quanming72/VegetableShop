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
    public class VegetableInfoView : VegetableInfo
    {
        #region 公共属性

        private String _vegetableId = "";

        [DataMember]
        public String VegetableId
        {
            get { return _vegetableId; }
            set { _vegetableId = value; }
        }

        private String _categoryTitle = "";

        [DataMember]
        public String CategoryTitle
        {
            get { return _categoryTitle; }
            set { _categoryTitle = value; }
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

        #endregion

        #region 生成实例
        public static VegetableInfoView CreateViewInstance(DataRow dr)
        {
            VegetableInfoView instance = null;

            if (dr != null)
            {
                instance = new VegetableInfoView();

                instance.VegetableId = dr["Vegetable_Id"].ToString();
                instance.Title = dr["Title"].ToString();
                instance.CategoryId = dr["Category_Id"].ToString();
                instance.CategoryTitle = dr["Category_Title"].ToString();
                instance.ProfitMargin = GetValueUtility.GetNumeric(dr["Profit_Margin"].ToString());
                instance.Description = dr["Description"].ToString();
                instance.IsActivity = GetValueUtility.GetBoolean(dr["Is_Activity"].ToString());
                instance.InputTime = GetValueUtility.GetDateTime(dr["Input_Time"].ToString());
            }

            return instance;
        }
        #endregion

        #region 筛选条件
        [DataContract]
        public class Filter
        {
            private String _vegetableId = "";

            [DataMember]
            public String VegetableId
            {
                get { return _vegetableId; }
                set { _vegetableId = value; }
            }

            private ThreeStateEnum _activityState = ThreeStateEnum.Yes;

            [DataMember]
            public ThreeStateEnum ActivityState
            {
                get { return _activityState; }
                set { _activityState = value; }
            }

            private String _categoryId = "";

            [DataMember]
            public String CategoryId
            {
                get { return _categoryId; }
                set { _categoryId = value; }
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
