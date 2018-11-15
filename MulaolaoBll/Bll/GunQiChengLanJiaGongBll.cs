using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class GunQiChengLanJiaGongBll
    {
        Dao.GunQiChengLanJiaGongDao dao = new Dao.GunQiChengLanJiaGongDao( );
        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.GunQiChengLanJiaGongLibrary model )
        {
            return dao.Exists( model );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert ( MulaolaoLibrary.GunQiChengLanJiaGongLibrary model )
        {
            return dao.Insert( model );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.GunQiChengLanJiaGongLibrary model )
        {
            return dao.Update( model );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary.GunQiChengLanJiaGongLibrary model )
        {
            return dao.Delete( model );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.GunQiChengLanJiaGongLibrary GetModel ( int idx )
        {
            return dao.GetModel( idx );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.GunQiChengLanJiaGongLibrary GetModel ( string oddNum )
        {
            return dao.GetModel( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere )
        {
            return dao.GetDataTable( strWhere );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableNums ( )
        {
            return dao.GetDataTableNums( );
        }

        /// <summary>
        /// 获取记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount ( string strWhere )
        {
            return dao.GetCount( strWhere );
        }
        public int GetCounts ( string strWhere )
        {
            return dao.GetCounts( strWhere );
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        {
            return dao.GetDataTableByPage( strWhere ,startIndex ,endIndex );
        }
        public DataTable GetDataTableByPages ( string strWhere ,int startIndex ,int endIndex )
        {
            return dao.GetDataTableByPages( strWhere ,startIndex ,endIndex );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            return dao.GetDataTableOnly( );
        }

        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteAll ( string oddNum )
        {
            return dao.DeleteAll( oddNum );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateAll ( MulaolaoLibrary.GunQiChengLanJiaGongLibrary model )
        {
            return dao.UpdateAll( model );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableWeiHu ( string oddNum )
        {
            return dao.GetDataTableWeiHu( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableWu ( string oddNum ,string num )
        {
            return dao.GetDataTableWu( oddNum ,num );
        }

        /// <summary>
        /// 复制
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Copy ( string oddNum )
        {
            return dao.Copy( oddNum );
        }

        /// <summary>
        /// 更改一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateCopy ( string oddNum )
        {
            return dao.UpdateCopy( oddNum );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <returns></returns>
        public bool DeleteCopy ( )
        {
            return dao.DeleteCopy( );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableOther ( string num )
        {
            return dao.GetDataTableOther( num );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableReadOf ( string num )
        {
            return dao.GetDataTableReadOf( num );
        }

        /// <summary>
        /// 获取打印数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrintOne ( string oddNum )
        {
            return dao.GetDataTablePrintOne( oddNum );
        }
        public DataTable GetDataTablePrintTwo ( string oddNum )
        {
            return dao.GetDataTablePrintTwo( oddNum );
        }
    }
}
