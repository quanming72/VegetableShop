using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Will.VegetableShop.Entities
{
    class PublicObject
    {
    }

    #region 两状态三值枚举
    public enum ThreeStateEnum
    {
        /// <summary>
        ///     忽略，NotSet-1
        /// </summary>
        NotSet = -1,
        /// <summary>
        ///     否，No0
        /// </summary>
        No = 0,
        /// <summary>
        ///     是，Yes1
        /// </summary>
        Yes = 1
    }
    #endregion
}
