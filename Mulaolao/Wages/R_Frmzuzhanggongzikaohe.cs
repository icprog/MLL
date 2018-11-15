using System;
using System.Data;
using System.Windows.Forms;
using Mulaolao.Class;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace Mulaolao.Wages
{
    public partial class R_Frmzuzhanggongzikaohe : FormChild
    {
        public R_Frmzuzhanggongzikaohe ( )
        {
            InitializeComponent( );
            
            //GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . gridView1 ,this . bandedGridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.ZuZhangGongZiKaoHeZaLibrary modelZa = new MulaolaoLibrary.ZuZhangGongZiKaoHeZaLibrary( );
        MulaolaoLibrary.ZuZhangGongZiKaoHeZbLibrary modelZb = new MulaolaoLibrary.ZuZhangGongZiKaoHeZbLibrary( );
        MulaolaoBll.Bll.ZuZhangGongZiKaoHeBll bll = new MulaolaoBll.Bll.ZuZhangGongZiKaoHeBll( );
        DataTable tableQuery, tableQueryTwo, searCh;
        string saa = "", strWhere = "1=1", dd = "",dateTime=string.Empty;
        bool result = false;
        
        private void R_Frmzuzhanggongzikaohe_Load( object sender, EventArgs e )
        {
            Power( this );

            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;
            gridControl2.DataSource = null;
            Ergodic.FormEverySpliEnableFalse( this );
            label45.Visible = false;
            bandedGridView1.OptionsBehavior.Editable = false;

            comboBox1.DataSource = bll.GetDataTableHeadMan( );
            comboBox1.DisplayMember = "DBA002";

            dateTimePicker1.Enabled = false;
        }

        #region Event
        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                if ( !string.IsNullOrEmpty( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) )
                {
                    modelZa.Idx = Convert.ToInt32( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                    assign( );
                }
            }
        }
        void assign ( )
        {
            modelZa = bll.GetModel( modelZa.Idx );
            comboBox1.Text = textBox7.Text = modelZa.QD001;
            if ( !string.IsNullOrEmpty( modelZa.QD003 ) )
                dateTimePicker1.Value = dateTimePicker2.Value = DateTime.ParseExact( modelZa.QD002 + modelZa.QD003.Substring( 2 ,2 ) ,"yyyyMMdd" ,System.Globalization.CultureInfo.CurrentCulture );
            textBox14.Text = modelZa.QD004.ToString( );
            textBox16.Text = modelZa.QD005.ToString( );
            textBox1.Text = modelZa.QD007.ToString( );
            textBox2.Text = modelZa.QD008.ToString( );
            textBox4.Text = modelZa.QD009.ToString( );
            textBox5.Text = modelZa.QD011.ToString( );
            textBox8.Text = modelZa.QD012.ToString( );
            textBox6.Text = modelZa.QD014.ToString( );
            textBox10.Text = modelZa.QD015.ToString( );
            textBox12.Text = modelZa.QD017.ToString( );
            textBox13.Text = modelZa.QD018.ToString( );
            textBox15.Text = modelZa.QD019.ToString( );

           dateTime= modelZb.QD094 = dateTimePicker1.Value.ToString( "MMdd" );
            //lookAss( modelZb.QD094 );
        }
        private void textBox14_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.fractionTb( e ,textBox14 );
        }
        private void textBox14_TextChanged ( object sender ,EventArgs e )
        {
            DateDay.textChangeTb( textBox14 );
        }
        private void textBox14_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox14.Text != "" && !DateDay.threeTwoNumTb( textBox14 ) )
            {
                this.textBox14.Text = "";
                MessageBox.Show( "只允许输入整数部分最多一位,小数部分最多两位,如9.99,请重新输入" );
            }
        }
        private void textBox16_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.fractionTb( e ,textBox16 );
        }
        private void textBox16_TextChanged ( object sender ,EventArgs e )
        {
            DateDay.textChangeTb( textBox16 );
        }
        private void textBox16_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox16.Text != "" && !DateDay.threeOneNumTb( textBox16 ) )
            {
                this.textBox16.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
        }
        private void textBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDayRegise.intgra( e );
        }
        private void textBox1_TextChanged ( object sender ,EventArgs e )
        {
            textBox3.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox1 ,textBox2 ) ) ,0 ).ToString( );
        }
        private void textBox2_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDay.intgra( e );
        }
        private void textBox2_TextChanged ( object sender ,EventArgs e )
        {
            textBox3.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox1 ,textBox2 ) ) ,0 ).ToString( );
        }
        private void textBox4_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.fractionTb( e ,textBox4 );
        }
        private void textBox4_TextChanged ( object sender ,EventArgs e )
        {
            DateDay.textChangeTb( textBox4 );
        }
        private void textBox4_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox4.Text != "" && !DateDay.foreOneNum( textBox4 ) )
            {
                this.textBox4.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如999.9,请重新输入" );
            }
        }
        private void textBox5_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDay.intgra( e );
        }
        private void textBox5_TextChanged ( object sender ,EventArgs e )
        {
            textBox9.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox5 ,textBox8 ) ) ,1 ).ToString( );
        }
        private void textBox8_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDay.fractionTb( e ,textBox8 );
        }
        private void textBox8_TextChanged ( object sender ,EventArgs e )
        {
            //DateDay.textChangeTb( textBox8 );
            textBox9.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox5 ,textBox8 ) ) ,1 ).ToString( );
        }
        private void textBox8_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox8.Text != "" && !DateDay.eightSixTb( textBox8 ) )
            {
                this.textBox8.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多六位,如99.999999,请重新输入" );
            }
        }
        private void textBox6_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.intgra( e );
        }
        private void textBox6_TextChanged ( object sender ,EventArgs e )
        {
            textBox11.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox6 ,textBox10 ) ) ,1 ).ToString( );
        }
        private void textBox10_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.fractionTb( e ,textBox10 );
        }
        private void textBox10_TextChanged ( object sender ,EventArgs e )
        {
            textBox11.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox6 ,textBox10 ) ) ,1 ).ToString( );
        }
        private void textBox10_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox10.Text != "" && !DateDay.eightSixTb( textBox10 ) )
            {
                this.textBox10.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多六位,如99.999999,请重新输入" );
            }
        }
        private void textBox15_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDay.intgra( e );
        }
        private void textBox13_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDay.intgra( e );
        }
        private void textBox12_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            //DateDay.intgra( e );
        }
        private void R_Frmzuzhanggongzikaohe_FormClosing ( object sender ,FormClosingEventArgs e )
        {
            if ( toolSave.Enabled )
                cancel( );
        }
        private void bandedGridView1_1_MouseDown ( object sender ,MouseEventArgs e )
        {
            //鼠标左键点击
            if ( e.Button == MouseButtons.Left )
            {
                GridHitInfo gridHitInfo = bandedGridView1.CalcHitInfo( e.X ,e.Y );

                //在列标题栏内且列标题name是自己需要的内容
                if ( gridHitInfo.InColumnPanel && gridHitInfo.Column.Name == "gridBand7" )
                {
                    //获取该列右边线的x坐标
                    GridViewInfo gridViewInfo = ( GridViewInfo ) this.bandedGridView1.GetViewInfo( );
                    int x = gridViewInfo.GetColumnLeftCoord( gridHitInfo.Column ) + gridHitInfo.Column.Width;
                    //右边线向左移动3个像素位置不弹出对话框（实验证明3个像素是正好的）
                    if ( e.X < x - 3 )
                    {
                        MessageBox.Show( "选中的列标题" );
                    }
                }
            }
        }
        #endregion

        #region TableOne
        void assignMent ( )
        {
            modelZa.QD001 = comboBox1.Text;
            modelZa.QD002 = dateTimePicker1.Value.ToString( "yyyyMM" );
            modelZa.QD003 = dateTimePicker1.Value.ToString( "MMdd" );
            modelZa.QD004 = string.IsNullOrEmpty( textBox14.Text ) == true ? 0 : Convert.ToDecimal( textBox14.Text );
            modelZa.QD005 = string.IsNullOrEmpty( textBox16.Text ) == true ? 0 : Convert.ToDecimal( textBox16.Text );
            modelZa.QD007 = string.IsNullOrEmpty( textBox1.Text ) == true ? 0 : Convert.ToDecimal( textBox1.Text );
            modelZa.QD008 = string.IsNullOrEmpty( textBox2.Text ) == true ? 0 : Convert.ToDecimal( textBox2.Text );
            modelZa.QD009 = string.IsNullOrEmpty( textBox4.Text ) == true ? 0 : Convert.ToDecimal( textBox4.Text );
            modelZa.QD011 = string.IsNullOrEmpty( textBox5.Text ) == true ? 0 : Convert.ToInt64( textBox5.Text );
            modelZa.QD012 = string.IsNullOrEmpty( textBox8.Text ) == true ? 0 : Convert.ToDecimal( textBox8.Text );
            modelZa.QD014 = string.IsNullOrEmpty( textBox6.Text ) == true ? 0 : Convert.ToDecimal( textBox6.Text );
            modelZa.QD015 = string.IsNullOrEmpty( textBox10.Text ) == true ? 0 : Convert.ToDecimal( textBox10.Text );
            modelZa.QD017 = string.IsNullOrEmpty( textBox12.Text ) == true ? 0 : Convert.ToDecimal( textBox12.Text );
            modelZa.QD018 = string.IsNullOrEmpty( textBox13.Text ) == true ? 0 : Convert.ToDecimal( textBox13.Text );
            modelZa.QD019 = string.IsNullOrEmpty( textBox15.Text ) == true ? 0 : Convert.ToDecimal( textBox15.Text );
        }
        //Build
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
                MessageBox.Show( "请选择组长" );
            else
            {
                assignMent( );
                result = false;
                result = bll.Exists( modelZa );
                if ( result == true )
                    MessageBox.Show( "组长姓名:" + modelZa.QD001 + "\n\r考察年月:" + modelZa.QD002 + "\n\r考察日期:" + modelZa.QD003 + "\n\r的记录已经存在,请核实后再录入" );
                else
                {
                    modelZa.Idx = bll.Add( modelZa );
                    if ( modelZa.Idx > 0 )
                    {
                        MessageBox.Show( "录入数据成功" );
                        strWhere = "1=1";
                        strWhere = strWhere + " AND QD074='" + modelZa.QD074 + "'";
                        tableQuery = bll.GetDataTable( strWhere );
                        gridControl1.DataSource = tableQuery;
                        calcuAll( );
                    }
                    else
                        MessageBox.Show( "录入数据失败" );
                }
            }
        }
        //Edit
        private void button2_Click( object sender, EventArgs e )
        {
            assignMent( );
            result = false;
            result = bll.Update( modelZa );
            if ( result == true )
            {
                MessageBox.Show( "编辑数据成功" );

                strWhere = "1=1";
                strWhere = strWhere + " AND QD074='" + modelZa.QD074 + "'";
                refres( );
            }
            else
                MessageBox.Show( "编辑数据失败" );
        }
        //Delete
        private void button3_Click( object sender, EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;
            result = false;
            modelZb.QD077 = modelZa.QD074;
            modelZb.QD079 = dateTimePicker1.Value.ToString( "yyyyMM" );
            modelZb.QD094 = dateTimePicker1.Value.ToString( "MMdd" );
            result = bll.ExistsIdxZb( modelZb );
            if ( result == true )
            {
                result = false;
                result = bll.Delete( modelZa.Idx ,modelZa.QD074 ,modelZb.QD079 ,modelZb.QD094 );
                if ( result == true )
                {
                    MessageBox.Show( "删除数据成功" );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND QD074='" + modelZa.QD074 + "'";
                    refres( );
                    tableQueryTwo = null;
                }
                else
                    MessageBox.Show( "删除数据失败" );
            }
            else
            {
                result = false;
                result = bll.DeleteIdxZa( modelZa.Idx );
                if ( result == true )
                {
                    MessageBox.Show( "删除数据成功" );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND QD074='" + modelZa.QD074 + "'";
                    refres( );
                    tableQueryTwo = null;
                }
                else
                    MessageBox.Show( "删除数据失败" );
            }
        }
        //Copy
        private void btnCopy_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( comboBox1 . Text ) )
                MessageBox . Show ( "请选择组长" );
            else
            {
                assignMent ( );
                result = false;
                result = bll . Exists ( modelZa );
                if ( result == true )
                    MessageBox . Show ( "组长姓名:" + modelZa . QD001 + "\n\r考察年月:" + modelZa . QD002 + "\n\r考察日期:" + modelZa . QD003 + "\n\r的记录已经存在,请核实后再录入" );
                else
                {
                    result = bll . Copy ( modelZa ,dateTime );
                    if ( result )
                    {
                        MessageBox . Show ( "录入数据成功" );
                        strWhere = "1=1";
                        strWhere = strWhere + " AND QD074='" + modelZa . QD074 + "'";
                        tableQuery = bll . GetDataTable ( strWhere );
                        gridControl1 . DataSource = tableQuery;
                        calcuAll ( );
                    }
                    else
                        MessageBox . Show ( "录入数据失败" );
                }
            }
        }
        //Refresh
        private void button4_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND QD074='" + modelZa.QD074 + "'";
            refres( );
        }
        void refres ( )
        {
            if ( string.IsNullOrEmpty( strWhere ) )
                strWhere = "1=1";
            tableQuery = bll.GetDataTable( strWhere );
            gridControl1.DataSource = tableQuery;
            calcuAll( );
        }
        void calcuAll ( )
        {
            //QD005 考勤日管人数列名   QD004  组长日考勤列名
            QD005 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( gridView1 . Columns [ "QD004" ] . Summary [ 1 ] . SummaryValue ) == 0 ? 0 : Convert . ToDecimal ( gridView1 . Columns [ "QD005" ] . Summary [ 0 ] . SummaryValue ) / Convert . ToDecimal ( gridView1 . Columns [ "QD004" ] . Summary [ 0 ] . SummaryValue ) ,1 ) . ToString ( ) );
            F01 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( gridView1 . Columns [ "QD004" ] . Summary [ 0 ] . SummaryValue ) == 0 ? 0 : Convert . ToDecimal ( gridView1 . Columns [ "F01" ] . Summary [ 0 ] . SummaryValue ) / Convert . ToDecimal ( gridView1 . Columns [ "QD004" ] . Summary [ 0 ] . SummaryValue ) ,1 ) . ToString ( ) );
            F02 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( gridView1 . Columns [ "QD004" ] . Summary [ 0 ] . SummaryValue ) == 0 ? 0 : Convert . ToDecimal ( gridView1 . Columns [ "F02" ] . Summary [ 0 ] . SummaryValue ) / Convert . ToDecimal ( gridView1 . Columns [ "QD004" ] . Summary [ 0 ] . SummaryValue ) ,1 ) . ToString ( ) );
        }
        private void button5_Click ( object sender ,EventArgs e )
        {
            DataTable da = bll.GetDataTableAll( );
            if ( da != null && da.Rows.Count > 0 )
            {
                textBox1.Text = da.Rows[0]["ZZ002"].ToString( );
                textBox2.Text = da.Rows[0]["ZZ003"].ToString( );
                textBox6.Text = da.Rows[0]["ZZ004"].ToString( );
                textBox10.Text = da.Rows[0]["ZZ005"].ToString( );
                textBox12.Text = da.Rows[0]["ZZ006"].ToString( );
                textBox13.Text = da.Rows[0]["ZZ007"].ToString( );
                textBox15.Text = da.Rows[0]["ZZ008"].ToString( );
            }
        }
        #endregion
        
        #region TableTwo
        void queryAuto ( )
        {
            if ( tableQuery != null && tableQuery.Rows.Count > 0 )
            {
                if ( tableQuery.Select( "QD003='" + dateTimePicker2.Value.ToString( "MMdd" ) + "'" ).Length < 1 )
                {
                    MessageBox.Show( "本月考勤记录中无:" + dateTimePicker2.Value.ToString( "MMdd" ) + "的数据" );
                    tableQueryTwo = null;                
                    gridControl2.DataSource = null;
                    return;
                }
            }
            strWhere = "1=1";
            strWhere = strWhere + " AND QD077='" + modelZa.QD074 + "' AND QD094='" + dateTimePicker2.Value.ToString( "MMdd" ) + "'";
            tableQueryTwo = bll.GetDataTableTwo( strWhere );
            tableQueryTwo.Columns.Add( "QU29" ,typeof( System.String ) );
            gridControl2.DataSource = tableQueryTwo;
            calcuTwo( );
        }
        private void dateTimePicker2_ValueChanged ( object sender ,EventArgs e )
        {
            queryAuto( );
        }
        //Save
        private void button7_Click ( object sender ,EventArgs e )
        {
            bandedGridView1.UpdateCurrentRow( );

            if ( tableQueryTwo != null )
            {
                DataRow row;
                for ( int i = 0 ; i < tableQueryTwo.Rows.Count ; i++ )
                {
                    row = tableQueryTwo.Rows[i];
                    row.BeginEdit( );
                    row["QD077"] = modelZa.QD074;
                    row["QD078"] = textBox7.Text;
                    row["QD079"] = dateTimePicker2.Value.ToString( "yyyyMM" );
                    row["QD094"] = dateTimePicker2.Value.ToString( "MMdd" );
                    row.EndEdit( );
                }
                modelZb.QD078 = textBox7.Text;
                modelZb.QD079 = dateTimePicker2.Value.ToString( "yyyyMM" );

                result = bll.UpdateTable( tableQueryTwo );
                if ( result == false )
                    MessageBox.Show( "保存数据失败,请重试" );
                else
                {
                    MessageBox.Show( "保存数据成功" );
                    queryAuto( );
                }
            }
        }
        //Read
        private void button8_Click ( object sender ,EventArgs e )
        {
            numAdd( );
            gridControl2.DataSource = tableQueryTwo;        
        }
        //Query
        private void button6_Click ( object sender ,EventArgs e )
        {
            queryAuto( );
        }
        private void bandedGridView1_InitNewRow ( object sender ,DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e )
        {
            bandedGridView1.AddNewRow( );
            bandedGridView1.UpdateCurrentRow( );
        }
        private void bandedGridView1_KeyDown ( object sender ,KeyEventArgs e )
        {
            if ( bandedGridView1.OptionsBehavior.Editable == true )
            {
                if ( e.KeyCode == Keys.Delete )
                {
                    int num = bandedGridView1.FocusedRowHandle;
                    if ( num >= 0 && num <= tableQueryTwo.Rows.Count - 1 )
                    {
                        modelZb.Idx = string.IsNullOrEmpty( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                        tableQueryTwo.Rows.RemoveAt( num );
                        gridControl2.DataSource = tableQueryTwo;
                        bll.DeleteZb( modelZb.Idx );
                    }
                }
            }
        }
        void saveTo ( )
        {
    
        }
        void lookAss ( string dateD )
        {
            bandedGridView1.UpdateCurrentRow( );
            if ( tableQueryTwo != null && tableQueryTwo.Rows.Count > 0 )
            {
                modelZb.QD094 = dd;
                saveTo( );
            }
            strWhere = "1=1";
            strWhere = strWhere + " AND QD077='" + modelZa.QD074 + "' AND QD094='"+dateD+"'";
            tableQueryTwo = bll.GetDataTableTwo( strWhere );            
            dd = dateTimePicker1.Value.ToString( "MMdd" );
        }
        void numAdd ( )
        {
            if ( tableQueryTwo == null )
            {
                queryAuto( );
            }
            if ( tableQuery != null )
            {
                if ( tableQuery.Select( "QD001='" + textBox7.Text + "'" ).Length < 1 )
                {
                    MessageBox.Show( "人员信息错误,请重新选择" );
                    return;
                }
            }
            modelZa.QD002 = dateTimePicker2.Value.ToString( "yyyyMM" );
            modelZa.QD001 = textBox7.Text;
            if ( modelZa.QD002 != null && modelZa.QD002.Length > 5 && modelZa.QD001 != null )
            {
                DataTable de = bll.GetDataTableDate( modelZa.QD002.Substring( 0 ,4 ) + "-" + modelZa.QD002.Substring( 4 ,2 ) ,modelZa.QD001 );
                if ( de != null && de.Rows.Count > 0 && tableQueryTwo != null )
                {
                    for ( int i = 0 ; i < de.Rows.Count ; i++ )
                    {
                        string str = de.Rows[i]["PQF01"].ToString( );
                        if ( tableQueryTwo.Select( "QD021='" + de.Rows[i]["PQF01"].ToString( ) + "'" ).Length <= 0 )
                        {
                            DataRow row = tableQueryTwo.NewRow( );
                            row["QD021"] = de.Rows[i]["PQF01"].ToString( );
                            row["QD095"] = de.Rows[i]["PQF04"].ToString( );
                            row["QD096"] = de.Rows[i]["PQF03"].ToString( );
                            if ( string.IsNullOrEmpty( de.Rows[i]["PQF32"].ToString( ) ) )
                                row["QD099"] = DBNull.Value;
                            else
                                row["QD099"] = Convert.ToDateTime( de.Rows[i]["PQF32"].ToString( ) );
                            if ( string.IsNullOrEmpty( de.Rows[i]["HT04"].ToString( ) ) )
                                row["QD104"] = DBNull.Value;
                            else
                                row["QD104"] = Convert.ToDateTime( de.Rows[i]["HT04"].ToString( ) );
                            if ( string.IsNullOrEmpty( de.Rows[i]["PQF31"].ToString( ) ) )
                                row["QD100"] = DBNull.Value;
                            else
                                row["QD100"] = Convert.ToDateTime( de.Rows[i]["PQF31"].ToString( ) );
                            row["QD098"] = de.Rows[i]["U1"].ToString( );
                            row["QD102"] = de.Rows[i]["U2"].ToString( );
                            row["QD103"] = string.IsNullOrEmpty( de.Rows[i]["AE28"].ToString( ) ) == true ? 0.ToString( ) : de.Rows[i]["AE28"].ToString( );
                            if ( string.IsNullOrEmpty( de.Rows[i]["AE21"].ToString( ) ) )
                                row["QD101"] = DBNull.Value;
                            else
                                row["QD101"] = Convert.ToDateTime( de.Rows[i]["AE21"].ToString( ) );

                            rowEdit( row );
                            tableQueryTwo.Rows.Add( row );
                        }
                        else
                        {

                            DataRow[] rows = tableQueryTwo.Select( "QD021='" + de.Rows[i]["PQF01"].ToString( ) + "'" );
                            DataRow row = rows[0];
                            row.BeginEdit( );
                            row["QD021"] = de.Rows[i]["PQF01"].ToString( );
                            row["QD095"] = de.Rows[i]["PQF04"].ToString( );
                            row["QD096"] = de.Rows[i]["PQF03"].ToString( );
                            if ( string.IsNullOrEmpty( de.Rows[i]["PQF32"].ToString( ) ) )
                                row["QD099"] = DBNull.Value;
                            else
                                row["QD099"] = Convert.ToDateTime( de.Rows[i]["PQF32"].ToString( ) );
                            if ( string.IsNullOrEmpty( de.Rows[i]["HT04"].ToString( ) ) )
                                row["QD104"] = DBNull.Value;
                            else
                                row["QD104"] = Convert.ToDateTime( de.Rows[i]["HT04"].ToString( ) );
                            if ( string.IsNullOrEmpty( de.Rows[i]["PQF31"].ToString( ) ) )
                                row["QD100"] = DBNull.Value;
                            else
                                row["QD100"] = Convert.ToDateTime( de.Rows[i]["PQF31"].ToString( ) );
                            row["QD098"] = de.Rows[i]["U1"].ToString( );
                            row["QD102"] = de.Rows[i]["U2"].ToString( );
                            row["QD103"] = string.IsNullOrEmpty( de.Rows[i]["AE28"].ToString( ) ) == true ? 0.ToString( ) : de.Rows[i]["AE28"].ToString( );
                            if ( string.IsNullOrEmpty( de.Rows[i]["AE21"].ToString( ) ) )
                                row["QD101"] = DBNull.Value;
                            else
                                row["QD101"] = Convert.ToDateTime( de.Rows[i]["AE21"].ToString( ) );
                            row.EndEdit( );
                        }
                    }
                }
            }
            modelZa.QD002 = null;
        }
        void rowEdit ( DataRow row )
        {
            DataTable da = bll.GetDataTableOfParameter( "R_501" );
            if ( da != null && da.Rows.Count > 0 )
            {
                row["QD022"] = da.Rows[0]["AY002"].ToString( );
                row["QD024"] = da.Rows[0]["AY003"].ToString( );
                row["QD026"] = da.Rows[0]["AY004"].ToString( );
                row["QD028"] = da.Rows[0]["AY005"].ToString( );
                row["QD030"] = da.Rows[0]["AY006"].ToString( );
                row["QD032"] = da.Rows[0]["AY007"].ToString( );
                row["QD034"] = da.Rows[0]["AY008"].ToString( );
                row["QD036"] = da.Rows[0]["AY009"].ToString( );
                row["QD038"] = da.Rows[0]["AY010"].ToString( );
                row["QD040"] = da.Rows[0]["AY011"].ToString( );
                row["QD042"] = da.Rows[0]["AY012"].ToString( );
                row["QD044"] = da.Rows[0]["AY013"].ToString( );
                row["QD046"] = da.Rows[0]["AY014"].ToString( );
                row["QD048"] = da.Rows[0]["AY015"].ToString( );
                row["QD050"] = da.Rows[0]["AY016"].ToString( );
                row["QD052"] = da.Rows[0]["AY017"].ToString( );
                row["QD054"] = da.Rows[0]["AY018"].ToString( );
                row["QD056"] = da.Rows[0]["AY019"].ToString( );
                row["QD058"] = da.Rows[0]["AY020"].ToString( );
                row["QD060"] = da.Rows[0]["AY021"].ToString( );
                row["QD062"] = da.Rows[0]["AY022"].ToString( );
                row["QD064"] = da.Rows[0]["AY023"].ToString( );
                row["QD066"] = da.Rows[0]["AY027"].ToString( );
                row["QD068"] = da.Rows[0]["AY024"].ToString( );
                row["QD070"] = da.Rows[0]["AY025"].ToString( );
                row["QD072"] = da.Rows[0]["AY026"].ToString( );
            }
            else
            {
                row["QD022"] = -1;
                row["QD024"] = 0;
                row["QD026"] = 2;
                row["QD028"] = 1;
                row["QD030"] = 1;
                row["QD032"] = 0.5;
                row["QD034"] = 0.5;
                row["QD036"] = 5;
                row["QD038"] = 1;
                row["QD040"] = 0.5;
                row["QD042"] = 10;
                row["QD044"] = 5;
                row["QD046"] = -2;
                row["QD048"] = 12;
                row["QD050"] = 8;
                row["QD052"] = 5;
                row["QD054"] = 2;
                row["QD056"] = 0.5;
                row["QD058"] = 4;
                row["QD060"] = 1;
                row["QD062"] = 10;
                row["QD064"] = 2;
                row["QD066"] = 0.3;
                row["QD068"] = -300;
                row["QD070"] = -10;
                row["QD072"] = 20;
            }          
        }
        void calcuTwo ( )
        {
            if ( tableQueryTwo != null && tableQueryTwo . Rows . Count > 0 )
            {
                QU01 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD023" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD022" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD022" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU02 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD025" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD024" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD024" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU03 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD027" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD026" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD026" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU04 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD029" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD028" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD028" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU05 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD031" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD030" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD030" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU06 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD033" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD032" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD032" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU07 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD035" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD034" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD034" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU08 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD037" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD036" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD036" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU09 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD039" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD038" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD038" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU10 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD041" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD040" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD040" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU11 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD043" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD042" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD042" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU12 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD045" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD044" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD044" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU13 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD047" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD046" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD046" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU14 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD049" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD048" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD048" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU15 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD051" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD050" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD050" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU16 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD053" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD052" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD052" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU17 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD055" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD054" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD054" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU18 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD057" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD056" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD056" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU19 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD059" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD058" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD058" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU20 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD061" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD060" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD060" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU21 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD063" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD062" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD062" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU22 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD065" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD064" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD064" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU23 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD023" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD022" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD022" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD025" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD024" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD024" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD027" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD026" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD026" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD029" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD028" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD028" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD031" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD030" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD030" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD033" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD032" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD032" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD035" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD034" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD034" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD037" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD036" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD036" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD039" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD038" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD038" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD041" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD040" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD040" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD043" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD042" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD042" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD045" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD044" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD044" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD047" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD046" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD046" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD049" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD048" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD048" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD051" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD050" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD050" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD053" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD052" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD052" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD055" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD054" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD054" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD057" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD056" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD056" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD059" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD058" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD058" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD061" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD060" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD060" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD063" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD062" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD062" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD065" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD064" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD064" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU24 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD067" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD066" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD066" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU25 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD069" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD068" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD068" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU26 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD071" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD070" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD070" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU27 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD073" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD072" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD072" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );
                QU28 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( bandedGridView1 . Columns [ "QD067" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD066" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD066" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD069" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD068" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD068" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD071" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD070" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD070" ] . ToString ( ) ) ) + Convert . ToDecimal ( bandedGridView1 . Columns [ "QD073" ] . Summary [ 0 ] . SummaryValue ) * ( string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( 0 ) [ "QD072" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( 0 ) [ "QD072" ] . ToString ( ) ) ) ,1 ) . ToString ( ) );



                DataTable dataTwoTable;
                modelZb . QD077 = modelZa . QD074;
                modelZb . QD079 = dateTimePicker1 . Value . ToString ( "yyyyMM" );
                dataTwoTable = bll . GetDataTableTwo ( modelZb );
                QD023 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "QD23" ] . ToString ( ) );
                QD025 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "QD25" ] . ToString ( ) );
                QD027 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "QD27" ] . ToString ( ) );
                QD029 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q29" ] . ToString ( ) );
                QD031 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q31" ] . ToString ( ) );
                QD033 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q33" ] . ToString ( ) );
                QD035 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q35" ] . ToString ( ) );
                QD037 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q37" ] . ToString ( ) );
                QD039 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q39" ] . ToString ( ) );
                QD041 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q41" ] . ToString ( ) );
                QD043 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q43" ] . ToString ( ) );
                QD045 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q45" ] . ToString ( ) );
                QD047 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q47" ] . ToString ( ) );
                QD049 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q49" ] . ToString ( ) );
                QD051 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q51" ] . ToString ( ) );
                QD053 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q53" ] . ToString ( ) );
                QD055 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q55" ] . ToString ( ) );
                QD057 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q57" ] . ToString ( ) );
                QD059 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q59" ] . ToString ( ) );
                QD061 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q61" ] . ToString ( ) );
                QD063 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q63" ] . ToString ( ) );
                QD065 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q65" ] . ToString ( ) );
                //QD067.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTwoTable.Rows[0]["Q67"].ToString( ) );
                //QD069.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTwoTable.Rows[0]["Q69"].ToString( ) );
                //QD071.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTwoTable.Rows[0]["Q71"].ToString( ) );
                //QD073.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTwoTable.Rows[0]["Q73"].ToString( ) );
                QU01 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q1" ] . ToString ( ) );
                QU02 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q2" ] . ToString ( ) );
                QU03 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q3" ] . ToString ( ) );
                QU04 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q4" ] . ToString ( ) );
                QU05 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q5" ] . ToString ( ) );
                QU06 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q6" ] . ToString ( ) );
                QU07 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q7" ] . ToString ( ) );
                QU08 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q8" ] . ToString ( ) );
                QU09 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q9" ] . ToString ( ) );
                QU10 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q10" ] . ToString ( ) );
                QU11 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q11" ] . ToString ( ) );
                QU12 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q12" ] . ToString ( ) );
                QU13 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q13" ] . ToString ( ) );
                QU14 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q14" ] . ToString ( ) );
                QU15 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q15" ] . ToString ( ) );
                QU16 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q16" ] . ToString ( ) );
                QU17 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q17" ] . ToString ( ) );
                QU18 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q18" ] . ToString ( ) );
                QU19 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q19" ] . ToString ( ) );
                QU20 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q20" ] . ToString ( ) );
                QU21 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q21" ] . ToString ( ) );
                QU22 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q22" ] . ToString ( ) );
                QU23 . Summary [ 2 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dataTwoTable . Rows [ 0 ] [ "Q23" ] . ToString ( ) );
                //QU24.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTwoTable.Rows[0]["Q24"].ToString( ) );
                //QU25.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTwoTable.Rows[0]["Q25"].ToString( ) );
                //QU26.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTwoTable.Rows[0]["Q26"].ToString( ) );
                //QU27.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTwoTable.Rows[0]["Q27"].ToString( ) );
                //QU28.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTwoTable.Rows[0]["Q28"].ToString( ) );

                DateTime dtOne, dtTwo;
                decimal dOne, dTwo;
                int count = 0, dayCount = 0;
                for ( int i = 0 ; i < bandedGridView1 . RowCount - 1 ; i++ )
                {
                    if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "QD100" ] . ToString ( ) ) /*&& !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["QD101"].ToString( ) )*/ /*&& !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["QD098"].ToString( ) )*/ /*&& !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["QD103"].ToString( ) )*/ )
                    {
                        dtOne = Convert . ToDateTime ( bandedGridView1 . GetDataRow ( i ) [ "QD100" ] . ToString ( ) );
                        dtTwo = String . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "QD101" ] . ToString ( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert . ToDateTime ( bandedGridView1 . GetDataRow ( i ) [ "QD101" ] . ToString ( ) );
                        dOne = String . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "QD098" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "QD098" ] . ToString ( ) );
                        dTwo = String . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "QD103" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "QD103" ] . ToString ( ) );
                        if ( ( dtOne - dtTwo ) . Days < 1 )
                        {
                            bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "QU29" ] ,( dtOne - dtTwo ) . Days );
                            count++;
                            dayCount = dayCount + ( dtOne - dtTwo ) . Days;
                        }
                        else
                        {
                            bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "QU29" ] ,( dtOne - dtTwo ) . Days );
                            if ( dOne - dTwo > 10 )
                            {
                                bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "QU29" ] ,"F" );
                                count++;
                            }
                        }
                    }
                }
                QU29 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,dayCount . ToString ( ) );
                QU29 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,count . ToString ( ) );

                DataTable dataOneTable;
                dataOneTable = bll . GetDataTableOne ( modelZa . QD074 );
                if ( dataOneTable != null && dataOneTable . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
                    {
                        modelZb . QD094 = gridView1 . GetDataRow ( i ) [ "QD003" ] . ToString ( );
                        gridView1 . SetRowCellValue ( i ,gridView1 . Columns [ "F03" ] ,dataOneTable . Select ( "QD094='" + modelZb . QD094 + "'" ) . Length > 0 == false ? 0 . ToString ( ) : dataOneTable . Select ( "QD094='" + modelZb . QD094 + "'" ) [ 0 ] [ "U1" ] . ToString ( ) );
                    }
                }

                F03 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( gridView1 . Columns [ "QD004" ] . Summary [ 0 ] . SummaryValue ) == 0 ? 0 : Convert . ToDecimal ( gridView1 . Columns [ "F03" ] . Summary [ 0 ] . SummaryValue ) / Convert . ToDecimal ( gridView1 . Columns [ "QD004" ] . Summary [ 0 ] . SummaryValue ) ,1 ) . ToString ( ) );
                F04 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( gridView1 . Columns [ "QD004" ] . Summary [ 0 ] . SummaryValue ) == 0 ? 0 : Convert . ToDecimal ( gridView1 . Columns [ "F04" ] . Summary [ 0 ] . SummaryValue ) / Convert . ToDecimal ( gridView1 . Columns [ "QD004" ] . Summary [ 0 ] . SummaryValue ) ,1 ) . ToString ( ) );
                F05 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( gridView1 . Columns [ "QD004" ] . Summary [ 0 ] . SummaryValue ) == 0 ? 0 : Convert . ToDecimal ( gridView1 . Columns [ "F04" ] . Summary [ 0 ] . SummaryValue ) / Convert . ToDecimal ( gridView1 . Columns [ "QD004" ] . Summary [ 0 ] . SummaryValue ) ,1 ) . ToString ( ) );
                F05 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( gridView1 . Columns [ "QD004" ] . Summary [ 0 ] . SummaryValue ) == 0 ? 0 : Convert . ToDecimal ( gridView1 . Columns [ "F04" ] . Summary [ 0 ] . SummaryValue ) / Convert . ToDecimal ( gridView1 . Columns [ "QD004" ] . Summary [ 0 ] . SummaryValue ) ,1 ) . ToString ( ) );
            }
        }
        private void MenuOne_ItemClicked ( object sender ,ToolStripItemClickedEventArgs e )
        {
            if ( ( e.ClickedItem ).Name == "MenuItemTwo" )
            {
            //    modelZb.QD094 = modelZa.QD003;
            //    lookAss( modelZb.QD094 );
            //}
            //else
            //{
                SelectAll.ZuZhangGongZiKaoHeOne zOne = new SelectAll.ZuZhangGongZiKaoHeOne( );
                zOne.sign = "1";
                zOne.StartPosition = FormStartPosition.CenterScreen;
                zOne.ShowDialog( );
            }
        }
        #endregion
        
        #region Main   
        protected override void add( )
        {
            base.add( );

            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;
            gridControl2.DataSource = null;
            Ergodic.FormEverySpliEnableTrue( this );
            saa = "1";
            label45.Visible = false;
            textBox17.Enabled = false;
            modelZa.QD074 = oddNumbers.purchaseContract( "SELECT MAX(AJ015) AJ015 FROM R_PQAJ" ,"AJ015" ,"R_501-" );

            bandedGridView1.OptionsBehavior.Editable = true;
            tableQueryTwo = null;
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void update( )
        {
            base.update( );

            result = false;
            result = bll.ExistsReview( modelZa.QD074 ,this.Text );

            if (result==true)
                MessageBox.Show( "单号:" + modelZa.QD074 + "的单据状态为执行,不允许更改" );
            else
            {
                Ergodic.FormEverySpliEnableTrue( this );
                toolSelect.Enabled = toolDelete.Enabled = toolAdd.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
                label45.Visible = false;
                textBox17.Enabled = false;
                bandedGridView1.OptionsBehavior.Editable = true;
                tableQueryTwo = null;

                //lookAss( modelZb.QD094 );
            }
        }
        protected override void delete ( )
        {
            base.delete( );

            if ( MessageBox.Show( "确认删除？" ,"删除" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
            {
                result = false;
                result = bll.ExistsReview( modelZa.QD074 ,this.Text );
                if ( result == true )
                    MessageBox.Show( "单号:" + modelZa.QD074 + "的单据状态为执行,不允许删除" );
                else
                {
                    result = false;
                    result = bll.DeleteTran( modelZa.QD074 );

                    if ( result == false )
                        MessageBox.Show( "删除数据失败" );
                    else
                    {
                        MessageBox.Show( "成功删除数据" );

                        Ergodic.FormEvery( this );
                        gridControl1.DataSource = null;
                        gridControl2.DataSource = null;
                        Ergodic.FormEverySpliEnableFalse( this );

                        toolSelect.Enabled = toolAdd.Enabled = true;
                        toolDelete.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolUpdate.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = false;
                        label45.Visible = false;
                        bandedGridView1.OptionsBehavior.Editable = false;
                        tableQueryTwo = null;
                    }
                }
            }
        }
        protected override void cancel( )
        {
            base.cancel( );

            if (saa == "1" && weihu != "1")
            {
                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;
                gridControl2.DataSource = null;
                Ergodic.FormEverySpliEnableFalse( this );

                toolSelect.Enabled = toolAdd.Enabled = true;
                toolDelete.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolUpdate.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = false;
                label45.Visible = false;
                bandedGridView1.OptionsBehavior.Editable = false;

                try
                {
                    bll.DeleteTran( modelZa.QD074 );
                    tableQueryTwo = null;
                }
                catch { }
            }
            else if (saa == "2" || weihu == "1")
            {
                Ergodic.FormEverySpliEnableFalse( this );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolUpdate.Enabled = toolcopy.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;

                bandedGridView1.OptionsBehavior.Editable = false;
            }
        }
        void state ( )
        {
            Ergodic.FormEverySpliEnableFalse( this );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
            bandedGridView1.OptionsBehavior.Editable = false;
            weihu = "";
            textBox1.Enabled = false;
        }
        protected override void save ( )
        {
            base.save( );

            if ( string.IsNullOrEmpty( comboBox1.Text ) )
                MessageBox.Show( "请选择组长姓名" );
            else
            {
                DataTable dql = bll.GetDataTableAll( modelZa.QD074 );
                if ( weihu == "1" )
                {
                    if ( string.IsNullOrEmpty( textBox17.Text ) )
                        MessageBox.Show( "请填写维护信息" );
                    else
                    {
                        if ( dql == null || dql.Rows.Count < 1 )
                            MessageBox.Show( "没有单号:" + modelZa.QD074 + "的信息,请核实后再维护" );
                        else
                        {
                            modelZa.QD076 = textBox17.Text;
                            modelZa.QD075 = dql.Rows[0]["QD075"].ToString( ) + "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";
                            result = false;
                            result = bll.UpdateWei( modelZa );
                            if ( result == false )
                                MessageBox.Show( "维护数据失败" );
                            else
                            {
                                MessageBox.Show( "成功维护数据" );
                                state( );
                                label45.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    modelZb.QD094 = dateTimePicker1.Value.ToString( "MMdd" );
                    saveTo( );
                    state( );
                    label45.Visible = false;
                }
            }
        }
        protected override void print( )
        {
            base.print( );
        }
        protected override void export( )
        {
            base.export( );
        }
        protected override void revirw( )
        {
            base.revirw( );

            Reviews( "QD074" ,modelZa.QD074 ,"R_PQZA" ,this ,"" ,"R_501" ,false ,false ,MulaolaoBll . Drity . GetDt ( )/*,"JM06" ,"JM87" ,"R_PQO" ,"JM01" ,JM01 ,ord ,textBox68.Text,"R_338"*/ );
            SpecialPowers sp = new SpecialPowers( );
            result = false;
            result = bll.ExistsReview( modelZa.QD074 ,this.Text );
            if ( result == true )
                label45.Visible = true;
            else
                label45.Visible = false;
        }
        string weihu = "";
        protected override void maintain( )
        {
            base.maintain( );

            result = false;
            result = bll.ExistsReview( modelZa.QD074 ,this.Text );
            if ( result == true )
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolUpdate.Enabled = toolcopy.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;

                textBox17.Enabled = true;

                weihu = "1";
                label45.Visible = true;
                bandedGridView1.OptionsBehavior.Editable = true;
            }
            else
                MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
        }
        #endregion

        #region  Query
        SelectAll.ZuZhangGongZiKaoHeAll query = new SelectAll.ZuZhangGongZiKaoHeAll( );
        protected override void select( )
        {
            base.select( );

            query.PassDataBetweenForm += new SelectAll.ZuZhangGongZiKaoHeAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.StartPosition = FormStartPosition.CenterScreen;
            query.ShowDialog( );

            if ( string.IsNullOrEmpty( modelZa.QD074 ) )
                MessageBox.Show( "您没有选择任何内容" );
            else
            {
                Ergodic.FormEverySpliEnableFalse( this );
                toolSelect.Enabled =  toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled =  toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
                saa = "2";
                textBox17.Enabled = false;

                tableQueryTwo = null;
                gridControl2.DataSource = null;
                strWhere = "1=1";
                strWhere = strWhere + " AND QD074='" + modelZa.QD074 + "'";
                refres( );

                //try
                //{
                //    modelZb.QD077 = modelZa.QD074;
                //    result = bll.UpdateTableOfDelete( modelZb );
                //}
                //catch { }
            }
        }
        private void query_PassDataBetweenForm( object sender, PassDataWinFormEventArgs e )
        {
            modelZa.QD074 = e.ConOne;
        }
        #endregion


        /*
        void perInf ( char x ,ref char y )
        {
            y = ( char ) ( x + y );
        }

        
        void test ( )
        {
            char x = 'A';
            char y = 'B';
            perInf ( x ,ref y );
            if ( y . ToString ( ) . Length > 0 )
            {
                string [ ] xy = y . ToString ( ) . Split ( '^' );
                foreach ( string s in xy )
                {
                    MessageBox . Show ( "" );
                }
            }
        }
        */
    }
}
