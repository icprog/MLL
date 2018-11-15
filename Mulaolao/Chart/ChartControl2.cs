using DevExpress . Skins;
using System . Text;
using StudentMgr;
using System . Data;
using DevExpress . XtraCharts;
using System . Collections . Generic;
using System . Reflection;
using System;
using System . Linq;

namespace text
{
    public partial class ChartControl2 :DevExpress . XtraEditors . XtraForm
    {
        protected static DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel=new DevExpress.LookAndFeel.DefaultLookAndFeel();
        DataTable tableView,chartTableOne,chartTableTwo;
        string num=string.Empty,part=string.Empty,work=string.Empty;
        
        public ChartControl2 ( )
        {
            InitializeComponent ( );

            //defaultLookAndFeel . LookAndFeel . SkinName = "Visual Studio 2013 Dark";
            Skin GridSkin = GridSkins . GetSkin ( defaultLookAndFeel . LookAndFeel );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            this . WindowState = System . Windows . Forms . FormWindowState . Maximized;

            getTableView ( );
        }
        
        void getTableView ( )
        {
            StringBuilder strSql = new StringBuilder ( );
            strSql . Append ( "WITH CET AS (" );
            strSql . Append ( "SELECT PQX01,PQX29,PQX14,PQX15,PQX16,PQX25,CONVERT(DATE,GETDATE(),121) PQX26,DATEADD(DAY,DATEDIFF( DAY ,CONVERT(DATE,GETDATE(),121) ,PQX30 ) - PQX19 + PQX16 - PQX18,CONVERT(DATE,GETDATE(),121)) U3,PQX30,U29,DATEDIFF( DAY ,PQX25 ,PQX30 ) - PQX19 + PQX16 - PQX18 U1,ISNULL(U2,0) U2,U4,PQX32,ISNULL(U9,0) U9,PQX32*PQX36-PQX34 U5,U12,U14,PQX21,PQX34,PQX36,PQX23,PQX24 FROM R_PQX),CFT AS (SELECT AE02 FROM R_PQAE WHERE AE02 NOT IN (SELECT AE02 FROM R_PQAE WHERE AE21 IS NOT NULL)) SELECT A.*,CASE WHEN U2=0 THEN 0 ELSE CONVERT(DECIMAL(18,2),U1*1.0/U2*100) END U0 FROM CET A LEFT JOIN CFT B ON A.PQX01=B.AE02 WHERE U5>=0 AND GETDATE()<=DATEADD(DAY,30,U3) ORDER BY PQX01,PQX14,PQX16 " );

            tableView = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            gridControl1 . DataSource = tableView;

            if ( tableView != null && tableView . Rows . Count > 0 )
            {
                DataRow row = tableView . Rows [ 0 ];
                if ( row != null )
                {
                    num = row [ "PQX01" ] . ToString ( );
                    if ( string . IsNullOrEmpty ( num ) )
                        return;
                   // chartData ( );
                    part = row [ "PQX15" ] . ToString ( );
                    if ( !string . IsNullOrEmpty ( part ) )
                        chartDataTwo ( );
                    work = row [ "PQX14" ] . ToString ( );
                    if ( !string . IsNullOrEmpty ( work ) )
                        chartDataTre ( );
                   // chartDataFor ( );
                    chartDataFiv ( );
                    chartDataSix ( );
                   // chartDataSev ( );
                }
            }
        }

        private void bandedGridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row != null )
            {
                num = row [ "PQX01" ] . ToString ( );
                if ( string . IsNullOrEmpty ( num ) )
                    return;
                //chartData ( );
                part = row [ "PQX15" ] . ToString ( );
                if ( !string . IsNullOrEmpty ( part ) )
                    chartDataTwo ( );
                work = row [ "PQX14" ] . ToString ( );
                if ( !string . IsNullOrEmpty ( work ) )
                    chartDataTre ( );
                //chartDataFor ( );
                chartDataFiv ( );
                chartDataSix ( );
                //chartDataSev ( );
            }
        }
        
        //void chartData ( )
        //{
        //    var query = tableView . AsEnumerable ( ) . Where ( p => p . Field<string> ( "PQX01" ) == num ) . Select ( p => new
        //    {
        //        U = p . Field<int> ( "U1" ) ,
        //        PQX15 = p . Field<string> ( "PQX15" )
        //    } );

        //    ChartTitle cTitle = new ChartTitle ( );
        //    cTitle . Text = num + " 生产周期";
        //    cTitle . TextColor = System . Drawing . Color . Black;
        //    cTitle . Font = new System . Drawing . Font ( "宋体" ,12F ,System . Drawing . FontStyle . Bold ,System . Drawing . GraphicsUnit . Point ,( ( byte ) ( 0 ) ) );
        //    cTitle . Dock = ChartTitleDockStyle . Top;
        //    cTitle . Alignment = System . Drawing . StringAlignment . Near;
        //    this . chartControl1 . Titles . Clear ( );
        //    this . chartControl1 . Titles . Add ( cTitle );

        //    Series seOne = new Series ( "工序工序产期" ,ViewType . Line );
        //    //设置Series样式
        //    //定性的
        //    seOne . ArgumentScaleType = ScaleType . Qualitative;
        //    //数字类型 
        //    //seOne . ValueScaleType = ScaleType . Qualitative;
        //    chartTableOne = ToTable ( query );
        //    //绑定数据源
        //    seOne . DataSource = chartTableOne . DefaultView;//table是获取到的数据(可以是数据库中的表，也可以是DataTable)
        //    seOne . ArgumentDataMember = "PQX15";//绑定的文字信息（名称）(坐标横轴)
        //    seOne . ValueDataMembers [ 0 ] = "U";//绑定的值（数据）(坐标纵轴)

        //    LineSeriesView viewOne = new LineSeriesView ( );
        //    viewOne . LineMarkerOptions . Color = System . Drawing . Color . FromArgb ( ( ( int ) ( ( ( byte ) ( 247 ) ) ) ) ,( ( int ) ( ( ( byte ) ( 150 ) ) ) ) ,( ( int ) ( ( ( byte ) ( 70 ) ) ) ) );
        //    viewOne . MarkerVisibility = DevExpress . Utils . DefaultBoolean . True;
        //    seOne . View = viewOne;

        //    chartControl1 . Series . Clear ( );
        //    chartControl1 . Series . Add ( seOne );

        //    this . chartControl1 . Legend . Visibility = DevExpress . Utils . DefaultBoolean . False;

        //    this . chartControl1 . Visible = true;
        //}

        void chartDataTwo ( )
        {
            var query = tableView . AsEnumerable ( ) .
                Where ( p => p . Field<string> ( "PQX15" ) == part ) .
             Select (
                p => new
                {
                    U = p . Field<int> ( "U1" ) ,
                    PQX01 = p . Field<string> ( "PQX01" )
                }
                );

            ChartTitle cTitle = new ChartTitle ( );
            cTitle . Text = part + " 生产周期";
            cTitle . TextColor = System . Drawing . Color . Black;
            cTitle . Font = new System . Drawing . Font ( "宋体" ,12F ,System . Drawing . FontStyle . Bold ,System . Drawing . GraphicsUnit . Point ,( ( byte ) ( 0 ) ) );
            cTitle . Dock = ChartTitleDockStyle . Top;
            cTitle . Alignment = System . Drawing . StringAlignment . Near;
            this . chartControl3 . Titles . Clear ( );
            this . chartControl3 . Titles . Add ( cTitle );

            Series seOne = new Series ( "流水工序产期" ,ViewType . Bar );
            //设置Series样式
            //定性的
            seOne . ArgumentScaleType = ScaleType . Qualitative;
            //数字类型 
            //seOne . ValueScaleType = ScaleType . Qualitative;
            chartTableTwo = ToTable ( query );
            chartTableTwo . DefaultView . Sort = "PQX01 asc";
            //chartTableTwo . DefaultView . Sort = "PQX14 asc";
            //chartTableTwo . DefaultView . Sort = "PQX16 asc";
            //绑定数据源
            seOne . DataSource = chartTableTwo . DefaultView;//table是获取到的数据(可以是数据库中的表，也可以是DataTable)
            seOne . ArgumentDataMember = "PQX01";//绑定的文字信息（名称）(坐标横轴)
            seOne . ValueDataMembers [ 0 ] = "U";//绑定的值（数据）(坐标纵轴)

            //LineSeriesView viewOne = new LineSeriesView ( );
            //viewOne . LineMarkerOptions . Color = System . Drawing . Color . FromArgb ( ( ( int ) ( ( ( byte ) ( 247 ) ) ) ) ,( ( int ) ( ( ( byte ) ( 150 ) ) ) ) ,( ( int ) ( ( ( byte ) ( 70 ) ) ) ) );
            //viewOne . MarkerVisibility = DevExpress . Utils . DefaultBoolean . True;
            //seOne . View = viewOne;


            chartControl3 . Series . Clear ( );
            chartControl3 . Series . Add ( seOne );

            this . chartControl3 . Legend . Visibility = DevExpress . Utils . DefaultBoolean . False;

            this . chartControl3 . Visible = true;
        }

        private void ChartControl2_Load ( object sender ,EventArgs e )
        {
            foreach ( DevExpress . XtraGrid . Columns . GridColumn column in bandedGridView1 . Columns )
            {
                column . AppearanceHeader . Font = new System . Drawing . Font ( "宋体" ,9F ,System . Drawing . FontStyle . Bold );
                column . AppearanceHeader . Options . UseFont = true;
                column . AppearanceHeader . Options . UseTextOptions = true;
                column . AppearanceHeader . TextOptions . HAlignment = DevExpress . Utils . HorzAlignment . Center;
                column . AppearanceHeader . TextOptions . WordWrap = DevExpress . Utils . WordWrap . Wrap;
            }
            bandedGridView1 . BestFitColumns ( );
        }

        void chartDataTre ( )
        {
            var query = tableView . AsEnumerable ( ) .
                Where ( p =>
                    p . Field<string> ( "PQX01" ) == num
                    &&
                    p . Field<string> ( "PQX14" ) == work ) .
                Select (
                    p => new
                    {
                        U = p . Field<Decimal> ( "U0" ) ,
                        PQX15 = p . Field<string> ( "PQX15" )
                    }
                );

            ChartTitle cTitle = new ChartTitle ( );
            cTitle . Text = num + " " + work + " 生产周期比率";
            cTitle . TextColor = System . Drawing . Color . Black;
            cTitle . Font = new System . Drawing . Font ( "宋体" ,12F ,System . Drawing . FontStyle . Bold ,System . Drawing . GraphicsUnit . Point ,( ( byte ) ( 0 ) ) );
            cTitle . Dock = ChartTitleDockStyle . Top;
            cTitle . Alignment = System . Drawing . StringAlignment . Near;
            this . chartControl4 . Titles . Clear ( );
            this . chartControl4 . Titles . Add ( cTitle );

            Series seOne = new Series ( "流水工序产期" ,ViewType . Bar );
            //设置Series样式
            //定性的
            seOne . ArgumentScaleType = ScaleType . Qualitative;
            //数字类型 
            //seOne . ValueScaleType = ScaleType . Qualitative;
            chartTableTwo = ToTable ( query );
            chartTableTwo . DefaultView . Sort = "PQX15 asc";
            //chartTableTwo . DefaultView . Sort = "PQX14 asc";
            //chartTableTwo . DefaultView . Sort = "PQX16 asc";
            //绑定数据源
            seOne . DataSource = chartTableTwo . DefaultView;//table是获取到的数据(可以是数据库中的表，也可以是DataTable)
            seOne . ArgumentDataMember = "PQX15";//绑定的文字信息（名称）(坐标横轴)
            seOne . ValueDataMembers [ 0 ] = "U";//绑定的值（数据）(坐标纵轴)

            //LineSeriesView viewOne = new LineSeriesView ( );
            //viewOne . LineMarkerOptions . Color = System . Drawing . Color . FromArgb ( ( ( int ) ( ( ( byte ) ( 247 ) ) ) ) ,( ( int ) ( ( ( byte ) ( 150 ) ) ) ) ,( ( int ) ( ( ( byte ) ( 70 ) ) ) ) );
            //viewOne . MarkerVisibility = DevExpress . Utils . DefaultBoolean . True;
            //seOne . View = viewOne;


            chartControl4 . Series . Clear ( );
            chartControl4 . Series . Add ( seOne );

            this . chartControl4 . Legend . Visibility = DevExpress . Utils . DefaultBoolean . False;

            this . chartControl4 . Visible = true;
        }

        //void chartDataFor ( )
        //{
        //    var query = from p in tableView . AsEnumerable ( ) . 
        //                Where ( p => p . Field<string> ( "PQX01" ) == num )
        //                group p by p . Field<string> ( "PQX14" ) into g
        //                select new
        //                {
        //                    PQX14 = g . Key ,
        //                    count = g . Count ( )
        //                };
                

        //    ChartTitle cTitle = new ChartTitle ( );
        //    cTitle . Text = num + " 零件占比";
        //    cTitle . TextColor = System . Drawing . Color . Black;
        //    cTitle . Font = new System . Drawing . Font ( "宋体" ,10F ,System . Drawing . FontStyle . Bold ,System . Drawing . GraphicsUnit . Point ,( ( byte ) ( 0 ) ) );
        //    cTitle . Dock = ChartTitleDockStyle . Top;
        //    cTitle . Alignment = System . Drawing . StringAlignment . Near;
        //    this . chartControl5 . Titles . Clear ( );
        //    this . chartControl5 . Titles . Add ( cTitle );

        //    Series seOne = new Series ( "流水工序产期" ,ViewType . Pie );
        //    //设置Series样式
        //    //定性的
        //    seOne . ArgumentScaleType = ScaleType . Qualitative;
        //    chartTableTwo = ToTable ( query );
        //    //绑定数据源
        //    seOne . DataSource = chartTableTwo . DefaultView;//table是获取到的数据(可以是数据库中的表，也可以是DataTable)
        //    seOne . ArgumentDataMember = "PQX14";//绑定的文字信息（名称）(坐标横轴)
        //    seOne . ValueDataMembers [ 0 ] = "count";//绑定的值（数据）(坐标纵轴)

        //    chartControl5 . Series . Clear ( );
        //    chartControl5 . Series . Add ( seOne );

        //    this . chartControl5 . Legend . Visibility = DevExpress . Utils . DefaultBoolean . False;

        //    this . chartControl5 . Visible = true;
        //}

        void chartDataFiv ( )
        {
            var query = from p in tableView . AsEnumerable ( ) .
                        Where ( p => p . Field<string> ( "PQX01" ) == num )
                        group p by p . Field<string> ( "PQX15" ) into g
                        select new
                        {
                            PQX14 = g . Key ,
                            count = g . Count ( )
                        };


            ChartTitle cTitle = new ChartTitle ( );
            cTitle . Text = num + " 工序占比";
            cTitle . TextColor = System . Drawing . Color . Black;
            cTitle . Font = new System . Drawing . Font ( "宋体" ,10F ,System . Drawing . FontStyle . Bold ,System . Drawing . GraphicsUnit . Point ,( ( byte ) ( 0 ) ) );
            cTitle . Dock = ChartTitleDockStyle . Top;
            cTitle . Alignment = System . Drawing . StringAlignment . Near;
            this . chartControl6 . Titles . Clear ( );
            this . chartControl6 . Titles . Add ( cTitle );

            Series seOne = new Series ( "流水工序产期" ,ViewType . Pie );
            //设置Series样式
            //定性的
            seOne . ArgumentScaleType = ScaleType . Qualitative;
            seOne . ValueScaleType = ScaleType . Numerical;
            seOne . PointOptions . PointView = PointView . ArgumentAndValues;
            chartTableTwo = ToTable ( query );
            //绑定数据源
            seOne . DataSource = chartTableTwo . DefaultView;//table是获取到的数据(可以是数据库中的表，也可以是DataTable)
            seOne . ArgumentDataMember = "PQX14";//绑定的文字信息（名称）(坐标横轴)
            seOne . ValueDataMembers [ 0 ] = "count";//绑定的值（数据）(坐标纵轴)


            chartControl6 . Series . Clear ( );
            chartControl6 . Series . Add ( seOne );

            this . chartControl6 . Legend . Visibility = DevExpress . Utils . DefaultBoolean . False;

            this . chartControl6 . Visible = true;
        }

        void chartDataSix ( )
        {
            var query = from p in tableView . AsEnumerable ( ) .
                        Where ( p => p . Field<string> ( "PQX01" ) == num )
                        group p by p . Field<string> ( "PQX21" ) into g
                        select new
                        {
                            PQX14 = g . Key ,
                            count = g . Count ( )
                        };


            ChartTitle cTitle = new ChartTitle ( );
            cTitle . Text = num + " 组长占比";
            cTitle . TextColor = System . Drawing . Color . Black;
            cTitle . Font = new System . Drawing . Font ( "宋体" ,10F ,System . Drawing . FontStyle . Bold ,System . Drawing . GraphicsUnit . Point ,( ( byte ) ( 0 ) ) );
            cTitle . Dock = ChartTitleDockStyle . Top;
            cTitle . Alignment = System . Drawing . StringAlignment . Near;
            this . chartControl7 . Titles . Clear ( );
            this . chartControl7 . Titles . Add ( cTitle );

            Series seOne = new Series ( "流水工序产期" ,ViewType . Pie );
            //设置Series样式
            //定性的
            seOne . ArgumentScaleType = ScaleType . Qualitative;
            seOne . ValueScaleType = ScaleType . Numerical;
            seOne . PointOptions . PointView = PointView . ArgumentAndValues;
            chartTableTwo = ToTable ( query );
            //绑定数据源
            seOne . DataSource = chartTableTwo . DefaultView;//table是获取到的数据(可以是数据库中的表，也可以是DataTable)
            seOne . ArgumentDataMember = "PQX14";//绑定的文字信息（名称）(坐标横轴)
            seOne . ValueDataMembers [ 0 ] = "count";//绑定的值（数据）(坐标纵轴)

            chartControl7 . Series . Clear ( );
            chartControl7 . Series . Add ( seOne );

            this . chartControl7 . Legend . Visibility = DevExpress . Utils . DefaultBoolean . False;

            this . chartControl7 . Visible = true;
        }

        //void chartDataSev ( )
        //{
        //    var query = from p 
        //                in tableView . AsEnumerable ( ) .
        //                Where ( p => p . Field<string> ( "PQX01" ) == num )
        //                group p by p . Field<string> ( "PQX14" ) 
        //                into g
        //                select 
        //                new
        //                {
        //                    PQX14 = g . Key ,
        //                    count = g . Count ( )
        //                };


        //    ChartTitle cTitle = new ChartTitle ( );
        //    cTitle . Text = num + " 零件占比";
        //    cTitle . TextColor = System . Drawing . Color . Black;
        //    cTitle . Font = new System . Drawing . Font ( "宋体" ,10F ,System . Drawing . FontStyle . Bold ,System . Drawing . GraphicsUnit . Point ,( ( byte ) ( 0 ) ) );
        //    cTitle . Dock = ChartTitleDockStyle . Top;
        //    cTitle . Alignment = System . Drawing . StringAlignment . Near;
        //    this . chartControl8 . Titles . Clear ( );
        //    this . chartControl8 . Titles . Add ( cTitle );

        //    Series seOne = new Series ( "零件占比" ,ViewType . Pie );
        //    //设置Series样式
        //    //定性的
        //    seOne . ArgumentScaleType = ScaleType . Qualitative;
        //    chartTableTwo = ToTable ( query );
        //    //绑定数据源
        //    seOne . DataSource = chartTableTwo . DefaultView;//table是获取到的数据(可以是数据库中的表，也可以是DataTable)
        //    seOne . ArgumentDataMember = "PQX14";//绑定的文字信息（名称）(坐标横轴)
        //    seOne . ValueDataMembers [ 0 ] = "count";//绑定的值（数据）(坐标纵轴)

        //    chartControl8 . Series . Clear ( );
        //    chartControl8 . Series . Add ( seOne );

        //    this . chartControl8 . Legend . Visibility = DevExpress . Utils . DefaultBoolean . False;

        //    this . chartControl8 . Visible = true;
        //}

        /// <summary>
        /// 下面通过一个方法来实现返回DataTable类型 
        /// LINQ返回DataTable类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="varlist"></param>
        /// <returns></returns>
        DataTable ToTable<T> ( IEnumerable<T> varlist )
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

    }
}
