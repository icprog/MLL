using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class GongXuGongZiBll
    {
        Dao.GongXuGongZiDao dao = new Dao.GongXuGongZiDao( );


        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.GongXuGongZiLibrary model )
        {
            return dao.Exists( model );
        }

        /// <summary>
        /// 是否存在流水号
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool Exists ( string num ,string oddNum )
        {
            return dao . Exists ( num ,oddNum );
        }

        /// <summary>
        /// 同填表人，同流水只能有一张表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsUserAndNum ( MulaolaoLibrary . GongXuGongZiLibrary model )
        {
            return dao . ExistsUserAndNum ( model );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary.GongXuGongZiLibrary model ,string tableNum,string tableName,string logins,DateTime dtOne,string stateOf,string stateOfOdd )
        {
            return dao.Add( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }



        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.GongXuGongZiLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.Update( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }


        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWei ( MulaolaoLibrary.GongXuGongZiLibrary model)
        {
            return dao.UpdateWei( model  );
        }


        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateOther ( MulaolaoLibrary.GongXuGongZiLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.UpdateOther( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( int idx ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd ,string oddNum )
        {
            return dao.Delete( idx ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd ,oddNum );
        }


        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteOddNum ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.DeleteOddNum( oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }



        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTable ( string strWhere )
        {
            return dao.GetDataTable( strWhere  );
        }
        public System.Data.DataTable GetDataTable ( string strWhere,string numCount )
        {
            return dao.GetDataTable( strWhere ,numCount );
        }


        /// <summary>
        /// 获取数据列表 定日工资额
        /// </summary>
        /// <param name="workPrice"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePrice ( string workPrice )
        {
            return dao.GetDataTablePrice( workPrice );
        }


        /// <summary>
        /// 是否送审
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool ExistsReview ( string oddNum ,string formText )
        {
            return dao.ExistsReview( oddNum ,formText  );
        }


        /// <summary>
        /// 得到数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableAll ( string oddNum )
        {
            return dao.GetDataTableAll( oddNum );
        }

        /// <summary>
        /// 得到实体对象 查询
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
        public int GetGongXuCount ( string strWhere )
        {
            return dao.GetGongXuCount( strWhere );
        }

        /// <summary>
        /// 获取分页数据
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
        /// 获取一个实例对象
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.GongXuGongZiLibrary GetModel ( int idx )
        {
            return dao.GetModel( idx );
        }


        /// <summary>
        /// 获取一个实例对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.GongXuGongZiLibrary GetDataRow ( System.Data.DataRow row )
        {
            return dao.GetDataRow( row );
        }


        /// <summary>
        /// 获取工序名称
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableWork ( string num )
        {
            return dao.GetDataTableWork( num );
        }


        /// <summary>
        /// 获取零件等信息
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableProcuce ( string num )
        {
            return dao.GetDataTableProcuce( num );
        }

        /// <summary>
        /// 获取工序名称
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableGongXu (string num )
        {
            return dao.GetDataTableGongXu( num );
        }


        /// <summary>
        /// 获取生产车间
        /// </summary>
        /// <param name="nameNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableCheJian ( )
        {
            return dao.GetDataTableCheJian( );
        }

        /// <summary>
        /// 获取流水号等信息
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableNum ( )
        {
            return dao.GetDataTableNum( );
        }

        /// <summary>
        /// 获取工段信息
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableWorkShop ( string num )
        {
            return dao.GetDataTableWorkShop( num );
        }

        /// <summary>
        /// 获取定日产量
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableDing ( string other ,string num,string GongXu)
        {
            return dao.GetDataTableDing( other ,num ,GongXu );
        }

        /// <summary>
        /// 是否存在一条记录
        /// </summary>
        /// <param name="year">年</param>
        /// <param name="mouth">月</param>
        /// <param name="day">日</param>
        /// <param name="num">流水</param>
        /// <param name="partName">零件名称</param>
        /// <param name="workPrice">工序</param>
        /// <returns></returns>
        public bool ExistsWrite ( string year ,int mouth ,int day ,string num ,string partName ,string workPrice )
        {
            return dao.ExistsWrite( year ,mouth ,day ,num ,partName ,workPrice );
        }

        /// <summary>
        /// 更改一条记录
        /// </summary>
        /// <param name="year"></param>
        /// <param name="mouth"></param>
        /// <param name="day"></param>
        /// <param name="num"></param>
        /// <param name="partName"></param>
        /// <param name="workPrice"></param>
        /// <returns></returns>
        public bool UpdateWrite ( string year ,int mouth ,int day ,string num ,string partName ,string workPrice,decimal price)
        {
            return dao.UpdateWrite( year ,mouth ,day ,num ,partName ,workPrice ,price );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableGen ( string num )
        {
            return dao.GetDataTableGen( num );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableLocal ( string num )
        {
            return dao.GetDataTableLocal( num );
        }

        /// <summary>
        /// 插入一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool InsertGen ( MulaolaoLibrary.GongXuGongZiLibrary model )
        {
            return dao.InsertGen( model );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTableWorkShops ( string num )
        {
            return dao.GetDataTableWorkShops( num );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableBom ( )
        {
            return dao.GetDataTableBom( );
        }


        /// <summary>
        /// 复制一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Copy ( string oddNum ,string tableNum,string tableName,string logins,DateTime dtOne,string stateOf,string stateOfOdd )
        {
            return dao.Copy( oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 编译一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool CopyUpdate ( string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd )
        {
            return dao.CopyUpdate( oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 删除复制数据
        /// </summary>
        /// <returns></returns>
        public bool DeleteCopy ( )
        {
            return dao.DeleteCopy( );
        }

        /// <summary>
        /// 编辑零件数量
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool UpdateLJ ( string num ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd ,string oddNum )
        {
            return dao.UpdateLJ( num ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfOdd ,oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="groupLeader"></param>
        /// <param name="staff"></param>
        /// <returns></returns>
        public DataTable GetDataTableLimit ( string groupLeader ,string staff )
        {
            return dao.GetDataTableLimit( groupLeader ,staff );
        }

        /// <summary>
        /// 获取预生产产品信息
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSeriableNum ( )
        {
            return dao.GetDataTableSeriableNum( );
        }

        /// <summary>
        /// 批量编辑部件名称
        /// </summary>
        /// <param name="num"></param>
        /// <param name="oddNum"></param>
        /// <param name="tableName"></param>
        /// <param name="tableNum"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <param name="part"></param>
        /// <param name="prePart"></param>
        /// <returns></returns>
        public bool Batch ( string num ,string oddNum ,string tableName ,string tableNum ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd ,string part ,string prePart )
        {
            return dao . Batch ( num ,oddNum ,tableName ,tableNum ,logins ,dtOne ,stateOf ,stateOfOdd ,part ,prePart );
        }

        /// <summary>
        /// 批量编辑工序名称  同流水，同工序
        /// </summary>
        /// <param name="num"></param>
        /// <param name="oddNum"></param>
        /// <param name="tableName"></param>
        /// <param name="tableNum"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <param name="work"></param>
        /// <param name="part"></param>
        /// <returns></returns>
        public bool BatchGX ( string num ,string oddNum ,string tableName ,string tableNum ,string logins ,DateTime dtOne ,string stateOf ,string stateOfOdd ,string work ,string part )
        {
            return dao . BatchGX ( num ,oddNum ,tableName ,tableNum ,logins ,dtOne ,stateOf ,stateOfOdd ,work ,part );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintOne ( string oddNum )
        {
            return dao . getPrintOne ( oddNum );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public DataTable getPrintTwo ( string oddNum )
        {
            return dao . getPrintTwo ( oddNum );
        }

    }
}
