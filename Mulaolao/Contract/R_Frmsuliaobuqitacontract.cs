using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Mulaolao.Class;
using StudentMgr;
using Mulaolao.Bom;
using Mulaolao.Raw_material_cost;
using FastReport;
using FastReport.Export.Xml;
using Mulaolao.Schedule_control;
using Mulaolao.Other;
using Mulaolao.Contract.yesOrNoPlan;
using System.Text;
using System.Collections.Generic;

namespace Mulaolao.Contract
{
    public partial class R_Frmsuliaobuqitacontract : FormChild
    {
        public R_Frmsuliaobuqitacontract (/*Form1 fm*/ )
        {
            //this.MdiParent = fm;
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,view } );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . gridView1 ,this . view } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.SuLiaoBuQiContractLibrary model = new MulaolaoLibrary.SuLiaoBuQiContractLibrary( );
        MulaolaoBll.Bll.SuLiaoBucontractBll bll = new MulaolaoBll.Bll.SuLiaoBucontractBll( );
        Youqicaigou yc = new Youqicaigou( );
        DataTable de, wpmc, biao, name, libraryTable,partTable;
        Report report = new Report( );
        DataSet RDataSet;
        Factory fc = new Factory( );
        SpecialPowers sp = new SpecialPowers( ); List<string> speList = new List<string>( );
        yesOrNoPlanActual pc = new yesOrNoPlanActual( ); //Dictionary<string ,string> dicStr = new Dictionary<string ,string>( );
        string copy = "", file = "", numQu = "", stateOfOdd = "", conOne = "";
        List<SplitContainer> spList = new List<SplitContainer>( );List<TabPage> pageList = new List<TabPage>( );
        
        private void R_Frmsuliaobuqitacontract_Load ( object sender ,EventArgs e )
        {
            Power( this );

            spList.Clear( );
            spList.AddRange( new SplitContainer[] { splitContainer1 ,splitContainer2 } );
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableFalse( spList );
            pageList.Clear( );
            pageList.AddRange( new TabPage[] { tabPageOne ,tabPageTwo ,tabPageTre ,tabPageFor } );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableFalse( pageList );

            textBox29.Enabled = false;

            label78.Visible = label98.Visible = false;

            comboBox1.Items.Clear( );
            comboBox1.Items.AddRange( new string[] { "包装辅料" ,"塑料件" ,"其它材料" } );

            name = bll.GetDataTablePerson( );
            lookUpEdit1.Properties.DataSource = name;
            lookUpEdit1.Properties.DisplayMember = "DBA002";
            lookUpEdit1.Properties.ValueMember = "DBA001";

            lookUpEdit2.Properties.DataSource = bll.GetDataTableWork( );
            lookUpEdit2.Properties.DisplayMember = "DBA002";
            lookUpEdit2.Properties.ValueMember = "DBA001";

            anOther( );

            if ( Logins.number == "MLL-0001" )
                checkBox17.Visible = true;
            else
                checkBox17.Visible = false;
        }
        
        private void R_Frmsuliaobuqitacontract_Shown ( object sender ,EventArgs e )
        {
            model.PJ92 = Merges.oddNum;
            if ( !string.IsNullOrEmpty( model.PJ92 ) )
                autoQuery( );
            Merges.oddNum = "";
        }

        #region 打印 导出
        private void CreateDataSet ( )
        {
            RDataSet = new DataSet( );

            DataTable print = SqlHelper.ExecuteDataTable( "SELECT PJ93,PJ95,PJ01,PJ18,PJ09,PJ89,PJ96,PJ15,CONVERT( BIGINT, ROUND(PJ11 * PJ96 + PJ10,0) ) U0,PJ10, PJ11,CONVERT( DECIMAL( 11, 2 ), (PJ12*(PJ11*PJ96+PJ10)-PJ16)/PJ96) U1,PJ17, PJ12, PJ13, PJ16,PJ12 * (PJ11 * PJ96 + PJ10) - PJ16 U2,CONVERT( VARCHAR( 20 ), PJ19, 102 ) PJ19,CONVERT( VARCHAR( 20 ), PJ20, 102 ) PJ20,PJ105 FROM R_PQS WHERE PJ92=@PJ92 AND PJ09!=''" ,new SqlParameter( "@PJ92" ,model.PJ92 ) );
            DataTable prints = SqlHelper.ExecuteDataTable( "SELECT DBA002,DBA028,DGA003,DGA017,DGA009,DGA011,PJ04,CONVERT(VARCHAR(20),PJ05,102) PJ05,PJ06,CONVERT(VARCHAR(20),PJ07,102) PJ07,PJ94,PJ08,PJ21,PJ22,CONVERT( VARCHAR( 20 ), PJ23, 102 ) PJ23, PJ24, PJ25, CONVERT( VARCHAR( 20 ), PJ26, 102 ) PJ26, PJ27, PJ28, CONVERT( VARCHAR( 20 ), PJ29, 102 ) PJ29, PJ30, PJ31, CONVERT( VARCHAR( 20 ), PJ32, 102 ) PJ32,PJ33, PJ34, PJ35, PJ36, PJ37, PJ38, PJ39, PJ40, PJ41,CASE WHEN PJ42 = 'F' AND PJ43 = 'F' AND PJ44 = 'F' AND PJ45 = 'F' THEN 'F' WHEN PJ42 = 'T' OR PJ43 = 'T' OR PJ44 = 'T' OR PJ45 = 'T' THEN 'T' END U7,PJ42, PJ43, PJ44, PJ45, PJ46, PJ47, PJ48, PJ49, PJ50, PJ51, PJ52, PJ53, PJ54, PJ55, PJ56, PJ57, PJ58, PJ59, PJ60, PJ61, PJ62, PJ63, PJ64, PJ65, PJ66, PJ67, PJ68, PJ78, CONVERT( VARCHAR( 20 ), PJ79, 102 ) PJ79, PJ69, PJ70, PJ71, PJ72, PJ73,PJ74, PJ75, PJ76, PJ77, PJ80, PJ81, CONVERT( VARCHAR( 20 ), PJ82, 102 ) PJ82, PJ83, CONVERT( VARCHAR( 20 ), PJ84, 102 ) PJ84, PJ85, CONVERT( VARCHAR( 20 ), PJ86, 102 ) PJ86, CONVERT( VARCHAR( 20 ), PJ87, 102 ) PJ87,PJ101,PJ92,CASE WHEN PJ01='' THEN 'F' WHEN PJ01!='' THEN CASE WHEN PJ15='库存' THEN 'T' ELSE '1' END END PJ,ISNULL(PJ100,'F') PJ100 FROM R_PQS A, TPADBA B, TPADGA C WHERE A.PJ02 = B.DBA001 AND A.PJ03 = C.DGA001 AND PJ92=@PJ92" , new SqlParameter( "@PJ92" ,model.PJ92 ) );

            print.TableName = "R_PQS";
            prints.TableName = "R_PQSS";
            RDataSet.Tables.Add( print );
            RDataSet.Tables.Add( prints );
        }
        #endregion

        #region 事件
        void anOther ( )
        {
            DataTable dAn = SqlHelper.ExecuteDataTable( "SELECT PJ22,PJ25,PJ28,PJ31,PJ67,PJ68,PJ78 FROM R_PQS" );
            //乙方
            comboBox10.DataSource = dAn.DefaultView.ToTable( true ,"PJ78" );
            comboBox10.DisplayMember = "PJ78";
            //甲方
            comboBox11.DataSource = dAn.DefaultView.ToTable( true ,"PJ68" );
            comboBox11.DisplayMember = "PJ68";
            //检验人
            comboBox12.DataSource = dAn.DefaultView.ToTable( true ,"PJ67" );
            comboBox12.DisplayMember = "PJ67";
            //选填人
            comboBox19.DataSource = dAn.DefaultView.ToTable( true ,"PJ22" );
            comboBox19.DisplayMember = "PJ22";
            comboBox18.DataSource = dAn.DefaultView.ToTable( true ,"PJ25" );
            comboBox18.DisplayMember = "PJ25";
            comboBox16.DataSource = dAn.DefaultView.ToTable( true ,"PJ28" );
            comboBox16.DisplayMember = "PJ28";
            comboBox14.DataSource = dAn.DefaultView.ToTable( true ,"PJ31" );
            comboBox14.DisplayMember = "PJ31";
        }
        //货号
        private void comboBox5_TextChanged ( object sender ,EventArgs e )
        {
            every( );
            previousOfPrice( );
        }
        private void textBox17_TextChanged ( object sender ,EventArgs e )
        {
            //PJ95 = comboBox5.Text;
            //if ( string . IsNullOrEmpty ( textBox17 . Text ) )
            //    wpmc = SqlHelper . ExecuteDataTable ( "SELECT DISTINCT GS07 PJ09,GS08 PJ89,GS09 PJ17,GS10 PJ11 FROM R_PQP WHERE GS07!=''  AND GS48 =@GS48 UNION SELECT DISTINCT GS52 PJ09,GS57 PJ89,GS58 PJ11,GS59 PJ17 FROM R_PQP WHERE GS52!='' AND GS48=@GS48" ,new SqlParameter ( "@GS48" ,PJ95 ) );
            //else
            //{
            //    PJ01 = textBox17 . Text;
            //    if ( !string . IsNullOrEmpty ( PJ01 ) )
            //        wpmc = SqlHelper . ExecuteDataTable ( "SELECT DISTINCT GS07 PJ09,GS08 PJ89,GS09 PJ17,GS10 PJ11 FROM R_PQP WHERE GS07!=''  AND GS01=@GS01 UNION SELECT DISTINCT GS52 PJ09,GS57 PJ89,GS58 PJ11,GS59 PJ17 FROM R_PQP WHERE GS52!='' AND GS01=@GS01" ,new SqlParameter ( "@GS01" ,PJ01 ) );
            //}
            //every( );
        }
        void every ( )
        {
            PJ95 = comboBox5 . Text;
            if ( !string . IsNullOrEmpty ( textBox17 . Text ) )
            {
                PJ01 = textBox17 . Text;

                wpmc = SqlHelper . ExecuteDataTable ( "SELECT DISTINCT GS07 PJ09,GS08 PJ89,GS09 PJ17,GS10 PJ11 FROM R_PQP WHERE GS07!='' AND GS70='R_347' AND GS01 =@GS01" ,new SqlParameter ( "@GS01" ,PJ01 ) );
                // UNION SELECT DISTINCT GS52 PJ09,GS57 PJ89,GS58 PJ11,GS59 PJ17 FROM R_PQP WHERE GS52!='' AND GS48=@GS48


                //wpmc = SqlHelper . ExecuteDataTable ( "SELECT DISTINCT GS07 PJ09,GS08 PJ89,GS09 PJ17,GS10 PJ11 FROM R_PQP WHERE GS07!=''  AND GS01=@GS01 " ,new SqlParameter ( "@GS01" ,PJ01 ) );
                //UNION SELECT DISTINCT GS52 PJ09,GS57 PJ89,GS58 PJ11,GS59 PJ17 FROM R_PQP WHERE GS52!='' AND GS01=@GS01

                biao = SqlHelper . ExecuteDataTable ( "SELECT '' PJ09,PJ10,0.0 PJ11,PJ12,PJ13,PJ14,PJ15,PJ16,'' PJ17,PJ18,'' PJ89 FROM R_PQS WHERE PJ01=@PJ01" ,new SqlParameter ( "@PJ01" ,PJ01 ) );
            }

            if ( string.IsNullOrEmpty( textBox17.Text ) )
                biao = SqlHelper.ExecuteDataTable( "SELECT PJ09,PJ10,PJ11,PJ12,PJ13,PJ14,PJ15,PJ16,PJ17,PJ18,PJ89 FROM R_PQS WHERE PJ95=@PJ95" ,new SqlParameter( "@PJ95" ,PJ95 ) );
            //else
            //{
            //    PJ01 = textBox17.Text;
            //    if ( !string . IsNullOrEmpty ( PJ01 ) )
            //        biao = SqlHelper.ExecuteDataTable( "SELECT PJ09,PJ10,PJ11,PJ12,PJ13,PJ14,PJ15,PJ16,PJ17,PJ18,PJ89 FROM R_PQS WHERE PJ01=@PJ01" ,new SqlParameter( "@PJ01" ,PJ01 ) );
            //}
            if ( wpmc != null )
                biao.Merge( wpmc );
            if ( biao != null && biao . Rows . Count > 0 )
            {
                //物料名称
                //DataTable wlmc= biao.DefaultView.ToTable( true ,"PJ09" );
                partTable = biao . DefaultView . ToTable ( true ,"PJ09" ,"PJ89" ,"PJ11" );
                gridLookUpEdit1 . Properties . DataSource = partTable;
                gridLookUpEdit1 . Properties . DisplayMember = "PJ09";
                gridLookUpEdit1 . Properties . ValueMember = "PJ09";
                //物品余量
                //DataTable yl = biao.DefaultView.ToTable(true ,"PJ10");
                comboBox13 . DataSource = biao . DefaultView . ToTable ( true ,"PJ10" );
                comboBox13 . DisplayMember = "PJ10";
                //现价
                //DataTable xj = biao.DefaultView.ToTable(true ,"PJ12");
                comboBox3 . DataSource = biao . DefaultView . ToTable ( true ,"PJ12" );
                comboBox3 . DisplayMember = "PJ12";
                //预付款
                //DataTable yfk = biao.DefaultView.ToTable(true ,"PJ16");
                comboBox15 . DataSource = biao . DefaultView . ToTable ( true ,"PJ16" );
                comboBox15 . DisplayMember = "PJ16";
                //品牌
                //DataTable pa = biao.DefaultView.ToTable(true ,"PJ18");
                comboBox17 . DataSource = biao . DefaultView . ToTable ( true ,"PJ18" );
                comboBox17 . DisplayMember = "PJ18";
                //规格
                //textBox26 . DataSource = biao . DefaultView . ToTable ( true ,"PJ89" );
                //textBox26 . DisplayMember = "PJ89";
                //每套用量
                //textBox37 . DataSource = biao . DefaultView . ToTable ( true ,"PJ11" );
                //textBox37 . DisplayMember = "PJ11";
                //计价单位
                comboBox8 . DataSource = biao . DefaultView . ToTable ( true ,"PJ17" );
                comboBox8 . DisplayMember = "PJ17";
            }
        }
        void previousOfPrice ( )
        {
            if ( string.IsNullOrEmpty( comboBox5.Text ) || string.IsNullOrEmpty( gridLookUpEdit1.Text ) )
                textBox7.Text = "0";
            else
            {
                DataTable dm = bll.GetDataTableOfPrice( comboBox5.Text ,gridLookUpEdit1.Text );
                if ( dm != null && dm.Rows.Count > 0 )
                    textBox7.Text = dm.Rows[0]["PJ12"].ToString( );
                else
                    textBox7.Text = "0";
            }
        }
        private void gridLookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = view . GetFocusedDataRow ( );
            if ( row == null )
            {
                if ( partTable != null && partTable . Rows . Count > 0 && partTable . Select ( "PJ09='" + gridLookUpEdit1 . Text + "'" ) . Length > 0 )
                    row = partTable . Select ( "PJ09='" + gridLookUpEdit1 . Text + "'" ) [ 0 ];
                if ( row == null )
                    return;
            }
            textBox37 . Text = row [ "PJ11" ] . ToString ( );
            textBox26 . Text = row [ "PJ89" ] . ToString ( );
            previousOfPrice ( );
        }
        //物料名称
        private void comboBox2_SelectedValueChanged ( object sender ,EventArgs e )
        {
            //if ( !string.IsNullOrEmpty( gridLookUpEdit1.Text ) && biao.Select( "PJ09='" + gridLookUpEdit1.Text + "'" ).Length > 0 )
            //{
            //    comboBox13.Text = biao.Select( "PJ09='" + gridLookUpEdit1.Text + "'" )[0]["PJ10"].ToString( );
            //    comboBox3.Text = biao.Select( "PJ09='" + gridLookUpEdit1.Text + "'" )[0]["PJ12"].ToString( );
            //    textBox7.Text = biao.Select( "PJ09='" + gridLookUpEdit1.Text + "'" )[0]["PJ13"].ToString( );
            //    comboBox15.Text = biao.Select( "PJ09='" + gridLookUpEdit1.Text + "'" )[0]["PJ16"].ToString( );
            //    comboBox17.Text = biao.Select( "PJ09='" + gridLookUpEdit1.Text + "'" )[0]["PJ18"].ToString( );
            //    textBox26.Text = biao.Select( "PJ09='" + gridLookUpEdit1.Text + "'" )[0]["PJ89"].ToString( );
            //    textBox37.Text = biao.Select( "PJ09='" + gridLookUpEdit1.Text + "'" )[0]["PJ11"].ToString( );
            //    comboBox8.Text = biao.Select( "PJ09='" + gridLookUpEdit1.Text + "'" )[0]["PJ17"].ToString( );
            //}
            previousOfPrice( );
        }
        //AQL
        private void textBox59_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox58_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox57_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox18_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox12_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox10_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox24_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox23_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox22_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //抽查数量
        private void textBox55_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //预付款
        private void comboBox15_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //现价
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
            if ( comboBox3.Text != "" && !DateDayRegise.elevenForNumber( comboBox3 ) )
            {
                this.comboBox3.Text = "";
                MessageBox.Show( "只允许输入整数部分最多七位,小数部分最多四位,如9999999.9999,请重新输入" );
            }
        }
        //物品余量
        private void comboBox13_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //表格
        string pj9 = "", gs008 = "";
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            DataRow row = gridView1 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            gridLookUpEdit1 . Text = row[ "PJ09" ] . ToString ( );
            textBox26 . Text = row[ "PJ89" ] . ToString ( );
            comboBox13 . Text = row[ "PJ10" ] . ToString ( );
            textBox37 . Text = row[ "PJ11" ] . ToString ( );
            comboBox3 . Text = row[ "PJ12" ] . ToString ( );
            textBox7 . Text = row[ "PJ13" ] . ToString ( );
            comboBox15 . Text = row [ "PJ16" ] . ToString ( );
            comboBox8 . Text = row [ "PJ17" ] . ToString ( );
            comboBox17 . Text = row [ "PJ18" ] . ToString ( );
            comboBox1 . Text = row [ "PJ105" ] . ToString ( );
            if ( row [ "PJ19" ] . ToString ( ) == "" )
                dateTimePicker4 . Value = MulaolaoBll . Drity . GetDt ( );
            else
                dateTimePicker4 . Value = Convert . ToDateTime ( row [ "PJ19" ] . ToString ( ) );
            if ( row [ "PJ20" ] . ToString ( ) == "" )
                dateTimePicker5 . Value = MulaolaoBll . Drity . GetDt ( );
            else
                dateTimePicker5 . Value = Convert . ToDateTime ( row [ "PJ20" ] . ToString ( ) );
            if ( row [ "PJ15" ] . ToString ( ) == "库存" )
            {
                radioButton10 . Checked = true;
                //radioButton11_CheckedChanged( null ,null );
                radioButton10_CheckedChanged ( null ,null );
                textBox15 . Text = row [ "PJ14" ] . ToString ( );
            }
            else if ( row [ "PJ15" ] . ToString ( ) == "外购" )
            {
                radioButton11 . Checked = true;
                //radioButton10_CheckedChanged( null ,null );
                radioButton11_CheckedChanged ( null ,null );
                textBox35 . Text = row [ "PJ97" ] . ToString ( );
            }
            //if ( gridView1.GetFocusedRowCellValue( "PJ100" ).ToString( ).Trim( ) == "T" )
            //    checkBox17.Checked = true;
            //else
            //    checkBox17.Checked = false;
            if ( !string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) )
                id = Convert . ToInt64 ( row [ "idx" ] . ToString ( ) );
            pj9 = gridLookUpEdit1 . Text;
            gs008 = textBox26 . Text;
        }
        //采购人
        private void lookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit1.EditValue != null )
            {
                PJ02 = lookUpEdit1.EditValue.ToString( );
                textBox3.Text = name.Select( "DBA001='" + PJ02 + "'" )[0]["DBA028"].ToString( );
            }
        }
        //乙方
        private void textBox1_TextChanged ( object sender ,EventArgs e )
        {
            DataTable drt = SqlHelper.ExecuteDataTable( "SELECT DGA003,DGA011,DGA017,DGA009 FROM TPADGA WHERE DGA001=@DGA001" ,new SqlParameter( "@DGA001" ,PJ03 ) );
            if ( drt.Rows.Count > 0 )
            {
                textBox1.Text = drt.Rows[0]["DGA003"].ToString( );
                textBox5.Text = drt.Rows[0]["DGA017"].ToString( );
                textBox6.Text = drt.Rows[0]["DGA009"].ToString( );
                textBox4.Text = drt.Rows[0]["DGA011"].ToString( );
            }
        }
        //窗体关闭
        private void R_Frmsuliaobuqitacontract_FormClosing ( object sender ,FormClosingEventArgs e )
        {
            if ( toolSave.Enabled )
            {
                cancel( );
            }
        }
        //成本员
        private void button12_Click ( object sender ,EventArgs e )
        {
            if ( textBox11.Text == "" )
                textBox11.Text = Logins.username;
            else if ( textBox11.Text != "" && textBox11.Text == Logins.username )
                textBox11.Text = "";

            dateTimePicker2 . Value = DateTime . Now;
        }
        //开合同人
        private void button11_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox9.Text ) )
            {
                textBox9.Text = Logins.username;
                PJ04 = textBox9.Text;
                string[] str = new string[2];
                str = oddNumbers.contractBatch( "R_PQS" ,PJ04 ,textBox9 ,textBox14 ,"PJ08" );
                if ( str[0] == "" )
                    textBox9.Text = "";
                else
                    PJ08 = str[1];
                textBox14.Text = str[1];
            }
            else if ( !string.IsNullOrEmpty( textBox9.Text ) && textBox9.Text == Logins.username )
            {
                textBox9.Text = "";
                PJ04 = textBox9.Text;
                PJ08 = "";
                textBox14.Text = "";
            }
            if ( textBox68.Text == "" )
                textBox68.Text = Logins.username;
            else if ( textBox68.Text != "" && textBox68.Text == Logins.username )
                textBox68.Text = "";

            dateTimePicker1 . Value = DateTime . Now;
        }
        //乙方代表
        private void button8_Click ( object sender ,EventArgs e )
        {
            if ( textBox69.Text == "" )
                textBox69.Text = Logins.username;
            else if ( textBox69.Text != "" && textBox69.Text == Logins.username )
                textBox69.Text = "";
            dateTimePicker11.Value = MulaolaoBll . Drity . GetDt ( );
        }
        //甲方代表
        private void button7_Click ( object sender ,EventArgs e )
        {

        }
        //审核人
        private void button9_Click ( object sender ,EventArgs e )
        {
            if ( textBox27.Text == "" )
                textBox27.Text = Logins.username;
            else if ( textBox27.Text != "" && textBox27.Text == Logins.username )
                textBox27.Text = "";

            dateTimePicker15.Value = MulaolaoBll . Drity . GetDt ( );
        }
        //复核人
        private void button10_Click ( object sender ,EventArgs e )
        {
            if ( textBox71.Text == "" )
                textBox71.Text = Logins.username;
            else if ( textBox71.Text != "" && textBox71.Text == Logins.username )
                textBox71.Text = "";
            dateTimePicker12.Value = MulaolaoBll . Drity . GetDt ( );
        }
        //使用库存数量
        private void textBox15_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox15 );
        }
        private void textBox15_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox15 );
        }
        private void textBox15_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox15.Text != "" && !DateDayRegise.twelveFourNumber( textBox15 ) )
            {
                this.textBox15.Text = "";
                MessageBox.Show( "只允许输入整数部分最多六位,小数部分最多四位,如99999999.9999,请重新输入" );
            }
        }
        //使用库存
        private void radioButton10_CheckedChanged ( object sender ,EventArgs e )
        {
            if ( radioButton10.Checked && ( ord == "实际" || !string.IsNullOrEmpty( textBox17.Text ) ) )
            {
                fc.yesOrNoOf( comboBox5.Text ,gridLookUpEdit1.Text ,textBox26.Text ,textBox34 ,textBox2 ,textBox21.Text );

                textBox35.Text = Math.Round( Convert.ToDecimal( Operation.MultiThrTbCbAdd( textBox21 ,textBox37 ,comboBox13 ,textBox34.Text ) ) ,4 ).ToString( );

                //if ( string.IsNullOrEmpty( textBox34.Text ) || textBox34.Text == "0" )
                //    textBox15.Text = "";
                //else
                textBox15.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTAdd( textBox21 ,textBox37 ,comboBox13 ) ) ,4 ).ToString( );
            }
        }
        //使用外购
        private void radioButton11_CheckedChanged ( object sender ,EventArgs e )
        {
            if ( radioButton11.Checked && ( ord == "实际" || !string.IsNullOrEmpty( textBox17.Text ) ) )
                get( );
            else
            {
                fc.yesOrNoOf( comboBox5.Text ,gridLookUpEdit1.Text ,textBox26.Text ,textBox34 ,textBox2 ,textBox21.Text );
                textBox35.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTAdd( textBox21 ,textBox37 ,comboBox13 ) ) ,4 ).ToString( );
            }

        }
        void get ( )
        {
            string str = "";
            PJ95 = comboBox5.Text;
            PJ009 = gridLookUpEdit1.Text;
            PJ089 = textBox26.Text;
            //AC16=@AC16 AND
            DataTable del = SqlHelper.ExecuteDataTable( "SELECT AC18,AC10+ISNULL(AC27,0)-ISNULL(SUM(AD12+ISNULL(AD21,0)),0) AC10 FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05 GROUP BY AC10,AC18 HAVING AC10+ISNULL(AC27,0)-ISNULL(SUM(AD12+ISNULL(AD21,0)),0)>0" ,new SqlParameter( "@AC02" ,PJ95 ) ,new SqlParameter( "@AC04" ,PJ009 ) ,new SqlParameter( "@AC05" ,PJ089 ) );
            if ( del.Rows.Count < 1 )
                str = "0";
            else if ( string.IsNullOrEmpty( del.Rows[0]["AC10"].ToString( ) ) )
                str = "0";
            else
                str = del.Rows[0]["AC10"].ToString( );

            textBox35.Text = Math.Round( Convert.ToDecimal( Operation.MultiThrTbCbAdd( textBox21 ,textBox37 ,comboBox13 ,str ) ) ,4 ).ToString( );
        }
        //使用外购数量
        private void textBox35_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox35 );
        }
        private void textBox35_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox35 );
        }
        private void textBox35_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox35.Text != "" && !DateDayRegise.twelveFourNumber( textBox35 ) )
            {
                this.textBox35.Text = "";
                MessageBox.Show( "只允许输入整数部分最多六位,小数部分最多四位,如99999999.9999,请重新输入" );
            }
        }
        //产品数量
        private void textBox21_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //产品名称
        private void comboBox4_SelectedValueChanged ( object sender ,EventArgs e )
        {
            if ( ord == "计划" || string.IsNullOrEmpty( textBox17.Text ) )
            {
                if ( !string.IsNullOrEmpty( comboBox4.Text ) )
                    comboBox5.Text = comboBox4.SelectedValue.ToString( );
            }
        }
        #endregion

        #region 查询
        void queryContent ( )
        {
            DataTable dei = SqlHelper.ExecuteDataTable( "SELECT TOP 1 *,(SELECT DBA002 FROM TPADBA WHERE PJ02=DBA001) DBA002 FROM R_PQS WHERE PJ92=@PJ92" ,new SqlParameter( "@PJ92" ,model.PJ92 ) );
            if ( dei.Rows.Count > 0 )
            {
                lookUpEdit1.Text = dei.Rows[0]["DBA002"].ToString( );
                #region
                textBox1 . Text = PJ03 = dei . Rows [ 0 ] [ "PJ03" ] . ToString ( );
                comboBox4.Text = dei.Rows[0]["PJ93"].ToString( );
                textBox17 . Text = dei . Rows [ 0 ] [ "PJ01" ] . ToString ( );
                comboBox5 .Text = dei.Rows[0]["PJ95"].ToString( );
                textBox13.Text = dei.Rows[0]["PJ94"].ToString( );
                textBox21.Text = dei.Rows[0]["PJ96"].ToString( );
                textBox9.Text = dei.Rows[0]["PJ04"].ToString( );
                lookUpEdit2.Text = dei.Rows[0]["PJ101"].ToString( );
                if ( dei . Rows [ 0 ] [ "PJ05" ] . ToString ( ) != "" )
                    dateTimePicker1 . Value = Convert . ToDateTime ( dei . Rows [ 0 ] [ "PJ05" ] );
                else
                    dateTimePicker1 . Value = DateTime . Now;
                textBox11.Text = dei.Rows[0]["PJ06"].ToString( );
                if ( dei.Rows[0]["PJ07"].ToString( ) != "" )
                    dateTimePicker2.Value = Convert.ToDateTime( dei.Rows[0]["PJ07"] );
                else
                    dateTimePicker2 . Value = DateTime . Now;
                textBox14 .Text = dei.Rows[0]["PJ08"].ToString( );
                textBox31.Text = dei.Rows[0]["PJ21"].ToString( );
                comboBox19.Text = dei.Rows[0]["PJ22"].ToString( );
                if ( dei.Rows[0]["PJ23"].ToString( ) != "" )
                    dateTimePicker6.Value = Convert.ToDateTime( dei.Rows[0]["PJ23"] );
                else
                    dateTimePicker6 . Value = DateTime . Now;
                textBox36 .Text = dei.Rows[0]["PJ24"].ToString( );
                comboBox18.Text = dei.Rows[0]["PJ25"].ToString( );
                if ( dei.Rows[0]["PJ26"].ToString( ) != "" )
                    dateTimePicker7.Value = Convert.ToDateTime( dei.Rows[0]["PJ26"] );
                else
                    dateTimePicker7 . Value = DateTime . Now;
                textBox39 .Text = dei.Rows[0]["PJ27"].ToString( );
                comboBox16.Text = dei.Rows[0]["PJ28"].ToString( );
                if ( dei.Rows[0]["PJ29"].ToString( ) != "" )
                    dateTimePicker8.Value = Convert.ToDateTime( dei.Rows[0]["PJ29"] );
                else
                    dateTimePicker8 . Value = DateTime . Now;
                textBox42 .Text = dei.Rows[0]["PJ30"].ToString( );
                comboBox14.Text = dei.Rows[0]["PJ31"].ToString( );
                if ( dei.Rows[0]["PJ32"].ToString( ) != "" )
                    dateTimePicker9.Value = Convert.ToDateTime( dei.Rows[0]["PJ32"] );
                else
                    dateTimePicker9 . Value = DateTime . Now;
                textBox30 .Text = dei.Rows[0]["PJ33"].ToString( );
                textBox33.Text = dei.Rows[0]["PJ34"].ToString( );
                if ( dei.Rows[0]["PJ35"].ToString( ).Trim( ) == "T" )
                {
                    checkBox21.Checked = true;
                }
                else
                {
                    checkBox21.Checked = false;
                }
                if ( dei.Rows[0]["PJ36"].ToString( ).Trim( ) == "T" )
                {
                    checkBox22.Checked = true;
                }
                else
                {
                    checkBox22.Checked = false;
                }
                if ( dei.Rows[0]["PJ37"].ToString( ).Trim( ) == "T" )
                {
                    checkBox23.Checked = true;
                }
                else
                {
                    checkBox23.Checked = false;
                }
                if ( dei.Rows[0]["PJ38"].ToString( ).Trim( ) == "T" )
                {
                    checkBox24.Checked = true;
                }
                else
                {
                    checkBox24.Checked = false;
                }
                if ( dei.Rows[0]["PJ39"].ToString( ).Trim( ) == "T" )
                {
                    checkBox5.Checked = true;
                }
                else
                {
                    checkBox5.Checked = false;
                }
                if ( dei.Rows[0]["PJ40"].ToString( ).Trim( ) == "T" )
                {
                    checkBox6.Checked = true;
                }
                else
                {
                    checkBox6.Checked = false;
                }
                if ( dei.Rows[0]["PJ41"].ToString( ).Trim( ) == "T" )
                {
                    checkBox7.Checked = true;
                }
                else
                {
                    checkBox7.Checked = false;
                }
                if ( dei.Rows[0]["PJ42"].ToString( ).Trim( ) == "T" )
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
                if ( dei.Rows[0]["PJ43"].ToString( ).Trim( ) == "T" )
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Checked = false;
                }
                if ( dei.Rows[0]["PJ44"].ToString( ).Trim( ) == "T" )
                {
                    checkBox4.Checked = true;
                }
                else
                {
                    checkBox4.Checked = false;
                }
                if ( dei.Rows[0]["PJ45"].ToString( ).Trim( ) == "T" )
                {
                    checkBox3.Checked = true;
                }
                else
                {
                    checkBox3.Checked = false;
                }
                if ( dei.Rows[0]["PJ46"].ToString( ).Trim( ) == "T" )
                {
                    checkBox8.Checked = true;
                }
                else
                {
                    checkBox8.Checked = false;
                }
                if ( dei.Rows[0]["PJ47"].ToString( ).Trim( ) == "T" )
                {
                    checkBox9.Checked = true;
                }
                else
                {
                    checkBox9.Checked = false;
                }
                if ( dei.Rows[0]["PJ48"].ToString( ).Trim( ) == "T" )
                {
                    checkBox11.Checked = true;
                }
                else
                {
                    checkBox11.Checked = false;
                }
                if ( dei.Rows[0]["PJ49"].ToString( ).Trim( ) == "T" )
                {
                    checkBox10.Checked = true;
                }
                else
                {
                    checkBox10.Checked = false;
                }
                if ( dei.Rows[0]["PJ50"].ToString( ).Trim( ) == "T" )
                {
                    checkBox12.Checked = true;
                }
                else
                {
                    checkBox12.Checked = false;
                }
                if ( dei.Rows[0]["PJ51"].ToString( ).Trim( ) == "在内" )
                {
                    radioButton1.Checked = true;
                }
                else if ( dei.Rows[0]["PJ51"].ToString( ).Trim( ) == "不在内" )
                {
                    radioButton2.Checked = true;
                }
                if ( dei.Rows[0]["PJ52"].ToString( ).Trim( ) == "有" )
                {
                    radioButton3.Checked = true;
                }
                else if ( dei.Rows[0]["PJ52"].ToString( ).Trim( ) == "没有" )
                {
                    radioButton4.Checked = true;
                }
                if ( dei.Rows[0]["PJ53"].ToString( ).Trim( ) == "已检测" )
                {
                    radioButton6.Checked = true;
                    textBox43.Text = dei.Rows[0]["PJ54"].ToString( );
                }
                else if ( dei.Rows[0]["PJ53"].ToString( ).Trim( ) == "未检测" )
                {
                    radioButton5.Checked = true;
                }
                textBox45.Text = dei.Rows[0]["PJ55"].ToString( );
                textBox44.Text = dei.Rows[0]["PJ56"].ToString( );
                if ( dei.Rows[0]["PJ57"].ToString( ).Trim( ) == "T" )
                {
                    checkBox13.Checked = true;
                }
                else
                {
                    checkBox13.Checked = false;
                }
                if ( dei.Rows[0]["PJ58"].ToString( ).Trim( ) == "T" )
                {
                    checkBox14.Checked = true;
                }
                else
                {
                    checkBox14.Checked = false;
                }
                if ( dei.Rows[0]["PJ59"].ToString( ).Trim( ) == "T" )
                {
                    checkBox15.Checked = true;
                }
                else
                {
                    checkBox15.Checked = false;
                }
                if ( dei.Rows[0]["PJ60"].ToString( ).Trim( ) == "T" )
                {
                    checkBox16.Checked = true;
                }
                else
                {
                    checkBox16.Checked = false;
                }
                if ( dei.Rows[0]["PJ61"].ToString( ).Trim( ) == "T" )
                {
                    checkBox18.Checked = true;
                }
                else
                {
                    checkBox18.Checked = false;
                }
                if ( dei.Rows[0]["PJ62"].ToString( ).Trim( ) == "T" )
                {
                    checkBox19.Checked = true;
                }
                else
                {
                    checkBox19.Checked = false;
                }
                if ( dei.Rows[0]["PJ63"].ToString( ).Trim( ) == "T" )
                {
                    checkBox20.Checked = true;
                }
                else
                {
                    checkBox20.Checked = false;
                }
                textBox55.Text = dei.Rows[0]["PJ64"].ToString( );
                if ( dei.Rows[0]["PJ65"].ToString( ).Trim( ) == "合格" )
                {
                    radioButton7.Checked = true;
                }
                else if ( dei.Rows[0]["PJ65"].ToString( ).Trim( ) == "条件接收" )
                {
                    radioButton8.Checked = true;
                    textBox25.Text = dei.Rows[0]["PJ66"].ToString( );
                }
                else if ( dei.Rows[0]["PJ65"].ToString( ).Trim( ) == "退货" )
                {
                    radioButton9.Checked = true;
                }
                comboBox12.Text = dei.Rows[0]["PJ67"].ToString( );
                comboBox11.Text = dei.Rows[0]["PJ68"].ToString( );
                comboBox10.Text = dei.Rows[0]["PJ78"].ToString( );
                if ( dei.Rows[0]["PJ79"].ToString( ) != "" )
                    dateTimePicker10.Value = Convert.ToDateTime( dei.Rows[0]["PJ79"] );
                else
                    dateTimePicker10 . Value = DateTime . Now;
                textBox57 .Text = dei.Rows[0]["PJ69"].ToString( );
                textBox58.Text = dei.Rows[0]["PJ70"].ToString( );
                textBox59.Text = dei.Rows[0]["PJ71"].ToString( );
                textBox18.Text = dei.Rows[0]["PJ72"].ToString( );
                textBox12.Text = dei.Rows[0]["PJ73"].ToString( );
                textBox10.Text = dei.Rows[0]["PJ74"].ToString( );
                textBox24.Text = dei.Rows[0]["PJ75"].ToString( );
                textBox23.Text = dei.Rows[0]["PJ76"].ToString( );
                textBox22.Text = dei.Rows[0]["PJ77"].ToString( );
                textBox68.Text = dei.Rows[0]["PJ80"].ToString( );
                textBox69.Text = dei.Rows[0]["PJ81"].ToString( );
                if ( dei.Rows[0]["PJ82"].ToString( ) != "" )
                    dateTimePicker11.Value = Convert.ToDateTime( dei.Rows[0]["PJ82"] );
                else
                    dateTimePicker11 . Value = DateTime . Now;
                textBox71 .Text = dei.Rows[0]["PJ83"].ToString( );
                if ( dei.Rows[0]["PJ84"].ToString( ) != "" )
                    dateTimePicker12.Value = Convert.ToDateTime( dei.Rows[0]["PJ84"] );
                else
                    dateTimePicker12 . Value = DateTime . Now;
                textBox27 .Text = dei.Rows[0]["PJ85"].ToString( );
                if ( dei.Rows[0]["PJ86"].ToString( ) != "" )
                    dateTimePicker15.Value = Convert.ToDateTime( dei.Rows[0]["PJ86"] );
                else
                    dateTimePicker15 . Value = DateTime . Now;
                if ( dei.Rows[0]["PJ87"].ToString( ) != "" )
                    dateTimePicker13.Value = Convert.ToDateTime( dei.Rows[0]["PJ87"] );
                else
                    dateTimePicker13 . Value = DateTime . Now;
                if ( dei.Rows[0]["PJ88"].ToString( ) != "" )
                    dateTimePicker3.Value = Convert.ToDateTime( dei.Rows[0]["PJ88"] );
                else
                    dateTimePicker3 . Value = DateTime . Now;

                textBox29 .Text = dei.Rows[0]["PJ90"].ToString( );
                if ( dei.Rows[0]["PJ99"].ToString( ).Trim( ) == "复制" )
                    label98.Visible = true;
                else
                    label98.Visible = false;
                checkBox17.Checked = dei.Rows[0]["PJ100"].ToString( ).Trim( ) == "T" ? true : false;
                checkBox25.Checked = dei.Rows[0]["PJ106"].ToString( ).Trim( ) == "T" ? true : false;
                #endregion
                //,PJ100
                de = SqlHelper.ExecuteDataTable( "SELECT idx,PJ09,PJ10,PJ89,PJ11,PJ12,PJ13,PJ14,PJ15,PJ16,PJ17,PJ18,PJ19,PJ20,PJ96,PJ97,PJ102,PJ103,PJ105 FROM R_PQS WHERE PJ92=@PJ92 AND PJ09!='' AND PJ09 IS NOT NULL ORDER BY idx DESC" ,new SqlParameter( "@PJ92" ,model.PJ92 ) );
                gridControl1.DataSource = de;
            }
        }
        void autoQuery ( )
        {
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableFalse( pageList );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
            textBox29.Enabled = false;

            adds = "2";
            ord = "";
            queryContent( );
        }
        string PJ009 = "";
        R_FrmTPADGA tpadga = new R_FrmTPADGA( );
        //供应商查询 供应商信息
        private void button4_Click ( object sender ,EventArgs e )
        {
            DataTable did = SqlHelper.ExecuteDataTable( "SELECT DGA001,DGA003,DGA011,DGA017,DGA009 FROM TPADGA WHERE DGA052='F'" );
            if ( did.Rows.Count < 1 )
                MessageBox.Show( "没有供应商信息" );
            else
            {
                tpadga.gridControl2.DataSource = did;
                tpadga.st = "3";
                tpadga.Text = "R_347 信息查询";
                tpadga.PassDataBetweenForm += new R_FrmTPADGA.PassDataBetweenFomrHandler( tpadga_PassDataBetweenForm );
                tpadga.StartPosition = FormStartPosition.CenterScreen;
                tpadga.ShowDialog( );
            }
        }
        private void tpadga_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            PJ03 = e.ConOne;
            textBox1.Text = e.ConTwo;
            textBox5.Text = e.ConFiv;
            textBox6.Text = e.ConTre;
            textBox4.Text = e.ConFor;
        }
        //查询
        //R_Frm347 frm = new R_Frm347( );
        SelectAll.SuLiaoBucontractQueryAll query = new SelectAll.SuLiaoBucontractQueryAll( );
        protected override void select ( )
        {
            base.select( );

            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.SuLiaoBucontractQueryAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );

            if ( model.PJ92 == "" )
                MessageBox.Show( "您没有选择任何信息" );
            else
                autoQuery( );
        }
        private void query_PassDataBetweenForm ( Object sender ,PassDataWinFormEventArgs e )
        {
            PJ01 = e.ConTre;
            //textBox17.Text = e.ConTre;
            PJ93 = e.ConOne;
            //comboBox4.Text = e.ConOne;
            PJ94 = e.ConTwo;
            //textBox13.Text = e.ConTwo;
            //PJ02 = e.ConFor;
            //lookUpEdit1.Text = e.ConFiv;
            PJ03 = e.ConSix;
            //textBox1.Text = e.ConSev;
            if ( e.ConEgi == "执行" )
                label78.Visible = true;
            else
                label78.Visible = false;
            model.PJ92 = e.ConNin;
            PJ95 = e.ConTen;
            //comboBox5.Text = e.ConTen;
            if ( e.ConEleven == "" )
                PJ096 = 0;
            else
                PJ096 = Convert.ToInt64( e.ConEleven );
            //textBox21.Text = e.ConEleven;
        }
        //流水号查询 销售合同
        Youqicaigou yq = new Youqicaigou( );
        private void button5_Click ( object sender ,EventArgs e )
        {
            DataTable dhr = SqlHelper.ExecuteDataTable( "SELECT PQF01,PQF02,PQF03,PQF04,PQF06,PQF07,PQF08 FROM R_PQF A,R_REVIEWS B,R_MLLCXMC C WHERE A.PQF01 = B.RES06 AND B.RES01 = C.CX01 AND C.CX02 = '订单销售合同(R_001)' AND RES05 = '执行' ORDER BY PQF01 DESC" );
            if ( dhr.Rows.Count < 1 )
                MessageBox.Show( "没有产品信息" );
            else
            {
                dhr.Columns.Add( "check" ,System.Type.GetType( "System.Boolean" ) );
                yq.gridControl1.DataSource = dhr;
                yq.sy = "1";
                yq.Text = "R_347 信息查询";
                yq.PassDataBetweenForm += new Youqicaigou.PassDataBetweenFormHandler( yq_PassDataBetweenForm );
                yq.StartPosition = FormStartPosition.CenterScreen;
                yq.ShowDialog( );
            }
        }
        private void yq_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            PJ01 = e.ConOne;
            textBox17.Text = e.ConOne;
            if ( e.ConTwo.IndexOf( "," ) > 0 )
                textBox13.Text = string.Join( "," ,e.ConTwo.Split( ',' ).Distinct( ).ToArray( ) );
            else
                textBox13.Text = e.ConTwo;
            PJ94 = textBox13.Text;
            if ( e.ConTre.IndexOf( "," ) > 0 )
                comboBox5.Text = string.Join( "," ,e.ConTre.Split( ',' ).Distinct( ).ToArray( ) );
            else
                comboBox5.Text = e.ConTre;
            PJ95 = e.ConTre;
            if ( e.ConFor.IndexOf( "," ) > 0 )
                comboBox4.Text = string.Join( "," ,e.ConFor.Split( ',' ).Distinct( ).ToArray( ) );
            else
                comboBox4.Text = e.ConFor;
            PJ93 = comboBox4.Text;
            textBox21.Text = e.ConFiv;
            if ( e.ConFiv == "" )
                PJ096 = 0;
            else
                PJ096 = Convert.ToInt64( e.ConFiv );
            if ( e.ConSix.IndexOf( "," ) > 0 )
                textBox30.Text = string.Join( "," ,e.ConSix.Split( ',' ).Distinct( ).ToArray( ) );
            else
                textBox30.Text = e.ConSix;
            PJ33 = textBox30.Text;
            if ( e.ConSev.IndexOf( "," ) > 0 )
                textBox33.Text = string.Join( "," ,e.ConSev.Split( ',' ).Distinct( ).ToArray( ) );
            else
                textBox33.Text = e.ConSev;
            PJ34 = textBox33.Text;
        }
        //计划查询
        planeQuery pq = new planeQuery( );
        private void button15_Click ( object sender ,EventArgs e )
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
            textBox17.Text = "";
            PJ93 = e.ConOne;
            comboBox4.Text = e.ConOne;
            PJ95 = e.ConTwo;
            comboBox5.Text = e.ConTwo;
            if ( !string.IsNullOrEmpty( e.ConTre ) )
                PJ096 = Convert.ToInt64( e.ConTre );
            else
                PJ096 = 0;
            textBox21.Text = e.ConTre;
            textBox13.Text = "";
        }
        //物品信息查询  509 零件名称  规格
        R_FrmPQP pqp = new R_FrmPQP( );
        private void button6_Click ( object sender ,EventArgs e )
        {
            if ( PJ01 == "" )
                MessageBox.Show( "流水号不可为空" );
            else
            {
                DataTable dee = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS07,GS08,GS10,GS09 FROM R_PQP A,R_REVIEWS B,R_MLLCXMC C WHERE A.GS34=B.RES06 AND B.RES01=C.CX01 AND RES05='执行' AND CX02='产品每套成本改善控制表(R_509)' AND GS07 IS NOT NULL AND GS07!='' AND GS01=@GS01" ,new SqlParameter( "@GS01" ,PJ01 ) );
                if ( dee.Rows.Count < 1 )
                    MessageBox.Show( "[产品每套成本改善控制表(R_509)]没有已经执行的信息,请录入或送审操作" );
                else
                {
                    dee.Columns.Add( "check" ,System.Type.GetType( "System.Boolean" ) );
                    pqp.gridControl1.DataSource = dee;
                    pqp.pqstr = "4";
                    pqp.Text = "R_347 信息查询";
                    pqp.PassDataBetweenForm += new R_FrmPQP.PassDataBetweenFormHandler( pqp_PassDataBetweenForm );
                    pqp.StartPosition = FormStartPosition.CenterScreen;
                    pqp.ShowDialog( );
                }
            }
        }
        private void pqp_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            PJ009 = e.ConOne;
            gridLookUpEdit1.Text = e.ConOne;
            PJ089 = e.ConTwo;
            textBox26.Text = e.ConTwo;
            textBox37.Text = e.ConTre;
            PJ017 = e.ConFor;
            comboBox8.Text = e.ConFor;
        }
        #endregion

        #region  主体
        string adds = "", weihu = "";
        string PJ01 = "", PJ02 = "", PJ03 = "", PJ04 = "", PJ06 = "", PJ08 = "", PJ21 = "", PJ22 = "", PJ24 = "", PJ25 = "", PJ27 = "", PJ28 = "", PJ30 = "", PJ31 = "", PJ33 = "", PJ34 = "", PJ35 = "", PJ36 = "", PJ37 = "", PJ38 = "", PJ39 = "", PJ40 = "", PJ41 = "", PJ42 = "", PJ43 = "", PJ44 = "", PJ45 = "", PJ46 = "", PJ47 = "", PJ48 = "", PJ49 = "", PJ50 = "", PJ51 = "", PJ52 = "", PJ53 = "", PJ54 = "", PJ55 = "", PJ56 = "", PJ57 = "", PJ58 = "", PJ59 = "", PJ60 = "", PJ61 = "", PJ62 = "", PJ63 = "", PJ65 = "", PJ66 = "", PJ67 = "", PJ68 = "", PJ78 = "", PJ80 = "", PJ81 = "", PJ83 = "", PJ85 = "", PJ90 = "", PJ91 = "", PJ93 = "", PJ94 = "", PJ95 = "", PJ100="",PJ101 = "", PJ0105 = "", PJ106 = "";


        long PJ64 = 0, PJ69 = 0, PJ70 = 0, PJ71 = 0, PJ72 = 0, PJ73 = 0, PJ74 = 0, PJ75 = 0, PJ76 = 0, PJ77 = 0, PJ096 = 0;
        DateTime PJ05 = MulaolaoBll . Drity . GetDt ( ), PJ07 = MulaolaoBll . Drity . GetDt ( ), PJ23 = MulaolaoBll . Drity . GetDt ( ), PJ26 = MulaolaoBll . Drity . GetDt ( ), PJ29 = MulaolaoBll . Drity . GetDt ( ), PJ32 = MulaolaoBll . Drity . GetDt ( ), PJ79 = MulaolaoBll . Drity . GetDt ( ), PJ82 = MulaolaoBll . Drity . GetDt ( ), PJ84 = MulaolaoBll . Drity . GetDt ( ), PJ86 = MulaolaoBll . Drity . GetDt ( ), PJ87 = MulaolaoBll . Drity . GetDt ( ), PJ88 = MulaolaoBll . Drity . GetDt ( );
        //新增
        Order od = new Order( );
        string ord = "";
        void orde ( )
        {
            PJ03 = "";
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableTrue( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableTrue( pageList );
            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;
           

            textBox29.Enabled = false;
            label98.Visible = false;

            adds = "1";

            model.PJ92 = oddNumbers.purchaseContract( "SELECT MAX(AJ007) AJ007 FROM R_PQAJ" ,"AJ007" ,"R_347-" );
            dateTimePicker2.Enabled = dateTimePicker5.Enabled = dateTimePicker1.Enabled = false;
            label78.Visible = false;
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
                comboBox4.Enabled = comboBox5.Enabled = true;
                textBox21.Enabled = true;
                button15.Enabled = true;
                button5.Enabled = false;
                //fc.productNumberRthr( comboBox4 );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
            }
            else if ( ord == "实际" )
            {
                orde( );

                comboBox4.Enabled = comboBox5.Enabled = false;
                textBox21.Enabled = false;
                button15.Enabled = false;
                button5.Enabled = true;
                //comboBox4.DataSource = null;
                //comboBox4.Items.Clear( );    
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
            }
            else
            {
                MessageBox.Show( "请选择计划订单或实际订单" );
                adds = "1";
                model.PJ92 = "";
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
            }
        }
        private void od_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            ord = e.ConOne;
        }
        //删除
        protected override void delete ( )
        {
            base.delete( );

            if ( label78.Visible==true )
            {
                if ( Logins.number == "MLL-0001" )
                    deles( );
                else
                    MessageBox.Show( "单号:" + model.PJ92 + "的单据状态为执行,不允许删除" );
            }
            else
                deles( );
        }
        void deles ( )
        {
            if ( label78.Visible == true )
                stateOfOdd = "维护删除";
            else
            {
                if ( adds == "1" )
                    stateOfOdd = "新增删除";
                else
                    stateOfOdd = "更改删除";
            }

            result = bll.DeleteAll( "R_347" ,"产品塑料、布和其他零配件采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,model.PJ92 ,"删除" ,stateOfOdd );
            if ( result==false )
                MessageBox.Show( "删除数据失败" );
            else
            {
                MessageBox.Show( "成功删除数据" );

                PJ03 = "";
                Ergodic.SpliClear( spList );
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.TablePageEnableFalse( pageList );
                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;

                toolSelect.Enabled = toolAdd.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolExport.Enabled = false;
                textBox29.Enabled = false;
                label98.Visible = label78.Visible = false;
            }
        }
        //更改
        protected override void update ( )
        {
            base.update( );

            if ( label78.Visible == true )
                MessageBox.Show( "单号:" + model.PJ92 + "的单据状态为执行,不允许更改" );
            else
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
                textBox29.Enabled = false;

                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );

                dateTimePicker2.Enabled = dateTimePicker5.Enabled = dateTimePicker1.Enabled = false;
                label78.Visible = false;
                if ( string.IsNullOrEmpty( textBox17.Text ) )
                {
                    comboBox4.Enabled = comboBox5.Enabled = true;
                    textBox21.Enabled = true;
                    button15.Enabled = true;
                    button5.Enabled = false;
                }
                else
                {
                    comboBox4.Enabled = comboBox5.Enabled = false;
                    textBox21.Enabled = false;
                    button15.Enabled = false;
                    button5.Enabled = true;
                }
            }
        }
        //送审
        protected override void revirw ( )
        {
            base.revirw( );

            bool result = false, over = false;
            if ( textBox27.Text == "廖灵飞" )
                result = true;
            else
                result = false;
            if ( string.IsNullOrEmpty( textBox11.Text ) )
                over = false;
            else
                over = true;
            Reviews( "PJ92" ,model.PJ92 ,"R_PQS" ,this ,PJ01 ,"R_347" ,result ,over,null/*,"PJ06" ,"PJ85" ,"R_PQS" ,"PJ92" ,PJ92 ,ord ,textBox17.Text,"R_347"*/ );
            result = false;
            result = sp.reviewImple( "R_347" ,model . PJ92 );
            if ( result == true )
            {
                label78.Visible = true;
                try
                {
                    SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfCopy( "R_PQSC" ,"R_PQS" ,"PJ92" ,model . PJ92 ) );
                    WriteOfReceivablesTo( );
                }
                catch { }
            }
            else
                label78.Visible = false;
        }
        void WriteOfReceivablesTo ( )
        {
            DataTable receiva;
            MulaolaoLibrary.ProductCostSummaryLibrary modelAm = new MulaolaoLibrary.ProductCostSummaryLibrary( );
            receiva = bll.GetDataTabelOfReceivable( model . PJ92 );
            if ( receiva != null && receiva.Rows.Count > 0 )
            {
                modelAm.AM002 = receiva.Rows[0]["PJ01"].ToString( );
                modelAm.AM212 = modelAm.AM217 = modelAm.AM215 = modelAm.AM221 = modelAm.AM218 = modelAm.AM223 = modelAm . AM229 = modelAm . AM231 = modelAm . AM233 = modelAm . AM235 = modelAm . AM237 = modelAm . AM255 = 0;
                modelAm.AM218 = string.IsNullOrEmpty( receiva.Compute( "SUM(PQ)" ,"PJ01='" + modelAm.AM002 + "' and PJ105='包装辅料' AND PJ100='F' AND PJ15='外购'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(PQ)" ,"PJ01='" + modelAm.AM002 + "' and PJ105='包装辅料' AND PJ100='F' AND PJ15='外购'" ) );
                modelAm.AM223 = string.IsNullOrEmpty( receiva.Compute( "SUM(PQ)" ,"PJ01='" + modelAm.AM002 + "' and PJ105='包装辅料' AND PJ100='T' AND PJ15='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(PQ)" ,"PJ01='" + modelAm.AM002 + "' and PJ105='包装辅料' AND PJ100='T' AND PJ15='外购'" ) );
                modelAm . AM237 = string . IsNullOrEmpty ( receiva . Compute ( "SUM(PQ)" , "PJ01='" + modelAm . AM002 + "' and PJ105='包装辅料' AND PJ100='T' AND PJ15='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "SUM(PQ)" , "PJ01='" + modelAm . AM002 + "' and PJ105='包装辅料' AND PJ100='T' AND PJ15='库存'" ) );
                modelAm . AM255 = string . IsNullOrEmpty ( receiva . Compute ( "SUM(PQ)" , "PJ01='" + modelAm . AM002 + "' and PJ105='包装辅料' AND PJ100='T' AND PJ15='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "SUM(PQ)" , "PJ01='" + modelAm . AM002 + "' and PJ105='包装辅料' AND PJ100='T' AND PJ15='库存'" ) );

                modelAm .AM215 = string.IsNullOrEmpty( receiva.Compute( "SUM(PQ)" ,"PJ01='" + modelAm.AM002 + "' and PJ105='其它材料' AND PJ100='F' AND PJ15='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(PQ)" ,"PJ01='" + modelAm.AM002 + "' and PJ105='其它材料' AND PJ100='F' AND PJ15='外购'" ) );
                modelAm.AM221 = string.IsNullOrEmpty( receiva.Compute( "SUM(PQ)" ,"PJ01='" + modelAm.AM002 + "' and PJ105='其它材料' AND PJ100='T' AND PJ15='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(PQ)" ,"PJ01='" + modelAm.AM002 + "' and PJ105='其它材料' AND PJ100='T' AND PJ15='外购'" ) );
                modelAm . AM233 = string . IsNullOrEmpty ( receiva . Compute ( "SUM(PQ)" , "PJ01='" + modelAm . AM002 + "' and PJ105='其它材料' AND PJ100='T' AND PJ15='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "SUM(PQ)" , "PJ01='" + modelAm . AM002 + "' and PJ105='其它材料' AND PJ100='T' AND PJ15='库存'" ) );
                modelAm . AM235 = string . IsNullOrEmpty ( receiva . Compute ( "SUM(PQ)" , "PJ01='" + modelAm . AM002 + "' and PJ105='其它材料' AND PJ100='T' AND PJ15='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "SUM(PQ)" , "PJ01='" + modelAm . AM002 + "' and PJ105='其它材料' AND PJ100='T' AND PJ15='库存'" ) );

                modelAm .AM212 = string.IsNullOrEmpty( receiva.Compute( "SUM(PQ)" ,"PJ01='" + modelAm.AM002 + "' and PJ105='塑料件' AND PJ100='F' AND PJ15='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(PQ)" ,"PJ01='" + modelAm.AM002 + "' and PJ105='塑料件' AND PJ100='F' AND PJ15='外购'" ) );
                modelAm.AM217 = string.IsNullOrEmpty( receiva.Compute( "SUM(PQ)" ,"PJ01='" + modelAm.AM002 + "' and PJ105='塑料件' AND PJ100='T' AND PJ15='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "sum(PQ)" ,"PJ01='" + modelAm.AM002 + "' and PJ105='塑料件' AND PJ100='T' AND PJ15='外购'" ) );
                modelAm . AM229 = string . IsNullOrEmpty ( receiva . Compute ( "SUM(PQ)" , "PJ01='" + modelAm . AM002 + "' and PJ105='塑料件' AND PJ100='T' AND PJ15='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(PQ)" , "PJ01='" + modelAm . AM002 + "' and PJ105='塑料件' AND PJ100='T' AND PJ15='库存'" ) );
                modelAm . AM231 = string . IsNullOrEmpty ( receiva . Compute ( "SUM(PQ)" , "PJ01='" + modelAm . AM002 + "' and PJ105='塑料件' AND PJ100='T' AND PJ15='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "sum(PQ)" , "PJ01='" + modelAm . AM002 + "' and PJ105='塑料件' AND PJ100='T' AND PJ15='库存'" ) );
                bll .UpdateOfReveciable( modelAm ,model . PJ92 );
            }
        }
        //打印
        bool result = false;
        void trueOrFalse ( )
        {
            PJ95 = comboBox5.Text;
            if ( ( string.IsNullOrEmpty( textBox17.Text ) && gridView1.GetDataRow( 0 )["PJ15"].ToString( ) == "外购" ) || ( !string.IsNullOrEmpty( textBox17.Text ) && gridView1.GetDataRow( 0 )["PJ15"].ToString( ) == "库存" ) )
            {
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    if ( sp.inOut( model . PJ92 ,gridView1.GetDataRow( i )["PJ09"].ToString( ) ,PJ95 ,gridView1.GetDataRow( i )["PJ89"].ToString( ) ) == false )
                    {
                        //所有都不等就是没有出或入
                        result = false;
                        break;
                    }
                    else if ( i == gridView1.RowCount - 1 )
                        result = true;
                }
            }
        }
        protected override void print ( )
        {
            base.print( );
            //sp.panDuan( "PJ06" ,"PJ85" ,"R_PQS" ,"PJ92" ,PJ92 ,ord ,textBox17.Text ,"R_347");

            if ( ( ord == "实际" || !string.IsNullOrEmpty( textBox17.Text ) ) && gridView1.GetDataRow( 0 )["PJ15"].ToString( ) == "外购" )
            {
                if ( label78.Visible == true )
                {
                    MulaolaoBll . ContractAddPrintTime . addTimeToContract ( "R_PQS" ,"PJ107" ,model . PJ92 ,"PJ92" );

                    CreateDataSet( );
                    file = "";
                    file = System.Windows.Forms.Application.StartupPath;
                    report.Load( file + "\\R_347.frx" );
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
                    MulaolaoBll . ContractAddPrintTime . addTimeToContract ( "R_PQS" ,"PJ107" ,model . PJ92 ,"PJ92" );

                    CreateDataSet ( );
                    file = "";
                    file = System.Windows.Forms.Application.StartupPath;
                    report.Load( file + "\\R_347.frx" );
                    report.RegisterData( RDataSet );
                    report.Show( );
                }
                else
                    MessageBox.Show( "没有出入库的单据不能打印" );
            }
        }
        //导出
        protected override void export ( )
        {
            base.export( );
            //sp.panDuan( "PJ06" ,"PJ85" ,"R_PQS" ,"PJ92" ,PJ92 ,ord ,textBox17.Text,"R_347" );

            //if ( ( ord == "实际" || !string.IsNullOrEmpty( textBox17.Text ) ) && radioButton11.Checked )
            //{
            //    if ( label78.Visible == true )
            //    {
            CreateDataSet( );
            file = "";
            file = System.Windows.Forms.Application.StartupPath;
            report.Load( file + "\\R_347.frx" );
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
            //        CreateDataSet( );
            //        report.Load( Environment.CurrentDirectory + "\\R_347.frx" );
            //        report.RegisterData( RDataSet );
            //        report.Prepare( );
            //        XMLExport exprots = new XMLExport( );
            //        exprots.Export( report );
            //    }
            //    else
            //        MessageBox.Show( "没有出入库的单据不能导出" );
            //}

        }
        //保存
        void saves ( )
        {
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled = toolStorage.Enabled = toolLibrary.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
            textBox29.Enabled = false;
            copy = "";
            adds = "2";
            weihu = "";
            label98.Visible = false;
        }
        void updates ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "UPDATE R_PQS SET PJ01='{0}',PJ02='{1}',PJ03='{2}',PJ04='{3}',PJ06='{4}',PJ08='{5}',PJ21='{6}',PJ22='{7}',PJ24='{8}',PJ25='{9}',PJ27='{10}',PJ28='{11}',PJ30='{12}',PJ31='{13}',PJ33='{14}',PJ34='{15}',PJ35='{16}',PJ36='{17}',PJ37='{18}',PJ38='{19}',PJ39='{20}',PJ40='{21}',PJ41='{22}',PJ42='{23}',PJ43='{24}',PJ44='{25}',PJ45='{26}',PJ46='{27}',PJ47='{28}',PJ48='{29}',PJ49='{30}',PJ50='{31}',PJ51='{32}',PJ52='{33}',PJ53='{34}',PJ54='{35}',PJ55='{36}',PJ56='{37}',PJ57='{38}',PJ58='{39}',PJ59='{40}',PJ60='{41}',PJ61='{42}',PJ62='{43}',PJ63='{44}',PJ65='{45}',PJ66='{46}',PJ67='{47}',PJ68='{48}',PJ78='{49}',PJ80='{50}',PJ81='{51}',PJ83='{52}',PJ85='{53}',PJ64='{54}',PJ69='{55}',PJ70='{56}',PJ71='{57}',PJ72='{58}',PJ73='{59}',PJ74='{60}',PJ75='{61}',PJ76='{62}',PJ77='{63}',PJ05='{64}',PJ07='{65}',PJ23='{66}',PJ26='{67}',PJ29='{68}',PJ32='{69}',PJ79='{70}',PJ82='{71}',PJ84='{72}',PJ86='{73}',PJ87='{74}',PJ88='{75}',PJ90='{76}',PJ91='{77}',PJ93='{78}',PJ94='{79}',PJ95='{80}',PJ100='{81}',PJ101='{82}',PJ99='',PJ106='{84}' WHERE PJ92='{83}'" ,PJ01 ,PJ02 ,PJ03 ,PJ04 ,PJ06 ,PJ08 ,PJ21 ,PJ22 ,PJ24 ,PJ25 ,PJ27 ,PJ28 ,PJ30 ,PJ31 ,PJ33 ,PJ34 ,PJ35 ,PJ36 ,PJ37 ,PJ38 ,PJ39 ,PJ40 ,PJ41 ,PJ42 ,PJ43 ,PJ44 ,PJ45 ,PJ46 ,PJ47 ,PJ48 ,PJ49 ,PJ50 ,PJ51 ,PJ52 ,PJ53 ,PJ54 ,PJ55 ,PJ56 ,PJ57 ,PJ58 ,PJ59 ,PJ60 ,PJ61 ,PJ62 ,PJ63 ,PJ65 ,PJ66 ,PJ67 ,PJ68 ,PJ78 ,PJ80 ,PJ81 ,PJ83 ,PJ85 ,PJ64 ,PJ69 ,PJ70 ,PJ71 ,PJ72 ,PJ73 ,PJ74 ,PJ75 ,PJ76 ,PJ77 ,PJ05 ,PJ07 ,PJ23 ,PJ26 ,PJ29 ,PJ32 ,PJ79 ,PJ82 ,PJ84 ,PJ86 ,PJ87 ,PJ88 ,PJ90 ,PJ91 ,PJ93 ,PJ94 ,PJ95 ,PJ0100 ,PJ101 ,model . PJ92 ,PJ106);
            int count = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( count < 1 )
                MessageBox.Show( "录入数据失败" );
            else
            {
                MessageBox.Show( "成功录入数据" );
                try
                {
                    SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_347" ,"产品塑料、布和其他零配件采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,model . PJ92 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"保存" ,stateOfOdd ) );
                }
                catch { }
                finally { saves( ); }
            }
        }
        protected override void save ( )
        {
            base.save( );

            if ( saveOfCategory( ) == true )
            {
                MessageBox.Show( "类别不可为空" );
                return;
            }

            if ( string . IsNullOrEmpty (comboBox4.Text ) )
            {
                MessageBox . Show ( "请选择产品名称" );
                return;
            }

            #region
            PJ0100 = checkBox17.Checked == true ? "T" : "F";
            if ( !string.IsNullOrEmpty( textBox13.Text ) )
                PJ94 = textBox13.Text;
            else
                PJ94 = "";
            if ( !string.IsNullOrEmpty( textBox21.Text ) )
                PJ096 = Convert.ToInt64( textBox21.Text );
            else
                PJ096 = 0;
            PJ93 = comboBox4 . Text;
            PJ101 = lookUpEdit2.Text;
            PJ04 = textBox9.Text;
            PJ05 = dateTimePicker1.Value;
            PJ06 = textBox11.Text;
            PJ07 = dateTimePicker2.Value;
            PJ08 = textBox14.Text;
            PJ21 = textBox31.Text;
            PJ22 = comboBox19.Text;
            PJ23 = dateTimePicker6.Value;
            PJ24 = textBox36.Text;
            PJ25 = comboBox18.Text;
            PJ26 = dateTimePicker7.Value;
            PJ27 = textBox39.Text;
            PJ28 = comboBox16.Text;
            PJ29 = dateTimePicker8.Value;
            PJ30 = textBox42.Text;
            PJ31 = comboBox14.Text;
            PJ32 = dateTimePicker9.Value;
            PJ33 = textBox30.Text;
            PJ34 = textBox33.Text;
            if ( checkBox21.Checked )
            {
                PJ35 = "T";
            }
            else
            {
                PJ35 = "F";
            }
            if ( checkBox22.Checked )
            {
                PJ36 = "T";
            }
            else
            {
                PJ36 = "F";
            }
            if ( checkBox23.Checked )
            {
                PJ37 = "T";
            }
            else
            {
                PJ37 = "F";
            }
            if ( checkBox24.Checked )
            {
                PJ38 = "T";
            }
            else
            {
                PJ38 = "F";
            }
            if ( checkBox5.Checked )
            {
                PJ39 = "T";
            }
            else
            {
                PJ39 = "F";
            }
            if ( checkBox6.Checked )
            {
                PJ40 = "T";
            }
            else
            {
                PJ40 = "F";
            }
            if ( checkBox7.Checked )
            {
                PJ41 = "T";
            }
            else
            {
                PJ41 = "F";
            }
            if ( checkBox1.Checked )
            {
                PJ42 = "T";
            }
            else
            {
                PJ42 = "F";
            }
            if ( checkBox2.Checked )
            {
                PJ43 = "T";
            }
            else
            {
                PJ43 = "F";
            }
            if ( checkBox4.Checked )
            {
                PJ44 = "T";
            }
            else
            {
                PJ44 = "F";
            }
            if ( checkBox3.Checked )
            {
                PJ45 = "T";
            }
            else
            {
                PJ45 = "F";
            }
            if ( checkBox8.Checked )
            {
                PJ46 = "T";
            }
            else
            {
                PJ46 = "F";
            }
            if ( checkBox9.Checked )
            {
                PJ47 = "T";
            }
            else
            {
                PJ47 = "F";
            }
            if ( checkBox11.Checked )
            {
                PJ48 = "T";
            }
            else
            {
                PJ48 = "F";
            }
            if ( checkBox10.Checked )
            {
                PJ49 = "T";
            }
            else
            {
                PJ49 = "F";
            }
            if ( checkBox12.Checked )
            {
                PJ50 = "T";
            }
            else
            {
                PJ50 = "F";
            }
            if ( radioButton1.Checked )
            {
                PJ51 = "在内";
            }
            else if ( radioButton2.Checked )
            {
                PJ51 = "不在内";
            }
            if ( radioButton3.Checked )
            {
                PJ52 = "有";
            }
            else if ( radioButton4.Checked )
            {
                PJ52 = "没有";
            }
            if ( radioButton6.Checked )
            {
                PJ53 = "已检测";
                PJ54 = textBox43.Text;
            }
            else if ( radioButton5.Checked )
            {
                PJ53 = "未检测";
            }
            PJ55 = textBox45.Text;
            PJ56 = textBox44.Text;
            if ( checkBox13.Checked )
            {
                PJ57 = "T";
            }
            else
            {
                PJ57 = "F";
            }
            if ( checkBox14.Checked )
            {
                PJ58 = "T";
            }
            else
            {
                PJ58 = "F";
            }
            if ( checkBox15.Checked )
            {
                PJ59 = "T";
            }
            else
            {
                PJ59 = "F";
            }
            if ( checkBox16.Checked )
            {
                PJ60 = "T";
            }
            else
            {
                PJ60 = "F";
            }
            if ( checkBox18.Checked )
            {
                PJ61 = "T";
            }
            else
            {
                PJ61 = "F";
            }
            if ( checkBox19.Checked )
            {
                PJ62 = "T";
            }
            else
            {
                PJ62 = "F";
            }
            if ( checkBox20.Checked )
            {
                PJ63 = "T";
            }
            else
            {
                PJ63 = "F";
            }
            if ( textBox55.Text == "" )
            {
                PJ64 = 0;
            }
            else
            {
                PJ64 = Convert.ToInt64( textBox55.Text );
            }
            if ( radioButton7.Checked )
            {
                PJ65 = "合格";
            }
            else if ( radioButton8.Checked )
            {
                PJ65 = "条件接收";
                PJ66 = textBox25.Text;
            }
            else if ( radioButton9.Checked )
            {
                PJ65 = "退货";
            }
            PJ67 = comboBox12.Text;
            PJ68 = comboBox11.Text;
            PJ78 = comboBox10.Text;
            PJ79 = dateTimePicker10.Value;
            if ( textBox57.Text == "" )
            {
                PJ69 = 0;
            }
            else
            {
                PJ69 = Convert.ToInt64( textBox57.Text );
            }
            if ( textBox58.Text == "" )
            {
                PJ70 = 0;
            }
            else
            {
                PJ70 = Convert.ToInt64( textBox58.Text );
            }
            if ( textBox59.Text == "" )
            {
                PJ71 = 0;
            }
            else
            {
                PJ71 = Convert.ToInt64( textBox59.Text );
            }
            if ( textBox18.Text == "" )
            {
                PJ72 = 0;
            }
            else
            {
                PJ72 = Convert.ToInt64( textBox18.Text );
            }
            if ( textBox12.Text == "" )
            {
                PJ73 = 0;
            }
            else
            {
                PJ73 = Convert.ToInt64( textBox12.Text );
            }
            if ( textBox10.Text == "" )
            {
                PJ74 = 0;
            }
            else
            {
                PJ74 = Convert.ToInt64( textBox10.Text );
            }
            if ( textBox24.Text == "" )
            {
                PJ75 = 0;
            }
            else
            {
                PJ75 = Convert.ToInt64( textBox24.Text );
            }
            if ( textBox23.Text == "" )
            {
                PJ76 = 0;
            }
            else
            {
                PJ76 = Convert.ToInt64( textBox23.Text );
            }
            if ( textBox22.Text == "" )
            {
                PJ77 = 0;
            }
            else
            {
                PJ77 = Convert.ToInt64( textBox22.Text );
            }
            PJ80 = textBox68.Text;
            PJ81 = textBox69.Text;
            PJ82 = dateTimePicker11.Value;
            PJ83 = textBox71.Text;
            PJ84 = dateTimePicker12.Value;
            PJ85 = textBox27.Text;
            PJ86 = dateTimePicker15.Value;
            PJ87 = dateTimePicker13.Value;
            PJ88 = dateTimePicker3.Value;
            //PJ100 = checkBox17 . Checked == true ? "T" : "F";
            PJ106 = checkBox25.Checked == true ? "T" : "F";
            #endregion

            PJ90 = textBox29.Text;
            PJ91 = "";
            PJ01 = textBox17.Text;

            if ( string . IsNullOrEmpty ( textBox14 . Text ) )
            {
                MessageBox . Show ( "合同批号不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit1 . Text ) )
            {
                MessageBox . Show ( "请选择采购人" );
                return;
            }
            PJ02 = lookUpEdit1.EditValue.ToString( );

            DataTable drt = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQS WHERE PJ92=@PJ92" ,new SqlParameter( "@PJ92" ,model . PJ92 ) );

            if ( weihu .Equals( "1") )
            {
                if ( string . IsNullOrEmpty ( textBox29 . Text ) )
                    MessageBox . Show ( "请填写维护意见" );
                else
                {
                    if ( drt . Rows . Count < 1 )
                        MessageBox . Show ( "单号:" + model . PJ92 + "的记录不存在,请核实后再维护" );
                    else
                    {
                        PJ91 = drt . Rows [ 0 ] [ "PJ91" ] . ToString ( ) + "[" + Logins . username + MulaolaoBll . Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "]";
                        stateOfOdd = "维护保存";
                        StringBuilder strSql = new StringBuilder ( );
                        strSql . AppendFormat ( "UPDATE R_PQS SET PJ01='{0}',PJ02='{1}',PJ03='{2}',PJ04='{3}',PJ06='{4}',PJ08='{5}',PJ21='{6}',PJ22='{7}',PJ24='{8}',PJ25='{9}',PJ27='{10}',PJ28='{11}',PJ30='{12}',PJ31='{13}',PJ33='{14}',PJ34='{15}',PJ35='{16}',PJ36='{17}',PJ37='{18}',PJ38='{19}',PJ39='{20}',PJ40='{21}',PJ41='{22}',PJ42='{23}',PJ43='{24}',PJ44='{25}',PJ45='{26}',PJ46='{27}',PJ47='{28}',PJ48='{29}',PJ49='{30}',PJ50='{31}',PJ51='{32}',PJ52='{33}',PJ53='{34}',PJ54='{35}',PJ55='{36}',PJ56='{37}',PJ57='{38}',PJ58='{39}',PJ59='{40}',PJ60='{41}',PJ61='{42}',PJ62='{43}',PJ63='{44}',PJ65='{45}',PJ66='{46}',PJ67='{47}',PJ68='{48}',PJ78='{49}',PJ80='{50}',PJ81='{51}',PJ83='{52}',PJ85='{53}',PJ64='{54}',PJ69='{55}',PJ70='{56}',PJ71='{57}',PJ72='{58}',PJ73='{59}',PJ74='{60}',PJ75='{61}',PJ76='{62}',PJ77='{63}',PJ05='{64}',PJ07='{65}',PJ23='{66}',PJ26='{67}',PJ29='{68}',PJ32='{69}',PJ79='{70}',PJ82='{71}',PJ84='{72}',PJ86='{73}',PJ87='{74}',PJ88='{75}',PJ90='{76}',PJ91='{77}',PJ93='{78}',PJ94='{79}',PJ95='{80}',PJ100='{81}',PJ101='{82}',PJ106='{84}' WHERE PJ92='{83}'" ,PJ01 ,PJ02 ,PJ03 ,PJ04 ,PJ06 ,PJ08 ,PJ21 ,PJ22 ,PJ24 ,PJ25 ,PJ27 ,PJ28 ,PJ30 ,PJ31 ,PJ33 ,PJ34 ,PJ35 ,PJ36 ,PJ37 ,PJ38 ,PJ39 ,PJ40 ,PJ41 ,PJ42 ,PJ43 ,PJ44 ,PJ45 ,PJ46 ,PJ47 ,PJ48 ,PJ49 ,PJ50 ,PJ51 ,PJ52 ,PJ53 ,PJ54 ,PJ55 ,PJ56 ,PJ57 ,PJ58 ,PJ59 ,PJ60 ,PJ61 ,PJ62 ,PJ63 ,PJ65 ,PJ66 ,PJ67 ,PJ68 ,PJ78 ,PJ80 ,PJ81 ,PJ83 ,PJ85 ,PJ64 ,PJ69 ,PJ70 ,PJ71 ,PJ72 ,PJ73 ,PJ74 ,PJ75 ,PJ76 ,PJ77 ,PJ05 ,PJ07 ,PJ23 ,PJ26 ,PJ29 ,PJ32 ,PJ79 ,PJ82 ,PJ84 ,PJ86 ,PJ87 ,PJ88 ,PJ90 ,PJ91 ,PJ93 ,PJ94 ,PJ95 ,PJ0100 ,PJ101 ,model . PJ92 ,PJ106 );
                        int count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                        if ( count < 1 )
                            MessageBox . Show ( "录入数据失败" );
                        else
                        {
                            MessageBox . Show ( "成功录入数据" );
                            try
                            {
                                SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( "R_347" ,"产品塑料、布和其他零配件采购合同" ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,model . PJ92 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"保存" ,stateOfOdd ) );
                                SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfCopy ( "R_PQSC" ,"R_PQS" ,"PJ92" ,model . PJ92 ) );
                                WriteOfReceivablesTo ( );
                            }
                            catch { }
                            finally { saves ( ); }
                        }
                    }
                }
            }
            else
            {
                if ( adds == "1" )
                    stateOfOdd = "新增保存";
                else
                    stateOfOdd = "更改保存";

                if ( drt.Rows.Count < 1 )
                    saves( );
                else
                {
                    if ( copy == "1" )
                    {
                        if ( MulaolaoBll . WriteReceivableToGeneralLedger . ExistsSup ( PJ03 ) == false )
                        {
                            MessageBox . Show ( "供应商已注销,请核实" );
                            return;
                        }

                        // AND PJ04=@PJ04
                        DataTable dru = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQS WHERE PJ92!=@PJ92" ,new SqlParameter( "@PJ92" ,model . PJ92 ) /*,new SqlParameter( "@PJ04" ,PJ04 )*/ );
                        if ( dru.Rows.Count < 1 )
                            updates( );
                        else
                        {
                            int proNum = 0;

                            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                            {
                                proNum = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "PJ96" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView1 . GetDataRow ( i ) [ "PJ96" ] );
                                if ( proNum != PJ096 )
                                {
                                    MessageBox . Show ( "产品数量不一致,请核实" );
                                    break;
                                }

                                if ( ord == "计划" || string.IsNullOrEmpty( textBox17.Text ) )
                                {
                                    if ( dru.Select( "PJ09='" + gridView1.GetDataRow( i )["PJ09"].ToString( ) + "' AND PJ89='" + gridView1.GetDataRow( i )["PJ89"].ToString( ) + "' AND PJ95='" + PJ95 + "'" ).Length > 0 )
                                    {
                                        if ( PJ08.Length > 8 && PJ08.Substring( 0 ,8 ) == "MLL-0001" )
                                        {
                                            updates( );
                                            break;
                                        }
                                        else
                                        {
                                            //\n\r开合同人:" + PJ04 + "
                                            MessageBox.Show( "已经存在\n\r货号:" + PJ95 + "\n\r物料名称:" + gridView1.GetDataRow( i )["PJ09"].ToString( ) + "\n\r规格:" + gridView1.GetDataRow( i )["PJ89"].ToString( ) + "\n\r的记录,请核实后再录入" );
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        updates( );
                                        break;
                                    }
                                }
                                else if ( ord == "实际" || !string.IsNullOrEmpty( textBox17.Text ) )
                                {
                                    if ( yesOrNoHaveStock( ) == false )
                                        return;

                                    if ( !string . IsNullOrEmpty ( textBox17 . Text ) )
                                    {
                                        if ( checkThisAnd509 ( ) == false )
                                            return;
                                    }

                                    if ( dru.Select( "PJ09='" + gridView1.GetDataRow( i )["PJ09"].ToString( ) + "' AND PJ89='" + gridView1.GetDataRow( i )["PJ89"].ToString( ) + "' AND PJ01='" + PJ01 + "'" ).Length > 0 )
                                    {
                                        if ( PJ08.Length > 8 && PJ08.Substring( 0 ,8 ) == "MLL-0001" )
                                        {
                                            updates( );
                                            break;
                                        }
                                        else
                                        {
                                            //\n\r开合同人:" + PJ04 + "
                                            MessageBox.Show( "已经存在\n\r流水号:" + PJ01 + "\n\r物料名称:" + gridView1.GetDataRow( i )["PJ09"].ToString( ) + "\n\r规格:" + gridView1.GetDataRow( i )["PJ89"].ToString( ) + "\n\r的记录,请核实后再录入" );
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
        bool saveOfCategory ( )
        {
            result = false;
            if ( gridView1.RowCount > 0 )
            {
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    if ( string.IsNullOrEmpty( gridView1.GetDataRow( i )["PJ105"].ToString( ) ) )
                    {
                        result = true;
                        break;
                    }
                }
            }

            return result;
        }
        bool yesOrNoHaveStock ( )
        {
            result = true;
            //PJ15:使用库存OR外购
            //PJ96:产品数量
            //PJ09:物料名称
            //PJ89:规格
            //combobox5:货号
            if ( gridView1 . RowCount > 0 && gridView1 . GetDataRow ( 0 ) [ "PJ15" ] . ToString ( ) == "库存" )
            {
                for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
                {
                    result = fc . LibraryOf ( comboBox5 . Text , gridView1 . GetDataRow ( i ) [ "PJ96" ] . ToString ( ) , gridView1 . GetDataRow ( i ) [ "PJ09" ] . ToString ( ) , gridView1 . GetDataRow ( i ) [ "PJ89" ] . ToString ( ) );
                    if ( result == false )
                    {
                        MessageBox . Show ( "库存数量少于使用库存数量,请核实" );
                        break;
                    }
                    else if ( i == gridView1 . RowCount - 1 )
                        result = true;
                }
            }
            else
                result = true;
            return result;
        }
        bool checkThisAnd509 ( )
        {
            result = true;
            model . PJ01 = textBox17 . Text;
            for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
            {
                model . PJ09 = gridView1 . GetDataRow ( i ) [ "PJ09" ] . ToString ( );
                model . PJ89 = gridView1 . GetDataRow ( i ) [ "PJ89" ] . ToString ( );
                result = fc . check347And509 ( model );
                if ( result == false )
                {
                    MessageBox . Show ( "流水号:" + model . PJ01 + "\n\r物品名称:" + model . PJ09 + "\n\r规格:" + model . PJ89 + "\n\r与509不一致,请核实" );
                    break;
                }
            }
            return result;
        }
        //取消
        protected override void cancel ( )
        {
            base.cancel( );

            if ( adds == "1" && weihu != "1" )
            {
                PJ03 = "";
                Ergodic.SpliClear( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;
                toolSelect.Enabled = toolAdd.Enabled =  true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = toolPrint.Enabled = toolExport.Enabled = false;
                textBox29.Enabled = false;
                gridControl1.DataSource = null;
                label98.Visible = false;
                try
                {
                    bll.DeleteAll( "R_347" ,"产品塑料、布和其他零配件采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,model . PJ92 ,"取消" ,"新增取消" );
                }
                catch { }

            }
            else if ( adds == "2" || weihu == "1" )
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
            }
            textBox29.Enabled = false;
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
        }
        //维护
        protected override void maintain ( )
        {
            base.maintain( );

            if ( label78.Visible == true )
            {
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );

                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;

                weihu = "1";
                dateTimePicker2.Enabled = dateTimePicker5.Enabled = dateTimePicker1.Enabled = false;
                label78.Visible = true;
                textBox29.Enabled = true;
                if ( !string.IsNullOrEmpty( textBox17.Text ) )
                {
                    comboBox4.Enabled = comboBox5.Enabled = false;
                    textBox21.Enabled = false;
                    button15.Enabled = false;
                    button5.Enabled = true;
                }
                else
                {
                    comboBox4.Enabled = comboBox5.Enabled = true;
                    textBox21.Enabled = true;
                    button15.Enabled = true;
                    button5.Enabled = false;
                }
            }
            else
                MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
        }
        //出库
        protected override void library ( )
        {
            base.library( );

            if ( label78.Visible == false )
            {
                MessageBox.Show( "非执行单据不能出库" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox4.Text ) )
            {
                MessageBox.Show( "产品名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox5.Text ) )
            {
                MessageBox.Show( "货号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox21.Text ) )
            {
                MessageBox.Show( "产品数量不可为空" );
                return;
            }
            if ( gridView1.GetDataRow( 0 )["PJ15"].ToString( ) == "外购" )
            {
                MessageBox.Show( "使用外购不能出库,请选择库存或更改状态" );
                return;
            }

            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                if ( libraryTable != null )
                    libraryTable.Rows.Add( new object[] { gridView1.GetDataRow( i )["PJ89"].ToString( ) ,gridView1.GetDataRow( i )["PJ09"].ToString( ) ,Convert.ToDecimal( gridView1.GetDataRow( i )["PJ14"].ToString( ) ) } );
                else
                {
                    libraryTable = new DataTable( "Datas" );
                    libraryTable.Columns.Add( "tOne" ,typeof( System.String ) );
                    libraryTable.Columns.Add( "tTwo" ,typeof( System.String ) );
                    libraryTable.Columns.Add( "tTre" ,typeof( System.Decimal ) );
                    libraryTable.Rows.Add( new object[] { gridView1.GetDataRow( i )["PJ89"].ToString( ) ,gridView1.GetDataRow( i )["PJ09"].ToString( ) ,Convert.ToDecimal( gridView1.GetDataRow( i )["PJ14"].ToString( ) ) } );
                }
            }
            if ( libraryTable.Rows.Count > 0 )
            {
                SelectAll.OutbandChoice outC = new SelectAll.OutbandChoice( );
                outC.libraryTable = libraryTable;
                outC.number = comboBox5.Text;
                outC.sign = "R_347";
                outC.oddNum = model . PJ92;
                outC.StartPosition = FormStartPosition.CenterScreen;
                outC.PassDataBetweenForm += new SelectAll.OutbandChoice.PassDataBetweenFormHandler( outC_PassDataBetweenForm );
                outC.ShowDialog( );
            }
            if ( conOne == "2" )
                return;
            int countSum = 0;
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                speList.Clear( );
                string query = "", count = "";
                if ( libraryTable == null )
                    query = count = "";
                if ( libraryTable != null && libraryTable.Rows.Count > 0 )
                {
                    countSum = libraryTable.Select( "tTwo='" + gridView1.GetDataRow( i )["PJ89"].ToString( ) + gridView1.GetDataRow( i )["PJ09"].ToString( ) + "'" ).Length;
                    if ( countSum > 0 )
                    {
                        for ( int k = 0 ; k < countSum ; k++ )
                        {
                            if ( !speList.Contains( libraryTable.Select( "tTwo='" + gridView1.GetDataRow( i )["PJ89"].ToString( ) + gridView1.GetDataRow( i )["PJ09"].ToString( ) + "'" )[k]["tOne"].ToString( ) ) )
                                speList.Add( libraryTable.Select( "tTwo='" + gridView1.GetDataRow( i )["PJ89"].ToString( ) + gridView1.GetDataRow( i )["PJ09"].ToString( ) + "'" )[k]["tOne"].ToString( ) );
                        }
                        if ( speList.Count > 0 )
                        {
                            foreach ( string str in speList )
                            {
                                query = str;
                                count = libraryTable.Select( "tTwo='" + gridView1.GetDataRow( i )["PJ89"].ToString( ) + gridView1.GetDataRow( i )["PJ09"].ToString( ) + "' AND tOne='" + query + "'" )[0]["tTre"].ToString( );

                                result = fc . Library ( comboBox4 . Text ,comboBox5 . Text ,textBox17 . Text ,textBox21 . Text ,gridView1 . GetDataRow ( i ) [ "PJ09" ] . ToString ( ) ,gridView1 . GetDataRow ( i ) [ "PJ89" ] . ToString ( ) ,gridView1 . GetDataRow ( i ) [ "PJ17" ] . ToString ( ) ,gridView1 . GetDataRow ( i ) [ "PJ11" ] . ToString ( ) ,"" ,gridView1 . GetDataRow ( i ) [ "PJ12" ] . ToString ( ) ,/*gridView1.GetDataRow( i )["PJ14"].ToString( )*/ count ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,model . PJ92 ,query . ToString ( ) ,lookUpEdit2 . Text );
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
                MessageBox.Show( "出库成功" );
        }
        private void outC_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            libraryTable = new DataTable( );
            conOne = e.ConOne;
            libraryTable = e.TabOne;
        }
        //入库
        protected override void storage ( )
        {
            base.storage( );

            if ( label78.Visible == true )
            {
                if ( string . IsNullOrEmpty ( comboBox4 . Text ) )
                {
                    MessageBox . Show ( "产品名称不可为空" );
                    return;
                }
                if ( string . IsNullOrEmpty ( comboBox5 . Text ) )
                {
                    MessageBox . Show ( "货号不可为空" );
                    return;
                }
                if ( string . IsNullOrEmpty ( textBox21 . Text ) )
                {
                    MessageBox . Show ( "产品数量不可为空" );
                    return;
                }
                if ( gridView1 . GetDataRow ( 0 ) [ "PJ15" ] . ToString ( ) == "库存" )
                {
                    MessageBox . Show ( "库存无法入库,请选择外购或更改状态" );
                    return;
                }
                if ( gridView1 . GetDataRow ( 0 ) [ "PJ15" ] . ToString ( ) == "外购" && ( ord == "实际" ) || !string . IsNullOrEmpty ( textBox17 . Text ) )
                {
                    MessageBox . Show ( "实际订单不允许入库" );
                    return;
                }
                    string mt = "";
                for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
                {
                    if ( Convert . ToInt64 ( textBox21 . Text ) == 0 )
                        mt = gridView1 . GetDataRow ( i ) [ "PJ11" ] . ToString ( );
                    else
                    {
                        if ( string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "PJ10" ] . ToString ( ) ) )
                            mt = gridView1 . GetDataRow ( i ) [ "PJ11" ] . ToString ( );
                        else
                            mt = Math . Round ( Convert . ToDecimal ( Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "PJ11" ] . ToString ( ) ) + Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "PJ10" ] . ToString ( ) ) / Convert . ToInt64 ( textBox21 . Text ) ) ,4 ) . ToString ( );
                    }
                    result = fc . Storage ( comboBox4 . Text ,comboBox5 . Text ,textBox21 . Text ,gridView1 . GetDataRow ( i ) [ "PJ09" ] . ToString ( ) ,gridView1 . GetDataRow ( i ) [ "PJ89" ] . ToString ( ) ,gridView1 . GetDataRow ( i ) [ "PJ17" ] . ToString ( ) ,mt ,"" ,gridView1 . GetDataRow ( i ) [ "PJ12" ] . ToString ( ) ,gridView1 . GetDataRow ( i ) [ "PJ97" ] . ToString ( ) ,textBox9 . Text ,dateTimePicker2 . Value ,lookUpEdit1 . Text ,MulaolaoBll . Drity . GetDt ( ) ,model . PJ92 ,gridView1 . GetDataRow ( i ) [ "PJ102" ] . ToString ( ) ,gridView1 . GetDataRow ( i ) [ "PJ103" ] . ToString ( ) ,lookUpEdit2 . Text ,textBox1 . Text ,textBox6 . Text );
                    if ( result == false )
                    {
                        MessageBox . Show ( "入库失败" );
                        break;
                    }
                    else
                    {
                        MessageBox . Show ( "入库成功" );
                        try
                        {
                            for ( int k = 0 ; k < gridView1 . RowCount ; k++ )
                            {
                                model . IDX = string . IsNullOrEmpty ( gridView1 . GetDataRow ( k ) [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView1 . GetDataRow ( k ) [ "idx" ] . ToString ( ) );
                                model . PJ102 = string . IsNullOrEmpty ( textBox21 . Text ) == true ? 0 : Convert . ToInt64 ( textBox21 . Text );
                                model . PJ103 = string . IsNullOrEmpty ( gridView1 . GetDataRow ( k ) [ "PJ97" ] . ToString ( ) ) == true ? 0 : Convert . ToInt64 ( gridView1 . GetDataRow ( k ) [ "PJ97" ] . ToString ( ) );
                                bll . UpdateStr ( model );
                            }
                        }
                        catch { }
                    }
                }
            }
            else
                MessageBox.Show( "非执行单据不能入库" );
        }
        //复制
        protected override void copys ( )
        {
            base.copys( );

            if ( label78.Visible == true )
                stateOfOdd = "维护复制";
            else
            {
                if ( adds == "1" )
                    stateOfOdd = "新增复制";
                else
                    stateOfOdd = "更改复制";
            }

            string /*pj = PJ92,*/ text = textBox1.Text;
            result = bll.Copy( "R_347" ,"产品塑料、布和其他零配件采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,model . PJ92 ,"复制" ,stateOfOdd );
            if ( result==false )
                MessageBox.Show( "复制失败,请重试" );
            else
            {
                model . PJ92 = oddNumbers.purchaseContract( "SELECT MAX(AJ007) AJ007 FROM R_PQAJ" ,"AJ007" ,"R_347-" );
                stateOfOdd = "更改复制单号";
                result = bll.CopyAll( "R_347" ,"产品塑料、布和其他零配件采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,model . PJ92 ,"复制" ,stateOfOdd );
                if ( result==false )
                {
                    MessageBox.Show( "复制失败,请重试" );
                    SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQS WHERE PJ92 IS NULL" );
                }
                else
                {
                    MessageBox.Show( "成功复制此表" );
                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                    toolSave.Enabled = toolCancel.Enabled = true;

                    textBox29.Enabled = false;
                    Ergodic.FormEvery( this );
                    Ergodic.SpliEnableTrue( spList );
                    Ergodic.TablePageEnableTrue( pageList );
                    gridControl1.DataSource = null;
                    dateTimePicker1.Enabled = dateTimePicker2.Enabled = dateTimePicker5.Enabled = false;
                    adds = "1";
                    copy = "1";
                    weihu = "";
                    label78.Visible = false;
                    queryContent( );
                    textBox1.Text = text;
                    button13_Click( null ,null );
                }
            }
        }
        #endregion

        #region  表格
        long PJ010 = 0, id = 0;
        decimal PJ012 = 0M, PJ013 = 0M, PJ016 = 0M, PJ011 = 0M, PJ014 = 0M, PJ097 = 0M;
        string PJ017 = "", PJ018 = "", PJ089 = "", PJ015 = "", PJ0100 = "";
        DateTime PJ020 = MulaolaoBll . Drity . GetDt ( ), PJ019 = MulaolaoBll . Drity . GetDt ( );
        //新建
        void getSet ( )
        {
            PJ93 = comboBox4.Text;
            PJ95 = comboBox5.Text;
            if ( !string.IsNullOrEmpty( textBox21.Text ) )
                PJ096 = Convert.ToInt64( textBox21.Text );
            if ( !string.IsNullOrEmpty( comboBox13.Text ) )
                PJ010 = Convert.ToInt64( comboBox13.Text );
            else
                PJ010 = 0;
            if ( !string.IsNullOrEmpty( textBox37.Text ) )
                PJ011 = Convert.ToDecimal( textBox37.Text );
            else
                PJ011 = 0;
            if ( !string.IsNullOrEmpty( comboBox3.Text ) )
                PJ012 = Convert.ToDecimal( comboBox3.Text );
            else
                PJ012 = 0;
            if ( !string.IsNullOrEmpty( textBox7.Text ) )
                PJ013 = Convert.ToDecimal( textBox7.Text );
            else
                PJ013 = 0;
            if ( radioButton10.Checked )
            {
                PJ015 = "库存";
                if ( string.IsNullOrEmpty( textBox15.Text ) )
                    PJ014 = 0;
                else
                    PJ014 = Convert.ToDecimal( textBox15.Text );
                PJ097 = 0;
            }
            else if ( radioButton11.Checked )
            {
                PJ015 = "外购";
                if ( string.IsNullOrEmpty( textBox35.Text ) )
                    PJ097 = 0;
                else
                    PJ097 = Convert.ToDecimal( textBox35.Text );
                PJ014 = 0;
            }
            if ( !string.IsNullOrEmpty( comboBox15.Text ) )
                PJ016 = Convert.ToDecimal( comboBox15.Text );
            else
                PJ016 = 0;
            PJ017 = comboBox8.Text;
            PJ018 = comboBox17.Text;
            PJ019 = dateTimePicker4.Value;
            PJ020 = dateTimePicker5.Value;
            PJ089 = textBox26.Text;
            PJ009 = gridLookUpEdit1.Text;
            PJ0105 = comboBox1.Text;
        }
        void build ( )
        {
            DataTable dew = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQS A,R_PQP B WHERE A.PJ09=B.GS07 AND PJ92=@PJ92 AND PJ09=@PJ09 AND PJ89=@PJ89" ,new SqlParameter( "@PJ92" ,model . PJ92 ) ,new SqlParameter( "@PJ09" ,PJ009 ) ,new SqlParameter( "@PJ89" ,PJ089 ) );
            if ( dew.Rows.Count < 1 )
            {
                StringBuilder strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQS (PJ09,PJ89,PJ10,PJ11,PJ12,PJ13,PJ14,PJ15,PJ16,PJ17,PJ18,PJ19,PJ20,PJ92,PJ93,PJ95,PJ96,PJ97,PJ105,PJ03) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}')" ,PJ009 ,PJ089 ,PJ010 ,PJ011 ,PJ012 ,PJ013 ,PJ014 ,PJ015 ,PJ016 ,PJ017 ,PJ018 ,PJ019 ,PJ020 ,model . PJ92 ,PJ93 ,PJ95 ,PJ096 ,PJ097 ,PJ0105 ,PJ03 );
                int count = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
                if ( count < 1 )
                    MessageBox.Show( "录入数据失败" );
                else
                {
                    MessageBox.Show( "成功录入数据" );
                    try
                    {
                        if ( label78.Visible == true )
                            stateOfOdd = "维护新建";
                        else
                        {
                            if ( adds == "1" )
                                stateOfOdd = "新增新建";
                            else
                                stateOfOdd = "更改新建";
                        }
                        SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_347" ,"产品塑料、布和其他零配件采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,model . PJ92 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"新建" ,stateOfOdd ) );
                    }
                    catch { }
                    finally {
                        every( );
                        button13_Click( null ,null );
                    }
                }
            }
            else
                MessageBox.Show( "单号：" + model . PJ92 + "\n\r物品名称：" + PJ009 + "\n\r公差尺寸含长宽高：" + PJ089 + "\n\r的数据已经存在,请核实后再录入" );
        }
        void buildes ( )
        {
            DataTable dn = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQS WHERE PJ95=@PJ95 AND PJ09=@PJ09 AND PJ89=@PJ89 AND PJ01='' AND PJ92=(SELECT MAX(PJ92) FROM R_PQS WHERE PJ95=@PJ95 AND PJ09=@PJ09 AND PJ89=@PJ89 AND PJ01='')" ,new SqlParameter( "@PJ95" ,PJ95 ) ,new SqlParameter( "@PJ09" ,PJ009 ) ,new SqlParameter( "@PJ89" ,PJ089 ) );
            if ( dn.Rows.Count > 0 )
            {
                if ( dn.Select( "PJ11='" + PJ011 + "'" ).Length <= 0 )
                    MessageBox.Show( "每套用量与计划订单不一致,应为:" + dn.Rows[0]["PJ11"].ToString( ) + "" );
                else
                {
                    if ( dn.Select( "PJ12='" + PJ012 + "'" ).Length <= 0 )
                        MessageBox.Show( "现价与计划订单不一致,应为:" + dn.Rows[0]["PJ12"].ToString( ) + "" );
                    //else
                    //{
                    //    if ( dn.Select( "PJ13='" + PJ013 + "'" ).Length <= 0 )
                    //        MessageBox.Show( "原价与计划订单不一致,应为:" + dn.Rows[0]["PJ13"].ToString( ) + "" );
                        else
                            build( );
                    //}
                }
            }
            else
                build( );
        }
        void outSouce ( )
        {
            if ( radioButton10.Checked )
                MessageBox.Show( "只能开外购合同" );
            else
            {
                string sx = Math.Round( Convert.ToDecimal( Operation.MultiTwoTAdd( textBox21 ,textBox37 ,comboBox13 ) ) ,4 ).ToString( );
                if ( !string.IsNullOrEmpty( sx ) && !string.IsNullOrEmpty( textBox35.Text ) )
                {
                    if ( Convert.ToDecimal( sx ) != Convert.ToDecimal( textBox35.Text ) )
                        MessageBox.Show( "外购数量有误,请核实" );
                    else
                        build( );
                }
            }
        }
        void outSouces ( )
        {
            if ( radioButton10.Checked )
                MessageBox.Show( "只能开外购合同" );
            else
            {
                string sx = Math.Round( Convert.ToDecimal( Operation.MultiTwoTAdd( textBox21 ,textBox37 ,comboBox13 ) ) ,4 ).ToString( );
                if ( !string.IsNullOrEmpty( sx ) && !string.IsNullOrEmpty( textBox35.Text ) )
                {
                    if ( Convert.ToDecimal( sx ) != Convert.ToDecimal( textBox35.Text ) )
                        MessageBox.Show( "外购数量有误,请核实" );
                    else
                        buildes( );
                }
            }
        }
        void plan ( )
        {
            if ( radioButton11.Checked == true )
            {
                if ( Logins.number == "MLL-0001" )
                {
                    string sx = Math.Round( Convert.ToDecimal( Operation.MultiTwoTAdd( textBox21 ,textBox37 ,comboBox13 ) ) ,4 ).ToString( );
                    if ( !string.IsNullOrEmpty( sx ) && !string.IsNullOrEmpty( textBox35.Text ) )
                    {
                        if ( Convert.ToDecimal( sx ) != Convert.ToDecimal( textBox35.Text ) )
                            MessageBox.Show( "外购数量有误,请核实" );
                        else
                            build( );
                    }
                }
                else
                    MessageBox.Show( "只能开具库存合同" );
            }
            //只能开具库存合同
            else
            {
                if ( !string.IsNullOrEmpty( textBox21.Text ) && !string.IsNullOrEmpty( textBox37.Text ) )
                {
                    if ( Convert.ToDecimal( textBox21.Text ) < Convert.ToDecimal( textBox37.Text ) )
                        MessageBox.Show( "出库数量必须小于库存数量" );
                    //且出库数小于等于库存数量
                    else
                    {
                        string str = Math.Round( Convert.ToDecimal( Operation.MultiTwoTAdd( textBox21 ,textBox37 ,comboBox13 ) ) ,4 ).ToString( );
                        if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox15.Text ) )
                            MessageBox.Show( "出库数量有误,请核查" );
                        else
                            build( );
                    }
                }
            }
        }
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( comboBox5.Text ) )
            {
                MessageBox.Show( "货号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
            {
                MessageBox.Show( "类别不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( PJ03 ) || string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "请选择供应商" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox14.Text ) )
            {
                MessageBox.Show( "合同批号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox26.Text ) )
            {
                MessageBox.Show( "规格不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( gridLookUpEdit1.Text ) )
            {
                MessageBox.Show( "物品名称不可为空" );
                return;
            }
            if ( !radioButton10.Checked && !radioButton11.Checked )
            {
                MessageBox.Show( "请选择库存或者外购" );
                return;
            }
            if ( dateTimePicker4.Value < MulaolaoBll . Drity . GetDt ( ).AddDays( 5 ) )
            {
                MessageBox.Show( "约定供期必须在当天的基础上延迟5天" );
                return;
            }

            getSet( );

            #region 计划  更改新建  无流水号
            if ( ord == "计划" || string.IsNullOrEmpty( textBox17.Text ) )
            {
                //计划可以开具多份
                //同货号、物料名称、规格是否已经开过计划订单
                DataTable yesNoAcPlan = SqlHelper.ExecuteDataTable( "SELECT AC03,AC18 FROM R_PQAC WHERE AC18=(SELECT MAX(AC18) FROM R_PQAC WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05)" ,new SqlParameter( "@AC02" ,PJ95 ) ,new SqlParameter( "@AC04" ,PJ009 ) ,new SqlParameter( "@AC05" ,PJ089 ) );
                //有  继续开  只能开外购  且每张套数  每张单价  原价/m³都必须与第一份计划订单相同
                if ( yesNoAcPlan.Rows.Count > 0 && string.IsNullOrEmpty( yesNoAcPlan.Rows[0]["AC18"].ToString( ) ) == false )
                {
                    DataTable yesNoAdPlan = SqlHelper.ExecuteDataTable( "SELECT SUM(AD05+ISNULL(AD20,0)) AD05 FROM R_PQAD WHERE AD01=@AD01" ,new SqlParameter( "@AD01" ,yesNoAcPlan.Rows[0]["AC18"].ToString( ) ) );
                    //有
                    if ( yesNoAdPlan.Rows.Count > 0 && !string.IsNullOrEmpty( yesNoAdPlan.Rows[0]["AD05"].ToString( ) ) )
                    {
                        if ( yesNoAcPlan.Rows[0]["AC03"].ToString( ) == yesNoAdPlan.Rows[0]["AD05"].ToString( ) )
                            outSouce( );
                        else
                        {
                            //开合同人是否是MLL-0001
                            if ( PJ08.Length > 8 && PJ08.Substring( 0 ,8 ) == "MLL-0001" )
                                outSouces( );
                            else
                                MessageBox.Show( "此合同为补开,请找总经理处理" );
                        }
                    }
                    //无  只能开外购
                    else
                    {
                        //开合同人是否是MLL-0001
                        if ( PJ08.Length > 8 && PJ08.Substring( 0 ,8 ) == "MLL-0001" )
                            outSouces( );
                        else
                            MessageBox.Show( "此合同为补开,请找总经理处理" );
                    }
                }
                //无  只能开外购
                else
                    outSouce( );
            }
            #endregion

            #region 实际  更改新建  有流水号
            else if ( ord == "实际" || !string.IsNullOrEmpty( textBox17.Text ) )
            {
              

                bool result = pc.PlanActual( PJ009 ,PJ089 ,PJ95 );
                bool vode = pc.PlanInDataBaseSu( PJ01 ,PJ009 ,PJ089 );
                if ( result == true )
                {
                    if ( vode == true )
                        outSouce( );
                    else
                    {
                        if ( PJ08.Length > 8 && PJ08.Substring( 0 ,8 ) == "MLL-0001" )
                            outSouce( );
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
                        if ( PJ08.Length > 8 && PJ08.Substring( 0 ,8 ) == "MLL-0001" )
                            plan( );
                        else
                            MessageBox.Show( "此单为超补,需要总经理处理" );
                    }
                }
            }
            #endregion
        }
        //删除
        private void dele ( )
        {
            //int num = gridView1.FocusedRowHandle;
            //if ( adds == "1" )
            //    dfg.Rows.RemoveAt(num);
            //else if ( adds == "2" )
            //    de.Rows.RemoveAt(num);

            every( );
            button13_Click( null ,null );
        }
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;
            StringBuilder strSql = new StringBuilder( );
            strSql . AppendFormat ( "DELETE FROM R_PQS WHERE PJ92='{1}' AND idx='{0}'" , id ,model . PJ92 );
            int count = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( count < 1 )
                MessageBox.Show( "删除数据失败" );
            else
            {
                MessageBox.Show( "成功删除数据" );
                try
                {
                    if ( label78.Visible == true )
                        stateOfOdd = "维护删除";
                    else
                    {
                        if ( adds == "1" )
                            stateOfOdd = "新增删除";
                        else
                            stateOfOdd = "更改删除";
                    }
                    SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_347" ,"产品塑料、布和其他零配件采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,model . PJ92 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"删除" ,stateOfOdd ) );
                }
                catch { }
                finally { dele( ); } 
            }
        }
        //编辑
        private void up ( )
        {
            //int num = gridView1.FocusedRowHandle;
            //DataRow row;
            //if ( adds == "1" )
            //{
            //    row = dfg.Rows[num];
            //    row.BeginEdit( );
            //    row["PJ09"] = PJ009;
            //    row["PJ10"] = PJ010;
            //    row["PJ11"] = PJ011;
            //    row["PJ12"] = PJ012;
            //    row["PJ13"] = PJ013;
            //    row["PJ14"] = PJ014;
            //    row["PJ15"] = PJ015;
            //    row["PJ16"] = PJ016;
            //    row["PJ17"] = PJ017;
            //    row["PJ18"] = PJ018;
            //    row["PJ19"] = PJ019;
            //    row["PJ20"] = PJ020;
            //    row["PJ96"] = PJ096;
            //    row["PJ89"] = PJ089;
            //    row["PJ97"] = PJ097;
            //    row["PJ100"] = PJ0100;
            //    row.EndEdit( );
            //}
            //else if ( adds == "2" )
            //{
            //    row = de.Rows[num];
            //    row.BeginEdit( );
            //    row["PJ09"] = PJ009;
            //    row["PJ10"] = PJ010;
            //    row["PJ11"] = PJ011;
            //    row["PJ12"] = PJ012;
            //    row["PJ13"] = PJ013;
            //    row["PJ14"] = PJ014;
            //    row["PJ15"] = PJ015;
            //    row["PJ16"] = PJ016;
            //    row["PJ17"] = PJ017;
            //    row["PJ18"] = PJ018;
            //    row["PJ19"] = PJ019;
            //    row["PJ20"] = PJ020;
            //    row["PJ96"] = PJ096;
            //    row["PJ89"] = PJ089;
            //    row["PJ97"] = PJ097;
            //    row["PJ100"] = PJ0100;
            //    row.EndEdit( );
            //}

            //every( );
            button13_Click( null ,null );
        }
        void edit ( )
        {
            //,PJ100='{14}'  , PJ0100 
            StringBuilder strSql = new StringBuilder( );
            strSql . AppendFormat ( "UPDATE R_PQS SET PJ10='{0}',PJ11='{1}',PJ12='{2}',PJ13='{3}',PJ14='{4}',PJ15='{5}',PJ16='{6}',PJ17='{7}',PJ18='{8}',PJ19='{9}',PJ20='{10}',PJ97='{11}',PJ96='{12}',PJ93='{13}',PJ105='{14}',PJ03='{15}' WHERE PJ92='{17}' AND idx='{16}'" , PJ010 , PJ011 , PJ012 , PJ013 , PJ014 , PJ015 , PJ016 , PJ017 , PJ018 , PJ019 , PJ020 , PJ097 ,PJ096 ,PJ93 ,PJ0105 ,PJ03 , id ,model . PJ92 );
            int count = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( count < 1 )
                MessageBox.Show( "编辑数据失败" );
            else
            {
                MessageBox.Show( "成功编辑数据" );
                try
                {
                    if ( label78.Visible == true )
                        stateOfOdd = "维护编辑";
                    else
                    {
                        if ( adds == "1" )
                            stateOfOdd = "新增编辑";
                        else
                            stateOfOdd = "更改编辑";
                    }
                    SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_347" ,"产品塑料、布和其他零配件采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,model . PJ92 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"编辑" ,stateOfOdd ) );
                }
                catch { }
                finally { up( ); }
            }
        }
        void builds ( )
        {
            DataTable dkj = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQS WHERE PJ02=@PJ92 AND PJ09=@PJ09 AND PJ89=@PJ89" ,new SqlParameter( "@PJ92" ,model .PJ92 ) ,new SqlParameter( "@PJ09" ,PJ009 ) ,new SqlParameter( "@PJ89" ,PJ089 ) );
            if ( dkj.Rows.Count < 1 )
            {
                StringBuilder strSql = new StringBuilder( );//,PJ100='{16}'  , PJ0100
                strSql . AppendFormat ( "UPDATE R_PQS SET PJ09='{0}',PJ89='{1}',PJ10='{2}',PJ11='{3}',PJ12='{4}',PJ13='{5}',PJ14='{6}',PJ15='{7}',PJ16='{8}',PJ17='{9}',PJ18='{10}',PJ19='{11}',PJ20='{12}',PJ96='{13}',PJ97='{14}',PJ93='{15}',PJ105='{16}',PJ03='{17}' WHERE PJ92='{19}' AND idx='{18}'" , PJ009 , PJ089 , PJ010 , PJ011 , PJ012 , PJ013 , PJ014 , PJ015 , PJ016 , PJ017 , PJ018 , PJ019 , PJ020 , PJ096 , PJ097 , PJ93  , PJ0105 , PJ03 , id ,model . PJ92 );
                int count = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
                if ( count < 1 )
                    MessageBox.Show( "编辑数据失败" );
                else
                {
                    MessageBox.Show( "成功编辑数据" );
                    try
                    {
                        if ( label78.Visible == true )
                            stateOfOdd = "维护编辑";
                        else
                        {
                            if ( adds == "1" )
                                stateOfOdd = "新增编辑";
                            else
                                stateOfOdd = "更改编辑";
                        }
                        SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_347" ,"产品塑料、布和其他零配件采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,model . PJ92 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"编辑" ,stateOfOdd ) );
                    }
                    catch { }
                    finally { up( ); }
                }
            }
            else
                MessageBox.Show( "单号：" + model . PJ92 + "\n\r物品名称：" + PJ009 + "\n\r公差尺寸含长宽高：" + PJ089 + "\n\r的数据已经存在,请核实后再编辑" );
        }
        void planOrActual ( )
        {
            if ( radioButton10.Checked )
            {
                if ( !string.IsNullOrEmpty( textBox34.Text ) && !string.IsNullOrEmpty( textBox15.Text ) )
                {
                    if ( Convert.ToDecimal( textBox34.Text ) < Convert.ToDecimal( textBox15.Text ) )
                        MessageBox.Show( "出库数量大于库存数量,请更改出库数量" );
                    else
                    {
                        string str = Math.Round( Convert.ToDecimal( Operation.MultiTwoTAdd( textBox21 ,textBox37 ,comboBox13 ) ) ,4 ).ToString( );
                        if ( !string.IsNullOrEmpty( str ) )
                        {
                            if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox15.Text ) )
                                MessageBox.Show( "出库数量有误,请核查" );
                            else
                                builds( );
                        }
                    }
                }
            }
            else
            {
                string str = Math.Round( Convert.ToDecimal( Operation. MultiTwoTbes ( textBox21 ,textBox37 ) ) ,4 ).ToString( );
                if ( !string.IsNullOrEmpty( str ) && !string.IsNullOrEmpty( textBox35.Text ) )
                {
                    if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox35.Text ) )
                        MessageBox.Show( "外购数量有误,请核查" );
                    else
                    {
                        if ( Logins.number == "MLL-0001" )
                            builds( );
                        else
                        {
                            if ( !string.IsNullOrEmpty( textBox34.Text ) && Convert.ToDecimal( textBox34.Text ) > 0 )
                                MessageBox.Show( "库存数量不为零,不可以外购" );
                            else
                                builds( );
                        }
                    }
                }
            }
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( comboBox5.Text ) )
            {
                MessageBox.Show( "货号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox1.Text ) )
            {
                MessageBox.Show( "类别不可为空" );
                return;
            }
            if ( textBox14.Text == "" )
            {
                MessageBox.Show( "合同批号不可为空" );
                return;
            }
            if (string.IsNullOrEmpty(PJ03) || string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("请选择供应商");
                return;
            }
            if ( string.IsNullOrEmpty( textBox26.Text ) )
            {
                MessageBox.Show( "规格不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( gridLookUpEdit1.Text ) )
            {
                MessageBox.Show( "物品名称不可为空" );
                return;
            }
            if ( !radioButton10.Checked && !radioButton11.Checked )
            {
                MessageBox.Show( "请选择库存或者外购" );
                return;
            }

            getSet( );

            if ( PJ009 == pj9 && PJ089 == gs008 )
            {
                if ( radioButton10.Checked )
                {
                    if ( !string.IsNullOrEmpty( textBox34.Text ) && !string.IsNullOrEmpty( textBox15.Text ) )
                    {
                        if ( Convert.ToDecimal( textBox34.Text ) < Convert.ToDecimal( textBox15.Text ) )
                            MessageBox.Show( "出库数量大于库存数量,请修改出库数量" );
                        else
                        {
                            string str = Math.Round( Convert.ToDecimal( Operation.MultiTwoTAdd( textBox21 ,textBox37 ,comboBox13 ) ) ,4 ).ToString( );
                            if ( !string.IsNullOrEmpty( str ) )
                            {
                                if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox15.Text ) )
                                    MessageBox.Show( "出库数量有误,请核实" );
                                else
                                    edit( );
                            }
                        }
                    }
                }
                else
                {
                    string sx = Math.Round( Convert.ToDecimal( Operation.MultiTwoTAdd( textBox21 ,textBox37 ,comboBox13 ) ) ,4 ).ToString( );
                    if ( !string.IsNullOrEmpty( sx ) && !string.IsNullOrEmpty( textBox35.Text ) )
                    {
                        if ( Convert.ToDecimal( sx ) != Convert.ToDecimal( textBox35.Text ) )
                            MessageBox.Show( "外购数量有误,请核实" );
                        else
                        {
                            if ( Logins.number == "MLL-0001" )
                                edit( );
                            else
                            {
                                if ( !string.IsNullOrEmpty( textBox34.Text ) && textBox34.Text != "0" )
                                    MessageBox.Show( "库存数量不为零,不可以外购" );
                                else
                                    edit( );
                            }
                        }
                    }
                }
            }
            else
            {
                if ( ord == "计划" || string.IsNullOrEmpty( textBox17.Text ) )
                {
                    DataTable plan = SqlHelper.ExecuteDataTable( "SELECT AC03+ISNULL(AC26,0)-(SELECT SUM(AD05+ISNULL(AD20,0)) AD05 FROM R_PQAD  WHERE AC18=AD01) AD05  FROM R_PQAC WHERE AC18=(SELECT MAX(AC18) FROM R_PQAC WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05) GROUP BY AC03,ISNULL(AC26,0),AC18" ,new SqlParameter( "@AC02" ,PJ95 ) ,new SqlParameter( "@AC04" ,PJ009 ) ,new SqlParameter( "@AC05" ,PJ089 ) );
                    if ( plan.Rows.Count > 0 && !string.IsNullOrEmpty( plan.Rows[0]["AD05"].ToString( ) ) && plan.Rows[0]["AD05"].ToString( ) != "0" )
                        //MessageBox.Show( "库存表中已经存在\n\r货号:" + PJ95 + "\n\r物料名称:" + PJ009 + "\n\r规格:" + PJ089 + "\n\r的记录,且入库数量大于出库数量。不允许新建此计划订单" );
                        planOrActual( );
                    else
                        planOrActual( );
                }
                else if ( ord == "实际" || !string.IsNullOrEmpty( textBox17.Text ) )
                {
                    //AND PJ04=@PJ04
                    DataTable dwo = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQS WHERE PJ01=@PJ01 AND PJ09=@PJ09 AND PJ89=@PJ89  AND PJ15=@PJ15" ,new SqlParameter( "@PJ01" ,PJ01 ) ,new SqlParameter( "@PJ09" ,PJ009 ) ,new SqlParameter( "@PJ89" ,PJ089 ) /*,new SqlParameter( "@PJ04" ,PJ04 )*/ ,new SqlParameter( "@PJ15" ,PJ015 ) );
                    if ( dwo.Rows.Count > 0 )
                    {
                        //开过的合同中是否包含此流水(针对可能合批)
                        for ( int k = 0 ; k < dwo.Rows.Count ; k++ )
                        {
                            if ( dwo.Rows[k]["PJ01"].ToString( ).Contains( PJ01 ) || PJ01.Contains( dwo.Rows[k]["PJ01"].ToString( ) ) )
                            {
                                if ( PJ08.Length > 0 && PJ08.Substring( 0 ,8 ) == "MLL-0001" )
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
        //Edit Batch
        SelectAll.NumberEditContract numQuery = new SelectAll.NumberEditContract( );
        private void button16_Click ( object sender ,EventArgs e )
        {
            numQuery.textBox1.Text = textBox21.Text;
            numQuery.StartPosition = FormStartPosition.CenterScreen;
            numQuery.PassDataBetweenForm += new SelectAll.NumberEditContract.PassDataBetweenFormHandler( numQuery_PassDataBetweenForm );
            numQuery.ShowDialog( );

            if ( numQu == "yes" )
            {
                if ( label78.Visible == true )
                    stateOfOdd = "维护批量编辑";
                else
                {
                    if ( adds == "1" )
                        stateOfOdd = "新增批量编辑";
                    else
                        stateOfOdd = "更改批量编辑";
                }
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    model.PJ11 = string.IsNullOrEmpty( gridView1.GetDataRow( i )["PJ11"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["PJ11"].ToString( ) );
                    model.PJ10 = string.IsNullOrEmpty( gridView1.GetDataRow( i )["PJ10"].ToString( ) ) == true ? 0 : Convert.ToInt64( gridView1.GetDataRow( i )["PJ10"].ToString( ) );
                    model.PJ15 = gridView1.GetDataRow( i )["PJ15"].ToString( );
                    model . IDX = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                    if ( model.PJ15 == "外购" )
                    {
                        model.PJ14 = 0;
                        model.PJ97 = Math.Round(Convert.ToDecimal( model.PJ96 * model.PJ11 + model.PJ10) ,0 );
                    }
                    else if ( model.PJ15 == "库存" )
                    {
                        model.PJ14 = Math.Round(Convert.ToDecimal( model.PJ96 * model.PJ11 + model.PJ10) ,0 );
                        model.PJ97 = 0;
                    }
                    else
                    {
                        model.PJ14 = 0;
                        model.PJ97 = 0;
                    }

                    result = bll.UpdateBatch( model ,"R_347" ,"产品塑料、布和其他零配件采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"批量编辑" ,stateOfOdd  );
                    if ( result == false )
                    {
                        MessageBox.Show( "编辑数据失败" );
                        break;
                    }
                    else if ( i == gridView1.RowCount - 1 )
                    {
                        MessageBox.Show( "编辑数据成功" );
                        button13_Click( null ,null );
                    }
                }
            }
        }
        private void numQuery_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            numQu = e.ConTwo;
            model.PJ96 = string.IsNullOrEmpty( e.ConOne ) == true ? 0 : Convert.ToInt64( e.ConOne );
        }
        //刷新
        private void button13_Click ( object sender ,EventArgs e )
        {
            //    if ( adds == "1" )
            //    {
            //        dfg = SqlHelper.ExecuteDataTable( "SELECT idx,PJ09,PJ10,PJ89,PJ11,PJ12,PJ13,PJ14,PJ15,PJ16,PJ17,PJ18,PJ19,PJ20,PJ96,PJ97,PJ100 FROM R_PQS WHERE PJ92=@PJ92 AND PJ09!='' AND PJ09 IS NOT NULL ORDER BY idx DESC" ,new SqlParameter("@PJ92" ,PJ92));
            //        gridControl1.DataSource = dfg;
            //    }
            //    else if ( adds == "2" )
            //    {
            de = SqlHelper . ExecuteDataTable ( "SELECT idx,PJ09,PJ10,PJ89,PJ11,PJ12,PJ13,PJ14,PJ15,PJ16,PJ17,PJ18,PJ19,PJ20,PJ96,PJ97,PJ102,PJ103,PJ105 FROM R_PQS WHERE PJ92=@PJ92 AND PJ09!='' AND PJ09 IS NOT NULL ORDER BY idx DESC" ,new SqlParameter ( "@PJ92" ,model . PJ92 ) );
            gridControl1 . DataSource = de;
            gridView1 . BestFitColumns ( );
            //every ( );
            //}
        }
        //实际收货时间
        yanpinSelect ys = new yanpinSelect( );
        private void button14_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox.Show( "流水号:" + PJ01 + "\n\r物料名称:" + gridLookUpEdit1.Text + "\n\r部件规格:" + textBox26.Text + "\n\r已经到货？" ,"提示" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
            {
                ys.ysOne = model.PJ92;
                ys.ysTwo = gridLookUpEdit1.Text;
                ys.ysThr = textBox26.Text;
                ys.ysFou = "";
                ys.ysFiv = "";
                ys.ysSix = "R_347";
                ys.StartPosition = FormStartPosition.CenterScreen;
                ys.ShowDialog( );
            }
        }
        #endregion

    }
}
