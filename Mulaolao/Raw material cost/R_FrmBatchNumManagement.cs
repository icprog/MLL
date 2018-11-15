using Mulaolao.Class;
using Mulaolao.Other;
using StudentMgr;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Mulaolao.Raw_material_cost
{
    public partial class R_FrmBatchNumManagement : FormChild
    {
        public R_FrmBatchNumManagement ( Form1 fm )
        {
            this.MdiParent = fm;
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.BatchNumManagementLibrary bn = new MulaolaoLibrary.BatchNumManagementLibrary( );
        R_Frm525 frm = new R_Frm525( );
        DataTable tableOne, tableTwo;
        string queryElse = "", seleOrBuild = "", weihu = "";
        int count = 0;
        bool result = false;

        private void R_FrmBatchNumManagement_Load ( object sender ,EventArgs e )
        {
            Ergodic.FormEverySpli( this );
            gridControl1.DataSource = null;
            Ergodic.FormEverySpliEnableFalse( this );
            label107.Visible = false;
            toolcopy . Visible = false;
        }

        #region Event
        private void textBox4_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox4 );
        }
        private void textBox4_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox4 );
        }
        private void textBox4_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox4.Text != "" && !DateDayRegise.fiveForNum( textBox4 ) )
            {
                this.textBox4.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多一位,如9999.9,请重新输入" );
            }
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
            if ( textBox5.Text != "" && !DateDayRegise.fiveForNum( textBox5 ) )
            {
                this.textBox5.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多一位,如9999.9,请重新输入" );
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
            if ( textBox9.Text != "" && !DateDayRegise.tenForNumber( textBox9 ) )
            {
                this.textBox9.Text = "";
                MessageBox.Show( "只允许输入整数部分最多六位,小数部分最多四位,如999999.9999,请重新输入" );
            }
        }
        private void textBox6_LostFocus ( object sender ,EventArgs e )
        {

        }
        private void button6_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox1.Text ) )
                MessageBox.Show( "流水号不可为空" );
            else
            {
                if ( string.IsNullOrEmpty( textBox8.Text ) )
                    MessageBox.Show( "零件名称不可为空" );
                else
                {
                    if ( string.IsNullOrEmpty( textBox2.Text ) )
                        MessageBox.Show( "工序不可为空" );
                    else
                    {
                        if ( string.IsNullOrEmpty( textBox3.Text ) )
                            MessageBox.Show( "色号不可为空" );
                        else
                        {
                            if ( string.IsNullOrEmpty( textBox6.Text ) )
                                MessageBox.Show( "供方批号不可为空" );
                            else
                            {
                                //bn.AI002 = textBox1.Text;
                                //bn.AI003 = textBox2.Text;
                                //bn.AI004 = textBox3.Text;
                                //bn.AI005 = textBox6.Text;
                                //AI001=@AI001 AND AI002=@AI002 AND ,new SqlParameter( "@AI001" ,bn.AI001 ) ,new SqlParameter( "@AI002" ,bn.AI002 ) ,new SqlParameter( "@AI003" ,bn.AI003 ) ,new SqlParameter( "@AI004" ,bn.AI004 )  WHERE AI003=@AI003 AND AI004=@AI004  AI005,
                                DataTable dil = SqlHelper.ExecuteDataTable( "SELECT AI006,AI005 FROM R_PQAI" );
                                if ( dil.Rows.Count < 1 )
                                    textBox7.Text = "CK" + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "001";
                                else
                                {
                                    if ( dil.Select( "AI005='" + textBox6.Text + "'" ).Length > 0 )
                                        textBox7.Text = dil.Select( "AI005='" + textBox6.Text + "'" )[0]["AI006"].ToString( );
                                    else
                                    {
                                        String str = "CK" + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "001";
                                        if ( dil.Select( "AI006='" + str + "'" ).Length > 0 )
                                            textBox7.Text = "CK" + ( Convert.ToInt64( dil.AsEnumerable( ).Select( t => t.Field<string>( "AI006" ) ).Max( ).Substring( 2 ,dil.AsEnumerable( ).Select( t => t.Field<string>( "AI006" ) ).Max( ).Length - 2 ) ) + 1 ).ToString( );
                                        else
                                            textBox7.Text = str;
                                    }
                                    //AI006='" + textBox7.Text + "' AND  && c.Field<string>( "AI006" ) == textBox7.Text  AI005='" + textBox6.Text + "' AND   c.Field<string>( "AI005" ) == textBox6.Text &&
                                    //if ( dil.Select( "AI005 ='" + textBox6.Text + "'" ).Length > 0 )
                                    //    textBox7.Text = dil.Select( "AI005 ='" + textBox6.Text + "'" )[0]["AI006"].ToString( );
                                    ////var query = dil.AsEnumerable( ).Select( t => t.Field<string>( "AI006" ) ).Max( );
                                    //else
                                    //{
                                    //    if ( dil.Select( "AI002='" + textBox1.Text + "'" ).Length > 0 )
                                    //    {
                                    //        var query = from c in dil.AsEnumerable( )
                                    //                    where c.Field<string>( "AI002" ) == textBox1.Text
                                    //                    select c;
                                    //        string maxAI = query.Max( r => r.Field<string>( "AI006" ) );
                                    //        textBox7.Text = "CK" + ( Convert.ToInt64( maxAI.Substring( 2 ,maxAI.Length - 2 ) ) + 1 ).ToString( );
                                    //    }
                                    //    else
                                    //        textBox7.Text = "CK" + bn.AI002 + "001";
                                    //} 
                                }
                            }
                        }
                    }
                }
            }
        }
        string ai2 = "", ai3 = "", ai4 = "", ai11 = "";
        private void gridView1_Click ( object sender ,EventArgs e )
        {
            if ( gridView1.RowCount == 1 )
            {
                textBox1.Text = gridView1.GetFocusedRowCellValue( "AI002" ).ToString( );
                textBox2.Text = gridView1.GetFocusedRowCellValue( "AI003" ).ToString( );
                textBox3.Text = gridView1.GetFocusedRowCellValue( "AI004" ).ToString( );
                textBox6.Text = gridView1.GetFocusedRowCellValue( "AI005" ).ToString( );
                textBox7.Text = gridView1.GetFocusedRowCellValue( "AI006" ).ToString( );
                textBox4.Text = gridView1.GetFocusedRowCellValue( "AI007" ).ToString( );
                textBox5.Text = gridView1.GetFocusedRowCellValue( "AI008" ).ToString( );
                textBox9.Text = gridView1.GetFocusedRowCellValue( "AI009" ).ToString( );
                textBox8.Text = gridView1.GetFocusedRowCellValue( "AI011" ).ToString( );
                textBox10.Text = gridView1.GetFocusedRowCellValue( "AI012" ).ToString( );
                bn.AI010 = gridView1.GetFocusedRowCellValue( "AI010" ).ToString( );
                bn.AI013 = gridView1.GetFocusedRowCellValue( "AI013" ).ToString( );
                bn . IDX = string . IsNullOrEmpty ( gridView1 . GetFocusedRowCellValue ( "IDX" ) . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView1 . GetFocusedRowCellValue ( "IDX" ) . ToString ( ) );
                ai2 = textBox1.Text;
                ai3 = textBox2.Text;
                ai4 = textBox3.Text;
                ai11 = textBox8.Text;
            }
        }
        private void gridView1_FocusedRowChanged ( object sender ,DevExpress . XtraGrid . Views . Base . FocusedRowChangedEventArgs e )
        {
            if ( gridView1 . FocusedRowHandle >= 0 && gridView1 . FocusedRowHandle <= gridView1 . DataRowCount - 1 )
            {
                textBox1 . Text = gridView1 . GetFocusedRowCellValue ( "AI002" ) . ToString ( );
                textBox2 . Text = gridView1 . GetFocusedRowCellValue ( "AI003" ) . ToString ( );
                textBox3 . Text = gridView1 . GetFocusedRowCellValue ( "AI004" ) . ToString ( );
                textBox6 . Text = gridView1 . GetFocusedRowCellValue ( "AI005" ) . ToString ( );
                textBox7 . Text = gridView1 . GetFocusedRowCellValue ( "AI006" ) . ToString ( );
                textBox4 . Text = gridView1 . GetFocusedRowCellValue ( "AI007" ) . ToString ( );
                textBox5 . Text = gridView1 . GetFocusedRowCellValue ( "AI008" ) . ToString ( );
                textBox9 . Text = gridView1 . GetFocusedRowCellValue ( "AI009" ) . ToString ( );
                textBox8 . Text = gridView1 . GetFocusedRowCellValue ( "AI011" ) . ToString ( );
                textBox10 . Text = gridView1 . GetFocusedRowCellValue ( "AI012" ) . ToString ( );
                bn . AI010 = gridView1 . GetFocusedRowCellValue ( "AI010" ) . ToString ( );
                bn . AI013 = gridView1 . GetFocusedRowCellValue ( "AI013" ) . ToString ( );
                bn . IDX = string . IsNullOrEmpty ( gridView1 . GetFocusedRowCellValue ( "IDX" ) . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView1 . GetFocusedRowCellValue ( "IDX" ) . ToString ( ) );
                bn . AI014 = gridView1 . GetFocusedRowCellValue ( "AI014" ) . ToString ( );
                textBox1 . Tag = gridView1 . GetFocusedRowCellValue ( "AI014" ) . ToString ( );
                ai2 = textBox1 . Text;
                ai3 = textBox2 . Text;
                ai4 = textBox3 . Text;
                ai11 = textBox8 . Text;
            }
        }
        #endregion

        #region Query
        //Check the serial numbert
        private void button1_Click ( object sender ,EventArgs e )
        {
            //DataTable da = SqlHelper.ExecuteDataTable( "SELECT PQK02,PQK07,PQK11,PQK17,PQK09-(SELECT ISNULL(SUM(AI007),0) AI007 FROM R_PQAI WHERE AI002=PQK02 AND AI003=PQK11 AND AI004=PQK17 AND AI011=PQK07) PQK09,PQK35,PQK36,CASE WHEN PQK26='0' THEN 0 WHEN PQK27='0' THEN 0 WHEN PQK20='0' THEN 0 WHEN PQK21='0' THEN 0 WHEN PQK22='0' THEN 0 WHEN PQK26!=0 AND PQK27!='0' AND PQK20!='0' AND PQK21!='0' AND PQK22!='0' THEN CONVERT(DECIMAL(10,4),PQK25*PQK08*PQK19*100/PQK26/PQK27/PQK20/PQK22/PQK21) END BS,CASE WHEN PQK20='0' THEN 0 WHEN PQK08='0' THEN 0 WHEN PQK19='0' THEN 0 WHEN PQK27='0' THEN 0 WHEN PQK28='0' THEN 0 WHEN PQK20!='0' AND PQK08!='0' AND PQK19!='0' AND PQK27!='0' AND PQK28!='0' THEN CONVERT(DECIMAL(10,4),PQK25*100*10000/PQK20/PQK08/PQK19/PQK27/PQK28) END PFS FROM R_PQK ORDER BY PQK02 DESC" );
            DataTable da = SqlHelper.ExecuteDataTable( "WITH CET AS (SELECT PQK30,PQK02,(SELECT PQF02 FROM R_PQF WHERE PQK02=PQF01) AI012,(SELECT PQF04 FROM R_PQF WHERE PQK02=PQF01) PQF04,PQK07,PQK11,PQK17,PQK35,PQK36,PQK09-(SELECT ISNULL(SUM(AI007),0) AI007 FROM R_PQAI WHERE AI002=PQK02 AND AI003=PQK11 AND AI004=PQK17 AND AI011=PQK07 AND AI014=PQK30) PQK09,PQK37-(SELECT ISNULL(SUM(AI007),0) AI007 FROM R_PQAI WHERE AI002=PQK02 AND AI003=PQK11 AND AI004=PQK17 AND AI011=PQK07 AND AI014=PQK30) PQK37,CASE WHEN PQK23='0' THEN 0 WHEN PQK18='0' THEN 0 WHEN PQK23!='0' AND PQK18!='0' THEN CONVERT(DECIMAL(10,4),PQK23/PQK18) END BS,CASE WHEN PQK23='0' THEN 0 WHEN PQK32='0' THEN 0 WHEN PQK23!='0' AND PQK32!='0' THEN CONVERT(DECIMAL(10,4),PQK23/PQK32) END PFS FROM R_PQK) SELECT * FROM CET WHERE PQK09>0 OR PQK37>0 ORDER BY PQK02 DESC" );
            if ( da.Rows.Count > 0 )
            {
                queryElse = "1";
                frm.gridControl1.DataSource = da;
                frm.Text = "R_525 信息查询";
                frm.sign = "1";
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.PassDataBetweenForm += new R_Frm525.PassDataBetweenFormHandler( frm_PassDataBetweenForm );
                frm.ShowDialog( );
            }
            else
                MessageBox.Show( "R_285没有数据" );
        }
        private void frm_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( queryElse == "1" )
            {
                bn.AI002 = e.ConOne;
                textBox1.Text = e.ConOne;
                bn.AI003 = e.ConTwo;
                textBox2.Text = e.ConTwo;
                bn.AI004 = e.ConTre;
                textBox3.Text = e.ConTre;

                if ( !string . IsNullOrEmpty ( e . ConFor ) && Convert . ToDecimal ( e . ConFor ) > 0 )
                {
                    bn . AI007 = Convert . ToDecimal ( e . ConFor );
                    textBox4 . Text = e . ConFor;
                }
                else if ( !string . IsNullOrEmpty ( e . ConTen ) && Convert . ToDecimal ( e . ConTen ) > 0 )
                {
                    bn . AI007 = Convert . ToDecimal ( e . ConTen );
                    textBox4 . Text = e . ConTen;
                }
                if ( !string.IsNullOrEmpty( e.ConFiv ) && Convert.ToDecimal( e.ConFiv ) > 0 )
                {
                    bn.AI009 = Convert.ToDecimal( e.ConFiv );
                    bn.AI010 = "T";
                    textBox9.Text = e.ConFiv;
                }
                else if ( !string.IsNullOrEmpty( e.ConSix ) && Convert.ToDecimal( e.ConSix ) > 0 )
                {
                    bn.AI009 = Convert.ToDecimal( e.ConSix );
                    bn.AI010 = "F";
                    textBox9.Text = e.ConSix;
                }
                bn.AI005 = e.ConSev;
                textBox6.Text = e.ConSev;
                bn.AI006 = e.ConEgi;
                textBox7.Text = e.ConEgi;
                bn.AI011 = e.ConNin;
                textBox8.Text = e.ConNin;
                bn.AI012 = e.ConEleven;
                textBox10.Text = e.ConEleven;
                bn . AI014 = e . ConTwelve;
                textBox1 . Tag = e . ConTwelve;
            }
            else if ( queryElse == "2" )
            {
                bn.AI001 = e.ConOne;
                bn.AI002 = e.ConTwo;
                textBox1.Text = e.ConTwo;
                bn.AI003 = e.ConTre;
                textBox2.Text = e.ConTre;
                bn.AI004 = e.ConFor;
                textBox3.Text = e.ConFor;
                if ( e.ConFiv == "执行" )
                    label107.Visible = true;
                else
                    label107.Visible = false;
                bn.AI011 = e.ConSix;
                textBox8.Text = e.ConSix;
                bn.AI012 = e.ConSev;
                textBox10.Text = e.ConSev;
            }
        }
        protected override void select ( )
        {
            base.select( );

            DataTable de = SqlHelper.ExecuteDataTable( "SELECT AI001,AI012,AI011 PQK07,AI002 PQK02,AI003 PQK11,AI004 PQK17,(SELECT RES05 FROM R_REVIEWS WHERE RES04=(SELECT MAX(RES04) FROM R_REVIEWS WHERE RES06=AI001)) RES05 FROM R_PQAI" );
            if ( de.Rows.Count > 0 )
            {
                queryElse = "2";
                frm.gridControl1.DataSource = de;
                frm.Text = "R_525 信息查询";
                frm.sign = "2";
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.PassDataBetweenForm += new R_Frm525.PassDataBetweenFormHandler( frm_PassDataBetweenForm );
                frm.ShowDialog( );

                if ( !string.IsNullOrEmpty( bn.AI001 ) )
                {
                    seleOrBuild = "1";
                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolcopy.Enabled = true;
                    toolSave.Enabled = toolCancel.Enabled = false;
                    Ergodic.FormEverySpliEnableFalse( this );
                    tableOne = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQAI WHERE AI001=@AI001" ,new SqlParameter( "@AI001" ,bn.AI001 ) );
                    gridControl1.DataSource = tableOne;
                }
            }
            else
                MessageBox.Show( "无数据" );
        }
        #endregion

        #region Main
        protected override void add ( )
        {
            base.add( );
            Ergodic.FormEverySpli( this );
            gridControl1.DataSource = null;
            Ergodic.FormEverySpliEnableTrue( this );
            label107.Visible = false;
            seleOrBuild = "2";
            bn.AI001 = oddNumbers.purchaseContract( "SELECT MAX(AI001) AI001 FROM R_PQAI" ,"AI001" ,"R_525-" );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void delete ( )
        {
            base.delete( );

            if ( deleteOf( ) == true )
            {
                MessageBox.Show( "本单据中有记录被339领用,不允许删除" );
                return;
            }
            DataTable del = SqlHelper.ExecuteDataTable( "SELECT * FROM R_REVIEWS A,R_MLLCXMC B WHERE A.RES01=B.CX01 AND RES05='执行' AND RES06=@RES06 AND CX02=@CX02 " ,new SqlParameter( "@RES06" ,bn.AI001 ) ,new SqlParameter( "@CX02" ,this.Text ) );
            if ( del != null && del.Rows.Count > 0 )
                MessageBox.Show( "单号:" + bn.AI001 + "的单据状态为执行,不允许删除" );
            {
                count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQAI WHERE AI001=@AI001" ,new SqlParameter( "@AI001" ,bn.AI001 ) );
                if ( count < 1 )
                    MessageBox.Show( "删除失败" );
                else
                {
                    MessageBox.Show( "成功删除数据" );
                    Ergodic.FormEverySpli( this );
                    gridControl1.DataSource = null;
                    Ergodic.FormEverySpliEnableFalse( this );
                    label107.Visible = false;
                    toolSelect.Enabled = toolAdd.Enabled = true;
                    toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolSave.Enabled = toolCancel.Enabled = false;
                    try
                    {
                        SqlHelper.ExecuteNonQuery( "DELETE FROM R_REVIEWS WHERE RES01=(SELECT CX01 FROM R_MLLCXMC WHERE CX02=@CX02) AND RES06=@RES06" ,new SqlParameter( "@CX02" ,this.Text ) ,new SqlParameter( "@RES06" ,bn.AI001 ) );
                    }
                    catch { }
                }
            }
        }
        bool deleteOf ( )
        {
            result = false;
            if ( gridView1.RowCount > 0 )
            {
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["AI013"].ToString( ) ) )
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }
        protected override void update ( )
        {
            base.update( );

            DataTable del = SqlHelper.ExecuteDataTable( "SELECT * FROM R_REVIEWS A,R_MLLCXMC B WHERE A.RES01=B.CX01 AND RES05='执行' AND RES06=@RES06 AND CX02=@CX02 " ,new SqlParameter( "@RES06" ,bn.AI001 ) ,new SqlParameter( "@CX02" ,this.Text ) );
            if ( del != null && del.Rows.Count > 0 )
                MessageBox.Show( "单号:" + bn.AI001 + "的单据状态为执行,不允许更改" );
            else
            {
                Ergodic.FormEverySpliEnableTrue( this );
                label107.Visible = false;
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
            }
        }
        protected override void save ( )
        {
            base.save( );

            Ergodic.FormEverySpliEnableFalse( this );
            label107.Visible = false;
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolcopy.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
            seleOrBuild = "2";
        }
        protected override void maintain ( )
        {
            base.maintain( );

            DataTable del = SqlHelper.ExecuteDataTable( "SELECT RES03,RES05,RES06,DBA012,CX02 FROM TPADBA A,R_REVIEW B,R_REVIEWS C,R_MLLCXMC D WHERE A.DBA001=B.RE01 AND B.RE01=C.RES03 AND C.RES01=D.CX01 AND RES06=@RES06 AND CX02=@CX02" ,new SqlParameter( "@RES06" ,bn.AI001 ) ,new SqlParameter( "@CX02" ,this.Text ) );
            if ( del != null && del.Rows.Count > 0 )
            {
                if ( del.Select( "RES05='执行'" ).Length > 0 )
                {
                    Ergodic.FormEverySpliEnableTrue( this );
                    label107.Visible = true;
                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
                    toolSave.Enabled = toolCancel.Enabled = true;
                    weihu = "1";
                } else
                    MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
            } else
                MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
        }
        protected override void cancel ( )
        {
            base.cancel( );

            if ( seleOrBuild == "1" || weihu == "1" )
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolcopy.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
            }
            else if ( seleOrBuild == "2" && weihu != "1" )
            {
                Ergodic.FormEverySpli( this );
                gridControl1.DataSource = null;
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolSave.Enabled = toolCancel.Enabled = false;
                try
                {
                    SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQAI WHERE AI001=@AI001" ,new SqlParameter( "@AI001" ,bn.AI001 ) );
                }
                catch { }
            }
            Ergodic.FormEverySpliEnableFalse( this );
        }
        protected override void copys ( )
        {
            base.copys( );

            //因为复制没有把339合同号带过来，所以取消复制功能
            //int row = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQAI (AI002,AI003,AI004,AI005,AI006,AI007,AI008,AI009,AI010,AI011,AI012) SELECT AI002,AI003,AI004,AI005,AI006,AI007,AI008,AI009,AI010,AI011,AI012 FROM R_PQAI WHERE AI001=@AI001" ,new SqlParameter( "@AI001" ,bn.AI001 ) );
            //if ( row < 1 )
            //    MessageBox.Show( "复制失败,请重试" );
            //else
            //{
            //    bn.AI001 = oddNumbers.purchaseContract( "SELECT MAX(AI001) AI001 FROM R_PQAI" ,"AI001" ,"R_525-" );
            //    row = SqlHelper.ExecuteNonQuery( "UPDATE R_PQAI SET AI001=@AI001 WHERE AI001 IS NULL" ,new SqlParameter( "@AI001" ,bn.AI001 ) );
            //    if ( row < 1 )
            //    {
            //        MessageBox.Show( "复制失败,请重试" );
            //        try
            //        {
            //            SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQAI WHERE AI001 IS NULL" );
            //        }
            //        catch { }
            //    }
            //    else
            //    {
            //        seleOrBuild = "1";
            //        toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            //        toolSave.Enabled = toolCancel.Enabled = true;
            //        Ergodic.FormEverySpliEnableTrue( this );
            //        tableOne = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQAI WHERE AI001=@AI001" ,new SqlParameter( "@AI001" ,bn.AI001 ) );
            //        gridControl1.DataSource = tableOne;
            //    }
            //}
        }
        #endregion

        #region Table
        void parameter ( )
        {
            bn.AI002 = textBox1.Text;
            bn.AI003 = textBox2.Text;
            bn.AI004 = textBox3.Text;
            bn.AI005 = textBox6.Text;
            bn.AI006 = textBox7.Text;
            bn.AI011 = textBox8.Text;
            if ( !string.IsNullOrEmpty( textBox4.Text ) )
                bn.AI007 = Convert.ToDecimal( textBox4.Text );
            else
                bn.AI007 = 0;
            if ( !string.IsNullOrEmpty( textBox5.Text ) )
                bn.AI008 = Convert.ToDecimal( textBox5.Text );
            else
                bn.AI008 = 0;
            if ( !string.IsNullOrEmpty( textBox9.Text ) )
                bn.AI009 = Convert.ToDecimal( textBox9.Text );
            else
                bn.AI009 = 0;
            bn.AI012 = textBox10.Text;
            bn . AI014 = textBox1 . Tag . ToString ( );
        }
        //Build
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox1.Text ) )
                MessageBox.Show( "流水号不可为空" );
            else
            {
                if ( string.IsNullOrEmpty( textBox8.Text ) )
                    MessageBox.Show( "零件名称不可为空" );
                else
                {
                    if ( string.IsNullOrEmpty( textBox2.Text ) )
                        MessageBox.Show( "序号不可为空" );
                    else
                    {
                        if ( string.IsNullOrEmpty( textBox3.Text ) )
                            MessageBox.Show( "色号不可为空" );
                        else
                        {
                            if ( string.IsNullOrEmpty( textBox7.Text ) )
                                MessageBox.Show( "生产批号不可为空" );
                            else
                            {
                                if ( string.IsNullOrEmpty( textBox4.Text ) )
                                    MessageBox.Show( "实入库量不可为空" );
                                else
                                {
                                    if ( Convert.ToDecimal( textBox4.Text ) <= 0 )
                                        MessageBox.Show( "实入库量必须大于0" );
                                    else
                                    {
                                        parameter( );
                                        bn.IDX = SqlHelper.ExecuteSqlReturnId( "INSERT INTO R_PQAI (AI001,AI002,AI003,AI004,AI005,AI006,AI007,AI008,AI009,AI010,AI011,AI012,AI014) VALUES (@AI001,@AI002,@AI003,@AI004,@AI005,@AI006,@AI007,@AI008,@AI009,@AI010,@AI011,@AI012,@AI014);SELECT SCOPE_IDENTITY();" ,new SqlParameter( "@AI001" ,bn.AI001 ) ,new SqlParameter( "@AI002" ,bn.AI002 ) ,new SqlParameter( "@AI003" ,bn.AI003 ) ,new SqlParameter( "@AI004" ,bn.AI004 ) ,new SqlParameter( "@AI005" ,bn.AI005 ) ,new SqlParameter( "@AI006" ,bn.AI006 ) ,new SqlParameter( "@AI007" ,bn.AI007 ) ,new SqlParameter( "@AI008" ,bn.AI008 ) ,new SqlParameter( "@AI009" ,bn.AI009 ) ,new SqlParameter( "@AI010" ,bn.AI010 ) ,new SqlParameter( "@AI011" ,bn.AI011 ) ,new SqlParameter( "@AI012" ,bn.AI012 ) ,new SqlParameter ( "@AI014" ,bn . AI014 ) );
                                        if ( bn . IDX < 1 )
                                            MessageBox.Show( "录入数据失败" );
                                        else
                                        {
                                            MessageBox.Show( "成功录入数据" );

                                            DataRow row;
                                            if ( seleOrBuild == "1" )
                                            {
                                                row = tableOne.NewRow( );
                                                row [ "IDX" ] = bn . IDX;
                                                row ["AI001"] = bn.AI001;
                                                row["AI002"] = bn.AI002;
                                                row["AI011"] = bn.AI011;
                                                row["AI003"] = bn.AI003;
                                                row["AI004"] = bn.AI004;
                                                row["AI005"] = bn.AI005;
                                                row["AI006"] = bn.AI006;
                                                row["AI007"] = bn.AI007;
                                                row["AI008"] = bn.AI008;
                                                row["AI009"] = bn.AI009;
                                                row["AI010"] = bn.AI010;
                                                row["AI012"] = bn.AI012;
                                                row [ "AI014" ] = bn . AI014;
                                                tableOne .Rows.Add( row );
                                            }
                                            else if ( seleOrBuild == "2" )
                                            {
                                                tableTwo = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQAI WHERE AI001=@AI001" ,new SqlParameter( "@AI001" ,bn.AI001 ) );
                                                gridControl1.DataSource = tableTwo;
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
        //Edit
        void editParam ( )
        {
            DataRow row;
            int num = gridView1.FocusedRowHandle;
            if ( seleOrBuild == "2" )
            {
                row = tableTwo.Rows[num];
                row.BeginEdit( );
                row["AI001"] = bn.AI001;
                row["AI002"] = bn.AI002;
                row["AI003"] = bn.AI003;
                row["AI004"] = bn.AI004;
                row["AI005"] = bn.AI005;
                row["AI006"] = bn.AI006;
                row["AI007"] = bn.AI007;
                row["AI008"] = bn.AI008;
                row["AI009"] = bn.AI009;
                row["AI010"] = bn.AI010;
                row["AI011"] = bn.AI011;
                row["AI012"] = bn.AI012;
                row [ "AI014" ] = bn . AI014;
                row .EndEdit( );
            }
            else if ( seleOrBuild == "1" )
            {
                row = tableOne.Rows[num];
                row.BeginEdit( );
                row["AI001"] = bn.AI001;
                row["AI002"] = bn.AI002;
                row["AI003"] = bn.AI003;
                row["AI004"] = bn.AI004;
                row["AI005"] = bn.AI005;
                row["AI006"] = bn.AI006;
                row["AI007"] = bn.AI007;
                row["AI008"] = bn.AI008;
                row["AI009"] = bn.AI009;
                row["AI010"] = bn.AI010;
                row["AI011"] = bn.AI011;
                row["AI012"] = bn.AI012;
                row [ "AI014" ] = bn . AI014;
                row .EndEdit( );
            }
        }
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "流水号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox8.Text ) )
            {
                MessageBox.Show( "零件名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox2.Text ) )
            {
                MessageBox.Show( "序号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox3.Text ) )
            {
                MessageBox.Show( "色号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox7.Text ) )
            {
                MessageBox.Show( "生产批号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox4.Text ) )
            {
                MessageBox.Show( "实入库量不可为空" );
                return;
            }
            if ( Convert.ToDecimal( textBox4.Text ) <= 0 )
            {
                MessageBox.Show( "实入库量必须大于0" );
                return;
            }
            if ( bn.AI013.Trim( ) == "T" )
            {
                MessageBox.Show( "此记录已经被339领用,不允许编辑" );
                return;
            }
            parameter( );
            if ( bn.AI002 == ai2 && bn.AI003 == ai3 && bn.AI004 == ai4 && bn.AI011 == ai11 )
            {
                //AI001=@AI001 AND AI002=@AI002 AND AI003=@AI003 AND AI004=@AI004 AND AI011=@AI011
                //new SqlParameter( "@AI001" ,bn.AI001 ) , new SqlParameter( "@AI002" ,bn.AI002 ) ,new SqlParameter( "@AI003" ,bn.AI003 ) ,,new SqlParameter( "@AI011" ,bn.AI011 )
                count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQAI SET AI005=@AI005,AI006=@AI006,AI007=@AI007,AI008=@AI008,AI009=@AI009,AI010=@AI010,AI012=@AI012 WHERE IDX=@IDX" ,new SqlParameter( "@IDX" ,bn.IDX ) ,new SqlParameter( "@AI005" ,bn.AI005 ) ,new SqlParameter( "@AI006" ,bn.AI006 ) ,new SqlParameter( "@AI007" ,bn.AI007 ) ,new SqlParameter( "@AI008" ,bn.AI008 ) ,new SqlParameter( "@AI009" ,bn.AI009 ) ,new SqlParameter( "@AI010" ,bn.AI010 )  ,new SqlParameter( "@AI012" ,bn.AI012 ) );
                if ( count < 1 )
                    MessageBox.Show( "编辑数据成功" );
                else
                {
                    MessageBox.Show( "成功编辑数据" );
                    editParam( );
                }
            }
            else
            {
                //AI001=@AI001 AND AI002=@AI2 AND AI003=@AI3 AND AI004=@AI4 AND AI011=@AI11
                //,new SqlParameter( "@AI2" ,ai2 ) ,new SqlParameter( "@AI3" ,ai3 ) ,new SqlParameter( "@AI4" ,ai4 ) ,new SqlParameter( "@AI11" ,ai11 )
                count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQAI SET AI002=@AI002,AI003=@AI003,AI004=@AI004,AI005=@AI005,AI006=@AI006,AI007=@AI007,AI008=@AI008,AI009=@AI009,AI010=@AI010,AI011=@AI011,AI012=@AI012,AI014=@AI014 WHERE IDX=@IDX" ,new SqlParameter( "@IDX" ,bn.IDX ) ,new SqlParameter( "@AI002" ,bn.AI002 ) ,new SqlParameter( "@AI003" ,bn.AI003 ) ,new SqlParameter( "@AI004" ,bn.AI004 ) ,new SqlParameter( "@AI005" ,bn.AI005 ) ,new SqlParameter( "@AI006" ,bn.AI006 ) ,new SqlParameter( "@AI007" ,bn.AI007 ) ,new SqlParameter( "@AI008" ,bn.AI008 ) ,new SqlParameter( "@AI009" ,bn.AI009 ) ,new SqlParameter( "@AI010" ,bn.AI010 ) ,new SqlParameter( "@AI011" ,bn.AI011 ) ,new SqlParameter( "@AI012" ,bn.AI012 ) ,new SqlParameter ( "@AI014" ,bn . AI014 ) );
                if ( count < 1 )
                    MessageBox.Show( "编辑数据成功" );
                else
                {
                    MessageBox.Show( "成功编辑数据" );
                    editParam( );
                }
            }
        }
        //Delete
        private void button4_Click ( object sender ,EventArgs e )
        {
            //if ( string.IsNullOrEmpty( textBox1.Text ) )
            //{
            //    MessageBox.Show( "流水号不可为空" );
            //    return;
            //}
            //if ( string.IsNullOrEmpty( textBox8.Text ) )
            //{
            //    MessageBox.Show( "零件名称不可为空" );
            //    return;
            //}
            //if ( string.IsNullOrEmpty( textBox2.Text ) )
            //{
            //    MessageBox.Show( "序号不可为空" );
            //    return;
            //}
            //if ( string.IsNullOrEmpty( textBox3.Text ) )
            //{
            //    MessageBox.Show( "色号不可为空" );
            //    return;
            //}
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==
DialogResult . Cancel )
                return;

            if ( bn.AI013.Trim( ) == "T" )
            {
                MessageBox.Show( "此记录已经被339领用,不允许删除" );
                return;
            }
            int num = gridView1 . FocusedRowHandle;
            //parameter( ); AI002=@AI002 AND AI006=@AI006   ,new SqlParameter( "@AI002" ,bn.AI002 )
            count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQAI WHERE IDX=@IDX" ,new SqlParameter( "@IDX" ,bn.IDX ) );
            if ( count < 1 )
                MessageBox.Show( "删除数据失败" );
            else
            {
                MessageBox.Show( "成功删除数据" );
                
                if ( seleOrBuild == "1" )
                    tableOne . Rows . RemoveAt ( num );
                else if ( seleOrBuild == "2" )
                    tableTwo . Rows . RemoveAt ( num );
            }
        }
        //Refresh
        private void button5_Click ( object sender ,EventArgs e )
        {
            if ( seleOrBuild == "1" )
            {
                tableOne = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQAI WHERE AI001=@AI001" ,new SqlParameter( "@AI001" ,bn.AI001 ) );
                gridControl1.DataSource = tableOne;
            }
            else if ( seleOrBuild == "2" )
            {
                tableTwo = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQAI WHERE AI001=@AI001" ,new SqlParameter( "@AI001" ,bn.AI001 ) );
                gridControl1.DataSource = tableTwo;
            }
        }
        //Read
        private void button7_Click ( object sender ,EventArgs e )
        {
            MulaolaoBll.Bll.BatchNumManagementBll _bll = new MulaolaoBll.Bll.BatchNumManagementBll( );
            if ( string.IsNullOrEmpty( textBox2.Text ) )
            {
                MessageBox.Show( "工序不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox3.Text ) )
            {
                MessageBox.Show( "色号不可为空" );
                return;
            }
            DataTable stock = _bll.GetDataTableStock( textBox2.Text ,textBox3.Text );
            if ( stock == null || stock.Rows.Count < 1 )
            {
                MessageBox.Show( "没有库存记录或尚未有出库的产品" );
                return;
            }
            if ( string.IsNullOrEmpty( stock.Rows[0]["AC15"].ToString( ) ) )
            {
                MessageBox.Show( "尚未有出库的产品或此产品已经出库且出库油漆已领用完" );
                return;
            }
            textBox6.Text = stock.Rows[0]["AC15"].ToString( );
        }
        //batchEdit
        private void button8_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "流水后不可为空" );
                return;
            }
            bn.AI002 = textBox1.Text;
            bn.AI012 = textBox10.Text;
            int row = SqlHelper.ExecuteNonQuery( "UPDATE R_PQAI SET AI002=@AI002,AI012=@AI012 WHERE AI001=@AI001" ,new SqlParameter( "@AI002" ,bn.AI002 ) ,new SqlParameter( "@AI012" ,bn.AI012 ) ,new SqlParameter( "@AI001" ,bn.AI001 ) );
            if ( row > 0 )
            {
                MessageBox.Show( "批量编辑成功" );
                tableOne = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQAI WHERE AI001=@AI001" ,new SqlParameter( "@AI001" ,bn.AI001 ) );
                gridControl1.DataSource = tableOne;
            }
            else
                MessageBox.Show( "批量编辑失败" );
        }
        #endregion
    }
}
