using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class SailsPaymentTaxRefundAndElectricityBillBll
    {
        Dao.SailsPaymentTaxRefundAndElectricityBillDao _dao = new Dao.SailsPaymentTaxRefundAndElectricityBillDao( );

        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="dateYear"></param>
        /// <param name="dateDay"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        public bool Exists ( int dateYear ,int dateDay ,string term )
        {
            return _dao.Exists( dateYear ,dateDay ,term );
        }
        public bool Exists ( int dateYear )
        {
            return _dao.Exists( dateYear );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int Add ( MulaolaoLibrary.SailsPaymentTaxRefundAndElectricityBillLibrary _model )
        {
            return _dao.Add( _model );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.SailsPaymentTaxRefundAndElectricityBillLibrary _model )
        {
            return _dao.Update( _model );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx )
        {
            return _dao.Delete( idx );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere )
        {
            return _dao.GetDataTable( strWhere );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableExists ( string oddNum )
        {
            return _dao.GetDataTableExists( oddNum );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Insert ( MulaolaoLibrary.SailsPaymentTaxRefundAndElectricityBillLibrary _model )
        {
            return _dao.Insert( _model );
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
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.SailsPaymentTaxRefundAndElectricityBillLibrary GetModel ( int idx )
        {
            return _dao.GetModel( idx );
        }
        public MulaolaoLibrary.SailsPaymentTaxRefundAndElectricityBillLibrary GetModel ( string oddNum )
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
        public DataTable GetDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            return _dao.GetDataTableByChange( strWhere ,startIndex ,endIndex );
        }

        /// <summary>
        /// 生成数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool AddOf ( MulaolaoLibrary.SailsPaymentTaxRefundAndElectricityBillLibrary _model )
        {
            return _dao.AddOf( _model );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfOddNum ( int year  )
        {
            return _dao.GetDataTableOfOddNum( year );
        }
    }
}
