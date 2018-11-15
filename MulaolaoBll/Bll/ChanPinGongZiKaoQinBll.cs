using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class ChanPinGongZiKaoQinBll
    {
        Dao.ChanPinGongZiKaoQinDao dao = new Dao.ChanPinGongZiKaoQinDao( );

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model )
        {
            return dao.Exists( model );
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsIdx ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model )
        {
            return dao.ExistsIdx( model );
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable ExistsOddNum ( string oddNum )
        {
            return dao.ExistsOddNum( oddNum );
        }

        /// <summary>
        /// 是否存在总毛量为0
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable ExistsIsZero ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model )
        {
            return dao.ExistsIsZero( model );
        }

        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Add ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfState )
        {
            return dao.Add( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfState );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfState )
        {
            return dao.Update( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfState );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWei ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model )
        {
            return dao.UpdateWei( model );
        }


        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateAll ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model )
        {
            return dao.UpdateAll( model );
        }

        /// <summary>
        /// 批量编辑月份数据
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool UpdateBatch ( int mouth )
        {
            return dao.UpdateBatch( mouth );
        }
        public bool UpdateBatch ( int startMonth ,string oddNum ,int mouth )
        {
            return dao.UpdateBatch( startMonth ,oddNum ,mouth );
        }
        public bool ExistsNum ( string num )
        {
            return dao.ExistsNum( num );
        }


        /// <summary>
        /// 批量编辑部件名称
        /// </summary>
        /// <param name="num"></param>
        /// <param name="pro"></param>
        /// <returns></returns>
        public bool UpdateBatchPro ( string num ,string oddNum,string pro ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfState ,string buJ,string gX,string dhCheck ,string gxCheck)
        {
            return dao . UpdateBatchPro ( num ,oddNum ,pro ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfState ,buJ ,gX ,dhCheck ,gxCheck );
        }

        /// <summary>
        /// 批量编辑工序实际单价
        /// </summary>
        /// <returns></returns>
        public bool UpdateBatchPrice ( decimal price ,string num ,string parts ,string proce ,string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfState)
        {
            return dao.UpdateBatchPrice( price ,num ,parts ,proce ,oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfState );
        }

        /// <summary>
        /// 批量编辑工序
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        public bool UpdateBarchWork ( string ori ,string now ,string num,string bjName ,string oddNum ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfState )
        {
            return dao.UpdateBarchWork( ori ,now ,num ,bjName ,oddNum ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfState );
        }

        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool Delete ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string stateOf ,string stateOfState )
        {
            return dao.Delete( model ,tableNum ,tableName ,logins ,dtOne ,stateOf ,stateOfState );
        }


        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteOddNum ( string oddNum ,string tableNum,string tableName,string logins,DateTime dton,string stateOf,string stateOfOdd)
        {
            return dao.DeleteOddNum( oddNum ,tableNum ,tableName ,logins ,dton ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ChanPinGongZiKaoQinLibrary GetModel ( int idx )
        {
            return dao.GetModel( idx );
        }


        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ChanPinGongZiKaoQinLibrary GetDataRow ( System.Data.DataRow row )
        {
            return dao.GetDataRow( row );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableOf ( string strWhere,string numOfTj )
        {
            return dao . GetDataTableOf ( strWhere , numOfTj );
        }
        public System.Data.DataTable GetDataTable ( string strWhere , string num )
        {
            return dao . GetDataTable ( strWhere , num );
        }
        public System . Data . DataTable GetDataTable ( )
        {
            return dao . GetDataTable ( );
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
        /// 获取统计员
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableTj ( )
        {
            return dao.GetDataTableTj( );
        }

        /// <summary>
        /// 获取生产人信息
        /// </summary>
        /// <param name="nameOfTjNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableWorkPerSon ( string nameOfTjNum )
        {
            return dao.GetDataTableWorkPerSon( nameOfTjNum );
        }

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public DataTable GetDataTableLeadesr ( string number )
        {
            return dao.GetDataTableLeadesr( number );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableWork ( string num )
        {
            return dao.GetDataTableWork( num );
        }
        public DataTable GetDataTableWorkProcedure ( string num )
        {
            return dao.GetDataTableWorkProcedure( num );
        }

        /// <summary>
        /// 获取工序名称
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableWorkPro ( )
        {
            return dao.GetDataTableWorkPro( );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableBom ( )
        {
            return dao.GetDataTableBom( );
        }
        public DataTable GetDataTableBom ( string num ,string partName )
        {
            return dao . GetDataTableBom ( num ,partName );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableProcess ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model )
        {
            return dao.GetDataTableProcess( model );
        }





        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableAll ( string num )
        {
            return dao.GetDataTableAll( num );
        }



        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableOne ( )
        {
            return dao.GetDataTableOne( );
        }



        /// <summary>
        /// 获取总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetChanPinCount ( string strWhere )
        {
            return dao.GetChanPinCount( strWhere );
        }

        /// <summary>
        /// 是否送审
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool ExistsReview ( string oddNum  )
        {
            return dao.ExistsReview( oddNum );
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="startIndex"></param>
        /// <param name="endIndex"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableByChange ( string strWhere ,int startIndex ,int endIndex )
        {
            return dao.GetDataTableByChange( strWhere ,startIndex ,endIndex );
        }

        public bool Update ( )
        {
            return dao.Update( );
        }

        /// <summary>
        /// 获取写入046数据
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableWrite ( string num )
        {
            return dao.GetDataTableWrite( num );
        }


        /// <summary>
        /// 更新记录
        /// </summary>
        /// <param name="nu"></param>
        /// <returns></returns>
        public bool UpdateSum ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model ,int GZ )
        {
            return dao.UpdateSum( model ,GZ );
        }

        /// <summary>
        /// 获取数据列表  组长
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableLeaderY ( )
        {
            return dao.GetDataTableLeaderY( );
        }

        public DataTable GetDataTableLeader ( string name )
        {
            return dao . GetDataTableLeader ( name );
        }

        /// <summary>
        /// 获取数据列表组长
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableLeader ( )
        {
            return dao . GetDataTableLeader ( );
        }

        /// <summary>
        /// 获取统计员
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSta ( )
        {
            return dao.GetDataTableSta( );
        }

        /// <summary>
        /// 获取数据列表  定日工资额
        /// </summary>
        /// <param name="workProcedure"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePrice ( string workProcedure )
        {
            return dao.GetDataTablePrice( workProcedure );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePlanPrice ( string num )
        {
            return dao.GetDataTablePlanPrice( num );
        }

        /// <summary>
        /// 编辑一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdatePlanPrice ( MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model )
        {
            return dao.UpdatePlanPrice( model );
        }

        /// <summary>
        /// 删除送审记录
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteReview ( string tableName ,string oddNum )
        {
            return dao.DeleteReview( tableName ,oddNum );
        }

        /// <summary>
        /// 是否存在统计员
        /// </summary>
        /// <param name="nameOfTj"></param>
        /// <returns></returns>
        public bool ExistsTJ ( string nameOfTj )
        {
            return dao.ExistsTJ( nameOfTj );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="nameOfWork"></param>
        /// <param name="nameOfLeader"></param>
        /// <returns></returns>
        public DataTable GetDataTableOddOne ( string nameOfWork ,string nameOfLeader,string nameOfT )
        {
            return dao.GetDataTableOddOne( nameOfWork ,nameOfLeader,nameOfT );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableNum ( )
        {
            return dao.GetDataTableNum( );
        }

        /// <summary>
        /// 批量编辑结算月份
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool BatchEdit ( List<string> stList,DateTime dtOne ,string signOf ,DateTime dt ,string oddNum,string tableNum,string tableName,string logins,DateTime dtTwo,string stateOf,string stateOfOdd ,string other)
        {
            return dao.BatchEdit( stList ,dtOne ,signOf ,dt ,oddNum ,tableNum ,tableName ,logins ,dtTwo ,stateOf ,stateOfOdd ,other );
        }

        /// <summary>
        /// 更改GZ25=1
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool isZeroId ( string strWhere )
        {
            return dao.isZeroId( strWhere );
        }
      public  bool calCuIsZero (  )
        {
            return dao.calCuIsZero(  );
        }

        /// <summary>
        /// 获取流水号
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfNum ( )
        {
            return dao.GetDataTableOfNum( );
        }

        public DataTable GetDataTableOfNumS ( )
        {
            return dao.GetDataTableOfNumS( );
        }

        /// <summary>
        /// 批量编辑
        /// </summary>
        /// <param name="numOne"></param>
        /// <param name="numTwo"></param>
        /// <param name="tableNum"></param>
        /// <param name="tableName"></param>
        /// <param name="logins"></param>
        /// <param name="dtOne"></param>
        /// <param name="oddNum"></param>
        /// <param name="stateOf"></param>
        /// <param name="stateOfOdd"></param>
        /// <returns></returns>
        public bool UpdateOfNum ( string numOne ,string numTwo ,string tableNum ,string tableName ,string logins ,DateTime dtOne ,string oddNum ,string stateOf ,string stateOfOdd )
        {
            return dao.UpdateOfNum( numOne ,numTwo ,tableNum ,tableName ,logins ,dtOne ,oddNum ,stateOf ,stateOfOdd );
        }

        /// <summary>
        /// 批量编辑人员隶属关系
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public bool changeUserForLeader ( string userName  ,List<string> strList ,string logins)
        {
            return dao . changeUserForLeader ( userName ,strList ,logins );
        }


        /// <summary>
        /// 获取317未执行的组长和统计员
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOfPQW ( )
        {
            return dao . getTableOfPQW ( );
        }

        /// <summary>
        /// 获取317未执行的车间主任
        /// </summary>
        /// <returns></returns>
        public DataTable getTableOfPQWC ( )
        {
            return dao . getTableOfPQWC ( );
        }

        /// <summary>
        /// 317组长批量变更
        /// </summary>
        /// <param name="orOneNum">变更后组长编号/param>
        /// <param name="orOneName">变更后组长姓名</param>
        /// <param name="orTwoNum">变更前组长编号</param>
        /// <param name="orTwoName">变更前组长姓名</param>
        /// <returns></returns>
        public bool EditOrder ( string orOneNum ,string orOneName ,string orTwoNum ,string orTwoName )
        {
            return dao . EditOrder ( orOneNum ,orOneName ,orTwoNum ,orTwoName );
        }

        /// <summary>
        /// 317统计员批量变更
        /// </summary>
        /// <returns></returns>
        public bool EditOrder ( string orOneNum ,string orOneName ,string tOneNum ,string tOneName ,string tTwoNum ,string tTwoName )
        {
            return dao . EditOrder ( orOneNum ,orOneName ,tOneNum ,tOneName ,tTwoNum ,tTwoName );
        }

        /// <summary>
        /// 317车间主任批量变更
        /// </summary>
        /// <returns></returns>
        public bool EditOrderC ( string orOneNum ,string orOneName ,string cOneNum ,string cOneName ,string cTwoNum ,string cTwoName )
        {
            return dao . EditOrderC ( orOneNum ,orOneName ,cOneNum ,cOneName ,cTwoNum ,cTwoName );
        }

        /// <summary>
        /// 获取人员信息
        /// </summary>
        /// <returns></returns>
        public DataTable getUserFor317 ( )
        {
            return dao . getUserFor317 ( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable getTableView ( string strWhere )
        {
            return dao . getTableView ( strWhere );
        }

        /// <summary>
        /// 批量编辑计时日工资
        /// </summary>
        /// <param name="table"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <returns></returns>
        public bool UpdateSales ( DataTable table ,int year ,int month )
        {
            return dao . UpdateSales ( table ,year ,month );
        }


        }
}
