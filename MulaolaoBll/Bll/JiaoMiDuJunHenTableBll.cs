using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace MulaolaoBll.Bll
{
    public class JiaoMiDuJunHenTableBll
    {
        Dao.JiaoMiDuJunHenTableDao dao = new Dao.JiaoMiDuJunHenTableDao( );
        /// <summary>
        /// 获取流水号
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableNum ( )
        {
            return dao.GetDataTableNum( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableGenerate ( string strWhere )
        {
            return dao.GetDataTableGenerate( strWhere );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.JiaoMiDuJunHengTableLibrary model )
        {
            return dao.Update( model );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx )
        {
            return dao.Delete( idx );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableTable ( string strWhere )
        {
            return dao.GetDataTableTable( strWhere );
        }

        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsYesOrNo ( MulaolaoLibrary.JiaoMiDuJunHengTableLibrary model )
        {
            return dao.ExistsYesOrNo( model );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateGener ( MulaolaoLibrary.JiaoMiDuJunHengTableLibrary model )
        {
            return dao.UpdateGener( model );
        }

        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertGener ( MulaolaoLibrary.JiaoMiDuJunHengTableLibrary model )
        {
            return dao.InsertGener( model );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteAll ( string oddNum )
        {
            return dao.DeleteAll( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable GetDataTableExists ( string oddNum )
        {
            return dao.GetDataTableExists( oddNum );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateMain ( MulaolaoLibrary.JiaoMiDuJunHengTableLibrary model )
        {
            return dao.UpdateMain( model );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.JiaoMiDuJunHengTableLibrary GetModel ( int idx )
        {
            return dao.GetModel( idx );
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
        /// 获取记录总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount ( string strWhere )
        {
            return dao.GetCount( strWhere );
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
            return dao.GetDataTableByChange( strWhere ,startIndex ,endIndex );
        }
    }
}
