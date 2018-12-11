using System;
using System . Data;
using System . Data . SqlClient;
using System . Windows . Forms;
using StudentMgr;
using System . Text;
using System . Collections . Generic;

namespace Mulaolao.Class
{
    public class Factory
    {
        private string _ac01;
        private string _ac02;
        private string _ac04;
        private string _ac05;
        private string _ac06;
        private string _ac11;
        private string _ac13;
        private string _ac16;
        private string _ac18;
        private string _ac22;
        private string _ac23;
        private decimal _ac03;
        private decimal _ac10;
        private decimal _ac07;
        private decimal _ac08;
        private decimal _ac09;
        private DateTime _ac12;
        private DateTime _ac14;
        private string _ac25;
        private string _ac28;

        /// <summary>
        /// 单号
        /// </summary>
        public string AC18
        {
            get
            {
                return _ac18;
            }
            set
            {
                _ac18 = value;
            }
        }
        /// <summary>
        /// 使用产品名称
        /// </summary>
        public string AC01
        {
            get
            {
                return _ac01;
            }
            set
            {
                _ac01 = value;
            }
        }
        /// <summary>
        /// 货号
        /// </summary>
        public string AC02
        {
            get
            {
                return _ac02;
            }
            set
            {
                _ac02 = value;
            }
        }
        /// <summary>
        /// 采购库存物资名称
        /// </summary>
        public string AC04
        {
            get
            {
                return _ac04;
            }
            set
            {
                _ac04 = value;
            }
        }
        /// <summary>
        /// 规格
        /// </summary>
        public string AC05
        {
            get
            {
                return _ac05;
            }
            set
            {
                _ac05 = value;
            }
        }
        /// <summary>
        /// 开合同人
        /// </summary>
        public string AC11
        {
            get
            {
                return _ac11;
            }
            set
            {
                _ac11 = value;
            }
        }
        /// <summary>
        /// 采购人
        /// </summary>
        public string AC13
        {
            get
            {
                return _ac13;
            }
            set
            {
                _ac13 = value;
            }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string AC06
        {
            get
            {
                return _ac06;
            }
            set
            {
                _ac06 = value;
            }
        }
        /// <summary>
        /// 计划采购数量
        /// </summary>
        public decimal AC10
        {
            get
            {
                return _ac10;
            }
            set
            {
                _ac10 = value;
            }
        }
        /// <summary>
        /// 计划使用产品数量
        /// </summary>
        public decimal AC03
        {
            get
            {
                return _ac03;
            }
            set
            {
                _ac03 = value;
            }
        }
        /// <summary>
        /// 每套用量
        /// </summary>
        public decimal AC07
        {
            get
            {
                return _ac07;
            }
            set
            {
                _ac07 = value;
            }
        }
        /// <summary>
        /// 每套成本
        /// </summary>
        public decimal AC08
        {
            get
            {
                return _ac08;
            }
            set
            {
                _ac08 = value;
            }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal AC09
        {
            get
            {
                return _ac09;
            }
            set
            {
                _ac09 = value;
            }
        }
        /// <summary>
        /// 开合同时间
        /// </summary>
        public DateTime AC12
        {
            get
            {
                return _ac12;
            }
            set
            {
                _ac12 = value;
            }
        }
        /// <summary>
        /// 采购时间
        /// </summary>
        public DateTime AC14
        {
            get
            {
                return _ac14;
            }
            set
            {
                _ac14 = value;
            }
        }
        /// <summary>
        /// 采购合同单号
        /// </summary>
        public string AC16
        {
            get
            {
                return _ac16;
            }
            set
            {
                _ac16 = value;
            }
        }
        /// <summary>
        /// 生产车间
        /// </summary>
        public string AC22
        {
            get
            {
                return _ac22;
            }
            set
            {
                _ac22 = value;
            }
        }
        /// <summary>
        /// 341规格
        /// </summary>
        public string AC23
        {
            get
            {
                return _ac23;
            }
            set
            {
                _ac23 = value;
            }
        }
        /// <summary>
        /// 供应商
        /// </summary>
        public string AC25
        {
            get
            {
                return _ac25;
            }
            set
            {
                _ac25 = value;
            }
        }
        /// <summary>
        /// 供方联系人
        /// </summary>
        public string AC28
        {
            get
            {
                return _ac28;
            }
            set
            {
                _ac28 = value;
            }

        }

        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="productName">使用产品名称</param>
        /// <param name="number">货号</param>
        /// <param name="productQuantity">计划使用产品数量</param>
        /// <param name="materialName">采购库存物资名称</param>
        /// <param name="specification">规格</param>
        /// <param name="company">单位</param>
        /// <param name="consumptionPerSet">每套用量</param>
        /// <param name="conPerSet">每套成本</param>
        /// <param name="unitPrice">单价</param>
        /// <param name="purchaseQuantity">计划采购数量</param>
        /// <param name="closeColleagues">开合同人</param>
        /// <param name="contractTime">开合同时间==审核提交日期</param>
        /// <param name="purchaser">采购人</param>
        /// <param name="procurementTime">采购时间==计划采购入库时间</param>
        /// <param name="purchaseContractNumber">采购合同单号</param>
        /// <param name="proWork">生产车间</param>
        /// <param name="supplier">供应商</param>
        /// <returns></returns>  338
        public bool Storage ( string productName ,string number ,string productQuantity ,string materialName ,string specification ,string company ,string consumptionPerSet ,string conPerSet ,string unitPrice ,string purchaseQuantity ,string closeColleagues ,DateTime contractTime ,string purchaser ,DateTime procurementTime ,string purchaseContractNumber ,string translateNum ,string translatePurchas ,string proWork,string supplier,string useForA)
        {
            StringBuilder strSql = new StringBuilder ( );
            int count = 0;
            AC18 = oddNumbers.purchaseContract( "SELECT MAX(AC18) AC18 FROM R_PQAC" ,"AC18" ,"R_464-" );
            AC01 = productName;
            AC02 = number;
            if ( string.IsNullOrEmpty( productQuantity ) )
                AC03 = 0;
            else
                AC03 = Convert.ToDecimal( productQuantity );
            AC04 = materialName;
            AC05 = specification;
            AC06 = company;
            if ( string.IsNullOrEmpty( consumptionPerSet ) )
                AC07 = 0;
            else
                AC07 = Convert.ToDecimal( consumptionPerSet );
            if ( string.IsNullOrEmpty( conPerSet ) )
                AC08 = 0;
            else
                AC08 = Convert.ToDecimal( conPerSet );
            if ( string.IsNullOrEmpty( unitPrice ) )
                AC09 = 0;
            else
                AC09 = Convert.ToDecimal( unitPrice );
            if ( string.IsNullOrEmpty( purchaseQuantity ) )
                AC10 = 0;
            else
                AC10 = Math.Round( Convert.ToDecimal( purchaseQuantity ) ,0 );
            AC11 = closeColleagues;
            AC12 = contractTime;
            AC13 = purchaser;
            AC14 = procurementTime;
            AC16 = purchaseContractNumber;
            AC22 = proWork;
            AC25 = supplier;
            AC28 = useForA;

            DataTable nullOrOddNum = SqlHelper.ExecuteDataTable( "SELECT AC16,AC18,AC03,AC10 FROM R_PQAC WHERE AC16 LIKE '%" + AC16 + "%' AND AC02='" + AC02 + "' AND AC04='" + AC04 + "' AND AC05='" + AC05 + "' AND AC06='" + AC06 + "'" );
            if ( nullOrOddNum != null && nullOrOddNum.Rows.Count > 0 )
            {
                if ( string.IsNullOrEmpty( nullOrOddNum.Rows[0]["AC16"].ToString( ) ) )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "INSERT INTO R_PQAC (AC18,AC01,AC02,AC03,AC04,AC05,AC06,AC07,AC08,AC09,AC10,AC11,AC12,AC13,AC14,AC16,AC22,AC25,AC28) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}')" ,AC18 ,AC01 ,AC02 ,AC03 ,AC04 ,AC05 ,AC06 ,AC07 ,AC08 ,AC09 ,AC10 ,AC11 ,AC12 ,AC13 ,AC14 ,AC16 ,AC22 ,AC25 ,AC28 );
                    count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                    if ( count < 1 )
                        //MessageBox.Show( "入库失败" );
                        result = false;
                    else
                    {
                        result = true;
                        try
                        {
                            SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( Logins . tableNum ,Logins . tableName ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,AD17 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"入库" ,"入库" ) );
                        }
                        catch
                        {

                        }
                    }
                }
                else
                {
                    AC18 = nullOrOddNum.Rows[0]["AC18"].ToString( );
                    if ( nullOrOddNum.Rows[0]["AC16"].ToString( ).Contains( "," ) )
                    {
                        if ( !string.IsNullOrEmpty( translateNum ) )
                        {
                            AC03 = AC03 - Convert.ToInt64( translateNum );
                            if ( !string.IsNullOrEmpty( nullOrOddNum.Rows[0]["AC03"].ToString( ) ) )
                                AC03 = AC03 + Convert.ToDecimal( nullOrOddNum.Rows[0]["AC03"].ToString( ) );
                        }
                        else
                        {
                            if ( !string.IsNullOrEmpty( nullOrOddNum.Rows[0]["AC03"].ToString( ) ) )
                                AC03 = Convert.ToDecimal( nullOrOddNum.Rows[0]["AC03"].ToString( ) );
                        }
                        if ( !string.IsNullOrEmpty( translatePurchas ) )
                        {
                            AC10 = AC10 - Convert.ToDecimal( translatePurchas );
                            if ( !string.IsNullOrEmpty( nullOrOddNum.Rows[0]["AC10"].ToString( ) ) )
                                AC10 = AC10 + Convert.ToDecimal( nullOrOddNum.Rows[0]["AC10"].ToString( ) );
                        }
                        else
                        {
                            if ( !string.IsNullOrEmpty( nullOrOddNum.Rows[0]["AC10"].ToString( ) ) )
                                AC10 = Convert.ToDecimal( nullOrOddNum.Rows[0]["AC10"].ToString( ) );
                        }
                        strSql = new StringBuilder ( );
                        strSql . AppendFormat ( "UPDATE R_PQAC SET AC03='{0}',AC10='{1}',AC09='{2}' WHERE AC18='{3}'" ,AC03 ,AC10 ,AC09 ,AC18 );
                        count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                        if ( count < 1 )
                            //MessageBox.Show( "入库失败" );
                            result = false;
                        else
                        {
                            result = true;
                            try
                            {
                                SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( Logins . tableNum ,Logins . tableName ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,AD17 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"入库" ,"入库" ) );
                            }
                            catch
                            {

                            }
                        }
                    }
                    else
                    {
                        strSql = new StringBuilder ( );
                        strSql . AppendFormat ( "UPDATE R_PQAC SET AC03='{0}',AC10='{1}',AC09='{2}' WHERE AC18='{3}'" ,AC03 ,AC10 ,AC09 ,AC18 );
                        count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                        if ( count < 1 )
                            //MessageBox.Show( "入库失败" );
                            result = false;
                        else
                        {
                            result = true;
                            try
                            {
                                SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( Logins . tableNum ,Logins . tableName ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,AD17 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"入库" ,"入库" ) );
                            }
                            catch
                            {

                            }
                        }
                    }
                }
            }
            else
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "INSERT INTO R_PQAC (AC18,AC01,AC02,AC03,AC04,AC05,AC06,AC07,AC08,AC09,AC10,AC11,AC12,AC13,AC14,AC16,AC22,AC25,AC28) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}')" ,AC18 ,AC01 ,AC02 ,AC03 ,AC04 ,AC05 ,AC06 ,AC07 ,AC08 ,AC09 ,AC10 ,AC11 ,AC12 ,AC13 ,AC14 ,AC16 ,AC22 ,AC25 ,AC28 );

                count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                if ( count < 1 )
                    //MessageBox.Show( "入库失败" );
                    result = false;
                else
                {
                    result = true;
                    try
                    {
                        SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( Logins . tableNum ,Logins . tableName ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,AD17 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"入库" ,"入库" ) );
                    }
                    catch
                    {

                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="productName">使用产品名称</param>
        /// <param name="number">货号</param>
        /// <param name="productQuantity">计划使用产品数量</param>
        /// <param name="materialName">采购库存物资名称</param>
        /// <param name="specification">规格</param>
        /// <param name="company">单位</param>
        /// <param name="consumptionPerSet">每套用量</param>
        /// <param name="conPerSet">每套成本</param>
        /// <param name="unitPrice">单价</param>
        /// <param name="purchaseQuantity">计划采购数量</param>
        /// <param name="closeColleagues">开合同人</param>
        /// <param name="contractTime">开合同时间==审核提交日期</param>
        /// <param name="purchaser">采购人</param>
        /// <param name="procurementTime">采购时间==计划采购入库时间</param>
        /// <param name="purchaseContractNumber">采购合同单号</param>
        /// <param name="proWork">生产车间</param>
        /// <param name="supplier">供应商</param>
        /// <param name="uerForA">供方联系人</param>
        /// <returns></returns>  338
        public bool Storage338 ( string productName ,string number ,string productQuantity ,string materialName ,string specification ,string company ,string consumptionPerSet ,string conPerSet ,string unitPrice ,string purchaseQuantity ,string closeColleagues ,DateTime contractTime ,string purchaser ,DateTime procurementTime ,string purchaseContractNumber ,string translateNum ,string translatePurchas ,string proWork ,string supplier,string uerForA)
        {
            StringBuilder strSql = new StringBuilder ( );
            int count = 0;
            AC18 = oddNumbers . purchaseContract ( "SELECT MAX(AC18) AC18 FROM R_PQAC" ,"AC18" ,"R_464-" );
            AC01 = productName;
            AC02 = number;
            if ( string . IsNullOrEmpty ( productQuantity ) )
                AC03 = 0;
            else
                AC03 = Convert . ToDecimal ( productQuantity );
            AC04 = materialName;
            AC05 = specification;
            AC06 = company;
            if ( string . IsNullOrEmpty ( consumptionPerSet ) )
                AC07 = 0;
            else
                AC07 = Convert . ToDecimal ( consumptionPerSet );
            if ( string . IsNullOrEmpty ( conPerSet ) )
                AC08 = 0;
            else
                AC08 = Convert . ToDecimal ( conPerSet );
            if ( string . IsNullOrEmpty ( unitPrice ) )
                AC09 = 0;
            else
                AC09 = Convert . ToDecimal ( unitPrice );
            if ( string . IsNullOrEmpty ( purchaseQuantity ) )
                AC10 = 0;
            else
                AC10 = Math . Round ( Convert . ToDecimal ( purchaseQuantity ) ,0 );
            AC11 = closeColleagues;
            AC12 = contractTime;
            AC13 = purchaser;
            AC14 = procurementTime;
            AC16 = purchaseContractNumber;
            AC22 = proWork;
            AC25 = supplier;
            AC28 = uerForA;

            DataTable nullOrOddNum = SqlHelper . ExecuteDataTable ( "SELECT AC16,AC18,AC03,AC10 FROM R_PQAC WHERE AC16 LIKE '%" + AC16 + "%' AND AC04='" + AC04 + "' AND AC05='" + AC05 + "'" );
            if ( nullOrOddNum != null && nullOrOddNum . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( nullOrOddNum . Rows [ 0 ] [ "AC16" ] . ToString ( ) ) )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "INSERT INTO R_PQAC (AC18,AC01,AC02,AC03,AC04,AC05,AC06,AC07,AC08,AC09,AC10,AC11,AC12,AC13,AC14,AC16,AC22,AC25,AC28) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}')" ,AC18 ,AC01 ,AC02 ,AC03 ,AC04 ,AC05 ,AC06 ,AC07 ,AC08 ,AC09 ,AC10 ,AC11 ,AC12 ,AC13 ,AC14 ,AC16 ,AC22 ,AC25 ,AC28 );
                    count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                    if ( count < 1 )
                        //MessageBox.Show( "入库失败" );
                        result = false;
                    else
                    {
                        result = true;
                        try
                        {
                            SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( Logins . tableNum ,Logins . tableName ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,AD17 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"入库" ,"入库" ) );
                        }
                        catch
                        {

                        }
                    }
                }
                else
                {
                    AC18 = nullOrOddNum . Rows [ 0 ] [ "AC18" ] . ToString ( );
                    if ( nullOrOddNum . Rows [ 0 ] [ "AC16" ] . ToString ( ) . Contains ( "," ) )
                    {
                        if ( !string . IsNullOrEmpty ( translateNum ) )
                        {
                            AC03 = AC03 - Convert . ToInt64 ( translateNum );
                            if ( !string . IsNullOrEmpty ( nullOrOddNum . Rows [ 0 ] [ "AC03" ] . ToString ( ) ) )
                                AC03 = AC03 + Convert . ToDecimal ( nullOrOddNum . Rows [ 0 ] [ "AC03" ] . ToString ( ) );
                        }
                        else
                        {
                            if ( !string . IsNullOrEmpty ( nullOrOddNum . Rows [ 0 ] [ "AC03" ] . ToString ( ) ) )
                                AC03 = Convert . ToDecimal ( nullOrOddNum . Rows [ 0 ] [ "AC03" ] . ToString ( ) );
                        }
                        if ( !string . IsNullOrEmpty ( translatePurchas ) )
                        {
                            AC10 = AC10 - Convert . ToDecimal ( translatePurchas );
                            if ( !string . IsNullOrEmpty ( nullOrOddNum . Rows [ 0 ] [ "AC10" ] . ToString ( ) ) )
                                AC10 = AC10 + Convert . ToDecimal ( nullOrOddNum . Rows [ 0 ] [ "AC10" ] . ToString ( ) );
                        }
                        else
                        {
                            if ( !string . IsNullOrEmpty ( nullOrOddNum . Rows [ 0 ] [ "AC10" ] . ToString ( ) ) )
                                AC10 = Convert . ToDecimal ( nullOrOddNum . Rows [ 0 ] [ "AC10" ] . ToString ( ) );
                        }
                        strSql = new StringBuilder ( );
                        strSql . AppendFormat ( "UPDATE R_PQAC SET AC03='{0}',AC10='{1}',AC09='{2}' WHERE AC18='{3}'" ,AC03 ,AC10 ,AC09 ,AC18 );
                        count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                        if ( count < 1 )
                            //MessageBox.Show( "入库失败" );
                            result = false;
                        else
                        {
                            result = true;
                            try
                            {
                                SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( Logins . tableNum ,Logins . tableName ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,AD17 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"入库" ,"入库" ) );
                            }
                            catch
                            {

                            }
                        }
                    }
                    else
                    {
                        strSql = new StringBuilder ( );
                        strSql . AppendFormat ( "UPDATE R_PQAC SET AC03='{0}',AC10='{1}',AC09='{2}' WHERE AC18='{3}'" ,AC03 ,AC10 ,AC09 ,AC18 );
                        count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                        if ( count < 1 )
                            //MessageBox.Show( "入库失败" );
                            result = false;
                        else
                        {
                            result = true;
                            try
                            {
                                SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( Logins . tableNum ,Logins . tableName ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,AD17 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"入库" ,"入库" ) );
                            }
                            catch
                            {

                            }
                        }
                    }
                }
            }
            else
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "INSERT INTO R_PQAC (AC18,AC01,AC02,AC03,AC04,AC05,AC06,AC07,AC08,AC09,AC10,AC11,AC12,AC13,AC14,AC16,AC22,AC25,AC28) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}')" ,AC18 ,AC01 ,AC02 ,AC03 ,AC04 ,AC05 ,AC06 ,AC07 ,AC08 ,AC09 ,AC10 ,AC11 ,AC12 ,AC13 ,AC14 ,AC16 ,AC22 ,AC25 ,AC28 );

                count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                if ( count < 1 )
                    //MessageBox.Show( "入库失败" );
                    result = false;
                else
                {
                    result = true;
                    try
                    {
                        SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( Logins . tableNum ,Logins . tableName ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,AD17 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"入库" ,"入库" ) );
                    }
                    catch
                    {

                    }
                }
            }
            return result;
        }

        bool result = false;

        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="productName">使用产品名称</param>
        /// <param name="number">货号</param>
        /// <param name="productQuantity">计划使用产品数量</param>
        /// <param name="materialName">采购库存物资名称</param>
        /// <param name="specification">规格</param>
        /// <param name="company">单位</param>
        /// <param name="consumptionPerSet">每套用量</param>
        /// <param name="conPerSet">每套成本</param>
        /// <param name="unitPrice">单价</param>
        /// <param name="purchaseQuantity">计划采购数量</param>
        /// <param name="closeColleagues">开合同人</param>
        /// <param name="contractTime">开合同时间==审核提交日期</param>
        /// <param name="purchaser">采购人</param>
        /// <param name="procurementTime">采购时间==计划采购入库时间</param>
        /// <param name="purchaseContractNumber">采购合同单号</param>
        /// <returns></returns>
        public bool StorageThrFouOne ( string productName ,string number ,string productQuantity ,string materialName ,string specification ,string company ,string consumptionPerSet ,string conPerSet ,string unitPrice ,string purchaseQuantity ,string closeColleagues ,DateTime contractTime ,string purchaser ,DateTime procurementTime ,string purchaseContractNumber ,string translateNum ,string translatePurchas )
        {
            StringBuilder strSql = new StringBuilder ( );

            int count = 0;
            AC18 = oddNumbers.purchaseContract( "SELECT MAX(AC18) AC18 FROM R_PQAC" ,"AC18" ,"R_464-" );
            AC01 = productName;
            AC02 = number;
            if ( string.IsNullOrEmpty( productQuantity ) )
                AC03 = 0;
            else
                AC03 = Convert.ToDecimal( productQuantity );
            AC04 = materialName;
            AC05 = specification;
            AC06 = company;
            if ( string.IsNullOrEmpty( consumptionPerSet ) )
                AC07 = 0;
            else
                AC07 = Convert.ToDecimal( consumptionPerSet );
            if ( string.IsNullOrEmpty( conPerSet ) )
                AC08 = 0;
            else
                AC08 = Convert.ToDecimal( conPerSet );
            if ( string.IsNullOrEmpty( unitPrice ) )
                AC09 = 0;
            else
                AC09 = Convert.ToDecimal( unitPrice );
            if ( string.IsNullOrEmpty( purchaseQuantity ) )
                AC10 = 0;
            else
                AC10 = Math.Round( Convert.ToDecimal( purchaseQuantity ) ,4 );
            AC11 = closeColleagues;
            AC12 = contractTime;
            AC13 = purchaser;
            AC14 = procurementTime;
            AC16 = purchaseContractNumber;

            DataTable nullOrCount = SqlHelper.ExecuteDataTable( "SELECT AC18,AC16,AC03,AC10 FROM R_PQAC WHERE AC16 LIKE '%" + AC16 + "%' AND AC02='" + AC02 + "' AND  AC04='" + AC04 + "' AND AC05='" + AC05 + "' " );
            if ( nullOrCount != null && nullOrCount.Rows.Count > 0 )
            {
                if ( string.IsNullOrEmpty( nullOrCount.Rows[0]["AC16"].ToString( ) ) )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "INSERT INTO R_PQAC (AC18,AC01,AC02,AC03,AC04,AC05,AC06,AC07,AC08,AC09,AC10,AC11,AC12,AC13,AC14,AC16) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')" ,AC18 ,AC01 ,AC02 ,AC03 ,AC04 ,AC05 ,AC06 ,AC07 ,AC08 ,AC09 ,AC10 ,AC11 ,AC12 ,AC13 ,AC14 ,AC16 );

                    count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                    if ( count < 1 )
                        //MessageBox.Show( "入库失败" );
                        result = false;
                    else
                    {
                        result = true;
                        try
                        {
                            SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( Logins . tableNum ,Logins . tableName ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,AD17 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"入库" ,"入库" ) );
                        }
                        catch
                        {

                        }
                    }
                }
                else
                {
                    AC18 = nullOrCount.Rows[0]["AC18"].ToString( );
                    if ( nullOrCount.Rows[0]["AC16"].ToString( ).Contains( "," ) )
                    {
                        if ( !string.IsNullOrEmpty( translateNum ) )
                        {
                            AC03 = AC03 - Convert.ToInt64( translateNum );
                            if ( !string.IsNullOrEmpty( nullOrCount.Rows[0]["AC03"].ToString( ) ) )
                                AC03 = AC03 + Convert.ToDecimal( nullOrCount.Rows[0]["AC03"].ToString( ) );
                        }
                        else
                        {
                            if ( !string.IsNullOrEmpty( nullOrCount.Rows[0]["AC03"].ToString( ) ) )
                                AC03 = Convert.ToDecimal( nullOrCount.Rows[0]["AC03"].ToString( ) );
                        }
                        if ( !string.IsNullOrEmpty( translatePurchas ) )
                        {
                            AC10 = AC10 - Convert.ToDecimal( translatePurchas );
                            if ( !string.IsNullOrEmpty( nullOrCount.Rows[0]["AC10"].ToString( ) ) )
                                AC10 = AC10 + Convert.ToDecimal( nullOrCount.Rows[0]["AC10"].ToString( ) );
                        }
                        else
                        {
                            if ( !string.IsNullOrEmpty( nullOrCount.Rows[0]["AC10"].ToString( ) ) )
                                AC10 = Convert.ToDecimal( nullOrCount.Rows[0]["AC10"].ToString( ) );
                        }
                        strSql = new StringBuilder ( );
                        strSql . AppendFormat ( "UPDATE R_PQAC SET AC03='{0}',AC10='{1}' WHERE AC18='{2}'" ,AC03 ,AC10 ,AC18 );
                        count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                        if ( count < 1 )
                            //MessageBox.Show( "入库失败" );
                            result = false;
                        else
                        {
                            result = true;
                            try
                            {
                                SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( Logins . tableNum ,Logins . tableName ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,AD17 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"入库" ,"入库" ) );
                            }
                            catch
                            {

                            }
                        }
                    }
                    else
                    {
                        strSql = new StringBuilder ( );
                        strSql . AppendFormat ( "UPDATE R_PQAC SET AC03='{0}',AC10='{1}',AC09='{2}' WHERE AC18='{3}'" ,AC03 ,AC10 ,AC09 ,AC18 );
                        count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                        if ( count < 1 )
                            //MessageBox.Show( "入库失败" );
                            result = false;
                        else
                        {
                            result = true;
                            try
                            {
                                SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( Logins . tableNum ,Logins . tableName ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,AD17 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"入库" ,"入库" ) );
                            }
                            catch
                            {

                            }
                        }
                    }
                }
            }
            else
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "INSERT INTO R_PQAC (AC18,AC01,AC02,AC03,AC04,AC05,AC06,AC07,AC08,AC09,AC10,AC11,AC12,AC13,AC14,AC16) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')" ,AC18 ,AC01 ,AC02 ,AC03 ,AC04 ,AC05 ,AC06 ,AC07 ,AC08 ,AC09 ,AC10 ,AC11 ,AC12 ,AC13 ,AC14 ,AC16 );
                count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                if ( count < 1 )
                    //MessageBox.Show( "入库失败" );
                    result = false;
                else
                {
                    result = true;
                    try
                    {
                        SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( Logins . tableNum ,Logins . tableName ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,AD17 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"入库" ,"入库" ) );
                    }
                    catch
                    {

                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 入库
        /// </summary>
        /// <param name="productName">使用产品名称</param>
        /// <param name="number">货号</param>
        /// <param name="productQuantity">计划使用产品数量</param>
        /// <param name="materialName">采购库存物资名称</param>
        /// <param name="specification">规格</param>
        /// <param name="company">单位</param>
        /// <param name="consumptionPerSet">每套用量</param>
        /// <param name="conPerSet">每套成本</param>
        /// <param name="unitPrice">单价</param>
        /// <param name="purchaseQuantity">计划采购数量</param>
        /// <param name="closeColleagues">开合同人</param>
        /// <param name="contractTime">开合同时间==审核提交日期</param>
        /// <param name="purchaser">采购人</param>
        /// <param name="procurementTime">采购时间==计划采购入库时间</param>
        /// <param name="purchaseContractNumber">采购合同单号</param>
        /// <param name="proWork">生产车间</param>
        /// <param name="supplier">供应商</param>
        /// <returns></returns>
        public bool StorageThrFouOne341 ( string productName ,string number ,string productQuantity ,string materialName ,string specification ,string company ,string consumptionPerSet ,string conPerSet ,string unitPrice ,string purchaseQuantity ,string closeColleagues ,DateTime contractTime ,string purchaser ,DateTime procurementTime ,string purchaseContractNumber ,string translateNum ,string translatePurchas,string proWork ,string guige ,string supplier ,string useForA)
        {
            StringBuilder strSql = new StringBuilder ( );
            
            int count = 0;
            AC18 = oddNumbers . purchaseContract ( "SELECT MAX(AC18) AC18 FROM R_PQAC" ,"AC18" ,"R_464-" );
            AC01 = productName;
            AC02 = number;
            if ( string . IsNullOrEmpty ( productQuantity ) )
                AC03 = 0;
            else
                AC03 = Convert . ToDecimal ( productQuantity );
            AC04 = materialName;
            AC05 = specification;
            AC06 = company;
            if ( string . IsNullOrEmpty ( consumptionPerSet ) )
                AC07 = 0;
            else
                AC07 = Convert . ToDecimal ( consumptionPerSet );
            if ( string . IsNullOrEmpty ( conPerSet ) )
                AC08 = 0;
            else
                AC08 = Convert . ToDecimal ( conPerSet );
            if ( string . IsNullOrEmpty ( unitPrice ) )
                AC09 = 0;
            else
                AC09 = Convert . ToDecimal ( unitPrice );
            if ( string . IsNullOrEmpty ( purchaseQuantity ) )
                AC10 = 0;
            else
                AC10 = Math . Round ( Convert . ToDecimal ( purchaseQuantity ) ,4 );
            AC11 = closeColleagues;
            AC12 = contractTime;
            AC13 = purchaser;
            AC14 = procurementTime;
            AC16 = purchaseContractNumber;
            AC22 = proWork;
            AC23 = guige;
            AC25 = supplier;
            AC28 = useForA;

            DataTable nullOrCount = SqlHelper . ExecuteDataTable ( "SELECT AC18,AC16,AC03,AC10 FROM R_PQAC WHERE AC16 LIKE '%" + AC16 + "%' AND AC02='" + AC02 + "' AND  AC04='" + AC04 + "' AND AC05='" + AC05 + "' " );  //AND AC23='" + AC23 + "'
            if ( nullOrCount != null && nullOrCount . Rows . Count > 0 )
            {
                if ( string . IsNullOrEmpty ( nullOrCount . Rows [ 0 ] [ "AC16" ] . ToString ( ) ) )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "INSERT INTO R_PQAC (AC18,AC01,AC02,AC03,AC04,AC05,AC06,AC07,AC08,AC09,AC10,AC11,AC12,AC13,AC14,AC16,AC22,AC23,AC25,AC28) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}')" ,AC18 ,AC01 ,AC02 ,AC03 ,AC04 ,AC05 ,AC06 ,AC07 ,AC08 ,AC09 ,AC10 ,AC11 ,AC12 ,AC13 ,AC14 ,AC16 ,AC22 ,AC23 ,AC25 ,AC28 );
                    
                    count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                    if ( count < 1 )
                        //MessageBox.Show( "入库失败" );
                        result = false;
                    else
                    {
                        result = true;
                        try
                        {
                            SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( Logins . tableNum ,Logins . tableName ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,AD17 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"入库" ,"入库" ) );
                        }
                        catch
                        {

                        }
                    }
                }
                else
                {
                    AC18 = nullOrCount . Rows [ 0 ] [ "AC18" ] . ToString ( );
                    if ( nullOrCount . Rows [ 0 ] [ "AC16" ] . ToString ( ) . Contains ( "," ) )
                    {
                        if ( !string . IsNullOrEmpty ( translateNum ) )
                        {
                            AC03 = AC03 - Convert . ToInt64 ( translateNum );
                            if ( !string . IsNullOrEmpty ( nullOrCount . Rows [ 0 ] [ "AC03" ] . ToString ( ) ) )
                                AC03 = AC03 + Convert . ToDecimal ( nullOrCount . Rows [ 0 ] [ "AC03" ] . ToString ( ) );
                        }
                        else
                        {
                            if ( !string . IsNullOrEmpty ( nullOrCount . Rows [ 0 ] [ "AC03" ] . ToString ( ) ) )
                                AC03 = Convert . ToDecimal ( nullOrCount . Rows [ 0 ] [ "AC03" ] . ToString ( ) );
                        }
                        if ( !string . IsNullOrEmpty ( translatePurchas ) )
                        {
                            AC10 = AC10 - Convert . ToDecimal ( translatePurchas );
                            if ( !string . IsNullOrEmpty ( nullOrCount . Rows [ 0 ] [ "AC10" ] . ToString ( ) ) )
                                AC10 = AC10 + Convert . ToDecimal ( nullOrCount . Rows [ 0 ] [ "AC10" ] . ToString ( ) );
                        }
                        else
                        {
                            if ( !string . IsNullOrEmpty ( nullOrCount . Rows [ 0 ] [ "AC10" ] . ToString ( ) ) )
                                AC10 = Convert . ToDecimal ( nullOrCount . Rows [ 0 ] [ "AC10" ] . ToString ( ) );
                        }
                        strSql = new StringBuilder ( );
                        strSql . AppendFormat ( "UPDATE R_PQAC SET AC03='{0}',AC10='{1}' WHERE AC18='{2}'" ,AC03 ,AC10 ,AC18 );
                        count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                        if ( count < 1 )
                            //MessageBox.Show( "入库失败" );
                            result = false;
                        else
                        {
                            result = true;
                            try
                            {
                                SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( Logins . tableNum ,Logins . tableName ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,AD17 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"入库" ,"入库" ) );
                            }
                            catch
                            {

                            }
                        }
                    }
                    else
                    {
                        strSql = new StringBuilder ( );
                        strSql . AppendFormat ( "UPDATE R_PQAC SET AC03='{0}',AC10='{1}',AC09='{2}' WHERE AC18='{3}'" ,AC03 ,AC10 ,AC09 ,AC18 );
                        count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                        if ( count < 1 )
                            //MessageBox.Show( "入库失败" );
                            result = false;
                        else
                        {
                            result = true;
                            try
                            {
                                SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( Logins . tableNum ,Logins . tableName ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,AD17 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"入库" ,"入库" ) );
                            }
                            catch
                            {

                            }
                        }
                    }

                }
            }
            else
            {
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "INSERT INTO R_PQAC (AC18,AC01,AC02,AC03,AC04,AC05,AC06,AC07,AC08,AC09,AC10,AC11,AC12,AC13,AC14,AC16,AC22,AC23,AC25,AC28) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}')" ,AC18 ,AC01 ,AC02 ,AC03 ,AC04 ,AC05 ,AC06 ,AC07 ,AC08 ,AC09 ,AC10 ,AC11 ,AC12 ,AC13 ,AC14 ,AC16 ,AC22 ,AC23 ,AC25 ,AC28 );
                count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                if ( count < 1 )
                    //MessageBox.Show( "入库失败" );
                    result = false;
                else
                {
                    result = true;
                    try
                    {
                        SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( Logins . tableNum ,Logins . tableName ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,AD17 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"入库" ,"入库" ) );
                    }
                    catch
                    {

                    }
                }
            }
            return result;
        }

        private string _ad01;
        private string _ad02;
        private string _ad03;
        private string _ad04;
        private string _ad06;
        private string _ad07;
        private string _ad08;
        private string _ad14;
        private string _ad15;
        private string _ad17;
        private string _ad18;
        private decimal _ad05;
        private decimal _ad12;
        private decimal _ad09;
        private decimal _ad10;
        private decimal _ad11;
        private DateTime _ad13;
        private DateTime _ad16;

        /// <summary>
        /// 单号
        /// </summary>
        public string AD01
        {
            get
            {
                return _ad01;
            }
            set
            {
                _ad01 = value;
            }
        }
        /// <summary>
        /// 产品名称
        /// </summary>
        public string AD02
        {
            get
            {
                return _ad02;
            }
            set
            {
                _ad02 = value;
            }
        }
        /// <summary>
        /// 货号
        /// </summary>
        public string AD03
        {
            get
            {
                return _ad03;
            }
            set
            {
                _ad03 = value;
            }
        }
        /// <summary>
        /// 流水号
        /// </summary>
        public string AD04
        {
            get
            {
                return _ad04;
            }
            set
            {
                _ad04 = value;
            }
        }
        /// <summary>
        /// 实领物资名称
        /// </summary>
        public string AD06
        {
            get
            {
                return _ad06;
            }
            set
            {
                _ad06 = value;
            }
        }
        /// <summary>
        /// 规格
        /// </summary>
        public string AD07
        {
            get
            {
                return _ad07;
            }
            set
            {
                _ad07 = value;
            }
        }
        /// <summary>
        /// 单位
        /// </summary>
        public string AD08
        {
            get
            {
                return _ad08;
            }
            set
            {
                _ad08 = value;
            }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string AD14
        {
            get
            {
                return _ad14;
            }
            set
            {
                _ad14 = value;
            }
        }
        /// <summary>
        /// 审核人
        /// </summary>
        public string AD15
        {
            get
            {
                return _ad15;
            }
            set
            {
                _ad15 = value;
            }
        }
        /// <summary>
        /// 实领使用产品数量
        /// </summary>
        public decimal AD05
        {
            get
            {
                return _ad05;
            }
            set
            {
                _ad05 = value;
            }
        }
        /// <summary>
        /// 实领数量
        /// </summary>
        public decimal AD12
        {
            get
            {
                return _ad12;
            }
            set
            {
                _ad12 = value;
            }
        }
        /// <summary>
        /// 每套用量
        /// </summary>
        public decimal AD09
        {
            get
            {
                return _ad09;
            }
            set
            {
                _ad09 = value;
            }
        }
        /// <summary>
        /// 每套成本
        /// </summary>
        public decimal AD10
        {
            get
            {
                return _ad10;
            }
            set
            {
                _ad10 = value;
            }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public decimal AD11
        {
            get
            {
                return _ad11;
            }
            set
            {
                _ad11 = value;
            }
        }
        /// <summary>
        /// 有效期限
        /// </summary>
        public DateTime AD13
        {
            get
            {
                return _ad13;
            }
            set
            {
                _ad13 = value;
            }
        }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime AD16
        {
            get
            {
                return _ad16;
            }
            set
            {
                _ad16 = value;
            }
        }
        /// <summary>
        /// 采购合同单号
        /// </summary>
        public string AD17
        {
            get
            {
                return _ad17;
            }
            set
            {
                _ad17 = value;
            }
        }
        /// <summary>
        /// 生产车间
        /// </summary>
        public string AD18
        {
            get
            {
                return _ad18;
            }
            set
            {
                _ad18 = value;
            }
        }

        /// <summary>
        /// 采购合同是否有库存
        /// </summary>
        /// <param name="number"></param>
        /// <param name="specification"></param>
        /// <returns></returns>
        public bool IsOrOf (string number,string specification ,string names,string contractOdd)
        {
            AD03 = number;
            AD06 = names;
            AD07 = specification;
            DataTable dk = SqlHelper.ExecuteDataTable( "SELECT AD01 FROM R_PQAD WHERE AD03='" + AD03 + "' AND AD07='" + AD07 + "' AND AD06='" + AD06 + "' AND AD17='" + contractOdd + "'" );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                if ( !string.IsNullOrEmpty( dk.Rows[0]["AD01"].ToString( ) ) )
                    return false;
                else
                    return true;
            }
            DataTable dl = SqlHelper.ExecuteDataTable( "SELECT AC18 FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC02='" + AD03 + "' AND AC05='" + AD07 + "' AND AC04='" + AD06 + "' GROUP BY AC18,AC10,AC02,AC05,AC03,ISNULL(AC27,0) HAVING AC10+ISNULL(AC27,0)-SUM(AD12+ISNULL(AD21,0))>0" );
            if ( dl != null && dl.Rows.Count > 0 )
            {
                int count = 0;
                for ( int i = 0 ; i < dl.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty( dl.Rows[i]["AC18"].ToString( ) ) )
                        count++;
                }

                if ( count >= 1 )
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// 341是否有库存
        /// </summary>
        /// <param name="number"></param>
        /// <param name="specification"></param>
        /// <returns></returns>
        public  bool IsOr ( string names ,string specification ,string contractOdd )
        {
            AD06 = names;
            AD07 = specification;
            DataTable dk = SqlHelper.ExecuteDataTable( "SELECT AD01 FROM R_PQAD WHERE AD06='" + AD06 + "' AND AD07='" + AD07 + "' AND AD17='" + contractOdd + "'" );
            if ( dk != null && dk.Rows.Count > 0 )
            {
                if ( !string.IsNullOrEmpty( dk.Rows[0]["AD01"].ToString( ) ) )
                    return false;
                else
                    return true;
            }
            DataTable dl = SqlHelper.ExecuteDataTable( "SELECT AC18 FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC04='" + AD06 + "' AND AC05='" + AD07 + "' GROUP BY AC10,AC05,AC03,AC18,ISNULL(AC27,0) HAVING AC10+ISNULL(AC27,0)-SUM(AD12+ISNULL(AD21,0))>0" );
            if ( dl != null && dl.Rows.Count > 0 )
            {
                int count = 0;
                for ( int i = 0 ; i < dl.Rows.Count ; i++ )
                {
                    if ( !string.IsNullOrEmpty( dl.Rows[i]["AC18"].ToString( ) ) )
                        count++;
                }

                if ( count >= 1 )
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="productName">产品名称</param>
        /// <param name="number">货号</param>
        /// <param name="serialNumber">流水号</param>
        /// <param name="productQuantity">实领使用产品数量</param>
        /// <param name="materialName">实领物资名称</param>
        /// <param name="specification">规格</param>
        /// <param name="company">单位</param>
        /// <param name="consumptionPerSet">每套用量</param>
        /// <param name="consPerSet">每套成本</param>
        /// <param name="unitPrice">单价</param>
        /// <param name="actualCollar">实领数量</param>
        /// <param name="auditor">审核人==执行人</param>
        /// <param name="auditTime">审核时间==出库时间</param>
        /// <param name="purchaseContractNumber">采购合同单号</param>
        /// <param name="proWork">生产车间</param>
        /// <returns></returns>
        public bool Library ( string productName ,string number ,string serialNumber ,string productQuantity ,string materialName ,string specification ,string company ,string consumptionPerSet ,string consPerSet ,string unitPrice ,string actualCollar ,string auditor ,DateTime auditTime ,string purchaseContractNumber ,string proWork)
        {
            int count = 0;
            AD02 = productName;
            AD03 = number;
            AD04 = serialNumber;
            if ( string.IsNullOrEmpty( productQuantity ) )
                AD05 = 0;
            else
                AD05 = Convert.ToDecimal( productQuantity );
            AD06 = materialName;
            AD07 = specification;
            AD08 = company;
            if ( string.IsNullOrEmpty( consumptionPerSet ) )
                AD09 = 0;
            else
                AD09 = Convert.ToDecimal( consumptionPerSet );
            if ( string.IsNullOrEmpty( consPerSet ) )
                AD10 = 0;
            else
                AD10 = Convert.ToDecimal( consPerSet );
            if ( string.IsNullOrEmpty( unitPrice ) )
                AD11 = 0;
            else
                AD11 = Convert.ToDecimal( unitPrice );
            if ( string.IsNullOrEmpty( actualCollar ) )
                AD12 = 0;
            else
                AD12 = Math.Round( Convert.ToDecimal( actualCollar ) ,0 );
            AD15 = auditor;
            AD16 = auditTime;
            AD17 = purchaseContractNumber;
            AD18 = proWork;

            DataTable damax = SqlHelper.ExecuteDataTable( "SELECT MAX(AC18) AC18 FROM R_PQAC WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05" ,new SqlParameter( "@AC02" ,AD03 ) ,new SqlParameter( "@AC04" ,AD06 ) ,new SqlParameter( "@AC05" ,AD07 ) );
            if ( damax.Rows.Count < 1 )
                MessageBox.Show( "[采购库存专用产品物资跟踪报表(R_464)]中没有\n\r产品货号:" + AD03 + "\n\r物资名称:" + AD06 + "\n\r规格:" + AD07 + "\n\r的记录,请仔细核查以上内容是否输入有误.若确认无误,请联系库管员查询相关内容" );
            else
            {
                DataTable del = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQAD WHERE AD17=@AD17 AND AD03=@AD03 AND AD06=@AD06 AND AD07=@AD07" ,new SqlParameter( "@AD17" ,AD17 ) ,new SqlParameter( "@AD03" ,AD03 ) ,new SqlParameter( "@AD06" ,AD06 ) ,new SqlParameter( "@AD07" ,AD07 ) );
                if ( del.Rows.Count > 0 )
                //MessageBox.Show( "[采购库存专用产品物资跟踪报表(R_464)]中已经存在\n\r单号:" + AD17 + "\n\r产品货号:" + AD03 + "\n\r物资名称:" + AD06 + "\n\r规格:" + AD07 + "\n\r的记录,不能做出库操作" );
                {
                    count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQAD SET AD05=@AD05,AD12=@AD12,AD11=@AD11 WHERE AD17=@AD17 AND AD03=@AD03 AND AD06=@AD06 AND AD07=@AD07" ,new SqlParameter( "@AD05" ,AD05 ) ,new SqlParameter( "@AD12" ,AD12 ) ,new SqlParameter( "@AD17" ,AD17 ) ,new SqlParameter( "@AD03" ,AD03 ) ,new SqlParameter( "@AD06" ,AD06 ) ,new SqlParameter( "@AD07" ,AD07 ),new SqlParameter("@AD11",AD11) );
                    if ( count > 0 )
                        return true;
                    else
                        return false;
                }
                else
                {
                    AD01 = damax.Rows[0]["AC18"].ToString( );
                    if ( string.IsNullOrEmpty( AD01 ) )
                        MessageBox.Show( "[采购库存专用产品物资跟踪报表(R_464)]中没有\n\r产品货号:" + AD03 + "\n\r物资名称:" + AD06 + "\n\r规格:" + AD07 + "\n\r的记录,请仔细核查以上内容是否输入有误.若确认无误,请联系库管员查询相关内容" );
                    else
                    {
                        count = SqlHelper . ExecuteNonQuery ( "INSERT INTO R_PQAD (AD01,AD02,AD03,AD04,AD05,AD06,AD07,AD08,AD09,AD10,AD11,AD12,AD15,AD16,AD17,AD18) VALUES(@AD01,@AD02,@AD03,@AD04,@AD05,@AD06,@AD07,@AD08,@AD09,@AD10,@AD11,@AD12,@AD15,@AD16,@AD17,@AD18)" ,new SqlParameter ( "@AD01" ,AD01 ) ,new SqlParameter ( "@AD02" ,AD02 ) ,new SqlParameter ( "@AD03" ,AD03 ) ,new SqlParameter ( "@AD04" ,AD04 ) ,new SqlParameter ( "@AD05" ,AD05 ) ,new SqlParameter ( "@AD06" ,AD06 ) ,new SqlParameter ( "@AD07" ,AD07 ) ,new SqlParameter ( "@AD08" ,AD08 ) ,new SqlParameter ( "@AD09" ,AD09 ) ,new SqlParameter ( "@AD10" ,AD10 ) ,new SqlParameter ( "@AD11" ,AD11 ) ,new SqlParameter ( "@AD12" ,AD12 ) ,new SqlParameter ( "@AD15" ,AD15 ) ,new SqlParameter ( "@AD16" ,AD16 ) ,new SqlParameter ( "@AD17" ,AD17 ) ,new SqlParameter ( "@AD18" ,AD18 ) );
                        if ( count < 1 )
                            //MessageBox.Show( "出库失败" );
                            result = false;
                        else
                            //MessageBox.Show( "已出库" );
                            result = true;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="productName">产品名称</param>
        /// <param name="number">货号</param>
        /// <param name="serialNumber">流水号</param>
        /// <param name="productQuantity">实领使用产品数量</param>
        /// <param name="materialName">实领物资名称</param>
        /// <param name="specification">规格</param>
        /// <param name="company">单位</param>
        /// <param name="consumptionPerSet">每套用量</param>
        /// <param name="consPerSet">每套成本</param>
        /// <param name="unitPrice">单价</param>
        /// <param name="actualCollar">实领数量</param>
        /// <param name="auditor">审核人==执行人</param>
        /// <param name="auditTime">审核时间==出库时间</param>
        /// <param name="purchaseContractNumber">采购合同单号</param>
        /// <param name="libraryOdd">出库单号</param>
        /// <returns></returns>
        public bool LibraryOf ( string productName ,string number ,string serialNumber ,string productQuantity ,string materialName ,string specification ,string company ,string consumptionPerSet ,string consPerSet ,string unitPrice ,string actualCollar ,string auditor ,DateTime auditTime ,string purchaseContractNumber ,string libraryOdd )
        {
            StringBuilder strSql = new StringBuilder ( );

            int count = 0;
            AD02 = productName;
            AD03 = number;
            AD04 = serialNumber;
            if ( string.IsNullOrEmpty( productQuantity ) )
                AD05 = 0;
            else
                AD05 = Convert.ToDecimal( productQuantity );
            AD06 = materialName;
            AD07 = specification;
            AD08 = company;
            if ( string.IsNullOrEmpty( consumptionPerSet ) )
                AD09 = 0;
            else
                AD09 = Convert.ToDecimal( consumptionPerSet );
            if ( string.IsNullOrEmpty( consPerSet ) )
                AD10 = 0;
            else
                AD10 = Convert.ToDecimal( consPerSet );
            if ( string.IsNullOrEmpty( unitPrice ) )
                AD11 = 0;
            else
                AD11 = Convert.ToDecimal( unitPrice );
            if ( string.IsNullOrEmpty( actualCollar ) )
                AD12 = 0;
            else
                AD12 = Math.Round( Convert.ToDecimal( actualCollar ) ,2 );
            AD15 = auditor;
            AD16 = auditTime;
            AD17 = purchaseContractNumber;

            if ( !string.IsNullOrEmpty( libraryOdd ) )
            {
                AD01 = libraryOdd;

                strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQAD WHERE AD17='{0}' AND AD01='{1}'AND AD06='{2}'AND AD07='{3}' AND AD08='{4}'" ,AD17 ,AD01 ,AD06 ,AD07 ,AD08 );
                if ( SqlHelper.Exists( strSql.ToString( ) ) == true )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "UPDATE R_PQAD SET AD05='{0}',AD12='{1}' WHERE AD17='{2}' AND AD01='{3}' AND AD06='{4}'AND AD07='{5}' AND AD08='{6}'" ,AD05 ,AD12 ,AD17 ,AD01 ,AD06 ,AD07 ,AD08 );
                    count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                    if ( count < 1 )
                        result = false;
                    else
                    {
                        result = true;
                        try
                        {
                            SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( Logins . tableNum ,Logins . tableName ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,AD17 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"出库" ,"出库" ) );
                        }
                        catch
                        {

                        }
                    }
                }
                else
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "INSERT INTO R_PQAD (AD01,AD02,AD03,AD04,AD05,AD06,AD07,AD08,AD09,AD10,AD11,AD12,AD15,AD16,AD17) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}')",AD01 ,AD02 ,AD03 ,AD04 ,AD05 ,AD06 ,AD07 ,AD08 ,AD09 ,AD10 ,AD11 ,AD12 ,AD15 ,AD16 ,AD17 );
                    count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                    if ( count < 1 )
                        result = false;
                    else
                    {
                        result = true;
                        try
                        {
                            SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( Logins . tableNum ,Logins . tableName ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,AD17 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"出库" ,"出库" ) );
                        }
                        catch
                        {

                        }
                    }
                }

                return result;
            }

            DataTable damax = SqlHelper.ExecuteDataTable( "SELECT MAX(AC18) AC18 FROM R_PQAC WHERE AC06=@AC06 AND AC04=@AC04 AND AC05=@AC05 AND AC02='滚漆'" ,new SqlParameter( "@AC06" ,AD08 ) ,new SqlParameter( "@AC04" ,AD06 ) ,new SqlParameter( "@AC05" ,AD07 ) );
            if ( damax.Rows.Count < 1 )
                MessageBox.Show( "[采购库存专用产品物资跟踪报表(R_464)]中没有\n\r工艺:滚漆\n\r油漆品牌:" + AD08 + "\n\r物资名称:" + AD06 + "\n\r规格:" + AD07 + "\n\r的记录,请仔细核查以上内容是否输入有误.若确认无误,请联系库管员查询相关内容" );
            else
            {
                DataTable del = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQAD WHERE AD17=@AD17 AND AD08=@AD08 AND AD06=@AD06 AND AD07=@AD07" ,new SqlParameter( "@AD17" ,AD17 ) ,new SqlParameter( "@AD08" ,AD08 ) ,new SqlParameter( "@AD06" ,AD06 ) ,new SqlParameter( "@AD07" ,AD07 ) );
                if ( del.Rows.Count > 0 )
                //MessageBox.Show( "[采购库存专用产品物资跟踪报表(R_464)]中已经存在\n\r单号:" + AD17 + "\n\r产品货号:" + AD03 + "\n\r物资名称:" + AD06 + "\n\r规格:" + AD07 + "\n\r的记录,不能做出库操作" );
                {
                    count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQAD SET AD05=@AD05,AD12=@AD12,AD11=@AD11 WHERE AD17=@AD17 AND AD08=@AD08 AND AD06=@AD06 AND AD07=@AD07" ,new SqlParameter( "@AD05" ,AD05 ) ,new SqlParameter( "@AD12" ,AD12 ) ,new SqlParameter( "@AD17" ,AD17 ) ,new SqlParameter( "@AD08" ,AD08 ) ,new SqlParameter( "@AD06" ,AD06 ) ,new SqlParameter( "@AD07" ,AD07 ) ,new SqlParameter( "@AD11" ,AD11 ) );
                    if ( count > 0 )
                        return true;
                    else
                        return false;
                }
                else
                {
                    AD01 = damax.Rows[0]["AC18"].ToString( );
                    if ( string.IsNullOrEmpty( AD01 ) )
                        MessageBox.Show( "[采购库存专用产品物资跟踪报表(R_464)]中没有\n\r油漆品牌:" + AD08 + "\n\r物资名称:" + AD06 + "\n\r规格:" + AD07 + "\n\r的记录,请仔细核查以上内容是否输入有误.若确认无误,请联系库管员查询相关内容" );
                    else
                    {
                        count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAD (AD01,AD02,AD03,AD04,AD05,AD06,AD07,AD08,AD09,AD10,AD11,AD12,AD15,AD16,AD17) VALUES(@AD01,@AD02,@AD03,@AD04,@AD05,@AD06,@AD07,@AD08,@AD09,@AD10,@AD11,@AD12,@AD15,@AD16,@AD17)" ,new SqlParameter( "@AD01" ,AD01 ) ,new SqlParameter( "@AD02" ,AD02 ) ,new SqlParameter( "@AD03" ,AD03 ) ,new SqlParameter( "@AD04" ,AD04 ) ,new SqlParameter( "@AD05" ,AD05 ) ,new SqlParameter( "@AD06" ,AD06 ) ,new SqlParameter( "@AD07" ,AD07 ) ,new SqlParameter( "@AD08" ,AD08 ) ,new SqlParameter( "@AD09" ,AD09 ) ,new SqlParameter( "@AD10" ,AD10 ) ,new SqlParameter( "@AD11" ,AD11 ) ,new SqlParameter( "@AD12" ,AD12 ) ,new SqlParameter( "@AD15" ,AD15 ) ,new SqlParameter( "@AD16" ,AD16 ) ,new SqlParameter( "@AD17" ,AD17 ) );
                        if ( count < 1 )
                            //MessageBox.Show( "出库失败" );
                            result = false;
                        else
                            //MessageBox.Show( "已出库" );
                            result = true;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="productName">产品名称</param>
        /// <param name="number">货号</param>
        /// <param name="serialNumber">流水号</param>
        /// <param name="productQuantity">实领使用产品数量</param>
        /// <param name="materialName">实领物资名称</param>
        /// <param name="specification">规格</param>
        /// <param name="company">单位</param>
        /// <param name="consumptionPerSet">每套用量</param>
        /// <param name="consPerSet">每套成本</param>
        /// <param name="unitPrice">单价</param>
        /// <param name="actualCollar">实领数量</param>
        /// <param name="auditor">审核人==执行人</param>
        /// <param name="auditTime">审核时间==出库时间</param>
        /// <param name="purchaseContractNumber">采购合同单号</param>
        /// <param name="libraryOdd">出库单号</param>
        /// <param name="proWorkShop">生产车间</param>
        /// <returns></returns>
        public bool Library ( string productName ,string number ,string serialNumber ,string productQuantity ,string materialName ,string specification ,string company ,string consumptionPerSet ,string consPerSet ,string unitPrice ,string actualCollar ,string auditor ,DateTime auditTime ,string purchaseContractNumber ,string libraryOdd ,string proWorkShop)
        {
            StringBuilder strSql = new StringBuilder ( );
            int count = 0;
            AD02 = productName;
            AD03 = number;
            AD04 = serialNumber;
            if ( string.IsNullOrEmpty( productQuantity ) )
                AD05 = 0;
            else
                AD05 = Convert.ToDecimal( productQuantity );
            AD06 = materialName;
            AD07 = specification;
            AD08 = company;
            if ( string.IsNullOrEmpty( consumptionPerSet ) )
                AD09 = 0;
            else
                AD09 = Convert.ToDecimal( consumptionPerSet );
            if ( string.IsNullOrEmpty( consPerSet ) )
                AD10 = 0;
            else
                AD10 = Convert.ToDecimal( consPerSet );
            if ( string.IsNullOrEmpty( unitPrice ) )
                AD11 = 0;
            else
                AD11 = Convert.ToDecimal( unitPrice );
            if ( string.IsNullOrEmpty( actualCollar ) )
                AD12 = 0;
            else
                AD12 = Math.Round( Convert.ToDecimal( actualCollar ) ,0 );
            AD15 = auditor;
            AD16 = auditTime;
            AD17 = purchaseContractNumber;
            AD18 = proWorkShop;

            if ( !string.IsNullOrEmpty( libraryOdd ) )
            {
                AD01 = libraryOdd;

                strSql = new StringBuilder ( );
                strSql .AppendFormat( "SELECT COUNT(1) FROM R_PQAD WHERE AD17='{0}' AND AD01='{1}'" ,AD17 ,AD01 );
                if ( SqlHelper.Exists( strSql.ToString( ) ) == true )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "UPDATE R_PQAD SET AD05={0},AD12={1} WHERE AD17='{2}' AND AD01='{3}'" ,AD05 ,AD12 ,AD17 ,AD01 );
                    count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                    if ( count < 1 )
                        result = false;
                    else
                    {
                        result = true;
                        try
                        {
                            SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( Logins . tableNum ,Logins . tableName ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,AD17 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"出库" ,"出库" ) );
                        }
                        catch {
                            
                        }
                    }
                }
                else
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "INSERT INTO R_PQAD (AD01,AD02,AD03,AD04,AD05,AD06,AD07,AD08,AD09,AD10,AD11,AD12,AD15,AD16,AD17,AD18) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')" ,AD01 ,AD02 ,AD03 ,AD04 ,AD05 ,AD06 ,AD07 ,AD08 ,AD09 ,AD10 ,AD11 ,AD12 ,AD15 ,AD16 ,AD17 ,AD18 );
                    count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                    if ( count < 1 )
                        result = false;
                    else
                    {
                        result = true;
                        try
                        {
                            SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( Logins.tableNum ,Logins.tableName ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,AD17 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"出库" ,"出库" ) );
                        }
                        catch { }
                    }
                }
                return result;
            }

            DataTable damax = SqlHelper.ExecuteDataTable( "SELECT MAX(AC18) AC18 FROM R_PQAC WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05" ,new SqlParameter( "@AC02" ,AD03 ) ,new SqlParameter( "@AC04" ,AD06 ) ,new SqlParameter( "@AC05" ,AD07 ) );
            if ( damax.Rows.Count < 1 )
                MessageBox.Show( "[采购库存专用产品物资跟踪报表(R_464)]中没有\n\r产品货号:" + AD03 + "\n\r物资名称:" + AD06 + "\n\r规格:" + AD07 + "\n\r的记录,请仔细核查以上内容是否输入有误.若确认无误,请联系库管员查询相关内容" );
            else
            {
                DataTable del = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQAD WHERE AD17=@AD17 AND AD03=@AD03 AND AD06=@AD06 AND AD07=@AD07" ,new SqlParameter( "@AD17" ,AD17 ) ,new SqlParameter( "@AD03" ,AD03 ) ,new SqlParameter( "@AD06" ,AD06 ) ,new SqlParameter( "@AD07" ,AD07 ) );
                if ( del.Rows.Count > 0 )
                //MessageBox.Show( "[采购库存专用产品物资跟踪报表(R_464)]中已经存在\n\r单号:" + AD17 + "\n\r产品货号:" + AD03 + "\n\r物资名称:" + AD06 + "\n\r规格:" + AD07 + "\n\r的记录,不能做出库操作" );
                {
                    count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQAD SET AD05=@AD05,AD12=@AD12,AD11=@AD11 WHERE AD17=@AD17 AND AD03=@AD03 AND AD06=@AD06 AND AD07=@AD07" ,new SqlParameter( "@AD05" ,AD05 ) ,new SqlParameter( "@AD12" ,AD12 ) ,new SqlParameter( "@AD17" ,AD17 ) ,new SqlParameter( "@AD03" ,AD03 ) ,new SqlParameter( "@AD06" ,AD06 ) ,new SqlParameter( "@AD07" ,AD07 ) ,new SqlParameter( "@AD11" ,AD11 ) );
                    if ( count > 0 )
                        result= true;
                    else
                        result= false;

                    return result;
                }
                else
                {
                    AD01 = damax.Rows[0]["AC18"].ToString( );
                    if ( string.IsNullOrEmpty( AD01 ) )
                        MessageBox.Show( "[采购库存专用产品物资跟踪报表(R_464)]中没有\n\r产品货号:" + AD03 + "\n\r物资名称:" + AD06 + "\n\r规格:" + AD07 + "\n\r的记录,请仔细核查以上内容是否输入有误.若确认无误,请联系库管员查询相关内容" );
                    else
                    {
                        count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAD (AD01,AD02,AD03,AD04,AD05,AD06,AD07,AD08,AD09,AD10,AD11,AD12,AD15,AD16,AD17,AD18) VALUES(@AD01,@AD02,@AD03,@AD04,@AD05,@AD06,@AD07,@AD08,@AD09,@AD10,@AD11,@AD12,@AD15,@AD16,@AD17,@AD18)" ,new SqlParameter( "@AD01" ,AD01 ) ,new SqlParameter( "@AD02" ,AD02 ) ,new SqlParameter( "@AD03" ,AD03 ) ,new SqlParameter( "@AD04" ,AD04 ) ,new SqlParameter( "@AD05" ,AD05 ) ,new SqlParameter( "@AD06" ,AD06 ) ,new SqlParameter( "@AD07" ,AD07 ) ,new SqlParameter( "@AD08" ,AD08 ) ,new SqlParameter( "@AD09" ,AD09 ) ,new SqlParameter( "@AD10" ,AD10 ) ,new SqlParameter( "@AD11" ,AD11 ) ,new SqlParameter( "@AD12" ,AD12 ) ,new SqlParameter( "@AD15" ,AD15 ) ,new SqlParameter( "@AD16" ,AD16 ) ,new SqlParameter( "@AD17" ,AD17 ) ,new SqlParameter ( "@AD18" ,AD18 ) );
                        if ( count < 1 )
                            result = false;
                        else
                            result = true;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="productName">产品名称</param>
        /// <param name="number">货号</param>
        /// <param name="serialNumber">流水号</param>
        /// <param name="productQuantity">实领使用产品数量</param>
        /// <param name="materialName">实领物资名称</param>
        /// <param name="specification">规格</param>
        /// <param name="company">单位</param>
        /// <param name="consumptionPerSet">每套用量</param>
        /// <param name="consPerSet">每套成本</param>
        /// <param name="unitPrice">单价</param>
        /// <param name="actualCollar">实领数量</param>
        /// <param name="auditor">审核人==执行人</param>
        /// <param name="auditTime">审核时间==出库时间</param>
        /// <param name="purchaseContractNumber">采购合同单号</param>
        /// <param name="proWork">生产车间</param>
        /// <returns></returns>
        public bool LibraryThrFouOne ( string productName ,string number ,string serialNumber ,string productQuantity ,string materialName ,string specification ,string company ,string consumptionPerSet ,string consPerSet ,string unitPrice ,string actualCollar ,string auditor ,DateTime auditTime ,string purchaseContractNumber ,string libraryOdd ,string proWork)
        {
            StringBuilder strSql = new StringBuilder ( );

            int count = 0;
            AD02 = productName;
            AD03 = number;
            AD04 = serialNumber;
            if ( string.IsNullOrEmpty( productQuantity ) )
                AD05 = 0;
            else
                AD05 = Convert.ToDecimal( productQuantity );
            AD06 = materialName;
            AD07 = specification;
            AD08 = company;
            if ( string.IsNullOrEmpty( consumptionPerSet ) )
                AD09 = 0;
            else
                AD09 = Convert.ToDecimal( consumptionPerSet );
            if ( string.IsNullOrEmpty( consPerSet ) )
                AD10 = 0;
            else
                AD10 = Convert.ToDecimal( consPerSet );
            if ( string.IsNullOrEmpty( unitPrice ) )
                AD11 = 0;
            else
                AD11 = Convert.ToDecimal( unitPrice );
            if ( string.IsNullOrEmpty( actualCollar ) )
                AD12 = 0;
            else
                AD12 = Math.Round( Convert.ToDecimal( actualCollar ) ,4 );
            AD15 = auditor;
            AD16 = auditTime;
            AD17 = purchaseContractNumber;
            AD18 = proWork;

            if ( !string.IsNullOrEmpty( libraryOdd ) )
            {
                AD01 = libraryOdd;
                
                strSql.AppendFormat( "SELECT COUNT(1) FROM R_PQAD WHERE AD17='{0}' AND AD01='{1}'" ,AD17 ,AD01 );
                if ( SqlHelper.Exists( strSql.ToString( ) ) == true )
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "UPDATE R_PQAD SET AD05='{0}',AD12='{1}' WHERE AD17='{2}' AND AD01='{3}'" ,AD05 ,AD12 ,AD17 ,AD01 );
                    count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                    if ( count < 1 )
                        result = false;
                    else
                    {
                        result = true;
                        try
                        {
                            SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( Logins . tableNum ,Logins . tableName ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,AD17 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"出库" ,"出库" ) );
                        }
                        catch
                        {

                        }
                    }
                }
                else
                {
                    strSql = new StringBuilder ( );
                    strSql . AppendFormat ( "INSERT INTO R_PQAD (AD01,AD02,AD03,AD04,AD05,AD06,AD07,AD08,AD09,AD10,AD11,AD12,AD15,AD16,AD17,AD18) VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}')" ,AD01 ,AD02 ,AD03 ,AD04 ,AD05 ,AD06 ,AD07 ,AD08 ,AD09 ,AD10 ,AD11 ,AD12 ,AD15 ,AD16 ,AD17 ,AD18 );
                    count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                    if ( count < 1 )
                        result = false;
                    else
                    {
                        result = true;
                        try
                        {
                            SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( Logins . tableNum ,Logins . tableName ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,AD17 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"出库" ,"出库" ) );
                        }
                        catch
                        {

                        }
                    }
                }
                return result;
            }

            DataTable damax = SqlHelper.ExecuteDataTable( "SELECT MAX(AC18) AC18 FROM R_PQAC WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05" ,new SqlParameter( "@AC02" ,"" ) ,new SqlParameter( "@AC04" ,AD06 ) ,new SqlParameter( "@AC05" ,AD07 ) );
            if ( damax.Rows.Count < 1 )
                MessageBox.Show( "[采购库存专用产品物资跟踪报表(R_464)]中没有\n\r产品货号:" + AD03 + "\n\r物资名称:" + AD06 + "\n\r规格:" + AD07 + "\n\r的记录,请仔细核查以上内容是否输入有误.若确认无误,请联系库管员查询相关内容" );
            else
            {
                DataTable del = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQAD WHERE AD17=@AD17 AND AD03=@AD03 AND AD06=@AD06 AND AD07=@AD07" ,new SqlParameter( "@AD17" ,AD17 ) ,new SqlParameter( "@AD03" ,AD03 ) ,new SqlParameter( "@AD06" ,AD06 ) ,new SqlParameter( "@AD07" ,AD07 ) );
                if ( del.Rows.Count > 0 )
                //MessageBox.Show( "[采购库存专用产品物资跟踪报表(R_464)]中已经存在\n\r单号:" + AD17 + "\n\r产品货号:" + AD03 + "\n\r物资名称:" + AD06 + "\n\r规格:" + AD07 + "\n\r的记录,不能做入库操作" );
                {
                    AD01 = damax.Rows[0]["AC18"].ToString( );
                    count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQAD SET AD05=@AD05,AD12=@AD12,AD11=@AD11 WHERE AD17=@AD17 AND AD03=@AD03 AND AD06=@AD06 AND AD07=@AD07" ,new SqlParameter( "@AD05" ,AD05 ) ,new SqlParameter( "@AD12" ,AD12 ) ,new SqlParameter( "@AD17" ,AD17 ) ,new SqlParameter( "@AD03" ,AD03 ) ,new SqlParameter( "@AD06" ,AD06 ) ,new SqlParameter( "@AD07" ,AD07 ) ,new SqlParameter( "@AD11" ,AD11 ) );
                    if ( count < 1 )
                        result = false;
                    else
                        result = true;

                    return result;
                }
                else
                {
                    AD01 = damax.Rows[0]["AC18"].ToString( );
                    if ( string.IsNullOrEmpty( AD01 ) )
                        MessageBox.Show( "[采购库存专用产品物资跟踪报表(R_464)]中没有\n\r产品货号:" + AD03 + "\n\r物资名称:" + AD06 + "\n\r规格:" + AD07 + "\n\r的记录,请仔细核查以上内容是否输入有误.若确认无误,请联系库管员查询相关内容" );
                    else
                    {
                        count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAD (AD01,AD02,AD03,AD04,AD05,AD06,AD07,AD08,AD09,AD10,AD11,AD12,AD15,AD16,AD17,AD18) VALUES(@AD01,@AD02,@AD03,@AD04,@AD05,@AD06,@AD07,@AD08,@AD09,@AD10,@AD11,@AD12,@AD15,@AD16,@AD17,@AD18)" ,new SqlParameter( "@AD01" ,AD01 ) ,new SqlParameter( "@AD02" ,AD02 ) ,new SqlParameter( "@AD03" ,AD03 ) ,new SqlParameter( "@AD04" ,AD04 ) ,new SqlParameter( "@AD05" ,AD05 ) ,new SqlParameter( "@AD06" ,AD06 ) ,new SqlParameter( "@AD07" ,AD07 ) ,new SqlParameter( "@AD08" ,AD08 ) ,new SqlParameter( "@AD09" ,AD09 ) ,new SqlParameter( "@AD10" ,AD10 ) ,new SqlParameter( "@AD11" ,AD11 ) ,new SqlParameter( "@AD12" ,AD12 ) ,new SqlParameter( "@AD15" ,AD15 ) ,new SqlParameter( "@AD16" ,AD16 ) ,new SqlParameter( "@AD17" ,AD17 ) ,new SqlParameter ( "@AD18" ,AD18 ) );
                        if ( count < 1 )
                            //MessageBox.Show( "出库失败" );
                            result = false;
                        else
                            //MessageBox.Show( "已出库" );
                            result = true;

                        return result;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 删除上次入错库  本次改为入库数量为0的记录
        /// </summary>
        /// <param name="strList"></param>
        /// <param name="oddNum"></param>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool deleteOfLibrary ( List<string>  strList,string oddNum,string num)
        {
            StringBuilder strSql = new StringBuilder ( );
            if ( strList . Count > 0 )
            {
                string strOf = "";
                foreach ( string str in strList )
                {
                    if ( strOf == "" )
                        strOf = "'" + str + "'";
                    else
                        strOf = strOf + "," + "'" + str + "'";
                }
            
                strSql . AppendFormat ( "DELETE FROM R_PQAD WHERE AD17='{0}' AND AD04='{1}' AND AD01 NOT IN (" + strOf + ")" ,oddNum ,num );
            }

            int row = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( row > 0 )
                return true;
            else
                return false;
        }


        /// <summary>
        /// 库存数量是否为空
        /// </summary>
        /// <param name="number">货号</param>
        /// <param name="materialName">物资名称</param>
        /// <param name="specification">规格</param>
        /// <param name="productQuantity">实领使用产品数量</param>
        /// <param name="box"></param>
        /// <param name="boxTwo"></param>
        public void yesOrNo ( string number ,string materialName ,string specification ,TextBox box ,TextBox boxTwo,string productQuantity )
        {
            if ( string.IsNullOrEmpty( productQuantity ) )
                AD05 = 0;
            else
                AD05 = Convert.ToDecimal( productQuantity );
            //if ( string.IsNullOrEmpty( materialName ) )
            //    MessageBox.Show( "物料名称不可为空" );
            //else
            //{
                DataTable der = SqlHelper.ExecuteDataTable( "SELECT MAX(AD01) AD01 FROM R_PQAD WHERE AD03=@AD03 AND AD06=@AD06 AND AD07=@AD07" ,new SqlParameter( "@AD03" ,number ) ,new SqlParameter( "@AD06" ,materialName ) ,new SqlParameter( "@AD07" ,specification ) );
                if ( string.IsNullOrEmpty( der.Rows[0]["AD01"].ToString( ) ) )
                {
                    DataTable ser = SqlHelper.ExecuteDataTable( "SELECT AC10+ISNULL(AC27,0) AC10,AC03+ISNULL(AC26,0) AC03 FROM R_PQAC WHERE AC18=(SELECT MAX(AC18) AC18 FROM R_PQAC WHERE AC02=@AD03 AND AC04=@AD06 AND AC05=@AD07)" ,new SqlParameter( "@AD03" ,number ) ,new SqlParameter( "@AD06" ,materialName ) ,new SqlParameter( "@AD07" ,specification ) );
                    if ( ser.Rows.Count < 1 )
                    {
                        box.Text = "0";
                        boxTwo.Text = "0";
                        //MessageBox.Show( "[采购库存专用产品物资跟踪报表( R_464 )]中没有\n\r产品货号: " + number + "\n\r物资名称: " + materialName + "\n\r规格: " + specification + "\n\r的记录 ,请仔细核查以上内容是否输入有误.若确认无误 ,请联系库管员查询相关内容" );
                    }
                    else if ( Convert.ToDecimal( ser.Rows[0]["AC03"].ToString( ) ) < AD05 )
                    {
                        box.Text = "0";
                        boxTwo.Text = Math.Round( Convert.ToDecimal( ser.Rows[0]["AC03"].ToString( ) ) ,0 ).ToString( );
                        //MessageBox.Show( "库存剩余产品数量:" + Convert.ToDecimal( ser.Rows[0]["AC03"].ToString( ) ) + ",请调整出库数量" );
                    }
                    else
                    {
                        box.Text = Math.Round( Convert.ToDecimal( ser.Rows[0]["AC10"].ToString( ) ) ,0 ).ToString( );
                        boxTwo.Text = Math.Round( Convert.ToDecimal( ser.Rows[0]["AC03"].ToString( ) ) ,0 ).ToString( );
                    }   
                }
                else
                {
                    DataTable del = SqlHelper.ExecuteDataTable( "SELECT AC10+ISNULL(AC27,0)-ISNULL((SELECT SUM(AD12+ISNULL(AD21,0)) FROM R_PQAD WHERE AD01=AC18),0) AC10,AC03+ISNULL(AC26,0)-ISNULL((SELECT SUM(AD05+ISNULL(AD20,0)) FROM R_PQAD WHERE AD01=AC18),0) AD05 FROM R_PQAC WHERE AC18=(SELECT MAX(AC18) AD01 FROM R_PQAC WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05) GROUP BY AC10,AC03,ISNULL(AC27,0),ISNULL(AC26,0),AC18" ,new SqlParameter( "@AC02" ,number ) ,new SqlParameter( "@AC04" ,materialName ) ,new SqlParameter( "@AC05" ,specification ) );
                    if ( del.Rows.Count < 1 )
                    {
                        box.Text = "0";
                    }
                    else if ( Convert.ToDecimal( del.Rows[0]["AC10"].ToString( ) ) <= 0 )
                    {
                        box.Text = "0";
                        boxTwo.Text = Math.Round( Convert.ToDecimal( del.Rows[0]["AD05"].ToString( ) ) ,0 ).ToString( );
                        //MessageBox.Show( "库存剩余产品数量:" + Convert.ToDecimal( del.Rows[0]["AD05"].ToString( ) ) + ",请更改出库产品数量" );
                    }
                    else
                    {
                        box.Text = Math.Round( Convert.ToDecimal( del.Rows[0]["AC10"].ToString( ) ) ,0 ).ToString( );
                        boxTwo.Text = Math.Round( Convert.ToDecimal( del.Rows[0]["AD05"].ToString( ) ) ,0 ).ToString( );
                    } 
                }
            //}
        }

        /// <summary>
        /// 库存数量是否为空
        /// </summary>
        /// <param name="number">货号</param>
        /// <param name="materialName">物资名称</param>
        /// <param name="specification">规格</param>
        /// <param name="productQuantity">实领使用产品数量</param>
        /// <param name="box"></param>
        /// <param name="boxTwo"></param>
        public void yesOrNoOf ( string number ,string materialName ,string specification ,TextBox box ,TextBox boxTwo ,string productQuantity )
        {
            if ( string.IsNullOrEmpty( productQuantity ) )
                AD05 = 0;
            else
                AD05 = Convert.ToDecimal( productQuantity );

            //and AC03-ISNULL(SUM(AD05),0)>=0
            //DataTable del = SqlHelper.ExecuteDataTable( "SELECT SUM(AC10) AC10,SUM(AD05) AD05 FROM (SELECT AC18,AC10-ISNULL(SUM(AD12),0) AC10,AC03-ISNULL(SUM(AD05),0) AD05 FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05 GROUP BY AC10,AC03,AC18 HAVING AC10-ISNULL(SUM(AD12),0)>=0 ) A " ,new SqlParameter( "@AC02" ,number ) ,new SqlParameter( "@AC04" ,materialName ) ,new SqlParameter( "@AC05" ,specification ) );
            
            DataTable del = SqlHelper . ExecuteDataTable ( "SELECT SUM(AC10) AC10,SUM(AD05) AD05 FROM (SELECT AC18,AC10+ISNULL(AC27,0)-ISNULL(SUM(AD12+ISNULL(AD21,0)),0) AC10,CONVERT(DECIMAL(11,0),(AC03+ISNULL(AC26,0))/(AC10+ISNULL(AC27,0))*((AC10+ISNULL(AC27,0))-SUM(ISNULL(AD12,0)+ISNULL(AD21,0)))) AD05 FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05 GROUP BY AC10,AC03,AC18,ISNULL(AC26,0),ISNULL(AC27,0) HAVING AC10+ISNULL(AC27,0)-ISNULL(SUM(AD12+ISNULL(AD21,0)),0)>=0 ) A " ,new SqlParameter ( "@AC02" ,number ) ,new SqlParameter ( "@AC04" ,materialName ) ,new SqlParameter ( "@AC05" ,specification ) );
            if ( del . Rows . Count < 1 )
                box . Text = "0";
            else if ( !string . IsNullOrEmpty ( del . Rows [ 0 ] [ "AC10" ] . ToString ( ) ) && Convert . ToDecimal ( del . Rows [ 0 ] [ "AC10" ] . ToString ( ) ) <= 0 )
            {
                box . Text = "0";
                boxTwo . Text = Math . Round ( Convert . ToDecimal ( del . Rows [ 0 ] [ "AD05" ] . ToString ( ) ) ,0 ) . ToString ( );
            }
            else
            {
                box . Text = string . IsNullOrEmpty ( del . Rows [ 0 ] [ "AC10" ] . ToString ( ) ) == true ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( del . Rows [ 0 ] [ "AC10" ] . ToString ( ) ) ,0 ) . ToString ( );
                boxTwo . Text = string . IsNullOrEmpty ( del . Rows [ 0 ] [ "AD05" ] . ToString ( ) ) == true ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( del . Rows [ 0 ] [ "AD05" ] . ToString ( ) ) ,0 ) . ToString ( );
            }
        }

        /// <summary>
        /// 库存数量是否为空  R_341  4位小数
        /// </summary>
        /// <param name="number">货号</param>
        /// <param name="materialName">物资名称</param>
        /// <param name="specification">规格</param>
        /// <param name="productQuantity">实领使用产品数量</param>
        /// <param name="box"></param>
        /// <param name="boxTwo"></param>
        public void yesOrNoThrForOne ( string number ,string materialName ,string specification ,TextBox box ,TextBox boxTwo ,string productQuantity )
        {
            if ( string.IsNullOrEmpty( productQuantity ) )
                AD05 = 0;
            else
                AD05 = Convert.ToDecimal( productQuantity );
            //if ( string.IsNullOrEmpty( materialName ) )
            //    MessageBox.Show( "物料名称不可为空" );
            //else
            //{
            // AD03=@AD03 AND     ,new SqlParameter( "@AD03" ,number ) 
            DataTable der = SqlHelper.ExecuteDataTable( "SELECT MAX(AD01) AD01 FROM R_PQAD WHERE AD06=@AD06 AND AD07=@AD07" ,new SqlParameter( "@AD06" ,materialName ) ,new SqlParameter( "@AD07" ,specification ) );
            if ( string.IsNullOrEmpty( der.Rows[0]["AD01"].ToString( ) ) )
            {
                DataTable ser = SqlHelper.ExecuteDataTable( "SELECT AC10+ISNULL(AC27,0) AC10,AC03+ISNULL(AC26,0) AC03 FROM R_PQAC WHERE AC18=(SELECT MAX(AC18) AC18 FROM R_PQAC WHERE AC02=@AD03 AND AC04=@AD06 AND AC05=@AD07)" ,new SqlParameter( "@AD03" ,"" ) ,new SqlParameter( "@AD06" ,materialName ) ,new SqlParameter( "@AD07" ,specification ) );
                if ( ser.Rows.Count < 1 )
                {
                    box.Text = "0";
                    boxTwo.Text = "0";
                    //MessageBox.Show( "[采购库存专用产品物资跟踪报表( R_464 )]中没有\n\r产品货号: " + number + "\n\r物资名称: " + materialName + "\n\r规格: " + specification + "\n\r的记录 ,请仔细核查以上内容是否输入有误.若确认无误 ,请联系库管员查询相关内容" );
                }
                else if ( Convert.ToDecimal( ser.Rows[0]["AC03"].ToString( ) ) < AD05 )
                {
                    box.Text = "0";
                    boxTwo.Text = Math.Round( Convert.ToDecimal( ser.Rows[0]["AC03"].ToString( ) ) ,4 ).ToString( );
                    //MessageBox.Show( "库存剩余产品数量:" + Convert.ToDecimal( ser.Rows[0]["AC03"].ToString( ) ) + ",请调整出库数量" );
                }
                else
                {
                    box.Text = Math.Round( Convert.ToDecimal( ser.Rows[0]["AC10"].ToString( ) ) ,4 ).ToString( );
                    boxTwo.Text = Math.Round( Convert.ToDecimal( ser.Rows[0]["AC03"].ToString( ) ) ,4 ).ToString( );
                }
            }
            else
            {
                DataTable del = SqlHelper.ExecuteDataTable( "SELECT AC10+ISNULL(AC27,0)-ISNULL((SELECT SUM(AD12+ISNULL(AD21,0)) FROM R_PQAD WHERE AD01=AC18),0) AC10,AC03+ISNULL(AC26,0)-ISNULL((SELECT SUM(AD05+ISNULL(AD20,0)) FROM R_PQAD WHERE AD01=AC18),0) AD05 FROM R_PQAC WHERE AC18=(SELECT MAX(AC18) AD01 FROM R_PQAC WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05) GROUP BY AC10,AC03,ISNULL(AC27,0),ISNULL(AC26,0),AC18" ,new SqlParameter( "@AC02" ,number ) ,new SqlParameter( "@AC04" ,materialName ) ,new SqlParameter( "@AC05" ,specification ) );
                if ( del.Rows.Count < 1 )
                {
                    box.Text = "0";
                }
                else if ( Convert.ToDecimal( del.Rows[0]["AC10"].ToString( ) ) <= 0 )
                {
                    box.Text = "0";
                    boxTwo.Text = Math.Round( Convert.ToDecimal( del.Rows[0]["AD05"].ToString( ) ) ,4 ).ToString( );
                    //MessageBox.Show( "库存剩余产品数量:" + Convert.ToDecimal( del.Rows[0]["AD05"].ToString( ) ) + ",请更改出库产品数量" );
                }
                else
                {
                    box.Text = Math.Round( Convert.ToDecimal( del.Rows[0]["AC10"].ToString( ) ) ,4 ).ToString( );
                    boxTwo.Text = Math.Round( Convert.ToDecimal( del.Rows[0]["AD05"].ToString( ) ) ,4 ).ToString( );
                }
            }
            //}
        }

        /// <summary>
        /// 库存数量是否为空  R_341  4位小数
        /// </summary>
        /// <param name="number">货号</param>
        /// <param name="materialName">物资名称</param>
        /// <param name="specification">规格</param>
        /// <param name="productQuantity">实领使用产品数量</param>
        /// <param name="box"></param>
        /// <param name="boxTwo"></param>
        public void yesOrNoThrForOneOf ( string number ,string materialName ,string specification ,TextBox box ,TextBox boxTwo ,string productQuantity )
        {
            if ( string.IsNullOrEmpty( productQuantity ) )
                AD05 = 0;
            else
                AD05 = Convert.ToDecimal( productQuantity );

            //DataTable del = SqlHelper.ExecuteDataTable( "SELECT SUM(AC10) AC10,SUM(AD05) AD05 FROM (SELECT AC18,AC10-ISNULL(SUM(AD12),0) AC10,AC03-ISNULL(SUM(AD05),0) AD05 FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE  AC04=@AC04 AND AC05=@AC05 GROUP BY AC10,AC03,AC18 HAVING AC10-ISNULL(SUM(AD12),0)>=0) A" ,new SqlParameter( "@AC04" ,materialName ) ,new SqlParameter( "@AC05" ,specification ) );
            DataTable del = SqlHelper . ExecuteDataTable ( "SELECT SUM(AC10) AC10,SUM(AD05) AD05 FROM (SELECT AC18,AC10+ISNULL(AC27,0)-ISNULL(SUM(AD12+ISNULL(AD21,0)),0) AC10,CONVERT(DECIMAL(11,0),(AC03+ISNULL(AC26,0))/(AC10+ISNULL(AC27,0))*(AC10+ISNULL(AC27,0)-SUM(ISNULL(AD12,0)+ISNULL(AD21,0)))) AD05 FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE  AC04=@AC04 AND AC05=@AC05 GROUP BY AC10,AC03,AC18,ISNULL(AC26,0),ISNULL(AC27,0) HAVING AC10+ISNULL(AC27,0)-ISNULL(SUM(AD12+ISNULL(AD21,0)),0)>=0) A" ,new SqlParameter ( "@AC04" ,materialName ) ,new SqlParameter ( "@AC05" ,specification ) );
            if ( del.Rows.Count < 1 )
            {
                box.Text = "0";
            }
            else if (!string.IsNullOrEmpty( del.Rows[0]["AC10"].ToString( ) ) && Convert.ToDecimal( del.Rows[0]["AC10"].ToString( ) ) <= 0 )
            {
                box.Text = "0";
                boxTwo.Text = string.IsNullOrEmpty( del.Rows[0]["AD05"].ToString( ) ) == true ? 0.ToString( ) : Math.Round( Convert.ToDecimal( del.Rows[0]["AD05"].ToString( ) ) ,4 ).ToString( );
                //MessageBox.Show( "库存剩余产品数量:" + Convert.ToDecimal( del.Rows[0]["AD05"].ToString( ) ) + ",请更改出库产品数量" );
            }
            else
            {
                box.Text = string.IsNullOrEmpty( del.Rows[0]["AC10"].ToString( ) ) == true ? 0.ToString( ) : Math.Round( Convert.ToDecimal( del.Rows[0]["AC10"].ToString( ) ) ,4 ).ToString( );
                boxTwo.Text = string.IsNullOrEmpty( del.Rows[0]["AD05"].ToString( ) ) == true ? 0.ToString( ) : Math.Round( Convert.ToDecimal( del.Rows[0]["AD05"].ToString( ) ) ,4 ).ToString( );
            }
        }

        /// <summary>
        /// 计划订单
        /// </summary>
        /// <param name="boxOne">产品名称</param>
        /// <param name="boxTwo">货号</param>
        /// <param name="boxThr">物料名称</param>
        public void productNumber ( ComboBox boxOne ,ComboBox boxTwo ,ComboBox boxThr )
        {
            DataTable del = SqlHelper.ExecuteDataTable( "SELECT PQF04,PQF03 FROM R_PQF" );
            //产品名称
            DataTable productName = del.DefaultView.ToTable( true ,"PQF04" );
            boxOne.DataSource = productName;
            boxOne.DisplayMember = "PQF04";
            //货号
            DataTable numBer = del.DefaultView.ToTable( true ,"PQF03" );
            boxTwo.DataSource = numBer;
            boxTwo.DisplayMember = "PQF03";
            //物料名称
            DataTable materialName = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS07 FROM R_PQP" );
            boxThr.DataSource = materialName;
            boxThr.DisplayMember = "GS07";
        }

        /// <summary>
        /// 计划订单
        /// </summary>
        /// <param name="boxOne">产品名称</param>
        /// <param name="boxTwo">货号</param>
        public void productNumberRthr ( ComboBox boxOne )
        {
            DataTable del = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQF04,PQF03 FROM R_PQF UNION SELECT DISTINCT JM100,JM102 FROM R_PQO" );
            //产品名称
            //DataTable productName = del.DefaultView.ToTable( true ,"PQF04" );
            boxOne.DataSource = del;
            boxOne.DisplayMember = "PQF04";
            boxOne.ValueMember = "PQF03";
            ////货号
            //DataTable numBer = del.DefaultView.ToTable( true ,"PQF03" );
            //boxTwo.DataSource = numBer;
            //boxTwo.DisplayMember = "PQF03";
        }


        /// <summary>
        /// 339开实际外购单得到525剩余库存
        /// </summary>
        /// <param name="boxSev">零件名称</param>
        /// <param name="boxOne">工序</param>
        /// <param name="boxTwo">色号</param>
        /// <param name="boxTre">供方批号</param>
        /// <param name="boxFor">生产批号</param>
        /// <param name="boxFiv">剩余库存量</param>
        /// <param name="boxSix">剩余产品数量</param>
        public void getInventory (TextBox boxSev,TextBox boxOne,ComboBox boxTwo,TextBox boxTre,TextBox boxFor,TextBox boxFiv,TextBox boxSix )
        {
            //DataTable da = SqlHelper.ExecuteDataTable( "SELECT A.AI005,A.AI006,CASE WHEN A.AI007=B.AI007 THEN B.AI007-B.AI008 WHEN A.AI007!=B.AI007 THEN  B.AI007-B.AI008-ISNULL(SUM(A.AI007),0) END AI007,CASE WHEN A.AI007=B.AI007 THEN ROUND((B.AI007-B.AI008)*B.AI009,0) WHEN A.AI007!=B.AI007 THEN ROUND((B.AI007-B.AI008-ISNULL(SUM(A.AI007),1))*B.AI009,0) END AI009 FROM R_PQAI A ,(SELECT TOP 1 AI007,AI008,AI006,AI009 FROM R_PQAI WHERE AI003='喷清面漆' AND AI004='清面漆' AND AI007-AI008!=0 ORDER BY AI006) B WHERE A.AI006=B.AI006 AND A.AI003='喷清面漆' AND A.AI004='清面漆'  GROUP BY B.AI007,B.AI008,A.AI005,A.AI006,A.AI009,A.AI007,B.AI009 HAVING B.AI007-B.AI008-ISNULL(SUM(A.AI007),0)!=0" ,new SqlParameter( "@AI003" ,boxOne.Text ) ,new SqlParameter( "@AI004" ,boxTwo.Text ) );
            DataTable da = SqlHelper.ExecuteDataTable( "SELECT AI005,AI006,AI007-AI008 AI007,(AI007-AI008)*AI009 AI009 FROM R_PQAI WHERE AI003=@AI003 AND AI004=@AI004 AND AI011=@AI011 AND AI007!=AI008 ORDER BY AI001" ,new SqlParameter( "@AI003" ,boxOne.Text ) ,new SqlParameter( "@AI004" ,boxTwo.Text ) ,new SqlParameter( "@AI011" ,boxSev.Text ) );
            if ( da.Rows.Count < 1 )
                boxTre.Text = boxFor.Text = boxFiv.Text = boxSix.Text = "";
            else
            {
                boxTre.Text = da.Rows[0]["AI005"].ToString( );
                boxFor.Text = da.Rows[0]["AI006"].ToString( );
                boxFiv.Text = da.Rows[0]["AI007"].ToString( );
                if ( !string.IsNullOrEmpty( da.Rows[0]["AI009"].ToString( ) ) )
                    boxSix.Text = Math.Round( Convert.ToDecimal( da.Rows[0]["AI009"].ToString( ) ) ,0 ).ToString( );
                else
                    boxSix.Text = "";
            }
        }

        public bool getInventory ( TextBox boxSev ,TextBox boxOne ,ComboBox boxTwo )
        {
            bool result = false;
            DataTable da = SqlHelper.ExecuteDataTable( "SELECT AI005,AI006,AI007-AI008 AI007,(AI007-AI008)*AI009 AI009 FROM R_PQAI WHERE AI003=@AI003 AND AI004=@AI004 AND AI011=@AI011 AND AI007!=AI008 ORDER BY AI001" ,new SqlParameter( "@AI003" ,boxOne.Text ) ,new SqlParameter( "@AI004" ,boxTwo.Text ) ,new SqlParameter( "@AI011" ,boxSev.Text ) );
            if ( da.Rows.Count < 1 )
                result = false;
            else
                result = true;

            return result;
        }

        public bool getInventory ( string boxSev ,string boxOne ,string boxTwo )
        {
            bool result = false;
            DataTable da = SqlHelper.ExecuteDataTable( "SELECT AI005,AI006,AI007-AI008 AI007,(AI007-AI008)*AI009 AI009 FROM R_PQAI WHERE AI003=@AI003 AND AI004=@AI004 AND AI011=@AI011 AND AI007!=AI008 ORDER BY AI001" ,new SqlParameter( "@AI003" ,boxOne ) ,new SqlParameter( "@AI004" ,boxTwo ) ,new SqlParameter( "@AI011" ,boxSev ) );
            if ( da.Rows.Count < 1 )
                result = false;
            else
                result = true;

            return result;
        }

        /// <summary>
        /// 库存是否多于现实采购
        /// </summary>
        /// <param name="number">货号</param>
        /// <param name="productQuantity">产品数量</param>
        /// <param name="materialName">物料名称</param>
        /// <param name="specification">规格</param>
        /// <returns></returns>
        public bool LibraryOf ( string number ,string productQuantity ,string materialName ,string specification )
        {
            bool result = false;
            AC02 = AD03 = number;
            if ( string . IsNullOrEmpty ( productQuantity ) )
                AD05 = 0;
            else
                AD05 = Convert . ToDecimal ( productQuantity );
            AC04 = AD06 = materialName;
            AC05 = AD07 = specification;

            DataTable da = SqlHelper . ExecuteDataTable ( "SELECT SUM(ACD) ACD FROM (SELECT AC18,AC03+ISNULL(AC26,0)-ISNULL(SUM(AD05+ISNULL(AD20,0)),0) ACD FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC04='" + AC04 + "' AND AC05='" + AC05 + "' AND AC02='" + AC02 + "' GROUP BY AC10,AC03,ISNULL(AC26,0),AC18 HAVING AC03+ISNULL(AC26,0)-ISNULL(SUM(AD05+ISNULL(AD20,0)),0)>=0) A" );
            if ( da != null && da . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < da . Rows . Count ; i++ )
                {
                    if ( !string . IsNullOrEmpty ( da . Rows [ i ] [ "ACD" ] . ToString ( ) ) && Convert . ToInt32 ( da . Rows [ i ] [ "ACD" ] . ToString ( ) ) < AD05 )
                        result = false;
                    else
                    {
                        result = true;
                        break;
                    }
                }
            }
            else
                result = false;

            return result;
        }

        /// <summary>
        /// 341
        /// </summary>
        /// <param name="productQuantity">物料数量</param>
        /// <param name="materialName">物料名称</param>
        /// <param name="specification">规格</param>
        /// <returns></returns>
        public bool LibraryOf ( string productQuantity ,string materialName ,string specification )
        {
            bool result = false;
            if ( string.IsNullOrEmpty( productQuantity ) )
                AD12 = 0;
            else
                AD12 = Convert.ToDecimal( productQuantity );
            AC04 = AD06 = materialName;
            AC05 = AD07 = specification;
            
            DataTable da = SqlHelper.ExecuteDataTable( "SELECT SUM(ACD) ACD FROM (SELECT AC18,AC10+ISNULL(AC27,0)-ISNULL(SUM(AD12+ISNULL(AD21,0)),0) ACD FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC04='" + AC04 + "' AND AC05='" + AC05 + "' GROUP BY AC10,AC03,ISNULL(AC27,0),AC18 HAVING AC10+ISNULL(AC27,0)-ISNULL(SUM(AD12+ISNULL(AD21,0)),0)>=0) A" );
            if ( da != null && da.Rows.Count > 0 )
            {
                if ( !string.IsNullOrEmpty( da.Rows[0]["ACD"].ToString( ) ) && Convert.ToDecimal( da.Rows[0]["ACD"].ToString( ) ) < AD12 )
                    result = false;
                else
                    result = true;
            }
            else
                result = false;

            return result;
        }
        
        /// <summary>
        /// 341保存检查是否和509一致,不一致就改
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool check341And509 ( MulaolaoLibrary.MuCaiContractLibrary model )
        {
            bool resultP = false;
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "select case when a='/' or a='\' then '0' else a end a from ( select right(a,LEN(a)-charindex('*',a)) a from ( SELECT right(GS08,len(GS08)-charindex('*',GS08)) a FROM R_PQP WHERE  GS70='R_341' AND GS01='{0}' AND GS02='{1}' AND GS07='{2}' ) a) a" ,model . PQV01 ,model . PQV86 ,model . PQV10 );

            DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( table == null || table . Rows . Count < 1 )
                return false;
            else
            {
                foreach ( DataRow row in table . Rows )
                {
                    string result = row [ "a" ] . ToString ( );
                    if ( ( Convert . ToDecimal ( result ) - model . PQV73 ) == 0 )
                    {
                        resultP= true;
                        break;
                    }
                }
            }

            return resultP;
        }

        /// <summary>
        /// 342保存检查是否和509一致
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool check342And509 ( MulaolaoLibrary . CheMuJianContractLibrary model )
        {
            bool resultS = false;
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT GS08 FROM R_PQP WHERE  GS70='R_342' AND GS01='{0}' AND GS02='{1}' AND GS07='{2}' " ,model . AF002 ,model . AF084 ,model . AF015 );

            DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( table == null || table . Rows . Count < 1 )
                return false;
            else
            {
                foreach ( DataRow row in table . Rows )
                {
                    string result = row [ "GS08" ] . ToString ( );
                    string code = string . Empty;
                    if ( result . Contains ( "Φ" ) )
                    {
                        code = "Φ" + ( model . AF022 * 10 ) . ToString ( "0.####" ) + "*" + ( model . AF020 * 10 ) . ToString ( "0.####" );
                        if ( result . Equals ( code ) )
                        {
                            resultS = true;
                            break;
                        }
                    }
                    else if ( !result . Contains ( "Φ" ) )
                    {
                        code = ( model . AF020 * 10 ) . ToString ( "0.####" ) + "*" + ( model . AF021 * 10 ) . ToString ( "0.####" ) + "*" + ( model . AF022 * 10 ) . ToString ( "0.####" );
                        if ( result . Equals ( code ) )
                        {
                            resultS = true;
                            break;
                        }
                    }
                    else
                    {
                        resultS= true;
                        break;
                    }
                }
            }

            return resultS;
        }

        /// <summary>
        /// 343保存检查是否和509一致
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool check343And509 ( MulaolaoLibrary . WuJinContractLibrary model )
        {
            bool result = false;
            string resultP;

            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT GS08 FROM R_PQP WHERE GS70='R_343' AND GS01='{0}' AND GS07='{1}' " ,model . PQU01 ,model . PQU10 );

            DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( table == null || table . Rows . Count < 1 )
                return false;
            else
            {
                foreach ( DataRow row in table . Rows )
                {
                    resultP = row [ "GS08" ] . ToString ( );
                    if ( resultP . Equals ( model . PQU12 ) )
                    {
                        result = true;
                        break;
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// 347保存检查是否和509一致
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool check347And509 ( MulaolaoLibrary . SuLiaoBuQiContractLibrary model )
        {
            bool result = false;
            string resultP;
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT GS08 FROM R_PQP WHERE GS70='R_347' AND GS01='{0}' AND GS07='{1}' " ,model . PJ01 ,model . PJ09 );

            DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( table == null || table . Rows . Count < 1 )
                return false;
            else
            {
                foreach ( DataRow row in table . Rows )
                {
                    resultP = row [ "GS08" ] . ToString ( );
                    if ( resultP . Equals ( model . PJ89 ) )
                    {
                        result= true;
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 347保存检查是否和509一致
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool check349And509 ( MulaolaoLibrary . WaiXianContractLibrary model )
        {
            bool result = false;
            string resultW;
            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT GS57 FROM R_PQP WHERE GS01='{0}' AND GS56='{1}' " ,model . WX01 ,model . WX10 );

            DataTable table = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( table == null || table . Rows . Count < 1 )
                return false;
            else
            {
                foreach ( DataRow row in table . Rows )
                {
                    resultW = row [ "GS57" ] . ToString ( );
                    if ( resultW . Equals ( model . WX11 ) )
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }

    }
}
