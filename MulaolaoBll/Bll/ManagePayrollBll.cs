using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class ManagePayrollBll
    {
        Dao.ManagePayrollDao _dao = new Dao.ManagePayrollDao( );

        /// <summary>
        /// 获取负责人信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTablePersonInCharge ( )
        {
            return _dao.GetDataTablePersonInCharge( );
        }


        /// <summary>
        /// 获取单位
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableCompany ( )
        {
            return _dao.GetDataTableCompany( );
        }

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
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfWeiHu ( string oddNum )
        {
            return _dao.GetDataTableOfWeiHu( oddNum );
        }

        /// <summary>
        /// 编辑一单记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.ManagePayrollLibrary _model )
        {
            return _dao.Update( _model );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.ManagePayrollLibrary _model )
        {
            return _dao.Exists( _model );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int Add ( MulaolaoLibrary.ManagePayrollLibrary _model )
        {
            return _dao.Add( _model );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ManagePayrollLibrary GetModel ( int idx )
        {
            return _dao.GetModel( idx );
        }
        public MulaolaoLibrary.ManagePayrollLibrary GetModel ( string oddNum )
        {
            return _dao.GetModel( oddNum );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Updates ( MulaolaoLibrary.ManagePayrollLibrary _model )
        {
            return _dao.Updates( _model );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Deletes ( int idx )
        {
            return _dao.Deletes( idx );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere ,DateTime dt )
        {
            return _dao.GetDataTable( strWhere,dt );
        }
        public DataTable GetDataTableTwo ( string strWhere ,DateTime dt )
        {
            return _dao.GetDataTableTwo( strWhere,dt );
        }
        public DataTable GetDataTableTre ( string strWhere ,DateTime dt )
        {
            return _dao.GetDataTableTre( strWhere ,dt );
        }
        public DataTable GetDataTableFor ( string strWhere ,DateTime dt )
        {
            return _dao.GetDataTableFor( strWhere ,dt );
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
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrint ( string oddNum ,string strPrintWhere)
        {
            return _dao.GetDataTablePrint( oddNum ,strPrintWhere );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableExport ( string oddNum,string strPrintWhere )
        {
            return _dao.GetDataTableExport( oddNum ,strPrintWhere );
        }

        /// <summary>
        /// 复制数据
        /// </summary>
        /// <param name="OddNum"></param>
        /// <returns></returns>
        public bool Copy ( string OddNum )
        {
            return _dao.Copy( OddNum );
        }

        /// <summary>
        /// 删除复制数据
        /// </summary>
        /// <returns></returns>
        public bool DeleteOfCopy ( )
        {
            return _dao.DeleteOfCopy( );
        }


        /// <summary>
        /// 编辑复制数据
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateOfCopy ( string oddNum )
        {
            return _dao.UpdateOfCopy( oddNum );
        }


        /// <summary>
        /// 批量编辑养老
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="yl"></param>
        /// <returns></returns>
        public bool BatchEdit ( string oddNum ,decimal yl )
        {
            return _dao.BatchEdit( oddNum ,yl );
        }
    }
}
