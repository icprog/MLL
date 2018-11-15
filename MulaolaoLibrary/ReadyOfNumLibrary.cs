using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MulaolaoLibrary
{
    public class ReadyOfNumLibrary
    {
        private string _bg001;
        private string _bg002;
        private string _bg003;
        private int _bg004;
        private string _bg005;

        /// <summary>
        /// 预流水号
        /// </summary>
        public string BG001
        {
            get
            {
                return _bg001;
            }
            set
            {
                _bg001 = value;
            }
        }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string BG002
        {
            get
            {
                return _bg002;
            }
            set
            {
                _bg002 = value;
            }
        }
        /// <summary>
        /// 货号
        /// </summary>
        public string BG003
        {
            get
            {
                return _bg003;
            }
            set
            {
                _bg003 = value;
            }
        }
        /// <summary>
        /// 产品数量
        /// </summary>
        public int BG004
        {
            get
            {
                return _bg004;
            }
            set
            {
                _bg004 = value;
            }
        }
        /// <summary>
        /// 流水
        /// </summary>
        public string BG005
        {
            get
            {
                return _bg005;
            }
            set
            {
                _bg005 = value;
            }
        }
    }
}
