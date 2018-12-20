using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace MulaolaoLibrary
{
    public class QuoEntity
    {
        #region Model
        private int _idx;
        private string _quo001;
        private string _quo002;
        private string _quo003;
        private string _quo004;
        private string _quo005;
        private string _quo006;
        private int? _quo007;
        private DateTime? _quo008;
        private byte[] _quo009;
        private string _quo010;
        private string _quo011;

        /// <summary>
        /// 
        /// </summary>
        public int idx
        {
            set
            {
                _idx = value;
            }
            get
            {
                return _idx;
            }
        }
        /// <summary>
        /// 单号
        /// </summary>
        public string QUO001
        {
            set
            {
                _quo001 = value;
            }
            get
            {
                return _quo001;
            }
        }
        /// <summary>
        /// 客户名称
        /// </summary>
        public string QUO002
        {
            set
            {
                _quo002 = value;
            }
            get
            {
                return _quo002;
            }
        }
        /// <summary>
        /// 产品编号
        /// </summary>
        public string QUO003
        {
            set
            {
                _quo003 = value;
            }
            get
            {
                return _quo003;
            }
        }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string QUO004
        {
            set
            {
                _quo004 = value;
            }
            get
            {
                return _quo004;
            }
        }
        /// <summary>
        /// 货号
        /// </summary>
        public string QUO005
        {
            set
            {
                _quo005 = value;
            }
            get
            {
                return _quo005;
            }
        }
        /// <summary>
        /// 流水号
        /// </summary>
        public string QUO006
        {
            set
            {
                _quo006 = value;
            }
            get
            {
                return _quo006;
            }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public int? QUO007
        {
            set
            {
                _quo007 = value;
            }
            get
            {
                return _quo007;
            }
        }
        /// <summary>
        /// 报价日期
        /// </summary>
        public DateTime? QUO008
        {
            set
            {
                _quo008 = value;
            }
            get
            {
                return _quo008;
            }
        }
        /// <summary>
        /// 图片
        /// </summary>
        public byte [ ] QUO009
        {
            set
            {
                _quo009 = value;
            }
            get
            {
                return _quo009;
            }
        }
        /// <summary>
        /// 业务员
        /// </summary>
        public string QUO010
        {
            set
            {
                _quo010 = value;
            }
            get
            {
                return _quo010;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QUO011
        {
            set
            {
                _quo011 = value;
            }
            get
            {
                return _quo011;
            }
        }
        #endregion Model
    }
}
