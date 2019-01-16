using DevExpress . XtraGrid . Views . Grid;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Linq;
using System . Windows . Forms;
using FastReport;
using System . Drawing;

namespace Mulaolao . Summary
{
    public partial class R_FrmCheckOut : FormChild
    {
        public R_FrmCheckOut ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoBll.Bll.CheckOutBll bal = new MulaolaoBll.Bll.CheckOutBll( );
        MulaolaoLibrary.CheckOutLibrary model = new MulaolaoLibrary.CheckOutLibrary( );
        SelectAll.CheckOutQueryAll query = new SelectAll.CheckOutQueryAll( );
        DataSet ds;
        List<string> list = new List<string>( );
        int id = 0;
        string strWhere = "", sign = "", file = "", stateOfState = "";
        DataTable tableQuery, tablePqq, tablePqah, tablePqo, tablePqi, tablePqv, tablePqaf, tablePqu, tablePqs, tablePqt, tablePqy, tablePqiz, tablePqis, tablePqmz, tablePqba;
        DataTable conTract, conTractYi,thereExist;
        bool result = false; 
        Report report = new Report( );DataSet RDataSet = new DataSet( );
        
        private void R_FrmCheckOut_Load ( object sender ,EventArgs e )
        {
            Power( this );
            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;

            Ergodic.FormEverySpliEnableFalse( this );
            
            comboBox1.Items.Clear( );
            comboBox1.Items.AddRange( new string[] { "R_195" ,"R_196" ,"R_199" ,"R_337" ,"R_338" ,"R_339" ,"R_341" ,"R_342" ,"R_343" ,"R_344" ,"R_347" ,"R_348" ,"R_349" ,"R_495" ,"R_505" } );
            comboBox2.Items.Clear( );
            comboBox2.Items.AddRange( new string[] { "" ,"执行" } );

        }

        #region Print
        void CreatePrint ( )
        {
            strWhere = "";
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                if ( string.IsNullOrEmpty( strWhere ) )
                    strWhere = gridView1.GetDataRow( i )["idx"].ToString( );
                else
                    strWhere = strWhere + "," + gridView1.GetDataRow( i )["idx"].ToString( );
            }
            if ( string.IsNullOrEmpty( strWhere ) )
                return;
            DataTable print = bal.GetDataTablePrint( strWhere );
            RDataSet.Tables.Add( print );
        }
        #endregion

        #region Event
        private void textBox10_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox10 );
        }
        private void textBox10_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox10 );
            textBox11.Text = CheckOutCalcu.Calculation( textBox8 ,textBox9 ,textBox10 ,textBox13 ).ToString( );
        }
        private void textBox10_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox10.Text != "" && !DateDayRegise.elevenTwoNumber( textBox10 ) )
            {
                this.textBox10.Text = "";
                MessageBox.Show( "只允许输入整数部分最多十位,小数部分最多一位,如999999999.99,请重新输入" );
            }
        }
        private void gridView1_Click ( object sender ,EventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                int num = gridView1.FocusedRowHandle;
                if ( gridView1.GetDataRow( num )["check"].ToString( ) == "True" )
                    gridView1.GetDataRow( num )["check"] = false;
                else
                    gridView1.GetDataRow( num )["check"] = true;

                if ( !string.IsNullOrEmpty( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) )
                    model.Idx = Convert.ToInt32( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                assignMent( );
            }
        }
        private void textBox8_TextChanged ( object sender ,EventArgs e )
        {
            textBox11.Text = CheckOutCalcu.Calculation( textBox8 ,textBox9 ,textBox10 ,textBox13 ).ToString( );
        }
        private void textBox9_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox9 );
        }
        private void textBox9_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox9 );
            textBox11.Text = CheckOutCalcu.Calculation( textBox8 ,textBox9 ,textBox10 ,textBox13 ).ToString( );
        }
        private void textBox9_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox9.Text != "" && !DateDayRegise.elevenOneNumber( textBox9 ) )
            {
                this.textBox9.Text = "";
                MessageBox.Show( "只允许输入整数部分最多十位,小数部分最多一位,如9999999999.9,请重新输入" );
            }
        }
        void assignMent ( )
        {
            model = bal.GetMode( model.Idx );
            if ( model == null )
                return;
            textBox1.Text = model.AK001;
            textBox2.Text = model.AK002;
            textBox4.Text = model.AK004;
            textBox5.Text = model.AK005;
            textBox3.Text = model.AK006;
            textBox6.Text = model.AK007.ToString( );
            textBox7.Text = model.AK008;
            textBox8.Text = model.AK009.ToString( );
            textBox9.Text = model.AK010.ToString( );
            textBox10.Text = model.AK011.ToString( );
            comboBox2.Text = model.AK017;
            if ( !string.IsNullOrEmpty( model.AK012.ToString( ) ) )
                dateTimePicker1.Value = model.AK012;
            textBox12.Text = model.AK013;
            //textBox13.Text = model.AK015.ToString( );
        }
        private void textBox13_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDayRegise.fractionTb( e ,textBox13 );
        }
        private void textBox13_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox13 );
            textBox11.Text = CheckOutCalcu.Calculation( textBox8 ,textBox9 ,textBox10 ,textBox13 ).ToString( );
            textBox10 . Text = ( string . IsNullOrEmpty ( textBox8 . Text ) == true ? 0 : Convert . ToDecimal ( textBox8 . Text ) - ( string . IsNullOrEmpty ( textBox9 . Text ) == true ? 0 : Convert . ToDecimal ( textBox9 . Text ) ) - ( string . IsNullOrEmpty ( textBox13 . Text ) == true ? 0 : Convert . ToDecimal ( textBox13 . Text ) ) ) . ToString ( );
        }
        private void textBox13_LostFocus ( object sender ,EventArgs e )
        {
            //if ( textBox13.Text != "" && !DateDayRegise.elevenOneNumber( textBox13 ) )
            //{
            //    this.textBox13.Text = "";
            //    MessageBox.Show( "只允许输入整数部分最多十位,小数部分最多一位,如9999999999.9,请重新输入" );
            //}
        }
        private void R_FrmCheckOut_FormClosing ( object sender ,FormClosingEventArgs e )
        {
            if ( toolSave.Enabled )
            {
                cancel( );
            }
        }
        private void gridView1_RowStyle ( object sender ,RowStyleEventArgs e )
        {
            int num = e.RowHandle;
            if ( num < 0 )
                return;
            DataRow dr = this.gridView1.GetDataRow( num );
            if ( dr == null )
                return;
            
            if ( thereExist != null && thereExist.Rows.Count > 0 && thereExist.Select( "idx='" + dr["idx"].ToString( ) + "'" ).Length > 0 )
            {
                //e.Appearance.ForeColor = Color.Red;// 改变行字体颜色
                //e.Appearance.BackColor = Color.Red;// 改变行背景颜色
                //e.Appearance.BackColor2 = Color.Blue;// 添加渐变颜色
                e.Appearance.BackColor = Color.Red;
            }
        }
        private void contextMenuStrip1_ItemClicked ( object sender , ToolStripItemClickedEventArgs e )
        {
            SelectAll . CheckOutBatchEdit bEd = new SelectAll . CheckOutBatchEdit ( );
            bEd . StartPosition = FormStartPosition . CenterScreen;
            bEd . ShowDialog ( );
        }
        private void gridView1_ColumnFilterChanged ( object sender ,EventArgs e )
        {
            assginSum ( );
        }
        private void gridView1_CustomDrawRowIndicator ( object sender ,RowIndicatorCustomDrawEventArgs e )
        {
            if ( e . Info . IsRowIndicator && e . RowHandle >= 0 )
            {
                e . Info . DisplayText = ( e . RowHandle + 1 ) . ToString ( );
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
            model.AK014 = oddNumbers.purchaseContract( "SELECT MAX(AK014) AK014 FROM R_PQAK" ,"AK014" ,"R_526-" );

            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void update ( )
        {
            base.update( );

            if ( gridView1.RowCount > 0 )
                model.AK014 = gridView1.GetDataRow( 0 )["AK014"].ToString( );
            Ergodic.FormEverySpliEnableTrue( this );
            toolAdd.Enabled = toolSelect.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolPrint.Enabled = toolReview.Enabled = toolExport.Enabled = toolMaintain.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void delete ( )
        {
            base.delete( );

            string idxList = "''";
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                idxList = idxList + "," + "'" + gridView1.GetDataRow( i )["idx"].ToString( ) + "'";
            }
            if ( sign == "1" )
                stateOfState = "新增删除";
            else
                stateOfState = "更改删除";
            bool result = bal.DeleteList( idxList ,"R_526" ,"财务结账" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOfState ,model.AK014 );
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
        protected override void print ( )
        {
            base.print( );

            //file = "";
            //file = Application.StartupPath + "\\R_526.frx";
            //CreatePrint( );
            //report.Load( file );
            //report.RegisterData( RDataSet );
            //report.Show( );
        }
        protected override void export ( )
        {
            base.export( );

            ViewExport . ExportToExcel ( this . Text ,gridControl1 );

            //file = "";
            //file = System.Windows.Forms.Application.StartupPath + "\\R_526.frx";
            //CreatePrint( );
            //report.Load( file );
            //report.RegisterData( RDataSet );
            //report.Prepare( );
            //XMLExport exprots = new XMLExport( );
            //exprots.Export( report );
        }
        protected override void maintain ( )
        {
            base.maintain( );
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
                    for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                    {
                        idxList = idxList + "," + "'" + gridView1.GetDataRow( i )["idx"].ToString( ) + "'";
                    }

                    bal.DeleteList( idxList ,"R_526" ,"财务结账" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"取消" ,"新增取消" ,model.AK014 );
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
                toolSave.Enabled = toolCancel.Enabled =  false;
            }

            sign = "";
        }
        #endregion

        #region Query
        protected override void select ( )
        {
            base.select( );

            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.CheckOutQueryAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );

            if ( list.Count > 0 )
            {
                strWhere = "1=1";
                string  str = "''";
                foreach ( string item in list )
                {
                    if ( !string.IsNullOrEmpty( item ) )
                        str = str + ",'" + item + "'";
                }
                strWhere = strWhere + " AND B.idx IN (" + str + ")";
                //button5_Click( null ,null );
                refre( );
                sign = "2";

                Ergodic.FormEverySpliEnableFalse( this );
                toolAdd.Enabled = toolSelect.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolPrint.Enabled = toolReview.Enabled = toolExport.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolMaintain.Enabled = false;
                list.Clear( );
            }
            else
                MessageBox.Show( "您没有选择任何内容" ); 
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            list = e.List;
        }
        string signQuery = "";
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
                MessageBox.Show( "请选择合同" );
            else
            {
                if ( comboBox1.Text . Equals ( "R_195") )
                {
                    SelectAll.ChanPinZhiBaoAll allChan = new SelectAll.ChanPinZhiBaoAll( );
                    signQuery = "1";
                    allChan.signChan = "1";
                    allChan.variable = textBox1.Text;
                    allChan.StartPosition = FormStartPosition.CenterScreen;
                    allChan.PassDataBetweenForm += new SelectAll.ChanPinZhiBaoAll.PassDataBetweenFormHandler( all_PassDataBetweenForm );
                    allChan.ShowDialog( );
                }
                else if ( comboBox1.Text . Equals ( "R_196") )
                {
                    SelectAll.SiReYiYincontractAll allSi = new SelectAll.SiReYiYincontractAll( );
                    signQuery = "2";
                    allSi.signSi = "1";
                    allSi.variable = textBox1.Text;
                    allSi.StartPosition = FormStartPosition.CenterScreen;
                    allSi.PassDataBetweenForm += new SelectAll.SiReYiYincontractAll.PassDataBetweenFormHandler( all_PassDataBetweenForm );
                    allSi.ShowDialog( );
                }
                else if ( comboBox1.Text . Equals ( "R_338") )
                {
                    SelectAll.JiaomiducontractQueryAll allJiao = new SelectAll.JiaomiducontractQueryAll( );
                    signQuery = "3";
                    allJiao.signJiao = "1";
                    allJiao.variable = textBox1.Text;
                    allJiao.StartPosition = FormStartPosition.CenterScreen;
                    allJiao.PassDataBetweenForm += new SelectAll.JiaomiducontractQueryAll.PassDataBetweenFormHandler( all_PassDataBetweenForm );
                    allJiao.ShowDialog( );
                }
                else if ( comboBox1.Text . Equals ( "R_339") )
                {
                    SelectAll.YouQicontractAll allYou = new SelectAll.YouQicontractAll( );
                    signQuery = "4";
                    allYou.signYou = "1";
                    allYou.variable = textBox1.Text;
                    allYou.StartPosition = FormStartPosition.CenterScreen;
                    allYou.PassDataBetweenForm += new SelectAll.YouQicontractAll.PassDataBetweenFormHandler( all_PassDataBetweenForm );
                    allYou.ShowDialog( );
                }
                else if ( comboBox1.Text . Equals ( "R_341") )
                {
                    SelectAll.MucaiContractQueryAll allMu = new SelectAll.MucaiContractQueryAll( );
                    signQuery = "5";
                    allMu.signMu = "1";
                    allMu.variable = textBox1.Text;
                    allMu.StartPosition = FormStartPosition.CenterScreen;
                    allMu.PassDataBetweenForm += new SelectAll.MucaiContractQueryAll.PassDataBetweenFormHandler( all_PassDataBetweenForm );
                    allMu.ShowDialog( );
                }
                else if ( comboBox1.Text . Equals ( "R_342") )
                {
                    SelectAll.CheMuJiancontractQueryAll allChe = new SelectAll.CheMuJiancontractQueryAll( );
                    signQuery = "6";
                    allChe.signChe = "1";
                    allChe.variable = textBox1.Text;
                    allChe.StartPosition = FormStartPosition.CenterScreen;
                    allChe.PassDataBetweenForm += new SelectAll.CheMuJiancontractQueryAll.PassDataBetweenFormHandler( all_PassDataBetweenForm );
                    allChe.ShowDialog( );
                }
                else if ( comboBox1.Text . Equals ( "R_343") )
                {
                    SelectAll.WuJinContractQueryAll allWu = new SelectAll.WuJinContractQueryAll( );
                    signQuery = "7";
                    allWu.signWuJin = "1";
                    allWu.variable = textBox1.Text;
                    allWu.StartPosition = FormStartPosition.CenterScreen;
                    allWu.PassDataBetweenForm += new SelectAll.WuJinContractQueryAll.PassDataBetweenFormHandler( all_PassDataBetweenForm );
                    allWu.ShowDialog( );
                }
                else if ( comboBox1.Text . Equals ( "R_347") )
                {
                    SelectAll.SuLiaoBucontractQueryAll allSu = new SelectAll.SuLiaoBucontractQueryAll( );
                    signQuery = "8";
                    allSu.signSu = "1";
                    allSu.variable = textBox1.Text;
                    allSu.StartPosition = FormStartPosition.CenterScreen;
                    allSu.PassDataBetweenForm += new SelectAll.SuLiaoBucontractQueryAll.PassDataBetweenFormHandler( all_PassDataBetweenForm );
                    allSu.ShowDialog( );
                }
                else if ( comboBox1.Text . Equals ( "R_349") )
                {
                    SelectAll.WaiXiancontractAll allWai = new SelectAll.WaiXiancontractAll( );
                    signQuery = "9";
                    allWai.signWai = "1";
                    allWai.variable = textBox1.Text;
                    allWai.StartPosition = FormStartPosition.CenterScreen;
                    allWai.PassDataBetweenForm += new SelectAll.WaiXiancontractAll.PassDataBetweenFormHandler( all_PassDataBetweenForm );
                    allWai.ShowDialog( );
                }
                else if ( comboBox1.Text . Equals ( "R_495") )
                {
                    SelectAll.PenYouQiChenAll allPen = new SelectAll.PenYouQiChenAll( );
                    signQuery = "10";
                    allPen.signChan = "1";
                    allPen.StartPosition = FormStartPosition.CenterScreen;
                    allPen.PassDataBetweenForm += new SelectAll.PenYouQiChenAll.PassDataBetweenFormHandler( all_PassDataBetweenForm );
                    allPen.ShowDialog( );
                }
                else if ( comboBox1.Text . Equals ( "R_505") )
                {
                    SelectAll.DuanLiaoAll duanLiao = new SelectAll.DuanLiaoAll( );
                    signQuery = "11";
                    duanLiao.signDuan = "1";
                    duanLiao.StartPosition = FormStartPosition.CenterScreen;
                    duanLiao.PassDataBetweenForm += new SelectAll.DuanLiaoAll.PassDataBetweenFormHandler( all_PassDataBetweenForm );
                    duanLiao.ShowDialog( );
                }
                else if ( comboBox1.Text . Equals ( "R_344") )
                {
                    SelectAll.GunQiContractAll gunqiCon = new SelectAll.GunQiContractAll( );
                    signQuery = "12";
                    gunqiCon.sign = "1";
                    gunqiCon.StartPosition = FormStartPosition.CenterScreen;
                    gunqiCon.PassDataBetweenForm += new SelectAll.GunQiContractAll.PassDataBetweenFormHandler( all_PassDataBetweenForm );
                    gunqiCon.ShowDialog( );
                }
                else if ( comboBox1.Text . Equals ( "R_337") )
                {
                    SelectAll.YouQiSelectAll query = new SelectAll.YouQiSelectAll( );
                    signQuery = "13";
                    query.variable = textBox1.Text;
                    query.sign = "1";
                    query.StartPosition = FormStartPosition.CenterScreen;
                    query.PassDataBetweenForm += new SelectAll.YouQiSelectAll.PassDataBetweenFormHandler( all_PassDataBetweenForm );
                    query.ShowDialog( );
                }
                else if ( comboBox1.Text . Equals ( "R_199") )
                {
                    SelectAll.ContracToDoAJobAll query = new SelectAll.ContracToDoAJobAll( );
                    signQuery = "14";
                    query.variable = textBox1.Text;
                    query.signChan = "1";
                    query.StartPosition = FormStartPosition.CenterScreen;
                    query.PassDataBetweenForm += new SelectAll.ContracToDoAJobAll.PassDataBetweenFormHandler( all_PassDataBetweenForm );
                    query.ShowDialog( );
                }
                else if ( comboBox1.Text .Equals( "R_348") )
                {
                    SelectAll.WaiXianAll query = new SelectAll.WaiXianAll( );
                    signQuery = "15";
                    query.variable = textBox1.Text;
                    query.signChan = "1";
                    query.StartPosition = FormStartPosition.CenterScreen;
                    query.PassDataBetweenForm += new SelectAll.WaiXianAll.PassDataBetweenFormHandler( all_PassDataBetweenForm );
                    query.ShowDialog( );
                }
            }
        }
        private void all_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            conTract = new DataTable( );
            switch ( signQuery )
            {
                case "1":
                {
                    #region
                    textBox1.Text = e.ConOne;
                    model.AK001 = textBox1.Text;
                    textBox2.Text = e.ConTwo;
                    model.AK002 = textBox2.Text;
                    textBox3.Text = e.ConTre;
                    model.AK006 = textBox3.Text;
                    textBox4.Text = e.ConFor;
                    model.AK004 = textBox4.Text;
                    textBox5.Text = e.ConFiv;
                    model.AK005 = textBox5.Text;
                    if ( e.ConSix.IndexOf( "," ) > 0 )
                        textBox7.Text = string.Join( "," ,e.ConSix.Split( ',' ).Distinct( ).ToArray( ) );
                    else
                        textBox7.Text = e.ConSix;
                    model.AK008 = textBox7.Text;
                    //textBox10.Text = e.ConSev;
                    if ( !string.IsNullOrEmpty( e.ConSev ) )
                        model.AK009 = Convert.ToDecimal( e.ConSev );
                    else
                        model.AK009 = 0;
                    textBox6.Text = e.ConEgi;
                    if ( !string.IsNullOrEmpty( e.ConEgi ) )
                        model.AK007 = Convert.ToInt64( e.ConEgi );
                    else
                        model.AK007 = 0;
                    model.AK003 = e.ConNin;
                    list = e.List;


                    conTract = bal.GetDataTablePqqCount( model.AK003 );
                    if ( conTract.Rows.Count > 0 )
                        textBox8.Text = conTract.Rows[0]["CP"].ToString( );
                    //textBox10 . Text = ( string . IsNullOrEmpty ( textBox8 . Text ) == true ? 0 : Convert . ToDecimal ( textBox8 . Text ) - ( string . IsNullOrEmpty ( textBox9 . Text ) == true ? 0 : Convert . ToDecimal ( textBox9 . Text ) ) - ( string . IsNullOrEmpty ( textBox13 . Text ) == true ? 0 : Convert . ToDecimal ( textBox13 . Text ) ) ) . ToString ( );
                    sumAll ( );
                    #endregion
                    break;
                }
                case "2":
                {
                    #region
                    model.AK003 = e.ConOne;
                    textBox2.Text = e.ConTwo;
                    model.AK002 = e.ConTwo;
                    textBox3.Text = e.ConTre;
                    model.AK006 = e.ConTre;
                    textBox4.Text = e.ConFor;
                    model.AK004 = e.ConFor;
                    textBox5.Text = e.ConFiv;
                    model.AK005 = e.ConFiv;
                    textBox1.Text = e.ConSix;
                    model.AK001 = e.ConSix;
                    textBox6.Text = e.ConSev;
                    if ( !string.IsNullOrEmpty( e.ConSev ) )
                        model.AK007 = Convert.ToInt64( e.ConSev );
                    else
                        model.AK007 = 0;
                    if ( e.ConEgi.IndexOf( "," ) > 0 )
                        textBox7.Text = string.Join( "," ,e.ConEgi.Split( ',' ).Distinct( ).ToArray( ) );
                    else
                        textBox7.Text = e.ConEgi;
                    model.AK008 = textBox7.Text;
                    //textBox10.Text = e.ConNin;
                    if ( !string.IsNullOrEmpty( e.ConNin ) )
                        model.AK009 = Convert.ToDecimal( e.ConNin );
                    else
                        model.AK009 = 0;
                    list = e.List;

                    conTract = bal.GetDataTablePqahCount( model.AK003 );
                    if ( conTract.Rows.Count > 0 )
                        textBox8.Text = conTract.Rows[0]["AH"].ToString( );
                    //textBox10 . Text = ( string . IsNullOrEmpty ( textBox8 . Text ) == true ? 0 : Convert . ToDecimal ( textBox8 . Text ) - ( string . IsNullOrEmpty ( textBox9 . Text ) == true ? 0 : Convert . ToDecimal ( textBox9 . Text ) ) - ( string . IsNullOrEmpty ( textBox13 . Text ) == true ? 0 : Convert . ToDecimal ( textBox13 . Text ) ) ) . ToString ( );
                    sumAll ( );
                    #endregion
                    break;
                }
                case "3":
                {
                    #region
                    model.AK003 = e.ConOne;
                    textBox2.Text = e.ConTwo;
                    model.AK002 = e.ConTwo;
                    textBox3.Text = e.ConTre;
                    model.AK006 = e.ConTre;
                    textBox4.Text = e.ConFor;
                    model.AK004 = e.ConFor;
                    textBox5.Text = e.ConFiv;
                    model.AK005 = e.ConFiv;
                    textBox6.Text = e.ConSix;
                    if ( !string.IsNullOrEmpty( e.ConSix ) )
                        model.AK007 = Convert.ToInt64( e.ConSix );
                    else
                        model.AK007 = 0;
                    textBox1.Text = e.ConSev;
                    model.AK001 = e.ConSev;
                    if ( e.ConEgi.IndexOf( "," ) > 0 )
                        textBox7.Text = string.Join( "," ,e.ConEgi.Split( ',' ).Distinct( ).ToArray( ) );
                    else
                        textBox7.Text = e.ConEgi;
                    model.AK008 = textBox7.Text;
                    //textBox10.Text = e.ConNin;
                    if ( !string.IsNullOrEmpty( e.ConNin ) )
                        model.AK009 = Convert.ToDecimal( e.ConNin );
                    else
                        model.AK009 = 0;
                    list = e.List;


                    conTract = bal.GetDataTablePqoCount( model.AK003 );
                    if ( conTract.Rows.Count > 0 )
                        textBox8.Text = conTract.Rows[0]["JM"].ToString( );
                    //textBox10 . Text = ( string . IsNullOrEmpty ( textBox8 . Text ) == true ? 0 : Convert . ToDecimal ( textBox8 . Text ) - ( string . IsNullOrEmpty ( textBox9 . Text ) == true ? 0 : Convert . ToDecimal ( textBox9 . Text ) ) - ( string . IsNullOrEmpty ( textBox13 . Text ) == true ? 0 : Convert . ToDecimal ( textBox13 . Text ) ) ) . ToString ( );
                    sumAll ( );
                    #endregion
                    break;
                }
                case "4":
                {
                    #region
                    model.AK003 = e.ConOne;
                    textBox2.Text = e.ConTwo;
                    model.AK002 = e.ConTwo;
                    textBox3.Text = e.ConTre;
                    model.AK006 = e.ConTre;
                    textBox4.Text = e.ConFor;
                    model.AK004 = e.ConFor;
                    textBox5.Text = e.ConFiv;
                    model.AK005 = e.ConFiv;
                    textBox6.Text = e.ConSix;
                    if ( !string.IsNullOrEmpty( e.ConSix ) )
                        model.AK007 = Convert.ToInt64( e.ConSix );
                    else
                        model.AK007 = 0;
                    textBox1.Text = e.ConSev;
                    model.AK001 = e.ConSev;
                    if ( e.ConEgi.IndexOf( "," ) > 0 )
                        textBox7.Text = string.Join( "," ,e.ConEgi.Split( ',' ).Distinct( ).ToArray( ) );
                    else
                        textBox7.Text = e.ConEgi;
                    model.AK008 = textBox7.Text;
                    //textBox10.Text = e.ConNin;
                    if ( !string.IsNullOrEmpty( e.ConNin ) )
                        model.AK009 = Convert.ToDecimal( e.ConNin );
                    else
                        model.AK009 = 0;
                    list = e.List;


                    conTract = bal.GetDataTablePqiCount( model.AK003 );
                    if ( conTract.Rows.Count > 0 )
                        textBox8.Text = conTract.Rows[0]["YQ"].ToString( );
                    //textBox10 . Text = ( string . IsNullOrEmpty ( textBox8 . Text ) == true ? 0 : Convert . ToDecimal ( textBox8 . Text ) - ( string . IsNullOrEmpty ( textBox9 . Text ) == true ? 0 : Convert . ToDecimal ( textBox9 . Text ) ) - ( string . IsNullOrEmpty ( textBox13 . Text ) == true ? 0 : Convert . ToDecimal ( textBox13 . Text ) ) ) . ToString ( );
                    sumAll ( );
                    #endregion
                    break;
                }
                case "5":
                {
                    #region
                    model.AK003 = e.ConOne;
                    textBox2.Text = e.ConTwo;
                    model.AK002 = e.ConTwo;
                    textBox3.Text = e.ConTre;
                    model.AK006 = e.ConTre;
                    textBox4.Text = e.ConFor;
                    model.AK004 = e.ConFor;
                    textBox5.Text = e.ConFiv;
                    model.AK005 = e.ConFiv;
                    textBox6.Text = e.ConSix;
                    if ( !string.IsNullOrEmpty( e.ConSix ) )
                        model.AK007 = Convert.ToInt64( e.ConSix );
                    else
                        model.AK007 = 0;
                    textBox1.Text = e.ConSev;
                    model.AK001 = e.ConSev;
                    if ( e.ConEgi.IndexOf( "," ) > 0 )
                        textBox7.Text = string.Join( "," ,e.ConEgi.Split( ',' ).Distinct( ).ToArray( ) );
                    else
                        textBox7.Text = e.ConEgi;
                    model.AK008 = textBox7.Text;
                    //textBox10.Text = e.ConNin;
                    if ( !string.IsNullOrEmpty( e.ConNin ) )
                        model.AK009 = Convert.ToDecimal( e.ConNin );
                    else
                        model.AK009 = 0;
                    //textBox8.Text = model.AK009.ToString( );
                    list = e.List;


                    conTract = bal.GetDataTablePqvCount( model.AK003 );
                    if ( conTract.Rows.Count > 0 )
                        textBox8.Text = conTract.Rows[0]["PQV"].ToString( );
                    //textBox10 . Text = ( string . IsNullOrEmpty ( textBox8 . Text ) == true ? 0 : Convert . ToDecimal ( textBox8 . Text ) - ( string . IsNullOrEmpty ( textBox9 . Text ) == true ? 0 : Convert . ToDecimal ( textBox9 . Text ) ) - ( string . IsNullOrEmpty ( textBox13 . Text ) == true ? 0 : Convert . ToDecimal ( textBox13 . Text ) ) ) . ToString ( );
                    sumAll ( );
                    #endregion
                    break;
                }
                case "6":
                {
                    #region
                    model.AK003 = e.ConOne;
                    textBox2.Text = e.ConTwo;
                    model.AK002 = e.ConTwo;
                    textBox3.Text = e.ConTre;
                    model.AK006 = e.ConTre;
                    textBox4.Text = e.ConFor;
                    model.AK004 = e.ConFor;
                    textBox5.Text = e.ConFiv;
                    model.AK005 = e.ConFiv;
                    textBox6.Text = e.ConSix;
                    if ( !string.IsNullOrEmpty( e.ConSix ) )
                        model.AK007 = Convert.ToInt64( e.ConSix );
                    else
                        model.AK007 = 0;
                    textBox1.Text = e.ConSev;
                    model.AK001 = e.ConSev;
                    if ( e.ConEgi.IndexOf( "," ) > 0 )
                        textBox7.Text = string.Join( "," ,e.ConEgi.Split( ',' ).Distinct( ).ToArray( ) );
                    else
                        textBox7.Text = e.ConEgi;
                    model.AK008 = textBox7.Text;
                    //textBox10.Text = e.ConNin;
                    if ( !string.IsNullOrEmpty( e.ConNin ) )
                        model.AK009 = Convert.ToDecimal( e.ConNin );
                    else
                        model.AK009 = 0;
                    list = e.List;

                    conTract = bal.GetDataTablePqafCount( model.AK003 );
                    if ( conTract.Rows.Count > 0 )
                        textBox8.Text = conTract.Rows[0]["AF"].ToString( );
                    //textBox10 . Text = ( string . IsNullOrEmpty ( textBox8 . Text ) == true ? 0 : Convert . ToDecimal ( textBox8 . Text ) - ( string . IsNullOrEmpty ( textBox9 . Text ) == true ? 0 : Convert . ToDecimal ( textBox9 . Text ) ) - ( string . IsNullOrEmpty ( textBox13 . Text ) == true ? 0 : Convert . ToDecimal ( textBox13 . Text ) ) ) . ToString ( );
                    sumAll ( );
                    #endregion
                    break;
                }
                case "7":
                {
                    #region
                    model.AK003 = e.ConOne;
                    textBox2.Text = e.ConTwo;
                    model.AK002 = e.ConTwo;
                    textBox3.Text = e.ConTre;
                    model.AK006 = e.ConTre;
                    textBox4.Text = e.ConFor;
                    model.AK004 = e.ConFor;
                    textBox5.Text = e.ConFiv;
                    model.AK005 = e.ConFiv;
                    textBox6.Text = e.ConSix;
                    if ( !string.IsNullOrEmpty( e.ConSix ) )
                        model.AK007 = Convert.ToInt64( e.ConSix );
                    else
                        model.AK007 = 0;
                    textBox1.Text = e.ConSev;
                    model.AK001 = e.ConSev;
                    if ( e.ConEgi.IndexOf( "," ) > 0 )
                        textBox7.Text = string.Join( "," ,e.ConEgi.Split( ',' ).Distinct( ).ToArray( ) );
                    else
                        textBox7.Text = e.ConEgi;
                    model.AK008 = textBox7.Text;
                    //textBox10.Text = e.ConNin;
                    if ( !string.IsNullOrEmpty( e.ConNin ) )
                        model.AK009 = Convert.ToDecimal( e.ConNin );
                    else
                        model.AK009 = 0;
                    list = e.List;


                    conTract = bal.GetDataTablePquCount( model.AK003 );
                    if ( conTract.Rows.Count > 0 )
                        textBox8.Text = conTract.Rows[0]["PQ"].ToString( );
                    //textBox10 . Text = ( string . IsNullOrEmpty ( textBox8 . Text ) == true ? 0 : Convert . ToDecimal ( textBox8 . Text ) - ( string . IsNullOrEmpty ( textBox9 . Text ) == true ? 0 : Convert . ToDecimal ( textBox9 . Text ) ) - ( string . IsNullOrEmpty ( textBox13 . Text ) == true ? 0 : Convert . ToDecimal ( textBox13 . Text ) ) ) . ToString ( );
                    sumAll ( );
                    #endregion
                    break;
                }
                case "8":
                {
                    #region
                    model.AK003 = e.ConOne;
                    textBox2.Text = e.ConTwo;
                    model.AK002 = e.ConTwo;
                    textBox3.Text = e.ConTre;
                    model.AK006 = e.ConTre;
                    textBox4.Text = e.ConFor;
                    model.AK004 = e.ConFor;
                    textBox5.Text = e.ConFiv;
                    model.AK005 = e.ConFiv;
                    textBox6.Text = e.ConSix;
                    if ( !string.IsNullOrEmpty( e.ConSix ) )
                        model.AK007 = Convert.ToInt64( e.ConSix );
                    else
                        model.AK007 = 0;
                    textBox1.Text = e.ConSev;
                    model.AK001 = e.ConSev;
                    if ( e.ConEgi.IndexOf( "," ) > 0 )
                        textBox7.Text = string.Join( "," ,e.ConEgi.Split( ',' ).Distinct( ).ToArray( ) );
                    else
                        textBox7.Text = e.ConEgi;
                    model.AK008 = textBox7.Text;
                    //textBox10.Text = e.ConNin;
                    if ( !string.IsNullOrEmpty( e.ConNin ) )
                        model.AK009 = Convert.ToDecimal( e.ConNin );
                    else
                        model.AK009 = 0;
                    list = e.List;


                    conTract = bal.GetDataTablePqsCount( model.AK003 );
                    if ( conTract.Rows.Count > 0 )
                        textBox8.Text = conTract.Rows[0]["PQ"].ToString( );
                    //textBox10 . Text = ( string . IsNullOrEmpty ( textBox8 . Text ) == true ? 0 : Convert . ToDecimal ( textBox8 . Text ) - ( string . IsNullOrEmpty ( textBox9 . Text ) == true ? 0 : Convert . ToDecimal ( textBox9 . Text ) ) - ( string . IsNullOrEmpty ( textBox13 . Text ) == true ? 0 : Convert . ToDecimal ( textBox13 . Text ) ) ) . ToString ( );
                    sumAll ( );
                    #endregion
                    break;
                }
                case "9":
                {
                    #region
                    model.AK003 = e.ConOne;
                    textBox2.Text = e.ConTwo;
                    model.AK002 = e.ConTwo;
                    textBox3.Text = e.ConTre;
                    model.AK006 = e.ConTre;
                    textBox4.Text = e.ConFor;
                    model.AK004 = e.ConFor;
                    textBox5.Text = e.ConFiv;
                    model.AK005 = e.ConFiv;
                    textBox6.Text = e.ConSix;
                    if ( !string.IsNullOrEmpty( e.ConSix ) )
                        model.AK007 = Convert.ToInt64( e.ConSix );
                    else
                        model.AK007 = 0;
                    textBox1.Text = e.ConSev;
                    model.AK001 = e.ConSev;
                    if ( e.ConEgi.IndexOf( "," ) > 0 )
                        textBox7.Text = string.Join( "," ,e.ConEgi.Split( ',' ).Distinct( ).ToArray( ) );
                    else
                        textBox7.Text = e.ConEgi;
                    model.AK008 = textBox7.Text;
                    //textBox10.Text = e.ConNin;
                    if ( !string.IsNullOrEmpty( e.ConNin ) )
                        model.AK009 = Convert.ToDecimal( e.ConNin );
                    else
                        model.AK009 = 0;
                    list = e.List;


                    conTract = bal.GetDataTablePqtCount( model.AK003 );
                    if ( conTract.Rows.Count > 0 )
                        textBox8.Text = conTract.Rows[0]["PQ"].ToString( );
                    //textBox10 . Text = ( string . IsNullOrEmpty ( textBox8 . Text ) == true ? 0 : Convert . ToDecimal ( textBox8 . Text ) - ( string . IsNullOrEmpty ( textBox9 . Text ) == true ? 0 : Convert . ToDecimal ( textBox9 . Text ) ) - ( string . IsNullOrEmpty ( textBox13 . Text ) == true ? 0 : Convert . ToDecimal ( textBox13 . Text ) ) ) . ToString ( );
                    sumAll ( );
                    #endregion
                    break;
                }
                case "10":
                {
                    #region
                    model.AK003 = e.ConOne;
                    textBox2.Text = e.ConTwo;
                    model.AK002 = e.ConTwo;
                    textBox3.Text = e.ConTre;
                    model.AK006 = e.ConTre;
                    textBox4.Text = e.ConFor;
                    model.AK004 = e.ConFor;
                    textBox5.Text = e.ConFiv;
                    model.AK005 = e.ConFiv;
                    textBox6.Text = e.ConSix;
                    if ( !string.IsNullOrEmpty( e.ConSix ) )
                        model.AK007 = Convert.ToInt64( e.ConSix );
                    else
                        model.AK007 = 0;
                    textBox1.Text = e.ConSev;
                    model.AK001 = e.ConSev;
                    if ( e.ConEgi.IndexOf( "," ) > 0 )
                        textBox7.Text = string.Join( "," ,e.ConEgi.Split( ',' ).Distinct( ).ToArray( ) );
                    else
                        textBox7.Text = e.ConEgi;
                    model.AK008 = textBox7.Text;
                    //textBox10.Text = e.ConNin;
                    if ( !string.IsNullOrEmpty( e.ConNin ) )
                        model.AK009 = Convert.ToDecimal( e.ConNin );
                    else
                        model.AK009 = 0;
                    list = e.List;


                    conTract = bal.GetDataTablePqyCount( model.AK003 );
                    if ( conTract.Rows.Count > 0 )
                        textBox8.Text = conTract.Rows[0]["U0"].ToString( );
                    //textBox10 . Text = ( string . IsNullOrEmpty ( textBox8 . Text ) == true ? 0 : Convert . ToDecimal ( textBox8 . Text ) - ( string . IsNullOrEmpty ( textBox9 . Text ) == true ? 0 : Convert . ToDecimal ( textBox9 . Text ) ) - ( string . IsNullOrEmpty ( textBox13 . Text ) == true ? 0 : Convert . ToDecimal ( textBox13 . Text ) ) ) . ToString ( );
                    sumAll ( );
                    #endregion
                    break;
                }
                case "11":
                {
                    #region
                    model.AK003 = e.ConNin;
                    textBox2.Text = e.ConTwo;
                    model.AK002 = e.ConTwo;
                    textBox3.Text = e.ConTre;
                    model.AK006 = e.ConTre;
                    textBox4.Text = e.ConFiv;
                    model.AK004 = e.ConFiv;
                    textBox5.Text = e.ConFor;
                    model.AK005 = e.ConFor;
                    textBox6.Text = e.ConEgi;
                    if ( !string.IsNullOrEmpty( e.ConEgi ) )
                        model.AK007 = Convert.ToInt64( e.ConEgi );
                    else
                        model.AK007 = 0;
                    textBox1.Text = e.ConOne;
                    model.AK001 = e.ConOne;
                    if ( e.ConSix.IndexOf( "," ) > 0 )
                        textBox7.Text = string.Join( "," ,e.ConSix.Split( ',' ).Distinct( ).ToArray( ) );
                    else
                        textBox7.Text = e.ConSix;
                    model.AK008 = textBox7.Text;
                    //textBox10.Text = e.ConSev;
                    if ( !string.IsNullOrEmpty( e.ConSev ) )
                        model.AK009 = Convert.ToDecimal( e.ConSev );
                    else
                        model.AK009 = 0;
                    list = e.List;


                    conTract = bal.GetDataTablePqizCount( model.AK003 );
                    if ( conTract.Rows.Count > 0 )
                        textBox8.Text = conTract.Rows[0]["U0"].ToString( );
                    //textBox10 . Text = ( string . IsNullOrEmpty ( textBox8 . Text ) == true ? 0 : Convert . ToDecimal ( textBox8 . Text ) - ( string . IsNullOrEmpty ( textBox9 . Text ) == true ? 0 : Convert . ToDecimal ( textBox9 . Text ) ) - ( string . IsNullOrEmpty ( textBox13 . Text ) == true ? 0 : Convert . ToDecimal ( textBox13 . Text ) ) ) . ToString ( );
                    sumAll ( );
                    #endregion
                    break;
                }
                case "12":
                {
                    #region
                    textBox1.Text = e.ConOne;
                    model.AK001 = e.ConOne;
                    textBox2.Text = e.ConTwo;
                    model.AK002 = e.ConTwo;
                    textBox3.Text = e.ConTre;
                    model.AK006 = e.ConTre;
                    textBox4.Text = e.ConFiv;
                    model.AK004 = e.ConFiv;
                    textBox5.Text = e.ConFor;
                    model.AK005 = e.ConFor;
                    if ( e.ConSix.IndexOf( "," ) > 0 )
                        textBox7.Text = string.Join( "," ,e.ConSix.Split( ',' ).Distinct( ).ToArray( ) );
                    else
                        textBox7.Text = e.ConSix;
                    model.AK008 = textBox7.Text;
                    if ( !string.IsNullOrEmpty( e.ConSev ) )
                        model.AK009 = Convert.ToDecimal( e.ConSev );
                    else
                        model.AK009 = 0;
                    //textBox10.Text = e.ConSev;
                    textBox6.Text = e.ConEgi;
                    if ( !string.IsNullOrEmpty( e.ConEgi ) )
                        model.AK007 = Convert.ToInt64( e.ConEgi );
                    else
                        model.AK007 = 0;
                    model.AK003 = e.ConNin;
                    list = e.List;

                    conTract = bal.GetDataTablePqmzCount( model.AK003 );
                    if ( conTract.Rows.Count > 0 )
                        textBox8.Text = conTract.Rows[0]["MZ0"].ToString( );
                    //textBox10 . Text = ( string . IsNullOrEmpty ( textBox8 . Text ) == true ? 0 : Convert . ToDecimal ( textBox8 . Text ) - ( string . IsNullOrEmpty ( textBox9 . Text ) == true ? 0 : Convert . ToDecimal ( textBox9 . Text ) ) - ( string . IsNullOrEmpty ( textBox13 . Text ) == true ? 0 : Convert . ToDecimal ( textBox13 . Text ) ) ) . ToString ( );
                    sumAll ( );
                    #endregion
                    break;
                }
                case "13":
                {
                    #region
                    textBox1.Text = e.ConOne;
                    model.AK001 = e.ConOne;
                    textBox2.Text = e.ConTwo;
                    model.AK002 = e.ConTwo;
                    textBox3.Text = e.ConTre;
                    model.AK006 = e.ConTre;
                    textBox4.Text = e.ConFiv;
                    model.AK004 = e.ConFiv;
                    textBox5.Text = e.ConFor;
                    model.AK005 = e.ConFor;
                    if ( e.ConSix.IndexOf( "," ) > 0 )
                        textBox7.Text = string.Join( "," ,e.ConSix.Split( ',' ).Distinct( ).ToArray( ) );
                    else
                        textBox7.Text = e.ConSix;
                    model.AK008 = textBox7.Text;
                    if ( !string.IsNullOrEmpty( e.ConSev ) )
                        model.AK009 = Convert.ToDecimal( e.ConSev );
                    else
                        model.AK009 = 0;
                    //textBox10.Text = e.ConSev;
                    textBox6.Text = e.ConEgi;
                    if ( !string.IsNullOrEmpty( e.ConEgi ) )
                        model.AK007 = Convert.ToInt64( e.ConEgi );
                    else
                        model.AK007 = 0;
                    model.AK003 = e.ConNin;
                    list = e.List;

                    conTract = bal.GetDataTablePqisCount( model.AK003 );
                    if ( conTract.Rows.Count > 0 )
                        textBox8.Text = conTract.Rows[0]["YQ"].ToString( );
                    //textBox10 . Text = ( string . IsNullOrEmpty ( textBox8 . Text ) == true ? 0 : Convert . ToDecimal ( textBox8 . Text ) - ( string . IsNullOrEmpty ( textBox9 . Text ) == true ? 0 : Convert . ToDecimal ( textBox9 . Text ) ) - ( string . IsNullOrEmpty ( textBox13 . Text ) == true ? 0 : Convert . ToDecimal ( textBox13 . Text ) ) ) . ToString ( );
                    sumAll ( );
                    #endregion
                    break;
                }
                case "14":
                {
                    #region
                    textBox1.Text = e.ConOne;
                    model.AK001 = textBox1.Text;
                    textBox2.Text = e.ConTwo;
                    model.AK002 = textBox2.Text;
                    textBox3.Text = e.ConTre;
                    model.AK006 = textBox3.Text;
                    textBox4.Text = e.ConFor;
                    model.AK004 = textBox4.Text;
                    textBox5.Text = e.ConFiv;
                    model.AK005 = textBox5.Text;
                    if ( e.ConSix.IndexOf( "," ) > 0 )
                        textBox7.Text = string.Join( "," ,e.ConSix.Split( ',' ).Distinct( ).ToArray( ) );
                    else
                        textBox7.Text = e.ConSix;
                    model.AK008 = textBox7.Text;
                    //textBox10.Text = e.ConSev;
                    if ( !string.IsNullOrEmpty( e.ConSev ) )
                        model.AK009 = Convert.ToDecimal( e.ConSev );
                    else
                        model.AK009 = 0;
                    textBox6.Text = e.ConEgi;
                    if ( !string.IsNullOrEmpty( e.ConEgi ) )
                        model.AK007 = Convert.ToInt64( e.ConEgi );
                    else
                        model.AK007 = 0;
                    model.AK003 = e.ConNin;
                    list = e.List;


                    conTract = bal.GetDataTablePqbaCount( model.AK003 );
                    if ( conTract.Rows.Count > 0 )
                        textBox8.Text = conTract.Rows[0]["BA"].ToString( );
                    //textBox10 . Text = ( string . IsNullOrEmpty ( textBox8 . Text ) == true ? 0 : Convert . ToDecimal ( textBox8 . Text ) - ( string . IsNullOrEmpty ( textBox9 . Text ) == true ? 0 : Convert . ToDecimal ( textBox9 . Text ) ) - ( string . IsNullOrEmpty ( textBox13 . Text ) == true ? 0 : Convert . ToDecimal ( textBox13 . Text ) ) ) . ToString ( );
                    sumAll ( );
                    #endregion
                    break;
                }
                case "15":
                {
                    #region
                    textBox1.Text = e.ConOne;
                    model.AK001 = textBox1.Text;
                    textBox2.Text = e.ConTwo;
                    model.AK002 = textBox2.Text;
                    textBox3.Text = e.ConTre;
                    model.AK006 = textBox3.Text;
                    textBox4.Text = e.ConFor;
                    model.AK004 = textBox4.Text;
                    textBox5.Text = e.ConFiv;
                    model.AK005 = textBox5.Text;
                    if ( e.ConSix.IndexOf( "," ) > 0 )
                        textBox7.Text = string.Join( "," ,e.ConSix.Split( ',' ).Distinct( ).ToArray( ) );
                    else
                        textBox7.Text = e.ConSix;
                    model.AK008 = textBox7.Text;
                    //textBox10.Text = e.ConSev;
                    if ( !string.IsNullOrEmpty( e.ConSev ) )
                        model.AK009 = Convert.ToDecimal( e.ConSev );
                    else
                        model.AK009 = 0;
                    textBox6.Text = e.ConEgi;
                    if ( !string.IsNullOrEmpty( e.ConEgi ) )
                        model.AK007 = Convert.ToInt64( e.ConEgi );
                    else
                        model.AK007 = 0;
                    model.AK003 = e.ConNin;
                    list = e.List;

                    conTract = bal.GetDataTablePqozCount( model.AK003 );
                    if ( conTract.Rows.Count > 0 )
                        textBox8.Text = conTract.Rows[0]["OZ"].ToString( );
                    //textBox10 . Text = ( string . IsNullOrEmpty ( textBox8 . Text ) == true ? 0 : Convert . ToDecimal ( textBox8 . Text ) - ( string . IsNullOrEmpty ( textBox9 . Text ) == true ? 0 : Convert . ToDecimal ( textBox9 . Text ) ) - ( string . IsNullOrEmpty ( textBox13 . Text ) == true ? 0 : Convert . ToDecimal ( textBox13 . Text ) ) ) . ToString ( );
                    sumAll ( );
                    #endregion
                    break;
                }
            }
        }
        void sumAll ( )
        {
            textBox13 . Text = 0 . ToString ( );
            conTractYi = bal.GetDataTablePqak( model.AK003 );
            if ( conTractYi.Rows.Count > 0 )
                textBox13.Text = conTractYi.Rows[0]["AK011"].ToString( );
        }
        #endregion

        #region Table
        void queryModel ( )
        {
            model.AK001 = textBox1.Text;
            model.AK002 = textBox2.Text;
            model.AK004 = textBox4.Text;
            model.AK005 = textBox5.Text;
            model.AK006 = textBox3.Text;
            long count = 0;
            long.TryParse( string.IsNullOrEmpty( textBox6.Text ) ? "0" : textBox6.Text ,out count );
            model.AK007 = count;
            model.AK008 = textBox7.Text;
            decimal yfhj = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox8.Text ) ? "0M" : textBox8.Text ,out yfhj );
            model.AK009 = yfhj;
            decimal num = 0;
            decimal.TryParse( string.IsNullOrEmpty( textBox9.Text ) ? "0" : textBox9.Text ,out num );
            model.AK010 = num;
            decimal bcfk = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox10.Text ) ? "0M" : textBox10.Text ,out bcfk );
            model.AK011 = bcfk;
            model.AK012 = dateTimePicker1.Value;
            model.AK013 = textBox12.Text;
            model.AK017 = comboBox2.Text;
            bcfk = 0M;
            decimal.TryParse( string.IsNullOrEmpty( textBox13.Text ) ? "0M" : textBox13.Text ,out bcfk );
            model.AK015 = bcfk;
        }
        //Build
        private void button2_Click ( object sender , EventArgs e )
        {
            if ( string . IsNullOrEmpty ( textBox1 . Text ) )
                MessageBox . Show ( "供应商不可为空" );
            else
            {
                queryModel ( );
                result = bal . ExistsAll ( model );
                if ( result == true )
                {
                    if ( MessageBox . Show ( "已经存在相同的记录,是否新建?" , "提示" , MessageBoxButtons . OKCancel ) == DialogResult . OK )
                        build ( );
                }
                else
                    build ( );
            }
        }
        void build ( )
        {
            result = false;
            if ( sign == "1" )
                stateOfState = "新增新建";
            else
                stateOfState = "更改新建";
            model . Idx = bal . Add ( model , "R_526" , "财务结账" , Logins . username , DateTime . Now , "新建" , stateOfState );
            if ( model . Idx > 0 )
            {
                foreach ( string item in list )
                {
                    if ( !string . IsNullOrEmpty ( item ) )
                        model . IdxContract = Convert . ToInt32 ( item );

                    result = bal . AddAl ( model , "R_526" , "财务结账" , Logins . username , DateTime . Now , "新建" , stateOfState );
                }

                if ( result == true )
                {
                    MessageBox . Show ( "成功录入数据" );
                    if ( sign == "1" )
                    {
                        strWhere = "1=1";
                        strWhere = "AK014='" + model . AK014 + "'";
                        refre ( );
                    }
                    else
                    {
                        DataRow row = tableQuery.NewRow( );
                        row [ "idx" ] = model . Idx;
                        row [ "AK014" ] = model . AK014;
                        row [ "AK001" ] = model . AK001;
                        row [ "AK002" ] = model . AK002;
                        row [ "AK003" ] = model . AK003;
                        row [ "AK004" ] = model . AK004;
                        row [ "AK005" ] = model . AK005;
                        row [ "AK006" ] = model . AK006;
                        row [ "AK007" ] = model . AK007;
                        row [ "AK008" ] = model . AK008;
                        row [ "AK009" ] = model . AK009;
                        row [ "AK010" ] = model . AK010;
                        row [ "AK011" ] = model . AK011;
                        row [ "AK012" ] = model . AK012;
                        row [ "AK013" ] = model . AK013;
                        row [ "AK015" ] = model . AK015;
                        row [ "AK017" ] = model . AK017;
                        tableQuery . Rows . Add ( row );
                        tableQuery . DefaultView . Sort = ( "idx DESC" );

                        //R_349_view_Click( null ,null );
                        list . Clear ( );
                    }
                }
                else
                {
                    MessageBox . Show ( "录入数据失败" );
                    try
                    {
                        if ( sign == "1" )
                            stateOfState = "新增删除";
                        else
                            stateOfState = "更改删除";
                        bal . Delete ( model , "R_526" , "财务结账" , Logins . username , DateTime . Now , "删除" , stateOfState );
                    }
                    catch { }
                }
            }
            else
                MessageBox . Show ( "录入数据失败" );
        }
        //Edit
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( gridView1.GetDataRow( gridView1.FocusedRowHandle )["AK017"].ToString( ) == "执行" )
            {
                if ( Logins.number != "MLL-0001" && Logins . number != "MLL-0008" )
                {
                    MessageBox.Show( "此记录状态为执行,不允许编辑" );
                    return;
                }
            }
            batchEdit( );
            queryModel( );
            if ( string.IsNullOrEmpty( textBox1.Text ) )
                MessageBox.Show( "供应商不可为空" );
            else
            {
                if ( list.Count > 0 )
                {
                    result = bal.Exists( model.Idx );
                    if ( result == false )
                    {
                        foreach ( string item in list )
                        {
                            if ( !string.IsNullOrEmpty( item ) )
                                model.IdxContract = Convert.ToInt32( item );
                            if ( sign == "1" )
                                stateOfState = "新增新建";
                            else
                                stateOfState = "更改新建";
                            result = bal.AddAl( model ,"R_526" ,"财务结账" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"新建" ,stateOfState );
                        }
                        if ( result==true )
                            edit( );
                        else
                            MessageBox.Show( "编辑数据失败" );
                    }
                    else
                    {
                        if ( sign == "1" )
                            stateOfState = "新增删除";
                        else
                            stateOfState = "更改删除";
                        result = bal.DeleteAl( model ,"R_526" ,"财务结账" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOfState );
                        if ( result == true )
                        {
                            foreach ( string item in list )
                            {
                                if ( !string.IsNullOrEmpty( item ) )
                                    model.IdxContract = Convert.ToInt32( item );
                                if ( sign == "1" )
                                    stateOfState = "新增新建";
                                else
                                    stateOfState = "更改新建";
                                result = bal.AddAl( model,"R_526" ,"财务结账" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"新建" ,stateOfState );
                            }
                            if ( result == true )
                                edit( );
                            else
                                MessageBox.Show( "编辑数据失败" );
                        }
                        else
                            MessageBox.Show( "编辑数据失败" );
                    }
                }
                else
                    edit( );
            }
        }
        void edit ( )
        {
            if ( sign == "1" )
                stateOfState = "新增编辑";
            else
                stateOfState = "更改编辑";
            bool result = bal.Update( model ,"R_526" ,"财务结账" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"编辑" ,stateOfState );
            if ( result == true )
            {
                MessageBox.Show( "编辑数据成功" );
                int num = gridView1.FocusedRowHandle;
                DataRow row = tableQuery.Rows[num];
                row.BeginEdit( );
                row["AK014"] = model.AK014;
                row["AK001"] = model.AK001;
                row["AK002"] = model.AK002;
                row["AK003"] = model.AK003;
                row["AK004"] = model.AK004;
                row["AK005"] = model.AK005;
                row["AK006"] = model.AK006;
                row["AK007"] = model.AK007;
                row["AK008"] = model.AK008;
                row["AK009"] = model.AK009;
                row["AK010"] = model.AK010;
                row["AK011"] = model.AK011;
                row["AK012"] = model.AK012;
                row["AK013"] = model.AK013;
                row["AK015"] = model.AK015;
                row["AK017"] = model.AK017;
                row.EndEdit( );
                tableQuery.DefaultView.Sort = ( "idx DESC" );
                //R_349_view_Click( null ,null );
                list.Clear( );
            }
            else
                MessageBox.Show( "编辑数据失败" );
        }
        void batchEdit ( )
        {
            if ( string.IsNullOrEmpty( comboBox2.Text ) )
            {
                MessageBox.Show( "请选择是否执行" );
                return;
            }
            string str = "";
            for ( int i = 0 ; i < gridView1.DataRowCount ; i++ )
            {
                if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                {
                    if ( str == "" )
                        str = gridView1.GetDataRow( i )["idx"].ToString( );
                    else
                        str = str + "," + gridView1.GetDataRow( i )["idx"].ToString( );
                }
            }

            if ( str != "" )
            {
                try
                {
                    if ( sign == "1" )
                        stateOfState = "新增批量编辑状态";
                    else
                        stateOfState = "更改批量编辑状态";
                    bal.UpdateOfState( str ,MulaolaoBll . Drity . GetDt ( ) ,"R_526" ,"财务结账" ,Logins.username ,"删除" ,stateOfState ,model.AK014 );
                }
                catch { }
            }
        }
        //Delete
        private void button4_Click ( object sender ,EventArgs e )
        {
        
            if ( gridView1.GetDataRow( gridView1.FocusedRowHandle )["AK017"].ToString( ) == "执行" || gridView1.GetDataRow( gridView1.FocusedRowHandle )["AK017"].ToString( ) == "审核" )
            {
                if ( Logins . number != "MLL-0001" && Logins . number != "MLL-0008" )
                {
                    MessageBox . Show ( "此记录状态为执行,不允许删除" );
                    return;
                }
            }
            if ( MessageBox.Show( "确认删除?" ,"确认" ,MessageBoxButtons.OKCancel  ) == DialogResult.OK )
            {
                if ( sign == "1" )
                    stateOfState = "新增删除";
                else
                    stateOfState = "更改删除";
                int num = gridView1.FocusedRowHandle;
                result = bal.Delete( model ,"R_526" ,"财务结账" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOfState );
                if ( result == true )
                {
                    MessageBox.Show( "成功删除数据" );                  
                    tableQuery.Rows.RemoveAt( num );
                }
                else
                    MessageBox.Show( "删除数据失败" );
            }
        }
        //Refresh
        private void R_349_view_Click ( object sender ,EventArgs e )
        {
            GridView view = sender as GridView;
            assginContrac( view );
        }
        void assginContrac (GridView view )
        {
            decimal val = 0.0001M;
            for ( int i = 0 ; i < view.RowCount ; i++ )
            {
                if ( view.GetDataRow( i )["WX10"].ToString( ) == "双瓦外箱" || view.GetDataRow( i )["WX10"].ToString( ) == "小箱式" )
                {
                    if ( !string.IsNullOrEmpty( view.GetDataRow( i )["WX27"].ToString( ) ) && !string.IsNullOrEmpty( view.GetDataRow( i )["WX28"].ToString( ) ) && !string.IsNullOrEmpty( view.GetDataRow( i )["WX29"].ToString( ) ) )
                        view.SetRowCellValue( i ,view.Columns["U3"] ,Convert.ToDecimal( view.GetDataRow( i )["WX27"].ToString( ) ) + Convert.ToDecimal( view.GetDataRow( i )["WX28"].ToString( ) ) + Convert.ToDecimal( view.GetDataRow( i )["WX29"].ToString( ) ) );
                    else
                        view.SetRowCellValue( i ,view.Columns["U3"] ,val );
                    if ( !string.IsNullOrEmpty( view.GetDataRow( i )["WX30"].ToString( ) ) && !string.IsNullOrEmpty( view.GetDataRow( i )["WX31"].ToString( ) ) && !string.IsNullOrEmpty( view.GetDataRow( i )["WX32"].ToString( ) ) )
                        view.SetRowCellValue( i ,view.Columns["U4"] ,Convert.ToDecimal( view.GetDataRow( i )["WX30"].ToString( ) ) + Convert.ToDecimal( view.GetDataRow( i )["WX31"].ToString( ) ) + Convert.ToDecimal( view.GetDataRow( i )["WX32"].ToString( ) ) );
                    else
                        view.SetRowCellValue( i ,view.Columns["U4"] ,val );
                }
                else if ( view.GetDataRow( i )["WX10"].ToString( ) == "牙膏式" || view.GetDataRow( i )["WX10"].ToString( ) == "插口式" )
                {
                    if ( !string.IsNullOrEmpty( view.GetDataRow( i )["WX27"].ToString( ) ) && !string.IsNullOrEmpty( view.GetDataRow( i )["WX28"].ToString( ) ) && !string.IsNullOrEmpty( view.GetDataRow( i )["WX29"].ToString( ) ) )
                        view.SetRowCellValue( i ,view.Columns["U3"] ,Convert.ToDecimal( view.GetDataRow( i )["WX27"].ToString( ) ) + 2 * Convert.ToDecimal( view.GetDataRow( i )["WX28"].ToString( ) ) + Convert.ToDecimal( view.GetDataRow( i )["WX29"].ToString( ) ) );
                    else
                        view.SetRowCellValue( i ,view.Columns["U3"] ,val );
                    if ( !string.IsNullOrEmpty( view.GetDataRow( i )["WX30"].ToString( ) ) && !string.IsNullOrEmpty( view.GetDataRow( i )["WX31"].ToString( ) ) && !string.IsNullOrEmpty( view.GetDataRow( i )["WX32"].ToString( ) ) )
                        view.SetRowCellValue( i ,view.Columns["U4"] ,2 * Convert.ToDecimal( view.GetDataRow( i )["WX30"].ToString( ) ) + 2 * Convert.ToDecimal( view.GetDataRow( i )["WX31"].ToString( ) ) + Convert.ToDecimal( view.GetDataRow( i )["WX32"].ToString( ) ) );
                    else
                        view.SetRowCellValue( i ,view.Columns["U4"] ,val );
                }
                else if ( view.GetDataRow( i )["WX10"].ToString( ) == "折叠式" )
                {
                    if ( !string.IsNullOrEmpty( view.GetDataRow( i )["WX27"].ToString( ) ) && !string.IsNullOrEmpty( view.GetDataRow( i )["WX28"].ToString( ) ) && !string.IsNullOrEmpty( view.GetDataRow( i )["WX29"].ToString( ) ) )
                        view.SetRowCellValue( i ,view.Columns["U3"] ,2 * Convert.ToDecimal( view.GetDataRow( i )["WX27"].ToString( ) ) + 2 * Convert.ToDecimal( view.GetDataRow( i )["WX28"].ToString( ) ) + Convert.ToDecimal( view.GetDataRow( i )["WX29"].ToString( ) ) );
                    else
                        view.SetRowCellValue( i ,view.Columns["U3"] ,val );
                    if ( !string.IsNullOrEmpty( view.GetDataRow( i )["WX30"].ToString( ) ) && !string.IsNullOrEmpty( view.GetDataRow( i )["WX31"].ToString( ) ) && !string.IsNullOrEmpty( view.GetDataRow( i )["WX32"].ToString( ) ) )
                        view.SetRowCellValue( i ,view.Columns["U4"] ,Convert.ToDecimal( 1.5 ) * Convert.ToDecimal( view.GetDataRow( i )["WX30"].ToString( ) ) + Convert.ToDecimal( view.GetDataRow( i )["WX31"].ToString( ) ) + Convert.ToDecimal( view.GetDataRow( i )["WX32"].ToString( ) ) );
                    else
                        view.SetRowCellValue( i ,view.Columns["U4"] ,val );
                }
                else if ( view.GetDataRow( i )["WX10"].ToString( ) == "天盖" || view.GetDataRow( i )["WX10"].ToString( ) == "地盖" )
                {
                    if ( !string.IsNullOrEmpty( view.GetDataRow( i )["WX27"].ToString( ) ) && !string.IsNullOrEmpty( view.GetDataRow( i )["WX28"].ToString( ) ) && !string.IsNullOrEmpty( view.GetDataRow( i )["WX29"].ToString( ) ) )
                        view.SetRowCellValue( i ,view.Columns["U3"] ,Convert.ToDecimal( view.GetDataRow( i )["WX27"].ToString( ) ) + 2 * Convert.ToDecimal( view.GetDataRow( i )["WX28"].ToString( ) ) + Convert.ToDecimal( view.GetDataRow( i )["WX29"].ToString( ) ) );
                    else
                        view.SetRowCellValue( i ,view.Columns["U3"] ,val );
                    if ( !string.IsNullOrEmpty( view.GetDataRow( i )["WX30"].ToString( ) ) && !string.IsNullOrEmpty( view.GetDataRow( i )["WX31"].ToString( ) ) && !string.IsNullOrEmpty( view.GetDataRow( i )["WX32"].ToString( ) ) )
                        view.SetRowCellValue( i ,view.Columns["U4"] ,Convert.ToDecimal( view.GetDataRow( i )["WX30"].ToString( ) ) + 2 * Convert.ToDecimal( view.GetDataRow( i )["WX31"].ToString( ) ) + Convert.ToDecimal( view.GetDataRow( i )["WX32"].ToString( ) ) );
                    else
                        view.SetRowCellValue( i ,view.Columns["U4"] ,val );
                }
                else
                {
                    view.SetRowCellValue( i ,view.Columns["U3"] ,val );
                    view.SetRowCellValue( i ,view.Columns["U4"] ,val );
                }
            }
        }
        private void button5_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            strWhere = "AK014='" + model.AK014 + "'";
            refre( );
        }
        void refre ( )
        {
            ds = new DataSet( );
            if ( string.IsNullOrEmpty( strWhere ) )
                strWhere = "1=1";
            tableQuery = bal.GetList( strWhere );
            tableQuery.Columns.Add( "check" ,typeof( Boolean ) );
            tableQuery.TableName = "PQAK";
            ds.Tables.Add( tableQuery );
            tablePqq = bal.GetDataTablePqq( strWhere );
            tablePqq.TableName = "PQQ";
            ds.Tables.Add( tablePqq );
            DataRelation relationPqq = new DataRelation( "R_195" ,ds.Tables["PQAK"].Columns["idx"] ,ds.Tables["PQQ"].Columns["idx"] );
            ds.Relations.Add( relationPqq );
            tablePqah = bal.GetDataTablePqah( strWhere );
            tablePqah.TableName = "PQAH";
            ds.Tables.Add( tablePqah );
            DataRelation relationPqah = new DataRelation( "R_196" ,ds.Tables["PQAK"].Columns["idx"] ,ds.Tables["PQAH"].Columns["idx"] );
            ds.Relations.Add( relationPqah );
            tablePqo = bal.GetDataTablePqo( strWhere );
            tablePqo.TableName = "PQO";
            ds.Tables.Add( tablePqo );
            DataRelation relationPqo = new DataRelation( "R_338" ,ds.Tables["PQAK"].Columns["idx"] ,ds.Tables["PQO"].Columns["idx"] );
            ds.Relations.Add( relationPqo );
            tablePqi = bal.GetDataTablePqi( strWhere );
            tablePqi.TableName = "PQI";
            ds.Tables.Add( tablePqi );
            DataRelation relationPqi = new DataRelation( "R_339" ,ds.Tables["PQAK"].Columns["idx"] ,ds.Tables["PQI"].Columns["idx"] );
            ds.Relations.Add( relationPqi );
            tablePqv = bal.GetDataTablePqv( strWhere );
            tablePqv.TableName = "PQV";
            ds.Tables.Add( tablePqv );
            DataRelation relationPqv = new DataRelation( "R_341" ,ds.Tables["PQAK"].Columns["idx"] ,ds.Tables["PQV"].Columns["idx"] );
            ds.Relations.Add( relationPqv );
            tablePqaf = bal.GetDataTablePqaf( strWhere );
            tablePqaf.TableName = "PQAF";
            ds.Tables.Add( tablePqaf );
            DataRelation relationPqaf = new DataRelation( "R_342" ,ds.Tables["PQAK"].Columns["idx"] ,ds.Tables["PQAF"].Columns["idx"] );
            ds.Relations.Add( relationPqaf );
            tablePqu = bal.GetDataTablePqu( strWhere );
            tablePqu.TableName = "PQU";
            ds.Tables.Add( tablePqu );
            DataRelation relationPqu = new DataRelation( "R_343" ,ds.Tables["PQAK"].Columns["idx"] ,ds.Tables["PQU"].Columns["idx"] );
            ds.Relations.Add( relationPqu );
            tablePqs = bal.GetDataTablePqs( strWhere );
            tablePqs.TableName = "PQS";
            ds.Tables.Add( tablePqs );
            DataRelation relationPqs = new DataRelation( "R_347" ,ds.Tables["PQAK"].Columns["idx"] ,ds.Tables["PQS"].Columns["idx"] );
            ds.Relations.Add( relationPqs );
            tablePqt = bal.GetDataTablePqt( strWhere );
            tablePqt.TableName = "PQT";
            ds.Tables.Add( tablePqt );
            DataRelation relationPqt = new DataRelation( "R_349" ,ds.Tables["PQAK"].Columns["idx"] ,ds.Tables["PQT"].Columns["idx"] );
            ds.Relations.Add( relationPqt );
            tablePqy = bal.GetDataTablePqy( strWhere );
            tablePqy.TableName = "PQY";
            ds.Tables.Add( tablePqy );
            DataRelation relationPqy = new DataRelation( "R_495" ,ds.Tables["PQAK"].Columns["idx"] ,ds.Tables["PQY"].Columns["idx"] );
            ds.Relations.Add( relationPqy );
            tablePqiz = bal.GetDataTablePqiz( strWhere );
            tablePqiz.TableName = "PQIZ";
            ds.Tables.Add( tablePqiz );
            DataRelation relationPqiz = new DataRelation( "R_505" ,ds.Tables["PQAK"].Columns["idx"] ,ds.Tables["PQIZ"].Columns["idx"] );
            ds.Relations.Add( relationPqiz );
            //tablePqlz = bal.GetDataTablePqlz( strWhere );
            //tablePqlz.TableName = "PQLZ";
            //ds.Tables.Add( tablePqlz );
            //DataRelation relationPqlz = new DataRelation( "R_345" ,ds.Tables["PQAK"].Columns["idx"] ,ds.Tables["PQLZ"].Columns["idx"] );
            //ds.Relations.Add( relationPqlz );
            tablePqmz = bal.GetDataTablePqmz( strWhere );
            tablePqmz.TableName = "PQMZ";
            ds.Tables.Add( tablePqmz );
            DataRelation relationPqmz = new DataRelation( "R_340" ,ds.Tables["PQAK"].Columns["idx"] ,ds.Tables["PQMZ"].Columns["idx"] );
            ds.Relations.Add( relationPqmz );
            tablePqis = bal.GetDataTablePqis( strWhere );
            tablePqis.TableName = "PQIS";
            ds.Tables.Add( tablePqis );
            DataRelation relationPqis = new DataRelation( "R_337",ds.Tables["PQAK"].Columns["idx"] ,ds.Tables["PQIS"].Columns["idx"] );
            ds.Relations.Add( relationPqis );
            tablePqba = bal.GetDataTablePqba( strWhere );
            tablePqba.TableName = "PQBA";
            ds.Tables.Add( tablePqba );
            DataRelation relationPqba = new DataRelation( "R_199" ,ds.Tables["PQAK"].Columns["idx"] ,ds.Tables["PQBA"].Columns["idx"] );
            ds.Relations.Add( relationPqba );
            gridControl1.DataSource = ds.Tables["PQAK"];
            strWhere = "1=1";
            thereExist = bal.GetDataTableOfAll( );
            assginSum ( );
        }
        void assginSum ( )
        {
            if ( gridView1 . RowCount > 0 )
            {
                List<string> strList = new List<string> ( );
                decimal sumAK009 = 0M;
                string oddNumAK003 = string . Empty;
                for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
                {
                    oddNumAK003 = gridView1 . GetDataRow ( i ) [ "AK003" ] . ToString ( ) . Trim ( );
                    if ( !strList . Contains ( oddNumAK003 ) )
                    {
                        strList . Add ( oddNumAK003 );
                        sumAK009 += string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "AK009" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "AK009" ] . ToString ( ) );
                    }
                }
                AK009 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( sumAK009 ,2 ) . ToString ( ) );
                U0 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,( sumAK009 - Convert . ToDecimal ( AK010 . SummaryItem . SummaryValue ) - Convert . ToDecimal ( AK011 . SummaryItem . SummaryValue ) ) . ToString ( ) );
                //u0=[AK009] - [AK010] - [AK011] - [AK015]
            }
        }
        //checkAll
        private void button6_Click ( object sender ,EventArgs e )
        {
            for ( int i = 0 ; i < gridView1.DataRowCount ; i++ )
            {
                gridView1.GetDataRow( i )["check"] = true;
            }
        }
        //unCheckAll
        private void button7_Click ( object sender ,EventArgs e )
        {
            for ( int i = 0 ; i < gridView1.DataRowCount ; i++ )
            {
                gridView1.GetDataRow( i )["check"] = false;
            }
        }
        #endregion

    }
}
