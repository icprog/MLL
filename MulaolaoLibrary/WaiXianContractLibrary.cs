using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MulaolaoLibrary
{
    public class WaiXianContractLibrary
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

        private long _wx15;
        /// <summary>
        /// 采购物品数量
        /// </summary>
        public long WX15
        {
            get
            {
                return _wx15;
            }set
            {
                _wx15 = value;
            }
        } 

        private long _wx16;
        /// <summary>
        /// 使用库存数量
        /// </summary>
        public long WX16
        {
            get
            {
                return _wx16;
            }
            set
            {
                _wx16 = value;
            }
        }

        private string _wx17;
        /// <summary>
        /// 使用外购(库存)
        /// </summary>
        public string WX17
        {
            get
            {
                return _wx17;
            }
            set
            {
                _wx17 = value;
            }
        }

        private decimal _wx18;
        /// <summary>
        /// 装箱率
        /// </summary>
        public decimal WX18
        {
            get
            {
                return _wx18;
            }
            set
            {
                _wx18 = value;
            }
        }

        private long _wx86;
        /// <summary>
        /// 产品数量
        /// </summary>
        public long WX86
        {
            get
            {
                return _wx86;
            }
            set
            {
                _wx86 = value;
            }
        }

        private long _wx87;
        /// <summary>
        /// 使用外购数量
        /// </summary>
        public long WX87
        {
            get
            {
                return _wx87;
            }
            set
            {
                _wx87 = value;
            }
        }

        private long _wx92;
        /// <summary>
        /// 上次入库数量
        /// </summary>
        public long WX92
        {
            get
            {
                return _wx92;
            }
            set
            {
                _wx92 = value;
            }
        }

        private long _wx93;
       /// <summary>
       /// 上次入库采购量
       /// </summary>
        public long WX93
        {
            get
            {
                return _wx93;
            }
            set
            {
                _wx93 = value;
            }
        }

        private DateTime? _wx94;
        /// <summary>
        /// 打印时间
        /// </summary>
        public DateTime? WX94
        {
            get
            {
                return _wx94;
            }
            set
            {
                _wx94 = value;
            }
        }

    }
}
