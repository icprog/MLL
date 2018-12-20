using StudentMgr;
using System;
using System . Data;
using System . Data . SqlClient;
using System . Linq;
using System . Windows . Forms;
using Mulaolao . Contract;
using Mulaolao . Class;
using Mulaolao . Bom;
using Mulaolao . Raw_material_cost;
using FastReport;
using FastReport . Export . Xml;
using Mulaolao . Schedule_control;
using Mulaolao . Other;
using Mulaolao . Contract . yesOrNoPlan;
using System . Collections . Generic;
using MulaolaoBll;
using System . Text;

namespace Mulaolao.Procedure
{
    public partial class R_FrmJiaomiducontract : FormChild
    {
        public R_FrmJiaomiducontract (/* Form1 fm */)
        {
            //this.MdiParent = fm;
            InitializeComponent( );

            Logins . tableNum = "R_338";
            Logins . tableName = this . Text;
            
            GridViewMoHuSelect . SetFilter ( bandedGridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this .bandedGridView1 } );
            UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoBll.Bll.JiaomiducontractBll bll = new MulaolaoBll.Bll.JiaomiducontractBll( );
        MulaolaoLibrary.JiaoMiDuContractLibrary model = new MulaolaoLibrary.JiaoMiDuContractLibrary( );
        bool result = false;
        DataTable grid;
        string saer = "", copy = "", file = "", strWhere = "1=1", weihu = "", numQu = "", stateOfOdd = "", conOne = "";
        Report report = new Report( );
        DataSet RDataSet;
        Factory fc = new Factory( ); SpecialPowers sp = new SpecialPowers( );
        yesOrNoPlanActual pc = new yesOrNoPlanActual( );
        DataTable biao, wl, name,libraryTable; List<string> strList = new List<string>( );
        //Dictionary<string ,string> dicStr = new Dictionary<string ,string>( );
        List<SplitContainer> spList = new List<SplitContainer>( );
        List<TabPage> pageList = new List<TabPage>( );
        List<string> speList = new List<string>( );
        
        private void R_FrmJiaomiducontract_Load ( object sender ,EventArgs e )
        {
            Power( this );

            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;
            spList.Clear( );
            spList.AddRange( new SplitContainer[] { splitContainer1 ,splitContainer2 } );
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableFalse( spList );
            pageList.Clear( );
            pageList.AddRange( new TabPage[] { tabPageOne ,tabPageTwo ,tabPageTre ,tabPageFor } );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableFalse( pageList );

            textBox3.Enabled = false;
            label107.Visible = false;
            label44.Visible = false;

            name = bll.GetDataTableProce( );
            lookUpEdit1.Properties.DataSource = name;
            lookUpEdit1.Properties.DisplayMember = "DBA002";
            lookUpEdit1.Properties.ValueMember = "DBA001";

            lookUpEdit2.Properties.DataSource = bll.GetDataTableWork( );
            lookUpEdit2.Properties.DisplayMember = "DBA002";
            lookUpEdit2.Properties.ValueMember = "DBA001";

            other( );

            if ( Logins.number == "MLL-0001" )
                checkBox6.Visible = true;
            else
                checkBox6.Visible = false;
        }
        
        private void R_FrmJiaomiducontract_Shown ( object sender ,EventArgs e )
        {
            model.JM01 = Merges.oddNum;
            if ( !string.IsNullOrEmpty( model.JM01 ) )
                autoQuery( );
            Merges.oddNum = "";
        }

        #region Print Explore
        private void Create ( )
        {
            RDataSet = new DataSet( );
            DataTable print = bll.GetDataTablePrintOne( model.JM01 );
            DataTable prints = bll.GetDataTablePrintTwo( model.JM01 );
            print.TableName = "R_PQO";
            prints.TableName = "R_PQOS";
            RDataSet.Tables.Add( print );
            RDataSet.Tables.Add( prints );
        }
        #endregion

        #region Event
        //货号
        private void comboBox9_TextChanged ( object sender ,EventArgs e )
        {
            model.JM102 = comboBox9.Text;
            wl = bll.GetDataTableNum( model.JM102 );
            table( );
            previousOfPrice( );
        }
        private void lookUpEdit3_EditValueChanged ( object sender ,EventArgs e )
        {
            previousOfPrice( );
        }
        void previousOfPrice ( )
        {
            if ( string.IsNullOrEmpty( comboBox9.Text ) || string.IsNullOrEmpty( lookUpEdit3.Text ) || string.IsNullOrEmpty( textBox84.Text ) || string.IsNullOrEmpty( textBox83.Text ) || string.IsNullOrEmpty( textBox85.Text ) )
                textBox20.Text = "0";
            else
            {
                decimal lon = string.IsNullOrEmpty( textBox84.Text ) == true ? 0 : Convert.ToDecimal( textBox84.Text );
                decimal wicth = string.IsNullOrEmpty( textBox83.Text ) == true ? 0 : Convert.ToDecimal( textBox83.Text );
                decimal high = string.IsNullOrEmpty( textBox85.Text ) == true ? 0 : Convert.ToDecimal( textBox85.Text );
                DataTable dm = bll.GetDataTableOfPrice( comboBox9.Text ,lookUpEdit3.Text ,lon ,wicth ,high );
                if ( dm != null && dm.Rows.Count > 0 )
                {
                    textBox20.Text = dm.Rows[0]["JM"].ToString( );
                    textBox21.Text = dm.Rows[0]["JM11"].ToString( );
                }
                else
                    textBox20.Text = textBox21.Text = "0";
            }
        }
        void calcuMj ( )
        {
            decimal d1 = string . IsNullOrEmpty ( textBox83 . Text ) == true ? 0 : Convert . ToDecimal ( textBox83 . Text );
            decimal d2 = string . IsNullOrEmpty ( textBox84 . Text ) == true ? 0 : Convert . ToDecimal ( textBox84 . Text );
            decimal d3 = string . IsNullOrEmpty ( textBox85 . Text ) == true ? 0 : Convert . ToDecimal ( textBox85 . Text );
            textBox61 . Text = ( d1 * d2 * d3 * Convert . ToDecimal ( "0.000001" ) ) . ToString ( "0.######" );
        }
        private void other ( )
        {
            DataTable other = bll.GetDataTableOther( );
            //甲方质检部选填人
            comboBox8.DataSource = other.DefaultView.ToTable( true ,"JM27" );
            comboBox8.DisplayMember = "JM27";
            //批次号
            comboBox15.DataSource = other.DefaultView.ToTable( true ,"JM29" );
            comboBox15.DisplayMember = "JM29";
            //签名
            comboBox16.DataSource = other.DefaultView.ToTable( true ,"JM31" );
            comboBox16.DisplayMember = "JM31";
            //甲方生产部选填人
            comboBox17.DataSource = other.DefaultView.ToTable( true ,"JM50" );
            comboBox17.DisplayMember = "JM50";
            //签名
            comboBox20.DataSource = other.DefaultView.ToTable( true ,"JM52" );
            comboBox20.DisplayMember = "JM52";
            //ICQ签字
            comboBox21.DataSource = other.DefaultView.ToTable( true ,"JM68" );
            comboBox21.DisplayMember = "JM68";
            //甲方签字
            comboBox18.DataSource = other.DefaultView.ToTable( true ,"JM69" );
            comboBox18.DisplayMember = "JM69";
            //乙方签字
            comboBox19.DataSource = other.DefaultView.ToTable( true ,"JM70" );
            comboBox19.DisplayMember = "JM70";
            //品牌
            comboBox1.DataSource = other.DefaultView.ToTable( true ,"JM92" );
            comboBox1.DisplayMember = "JM92";
            //E0级别
            comboBox14.DataSource = other.DefaultView.ToTable( true ,"JM93" );
            comboBox14.DisplayMember = "JM93";
        }
        private void table ( )
        {
            biao = bll.GetDataTableTable( model.JM102 );
            if ( wl != null && wl.Rows.Count >= 0 )
                biao.Merge( wl );
            //每张套数
            comboBox2.DataSource = biao.DefaultView.ToTable( true ,"JM10" );
            comboBox2.DisplayMember = "JM10";
            comboBox2 . Text = string . Empty;
            ////每张单价
            //textBox62.DataSource = biao.DefaultView.ToTable( true ,"JM11" );
            //textBox62.DisplayMember = "JM11";
            //每套用量
            comboBox12.DataSource = biao.DefaultView.ToTable( true ,"JM13" );
            comboBox12.DisplayMember = "JM13";
            comboBox12 . Text = string . Empty;
            //张余边尺寸
            comboBox5.DataSource = biao.DefaultView.ToTable( true ,"JM91" );
            comboBox5.DisplayMember = "JM91";
            comboBox5 . Text = string . Empty;

            lookUpEdit3.Properties.DataSource = biao.DefaultView.ToTable( true ,"JM09" );
            lookUpEdit3.Properties.DisplayMember = "JM09";
        }
        private void comboBox11_SelectedValueChanged ( object sender ,EventArgs e )
        {
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) && biao.Select( "JM09='" + lookUpEdit3.Text + "'" ).Length > 0 )
            {
                comboBox2.Text = biao.Select( "JM09='" + lookUpEdit3.Text + "'" )[0]["JM10"].ToString( );
                textBox62.Text = biao.Select( "JM09='" + lookUpEdit3.Text + "'" )[0]["JM11"].ToString( );
                textBox20.Text = biao.Select( "JM09='" + lookUpEdit3.Text + "'" )[0]["JM12"].ToString( );
                comboBox12.Text = biao.Select( "JM09='" + lookUpEdit3.Text + "'" )[0]["JM13"].ToString( );
                comboBox5.Text = biao.Select( "JM09='" + lookUpEdit3.Text + "'" )[0]["JM91"].ToString( );
                //comboBox1.Text = biao.Select( "JM09='" + lookUpEdit3.Text + "'" )[0]["JM92"].ToString( );
                //comboBox14.Text = biao.Select( "JM09='" + lookUpEdit3.Text + "'" )[0]["JM93"].ToString( );
                textBox84.Text = biao.Select( "JM09='" + lookUpEdit3.Text + "'" )[0]["JM94"].ToString( );
                textBox83.Text = biao.Select( "JM09='" + lookUpEdit3.Text + "'" )[0]["JM95"].ToString( );
                textBox85.Text = biao.Select( "JM09='" + lookUpEdit3.Text + "'" )[0]["JM96"].ToString( );
            }
        }
        //长
        private void textBox84_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox84 );
        }
        private void textBox84_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox84 );
            previousOfPrice( );
            calcuMj ( );
        }
        private void textBox84_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox84.Text != "" && !DateDayRegise.sixTwoNumber( textBox84 ) && Convert.ToDecimal( textBox84.Text ) > 0 )
            {
                this.textBox84.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多二位,如9999.99,请重新输入" );
            }

            DateDayRegise.fill( textBox84 );

        }
        //宽
        private void textBox83_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox83 );
        }
        private void textBox83_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox83 );
            previousOfPrice( );
            calcuMj ( );
        }
        private void textBox83_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox83.Text != "" && !DateDayRegise.sixTwoNumber( textBox83 ) && Convert.ToDecimal( textBox83.Text ) > 0 )
            {
                this.textBox83.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多二位,如9999.99,请重新输入" );
            }

            DateDayRegise.fill( textBox83 );

        }
        //高
        private void textBox85_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox85 );
        }
        private void textBox85_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox85 );
            previousOfPrice( );
            calcuMj ( );
        }
        private void textBox85_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox85.Text != "" && !DateDayRegise.sixTwoNumber( textBox85 ) && Convert.ToDecimal( textBox85.Text ) > 0 )
            {
                this.textBox85.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多二位,如9999.99,请重新输入" );
            }

            DateDayRegise.fill( textBox85 );

        }
        //成本员
        private void button12_Click ( object sender ,EventArgs e )
        {
            if ( textBox14.Text == "" )
                textBox14.Text = Logins.username;
            else if ( textBox14.Text != "" && textBox14.Text == Logins.username )
                textBox14.Text = "";
            dateTimePicker1 . Value = DateTime . Now;
        }
        //审批人
        private void button10_Click ( object sender ,EventArgs e )
        {
            if ( textBox53.Text == "" )
                textBox53.Text = Logins.username;
            else if ( textBox53.Text != "" && textBox53.Text == Logins.username )
                textBox53.Text = "";
            dateTimePicker12.Value = MulaolaoBll . Drity . GetDt ( );
        }
        //复核人
        private void button9_Click ( object sender ,EventArgs e )
        {
            if ( textBox54.Text == "" )
                textBox54.Text = Logins.username;
            else if ( textBox54.Text != "" && textBox54.Text == Logins.username )
                textBox54.Text = "";
            dateTimePicker11.Value = MulaolaoBll . Drity . GetDt ( );
        }
        //乙方代表
        private void button8_Click ( object sender ,EventArgs e )
        {
            if ( textBox55.Text == "" )
                textBox55.Text = Logins.username;
            else if ( textBox55.Text != "" && textBox55.Text == Logins.username )
                textBox55.Text = "";
            dateTimePicker10.Value = MulaolaoBll . Drity . GetDt ( );
        }
        //甲方代表
        private void button7_Click ( object sender ,EventArgs e )
        {

        }
        //开合同人
        private void button11_Click ( object sender ,EventArgs e )
        {
            if ( textBox13.Text == "" )
            {
                textBox13.Text = Logins.username;
                model.JM04 = textBox13.Text;

                string[] str = new string[2];
                str = oddNumbers.contractBatch( "R_PQO" ,model.JM04 ,textBox13 ,textBox15 ,"JM08" );
                if ( str[0] == "" )
                    textBox13.Text = "";
                else
                    model.JM08 = str[1];
                textBox15.Text = model.JM08;
            }
            else if ( textBox13.Text != "" && textBox13.Text == Logins.username )
            {
                textBox13.Text = "";
                model.JM04 = textBox13.Text;
                model.JM08 = "";
                textBox15.Text = "";
            }
            if ( textBox56.Text == "" )
                textBox56.Text = Logins.username;
            else if ( textBox56.Text != "" && textBox56.Text == Logins.username )
                textBox56.Text = "";

            dateTimePicker2 . Value = DateTime . Now;
        }
        //每张/套数
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
            if ( comboBox2.Text != "" && !DateDayRegise.ninFivTb( comboBox2 ) )
            {
                this.comboBox2.Text = "";
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
            if ( textBox21.Text != "" && !DateDayRegise.sevenFourTb( textBox21 ) )
            {
                this.textBox21.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多四位,如999.9999,请重新输入" );
            }
        }
        //每套用量
        private void comboBox12_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox12 );
        }
        private void comboBox12_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox12 );
        }
        private void comboBox12_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox12.Text != "" && !DateDayRegise.tenForNumber( comboBox12 ) )
            {
                this.comboBox12.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多四位,如999.9999,请重新输入" );
            }
        }
        //部件数量
        private void comboBox3_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //张余边尺寸
        private void comboBox5_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox5 );
        }
        private void comboBox5_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox5 );
        }
        private void comboBox5_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox5.Text != "" && !DateDayRegise.threeTwoNum( comboBox5 ) )
            {
                this.comboBox5.Text = "";
                MessageBox.Show( "只允许输入整数部分最多一位,小数部分最多两位,如9.99,请重新输入" );
            }
        }
        private void textBox59_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise . textChangeTb ( textBox59 );
            calcuPrice ( );
        }
        private void textBox60_TextChanged ( object sender ,EventArgs e )
        {
            //calcuPrice ( );
        }
        private void textBox61_TextChanged ( object sender ,EventArgs e )
        {
            calcuPrice ( );
        }
        void calcuPrice ( )
        {
            if ( string . IsNullOrEmpty ( textBox60 . Text ) )
                return;
            if ( string . IsNullOrEmpty ( textBox61 . Text ) )
                return;
            decimal ld = Convert . ToDecimal ( textBox60 . Tag );
            decimal lz = Convert . ToDecimal ( textBox61 . Text );
            decimal yd = string . IsNullOrEmpty ( textBox59 . Text ) == true ? 0 : Convert . ToDecimal ( textBox59 . Text );
            textBox60 . Text = ( ld + yd ) . ToString ( "0.##" );
            ld = Convert . ToDecimal ( textBox60 . Text );
            textBox62 . Text = Convert . ToDecimal ( ld * lz ) . ToString ( "0.##" );
        }
        private void textBox59_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise . fractionTb ( e ,textBox59 );
        }
        private void textBox59_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox59 . Text != "" && !DateDayRegise . eighteenSixNumber ( textBox59 ) )
            {
                this . textBox59 . Text = "";
                MessageBox . Show ( "只允许输入整数部分最多十二位,小数部分最多六位,如999999999999.999999,请重新输入" );
            }
        }
        //抽查数量
        private void textBox52_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //AQL
        private void textBox42_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox43_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox44_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox41_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox45_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox46_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox47_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox48_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox49_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //string sti;
        //采购人
        private void lookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit1.EditValue != null )
            {
                model.JM02 = lookUpEdit1.EditValue.ToString( );
                textBox5.Text = name.Select( "DBA001='" + model.JM02 + "'" )[0]["DBA028"].ToString( );
            }
            //DataTable dli = SqlHelper.ExecuteDataTable( "SELECT DBA028 FROM TPADBA WHERE DBA001=@DBA001" ,new SqlParameter( "@DBA001" ,JM02 ) );
            //if ( dli.Rows.Count < 1 )
            //    textBox5.Text = "";
            //else
            //    textBox5.Text = dli.Rows[0]["DBA028"].ToString( );
        }
        //乙方
        private void textBox19_TextChanged ( object sender ,EventArgs e )
        {
            //DataTable del = SqlHelper.ExecuteDataTable( "SELECT DGA003,DGA008,DGA011,DGA017,DGA009,DGA012 FROM TPADGA WHERE DGA001=@DGA001", new SqlParameter( "@DGA001",model.JM03 ) );
            //if (del.Rows.Count > 0)
            //{
            //    textBox19.Text = del.Rows[0]["DGA003"].ToString( );
            //    textBox6.Text = del.Rows[0]["DGA017"].ToString( );
            //    textBox7.Text = del.Rows[0]["DGA008"].ToString( );
            //    textBox8.Text = del.Rows[0]["DGA012"].ToString( );
            //    textBox9.Text = del.Rows[0]["DGA009"].ToString( );
            //    textBox10.Text = del.Rows[0]["DGA011"].ToString( );
            //}
        }
        //表
        string pm9 = "";
        decimal jm094 = 0M, jm095 = 0M, jm096 = 0M;
        private void bandedGridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( bandedGridView1.FocusedRowHandle >= 0 && bandedGridView1.FocusedRowHandle <= bandedGridView1.RowCount - 1 )
            {
                model.IDX = string.IsNullOrEmpty( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetFocusedRowCellValue( "idx" ).ToString( ) );
                assignMent( );
                dateTimePicker4.Value = string.IsNullOrEmpty( bandedGridView1.GetFocusedRowCellValue( "JM17" ).ToString( ) ) == true ? MulaolaoBll . Drity . GetDt ( ) : Convert.ToDateTime( bandedGridView1.GetFocusedRowCellValue( "JM17" ).ToString( ) );
            }
        }
        void assignMent ( )
        {
            model = bll . GetModel ( model . IDX );
            if ( model == null )
                return;
            comboBox2 . Text = model . JM10 . ToString ( "0.######" );
            textBox62 . Text = model . JM11 . ToString ( "0.##" );
            comboBox12 . Text = model . JM13 . ToString ( "0.######" );
            //if ( model.JM16.ToString( ) != "0001/1/1 0:00:00" && model.JM16.ToString( ) != "0001-1-1 0:00:00" && model.JM16.ToString( ) != "0001.1.1 0:00:00" )
            //    dateTimePicker3.Value = model.JM16;
            if ( model . JM16 > DateTime . MinValue && model . JM16 < DateTime . MaxValue )
                dateTimePicker3 . Value = model . JM16;
            comboBox5 . Text = model . JM91 . ToString ( "0.######" );
            comboBox1 . Text = model . JM92;
            comboBox14 . Text = model . JM93;
            textBox84 . Text = model . JM94 . ToString ( );
            textBox83 . Text = model . JM95 . ToString ( );
            textBox85 . Text = model . JM96 . ToString ( );
            lookUpEdit3 . Text = model . JM09;
            if ( model . JM14 . Trim ( ) == "库存" )
            {
                radioButton15 . Checked = true;
                textBox1 . Text = model . JM15 . ToString ( );
                radioButton15_CheckedChanged ( null ,null );
            }
            else if ( model . JM14 . Trim ( ) == "外购" )
            {
                radioButton16 . Checked = true;
                textBox11 . Text = model . JM104 . ToString ( );
                radioButton16_CheckedChanged ( null ,null );
            }
            if ( string . IsNullOrEmpty ( textBox21 . Text ) || Convert . ToDecimal ( textBox21 . Text ) <= 0 )
                textBox21 . Text = model . JM112 . ToString ( );
            if ( string . IsNullOrEmpty ( textBox20 . Text ) || Convert . ToDecimal ( textBox20 . Text ) <= 0 )
                textBox20 . Text = model . JM12 . ToString ( );
            textBox58 . Text = model . JM118 . ToString ( "0.######" );
            textBox59 . Text = textBox61 . Text = 0 . ToString ( );
            textBox59 . Text = Convert . ToDecimal ( model . JM119 ) . ToString ( "0.######" );
            textBox60 . Tag = textBox60 . Text = Convert . ToDecimal ( model . JM120 ) . ToString ( "0.##" );
            textBox61 . Text = Convert . ToDecimal ( model . JM121 ) . ToString ( "0.######" );
            pm9 = model . JM09;
            jm094 = model . JM94;
            jm095 = model . JM95;
            jm096 = model . JM96;
        }
        private void bandedGridView1_CustomColumnDisplayText ( object sender ,DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e )
        {
            for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
            {
                if ( string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["JM15"].ToString( ) ) )
                    bandedGridView1.GetDataRow( i )["JM15"] = 0;
            }
        }
        //窗体关闭
        private void R_FrmJiaomiducontract_FormClosing ( object sender ,FormClosingEventArgs e )
        {
            if ( toolSave.Enabled )
            {
                cancel( );
            }
        }
        //使用库存
        private void radioButton15_CheckedChanged ( object sender ,EventArgs e )
        {
            if ( radioButton15.Checked && ( ord == "实际" || !string.IsNullOrEmpty( textBox68.Text ) ) )
            {
                fc.yesOrNoOf( comboBox9.Text ,lookUpEdit3.Text ,textBox84.Text + "*" + textBox83.Text + "*" + textBox85.Text ,textBox12 ,textBox18 ,textBox71.Text );
                
                textBox11.Text = Math.Round( Convert.ToDecimal( Operation.MultiThrTbCb( textBox71 ,comboBox2 ,textBox12.Text ) ) ,0 ).ToString( );

                //if ( !string.IsNullOrEmpty( textBox12.Text ) || textBox12.Text != "0" )
                //    textBox1.Text = 0.ToString( );
                //else
                textBox1.Text = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox71 ,comboBox2 ) ) ,0 ).ToString( );
            }
        }
        //使用外购
        private void radioButton16_CheckedChanged ( object sender ,EventArgs e )
        {
            if ( radioButton16.Checked && ( ord == "实际" || !string.IsNullOrEmpty( textBox68.Text ) ) )
                get( );
            else
            {
                fc.yesOrNoOf( comboBox9.Text ,lookUpEdit3.Text ,textBox84.Text + "*" + textBox83.Text + "*" + textBox85.Text ,textBox12 ,textBox18 ,textBox71.Text );
                textBox11.Text = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox71 ,comboBox2 ) ) ,0 ).ToString( );
            }

        }
        void get ( )
        {
            string str = "";
            model.JM102 = comboBox9.Text;
            model.JM09 = lookUpEdit3.Text;
            if ( string.IsNullOrEmpty( textBox84.Text ) )
                model.JM94 = 0;
            else
                model.JM94 = Convert.ToDecimal( textBox84.Text );
            if ( string.IsNullOrEmpty( textBox83.Text ) )
                model.JM95 = 0;
            else
                model.JM95 = Convert.ToDecimal( textBox83.Text );
            if ( string.IsNullOrEmpty( textBox85.Text ) )
                model.JM96 = 0;
            else
                model.JM96 = Convert.ToDecimal( textBox85.Text );
            //AC16=@AC16 AND
            StringBuilder strSql = new StringBuilder ( );

            DataTable del = SqlHelper.ExecuteDataTable( "SELECT AC10+ISNULL(AC27,0)-ISNULL(SUM(AD12+ISNULL(AD21,0)),0) AC10 FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=convert(varchar(10),@JM94)+'*'+convert(varchar(10),@JM95)+'*'+convert(varchar(10),@JM96) GROUP BY AC10,ISNULL(AC27,0) HAVING AC10+ISNULL(AC27,0)- ISNULL (SUM(AD12+ISNULL(AD21,0)),0)>=1" ,new SqlParameter( "@AC02" ,model.JM102 ) ,new SqlParameter( "@AC04" ,model.JM09 ) ,new SqlParameter( "@JM94" ,model.JM94 ) ,new SqlParameter( "@JM95" ,model.JM95 ) ,new SqlParameter( "@JM96" ,model.JM96 ) );
            if ( del.Rows.Count < 1 )
                str = "0";
            else if ( string.IsNullOrEmpty( del.Rows[0]["AC10"].ToString( ) ) )
                str = "0";
            else
                str = del.Rows[0]["AC10"].ToString( );
            //怎么读取库存数量
            textBox11.Text = Math.Round( Convert.ToDecimal( Operation.MultiThrTbCb( textBox71 ,comboBox2 ,str ) ) ,0 ).ToString( );
        }
        //产品数量
        private void textBox71_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //使用外购数量
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
            if ( textBox11.Text != "" && !DateDayRegise.eightTwoNumber( textBox11 ) )
            {
                this.textBox11.Text = "";
                MessageBox.Show( "只允许输入整数部分最多六位,小数部分最多两位,如999999.99,请重新输入" );
            }
        }
        //使用库存数量
        private void textBox1_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox1 );
        }
        private void textBox1_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox1 );
        }
        private void textBox1_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox1.Text != "" && !DateDayRegise.eightTwoNumber( textBox1 ) )
            {
                this.textBox1.Text = "";
                MessageBox.Show( "只允许输入整数部分最多六位,小数部分最多两位,如999999.99,请重新输入" );
            }
        }
        //每套零件数量
        private void textBox18_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //产品名称
        private void comboBox7_SelectedValueChanged ( object sender ,EventArgs e )
        {
            if ( ord == "计划" || string.IsNullOrEmpty( textBox68.Text ) )
            {
                if ( !string.IsNullOrEmpty( comboBox7.Text ) )
                    comboBox9.Text = comboBox7.SelectedValue.ToString( );
            }
        }
        private void textBox58_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise . intgra ( e );
        }
        #endregion

        #region Main
        //Reviews
        protected override void revirw ( )
        {
            base.revirw( );
            bool result = false, over = false;
            if ( textBox53.Text == "廖灵飞" )
                result = true;
            else
                result = false;
            if ( string.IsNullOrEmpty( textBox14.Text ) )
                over = false;
            else
                over = true;
            Reviews( "JM01" ,model.JM01 ,"R_PQO" ,this ,model.JM90 ,"R_338" ,result ,over,null/*,"JM06" ,"JM87" ,"R_PQO" ,"JM01" ,JM01 ,ord ,textBox68.Text,"R_338"*/ );
            
            result = false;
            result = sp.reviewImple( "R_338" ,model.JM01 );
            if ( result == true )
            {
                label107.Visible = true;
                try
                {
                    SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfCopy( "R_PQOC" ,"R_PQO" ,"JM01" ,model.JM01 ) );
                    WriteOfReceivablesTo( );
                }
                catch { }
            }
            else
                label107.Visible = false;
        }
        void WriteOfReceivablesTo ( )
        {
            DataTable receiva;
            MulaolaoLibrary.ProductCostSummaryLibrary modelAm = new MulaolaoLibrary.ProductCostSummaryLibrary( );
            receiva = bll.GetDataTableOfReceviable( model.JM01 );
            if ( receiva != null && receiva.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < receiva.Rows.Count ; i++ )
                {
                    modelAm.AM002 = receiva.Rows[i]["JM90"].ToString( );

                    modelAm.AM296 = modelAm.AM298 = modelAm.AM300 = modelAm.AM301 = modelAm.AM304 = modelAm.AM306 = modelAm.AM307 = modelAm.AM311 = modelAm.AM313 = modelAm.AM315 = modelAm.AM318 = modelAm.AM320 = modelAm.AM321 = modelAm.AM324 = modelAm.AM326 = modelAm.AM328 = 0;

                    modelAm.AM298 = string.IsNullOrEmpty( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='F'" ) );
                    modelAm.AM300 = string.IsNullOrEmpty( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='外购' AND JM107='T'" ) );

                    modelAm.AM307 = string.IsNullOrEmpty( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='F'" ) );
                    modelAm.AM320 = string.IsNullOrEmpty( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='外购' AND JM107='T'" ) );

                    modelAm.AM301 = string.IsNullOrEmpty( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='F'" ) );
                    modelAm.AM306 = string.IsNullOrEmpty( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='外购' AND JM107='T'" ) );

                    modelAm.AM311 = string.IsNullOrEmpty( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='F'" ) );
                    modelAm.AM324 = string.IsNullOrEmpty( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='外购' AND JM107='T'" ) );

                    modelAm.AM304 = string.IsNullOrEmpty( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='F'" ) );
                    modelAm.AM313 = string.IsNullOrEmpty( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '胶合板' and JM93='E0' and JM14='库存' AND JM107='T'" ) );

                    modelAm.AM315 = string.IsNullOrEmpty( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='F'" ) );
                    modelAm.AM326 = string.IsNullOrEmpty( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '胶合板' and JM93='E1' and JM14='库存' AND JM107='T'" ) );

                    modelAm.AM318 = string.IsNullOrEmpty( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='F'" ) );
                    modelAm.AM328 = string.IsNullOrEmpty( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '密度板' and JM93='E0' and JM14='库存' AND JM107='T'" ) );

                    modelAm.AM321 = string.IsNullOrEmpty( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='F'" ) );
                    modelAm.AM296 = string.IsNullOrEmpty( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(JM)" ,"JM90='" + modelAm.AM002 + "' and JM09= '密度板' and JM93='E1' and JM14='库存' AND JM107='T'" ) );
                    bll.UpdateOfReceviable( modelAm ,model.JM01 );
                }
            }
        }
        //Update
        protected override void update ( )
        {
            base.update( );

            result = false;
            result = bll.ExistsReviews( "R_338" ,model.JM01 );
            if ( result == true )
                MessageBox.Show( "单号:" + model.JM01 + "的单据状态为执行,不允许更改" );
            else
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolUpdate.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
                Ergodic.TablePageEnableTrue( pageList );
                Ergodic.SpliEnableTrue( spList );

                textBox3.Enabled = false;
                dateTimePicker1.Enabled = dateTimePicker4.Enabled = dateTimePicker2.Enabled = false;
                if ( string.IsNullOrEmpty( textBox68.Text ) )
                {
                    //fc.productNumberRthr( comboBox7 );
                    textBox71.Enabled = true;
                    comboBox7.Enabled = comboBox9.Enabled = true;
                    button4.Enabled = false;
                    button14.Enabled = true;
                }
                else
                {
                    comboBox7.Enabled = comboBox9.Enabled = false;
                    textBox71.Enabled = false;
                    button4.Enabled = true;
                    button14.Enabled = false;
                }
            }
        }
        //Delete
        void dele ( )
        {
            if ( label107.Visible == true )
                stateOfOdd = "维护删除";
            else
            {
                if ( saer == "1" )
                    stateOfOdd = "新增删除";
                else
                    stateOfOdd = "更改删除";
            }

            result = bll.DeleteOne( model.JM01 ,"R_338" ,"胶合板、密度板采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOfOdd );
            if ( result == false )
                MessageBox.Show( "删除数据失败" );
            else
            {
                MessageBox.Show( "成功删除数据" );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.SpliClear( spList );
                Ergodic.TablePageEnableFalse( pageList );
                Ergodic.SpliEnableFalse( spList );
                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;

                toolSelect.Enabled = toolAdd.Enabled = true;
                toolDelete.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolUpdate.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolExport.Enabled = false;

                textBox2.Text = "";
                textBox3.Enabled = false;
                label44.Visible = false;
                label107.Visible = false;
            }
        }
        protected override void delete ( )
        {
            base.delete( );

            result = bll.ExistsReviews( "R_338" ,model.JM01 );
            if ( result == true )
            {
                if ( Logins.number == "MLL-0001" )
                    dele( );
                else
                    MessageBox.Show( "单号:" + model.JM01 + "的单据状态为执行,需要总经理删除" );
            }
            else
                dele( );
        }
        //Add
        Order od = new Order( );
        string ord = "";
        void orde ( )
        {
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.SpliClear( spList );
            Ergodic.TablePageEnableTrue( pageList );
            Ergodic.SpliEnableTrue( spList );
            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;

            textBox3.Enabled = false;
            label44.Visible = label107.Visible = false;
            saer = "1";

            dateTimePicker1.Enabled = dateTimePicker4.Enabled = dateTimePicker2.Enabled = false;

            model.JM01 = oddNumbers.purchaseContract( "SELECT MAX(AJ002) AJ002 FROM R_PQAJ" ,"AJ002" ,"R_338-" );
        }
        protected override void add ( )
        {
            base.add( );

            od.StartPosition = FormStartPosition.CenterScreen;
            od.PassDataBetweenForm += new Order.PassDataBetweenFormHandler( od_PassDataBetweenForm );
            od.ShowDialog( );

            if ( ord == "计划" )
            {
                orde( );
                comboBox7.Enabled = comboBox9.Enabled = true;
                button4.Enabled = false;
                button14.Enabled = true;
                textBox71.Enabled = true;
                //fc.productNumberRthr( comboBox7 );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
            }
            else if ( ord == "实际" )
            {
                orde( );
                comboBox7.Enabled = comboBox9.Enabled = false;
                textBox71.Enabled = false;
                button4.Enabled = true;
                button14.Enabled = false;
                //comboBox7.DataSource = null;
                //comboBox7.Items.Clear( );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
            }
            else if ( ord == "" )
            {
                MessageBox.Show( "请选择计划订单或实际订单" );
                saer = "1";
                model.JM01 = "";
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
            }
        }
        private void od_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            ord = e.ConOne;
        }
        //Print    
        void trueOrFalse ( )
        {
            model.JM102 = comboBox9.Text;
            result = false;
            if ( ( string.IsNullOrEmpty( textBox68.Text ) && bandedGridView1.GetDataRow( 0 )["JM14"].ToString( ) == "外购" ) || ( !string.IsNullOrEmpty( textBox68.Text ) && bandedGridView1.GetDataRow( 0 )["JM14"].ToString( ) == "库存" ) )
            {
                for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                {
                    if ( sp.inOut( model.JM01 ,bandedGridView1.GetDataRow( i )["JM09"].ToString( ) ,model.JM102 ,bandedGridView1.GetDataRow( i )["JM94"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["JM95"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["JM96"].ToString( ) ) == false )
                    {
                        //所有都不等就是没有出或入
                        result = false;
                        break;
                    }
                    else if ( i == bandedGridView1.RowCount - 1 )
                        result = true;
                }
            }
        }
        protected override void print ( )
        {
            base.print( );

            //sp.panDuan( "JM06" ,"JM87" ,"R_PQO" ,"JM01" ,JM01 ,ord ,textBox68.Text ,"R_338");
            /*sp.sp == "1"*/
            if ( ( ord == "实际" || !string.IsNullOrEmpty( textBox68.Text ) ) && bandedGridView1.GetDataRow( 0 )["JM14"].ToString( ) == "外购" )
            {
                if ( label107.Visible == true )
                {
                    MulaolaoBll . ContractAddPrintTime . addTimeToContract ( "R_PQO" ,"JM114" ,model . JM01 ,"JM01" );

                    Create( );
                    file = "";
                    file = System.Windows.Forms.Application.StartupPath;
                    report.Load( file + "\\R_338.frx" );
                    report.RegisterData( RDataSet );
                    report.Show( );
                }
                else
                    MessageBox.Show( "非执行单据不能打印" );
            }
            else
            {
                trueOrFalse( );
                if ( result == true )
                {
                    MulaolaoBll . ContractAddPrintTime . addTimeToContract ( "R_PQO" ,"JM114" ,model . JM01 ,"JM01" );

                    Create ( );
                    file = "";
                    file = System.Windows.Forms.Application.StartupPath;
                    report.Load( file + "\\R_338.frx" );
                    report.RegisterData( RDataSet );
                    report.Show( );
                }
                else
                    MessageBox.Show( "没有出入库的单据不能打印" );
            }

        }
        //Export
        protected override void export ( )
        {
            base.export( );

            //sp.panDuan( "JM06" ,"JM87" ,"R_PQO" ,"JM01" ,JM01 ,ord ,textBox68.Text,"R_338" );

            //if ( ( ord == "实际" || !string.IsNullOrEmpty( textBox68.Text ) ) && radioButton16.Checked )
            //{
            //    if ( label107.Visible == true )
            //    {
            Create( );
            file = "";
            file = Environment.CurrentDirectory;
            report.Load( file + "\\R_338.frx" );

            report.RegisterData( RDataSet );
            report.Prepare( );
            XMLExport exprots = new XMLExport( );
            exprots.Export( report );
            //    }
            //    else
            //        MessageBox.Show( "非执行单据不能导出" );
            //}
            //else
            //{
            //    trueOrFalse( );
            //    if ( result == true )
            //    {
            //        Create( );

            //        report.Load( Environment.CurrentDirectory + "\\R_338.frx" );

            //        report.RegisterData( RDataSet );
            //        report.Prepare( );
            //        XMLExport exprots = new XMLExport( );
            //        exprots.Export( report );
            //    }
            //    else
            //        MessageBox.Show( "没有出入库的单据不能导出" );
            //}
        }
        //Save
        void saves ( )
        {
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolUpdate.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
            Ergodic.TablePageEnableFalse( pageList );
            Ergodic.SpliEnableFalse( spList );
            textBox3.Enabled = false;
            copy = "";
            weihu = "";
            label44.Visible = false;
        }
        void updates ( )
        {
            result = bll.UpdateMain( model ,"R_338" ,"胶合板、密度板采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"保存" ,stateOfOdd );
            if ( result == false )
                MessageBox.Show( "录入数据失败" );
            else
            {
                MessageBox.Show( "成功录入数据" );
                if ( weihu == "1" )
                {
                    try
                    {
                        SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfCopy( "R_PQOC" ,"R_PQO" ,"JM01" ,model.JM01 ) );
                        WriteOfReceivablesTo( );
                    }
                    catch { }
                }
                saves( );
            }
        }
        void variab ( )
        {
            model.JM02 = lookUpEdit1.EditValue.ToString( );
            //if ( ord == "计划" || string.IsNullOrEmpty( textBox68.Text ) )
            //    model.JM01 = "";
            model.JM04 = textBox13.Text;
            model.JM05 = dateTimePicker2.Value;
            model.JM06 = textBox14.Text;
            model.JM07 = dateTimePicker1.Value;
            model.JM08 = textBox15.Text;
            model.JM19 = textBox23.Text;
            model.JM20 = textBox24.Text;
            model.JM21 = checkBox12.Checked == true ? "T" : "F";
            model.JM22 = checkBox13.Checked == true ? "T" : "F";
            model.JM23 = checkBox14.Checked == true ? "T" : "F";
            model.JM24 = checkBox15.Checked == true ? "T" : "F";
            model.JM25 = checkBox16.Checked == true ? "T" : "F";
            model.JM26 = checkBox18.Checked == true ? "T" : "F";
            model.JM27 = comboBox8.Text;
            model.JM28 = dateTimePicker5.Value;
            model.JM29 = comboBox15.Text;
            model.JM30 = dateTimePicker6.Value;
            model.JM31 = comboBox16.Text;
            model.JM32 = dateTimePicker7.Value;
            model.JM33 = textBox16.Text;
            model.JM34 = textBox27.Text;
            if ( radioButton1.Checked )
                model.JM35 = "在内";
            else if ( radioButton2.Checked )
                model.JM35 = "不在内";
            else
                model.JM35 = string.Empty;
            if ( radioButton3.Checked )
                model.JM36 = "有";
            else if ( radioButton4.Checked )
                model.JM36 = "没有";
            else
                model.JM36 = string.Empty;
            if ( radioButton6.Checked )
            {
                model.JM37 = "已检测";
                model.JM38 = textBox26.Text;
            }
            else if ( radioButton5.Checked )
            {
                model.JM37 = "未检测";
                model.JM38 = string.Empty;
            }
            else
            {
                model.JM37 = string.Empty;
                model.JM38 = string.Empty;
            }
            model.JM39 = checkBox1.Checked == true ? "T" : "F";
            model.JM40 = checkBox20.Checked == true ? "T" : "F";
            model.JM41 = checkBox2.Checked == true ? "T" : "F";
            model.JM42 = checkBox4.Checked == true ? "T" : "F";
            model.JM43 = checkBox3.Checked == true ? "T" : "F";
            model.JM44 = checkBox5.Checked == true ? "T" : "F";
            model.JM45 = checkBox7.Checked == true ? "T" : "F";
            model.JM46 = checkBox19.Checked == true ? "T" : "F";
            model.JM47 = checkBox9.Checked == true ? "T" : "F";
            model.JM48 = checkBox11.Checked == true ? "T" : "F";
            model.JM49 = checkBox10.Checked == true ? "T" : "F";
            model.JM50 = comboBox17.Text;
            model.JM51 = dateTimePicker8.Value;
            model.JM52 = comboBox20.Text;
            model.JM53 = dateTimePicker9.Value;
            if ( radioButton7.Checked )
                model.JM54 = "椴木芯";
            else if ( radioButton8.Checked )
                model.JM54 = "杨木芯";
            else if ( radioButton9.Checked )
                model.JM54 = "冲压专用板";
            else
                model.JM54 = string.Empty;
            if ( radioButton11.Checked )
                model.JM55 = "浅白色";
            else if ( radioButton12.Checked )
                model.JM55 = "棕色";
            else
                model.JM55 = string.Empty;
            model.JM56 = textBox30.Text;
            model.JM57 = textBox31.Text;
            model.JM58 = textBox32.Text;
            model.JM59 = textBox33.Text;
            model.JM60 = textBox37.Text;
            model.JM61 = textBox36.Text;
            model.JM62 = textBox35.Text;
            model.JM63 = textBox34.Text;
            model.JM64 = textBox40.Text;
            model.JM65 = textBox39.Text;
            model.JM66 = textBox4.Text;
            model.JM67 = string.IsNullOrEmpty( textBox52.Text ) == true ? 0 : Convert.ToInt32( textBox52.Text );
            model.JM68 = comboBox21.Text;
            model.JM69 = comboBox18.Text;
            model.JM70 = comboBox19.Text;
            if ( radioButton14.Checked )
            {
                model.JM71 = "合格";
                model.JM72 = string.Empty;
            }
            else if ( radioButton13.Checked )
            {
                model.JM71 = "退货";
                model.JM72 = string.Empty;
            }
            else if ( radioButton10.Checked )
            {
                model.JM71 = "条件接收";
                model.JM72 = textBox50.Text;
            }
            else
            {
                model.JM71 = string.Empty;
                model.JM72 = string.Empty;
            }
            model.JM73 = string.IsNullOrEmpty( textBox49.Text ) == true ? 0 : Convert.ToInt32( textBox49.Text );
            model.JM74 = string.IsNullOrEmpty( textBox48.Text ) == true ? 0 : Convert.ToInt32( textBox48.Text );
            model.JM75 = string.IsNullOrEmpty( textBox47.Text ) == true ? 0 : Convert.ToInt32( textBox47.Text );
            model.JM76 = string.IsNullOrEmpty( textBox46.Text ) == true ? 0 : Convert.ToInt32( textBox46.Text );
            model.JM77 = string.IsNullOrEmpty( textBox45.Text ) == true ? 0 : Convert.ToInt32( textBox45.Text );
            model.JM78 = string.IsNullOrEmpty( textBox17.Text ) == true ? 0 : Convert.ToInt32( textBox17.Text );
            model.JM79 = string.IsNullOrEmpty( textBox44.Text ) == true ? 0 : Convert.ToInt32( textBox44.Text );
            model.JM80 = string.IsNullOrEmpty( textBox43.Text ) == true ? 0 : Convert.ToInt32( textBox43.Text );
            model.JM81 = string.IsNullOrEmpty( textBox42.Text ) == true ? 0 : Convert.ToInt32( textBox42.Text );
            model.JM82 = textBox56.Text;
            model.JM83 = textBox55.Text;
            model.JM84 = dateTimePicker10.Value;
            model.JM85 = textBox54.Text;
            model.JM86 = dateTimePicker11.Value;
            model.JM87 = textBox53.Text;
            model.JM88 = dateTimePicker12.Value;
            model.JM89 = dateTimePicker13.Value;
            model.JM90 = textBox68.Text;
            model.JM98 = textBox3.Text;
            model.JM100 = comboBox7.Text;
            model.JM101 = textBox2.Text;
            model.JM102 = comboBox9.Text;
            model.JM103 = string.IsNullOrEmpty( textBox71.Text ) == true ? 0 : Convert.ToInt64( textBox71.Text );
            model.JM108 = lookUpEdit2.Text;
            model.JM106 = string.Empty;
            model.JM107 = checkBox6.Checked == true ? "T" : "F";
            model.JM113 = checkBox8.Checked == true ? "T" : "F";
        }
        protected override void save ( )
        {
            base.save( );

            if ( string.IsNullOrEmpty( textBox15.Text ) )
            {
                MessageBox.Show( "合同批号不可为空" );
                return;
            }
            //if ( string . IsNullOrEmpty ( model . JM03 ) || string . IsNullOrEmpty ( textBox19 . Text ) )
            //{
            //    MessageBox . Show ( "请选择供应商" );
            //    return;
            //}
            if ( string.IsNullOrEmpty( textBox19.Text ) )
            {
                MessageBox.Show( "请选择供应商信息" );
                return;
            }
            if ( string.IsNullOrEmpty( lookUpEdit1.Text ) )
            {
                MessageBox.Show( "请选择采购人" );
                return;
            }
            variab( );
            if ( model . JM03 != numFor )
                model . JM03 = numFor;
            if ( readNameFordga ( ) == false )
                return;

            DataTable drt = bll.GetDataTableMainTain( model.JM01 );
            if ( weihu == "1" )
            {
                if ( string.IsNullOrEmpty( textBox3.Text ) )
                {
                    MessageBox.Show( "请填写维护意见" );
                    return;
                }
                stateOfOdd = "维护保存";
                model.JM99 = drt.Rows[0]["JM99"].ToString( ) + "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";
                updates( );
            }
            else
            {
                //如果是库存合同，检查是否在046有剩余的同货号和规格、同物料名称
                if ( !string . IsNullOrEmpty ( textBox68 . Text ) )
                {
                    string num = comboBox9 . Text;
                    string name = string . Empty, spe = string . Empty;
                    decimal numsOfPart = 0;
                    int kw = 0;
                    for ( int i = 0 ; i < bandedGridView1 . RowCount ; i++ )
                    {
                        if ( bandedGridView1 . GetDataRow ( i ) [ "JM14" ] . ToString ( ) . Equals ( "库存" ) )
                        {
                            if ( kw==2 )
                            {
                                MessageBox . Show ( "不能在同一张合同中开外购和库存合同" );
                                return;
                            }
                            kw = 1;
                            name = bandedGridView1 . GetDataRow ( i ) [ "JM09" ] . ToString ( );
                            spe = bandedGridView1 . GetDataRow ( i ) [ "JM94" ] . ToString ( ) + "*" + bandedGridView1 . GetDataRow ( i ) [ "JM95" ] . ToString ( ) + "*" + bandedGridView1 . GetDataRow ( i ) [ "JM96" ] . ToString ( );
                            numsOfPart = string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "JM15" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "JM15" ] . ToString ( ) );
                            if ( checkLibrary ( num ,name ,spe ,numsOfPart ) == false )
                            {
                                MessageBox . Show ( "货号:" + num + "\n\r零件名称:" + name + "\n\r规格:" + spe + "\n\r使用库存量多余库存量,请检查" );
                                return;
                            }
                        }
                        else if ( bandedGridView1 . GetDataRow ( i ) [ "JM14" ] . ToString ( ) . Equals ( "外购" ) )
                        {
                            if ( kw==1 )
                            {
                                MessageBox . Show ( "不能在同一张合同中开外购和库存合同" );
                                return;
                            }
                            kw = 2;
                            name = bandedGridView1 . GetDataRow ( i ) [ "JM09" ] . ToString ( );
                            spe = bandedGridView1 . GetDataRow ( i ) [ "JM94" ] . ToString ( ) + "*" + bandedGridView1 . GetDataRow ( i ) [ "JM95" ] . ToString ( ) + "*" + bandedGridView1 . GetDataRow ( i ) [ "JM96" ] . ToString ( );
                            numsOfPart = string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "JM104" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "JM104" ] . ToString ( ) );
                            if ( checkSto ( num ,name ,spe ) == false )
                            {
                                MessageBox . Show ( "货号:" + num + "\n\r零件名称:" + name + "\n\r规格:" + spe + "\n\r还有库存,不允许外购,请检查" );
                                return;
                            }
                        }
                    }
                }

                if ( saer == "1" )
                    stateOfOdd = "新增保存";
                else
                    stateOfOdd = "更改保存";
                model.JM99 = string.Empty;
                if ( drt.Rows.Count < 1 )
                    saves( );
                else
                {
                    if ( copy == "1" )
                    {
                        if ( MulaolaoBll . WriteReceivableToGeneralLedger . ExistsSup ( model .JM03 ) == false )
                        {
                            MessageBox . Show ( "供应商已注销,请核实" );
                            return;
                        }

                        stateOfOdd = "复制保存";
                        // AND JM04=@JM04
                        DataTable dyu = bll.GetDataTableNoMain( model.JM01 );
                        if ( dyu.Rows.Count < 1 )
                            updates( );
                        else
                        {
                            int proNum = 0;
                            for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                            {
                                proNum = string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "JM103" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( bandedGridView1 . GetDataRow ( i ) [ "JM103" ] );
                                if ( proNum != model . JM103 )
                                {
                                    MessageBox . Show ( "产品数量不一致,请核实" );
                                    break;
                                }

                                if ( ord == "计划" || string.IsNullOrEmpty( textBox68.Text ) )
                                {
                                    if ( dyu.Select( "JM09='" + bandedGridView1.GetDataRow( i )["JM09"].ToString( ) + "' AND JM94='" + bandedGridView1.GetDataRow( i )["JM94"].ToString( ) + "' AND JM95='" + bandedGridView1.GetDataRow( i )["JM95"].ToString( ) + "' AND JM96='" + bandedGridView1.GetDataRow( i )["JM96"].ToString( ) + "' AND JM102='" + model.JM102 + "'" ).Length > 0 )
                                    {
                                        if ( model.JM08.Length >= 8 && model.JM08.Substring( 0 ,8 ) == "MLL-0001" )
                                        {
                                            updates( );
                                            break;
                                        }
                                        else
                                        {
                                            MessageBox.Show( "已经存在\n\r货号:" + model.JM102 + "\n\r物料名称:" + bandedGridView1.GetDataRow( i )["JM09"].ToString( ) + "\n\r长:" + bandedGridView1.GetDataRow( i )["JM94"].ToString( ) + "\n\r宽:" + bandedGridView1.GetDataRow( i )["JM95"].ToString( ) + "\n\r高:" + bandedGridView1.GetDataRow( i )["JM96"].ToString( ) + "的记录,请核实后再录入" );
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        updates( );
                                        break;
                                    }
                                }
                                else if ( ord == "实际" || !string.IsNullOrEmpty( textBox68.Text ) )
                                {
                                    //if ( yesOrNoHaveStock( ) == false )
                                    //    break;
                                    if ( dyu.Select( "JM09='" + bandedGridView1.GetDataRow( i )["JM09"].ToString( ) + "' AND JM94='" + bandedGridView1.GetDataRow( i )["JM94"].ToString( ) + "' AND JM95='" + bandedGridView1.GetDataRow( i )["JM95"].ToString( ) + "' AND JM96='" + bandedGridView1.GetDataRow( i )["JM96"].ToString( ) + "' AND JM90='" + model.JM90 + "'" ).Length > 0 )
                                    {
                                        if ( model.JM08.Length >= 8 && model.JM08.Substring( 0 ,8 ) == "MLL-0001" )
                                        {
                                            updates( );
                                            break;
                                        }
                                        else
                                        {
                                            MessageBox.Show( "已经存在\n\r流水号:" + model.JM90 + "\n\r物料名称:" + bandedGridView1.GetDataRow( i )["JM09"].ToString( ) + "\n\r长:" + bandedGridView1.GetDataRow( i )["JM94"].ToString( ) + "\n\r宽:" + bandedGridView1.GetDataRow( i )["JM95"].ToString( ) + "\n\r高:" + bandedGridView1.GetDataRow( i )["JM96"].ToString( ) + "的记录,请核实后再录入" );
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        updates( );
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                        updates( );
                }
            }
        }
        bool checkLibrary ( string num,string name,string spe,decimal numsOfPart )
        {
            decimal numsOf = bll . getSurNum ( num ,name ,spe );
            if ( numsOf < numsOfPart )
                return false;
            else
                return true;
        }
        bool checkSto ( string num ,string name ,string spe   )
        {
            decimal numsOf = bll . getSurNum ( num ,name ,spe );
            if ( numsOf >0 )
                return false;
            else
                return true;
        }
        bool yesOrNoHaveStock ( )
        {
            //JM14:使用库存OR外购
            //JM103:产品数量
            //JM09:物料名称
            //JM94:长
            //JM95:宽
            //JM96:高
            //combobox9:货号

            /*
             2017-7-5  货号:ZE0347B 流水:17060215  复制，开库存板1020套  提示库存不足--经查是因为产品数量多于剩余产品数量-->造成原因(购买板数量=产品数量/每套用量  每套用量小数较多，除不尽  所以若产品数量过大  会少板)
             */
             
            if ( bandedGridView1.RowCount > 0 && bandedGridView1.GetDataRow( 0 )["JM14"].ToString( ) == "库存" )
            {
                for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                {
                    result = fc.LibraryOf( comboBox9.Text ,bandedGridView1.GetDataRow( i )["JM103"].ToString( ) ,bandedGridView1.GetDataRow( i )["JM09"].ToString( ) ,bandedGridView1.GetDataRow( i )["JM94"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["JM95"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["JM96"].ToString( ) );
                    if ( result == false )
                    {
                        MessageBox.Show( "库存数量少于使用库存数量,请核实" );
                        break;
                    }
                    else if ( i == bandedGridView1.RowCount - 1 )
                        result = true;
                }
            }
            return result;
        }
        bool readNameFordga ( )
        {
            string dgaNum = bll . getTpadga ( textBox19 . Text ,textBox9 . Text );
            if ( dgaNum == null || dgaNum == string . Empty )
            {
                MessageBox . Show ( "请重新选择供应商" );
                return false;
            }
            if ( dgaNum . Equals ( numFor ) )
                return true;
            else
            {
                MessageBox . Show ( "请重新选择供应商" );
                return false;
            }
        }
        //Cancel
        protected override void cancel ( )
        {
            base.cancel( );

            if ( saer == "1" && weihu != "1" )
            {
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.SpliClear( spList );
                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolDelete.Enabled = toolReview.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolSave.Enabled = toolCancel.Enabled = toolPrint.Enabled = toolExport.Enabled = false;

                label44.Visible = false;
                try
                {
                     bll.DeleteOne( model.JM01 ,"R_338" ,"胶合板、密度板采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"取消" ,"新增取消" );
                    //bll.DeleteReview( model.JM01 ,"R_338" );
                }
                catch { }
            }
            else if ( saer == "2" || weihu == "1" )
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolUpdate.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
            }
            Ergodic.TablePageEnableFalse( pageList );
            Ergodic.SpliEnableFalse( spList );
            textBox3.Enabled = false;
        }
        //MainTain
        protected override void maintain ( )
        {
            base.maintain( );

            result = false;
            result = bll.ExistsReviews( "R_338" ,model.JM01 );
            if ( result == true )
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolUpdate.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;

                textBox3.Enabled = true;

                weihu = "1";
                Ergodic.TablePageEnableTrue( pageList );
                Ergodic.SpliEnableTrue( spList );
                dateTimePicker1.Enabled = dateTimePicker4.Enabled = dateTimePicker2.Enabled = false;
                comboBox7.Enabled = comboBox9.Enabled = false;

                if ( string.IsNullOrEmpty( textBox68.Text ) )
                {
                    comboBox7.Enabled = comboBox9.Enabled = true;
                    textBox71.Enabled = true;
                    button14.Enabled = true;
                    button4.Enabled = false;
                }
                else
                {
                    comboBox7.Enabled = comboBox9.Enabled = false;
                    textBox71.Enabled = false;
                    button14.Enabled = false;
                    button4.Enabled = true;
                }
            }
            else
                MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
        }
        //Library
        protected override void library ( )
        {
            base.library( );

            if ( label107.Visible == false )
            {
                MessageBox.Show( "非执行单据不能出库" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox7.Text ) )
            {
                MessageBox.Show( "产品名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox9.Text ) )
            {
                MessageBox.Show( "货号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox71.Text ) )
            {
                MessageBox.Show( "产品数量不可为空" );
                return;
            }
            if ( bandedGridView1.GetDataRow( 0 )["JM14"].ToString( ) == "外购" )
            {
                MessageBox.Show( "外购无法出库,请选择入库或更改状态" );
                return;
            }
            libraryTable = null;
            for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
            {
                if ( libraryTable != null )
                    libraryTable.Rows.Add( new object[] { bandedGridView1.GetDataRow( i )["JM94"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["JM95"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["JM96"].ToString( ) ,bandedGridView1.GetDataRow( i )["JM09"].ToString( ) ,Math.Truncate( Convert.ToDecimal( bandedGridView1.GetDataRow( i )["JM15"].ToString( ) ) ) } );
                else
                {
                    libraryTable = new DataTable( "Datas" );
                    libraryTable.Columns.Add( "tOne" ,typeof( System.String ) );
                    libraryTable.Columns.Add( "tTwo" ,typeof( System.String ) );
                    libraryTable.Columns.Add( "tTre" ,typeof( System.Decimal ) );
                    libraryTable.Rows.Add( new object[] { bandedGridView1.GetDataRow( i )["JM94"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["JM95"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["JM96"].ToString( ) ,bandedGridView1.GetDataRow( i )["JM09"].ToString( ) ,Math.Truncate( Convert.ToDecimal( bandedGridView1.GetDataRow( i )["JM15"].ToString( ) ) ) } );
                }
            }
            if ( libraryTable.Rows.Count > 0 )
            {
                SelectAll.OutbandChoice outC = new SelectAll.OutbandChoice( );
                outC.libraryTable = libraryTable;
                outC.number = comboBox9.Text;
                outC.sign = "R_338";
                outC.oddNum = model.JM01;
                outC.StartPosition = FormStartPosition.CenterScreen;
                outC.PassDataBetweenForm += new SelectAll.OutbandChoice.PassDataBetweenFormHandler( outC_PassDataBetweenForm );
                outC.ShowDialog( );
            }
            if ( conOne == "2" )
                return;
            int countSum = 0;
            for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
            {
                speList.Clear( );
                string query = "", count = "";
                if ( libraryTable == null )
                    query = count = "";
                if ( libraryTable != null && libraryTable.Rows.Count > 0 )
                {
                    countSum = libraryTable.Select( "tTwo='" + bandedGridView1.GetDataRow( i )["JM94"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["JM95"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["JM96"].ToString( ) + bandedGridView1.GetDataRow( i )["JM09"].ToString( ) + "'" ).Length;
                    if ( countSum > 0 )
                    {
                        for ( int k = 0 ; k < countSum ; k++ )
                        {
                            if ( !speList.Contains( libraryTable.Select( "tTwo='" + bandedGridView1.GetDataRow( i )["JM94"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["JM95"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["JM96"].ToString( ) + bandedGridView1.GetDataRow( i )["JM09"].ToString( ) + "'" )[k]["tOne"].ToString( ) ) )
                                speList.Add( libraryTable.Select( "tTwo='" + bandedGridView1.GetDataRow( i )["JM94"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["JM95"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["JM96"].ToString( ) + bandedGridView1.GetDataRow( i )["JM09"].ToString( ) + "'" )[k]["tOne"].ToString( ) );
                        }

                        if ( speList.Count > 0 )
                        {
                            foreach ( string str in speList )
                            {
                                query = str;
                                count = libraryTable.Select( "tTwo='" + bandedGridView1.GetDataRow( i )["JM94"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["JM95"].ToString( ) + "*" + bandedGridView1.GetDataRow( i )["JM96"].ToString( ) + bandedGridView1.GetDataRow( i )["JM09"].ToString( ) + "' AND tOne='" + query + "'" )[0]["tTre"].ToString( );

                                result = fc . Library ( comboBox7 . Text ,comboBox9 . Text ,textBox68 . Text ,bandedGridView1 . GetDataRow ( i ) [ "JM103" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "JM09" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "JM94" ] . ToString ( ) + "*" + bandedGridView1 . GetDataRow ( i ) [ "JM95" ] . ToString ( ) + "*" + bandedGridView1 . GetDataRow ( i ) [ "JM96" ] . ToString ( ) ,"张" ,bandedGridView1 . GetDataRow ( i ) [ "JM13" ] . ToString ( ) ,"" ,bandedGridView1 . GetDataRow ( i ) [ "JM11" ] . ToString ( ) ,/*bandedGridView1.GetDataRow( i )["JM15"].ToString( )*/count ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,model . JM01 ,query ,lookUpEdit2 . Text );

                                if ( result == false )
                                {
                                    MessageBox.Show( "出库失败" );
                                    break;
                                }

                            }
                        }

                    }
                }
            }
            if ( result == true )
            {
                MessageBox . Show ( "出库成功" );
                //fc . deleteOfLibrary ( speList ,model . JM01 ,model . JM90 );
            }
        }
        private void outC_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            libraryTable = new DataTable( );
            conOne = e.ConOne;
            libraryTable = e.TabOne;
        }
        //Storage
        protected override void storage ( )
        {
            base.storage( );

            if ( label107.Visible == false )
            {
                MessageBox.Show( "非执行单据不能入库" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox7.Text ) )
            {
                MessageBox.Show( "产品名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox9.Text ) )
            {
                MessageBox.Show( "货号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox71.Text ) )
            {
                MessageBox.Show( "产品数量不可为空" );
                return;
            }
            if ( bandedGridView1.GetDataRow( 0 )["JM14"].ToString( ) == "库存" )
            {
                MessageBox.Show( "库存无法入库,请选择出库或更改状态" );
                return;
            }
            if ( bandedGridView1.GetDataRow( 0 )["JM14"].ToString( ) == "外购" && ( ord == "实际" || !string.IsNullOrEmpty( textBox68.Text ) ) )
            {
                MessageBox.Show( "实际订单不允许入库" );
                return;
            }
            for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
            {
                result = fc . Storage338 ( comboBox7 . Text ,comboBox9 . Text ,bandedGridView1 . GetDataRow ( i ) [ "JM103" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "JM09" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "JM94" ] . ToString ( ) + "*" + bandedGridView1 . GetDataRow ( i ) [ "JM95" ] . ToString ( ) + "*" + bandedGridView1 . GetDataRow ( i ) [ "JM96" ] . ToString ( ) ,"张" ,bandedGridView1 . GetDataRow ( i ) [ "JM13" ] . ToString ( ) ,"" ,bandedGridView1 . GetDataRow ( i ) [ "JM11" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "JM104" ] . ToString ( ) ,textBox13 . Text ,dateTimePicker1 . Value ,lookUpEdit1 . Text ,MulaolaoBll . Drity . GetDt ( ) ,model . JM01 ,bandedGridView1 . GetDataRow ( i ) [ "JM109" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "JM110" ] . ToString ( ) ,lookUpEdit2 . Text ,textBox19 . Text ,textBox9 . Text );
                if ( result == false )
                {
                    MessageBox.Show( "入库失败" );
                    break;
                }
                else if ( i == bandedGridView1.RowCount - 1 )
                {
                    MessageBox.Show( "已入库" );
                    try
                    {
                        for ( int k = 0 ; k < bandedGridView1.RowCount ; k++ )
                        {
                            model.IDX = string.IsNullOrEmpty( bandedGridView1.GetDataRow( k )["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetDataRow( k )["idx"].ToString( ) );
                            model.JM109 = string.IsNullOrEmpty( bandedGridView1.GetDataRow( k )["JM103"].ToString( ) ) == true ? 0 : Convert.ToInt64( bandedGridView1.GetDataRow( k )["JM103"].ToString( ) );
                            model.JM110 = string.IsNullOrEmpty( bandedGridView1.GetDataRow( k )["JM104"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( k )["JM104"].ToString( ) );
                            bll.UpdateLastTime( model.JM109 ,model.JM110 ,model.IDX );
                        }
                    }
                    catch { }
                }
            }
        }
        //Copy
        protected override void copys ( )
        {
            base.copys( );

            xu( );
        }
        void xu ( )
        {
            if ( label107.Visible == true )
                stateOfOdd = "维护复制";
            else
            {
                if ( saer == "1" )
                    stateOfOdd = "新增复制";
                else
                    stateOfOdd = "更改复制";
            }

            result = bll.Copy( model.JM01 ,"R_338" ,"胶合板、密度板采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOfOdd );
            if ( result == false )
                MessageBox.Show( "复制失败,请重试" );
            else
            {
                model.JM01 = oddNumbers.purchaseContract( "SELECT MAX(AJ002) AJ002 FROM R_PQAJ" ,"AJ002" ,"R_338-" );
                stateOfOdd = "复制更改单号";
                result = bll.UpdateCopy( model.JM01 ,"R_338" ,"胶合板、密度板采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOfOdd );
                if ( result == false )
                {
                    MessageBox.Show( "复制失败,请重试" );
                    bll.DeleteCopy( );
                }
                else
                {
                    MessageBox.Show( "成功复制此表" );

                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolUpdate.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                    toolSave.Enabled = toolCancel.Enabled = true;
                    Ergodic.TablePageEnableTrue( pageList );
                    Ergodic.SpliEnableTrue( spList );
                    Ergodic.FormEvery( this );
                    gridControl1.DataSource = null;
                    dateTimePicker1.Enabled = dateTimePicker2.Enabled = dateTimePicker4.Enabled = false;
                    textBox3.Enabled = false;
                    saer = "1";
                    ord = "";
                    copy = "1";
                    weihu = "";
                    label107.Visible = false;

                    queryContent( );
                }
            }
        }
        #endregion
        
        #region Query
        void queryContent ( )
        {
            if ( model.JM01 != null && model.JM01 != "" )
            {
                model = bll.GetModel( model.JM01 );

                if ( model != null )
                {
                    textBox19 . Tag = numFor = model . JM03;

                    #region
                    DataTable delS = bll.GetDataTableSecond( model.JM03 );
                    if ( delS.Rows.Count > 0 )
                    {
                        textBox19.Text = delS.Rows[0]["DGA003"].ToString( );
                        textBox6.Text = delS.Rows[0]["DGA017"].ToString( );
                        textBox7.Text = delS.Rows[0]["DGA008"].ToString( );
                        textBox8.Text = delS.Rows[0]["DGA012"].ToString( );
                        textBox9.Text = delS.Rows[0]["DGA009"].ToString( );
                        textBox10.Text = delS.Rows[0]["DGA011"].ToString( );
                    }
                    lookUpEdit1.Text = name.Select( "DBA001='" + model.JM02 + "'" ).Length > 0 ? name.Select( "DBA001='" + model.JM02 + "'" )[0]["DBA002"].ToString( ) : string.Empty;
                    textBox5.Text = name.Select( "DBA001='" + model.JM02 + "'" ).Length > 0 ? name.Select( "DBA001='" + model.JM02 + "'" )[0]["DBA028"].ToString( ) : string.Empty;
                    textBox13.Text = model.JM04;
                    comboBox7.Text = model.JM100;
                    comboBox9.Text = model.JM102;
                    textBox68.Text = model.JM90;
                    textBox2.Text = model.JM101;
                    textBox71.Text = model.JM103.ToString( );
                    textBox14.Text = model.JM06;
                    if ( model.JM05 > DateTime.MinValue && model.JM05 < DateTime.MaxValue )
                        dateTimePicker2.Value = model.JM05;
                    if ( model.JM07 > DateTime.MinValue && model.JM07 < DateTime.MaxValue )
                        dateTimePicker1.Value = model.JM07;
                    textBox15.Text = model.JM08;
                    textBox23.Text = model.JM19;
                    textBox24.Text = model.JM20;
                    checkBox12.Checked = model.JM21.Trim( ) == "T" ? true : false;
                    checkBox13.Checked = model.JM22.Trim( ) == "T" ? true : false;
                    checkBox14.Checked = model.JM23.Trim( ) == "T" ? true : false;
                    checkBox15.Checked = model.JM24.Trim( ) == "T" ? true : false;
                    checkBox16.Checked = model.JM25.Trim( ) == "T" ? true : false;
                    checkBox18.Checked = model.JM26.Trim( ) == "T" ? true : false;
                    comboBox8.Text = model.JM27;
                    if ( model.JM28 > DateTime.MinValue && model.JM28 < DateTime.MaxValue )
                        dateTimePicker5.Value = model.JM28;
                    comboBox15.Text = model.JM29;
                    if ( model.JM30 > DateTime.MinValue && model.JM30 < DateTime.MaxValue )
                        dateTimePicker6.Value = model.JM30;
                    comboBox16.Text = model.JM31;
                    if ( model.JM32 > DateTime.MinValue && model.JM32 < DateTime.MaxValue )
                        dateTimePicker7.Value = model.JM32;
                    textBox16.Text = model.JM33;
                    textBox27.Text = model.JM34;
                    if ( model.JM35.Trim( ) == "在内" )
                        radioButton1.Checked = true;
                    else if ( model.JM35.Trim( ) == "不在内" )
                        radioButton2.Checked = true;
                    if ( model.JM36.Trim( ) == "有" )
                        radioButton3.Checked = true;
                    else if ( model.JM36.Trim( ) == "没有" )
                        radioButton4.Checked = true;
                    if ( model.JM37.Trim( ) == "已检测" )
                    {
                        radioButton6.Checked = true;
                        textBox26.Text = model.JM38;
                    }
                    else if ( model.JM37.Trim( ) == "未检测" )
                    {
                        radioButton5.Checked = true;
                    }
                    checkBox1.Checked = model.JM39.Trim( ) == "T" ? true : false;
                    checkBox20.Checked = model.JM40.Trim( ) == "T" ? true : false;
                    checkBox2.Checked = model.JM41.Trim( ) == "T" ? true : false;
                    checkBox4.Checked = model.JM42.Trim( ) == "T" ? true : false;
                    checkBox3.Checked = model.JM43.Trim( ) == "T" ? true : false;
                    checkBox5.Checked = model.JM44.Trim( ) == "T" ? true : false;
                    checkBox7.Checked = model.JM45.Trim( ) == "T" ? true : false;
                    checkBox19.Checked = model.JM46.Trim( ) == "T" ? true : false;
                    checkBox9.Checked = model.JM47.Trim( ) == "T" ? true : false;
                    checkBox11.Checked = model.JM48.Trim( ) == "T" ? true : false;
                    checkBox10.Checked = model.JM49.Trim( ) == "T" ? true : false;
                    comboBox17.Text = model.JM50;
                    if ( model.JM51 > DateTime.MinValue && model.JM51 < DateTime.MaxValue )
                        dateTimePicker8.Value = model.JM51;
                    comboBox20.Text = model.JM52;
                    if ( model.JM53 > DateTime.MinValue && model.JM53 < DateTime.MaxValue )
                        dateTimePicker9.Value = model.JM53;
                    if ( model.JM54.Trim( ) == "椴木芯" )
                        radioButton7.Checked = true;
                    else if ( model.JM54.Trim( ) == "杨木芯" )
                        radioButton8.Checked = true;
                    else if ( model.JM54.Trim( ) == "冲压专用板" )
                        radioButton9.Checked = true;
                    if ( model.JM55.Trim( ) == "浅白色" )
                        radioButton11.Checked = true;
                    else if ( model.JM55.Trim( ) == "棕色" )
                        radioButton12.Checked = true;
                    textBox30.Text = model.JM56;
                    textBox31.Text = model.JM57;
                    textBox32.Text = model.JM58;
                    textBox33.Text = model.JM59;
                    textBox37.Text = model.JM60;
                    textBox36.Text = model.JM61;
                    textBox35.Text = model.JM62;
                    textBox34.Text = model.JM63;
                    textBox40.Text = model.JM64;
                    textBox39.Text = model.JM65;
                    textBox4.Text = model.JM66;
                    textBox52.Text = model.JM67.ToString( );
                    comboBox21.Text = model.JM68;
                    comboBox18.Text = model.JM69;
                    comboBox19.Text = model.JM70;
                    if ( model.JM71.Trim( ) == "合格" )
                        radioButton14.Checked = true;
                    else if ( model.JM71.Trim( ) == "退货" )
                        radioButton13.Checked = true;
                    else if ( model.JM71.Trim( ) == "条件接收" )
                    {
                        radioButton10.Checked = true;
                        textBox50.Text = model.JM72;
                    }
                    textBox49.Text = model.JM73.ToString( );
                    textBox48.Text = model.JM74.ToString( );
                    textBox47.Text = model.JM75.ToString( );
                    textBox46.Text = model.JM76.ToString( );
                    textBox45.Text = model.JM77.ToString( );
                    textBox17.Text = model.JM78.ToString( );
                    textBox44.Text = model.JM79.ToString( );
                    textBox43.Text = model.JM80.ToString( );
                    textBox42.Text = model.JM81.ToString( );
                    textBox56.Text = model.JM82;
                    textBox55.Text = model.JM83;
                    if ( model.JM84 > DateTime.MinValue && model.JM84 < DateTime.MaxValue )
                        dateTimePicker10.Value = model.JM84;
                    textBox54.Text = model.JM85;
                    if ( model.JM86 > DateTime.MinValue && model.JM86 < DateTime.MaxValue )
                        dateTimePicker11.Value = model.JM86;
                    textBox53.Text = model.JM87;
                    if ( model.JM88 > DateTime.MinValue && model.JM88 < DateTime.MaxValue )
                        dateTimePicker12.Value = model.JM88;
                    if ( model.JM89 > DateTime.MinValue && model.JM89 < DateTime.MaxValue )
                        dateTimePicker13.Value = model.JM89;
                    textBox3.Text = model.JM98;
                    label44.Visible = model.JM106 == "复制" ? true : false;
                    checkBox6.Checked = model.JM107.Trim( ) == "T" ? true : false;
                    lookUpEdit2.Text = model.JM108;
                    checkBox8.Checked = model.JM113.Trim( ) == "T" ? true : false;
                    #endregion

                    strWhere = "1=1";
                    strWhere = strWhere + " AND JM01='" + model.JM01 + "'";
                    refre( );
                }
            }
        }
        void autoQuery ( )
        {
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolUpdate.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
            Ergodic.TablePageEnableFalse( pageList );
            Ergodic.SpliEnableFalse( spList );
            textBox3.Enabled = false;
            saer = "2";
            ord = "";

            queryContent( );
        }
        //查询
        SelectAll.JiaomiducontractQueryAll jm = new SelectAll.JiaomiducontractQueryAll( );
        protected override void select ( )
        {
            base.select( );

            model = new MulaolaoLibrary.JiaoMiDuContractLibrary( );
            
            jm.PassDataBetweenForm += new SelectAll.JiaomiducontractQueryAll.PassDataBetweenFormHandler( jm_PassDataBetweenForm );
            jm.StartPosition = FormStartPosition.CenterScreen;
            jm.ShowDialog( );

            if ( model.JM01 == null || model.JM01 == "" )
                MessageBox.Show( "您没有选择任何数据" );
            else
                autoQuery( );
        }
        private void jm_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            model.JM101 = e.ConOne;
            textBox2.Text = e.ConOne;
            textBox68.Text = e.ConTwo;
            model.JM90 = e.ConTwo;
            model.JM100 = e.ConTre;
            comboBox7.Text = e.ConTre;
            model.JM03 = e.ConSix;
            textBox19.Text = e.ConSev;
            model.JM04 = e.ConEgi;
            textBox13.Text = e.ConEgi;
            model.JM01 = e.ConNin;
            if ( e.ConTen == "执行" )
                label107.Visible = true;
            else
                label107.Visible = false;
            model.JM102 = e.ConEleven;
            comboBox9.Text = e.ConEleven;
            textBox71.Text = e.ConTwelve;
            if ( e.ConTwelve == "" )
                model.JM103 = 0;
            else
                model.JM103 = Convert.ToInt64( e.ConTwelve );
        }
        //供应商查询
        R_FrmTPADGA tpadga = new R_FrmTPADGA( );
        private void button5_Click ( object sender ,EventArgs e )
        {
            DataTable did = SqlHelper.ExecuteDataTable( "SELECT DGA001,DGA003,DGA008,DGA011,DGA017,DGA009,DGA012 FROM TPADGA WHERE DGA052='F'" );
            if ( did.Rows.Count < 1 )
                MessageBox.Show( "没有供应商信息" );
            else
            {
                tpadga.gridControl2.DataSource = did;
                tpadga.st = "2";
                tpadga.Text = "R_338 供应商查询";
                tpadga.PassDataBetweenForm += new R_FrmTPADGA.PassDataBetweenFomrHandler( tpadga_PassDataBetweenForm );
                tpadga.StartPosition = FormStartPosition.CenterScreen;
                tpadga.ShowDialog( );
            }
        }
        private void tpadga_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            model.JM03 = e.ConOne;
            textBox19.Text = e.ConTwo;
            textBox6.Text = e.ConSev;
            textBox7.Text = e.ConTre;
            textBox8.Text = e.ConSix;
            textBox9.Text = e.ConFor;
            textBox10.Text = e.ConFiv;
        }
        //流水号查询
        Youqicaigou yq = new Youqicaigou( );
        private void button4_Click ( object sender ,EventArgs e )
        {
            DataTable dhr = SqlHelper.ExecuteDataTable( "SELECT PQF01,PQF02,PQF03,PQF04,PQF06,RES05,PQF07,PQF08 FROM R_PQF A,R_MLLCXMC B,R_REVIEWS C WHERE A.PQF01 = C.RES06 AND B.CX01 = C.RES01 AND RES05 = '执行' AND CX02 = '订单销售合同(R_001)' ORDER BY PQF01 DESC" );
            if ( dhr.Rows.Count < 1 )
                MessageBox.Show( "没有产品信息" );
            else
            {
                dhr.Columns.Add( "check" ,System.Type.GetType( "System.Boolean" ) );
                yq.gridControl1.DataSource = dhr;
                yq.sy = "1";
                yq.Text = "R_338 信息查询";
                yq.PassDataBetweenForm += new Youqicaigou.PassDataBetweenFormHandler( yq_PassDataBetweenForm );
                yq.StartPosition = FormStartPosition.CenterScreen;
                yq.ShowDialog( );
            }
        }
        private void yq_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            model.JM90 = e.ConOne;
            textBox68.Text = e.ConOne;
            if ( e.ConTwo.IndexOf( "," ) > 0 )
                textBox2.Text = string.Join( "," ,e.ConTwo.Split( ',' ).Distinct( ).ToArray( ) );
            else
                textBox2.Text = e.ConTwo;
            model.JM101 = textBox2.Text;
            if ( e.ConTre.IndexOf( "," ) > 0 )
                comboBox9.Text = string.Join( "," ,e.ConTre.Split( ',' ).Distinct( ).ToArray( ) );
            else
                comboBox9.Text = e.ConTre;
            model.JM102 = e.ConTre;
            if ( e.ConFor.IndexOf( "," ) > 0 )
                comboBox7.Text = string.Join( "," ,e.ConFor.Split( ',' ).Distinct( ).ToArray( ) );
            else
                comboBox7.Text = e.ConFor;
            model.JM100 = e.ConFor;
            if ( e.ConSix.IndexOf( "," ) > 0 )
                textBox23.Text = string.Join( "," ,e.ConSix.Split( ',' ).Distinct( ).ToArray( ) );
            else
                textBox23.Text = e.ConSix;
            model.JM19 = textBox23.Text;
            if ( e.ConSev.IndexOf( "," ) > 0 )
                textBox24.Text = string.Join( "," ,e.ConSev.Split( ',' ).Distinct( ).ToArray( ) );
            else
                textBox24.Text = e.ConSev;
            model.JM20 = textBox24.Text;
            textBox71.Text = e.ConFiv;
            if ( e.ConFiv == "" )
                model.JM103 = 0;
            else
                model.JM103 = Convert.ToInt64( e.ConFiv );
        }
        //计划查询
        planeQuery pq = new planeQuery( );
        private void button14_Click ( object sender ,EventArgs e )
        {
            DataTable plq = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQF03,PQF04,PQF06 FROM R_PQF A,R_MLLCXMC B,R_REVIEWS C WHERE A.PQF01 = C.RES06 AND B.CX01 = C.RES01 AND RES05 = '执行' AND CX02 = '订单销售合同(R_001)' ORDER BY PQF04" );
            if ( plq.Rows.Count > 0 )
            {
                pq.Text = "R_338 信息查询";
                pq.gridControl1.DataSource = plq;
                pq.StartPosition = FormStartPosition.CenterScreen;
                pq.PassDataBetweenForm += new planeQuery.PassDataBetweenFormHandler( pq_PassDataBetweenForm );
                pq.ShowDialog( );
            }
        }
        void pq_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            textBox68.Text = "";
            model.JM100 = e.ConOne;
            comboBox7.Text = e.ConOne;
            model.JM102 = e.ConTwo;
            comboBox9.Text = e.ConTwo;
            if ( !string.IsNullOrEmpty( e.ConTre ) )
                model.JM103 = Convert.ToInt64( e.ConTre );
            else
                model.JM103 = 0;
            textBox71.Text = e.ConTre;
            textBox2.Text = "";
        }
        //读取胶合板和密度板数据
        string numFor="";
        private void button16_Click ( object sender ,EventArgs e )
        {
            FormJiaoMiDu form = new FormJiaoMiDu ( );
            if ( form . ShowDialog ( ) == DialogResult . OK )
            {
                string info = form . getStr;
                DataRow row = form . getRow;
                string spe = string . Empty;
                textBox59 . Text = string . Empty;
                if ( "胶合板" . Equals ( info ) )
                {
                    lookUpEdit3 . Text = "胶合板";
                    textBox19 . Tag = row [ "QJB013" ];
                    numFor= model . JM03 = string . IsNullOrEmpty ( row [ "QJB013" ] . ToString ( ) ) ? string . Empty : row [ "QJB013" ] . ToString ( );
                    textBox19 . Text = row [ "QJB014" ] . ToString ( );
                    textBox6 . Text = row [ "QJB015" ] . ToString ( );
                    textBox7 . Text = row [ "QJB016" ] . ToString ( );
                    textBox8 . Text = row [ "QJB017" ] . ToString ( );
                    textBox9 . Text = row [ "QJB018" ] . ToString ( );
                    textBox10 . Text = row [ "QJB019" ] . ToString ( );
                    spe= row [ "QJB003" ] . ToString ( );
                    if ( spe != string . Empty )
                    {
                        textBox84 . Text = spe . Split ( '*' ) [ 0 ] . ToString ( );
                        textBox83 . Text = spe . Split ( '*' ) [ 1 ] . ToString ( );
                        textBox85 . Text = spe . Split ( '*' ) [ 2 ] . ToString ( );
                        textBox84_LostFocus ( null ,null );
                        textBox83_LostFocus ( null ,null );
                        textBox85_LostFocus ( null ,null );
                    }
                    comboBox1 . Text = row [ "QJB002" ] . ToString ( );
                    comboBox14 . Text = row [ "QJB011" ] . ToString ( );
                    textBox60 . Tag = textBox60 . Text = string . IsNullOrEmpty ( row [ "QJB007" ] . ToString ( ) ) == true ? 0 . ToString ( ) : ( string . IsNullOrEmpty ( row [ "QJB008" ] . ToString ( ) ) == true ? 0 . ToString ( ) : ( Convert . ToDecimal ( row [ "QJB007" ] ) / Convert . ToDecimal ( row [ "QJB008" ] ) ) . ToString ( "0.##" ) );
                    textBox61 . Text = row [ "QJB008" ] . ToString ( );
                    textBox60_TextChanged ( null ,null );
                    textBox61_TextChanged ( null ,null );
                }
                else if ( "密度板" . Equals ( info ) )
                {
                    lookUpEdit3 . Text = "密度板";
                    textBox19 . Tag = row [ "QMD012" ];
                    numFor = model . JM03 = string . IsNullOrEmpty ( row [ "QMD012" ] . ToString ( ) ) ? string . Empty : row [ "QMD012" ] . ToString ( );
                    textBox19 . Text = row [ "QMD013" ] . ToString ( );
                    textBox6 . Text = row [ "QMD014" ] . ToString ( );
                    textBox7 . Text = row [ "QMD015" ] . ToString ( );
                    textBox8 . Text = row [ "QMD016" ] . ToString ( );
                    textBox9 . Text = row [ "QMD017" ] . ToString ( );
                    textBox10 . Text = row [ "QMD018" ] . ToString ( );
                    spe = row [ "QMD003" ] . ToString ( );
                    if ( spe != string . Empty )
                    {
                        textBox84 . Text = spe . Split ( '*' ) [ 0 ] . ToString ( );
                        textBox83 . Text = spe . Split ( '*' ) [ 1 ] . ToString ( );
                        textBox85 . Text = spe . Split ( '*' ) [ 2 ] . ToString ( );
                        textBox84_LostFocus ( null ,null );
                        textBox83_LostFocus ( null ,null );
                        textBox85_LostFocus ( null ,null );
                    }
                    comboBox1 . Text = row [ "QMD002" ] . ToString ( );
                    comboBox14 . Text = row [ "QMD009" ] . ToString ( );
                    textBox60 . Tag = textBox60 . Text = string . IsNullOrEmpty ( row [ "QMD006" ] . ToString ( ) ) == true ? 0 . ToString ( ) : ( string . IsNullOrEmpty ( row [ "QMD007" ] . ToString ( ) ) == true ? 0 . ToString ( ) : ( Convert . ToDecimal ( row [ "QMD006" ] ) / Convert . ToDecimal ( row [ "QMD007" ] ) ) . ToString ( "0.##" ) );
                    textBox61 . Text = row [ "QMD007" ] . ToString ( );
                    textBox60_TextChanged ( null ,null );
                    textBox61_TextChanged ( null ,null );
                }
            }
        }
        #endregion

        #region Table
        //Build
        void variable ( )
        {
            model . JM08 = textBox15 . Text;
            model . JM90 = textBox68 . Text;
            model . JM09 = lookUpEdit3 . Text;
            model . JM10 = string . IsNullOrEmpty ( comboBox2 . Text ) == true ? 0 : Convert . ToDecimal ( comboBox2 . Text );
            model . JM11 = string . IsNullOrEmpty ( textBox62 . Text ) == true ? 0 : Convert . ToDecimal ( textBox62 . Text );
            model . JM12 = string . IsNullOrEmpty ( textBox20 . Text ) == true ? 0 : Convert . ToDecimal ( textBox20 . Text );
            model . JM13 = string . IsNullOrEmpty ( comboBox12 . Text ) == true ? 0 : Convert . ToDecimal ( comboBox12 . Text );
            if ( radioButton15 . Checked )
            {
                model . JM14 = "库存";
                model . JM15 = string . IsNullOrEmpty ( textBox1 . Text ) == true ? 0 : Math . Round ( Convert . ToDecimal ( textBox1 . Text ) ,0 );
                model . JM104 = 0;
            }
            else if ( radioButton16 . Checked )
            {
                model . JM14 = "外购";
                model . JM104 = string . IsNullOrEmpty ( textBox11 . Text ) == true ? 0 : Math . Round ( Convert . ToDecimal ( textBox11 . Text ) ,0 );
                model . JM15 = 0;
            }
            model . JM16 = dateTimePicker3 . Value;
            model . JM17 = dateTimePicker4 . Value;
            model . JM91 = string . IsNullOrEmpty ( comboBox5 . Text ) == true ? 0 : Convert . ToDecimal ( comboBox5 . Text );
            model . JM92 = comboBox1 . Text;
            model . JM93 = comboBox14 . Text;
            model . JM94 = string . IsNullOrEmpty ( textBox84 . Text ) == true ? 0 : Convert . ToDecimal ( textBox84 . Text );
            model . JM95 = string . IsNullOrEmpty ( textBox83 . Text ) == true ? 0 : Convert . ToDecimal ( textBox83 . Text );
            model . JM96 = string . IsNullOrEmpty ( textBox85 . Text ) == true ? 0 : Convert . ToDecimal ( textBox85 . Text );
            model . JM103 = string . IsNullOrEmpty ( textBox71 . Text ) == true ? 0 : Convert . ToInt64 ( textBox71 . Text );
            model . JM102 = comboBox9 . Text;
            model . JM112 = string . IsNullOrEmpty ( textBox21 . Text ) == true ? 0 : Convert . ToDecimal ( textBox21 . Text );
            model . JM118 = string . IsNullOrEmpty ( textBox58 . Text ) == true ? 0 : Convert . ToInt32 ( textBox58 . Text );
            model . JM119 = string . IsNullOrEmpty ( textBox59 . Text ) == true ? 0 : Convert . ToDecimal ( textBox59 . Text );
            model . JM120 = string . IsNullOrEmpty ( textBox60 . Tag . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( textBox60 . Tag );
            model . JM121 = string . IsNullOrEmpty ( textBox61 . Text ) == true ? 0 : Convert . ToDecimal ( textBox61 . Text );
        }
        void build ( )
        {
            result = bll.ExistsOne( model );
            if ( label107.Visible == true )
                stateOfOdd = "维护新建";
            else
            {
                if ( saer == "1" )
                    stateOfOdd = "新增新建";
                else
                    stateOfOdd = "更改新建";
            }
            if ( result == false )
            {
                result = bll.Add( model ,"R_338" ,"胶合板、密度板采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"新建" ,stateOfOdd );
                if ( result == true )
                {
                    MessageBox.Show( "成功录入数据" );
                    table( );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND JM01='" + model.JM01 + "'";
                    refre( );
                }
                else
                    MessageBox.Show( "录入数据失败" );
            }
            else
                MessageBox.Show( "单号:" + model.JM01 + "\n\r物料名称" + model.JM09 + "\n\r长：" + model.JM94 + "\n\r宽：" + model.JM95 + "\n\r高：" + model.JM96 + "\n\r的数据已经存在,请核实后再录入" );
        }
        void builds ( )
        {
            DataTable acd = bll.GetDataTableContrast( model );
            if ( acd.Rows.Count > 0 )
            {
                //每张套数 每张单价 原价/m³必须与计划合同一致
                if ( acd.Select( "JM10='" + model.JM10 + "'" ).Length <= 0 )
                    MessageBox.Show( "每张套数与计划订单不一致,应为:" + acd.Rows[0]["JM10"].ToString( ) + "" );
                else
                {
                    if ( acd.Select( "JM11='" + model.JM11 + "'" ).Length <= 0 )
                        MessageBox.Show( "每张单价与计划订单不一致,应为:" + acd.Rows[0]["JM11"].ToString( ) + "" );
                    else
                    {
                        if ( acd.Select( "JM12='" + model.JM12 + "'" ).Length <= 0 )
                            MessageBox.Show( "原价/m³与计划订单不一致,应为:" + acd.Rows[0]["JM12"].ToString( ) + "" );
                        else
                            build( );
                    }
                }
            }
            else
                build( );
        }
        void outSourc ( )
        {
            if ( radioButton15.Checked )
                MessageBox.Show( "只能开外购合同" );
            else
            {
                string sx = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox71 ,comboBox2 ) ) ,0 ).ToString( );
                if ( !string.IsNullOrEmpty( sx ) && !string.IsNullOrEmpty( textBox11.Text ) )
                {
                    if ( Convert.ToDecimal( sx ) != Convert.ToDecimal( textBox11.Text ) )
                        MessageBox.Show( "外购数量有误,请核实" );
                    else
                        builds( );
                }
            }
        }
        void outSources ( )
        {
            if ( radioButton15.Checked )
                MessageBox.Show( "只能开外购合同" );
            else
            {
                string sx = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox71 ,comboBox2 ) ) ,0 ).ToString( );
                if ( !string.IsNullOrEmpty( sx ) && !string.IsNullOrEmpty( textBox11.Text ) )
                {
                    if ( Convert.ToDecimal( sx ) != Convert.ToDecimal( textBox11.Text ) )
                        MessageBox.Show( "外购数量有误,请核实" );
                    else
                        build( );
                }
            }
        }
        void plan ( )
        {
            if ( radioButton16.Checked == true )
            {
                if ( Logins.number == "MLL-0001" )
                {
                    string sx = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox71 ,comboBox2 ) ) ,0 ).ToString( );
                    if ( !string.IsNullOrEmpty( sx ) && !string.IsNullOrEmpty( textBox11.Text ) )
                    {
                        if ( Convert.ToDecimal( sx ) != Convert.ToDecimal( textBox11.Text ) )
                            MessageBox.Show( "外购数量有误,请核实" );
                        else
                            build( );
                    }
                }
                else
                    MessageBox.Show( "库存还有剩余,需要总经理补开" );
            }
            //只能开具库存合同
            else
            {
                if ( !string.IsNullOrEmpty( textBox12.Text ) && !string.IsNullOrEmpty( textBox1.Text ) )
                {
                    if ( Convert.ToDecimal( textBox12.Text ) < Convert.ToDecimal( textBox1.Text ) )
                        MessageBox.Show( "出库数量必须小于库存数量" );
                    //且出库数小于等于库存数量
                    else
                    {
                        string str = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox71 ,comboBox2 ) ) ,0 ).ToString( );
                        if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox1.Text ) )
                            MessageBox.Show( "出库数量有误,请核查" );
                        else
                            builds( );
                    }
                }
            }
        }
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox15.Text ) )
            {
                MessageBox.Show( "合同批号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox71.Text ) )
            {
                MessageBox.Show( "产品数量不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( model.JM03 ) || string.IsNullOrEmpty(textBox19.Text) )
            {
                MessageBox.Show( "请选择供应商" );
                return;
            }
            if ( string.IsNullOrEmpty( lookUpEdit3.Text ) )
            {
                MessageBox.Show( "请选择物料名称" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox14.Text ) )
            {
                MessageBox.Show( "E0.E1级别不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox2.Text ) )
            {
                MessageBox.Show( "每张套数不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox62.Text ) )
            {
                MessageBox.Show( "每张单价不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox20.Text ) )
            {
                MessageBox.Show( "原价/m³不可为空" );
                return;
            }
            if ( radioButton15.Checked == false && radioButton16.Checked == false )
            {
                MessageBox.Show( "请选择库存或外购" );
                return;
            }
            if ( radioButton16.Checked && dateTimePicker3.Value < MulaolaoBll . Drity . GetDt ( ) . AddDays( 5 ) )
            {
                MessageBox.Show( "约定供期必须在当天的基础上延迟5天" );
                return;
            }
            variable( );

            #region 计划订单  更改新建  流水号为空
            if ( ord == "计划" || string.IsNullOrEmpty( textBox68.Text ) )
            {
                //计划可以开具多份
                //同货号、物料名称、规格是否已经开过计划订单
                DataTable yesNoAcPlan = bll.GetDataTableYesOrNoPlan( model );
                //有  继续开  只能开外购  且每张套数  每张单价  原价/m³都必须与第一份计划订单相同
                if ( yesNoAcPlan.Rows.Count > 0 && string.IsNullOrEmpty( yesNoAcPlan.Rows[0]["AC18"].ToString( ) ) == false )
                {
                    DataTable yesNoAdPlan = bll.GetDataTableYesNoAdPlan( yesNoAcPlan.Rows[0]["AC18"].ToString( ) );
                    //有
                    if ( yesNoAdPlan.Rows.Count > 0 && !string.IsNullOrEmpty( yesNoAdPlan.Rows[0]["AD05"].ToString( ) ) )
                    {
                        if ( yesNoAcPlan.Rows[0]["AC03"].ToString( ) == yesNoAdPlan.Rows[0]["AD05"].ToString( ) )
                            outSources( );
                        else
                        {
                            //开合同人是否是MLL-0001
                            if ( model.JM08.Length >= 8 && model.JM08.Substring( 0 ,8 ) == "MLL-0001" )
                                outSourc( );
                            else
                                MessageBox.Show( "此合同为补开,请找总经理处理" );
                        }
                    }
                    else
                    {
                        //开合同人是否是MLL-0001
                        if ( model.JM08.Length >= 8 && model.JM08.Substring( 0 ,8 ) == "MLL-0001" )
                            outSourc( );
                        else
                            MessageBox.Show( "此合同为补开,请找总经理处理" );
                    }
                }
                else
                {
                    //无  直接开  只能开外购
                    outSources( );
                }
            }
            #endregion

            #region 实际订单      更改新建  流水号不为空
            else if ( ord == "实际" || !string.IsNullOrEmpty( textBox68.Text ) )
            {
                model.JM90 = textBox68.Text;
                bool result = pc.PlanActual( model.JM09 ,model.JM94 + "*" + model.JM95 + "*" + model.JM96 ,model.JM102 );
                bool vode = pc.PlanInDataBase( model.JM90 ,model.JM09 ,model.JM94 ,model.JM95 ,model.JM96 );
                if ( result == true )
                {
                    if ( vode == true )
                        outSources( );
                    else
                    {
                        if ( model.JM08.Length >= 8 && model.JM08.Substring( 0 ,8 ) == "MLL-0001" )
                            outSources( );
                        else
                            MessageBox.Show( "此单为超补,需要总经理处理" );
                    }
                }
                else
                {
                    if ( vode == true )
                        plan( );
                    else
                    {

                        if ( model.JM08.Length > 8 && model.JM08.Substring( 0 ,8 ) == "MLL-0001" )
                            plan( );
                        else
                            MessageBox.Show( "此单为超补,需要总经理处理" );
                    }

                }
            }
            #endregion
        }
        //Delete
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==DialogResult . Cancel )
                return;

            if ( label107.Visible == true )
                stateOfOdd = "维护删除";
            else
            {
                if ( saer == "1" )
                    stateOfOdd = "新增删除";
                else
                    stateOfOdd = "更改删除";
            }
            result = bll.Delete( model.IDX ,"R_338" ,"胶合板、密度板采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,model.JM01 ,"删除" ,stateOfOdd );
            if ( result == false )
                MessageBox.Show( "删除数据失败" );
            else
            {
                MessageBox.Show( "成功删除数据" );
                //grid.Rows.Remove( grid.Select( "idx='" + model.IDX + "'" )[0] );
                button13_Click ( null , null );
            }
        }
        //Update
        void upda ( )
        {
            //int num = bandedGridView1.FocusedRowHandle;
            //DataRow row;
            //if ( saer == "1" )
            //{
            //    row = gridcon.Rows[num];
            //    row.BeginEdit( );
            //    row["JM09"] = JM9;
            //    row["JM92"] = JM092;
            //    row["JM93"] = JM093;
            //    row["JM94"] = JM094;
            //    row["JM95"] = JM095;
            //    row["JM96"] = JM096;
            //    row["JM10"] = JM010;
            //    row["JM11"] = JM011;
            //    row["JM12"] = JM012;
            //    row["JM13"] = JM013;
            //    row["JM14"] = JM014;
            //    row["JM15"] = JM015;
            //    row["JM16"] = JM016;
            //    row["JM17"] = JM017;
            //    row["JM91"] = JM091;
            //    row["JM103"] = JM103;
            //    row["JM104"] = JM0104;
            //    row["JM107"] = JM0107;
            //    row.EndEdit( );
            //}
            //else if ( saer == "2" )
            //{
            //    row = grid.Rows[num];
            //    row.BeginEdit( );
            //    row["JM09"] = JM9;
            //    row["JM92"] = JM092;
            //    row["JM93"] = JM093;
            //    row["JM94"] = JM094;
            //    row["JM95"] = JM095;
            //    row["JM96"] = JM096;
            //    row["JM10"] = JM010;
            //    row["JM11"] = JM011;
            //    row["JM12"] = JM012;
            //    row["JM13"] = JM013;
            //    row["JM14"] = JM014;
            //    row["JM15"] = JM015;
            //    row["JM16"] = JM016;
            //    row["JM17"] = JM017;
            //    row["JM91"] = JM091;
            //    row["JM103"] = JM103;
            //    row["JM104"] = JM0104;
            //    row["JM107"] = JM0107;
            //    row.EndEdit( );
            //}
            table( );

        }
        void edit ( )
        {
            if ( label107.Visible == true )
                stateOfOdd = "维护编辑";
            else
            {
                if ( saer == "1" )
                    stateOfOdd = "新增编辑";
                else
                    stateOfOdd = "更改编辑";
            }

            result = bll.ExistsOne( model );
            if ( result == false )
            {
                result = bll.Update( model ,"R_338" ,"胶合板、密度板采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"编辑" ,stateOfOdd );
                if ( result == false )
                    MessageBox.Show( "录入数据失败" );
                else
                {
                    MessageBox.Show( "成功录入数据" );
                    strWhere = "1=1";
                    strWhere = strWhere + " AND JM01='" + model.JM01 + "'";
                    refre( );
                }
            }
            else
                MessageBox.Show( "单号:" + model.JM01 + "中已经存在\n\r物料名称" + model.JM09 + "\n\r长：" + model.JM94 + "\n\r宽：" + model.JM95 + "\n\r高：" + model.JM96 + "\n\r的数据,请核实后再编辑" );
        }
        void planOrActual ( )
        {
            if ( radioButton15.Checked )
            {
                if ( !string.IsNullOrEmpty( textBox12.Text ) && !string.IsNullOrEmpty( textBox1.Text ) )
                {
                    if ( Convert.ToDecimal( textBox12.Text ) < Convert.ToDecimal( textBox1.Text ) )
                        MessageBox.Show( "出库数量大于库存数量,请更改出库数量" );
                    else
                    {
                        string str = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox71 ,comboBox2 ) ) ,0 ).ToString( );
                        if ( !string.IsNullOrEmpty( str ) )
                        {
                            if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox1.Text ) )
                                MessageBox.Show( "出库数量有误,请核查" );
                            else
                                edit( );
                        }
                    }
                }
            }
            else
            {
                string str = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox71 ,comboBox2 ) ) ,0 ).ToString( );
                if ( !string.IsNullOrEmpty( str ) && !string.IsNullOrEmpty( textBox11.Text ) )
                {
                    if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox11.Text ) )
                        MessageBox.Show( "外购数量有误,请核查" );
                    else
                    {
                        if ( Logins.number == "MLL-0001" )
                            edit( );
                        else
                        {
                            if ( !string.IsNullOrEmpty( textBox12.Text ) && Convert.ToDecimal( textBox12.Text ) > 0 )
                                MessageBox.Show( "库存数量不为零,不可以开外购合同" );
                            else
                                edit( );
                        }
                    }
                }
            }
        }
        void edit_One ( )
        {
            if ( label107.Visible == true )
                stateOfOdd = "维护编辑";
            else
            {
                if ( saer == "1" )
                    stateOfOdd = "新增编辑";
                else
                    stateOfOdd = "更改编辑";
            }

            result = bll.Update( model ,"R_338" ,"胶合板、密度板采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"编辑" ,stateOfOdd );
            if ( result == false )
                MessageBox.Show( "数据编辑失败" );
            else
            {
                MessageBox.Show( "数据编辑成功" );
                strWhere = "1=1";
                strWhere = strWhere + " AND JM01='" + model.JM01 + "'";
                refre( );
            }
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( textBox15.Text == "" )
            {
                MessageBox.Show( "合同批号不可为空" );
                return;
            }
            if ( lookUpEdit3.Text == "" )
            {
                MessageBox.Show( "请选择物料名称" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox71.Text ) )
            {
                MessageBox.Show( "产品数量不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox14.Text ) )
            {
                MessageBox.Show( "E0.E1级别不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox2.Text ) )
            {
                MessageBox.Show( "每张套数不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox62.Text ) )
            {
                MessageBox.Show( "每张单价不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox20.Text ) )
            {
                MessageBox.Show( "原价/m³不可为空" );
                return;
            }
            if ( radioButton15.Checked == false && radioButton16.Checked == false )
            {
                MessageBox.Show( "请选择库存或者外购" );
                return;
            }
            variable( );

            if ( pm9 == model.JM09 && jm094 == model.JM94 && jm095 == model.JM95 && jm096 == model.JM96 )
            {
                if ( radioButton15.Checked )
                {
                    if ( !string.IsNullOrEmpty( textBox12.Text ) && !string.IsNullOrEmpty( textBox1.Text ) )
                    {
                        if ( Convert.ToDecimal( textBox12.Text ) < Convert.ToDecimal( textBox1.Text ) )
                            MessageBox.Show( "出库数量大于库存数量,请更改出库数量" );
                        else
                        {
                            string str = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox71 ,comboBox2 ) ) ,0 ).ToString( );

                            if ( !string.IsNullOrEmpty( str ) )
                            {
                                if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox1.Text ) )
                                    MessageBox.Show( "出库数量有误,请核查" );
                                else
                                    edit_One( );
                            }
                        }
                    }
                }
                else
                {
                    string str = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox71 ,comboBox2 ) ) ,0 ).ToString( );
                    if ( !string.IsNullOrEmpty( str ) && !string.IsNullOrEmpty( textBox11.Text ) )
                    {
                        if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox11.Text ) )
                            MessageBox.Show( "外购数量有误,请核查" );
                        else
                        {
                            if ( Logins.number == "MLL-0001" )
                                edit_One( );
                            else
                            {
                                if ( !string.IsNullOrEmpty( textBox12.Text ) && textBox12.Text != "0" )
                                    MessageBox.Show( "库存数量不为零,不可以开外购合同" );
                                else
                                    edit_One( );
                            }
                        }
                    }
                }
            }
            else
            {
                if ( ord == "计划" || string.IsNullOrEmpty( textBox68.Text ) )
                {
                    DataTable plan = bll.GetDataTablePlan( model );
                    if ( plan.Rows.Count > 0 && !string.IsNullOrEmpty( plan.Rows[0]["AD05"].ToString( ) ) && plan.Rows[0]["AD05"].ToString( ) != "0" )
                        //MessageBox.Show( "库存表中已经存在\n\r货号:" + model.JM102 + "\n\r物料名称:" + model.JM09 + "\n\r规格:" + model.JM94 + "*" + model.JM95 + "*" + model.JM96 + "\n\r的记录,且入库数量大于出库数量。不允许新建此计划订单" );
                        planOrActual( );
                    else
                        planOrActual( );
                }
                else if ( ord == "实际" || !string.IsNullOrEmpty( textBox68.Text ) )
                {
                    DataTable dwo = bll.GetDataTableDwo( model );
                    if ( dwo.Rows.Count > 0 )
                    {
                        //开过的合同中是否包含此流水(针对可能合批)
                        for ( int k = 0 ; k < dwo.Rows.Count ; k++ )
                        {
                            if ( dwo.Rows[k]["JM90"].ToString( ).Contains( model.JM90 ) == true || model.JM90.Contains( dwo.Rows[k]["JM90"].ToString( ) ) == true )
                            {
                                if ( model.JM08.Length > 8 && model.JM08.Substring( 0 ,8 ) == "MLL-0001" )
                                {
                                    planOrActual( );
                                    break;
                                }
                                else
                                {
                                    MessageBox.Show( "此合同为补开,请联系总经理处理" );
                                    break;
                                }
                            }
                            else if ( k == dwo.Rows.Count - 1 )
                                planOrActual( );
                        }
                    }
                    else
                        planOrActual( );
                }
            }
        }
        //Refresh
        private void button13_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            strWhere = strWhere + " AND JM01='" + model.JM01 + "'";
            refre( );

            model . JM102 = comboBox9 . Text;
            wl = bll . GetDataTableNum ( model . JM102 );
            table ( );
        }
        void refre ( )
        {
            if ( string.IsNullOrEmpty( strWhere ) )
                strWhere = "1=1";
            grid = bll.GetDataTableAll( strWhere );
            gridControl1.DataSource = grid;
        }
        //acture
        yanpinSelect ys = new yanpinSelect( );
        private void button6_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox.Show( "流水号:" + model.JM90 + "\n\r物料名称:" + comboBox1.Text + "\n\r长:" + textBox84.Text + "\n\r宽:" + textBox83.Text + "\n\r高:" + textBox85.Text + "\n\r已经到货？" ,"提示" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
            {
                ys.ysOne = model.JM01;
                ys.ysTwo = lookUpEdit3.Text;
                ys.ysThr = textBox84.Text;
                ys.ysFou = textBox83.Text;
                ys.ysFiv = textBox85.Text;
                ys.ysSix = "R_338";
                ys.StartPosition = FormStartPosition.CenterScreen;
                ys.ShowDialog( );
            }          
        }
        //batch
        SelectAll.NumberEditContract numQuery = new SelectAll.NumberEditContract( );
        private void button15_Click ( object sender ,EventArgs e )
        {
            numQuery.textBox1.Text = textBox71.Text;
            numQuery.StartPosition = FormStartPosition.CenterScreen;
            numQuery.PassDataBetweenForm += new SelectAll.NumberEditContract.PassDataBetweenFormHandler( numQuery_PassDataBetweenForm );
            numQuery.ShowDialog( );

            if ( numQu == "yes" )
            {
                if ( label107.Visible == true )
                    stateOfOdd = "维护批量编辑";
                else
                {
                    if ( saer == "1" )
                        stateOfOdd = "新增批量编辑";
                    else
                        stateOfOdd = "更改批量编辑";
                }
                for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                {
                    model.JM10 = string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["JM10"].ToString( ) ) == true ? 0 : Convert.ToDecimal( bandedGridView1.GetDataRow( i )["JM10"].ToString( ) );
                    model.IDX = string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( bandedGridView1.GetDataRow( i )["idx"].ToString( ) );
                    model.JM14 = bandedGridView1.GetDataRow( i )["JM14"].ToString( );
                    if ( model.JM14 == "外购" )
                    {
                        model.JM104 = model.JM10 == 0 ? 0 : Math.Round( model.JM103 / model.JM10 ,0 );
                        model.JM15 = 0;
                    }
                    else if ( model.JM14 == "库存" )
                    {
                        model.JM104 = 0;
                        model.JM15 = model.JM10 == 0 ? 0 : Math.Round( model.JM103 / model.JM10 ,0 );
                    }
                    else
                    {
                        model.JM104 = 0;
                        model.JM15 = 0;
                    }
                    result = false;
                    result = bll.UpdateBatch( model ,"R_338" ,"胶合板、密度板采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"批量编辑" ,stateOfOdd );
                    if ( result == false )
                    {
                        MessageBox.Show( "编辑数据失败" );
                        break;
                    }
                    else if ( i == bandedGridView1.RowCount - 1 )
                    {
                        MessageBox.Show( "编辑数据成功" );
                        strWhere = "1=1";
                        strWhere = strWhere + " AND JM01='" + model.JM01 + "'";
                        refre( );
                    }
                }
            }
        }
        private void numQuery_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            numQu = e.ConTwo;
            model.JM103 = string.IsNullOrEmpty( e.ConOne ) == true ? 0 : Convert.ToInt64( e.ConOne );
        }
        #endregion

    }
}
