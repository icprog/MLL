using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using StudentMgr;
using Mulaolao.Contract;
using Mulaolao.Class;
using Mulaolao.Other;

namespace Mulaolao.Raw_material_cost
{
    public partial class R_Frmhuaxuepicichenben : FormChild
    {
        public R_Frmhuaxuepicichenben ( /*Form fm*/ )
        {
            //this.MdiParent = fm;
            InitializeComponent( );
            
            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . bandedGridView1  } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.HuaXuePiCiChenBen hxp = new MulaolaoLibrary.HuaXuePiCiChenBen( );
        MulaolaoBll.Bll.HuaXuePingCiChenBenBll _bll = new MulaolaoBll.Bll.HuaXuePingCiChenBenBll( );
        DataTable dg;
        R_Frmpenselect pl = new R_Frmpenselect( );
        R_Frm285 frm = new R_Frm285( ); Factory fc = new Factory( );
        string sele = "", weihu = "";
        GroupBox[] gb;
        
        private void R_Frmhuaxuepicichenben_Load ( object sender ,EventArgs e )
        {
            Power( this );
            gb = new GroupBox[] { groupBox1 ,groupBox2 ,groupBox4 };
            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;
            Ergodic.FormGroupboxEnableFalse( this ,gb );

            label107.Visible = false;
        }

        #region  查询
        //查询
        protected override void select ( )
        {
            base . select ( );

            //DataTable dl = SqlHelper.ExecuteDataTable( "WITH CET AS (SELECT PQK01,PQK02,PQK13,PQK23,PQK14,PQK12,PQK03,PQK04,PQK05,PQK06,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=PQK01)) RES05,CASE WHEN (PQK09<0 OR PQK09 IS NULL) OR (PQK37<0 OR PQK37 IS NULL) OR PQK09<PQK18 OR PQK37<PQK32 THEN '未入库' WHEN PQK09=PQK18 OR PQK37=PQK32 THEN '已入库' END PQK09,PQK41,ISNULL(CONVERT(FLOAT,PQK10*PQK25+PQK31*PQK25),0) US,ISNULL(CONVERT(FLOAT,CONVERT(DECIMAL(11,1),(PQK23*PQK20*PQK21*PQK22/(PQK08*PQK19))*PQK27*PQK26/100+PQK08*PQK19*PQK20*PQK23*PQK21*PQK22*0.0001*PQK27*PQK28/100)),0) UJ FROM R_PQK ) SELECT PQK01,PQK02,PQK13,PQK23,PQK14,PQK12,PQK03,PQK04,PQK05,PQK06,RES05,PQK09,PQK41,SUM(US) US,SUM(UJ) UJ FROM CET GROUP BY PQK01,PQK02,PQK13,PQK23,PQK14,PQK12,PQK03,PQK04,PQK05,PQK06,RES05,PQK09,PQK41" );
            //if ( dl.Rows.Count < 1 )
            //    MessageBox.Show( "没有数据" );
            //else
            //{
            //frm.gridControl1.DataSource = dl;
            sele = "1";
            frm . Text = "R_285 信息查询";
            frm . PassDataBetweenForm += new R_Frm285 . PassDataBetweenFormHandler ( pl_PassDataBetweenForm );
            frm . StartPosition = FormStartPosition . CenterScreen;
            frm . ShowDialog ( );

            if ( string . IsNullOrEmpty ( hxp . PQK01 ) )
                MessageBox . Show ( "您没有选择任何数据" );
            else
            {
                Ergodic . FormGroupboxEnableFalse ( this ,gb );
                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = false;

                dg = SqlHelper . ExecuteDataTable ( "SELECT idx,PQK07,PQK18,PQK32,PQK16,PQK11,PQK17,PQK08,PQK19,PQK20,PQK21,PQK22,PQK23,PQK24,PQK25,PQK26,PQK27,PQK28,PQK09,PQK37,PQK10,PQK31,PQK29,PQK30,PQK38 FROM R_PQK WHERE PQK01 = @PQK01" ,new SqlParameter ( "@PQK01" ,hxp . PQK01 ) );
                gridControl1 . DataSource = dg;
            }
            //}
        }
        //流水号查询
        private void button1_Click ( object sender ,EventArgs e )
        {
            DataTable da = SqlHelper.ExecuteDataTable( "SELECT YQ12,YQ107,YQ03,YQ06,PY07,PY04 FROM R_PQI A,R_PQY B WHERE A.YQ03=B.PY01 AND A.YQ10=B.PY25 AND A.YQ11=B.PY24 ORDER BY YQ12" );
            if ( da.Rows.Count < 1 )
                MessageBox.Show( "没有产品信息" );
            else
            {
                pl.gridControl1.DataSource = da;
                pl.str = "3";
                sele = "2";
                pl.PassDataBetweenForm += new R_Frmpenselect.PassDataBetweenFomrHandler( pl_PassDataBetweenForm );
                pl.StartPosition = FormStartPosition.CenterScreen;
                pl.ShowDialog( );
            }
        }
        private void pl_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( sele == "1" )
            {
                hxp.PQK01 = e.ConOne;
                hxp.PQK02 = e.ConTwo;
                textBox1.Text = e.ConTwo;
                hxp.PQK13 = e.ConEgi;
                textBox2.Text = e.ConEgi;
                hxp.PQK14 = e.ConNin;
                textBox4.Text = e.ConNin;
                hxp.PQK12 = e.ConSev;
                textBox3.Text = e.ConSev;
                hxp.PQK03 = e.ConTre;
                textBox6.Text = e.ConTre;
                hxp.PQK04 = e.ConFor;
                textBox7.Text = e.ConFor;
                if ( !string.IsNullOrEmpty( e.ConFiv ) )
                {
                    hxp.PQK05 = Convert.ToDateTime( e.ConFiv );
                    dateTimePicker1.Value = Convert.ToDateTime( e.ConFiv );
                }
                if ( !string.IsNullOrEmpty( e.ConSix ) )
                {
                    hxp.PQK06 = Convert.ToDateTime( e.ConSix );
                    dateTimePicker2.Value = Convert.ToDateTime( e.ConSix );
                }
                if ( e.ConTen == "执行" )
                    label107.Visible = true;
                else
                    label107.Visible = false;
            }
            else if ( sele == "2" )
            {
                hxp.PQK12 = e.ConOne;
                textBox3.Text = e.ConOne;
                hxp.PQK13 = e.ConTwo;
                textBox2.Text = e.ConTwo;
                hxp.PQK02 = e.ConTre;
                textBox1.Text = e.ConTre;
                hxp.PQK14 = e.ConFor;
                textBox4.Text = e.ConFor;
                hxp.PQK03 = e.ConFiv;
                textBox6.Text = e.ConFiv;
                hxp.PQK04 = e.ConSix;
                textBox7.Text = e.ConSix;
            }
        }
        #endregion

        #region  主体
        //新增
        private void toolAdd_Click ( object sender ,EventArgs e )
        {
            base.add( );

            //Ergodic.FormEvery( this );
            //gridControl1.DataSource = null;
            //Ergodic.FormGroupboxEnableTrue( this ,gb );
            //textBox14.Enabled = false;
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        //删除
        protected override void delete ( )
        {
            base.delete( );

            if ( deleteOf( ) == false )
                return;

            if ( string.IsNullOrEmpty( hxp.PQK01 ) )
                MessageBox.Show( "请查询需要删除的内容" );
            else
            {
                try
                {
                    SqlHelper.ExecuteNonQuery( "DELETE FROM R_REVIEWS WHERE RES01=(SELECT CX01 FROM R_MLLCXMC WHERE CX02=@CX02) AND RES06=@RES06" ,new SqlParameter( "@CX02" ,this.Text ) ,new SqlParameter( "@RES06" ,hxp.PQK01 ) );
                    SqlHelper.ExecuteNonQuery( "UPDATE R_PQI SET YQ118=0,YQ122=0 WHERE YQ99 IN (SELECT YQ99 FROM R_PQI A RIGHT JOIN R_PQK B ON A.YQ03=B.PQK02 AND A.YQ10=B.PQK07 AND A.YQ11=B.PQK11 AND A.YQ12=B.PQK17 WHERE PQK01=@PQK01)" ,new SqlParameter( "@PQK01" ,hxp.PQK01 ) );
                }
                catch { }
                int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQK WHERE PQK01=@PQK01" ,new SqlParameter( "@PQK01" ,hxp.PQK01 ) );
                if ( count < 1 )
                    MessageBox.Show( "删除数据失败" );
                else
                {
                    MessageBox.Show( "成功删除数据" );

                    toolSelect.Enabled = toolAdd.Enabled = true;
                    toolDelete.Enabled = toolUpdate.Enabled = toolSave.Enabled = toolCancel.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled =toolcopy.Enabled= false;
                    Ergodic.FormEvery( this );
                    gridControl1.DataSource = null;
                    Ergodic.FormGroupboxEnableFalse( this ,gb );                    
                }
            }
        }
        bool deleteOf ( )
        {
            result = true;
            if ( bandedGridView1.RowCount > 0 )
            {
                for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                {
                   bool resu = _bll.yesOrNo( hxp.PQK02 ,bandedGridView1.GetDataRow( i )["PQK07"].ToString( ) ,bandedGridView1.GetDataRow( i )["PQK11"].ToString( ) ,bandedGridView1.GetDataRow( i )["PQK17"].ToString( ) );
                    if ( resu == false )
                    {
                        MessageBox.Show( "此单中有记录被339领用,不允许删除" );
                        result = false;
                        break;
                    }
                }
            }

            return result;
        }
        //更改
        protected override void update ( )
        {
            base.update( );

            DataTable del = SqlHelper.ExecuteDataTable( "SELECT * FROM R_REVIEWS A,R_MLLCXMC B WHERE A.RES01=B.CX01 AND RES05='执行' AND RES06=@RES06 AND CX02=@CX02 " ,new SqlParameter( "@RES06" ,hxp.PQK01 ) ,new SqlParameter( "@CX02" ,this.Text ) );
            if ( del != null && del.Rows.Count > 0 )
                MessageBox.Show( "单号:" + hxp.PQK01 + "的单据状态为执行,不允许更改" );
            else
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;

                Ergodic.FormGroupboxEnableTrue( this ,gb );
                textBox14.Enabled = false;
            }
        }
        //送审
        bool result = false, over = false;
        protected override void revirw ( )
        {
            base.revirw( );
            Reviews( "PQK01" ,hxp.PQK01 ,"R_PQK" ,this ,hxp.PQK16 ,"R_285" ,result ,over,MulaolaoBll . Drity . GetDt ( )/*,"AF012" ,"AF072" ,"R_PQAF" ,"AF001" ,cmj.AF001 ,ord ,textBox68.Text ,"R_342"*/);
        }
        //打印
        protected override void print ( )
        {
            base.print( );
        }
        //保存
        protected override void save ( )
        {
            base.save( );

            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;

            Ergodic.FormGroupboxEnableFalse( this ,gb );

            try
            {
                WriteOfReceivablesTo ( );
            }
            catch { }
        }
        bool WriteOfReceivablesTo ( )
        {
            result = false;
            DataTable receiva;
            MulaolaoLibrary . ProductCostSummaryLibrary modelAm = new MulaolaoLibrary . ProductCostSummaryLibrary ( );
            receiva = _bll . GetDataTable ( hxp . PQK01 );
            if ( receiva != null && receiva . Rows . Count > 0 )
            {
                modelAm . AM002 = receiva . Rows [ 0 ] [ "PQK02" ] . ToString ( );
                modelAm . AM173 = 0;
                modelAm . AM173 = string . IsNullOrEmpty ( receiva . Compute ( "SUM(PQK)" , "PQK02='" + modelAm . AM002 + "'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "SUM(PQK)" , "PQK02='" + modelAm . AM002 + "'" ) );
                result = _bll . UpdateOfRecevable ( modelAm , hxp . PQK01 );
            }

            return result;
        }
        //取消
        protected override void cancel ( )
        {
            base.cancel( );

            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;
            Ergodic.FormGroupboxEnableFalse( this ,gb );
        }
        //维护
        protected override void maintain ( )
        {
            base.maintain( );

            DataTable del = SqlHelper.ExecuteDataTable( "SELECT RES03,RES05,RES06,DBA012,CX02 FROM TPADBA A,R_REVIEW B,R_REVIEWS C,R_MLLCXMC D WHERE A.DBA001=B.RE01 AND B.RE01=C.RES03 AND C.RES01=D.CX01 AND RES06=@RES06 AND CX02=@CX02" ,new SqlParameter( "@RES06" ,hxp.PQK01 ) ,new SqlParameter( "@CX02" ,this.Text ) );
            if ( del != null && del.Rows.Count > 0 )
            {
                if ( del.Select( "RES05='执行'" ).Length > 0 )
                {
                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
                    toolSave.Enabled = toolCancel.Enabled = true;
                    Ergodic.FormGroupboxEnableTrue( this ,gb );
                    textBox14.Enabled = true;
                    weihu = "1";
                    label107.Visible = false;
                }else
                    MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
            }else
                MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
        }
        //入库
        protected override void storage ( )
        {
            base.storage( );

            if ( label107.Visible == true )
            {
                if ( string.IsNullOrEmpty( textBox3.Text ) )
                    MessageBox.Show( "产品名称不可为空" );
                else
                {
                    int productNum = 0;
                    decimal everyFine = 0M, surplus = 0M;
                    for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                    {
                        if ( !string.IsNullOrEmpty( /*textBox13.Text*/ bandedGridView1.GetDataRow( i )["PQK18"].ToString( ) ) && Convert.ToDecimal( /*textBox13.Text*/bandedGridView1.GetDataRow( i )["PQK18"].ToString( ) ) > 0 )
                        {
                            if ( !string.IsNullOrEmpty( /*cxb*/ bandedGridView1.GetDataRow( i )["PQK08"].ToString( ) ) && !string.IsNullOrEmpty( /*kxb*/bandedGridView1.GetDataRow( i )["PQK19"].ToString( ) ) && !string.IsNullOrEmpty( /*yqx*/bandedGridView1.GetDataRow( i )["PQK25"].ToString( ) ) && !string.IsNullOrEmpty( /*mtbj*/bandedGridView1.GetDataRow( i )["PQK20"].ToString( ) ) && !string.IsNullOrEmpty( /*mbby*/bandedGridView1.GetDataRow( i )["PQK27"].ToString( ) ) && !string.IsNullOrEmpty( /*mppt*/bandedGridView1.GetDataRow( i )["PQK21"].ToString( ) ) && !string.IsNullOrEmpty( /*mmpt*/bandedGridView1.GetDataRow( i )["PQK22"].ToString( ) ) && !string.IsNullOrEmpty( /*bs*/bandedGridView1.GetDataRow( i )["PQK26"].ToString( ) ) )
                                everyFine = Convert.ToDecimal( /*yqx*/bandedGridView1.GetDataRow( i )["PQK25"].ToString( ) ) * Convert.ToDecimal( /*cxb*/bandedGridView1.GetDataRow( i )["PQK08"].ToString( ) ) * Convert.ToDecimal(/* kxb*/bandedGridView1.GetDataRow( i )["PQK19"].ToString( ) ) * 100 / Convert.ToDecimal( /*bs*/ bandedGridView1.GetDataRow( i )["PQK26"].ToString( ) ) / Convert.ToDecimal( /*mbby*/bandedGridView1.GetDataRow( i )["PQK27"].ToString( ) ) / Convert.ToDecimal( /*mtbj*/bandedGridView1.GetDataRow( i )["PQK20"].ToString( ) ) / Convert.ToDecimal( /*mmpt*/ bandedGridView1.GetDataRow( i )["PQK22"].ToString( ) ) / Convert.ToDecimal( /*mppt */bandedGridView1.GetDataRow( i )["PQK21"].ToString( ) );
                            else
                                everyFine = 0;
                            if ( !string.IsNullOrEmpty( /*textBox7.Text*/bandedGridView1.GetDataRow( i )["PQK09"].ToString( ) ) && !string.IsNullOrEmpty( /*textBox8.Text*/bandedGridView1.GetDataRow( i )["PQK10"].ToString( ) ) )
                                surplus = Convert.ToDecimal( bandedGridView1.GetDataRow( i )["PQK09"].ToString( ) ) - Convert.ToDecimal( /*textBox8.Text*/bandedGridView1.GetDataRow( i )["PQK10"].ToString( ) );
                            else if ( !string.IsNullOrEmpty( /*textBox7.Text*/bandedGridView1.GetDataRow( i )["PQK09"].ToString( ) ) && string.IsNullOrEmpty( /*textBox8.Text*/bandedGridView1.GetDataRow( i )["PQK10"].ToString( ) ) )
                                surplus = Convert.ToDecimal( /*textBox7.Text*/bandedGridView1.GetDataRow( i )["PQK09"].ToString( ) );
                            productNum = Convert.ToInt32( Math.Round( surplus * everyFine ,0 ) );
                            //if ( everyFine == 0 || productNum == 0 )
                            //    MessageBox.Show( "剩余产品数量为0,不能入库" );
                            //else
                            result = fc . Storage ( textBox3 . Text /*产品名称*/,""/*货号*/ ,productNum . ToString ( )/*产品数量*/ ,bandedGridView1 . GetDataRow ( i ) [ "PQK11" ] . ToString ( )/*textBox10.Text*//*物料名称*/ ,bandedGridView1 . GetDataRow ( i ) [ "PQK17" ] . ToString ( )/*textBox11.Text*/ /*规格*/,"" /*单位*/,everyFine . ToString ( ) /*每套用量*/,"" /*每套成本*/,yqx /*单价*/,surplus . ToString ( ) /*计划采购数量*/,""/*开合同人*/ ,MulaolaoBll . Drity . GetDt ( ) ,"" ,MulaolaoBll . Drity . GetDt ( ) ,hxp . PQK01 ,bandedGridView1 . GetDataRow ( i ) [ "PQK39" ] . ToString ( )/*上次入库数量*/,bandedGridView1 . GetDataRow ( i ) [ "PQK40" ] . ToString ( )/*上次入库采购数量*/ ,string . Empty ,string . Empty ,string . Empty );
                            if ( result == false )
                            {
                                MessageBox.Show( "入库失败" );
                                break;
                            }
                            else
                            {
                                try
                                {
                                    hxp.IDX = string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetDataRow( i )["idx"].ToString( ) );
                                    hxp.PQK39 = productNum;
                                    hxp.PQK40 = surplus;
                                    SqlHelper.ExecuteNonQuery( "UPDATE R_PQK SET PQK39=@PQK39,PQK40=@PQK40 WHERE idx=@idx" ,new SqlParameter( "@idx" ,hxp.IDX ) ,new SqlParameter( "@PQK39" ,hxp.PQK39 ) ,new SqlParameter( "@PQK40" ,hxp.PQK40 ) );
                                    if ( i == bandedGridView1.RowCount - 1 )
                                        MessageBox.Show( "已入库" );
                                }
                                catch { }
                            }
                        }
                        else if ( !string.IsNullOrEmpty( /*textBox15.Text*/bandedGridView1.GetDataRow( i )["PQK32"].ToString( ) ) && Convert.ToDecimal( /*textBox15.Text*/bandedGridView1.GetDataRow( i )["PQK32"].ToString( ) ) > 0 )
                        {
                            if ( !string.IsNullOrEmpty( /*cxb*/bandedGridView1.GetDataRow( i )["PQK08"].ToString( ) ) && !string.IsNullOrEmpty( /*kxb*/bandedGridView1.GetDataRow( i )["PQK19"].ToString( ) ) && !string.IsNullOrEmpty( /*yqx*/bandedGridView1.GetDataRow( i )["PQK25"].ToString( ) ) && !string.IsNullOrEmpty( /*mtbj*/bandedGridView1.GetDataRow( i )["PQK20"].ToString( ) ) && !string.IsNullOrEmpty( /*mbby*/bandedGridView1.GetDataRow( i )["PQK27"].ToString( ) ) && !string.IsNullOrEmpty( /*pm*/bandedGridView1.GetDataRow( i )["PQK28"].ToString( ) ) )
                                everyFine = Convert.ToDecimal( /*yqx*/bandedGridView1.GetDataRow( i )["PQK25"].ToString( ) ) * 100 * 10000 / Convert.ToDecimal( /*mtbj*/bandedGridView1.GetDataRow( i )["PQK20"].ToString( ) ) / Convert.ToDecimal( /*cxb*/bandedGridView1.GetDataRow( i )["PQK08"].ToString( ) ) / Convert.ToDecimal( /*kxb*/ bandedGridView1.GetDataRow( i )["PQK19"].ToString( ) ) / Convert.ToDecimal( /*mbby*/ bandedGridView1.GetDataRow( i )["PQK27"].ToString( ) ) / Convert.ToDecimal( /*pm*/ bandedGridView1.GetDataRow( i )["PQK28"].ToString( ) );
                            else
                                everyFine = 0;
                            if ( !string.IsNullOrEmpty( /*textBox7.Text*/bandedGridView1.GetDataRow( i )["PQK09"].ToString( ) ) && !string.IsNullOrEmpty( /*textBox12.Text*/bandedGridView1.GetDataRow( i )["PQK31"].ToString( ) ) )
                                surplus = Convert.ToDecimal( /*textBox7.Text*/bandedGridView1.GetDataRow( i )["PQK09"].ToString( ) ) - Convert.ToDecimal( /*textBox12.Text*/bandedGridView1.GetDataRow( i )["PQK31"].ToString( ) );
                            else if ( !string.IsNullOrEmpty( /*textBox7.Text*/bandedGridView1.GetDataRow( i )["PQK09"].ToString( ) ) && string.IsNullOrEmpty( /*textBox12.Text*/bandedGridView1.GetDataRow( i )["PQK31"].ToString( ) ) )
                                surplus = Convert.ToDecimal( /*textBox7.Text*/bandedGridView1.GetDataRow( i )["PQK09"].ToString( ) );
                            productNum = Convert.ToInt32( Math.Round( surplus * everyFine ,0 ) );
                            //if ( everyFine == 0 || productNum == 0 )
                            //    MessageBox.Show( "剩余产品数量为0,不能入库" );
                            //else
                            result = fc . Storage ( textBox3 . Text /*产品名称*/,""/*货号*/ ,productNum . ToString ( )/*产品数量*/ ,bandedGridView1 . GetDataRow ( i ) [ "PQK11" ] . ToString ( )/*textBox10.Text*//*物料名称*/ ,bandedGridView1 . GetDataRow ( i ) [ "PQK17" ] . ToString ( )/*textBox11.Text*/ /*规格*/,"" /*单位*/,everyFine . ToString ( ) /*每套用量*/,"" /*每套成本*/,yqx /*单价*/,surplus . ToString ( ) /*计划采购数量*/,""/*开合同人*/ ,MulaolaoBll . Drity . GetDt ( ) ,"" ,MulaolaoBll . Drity . GetDt ( ) ,hxp . PQK01 ,bandedGridView1 . GetDataRow ( i ) [ "PQK39" ] . ToString ( )/*上次入库数量*/,bandedGridView1 . GetDataRow ( i ) [ "PQK40" ] . ToString ( )/*上次入库采购数量*/,string . Empty ,string . Empty ,string . Empty );
                            if ( result == false )
                            {
                                MessageBox.Show( "入库失败" );
                                break;
                            }
                            else if ( i == bandedGridView1.RowCount - 1 )
                            {
                                MessageBox.Show( "已成功" );
                                try
                                {
                                    try
                                    {
                                        hxp.IDX = string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetDataRow( i )["idx"].ToString( ) );
                                        hxp.PQK39 = productNum;
                                        hxp.PQK40 = surplus;
                                        SqlHelper.ExecuteNonQuery( "UPDATE R_PQK SET PQK39=@PQK39,PQK40=@PQK40 WHERE idx=@idx" ,new SqlParameter( "@idx" ,hxp.IDX ) ,new SqlParameter( "@PQK39" ,hxp.PQK39 ) ,new SqlParameter( "@PQK40" ,hxp.PQK40 ) );
                                        if ( i == bandedGridView1.RowCount - 1 )
                                            MessageBox.Show( "已入库" );
                                    }
                                    catch { }
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show( "非执行单据不能入库" );
        }
        #endregion

        #region 表格
        //删除
        void variable ( )
        {
            hxp.PQK02 = textBox1.Text;
            hxp.PQK07 = textBox16.Text;
            hxp.PQK11 = textBox10.Text;
            hxp.PQK17 = textBox11.Text;
            if ( !string.IsNullOrEmpty( textBox7.Text ) )
                hxp.PQK09 = Convert.ToDecimal( textBox7.Text );
            else
                hxp.PQK09 = 0;
            if ( !string.IsNullOrEmpty( textBox8.Text ) )
                hxp.PQK10 = Convert.ToDecimal( textBox8.Text );
            else
                hxp.PQK10 = 0;
            if ( !string.IsNullOrEmpty( textBox13.Text ) )
                hxp.PQK18 = Convert.ToDecimal( textBox13.Text );
            else
                hxp.PQK18 = 0;
            if ( !string.IsNullOrEmpty( textBox12.Text ) )
                hxp.PQK31 = Convert.ToDecimal( textBox12.Text );
            else
                hxp.PQK31 = 0;
            if ( !string.IsNullOrEmpty( textBox15.Text ) )
                hxp.PQK32 = Convert.ToDecimal( textBox15.Text );
            else
                hxp.PQK32 = 0;
            if ( !string.IsNullOrEmpty( textBox5.Text ) )
                hxp.PQK29 = Convert.ToInt32( textBox5.Text );
            else
                hxp.PQK29 = 0;
            if ( !string.IsNullOrEmpty( textBox17.Text ) )
                hxp.PQK37 = Convert.ToDecimal( textBox17.Text );
            else
                hxp.PQK37 = 0;
            hxp.PQK38 = dateTimePicker3.Value;
        }
        private void button7_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==
   DialogResult . Cancel )
                return;

            if ( string.IsNullOrEmpty( textBox10.Text ) )
                MessageBox.Show( "工序不可为空" );
            else
            {
                if ( string.IsNullOrEmpty( textBox11.Text ) )
                    MessageBox.Show( "色号不可为空" );
                else
                {
                    variable( );//PQK01=@PQK01 AND PQK07=@PQK07 AND PQK11=@PQK11 AND PQK17=@PQK17
                    int count = SqlHelper . ExecuteNonQuery ( "DELETE FROM R_PQK WHERE idx=@idx" /*,new SqlParameter( "@PQK01" ,hxp.PQK01 ) ,new SqlParameter( "@PQK07" ,hxp.PQK07 ) ,new SqlParameter( "@PQK11" ,hxp.PQK11 ) ,new SqlParameter( "@PQK17" ,hxp.PQK17 )*/,new SqlParameter ( "@idx" ,hxp . IDX ) );
                    if ( count < 1 )
                        MessageBox.Show( "删除数据失败" );
                    else
                    {
                        MessageBox.Show( "成功删除数据" );
                        int num = bandedGridView1.FocusedRowHandle;
                        dg.Rows.RemoveAt( num );
                        try
                        {
                            SqlHelper.ExecuteNonQuery( "UPDATE R_PQI SET YQ118=0,YQ122=0 WHERE YQ03=@PQK02 AND YQ10=@PQK07 AND YQ11=@PQK11 AND YQ12=@PQK17 AND YQ99=@PQK30" ,new SqlParameter( "@PQK02" ,hxp.PQK02 ) ,new SqlParameter( "@PQK07" ,hxp.PQK07 ) ,new SqlParameter( "@PQK11" ,hxp.PQK11 ) ,new SqlParameter( "@PQK17" ,hxp.PQK17 ) ,new SqlParameter ( "@PQK30" ,hxp . PQK30 ) );
                        }
                        catch { }
                    }
                }
            }
        }
        //编辑
        private void button6_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox10.Text ) )
                MessageBox.Show( "工序不可为空" );
            else
            {
                if ( string.IsNullOrEmpty( textBox11.Text ) )
                    MessageBox.Show( "色号不可为空" );
                else
                {
                    variable( );//PQK01=@PQK01 AND PQK07=@PQK07 AND PQK11=@PQK11 AND PQK17=@PQK17
                    int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQK SET PQK09=@PQK09,PQK10=@PQK10,PQK18=@PQK18,PQK32=@PQK32,PQK31=@PQK31,PQK29=@PQK29,PQK37=@PQK37,PQK38=@PQK38 WHERE idx=@idx" /*,new SqlParameter( "@PQK01" ,hxp.PQK01 ) *//*,new SqlParameter( "@PQK07" ,hxp.PQK07 )*/ /*,new SqlParameter( "@PQK11" ,hxp.PQK11 )*/ /*,new SqlParameter( "@PQK17" ,hxp.PQK17 )*/ ,new SqlParameter( "@PQK09" ,hxp.PQK09 ) ,new SqlParameter( "@PQK10" ,hxp.PQK10 ) ,new SqlParameter( "@PQK18" ,hxp.PQK18 ) ,new SqlParameter( "@PQK31" ,hxp.PQK31 ) ,new SqlParameter( "@PQK32" ,hxp.PQK32 ) ,new SqlParameter( "@PQK29" ,hxp.PQK29 ) ,new SqlParameter( "@PQK37" ,hxp.PQK37 ) ,new SqlParameter( "@PQK38" ,hxp.PQK38 ) ,new SqlParameter ( "@idx" ,hxp . IDX ) );
                    if ( count < 1 )
                        MessageBox.Show( "编辑数据失败" );
                    else
                    {
                        MessageBox.Show( "成功编辑数据" );
                        int num = bandedGridView1.FocusedRowHandle;
                        DataRow row = dg.Rows[num];
                        row.BeginEdit( );
                        row["PQK07"] = hxp.PQK07;
                        row["PQK09"] = hxp.PQK09;
                        row["PQK10"] = hxp.PQK10;
                        row["PQK18"] = hxp.PQK18;
                        row["PQK31"] = hxp.PQK31;
                        row["PQK32"] = hxp.PQK32;
                        row["PQK29"] = hxp.PQK29;
                        row["PQK37"] = hxp.PQK37;
                        row["PQK38"] = hxp.PQK38;
                        row.EndEdit( );
                    }
                }
            }
        }
        //刷新
        private void button2_Click ( object sender ,EventArgs e )
        {
            dg = SqlHelper.ExecuteDataTable( "SELECT idx,PQK07,PQK18,PQK32,PQK16,PQK11,PQK17,PQK08,PQK19,PQK20,PQK21,PQK22,PQK23,PQK24,PQK25,PQK26,PQK27,PQK28,PQK09,PQK37,PQK10,PQK31,PQK29,PQK30,PQK38 FROM R_PQK WHERE PQK01 = @PQK01" ,new SqlParameter( "@PQK01" ,hxp.PQK01 ) );
            gridControl1.DataSource = dg;
        }
        #endregion

        #region  事件
        //每板实际摆放个数
        private void textBox5_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //实入库量(kg)
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
            if ( textBox7.Text != "" && !DateDayRegise.sevenOne( textBox7 ) )
            {
                this.textBox7.Text = "";
                MessageBox.Show( "只允许输入整数部分最多六位,小数部分最多一位,如999999.9,请重新输入" );
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
            if ( textBox17.Text != "" && !DateDayRegise.sevenOne( textBox17 ) )
            {
                this.textBox17.Text = "";
                MessageBox.Show( "只允许输入整数部分最多六位,小数部分最多一位,如999999.9,请重新输入" );
            }
        }
        //板实领漆量(kg)
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
            if ( textBox8.Text != "" && !DateDayRegise.sevenOne( textBox8 ) )
            {
                this.textBox8.Text = "";
                MessageBox.Show( "只允许输入整数部分最多六位,小数部分最多一位,如999999.9,请重新输入" );
            }
        }
        //平米实领漆量(kg)
        private void textBox12_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox8 );
        }
        private void textBox12_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox8 );
        }
        private void textBox12_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox12.Text != "" && !DateDayRegise.sevenOne( textBox12 ) )
            {
                this.textBox12.Text = "";
                MessageBox.Show( "只允许输入整数部分最多六位,小数部分最多一位,如999999.9,请重新输入" );
            }
        }
        //定板算采购漆量
        private void textBox13_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox8 );
        }
        private void textBox13_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox8 );
        }
        private void textBox13_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox13.Text != "" && !DateDayRegise.sevenOne( textBox13 ) )
            {
                this.textBox13.Text = "";
                MessageBox.Show( "只允许输入整数部分最多六位,小数部分最多一位,如999999.9,请重新输入" );
            }
        }
        //定平米算采购漆量
        private void textBox15_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox8 );
        }
        private void textBox15_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox8 );
        }
        private void textBox15_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox15.Text != "" && !DateDayRegise.sevenOne( textBox15 ) )
            {
                this.textBox15.Text = "";
                MessageBox.Show( "只允许输入整数部分最多六位,小数部分最多一位,如999999.9,请重新输入" );
            }
        }
        private void textBox16_TextChanged ( object sender ,EventArgs e )
        {
            
        }
        void yesOrNo ( )
        {
            if ( toolSave.Enabled == true )
            {
                result = _bll.yesOrNo( textBox1.Text ,textBox16.Text ,textBox10.Text ,textBox11.Text );
                if ( result == false )
                    textBox8.Enabled = textBox12.Enabled = button7.Enabled = false;
                else
                    textBox8.Enabled = textBox12.Enabled = button7.Enabled = true;
            }
        }
        //表
        string cxb = "", kxb = "", yqx = "", mtbj = "", mbby = "", mppt = "", mmpt = "", bs = "", pm = "";
        private void bandedGridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            int num = bandedGridView1.FocusedRowHandle;
            if ( num >= 0 && num <= bandedGridView1.RowCount - 1 )
            {
                hxp . IDX = string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( num ) [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( bandedGridView1 . GetDataRow ( num ) [ "idx" ] . ToString ( ) );
                hxp.PQK30 = bandedGridView1 . GetDataRow ( num ) [ "PQK30" ] . ToString ( );
                textBox10 .Text = bandedGridView1.GetDataRow( num )["PQK11"].ToString( );
                textBox11.Text = bandedGridView1.GetDataRow( num )["PQK17"].ToString( );
                textBox7.Text = bandedGridView1.GetDataRow( num )["PQK09"].ToString( );
                textBox8.Text = bandedGridView1.GetDataRow( num )["PQK10"].ToString( );
                textBox12.Text = bandedGridView1.GetDataRow( num )["PQK31"].ToString( );
                textBox13.Text = bandedGridView1.GetDataRow( num )["PQK18"].ToString( );
                textBox15.Text = bandedGridView1.GetDataRow( num )["PQK32"].ToString( );
                textBox16.Text = bandedGridView1.GetDataRow( num )["PQK07"].ToString( );
                textBox5.Text = bandedGridView1.GetDataRow( num )["PQK29"].ToString( );
                textBox17.Text = bandedGridView1.GetDataRow( num )["PQK37"].ToString( );
                cxb = bandedGridView1.GetDataRow( num )["PQK08"].ToString( );
                kxb = bandedGridView1.GetDataRow( num )["PQK19"].ToString( );
                yqx = bandedGridView1.GetDataRow( num )["PQK25"].ToString( );
                mtbj = bandedGridView1.GetDataRow( num )["PQK20"].ToString( );
                mppt = bandedGridView1.GetDataRow( num )["PQK21"].ToString( );
                mmpt = bandedGridView1.GetDataRow( num )["PQK22"].ToString( );
                mbby = bandedGridView1.GetDataRow( num )["PQK27"].ToString( );
                bs = bandedGridView1.GetDataRow( num )["PQK26"].ToString( );
                pm = bandedGridView1.GetDataRow( num )["PQK28"].ToString( );
                yesOrNo( );
            }
        }
        private void textBox1_TextChanged ( object sender ,EventArgs e )
        {
            if ( !string . IsNullOrEmpty ( textBox1 . Text ) )
                btnOver . Enabled = true;
        }
        private void btnOver_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( textBox1 . Text ) )
            {
                MessageBox . Show ( "请选择流水号" );
                return;
            }
            result = _bll . UpdateOver ( textBox1 . Text );
            if ( result==false )
                MessageBox . Show ( "失败,请重试" );
        }
        #endregion
    }
}

/*
板算
Convert.ToDecimal( yqx ) * Convert.ToDecimal( cxb ) * Convert.ToDecimal( kxb ) * 100 / Convert.ToDecimal( bs ) / Convert.ToDecimal( mbby ) / Convert.ToDecimal( mtbj ) / Convert.ToDecimal( mmpt ) / Convert.ToDecimal( mppt )
PQK25*PQK08*PQK19*100/PQK26/PQK27/PQK20/PQK22/PQK21
平方算
Convert.ToDecimal( yqx ) * 100 * 10000 / Convert.ToDecimal( mtbj ) / Convert.ToDecimal( cxb ) / Convert.ToDecimal( kxb ) / Convert.ToDecimal( mbby ) / Convert.ToDecimal( pm )
PQK25*100*10000/PQK20/PQK08/PQK19/PQK27/PQK28
*/
