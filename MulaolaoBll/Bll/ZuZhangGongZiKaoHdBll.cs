using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class ZuZhangGongZiKaoHdBll
    {
        Dao.ZuZhangGongZiKaoHdDao dao = new Dao.ZuZhangGongZiKaoHdDao( );

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsAzAdd ( MulaolaoLibrary.ZuZhangGongZiKaoHeHdAzLibrary model )
        {
            return dao.ExistsAzAdd( model );
        }


        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool ExistsIdxBz ( int idx )
        {
            return dao.ExistsIdxBz( idx );
        }


        /// <summary>
        /// 获取数据列表   组长姓名
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableName ( )
        {
            return dao.GetDataTableName( );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add ( MulaolaoLibrary.ZuZhangGongZiKaoHeHdAzLibrary model )
        {
            return dao.Add( model );
        }

        /// <summary>
        /// 复制数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public bool Copy ( MulaolaoLibrary . ZuZhangGongZiKaoHeHdAzLibrary model ,string dateTime )
        {
            return dao . Copy ( model ,dateTime );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.ZuZhangGongZiKaoHeHdAzLibrary model )
        {
            return dao.Update( model );
        }

        /// <summary>
        /// 更新维护记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWeiHu ( MulaolaoLibrary.ZuZhangGongZiKaoHeHdAzLibrary model )
        {
            return dao.UpdateWeiHu( model );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddBz ( MulaolaoLibrary.ZuZhangGongZiKaoHeBzLibrary model )
        {
            return dao.AddBz( model );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateBz ( MulaolaoLibrary.ZuZhangGongZiKaoHeBzLibrary model )
        {
            return dao.UpdateBz( model );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary.ZuZhangGongZiKaoHeHdAzLibrary model )
        {
            return dao.Delete( model );
        }


        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteBz ( MulaolaoLibrary.ZuZhangGongZiKaoHeBzLibrary model )
        {
            return dao.DeleteBz( model );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteTran ( string oddNum )
        {
            return dao.DeleteTran( oddNum );
        }



        /// <summary>
        /// 得到数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableAz ( string strWhere )
        {
            return dao.GetDataTableAz( strWhere );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ZuZhangGongZiKaoHeHdAzLibrary GetModel ( int idx )
        {
            return dao.GetModel( idx );
        }

        /// <summary>
        /// 获取数据实例
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ZuZhangGongZiKaoHeHdAzLibrary GetDataRow ( System.Data.DataRow row )
        {
            return dao.GetDataRow( row );
        }

        /// <summary>
        /// 获取产品名称等信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableNameNum ( )
        {
            return dao.GetDataTableNameNum( );
        }

        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool ExistsReview ( string oddNum ,string formText )
        {
            return dao.ExistsReview( oddNum ,formText );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableBz ( string strWhere )
        {
            return dao.GetDataTableBz( strWhere );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableTwo ( MulaolaoLibrary.ZuZhangGongZiKaoHeBzLibrary model )
        {
            return dao.GetDataTableTwo( model );
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
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeleteBz ( int idx )
        {
            return dao.DeleteBz( idx );
        }

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
        public int GetZuZhangCount ( string strWhere )
        {
            return dao.GetZuZhangCount( strWhere );
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
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableAll ( string oddNum )
        {
            return dao.GetDataTableAll( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="dateYm"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableDate ( string dateYm ,string name)
        {
            return dao.GetDataTableDate( dateYm ,name);
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
        /// 批量更新数据到表
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool UpdateTable ( DataTable table )
        {
            return dao.UpdateTable( table );
        }
        public bool UpdateTableDelete ( MulaolaoLibrary.ZuZhangGongZiKaoHeBzLibrary modelBz )
        {
            return dao.UpdateTableDelete( modelBz );
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
    }
}
