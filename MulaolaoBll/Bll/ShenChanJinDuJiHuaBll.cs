using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class ShenChanJinDuJiHuaBll
    {
        Dao.ShenChanJinDuJiHuaDao dao = new Dao.ShenChanJinDuJiHuaDao( );

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Exists ( MulaolaoLibrary.ShenChanJinDuJiHuaLibrary model )
        {
            return dao.Exists( model );
        }


        /// <summary>
        /// 是否存在相同工序序号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool ExistsId ( MulaolaoLibrary.ShenChanJinDuJiHuaLibrary model )
        {
            return dao.ExistsId( model );
        }


        /// <summary>
        /// 是否执行
        /// </summary>
        /// <param name="model"></param>
        /// <param name="formText"></param>
        /// <returns></returns>
        public bool ExistsReview ( MulaolaoLibrary.ShenChanJinDuJiHuaLibrary model ,string formText )
        {
            return dao.ExistsReview( model ,formText );
        }


        /// <summary>
        /// 复制一张表
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool GetDataCopy ( string oddNum )
        {
            return dao.GetDataCopy( oddNum );
        }




        /// <summary>
        /// 增加一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add ( MulaolaoLibrary.ShenChanJinDuJiHuaLibrary model )
        {
            return dao.Add( model );
        }


        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update ( MulaolaoLibrary.ShenChanJinDuJiHuaLibrary model )
        {
            return dao.Update( model );
        }

        /// <summary>
        /// 批量编辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateBatch ( MulaolaoLibrary.ShenChanJinDuJiHuaLibrary model ,string nameOfSpare ,string partCode ,int partNum )
        {
            return dao.UpdateBatch( model ,nameOfSpare ,partCode ,partNum );
        }

        /// <summary>
        /// 更新一条记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateAll ( MulaolaoLibrary.ShenChanJinDuJiHuaLibrary model )
        {
            return dao . UpdateAll ( model );
        }

        /// <summary>
        /// 检查是否046有436不存在的零件和工序
        /// </summary>
        /// <param name="num"></param>
        /// <param name="tableOne"></param>
        /// <returns></returns>
        public int checkPart ( string num ,DataTable tableOne )
        {
            return dao. checkPart ( num ,tableOne );
        }

        /// <summary>
        /// 更新维护记录
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateWeiHu ( MulaolaoLibrary.ShenChanJinDuJiHuaLibrary model )
        {
            return dao.UpdateWeiHu( model );
        }


        /// <summary>
        /// 更新复制数据的单号
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateCopy ( string oddNum )
        {
            return dao.UpdateCopy( oddNum );
        }


        /// <summary>
        /// 删除复制内容
        /// </summary>
        public bool DeleteCopy ( )
        {
            return dao.DeleteCopy( );
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
        /// 批量删除数据
        /// </summary>
        /// <param name="idxList"></param>
        /// <returns></returns>
        public bool DeleteIdxList ( string idxList )
        {
            return dao.DeleteIdxList( idxList );
        }


        /// <summary>
        /// 批量删除数据  依据单号
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool DeleteOddNumList ( string oddNum )
        {
            return dao.DeleteOddNumList( oddNum );
        }


        /// <summary>
        /// 获取数据列表  com
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableAll ( /*MulaolaoLibrary.ShenChanJinDuJiHuaLibrary model*/string strWhere )
        {
            return dao.GetDataTableAll( strWhere );
        }


        /// <summary>
        /// 获取一个实体对象
        /// </summary>
        /// <param name="idx"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ShenChanJinDuJiHuaLibrary GetModel ( int idx )
        {
            return dao.GetModel( idx );
        }


        /// <summary>
        /// 获取一个实体对象
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public MulaolaoLibrary.ShenChanJinDuJiHuaLibrary GetDataRow ( DataRow row )
        {
            return dao.GetDataRow( row );
        }


        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTable ( string strWhere,string numCount )
        {
            return dao.GetDataTable( strWhere ,numCount );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableAll ( string strWhere ,DateTime dateTi ,string numCount)
        {
            return dao.GetDataTableAll( strWhere ,dateTi ,numCount );
        }



        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataRow GetDataRowAll ( string strWhere ,DateTime dateTi )
        {
            return dao.GetDataRowAll( strWhere ,dateTi );
        }


        /// <summary>
        /// 获取数据列表  依据单号
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableToOdd ( string oddNum )
        {
            return dao.GetDataTableToOdd( oddNum );
        }

        /// <summary>
        /// 得到数据列表  查询
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableOnly ( )
        {
            return dao.GetDataTableOnly( );
        }

        /// <summary>
        /// 获取数据总记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetShenChanCount ( string strWhere )
        {
            return dao.GetShenChanCount( strWhere );
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



        /// <summary>
        /// 获取零件名称
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePart ( string strWhere,string part )
        {
            return dao.GetDataTablePart( strWhere ,part );
        }
        public System . Data . DataTable GetDataTablePart ( string strWhere )
        {
            return dao . GetDataTablePart ( strWhere  );
        }

        public DataTable GetDataTablePartFor509 ( string strWhere ,string part)
        {
            return dao . GetDataTablePartFor509 ( strWhere ,part);
        }

        /// <summary>
        /// 获取工艺数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableWorkPro ( )
        {
            return dao.GetDataTableWorkPro( );
        }

        /// <summary>
        /// 获取工序名称
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableWork ( string num ,string partName)
        {
            return dao . GetDataTableWork ( num ,partName );
        }

        public DataTable GetDataTableWork ( string num )
        {
            return dao . GetDataTableWork ( num );
        }

        /// <summary>
        /// 获取部件名称
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableParts ( string strWhere  )
        {
            return dao . GetDataTableParts ( strWhere );
        }

        /// <summary>
        /// 获取业务员
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableSalesman ( )
        {
            return dao.GetDataTableSalesman( );
        }

        /// <summary>
        /// 获取跟单组长
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableNaman ( )
        {
            return dao.GetDataTableNaman( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public System.Data.DataTable GetDataTablePlan ( )
        {
            return dao.GetDataTablePlan( );
        }

        /// <summary>
        /// 生成配套表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="dateD"></param>
        /// <returns></returns>
        public System.Data.DataTable GetDataTableProduct ( string strWhere ,DateTime dateD,string numCount )
        {
            return dao.GetDataTableProduct( strWhere ,dateD ,numCount );
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="strWhere"></param>
        /// <param name="dateD"></param>
        /// <param name="numCount"></param>
        /// <returns></returns>
        public DataTable printTableOne ( string strWhere ,DateTime dateD ,string numCount )
        {
            return dao . printTableOne ( strWhere ,dateD ,numCount );
        }

        /// <summary>
        /// 获取打印列表
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrint ( string num )
        {
            return dao . GetDataTablePrint ( num );
        }

        /// <summary>
        /// 更改隐藏标记
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateHideYes ( MulaolaoLibrary.ShenChanJinDuJiHuaLibrary model )
        {
            return dao.UpdateHideYes( model );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="numCount"></param>
        /// <returns></returns>
        public DataTable GetDataTablePrice ( string numCount )
        {
            return dao.GetDataTablePrice( numCount );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="numCount"></param>
        /// <returns></returns>
        public DataTable GetDataTablePri ( string numCount )
        {
            return dao.GetDataTablePri( numCount );
        }

        /// <summary>
        /// 更改每套数量
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdatePrice ( MulaolaoLibrary.ShenChanJinDuJiHuaLibrary model )
        {
            return dao.UpdatePrice( model );
        }

        /// <summary>
        /// 编辑交货日期
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool UpdateDate ( string oddNum ,DateTime date ,int dtSpan )
        {
            return dao . UpdateDate ( oddNum ,date ,dtSpan );
        }

        /// <summary>
        /// 编辑工序增减道差
        /// </summary>
        /// <param name="oddNum"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool UpdateNum ( string oddNum ,int num )
        {
            return dao.UpdateNum( oddNum ,num );
        }


        /// <summary>
        /// 编辑部件工序道数
        /// </summary>
        /// <param name="lsNum"></param>
        /// <param name="ljName"></param>
        /// <param name="gx"></param>
        /// <returns></returns>
        public bool UpdateB ( string lsNum ,string ljName ,int gx )
        {
            return dao . UpdateB ( lsNum ,ljName ,gx );
        }

        /// <summary>
        /// 批量编辑工艺
        /// </summary>
        /// <param name="ori"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        public bool UpdateBatchWorkPro ( string ori ,string now )
        {
            return dao.UpdateBatchWorkPro( ori ,now );
        }

        /// <summary>
        /// 编辑累计部件量=累计部件量+当日生产量（流水，单号，来源，PQX39(当日生产量的日期)）
        /// </summary>
        /// <param name="numCount"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public int EditPQX34 ( string numCount ,string oddNum )
        {
            return dao . EditPQX34 ( numCount ,oddNum );
        }

        /// <summary>
        /// 当(工序实投产日期)显示≥(工序计划投产日期)时(欠投产天数)栏位开始计数直到(日产部件量)栏位有数值读入时静止计数[(欠投产天数)该栏位的负数值就是该工序的延误投产天数]
        /// </summary>
        /// <param name="num">流水号</param>
        /// <param name="oddNum">合同号</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public bool EditToOtherColumn ( string num ,string oddNum ,DateTime dt )
        {
            return dao . EditToOtherColumn ( num ,oddNum ,dt );
        }

        /// <summary>
        /// (工序实投产日期)显示≥(工序计划投产日期)或(日产部件量)栏位有数值读入时(工序实产周期)栏位开始计数直到(还要生产部件)栏位值0≦时(工序实产周期)栏位静止计数[(工序实产周期)该栏位的负数值就是该工序的延迟交期天数]
        /// </summary>
        /// <param name="num">流水号</param>
        /// <param name="oddNum">单号</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public bool EditToOtherColumnForU2 ( string num ,string oddNum  ,DateTime dt)
        {
            return dao . EditToOtherColumnForU2 ( num ,oddNum  ,dt );
        }

        /// <summary>
        /// (累欠产量)=(当日欠产量)+前面的累欠产量    注:和(累计已生产量)计算方法相同 
        /// </summary>
        /// <param name="num">流水号</param>
        /// <param name="oddNum">单号</param>
        /// <param name="strWhere">条件</param>
        /// <param name="dt">日期</param>
        /// <returns></returns>
        public bool EditToOtherColumnForU14 ( string num ,string oddNum  ,DateTime dt )
        {
            return dao . EditToOtherColumnForU14 ( num ,oddNum  ,dt );
        }

        /// <summary>
        /// (工序积压亏损数量)=(累已产部件量)下道工序(栏位)减上道工序(栏位)
        /// </summary>
        /// <param name="num">流水号</param>
        /// <param name="oddNum">单号</param>
        /// <returns></returns>
        public bool EditToOtherColounForU12 ( string num ,string oddNum )
        {
            return dao . EditToOtherColounForU12 ( num ,oddNum );
        }

        /// <summary>
        /// (日产部件量差)改(R317读入次数)=从R317每读入1次就累加1次
        /// </summary>
        /// <param name="num">流水号</param>
        /// <param name="oddNum">单号</param>
        /// <param name="dt">日期</param>
        /// <returns></returns>
        public bool EditToOtherColumnForU29 ( string num ,string oddNum ,DateTime dt )
        {
            return dao . EditToOtherColumnForU29 ( num ,oddNum ,dt );
        }

        /// <summary>
        /// 调整日产部件  工序实产周期大于等于1时计算，否则不变，  还要生产部件等于零时为零
        /// </summary>
        /// <param name="num"></param>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool EditToOtherColumnForU9 ( string num ,string oddNum )
        {
            return dao . EditToOtherColumnForU9 ( num ,oddNum );
        }

        /// <summary>
        /// 获取累计生产量
        /// </summary>
        /// <param name="idx"></param>
        /// <param name="num">日产部件量</param>
        /// <param name="name">加法还是减法</param>
        /// <returns></returns>
        public int EditAll ( string idx ,int num ,string name )
        {
            return dao . EditAll ( idx ,num ,name );
        }

        /// <summary>
        /// 编辑预计生产日期
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool EditWork ( List<DataRow> rows ,MulaolaoLibrary . ShenChanJinDuJiHuaLibrary model )
        {
            return dao . EditWork ( rows ,model );
        }

    }
}
