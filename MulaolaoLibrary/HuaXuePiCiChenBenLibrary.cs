using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MulaolaoLibrary
{
    public class HuaXuePiCiChenBen
    {
        private int _idx;
        private string _pqk01;
        private string _pqk16;
        private string _pqk02;
        private string _pqk12;
        private string _pqk13;
        private string _pqk14;
        private string _pqk15;
        private string _pqk03;
        private string _pqk04;
        private DateTime? _pqk05;
        private DateTime? _pqk06;
        private string _pqk07;
        private string _pqk11;
        private string _pqk17;
        private int _pqk08;
        private int _pqk29;
        private decimal _pqk09;
        private decimal _pqk10;
        private decimal _pqk18;
        private decimal _pqk31;
        private decimal _pqk32;
        private decimal _pqk37;
        private long _pqk23;
        private int _pqk20;
        private int _pqk22;
        private int _pqk21;
        private decimal _pqk27;
        private decimal _pqk26;
        private decimal _pqk19;
        private decimal _pqk28;
        private string _pqk24;
        private decimal _pqk25;
        private string _pqk35;
        private string _pqk36;
        private string _pqk30;
        private DateTime _pqk38;
        private int _pqk39;
        private decimal _pqk40;
        private string _pqk41;

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
        /// 单号
        /// </summary>
        public string PQK01
        {
            get
            {
                return _pqk01;
            }
            set
            {
                _pqk01 = value;
            }
        }
        /// <summary>
        /// 批号
        /// </summary>
        public string PQK16
        {
            get
            {
                return _pqk16;
            }
            set
            {
                _pqk16 = value;
            }
        }
        /// <summary>
        /// 流水号
        /// </summary>
        public string PQK02
        {
            get
            {
                return _pqk02;
            }
            set
            {
                _pqk02 = value;
            }
        }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string PQK12
        {
            get
            {
                return _pqk12;
            }
            set
            {
                _pqk12 = value;
            }
        }
        /// <summary>
        /// 货号
        /// </summary>
        public string PQK13
        {
            get
            {
                return _pqk13;
            }
            set
            {
                _pqk13 = value;
            }
        }
        /// <summary>
        /// 品牌
        /// </summary>
        public string PQK14
        {
            get
            {
                return _pqk14;
            }
            set
            {
                _pqk14 = value;
            }
        }
        /// <summary>
        /// 填报人
        /// </summary>
        public string PQK15
        {
            get
            {
                return _pqk15;
            }
            set
            {
                _pqk15 = value;
            }
        }
        /// <summary>
        /// 喷漆人
        /// </summary>
        public string PQK03
        {
            get
            {
                return _pqk03;
            }
            set
            {
                _pqk03 = value;
            }
        }
        /// <summary>
        /// 车间
        /// </summary>
        public string PQK04
        {
            get
            {
                return _pqk04;
            }
            set
            {
                _pqk04 = value;
            }
        }
        /// <summary>
        /// 完工日期
        /// </summary>
        public DateTime? PQK05
        {
            get
            {
                return _pqk05;
            }
            set
            {
                _pqk05 = value;
            }
        }
        /// <summary>
        /// 上报日期
        /// </summary>
        public DateTime? PQK06
        {
            get
            {
                return _pqk06;
            }
            set
            {
                _pqk06 = value;
            }
        }
        /// <summary>
        /// 零件名称
        /// </summary>
        public string PQK07
        {
            get
            {
                return _pqk07;
            }
            set
            {
                _pqk07 = value;
            }
        }
        /// <summary>
        /// 工艺
        /// </summary>
        public string PQK11
        {
            get
            {
                return _pqk11;
            }
            set
            {
                _pqk11 = value;
            }
        }
        /// <summary>
        /// 色号
        /// </summary>
        public string PQK17
        {
            get
            {
                return _pqk17;
            }
            set
            {
                _pqk17 = value;
            }
        }
        /// <summary>
        /// 长向摆放个数
        /// </summary>
        public int PQK08
        {
            get
            {
                return _pqk08;
            }
            set
            {
                _pqk08 = value;
            }
        }
        /// <summary>
        /// 宽向摆放个数
        /// </summary>
        public decimal PQK19
        {
            get
            {
                return _pqk19;
            }
            set
            {
                _pqk19 = value;
            }
        }
        /// <summary>
        /// 每板实际摆放个数
        /// </summary>
        public int PQK29
        {
            get
            {
                return _pqk29;
            }
            set
            {
                _pqk29 = value;
            }
        }
        /// <summary>
        /// 板实入库量(kg)
        /// </summary>
        public decimal PQK09
        {
            get
            {
                return _pqk09;
            }
            set
            {
                _pqk09 = value;
            }
        }
        /// <summary>
        /// 平米实入库量(kg)
        /// </summary>
        public decimal PQK37
        {
            get
            {
                return _pqk37;
            }
            set
            {
                _pqk37 = value;
            }
        }
        /// <summary>
        /// 板实领用漆量kgR_266
        /// </summary>
        public decimal PQK10
        {
            get
            {
                return _pqk10;
            }
            set
            {
                _pqk10 = value;
            }
        }
        /// <summary>
        /// 定板算采购漆量(kg)
        /// </summary>
        public decimal PQK18
        {
            get
            {
                return _pqk18;
            }
            set
            {
                _pqk18 = value;
            }
        }
        /// <summary>
        /// 平米实领用漆量Kg R-266
        /// </summary>
        public decimal PQK31
        {
            get
            {
                return _pqk31;
            }
            set
            {
                _pqk31 = value;
            }
        }
        /// <summary>
        /// 定平米算采购漆量(kg)
        /// </summary>
        public decimal PQK32
        {
            get
            {
                return _pqk32;
            }
            set
            {
                _pqk32 = value;
            }
        }
        /// <summary>
        /// 产品数量
        /// </summary>
        public long PQK23
        {
            get
            {
                return _pqk23;
            }
            set
            {
                _pqk23 = value;
            }
        }
        /// <summary>
        /// 每套部件数量
        /// </summary>
        public int PQK20
        {
            get
            {
                return _pqk20;
            }
            set
            {
                _pqk20 = value;
            }
        }
        /// <summary>
        /// 每片喷面数
        /// </summary>
        public int PQK22
        {
            get
            {
                return _pqk22;
            }
            set
            {
                _pqk22 = value;
            }
        }
        /// <summary>
        /// 每片每面喷涂遍数
        /// </summary>
        public int PQK21
        {
            get
            {
                return _pqk21;
            }
            set
            {
                _pqk21 = value;
            }
        }
        /// <summary>
        /// 每板摆用率
        /// </summary>
        public decimal PQK27
        {
            get
            {
                return _pqk27;
            }
            set
            {
                _pqk27 = value;
            }
        }
        /// <summary>
        /// 定每板单面.遍漆价
        /// </summary>
        public decimal PQK26
        {
            get
            {
                return _pqk26;
            }
            set
            {
                _pqk26 = value;
            }
        }
        /// <summary>
        /// 定每平米单面遍漆价
        /// </summary>
        public decimal PQK28
        {
            get
            {
                return _pqk28;
            }
            set
            {
                _pqk28 = value;
            }
        }
        /// <summary>
        /// 填大小板密度板(计价单位平方、板)
        /// </summary>
        public string PQK24
        {
            get
            {
                return _pqk24;
            }
            set
            {
                _pqk24 = value;
            }
        }
        /// <summary>
        /// 油漆现价
        /// </summary>
        public decimal PQK25
        {
            get
            {
                return _pqk25;
            }
            set
            {
                _pqk25 = value;
            }
        }
        /// <summary>
        /// 339供方批号
        /// </summary>
        public string PQK35
        {
            get
            {
                return _pqk35;
            }
            set
            {
                _pqk35 = value;
            }
        }
        /// <summary>
        /// 339生产批号
        /// </summary>
        public string PQK36
        {
            get
            {
                return _pqk36;
            }
            set
            {
                _pqk36 = value;
            }
        }
        /// <summary>
        /// 339单号
        /// </summary>
        public string PQK30
        {
            get
            {
                return _pqk30;
            }
            set
            {
                _pqk30 = value;
            }
        }
        /// <summary>
        /// 实际入库日期
        /// </summary>
        public DateTime PQK38
        {
            get
            {
                return _pqk38;
            }
            set
            {
                _pqk38 = value;
            }
        }
        /// <summary>
        /// 上次入库数量
        /// </summary>
        public int PQK39
        {
            get
            {
                return _pqk39;
            }
            set
            {
                _pqk39 = value;
            }
        }
        /// <summary>
        /// 上次入库采购数量
        /// </summary>
        public decimal PQK40
        {
            get
            {
                return _pqk40;
            }
            set
            {
                _pqk40 = value;
            }
        }
        /// <summary>
        /// 是否完工
        /// </summary>
        public string PQK41
        {
            get
            {
                return _pqk41;
            }
            set
            {
                _pqk41 = value;
            }
        }
    }
}
