using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class PenYouQiChenBll
    {
        Dao.PenYouQiChenDao dao = new Dao.PenYouQiChenDao( );

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableOnly ( )
        {
            return dao.GetDataTableOnly( );
        }

        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount ( string strWhere )
        {
            return dao.GetCount( strWhere );
        }
        public int GetCoun ( string strWhere )
        {
            return dao.GetCoun( strWhere );
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        {
            return dao.GetDataTableByPage( strWhere ,startIndex ,endIndex );
        }
        public System.Data.DataTable GetDataTableByPages ( string strWhere ,int startIndex ,int endIndex )
        {
            return dao.GetDataTableByPages( strWhere ,startIndex ,endIndex );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="oddNum"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool Delete ( string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum ,string stateOf ,string stateOfOdd )
        {
            return dao.Delete( tableNum ,tableName ,logins ,dtOne ,oddNum ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="oddNum"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool Copy ( string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum ,string stateOf ,string stateOfOdd )
        {
            return dao.Copy( tableNum ,tableName ,logins ,dtOne ,oddNum ,stateOf ,stateOfOdd );
        }


        /// <summary>
        /// 更改复制单号
        /// </summary>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="oddNum"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool CopyAll ( string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum ,string stateOf ,string stateOfOdd )
        {
            return dao.CopyAll( tableNum ,tableName ,logins ,dtOne ,oddNum ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfReceivable ( string oddNum )
        {
            return dao.GetDataTableOfReceivable( oddNum );
        }

        /// <summary>
        /// 写数据到241
        /// </summary>
        /// <param name="modelAm"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateOfReceivable ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum )
        {
            return dao.UpdateOfReceivable( modelAm ,oddNum );
        }


        /// <summary>
        /// 获取流水等信息
        /// </summary>
        /// <returns></returns>
        public DataTable getProductInfo ( )
        {
            return dao . getProductInfo ( );
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Insert ( MulaolaoLibrary . FrmpenyouqichenEntity _model ,string logins ,string oddNumOfAll)
        {
            return dao . Insert ( _model ,logins ,oddNumOfAll );
        }

        /// <summary>
        /// 是否存在同流水，开合同人，零件名称，工序
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool ExistsBody ( MulaolaoLibrary . FrmpenyouqichenEntity _model )
        {
            return dao . ExistsBody ( _model );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="logins"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool Edit ( MulaolaoLibrary . FrmpenyouqichenEntity _model ,string logins ,string stateOfOdd )
        {
            return dao . Edit ( _model ,logins ,stateOfOdd );
        }

        /// <summary>
        /// 批量编辑数据
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="logins"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool BatchEdit ( MulaolaoLibrary . FrmpenyouqichenEntity _model ,string logins ,string stateOfOdd )
        {
            return dao . BatchEdit ( _model ,logins ,stateOfOdd );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="_model"></param>
        /// <param name="logins"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary . FrmpenyouqichenEntity _model ,string logins ,string stateOfOdd )
        {
            return dao . Delete ( _model ,logins ,stateOfOdd );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getTableToView ( string oddNum )
        {
            return dao . getTableToView ( oddNum );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary . FrmpenyouqichenEntity getModel ( long idx )
        {
            return dao . getModel ( idx );
        }
        public MulaolaoLibrary . FrmpenyouqichenEntity getModel ( string oddNum )
        {
            return dao . getModel ( oddNum );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logins"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary . FrmpenyouqichenEntity model ,string logins ,string stateOfOdd )
        {
            return dao . Update ( model ,logins ,stateOfOdd );
        }

        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="logins"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary . FrmpenyouqichenEntity model ,string logins ,string stateOfOdd )
        {
            return dao . Add ( model ,logins ,stateOfOdd );
        }

        }
}
