using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;
using FastReport;
using FastReport . Export . Xml;

namespace Mulaolao.Wages
{
    public partial class R_FrmTeamLeaderRoutineCheck : FormChild
    {
        public R_FrmTeamLeaderRoutineCheck ( )
        {
            InitializeComponent ( );

            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { bandedGridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.TeamLeaderRoutineCheckLibrary _model = new MulaolaoLibrary.TeamLeaderRoutineCheckLibrary( );
        MulaolaoBll.Bll.TeamLeaderRoutineCheckBll _bll = new MulaolaoBll.Bll.TeamLeaderRoutineCheckBll( );
        List<SplitContainer> spList = new List<SplitContainer>( );
        List<TabPage> pageList = new List<TabPage>( );
        SpecialPowers sp = new SpecialPowers( );
        bool result = false;
        string sign = "", weihu = "",files="";
        DataTable tableQuery;
        DataSet RData=new DataSet();Report report=new Report();
        
        //DBA960  男  女  其他
        
        private void R_FrmTeamLeaderRoutineCheck_Load ( object sender ,EventArgs e )
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
            label45.Visible = false;
            bandedGridView1.OptionsBehavior.Editable = false;
            
        }

        #region Print
        void createPrint ( )
        {
            DataTable printOne = _bll . PrintOne ( _model . QZ001 );
            DataTable printTwo = _bll . PrintTwo ( _model . QZ001 );
            DataTable printTre = _bll . GetDataTableOfSum ( _model . QZ001 );
            _model . QZ002 = dateTimePicker1 . Value;
            DataTable printFore = _bll . GetDataTableOfCountSum ( _model . QZ001 ,_model . QZ002 );

            printOne . TableName = "R_PQQZ";
            printTwo . TableName = "R_PQQZO";
            printTre . TableName = "PrintOne";
            printFore . TableName = "PrintTwo";

            RData = new DataSet ( );
            RData . Tables . AddRange ( new DataTable [ ] { printOne ,printTwo ,printTre ,printFore } );
        }
        #endregion

        #region Query
        protected override void select ( )
        {
            base.select( );

            _model = new MulaolaoLibrary.TeamLeaderRoutineCheckLibrary( );
            SelectAll.TeamLeaderRoutineCheckAll query = new SelectAll.TeamLeaderRoutineCheckAll( );
            if ( query . ShowDialog ( ) == DialogResult . Cancel )
                return;
            string [ ] str = query . strList;
            _model . QZ001 = str [ 0 ];
            if ( str [ 1 ] . Equals ( "执行" ) )
                label45 . Visible = true;
            else
                label45 . Visible = false;
            //query.StartPosition = FormStartPosition.CenterScreen;
            //query.PassDataBetweenForm += new SelectAll.TeamLeaderRoutineCheckAll.PassDataBetweenFormHandler( query_PassDataBetween );
            //query.ShowDialog( );
            if ( _model.QZ001 != null )
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
                bandedGridView1.OptionsBehavior.Editable = false;
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableFalse( pageList );
                
                _model = _bll.GetModel( _model.QZ001 );
                if ( _model == null )
                    return;
                textBox5 . Tag = _model . QZ001;
                textBox5.Text = _model.QZ009.ToString( );
                textBox6.Text = _model.QZ011.ToString( );
                textBox7.Text = _model.QZ012.ToString( );
                textBox8.Text = _model.QZ017.ToString( );
                textBox9.Text = _model.QZ018.ToString( );
                textBox10.Text = _model.QZ020.ToString( );
                textBox12.Text = _model.QZ022.ToString( );
                textBox13.Text = _model.QZ024.ToString( );
                textBox14.Text = _model.QZ026.ToString( );
                textBox15.Text = _model.QZ028.ToString( );
                textBox16.Text = _model.QZ030.ToString( );
                textBox1.Text = _model.QZ031;
                if ( _model.QZ032 > DateTime.MinValue && _model.QZ032 < DateTime.MaxValue )
                    dateTimePicker2.Value = _model.QZ032;
                textBox2.Text = _model.QZ033;
                if ( _model.QZ034 > DateTime.MinValue && _model.QZ034 < DateTime.MaxValue )
                    dateTimePicker3.Value = _model.QZ034;
                textBox3.Text = _model.QZ035;
                if ( _model.QZ036 > DateTime.MinValue && _model.QZ036 < DateTime.MaxValue )
                    dateTimePicker4.Value = _model.QZ036;
                if ( _model.QZ002 > DateTime.MinValue && _model.QZ002 < DateTime.MaxValue )
                    dateTimePicker1.Value = _model.QZ002;
                textBox4.Text = _model.QZ038;
                assignMent ( );
            }
        }
        private void query_PassDataBetween ( object sneder ,PassDataWinFormEventArgs e )
        {
            _model.QZ001 = e.ConOne;
            if ( e.ConTwo == "执行" )
                label45.Visible = true;
            else
                label45.Visible = false;
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
            gridControl1.DataSource = null;
            _model.QZ001 = oddNumbers.purchaseContract( "SELECT MAX(QZ001) QZ001 FROM R_PQQZ" ,"QZ001" ,"R_351-" );
            textBox5 . Tag = _model . QZ001;
            label45.Visible = false;
            textBox4.Enabled = false;
            sign = "1";
            bandedGridView1.OptionsBehavior.Editable = true;
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void delete ( )
        {
            base.delete( );

            if ( label45.Visible == true )
            {
                if ( Logins.number == "MLL-0001" )
                    dele( );
                else
                    MessageBox.Show( "此单已经执行,需要总经理删除" );
            }
            else
                dele( );
        }
        void dele ( )
        {
            result = _bll . Delete ( _model . QZ001 ,dateTimePicker1 . Value );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;

                Ergodic.SpliClear( spList );
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.TablePageEnableFalse( pageList );
                gridControl1.DataSource = null;
                label45.Visible = false;
                bandedGridView1.OptionsBehavior.Editable = false;
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        protected override void update ( )
        {
            base.update( );

            if ( label45.Visible == true )
                MessageBox.Show( "此单为执行状态,请维护" );
            else
            {
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );
                textBox4.Enabled = false;
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
                bandedGridView1.OptionsBehavior.Editable = true;
            }
        }
        protected override void revirw ( )
        {
            base.revirw( );

            Reviews( "QZ001" ,_model.QZ001 ,"R_PQQZ" ,this ,"" ,"R_351" ,false ,false ,MulaolaoBll . Drity . GetDt ( )/*,"" ,"" ,"" ,"" ,"" ,"" ,"","R_195"*/ );
            result = sp.reviewImple( "R_351" ,_model.QZ001 );
            if ( result == true )
                label45.Visible = true;
            else
                label45.Visible = false;
        }
        protected override void save ( )
        {
            base.save( );

            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "填表人不可为空" );
                return;
            }
            if ( weihu == "1" )
            {
                if ( string.IsNullOrEmpty( textBox4.Text ) )
                {
                    MessageBox.Show( "维护信息不可为空" );
                    return;
                }
                saves( );
            }
            else
                saves( );
        }
        void saveState ( )
        {
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
            textBox4.Enabled = false;
            sign = "";
            bandedGridView1.OptionsBehavior.Editable = false;
        }
        void saveArrable ( )
        {
            _model.QZ002 = Convert.ToDateTime( dateTimePicker1.Value.ToString( "yyyy-MM" ) );
            _model.QZ031 = textBox1.Text;
            _model.QZ032 = dateTimePicker2.Value;
            _model.QZ033 = textBox2.Text;
            _model.QZ034 = dateTimePicker3.Value;
            _model.QZ035 = textBox3.Text;
            _model.QZ036 = dateTimePicker4.Value;
            _model.QZ038 = textBox4.Text;
        }
        void saves ( )
        {
            bandedGridView1.UpdateCurrentRow( );
            if ( tableQuery != null )
            {
                saveArrable( );
                for ( int i = 0 ; i < tableQuery.Rows.Count ; i++ )
                {
                    tableQuery.Rows[i]["QZ002"] = _model.QZ002;
                    tableQuery.Rows[i]["QZ031"] = _model.QZ031;
                    tableQuery.Rows[i]["QZ032"] = _model.QZ032;
                    tableQuery.Rows[i]["QZ033"] = _model.QZ033;
                    tableQuery.Rows[i]["QZ034"] = _model.QZ034;
                    tableQuery.Rows[i]["QZ035"] = _model.QZ035;
                    tableQuery.Rows[i]["QZ036"] = _model.QZ036;
                    tableQuery.Rows[i]["QZ037"] = "";
                    tableQuery.Rows[i]["QZ038"] = _model.QZ038;
                }
                result = _bll.UpdateTable( tableQuery );
                if ( result == true )
                {
                    MessageBox.Show( "成功保存数据" );
                    saveState( );
                }
                else
                    MessageBox.Show( "保存数据失败" );
            }
        }
        protected override void cancel ( )
        {
            base.cancel( );

            if ( sign == "1" && weihu != "1" )
            {
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                Ergodic.SpliClear( spList );
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.TablePageEnableFalse( pageList );
                label45.Visible = false;
                bandedGridView1.OptionsBehavior.Editable = false;
                try
                {
                    _bll . Delete ( _model . QZ001 ,dateTimePicker1 . Value );
                }
                catch { }
            }
            else
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                bandedGridView1.OptionsBehavior.Editable = false;
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableFalse( pageList );
            }
        }
        protected override void maintain ( )
        {
            base.maintain( );

            if ( label45.Visible == true )
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );
                label45.Visible = true;
                bandedGridView1.OptionsBehavior.Editable = true;
            }
            else
                MessageBox.Show( "此单状态非执行,请更改" );
        }
        protected override void print ( )
        {
            base . print ( );

            //if ( label45 . Visible == false )
            //{
            //    MessageBox . Show ( "非执行单据不允许打印" );
            //    return;
            //}
            //files = Application . StartupPath + "\\R_351.frx";
            //createPrint ( );
            //report . Load ( files );
            //report . RegisterData ( RData );
            //report . Show ( );
        }
        protected override void export ( )
        {
            base . export ( );

            files = Application . StartupPath + "\\R_351.frx";
            createPrint ( );
            report . Load ( files );
            report . RegisterData ( RData );
            report . Prepare ( );
            XMLExport exprots = new XMLExport ( );
            exprots . Export ( report );

            //ViewExport . ExportToExcel ( this . Text ,gridControl1 );

        }
        #endregion

        #region Event
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( !string.IsNullOrEmpty( textBox1.Text ) && textBox1.Text == Logins.username )
                textBox1.Text = "";
            else
                textBox1.Text = Logins.username;
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( !string.IsNullOrEmpty( textBox2.Text ) && textBox2.Text == Logins.username )
                textBox2.Text = "";
            else
                textBox2.Text = Logins.username;
        }
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( !string.IsNullOrEmpty( textBox3.Text ) && textBox3.Text == Logins.username )
                textBox3.Text = "";
            else
                textBox3.Text = Logins.username;
        }
        private void textBox5_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox5 );
        }
        private void textBox5_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox5 );
        }
        private void textBox5_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox5.Text != "" && !DateDayRegise. ninFivTb ( textBox5 ) )
            {
                textBox5.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多五位,如9999.99999,请重新输入" );
            }
        }
        private void textBox11_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox11 );
        }
        private void textBox11_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox11 );
        }
        private void textBox11_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox11.Text != "" && !DateDayRegise. ninFivTb ( textBox11 ) )
            {
                textBox11.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多五位,如9999.99999,请重新输入" );
            }
        }
        private void textBox17_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox11 );
        }
        private void textBox17_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox11 );
        }
        private void textBox17_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox17.Text != "" && !DateDayRegise. ninFivTb ( textBox17 ) )
            {
                textBox17.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多五位,如9999.99999,请重新输入" );
            }
        }
        private void textBox6_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox18_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox19_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
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
            if ( textBox20.Text != "" && !DateDayRegise. ninFivTb ( textBox20 ) )
            {
                textBox20.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多五位,如9999.99999,请重新输入" );
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
            if ( textBox21.Text != "" && !DateDayRegise. ninFivTb ( textBox21 ) )
            {
                textBox21.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多五位,如9999.99999,请重新输入" );
            }
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
            if ( textBox7.Text != "" && !DateDayRegise. ninFivTb ( textBox7 ) )
            {
                textBox7.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多五位,如9999.99999,请重新输入" );
            }
        }
        private void textBox8_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox22_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox23_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox9_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox9 );
        }
        private void textBox9_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox9 );
        }
        private void textBox9_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox9.Text != "" && !DateDayRegise. ninFivTb ( textBox9 ) )
            {
                textBox9.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多五位,如9999.99999,请重新输入" );
            }
        }
        private void textBox10_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox10 );
        }
        private void textBox10_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox10 );
        }
        private void textBox10_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox10.Text != "" && !DateDayRegise. ninFivTb ( textBox10 ) )
            {
                textBox10.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多五位,如9999.99999,请重新输入" );
            }
        }
        private void textBox12_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox13_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox14_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox15_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox16_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void bandedGridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView1.FocusedRowHandle >= 0 && bandedGridView1.FocusedRowHandle <= bandedGridView1.RowCount - 1 )
            {
                _model.IDX = string.IsNullOrEmpty( bandedGridView1.GetDataRow( bandedGridView1.FocusedRowHandle )["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetDataRow( bandedGridView1.FocusedRowHandle )["idx"].ToString( ) );
                assignM( );
            }
        }
        void assignM ( )
        {
            _model = _bll.GetDataTable( _model.IDX );
            if ( _model == null )
                return;
            textBox5.Text = _model.QZ009.ToString( );
            textBox11.Text = _model.QZ015.ToString( );
            textBox6.Text = _model.QZ011.ToString( );
            textBox7.Text = _model.QZ012.ToString( );
            textBox8.Text = _model.QZ017.ToString( );
            textBox9.Text = _model.QZ018.ToString( );
            textBox10.Text = _model.QZ020.ToString( );
            textBox12.Text = _model.QZ022.ToString( );
            textBox13.Text = _model.QZ024.ToString( );
            textBox14.Text = _model.QZ026.ToString( );
            textBox15.Text = _model.QZ028.ToString( );
            textBox16.Text = _model.QZ030.ToString( );
            textBox17.Text = _model.QZ040.ToString( );
            textBox18.Text = _model.QZ016.ToString( );
            textBox19.Text = _model.QZ041.ToString( );
            textBox21.Text = _model.QZ042.ToString( );
            textBox7.Text = _model.QZ043.ToString( );
            textBox22.Text = _model.QZ044.ToString( );
            textBox23.Text = _model.QZ045.ToString( ); 
            textBox20 . Text = _model . QZ012 . ToString ( );
            textBox24 . Text = _model . QZ047 . ToString ( );
            textBox25 . Text = _model . QZ049 . ToString ( );
            if ( _model.QZ002 > DateTime.MinValue && _model.QZ002 < DateTime.MaxValue )
                dateTimePicker1.Value = _model.QZ002;
        }
        private void bandedGridView1_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            //sumOfCount( );
        }
        private void bandedGridView1_CustomDrawRowFooterCell ( object sender ,DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs e )
        {
            if ( tableQuery == null || tableQuery . Rows . Count < 1 )
                return;
            _model.QZ001 = tableQuery.Rows[0]["QZ001"].ToString( );
            DataTable de = _bll.GetDataTableOfGroupSum( _model.QZ001 );
            if ( de != null && de.Rows.Count > 0 )
            {
                if ( de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" ).Length > 0 )
                {
                    if ( e.Column == this.QZ006 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["QZ006"].ToString( );
                    if ( e.Column == this.QZ007 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["QZ007"].ToString( );
                    if ( e.Column == this.QZ008 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["QZ008"].ToString( );
                    if ( e.Column == this.U22 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U22"].ToString( );
                    if ( e.Column == this.U0 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U0"].ToString( );
                    if ( e.Column == this.U23 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U23"].ToString( );
                    if ( e.Column == this.U1 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U1"].ToString( );
                    if ( e.Column == this.QZ014 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["QZ014"].ToString( );
                    if ( e.Column == this.U4 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U4"].ToString( );
                    if ( e.Column == this.QZ013 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["QZ013"].ToString( );
                    if ( e.Column == this.U5 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U5"].ToString( );
                    if ( e.Column == this.U6 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U6"].ToString( );
                    if ( e.Column == this.U3 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U3"].ToString( );
                    if ( e.Column == this.U24 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U24"].ToString( );
                    if ( e.Column == this.U7 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U7"].ToString( );
                    if ( e.Column == this.U9 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U9"].ToString( );
                    if ( e.Column == this.U10 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U10"].ToString( );
                    if ( e.Column == this.U11 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U11"].ToString( );
                    if ( e.Column == this.U12 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U12"].ToString( );
                    if ( e.Column == this.QZ019 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["QZ019"].ToString( );
                    if ( e.Column == this.U13 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U13"].ToString( );
                    if ( e.Column == this.QZ021 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["QZ021"].ToString( );
                    if ( e.Column == this.U14 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U14"].ToString( );
                    if ( e.Column == this.QZ023 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["QZ023"].ToString( );
                    if ( e.Column == this.U15 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U15"].ToString( );
                    if ( e.Column == this.QZ025 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["QZ025"].ToString( );
                    if ( e.Column == this.U16 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U16"].ToString( );
                    if ( e.Column == this.QZ027 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["QZ027"].ToString( );
                    if ( e.Column == this.U17 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U17"].ToString( );
                    if ( e.Column == this.QZ029 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["QZ029"].ToString( );
                    if ( e.Column == this.U18 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U18"].ToString( );
                    if ( e.Column == this.U19 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U19"].ToString( );
                    if ( e.Column == this.U20 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U20"].ToString( );
                    if ( e.Column == this.U21 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["U21"].ToString( );
                    if ( e.Column == this.QZ039 )
                        e.Info.DisplayText = de.Select( "QZ003='" + bandedGridView1.GetDataRow( e.RowHandle )["QZ003"].ToString( ) + "'" )[0]["QZ039"].ToString( );
                    if ( e . Column == this . QZ046 )
                        e . Info . DisplayText = de . Select ( "QZ003='" + bandedGridView1 . GetDataRow ( e . RowHandle ) [ "QZ003" ] . ToString ( ) + "'" ) [ 0 ] [ "QZ046" ] . ToString ( );
                    if ( e . Column == this . QZ048 )
                        e . Info . DisplayText = de . Select ( "QZ003='" + bandedGridView1 . GetDataRow ( e . RowHandle ) [ "QZ003" ] . ToString ( ) + "'" ) [ 0 ] [ "QZ048" ] . ToString ( );
                }
            }
        }
        #endregion

        #region Table
        //Generate
        private void button4_Click ( object sender ,EventArgs e )
        {
            _model.QZ002 = dateTimePicker1.Value;
            result = _bll.Generate( _model.QZ002.ToString( "yyyyMM" ) ,_model.QZ002.Year ,_model.QZ002.Month ,_model );
            if ( result == true )
            {
                MessageBox.Show( "生成成功" );
                _bll . UpdateOf ( _model . QZ001 );
                assignMent( );              
            }
            else
                MessageBox.Show( "生成失败,请重试" );
        }
        //BatchEdit
        private void button5_Click ( object sender ,EventArgs e )
        {
            _model.QZ009 = string.IsNullOrEmpty( textBox5.Text ) == true ? 0 : Convert.ToDecimal( textBox5.Text );
            _model.QZ015 = string.IsNullOrEmpty( textBox11.Text ) == true ? 0 : Convert.ToDecimal( textBox11.Text );
            _model.QZ040 = string.IsNullOrEmpty( textBox17.Text ) == true ? 0 : Convert.ToDecimal( textBox17.Text );
            _model.QZ011 = string.IsNullOrEmpty( textBox6.Text ) == true ? 0 : Convert.ToInt32( textBox6.Text );
            _model.QZ016 = string.IsNullOrEmpty( textBox18.Text ) == true ? 0 : Convert.ToInt32( textBox18.Text );
            _model.QZ041 = string.IsNullOrEmpty( textBox19.Text ) == true ? 0 : Convert.ToInt32( textBox19.Text );
            _model.QZ012 = string.IsNullOrEmpty( textBox20.Text ) == true ? 0 : Convert.ToDecimal( textBox20.Text );
            _model.QZ042 = string.IsNullOrEmpty( textBox21.Text ) == true ? 0 : Convert.ToDecimal( textBox21.Text );
            _model.QZ043 = string.IsNullOrEmpty( textBox7.Text ) == true ? 0 : Convert.ToDecimal( textBox7.Text );
            _model.QZ017 = string.IsNullOrEmpty( textBox8.Text ) == true ? 0 : Convert.ToInt32( textBox8.Text );
            _model.QZ044 = string.IsNullOrEmpty( textBox22.Text ) == true ? 0 : Convert.ToInt32( textBox22.Text );
            _model.QZ045 = string.IsNullOrEmpty( textBox23.Text ) == true ? 0 : Convert.ToInt32( textBox23.Text );
            _model.QZ018 = string.IsNullOrEmpty( textBox9.Text ) == true ? 0 : Convert.ToDecimal( textBox9.Text );
            _model.QZ020 = string.IsNullOrEmpty( textBox10.Text ) == true ? 0 : Convert.ToDecimal( textBox10.Text );
            _model.QZ022 = string.IsNullOrEmpty( textBox12.Text ) == true ? 0 : Convert.ToInt32( textBox12.Text );
            _model.QZ024 = string.IsNullOrEmpty( textBox13.Text ) == true ? 0 : Convert.ToInt32( textBox13.Text );
            _model.QZ026 = string.IsNullOrEmpty( textBox14.Text ) == true ? 0 : Convert.ToInt32( textBox14.Text );
            _model.QZ028 = string.IsNullOrEmpty( textBox15.Text ) == true ? 0 : Convert.ToInt32( textBox15.Text );
            _model.QZ030 = string.IsNullOrEmpty( textBox16.Text ) == true ? 0 : Convert.ToInt32( textBox16.Text );
            _model . QZ047 = string . IsNullOrEmpty ( textBox24 . Text ) == true ? 0 : Convert . ToInt32 ( textBox24 . Text );
            _model . QZ049 = string . IsNullOrEmpty ( textBox25 . Text ) == true ? 0 : Convert . ToInt32 ( textBox25 . Text );
            result = _bll.UpdateOfCoe( _model );
            if ( result == true )
            {
                MessageBox.Show( "编辑成功" );
                assignMent( );
            }
            else
                MessageBox.Show( "编辑失败,请重试" );
        }
        //Edit
        private void button6_Click ( object sender ,EventArgs e )
        {
            //_model.QZ013 = string.IsNullOrEmpty( textBox11.Text ) == true ? 0 : Convert.ToInt32( textBox11.Text );
            result = _bll.UpdateOfEdit( _model.IDX ,_model.QZ013 );
            if ( result == true )
            {
                MessageBox.Show( "编辑成功" );
                assignMent( );
            }
            else
                MessageBox.Show( "编辑失败,请重试" );
        }
        void assignMent ( )
        {
            _model . QZ001 = textBox5 . Tag . ToString ( );
            tableQuery = _bll.GetDataTable( _model.QZ001 );
            gridControl1.DataSource = tableQuery;
            sumOfCount( );
        }
        void sumOfCount ( )
        {
            if ( tableQuery != null && tableQuery . Rows . Count > 0 )
            {
                DataTable da = _bll . GetDataTableOfSum ( _model . QZ001 );
                if ( da != null && da . Rows . Count > 0 )
                {
                    QZ006 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ006" ] . ToString ( ) );
                    QZ007 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ007" ] . ToString ( ) );
                    QZ008 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ008" ] . ToString ( ) );
                    U22 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U22" ] . ToString ( ) );
                    U0 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U0" ] . ToString ( ) );
                    U23 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U23" ] . ToString ( ) );
                    U1 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U1" ] . ToString ( ) );
                    U1 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U1" ] . ToString ( ) );
                    QZ014 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ014" ] . ToString ( ) );
                    U4 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U4" ] . ToString ( ) );
                    QZ013 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ013" ] . ToString ( ) );
                    U5 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U5" ] . ToString ( ) );
                    U6 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U6" ] . ToString ( ) );
                    U3 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U3" ] . ToString ( ) );
                    U24 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U24" ] . ToString ( ) );
                    U7 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U7" ] . ToString ( ) );
                    U9 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U9" ] . ToString ( ) );
                    U10 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U10" ] . ToString ( ) );
                    U11 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U11" ] . ToString ( ) );
                    U12 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U12" ] . ToString ( ) );
                    QZ019 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ019" ] . ToString ( ) );
                    U13 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U13" ] . ToString ( ) );
                    QZ021 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ021" ] . ToString ( ) );
                    U14 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U14" ] . ToString ( ) );
                    QZ023 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ023" ] . ToString ( ) );
                    U15 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U15" ] . ToString ( ) );
                    QZ025 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ025" ] . ToString ( ) );
                    U16 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U16" ] . ToString ( ) );
                    QZ027 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ027" ] . ToString ( ) );
                    U17 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U17" ] . ToString ( ) );
                    QZ029 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ029" ] . ToString ( ) );
                    U18 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U18" ] . ToString ( ) );
                    QZ039 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ039" ] . ToString ( ) );
                    U19 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U19" ] . ToString ( ) );
                    U20 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U20" ] . ToString ( ) );
                    U21 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U21" ] . ToString ( ) );
                    QZ046 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ046" ] . ToString ( ) );
                    QZ048 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ048" ] . ToString ( ) );
                }
                da = new DataTable ( );
                _model . QZ002 = dateTimePicker1 . Value;
                da = _bll . GetDataTableOfCountSum ( _model . QZ001 ,_model . QZ002 );
                if ( da != null && da . Rows . Count > 0 )
                {
                    QZ006 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ006" ] . ToString ( ) );
                    QZ007 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ007" ] . ToString ( ) );
                    QZ008 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ008" ] . ToString ( ) );
                    U22 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U22" ] . ToString ( ) );
                    U0 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U0" ] . ToString ( ) );
                    U23 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U23" ] . ToString ( ) );
                    //U1 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U1" ] . ToString ( ) );
                    //U1 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,U1 . Summary [ 0 ] . SummaryValue . ToString ( ) );
                    QZ014 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ014" ] . ToString ( ) );
                    U4 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U4" ] . ToString ( ) );
                    QZ013 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ013" ] . ToString ( ) );
                    U5 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U5" ] . ToString ( ) );
                    U6 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U6" ] . ToString ( ) );
                    U3 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U3" ] . ToString ( ) );
                    U24 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U24" ] . ToString ( ) );
                    U7 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U7" ] . ToString ( ) );
                    U9 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U9" ] . ToString ( ) );
                    U10 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U10" ] . ToString ( ) );
                    U11 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U11" ] . ToString ( ) );
                    U12 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U12" ] . ToString ( ) );
                    QZ019 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ019" ] . ToString ( ) );
                    U13 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U13" ] . ToString ( ) );
                    QZ021 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ021" ] . ToString ( ) );
                    U14 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U14" ] . ToString ( ) );
                    QZ023 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ023" ] . ToString ( ) );
                    U15 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U15" ] . ToString ( ) );
                    QZ025 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ025" ] . ToString ( ) );
                    U16 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U16" ] . ToString ( ) );
                    QZ027 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ027" ] . ToString ( ) );
                    U17 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U17" ] . ToString ( ) );
                    QZ029 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ029" ] . ToString ( ) );
                    U18 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U18" ] . ToString ( ) );
                    QZ039 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ039" ] . ToString ( ) );
                    U19 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U19" ] . ToString ( ) );
                    U20 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U20" ] . ToString ( ) );
                    U21 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "U21" ] . ToString ( ) );
                    QZ046 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ046" ] . ToString ( ) );
                    QZ048 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,da . Rows [ 0 ] [ "QZ048" ] . ToString ( ) );
                   
                    //U3有问题
                }
            }
        }
        #endregion

    }
}
