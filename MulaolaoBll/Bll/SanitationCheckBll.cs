using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Text;

namespace MulaolaoBll . Bll
{
    public class SanitationCheckBll
    {
        readonly private Dao.SanitationCheckDao dal=null;
        public SanitationCheckBll ( )
        {
            dal = new Dao . SanitationCheckDao ( );
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable getTableView ( string code )
        {
            return dal . getTableView ( code );
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
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Save ( MulaolaoLibrary . SanitationCheckHeaderEntity model ,DataTable table )
        {
            return dal . Save ( model ,table );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="table"></param>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool Edit ( MulaolaoLibrary . SanitationCheckHeaderEntity model ,DataTable table ,List<string> idxList )
        {
            return dal . Edit ( model ,table ,idxList );
        }


        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        public DataTable getTableQuery ( string code )
        {
            return dal . getTableQuery ( code );
        }

        /// <summary>
        /// 获取车间
        /// </summary>
        /// <returns></returns>
        public DataTable getTableWork ( )
        {
            return dal . getTableWork ( );
        }

        /// <summary>
        /// 获取组长
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable getTableGroup (   )
        {
            return dal . getTableGroup (  );
        }

        /// <summary>
        /// 获取看板
        /// </summary>
        /// <returns></returns>
        public DataTable getTableAll ( )
        {
            return dal . getTableAll ( );
        }

        }
}
