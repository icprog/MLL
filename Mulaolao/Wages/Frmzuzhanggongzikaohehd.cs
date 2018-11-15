using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Wages
{
    /*
     所有001产品的生产车间必须是前道组长，如果是后道组长，那么此处是读取不了的
         */
    public partial class Frmzuzhanggongzikaohehd : FormChild
    {
        public Frmzuzhanggongzikaohehd(  )
        {
            InitializeComponent( );
            //GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . gridView1,this.bandedGridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoBll.Bll.ZuZhangGongZiKaoHdBll bll = new MulaolaoBll.Bll.ZuZhangGongZiKaoHdBll( );
        MulaolaoLibrary.ZuZhangGongZiKaoHeHdAzLibrary modelAz = new MulaolaoLibrary.ZuZhangGongZiKaoHeHdAzLibrary( );
        MulaolaoLibrary.ZuZhangGongZiKaoHeBzLibrary modelBz = new MulaolaoLibrary.ZuZhangGongZiKaoHeBzLibrary( );
        DataTable tableQueryOne, tableQueryTwo, searCh;
        bool result = false;
        string saa = "", strWhere = "1=1", weihu = "", dd = "",dateTime=string.Empty;
        
        private void Frmzuzhanggongzikaohehd_Load( object sender, EventArgs e )
        {
            Power( this );

            Ergodic.FormEverySpliEnableFalse( this );
            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;
            gridControl2.DataSource = null;

            textBox1.Enabled = false;
            label45.Visible = false;

            bandedGridView1.OptionsBehavior.Editable = false;

            DataTable df = bll.GetDataTableName( );
            comboBox1.DataSource = df.DefaultView.ToTable( true ,"DBA002" );
            comboBox1.DisplayMember = "DBA002";

            comboBox2.DataSource = df.DefaultView.ToTable( true ,"DBA002" );
            comboBox2.DisplayMember = "DBA002";

            dateTimePicker2.Enabled = false;
        }
        
        #region Event
        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                if ( !string.IsNullOrEmpty( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) )
                {
                    modelAz.IDX = Convert.ToInt32( gridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                    assginMent( );
                }
            }
        }
        void assginMent ( )
        {
            modelAz = bll.GetModel( modelAz.IDX );
            comboBox1.Text = textBox18.Text = modelAz.HD001;
            comboBox2.Text = textBox17.Text = modelAz.HD094;
            if ( !string.IsNullOrEmpty( modelAz.HD003 ) )
                dateTimePicker1.Value = dateTimePicker2.Value = DateTime.ParseExact( modelAz.HD002 + modelAz.HD003.Substring( 2 ,2 ) ,"yyyyMMdd" ,System.Globalization.CultureInfo.CurrentCulture );
            textBox14.Text = modelAz.HD004.ToString( );
            textBox16.Text = modelAz.HD005.ToString( );
            textBox7.Text = modelAz.HD007.ToString( );
            textBox2.Text = modelAz.HD008.ToString( );
            textBox4.Text = modelAz.HD009.ToString( );
            textBox5.Text = modelAz.HD011.ToString( );
            textBox8.Text = modelAz.HD012.ToString( );
            textBox6.Text = modelAz.HD014.ToString( );
            textBox10.Text = modelAz.HD015.ToString( );
            textBox12.Text = modelAz.HD017.ToString( );
            textBox13.Text = modelAz.HD018.ToString( );
            textBox15.Text = modelAz.HD019.ToString( );
            dateTime = modelBz . HD080 = dateTimePicker1 . Value . ToString ( "MMdd" );
            //lookAss( modelBz.HD080 );
        }
        private void textBox14_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox14 );
        }
        private void textBox14_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox14 );
        }
        private void textBox14_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox14.Text != "" && !DateDayRegise.threeTwoNumTb( textBox14 ) )
            {
                this.textBox14.Text = "";
                MessageBox.Show( "只允许输入整数部分最多一位,小数部分最多两位,如9.99,请重新输入" );
            }
        }
        private void textBox16_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox16 );
        }
        private void textBox16_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox16 );
        }
        private void textBox16_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox16.Text != "" && !DateDayRegise.threeOneNumTb( textBox16 ) )
            {
                this.textBox16.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多一位,如99.9,请重新输入" );
            }
        }
        private void textBox7_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox7_TextChanged ( object sender ,EventArgs e )
        {
            textBox3.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox7 ,textBox2 ) ) ,0 ).ToString( );
        }
        private void textBox2_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox2_TextChanged ( object sender ,EventArgs e )
        {
            textBox3.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox7 ,textBox2 ) ) ,0 ).ToString( );
        }
        private void textBox4_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e,textBox4 );
        }
        private void textBox4_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox4 );
        }
        private void textBox4_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox4.Text != "" && !DateDayRegise.foreOneNum( textBox4 ) )
            {
                this.textBox4.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如999.9,请重新输入" );
            }
        }
        private void textBox5_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox5_TextChanged ( object sender ,EventArgs e )
        {
            textBox9.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox5 ,textBox8 ) ) ,1 ).ToString( );
        }
        private void textBox8_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox8 );
        }
        private void textBox8_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox8 );
            textBox9.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox5 ,textBox8 ) ) ,1 ).ToString( );
        }
        private void textBox8_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox8.Text != "" && !DateDayRegise.eightSixTb( textBox8 ) )
            {
                this.textBox8.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多六位,如99.999999,请重新输入" );
            }
        }
        private void textBox6_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox6_TextChanged ( object sender ,EventArgs e )
        {
            textBox11.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox6 ,textBox10 ) ) ,1 ).ToString( );
        }
        private void textBox10_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox10 );
        }
        private void textBox10_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox10 );
            textBox11.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTb( textBox6 ,textBox10 ) ) ,1 ).ToString( );
        }
        private void textBox10_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox10.Text != "" && !DateDayRegise.eightSixTb( textBox10 ) )
            {
                this.textBox10.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多六位,如99.999999,请重新输入" );
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
        private void textBox15_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void Frmzuzhanggongzikaohehd_FormClosing ( object sender ,FormClosingEventArgs e )
        {
            if ( toolSave.Enabled )
                cancel( );
        }
        #endregion

        #region TableOne
        void variable ( )
        {
            modelAz.HD001 = comboBox1.Text;
            modelAz.HD094 = comboBox2.Text;
            modelAz.HD002 = dateTimePicker1.Value.ToString( "yyyyMM" );
            modelAz.HD003 = dateTimePicker1.Value.ToString( "MMdd" );
            modelAz.HD004 = string.IsNullOrEmpty( textBox14.Text ) == true ? 0 : Convert.ToDecimal( textBox14.Text );
            modelAz.HD005 = string.IsNullOrEmpty( textBox16.Text ) == true ? 0 : Convert.ToDecimal( textBox16.Text );
            modelAz.HD007 = string.IsNullOrEmpty( textBox7.Text ) == true ? 0 : Convert.ToDecimal( textBox7.Text );
            modelAz.HD008 = string.IsNullOrEmpty( textBox2.Text ) == true ? 0 : Convert.ToDecimal( textBox2.Text );
            modelAz.HD009 = string.IsNullOrEmpty( textBox4.Text ) == true ? 0 : Convert.ToDecimal( textBox4.Text );
            modelAz.HD011 = string.IsNullOrEmpty( textBox5.Text ) == true ? 0 : Convert.ToInt32( textBox5.Text );
            modelAz.HD012 = string.IsNullOrEmpty( textBox8.Text ) == true ? 0 : Convert.ToDecimal( textBox8.Text );
            modelAz.HD014 = string.IsNullOrEmpty( textBox6.Text ) == true ? 0 : Convert.ToDecimal( textBox6.Text );
            modelAz.HD015 = string.IsNullOrEmpty( textBox10.Text ) == true ? 0 : Convert.ToDecimal( textBox10.Text );
            modelAz.HD017 = string.IsNullOrEmpty( textBox12.Text ) == true ? 0 : Convert.ToDecimal( textBox12.Text );
            modelAz.HD018 = string.IsNullOrEmpty( textBox13.Text ) == true ? 0 : Convert.ToDecimal( textBox13.Text );
            modelAz.HD019 = string.IsNullOrEmpty( textBox15.Text ) == true ? 0 : Convert.ToDecimal( textBox15.Text );
        }
        //Build
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
                MessageBox.Show( "组长姓名不可为空" );
            else
            {
                variable( );
                result = false;
                result = bll.ExistsAzAdd( modelAz );

                if ( result == true )
                    MessageBox.Show( "单号:" + modelAz.HD074 + "\n\r组长姓名:" + modelAz.HD001 + "\n\r年月:" + modelAz.HD002 + "\n\r日:" + modelAz.HD003 + "\n\r的记录已经存在,请核实后再录入" );
                else
                {
                    modelAz.IDX = bll.Add( modelAz );
                    if ( modelAz.IDX > 0 )
                    {
                        MessageBox.Show( "录入数据成功" );
                        strWhere = "1=1";
                        strWhere = strWhere + " AND HD074='" + modelAz.HD074 + "'";
                        refre( );
                    }
                    else
                        MessageBox.Show( "录入数据失败" );
                }
            }
        }
        //Edit
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
                MessageBox.Show( "组长姓名不可为空" );
            else
            {
                variable( );
                result = false;
                result = bll.Update( modelAz );
                if ( result == true )
                {
                    MessageBox.Show( "编辑数据成功" );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND HD074='" + modelAz.HD074 + "'";
                    refre( );
                }
                else
                    MessageBox.Show( "编辑数据失败" );
            }
        }
        //Delete
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;
            modelAz .HD002 = dateTimePicker1.Value.ToString( "yyyyMM" );
            modelAz.HD003 = dateTimePicker1.Value.ToString( "MMdd" );
            result = false;
            result = bll.Delete( modelAz );
            if ( result == true )
            {
                MessageBox.Show( "删除数据成功" );
                strWhere = "1=1";
                strWhere = strWhere + " AND HD074='" + modelAz.HD074 + "'";
                refre( );
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        //Copy
        private void btnCopy_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( comboBox1 . Text ) )
                MessageBox . Show ( "组长姓名不可为空" );
            else
            {
                variable ( );
                result = false;
                result = bll . ExistsAzAdd ( modelAz );

                if ( result == true )
                    MessageBox . Show ( "单号:" + modelAz . HD074 + "\n\r组长姓名:" + modelAz . HD001 + "\n\r年月:" + modelAz . HD002 + "\n\r日:" + modelAz . HD003 + "\n\r的记录已经存在,请核实后再录入" );
                else
                {
                    result = bll . Copy ( modelAz ,dateTime );
                    if ( result )
                    {
                        MessageBox . Show ( "录入数据成功" );
                        strWhere = "1=1";
                        strWhere = strWhere + " AND HD074='" + modelAz . HD074 + "'";
                        refre ( );
                    }
                    else
                        MessageBox . Show ( "录入数据失败" );
                }
            }
        }
        //Refresh
        private void button4_Click_1 ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND HD074='" + modelAz.HD074 + "'";
            refre( );
        }
        void refre ( )
        {
            if ( string.IsNullOrEmpty( strWhere ) )
                strWhere = "1=1";
            tableQueryOne = bll.GetDataTableAz( strWhere );
            gridControl1.DataSource = tableQueryOne;
            calcuAll( );
        }
        void calcuAll ( )
        {
            HD005 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( gridView1 . Columns [ "HD004" ] . Summary [ 1 ] . SummaryValue ) == 0 ? 0 : Convert . ToDecimal ( gridView1 . Columns [ "HD005" ] . Summary [ 0 ] . SummaryValue ) / Convert . ToDecimal ( gridView1 . Columns [ "HD004" ] . Summary [ 0 ] . SummaryValue ) ,1 ) . ToString ( ) );
            F01 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( gridView1 . Columns [ "HD004" ] . Summary [ 0 ] . SummaryValue ) == 0 ? 0 : Convert . ToDecimal ( gridView1 . Columns [ "F01" ] . Summary [ 0 ] . SummaryValue ) / Convert . ToDecimal ( gridView1 . Columns [ "HD004" ] . Summary [ 0 ] . SummaryValue ) ,2 ) . ToString ( ) );
            F02 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( gridView1 . Columns [ "HD004" ] . Summary [ 0 ] . SummaryValue ) == 0 ? 0 : Convert . ToDecimal ( gridView1 . Columns [ "F02" ] . Summary [ 0 ] . SummaryValue ) / Convert . ToDecimal ( gridView1 . Columns [ "HD004" ] . Summary [ 0 ] . SummaryValue ) ,2 ) . ToString ( ) );
        }
        private void button5_Click ( object sender ,EventArgs e )
        {
            DataTable da = bll.GetDataTableAll( );
            if ( da != null && da.Rows.Count > 0 )
            {
                textBox7.Text = da.Rows[0]["ZZ002"].ToString( );
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
            if ( tableQueryOne != null && tableQueryOne.Rows.Count > 0 )
            {
                if ( tableQueryOne.Select( "HD003='"+ dateTimePicker2.Value.ToString( "MMdd" ) + "'").Length < 1 )
                {
                    MessageBox.Show( "本月考核无:" + dateTimePicker2.Value.ToString( "MMdd" ) + "的数据" );
                    tableQueryTwo = null;
                    gridControl2.DataSource = null;
                    return;
                }
            }
            strWhere = "1=1";
            strWhere = strWhere + " AND HD077='" + modelAz.HD074 + "' AND HD080='" + dateTimePicker2.Value.ToString( "MMdd" ) + "'";
            tableQueryTwo = bll.GetDataTableBz( strWhere );
            tableQueryTwo.Columns.Add( "HU30" ,typeof( System.String ) );
            gridControl2.DataSource = tableQueryTwo;
            calcuAllBz( );
        }
        private void dateTimePicker2_ValueChanged ( object sender ,EventArgs e )
        {
            queryAuto( );
        }
        //Query
        private void button6_Click ( object sender ,EventArgs e )
        {
            queryAuto( );
        }
        //Read
        private void button8_Click ( object sender ,EventArgs e )
        {
            numAdd( );
            gridControl2.DataSource = tableQueryTwo;
        }
        //Save
        private void button7_Click ( object sender ,EventArgs e )
        {
            bandedGridView1.CancelUpdateCurrentRow( );
            if ( tableQueryTwo != null )
            {
                DataRow row;
                for ( int i = 0 ; i < tableQueryTwo.Rows.Count ; i++ )
                {
                    row = tableQueryTwo.Rows[i];
                    row.BeginEdit( );
                    row["HD077"] = modelAz.HD074;
                    row["HD078"] = textBox18.Text;
                    row["HD079"] = dateTimePicker2.Value.ToString( "yyyyMM" );
                    row["HD080"] = dateTimePicker2.Value.ToString( "MMdd" );
                    row.EndEdit( );
                }
                modelBz.HD078 = textBox18.Text;
                modelBz.HD079 = dateTimePicker2.Value.ToString( "yyyyMM" );
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
        private void bandedGridView1_KeyDown ( object sender ,KeyEventArgs e )
        {
            if ( bandedGridView1.OptionsBehavior.Editable == true )
            {
                if ( e.KeyCode == Keys.Delete )
                {
                    int num = bandedGridView1.FocusedRowHandle;
                    if ( num >= 0 && num <= tableQueryTwo.Rows.Count-1 )
                    {
                        modelBz.IDX = string.IsNullOrEmpty( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                        tableQueryTwo.Rows.RemoveAt( num );
                        gridControl2.DataSource = tableQueryTwo;
                        bll.DeleteBz( modelBz.IDX );
                    }
                }
            }
        }
        void saveTo ( )
        {
           

            #region
            /*
           if ( tableQueryTwo != null )
           {
               for ( int i = 0 ; i < tableQueryTwo.Rows.Count ; i++ )
               {
                   modelBz.HD021 = tableQueryTwo.Rows[i]["HD021"].ToString( );
                   modelBz.HD022 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD022"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD022"].ToString( ) );
                   modelBz.HD023 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD023"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD023"].ToString( ) );
                   modelBz.HD024 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD024"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD024"].ToString( ) );
                   modelBz.HD025 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD025"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD025"].ToString( ) );
                   modelBz.HD026 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD026"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD026"].ToString( ) );
                   modelBz.HD027 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD027"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD027"].ToString( ) );
                   modelBz.HD028 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD028"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD028"].ToString( ) );
                   modelBz.HD029 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD029"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD029"].ToString( ) );
                   modelBz.HD030 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD030"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD030"].ToString( ) );
                   modelBz.HD031 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD031"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD031"].ToString( ) );
                   modelBz.HD032 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD032"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD032"].ToString( ) );
                   modelBz.HD033 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD033"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD033"].ToString( ) );
                   modelBz.HD034 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD034"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD034"].ToString( ) );
                   modelBz.HD035 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD035"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD035"].ToString( ) );
                   modelBz.HD036 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD036"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD036"].ToString( ) );
                   modelBz.HD037 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD037"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD037"].ToString( ) );
                   modelBz.HD038 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD038"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD038"].ToString( ) );
                   modelBz.HD039 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD039"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD039"].ToString( ) );
                   modelBz.HD040 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD040"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD040"].ToString( ) );
                   modelBz.HD041 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD041"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD041"].ToString( ) );
                   modelBz.HD042 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD042"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD042"].ToString( ) );
                   modelBz.HD043 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD043"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD043"].ToString( ) );
                   modelBz.HD044 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD044"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD044"].ToString( ) );
                   modelBz.HD045 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD045"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD045"].ToString( ) );
                   modelBz.HD046 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD046"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD046"].ToString( ) );
                   modelBz.HD047 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD047"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD047"].ToString( ) );
                   modelBz.HD048 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD048"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD048"].ToString( ) );
                   modelBz.HD049 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD049"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD049"].ToString( ) );
                   modelBz.HD050 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD050"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD050"].ToString( ) );
                   modelBz.HD051 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD051"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD051"].ToString( ) );
                   modelBz.HD052 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD052"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD052"].ToString( ) );
                   modelBz.HD053 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD053"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD053"].ToString( ) );
                   modelBz.HD054 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD054"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD054"].ToString( ) );
                   modelBz.HD055 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD055"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD055"].ToString( ) );
                   modelBz.HD056 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD056"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD056"].ToString( ) );
                   modelBz.HD057 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD057"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD057"].ToString( ) );
                   modelBz.HD058 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD058"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD058"].ToString( ) );
                   modelBz.HD059 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD059"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD059"].ToString( ) );
                   modelBz.HD060 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD060"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD060"].ToString( ) );
                   modelBz.HD061 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD061"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD061"].ToString( ) );
                   modelBz.HD062 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD062"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD062"].ToString( ) );
                   modelBz.HD063 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD063"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD063"].ToString( ) );
                   modelBz.HD064 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD064"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD064"].ToString( ) );
                   modelBz.HD065 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD065"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD065"].ToString( ) );
                   modelBz.HD066 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD066"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD066"].ToString( ) );
                   modelBz.HD067 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD067"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD067"].ToString( ) );
                   modelBz.HD068 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD068"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD068"].ToString( ) );
                   modelBz.HD069 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD069"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD069"].ToString( ) );
                   modelBz.HD070 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD070"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD070"].ToString( ) );
                   modelBz.HD071 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD071"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD071"].ToString( ) );
                   modelBz.HD072 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD072"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD072"].ToString( ) );
                   modelBz.HD073 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD073"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["HD073"].ToString( ) );
                   if ( string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD084"].ToString( ) ) )
                       modelBz.HD084 = null;
                   else
                       modelBz.HD084 = Convert.ToDateTime( tableQueryTwo.Rows[i]["HD084"].ToString( ) );
                   if ( string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD085"].ToString( ) ) )
                       modelBz.HD085 = null;
                   else
                       modelBz.HD085 = Convert.ToDateTime( tableQueryTwo.Rows[i]["HD085"].ToString( ) );
                   if ( string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD088"].ToString( ) ) )
                       modelBz.HD088 = null;
                   else
                       modelBz.HD088 = Convert.ToDateTime( tableQueryTwo.Rows[i]["HD088"].ToString( ) );
                   if ( string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD089"].ToString( ) ) )
                       modelBz.HD089 = null;
                   else
                       modelBz.HD089 = Convert.ToDateTime( tableQueryTwo.Rows[i]["HD089"].ToString( ) );
                   modelBz.HD086 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD086"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD086"].ToString( ) );
                   modelBz.HD087 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD087"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD087"].ToString( ) );
                   modelBz.HD077 = modelAz.HD074;
                   modelBz.HD078 = comboBox1.Text;
                   modelBz.HD079 = dateTimePicker1.Value.ToString( "yyyyMM" );
                   modelBz.HD081 = tableQueryTwo.Rows[i]["HD081"].ToString( );
                   modelBz.HD082 = tableQueryTwo.Rows[i]["HD082"].ToString( );
                   modelBz.HD083 = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["HD083"].ToString( ) ) == true ? 0 : Convert.ToDecimal( tableQueryTwo.Rows[i]["HD083"].ToString( ) );
                   modelBz.IDX = string.IsNullOrEmpty( tableQueryTwo.Rows[i]["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( tableQueryTwo.Rows[i]["idx"].ToString( ) );

                   result = false;
                   result = bll.ExistsIdxBz( modelBz.IDX );
                   if ( result == true )
                   {
                       result = false;
                       result = bll.UpdateBz( modelBz );
                       if ( i == tableQueryTwo.Rows.Count - 1 )
                       {
                           tableQueryTwo = null;
                           break;
                       }
                   }
                   else
                   {
                       result = bll.AddBz( modelBz );
                       if ( i == tableQueryTwo.Rows.Count - 1 )
                       {
                           tableQueryTwo = null;
                           break;
                       }
                   }
               }
           }            */
            #endregion

        }
        void lookAss ( string dateD )
        {
            bandedGridView1.CancelUpdateCurrentRow( );
            if ( tableQueryTwo != null && tableQueryTwo.Rows.Count > 0 )
            {
                modelBz.HD080 = dd;
                saveTo( );
            }


            numAdd( );
            gridControl2.DataSource = tableQueryTwo;
            calcuAllBz( );
            dd = dateTimePicker1.Value.ToString( "MMdd" );
        }
        void calcuAllBz ( )
        {
            if ( tableQueryTwo != null && tableQueryTwo.Rows.Count > 0 )
            {
                HU01.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD023"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD022"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD022"].ToString( ) ) ),1 ).ToString( ) );
                HU02.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD025"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD024"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD024"].ToString( ) ) ),1 ).ToString( ) );
                HU03.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD027"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD026"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD026"].ToString( ) ) ),1 ).ToString( ) );
                HU04.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD029"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD028"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD028"].ToString( ) ) ) ,1).ToString( ) );
                HU05.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD031"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD030"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD030"].ToString( ) ) ) ,1).ToString( ) );
                HU06.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD033"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD032"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD032"].ToString( ) ) ) ,1).ToString( ) );
                HU07.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD035"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD034"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD034"].ToString( ) ) ) ,1 ) .ToString( ) );
                HU08.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD037"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD036"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD036"].ToString( ) ) ) ,1 ) .ToString( ) );
                HU09.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD039"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD038"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD038"].ToString( ) ) ) ,1 ) .ToString( ) );
                HU10.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD041"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD040"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD040"].ToString( ) ) ) ,1 ) .ToString( ) );
                HU11.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD043"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD042"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD042"].ToString( ) ) ) ,1 ) .ToString( ) );
                HU12.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD045"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD044"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD044"].ToString( ) ) ) ,1 ) .ToString( ) );
                HU13.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD047"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD046"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD046"].ToString( ) ) ) ,1 ) .ToString( ) );
                HU14.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD049"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD048"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD048"].ToString( ) ) ) ,1 ) .ToString( ) );
                HU15.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD051"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD050"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD050"].ToString( ) ) ) ,1 ) .ToString( ) );
                HU16.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD053"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD052"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD052"].ToString( ) ) ) ,1 ) .ToString( ) );
                HU17.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD055"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD054"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD054"].ToString( ) ) ) ,1 ) .ToString( ) );
                HU18.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD057"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD056"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD056"].ToString( ) ) ) ,1 ) .ToString( ) );
                HU19.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD059"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD058"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD058"].ToString( ) ) ) ,1 ) .ToString( ) );
                HU20.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD061"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD060"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD060"].ToString( ) ) ) ,1 ) .ToString( ) );
                HU21.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD063"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD062"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD062"].ToString( ) ) ) ,1 ) .ToString( ) );
                HU22.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD065"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD064"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD064"].ToString( ) ) ) ,1 ) .ToString( ) );
                HU23.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD023"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD022"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD022"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD025"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD024"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD024"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD027"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD026"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD026"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD029"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD028"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD028"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD031"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD030"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD030"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD033"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD032"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD032"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD035"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD034"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD034"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD037"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD036"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD036"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD039"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD038"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD038"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD041"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD040"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD040"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD043"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD042"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD042"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD045"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD044"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD044"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD047"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD046"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD046"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD049"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD048"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD048"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD051"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD050"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD050"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD053"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD052"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD052"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD055"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD054"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD054"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD057"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD056"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD056"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD059"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD058"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD058"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD061"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD060"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD060"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD063"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD062"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD062"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD065"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD064"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD064"].ToString( ) ) ) ,1 ) .ToString( ) );

                HU24.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD067"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD066"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD066"].ToString( ) ) ) ,1 ) .ToString( ) );
                HU25.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD069"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD068"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD068"].ToString( ) ) ) ,1 ) .ToString( ) );
                HU26.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD071"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD070"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD070"].ToString( ) ) ) ,1 ) .ToString( ) );
                HU27.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD073"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD072"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD072"].ToString( ) ) ) ,1 ) .ToString( ) );
                HU28.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,Math . Round ( Convert.ToDecimal( bandedGridView1.Columns["HD067"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD066"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD066"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD069"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD068"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD068"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD071"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD070"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD070"].ToString( ) ) ) + Convert.ToDecimal( bandedGridView1.Columns["HD073"].Summary[0].SummaryValue ) * ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( 0 )["HD072"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( 0 )["HD072"].ToString( ) ) ) ,1).ToString( ) );


                DataTable dataTableTwo;
                modelBz.HD077 = modelAz.HD074;
                modelBz.HD079 = dateTimePicker1.Value.ToString( "yyyyMM" );
                dataTableTwo = bll.GetDataTableTwo( modelBz );
                HD023.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H23"].ToString( ) );
                HD025.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H25"].ToString( ) );
                HD027.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H27"].ToString( ) );
                HD029.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H29"].ToString( ) );
                HD031.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H31"].ToString( ) );
                HD033.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H33"].ToString( ) );
                HD035.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H35"].ToString( ) );
                HD037.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H37"].ToString( ) );
                HD039.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H39"].ToString( ) );
                HD041.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H41"].ToString( ) );
                HD043.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H43"].ToString( ) );
                HD045.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H45"].ToString( ) );
                HD047.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H47"].ToString( ) );
                HD049.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H49"].ToString( ) );
                HD051.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H51"].ToString( ) );
                HD053.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H53"].ToString( ) );
                HD055.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H55"].ToString( ) );
                HD057.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H57"].ToString( ) );
                HD059.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H59"].ToString( ) );
                HD061.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H61"].ToString( ) );
                HD063.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H63"].ToString( ) );
                HD065.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H65"].ToString( ) );
                HU01.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["U1"].ToString( ) );
                HU02.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["U2"].ToString( ) );
                HU03.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["U3"].ToString( ) );
                HU04.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["U4"].ToString( ) );
                HU05.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["U5"].ToString( ) );
                HU06.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["U6"].ToString( ) );
                HU07.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["U7"].ToString( ) );
                HU08.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["U8"].ToString( ) );
                HU09.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["U9"].ToString( ) );
                HU10.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["U10"].ToString( ) );
                HU11.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["U11"].ToString( ) );
                HU12.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["U12"].ToString( ) );
                HU13.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["U13"].ToString( ) );
                HU14.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["U14"].ToString( ) );
                HU15.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["U15"].ToString( ) );
                HU16.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["U16"].ToString( ) );
                HU17.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["U17"].ToString( ) );
                HU18.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["U18"].ToString( ) );
                HU19.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["U19"].ToString( ) );
                HU20.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["U20"].ToString( ) );
                HU21.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["U21"].ToString( ) );
                HU22.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["U22"].ToString( ) );
                HU23.Summary[2].SetSummary( DevExpress.Data.SummaryItemType.Custom ,dataTableTwo.Rows[0]["H23"].ToString( ) );

                DateTime dtOne, dtTwo;
                decimal dOne, dTwo;
                int count = 0, yanCount = 0;
                for ( int i = 0 ; i < bandedGridView1.RowCount - 1 ; i++ )
                {
                    if ( !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["HD085"].ToString( ) ) )
                    {
                        dtOne = Convert.ToDateTime( bandedGridView1.GetDataRow( i )["HD085"].ToString( ) );
                        dtTwo = string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["HD088"].ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( bandedGridView1.GetDataRow( i )["HD088"].ToString( ) );
                        dOne = string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["HD083"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( i )["HD083"].ToString( ) );
                        dTwo = string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["HD087"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( i )["HD087"].ToString( ) );
                        if ( ( dtOne - dtTwo ).Days < 1 )
                        {
                            bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["HU30"] ,( dtOne - dtTwo ).Days );
                            count++;
                            yanCount = yanCount + ( dtOne - dtTwo ).Days;
                        }
                        else
                        {
                            bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["HU30"] ,( dtOne - dtTwo ).Days );
                            if ( dOne - dTwo > 10 )
                            {
                                bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["HU30"] ,"F" );
                                count++;
                            }
                        }
                    }
                }
                HU30.Summary[0].SetSummary( DevExpress.Data.SummaryItemType.Custom ,yanCount.ToString( ) );
                HU30.Summary[1].SetSummary( DevExpress.Data.SummaryItemType.Custom ,count.ToString( ) );

                DataTable dataTableOne;
                dataTableOne = bll.GetDataTableOne( modelAz.HD074 );
                if ( dataTableOne != null && dataTableOne.Rows.Count > 0 )
                {
                    for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                    {
                        modelBz.HD080 = gridView1.GetDataRow( i )["HD003"].ToString( );
                        gridView1.SetRowCellValue( i ,gridView1.Columns["F03"] ,dataTableOne.Select( "HD080='" + modelBz.HD080 + "'" ).Length > 0 == true ? dataTableOne.Select( "HD080='" + modelBz.HD080 + "'" )[0]["U1"].ToString( ) : 0.ToString( ) );
                    }
                }

                F03 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( gridView1 . Columns [ "HD004" ] . Summary [ 0 ] . SummaryValue ) == 0 ? 0 : Convert . ToDecimal ( gridView1 . Columns [ "F03" ] . Summary [ 0 ] . SummaryValue ) / Convert . ToDecimal ( gridView1 . Columns [ "HD004" ] . Summary [ 0 ] . SummaryValue ) ,2 ) . ToString ( ) );
                F04 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( gridView1 . Columns [ "HD004" ] . Summary [ 0 ] . SummaryValue ) == 0 ? 0 : Convert . ToDecimal ( gridView1 . Columns [ "F04" ] . Summary [ 0 ] . SummaryValue ) / Convert . ToDecimal ( gridView1 . Columns [ "HD004" ] . Summary [ 0 ] . SummaryValue ) ,2 ) . ToString ( ) );
                F05 . Summary [ 0 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( gridView1 . Columns [ "HD004" ] . Summary [ 0 ] . SummaryValue ) == 0 ? 0 : Convert . ToDecimal ( gridView1 . Columns [ "F04" ] . Summary [ 0 ] . SummaryValue ) / Convert . ToDecimal ( gridView1 . Columns [ "HD004" ] . Summary [ 0 ] . SummaryValue ) ,2 ) . ToString ( ) );
                F05 . Summary [ 1 ] . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( Convert . ToDecimal ( gridView1 . Columns [ "HD004" ] . Summary [ 0 ] . SummaryValue ) == 0 ? 0 : Convert . ToDecimal ( gridView1 . Columns [ "F04" ] . Summary [ 0 ] . SummaryValue ) / Convert . ToDecimal ( gridView1 . Columns [ "HD004" ] . Summary [ 0 ] . SummaryValue ) ,2 ) . ToString ( ) );
            }
        }
        void numAdd ( )
        {
            if ( tableQueryTwo == null )
            {
                queryAuto( );
            }
            if ( tableQueryOne != null )
            {
                if ( tableQueryOne.Select( "HD094='"+textBox17.Text+"'" ).Length < 1 )
                {
                    MessageBox.Show( "人员信息错误,请重新查询" );
                    return;
                }
            }
            modelAz.HD094 = textBox17.Text;
            modelAz.HD002 = dateTimePicker2.Value.ToString( "yyyyMM" );
            if ( modelAz.HD002 != null && modelAz.HD002.Length > 5 && modelAz.HD001!=null)
            {
                DataTable de = bll.GetDataTableDate( modelAz.HD002.Substring( 0 ,4 ) + "-" + modelAz.HD002.Substring( 4 ,2 ) ,modelAz.HD094 );
                if ( de != null && de.Rows.Count > 0 && tableQueryTwo != null )
                {
                    for ( int i = 0 ; i < de.Rows.Count ; i++ )
                    {
                        if ( tableQueryTwo.Select( "HD021='" + de.Rows[i]["PQF01"].ToString( ) + "'" ).Length <= 0 )
                        {
                            DataRow row = tableQueryTwo.NewRow( );
                            row["HD021"] = de.Rows[i]["PQF01"].ToString( );
                            row["HD081"] = de.Rows[i]["PQF04"].ToString( );
                            row["HD082"] = de.Rows[i]["PQF03"].ToString( );
                            if ( string.IsNullOrEmpty( de.Rows[i]["PQF32"].ToString( ) ) )
                                row["HD084"] = DBNull.Value;
                            else
                                row["HD084"] = Convert.ToDateTime( de.Rows[i]["PQF32"].ToString( ) );
                            if ( string.IsNullOrEmpty( de.Rows[i]["HT04"].ToString( ) ) )
                                row["HD089"] = DBNull.Value;
                            else
                                row["HD089"] = Convert.ToDateTime( de.Rows[i]["HT04"].ToString( ) );
                            if ( string.IsNullOrEmpty( de.Rows[i]["PQF31"].ToString( ) ) )
                                row["HD085"] = DBNull.Value;
                            else
                                row["HD085"] = Convert.ToDateTime( de.Rows[i]["PQF31"].ToString( ) );
                            row["HD086"] = de.Rows[i]["U2"].ToString( );
                            row["HD083"] = de.Rows[i]["U1"].ToString( );
                            row["HD087"] = string.IsNullOrEmpty( de.Rows[i]["AE28"].ToString( ) ) == true ? 0.ToString( ) : de.Rows[i]["AE28"].ToString( );
                            if ( string.IsNullOrEmpty( de.Rows[i]["AE21"].ToString( ) ) )
                                row["HD088"] = DBNull.Value;
                            else
                                row["HD088"] = Convert.ToDateTime( de.Rows[i]["AE21"].ToString( ) );
                            rowEdit( row );
                            tableQueryTwo.Rows.Add( row );
                        }
                        else
                        {
                            DataRow[] rows = tableQueryTwo.Select( "HD021='" + de.Rows[i]["PQF01"].ToString( ) + "'" );
                            DataRow row = rows[0];
                            row.BeginEdit( );
                            row["HD021"] = de.Rows[i]["PQF01"].ToString( );
                            row["HD081"] = de.Rows[i]["PQF04"].ToString( );
                            row["HD082"] = de.Rows[i]["PQF03"].ToString( );
                            row["HD083"] = de.Rows[i]["U1"].ToString( );
                            if ( string.IsNullOrEmpty( de.Rows[i]["PQF32"].ToString( ) ) )
                                row["HD084"] = DBNull.Value;
                            else
                                row["HD084"] = Convert.ToDateTime( de.Rows[i]["PQF32"].ToString( ) );
                            if ( string.IsNullOrEmpty( de.Rows[i]["HT04"].ToString( ) ) )
                                row["HD089"] = DBNull.Value;
                            else
                                row["HD089"] = Convert.ToDateTime( de.Rows[i]["HT04"].ToString( ) );
                            if ( string.IsNullOrEmpty( de.Rows[i]["PQF31"].ToString( ) ) )
                                row["HD085"] = DBNull.Value;
                            else
                                row["HD085"] = Convert.ToDateTime( de.Rows[i]["PQF31"].ToString( ) );
                            row["HD086"] = de.Rows[i]["U2"].ToString( );
                            row["HD083"] = de.Rows[i]["U1"].ToString( );
                            row["HD087"] = string.IsNullOrEmpty( de.Rows[i]["AE28"].ToString( ) ) == true ? 0.ToString( ) : de.Rows[i]["AE28"].ToString( );
                            if ( string.IsNullOrEmpty( de.Rows[i]["AE21"].ToString( ) ) )
                                row["HD088"] = DBNull.Value;
                            else
                                row["HD088"] = Convert.ToDateTime( de.Rows[i]["AE21"].ToString( ) );
                            row.EndEdit( );
                        }
                    }
                }
            }
        }
        void rowEdit ( DataRow row)
        {
            DataTable da = bll.GetDataTableOfParameter( "R_502" );
            if ( da != null && da.Rows.Count > 0 )
            {
                row["HD022"] = da.Rows[0]["AY002"].ToString( );
                row["HD024"] = da.Rows[0]["AY003"].ToString( );
                row["HD026"] = da.Rows[0]["AY004"].ToString( );
                row["HD028"] = da.Rows[0]["AY005"].ToString( );
                row["HD030"] = da.Rows[0]["AY006"].ToString( );
                row["HD032"] = da.Rows[0]["AY007"].ToString( );
                row["HD034"] = da.Rows[0]["AY008"].ToString( );
                row["HD036"] = da.Rows[0]["AY009"].ToString( );
                row["HD038"] = da.Rows[0]["AY010"].ToString( );
                row["HD040"] = da.Rows[0]["AY011"].ToString( );
                row["HD042"] = da.Rows[0]["AY012"].ToString( );
                row["HD044"] = da.Rows[0]["AY013"].ToString( );
                row["HD046"] = da.Rows[0]["AY014"].ToString( );
                row["HD048"] = da.Rows[0]["AY015"].ToString( );
                row["HD050"] = da.Rows[0]["AY016"].ToString( );
                row["HD052"] = da.Rows[0]["AY017"].ToString( );
                row["HD054"] = da.Rows[0]["AY018"].ToString( );
                row["HD056"] = da.Rows[0]["AY019"].ToString( );
                row["HD058"] = da.Rows[0]["AY020"].ToString( );
                row["HD060"] = da.Rows[0]["AY021"].ToString( );
                row["HD062"] = da.Rows[0]["AY022"].ToString( );
                row["HD064"] = da.Rows[0]["AY023"].ToString( );
                row["HD066"] = da.Rows[0]["AY024"].ToString( );
                row["HD068"] = da.Rows[0]["AY025"].ToString( );
                row["HD070"] = da.Rows[0]["AY026"].ToString( );
                row["HD072"] = da.Rows[0]["AY027"].ToString( );
            }
            else
            {
                row["HD022"] = -1;
                row["HD024"] = 0;
                row["HD026"] = 2;
                row["HD028"] = 1;
                row["HD030"] = 1;
                row["HD032"] = 4;
                row["HD034"] = 0.5;
                row["HD036"] = 0.5;
                row["HD038"] = 10;
                row["HD040"] = 5;
                row["HD042"] = 2;
                row["HD044"] = 1;
                row["HD046"] = -2;
                row["HD048"] = 12;
                row["HD050"] = 8;
                row["HD052"] = 5;
                row["HD054"] = 2;
                row["HD056"] = 0.5;
                row["HD058"] = 4;
                row["HD060"] = 1;
                row["HD062"] = 10;
                row["HD064"] = 2;
                row["HD066"] = 0.3;
                row["HD068"] = -300;
                row["HD070"] = -10;
                row["HD072"] = 20;
            }
        }
        private void contextMenuStripOne_ItemClicked ( object sender ,ToolStripItemClickedEventArgs e )
        {
            if ( ( e.ClickedItem ).Name == "MenuItemTwo" )
            {
            //    modelBz.HD080 = modelAz.HD003;
            //    lookAss( modelBz.HD080 );
            //}
            //if ( ( e.ClickedItem ).Name == "MenuItemTwo" )
            //{
                SelectAll.ZuZhangGongZiKaoHeOne zOne = new SelectAll.ZuZhangGongZiKaoHeOne( );
                zOne.sign = "2";
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

            textBox1.Enabled = false;
            label45.Visible = false;
            modelAz.HD074 = oddNumbers.purchaseContract( "SELECT MAX(AJ023) AJ023 FROM R_PQAJ" ,"AJ023" ,"R_502-" );

            bandedGridView1.OptionsBehavior.Editable = true;
            tableQueryTwo = null;
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            toolSave.Enabled = toolCancel.Enabled = true;
        }
        protected override void update( )
        {
            base.update( );

            result = false;
            result = bll.ExistsReview( modelAz.HD074 ,this.Text );
            if ( result == true )
                MessageBox.Show( "单号:" + modelAz.HD074 + "的单据状态为执行,不允许更改" );
            else
            {
                Ergodic.FormEverySpliEnableTrue( this );
                toolSelect.Enabled = toolDelete.Enabled = toolAdd.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
                label45.Visible = false;
                textBox1.Enabled = false;
                bandedGridView1.OptionsBehavior.Editable = true;
                tableQueryTwo = null;

                //lookAss( modelBz.HD080 );
            }
        }
        protected override void delete ( )
        {
            base.delete( );

            if ( MessageBox.Show( "确认删除？" ,"删除" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
            {
                result = false;
                result = bll.ExistsReview( modelAz.HD074 ,this.Text );
                if ( result == true )
                {
                    if ( Logins.number == "MLL-0001" )
                    {
                        result = bll.DeleteTran( modelAz.HD074 );

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
                    else
                        MessageBox.Show( "单号:" + modelAz.HD074 + "的单据状态为执行,不允许删除" );
                }
                else
                {
                    result = false;
                    result = bll.DeleteTran( modelAz.HD074 );

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

            if ( saa == "1" && weihu != "1" )
            {
                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;
                gridControl2.DataSource = null;

                toolSelect.Enabled = toolAdd.Enabled = true;
                toolDelete.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolUpdate.Enabled = toolcopy.Enabled = toolSave.Enabled = toolCancel.Enabled = false;
                saa = "";


                try
                {
                    bll.DeleteTran( modelAz.HD074 );
                    tableQueryTwo = null;
                }
                catch { }
            }
            else if ( saa == "2" || weihu == "1" )
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolUpdate.Enabled = true;
                toolPrint.Enabled = toolExport.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = false;
            }

            Ergodic.FormEverySpliEnableFalse( this );
            textBox1.Enabled = false;
        }
        void state ( )
        {
            Ergodic.FormEverySpliEnableFalse( this );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
            bandedGridView1.OptionsBehavior.Editable = false;
            weihu = "";
        }
        protected override void save( )
        {
            base.save( );

            if ( string.IsNullOrEmpty( comboBox1.Text ) )
                MessageBox.Show( "请选择组长姓名" );
            else
            {
                DataTable dr = bll.GetDataTableAll( modelAz.HD074 );

                if ( weihu == "1" )
                {
                    if ( string.IsNullOrEmpty( textBox1.Text ) )
                        MessageBox.Show( "请填写维护信息" );
                    else
                    {
                        if ( dr == null && dr.Rows.Count < 1 )
                            MessageBox.Show( "没有单号:" + modelAz.HD074 + "的信息,请核实后再维护" );
                        else
                        {
                            modelAz.HD075 = textBox1.Text;
                            modelAz.HD076 = dr.Rows[0]["HD076"].ToString( ) + "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";
                            result = false;
                            result = bll.UpdateWeiHu( modelAz );
                            if ( result == true )
                            {
                                MessageBox.Show( "成功维护数据" );
                                state( );
                                label45.Visible = true;
                            }
                            else
                                MessageBox.Show( "维护数据失败" );
                        }
                    }
                }
                else
                {
                    modelBz.HD080 = dateTimePicker1.Value.ToString( "MMdd" );
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

            Reviews( "HD074" ,modelAz.HD074 ,"R_PQAZ" ,this ,"" ,"R_502" ,false ,false,MulaolaoBll . Drity . GetDt ( )/*,"JM06" ,"JM87" ,"R_PQO" ,"JM01" ,JM01 ,ord ,textBox68.Text,"R_338"*/ );
            SpecialPowers sp = new SpecialPowers( );
            result = false;
            result = bll.ExistsReview( modelAz.HD074 ,this.Text );
            if ( result == true )
                label45.Visible = true;
            else
                label45.Visible = false;
        }
        protected override void maintain( )
        {
            base.maintain( );

            result = false;
            result = bll.ExistsReview( modelAz.HD074 ,this.Text );

            if ( result==true )
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolUpdate.Enabled = toolcopy.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;

                textBox1.Enabled = true;

                weihu = "1";
                label45.Visible = true;
            }
            else
                MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
        }
        #endregion

        #region Query
        SelectAll.ZuZhangGongZiKaoHeHdAll query = new SelectAll.ZuZhangGongZiKaoHeHdAll( );
        protected override void select( )
        {
            base.select( );
            
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.ZuZhangGongZiKaoHeHdAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );

            if ( string.IsNullOrEmpty( modelAz.HD074 ) )
                MessageBox.Show( "您没有选择任何内容" );
            else
            {
                Ergodic.FormEverySpliEnableFalse( this );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
                saa = "2";
                textBox1.Enabled = false;

                tableQueryTwo = null;
                gridControl2.DataSource = null;

                strWhere = "1=1";
                strWhere = strWhere + " AND HD074='" + modelAz.HD074 + "'";
                refre( );

                //try
                //{
                //    modelBz.HD077 = modelAz.HD074;
                //    result = bll.UpdateTableDelete( modelBz );
                //}
                //catch { }
            }
        }
        private void query_PassDataBetweenForm( object sender, PassDataWinFormEventArgs e )
        {
            modelAz.HD074 = e.ConOne;
        }
        #endregion
    }
}
