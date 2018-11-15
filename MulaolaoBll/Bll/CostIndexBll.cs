using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class CostIndexBll
    {
        Dao.CostIndexDao _dao = new Dao.CostIndexDao( );

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            return _dao.Delete( oddNum );
        }
        public bool DeleteTwo ( DateTime dtTime )
        {
            return _dao.DeleteTwo( dtTime );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            return _dao.GetDataTableOnly( );
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount ( string strWhere )
        {
            return _dao.GetCount( strWhere );
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            return _dao.GetDataTableByChange( strWhere ,startIndex ,endIndex );
        }

        /// <summary>
        /// 生成数据s
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool GetDataTableGenerate ( MulaolaoLibrary.CostIndexLibrary _model )
        {
            return _dao.GetDataTableGenerate( _model );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string oddNum )
        {
            return _dao.GetDataTable( oddNum );
        }
        public DataTable GetDataTable ( DateTime dtTime )
        {
            return _dao.GetDataTable( dtTime );
        }
        public DataTable GetDataTableOne ( DateTime dtTime )
        {
            return _dao.GetDataTableOne( dtTime );
        }
        public DataTable GetDataTableTwo ( DateTime dtTime )
        {
            return _dao.GetDataTableTwo( dtTime );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool AddTable ( DataTable table )
        {
            return _dao.AddTable( table );
        }
        public bool AddTableOne ( DataTable table )
        {
            return _dao.AddTableOne( table );
        }
        public bool AddTableTwo ( DataTable table )
        {
            return _dao.AddTableTwo( table );
        }
        public bool AddTableTre ( DataTable table )
        {
            return _dao.AddTableTre( table );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public DataTable GetDataTableTwo ( int dt )
        {
            return _dao.GetDataTableTwo( dt );
        }

        /// <summary>
        /// 生成年度报表
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool GetDataTableGenerate ( MulaolaoLibrary.CostIndexOneLibrary _model )
        {
            return _dao.GetDataTableGenerate( _model );
        }
    }
}
