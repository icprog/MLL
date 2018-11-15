using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class WaiXianBll
    {
        Dao.WaiXianDao _dao = new Dao.WaiXianDao( );
        /// <summary>
        /// 获取流水信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableNum ( )
        {
            return _dao.GetDataTableNum( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool GetDataTableGener ( string num ,string oddNum,string oddNumOf349)
        {
            return _dao.GetDataTableGener( num ,oddNum ,oddNumOf349);
        }
        
        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableAll ( string strWhere )
        {
            return _dao.GetDataTableAll( strWhere );
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
        /// 编辑一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="number"></param>
        /// <param name="every"></param>
        /// <returns></returns>
        public bool Update ( string num ,long number ,decimal every ,string oddNum)
        {
            return _dao.Update( num ,number ,every ,oddNum);
        }
        public bool Update ( string num,string oddNum ,long number ,decimal every )
        {
            return _dao.Update( num ,oddNum ,number ,every );
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
        /// 获取供应商
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfSupplier ( )
        {
            return _dao.GetDataTableOfSupplier( );
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
        public int GetCounts ( string strWhere )
        {
            return _dao.GetCounts( strWhere );
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

        public DataTable GetDataTableByChangeOther ( string strWhere ,int startIndex ,int endIndex )
        {
            return _dao.GetDataTableByChangeOther( strWhere ,startIndex ,endIndex );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public MulaolaoLibrary.WaiXianLibrary GetModel ( string oddNum )
        {
            return _dao.GetModel( oddNum );
        }
        public MulaolaoLibrary.WaiXianLibrary GetModel ( int idx )
        {
            return _dao.GetModel( idx );
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
        public DataTable GetDataTableWeiHu ( string oddNum )
        {
            return _dao.GetDataTableWeiHu( oddNum );
        }

        /// <summary>
        /// 更新维护记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="mainTainStation"></param>
        /// <param name="mainTainRecord"></param>
        /// <returns></returns>
        public bool UpdateMainTain ( string oddNum ,string mainTainStation ,string mainTainRecord )
        {
            return _dao.UpdateMainTain( oddNum ,mainTainStation ,mainTainRecord );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableCount ( string oddNum )
        {
            return _dao.GetDataTableCount( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableSum ( string oddNum )
        {
            return _dao.GetDataTableSum( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableSums ( string oddNum )
        {
            return _dao.GetDataTableSums( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOf241 ( string oddNum )
        {
            return _dao.GetDataTableOf241( oddNum );
        }

        /// <summary>
        /// 写数据到241
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateOfReceivable ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum )
        {
            return _dao.UpdateOfReceivable( modelAm ,oddNum );
        }
    }
}
