using System . Data;

namespace MulaolaoBll . Bll
{
    public class ProcessingDelayBll
    {
        Dao.ProcessingDelayDao dal=null;

        public ProcessingDelayBll ( )
        {
            dal = new Dao . ProcessingDelayDao ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            return dal . getTableView ( strWhere );
        }

        /// <summary>
        /// 获取产品名称
        /// </summary>
        /// <returns></returns>
        public DataTable getTablePro ( )
        {
            return dal . getTablePro ( );
        }

        }
}
