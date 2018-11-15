using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Mulaolao.Class
{
   public static  class DateDayRegise
    {
        /// <summary>
        /// 匹配日期格式为yyyyMMdd
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool isDate( TextBox tb )
        {
            //bool res = Regex.IsMatch(tb.Text, @"^(?:(?!0000)[0-9]{4}-(?:(?:0[1-9]|1[0-2])-(?:0[1-9]|1[0-9]|2[0-8])|(?:0[13-9]|1[0-2])-(?:29|30)|(?:0[13578]|1[02])-31)|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)-02-29)$");
            bool res = Regex.IsMatch( tb.Text, @"^(?:(?!0000)[0-9]{4}(?:(?:0[1-9]|1[0-2])(?:0[1-9]|1[0-9]|2[0-8])|(?:0[13-9]|1[0-2])(?:29|30)|(?:0[13578]|1[02])-31)|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00)-02-29)$" );
            return res;
        }
        public static bool PassWords( TextBox tb )
        {
            bool pws = Regex.IsMatch( tb.Text, @"^.{6,15}$" );
            return pws;
        }       
        /// <summary>
        /// 匹配decimal(2,1)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool twoOneNum( ComboBox cb )
        {
            bool res = Regex.IsMatch( cb.Text,@"^(\-)?\d{1,1}(?:\.\d{1,1})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(3,1)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool threeOneNum ( ComboBox cb )
        {
            bool res = Regex. IsMatch ( cb. Text ,@"^(\-)?\d{1,2}(?:\.\d{1,1})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(3,1)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool threeOneNumTb ( TextBox tb )
        {
            bool res = Regex. IsMatch ( tb. Text ,@"^(\-)?\d{1,2}(?:\.\d{1,1})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(3,2)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool threeTwoNum( ComboBox cb )
        {
            bool res = Regex.IsMatch( cb.Text,@"^(\-)?\d{1,1}(?:\.\d{1,2})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(3,2)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool threeTwoNumTb ( TextBox tb )
        {
            bool res = Regex. IsMatch ( tb. Text ,@"^(\-)?\d{1,1}(?:\.\d{1,2})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(4,1)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool foreOneNum( ComboBox cb )
        {
            bool res = Regex.IsMatch( cb.Text,@"^(\-)?\d{1,3}(?:\.\d{1,1})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(4,1)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool foreOneNum ( TextBox cb )
        {
            bool res = Regex.IsMatch( cb.Text ,@"^(\-)?\d{1,3}(?:\.\d{1,1})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(4,3)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool foreThreeNum( ComboBox cb )
        {
            bool res = Regex.IsMatch( cb.Text,@"^(\-)?\d{1,1}(?:\.\d{1,3})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(4,3)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool foreThreeNum ( TextBox cb )
        {
            bool res = Regex . IsMatch ( cb . Text ,@"^(\-)?\d{1,1}(?:\.\d{1,3})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(4,2)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool foreTwoNum( ComboBox cb )
        {
            bool res = Regex.IsMatch( cb.Text,@"^(\-)?\d{1,2}(?:\.\d{1,2})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(4,2)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool foreTwoNum ( TextBox cb )
        {
            bool res = Regex.IsMatch( cb.Text ,@"^(\-)?\d{1,2}(?:\.\d{1,2})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(5,1)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool fiveForNum ( TextBox cb )
        {
            bool res = Regex.IsMatch( cb.Text ,@"^(\-)?\d{1,4}(?:\.\d{1,1})?$" );
            return res;
        }
        public static bool fiveForNum ( ComboBox cb )
        {
            bool res = Regex.IsMatch( cb.Text ,@"^(\-)?\d{1,4}(?:\.\d{1,1})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(5,2)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool fiveTwoNum ( ComboBox cb )
        {
            bool res = Regex. IsMatch ( cb. Text ,@"^(\-)?\d{1,3}(?:\.\d{1,2})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(5,2)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool fiveTwoNum ( TextBox tb )
        {
            bool res = Regex.IsMatch( tb.Text ,@"^(\-)?\d{1,3}(?:\.\d{1,2})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(5,3)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool fiveThreeNum( ComboBox cb )
        {
            bool res = Regex.IsMatch( cb.Text,@"^(\-)?\d{1,2}(?:\.\d{1,3})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(5,3)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool fiveThreeNumtb ( TextBox tb )
        {
            bool res = Regex. IsMatch ( tb. Text ,@"^(\-)?\d{1,2}(?:\.\d{1,3})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(5,4)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool fiveOneNum ( ComboBox cb )
        {
            bool res = Regex. IsMatch ( cb. Text ,@"^(\-)?\d{1,1}(?:\.\d{1,4})?$" );
            return res;
        }              
        /// <summary>
        /// 匹配decimal(5,4)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool fiveFoureNum( ComboBox cb )
        {
            bool res = Regex.IsMatch( cb.Text,@"^(\-)?\d{1,1}(?:\.\d{1,4})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(5,1)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool fiveOneNum ( TextBox tb )
        {
            bool res = Regex.IsMatch( tb.Text ,@"^(\-)?\d{1,4}(?:\.\d{1,1})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(6,2)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool sixTwoNumber( TextBox tb )
        {
            bool res = Regex.IsMatch( tb.Text,@"^(\-)?\d{1,4}(?:\.\d{1,2})?$" );
            return res;
        }
        /// <summary>
         /// 匹配decimal(6,2)
         /// </summary>
         /// <param name="cb"></param>
         /// <returns></returns>
        public static bool sixTwoNumberCb( ComboBox cb )
        {
            bool res = Regex.IsMatch( cb.Text,@"^(\-)?\d{1,4}(?:\.\d{1,2})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(6,3)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool sixThrNumberCb ( ComboBox cb )
        {
            bool res = Regex.IsMatch( cb.Text ,@"^(\-)?\d{1,3}(?:\.\d{1,3})?$" );
            return res;
        }
        public static bool sixThrNumberCb ( TextBox cb )
        {
            bool res = Regex.IsMatch( cb.Text ,@"^(\-)?\d{1,3}(?:\.\d{1,3})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(6,4)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool sixFour( ComboBox cb )
        {
            bool res = Regex.IsMatch( cb.Text,@"^(\-)?\d{1,2}(?:\.\d{1,4})?$" );
            return res;
        }
        /// <summary>
         /// 匹配decimal(6,1)
         /// </summary>
         /// <param name="cb"></param>
         /// <returns></returns>
        public static bool sixOne( ComboBox cb )
        {
            bool res = Regex.IsMatch( cb.Text,@"^(\-)?\d{1,5}(?:\.\d{1,1})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(7,1)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool sevenOne ( TextBox cb )
        {
            bool res = Regex.IsMatch( cb.Text ,@"^(\-)?\d{1,6}(?:\.\d{1,1})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(7,2)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool sevenTwo ( ComboBox cb )
        {
            bool res = Regex.IsMatch( cb.Text ,@"^(\-)?\d{1,5}(?:\.\d{1,2})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(7,2)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool sevenTwo ( TextBox cb )
        {
            bool res = Regex.IsMatch( cb.Text ,@"^(\-)?\d{1,5}(?:\.\d{1,2})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(7,3)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool sevenThr ( ComboBox cb )
        {
            bool res = Regex.IsMatch( cb.Text ,@"^(\-)?\d{1,4}(?:\.\d{1,3})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(7,4)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool sevenFour( ComboBox cb )
        {
            bool res = Regex.IsMatch( cb.Text,@"^(\-)?\d{1,3}(?:\.\d{1,4})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(7,4)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool sevenFourTb ( TextBox tb )
        {
            bool res = Regex.IsMatch( tb.Text ,@"^(\-)?\d{1,3}(?:\.\d{1,4})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(7,5)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool sevenFivTb ( TextBox tb ,int n)
        {
            bool res = Regex.IsMatch( tb.Text ,@"^(\-)?\d{1,2}(?:\.\d{1,5})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(7,6)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool sevenSixTb ( TextBox tb )
        {
            bool res = Regex.IsMatch( tb.Text ,@"^(\-)?\d{1,1}(?:\.\d{1,6})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(8,2)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool eightTwoNumber ( TextBox tb )
        {
            bool res = Regex.IsMatch( tb.Text ,@"^(\-)?\d{1,6}(?:\.\d{1,2})?$" );
            return res;
        }
        /// <summary>
         /// 匹配decimal(8,2)
         /// </summary>
         /// <param name="cb"></param>
         /// <returns></returns>
        public static bool eightTwoNumber ( ComboBox cb )
        {
            bool res = Regex.IsMatch( cb.Text ,@"^(\-)?\d{1,6}(?:\.\d{1,2})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(8,4)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool eightFourNumber ( ComboBox cb )
        {
            bool res = Regex.IsMatch( cb.Text ,@"^(\-)?\d{1,4}(?:\.\d{1,4})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(8,5)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool eightFiveNumber( TextBox tb )
        {
            bool res = Regex.IsMatch( tb.Text,@"^(\-)?\d{1,3}(?:\.\d{1,5})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(8,6)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool eightSix( ComboBox cb )
        {
            bool res = Regex.IsMatch( cb.Text,@"^(\-)?\d{1,2}(?:\.\d{1,6})?$" );
            return res;
        }
        /// <summary>
         /// 匹配decimal(8,6)
         /// </summary>
         /// <param name="tb"></param>
         /// <returns></returns>
        public static bool eightSixTb ( TextBox tb )
        {
            bool res = Regex. IsMatch ( tb. Text ,@"^(\-)?\d{1,2}(?:\.\d{1,6})?$" );
            return res;
        }
        /// <summary>
         /// 匹配decimal(9,5)
         /// </summary>
         /// <param name="tb"></param>
         /// <returns></returns>
        public static bool ninFivTb ( ComboBox tb )
        {
            bool res = Regex.IsMatch( tb.Text ,@"^(\-)?\d{1,4}(?:\.\d{1,5})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(9,2)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool ninTwoTb ( TextBox tb )
        {
            bool res = Regex.IsMatch( tb.Text ,@"^(\-)?\d{1,7}(?:\.\d{1,2})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(9,5)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool ninFivTb ( TextBox tb )
        {
            bool res = Regex.IsMatch( tb.Text ,@"^(\-)?\d{1,4}(?:\.\d{1,5})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(9,7)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool ninSevTb ( TextBox tb )
        {
            bool res = Regex.IsMatch( tb.Text ,@"^(\-)?\d{1,2}(?:\.\d{1,7})?$" );
            return res;
        }
        /// <summary>
        /// 匹配正整数
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool Num( ComboBox cb )
        {
            bool res = Regex.IsMatch( cb.Text, @"(^[1-9]\d*$)" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(10,1)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool tenOneNumber ( TextBox tb )
        {
            bool res = Regex.IsMatch( tb.Text ,@"^(\-)?\d{1,9}(?:\.\d{1,1})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(10,1)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool tenOneNumber ( ComboBox tb )
        {
            bool res = Regex . IsMatch ( tb . Text ,@"^(\-)?\d{1,9}(?:\.\d{1,1})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(10,2)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool tenTwoNumber ( TextBox tb )
        {
            bool res = Regex. IsMatch ( tb. Text ,@"^(\-)?\d{1,8}(?:\.\d{1,2})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(10,3)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool tenThrNumber ( TextBox tb )
        {
            bool res = Regex.IsMatch( tb.Text ,@"^(\-)?\d{1,7}(?:\.\d{1,3})?$" );
            return res;
        }
        /// <summary>
         /// 匹配decimal(10,4)
         /// </summary>
         /// <param name="tb"></param>
         /// <returns></returns>
        public static bool tenForNumber ( TextBox tb )
        {
            bool res = Regex.IsMatch( tb.Text ,@"^(\-)?\d{1,6}(?:\.\d{1,4})?$" );
            return res;
        } 
        /// 匹配decimal(10,4)
          /// </summary>
          /// <param name="tb"></param>
          /// <returns></returns>
        public static bool tenForNumber ( ComboBox tb )
        {
            bool res = Regex.IsMatch( tb.Text ,@"^(\-)?\d{1,6}(?:\.\d{1,4})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(11,1)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool elevenOneNumber ( TextBox tb )
        {
            bool res = Regex.IsMatch( tb.Text ,@"^(\-)?\d{1,10}(?:\.\d{1,1})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(11,2)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool elevenTwoNumber ( TextBox tb )
        {
            bool res = Regex.IsMatch( tb.Text ,@"^(\-)?\d{1,9}(?:\.\d{1,2})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(11,3)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool elevenTreNumber ( TextBox tb )
        {
            bool res = Regex . IsMatch ( tb . Text ,@"^(\-)?\d{1,8}(?:\.\d{1,3})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(11,4)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool elevenForNumber ( TextBox tb )
        {
            bool res = Regex.IsMatch( tb.Text ,@"^(\-)?\d{1,7}(?:\.\d{1,4})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(11,4)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool elevenForNumber ( ComboBox tb )
        {
            bool res = Regex . IsMatch ( tb . Text ,@"^(\-)?\d{1,7}(?:\.\d{1,4})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(11,6)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool elevenSixNumber ( TextBox tb )
        {
            bool res = Regex . IsMatch ( tb . Text ,@"^\d{1,5}(?:\.\d{1,6})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(11,6)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool elevenSixNumber ( ComboBox tb )
        {
            bool res = Regex . IsMatch ( tb . Text ,@"^\d{1,5}(?:\.\d{1,6})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(12,4)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool twelveFourNumber ( TextBox tb )
        {
            bool res = Regex.IsMatch( tb.Text ,@"^(\-)?\d{1,5}(?:\.\d{1,7})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(12,4)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool twelveFourNumber ( ComboBox tb )
        {
            bool res = Regex.IsMatch( tb.Text ,@"^(\-)?\d{1,5}(?:\.\d{1,7})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(12,7)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool twelveSevenNumber ( TextBox tb )
        {
            bool res = Regex.IsMatch( tb.Text ,@"^(\-)?\d{1,5}(?:\.\d{1,7})?$" );
            return res;
        }

        /// <summary>
        /// 匹配decimal(13,10)
        /// </summary>
        /// <param name="tb"></param>
        /// <returns></returns>
        public static bool thirteenTenNum ( TextBox tb )
        {
            bool res = Regex.IsMatch( tb.Text ,@"^(\-)?\d{1,3}(?:\.\d{1,10})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(18,6)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool eighteenSixNumber ( ComboBox cb )
        {
            bool res = Regex . IsMatch ( cb . Text ,@"^(\-)?\d{1,12}(?:\.\d{1,6})?$" );
            return res;
        }
        /// <summary>
        /// 匹配decimal(18,6)
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool eighteenSixNumber ( TextBox tb )
        {
            bool res = Regex . IsMatch ( tb . Text ,@"^(\-)?\d{1,12}(?:\.\d{1,6})?$" );
            return res;
        }
        /*
        正则:http://blog.csdn.net/onebigday/article/details/5429868
        ^[1-9]d*$　 　 //匹配正整数
　　    ^-[1-9]d*$ 　 //匹配负整数
　　    ^-?[1-9]d*$　　 //匹配整数
　　    ^[1-9]d*|0$　 //匹配非负整数（正整数 + 0）
　　    ^-[1-9]d*|0$　　 //匹配非正整数（负整数 + 0）
　　    ^[1-9]d*.d*|0.d*[1-9]d*$　　 //匹配正浮点数
　　    ^-([1-9]d*.d*|0.d*[1-9]d*)$　 //匹配负浮点数
　　    ^-?([1-9]d*.d*|0.d*[1-9]d*|0?.0+|0)$　 //匹配浮点数
　　    ^[1-9]d*.d*|0.d*[1-9]d*|0?.0+|0$　　 //匹配非负浮点数（正浮点数 + 0）
　　    ^(-([1-9]d*.d*|0.d*[1-9]d*))|0?.0+|0$　　//匹配非正浮点数（负浮点数 + 0） 
        */
        /// <summary>
        /// 匹配整数以及小数
        /// </summary>
        /// <param name="str">变量</param>
        /// <returns></returns>
        public static bool NumsXiao( ComboBox cb )
        {
            bool res = Regex.IsMatch( cb.Text, @"(?<!\d|^)([1-9]\d+|\d)(\.\d+)?((?!\d)|$)" );
            return res;
        }
        /// <summary>
        /// 匹配整数以及小数
        /// </summary>
        /// <param name="str">变量</param>
        /// <returns></returns>
        public static bool NumXiao( string str )
        {
            bool res = Regex.IsMatch( str, @"(?<!\d|^)([1-9]\d+|\d)(\.\d+)?((?!\d)|$)" );
            return res;
        }
        /// <summary>
        /// 匹配汉字
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public static bool hanZi( ComboBox cb )
        {
            bool res = Regex.IsMatch( cb.Text, @"^[\u4E00-\u9FA5]+$" );
            return res;
        }



        /// <summary>
        /// 键盘输入整数验证
        /// </summary>
        /// <param name="e">键盘按下</param>
        public static void intgra ( KeyPressEventArgs e )
        {
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && e. KeyChar != 8 && e.KeyChar != 45 )
            {
                e. Handled = true;
                MessageBox. Show ( "只允许输入整数" );
            }
        }
        /// <summary>
        /// 键盘输入小数验证
        /// </summary>
        /// <param name="e">键盘按下</param>
        /// <param name="cb">Combobox</param>
        public static void fractionCb ( KeyPressEventArgs e ,ComboBox cb)
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 && e.KeyChar != 45 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if ( e.KeyChar != 45 && char. IsPunctuation ( e. KeyChar ) )
            {
                if ( cb. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        /// <summary>
        /// 键盘输入小数验证
        /// </summary>
        /// <param name="e">键盘按下</param>
        /// <param name="tb">Textbox</param>
        public static void fractionTb ( KeyPressEventArgs e , TextBox tb )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ( ( e. KeyChar < 48 || e. KeyChar > 57 ) && ( e. KeyChar != 46 ) && e. KeyChar != 8 && e.KeyChar != 45 )
            {
                MessageBox. Show ( "请输入数字" );
                e. Handled = true;
            }
            else if (e.KeyChar!=45 && char. IsPunctuation ( e. KeyChar ) )
            {
                if ( tb. Text. LastIndexOf ( '.' ) != -1 )
                {
                    e. Handled = true;
                    MessageBox. Show ( "只能输入一个小数点" );
                }
            }
        }
        /// <summary>
        /// 若第一位是小数点则为0.
        /// </summary>
        /// <param name="tb">Textbox</param>
        public static void textChangeTb (TextBox tb )
        {
            if ( tb. Text. Substring ( 0 ) == "." )
            {
                tb. Text = "0.";
                tb. SelectionStart = 2;
            }
            if ( tb.Text.Contains( "-" ) && tb.Text.Substring( 0 ,1 ) != "-" )
            {
                tb.Text = "";
                MessageBox.Show( "负号只能在第一位" );
            }
        }
        /// <summary>
        /// 若第一位是小数点则为0.
        /// </summary>
        /// <param name="cb">Textbox</param>
        public static void textChangeCb ( ComboBox cb )
        {
            if ( cb. Text. Substring ( 0 ) == "." )
            {
                cb. Text = "0.";
                cb. SelectionStart = 2;
            }
            if ( cb.Text.Contains( "-" ) && cb.Text.Substring( 0 ,1 ) != "-" )
            {
                cb.Text = "";
                MessageBox.Show( "负号只能在第一位" );
            }
        }

        /// <summary>
        /// 填充不足的小数位
        /// </summary>
        /// <param name="box">TextBox</param>
        public static void fill ( TextBox box )
        {
            if ( box.Text.IndexOf( "." ) >= 0 )
            {
                string[] str = box.Text.Split( '.' );
                if ( str[1].Length == 1 )
                    box.Text = box.Text + "0";
            }
            else
            {
                box.Text = box.Text + ".00";
            }
        }/// <summary>
         /// 填充不足的小数位  两位小数
         /// </summary>
         /// <param name="box">TextBox</param>
        public static void fill ( ComboBox box )
        {
            if ( box.Text.IndexOf( "." ) >= 0 )
            {
                string[] str = box.Text.Split( '.' );
                if ( str[1].Length == 1 )
                    box.Text = box.Text + "0";
            }
            else
            {
                box.Text = box.Text + ".00";
            }
        }
        /// 填充不足的小数位  三位小数
         /// </summary>
         /// <param name="box">TextBox</param>
        public static void fills ( ComboBox box )
        {
            if ( box.Text.IndexOf( "." ) >= 0 )
            {
                string[] str = box.Text.Split( '.' );
                if ( str[1].Length == 1 )
                    box.Text = box.Text + "0";
            }
            else
            {
                box.Text = box.Text + ".000";
            }
        }
    }
}
