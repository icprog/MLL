using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MulaolaoLibrary
{
    public class WuJinContractLibrary
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

        private decimal _pqu13;
        /// <summary>
        /// 每套部件用量
        /// </summary>
        public decimal PQU13
        {
            get
            {
                return _pqu13;
            }
            set
            {
                _pqu13 = value;
            }
        }

        private int _pqu14;
        /// <summary>
        /// 采购余量
        /// </summary>
        public int PQU14
        {
            get
            {
                return _pqu14;
            }
            set
            {
                _pqu14 = value;
            }
        }

        private string _pqu19;
        /// <summary>
        /// 使用库存（外购）
        /// </summary>
        public string PQU19
        {
            get
            {
                return _pqu19;
            }
            set
            {
                _pqu19 = value;
            }
        }

        private decimal _pqu18;
        /// <summary>
        /// 库存数量
        /// </summary>
        public decimal PQU18
        {
            get
            {
                return _pqu18;
            }
            set
            {
                _pqu18 = value;
            }
        }

        private long _pqu101;
        /// <summary>
        /// 产品数量
        /// </summary>
        public long PQU101
        {
            get
            {
                return _pqu101;
            }
            set
            {
                _pqu101 = value;
            }
        }

        private decimal _pqu104;
        /// <summary>
        /// 外购数量
        /// </summary>
        public decimal PQU104
        {
            get
            {
                return _pqu104;
            }
            set
            {
                _pqu104 = value;
            }
        }

        private long _pqu109;
        /// <summary>
        /// 上次入库数量
        /// </summary>
        public long PQU109
        {
            get
            {
                return _pqu109;
            }
            set
            {
                _pqu109 = value;
            }
        }

        private decimal _pqu110;
        /// <summary>
        /// 上次入库采购数量
        /// </summary>
        public decimal PQU110
        {
            get
            {
                return _pqu110;
            }
            set
            {
                _pqu110 = value;
            }
        }

        private string _pqu111;
        /// <summary>
        /// 入库标记  入库 'T'
        /// </summary>
        public string PQU111
        {
            get
            {
                return _pqu111;
            }
            set
            {
                _pqu111 = value;
            }
        }

        private string _pqu112;
        /// <summary>
        /// 是否调库  是T
        /// </summary>
        public string PQU112
        {
            get
            {
                return _pqu112;
            }
            set
            {
                _pqu112 = value;
            }
        }

        private DateTime? _pqu113;
        /// <summary>
        /// 打印时间
        /// </summary>
        public DateTime? PQU113
        {
            get
            {
                return _pqu113;
            }
            set
            {
                _pqu113 = value;
            }
        }

    }
}
