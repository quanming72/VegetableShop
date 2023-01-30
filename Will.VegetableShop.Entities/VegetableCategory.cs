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
    ///     蔬菜分类基础类
    /// </summary>
    /// <table>vegetable_shop</table>
    [DataContract]
    public class VegetableCategory
    {
        #region 公共属性
        private String _title = "";

        /// <summary>
        ///     标题
        /// </summary>
        /// <field>title</field>
        [DataMember]
        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private String _description = "";

        /// <summary>
        ///     描述
        /// </summary>
        /// <field>description</field>
        [DataMember]
        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        #endregion
    }
}
