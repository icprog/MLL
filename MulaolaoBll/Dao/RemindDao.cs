using System . Data;
using System . Text;
using StudentMgr;
using System . Threading . Tasks;
using System . Collections;

namespace MulaolaoBll . Dao
{
    public class RemindDao
    {
        /// <summary>
        /// 获取021-509--436--046提示
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public DataTable getTableFor021 ( string userNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            if ( userNum . Equals ( "MLL-0018" ) || userNum . Equals ( "MLL-0007" ) || userNum . Equals ( "MLL-0025" ) || userNum . Equals ( "MLL-0026" ) || userNum . Equals ( "MLL-0020" ) )
                userNum = "MLL-0001";
            strSql . Append ( "WITH CET AS(" );
            strSql . Append ( "SELECT 'R_021' tn021,PQF01,PQF04,PQF02,PQF03,PQF31 FROM R_PQF A INNER JOIN R_REVIEWS B ON A.PQF01=B.RES06 WHERE PQF01 NOT IN (SELECT PQF01 FROM R_PQF A INNER JOIN R_REVIEWS B ON A.PQF01=B.RES06 LEFT JOIN R_PQL C ON A.PQF01=C.HT01 WHERE RES05='执行') AND  RES05='执行')" );
            strSql . Append ( ",CFT AS(" );
            strSql . AppendFormat ( "SELECT DISTINCT B.* FROM R_DBB A INNER JOIN CET B ON A.DBB002=B.tn021 WHERE DBB002='R_021' AND DBB001='{0}' AND DBB004='T'" ,userNum );
            strSql . Append ( "),CHT AS(" );
            strSql . Append ( "SELECT 'R_509' tn509,HT01,PQF04,HT02,PQF03,PQF31 FROM R_PQL A INNER JOIN R_REVIEWS B ON A.HT01=B.RES06 INNER JOIN R_PQF C ON A.HT01=C.PQF01 WHERE HT01 NOT IN (SELECT HT01 FROM R_PQL A INNER JOIN R_REVIEWS B ON A.HT01=B.RES06 INNER JOIN R_PQP C ON A.HT01=C.GS01 WHERE RES05='执行') AND RES05='执行'" );
            strSql . Append ( "),CGT AS(" );
            strSql . AppendFormat ( "SELECT DISTINCT B.HT01,B.tn509 FROM R_DBB A INNER JOIN CHT B ON A.DBB002=B.tn509 WHERE DBB002='R_509' AND DBB001='{0}' AND DBB004='T'" ,userNum );
            strSql . Append ( "),CIT AS(" );
            strSql . Append ( "SELECT DISTINCT 'R_436' tn436,GS01,GS46,GS47,GS48,'' PQF31 FROM R_PQP A INNER JOIN R_REVIEWS B ON A.GS34=B.RES06 WHERE GS01 NOT IN (SELECT DISTINCT GS01 FROM R_PQP A INNER JOIN R_REVIEWS B ON A.GS34=B.RES06 INNER JOIN R_PQR D ON A.GS01=D.DS01 WHERE RES05='执行') AND RES05='执行' AND GS01!=''" );
            strSql . Append ( "),CJT AS(" );
            strSql . AppendFormat ( "SELECT DISTINCT B.GS01,B.tn436 FROM R_DBB A INNER JOIN CIT B ON A.DBB002=B.tn436 WHERE DBB002='R_436' AND DBB001='{0}' AND DBB004='T'" ,userNum );
            strSql . Append ( "),CKT AS(" );
            //strSql . Append ( "SELECT DISTINCT 'R_046' tn046,PQF01,PQF04,PQF02,PQF03,PQF31 FROM R_PQR A RIGHT JOIN R_PQF C ON A.DS01=C.PQF01  WHERE PQF01 NOT IN (SELECT DISTINCT DS01 FROM (SELECT DISTINCT DS01,DS21 FROM R_PQR) A INNER JOIN (SELECT DISTINCT PQX01 FROM R_PQX) D ON A.DS01=D.PQX01) " );
            strSql . Append ( "SELECT DISTINCT 'R_046' tn046,PQX01,PQF01,PQF04,PQF02,PQF03,PQF31 FROM R_PQX A RIGHT JOIN R_PQF C ON A.PQX01=C.PQF01 " );
            strSql . Append ( "),CLT AS(" );
            strSql . AppendFormat ( "SELECT DISTINCT B.PQF01,B.PQX01,B.tn046 FROM R_DBB A INNER JOIN CKT B ON A.DBB002=B.tn046 WHERE DBB002='R_046' AND DBB001='{0}' AND DBB004='T')" ,userNum );
            strSql . Append ( "SELECT A.PQF01,A.PQF02,A.PQF03,A.PQF04,CASE WHEN B.tn021 IS NULL THEN 'R_021' ELSE NULL END tn021,CASE WHEN C.tn509 IS NULL THEN 'R_509' ELSE NULL END tn509,CASE WHEN D.tn436 IS NULL THEN 'R_436' ELSE NULL END tn436,CASE WHEN PQX01 IS NULL THEN NULL ELSE E.tn046 END tn046,A.PQF31 FROM R_PQF A LEFT JOIN CFT B ON A.PQF01=B.PQF01 LEFT JOIN CGT C ON A.PQF01=C.HT01 LEFT JOIN CJT D ON A.PQF01=D.GS01 LEFT JOIN CLT E ON A.PQF01=E.PQF01 WHERE ( tn021 IS NOT NULL OR tn509 IS NOT NULL OR tn436 IS NOT NULL OR tn046 IS NOT NULL) AND A.PQF01 NOT IN ( SELECT DISTINCT AE02 FROM R_PQAE WHERE AE21 IS NOT NULL OR AE21!='') order by A.PQF31" );//CASE WHEN E.tn046 IS NULL THEN 'R_046' ELSE NULL END tn046

            Task task = new Task ( updatepqae );
            task . Start ( );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取采购合同提示
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public DataTable getTableForContract ( string userNum )
        {
            StringBuilder strSql = new StringBuilder ( );//MLL-0007
            if ( !userNum . Equals ( "MLL-0001" ) && !userNum . Equals ( "MLL-0018" ) && !userNum . Equals ( "MLL-0007" ) && !userNum . Equals ( "MLL-0025" ) && !userNum . Equals ( "MLL-0026" ) )
            {
                //strSql . AppendFormat ( "SELECT A.idx,'产品委外(成品、雕刻、冲印、砂皮)等承揽加工合同书(R_195)' tn,CP51,CP01,CP52,CP03,CP06,CP07,CP54,CP54*CP13 CP1,PQF31,CP57 FROM R_PQQ A INNER JOIN R_PQF B ON A.CP01=B.PQF01 INNER JOIN R_REVIEWS D ON A.CP03=D.RES06 WHERE CP02='{0}' AND RES05='执行' AND (CP61='' OR CP61 IS NULL) " ,userNum );
                //strSql . Append ( " UNION ALL " );
                //strSql . AppendFormat ( "SELECT A.idx,'丝.热.移印(化学品)承揽加工合同书 (R_196)' tn,AH98,AH01,AH99,AH97,AH10,AH11,AH101,AH101*AH13*AH14 AH,PQF31,AH112 FROM R_PQAH A INNER JOIN R_PQF B ON A.AH01=B.PQF01 INNER JOIN R_REVIEWS D ON A.AH97=D.RES06 WHERE AH02='{0}' AND RES05='执行' AND (AH116='' OR AH116 IS NULL) " ,userNum );
                //strSql . Append ( " UNION ALL " );
                strSql . Append ( "WITH CET AS (" );
                strSql . AppendFormat ( "SELECT A.idx,'委外加工合同(R_199)' tn,BA051 CP51,BA001 CP01,BA052 CP52,BA003 CP03,BA006 CP06,BA007 CP07,BA054 CP54,BA054 CP1,PQF31,BA057 CP57 FROM R_PQBA A INNER JOIN R_PQF B ON A.BA001=B.PQF01 INNER JOIN R_REVIEWS D ON A.BA003=D.RES06 WHERE BA002='{0}' AND RES05='执行' AND (BA062='' OR BA062 IS NULL)  " ,userNum );
                strSql . Append ( " UNION ALL " );
                strSql . AppendFormat ( "SELECT A.idx,'胶合板、密度板采购合同书(R_338)' tn,JM100,JM90,JM101,JM01,JM09,CONVERT(VARCHAR,JM94)+'*'+CONVERT(VARCHAR,JM95)+'*'+CONVERT(VARCHAR,JM96) JM,JM103,CASE WHEN JM14='外购' THEN JM104 ELSE JM15 END JM1,PQF31,JM108 FROM R_PQO A INNER JOIN R_PQF B ON A.JM90=B.PQF01 INNER JOIN R_REVIEWS D ON A.JM01=D.RES06 WHERE JM02='{0}' AND RES05='执行' AND (JM115='' OR JM115 IS NULL)  " ,userNum );
                strSql . Append ( " UNION ALL " );
                strSql . AppendFormat ( "SELECT A.idx,'油漆（墨）等化学品采购合同书(R_339)' tn,YQ105,YQ03,YQ106,YQ99,YQ10,YQ12,YQ108,CASE WHEN YQ101='外购' THEN YQ109 ELSE YQ19 END YQ,PQF31,YQ124 FROM R_PQI A INNER JOIN R_PQF B ON A.YQ03=B.PQF01 INNER JOIN R_REVIEWS D ON A.YQ99=D.RES06 WHERE YQ99 LIKE 'R_339%' AND YQ01='{0}' AND RES05='执行' AND (YQ137='' OR YQ137 IS NULL) " ,userNum );
                strSql . Append ( " UNION ALL " );
                strSql . AppendFormat ( "SELECT A.idx,'库存油漆（墨）等采购合同书(R_337)' tn,YQ105,YQ03,YQ106,YQ99,YQ06,YQ11,0 YQ12,YQ109,YQ17,YQ124 FROM R_PQI A INNER JOIN R_REVIEWS D ON A.YQ99=D.RES06 WHERE YQ99 LIKE 'R_337%' AND YQ01='{0}' AND RES05='执行' AND (YQ138='' OR YQ138 IS NULL) " ,userNum );
                strSql . Append ( " UNION ALL  " );
                strSql . AppendFormat ( "SELECT A.idx,'木材采购合同(R_341)' tn,PQV77,PQV01,PQV78,PQV76,PQV10,CONVERT(VARCHAR,PQV66)+'*'+CONVERT(VARCHAR,PQV81)+'*'+CONVERT(VARCHAR,PQV67) PQV,PQV80,CASE WHEN PQV65='外购' THEN PQV82 ELSE PQV64 END PQV1,PQF31,PQV89 FROM R_PQV A INNER JOIN R_PQF B ON A.PQV01=B.PQF01 INNER JOIN R_REVIEWS D ON A.PQV76=D.RES06 WHERE PQV02='{0}' AND RES05='执行' AND (PQV96='' OR PQV96 IS NULL) " ,userNum );
                strSql . Append ( " UNION ALL " );
                strSql . AppendFormat ( "SELECT A.idx,'车木件采购合同(R_342)' tn,AF003,AF002,AF005,AF001,AF015,CONVERT(VARCHAR,AF020)+'*'+CONVERT(VARCHAR,AF021)+'*'+CONVERT(VARCHAR,AF022) AF,AF006,CASE WHEN AF016='外购' THEN AF017 ELSE AF018 END AF1,PQF31,AF079 FROM R_PQAF A INNER JOIN R_PQF B ON A.AF002=B.PQF01 INNER JOIN R_REVIEWS D ON A.AF001=D.RES06 WHERE AF007='{0}' AND RES05='执行' AND (AF086='' OR AF086 IS NULL) " ,userNum );
                strSql . Append ( " UNION ALL " );
                strSql . AppendFormat ( "SELECT A.idx,'五金件(镀、烤漆)采购合同书(R_343)' tn,PQU98,PQU01,PQU99,PQU97,PQU10,PQU12,PQU101,CASE WHEN PQU19='外购' THEN PQU104 ELSE PQU18 END PQU,PQF31,PQU108 FROM R_PQU A INNER JOIN R_PQF B ON A.PQU01=B.PQF01 INNER JOIN R_REVIEWS D ON A.PQU97=D.RES06 WHERE PQU02='{0}' AND RES05='执行' AND (PQU114='' OR PQU114 IS NULL) " ,userNum );
                strSql . Append ( " UNION ALL " );
                strSql . AppendFormat ( "SELECT A.idx,'滚漆承揽加工成本合同书(R_344)' tn,MZ003,MZ002,MZ004,MZ001,MZ016,MZ018,MZ006,MZ006*MZ021 MZ,PQF31,'' MZ1 FROM R_PQMZ A INNER JOIN R_PQF B ON A.MZ002=B.PQF01 INNER JOIN R_REVIEWS D ON A.MZ001=D.RES06 WHERE MZ117='{0}' AND RES05='执行' AND (MZ128='' OR MZ128 IS NULL) " ,userNum );
                strSql . Append ( " UNION ALL " );
                strSql . AppendFormat ( "SELECT A.idx,'产品塑料、布和其他零配件采购合同(R_347)' tn,PJ93,PJ01,PJ94,PJ92,PJ09,PJ89,PJ96,PJ11*PJ96+PJ10 PJ,PQF31,PJ101 FROM R_PQS A INNER JOIN R_PQF B ON A.PJ01=B.PQF01 INNER JOIN R_REVIEWS D ON A.PJ92=D.RES06 WHERE PJ02='{0}' AND RES05='执行' AND (PJ108='' OR PJ108 IS NULL) " ,userNum );
                strSql . Append ( " UNION ALL " );
                strSql . AppendFormat ( "SELECT A.idx,'外箱、中包、彩盒、纸片（卡）等采购合同(R_349)' tn,WX83,WX01,WX84,WX82,WX10,WX11,WX86,CASE WHEN WX17='外购' THEN WX87 ELSE WX16 END WX,PQF31,WX91 FROM R_PQT  A INNER JOIN R_PQF B ON A.WX01=B.PQF01 INNER JOIN R_REVIEWS D ON A.WX82=D.RES06 WHERE WX02='{0}' AND RES05='执行' AND (WX95='' OR WX95 IS NULL) " ,userNum );
                strSql . Append ( ")" );
                strSql . Append ( "SELECT * FROM CET WHERE CP01 NOT IN (SELECT DISTINCT AE02 FROM R_PQAE WHERE AE21 IS NOT NULL OR AE21!='')" );
            }
            else if(userNum.Equals( "MLL-0001") || userNum . Equals ( "MLL-0018" ) || userNum . Equals ( "MLL-0007" ) || userNum . Equals ( "MLL-0025" ) || userNum . Equals ( "MLL-0026" ) || userNum . Equals ( "MLL-0020" ) )
            {
                //strSql . AppendFormat ( "SELECT A.idx,'产品委外(成品、雕刻、冲印、砂皮)等承揽加工合同书(R_195)' tn,CP51,CP01,CP52,CP03,CP06,CP07,CP54,CP54*CP13 CP1,PQF31,CP57 FROM R_PQQ A INNER JOIN R_PQF B ON A.CP01=B.PQF01 INNER JOIN R_REVIEWS D ON A.CP03=D.RES06 WHERE RES05='执行' AND (CP61='' OR CP61 IS NULL) " );
                //strSql . Append ( " UNION ALL " );
                //strSql . AppendFormat ( "SELECT A.idx,'丝.热.移印(化学品)承揽加工合同书 (R_196)' tn,AH98,AH01,AH99,AH97,AH10,AH11,AH101,AH101*AH13*AH14 AH,PQF31,AH112 FROM R_PQAH A INNER JOIN R_PQF B ON A.AH01=B.PQF01 INNER JOIN R_REVIEWS D ON A.AH97=D.RES06 WHERE RES05='执行' AND (AH116='' OR AH116 IS NULL) "  );
                //strSql . Append ( " UNION ALL " );
                strSql . Append ( "WITH CET AS (" );
                strSql . AppendFormat ( "SELECT A.idx,'委外加工合同(R_199)' tn,BA051 CP51,BA001 CP01,BA052 CP52,BA003 CP03,BA006 CP06,BA007 CP07,BA054 CP54,BA054 CP1,PQF31,BA057 CP57 FROM R_PQBA A INNER JOIN R_PQF B ON A.BA001=B.PQF01 INNER JOIN R_REVIEWS D ON A.BA003=D.RES06 WHERE  RES05='执行' AND (BA062='' OR BA062 IS NULL)  " );
                strSql . Append ( " UNION ALL " );
                strSql . AppendFormat ( "SELECT A.idx,'胶合板、密度板采购合同书(R_338)' tn,JM100,JM90,JM101,JM01,JM09,CONVERT(VARCHAR,JM94)+'*'+CONVERT(VARCHAR,JM95)+'*'+CONVERT(VARCHAR,JM96) JM,JM103,CASE WHEN JM14='外购' THEN JM104 ELSE JM15 END JM1,PQF31,JM108 FROM R_PQO A INNER JOIN R_PQF B ON A.JM90=B.PQF01 INNER JOIN R_REVIEWS D ON A.JM01=D.RES06 WHERE RES05='执行' AND (JM115='' OR JM115 IS NULL)  "  );
                strSql . Append ( " UNION ALL " );
                strSql . AppendFormat ( "SELECT A.idx,'油漆（墨）等化学品采购合同书(R_339)' tn,YQ105,YQ03,YQ106,YQ99,YQ10,YQ12,YQ108,CASE WHEN YQ101='外购' THEN YQ109 ELSE YQ19 END YQ,PQF31,YQ124 FROM R_PQI A INNER JOIN R_PQF B ON A.YQ03=B.PQF01 INNER JOIN R_REVIEWS D ON A.YQ99=D.RES06 WHERE YQ99 LIKE 'R_339%' AND RES05='执行' AND (YQ137='' OR YQ137 IS NULL) "  );
                strSql . Append ( " UNION ALL " );
                strSql . AppendFormat ( "SELECT A.idx,'库存油漆（墨）等采购合同书(R_337)' tn,YQ105,YQ03,YQ106,YQ99,YQ06,YQ11,0 YQ12,YQ109,YQ17,YQ124 FROM R_PQI A INNER JOIN R_REVIEWS D ON A.YQ99=D.RES06 WHERE YQ99 LIKE 'R_337%' AND  RES05='执行' AND (YQ138='' OR YQ138 IS NULL) "  );
                strSql . Append ( " UNION ALL  " );
                strSql . AppendFormat ( "SELECT A.idx,'木材采购合同(R_341)' tn,PQV77,PQV01,PQV78,PQV76,PQV10,CONVERT(VARCHAR,PQV66)+'*'+CONVERT(VARCHAR,PQV81)+'*'+CONVERT(VARCHAR,PQV67) PQV,PQV80,CASE WHEN PQV65='外购' THEN PQV82 ELSE PQV64 END PQV1,PQF31,PQV89 FROM R_PQV A INNER JOIN R_PQF B ON A.PQV01=B.PQF01 INNER JOIN R_REVIEWS D ON A.PQV76=D.RES06 WHERE  RES05='执行' AND (PQV96='' OR PQV96 IS NULL) "  );
                strSql . Append ( " UNION ALL " );
                strSql . AppendFormat ( "SELECT A.idx,'车木件采购合同(R_342)' tn,AF003,AF002,AF005,AF001,AF015,CONVERT(VARCHAR,AF020)+'*'+CONVERT(VARCHAR,AF021)+'*'+CONVERT(VARCHAR,AF022) AF,AF006,CASE WHEN AF016='外购' THEN AF017 ELSE AF018 END AF1,PQF31,AF079 FROM R_PQAF A INNER JOIN R_PQF B ON A.AF002=B.PQF01 INNER JOIN R_REVIEWS D ON A.AF001=D.RES06 WHERE  RES05='执行' AND (AF086='' OR AF086 IS NULL) "  );
                strSql . Append ( " UNION ALL " );
                strSql . AppendFormat ( "SELECT A.idx,'五金件(镀、烤漆)采购合同书(R_343)' tn,PQU98,PQU01,PQU99,PQU97,PQU10,PQU12,PQU101,CASE WHEN PQU19='外购' THEN PQU104 ELSE PQU18 END PQU,PQF31,PQU108 FROM R_PQU A INNER JOIN R_PQF B ON A.PQU01=B.PQF01 INNER JOIN R_REVIEWS D ON A.PQU97=D.RES06 WHERE  RES05='执行' AND (PQU114='' OR PQU114 IS NULL) "  );
                strSql . Append ( " UNION ALL " );
                strSql . AppendFormat ( "SELECT A.idx,'滚漆承揽加工成本合同书(R_344)' tn,MZ003,MZ002,MZ004,MZ001,MZ016,MZ018,MZ006,MZ006*MZ021 MZ,PQF31,'' MZ1 FROM R_PQMZ A INNER JOIN R_PQF B ON A.MZ002=B.PQF01 INNER JOIN R_REVIEWS D ON A.MZ001=D.RES06 WHERE RES05='执行' AND (MZ128='' OR MZ128 IS NULL) "  );
                strSql . Append ( " UNION ALL " );
                strSql . AppendFormat ( "SELECT A.idx,'产品塑料、布和其他零配件采购合同(R_347)' tn,PJ93,PJ01,PJ94,PJ92,PJ09,PJ89,PJ96,PJ11*PJ96+PJ10 PJ,PQF31,PJ101 FROM R_PQS A INNER JOIN R_PQF B ON A.PJ01=B.PQF01 INNER JOIN R_REVIEWS D ON A.PJ92=D.RES06 WHERE RES05='执行' AND (PJ108='' OR PJ108 IS NULL) "  );
                strSql . Append ( " UNION ALL " );
                strSql . AppendFormat ( "SELECT A.idx,'外箱、中包、彩盒、纸片（卡）等采购合同(R_349)' tn,WX83,WX01,WX84,WX82,WX10,WX11,WX86,CASE WHEN WX17='外购' THEN WX87 ELSE WX16 END WX,PQF31,WX91 FROM R_PQT  A INNER JOIN R_PQF B ON A.WX01=B.PQF01 INNER JOIN R_REVIEWS D ON A.WX82=D.RES06 WHERE RES05='执行' AND (WX95='' OR WX95 IS NULL) "  );
                strSql . Append ( ")" );
                strSql . Append ( "SELECT * FROM CET WHERE CP01 NOT IN (SELECT DISTINCT AE02 FROM R_PQAE WHERE AE21 IS NOT NULL OR AE21!='')" );
            }
            //strSql . Append ( " UNION ALL " );
            //strSql . AppendFormat ( "SELECT 'R_495' tn,PY30,PY01,PY38,PY33,PY24,PY25,PY27,PY10*PY11 PY,PQF31,PY41 FROM R_PQY A INNER JOIN R_PQF B ON A.PY01=B.PQF01 INNER JOIN R_REVIEWS D ON A.PY33=D.RES06 WHERE CP02='{0}' AND RES05='执行' AND (PY45='' OR PY45 IS NULL) " ,userNum );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }
        
        /// <summary>
        /// 确认实际到货日期
        /// </summary>
        /// <param name="tableNum"></param>
        /// <param name="idx"></param>
        /// <returns></returns>
        public bool UpdateDate ( string tableNum,string idx )
        {
            StringBuilder strSql = new StringBuilder ( );
            if ( tableNum . Contains ( "R_195" ) )
                strSql . AppendFormat ( "UPDATE R_PQQ SET CP61=GETDATE() WHERE idx={0}" ,idx );
            if ( tableNum . Contains ( "R_196" ) )
                strSql . AppendFormat ( "UPDATE R_PQAH SET AH116=GETDATE() WHERE idx={0}" ,idx );
            if ( tableNum . Contains ( "R_199" ) )
                strSql . AppendFormat ( "UPDATE R_PQBA SET BA062=GETDATE() WHERE idx={0}" ,idx );
            if ( tableNum . Contains ( "R_338" ) )
                strSql . AppendFormat ( "UPDATE R_PQO SET JM115=GETDATE() WHERE idx={0}" ,idx );
            //if ( tableNum . Contains ( "R_339" ) )
            //    strSql . AppendFormat ( "UPDATE R_PQI SET YQ137=GETDATE() WHERE idx={0}" ,idx );
            //if ( tableNum . Contains ( "R_337" ) )
            //    strSql . AppendFormat ( "UPDATE R_PQI SET YQ138=GETDATE() WHERE idx={0}" ,idx );
            if ( tableNum . Contains ( "R_341" ) )
                strSql . AppendFormat ( "UPDATE R_PQV SET PQV96=GETDATE() WHERE idx={0}" ,idx );
            if ( tableNum . Contains ( "R_342" ) )
                strSql . AppendFormat ( "UPDATE R_PQAF SET AF086=GETDATE() WHERE idx={0}" ,idx );
            if ( tableNum . Contains ( "R_343" ) )
                strSql . AppendFormat ( "UPDATE R_PQU SET PQU114=GETDATE() WHERE idx={0}" ,idx );
            if ( tableNum . Contains ( "R_344" ) )
                strSql . AppendFormat ( "UPDATE R_PQMZ SET MZ128=GETDATE() WHERE idx={0}" ,idx );
            if ( tableNum . Contains ( "R_347" ) )
                strSql . AppendFormat ( "UPDATE R_PQS SET PJ108=GETDATE() WHERE idx={0}" ,idx );
            if ( tableNum . Contains ( "R_349" ) )
                strSql . AppendFormat ( "UPDATE R_PQT SET WX95=GETDATE() WHERE idx={0}" ,idx );
            
            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 339  337确认到货日期
        /// </summary>
        /// <param name="oddNum"></param>
        /// <returns></returns>
        public bool UpdateDateT ( string tableNum ,string oddNum )
        {
            StringBuilder strSql = new StringBuilder ( );
            if ( tableNum . Contains ( "R_339" ) )
                strSql . AppendFormat ( "UPDATE R_PQI SET YQ137=GETDATE() WHERE YQ99='{0}'" ,oddNum );
            if ( tableNum . Contains ( "R_337" ) )
                strSql . AppendFormat ( "UPDATE R_PQI SET YQ138=GETDATE() WHERE YQ99='{0}'" ,oddNum );

            int rows = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( rows > 0 )
                return true;
            else
                return false;
        }

        /// <summary>
        /// 编辑250生产车间
        /// </summary>
        void updatepqae ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "UPDATE R_PQAE SET AE08=PQF66 FROM R_PQF A INNER JOIN R_PQAE B ON A.PQF01=B.AE02 WHERE AE08=''" );

            SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 获取509存在  合同未开的数据
        /// </summary>
        /// <param name="userNum"></param>
        /// <returns></returns>
        public DataTable getTableForContractAll ( )
        {
            DataTable table,tableOne;
            
            StringBuilder strSql = new StringBuilder ( );
            //338
            strSql . Append ( "WITH CET AS (" );
            strSql . Append ( "select GS70,GS01,GS46,GS49,GS71,GS02,right(GS08,len(GS08) - charindex('*',GS08) ) a from R_PQP  WHERE GS70='R_338' AND GS73='F' " );
            strSql . Append ( "),CFT AS (" );
            strSql . Append ( "SELECT GS70,GS01,GS46,GS49,GS71,GS02,right(a,LEN(a)-charindex('*',a)) GS08 FROM CET " );
            strSql . Append ( " ),CHT AS(" );
            strSql . Append ( " SELECT DISTINCT GS70,GS01,GS46,GS49,GS71,GS02,CONVERT(FLOAT,CONVERT(DECIMAL(11,2),GS08)*1.0/10) GS08 FROM CFT " );
            strSql . Append ( " )SELECT GS70,GS01,GS46,GS49,GS71,GS02,CONVERT(VARCHAR,GS08) GS08,'' GS07,PQF13,PQF31 FROM CHT A INNER JOIN R_PQF B ON A.GS01=B.PQF01  WHERE (SELECT COUNT(1) FROM R_PQO WHERE GS01=JM90 AND GS02=JM09 AND CONVERT(VARCHAR,GS08)=CONVERT(VARCHAR,CONVERT(FLOAT,CONVERT(DECIMAL(11,4),JM96))))=0 and GS01 not in (SELECT JM90 FROM R_PQO WHERE JM116='1' )" );
            table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            
            //341
            strSql = new StringBuilder ( );
            strSql . Append ( " WITH CET AS (" );
            strSql . Append ( " select GS70 ,GS01 ,GS46 ,GS49 ,GS71 ,GS02,GS07 ,right ( GS08 ,len ( GS08 ) - charindex ( '*' ,GS08 ) ) a from R_PQP WHERE GS73='F'" );
            strSql . Append ( "AND GS70 = 'R_341'" );
            strSql . Append ( " ),CFT AS (" );
            strSql . Append ( "SELECT GS70 ,GS01 ,GS46 ,GS49 ,GS71 ,GS02,GS07 ,right( a ,LEN( a ) - charindex ( '*' ,a )) GS08 FROM CET" );
            strSql . Append ( " ) ,CGT AS(" );
            strSql . Append ( " SELECT DISTINCT GS70 ,GS01 ,GS46 ,GS49 ,GS71 ,GS02,GS07 ,CASE WHEN GS08 = '/' OR GS08 = '\' OR GS08='' THEN '0' ELSE GS08 END GS08 " );
            strSql . Append ( "  FROM CFT" );
            strSql . Append ( "  ) ,CHT AS(" );
            strSql . Append ( "  SELECT DISTINCT GS70 ,GS01 ,GS46 ,GS49 ,GS71 ,GS02,GS07 ,CONVERT ( FLOAT ,CONVERT ( DECIMAL ( 11 ,2 ) ,GS08 ) * 1.0 / 10 ) GS08 FROM CGT" );
            strSql . Append ( "  )SELECT GS70, GS01, GS46, GS49, GS71, GS02,CONVERT(VARCHAR,GS08) GS08,GS07,PQF13,PQF31 FROM CHT A INNER JOIN R_PQF B ON A.GS01=B.PQF01 WHERE (SELECT COUNT(1) FROM R_PQV WHERE GS01=PQV01 AND GS02=PQV86 AND PQV10=GS07 AND CONVERT(VARCHAR,GS08) = CONVERT(VARCHAR,CONVERT(FLOAT,PQV73)))=0 and GS01 not in (SELECT PQV01 FROM R_PQV WHERE PQV98='1' )" );
            tableOne = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );

            if ( table != null )
            {
                if ( tableOne != null )
                    table . Merge ( tableOne );
            }
            else
                table = tableOne;

            //342
            strSql = new StringBuilder ( );
            strSql . Append ( "with cet as (" );
            strSql . Append ( "SELECT DISTINCT GS70,GS01,GS46,GS49,GS71,GS02,GS08,GS07,PQF13,PQF31 FROM R_PQP A INNER JOIN R_PQF C ON A.GS01=C.PQF01 WHERE GS70 = 'R_342' AND GS73='F' AND ( SELECT COUNT(1) as num FROM R_PQAF B WHERE A.GS01=B.AF002 AND A.GS07=B.AF015 AND A.GS02=B.AF084 AND A.GS08 ='Φ'+CONVERT(VARCHAR,CONVERT(FLOAT,AF022*10))+'*'+CONVERT(VARCHAR,CONVERT(FLOAT,AF020*10))) = 0 and GS01 not in (SELECT AF002 FROM R_PQAF WHERE AF089='1' )" );
            strSql . Append ( "),cft as (" );
            strSql . Append ( "SELECT DISTINCT GS70,GS01,GS46,GS49,GS71,GS02,GS08,GS07,PQF13,PQF31 FROM R_PQP A INNER JOIN R_PQF C ON A.GS01=C.PQF01 WHERE GS70 = 'R_342' AND GS73='F' AND ( SELECT COUNT(1) as num FROM R_PQAF B WHERE A.GS01=B.AF002 AND A.GS07=B.AF015 AND A.GS02=B.AF084 AND A.GS08 =CONVERT(VARCHAR,CONVERT(FLOAT,AF020*10))+'*'+CONVERT(VARCHAR,CONVERT(FLOAT,AF021*10))+'*'+CONVERT(VARCHAR,CONVERT(FLOAT,AF022*10))) = 0 and GS01 not in (SELECT AF002 FROM R_PQAF WHERE AF089='1'))" );
            strSql . Append ( " select a.* from cet a inner join cft b on a.GS01=b.GS01 and a.GS02=b.GS02 and a.GS07=b.GS07 and a.GS08=b.GS08" );
            tableOne = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );

            if ( table != null )
            {
                if ( tableOne != null )
                    table . Merge ( tableOne );
            }
            else
                table = tableOne;

            //343
            strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT GS70,GS01,GS46,GS49,GS71,GS02,GS08,GS07,PQF13,PQF31 FROM R_PQP A INNER JOIN R_PQF C ON A.GS01=C.PQF01 WHERE GS70='R_343' AND GS73='F' AND (SELECT COUNT(1) as num FROM R_PQU B WHERE A.GS01=B.PQU01 AND A.GS07=B.PQU10 AND A.GS08=PQU12)=0 and GS01 not in (SELECT PQU01 FROM R_PQU WHERE PQU115='1' ) ORDER BY GS01" );
            tableOne = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );

            if ( table != null )
            {
                if ( tableOne != null )
                    table . Merge ( tableOne );
            }
            else
                table = tableOne;

            //347
            strSql = new StringBuilder ( );
            //strSql . Append ( "SELECT DISTINCT GS70,GS01,GS46,GS49,GS71,GS02,GS57 GS08,GS56 GS07,PQF13,PQF31 FROM R_PQP A INNER JOIN R_PQF C ON A.GS01=C.PQF01 WHERE GS70='R_347' AND GS73='F' AND (SELECT COUNT(1) as num FROM R_PQS B WHERE A.GS01=B.PJ01 AND A.GS56=B.PJ09 AND A.GS57=PJ89)=0  and GS01 not in (SELECT PJ01 FROM R_PQS WHERE PJ109='1') ORDER BY GS01" );
            strSql . Append ( "SELECT DISTINCT GS70,GS01,GS46,GS49,GS71,GS02,GS08,GS07,PQF13,PQF31 FROM R_PQP A INNER JOIN R_PQF C ON A.GS01=C.PQF01 WHERE GS70='R_347' AND GS73='F' AND (SELECT COUNT(1) as num FROM R_PQS B WHERE A.GS01=B.PJ01 AND A.GS07=B.PJ09 AND A.GS08=PJ89)=0  and GS01 not in (SELECT PJ01 FROM R_PQS WHERE PJ109='1') ORDER BY GS01" );
            tableOne = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            
            if ( table != null )
            {
                if ( tableOne != null )
                    table . Merge ( tableOne );
            }
            else
                table = tableOne;

            //349
            strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT 'R_349' GS70,GS01,GS46,GS49,GS56 GS71,'' GS02,GS57 GS08,'' GS07,PQF13,PQF31 FROM R_PQP A INNER JOIN R_PQF C ON A.GS01=C.PQF01 WHERE GS56 IS NOT NULL AND GS73='F' AND GS56!='' AND (SELECT COUNT(1) as num FROM R_PQT B WHERE A.GS01=B.WX01 AND A.GS56=B.WX10 AND A.GS57=WX11)=0 and GS01 not in (SELECT WX01 FROM R_PQT WHERE WX96='1') ORDER BY GS01" );// AND GS70 LIKE '%R_349%'
            tableOne = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );

            if ( table != null )
            {
                if ( tableOne != null )
                    table . Merge ( tableOne );
            }
            else
                table = tableOne;

            //195
            strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT 'R_195' GS70,GS01,GS46,GS49,GS35 GS71,'' GS02,'' GS08,'' GS07,PQF13,PQF31  FROM R_PQP A INNER JOIN R_PQF C ON A.GS01=C.PQF01 WHERE  GS73='F' AND GS74='R_195' AND (SELECT COUNT(1) as num FROM R_PQQ B WHERE A.GS01=B.CP01 AND A.GS35=B.CP09)=0  and GS01 not in (SELECT CP01 FROM R_PQQ WHERE CP62='1') ORDER BY GS01" );//AND (GS35 LIKE '%雕刻%' OR GS35  LIKE '%砂皮%')
            tableOne = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );

            if ( table != null )
            {
                if ( tableOne != null )
                    table . Merge ( tableOne );
            }
            else
                table = tableOne;

            //196
            strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT 'R_196' GS70,GS01,GS46,GS49,GS35 GS71,'' GS02,'' GS08,'' GS07,PQF13,PQF31 FROM R_PQP A INNER JOIN R_PQF C ON A.GS01=C.PQF01 WHERE GS73='F' AND GS74='R_196' AND (SELECT COUNT(1) as num FROM R_PQAH B WHERE A.GS01=B.AH01 AND A.GS35=B.AH18)=0  and GS01 not in (SELECT AH01 FROM R_PQAH WHERE AH117='1')  ORDER BY GS01" );
            tableOne = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );

            if ( table != null )
            {
                if ( tableOne != null )
                    table . Merge ( tableOne );
            }
            else
                table = tableOne;

            //339
            strSql = new StringBuilder ( );
            strSql . Append ( "SELECT DISTINCT 'R_339' GS70,GS01,GS46,GS49,GS35 GS71,'' GS02,'' GS08,'' GS07,PQF13,PQF31 FROM R_PQP A INNER JOIN R_PQF C ON A.GS01=C.PQF01 WHERE GS73='F' AND GS35 LIKE '%油漆%' AND GS35 NOT LIKE '%工资%' AND (SELECT COUNT(1) as num FROM R_PQI B WHERE A.GS01=B.YQ03)=0  and GS01 not in (SELECT YQ03 FROM R_PQI WHERE YQ139='1') ORDER BY GS01" );
            tableOne = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );

            if ( table != null )
            {
                if ( tableOne != null )
                    table . Merge ( tableOne );
            }
            else
                table = tableOne;


            return table ;
        }
        
        /// <summary>
        /// 是否已开合同
        /// </summary>
        /// <param name="num"></param>
        /// <param name="tab"></param>
        /// <returns></returns>
        public bool UpdateOver (DataRow row )
        {
            DataTable table;
            //有问题
            string tab = row [ "GS70" ] . ToString ( );
            string num = row [ "GS01" ] . ToString ( );
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            if ( tab . Equals ( "R_195" ) )
            {
                strSql . AppendFormat ( "UPDATE R_PQQ SET CP62='1' WHERE CP01='{0}'" ,num );
                SQLString . Add ( strSql . ToString ( ) );
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE R_PQP SET GS73='T' WHERE GS01='{0}' AND GS35='{1}'" ,num ,row [ "GS71" ] . ToString ( ) );
                SQLString . Add ( strSql . ToString ( ) );
            }
            if ( tab . Equals ( "R_196" ) )
            {
                strSql . AppendFormat ( "UPDATE R_PQAH SET AH117='1' WHERE AH01='{0}'" ,num );
                SQLString . Add ( strSql . ToString ( ) );
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE R_PQP SET GS73='T' WHERE GS01='{0}' AND GS35='{1}'" ,num ,row [ "GS71" ] . ToString ( ) );
                SQLString . Add ( strSql . ToString ( ) );
            }
            if ( tab . Equals ( "R_338" ) )
            {
                strSql . AppendFormat ( "UPDATE R_PQO SET JM116='1' WHERE JM90='{0}'" ,num );
                SQLString . Add ( strSql . ToString ( ) );
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "WITH CET AS(SELECT right(GS08,len(GS08) - charindex('*',GS08) ) a,GS08 FROM R_PQP WHERE GS01='{0}' AND GS02='{1}' )" ,num,row [ "GS02" ] . ToString ( ) );
                strSql . AppendFormat ( ",CFT as(SELECT convert(float,right(a,LEN(a)-charindex('*',a)))*1.0/10 GS8,GS08 FROM CET  WHERE convert(float,right(a,LEN(a)-charindex('*',a)))*1.0/10='{0}')" ,row [ "GS08" ] . ToString ( ) );
                strSql . Append ( "SELECT * FROM CFT " );
                table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                if ( table != null && table . Rows . Count > 0 )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "UPDATE R_PQP SET GS73='T' WHERE GS01='{0}' AND GS02='{1}' AND GS08='{2}' " ,num ,row [ "GS02" ] . ToString ( ) ,table . Rows [ 0 ] [ "GS08" ] . ToString ( ) );
                    SQLString . Add ( strSql . ToString ( ) );
                }
            }
            if ( tab . Equals ( "R_339" ) )
            {
                strSql . AppendFormat ( "UPDATE R_PQI SET YQ139='1' WHERE YQ03='{0}'" ,num );
                SQLString . Add ( strSql . ToString ( ) );
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE R_PQP SET GS73='T' WHERE GS01='{0}' AND GS35='{1}'" ,num ,row [ "GS71" ] . ToString ( ) );
                SQLString . Add ( strSql . ToString ( ) );
            }
            if ( tab . Equals ( "R_341" ) )
            {
                strSql . AppendFormat ( "UPDATE R_PQV SET PQV98='1' WHERE PQV01='{0}'" ,num );
                SQLString . Add ( strSql . ToString ( ) );
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "WITH CET AS (" );
                strSql . AppendFormat ( "select GS70 ,GS01 ,GS46 ,GS49 ,GS71 ,GS02 ,right ( GS08 ,len ( GS08 ) - charindex ( '*' ,GS08 ) ) a,GS08 from R_PQP WHERE GS73='F'  AND GS70 = 'R_341' AND GS01='{0}' AND GS02='{1}'" ,num ,row [ "GS02" ] . ToString ( ) );
                strSql . AppendFormat ( "),CFT AS (SELECT GS70 ,GS01 ,GS46 ,GS49 ,GS71 ,GS02 ,right( a ,LEN( a ) - charindex ( '*' ,a )) GS8,GS08 FROM CET) ,CGT AS(SELECT DISTINCT GS70 ,GS01 ,GS46 ,GS49 ,GS71 ,GS02 ,CASE WHEN GS8 = '/' OR GS8 = '\' OR GS8='' THEN '0' ELSE GS8 END GS8,GS08 FROM CFT) ,CHT AS(SELECT DISTINCT GS70 ,GS01 ,GS46 ,GS49 ,GS71 ,GS02 ,CONVERT ( FLOAT ,CONVERT ( DECIMAL ( 11 ,2 ) ,GS8 ) * 1.0 / 10 ) GS8,GS08 FROM CGT) " );
                strSql . AppendFormat ( "SELECT * FROM CHT " );
                table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                if ( table != null && table . Rows . Count > 0 )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "UPDATE R_PQP SET GS73='T' WHERE GS01='{0}' AND GS02='{1}' AND GS08='{2}' " ,num ,row [ "GS02" ] . ToString ( ) ,table . Rows [ 0 ] [ "GS08" ] . ToString ( ) );
                    SQLString . Add ( strSql . ToString ( ) );
                }

                strSql . AppendFormat ( "UPDATE R_PQP SET GS73='T' WHERE GS01='{0}' AND GS07='{1}' AND GS08='{2}' " ,num ,row [ "GS71" ] . ToString ( ) ,row [ "GS02" ] . ToString ( ) );
                SQLString . Add ( strSql . ToString ( ) );
            }
            if ( tab . Equals ( "R_342" ) )
            {
                strSql . AppendFormat ( "UPDATE R_PQAF SET AF089='1' WHERE AF002='{0}'" ,num );
                SQLString . Add ( strSql . ToString ( ) );
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE R_PQP SET GS73='T' WHERE GS01='{0}' AND GS02='{1}' AND GS08='{2}' " ,num ,row [ "GS02" ] . ToString ( ) ,row [ "GS08" ] . ToString ( ) );
                SQLString . Add ( strSql . ToString ( ) );
            }
            if ( tab . Equals ( "R_343" ) )
            {
                strSql . AppendFormat ( "UPDATE R_PQU SET PQU115='1' WHERE PQU01='{0}'" ,num );
                SQLString . Add ( strSql . ToString ( ) );
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE R_PQP SET GS73='T' WHERE GS01='{0}' AND GS02='{1}' AND GS08='{2}' " ,num ,row [ "GS02" ] . ToString ( ) ,row [ "GS08" ] . ToString ( ) );
                SQLString . Add ( strSql . ToString ( ) );
            }
            if ( tab . Equals ( "R_347" ) )
            {
                strSql . AppendFormat ( "UPDATE R_PQS SET PJ109='1' WHERE PJ01='{0}'" ,num );
                SQLString . Add ( strSql . ToString ( ) );
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE R_PQP SET GS73='T' WHERE GS01='{0}' AND GS02='{1}' AND GS08='{2}' " ,num ,row [ "GS02" ] . ToString ( ) ,row [ "GS08" ] . ToString ( ) );
                SQLString . Add ( strSql . ToString ( ) );
            }
            if ( tab . Equals ( "R_349" ) )
            {
                strSql . AppendFormat ( "UPDATE R_PQT SET WX96='1' WHERE WX01='{0}'" ,num );
                SQLString . Add ( strSql . ToString ( ) );
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "UPDATE R_PQP SET GS73='T' WHERE GS01='{0}' AND GS56='{1}' AND GS57='{2}'" ,num ,row [ "GS71" ] . ToString ( ) ,row [ "GS08" ] . ToString ( ) );
                SQLString . Add ( strSql . ToString ( ) );
            }
            //strSql . AppendFormat ( "UPDATE " );
            return SqlHelper . ExecuteSqlTran ( SQLString );
        }

        /// <summary>
        /// 编辑509中已开合同的GS73='T'
        /// </summary>
        /// <returns></returns>
        public bool UpdateOver ( )
        {
            ArrayList SQLString = new ArrayList ( );
            StringBuilder strSql = new StringBuilder ( );
            //195
            strSql . AppendFormat ( "UPDATE R_PQP SET GS73='T' FROM R_PQQ WHERE GS01=CP01 AND GS35=CP09 AND (GS35  LIKE '%丝印%' OR GS35 LIKE '%雕刻%' OR GS35  LIKE '%砂皮%' OR GS35  LIKE '%走台印%' OR GS35  LIKE '%冲印%') " );
            SQLString . Add ( strSql );
            //196
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQP SET GS73='T' FROM R_PQAH WHERE GS01=AH01 AND GS35=AH18 AND (GS35  LIKE '%丝印%' OR GS35 LIKE '%雕刻%' OR GS35  LIKE '%砂皮%' OR GS35  LIKE '%走台印%' OR GS35  LIKE '%冲印%')" );
            SQLString . Add ( strSql );
            //338
            //strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "WITH CET AS (select GS70,GS01,GS46,GS49,GS71,GS02,right(GS08,len(GS08) - charindex('*',GS08) ) a from R_PQP  WHERE GS70='R_338' AND GS73='F'),CFT AS (SELECT GS70,GS01,GS46,GS49,GS71,GS02,right(a,LEN(a)-charindex('*',a)) GS08 FROM CET),CHT AS(SELECT DISTINCT GS70,GS01,GS46,GS49,GS71,GS02,CONVERT(FLOAT,CONVERT(DECIMAL(11,2),GS08)*1.0/10) GS08 FROM CFT) " );
            //strSql . Append ( "UPDATE R_PQP SET GS73='T' FROM CHT A INNER JOIN R_PQO B ON A.GS01=B.JM90 AND A.GS02=B.JM09 AND CONVERT(VARCHAR,A.GS08)=CONVERT(VARCHAR,CONVERT(FLOAT,CONVERT(DECIMAL(11,4),JM96)))" );
            //SQLString . Add ( strSql );
            //339
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQP SET GS73='T' FROM R_PQI WHERE GS01=YQ03 AND  GS35 LIKE '%油漆%'  AND YQ139='1'" );
            SQLString . Add ( strSql );
            //341
            //strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "WITH CET AS (select GS70 ,GS01 ,GS46 ,GS49 ,GS71 ,GS02 ,right ( GS08 ,len ( GS08 ) - charindex ( '*' ,GS08 ) ) a from R_PQP WHERE GS73='F' AND GS70 = 'R_341'),CFT AS (SELECT GS70 ,GS01 ,GS46 ,GS49 ,GS71 ,GS02 ,right( a ,LEN( a ) - charindex ( '*' ,a )) GS08 FROM CET ) ,CGT AS( SELECT DISTINCT GS70 ,GS01 ,GS46 ,GS49 ,GS71 ,GS02 ,CASE WHEN GS08 = '/' OR GS08 = '\' OR GS08='' THEN '0' ELSE GS08 END GS08  FROM CFT ) ,CHT AS( SELECT DISTINCT GS70 ,GS01 ,GS46 ,GS49 ,GS71 ,GS02 ,CONVERT ( FLOAT ,CONVERT ( DECIMAL ( 11 ,2 ) ,GS08 ) * 1.0 / 10 ) GS08 FROM CGT ) " );
            //strSql . Append ( "UPDATE R_PQP SET GS73='T' FROM CHT A INNER JOIN R_PQV B ON GS01=PQV01 AND GS02=PQV86 AND CONVERT(VARCHAR,GS08) = CONVERT(VARCHAR,CONVERT(FLOAT,PQV73))" );
            //SQLString . Add ( strSql );


            //342
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQP SET GS73='T' FROM R_PQAF WHERE GS01=AF002 AND GS07=AF015 AND GS02=AF084 AND GS08 ='Φ'+CONVERT(VARCHAR,CONVERT(FLOAT,AF022*10))+'*'+CONVERT(VARCHAR,CONVERT(FLOAT,AF020*10)) " );//AND GS70='R_342'
            SQLString . Add ( strSql );

            //343
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQP SET GS73='T' FROM R_PQU WHERE GS01=PQU01 AND GS07=PQU10 AND GS08=PQU12  " );//AND GS70='R_343'
            SQLString . Add ( strSql );

            //347
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQP SET GS73='T' FROM R_PQS WHERE GS01=PJ01 AND GS56=PJ09 AND GS57=PJ89  " );//AND GS70='R_347'
            SQLString . Add ( strSql );

            //349
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "UPDATE R_PQP SET GS73='T' FROM R_PQT WHERE GS01=WX01 AND GS56=WX10 AND GS57=WX11 " );
            SQLString . Add ( strSql );

            return SqlHelper . ExecuteSqlTran ( SQLString );

        }

    }
}
