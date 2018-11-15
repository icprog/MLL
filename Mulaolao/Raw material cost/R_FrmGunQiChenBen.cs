using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Raw_material_cost
{
    public partial class R_FrmGunQiChenBen : FormChild
    {
        public R_FrmGunQiChenBen ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { bandedGridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoBll.Bll.GunQiChenBenBll _bll = new MulaolaoBll.Bll.GunQiChenBenBll( );
        MulaolaoLibrary.GunQiChenBenLibrary _model = new MulaolaoLibrary.GunQiChenBenLibrary( );
        DataTable tableQuery,libraryTable;
        bool result = false;
        string conOne="";
        
        List<SplitContainer> spList = new List<SplitContainer>( );
        List<TabPage> pageList = new List<TabPage>( ); Factory fc = new Factory( );

        private void R_FrmGunQiChenBen_Load ( object sender ,EventArgs e )
        {
            Power( this );
            spList.Clear( );
            spList.Add( splitContainer1 );
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableFalse( spList );
            pageList.Clear( );
            pageList.AddRange( new TabPage[] { tabPageOne ,tabPageTwo } );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableFalse( pageList );
            hideItems( );
        }
        
        #region Event
        private void bandedGridView1_CustomDrawRowIndicator ( object sender ,DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e )
        {
            if ( e.Info.Kind == DevExpress.Utils.Drawing.IndicatorKind.Band)
            {
                e.Appearance.DrawBackground( e.Cache ,e.Bounds );
                e.Appearance.DrawString( e.Cache ,"  序号" ,e.Bounds );
                e.Handled = true;
            }
            if ( e.Info.IsRowIndicator && e.RowHandle >= 0 )
            {
                e.Info.DisplayText = ( e.RowHandle + 1 ).ToString( );
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
            if ( textBox9.Text != "" && !DateDay.sixThrNumberCb( textBox9 ) )
            {
                this.textBox9.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多三位,如999.999,请重新输入" );
            }
        }
        private void textBox10_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.fractionTb( e ,textBox10 );
        }
        private void textBox10_TextChanged ( object sender ,EventArgs e )
        {
            DateDay.textChangeTb( textBox9 );
        }
        private void textBox10_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox10.Text != "" && !DateDay.sixThrNumberCb( textBox10 ) )
            {
                this.textBox10.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多三位,如999.999,请重新输入" );
            }
        }
        //string num = "", partName = "", brand = "", baseMaterial = "", colorNum = "";
        private void bandedGridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView1.FocusedRowHandle >= 0 && bandedGridView1.FocusedRowHandle <= bandedGridView1.RowCount - 1 )
            {
                _model.IDX = string.IsNullOrEmpty( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                assignMent( );
            }
        }
        void assignMent ( )
        {
            _model = _bll.GetModel( _model.IDX );
            textBox1.Text = _model.PZ002;
            textBox2.Text = _model.PZ003;
            textBox3.Text = _model.PZ005;
            textBox4.Text = _model.PZ004;
            textBox5.Text = _model.PZ006.ToString( );
            if ( _model.PZ007 > DateTime.MinValue && _model.PZ007 < DateTime.MaxValue )
                dateTimePicker1.Value = _model.PZ007;
            if ( _model.PZ008 > DateTime.MinValue && _model.PZ008 < DateTime.MaxValue )
                dateTimePicker2.Value = _model.PZ008;
            textBox9.Text = _model.PZ017.ToString( );           
            textBox7.Text = _model.PZ023;
            textBox6.Text = _model.PZ021;
            textBox8.Text = _model.PZ024;
            if ( _model.PZ022 > DateTime.MinValue && _model.PZ022 < DateTime.MaxValue )
                dateTimePicker3.Value = _model.PZ022;
            if ( _model.PZ025 > DateTime.MinValue && _model.PZ025 < DateTime.MaxValue )
                dateTimePicker4.Value = _model.PZ025;
            textBox10.Text = _model.PZ036.ToString( );
        }
        private void contextMenuStrip1_ItemClicked ( object sender ,ToolStripItemClickedEventArgs e )
        {
            if ( ( e.ClickedItem ).Name == "MenuItemOne" )
            {
                _model.PZ038 = "T";
                _bll.EditHide( _model.PZ038 );
                hideItems( );
            }
            else if ( ( e.ClickedItem ).Name == "MenuItemTwo" )
            {
                _model.PZ038 = "F";
                _bll.EditHide( _model.PZ038 );
                cancelHideItems( );
            }
        }
        void hideItems ( )
        {
            gridBand43.Visible = gridBand12.Visible = gridBand45.Visible = gridBand18.Visible = gridBand20.Visible = gridBand54.Visible = gridBand23.Visible = gridBand58.Visible = gridBand26.Visible = gridBand27.Visible = gridBand14.Visible = gridBand47.Visible = gridBand61.Visible = gridBand30.Visible = gridBand32.Visible = gridBand33.Visible = gridBand35.Visible = false;
        }
        void cancelHideItems ( )
        {
            gridBand43.Visible = gridBand12.Visible = gridBand45.Visible = gridBand18.Visible = gridBand20.Visible = gridBand54.Visible = gridBand23.Visible = gridBand58.Visible = gridBand26.Visible = gridBand27.Visible = gridBand14.Visible = gridBand47.Visible = gridBand61.Visible = gridBand30.Visible = gridBand32.Visible = gridBand33.Visible = gridBand35.Visible = true;
        }
        #endregion

        #region Table
        void variable ( )
        {
            _model.PZ017 = string.IsNullOrEmpty( textBox9.Text ) == true ? 0M : Convert.ToDecimal( textBox9.Text );
            _model.PZ036 = string.IsNullOrEmpty( textBox10.Text ) == true ? 0M : Convert.ToDecimal( textBox10.Text );
            //_model.PZ018 = string.IsNullOrEmpty( textBox10.Text ) == true ? 0M : Convert.ToDecimal( textBox10.Text );
        }
        //Edit
        private void button5_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox2.Text ) )
            {
                MessageBox.Show( "流水号不可为空" );
                return;
            }
            variable( );
            edit( );
        }
        void edit ( )
        {
            result = _bll . Update ( _model ,Logins . username );
            if ( result == true )
            {
                MessageBox.Show( "成功编辑数据" );
                DataRow row = tableQuery.Rows[bandedGridView1.FocusedRowHandle];
                row.BeginEdit( );
                row["PZ017"] = _model.PZ017;
                row["PZ036"] = _model.PZ036;
                row.EndEdit( );
            }
            else
                MessageBox.Show( "编辑数据失败" );
        }
        //Delete
        private void button6_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;
            result = _bll . Delete ( _model . IDX ,Logins . username ,_model . PZ001 );
            if ( result == true )
            {
                MessageBox.Show( "删除数据成功" );
                tableQuery.Rows.RemoveAt( bandedGridView1.FocusedRowHandle );
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        //Refresh
        private void button7_Click ( object sender ,EventArgs e )
        {
            tableQuery = _bll.GetDataTable( _model.PZ001 );
            gridControl1.DataSource = tableQuery;
            assgin( );
        }
        void assgin ( )
        {
            decimal u11D = 0M, u16D = 0M, u27D = 0M, pz026dd = 0M;
            for ( int i = 0 ; i < bandedGridView1.DataRowCount ; i++ )
            {
                pz026dd = string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PZ026"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PZ026"].ToString( ) );
                u11D += Math.Round( pz026dd * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PZ017"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PZ017"].ToString( ) ) ) ,1 );
                u16D += Math.Round( pz026dd * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PZ019"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PZ019"].ToString( ) ) ) ,1 );
                u27D += Math.Round( pz026dd * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["PZ036"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PZ036"].ToString( ) ) ) ,1 );
            }
            decimal pz026D = Convert.ToDecimal( PZ026.SummaryItem.SummaryValue );
            decimal u19D = Convert.ToDecimal( U19.SummaryItem.SummaryValue );
            decimal u10D = Convert.ToDecimal( U10.SummaryItem.SummaryValue );
            //decimal u11D = Convert.ToDecimal( U11.SummaryItem.SummaryValue );
            decimal u13D = Convert.ToDecimal( U13.SummaryItem.SummaryValue );
            //decimal u16D = Convert.ToDecimal( U16.SummaryItem.SummaryValue );
            //decimal u17D = Convert.ToDecimal( U17.SummaryItem.SummaryValue );
            //decimal u27D = Convert.ToDecimal( U27.SummaryItem.SummaryValue );
            decimal pz033D = Convert.ToDecimal( PZ033.SummaryItem.SummaryValue );
            decimal pz034D = Convert.ToDecimal( PZ034.SummaryItem.SummaryValue );
            decimal pz035D = Convert.ToDecimal( PZ035.SummaryItem.SummaryValue );
            decimal pz006D = Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["PZ006"].ToString( ) );
            decimal pz015D = Convert.ToDecimal( PZ015.SummaryItem.SummaryValue );
            PZ006.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,pz006D.ToString( ) );
            PZ018.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( pz026D == 0 ? 0 : u19D / pz026D ,1 ).ToString( ) );
            PZ016.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( pz026D == 0 ? 0 : u10D / pz026D ,1 ).ToString( ) );
            PZ017.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( pz026D == 0 ? 0 : u11D / pz026D ,1 ).ToString( ) );
            PZ019.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( pz026D == 0 ? 0 : u16D / pz026D ,2 ).ToString( ) );
            PZ036.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( pz026D == 0 ? 0 : ( u27D + pz033D ) / pz026D ,2 ).ToString( ) );
            U0.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( pz026D == 0 ? 0 : u10D / pz026D + u11D / pz026D ,2 ).ToString( ) );
            U1.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( pz026D == 0 ? 0 : u16D / pz026D - u10D / pz026D - u19D / pz026D ,2 ).ToString( ) );
            U2.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( pz026D == 0 ? 0 : u16D / pz026D - u10D / pz026D - u11D / pz026D ,2 ).ToString( ) );
            U3.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( pz026D == 0 ? 0 : ( u16D == 0 ? 0 : ( u16D / pz026D - u10D / pz026D - u19D / pz026D ) / ( u16D / pz026D ) ) ) * 100 ,1 ).ToString( ) + "%" );//(u16D / pz026D - u10D / pz026D - u19D / pz026D)/( u16D / pz026D)
            U4.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( ( pz026D == 0 ? 0 : ( u16D == 0 ? 0 : ( u16D / pz026D - u10D / pz026D - u11D / pz026D ) / ( u16D / pz026D ) ) * 100 ) ,1 ).ToString( ) + "%" );//
            U5.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( pz006D == 0 ? 0 : u10D / pz006D ,2 ).ToString( ) );
            U6.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( pz006D == 0 ? 0 : ( u27D + pz033D + u11D + pz034D ) / pz006D ,2 ).ToString( ) );
            U7.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( pz026D == 0 ? 0 : u10D / pz026D - u11D / pz026D ,2 ).ToString( ) );
            U8.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( pz006D == 0 ? 0 : u10D / pz006D - ( u27D + pz033D + u11D + pz034D ) / pz006D ,2 ).ToString( ) );
            //U9.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( pz015D == 0 ? 0 : u11D / pz015D ,2 ).ToString( ) );
            U11.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,( u11D + pz034D ).ToString( ) );
            U12.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,( u10D - u11D - pz034D ).ToString( ) );
            U14.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,( u27D + pz033D + u11D + pz034D ).ToString( ) );
            U16.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,( u16D + pz035D ).ToString( ) );
            U17.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( pz026D == 0 ? 0 : u10D / pz026D + u19D / pz026D ,2 ).ToString( ) );
            U18.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,( u16D + pz035D - u27D - pz033D - u11D - pz034D ).ToString( ) );
            U21.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( pz006D == 0 ? 0 : u19D / pz006D ,2 ).ToString( ) );
            U22.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( pz006D == 0 ? 0 : ( u27D + pz033D ) / pz006D ,2 ).ToString( ) );
            U23.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( pz006D == 0 ? 0 : ( u27D + pz033D ) / pz006D+ ( u27D + pz033D + u11D + pz034D ) / pz006D ,2 ).ToString( ) );
            U24.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( pz006D == 0 ? 0 : ( u16D + pz035D ) / pz006D ,2 ).ToString( ) );
            U25.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( u19D / pz006D - ( u27D + pz033D ) / pz006D ,2 ).ToString( ) );
            U26.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( pz006D == 0 ? 0 : ( u16D + pz035D ) / pz006D - ( u27D + pz033D ) / pz006D - ( u27D + pz033D + u11D + pz034D ) / pz006D ,2 ).ToString( ) );
            U27.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,( u27D + pz033D ).ToString( ) );
            U29 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom , ( u16D + pz035D ) == 0 ? 0 . ToString ( ) : Math . Round ( ( u16D + pz035D - u27D - pz033D - u11D - pz034D ) / ( u16D + pz035D ) * 100 ,2 ) . ToString ( ) + "%" );
        }
        #endregion

        #region Main
        protected override void delete ( )
        {
            base.delete( );

            result = _bll . Delete ( _model . PZ001 ,bandedGridView1 . GetDataRow ( 0 ) [ "PZ037" ] . ToString ( ) ,Logins . username );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                toolSelect.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolAdd.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolDelete.Enabled = toolUpdate.Enabled = false;
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableFalse( pageList );
                Ergodic.SpliClear( spList );
                Ergodic.TablePageEnableClear( pageList );
                gridControl1.DataSource = null;
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        protected override void update ( )
        {
            base.update( );

            toolSelect.Enabled = toolAdd.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolDelete.Enabled = toolUpdate.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;

            Ergodic.SpliEnableTrue( spList );
            Ergodic.TablePageEnableTrue( pageList );
        }
        protected override void save ( )
        {
            base.save( );

            
            toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolLibrary . Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = toolAdd.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolStorage.Enabled = false;
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );            
        }
        bool WriteOfReceivablesTo ( )
        {
            result = false;
            DataTable receiva;
            MulaolaoLibrary.ProductCostSummaryLibrary modelAm = new MulaolaoLibrary.ProductCostSummaryLibrary( );
            receiva = _bll.GetDataTableOf( _model.PZ001 );
            if ( receiva != null && receiva.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < receiva.Rows.Count ; i++ )
                {
                    modelAm.AM002 = receiva.Rows[0]["PZ003"].ToString( );
                    modelAm.AM239 = modelAm.AM241 = 0;
                    modelAm.AM239 = string.IsNullOrEmpty( receiva.Compute( "SUM(PZ)" ,null ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(PZ)" ,null ).ToString( ) );
                    modelAm.AM241 = 0;
                    if ( _bll.UpdateOfReceviable( modelAm ,_model.PZ001 ) == true )
                        result = true;
                    else
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }
        protected override void cancel ( )
        {
            base.cancel( );

            toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolLibrary . Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = toolAdd.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled =  toolStorage.Enabled = false;
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
        }
        protected override void library ( )
        {
            base . library ( );

            List<string> speList = new List<string> ( );
            decimal planQi = 0;
            if ( libraryTable != null )
                libraryTable . Clear ( );
            for ( int i = 0 ; i < bandedGridView1 . RowCount ; i++ )
            {
                planQi = 0;
                planQi = string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "PZ015" ] . ToString ( ) ) == true ? 0 : Math . Round ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "PZ026" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "PZ026" ] . ToString ( ) ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "PZ017" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "PZ017" ] . ToString ( ) ) ) / Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "PZ015" ] . ToString ( ) ) ,1 );

                if ( libraryTable != null )
                    libraryTable . Rows . Add ( new object [ ] { bandedGridView1 . GetDataRow ( i ) [ "PZ013" ] . ToString ( ) , bandedGridView1 . GetDataRow ( i ) [ "PZ014" ] . ToString ( ) , bandedGridView1 . GetDataRow ( i ) [ "PZ027" ] . ToString ( ) , planQi } );
                else
                {
                    libraryTable = new DataTable ( "Datas" );
                    libraryTable . Columns . Add ( "tOne" , typeof ( System . String ) );
                    libraryTable . Columns . Add ( "tTwo" , typeof ( System . String ) );
                    libraryTable . Columns . Add ( "tTre" , typeof ( System . String ) );
                    libraryTable . Columns . Add ( "tFor" , typeof ( System . Decimal ) );
                    libraryTable . Rows . Add ( new object [ ] { bandedGridView1 . GetDataRow ( i ) [ "PZ013" ] . ToString ( ) , bandedGridView1 . GetDataRow ( i ) [ "PZ014" ] . ToString ( ) , bandedGridView1 . GetDataRow ( i ) [ "PZ027" ] . ToString ( ) , planQi } );
                }
            }
            if ( libraryTable . Rows . Count > 0 )
            {
                SelectAll . GunQiChenBenLibraryAll outC = new SelectAll . GunQiChenBenLibraryAll ( );
                outC . libraryTable = libraryTable;
                outC . oddNum = _model . PZ001;
                outC . StartPosition = FormStartPosition . CenterScreen;
                outC . PassDataBetweenForm += new SelectAll . GunQiChenBenLibraryAll . PassDataBetweenFormHandler ( outC_PassDataBetweenForm );
                outC . ShowDialog ( );
            }
            if ( conOne == "2" )
                return;
            //int countSum = 0;
            //for ( int i = 0 ; i < bandedGridView1 . RowCount ; i++ )
            //{
            //    speList . Clear ( );
            //    string query = "", count = "";
            //    if ( libraryTable == null )
            //        query = count = "";
            //    if ( libraryTable != null && libraryTable . Rows . Count > 0 )
            //    {
            //        countSum = libraryTable . Select ( "tTwo='" + bandedGridView1 . GetDataRow ( i ) [ "PZ013" ] . ToString ( ) + "'" ) . Length;
            //        if ( countSum > 0 )
            //        {
            //            for ( int k = 0 ; k < countSum ; k++ )
            //            {
            //                if ( !speList . Contains ( libraryTable . Select ( "tTwo='" + bandedGridView1 . GetDataRow ( i ) [ "PZ013" ] . ToString ( ) + "'" ) [ k ] [ "tOne" ] . ToString ( ) ) )
            //                    speList . Add ( libraryTable . Select ( "tTwo='" + bandedGridView1 . GetDataRow ( i ) [ "PZ013" ] . ToString ( ) + "'" ) [ k ] [ "tOne" ] . ToString ( ) );
            //            }
            //            if ( speList . Count > 0 )
            //            {
            //                foreach ( string str in speList )
            //                {
            //                    query = str;
            //                    count = libraryTable . Select ( "tTwo='" + bandedGridView1 . GetDataRow ( i ) [ "PZ013" ] . ToString ( ) + "' AND tOne='" + query + "'" ) [ 0 ] [ "tFor" ] . ToString ( );

            //                    result = fc . LibraryOf ( textBox1 . Text , textBox4 . Text , textBox2 . Text , bandedGridView1 . GetDataRow ( i ) [ "PZ006" ] . ToString ( ) , bandedGridView1 . GetDataRow ( i ) [ "PZ014" ] . ToString ( ) , bandedGridView1 . GetDataRow ( i ) [ "PZ027" ] . ToString ( ) , bandedGridView1 . GetDataRow ( i ) [ "PZ013" ] . ToString ( ) , 0 . ToString ( ) , "" , bandedGridView1 . GetDataRow ( i ) [ "PZ017" ] . ToString ( ) ,/*u15Cal.ToString( )*/count . ToString ( ) , Logins . username , System . DateTime . Now , _model . PZ001 , query );
            //                    if ( result == false )
            //                    {
            //                        MessageBox . Show ( "出库失败" );
            //                        break;
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            for ( int i = 0 ; i < libraryTable . Rows . Count ; i++ )
            {
                //出库单号
                _model . PZ002 = libraryTable . Rows [ i ] [ "tOne" ] . ToString ( );
                if ( _model . PZ002 . Contains ( "R_464" ) )
                {
                    //每套用量
                    _model . PZ015 = string . IsNullOrEmpty ( libraryTable . Rows [ i ] [ "tFor" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( libraryTable . Rows [ i ] [ "tFor" ] . ToString ( ) );

                    tableQuery = _bll . GetDataTableAC ( _model . PZ002 );
                    if ( tableQuery != null && tableQuery . Rows . Count > 0 )
                    {
                        _model . PZ014 = tableQuery . Rows [ 0 ] [ "AC04" ] . ToString ( );
                        _model . PZ027 = tableQuery . Rows [ 0 ] [ "AC05" ] . ToString ( );
                        _model . PZ013 = tableQuery . Rows [ 0 ] [ "AC06" ] . ToString ( );
                    }

                    result = fc . LibraryOf ( textBox1 . Text ,textBox4 . Text ,textBox2 . Text ,bandedGridView1 . GetDataRow ( 0 ) [ "PZ006" ] . ToString ( ) ,_model . PZ014 ,_model . PZ027 ,_model . PZ013 ,0 . ToString ( ) ,"" ,0 . ToString ( ) ,/*u15Cal.ToString( )*/_model . PZ015 . ToString ( ) ,Logins . username ,System . DateTime . Now ,_model . PZ001 ,_model . PZ002 );
                    if ( result == false )
                    {
                        MessageBox . Show ( "出库失败" );
                        break;
                    }
                }
                else
                    result = false;
            }
            if ( result == true )
            {
                if ( WriteOfReceivablesTo ( ) == false )
                {
                    MessageBox . Show ( "写入241数据错误,请重新出库" );
                    return;
                }
                else
                {
                    MessageBox . Show ( "出库成功" );
                    _model . PZ003 = bandedGridView1 . GetDataRow ( 0 ) [ "PZ003" ] . ToString ( );
                    if ( speList . Count > 0 )
                        fc . deleteOfLibrary ( speList ,_model . PZ001 ,_model . PZ003 );
                }
            }
        }
        private void outC_PassDataBetweenForm ( object sender , PassDataWinFormEventArgs e )
        {
            libraryTable = new DataTable ( );
            conOne = e . ConOne;
            libraryTable = e . TabOne;
        }
        #endregion

        #region Query
        protected override void select ( )
        {
            base.select( );

            _model = new MulaolaoLibrary.GunQiChenBenLibrary( );
            SelectAll.GunQiChenBenAll gunQi = new SelectAll.GunQiChenBenAll( );
            gunQi.StartPosition = FormStartPosition.CenterScreen;
            gunQi.PassDataBetweenForm += new SelectAll.GunQiChenBenAll.PassDataBetweenFormHandler( gunQi_PassDataBetweenForm );
            gunQi.ShowDialog( );

            if ( _model.PZ001 != null )
                autoQuery( );
        }
        private void gunQi_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            _model.PZ001 = e.ConOne;
        }
        void autoQuery ( )
        {
            toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolLibrary . Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = toolAdd.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolStorage.Enabled = false;
            Ergodic.TablePageEnableFalse( pageList );
            Ergodic.SpliEnableFalse( spList );
            button7_Click( null ,null );
        }
        #endregion

    }
}
