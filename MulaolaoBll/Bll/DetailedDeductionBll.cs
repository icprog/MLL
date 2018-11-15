using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class DetailedDeductionBll
    {
        Dao.DetailedDeductionDao _dao = new Dao.DetailedDeductionDao( );

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            return _dao.Delete( oddNum );
        }

        /// <summary>
        /// 获取车间主任信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable ( )
        {
            return _dao.GetDataTable( );
        }

        /// <summary>
        /// 获取采购人
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfPurchase ( )
        {
            return _dao.GetDataTableOfPurchase( );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public int Add ( MulaolaoLibrary.DetailedDeductionLibrary _model )
        {
            return _dao.Add( _model );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableGrid ( string strWhere )
        {
            return _dao.GetDataTableGrid( strWhere );
        }
        public DataTable GetDataTableGrid ( )
        {
            return _dao . GetDataTableGrid ( );
        }

        public DataTable GetDataTableZ ( string strWhere )
        {
            return _dao . GetDataTableZ ( strWhere );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Edit ( MulaolaoLibrary.DetailedDeductionLibrary _model )
        {
            return _dao.Edit( _model );
        }

        /// <summary>
        /// 是否存在本次付款记录且已经审核或执行
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exit ( int idx )
        {
            return _dao . Exit ( idx );
        }


        /// <summary>
        /// 木佬佬付款是否存在
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exit_231 ( int idx )
        {
            return _dao . Exit_231 ( idx );
        }

        /// <summary>
        /// 永灵付款是否存在
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exit_231_yl ( int idx )
        {
            return _dao . Exit_231_yl ( idx );
        }

        /// <summary>
        /// 木佬佬扣款是否存在
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exit_231_MK ( int idx )
        {
            return _dao . Exit_231_MK ( idx );
        }


        /// <summary>
        /// 永灵扣款是否存在
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Exit_231_YL ( int idx )
        {
            return _dao . Exit_231_YL ( idx );
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
        /// <param name="startIndedx"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByChange ( string strWhere ,int startIndedx ,int endIndex )
        {
            return _dao.GetDataTableByChange( strWhere ,startIndedx ,endIndex );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.DetailedDeductionLibrary GetModel ( int idx )
        {
            return _dao.GetModel( idx );
        }

        /// <summary>
        /// 获取流水号等信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableNum ( )
        {
            return _dao.GetDataTableNum( );
        }

        /// <summary>
        /// 供应商
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSupplier ( )
        {
            return _dao.GetDataTableSupplier( );
        }

        /// <summary>
        /// 获取付款明细
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public DataTable getTableOf ( int idx )
        {
            return _dao . getTableOf ( idx );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <param name="idxList"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Save ( DataTable table ,List<string> idxList ,string logins )
        {
            return _dao . Save ( table ,idxList ,logins );
        }

    }
}
