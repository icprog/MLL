using Mulaolao.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FastReport;
using FastReport.Export.Xml;

namespace Mulaolao.Environmental
{
    public partial class R_FrmProductQuality : FormChild
    {
        public R_FrmProductQuality ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }

        MulaolaoLibrary.R_FrmProductQualityLibrary _model = new MulaolaoLibrary.R_FrmProductQualityLibrary( );
        MulaolaoBll.Bll.ProductQualityBll _bll = new MulaolaoBll.Bll.ProductQualityBll( );
        List<SplitContainer> spList = new List<SplitContainer>( );
        List<TabPage> pageList = new List<TabPage>( );
        SpecialPowers sp = new SpecialPowers( );
        bool result = false;
        string sign = "", file = ""; int num = 0;
        DataTable tableQuery = new DataTable( );
        DataTable dl = new DataTable( );
        Report report = new Report( ); DataSet RDataSet = new DataSet( );

        private void R_FrmProductQuality_Load ( object sender ,EventArgs e )
        {
            Power( this );
            spList.Clear( );
            spList.AddRange( new SplitContainer[] { splitContainer1 } );
            pageList.Clear( );
            pageList.AddRange( new TabPage[] { tabPageOne ,tabPageTwo ,tabPageTre } );
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableFalse( pageList );
            label44.Visible = label107.Visible = false;
            gridView1.OptionsBehavior.Editable = false;
        }

        #region Print
        void CreatePrint ( )
        {
            DataTable print = _bll.GetDataTablePrint( _model.BD001 );
            DataTable prints = _bll.GetDataTableExport( _model.BD001 );
            print.TableName = "R_PQBD";
            prints.TableName = "R_PQBDS";
            RDataSet.Tables.AddRange( new DataTable[] { print ,prints } );
        }
        #endregion

        #region Main
        protected override void add ( )
        {
            base.add( );

            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableTrue( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableTrue( pageList );
            _model.BD001 = oddNumbers.purchaseContract( "SELECT MAX(AJ026) AJ026 FROM R_PQAJ" ,"AJ026" ,"R_365-" );
            label44.Visible = label107.Visible = false;
            sign = "1";
            gridView1.OptionsBehavior.Editable = true;
            gridControl1.DataSource = null;
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void delete ( )
        {
            base.delete( );

            if ( label107.Visible == true )
            {
                if ( Logins.number == "MLL-0001" )
                    dele( );
                else
                    MessageBox.Show( "单据状态为执行,需要总经理删除" );
            }
            else
                dele( );
        }
        void dele ( )
        {
            result = _bll.Delete( _model.BD001 );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                Ergodic.SpliClear( spList );
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.TablePageEnableFalse( pageList );
                gridControl1.DataSource = null;

                label44.Visible = label107.Visible = false;
                sign = "";
                gridView1.OptionsBehavior.Editable = false;
                toolAdd.Enabled = toolSelect.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            }
            else
                MessageBox.Show( "删除失败,请重试" );
        }
        protected override void update ( )
        {
            base.update( );

            if ( label107.Visible == true )
                MessageBox.Show( "此单已执行请维护" );
            else
            {
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );

                sign = "2";
                gridView1.OptionsBehavior.Editable = true;
                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
                textBox6.Enabled = false;
            }
        }
        protected override void revirw ( )
        {
            base.revirw( );

            Reviews( "BD001" ,_model.BD001 ,"R_PQBD" ,this ,"" ,"R_365" ,false ,false,MulaolaoBll . Drity . GetDt ( )/*,"" ,"" ,"" ,"" ,"" ,"" ,"","R_196"*/ );

            result = sp.reviewImple( "R_365" ,_model.BD001 );
            if ( result == true )
                label107.Visible = true;
            else
                label107.Visible = false;
        }
        protected override void print ( )
        {
            base.print( );

            if ( label107.Visible == true )
            {
                file = "";
                file = Application.StartupPath + "\\R_365.frx";
                CreatePrint( );
                report.Load( file );
                report.RegisterData( RDataSet );
                report.Show( );
            }
            else
                MessageBox.Show( "非执行单据不允许打印" );
        }
        protected override void export ( )
        {
            base.export( );

            file = "";
            file = Environment.CurrentDirectory;
            report.Load( file + "\\R_365.frx" );
            CreatePrint( );
            report.RegisterData( RDataSet );
            report.Prepare( );
            XMLExport exprots = new XMLExport( );
            exprots.Export( report );
        }
        protected override void save ( )
        {
            base.save( );

            if ( string.IsNullOrEmpty( textBox2.Text ) )
            {
                MessageBox.Show( "流水号不可为空" );
                return;
            }
            gridView1.UpdateCurrentRow( );
            variable ( );
            if ( tableQuery != null && tableQuery . Rows . Count > 0 )
            {
                for ( int i = 0 ; i < tableQuery . Rows . Count ; i++ )
                {
                    DataRow row=tableQuery.Rows[i];
                    row . BeginEdit ( );
                    row [ "BD002" ] = _model . BD002;
                    row [ "BD003" ] = _model . BD003;
                    row [ "BD004" ] = _model . BD004;
                    row [ "BD006" ] = _model . BD006;
                    row [ "BD007" ] = _model . BD007;
                    row [ "BD008" ] = _model . BD008;
                    row [ "BD009" ] = _model . BD009;
                    row [ "BD010" ] = _model . BD010;
                    row [ "BD011" ] = _model . BD011;
                    row [ "BD012" ] = _model . BD012;
                    row [ "BD013" ] = _model . BD013;
                    row [ "BD014" ] = _model . BD014;
                    row [ "BD040" ] = _model . BD040;
                    row [ "BD041" ] = _model . BD041;
                    row . EndEdit ( );
                }
            }
            if ( tableQuery != null && tableQuery.Rows.Count > 0 )
            {
                result = _bll.SaveOf( tableQuery );
                if ( result == true )
                {
                    //_model.BD001 = tableQuery.Rows[0]["BD001"].ToString( );
                   
                    //result = _bll.SaveOfUpdate( _model );
                    //if ( result == true )
                    //{
                        MessageBox.Show( "保存数据成功" );
                        saveState( );
                    //}
                    //else
                    //    MessageBox.Show( "保存数据失败,请重试" );
                }
                else
                    MessageBox.Show( "保存数据失败,请重试" );
            }

        }
        void saveState ( )
        {
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
            label44.Visible = false;
            gridView1.OptionsBehavior.Editable = false;
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolExport.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
            sign = "";
        }
        void variable ( )
        {
            _model.BD002 = textBox1.Text;
            _model.BD004 = textBox3.Text;
            _model.BD005 = string.IsNullOrEmpty( textBox4.Text ) == true ? 0 : Convert.ToInt32( textBox4.Text );
            _model.BD006 = comboBox1.Text;
            _model.BD007 = comboBox2.Text;
            _model.BD008 = comboBox3.Text;
            _model.BD009 = comboBox4.Text;
            _model.BD010 = dateTimePicker1.Value;
            _model.BD011 = dateTimePicker2.Value;
            _model.BD012 = dateTimePicker3.Value;
            _model.BD013 = dateTimePicker4.Value;
            _model.BD014 = string.IsNullOrEmpty( textBox5.Text ) == true ? 0 : Convert.ToInt32( textBox5.Text );
            _model.BD041 = textBox6.Text;
            if ( sign == "3" )
                _model.BD040 = "[" + Logins.number + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";
            else
                _model.BD040 = "";
        }
        protected override void cancel ( )
        {
            base.cancel( );

            if ( ( sign == "1" || sign == "4" ) && sign != "3" )
            {
                Ergodic.SpliClear( spList );
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.TablePageEnableFalse( pageList );

                label107.Visible = label44.Visible = false;
                sign = "";
                gridView1.OptionsBehavior.Editable = false;
                gridControl1.DataSource = null;

                toolSelect.Enabled = toolAdd.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolExport.Enabled = false;

                try
                {
                    _bll.Delete( _model.BD001 );
                }
                catch { }
            }
            else if ( sign == "2" || sign == "3" )
            {
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableFalse( pageList );
                gridView1.OptionsBehavior.Editable = false;
                toolSelect.Enabled = toolAdd.Enabled = toolcopy.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolExport.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
            }
        }
        protected override void maintain ( )
        {
            base.maintain( );

            if ( label107.Visible == true )
            {
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );

                sign = "3";
                toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
                gridView1.OptionsBehavior.Editable = true;
            }
            else
                MessageBox.Show( "非执行单据,请更改" );
        }
        protected override void copys ( )
        {
            base.copys( );

            result = _bll.Copys( _model.BD001 );
            if ( result == false )
            {
                MessageBox.Show( "复制失败,请重试" );
                return;
            }
            _model.BD001 = oddNumbers.purchaseContract( "SELECT MAX(AJ026) AJ026 FROM R_PQAJ" ,"AJ026" ,"R_365-" );
            result = _bll.UpdateCopy( _model.BD001 );
            if ( result == false )
            {
                MessageBox.Show( "复制失败,请重试" );
                _bll.DleteCopy( );
                return;
            }
            MessageBox.Show( "成功复制数据" );
            Ergodic.SpliEnableTrue( spList );
            Ergodic.TablePageEnableTrue( pageList );

            sign = "4";
            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
            label44.Visible = true;
            label107.Visible = false;
            queryContent( );
        }
        #endregion

        #region Table
        void refre ( )
        {
            tableQuery = _bll.GetDataTableOf( _model.BD001 );
            gridControl1.DataSource = tableQuery;
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox2.Text ) )
            {
                MessageBox.Show( "流水号不可为空" );
                return;
            }
            _model.BD003 = textBox2.Text;
            tableQuery = _bll.GetDataTableOf( _model.BD001 ,_model.BD003 );
            gridControl1.DataSource = tableQuery;
        }
        #endregion

        #region Event
        private void gridView1_CustomDrawRowIndicator ( object sender ,DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e )
        {
            if ( e.Info.Kind == DevExpress.Utils.Drawing.IndicatorKind.Band )
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
        private void gridView1_InitNewRow ( object sender ,DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e )
        {
            DevExpress.XtraGrid.Views.Grid.GridView view = sender as DevExpress.XtraGrid.Views.Grid.GridView;
            view.SetRowCellValue( e.RowHandle ,view.Columns["BD001"] ,_model.BD001 );
            gridView1 . UpdateCurrentRow ( );
            string maxX=tableQuery.Compute("MAX(BD043)",null).ToString();
            if ( !string . IsNullOrEmpty ( maxX ) )
            {
                if ( Convert . ToInt32 ( maxX ) < 9 )
                    _model . BD043 = "00" + Convert . ToInt32 ( maxX ) + 1;
                else if ( Convert . ToInt32 ( maxX ) >= 9 && Convert . ToInt32 ( maxX ) < 99 )
                    _model . BD043 = "0" + Convert . ToInt32 ( maxX ) + 1;
                else
                    _model . BD043 = ( Convert . ToInt32 ( maxX ) + 1 ) . ToString ( );
            }
            else
                _model . BD043 = "001";
            view . SetRowCellValue ( e . RowHandle , view . Columns [ "BD043" ] , _model . BD043 );
        }
        private void textBox5_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void gridView1_KeyDown ( object sender , KeyEventArgs e )
        {
            if ( gridView1 . OptionsBehavior . Editable == true )
            {
                if ( e . KeyCode == Keys . Delete )
                {
                    int num = gridView1.FocusedRowHandle;
                    gridView1 . UpdateCurrentRow ( );
                    if ( num >= 0 && num <= tableQuery . Rows . Count - 1 )
                    {
                        gridView1 . DeleteRow ( num );
                    }
                }
            }
        }
        #endregion

        #region Query
        protected override void select ( )
        {
            base.select( );

            _model = new MulaolaoLibrary.R_FrmProductQualityLibrary( );
            SelectAll.ProductQualityAll query = new SelectAll.ProductQualityAll( );
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.ProductQualityAll.PassDataBetweenFormHandler( query_PassDataBetWeenForm );
            query.ShowDialog( );

            if ( _model.BD001 != null )
                autoQuery( );
        }
        private void query_PassDataBetWeenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            _model.BD001 = e.ConOne;
            if ( e.ConTwo == "执行" )
                label107.Visible = true;
            else
                label107.Visible = false;
        }
        void autoQuery ( )
        {
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;

            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
            gridView1.OptionsBehavior.Editable = false;
            sign = "2";
            gridView1.OptionsBehavior.Editable = false;
            queryContent( );
        }
        void queryContent ( )
        {
            _model = _bll.GetModel( _model.BD001 );
            if ( _model == null )
                return;
            textBox1.Text = _model.BD002;
            textBox2.Text = _model.BD003;
            textBox3.Text = _model.BD004;
            textBox4.Text = _model.BD005.ToString( );
            comboBox1.Text = _model.BD006;
            comboBox2.Text = _model.BD007;
            comboBox3.Text = _model.BD008;
            comboBox4.Text = _model.BD009;
            if ( _model.BD010 > DateTime.MinValue && _model.BD010 < DateTime.MaxValue )
                dateTimePicker1.Value = _model.BD010;
            if ( _model.BD011 > DateTime.MinValue && _model.BD011 < DateTime.MaxValue )
                dateTimePicker2.Value = _model.BD011;
            if ( _model.BD012 > DateTime.MinValue && _model.BD012 < DateTime.MaxValue )
                dateTimePicker3.Value = _model.BD012;
            if ( _model.BD013 > DateTime.MinValue && _model.BD013 < DateTime.MaxValue )
                dateTimePicker4.Value = _model.BD013;
            textBox5.Text = _model.BD014.ToString( );
            textBox6.Text = _model.BD041;
            refre( );
        }
        private void button1_Click ( object sender ,EventArgs e )
        {
            SelectAll.QualityTestingNumQuery queryNum = new SelectAll.QualityTestingNumQuery( );
            queryNum.StartPosition = FormStartPosition.CenterScreen;
            queryNum.PassDataBetweenForm += new SelectAll.QualityTestingNumQuery.PassDataBetweenFormHandler( queryNum_PassDataBetWennForm );
            queryNum.ShowDialog( );
        }
        private void queryNum_PassDataBetWennForm ( object sender ,PassDataWinFormEventArgs e )
        {
            textBox2.Text = e.ConOne;
            textBox3.Text = e.ConTwo;
            textBox1.Text = e.ConTre;
            textBox4.Text = e.ConFor;
        }
        #endregion
    }
}
