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
    public class VegetableCategoryView : VegetableCategory
    {
        #region 公共属性
        private String _categoryId = "";

        /// <summary>
        ///     GUID
        /// </summary>
        /// <field>category_id</field>
        [DataMember]
        public String CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        private Boolean _activityState = true;

        /// <summary>
        ///     活动性，0禁用，1活动，默认1
        /// </summary>
        /// <field>is_activity</field>
        [DataMember]
        public Boolean ActivityState
        {
            get { return _activityState; }
            set { _activityState = value; }
        }

        private DateTime _inputTime = DateTime.Now;

        /// <summary>
        ///     登记时间
        /// </summary>
        /// <field>input_time</field>
        [DataMember]
        public DateTime InputTime
        {
            get { return _inputTime; }
            set { _inputTime = value; }
        }

        #endregion

        #region 生成实例
        public static VegetableCategoryView CreateViewInstance(DataRow dr)
        {
            VegetableCategoryView instance = null;

            if (dr != null)
            {
                instance = new VegetableCategoryView();

                instance.CategoryId = dr["Category_Id"].ToString();
                instance.Title = dr["Title"].ToString();
                instance.Description = dr["Description"].ToString();

                Int32 activityStateValue = GetValueUtility.GetInteger(dr["Is_Activity"].ToString(), 1);
                instance.ActivityState = (activityStateValue == 1 ? true : false);

                instance.InputTime = GetValueUtility.GetDateTime(dr["Input_Time"].ToString());
            }

            return instance;
        }
        #endregion

        #region 筛选条件
        [DataContract]
        public class Filter
        {
            private String _categoryId = "";

            /// <summary>
            ///     GUID
            /// </summary>
            /// <field>category_id</field>
            [DataMember]
            public String CategoryId
            {
                get { return _categoryId; }
                set { _categoryId = value; }
            }

            private ThreeStateEnum _activityState = ThreeStateEnum.Yes;

            /// <summary>
            ///     活动性，0禁用，1活动，默认1
            /// </summary>
            /// <field>is_activity</field>
            [DataMember]
            public ThreeStateEnum ActivityState
            {
                get { return _activityState; }
                set { _activityState = value; }
            }

            private String _keywords = "";

            /// <summary>
            ///     关键字，通过Title模糊搜索
            /// </summary>
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
