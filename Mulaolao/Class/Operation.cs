using System;
using System. Collections. Generic;
using System. Linq;
using System. Text;
using System. Windows. Forms;

namespace Mulaolao. Class
{
   public static class Operation
    {
        private static long _One;
        private static long _Two;
        private static long _Six;
        private static decimal _Thr;
        private static decimal _For;
        private static decimal _Fiv;
        private static string _Sev;
        private static decimal _Egi;
        private static int _Nin;

        private static long One
        {
            get
            {
                return _One;
            }
            set
            {
                _One = value;
            }
        }
        private static long Two
        {
            get
            {
                return _Two;
            }
            set
            {
                _Two = value;
            }
        }
        private static long Six
        {
            get
            {
                return _Six;
            }
            set
            {
                _Six = value;
            }
        }
        private static decimal Thr
        {
            get
            {
                return _Thr;
            }
            set
            {
                _Thr = value;
            }
        }
        private static decimal For
        {
            get
            {
                return _For;
            }
            set
            {
                _For = value;
            }
        }
        private static decimal Fiv
        {
            get
            {
                return _Fiv;
            }
            set
            {
                _Fiv = value;
            }
        }
        private static string Sev
        {
            get
            {
                return _Sev;
            }
            set
            {
                _Sev = value;
            }
        }
        private static decimal Egi
        {
            get
            {
                return _Egi;
            }
            set
            {
                _Egi = value;
            }
        }
        private static int Nin
        {
            get
            {
                return _Nin;
            }
            set
            {
                _Nin = value;
            }
        }

        /// <summary>
        /// 三个数据的乘法运算
        /// </summary>
        /// <param name="tbOne">Textbox Decimal</param>
        /// <param name="tbTwo">Textbox Decimal</param>
        /// <param name="cbThr">ComboBox Int</param>
        /// <returns></returns>
        public static string MultiCb ( TextBox tbOne,TextBox tbTwo,ComboBox cbThr)
        {
            if ( tbOne. Text != "" )
                Thr = Convert. ToDecimal ( tbOne. Text );
            else
                Thr = 0M;
            if ( tbTwo. Text != "" )
                For = Convert. ToDecimal ( tbTwo. Text );
            else
                For = 0M;
            if ( cbThr. Text != "" )
                One = Convert. ToInt64 ( cbThr. Text );
            else
                One = 0;

            return ( Thr * For * One ). ToString ( );
        }
        /// <summary>
        /// 三个数据的乘法运算
        /// </summary>
        /// <param name="tbOne">Textbox decimal</param>
        /// <param name="tbTwo">Textbox decimal</param>
        /// <param name="tbThr">Textbox Int32</param>
        /// <returns></returns>
        public static string MultiTb ( TextBox tbOne , TextBox tbTwo , TextBox tbThr )
        {
            if ( tbOne. Text != "" )
                Thr = Convert. ToDecimal ( tbOne. Text );
            else
                Thr = 0M;
            if ( tbTwo. Text != "" )
                For = Convert. ToDecimal ( tbTwo. Text );
            else
                For = 0M;
            if ( tbThr. Text != "" )
                One = Convert. ToInt64 ( tbThr. Text );
            else
                One = 0;

            return ( Thr * For * One ). ToString ( );
        }
        /// <summary>
        /// 三个数据的乘法运算
        /// </summary>
        /// <param name="tbOne">Textbox decimal</param>
        /// <param name="tbTwo">Textbox decimal</param>
        /// <param name="tbThr">Textbox Int32</param>
        /// <returns></returns>
        public static string MultiTb ( ComboBox tbOne ,ComboBox tbTwo ,ComboBox tbThr )
        {
            if ( tbOne.Text != "" )
                Thr = Convert.ToDecimal( tbOne.Text );
            else
                Thr = 0M;
            if ( tbTwo.Text != "" )
                For = Convert.ToDecimal( tbTwo.Text );
            else
                For = 0M;
            if ( tbThr.Text != "" )
                Fiv = Convert.ToDecimal( tbThr.Text );
            else
                Fiv = 0;

            return Math.Round( Thr * For * Fiv ,3 ).ToString( );
        }
        /// <summary>
        /// 三个数据的加法运算
        /// </summary>
        /// <param name="lbOne">Label decimal</param>
        /// <param name="lbTwo">Label decimal</param>
        /// <param name="lbThr">Label decimal</param>
        /// <returns></returns>
        public static string MultiLb ( Label lbOne , Label lbTwo , Label lbThr )
        {
            if ( lbOne. Text != "" )
                Thr = Convert. ToDecimal ( lbOne. Text );
            else
                Thr = 0M;
            if ( lbTwo. Text != "" )
                For = Convert. ToDecimal ( lbTwo. Text );
            else
                For = 0M;
            if ( lbThr. Text != "" )
                Fiv = Convert. ToDecimal ( lbThr. Text );
            else
                Fiv = 0;

            return ( Thr + For + Fiv ). ToString ( );
        }
        /// <summary>
        /// 两个数据的除法运算
        /// </summary>
        /// <param name="lbOne">Label decimal</param>
        /// <param name="lbTwo">Label decimal</param>
        /// <returns></returns>
        public static string DivisionLb ( Label lbOne , Label lbTwo )
        {
            if ( lbOne. Text != "" && lbOne. Text != "0" )
            {
                Thr = Convert. ToDecimal ( lbOne. Text );
                if ( lbTwo. Text != "" && Convert. ToDecimal ( lbTwo. Text ) > 0 )
                {
                    For = Convert. ToDecimal ( lbTwo. Text );
                    return ( Thr / For ). ToString ( );
                }
                else
                    return 0. ToString ( );
            }
            else
            {
                return 0. ToString ( );
            }         
        }
        /// <summary>
        /// 两个数据的除法运算
        /// </summary>
        /// <param name="lbOne">Label decimal</param>
        /// <param name="lbTwo">Label decimal</param>
        /// <returns></returns>
        public static string DivisionTc ( TextBox boxOne ,ComboBox boxTwo )
        {
            if ( boxOne.Text != "" )
            {
                Thr = Convert.ToDecimal( boxOne.Text );
                if ( boxTwo.Text != "" && Convert.ToDecimal( boxTwo.Text ) > 0 )
                {
                    For = Convert.ToDecimal( boxTwo.Text );
                    return Convert.ToDecimal( ( Thr / For ) ).ToString( );
                }
                else
                    return 0.ToString( );
            }
            else
                return 0.ToString( );
        }
        /// <summary>
        /// 两个数据的除法运算
        /// </summary>
        /// <param name="lbOne">Label decimal</param>
        /// <param name="lbTwo">Label decimal</param>
        /// <returns></returns>
        public static string DivisionTc ( TextBox boxOne ,TextBox boxTwo )
        {
            if ( boxOne.Text != "" )
            {
                Thr = Convert.ToDecimal( boxOne.Text );
                if ( boxTwo.Text != "" && Convert.ToDecimal( boxTwo.Text ) > 0 )
                {
                    For = Convert.ToDecimal( boxTwo.Text );
                    return Convert.ToDecimal( ( Thr / For ) ).ToString( );
                }
                else
                    return 0.ToString( );
            }
            else
                return 0.ToString( );
        }
        /// <summary>
        /// 多个数据的加法运算
        /// </summary>
        /// <param name="tbs">TextBox  集合</param>
        /// <returns></returns>
        public static string MultiTbs ( List<TextBox> tbs )
        {
            decimal sum = 0M;
            foreach ( TextBox tb in tbs )
            {
                if ( tb. Text != "" )
                {
                    Thr = Convert. ToDecimal ( tb. Text );
                    sum = sum + Thr;
                }
                else
                    Thr = 0M;               
            }
            return sum. ToString ( );
        }
        /// <summary>
        /// 多个数据的加法运算
        /// </summary>
        /// <param name="lbs">Label 集合</param>
        /// <returns></returns>
        public static string MultiLbs ( List<Label> lbs )
        {
            decimal sum = 0M;
            foreach ( Label lb in lbs )
            {
                if ( lb. Text != "" )
                {
                    Thr = Convert. ToDecimal ( lb. Text );
                    sum = sum + Thr;
                }
                else
                    Thr = 0M;
            }
            return sum. ToString ( );
        }
        /// <summary>
        /// 判断实际考勤天数
        /// </summary>
        /// <param name="tbs">TextBox  集合</param>
        /// <returns></returns>
        public static string MultiTbc ( List<TextBox> tbs )
        {
            int sum = 0;
            foreach ( TextBox tb in tbs )
            {
                if ( tb. Text != "" && tb. Text != "0" )
                {
                    sum++;
                }
            }
            return sum. ToString ( );
        }
        /// <summary>
        /// 两个数据的乘法运算
        /// </summary>
        /// <param name="boxOne">TextBox</param>
        /// <param name="boxTwo">TextBox</param>
        /// <returns></returns>
        public static string MultiTwoTb ( TextBox boxOne ,TextBox boxTwo)
        {
            if ( !string.IsNullOrEmpty(boxOne.Text) )
                For = Convert.ToDecimal( boxOne.Text );
            else
                For = 0;
            if (!string.IsNullOrEmpty( boxTwo.Text) )
                Thr = Convert.ToDecimal( boxTwo.Text );
            else
                Thr = 0;
           
            return ( For * Thr ).ToString( );
        }
        /// <summary>
        /// 两个数据的乘法运算
        /// </summary>
        /// <param name="boxOne">TextBox</param>
        /// <param name="boxTwo">TextBox</param>
        /// <returns></returns>
        public static string MultiTwoTbs ( TextBox boxOne ,TextBox boxTwo )
        {
            if ( !string.IsNullOrEmpty( boxOne.Text ) )
                One = Convert.ToInt64( boxOne.Text );
            else
                One = 0;
            if ( !string.IsNullOrEmpty( boxTwo.Text ) )
                Two = Convert.ToInt64( boxTwo.Text );
            else
                Two = 0;

            return ( One * Two ).ToString( );
        }
        /// <summary>
        /// 两个数据的乘法运算
        /// </summary>
        /// <param name="boxOne">TextBox</param>
        /// <param name="boxTwo">TextBox</param>
        /// <returns></returns>
        public static string MultiTwoTbes ( TextBox boxOne ,TextBox boxTwo )
        {
            if ( !string.IsNullOrEmpty( boxOne.Text ) )
                One = Convert.ToInt64( boxOne.Text );
            else
                One = 0;
            if ( !string.IsNullOrEmpty( boxTwo.Text ) )
                Thr = Convert.ToDecimal( boxTwo.Text );
            else
                Thr = 0;

            return ( One * Thr ).ToString( );
        }
        /// <summary>
        /// 两个数据的乘法运算
        /// </summary>
        /// <param name="boxOne">TextBox</param>
        /// <param name="boxTwo">TextBox</param>
        /// <returns></returns>
        public static string MultiTwoTbCbes ( TextBox boxOne ,ComboBox boxTwo )
        {
            if ( !string.IsNullOrEmpty( boxOne.Text ) )
                One = Convert.ToInt64( boxOne.Text );
            else
                One = 0;
            if ( !string.IsNullOrEmpty( boxTwo.Text ) )
                Thr = Convert.ToDecimal( boxTwo.Text );
            else
                Thr = 0;

            return ( One * Thr ).ToString( );
        }
        /// <summary>
        /// 两个数据的减法运算
        /// </summary>
        /// <param name="boxOne">TextBox</param>
        /// <param name="boxTwo">TextBox</param>
        /// <returns></returns>
        public static string MultiTTb ( TextBox boxOne ,TextBox boxTwo )
        {
            if ( !string.IsNullOrEmpty( boxOne.Text ) )
                One = Convert.ToInt64( boxOne.Text );
            else
                One = 0;
            if ( !string.IsNullOrEmpty( boxTwo.Text ) )
                Two = Convert.ToInt64( boxTwo.Text );
            else
                Two = 0;

            return ( One - Two ).ToString( );
        }
        /// <summary>
        /// 四个数据的乘法运算
        /// </summary>
        /// <param name="OnePa">开票数量</param>
        /// <param name="TwoPa">产品单价</param>
        /// <param name="TrePa">开票汇率</param>
        /// <param name="ForPa">美金单价</param>
        /// <returns></returns>
        public static string MultiForTbCbes ( string OnePa,string TwoPa,string TrePa,string ForPa )
        {
            if ( !string.IsNullOrEmpty( OnePa ) )
                One = Convert.ToInt64( OnePa );
            else
                One = 0;
            if ( !string.IsNullOrEmpty( TwoPa ) )
                Thr = Convert.ToDecimal( TwoPa );
            else
                Thr = 0;
            if ( !string.IsNullOrEmpty( TrePa ) )
                For = Convert.ToDecimal( TrePa );
            else
                For = 0;
            if ( !string.IsNullOrEmpty( ForPa ) )
                Fiv = Convert.ToDecimal( ForPa );
            else
                Fiv = 0;

            return ( For != 0 ? One * For * Fiv : One * Thr ).ToString( );
        }
        /// <summary>
        /// 三个数据的先乘后加运算
        /// </summary>
        /// <param name="boxOne">TextBox</param>
        /// <param name="boxTwo">TextBox</param>
        /// <returns></returns>
        public static string MultiTwoTAdd ( TextBox boxOne ,TextBox boxTwo,ComboBox boxTre )
        {
            if ( !string.IsNullOrEmpty( boxOne.Text ) )
                One = Convert.ToInt64( boxOne.Text );
            else
                One = 0;
            if ( !string.IsNullOrEmpty( boxTwo.Text ) )
                Thr = Convert.ToDecimal( boxTwo.Text );
            else
                Thr = 0;
            if ( !string.IsNullOrEmpty( boxTre.Text ) )
                Fiv = Convert.ToDecimal( boxTre.Text );
            else
                Fiv = 0;
            return ( One * Thr + Fiv ).ToString( );
        }
        /// <summary>
        /// 三个数据的先乘后加运算
        /// </summary>
        /// <param name="boxOne">TextBox</param>
        /// <param name="boxTwo">TextBox</param>
        /// <returns></returns>
        public static string MultiTwoTAdd ( TextBox boxOne ,ComboBox boxTwo ,ComboBox boxTre )
        {
            if ( !string.IsNullOrEmpty( boxOne.Text ) )
                One = Convert.ToInt64( boxOne.Text );
            else
                One = 0;
            if ( !string.IsNullOrEmpty( boxTwo.Text ) )
                Thr = Convert.ToDecimal( boxTwo.Text );
            else
                Thr = 0;
            if ( !string.IsNullOrEmpty( boxTre.Text ) )
                Fiv = Convert.ToDecimal( boxTre.Text );
            else
                Fiv = 0;
            return ( One * Thr + Fiv ).ToString( );
        }
        /// <summary>
        /// 三个数据的先除后减运算
        /// </summary>
        /// <param name="boxOne">TextBox 产品数量</param>
        /// <param name="boxTwo">ComboBox 每套用量</param>
        /// <param name="boxThr">TextBox 剩余库存数量</param>
        /// <returns></returns>
        public static string MultiThrTbCb ( TextBox boxOne ,ComboBox boxTwo,string boxThr )
        {
            if ( !string.IsNullOrEmpty( boxThr ) )
                Fiv = Convert.ToDecimal( boxThr );
            else
                Fiv = 0;
            if ( !string.IsNullOrEmpty( boxOne.Text ) )
                One = Convert.ToInt64( boxOne.Text );
            else
                One = 0;
            if ( !string.IsNullOrEmpty( boxTwo.Text ) )
                For = Convert.ToDecimal( boxTwo.Text );
            else
                For = 0;

            if ( For == 0 && Fiv == 0 )
                Sev = 0.ToString( );
            else if ( For == 0 && Fiv != 0 )
                Sev = ( -Fiv ).ToString( );
            else if ( For != 0 && Fiv == 0 )
                Sev = Convert.ToDecimal( ( One / For ) ).ToString( );
            else if ( For != 0 && Fiv != 0 )
                Sev = Convert.ToDecimal( ( One / For - Fiv ) ).ToString( );

            return Sev;
        }
        /// <summary>
        /// 三个数据的先乘后减运算
        /// </summary>
        /// <param name="boxOne">TextBox</param>
        /// <param name="boxTwo">ComboBox</param>
        /// <param name="boxThr">TextBox</param>
        /// <returns></returns>
        public static string MultiThrTbCb ( TextBox boxOne ,TextBox boxTwo ,string boxThr )
        {
            if ( !string.IsNullOrEmpty( boxThr ) )
                For = Convert.ToDecimal( boxThr );
            else
                For = 0;
            if ( !string.IsNullOrEmpty( boxOne.Text ) )
                One = Convert.ToInt64( boxOne.Text );
            else
                One = 0;
            if ( !string.IsNullOrEmpty( boxTwo.Text ) )
                Thr = Convert.ToDecimal( boxTwo.Text );
            else
                Thr = 0;

            return ( One * Thr - For ).ToString( );
        }
        /// <summary>
        /// 三个数据的先乘后减运算
        /// </summary>
        /// <param name="boxOne">TextBox</param>
        /// <param name="boxTwo">ComboBox</param>
        /// <param name="boxThr">TextBox</param>
        /// <returns></returns>
        public static string MultiThrTbC ( TextBox boxOne ,ComboBox boxTwo ,string boxThr )
        {
            if ( !string.IsNullOrEmpty( boxThr ) )
                For = Convert.ToDecimal( boxThr );
            else
                For = 0;
            if ( !string.IsNullOrEmpty( boxOne.Text ) )
                One = Convert.ToInt64( boxOne.Text );
            else
                One = 0;
            if ( !string.IsNullOrEmpty( boxTwo.Text ) )
                Thr = Convert.ToDecimal( boxTwo.Text );
            else
                Thr = 0;

            return ( One * Thr - For ).ToString( );
        }
        public static string MultiThrTbCs ( TextBox boxOne ,ComboBox boxTwo ,string boxThr )
        {
            if ( !string . IsNullOrEmpty ( boxThr ) )
                For = Convert . ToDecimal ( boxThr );
            else
                For = 0;
            if ( !string . IsNullOrEmpty ( boxOne . Text ) )
                Fiv = Convert . ToDecimal ( boxOne . Text );
            else
                Fiv = 0;
            if ( !string . IsNullOrEmpty ( boxTwo . Text ) )
                Thr = Convert . ToDecimal ( boxTwo . Text );
            else
                Thr = 0;

            return ( Fiv * Thr - For ) . ToString ( );
        }
        public static string MultiThrTbCs ( TextBox boxOne ,TextBox boxTwo ,string boxThr )
        {
            if ( !string . IsNullOrEmpty ( boxThr ) )
                For = Convert . ToDecimal ( boxThr );
            else
                For = 0;
            if ( !string . IsNullOrEmpty ( boxOne . Text ) )
                Fiv = Convert . ToDecimal ( boxOne . Text );
            else
                Fiv = 0;
            if ( !string . IsNullOrEmpty ( boxTwo . Text ) )
                Thr = Convert . ToDecimal ( boxTwo . Text );
            else
                Thr = 0;

            return ( Fiv * Thr - For ) . ToString ( );
        }
        /// <summary>
        /// 四个数据的先乘后加再减运算
        /// </summary>
        /// <param name="boxOne">TextBox</param>
        /// <param name="boxTwo">ComboBox</param>
        /// <param name="boxThr">TextBox</param>
        /// <returns></returns>
        public static string MultiThrTbCbAdd ( TextBox boxOne ,TextBox boxTwo ,ComboBox boxTre ,string boxThr )
        {
            if ( !string.IsNullOrEmpty( boxOne.Text ) )
                One = Convert.ToInt64( boxOne.Text );
            else
                One = 0;
            if ( !string.IsNullOrEmpty( boxTwo.Text ) )
                Fiv = Convert.ToDecimal( boxTwo.Text );
            else
                Fiv = 0;
            if ( !string.IsNullOrEmpty( boxTre.Text ) )
                For = Convert.ToDecimal( boxTre.Text );
            else
                For = 0;
            if ( !string.IsNullOrEmpty( boxThr ) )
                Egi = Convert.ToDecimal( boxThr );
            else
                Egi = 0;

            Sev = ( One * Fiv + For - Egi ).ToString( );
            return Sev;
        }
        /// <summary>
        /// 四个数据的先乘后加再减运算
        /// </summary>
        /// <param name="boxOne">TextBox</param>
        /// <param name="boxTwo">ComboBox</param>
        /// <param name="boxThr">TextBox</param>
        /// <returns></returns>
        public static string MultiThrTbCbAdd ( TextBox boxOne ,ComboBox boxTwo ,ComboBox boxTre ,string boxThr )
        {
            if ( !string.IsNullOrEmpty( boxOne.Text ) )
                One = Convert.ToInt64( boxOne.Text );
            else
                One = 0;
            if ( !string.IsNullOrEmpty( boxTwo.Text ) )
                Fiv = Convert.ToDecimal( boxTwo.Text );
            else
                Fiv = 0;
            if ( !string.IsNullOrEmpty( boxTre.Text ) )
                For = Convert.ToDecimal( boxTre.Text );
            else
                For = 0;
            if ( !string.IsNullOrEmpty( boxThr ) )
                Egi = Convert.ToDecimal( boxThr );
            else
                Egi = 0;

            Sev = ( One * Fiv + For - Egi ).ToString( );
            return Sev;
        }
        /// <summary>
        /// 四个数据的先乘后减运算
        /// </summary>
        /// <param name="boxOne">TextBox</param>
        /// <param name="boxTwo">ComboBox</param>
        /// <param name="boxThr">TextBox</param>
        /// <returns></returns>
        public static string MultiThrTbCb ( ComboBox boxOne ,ComboBox boxTwo ,ComboBox boxFor ,string boxThr )
        {
            if ( !string.IsNullOrEmpty( boxOne.Text ) )
                Thr = Convert.ToDecimal( boxOne.Text );
            else
                Thr = 0;
            if ( !string.IsNullOrEmpty( boxTwo.Text ) )
                Fiv = Convert.ToDecimal( boxTwo.Text );
            else
                Fiv = 0;
            if ( !string.IsNullOrEmpty( boxFor.Text ) )
                For = Convert.ToDecimal( boxFor.Text );
            else
                For = 0;
            if ( !string.IsNullOrEmpty( boxThr ) )
                Egi = Convert.ToDecimal( boxThr );
            else
                Egi = 0;

            Sev = ( Thr * Fiv * For - Egi ).ToString( );
            return Sev;
        }
        /// <summary>
        /// 五个数据的乘法运算
        /// </summary>
        /// <returns></returns>
        public static string MultiTwoTbes ( ComboBox boxOne ,ComboBox boxTwo,ComboBox boxTre,TextBox boxFor,ComboBox boxFiv )
        {
            if ( !string.IsNullOrEmpty( boxOne.Text ) )
                Thr = Convert.ToDecimal( boxOne.Text );
            else
                Thr = 0;
            if ( !string.IsNullOrEmpty( boxTwo.Text ) )
                For = Convert.ToDecimal( boxTwo.Text );
            else
                For = 0;
            if ( !string.IsNullOrEmpty( boxTre.Text ) )
                Fiv = Convert.ToDecimal( boxTre.Text );
            else
                Fiv = 0;
            if ( !string.IsNullOrEmpty( boxFor.Text ) )
                One = Convert.ToInt64( boxFor.Text );
            else
                One = 0;
            if ( !string.IsNullOrEmpty( boxFiv.Text ) )
                Nin = Convert.ToInt32( boxFiv.Text );
            else
                Nin = 0;

            return ( Thr * For * Fiv * One * Nin * Convert.ToDecimal( 0.000001 ) ).ToString( );
        }
        /// <summary>
        /// 六个数据的先乘法后减法运算
        /// </summary>
        /// <returns></returns>
        public static string MultiTwoTbes ( ComboBox boxOne ,ComboBox boxTwo ,ComboBox boxTre ,TextBox boxFor ,ComboBox boxFiv,TextBox boxSix )
        {
            if ( !string.IsNullOrEmpty( boxOne.Text ) )
                Thr = Convert.ToDecimal( boxOne.Text );
            else
                Thr = 0;
            if ( !string.IsNullOrEmpty( boxTwo.Text ) )
                For = Convert.ToDecimal( boxTwo.Text );
            else
                For = 0;
            if ( !string.IsNullOrEmpty( boxTre.Text ) )
                Fiv = Convert.ToDecimal( boxTre.Text );
            else
                Fiv = 0;
            if ( !string.IsNullOrEmpty( boxFor.Text ) )
                One = Convert.ToInt64( boxFor.Text );
            else
                One = 0;
            if ( !string.IsNullOrEmpty( boxFiv.Text ) )
                Nin = Convert.ToInt32( boxFiv.Text );
            else
                Nin = 0;
            if ( !string.IsNullOrEmpty( boxSix.Text ) )
                Egi = Convert.ToDecimal( boxSix.Text );
            else
                Egi = 0;

            return ( Thr * For * Fiv * One * Nin * Convert.ToDecimal( 0.000001 ) - Egi ).ToString( );
        }

        /// <summary>
        /// 339  板算漆量
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <param name="tre"></param>
        /// <param name="fou"></param>
        /// <param name="fiv"></param>
        /// <param name="six"></param>
        /// <param name="sev"></param>
        /// <param name="eig"></param>
        /// <param name="nin"></param>
        /// <returns></returns>
        public static string MultiAll (string one,string two,string tre,string fou,string fiv,string six,string sev,string eig,string nin )
        {
            string str = "";
            if ( !string.IsNullOrEmpty( one ) && !string.IsNullOrEmpty( two ) && !string.IsNullOrEmpty( tre ) && !string.IsNullOrEmpty( fou ) && !string.IsNullOrEmpty( fiv ) && !string.IsNullOrEmpty( six ) && !string.IsNullOrEmpty( sev ) && !string.IsNullOrEmpty( eig ) && !string.IsNullOrEmpty( nin ) )
                str = ( ( Convert.ToDecimal( one ) * Convert.ToDecimal( two ) * Convert.ToInt64( tre ) * Convert.ToDecimal( fou ) * Convert.ToDecimal( fiv ) * Convert.ToDecimal( six ) ) / Convert.ToDecimal( sev ) / Convert.ToDecimal( eig ) / Convert.ToDecimal( nin ) / 100 ).ToString( );
            else
                str = "0";

            return str;
        }

        /// <summary>
        /// 339 平米算
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <param name="tre"></param>
        /// <param name="fou"></param>
        /// <param name="fiv"></param>
        /// <param name="six"></param>
        /// <param name="sev"></param>
        /// <returns></returns>
        public static string MultiAllP ( string one ,string two ,string tre ,string fou ,string fiv ,string six ,string sev,string egi,string nin )
        {
            string str = "";
            if ( !string.IsNullOrEmpty( one ) && !string.IsNullOrEmpty( two ) && !string.IsNullOrEmpty( tre ) && !string.IsNullOrEmpty( fou ) && !string.IsNullOrEmpty( fiv ) && !string.IsNullOrEmpty( six ) && !string.IsNullOrEmpty( sev ) && !string.IsNullOrEmpty( egi ) && !string.IsNullOrEmpty( nin ) )
                str = ( Convert.ToDecimal( one ) * Convert.ToDecimal( two ) * Convert.ToDecimal( tre ) * Convert.ToDecimal( fou ) * Convert.ToDecimal( fiv ) * Convert.ToDecimal( six ) * Convert.ToDecimal( egi ) * Convert.ToDecimal( nin ) / Convert.ToDecimal( sev ) / 10000 / 100 ).ToString( );
            else
                str = "0";

            return str;
        }
    }
}
