using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MulaolaoLibrary
{
    public class ChanPinGongZiKaoQinLibrary
    {
        private int _idx;
        /// <summary>
        /// Idx
        /// </summary>
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

        private string _gz29;
        /// <summary>
        /// 单号
        /// </summary>
        public string GZ29
        {
            get
            {
                return _gz29;
            }
            set
            {
                _gz29 = value;
            }
        }

        private string _gz01;
        /// <summary>
        /// 流水号
        /// </summary>
        public string GZ01
        {
            get
            {
                return _gz01;
            }
            set
            {
                _gz01 = value;
            }
        }

        private string _gz22;
        /// <summary>
        /// 产品名称
        /// </summary>
        public string GZ22
        {
            get
            {
                return _gz22;
            }
            set
            {
                _gz22 = value;
            }
        }

        private string _gz23;
        /// <summary>
        /// 货号
        /// </summary>
        public string GZ23
        {
            get
            {
                return _gz23;
            }
            set
            {
                _gz23 = value;
            }
        }

        private string _gz02;
        /// <summary>
        /// 生产人姓名
        /// </summary>
        public string GZ02
        {
            get
            {
                return _gz02;
            }
            set
            {
                _gz02 = value;
            }
        }

        private int _gz24;
        /// <summary>
        /// 月份
        /// </summary>
        public int GZ24
        {
            get
            {
                return _gz24;
            }
            set
            {
                _gz24 = value;
            }
        }

        private int _gz17;
        /// <summary>
        /// 日期
        /// </summary>
        public int GZ17
        {
            get
            {
                return _gz17;
            }
            set
            {
                _gz17 = value;
            }
        }

        private string _gz03;
        /// <summary>
        /// 部件名称(509零件名称)
        /// </summary>
        public string GZ03
        {
            get
            {
                return _gz03;
            }
            set
            {
                _gz03 = value;
            }
        }

        private string _gz04;
        /// <summary>
        /// 工序(工序BOM)
        /// </summary>
        public string GZ04
        {
            get
            {
                return _gz04;
            }
            set
            {
                _gz04 = value;
            }
        }

        private decimal _gz09;
        /// <summary>
        /// 上午计件
        /// </summary>
        public decimal GZ09
        {
            get
            {
                return _gz09;
            }
            set
            {
                _gz09 = value;
            }
        }

        private decimal _gz10;
        /// <summary>
        /// 下午计件
        /// </summary>
        public decimal GZ10
        {
            get
            {
                return _gz10;
            }
            set
            {
                _gz10 = value;
            }
        }

        private decimal _gz11;
        /// <summary>
        /// 晚上计件
        /// </summary>
        public decimal GZ11
        {
            get
            {
                return _gz11;
            }
            set
            {
                _gz11 = value;
            }
        }

        private decimal _gz12;
        /// <summary>
        /// 上午计时
        /// </summary>
        public decimal GZ12
        {
            get
            {
                return _gz12;
            }
            set
            {
                _gz12 = value;
            }
        }

        private decimal _gz13;
        /// <summary>
        /// 下午计时
        /// </summary>
        public decimal GZ13
        {
            get
            {
                return _gz13;
            }
            set
            {
                _gz13 = value;
            }
        }

        private decimal _gz14;
        /// <summary>
        /// 晚上计时
        /// </summary>
        public decimal GZ14
        {
            get
            {
                return _gz14;
            }
            set
            {
                _gz14 = value;
            }
        }

        private decimal _gz19;
        /// <summary>
        /// 电子日工时
        /// </summary>
        public decimal GZ19
        {
            get
            {
                return _gz19;
            }
            set
            {
                _gz19 = value;
            }
        }

        private long _gz25;
        /// <summary>
        /// 计件量
        /// </summary>
        public long GZ25
        {
            get
            {
                return _gz25;
            }
            set
            {
                _gz25 = value;
            }
        }

        private long _gz26;
        /// <summary>
        /// 计时量
        /// </summary>
        public long GZ26
        {
            get
            {
                return _gz26;
            }
            set
            {
                _gz26 = value;
            }
        }

        private decimal _gz27;
        /// <summary>
        /// 工序计划单价
        /// </summary>
        public decimal GZ27
        {
            get
            {
                return _gz27;
            }
            set
            {
                _gz27 = value;
            }
        }

        private decimal _gz06;
        /// <summary>
        /// 计价单价
        /// </summary>
        public decimal GZ06
        {
            get
            {
                return _gz06;
            }
            set
            {
                _gz06 = value;
            }
        }

        private int _gz05;
        /// <summary>
        /// 计时标准日资(工序BOM)
        /// </summary>
        public int GZ05
        {
            get
            {
                return _gz05;
            }
            set
            {
                _gz05 = value;
            }
        }

        private string _gz07;
        /// <summary>
        /// 返工私增工序(工序BOM)
        /// </summary>
        public string GZ07
        {
            get
            {
                return _gz07;
            }
            set
            {
                _gz07 = value;
            }
        }

        private int _gz28;
        /// <summary>
        /// 结算月份
        /// </summary>
        public int GZ28
        {
            get
            {
                return _gz28;
            }
            set
            {
                _gz28 = value;
            }
        }

        private int _gz15;
        /// <summary>
        /// 结算工资
        /// </summary>
        public int GZ15
        {
            get
            {
                return _gz15;
            }
            set
            {
                _gz15 = value;
            }
        }

        private decimal _gz08;
        /// <summary>
        /// 合格率
        /// </summary>
        public decimal GZ08
        {
            get
            {
                return _gz08;
            }
            set
            {
                _gz08 = value;
            }
        }

        private string _gz16;
        /// <summary>
        /// 组长
        /// </summary>
        public string GZ16
        {
            get
            {
                return _gz16;
            }
            set
            {
                _gz16 = value;
            }
        }

        private string _gz18;
        /// <summary>
        /// 注明
        /// </summary>
        public string GZ18
        {
            get
            {
                return _gz18;
            }
            set
            {
                _gz18 = value;
            }
        }

        private string _gz20;
        /// <summary>
        /// 维护意见
        /// </summary>
        public string GZ20
        {
            get
            {
                return _gz20;
            }
            set
            {
                _gz20 = value;
            }
        }

        private string _gz21;
        /// <summary>
        /// 维护记录
        /// </summary>
        public string GZ21
        {
            get
            {
                return _gz21;
            }
            set
            {
                _gz21 = value;
            }
        }

        private string _gz30;
        /// <summary>
        /// 车间主任
        /// </summary>
        public string GZ30
        {
            get
            {
                return _gz30;
            }
            set
            {
                _gz30 = value;
            }
        }

        private string _gz31;
        /// <summary>
        /// 车间主任编号
        /// </summary>
        public string GZ31
        {
            get
            {
                return _gz31;
            }
            set
            {
                _gz31 = value;
            }
        }

        private string _gz32;
        /// <summary>
        /// 组长编号
        /// </summary>
        public string GZ32
        {
            get
            {
                return _gz32;
            }
            set
            {
                _gz32 = value;
            }
        }

        private string _gz33;
        /// <summary>
        /// 生产人编号
        /// </summary>
        public string GZ33
        {
            get
            {
                return _gz33;
            }
            set
            {
                _gz33 = value;
            }
        }

        private long _gz34;
        /// <summary>
        /// 产品数量
        /// </summary>
        public long GZ34
        {
            get
            {
                return _gz34;
            }
            set
            {
                _gz34 = value;
            }
        }

        private string _gz35;
        /// <summary>
        /// 年
        /// </summary>
        public string GZ35
        {
            get
            {
                return _gz35;
            }
            set
            {
                _gz35 = value;
            }
        }

        private decimal _gz36;
        /// <summary>
        /// 计时日工资
        /// </summary>
        public decimal GZ36
        {
            get
            {
                return _gz36;
            }
            set
            {
                _gz36 = value;
            }
        }

        private string _gz37;
        /// <summary>
        /// 统计员
        /// </summary>
        public string GZ37
        {
            get
            {
                return _gz37;
            }
            set
            {
                _gz37 = value;
            }
        }

        private string _gz38;
        /// <summary>
        /// 统计员编号
        /// </summary>
        public string GZ38
        {
            get
            {
                return _gz38;
            }
            set
            {
                _gz38 = value;
            }
        }

        private string _gz39;
        /// <summary>
        /// 状态
        /// </summary>
        public string GZ39
        {
            get
            {
                return _gz39;
            }
            set
            {
                _gz39 = value;
            }
        }

        private int _gz40;
        /// <summary>
        /// 零部件数量
        /// </summary>
        public int GZ40
        {
            get
            {
                return _gz40;
            }
            set
            {
                _gz40 = value;
            }
        }

        private string _gz42;
        /// <summary>
        /// 标识
        /// </summary>
        public string GZ42
        {
            get
            {
                return _gz42;
            }
            set
            {
                _gz42 = value;
            }
        }

        private DateTime _gz43;
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime GZ43
        {
            get
            {
                return _gz43;
            }
            set
            {
                _gz43 = value;
            }
        }

        private int _gz44;
        /// <summary>
        /// 结算年
        /// </summary>
        public int GZ44
        {
            get
            {
                return _gz44;
            }
            set
            {
                _gz44 = value;
            }
        }
    }
}
