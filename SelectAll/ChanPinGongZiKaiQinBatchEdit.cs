using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;
using SelectAll . Class;
using System . Threading . Tasks;

namespace SelectAll
{
    public partial class ChanPinGongZiKaiQinBatchEdit : Form
    {
        public ChanPinGongZiKaiQinBatchEdit ( )
        {
            InitializeComponent( );
            GridViewMoHuSelect . SetFilter ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,gridView2 } );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,gridView2 } );
        }
        
        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        MulaolaoLibrary.ChanPinGongZiKaoQinLibrary model = new MulaolaoLibrary.ChanPinGongZiKaoQinLibrary( );
        MulaolaoBll.Bll.ChanPinGongZiKaoQinBll bll = new MulaolaoBll.Bll.ChanPinGongZiKaoQinBll( );
        public string num = "", oddNum = "", signOf = "", logins = "";
        string stateOfState = ""; bool result = false;
        string cn1 = "", cn2 = "", cn3 = "",cn4="";
        DataTable tableQuery,tableView;
        List<string> stList = new List<string>( );
        
        private void ChanPinGongZiKaiQinBatchEdit_Load ( object sender ,EventArgs e )
        {
            if ( !string.IsNullOrEmpty( num ) )
            {
                lookUpEdit1.Properties.DataSource = bll.GetDataTableWork( num );
                lookUpEdit1.Properties.DisplayMember = "GZ03";
                lookUpEdit2.Properties.DataSource = bll.GetDataTableWorkPro( );
                lookUpEdit2.Properties.DisplayMember = "GX02";
            }
            assginTable( );

            Task task = new Task ( getUserFor317 );
            task . Start ( );
        }


        #region settlement
        void assginTable ( )
        {
            tableQuery = bll.GetDataTableNum( );
            tableQuery.Columns.Add( "check" ,typeof( System.Boolean ) );
            gridControl1.DataSource = tableQuery;
        }
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "请选择结算年月" );
                return;
            }
            for ( int i = 0 ; i < gridView1.DataRowCount ; i++ )
            {
                if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                    stList.Add( gridView1.GetDataRow( i )["AE02"].ToString( ) );
            }
            if ( stList.Count < 0 )
            {
                MessageBox.Show( "请选择需要编辑的流水号" );
                return;
            }

            if ( signOf == "1" )
                stateOfState = "更改批量编辑结算月份";
            else
                stateOfState = "新增批量编辑结算月份";
            model.GZ42 = "批量编辑";
            model.GZ43 = MulaolaoBll . Drity . GetDt ( );
            //DateTime dtone = dateTimePicker1.Value;
            result = bll.BatchEdit( stList ,dateTimePicker1.Value ,model.GZ42 ,model.GZ43 ,oddNum ,"R_317" ,"产品工资考勤表" ,logins ,MulaolaoBll . Drity . GetDt ( ) ,"批量编辑" ,stateOfState ,textBox1.Text );
            if ( result == true )
                MessageBox.Show( "批量编辑结算月份成功,请刷新" );
            else
                MessageBox.Show( "批量编辑结算月份失败,请重试" );
            this.Close( );
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }
        private void textBox2_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e.KeyChar == 8 )
            {
                //textBox2.Text = "";
            }
            else
            {
                e.Handled = true;
            }
        }
        private void dateTimePicker1_ValueChanged ( object sender ,EventArgs e )
        {
            textBox1.Text = dateTimePicker1.Value.ToString( "yy年MM月" );
        }
        private void textBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e.KeyChar == 8 )
                textBox1.Text = "";
            else if ( e.KeyChar == 48 )
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 )
            {
                int num = gridView1.FocusedRowHandle;
                if ( gridView1.GetDataRow( num )["check"].ToString( ) == "True" )
                    gridView1.GetDataRow( num )["check"] = false;
                else
                    gridView1.GetDataRow( num )["check"] = true;
            }
        }
        #endregion

        #region Parts
        private void button4_Click ( object sender ,EventArgs e )
        {
            cn1 = "";
            cn1 = lookUpEdit1 . Text;
            cn2 = "";
            cn2 = "2";
            if ( checkBox1 . Checked == false )
                cn3 = "";
            else
                cn3 = checkBox1 . Text;
            if ( checkBox2 . Checked == false )
                cn4 = "";
            else
                cn4 = checkBox2 . Text;
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs ( cn1 ,cn2 ,cn3 ,cn4 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm ( this ,args );
            }
            this . Close ( );
        }
        private void button3_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }
        #endregion

        #region Price
        private void textBox5_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.fractionTb( e ,textBox5 );
        }
        private void textBox5_TextChanged ( object sender ,EventArgs e )
        {
            DateDay.textChangeTb( textBox5 );
        }
        private void textBox5_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox5.Text != "" && !DateDay.sevenFourTb( textBox5 ) )
            {
                this.textBox5.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多四位,如999.9999,请重新输入" );
            }
        }
        private void button6_Click ( object sender ,EventArgs e )
        {
            cn1 = "";
            cn1 = string.IsNullOrEmpty( textBox5.Text ) == true ? 0.ToString( ) : Convert.ToDecimal( textBox5.Text ).ToString( );
            cn2 = "";
            cn2 = "3";
            cn3 = cn4 = "";
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
        private void button5_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }
        #endregion

        #region WorkProcedure
        private void button8_Click ( object sender ,EventArgs e )
        {
            cn1 = "";
            cn1 = lookUpEdit2.Text;
            cn2 = "";
            cn2 = "4";
            cn3 = cn4 = "";
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 ,cn4 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm( this ,args );
            }
            this.Close( );
        }
        private void button7_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }
        #endregion

        #region num
        private void tabControl1_SelectedIndexChanged ( object sender ,EventArgs e )
        {
            if ( tabControl1.SelectedTab.Name == "tabPageFiv" )
            {
                lookUpEdit3.Properties.DataSource = bll.GetDataTableOfNum( ).DefaultView.ToTable( true ,"PQF01" );
                lookUpEdit3.Properties.DisplayMember = "PQF01";
            }
        }
        private void button10_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox2.Text ) )
            {
                MessageBox.Show( "请选择需要编辑的流水号" );
                return;
            }
            if ( string.IsNullOrEmpty( lookUpEdit3.Text ) )
            {
                MessageBox.Show( "请选择流水号" );
                return;
            }
            if ( signOf == "1" )
                stateOfState = "更改批量编辑流水号";
            else
                stateOfState = "新增批量编辑流水号";
            result = bll.UpdateOfNum( lookUpEdit3.Text ,textBox2.Text ,"R_317" ,"产品工资考勤表" ,logins ,MulaolaoBll . Drity . GetDt ( ) ,oddNum ,"批量编辑" ,stateOfState );
            if ( result == true )
                MessageBox.Show( "批量编辑结算月份成功,请刷新" );
            else
                MessageBox.Show( "批量编辑结算月份失败,请重试" );
            this.Close( );
        }
        private void button9_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }
        #endregion

        #region 
        void getUserFor317 ( )
        {
            DataTable tableUser = bll . getUserFor317 ( );
            txtUser . Properties . DataSource = tableUser;
            txtUser . Properties . DisplayMember = "GZ02";
            txtUser . Properties . ValueMember = "GZ33";
        }
        private void btnQuery_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtUser . Text ) )
            {
                MessageBox . Show ( "请选择人员信息" );
                return;
            }
            if ( string . IsNullOrEmpty ( date . Text ) )
            {
                MessageBox . Show ( "请选择日期" );
                return;
            }

            string strWhere = "1=1";
            strWhere = strWhere + " AND GZ33='" + txtUser . EditValue . ToString ( ) + "' AND GZ35='" + Convert . ToDateTime ( date . Text ) . Year + "' AND GZ24='" + Convert . ToDateTime ( date . Text ) . Month + "'";

            tableView = bll . getTableView ( strWhere );
            gridControl2 . DataSource = tableView;
        }
        private void btnOk_Click ( object sender ,EventArgs e )
        {
            if ( LoginUser . Num . Equals ( "MLL-0001" ) || LoginUser . Num . Equals ( "MLL-0008" ) || LoginUser . Num . Equals ( "MLL-0007" ) )
            {
                gridView2 . CloseEditor ( );
                gridView2 . UpdateCurrentRow ( );

                result = bll . UpdateSales ( tableView ,Convert . ToDateTime ( date . Text ) . Year ,Convert . ToDateTime ( date . Text ) . Month );
                if ( result )
                {
                    MessageBox . Show ( "编辑成功,请查询" );
                    this . Close ( );
                }
                else
                    MessageBox . Show ( "编辑失败" );
            }
            else
                MessageBox . Show ( "您无权编辑" );
        }
        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . Close ( );
        }
        #endregion

    }
}
