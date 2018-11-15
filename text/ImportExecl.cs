using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Linq;
using System . Text;
using System . Windows . Forms;
using StudentMgr;
using DevExpress . XtraCharts;
using DevExpress . XtraEditors;
using System . Data . OleDb;

namespace text
{
    public partial class ImportExecl : Form
    {
        public ImportExecl ( )
        {
            InitializeComponent( );
        }

        private void CharSet_Load ( object sender ,EventArgs e )
        {
            /*
            chartControl1.Series.Clear( );
            Series seriesOne = new Series( "数据统计" ,ViewType.Bar );
            chartControl1.Series.Add( seriesOne );
            Series seriesTwo = new Series( "数据交换" ,ViewType.Bar );
            chartControl1.Series.Add( seriesTwo );
            DataTable da = SqlHelper.ExecuteDataTable( "SELECT TOP 20 PQF01,PQF09,PQF06/100 PQF06 FROM R_PQF" );
            chartControl1.DataSource = da;

            SeriesPoint point = null;
            SeriesPoint pointes = null;
            foreach ( DataRow row in da.Rows )
            {
                if ( row["PQF01"] != null )
                {
                    point = new SeriesPoint( row["PQF01"].ToString( ) );
                    double[] vals = { Convert.ToDouble( row["PQF09"] ) };
                    point.Values = vals;
                    seriesOne.Points.Add( point );
                    pointes = new SeriesPoint( row["PQF01"].ToString( ) );
                    double[] vales = { Convert.ToDouble( row["PQF06"] ) };
                    pointes.Values = vales;
                    seriesTwo.Points.Add( pointes );
                }
            }
            */
        }

        //import for execl
        private void button1_Click ( object sender ,EventArgs e )
        {
            OpenFileDialog open = new OpenFileDialog ( );
            open . Title = "execl文件";
            open . FileName = "";
            open . InitialDirectory = Environment . GetFolderPath ( Environment . SpecialFolder . MyDocuments );
            open . Filter = "所有文件(*.*)|*.*|Execl2003文件(*.xls)|*.xls|Execl2007文件(*.xlsx)|*.xlsx";
            open . ValidateNames = true;
            open . CheckFileExists = true;
            open . CheckPathExists = true;
            string strName = string . Empty;
            if ( open . ShowDialog ( ) == DialogResult . OK )
                strName = open . FileName;
            if ( strName == "" )
            {
                MessageBox . Show ( "没有Execl文件!无法进行数据导入" );
                return;
            }
            try
            {
                DataSet RData = new DataSet ( );
                string text = string . Format ( "Provide=Microsoft.Jet.OLEDB.4.0;Data Source='{0}';Extended Properties=Execl 8.0;" ,strName );
                string execlFirstTableName = GetExeclFirstTableName ( text );
                RData . Tables . Clear ( );
                this . gridControl1 . DataSource = null;
                OleDbConnection selectConnection = new OleDbConnection ( );
                OleDbDataAdapter oleDbDataAdaper = new OleDbDataAdapter ( string . Format ( "SELECT * FROM [{0}]" ,execlFirstTableName ) ,selectConnection );
                oleDbDataAdaper . Fill ( RData );
                this . gridControl1 . DataSource = RData . Tables [ 0 ];
                this . gridView1 . PopulateColumns ( );
            }
            catch (Exception ex)
            {
                MessageBox . Show ( ex . Message ,"从电子表格文件中装载数据异常!" );
            }
        }

        /// <summary>
        /// 返回工作表第一个工作表表名
        /// </summary>
        /// <param name="connectsting">execl连接字符串</param>
        /// <returns></returns>
        public static string GetExeclFirstTableName ( string connectsting )
        {
            using ( OleDbConnection connection = new OleDbConnection ( connectsting ) )
            {
                string tableName = string . Empty;
                if ( connection . State == ConnectionState . Closed )
                    connection . Open ( );
                DataTable dt = connection . GetOleDbSchemaTable ( OleDbSchemaGuid . Tables ,null );
                if ( dt != null && dt . Rows . Count > 0 )
                {
                    tableName = ConvertTo<string> ( dt . Rows [ 0 ] [ 2 ] );
                }

                return tableName;
            }
        }

        /// <summary>
        /// 将数据转换为指定的数据类型
        /// </summary>
        /// <typeparam name="T">转换的目标类型</typeparam>
        /// <param name="data">转换的数据</param>
        /// <returns></returns>
        public static T ConvertTo<T> ( Object data )
        {
            if ( data == null || Convert . IsDBNull ( data ) )
                return default ( T );
            Object obj = ConvertTo ( data ,typeof ( T ) );
            if ( obj == null )
                return default ( T );
            return ( T ) obj;
        }

        /// <summary>
        /// 将数据转换为指定的数据类型
        /// </summary>
        /// <param name="data">转换的数据</param>
        /// <param name="targetType">转换的目标类型</param>
        /// <returns></returns>
        public static object ConvertTo ( object data ,Type targetType )
        {
            if ( data == null && Convert . IsDBNull ( data ) )
                return null;
            Type typeTwo = data . GetType ( );
            if ( targetType == typeTwo )
                return data;
            if ( ( ( targetType == typeof ( Guid ) ) || ( targetType == typeof ( Guid? ) ) ) && ( typeTwo == typeof ( string ) ) )
            {
                if ( string . IsNullOrEmpty ( data . ToString ( ) ) )
                    return null;
                return new Guid ( data . ToString ( ) );
            }
            if ( targetType . IsEnum )
            {
                try
                {
                    return Enum . Parse ( targetType ,data . ToString ( ) ,true );
                }
                catch { return Enum . ToObject ( targetType ,data ); }
            }
            if (targetType.IsGenericType)
            {
                targetType = targetType . GetGenericArguments ( ) [ 0 ];
            }

            return Convert . ChangeType ( data ,targetType );
        }

    }
}
