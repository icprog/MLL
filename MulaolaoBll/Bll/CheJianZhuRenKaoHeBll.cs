using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class CheJianZhuRenKaoHeBll
    {
        Dao.CheJianZhuRenKaoHeDao dao = new Dao.CheJianZhuRenKaoHeDao( );
        /// <summary>
        /// 获取车间主任姓名
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableDirecTor ( )
        {
            return dao.GetDataTableDirecTor( );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add ( MulaolaoLibrary.CheJianZhuRenKaoHeCzLibrary model )
        {
            return dao.Add( model );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.CheJianZhuRenKaoHeCzLibrary model )
        {
            return dao.Update( model );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary.CheJianZhuRenKaoHeCzLibrary model )
        {
            return dao.Delete( model );
        }

        /// <summary>
        /// 获取数据列表  表一
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableOne ( string strWhere )
        {
            return dao.GetDataTableOne( strWhere );
        }


        /// <summary>
        /// 获取数据列表  表二
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableTwo ( string strWhere )
        {
            return dao.GetDataTableTwo( strWhere );
        }


        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.CheJianZhuRenKaoHeCzLibrary GetModelCz ( int idx )
        {
            return dao.GetModelCz( idx );
        }

        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.CheJianZhuRenKaoHeCzLibrary GetDataRowCz ( System.Data.DataRow row )
        {
            return dao.GetDataRowCz( row );
        }

        /// <summary>
        /// 是否执行
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public bool ExistsReview ( string oddNum ,string tableName )
        {
            return dao.ExistsReview( oddNum ,tableName );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteOddNum ( string oddNum )
        {
            return dao.DeleteOddNum( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTabbleExists ( string oddNum )
        {
            return dao.GetDataTabbleExists( oddNum );
        }

        /// <summary>
        /// 更改维护意见
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWeiHu ( MulaolaoLibrary.CheJianZhuRenKaoHeCzLibrary model )
        {
            return dao.UpdateWeiHu( model );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool DeleteDz ( int idx )
        {
            return dao.DeleteDz( idx );
        }


        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool ExistsIdx ( int idx )
        {
            return dao.ExistsIdx( idx );
        }


        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int AddTwo ( MulaolaoLibrary.CheJianZhuRenKaoHeDzLibrary model )
        {
            return dao.AddTwo( model );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateTwo ( MulaolaoLibrary.CheJianZhuRenKaoHeDzLibrary model )
        {
            return dao.UpdateTwo( model );
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
        public int GetCount ( string strWhere )
        {
            return dao.GetCount( strWhere );
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableByPage ( string strWhere ,int startIndex ,int endIndex )
        {
            return dao.GetDataTableByPage( strWhere ,startIndex ,endIndex );
        }

        /// <summary>
        /// 获取计算结果
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableCacle ( MulaolaoLibrary.CheJianZhuRenKaoHeDzLibrary model )
        {
            return dao.GetDataTableCacle( model );
        }

        /// <summary>
        /// 批量编辑
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool UpdateTable ( DataTable table )
        {
            return dao.UpdateTable( table );
        }

        /// <summary>
        /// 得到数据列表
        /// </summary>
        /// <param name="nameNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableNum ( string nameNum ,string dateD)
        {
            return dao.GetDataTableNum( nameNum ,dateD );
        }
    }
}
