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
    public class VegetableInfo
    {
        #region 公共属性

        private String _title = "";

        [DataMember]
        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private String _categoryId = "";

        [DataMember]
        public String CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        private decimal _profitMargin = 0;

        [DataMember]
        public decimal ProfitMargin
        {
            get { return _profitMargin; }
            set { _profitMargin = value; }
        }

        private String _description = "";

        [DataMember]
        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        #endregion
    }
}
