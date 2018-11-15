using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MulaolaoLibrary
{
    public class WagesContrastTableLibrary
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

        private int _vz001;
        /// <summary>
        /// 年
        /// </summary>
        public int VZ001
        {
            get
            {
                return _vz001;
            }
            set
            {
                _vz001 = value;
            }
        }

        private int _vz002;
        /// <summary>
        /// 月
        /// </summary>
        public int VZ002
        {
            get
            {
                return _vz002;
            }
            set
            {
                _vz002 = value;
            }
        }

        private string _vz003;
        /// <summary>
        /// 表号
        /// </summary>
        public string VZ003
        {
            get
            {
                return _vz003;
            }
            set
            {
                _vz003 = value;
            }
        }

        private decimal _vz004;
        /// <summary>
        /// 本月考勤天数
        /// </summary>
        public decimal VZ004
        {
            get
            {
                return _vz004;
            }
            set
            {
                _vz004 = value;
            }
        }

        private decimal _vz005;
        /// <summary>
        /// 本月已结天数
        /// </summary>
        public decimal VZ005
        {
            get
            {
                return _vz005;
            }
            set
            {
                _vz005 = value;
            }
        }

        private decimal _vz006;
        /// <summary>
        /// 本月已结金额
        /// </summary>
        public decimal VZ006
        {
            get
            {
                return _vz006;
            }
            set
            {
                _vz006 = value;
            }
        }

        private decimal _vz007;
        /// <summary>
        /// 累计考勤天数
        /// </summary>
        public decimal VZ007
        {
            get
            {
                return _vz007;
            }
            set
            {
                _vz007 = value;
            }
        }

        private decimal _vz008;
        /// <summary>
        /// 累计已结天数
        /// </summary>
        public decimal VZ008
        {
            get
            {
                return _vz008;
            }
            set
            {
                _vz008 = value;
            }
        }

        private decimal _vz009;
        /// <summary>
        /// 累计已结金额
        /// </summary>
        public decimal VZ009
        {
            get
            {
                return _vz009;
            }
            set
            {
                _vz009 = value;
            }
        }
    }
}
