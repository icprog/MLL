using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;
using FastReport;
using FastReport . Export . Xml;

namespace Mulaolao . Wages
{
    public partial class R_FrmChanPinGongZiKaoQinHuiZong : FormChild
    {
        public R_FrmChanPinGongZiKaoQinHuiZong ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { bandedGridView1  } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }

        MulaolaoBll.Bll.ChanPinGonZiKaoQinHuiZongBll bll = new MulaolaoBll.Bll.ChanPinGonZiKaoQinHuiZongBll( );
        DataTable searCh, tableQuery;
        string strWhere = "1=1", file = "", headOfWorkShop = "", Statistician = "";
        Report report = new Report( );
        DataSet RDataSet;

        private void R_FrmChanPinGongZiKaoQinHuiZong_Load ( object sender ,EventArgs e )
        {
            toolPrint.Enabled = toolExport.Enabled = true;

            searCh = bll.GetDataTableProduct( );
            searchLookUpEdit1.Properties.DataSource = searCh;
            searchLookUpEdit1.Properties.DisplayMember = "GZ22";
            searchLookUpEdit1.Properties.ValueMember = "GZ01";

            lookUpEdit1.Properties.DataSource = bll.GetDataTableHeadOfWorkShop( );
            lookUpEdit1.Properties.DisplayMember = "GZ30";
            lookUpEdit1.Properties.ValueMember = "GZ31";
        }

        #region Event
        private void searchLookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( searchLookUpEdit1.Text != null )
            {
                string str = searchLookUpEdit1.Text;
                textBox3.Text = searchLookUpEdit1.EditValue.ToString( );
                DataRow[] row = searCh.Select( string.Format( "GZ01='{0}'" ,textBox3.Text ) );
                if ( row != null && row.Length > 0 )
                {
                    DataRow ow = row[0];
                    textBox1.Text = ow["GZ23"].ToString( );
                    textBox2.Text = ow["GZ34"].ToString( );
                }
            }
        }
        private void lookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit1.EditValue != null )
            {
                lookUpEdit2.Properties.DataSource = bll.GetDataTableStatistician( lookUpEdit1.EditValue.ToString( ) );
                lookUpEdit2.Properties.DisplayMember = "GZ37";
                lookUpEdit2.Properties.ValueMember = "GZ38";
            }
        }
        private void bandedGridView1_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            summaryCalcu( );
        }
        private void dateTimePicker1_ValueChanged ( object sender ,EventArgs e )
        {
            textBox4.Text = dateTimePicker1.Value.ToString( "MM月" );
        }
        private void textBox4_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e.KeyChar == 8 )
            {
                textBox4.Text = "";
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion

        #region Table
        //Query
        private void button1_Click ( object sender ,EventArgs e )
        {
            //if ( lookUpEdit1.EditValue == null )
            //{
            //    MessageBox.Show( "请选择车间主任" );
            //    return;
            //}
            //if ( lookUpEdit2.EditValue == null )
            //{
            //    MessageBox.Show( "请选择统计员" );
            //    return;
            //}
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( textBox3.Text ) )
                strWhere = strWhere + " AND GZ01='" + textBox3.Text + "'";
            if ( lookUpEdit1.EditValue != null )
            {
                strWhere = strWhere + " AND GZ31='" + lookUpEdit1.EditValue.ToString( ) + "'";
                headOfWorkShop = lookUpEdit1.Text;
            }
            if ( lookUpEdit2.EditValue != null )
            {
                strWhere = strWhere + " AND GZ38='" + lookUpEdit2.EditValue.ToString( ) + "'";
                Statistician = lookUpEdit2.Text;
            }
            if ( !string.IsNullOrEmpty( textBox4.Text ) )
                strWhere = strWhere + " AND GZ44='" + dateTimePicker1.Value.ToString( "yyyy" ) + "' AND GZ28='" + dateTimePicker1.Value.ToString( "MM" ) + "'";

            tableQuery = bll.GetDataTableAll( strWhere  );
            gridControl1.DataSource = tableQuery;
            summaryCalcu( );
        }
        //Clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            searchLookUpEdit1.Text = textBox1.Text = textBox2.Text = textBox3.Text = "";
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = -1;
            textBox4 . Text = string . Empty;
            gridControl1.DataSource = null;
        }
        void summaryCalcu ( )
        {
            U9.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Convert.ToDecimal( GZ.SummaryItem.SummaryValue ) == 0 ? 0.ToString( ) : Math.Round( Convert.ToDecimal( U3.SummaryItem.SummaryValue ) / Convert.ToDecimal( GZ.SummaryItem.SummaryValue ) ,4 ).ToString( ) );
        }
        #endregion
        
        #region Main
        void printTable ( )
        {
            RDataSet = new DataSet( );
            if ( string.IsNullOrEmpty( strWhere ) )
                strWhere = "1=1";
            DataTable print = bll.GetDataTablePrint( strWhere );
            print.TableName = "R_PQW";
            RDataSet.Tables.Add( print );
        }
        protected override void print ( )
        {
            base.print( );

            if ( string.IsNullOrEmpty( textBox4.Text ) )
            {
                MessageBox.Show( "请选择结算月份" );
                return;   
            }
            strWhere = "1=1";
            strWhere = strWhere + " AND GZ44='" + dateTimePicker1.Value.ToString( "yyyy" ) + "' AND GZ28='" + dateTimePicker1.Value.ToString( "MM" ) + "'";

            printTable( );
            file = "";
            file = /*Environment.CurrentDirectory;*/System.Windows.Forms.Application.StartupPath;
            report.Load( file + "\\R_225.frx" );
            report.RegisterData( RDataSet );
            report.Show( );
        }
        protected override void export ( )
        {
            base.export( );

            if ( string.IsNullOrEmpty( textBox4.Text ) )
            {
                MessageBox.Show( "请选择结算月份" );
                return;
            }
            strWhere = "1=1";
            strWhere = strWhere + " AND GZ44='" + dateTimePicker1.Value.ToString( "yyyy" ) + "' AND GZ28='" + dateTimePicker1.Value.ToString( "MM" ) + "'";

            printTable( );
            file = "";
            file = System.Windows.Forms.Application.StartupPath;
            report.Load( file + "\\R_225.frx" );
            report.RegisterData( RDataSet );
            report.Prepare( );
            XMLExport exprots = new XMLExport( );
            exprots.Export( report );
        }
        #endregion
    }
}
