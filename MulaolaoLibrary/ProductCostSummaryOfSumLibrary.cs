using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MulaolaoLibrary
{
    public class ProductCostSummaryOfSumLibrary
    {
        private int _idx;
        public int IDX
        {
            get
            {
                return _idx;
            }
            set
            {
                _idx = value;
            }
        }

        private string _bb001;
        /// <summary>
        /// 状态
        /// </summary>
        public string BB001
        {
            get
            {
                return _bb001;
            }
            set
            {
                _bb001 = value;
            }
        }

        private DateTime _bb002;
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime BB002
        {
            get
            {
                return _bb002;
            }
            set
            {
                _bb002 = value;
            }
        }

        private decimal _bb003;
        /// <summary>
        /// 241总计
        /// </summary>
        public decimal BB003
        {
            get
            {
                return _bb003;
            }
            set
            {
                _bb003 = value;
            }
        }

        private string _bb004;
        /// <summary>
        /// 付款对象
        /// </summary>
        public string BB004
        {
            get
            {
                return _bb004;
            }
            set
            {
                _bb004 = value;
            }
        }
    }
}
