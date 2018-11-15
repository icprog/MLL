using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
   public class ChanPinGaiShanBll
    {
        Dao.ChanPinGaiShanDao dao = new Dao.ChanPinGaiShanDao( );

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTable ( string oddNum )
        {
            return dao.GetDataTable( oddNum );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableOn (  )
        {
            return dao.GetDataTableOn(  );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfNum ( string number )
        {
            return dao.GetDataTableOfNum( number );
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfNumOf ( string str )
        {
            return dao.GetDataTableOfNumOf( str );
        }

        /// <summary>
        /// 获取材料
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfMaterial ( string str )
        {
            return dao.GetDataTableOfMaterial( str );
        }

        /// <summary>
        /// 获取工段
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfAccess ( string str )
        {
            return dao.GetDataTableOfAccess( str );
        }

        /// <summary>
        /// 获取辅料
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfWorkShop ( string str )
        {
            return dao.GetDataTableOfWorkShop( str );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="gs34"></param>
        /// <returns></returns>
        public DataTable printTableOne ( string gs34 )
        {
            return dao . printTableOne ( gs34 );
        }


        public DataTable printTableTwo ( string gs34 )
        {
            return dao . printTableTwo ( gs34 );
        }

        public DataTable printTableTre ( string gs34 )
        {
            return dao . printTableTre ( gs34 );
        }

        public DataTable printTableFor ( string gs34 )
        {
            return dao . printTableFor ( gs34 );
        }

        /// <summary>
        /// 批量编辑
        /// </summary>
        /// <param name="tableOne"></param>
        /// <param name="tableTwo"></param>
        /// <param name="tableTre"></param>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool Update ( DataTable tableOne ,DataTable tableTwo ,DataTable tableTre ,List<string> idxList )
        {
            return dao.Update( tableOne ,tableTwo ,tableTre ,idxList );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="gs34"></param>
        /// <param name="logins"></param>
        /// <returns></returns>
        public bool Delete ( string gs34 ,string logins )
        {
            return dao . Delete ( gs34 ,logins );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary . ChanPinGaiShanEntity _model )
        {
            return dao . Update ( _model );
        }

        /// <summary>
        /// 增加数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            return dao . Add ( model );
        }

        /// <summary>
        /// 复制保存
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Copy ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            return dao . Copy ( model );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            return dao . Exists ( model );
        }


        /// <summary>
        /// 新建数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool BuildOne ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            return dao . BuildOne ( model );
        }


        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditOne ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            return dao . EditOne ( model );
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteOne ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            return dao . DeleteOne ( model );
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsOne ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            return dao . ExistsOne ( model );
        }

        /// <summary>
        /// 新建数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool BuildTwo ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            return dao . BuildTwo ( model );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditTwo ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            return dao . EditTwo ( model );
        }


        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsTwo ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            return dao . ExistsTwo ( model );
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool BuildTre ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            return dao . BuildTre ( model );
        }

        /// <summary>
        /// 编辑数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditTre ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            return dao . EditTre ( model );
        }

        /// <summary>
        /// 是否存在流水
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsNum ( MulaolaoLibrary . ChanPinGaiShanEntity model )
        {
            return dao . ExistsNum ( model );
        }

        //批量新增
        public DataTable tableOne ( )
        {
            return dao . tableOne ( );
        }

        public DataTable tableTwo ( )
        {
            return dao . tableTwo ( );
        }
        public DataTable tableTre ( )
        {
            return dao . tableTre ( );
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="tableQueryTwo"></param>
        /// <param name="tableQueryTre"></param>
        /// <param name="tableQueryFor"></param>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool BatchAdd ( DataTable tableQueryTwo ,DataTable tableQueryTre ,DataTable tableQueryFor ,List<string> idxList )
        {
            return dao . BatchAdd ( tableQueryTwo ,tableQueryTre ,tableQueryFor ,idxList );
        }

        /// <summary>
        /// 获取总条数
        /// </summary>
        /// <returns></returns>
        public int getCount ( string strWhere )
        {
            return dao . getCount ( strWhere );
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
            return dao . GetDataTableByChange ( strWhere ,startIndex ,endIndex );
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <returns></returns>
        public DataTable getOnly ( )
        {
            return dao . getOnly ( );
        }


        }
}
