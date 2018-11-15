using Mulaolao . Class;
using System;
using System . Collections;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;
using System . Threading;

namespace Mulaolao . Summary
{
    public partial class R_FrmProductCostSummary : FormChild
    {
        public R_FrmProductCostSummary ( )
        {
            InitializeComponent( );
            
            listSuper( );
            textBoxKeypress( );
            MulaolaoBll . UserInfoMation . tableName = this . Name;


            
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { bandedGridView1 ,bandedGridView10 ,bandedGridView11 ,bandedGridView12 ,bandedGridView13 ,bandedGridView2 ,bandedGridView3 ,bandedGridView4 ,bandedGridView5 ,bandedGridView6 ,bandedGridView7 ,bandedGridView8 ,bandedGridView9 } );

            List<DevExpress . XtraGrid . Views . BandedGrid . BandedGridView> bandList = new List<DevExpress . XtraGrid . Views . BandedGrid . BandedGridView> ( );
            bandList . AddRange ( new DevExpress . XtraGrid . Views . BandedGrid . BandedGridView [ ] { bandedGridView1 ,bandedGridView10 ,bandedGridView11 ,bandedGridView12 ,bandedGridView13 ,bandedGridView2 ,bandedGridView3 ,bandedGridView4 ,bandedGridView5 ,bandedGridView6 ,bandedGridView7 ,bandedGridView8 ,bandedGridView9 } );
            foreach ( DevExpress . XtraGrid . Views . BandedGrid . BandedGridView band in bandList )
            {
                GridViewMoHuSelect . SetFilter ( band );
            }
        }
        
        MulaolaoBll.Bll.ProductCostSummaryBll bll = new MulaolaoBll.Bll.ProductCostSummaryBll( );
        MulaolaoLibrary.ProductCostSummaryLibrary model = new MulaolaoLibrary.ProductCostSummaryLibrary( );
        
        string sign = "", strWhere = "1=1";
        bool result = false;
        DataTable queryTable;
        int num = 0;
        List<string> list = new List<string>( );
        List<TextBox> listBox = new List<TextBox>( );
        string signQuery = "";
        
        private void R_FrmProductCostSummary_Load ( object sender ,EventArgs e )
        {
            Power( this );
            Ergodic.FormEvery( this );
            gridControlDataToNull( );
            Ergodic.FormEverySpliEnableFalse( this );

            progressBar1 . Visible = false;
        }
        
        #region Main     
        protected override void delete ( )
        {
            base.delete( );

            string idList = "''";
            for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
            {
                idList = idList + "," +"'"+ bandedGridView1.GetDataRow( i )["idx"].ToString( ) + "'";
            }
            result = bll.DeleteList( idList );
            if ( result == true )
            {
                Ergodic.FormEvery( this );
                gridControlDataToNull( );
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

            Ergodic.FormEverySpliEnableTrue( this );
            toolAdd.Enabled = toolSelect.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolPrint.Enabled = toolReview.Enabled = toolExport.Enabled = toolMaintain.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void add ( )
        {
            base.add( );

            Ergodic.FormEvery( this );
            gridControlDataToNull( );
            Ergodic.FormEverySpliEnableTrue( this );
            sign = "1";
            model.AM001 = oddNumbers.purchaseContract( "SELECT MAX(AJ024) AJ024 FROM R_PQAJ" ,"AJ024" ,"R_241-" );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void save ( )
        {
            base.save( );

            if ( progressBar1 . Visible == true )
            {
                MessageBox . Show ( "正在生成数据,不允许保存" );
                return;
            }

            Ergodic .FormEverySpliEnableFalse( this );
            toolAdd.Enabled = toolSelect.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolPrint.Enabled = toolReview.Enabled = toolExport.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = toolMaintain.Enabled = false;
        }
        protected override void cancel ( )
        {
            base.cancel( );

            if ( progressBar1 . Visible == true )
            {
                MessageBox . Show ( "正在生成数据,不允许终止" );
                return;
            }

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
                finally {
                    Ergodic.FormEvery( this );
                    gridControlDataToNull( );
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
            //ViewExport . ExportToExcel ( this . Text ,gridControl1 ,gridControl2 ,gridControl3 ,gridControl4 ,gridControl5 ,gridControl6 ,gridControl7 ,gridControl8 ,gridControl9 ,gridControl10 ,gridControl11 ,gridControl12 ,gridControl13 );

            //GridControl [ ] gc = new GridControl [ ] { gridControl1 ,gridControl2 ,gridControl3 ,gridControl4 ,gridControl5 ,gridControl6 ,gridControl7 ,gridControl8 ,gridControl9 ,gridControl10 ,gridControl11 ,gridControl12 ,gridControl13 };

            //foreach ( GridControl g in gc )
            //{
            //    ViewExport . ExportToExcel ( this . Text ,g );
            //}

            if ( tabControl1 . SelectedTab . Name == "tabPage1" )
                ViewExport . ExportToExcel ( this . Text + this . tabPage1 . Text ,gridControl1 );
            if ( tabControl1 . SelectedTab . Name == "tabPage2" )
                ViewExport . ExportToExcel ( this . Text + this . tabPage2 . Text ,gridControl2 );
            if ( tabControl1 . SelectedTab . Name == "tabPage3" )
                ViewExport . ExportToExcel ( this . Text + this . tabPage3 . Text ,gridControl3 );
            if ( tabControl1 . SelectedTab . Name == "tabPage4" )
                ViewExport . ExportToExcel ( this . Text + this . tabPage4 . Text ,gridControl4 );
            if ( tabControl1 . SelectedTab . Name == "tabPage5" )
                ViewExport . ExportToExcel ( this . Text + this . tabPage5 . Text ,gridControl5 );
            if ( tabControl1 . SelectedTab . Name == "tabPage6" )
                ViewExport . ExportToExcel ( this . Text + this . tabPage6 . Text ,gridControl6 );
            if ( tabControl1 . SelectedTab . Name == "tabPage7" )
                ViewExport . ExportToExcel ( this . Text + this . tabPage7 . Text ,gridControl7 );
            if ( tabControl1 . SelectedTab . Name == "tabPage8" )
                ViewExport . ExportToExcel ( this . Text + this . tabPage8 . Text ,gridControl8 );
            if ( tabControl1 . SelectedTab . Name == "tabPage9" )
                ViewExport . ExportToExcel ( this . Text + this . tabPage9 . Text ,gridControl9 );
            if ( tabControl1 . SelectedTab . Name == "tabPage10" )
                ViewExport . ExportToExcel ( this . Text + this . tabPage10 . Text ,gridControl10 );
            if ( tabControl1 . SelectedTab . Name == "tabPage11" )
                ViewExport . ExportToExcel ( this . Text + this . tabPage11 . Text ,gridControl11 );
            if ( tabControl1 . SelectedTab . Name == "tabPage12" )
                ViewExport . ExportToExcel ( this . Text + this . tabPage12 . Text ,gridControl12 );
            if ( tabControl1 . SelectedTab . Name == "tabPage13" )
                ViewExport . ExportToExcel ( this . Text + this . tabPage13 . Text ,gridControl13 );

            base . export ( );
        }
        #endregion

        #region Table
        void variable ( )
        {
            model.AM002 = textBox4.Text;
            model.AM003 = textBox3.Text;
            model.AM004 = textBox5.Text;
            model.AM005 = textBox6.Text;
            long count = 0;
            long.TryParse( string.IsNullOrEmpty( textBox7.Text ) ? "0" : textBox7.Text ,out count );
            model.AM006 = count;
            if ( !string . IsNullOrEmpty ( textBox25 . Text ) )
                model . AM007 = Convert . ToDateTime ( textBox25 . Text );
            else
                model . AM007 = null;
            model.AM008 = textBox13.Text;
            model.AM009 = textBox1.Text;
            model.AM010 = textBox9.Text;
            model.AM011 = textBox10.Text;
            model.AM012 = textBox11.Text;
            model.AM013 = textBox14.Text;
            model.AM014 = textBox15.Text;
            count = 0;
            long.TryParse( string.IsNullOrEmpty( textBox8.Text ) ? "0" : textBox8.Text ,out count );
            model.AM015 = count;
            decimal unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox12.Text ) ? "0" : textBox12.Text ,out unitPrice );
            model.AM016 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox16.Text ) ? "0" : textBox16.Text ,out unitPrice );
            model.AM017 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox17.Text ) ? "0" : textBox17.Text ,out unitPrice );
            model.AM018 = unitPrice;
            unitPrice = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox18.Text ) ? "0" : textBox18.Text ,out unitPrice );
            model.AM019 = unitPrice;
        }
        //Build
        private void button2_Click ( object sender ,EventArgs e )
        {
            build( );
        }     
        //Edit
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox3.Text ) )
                MessageBox.Show( "请选择产品" );
            else
            {
                variable( );
                result = bll.Update( model );
                if ( result == true )
                {
                    MessageBox.Show( "编辑成功" );
                }
                else
                {
                    MessageBox.Show( "编辑失败" );
                }
            }
        }
        private void button8_Click ( object sender ,EventArgs e )
        {
            if ( model.Idx > 0 )
            {
                signQuery = "";
                SelectAll.ProductAgentFeeAll agentFee = new SelectAll.ProductAgentFeeAll( );
                agentFee.PassDataBetweenForm += new SelectAll.ProductAgentFeeAll.PassDataBetweenFormHandler( agentFee_PassDataBetweenForm );
                agentFee.StartPosition = FormStartPosition.CenterScreen;
                agentFee.id = model.Idx;
                agentFee.ShowDialog( );
                if ( signQuery == "1" )
                {
                    if ( result == true )
                    {
                        MessageBox.Show( "编辑成功" );
                        agentFeeEdit( );
                    }
                    else
                        MessageBox.Show( "编辑失败" );
                }
            }
        }
        private void agentFee_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( e.ConTwo == "1" )
            {
                signQuery = "1";
                result = e.ConOne == "1" ? true : false;
            }
            else
                signQuery = "";
        }
        void agentFeeEdit ( )
        {
            DataRow row = queryTable.Rows[bandedGridView3.FocusedRowHandle];
            row.BeginEdit( );
            row["AM020"] = model.AM020;
            row["AM021"] = model.AM021;
            row["AM022"] = model.AM022;
            row["AM023"] = model.AM023;
            row["AM024"] = model.AM024;
            row["AM025"] = model.AM025;
            row["AM026"] = model.AM026;
            row["AM027"] = model.AM027;
            row["AM028"] = model.AM028;
            row["AM029"] = model.AM029;
            row.EndEdit( );
        }
        private void button12_Click ( object sender ,EventArgs e )
        {
            if ( model.Idx > 0 )
            {
                signQuery = "";
                SelectAll.ProductBeforeAndAfterRoadWagesAll beforeAndAfterRoadWages = new SelectAll.ProductBeforeAndAfterRoadWagesAll( );
                beforeAndAfterRoadWages.PassDataBetweenForm += new SelectAll.ProductBeforeAndAfterRoadWagesAll.PassDataBetweenFormHandler( agentFee_PassDataBetweenForm );
                beforeAndAfterRoadWages.StartPosition = FormStartPosition.CenterScreen;
                beforeAndAfterRoadWages.id = model.Idx;
                beforeAndAfterRoadWages.ShowDialog( );
                if ( signQuery == "1" )
                {
                    if ( result == true )
                    {
                        MessageBox.Show( "编辑成功" );
                        beforeAndAfterRoadWagesEdit( );
                    }
                    else
                        MessageBox.Show( "编辑失败" );
                }
            }
        }
        void beforeAndAfterRoadWagesEdit ( )
        {
            DataRow row = queryTable.Rows[bandedGridView4.FocusedRowHandle];
            row.BeginEdit( );
            row["AM044"] = model.AM044;
            row["AM045"] = model.AM045;
            row["AM046"] = model.AM046;
            row["AM047"] = model.AM047;
            row["AM048"] = model.AM048;
            row["AM049"] = model.AM049;
            row["AM050"] = model.AM050;
            row["AM051"] = model.AM051;
            row["AM052"] = model.AM052;
            row["AM053"] = model.AM053;
            row["AM054"] = model.AM054;
            row["AM055"] = model.AM055;
            row["AM056"] = model.AM056;
            row["AM057"] = model.AM057;
            row["AM058"] = model.AM058;
            row["AM059"] = model.AM059;
            row["AM060"] = model.AM060;
            row["AM061"] = model.AM061;
            row.EndEdit( );
        }
        private void button16_Click ( object sender ,EventArgs e )
        {
            if ( model.Idx > 0 )
            {
                signQuery = "";
                SelectAll.ProductContractProcessAll contractProcess = new SelectAll.ProductContractProcessAll( );
                contractProcess.PassDataBetweenForm += new SelectAll.ProductContractProcessAll.PassDataBetweenFormHandler( agentFee_PassDataBetweenForm );
                contractProcess.StartPosition = FormStartPosition.CenterScreen;
                contractProcess.id = model.Idx;
                contractProcess.ShowDialog( );
                if ( signQuery == "1" )
                {
                    if ( result == true )
                    {
                        MessageBox.Show( "编辑成功" );
                        contractProcessEdit( );
                    }
                    else
                        MessageBox.Show( "编辑失败" );
                }
            }
        }
        void contractProcessEdit ( )
        {
            DataRow row = queryTable.Rows[bandedGridView5.FocusedRowHandle];
            row.BeginEdit( );
            row["AM070"] = model.AM070;
            row["AM071"] = model.AM071;
            row["AM072"] = model.AM072;
            row["AM073"] = model.AM073;
            row["AM074"] = model.AM074;
            row["AM075"] = model.AM075;
            row["AM076"] = model.AM076;
            row["AM077"] = model.AM077;
            row["AM078"] = model.AM078;
            row["AM079"] = model.AM079;
            row["AM080"] = model.AM080;
            row["AM081"] = model.AM081;
            row["AM082"] = model.AM082;
            row["AM083"] = model.AM083;
            row["AM084"] = model.AM084;
            row["AM085"] = model.AM085;
            row["AM086"] = model.AM086;
            row["AM087"] = model.AM087;
            row["AM088"] = model.AM088;
            row["AM089"] = model.AM089;
            row["AM090"] = model.AM090;
            row["AM091"] = model.AM091;
            row["AM092"] = model.AM092;
            row["AM093"] = model.AM093;
            row.EndEdit( );
        }
        private void button20_Click ( object sender ,EventArgs e )
        {
            if ( model.Idx > 0 )
            {
                signQuery = "";
                SelectAll.ProductFinishedProductOutsourcingAll finishedProductOutsourcing = new SelectAll.ProductFinishedProductOutsourcingAll( );
                finishedProductOutsourcing.id = model.Idx;
                finishedProductOutsourcing.PassDataBetweenForm += new SelectAll.ProductFinishedProductOutsourcingAll.PassDataBetweenFormHandler( agentFee_PassDataBetweenForm );
                finishedProductOutsourcing.StartPosition = FormStartPosition.CenterScreen;
                finishedProductOutsourcing.ShowDialog( );
                if ( signQuery == "1" )
                {
                    if ( result == true )
                    {
                        MessageBox.Show( "编辑成功" );
                        finishedProductOutsourcingEdit( );
                    }
                    else
                        MessageBox.Show( "编辑失败" );
                }
            }
        }
        void finishedProductOutsourcingEdit ( )
        {
            DataRow row = queryTable.Rows[bandedGridView6.FocusedRowHandle];
            row.BeginEdit( );
            row["AM108"] = model.AM108;
            row["AM109"] = model.AM109;
            row["AM110"] = model.AM110;
            row["AM111"] = model.AM111;
            row["AM112"] = model.AM112;
            row["AM113"] = model.AM113;
            row.EndEdit( );
        }
        private void button24_Click ( object sender ,EventArgs e )
        {
            if ( model.Idx > 0 )
            {
                signQuery = "";
                SelectAll.ProductPackageMaterialAll packageMaterial = new SelectAll.ProductPackageMaterialAll( );
                packageMaterial.id = model.Idx;
                packageMaterial.PassDataBetweenForm += new SelectAll.ProductPackageMaterialAll.PassDataBetweenFormHandler( agentFee_PassDataBetweenForm );
                packageMaterial.StartPosition = FormStartPosition.CenterScreen;
                packageMaterial.ShowDialog( );
                if ( signQuery == "1" )
                {
                    if ( result == true )
                    {
                        MessageBox.Show( "编辑成功" );
                        packageMaterialEdit( );
                    }
                    else
                        MessageBox.Show( "编辑失败" );
                }
            }
        }
        void packageMaterialEdit ( )
        {
            DataRow row = queryTable.Rows[bandedGridView7.FocusedRowHandle];
            row.BeginEdit( );
            row["AM136"] = model.AM136;
            row["AM137"] = model.AM137;
            row["AM138"] = model.AM138;
            row["AM139"] = model.AM139;
            row["AM140"] = model.AM140;
            row["AM141"] = model.AM141;
            row["AM142"] = model.AM142;
            row["AM143"] = model.AM143;
            row["AM144"] = model.AM144;
            row["AM145"] = model.AM145;
            row["AM146"] = model.AM146;
            row["AM147"] = model.AM147;
            row["AM148"] = model.AM148;
            row["AM149"] = model.AM149;
            row["AM150"] = model.AM150;
            row["AM151"] = model.AM151;
            row["AM152"] = model.AM152;
            row["AM153"] = model.AM153;
            row.EndEdit( );
        }
        private void button28_Click ( object sender ,EventArgs e )
        {
            if ( model.Idx > 0 )
            {
                signQuery = "";
                SelectAll.ProductPaintAll paint = new SelectAll.ProductPaintAll( );
                paint.id = model.Idx;
                paint.StartPosition = FormStartPosition.CenterScreen;
                paint.PassDataBetweenForm += new SelectAll.ProductPaintAll.PassDataBetweenFormHandler( agentFee_PassDataBetweenForm );
                paint.ShowDialog( );
                if ( signQuery == "1" )
                {
                    if ( result == true )
                    {
                        MessageBox.Show( "编辑成功" );
                        paintEdit( );
                    }
                    else
                        MessageBox.Show( "编辑失败" );
                }
            }
        }
        void paintEdit ( )
        {
            DataRow row = queryTable.Rows[bandedGridView8.FocusedRowHandle];
            row.BeginEdit( );
            row["AM175"] = model.AM175;
            row["AM176"] = model.AM176;
            row["AM177"] = model.AM177;
            row["AM178"] = model.AM178;
            row["AM179"] = model.AM179;
            row["AM180"] = model.AM180;
            row["AM181"] = model.AM181;
            row["AM182"] = model.AM182;
            row["AM183"] = model.AM183;
            row["AM184"] = model.AM184;
            row["AM185"] = model.AM185;
            row["AM186"] = model.AM186;
            row["AM187"] = model.AM187;
            row.EndEdit( );
        }
        private void button32_Click ( object sender ,EventArgs e )
        {
            if ( model.Idx > 0 )
            {
                signQuery = "";
                SelectAll.ProductLron lron = new SelectAll.ProductLron( );
                lron.id = model.Idx;
                lron.StartPosition = FormStartPosition.CenterScreen;
                lron.PassDataBetweenForm += new SelectAll.ProductLron.PassDataBetweenFormHandler( agentFee_PassDataBetweenForm );
                lron.num = textBox4.Text;
                lron.ShowDialog( );
                if ( signQuery == "1" )
                {
                    if ( result == true )
                    {
                        MessageBox.Show( "编辑成功" );
                        lronEdit( );
                    }
                    else
                        MessageBox.Show( "编辑失败" );
                }
            }
        }
        void lronEdit ( )
        {
            DataRow row = queryTable.Rows[bandedGridView9.FocusedRowHandle];
            row.BeginEdit( );
            row["AM209"] = model.AM209;
            row["AM210"] = model.AM210;
            row["AM211"] = model.AM211;
            row["AM212"] = model.AM212;
            row["AM213"] = model.AM213;
            row["AM214"] = model.AM214;
            row["AM215"] = model.AM215;
            row["AM216"] = model.AM216;
            row["AM217"] = model.AM217;
            row.EndEdit( );
        }
        private void button36_Click ( object sender ,EventArgs e )
        {
            if ( model.Idx > 0 )
            {
                signQuery = "";
                SelectAll.ProductGunPaintAll gunPaint = new SelectAll.ProductGunPaintAll( );
                gunPaint.id = model.Idx;
                gunPaint.PassDataBetweenForm += new SelectAll.ProductGunPaintAll.PassDataBetweenFormHandler( agentFee_PassDataBetweenForm );
                gunPaint.StartPosition = FormStartPosition.CenterScreen;
                gunPaint.ShowDialog( );
                if ( signQuery == "1" )
                {
                    if ( result == true )
                    {
                        MessageBox.Show( "编辑成功" );
                        gunPaintEdit( );
                    }
                    else
                        MessageBox.Show( "编辑失败" );
                }
            }
        }
        void gunPaintEdit ( )
        {
            DataRow row = queryTable.Rows[bandedGridView10.FocusedRowHandle];
            row.BeginEdit( );
            row["AM239"] = model.AM239;
            row["AM240"] = model.AM240;
            row["AM241"] = model.AM241;
            row["AM242"] = model.AM242;
            row["AM243"] = model.AM243;
            row["AM244"] = model.AM244;
            row["AM245"] = model.AM245;
            row["AM246"] = model.AM246;
            row["AM247"] = model.AM247;
            row["AM249"] = model.AM249;
            row["AM250"] = model.AM250;
            row.EndEdit( );
        }
        private void button40_Click ( object sender ,EventArgs e )
        {
            if ( model.Idx > 0 )
            {
                signQuery = "";
                SelectAll.ProductVehicleWoodPiecesAll vehicleWoodPieces = new SelectAll.ProductVehicleWoodPiecesAll( );
                vehicleWoodPieces.id = model.Idx;
                vehicleWoodPieces.StartPosition = FormStartPosition.CenterScreen;
                vehicleWoodPieces.PassDataBetweenForm += new SelectAll.ProductVehicleWoodPiecesAll.PassDataBetweenFormHandler( agentFee_PassDataBetweenForm );
                vehicleWoodPieces.ShowDialog( );
                if ( signQuery == "1" )
                {
                    if ( result == true )
                    {
                        MessageBox.Show( "编辑成功" );
                        vehicleWoodPiecesEdit( );
                    }
                    else
                        MessageBox.Show( "编辑失败" );
                }
            }
        }
        void vehicleWoodPiecesEdit ( )
        {
            DataRow row = queryTable.Rows[bandedGridView11.FocusedRowHandle];
            row.BeginEdit( );
            row["AM270"] = model.AM270;
            row["AM271"] = model.AM270;
            row["AM272"] = model.AM270;
            row["AM273"] = model.AM270;
            row["AM274"] = model.AM270;
            row["AM275"] = model.AM270;
            row.EndEdit( );
        }
        private void button44_Click ( object sender ,EventArgs e )
        {
            if ( model.Idx > 0 )
            {
                signQuery = "";
                SelectAll.ProductPlywoodAll plyWood = new SelectAll.ProductPlywoodAll( );
                plyWood.id = model.Idx;
                plyWood.StartPosition = FormStartPosition.CenterScreen;
                plyWood.PassDataBetweenForm += new SelectAll.ProductPlywoodAll.PassDataBetweenFormHandler( agentFee_PassDataBetweenForm );
                plyWood.ShowDialog( );
                if ( signQuery == "1" )
                {
                    if ( result == true )
                    {
                        MessageBox.Show( "编辑成功" );
                        plywoodEdit( );
                    }
                    else
                        MessageBox.Show( "编辑失败" );
                }
            }
        }
        void plywoodEdit ( )
        {
            DataRow row = queryTable.Rows[bandedGridView12.FocusedRowHandle];
            row.BeginEdit( );
            row["AM298"] = model.AM298;
            row["AM299"] = model.AM299;
            row["AM300"] = model.AM300;
            row["AM301"] = model.AM301;
            row["AM302"] = model.AM302;
            row["AM303"] = model.AM303;
            row["AM304"] = model.AM304;
            row["AM305"] = model.AM305;
            row["AM306"] = model.AM306;
            row["AM307"] = model.AM307;
            row["AM308"] = model.AM308;
            row["AM309"] = model.AM309;
            row["AM310"] = model.AM310;
            row["AM311"] = model.AM311;
            row["AM312"] = model.AM312;
            row["AM313"] = model.AM313;
            row.EndEdit( );
        }
        private void button48_Click ( object sender ,EventArgs e )
        {
            if ( model.Idx > 0 )
            {
                signQuery = "";
                SelectAll.ProductWoodAll wood = new SelectAll.ProductWoodAll( );
                wood.id = model.Idx;
                wood.StartPosition = FormStartPosition.CenterScreen;
                wood.PassDataBetweenForm += new SelectAll.ProductWoodAll.PassDataBetweenFormHandler( agentFee_PassDataBetweenForm );
                wood.ShowDialog( );
                if ( signQuery == "1" )
                {
                    if ( result == true )
                    {
                        MessageBox.Show( "编辑成功" );
                        woodEdit( );
                    }
                    else
                        MessageBox.Show( "编辑失败" );
                }
            }
        }
        void woodEdit ( )
        {
            DataRow row = queryTable.Rows[bandedGridView13.FocusedRowHandle];
            row.BeginEdit( );
            row["AM336"] = model.AM336;
            row["AM337"] = model.AM337;
            row["AM338"] = model.AM338;
            row["AM339"] = model.AM339;
            row["AM340"] = model.AM340;
            row["AM341"] = model.AM341;
            row["AM342"] = model.AM342;
            row["AM343"] = model.AM343;
            row["AM344"] = model.AM344;
            row["AM345"] = model.AM345;
            row["AM346"] = model.AM346;
            row["AM347"] = model.AM347;
            row["AM348"] = model.AM348;
            row["AM349"] = model.AM349;
            row["AM350"] = model.AM350;
            row["AM351"] = model.AM351;
            row["AM352"] = model.AM352;
            row["AM353"] = model.AM353;
            row["AM354"] = model.AM354;
            row["AM355"] = model.AM355;
            row["AM356"] = model.AM356;
            row["AM357"] = model.AM357;
            row["AM358"] = model.AM358;
            row["AM359"] = model.AM359;
            row["AM360"] = model.AM360;
            row["AM361"] = model.AM361;
            row["AM362"] = model.AM362;
            row["AM363"] = model.AM363;
            row["AM364"] = model.AM364;
            row["AM365"] = model.AM365;
            row["AM366"] = model.AM366;
            row["AM367"] = model.AM367;
            row["AM368"] = model.AM368;
            row["AM369"] = model.AM369;
            row["AM370"] = model.AM370;
            row["AM371"] = model.AM371;
            row["AM372"] = model.AM372;
            row.EndEdit( );
        }
        //Delete
        private void button4_Click ( object sender ,EventArgs e )
        {
            Delete( );
        }
        //Refresh
        private void button5_Click ( object sender ,EventArgs e )
        {
            Refreshes( );
            //gridControl1.DataSource = null;
        }
        private void button6_Click ( object sender ,EventArgs e )
        {
            Refreshes( );
        }
        private void button10_Click ( object sender ,EventArgs e )
        {
            Refreshes( );
        }
        private void button14_Click ( object sender ,EventArgs e )
        {
            Refreshes( );
            //gridControl5.DataSource = null;
        }
        private void button18_Click ( object sender ,EventArgs e )
        {
            Refreshes( );
            //gridControl6.DataSource = null;
        }
        private void button22_Click ( object sender ,EventArgs e )
        {
            Refreshes( );
            //gridControl7.DataSource = null;
        }
        private void button26_Click ( object sender ,EventArgs e )
        {
            Refreshes( );
            //gridControl8.DataSource = null;
        }
        private void button30_Click ( object sender ,EventArgs e )
        {
            Refreshes( );
            //gridControl9.DataSource = null;
        }
        private void button34_Click ( object sender ,EventArgs e )
        {
            Refreshes( );
            //gridControl10.DataSource = null;
        }
        private void button38_Click ( object sender ,EventArgs e )
        {
            Refreshes( );
            //gridControl11.DataSource = null;
        }
        private void button42_Click ( object sender ,EventArgs e )
        {
            Refreshes( );
            //gridControl12.DataSource = null;
        }
        private void button46_Click ( object sender ,EventArgs e )
        {
            Refreshes( );
            //gridControl13.DataSource = null;
        }
        //BuildAll

        delegate void AsynUpdateUI ( int temp );//建立一个委托来实现非创建控件的线程更新控件

        public delegate void UpdateUI ( int step );//声明一个更新主线程的委托
        public UpdateUI UpdateUIDelegate;
        
        private void UpdateUIStatus ( int temp )
        {
            if ( InvokeRequired )
            {
                this . Invoke ( new AsynUpdateUI ( delegate ( int s )
                {
                    this . progressBar1 . Value += s;
                    if ( this . progressBar1 . Value == progressBar1 . Maximum )
                    {
                        progressBar1 . Visible = false;
                        Ergodic . FormEverySpliEnableTrue ( this );
                    }

                } ) , temp );
            }
            else
            {
                this . progressBar1 . Value += temp;
                if ( this . progressBar1 . Value == progressBar1 . Maximum )
                {
                    progressBar1 . Visible = false;
                    Ergodic . FormEverySpliEnableTrue ( this );
                }
            }
        }

        public delegate void AccomplishTask ( );//声明一个在完成任务时通知主线程的委托
        public AccomplishTask TaskCallBack;

        private void button7_Click ( object sender ,EventArgs e )
        {
            try
            {
                this . UpdateUIDelegate += UpdateUIStatus;//绑定更新任务状态的委托
                this . TaskCallBack += Accomplish;//绑定完成任务要调用的委托
                //if ( bandedGridView1 . DataRowCount < 1 )
                //{
                //    MessageBox . Show ( "请查询需要生成的流水" );
                //    return;
                //}
                string num = string . Empty;
                for ( int i = 0 ; i < bandedGridView1 . DataRowCount ; i++ )
                {
                    if ( string . IsNullOrEmpty ( num ) )
                        num = "'" + bandedGridView1 . GetDataRow ( i ) [ "AM002" ] . ToString ( ) + "'";
                    else
                        num = num + "," + "'" + bandedGridView1 . GetDataRow ( i ) [ "AM002" ] . ToString ( ) + "'";
                }
                if ( string . IsNullOrEmpty ( num ) )
                {
                    if ( string . IsNullOrEmpty ( dateNum . Text ) )
                    {
                        MessageBox . Show ( "请选择年" );
                        return;
                    }
                    num = dateNum . Text . Substring ( 2 ,2 );
                    num = "PQF01 LIKE '" + num + "%'";
                }
                else
                    num = "PQF01 IN (" + num + ")";
                DataTable tablePqf = bll . GetDataTablePqf ( num );
                if ( tablePqf != null && tablePqf . Rows . Count > 0 )
                {
                    Ergodic . FormEverySpliEnableFalse ( this );
                    progressBar1 . Visible = true;
                    this . progressBar1 . Maximum = tablePqf . Rows . Count;
                    this . progressBar1 . Value = 0;
                    Thread thread = new Thread ( new ParameterizedThreadStart ( GenerateAll ) );
                    thread . IsBackground = true;
                    thread . Start ( tablePqf );
                }
            }
            catch ( Exception ex )
            {
                AutoUpdate.LogHelper . WriteLog ( ex . StackTrace );
            }
        }

        //完成任务时需要调用
        private void Accomplish ( )
        {
            //还可以进行其他的一些完任务完成之后的逻辑处理
            progressBar1 . Visible = false;
            Ergodic . FormEverySpliEnableTrue ( this );
        }

        void GenerateAll ( object da )
        {
            DataTable tablePqf = ( DataTable ) da;
            ArrayList SQLString = new ArrayList ( );

            if ( tablePqf != null && tablePqf . Rows . Count > 0 )
            {
                DataTable tpadba = bll . GetDataTableTpa ( );
                DataTable dl;
                if ( bandedGridView1 . DataRowCount > 0 )
                    model . AM001 = bandedGridView1 . GetDataRow ( 0 ) [ "AM001" ] . ToString ( );
                for ( int i = 0 ; i < tablePqf . Rows . Count ; i++ )
                {
                    model . AM002 = tablePqf . Rows [ i ] [ "PQF01" ] . ToString ( );
                    model . AM003 = tablePqf . Rows [ i ] [ "PQF04" ] . ToString ( );
                    model . AM004 = tablePqf . Rows [ i ] [ "PQF02" ] . ToString ( );
                    model . AM005 = tablePqf . Rows [ i ] [ "PQF03" ] . ToString ( );
                    model . AM006 = string . IsNullOrEmpty ( tablePqf . Rows [ i ] [ "PQF06" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tablePqf . Rows [ i ] [ "PQF06" ] . ToString ( ) );
                    if ( !string . IsNullOrEmpty ( tablePqf . Rows [ i ] [ "AE21" ] . ToString ( ) ) && Convert . ToDateTime ( tablePqf . Rows [ i ] [ "AE21" ] . ToString ( ) ) > DateTime . MinValue && Convert . ToDateTime ( tablePqf . Rows [ i ] [ "AE21" ] . ToString ( ) ) < DateTime . MaxValue )
                        model . AM007 = Convert . ToDateTime ( tablePqf . Rows [ i ] [ "AE21" ] . ToString ( ) );
                    else
                        model . AM007 = null;
                    model . AM008 = tablePqf . Rows [ i ] [ "DAA002" ] . ToString ( );
                    if ( tpadba != null && tpadba . Select ( "DBA002='" + model . AM008 + "'" ) . Length > 0 )
                        model . AM009 = tpadba . Select ( "DBA002='" + model . AM008 + "'" ) [ 0 ] [ "DAA002" ] . ToString ( );
                    else
                        model . AM009 = "";
                    model . AM010 = tablePqf . Rows [ i ] [ "DBA002" ] . ToString ( );
                    model . AM011 = tablePqf . Rows [ i ] [ "DFA003" ] . ToString ( );
                    model . AM012 = tablePqf . Rows [ i ] [ "PQF23" ] . ToString ( );
                    model . AM013 = tablePqf . Rows [ i ] [ "PQF24" ] . ToString ( );
                    model . AM014 = tablePqf . Rows [ i ] [ "PQF10" ] . ToString ( );
                    model . AM015 = string . IsNullOrEmpty ( tablePqf . Rows [ i ] [ "AE37" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( tablePqf . Rows [ i ] [ "AE37" ] . ToString ( ) );
                    model . AM016 = string . IsNullOrEmpty ( tablePqf . Rows [ i ] [ "PQF09" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( tablePqf . Rows [ i ] [ "PQF09" ] . ToString ( ) );
                    model . AM017 = 0M;
                    model . AM018 = 0M;
                    model . AM019 = 0M;
                    Generate ( );
                    dl = bll . GetDataTableExists ( model . AM002 );
                    if ( dl != null && dl . Rows . Count > 0 )
                    {
                        model . Idx = string . IsNullOrEmpty ( dl . Rows [ 0 ] [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( dl . Rows [ 0 ] [ "idx" ] . ToString ( ) );
                        result = bll . Update ( model );
                        if ( result == false )
                        {
                            MessageBox . Show ( "数据生成失败,请重试" );
                            //TaskCallBack ( );
                            //progressBar1 . Visible = false;
                            //Ergodic . FormEverySpliEnableTrue ( this );
                            return;
                        }
                        else if ( i == tablePqf . Rows . Count - 1 )
                        {
                            MessageBox . Show ( "生成数据成功,请查询" );

                            //progressBar1 . Visible = false;
                            //Ergodic . FormEverySpliEnableTrue ( this );

                            //写入一条数据，调用更新主线程ui状态的委托
                            UpdateUIDelegate ( 1 );                      
                            //任务完成时通知主线程作出相应的处理
                            //TaskCallBack ( );
                            try
                            {
                                bll . UpdateOfRpqbb ( );
                            }
                            catch { }
                        }else
                            //写入一条数据，调用更新主线程ui状态的委托
                            UpdateUIDelegate ( 1 );
                    }
                    else
                    {
                        model . AM001 = oddNumbers . purchaseContract ( "SELECT MAX(AJ024) AJ024 FROM R_PQAJ" , "AJ024" , "R_241-" );
                        model . Idx = 0;
                        model . Idx = bll . Add ( model );
                        if ( model . Idx < 1 )
                        {
                            MessageBox . Show ( "数据生成失败,请重试" );
                            //TaskCallBack ( );
                            //progressBar1 . Visible = false;
                            //Ergodic . FormEverySpliEnableTrue ( this );
                            return;
                        }
                        else if ( i == tablePqf . Rows . Count - 1 )
                        {
                            MessageBox . Show ( "生成数据成功,请查询" );

                            //progressBar1 . Visible = false;
                            //Ergodic . FormEverySpliEnableTrue ( this );

                            //写入一条数据，调用更新主线程ui状态的委托
                            UpdateUIDelegate ( 1 );
                            //任务完成时通知主线程作出相应的处理
                            //TaskCallBack ( );
                            try
                            {
                                bll . UpdateOfRpqbb ( );
                            }
                            catch { }
                        }else
                            //写入一条数据，调用更新主线程ui状态的委托
                            UpdateUIDelegate ( 1 );
                    }
                }
            }
        }

        DataRow row;
        void build ( )
        {
            if ( string.IsNullOrEmpty( textBox4.Text ) )
                MessageBox.Show( "流水号不可为空" );
            else
            {
                variable( );
                Generate( );
                result = bll.ExistsModel( model );
                if ( result == false )
                {
                    model.Idx = bll.Add( model );
                    if ( model.Idx > 0 )
                    {
                        MessageBox.Show( "成功录入数据" );
                        if ( sign == "1" )
                            Refreshes( );
                        else
                        {
                            row = queryTable.NewRow( );
                            row["idx"] = model.Idx;
                            build_One( );
                            queryTable.Rows.Add( row );
                        }

                        try
                        {
                            bll.UpdateOfRpqbb( );
                        }
                        catch { }
                    }
                    else
                        MessageBox.Show( "录入数据失败" );
                }
                else
                {
                    result = bll.Update( model );
                    if ( result == true )
                    {
                        MessageBox.Show( "成功录入数据" );
                        row = queryTable.Rows[num];
                        row.BeginEdit( );
                        build_One( );
                        row.EndEdit( );

                        try
                        {
                            bll.UpdateOfRpqbb( );
                        }
                        catch { }
                    }
                    else
                        MessageBox.Show( "录入数据失败" );
                }
            }
        }
        void Delete ( )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==DialogResult . Cancel )
                return;
            variable ( );
            result = bll.Delete( model );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                queryTable.Rows.Remove( queryTable.Select( "idx='" + model.Idx + "'" )[0] );
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        void Edit ( )
        {
            if ( string.IsNullOrEmpty( textBox3.Text ) )
                MessageBox.Show( "产品名称不可为空" );
            else
            {
                variable( );
                if ( oddNum == textBox4.Text )
                {
                    result = false;
                    result = bll.Update( model );
                    if ( result == true )
                    {
                        MessageBox.Show( "编辑数据成功" );
                        row = queryTable.Rows[num];
                        row.BeginEdit( );
                        build_One( );
                        row.EndEdit( );
                    }
                    else
                        MessageBox.Show( "编辑数据失败" );
                }
                else
                {
                    result = false;
                    result = bll.Update( model );
                    if ( result == true )
                    {
                        MessageBox.Show( "编辑数据成功" );
                        row = queryTable.Rows[num];
                        row.BeginEdit( );
                        build_One( );
                        row.EndEdit( );
                    }
                    else
                        MessageBox.Show( "编辑数据失败" );
                }
            }
        }
        void Refreshes ( )
        {
            try
            {
                bll . UpdateOfRpqbb ( );
            }
            catch { }
            finally
            {
                strWhere = "1=1";
                strWhere = strWhere + " AND AM001='" + model . AM001 + "'";
                refre ( );

                strWhere = "1=1";
            }
        }

        void refre (  )
        {
            queryTable = bll.GetList( strWhere );
            addColumn( );
            gridControl1.DataSource = queryTable;
            gridControl2.DataSource = queryTable;
            gridControl3.DataSource = queryTable;
            gridControl4.DataSource = queryTable;
            gridControl5.DataSource = queryTable;
            gridControl6.DataSource = queryTable;
            gridControl7.DataSource = queryTable;
            gridControl8.DataSource = queryTable;
            gridControl9.DataSource = queryTable;
            gridControl10.DataSource = queryTable;
            gridControl11.DataSource = queryTable;
            gridControl12.DataSource = queryTable;
            gridControl13.DataSource = queryTable;

            if ( queryTable . Rows . Count > 0 )
            {
                if ( queryTable . Rows [ 0 ] [ "AM114" ] . ToString ( ) == "T" )
                    all ( );
                else
                    hide ( );
            }
            else
                all ( );
            calcuTotal ( );
        }
        void Generate ( )
        {
            //2018-10-19  统一修改241读数据   342有备注

            #region 195         
            DataTable daPqq = bll.GetDataTablePqq( model.AM002 );
            if ( daPqq != null && daPqq.Rows.Count > 0 )
            {
                try
                {
                    bll.UpdatePqq( model );
                }
                catch (Exception ex)
                {
                    AutoUpdate . LogHelper . WriteLog ( "241 195 " + ex . Message + ex . StackTrace );
                    throw new Exception ( "195：" + ex . Message );
                }
                finally
                {
                    model.AM109 = model.AM108 = model.AM111 = model.AM112 = model.AM110 = model.AM113 = model.AM115 = model.AM116 = 0;
                    model.AM109 = string.IsNullOrEmpty( daPqq.Compute( "SUM(AK)" ,"CP56='F' AND CP58='F' AND (AK017='执行' OR AK017='审核')" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqq.Compute( "SUM(AK)" ,"CP56='F' AND CP58='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM108 = string.IsNullOrEmpty( daPqq.Compute( "SUM(CP)" ,"CP56='F' AND CP58='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqq.Compute( "SUM(CP)" ,"CP56='F' AND CP58='F'" ).ToString( ) );
                    model.AM113 = string.IsNullOrEmpty( daPqq.Compute( "SUM(AK)" ,"CP56='T' AND CP58='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqq.Compute( "SUM(AK)" ,"CP56='T' AND CP58='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM110 = string.IsNullOrEmpty( daPqq.Compute( "SUM(CP)" ,"CP56='T' AND CP58='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqq.Compute( "SUM(CP)" ,"CP56='T' AND CP58='F'" ).ToString( ) );
                    model.AM112 = string.IsNullOrEmpty( daPqq.Compute( "SUM(AK)" ,"CP56='F' AND CP58='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqq.Compute( "SUM(AK)" ,"CP56='F' AND CP58='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM111 = string.IsNullOrEmpty( daPqq.Compute( "SUM(CP)" ,"CP56='F' AND CP58='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqq.Compute( "SUM(CP)" ,"CP56='F' AND CP58='T'" ).ToString( ) );
                    model.AM116 = string.IsNullOrEmpty( daPqq.Compute( "SUM(AK)" ,"CP56='T' AND CP58='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqq.Compute( "SUM(AK)" ,"CP56='T' AND CP58='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM115 = string.IsNullOrEmpty( daPqq.Compute( "SUM(CP)" ,"CP56='T' AND CP58='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqq.Compute( "SUM(CP)" ,"CP56='T' AND CP58='T'" ).ToString( ) );
                }
            }
            else
                model.AM109 = model.AM108 = model.AM111 = model.AM112 = model.AM110 = model.AM113 = model.AM115 = model.AM116 = 0;
            #endregion
            
            #region 196
            DataTable daTwo = bll.GetDataTableTwo( model.AM002 );
            if ( daTwo != null && daTwo.Rows.Count > 0 )
            {
                try
                {
                    bll.UpdatePqah( model );
                }
                catch(Exception ex) { AutoUpdate . LogHelper . WriteLog ( "241 196 " + ex . Message + ex . StackTrace ); throw new Exception ( "196：" + ex . Message ); }
                finally
                {
                    model.AM070 = model.AM071 = model.AM072 = model.AM073 = model.AM074 = model.AM075 = model.AM076 = model.AM077 = model.AM078 = model.AM079 = model.AM080 = model.AM081 = model.AM082 = model.AM083 = model.AM084 = model.AM085 = model.AM086 = model.AM087 = model.AM088 = model.AM089 = model.AM090 = model.AM091 = model.AM092 = model.AM093 = 0;
                    model.AM070 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AH)" ,"AH18='雕刻'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AH)" ,"AH18='雕刻'" ).ToString( ) );
                    model.AM071 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AK)" ,"AH18='雕刻' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AK)" ,"AH18='雕刻' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM072 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AH)" ,"AH18='绕锯'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AH)" ,"AH18='绕锯'" ).ToString( ) );
                    model.AM073 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AK)" ,"AH18='绕锯' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AK)" ,"AH18='绕锯' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM074 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AH)" ,"AH18='夹料'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AH)" ,"AH18='夹料'" ).ToString( ) );
                    model.AM075 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AK)" ,"AH18='夹料' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AK)" ,"AH18='夹料' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM076 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AH)" ,"AH18='擦砂皮'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AH)" ,"AH18='擦砂皮'" ).ToString( ) );
                    model.AM077 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AK)" ,"AH18='擦砂皮' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AK)" ,"AH18='擦砂皮' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM078 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AH)" ,"AH18='丝印'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AH)" ,"AH18='丝印'" ).ToString( ) );
                    model.AM079 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AK)" ,"AH18='丝印' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AK)" ,"AH18='丝印' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM080 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AH)" ,"AH18='走台印'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AH)" ,"AH18='走台印'" ).ToString( ) );
                    model.AM081 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AK)" ,"AH18='走台印' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AK)" ,"AH18='走台印' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM082 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AH)" ,"AH18='移印'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AH)" ,"AH18='移印'" ).ToString( ) );
                    model.AM083 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AK)" ,"AH18='移印' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AK)" ,"AH18='移印' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM084 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AH)" ,"AH18='热转印'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AH)" ,"AH18='热转印'" ).ToString( ) );
                    model.AM085 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AK)" ,"AH18='热转印' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AK)" ,"AH18='热转印' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM086 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AH)" ,"AH18='烫印'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AH)" ,"AH18='烫印'" ).ToString( ) );
                    model.AM087 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AK)" ,"AH18='烫印' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AK)" ,"AH18='烫印' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM088 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AH)" ,"AH18='喷漆'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AH)" ,"AH18='喷漆'" ).ToString( ) );
                    model.AM089 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AK)" ,"AH18='喷漆' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AK)" ,"AH18='喷漆' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM090 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AH)" ,"AH18='冲压'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AH)" ,"AH18='冲压'" ).ToString( ) );
                    model.AM091 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AK)" ,"AH18='冲压' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AK)" ,"AH18='冲压' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM092 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AH)" ,"AH18='手工剪切、其它'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AH)" ,"AH18='手工剪切、其它'" ).ToString( ) );
                    model.AM093 = string.IsNullOrEmpty( daTwo.Compute( "SUM(AK)" ,"AH18='手工剪切、其它' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daTwo.Compute( "SUM(AK)" ,"AH18='手工剪切、其它' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                }
            }
            else
                model.AM070 = model.AM071 = model.AM072 = model.AM073 = model.AM074 = model.AM075 = model.AM076 = model.AM077 = model.AM078 = model.AM079 = model.AM080 = model.AM081 = model.AM082 = model.AM083 = model.AM084 = model.AM085 = model.AM086 = model.AM087 = model.AM088 = model.AM089 = model.AM090 = model.AM091 = model.AM092 = model.AM093 = 0;
            #endregion

            #region 199
            /*
            DataTable daPqba = bll.GetDataTablePqba( model.AM002 );
            if ( daPqba != null && daPqba.Rows.Count > 0 )
            {
                model.AM109 = model.AM108 = model.AM111 = model.AM112 = model.AM110 = model.AM113 = model.AM115 = model.AM116 = 0M;
                model.AM109 = string.IsNullOrEmpty( daPqba.Compute( "SUM(AK)" ,"BA056='F' AND BA058='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqba.Compute( "SUM(AK)" ,"BA056='F' AND BA058='F'" ).ToString( ) );
                model.AM108 = string.IsNullOrEmpty( daPqba.Compute( "SUM(BA)" ,"BA056='F' AND BA058='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqba.Compute( "SUM(BA)" ,"BA056='F' AND BA058='F'" ).ToString( ) );
                model.AM113 = string.IsNullOrEmpty( daPqba.Compute( "SUM(AK)" ,"BA056='T' AND BA058='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqba.Compute( "SUM(AK)" ,"BA056='T' AND BA058='F'" ).ToString( ) );
                model.AM110 = string.IsNullOrEmpty( daPqba.Compute( "SUM(BA)" ,"BA056='T' AND BA058='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqba.Compute( "SUM(BA)" ,"BA056='T' AND BA058='F'" ).ToString( ) );
                model.AM112 = string.IsNullOrEmpty( daPqba.Compute( "SUM(AK)" ,"BA056='F' AND BA058='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqba.Compute( "SUM(AK)" ,"BA056='F' AND BA058='T'" ).ToString( ) );
                model.AM111 = string.IsNullOrEmpty( daPqba.Compute( "SUM(BA)" ,"BA056='F' AND BA058='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqba.Compute( "SUM(BA)" ,"BA056='F' AND BA058='T'" ).ToString( ) );
                model.AM116 = string.IsNullOrEmpty( daPqba.Compute( "SUM(AK)" ,"BA056='T' AND BA058='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqba.Compute( "SUM(AK)" ,"BA056='T' AND BA058='T'" ).ToString( ) );
                model.AM115 = string.IsNullOrEmpty( daPqba.Compute( "SUM(BA)" ,"BA056='T' AND BA058='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqba.Compute( "SUM(BA)" ,"BA056='T' AND BA058='T'" ).ToString( ) );

                #region
                /*
                signOfState = "";
                for ( int i = 0 ; i < daPqba.Rows.Count ; i++ )
                {
                    signOfState = daPqba.Rows[i]["BA056"].ToString( ).Trim( );
                    if ( daPqba.Rows[i]["BA058"].ToString( ).Trim() == "F" )
                    {
                        if ( signOfState == "F" )
                        {
                            model.AM109 += string.IsNullOrEmpty( daPqba.Rows[0]["AK"].ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqba.Rows[0]["AK"].ToString( ) );
                            model.AM108 += string.IsNullOrEmpty( daPqba.Rows[0]["BA"].ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqba.Rows[0]["BA"].ToString( ) );
                        }
                        else if ( signOfState == "T" )
                        {
                            model.AM113 += string.IsNullOrEmpty( daPqba.Rows[0]["AK"].ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqba.Rows[0]["AK"].ToString( ) );
                            model.AM110 += string.IsNullOrEmpty( daPqba.Rows[0]["BA"].ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqba.Rows[0]["BA"].ToString( ) );
                        }
                    }
                    else
                    {
                        if ( signOfState == "F" )
                        {
                            model.AM112 += string.IsNullOrEmpty( daPqba.Rows[0]["AK"].ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqba.Rows[0]["AK"].ToString( ) );
                            model.AM111 += string.IsNullOrEmpty( daPqba.Rows[0]["BA"].ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqba.Rows[0]["BA"].ToString( ) );
                        }
                        else if ( signOfState == "T" )
                        {
                            model.AM116 += string.IsNullOrEmpty( daPqba.Rows[0]["AK"].ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqba.Rows[0]["AK"].ToString( ) );
                            model.AM115 += string.IsNullOrEmpty( daPqba.Rows[0]["BA"].ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqba.Rows[0]["BA"].ToString( ) );
                        }
                    }
                }
                
                #endregion
            }
            else
                model.AM109 = model.AM108 = model.AM111 = model.AM112 = model.AM110 = model.AM113 = model.AM115 = model.AM116 = 0;
            */
            #endregion

            #region 317         
            DataTable daPqw = bll.GetDataTablePqw( model.AM002 );
            if ( daPqw.Rows.Count > 0 )
            {
                model.AM044 = model.AM045 = model.AM046 = model.AM047 = model.AM048 = model.AM049 = model.AM050 = model.AM051 = model.AM052 = model.AM053 = model.AM054 = model.AM055 = model.AM056 = model.AM057 = model.AM058 = model.AM059 = model.AM060 = model.AM061 = model.AM062 = model.AM063 = 0M;
                model.AM044 = string.IsNullOrEmpty( daPqw.Compute( "sum(GZ)" ,"GX04='白坯'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqw.Compute( "sum(GZ)" ,"GX04='白坯'" ) );
                model.AM045 = string.IsNullOrEmpty( daPqw.Compute( "sum(GZ1)" ,"GX04='白坯'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqw.Compute( "sum(GZ1)" ,"GX04='白坯'" ) );
                model.AM046 = string.IsNullOrEmpty( daPqw.Compute( "sum(GZ)" ,"GX04='砂光'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqw.Compute( "sum(GZ)" ,"GX04='砂光'" ) );
                model.AM047 = string.IsNullOrEmpty( daPqw.Compute( "sum(GZ1)" ,"GX04='砂光'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqw.Compute( "sum(GZ1)" ,"GX04='砂光'" ) );
                model.AM048 = string.IsNullOrEmpty( daPqw.Compute( "sum(GZ)" ,"GX04='粘接'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqw.Compute( "sum(GZ)" ,"GX04='粘接'" ) );
                model.AM049 = string.IsNullOrEmpty( daPqw.Compute( "sum(GZ1)" ,"GX04='粘接'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqw.Compute( "sum(GZ1)" ,"GX04='粘接'" ) );
                model.AM050 = string.IsNullOrEmpty( daPqw.Compute( "sum(GZ)" ,"GX04='组装'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqw.Compute( "sum(GZ)" ,"GX04='组装'" ) );
                model.AM051 = string.IsNullOrEmpty( daPqw.Compute( "sum(GZ1)" ,"GX04='组装'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqw.Compute( "sum(GZ1)" ,"GX04='组装'" ) );
                model.AM052 = string.IsNullOrEmpty( daPqw.Compute( "sum(GZ)" ,"GX04='检验'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqw.Compute( "sum(GZ)" ,"GX04='检验'" ) );
                model.AM053 = string.IsNullOrEmpty( daPqw.Compute( "sum(GZ1)" ,"GX04='检验'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqw.Compute( "sum(GZ1)" ,"GX04='检验'" ) );
                model.AM054 = string.IsNullOrEmpty( daPqw.Compute( "sum(GZ)" ,"GX04='包装'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqw.Compute( "sum(GZ)" ,"GX04='包装'" ) );
                model.AM055 = string.IsNullOrEmpty( daPqw.Compute( "sum(GZ1)" ,"GX04='包装'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqw.Compute( "sum(GZ1)" ,"GX04='包装'" ) );
                model.AM056 = string.IsNullOrEmpty( daPqw.Compute( "sum(GZ)" ,"GX04='修理'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqw.Compute( "sum(GZ)" ,"GX04='修理'" ) );
                model.AM057 = string.IsNullOrEmpty( daPqw.Compute( "sum(GZ1)" ,"GX04='修理'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqw.Compute( "sum(GZ1)" ,"GX04='修理'" ) );
                model.AM058 = string.IsNullOrEmpty( daPqw.Compute( "sum(GZ)" ,"GX04='后道辅助'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqw.Compute( "sum(GZ)" ,"GX04='后道辅助'" ) );
                model.AM059 = string.IsNullOrEmpty( daPqw.Compute( "sum(GZ1)" ,"GX04='后道辅助'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqw.Compute( "sum(GZ1)" ,"GX04='后道辅助'" ) );
                model.AM060 = string.IsNullOrEmpty( daPqw.Compute( "sum(GZ)" ,"GX04='返工'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqw.Compute( "sum(GZ)" ,"GX04='返工'" ) );
                model.AM061 = string.IsNullOrEmpty( daPqw.Compute( "sum(GZ1)" ,"GX04='返工'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqw.Compute( "sum(GZ1)" ,"GX04='返工'" ) );
                model.AM062 = string.IsNullOrEmpty( daPqw.Compute( "sum(GZ)" ,"GX04='其它'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqw.Compute( "sum(GZ)" ,"GX04='其它'" ) );
                model.AM063 = string.IsNullOrEmpty( daPqw.Compute( "sum(GZ1)" ,"GX04='其它'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqw.Compute( "sum(GZ1)" ,"GX04='其它'" ) );
                #region
                /*
                for ( int i = 0 ; i < daPqw.Rows.Count ; i++ )
                {
                    if ( daPqw.Rows[i]["GX04"].ToString( ) == "白坯" )
                    {
                        model.AM044 += string.IsNullOrEmpty( daPqw.Rows[i]["GZ"].ToString( ) ) == true ? 0M : Convert.ToInt32( daPqw.Rows[i]["GZ"].ToString( ) );
                        model.AM045 += string.IsNullOrEmpty( daPqw.Rows[i]["GZ1"].ToString( ) ) == true ? 0M : Convert.ToInt32( daPqw.Rows[i]["GZ1"].ToString( ) );
                    }
                    if ( daPqw.Rows[i]["GX04"].ToString( ) == "砂光" )
                    {
                        model.AM046 += string.IsNullOrEmpty( daPqw.Rows[i]["GZ"].ToString( ) ) == true ? 0M : Convert.ToInt32( daPqw.Rows[i]["GZ"].ToString( ) );
                        model.AM047 += string.IsNullOrEmpty( daPqw.Rows[i]["GZ1"].ToString( ) ) == true ? 0M : Convert.ToInt32( daPqw.Rows[i]["GZ1"].ToString( ) );
                    }
                    if ( daPqw.Rows[i]["GX04"].ToString( ) == "粘接" )
                    {
                        model.AM048 += string.IsNullOrEmpty( daPqw.Rows[i]["GZ"].ToString( ) ) == true ? 0M : Convert.ToInt32( daPqw.Rows[i]["GZ"].ToString( ) );
                        model.AM049 += string.IsNullOrEmpty( daPqw.Rows[i]["GZ1"].ToString( ) ) == true ? 0M : Convert.ToInt32( daPqw.Rows[i]["GZ1"].ToString( ) );
                    }
                    if ( daPqw.Rows[i]["GX04"].ToString( ) == "组装" )
                    {
                        model.AM050 += string.IsNullOrEmpty( daPqw.Rows[i]["GZ"].ToString( ) ) == true ? 0M : Convert.ToInt32( daPqw.Rows[i]["GZ"].ToString( ) );
                        model.AM051 += string.IsNullOrEmpty( daPqw.Rows[i]["GZ1"].ToString( ) ) == true ? 0M : Convert.ToInt32( daPqw.Rows[i]["GZ1"].ToString( ) );
                    }
                    if ( daPqw.Rows[i]["GX04"].ToString( ) == "检验" )
                    {
                        model.AM052 += string.IsNullOrEmpty( daPqw.Rows[i]["GZ"].ToString( ) ) == true ? 0M : Convert.ToInt32( daPqw.Rows[i]["GZ"].ToString( ) );
                        model.AM053 += string.IsNullOrEmpty( daPqw.Rows[i]["GZ1"].ToString( ) ) == true ? 0M : Convert.ToInt32( daPqw.Rows[i]["GZ1"].ToString( ) );
                    }
                    if ( daPqw.Rows[i]["GX04"].ToString( ) == "包装" )
                    {
                        model.AM054 += string.IsNullOrEmpty( daPqw.Rows[i]["GZ"].ToString( ) ) == true ? 0M : Convert.ToInt32( daPqw.Rows[i]["GZ"].ToString( ) );
                        model.AM055 += string.IsNullOrEmpty( daPqw.Rows[i]["GZ1"].ToString( ) ) == true ? 0M : Convert.ToInt32( daPqw.Rows[i]["GZ1"].ToString( ) );
                    }
                    if ( daPqw.Rows[i]["GX04"].ToString( ) == "修理" )
                    {
                        model.AM056 += string.IsNullOrEmpty( daPqw.Rows[i]["GZ"].ToString( ) ) == true ? 0M : Convert.ToInt32( daPqw.Rows[i]["GZ"].ToString( ) );
                        model.AM057 += string.IsNullOrEmpty( daPqw.Rows[i]["GZ1"].ToString( ) ) == true ? 0M : Convert.ToInt32( daPqw.Rows[i]["GZ1"].ToString( ) );
                    }
                    if ( daPqw.Rows[i]["GX04"].ToString( ) == "后道辅助" )
                    {
                        model.AM058 += string.IsNullOrEmpty( daPqw.Rows[i]["GZ"].ToString( ) ) == true ? 0M : Convert.ToInt32( daPqw.Rows[i]["GZ"].ToString( ) );
                        model.AM059 += string.IsNullOrEmpty( daPqw.Rows[i]["GZ1"].ToString( ) ) == true ? 0M : Convert.ToInt32( daPqw.Rows[i]["GZ1"].ToString( ) );
                    }
                    if ( daPqw.Rows[i]["GX04"].ToString( ) == "返工" )
                    {
                        model.AM060 += string.IsNullOrEmpty( daPqw.Rows[i]["GZ"].ToString( ) ) == true ? 0M : Convert.ToInt32( daPqw.Rows[i]["GZ"].ToString( ) );
                        model.AM061 += string.IsNullOrEmpty( daPqw.Rows[i]["GZ1"].ToString( ) ) == true ? 0M : Convert.ToInt32( daPqw.Rows[i]["GZ1"].ToString( ) );
                    }
                   
                }
                */
                #endregion
            }
            else
                model.AM044 = model.AM045 = model.AM046 = model.AM047 = model.AM048 = model.AM049 = model.AM050 = model.AM051 = model.AM052 = model.AM053 = model.AM054 = model.AM055 = model.AM056 = model.AM057 = model.AM058 = model.AM059 = model.AM060 = model.AM061 = model.AM062 = model.AM063 = 0M;
            #endregion
            
            #region 338          
            DataTable daPqo = bll.GetDataTablePqo( model.AM002 );
            if ( daPqo != null && daPqo.Rows.Count > 0 )
            {
                try
                {
                    bll.UpdatePqo( model );
                }
                catch ( Exception ex ) { AutoUpdate . LogHelper . WriteLog ( "241 338 " + ex . Message + ex . StackTrace ); throw new Exception ( "338：" + ex . Message ); }
                finally
                {
                    model.AM296 = model.AM297 = model.AM298 = model.AM299 = model.AM307 = model.AM308 = model.AM301 = model.AM302 = model.AM311 = model.AM312 = model.AM304 = model.AM305 = model.AM315 = model.AM316 = model.AM318 = model.AM319 = model.AM321 = model.AM322 = model.AM300 = model.AM309 = model.AM303 = model.AM313 = model.AM306 = model.AM317 = model.AM320 = model.AM321 = model.AM322 = model.AM323 = model.AM324 = model.AM325 = model.AM326 = model.AM327 = model.AM328 = model.AM329 = 0;

                    model.AM298 = string.IsNullOrEmpty( daPqo.Compute( "SUM(JM)" ,"JM14='外购' AND JM09='胶合板' AND JM93='E0' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(JM)" ,"JM14='外购' AND JM09='胶合板' AND JM93='E0' AND JM107='F'" ).ToString( ) );
                    model.AM299 = string.IsNullOrEmpty( daPqo.Compute( "SUM(AK)" ,"JM14='外购' AND JM09='胶合板' AND JM93='E0' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(AK)" ,"JM14='外购' AND JM09='胶合板' AND JM93='E0' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM300 = string.IsNullOrEmpty( daPqo.Compute( "SUM(JM)" ,"JM14='外购' AND JM09='胶合板' AND JM93='E0' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(JM)" ,"JM14='外购' AND JM09='胶合板' AND JM93='E0' AND JM107='T'" ).ToString( ) );
                    model.AM303 = string.IsNullOrEmpty( daPqo.Compute( "SUM(AK)" ,"JM14='外购' AND JM09='胶合板' AND JM93='E0' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(AK)" ,"JM14='外购' AND JM09='胶合板' AND JM93='E0' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM307 = string.IsNullOrEmpty( daPqo.Compute( "SUM(JM)" ,"JM14='外购' AND JM09='胶合板' AND JM93='E1' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(JM)" ,"JM14='外购' AND JM09='胶合板' AND JM93='E1' AND JM107='F'" ).ToString( ) );
                    model.AM308 = string.IsNullOrEmpty( daPqo.Compute( "SUM(AK)" ,"JM14='外购' AND JM09='胶合板' AND JM93='E1' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(AK)" ,"JM14='外购' AND JM09='胶合板' AND JM93='E1' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM320 = string.IsNullOrEmpty( daPqo.Compute( "SUM(JM)" ,"JM14='外购' AND JM09='胶合板' AND JM93='E1' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(JM)" ,"JM14='外购' AND JM09='胶合板' AND JM93='E1' AND JM107='T'" ).ToString( ) );
                    model.AM323 = string.IsNullOrEmpty( daPqo.Compute( "SUM(AK)" ,"JM14='外购' AND JM09='胶合板' AND JM93='E1' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(AK)" ,"JM14='外购' AND JM09='胶合板' AND JM93='E1' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM301 = string.IsNullOrEmpty( daPqo.Compute( "SUM(JM)" ,"JM14='外购' AND JM09='密度板' AND JM93='E0' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(JM)" ,"JM14='外购' AND JM09='密度板' AND JM93='E0' AND JM107='F'" ).ToString( ) );
                    model.AM302 = string.IsNullOrEmpty( daPqo.Compute( "SUM(AK)" ,"JM14='外购' AND JM09='密度板' AND JM93='E0' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(AK)" ,"JM14='外购' AND JM09='密度板' AND JM93='E0' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM306 = string.IsNullOrEmpty( daPqo.Compute( "SUM(JM)" ,"JM14='外购' AND JM09='密度板' AND JM93='E0' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(JM)" ,"JM14='外购' AND JM09='密度板' AND JM93='E0' AND JM107='T'" ).ToString( ) );
                    model.AM309 = string.IsNullOrEmpty( daPqo.Compute( "SUM(AK)" ,"JM14='外购' AND JM09='密度板' AND JM93='E0' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(AK)" ,"JM14='外购' AND JM09='密度板' AND JM93='E0' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM311 = string.IsNullOrEmpty( daPqo.Compute( "SUM(JM)" ,"JM14='外购' AND JM09='密度板' AND JM93='E1' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(JM)" ,"JM14='外购' AND JM09='密度板' AND JM93='E1' AND JM107='F'" ).ToString( ) );
                    model.AM312 = string.IsNullOrEmpty( daPqo.Compute( "SUM(AK)" ,"JM14='外购' AND JM09='密度板' AND JM93='E1' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(AK)" ,"JM14='外购' AND JM09='密度板' AND JM93='E1' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM324 = string.IsNullOrEmpty( daPqo.Compute( "SUM(JM)" ,"JM14='外购' AND JM09='密度板' AND JM93='E1' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(JM)" ,"JM14='外购' AND JM09='密度板' AND JM93='E1' AND JM107='T'" ).ToString( ) );
                    model.AM325 = string.IsNullOrEmpty( daPqo.Compute( "SUM(AK)" ,"JM14='外购' AND JM09='密度板' AND JM93='E1' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(AK)" ,"JM14='外购' AND JM09='密度板' AND JM93='E1' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM304 = string.IsNullOrEmpty( daPqo.Compute( "SUM(JM)" ,"JM14='库存' AND JM09='胶合板' AND JM93='E0' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(JM)" ,"JM14='库存' AND JM09='胶合板' AND JM93='E0' AND JM107='F'" ).ToString( ) );
                    model.AM305 = string.IsNullOrEmpty( daPqo.Compute( "SUM(AK)" ,"JM14='库存' AND JM09='胶合板' AND JM93='E0' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(AK)" ,"JM14='库存' AND JM09='胶合板' AND JM93='E0' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM313 = string.IsNullOrEmpty( daPqo.Compute( "SUM(JM)" ,"JM14='库存' AND JM09='胶合板' AND JM93='E0' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(JM)" ,"JM14='库存' AND JM09='胶合板' AND JM93='E0' AND JM107='T'" ).ToString( ) );
                    model.AM317 = string.IsNullOrEmpty( daPqo.Compute( "SUM(AK)" ,"JM14='库存' AND JM09='胶合板' AND JM93='E0' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(AK)" ,"JM14='库存' AND JM09='胶合板' AND JM93='E0' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM315 = string.IsNullOrEmpty( daPqo.Compute( "SUM(JM)" ,"JM14='库存' AND JM09='胶合板' AND JM93='E1' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(JM)" ,"JM14='库存' AND JM09='胶合板' AND JM93='E1' AND JM107='F'" ).ToString( ) );
                    model.AM316 = string.IsNullOrEmpty( daPqo.Compute( "SUM(AK)" ,"JM14='库存' AND JM09='胶合板' AND JM93='E1' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(AK)" ,"JM14='库存' AND JM09='胶合板' AND JM93='E1' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM326 = string.IsNullOrEmpty( daPqo.Compute( "SUM(JM)" ,"JM14='库存' AND JM09='胶合板' AND JM93='E1' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(JM)" ,"JM14='库存' AND JM09='胶合板' AND JM93='E1' AND JM107='T'" ).ToString( ) );
                    model.AM327 = string.IsNullOrEmpty( daPqo.Compute( "SUM(AK)" ,"JM14='库存' AND JM09='胶合板' AND JM93='E1' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(AK)" ,"JM14='库存' AND JM09='胶合板' AND JM93='E1' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM318 = string.IsNullOrEmpty( daPqo.Compute( "SUM(JM)" ,"JM14='库存' AND JM09='密度板' AND JM93='E0' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(JM)" ,"JM14='库存' AND JM09='密度板' AND JM93='E0' AND JM107='F'" ) .ToString( ) );
                    model.AM319 = string.IsNullOrEmpty( daPqo.Compute( "SUM(AK)" ,"JM14='库存' AND JM09='密度板' AND JM93='E0' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(AK)" ,"JM14='库存' AND JM09='密度板' AND JM93='E0' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM328 = string.IsNullOrEmpty( daPqo.Compute( "SUM(JM)" ,"JM14='库存' AND JM09='密度板' AND JM93='E0' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(JM)" ,"JM14='库存' AND JM09='密度板' AND JM93='E0' AND JM107='T'" ) .ToString( ) );
                    model.AM329 = string.IsNullOrEmpty( daPqo.Compute( "SUM(AK)" ,"JM14='库存' AND JM09='密度板' AND JM93='E0' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(AK)" ,"JM14='库存' AND JM09='密度板' AND JM93='E0' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM321 = string.IsNullOrEmpty( daPqo.Compute( "SUM(JM)" ,"JM14='库存' AND JM09='密度板' AND JM93='E1' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(JM)" ,"JM14='库存' AND JM09='密度板' AND JM93='E1' AND JM107='F'" ) .ToString( ) );
                    model.AM322 = string.IsNullOrEmpty( daPqo.Compute( "SUM(AK)" ,"JM14='库存' AND JM09='密度板' AND JM93='E1' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(AK)" ,"JM14='库存' AND JM09='密度板' AND JM93='E1' AND JM107='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM296 = string.IsNullOrEmpty( daPqo.Compute( "SUM(JM)" ,"JM14='库存' AND JM09='密度板' AND JM93='E1' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(JM)" ,"JM14='库存' AND JM09='密度板' AND JM93='E1' AND JM107='T'" ) .ToString( ) );
                    model.AM297 = string.IsNullOrEmpty( daPqo.Compute( "SUM(AK)" ,"JM14='库存' AND JM09='密度板' AND JM93='E1' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqo.Compute( "SUM(AK)" ,"JM14='库存' AND JM09='密度板' AND JM93='E1' AND JM107='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                }
            }
            else
                model.AM296 = model.AM297 = model.AM298 = model.AM299 = model.AM307 = model.AM308 = model.AM301 = model.AM302 = model.AM311 = model.AM312 = model.AM304 = model.AM305 = model.AM315 = model.AM316 = model.AM318 = model.AM319 = model.AM321 = model.AM322 = model.AM300 = model.AM309 = model.AM303 = model.AM313 = model.AM306 = model.AM317 = model.AM320 = model.AM321 = model.AM322 = model.AM323 = model.AM324 = model.AM325 = model.AM326 = model.AM327 = model.AM328 = model.AM329 = 0;
            #endregion
            
            #region 339
            DataTable daPqi = bll.GetDataTablePqi( model.AM002 );
            if ( daPqi != null && daPqi.Rows.Count > 0 )
            {
                try
                {
                    bll.UpdatePqi( model );
                }
                catch ( Exception ex ) { AutoUpdate . LogHelper . WriteLog ( "241 339 " + ex . Message + ex . StackTrace ); throw new Exception ( "339：" + ex . Message ); }
                finally
                {
                    model.AM175 = model.AM176 = model.AM178 = model.AM179 = model.AM182 = model.AM183 = model.AM185 = model.AM186 = model.AM188 = model.AM189 = model.AM191 = model.AM192 = model.AM194 = model.AM195 = model.AM197 = model.AM198 = model.AM177 = model.AM180 = model.AM184 = model.AM187 = model.AM190 = model.AM193 = model.AM196 = model.AM199 = model.AM200 = model.AM201 = model.AM203 = model.AM204 = model.AM205 = model.AM206 = model.AM207 = model.AM208 = 0;
                    model.AM175 = string.IsNullOrEmpty( daPqi.Compute( "SUM(YQ)" ,"YQ123='F' AND YQ12='水性漆一类' AND YQ101='外购'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(YQ)" ,"YQ123='F' AND YQ12='水性漆一类' AND YQ101='外购'" ).ToString( ) );
                    model.AM176 = string.IsNullOrEmpty( daPqi.Compute( "SUM(AK)" ,"YQ123='F' AND YQ12='水性漆一类' AND YQ101='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(AK)" ,"YQ123='F' AND YQ12='水性漆一类' AND YQ101='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM177 = string.IsNullOrEmpty( daPqi.Compute( "SUM(YQ)" ,"YQ123='T' AND YQ12='水性漆一类' AND YQ101='外购'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(YQ)" ,"YQ123='T' AND YQ12='水性漆一类' AND YQ101='外购'" ).ToString( ) );
                    model.AM180 = string.IsNullOrEmpty( daPqi.Compute( "SUM(AK)" ,"YQ123='T' AND YQ12='水性漆一类' AND YQ101='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(AK)" ,"YQ123='T' AND YQ12='水性漆一类' AND YQ101='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM188 = string.IsNullOrEmpty( daPqi.Compute( "SUM(YQ)" ,"YQ123='F' AND YQ12='水性漆一类' AND YQ101='库存'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(YQ)" ,"YQ123='F' AND YQ12='水性漆一类' AND YQ101='库存'" ).ToString( ) );
                    model.AM189 = string.IsNullOrEmpty( daPqi.Compute( "SUM(AK)" ,"YQ123='F' AND YQ12='水性漆一类' AND YQ101='库存' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(AK)" ,"YQ123='F' AND YQ12='水性漆一类' AND YQ101='库存' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM200 = string.IsNullOrEmpty( daPqi.Compute( "SUM(YQ)" ,"YQ123='T' AND YQ12='水性漆一类' AND YQ101='库存'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(YQ)" ,"YQ123='T' AND YQ12='水性漆一类' AND YQ101='库存'" ).ToString( ) );
                    model.AM201 = string.IsNullOrEmpty( daPqi.Compute( "SUM(AK)" ,"YQ123='T' AND YQ12='水性漆一类' AND YQ101='库存' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(AK)" ,"YQ123='T' AND YQ12='水性漆一类' AND YQ101='库存' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM178 = string.IsNullOrEmpty( daPqi.Compute( "SUM(YQ)" ,"YQ123='F' AND YQ12='水性漆二类' AND YQ101='外购'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(YQ)" ,"YQ123='F' AND YQ12='水性漆二类' AND YQ101='外购'" ).ToString( ) );
                    model.AM179 = string.IsNullOrEmpty( daPqi.Compute( "SUM(AK)" ,"YQ123='F' AND YQ12='水性漆二类' AND YQ101='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(AK)" ,"YQ123='F' AND YQ12='水性漆二类' AND YQ101='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM184 = string.IsNullOrEmpty( daPqi.Compute( "SUM(YQ)" ,"YQ123='T' AND YQ12='水性漆二类' AND YQ101='外购'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(YQ)" ,"YQ123='T' AND YQ12='水性漆二类' AND YQ101='外购'" ).ToString( ) );
                    model.AM187 = string.IsNullOrEmpty( daPqi.Compute( "SUM(AK)" ,"YQ123='T' AND YQ12='水性漆二类' AND YQ101='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(AK)" ,"YQ123='T' AND YQ12='水性漆二类' AND YQ101='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM191 = string.IsNullOrEmpty( daPqi.Compute( "SUM(YQ)" ,"YQ123='F' AND YQ12='水性漆二类' AND YQ101='库存'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(YQ)" ,"YQ123='F' AND YQ12='水性漆二类' AND YQ101='库存'" ).ToString( ) );
                    model.AM192 = string.IsNullOrEmpty( daPqi.Compute( "SUM(AK)" ,"YQ123='F' AND YQ12='水性漆二类' AND YQ101='库存' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(AK)" ,"YQ123='F' AND YQ12='水性漆二类' AND YQ101='库存' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM203 = string.IsNullOrEmpty( daPqi.Compute( "SUM(YQ)" ,"YQ123='T' AND YQ12='水性漆二类' AND YQ101='库存'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(YQ)" ,"YQ123='T' AND YQ12='水性漆二类' AND YQ101='库存'" ).ToString( ) );
                    model.AM204 = string.IsNullOrEmpty( daPqi.Compute( "SUM(AK)" ,"YQ123='T' AND YQ12='水性漆二类' AND YQ101='库存' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(AK)" ,"YQ123='T' AND YQ12='水性漆二类' AND YQ101='库存' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM182 = string.IsNullOrEmpty( daPqi.Compute( "SUM(YQ)" ,"YQ123='F' AND YQ12='硝基漆' AND YQ101='外购'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(YQ)" ,"YQ123='F' AND YQ12='硝基漆' AND YQ101='外购'" ).ToString( ) );
                    model.AM183 = string.IsNullOrEmpty( daPqi.Compute( "SUM(AK)" ,"YQ123='F' AND YQ12='硝基漆' AND YQ101='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(AK)" ,"YQ123='F' AND YQ12='硝基漆' AND YQ101='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM190 = string.IsNullOrEmpty( daPqi.Compute( "SUM(YQ)" ,"YQ123='T' AND YQ12='硝基漆' AND YQ101='外购'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(YQ)" ,"YQ123='T' AND YQ12='硝基漆' AND YQ101='外购'" ).ToString( ) );
                    model.AM193 = string.IsNullOrEmpty( daPqi.Compute( "SUM(AK)" ,"YQ123='T' AND YQ12='硝基漆' AND YQ101='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(AK)" ,"YQ123='T' AND YQ12='硝基漆' AND YQ101='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM194 = string.IsNullOrEmpty( daPqi.Compute( "SUM(YQ)" ,"YQ123='F' AND YQ12='硝基漆' AND YQ101='库存'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(YQ)" ,"YQ123='F' AND YQ12='硝基漆' AND YQ101='库存'" ).ToString( ) );
                    model.AM195 = string.IsNullOrEmpty( daPqi.Compute( "SUM(AK)" ,"YQ123='F' AND YQ12='硝基漆' AND YQ101='库存' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(AK)" ,"YQ123='F' AND YQ12='硝基漆' AND YQ101='库存' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM205 = string.IsNullOrEmpty( daPqi.Compute( "SUM(YQ)" ,"YQ123='T' AND YQ12='硝基漆' AND YQ101='库存'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(YQ)" ,"YQ123='T' AND YQ12='硝基漆' AND YQ101='库存'" ).ToString( ) );
                    model.AM206 = string.IsNullOrEmpty( daPqi.Compute( "SUM(AK)" ,"YQ123='T' AND YQ12='硝基漆' AND YQ101='库存' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(AK)" ,"YQ123='T' AND YQ12='硝基漆' AND YQ101='库存' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM185 = string.IsNullOrEmpty( daPqi.Compute( "SUM(YQ)" ,"YQ123='F' AND YQ12='香蕉水' AND YQ101='外购'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(YQ)" ,"YQ123='F' AND YQ12='香蕉水' AND YQ101='外购'" ).ToString( ) );
                    model.AM186 = string.IsNullOrEmpty( daPqi.Compute( "SUM(AK)" ,"YQ123='F' AND YQ12='香蕉水' AND YQ101='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(AK)" ,"YQ123='F' AND YQ12='香蕉水' AND YQ101='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM196 = string.IsNullOrEmpty( daPqi.Compute( "SUM(YQ)" ,"YQ123='T' AND YQ12='香蕉水' AND YQ101='外购'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(YQ)" ,"YQ123='T' AND YQ12='香蕉水' AND YQ101='外购'" ).ToString( ) );
                    model.AM199 = string.IsNullOrEmpty( daPqi.Compute( "SUM(AK)" ,"YQ123='T' AND YQ12='香蕉水' AND YQ101='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(AK)" ,"YQ123='T' AND YQ12='香蕉水' AND YQ101='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM197 = string.IsNullOrEmpty( daPqi.Compute( "SUM(YQ)" ,"YQ123='F' AND YQ12='香蕉水' AND YQ101='库存'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(YQ)" ,"YQ123='F' AND YQ12='香蕉水' AND YQ101='库存'" ).ToString( ) );
                    model.AM198 = string.IsNullOrEmpty( daPqi.Compute( "SUM(AK)" ,"YQ123='F' AND YQ12='香蕉水' AND YQ101='库存' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(AK)" ,"YQ123='F' AND YQ12='香蕉水' AND YQ101='库存' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM197 = string.IsNullOrEmpty( daPqi.Compute( "SUM(YQ)" ,"YQ123='T' AND YQ12='香蕉水' AND YQ101='库存'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(YQ)" ,"YQ123='T' AND YQ12='香蕉水' AND YQ101='库存'" ).ToString( ) );
                    model.AM198 = string.IsNullOrEmpty( daPqi.Compute( "SUM(AK)" ,"YQ123='T' AND YQ12='香蕉水' AND YQ101='库存' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqi.Compute( "SUM(AK)" ,"YQ123='T' AND YQ12='香蕉水' AND YQ101='库存' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                }
            }
            else
                model.AM175 = model.AM176 = model.AM178 = model.AM179 = model.AM182 = model.AM183 = model.AM185 = model.AM186 = model.AM188 = model.AM189 = model.AM191 = model.AM192 = model.AM194 = model.AM195 = model.AM197 = model.AM198 = model.AM177 = model.AM180 = model.AM184 = model.AM187 = model.AM190 = model.AM193 = model.AM196 = model.AM199 = model.AM200 = model.AM201 = model.AM203 = model.AM204 = model.AM205 = model.AM206 = model.AM207 = model.AM208 = 0;
            #endregion

            #region 285
            DataTable daPqk = bll . GetDataTablePqk ( model . AM002 );
            if ( daPqk != null && daPqk . Rows . Count > 0 )
            {
                try
                {
                    bll . UpdatePqk ( model );
                }
                catch ( Exception ex ) { AutoUpdate . LogHelper . WriteLog ( "241 285 " + ex . Message + ex . StackTrace ); throw new Exception ( "285：" + ex . Message ); }
                finally
                {
                    model . AM173 = 0;
                    model . AM173 = string . IsNullOrEmpty ( daPqk . Compute ( "SUM(PQK)" , null ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqk . Compute ( "SUM(PQK)" , null ) . ToString ( ) );
                }
            }else
                model . AM173 = 0;
            #endregion

            #region 341          
            DataTable daPqv = bll.GetDataTablePqv( model.AM002 );
            if ( daPqv != null && daPqv . Rows . Count > 0 )
            {
                try
                {
                    bll . UpdatePqv ( model );
                }
                catch ( Exception ex ) { AutoUpdate . LogHelper . WriteLog ( "241 341 " + ex . Message + ex . StackTrace ); throw new Exception ( "342：" + ex . Message ); }
                finally
                {
                    model . AM261 = model . AM262 = model . AM263 = model . AM264 = model . AM265 = model . AM266 = model . AM267 = model . AM268 = model . AM269 = model . AM287 = model . AM288 = model . AM289 = model . AM290 = model . AM291 = model . AM292 = model . AM293 = model . AM294 = model . AM295 = model . AM330 = model . AM331 = model . AM332 = model . AM333 = model . AM334 = model . AM335 = model . AM336 = model . AM337 = model . AM338 = model . AM339 = model . AM340 = model . AM341 = model . AM343 = model . AM344 = model . AM345 = model . AM346 = model . AM347 = model . AM348 = model . AM349 = model . AM350 = model . AM351 = model . AM352 = model . AM353 = model . AM354 = model . AM355 = model . AM356 = model . AM357 = model . AM358 = model . AM359 = model . AM360 = model . AM361 = model . AM362 = model . AM363 = model . AM364 = model . AM365 = model . AM366 = model . AM367 = model . AM368 = model . AM369 = model . AM370 = model . AM371 = model . AM372 = model . AM373 = model . AM374 = model . AM375 = model . AM376 = model . AM377 = model . AM378 = model . AM379 = model . AM380 = model . AM381 = model . AM382 = model . AM383 = model . AM385 = model . AM386 = model . AM387 = model . AM388 = model . AM389 = model . AM390 = model . AM391 = model . AM392 = model . AM393 = model . AM157 = model . AM158 = model . AM153 = model . AM154 = model . AM155 = model . AM156 = 0;

                    model . AM153 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='杨木' AND PQV88='F' AND PQV65='外购'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='杨木' AND PQV88='F' AND PQV65='外购'" ) . ToString ( ) );
                    model . AM154 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='杨木' AND PQV88='F' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='杨木' AND PQV88='F' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM155 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='杨木' AND PQV88='T' AND PQV65='外购'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='杨木' AND PQV88='T' AND PQV65='外购'" ) . ToString ( ) );
                    model . AM156 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='杨木' AND PQV88='T' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='杨木' AND PQV88='T' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );

                    model . AM157 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='杨木' AND PQV88='F' AND PQV65='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='杨木' AND PQV88='F' AND PQV65='库存'" ) . ToString ( ) );
                    model . AM158 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='杨木' AND PQV88='T' AND PQV65='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='杨木' AND PQV88='T' AND PQV65='库存'" ) . ToString ( ) );

                    model . AM339 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='T' AND PQV86='新西兰松' AND PQV88='F'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='T' AND PQV86='新西兰松' AND PQV88='F'" ) . ToString ( ) );
                    model . AM340 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='T' AND PQV86='新西兰松' AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='T' AND PQV86='新西兰松' AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM345 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='T' AND PQV86='新西兰松' AND PQV88='T'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='T' AND PQV86='新西兰松' AND PQV88='T'" ) . ToString ( ) );
                    model . AM348 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='T' AND PQV86='新西兰松' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='T' AND PQV86='新西兰松' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM364 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='T' AND PQV86='榉木' AND PQV88='F'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='T' AND PQV86='榉木' AND PQV88='F'" ) . ToString ( ) );
                    model . AM365 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='T' AND PQV86='榉木' AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='T' AND PQV86='榉木' AND PQV88='F' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM390 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='T' AND PQV86='榉木' AND PQV88='T'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='T' AND PQV86='榉木' AND PQV88='T'" ) . ToString ( ) );
                    model . AM393 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='T' AND PQV86='榉木' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='T' AND PQV86='榉木' AND PQV88='T' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM336 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='新西兰松' AND PQV88='F' AND PQV65='外购'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='新西兰松' AND PQV88='F' AND PQV65='外购'" ) . ToString ( ) );
                    model . AM337 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='新西兰松' AND PQV88='F' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='新西兰松' AND PQV88='F' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM338 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='新西兰松' AND PQV88='T' AND PQV65='外购'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='新西兰松' AND PQV88='T' AND PQV65='外购'" ) . ToString ( ) );
                    model . AM341 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='新西兰松' AND PQV88='T' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='新西兰松' AND PQV88='T' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM358 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='新西兰松' AND PQV88='F' AND PQV65='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='新西兰松' AND PQV88='F' AND PQV65='库存'" ) . ToString ( ) );
                    model . AM359 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='新西兰松' AND PQV88='F' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='新西兰松' AND PQV88='F' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM375 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='新西兰松' AND PQV88='T' AND PQV65='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='新西兰松' AND PQV88='T' AND PQV65='库存'" ) . ToString ( ) );
                    model . AM378 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='新西兰松' AND PQV88='T' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='新西兰松' AND PQV88='T' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM343 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='F' AND PQV65='外购'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='F' AND PQV65='外购'" ) . ToString ( ) );
                    model . AM344 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='F' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='F' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM351 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='T' AND PQV65='外购'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='T' AND PQV65='外购'" ) . ToString ( ) );
                    model . AM354 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='T' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='T' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    //model.AM361 = string.IsNullOrEmpty( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='F' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='F' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) );
                    //model.AM362 = string.IsNullOrEmpty( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='F' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='F' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) );
                    //model.AM381 = string.IsNullOrEmpty( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='T' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='T' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) );
                    //model.AM387 = string.IsNullOrEmpty( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='T' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='T' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) );
                    model . AM373 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='F' AND PQV65='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='F' AND PQV65='库存'" ) . ToString ( ) );
                    model . AM374 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='F' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='F' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM287 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='T' AND PQV65='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='T' AND PQV65='库存'" ) . ToString ( ) );
                    model . AM269 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='T' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='T' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    //model.AM376 = string.IsNullOrEmpty( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='F' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='F' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) );
                    //model.AM377 = string.IsNullOrEmpty( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='F' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='F' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) );
                    //model.AM367 = string.IsNullOrEmpty( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='T' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='T' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) );
                    //model.AM368 = string.IsNullOrEmpty( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='T' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='荷木' AND PQV88='T' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) );
                    model . AM352 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='F' AND PQV65='外购'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='F' AND PQV65='外购'" ) . ToString ( ) );
                    model . AM353 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='F' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='F' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM369 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='T' AND PQV65='外购'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='T' AND PQV65='外购'" ) . ToString ( ) );
                    model . AM372 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='T' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='T' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    //model.AM370 = string.IsNullOrEmpty( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='F' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='F' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) );
                    //model.AM371 = string.IsNullOrEmpty( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='F' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='F' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) );
                    //model.AM292 = string.IsNullOrEmpty( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='T' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='T' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) );
                    //model.AM293 = string.IsNullOrEmpty( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='T' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='T' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) );
                    model . AM391 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='F' AND PQV65='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='F' AND PQV65='库存'" ) . ToString ( ) );
                    model . AM392 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='F' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='F' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM361 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='T' AND PQV65='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='T' AND PQV65='库存'" ) . ToString ( ) );
                    model . AM362 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='T' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='T' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM349 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='F' AND PQV65='外购'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='F' AND PQV65='外购'" ) . ToString ( ) );
                    model . AM350 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='F' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='F' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM363 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='T' AND PQV65='外购'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='T' AND PQV65='外购'" ) . ToString ( ) );
                    model . AM366 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='T' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='T' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    //model.AM367 = string.IsNullOrEmpty( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='F' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='F' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) );
                    //model.AM368 = string.IsNullOrEmpty( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='F' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='F' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) );
                    //model.AM294 = string.IsNullOrEmpty( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='T' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='T' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) );
                    //model.AM295 = string.IsNullOrEmpty( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='T' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='T' AND PQV65='外购' AND PQV16='混水'" ).ToString( ) );
                    model . AM385 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='F' AND PQV65='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='F' AND PQV65='库存'" ) . ToString ( ) );
                    model . AM386 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='F' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='F' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM382 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='T' AND PQV65='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='T' AND PQV65='库存'" ) . ToString ( ) );
                    model . AM383 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='T' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='T' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    //model.AM388 = string.IsNullOrEmpty( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='F' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='F' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) );
                    //model.AM389 = string.IsNullOrEmpty( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='F' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='F' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) );
                    //model.AM263 = string.IsNullOrEmpty( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='T' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='T' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) );
                    //model.AM264 = string.IsNullOrEmpty( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='T' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='椴木' AND PQV88='T' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) );
                    model . AM346 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='榉木' AND PQV88='F' AND PQV65='外购'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='榉木' AND PQV88='F' AND PQV65='外购'" ) . ToString ( ) );
                    model . AM347 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='榉木' AND PQV88='F' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='榉木' AND PQV88='F' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM357 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='榉木' AND PQV88='T' AND PQV65='外购'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='榉木' AND PQV88='T' AND PQV65='外购'" ) . ToString ( ) );
                    model . AM360 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='榉木' AND PQV88='T' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='榉木' AND PQV88='T' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM379 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='榉木' AND PQV88='F' AND PQV65='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='榉木' AND PQV88='F' AND PQV65='库存'" ) . ToString ( ) );
                    model . AM380 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='榉木' AND PQV88='F' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='榉木' AND PQV88='F' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM265 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='榉木' AND PQV88='T' AND PQV65='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='榉木' AND PQV88='T' AND PQV65='库存'" ) . ToString ( ) );
                    model . AM266 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='榉木' AND PQV88='T' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='榉木' AND PQV88='T' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    //model.AM333 = string.IsNullOrEmpty( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='F' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='F' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) );
                    //model.AM334 = string.IsNullOrEmpty( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='F' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='F' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) );
                    //model.AM288 = string.IsNullOrEmpty( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='T' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(PQV)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='T' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) );
                    //model.AM289 = string.IsNullOrEmpty( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='T' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqv.Compute( "SUM(AK)" ,"PQV92='F' AND PQV86='桦木' AND PQV88='T' AND PQV65='库存' AND PQV16='混水'" ).ToString( ) );
                    model . AM355 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='杂木' AND PQV88='F' AND PQV65='外购'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='杂木' AND PQV88='F' AND PQV65='外购'" ) . ToString ( ) );
                    model . AM356 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='杂木' AND PQV88='F' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='杂木' AND PQV88='F' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM332 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='杂木' AND PQV88='T' AND PQV65='外购'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='杂木' AND PQV88='T' AND PQV65='外购'" ) . ToString ( ) );
                    model . AM335 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='杂木' AND PQV88='T' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='杂木' AND PQV88='T' AND PQV65='外购' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM330 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='杂木' AND PQV88='F' AND PQV65='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='杂木' AND PQV88='F' AND PQV65='库存'" ) . ToString ( ) );
                    model . AM331 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='杂木' AND PQV88='F' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='杂木' AND PQV88='F' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM290 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='杂木' AND PQV88='T' AND PQV65='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(PQV)" ,"PQV92='F' AND PQV86='杂木' AND PQV88='T' AND PQV65='库存'" ) . ToString ( ) );
                    model . AM291 = string . IsNullOrEmpty ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='杂木' AND PQV88='T' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqv . Compute ( "SUM(AK)" ,"PQV92='F' AND PQV86='杂木' AND PQV88='T' AND PQV65='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );

                }
            }
            else
                model . AM261 = model . AM262 = model . AM263 = model . AM264 = model . AM265 = model . AM266 = model . AM267 = model . AM268 = model . AM269 = model . AM287 = model . AM288 = model . AM289 = model . AM290 = model . AM291 = model . AM292 = model . AM293 = model . AM294 = model . AM295 = model . AM330 = model . AM331 = model . AM332 = model . AM333 = model . AM334 = model . AM335 = model . AM336 = model . AM337 = model . AM338 = model . AM339 = model . AM340 = model . AM341 = model . AM343 = model . AM344 = model . AM345 = model . AM346 = model . AM347 = model . AM348 = model . AM349 = model . AM350 = model . AM351 = model . AM352 = model . AM353 = model . AM354 = model . AM355 = model . AM356 = model . AM357 = model . AM358 = model . AM359 = model . AM360 = model . AM361 = model . AM362 = model . AM363 = model . AM364 = model . AM365 = model . AM366 = model . AM367 = model . AM368 = model . AM369 = model . AM370 = model . AM371 = model . AM372 = model . AM373 = model . AM374 = model . AM375 = model . AM376 = model . AM377 = model . AM378 = model . AM379 = model . AM380 = model . AM381 = model . AM382 = model . AM383 = model . AM385 = model . AM386 = model . AM387 = model . AM388 = model . AM389 = model . AM390 = model . AM391 = model . AM392 = model . AM393 = model . AM157 = model . AM158 = model . AM153 = model . AM154 = model . AM155 = model . AM156 = 0;
            #endregion
            
            #region 342           
            DataTable daPqaf = bll.GetDataTablePqaf( model.AM002 );
            if ( daPqaf != null && daPqaf.Rows.Count > 0 )
            {
                try
                {
                    bll.UpdatePqaf( model );
                }
                catch ( Exception ex ) { AutoUpdate . LogHelper . WriteLog ( "241 341 " + ex . Message + ex . StackTrace ); throw new Exception ( "342：" + ex . Message ); }
                finally
                {
                    model.AM270 = model.AM271 = model.AM273 = model.AM274 = model.AM277 = model.AM278 = model.AM280 = model.AM281 = model.AM272 = model.AM275 = model.AM279 = model.AM282 = model.AM283 = model.AM284 = model.AM285 = model.AM286 = 0;
                    model.AM270 = string.IsNullOrEmpty( daPqaf.Compute( "SUM(AF)" ,"AF016='外购' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqaf.Compute( "SUM(AF)" ,"AF016='外购' AND AF078='F'" ).ToString( ) );
                    model.AM271 = string.IsNullOrEmpty( daPqaf.Compute( "SUM(AK)" ,"AF016='外购' AND AF078='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqaf.Compute( "SUM(AK)" ,"AF016='外购' AND AF078='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM272 = string.IsNullOrEmpty( daPqaf.Compute( "SUM(AF)" ,"AF016='外购' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqaf.Compute( "SUM(AF)" ,"AF016='外购' AND AF078='T'" ).ToString( ) );
                    model.AM275 = string.IsNullOrEmpty( daPqaf.Compute( "SUM(AK)" ,"AF016='外购' AND AF078='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqaf.Compute( "SUM(AK)" ,"AF016='外购' AND AF078='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    //model.AM273 = string.IsNullOrEmpty( daPqaf.Compute( "SUM(AF)" ,"AF016='外购' AND AF026='混水' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqaf.Compute( "SUM(AF)" ,"AF016='外购' AND AF026='混水' AND AF078='F'" ).ToString( ) );
                    //model.AM274 = string.IsNullOrEmpty( daPqaf.Compute( "SUM(AK)" ,"AF016='外购' AND AF026='混水' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqaf.Compute( "SUM(AK)" ,"AF016='外购' AND AF026='混水' AND AF078='F'" ).ToString( ) );
                    //model.AM279 = string.IsNullOrEmpty( daPqaf.Compute( "SUM(AF)" ,"AF016='外购' AND AF026='混水' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqaf.Compute( "SUM(AF)" ,"AF016='外购' AND AF026='混水' AND AF078='T'" ).ToString( ) );
                    //model.AM282 = string.IsNullOrEmpty( daPqaf.Compute( "SUM(AK)" ,"AF016='外购' AND AF026='混水' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqaf.Compute( "SUM(AK)" ,"AF016='外购' AND AF026='混水' AND AF078='T'" ).ToString( ) );
                    model.AM277 = string.IsNullOrEmpty( daPqaf.Compute( "SUM(AF)" ,"AF016='库存' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqaf.Compute( "SUM(AF)" ,"AF016='库存' AND AF078='F'" ).ToString( ) );
                    model.AM278 = string.IsNullOrEmpty( daPqaf.Compute( "SUM(AK)" ,"AF016='库存' AND AF078='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqaf.Compute( "SUM(AK)" ,"AF016='库存' AND AF078='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM283 = string.IsNullOrEmpty( daPqaf.Compute( "SUM(AF)" ,"AF016='库存' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqaf.Compute( "SUM(AF)" ,"AF016='库存' AND AF078='T'" ).ToString( ) );
                    model.AM284 = string.IsNullOrEmpty( daPqaf.Compute( "SUM(AK)" ,"AF016='库存' AND AF078='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqaf.Compute( "SUM(AK)" ,"AF016='库存' AND AF078='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    //model.AM280 = string.IsNullOrEmpty( daPqaf.Compute( "SUM(AF)" ,"AF016='库存' AND AF026='混水' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqaf.Compute( "SUM(AF)" ,"AF016='库存' AND AF026='混水' AND AF078='F'" ).ToString( ) );
                    //model.AM281 = string.IsNullOrEmpty( daPqaf.Compute( "SUM(AK)" ,"AF016='库存' AND AF026='混水' AND AF078='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqaf.Compute( "SUM(AK)" ,"AF016='库存' AND AF026='混水' AND AF078='F'" ).ToString( ) );
                    //model.AM285 = string.IsNullOrEmpty( daPqaf.Compute( "SUM(AF)" ,"AF016='库存' AND AF026='混水' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqaf.Compute( "SUM(AF)" ,"AF016='库存' AND AF026='混水' AND AF078='T'" ).ToString( ) );
                    //model.AM286 = string.IsNullOrEmpty( daPqaf.Compute( "SUM(AK)" ,"AF016='库存' AND AF026='混水' AND AF078='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqaf.Compute( "SUM(AK)" ,"AF016='库存' AND AF026='混水' AND AF078='T'" ).ToString( ) );
                }
            }
            else
                model.AM270 = model.AM271 = model.AM273 = model.AM274 = model.AM277 = model.AM278 = model.AM280 = model.AM281 = model.AM272 = model.AM275 = model.AM279 = model.AM282 = model.AM283 = model.AM284 = model.AM285 = model.AM286 = 0;
            #endregion

            #region 343           
            DataTable daPqu = bll.GetDataTablePqu( model.AM002 );
            if ( daPqu != null && daPqu.Rows.Count > 0 )
            {
                try
                {
                    bll.UpdatePqu( model );
                }
                catch ( Exception ex ) { AutoUpdate . LogHelper . WriteLog ( "241 341 " + ex . Message + ex . StackTrace ); throw new Exception ( "343：" + ex . Message ); }
                finally
                {
                    model.AM209 = model.AM210 = model.AM211 = model.AM214 = model . AM225 = model . AM226 = model . AM227 = model . AM228 = 0;
                    model.AM209 = string.IsNullOrEmpty( daPqu.Compute( "sum(PQ)" ,"PQU107='F' AND PQU19='外购'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqu.Compute( "sum(PQ)" , "PQU107='F' AND PQU19='外购'" ) .ToString( ) );
                    model.AM210 = string.IsNullOrEmpty( daPqu.Compute( "sum(AK)" ,"PQU107='F' AND PQU19='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqu.Compute( "sum(AK)" ,"PQU107='F' AND PQU19='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM211 = string.IsNullOrEmpty( daPqu.Compute( "sum(PQ)" , "PQU107='T' AND PQU19='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqu.Compute( "sum(PQ)" , "PQU107='T' AND PQU19='外购'" ) .ToString( ) );
                    model.AM214 = string.IsNullOrEmpty( daPqu.Compute( "sum(AK)" ,"PQU107='T' AND PQU19='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqu.Compute( "sum(AK)" ,"PQU107='T' AND PQU19='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model . AM225 = string . IsNullOrEmpty ( daPqu . Compute ( "sum(PQ)" , "PQU107='F' AND PQU19='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqu . Compute ( "sum(PQ)" , "PQU107='F' AND PQU19='库存'" ) . ToString ( ) );
                    model . AM226 = string . IsNullOrEmpty ( daPqu . Compute ( "sum(AK)" ,"PQU107='F' AND PQU19='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqu . Compute ( "sum(AK)" ,"PQU107='F' AND PQU19='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM227 = string . IsNullOrEmpty ( daPqu . Compute ( "sum(PQ)" , "PQU107='T' AND PQU19='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqu . Compute ( "sum(PQ)" , "PQU107='T' AND PQU19='库存'" ) . ToString ( ) );
                    model . AM228 = string . IsNullOrEmpty ( daPqu . Compute ( "sum(AK)" ,"PQU107='T' AND PQU19='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqu . Compute ( "sum(AK)" ,"PQU107='T' AND PQU19='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                }
                #region
                /*
                signOfState = "";
                for ( int i = 0 ; i < daPqu.Rows.Count ; i++ )
                {
                    signOfState = daPqu.Rows[i]["PQU107"].ToString( ).Trim( );
                    if ( signOfState == "F" )
                    {
                        model.AM209 += string.IsNullOrEmpty( daPqu.Rows[i]["PQ"].ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqu.Rows[i]["PQ"].ToString( ) );
                        model.AM210 += string.IsNullOrEmpty( daPqu.Rows[i]["AK"].ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqu.Rows[i]["AK"].ToString( ) );
                    }
                    else if ( signOfState == "T" )
                    {
                        model.AM211 += string.IsNullOrEmpty( daPqu.Rows[i]["PQ"].ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqu.Rows[i]["PQ"].ToString( ) );
                        model.AM214 += string.IsNullOrEmpty( daPqu.Rows[i]["AK"].ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqu.Rows[i]["AK"].ToString( ) );
                    }
                }
                */
                #endregion
            }
            else
                model . AM209 = model . AM210 = model . AM211 = model . AM214 = model . AM225 = model . AM226 = model . AM227 = model . AM228 = 0;
            #endregion

            #region 347
            DataTable daPqs = bll.GetDataTablePqs( model.AM002 );
            if ( daPqs != null && daPqs.Rows.Count > 0 )
            {
                try
                {
                    bll.UpdatePqs( model );
                }
                catch ( Exception ex ) { AutoUpdate . LogHelper . WriteLog ( "241 341 " + ex . Message + ex . StackTrace ); throw new Exception ( "347：" + ex . Message ); }
                finally
                {
                    model.AM212 = model.AM213 = model.AM217 = model.AM220 = model.AM215 = model.AM216 = model.AM221 = model.AM222 = model.AM218 = model.AM219 = model.AM223 = model.AM224 = model . AM229 = model . AM230 = model . AM231 = model . AM232 = model . AM233 = model . AM234 = model . AM235 = model . AM236 = 0;

                    model.AM212 = string.IsNullOrEmpty( daPqs.Compute( "SUM(PQ)" , "PJ100='F' AND PJ105='塑料件' AND PJ15='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqs.Compute( "SUM(PQ)" , "PJ100='F' AND PJ105='塑料件' AND PJ15='外购'" ) .ToString( ) );
                    model.AM213 = string.IsNullOrEmpty( daPqs.Compute( "SUM(AK)" ,"PJ100='F' AND PJ105='塑料件' AND PJ15='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqs.Compute( "SUM(AK)" ,"PJ100='F' AND PJ105='塑料件' AND PJ15='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM217 = string.IsNullOrEmpty( daPqs.Compute( "SUM(PQ)" , "PJ100='T' AND PJ105='塑料件' AND PJ15='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqs.Compute( "SUM(PQ)" , "PJ100='T' AND PJ105='塑料件' AND PJ15='外购'" ) .ToString( ) );
                    model.AM220 = string.IsNullOrEmpty( daPqs.Compute( "SUM(AK)" ,"PJ100='T' AND PJ105='塑料件' AND PJ15='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqs.Compute( "SUM(AK)" ,"PJ100='T' AND PJ105='塑料件' AND PJ15='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM215 = string.IsNullOrEmpty( daPqs.Compute( "SUM(PQ)" , "PJ100='F' AND PJ105='其它材料' AND PJ15='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqs.Compute( "SUM(PQ)" , "PJ100='F' AND PJ105='其它材料' AND PJ15='外购'" ) .ToString( ) );
                    model.AM216 = string.IsNullOrEmpty( daPqs.Compute( "SUM(AK)" ,"PJ100='F' AND PJ105='其它材料' AND PJ15='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqs.Compute( "SUM(AK)" ,"PJ100='F' AND PJ105='其它材料' AND PJ15='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM221 = string.IsNullOrEmpty( daPqs.Compute( "SUM(PQ)" , "PJ100='T' AND PJ105='其它材料' AND PJ15='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqs.Compute( "SUM(PQ)" , "PJ100='T' AND PJ105='其它材料' AND PJ15='外购'" ) .ToString( ) );
                    model.AM222 = string.IsNullOrEmpty( daPqs.Compute( "SUM(AK)" ,"PJ100='T' AND PJ105='其它材料' AND PJ15='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqs.Compute( "SUM(AK)" ,"PJ100='T' AND PJ105='其它材料' AND PJ15='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model . AM229 = string . IsNullOrEmpty ( daPqs . Compute ( "SUM(PQ)" , "PJ100='F' AND PJ105='塑料件' AND PJ15='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqs . Compute ( "SUM(PQ)" , "PJ100='F' AND PJ105='塑料件' AND PJ15='库存'" ) . ToString ( ) );
                    model . AM230 = string . IsNullOrEmpty ( daPqs . Compute ( "SUM(AK)" ,"PJ100='F' AND PJ105='塑料件' AND PJ15='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqs . Compute ( "SUM(AK)" ,"PJ100='F' AND PJ105='塑料件' AND PJ15='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM231 = string . IsNullOrEmpty ( daPqs . Compute ( "SUM(PQ)" , "PJ100='T' AND PJ105='塑料件' AND PJ15='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqs . Compute ( "SUM(PQ)" , "PJ100='T' AND PJ105='塑料件' AND PJ15='库存'" ) . ToString ( ) );
                    model . AM232 = string . IsNullOrEmpty ( daPqs . Compute ( "SUM(AK)" ,"PJ100='T' AND PJ105='塑料件' AND PJ15='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqs . Compute ( "SUM(AK)" ,"PJ100='T' AND PJ105='塑料件' AND PJ15='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM233 = string . IsNullOrEmpty ( daPqs . Compute ( "SUM(PQ)" , "PJ100='F' AND PJ105='其它材料' AND PJ15='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqs . Compute ( "SUM(PQ)" , "PJ100='F' AND PJ105='其它材料' AND PJ15='库存'" ) . ToString ( ) );
                    model . AM234 = string . IsNullOrEmpty ( daPqs . Compute ( "SUM(AK)" ,"PJ100='F' AND PJ105='其它材料' AND PJ15='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqs . Compute ( "SUM(AK)" ,"PJ100='F' AND PJ105='其它材料' AND PJ15='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM235 = string . IsNullOrEmpty ( daPqs . Compute ( "SUM(PQ)" , "PJ100='T' AND PJ105='其它材料' AND PJ15='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqs . Compute ( "SUM(PQ)" , "PJ100='T' AND PJ105='其它材料' AND PJ15='库存'" ) . ToString ( ) );
                    model . AM236 = string . IsNullOrEmpty ( daPqs . Compute ( "SUM(AK)" ,"PJ100='T' AND PJ105='其它材料' AND PJ15='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqs . Compute ( "SUM(AK)" ,"PJ100='T' AND PJ105='其它材料' AND PJ15='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    //model.AM218 = string.IsNullOrEmpty( daPqs.Compute( "SUM(PQ)" ,"PJ100='F' AND PJ105='包装辅料'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqs.Compute( "SUM(PQ)" ,"PJ100='F' AND PJ105='包装辅料'" ).ToString( ) );
                    //model.AM219 = string.IsNullOrEmpty( daPqs.Compute( "SUM(AK)" ,"PJ100='F' AND PJ105='包装辅料'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqs.Compute( "SUM(AK)" ,"PJ100='F' AND PJ105='包装辅料'" ).ToString( ) );
                    //model.AM223 = string.IsNullOrEmpty( daPqs.Compute( "SUM(PQ)" ,"PJ100='T' AND PJ105='包装辅料'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqs.Compute( "SUM(PQ)" ,"PJ100='T' AND PJ105='包装辅料'" ).ToString( ) );
                    //model.AM224 = string.IsNullOrEmpty( daPqs.Compute( "SUM(AK)" ,"PJ100='T' AND PJ105='包装辅料'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqs.Compute( "SUM(AK)" ,"PJ100='T' AND PJ105='包装辅料'" ).ToString( ) );
                }
            }
            else
                model.AM212 = model.AM213 = model.AM217 = model.AM220 = model.AM215 = model.AM216 = model.AM221 = model.AM222 = model.AM218 = model.AM219 = model.AM223 = model.AM224 = model . AM229 = model . AM230 = model . AM231 = model . AM232 = model . AM233 = model . AM234 = model . AM235 = model . AM236 = 0;
            #endregion
            
            #region 349  348
            DataTable daPqt = bll.GetDataTablePqt( model.AM002 );
            if ( daPqt != null && daPqt.Rows.Count > 0 )
            {
                try
                {
                    bll.UpdatePqt( model );
                }
                catch ( Exception ex ) { AutoUpdate . LogHelper . WriteLog ( "241 341 " + ex . Message + ex . StackTrace ); throw new Exception ( "349：" + ex . Message ); }
                finally
                {
                    model.AM130 = model.AM131 = model.AM133 = model.AM134 = model.AM135 = model.AM136 = model.AM137 = model.AM138 = model.AM139 = model.AM140 = model.AM141 = model.AM142 = model.AM143 = model.AM144 = model.AM145 = model.AM146 = model.AM147 = model.AM148 = model.AM149 = model.AM150 = model . AM237 = model . AM238 = model . AM255 = model . AM256 = 0;

                    model.AM136 = string.IsNullOrEmpty( daPqt.Compute( "SUM(PQ)" ,"WX20='包装辅料' AND WX90='F' AND WX17='外购'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqt.Compute( "SUM(PQ)" , "WX20='包装辅料' AND WX90='F' AND WX17='外购'" ) .ToString( ) );
                    model.AM137 = string.IsNullOrEmpty( daPqt.Compute( "SUM(AK)" ,"WX20='包装辅料' AND WX90='F' AND WX17='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqt.Compute( "SUM(AK)" ,"WX20='包装辅料' AND WX90='F' AND WX17='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM138 = string.IsNullOrEmpty( daPqt.Compute( "SUM(PQ)" , "WX20='包装辅料' AND WX90='T' AND WX17='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqt.Compute( "SUM(PQ)" , "WX20='包装辅料' AND WX90='T' AND WX17='外购'" ) .ToString( ) );
                    model.AM141 = string.IsNullOrEmpty( daPqt.Compute( "SUM(AK)" ,"WX20='包装辅料' AND WX90='T' AND WX17='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqt.Compute( "SUM(AK)" ,"WX20='包装辅料' AND WX90='T' AND WX17='外购' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM145 = string.IsNullOrEmpty( daPqt.Compute( "SUM(PQ)" ,"WX20='内盒' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqt.Compute( "SUM(PQ)" ,"WX20='内盒' AND WX90='F'" ).ToString( ) );
                    model.AM146 = string.IsNullOrEmpty( daPqt.Compute( "SUM(AK)" ,"WX20='内盒' AND WX90='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqt.Compute( "SUM(AK)" ,"WX20='内盒' AND WX90='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM133 = string.IsNullOrEmpty( daPqt.Compute( "SUM(PQ)" ,"WX20='内盒' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqt.Compute( "SUM(PQ)" ,"WX20='内盒' AND WX90='T'" ).ToString( ) );
                    model.AM134 = string.IsNullOrEmpty( daPqt.Compute( "SUM(AK)" ,"WX20='内盒' AND WX90='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqt.Compute( "SUM(AK)" ,"WX20='内盒' AND WX90='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM139 = string.IsNullOrEmpty( daPqt.Compute( "SUM(PQ)" ,"WX20='外箱' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqt.Compute( "SUM(PQ)" ,"WX20='外箱' AND WX90='F'" ).ToString( ) );
                    model.AM140 = string.IsNullOrEmpty( daPqt.Compute( "SUM(AK)" ,"WX20='外箱' AND WX90='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqt.Compute( "SUM(AK)" ,"WX20='外箱' AND WX90='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM144 = string.IsNullOrEmpty( daPqt.Compute( "SUM(PQ)" ,"WX20='外箱' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqt.Compute( "SUM(PQ)" ,"WX20='外箱' AND WX90='T'" ).ToString( ) );
                    model.AM147 = string.IsNullOrEmpty( daPqt.Compute( "SUM(AK)" ,"WX20='外箱' AND WX90='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqt.Compute( "SUM(AK)" ,"WX20='外箱' AND WX90='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM142 = string.IsNullOrEmpty( daPqt.Compute( "SUM(PQ)" ,"WX20='中包' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqt.Compute( "SUM(PQ)" ,"WX20='中包' AND WX90='F'" ).ToString( ) );
                    model.AM143 = string.IsNullOrEmpty( daPqt.Compute( "SUM(AK)" ,"WX20='中包' AND WX90='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqt.Compute( "SUM(AK)" ,"WX20='中包' AND WX90='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM150 = string.IsNullOrEmpty( daPqt.Compute( "SUM(PQ)" ,"WX20='中包' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqt.Compute( "SUM(PQ)" ,"WX20='中包' AND WX90='T'" ).ToString( ) );
                    model.AM135 = string.IsNullOrEmpty( daPqt.Compute( "SUM(AK)" ,"WX20='中包' AND WX90='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqt.Compute( "SUM(AK)" ,"WX20='中包' AND WX90='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM148 = string.IsNullOrEmpty( daPqt.Compute( "SUM(PQ)" ,"WX20='彩盒' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqt.Compute( "SUM(PQ)" ,"WX20='彩盒' AND WX90='F'" ).ToString( ) );
                    model.AM149 = string.IsNullOrEmpty( daPqt.Compute( "SUM(AK)" ,"WX20='彩盒' AND WX90='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqt.Compute( "SUM(AK)" ,"WX20='彩盒' AND WX90='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM130 = string.IsNullOrEmpty( daPqt.Compute( "SUM(PQ)" ,"WX20='彩盒' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqt.Compute( "SUM(PQ)" ,"WX20='彩盒' AND WX90='T'" ).ToString( ) );
                    model.AM131 = string.IsNullOrEmpty( daPqt.Compute( "SUM(AK)" ,"WX20='彩盒' AND WX90='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqt.Compute( "SUM(AK)" ,"WX20='彩盒' AND WX90='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model . AM237 = string . IsNullOrEmpty ( daPqt . Compute ( "SUM(PQ)" , "WX20='包装辅料' AND WX90='F' AND WX17='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqt . Compute ( "SUM(PQ)" , "WX20='包装辅料' AND WX90='F' AND WX17='库存'" ) . ToString ( ) );
                    model . AM238 = string . IsNullOrEmpty ( daPqt . Compute ( "SUM(AK)" ,"WX20='包装辅料' AND WX90='F' AND WX17='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqt . Compute ( "SUM(AK)" ,"WX20='包装辅料' AND WX90='F' AND WX17='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                    model . AM255 = string . IsNullOrEmpty ( daPqt . Compute ( "SUM(PQ)" , "WX20='包装辅料' AND WX90='T' AND WX17='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqt . Compute ( "SUM(PQ)" , "WX20='包装辅料' AND WX90='T' AND WX17='库存'" ) . ToString ( ) );
                    model . AM256 = string . IsNullOrEmpty ( daPqt . Compute ( "SUM(AK)" ,"WX20='包装辅料' AND WX90='T' AND WX17='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqt . Compute ( "SUM(AK)" ,"WX20='包装辅料' AND WX90='T' AND WX17='库存' AND (AK017='执行' OR AK017='审核')" ) . ToString ( ) );
                }

            }
            else
                model.AM136 = model.AM137 = model.AM139 = model.AM140 = model.AM142 = model.AM143 = model.AM145 = model.AM146 = model.AM148 = model.AM149 = model.AM138 = model.AM141 = model.AM144 = model.AM147 = model.AM150 = model.AM135 = model.AM133 = model.AM134 = model.AM130 = model.AM131 = model . AM237 = model . AM238 = model . AM255 = model . AM256 = 0;
            #endregion

            #region 344 漆款厂外
            DataTable daPqmz = bll.GetDataTablePqlz( model.AM002 );
            if ( daPqmz.Rows.Count > 0 )
            {
                try
                {
                    bll.UpdatePqlz( model );
                }
                catch ( Exception ex ) { AutoUpdate . LogHelper . WriteLog ( "241 341 " + ex . Message + ex . StackTrace ); throw new Exception ( "344漆款厂外：" + ex . Message ); }
                finally
                {
                    model.AM242 = model.AM243 = model.AM247 = model.AM251 = model.AM245 = model.AM246 = model.AM252 = model.AM253 = 0M;
                    model.AM242 = string.IsNullOrEmpty( daPqmz.Compute( "sum(MZ2)" ,"MZ123='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqmz.Compute( "sum(MZ2)" ,"MZ123='F'" ).ToString( ) );
                    model.AM243 = string.IsNullOrEmpty( daPqmz.Compute( "sum(AK)" ,"MZ123='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqmz.Compute( "sum(AK)" ,"MZ123='F' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                    model.AM247 = string.IsNullOrEmpty( daPqmz.Compute( "sum(AK)" ,"MZ123='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqmz.Compute( "sum(AK)" ,"MZ123='T'" ).ToString( ) );
                    model.AM251 = string.IsNullOrEmpty( daPqmz.Compute( "sum(AK)" ,"MZ123='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqmz.Compute( "sum(AK)" ,"MZ123='T' AND (AK017='执行' OR AK017='审核')" ) .ToString( ) );
                }
            }
            else
                model.AM242 = model.AM243 = model.AM247 = model.AM251 = model.AM245 = model.AM246 = model.AM252 = model.AM253 = 0M;
            #endregion

            #region 344 漆款厂内
            DataTable daPqmzse = bll . GetDataTablePqmzs ( model . AM002 );
            if ( daPqmzse != null && daPqmzse . Rows . Count > 0 )
            {
                model . AM239 = model . AM240 = model . AM241 = model . AM244 = 0;
                model . AM239 = string . IsNullOrEmpty ( daPqmzse . Compute ( "SUM(MZ)" ,null ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqmzse . Compute ( "SUM(MZ)" ,null ) . ToString ( ) );
                model . AM240 = string . IsNullOrEmpty ( daPqmzse . Compute ( "SUM(MZ)" ,null ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqmzse . Compute ( "SUM(MZ)" ,null ) . ToString ( ) );
                model . AM241 = 0;
                model . AM244 = 0;
            }
            else
                model . AM239 = model . AM240 = model . AM241 = model . AM244 = 0;
            #endregion

            #region 346 漆款厂内
            DataTable daPqmzs = bll.GetDataTablePqlzs( model.AM002 );
            if ( daPqmzs != null && daPqmzs.Rows.Count > 0 )
            {
                model . AM248 = 0;
                model . AM248 = string . IsNullOrEmpty ( daPqmzs . Compute ( "SUM(PZ)" ,null ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqmzs . Compute ( "SUM(PZ)" ,null ) . ToString ( ) );
            }
            else
                model . AM248 = 0;
            #endregion

            #region 344 工资
            DataTable daPqlz = bll.GetDataTablePqmz( model.AM002 );
            if ( daPqlz.Rows.Count > 0 )
            {
                try
                {
                    bll.UpdatePqmz( model );
                }
                catch ( Exception ex ) { AutoUpdate . LogHelper . WriteLog ( "241 341 " + ex . Message + ex . StackTrace );throw new Exception ("344工资："+ ex . Message ); }
                finally
                {
                    model.AM249 = model.AM250 = 0M;
                    //model.AM249= daPqlz
                    model . AM249 = string . IsNullOrEmpty ( daPqlz . Compute ( "sum(MZ0)" ,null ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqlz . Compute ( "sum(MZ0)" ,null ) . ToString ( ) );
                    model . AM250 = string . IsNullOrEmpty ( daPqlz . Compute ( "sum(AK)" ,null ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( daPqlz . Compute ( "sum(AK)" ,null ) . ToString ( ) );
                    //model .AM249 += string.IsNullOrEmpty( daPqlz.Rows[0]["MZ0"].ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqlz.Rows[0]["MZ0"].ToString( ) );
                    //model.AM250 += string.IsNullOrEmpty( daPqlz.Rows[0]["AK"].ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqlz.Rows[0]["AK"].ToString( ) );
                }
            }
            else
                model.AM249 = model.AM250 = 0M;
            #endregion

            #region 243 运费
            DataTable daPqbe = bll.GetDataTablePqbe( model.AM002 );
            if ( daPqbe.Rows.Count > 0 )
            {
                model.AM020 = model.AM021 = string.IsNullOrEmpty( daPqbe.Rows[0]["BE007"].ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqbe.Rows[0]["BE007"].ToString( ) );
                model.AM022 = model.AM023 = string.IsNullOrEmpty( daPqbe.Rows[0]["BE008"].ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqbe.Rows[0]["BE008"].ToString( ) );
                model.AM024 = model.AM025 = string.IsNullOrEmpty( daPqbe.Rows[0]["BE009"].ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqbe.Rows[0]["BE009"].ToString( ) );
                model.AM026 = model.AM027 = string.IsNullOrEmpty( daPqbe.Rows[0]["BE010"].ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqbe.Rows[0]["BE010"].ToString( ) );
                model.AM028 = model.AM029 = string.IsNullOrEmpty( daPqbe.Rows[0]["BE011"].ToString( ) ) == true ? 0 : Convert.ToDecimal( daPqbe.Rows[0]["BE011"].ToString( ) );
            }
            else
                model.AM020 = model.AM021 = model.AM022 = model.AM023 = model.AM024 = model.AM025 = model.AM026 = model.AM027 = model.AM028 = model.AM029 = 0;
            #endregion

        }
        void build_One ( )
        {
            row["AM001"] = model.AM001;
            row["AM002"] = model.AM002;
            row["AM003"] = model.AM003;
            row["AM004"] = model.AM004;
            row["AM005"] = model.AM005;
            row["AM006"] = model.AM006;
            if ( model . AM007 != null )
                row [ "AM007" ] = model . AM007;
            else
                row [ "AM007" ] = DBNull . Value;
            row ["AM008"] = model.AM008;
            row["AM009"] = model.AM009;
            row["AM010"] = model.AM010;
            row["AM011"] = model.AM011;
            row["AM012"] = model.AM012;
            row["AM013"] = model.AM013;
            row["AM014"] = model.AM014;
            row["AM015"] = model.AM015;
            row["AM016"] = model.AM016;
            row["AM017"] = model.AM017;
            row["AM018"] = model.AM018;
            row["AM019"] = model.AM019;
            row["AM020"] = model.AM020;
            row["AM021"] = model.AM021;
            row["AM022"] = model.AM022;
            row["AM023"] = model.AM023;
            row["AM024"] = model.AM024;
            row["AM025"] = model.AM025;
            row["AM026"] = model.AM026;
            row["AM027"] = model.AM027;
            row["AM028"] = model.AM028;
            row["AM029"] = model.AM029;
            row["AM062"] = model.AM062;
            row["AM063"] = model.AM063;
            row["AM070"] = model.AM070;
            row["AM071"] = model.AM071;
            row["AM072"] = model.AM072;
            row["AM073"] = model.AM073;
            row["AM074"] = model.AM074;
            row["AM075"] = model.AM075;
            row["AM076"] = model.AM076;
            row["AM077"] = model.AM077;
            row["AM078"] = model.AM078;
            row["AM079"] = model.AM079;
            row["AM080"] = model.AM080;
            row["AM081"] = model.AM081;
            row["AM082"] = model.AM082;
            row["AM083"] = model.AM083;
            row["AM084"] = model.AM084;
            row["AM085"] = model.AM085;
            row["AM086"] = model.AM086;
            row["AM087"] = model.AM087;
            row["AM088"] = model.AM088;
            row["AM089"] = model.AM089;
            row["AM090"] = model.AM090;
            row["AM091"] = model.AM091;
            row["AM092"] = model.AM092;
            row["AM093"] = model.AM093;
            row["AM108"] = model.AM108;
            row["AM109"] = model.AM109;
            row["AM110"] = model.AM110;
            row["AM111"] = model.AM111;
            row["AM112"] = model.AM112;
            row["AM113"] = model.AM113;
            row["AM136"] = model.AM136;
            row["AM137"] = model.AM137;
            row["AM138"] = model.AM138;
            row["AM139"] = model.AM139;
            row["AM140"] = model.AM140;
            row["AM141"] = model.AM141;
            row["AM142"] = model.AM142;
            row["AM143"] = model.AM143;
            row["AM144"] = model.AM144;
            row["AM145"] = model.AM145;
            row["AM146"] = model.AM146;
            row["AM147"] = model.AM147;
            row["AM148"] = model.AM148;
            row["AM149"] = model.AM149;
            row["AM150"] = model.AM150;
            row [ "AM173" ] = model . AM173;
            row ["AM175"] = model.AM175;
            row["AM176"] = model.AM176;
            row["AM177"] = model.AM177;
            row["AM178"] = model.AM178;
            row["AM179"] = model.AM179;
            row["AM180"] = model.AM180;
            row["AM182"] = model.AM182;
            row["AM183"] = model.AM183;
            row["AM184"] = model.AM184;
            row["AM185"] = model.AM185;
            row["AM186"] = model.AM186;
            row["AM187"] = model.AM187;
            row["AM188"] = model.AM188;
            row["AM189"] = model.AM189;
            row["AM190"] = model.AM190;
            row["AM191"] = model.AM191;
            row["AM192"] = model.AM192;
            row["AM193"] = model.AM193;
            row["AM194"] = model.AM194;
            row["AM195"] = model.AM195;
            row["AM196"] = model.AM196;
            row["AM197"] = model.AM197;
            row["AM198"] = model.AM198;
            row["AM199"] = model.AM199;
            row["AM209"] = model.AM209;
            row["AM210"] = model.AM210;
            row["AM211"] = model.AM211;
            row["AM239"] = model.AM239;
            row["AM240"] = model.AM240;
            row["AM241"] = model.AM241;
            row["AM242"] = model.AM242;
            row["AM243"] = model.AM243;
            row["AM244"] = model.AM244;
            row["AM245"] = model.AM245;
            row["AM246"] = model.AM246;
            row["AM247"] = model.AM247;
            row["AM249"] = model.AM249;
            row["AM250"] = model.AM250;
            row["AM270"] = model.AM270;
            row["AM271"] = model.AM271;
            row["AM272"] = model.AM272;
            row["AM273"] = model.AM273;
            row["AM274"] = model.AM274;
            row["AM275"] = model.AM275;
            row["AM277"] = model.AM277;
            row["AM278"] = model.AM278;
            row["AM279"] = model.AM279;
            row["AM280"] = model.AM280;
            row["AM281"] = model.AM281;
            row["AM282"] = model.AM282;
            row["AM298"] = model.AM298;
            row["AM299"] = model.AM299;
            row["AM300"] = model.AM300;
            row["AM301"] = model.AM301;
            row["AM302"] = model.AM302;
            row["AM303"] = model.AM303;
            row["AM304"] = model.AM304;
            row["AM305"] = model.AM305;
            row["AM306"] = model.AM306;
            row["AM307"] = model.AM307;
            row["AM308"] = model.AM308;
            row["AM309"] = model.AM309;
            row["AM311"] = model.AM311;
            row["AM312"] = model.AM312;
            row["AM313"] = model.AM313;
            row["AM314"] = model.AM314;
            row["AM315"] = model.AM315;
            row["AM316"] = model.AM316;
            row["AM317"] = model.AM317;
            row["AM318"] = model.AM318;
            row["AM319"] = model.AM319;
            row["AM320"] = model.AM320;
            row["AM321"] = model.AM321;
            row["AM322"] = model.AM322;
            row["AM323"] = model.AM323;
            row["AM330"] = model.AM330;
            row["AM331"] = model.AM331;
            row["AM332"] = model.AM332;
            row["AM333"] = model.AM333;
            row["AM334"] = model.AM334;
            row["AM335"] = model.AM335;
            row["AM336"] = model.AM336;
            row["AM337"] = model.AM337;
            row["AM338"] = model.AM338;
            row["AM339"] = model.AM339;
            row["AM340"] = model.AM340;
            row["AM341"] = model.AM341;
            row["AM343"] = model.AM343;
            row["AM344"] = model.AM344;
            row["AM345"] = model.AM345;
            row["AM346"] = model.AM346;
            row["AM347"] = model.AM347;
            row["AM348"] = model.AM348;
            row["AM349"] = model.AM349;
            row["AM350"] = model.AM350;
            row["AM351"] = model.AM351;
            row["AM352"] = model.AM352;
            row["AM353"] = model.AM353;
            row["AM354"] = model.AM354;
            row["AM355"] = model.AM355;
            row["AM356"] = model.AM356;
            row["AM357"] = model.AM357;
            row["AM358"] = model.AM358;
            row["AM359"] = model.AM359;
            row["AM360"] = model.AM360;
            row["AM361"] = model.AM361;
            row["AM362"] = model.AM362;
            row["AM363"] = model.AM363;
            row["AM364"] = model.AM364;
            row["AM365"] = model.AM365;
            row["AM366"] = model.AM366;
            row["AM367"] = model.AM367;
            row["AM368"] = model.AM368;
            row["AM369"] = model.AM369;
            row["AM370"] = model.AM370;
            row["AM371"] = model.AM371;
            row["AM372"] = model.AM372;
            row["AM373"] = model.AM373;
            row["AM374"] = model.AM374;
            row["AM375"] = model.AM375;
            row["AM376"] = model.AM376;
            row["AM377"] = model.AM377;
            row["AM378"] = model.AM378;
            row["AM379"] = model.AM379;
            row["AM380"] = model.AM380;
            row["AM381"] = model.AM381;
            row["AM385"] = model.AM385;
            row["AM386"] = model.AM386;
            row["AM387"] = model.AM387;
            row["AM388"] = model.AM388;
            row["AM389"] = model.AM389;
            row["AM390"] = model.AM390;
            row["AM391"] = model.AM391;
            row["AM392"] = model.AM392;
            row["AM393"] = model.AM393;
        }
        #endregion
        
        #region Query
        SelectAll.ProductCostSummaryAll queryAll = new SelectAll.ProductCostSummaryAll( );
        protected override void select ( )
        {
            base.select( );

            queryAll.StartPosition = FormStartPosition.CenterScreen;
            //queryAll.PassDataBetweenForm += new SelectAll.ProductCostSummaryAll.PassDataBetweenFormHandler( queryAll_PassDataBetweenForm );
            if ( queryAll . ShowDialog ( ) == DialogResult . Cancel )
                return;
            list = queryAll . idxList;
            strWhere = "1=1";
            if ( list.Count > 0 )
            {
                string str = "''";
                foreach ( string item in list )
                {
                    if ( !string.IsNullOrEmpty( item ) )
                        str = str + ",'" + item + "'";
                }
                strWhere = strWhere + " AND idx IN (" + str + ")";
               
                refre ( );
                sign = "2";
                bandedGridView1.FocusedRowHandle = 0;
                
                toolAdd.Enabled = toolSelect.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolPrint.Enabled = toolReview.Enabled = toolExport.Enabled = toolMaintain.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled =  false;
            }
            else
                MessageBox.Show( "您没有选择任何信息" );
        }
        private void queryAll_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            list = e.List;
        }
        SelectAll.DailyCollectionRecordAll query = new SelectAll.DailyCollectionRecordAll( );
        private void button1_Click ( object sender ,EventArgs e )
        {
            query.signQuery = "1";
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.DailyCollectionRecordAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );

            if ( model.AM002 ==null )
                MessageBox.Show( "您没有选择任何内容" );
            else
                seleQuery( );
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            model.AM002 = e.ConOne;
            textBox4.Text = textBox20.Text = textBox23.Text = textBox50.Text = textBox81.Text = textBox121.Text = textBox153.Text = textBox195.Text = textBox231.Text = textBox264.Text = textBox297.Text = textBox327.Text = textBox366.Text = model.AM002;
        }
        void seleQuery ( )
        {
            strWhere = strWhere + " AND AE02='" + model.AM002 + "'";
            DataTable daOne = bll.GetDataTableOne( strWhere );
            if ( daOne.Rows.Count > 0 )
            {
                textBox3.Text = daOne.Rows[0]["AE03"].ToString( );
                textBox5.Text = daOne.Rows[0]["AE04"].ToString( );
                textBox6.Text = daOne.Rows[0]["AE05"].ToString( );
                textBox7.Text = textBox365.Text = textBox326.Text = textBox296.Text = textBox263.Text = textBox230.Text = textBox194.Text = textBox152.Text = textBox121.Text = textBox80.Text = textBox49.Text = textBox22.Text = textBox21.Text = textBox7.Text = daOne.Rows[0]["AE06"].ToString( );
                textBox13.Text= daOne.Rows[0]["AE08"].ToString( );
                textBox9.Text = daOne.Rows[0]["AE09"].ToString( );
                textBox10.Text= daOne.Rows[0]["AE07"].ToString( );
                textBox11.Text = daOne.Rows[0]["AE13"].ToString( );
                textBox8.Text = daOne.Rows[0]["AE37"].ToString( );
                textBox12.Text = daOne.Rows[0]["AE12"].ToString( );
                textBox1.Text = daOne.Rows[0]["DAA002"].ToString( );
            }
            strWhere = "1=1";
        }
        #endregion
        
        #region TextBoxEvent
        void gridControlDataToNull ( )
        {
            gridControl1.DataSource = null;
            gridControl2.DataSource = null;
            gridControl3.DataSource = null;
            gridControl4.DataSource = null;
            gridControl5.DataSource = null;
            gridControl6.DataSource = null;
            gridControl7.DataSource = null;
            gridControl8.DataSource = null;
            gridControl9.DataSource = null;
            gridControl10.DataSource = null;
            gridControl11.DataSource = null;
            gridControl12.DataSource = null;
            gridControl13.DataSource = null;
        }
        void textBoxKeypress ( )
        {
            foreach ( Control item in tabControl1.Controls )
            {
                if ( item.GetType( ) == typeof( TabPage ) )
                {
                    TabPage page = item as TabPage;
                    foreach ( Control spl in page.Controls )
                    {
                        if ( spl.GetType( ) == typeof( SplitContainer ) )
                        {
                            SplitContainer spli = spl as SplitContainer;
                            foreach ( Control sp in spli.Controls )
                            {
                                if ( sp.GetType( ) == typeof( SplitterPanel ) )
                                {
                                    SplitterPanel pan = sp as SplitterPanel;
                                    foreach ( Control con in pan.Controls )
                                    {
                                        if ( con.GetType( ) == typeof( GroupBox ) )
                                        {
                                            GroupBox box = con as GroupBox;
                                            foreach ( Control bo in box.Controls )
                                            {
                                                if ( bo.GetType( ) == typeof( TextBox ) )
                                                {
                                                    TextBox text = bo as TextBox;
                                                    if ( !listBox.Contains( text ) )
                                                    {
                                                        text.KeyPress += new KeyPressEventHandler( textBox_KeyPress );
                                                        text.TextChanged += new EventHandler( textBox_TextChanged );
                                                        text.LostFocus += new EventHandler( textBox_LostFocus );
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }  
                    }
                }
            }
        }
        private void textBox_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            TextBox box = ( TextBox ) sender;
            DateDayRegise.fractionTb( e ,box );
        }
        private void textBox_TextChanged ( object sender ,EventArgs e )
        {
            TextBox box = ( TextBox ) sender;
            DateDayRegise.textChangeTb( box );
        }
        private void textBox_LostFocus ( object sender ,EventArgs e )
        {
            TextBox box = ( TextBox ) sender;
            if ( box.Text != "" && !DateDayRegise.tenTwoNumber( box ) )
            {
                box.Text = "";
                MessageBox.Show( "只允许输入整数部分最多八位,小数部分最多两位,如99999999.99,请重新输入" );
            }
        }
        void listSuper ( )
        {
            listBox.Clear( );
            listBox.Add( textBox14 );
            listBox.Add( textBox15 );
            listBox.Add( textBox16 );
            listBox.Add( textBox17 );           
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
            if ( !string . IsNullOrEmpty ( textBox16 . Text ) && !DateDayRegise . elevenSixNumber ( textBox16 ) )
            {
                textBox16 . Text = "";
                MessageBox . Show ( "只允许输入整数部分最多五位,小数部分最多六位,如99999.999999,请重新输入" );
            }
        }
        private void textBox17_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox17 );
        }
        private void textBox17_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox17 );
        }
        private void textBox17_LostFocus ( object sender ,EventArgs e )
        {
            if ( !string . IsNullOrEmpty ( textBox17 . Text ) && !DateDayRegise . elevenSixNumber ( textBox17 ) )
            {
                textBox17 . Text = "";
                MessageBox . Show ( "只允许输入整数部分最多五位,小数部分最多六位,如99999.999999,请重新输入" );
            }
        }
        #endregion

        #region GridViewEvent
        string oddNum = "";
        private void bandedGridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView1.FocusedRowHandle >= 0 && bandedGridView1.FocusedRowHandle <= bandedGridView1.RowCount - 1 )
            {
                if ( !string.IsNullOrEmpty( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ))
                      model.Idx = Convert.ToInt32( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                textBox367.Text = textBox328.Text = textBox298.Text = textBox265.Text = textBox232.Text = textBox196.Text = textBox154.Text = textBox123.Text = textBox82.Text = textBox51.Text = textBox24.Text = textBox19.Text = textBox2.Text = model.Idx.ToString( );
                oddNum = bandedGridView1.GetFocusedRowCellValue( "AM002" ).ToString( );
                num = bandedGridView1.FocusedRowHandle;
                assignMent( );
            }
        }
        private void bandedGridView2_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView2.FocusedRowHandle >= 0 && bandedGridView2.FocusedRowHandle <= bandedGridView2.RowCount - 1 )
            {
                if ( !string.IsNullOrEmpty( bandedGridView2.GetFocusedRowCellValue( "idx" ).ToString( ) ) )
                    model.Idx = Convert.ToInt32( bandedGridView2.GetFocusedRowCellValue( "idx" ).ToString( ) );
                textBox367.Text = textBox328.Text = textBox298.Text = textBox265.Text = textBox232.Text = textBox196.Text = textBox154.Text = textBox123.Text = textBox82.Text = textBox51.Text = textBox24.Text = textBox19.Text = textBox2.Text = model.Idx.ToString( );
                oddNum = bandedGridView2.GetFocusedRowCellValue( "AM002" ).ToString( );
                num = bandedGridView2.FocusedRowHandle;
                assignMent( );
            }
        }
        private void bandedGridView3_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView3.FocusedRowHandle >= 0 && bandedGridView3.FocusedRowHandle <= bandedGridView3.RowCount - 1 )
            {
                if ( !string.IsNullOrEmpty( bandedGridView3.GetFocusedRowCellValue( "idx" ).ToString( ) ) )
                    model.Idx = Convert.ToInt32( bandedGridView3.GetFocusedRowCellValue( "idx" ).ToString( ) );
                textBox367.Text = textBox328.Text = textBox298.Text = textBox265.Text = textBox232.Text = textBox196.Text = textBox154.Text = textBox123.Text = textBox82.Text = textBox51.Text = textBox24.Text = textBox19.Text = textBox2.Text = model.Idx.ToString( );
                oddNum = bandedGridView3.GetFocusedRowCellValue( "AM002" ).ToString( );
                num = bandedGridView3.FocusedRowHandle;
                assignMent( );
            }
        }
        private void bandedGridView4_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView4.FocusedRowHandle >= 0 && bandedGridView4.FocusedRowHandle <= bandedGridView4.RowCount - 1 )
            {
                if ( !string.IsNullOrEmpty( bandedGridView4.GetFocusedRowCellValue( "idx" ).ToString( ) ) )
                    model.Idx = Convert.ToInt32( bandedGridView4.GetFocusedRowCellValue( "idx" ).ToString( ) );
                textBox367.Text = textBox328.Text = textBox298.Text = textBox265.Text = textBox232.Text = textBox196.Text = textBox154.Text = textBox123.Text = textBox82.Text = textBox51.Text = textBox24.Text = textBox19.Text = textBox2.Text = model.Idx.ToString( );
                oddNum = bandedGridView4.GetFocusedRowCellValue( "AM002" ).ToString( );
                num = bandedGridView4.FocusedRowHandle;
                assignMent( );
            }
        }
        private void bandedGridView5_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView5.FocusedRowHandle >= 0 && bandedGridView5.FocusedRowHandle <= bandedGridView5.RowCount - 1 )
            {
                if ( !string.IsNullOrEmpty( bandedGridView5.GetFocusedRowCellValue( "idx" ).ToString( ) ) )
                    model.Idx = Convert.ToInt32( bandedGridView5.GetFocusedRowCellValue( "idx" ).ToString( ) );
                textBox367.Text = textBox328.Text = textBox298.Text = textBox265.Text = textBox232.Text = textBox196.Text = textBox154.Text = textBox123.Text = textBox82.Text = textBox51.Text = textBox24.Text = textBox19.Text = textBox2.Text = model.Idx.ToString( );
                oddNum = bandedGridView5.GetFocusedRowCellValue( "AM002" ).ToString( );
                num = bandedGridView5.FocusedRowHandle;
                assignMent( );
            }
        }
        private void bandedGridView6_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView6.FocusedRowHandle >= 0 && bandedGridView6.FocusedRowHandle <= bandedGridView6.RowCount - 1 )
            {
                if ( !string.IsNullOrEmpty( bandedGridView6.GetFocusedRowCellValue( "idx" ).ToString( ) ) )
                    model.Idx = Convert.ToInt32( bandedGridView6.GetFocusedRowCellValue( "idx" ).ToString( ) );
                textBox367.Text = textBox328.Text = textBox298.Text = textBox265.Text = textBox232.Text = textBox196.Text = textBox154.Text = textBox123.Text = textBox82.Text = textBox51.Text = textBox24.Text = textBox19.Text = textBox2.Text = model.Idx.ToString( );
                oddNum = bandedGridView6.GetFocusedRowCellValue( "AM002" ).ToString( );
                num = bandedGridView6.FocusedRowHandle;
                assignMent( );
            }
        }
        private void bandedGridView7_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView7.FocusedRowHandle >= 0 && bandedGridView7.FocusedRowHandle <= bandedGridView7.RowCount - 1 )
            {
                if ( !string.IsNullOrEmpty( bandedGridView7.GetFocusedRowCellValue( "idx" ).ToString( ) ) )
                    model.Idx = Convert.ToInt32( bandedGridView7.GetFocusedRowCellValue( "idx" ).ToString( ) );
                textBox367.Text = textBox328.Text = textBox298.Text = textBox265.Text = textBox232.Text = textBox196.Text = textBox154.Text = textBox123.Text = textBox82.Text = textBox51.Text = textBox24.Text = textBox19.Text = textBox2.Text = model.Idx.ToString( );
                oddNum = bandedGridView7.GetFocusedRowCellValue( "AM002" ).ToString( );
                num = bandedGridView7.FocusedRowHandle;
                assignMent( );
            }
        }
        private void bandedGridView8_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView8.FocusedRowHandle >= 0 && bandedGridView8.FocusedRowHandle <= bandedGridView8.RowCount - 1 )
            {
                if ( !string.IsNullOrEmpty( bandedGridView8.GetFocusedRowCellValue( "idx" ).ToString( ) ) )
                    model.Idx = Convert.ToInt32( bandedGridView8.GetFocusedRowCellValue( "idx" ).ToString( ) );
                textBox367.Text = textBox328.Text = textBox298.Text = textBox265.Text = textBox232.Text = textBox196.Text = textBox154.Text = textBox123.Text = textBox82.Text = textBox51.Text = textBox24.Text = textBox19.Text = textBox2.Text = model.Idx.ToString( );
                oddNum = bandedGridView8.GetFocusedRowCellValue( "AM002" ).ToString( );
                num = bandedGridView8.FocusedRowHandle;
                assignMent( );
            }
        }
        private void bandedGridView9_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView9.FocusedRowHandle >= 0 && bandedGridView9.FocusedRowHandle <= bandedGridView9.RowCount - 1 )
            {
                if ( !string.IsNullOrEmpty( bandedGridView9.GetFocusedRowCellValue( "idx" ).ToString( ) ) )
                    model.Idx = Convert.ToInt32( bandedGridView9.GetFocusedRowCellValue( "idx" ).ToString( ) );
                textBox367.Text = textBox328.Text = textBox298.Text = textBox265.Text = textBox232.Text = textBox196.Text = textBox154.Text = textBox123.Text = textBox82.Text = textBox51.Text = textBox24.Text = textBox19.Text = textBox2.Text = model.Idx.ToString( );
                oddNum = bandedGridView6.GetFocusedRowCellValue( "AM002" ).ToString( );
                num = bandedGridView9.FocusedRowHandle;
                assignMent( );
            }
        }
        private void bandedGridView10_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView10.FocusedRowHandle >= 0 && bandedGridView10.FocusedRowHandle <= bandedGridView10.RowCount - 1 )
            {
                if ( !string.IsNullOrEmpty( bandedGridView10.GetFocusedRowCellValue( "idx" ).ToString( ) ) )
                    model.Idx = Convert.ToInt32( bandedGridView10.GetFocusedRowCellValue( "idx" ).ToString( ) );
                textBox367.Text = textBox328.Text = textBox298.Text = textBox265.Text = textBox232.Text = textBox196.Text = textBox154.Text = textBox123.Text = textBox82.Text = textBox51.Text = textBox24.Text = textBox19.Text = textBox2.Text = model.Idx.ToString( );
                oddNum = bandedGridView10.GetFocusedRowCellValue( "AM002" ).ToString( );
                num = bandedGridView10.FocusedRowHandle;
                assignMent( );
            }
        }
        private void bandedGridView11_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView11.FocusedRowHandle >= 0 && bandedGridView11.FocusedRowHandle <= bandedGridView11.RowCount - 1 )
            {
                if ( !string.IsNullOrEmpty( bandedGridView11.GetFocusedRowCellValue( "idx" ).ToString( ) ) )
                    model.Idx = Convert.ToInt32( bandedGridView11.GetFocusedRowCellValue( "idx" ).ToString( ) );
                textBox367.Text = textBox328.Text = textBox298.Text = textBox265.Text = textBox232.Text = textBox196.Text = textBox154.Text = textBox123.Text = textBox82.Text = textBox51.Text = textBox24.Text = textBox19.Text = textBox2.Text = model.Idx.ToString( );
                oddNum = bandedGridView11.GetFocusedRowCellValue( "AM002" ).ToString( );
                num = bandedGridView11.FocusedRowHandle;
                assignMent( );
            }
        }
        private void bandedGridView12_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView12.FocusedRowHandle >= 0 && bandedGridView12.FocusedRowHandle <= bandedGridView12.RowCount - 1 )
            {
                if ( !string.IsNullOrEmpty( bandedGridView12.GetFocusedRowCellValue( "idx" ).ToString( ) ) )
                    model.Idx = Convert.ToInt32( bandedGridView12.GetFocusedRowCellValue( "idx" ).ToString( ) );
                textBox367.Text = textBox328.Text = textBox298.Text = textBox265.Text = textBox232.Text = textBox196.Text = textBox154.Text = textBox123.Text = textBox82.Text = textBox51.Text = textBox24.Text = textBox19.Text = textBox2.Text = model.Idx.ToString( );
                oddNum = bandedGridView12.GetFocusedRowCellValue( "AM002" ).ToString( );
                num = bandedGridView12.FocusedRowHandle;
                assignMent( );
            }
        }
        private void bandedGridView13_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView13.FocusedRowHandle >= 0 && bandedGridView13.FocusedRowHandle <= bandedGridView13.RowCount - 1 )
            {
                if ( !string.IsNullOrEmpty( bandedGridView13.GetFocusedRowCellValue( "idx" ).ToString( ) ) )
                    model.Idx = Convert.ToInt32( bandedGridView13.GetFocusedRowCellValue( "idx" ).ToString( ) );
                textBox367.Text = textBox328.Text = textBox298.Text = textBox265.Text = textBox232.Text = textBox196.Text = textBox154.Text = textBox123.Text = textBox82.Text = textBox51.Text = textBox24.Text = textBox19.Text = textBox2.Text = model.Idx.ToString( );
                oddNum = bandedGridView13.GetFocusedRowCellValue( "AM002" ).ToString( );
                num = bandedGridView13.FocusedRowHandle;
                assignMent( );
            }
        }

        void assignMent ( )
        {
            model = bll . GetModel ( model . Idx );
            textBox4 . Text = textBox20 . Text = textBox23 . Text = textBox50 . Text = textBox81 . Text = textBox121 . Text = textBox153 . Text = textBox195 . Text = textBox231 . Text = textBox264 . Text = textBox297 . Text = textBox327 . Text = textBox366 . Text = model . AM002;
            textBox3 . Text = model . AM003;
            textBox5 . Text = model . AM004;
            textBox6 . Text = model . AM005;
            textBox7 . Text = textBox365 . Text = textBox326 . Text = textBox296 . Text = textBox263 . Text = textBox230 . Text = textBox194 . Text = textBox152 . Text = textBox121 . Text = textBox80 . Text = textBox49 . Text = textBox22 . Text = textBox21 . Text = textBox7 . Text = model . AM006 . ToString ( );
            if ( model . AM007 > DateTime . MinValue && model . AM007 < DateTime . MaxValue )
                textBox25 . Text = model . AM007 . ToString ( );
            else
                textBox25 . Text = string . Empty;
            textBox13 . Text = model . AM008;
            textBox1 . Text = model . AM009;
            textBox9 . Text = model . AM010;
            textBox10 . Text = model . AM011;
            textBox11 . Text = model . AM012;
            textBox14 . Text = model . AM013;
            textBox15 . Text = model . AM014;
            textBox8 . Text = model . AM015 . ToString ( );
            textBox12 . Text = model . AM016 . ToString ( );
            textBox16 . Text = model . AM017 . ToString ( );
            textBox17 . Text = model . AM018 . ToString ( );
            textBox18 . Text = model . AM019 . ToString ( );
        }
        #endregion

        #region CalCulaTion
        void all ( )
        {
            DataTable calCu = new DataTable ( );
            calCu = bll . GetDataTableCalCu ( strWhere );
            if ( calCu != null && calCu . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < bandedGridView2 . RowCount ; i++ )
                {
                    model . Idx = string . IsNullOrEmpty ( bandedGridView2 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( bandedGridView2 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );

                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U24" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U24" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U26" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U26" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U29" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U29" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U31" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U31" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U34" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U34" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U36" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U36" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U39" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U39" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U41" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U41" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U44" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U44" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U46" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U46" ] . ToString ( ) );
                    //油漆 U49应付 
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U49" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U49" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U51" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U51" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U54" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U54" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U56" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U56" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U59" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U59" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U61" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U61" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U64" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U64" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U66" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U66" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U69" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U69" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U71" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U71" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U74" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U74" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U76" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U76" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U104" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U104" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U105" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U105" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U106" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U106" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U107" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U107" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U108" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U108" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U109" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U109" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U110" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U110" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U111" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U111" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U112" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U112" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U113" ] ,calCu . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U113" ] . ToString ( ) );
                }
                for ( int i = 0 ; i < bandedGridView1 . RowCount ; i++ )
                {
                    bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U14" ] ,calCu . Select ( "idx='" + bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) + "'" ) [ 0 ] [ "U14" ] . ToString ( ) );
                    bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U16" ] ,calCu . Select ( "idx='" + bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) + "'" ) [ 0 ] [ "U16" ] . ToString ( ) );
                    bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "F0" ] ,calCu . Select ( "idx='" + bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) + "'" ) [ 0 ] [ "F0" ] . ToString ( ) );
                    bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "F1" ] ,calCu . Select ( "idx='" + bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) + "'" ) [ 0 ] [ "F1" ] . ToString ( ) );
                }

                attriButeCancel ( );
            }
        }
        void hide ( )
        {
            DataTable calCuHide = new DataTable ( );
            calCuHide = bll . GetDataTableCalCuHide ( strWhere );
            if ( calCuHide != null && calCuHide . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < bandedGridView2 . RowCount ; i++ )
                {
                    model . Idx = string . IsNullOrEmpty ( bandedGridView2 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( bandedGridView2 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U24" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U24" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U26" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U26" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U29" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U29" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U31" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U31" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U34" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U34" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U36" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U36" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U39" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U39" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U41" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U41" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U44" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U44" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U46" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U46" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U49" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U49" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U51" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U51" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U54" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U54" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U56" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U56" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U59" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U59" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U61" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U61" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U64" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U64" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U66" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U66" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U69" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U69" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U71" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U71" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U74" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U74" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U76" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U76" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U104" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U104" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U105" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U105" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U106" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U106" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U107" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U107" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U108" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U108" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U109" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U109" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U110" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U110" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U111" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U111" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U112" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U112" ] . ToString ( ) );
                    bandedGridView2 . SetRowCellValue ( i ,bandedGridView2 . Columns [ "U113" ] ,calCuHide . Select ( "idx='" + model . Idx + "'" ) [ 0 ] [ "U113" ] . ToString ( ) );
                }
                for ( int i = 0 ; i < bandedGridView1 . RowCount ; i++ )
                {
                    bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U14" ] ,calCuHide . Select ( "idx='" + bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) + "'" ) [ 0 ] [ "U14" ] . ToString ( ) );
                    bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U16" ] ,calCuHide . Select ( "idx='" + bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) + "'" ) [ 0 ] [ "U16" ] . ToString ( ) );
                    bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "F0" ] ,calCuHide . Select ( "idx='" + bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) + "'" ) [ 0 ] [ "F0" ] . ToString ( ) );
                    bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "F1" ] ,calCuHide . Select ( "idx='" + bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) + "'" ) [ 0 ] [ "F1" ] . ToString ( ) );
                }

                attriBute ( );
            }
        }
        void addColumn ( )
        {
            if ( queryTable.Columns.Contains( "U24" ) == true )
                return;
            queryTable.Columns.Add( "U24" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U26" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U29" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U31" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U34" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U36" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U39" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U41" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U44" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U46" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U49" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U51" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U54" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U56" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U59" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U61" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U64" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U66" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U69" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U74" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U71" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U76" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U14" ,Type.GetType( "System.Decimal" ) );
            queryTable.Columns.Add( "U16" ,Type.GetType( "System.Decimal" ) );
            queryTable . Columns . Add ( "U104" ,Type . GetType ( "System.Decimal" ) );
            queryTable . Columns . Add ( "U105" ,Type . GetType ( "System.Decimal" ) );
            queryTable . Columns . Add ( "U106" ,Type . GetType ( "System.Decimal" ) );
            queryTable . Columns . Add ( "U107" ,Type . GetType ( "System.Decimal" ) );
            queryTable . Columns . Add ( "U108" ,Type . GetType ( "System.Decimal" ) );
            queryTable . Columns . Add ( "U109" ,Type . GetType ( "System.Decimal" ) );
            queryTable . Columns . Add ( "U110" ,Type . GetType ( "System.Decimal" ) );
            queryTable . Columns . Add ( "U111" ,Type . GetType ( "System.Decimal" ) );
            queryTable . Columns . Add ( "U112" ,Type . GetType ( "System.Decimal" ) );
            queryTable . Columns . Add ( "U113" ,Type . GetType ( "System.Decimal" ) );
            queryTable . Columns . Add ( "F0" ,Type . GetType ( "System.Decimal" ) );
            queryTable . Columns . Add ( "F1" ,Type . GetType ( "System.Decimal" ) );
        }
        void calcuTotal ( )
        {
            model . AM006 = Convert . ToInt32 ( AM006 . SummaryItem . SummaryValue );
            U8 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U2 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U9 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U3 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U15 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U14 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U17 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U16 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );

            model . AM006 = Convert . ToInt32 ( AM006_0ne . SummaryItem . SummaryValue );
            U20 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U19 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U22 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U21 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U25 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U24 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U27 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U26 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U30 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U29 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U32 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U31 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U35 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U34 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U37 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U36 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U40 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U39 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U42 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U41 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U45 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U44 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U47 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U46 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U50 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U49 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U52 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U51 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U55 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U54 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U57 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U56 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U60 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U59 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U62 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U61 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U65 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U64 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U67 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U66 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U70 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U69 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U72 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U71 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U75 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U74 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U77 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U76 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U80 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U79 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U82 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U81 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );


            model . AM006 = Convert . ToInt32 ( AM006_two . SummaryItem . SummaryValue );
            U85 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U84 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U87 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U86 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U89 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM020 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U90 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM021 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U92 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM022 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U93 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM023 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U95 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM024 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U96 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM025 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U98 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM026 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U99 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM027 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U101 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM028 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U102 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM029 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );


            model . AM006 = Convert . ToInt32 ( AM006_for . SummaryItem . SummaryValue );
            U205 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U209 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U207 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U206 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U210 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM044 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U211 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM045 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U213 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM046 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U214 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM047 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U216 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM048 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U217 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM049 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U219 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM050 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U220 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM051 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U222 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM052 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U223 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM053 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U225 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM054 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U226 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM055 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U228 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM056 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U229 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM057 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U231 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM058 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U232 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM059 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U234 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM060 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U235 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM061 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U237 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM062 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U238 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM063 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );


            model . AM006 = Convert . ToInt32 ( AM006_fiv . SummaryItem . SummaryValue );
            U250 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U249 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U252 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U251 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U254 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM070 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U255 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM071 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U257 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM072 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U258 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM073 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U260 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM074 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U261 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM075 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U263 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM076 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U264 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM077 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U266 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM078 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U267 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM079 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U269 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM080 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U270 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM081 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U272 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM082 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U273 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM083 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U275 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM084 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U276 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM085 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U278 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM086 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U279 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM087 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U281 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM088 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U282 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM089 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U284 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM090 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U285 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM091 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U287 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM092 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U288 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM093 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );


            model . AM006 = Convert . ToInt32 ( AM006_idx . SummaryItem . SummaryValue );
            U312 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U311 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U314 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U313 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U316 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM108 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U317 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM109 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U319 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM111 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U320 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM112 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );

            model . AM006 = Convert . ToInt32 ( AM006_sev . SummaryItem . SummaryValue );
            U344 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U343 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U346 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U345 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U348 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM136 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U349 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM137 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U351 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM139 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U352 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM140 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U354 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM142 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U355 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM143 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U357 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM145 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U358 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM146 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U360 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM148 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U361 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM149 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U363 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM237 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );


            model . AM006 = Convert . ToInt32 ( AM006_egi . SummaryItem . SummaryValue );
            U388 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U387 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U390 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U389 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U392 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM175 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U393 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal (  AM176. SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U395 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM178 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U396 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM179 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U398 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM182 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U399 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM183 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U401 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM185 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U402 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM186 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U404 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM188 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U407 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM191 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U410 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM194 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U413 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM197 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );


            model . AM006 = Convert . ToInt32 ( AM006_nin . SummaryItem . SummaryValue );
            U427 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U426 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U429 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U428 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U431 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM209 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U432 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM210 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U434 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM212 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U435 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM213 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U437 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM215 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U438 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM217 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U440 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM218 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U441 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM219 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U443 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM225 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U446 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM229 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U450 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM234 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );


            model . AM006 = Convert . ToInt32 ( AM006_ten . SummaryItem . SummaryValue );
            U462 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U461 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U464 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U463 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U466 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM239 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U467 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM240 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U469 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM242 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U470 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM243 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U472 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM245 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U473 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM246 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U475 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM249 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U476 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM250 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );

            model . AM006 = Convert . ToInt32 ( AM006_ele . SummaryItem . SummaryValue );
            U497 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U496 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U499 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U498 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U501 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM270 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U502 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM271 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U504 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM273 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U505 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM274 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U507 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM277 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U510 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM280 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );

            model . AM006 = Convert . ToInt32 ( AM006_twe . SummaryItem . SummaryValue );
            U530 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U529 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U532 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U531 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U534 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM298 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U535 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM299 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U537 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM301 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U538 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM302 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U540 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM304 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U543 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM307 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U544 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM308 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U546 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM311 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U547 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM312 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U549 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM315 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U552 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM318 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U555 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM321 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );

            model . AM006 = Convert . ToInt32 ( AM006_tre . SummaryItem . SummaryValue );
            U571 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U570 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U573 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U572 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U575 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM336 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U576 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM337 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U578 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM339 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U579 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM340 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U581 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM343 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U582 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM344 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U584 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM346 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U585 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM347 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U587 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM349 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U588 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM350 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U590 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM352 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U591 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM353 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U593 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM355 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U594 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM356 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U596 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM358 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U599 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM361 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U600 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM362 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U602 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM364 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U603 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM365 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U605 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM367 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U606 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM368 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U608 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM370 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U609 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM371 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U611 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM330 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U614 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM333 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U617 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM373 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U620 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM376 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U623 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM379 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U626 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM385 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U629 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM388 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U632 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM391 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U637 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM153 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U638 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM354 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U640 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM157 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
        }
        private void bandedGridView1_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            model . AM006 = Convert . ToInt32 ( AM006 . SummaryItem . SummaryValue );
            U8 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U2 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U9 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U3 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U15 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U14 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U17 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U16 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
        }
        private void bandedGridView2_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            model . AM006 = Convert . ToInt32 ( AM006_0ne . SummaryItem . SummaryValue );
            U20 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U19 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U22 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U21 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U25 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U24 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U27 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U26 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U30 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U29 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U32 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U31 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U35 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U34 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U37 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U36 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U40 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U39 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U42 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U41 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U45 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U44 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U47 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U46 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U50 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U49 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U52 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U51 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U55 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U54 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U57 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U56 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U60 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U59 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U62 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U61 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U65 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U64 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U67 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U66 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U70 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U69 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U72 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U71 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U75 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U74 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U77 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U76 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U80 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U79 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U82 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U81 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
        }
        private void bandedGridView3_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            model . AM006 = Convert . ToInt32 ( AM006_two . SummaryItem . SummaryValue );
            U85 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U84 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U87 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U86 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U89 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM020 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U90 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM021 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U92 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM022 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U93 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM023 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U95 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM024 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U96 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM025 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U98 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM026 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U99 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM027 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U101 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM028 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U102 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM029 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
        }
        private void bandedGridView4_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            model . AM006 = Convert . ToInt32 ( AM006_for . SummaryItem . SummaryValue );
            U205 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U209 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U207 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U206 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U210 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM044 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U211 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM045 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U213 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM046 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U214 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM047 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U216 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM048 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U217 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM049 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U219 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM050 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U220 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM051 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U222 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM052 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U223 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM053 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U225 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM054 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U226 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM055 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U228 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM056 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U229 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM057 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U231 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM058 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U232 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM059 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U234 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM060 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U235 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM061 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U237 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM062 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U238 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM063 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
        }
        private void bandedGridView5_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            model . AM006 = Convert . ToInt32 ( AM006_fiv . SummaryItem . SummaryValue );
            U250 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U249 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U252 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U251 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U254 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM070 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U255 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM071 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U257 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM072 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U258 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM073 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U260 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM074 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U261 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM075 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U263 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM076 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U264 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM077 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U266 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM078 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U267 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM079 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U269 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM080 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U270 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM081 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U272 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM082 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U273 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM083 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U275 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM084 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U276 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM085 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U278 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM086 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U279 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM087 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U281 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM088 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U282 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM089 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U284 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM090 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U285 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM091 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U287 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM092 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U288 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM093 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
        }
        private void bandedGridView6_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            model . AM006 = Convert . ToInt32 ( AM006_idx . SummaryItem . SummaryValue );
            U312 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U311 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U314 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U313 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U316 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM108 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U317 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM109 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U319 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM111 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U320 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM112 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
        }
        private void bandedGridView7_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            model . AM006 = Convert . ToInt32 ( AM006_sev . SummaryItem . SummaryValue );
            U344 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U343 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U346 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U345 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U348 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM136 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U349 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM137 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U351 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM139 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U352 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM140 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U354 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM142 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U355 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM143 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U357 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM145 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U358 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM146 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U360 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM148 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U361 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM149 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U363 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM237 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
        }
        private void bandedGridView8_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            model . AM006 = Convert . ToInt32 ( AM006_egi . SummaryItem . SummaryValue );
            U388 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U387 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U390 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U389 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U392 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM175 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U393 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM176 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U395 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM178 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U396 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM179 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U398 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM182 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U399 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM183 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U401 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM185 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U402 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM186 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U404 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM188 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U407 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM191 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U410 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM194 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U413 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM197 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
        }
        private void bandedGridView9_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            model . AM006 = Convert . ToInt32 ( AM006_nin . SummaryItem . SummaryValue );
            U427 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U426 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U429 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U428 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U431 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM209 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U432 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM210 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U434 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM212 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U435 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM213 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U437 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM215 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U438 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM217 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U440 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM218 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U441 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM219 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U443 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM225 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U446 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM229 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U450 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM234 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
        }
        private void bandedGridView10_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            model . AM006 = Convert . ToInt32 ( AM006_ten . SummaryItem . SummaryValue );
            U462 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U461 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U464 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U463 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U466 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM239 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U467 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM240 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U469 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM242 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U470 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM243 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U472 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM245 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U473 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM246 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U475 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM249 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U476 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM250 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
        }
        private void bandedGridView11_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            model . AM006 = Convert . ToInt32 ( AM006_ele . SummaryItem . SummaryValue );
            U497 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U496 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U499 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U498 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U501 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM270 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U502 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM271 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U504 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM273 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U505 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM274 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U507 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM277 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U510 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM280 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
        }
        private void bandedGridView12_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            model . AM006 = Convert . ToInt32 ( AM006_twe . SummaryItem . SummaryValue );
            U530 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U529 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U532 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U531 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U534 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM298 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U535 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM299 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U537 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM301 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U538 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM302 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U540 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM304 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U543 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM307 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U544 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM308 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U546 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM311 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U547 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM312 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U549 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM315 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U552 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM318 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U555 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM321 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
        }
        private void bandedGridView13_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            model . AM006 = Convert . ToInt32 ( AM006_tre . SummaryItem . SummaryValue );
            U571 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U570 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U573 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( U572 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U575 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM336 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U576 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM337 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U578 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM339 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U579 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM340 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U581 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM343 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U582 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM344 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U584 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM346 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U585 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM347 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U587 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM349 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U588 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM350 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U590 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM352 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U591 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM353 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U593 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM355 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U594 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM356 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U596 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM358 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U599 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM361 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U600 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM362 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U602 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM364 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U603 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM365 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U605 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM367 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U606 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM368 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U608 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM370 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U609 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM371 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U611 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM330 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U614 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM333 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U617 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM373 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U620 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM376 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U623 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM379 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U626 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM385 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U629 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM388 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U632 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM391 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U637 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM153 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U638 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM354 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
            U640 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( AM157 . SummaryItem . SummaryValue ) / model . AM006 ,2 ) . ToString ( ) );
        }
        #endregion

        #region Other
        private void contextMenuStrip1_ItemClicked ( object sender ,ToolStripItemClickedEventArgs e )
        {
            if ( ( e . ClickedItem ) . Name == "MenuItemHide" )
            {
                bool resuleFiv = bll.GetHide( );
                if ( resuleFiv == true )
                {
                    strWhere = "''";
                    for ( int i = 0 ; i < bandedGridView1 . RowCount ; i++ )
                    {
                        strWhere = strWhere + "," + "'" + bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) + "'";
                    }
                    strWhere = "idx IN (" + strWhere + ")";
                    hide ( );
                }
                else
                    MessageBox . Show ( "设置失败,请重新设置" );
            }
            else if ( ( e . ClickedItem ) . Name == "MenuItemHideCanCel" )
            {
                bool resuleSix = bll.GetHideCanCel( );
                if ( resuleSix == true )
                {
                    strWhere = "''";
                    for ( int i = 0 ; i < bandedGridView1 . RowCount ; i++ )
                    {
                        strWhere = strWhere + "," + "'" + bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) + "'";
                    }
                    strWhere = "idx IN (" + strWhere + ")";
                    all ( );
                }
                else
                    MessageBox . Show ( "设置失败,请重新设置" );
            }
            else if ( ( e . ClickedItem ) . Name == "MenuItemBatchEdit" )
            {
                strWhere = "";
                string numOf="";
                for ( int i = 0 ; i < bandedGridView1 . RowCount ; i++ )
                {
                    numOf = bandedGridView1 . GetDataRow ( i ) [ "AM002" ] . ToString ( );
                    if ( strWhere == "" )
                        strWhere = "'" + numOf + "'";
                    else if ( !strWhere . Contains ( numOf ) )
                        strWhere = strWhere + "," + "'" + numOf + "'";
                }
                if ( strWhere != string . Empty )
                {
                    SelectAll.ProductCostSummaryBatch batchQuery = new SelectAll.ProductCostSummaryBatch();
                    batchQuery.StartPosition = FormStartPosition.CenterScreen;
                    batchQuery.strWhere = strWhere;
                    batchQuery.ShowDialog();
                }
            }
        }
        void attriBute ( )
        {
            gridBand60.Visible = false;
            //gridBand86.Visible = false;
            //gridBand90.Visible = false;
            gridBand151.Visible = false;
            gridBand159.Visible = false;

            this.U311.UnboundExpression = "[AM108]";
            this.U313.UnboundExpression = "[AM109]";
            //this.U387.UnboundExpression = "[AM175] + [AM182] + [AM185] + [AM188] + [AM194] + [AM197]";
            //this.U389.UnboundExpression = "[AM176] + [AM183] + [AM186] + [AM189] + [AM195] + [AM198]";          
            this . U570 . UnboundExpression = "[AM338]+[AM351]+[AM381]+[AM357]+[AM363]+[AM294]+[AM369]+[AM292]+[AM332]+[AM155]+[AM345]+[AM390]+[AM336]+[AM343]+[AM361]+[AM346]+[AM349]+[AM367]+[AM352]+[AM370]+[AM355]+[AM153]+[AM339]+[AM364]";

            this . U572.UnboundExpression = "[AM341]+[AM354]+[AM387]+[AM360]+[AM366]+[AM295]+[AM372]+[AM293]+[AM335]+[AM156]+[AM348]+[AM393]+[AM365]+[AM340]+[AM154]+[AM337]+[AM344]+[AM362]+[AM347]+[AM350]+[AM368]+[AM353]+[AM371]+[AM356]";
        }
        void attriButeCancel ( )
        {
            gridBand60.Visible = true;
            //gridBand86.Visible = true;
            //gridBand90.Visible = true;
            gridBand151.Visible = true;
            gridBand159.Visible = true;

            this.U311.UnboundExpression = "[AM108] + [AM111]";
            this.U313.UnboundExpression = "[AM109] + [AM112]";
            //this.U387.UnboundExpression = "[AM175] + [AM178] + [AM182] + [AM185] + [AM188] + [AM191] + [AM194] + [AM197]";
            //this.U389.UnboundExpression = "[AM176] + [AM179] + [AM183] + [AM186] + [AM189] + [AM192] + [AM195] + [AM198]";
            this.U570.UnboundExpression = "[AM261]+[AM263]+[AM265]+[AM267]+[AM287]+[AM288]+[AM290]+[AM292]+[AM294]+[AM330]+[AM332]+[AM333]+[AM336]+[AM338]+[AM339]+[AM343]+[AM345]+[AM346]+[AM349]+[AM351]+[AM352]+[AM355]+[AM357]+[AM358]+[AM361]+[AM363]+[AM364]+[AM367]+[AM369]+[AM370]+[AM373]+[AM375]+[AM376]+[AM379]+[AM381]+[AM382]+[AM385]+[AM388]+[AM390]+[AM391]";
            this.U572.UnboundExpression = "[AM262]+[AM264]+[AM266]+[AM268]+[AM269]+[AM289]+[AM291]+[AM293]+[AM295]+[AM331]+[AM334]+[AM335]+[AM337]+[AM340]+[AM341]+[AM344]+[AM347]+[AM348]+[AM350]+[AM353]+[AM354]+[AM356]+[AM359]+[AM360]+[AM362]+[AM365]+[AM366]+[AM368]+[AM371]+[AM372]+[AM374]+[AM377]+[AM378]+[AM380]+[AM383]+[AM386]+[AM387]+[AM389]+[AM392]+[AM393]";
        }
        private void R_FrmProductCostSummary_FormClosing ( object sender ,FormClosingEventArgs e )
        {
            if ( toolSave . Enabled == true )
            {
                if ( progressBar1 . Visible == true )
                {
                    MessageBox . Show ( "正在生成数据,不允许终止" );
                    e . Cancel = true;
                    return;
                }
                else
                    cancel ( );
                //e . Cancel = true;
            }
        }
        #endregion

    }
}
