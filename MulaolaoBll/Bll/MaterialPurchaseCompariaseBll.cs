using MulaolaoBll.Dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class MaterialPurchaseCompariaseBll
    {
        MaterialPurchaseCompariaseDao _dao = new MaterialPurchaseCompariaseDao( );
        /// <summary>
        /// 生成数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Generate ( MulaolaoLibrary.MaterialPurchaseCompariaseLibrary _model ,string year)
        {
            return _dao . Generate ( _model ,year );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            return _dao.GetDataTable( );
        }
    }
}
