using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class ZuZhangGongZiKaoHeBll
    {
        Dao.ZuZhangGongZiKaoHeDao dao = new Dao.ZuZhangGongZiKaoHeDao( );


        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.ZuZhangGongZiKaoHeZaLibrary model )
        {
            return dao.Exists( model );
        }

        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool ExistsIdx ( int idx ,DataTable table ,MulaolaoLibrary.ZuZhangGongZiKaoHeZbLibrary model ,string oddNum ,string yearMoth ,string nameOfLeader )
        {
            return dao.ExistsIdx( idx ,table ,model ,oddNum ,yearMoth ,nameOfLeader );
        }
        public bool UpdateTable ( DataTable table )
        {
            return dao.UpdateTable( table );
        }
        public bool UpdateTableOfDelete ( MulaolaoLibrary.ZuZhangGongZiKaoHeZbLibrary modelZb )
        {
            return dao.UpdateTableOfDelete( modelZb );
        }
        public bool UpdateTable ( DataTable table,MulaolaoLibrary.ZuZhangGongZiKaoHeZbLibrary modelZb )
        {
            return dao.UpdateTable( table ,modelZb );
        }


        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsIdxZb ( MulaolaoLibrary.ZuZhangGongZiKaoHeZbLibrary model )
        {
            return dao.ExistsIdxZb( model );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add ( MulaolaoLibrary.ZuZhangGongZiKaoHeZaLibrary model )
        {
            return dao.Add( model );
        }

        /// <summary>
        /// 复制数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public bool Copy ( MulaolaoLibrary . ZuZhangGongZiKaoHeZaLibrary model ,string dateTime )
        {
            return dao . Copy ( model ,dateTime );
        }

        /// <summary>
        /// 增加一条记录  表2
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddZb ( MulaolaoLibrary.ZuZhangGongZiKaoHeZbLibrary model )
        {
            return dao.AddZb( model );
        }


        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.ZuZhangGongZiKaoHeZaLibrary model )
        {
            return dao.Update( model );
        }

        /// <summary>
        /// 维护
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWei ( MulaolaoLibrary.ZuZhangGongZiKaoHeZaLibrary model )
        {
            return dao.UpdateWei( model );
        }

        /// <summary>
        /// 更新一条记录  表二
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateZb ( MulaolaoLibrary.ZuZhangGongZiKaoHeZbLibrary model )
        {
            return dao.UpdateZb( model );
        }


        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeleteIdxZa ( int idx )
        {
            return dao.DeleteIdxZa( idx );
        }



        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx ,string oddNum ,string yearMonth ,string day )
        {
            return dao.Delete( idx ,oddNum ,yearMonth ,day );
        }

        /// <summary>
        /// 删除多条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteOddNum ( string oddNum )
        {
            return dao.DeleteOddNum( oddNum );
        }


        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeleteZb ( int idx )
        {
            return dao.DeleteZb( idx );
        }

        /// <summary>
        /// 删除多条记录  表二
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteOddNumZb ( string oddNum )
        {
            return dao.DeleteOddNumZb( oddNum );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ZuZhangGongZiKaoHeZaLibrary GetModel ( int idx )
        {
            return dao.GetModel( idx );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ZuZhangGongZiKaoHeZaLibrary GetDataRow ( System.Data.DataRow row )
        {
            return dao.GetDataRow( row );
        }

        /// <summary>
        /// 获取数据库列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTable ( string strWhere )
        {
            return dao.GetDataTable( strWhere );
        }

        /// <summary>
        /// 是否已经执行
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool ExistsReview ( string oddNum ,string formText )
        {
            return dao.ExistsReview( oddNum ,formText );
        }

        /// <summary>
        /// 得到一个实体数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableAll ( string oddNum )
        {
            return dao.GetDataTableAll( oddNum );
        }


        /// <summary>
        /// 获取实体数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableTwo ( string strWhere )
        {
            return dao.GetDataTableTwo( strWhere );
        }

        /// <summary>
        /// 获取产品名称等信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableName ( )
        {
            return dao.GetDataTableName( );
        }

        /// <summary>
        /// 获取组长姓名
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableHeadMan ( )
        {
            return dao.GetDataTableHeadMan( );
        }

        /// <summary>
        /// 执行数据库事务  删除表内容
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteTran ( string oddNum )
        {
            return dao.DeleteTran( oddNum );
        }



        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableSign ( )
        {
            return dao.GetDataTableSign( );
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

        /// <summary>
        /// 分页获取数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            return dao.GetDataTableByChange( strWhere ,startIndex ,endIndex );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableOne ( string oddNum )
        {
            return dao.GetDataTableOne( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableTwo ( MulaolaoLibrary.ZuZhangGongZiKaoHeZbLibrary model )
        {
            return dao.GetDataTableTwo( model );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="dateYm"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableDate ( string dateYm ,string name)
        {
            return dao.GetDataTableDate( dateYm ,name );
        }
        public DataTable GetDataTableDateOf ( string yearMonth ,string name )
        {
            return dao.GetDataTableDateOf( yearMonth ,name );
        }
        public System.Data.DataTable GetDataTableDates ( string dateYm ,string name )
        {
            return dao.GetDataTableDates( dateYm ,name );
        }
        public System.Data.DataTable GetDataTableDats ( string name )
        {
            return dao.GetDataTableDats( name );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableAll ( )
        {
            return dao.GetDataTableAll( );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="tableNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfParameter ( string tableNum )
        {
            return dao.GetDataTableOfParameter( tableNum );
        }
        public bool AddOfParameter ( DataTable table ,string sign )
        {
            return dao . AddOfParameter ( table ,sign );
        }
    }
}
