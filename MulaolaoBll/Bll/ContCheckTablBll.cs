using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class ContCheckTablBll
    {
        Dao.ContCheckTableDao _dal=null;
        public ContCheckTablBll ( )
        {
            _dal = new Dao . ContCheckTableDao ( );
        }

        /// <summary>
        /// 获取所有的采购合同执行未结账
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public DataTable getTable ( int year ,bool state,string tableNum)
        {
            return _dal . getTable ( year ,state ,tableNum );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Update ( DataTable table )
        {
            return _dal . Update ( table );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary . ContCheckTableEntity _model )
        {
            return _dal . Delete ( _model );
        }

    }
}
