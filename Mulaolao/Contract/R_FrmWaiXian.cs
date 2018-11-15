using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Contract
{
    public partial class R_FrmWaiXian : FormChild
    {
        public R_FrmWaiXian ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.WaiXianLibrary _model = new MulaolaoLibrary.WaiXianLibrary( );
        MulaolaoBll.Bll.WaiXianBll _bll = new MulaolaoBll.Bll.WaiXianBll( );
        bool result = false;
        string strWhere = "1=1", sign = "", weihu = "";
        DataTable tableQuery;
        List<SplitContainer> spList = new List<SplitContainer>( );

        private void R_FrmWaiXian_Load ( object sender ,EventArgs e )
        {
            Power( this );
            spList.Clear( );
            spList.AddRange( new SplitContainer[] { splitContainer1 } );
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableFalse( spList );
            gridControl1.DataSource = null;
            textBox7.Enabled = false;
            label83.Visible = false;
        }

        private void R_FrmWaiXian_Shown ( object sender , EventArgs e )
        {
            _model . OZ011 = Merges . oddNum;
            if ( !string . IsNullOrEmpty ( _model . OZ011 ) )
                autoQuery ( );
            Merges . oddNum = "";
        }

        #region Query
        //num Query
        private void button1_Click ( object sender ,EventArgs e )
        {
            SelectAll.WaiXianNumAll wxQuery = new SelectAll.WaiXianNumAll( );
            wxQuery.StartPosition = FormStartPosition.CenterScreen;
            wxQuery.PassDataBetweenForm += new SelectAll.WaiXianNumAll.PassDataBetweenFormHandler( wxQuery_PassDataBetweenForm );
            wxQuery.ShowDialog( );
        }
        private void wxQuery_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            textBox10.Text = e.ConOne;
            textBox1.Text = e.ConTwo;
            textBox2.Text = e.ConFor;
            textBox3.Text = e.ConTre;
            textBox8.Text = e.ConFiv;
        }
        SelectAll.WaiXianAll query = new SelectAll.WaiXianAll( );
        protected override void select ( )
        {
            base.select( );

            _model = new MulaolaoLibrary.WaiXianLibrary( );
            
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.WaiXianAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );

            if ( _model.OZ011 != null && _model.OZ011 != "" )
                autoQuery( );
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            _model.OZ011 = e.ConOne;
            if ( e.ConTwo == "执行" )
                label83.Visible = true;
            else
                label83.Visible = false;
        }
        void autoQuery ( )
        {
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
            textBox7.Enabled = false;
            Ergodic.SpliEnableFalse( spList );
            sign = "1";
            queryConten( );
        }
        void queryConten ( )
        {
            _model = _bll.GetModel( _model.OZ011 );
            textBox7.Text = _model.OZ013;
            refre( );
        }
        #endregion

        #region Table
        //Generate
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( textBox1.Text.Contains( "," ) )
                _model.OZ001 = textBox1.Text;
            else
                _model.OZ001 = gridView1.GetDataRow( 0 )["OZ010"].ToString( );
            _model.OZ015 = textBox8.Text;
            result = _bll.GetDataTableGener( _model.OZ001 ,_model.OZ011 ,_model.OZ015 );
            if ( result == true )
            {
                MessageBox.Show( "生成成功" );
                refre( );
            }
            else
                MessageBox.Show( "生成失败" );
        }
        //EditOfBatch
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "流水号不可为空" );
                return;
            }
            _model.OZ001 = textBox1.Text;
            _model.OZ005 = string.IsNullOrEmpty( textBox4.Text ) == true ? 0 : Convert.ToInt64( textBox4.Text );
            _model.OZ006 = string.IsNullOrEmpty( textBox5.Text ) == true ? 0M : Convert.ToDecimal( textBox5.Text );
            result = _bll.Update( _model.OZ001 ,_model.OZ005 ,_model.OZ006 ,_model.OZ011);
            if ( result == true )
            {
                MessageBox.Show( "成功编辑数据" );
                refre( );
            }
            else
                MessageBox.Show( "编辑数据失败" );
        }
        private void button6_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "流水号不可为空" );
                return;
            }
            _model.OZ005 = string.IsNullOrEmpty( textBox4.Text ) == true ? 0 : Convert.ToInt64( textBox4.Text );
            _model.OZ006 = string.IsNullOrEmpty( textBox5.Text ) == true ? 0M : Convert.ToDecimal( textBox5.Text );
            _model.OZ001 = textBox1.Text;
            result = _bll.Update( _model.OZ001 ,_model.OZ011 ,_model.OZ005 ,_model.OZ006 );
            if ( result == true )
            {
                MessageBox.Show( "成功编辑数据" );
                refre( );
            }
            else
                MessageBox.Show( "编辑数据失败" );
        }
        //Delete
        private void button4_Click ( object sender ,EventArgs e )
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
        //Refresh
        private void button5_Click ( object sender ,EventArgs e )
        {
            refre( );
        }
        void refre ( )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND OZ011='" + _model.OZ011 + "'";
            tableQuery = _bll.GetDataTableAll( strWhere );
            tableQuery.Columns.Add( "U1" ,typeof( System.Decimal ) );
            //tableQuery.Columns.Add( "U3" ,typeof( System.Decimal ) );
            tableQuery.Columns.Add( "U2" ,typeof( System.Decimal ) );
            gridControl1.DataSource = tableQuery;
            assignMent( );
        }
        void assignMent ( )
        {
            if ( tableQuery != null )
            {
                string num = "";
                decimal countOfMoney = 0, countOfVolume = 0, countOfEvery = 0, countOfAll = 0;
                List<string> strList = new List<string>( );
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    if ( i == 0 )
                    {
                        num = gridView1.GetDataRow( i )["OZ001"].ToString( );
                        countOfMoney = string.IsNullOrEmpty( gridView1.GetDataRow( i )["OZ009"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["OZ009"].ToString( ) );
                        strList.Add( num );
                        countOfVolume = ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["OZ005"].ToString( ) ) == true ? 0 : Convert.ToInt32( gridView1.GetDataRow( i )["OZ005"].ToString( ) ) ) * ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["OZ006"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["OZ006"].ToString( ) ) );
                    }
                    else if ( gridView1.GetDataRow( i )["OZ001"].ToString( ) == num )
                    {
                        countOfMoney += string.IsNullOrEmpty( gridView1.GetDataRow( i )["OZ009"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["OZ009"].ToString( ) );
                    }
                    if ( !strList.Contains( gridView1.GetDataRow( i )["OZ001"].ToString( ) ) )
                    {
                        strList.Add( gridView1.GetDataRow( i )["OZ001"].ToString( ) );
                        countOfVolume = countOfVolume + ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["OZ005"].ToString( ) ) == true ? 0 : Convert.ToInt32( gridView1.GetDataRow( i )["OZ005"].ToString( ) ) ) * ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["OZ006"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["OZ006"].ToString( ) ) );
                    }
                }
                strList.Clear( );
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    //gridView1.SetRowCellValue( i ,gridView1.Columns["U3"] ,countOfMoney );
                    gridView1.SetRowCellValue( i ,gridView1.Columns["U1"] ,countOfVolume );
                    gridView1 . SetRowCellValue ( i ,gridView1 . Columns [ "U2" ] ,countOfVolume == 0 ? 0 : countOfMoney / countOfVolume * ( string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "OZ006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "OZ006" ] . ToString ( ) ) ) );
                    
                    string str = gridView1.GetDataRow( i )["OZ001"].ToString( );
                    if ( i == 0 )
                    {
                        strList.Add( gridView1.GetDataRow( i )["OZ001"].ToString( ) );
                        countOfEvery = countOfVolume == 0 ? 0 : countOfMoney / countOfVolume * ( string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "OZ006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "OZ006" ] . ToString ( ) ) );
                        countOfAll = countOfVolume == 0 ? 0 : Math.Round( countOfMoney / countOfVolume * ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["OZ006"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["OZ006"].ToString( ) ) ) ,4 ) * ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["OZ005"].ToString( ) ) == true ? 0 : Convert.ToInt32( gridView1.GetDataRow( i )["OZ005"].ToString( ) ) );
                    }
                    if ( !strList.Contains( gridView1.GetDataRow( i )["OZ001"].ToString( ) ) )
                    {
                        strList.Add( gridView1.GetDataRow( i )["OZ001"].ToString( ) );
                        countOfEvery += countOfVolume == 0 ? 0 : countOfMoney / countOfVolume * ( string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "OZ006" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "OZ006" ] . ToString ( ) ) );
                        countOfAll += countOfVolume == 0 ? 0 : Math.Round( countOfMoney / countOfVolume * ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["OZ006"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["OZ006"].ToString( ) ) ) ,4 ) * ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["OZ005"].ToString( ) ) == true ? 0 : Convert.ToInt32( gridView1.GetDataRow( i )["OZ005"].ToString( ) ) );
                    }
                }

                U2 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( countOfEvery ,2 ) . ToString ( ) );
                U3.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math.Round( countOfAll ,2 ).ToString( ) );

                DataTable dl = _bll.GetDataTableSum( _model.OZ011 );
                if ( dl != null && dl.Rows.Count > 0 )
                {
                    OZ008.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,dl.Rows[0]["OZ008"].ToString( ) );
                    OZ009.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,dl.Rows[0]["OZ009"].ToString( ) );
                }
                DataTable de = _bll.GetDataTableSums( _model.OZ011 );
                if ( de != null && de.Rows.Count > 0 )
                {
                    OZ005.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,de.Rows[0]["OZ005"].ToString( ) );
                    OZ006.SummaryItem.SetSummary( DevExpress.Data.SummaryItemType.Custom ,de.Rows[0]["OZ006"].ToString( ) );
                }
            }
        }
        #endregion

        #region Main
        protected override void add ( )
        {
            base.add( );

            sign = "2";
            Ergodic.SpliEnableTrue( spList );
            Ergodic.SpliClear( spList );
            gridControl1.DataSource = null;
            _model.OZ011 = oddNumbers.purchaseContract( "SELECT MAX(OZ011) OZ011 FROM R_PQOZ" ,"OZ011" ,"R_348-" );
            textBox7.Enabled = false;
            label83.Visible = false;

            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        void dele ( )
        {
            result = _bll.Delete( _model.OZ011 );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                toolSelect.Enabled = toolAdd.Enabled = toolPrint.Enabled = toolExport.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                Ergodic.SpliClear( spList );
                Ergodic.SpliEnableFalse( spList );
                gridControl1.DataSource = null;
                textBox7.Enabled = false;
                label83.Visible = false;
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        protected override void delete ( )
        {
            base.delete( );

            if ( label83.Visible == true )
            {
                if ( Logins.number == "MLL-0001" )
                    dele( );
                else
                    MessageBox.Show( "单据状态为执行,需要总经理删除" );
            }
            else
                dele( );
        }
        protected override void update ( )
        {
            base.update( );

            if ( label83.Visible == true )
                MessageBox.Show( "单据状态为执行,需要维护" );
            else
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
                Ergodic.SpliEnableTrue( spList );
                label83.Visible = false;
                textBox7.Enabled = false;
            }
        }
        protected override void save ( )
        {
            base.save( );

            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "流水号不可为空" );
                return;
            }
            if ( weihu == "1" )
            {
                if ( string.IsNullOrEmpty( textBox7.Text ) )
                {
                    MessageBox.Show( "维护信息不可为空" );
                    return;
                }
                DataTable dl = _bll.GetDataTableWeiHu( _model.OZ011 );
                if ( dl.Rows.Count > 0 )
                    _model.OZ012 = dl.Rows[0]["OZ012"].ToString( ) + "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";
                else
                    _model.OZ012 = "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";
                _model.OZ013 = textBox7.Text;
                if ( WriteOfReceivablesTo( ) == false )
                {
                    MessageBox.Show( "维护保存失败,请联系系统管理员" );
                    return;
                }
                else
                {
                    result = _bll.UpdateMainTain( _model.OZ011 ,_model.OZ013 ,_model.OZ012 );
                    if ( result == true )
                    {
                        MessageBox.Show( "维护数据成功" );
                        saveState( );
                    }
                    else
                        MessageBox.Show( "维护数据失败" );
                }
            }
            else
                saveState( );
        }
        void saveState ( )
        {
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
            textBox7.Enabled = false;
            sign = "";
            weihu = "";
            Ergodic.SpliEnableFalse( spList );
        }
        protected override void cancel ( )
        {
            base.cancel( );

            if ( sign == "2" && weihu != "1" )
            {
                Ergodic.SpliClear( spList );
                gridControl1.DataSource = null;
                toolSelect.Enabled = toolAdd.Enabled = toolPrint.Enabled = toolExport.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                try
                {
                    _bll.Delete( _model.OZ011 );
                }
                catch { }
            }
            else if ( sign == "1" || weihu == "1" )
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
                toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = false;
            }
            Ergodic.SpliEnableFalse( spList );
            textBox7.Enabled = false;
        }
        protected override void revirw ( )
        {
            base.revirw( );

            Reviews( "OZ011" ,_model.OZ011 ,"R_PQOZ" ,this ,_model.OZ001 ,"R_348" ,false ,false,MulaolaoBll . Drity . GetDt ( )/*,"WX07" ,"WX75" ,"R_PQT" ,"WX82" ,WX82 ,ord ,textBox7.Text,"R_349"*/ );

            SpecialPowers sp = new SpecialPowers( );
            result = sp.reviewImple( "R_348" ,_model.OZ011 );
            if ( result == true )
            {
                if ( WriteOfReceivablesTo( ) == false )
                {
                    MessageBox.Show( "审核失败,请联系系统管理员" );
                    return;
                }
                else
                    label83.Visible = true;
            }
            else
                label83.Visible = false;
        }
        bool WriteOfReceivablesTo ( )
        {
            result = false;
            DataTable receiva;
            MulaolaoLibrary.ProductCostSummaryLibrary modelAm = new MulaolaoLibrary.ProductCostSummaryLibrary( );
            receiva = _bll.GetDataTableOf241( _model.OZ011 );
            if ( receiva != null && receiva.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < receiva.Rows.Count ; i++ )
                {
                    modelAm.AM002 = receiva.Rows[i]["OZ001"].ToString( );
                    modelAm.AM139 = modelAm.AM144 = 0;
                    modelAm.AM139 = string.IsNullOrEmpty( receiva.Compute( "SUM(OZ)" ,"OZ001='" + modelAm.AM002 + "' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(OZ)" ,"OZ001='" + modelAm.AM002 + "' AND WX90='F'" ) );
                    modelAm.AM144 = string.IsNullOrEmpty( receiva.Compute( "SUM(OZ)" ,"OZ001='" + modelAm.AM002 + "' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(OZ)" ,"OZ001='" + modelAm.AM002 + "' AND WX90='T'" ) );
                    result = _bll.UpdateOfReceivable( modelAm ,_model.OZ011 );
                }
            }

            return result;
        }
        protected override void maintain ( )
        {
            base.maintain( );

            if ( label83.Visible == true )
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
                textBox7.Enabled = true;
                Ergodic.SpliEnableTrue( spList );
                weihu = "1";
            }
            else
                MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
        }
        #endregion

        #region Event
        private void textBox4_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
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
            if ( textBox5.Text != "" && !DateDayRegise.thirteenTenNum( textBox5 ) )
            {
                this.textBox5.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多十位,如999.9999999999,请重新输入" );
            }
        }
        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                _model.IDX = string.IsNullOrEmpty( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                ass( );
            }
        }
        void ass ( )
        {
            _model = _bll.GetModel( _model.IDX );
            textBox10.Text = _model.OZ002;
            textBox1.Text = _model.OZ001;
            textBox2.Text = _model.OZ003;
            textBox3.Text = _model.OZ004;
            textBox4.Text = _model.OZ005.ToString( );
            textBox5.Text = _model.OZ006.ToString( );
            textBox6.Text = _model.OZ007;
            textBox8.Text = _model.OZ015;
        }
        #endregion

    }
}
