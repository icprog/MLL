using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MulaolaoLibrary
{
    public class SuLiaoBuQiContractLibrary
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

        private long _pj10;
        /// <summary>
        ///物品余量
        /// </summary>
        public long PJ10
        {
            get
            {
                return _pj10;
            }
            set
            {
                _pj10 = value;
            }
        }

        private decimal _pj11;
        /// <summary>
        ///每套用量
        /// </summary>
        public decimal PJ11
        {
            get
            {
                return _pj11;
            }
            set
            {
                _pj11 = value;
            }
        }

        private decimal _pj14;
        /// <summary>
        ///使用库存数量
        /// </summary>
        public decimal PJ14
        {
            get
            {
                return _pj14;
            }
            set
            {
                _pj14 = value;
            }
        }

        private string _pj15;
        /// <summary>
        ///使用库存(外购)
        /// </summary>
        public string PJ15
        {
            get
            {
                return _pj15;
            }
            set
            {
                _pj15 = value;
            }
        }

        private string _pj92;
        /// <summary>
        /// 单号
        /// </summary>
        public string PJ92
        {
            get
            {
                return _pj92;
            }
            set
            {
                _pj92 = value;
            }
        }

        private long _pj96;
        /// <summary>
        ///产品数量
        /// </summary>
        public long PJ96
        {
            get
            {
                return _pj96;
            }
            set
            {
                _pj96 = value;
            }
        }

        private decimal _pj97;
        /// <summary>
        ///使用外购数量
        /// </summary>
        public decimal PJ97
        {
            get
            {
                return _pj97;
            }
            set
            {
                _pj97 = value;
            }
        }

        private long _pj102;
        /// <summary>
        /// 上次入库数量
        /// </summary>
        public long PJ102
        {
            get
            {
                return _pj102;
            }
            set
            {
                _pj102 = value;
            }
        }

        private decimal _pj103;
        /// <summary>
        /// 上次入库数量
        /// </summary>
        public decimal PJ103
        {
            get
            {
                return _pj103;
            }
            set
            {
                _pj103 = value;
            }
        }

        private string _pj104;
        /// <summary>
        /// 入库标识  入库''T''
        /// </summary>
        public string PJ104
        {
            get
            {
                return _pj104;
            }
            set
            {
                _pj104 = value;
            }
        }

        private DateTime? _pj107;
        /// <summary>
        /// 打印时间
        /// </summary>
        public DateTime? PJ107
        {
            get
            {
                return _pj107;
            }
            set
            {
                _pj107 = value;
            }
        }


    }
}
