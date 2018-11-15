using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MulaolaoLibrary
{
    public class SailesLibrary
    {
        public SailesLibrary ( )
        {
        }

        #region Model
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

        private string _pqf01;
        /// <summary>
        /// 流水号
        /// </summary>
        public string PQF01
        {
            get
            {
                return _pqf01;
            }
            set
            {
                _pqf01 = value;
            }
        }

        private string _pqf02;
        /// <summary>
        /// 合同编号
        /// </summary>
        public string PQF02
        {
            get
            {
                return _pqf02;
            }
            set
            {
                _pqf02 = value;
            }
        }

        private string _pqf03;
        /// <summary>
        /// 货号
        /// </summary>
        public string PQF03
        {
            get
            {
                return _pqf03;
            }
            set
            {
                _pqf03 = value;
            }
        }

        public string _pqf04;
        /// <summary>
        /// 产品名称
        /// </summary>
        public string PQF04
        {
            get
            {
                return _pqf04;
            }
            set
            {
                _pqf04 = value;
            }
        }

        public string _pqf05;
        /// <summary>
        /// 单位
        /// </summary>
        public string PQF05
        {
            get
            {
                return _pqf05;
            }
            set
            {
                _pqf05 = value;
            }
        }

        private long _pqf06;
        /// <summary>
        /// 产品数量
        /// </summary>
        public long PQF06
        {
            get
            {
                return _pqf06;
            }
            set
            {
                _pqf06 = value;
            }
        }

        public string _pqf07;
        /// <summary>
        /// 目的国
        /// </summary>
        public string PQF07
        {
            get
            {
                return _pqf07;
            }
            set
            {
                _pqf07 = value;
            }
        }

        public string _pqf08;
        /// <summary>
        /// 
        /// </summary>
        public string PQF08
        {
            get
            {
                return _pqf08;
            }
            set
            {
                _pqf08 = value;
            }
        }

        private decimal _pqf09;
        /// <summary>
        /// 产品单价
        /// </summary>
        public decimal PQF09
        {
            get
            {
                return _pqf09;
            }
            set
            {
                _pqf09 = value;
            }
        }

        private decimal _pqf10;
        /// <summary>
        /// 美元单价
        /// </summary>
        public decimal PQF10
        {
            get
            {
                return _pqf10;
            }
            set
            {
                _pqf10 = value;
            }
        }

        private string _pqf11;
        /// <summary>
        /// 
        /// </summary>
        public string PQF11
        {
            get
            {
                return _pqf11;
            }set
            {
                _pqf11 = value;
            }
        }

        private string _pqf12;
        /// <summary>
        /// 人员编号
        /// </summary>
        public string PQF12
        {
            get
            {
                return _pqf12;
            }
            set
            {
                _pqf12 = value;
            }
        }

        private DateTime _pqf13;
        /// <summary>
        /// 订货日期
        /// </summary>
        public DateTime PQF13
        {
            get
            {
                return _pqf13;
            }
            set
            {
                _pqf13 = value;
            }
        }

        private string _pqf17;
        /// <summary>
        /// 部门编号
        /// </summary>
        public string PQF17
        {
            get
            {
                return _pqf17;
            }
            set
            {
                _pqf17 = value;
            }
        }

        private string _pqf20;
        /// <summary>
        /// 贸易类型
        /// </summary>
        public string PQF20
        {
            get
            {
                return _pqf20;
            }
            set
            {
                _pqf20 = value;
            }
        }

        private string _pqf21;
        /// <summary>
        /// 单据状态
        /// </summary>
        public string PQF21
        {
            get
            {
                return _pqf21;
            }
            set
            {
                _pqf21 = value;
            }
        }

        private string _pqf23;
        /// <summary>
        /// FSC认证
        /// </summary>
        public string PQF23
        {
            get
            {
                return _pqf23;
            }
            set
            {
                _pqf23 = value;
            }
        }

        private string _pqf24;
        /// <summary>
        /// 是否专利
        /// </summary>
        public string PQF24
        {
            get
            {
                return _pqf24;
            }
            set
            {
                _pqf24 = value;
            }
        }

        private byte[] _pqf29 = new byte[0];
        /// <summary>
        /// 产品图片
        /// </summary>
        public byte[] PQF29
        {
            get
            {
                return _pqf29;
            }
            set
            {
                _pqf29 = value;
            }
        }

        private DateTime _pqf31;
        /// <summary>
        /// 合同交货日期
        /// </summary>
        public DateTime PQF31
        {
            get
            {
                return _pqf31;
            }
            set
            {
                _pqf31 = value;
            }
        }

        private DateTime _pqf32;
        /// <summary>
        /// 输入ERP日期
        /// </summary>
        public DateTime PQF32
        {
            get
            {
                return _pqf32;
            }
            set
            {
                _pqf32 = value;
            }
        }

        private DateTime _pqf34;
        /// <summary>
        /// 约定收款日期
        /// </summary>
        public DateTime PQF34
        {
            get
            {
                return _pqf34;
            }
            set
            {
                _pqf34 = value;
            }
        }

        private decimal _pqf38;
        /// <summary>
        /// 预收款金额
        /// </summary>
        public decimal PQF38
        {
            get
            {
                return _pqf38;
            }
            set
            {
                _pqf38 = value;
            }
        }

        private string _pqf41;
        /// <summary>
        /// 货币类型
        /// </summary>
        public string PQF41
        {
            get
            {
                return _pqf41;
            }
            set
            {
                _pqf41 = value;
            }
        }

        private string _pqf44;
        /// <summary>
        /// 扣税类别
        /// </summary>
        public string PQF44
        {
            get
            {
                return _pqf44;
            }
            set
            {
                _pqf44 = value;
            }
        }

        private decimal _pqf45;
        /// <summary>
        /// 合同汇率
        /// </summary>
        public decimal PQF45
        {
            get
            {
                return _pqf45;
            }
            set
            {
                _pqf45 = value;
            }
        }

        private string _pqf47;
        /// <summary>
        /// 付款方式
        /// </summary>
        public string PQF47
        {
            get
            {
                return _pqf47;
            }
            set
            {
                _pqf47 = value;
            }
        }

        private decimal _pqf49;
        /// <summary>
        /// 其他收款
        /// </summary>
        public decimal PQF49
        {
            get
            {
                return _pqf49;
            }
            set
            {
                _pqf49 = value;
            }
        }

        private string _pqf51;
        /// <summary>
        /// 扣款事项说明
        /// </summary>
        public string PQF51
        {
            get
            {
                return _pqf51;
            }
            set
            {
                _pqf51 = value;
            }
        }

        private string _pqf55;
        /// <summary>
        /// 制单人员编号
        /// </summary>
        public string PQF55
        {
            get
            {
                return _pqf55;
            }
            set
            {
                _pqf55 = value;
            }
        }

        private DateTime _pqf56;
        /// <summary>
        /// 制单日期
        /// </summary>
        public DateTime PQF56
        {
            get
            {
                return _pqf56;
            }
            set
            {
                _pqf56 = value;
            }
        }

        private string _pqf57;
        /// <summary>
        /// 审核人员编号
        /// </summary>
        public string PQF57
        {
            get
            {
                return _pqf57;
            }
            set
            {
                _pqf57 = value;
            }
        }

        private DateTime _pqf58;
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime PQF58
        {
            get
            {
                return _pqf58;
            }
            set
            {
                _pqf58 = value;
            }
        }

        private string _pqf59;
        /// <summary>
        /// 销售部门编号
        /// </summary>
        public string PQF59
        {
            get
            {
                return _pqf59;
            }
            set
            {
                _pqf59 = value;
            }
        }

        private string _pqf60;
        /// <summary>
        /// 交货方式
        /// </summary>
        public string PQF60
        {
            get
            {
                return _pqf60;
            }
            set
            {
                _pqf60 = value;
            }
        }

        private string _pqf61;
        /// <summary>
        /// 备注
        /// </summary>
        public string PQF61
        {
            get
            {
                return _pqf61;
            }
            set
            {
                _pqf61 = value;
            }
        }

        private byte[] _pqf62 = new byte[0];
        /// <summary>
        /// 合同附件
        /// </summary>
        public byte[] PQF62
        {
            get
            {
                return _pqf62;
            }
            set
            {
                _pqf62 = value;
            }
        }

        private DateTime _pqf63;
        /// <summary>
        /// 合同初审日期
        /// </summary>
        public DateTime PQF63
        {
            get
            {
                return _pqf63;
            }
            set
            {
                _pqf63 = value;
            }
        }

        private string _pqf64;
        /// <summary>
        /// 维护意见
        /// </summary>
        public string PQF64
        {
            get
            {
                return _pqf64;
            }
            set
            {
                _pqf64 = value;
            }
        }
        
        private string _pqf65;
        /// <summary>
        /// 维护记录
        /// </summary>
        public string PQF65
        {
            get
            {
                return _pqf65;
            }
            set
            {
                _pqf65 = value;
            }
        }

        private string _pqf66;
        /// <summary>
        /// 生产车间姓名
        /// </summary>
        public string PQF66
        {
            get
            {
                return _pqf66;
            }
            set
            {
                _pqf66 = value;
            }
        }

        private string _pqf67;
        /// <summary>
        /// 业务员姓名
        /// </summary>
        public string PQF67
        {
            get
            {
                return _pqf67;
            }
            set
            {
                _pqf67 = value;
            }
        }
        #endregion
    }
}
