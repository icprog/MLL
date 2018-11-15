using DevExpress . XtraGrid . Views . Grid;
using FastReport;
using FastReport . Export . Xml;
using Mulaolao . Class;
using Mulaolao . Other;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao.Summary
{
    public partial class R_FrmChengBenYuHeSuanAll : FormChild
    {
        public R_FrmChengBenYuHeSuanAll ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { bandedGridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.ChengBenYuHeSuanAllLibrary model = new MulaolaoLibrary.ChengBenYuHeSuanAllLibrary( );
        MulaolaoBll.Bll.ChengBenYuHeSuanAllBll bll = new MulaolaoBll.Bll.ChengBenYuHeSuanAllBll( );
        
        string sign = "", strWhere = "1=1";
        DataTable queryTable, da,printOne,printTwo;
        bool result = false;
        List<string> list = new List<string>( );
        
        private void R_FrmChengBenYuHeSuanAll_Load ( object sender ,EventArgs e )
        {
            Power( this );
            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;
            Ergodic.FormEverySpliEnableFalse( this );

        }

        #region Main
        protected override void add ( )
        {
            base.add( );

            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;
            Ergodic.FormEverySpliEnableTrue( this );
            model.AN001 = oddNumbers.purchaseContract( "SELECT MAX(AN001) AN001 FROM R_PQAN" ,"AN001" ,"R_240-" );
            sign = "1";
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void delete ( )
        {
            base.delete( );

            string idxList = "''";
            for ( int i = 0 ; i < queryTable.Rows.Count ; i++ )
            {
                idxList = idxList + "," + "'" + queryTable.Rows[i]["idx"].ToString( ) + "'";
            }

            bool result = bll.DeleteList( idxList );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;
                Ergodic.FormEverySpliEnableFalse( this );
                toolAdd.Enabled = toolSelect.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolPrint.Enabled = toolReview.Enabled = toolExport.Enabled = toolMaintain.Enabled = false;
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        protected override void update ( )
        {
            base.update( );

            if ( bandedGridView1.RowCount > 0 )
                model.AN001 = bandedGridView1.GetDataRow( 0 )["AN001"].ToString( );
            Ergodic.FormEverySpliEnableTrue( this );
            toolAdd.Enabled = toolSelect.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolPrint.Enabled = toolReview.Enabled = toolExport.Enabled = toolMaintain.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
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
                    for ( int i = 0 ; i < queryTable.Rows.Count ; i++ )
                    {
                        idxList = idxList + "," + "'" + queryTable.Rows[i]["idx"].ToString( ) + "'";
                    }

                    bll.DeleteList( idxList );
                }
                catch { }
                finally {
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
        protected override void export ( )
        {
            //ViewExport . ExportToExcel ( this . Text ,gridControl1 );

            DataSet RDataSet = new DataSet ( );
            model . AN002 = textBox3 . Text;
            printOne = bll . getPrintOne ( model . AN002 );
            printOne . TableName = "R_PQAN";
            printTwo = bll . getPrintTwo ( model . AN002 );
            printTwo . TableName = "R_PQAN1";
            RDataSet . Tables . Add ( printOne );
            RDataSet . Tables . Add ( printTwo );

            Report report = new Report ( );
            report . Load ( Application . StartupPath + "\\R_240.frx" );
            report . RegisterData ( RDataSet );
            report . Prepare ( );
            XMLExport exprots = new XMLExport ( );
            exprots . Export ( report );

            base . export ( );
        }
        #endregion

        #region Event
        private void bandedGridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView1.FocusedRowHandle >= 0 && bandedGridView1.FocusedRowHandle <= queryTable.Rows.Count - 1 )
            {
                if ( !string.IsNullOrEmpty( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) )
                {
                    model.Idx = Convert.ToInt32( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                    assignMent( );
                }
            }
        }
        object an006Temp = 0;
        private void bandedGridView1_CustomSummaryCalculate ( object sender ,DevExpress.Data.CustomSummaryEventArgs e )
        {
            GridView view = sender as GridView;
            int summaryId = Convert.ToInt32( ( e.Item as DevExpress.XtraGrid.GridSummaryItem ).Tag );

            if ( e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Calculate )
            {
                for ( int i = 0 ; i < queryTable.Rows.Count ; i++ )
                {
                    an006Temp = queryTable.Rows[i]["AN006"];
                    an006Temp = ( an006Temp == DBNull.Value || an006Temp == null ) ? 0 : an006Temp;
                }
            }
            if ( e.SummaryProcess == DevExpress.Data.CustomSummaryProcess.Finalize )
            {
                switch ( summaryId )
                {
                    case 12:
                    e.TotalValue = an006Temp;
                    break;
                }
            }
           
        }
        void assignMent ( )
        {
            model = bll.GetModel( model );
            textBox8.Text = model.AN012;
            textBox11.Text = model.AN013;
            textBox9.Text = model.AN019.ToString( );
            textBox10.Text = model.AN024;
            textBox7.Text = model.AN023;
            textBox6.Text = model.AN007;
        }
        private void textBox9_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox9 );
        }
        private void textBox9_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise . textChangeTb( textBox9 );
        }
        private void textBox9_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox9.Text != "" && !DateDayRegise . tenTwoNumber( textBox9 ) )
            {
                this.textBox9.Text = "";
                MessageBox.Show( "只允许输入整数部分最多八位,小数部分最多两位,如99999999.99,请重新输入" );
            }
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( textBox6.Text == "" )
            {
                textBox6.Text = Logins.username;
            }
            else if ( textBox6.Text != "" && textBox6.Text == Logins.username )
            {
                textBox6.Text = "";
            }
        }
        private void bandedGridView1_CustomDrawRowFooterCell ( object sender ,FooterCellCustomDrawEventArgs e )
        {
            decimal d1 = 0M, d2 = 0M, d3 = 0M;
            //this.AN017:GridView中的列  AN006、 U1均是
            if ( e.Column == this.AN017 )
            {
                d1 = d2 = d3 = 0M;
                 d1 = this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.AN006 ) == "" ? 0 : Convert.ToDecimal( this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.AN006 ) );
                 d2 = this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.U1 ) == "" ? 0 : Convert.ToDecimal( this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.U1 ) );
                 d3 = d1 == 0 ? 0 : Math.Round( d2 / d1 ,2 );
                e.Info.DisplayText = d3.ToString( );
            }
            if ( e.Column == this.U2 )
            {
                d1 = d2 = d3 = 0M;
                 d1 = this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.AN006 ) == "" ? 0 : Convert.ToDecimal( this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.AN006 ) );
                 d2 = this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.AN019 ) == "" ? 0 : Convert.ToDecimal( this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.AN019 ) );
                 d3 = d1 == 0 ? 0 : Math.Round( d2 / d1 ,2 );
                e.Info.DisplayText = d3.ToString( );
            }
            if ( e.Column == this.U3 )
            {
                d1 = d2 = d3 = 0M;
                 d1 = this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.AN006 ) == "" ? 0 : Convert.ToDecimal( this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.AN006 ) );
                 d2 = this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.AN020 ) == "" ? 0 : Convert.ToDecimal( this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.AN020 ) );
                 d3 = d1 == 0 ? 0 : Math.Round( d2 / d1 ,2 );
                e.Info.DisplayText = d3.ToString( );
            }
            if ( e.Column == this.U4 )
            {
                d1 = d2 = d3 = 0M;
                d1 = this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.AN006 ) == "" ? 0 : Convert.ToDecimal( this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.AN006 ) );
                d2 = this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.AN025 ) == "" ? 0 : Convert.ToDecimal( this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.AN025 ) );
                d3 = d1 == 0 ? 0 : Math.Round( d2 / d1 ,2 );
                e.Info.DisplayText = d3.ToString( );
            }
            if ( e.Column == this.U6)
            {
                d1 = d2 = d3 = 0M;
                d1 = this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.AN006 ) == "" ? 0 : Convert.ToDecimal( this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.AN006 ) );
                d2 = this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.AN022 ) == "" ? 0 : Convert.ToDecimal( this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.AN022 ) );
                d3 = d1 == 0 ? 0 : Math.Round( d2 / d1 ,2 );
                e.Info.DisplayText = d3.ToString( );
            }
            if ( e.Column == this.U7 )
            {
                d1 = d2 = d3 = 0M;
                d1 = this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.AN006 ) == "" ? 0 : Convert.ToDecimal( this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.AN006 ) );
                d2 = this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.U5 ) == "" ? 0 : Convert.ToDecimal( this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.U5 ) );
                d3 = d1 == 0 ? 0 : Math.Round( d2 / d1 ,2 );
                e.Info.DisplayText = d3.ToString( );
            }
            if ( e.Column == this.U9 )
            {
                d1 = d2 = d3 = 0M;
                d1 = this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.AN006 ) == "" ? 0 : Convert.ToDecimal( this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.AN006 ) );
                d2 = this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.U8 ) == "" ? 0 : Convert.ToDecimal( this.bandedGridView1.GetRowFooterCellText( e.RowHandle ,this.U8 ) );
                d3 = d1 == 0 ? 0 : Math.Round( d2 / d1 ,2 );
                e.Info.DisplayText = d3.ToString( );
            }
        }
        #endregion

        #region Table
        void variable ( )
        {
            model.AN002 = textBox3.Text;
            model.AN003 = textBox1.Text;
            model.AN004 = textBox2.Text;
            model.AN005 = textBox4.Text;
            model.AN006 = string.IsNullOrEmpty( textBox5.Text ) == true ? 0 : Convert.ToInt64( textBox5.Text );
            model.AN007 = textBox6.Text;
            model.AN008 = dateTimePicker1.Value;
            model.AN009 = dateTimePicker2.Value;
            model.AN010 = dateTimePicker3.Value;
            model.AN011 = textBox7.Text;
            model.AN012 = textBox8.Text;
            model.AN013 = textBox11.Text;
            model.AN014 = "";
            model.AN015 = 0;
            model.AN016 = 0;
            model.AN017 = 0;
            model.AN018 = 0;
            model.AN019 = string.IsNullOrEmpty( textBox9.Text ) == true ? 0 : Convert.ToDecimal( textBox9.Text );
            model.AN020 = 0;
            model.AN021 = 0;
            model.AN022 = 0;
            model.AN023 = textBox7.Text;
            model.AN024 = textBox10.Text;
            model.AN025 = 0;
        }
        void otherVariable ( )
        {
            model.AN007 = textBox6.Text;
            model.AN012 = textBox8.Text;
            model.AN013 = textBox11.Text;
            model.AN014 = "";
            model.AN015 = 0;
            model.AN016 = 0;
            model.AN017 = 0;
            model.AN018 = 0;
            model.AN019 = string.IsNullOrEmpty( textBox9.Text ) == true ? 0 : Convert.ToDecimal( textBox9.Text );
            model.AN020 = 0;
            model.AN021 = 0;
            model.AN022 = 0;
            model.AN023 = "";
            model.AN024 = textBox10.Text;
            model.AN025 = 0;
        }
        //Generate
        private void button7_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( textBox3 . Text ) )
                MessageBox . Show ( "请选择流水号" );
            else
            {
                variable ( );

                #region R_195
                da = bll . GetDataTablePqq ( model . AN002 );
                if ( da . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        model . AN012 = "产品委外(成品、雕刻、冲印、砂皮)等承揽加工合同书(R_195)";
                        model . AN013 = da . Rows [ i ] [ "CP09" ] . ToString ( );
                        model . AN014 = "";
                        model . AN015 = 0;
                        model . AN016 = 0;
                        model . AN017 = 0;
                        model . AN018 = 0;
                        model . AN019 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U0" ] . ToString ( ) );
                        model . AN020 = 0;
                        model . AN021 = 0;
                        model . AN022 = 0;
                        model . AN023 = da . Rows [ i ] [ "CP32" ] . ToString ( );
                        model . AN025 = model . AN019 + model . AN020;

                        model . Idx = bll . idxExists ( model );
                        if ( model . Idx > 0 )
                        {
                            result = bll . UpdateContract ( model );
                            if ( result == false )
                            {
                                MessageBox . Show ( "生成R_195失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_195成功" );
                        }
                        else
                        {
                            model . Idx = bll . Add ( model );
                            if ( model . Idx <= 0 )
                            {
                                MessageBox . Show ( "生成R_195失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_195成功" );
                        }
                    }
                }
                else
                    MessageBox . Show ( "R_195中没有流水号:" + model . AN002 + "的记录" );
                #endregion

                #region R_196
                da = null;
                da = bll . GetDataTablePqah ( model . AN002 );
                if ( da . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        model . AN012 = "丝.热.移印(化学品)承揽加工合同书 (R_196)";
                        model . AN013 = da . Rows [ i ] [ "AH18" ] . ToString ( );
                        model . AN014 = "";
                        model . AN015 = 0;
                        model . AN016 = 0;
                        model . AN017 = 0;
                        model . AN018 = 0;
                        if ( da . Rows [ i ] [ "AH111" ] . ToString ( ) == "T" )
                        {
                            model . AN022 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U0" ] . ToString ( ) );
                            model . AN019 = 0;
                            model . AN020 = 0;
                        }
                        else
                        {
                            model . AN019 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U0" ] . ToString ( ) );
                            model . AN020 = 0;
                            model . AN022 = 0;
                        }
                        model . AN021 = 0;
                        model . AN023 = da . Rows [ i ] [ "AH05" ] . ToString ( );
                        model . AN025 = model . AN019 + model . AN020;

                        model . Idx = bll . idxExists ( model );
                        if ( model . Idx > 0 )
                        {
                            result = bll . UpdateContract ( model );
                            if ( result == false )
                            {
                                MessageBox . Show ( "生成R_196失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_196成功" );
                        }
                        else
                        {
                            model . Idx = bll . Add ( model );
                            if ( model . Idx <= 0 )
                            {
                                MessageBox . Show ( "生成R_196失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_196成功" );
                        }
                    }
                }
                else
                    MessageBox . Show ( "R_196中没有流水号:" + model . AN002 + "的记录" );
                #endregion

                #region R_317
                da = null;
                da = bll . GetDataTablePqw ( model . AN002 );
                if ( da . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        model . AN012 = "产品工资考勤表(R_317)";
                        model . AN013 = da . Rows [ i ] [ "GX04" ] . ToString ( );
                        model . AN014 = "";
                        model . AN015 = 0;
                        model . AN016 = 0;
                        model . AN017 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS36" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GS36" ] . ToString ( ) );
                        model . AN018 = 0;
                        model . AN019 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GZ" ] . ToString ( ) );
                        model . AN020 = 0;
                        model . AN021 = 0;
                        model . AN022 = 0;
                        model . AN023 = da . Rows [ i ] [ "GZ30" ] . ToString ( );
                        model . AN024 = "";
                        model . AN025 = model . AN019 + model . AN020;

                        model . Idx = bll . idxExists ( model );
                        if ( model . Idx > 0 )
                        {
                            result = bll . UpdateContract ( model );
                            if ( result == false )
                            {
                                MessageBox . Show ( "生成R_317失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_317成功" );
                        }
                        else
                        {
                            result = bll . AddOfPqw ( model );
                            if ( result == false )
                            {
                                MessageBox . Show ( "生成R_317失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_317成功" );
                        }
                    }
                }
                #endregion

                #region R_338
                da = null;
                da = bll . GetDataTablePqo ( model . AN002 );
                if ( da . Rows . Count > 0 )
                {
                    List<decimal> sign = new List<decimal> ( );
                    List<decimal> signT = new List<decimal> ( );
                    int k = 0;
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        model . AN012 = "胶合板、密度板采购合同书(R_338)";
                        model . AN013 = da . Rows [ i ] [ "JM09" ] . ToString ( );
                        model . AN014 = da . Rows [ i ] [ "JM94" ] . ToString ( ) + "*" + da . Rows [ i ] [ "JM95" ] . ToString ( ) + "*" + da . Rows [ i ] [ "JM96" ] . ToString ( );
                        model . AN015 = string . IsNullOrEmpty ( da . Rows [ i ] [ "JM10" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "JM10" ] . ToString ( ) );
                        model . AN016 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS10" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GS10" ] . ToString ( ) );
                        if ( model . AN013 . Trim ( ) . Equals ( "胶合板" ) )
                        {
                            model . AN017 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS51" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GS51" ] . ToString ( ) );
                            sign . Add ( model . AN017 );
                            foreach ( decimal si in sign )
                            {
                                if ( si != 0 )
                                {
                                    k++;
                                }
                            }
                            if ( k > 1 )
                                model . AN017 = 0;
                            k = 0;
                        }
                        if ( model . AN013 . Trim ( ) . Equals ( "密度板" ) )
                        {
                            model . AN017 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS51" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GS51" ] . ToString ( ) );
                            signT . Add ( model . AN017 );
                            foreach ( decimal sig in signT )
                            {
                                if ( sig != 0 )
                                {
                                    k++;
                                }
                            }
                            if ( k > 1 )
                                model . AN017 = 0;
                            k = 0;
                        }
                        model . AN018 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS04" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GS04" ] . ToString ( ) );
                        if ( da . Rows [ i ] [ "JM107" ] . ToString ( ) . Trim ( ) . Equals ( "T" ) )
                        {
                            model . AN022 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U0" ] . ToString ( ) );
                            model . AN019 = 0;
                            model . AN020 = 0;
                        }
                        else
                        {
                            if ( da . Rows [ i ] [ "JM14" ] . ToString ( ) . Trim ( ) . Equals ( "外购" ) )
                            {
                                model . AN019 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U0" ] . ToString ( ) );
                                model . AN020 = 0;
                            }
                            else
                            {
                                model . AN019 = 0;
                                model . AN020 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U0" ] . ToString ( ) );
                            }

                            model . AN022 = 0;
                        }
                        model . AN021 = 0;
                        model . AN023 = da . Rows [ i ] [ "DBA002" ] . ToString ( );
                        model . AN025 = model . AN019 + model . AN020;

                        model . Idx = bll . idxExists ( model );
                        if ( model . Idx > 0 )
                        {
                            result = bll . UpdateOfPqw ( model );
                            if ( result == false )
                            {
                                MessageBox . Show ( "生成R_338失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_338成功" );
                        }
                        else
                        {
                            model . Idx = bll . Add ( model );
                            if ( model . Idx <= 0 )
                            {
                                MessageBox . Show ( "生成R_338失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_338成功" );
                        }
                    }
                    sign . Clear ( );
                    signT . Clear ( );
                }
                else
                    MessageBox . Show ( "R_338中没有流水号:" + model . AN002 + "的记录" );
                #endregion

                #region R_339  285
                da = null;
                da = bll . GetDataTablePqi ( model . AN002 );
                if ( da . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        model . AN012 = /*"油漆（墨）等化学品采购合同书(R_339)"*/"油漆（墨）、香蕉水等化学品防白水使用批次及成本汇总表(R_285)";
                        model . AN013 = "油漆";
                        model . AN014 = "";
                        model . AN015 = 0;
                        model . AN016 = 0;
                        model . AN017 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U3" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U3" ] . ToString ( ) );
                        model . AN018 = 0;
                        model . AN019 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U4" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U2" ] . ToString ( ) );
                        model . AN020 = 0;
                        model . AN021 = 0;
                        model . AN022 = 0;
                        model . AN025 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U2" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U2" ] . ToString ( ) );
                        model . AN023 = da . Rows [ i ] [ "DBA002" ] . ToString ( );

                        model . Idx = bll . idxExists ( model );
                        if ( model . Idx > 0 )
                        {
                            result = bll . UpdateContract ( model );
                            if ( result == false )
                            {
                                MessageBox . Show ( "生成R_339失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_339成功" );
                        }
                        else
                        {
                            model . Idx = bll . Add ( model );
                            if ( model . Idx <= 0 )
                            {
                                MessageBox . Show ( "生成R_339失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_339成功" );
                        }
                    }
                }
                else
                    MessageBox . Show ( "R_339中没有流水号:" + model . AN002 + "的记录" );
                #endregion

                #region R_344 厂外
                da = null;
                da = bll . GetDataTablePqmz ( model . AN002 );
                if ( da . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        model . AN012 = "滚漆油漆成本采购合同书--厂外(R_344)";
                        model . AN013 = da . Rows [ i ] [ "PZ009" ] . ToString ( );
                        model . AN014 = string . Empty;
                        model . AN015 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PZ030" ] . ToString ( ) ) == true ? 0M : Convert . ToDecimal ( da . Rows [ i ] [ "PZ030" ] . ToString ( ) );
                        model . AN016 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS10" ] . ToString ( ) ) == true ? 0M : Convert . ToDecimal ( da . Rows [ i ] [ "GS10" ] . ToString ( ) );
                        model . AN017 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS51" ] . ToString ( ) ) == true ? 0M : Convert . ToDecimal ( da . Rows [ i ] [ "GS51" ] . ToString ( ) );
                        model . AN018 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS04" ] . ToString ( ) ) == true ? 0M : Convert . ToDecimal ( da . Rows [ i ] [ "GS04" ] . ToString ( ) );
                        model . AN019 = string . IsNullOrEmpty ( da . Rows [ i ] [ "MZ1" ] . ToString ( ) ) == true ? 0M : Convert . ToDecimal ( da . Rows [ i ] [ "MZ1" ] . ToString ( ) );
                        model . AN020 = 0M;
                        model . AN021 = string . IsNullOrEmpty ( da . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "idx" ] . ToString ( ) );
                        model . AN022 = 0M;
                        model . AN023 = da . Rows [ i ] [ "PZ023" ] . ToString ( );
                        model . AN024 = "";
                        model . AN025 = model . AN019 + model . AN020;

                        model . Idx = bll . idxExists ( model );
                        if ( model . Idx > 0 )
                        {
                            result = bll . UpdateOfPqw ( model );
                            if ( result == false )
                            {
                                MessageBox . Show ( "生成R_344厂外失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_344厂外成功" );
                        }
                        else
                        {
                            model . Idx = bll . Add ( model );
                            if ( model . Idx <= 0 )
                            {
                                MessageBox . Show ( "生成R_344厂外失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_344厂外成功" );
                        }
                    }
                }
                else
                    MessageBox . Show ( "R_344中没有流水号:" + model . AN002 + "的记录" );
                #endregion

                #region R_344 346 工资
                da = null;
                da = bll . GetDataTablePqmzs ( model . AN002 );
                if ( da != null && da . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        model . AN012 = "滚漆油漆成本采购合同书--工资(R_344)";
                        model . AN013 = "";
                        model . AN014 = "";
                        model . AN015 = 0;
                        model . AN016 = 0;
                        model . AN017 = 0;
                        model . AN018 = 0;
                        model . AN019 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PZ" ] . ToString ( ) ) == true ? 0M : Convert . ToDecimal ( da . Rows [ i ] [ "PZ" ] . ToString ( ) );
                        model . AN020 = 0M;
                        model . AN021 = 0;
                        model . AN022 = 0M;
                        model . AN023 = da . Rows [ i ] [ "MZ031" ] . ToString ( );
                        model . AN024 = "";
                        model . AN025 = model . AN019 + model . AN020;


                        model . Idx = bll . idxExists ( model );
                        if ( model . Idx > 0 )
                        {
                            result = bll . UpdateContract ( model );
                            if ( result == false )
                            {
                                MessageBox . Show ( "生成R_344工资失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_344工资成功" );
                        }
                        else
                        {
                            model . Idx = bll . Add ( model );
                            if ( model . Idx <= 0 )
                            {
                                MessageBox . Show ( "生成R_344工资失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_344工资成功" );
                        }
                    }
                }
                #endregion

                #region R_344 厂内漆款  346厂内漆
                da = null;
                da = bll . GetDataTablePqmzes ( model . AN002 );
                if ( da != null && da . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        model . AN012 = "滚漆油漆成本采购合同书--厂内漆(R_344)";
                        model . AN013 = da . Rows [ i ] [ "MZ016" ] . ToString ( );
                        model . AN014 = "";
                        model . AN015 = string . IsNullOrEmpty ( da . Rows [ i ] [ "MZ021" ] . ToString ( ) ) == true ? 0M : Convert . ToDecimal ( da . Rows [ i ] [ "MZ021" ] . ToString ( ) );
                        model . AN016 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS10" ] . ToString ( ) ) == true ? 0M : Convert . ToDecimal ( da . Rows [ i ] [ "GS10" ] . ToString ( ) );
                        model . AN017 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS51" ] . ToString ( ) ) == true ? 0M : Convert . ToDecimal ( da . Rows [ i ] [ "GS51" ] . ToString ( ) );
                        model . AN018 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS04" ] . ToString ( ) ) == true ? 0M : Convert . ToDecimal ( da . Rows [ i ] [ "GS04" ] . ToString ( ) );
                        model . AN019 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PZ1" ] . ToString ( ) ) == true ? 0M : Convert . ToDecimal ( da . Rows [ i ] [ "PZ1" ] . ToString ( ) );
                        model . AN020 = 0M;
                        model . AN021 = string . IsNullOrEmpty ( da . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "idx" ] . ToString ( ) );
                        model . AN022 = 0M;
                        model . AN023 = da . Rows [ i ] [ "MZ031" ] . ToString ( );
                        model . AN024 = "";
                        model . AN025 = model . AN019 + model . AN020;

                        model . Idx = bll . idxExists ( model );
                        if ( model . Idx > 0 )
                        {
                            result = bll . UpdateOfPqw ( model );
                            if ( result == false )
                            {
                                MessageBox . Show ( "生成R_344厂内漆失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_344厂内漆成功" );
                        }
                        else
                        {
                            model . Idx = bll . Add ( model );
                            if ( model . Idx <= 0 )
                            {
                                MessageBox . Show ( "生成R_344厂内漆失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_344厂内漆成功" );
                        }
                    }
                }
                #endregion

                #region R_341
                da = null;
                da = bll . GetDataTablePqv ( model . AN002 );
                if ( da . Rows . Count > 0 )
                {
                    List<string> list = new List<string> ( );
                    List<string> lis = new List<string> ( );
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        model . AN012 = "木材采购合同书(R_341)";
                        model . AN013 = da . Rows [ i ] [ "PQV10" ] . ToString ( );
                        model . AN014 = da . Rows [ i ] [ "PQV68" ] . ToString ( ) + "*" + da . Rows [ i ] [ "PQV69" ] . ToString ( ) + "*" + da . Rows [ i ] [ "PQV70" ] . ToString ( );
                        model . AN015 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PQV12" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "PQV12" ] . ToString ( ) );
                        model . AN016 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS10" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GS10" ] . ToString ( ) );
                        //if ( list . Count > 0 )
                        //{
                        //    foreach ( string str in list )
                        //    {
                        //        if ( str . Equals ( da . Rows [ i ] [ "PQV86" ] . ToString ( ) . Trim ( ) ) )
                        //            model . AN017 = 0;
                        //        else
                        //        {
                        //            model . AN017 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS04" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GS04" ] . ToString ( ) );
                        //            lis . Add ( da . Rows [ i ] [ "PQV86" ] . ToString ( ) );
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        //    list . Add ( da . Rows [ i ] [ "PQV86" ] . ToString ( ) );
                        //    model . AN017 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS04" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GS04" ] . ToString ( ) );
                        //}
                        //foreach ( string s in lis )
                        //{
                        //    list . Add ( s );
                        //}
                        model . AN017 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS04" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GS04" ] . ToString ( ) );
                        model . AN018 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS11" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GS11" ] . ToString ( ) );
                        if ( da . Rows [ i ] [ "PQV88" ] . ToString ( ) . Trim ( ) . Equals ( "T" ) )
                        {
                            model . AN022 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U0" ] . ToString ( ) );
                            model . AN019 = 0;
                            model . AN020 = 0;
                        }
                        else
                        {
                            if ( da . Rows [ i ] [ "PQV65" ] . ToString ( ) . Trim ( ) . Equals ( "外购" ) )
                            {
                                model . AN019 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U0" ] . ToString ( ) );
                                model . AN020 = 0;
                            }
                            else
                            {
                                model . AN019 = 0;
                                model . AN020 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U0" ] . ToString ( ) );
                            }
                            model . AN022 = 0;
                        }
                        model . AN021 = string . IsNullOrEmpty ( da . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "idx" ] . ToString ( ) );
                        model . AN023 = da . Rows [ i ] [ "PQV05" ] . ToString ( );
                        model . AN025 = model . AN019 + model . AN020;


                        model . Idx = bll . idxExists ( model );
                        if ( model . Idx > 0 )
                        {
                            result = bll . UpdateOfPqw ( model );
                            if ( result == false )
                            {
                                MessageBox . Show ( "生成R_341失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                            {
                                list . Clear ( );
                                lis . Clear ( );
                                MessageBox . Show ( "生成R_341成功" );
                            }

                        }
                        else
                        {
                            model . Idx = bll . Add ( model );
                            if ( model . Idx <= 0 )
                            {
                                MessageBox . Show ( "生成R_341失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                            {
                                list . Clear ( );
                                lis . Clear ( );
                                MessageBox . Show ( "生成R_341成功" );
                            }
                        }
                    }
                }
                else
                    MessageBox . Show ( "R_341中没有流水号:" + model . AN002 + "的记录" );
                #endregion

                #region R_342
                da = null;
                da = bll . GetDataTablePqaf ( model . AN002 );
                if ( da . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        model . AN012 = "车木件采购合同(R_342)";
                        model . AN013 = da . Rows [ i ] [ "AF015" ] . ToString ( );
                        model . AN014 = da . Rows [ i ] [ "AF020" ] . ToString ( ) + "*" + da . Rows [ i ] [ "AF021" ] . ToString ( ) + "*" + da . Rows [ i ] [ "AF022" ] . ToString ( );
                        model . AN015 = string . IsNullOrEmpty ( da . Rows [ i ] [ "AF019" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "AF019" ] . ToString ( ) );
                        model . AN016 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS10" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GS10" ] . ToString ( ) );
                        model . AN017 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GS" ] . ToString ( ) );
                        model . AN018 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS11" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GS11" ] . ToString ( ) );
                        if ( da . Rows [ i ] [ "AF078" ] . ToString ( ) . Trim ( ) . Equals ( "T" ) )
                        {
                            model . AN022 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U0" ] . ToString ( ) );
                            model . AN019 = 0;
                            model . AN020 = 0;
                        }
                        else
                        {
                            if ( da . Rows [ i ] [ "AF016" ] . ToString ( ) . Trim ( ) . Equals ( "外购" ) )
                            {
                                model . AN019 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U0" ] . ToString ( ) );
                                model . AN020 = 0;
                            }
                            else
                            {
                                model . AN019 = 0;
                                model . AN020 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U0" ] . ToString ( ) );
                            }
                            model . AN022 = 0;
                        }
                        model . AN021 = string . IsNullOrEmpty ( da . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "idx" ] . ToString ( ) );
                        model . AN023 = da . Rows [ i ] [ "AF010" ] . ToString ( );
                        model . AN025 = model . AN019 + model . AN020;

                        model . Idx = bll . idxExists ( model );
                        if ( model . Idx > 0 )
                        {
                            result = bll . UpdateOfPqw ( model );
                            if ( result == false )
                            {
                                MessageBox . Show ( "生成R_342失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_342成功" );
                        }
                        else
                        {
                            model . Idx = bll . Add ( model );
                            if ( model . Idx <= 0 )
                            {
                                MessageBox . Show ( "生成R_342失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_342成功" );
                        }
                    }
                }
                else
                    MessageBox . Show ( "R_342中没有流水号:" + model . AN002 + "的记录" );
                #endregion

                #region R_343
                da = null;
                da = bll . GetDataTablePqu ( model . AN002 );
                if ( da . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        model . AN012 = "五金件(镀、烤漆)采购合同书(R_343)";
                        model . AN013 = da . Rows [ i ] [ "PQU10" ] . ToString ( );
                        model . AN014 = da . Rows [ i ] [ "PQU12" ] . ToString ( );
                        model . AN015 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PQU13" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "PQU13" ] . ToString ( ) );
                        model . AN016 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS10" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GS10" ] . ToString ( ) );
                        model . AN017 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GS" ] . ToString ( ) );
                        model . AN018 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS11" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GS11" ] . ToString ( ) );
                        if ( da . Rows [ i ] [ "PQU107" ] . ToString ( ) . Trim ( ) . Equals ( "T" ) )
                        {
                            model . AN022 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U0" ] . ToString ( ) );
                            model . AN019 = 0;
                            model . AN020 = 0;
                        }
                        else
                        {
                            if ( da . Rows [ i ] [ "PQU19" ] . ToString ( ) . Trim ( ) . Equals ( "外购" ) )
                            {
                                model . AN019 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U0" ] . ToString ( ) );
                                model . AN020 = 0;
                            }
                            else
                            {
                                model . AN019 = 0;
                                model . AN020 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U0" ] . ToString ( ) );
                            }
                            model . AN022 = 0;
                        }
                        model . AN021 = string . IsNullOrEmpty ( da . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "idx" ] . ToString ( ) );
                        model . AN023 = da . Rows [ i ] [ "PQU05" ] . ToString ( );
                        model . AN025 = model . AN019 + model . AN020;

                        model . Idx = bll . idxExists ( model );
                        if ( model . Idx > 0 )
                        {
                            result = bll . UpdateOfPqw ( model );
                            if ( result == false )
                            {
                                MessageBox . Show ( "生成R_343失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_343成功" );
                        }
                        else
                        {
                            model . Idx = bll . Add ( model );
                            if ( model . Idx <= 0 )
                            {
                                MessageBox . Show ( "生成R_343失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_343成功" );
                        }
                    }
                }
                else
                    MessageBox . Show ( "R_343中没有流水号:" + model . AN002 + "的记录" );
                #endregion

                #region R_347
                da = null;
                da = bll . GetDataTablePqs ( model . AN002 );
                if ( da . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        model . AN012 = "产品塑料、布和其他零配件采购合同(R_347)";
                        model . AN013 = da . Rows [ i ] [ "PJ09" ] . ToString ( );
                        model . AN014 = da . Rows [ i ] [ "PJ89" ] . ToString ( );
                        model . AN015 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PJ11" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "PJ11" ] . ToString ( ) );
                        model . AN016 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS10" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GS10" ] . ToString ( ) );
                        model . AN017 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS51" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GS51" ] . ToString ( ) );
                        model . AN018 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS04" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GS04" ] . ToString ( ) );
                        if ( da . Rows [ i ] [ "PJ100" ] . ToString ( ) . Trim ( ) . Equals ( "T" ) )
                        {
                            model . AN022 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U0" ] . ToString ( ) );
                            model . AN019 = 0;
                            model . AN020 = 0;
                        }
                        else
                        {
                            if ( da . Rows [ i ] [ "PJ15" ] . ToString ( ) . Trim ( ) . Equals ( "外购" ) )
                            {
                                model . AN019 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U0" ] . ToString ( ) );
                                model . AN020 = 0;
                            }
                            else
                            {
                                model . AN019 = 0;
                                model . AN020 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U0" ] . ToString ( ) );
                            }
                            model . AN022 = 0;
                        }
                        model . AN021 = string . IsNullOrEmpty ( da . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "idx" ] . ToString ( ) );
                        model . AN023 = da . Rows [ i ] [ "PJ04" ] . ToString ( );
                        model . AN025 = model . AN019 + model . AN020;

                        model . Idx = bll . idxExists ( model );
                        if ( model . Idx > 0 )
                        {
                            result = false;
                            result = bll . UpdateOfPqw ( model );
                            if ( result == false )
                            {
                                MessageBox . Show ( "生成R_347失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_347成功" );
                        }
                        else
                        {
                            model . Idx = bll . Add ( model );
                            if ( model . Idx <= 0 )
                            {
                                MessageBox . Show ( "生成R_347失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_347成功" );
                        }
                    }
                }
                else
                    MessageBox . Show ( "R_347中没有流水号:" + model . AN002 + "的记录" );
                #endregion

                #region R_348
                da = null;
                da = bll . GetDataTablePqoz ( model . AN002 );
                if ( da != null && da . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        model . AN012 = "R_349合并流水号拆分(R_348)";
                        model . AN013 = "外箱";
                        model . AN014 = "";
                        model . AN015 = 0;
                        model . AN016 = 0;
                        model . AN017 = 0;
                        model . AN018 = 0;
                        if ( da . Rows [ i ] [ "WX90" ] . ToString ( ) . Equals ( "T" ) )
                        {
                            model . AN022 = string . IsNullOrEmpty ( da . Rows [ i ] [ "OZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "OZ" ] . ToString ( ) );
                            model . AN019 = 0;
                            model . AN020 = 0;
                        }
                        else
                        {
                            model . AN019 = string . IsNullOrEmpty ( da . Rows [ i ] [ "OZ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "OZ" ] . ToString ( ) );
                            model . AN020 = 0;
                            model . AN022 = 0;
                        }
                        model . AN021 = 0;
                        model . AN023 = da . Rows [ i ] [ "WX05" ] . ToString ( );
                        model . AN025 = model . AN019 + model . AN020;


                        model . Idx = bll . idxExists ( model );
                        if ( model . Idx > 0 )
                        {
                            result = bll . UpdateOfPqw ( model );
                            if ( result == false )
                            {
                                MessageBox . Show ( "生成R_348失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_348成功" );
                        }
                        else
                        {
                            model . Idx = bll . Add ( model );
                            if ( model . Idx <= 0 )
                            {
                                MessageBox . Show ( "生成R_348失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_348成功" );
                        }
                    }
                }
                else
                    MessageBox . Show ( "R_348中没有流水号:" + model . AN002 + "的记录" );
                #endregion

                #region R_349
                da = null;
                da = bll . GetDataTablePqt ( model . AN002 );
                if ( da . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        model . AN012 = "外箱、中包、彩盒、纸片（卡）等采购合同(R_349)";
                        model . AN013 = da . Rows [ i ] [ "WX10" ] . ToString ( );
                        model . AN014 = da . Rows [ i ] [ "WX11" ] . ToString ( );
                        model . AN015 = string . IsNullOrEmpty ( da . Rows [ i ] [ "WX14" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "WX14" ] . ToString ( ) );
                        model . AN016 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS59" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GS59" ] . ToString ( ) );
                        model . AN017 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS53" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GS53" ] . ToString ( ) );
                        model . AN018 = string . IsNullOrEmpty ( da . Rows [ i ] [ "GS61" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "GS61" ] . ToString ( ) );
                        if ( da . Rows [ i ] [ "WX90" ] . ToString ( ) . Trim ( ) . Equals ( "T" ) )
                        {
                            model . AN022 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PQ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "PQ" ] . ToString ( ) );
                            model . AN019 = 0;
                            model . AN020 = 0;
                        }
                        else
                        {
                            if ( da . Rows [ i ] [ "WX17" ] . ToString ( ) . Trim ( ) . Equals ( "外购" ) )
                            {
                                model . AN019 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PQ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "PQ" ] . ToString ( ) );
                                model . AN020 = 0;
                            }
                            else
                            {
                                model . AN019 = 0;
                                model . AN020 = string . IsNullOrEmpty ( da . Rows [ i ] [ "PQ" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "PQ" ] . ToString ( ) );
                            }
                            model . AN022 = 0;
                        }

                        model . AN021 = string . IsNullOrEmpty ( da . Rows [ i ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( da . Rows [ i ] [ "idx" ] . ToString ( ) );
                        model . AN023 = da . Rows [ i ] [ "WX05" ] . ToString ( );
                        model . AN025 = model . AN019 + model . AN020;


                        model . Idx = bll . idxExists ( model );
                        if ( model . Idx > 0 )
                        {
                            result = bll . UpdateOfPqw ( model );
                            if ( result == false )
                            {
                                MessageBox . Show ( "生成R_349失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_349成功" );
                        }
                        else
                        {
                            model . Idx = bll . Add ( model );
                            if ( model . Idx <= 0 )
                            {
                                MessageBox . Show ( "生成R_349失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_349成功" );
                        }
                    }
                }
                else
                    MessageBox . Show ( "R_349中没有流水号:" + model . AN002 + "的记录" );
                #endregion

                #region R_495
                da = null;
                da = bll . GetDataTablePqy ( model . AN002 );
                if ( da . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        model . AN012 = "喷油漆承揽生产加工合同(R_495)";
                        model . AN013 = "喷漆";
                        model . AN014 = "";
                        model . AN015 = 0;
                        model . AN016 = 0;
                        model . AN017 = 0;
                        model . AN018 = 0;
                        model . AN019 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U1" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U1" ] . ToString ( ) );
                        model . AN020 = 0;
                        model . AN021 = 0;
                        model . AN022 = 0;
                        model . AN023 = da . Rows [ i ] [ "PY06" ] . ToString ( );
                        model . AN024 = "";
                        model . AN025 = model . AN019 + model . AN020;

                        model . Idx = bll . idxExists ( model );
                        if ( model . Idx > 0 )
                        {
                            result = bll . UpdateContract ( model );
                            if ( result == false )
                            {
                                MessageBox . Show ( "生成R_495失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_495成功" );
                        }
                        else
                        {
                            model . Idx = bll . Add ( model );
                            if ( model . Idx <= 0 )
                            {
                                MessageBox . Show ( "生成R_495失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_495成功" );
                        }
                    }
                }
                else
                    MessageBox . Show ( "R_495中没有流水号:" + model . AN002 + "的记录" );
                #endregion

                #region R_505
                da = null;
                da = bll . GetDataTablePqiz ( model . AN002 );
                if ( da . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < da . Rows . Count ; i++ )
                    {
                        model . AN012 = "断料、平刨、压刨、夹料、叠料、清理承揽加工合同(R_505)";
                        model . AN013 = "夹料";
                        model . AN014 = "";
                        model . AN015 = 0;
                        model . AN016 = 0;
                        model . AN017 = 0;
                        model . AN018 = 0;
                        model . AN019 = string . IsNullOrEmpty ( da . Rows [ i ] [ "U0" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( da . Rows [ i ] [ "U0" ] . ToString ( ) );
                        model . AN020 = 0;
                        model . AN021 = 0;
                        model . AN022 = 0;
                        model . AN023 = da . Rows [ i ] [ "IZ006" ] . ToString ( );
                        model . AN024 = "";
                        model . AN025 = model . AN019 + model . AN020;

                        model . Idx = bll . idxExists ( model );
                        if ( model . Idx > 0 )
                        {
                            result = bll . UpdateContract ( model );
                            if ( result == false )
                            {
                                MessageBox . Show ( "生成R_505失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_505成功" );
                        }
                        else
                        {
                            model . Idx = bll . Add ( model );
                            if ( model . Idx <= 0 )
                            {
                                MessageBox . Show ( "生成R_505失败" );
                                break;
                            }
                            else if ( i == da . Rows . Count - 1 )
                                MessageBox . Show ( "生成R_505成功" );
                        }
                    }
                }
                #endregion

            }

            strWhere = "1=1";
            strWhere = strWhere + " AND AN001='" + model . AN001 + "'";
            button6_Click ( null ,null );
        }
        //Build
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox3.Text ) )
                MessageBox.Show( "流水号不可为空" );
            else
            {
                variable( );
                otherVariable( );
                model.Idx = bll.Add( model );
                if ( model.Idx > 0 )
                {
                    MessageBox.Show( "录入数据成功" );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND AN001='" + model.AN001 + "'";
                    refresh( );
                }
                else
                    MessageBox.Show( "录入数据失败" );
            }
        }
        //Eidt
        private void button4_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox3.Text ) )
                MessageBox.Show( "流水号不可为空" );
            else
            {
                variable( );
                otherVariable( );
                result = false;
                result = bll.Update( model );
                if ( result == true )
                {
                    MessageBox.Show( "编辑数据成功" );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND AN001='" + model.AN001 + "'";
                    refresh( );
                }
                else
                    MessageBox.Show( "编辑数据失败" );
            }
        }
        //Delete
        private void button5_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==  DialogResult . Cancel )
                return;
            if ( string.IsNullOrEmpty( textBox3.Text ) )
                MessageBox.Show( "流水号不可为空" );
            else
            {
                result = false;
                result = bll.Delete( model );
                if ( result == true )
                {
                    MessageBox.Show( "删除数据成功" );
                    //queryTable.Rows.Remove( queryTable.Select( "idx='" + model.Idx + "'" )[0] );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND AN001='" + model.AN001 + "'";
                    refresh( );
                }
                else
                    MessageBox.Show( "删除数据失败" );
            }
        }
        //Refresh
        private void button6_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND AN001='" + model.AN001 + "'";
            refresh( );
        }
        void refresh ( )
        {
            if ( string.IsNullOrEmpty( strWhere ) )
                strWhere = "1=1";
            queryTable = bll.GetDataTable( strWhere );
            gridControl1.DataSource = queryTable;

            if ( queryTable != null && queryTable . Rows . Count > 0 )
            {
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Custom ,"U2" ,bandedGridView1 . Columns [ "U2" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Custom ,"U3" ,bandedGridView1 . Columns [ "U3" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Custom ,"U4" ,bandedGridView1 . Columns [ "U4" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Custom ,"U6" ,bandedGridView1 . Columns [ "U6" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Custom ,"U7" ,bandedGridView1 . Columns [ "U7" ] ,"{0}" );
                bandedGridView1 . GroupSummary . Add ( DevExpress . Data . SummaryItemType . Custom ,"U9" ,bandedGridView1 . Columns [ "U9" ] ,"{0}" );

                bandedGridView1 . ExpandAllGroups ( );

                AN017 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "U1" ] . SummaryItem . SummaryValue ) / Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "AN006" ] ) ,2 ) . ToString ( ) );
                U2 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "AN019" ] . SummaryItem . SummaryValue ) / Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "AN006" ] ) ,2 ) . ToString ( ) );
                AN006 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,bandedGridView1 . GetDataRow ( 0 ) [ "AN006" ] . ToString ( ) );
                U3 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "AN020" ] . SummaryItem . SummaryValue ) / Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "AN006" ] ) ,2 ) . ToString ( ) );
                U4 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "AN025" ] . SummaryItem . SummaryValue ) / Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "AN006" ] ) ,2 ) . ToString ( ) );
                U6 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "AN022" ] . SummaryItem . SummaryValue ) / Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "AN006" ] ) ,2 ) . ToString ( ) );
                U7 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "U5" ] . SummaryItem . SummaryValue ) / Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "AN006" ] ) ,2 ) . ToString ( ) );
                U9 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "U8" ] . SummaryItem . SummaryValue ) / Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "AN006" ] ) ,2 ) . ToString ( ) );

                for ( int i = 0 ; i < queryTable . Rows . Count ; i++ )
                {
                    if ( bandedGridView1 . GetDataRow ( i ) [ "AN012" ] . ToString ( ) == "胶合板、密度板采购合同书(R_338)" || bandedGridView1 . GetDataRow ( i ) [ "AN012" ] . ToString ( ) == "木材采购合同书(R_341)" )
                    {
                        if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "AN017" ] . ToString ( ) ) && !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "AN006" ] . ToString ( ) ) )
                            bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U1" ] ,Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "AN017" ] . ToString ( ) ) * Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "AN006" ] . ToString ( ) ) );
                        else
                            bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U1" ] ,0 );
                    }
                    else
                    {
                        if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "AN006" ] . ToString ( ) ) && !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "AN018" ] . ToString ( ) ) && !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "AN015" ] . ToString ( ) ) )
                            bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U1" ] ,Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "AN006" ] . ToString ( ) ) * Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "AN018" ] . ToString ( ) ) * Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "AN015" ] . ToString ( ) ) );
                        else
                            bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U1" ] ,0 );
                    }
                }
            }
        }
        #endregion

        #region Query
        SelectAll.ChengBenYuSuanAll query = new SelectAll.ChengBenYuSuanAll( );
        protected override void select ( )
        {
            base.select( );

            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.ChengBenYuSuanAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );

            if ( string.IsNullOrEmpty( model.AN001 ) )
                MessageBox.Show( "您没有选择任何内容" );
            else
            {
                strWhere = "1=1";
                strWhere = strWhere + " AND AN001='" + model.AN001 + "'";
                button6_Click( null ,null );
                assignMents( );

                toolAdd.Enabled = toolSelect.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolPrint.Enabled = toolReview.Enabled = toolExport.Enabled = toolMaintain.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
            }
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            model.AN001 = e.ConOne;
        }
        void assignMents ( )
        {
            if ( queryTable.Rows.Count > 0 )
            {
                model = bll.DataRowModel( queryTable.Select( "AN001='" + model.AN001 + "'" )[0] );
                textBox1.Text = model.AN003;
                textBox3.Text = model.AN002;
                textBox2.Text = model.AN004;
                textBox4.Text = model.AN005;
                textBox5.Text = model.AN006.ToString( );
                textBox6.Text = model.AN007;
                if ( !string.IsNullOrEmpty( model.AN008.ToString( ) ) )
                    dateTimePicker1.Value = model.AN008;
                if ( !string.IsNullOrEmpty( model.AN009.ToString( ) ) )
                    dateTimePicker2.Value = model.AN009;
                if ( !string.IsNullOrEmpty( model.AN010.ToString( ) ) )
                    dateTimePicker3.Value = model.AN010;
                textBox7.Text = model.AN011;
            }
        }
        R_Frm001 frmSele = new R_Frm001( );
        private void button1_Click ( object sender ,EventArgs e )
        {
            DataTable de = bll.GetDataTableRpqaf( );
            if ( de.Rows.Count > 0 )
            {
                frmSele.gridControl1.DataSource = de;
                frmSele.Text = "R_240 信息查询";
                frmSele.StartPosition = FormStartPosition.CenterScreen;
                frmSele.PassDataBetweenForm += new R_Frm001.PassDataBetweenFormHandler( frmSele_PassDataBetweenForm );
                frmSele.ShowDialog( );
            }

            if ( string.IsNullOrEmpty( model.AN002 ) )
                MessageBox.Show( "您没有选择任何内容" );
            else
            {
                DataTable df = bll.GetDataTableRpqafQuery( model.AN002 );
                if ( df.Rows.Count > 0 )
                {
                    textBox1.Text = df.Rows[0]["PQF04"].ToString( );
                    textBox2.Text = df.Rows[0]["PQF02"].ToString( );
                    textBox4.Text = df.Rows[0]["PQF03"].ToString( );
                    textBox5.Text = df.Rows[0]["PQF06"].ToString( );
                    dateTimePicker1.Value = string.IsNullOrEmpty( df.Rows[0]["PQF31"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( df.Rows[0]["PQF31"].ToString( ) );
                    dateTimePicker2.Value = string.IsNullOrEmpty( df.Rows[0]["PQF13"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( df.Rows[0]["PQF13"].ToString( ) );
                    textBox7.Text = df.Rows[0]["DAA002"].ToString( );
                }
            }
        }
        private void frmSele_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            model.AN002 = e.ConOne;
            textBox3.Text = e.ConOne;
        }
        #endregion

    }
}
