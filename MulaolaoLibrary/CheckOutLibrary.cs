using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulaolaoLibrary
{
    public class CheckOutLibrary
    {
        public CheckOutLibrary ( )
        {
        }

        #region Model
        private int _idx;
        private string _ak001;
        private string _ak002;
        private string _ak003;
        private string _ak004;
        private string _ak005;
        private string _ak006;
        private long _ak007;
        private string _ak008;
        private decimal _ak009;
        private decimal _ak010;
        private decimal _ak011;
        private DateTime _ak012;
        private string _ak013;
        private string _ak014;
        private decimal _ak015;
        private DateTime _ak016;
        private string _ak017;
        private int _idxContract;

        private string _contractSelect;

        /// <summary>
        /// 合同选择
        /// </summary>
        public string ContractSelect
        {
            get
            {
                return _contractSelect;
            }
            set
            {
                _contractSelect = value;
            }
        }

        /// <summary>
        /// 采购合同IDX
        /// </summary>
        public int IdxContract
        {
            get
            {
                return _idxContract;
            }
            set
            {
                _idxContract = value;
            }
        }
        public int Idx
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
        /// <summary>
        /// 供应商名称
        /// </summary>
        public string AK001
        {
            get
            {
                return _ak001;
            }
            set
            {
                _ak001 = value;
            }
        }
        /// <summary>
        /// 流水号
        /// </summary>
        public string AK002
        {
            get
            {
                return _ak002;
            }
            set
            {
                _ak002 = value;
            }
        }
        /// <summary>
        /// 合同单号
        /// </summary>
        public string AK003
        {
            get
            {
                return _ak003;
            }
            set
            {
                _ak003 = value;
            }
        }
        /// <summary>
        /// 合同号
        /// </summary>
        public string AK004
        {
            get
            {
                return _ak004;
            }
            set
            {
                _ak004 = value;
            }
        }
        /// <summary>
        /// 货号
        /// </summary>
        public string AK005
        {
            get
            {
                return _ak005;
            }
            set
            {
                _ak005 = value;
            }
        }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string AK006
        {
            get
            {
                return _ak006;
            }
            set
            {
                _ak006 = value;
            }
        }
        /// <summary>
        /// 产品数量
        /// </summary>
        public long AK007
        {
            get
            {
                return _ak007;
            }
            set
            {
                _ak007 = value;
            }
        }
        /// <summary>
        /// 物料名称
        /// </summary>
        public string AK008
        {
            get
            {
                return _ak008;
            }
            set
            {
                _ak008 = value;
            }
        }
        /// <summary>
        /// 应付合计金额
        /// </summary>
        public decimal AK009
        {
            get
            {
                return _ak009;
            }
            set
            {
                _ak009 = value;
            }
        }
        /// <summary>
        /// 预付款
        /// </summary>
        public decimal AK010
        {
            get
            {
                return _ak010;
            }
            set
            {
                _ak010 = value;
            }
        }
        /// <summary>
        /// 本次付款金额
        /// </summary>
        public decimal AK011
        {
            get
            {
                return _ak011;
            }
            set
            {
                _ak011 = value;
            }
        }
        /// <summary>
        /// 付款日期
        /// </summary>
        public DateTime AK012
        {
            get
            {
                return _ak012;
            }
            set
            {
                _ak012 = value;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string AK013
        {
            get
            {
                return _ak013;
            }
            set
            {
                _ak013 = value;
            }
        }
        /// <summary>
        /// 单号
        /// </summary>
        public string AK014
        {
            get
            {
                return _ak014;
            }
            set
            {
                _ak014 = value;
            }
        }
        /// <summary>
        /// 已付款
        /// </summary>
        public decimal AK015
        {
            get
            {
                return _ak015;
            }
            set
            {
                _ak015 = value;
            }
        }
        /// <summary>
        /// 付款日期
        /// </summary>
        public DateTime AK016
        {
            get
            {
                return _ak016;
            }
            set
            {
                _ak016 = value;
            }
        }
        /// <summary>
        /// 是否执行
        /// </summary>
        public string AK017
        {
            get
            {
                return _ak017;
            }
            set
            {
                _ak017 = value;
            }
        }
        #endregion
    }
}
