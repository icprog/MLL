using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Wages
{
    public partial class R_FrmDetailedDeduction : FormChild
    {
        MulaolaoLibrary.DetailedDeductionLibrary _model =null;
        MulaolaoLibrary.DetailedDeductionWYLibrary _wy=null;
        MulaolaoBll.Bll.DetailedDeductionBll _bll =null;
        
        public R_FrmDetailedDeduction ( )
        {
            InitializeComponent( );

            _model = new MulaolaoLibrary . DetailedDeductionLibrary ( );
            _wy = new MulaolaoLibrary . DetailedDeductionWYLibrary ( );
            _bll = new MulaolaoBll . Bll . DetailedDeductionBll ( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,gridView3 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        List<SplitContainer> spList = new List<SplitContainer>( );
        bool result = false;
        DataTable tableQuery,tableZ;DataRow row;
        string strWhere = "1=1", sign = "";
        List<string> sList = new List<string>( );

        private void R_FrmDetailedDeduction_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            Power( this );
            spList.Clear( );
            spList.AddRange( new SplitContainer[] { splitContainer1 } );
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableFalse( spList );

            lookUpEdit2 . Properties . DataSource = _bll . GetDataTableOfPurchase ( );
            lookUpEdit2 . Properties . DisplayMember = "DBA002";
            lookUpEdit2 . Properties . ValueMember = "DBA001";
            DataTable tableWorkShop = _bll . GetDataTable ( );
            lookUpEdit1 . Properties . DataSource = tableWorkShop;
            lookUpEdit1 . Properties . DisplayMember = "DBA002";
            lookUpEdit1 . Properties . ValueMember = "DBA001";
        }

        #region Main
        protected override void add ( )
        {
            base.add( );

            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableTrue( spList );
            gridControl1.DataSource = null;
            toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolSelect.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
            _model.WZ001 = oddNumbers.purchaseContract( "SELECT MAX(WZ001) WZ001 FROM R_PQWZ" ,"WZ001" ,"R_244-" );
        }
        protected override void delete ( )
        {
            base.delete( );
            
            /*
            result = _bll.Delete( _model.WZ001 );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                Ergodic.SpliClear( spList );
                Ergodic.SpliEnableFalse( spList );
                gridControl1.DataSource = null;
                toolAdd.Enabled = toolSelect.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;           
            }
            else
                MessageBox.Show( "删除数据失败" );
             */
        }
        protected override void update ( )
        {
            base.update( );

            Ergodic.SpliEnableTrue( spList );

            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled =  true;
        }
        protected override void save ( )
        {
            base.save( );

            Ergodic.SpliEnableFalse( spList );
            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled =  true;
            toolSave.Enabled = toolCancel.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
        }
        protected override void cancel ( )
        {
            base.cancel( );

            Ergodic.SpliEnableFalse( spList );
            toolAdd.Enabled = toolSelect.Enabled = toolDelete.Enabled = toolUpdate.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
        }
        protected override void export ( )
        {
            ViewExport . ExportToExcel ( this . Text ,gridControl1 );

            base . export ( );
        }
        #endregion
        
        #region Event
        private void textBox1_TextChanged ( object sender ,EventArgs e )
        {
            

            
        }
        private void textBox6_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.fractionTb( e ,textBox6 );
        }
        private void textBox6_TextChanged ( object sender ,EventArgs e )
        {
            DateDay.textChangeTb( textBox6 );
        }
        private void textBox6_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox6.Text != "" && !DateDay.elevenTwoNumber( textBox6 ) )
            {
                textBox6.Text = "";
                MessageBox.Show( "只允许输入整数部分最多九位,小数部分最多两位,如999999999.99,请重新输入" );
            }
        }
        private void textBox7_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.fractionTb( e ,textBox7 );
        }
        private void textBox7_TextChanged ( object sender ,EventArgs e )
        {
            DateDay.textChangeTb( textBox7 );
        }
        private void textBox7_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox7.Text != "" && !DateDay.elevenTwoNumber( textBox7 ) )
            {
                textBox7.Text = "";
                MessageBox.Show( "只允许输入整数部分最多九位,小数部分最多两位,如999999999.99,请重新输入" );
            }
        }
        private void textBox8_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.fractionTb( e ,textBox8 );
        }
        private void textBox8_TextChanged ( object sender ,EventArgs e )
        {
            DateDay.textChangeTb( textBox8 );
        }
        private void textBox8_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox8.Text != "" && !DateDay.elevenTwoNumber( textBox8 ) )
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
            if ( textBox9.Text != "" && !DateDay.elevenTwoNumber( textBox9 ) )
            {
                textBox9.Text = "";
                MessageBox.Show( "只允许输入整数部分最多九位,小数部分最多两位,如999999999.99,请重新输入" );
            }
        }
        private void textBox10_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.fractionTb( e ,textBox10 );
        }
        private void textBox10_TextChanged ( object sender ,EventArgs e )
        {
            DateDay.textChangeTb( textBox10 );
        }
        private void textBox10_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox10.Text != "" && !DateDay.elevenTwoNumber( textBox10 ) )
            {
                textBox10.Text = "";
                MessageBox.Show( "只允许输入整数部分最多九位,小数部分最多两位,如999999999.99,请重新输入" );
            }
        }
        private void gridView1_Click ( object sender ,EventArgs e )
        {
            DataRow row = gridView1 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            _model . IDX = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
            assignMent ( );
        }
        void assignMent ( )
        {
            _model = _bll.GetModel( _model.IDX );
            if ( _model.WZ002 > DateTime.MinValue && _model.WZ002 < DateTime.MaxValue )
                dateTimePicker1.Value = _model.WZ002;
            lookUpEdit1.Text = _model.WZ003;
            textBox4.Text = _model.WZ004;
            lookUpEdit2.Text = _model.WZ005;
            textBox1.Text = _model.WZ006;
            textBox3.Text = _model.WZ007;
            textBox2.Text = _model.WZ008;
            textBox5.Text = _model.WZ009;
            textBox6.Text = _model.WZ010.ToString( );
            textBox7.Text = _model.WZ011.ToString( );
            textBox8.Text = _model.WZ012.ToString( );
            textBox9.Text = _model.WZ013.ToString( );
            textBox10.Text = _model.WZ014.ToString( );
            textBox11.Text = _model.WZ015;
        }
        #endregion

        #region Table
        void variable ( )
        {
            _model.WZ002 = dateTimePicker1.Value;
            _model.WZ003 = lookUpEdit1.Text;
            _model.WZ004 = textBox4.Text;
            _model.WZ005 = lookUpEdit2.Text;
            _model.WZ006 = textBox1.Text;
            _model.WZ007 = textBox3.Text;
            _model.WZ008 = textBox2.Text;
            _model.WZ009 = textBox5.Text;
            _model.WZ010 = string.IsNullOrEmpty( textBox6.Text ) == true ? 0 : Convert.ToDecimal( textBox6.Text );
            _model.WZ011 = string.IsNullOrEmpty( textBox7.Text ) == true ? 0 : Convert.ToDecimal( textBox7.Text );
            _model.WZ012 = string.IsNullOrEmpty( textBox8.Text ) == true ? 0 : Convert.ToDecimal( textBox8.Text );
            _model.WZ013 = string.IsNullOrEmpty( textBox9.Text ) == true ? 0 : Convert.ToDecimal( textBox9.Text );
            _model.WZ014 = string.IsNullOrEmpty( textBox10.Text ) == true ? 0 : Convert.ToDecimal( textBox10.Text );
            _model.WZ015 = textBox11.Text;
        }
        void rowAdd ( )
        {
            row["WZ002"] = _model.WZ002;
            row["WZ003"] = _model.WZ003;
            row["WZ004"] = _model.WZ004;
            row["WZ005"] = _model.WZ005;
            row["WZ006"] = _model.WZ006;
            row["WZ007"] = _model.WZ007;
            row["WZ008"] = _model.WZ008;
            row["WZ009"] = _model.WZ009;
            row["WZ010"] = _model.WZ010;
            row["WZ011"] = _model.WZ011;
            row["WZ012"] = _model.WZ012;
            row["WZ013"] = _model.WZ013;
            row["WZ014"] = _model.WZ014;
            row["WZ015"] = _model.WZ015;
        }
        //Add
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox4.Text ) )
            {
                MessageBox.Show( "供应商不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox5.Text ) )
            {
                MessageBox.Show( "物品名称不可为空" );
                return;
            }
            variable( );
            _model.IDX = _bll.Add( _model );
            if ( _model.IDX > 0 )
            {
                MessageBox.Show( "成功录入数据" );
                strWhere = "1=1";
                //strWhere = strWhere + " AND WZ001='" + _model.WZ001 + "'";
                button3_Click( null ,null );
            }
            else
                MessageBox.Show( "录入数据失败" );
        }
        //Edit
        private void button4_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox4.Text ) )
            {
                MessageBox.Show( "供应商不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox5.Text ) )
            {
                MessageBox.Show( "物品名称不可为空" );
                return;
            }
            if ( _model.WZ016 != null && _model.WZ016 == "执行" )
            {
                MessageBox.Show( "此记录已经在231结账,不允许修改" );
                return;
            }
            variable( );
            result = _bll.Edit( _model );
            if ( result == true )
            {
                MessageBox.Show( "成功编辑数据" );
                row = tableQuery.Rows[gridView1.FocusedRowHandle];
                row.BeginEdit( );
                rowAdd( );
                row.EndEdit( );
            }
            else
                MessageBox.Show( "编辑数据失败" );
        }
        //Delete
        private void button5_Click ( object sender ,EventArgs e )
        {
            if ( _model.WZ016 != null && _model.WZ016 == "执行" )
            {
                MessageBox.Show( "此记录已经在231结账,不允许删除" );
                return;
            }
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==DialogResult . Cancel )
                return;

            if ( _bll . Exit ( _model . IDX ) )
            {
                MessageBox . Show ( "本次付款金额有明细已经审核或执行,不允许删除" );
                return;
            }
            if ( _bll . Exit_231 ( _model . IDX ) )
            {
                MessageBox . Show ( "本次付款金额有明细已经在木佬佬付款读取,不允许删除" );
                return;
            }
            if ( _bll . Exit_231_yl ( _model . IDX ) )
            {
                MessageBox . Show ( "本次付款金额有明细已经在永灵付款读取,不允许删除" );
                return;
            }
            if ( _bll . Exit_231_MK ( _model . IDX ) )
            {
                MessageBox . Show ( "木佬佬扣款已经读取,不允许删除" );
                return;
            }
            if ( _bll . Exit_231_YL ( _model . IDX ) )
            {
                MessageBox . Show ( "永灵扣款已经读取,不允许删除" );
                return;
            }

            result = _bll.Delete( _model.IDX );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                strWhere = "1=1";
                //strWhere = strWhere + " AND WZ001='" + _model.WZ001 + "'";
                button3_Click( null ,null );
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        //Refresh
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( strWhere ) )
                strWhere = "1=1";
            DataSet ds = new DataSet ( );
            
            tableQuery = _bll.GetDataTableGrid( strWhere );
            tableQuery . TableName = "PQWZ";
            ds . Tables . Add ( tableQuery );
            if ( strWhere . Contains ( "A.idx" ) )
                strWhere = strWhere . Replace ( "A.idx" ,"WY001" );
            tableZ = _bll . GetDataTableZ ( strWhere );
            tableZ . TableName = "PQWY";
            ds . Tables . Add ( tableZ );
            DataRelation relation = new DataRelation ( "本次扣款" ,ds . Tables [ "PQWZ" ] . Columns [ "idx" ] ,ds . Tables [ "PQWY" ] . Columns [ "WY001" ] );
            ds . Relations . Add ( relation );
            gridControl1 . DataSource = ds . Tables [ "PQWZ" ];
        }
        //扣款操作
        private void btnK_Click ( object sender ,EventArgs e )
        {
            DetailedDeductionChildTable from = new DetailedDeductionChildTable ( _model . IDX );
            if ( from . ShowDialog ( ) == DialogResult . OK )
            {
                button3_Click ( null ,null );
            }
        }
        #endregion

        #region Query
        protected override void select ( )
        {
            base.select( );

            _model = new MulaolaoLibrary.DetailedDeductionLibrary( );
            SelectAll.DetailedDeductionAll query = new SelectAll.DetailedDeductionAll( );
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.DetailedDeductionAll.PassDataBetweenFormHandler( query_PassDataBetweenFrom );
            query.ShowDialog( );

            strWhere = "1=1";
            if ( sign == "1" )
            {
                if ( sList.Count > 0 )
                {
                    string s = "";
                    foreach ( string id in sList )
                    {
                        if ( s == "" )
                            s = id;
                        else
                            s = s + "," + id;
                    }
                    strWhere = strWhere + " AND A.idx IN (" + s + ")";
                }
                else
                    strWhere = "1=1";
            }
            //else if ( _model.WZ001 != null )
            //{
            //    strWhere = "1=1";
            //    strWhere = strWhere + " AND WZ001='" + _model.WZ001 + "'";
            //}

            button3_Click( null ,null );

            toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolSelect.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolMaintain.Enabled = toolcopy.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
        }
        private void query_PassDataBetweenFrom ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( e.ConOne == "1" )
            {
                sign = "1";
                sList = e.List;
            }
            else
                _model.WZ001 = e.ConOne;
        }
        private void button1_Click ( object sender ,EventArgs e )
        {
            SelectAll.DetailedDeductionNumQuery queryNum = new SelectAll.DetailedDeductionNumQuery( );
            queryNum.PassDataBetweenForm += new SelectAll.DetailedDeductionNumQuery.PassDataBetweenFormHandler( queryNum_PassDataBetweenFrom );
            queryNum.StartPosition = FormStartPosition.CenterScreen;
            queryNum.ShowDialog( );
        }
        private void queryNum_PassDataBetweenFrom ( object sender ,PassDataWinFormEventArgs e )
        {
            textBox1.Text = e.ConOne;
            textBox3.Text = e.ConTwo;
            textBox2.Text = e.ConTre;
        }
        private void button6_Click ( object sender ,EventArgs e )
        {
            SelectAll.DetailedDeductionSupplier deQuery = new SelectAll.DetailedDeductionSupplier( );
            deQuery.StartPosition = FormStartPosition.CenterScreen;
            deQuery.PassDataBetweenForm += new SelectAll.DetailedDeductionSupplier.PassDataBetweenFormHandler( deQuery_PassDataBetweenForm );
            deQuery.ShowDialog( );
        }
        private void deQuery_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            textBox4.Text = e.ConOne;
        }
        #endregion

    }
}
