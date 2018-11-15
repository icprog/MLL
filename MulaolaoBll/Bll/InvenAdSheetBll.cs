using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class InvenAdSheetBll
    {
        private readonly Dao.InvenAdSheetDao dal=null;
        public InvenAdSheetBll ( )
        {
            dal = new Dao . InvenAdSheetDao ( );
        }

        /// <summary>
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public string getCode ( )
        {
            return dal . getCode ( );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool Delete ( string code )
        {
            return dal . Delete ( code );
        }

        /// <summary>
        /// 查询入库记录
        /// </summary>
        /// <param name="codeForRK"></param>
        /// <returns></returns>
        public DataTable getTableRK (   )
        {
            return dal . getTableRK (  );
        }

        /// <summary>
        /// 查询出库记录
        /// </summary>
        /// <param name="codeForCK"></param>
        /// <returns></returns>
        public DataTable getTableCK ( string code )
        {
            return dal . getTableCK ( code );
        }

        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="table"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( DataTable table ,MulaolaoLibrary . InvenAdSheetINAEntity model )
        {
            return dal . Add ( table ,model );
        }

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="table"></param>
        /// <param name="model"></param>
        /// <param name="strList"></param>
        /// <returns></returns>
        public bool Edit ( DataTable table ,MulaolaoLibrary . InvenAdSheetINAEntity model ,List<string> strList )
        {
            return dal . Edit ( table ,model ,strList );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public DataTable getTableView ( string code )
        {
            return dal . getTableView ( code );
        }

        /// <summary>
        /// 获取查询数据
        /// </summary>
        /// <returns></returns>
        public DataTable getTableQuery ( )
        {
            return dal . getTableQuery ( );
        }

        /// <summary>
        /// 回写数据到464中
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public bool writeTo ( string code )
        {
            return dal . writeTo ( code );
        }

    }
}
