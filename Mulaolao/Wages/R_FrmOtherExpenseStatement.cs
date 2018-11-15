using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Wages
{
    public partial class R_FrmOtherExpenseStatement : FormChild
    {
        public R_FrmOtherExpenseStatement ( )
        {
            InitializeComponent( );


            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.OtherExpenseStatementLibrary _model = new MulaolaoLibrary.OtherExpenseStatementLibrary( );
        MulaolaoBll.Bll.OtherExpenseStatementBll _bll = new MulaolaoBll.Bll.OtherExpenseStatementBll( );
        List<SplitContainer> spList = new List<SplitContainer>( );
        List<TabPage> pageList = new List<TabPage>( );
        DataRow row;
        DataTable tableQuery;
        bool result = false;
        string strWhere = "", sign = "";

        private void R_FrmOtherExpenseStatement_Load ( object sender ,EventArgs e )
        {
            Power( this );
            spList.Clear( );
            pageList.Clear( );
            spList.AddRange( new SplitContainer[] { splitContainer1 } );
            pageList.AddRange( new TabPage[] { tabPageOne } );
            Ergodic.SpliClear( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableTrue( pageList );

            comboBox1.DataSource = _bll.GetDataTableOf( );
            comboBox1.DisplayMember = "DGA003";
            comboBox1.ValueMember = "DGA001";

            foreach ( DevExpress . XtraGrid . Columns . GridColumn col in gridView1 . Columns )
            {
                col . OptionsFilter . FilterPopupMode = DevExpress . XtraGrid . Columns . FilterPopupMode . CheckedList;
            }
        }

        #region Main
        protected override void add ( )
        {
            base.add( );

            _model.BE015 = oddNumbers.purchaseContract( "SELECT MAX(AJ027) AJ027 FROM R_PQAJ" ,"AJ027" ,"R_243-" );
            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolReview.Enabled = toolMaintain.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
            Ergodic.SpliClear( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.SpliEnableTrue( spList );
            Ergodic.TablePageEnableTrue( pageList );
            gridControl1.DataSource = null;
            tableQuery = null;
        }
        protected override void delete ( )
        {
            base.delete( );

            sign = "";
            for ( int i = 0 ; i < gridView1.DataRowCount - 1 ; i++ )
            {
                if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["BE013"].ToString( ) ) && ( gridView1.GetDataRow( i )["BE013"].ToString( ) == "审核" || gridView1.GetDataRow( i )["BE013"].ToString( ) == "执行" ) )
                {
                    MessageBox.Show( "已经存在审核或执行记录,此单不能全部删除,请选择个别删除" );
                    sign = "1";
                    break;
                }
            }
            if ( sign == "1" )
                return;
            result = _bll.DeleteAll( _model.BE015 );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                toolAdd.Enabled = toolSelect.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = false;
                Ergodic.SpliClear( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableFalse( pageList );
                gridControl1.DataSource = null;
                tableQuery = null;
            }
            else
                MessageBox.Show( "删除数据失败,请重试" );
        }
        protected override void update ( )
        {
            base.update( );

            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolReview.Enabled = toolMaintain.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
            Ergodic.SpliEnableTrue( spList );
            Ergodic.TablePageEnableTrue( pageList );
        }
        protected override void save ( )
        {
            base.save( );

            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolReview.Enabled = toolMaintain.Enabled = false;
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
        }
        protected override void cancel ( )
        {
            base.cancel( );

            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolReview.Enabled = toolMaintain.Enabled = false;
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
        }
        #endregion

        #region Event
        private void textBox6_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox6 );        
        }
        private void textBox6_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox6 );
        }
        private void textBox6_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox6.Text != "" && !DateDayRegise.elevenTwoNumber( textBox6 ) )
            {
                textBox6.Text = "";
                MessageBox.Show( "只允许输入整数部分最多九位,小数部分最多两位,如999999999.99,请重新输入" );
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
            if ( textBox7.Text != "" && !DateDayRegise.elevenTwoNumber( textBox7 ) )
            {
                textBox7.Text = "";
                MessageBox.Show( "只允许输入整数部分最多九位,小数部分最多两位,如999999999.99,请重新输入" );
            }
        }
        private void textBox8_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox8 );
        }
        private void textBox8_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox8 );
        }
        private void textBox8_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox8.Text != "" && !DateDayRegise.elevenTwoNumber( textBox8 ) )
            {
                textBox8.Text = "";
                MessageBox.Show( "只允许输入整数部分最多九位,小数部分最多两位,如999999999.99,请重新输入" );
            }
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
            if ( textBox9.Text != "" && !DateDayRegise.elevenTwoNumber( textBox9 ) )
            {
                textBox9.Text = "";
                MessageBox.Show( "只允许输入整数部分最多九位,小数部分最多两位,如999999999.99,请重新输入" );
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
            if ( textBox10.Text != "" && !DateDayRegise.elevenTwoNumber( textBox10 ) )
            {
                textBox10.Text = "";
                MessageBox.Show( "只允许输入整数部分最多九位,小数部分最多两位,如999999999.99,请重新输入" );
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
            if ( textBox11.Text != "" && !DateDayRegise.elevenTwoNumber( textBox11 ) )
            {
                textBox11.Text = "";
                MessageBox.Show( "只允许输入整数部分最多九位,小数部分最多两位,如999999999.99,请重新输入" );
            }
        }
        private void comboBox1_SelectedIndexChanged ( object sender ,EventArgs e )
        {
           
        }
        private void comboBox1_SelectedValueChanged ( object sender ,EventArgs e )
        {
            _model.BE016 = comboBox1.SelectedValue.ToString( );
        }
        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.DataRowCount - 1 )
            {
                _model.idx = string.IsNullOrEmpty( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                assignMent( );
            }
        }
        void assignMent ( )
        {
            _model = _bll.GetDataTable( _model.idx );
            if ( _model == null )
                return;
            textBox1.Text = _model.BE001;
            textBox2.Text = _model.BE002;
            textBox3.Text = _model.BE003;
            textBox4.Text = _model.BE004;
            textBox5.Text = _model.BE005.ToString( );
            textBox12.Text = _model.BE006;
            textBox6.Text = _model.BE007.ToString( );
            textBox7.Text = _model.BE008.ToString( );
            textBox8.Text = _model.BE009.ToString( );
            textBox9.Text = _model.BE010.ToString( );
            textBox10.Text = _model.BE011.ToString( );
            textBox11.Text = _model.BE012.ToString( );
            textBox13 . Text = _model . BE017;
            changeIndex( );
        }
        void changeIndex ( )
        {
            DataTable da = _bll.GetDataTableOf( _model.BE016 );
            if ( da != null && da.Rows.Count > 0 )
                comboBox1.Text = da.Rows[0]["DGA003"].ToString( );
        }
        private void gridView1_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            assignMents ( );
        }
        #endregion

        #region Table
        void variable ( )
        {
            _model . BE001 = textBox1 . Text;
            _model . BE002 = textBox2 . Text;
            _model . BE003 = textBox3 . Text;
            _model . BE004 = textBox4 . Text;
            _model . BE005 = string . IsNullOrEmpty ( textBox5 . Text ) == true ? 0 : Convert . ToInt32 ( textBox5 . Text );
            _model . BE006 = textBox12 . Text;
            _model . BE007 = string . IsNullOrEmpty ( textBox6 . Text ) == true ? 0 : Convert . ToDecimal ( textBox6 . Text );
            _model . BE008 = string . IsNullOrEmpty ( textBox7 . Text ) == true ? 0 : Convert . ToDecimal ( textBox7 . Text );
            _model . BE009 = string . IsNullOrEmpty ( textBox8 . Text ) == true ? 0 : Convert . ToDecimal ( textBox8 . Text );
            _model . BE010 = string . IsNullOrEmpty ( textBox9 . Text ) == true ? 0 : Convert . ToDecimal ( textBox9 . Text );
            _model . BE011 = string . IsNullOrEmpty ( textBox10 . Text ) == true ? 0 : Convert . ToDecimal ( textBox10 . Text );
            _model . BE012 = string . IsNullOrEmpty ( textBox11 . Text ) == true ? 0 : Convert . ToDecimal ( textBox11 . Text );
            _model . BE017 = textBox13 . Text;
        }
        //Add
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox2.Text ) )
            {
                MessageBox.Show( "流水号不可为空" );
                return;
            }
            variable( );

            if ( _bll . Exists ( _model ) )
            {
                if ( MessageBox . Show ( "新建项已经存在,是否继续新建?" ,"提示" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                    return;
            }

            _model.idx = _bll.Insert( _model );
            if ( _model.idx > 0 )
            {
                MessageBox.Show( "录入数据成功" );
                //if ( tableQuery != null )
                //{
                //    row = tableQuery.NewRow( );
                //    row["idx"] = _model.idx;
                //    build( _model );
                //    tableQuery.Rows.Add( row );
                //}
                //else
                //{
                    strWhere = "1=1";
                    strWhere = strWhere + " AND BE015='" + _model.BE015 + "'";
                    button5_Click( null ,null );
                //}
            }
            else
                MessageBox.Show( "录入数据失败,请重试" );
        }
        void build ( MulaolaoLibrary.OtherExpenseStatementLibrary _model )
        {
            row["BE001"] = _model.BE001;
            row["BE002"] = _model.BE002;
            row["BE003"] = _model.BE003;
            row["BE004"] = _model.BE004;
            row["BE005"] = _model.BE005;
            row["BE006"] = _model.BE006;
            row["BE007"] = _model.BE007;
            row["BE008"] = _model.BE008;
            row["BE009"] = _model.BE009;
            row["BE010"] = _model.BE010;
            row["BE011"] = _model.BE011;
            row["BE012"] = _model.BE012;
            row["BE015"] = _model.BE015;
            row["BE016"] = _model.BE016;
            row["DGA003"] = comboBox1.Text;
        }
        //Edit
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox2.Text ) )
            {
                MessageBox.Show( "流水号不可为空" );
                return;
            }
            variable( );
            int num = gridView1.FocusedRowHandle;
            if ( gridView1.GetDataRow( num )["BE013"].ToString( ) == "审核" || gridView1.GetDataRow( num )["BE013"].ToString( ) == "执行" )
            {
                MessageBox.Show( "此记录状态为" + gridView1.GetDataRow( num )["BE013"].ToString( ) + ",不能编辑" );
                return;
            }         
            result = _bll.Update( _model );
            if ( result == true )
            {
                MessageBox.Show( "成功编辑数据" );
                row = tableQuery.Rows[num];
                row.BeginEdit( );
                build( _model );
                row.EndEdit( );
            }
            else
                MessageBox.Show( "编辑数据失败,请重试" );
        }
        //Delete
        private void button4_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;
            int num = gridView1.FocusedRowHandle;
            if ( gridView1.GetDataRow( num )["BE013"].ToString( ) == "审核" || gridView1.GetDataRow( num )["BE013"].ToString( ) == "执行" )
            {
                MessageBox.Show( "此记录状态为" + gridView1.GetDataRow( num )["BE013"].ToString( ) + ",不能删除" );
                return;
            }
            result = _bll.Delete( _model.idx );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                tableQuery.Rows.RemoveAt( num );
            }
            else
                MessageBox.Show( "删除数据失败,请重试" );
        }
        //Refresh
        private void button5_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( strWhere ) )
                strWhere = "1=1";            
            tableQuery = _bll.GetDataTable( strWhere );
            gridControl1.DataSource = tableQuery;
            assignMents ( );
        }
        void assignMents ( )
        {
            BE017 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( BE007 . SummaryItem . SummaryValue ) + Convert . ToDecimal ( BE008 . SummaryItem . SummaryValue ) + Convert . ToDecimal ( BE009 . SummaryItem . SummaryValue ) + Convert . ToDecimal ( BE010 . SummaryItem . SummaryValue ) + Convert . ToDecimal ( BE011 . SummaryItem . SummaryValue ) + Convert . ToDecimal ( BE012 . SummaryItem . SummaryValue ) ,0 ) . ToString ( ) );
        }
        #endregion
         
        #region Query
        List<string> idxList=new List<string>();
        void autoQuery ( )
        {
            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolReview.Enabled = toolMaintain.Enabled = false;
            Ergodic.SpliClear( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
            if ( !string . IsNullOrEmpty ( _model . BE015 ) )
            {
                strWhere = "1=1";
                strWhere = strWhere + " AND BE015='" + _model . BE015 + "'";
            }
            else
            {
                strWhere = "1=1";
                strWhere = strWhere + " AND A.idx IN (" + string . Join ( "," ,idxList . ToArray ( ) ) + ")";
            }
            button5_Click( null ,null );
        }
        protected override void select ( )
        {
            base.select( );

            _model = new MulaolaoLibrary.OtherExpenseStatementLibrary( );
            SelectAll.OtherExpenseStatementAll query = new SelectAll.OtherExpenseStatementAll( );
            if ( query . ShowDialog ( ) == DialogResult . OK )
            {
                _model . BE015 = query . getOdd;
                idxList = query . getAdd;
                autoQuery ( );
            }   
        }
        private void button1_Click ( object sender ,EventArgs e )
        {
            SelectAll.OtherExpenseStatementNumAll queryNum = new SelectAll.OtherExpenseStatementNumAll( );
            queryNum.StartPosition = FormStartPosition.CenterScreen;
            queryNum.PassDataBetweenForm += new SelectAll.OtherExpenseStatementNumAll.PassDataBetweenFormHandler( queryNum_PassDataBetWeen );
            queryNum.ShowDialog( );
        }
        private void queryNum_PassDataBetWeen ( object sender ,PassDataWinFormEventArgs e )
        {
            textBox1.Text = e.ConFor;
            textBox2.Text = e.ConOne;
            textBox3.Text = e.ConTre;
            textBox4.Text = e.ConTwo;
            textBox5.Text = e.ConFiv;
            textBox12.Text = e.ConSix;
        }
        #endregion

    }
}
