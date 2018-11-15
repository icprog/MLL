using Mulaolao . Class;
using System;
using System . Data;
using System . Data . SqlClient;
using System . Windows . Forms;
using StudentMgr;
using Mulaolao . Other;

namespace Mulaolao . Raw_material_cost
{
    public partial class R_FrmDailyUseOfChemicals : FormChild
    {
        public R_FrmDailyUseOfChemicals ( Form fm )
        {
            this.MdiParent = fm;
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { bandedGridView1  } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }

        MulaolaoLibrary.DailyUseOfChemicals du = new MulaolaoLibrary.DailyUseOfChemicals( );
        MulaolaoBll.Bll.DailyUseOfChemicalsBll _bll = new MulaolaoBll.Bll.DailyUseOfChemicalsBll( );
        DataTable tableOne;
        string sav = "", strWhere = "";
        int count = 0;
        bool result = false;

        private void R_FrmDailyUseOfChemicals_Load ( object sender ,EventArgs e )
        {
            Power( this );

            Ergodic.FormEverySpli( this );
            gridControl1.DataSource = null;
            Ergodic.FormEverySpliEnableFalse( this );

            DataTable da = SqlHelper.ExecuteDataTable( "SELECT DISTINCT AG016 FROM R_PQAG" );
            comboBox5.DataSource = da;
            comboBox5.DisplayMember = "AG016";
        }

        #region Main
        protected override void add ( )
        {
            base.add( );

            Ergodic.FormEverySpli( this );
            gridControl1.DataSource = null;
            Ergodic.FormEverySpliEnableTrue( this );
            dateTimePicker1.Enabled = false;
            sav = "1";
            du.AG001 = oddNumbers.purchaseContract( "SELECT MAX(AJ021) AJ021 FROM R_PQAJ" ,"AJ021" ,"R_266-" );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void update ( )
        {
            base.update( );

            Ergodic.FormEverySpliEnableTrue( this );
            toolSelect.Enabled = toolAdd.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolMaintain.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
            dateTimePicker1.Enabled = false;
        }
        protected override void delete ( )
        {
            base.delete( );

            if ( deleteof( ) == true )
                return;
            if ( string.IsNullOrEmpty( du.AG001 ) )
                MessageBox.Show( "请选择需要删除的内容" );
            else
            {
                int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQAG WHERE AG001=@AG001" ,new SqlParameter( "@AG001" ,du.AG001 ) );
                if ( count < 1 )
                    MessageBox.Show( "删除数据失败" );
                else
                {
                    MessageBox.Show( "删除数据成功" );

                    Ergodic.FormEverySpli( this );
                    gridControl1.DataSource = null;
                    Ergodic.FormEverySpliEnableFalse( this );
                    toolSave.Enabled = toolCancel.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolMaintain.Enabled = false;
                    toolSelect.Enabled = toolAdd.Enabled = true;

                    try
                    {
                        SqlHelper.ExecuteNonQuery( "DELETE FROM R_REVIEWS WHERE RES01=(SELECT CX01 FROM R_MLLCXMC WHERE CX02=@CX02) AND RES06=@RES06" ,new SqlParameter( "@CX02" ,this.Text ) ,new SqlParameter( "@RES06" ,du.AG001 ) );
                    }
                    catch { }
                }
            }
        }
        bool deleteof ( )
        {
            result = false;
            if ( bandedGridView1.RowCount > 0 )
            {
                for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                {
                    if ( _bll.yesOrNo( du.AG002 ,bandedGridView1.GetDataRow( i )["AG009"].ToString( ) ,bandedGridView1.GetDataRow( i )["AG005"].ToString( ) ,bandedGridView1.GetDataRow( i )["AG006"].ToString( ) ) == false )
                    {
                        MessageBox.Show( "此单据中有记录被339领用,不允许删除" );
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }
        protected override void save ( )
        {
            base.save( );

            Ergodic.FormEverySpliEnableFalse( this );
            toolSave.Enabled = toolCancel.Enabled = toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolMaintain.Enabled = false;
            toolSelect.Enabled = toolAdd.Enabled = toolUpdate.Enabled = toolDelete.Enabled = true;
        }
        protected override void cancel ( )
        {
            base.cancel( );

            if ( sav == "1" )
            {
                Ergodic.FormEverySpli( this );
                gridControl1.DataSource = null;
                Ergodic.FormEverySpliEnableFalse( this );

                toolSelect.Enabled = toolAdd.Enabled = toolUpdate.Enabled = toolDelete.Enabled = toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolMaintain.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
                try
                {
                    SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQAG WHERE AG001=@AG001" ,new SqlParameter( "@AG001" ,du.AG001 ) );
                }
                catch { }
            }
            else if ( sav == "2" )
            {
                Ergodic.FormEverySpliEnableFalse( this );

                toolSave.Enabled = toolCancel.Enabled = toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolMaintain.Enabled = false;
                toolSelect.Enabled = toolAdd.Enabled = toolUpdate.Enabled = toolDelete.Enabled = true;
            }
        }
        #endregion

        #region Event
        //Form 525
        private void button8_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox1.Text ) )
                MessageBox.Show( "流水号不可为空" );
            else
            {
                if ( string.IsNullOrEmpty( textBox9.Text ) )
                    MessageBox.Show( "零件名称不可为空" );
                else
                {
                    if ( string.IsNullOrEmpty( textBox6.Text ) )
                        MessageBox.Show( "工序不可为空" );
                    else
                    {
                        if ( string.IsNullOrEmpty( textBox7.Text ) )
                            MessageBox.Show( "色号不可为空" );
                        else
                        {
                            if ( string.IsNullOrEmpty( textBox5.Text ) )
                                MessageBox.Show( "生产批次号不可为空" );
                            else
                            {
                                du.AG002 = textBox1.Text;
                                du.AG005 = textBox6.Text;
                                du.AG006 = textBox7.Text;
                                du.AG010 = textBox5.Text;
                                du.AG009 = textBox9.Text;
                                du . AG020 = textBox1 . Tag . ToString ( );
                                DataTable dpi = SqlHelper.ExecuteDataTable( "SELECT AI007-AI008 AI FROM R_PQAI WHERE AI002=@AI002 AND AI003=@AI003 AND AI004=@AI004 AND AI006=@AI006 AND AI011=@AI011 AND AI014=@AI014" ,new SqlParameter( "@AI002" ,du.AG002 ) ,new SqlParameter( "@AI003" ,du.AG005 ) ,new SqlParameter( "@AI004" ,du.AG006 ) ,new SqlParameter( "@AI006" ,du.AG010 ) ,new SqlParameter( "@AI011" ,du.AG009 ) ,new SqlParameter ( "@AI014" ,du . AG020 ) );
                                if ( dpi.Rows.Count > 0 )
                                    textBox11.Text = dpi.Rows[0]["AI"].ToString( );
                                else
                                    textBox11.Text = "0";
                            }
                        }
                    }
                }
            }
        }
        //供方批号
        //private void TextBox10_LostFocus ( object sender ,EventArgs e )
        //{
        //    if ( string.IsNullOrEmpty( textBox1.Text ) )
        //        MessageBox.Show( "流水号不可为空" );
        //    else
        //    {
        //        if ( string.IsNullOrEmpty( textBox6.Text ) )
        //            MessageBox.Show( "工艺不可为空" );
        //        else
        //        {
        //            if ( string.IsNullOrEmpty( textBox7.Text ) )
        //                MessageBox.Show( "色号不可为空" );
        //            else
        //            {
        //                DataTable dq = SqlHelper.ExecuteDataTable( "SELECT DISTINCT AG009,AG010 FROM R_PQAG" );
        //                if ( dq.Rows.Count < 1 )
        //                    textBox5.Text = "CK_1001";
        //                else
        //                {
        //                    for ( int k = 0 ; k < dq.Rows.Count ; k++ )
        //                    {
        //                        if ( dq.Rows[k]["AG009"].ToString( ) == textBox10.Text )
        //                        {
        //                            textBox5.Text = dq.Rows[k]["AG010"].ToString( );
        //                            break;
        //                        }
        //                        else
        //                        {
        //                            var query = dq.AsEnumerable( ).Select( t => t.Field<string>( "AG010" ) ).Max( );
        //                            textBox5.Text = "CK_" + ( Convert.ToInt64( query.Substring( 2 ,query.Length - 2 ) ) + 1 ).ToString( );
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
        //领用量
        private void comboBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox1 );
        }
        private void comboBox1_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox1 );
        }
        private void comboBox1_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox1.Text != "" && !DateDayRegise.fiveForNum( comboBox1 ) )
            {
                this.comboBox1.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多一位,如9999.9,请重新输入" );
            }
        }
        private void comboBox2_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox2 );
        }
        private void comboBox2_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox2 );
        }
        private void comboBox2_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox2.Text != "" && !DateDayRegise. fiveForNum ( comboBox2 ) )
            {
                this.comboBox2.Text = "";
                MessageBox . Show ( "只允许输入整数部分最多四位,小数部分最多一位,如9999.9,请重新输入" );
            }
        }
        private void comboBox4_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox4 );
        }
        private void comboBox4_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox4 );
        }
        private void comboBox4_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox4.Text != "" && !DateDayRegise. fiveForNum ( comboBox4 ) )
            {
                this.comboBox4.Text = "";
                MessageBox . Show ( "只允许输入整数部分最多四位,小数部分最多一位,如9999.9,请重新输入" );
            }
        }
        private void comboBox3_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox3 );
        }
        private void comboBox3_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox3 );
        }
        private void comboBox3_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox3.Text != "" && !DateDayRegise. fiveForNum ( comboBox3 ) )
            {
                this.comboBox3.Text = "";
                MessageBox . Show ( "只允许输入整数部分最多四位,小数部分最多一位,如9999.9,请重新输入" );
            }
        }
        private void bandedGridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            int num = bandedGridView1.FocusedRowHandle;
            if ( num >= 0 && num <= bandedGridView1.RowCount - 1 )
            {
                if ( !string.IsNullOrEmpty( bandedGridView1.GetFocusedRowCellValue( "AG003" ).ToString( ) ) )
                    dateTimePicker2.Value = Convert.ToDateTime( bandedGridView1.GetFocusedRowCellValue( "AG003" ).ToString( ) );
                textBox6.Text = bandedGridView1.GetFocusedRowCellValue( "AG005" ).ToString( );
                textBox7.Text = bandedGridView1.GetFocusedRowCellValue( "AG006" ).ToString( );
                textBox8.Text = bandedGridView1.GetFocusedRowCellValue( "AG007" ).ToString( );
                textBox9.Text = bandedGridView1.GetFocusedRowCellValue( "AG009" ).ToString( );
                textBox5.Text = bandedGridView1.GetFocusedRowCellValue( "AG010" ).ToString( );
                comboBox1.Text = bandedGridView1.GetFocusedRowCellValue( "AG011" ).ToString( );
                comboBox2.Text = bandedGridView1.GetFocusedRowCellValue( "AG012" ).ToString( );
                comboBox4.Text = bandedGridView1.GetFocusedRowCellValue( "AG013" ).ToString( );
                comboBox3.Text = bandedGridView1.GetFocusedRowCellValue( "AG014" ).ToString( );
                comboBox5.Text = bandedGridView1.GetFocusedRowCellValue( "AG016" ).ToString( );
                textBox1 . Tag = bandedGridView1 . GetFocusedRowCellValue ( "AG020" ) . ToString ( );
                du .AG008 = bandedGridView1.GetFocusedRowCellValue( "AG008" ).ToString( );
                du.IDX = string.IsNullOrEmpty( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                du.AG005 = textBox6.Text;
                du.AG006 = textBox7.Text;
                du.AG019 = bandedGridView1.GetFocusedRowCellValue( "AG019" ).ToString( );
                yesOrNo( );
            }
        }
        void yesOrNo ( )
        {
            if ( toolSave.Enabled )
            {
                if ( _bll.yesOrNo( textBox1.Text ,textBox9.Text ,textBox6.Text ,textBox7.Text ) == false )
                    comboBox1.Enabled = comboBox2.Enabled = button5.Enabled = false;
                else
                    comboBox1.Enabled = comboBox2.Enabled = button5.Enabled = true;
            }
        }
        #endregion

        #region Table
        DataRow row;
        void variable ( )
        {
            //du.AG004 = textBox5.Text;
            du.AG005 = textBox6.Text;
            du.AG006 = textBox7.Text;
            du.AG003 = dateTimePicker2.Value;
            du.AG007 = textBox8.Text;
            du.AG009 = textBox9.Text;
            du.AG010 = textBox5.Text;
            if ( !string.IsNullOrEmpty( comboBox1.Text ) )
                du.AG011 = Convert.ToDecimal( comboBox1.Text );
            else
                du.AG011 = 0;
            if ( !string.IsNullOrEmpty( comboBox2.Text ) )
                du.AG012 = Convert.ToDecimal( comboBox2.Text );
            else
                du.AG012 = 0;
            if ( !string.IsNullOrEmpty( comboBox4.Text ) )
                du.AG013 = Convert.ToDecimal( comboBox4.Text );
            else
                du.AG013 = 0;
            if ( !string.IsNullOrEmpty( comboBox3.Text ) )
                du.AG014 = Convert.ToDecimal( comboBox3.Text );
            else
                du.AG014 = 0;
            du.AG016 = comboBox5.Text;
            du . AG020 = textBox1 . Tag . ToString ( );
        }
        void rowEdit ( )
        {
            row["AG003"] = du.AG003;
            row["AG005"] = du.AG005;
            row["AG006"] = du.AG006;
            row["AG007"] = du.AG007;
            row["AG008"] = du.AG008;
            row["AG009"] = du.AG009;
            row["AG010"] = du.AG010;
            row["AG011"] = du.AG011;
            row["AG012"] = du.AG012;
            row["AG013"] = du.AG013;
            row["AG014"] = du.AG014;
            row["AG016"] = du.AG016;
            row["AG019"] = du.AG019;
            row [ "AG020" ] = du . AG020;
        }
        //Build
        private void button7_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "流水号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox6.Text ) )
            {
                MessageBox.Show( "工艺不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox7.Text ) )
            {
                MessageBox.Show( "色号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
            {
                MessageBox.Show( "领用量不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox5.Text ) )
            {
                MessageBox.Show( "生产批次号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox5.Text ) )
            {
                MessageBox.Show( "领用人不可为空" );
                return;
            }
            if ( du.AG011 < du.AG012 )
            {
                MessageBox.Show( "收回量大于领用量,请调整" );
                return;
            }
            
            variable( );

            button8_Click( null ,null );
            if ( !string.IsNullOrEmpty( textBox11.Text ) )
            {
                if ( Convert.ToDecimal( textBox11.Text ) < du.AG011 )
                {
                    MessageBox.Show( "领用量多于库存量,请更改领用量" );
                    return;
                }

                du.IDX = _bll.Add( du );
                if ( du.IDX > 0 )
                {
                    MessageBox.Show( "成功录入数据" );
                    if ( tableOne == null )
                        refre( );
                    else
                    {
                        row = tableOne.NewRow( );
                        row["idx"] = du.IDX;
                        rowEdit( );
                        tableOne.Rows.Add( row );
                    }
                }
                else
                    MessageBox.Show( "录入数据失败" );
            }
            else
                MessageBox.Show( "剩余库存量为0,请外购" );
        }     
        //Edit
        private void button6_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( du.AG002 ) )
            {
                MessageBox.Show( "流水号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "流水号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox6.Text ) )
            {
                MessageBox.Show( "工艺不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox7.Text ) )
            {
                MessageBox.Show( "色号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
            {
                MessageBox.Show( "领用量不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox5.Text ) )
            {
                MessageBox.Show( "生产批次号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox5.Text ) )
            {
                MessageBox.Show( "领用人不可为空" );
                return;
            }
            if ( du.AG011 < du.AG012 )
            {
                MessageBox.Show( "收回量大于领用量,请调整" );
                return;
            }
            variable( );
            button8_Click( null ,null );
            if ( !string.IsNullOrEmpty( textBox11.Text ) )
            {
                if ( Convert.ToDecimal( textBox11.Text ) < du.AG011 )
                {
                    MessageBox.Show( "领用量多于库存量,请更改领用量" );
                    return;
                }
                result = _bll.Update( du );
                if ( result == true )
                {
                    MessageBox.Show( "数据编辑成功" );
                    row = tableOne.Rows[bandedGridView1.FocusedRowHandle];
                    row.BeginEdit( );
                    rowEdit( );
                    row.EndEdit( );
                }
                else
                    MessageBox.Show( "编辑数据失败" );
            }
            else
                MessageBox.Show( "剩余库存量为0，请外购" );
        }
        //Dele
        private void button5_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==
   DialogResult . Cancel )
                return;

            result = _bll.Delete( du.IDX );
            if ( result==false )
                MessageBox.Show( "删除数据失败" );
            else
            {
                MessageBox.Show( "成功删除数据" );

                int num = bandedGridView1.FocusedRowHandle;
                tableOne.Rows.RemoveAt( num );
            }
        }
        //Refresh
        private void button4_Click ( object sender ,EventArgs e )
        {
            refre( );
        }
        void refre ( )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND AG001='" + du.AG001 + "'";
            tableOne = _bll.GetDataTable( strWhere );
            gridControl1.DataSource = tableOne;
        }
        //Write to 285 525
        decimal PQK10 = 0, PQK31 = 0, AI008 = 0;
        string PQK33 = "", PQK34 = "";
        private void button3_Click ( object sender ,EventArgs e )
        {
            
            if ( string.IsNullOrEmpty( du.AG002 ) )
                MessageBox.Show( "流水号不可为空" );
            else
            {
                if ( string.IsNullOrEmpty( textBox1.Text ) )
                    MessageBox.Show( "流水号不可为空" );
                else
                {
                    if ( string.IsNullOrEmpty( textBox6.Text ) )
                        MessageBox.Show( "工艺不可为空" );
                    else
                    {
                        if ( string.IsNullOrEmpty( textBox7.Text ) )
                            MessageBox.Show( "色号不可为空" );
                        else
                        {
                            if ( string.IsNullOrEmpty( comboBox1.Text ) )
                                MessageBox.Show( "领用量不可为空" );
                            else
                            {
                                if ( string.IsNullOrEmpty( textBox5.Text ) )
                                    MessageBox.Show( "生产批次号不可为空" );
                                else
                                {
                                    variable( );
                                    button8_Click( null ,null );
                                    if ( Convert.ToDecimal( textBox11.Text ) < du.AG011 - du.AG012 )
                                        MessageBox.Show( "实用量大于剩余库存量,不能写入285,请调整" );
                                    else
                                    {
                                        if ( du.AG011 < du.AG012 )
                                            MessageBox.Show( "收回量大于领用量,请调整" );
                                        else
                                        {
                                            PQK10 = PQK31 = AI008 = 0;
                                            PQK33 = PQK34 = "";

                                            DataTable sel = SqlHelper.ExecuteDataTable( "SELECT PQK10,PQK31,PQK33,PQK34 FROM R_PQK WHERE PQK07=@PQK07 AND PQK02=@PQK02 AND PQK11=@PQK11 AND PQK17=@PQK17 AND PQK30=@PQK30" ,new SqlParameter( "@PQK07" ,du.AG009 ) ,new SqlParameter( "@PQK02" ,du.AG002 ) ,new SqlParameter( "@PQK11" ,du.AG005 ) ,new SqlParameter( "@PQK17" ,du.AG006 ) ,new SqlParameter ( "@PQK30" ,du . AG020 ) );
                                            if ( sel.Rows.Count > 0 )
                                            {
                                                DataTable srt = SqlHelper.ExecuteDataTable( "SELECT AG018,AG004 FROM R_PQAG WHERE idx=@idx" ,new SqlParameter( "@idx" ,du.IDX ) );
                                                if ( srt.Rows.Count > 0 )
                                                {
                                                    if ( !string.IsNullOrEmpty( srt.Rows[0]["AG018"].ToString( ) ) )
                                                        du.AG018 = Convert.ToDecimal( srt.Rows[0]["AG018"].ToString( ) );
                                                    else
                                                        du.AG018 = 0;
                                                    if ( !string.IsNullOrEmpty( srt.Rows[0]["AG004"].ToString( ) ) )
                                                        du.AG004 = Convert.ToDecimal( srt.Rows[0]["AG004"].ToString( ) );
                                                    else
                                                        du.AG004 = 0;
                                                }
                                                else
                                                {
                                                    du.AG018 = 0;
                                                    du.AG004 = 0;
                                                }
                                                if ( string.IsNullOrEmpty( sel.Rows[0]["PQK33"].ToString( ) ) )
                                                    PQK33 = du.AG010;
                                                else if ( !sel.Rows[0]["PQK33"].ToString( ).Contains( du.AG010 ) )
                                                    PQK33 = sel.Rows[0]["PQK33"].ToString( ) + "," + du.AG010;
                                                if ( string.IsNullOrEmpty( sel.Rows[0]["PQK34"].ToString( ) ) )
                                                    PQK34 = du.AG008;
                                                else if ( !sel.Rows[0]["PQK34"].ToString( ).Contains( du.AG008 ) )
                                                    PQK34 = sel.Rows[0]["PQK34"].ToString( ) + "," + du.AG008;
                                                if ( du.AG019 == "T" )
                                                {
                                                    if ( !string.IsNullOrEmpty( sel.Rows[0]["PQK10"].ToString( ) ) )
                                                        PQK10 = du.AG011 - du.AG012 - du.AG018 + Convert.ToDecimal( sel.Rows[0]["PQK10"].ToString( ) );
                                                    else
                                                        PQK10 = du.AG011 - du.AG012 - du.AG018;
                                                    count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQK SET PQK10=@PQK10,PQK33=@PQK33,PQK34=@PQK34 WHERE PQK02=@PQK02 AND PQK07=@PQK07 AND PQK11=@PQK11 AND PQK17=@PQK17 AND PQK30=@PQK30" ,new SqlParameter( "@PQK02" ,du.AG002 ) ,new SqlParameter( "@PQK07" ,du.AG009 ) ,new SqlParameter( "@PQK11" ,du.AG005 ) ,new SqlParameter( "@PQK17" ,du.AG006 ) ,new SqlParameter( "@PQK10" ,PQK10 ) ,new SqlParameter( "@PQK33" ,PQK33 ) ,new SqlParameter( "@PQK34" ,PQK34 ) ,new SqlParameter ( "@PQK30" ,du.AG020 ) );
                                                    if ( count < 1 )
                                                        MessageBox.Show( "写入285失败" );
                                                    else
                                                    {
                                                        MessageBox.Show( "写入285成功" );

                                                        try
                                                        {
                                                            SqlHelper.ExecuteNonQuery( "UPDATE R_PQAG SET AG018=@AG018 WHERE idx=@idx" ,new SqlParameter( "@idx" ,du.IDX ) ,new SqlParameter( "@AG018" ,du.AG011 - du.AG012 ) );
                                                        }
                                                        catch { }
                                                    }
                                                }
                                                else if ( du.AG019 == "F" )
                                                {
                                                    if ( !string.IsNullOrEmpty( sel.Rows[0]["PQK31"].ToString( ) ) )
                                                        PQK31 = du.AG011 - du.AG012 - du.AG018 + Convert.ToDecimal( sel.Rows[0]["PQK31"].ToString( ) );
                                                    else
                                                        PQK31 = du.AG011 - du.AG012 - du.AG018;
                                                    int num = SqlHelper.ExecuteNonQuery( "UPDATE R_PQK SET PQK31=@PQK31,PQK33=@PQK33,PQK34=@PQK34  WHERE PQK02=@PQK02 AND PQK07=@PQK07 AND PQK11=@PQK11 AND PQK17=@PQK17 AND PQK30=@PQK30" ,new SqlParameter( "@PQK02" ,du.AG002 ) ,new SqlParameter( "@PQK07" ,du.AG009 ) ,new SqlParameter( "@PQK11" ,du.AG005 ) ,new SqlParameter( "@PQK17" ,du.AG006 ) ,new SqlParameter( "@PQK31" ,PQK31 ) ,new SqlParameter( "@PQK33" ,PQK33 ) ,new SqlParameter( "@PQK34" ,PQK34 ) ,new SqlParameter ( "@PQK30" ,du.AG020 ) );
                                                    if ( num < 1 )
                                                        MessageBox.Show( "写入285失败" );
                                                    else
                                                    {
                                                        MessageBox.Show( "写入285成功" );
                                                        try
                                                        {
                                                            SqlHelper.ExecuteNonQuery( "UPDATE R_PQAG SET AG018=@AG018 WHERE idx=@idx" ,new SqlParameter( "@idx" ,du.IDX ) ,new SqlParameter( "@AG018" ,du.AG011 - du.AG012 ) );
                                                        }
                                                        catch { }
                                                    }
                                                }
                                            }
                                            else
                                                MessageBox.Show( "285没有此记录,请核实" );
                                            DataTable dli = SqlHelper.ExecuteDataTable( "SELECT SUM(AI008) AI008 FROM R_PQAI WHERE AI002=@AI002 AND AI011=@AI011 AND AI003=@AI003 AND AI004=@AI004 AND AI014=@AI014" ,new SqlParameter( "@AI002" ,du.AG002 ) ,new SqlParameter( "@AI011" ,du.AG009 ) ,new SqlParameter( "@AI003" ,du.AG005 ) ,new SqlParameter( "@AI004" ,du.AG006 ) ,new SqlParameter ( "@AI014" ,du . AG020 ) );
                                            if ( dli.Rows.Count < 1 )
                                                MessageBox.Show( "525没有此记录,请核实" );
                                            else
                                            {
                                                if ( !string.IsNullOrEmpty( dli.Rows[0]["AI008"].ToString( ) ) )
                                                    AI008 = du.AG011 - du.AG012 - du.AG004 + Convert.ToDecimal( dli.Rows[0]["AI008"].ToString( ) );
                                                else
                                                    AI008 = du.AG011 - du.AG012 - du.AG004;
                                                int counst = SqlHelper . ExecuteNonQuery ( "UPDATE R_PQAI SET AI008=@AI008 WHERE AI002=@AI002 AND AI011=@AI011 AND AI003=@AI003 AND AI004=@AI004 AND AI014=@AI014" ,new SqlParameter ( "@AI002" ,du . AG002 ) ,new SqlParameter ( "@AI011" ,du . AG009 ) ,new SqlParameter ( "@AI003" ,du . AG005 ) ,new SqlParameter ( "@AI004" ,du . AG006 ) ,new SqlParameter ( "@AI008" ,AI008 ) ,new SqlParameter ( "@AI014" ,du . AG020 ) );
                                                if ( counst < 1 )
                                                    MessageBox.Show( "写入525失败" );
                                                else
                                                {
                                                    MessageBox.Show( "写入525成功" );
                                                    try
                                                    {
                                                        SqlHelper.ExecuteNonQuery( "UPDATE R_PQAG SET AG004=@AG004 WHERE idx=@idx" ,new SqlParameter( "@idx" ,du.IDX ),new SqlParameter( "@AG004" ,du.AG011 - du.AG012 ) );
                                                    }
                                                    catch { }
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
        #endregion

        #region Query
        protected override void select ( )
        {
            base.select( );

            DataTable dr = SqlHelper.ExecuteDataTable( "SELECT DISTINCT idx,AG001,AG002 AI002,AG009 AI011,AG005 AI003,AG006 AI004,AG019 AI010,AG010 AI006 FROM R_PQAG ORDER BY AG001 DESC" );
            if ( dr.Rows.Count < 1 )
                MessageBox.Show( "没有数据" );
            else
            {
                ss = "3";
                frm.gridControl1.DataSource = dr;
                frm.Text = "R_266 信息查询";
                frm.test = "3";
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.PassDataBetweenForm += new R_Frm266.PassDataBetweenFormHandler( frm_PassDataBetweenForm );
                frm.ShowDialog( );

                if ( string.IsNullOrEmpty( du.AG001 ) )
                    MessageBox.Show( "您没有选择任何内容" );
                else
                {
                    Ergodic.FormEverySpliEnableFalse( this );
                    toolSave.Enabled = toolCancel.Enabled = toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolMaintain.Enabled = false;
                    toolSelect.Enabled = toolAdd.Enabled = toolUpdate.Enabled = toolDelete.Enabled = true;
                    sav = "2";

                    DataTable dm = SqlHelper.ExecuteDataTable( "SELECT YQ107,YQ108,YQ04,YQ05 FROM R_PQI WHERE YQ03=@YQ03" ,new SqlParameter( "@YQ03" ,du.AG002 ) );
                    if ( dm.Rows.Count > 0 )
                    {
                        textBox2.Text = dm.Rows[0]["YQ107"].ToString( );
                        textBox3.Text = dm.Rows[0]["YQ108"].ToString( );
                        textBox4.Text = dm.Rows[0]["YQ04"].ToString( );
                        if ( !string.IsNullOrEmpty( dm.Rows[0]["YQ05"].ToString( ) ) )
                            dateTimePicker1.Value = Convert.ToDateTime( dm.Rows[0]["YQ05"].ToString( ) );
                    }
                    //AG004,
                    refre( );
                }
            }
        }
        R_Frm266 frm = new R_Frm266( );
        string ss = "";
        private void button1_Click ( object sender ,EventArgs e )
        {
            DataTable da = SqlHelper.ExecuteDataTable( "SELECT AI014,AI011,AI002,YQ107,YQ108,YQ04,YQ05,AI003,AI004,AI005,AI006,AI007-AI008 AI,AI010 FROM R_PQAI A LEFT JOIN R_PQI B ON A.AI002=B.YQ03 AND AI011=YQ10 AND AI003=YQ11 AND AI004=YQ12 AND AI014=YQ99 WHERE AI007-AI008>0 AND (AI013!='T' OR AI013='' OR AI013 IS NULL)" );
            if ( da.Rows.Count < 1 )
                MessageBox.Show( "R_525没有记录" );
            else
            {
                ss = "1";
                frm.gridControl1.DataSource = da;
                frm.Text = "R_266 信息查询";
                frm.test = "1";
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.PassDataBetweenForm += new R_Frm266.PassDataBetweenFormHandler( frm_PassDataBetweenForm );
                frm.ShowDialog( );
            }
        }
        private void frm_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( ss == "1" )
            {
                du.AG002 = e.ConOne;
                textBox1.Text = e.ConOne;
                textBox2.Text = e.ConTwo;
                textBox3.Text = e.ConTre;
                textBox4.Text = e.ConFor;
                if ( !string.IsNullOrEmpty( e.ConFiv ) )
                    dateTimePicker1.Value = Convert.ToDateTime( e.ConFiv );
                du.AG005 = e.ConSix;
                textBox6.Text = e.ConSix;
                du.AG006 = e.ConSev;
                textBox7.Text = e.ConSev;
                du.AG010 = e.ConEgi;
                textBox5.Text = e.ConEgi;
                textBox11.Text = e.ConNin;
                du.AG019 = e.ConTen;
                du.AG008 = e.ConEleven;
                du.AG009 = e.ConTwelve;
                textBox9.Text = e.ConTwelve;
                textBox1 . Tag = e . ConThirteen;
                du . AG020 = e . ConThirteen;
            }
            else if ( ss == "3" )
            {
                du.AG001 = e.ConOne;
                du.AG002 = e.ConTre;
                textBox1.Text = e.ConTre;
                du.AG005 = e.ConFor;
                textBox6.Text = e.ConFor;
                du.AG006 = e.ConFiv;
                textBox7.Text = e.ConFiv;
                du.AG010 = e.ConSix;
                textBox5.Text = e.ConSix;
                du.AG019 = e.ConSev;
                du.AG009 = e.ConEgi;
                textBox9.Text = e.ConEgi;
            }
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( du.AG002 ) )
                MessageBox.Show( "请选择流水号" );
            else
            {
                DataTable de = SqlHelper.ExecuteDataTable( "SELECT PQK07,PQK11,PQK17,PQK16,PQK09,PQK10,PQK31,PQK18,PQK32 FROM R_PQK WHERE PQK02 =@PQK02" ,new SqlParameter( "@PQK02" ,du.AG002 ) );
                if ( de.Rows.Count < 1 )
                    MessageBox.Show( "R_285表中没有流水号:" + du.AG002 + "的记录,请核实后再查询" );
                else
                {
                    ss = "2";
                    frm.gridControl1.DataSource = de;
                    frm.Text = "R_266 信息查询";
                    frm.test = "2";
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.PassDataBetweenForm += new R_Frm266.PassDataBetweenFormHandler( frm_PassDataBetweenForm );
                    frm.ShowDialog( );
                }
            }
        }
        #endregion
    }
}

