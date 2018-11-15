using Mulaolao.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Mulaolao.Summary
{
    public partial class SailsPaymentTaxRefundAndElectricityBill : FormChild
    {
        public SailsPaymentTaxRefundAndElectricityBill ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.SailsPaymentTaxRefundAndElectricityBillLibrary _model = new MulaolaoLibrary.SailsPaymentTaxRefundAndElectricityBillLibrary( );
        MulaolaoBll.Bll.SailsPaymentTaxRefundAndElectricityBillBll _bll = new MulaolaoBll.Bll.SailsPaymentTaxRefundAndElectricityBillBll( );
        
        List<SplitContainer> spList = new List<SplitContainer>( );
        bool result = false;
        DataTable tableQuery,tableSum;DataRow row;
        int dateYear = 0, dateDay = 0;
        string term = "", strWhere = "", sign = "", weihu = "";


        private void SailsPaymentTaxRefundAndElectricityBill_Load ( object sender ,EventArgs e )
        {
            Power( this );
            spList.Clear( );
            spList.AddRange( new SplitContainer[] { splitContainer1 } );
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableFalse( spList );
            gridControl1.DataSource = null;
            textBox1.Enabled = false;
            label45.Visible = false;

            comboBox1.Items.Clear( );
            comboBox1.Items.AddRange( new string[] { "" ,"订单R-250表额" ,"开票.实交金额" ,"收齐(申报)" } );
        }

        #region Main
        protected override void add ( )
        {
            base.add( );

            gridControl1.DataSource = null;
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableTrue( spList );
            sign = "1";
            textBox1.Enabled = false;
            label45.Visible = false;
            _model.NZ001 = oddNumbers.purchaseContract( "SELECT MAX(NZ001) NZ001 FROM R_PQNZ" ,"NZ001" ,"R_500-" );

            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void save ( )
        {
            base.save( );

            _model.NZ021 = textBox1.Text;
            
            DataTable daExists = _bll.GetDataTableExists( _model.NZ001 );
            if ( weihu == "1" )
            {
                if ( daExists != null && daExists.Rows.Count > 0 )
                {
                    if ( string.IsNullOrEmpty( textBox1.Text ) )
                    {
                        MessageBox.Show( "维护意见不可为空" );
                        return;
                    }
                    _model.NZ020 = daExists.Rows[0]["NZ020"].ToString( ) + "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";
                    result = _bll.Insert( _model );
                    if ( result == true )
                    {
                        MessageBox.Show( "成功保存数据" );
                        saveState( );
                    }
                    else
                        MessageBox.Show( "保存数据失败" );
                }
            }
            else
                saveState( );
        }
        void saveState ( )
        {
            Ergodic.SpliEnableFalse( spList );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = false;
            label45.Visible = false;
            sign = "";
            weihu = "";
            textBox1.Enabled = false;
        }
        protected override void delete ( )
        {
            base.delete( );

            if ( label45.Visible == true )
            {
                if ( Logins.number == "MLL-0001" )
                    dele( );
                else
                    MessageBox.Show( "此单已执行,需要总经理删除" );
            }
            else
                dele( );
        }
        void dele ( )
        {
            result = _bll.Delete( _model.NZ001 );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = false;

                gridControl1.DataSource = null;
                Ergodic.SpliClear( spList );
                Ergodic.SpliEnableFalse( spList );
                sign = weihu = "";
                label45.Visible = false;
                textBox1.Enabled = false;
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        protected override void update ( )
        {
            base.update( );

            if ( label45.Visible == true )
                MessageBox.Show( "此单意见执行,请维护" );
            else
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;

                Ergodic.SpliEnableTrue( spList );
                textBox1.Enabled = false;
                label45.Visible =  false;
            }
        }
        protected override void revirw ( )
        {
            base.revirw( );

            Reviews( "NZ001" ,_model.NZ001 ,"R_PQNZ" ,this ,"" ,"R_500" ,false ,false,MulaolaoBll . Drity . GetDt ( )/*,"" ,"" ,"" ,"" ,"" ,"" ,"","R_195"*/ );
            SpecialPowers sp = new SpecialPowers( );
            result = sp.reviewImple( "R_500" ,_model.NZ001 );
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
        protected override void cancel ( )
        {
            base.cancel( );

            if ( sign == "1" && weihu != "1" )
            {
                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = false;
                sign = "";
                weihu = "";
                textBox13.Enabled = false;
                label45.Visible = false;
                Ergodic.SpliClear( spList );

                _bll.Delete( _model.NZ001 );
            }
            else
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled = toolcopy.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
            }
            Ergodic.SpliEnableFalse( spList );
            textBox10.Enabled = false;
        }
        protected override void maintain ( )
        {
            base.maintain( );

            if ( label45.Visible == true )
            {
                Ergodic.SpliEnableTrue( spList );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
                textBox1.Enabled = true;
                weihu = "1";
            }
            else
                MessageBox.Show( "此单据状态为非执行,请更改" );
        }
        protected override void copys ( )
        {
            base.copys( );
        }
        #endregion

        #region Event
        private void textBox2_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.intgra( e );
        }
        private void textBox5_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.intgra( e );
        }
        private void textBox6_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.intgra( e );
        }
        private void textBox7_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox7 );
        }
        private void textBox7_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox7 );
        }
        private void textBox7_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox7.Text != "" && !DateDayRegise.elevenTwoNumber( textBox7 ) )
            {
                textBox7.Text = "";
                MessageBox.Show( "只允许输入整数部分最多九位,小数部分最多两位,如999999999.99,请重新输入" );
            }
        }
        private void textBox8_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise . fractionTb( e ,textBox8 );
        }
        private void textBox8_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox8 );
        }
        private void textBox8_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox8.Text != "" && !DateDayRegise. elevenTwoNumber ( textBox8 ) )
            {
                textBox8.Text = "";
                MessageBox.Show( "只允许输入整数部分最多九位,小数部分最多两位,如999999999.99,请重新输入" );
            }
        }
        private void textBox9_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.fractionTb( e ,textBox9 );
        }
        private void textBox9_TextChanged ( object sender ,EventArgs e )
        {
            DateDay.textChangeTb( textBox9 );
        }
        private void textBox9_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox9.Text != "" && !DateDayRegise.foreThreeNum( textBox9 ) )
            {
                textBox9.Text = "";
                MessageBox.Show( "只允许输入整数部分最多一位,小数部分最多三位,如9.999,请重新输入" );
            }
        }
        private void comboBox1_TextChanged ( object sender ,EventArgs e )
        {
            if ( comboBox1.Text == "订单R-250表额" )
            {
                textBox9.ReadOnly = false;
                button5.Enabled = true;
            }
            else if ( comboBox1.Text == "开票.实交金额" )
            {
                textBox9.ReadOnly = true;
                button5.Enabled = true;
            }
            else
            {
                textBox9.ReadOnly = true;
                button5.Enabled = false;
                textBox2.Text = textBox5.Text = textBox6.Text = "";
            }
        }
        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                _model.IDX = string.IsNullOrEmpty( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                if ( _model.IDX > 0 )
                    assIgn( );
            }
        }
        void assIgn ( )
        {
            _model = _bll.GetModel( _model.IDX );
            if ( _model.NZ002 != 0 && _model.NZ003 != 0 )
                dateTimePicker1.Value = Convert.ToDateTime( _model.NZ002 + "年" + _model.NZ003 + "月" );
            comboBox1.Text = _model.NZ004;
            textBox2.Text = _model.NZ005.ToString( );
            textBox5.Text = _model.NZ008.ToString( );
            textBox6.Text = _model.NZ009.ToString( );
            textBox7.Text = _model.NZ010.ToString( );
            textBox8.Text = _model.NZ011.ToString( );
            textBox9.Text = _model.NZ012.ToString( );
            textBox10.Text = _model.NZ013.ToString( );
            textBox11.Text = _model.NZ014.ToString( );
            textBox12.Text = _model.NZ015.ToString( );
            textBox13.Text = _model.NZ016.ToString( );
            textBox14.Text = _model.NZ017.ToString( );
            textBox15.Text = _model.NZ018.ToString( );
            textBox16.Text = _model.NZ019.ToString( );
            dateYear = _model.NZ002;
            dateDay = _model.NZ003;
            term = _model.NZ004;
        }
        #endregion

        #region Table
        void variable ( )
        {
            _model.NZ002 = Convert.ToInt32( dateTimePicker1.Value.ToString( "yyyy" ) );
            _model.NZ003 = Convert.ToInt32( dateTimePicker1.Value.ToString( "MM" ) );
            _model.NZ004 = comboBox1.Text;
            _model.NZ005 = string.IsNullOrEmpty( textBox2.Text ) == true ? 0 : Convert.ToInt32( textBox2.Text );
            _model.NZ008 = string.IsNullOrEmpty( textBox5.Text ) == true ? 0 : Convert.ToInt32( textBox5.Text );
            _model.NZ009 = string.IsNullOrEmpty( textBox6.Text ) == true ? 0 : Convert.ToInt32( textBox6.Text );
            _model.NZ010 = string.IsNullOrEmpty( textBox7.Text ) == true ? 0M : Convert.ToDecimal( textBox7.Text );
            _model.NZ011 = string.IsNullOrEmpty( textBox8.Text ) == true ? 0M : Convert.ToDecimal( textBox8.Text );
            _model.NZ012 = string.IsNullOrEmpty( textBox9.Text ) == true ? 0M : Convert.ToDecimal( textBox9.Text );
            _model.NZ013 = string.IsNullOrEmpty( textBox10.Text ) == true ? 0 : Convert.ToInt32( textBox10.Text );
            _model.NZ014 = string.IsNullOrEmpty( textBox11.Text ) == true ? 0 : Convert.ToInt32( textBox11.Text );
            _model.NZ015 = string.IsNullOrEmpty( textBox12.Text ) == true ? 0 : Convert.ToInt32( textBox12.Text );
            _model.NZ016 = string.IsNullOrEmpty( textBox13.Text ) == true ? 0 : Convert.ToInt32( textBox13.Text );
            _model.NZ017 = string.IsNullOrEmpty( textBox14.Text ) == true ? 0 : Convert.ToInt32( textBox14.Text );
            _model.NZ018 = string.IsNullOrEmpty( textBox15.Text ) == true ? 0M : Convert.ToDecimal( textBox15.Text );
            _model.NZ019 = string.IsNullOrEmpty( textBox16.Text ) == true ? 0 : Convert.ToInt32( textBox16.Text );
        }
        void rowEdit ( )
        {
            row["NZ002"] = _model.NZ002;
            row["NZ003"] = _model.NZ003;
            row["NZ004"] = _model.NZ004;
            row["NZ005"] = _model.NZ005;
            row["NZ008"] = _model.NZ008;
            row["NZ009"] = _model.NZ009;
            row["NZ010"] = _model.NZ010;
            row["NZ011"] = _model.NZ011;
            row["NZ012"] = _model.NZ012;
            row["NZ013"] = _model.NZ013;
            row["NZ014"] = _model.NZ014;
            row["NZ015"] = _model.NZ015;
            row["NZ016"] = _model.NZ016;
            row["NZ017"] = _model.NZ017;
            row["NZ018"] = _model.NZ018;
            row["NZ019"] = _model.NZ019;
        }
        //Build
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
            {
                MessageBox.Show( "项不可为空" );
                return;
            }
            variable( );
            result = _bll.Exists( _model.NZ002 ,_model.NZ003 ,_model.NZ004 );
            if ( result == true )
            {
                MessageBox.Show( "已经存在" + _model.NZ002 + "年" + _model.NZ003 + "月,项:" + _model.NZ004 + "的记录" );
                return;
            }
            _model.IDX = _bll.Add( _model );
            if ( _model.IDX > 0 )
            {
                MessageBox.Show( "成功录入数据" );
                if ( tableQuery == null )
                    refre( );
                else
                {
                    row = tableQuery.NewRow( );
                    row["idx"] = _model.IDX;
                    rowEdit( );
                    tableQuery.Rows.Add( row );
                }
            }
            else
                MessageBox.Show( "录入数据失败" );
        }
        //Edit
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
            {
                MessageBox.Show( "项不可为空" );
                return;
            }
            variable( );
            if ( dateYear == _model.NZ002 && dateDay == _model.NZ003 && term == _model.NZ004 )
                edit( );
            else
            {
                result = _bll.Exists( _model.NZ002 ,_model.NZ003 ,_model.NZ004 );
                if ( result == true )
                {
                    MessageBox.Show( "已经存在" + _model.NZ002 + "年" + _model.NZ003 + "月,项:" + _model.NZ004 + "的记录" );
                    return;
                }
                else
                    edit( );
            }
        }
        void edit ( )
        {
            result = _bll.Update( _model );
            if ( result == true )
            {
                MessageBox.Show( "成功编辑数据" );
                row = tableQuery.Rows[gridView1.FocusedRowHandle];
                row.BeginEdit( );
                rowEdit( );
                row.EndEdit( );
            }
            else
                MessageBox.Show( "编辑数据失败" );
        }
        //Delete
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==
   DialogResult . Cancel )
                return;

            result = _bll.Delete( _model.IDX );
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
            refre( );
        }
        void refre ( )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND NZ001='" + _model.NZ001 + "'";
            tableQuery = _bll.GetDataTable( strWhere );
            gridControl1.DataSource = tableQuery;
            assignMent( );
        }
        decimal nz8 = 0M, nz5 = 0m, nz9 = 0m, nz10 = 0M, nz11 = 0M, nz12 = 0M, nz13 = 0M, nz14 = 0M, nz15 = 0M, nz17 = 0M, nz18 = 0M,nz19=0M,
                sumNz5 = 0M, sumNz05 = 0M, sumNz005 = 0M, sumNz8 = 0M, sumNz08 = 0M, sumNz008 = 0M, sumNz9 = 0M, sumNz09 = 0M, sunU0 = 0M, sunU00 = 0M, sumU1 = 0M, sumU01 = 0M, sumU3 = 0M, sumU03 = 0M, sumU4 = 0M, sumU04 = 0M, sumU004 = 0M, sumU05 = 0M, sumU005 = 0m, sumU6 = 0M, sumU06 = 0M, sumU006 = 0M, sumU7 = 0M, sumU07 = 0M, sumU007 = 0M, sumU9 = 0M, sumU09 = 0M, sumU10 = 0M, sumU010 = 0M, sumU12 = 0M, sumU012 = 0M, sumU0012 = 0M, sumU14 = 0M, sumU014 = 0M, sumU15 = 0M, sumU015 = 0M, sumU16 = 0M, sumU016 = 0M;
        void assignMent ( )
        {
            if ( tableQuery != null )
            {
                nz8 = nz5 = nz9 = nz10 = nz11 = nz12 = nz13 = nz14 = nz15 = nz17 = nz18 = sumNz5 = sumNz05 = sumNz005 = sumNz8 = sumNz08 = sumNz008 = sumNz9 = sumNz09 = sunU0 = sunU00 = sumU1 = sumU01 = sumU3 = sumU4 = sumU04 = sumU004 = sumU05 = sumU005 = sumU6 = sumU06 = sumU006 = sumU7 = sumU07 = sumU007 = sumU9 = sumU09 = sumU10 = sumU010 = sumU12 = sumU012 = sumU0012 = sumU14 = sumU014 = sumU15 = sumU015 = sumU16 = sumU016 = 0M;
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    obtainValue( i );
                    giveValue( i );
                }
                summaryNZ005( );
                summaryNZ008( );
                summaryNZ009( );
                summaryUO( );
                summaryU1( );
                summaryNZ010( );
                summaryNZ011( );
                summaryNZ012( );
                summaryU2( );
                summaryU3( );
                summaryNZ013( );
                summaryU4( );
                summaryU5( );
                summaryU6( );
                summaryNZ014( );
                summaryNZ015( );
                summaryNZ016( );
                summaryU7( );
                summaryU8( );
                summaryNZ017( );
                summaryU9( );
                summaryU10( );
                summaryU11( );
                summaryU12( );
                summaryU13( );
                summaryNZ018( );
                summaryU14( );
                summaryU15( );
                summaryU16( );
            }
        }
        void obtainValue ( int i )
        {
            if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["NZ008"].ToString( ) ) )
                nz8 = 0;
            else
                nz8 = Convert.ToDecimal( gridView1.GetDataRow( i )["NZ008"].ToString( ) );
            if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["NZ005"].ToString( ) ) )
                nz5 = 0;
            else
                nz5 = Convert.ToDecimal( gridView1.GetDataRow( i )["NZ005"].ToString( ) );
            if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["NZ009"].ToString( ) ) )
                nz9 = 0;
            else
                nz9 = Convert.ToDecimal( gridView1.GetDataRow( i )["NZ009"].ToString( ) );
            if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["NZ010"].ToString( ) ) )
                nz10 = 0;
            else
                nz10 = Convert.ToDecimal( gridView1.GetDataRow( i )["NZ010"].ToString( ) );
            if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["NZ011"].ToString( ) ) )
                nz11 = 0;
            else
                nz11 = Convert.ToDecimal( gridView1.GetDataRow( i )["NZ011"].ToString( ) );
            if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["NZ012"].ToString( ) ) )
                nz12 = 0;
            else
                nz12 = Convert.ToDecimal( gridView1.GetDataRow( i )["NZ012"].ToString( ) );
            if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["NZ013"].ToString( ) ) )
                nz13 = 0;
            else
                nz13 = Convert.ToDecimal( gridView1.GetDataRow( i )["NZ013"].ToString( ) );
            if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["NZ014"].ToString( ) ) )
                nz14 = 0;
            else
                nz14 = Convert.ToDecimal( gridView1.GetDataRow( i )["NZ014"].ToString( ) );
            if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["NZ015"].ToString( ) ) )
                nz15 = 0;
            else
                nz15 = Convert.ToDecimal( gridView1.GetDataRow( i )["NZ015"].ToString( ) );
            if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["NZ017"].ToString( ) ) )
                nz17 = 0;
            else
                nz17 = Convert.ToDecimal( gridView1.GetDataRow( i )["NZ017"].ToString( ) );
            if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["NZ018"].ToString( ) ) )
                nz18 = 0;
            else
                nz18 = Convert.ToDecimal( gridView1.GetDataRow( i )["NZ018"].ToString( ) );
            if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["NZ019"].ToString( ) ) )
                nz19 = 0;
            else
                nz19 = Convert.ToDecimal( gridView1.GetDataRow( i )["NZ019"].ToString( ) );
        }
        void giveValue ( int i )
        {
            if ( gridView1.GetDataRow( i )["NZ004"].ToString( ) == "订单R-250表额" )
            {
                gridView1.SetRowCellValue( i ,gridView1.Columns["NZ009"] ,nz8 / Convert.ToDecimal( 1.17 ) );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U0"] ,nz5 + nz8 / Convert.ToDecimal( 1.17 ) );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U2"] ,nz17 == 0 ? 0 : nz13 / nz17 );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U3"] ,nz8 / Convert.ToDecimal( 1.17 ) * nz10 );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U8"] ,( nz8 / Convert.ToDecimal( 1.17 ) * nz10 + nz5 * ( nz10 - nz11 ) - nz13 + nz14 - nz15 ) / Convert.ToDecimal( 0.17 ) );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U9"] ,nz12 * ( nz5 + nz8 / Convert.ToDecimal( 1.17 ) ) );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U10"] ,nz17 - nz12 * ( nz5 + nz8 / Convert.ToDecimal( 1.17 ) ) );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U11"] ,nz5 + nz8 / Convert.ToDecimal( 1.17 ) == 0 ? 0 : nz17 / ( nz5 + nz8 / Convert.ToDecimal( 1.17 ) ) );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U16"] ,nz17 + ( nz5 + nz8 / Convert.ToDecimal( 1.17 ) ) * nz18 );
                sumNz5 += nz5;
                sumNz8 += nz8;
                sumNz9 += Math.Round( nz8 / Convert.ToDecimal( 1.17 ) ,0 );
                sunU0 += Math.Round( nz5 + nz8 / Convert.ToDecimal( 1.17 ) ,0 );
                sumU1 += nz5 + nz8;
                sumU3 += Math.Round( nz8 / Convert.ToDecimal( 1.17 ) * nz10 ,0 );
                sumU4 += Math.Round( nz5 * ( nz10 - nz11 ) ,0 );
                sumU6 += Math.Round( sumU3 + sumU4 - nz13 ,0 );
                sumU7 += Math.Round( sumU6 + nz14 - nz15 ,0 );
                sumU9 += Math.Round( ( sumNz5 + sumNz9 ) * nz12 );
                sumU10 += Math.Round( nz17 - sumU9 );
                sumU12 += Math.Round( nz5 * nz11 + nz15 - nz14 );
                sumU14 += Math.Round( sunU0 * nz18 );
                sumU15 += Math.Round( sumU14 - nz19 );
                sumU16 += Math.Round( nz17 + sumU14 );
            }
            if ( gridView1.GetDataRow( i )["NZ004"].ToString( ) == "收齐(申报)" )
            {
                gridView1.SetRowCellValue( i ,gridView1.Columns["NZ009"] ,0 );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U0"] ,gridView1.GetDataRow( i )["NZ005"].ToString( ) );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U1"] ,0 );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U2"] ,0 );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U3"] ,string.IsNullOrEmpty( gridView1.GetDataRow( i - 1 )["U3"].ToString( ) ) == true ? 0 : Convert.ToInt32( gridView1.GetDataRow( i - 1 )["U3"].ToString( ) ) );
                gridView1.SetRowCellValue( i ,gridView1.Columns["NZ012"] ,0 );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U8"] ,0 );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U9"] ,0 );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U10"] ,0 );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U11"] ,0 );
                gridView1.SetRowCellValue( i ,gridView1.Columns["NZ018"] ,0 );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U14"] ,0 );
                gridView1.SetRowCellValue( i ,gridView1.Columns["NZ019"] ,0 );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U15"] ,0 );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U16"] ,0 );
                sumNz005 += nz5;
                sumNz008 += nz8;
                sumU004 += nz5 * ( nz10 - nz11 );
                sumU005 += Math.Round( nz5 * nz11 ,0 );
                sumU006 += Math.Round( ( string.IsNullOrEmpty( gridView1.GetDataRow( i - 1 )["U3"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i - 1 )["U3"].ToString( ) ) ) + sumU004 - nz13 );
                sumU007 += Math.Round( sumU006 + nz14 - nz15 ,0 );
                sumU0012 += Math.Round( nz5 * nz11 + nz15 - nz14 );
            }
            if ( gridView1.GetDataRow( i )["NZ004"].ToString( ) == "开票.实交金额" )
            {
                gridView1 . SetRowCellValue ( i ,gridView1 . Columns [ "NZ009" ] ,nz8 / Convert . ToDecimal ( 1.17 ) );
                gridView1 .SetRowCellValue( i ,gridView1.Columns["U0"] ,nz5 + nz9 );
                gridView1.SetRowCellValue( i ,gridView1.Columns["NZ012"] ,( nz5 + nz9 * Convert.ToDecimal( 1.17 ) ) == 0 ? 0 : nz17 / ( nz5 + nz9 * Convert.ToDecimal( 1.17 ) ) );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U2"] ,nz17 == 0 ? 0 : nz13 / nz17 );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U3"] ,nz9 * nz10 );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U8"] ,( nz9 * nz10 + nz5 * ( nz10 - nz11 ) - nz13 + nz14 - nz15 ) / Convert.ToDecimal( 0.17 ) );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U9"] ,( nz5 + nz9 ) * Convert.ToDecimal( 0.7 ) );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U10"] ,nz17 - ( nz5 + nz9 ) * Convert.ToDecimal( 0.7 ) );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U11"] ,( nz5 + nz9 ) == 0 ? 0 : nz17 / ( nz5 + nz9 ) );
                gridView1.SetRowCellValue( i ,gridView1.Columns["U16"] ,nz17 + ( nz5 + nz8 / Convert.ToDecimal( 1.17 ) ) * nz18 );
                sumNz05 += nz5;
                sumNz08 += Math.Round( nz9 * Convert.ToDecimal( 1.17 ) ,0 );
                sumNz09 += nz9;
                sunU00 += nz5 + nz9;
                sumU01 += Math.Round( nz5 + nz9 * Convert.ToDecimal( 1.17 ) );
                sumU03 += nz9 * nz10;
                sumU04 += nz5 * ( nz10 - nz11 );
                sumU05 += Math.Round( nz5 * nz11 ,0 );
                sumU06 += Math.Round( sumU03 + sumU04 - nz13 );
                sumU07 += Math.Round( sumU06 + nz14 - nz15 ,0 );
                sumU09 += Math.Round( ( sumNz05 + sumNz09 ) * nz12 );
                sumU010 += Math.Round( nz17 - sumU09 );
                sumU012 += Math.Round( nz5 * nz11 + nz15 - nz14 );
                sumU014 += Math.Round( sunU00 * nz18 );
                sumU015 += Math.Round( sumU04 - nz19 );
                sumU016 += Math.Round( nz17 + sumU014 );
            }
        }
        void summaryNZ005 ( )
        {
            NZ005.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumNz5.ToString( ) );
            NZ005.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumNz5.ToString( ) );
            NZ005.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumNz05.ToString( ) );
            NZ005.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumNz05.ToString( ) );
            NZ005.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumNz005.ToString( ) );
            NZ005.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumNz005.ToString( ) );
            NZ005.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ005.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ005.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( sumNz5 - sumNz05 ).ToString( ) );
        }
        void summaryNZ008 ( )
        {
            NZ008.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumNz8.ToString( ) );
            NZ008.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumNz8.ToString( ) );
            NZ008.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumNz08.ToString( ) );
            NZ008.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumNz08.ToString( ) );
            NZ008.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumNz008.ToString( ) );
            NZ008.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumNz008.ToString( ) );
            NZ008.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ008.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ008.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( sumNz8 - sumNz08 ).ToString( ) );
        }
        void summaryNZ009 ( )
        {
            NZ009.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumNz9.ToString( ) );
            NZ009.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumNz8 / Convert.ToDecimal( 1.17 ) ,0 ).ToString( ) );
            NZ009.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumNz09.ToString( ) );
            NZ009.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumNz09.ToString( ) );
            NZ009.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumNz09.ToString( ) );
            NZ009.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumNz09.ToString( ) );
            NZ009.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ009.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ009.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
        }
        void summaryUO ( )
        {
            U0.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sunU0.ToString( ) );
            U0.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumNz5 + sumNz8 / Convert.ToDecimal( 1.17 ) ,0 ).ToString( ) );
            U0.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sunU00.ToString( ) );
            U0.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( sumNz05 + sumNz09 ).ToString( ) );
            U0.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( sumNz05 + sumNz09 ).ToString( ) );
            U0.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( sumNz05 + sumNz09 ).ToString( ) );
            U0.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U0.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U0.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
        }
        void summaryU1 ( )
        {
            U1.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU1.ToString( ) );
            U1.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( sumNz5 + sumNz8 ).ToString( ) );
            U1.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU01.ToString( ) );
            U1.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( sumNz05 + sumNz08 ).ToString( ) );
            U1.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U1.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U1.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( sumU1 - sumNz5 - sumNz8 ).ToString( ) );
            U1.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( sumU01 - sumNz05 - sumNz08 ).ToString( ) );
            U1.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( sumNz5 + sumNz8 - sumNz05 - sumNz08 ).ToString( ) );
        }
        void summaryNZ010 ( )
        {
            NZ010.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,nz10.ToString( ) );
            NZ010.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,nz10.ToString( ) );
            NZ010.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,nz10.ToString( ) );
            NZ010.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,nz10.ToString( ) );
            NZ010.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,nz10.ToString( ) );
            NZ010.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,nz10.ToString( ) );
            NZ010.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ010.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ010.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
        }
        void summaryNZ011 ( )
        {
            NZ011.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,nz11.ToString( ) );
            NZ011.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,nz11.ToString( ) );
            NZ011.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,nz11.ToString( ) );
            NZ011.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,nz11.ToString( ) );
            NZ011.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,nz11.ToString( ) );
            NZ011.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,nz11.ToString( ) );
            NZ011.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ011.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ011.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
        }
        void summaryNZ012 ( )
        {
            NZ012.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,nz12.ToString( ) );
            NZ012.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,nz12.ToString( ) );
            NZ012.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ012.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ012.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ012.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ012.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ012.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ012.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
        }
        void summaryU2 ( )
        {
            if ( Convert.ToDecimal( NZ017.Summary[0].SummaryValue ) == 0 )
            {
                U2.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
                U2.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
                U2.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
                U2.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
                U2.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
                U2.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            }
            else
            {
                U2.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( NZ013.Summary[0].SummaryValue ) / Convert.ToDecimal( NZ017.Summary[0].SummaryValue ) * 100 ,2 ).ToString( ) + "%" );
                U2.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( NZ013.Summary[0].SummaryValue ) / Convert.ToDecimal( NZ017.Summary[0].SummaryValue ) * 100 ,2 ).ToString( ) + "%" );
                U2.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( NZ013.Summary[0].SummaryValue ) / Convert.ToDecimal( NZ017.Summary[0].SummaryValue ) * 100 ,2 ).ToString( ) + "%" );
                U2.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( NZ013.Summary[0].SummaryValue ) / Convert.ToDecimal( NZ017.Summary[0].SummaryValue ) * 100 ,2 ).ToString( ) + "%" );
                U2.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( NZ013.Summary[0].SummaryValue ) / Convert.ToDecimal( NZ017.Summary[0].SummaryValue ) * 100 ,2 ).ToString( ) + "%" );
                U2.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( NZ013.Summary[0].SummaryValue ) / Convert.ToDecimal( NZ017.Summary[0].SummaryValue ) * 100 ,2 ).ToString( ) + "%" );
            }
            U2.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U2.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U2.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
        }
        void summaryU3 ( )
        {
            U3.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU3.ToString( ) );
            //nz009*nz010
            U3.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( sumNz8 / Convert.ToDecimal( 1.17 ) ) * nz10 ,0 ).ToString( ) );
            U3.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU03.ToString( ) );
            U3.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumNz09 * nz10 ,0 ).ToString( ) );
            U3.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumNz09 * nz10 ,0 ).ToString( ) );
            U3.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumNz09 * nz10 ,0 ).ToString( ) );
            U3.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U3.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumU03 - sumNz09 * nz10 ,0 ).ToString( ) );
            U3.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( sumNz8 / Convert.ToDecimal( 1.17 ) ) * nz10 - sumNz09 * nz10 ,0 ).ToString( ) );
        }
        void summaryNZ013 ( )
        {
            NZ013.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ013.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ013.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
        }
        void summaryU4 ( )
        {
            U4.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU4.ToString( ) );
            //[NZ005] * ([NZ010] - [NZ011])
            U4.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumNz5 * ( nz10 - nz11 ) ,0 ).ToString( ) );
            U4.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU04.ToString( ) );
            U4.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumNz05 * ( nz10 - nz11 ) ,0 ).ToString( ) );
            U4.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU004.ToString( ) );
            U4.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumNz005 * ( nz10 - nz11 ) ,0 ).ToString( ) );
            U4.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumU4 - sumNz5 * ( nz10 - nz11 ) ,0 ).ToString( ) );
            U4.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumU04 - sumNz05 * ( nz10 - nz11 ) ,0 ).ToString( ) );
            U4.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( sumNz5 - sumNz05 ) * ( nz10 - nz11 ) ,0 ).ToString( ) );
        }
        void summaryU5 ( )
        {
            //[NZ005] * [NZ011]
            U5.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumNz5 * nz11 ,0 ).ToString( ) );
            U5.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumNz5 * nz11 ,0 ).ToString( ) );
            U5.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU05.ToString( ) );
            U5.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumNz05 * nz11 ,0 ).ToString( ) );
            U5.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU005.ToString( ) );
            U5.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumNz005 * nz11 ,0 ).ToString( ) );
            U5.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U5.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumU05 - sumNz05 * nz11 ,0 ).ToString( ) );
            U5.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( sumNz5 - sumNz05 ) * nz11 ,0 ).ToString( ) );
        }
        void summaryU6 ( )
        {
            //[NZ005] * [NZ011]
            U6.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU6.ToString( ) );
            U6.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumU3 + sumU4 - Convert.ToDecimal( gridView1.Columns["NZ013"].Summary[0].SummaryValue ) ,0 ).ToString( ) );
            U6.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU06.ToString( ) );
            U6.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumU03 + sumU04 - Convert.ToDecimal( gridView1.Columns["NZ013"].Summary[0].SummaryValue ) ).ToString( ) );
            U6.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU006.ToString( ) );
            U6.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumU03 + sumU004 - Convert.ToDecimal( gridView1.Columns["NZ013"].Summary[0].SummaryValue ) ,0 ).ToString( ) );
            U6.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U6.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( gridView1.Columns["U6"].Summary[2].SummaryValue ) - Convert.ToDecimal( gridView1.Columns["U6"].Summary[3].SummaryValue ) ,0 ).ToString( ) );
            U6.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( gridView1.Columns["U6"].Summary[1].SummaryValue ) - Convert.ToDecimal( gridView1.Columns["U6"].Summary[3].SummaryValue ) ,0 ).ToString( ) );
        }
        void summaryNZ014 ( )
        {
            NZ014.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ014.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ014.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
        }
        void summaryNZ015 ( )
        {
            NZ015.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ015.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ015.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
        }
        void summaryNZ016 ( )
        {
            NZ016.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ016.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ016.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
        }
        void summaryU7 ( )
        {
            U7.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU7.ToString( ) );
            U7.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( sumU3 + sumU4 - Convert.ToDecimal( gridView1.Columns["NZ013"].Summary[0].SummaryValue ) ) + Convert.ToDecimal( NZ014.Summary[1].SummaryValue ) - Convert.ToDecimal( NZ015.Summary[1].SummaryValue ) ,0 ).ToString( ) );
            U7.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU07.ToString( ) );
            U7.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( sumU03 + sumU04 - Convert.ToDecimal( gridView1.Columns["NZ013"].Summary[0].SummaryValue ) ) + Convert.ToDecimal( NZ014.Summary[3].SummaryValue ) - Convert.ToDecimal( NZ015.Summary[3].SummaryValue ) ,0 ).ToString( ) );
            U7.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU007.ToString( ) );
            U7.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( sumU03 + sumU004 - Convert.ToDecimal( gridView1.Columns["NZ013"].Summary[0].SummaryValue ) ) + Convert.ToDecimal( NZ014.Summary[5].SummaryValue ) - Convert.ToDecimal( NZ015.Summary[5].SummaryValue ) ,0 ).ToString( ) );
            U7.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( sumU7 -  Convert.ToDecimal( sumU3 + sumU4 - Convert.ToDecimal( gridView1.Columns["NZ013"].Summary[0].SummaryValue ) ) - Convert.ToDecimal( NZ014.Summary[1].SummaryValue ) + Convert.ToDecimal( NZ015.Summary[1].SummaryValue ) ).ToString( ) );
            U7.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( sumU07 - Convert.ToDecimal( sumU03 + sumU04 - Convert.ToDecimal( gridView1.Columns["NZ013"].Summary[0].SummaryValue ) ) - Convert.ToDecimal( NZ014.Summary[3].SummaryValue ) + Convert.ToDecimal( NZ015.Summary[3].SummaryValue ) ).ToString( ) );
            U7.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,( Convert.ToDecimal( sumU3 + sumU4 - Convert.ToDecimal( gridView1.Columns["NZ013"].Summary[0].SummaryValue ) ) + Convert.ToDecimal( NZ014.Summary[1].SummaryValue ) - Convert.ToDecimal( NZ015.Summary[1].SummaryValue ) - Convert.ToDecimal( sumU03 + sumU04 - Convert.ToDecimal( gridView1.Columns["NZ013"].Summary[0].SummaryValue ) ) - Convert.ToDecimal( NZ014.Summary[3].SummaryValue ) + Convert.ToDecimal( NZ015.Summary[3].SummaryValue ) ).ToString( ) );
        }
        void summaryU8 ( )
        {
            U8.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( sumU7 / Convert.ToDecimal( 0.17 ) ) ,0 ).ToString( ) );
            U8.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( Convert.ToDecimal( sumU3 + sumU4 - Convert.ToDecimal( gridView1.Columns["NZ013"].Summary[0].SummaryValue ) ) + Convert.ToDecimal( NZ014.Summary[1].SummaryValue ) - Convert.ToDecimal( NZ015.Summary[1].SummaryValue ) ) / Convert.ToDecimal( 0.17 ) ,0 ).ToString( ) );
            U8.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumU07 / Convert.ToDecimal( 0.17 ) ).ToString( ) );
            U8.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( Convert.ToDecimal( sumU03 + sumU04 - Convert.ToDecimal( gridView1.Columns["NZ013"].Summary[0].SummaryValue ) ) + Convert.ToDecimal( NZ014.Summary[3].SummaryValue ) - Convert.ToDecimal( NZ015.Summary[3].SummaryValue ) ) / Convert.ToDecimal( 0.17 ) ,0 ).ToString( ) );
            U8.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U8.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U8.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( sumU7 - Convert.ToDecimal( sumU3 + sumU4 - Convert.ToDecimal( gridView1.Columns["NZ013"].Summary[0].SummaryValue ) ) - Convert.ToDecimal( NZ014.Summary[1].SummaryValue ) + Convert.ToDecimal( NZ015.Summary[1].SummaryValue ) ) / Convert.ToDecimal( 0.17 ) ,0 ).ToString( ) );
            U8.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( sumU07 - Convert.ToDecimal( sumU03 + sumU04 - Convert.ToDecimal( gridView1.Columns["NZ013"].Summary[0].SummaryValue ) ) - Convert.ToDecimal( NZ014.Summary[3].SummaryValue ) + Convert.ToDecimal( NZ015.Summary[3].SummaryValue ) ) / Convert.ToDecimal( 0.17 ) ,0 ).ToString( ) );
            U8.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( Convert.ToDecimal( sumU3 + sumU4 - Convert.ToDecimal( gridView1.Columns["NZ013"].Summary[0].SummaryValue ) ) + Convert.ToDecimal( NZ014.Summary[1].SummaryValue ) - Convert.ToDecimal( NZ015.Summary[1].SummaryValue ) - Convert.ToDecimal( sumU03 + sumU04 - Convert.ToDecimal( gridView1.Columns["NZ013"].Summary[0].SummaryValue ) ) - Convert.ToDecimal( NZ014.Summary[3].SummaryValue ) + Convert.ToDecimal( NZ015.Summary[3].SummaryValue ) ) / Convert.ToDecimal( 0.17 ) ,0 ).ToString( ) );
        }
        void summaryNZ017 ( )
        {
            NZ017.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ017.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ017.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
        }
        void summaryU9 ( )
        {
            U9.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU9.ToString( ) );
            U9.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumNz5 + sumNz8 / Convert.ToDecimal( 1.17 ) * nz12 ,0 ).ToString( ) );
            U9.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU09.ToString( ) );
            U9.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( sumNz05 + sumNz09 ) * Convert.ToDecimal( 0.7 ) ,0 ).ToString( ) );
            U9.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U9.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U9.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U9.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U9.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
        }
        void summaryU10 ( )
        {
            U10.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU10.ToString( ) );
            U10.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( NZ017.Summary[1].SummaryValue ) - ( sumNz5 + sumNz8 / Convert.ToDecimal( 1.17 ) * nz12 ) ,0 ).ToString( ) );
            U10.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU010.ToString( ) );
            U10.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal(NZ017.Summary[3].SummaryValue)-( ( sumNz05 + sumNz09 ) * Convert.ToDecimal( 0.7 ) ) ,0 ).ToString( ) );
            U10.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U10.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U10.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U10.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U10.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
        }
        void summaryU11 ( )
        {
            if ( sumNz5 + sumNz8 == 0 )
            {
                U11.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
                U11.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            }
            else
            {
                U11.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( NZ017.Summary[1].SummaryValue ) / ( sumNz5 + sumNz8 / Convert.ToDecimal( 1.17 ) ) ,0 ).ToString( ) );
                U11.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( NZ017.Summary[1].SummaryValue ) / ( sumNz5 + sumNz8 / Convert.ToDecimal( 1.17 ) ) ,0 ).ToString( ) );
            }
            if ( sumNz05 + sumNz09 == 0 )
            {
                U11.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
                U11.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            }
            else
            {
                U11.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( NZ017.Summary[1].SummaryValue ) / ( sumNz05 + sumNz09 ) ,0 ).ToString( ) );
                U11.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( NZ017.Summary[1].SummaryValue ) / ( sumNz05 + sumNz09 ) ,0 ).ToString( ) );
            }
            U11.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U11.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U11.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U11.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U11.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
        }
        void summaryU12 ( )
        {
            U12.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU12.ToString( ) );
            U12.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumNz5 * nz11 * +Convert.ToDecimal( NZ015.Summary[1].SummaryValue ) - Convert.ToDecimal( NZ014.Summary[1].SummaryValue ) ,0 ).ToString( ) );
            U12.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU012.ToString( ) );
            U12.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumNz05 * nz11 + Convert.ToDecimal( NZ015.Summary[3].SummaryValue ) - Convert.ToDecimal( NZ014.Summary[1].SummaryValue ) ,0 ).ToString( ) );
            U12.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU0012.ToString( ) );
            U12.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumNz005 * nz11 + Convert.ToDecimal( NZ015.Summary[5].SummaryValue ) - Convert.ToDecimal( NZ014.Summary[5].SummaryValue ) ,0 ).ToString( ) );
            U12.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U12.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U12.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
        }
        void summaryU13 ( )
        {
            if ( sumNz5 + sumNz8 == 0 )
            {
                U13.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
                U13.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            }
            else
            {
                U13.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( sumNz5 * nz11 +Convert.ToDecimal( NZ015.Summary[1].SummaryValue ) - Convert.ToDecimal( NZ014.Summary[1].SummaryValue ) ) / ( sumNz5 + sumNz8 / Convert.ToDecimal( 1.17 ) ) * 100 ,1 ).ToString( ) + "%" );
                U13.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( sumNz5 * nz11 +Convert.ToDecimal( NZ015.Summary[1].SummaryValue ) - Convert.ToDecimal( NZ014.Summary[1].SummaryValue ) ) / ( sumNz5 + sumNz8 / Convert.ToDecimal( 1.17 ) ) * 100 ,1 ).ToString( ) + "%" );
            }
            if ( sumNz05 + sumNz09 ==0)
            {
                U13.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
                U13.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
                U13.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
                U13.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            }
            else
            {
                U13.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( sumNz05 * nz11 + Convert.ToDecimal( NZ015.Summary[3].SummaryValue ) - Convert.ToDecimal( NZ014.Summary[1].SummaryValue ) ) / ( sumNz05 + sumNz09 ) * 100 ,1 ).ToString( ) + "%" );
                U13.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( sumNz05 * nz11 + Convert.ToDecimal( NZ015.Summary[3].SummaryValue ) - Convert.ToDecimal( NZ014.Summary[1].SummaryValue ) ) / ( sumNz05 + sumNz09 ) * 100 ,1 ).ToString( ) + "%" );
                U13.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( sumNz005 * nz11 + Convert.ToDecimal( NZ015.Summary[5].SummaryValue ) - Convert.ToDecimal( NZ014.Summary[5].SummaryValue ) ) / ( sumNz05 + sumNz09 ) * 100 ,1 ).ToString( ) + "%" );
                U13.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( sumNz005 * nz11 + Convert.ToDecimal( NZ015.Summary[5].SummaryValue ) - Convert.ToDecimal( NZ014.Summary[5].SummaryValue ) ) / ( sumNz05 + sumNz09 ) * 100 ,1 ).ToString( ) + "%" );
            }
            if ( sumNz5 + sumNz8 / Convert.ToDecimal( 1.17 ) - sumNz05 - sumNz09 ==0)
            {
                U13.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
                U13.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
                U13.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            }
            else
            {
                U13.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( sumNz5 * nz11  +Convert.ToDecimal( NZ015.Summary[1].SummaryValue ) - Convert.ToDecimal( NZ014.Summary[1].SummaryValue ) ) / ( sumNz5 + sumNz8 / Convert.ToDecimal( 1.17 ) - sumNz05 - sumNz09 ) ,1 ).ToString( ) + "%" );
                U13.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( sumNz5 * nz11  +Convert.ToDecimal( NZ015.Summary[1].SummaryValue ) - Convert.ToDecimal( NZ014.Summary[1].SummaryValue ) ) / ( sumNz5 + sumNz8 / Convert.ToDecimal( 1.17 ) - sumNz05 - sumNz09 ) ,1 ).ToString( ) + "%" );
                U13.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( sumNz5 * nz11  +Convert.ToDecimal( NZ015.Summary[1].SummaryValue ) - Convert.ToDecimal( NZ014.Summary[1].SummaryValue ) ) / ( sumNz5 + sumNz8 / Convert.ToDecimal( 1.17 ) - sumNz05 - sumNz09 ) ,1 ).ToString( ) + "%" );
            }
        }
        void summaryNZ018 ( )
        {
            NZ018.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Convert.ToDecimal( gridView1.GetDataRow( 0 )["NZ018"].ToString( ) ).ToString( ) );
            NZ018.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Convert.ToDecimal( gridView1.GetDataRow( 0 )["NZ018"].ToString( ) ).ToString( ) );
            NZ018.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Convert.ToDecimal( gridView1.GetDataRow( 0 )["NZ018"].ToString( ) ).ToString( ) );
            NZ018.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Convert.ToDecimal( gridView1.GetDataRow( 0 )["NZ018"].ToString( ) ).ToString( ) );
            NZ018.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ018.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ018.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ018.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ018.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
        }
        void summaryU14 ( )
        {
            U14.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU14.ToString( ) );
            U14.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( (sumNz5 + sumNz8 / Convert.ToDecimal( 1.17 )) * Convert.ToDecimal( gridView1.GetDataRow( 0 )["NZ018"].ToString( ) ) ,0 ).ToString( ) );
            U14.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU014.ToString( ) );
            U14.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( sumNz05 + sumNz09 ) * Convert.ToDecimal( gridView1.GetDataRow( 0 )["NZ018"].ToString( ) ) ,0 ).ToString( ) );
            U14.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U14.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U14.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumU14 - ( sumNz5 + sumNz8 / Convert.ToDecimal( 1.17 ) ) * Convert.ToDecimal( gridView1.GetDataRow( 0 )["NZ018"].ToString( ) ) ,0 ).ToString( ) );
            U14.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumU014 - ( sumNz05 + sumNz09 ) * Convert.ToDecimal( gridView1.GetDataRow( 0 )["NZ018"].ToString( ) ) ,0 ).ToString( ) );
            U14.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( sumNz5 + sumNz8 / Convert.ToDecimal( 1.17 ) ) * Convert.ToDecimal( gridView1.GetDataRow( 0 )["NZ018"].ToString( ) ) - ( sumNz05 + sumNz09 ) * Convert.ToDecimal( gridView1.GetDataRow( 0 )["NZ018"].ToString( ) ) ,0 ).ToString( ) );
        }
        void summaryNZ019 ( )
        {
            NZ019.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ019.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ019.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ019.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            NZ019.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
        }
        void summaryU15 ( )
        {
            U15.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU15.ToString( ) );
            U15.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( sumNz5 + sumNz8 / Convert.ToDecimal( 1.17 ) ) * Convert.ToDecimal( gridView1.GetDataRow( 0 )["NZ018"].ToString( ) ) - Convert.ToDecimal( NZ019.Summary[1].SummaryValue ) ,0 ).ToString( ) );
            U15.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU015.ToString( ) );
            U15.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( sumNz05 + sumNz09 ) * Convert.ToDecimal( gridView1.GetDataRow( 0 )["NZ018"].ToString( ) ) - Convert.ToDecimal( NZ019.Summary[3].SummaryValue ) ,0 ).ToString( ) );
            U15.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U15.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U15.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U15.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( sumU015 - ( sumNz05 + sumNz09 ) * Convert.ToDecimal( gridView1.GetDataRow( 0 )["NZ018"].ToString( ) ) + Convert.ToDecimal( NZ019.Summary[3].SummaryValue ) ,0 ).ToString( ) );
            U15.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( sumNz5 + sumNz8 / Convert.ToDecimal( 1.17 ) ) * Convert.ToDecimal( gridView1.GetDataRow( 0 )["NZ018"].ToString( ) ) - Convert.ToDecimal( NZ019.Summary[1].SummaryValue ) - ( sumNz05 + sumNz09 ) * Convert.ToDecimal( gridView1.GetDataRow( 0 )["NZ018"].ToString( ) ) + Convert.ToDecimal( NZ019.Summary[3].SummaryValue ) ,0 ).ToString( ) );
        }
        void summaryU16 ( )
        {
            U16.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU16.ToString( ) );
            U16.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( NZ017.Summary[1].SummaryValue ) + ( sumNz5 + sumNz8 / Convert.ToDecimal( 1.17 ) ) * Convert.ToDecimal( gridView1.GetDataRow( 0 )["NZ018"].ToString( ) ) ,0 ).ToString( ) );
            U16.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,sumU016.ToString( ) );
            U16.Summary[3].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( Convert.ToDecimal( NZ017.Summary[3].SummaryValue ) + ( sumNz05 + sumNz09 ) * Convert.ToDecimal( gridView1.GetDataRow( 0 )["NZ018"].ToString( ) ) ,0 ).ToString( ) );
            U16.Summary[4].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U16.Summary[5].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U16.Summary[6].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U16.Summary[7].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
            U16.Summary[8].SetSummary( DevExpress.Data.SummaryItemType.Custom ,0.ToString( ) );
        }
        //Read
        private void button5_Click ( object sender ,EventArgs e )
        {
            _model.NZ002 = dateTimePicker1.Value.Year;
            _model.NZ003 = dateTimePicker1.Value.Month;
            
            result = _bll.Exists( _model.NZ002 );
            if ( result == true )
                _model.NZ001 = _bll.GetDataTableOfOddNum( _model.NZ002 ).Rows[0]["NZ001"].ToString( );
            result = _bll.AddOf( _model );
            if ( result == true )
            {
                MessageBox.Show( "生成成功" );
                refre( );
            }
            else
                MessageBox.Show( "生成失败" );
        }
        #endregion

        #region Query
        protected override void select ( )
        {
            base.select( );

            _model = new MulaolaoLibrary.SailsPaymentTaxRefundAndElectricityBillLibrary( );
            SelectAll.SailsPaymentTaxRefundAndElectricityBillAll query = new SelectAll.SailsPaymentTaxRefundAndElectricityBillAll( );
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.SailsPaymentTaxRefundAndElectricityBillAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );

            if ( _model.NZ001 != null && _model.NZ001 != "" )
            {
                _model = _bll.GetModel( _model.NZ001 );
                if ( _model != null )
                {
                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
                    toolSave.Enabled = toolCancel.Enabled = false;
                    Ergodic.SpliEnableFalse( spList );
                    sign = "2";
                    textBox1.Enabled = false;
                    textBox1.Text = _model.NZ021;
                    refre( );                  
                }
            }
            else
                MessageBox.Show( "您没有选择任何内容" );
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            _model.NZ001 = e.ConOne;
            if ( e.ConTwo == "执行" )
                label45.Visible = true;
            else
                label45.Visible = false;
        }
        #endregion
    }
}
