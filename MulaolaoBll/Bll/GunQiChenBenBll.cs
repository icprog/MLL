using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class GunQiChenBenBll
    {
        Dao.GunQiChenBenDao _dao = new Dao.GunQiChenBenDao( );

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.GunQiChenBenLibrary _model ,string logins)
        {
            return _dao . Update ( _model ,logins );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Delete ( int idx ,string logins,string oddNum)
        {
            return _dao . Delete ( idx ,logins ,oddNum );
        }

        public bool Delete ( )
        {
            return _dao.Delete( );
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

        /// <summary>
        /// 获取单个字段数据列表
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
        /// 分页获取数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        {
            return _dao.GetDataTableByPage( strWhere ,startIndex ,endIndex );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.GunQiChenBenLibrary GetModel ( int idx )
        {
            return _dao.GetModel( idx );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum ,string oddNumOf,string logins)
        {
            return _dao . Delete ( oddNum ,oddNumOf ,logins );
        }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public bool EditHide ( string attribute )
        {
            return _dao.EditHide( attribute );
        }

        /// <summary>
        /// 获取数据  写入241
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableOf ( string oddNum )
        {
            return _dao.GetDataTableOf( oddNum );
        }

        /// <summary>
        /// 写数据到241
        /// </summary>
        /// <param name="modelAm"></param>
        /// <returns></returns>
        public bool UpdateOfReceviable ( MulaolaoLibrary.ProductCostSummaryLibrary modelAm ,string oddNum )
        {
            return _dao.UpdateOfReceviable( modelAm ,oddNum );
        }

        /// <summary>
        /// 获取色号等
        /// </summary>
        /// <param name="AC18"></param>
        /// <returns></returns>
        public DataTable GetDataTableAC ( string AC18 )
        {
            return _dao . GetDataTableAC ( AC18 );
        }

    }
}
