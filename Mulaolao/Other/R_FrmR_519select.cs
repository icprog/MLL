using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;
using StudentMgr;
using System . Text;

namespace Mulaolao . Other
{
    public partial class R_FrmR_519select : Form
    {
        
        public string zhi = "";
        //添加一个委托
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        //添加一个PassDataBetweenFormHandler类型的事件
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        string cn1 = "", cn2 = "", cn3 = "", cn4 = "", cn5 = "", cn6 = "", cn7 = "", cn8 = "", cn9 = "", cn10 = "";
        public string chose = "";
        string strWhere="1=1";

        public R_FrmR_519select( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,gridView2 ,gridView3 ,gridView4 ,gridView5 ,gridView6 ,gridView7 } );

            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        public R_FrmR_519select ( string strW ,string chose,string zhi )
        {
            InitializeComponent ( );

            GridViewMoHuSelect . SetFilter ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,gridView2 ,gridView3 ,gridView4 ,gridView5 ,gridView6 ,gridView7 } );

            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );

            strWhere = strWhere + strW;
            this . chose = chose;
            this . zhi = zhi;
        }

        private void R_FrmR_519select_Load ( object sender ,EventArgs e )
        {
            getDataView ( );
        }

        void getDataView ( )
        {
            DataTable da;
            StringBuilder strSql = new StringBuilder ( );
            if ( zhi . Equals ( "1" ) )
            {
                strSql . AppendFormat ( "SELECT * FROM R_PQA WHERE {0}" ,strWhere );
                da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                gridControl1 . DataSource = da;
                tabPage2 . Parent = tabControl1;
                tabPage1 . Parent = null;
                tabPage3 . Parent = null;
                tabPage4 . Parent = null;
                tabPage5 . Parent = null;
                tabPage6 . Parent = null;
                tabPage7 . Parent = null;
            }
            else if ( zhi . Equals ( "2" ) )
            {
                strSql . AppendFormat ( "SELECT * FROM R_PQD WHERE {0}" ,strWhere );
                da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                gridControl4 . DataSource = da;
                tabPage4 . Parent = tabControl1;
                tabPage1 . Parent = null;
                tabPage2 . Parent = null;
                tabPage3 . Parent = null;
                tabPage5 . Parent = null;
                tabPage6 . Parent = null;
                tabPage7 . Parent = null;
            }
            else if ( zhi . Equals ( "3" ) )
            {
                strSql . AppendFormat ( "SELECT * FROM R_PQE WHERE {0}" ,strWhere );
                da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                gridControl5 . DataSource = da;
                tabPage5 . Parent = tabControl1;
                tabPage1 . Parent = null;
                tabPage2 . Parent = null;
                tabPage3 . Parent = null;
                tabPage4 . Parent = null;
                tabPage6 . Parent = null;
                tabPage7 . Parent = null;
            }
            else if ( zhi . Equals ( "4" ) )
            {
                strSql . AppendFormat ( "SELECT * FROM R_PQB WHERE {0}" ,strWhere );
                da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                gridControl2 . DataSource = da;
                tabPage1 . Parent = tabControl1;
                tabPage5 . Parent = null;
                tabPage2 . Parent = null;
                tabPage3 . Parent = null;
                tabPage4 . Parent = null;
                tabPage6 . Parent = null;
                tabPage7 . Parent = null;
            }
            else if ( zhi . Equals ( "5" ) )
            {
                strSql . AppendFormat ( "SELECT * FROM R_PQC WHERE {0}" ,strWhere );
                da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                gridControl3 . DataSource = da;
                tabPage3 . Parent = tabControl1;
                tabPage5 . Parent = null;
                tabPage2 . Parent = null;
                tabPage1 . Parent = null;
                tabPage4 . Parent = null;
                tabPage6 . Parent = null;
                tabPage7 . Parent = null;
            }
            else if ( zhi . Equals ( "6" ) || zhi . Equals ( "7" ) || zhi . Equals ( "8" ) )
            {
                strSql . AppendFormat ( "SELECT * FROM R_PQKZ WHERE {0}" ,strWhere );
                da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                gridControl6 . DataSource = da;
                tabPage6 . Parent = tabControl1;
                tabPage5 . Parent = null;
                tabPage2 . Parent = null;
                tabPage1 . Parent = null;
                tabPage4 . Parent = null;
                tabPage3 . Parent = null;
                tabPage7 . Parent = null;
            }
            else if ( zhi . Equals ( "9" ) )
            {
                strSql . AppendFormat ( "SELECT * FROM R_PQAS WHERE {0}" ,strWhere );
                da = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
                gridControl7 . DataSource = da;
                tabPage6 . Parent = null;
                tabPage5 . Parent = null;
                tabPage2 . Parent = null;
                tabPage1 . Parent = null;
                tabPage4 . Parent = null;
                tabPage3 . Parent = null;
                tabPage7 . Parent = tabControl1;
            }
        }

        //水帘机
        decimal d1=0,d2=0;
        DataRow row;
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            /*
           PQA02 小工标准日工资 PQA03 日排小工人数 PQA04 老师标准日工资 PQA10 板数/天
            */
            row = gridView1 . GetFocusedDataRow ( );
            if ( chose . Equals ( "1" ) )
            {
                cn1 = row [ "PQA02" ] . ToString ( ); //gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQA02" ).ToString( );
                cn2 = row [ "PQA03" ] . ToString ( ); //gridView1.GetRowCellValue( gridView1.FocusedRowHandle ,"PQA03" ).ToString( );
                cn3 = row [ "PQA04" ] . ToString ( ); //gridView1 . GetRowCellValue ( gridView1 . FocusedRowHandle ,"PQA04" ) . ToString ( );
                cn4 = row [ "PQA10" ] . ToString ( ); //gridView1 . GetRowCellValue ( gridView1 . FocusedRowHandle ,"PQA10" ) . ToString ( );
                cn5 = row [ "PQA06" ] . ToString ( ); //gridView1 . GetRowCellValue ( gridView1 . FocusedRowHandle ,"PQA06" ) . ToString ( );
                cn6 = row [ "PQA12" ] . ToString ( ); //gridView1 . GetRowCellValue ( gridView1 . FocusedRowHandle ,"PQA12" ) . ToString ( );
                cn7 = row [ "PQA01" ] . ToString ( ); //gridView1 . GetRowCellValue ( gridView1 . FocusedRowHandle ,"PQA01" ) . ToString ( );
            }
            else if ( chose . Equals ( "2" ) )
            {
                cn1 = row [ "PQA09" ] . ToString ( );//gridView1 . GetRowCellValue ( gridView1 . FocusedRowHandle ,"PQA09" ) . ToString ( );
                cn2 = row [ "PQA11" ] . ToString ( );// gridView1 . GetRowCellValue ( gridView1 . FocusedRowHandle ,"PQA11" ) . ToString ( );
                cn3 = row [ "PQA08" ] . ToString ( );// gridView1 . GetRowCellValue ( gridView1 . FocusedRowHandle ,"PQA08" ) . ToString ( );
                cn4 = row [ "PQA06" ] . ToString ( );// gridView1 . GetRowCellValue ( gridView1 . FocusedRowHandle ,"PQA06" ) . ToString ( );
                cn5 = row [ "PQA12" ] . ToString ( );// gridView1 . GetRowCellValue ( gridView1 . FocusedRowHandle ,"PQA12" ) . ToString ( );
                cn6 = row [ "PQA01" ] . ToString ( );// gridView1 . GetRowCellValue ( gridView1 . FocusedRowHandle ,"PQA01" ) . ToString ( );
                d1 = string . IsNullOrEmpty ( row [ "PQA09" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PQA09" ] . ToString ( ) );
                d2 = string . IsNullOrEmpty ( row [ "PQA08" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PQA08" ] . ToString ( ) );
                cn7 = d1 == 0 ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( 0.425 ) * d2 / d1 ,4 ) . ToString ( );
            }
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs ( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm ( this ,args );
            }

            this . Close ( );
        }
        //静电喷涂
        private void gridView4_DoubleClick ( object sender ,EventArgs e )
        {
            /*
            小工标准日工资  日排小工人数  老师标准日工资  板数/天
            */
            row = gridView4 . GetFocusedDataRow ( );
            if ( chose . Equals ( "1" ) )
            {
                cn1 = row [ "PQD02" ] . ToString ( );
                // gridView4 . GetRowCellValue ( gridView4 . FocusedRowHandle ,"PQD02" ) . ToString ( );
                cn2 = row [ "PQD03" ] . ToString ( );
                //gridView4 . GetRowCellValue ( gridView4 . FocusedRowHandle ,"PQD03" ) . ToString ( );
                cn3 = row [ "PQD04" ] . ToString ( );
                //gridView4 . GetRowCellValue ( gridView4 . FocusedRowHandle ,"PQD04" ) . ToString ( );
                cn4 = row [ "PQD10" ] . ToString ( );
                //gridView4 . GetRowCellValue ( gridView4 . FocusedRowHandle ,"PQD10" ) . ToString ( );
                cn5 = row [ "PQD06" ] . ToString ( );
                //gridView4 . GetRowCellValue ( gridView4 . FocusedRowHandle ,"PQD06" ) . ToString ( );
                cn6 = row [ "PQD12" ] . ToString ( );
                //gridView4 . GetRowCellValue ( gridView4 . FocusedRowHandle ,"PQD12" ) . ToString ( );
                cn7 = row [ "PQD01" ] . ToString ( );
                //gridView4 . GetRowCellValue ( gridView4 . FocusedRowHandle ,"PQD01" ) . ToString ( );
            }
            else if ( chose . Equals ( "2" ) )
            {
                cn1 = row [ "PQD09" ] . ToString ( );
                //gridView4 . GetRowCellValue ( gridView4 . FocusedRowHandle ,"PQD09" ) . ToString ( );
                cn2 = row [ "PQD11" ] . ToString ( );
                //gridView4 . GetRowCellValue ( gridView4 . FocusedRowHandle ,"PQD11" ) . ToString ( );
                cn3 = row [ "PQD08" ] . ToString ( );
                //gridView4 . GetRowCellValue ( gridView4 . FocusedRowHandle ,"PQD08" ) . ToString ( );
                cn4 = row [ "PQD06" ] . ToString ( );
                //gridView4 . GetRowCellValue ( gridView4 . FocusedRowHandle ,"PQD06" ) . ToString ( );
                cn5 = row [ "PQD12" ] . ToString ( );
                //gridView4 . GetRowCellValue ( gridView4 . FocusedRowHandle ,"PQD12" ) . ToString ( );
                cn6 = row [ "PQD01" ] . ToString ( );
                //gridView4 . GetRowCellValue ( gridView4 . FocusedRowHandle ,"PQD01" ) . ToString ( );
                d1 = string . IsNullOrEmpty ( row [ "PQD09" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PQD09" ] . ToString ( ) );
                d2 = string . IsNullOrEmpty ( row [ "PQD08" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PQD08" ] . ToString ( ) );
                cn7 = d1 == 0 ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( 0.425 ) * d2 / d1 ,4 ) . ToString ( );
            }
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs ( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm ( this ,args );
            }

            this . Close ( );
        }
        //浸漆
        private void gridView5_DoubleClick( object sender, EventArgs e )
        {
            /*
            小工标准日工资 日排小工人数  板数/天
            */
            row = gridView5 . GetFocusedDataRow ( );
            if ( chose . Equals ( "1" ) )
            {
                cn1 = row [ "PQE02" ] . ToString ( ); 
                //gridView5 . GetRowCellValue ( gridView5 . FocusedRowHandle ,"PQE02" ) . ToString ( );
                cn2 = row [ "PQE03" ] . ToString ( );
                //gridView5 . GetRowCellValue ( gridView5 . FocusedRowHandle ,"PQE03" ) . ToString ( );
                cn3 = row [ "PQE10" ] . ToString ( );
                //gridView5 . GetRowCellValue ( gridView5 . FocusedRowHandle ,"PQE10" ) . ToString ( );
                cn4 = row [ "PQE06" ] . ToString ( );
                //gridView5 . GetRowCellValue ( gridView5 . FocusedRowHandle ,"PQE06" ) . ToString ( );
                cn5 = row [ "PQE12" ] . ToString ( );
                //gridView5 . GetRowCellValue ( gridView5 . FocusedRowHandle ,"PQE12" ) . ToString ( );
                cn6 = row [ "PQE01" ] . ToString ( );
                //gridView5 . GetRowCellValue ( gridView5 . FocusedRowHandle ,"PQE01" ) . ToString ( );
            }
            else if ( chose . Equals ( "2" ) )
            {
                cn1 = row [ "PQE09" ] . ToString ( );
                //gridView5 . GetRowCellValue ( gridView5 . FocusedRowHandle ,"PQE09" ) . ToString ( );
                cn2 = row [ "PQE11" ] . ToString ( );
                //gridView5 . GetRowCellValue ( gridView5 . FocusedRowHandle ,"PQE11" ) . ToString ( );
                cn3 = row [ "PQE08" ] . ToString ( );
                //gridView5 . GetRowCellValue ( gridView5 . FocusedRowHandle ,"PQE08" ) . ToString ( );
                cn4 = row [ "PQE06" ] . ToString ( );
                //gridView5 . GetRowCellValue ( gridView5 . FocusedRowHandle ,"PQE06" ) . ToString ( );
                cn5 = row [ "PQE12" ] . ToString ( );
                //gridView5 . GetRowCellValue ( gridView5 . FocusedRowHandle ,"PQE12" ) . ToString ( );
                cn6 = row [ "PQE01" ] . ToString ( );
                //gridView5 . GetRowCellValue ( gridView5 . FocusedRowHandle ,"PQE01" ) . ToString ( );

            }
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 );
            if (PassDataBetweenForm != null)
            {
                PassDataBetweenForm( this, args );
            }

            this.Close( );
        }
        //封边
        private void gridView2_DoubleClick( object sender, EventArgs e )
        {
            /*
            工资单价/m²
            */
            row = gridView2 . GetFocusedDataRow ( );
            if ( chose . Equals ( "1" ) )
            {
                cn1 = row [ "PQB03" ] . ToString ( );
                //gridView2 . GetRowCellValue ( gridView2 . FocusedRowHandle ,"PQB03" ) . ToString ( );
                cn2 = row [ "PQB05" ] . ToString ( );
                //gridView2 . GetRowCellValue ( gridView2 . FocusedRowHandle ,"PQB05" ) . ToString ( );
                cn3 = row [ "PQB12" ] . ToString ( );
                //gridView2 . GetRowCellValue ( gridView2 . FocusedRowHandle ,"PQB12" ) . ToString ( );
                cn4 = row [ "PQB01" ] . ToString ( );
                //gridView2 . GetRowCellValue ( gridView2 . FocusedRowHandle ,"PQB01" ) . ToString ( );
            }
            else if ( chose . Equals ( "2" ) )
            {
                cn1 = row [ "PQB08" ] . ToString ( );
                //gridView2 . GetRowCellValue ( gridView2 . FocusedRowHandle ,"PQB08" ) . ToString ( );
                cn2 = row [ "PQB10" ] . ToString ( );
                //gridView2 . GetRowCellValue ( gridView2 . FocusedRowHandle ,"PQB10" ) . ToString ( );
                cn3 = row [ "PQB09" ] . ToString ( );
                //gridView2 . GetRowCellValue ( gridView2 . FocusedRowHandle ,"PQB09" ) . ToString ( );
                cn4 = row [ "PQB05" ] . ToString ( );
                //gridView2 . GetRowCellValue ( gridView2 . FocusedRowHandle ,"PQB05" ) . ToString ( );
                cn5 = row [ "PQB12" ] . ToString ( );
                //gridView2 . GetRowCellValue ( gridView2 . FocusedRowHandle ,"PQB12" ) . ToString ( );
                cn6 = row [ "PQB01" ] . ToString ( );
                //gridView2 . GetRowCellValue ( gridView2 . FocusedRowHandle ,"PQB01" ) . ToString ( );
                d1 = string . IsNullOrEmpty ( row [ "PQB08" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PQB08" ] . ToString ( ) );
                d2 = string . IsNullOrEmpty ( row [ "PQB09" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PQB09" ] . ToString ( ) );
                cn7 = d1 == 0 ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( 0.5 ) * d2 / d1 ,4 ) . ToString ( );
            }
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs ( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 );
            if (PassDataBetweenForm != null)
            {
                PassDataBetweenForm( this, args );
            }

            this.Close( );
        }
        //涂布
        private void gridView3_DoubleClick( object sender, EventArgs e )
        {
            /*
            小工标准日工资 日排小工人数 工资单价 / m²
            */
            row = gridView3 . GetFocusedDataRow ( );
            if ( chose . Equals ( "1" ) )
            {
                cn1 = row [ "PQC04" ] . ToString ( );
                //gridView3 . GetRowCellValue ( gridView3 . FocusedRowHandle ,"PQC04" ) . ToString ( );
                cn2 = row [ "PQC05" ] . ToString ( );
                //gridView3 . GetRowCellValue ( gridView3 . FocusedRowHandle ,"PQC05" ) . ToString ( );
                cn3 = row [ "PQC06" ] . ToString ( );
                //gridView3 . GetRowCellValue ( gridView3 . FocusedRowHandle ,"PQC06" ) . ToString ( );
                cn4 = row [ "PQC08" ] . ToString ( );
                //gridView3 . GetRowCellValue ( gridView3 . FocusedRowHandle ,"PQC08" ) . ToString ( );
                cn5 = row [ "PQC14" ] . ToString ( );
                //gridView3 . GetRowCellValue ( gridView3 . FocusedRowHandle ,"PQC14" ) . ToString ( );
                cn6 = row [ "PQC02" ] . ToString ( );
                //gridView3 . GetRowCellValue ( gridView3 . FocusedRowHandle ,"PQC02" ) . ToString ( );
                cn7 = row [ "PQC03" ] . ToString ( );
                //gridView3 . GetRowCellValue ( gridView3 . FocusedRowHandle ,"PQC03" ) . ToString ( );
            }
            else if ( chose . Equals ( "2" ) )
            {
                cn1 = row [ "PQC11" ] . ToString ( );
                //gridView3 . GetRowCellValue ( gridView3 . FocusedRowHandle ,"PQC11" ) . ToString ( );
                cn2 = row [ "PQC13" ] . ToString ( );
                //gridView3 . GetRowCellValue ( gridView3 . FocusedRowHandle ,"PQC13" ) . ToString ( );
                cn3 = row [ "PQC12" ] . ToString ( );
                //gridView3 . GetRowCellValue ( gridView3 . FocusedRowHandle ,"PQC12" ) . ToString ( );
                cn4 = row [ "PQC08" ] . ToString ( );
                //gridView3 . GetRowCellValue ( gridView3 . FocusedRowHandle ,"PQC08" ) . ToString ( );
                cn5 = row [ "PQC02" ] . ToString ( );
                //gridView3 . GetRowCellValue ( gridView3 . FocusedRowHandle ,"PQC02" ) . ToString ( );
                cn6 = row [ "PQC03" ] . ToString ( );
                //gridView3 . GetRowCellValue ( gridView3 . FocusedRowHandle ,"PQC03" ) . ToString ( );
                cn7 = row [ "PQC14" ] . ToString ( );
                //gridView3 . GetRowCellValue ( gridView3 . FocusedRowHandle ,"PQC14" ) . ToString ( );
                cn8 = row [ "PQC01" ] . ToString ( );
                //gridView3 . GetRowCellValue ( gridView3 . FocusedRowHandle ,"PQC01" ) . ToString ( );
                d1 = string . IsNullOrEmpty ( row [ "PQC11" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PQC11" ] . ToString ( ) );
                d2 = string . IsNullOrEmpty ( row [ "PQC12" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "PQC12" ] . ToString ( ) );
                cn9 = d1 == 0 ? 0 . ToString ( ) : Math . Round ( Convert . ToDecimal ( 0.5 ) * d2 / d1 ,4 ) . ToString ( );
            }

            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs ( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 );
            if (PassDataBetweenForm != null)
            {
                PassDataBetweenForm( this, args );
            }

            this.Close( );
        }
        //滚漆
        private void gridView6_DoubleClick ( object sender ,EventArgs e )
        {
            if ( zhi == "6" )
            {
                cn1 = gridView6.GetFocusedRowCellValue( "KZ001" ).ToString( );
                cn2 = gridView6.GetFocusedRowCellValue( "KZ002" ).ToString( );
                cn3 = gridView6.GetFocusedRowCellValue( "KZ003" ).ToString( );
                //cn4 = gridView6.GetFocusedRowCellValue( "KZ004" ).ToString( );
                cn5 = gridView6.GetFocusedRowCellValue( "KZ007" ).ToString( );
                //cn6 = gridView6.GetFocusedRowCellValue( "KZ009" ).ToString( );
                cn7 = gridView6.GetFocusedRowCellValue( "KZ010" ).ToString( );
                cn8 = gridView6.GetFocusedRowCellValue( "KZ008" ).ToString( );
                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 );
                if ( PassDataBetweenForm != null )
                {
                    PassDataBetweenForm( this ,args );
                }
                this.Close( );
            }
            else if(zhi=="7")
            {
                cn1 = gridView6.GetFocusedRowCellValue( "KZ003" ).ToString( );
                cn2 = gridView6.GetFocusedRowCellValue( "KZ010" ).ToString( );
                cn3 = gridView6.GetFocusedRowCellValue( "KZ001" ).ToString( );
                cn4 = gridView6.GetFocusedRowCellValue( "KZ004" ).ToString( );
                cn5 = gridView6.GetFocusedRowCellValue( "KZ005" ).ToString( );
                cn6 = gridView6.GetFocusedRowCellValue( "KZ007" ).ToString( );
                cn7 = gridView6.GetFocusedRowCellValue( "KZ006" ).ToString( );
                cn8 = gridView6.GetFocusedRowCellValue( "KZ008" ).ToString( );
                cn9 = gridView6.GetFocusedRowCellValue( "KZ012" ).ToString( );
                cn10 = gridView6.GetFocusedRowCellValue( "KZ002" ).ToString( );
                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 ,cn8 ,cn9 ,cn10 );
                if ( PassDataBetweenForm != null )
                {
                    PassDataBetweenForm( this ,args );
                }
                this.Close( );
            }
            else if ( zhi == "8" )
            {
                cn1 = gridView6.GetFocusedRowCellValue( "KZ010" ).ToString( );
                cn2 = gridView6.GetFocusedRowCellValue( "KZ005" ).ToString( );
                cn3 = gridView6.GetFocusedRowCellValue( "KZ002" ).ToString( );
                cn4 = gridView6.GetFocusedRowCellValue( "KZ001" ).ToString( );
                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 );
                if ( PassDataBetweenForm != null )
                {
                    PassDataBetweenForm( this ,args );
                }
                this.Close( );
            }
        }
        //化学品辅料
        private void gridView7_DoubleClick ( object sender ,EventArgs e )
        {
            if ( zhi == "9" )
            {
                cn1 = gridView7.GetFocusedRowCellValue( "AS006" ).ToString( );
                cn2 = gridView7.GetFocusedRowCellValue( "AS007" ).ToString( );
                cn3 = gridView7.GetFocusedRowCellValue( "AS003" ).ToString( );
                cn4 = gridView7.GetFocusedRowCellValue( "AS009" ).ToString( );
                cn5 = gridView7.GetFocusedRowCellValue( "AS002" ).ToString( );
                cn6 = gridView7.GetFocusedRowCellValue( "AS004" ).ToString( );
                cn7 = gridView7 . GetFocusedRowCellValue ( "AS008" ) . ToString ( );
                PassDataWinFormEventArgs args = new PassDataWinFormEventArgs ( cn1 ,cn2 ,cn3 ,cn4 ,cn5 ,cn6 ,cn7 );
                if ( PassDataBetweenForm != null )
                {
                    PassDataBetweenForm( this ,args );
                }
                this.Close( );
            }
        }
    }
}
