using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class QualityTestingBll
    {
        Dao.QualityTestingDao _dao = new Dao.QualityTestingDao( );

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            return _dao.Delete( oddNum );
        }

        /// <summary>
        /// 复制一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Copys ( string oddNum )
        {
            return _dao.Copys( oddNum );
        }

        /// <summary>
        /// 编辑复制记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateCopy ( string oddNum )
        {
            return _dao.UpdateCopy( oddNum );
        }

        /// <summary>
        /// 删除复制记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DleteCopy (  )
        {
            return _dao.DleteCopy( );
        }

        /// <summary>
        /// 保存表数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool SaveOf ( DataTable table )
        {
            return _dao.SaveOf( table );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOf ( string oddNum ,string num)
        {
            return _dao.GetDataTableOf( oddNum ,num );
        }
        public DataTable GetDataTableOf ( string oddNum )
        {
            return _dao.GetDataTableOf( oddNum );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool SaveOfUpdate ( MulaolaoLibrary.QualityTestingLibrary _model )
        {
            return _dao.SaveOfUpdate( _model );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary.QualityTestingLibrary GetModel ( string oddNum )
        {
            return _dao.GetModel( oddNum );
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
        /// 获取数据总记录数
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
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfLj ( string num )
        {
            return _dao.GetDataTableOfLj( num );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfNum ( )
        {
            return _dao.GetDataTableOfNum( );
        }


        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrint ( string oddNum )
        {
            return _dao.GetDataTablePrint( oddNum );
        }

        /// <summary>
        /// 获取打印数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableExport ( string oddNum )
        {
            return _dao.GetDataTableExport( oddNum );
        }
    }
}
