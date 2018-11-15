using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MulaolaoBll.Bll
{
    public class PayMentBll
    {
        Dao.PayMentDao _dao = new Dao.PayMentDao( );

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableCombo ( )
        {
            return _dao.GetDataTableCombo( );
        }
        public DataTable GetDataTableComboOne ( )
        {
            return _dao.GetDataTableComboOne( );
        }
        public DataTable GetDataTableComboTwo ( )
        {
            return _dao.GetDataTableComboTwo( );
        }
        public DataTable GetDataTableComboTre ( )
        {
            return _dao.GetDataTableComboTre( );
        }
        public DataTable GetDataTableComboFor ( )
        {
            return _dao.GetDataTableComboFor( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTable ( string strWhere )
        {
            return _dao.GetDataTable( strWhere );
        }

        /// <summary>
        /// 获取323数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPqez ( string strWhere )
        {
            return _dao.GetDataTableOfPqez( strWhere );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnly ( )
        {
            return _dao.GetDataTableOnly( );
        }

        /// <summary>
        /// 323数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnlyOfPqez ( )
        {
            return _dao.GetDataTableOnlyOfPqez( );
        }

        /// <summary>
        /// 获取扣款明细
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableSupplier (  )
        {
            return _dao.GetDataTableSupplier(  );
        }

        /// <summary>
        /// 获取工资
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPay ( DateTime dt ,string strWhere )
        {
            return _dao.GetDataTableOfPay( dt ,strWhere );
        }

        /// <summary>
        /// 获取工资
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfPays ( DateTime dt ,string strWhere )
        {
            return _dao.GetDataTableOfPays( dt ,strWhere );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataTable GetDataTableOfAll ( string strWhere )
        {
            return _dao.GetDataTableOfAll( strWhere );
        }
        public DataTable GetDataTableOfAllOne ( string strWhere )
        {
            return _dao.GetDataTableOfAllOne( strWhere );
        }
        public DataTable GetDataTableOfAllTwo ( string strWhere )
        {
            return _dao.GetDataTableOfAllTwo( strWhere );
        }
        public DataTable GetDataTableOfAllTre ( string strWhere )
        {
            return _dao.GetDataTableOfAllTre( strWhere );
        }
        public DataTable GetDataTableOfAllFor ( string strWhere )
        {
            return _dao.GetDataTableOfAllFor( strWhere );
        }
        public DataTable GetDataTableOfAllFiv ( )
        {
            return _dao.GetDataTableOfAllFiv( );
        }
        public DataTable GetDataTableOfAllSix ( )
        {
            return _dao.GetDataTableOfAllSix( );
        }

        /// <summary>
        /// 编辑状态
        /// </summary>
        /// <param name="signOne"></param>
        /// <param name="signTwo"></param>
        /// <param name="signTre"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public bool UpdateStateSe ( string signOne ,string signTwo ,string signTre ,string signFor ,string signFiv ,string signSix,DateTime dt ,string signSev)
        {
            return _dao . UpdateStateSe ( signOne , signTwo , signTre , signFor , signFiv , signSix , dt , signSev );
        }
        public bool UpdateState ( string signOne ,string signTwo ,string signTre ,string signFor ,string signFiv ,string signSix ,string signSev)
        {
            return _dao . UpdateState ( signOne , signTwo , signTre , signFor , signFiv , signSix , signSev );
        }
        public bool UpdateState ( string signOne ,string signTwo ,string signTre ,string signFor ,string signFiv ,string state,string signSix,string signEgi )
        {
            return _dao.UpdateState( signOne ,signTwo ,signTre ,signFor ,signFiv ,state ,signSix , signEgi );
        }
        public bool UpdateState ( string signOne ,string signTwo ,string signTre ,string signFor ,string signFiv ,string state ,DateTime dt,string signSix )
        {
            return _dao.UpdateState( signOne ,signTwo ,signTre ,signFor ,signFiv ,state ,dt ,signSix );
        }
        public bool UpdateState ( string signOne ,DateTime dt ,string state )
        {
            return _dao . UpdateState ( signOne ,dt ,state  );
        }


        public bool UpdateStateOf ( string oddNum ,List<string> strList ,string imPlement )
        {
            return _dao.UpdateStateOf( oddNum , strList , imPlement );
        }
        public bool UpdateStateOfs ( string oddNum ,List<string> strList ,string imPlement )
        {
            return _dao . UpdateStateOfs ( oddNum , strList , imPlement );
        }
        public bool UpdateStateOfVirwTre ( string oddNum ,List<string> strList ,string imPlement )
        {
            return _dao . UpdateStateOfVirwTre ( oddNum ,strList ,imPlement );
        }
        public bool UpdateStateOfVirwFor ( string oddNum ,List<string> strList ,string imPlement )
        {
            return _dao . UpdateStateOfVirwFor ( oddNum ,strList ,imPlement );
        }
        public int UpdaetOfDt ( string oddNum ,string sate ,DateTime dtTwo )
        {
            return _dao.UpdaetOfDt( oddNum ,sate ,dtTwo );
        }

        public int UpdaetOfDtAp ( string oddNum ,string sate ,DateTime dtTwo )
        {
            return _dao.UpdaetOfDtAp( oddNum ,sate ,dtTwo );
        }
        public int UpdaetOfDtViewTre ( string oddNum ,string sate ,DateTime dtTwo )
        {
            return _dao . UpdaetOfDtViewTre ( oddNum ,sate ,dtTwo );
        }
        public int UpdaetOfDtViewFor ( string oddNum ,string sate ,DateTime dtTwo )
        {
            return _dao . UpdaetOfDtViewFor ( oddNum ,sate ,dtTwo );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool AddNew ( DataTable table )
        {
            return _dao.AddNew( table );
        }
        public bool AddNewOne ( DataTable table )
        {
            return _dao.AddNewOne( table );
        }
        public bool AddNewTwo ( DataTable table )
        {
            return _dao.AddNewTwo( table );
        }
        public bool AddNewTre ( DataTable table )
        {
            return _dao.AddNewTre( table );
        }
        public bool AddNewFor ( DataTable table )
        {
            return _dao.AddNewFor( table );
        }

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool AddOne ( DataTable table )
        {
            return _dao.AddOne( table );
        }
        public bool AddTwo ( DataTable table )
        {
            return _dao.AddTwo( table );
        }
        public bool AddTre ( DataTable table )
        {
            return _dao.AddTre( table );
        }
        public bool AddFor ( DataTable table )
        {
            return _dao.AddFor( table );
        }
        public bool AddFiv ( DataTable table )
        {
            return _dao.AddFiv( table );
        }

        /// <summary>
        /// 删除一单记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool Delete ( string oddNum )
        {
            return _dao.Delete( oddNum );
        }
        public bool Deletes ( string idxList )
        {
            return _dao.Deletes( idxList );
        }
        public bool DeleteOne ( string oddNum )
        {
            return _dao.DeleteOne( oddNum );
        }
        public bool DeleteOnes ( string idxList )
        {
            return _dao.DeleteOnes( idxList );
        }
        public bool DeleteTwo ( string oddNum )
        {
            return _dao.DeleteTwo( oddNum );
        }
        public bool DeleteTwos ( string idxList )
        {
            return _dao.DeleteTwos( idxList );
        }
        public bool DeleteTre ( string oddNum )
        {
            return _dao.DeleteTre( oddNum );
        }
        public bool DeleteTres ( string idxList )
        {
            return _dao.DeleteTres( idxList );
        }
        public bool DeleteFor ( string oddNum )
        {
            return _dao.DeleteFor( oddNum );
        }
        public bool DeleteFors ( string idxList )
        {
            return _dao.DeleteFors( idxList );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfOddNum ( )
        {
            return _dao.GetDataTableOfOddNum( );
        }
        public DataTable GetDataTableOfOddNumOne ( )
        {
            return _dao.GetDataTableOfOddNumOne( );
        }

        /// <summary>
        /// 获取数据记录数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount ( string strWhere )
        {
            return _dao.GetCount( strWhere );
        }
        public int GetCountOne ( string strWhere )
        {
            return _dao.GetCountOne( strWhere );
        }
        public int GetCountTwo ( string strWhere )
        {
            return _dao.GetCountTwo( strWhere );
        }
        public int GetCountTre ( string strWhere )
        {
            return _dao.GetCountTre( strWhere );
        }
        public int GetCountFor ( string strWhere )
        {
            return _dao.GetCountFor( strWhere );
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
            return _dao.GetDataTableByChange( strWhere ,startIndex ,endIndex );
        }
        public DataTable GetDataTableByChangeOne ( string strWhere ,int startIndex ,int endIndex )
        {
            return _dao.GetDataTableByChangeOne( strWhere ,startIndex ,endIndex );
        }
        public DataTable GetDataTableByChangeTwo ( string strWhere ,int startIndex ,int endIndex )
        {
            return _dao.GetDataTableByChangeTwo( strWhere ,startIndex ,endIndex );
        }
        public DataTable GetDataTableByChangeTre ( string strWhere ,int startIndex ,int endIndex )
        {
            return _dao.GetDataTableByChangeTre( strWhere ,startIndex ,endIndex );
        }
        public DataTable GetDataTableByChangeFor ( string strWhere ,int startIndex ,int endIndex )
        {
            return _dao.GetDataTableByChangeFor( strWhere ,startIndex ,endIndex );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOnlyOne ( )
        {
            return _dao.GetDataTableOnlyOne( );
        }
        public DataTable GetDataTableOnlyTwo ( )
        {
            return _dao.GetDataTableOnlyTwo( );
        }
        public DataTable GetDataTableOnlyTre ( )
        {
            return _dao.GetDataTableOnlyTre( );
        }

        /// <summary>
        /// 获取本月之前所有记录和
        /// </summary>
        /// <param name="dtOne">当前日期</param>
        /// <param name="dtTwo">开始日期</param>
        /// <returns></returns>
        public DataTable GetDataTableSumOne ( DateTime dtOne ,DateTime dtTwo )
        {
            return _dao.GetDataTableSumOne( dtOne ,dtTwo );
        }
        public DataTable GetDataTableSumTwo ( DateTime dtOne ,DateTime dtTwo )
        {
            return _dao.GetDataTableSumTwo( dtOne ,dtTwo );
        }
        public DataTable GetDataTableSumTre ( DateTime dtOne ,DateTime dtTwo )
        {
            return _dao.GetDataTableSumTre( dtOne ,dtTwo );
        }
        public DataTable GetDataTableSumFor ( DateTime dtOne ,DateTime dtTwo )
        {
            return _dao.GetDataTableSumFor( dtOne ,dtTwo );
        }

        /// <summary>
        /// 更改送审记录
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateOfReview ( string oddNum )
        {
            return _dao.UpdateOfReview( oddNum );
        }

        /// <summary>
        /// 批量编辑日期
        /// </summary>
        /// <param name="_model"></param>
        /// <returns></returns>
        public bool UpdateOfBatchTime ( MulaolaoLibrary.PayMentLibrary _model )
        {
            return _dao.UpdateOfBatchTime( _model );
        }
        public bool UpdateOfBatchTime ( MulaolaoLibrary.PayMentOneLibrary _modelOne )
        {
            return _dao.UpdateOfBatchTime( _modelOne );
        }

        /// <summary>
        /// 写入数据到241
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Read526To241 ( DataTable table )
        {
            return _dao.Read526To241( table );
        }
        public bool Read526To241AP ( DataTable table )
        {
            return _dao.Read526To241AP( table );
        }

        /// <summary>
        /// 去除勾选掉的内容
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public bool Delete256WriteTo241 ( DataTable table )
        {
            return _dao.Delete256WriteTo241( table );
        }
        public bool Delete256WriteTo241AP ( DataTable table )
        {
            return _dao.Delete256WriteTo241AP( table );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfF12 ( )
        {
            return _dao.GetDataTableOfF12( );
        }

        /// <summary>
        /// 是否隐藏列
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool UpdateOfHide ( string state )
        {
            return _dao.UpdateOfHide( state );
        }

        /// <summary>
        /// 是否隐藏
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfHide ( )
        {
            return _dao.GetDataTableOfHide( );
        }

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfTre ( )
        {
            return _dao.GetDataTableOfTre( );
        }


        /// <summary>
        /// 获取480数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTableOfFor ( )
        {
            return _dao . GetDataTableOfFor ( );
        }

        /// <summary>
        /// 批量编辑526标记
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public bool UpdateOfSign ( string strWhere )
        {
            return _dao.UpdateOfSign( strWhere );
        }

        /// <summary>
        /// 回写扣借支款到借款木佬佬还款额
        /// </summary>
        /// <param name="unit">使用单位</param>
        /// <param name="person">借款单位</param>
        /// <param name="money">还款额</param>
        /// <returns></returns>
        public bool UpdateJkTo (string handPer, string unit ,string person ,decimal money )
        {
            return _dao . UpdateJkTo (handPer, unit ,person ,money );
        }

        /// <summary>
        /// 回写扣借支款到借款木佬佬还款额
        /// </summary>
        /// <param name="unit">使用单位</param>
        /// <param name="person">借款单位</param>
        /// <param name="money">还款额</param>
        /// <returns></returns>
        public bool UpdateJkyTo ( string handPer ,string unit ,string person ,decimal money )
        {
            return _dao . UpdateJkyTo ( handPer ,unit ,person ,money );
        }

    }
}
