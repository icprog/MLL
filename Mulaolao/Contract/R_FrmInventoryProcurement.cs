using Mulaolao . Class;
using System;
using System . Data;
using System . Data . SqlClient;
using System . Windows . Forms;
using StudentMgr;
using Mulaolao . Other;
using System . Collections;
using System . Text;
using MulaolaoBll;
using System . Threading . Tasks;

namespace Mulaolao . Contract
{
    public partial class R_FrmInventoryProcurement : FormChild
    {
        
        MulaolaoBll.Bll.InventoryProcurementBll _bll=null;
        StringBuilder strSql = new StringBuilder ( );

        public R_FrmInventoryProcurement (Form1 fm )
        {
            this.MdiParent = fm;
            InitializeComponent ( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GridViewMoHuSelect . SetFilter ( gridView2 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . gridView1 ,this . gridView2 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            _bll = new MulaolaoBll . Bll . InventoryProcurementBll ( );
        }
        
        DataTable sto;
        DataTable find;
        bool result=false;
        
        Hashtable SQLString = new Hashtable ( );
        
        private void R_FrmInventoryProcurement_Load ( object sender , EventArgs e )
        {
            Power( this );

            GridViewMoHuSelect.SetFilter( gridView1 );
            GridViewMoHuSelect.SetFilter( gridView2 );

           

            DataTable da = SqlHelper.ExecuteDataTable( "SELECT AC18,AC01,AC02,AC04,AC05,AC06 FROM R_PQAC" );
            //产品名称
            DataTable productName = da.DefaultView.ToTable( true ,"AC01" );
            comboBox9.DataSource = row( productName ,"AC01" );
            comboBox9.DisplayMember = "AC01";
            //货号
            DataTable number = da.DefaultView.ToTable( true ,"AC02" );
            comboBox10.DataSource = row( number ,"AC02" );
            comboBox10.DisplayMember = "AC02";
            //物资名称
            DataTable materialName = da.DefaultView.ToTable( true ,"AC04" );
            comboBox3.DataSource = row( materialName ,"AC04" );
            comboBox3.DisplayMember = "AC04";
            //规格
            DataTable specification = da.DefaultView.ToTable( true ,"AC05" );
            comboBox8.DataSource = row( specification ,"AC05" );
            comboBox8.DisplayMember = "AC05";
            //单位
            DataTable unit = da.DefaultView.ToTable( true ,"AC06" );
            comboBox5.DataSource = row( unit ,"AC06" );
            comboBox5.DisplayMember = "AC06";


            DataTable de = SqlHelper.ExecuteDataTable( "SELECT AD02,AD03,AD04,AD06,AD07,AD08 FROM R_PQAD" );
            //产品名称
            DataTable productNameOne = de.DefaultView.ToTable( true ,"AD02" );
            comboBox1.DataSource = productNameOne;
            comboBox1.DisplayMember = "AD02";
            //货号
            DataTable numberOne = de.DefaultView.ToTable( true ,"AD03" );
            comboBox2.DataSource = numberOne;
            comboBox2.DisplayMember = "AD03";
            //流水号
            DataTable serialNumber = de.DefaultView.ToTable( true ,"AD04" );
            comboBox4.DataSource = serialNumber;
            comboBox4.DisplayMember = "AD04";
            //物资名称
            DataTable metarialNameOne = de.DefaultView.ToTable( true ,"AD06" );
            comboBox6.DataSource = metarialNameOne;
            comboBox6.DisplayMember = "AD06";
            //规格
            DataTable specificationOne = de.DefaultView.ToTable( true ,"AD07" );
            comboBox7.DataSource = specificationOne;
            comboBox7.DisplayMember = "AD07";
            //单位
            DataTable unitOne = de.DefaultView.ToTable( true ,"AD08" );
            comboBox11.DataSource = unitOne;
            comboBox11.DisplayMember = "AD08";

            DataTable dt = SqlHelper . ExecuteDataTable ( "SELECT DBA002,DBA001 FROM TPADBA WHERE DBA028!='' AND (DBA043='F' OR DBA043='' OR DBA043 IS NULL) ORDER BY DBA001" );
            lookUpEdit1 . Properties . DataSource = dt;
            lookUpEdit1 . Properties . DisplayMember = "DBA002";
            lookUpEdit1 . Properties . ValueMember = "DBA001";


            Task task = new Task ( readJZ );
            task . Start ( );
        }

        #region Method
        void readJZ ( )
        {
            _bll . UpdateJZ ( );
            _bll . UpdateADJZ ( );
        }
        #endregion

        #region 表格
        //出库
        string AD1 = "", AD2 = "", AD3 = "", AD4 = "", AD6 = "", AD7 = "", AD8 = "", AD014 = "", AD015 = "",AD019="";
        long AD5 = 0;decimal AD012 = 0;
        decimal AD9 = 0M, AD011 = 0M;
        DateTime AD013 = MulaolaoBll . Drity . GetDt ( ), AD016 = MulaolaoBll . Drity . GetDt ( );
        private void builds ( )
        {
            //AD2 = comboBox1.Text;
            //AD3 = comboBox2.Text;
            //AD4 = comboBox4.Text;
            //if ( string.IsNullOrEmpty( textBox10.Text ) )
            //    AD5 = 0;
            //else
            //    AD5 = Convert.ToInt64( textBox10.Text );
            //AD6 = comboBox6.Text;
            //AD7 = comboBox7.Text;
            //AD8 = comboBox11.Text;
            //if ( string.IsNullOrEmpty( textBox4.Text ) )
            //    AD9 = 0;
            //else
            //    AD9 = Convert.ToDecimal( textBox4.Text );
            //if ( string.IsNullOrEmpty( textBox5.Text ) )
            //    AD011 = 0M;
            //else
            //    AD011 = Convert.ToDecimal( textBox5.Text );
            //if ( string.IsNullOrEmpty( textBox7.Text ) )
            //    AD012 = 0;
            //else
            //    AD012 = Convert.ToDecimal( textBox7.Text );
            //AD013 = dateTimePicker2.Value;
            //AD014 = textBox11.Text;
            //AD015 = Logins.username;
            //AD016 = MulaolaoBll . Drity . GetDt ( );
        }
        //入库
        string AC18 = "", AC01 = "", AC02 = "", AC04 = "", AC05 = "", AC06 = "", AC011 = "", AC015 = "", AC019 = "",AC024="";
        long AC03 = 0;
        decimal AC07 = 0M, AC09 = 0M, AC10 = 0M;
        int AC020 = 0;
        DateTime AC012 = MulaolaoBll . Drity . GetDt ( ),AC021=MulaolaoBll . Drity . GetDt ( );
        private void build ( )
        {            
            AC01 = comboBox9.Text;
            AC02 = comboBox10.Text;
            AC04 = comboBox3.Text;
            AC05 = comboBox8.Text;
            AC06 = comboBox5.Text;
            //if ( string.IsNullOrEmpty( textBox9.Text ) )
            //    AC03 = 0;
            //else
            //    AC03 = Convert.ToInt64( textBox9.Text );
            //if ( string.IsNullOrEmpty( textBox8.Text ) )
            //    AC10 = 0;
            //else
            //    AC10 = Convert.ToDecimal( textBox8.Text );
            //if ( string.IsNullOrEmpty( textBox3.Text ) )
            //    AC07 = 0M;
            //else
            //    AC07 = Convert.ToDecimal( textBox3.Text );
            //if ( string.IsNullOrEmpty( textBox2.Text ) )
            //    AC09 = 0M;
            //else
            //    AC09 = Convert.ToDecimal( textBox2.Text );
            AC011 = Logins.username;
            AC012 = MulaolaoBll . Drity . GetDt ( );
            //AC015 = textBox6.Text;
            //AC019 = lookUpEdit1.Text;
            //AC020 = string.IsNullOrEmpty( textBox13.Text ) == true ? 0 : Convert.ToInt32( textBox13.Text );
            AC021 = DateTime . Now;
        }
        #endregion

        #region 事件
        //计算
        string ac16 = "";int id = 0;
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( ac16.Substring( 0 ,5 ) == "R_338" )
                // 产品数量/每张套数
                textBox8.Text = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox9 ,textBox3 ) ) ,4 ).ToString( );
            else if ( ac16.Substring( 0 ,5 ) == "R_342" )
                //产品数量*每套用量
                textBox8.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTbes( textBox9 ,textBox3 ) ) ,4 ).ToString( );
            else if ( ac16.Substring( 0 ,5 ) == "R_341" )
                // 产品数量*每套用量(半成品规格长*宽*高*0.000001*每套部件数量)
                textBox8.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTbes( textBox9 ,textBox3 ) ) ,4 ).ToString( );
            else if ( ac16.Substring( 0 ,5 ) == "R_343" )
                // 产品数量*每套用量(每套用量+采购余量/产品数量)
                textBox8.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTbes( textBox9 ,textBox3 ) ) ,4 ).ToString( );
            else if ( ac16.Substring( 0 ,5 ) == "R_349" )
                // 产品数量/装箱率
                textBox8.Text = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox9 ,textBox3 ) ) ,4 ).ToString( );
            else if ( ac16.Substring( 0 ,5 ) == "R_347" )
                // 产品数量*每套用量(每套用量+物品余量/产品数量)
                textBox8.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTbes( textBox9 ,textBox3 ) ) ,4 ).ToString( );
            else if ( ac16.Substring( 0 ,5 ) == "R_339" || ac16.Substring( 0 ,5 ) == "R_285" )
                textBox8.Text = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox9 ,textBox3 ) ) ,4 ).ToString( );
        }
        //计算每套用量
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( ac16.Substring( 0 ,5 ) == "R_338" )
                // 产品数量/每张套数
                textBox3.Text = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox9 ,textBox8 ) ) ,7 ).ToString( );
            else if ( ac16.Substring( 0 ,5 ) == "R_342" )
                //产品数量*每套用量
                textBox3.Text = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox8 ,textBox9 ) ) ,7 ).ToString( );
            else if ( ac16.Substring( 0 ,5 ) == "R_341" )
                // 产品数量*每套用量(半成品规格长*宽*高*0.000001*每套部件数量)
                textBox3.Text = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox8 ,textBox9 ) ) ,7 ).ToString( );
            else if ( ac16.Substring( 0 ,5 ) == "R_343" )
                // 产品数量*每套用量(每套用量+采购余量/产品数量)
                textBox3.Text = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox8 ,textBox9 ) ) ,7 ).ToString( );
            else if ( ac16.Substring( 0 ,5 ) == "R_349" )
                // 产品数量/装箱率
                textBox3.Text = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox9 ,textBox8 ) ) ,7 ).ToString( );
            else if ( ac16.Substring( 0 ,5 ) == "R_347" )
                // 产品数量*每套用量(每套用量+物品余量/产品数量)
                textBox3.Text = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox8 ,textBox9 ) ) ,7 ).ToString( );
            else if ( ac16.Substring( 0 ,5 ) == "R_339" || ac16.Substring( 0 ,5 ) == "R_285" )
                textBox3.Text = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox9 ,textBox8 ) ) ,7 ).ToString( );
        }
        //COMBOBOX添加空行
        private DataTable row ( DataTable tab,string str )
        {
            DataRow row = tab.NewRow( );
            row["" + str + ""] = "";
            tab.Rows.Add( row );

            return tab;
        }
        //退库数量
        private void textBox13_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //表
        private void gridView2_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            DataRow row = gridView2 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            AC18 = row [ "AC18" ] . ToString ( );
            comboBox3 . Text = row [ "AC04" ] . ToString ( );
            comboBox8 . Text = row [ "AC05" ] . ToString ( );
            comboBox9 . Text = row [ "AC01" ] . ToString ( );
            comboBox10 . Text = row [ "AC02" ] . ToString ( );
            textBox8 . Text = row [ "AC10" ] . ToString ( );
            comboBox5 . Text = row [ "AC06" ] . ToString ( );
            textBox9 . Text = row [ "AC03" ] . ToString ( );
            textBox3 . Text = row [ "AC07" ] . ToString ( );
            textBox2 . Text = row [ "AC09" ] . ToString ( );
            textBox6 . Text = row [ "AC15" ] . ToString ( );
            AD1 = AC18;
            ac16 = row [ "AC16" ] . ToString ( );
            AC021 = string . IsNullOrEmpty ( row [ "AC21" ] . ToString ( ) ) == true ? DateTime . Now : Convert . ToDateTime ( row [ "AC21" ] . ToString ( ) );
            lookUpEdit1 . Text = row [ "AC19" ] . ToString ( );
            textBox13 . Text = row [ "AC20" ] . ToString ( );

            gridView1 . FocusedRowHandle = 0;

            gridv ( );
        }
        void gridv ( )
        {
            //find = SqlHelper.ExecuteDataTable( "SELECT AD01,AD04,AD02,AD03,AD05,AD06,AD07,AD08,AD09,AD11,AD12,AD13,AD14,(AC10-SUM(AD12)) U1,(AC03-SUM(AD05)) U2,(AC09*AC10-SUM(AD11*AD12)) U3 FROM R_PQAD A,R_PQAC B WHERE A.AD01=B.AC18 AND AD01=@AD01 GROUP BY AC10,AD01,AD04,AD02,AD03,AD05,AD06,AD07,AD08,AD09,AD11,AD12,AD13,AD14,AC03,AC09 ORDER BY AD01 DESC" ,new SqlParameter( "@AD01" ,AC18 ) );
            find = SqlHelper.ExecuteDataTable( "SELECT A.idx,AD01,AD04,AD02,AD03,AD05+ISNULL(AD20,0) AD05,AD06,AD07,AD08,CONVERT(FLOAT,AD09) AD09,CONVERT(FLOAT,AD11) AD11,CONVERT(FLOAT,AD12+ISNULL(AD21,0)) AD12,AD13,AD14,AD17,CONVERT(FLOAT,AC10+ISNULL(AC27,0)) AC10,CONVERT(FLOAT,AC03+ISNULL(AC26,0)) AC03,CONVERT(FLOAT,AC09) AC09,AC10+ISNULL(AC27,0)-ISNULL((SELECT SUM(AD12+ISNULL(AD21,0)) FROM R_PQAD WHERE idx<=A.idx AND AD01=@AD01),0) U1,CASE WHEN AC10+ISNULL(AC27,0)=0 THEN 0 ELSE (AC03+ISNULL(AC26,0))/(AC10+ISNULL(AC27,0))*(AC10+ISNULL(AC27,0)-ISNULL((SELECT SUM(AD12+ISNULL(AD21,0)) FROM R_PQAD WHERE idx<=A.idx AND AD01=@AD01),0)) END U2,AD18,AD19 FROM R_PQAD A,R_PQAC B WHERE A.AD01=B.AC18 AND AD01=@AD01 ORDER BY A.AD16,AD17" ,new SqlParameter( "@AD01" ,AC18 ) );
            //strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "WITH CET AS(SELECT INB002,INB003,SUM(CONVERT(FLOAT,INB014+CONVERT(VARCHAR,INB013))) INB013,SUM(CONVERT(FLOAT,INB016+CONVERT(VARCHAR,INB015))) INB015 FROM R_INA A INNER JOIN R_INB B ON A.INA001=B.INB001 WHERE INA003='出库' AND INB002='{0}' group by INB002,INB003)" ,AC18 );
            //strSql . AppendFormat ( ",CFT AS(SELECT INB002,SUM(CONVERT(FLOAT,INB014+CONVERT(VARCHAR,INB013))) INB013,SUM(CONVERT(FLOAT,INB016+CONVERT(VARCHAR,INB015))) INB015 FROM R_INA A INNER JOIN R_INB B ON A.INA001=B.INB001 WHERE INA003='入库' AND INB002='{0}' group by INB002" ,AC18 );
            //strSql . AppendFormat ( "),CHT AS(SELECT AC18,AC10+ISNULL(INB015,0) AC10,CONVERT(FLOAT,AC03)+ISNULL(INB013,0) AC03,CONVERT(FLOAT,AC09) AC09 FROM R_PQAC A LEFT JOIN CFT B ON A.AC18=B.INB002 WHERE AC18='{0}')," ,AC18 );
            //strSql . AppendFormat ( "CKT AS(SELECT idx,AD01,AD04,AD02,AD03,AD05+ISNULL(INB015,0) AD05,AD06,AD07,AD08,CONVERT(FLOAT,AD09) AD09,CONVERT(FLOAT,AD11) AD11,CONVERT(FLOAT,AD12)+ISNULL(INB013,0) AD12,AD13,AD14,AD17,AD18,AD19,AD16 FROM R_PQAD A LEFT JOIN CET B ON A.AD01=B.INB002 AND A.AD17=B.INB003 WHERE AD01='{0}')" ,AC18 );
            //strSql . AppendFormat ( "SELECT idx,AD01,AD04,AD02,AD03,AD05,AD06,AD07,AD08,AD09,AD11,AD12,AD13,AD14,AD17,AC10,AC03,AC09,AC10-ISNULL((SELECT SUM(AD12) FROM CKT WHERE idx<=A.idx AND AD01='{0}'),0) U1,CASE WHEN AC10=0 THEN 0 ELSE AC03/AC10*(AC10-ISNULL((SELECT SUM(AD12) FROM CKT WHERE idx<=A.idx AND AD01='{0}'),0)) END U2,AD18,AD19 FROM CKT A INNER JOIN CHT B ON A.AD01=B.AC18 WHERE AD01='{0}' ORDER BY A.AD16,AD17" ,AC18 );

            //find = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            gridControl1 .DataSource = find;
            //gridView1 . BestFitColumns ( );
            //assignMent( );
        }
        void assignMent ( )
        {
            //计算U1，U2，U3的值   由于三个字段不属于表   所以不能直接调用   需要在数据库加上以上三个字段   查询空字段即可
            //另  为了计算结果第一时间显示需要写到绑定数据源的后面   gridView1.SetRowCellValue()不能写到gridView1_CustomColumnDisplayText事件里面  会提示错误
            //下面的写法只适合编号相同   若编号不同则需判断  同编号才能用下面方法计算  一下是参考方法
            //if ( e.Column.Caption.Equals( "数量" ) || e.Column.Caption.Equals( "单价" ) )
            //{
            //    //设置结果值       
            //    gridView.SetRowCellValue( gridView.FocusedRowHandle ,gridView.Columns["合价"] ,gridView.GetFocusedRowCellValue( "小计" ).ToString( ) );
            //}
            decimal sum = 0, count = 0, sums = 0;
            decimal num = 0, numb = 0;
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["AD11"].ToString( ) ) || gridView1.GetDataRow( i )["AD11"].ToString( ) == "0" )
                    //num = num + 0;
                    num = 0;
                else
                    num = /*num +*/ Convert.ToDecimal( gridView1.GetDataRow( i )["AD11"].ToString( ) );
                if ( string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "AD12" ] . ToString ( ) ) || gridView1 . GetDataRow ( i ) [ "AD12" ] . ToString ( ) == "0" )
                    sum += /*sum +*/ 0;
                else
                {
                    sum = sum + Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "AD12" ] . ToString ( ) );
                    //sums = Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "AD12" ] . ToString ( ) );           
                }
                numb = numb + num * sum;
                if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["AD05"].ToString( ) ) || gridView1.GetDataRow( i )["AD05"].ToString( ) == "0" )
                    count = count + 0;
                else
                    count = count + Convert.ToDecimal( gridView1.GetDataRow( i )["AD05"].ToString( ) );

                decimal de = Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "AC10" ] . ToString ( ) );
                //U1 AC10-SUM(AD12)
                //U2 AC03-SUM(AD05)
                if ( i > 0 )
                {
                    if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["AC10"].ToString( ) ) && gridView1.GetDataRow( i )["AC10"].ToString( ) != "0" )
                    {
                        gridView1 .SetRowCellValue( i ,gridView1.Columns["U1"] ,Convert.ToDecimal( gridView1.GetDataRow( i )["AC10"].ToString( ) ) - sum );
                        //string sx = gridView1.GetDataRow( i )["U1"].ToString( );
                        //gridView1.GetDataRow( i )["U1"] = ( Convert.ToInt64( gridView1.GetDataRow( i )["AC10"].ToString( ) ) - sum ).ToString( );
                    }

                    
                    if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["AC03"].ToString( ) ) && gridView1.GetDataRow( i )["AC03"].ToString( ) != "0" )
                        //gridView1.GetDataRow( i )["U2"] = ( Convert.ToInt64( gridView1.GetDataRow( i )["AC03"].ToString( ) ) - count ).ToString( );
                        gridView1.SetRowCellValue( i ,gridView1.Columns["U2"] ,Convert.ToDecimal( gridView1.GetDataRow( i )["AC03"].ToString( ) ) - count );
                    if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["AC10"].ToString( ) ) && gridView1.GetDataRow( i )["AC10"].ToString( ) != "0" )
                    {
                        if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["AC09"].ToString( ) ) && gridView1.GetDataRow( i )["AC09"].ToString( ) != "0" )
                        {
                            //decimal SS = Convert.ToDecimal( gridView1.GetDataRow( i )["AC09"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["AC10"].ToString( ) );
                            //decimal SF = SS - numb;
                            gridView1.SetRowCellValue( i ,gridView1.Columns["U3"] ,Convert.ToDecimal( gridView1.GetDataRow( i )["AC09"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["AC10"].ToString( ) ) - numb );
                            //string SD = gridView1.GetDataRow( i )["U3"].ToString( );
                        }                        
                    }
                }
                else if ( i == 0 )
                {
                    if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["AC10"].ToString( ) ) && gridView1.GetDataRow( i )["AC10"].ToString( ) != "0" )
                    {
                        if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["AD12"].ToString( ) ) || gridView1.GetDataRow( i )["AD12"].ToString( ) != "0" )
                        {
                            gridView1.SetRowCellValue( i ,gridView1.Columns["U1"] ,Convert.ToDecimal( gridView1.GetDataRow( i )["AC10"].ToString( ) ) - Convert.ToDecimal( gridView1.GetDataRow( i )["AD12"].ToString( ) ) );
                        }
                    }
                    if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["AC03"].ToString( ) ) && gridView1.GetDataRow( i )["AC03"].ToString( ) != "0" )
                    {
                        if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["AD05"].ToString( ) ) || gridView1.GetDataRow( i )["AD05"].ToString( ) != "0" )
                            gridView1.SetRowCellValue( i ,gridView1.Columns["U2"] ,Convert.ToDecimal( gridView1.GetDataRow( i )["AC03"].ToString( ) ) - Convert.ToDecimal( gridView1.GetDataRow( i )["AD05"].ToString( ) ) );
                    }
                    if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["AC10"].ToString( ) ) && gridView1.GetDataRow( i )["AC10"].ToString( ) != "0" )
                    {
                        if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["AC09"].ToString( ) ) && gridView1.GetDataRow( i )["AC09"].ToString( ) != "0" )
                        {
                            if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["AD11"].ToString( ) ) || gridView1.GetDataRow( i )["AD11"].ToString( ) != "0" )
                            {
                                if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["AD12"].ToString( ) ) || gridView1.GetDataRow( i )["AD12"].ToString( ) != "0" )
                                    
                                    gridView1.SetRowCellValue( i ,gridView1.Columns["U3"] ,Convert.ToDecimal( gridView1.GetDataRow( i )["AC09"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["AC10"].ToString( ) ) - Convert.ToDecimal( gridView1.GetDataRow( i )["AD11"].ToString( ) ) * Convert.ToDecimal( gridView1.GetDataRow( i )["AD12"].ToString( ) ) );
                            }
                        }
                    }
                }
            }
        }
        private void gridView1_CustomColumnDisplayText ( object sender ,DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e )
        {
            //for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            //{
            //    if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["U0"].ToString( ) ) )
            //        gridView1.GetDataRow( i )["U0"] = 0;
            //    if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["U1"].ToString( ) ) )
            //        gridView1.GetDataRow( i )["U1"] = 0;
            //    if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["U2"].ToString( ) ) )
            //        gridView1.GetDataRow( i )["U2"] = 0;
            //    if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["U3"].ToString( ) ) )
            //        gridView1.GetDataRow( i )["U3"] = 0;
            //}
        }
        //计划采购数量
        private void textBox8_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox8 );
            textBox1.Text = Operation.MultiTwoTb( textBox8 ,textBox2 );
        }
        private void textBox8_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox8 );
        }
        private void textBox8_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox8.Text != "" && !DateDayRegise.tenForNumber( textBox8 ) )
            {
                this.textBox8.Text = "";
                MessageBox.Show( "只允许输入整数部分最多六位,小数部分最多四位,如999999.9999,请重新输入" );
            }
        }
        //单价
        private void textBox2_TextChanged ( object sender ,EventArgs e )
        {
            textBox1.Text = Operation.MultiTwoTb( textBox8 ,textBox2 );
            DateDayRegise.textChangeTb( textBox2 );
        }
        private void textBox2_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox2 );
        }
        private void textBox2_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox2.Text != "" && !DateDayRegise.sevenFourTb( textBox2 ) )
            {
                this.textBox2.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多四位,如999.9999,请重新输入" );
            }
        }
        //每套用量
        private void textBox3_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox3 );
        }
        private void textBox3_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox3 );
        }
        private void textBox3_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox3.Text != "" && !DateDayRegise.twelveSevenNumber( textBox3 ) )
            {
                this.textBox3.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多五位,如9999.9999999,请重新输入" );
            }
        }
        //计划采购产品数量
        private void textBox9_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //出库
        //实领数量
        private void textBox7_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //产品数量
        private void textBox10_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //每套用量
        private void textBox4_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox4 );
        }
        private void textBox4_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox4 );
        }
        private void textBox4_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox4.Text != "" && !DateDayRegise.eightTwoNumber( textBox4 ) )
            {
                this.textBox4.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多两位,如999.99,请重新输入" );
            }
        }
        //单价
        private void textBox5_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox5 );
        }
        private void textBox5_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox5 );
        }
        private void textBox5_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox5.Text != "" && !DateDayRegise.sevenFourTb( textBox5 ) )
            {
                this.textBox5.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多四位,如999.9999,请重新输入" );
            }
        }
        //出库单刷新
        private void btnRefresh_Click ( object sender ,EventArgs e )
        {
            DataRow row = gridView2 . GetFocusedDataRow ( );
            if ( row == null )
            {
                MessageBox . Show ( "请选择入库单记录" );
                return;
            }
            AC18 = row [ "AC18" ] . ToString ( );
            gridv ( );
        }
        #endregion

        #region 主体
        //查询
        R_Frm464Select rf = new R_Frm464Select( );
        protected override void select ( )
        {
            base.select( );

            //AC03-ISNULL(SUM(AD05),0) AC10
            strSql = new StringBuilder ( );
            //strSql . AppendFormat ( "WITH CET AS(SELECT INB002,INB003,SUM(CONVERT(FLOAT,INB014+CONVERT(VARCHAR,INB013))) INB013,SUM(CONVERT(FLOAT,INB016+CONVERT(VARCHAR,INB015))) INB015 FROM R_INA A INNER JOIN R_INB B ON A.INA001=B.INB001 WHERE INA003='出库' group by INB002,INB003),CFT AS(SELECT INB002,SUM(CONVERT(FLOAT,INB014+CONVERT(VARCHAR,INB013))) INB013,SUM(CONVERT(FLOAT,INB016+CONVERT(VARCHAR,INB015))) INB015 FROM R_INA A INNER JOIN R_INB B ON A.INA001=B.INB001 WHERE INA003='入库' group by INB002),CHT AS (SELECT AC18,AC01,AC02,AC04,AC05,AC03+ISNULL(INB015,0) AC03,AC10+ISNULL(INB013,0) AC10,AC09,AC11,AC16,AC22,AC24 FROM R_PQAC A LEFT JOIN CFT B ON A.AC18=B.INB002),CKT AS(SELECT AD01,AD12+ISNULL(INB013,0) AD12 FROM R_PQAD A LEFT JOIN CET B ON A.AD01=B.INB002 AND A.AD17=B.INB003)" );
            //strSql . AppendFormat ( "SELECT AC18,AC01,AC02,AC04,AC05,AC09,CONVERT(DECIMAL(11,0),AC03/AC10*(AC10-SUM(ISNULL(AD12,0)))) AC10,CONVERT(DECIMAL(18,0),AC10-ISNULL(SUM(AD12),0)) AC03,CONVERT(DECIMAL(18,0),AC09*AC10-ISNULL(SUM(AC09*AD12),0)) AC,AC16,AC11,AC22,AC24 FROM CHT LEFT JOIN CKT ON AC18=AD01 GROUP BY AC10,AC18,AC01,AC02,AC04,AC05,AC09,AC03,AC11,AC22,AC16,AC24 ORDER BY AC18 DESC,AC02" );
            strSql . AppendFormat ( "SELECT AC18,AC01,AC02,AC04,AC05,AC09,CONVERT(DECIMAL(11,0),CASE WHEN AC10+ISNULL(AC27,0)=0 THEN 0 ELSE (AC03+ISNULL(AC26,0))/(AC10+ISNULL(AC27,0))*(AC10+ISNULL(AC27,0)-SUM(ISNULL(AD12,0)+ISNULL(AD21,0))) END) AC10,CONVERT(DECIMAL(18,0),AC10+ISNULL(AC27,0)-ISNULL(SUM(AD12+ISNULL(AD21,0)),0)) AC03,CONVERT(DECIMAL(18,0),AC09*(AC10+ISNULL(AC27,0))-ISNULL(SUM(AC09*(AD12+ISNULL(AD21,0))),0)) AC,AC16,AC11,AC22,AC24,AC28 FROM R_PQAC LEFT JOIN R_PQAD ON AC18=AD01 GROUP BY AC10,AC18,AC01,AC02,AC04,AC05,AC09,AC03,AC11,AC22,AC16,AC24,ISNULL(AC26,0),ISNULL(AC27,0),AC28 ORDER BY AC18 DESC,AC02" );

            DataTable dr = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            if ( dr.Rows.Count < 1 )
                MessageBox.Show( "没有数据" );
            else
            {
                dr.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
                rf.gridControl1.DataSource = dr;
                rf.Text = "R_464 信息查询";
                rf.StartPosition = FormStartPosition.CenterScreen;
                rf.ShowDialog( );

                if ( rf.all.Count <= 0 )
                    gridControl2.DataSource = null;
                else
                {
                    string where = "1=1", str = "";
                    for ( int i = 0 ; i < rf.all.Count ; i++ )
                    {
                        str = str + "'" + rf.all[i] + "',";                                           
                    }
                    if ( str.Length > 0 )
                    {
                        str = str.Substring( 0 ,str.Length - 1 );
                        where = where + "AND AC18 IN (" + str + ")";
                    }
                    sto = SqlHelper.ExecuteDataTable( "SELECT AC01,AC02,AC03+ISNULL(AC26,0) AC03,AC04,AC05,AC06,CONVERT(FLOAT,CONVERT(DECIMAL(18,2),AC07)) AC07,CONVERT(FLOAT,AC09) AC09,CONVERT(FLOAT,AC10+ISNULL(AC27,0)) AC10,AC11,AC12,AC13,AC14,AC15,AC18,AC16,AC19,AC20,AC21,AC22,CONVERT(FLOAT,CONVERT(DECIMAL(18,4),AC10+ISNULL(AC27,0)-SUM(ISNULL(AD12,0)+ISNULL(AD21,0)))) AD,AC24,AC25,AC28 FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE " + where + " GROUP BY AC01,AC02,AC03,AC04,AC05,AC06,AC07,AC09,AC10,AC11,AC12,AC13,AC14,AC15,AC18,AC16,AC19,AC20,AC21,AC22,AC24,AC25,ISNULL(AC26,0),ISNULL(AC27,0),AC28" );
                    //strSql = new StringBuilder ( );
                    //strSql . AppendFormat ( "WITH CET AS(SELECT INB002,INB003,SUM(CONVERT(FLOAT,INB014+CONVERT(VARCHAR,INB013))) INB013,SUM(CONVERT(FLOAT,INB016+CONVERT(VARCHAR,INB015))) INB015 FROM R_INA A INNER JOIN R_INB B ON A.INA001=B.INB001 WHERE INA003='出库' group by INB002,INB003),CFT AS(SELECT INB002,SUM(CONVERT(FLOAT,INB014+CONVERT(VARCHAR,INB013))) INB013,SUM(CONVERT(FLOAT,INB016+CONVERT(VARCHAR,INB015))) INB015 FROM R_INA A INNER JOIN R_INB B ON A.INA001=B.INB001 WHERE INA003='入库' group by INB002),CHT AS(SELECT AC01,AC02,AC03+ISNULL(INB015,0) AC03,AC04,AC05,AC06,AC07,AC09,CONVERT(FLOAT,AC10)+ISNULL(INB013,0) AC10,AC11,AC12,AC13,AC14,AC15,AC18,AC16,AC19,AC20,AC21,AC22,AC24,AC25 FROM R_PQAC A LEFT JOIN CFT B ON A.AC18=B.INB002),CKT AS(SELECT AD01,AD12+ISNULL(INB013,0) AD12 FROM R_PQAD A LEFT JOIN CET B ON A.AD01=B.INB002 AND A.AD17=B.INB003)" );
                    //strSql . AppendFormat ( "SELECT AC01,AC02,AC03,AC04,AC05,AC06,CONVERT(FLOAT,CONVERT(DECIMAL(18,2),AC07)) AC07,CONVERT(FLOAT,AC09) AC09,AC10,AC11,AC12,AC13,AC14,AC15,AC18,AC16,AC19,AC20,AC21,AC22,CONVERT(FLOAT,CONVERT(DECIMAL(18,4),AC10-SUM(ISNULL(AD12,0)))) AD,AC24,AC25 FROM CHT A LEFT JOIN CKT B ON A.AC18=B.AD01 WHERE " + where + " GROUP BY AC01,AC02,AC03,AC04,AC05,AC06,AC07,AC09,AC10,AC11,AC12,AC13,AC14,AC15,AC18,AC16,AC19,AC20,AC21,AC22,AC24,AC25" );

                    //sto = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                    gridControl2.DataSource = sto;
                    //gridView2 . BestFitColumns ( );

                    toolSelect.Enabled = toolAdd.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolExport . Enabled = true;
                    toolPrint.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = false;
                } 
            }            
        }
        //新增
        string sign = "";
        protected override void add ( )
        {
            base.add( );

            //sign = "1";
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        //删除
        protected override void delete ( )
        {
            //base . delete ( );

            //if ( tabControl1 . SelectedTab == tabPage1 )
            //{
            //    //入库
            //    if ( string . IsNullOrEmpty ( AC18 ) )
            //    {
            //        MessageBox . Show ( "请选择需删除内容" );
            //        return;
            //    }
            //    //if ( gridView1 . RowCount > 0 )
            //    //{
            //        if ( MessageBox . Show ( "编号:" + AC18 + "已经有出库记录,如果删除此记录,系统将自动删除对应的出库记录,是否删除？" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . OK )
            //        {
            //            SQLString . Clear ( );
            //            strSql = new StringBuilder ( );
            //            strSql . AppendFormat ( "DELETE FROM R_PQAD WHERE AD01='{0}'" ,AC18 );
            //            SQLString . Add ( strSql ,null );
            //            strSql = new StringBuilder ( );
            //            strSql . AppendFormat ( "DELETE FROM R_PQAC WHERE AC18='{0}'" ,AC18 );
            //            SQLString . Add ( strSql ,null );
            //            SQLString . Add ( Drity . DrityOfComparation ( "R_464" ,this . Text ,Logins . username ,DateTime . Now ,AC18 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除入库" ) ,null );
            //            result = SqlHelper . ExecuteSqlTran ( SQLString );

            //            if ( result == false )
            //                MessageBox . Show ( "出库记录删除失败,请联系管理员处理" );
            //            else
            //            {
            //                MessageBox . Show ( "入库记录删除成功" );
            //                button3_Click ( null ,null );

            //                try
            //                {
            //                    DeleteOfAll ( ac16 );
            //                }
            //                catch { }
            //            }
            //        }
            //    //}
            //}
            //else if ( tabControl1 . SelectedTab == tabPage2 )
            //{
            //    //出库
            //    if ( string . IsNullOrEmpty ( AD1 ) )
            //    {
            //        MessageBox . Show ( "请选择需删除的内容" );
            //        return;
            //    }
            //    SQLString . Clear ( );
            //    strSql = new StringBuilder ( );
            //    strSql . AppendFormat ( "DELETE FROM R_PQAD WHERE idx='{0}'" ,id );
            //    SQLString . Add ( strSql ,null );
            //    SQLString . Add ( Drity . DrityOfComparation ( "R_464" ,this . Text ,Logins . username ,DateTime . Now ,AC18 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"删除" ,"删除出库" ) ,null );
            //    result = SqlHelper . ExecuteSqlTran ( SQLString );

            //    if ( result== false )
            //        MessageBox . Show ( "数据删除失败" );
            //    else
            //    {
            //        MessageBox . Show ( "数据删除成功" );
            //        int num = gridView1 . FocusedRowHandle;
            //        find . Rows . RemoveAt ( num );

            //        assignMent ( );
            //    }
            //}
            //else
            //    MessageBox . Show ( "请选择删除内容" );
        }
        void DeleteOfAll ( string contractNum )
        {
            string[] liStr = new string[] { };
            string strNum = "";
            if ( contractNum.Contains( "," ) )
            {
                liStr = contractNum.Split( ',' );
                for ( int i = 0 ; i < liStr.Length ; i++ )
                {
                    strNum = liStr[i];
                    UpdateOfContract( strNum );
                }
            }
            else
                UpdateOfContract( contractNum );
        }
        void UpdateOfContract ( string strNum )
        {
            if ( strNum.Contains( "R_338" ) )
                SqlHelper.ExecuteNonQuery( "UPDATE R_PQO SET JM109=0,JM110=0 WHERE JM01='" + strNum + "'" );
            if ( strNum.Contains( "R_341" ) )
                SqlHelper.ExecuteNonQuery( "UPDATE R_PQV SET PQV90=0,PQV91=0 WHERE PQV76='" + strNum + "'" );
            if ( strNum.Contains( "R_342" ) )
                SqlHelper.ExecuteNonQuery( "UPDATE R_PQAF SET AF080=0,AF081=0 WHERE AF001='" + strNum + "'" );
            if ( strNum.Contains( "R_343" ) )
                SqlHelper.ExecuteNonQuery( "UPDATE R_PQU SET PQU109=0,PQU110=0 WHERE PQU97='" + strNum + "'" );
            if ( strNum.Contains( "R_347" ) )
                SqlHelper.ExecuteNonQuery( "UPDATE R_PQS SET PJ102=0,PJ103=0 WHERE PJ92='" + strNum + "'" );
        }
        //更改
        protected override void update ( )
        {
            base.update( );

            sign = "2";

            toolSelect.Enabled = toolAdd.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        //保存
        protected override void save ( )
        {
            base . save ( );

            #region  入库
            if ( tabControl1 . SelectedTab == tabPage1 )
            {
                if ( string . IsNullOrEmpty ( comboBox3 . Text ) )
                {
                    MessageBox . Show ( "采购库存物资名称不可为空" );
                    return;
                }
                if ( string . IsNullOrEmpty ( comboBox10 . Text ) )
                {
                    MessageBox . Show ( "货号不可为空" );
                    return;
                }
                //if ( sign == "1" )
                //{
                //    AC18 = oddNumbers . purchaseContract ( "SELECT MAX(AC18) AC18 FROM R_PQAC WHERE AC18 LIKE 'P%'" ,"AC18" ,"P-" );
                //    build ( );

                //    strSql = new StringBuilder ( );
                //    SQLString . Clear ( );
                //    strSql . AppendFormat ( "INSERT INTO R_PQAC (AC18,AC02) VALUES ('{0}','{1}')" ,AC18 ,AC02 );
                //    SQLString . Add ( strSql ,null );
                //    SQLString . Add ( Drity . DrityOfComparation ( "R_464" ,this . Text ,Logins . username ,DateTime . Now ,AC18 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增入库" ) ,null );
                //    result = SqlHelper . ExecuteSqlTran ( SQLString );

                //    if ( result == false )
                //        MessageBox . Show ( "入库失败" );
                //    else
                //    {
                //        MessageBox . Show ( "已入库" );

                //        DataRow row = sto . NewRow ( );
                //        row [ "AC18" ] = AC18;
                //        row [ "AC01" ] = AC01;
                //        row [ "AC02" ] = AC02;
                //        row [ "AC04" ] = AC04;
                //        row [ "AC05" ] = AC05;
                //        row [ "AC06" ] = AC06;
                //        row [ "AC11" ] = AC011;
                //        row [ "AC12" ] = AC012;
                //        row [ "AC21" ] = AC021;
                //        sto . Rows . Add ( row );
                //    }
                //}
                //else 
                if ( sign . Equals ( "2" ) )
                {
                    if ( AC18 == "" )
                    {
                        MessageBox . Show ( "请选择编辑的内容" );
                        return;
                    }
                    build ( );
                    strSql = new StringBuilder ( );
                    SQLString . Clear ( );//,AC11='{9}',AC12='{10}'  ,AC011 ,AC012
                    strSql . AppendFormat ( "UPDATE R_PQAC SET AC02='{0}' WHERE AC18='{1}'" ,AC02 ,AC18 );
                    SQLString . Add ( strSql ,null );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_464" ,this . Text ,Logins . username ,DateTime . Now ,AC18 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑入库" ) ,null );
                    result = SqlHelper . ExecuteSqlTran ( SQLString );

                    if ( result == false )
                        MessageBox . Show ( "编辑数据失败" );
                    else
                    {
                        MessageBox . Show ( "成功编辑数据" );

                        int num = gridView2 . FocusedRowHandle;
                        DataRow row = sto . Rows [ num ];
                        row . BeginEdit ( );
                        row [ "AC02" ] = AC02;
                        row . EndEdit ( );
                    }
                }
            }
            #endregion

            /*

            #region  出库
            else if ( tabControl1 . SelectedTab == tabPage2 )
            {
                if ( string . IsNullOrEmpty ( comboBox3 . Text ) )
                {
                    MessageBox . Show ( "物料名称不可为空" );
                    return;
                }
                if ( string . IsNullOrEmpty ( comboBox2 . Text ) )
                {
                    MessageBox . Show ( "货号不可为空" );
                    return;
                }
                if ( sign . Equals ( "1" ) )
                {
                    
                    builds ( );
                    strSql = new StringBuilder ( );
                    SQLString . Clear ( );
                    strSql . AppendFormat ( "INSERT INTO R_PQAD (AD01,AD02,AD03,AD04,AD05,AD06,AD07,AD08,AD09,AD11,AD12,AD13,AD14,AD15,AD16) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}')" ,AD1 ,AD2 ,AD3 ,AD4 ,AD5 ,AD6 ,AD7 ,AD8 ,AD9 ,AD011 ,AD012 ,AD013 ,AD014 ,AD015 ,AD016 );
                    SQLString . Add ( strSql ,null );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_464" ,this . Text ,Logins . username ,DateTime . Now ,AC18 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"新增" ,"新增出库" ) ,null );
                    result = SqlHelper . ExecuteSqlTran ( SQLString );
                    if ( result == false )
                        MessageBox . Show ( "出库失败" );
                    else
                    {
                        MessageBox . Show ( "成功出库" );

                        DataRow row = find . NewRow ( );
                        row [ "AD01" ] = AD1;
                        row [ "AD02" ] = AD2;
                        row [ "AD03" ] = AD3;
                        row [ "AD04" ] = AD4;
                        row [ "AD05" ] = AD5;
                        row [ "AD06" ] = AD6;
                        row [ "AD07" ] = AD7;
                        row [ "AD08" ] = AD8;
                        row [ "AD09" ] = AD9;
                        row [ "AD11" ] = AD011;
                        row [ "AD12" ] = AD012;
                        row [ "AD13" ] = AD013;
                        row [ "AD14" ] = AD014;
                        find . Rows . Add ( row );

                        assignMent ( );
                    }
                }
                else if ( sign . Equals ( "2" ) )
                {
                    if ( id < 0 )
                    {
                        MessageBox . Show ( "请选择需要编辑的内容" );
                        return;
                    }
                    builds ( );
                    strSql = new StringBuilder ( );
                    SQLString . Clear ( );
                    strSql . AppendFormat ( "UPDATE R_PQAD SET AD02='{0}',AD03='{1}',AD04='{2}',AD06='{3}',AD07='{4}',AD08='{5}',AD13='{6}',AD14='{7}' WHERE idx='{8}'" ,AD2 ,AD3 ,AD4 ,AD6 ,AD7 ,AD8 ,AD013 ,AD014 ,id );
                    SQLString . Add ( strSql ,null );
                    SQLString . Add ( Drity . DrityOfComparation ( "R_464" ,this . Text ,Logins . username ,DateTime . Now ,AC18 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"编辑" ,"编辑出库" ) ,null );
                    result = SqlHelper . ExecuteSqlTran ( SQLString );

                    if ( result == false )
                        MessageBox . Show ( "编辑数据失败" );
                    else
                    {
                        MessageBox . Show ( "成功编辑数据" );
                        int num = gridView1 . FocusedRowHandle;
                        DataRow row = find . Rows [ num ];
                        row . BeginEdit ( );
                        row [ "AD01" ] = AD1;
                        row [ "AD02" ] = AD2;
                        row [ "AD03" ] = AD3;
                        row [ "AD04" ] = AD4;
                        row [ "AD05" ] = AD5;
                        row [ "AD06" ] = AD6;
                        row [ "AD07" ] = AD7;
                        row [ "AD08" ] = AD8;
                        row [ "AD09" ] = AD9;
                        row [ "AD11" ] = AD011;
                        row [ "AD12" ] = AD012;
                        row [ "AD13" ] = AD013;
                        row [ "AD14" ] = AD014;
                        row . EndEdit ( );

                        assignMent ( );
                    }
                }
            }
            #endregion

            */
            toolSelect . Enabled = toolAdd . Enabled = toolUpdate . Enabled = toolDelete . Enabled = true;
            toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolSave . Enabled = toolCancel . Enabled = false;
        }
        //取消
        protected override void cancel ( )
        {
            base.cancel( );

            toolSelect.Enabled = toolAdd.Enabled = toolUpdate.Enabled = toolDelete.Enabled = true;
            toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = false;
        }
        //Refresh
        private void button3_Click ( object sender ,EventArgs e )
        {
            string idxList = "";
            for ( int i = 0 ; i < gridView2.DataRowCount ; i++ )
            {
                if ( idxList == "" )
                    idxList = "'" + gridView2.GetDataRow( i )["AC18"].ToString( ) + "'";
                else
                    idxList = idxList + "," + "'" + gridView2.GetDataRow( i )["AC18"].ToString( ) + "'";
            }
            sto = SqlHelper.ExecuteDataTable( "SELECT AC01,AC02,AC03+ISNULL(AC26,0) AC03,AC04,AC05,AC06,CONVERT(FLOAT,CONVERT(DECIMAL(18,2),AC07)) AC07,CONVERT(FLOAT,AC09) AC09,CONVERT(FLOAT,AC10)+CONVERT(FLOAT,ISNULL(AC27,0)) AC10,AC11,AC12,AC13,AC14,AC15,AC18,AC16,AC19,AC20,AC21,AC22,CONVERT(FLOAT,CONVERT(DECIMAL(18,4),AC10+ISNULL(AC27,0)-SUM(ISNULL(AD12,0)+ISNULL(AD21,0)))) AD,AC25 FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC18 IN (" + idxList + ") GROUP BY AC01,AC02,AC03,AC04,AC05,AC06,AC07,AC09,AC10,AC11,AC12,AC13,AC14,AC15,AC18,AC16,AC19,AC20,AC21,AC22,AC25" );
            gridControl2.DataSource = sto;
            gridView2 . BestFitColumns ( );
        }
        protected override void export ( )
        {
            if ( tabControl1 . SelectedTab . Name == "tabPage1" )
                ViewExport . ExportToExcel ( this . Text + "入库" ,gridControl2 );
            if ( tabControl1 . SelectedTab . Name == "tabPage2" )
                ViewExport . ExportToExcel ( this . Text + "出库" ,gridControl1 );


            base . export ( );
        }
        #endregion

    }
}
