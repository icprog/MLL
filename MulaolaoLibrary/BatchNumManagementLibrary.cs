using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MulaolaoLibrary
{
   public class BatchNumManagementLibrary
    {
        private int _idx;
        private string _ai001;
        private string _ai002;
        private string _ai003;
        private string _ai004;
        private string _ai005;
        private string _ai006;
        private decimal _ai007;
        private decimal _ai008;
        private decimal _ai009;
        private string _ai010;
        private string _ai011;
        private string _ai012;
        private string _ai013;
        private string _ai014;

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

        /// <summary>
        /// 唯一识别号
        /// </summary>
        public string AI001
        {
            get
            {
                return _ai001;
            }
            set
            {
                _ai001 = value;
            }
        }
        /// <summary>
        /// 流水号
        /// </summary>
        public string AI002
        {
            get
            {
                return _ai002;
            }
            set
            {
                _ai002 = value;
            }
        }
        /// <summary>
        /// 工序
        /// </summary>
        public string AI003
        {
            get
            {
                return _ai003;
            }
            set
            {
                _ai003 = value;
            }
        }
        /// <summary>
        /// 色号
        /// </summary>
        public string AI004
        {
            get
            {
                return _ai004;
            }
            set
            {
                _ai004 = value;
            }
        }
        /// <summary>
        /// 供方批号
        /// </summary>
        public string AI005
        {
            get
            {
                return _ai005;
            }
            set
            {
                _ai005 = value;
            }
        }
        /// <summary>
        /// 生产批次号
        /// </summary>
        public string AI006
        {
            get
            {
                return _ai006;
            }
            set
            {
                _ai006 = value;
            }
        }
        /// <summary>
        ///T:板算F:平方算
        /// </summary>
        public string AI010
        {
            get
            {
                return _ai010;
            }
            set
            {
                _ai010 = value;
            }
        }
        /// <summary>
        ///零件名称
        /// </summary>
        public string AI011
        {
            get
            {
                return _ai011;
            }
            set
            {
                _ai011 = value;
            }
        }
        /// <summary>
        /// 实际入库量
        /// </summary>
        public decimal AI007
        {
            get
            {
                return _ai007;
            }
            set
            {
                _ai007 = value;
            }
        }
        /// <summary>
        /// 实际领用量
        /// </summary>
        public decimal AI008
        {
            get
            {
                return _ai008;
            }
            set
            {
                _ai008 = value;
            }
        }
        /// <summary>
        /// 每套用量
        /// </summary>
        public decimal AI009
        {
            get
            {
                return _ai009;
            }
            set
            {
                _ai009 = value;
            }
        }
        /// <summary>
        /// 合同号
        /// </summary>
        public string AI012
        {
            get
            {
                return _ai012;
            }
            set
            {
                _ai012 = value;
            }
        }
        /// <summary>
        /// 是否使用
        /// </summary>
        public string AI013
        {
            get
            {
                return _ai013;
            }
            set
            {
                _ai013 = value;
            }
        }
        /// <summary>
        /// R_339单号
        /// </summary>
        public string AI014
        {
            get
            {
                return _ai014;
            }
            set
            {
                _ai014 = value;
            }
        }

    }
}
