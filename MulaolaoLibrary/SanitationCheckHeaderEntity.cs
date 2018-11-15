using System;
using System . Collections . Generic;
using System . Linq;
using System . Text;

namespace MulaolaoLibrary
{
    public class SanitationCheckHeaderEntity
    {
        #region Model
        private int _idx;
        private string _sac001;
        private string _sac002;
        private DateTime? _sac003;
        private DateTime? _sac004;
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
        public string SAC001
        {
            set
            {
                _sac001 = value;
            }
            get
            {
                return _sac001;
            }
        }
        /// <summary>
        /// 检查人
        /// </summary>
        public string SAC002
        {
            set
            {
                _sac002 = value;
            }
            get
            {
                return _sac002;
            }
        }
        /// <summary>
        /// 检查日期
        /// </summary>
        public DateTime? SAC003
        {
            set
            {
                _sac003 = value;
            }
            get
            {
                return _sac003;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SAC004
        {
            set
            {
                _sac004 = value;
            }
            get
            {
                return _sac004;
            }
        }
        #endregion Model
    }
}
