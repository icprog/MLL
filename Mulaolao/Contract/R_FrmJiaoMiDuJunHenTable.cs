using DevExpress.XtraGrid.Views.Grid;
using Mulaolao.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mulaolao.Contract
{
    public partial class R_FrmJiaoMiDuJunHenTable : FormChild
    {

        public R_FrmJiaoMiDuJunHenTable ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }

        MulaolaoBll.Bll.JiaoMiDuJunHenTableBll bll = new MulaolaoBll.Bll.JiaoMiDuJunHenTableBll( );
        MulaolaoLibrary.JiaoMiDuJunHengTableLibrary model = new MulaolaoLibrary.JiaoMiDuJunHengTableLibrary( );
        List<string> listCount = new List<string>( );
        DataTable generateQuery, tableQuery;
        string strWhere = "1=1", sign = "", weihu = "";
        bool result = false; SpecialPowers sp = new SpecialPowers( );

        private void R_FrmJiaoMiDuJunHenTable_Load ( object sender ,EventArgs e )
        {
            Power( this );

            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;
            Ergodic.FormEverySpliEnableFalse( this );
            textBox7.Enabled = false;
            label45.Visible = label46.Visible = false;
            textBox7.Enabled = false;
        }

        private void R_FrmJiaoMiDuJunHenTable_Shown ( object sender ,EventArgs e )
        {
            model.JZ001 = Merges.oddNum;
            if ( model.JZ001 != null && model.JZ001 != "" )
                autoQuery( );
            Merges.oddNum = "";
        }

        #region Query
        SelectAll.JiaoHeBanJunHengNumAll numQuery = new SelectAll.JiaoHeBanJunHengNumAll( );
        private void button6_Click ( object sender ,EventArgs e )
        {
            listCount.Clear( );
            numQuery.StartPosition = FormStartPosition.CenterScreen;
            numQuery.PassDataBetweenForm += new SelectAll.JiaoHeBanJunHengNumAll.PassDataBetweenFormHandler( numQuery_PassDataBetweenForm );
            numQuery.ShowDialog( );

            if ( listCount.Count > 0 )
            {
                if ( listCount.Count < 1 )
                    return;
                strWhere = "''";
                foreach ( string str in listCount )
                {
                    strWhere = strWhere + "," + "'" + str + "'";
                }
                if ( string.IsNullOrEmpty( strWhere ) )
                    return;
                generate( );
            }
        }
        private void numQuery_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            listCount = e.List;
        }
        SelectAll.JiaoMiDuJunHengAll query = new SelectAll.JiaoMiDuJunHengAll( );
        protected override void select ( )
        {
            base.select( );

            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.JiaoMiDuJunHengAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );
            if ( model.JZ001 != null )
                autoQuery( );
            else
                MessageBox.Show( "您没有选择任何内容" );
        }
        void autoQuery ( )
        {
            Ergodic.FormEverySpliEnableFalse( this );
            textBox7.Enabled = false;

            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;

            sign = "2";
            queryContent( );
        }
        void queryContent ( )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND JZ001='" + model.JZ001 + "'";
            button4_Click( null ,null );
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            model.JZ001 = e.ConOne;
            if ( e.ConTwo == "执行" )
                label45.Visible = true;
            else
                label45.Visible = false;
        }
        #endregion

        #region Table
        void generate ( )
        { 
            generateQuery = bll.GetDataTableGenerate( strWhere );
            if ( generateQuery != null && generateQuery.Rows.Count > 0 )
            {
                string str = "";
                for ( int i = 0 ; i < generateQuery.Rows.Count ; i++ )
                {
                    model.JZ002 = generateQuery.Rows[i]["JM101"].ToString( );
                    model.JZ003 = generateQuery.Rows[i]["JM100"].ToString( );
                    model.JZ004 = generateQuery.Rows[i]["JM90"].ToString( );
                    model.JZ005 = generateQuery.Rows[i]["JM102"].ToString( );
                    str = generateQuery.Rows[i]["JM94"].ToString( );
                    model.JZ007 = string.IsNullOrEmpty( str ) == true ? 0 : Convert.ToDecimal( str );
                    str = generateQuery.Rows[i]["JM95"].ToString( );
                    model.JZ008 = string.IsNullOrEmpty( str ) == true ? 0 : Convert.ToDecimal( str );
                    str = generateQuery.Rows[i]["JM96"].ToString( );
                    model.JZ009 = string.IsNullOrEmpty( str ) == true ? 0 : Convert.ToDecimal( str );
                    str = generateQuery.Rows[i]["JM10"].ToString( );
                    model.JZ012 = string.IsNullOrEmpty( str ) == true ? 0 : Convert.ToDecimal( str );
                    str = generateQuery.Rows[i]["JM07"].ToString( );
                    if ( string.IsNullOrEmpty( str ) )
                        model.JZ015 = null;
                    else
                        model.JZ015 = Convert.ToDateTime( str );
                    str = generateQuery.Rows[i]["JM16"].ToString( );
                    if ( string.IsNullOrEmpty( str ) )
                        model.JZ016 = null;
                    else
                        model.JZ016 = Convert.ToDateTime( str );
                    model.JZ018 = generateQuery.Rows[i]["JM108"].ToString( );
                    var sumOfNumber = generateQuery.AsEnumerable( ).Where( p => p.Field<decimal>( "JM94" ) == model.JZ007 && p.Field<decimal>( "JM95" ) == model.JZ008 && p.Field<decimal>( "JM96" ) == model.JZ009 && p.Field<decimal>( "JM10" ) == model.JZ012 && p.Field<string>( "JM108" ) == model.JZ018 ).Sum( t => t.Field<long>( "JM103" ) );
                    model.JZ006 = string.IsNullOrEmpty( sumOfNumber.ToString( ) ) == true ? 0 : Convert.ToInt64( sumOfNumber );
                    var sumOfStock = generateQuery.AsEnumerable( ).Where( p => p.Field<decimal>( "JM94" ) == model.JZ007 && p.Field<decimal>( "JM95" ) == model.JZ008 && p.Field<decimal>( "JM96" ) == model.JZ009 && p.Field<decimal>( "JM10" ) == model.JZ012 && p.Field<string>( "JM108" ) == model.JZ018 ).Sum( t => t.Field<decimal>( "JM15" ) );
                    var sumOfOut = generateQuery.AsEnumerable( ).Where( p => p.Field<decimal>( "JM94" ) == model.JZ007 && p.Field<decimal>( "JM95" ) == model.JZ008 && p.Field<decimal>( "JM96" ) == model.JZ009 && p.Field<decimal>( "JM10" ) == model.JZ012 && p.Field<string>( "JM108" ) == model.JZ018 ).Sum( t => t.Field<decimal>( "JM104" ) );
                    model.JZ010 = string.IsNullOrEmpty( sumOfStock.ToString( ) ) == true ? ( string.IsNullOrEmpty( sumOfOut.ToString( ) ) == true ? 0 : Convert.ToInt64( sumOfOut ) ) : Convert.ToInt64( sumOfStock ) + Convert.ToInt64( sumOfOut );
                    result = bll.ExistsYesOrNo( model );
                    if ( result == true )
                    {
                        result = bll.UpdateGener( model );
                        if ( result == false )
                        {
                            MessageBox.Show( "生成失败" );
                            break;
                        }
                        else if ( i == generateQuery.Rows.Count - 1 )
                        {
                            MessageBox.Show( "生成成功" );
                            strWhere = "1=1";
                            strWhere = strWhere + " AND JZ001='" + model.JZ001 + "'";
                            button4_Click( null ,null );
                        }
                    }
                    else
                    {
                        result = bll.InsertGener( model );
                        if ( result == false )
                        {
                            MessageBox.Show( "生成失败" );
                            break;
                        }
                        else if ( i == generateQuery.Rows.Count - 1 )
                        {
                            MessageBox.Show( "生成成功" );
                            strWhere = "1=1";
                            strWhere = strWhere + " AND JZ001='" + model.JZ001 + "'";
                            button4_Click( null ,null );
                        }
                    }
                }
            }
        }
        void seriable ( )
        {
            model.JZ011 = string.IsNullOrEmpty( textBox3.Text ) == true ? 0 : Convert.ToInt32( textBox3.Text );
            model.JZ013 = string.IsNullOrEmpty( textBox5.Text ) == true ? 0 : Convert.ToInt32( textBox5.Text );
            model.JZ014 = string.IsNullOrEmpty( textBox6.Text ) == true ? 0 : Convert.ToInt32( textBox6.Text );
            model.JZ017 = dateTimePicker1.Value;
            model.JZ019 = model.JZ019 + model.JZ011;
        }
        //generatetion
        private void button5_Click ( object sender ,EventArgs e )
        {
            strWhere = "''";
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                strWhere = strWhere + "," + "'" + gridView1.GetDataRow( i )["JZ004"].ToString( ) + "'";
            }
            if ( string.IsNullOrEmpty( strWhere ) )
                return;
            generate( );
        }
        //edit
        private void button2_Click ( object sender ,EventArgs e )
        {
            seriable( );
            result = bll.Update( model );
            if ( result == true )
            {
                MessageBox.Show( "编辑成功" );
                strWhere = "1=1";
                strWhere = strWhere + " AND JZ001='" + model.JZ001 + "'";
                button4_Click( null ,null );
            }
            else
                MessageBox.Show( "编辑失败" );
        }
        //delete
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==
DialogResult . Cancel )
                return;
            result = bll.Delete( model.IDX );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                tableQuery.Rows.RemoveAt( gridView1.FocusedRowHandle );
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        //refresh
        private void button4_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( strWhere ) )
                strWhere = "1=1";
            tableQuery = bll.GetDataTableTable( strWhere );
            gridControl1.DataSource = tableQuery;
        }
        #endregion

        #region Main
        protected override void add ( )
        {
            base.add( );

            Ergodic.FormEvery( this );
            Ergodic.FormEverySpliEnableTrue( this );
            gridControl1.DataSource = null;
            textBox7.Enabled = false;

            sign = "1";
            model.JZ001 = oddNumbers.purchaseContract( "SELECT MAX(AJ017) AJ017 FROM R_PQAJ" ,"AJ017" ,"R_047-" );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        void dele ( )
        {
            result = bll.DeleteAll( model.JZ001 );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;
                Ergodic.FormEverySpliEnableFalse( this );

                toolSelect.Enabled = toolAdd.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;

                label45.Visible = label46.Visible = false;
                sign = "";
                weihu = "";
                textBox7.Enabled = false;
            }
            else
                MessageBox.Show( "数据删除失败" );
        }
        protected override void delete ( )
        {
            base.delete( );

            if ( label45.Visible == true )
            {
                if ( Logins.number == "MLL-0001" )
                    dele( );
                else
                    MessageBox.Show( "此单状态为执行,需要总经理处理" );
            }
            else
            {
                dele( );
            }
        }
        protected override void update ( )
        {
            base.update( );

            if ( label45.Visible == true )
                MessageBox.Show( "此单状态为执行,请维护" );
            else
            {
                Ergodic.FormEverySpliEnableTrue( this );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
                textBox7.Enabled = false;
            }
        }
        void variable ( )
        {
            model.JZ020 = textBox7.Text;
        }
        void updateSave ( )
        {
            result = bll.UpdateMain( model );
            if ( result == true )
            {
                MessageBox.Show( "录入数据成功" );
                saveState( );
            }
            else
                MessageBox.Show( "录入数据失败" );
        }
        void saveState ( )
        {
            Ergodic.FormEverySpliEnableFalse( this );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
            sign = "";
            weihu = "";
            label46.Visible = false;
            textBox7.Enabled = false;
        }
        protected override void save ( )
        {
            base.save( );

            variable( );

            DataTable da = bll.GetDataTableExists( model.JZ001 );
            if ( weihu == "1" )
            {
                if ( string.IsNullOrEmpty( textBox7.Text ) )
                {
                    MessageBox.Show( "维护意见不可为空" );
                    return;
                }
                if ( da.Rows.Count > 0 )
                {
                    model.JZ021 = da.Rows[0]["JZ021"].ToString( ) + "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";
                    updateSave( );
                }
            }
            else
            {
                if ( da.Rows.Count > 0 )
                {
                    model.JZ021 = "";
                    updateSave( );
                }
                else
                    saveState( );
            }
        }
        protected override void cancel ( )
        {
            base.cancel( );

            if ( sign == "1" && weihu != "1" )
            {
                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;
                Ergodic.FormEverySpliEnableFalse( this );

                toolSelect.Enabled = toolAdd.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolPrint.Enabled = toolExport.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;

                label45.Visible = false;
                label46.Visible = false;
                sign = weihu = "";
                try
                {
                    bll.DeleteAll( model.JZ001 );
                }
                catch { }
            }
            else
            {
                Ergodic.FormEverySpliEnableFalse( this );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
                sign = weihu = "";
            }
            textBox7.Enabled = false;
        }
        protected override void revirw ( )
        {
            base.revirw( );

            Reviews( "JZ001" ,model.JZ001 ,"R_PQJZ" ,this ,"" ,"R_047" ,false ,false,MulaolaoBll . Drity . GetDt ( )/*,"" ,"" ,"" ,"" ,"" ,"" ,"","R_195"*/ );
            result = sp.reviewImple( "R_195" ,model.JZ001 );
            if ( result == true )
                label45.Visible = true;
            else
                label45.Visible = false;
        }
        protected override void print ( )
        {
            base.print( );
        }
        protected override void export ( )
        {
            base.export( );
        }
        protected override void maintain ( )
        {
            base.maintain( );

            if ( label45.Visible == true )
            {
                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolCancel.Enabled = toolSave.Enabled = true;

                Ergodic.FormEverySpliEnableTrue( this );
                textBox7.Enabled = true;
                weihu = "1";
            }
            else
                MessageBox.Show( "此单状态为非执行,请更改或删除" );
        }
        protected override void copys ( )
        {
            base.copys( );
        }
        #endregion
            
        #region Event
        private void textBox3_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox4_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox4 );
        }
        private void textBox4_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox4 );
        }
        private void textBox4_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox4.Text != "" && !DateDayRegise.fiveTwoNum( textBox4 ) )
            {
                textBox4.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多两位,如999.99,请重新输入" );
            }
        }
        private void textBox5_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox6_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                model.IDX = string.IsNullOrEmpty( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                assignMent( );
            }
        }
        void assignMent ( )
        {
            model = bll.GetModel( model.IDX );
            textBox1.Text = model.JZ004;
            textBox2.Text = model.JZ003;
            textBox3.Text = model.JZ011.ToString( );
            textBox4.Text = model.JZ012.ToString( );
            textBox5.Text = model.JZ013.ToString( );
            textBox6.Text = model.JZ014.ToString( );
            if (  model.JZ017!=null )
                dateTimePicker1.Value = Convert.ToDateTime( model.JZ017 );
        }
        private void gridView1_CellMerge ( object sender ,DevExpress.XtraGrid.Views.Grid.CellMergeEventArgs e )
        {
            int rowOne = e.RowHandle1;
            int rowTwo = e.RowHandle2;
            string valueOne = gridView1.GetDataRow( rowOne )["JZ007"].ToString( );
            string valueTwo = gridView1.GetDataRow( rowTwo )["JZ007"].ToString( );
            string valueTre = gridView1.GetDataRow( rowOne )["JZ008"].ToString( );
            string valueFor = gridView1.GetDataRow( rowTwo )["JZ008"].ToString( );
            string valueSix = gridView1.GetDataRow( rowOne )["JZ009"].ToString( );
            string valueSev = gridView1.GetDataRow( rowTwo )["JZ009"].ToString( );
            if ( valueOne + valueTre + valueSix != valueTwo + valueFor + valueSev )
            {
                e.Handled = true;
            }
        }
        #endregion
    }
}
