using System.Diagnostics;
using System.Data;
using System.Collections;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System;

namespace Will.VegetableShop.Entities
{
    /// <summary>
    ///     取得指定类型的值
    ///     1、取得逻辑型的值
    ///     2、取得数值型的值
    ///     3、取得整型值
    ///     4、取得日期型的值
    ///     5、处理SQL语句执行插入和修改时字符串中的危险字符
    /// </summary>
    /// <remarks></remarks>
    /// <author>权明</author>
    public class GetValueUtility
    {
        public static bool GetBoolean(string sourceString)
        {
            return GetBoolean(sourceString, false);
        }

        /// <summary>
        ///     通过指定字符串获取一个逻辑值
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <param name="defaultValue">可选参数，当源字符串不合法时的返回值，默认为false</param>
        /// <returns>转换后的值</returns>
        /// <remarks>
        ///     <para>若不合法时的返回值为False，只有当源字符串为True（不区分大小写）或1时返回True，否则返回False</para>
        ///     <para>若不合法时的返回值为True，只有当源字符串为False（不区分大小写）或0时返回False，否则返回True</para>
        /// </remarks>
        /// <author>权明</author>
        public static bool GetBoolean(string sourceString, bool defaultValue)
        {
            bool returnValue;

            if (sourceString == null)
            {
                returnValue = defaultValue;
            }
            else
            {
                if (defaultValue)
                {
                    if (sourceString.ToLower() == "false" || sourceString == "0")
                    {
                        returnValue = false;
                    }
                    else
                    {
                        returnValue = true;
                    }
                }
                else
                {
                    if (sourceString.ToLower() == "true" || sourceString == "1")
                    {
                        returnValue = true;
                    }
                    else
                    {
                        returnValue = false;
                    }

                }
            }

            return returnValue;
        }

        public static decimal GetNumeric(string sourceString)
        {
            return GetNumeric(sourceString, 0);
        }

        /// <summary>
        ///     通过源字符串获取一个数值
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <param name="defaultValue">可选参数，当源字符串不合法时的返回值，默认为0</param>
        /// <returns>获取的数值</returns>
        /// <remarks></remarks>
        /// <author>权明</author>
        public static decimal GetNumeric(string sourceString, decimal defaultValue)
        {
            decimal returnValue;

            if (CheckNumber(sourceString))
            {
                returnValue = Convert.ToDecimal(sourceString);
            }
            else
            {
                returnValue = defaultValue;
            }

            return returnValue;
        }

        public static int GetInteger(string sourceString)
        {
            return (int)(GetNumeric(sourceString, 0));
        }

        /// <summary>
        ///     通过源字符串获取一个整数值
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <param name="defaultValue">可选参数，当源字符串不合法时的返回值，默认为0</param>
        /// <returns>获取的整数值</returns>
        /// <remarks></remarks>
        /// <author>权明</author>
        public static int GetInteger(string sourceString, int defaultValue)
        {
            return (int)(GetNumeric(sourceString, defaultValue));
        }

        public static DateTime GetDateTime(string sourceString)
        {
            return GetDateTime(sourceString, Convert.ToDateTime("1900-1-1"));
        }

        /// <summary>
        ///     通过源字符串获取一个日期时间值
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <param name="defaultValue">可选参数，当源字符串不合法时的返回值，默认为1900-1-1 0:00</param>
        /// <returns>获取的日期时间值</returns>
        /// <remarks></remarks>
        /// <author>权明</author>
        public static DateTime GetDateTime(string sourceString, DateTime defaultValue)
        {
            DateTime returnValue;

            if (Information.IsDate(sourceString))
            {
                returnValue = Convert.ToDateTime(sourceString);
            }
            else
            {
                returnValue = defaultValue;
            }

            return returnValue;
        }

        /// <summary>
        ///     处理SQL插入和修改时字符串值中的危险字符
        /// </summary>
        /// <param name="sourceString">源字符串</param>
        /// <returns>处理过的字符串</returns>
        /// <remarks></remarks>
        /// <author>权明</author>
        public static string GetSqlValueString(string sourceString)
        {
            string returnValue;

            Hashtable canReplaceString = new Hashtable();
            canReplaceString.Add("\'", "\'\'");

            foreach (DictionaryEntry de in canReplaceString)
            {
                sourceString = sourceString.Replace(de.Key.ToString(), de.Value.ToString());
            }

            returnValue = sourceString;

            return returnValue;
        }

        /// <summary>
        /// 验证数字
        /// </summary>
        /// <param name="number">数字内容</param>
        /// <returns>true 验证成功 false 验证失败</returns>
        public static bool CheckNumber(string number)
        {
            if (string.IsNullOrEmpty(number))
            {
                return false;
            }
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^(-)?\d+(\.\d+)?$");
            if (regex.IsMatch(number))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

}
