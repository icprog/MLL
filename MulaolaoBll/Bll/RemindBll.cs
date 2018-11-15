using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class RemindBll
    {
        Dao.RemindDao dal=null;
        public RemindBll ( )
        {
            dal = new Dao . RemindDao ( );
        }

        /// <summary>
        /// 获取021-509--436--046提示
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public DataTable getTableFor021 ( string userNum )
        {
            return dal . getTableFor021 ( userNum );
        }

        /// <summary>
        /// 获取采购合同提示
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public DataTable getTableForContract ( string userNum )
        {
            return dal . getTableForContract ( userNum );
        }


        /// <summary>
        /// 确认实际到货日期
        /// </summary>
        /// <param name="tableNum"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool UpdateDate ( string tableNum ,string idx )
        {
            return dal . UpdateDate ( tableNum ,idx );
        }

        /// <summary>
        /// 339  337确认到货日期
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateDateT ( string tableNum ,string oddNum )
        {
            return dal . UpdateDateT ( tableNum ,oddNum );
        }


        /// <summary>
        /// 获取509存在  合同未开的数据
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public DataTable getTableForContractAll ( )
        {
            return dal . getTableForContractAll ( );
        }

        /// <summary>
        /// 是否已开合同
        /// </summary>
        /// <param name="num"></param>
        /// <param name="tab"></param>
        /// <returns></returns>
        public bool UpdateOver ( DataRow row )
        {
            return dal . UpdateOver ( row );
        }

        /// <summary>
        /// 编辑509中已开合同的GS73='T'
        /// </summary>
        /// <returns></returns>
        public bool UpdateOver ( )
        {
            return dal . UpdateOver ( );
        }

    }
}
