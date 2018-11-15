using System;
using System . Data;

namespace MulaolaoBll . Bll
{
    public class WarehouseReceiptBll
    {
        private readonly Dao.WarehouseReceiptDao _dao=new Dao.WarehouseReceiptDao();
        
        /// <summary>
        /// 获取入库单数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableS ( string strWhere )
        {
            return _dao . GetDataTableS ( strWhere );
        }

        /// <summary>
        /// 获取入库单数据集
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary . WarehouseReceiptWAREntity GetDataTableS ( int idx )
        {
            return _dao . GetDataTableS ( idx );
        }

        /// <summary>
        /// 是否存在出库记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exists ( int idx )
        {
            return _dao . Exists ( idx );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeleteS ( int idx )
        {
            return _dao . DeleteS ( idx );
        }


        /// <summary>
        /// 增加入库单记录
        /// </summary>
        /// <param name="_war"></param>
        /// <returns></returns>
        public bool AddS ( MulaolaoLibrary . WarehouseReceiptWAREntity _war )
        {
            return _dao . AddS ( _war );
        }

        /// <summary>
        /// 编辑入库单记录
        /// </summary>
        /// <param name="_war"></param>
        /// <returns></returns>
        public bool EditS ( MulaolaoLibrary . WarehouseReceiptWAREntity _war )
        {
            return _dao . EditS ( _war );
        }

        /// <summary>
        /// 获取原单价
        /// </summary>
        /// <param name="types"></param>
        /// <param name="name"></param>
        /// <param name="spece"></param>
        /// <returns></returns>
        public decimal priceS ( string types ,string name ,string spece )
        {
            return _dao . priceS ( types ,name ,spece );
        }

        /// <summary>
        /// 获取出库单数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableL ( string strWhere )
        {
            return _dao . GetDataTableL ( strWhere );
        }

        /// <summary>
        /// 获取出库单数据集
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary . WarehouseReceiptWASEntity GetDataTableL ( int idx )
        {
            return _dao . GetDataTableL ( idx );
        }


        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeleteL ( int idx )
        {
            return _dao . DeleteL ( idx );
        }

        /// <summary>
        /// 获取入库单
        /// </summary>
        /// <param name="types"></param>
        /// <param name="name"></param>
        /// <param name="spece"></param>
        /// <returns></returns>
        public DataTable GetDataTableOther ( string idx )
        {
            return _dao . GetDataTableOther ( idx );
        }

        /// <summary>
        /// 增加记录
        /// </summary>
        /// <param name="_was"></param>
        /// <returns></returns>
        public bool AddL ( MulaolaoLibrary . WarehouseReceiptWASEntity _was )
        {
            return _dao . AddL ( _was );
        }

        /// <summary>
        /// 编辑记录
        /// </summary>
        /// <param name="_was"></param>
        /// <returns></returns>
        public bool EditL ( MulaolaoLibrary . WarehouseReceiptWASEntity _was )
        {
            return _dao . EditL ( _was );
        }

        /// <summary>
        /// 获取原单价
        /// </summary>
        /// <param name="types"></param>
        /// <param name="name"></param>
        /// <param name="spece"></param>
        /// <returns></returns>
        public decimal price ( string types ,string name ,string spece )
        {
            return _dao . price ( types ,name ,spece );
        }

        /// <summary>
        /// 获取字段值
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( string fileName ,string tableName )
        {
            return _dao . GetDataTableOnly ( fileName ,tableName );
        }


        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePerson ( )
        {
            return _dao . GetDataTablePerson ( );
        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableUser ( )
        {
            return _dao . GetDataTableUser ( );
        }

        /// <summary>
        /// 入库单获取原单价
        /// </summary>
        /// <param name="types"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public decimal priceOne ( string types ,string name )
        {
            return _dao . priceOne ( types ,name );
        }


        /// <summary>
        /// 出库单获取原单价
        /// </summary>
        /// <param name="types"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public decimal priceTwo ( string types ,string name )
        {
            return _dao . priceTwo ( types ,name );
        }

        /// <summary>
        /// 获取出库列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableView ( string userNum )
        {
            return _dao . getTableView ( userNum );
        }


        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable getTableUser ( )
        {
            return _dao . getTableUser ( );
        }

        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="table"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool Library ( DataTable table ,DateTime dt )
        {
            return _dao . Library ( table ,dt );
        }

    }
}
