using System;
using System . Collections . Generic;
using System . Data;
using System . Text;
using System . Linq;
using StudentMgr;
using System . Reflection;
using DevExpress . XtraCharts;
using System . Drawing;
using System . Windows . Forms;

namespace text
{
    public partial class ChartControl :DevExpress . XtraEditors . XtraForm
    {
        public delegate void CheckEventHandler ( string name );
        public CheckEventHandler ChekcEvent;

        DataTable dt;
        public ChartControl ( )
        {
            InitializeComponent ( );

            this . ChekcEvent = new CheckEventHandler ( check_Event );

            //MessageBox . Show ( ( 69*1.0 / 10 ) . ToString ( ) );
            MessageBox . Show ( ( 67 % 10 ) . ToString ( ) );
        }

        private void ChartControl_Load ( object sender ,EventArgs e )
        {
            dt = getTable ( );

            comboBox1 . DataSource = dt . AsEnumerable ( ) . Select ( p => new
            {
                QZ004 = p . Field<String> ( "QZ004" )
            } ) . ToArray ( );
            comboBox1 . DisplayMember = "QZ004";

            gridControl1 . DataSource = dt;
        }

        //按组长生成
        private void button1_Click ( object sender ,EventArgs e )
        {
            
        }

        //按年月生成
        private void button2_Click ( object sender ,EventArgs e )
        {
            check_Event_userName ( Convert . ToDateTime ( dateEdit1 . Text ) );
        }

        DataTable getTable ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (" );
            strSql . Append ( "SELECT DISTINCT CONVERT(DATE,A.QZ002,112) QZ002,A.QZ003,A.QZ008 FROM R_PQQZC A RIGHT JOIN R_PQQZ B ON A.QZ004=B.QZ004 AND A.QZ003=B.QZ003 " );
            strSql . Append ( "),CFT AS(" );
            strSql . Append ( "SELECT QZ002,CONVERT(DECIMAL(18,0),SUM(QZ008)) QZ008 FROM CET GROUP BY QZ002)" );
            strSql . Append ( ",CHT AS(" );
            strSql . Append ( "SELECT A.QZ004,A.QZ002,CONVERT(DECIMAL(18,0),SUM(ISNULL(U22,0))) U22,CONVERT(DECIMAL(18,0),SUM(U23)) U23,CONVERT(DECIMAL(18,0),SUM(QZ014)) QZ014,CONVERT(DECIMAL(18,0),SUM(U5)) U5,CONVERT(DECIMAL(18,0),SUM(U13+U14+U15+U16+U17+U18)) U19,CONVERT(DECIMAL(18,0),SUM(U7)) U7,CONVERT(DECIMAL(18,0),SUM(QZ018*(U22+U23+QZ014+U5+U13+U14+U15+U16+U17+U18-U7))) U10 FROM R_PQQZC A INNER JOIN CFT B ON A.QZ002=B.QZ002 GROUP BY A.QZ004,A.QZ002) " );
            strSql . Append ( "SELECT QZ004,QZ002,U22+U23+QZ014+U5+U19-U7-U10 U FROM CHT" );

            return SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
        }

        /// <summary>
        /// 下面通过一个方法来实现返回DataTable类型 
        /// LINQ返回DataTable类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="varlist"></param>
        /// <returns></returns>
        DataTable ToTable<T> (IEnumerable<T> varlist )
        {
            DataTable table = new DataTable ( );
            PropertyInfo [ ] oProps = null;
            if ( varlist == null )
                return table;
            foreach ( T rec in varlist )
            {
                if ( oProps == null )
                {
                    oProps = ( ( Type ) rec . GetType ( ) ) . GetProperties ( );
                    foreach ( PropertyInfo pi in oProps )
                    {
                        Type colType = pi . PropertyType;
                        if ( ( colType . IsGenericType ) && ( colType . GetGenericTypeDefinition ( ) == typeof ( Nullable<> ) ) )
                        {
                            colType = colType . GetGenericArguments ( ) [ 0 ];
                        }
                        table . Columns . Add ( new DataColumn ( pi . Name ,colType ) );
                    }
                }
                DataRow dr = table . NewRow ( );
                foreach ( PropertyInfo pi in oProps )
                {
                    dr [ pi . Name ] = pi . GetValue ( rec ,null ) == null ? DBNull . Value : pi . GetValue ( rec ,null );
                }
                table . Rows . Add ( dr );
            }
            return table;
        }

        void check_Event ( string name )
        {
            this . chartControl1 . Series . Clear ( );
            var query = dt . AsEnumerable ( )
                . Where ( p => p . Field<string> ( "QZ004" ) == name )
                . Select ( p => new
                {
                    QZ004 = p . Field<string> ( "QZ004" ) ,
                    QZ002 = p . Field<DateTime> ( "QZ002" ) ,
                    U = p . Field<decimal> ( "U" )
                } );

            DataTable table = ToTable ( query );
            //新建Series
            Series seOne = new Series ( "组长工资" ,ViewType . Bar );
            //设置Series样式
            //定性的
            seOne . ArgumentScaleType = ScaleType . Qualitative;
            //数字类型 
            seOne . ValueScaleType = ScaleType . Numerical;
            //绑定数据源
            seOne . DataSource = table . DefaultView;//table是获取到的数据(可以是数据库中的表，也可以是DataTable)
            seOne . ArgumentDataMember = "QZ002";//绑定的文字信息（名称）(坐标横轴)
            seOne . ValueDataMembers [ 0 ] = "U";//绑定的值（数据）(坐标纵轴)

            chartControl1 . Titles . Clear ( );
            //设置图表标题
            ChartTitle ct = new ChartTitle ( );
            ct . Text = comboBox1 . Text + "本年工资";
            ct . TextColor = Color . Black;//颜色
            ct . Font = new Font ( "Tahoma" ,12 );//字体
            ct . Dock = ChartTitleDockStyle . Top;//停靠在上方
            ct . Alignment = StringAlignment . Center;//居中显示
            this . chartControl1 . Titles . Add ( ct );
            chartControl1 . Series . Add ( seOne );
            //不现实指示图
            chartControl1 . Visible = true;

            Series seTwo = new Series ( "组长工资" ,ViewType . Line );
            seTwo . ArgumentScaleType = ScaleType . Qualitative;
            seTwo . ValueScaleType = ScaleType . Numerical;
            seTwo . DataSource = table . DefaultView;
            seTwo . ArgumentDataMember = "QZ002";
            seTwo . ValueDataMembers [ 0 ] = "U";

            chartControl2 . Titles . Clear ( );
            chartControl2 . Titles . Add ( ct );
            chartControl2 . Series . Clear ( );
            chartControl2 . Series . Add ( seTwo );
            chartControl2 . Visible = true;

            Series seTre = new Series ( "组长工资" ,ViewType .Pie );
            seTre . ArgumentScaleType = ScaleType . Qualitative;
            seTre . ValueScaleType = ScaleType . Numerical;
            seTre . DataSource = table . DefaultView;
            seTre . ArgumentDataMember = "QZ002";
            seTre . ValueDataMembers [ 0 ] = "U";

            chartControl3 . Titles . Clear ( );
            chartControl3 . Titles . Add ( ct );
            chartControl3 . Series . Clear ( );
            chartControl3 . Series . Add ( seTre );
            chartControl3 . Visible = true;
        }

        void check_Event_userName ( DateTime dateT )
        {
            this . chartControl1 . Series . Clear ( );
            var query = dt . AsEnumerable ( )
                . Where ( p => p . Field<DateTime> ( "QZ002" ) == dateT )
                . Select ( p => new
                {
                    QZ004 = p . Field<string> ( "QZ004" ) ,
                    QZ002 = p . Field<DateTime> ( "QZ002" ) ,
                    U = p . Field<decimal> ( "U" )
                } );

            DataTable table = ToTable ( query );
            if ( table == null || table . Rows . Count < 1 )
            {
                MessageBox . Show ( "此月工资没有" );
                return;
            }
            //新建Series
            Series seOne = new Series ( "组长工资" ,ViewType . Bar );
            //设置Series样式
            //定性的
            seOne . ArgumentScaleType = ScaleType . Qualitative;
            //数字类型 
            seOne . ValueScaleType = ScaleType . Numerical;
            //绑定数据源
            seOne . DataSource = table . DefaultView;//table是获取到的数据(可以是数据库中的表，也可以是DataTable)
            seOne . ArgumentDataMember = "QZ004";//绑定的文字信息（名称）(坐标横轴)
            seOne . ValueDataMembers [ 0 ] = "U";//绑定的值（数据）(坐标纵轴)

            chartControl1 . Titles . Clear ( );
            //设置图表标题
            ChartTitle ct = new ChartTitle ( );
            ct . Text = Convert . ToDateTime ( dateEdit1 . Text ) . ToString ( "yyyy年MM月" ) + "工资";
            ct . TextColor = Color . Black;//颜色
            ct . Font = new Font ( "Tahoma" ,12 );//字体
            ct . Dock = ChartTitleDockStyle . Top;//停靠在上方
            ct . Alignment = StringAlignment . Center;//居中显示
            this . chartControl1 . Titles . Add ( ct );
            chartControl1 . Series . Add ( seOne );
            //不现实指示图
            chartControl1 . Visible = true;

            Series seTwo = new Series ( "组长工资" ,ViewType . Line );
            seTwo . ArgumentScaleType = ScaleType . Qualitative;
            seTwo . ValueScaleType = ScaleType . Numerical;
            seTwo . DataSource = table . DefaultView;
            seTwo . ArgumentDataMember = "QZ004";
            seTwo . ValueDataMembers [ 0 ] = "U";

            chartControl2 . Titles . Clear ( );
            chartControl2 . Titles . Add ( ct );
            chartControl2 . Series . Clear ( );
            chartControl2 . Series . Add ( seTwo );
            chartControl2 . Visible = true;

            Series seTre = new Series ( "组长工资" ,ViewType . Pie );
            seTre . ArgumentScaleType = ScaleType . Qualitative;
            seTre . ValueScaleType = ScaleType . Numerical;
            seTre . DataSource = table . DefaultView;
            seTre . ArgumentDataMember = "QZ004";
            seTre . ValueDataMembers [ 0 ] = "U";

            chartControl3 . Titles . Clear ( );
            chartControl3 . Titles . Add ( ct );
            chartControl3 . Series . Clear ( );
            chartControl3 . Series . Add ( seTre );
            chartControl3 . Visible = true;
        }

        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            DataRow row = gridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                check_Event ( row [ "QZ004" ] . ToString ( ) );
            }
        }

    }
}