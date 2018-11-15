using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class TeamLeaderRoutineCheckBll
    {
        Dao.TeamLeaderRoutineCheckDao _dao = new Dao.TeamLeaderRoutineCheckDao( );

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,DateTime dt)
        {
            return _dao . Delete ( oddNum ,dt );
        }

        /// <summary>
        /// 更新数据到数据库
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool UpdateTable ( DataTable table )
        {
            return _dao.UpdateTable( table );
        }


        /// <summary>
        /// 生成报表
        /// </summary>
        /// <param name="dateSt"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Generate ( string dateSt ,int year ,int month ,MulaolaoLibrary.TeamLeaderRoutineCheckLibrary _model )
        {
            return _dao.Generate( dateSt ,year ,month ,_model );
        }


        /// <summary>
        /// 前后道468一致  一组组长
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateOf ( string oddNum )
        {
            return _dao . UpdateOf ( oddNum );
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
        public MulaolaoLibrary.TeamLeaderRoutineCheckLibrary GetModel ( string oddNum )
        {
            return _dao.GetModel( oddNum );
        }

        /// <summary>
        /// 编辑系数
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool UpdateOfCoe ( MulaolaoLibrary.TeamLeaderRoutineCheckLibrary _model )
        {
            return _dao.UpdateOfCoe( _model );
        }

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount ( string strWhere )
        {
            return _dao.GetCount( strWhere );
        }

        /// <summary>
        /// 获取数据列表
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
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            return _dao.GetDataTableOnly( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.TeamLeaderRoutineCheckLibrary GetDataTable ( int idx )
        {
            return _dao.GetDataTable( idx );
        }

        /// <summary>
        /// 编辑利润
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public bool UpdateOfEdit ( int idx ,int price )
        {
            return _dao.UpdateOfEdit( idx ,price );
        }

        /// <summary>
        /// 获取合计
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfSum ( string oddNum )
        {
            return _dao.GetDataTableOfSum( oddNum );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPrint ( DateTime dtOne )
        {
            return _dao . GetDataTableOfPrint ( dtOne );
        }

        /// <summary>
        /// 获取累计合计
        /// </summary>
        /// <param name="dtOne"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfCountSum ( string oddNum , DateTime dtOne)
        {
            return _dao . GetDataTableOfCountSum ( oddNum ,dtOne );
        }

        /// <summary>
        /// 获取本月分组合计
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfGroupSum ( string oddNum )
        {
            return _dao.GetDataTableOfGroupSum( oddNum );
        }


        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable PrintOne ( string oddNum )
        {
            return _dao . PrintOne ( oddNum );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable PrintTwo ( string oddNum )
        {
            return _dao . PrintTwo ( oddNum );
        }
    }
}
