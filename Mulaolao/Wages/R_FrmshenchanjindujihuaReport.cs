using DevExpress . XtraCharts;
using Mulaolao . Class;
using System;
using System . Data;
using System . Linq;
using System . Threading . Tasks;
using System . Windows . Forms;

namespace Mulaolao . Wages
{
    public partial class R_FrmshenchanjindujihuaReport :Form
    {
        DataTable tableView,tableOne,table;
        MulaolaoBll.Bll.shenchanjindujihuaReportBll _bll=null;

        bool result=false;
        int numData=0,timeChange=0;

        public delegate void ReadDataTableHandler ( bool result );
        public event ReadDataTableHandler tableHandler;

        public delegate void ChartControlHandler ( bool result );
        public event ChartControlHandler chartHandler;
        
        public R_FrmshenchanjindujihuaReport ( )
        {
            InitializeComponent ( );
            
            _bll = new MulaolaoBll . Bll . shenchanjindujihuaReportBll ( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            this . tableHandler += new ReadDataTableHandler ( getData );
            this . chartHandler += new ChartControlHandler ( updateIUI );

            Func<string> funStr = InitData;
            IAsyncResult result = funStr . BeginInvoke ( new AsyncCallback ( other ) ,null );

            timeChange = 1;

            System . Timers . Timer t = new System . Timers . Timer ( 1000 * 60 * timeChange );
            t . Elapsed += new System . Timers . ElapsedEventHandler ( refreData );
            t . AutoReset = true;
            t . Enabled = true;
        }

        void getData ( bool result )
        {
            if ( result )
            {
                tableView = _bll . getTableToView ( );
                Task task = new Task ( ReadCalcu );
                task . Start ( );
                result = false;
                updateIUI ( true );
            }
        }

        void updateIUI ( bool result )
        {
            chartOne ( );
        }

        string InitData ( )
        {
            tableView = _bll . getTableToView ( );
            Task task = new Task ( ReadCalcu );
            task . Start ( );

            return string . Empty;
        }

        void ReadCalcu ( )
        {
            _bll . Calcu ( );
        }

        delegate void AsynUpdateUI ( );
        void other ( IAsyncResult result )
        {
            if ( InvokeRequired )
            {
                this . Invoke ( new AsynUpdateUI ( delegate ( )
                {
                    numData = 20;
                    table = getTable ( numData );
                    gridControl1 . DataSource = table;
                    chartOne ( );
                } ) );
            }
        }

        void refreData ( object source ,System . Timers . ElapsedEventArgs e )
        {
            if ( InvokeRequired )
            {
                this . Invoke ( new AsynUpdateUI ( delegate ( )
                {
                    result = false;
                    numData = 20;
                    table = getTable ( numData );
                    gridControl1 . DataSource = table;
                } ) );
            }
        }

        DataTable getTable ( int nums )
        {
            if ( tableOne == null )
                tableOne = tableView . Copy ( );
            DataTable tableTwo = tableOne . Clone ( );
            if ( tableOne . Rows . Count <= nums )
            {
                nums = tableOne . Rows . Count;
                result = true;
                tableHandler ( result );
            }
            DataRow [ ] rows = tableOne . Select ( "1=1" );
            for ( int i = 0 ; i < nums ; i++ )
            {
                tableTwo . ImportRow ( ( DataRow ) rows [ i ] );
                tableOne . Rows . Remove ( rows [ i ] );
            }
            if ( tableOne . Rows . Count == 0 )
            {
                tableOne = tableView . Copy ( );
            }

            return tableTwo;
        }

        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress . XtraGrid . Views . Grid . RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
            }
        }

        void chartOne ( )
        {
            var query = from p in tableView . AsEnumerable ( )
                        group p by new
                        {
                            p1 = p . Field<string> ( "PQX21" )
                        } into m
                        select new
                        {
                            pqx21 = m . Key . p1 ,
                            count = m . Count ( )
                        };
            if ( query == null )
                return;

            DataTable table = new DataTable ( );
            table . Columns . Add ( "X" ,typeof ( string ) );
            table . Columns . Add ( "Y" ,typeof ( int ) );
            foreach ( var x in query )
            {
                DataRow row = table . NewRow ( );
                row [ "X" ] = x . pqx21;
                row [ "Y" ] = x . count;
                table . Rows . Add ( row );
            }
            Series seOne = chartControl1 . GetSeriesByName ( "SeriesOne" );
            seOne . DataSource = table;
            seOne . ArgumentDataMember = "X";
            seOne . ValueDataMembers [ 0 ] = "Y";
            chartControl1 . Series . Clear ( );
            chartControl1 . Series . Add ( seOne );
        }

    }
}


/*
 1、从每批流水号各零件中找出往下交接的第一个(欠投产天数栏位≦-3)的工序组长读取到该汇总表, 像R-241中的生成或全部生的方式产生该汇总表.该汇总表数据作为延误考核用
 2、从每批流水号各零件中找出往下交接的第一个(工序实产周期栏位≦-3)的工序组长读取到该汇总表, 象R-241中的生成或全部生的方式产生该汇总表.该汇总表数据作为延误考核用. 
 */

