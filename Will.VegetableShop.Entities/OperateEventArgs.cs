using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Will.VegetableShop.Entities
{
    [DataContract]
    public class OperateEventArgs
    {
        private Int32 _id = -1;

        /// <summary>
        ///     操作对象的数值型ID，默认为-1
        /// </summary>
        [DataMember]
        public Int32 Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private String _GUID = "";

        /// <summary>
        ///     操作对象的字符型ID，例如GUID，默认为空字符串
        /// </summary>
        [DataMember]
        public String GUID
        {
            get { return _GUID; }
            set { _GUID = value; }
        }

        private String _errorString = "未定义错误";

        /// <summary>
        ///     操作错误信息，默认为“未定义错误”，操作成功时请置为空字符串
        /// </summary>
        [DataMember]
        public String ErrorString
        {
            get { return _errorString; }
            set { _errorString = value; }
        }

        private Boolean _operateSuccess = false;

        /// <summary>
        ///     操作是否成功，默认为flase，操作成功时请置为true。
        /// </summary>
        [DataMember]
        public Boolean OperateSuccess
        {
            get { return _operateSuccess; }
            set { _operateSuccess = value; }
        }

        private Exception _errorException = null;

        /// <summary>
        ///     操作捕获的异常
        /// </summary>
        [DataMember]
        public Exception ErrorException
        {
            get { return _errorException; }
            set { _errorException = value; }
        }

        private Object _otherInfo = null;

        /// <summary>
        ///     其他需要提供的数据
        /// </summary>
        [DataMember]
        public Object OtherInfo
        {
            get { return _otherInfo; }
            set { _otherInfo = value; }
        }

        private String _otherInfoJson = "";

        [DataMember]
        public String OtherInfoJson
        {
            get { return _otherInfoJson; }
            set { _otherInfoJson = value; }
        }

        private Int32 _errorCode = -1;

        [DataMember]
        public Int32 ErrorCode
        {
            get { return _errorCode; }
            set { _errorCode = value; }
        }

        private Int32 _dealCount = 0;

        /// <summary>
        ///     处理总数
        /// </summary>
        [DataMember]
        public Int32 DealCount
        {
            get { return _dealCount; }
            set { _dealCount = value; }
        }

        private Int32 _successCount = 0;

        /// <summary>
        ///     处理成功数
        /// </summary>
        [DataMember]
        public Int32 SuccessCount
        {
            get { return _successCount; }
            set { _successCount = value; }
        }

        private Int32 _failCount = 0;

        /// <summary>
        ///     处理失败数
        /// </summary>
        [DataMember]
        public Int32 FailCount
        {
            get { return _failCount; }
            set { _failCount = value; }
        }

    }
}
