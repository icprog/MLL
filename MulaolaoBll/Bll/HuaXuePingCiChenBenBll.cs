using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll.Bll
{
    public class HuaXuePingCiChenBenBll
    {
        Dao.HuaXuePingCiChenBenDao _dao = new Dao.HuaXuePingCiChenBenDao( );
        /// <summary>
        /// 是否被339领用
        /// </summary>
        /// <param name="num"></param>
        /// <param name="nameOf"></param>
        /// <param name="workOf"></param>
        /// <param name="colorName"></param>
        /// <returns></returns>
        public bool yesOrNo ( string num ,string nameOf ,string workOf ,string colorName )
        {
            return _dao.yesOrNo( num ,nameOf ,workOf ,colorName );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string oddNum )
        {
            return _dao . GetDataTable ( oddNum );
        }

        /// <summary>
        /// 写数据到241
        /// </summary>
        /// <param name="modelAm"></param>
        /// <returns></returns>
        public bool UpdateOfRecevable ( MulaolaoLibrary . ProductCostSummaryLibrary modelAm , string oddNum )
        {
            return _dao . UpdateOfRecevable ( modelAm , oddNum );
        }

        /// <summary>
        /// 是否完工
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool UpdateOver ( string num )
        {
            return _dao . UpdateOver ( num );
        }

        /// <summary>
        /// 获取流水号
        /// </summary>
        /// <returns></returns>
        public DataTable getNum ( )
        {
            return _dao . getNum ( );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            return _dao . getTableView ( strWhere );
        }

    }
}
