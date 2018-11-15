using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class DailyUseOfChemicalsBll
    {
        Dao.DailyUseOfChemicalsDao _dao = new Dao.DailyUseOfChemicalsDao( );
        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int Add ( MulaolaoLibrary.DailyUseOfChemicals _model )
        {
            return _dao.Add( _model );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.DailyUseOfChemicals _model )
        {
            return _dao.Update( _model );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx )
        {
            return _dao.Delete( idx );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere )
        {
            return _dao.GetDataTable( strWhere );
        }

        /// <summary>
        /// 是否被339领用
        /// </summary>
        /// <param name="num"></param>
        /// <param name="nameOf"></param>
        /// <param name="workOf"></param>
        /// <param name="colorName"></param>
        /// <returns>true:没有  false:有</returns>
        public bool yesOrNo ( string num ,string nameOf ,string workOf ,string colorName )
        {
            return _dao.yesOrNo( num ,nameOf ,workOf ,colorName );
        }
    }
}
