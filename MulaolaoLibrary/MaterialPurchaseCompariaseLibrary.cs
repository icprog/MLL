using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MulaolaoLibrary
{
    public class MaterialPurchaseCompariaseLibrary
    {
        private string _au001;
        /// <summary>
        /// 项
        /// </summary>
        public string AU001
        {
            get
            {
                return _au001;
            }
            set
            {
                _au001 = value;
            }
        }

        private int _au002;
        /// <summary>
        /// 采购合同合计应付款
        /// </summary>
        public int AU002
        {
            get
            {
                return _au002;
            }
            set
            {
                _au002 = value;
            }
        }

        private int _au003;
        /// <summary>
        /// 采购合同累计已付款
        /// </summary>
        public int AU003
        {
            get
            {
                return _au003;
            }
            set
            {
                _au003 = value;
            }
        }

        private int _au004;
        /// <summary>
        /// 采购合同累计未付款
        /// </summary>
        public int AU004
        {
            get
            {
                return _au004;
            }
            set
            {
                _au004 = value;
            }
        }
    }
}
