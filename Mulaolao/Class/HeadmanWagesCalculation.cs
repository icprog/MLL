using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mulaolao.Class
{
    public class HeadmanWagesCalculation
    {
        private decimal OneDe = 0M;
        private decimal TwoDe = 0M;
        private decimal TreDe = 0M;
        private decimal ForDe = 0M;
        private decimal FivDe = 0M;

        /// <summary>
        /// 两个数的除法
        /// </summary>
        /// <param name="boxOne"></param>
        /// <param name="boxTwo"></param>
        /// <param name="boxTre"></param>
        /// <returns>返回一位小数结果</returns>
        public string DivisionTreDeOne ( Label belOne ,Label belTwo )
        {
            if ( !string.IsNullOrEmpty( belOne.Text ) )
                OneDe = Convert.ToDecimal( belOne.Text );
            if ( !string.IsNullOrEmpty( belTwo.Text ) )
                TwoDe = Convert.ToDecimal( belTwo.Text );
            if ( TwoDe == 0 )
                return 0.ToString( );
            else
                return Math.Round( OneDe / TwoDe ,1 ).ToString( );
        }
        /// <summary>
        /// 三个数的乘积
        /// </summary>
        /// <param name="boxOne"></param>
        /// <param name="boxTwo"></param>
        /// <param name="boxTre"></param>
        /// <returns>返回一位小数结果</returns>
        public string MultiTreDeOne ( TextBox boxOne,TextBox boxTwo,TextBox boxTre)
        {
            if ( !string.IsNullOrEmpty( boxOne.Text ) )
                OneDe = Convert.ToDecimal( boxOne.Text );
            if ( !string.IsNullOrEmpty( boxTwo.Text ) )
                TwoDe = Convert.ToDecimal( boxTwo.Text );
            if ( !string.IsNullOrEmpty( boxTre.Text ) )
                TreDe = Convert.ToDecimal( boxTre.Text );

            return Math.Round( OneDe * TwoDe * TreDe ,1 ).ToString( );
        }
        /// <summary>
        /// 三个数的乘积
        /// </summary>
        /// <param name="boxOne"></param>
        /// <param name="boxTwo"></param>
        /// <param name="boxTre"></param>
        /// <returns>返回一位小数结果</returns>
        public string MultiTreDeTwo ( TextBox boxOne ,TextBox boxTwo ,TextBox boxTre )
        {
            if ( !string.IsNullOrEmpty( boxOne.Text ) )
                OneDe = Convert.ToDecimal( boxOne.Text );
            if ( !string.IsNullOrEmpty( boxTwo.Text ) )
                TwoDe = Convert.ToDecimal( boxTwo.Text );
            if ( !string.IsNullOrEmpty( boxTre.Text ) )
                TreDe = Convert.ToDecimal( boxTre.Text );

            return Math.Round( OneDe * TwoDe * TreDe ,2 ).ToString( );
        }
        /// <summary>
        /// 三个数的加法
        /// </summary>
        /// <param name="boxOne"></param>
        /// <param name="boxTwo"></param>
        /// <param name="boxTre"></param>
        /// <returns>返回一位小数结果</returns>
        public string AddTreDeOne ( Label belOne ,Label belTwo ,Label belTre )
        {
            if ( !string.IsNullOrEmpty( belOne.Text ) )
                OneDe = Convert.ToDecimal( belOne.Text );
            if ( !string.IsNullOrEmpty( belTwo.Text ) )
                TwoDe = Convert.ToDecimal( belTwo.Text );
            if ( !string.IsNullOrEmpty( belTre.Text ) )
                TreDe = Convert.ToDecimal( belTre.Text );

            return Math.Round( OneDe + TwoDe + TreDe ,1 ).ToString( );
        }
        /// <summary>
        /// 多个数相加
        /// </summary>
        /// <param name="list"></param>
        /// <returns>返回一位小数结果</returns>
        public string AddMultipleDeOne ( List<TextBox> list )
        {
            foreach ( TextBox boxOne in list )
            {
                if ( !string.IsNullOrEmpty( boxOne.Text ) )
                    OneDe += Convert.ToDecimal( boxOne.Text );
            }

            return Math.Round( OneDe ,1 ).ToString( );
        } 
        /// <summary>
          /// 多个数相加
          /// </summary>
          /// <param name="list"></param>
          /// <returns>返回一位小数结果</returns>
        public string AddMultipleDeOne ( List<Label> list )
        {
            foreach ( Label boxOne in list )
            {
                if ( !string.IsNullOrEmpty( boxOne.Text ) )
                    OneDe += Convert.ToDecimal( boxOne.Text );
            }

            return Math.Round( OneDe ,1 ).ToString( );
        }

        /// <summary>
        /// 多个数据做运算
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <param name="tre"></param>
        /// <param name="fore"></param>
        /// <param name="fiv"></param>
        /// <returns></returns>
        public string SomeOfCaculation ( string one ,string two ,string tre ,string fore ,string fiv )
        {
            if ( !string.IsNullOrEmpty( one ) )
                OneDe = Convert.ToDecimal( one );
            else
                OneDe = 0;
            if ( !string.IsNullOrEmpty( two ) )
                TwoDe = Convert.ToDecimal( two );
            else
                TwoDe = 0;
            if ( !string.IsNullOrEmpty( tre ) )
                TreDe = Convert.ToDecimal( tre );
            else
                TreDe = 0;
            if ( !string.IsNullOrEmpty( fore ) )
                ForDe = Convert.ToDecimal( fore );
            else
                ForDe = 0;
            if ( !string.IsNullOrEmpty( fiv ) )
                FivDe = Convert.ToDecimal( fiv );
            else
                FivDe = 0;

            if ( FivDe == 0 )
                return 0.ToString( );
            else
                return Math.Round( OneDe * TwoDe * TreDe * ForDe / FivDe ,2 ).ToString( );
        }

        /// <summary>
        /// 多个数据做运算
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <param name="tre"></param>
        /// <param name="fore"></param>
        /// <returns></returns>
        public string SomeOfCaculations (string one,string two,string tre,string fore )
        {
            if ( string.IsNullOrEmpty( one ) )
                OneDe = 0;
            else
                OneDe = Convert.ToDecimal( one );
            if ( string.IsNullOrEmpty( two ) )
                TwoDe = 0;
            else
                TwoDe = Convert.ToDecimal( two );
            if ( string.IsNullOrEmpty( tre ) )
                TreDe = 0;
            else
                TreDe = Convert.ToDecimal( tre );
            if ( string.IsNullOrEmpty( fore ) )
                ForDe = 0;
            else
                ForDe = Convert.ToDecimal( fore );

            return Math.Round( OneDe * TwoDe * TreDe * ( 1 + ForDe ) ,2 ).ToString( );
        }
    }
}
