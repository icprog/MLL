using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class TargetActualWarnBll
    {
        Dao.TargetActualWarnDao _dao = new Dao.TargetActualWarnDao( );

        /// <summary>
        /// 生成记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Generate ( MulaolaoLibrary.TargetActualWarnLibrary _model )
        {
            return _dao.Generate( _model );
        }

        /// <summary>
        /// 包括所有月份
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool InsertOfAll ( string oddNum )
        {
            return _dao . InsertOfAll ( oddNum );
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
        public DataTable GetDataTableTotal ( string oddNum )
        {
            return _dao . GetDataTableTotal ( oddNum );
        }


        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            return _dao.Delete( oddNum );
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
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere ,int startIndex ,int endIndex )
        {
            return _dao.GetDataTable( strWhere ,startIndex ,endIndex );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            return _dao.GetDataTable( );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool UpdateOne ( MulaolaoLibrary.TargetActualWarnLibrary _model )
        {
            return _dao.UpdateOne( _model );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.TargetActualWarnLibrary GetModel ( int idx )
        {
            return _dao.GetModel( idx );
        }
    }
}
