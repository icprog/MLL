using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace MulaolaoLibrary
{
    public class InvenAdSheetINAEntity
    {
        private int _id;
        private string _ina001;
        private string _ina002;
        private string _ina003;
        private DateTime? _ina004;
        private string _ina005;
        private string _ina006;
        private string _ina007;

        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set
            {
                _id = value;
            }
            get
            {
                return _id;
            }
        }
        /// <summary>
        /// 单号
        /// </summary>
        public string INA001
        {
            set
            {
                _ina001 = value;
            }
            get
            {
                return _ina001;
            }
        }
        /// <summary>
        /// 合同类别
        /// </summary>
        public string INA002
        {
            set
            {
                _ina002 = value;
            }
            get
            {
                return _ina002;
            }
        }
        /// <summary>
        /// 出入库
        /// </summary>
        public string INA003
        {
            set
            {
                _ina003 = value;
            }
            get
            {
                return _ina003;
            }
        }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime? INA004
        {
            set
            {
                _ina004 = value;
            }
            get
            {
                return _ina004;
            }
        }
        /// <summary>
        /// 操作人
        /// </summary>
        public string INA005
        {
            set
            {
                _ina005 = value;
            }
            get
            {
                return _ina005;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string INA006
        {
            set
            {
                _ina006 = value;
            }
            get
            {
                return _ina006;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string INA007
        {
            set
            {
                _ina007 = value;
            }
            get
            {
                return _ina007;
            }
        }
    } 
}
