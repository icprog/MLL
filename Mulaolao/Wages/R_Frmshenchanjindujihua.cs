using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Windows . Forms;
using Mulaolao . Class;
using Mulaolao . Contract;
using StudentMgr;
using System . IO;
using FastReport . Export . Xml;
using System . Reflection;

namespace Mulaolao . Wages
{
    public partial class R_Frmshenchanjindujihua :FormChild
    {
        DataTable da;
        MulaolaoLibrary.ShenChanJinDuJiHuaLibrary model = null;
        MulaolaoBll.Bll.ShenChanJinDuJiHuaBll bll = null;
        bool result = false;
        string strWhere = "1=1", numCount = "";
        DataTable xj, tableQu, partName,partTableTwo,workShop,workShopOne;
        public string sav = "";
        string weihu = "", copy = "";
        string path= Environment.CurrentDirectory + "\\布局";
        string file = "\\R_046.XML";
        List<string> listIdx = new List<string>( );
        List<SplitContainer> listSp = new List<SplitContainer>( );
        int selectIdx=0;
        
        public R_Frmshenchanjindujihua ( )
        {
            //this.MdiParent = fm;
            InitializeComponent ( );

            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GridViewMoHuSelect . SetFilter ( bandedGridView2 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . bandedGridView1 ,this . bandedGridView2 } );

            FieldInfo fi = typeof ( DevExpress . Utils . Paint . XPaint ) . GetField ( "graphics" ,BindingFlags . Static | BindingFlags . NonPublic );
            fi . SetValue ( null ,new DrawXPaint ( ) );

            MulaolaoBll . UserInfoMation . tableName = this . Name;
            model = new MulaolaoLibrary . ShenChanJinDuJiHuaLibrary ( );
            bll = new MulaolaoBll . Bll . ShenChanJinDuJiHuaBll ( );
        }
        
        private void R_Frmshenchanjindujihua_Load ( object sender ,EventArgs e )
        {
            listSp . Clear ( );
            listSp . Add ( splitContainer1 );
            listSp . Add ( splitContainer2 );
            listSp . Add ( splitContainer3 );
            Ergodic . SpliClear ( listSp );
            gridControl1 . DataSource = null;
            Ergodic . SpliEnableFalse ( listSp );

            label46 . Visible = false;
            label107 . Visible = false;

            readColumn ( );

            if ( Directory . Exists ( path + file ) )
            {
                gridControl1 . MainView . RestoreLayoutFromXml ( path + file );
            }

            List<DevExpress . XtraGrid . Views . BandedGrid . BandedGridView> bandList = new List<DevExpress . XtraGrid . Views . BandedGrid . BandedGridView> ( );
            bandList . AddRange ( new DevExpress . XtraGrid . Views . BandedGrid . BandedGridView [ ] { bandedGridView1 ,bandedGridView2 } );
            foreach ( DevExpress . XtraGrid . Views . BandedGrid . BandedGridView band in bandList )
            {
                foreach ( DevExpress . XtraGrid . Columns . GridColumn colu in band . Columns )
                {
                    colu . OptionsFilter . FilterPopupMode = DevExpress . XtraGrid . Columns . FilterPopupMode . CheckedList;
                }
            }
        }

        #region Query
        //Query
        void assignMentAll ( )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND PQX33='" + model . PQX33 + "'";
            refresh ( );

            if ( xj != null && xj . Rows . Count > 0 )
            {
                model . PQX37 = string . IsNullOrEmpty ( xj . Rows [ 0 ] [ "PQX37" ] . ToString ( ) ) == true ? "T" : xj . Rows [ 0 ] [ "PQX37" ] . ToString ( );
                if ( model . PQX37 . Trim ( ) == "T" )
                    hideYes ( );
                else
                    hideNo ( );
                model . Idx = string . IsNullOrEmpty ( xj . Rows [ 0 ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( xj . Rows [ 0 ] [ "idx" ] . ToString ( ) );
                assign ( );
                assignMent ( );
            }
        }
        void assign ( )
        {
            model = bll . GetModel ( model . Idx );
            textBox68 . Text = model . PQX01;
            textBox1 . Text = model . PQX29;
            dateTimePicker4 . Value = string . IsNullOrEmpty ( model . PQX30 . ToString ( ) ) == true ? DateTime . Now : model . PQX30;
            textBox70 . Text = model . PQX31;
            textBox71 . Text = model . PQX32 . ToString ( );
            lookUpEdit2 . Text = model . PQX02;
            lookUpEdit3 . Text = model . PQX03;
            dateTimePicker7 . Value = string . IsNullOrEmpty ( model . PQX04 . ToString ( ) ) == true ? DateTime . Now : model . PQX04;
            dateTimePicker6 . Value = string . IsNullOrEmpty ( model . PQX05 . ToString ( ) ) == true ? DateTime . Now : model . PQX05;
            lookUpEdit4 . Text = model . PQX06;
            dateTimePicker1 . Value = string . IsNullOrEmpty ( model . PQX07 . ToString ( ) ) == true ? DateTime . Now : model . PQX07;
            lookUpEdit5 . Text = model . PQX08;
            dateTimePicker2 . Value = string . IsNullOrEmpty ( model . PQX09 . ToString ( ) ) == true ? DateTime . Now : model . PQX09;
            lookUpEdit6 . Text = model . PQX10;
            dateTimePicker3 . Value = string . IsNullOrEmpty ( model . PQX11 . ToString ( ) ) == true ? DateTime . Now : model . PQX11;
            dateTimePicker5 . Value = string . IsNullOrEmpty ( model . PQX12 . ToString ( ) ) == true ? DateTime . Now : model . PQX12;
        }
        SelectAll.ShenChanJinDuJiHuaAll query = new SelectAll.ShenChanJinDuJiHuaAll( );
        protected override void select ( )
        {
            base . select ( );

            query . StartPosition = FormStartPosition . CenterScreen;
            //query . PassDataBetweenForm += new SelectAll . ShenChanJinDuJiHuaAll . PassDataBetweenFormHandler ( query_PassDataBetweenForm );
            if ( query . ShowDialog ( ) == DialogResult . OK )
            {
                model . PQX33 =  query . getOdd;
                textBox68 . Tag = model . PQX33;
                model . PQX31 = query . getHNum;
                textBox68 . Text = query . Num;
                Ergodic . SpliEnableFalse ( listSp );
                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = false;
                sav = "2";
                copy = "";
                assignMentAll ( );
            }
        }
        //num
        R_Frmpenselect pl = new R_Frmpenselect( );
        private void button4_Click ( object sender ,EventArgs e )
        {
            DataTable dp = SqlHelper . ExecuteDataTable ( "SELECT PQF01,PQF03,PQF04,PQF06,PQF31,(SELECT DBA002 FROM TPADBA WHERE DBA001=PQF12) DBA002 FROM R_PQF ORDER BY PQF01 DESC" );
            if ( dp . Rows . Count < 1 )
                MessageBox . Show ( "产品BOM表中无信息" );
            else
            {
                dp . Columns . Add ( "check" ,System . Type . GetType ( "System.Boolean" ) );
                pl . gridControl1 . DataSource = dp;
                pl . str = "5";
                pl . Text = "R_046 信息查询";
                pl . PassDataBetweenForm += new R_Frmpenselect . PassDataBetweenFomrHandler ( pl_PassDataBetweenForm );
                pl . StartPosition = FormStartPosition . CenterScreen;
                pl . ShowDialog ( );
            }
        }
        private void pl_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            //textBox68.Text = e.ConOne;
            if ( e . ConOne . IndexOf ( "," ) > 0 )
                /*textBox68.Text*/
                model . PQX01 = string . Join ( "," ,e . ConOne . Split ( ',' ) . Distinct ( ) . ToArray ( ) );
            else
                /*textBox68.Text*/
                model . PQX01 = e . ConOne;
            textBox68 . Text = model . PQX01;
            if ( e . ConTwo . IndexOf ( "," ) > 0 )
                lookUpEdit2 . Text = string . Join ( "," ,e . ConTwo . Split ( ',' ) . Distinct ( ) . ToArray ( ) );
            else
                lookUpEdit2 . Text = e . ConTwo;
            model . PQX02 = lookUpEdit2 . Text;
            if ( e . ConTre . IndexOf ( "," ) > 0 )
                textBox70 . Text = string . Join ( "," ,e . ConTre . Split ( ',' ) . Distinct ( ) . ToArray ( ) );
            else
                textBox70 . Text = e . ConTre;
            model . PQX31 = textBox70 . Text;
            if ( e . ConFor . IndexOf ( "," ) > 0 )
                textBox1 . Text = string . Join ( "," ,e . ConFor . Split ( ',' ) . Distinct ( ) . ToArray ( ) );
            else
                textBox1 . Text = e . ConFor;
            model . PQX29 = e . ConFor;
            textBox71 . Text = e . ConFiv;
            if ( !string . IsNullOrEmpty ( e . ConFiv ) )
                model . PQX32 = Convert . ToInt64 ( e . ConFiv );
            else
                model . PQX32 = 0;
            if ( e . ConSix . IndexOf ( "," ) > 0 )
            {
                string [ ] str = e . ConSix . Split ( ',' );
                dateTimePicker4 . Value = Convert . ToDateTime ( str [ 0 ] );
            }
            else if ( !string . IsNullOrEmpty ( e . ConSix ) )
                dateTimePicker4 . Value = Convert . ToDateTime ( e . ConSix );
            model . PQX30 = dateTimePicker4 . Value;
        }
        #endregion

        #region Event
        void assgin ( )
        {
            if ( xj != null )
            {
                decimal u17 = 0, u7 = 0, u4 = 0, p34 = 0;
                for ( int i = 0 ; i < xj . Rows . Count ; i++ )
                {
                    if ( i < 1 )
                    {
                        //bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U12"] ,0 );
                        bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U17" ] ,0 );
                    }
                    else
                    {
                        //if ( !string.IsNullOrEmpty( xj.Rows[i]["PQX34"].ToString( ) ) && !string.IsNullOrEmpty( xj.Rows[i - 1]["PQX34"].ToString( ) ) )
                        //    bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U12"] ,Convert.ToInt64( xj.Rows[i - 1]["PQX34"].ToString( ) ) - Convert.ToInt64( xj.Rows[i]["PQX34"].ToString( ) ) );
                        if ( !string . IsNullOrEmpty ( xj . Rows [ i - 1 ] [ "U18" ] . ToString ( ) ) )
                            bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U17" ] ,-Convert . ToDecimal ( xj . Rows [ i - 1 ] [ "U18" ] . ToString ( ) ) );
                    }

                    u17 = string . IsNullOrEmpty ( xj . Rows [ i ] [ "U17" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( xj . Rows [ i ] [ "U17" ] . ToString ( ) );
                    u7 = string . IsNullOrEmpty ( xj . Rows [ i ] [ "U7" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( xj . Rows [ i ] [ "U7" ] . ToString ( ) );
                    u4 = string . IsNullOrEmpty ( xj . Rows [ i ] [ "U4" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( xj . Rows [ i ] [ "U4" ] . ToString ( ) );
                    p34 = string . IsNullOrEmpty ( xj . Rows [ i ] [ "PQX34" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( xj . Rows [ i ] [ "PQX34" ] . ToString ( ) );

                    if ( u7 == 0 )
                        bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U18" ] ,u17 );
                    else
                        bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U18" ] ,u17 + ( p34 - u7 * u4 ) / u7 );
                }

                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"PQX32" ,bandedGridView1 . Columns [ "PQX32" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U5" ,bandedGridView1 . Columns [ "U5" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"PQX22" ,bandedGridView1 . Columns [ "PQX22" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"PQX23" ,bandedGridView1 . Columns [ "PQX23" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U6" ,bandedGridView1 . Columns [ "U6" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U7" ,bandedGridView1 . Columns [ "U7" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U8" ,bandedGridView1 . Columns [ "U8" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U9" ,bandedGridView1 . Columns [ "U9" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"PQX24" ,bandedGridView1 . Columns [ "PQX24" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U11" ,bandedGridView1 . Columns [ "U11" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"PQX34" ,bandedGridView1 . Columns [ "PQX34" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U12" ,bandedGridView1 . Columns [ "U12" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U13" ,bandedGridView1 . Columns [ "U13" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U14" ,bandedGridView1 . Columns [ "U14" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U15" ,bandedGridView1 . Columns [ "U15" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U16" ,bandedGridView1 . Columns [ "U16" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U17" ,bandedGridView1 . Columns [ "U17" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U18" ,bandedGridView1 . Columns [ "U18" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U19" ,bandedGridView1 . Columns [ "U19" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U21" ,bandedGridView1 . Columns [ "U21" ] ,"{0}" );
                //bandedGridView1.ExpandAllGroups( );

                //( ( DevExpress.XtraGrid.GridSummaryItem ) bandedGridView1.GroupSummary[bandedGridView1.GroupSummary.Count - 1] ).DisplayFormat = "{0:N0}";
            }
        }
        void everyGx ( string part )
        {
            partName = bll . GetDataTablePart ( strWhere,part );
            partTableTwo = bll . GetDataTablePartFor509 ( strWhere ,part );
            workShop = bll . GetDataTableWork ( textBox68 . Text );
            if ( comboBoxEdit1 . Text . Equals ( "厂内" ) /*|| comboBoxEdit1 . Text . Equals ( "承揽" )*/ )
            {
                gridLookUpEdit1 . Properties . DataSource = partName;
                gridLookUpEdit1 . Properties . DisplayMember = "PQX14";
                gridLookUpEdit1 . Properties . ValueMember = "PQX14";

                if ( workShop != null && workShop . Rows . Count > 0 )
                {
                    cmbWorkShop . Properties . Items . Clear ( );
                    cmbWorkShop . Text = string . Empty;
                    for ( int i = 0 ; i < workShop . Rows . Count ; i++ )
                    {
                        cmbWorkShop . Properties . Items . Add ( workShop . Rows [ i ] [ "GX02" ] . ToString ( ) );
                    }
                }
            }
            else
            {
                gridLookUpEdit1 . Properties . DataSource = partTableTwo;
                gridLookUpEdit1 . Properties . DisplayMember = "PQX14";
                gridLookUpEdit1 . Properties . ValueMember = "PQX14";
             
            }
        }
        void every ( )
        {
            DataTable biao = bll . GetDataTableAll ( strWhere );
            //零件代码
            //comboBox2 . DataSource = biao . DefaultView . ToTable ( true ,"PQX17" );
            //comboBox2 . DisplayMember = "PQX17";
            //增减工序道差
            comboBox4 . DataSource = biao . DefaultView . ToTable ( true ,"PQX18" );
            comboBox4 . DisplayMember = "PQX18";
            //部件工序道数
            comboBox3 . DataSource = biao . DefaultView . ToTable ( true ,"PQX19" );
            comboBox3 . DisplayMember = "PQX19";
        }
        void columnQuery ( )
        {
            if ( !string . IsNullOrEmpty ( textBox68 . Text ) )
            {
                strWhere = "";
                if ( textBox68 . Text . Contains ( "," ) )
                {
                    string [ ] str = textBox68 . Text . Split ( new char [ ] { ',' } );
                    foreach ( string st in str )
                    {
                        if ( strWhere == "" )
                            strWhere = "'" + st + "'";
                        else
                            strWhere = strWhere + "," + "'" + st + "'";
                    }
                }
                else
                    strWhere = "'" + textBox68 . Text + "'";
            }
            else
                return;

            every ( );
        }
        private void textBox68_TextChanged ( object sender ,EventArgs e )
        {
            columnQuery ( );
            DataTable parats = bll . GetDataTableParts ( strWhere );
            lookUpEdit9 . Properties . DataSource = parats;
            lookUpEdit9 . Properties . DisplayMember = "PQX13";
        }
        private void textBox70_TextChanged ( object sender ,EventArgs e )
        {

        }
        private void lookUpEdit10_TextChanged ( object sender ,EventArgs e )
        {
           
        }
        private void comboBox4_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay . intgra ( e );
        }
        private void comboBox3_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay . intgra ( e );
        }
        private void comboBox6_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay . intgra ( e );
        }
        private void comboBox5_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay . intgra ( e );
        }
        private void comboBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay . intgra ( e );
        }
        private void comboBox1_LostFocus ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( comboBox1 . Text ) )
            {
                if ( string . IsNullOrEmpty ( gridLookUpEdit1 . Text ) )
                    MessageBox . Show ( "请选择零件名称" );
                else
                {
                    model . PQX14 = gridLookUpEdit1 . Text;
                    model . PQX16 = string . IsNullOrEmpty ( comboBox1 . Text ) == true ? 0 : Convert . ToInt32 ( comboBox1 . Text );

                    result = false;
                    result = bll . ExistsId ( model );
                    if ( result == true )
                    {
                        comboBox1 . Text = "";
                        MessageBox . Show ( "工序序号不可以重复,请重新输入" );
                    }
                }
            }
        }
        //FormClosing
        private void R_Frmshenchanjindujihua_FormClosing ( object sender ,FormClosingEventArgs e )
        {
            if ( toolSave . Enabled )
            {
                cancel ( );
            }

            if ( !Directory . Exists ( path ) )
            {
                Directory . CreateDirectory ( path );
            }
            gridControl1 . MainView . SaveLayoutToXml ( path + file );
        }
        //Table   
        string px14 = "", px15 = "";
        private void bandedGridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            selectIdx = bandedGridView1 . FocusedRowHandle;
            if ( selectIdx < 0 )
                return;
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                model . Idx = Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                assignMent ( );
                if ( !string . IsNullOrEmpty ( row [ "PQX26" ] . ToString ( ) ) )
                {
                    if ( Convert . ToDateTime ( row [ "PQX26" ] . ToString ( ) ) > DateTime . MinValue && Convert . ToDateTime ( row [ "PQX26" ] . ToString ( ) ) < DateTime . MaxValue )
                        dateTimePicker9 . Value = Convert . ToDateTime ( row [ "PQX26" ] . ToString ( ) );
                    else
                        dateTimePicker9 . Value = MulaolaoBll . Drity . GetDt ( );
                }
                else
                    dateTimePicker9 . Value = MulaolaoBll . Drity . GetDt ( );
                textBox5 . Text = row [ "PQX22" ] . ToString ( );
                textBox6 . Text = row [ "PQX23" ] . ToString ( );
            }
        }
        void assignMent ( )
        {
            model = bll . GetModel ( model . Idx );
            if ( model == null )
                return;
            comboBoxEdit1 . Text = model . PQX38;
            lookUpEdit9 . Text = model . PQX13;
            gridLookUpEdit1 . Text = model . PQX14;
            cmbWorkShop . Text = model . PQX15;
            comboBox1 . Text = model . PQX16 . ToString ( );
            comboBox2 . Text = model . PQX17;
            comboBox4 . Text = model . PQX18 . ToString ( );
            comboBox3 . Text = model . PQX19 . ToString ( );
            lookUpEdit7 . Text = model . PQX20;
            lookUpEdit8 . Text = model . PQX21;
            //textBox5.Text = model.PQX22.ToString( );
            //textBox6.Text = model.PQX23.ToString( );
            textBox2 . Text = model . PQX24 . ToString ( );
            dateTimePicker8 . Value = string . IsNullOrEmpty ( model . PQX25 . ToString ( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : model . PQX25;
            //dateTimePicker9.Value = string.IsNullOrEmpty( model.PQX26.ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : model.PQX26;
            textBox3 . Text = model . PQX27;
            textBox4 . Text = model . PQX36 . ToString ( );
            dateTimePicker4 . Value = model . PQX30;
            px14 = model . PQX14;
            px15 = model . PQX15;
        }
        private void bandedGridView1_CustomColumnDisplayText ( object sender ,DevExpress . XtraGrid . Views . Base . CustomColumnDisplayTextEventArgs e )
        {
            // 日期显示格式
            PQX30 . DisplayFormat . FormatString = "MM月dd日";
            PQX25 . DisplayFormat . FormatString = "MM月dd日";
            PQX26 . DisplayFormat . FormatString = "MM月dd日";
            U3 . DisplayFormat . FormatString = "MM月dd日";
        }
        private void bandedGridView2_CustomColumnDisplayText ( object sender ,DevExpress . XtraGrid . Views . Base . CustomColumnDisplayTextEventArgs e )
        {
            // 日期显示格式
            PQX30_ONE . DisplayFormat . FormatString = "MM月dd日";
            PQX25_ONE . DisplayFormat . FormatString = "MM月dd日";
            PQX26_ONE . DisplayFormat . FormatString = "MM月dd日";
            U3_ONE . DisplayFormat . FormatString = "MM月dd日";
        }
        private void bandedGridView2_CustomDrawRowFooterCell ( object sender ,DevExpress . XtraGrid . Views . Grid . FooterCellCustomDrawEventArgs e )
        {
            //U24_ONE = U9_ONE / U20_ONE;
            int sumOne = 0;
            decimal avgOne = 0M;
            if ( e . Column == U24_ONE )
            {
                sumOne = this . bandedGridView2 . GetRowFooterCellText ( e . RowHandle ,this . U5_ONE ) == string . Empty ? 0 : Convert . ToInt32 ( this . bandedGridView2 . GetRowFooterCellText ( e . RowHandle ,this . U5_ONE ) );
                avgOne = this . bandedGridView2 . GetRowFooterCellText ( e . RowHandle ,this . U20_ONE ) == string . Empty ? 0 : Convert . ToDecimal ( this . bandedGridView2 . GetRowFooterCellText ( e . RowHandle ,this . U20_ONE ) );
                e . Info . DisplayText = avgOne == 0 ? 0 . ToString ( ) : ( sumOne / avgOne ) . ToString ( "f0" );
            }
        }
        //groupby
        private void bandedGridView1_CustomSummaryCalculate ( object sender ,DevExpress . Data . CustomSummaryEventArgs e )
        {
            //if (((DevExpress.XtraGrid.GridSummaryItem)e.Item).FieldName.CompareTo( "U0" ).ToString( ) == "")
            //{
            //    ar = (DateTime)(PQF31.SummaryItem.SummaryValue);
            //    br = (DateTime)(PQX25.SummaryItem.SummaryValue);

            //    TimeSpan ts = ar - br;
            //    string[] str = ts.ToString( ).Split( new char[1] { '.' } );
            //    string st = str[0];
            //    e.TotalValue = st;
            //}
        }
        //CellMerge
        private void bandedGridView1_CellMerge ( object sender ,DevExpress . XtraGrid . Views . Grid . CellMergeEventArgs e )
        {
            //    //部件名称  列名
            //    string str1 = bandedGridView1.GetDataRow( e.RowHandle1 )["PQX13"].ToString( );
            //    string str2 = bandedGridView1.GetDataRow( e.RowHandle2 )["PQX13"].ToString( );
            //    if (str1 == str2)
            //    {
            //        e.Merge = true;
            //        e.Handled = true;
            //    }
            //    else
            //    {
            //        e.Merge = false;
            //        e.Handled = true;
            //    }

            //    string str3 = bandedGridView1.GetDataRow( e.RowHandle1 )["PQX14"].ToString( );
            //    string str4 = bandedGridView1.GetDataRow( e.RowHandle2 )["PQX14"].ToString( );
            //    if (str3 == str4)
            //    {
            //        e.Merge = true;
            //        e.Handled = true;
            //    }
            //    else
            //    {
            //        e.Merge = false;
            //        e.Handled = true;
            //    }
        }
        private void contextMenuStrip1_ItemClicked ( object sender ,ToolStripItemClickedEventArgs e )
        {
            //隐藏：部件名称、工序生产周期、产品生产周期、曾减工序道差、实与计投产日差、当日欠产量、今日止累应完成产量、累欠产量、日均欠产量
            if ( ( e . ClickedItem ) . Name == "MenuItemHide" )
            {
                model . PQX37 = "T";
                bll . UpdateHideYes ( model );
                hideYes ( );
            }
            else if ( ( e . ClickedItem ) . Name == "MenuItemTwo" )
            {
                model . PQX37 = "F";
                bll . UpdateHideYes ( model );
                hideNo ( );
            }
        }
        void hideYes ( )
        {
            gridBand21 . Visible = PQX19 . Visible = PQX18 . Visible = U0 . Visible = U20 . Visible = U15 . Visible = PQX22 . Visible = PQX23 . Visible = U6 . Visible = PQX30 . Visible = U21 . Visible = PQX34 . Visible = gridBand26 . Visible = false;
            PQX19_ONE . Visible = PQX18_ONE . Visible = U0_ONE . Visible = gridBand66 . Visible = U15_ONE . Visible = PQX22_ONE . Visible = PQX23_ONE . Visible = U6_ONE . Visible = PQX30_ONE . Visible = U21_ONE . Visible = PQX34_ONE . Visible = U14_ONE . Visible = gridBand60 . Visible = false;
        }
        void hideNo ( )
        {
            gridBand21 . Visible = PQX19 . Visible = PQX18 . Visible = U0 . Visible = U20 . Visible = U15 . Visible = PQX22 . Visible = PQX23 . Visible = U6 . Visible = PQX30 . Visible = U21 . Visible = PQX34 . Visible = gridBand26 . Visible = true;
            PQX19_ONE . Visible = PQX18_ONE . Visible = U0_ONE . Visible = gridBand66 . Visible = U15_ONE . Visible = PQX22_ONE . Visible = PQX23_ONE . Visible = U6_ONE . Visible = PQX30_ONE . Visible = U21_ONE . Visible = PQX34_ONE . Visible = U14_ONE . Visible = gridBand60 . Visible = true;
        }
        //零件名称
        private void gridLookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( !string . IsNullOrEmpty ( gridLookUpEdit1 . Text ) && partName != null && partName . Select ( "PQX14='" + gridLookUpEdit1 . Text + "'" ) . Length > 0 )
                textBox4 . Text = partName . Select ( "PQX14='" + gridLookUpEdit1 . Text + "'" ) [ 0 ] [ "PQX36" ] . ToString ( );

            //textBox4 . Text = gridLookUpEdit1 . EditValue . ToString ( );

            DataRow row = View1 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            textBox4 . Text = row [ "PQX36" ] . ToString ( );


            if ( string . IsNullOrEmpty ( comboBoxEdit1 . Text ) || comboBoxEdit1 . Text . Equals ( "厂内" ) )
            {

                workShopOne = bll . GetDataTableWork ( textBox68 . Text ,gridLookUpEdit1 . Text );
                if ( workShopOne != null && workShopOne . Rows . Count > 0 )
                {
                    cmbWorkShop . Properties . Items . Clear ( );
                    cmbWorkShop . Text = string . Empty;
                    for ( int i = 0 ; i < workShopOne . Rows . Count ; i++ )
                    {
                        cmbWorkShop . Properties . Items . Add ( workShopOne . Rows [ i ] [ "GX02" ] . ToString ( ) );
                    }
                }
            }
        }
        private void comboBoxEdit1_SelectedValueChanged ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( comboBoxEdit1 . Text ) )
                return;
            columnQuery ( );

            DataTable parats = bll . GetDataTableParts ( strWhere );
            lookUpEdit9 . Properties . DataSource = parats;
            lookUpEdit9 . Properties . DisplayMember = "PQX13";

            //if ( parats == null || parats . Rows . Count < 1 )
            //    everyGx ( string . Empty );

            cmbWorkShop . Properties . Items . Clear ( );
            if ( comboBoxEdit1 . Text . Equals ( "承揽" ) )
            {
                cmbWorkShop . Properties . Items . AddRange ( new string [ ] { "夹料" ,"雕刻" ,"绕锯" ,"冲床" ,"砂庋" ,"喷漆" ,"涂布" ,"丝印" ,"热转印" ,"移印" ,"画线" ,"滚漆" } );
            }
            else if ( comboBoxEdit1 . Text . Equals ( "采购" ) )
            {
                cmbWorkShop . Properties . Items . AddRange ( new string [ ] { "采购" } );
            }
            else if ( comboBoxEdit1 . Text . Equals ( "委外" ) )
            {
                cmbWorkShop . Properties . Items . AddRange ( new string [ ] { "收白坯" } );
            }
            else if ( comboBoxEdit1 . Text . Equals ( "客供" ) )
            {
                cmbWorkShop . Properties . Items . AddRange ( new string [ ] { "采购" ,"客供件","委外" } );
            }
        }
        private void lookUpEdit9_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( lookUpEdit9 . Text ) )
                everyGx ( string . Empty );
            else
            {
                columnQuery ( );
                everyGx ( lookUpEdit9 . Text );
            }
        }
        private void bandedGridView1_DoubleClick ( object sender ,EventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            //if ( row [ "PQX38" ] . ToString ( ) . Equals ( "委外" ) || row [ "PQX38" ] . ToString ( ) . Equals ( "承揽" ) || row [ "PQX38" ] . ToString ( ) . Equals ( "采购" ) )
            //{
            row [ "PQX21" ] = textBox68 . Text;
            SelectAll . FormShenchenJinDu from = new SelectAll . FormShenchenJinDu ( row );
            if ( from . ShowDialog ( ) == DialogResult . OK )
            {
                model . PQX24 = from . getNums;
                row [ "PQX21" ] = lookUpEdit8 . Text;
                row [ "PQX24" ] = model . PQX24;
                row [ "PQX34" ] = Convert . ToInt32 ( row [ "PQX34" ] ) + ( from . getCNum );
                gridControl1 . RefreshDataSource ( );
            }
            //}
        }
        private void textBox71_TextChanged ( object sender ,EventArgs e )
        {
            int num = 0;
            if ( !string . IsNullOrEmpty ( textBox71 . Text ) && int . TryParse ( textBox71 . Text ,out num ) )
            {
                foreach ( DataRow row in xj . Rows )
                {
                    row [ "PQX32" ] = num;
                }
                gridControl1 . RefreshDataSource ( );
            }
        }
        #endregion

        #region Main        
        protected override void add ( )
        {
            base . add ( );

            Ergodic . SpliClear ( listSp );
            gridControl1 . DataSource = null;
            //gridControl2.DataSource = null;
            Ergodic . SpliEnableTrue ( listSp );
            textBox3 . Enabled = false;

            sav = "1";
            //dateTimePicker4.Enabled = false;
            label107 . Visible = false;
            label46 . Visible = false;

            model . PQX33 = oddNumbers . purchaseContract ( "SELECT MAX(AJ012) AJ012 FROM R_PQAJ" ,"AJ012" ,"R_046-" );
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;
        }
        void dele ( )
        {
            result = false;
            result = bll . DeleteOddNumList ( model . PQX33 );
            if ( result == false )
                MessageBox . Show ( "删除数据失败" );
            else
            {
                MessageBox . Show ( "成功删除数据" );

                Ergodic . SpliClear ( listSp );
                gridControl1 . DataSource = null;
                Ergodic . SpliEnableFalse ( listSp );

                toolSelect . Enabled = toolAdd . Enabled = true;
                toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolSave . Enabled = toolCancel . Enabled = toolcopy . Enabled = false;
                label46 . Visible = false;
                label107 . Visible = false;
            }
        }
        protected override void delete ( )
        {
            base . delete ( );

            result = false;
            result = bll . ExistsReview ( model ,this . Text );
            if ( result == true )
            {
                if ( Logins . number == "MLL-0001" )
                    dele ( );
                else
                    MessageBox . Show ( "单号:" + model . PQX33 + "的单据状态为执行,不允许删除" );
            }
            else
                dele ( );
        }
        protected override void update ( )
        {
            base . update ( );

            result = false;
            result = bll . ExistsReview ( model ,this . Text );
            if ( result == true )
                MessageBox . Show ( "单号:" + model . PQX33 + "的单据状态为执行,不允许更改" );
            else
            {
                Ergodic . SpliEnableTrue ( listSp );

                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = false;
                toolSave . Enabled = toolCancel . Enabled = true;
                //dateTimePicker4.Enabled = false;
                textBox3 . Enabled = false;
            }
        }
        protected override void revirw ( )
        {
            base . revirw ( );

            Reviews ( "PQX33" ,model . PQX33 ,"R_PQX" ,this ,model . PQX01 ,"R_046" ,false ,false ,MulaolaoBll . Drity . GetDt ( )/*,"JM06" ,"JM87" ,"R_PQO" ,"JM01" ,JM01 ,ord ,textBox68.Text,"R_338"*/ );
            SpecialPowers sp = new SpecialPowers ( );
            result = false;
            result = bll . ExistsReview ( model ,this . Text );
            if ( result == true )
                label107 . Visible = true;
            else
                label107 . Visible = false;
        }
        DataTable dtPrint,dtPrintTwo;
        protected override void print ( )
        {
            if ( bandedGridView2 . RowCount < 1 )
                return;

            printOrExport ( );
            DataSet ds = new DataSet ( );
            dtPrint . TableName = "TableOne";
            dtPrintTwo . TableName = "TableTwo";
            ds . Tables . Add ( dtPrint );
            ds . Tables . Add ( dtPrintTwo );
            FastReport . Report report = new FastReport . Report ( );
            report . Load ( Application . StartupPath + "\\R_046.frx" );
            report . RegisterData ( ds );
            report . Show ( );

            base . print ( );
        }
        protected override void export ( )
        {
            printOrExport ( );
            DataSet ds = new DataSet ( );
            dtPrint . TableName = "TableOne";
            dtPrintTwo . TableName = "TableTwo";
            ds . Tables . Add ( dtPrint );
            ds . Tables . Add ( dtPrintTwo );
            FastReport . Report report = new FastReport . Report ( );
            report . Load ( Application . StartupPath + "\\R_046.frx" );
            report . RegisterData ( ds );

            report . Prepare ( );
            XMLExport reports = new XMLExport ( );
            reports . Export ( report );

            base . export ( );
        }
        void printOrExport ( )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND PQX33='" + model . PQX33 + "'";

            string strIdx = string . Empty;
            DataRow row;
            for ( int i = 0 ; i < bandedGridView2 . RowCount ; i++ )
            {
                row = bandedGridView2 . GetDataRow ( i );
                if ( row != null )
                {
                    if ( strIdx == string . Empty )
                        strIdx = bandedGridView2 . GetDataRow ( i ) [ "idx" ] . ToString ( );
                    else
                        strIdx = strIdx + "," + bandedGridView2 . GetDataRow ( i ) [ "idx" ] . ToString ( );
                }
            }
            if ( !string . IsNullOrEmpty ( strIdx ) )
                strWhere = strWhere + " AND idx in (" + strIdx + ")";
            model . PQX26 = Convert . ToDateTime ( dateTimePicker9 . Value . ToString ( "yyyy-MM-dd" ) );
            if ( string . IsNullOrEmpty ( textBox68 . Text ) )
                numCount = "''";
            else
            {
                numCount = "";
                if ( !textBox68 . Text . Contains ( "," ) )
                    numCount = "'" + textBox68 . Text + "'";
                else
                {
                    string [ ] str = textBox68 . Text . Split ( new char [ ] { ',' } );
                    if ( str . Length > 0 )
                    {
                        foreach ( string s in str )
                        {
                            if ( numCount == "" )
                                numCount = "'" + s + "'";
                            else
                                numCount = numCount + "," + "'" + s + "'";
                        }
                    }
                    else
                        numCount = "''";
                }
            }
            dtPrint = bll . printTableOne ( strWhere ,model . PQX26 ,numCount );
            dtPrintTwo = bll . GetDataTablePrint ( textBox68 . Text );
        }
        private void adds ( )
        {
            Ergodic . SpliEnableFalse ( listSp );
            toolSelect . Enabled = toolAdd . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolcopy . Enabled = true;
            toolSave . Enabled = toolCancel . Enabled = false;
            weihu = "";
            copy = "";
            label46 . Visible = false;
        }
        protected override void save ( )
        {
            base . save ( );

            if ( string . IsNullOrEmpty ( textBox68 . Text ) )
            {
                MessageBox . Show ( "请选择流水号" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit2 . Text ) )
            {
                MessageBox . Show ( "请选择业务员" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit3 . Text ) )
            {
                MessageBox . Show ( "请选择跟单组长" );
                return;
            }

            build ( );

            DataTable der = bll . GetDataTableToOdd ( model . PQX33 );

            if ( weihu . Equals ( "1" ) )
            {
                if ( string . IsNullOrEmpty ( textBox3 . Text ) )
                {
                    MessageBox . Show ( "请填写维护意见" );
                    return;
                }
                if ( der . Rows . Count < 1 )
                    MessageBox . Show ( "单号:" + model . PQX33 + "\n\r的记录不存在,请核实后再维护" );
                else
                {
                    model . PQX27 = textBox3 . Text;
                    model . PQX28 = der . Rows [ 0 ] [ "PQX28" ] . ToString ( ) + "[" + Logins . username + MulaolaoBll . Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "]";

                    result = false;
                    result = bll . UpdateWeiHu ( model );
                    if ( result == false )
                        MessageBox . Show ( "录入数据失败" );
                    else
                    {
                        MessageBox . Show ( "成功录入数据" );

                        adds ( );
                    }
                }
            }
            else
            {
                if ( der . Rows . Count > 0 )
                {
                    result = false;
                    result = bll . UpdateAll ( model );
                    if ( result == true )
                    {
                        if ( copy . Equals ( "1" ) )
                        {
                            int resu = bll . checkPart ( model . PQX01 ,xj );
                            if ( resu == 1 )
                                MessageBox . Show ( "436中不存在此流水内容,已删除046本流水数据,请填写436数据之后重新填写046" );
                            else if ( resu == 5 )
                                MessageBox . Show ( "请重新保存,436中不存在此流水内容,删除046本流水数据失败,请填写436数据之后重新填写046" );
                            else if ( resu == 2 )
                            {
                                MessageBox . Show ( "成功录入数据" );
                                adds ( );
                            }
                            else if ( resu == 3 )
                            {
                                MessageBox . Show ( "成功录入数据,且已删除046中生产来源是厂内且不存在436的零件和工序信息,请重新查询" );
                                adds ( );
                            }
                            else if ( resu == 4 )
                                MessageBox . Show ( "删除046中生产来源是厂内且不存在436的零件和工序信息失败,请重新保存" );
                        }
                        else
                        {
                            MessageBox . Show ( "成功录入数据" );
                            adds ( );
                        }
                    }
                    else
                        MessageBox . Show ( "录入数据失败" );
                }
            }
        }
        protected override void cancel ( )
        {
            base . cancel ( );

            if ( sav == "1" && weihu != "1" )
            {
                try
                {
                    bll . DeleteOddNumList ( model . PQX33 );
                }
                catch
                {
                }
                finally
                {
                    Ergodic . SpliClear ( listSp );
                    gridControl1 . DataSource = null;
                    //gridControl2.DataSource = null;                   
                    toolSelect . Enabled = toolAdd . Enabled = true;
                    toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolSave . Enabled = toolCancel . Enabled = toolcopy . Enabled = false;
                    label46 . Visible = false;
                }
            }
            else if ( sav == "2" || weihu == "1" )
            {
                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolReview . Enabled = toolcopy . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = false;
            }
            Ergodic . SpliEnableFalse ( listSp );
            textBox3 . Enabled = false;
        }
        protected override void maintain ( )
        {
            base . maintain ( );

            //DataTable del = SqlHelper.ExecuteDataTable( "SELECT RES03,RES05,RES06,DBA012,CX02 FROM TPADBA A,R_REVIEW B,R_REVIEWS C,R_MLLCXMC D WHERE A.DBA001=B.RE01 AND B.RE01=C.RES03 AND C.RES01=D.CX01 AND RES06=@RES06 AND CX02=@CX02", new SqlParameter( "@RES06", PQX33 ), new SqlParameter( "@CX02", this.Text ) );
            result = false;
            result = bll . ExistsReview ( model ,this . Text );
            if ( result == true )
            {
                Ergodic . SpliEnableTrue ( listSp );
                toolAdd . Enabled = toolSelect . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = false;
                toolSave . Enabled = toolCancel . Enabled = true;

                weihu = "1";

                textBox3 . Enabled = true;

                //dateTimePicker4.Enabled =  false;
            }
            else
                MessageBox . Show ( "此单据没有被执行,只需更改即可,无需维护" );
        }
        protected override void copys ( )
        {
            base . copys ( );

            result = false;
            result = bll . GetDataCopy ( model . PQX33 );
            if ( result == true )
            {
                model . PQX33 = oddNumbers . purchaseContract ( "SELECT MAX(AJ012) AJ012 FROM R_PQAJ" ,"AJ012" ,"R_046-" );
                result = false;
                result = bll . UpdateCopy ( model . PQX33 );
                if ( result == true )
                {
                    MessageBox . Show ( "成功复制数据" );

                    Ergodic . SpliClear ( listSp );
                    gridControl1 . DataSource = null;
                    //gridControl2.DataSource = null;
                    Ergodic . SpliEnableTrue ( listSp );

                    toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolcopy . Enabled = false;
                    toolSave . Enabled = toolCancel . Enabled = true;
                    textBox3 . Enabled = false;
                    sav = "1";
                    copy = "1";
                    weihu = "";
                    textBox3 . Enabled = false;
                    label46 . Visible = true;
                    label107 . Visible = false;
                    //dateTimePicker4.Enabled = false;
                    assignMentAll ( );
                }
                else
                {
                    MessageBox . Show ( "复制数据失败" );
                    bll . DeleteCopy ( );
                }
            }
            else
                MessageBox . Show ( "复制数据失败" );
        }
        #endregion

        #region Table
        //Add      
        void build ( )
        {
            model . PQX01 = textBox68 . Text;
            model . PQX29 = textBox1 . Text;
            model . PQX30 = dateTimePicker4 . Value;
            model . PQX31 = textBox70 . Text;
            model . PQX32 = string . IsNullOrEmpty ( textBox71 . Text ) == true ? 0 : Convert . ToInt64 ( textBox71 . Text );
            model . PQX02 = lookUpEdit2 . Text;
            model . PQX03 = lookUpEdit3 . Text;
            model . PQX04 = dateTimePicker7 . Value;
            model . PQX05 = dateTimePicker6 . Value;
            model . PQX06 = lookUpEdit4 . Text;
            model . PQX07 = dateTimePicker1 . Value;
            model . PQX08 = lookUpEdit5 . Text;
            model . PQX09 = dateTimePicker2 . Value;
            model . PQX10 = lookUpEdit6 . Text;
            model . PQX11 = dateTimePicker3 . Value;
            model . PQX12 = dateTimePicker5 . Value;
            model . PQX13 = lookUpEdit9 . Text;
            model . PQX14 = gridLookUpEdit1 . Text;
            model . PQX15 = cmbWorkShop . Text;
            model . PQX16 = string . IsNullOrEmpty ( comboBox1 . Text ) == true ? 0 : Convert . ToInt32 ( comboBox1 . Text );
            model . PQX17 = comboBox2 . Text;
            model . PQX18 = string . IsNullOrEmpty ( comboBox4 . Text ) == true ? 0 : Convert . ToInt32 ( comboBox4 . Text );
            model . PQX19 = string . IsNullOrEmpty ( comboBox3 . Text ) == true ? 0 : Convert . ToInt32 ( comboBox3 . Text );
            model . PQX20 = lookUpEdit7 . Text;
            model . PQX21 = lookUpEdit8 . Text;
            //model.PQX22 = string.IsNullOrEmpty( textBox5.Text ) == true ? 0 : Convert.ToInt64( textBox5.Text );
            //model.PQX23 = string.IsNullOrEmpty( textBox6.Text ) == true ? 0 : Convert.ToInt64( textBox6.Text );
            model . PQX24 = string . IsNullOrEmpty ( textBox2 . Text ) == true ? 0 : Convert . ToInt64 ( textBox2 . Text );
            model . PQX25 = dateTimePicker8 . Value;
            model . PQX26 = dateTimePicker9 . Value;
            model . PQX27 = textBox3 . Text;
            decimal tbox = 0;
            decimal . TryParse ( textBox4 . Text ,out tbox );
            model . PQX36 = Convert . ToInt32 ( Math . Round ( tbox ,0 ) );
            //if ( string.IsNullOrEmpty( model.PQX34.ToString( ) ) )
            //    model.PQX34 = model.PQX24;
            //else
            //    model.PQX34 = model.PQX34 + model.PQX24;
            //PQX034 = PQX034 + PQX024;
            model . PQX38 = comboBoxEdit1 . Text;
        }
        void add_One ( )
        {
            //strWhere = "1=1";
            //strWhere = strWhere + " AND idx='" + model.Idx + "'";
            //DataRow row = bll.GetDataRowAll( strWhere ,model.PQX26 );
            //xj.Rows.Add( row );
            //DataView dv = xj.DefaultView;
            //dv.Sort= "PQX14,PQX17 ASC,PQX16 DESC";
            //xj = dv.ToTable( );
            DataRow row = xj . NewRow ( );
            row [ "idx" ] = model . Idx;
            row [ "PQX13" ] = model . PQX13;
            row [ "PQX14" ] = model . PQX14;
            row [ "PQX15" ] = model . PQX15;
            row [ "PQX16" ] = model . PQX16;
            row [ "PQX17" ] = model . PQX17;
            row [ "PQX18" ] = model . PQX18;
            row [ "PQX19" ] = model . PQX19;
            row [ "PQX20" ] = model . PQX20;
            row [ "PQX21" ] = model . PQX21;
            //row["PQX22"] = model.PQX22;
            //row["PQX23"] = model.PQX23;
            row [ "PQX24" ] = model . PQX24;
            row [ "PQX25" ] = model . PQX25;
            row [ "PQX26" ] = model . PQX26;
            row [ "PQX32" ] = model . PQX32;
            row [ "PQX30" ] = model . PQX30;
            //row [ "PQX34" ] = model . PQX34;
            row [ "PQX36" ] = model . PQX36;
            row [ "PQX38" ] = model . PQX38;
            xj . Rows . Add ( row );
            gridControl1 . RefreshDataSource ( );
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( textBox68 . Text ) )
            {
                MessageBox . Show ( "请选择流水号" );
                return;
            }
            if ( string . IsNullOrEmpty ( gridLookUpEdit1 . Text ) )
            {
                MessageBox . Show ( "请选择零件名称" );
                return;
            }
            if ( string . IsNullOrEmpty ( cmbWorkShop . Text ) )
            {
                MessageBox . Show ( "请选择工序名称" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit2 . Text ) )
            {
                MessageBox . Show ( "请选择业务员" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit3 . Text ) )
            {
                MessageBox . Show ( "请选择跟单组长" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox1 . Text ) )
            {
                MessageBox . Show ( "请输入工序序号" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBoxEdit1 . Text ) )
            {
                MessageBox . Show ( "请选择生产来源" );
                return;
            }

            build ( );

            result = bll . Exists ( model );
            if ( result == true )
                MessageBox . Show ( "已经存在\n\r单号:" + model . PQX33 + "\n\r零件名称:" + model . PQX14 + "\n\r工序名称:" + model . PQX15 + "\n\r的数据,请核实后再录入" );
            else
            {
                model . Idx = bll . Add ( model );
                if ( model . Idx > 0 )
                {
                    MessageBox . Show ( "录入数据成功" );
                    if ( xj == null )
                    {
                        strWhere = "1=1";
                        strWhere = strWhere + " AND PQX33='" + model . PQX33 + "'";
                        refresh ( );
                    }
                    else
                        add_One ( );
                }
                else
                    MessageBox . Show ( "录入数据失败" );
            }
        }
        //Edit
        void upd ( )
        {
            bandedGridView1 . CloseEditor ( );
            bandedGridView1 . UpdateCurrentRow ( );
            DataRow row;
            List<DataRow> rows = new List<DataRow> ( );
            string workEr = string . Empty, workErPr = string . Empty, workNum = string . Empty, worlNumPr = string . Empty;
            int j = 0, k = 0;
            for ( int i = selectIdx + 1 ; i < bandedGridView1 . RowCount ; i++ )
            {
                row = bandedGridView1 . GetDataRow ( i );
                if ( row != null && row [ "PQX17" ] . Equals ( model . PQX17 ) )
                {
                    j++;
                    row [ "PQX25" ] = model . PQX25 . AddDays ( j );
                    rows . Add ( row );
                }

                row = bandedGridView1 . GetDataRow ( i - 1 );
                if ( row != null )
                    worlNumPr = row [ "PQX17" ] . ToString ( );

                row = bandedGridView1 . GetDataRow ( i );
                if ( row != null )
                {
                    workNum = row [ "PQX17" ] . ToString ( );
                    if ( !workNum . Equals ( model . PQX17 ) )
                    {
                        if ( !workNum . Equals ( worlNumPr ) )
                            k = 0;
                        k++;
                        row [ "PQX25" ] = model . PQX25 . AddDays ( k - 1 );
                        rows . Add ( row );
                    }
                }
            }
            gridControl1 . RefreshDataSource ( );
            model . PQX01 = textBox68 . Text;
            bll . EditWork ( rows ,model );
        }
        void up ( )
        {
            bandedGridView1 . CloseEditor ( );
            bandedGridView1 . UpdateCurrentRow ( );
            DataRow row = xj . Select ( "idx=" + model . Idx + "" ) [ 0 ];
            row . BeginEdit ( );
            row [ "PQX13" ] = model . PQX13;
            row [ "PQX14" ] = model . PQX14;
            row [ "PQX15" ] = model . PQX15;
            row [ "PQX16" ] = model . PQX16;
            row [ "PQX17" ] = model . PQX17;
            row [ "PQX18" ] = model . PQX18;
            row [ "PQX19" ] = model . PQX19;
            row [ "PQX20" ] = model . PQX20;
            row [ "PQX21" ] = model . PQX21;
            row [ "PQX24" ] = model . PQX24;
            row [ "PQX25" ] = model . PQX25;
            row [ "PQX26" ] = model . PQX26;
            row [ "PQX30" ] = model . PQX30;
            row [ "PQX32" ] = model . PQX32;
            //row [ "PQX34" ] = model . PQX34;
            row [ "PQX36" ] = model . PQX36;
            row [ "PQX38" ] = model . PQX38;
            row [ "U0" ] = ( model . PQX30- model . PQX25  ) . Days;
            row [ "U1" ] = ( model . PQX30-model . PQX25  ) . Days - model . PQX19 + model . PQX16 - model . PQX18;
            row [ "U3" ] = MulaolaoBll . Drity . GetDt ( ) . AddDays ( ( model . PQX30 - MulaolaoBll . Drity . GetDt ( ) ) . Days - model . PQX19 + model . PQX16 - model . PQX18 );
            row . EndEdit ( );
            gridControl1 . DataSource = xj;
            gridControl1 . RefreshDataSource ( );
            upd ( );
        }
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( textBox68 . Text ) )
            {
                MessageBox . Show ( "请选择流水号" );
                return;
            }
            if ( string . IsNullOrEmpty ( gridLookUpEdit1 . Text ) )
            {
                MessageBox . Show ( "请选择零件名称" );
                return;
            }
            if ( string . IsNullOrEmpty ( cmbWorkShop . Text ) )
            {
                MessageBox . Show ( "请选择工序名称" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit2 . Text ) )
            {
                MessageBox . Show ( "请选择业务员" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit3 . Text ) )
            {
                MessageBox . Show ( "请选择跟单组长" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox1 . Text ) )
            {
                MessageBox . Show ( "请输入工序序号" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBoxEdit1 . Text ) )
            {
                MessageBox . Show ( "请选择生产来源" );
                return;
            }
            build ( );

            int num = bandedGridView1 . FocusedRowHandle;
            if ( model . PQX14 == px14 && model . PQX15 == px15 )
            {
                result = false;
                result = bll . Update ( model );
                if ( result == true )
                {
                    MessageBox . Show ( "成功编辑数据" );
                    //strWhere = "1=1";
                    //strWhere = strWhere + " AND PQX33='" + model.PQX33 + "'";
                    //refresh( );
                    up ( );
                    //bandedGridView1.FocusedRowHandle = num;
                }
                else
                    MessageBox . Show ( "编辑数据失败" );
            }
            else
            {
                result = false;
                result = bll . Exists ( model );
                if ( result == true )
                    MessageBox . Show ( "单号: " + model . PQX33 + "\n\r零件名称:" + model . PQX14 + "\n\r工序名称:" + model . PQX15 + " \n\r的记录已经存在,不允许重复录入" );
                else
                {
                    result = false;
                    result = bll . Update ( model );
                    if ( result == true )
                    {
                        MessageBox . Show ( "成功编辑数据" );
                        //strWhere = "1=1";
                        //strWhere = strWhere + " AND PQX33='" + model.PQX33 + "'";
                        //refresh( );
                        up ( );
                        //bandedGridView1.FocusedRowHandle = num;
                    }
                    else
                        MessageBox . Show ( "编辑数据失败" );
                }
            }
        }
        //Delete
        private void button5_Click( object sender, EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;
            result = false;
            result = bll.Delete( model.Idx );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                //strWhere = "1=1";
                //strWhere = strWhere + " AND PQX33='" + model.PQX33 + "'";
                //refresh( );
                int num = bandedGridView1.FocusedRowHandle;
                xj.Rows.Remove( xj.Select( "idx='" + model.Idx + "'" )[0] );
                if ( num >= 1 )
                    bandedGridView1.FocusedRowHandle = num - 1;
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        //Update
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND PQX33='" + model . PQX33 + "'";
            model . PQX26 = Convert . ToDateTime ( dateTimePicker9 . Value . ToString ( "yyyy-MM-dd" ) );
            updatePrict ( );
            editOtherCo ( model . PQX26 );
            xj = bll . GetDataTableAll ( strWhere ,model . PQX26 ,numCount );
            gridControl1 . DataSource = xj;
            assgin ( );
            assginOne ( );
            //columnQuery ( );
            readColumn ( );
        }
        void readColumn ( )
        {
            //salesman
            lookUpEdit2 . Properties . DataSource = bll . GetDataTableSalesman ( );
            lookUpEdit2 . Properties . DisplayMember = "DBA002";
            lookUpEdit2 . Properties . ValueMember = "DBA001";
            //Naman
            lookUpEdit3 . Properties . DataSource = bll . GetDataTableNaman ( );
            lookUpEdit3 . Properties . DisplayMember = "DBA002";
            lookUpEdit3 . Properties . ValueMember = "DBA001";
            da = bll . GetDataTablePlan ( );
            //Plan person
            lookUpEdit4 . Properties . DataSource = da . Copy ( );
            lookUpEdit4 . Properties . DisplayMember = "DBA002";
            lookUpEdit4 . Properties . ValueMember = "DBA001";
            //填表人
            lookUpEdit5 . Properties . DataSource = da . Copy ( );
            lookUpEdit5 . Properties . DisplayMember = "DBA002";
            lookUpEdit5 . Properties . ValueMember = "DBA001";
            //审核人
            lookUpEdit6 . Properties . DataSource = da . Copy ( );
            lookUpEdit6 . Properties . DisplayMember = "DBA002";
            lookUpEdit6 . Properties . ValueMember = "DBA001";
            //生产责任人
            lookUpEdit7 . Properties . DataSource = da . Copy ( );
            lookUpEdit7 . Properties . DisplayMember = "DBA002";
            lookUpEdit7 . Properties . ValueMember = "DBA001";
            //工序组长
            lookUpEdit8 . Properties . DataSource = bll . GetDataTableNaman ( );
            lookUpEdit8 . Properties . DisplayMember = "DBA002";
            lookUpEdit8 . Properties . ValueMember = "DBA001";
        }
        void refresh ( )
        {
            if ( string . IsNullOrEmpty ( strWhere ) )
                strWhere = "1=1";
            updatePrict ( );
            editOtherCo ( MulaolaoBll . Drity . GetDt ( ) );
            xj = bll . GetDataTable ( strWhere ,numCount );
            gridControl1 . DataSource = xj;
            /*
             U14=[今日止累计已生产量] - [今日止累计应完成计划产量]
             Abs([PQX34] - [U13])
             */
            assgin ( );
            columnQuery ( );
            //everyGx ( );
            //assginOne ( );
            //every( );
        }
        void updatePrict ( )
        {
            if ( string.IsNullOrEmpty( textBox68.Text ) )
            {
                numCount = "''";
                return;
            }
            numCount = "";
            if ( !textBox68.Text.Contains( "," ) )
                numCount = "'" + textBox68.Text + "'";
            else
            {
                string[] str = textBox68.Text.Split( new char[] { ',' } );
                if ( str.Length > 0 )
                {
                    foreach ( string s in str )
                    {
                        if ( numCount == "" )
                            numCount = "'" + s + "'";
                        else
                            numCount = numCount + "," + "'" + s + "'";
                    }
                }
                else
                    numCount = "''";
            }

            DataTable dl = bll.GetDataTablePrice( numCount );
            if ( dl == null || dl.Rows.Count < 1 )
                return;
            else
            {
                DataTable dk = bll.GetDataTablePri( numCount );
                if ( dk == null || dk.Rows.Count < 1 )
                    return;
                else
                {
                    for ( int i = 0 ; i < dl.Rows.Count ; i++ )
                    {
                        model.PQX14 = dl.Rows[i]["PQX14"].ToString( );
                        if ( dk.Select( "PQX14='" + model.PQX14 + "'" ).Length > 0 )
                        {
                            string sk = dk.Select( "PQX14='" + model.PQX14 + "'" )[0]["GS10"].ToString( );
                            if ( !string.IsNullOrEmpty( sk ) )
                            {
                                model.PQX36 = ( int ) Convert.ToDecimal( sk );
                                bll.UpdatePrice( model );
                            }
                        }
                    }
                }
            }
        }
        void editOtherCo ( DateTime dt )
        {
            bll . EditPQX34 ( numCount ,model . PQX33 );
            bll . EditToOtherColumn ( numCount ,model . PQX33  ,dt );
            bll . EditToOtherColumnForU2 ( numCount ,model . PQX33 ,dt );
            bll . EditToOtherColumnForU14 ( numCount ,model . PQX33 ,dt );
            bll . EditToOtherColounForU12 ( numCount ,model . PQX33 );
            bll . EditToOtherColumnForU29 ( numCount ,model . PQX33 ,dt );
            bll . EditToOtherColumnForU9 ( numCount ,model . PQX33 );
        }
        //copyBatch
        SelectAll.ShenChanJinDuJiHuaCopyPartAll copyQuery = new SelectAll.ShenChanJinDuJiHuaCopyPartAll( );
        private void button6_Click ( object sender ,EventArgs e )
        {
            model . PQX01 = textBox68 . Text;
            listObTain( );
            copyQuery.Text = "R_046 复制";
            copyQuery.sign = "copy";
            copyQuery.model = model;
            copyQuery.listIdx = listIdx;
            copyQuery.StartPosition = FormStartPosition.CenterScreen;
            copyQuery.ShowDialog( );
        }
        //EditBatch
        private void button7_Click ( object sender ,EventArgs e )
        {
            listObTain( );
            copyQuery.Text = "R_046 编辑";
            copyQuery.sign = "edit";
            copyQuery.model = model;
            copyQuery.listIdx = listIdx;
            model . PQX01 = textBox68 . Text;
            copyQuery.oddNum = model.PQX33;
            copyQuery.textBox7.Text = comboBox4.Text;
            copyQuery.textBox9.Text = cmbWorkShop.Text;
            copyQuery . textBox6 . Text = dateTimePicker4 . Value . ToString ( "yyyy年MM月dd日" );
            //string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "PQX30" ] . ToString ( ) ) == true ? dateTimePicker4 . Value . ToString ( "yyyy年MM月dd日" ) : Convert . ToDateTime ( bandedGridView1 . GetDataRow ( 0 ) [ "PQX30" ] . ToString ( ) ) . ToString ( "yyyy年MM月dd日" );
            copyQuery.StartPosition = FormStartPosition.CenterScreen;
            copyQuery.ShowDialog( );
        }
        //DeleteBatch
        private void button8_Click ( object sender ,EventArgs e )
        {
            listObTain( );

            strWhere = "''";
            foreach ( string id in listIdx )
            {
                //strWhere =  "," + "'" + id + "'";
                strWhere = strWhere + "," + id;
            }
            if (! string.IsNullOrEmpty( strWhere ) )
            {
                result = false;
                result = bll.DeleteIdxList( strWhere );
                if ( result == true )
                {
                    MessageBox.Show( "删除数据成功" );
                    foreach ( string idx in listIdx )
                    {
                        model.Idx = string.IsNullOrEmpty( idx ) == true ? 0 : Convert.ToInt32( idx );
                        xj.Rows.Remove( xj.Select( "idx='" + model.Idx + "'" )[0] );
                    }
                }
                else
                    MessageBox.Show( "删除数据失败" );
            }
        }
        void listObTain ( )
        {
            listIdx.Clear( );
            for ( int i = 0 ; i < xj.Select( "PQX14='" + model.PQX14 + "'" ).Length ; i++ )
            {
                listIdx.Add( xj.Select( "PQX14='" + model.PQX14 + "'" )[i]["idx"].ToString( ) );
            }
        }
        //Production supporting table
        private void button9_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND PQX33='" + model.PQX33 + "'";
            model.PQX26 = Convert.ToDateTime( dateTimePicker9.Value.ToString( "yyyy-MM-dd" ) );
            if ( string.IsNullOrEmpty( textBox68.Text ) )
                numCount = "''";
            else
            {
                numCount = "";
                if ( !textBox68.Text.Contains( "," ) )
                    numCount = "'" + textBox68.Text + "'";
                else
                {
                    string[] str = textBox68.Text.Split( new char[] { ',' } );
                    if ( str.Length > 0 )
                    {
                        foreach ( string s in str )
                        {
                            if ( numCount == "" )
                                numCount = "'" + s + "'";
                            else
                                numCount = numCount + "," + "'" + s + "'";
                        }
                    }
                    else
                        numCount = "''";
                }
            }
            tableQu = bll.GetDataTableProduct( strWhere ,model.PQX26 ,numCount );
            gridControl2.DataSource = tableQu;
            assginTwo( );
        }
        void assginTwo ( )
        {
            if ( tableQu != null )
            {
                decimal u17 = 0, u7 = 0, u4 = 0, p34 = 0;
                for ( int i = 0 ; i < tableQu . Rows . Count ; i++ )
                {
                    if ( i < 1 )
                    {
                        //bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U12" ] ,0 );
                        bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U17" ] ,0 );
                    }
                    else
                    {
                        //if ( !string . IsNullOrEmpty ( tableQu . Rows [ i ] [ "PQX34" ] . ToString ( ) ) && !string . IsNullOrEmpty ( tableQu . Rows [ i - 1 ] [ "PQX34" ] . ToString ( ) ) )
                        //    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U12" ] ,Convert . ToInt64 ( tableQu . Rows [ i - 1 ] [ "PQX34" ] . ToString ( ) ) - Convert . ToInt64 ( tableQu . Rows [ i ] [ "PQX34" ] . ToString ( ) ) );
                        if ( !string . IsNullOrEmpty ( tableQu . Rows [ i - 1 ] [ "U18" ] . ToString ( ) ) )
                            bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U17" ] ,-Convert . ToDecimal ( tableQu . Rows [ i - 1 ] [ "U18" ] . ToString ( ) ) );
                    }

                    u17 = string . IsNullOrEmpty ( tableQu . Rows [ i ] [ "U17" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQu . Rows [ i ] [ "U17" ] . ToString ( ) );
                    u7 = string . IsNullOrEmpty ( tableQu . Rows [ i ] [ "U7" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQu . Rows [ i ] [ "U7" ] . ToString ( ) );
                    u4 = string . IsNullOrEmpty ( tableQu . Rows [ i ] [ "U4" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQu . Rows [ i ] [ "U4" ] . ToString ( ) );
                    p34 = string . IsNullOrEmpty ( tableQu . Rows [ i ] [ "PQX34" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tableQu . Rows [ i ] [ "PQX34" ] . ToString ( ) );

                    if ( u7 == 0 )
                        bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U18" ] ,u17 );
                    else
                        bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U18" ] ,u17 + ( p34 - u7 * u4 ) / u7 );
                }

                bandedGridView2 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"PQX32" ,bandedGridView2 . Columns [ "PQX32" ] ,"{0}" );
                bandedGridView2 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U5" ,bandedGridView2 . Columns [ "U5" ] ,"{0}" );
                bandedGridView2 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"PQX22" ,bandedGridView2 . Columns [ "PQX22" ] ,"{0}" );
                bandedGridView2 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"PQX23" ,bandedGridView2 . Columns [ "PQX23" ] ,"{0}" );
                bandedGridView2 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U6" ,bandedGridView2 . Columns [ "U6" ] ,"{0}" );
                bandedGridView2 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U7" ,bandedGridView2 . Columns [ "U7" ] ,"{0}" );
                bandedGridView2 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U8" ,bandedGridView2 . Columns [ "U8" ] ,"{0}" );
                bandedGridView2 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U9" ,bandedGridView2 . Columns [ "U9" ] ,"{0}" );
                bandedGridView2 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"PQX24" ,bandedGridView2 . Columns [ "PQX24" ] ,"{0}" );
                bandedGridView2 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U11" ,bandedGridView2 . Columns [ "U11" ] ,"{0}" );
                bandedGridView2 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"PQX34" ,bandedGridView2 . Columns [ "PQX34" ] ,"{0}" );
                bandedGridView2 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U12" ,bandedGridView2 . Columns [ "U12" ] ,"{0:N1}" );
                bandedGridView2 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U13" ,bandedGridView2 . Columns [ "U13" ] ,"{0}" );
                bandedGridView2 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U14" ,bandedGridView2 . Columns [ "U14" ] ,"{0}" );
                bandedGridView2 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U15" ,bandedGridView2 . Columns [ "U15" ] ,"{0}" );
                bandedGridView2 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U16" ,bandedGridView2 . Columns [ "U16" ] ,"{0}" );
                bandedGridView2 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U17" ,bandedGridView2 . Columns [ "U17" ] ,"{0:N1}" );
                bandedGridView2 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U18" ,bandedGridView2 . Columns [ "U18" ] ,"{0:N1}" );
                bandedGridView2 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U19" ,bandedGridView2 . Columns [ "U19" ] ,"{0}" );
                bandedGridView2 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Sum ,"U21_ONE" ,bandedGridView2 . Columns [ "U21_ONE" ] ,"{0}" );
                u17 = U5_ONE . SummaryItem . SummaryValue == null ? 0 : Convert . ToDecimal ( U5_ONE . SummaryItem . SummaryValue );
                u7 = U20_ONE . SummaryItem . SummaryValue == null ? 0 : Math . Round ( Convert . ToDecimal ( U20_ONE . SummaryItem . SummaryValue ) ,1 );
                //bandedGridView2 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Custom ,"U24_ONE" ,bandedGridView2 . Columns [ "U24_ONE" ] ,"{0}" );
                U24_ONE . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,u7 == 0 ? 0 . ToString ( ) : ( u17 / u7 ) . ToString ( "f0" ) );
                //bandedGridView2.ExpandAllGroups( );

                //( ( DevExpress.XtraGrid.GridSummaryItem ) bandedGridView1.GroupSummary[bandedGridView1.GroupSummary.Count - 1] ).DisplayFormat = "{0:N0}";
            }
        }
        void assginOne ( )
        {
            for ( int i = 0 ; i < bandedGridView1.DataRowCount ; i++ )
            {
                if ( i == bandedGridView1.DataRowCount - 1 )
                    bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U12"] ,0 );
                else
                {
                    if ( bandedGridView1.GetDataRow( i )["PQX14"].ToString( ) == bandedGridView1.GetDataRow( i + 1 )["PQX14"].ToString( ) )
                        bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U12"] ,string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PQX34"].ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetDataRow( i )["PQX34"].ToString( ) ) - ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( i + 1 )["PQX34"].ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetDataRow( i + 1 )["PQX34"].ToString( ) ) ) );
                    else
                        bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U12"] ,0 );
                }
            }
        }
        #endregion

    }
}



/*
U9:Iif([工序实产周期] <> 0, Iif([工序实产周期] >= 1, [还要生产部件] / [工序实产周期], [还要生产部件] / 1), 0) 
*/
