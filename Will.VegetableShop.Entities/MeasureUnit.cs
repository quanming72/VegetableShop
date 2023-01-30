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
    ///     计量单位类
    /// </summary>
    /// <table>measure_unit</table>
    [DataContract]
    public class MeasureUnit
    {
        #region 公共属性
        private String _title = "";

        [DataMember]
        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private String _code = "";

        [DataMember]
        public String Code
        {
            get { return _code; }
            set { _code = value; }
        }

        private KindEnum _kind = KindEnum.Other;

        [DataMember]
        public KindEnum Kind
        {
            get { return _kind; }
            set { _kind = value; }
        }

        private Boolean _isBase = false;

        [DataMember]
        public Boolean IsBase
        {
            get { return _isBase; }
            set { _isBase = value; }
        }

        private decimal _toBase = 1;

        [DataMember]
        public decimal ToBase
        {
            get { return _toBase; }
            set { _toBase = value; }
        }

        private String _description = "";

        [DataMember]
        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        #endregion

        #region 性质枚举
        /// <summary>
        ///     性质，1长度Length，2面积Area，3体积Space，4容积Capacity，5时间Time，6质量Weight，7力Power，8压力Pressure，9温度Temperature，10能Energy，11功率Capy，12角度Angle，13频率Frequency，14速度Velocity，15计数Count，99其他Other
        /// </summary>
        public enum KindEnum
        {
            /// <summary>
            ///     1长度Length
            /// </summary>
            Length=1,
            /// <summary>
            ///     2面积Area
            /// </summary>
            Area = 2,
            /// <summary>
            ///     3体积Space
            /// </summary>
            Space = 3,
            /// <summary>
            ///     4容积Capacity
            /// </summary>
            Capacity = 4,
            /// <summary>
            ///     5时间Time
            /// </summary>
            Time = 5,
            /// <summary>
            ///     6质量Weight
            /// </summary>
            Weight = 6,
            /// <summary>
            ///     7力Power
            /// </summary>
            Power = 7,
            /// <summary>
            ///     8压力Pressure
            /// </summary>
            Pressure = 8,
            /// <summary>
            ///     9温度Temperature
            /// </summary>
            Temperature = 9,
            /// <summary>
            ///     11功率Capy
            /// </summary>
            Energy = 10,
            /// <summary>
            ///     11功率Capy
            /// </summary>
            Capy = 11,
            /// <summary>
            ///     12角度Angle
            /// </summary>
            Angle = 12,
            /// <summary>
            ///     13频率Frequency
            /// </summary>
            Frequency = 13,
            /// <summary>
            ///     14速度Velocity
            /// </summary>
            Velocity = 14,
            /// <summary>
            ///     15计数Count
            /// </summary>
            Count = 15,
            /// <summary>
            ///     99其他Other
            /// </summary>
            Other = 99
        }

        public static String ConvertKindEnumToTitle(KindEnum kind)
        {
            String title = "其他";

            return title;
        }

        public static KindEnum ConvertKindValueToEnum(Int32 value)
        {
            KindEnum kind = KindEnum.Other;

            if (value>0 && value<16)
            {
                kind = (KindEnum)value;
            }

            return kind;
        }
        #endregion
    }
}
