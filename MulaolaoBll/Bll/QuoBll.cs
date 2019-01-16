using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;


namespace MulaolaoBll . Bll
{
    public class QuoBll
    {
        private readonly Dao.QuoDao dal=null;
        public QuoBll ( )
        {
            dal = new Dao . QuoDao ( );
        }


        /// <summary>
        /// 获取195数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableFor195Info (DateTime dt )
        {
            return dal . getTableFor195Info (dt );
        }

        /// <summary>
        /// 获取196数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableFor196Info ( DateTime dt )
        {
            return dal . getTableFor196Info (dt );
        }

        /// <summary>
        /// 获取338数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableFor338Info ( DateTime dt )
        {
            return dal . getTableFor338Info ( dt );
        }

        /// <summary>
        /// 获取339数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableFor339Info ( DateTime dt )
        {
            return dal . getTableFor339Info ( dt );
        }

        /// <summary>
        /// 获取347数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable getTableFor347Info ( DateTime dt )
        {
            return dal . getTableFor347Info ( dt );
        }

        /// <summary>
        /// 获取341数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable getTableFor341Info ( DateTime dt )
        {
            return dal . getTableFor341Info ( dt );
        }

        /// <summary>
        /// 获取342数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable getTableFor342Info ( DateTime dt )
        {
            return dal . getTableFor342Info ( dt );
        }

        /// <summary>
        /// 获取343数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable getTableFor343Info ( DateTime dt )
        {
            return dal . getTableFor343Info ( dt );
        }

        /// <summary>
        /// 获取349数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable getTableFor349Info ( DateTime dt )
        {
            return dal . getTableFor349Info ( dt );
        }

        /// <summary>
        /// 获取344数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableFor344Info ( DateTime dt )
        {
            return dal . getTableFor344Info ( dt );
        }

        /// <summary>
        /// 获取509工段
        /// </summary>
        /// <returns></returns>
        public DataTable getTableFor509GX ( )
        {
            return dal . getTableFor509GX ( );
        }

        /// <summary>
        /// 获取单号
        /// </summary>
        /// <returns></returns>
        public string getOddNum ( )
        {
            return dal . getOddNum ( );
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
        /// 删除数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            return dal . Delete ( oddNum );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="_quo"></param>
        /// <param name="table"></param>
        /// <param name="state"></param>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool Save ( MulaolaoLibrary . QuoEntity _quo ,DataTable table ,string state ,List<string> idxList )
        {
            return dal . Save ( _quo ,table ,state ,idxList );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOnlyColumn ( )
        {
            return dal . getTableOnlyColumn ( );
        }

        /// <summary>
        /// 获取总数量
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            return dal . getCount ( strWhere );
        }

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable getDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            return dal . getDataTableByChange ( strWhere ,startIndex ,endIndex );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public MulaolaoLibrary . QuoEntity getModel ( string strWhere )
        {
            return dal . getModel ( strWhere );
        }

        /// <summary>
        /// 获取业务人员
        /// </summary>
        /// <returns></returns>
        public DataTable getTableFor ( )
        {
            return dal . getTableFor ( );
        }

        }
}
