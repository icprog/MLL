using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Text;
using System . Linq;
using System . Windows . Forms;
using DevExpress . XtraEditors;
using Mulaolao . Class;

namespace Mulaolao . Environmental
{
    public partial class FormSanitationBroad :Form
    {
        MulaolaoBll.Bll.SanitationBroadBll _bll=null;

        public delegate void ReadDataTableHandler ( bool result );
        public event ReadDataTableHandler tableHandler;

        public delegate void ChartControlHandler ( bool result );
        public event ChartControlHandler chartHandler;

        DataTable tableView,tableAll;

        public FormSanitationBroad ( )
        {
            InitializeComponent ( );

            _bll = new MulaolaoBll . Bll . SanitationBroadBll ( );

            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            

            this . tableHandler += new ReadDataTableHandler ( getData );
            this . chartHandler += new ChartControlHandler ( updateIUI );

            Func<string> funStr = InitData;
            IAsyncResult res = funStr . BeginInvoke ( new AsyncCallback ( other ) ,null );

            System . Timers . Timer t = new System . Timers . Timer ( 1000 * 60 * 1 );
            t . Elapsed += new System . Timers . ElapsedEventHandler ( refreData );
            t . AutoReset = true;
            t . Enabled = true;

        }

        void getData ( bool result )
        {
            if ( result )
            {
                tableAll = _bll . getTableGrouper ( );
                getTableView ( );
                chartHandler ( true );
            }
        }

        void updateIUI ( bool result  )
        {
            if ( tableView == null || tableView . Rows . Count < 1 )
                return;

            foreach ( DataColumn column in tableView.Columns )
            {
                if ( column . ColumnName . Contains ( "[" ) || column . ColumnName . Contains ( "]" ) || column . ColumnName . Contains ( "col" ) )
                {
                    column . ColumnName = column . ColumnName . Replace ( '[' ,' ' ) . TrimStart ( );
                    column . ColumnName = column . ColumnName . Replace ( ']' ,' ' ) . TrimEnd ( );
                    column . ColumnName = column . ColumnName . Replace ( "col" ,"" );
                }
            }
        }

        string InitData ( )
        {
            tableAll = _bll . getTableGrouper ( );
            getTableView ( );
            chartHandler ( true );
            return string . Empty;
        }

        void getTableView ( )
        {
            if ( tableAll == null || tableAll . Rows . Count < 1 )
                return;
            string time = tableAll . Rows [ 0 ] [ "SAC" ] . ToString ( );
            tableView = _bll . getTableView ( time );
        }

        delegate void AsynUpdateUI ( );
        void other ( IAsyncResult result )
        {
            if ( InvokeRequired )
            {
                this . Invoke ( new AsynUpdateUI ( delegate
                {
                    gridControl1 . DataSource = tableView;
                    bandedGridView1 . PopulateColumns ( );
                    editUI ( );
                    bandedGridView1 . BestFitColumns ( );
                } ) );
            }
        }

        void refreData ( object source ,System . Timers . ElapsedEventArgs e )
        {
            if ( InvokeRequired )
            {
                this . Invoke ( new AsynUpdateUI ( delegate ( )
                {
                    tableHandler ( true );
                    gridControl1 . DataSource = tableView;
                    bandedGridView1 . PopulateColumns ( );
                    editUI ( );
                    bandedGridView1 . BestFitColumns ( );
                } ) );
            }
        }

        void editUI ( )
        {
            if ( tableView == null || tableView . Rows . Count < 1 )
                return;
            var query = from p in tableAll . AsEnumerable ( )
                        group p by new
                        {
                            p1 = p . Field<string> ( "SAD007" )
                        } into m
                        select new
                        {
                            sad007 = m . Key . p1
                        };
            if ( query == null )
                return;
            int i = 2;
            foreach ( var x in query )
            {
                if ( i == 2 )
                {
                    gb2 . Caption = x . sad007;
                    gb2 . Visible = true;
                }
                else if ( i == 3 )
                {
                    gb3 . Caption = x . sad007;
                    gb3 . Visible = true;
                }
                else if ( i == 4 )
                {
                    gb4 . Caption = x . sad007;
                    gb4 . Visible = true;
                }
                else if ( i == 5 )
                {
                    gb5 . Caption = x . sad007;
                    gb5 . Visible = true;
                }
                else if ( i == 6 )
                {
                    gb6 . Caption = x . sad007;
                    gb6 . Visible = true;
                }
                else if ( i == 7 )
                {
                    gb7 . Caption = x . sad007;
                    gb7 . Visible = true;
                }
                else if ( i == 8 )
                {
                    gb8 . Caption = x . sad007;
                    gb8 . Visible = true;
                }
                else if ( i == 9 )
                {
                    gb9 . Caption = x . sad007;
                    gb9 . Visible = true;
                }
                else if ( i == 10 )
                {
                    gb10 . Caption = x . sad007;
                    gb10 . Visible = true;
                }
                else if ( i == 11 )
                {
                    gb11 . Caption = x . sad007;
                    gb11 . Visible = true;
                }
                i++;
            }
            foreach ( DevExpress . XtraGrid . Views . BandedGrid . GridBand band in bandedGridView1 . Bands )
            {
                DataRow [ ] rows = tableAll . Select ( "SAD007='" + band . Caption + "'" );
                if ( rows == null || rows . Length < 1 )
                    continue;
                foreach ( DataRow r in rows )
                {
                    band . Columns . Add ( bandedGridView1 . Columns [ r [ "SAD008" ] . ToString ( ) ] );
                }
            }
            
            foreach ( DevExpress . XtraGrid . Columns . GridColumn column in bandedGridView1 . Columns )
            {
                column . Summary . Clear ( );
                if ( column . FieldName == "SAD002" )
                    column . Caption = "检查区域";
                else if ( column . FieldName == "SAD003" )
                    column . Caption = "检查项目";
                else if ( column . FieldName == "SAD004" )
                    column . Caption = "现场检查内容";
                else if ( column . FieldName == "SAD005" )
                    column . Caption = "评分标准";
                else if ( column . FieldName == "SAD009" )
                    column . Caption = "现状及存在问题描述";
                else
                {
                    column . Summary . Add ( DevExpress . Data . SummaryItemType . Sum ,column . FieldName );
                    column . OptionsColumn . AllowMerge = DevExpress . Utils . DefaultBoolean . False;
                }
            }
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { bandedGridView1 } );
        }

    }

}