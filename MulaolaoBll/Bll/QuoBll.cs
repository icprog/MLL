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
        public DataTable getTableFor195Info ( )
        {
            return dal . getTableFor195Info ( );
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

        }
}
