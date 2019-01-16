using Mulaolao.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Mulaolao.Summary
{
    public partial class R_FrmDailyCollectionRecord : FormChild
    {
        public R_FrmDailyCollectionRecord ( )
        {
            InitializeComponent( );
            
            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GridViewMoHuSelect . SetFilter ( bandedGridView2 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { bandedGridView1 ,bandedGridView2 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.DailyCollectionRecordLibrary model = new MulaolaoLibrary.DailyCollectionRecordLibrary( );
        MulaolaoBll.Bll.DailyCollectionRecordBll bll = new MulaolaoBll.Bll.DailyCollectionRecordBll( );
        SelectAll.SailesQueryAll query = new SelectAll.SailesQueryAll( );
        SelectAll.DailyCollectionRecordAll daQuery = new SelectAll.DailyCollectionRecordAll( );
        string sign = "", strWhere = "1=1";
        bool result = false;
        DataTable queryTable, queryTableTwo;
        List<string> listQuery = new List<string>( );
        
        private void R_FrmDailyCollectionRecord_Load ( object sender ,EventArgs e )
        {
            Power ( this );
            Ergodic . FormEvery ( this );
            gridControl1 . DataSource = null;
            Ergodic . FormEverySpliEnableFalse ( this );
            label107 . Visible = false;

            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GridViewMoHuSelect . SetFilter ( bandedGridView2 );
            foreach ( DevExpress . XtraGrid . Columns . GridColumn column in bandedGridView1 . Columns )
            {
                column . OptionsFilter . FilterPopupMode = DevExpress . XtraGrid . Columns . FilterPopupMode . CheckedList;
            }
            foreach ( DevExpress . XtraGrid . Columns . GridColumn column in bandedGridView2 . Columns )
            {
                column . OptionsFilter . FilterPopupMode = DevExpress . XtraGrid . Columns . FilterPopupMode . CheckedList;
            }
        }

        #region Event
        private void textBox11_TextChanged ( object sender ,EventArgs e )
        {
            textBox13.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox11 ,textBox5 ) ) ,2 ).ToString( );
            textBox16.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox11 ,textBox14 ) ) ,2 ).ToString( );
            textBox28.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox11 ,textBox27 ) ) ,2 ).ToString( );
            textBox17.Text = Math.Round( Convert.ToDecimal( Operation.MultiForTbCbes( textBox34.Text ,textBox11.Text ,textBox35.Text ,textBox9.Text ) ) ,2 ).ToString( );
        }
        private void textBox5_TextChanged ( object sender ,EventArgs e )
        {
            textBox13.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox11 ,textBox5 ) ) ,2 ).ToString( );
            textBox29 . Text = Convert . ToDecimal ( Operation . MultiTwoTb ( textBox9 ,textBox5 ) ) . ToString ( "0.######" );
        }
        private void textBox14_TextChanged ( object sender ,EventArgs e )
        {
            textBox16.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox11 ,textBox14 ) ) ,2 ).ToString( );
        }
        private void textBox16_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox16 );
        }
        private void textBox16_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox16 );
        }
        private void textBox16_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox16.Text != "" && !DateDayRegise.tenTwoNumber( textBox16 ) )
            {
                this.textBox16.Text = "";
                MessageBox.Show( "只允许输入整数部分最多八位,小数部分最多两位,如99999999.99,请重新输入" );
            }
        }
        private void textBox15_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox15 );
        }
        private void textBox15_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox15 );
        }
        private void textBox15_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox15.Text != "" && !DateDayRegise.tenTwoNumber( textBox15 ) )
            {
                this.textBox15.Text = "";
                MessageBox.Show( "只允许输入整数部分最多八位,小数部分最多两位,如99999999.99,请重新输入" );
            }
        }
        private void textBox18_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox18 );
        }
        private void textBox18_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox18 );
        }
        private void textBox18_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox18.Text != "" && !DateDayRegise.tenTwoNumber( textBox18 ) )
            {
                this.textBox18.Text = "";
                MessageBox.Show( "只允许输入整数部分最多八位,小数部分最多两位,如99999999.99,请重新输入" );
            }
        }
        private void textBox20_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox20 );
        }
        private void textBox20_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox20 );
        }
        private void textBox20_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox20.Text != "" && !DateDayRegise.elevenForNumber( textBox20 ) )
            {
                this.textBox20.Text = "";
                MessageBox.Show( "只允许输入整数部分最多七位,小数部分最多四位,如99.999,请重新输入" );
            }
        }
        private void textBox22_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox22 );
        }
        private void textBox22_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox22 );
        }
        private void textBox22_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox22.Text != "" && !DateDayRegise.tenTwoNumber( textBox22 ) )
            {
                this.textBox22.Text = "";
                MessageBox.Show( "只允许输入整数部分最多八位,小数部分最多两位,如99999999.99,请重新输入" );
            }
        }
        private void textBox19_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox19 );
        }
        private void textBox19_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox19 );
        }
        private void textBox19_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox19.Text != "" && !DateDayRegise.tenTwoNumber( textBox19 ) )
            {
                this.textBox19.Text = "";
                MessageBox.Show( "只允许输入整数部分最多八位,小数部分最多两位,如99999999.99,请重新输入" );
            }
        }
        private void textBox23_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox23 );
        }
        private void textBox23_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox23 );
        }
        private void textBox23_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox23.Text != "" && !DateDayRegise.tenTwoNumber( textBox23 ) )
            {
                this.textBox23.Text = "";
                MessageBox.Show( "只允许输入整数部分最多八位,小数部分最多两位,如99999999.99,请重新输入" );
            }
        }
        private void textBox21_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox21 );
        }
        private void textBox21_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox21 );
        }
        private void textBox21_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox21.Text != "" && !DateDayRegise.tenTwoNumber( textBox21 ) )
            {
                this.textBox21.Text = "";
                MessageBox.Show( "只允许输入整数部分最多八位,小数部分最多两位,如99999999.99,请重新输入" );
            }
        }
        private void textBox24_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox24 );
        }
        private void textBox24_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox24 );
        }
        private void textBox24_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox24.Text != "" && !DateDayRegise.tenTwoNumber( textBox24 ) )
            {
                this.textBox24.Text = "";
                MessageBox.Show( "只允许输入整数部分最多八位,小数部分最多两位,如99999999.99,请重新输入" );
            }
        }
        private void textBox14_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox27_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox27_TextChanged ( object sender ,EventArgs e )
        {
            textBox28.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox11 ,textBox27 ) ) ,2 ).ToString( );
        }
        private void textBox35_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox35 );
        }
        private void textBox35_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox35 );
            textBox17.Text = Math.Round( Convert.ToDecimal( Operation.MultiForTbCbes( textBox34.Text ,textBox11.Text ,textBox35.Text ,textBox9.Text ) ) ,2 ).ToString( );
        }
        private void textBox35_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox35.Text != "" && !DateDayRegise.elevenForNumber( textBox35 ) )
            {
                this.textBox35.Text = "";
                MessageBox.Show( "只允许输入整数部分最多七位,小数部分最多四位,如9999999.9999,请重新输入" );
            }
        }
        private void textBox36_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox36 );
        }
        private void textBox36_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox36 );
        }
        private void textBox36_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox36.Text != "" && !DateDayRegise.elevenTwoNumber( textBox36 ) )
            {
                this.textBox36.Text = "";
                MessageBox.Show( "只允许输入整数部分最多九位,小数部分最多两位,如999999999.99,请重新输入" );
            }
        }
        private void textBox30_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise . fractionTb ( e ,textBox30 );
        }
        private void textBox30_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise . textChangeTb ( textBox30 );
        }
        private void textBox30_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox30 . Text != "" && !DateDayRegise . elevenTwoNumber ( textBox30 ) )
            {
                this . textBox30 . Text = "";
                MessageBox . Show ( "只允许输入整数部分最多九位,小数部分最多两位,如999999999.99,请重新输入" );
            }
        }
        private void textBox38_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise . fractionTb ( e ,textBox38 );
        }
        private void textBox38_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise . textChangeTb ( textBox38 );
        }
        private void textBox38_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox38 . Text != "" && !DateDayRegise . elevenTwoNumber ( textBox38 ) )
            {
                this . textBox38 . Text = "";
                MessageBox . Show ( "只允许输入整数部分最多九位,小数部分最多两位,如999999999.99,请重新输入" );
            }
        }
        private void textBox37_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox37 );
        }
        private void textBox37_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox37 );
        }
        private void textBox37_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox37.Text != "" && !DateDayRegise.elevenTwoNumber( textBox37 ) )
            {
                this.textBox37.Text = "";
                MessageBox.Show( "只允许输入整数部分最多九位,小数部分最多两位,如999999999.99,请重新输入" );
            }
        }
        string pqf01 = "";
        private void bandedGridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView1.FocusedRowHandle >= 0 && bandedGridView1.FocusedRowHandle <= bandedGridView1.DataRowCount - 1 )
            {
                if ( !string.IsNullOrEmpty( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) )
                    model.Idx = Convert.ToInt32( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                pqf01 = bandedGridView1.GetFocusedRowCellValue( "AE02" ).ToString( );
                seriablePqae( );
                if ( !string . IsNullOrEmpty ( bandedGridView1 . GetFocusedRowCellValue ( "AE32" ) . ToString ( ) ) )
                {
                    dateEdit5 . Text = bandedGridView1 . GetFocusedRowCellValue ( "AE32" ) . ToString ( );
                    //    textBox33.Text = dateEdit5.Value.ToString( "MM月dd日" );
                }
                else
                    dateEdit5 . Text = string . Empty;
                //    textBox33.Text = "";
                if ( !string . IsNullOrEmpty ( bandedGridView1 . GetFocusedRowCellValue ( "AE21" ) . ToString ( ) ) )
                {
                    dateEdit1 . Text = bandedGridView1 . GetFocusedRowCellValue ( "AE21" ) . ToString ( );
                    //    textBox29.Text = dateEdit1.Value.ToString( "MM月dd日" );
                }
                else
                    dateEdit1 . Text = String . Empty;
                //    textBox29.Text = "";
                if ( !string . IsNullOrEmpty ( bandedGridView1 . GetFocusedRowCellValue ( "AE22" ) . ToString ( ) ) )
                {
                    dateEdit3 . Text = bandedGridView1 . GetFocusedRowCellValue ( "AE22" ) . ToString ( );
                    //    textBox31.Text = dateEdit3.Value.ToString( "MM月dd日" );
                }
                else
                    dateEdit3 . Text = string . Empty;
                //    textBox31.Text = "";
                if ( !string . IsNullOrEmpty ( bandedGridView1 . GetFocusedRowCellValue ( "AE23" ) . ToString ( ) ) )
                {
                    dateEdit2 . Text = bandedGridView1 . GetFocusedRowCellValue ( "AE23" ) . ToString ( );
                    //    textBox30.Text = dateEdit2.Value.ToString( "MM月dd日" );
                }
                else
                    dateEdit2 . Text = String . Empty;
                //    textBox30.Text = "";
                if ( !string . IsNullOrEmpty ( bandedGridView1 . GetFocusedRowCellValue ( "AE24" ) . ToString ( ) ) )
                {
                    dateEdit4 . Text = bandedGridView1 . GetFocusedRowCellValue ( "AE24" ) . ToString ( );
                    //    textBox32.Text = dateEdit4.Value.ToString( "MM月dd日" );
                }
                else
                    dateEdit4 . Text = string . Empty;
                //    textBox32.Text = "";
            }
        }
        void seriablePqae ( )
        {
            model = bll.GetModel( model.Idx );
            if ( model == null )
                return;
            textBox4.Text = model.AE02;
            textBox1.Text = model.AE03;
            textBox3.Text = model.AE04;
            textBox2.Text = model.AE05;
            textBox5.Text = model.AE06.ToString( );
            textBox6.Text = model.AE07;
            textBox7.Text = model.AE08;
            textBox8.Text = model.AE09;
            textBox9.Text = model.AE10.ToString( );
            textBox10.Text = model.AE11.ToString( );
            textBox11.Text = model.AE12.ToString( );
            textBox12.Text = model.AE13;
            dateTimePicker1.Value = model.AE14;
            if ( !string.IsNullOrEmpty( model.AE15.ToString( ) ) )
                dateTimePicker2.Value = model.AE15;
            if ( !string.IsNullOrEmpty( model.AE16.ToString( ) ) )
                dateTimePicker3.Value = model.AE16;
            if ( !string.IsNullOrEmpty( model.AE17.ToString( ) ) )
                dateTimePicker4.Value = model.AE17;
            if ( !string.IsNullOrEmpty( model.AE18.ToString( ) ) )
                dateTimePicker5.Value = model.AE18;
            textBox13.Text = model.AE19.ToString( );
            textBox20.Text = model.AE20.ToString( );
            textBox16 . Text = ( model . AE37 * model . AE12 ) . ToString ( );
            textBox34 .Text = model.AE26.ToString( );
            textBox15.Text = model.AE27.ToString( );
            textBox22.Text = model.AE28.ToString( );
            textBox18.Text = model.AE29.ToString( );
            textBox19.Text = model.AE30.ToString( );
            textBox23.Text = model.AE31.ToString( );         
            textBox21.Text = model.AE33.ToString( );
            textBox24.Text = model.AE34.ToString( );
            textBox26.Text = model.AE35;
            textBox25.Text = model.AE36;
            textBox14.Text = model.AE37.ToString( );
            textBox27.Text = model.AE38.ToString( );
            textBox35.Text = model.AE39.ToString( );
            textBox36.Text = model.AE40.ToString( );
            textBox37.Text = model.AE41.ToString( );
            textBox38 . Text = model . AE42 . ToString ( );
            textBox30 . Text = model . AE43 . ToString ( "0.######" );
        }
        private void bandedGridView1_CustomColumnDisplayText ( object sender ,DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e )
        {
            //AE14.DisplayFormat.FormatString = "MM月dd日";
            //AE15.DisplayFormat.FormatString = "MM月dd日";
            //AE16.DisplayFormat.FormatString = "MM月dd日";
            //AE17.DisplayFormat.FormatString = "MM月dd日";
            //AE21.DisplayFormat.FormatString = "MM月dd日";
            //AE23.DisplayFormat.FormatString = "MM月dd日";
            //AE18.DisplayFormat.FormatString = "MM月dd日";
            //AE22.DisplayFormat.FormatString = "MM月dd日";
            //AE24.DisplayFormat.FormatString = "MM月dd日";
            //AE32.DisplayFormat.FormatString = "MM月dd日";
        }
        private void R_FrmDailyCollectionRecord_FormClosing ( object sender ,FormClosingEventArgs e )
        {
            if ( toolSave.Enabled == true )
            {
                cancel( );
            }
        }
        private void dateTimePicker6_ValueChanged ( object sender ,EventArgs e )
        {
            //textBox29.Text = dateEdit1.Value.ToString( "MM月dd日" );
        }
        private void dateTimePicker7_ValueChanged ( object sender ,EventArgs e )
        {
            
            //textBox30.Text = dateEdit2.Value.ToString( "MM月dd日" );
        }
        private void dateTimePicker8_ValueChanged ( object sender ,EventArgs e )
        {
            //textBox31.Text = dateEdit3.Value.ToString( "MM月dd日" );
        }
        private void dateTimePicker9_ValueChanged ( object sender ,EventArgs e )
        {
            //textBox32.Text = dateEdit4.Value.ToString( "MM月dd日" );
        }
        private void dateTimePicker10_ValueChanged ( object sender ,EventArgs e )
        {
            //textBox33.Text = dateEdit5.Value.ToString( "MM月dd日" );
        }
        private void dateTimePicker6_KeyPress ( object sender ,KeyPressEventArgs e )
        {
        }
        private void dateTimePicker7_KeyPress ( object sender ,KeyPressEventArgs e )
        {

        }
        private void dateTimePicker8_KeyPress ( object sender ,KeyPressEventArgs e )
        {

        }
        private void dateTimePicker9_KeyPress ( object sender ,KeyPressEventArgs e )
        {

        }
        private void dateTimePicker10_KeyPress ( object sender ,KeyPressEventArgs e )
        {
        }
        private void textBox29_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e.KeyChar == 8 )
            {
                textBox22.Text = "";
            }
            else
            {
                e.Handled = true;
            }
        }
        private void textBox31_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e.KeyChar == 8 )
            {
                textBox22.Text = "";
            }
            else
            {
                e.Handled = true;
            }
        }
        private void textBox32_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e.KeyChar == 8 )
            {
                textBox22.Text = "";
            }
            else
            {
                e.Handled = true;
            }
        }
        private void textBox33_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            if ( e.KeyChar == 8 )
            {
                textBox22.Text = "";
            }
            else
            {
                e.Handled = true;
            }
        }
        private void textBox34_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox34_TextChanged ( object sender ,EventArgs e )
        {
            textBox17.Text = Math.Round( Convert.ToDecimal( Operation.MultiForTbCbes( textBox34.Text ,textBox11.Text ,textBox35.Text ,textBox9.Text ) ) ,2 ).ToString( );
        }
        private void textBox9_TextChanged ( object sender ,EventArgs e )
        {
            textBox17.Text = Math.Round( Convert.ToDecimal( Operation.MultiForTbCbes( textBox34.Text ,textBox11.Text ,textBox35.Text ,textBox9.Text ) ) ,2 ).ToString( );
            textBox29 . Text = Convert . ToDecimal ( Operation . MultiTwoTb ( textBox9 ,textBox5 ) ) . ToString ( "0.######" );
        }
        private void bandedGridView1_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            //assignMents( );
            assignMent ( );
            //calcSum ( );
        }
        void assignMents ( )
        {
            if ( queryTable != null )
            {
                long sum = 0, count = 0;
                decimal countAe25 = 0, countAe25Sum = 0, countAe26 = 0, countAe28 = 0, countAe30 = 0, countAe29 = 0, countAe5 = 0, countAe6 = 0, countAe27 = 0, countAe06 = 0M, countAe19 = 0M;
                DataRow row;
                for ( int i = 0 ; i < bandedGridView1 . RowCount ; i++ )
                {
                    row = bandedGridView1 . GetDataRow ( i );
                    model . AE06 = string . IsNullOrEmpty ( row [ "AE06" ] . ToString ( ) ) == true ? 0 : Convert . ToInt64 ( row [ "AE06" ] . ToString ( ) );
                    model . AE10 = string . IsNullOrEmpty ( row [ "AE10" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE10" ] . ToString ( ) );
                    model . AE11 = string . IsNullOrEmpty ( row [ "AE11" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE11" ] . ToString ( ) );
                    model . AE12 = string . IsNullOrEmpty ( row [ "AE12" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE12" ] . ToString ( ) );
                    model . AE19 = string . IsNullOrEmpty ( row [ "AE19" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE19" ] . ToString ( ) );
                    model . AE26 = string . IsNullOrEmpty ( row [ "AE26" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "AE26" ] . ToString ( ) );
                    model . AE27 = string . IsNullOrEmpty ( row [ "AE27" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE27" ] . ToString ( ) );
                    model . AE28 = string . IsNullOrEmpty ( row [ "AE28" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE28" ] . ToString ( ) );
                    model . AE29 = string . IsNullOrEmpty ( row [ "AE29" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE29" ] . ToString ( ) );
                    model . AE30 = string . IsNullOrEmpty ( row [ "AE30" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE30" ] . ToString ( ) );
                    model . AE37 = string . IsNullOrEmpty ( row [ "AE37" ] . ToString ( ) ) == true ? 0 : Convert . ToInt64 ( row [ "AE37" ] . ToString ( ) );
                    
                    if ( !string . IsNullOrEmpty ( row [ "AE21" ] . ToString ( ) ) )
                        model . AE21 = Convert . ToDateTime ( row [ "AE21" ] . ToString ( ) );
                    else
                        model . AE21 = null;

                    if ( !string . IsNullOrEmpty ( row [ "AE22" ] . ToString ( ) ) )
                        model . AE22 = Convert . ToDateTime ( row [ "AE22" ] . ToString ( ) );
                    else
                        model . AE22 = null;

                    if ( !string . IsNullOrEmpty ( row [ "AE23" ] . ToString ( ) ) )
                        model . AE23 = Convert . ToDateTime ( row [ "AE23" ] . ToString ( ) );
                    else
                        model . AE23 = null;

                    countAe25Sum += model . AE37 * model . AE12;

                    countAe27 += model . AE27 + model . AE28 + model . AE30 + model . AE29 * model . AE11;
                    bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U11" ] ,model . AE19 - countAe27 );

                    if ( i == 0 )
                    {
                        count += model . AE06;
                        sum += model . AE37;
                        bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U0" ] ,model . AE06 - sum );

                        countAe26 += model . AE26 * model . AE12;
                        countAe25 += model . AE37 * model . AE12;
                        bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U7" ] ,countAe25 - countAe26 );

                        countAe5 += model . AE37 * model . AE12;

                        countAe28 += model . AE28;

                        countAe30 += model . AE30;

                        countAe29 += model . AE29 * model . AE11;

                        countAe6 += model . AE12 * model . AE26;

                        countAe06 += model . AE06 * model . AE10;

                        countAe19 += model . AE19;


                        if ( model . AE22 != null )
                            bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U12" ] ,countAe5 - countAe28 - countAe30 - countAe29 );
                        if ( model . AE23 != null )
                            bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U13" ] ,countAe6 - countAe28 - countAe30 - countAe29 );
                    }
                    else
                    {
                        if ( bandedGridView1 . GetDataRow ( i ) [ "AE02" ] . ToString ( ) == bandedGridView1 . GetDataRow ( i - 1 ) [ "AE02" ] . ToString ( ) )
                        {
                            sum += model . AE37;
                            bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U0" ] ,model . AE06 - sum );

                            countAe26 += Convert . ToDecimal ( model . AE26 * model . AE12 );
                            countAe25 += model . AE37 * model . AE12;
                            bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U7" ] ,countAe25 - countAe26 );

                            countAe5 += model . AE37 * model . AE12;

                            countAe28 += model . AE28;

                            countAe30 += model . AE30;

                            countAe29 += model . AE29 * model . AE11;

                            countAe6 += model . AE26 * model . AE12;

                            if ( model . AE22 != null )
                                bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U12" ] ,countAe5 - countAe28 - countAe30 - countAe29 );
                            if ( model . AE23 != null )
                                bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U13" ] ,countAe6 - countAe28 - countAe30 - countAe29 );
                        }
                        else
                        {
                            count += model . AE06;
                            sum = 0;
                            sum += model . AE37;
                            bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U0" ] ,model . AE06 - sum );

                            countAe26 = 0;
                            countAe26 += model . AE26 * model . AE12;
                            countAe25 = 0;

                            countAe25 += model . AE37 * model . AE12;
                            bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U7" ] ,countAe25 - countAe26 );

                            countAe5 = countAe28 = countAe30 = countAe29 = countAe6 = 0;

                            countAe5 += model . AE37 * model . AE12;

                            countAe28 += model . AE28;

                            countAe30 += model . AE30;

                            countAe29 += model . AE29 * model . AE11;

                            countAe6 += model . AE26 * model . AE12;

                            countAe06 += model . AE06 * model . AE10;

                            countAe19 += model . AE19;


                            if ( model . AE22 != null )
                                bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U12" ] ,countAe5 - countAe28 - countAe30 - countAe29 );
                            if ( model . AE23 != null )
                                bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U13" ] ,countAe6 - countAe28 - countAe30 - countAe29 );
                        }
                    }

                    if ( model . AE21 == null && model . AE23 == null )
                    {
                        bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U0" ] ,0 );
                        bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U7" ] ,0 );
                    }
                }

                AE06 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,count . ToString ( ) );
                U0 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,( count - Convert . ToInt64 ( AE37 . SummaryItem . SummaryValue ) ) . ToString ( ) );
                U7 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( countAe25Sum - Convert . ToDecimal ( U20 . SummaryItem . SummaryValue ) ,2 ) . ToString ( ) );

                U6 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( countAe06 ,2 ) . ToString ( ) );
                AE19 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,countAe19 . ToString ( ) );
                U11 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( countAe19 - Convert . ToDecimal ( U10 . SummaryItem . SummaryValue ) ,2 ) . ToString ( ) );

                decimal ae29Count = string . IsNullOrEmpty ( AE29 . SummaryItem . SummaryValue . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( AE29 . SummaryItem . SummaryValue );

                U23 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,( countAe06 - ae29Count ) . ToString ( ) );
            }
        }
        #endregion

        #region Main
        protected override void add ( )
        {
            base.add( );

            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;
            Ergodic.FormEverySpliEnableTrue( this );
            sign = "1";
            label107.Visible = false;
            model.AE01 = oddNumbers.purchaseContract( "SELECT MAX(AE01) AE01 FROM R_PQAE" ,"AE01" ,"R_250-" );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void delete ( )
        {
            base.delete( );

            if ( model.AE01 != null )
            {
                result = bll.GetReview( model ,this.Text );
                if ( result == false )
                {
                    string idList = "''";
                    for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                    {
                        idList = idList + "," + "'" + bandedGridView1.GetDataRow( i )["idx"].ToString( ) + "'";
                    }
                    result = bll.DeleteList( idList );
                    if ( result == true )
                    {
                        MessageBox.Show( "成功删除数据" );
                        Ergodic.FormEvery( this );
                        gridControl1.DataSource = null;
                        Ergodic.FormEverySpliEnableFalse( this );
                        toolAdd.Enabled = toolSelect.Enabled = true;
                        toolSave.Enabled = toolCancel.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolPrint.Enabled = toolReview.Enabled = toolExport.Enabled = toolMaintain.Enabled = false;
                        label107.Visible = false;
                    }
                    else
                        MessageBox.Show( "删除数据失败" );
                }
                else
                    MessageBox.Show( "此单据已执行,不能删除" );
            }
            result = false;
        }
        protected override void update ( )
        {
            base.update( );

            if ( model.AE01 != null )
            {
                result = bll.GetReview( model ,this.Text );
                if ( result == false )
                {
                    if ( bandedGridView1.RowCount > 0 )
                        model.AE01 = bandedGridView1.GetDataRow( 0 )["AE01"].ToString( );
                    Ergodic.FormEverySpliEnableTrue( this );
                    toolAdd.Enabled = toolSelect.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolPrint.Enabled = toolReview.Enabled = toolExport.Enabled = toolMaintain.Enabled = false;
                    toolSave.Enabled = toolCancel.Enabled = true;
                }
                else
                    MessageBox.Show( "此单据已执行,不能更改" );
                result = false;
            }
        }
        protected override void save ( )
        {
            base.save( );

            Ergodic.FormEverySpliEnableFalse( this );
            toolAdd.Enabled = toolSelect.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolPrint.Enabled = toolReview.Enabled = toolExport.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = toolMaintain.Enabled = false;
            sign = "";
        }
        protected override void cancel ( )
        {
            base.cancel( );

            if ( sign == "1" )
            {
                try
                {
                    string idxList = "''";
                    for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                    {
                        idxList = idxList + "," + "'" + bandedGridView1.GetDataRow( i )["idx"].ToString( ) + "'";
                    }

                    bll.DeleteList( idxList );
                }
                catch { }
                finally
                {
                    Ergodic.FormEvery( this );
                    gridControl1.DataSource = null;
                    Ergodic.FormEverySpliEnableFalse( this );
                    toolAdd.Enabled = toolSelect.Enabled = true;
                    toolSave.Enabled = toolCancel.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolPrint.Enabled = toolReview.Enabled = toolExport.Enabled = toolMaintain.Enabled = false;
                }
            }
            else
            {
                Ergodic.FormEverySpliEnableFalse( this );
                toolAdd.Enabled = toolSelect.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolPrint.Enabled = toolReview.Enabled = toolExport.Enabled = toolMaintain.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
            }
            sign = "";
        }
        protected override void revirw ( )
        {
            base.revirw( );

            Reviews( "AE01" ,model.AE01 ,"R_PQAE" ,this ,model.AE02 ,"R_250" ,false ,false,MulaolaoBll . Drity . GetDt ( )/*,"JM06" ,"JM87" ,"R_PQO" ,"JM01" ,JM01 ,ord ,textBox68.Text,"R_338"*/ );
            SpecialPowers sp = new SpecialPowers( );
            result = false;
            result = bll.GetReview( model ,this.Text );
            if ( result == true )
                label107.Visible = true;
            else
                label107.Visible = false;
        }
        protected override void export ( )
        {
            ViewExport . ExportToExcel ( this . Text ,gridControl2 );

            base . export ( );
        }
        #endregion

        #region Query
        protected override void select ( )
        {
            base.select( );

            daQuery.StartPosition = FormStartPosition.CenterScreen;
            daQuery.PassDataBetweenForm += new SelectAll.DailyCollectionRecordAll.PassDataBetweenFormHandler( daQuery_PassDataBetweenForm );
            daQuery.ShowDialog( );

            if ( listQuery.Count <= 0 )
                MessageBox.Show( "您没有选择任何内容" );
            else
            {

                strWhere = "1=1";
                string str = "''";
                foreach ( string item in listQuery )
                {
                    if ( !string.IsNullOrEmpty( item ) )
                        str = str + ",'" + item + "'";
                }
                strWhere = strWhere + " AND A.idx IN (" + str + ")";
                resfrs( );

                listQuery.Clear( );

                bandedGridView1.FocusedRowHandle = 0;

                Ergodic.FormEverySpliEnableFalse( this );
                toolAdd.Enabled = toolSelect.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolPrint.Enabled = toolReview.Enabled = toolExport.Enabled = toolMaintain.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
            }
        }
        private void daQuery_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            listQuery = e.List;
        }
        private void button1_Click ( object sender ,EventArgs e )
        {
            query.numPqfOne = "1";
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.SailesQueryAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );

            if ( !string.IsNullOrEmpty( model.AE02 ) )
                num( );
            else
                MessageBox.Show( "您没有选择任何内容" );
        }
        void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            model.AE02 = e.ConOne;
            textBox4.Text = e.ConOne;
        }
        void num ( )
        {
            DataTable da = bll.GetDataTablePqf( model.AE02 );
            if ( da.Rows.Count > 0 )
            {
                textBox1.Text = da.Rows[0]["PQF04"].ToString( );
                textBox2.Text = da.Rows[0]["PQF03"].ToString( );
                textBox3.Text = da.Rows[0]["PQF02"].ToString( );
                textBox5.Text = da.Rows[0]["PQF06"].ToString( );
                textBox6.Text = da.Rows[0]["DFA003"].ToString( );
                textBox7.Text = da.Rows[0]["DAA002"].ToString( );
                textBox8.Text = da.Rows[0]["DBA002"].ToString( );
                textBox9.Text = da.Rows[0]["PQF10"].ToString( );
                textBox10.Text = da.Rows[0]["PQF45"].ToString( );
                textBox11.Text = da.Rows[0]["PQF09"].ToString( );
                textBox12.Text = da.Rows[0]["PQF23"].ToString( );
                if ( !string.IsNullOrEmpty( da.Rows[0]["PQF13"].ToString( ) ) )
                    dateTimePicker1.Value = Convert.ToDateTime( da.Rows[0]["PQF13"].ToString( ) );
                if ( !string.IsNullOrEmpty( da.Rows[0]["RES4"].ToString( ) ) )
                    dateTimePicker2.Value = Convert.ToDateTime( da.Rows[0]["RES4"].ToString( ) );
                if ( !string.IsNullOrEmpty( da.Rows[0]["RES04"].ToString( ) ) )
                    dateTimePicker3.Value = Convert.ToDateTime( da.Rows[0]["RES04"].ToString( ) );
                if ( !string.IsNullOrEmpty( da.Rows[0]["PQF31"].ToString( ) ) )
                    dateTimePicker4.Value = Convert.ToDateTime( da.Rows[0]["PQF31"].ToString( ) );
                if ( !string.IsNullOrEmpty( da.Rows[0]["PQF34"].ToString( ) ) )
                    dateTimePicker5.Value = Convert.ToDateTime( da.Rows[0]["PQF34"].ToString( ) );
            }
        }
        #endregion

        #region Table
        void variable ( )
        {
            model.AE02 = textBox4.Text;
            model.AE03 = textBox1.Text;
            model.AE04 = textBox3.Text;
            model.AE05 = textBox2.Text;
            long num = 0;
            long.TryParse( string.IsNullOrEmpty( textBox5.Text ) ? "0" : textBox5.Text ,out num );
            model.AE06 = num;
            model.AE07 = textBox6.Text;
            model.AE08 = textBox7.Text;
            model.AE09 = textBox8.Text;
            decimal count = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox9.Text ) ? "0" : textBox9.Text ,out count );
            model.AE10 = count;
            count = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox10.Text ) ? "0" : textBox10.Text ,out count );
            model.AE11 = count;
            count = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox11.Text ) ? "0" : textBox11.Text ,out count );
            model.AE12 = count;
            model.AE13 = textBox12.Text;
            model.AE14 = dateTimePicker1.Value;
            model.AE15 = dateTimePicker2.Value;
            model.AE16 = dateTimePicker3.Value;
            model.AE17 = dateTimePicker4.Value;
            model.AE18 = dateTimePicker5.Value;
            count = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox13.Text ) ? "0" : textBox13.Text ,out count );
            model.AE19 = count;
            count = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox20.Text ) ? "0" : textBox20.Text ,out count );
            model.AE20 = count;
            if ( !string . IsNullOrEmpty ( dateEdit1 . Text . Trim ( ) ) )
                model . AE21 = DateTime . Parse ( dateEdit1 . Text );
            else
                model . AE21 = null;
            if ( !string . IsNullOrEmpty ( dateEdit3 . Text . Trim ( ) ) )
                model . AE22 = DateTime . Parse ( dateEdit3 . Text );
            else
                model . AE22 = null;
            if ( !string . IsNullOrEmpty ( dateEdit2 . Text . Trim ( ) ) )
                model . AE23 = DateTime . Parse ( dateEdit2 . Text );
            else
                model . AE23 = null;
            if ( !string . IsNullOrEmpty ( dateEdit4 . Text . Trim ( ) ) )
                model . AE24 = DateTime . Parse ( dateEdit4 . Text );
            else
                model . AE24 = null;
            //count = 0M;
            //decimal.TryParse( string.IsNullOrEmpty( textBox16.Text ) ? "0" : textBox16.Text ,out count );
            //model.AE25 = count;
            model.AE26 = string.IsNullOrEmpty( textBox34.Text ) == true ? 0 : Convert.ToInt32( textBox34.Text );
            count = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox15.Text ) ? "0" : textBox15.Text ,out count );
            model.AE27 = count;
            count = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox22.Text ) ? "0" : textBox22.Text ,out count );
            model.AE28 = count;
            count = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox18.Text ) ? "0" : textBox18.Text ,out count );
            model.AE29 = count;
            count = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox19.Text ) ? "0" : textBox19.Text ,out count );
            model.AE30 = count;
            count = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox23.Text ) ? "0" : textBox23.Text ,out count );
            model.AE31 = count;
            if ( !string . IsNullOrEmpty ( dateEdit5 . Text . Trim ( ) ) )
                model . AE32 = DateTime . Parse ( dateEdit5 . Text );
            else
                model . AE32 = null;
            count = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox21.Text ) ? "0" : textBox21.Text ,out count );
            model.AE33 = count;
            count = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox24.Text ) ? "0" : textBox24.Text ,out count );
            model.AE34 = count;
            model.AE35 = textBox26.Text;
            model.AE36 = textBox25.Text;
            num = 0;
            long.TryParse( string.IsNullOrEmpty( textBox14.Text ) ? "0" : textBox14.Text ,out num );
            model.AE37 = num;
            num = 0;
            long.TryParse( string.IsNullOrEmpty( textBox27.Text ) ? "0" : textBox27.Text ,out num );
            model.AE38 = num;
            model.AE39 = string.IsNullOrEmpty( textBox35.Text ) == true ? 0 : Convert.ToDecimal( textBox35.Text );
            model.AE40 = string.IsNullOrEmpty( textBox36.Text ) == true ? 0 : Convert.ToDecimal( textBox36.Text );
            model.AE41 = string.IsNullOrEmpty( textBox37.Text ) == true ? 0 : Convert.ToDecimal( textBox37.Text );
            model . AE42 = string . IsNullOrEmpty ( textBox38 . Text ) == true ? 0 : Convert . ToDecimal ( textBox38 . Text );
            count = 0M;
            decimal . TryParse ( string . IsNullOrEmpty ( textBox30 . Text ) ? "0" : textBox30 . Text ,out count );
            model . AE43 = count;
        }
        //add
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox4.Text ) )
                MessageBox.Show( "流水号不可为空" );
            else
            {
                variable( );

                result = false;
                result = bll.Add( model );
                if ( result==true )
                {
                    MessageBox.Show( "录入数据成功" );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND AE02='" + textBox4 . Text + "'";
                    resfrs( );
                }
                else
                    MessageBox.Show( "录入数据失败" );

                result = false;
            }
        }
        //update
        private void button4_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox4.Text ) )
                MessageBox.Show( "流水号不可为空" );
            else
            {
                variable( );
                if ( model.AE02 == pqf01 )
                {
                    result = bll.Update( model );
                    if ( result == true )
                    {
                        MessageBox.Show( "成功编辑数据" );
                        strWhere = "1=1";
                        strWhere = strWhere + " AND AE02='" + textBox4.Text + "'";
                        resfrs( );
                    }
                    else
                        MessageBox.Show( "编辑数据失败" );
                }
                else
                {
                    result = bll.Update( model );
                    if ( result == true )
                    {
                        MessageBox.Show( "成功编辑数据" );
                        strWhere = "1=1";
                        strWhere = strWhere + " AND AE02='" + textBox4 . Text + "'";
                        resfrs( );
                    }
                    else
                        MessageBox.Show( "编辑数据失败" );
                    //}
                }
                result = false;
            }
        }
        //delete
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox.Show( "确认删除此记录?" ,"删除提示" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
            {
                result = bll.Delete( model );
                if ( result == true )
                {
                    MessageBox.Show( "成功删除数据" );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND AE02='" + textBox4 . Text + "'";
                    resfrs( );
                }
                else
                    MessageBox.Show( "删除数据失败" );
                result = false;
            }
        }
        //refresh
        private void button5_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND AE02='" + textBox4 . Text + "'";
            resfrs( );
        }
        void resfrs ( )
        {
            if ( string.IsNullOrEmpty( strWhere ) )
                strWhere = "1=1";
            queryTable = bll.GetDataTable( strWhere );
            gridControl1.DataSource = queryTable;
            assignMent( );
            //calcSum ( );
            queryTableTwo = bll.GetDataTableTwo( strWhere );
            gridControl2.DataSource = queryTableTwo;
        }
        void assignMent ( )
        {
            if ( queryTable != null )
            {
                long sum = 0, count = 0;
                //countAe26:开票数量*产品单价
                //countAe25:发货应收款
                //countAe5:发货应收款
                //countAe28:结算已收款
                //countAe30:预收款
                //countAe29:美金预收款
                //countAe6:开票应收款
                //countAe27:取消合同款
                //countAe06:合同美金
                //countAe19:合同销售金额
                //countAe019:合同销售金额
                //countAe40:开票差额
                //countAe41:结算差额
                //countAe42:合同结算差额
                //countAe
                decimal countAe25 = 0, countAe26 = 0, countAe28 = 0, countAe30 = 0, countAe29 = 0, countAe6 = 0, countAe27 = 0, countAe06 = 0M, countAe19 = 0M, countAe40 = 0, countAe41 = 0, countAe42 = 0, countAe019 = 0, countAe25S = 0;

                DataRow row;

                for ( int i = 0 ; i < bandedGridView1 . DataRowCount ; i++ )
                {
                    row = bandedGridView1 . GetDataRow ( i );
                    model . AE06 = string . IsNullOrEmpty ( row [ "AE06" ] . ToString ( ) ) == true ? 0 : Convert . ToInt64 ( row [ "AE06" ] . ToString ( ) );
                    model . AE10 = string . IsNullOrEmpty ( row [ "AE10" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE10" ] . ToString ( ) );
                    model . AE11 = string . IsNullOrEmpty ( row [ "AE11" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE11" ] . ToString ( ) );
                    model . AE12 = string . IsNullOrEmpty ( row [ "AE12" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE12" ] . ToString ( ) );
                    model . AE19 = string . IsNullOrEmpty ( row [ "AE19" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE19" ] . ToString ( ) );
                    model . AE26 = string . IsNullOrEmpty ( row [ "AE26" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "AE26" ] . ToString ( ) );
                    model . AE27 = string . IsNullOrEmpty ( row [ "AE27" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE27" ] . ToString ( ) );
                    model . AE28 = string . IsNullOrEmpty ( row [ "AE28" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE28" ] . ToString ( ) );
                    model . AE29 = string . IsNullOrEmpty ( row [ "AE29" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE29" ] . ToString ( ) );
                    model . AE30 = string . IsNullOrEmpty ( row [ "AE30" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE30" ] . ToString ( ) );
                    model . AE37 = string . IsNullOrEmpty ( row [ "AE37" ] . ToString ( ) ) == true ? 0 : Convert . ToInt64 ( row [ "AE37" ] . ToString ( ) );
                    model . AE39 = string . IsNullOrEmpty ( row [ "AE39" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE39" ] . ToString ( ) );
                    model . AE40 = string . IsNullOrEmpty ( row [ "AE40" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE40" ] . ToString ( ) );
                    model . AE41 = string . IsNullOrEmpty ( row [ "AE41" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE41" ] . ToString ( ) );
                    model . AE42 = string . IsNullOrEmpty ( row [ "AE42" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE42" ] . ToString ( ) );

                    if ( !string . IsNullOrEmpty ( row [ "AE21" ] . ToString ( ) ) )
                        model . AE21 = Convert . ToDateTime ( row [ "AE21" ] . ToString ( ) );
                    else
                        model . AE21 = null;

                    if ( !string . IsNullOrEmpty ( row [ "AE22" ] . ToString ( ) ) )
                        model . AE22 = Convert . ToDateTime ( row [ "AE22" ] . ToString ( ) );
                    else
                        model . AE22 = null;

                    if ( !string . IsNullOrEmpty ( row [ "AE23" ] . ToString ( ) ) )
                        model . AE23 = Convert . ToDateTime ( row [ "AE23" ] . ToString ( ) );
                    else
                        model . AE23 = null;


                    countAe25S += model . AE37 * model . AE12;

                    if ( i == 0 )
                    {

                        countAe06 += model . AE06 * model . AE10;

                        #region  第一行
                        count += model . AE06;
                        sum += model . AE37;
                        bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U0" ] ,model . AE06 - sum );

                        countAe25 += model . AE37 * model . AE12;

                        countAe26 += model . AE26 * model . AE12;

                        bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U7" ] ,countAe25 - countAe26 );

                        countAe27 += model . AE27;

                        countAe28 += model . AE28;

                        countAe42 += model . AE42;

                        countAe30 += model . AE30;

                        countAe29 += model . AE29 * model . AE11;

                        countAe6 += model . AE39 == 0 ? model . AE26 * model . AE12 : model . AE26 * model . AE10 * model . AE39;


                        countAe19 += model . AE19;
                        countAe019 += model . AE19;

                        countAe40 += model . AE40;

                        countAe41 += model . AE41;


                        //if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "AE22" ] . ToString ( ) ) )
                        //    bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U12" ] ,countAe25 - countAe28 - countAe30 - countAe29 + countAe41 );
                        //if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "AE23" ] . ToString ( ) ) )
                        //bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U13" ] ,countAe6 - countAe28 - countAe30 - countAe29 + countAe40 );
                        //bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U11" ] ,countAe19 - countAe28 - countAe30 - countAe29 - countAe27 - countAe42 );

                        #endregion

                    }
                    else
                    {
                        #region
                        string str1 = bandedGridView1 . GetDataRow ( i ) [ "AE02" ] . ToString ( );
                        string str2 = bandedGridView1 . GetDataRow ( i - 1 ) [ "AE02" ] . ToString ( );
                        if ( str1 . Equals ( str2 ) )
                        {
                            #region 同流水

                            sum += model . AE37;
                            bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U0" ] ,model . AE06 - sum );

                            countAe25 += model . AE37 * model . AE12;

                            countAe26 += model . AE26 * model . AE12;
                            bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U7" ] ,countAe25 - countAe26 );

                            countAe27 += model . AE27;
                            countAe28 += model . AE28;
                            countAe42 += model . AE42;

                            countAe30 += model . AE30;

                            countAe29 += model . AE29 * model . AE11;

                            countAe6 += model . AE39 == 0 ? model . AE26 * model . AE12 : model . AE26 * model . AE10 * model . AE39;
                            countAe40 += model . AE40;
                            countAe41 += model . AE41;
                            #endregion
                        }
                        else
                        {
                            #region 不同流水

                            countAe25 = countAe26 = countAe28 = countAe30 = countAe29 = countAe6 = countAe27 = countAe19 = countAe42 = 0;

                            countAe06 += model . AE06 * model . AE10;
                            count += model . AE06;
                            sum = 0;
                            sum += model . AE37;
                            bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U0" ] ,model . AE06 - sum );
                            countAe25 += model . AE37 * model . AE12;

                            countAe26 += model . AE26 * model . AE12;
                            countAe25 = 0;
                            bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U7" ] ,countAe25 - countAe26 );

                            countAe27 += model . AE27;
                            countAe28 += model . AE28;
                            countAe42 += model . AE42;

                            countAe30 += model . AE30;

                            countAe29 += model . AE29 * model . AE11;

                            countAe6 += model . AE39 == 0 ? model . AE12 * model . AE26 : model . AE10 * model . AE26 * model . AE39;

                            countAe19 += model . AE19;
                            countAe019 += model . AE19;

                            countAe40 += model . AE40;
                            countAe41 += model . AE41;

                            #endregion
                        }
                        #endregion
                    }
                    if ( model . AE21 == null && model . AE23 == null )
                    {
                        bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U0" ] ,0 );
                        bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U7" ] ,0 );
                    }
                }

                AE06 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,count . ToString ( ) );
                U0 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,( count - Convert . ToInt64 ( AE37 . SummaryItem . SummaryValue ) ) . ToString ( ) );
                U7 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( countAe25S - Convert . ToDecimal ( U20 . SummaryItem . SummaryValue ) ,2 ) . ToString ( ) );

                U6 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( countAe06 ,2 ) . ToString ( ) );
                AE19 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,countAe019 . ToString ( ) );
                U11 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( countAe019 - Convert . ToDecimal ( AE28 . SummaryItem . SummaryValue ) - Convert . ToDecimal ( AE30 . SummaryItem . SummaryValue ) - Convert . ToDecimal ( AE29 . SummaryItem . SummaryValue ) - Convert . ToDecimal ( AE27 . SummaryItem . SummaryValue ) - Convert . ToDecimal ( AE42 . SummaryItem . SummaryValue ) ,2 ) . ToString ( ) );

                decimal ae29Count = string . IsNullOrEmpty ( AE29 . SummaryItem . SummaryValue . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( AE29 . SummaryItem . SummaryValue );

                U23 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,( countAe06 - ae29Count ) . ToString ( ) );
            }
        }
        void calcSum ( )
        {
            //countAe26:开票数量*产品单价
            //countAe25:发货应收款
            //countAe5:发货应收款
            //countAe28:结算已收款
            //countAe30:预收款
            //countAe29:美金预收款
            //countAe6:开票应收款
            //countAe27:取消合同款
            //countAe06:合同美金
            //countAe19:合同销售金额
            //countAe019:合同销售金额
            //countAe40:开票差额
            //countAe41:结算差额
            //countAe42:合同结算差额
            //countAe2911:折币预收款
            //long sum = 0, count = 0;
            decimal countAe25 = 0, /*countAe26 = 0,*/ countAe28 = 0, countAe30 = 0, countAe29 = 0, /*countAe6 = 0,*/ countAe27 = 0, /*countAe06 = 0M,*/ countAe19 = 0M, /*countAe40 = 0,*/ countAe41 = 0, countAe42 = 0, /*countAe019 = 0,*/ countAe2911 = 0, sumU12 = 0;

            //(U11)合同未收款=合同销售金额(AE19)-预收款(AE30)-取消合同款(AE27)-结算已收款(AE28)-美金预收款(AE29)-合同结算差额(AE42)

            //(U12)发货未收款=发货应收款(AE25)-结算已收款(AE28)-预收款(AE30)-折币预收款(AE29*AE11)+发货结算差额(AE41)
            string numOne = string . Empty, numTwo = string . Empty;
            for ( int i = 0 ; i < bandedGridView1 . RowCount ; i++ )
            {
                DataRow row = bandedGridView1 . GetDataRow ( i );        
                
                     
                if ( row != null )
                {
                    model . AE06 = string . IsNullOrEmpty ( row [ "AE06" ] . ToString ( ) ) == true ? 0 : Convert . ToInt64 ( row [ "AE06" ] . ToString ( ) );
                    model . AE10 = string . IsNullOrEmpty ( row [ "AE10" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE10" ] . ToString ( ) );
                    model . AE11 = string . IsNullOrEmpty ( row [ "AE11" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE11" ] . ToString ( ) );
                    model . AE12 = string . IsNullOrEmpty ( row [ "AE12" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE12" ] . ToString ( ) );
                    model . AE19 = string . IsNullOrEmpty ( row [ "AE19" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE19" ] . ToString ( ) );
                    model . AE26 = string . IsNullOrEmpty ( row [ "AE26" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "AE26" ] . ToString ( ) );
                    model . AE27 = string . IsNullOrEmpty ( row [ "AE27" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE27" ] . ToString ( ) );
                    model . AE28 = string . IsNullOrEmpty ( row [ "AE28" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE28" ] . ToString ( ) );
                    model . AE29 = string . IsNullOrEmpty ( row [ "AE29" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE29" ] . ToString ( ) );
                    model . AE30 = string . IsNullOrEmpty ( row [ "AE30" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE30" ] . ToString ( ) );
                    model . AE37 = string . IsNullOrEmpty ( row [ "AE37" ] . ToString ( ) ) == true ? 0 : Convert . ToInt64 ( row [ "AE37" ] . ToString ( ) );
                    model . AE39 = string . IsNullOrEmpty ( row [ "AE39" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE39" ] . ToString ( ) );
                    model . AE40 = string . IsNullOrEmpty ( row [ "AE40" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE40" ] . ToString ( ) );
                    model . AE41 = string . IsNullOrEmpty ( row [ "AE41" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE41" ] . ToString ( ) );
                    model . AE42 = string . IsNullOrEmpty ( row [ "AE42" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "AE42" ] . ToString ( ) );

                    if ( !string . IsNullOrEmpty ( row [ "AE21" ] . ToString ( ) ) )
                        model . AE21 = Convert . ToDateTime ( row [ "AE21" ] . ToString ( ) );
                    else
                        model . AE21 = null;

                    if ( !string . IsNullOrEmpty ( row [ "AE22" ] . ToString ( ) ) )
                        model . AE22 = Convert . ToDateTime ( row [ "AE22" ] . ToString ( ) );
                    else
                        model . AE22 = null;

                    if ( !string . IsNullOrEmpty ( row [ "AE23" ] . ToString ( ) ) )
                        model . AE23 = Convert . ToDateTime ( row [ "AE23" ] . ToString ( ) );
                    else
                        model . AE23 = null;

                    numOne = row [ "AE02" ] . ToString ( );
                    if ( i == 0 )
                    {
                        countAe19 += model . AE19;
                        countAe30 += model . AE30;
                        countAe27 += model . AE27;
                        countAe28 += model . AE28;
                        countAe29 += model . AE29;
                        countAe42 += model . AE42;
                        countAe25 += model . AE37 * model . AE12;
                        countAe2911 += model . AE29 * model . AE11;
                        countAe41 += model . AE41;

                        bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U11" ] ,countAe19 - countAe30 - countAe27 - countAe28 - countAe29 - countAe42 );
                        if ( model.AE22!=null )
                        {
                            bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U12" ] ,countAe25 - countAe28 - countAe30 - countAe2911 + countAe41 );
                        }
                    }
                    else
                    {
                        numTwo = bandedGridView1 . GetDataRow ( i - 1 ) [ "AE02" ] . ToString ( );
                        if ( numOne . Equals ( numTwo ) )
                        {
                            countAe30 += model . AE30;
                            countAe27 += model . AE27;
                            countAe28 += model . AE28;
                            countAe29 += model . AE29;
                            countAe42 += model . AE42;
                            countAe25 += model . AE37 * model . AE12;
                            countAe2911 += model . AE29 * model . AE11;
                            countAe41 += model . AE41;

                            bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U11" ] ,countAe19 - countAe30 - countAe27 - countAe28 - countAe29 - countAe42 );
                            if ( model.AE22!=null )
                            {
                                bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U12" ] ,countAe25 - countAe28 - countAe30 - countAe2911 + countAe41 );
                            }
                        }
                        else
                        {
                            countAe30 = countAe19 = countAe27 = countAe28 = countAe29 = countAe42 = countAe25 = countAe2911 = countAe41 = 0;
                            countAe19 += model . AE19;
                            countAe30 += model . AE30;
                            countAe27 += model . AE27;
                            countAe28 += model . AE28;
                            countAe29 += model . AE29;
                            countAe42 += model . AE42;
                            countAe25 += model . AE37 * model . AE12;
                            countAe2911 += model . AE29 * model . AE11;
                            countAe41 += model . AE41;

                            bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U11" ] ,countAe19 - countAe30 - countAe27 - countAe28 - countAe29 - countAe42 );
                            if ( model . AE22 != null )
                            {
                                bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U12" ] ,countAe25 - countAe28 - countAe30 - countAe2911 + countAe41 );
                            }
                        }
                    }
                    sumU12 = countAe25 - countAe28 - countAe30 - countAe2911 + countAe41;
                }
            }
        }
        //Read
        private void button6_Click ( object sender ,EventArgs e )
        {
            DataTable tableRead = bll.GetDataTable( );
            if ( tableRead != null && tableRead.Rows.Count > 0 )
            {
                DataTable da;
                for ( int i = 0 ; i < tableRead.Rows.Count ; i++ )
                {
                    model.AE02 = tableRead.Rows[i]["PQF01"].ToString( );
                    model.AE03 = tableRead.Rows[i]["PQF04"].ToString( );
                    model.AE04 = tableRead.Rows[i]["PQF02"].ToString( );
                    model.AE05 = tableRead.Rows[i]["PQF03"].ToString( );
                    model.AE06 = string.IsNullOrEmpty( tableRead.Rows[i]["PQF06"].ToString( ) ) == true ? 0 : Convert.ToInt64( tableRead.Rows[i]["PQF06"].ToString( ) );
                    model.AE07 = tableRead.Rows[i]["DFA003"].ToString( );
                    model.AE08 = tableRead.Rows[i]["DAA002"].ToString( );
                    model.AE09 = tableRead.Rows[i]["DBA002"].ToString( );
                    model.AE10 = string.IsNullOrEmpty( tableRead.Rows[i]["PQF10"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableRead.Rows[i]["PQF10"].ToString( ) );
                    model.AE11 = string.IsNullOrEmpty( tableRead.Rows[i]["PQF45"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableRead.Rows[i]["PQF45"].ToString( ) );
                    model.AE12 = string.IsNullOrEmpty( tableRead.Rows[i]["PQF09"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableRead.Rows[i]["PQF09"].ToString( ) );
                    model.AE13 = tableRead.Rows[i]["PQF23"].ToString( );
                    model.AE14 = string.IsNullOrEmpty( tableRead.Rows[i]["PQF13"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( tableRead.Rows[i]["PQF13"].ToString( ) );
                    model.AE15 = string.IsNullOrEmpty( tableRead.Rows[i]["RES4"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( tableRead.Rows[i]["RES4"].ToString( ) );
                    model.AE16 = string.IsNullOrEmpty( tableRead.Rows[i]["RES04"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( tableRead.Rows[i]["RES04"].ToString( ) );
                    model.AE17 = string.IsNullOrEmpty( tableRead.Rows[i]["PQF31"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( tableRead.Rows[i]["PQF31"].ToString( ) );
                    model.AE18 = string.IsNullOrEmpty( tableRead.Rows[i]["PQF34"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( tableRead.Rows[i]["PQF34"].ToString( ) );
                    model.AE19 = string.IsNullOrEmpty( tableRead.Rows[i]["AE19"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableRead.Rows[i]["AE19"].ToString( ) );
                    model.AE20 = 0;
                    da = bll.ExistsDataTable( model.AE02 );
                    if ( da != null && da.Rows.Count > 0 )
                    {
                        if ( da.Select( "AE26=0 AND AE37=0 AND AE38=0 AND AE22 IS NULL" ).Length < 1 )
                        {
                            model.AE01 = da.Rows[0]["AE01"].ToString( );
                            result = bll.Adds( model );
                            if ( result == false )
                            {
                                MessageBox.Show( "读取失败,请重试" );
                                return;
                            }
                            else if ( i == tableRead.Rows.Count - 1 )
                                MessageBox.Show( "读取成功,请查询" );
                        }
                        else
                        {
                            result = bll.Updatas( model );
                            if ( result == false )
                            {
                                MessageBox.Show( "读取失败,请重试" );
                                return;
                            }
                            else if ( i == tableRead.Rows.Count - 1 )
                                MessageBox.Show( "读取成功,请查询" );
                        }
                    }
                    else
                    {
                        model.AE01 = oddNumbers.purchaseContract( "SELECT MAX(AE01) AE01 FROM R_PQAE" ,"AE01" ,"R_250-" );
                        result = bll.Adds( model );
                        if ( result == false )
                        {
                            MessageBox.Show( "读取失败,请重试" );
                            return;
                        }
                        else if ( i == tableRead.Rows.Count - 1 )
                            MessageBox.Show( "读取成功,请查询" );
                    }
                }
            }
        }
        #endregion

    }
}
