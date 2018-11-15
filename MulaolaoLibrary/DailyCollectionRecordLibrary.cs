using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoLibrary
{
   public  class DailyCollectionRecordLibrary
    {
        private int _idx;
        /// <summary>
        /// 编号
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

        private string _ae01;

        /// <summary>
        /// 单号
        /// </summary>
        public string AE01
        {
            get
            {
                return _ae01;
            }
            set
            {
                _ae01 = value;
            }
        }

        private string _ae02;

        /// <summary>
        /// 流水号
        /// </summary>
        public string AE02
        {
            get
            {
                return _ae02;
            }
            set
            {
                _ae02 = value;
            }
        }

        private string _ae03;
        /// <summary>
        /// 产品名称
        /// </summary>
        public string AE03
        {
            get
            {
                return _ae03;
            }
            set
            {
                _ae03 = value;
            }
        }

        private string _ae04;

        /// <summary>
        /// 合同号
        /// </summary>
        public string AE04
        {
            get
            {
                return _ae04;
            }
            set
            {
                _ae04 = value;
            }
        }

        private string _ae05;

        /// <summary>
        /// 货号
        /// </summary>
        public string AE05
        {
            get
            {
                return _ae05;
            }
            set
            {
                _ae05 = value;
            }
        }

        private long _ae06;

        /// <summary>
        /// 产品数量
        /// </summary>
        public long AE06
        {
            get
            {
                return _ae06;
            }
            set
            {
                _ae06 = value;
            }
        }

        private string _ae07;

        /// <summary>
        /// 客户
        /// </summary>
        public string AE07
        {
            get
            {
                return _ae07;
            }
            set
            {
                _ae07 = value;
            }
        }

        private string _ae08;

        /// <summary>
        /// 生产车间
        /// </summary>
        public string AE08
        {
            get
            {
                return _ae08;
            }
            set
            {
                _ae08 = value;
            }
        }

        private string _ae09;

        /// <summary>
        /// 业务员
        /// </summary>
        public string AE09
        {
            get
            {
                return _ae09;
            }
            set
            {
                _ae09 = value;
            }
        }

        private decimal _ae10;

        /// <summary>
        /// 美元单价
        /// </summary>
        public decimal AE10
        {
            get
            {
                return _ae10;
            }
            set
            {
                _ae10 = value;
            }
        }

        private decimal _ae11;

        /// <summary>
        /// 合同汇率
        /// </summary>
        public decimal AE11
        {
            get
            {
                return _ae11;
            }
            set
            {
                _ae11 = value;
            }
        }

        private decimal _ae12;

        /// <summary>
        /// 产品单价
        /// </summary>
        public decimal AE12
        {
            get
            {
                return _ae12;
            }
            set
            {
                _ae12 = value;
            }
        }

        private string _ae13;

        /// <summary>
        /// FSC认证(是否)
        /// </summary>
        public string AE13
        {
            get
            {
                return _ae13;
            }
            set
            {
                _ae13 = value;
            }
        }

        private DateTime _ae14;

        /// <summary>
        /// 订货日期==下单日期
        /// </summary>
        public DateTime AE14
        {
            get
            {
                return _ae14;
            }
            set
            {
                _ae14 = value;
            }
        }

        private DateTime _ae15;

        /// <summary>
        /// 登记日期==执行日期
        /// </summary>
        public DateTime AE15
        {
            get
            {
                return _ae15;
            }
            set
            {
                _ae15 = value;
            }
        }

        private DateTime _ae16;

        /// <summary>
        /// 评审日期==执行日期
        /// </summary>
        public DateTime AE16
        {
            get
            {
                return _ae16;
            }
            set
            {
                _ae16 = value;
            }
        }

        private DateTime _ae17;

        /// <summary>
        /// ERP发货日期==合同交货日期
        /// </summary>
        public DateTime AE17
        {
            get
            {
                return _ae17;
            }
            set
            {
                _ae17 = value;
            }
        }

        private DateTime _ae18;

        /// <summary>
        /// 约定收款日期
        /// </summary>
        public DateTime AE18
        {
            get
            {
                return _ae18;
            }
            set
            {
                _ae18 = value;
            }
        }

        private decimal _ae19;

        /// <summary>
        /// 合同销售金额
        /// </summary>
        public decimal AE19
        {
            get
            {
                return _ae19;
            }
            set
            {
                _ae19 = value;
            }
        }

        private decimal _ae20;

        /// <summary>
        /// 结算汇率
        /// </summary>
        public decimal AE20
        {
            get
            {
                return _ae20;
            }
            set
            {
                _ae20 = value;
            }
        }

        private DateTime? _ae21 = null;

        /// <summary>
        /// 实际发货日期
        /// </summary>
        public DateTime? AE21
        {
            get
            {
                return _ae21;
            }
            set
            {
                _ae21 = value;
            }
        }

        private DateTime? _ae22 = null;

        /// <summary>
        /// 实际收款日期
        /// </summary>
        public DateTime? AE22
        {
            get
            {
                return _ae22;
            }
            set
            {
                _ae22 = value;
            }
        }

        private DateTime? _ae23 = null;

        /// <summary>
        /// 开票日期
        /// </summary>
        public DateTime? AE23
        {
            get
            {
                return _ae23;
            }
            set
            {
                _ae23 = value;
            }
        }

        private DateTime? _ae24 = null;

        /// <summary>
        /// 预收时间
        /// </summary>
        public DateTime? AE24
        {
            get
            {
                return _ae24;
            }
            set
            {
                _ae24 = value;
            }
        }

        private decimal _ae25;

        /// <summary>
        /// 发货应收款
        /// </summary>
        public decimal AE25
        {
            get
            {
                return _ae25;
            }
            set
            {
                _ae25 = value;
            }
        }

        private int _ae26;

        /// <summary>
        /// 开票数量
        /// </summary>
        public int AE26
        {
            get
            {
                return _ae26;
            }
            set
            {
                _ae26 = value;
            }
        }

        private decimal _ae27;

        /// <summary>
        /// 取消合同款
        /// </summary>
        public decimal AE27
        {
            get
            {
                return _ae27;
            }
            set
            {
                _ae27 = value;
            }
        }

        private decimal _ae28;

        /// <summary>
        /// 结算已收款
        /// </summary>
        public decimal AE28
        {
            get
            {
                return _ae28;
            }
            set
            {
                _ae28 = value;
            }
        }

        private decimal _ae29;

        /// <summary>
        /// 美金预收款
        /// </summary>
        public decimal AE29
        {
            get
            {
                return _ae29;
            }
            set
            {
                _ae29 = value;
            }
        }

        private decimal _ae30;

        /// <summary>
        /// 预收款
        /// </summary>
        public decimal AE30
        {
            get
            {
                return _ae30;
            }
            set
            {
                _ae30 = value;
            }
        }

        private decimal _ae31;

        /// <summary>
        /// 应扣款
        /// </summary>
        public decimal AE31
        {
            get
            {
                return _ae31;
            }
            set
            {
                _ae31 = value;
            }
        }

        private DateTime? _ae32 = null;

        /// <summary>
        /// 客检日期
        /// </summary>
        public DateTime? AE32
        {
            get
            {
                return _ae32;
            }
            set
            {
                _ae32 = value;
            }
        }

        private decimal _ae33;

        /// <summary>
        /// 其它收款
        /// </summary>
        public decimal AE33
        {
            get
            {
                return _ae33;
            }
            set
            {
                _ae33 = value;
            }
        }

        private decimal _ae34;

        /// <summary>
        /// 其它扣款
        /// </summary>
        public decimal AE34
        {
            get
            {
                return _ae34;
            }
            set
            {
                _ae34 = value;
            }
        }

        private string _ae35;

        /// <summary>
        /// 其它扣款事项说明
        /// </summary>
        public string AE35
        {
            get
            {
                return _ae35;
            }
            set
            {
                _ae35 = value;
            }
        }

        private string _ae36;

        /// <summary>
        /// 备注
        /// </summary>
        public string AE36
        {
            get
            {
                return _ae36;
            }
            set
            {
                _ae36 = value;
            }
        }

        private long _ae37;

        /// <summary>
        /// 发货数量
        /// </summary>
        public long AE37
        {
            get
            {
                return _ae37;
            }
            set
            {
                _ae37 = value;
            }
        }

        private long _ae38;

        /// <summary>
        /// 客检数量
        /// </summary>
        public long AE38
        {
            get
            {
                return _ae38;
            }
            set
            {
                _ae38 = value;
            }
        }

        private decimal _ae39;

        /// <summary>
        /// 开票汇率
        /// </summary>
        public decimal AE39
        {
            get
            {
                return _ae39;
            }
            set
            {
                _ae39 = value;
            }
        }

        private decimal _ae40;

        /// <summary>
        /// 开票差额
        /// </summary>
        public decimal AE40
        {
            get
            {
                return _ae40;
            }
            set
            {
                _ae40 = value;
            }
        }

        private decimal _ae41;

        /// <summary>
        /// 结算差额
        /// </summary>
        public decimal AE41
        {
            get
            {
                return _ae41;
            }
            set
            {
                _ae41 = value;
            }
        }

        private decimal _ae42;

        /// <summary>
        /// 合同结算差额
        /// </summary>
        public decimal AE42
        {
            get
            {
                return _ae42;
            }
            set
            {
                _ae42 = value;
            }
        }
    }
}
