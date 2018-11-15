using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MulaolaoLibrary
{
    public class PayMentLibrary
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

        private string _yz001;
        /// <summary>
        /// 单号
        /// </summary>
        public string YZ001
        {
            get
            {
                return _yz001;
            }
            set
            {
                _yz001 = value;
            }
        }

        private string _yz002;
        /// <summary>
        /// 付款选择
        /// </summary>
        public string YZ002
        {
            get
            {
                return _yz002;
            }
            set
            {
                _yz002 = value;
            }
        }

        private string _yz003;
        /// <summary>
        /// 执行状态
        /// </summary>
        public string YZ003
        {
            get
            {
                return _yz003;
            }
            set
            {
                _yz003 = value;
            }
        }

        private string _yz004;
        /// <summary>
        /// 成本监督人
        /// </summary>
        public string YZ004
        {
            get
            {
                return _yz004;
            }
            set
            {
                _yz004 = value;
            }
        }

        private string _yz005;
        /// <summary>
        /// 成本经办人
        /// </summary>
        public string YZ005
        {
            get
            {
                return _yz005;
            }
            set
            {
                _yz005 = value;
            }
        }

        private string _yz006;
        /// <summary>
        /// 单位名称
        /// </summary>
        public string YZ006
        {
            get
            {
                return _yz006;
            }
            set
            {
                _yz006 = value;
            }
        }

        private string _yz007;
        /// <summary>
        /// 付款内容（品名）
        /// </summary>
        public string YZ007
        {
            get
            {
                return _yz007;
            }
            set
            {
                _yz007 = value;
            }
        }

        private string _yz008;
        /// <summary>
        /// 扣款明细
        /// </summary>
        public string YZ008
        {
            get
            {
                return _yz008;
            }
            set
            {
                _yz008 = value;
            }
        }

        private DateTime _yz009;
        /// <summary>
        /// 付款日期
        /// </summary>
        public DateTime YZ009
        {
            get
            {
                return _yz009;
            }
            set
            {
                _yz009 = value;
            }
        }

        private decimal _yz010;
        /// <summary>
        /// 合并金额
        /// </summary>
        public decimal YZ010
        {
            get
            {
                return _yz010;
            }
            set
            {
                _yz010 = value;
            }
        }

        private decimal _yz011;
        /// <summary>
        /// 交回现金
        /// </summary>
        public decimal YZ011
        {
            get
            {
                return _yz011;
            }
            set
            {
                _yz011 = value;
            }
        }

        private decimal _yz012;
        /// <summary>
        /// 己扣返工工资额
        /// </summary>
        public decimal YZ012
        {
            get
            {
                return _yz012;
            }
            set
            {
                _yz012 = value;
            }
        }

        private decimal _yz013;
        /// <summary>
        /// 验.检红包
        /// </summary>
        public decimal YZ013
        {
            get
            {
                return _yz013;
            }
            set
            {
                _yz013 = value;
            }
        }

        private decimal _yz014;
        /// <summary>
        /// 己扣责任款
        /// </summary>
        public decimal YZ014
        {
            get
            {
                return _yz014;
            }
            set
            {
                _yz014 = value;
            }
        }

        private decimal _yz015;
        /// <summary>
        /// 应付产品前道款
        /// </summary>
        public decimal YZ015
        {
            get
            {
                return _yz015;
            }
            set
            {
                _yz015 = value;
            }
        }

        private decimal _yz016;
        /// <summary>
        /// 扣后生产管理员工资
        /// </summary>
        public decimal YZ016
        {
            get
            {
                return _yz016;
            }
            set
            {
                _yz016 = value;
            }
        }

        private decimal _yz017;
        /// <summary>
        /// 应付后道款
        /// </summary>
        public decimal YZ017
        {
            get
            {
                return _yz017;
            }
            set
            {
                _yz017 = value;
            }
        }

        private decimal _yz018;
        /// <summary>
        /// 扣后行政后勤工资
        /// </summary>
        public decimal YZ018
        {
            get
            {
                return _yz018;
            }
            set
            {
                _yz018 = value;
            }
        }

        private decimal _yz019;
        /// <summary>
        /// 外购库存
        /// </summary>
        public decimal YZ019
        {
            get
            {
                return _yz019;
            }
            set
            {
                _yz019 = value;
            }
        }

        private string _yz020;
        /// <summary>
        /// 付出账户
        /// </summary>
        public string YZ020
        {
            get
            {
                return _yz020;
            }
            set
            {
                _yz020 = value;
            }
        }

        private string _yz021;
        /// <summary>
        /// 使用单位(人)
        /// </summary>
        public string YZ021
        {
            get
            {
                return _yz021;
            }
            set
            {
                _yz021 = value;
            }
        }

        private string _yz022;
        /// <summary>
        /// 526idx
        /// </summary>
        public string YZ022
        {
            get
            {
                return _yz022;
            }
            set
            {
                _yz022 = value;
            }
        }

        private string _yz023;
        /// <summary>
        /// 244idx
        /// </summary>
        public string YZ023
        {
            get
            {
                return _yz023;
            }
            set
            {
                _yz023 = value;
            }
        }

        private string _yz024;
        /// <summary>
        /// 050idx  行政
        /// </summary>
        public string YZ024
        {
            get
            {
                return _yz024;
            }
            set
            {
                _yz024 = value;
            }
        }

        private string _yz025;
        /// <summary>
        /// 050idx  生产部
        /// </summary>
        public string YZ025
        {
            get
            {
                return _yz025;
            }
            set
            {
                _yz025 = value;
            }
        }

        private decimal _yz026;
        /// <summary>
        /// 预借支款
        /// </summary>
        public decimal YZ026
        {
            get
            {
                return _yz026;
            }
            set
            {
                _yz026 = value;
            }
        }

        private string _yz027;
        /// <summary>
        /// 323idx
        /// </summary>
        public string YZ027
        {
            get
            {
                return _yz027;
            }
            set
            {
                _yz027 = value;
            }
        }

        private string _yz028;
        /// <summary>
        /// 使用人
        /// </summary>
        public string YZ028
        {
            get
            {
                return _yz028;
            }
            set
            {
                _yz028 = value;
            }
        }

        private string _yz030;
        /// <summary>
        /// 243idx
        /// </summary>
        public string YZ030
        {
            get
            {
                return _yz030;
            }
            set
            {
                _yz030 = value;
            }
        }

        private string _yz031;
        /// <summary>
        /// 序号
        /// </summary>
        public string YZ031
        {
            get
            {
                return _yz031;
            }
            set
            {
                _yz031 = value;
            }
        }

        private string _yz032;
        /// <summary>
        /// 480IDX
        /// </summary>
        public string YZ032
        {
            get
            {
                return _yz032;
            }
            set
            {
                _yz032 = value;
            }
        }
    }
}
