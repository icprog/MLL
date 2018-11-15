using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class WorkWagesBll
    {
        Dao.WorkWagesDao _dao = new Dao.WorkWagesDao( );
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( int year ,int month ,string yearMonth )
        {
            return _dao.GetDataTable( year ,month ,yearMonth );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( string yearMonth )
        {
            return _dao.GetDataTable( yearMonth );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public bool Exists ( int year ,int month )
        {
            return _dao.Exists( year ,month );
        }

        /// <summary>
        /// 317本月考勤和工资
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool GetDataTableOne ( MulaolaoLibrary.WorkWagesLibrary _model )
        {
            return _dao.GetDataTableOne( _model );
        }

        /// <summary>
        /// 317本月以及本月以前的考勤和工资
        /// </summary>
        /// <param name="yearMonth"></param>
        /// <returns></returns>
        public bool GetDataTableTwo ( MulaolaoLibrary.WorkWagesLibrary _model )
        {
            return _dao.GetDataTableTwo( _model );
        }

        /// <summary>
        /// 323本月考勤及工资
        /// </summary>
        /// <param name="yearMonth"></param>
        /// <returns></returns>
        public bool GetDataTableTre ( MulaolaoLibrary.WorkWagesLibrary _model ,string yearMonth )
        {
            return _dao.GetDataTableTre( _model ,yearMonth );
        }

        /// <summary>
        /// 323本月以及本月以前的考勤和工资
        /// </summary>
        /// <param name="yearMonth"></param>
        /// <returns></returns>
        public bool GetDataTableFor ( MulaolaoLibrary.WorkWagesLibrary _model ,string yearMonth )
        {
            return _dao.GetDataTableFor( _model ,yearMonth );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            return _dao.Delete( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTables ( string oddNum )
        {
            return _dao.GetDataTables( oddNum );
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
        /// 分页获取数据
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
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.WorkWagesLibrary GetModel ( int idx )
        {
            return _dao.GetModel( idx );
        }
    }
}
