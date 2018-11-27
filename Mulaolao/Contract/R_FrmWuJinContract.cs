using Mulaolao.Bom;
using Mulaolao.Class;
using Mulaolao.Raw_material_cost;
using StudentMgr;
using System;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using FastReport;
using FastReport.Export.Xml;
using Mulaolao.Schedule_control;
using Mulaolao.Other;
using Mulaolao.Contract.yesOrNoPlan;
using System.Text;
using System.Collections.Generic;

namespace Mulaolao.Contract
{
    public partial class R_FrmWuJinContract : FormChild
    {
        public R_FrmWuJinContract (/*Form1 fm */)
        {
            //this.MdiParent = fm;
            InitializeComponent( );

            Logins . tableNum = "R_343";
            Logins . tableName = this . Text;

            GridViewMoHuSelect . SetFilter ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,View } );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . gridView1 ,this . View } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.WuJinContractLibrary model = new MulaolaoLibrary.WuJinContractLibrary( );
        MulaolaoBll.Bll.WuJincontractBll bll = new MulaolaoBll.Bll.WuJincontractBll( );
        Report report = new Report( );
        DataSet RDataSet;
        Factory fc = new Factory( );
        SpecialPowers sp = new SpecialPowers( );
        yesOrNoPlanActual pc = new yesOrNoPlanActual( );
        //Dictionary<string ,string> dicStr = new Dictionary<string ,string>( );
        string copy = "", file = "", numQu = "", stateOfOdd = "", conOne = "";
        DataTable wpmc, biao, name, libraryTable,partable;
        List<SplitContainer> spList = new List<SplitContainer>( ); List<TabPage> pageList = new List<TabPage>( );
        List<string> speList = new List<string>( );
        
        private void R_FrmsiyeyiyinContract_Load ( object sender ,EventArgs e )
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


            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;

            textBox4.Enabled = false;
            label3.Visible = false;
            label98.Visible = false;

            name = bll.GetDataTablePerson( );
            lookUpEdit1.Properties.DataSource = name;
            lookUpEdit1.Properties.DisplayMember = "DBA002";
            lookUpEdit1.Properties.ValueMember = "DBA001";

            lookUpEdit2.Properties.DataSource = bll.GetDataTableWork( );
            lookUpEdit2.Properties.DisplayMember = "DBA002";
            lookUpEdit2.Properties.ValueMember = "DBA001";

            #region
            DataTable dl = SqlHelper.ExecuteDataTable( "SELECT PQU30,PQU45,PQU47,PQU74 FROM R_PQU" );
            //甲方质检部签名
            comboBox16.DataSource = dl.DefaultView.ToTable( true ,"PQU30" );
            comboBox16.DisplayMember = "PQU30";
            //检验人
            comboBox17.DataSource = dl.DefaultView.ToTable( true ,"PQU45" );
            comboBox17.DisplayMember = "PQU45";
            //甲方生产部
            comboBox18.DataSource = dl.DefaultView.ToTable( true ,"PQU47" );
            comboBox18.DisplayMember = "PQU47";
            //ICQ签名
            comboBox5.DataSource = dl.DefaultView.ToTable( true ,"PQU74" );
            comboBox5.DisplayMember = "PQU74";
            #endregion

            if ( Logins.number == "MLL-0001" )
                checkBox15.Visible = true;
            else
                checkBox15.Visible = false;
        }

        private void R_FrmWuJinContract_Shown ( object sender ,EventArgs e )
        {
            PQU97 = Merges.oddNum;
            if ( !string.IsNullOrEmpty( PQU97 ) )
                autoQuery( );
            Merges.oddNum = "";
        }

        #region 打印  导出
        private void CreateDataset ( )
        {
            RDataSet = new DataSet( );

            DataTable print = SqlHelper.ExecuteDataTable( "SELECT PQU10,PQU11,PQU12,PQU19,PQU101, PQU21, PQU13, PQU14,CONVERT( DECIMAL( 11, 1 ), PQU16 * PQU13) U0,PQU20, PQU15, PQU16,CONVERT( BIGINT, PQU101 * PQU13+PQU14 ) U1,PQU16 * (PQU101 * PQU13+PQU14)-PQU17 U2,PQU17,CONVERT( VARCHAR( 20 ), PQU22, 102 ) PQU22,CONVERT( VARCHAR( 20 ), PQU23, 102 ) PQU23 FROM R_PQU WHERE PQU10!='' AND PQU97 =@PQU97" ,new SqlParameter( "@PQU97" ,PQU97 ) );
            DataTable prints = SqlHelper.ExecuteDataTable( "SELECT DBA002,DBA028,DGA003,DGA017,DGA008,DGA009,DGA011,PQU05,CONVERT(VARCHAR(20),PQU06,102) PQU06,PQU07,CONVERT(VARCHAR(20),PQU08,102) PQU08,PQU09,PQU98,PQU99,PQU100,PQU01,PQU24,PQU25,PQU26,PQU27,PQU28,PQU29,PQU30,CONVERT( VARCHAR( 20 ),PQU31,102) PQU31,CASE WHEN PQU32='F' AND PQU33='F' AND PQU34='F' AND PQU35='F' THEN 'F' WHEN PQU32='T' OR PQU33='T' OR PQU34='T' OR PQU35='T' THEN 'T' END U0,PQU32, PQU33, PQU34, PQU35, PQU36, PQU37, PQU38, PQU40, PQU41, PQU42, PQU43, PQU45, CONVERT( VARCHAR( 20 ), PQU46, 102 ) PQU46, PQU47, CONVERT( VARCHAR( 20 ), PQU48, 102 ) PQU48, PQU49, PQU50, PQU51, PQU57, PQU52, PQU53, PQU54,PQU58, PQU55, PQU56, PQU59, PQU65, PQU61, PQU62, PQU63, PQU64, PQU60, PQU66, PQU67, PQU68, PQU69, PQU70, CONVERT( VARCHAR( 20 ), PQU71, 102 ) PQU71, PQU72, PQU73, PQU74, CONVERT( VARCHAR( 20 ), PQU75, 102 ) PQU75, PQU76, PQU77, PQU78,PQU79, PQU80, PQU81, PQU82, PQU83, PQU84, PQU85, PQU86, PQU87, PQU88, CONVERT( VARCHAR( 20 ), PQU89, 102 ) PQU89, PQU90, CONVERT( VARCHAR( 20 ), PQU91, 102 ) PQU91, PQU92, CONVERT( VARCHAR( 20 ), PQU93, 102 ) PQU93, CONVERT( VARCHAR( 20 ), PQU94, 102 ) PQU94,PQU108,PQU97,CASE WHEN PQU01='' THEN 'F' WHEN PQU01!='' THEN CASE WHEN PQU19='库存' THEN 'T' ELSE '1' END END PQU,ISNULL(PQU107,'F') PQU107 FROM R_PQU A, TPADBA B, TPADGA C WHERE A.PQU02 = B.DBA001 AND A.PQU03 = C.DGA001 AND PQU97=@PQU97" , new SqlParameter( "@PQU97" ,PQU97 ) );
            print.TableName = "R_PQU";
            prints.TableName = "R_PQUS";
            RDataSet.Tables.Add( print );
            RDataSet.Tables.Add( prints );
        }
        #endregion

        #region 查询
        void queryContent ( )
        {
            //comboBox15_SelectedValueChanged( null ,null );

            DataTable de = SqlHelper.ExecuteDataTable( "SELECT TOP 1 * ,(SELECT DBA002 FROM TPADBA WHERE PQU02=DBA001) DBA002 FROM R_PQU WHERE PQU97=@PQU97" ,new SqlParameter( "@PQU97" ,PQU97 ) );
            if ( de.Rows.Count > 0 )
            {
                lookUpEdit1.Text = de.Rows[0]["DBA002"].ToString( );

                #region
                PQU03 = de . Rows [ 0 ] [ "PQU03" ] . ToString ( );
                textBox2 .Text = de.Rows[0]["PQU03"].ToString( );
                comboBox4.Text = de.Rows[0]["PQU98"].ToString( );
                textBox50.Text = de.Rows[0]["PQU99"].ToString( );
                textBox49.Text = de.Rows[0]["PQU01"].ToString( );
                comboBox6.Text = de.Rows[0]["PQU100"].ToString( );
                textBox53.Text = de.Rows[0]["PQU101"].ToString( );
                lookUpEdit2.Text = de.Rows[0]["PQU108"].ToString( );
                if ( de . Rows [ 0 ] [ "PQU04" ] . ToString ( ) != "" )
                    dateTimePicker14 . Value = Convert . ToDateTime ( de . Rows [ 0 ] [ "PQU04" ] );
                else
                    dateTimePicker14 . Value = DateTime . Now;
                textBox17.Text = de.Rows[0]["PQU05"].ToString( );
                if ( de.Rows[0]["PQU06"].ToString( ) != "" )
                    dateTimePicker1.Value = Convert.ToDateTime( de.Rows[0]["PQU06"] );
                else
                    dateTimePicker1 . Value = DateTime . Now;
                textBox13 .Text = de.Rows[0]["PQU07"].ToString( );
                if ( de.Rows[0]["PQU08"].ToString( ) != "" )
                    dateTimePicker2.Value = Convert.ToDateTime( de.Rows[0]["PQU08"] );
                else
                    dateTimePicker2 . Value = DateTime . Now;
                textBox16 .Text = de.Rows[0]["PQU09"].ToString( );
                textBox15.Text = de.Rows[0]["PQU24"].ToString( );
                textBox18.Text = de.Rows[0]["PQU25"].ToString( );
                if ( de.Rows[0]["PQU26"].ToString( ).Trim( ) == "T" )
                    checkBox36.Checked = true;
                else
                    checkBox36.Checked = false;
                if ( de.Rows[0]["PQU27"].ToString( ).Trim( ) == "T" )
                    checkBox38.Checked = true;
                else
                    checkBox38.Checked = false;
                if ( de.Rows[0]["PQU28"].ToString( ).Trim( ) == "T" )
                    checkBox39.Checked = true;
                else
                    checkBox39.Checked = false;
                if ( de.Rows[0]["PQU29"].ToString( ).Trim( ) == "T" )
                    checkBox40.Checked = true;
                else
                    checkBox40.Checked = false;
                comboBox16.Text = de.Rows[0]["PQU30"].ToString( );
                if ( de.Rows[0]["PQU31"].ToString( ) != "" )
                    dateTimePicker5.Value = Convert.ToDateTime( de.Rows[0]["PQU31"] );
                else
                    dateTimePicker5 . Value = DateTime . Now;
                if ( de.Rows[0]["PQU32"].ToString( ).Trim( ) == "T" )
                    checkBox4.Checked = true;
                else
                    checkBox4.Checked = false;
                if ( de.Rows[0]["PQU33"].ToString( ).Trim( ) == "T" )
                    checkBox7.Checked = true;
                else
                    checkBox7.Checked = false;
                if ( de.Rows[0]["PQU34"].ToString( ).Trim( ) == "T" )
                    checkBox5.Checked = true;
                else
                    checkBox5.Checked = false;
                if ( de.Rows[0]["PQU35"].ToString( ).Trim( ) == "T" )
                    checkBox6.Checked = true;
                else
                    checkBox6.Checked = false;
                if ( de.Rows[0]["PQU36"].ToString( ).Trim( ) == "T" )
                    checkBox1.Checked = true;
                else
                    checkBox1.Checked = false;
                if ( de.Rows[0]["PQU37"].ToString( ).Trim( ) == "T" )
                    checkBox2.Checked = true;
                else
                    checkBox2.Checked = false;
                if ( de.Rows[0]["PQU38"].ToString( ).Trim( ) == "T" )
                    checkBox3.Checked = true;
                else
                    checkBox3.Checked = false;
                if ( de.Rows[0]["PQU39"].ToString( ).Trim( ) == "T" )
                    checkBox8.Checked = true;
                else
                    checkBox8.Checked = false;
                if ( de.Rows[0]["PQU40"].ToString( ).Trim( ) == "T" )
                    checkBox9.Checked = true;
                else
                    checkBox9.Checked = false;
                if ( de.Rows[0]["PQU41"].ToString( ).Trim( ) == "T" )
                    checkBox10.Checked = true;
                else
                    checkBox10.Checked = false;
                if ( de.Rows[0]["PQU42"].ToString( ).Trim( ) == "T" )
                    checkBox41.Checked = true;
                else
                    checkBox41.Checked = false;
                textBox26.Text = de.Rows[0]["PQU43"].ToString( );
                textBox1.Text = de.Rows[0]["PQU44"].ToString( );
                comboBox17.Text = de.Rows[0]["PQU45"].ToString( );
                if ( de.Rows[0]["PQU46"].ToString( ) != "" )
                    dateTimePicker6.Value = Convert.ToDateTime( de.Rows[0]["PQU46"].ToString( ) );
                else
                    dateTimePicker6 . Value = DateTime . Now;
                comboBox18 .Text = de.Rows[0]["PQU47"].ToString( );
                if ( de.Rows[0]["PQU48"].ToString( ) != "" )
                    dateTimePicker7.Value = Convert.ToDateTime( de.Rows[0]["PQU48"].ToString( ) );
                else
                    dateTimePicker7 . Value = DateTime . Now;
                if ( de.Rows[0]["PQU49"].ToString( ).Trim( ) == "T" )
                    checkBox11.Checked = true;
                else
                    checkBox11.Checked = false;
                if ( de.Rows[0]["PQU50"].ToString( ).Trim( ) == "T" )
                    checkBox12.Checked = true;
                else
                    checkBox12.Checked = false;
                if ( de.Rows[0]["PQU51"].ToString( ).Trim( ) == "T" )
                    checkBox13.Checked = true;
                else
                    checkBox13.Checked = false;
                if ( de.Rows[0]["PQU52"].ToString( ).Trim( ) == "T" )
                    checkBox14.Checked = true;
                else
                    checkBox14.Checked = false;
                if ( de.Rows[0]["PQU53"].ToString( ).Trim( ) == "T" )
                    checkBox17.Checked = true;
                else
                    checkBox17.Checked = false;
                if ( de.Rows[0]["PQU54"].ToString( ).Trim( ) == "T" )
                    checkBox21.Checked = true;
                else
                    checkBox21.Checked = false;
                if ( de.Rows[0]["PQU55"].ToString( ).Trim( ) == "T" )
                    checkBox26.Checked = true;
                else
                    checkBox26.Checked = false;
                if ( de.Rows[0]["PQU56"].ToString( ).Trim( ) == "T" )
                    checkBox27.Checked = true;
                else
                    checkBox27.Checked = false;
                if ( de.Rows[0]["PQU57"].ToString( ).Trim( ) == "T" )
                    checkBox19.Checked = true;
                else
                    checkBox19.Checked = false;
                if ( de.Rows[0]["PQU58"].ToString( ).Trim( ) == "T" )
                    checkBox24.Checked = true;
                else
                    checkBox24.Checked = false;
                if ( de.Rows[0]["PQU59"].ToString( ).Trim( ) == "T" )
                    checkBox30.Checked = true;
                else
                    checkBox30.Checked = false;
                if ( de.Rows[0]["PQU60"].ToString( ).Trim( ) == "T" )
                    checkBox33.Checked = true;
                else
                    checkBox33.Checked = false;
                if ( de.Rows[0]["PQU61"].ToString( ).Trim( ) == "T" )
                    checkBox35.Checked = true;
                else
                    checkBox35.Checked = false;
                if ( de.Rows[0]["PQU62"].ToString( ).Trim( ) == "T" )
                    checkBox32.Checked = true;
                else
                    checkBox32.Checked = false;
                if ( de.Rows[0]["PQU63"].ToString( ).Trim( ) == "T" )
                    checkBox31.Checked = true;
                else
                    checkBox31.Checked = false;
                if ( de.Rows[0]["PQU64"].ToString( ).Trim( ) == "T" )
                    checkBox34.Checked = true;
                else
                    checkBox34.Checked = false;
                textBox30.Text = de.Rows[0]["PQU65"].ToString( );
                if ( de.Rows[0]["PQU66"].ToString( ) == radioButton1.Text )
                    radioButton1.Checked = true;
                else if ( de.Rows[0]["PQU66"].ToString( ) == radioButton2.Text )
                    radioButton2.Checked = true;
                if ( de.Rows[0]["PQU67"].ToString( ) == radioButton3.Text )
                    radioButton3.Checked = true;
                else if ( de.Rows[0]["PQU67"].ToString( ) == radioButton4.Text )
                    radioButton4.Checked = true;
                if ( de.Rows[0]["PQU68"].ToString( ) == radioButton6.Text )
                {
                    radioButton6.Checked = true;
                    textBox24.Text = de.Rows[0]["PQU69"].ToString( );
                }
                else if ( de.Rows[0]["PQU68"].ToString( ) == radioButton5.Text )
                    radioButton5.Checked = true;
                textBox31.Text = de.Rows[0]["PQU70"].ToString( );
                if ( de.Rows[0]["PQU71"].ToString( ) != "" )
                    dateTimePicker8.Value = Convert.ToDateTime( de.Rows[0]["PQU71"].ToString( ) );
                else
                    dateTimePicker8 . Value = DateTime . Now;
                textBox33 .Text = de.Rows[0]["PQU72"].ToString( );
                if ( de.Rows[0]["PQU73"].ToString( ) == radioButton7.Text )
                    radioButton7.Checked = true;
                else if ( de.Rows[0]["PQU73"].ToString( ) == radioButton8.Text )
                    radioButton8.Checked = true;
                else if ( de.Rows[0]["PQU73"].ToString( ) == radioButton9.Text )
                {
                    radioButton9.Checked = true;
                    textBox35.Text = de.Rows[0]["PQU76"].ToString( );
                }
                comboBox5.Text = de.Rows[0]["PQU74"].ToString( );
                if ( de.Rows[0]["PQU75"].ToString( ) != "" )
                    dateTimePicker9.Value = Convert.ToDateTime( de.Rows[0]["PQU75"].ToString( ) );
                else
                    dateTimePicker9 . Value = DateTime . Now;
                textBox36 .Text = de.Rows[0]["PQU77"].ToString( );
                textBox37.Text = de.Rows[0]["PQU78"].ToString( );
                textBox38.Text = de.Rows[0]["PQU79"].ToString( );
                textBox39.Text = de.Rows[0]["PQU80"].ToString( );
                textBox40.Text = de.Rows[0]["PQU81"].ToString( );
                textBox41.Text = de.Rows[0]["PQU82"].ToString( );
                textBox42.Text = de.Rows[0]["PQU83"].ToString( );
                textBox43.Text = de.Rows[0]["PQU84"].ToString( );
                textBox44.Text = de.Rows[0]["PQU85"].ToString( );
                textBox12.Text = de.Rows[0]["PQU86"].ToString( );
                textBox45.Text = de.Rows[0]["PQU87"].ToString( );
                textBox46.Text = de.Rows[0]["PQU88"].ToString( );
                if ( de.Rows[0]["PQU89"].ToString( ) != "" )
                    dateTimePicker10.Value = Convert.ToDateTime( de.Rows[0]["PQU89"].ToString( ) );
                else
                    dateTimePicker10 . Value = DateTime . Now;
                textBox47 .Text = de.Rows[0]["PQU90"].ToString( );
                if ( de.Rows[0]["PQU91"].ToString( ) != "" )
                    dateTimePicker11.Value = Convert.ToDateTime( de.Rows[0]["PQU91"].ToString( ) );
                else
                    dateTimePicker11 . Value = DateTime . Now;
                textBox48 .Text = de.Rows[0]["PQU92"].ToString( );
                if ( de.Rows[0]["PQU93"].ToString( ) != "" )
                    dateTimePicker12.Value = Convert.ToDateTime( de.Rows[0]["PQU93"].ToString( ) );
                else
                    dateTimePicker12 . Value = DateTime . Now;
                if ( de.Rows[0]["PQU94"].ToString( ) != "" )
                    dateTimePicker13.Value = Convert.ToDateTime( de.Rows[0]["PQU94"].ToString( ) );
                else
                    dateTimePicker13 . Value = DateTime . Now;
                textBox4 .Text = de.Rows[0]["PQU95"].ToString( );
                if ( de.Rows[0]["PQU106"].ToString( ).Trim( ) == "复制" )
                    label98.Visible = true;
                else
                    label98.Visible = false;
                checkBox15.Checked = de.Rows[0]["PQU107"].ToString( ).Trim( ) == "T" ? true : false;
                checkBox16.Checked = de.Rows[0]["PQU112"].ToString( ).Trim( ) == "T" ? true : false;
                #endregion
                //,PQU107
                dl = SqlHelper.ExecuteDataTable( "SELECT idx,PQU10,PQU101,PQU11,PQU12,PQU13,PQU14,PQU15,PQU16,PQU17,PQU18,PQU19,PQU20,PQU21,PQU22,PQU23,PQU104,PQU109,PQU110 FROM R_PQU WHERE PQU97=@PQU97 ORDER BY idx DESC" ,new SqlParameter( "@PQU97" ,PQU97 ) );
                gridControl1.DataSource = dl;
            }
        }
        void autoQuery ( )
        {
            Ergodic.SpliClear( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolReview.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
            textBox4.Enabled = false;
            sav = "2";
            ord = "";

            queryContent( );
        }
        DataTable dl;
        SelectAll.WuJinContractQueryAll query = new SelectAll.WuJinContractQueryAll( );
        //查询
        protected override void select ( )
        {
            base.select( );

            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.WuJinContractQueryAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );

            if ( PQU97 == "" )
                MessageBox.Show( "您没有选择任何内容" );
            else
                autoQuery( );
        }
        private void query_PassDataBetweenForm ( Object sender ,PassDataWinFormEventArgs e )
        {
            PQU01 = e.ConTre;
            //textBox49.Text = e.ConTre;
            PQU98 = e.ConOne;
            //comboBox4.Text = e.ConOne;
            PQU99 = e.ConTwo;
            //textBox50.Text = e.ConTwo;
            //PQU02 = e.ConFor;
            //lookUpEdit1.Text = e.ConFiv;
            PQU03 = e.ConSix;
            //textBox2.Text = e.ConSev;
            if ( e.ConEgi == "执行" )
                label3.Visible = true;
            else
                label3.Visible = false;
            PQU97 = e.ConNin;
            PQU100 = e.ConTen;
            //comboBox6.Text = e.ConTen;
            if ( e.ConEleven == "" )
                PQU0101 = 0;
            else
                PQU0101 = Convert.ToInt64( e.ConEleven );
            //textBox53.Text = e.ConEleven;
        }
        R_FrmTPADGA tpadga = new R_FrmTPADGA( );
        //供应商查询
        private void button4_Click ( object sender ,EventArgs e )
        {
            DataTable did = SqlHelper.ExecuteDataTable( "SELECT DGA001,DGA003,DGA008,DGA011,DGA017,DGA009 FROM TPADGA WHERE DGA052='F'" );
            if ( did.Rows.Count < 1 )
                MessageBox.Show( "没有供应商信息" );
            else
            {
                tpadga.gridControl2.DataSource = did;
                tpadga.st = "4";
                tpadga.Text = "R_343 信息查询";
                tpadga.PassDataBetweenForm += new R_FrmTPADGA.PassDataBetweenFomrHandler( tpadga_PassDataBetweenForm );
                tpadga.StartPosition = FormStartPosition.CenterScreen;
                tpadga.ShowDialog( );
            }
        }
        private void tpadga_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            PQU03 = e.ConOne;
            textBox2 . Tag = e . ConOne;
            textBox2.Text = e.ConTwo;
            textBox7.Text = e.ConSix;
            textBox8.Text = e.ConTre;
            textBox10.Text = e.ConFor;
            textBox6.Text = e.ConFiv;
        }
        //流水号
        Youqicaigou yq = new Youqicaigou( );
        private void button5_Click ( object sender ,EventArgs e )
        {
            DataTable dhr = SqlHelper.ExecuteDataTable( "SELECT PQF01,PQF02,PQF03,PQF04,PQF06,PQF07,PQF08 FROM R_PQF A,R_REVIEWS B,R_MLLCXMC C WHERE A.PQF01 = B.RES06 AND B.RES01 = C.CX01 AND C.CX02 = '订单销售合同(R_001)' AND RES05 = '执行' ORDER BY PQF01 DESC" );
            if ( dhr.Rows.Count < 1 )
                MessageBox.Show( "没有产品信息" );
            else
            {
                dhr.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
                yq.gridControl1.DataSource = dhr;
                yq.sy = "5";
                yq.Text = "R_343 信息查询";
                yq.PassDataBetweenForm += new Youqicaigou.PassDataBetweenFormHandler( yq_PassDataBetweenForm );
                yq.StartPosition = FormStartPosition.CenterScreen;
                yq.ShowDialog( );
            }
        }
        private void yq_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            if ( e.ConOne.IndexOf( "," ) > 0 )
                textBox49.Text = string.Join( "," ,e.ConOne.Split( ',' ).Distinct( ).ToArray( ) );
            else
                textBox49.Text = e.ConOne;
            PQU01 = textBox49.Text;
            if ( e.ConTwo.IndexOf( "," ) > 0 )
                textBox50.Text = string.Join( "," ,e.ConTwo.Split( ',' ).Distinct( ).ToArray( ) );
            else
                textBox50.Text = e.ConTwo;
            PQU99 = textBox50.Text;
            if ( e.ConTre.IndexOf( "," ) > 0 )
                comboBox6.Text = string.Join( "," ,e.ConTre.Split( ',' ).Distinct( ).ToArray( ) );
            else
                comboBox6.Text = e.ConTre;
            PQU100 = comboBox6.Text;
            if ( e.ConFor.IndexOf( "," ) > 0 )
                comboBox4.Text = string.Join( "," ,e.ConFor.Split( ',' ).Distinct( ).ToArray( ) );
            else
                comboBox4.Text = e.ConFor;
            PQU98 = comboBox4.Text;
            textBox53.Text = e.ConFiv;
            if ( e.ConFiv == "" )
                PQU0101 = 0;
            else
                PQU0101 = Convert.ToInt64( e.ConFiv );
            if ( e.ConSix.IndexOf( "," ) > 0 )
                textBox15.Text = string.Join( "," ,e.ConSix.Split( ',' ).Distinct( ).ToArray( ) );
            else
                textBox15.Text = e.ConSix;
            PQU24 = textBox15.Text;
            if ( e.ConSev.IndexOf( "," ) > 0 )
                textBox18.Text = string.Join( "," ,e.ConSev.Split( ',' ).Distinct( ).ToArray( ) );
            else
                textBox18.Text = e.ConSev;
            PQU25 = textBox18.Text;
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
            textBox49.Text = "";
            PQU98 = e.ConOne;
            comboBox4.Text = e.ConOne;
            PQU100 = e.ConTwo;
            comboBox6.Text = e.ConTwo;
            if ( !string.IsNullOrEmpty( e.ConTre ) )
                PQU0101 = Convert.ToInt64( e.ConTre );
            else
                PQU0101 = 0;
            textBox53.Text = e.ConTre;
            textBox50.Text = "";
        }
        //物品名称
        R_FrmPQP pqp = new R_FrmPQP( );
        private void button6_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( PQU01 ) )
                MessageBox.Show( "流水号不可为空" );
            else
            {
                DataTable wl = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS07,GS08,GS10,GS09 FROM R_PQP A,R_REVIEWS B,R_MLLCXMC C WHERE A.GS34=B.RES06 AND B.RES01=C.CX01 AND RES05='执行' AND CX02='产品每套成本改善控制表(R_509)' AND GS07 IS NOT NULL AND GS07!='' AND GS01=@GS01" ,new SqlParameter( "@GS01" ,PQU01 ) );
                if ( wl.Rows.Count < 1 )
                    MessageBox.Show( "[产品每套成本改善控制表(R_509)]没有已经执行的信息,请录入或送审操作" );
                else
                {
                    wl.Columns.Add( "check" ,System.Type.GetType( "System.Boolean" ) );
                    pqp.gridControl1.DataSource = wl;
                    pqp.pqstr = "3";
                    pqp.Text = "R_343 信息查询";
                    pqp.PassDataBetweenForm += new R_FrmPQP.PassDataBetweenFormHandler( pqp_PassDataBetweenForm );
                    pqp.StartPosition = FormStartPosition.CenterScreen;
                    pqp.ShowDialog( );
                }
            }
        }
        private void pqp_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            PQU010 = e.ConOne;
            gridLookUpEdit1.Text = e.ConOne;
            PQU012 = e.ConTwo;
            textBox14.Text = e.ConTwo;
            textBox21.Text = e.ConTre;
            PQU021 = e.ConFor;
            comboBox10.Text = e.ConFor;
        }
        #endregion

        #region 事件
        //货号
        private void comboBox6_TextChanged ( object sender ,EventArgs e )
        {
            
            every( );
            previousOfPrice( );
        }
        void every ( )
        {
            PQU100 = comboBox6 . Text;
            if ( !string . IsNullOrEmpty ( textBox49 . Text ) )
            {
                PQU01 = textBox49 . Text;

                wpmc = SqlHelper . ExecuteDataTable ( "SELECT DISTINCT GS07 PQU10,GS08 PQU12,GS10 PQU13,GS09 PQU21 FROM R_PQP WHERE GS07 IS NOT NULL AND GS07!='' AND GS70='R_343' AND GS01=@GS01" ,new SqlParameter ( "@GS01" ,PQU01 ) );
            //else
            //{
                
                //wpmc = SqlHelper . ExecuteDataTable ( "SELECT DISTINCT GS07 PQU10,GS08 PQU12,GS10 PQU13,GS09 PQU21 FROM R_PQP WHERE GS07 IS NOT NULL AND GS07!='' AND GS01=@GS01" ,new SqlParameter ( "@GS01" ,PQU01 ) );
                biao = SqlHelper . ExecuteDataTable ( "SELECT '' PQU10,PQU11,'' PQU12,0.0 PQU13,PQU14,PQU15,PQU16,PQU17,PQU18,PQU19,PQU20,'' PQU21,PQU22,PQU23 FROM R_PQU WHERE PQU01=@PQU01" ,new SqlParameter ( "@PQU01" ,PQU01 ) );
            }

            if ( string.IsNullOrEmpty( textBox49.Text ) )
                biao = SqlHelper.ExecuteDataTable( "SELECT PQU10,PQU11,PQU12,PQU13,PQU14,PQU15,PQU16,PQU17,PQU18,PQU19,PQU20,PQU21,PQU22,PQU23 FROM R_PQU WHERE PQU100=@PQU100" ,new SqlParameter( "@PQU100" ,PQU100 ) );
            //else
            //{
            //    PQU01 = textBox49.Text;
            //    biao = SqlHelper.ExecuteDataTable( "SELECT PQU10,PQU11,PQU12,PQU13,PQU14,PQU15,PQU16,PQU17,PQU18,PQU19,PQU20,PQU21,PQU22,PQU23 FROM R_PQU WHERE PQU01=@PQU01" ,new SqlParameter( "@PQU01" ,PQU01 ) );
            //}
            if ( wpmc != null )
                biao.Merge( wpmc );


            partable = biao . DefaultView . ToTable ( true ,"PQU10" ,"PQU12" ,"PQU13" );
            gridLookUpEdit1 . Properties . DataSource = partable;
            gridLookUpEdit1 . Properties . DisplayMember = "PQU10";
            gridLookUpEdit1 . Properties . ValueMember = "PQU10";

            //textBox14 .DataSource = biao.DefaultView.ToTable( true ,"PQU12" );
            //textBox14.DisplayMember = "PQU12";
            //textBox21.DataSource = biao.DefaultView.ToTable( true ,"PQU13" );
            //textBox21.DisplayMember = "PQU13";

            comboBox10.DataSource = biao.DefaultView.ToTable( true ,"PQU21" );
            comboBox10.DisplayMember = "PQU21";
            //色号.按色号与色板间
            comboBox14.DataSource = biao.DefaultView.ToTable( true ,"PQU11" );
            comboBox14.DisplayMember = "PQU11";
            //丝.热.移印/色价数
            comboBox3.DataSource = biao.DefaultView.ToTable( true ,"PQU14" );
            comboBox3.DisplayMember = "PQU14";
            //现价
            comboBox7.DataSource = biao.DefaultView.ToTable( true ,"PQU16" );
            comboBox7.DisplayMember = "PQU16";
            //滚漆材质
            comboBox12.DataSource = biao.DefaultView.ToTable( true ,"PQU20" );
            comboBox12.DisplayMember = "PQU20";
            //预付款
            comboBox8.DataSource = biao.DefaultView.ToTable( true ,"PQU17" );
            comboBox8.DisplayMember = "PQU17";
        }
        void previousOfPrice ( )
        {
            if ( string.IsNullOrEmpty( comboBox6.Text ) || string.IsNullOrEmpty( gridLookUpEdit1.Text ) )
                textBox11.Text = "0";
            else
            {
                DataTable dm = bll.GetDataTableOfPrice( comboBox6.Text ,gridLookUpEdit1.Text );
                if ( dm != null && dm.Rows.Count > 0 )
                    textBox11.Text = dm.Rows[0]["PQU16"].ToString( );
                else
                    textBox11.Text = "0";
            }
        }
        private void gridLookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = View . GetFocusedDataRow ( );
            if ( row == null )
                return;
            textBox14 . Text = row [ "PQU12" ] . ToString ( );
            textBox21 . Text = row [ "PQU13" ] . ToString ( );
        }
        private void comboBox2_SelectedValueChanged ( object sender ,EventArgs e )
        {
            if ( !string.IsNullOrEmpty( gridLookUpEdit1.Text ) && biao.Select( "PQU10='" + gridLookUpEdit1.Text + "'" ).Length > 0 )
            {
                textBox14.Text = biao.Select( "PQU10='" + gridLookUpEdit1.Text + "'" )[0]["PQU12"].ToString( );
                textBox21.Text = biao.Select( "PQU10='" + gridLookUpEdit1.Text + "'" )[0]["PQU13"].ToString( );
                comboBox10.Text = biao.Select( "PQU10='" + gridLookUpEdit1.Text + "'" )[0]["PQU21"].ToString( );
                comboBox14.Text = biao.Select( "PQU10='" + gridLookUpEdit1.Text + "'" )[0]["PQU11"].ToString( );
                comboBox3.Text = biao.Select( "PQU10='" + gridLookUpEdit1.Text + "'" )[0]["PQU14"].ToString( );
                textBox11.Text = biao.Select( "PQU10='" + gridLookUpEdit1.Text + "'" )[0]["PQU15"].ToString( );
                comboBox7.Text = biao.Select( "PQU10='" + gridLookUpEdit1.Text + "'" )[0]["PQU16"].ToString( );
                comboBox12.Text = biao.Select( "PQU10='" + gridLookUpEdit1.Text + "'" )[0]["PQU20"].ToString( );
                comboBox8.Text = biao.Select( "PQU10='" + gridLookUpEdit1.Text + "'" )[0]["PQU17"].ToString( );
            }

            previousOfPrice( );
        }
        //成本员
        private void button8_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox13.Text ) )
                textBox13.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox13.Text ) && textBox13.Text == Logins.username )
                textBox13.Text = "";

            dateTimePicker2 . Value = DateTime . Now;
        }
        //开合同人
        private void button7_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox17.Text ) )
            {
                textBox17.Text = Logins.username;
                PQU05 = textBox17.Text;

                string[] str = new string[2];
                str = oddNumbers.contractBatch( "R_PQU" ,PQU05 ,textBox17 ,textBox16 ,"PQU09" );
                if ( str[0] == "" )
                    textBox17.Text = "";
                else
                    PQU09 = str[1];
                textBox16.Text = str[1];
            }
            else if ( !string.IsNullOrEmpty( textBox17.Text ) && textBox17.Text == Logins.username )
            {
                textBox17.Text = "";
                PQU05 = textBox17.Text;
                PQU09 = "";
                textBox16.Text = "";
            }
            if ( string.IsNullOrEmpty( textBox45.Text ) )
                textBox45.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox45.Text ) && textBox45.Text == Logins.username )
                textBox45.Text = "";

            dateTimePicker1 . Value = DateTime . Now;
        }
        //甲方代表
        private void button9_Click ( object sender ,EventArgs e )
        {

        }
        //乙方代表
        private void button10_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox46.Text ) )
                textBox46.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox46.Text ) && textBox46.Text == Logins.username )
                textBox46.Text = "";
            dateTimePicker10.Value = MulaolaoBll . Drity . GetDt ( );
        }
        //复核人
        private void button11_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox47.Text ) )
                textBox47.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox47.Text ) && textBox47.Text == Logins.username )
                textBox47.Text = "";
            dateTimePicker11.Value = MulaolaoBll . Drity . GetDt ( );
        }
        //审批人
        private void button12_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox48.Text ) )
                textBox48.Text = Logins.username;
            else if ( !string.IsNullOrEmpty( textBox48.Text ) && textBox48.Text == Logins.username )
                textBox48.Text = "";
            dateTimePicker12.Value = MulaolaoBll . Drity . GetDt ( );
        }
        //采购人
        private void lookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit1.EditValue != null )
            {
                PQU02 = lookUpEdit1.EditValue.ToString( );
                textBox5.Text = name.Select( "DBA001='" + PQU02 + "'" )[0]["DBA028"].ToString( );
            }
        }
        //供应商
        private void textBox2_TextChanged ( object sender ,EventArgs e )
        {
            DataTable del = SqlHelper . ExecuteDataTable ( "SELECT DGA001,DGA003,DGA008,DGA011,DGA017,DGA009,DGA012 FROM TPADGA WHERE DGA001=@DGA001" ,new SqlParameter ( "@DGA001" ,PQU03 ) );
            if ( del . Rows . Count > 0 )
            {
                textBox2 . Tag = del . Rows [ 0 ] [ "DGA001" ] . ToString ( );
                textBox2 . Text = del . Rows [ 0 ] [ "DGA003" ] . ToString ( );
                textBox7 . Text = del . Rows [ 0 ] [ "DGA017" ] . ToString ( );
                textBox8 . Text = del . Rows [ 0 ] [ "DGA008" ] . ToString ( );
                textBox10 . Text = del . Rows [ 0 ] [ "DGA009" ] . ToString ( );
                textBox6 . Text = del . Rows [ 0 ] [ "DGA011" ] . ToString ( );
            }
        }
        //现价
        private void comboBox7_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox7 );
        }
        private void comboBox7_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox7 );
        }
        private void comboBox7_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox7.Text != "" && !DateDayRegise.sixFour( comboBox7 ) )
            {
                this.comboBox7.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多四位,如99.9999,请重新输入" );
            }
        }
        //预付款
        private void comboBox8_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //丝.热.移印/色价数
        private void comboBox3_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //抽查数量
        private void textBox33_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //AQL
        private void textBox36_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox37_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox38_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox41_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox40_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox39_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox44_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox43_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox42_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //表
        string wp = "", gue = "";
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            DataRow row = gridView1 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            gridLookUpEdit1 . Text = row [ "PQU10" ] . ToString ( );
            comboBox14 . Text =row[ "PQU11" ] . ToString ( );
            textBox14 . Text = row[ "PQU12" ] . ToString ( );
            textBox21 . Text = row[ "PQU13" ] . ToString ( );
            comboBox3 . Text = row[ "PQU14" ] . ToString ( );
            textBox11 . Text = row[ "PQU15" ] . ToString ( );
            comboBox7 . Text = row[ "PQU16" ] . ToString ( );
            comboBox8 . Text = row[ "PQU17" ] . ToString ( );
            comboBox12 . Text = row[ "PQU20" ] . ToString ( );
            comboBox10 . Text =row[ "PQU21" ] . ToString ( );
            if ( row[ "PQU22" ] . ToString ( ) != "" )
                dateTimePicker3 . Value = Convert . ToDateTime ( row[ "PQU22" ] . ToString ( ) );
            if ( row[ "PQU23" ] . ToString ( ) != "" )
                dateTimePicker4 . Value = Convert . ToDateTime ( row[ "PQU23" ] . ToString ( ) );
            if ( row[ "PQU19" ] . ToString ( ) == "库存" )
            {
                radioButton10 . Checked = true;
                //radioButton11_CheckedChanged( null ,null );
                radioButton10_CheckedChanged ( null ,null );
                radioButton11 . Checked = false;
                textBox3 . Text = row[ "PQU18" ] . ToString ( );
            }
            else if ( row[ "PQU19" ] . ToString ( ) == "外购" )
            {
                radioButton10 . Checked = false;
                radioButton11 . Checked = true;
                //radioButton10_CheckedChanged( null ,null );
                radioButton11_CheckedChanged ( null ,null );
                textBox20 . Text = row[ "PQU104" ] . ToString ( );
            }
            //if ( gridView1.GetFocusedRowCellValue( "PQU107" ).ToString( ).Trim( ) == "T" )
            //    checkBox15.Checked = true;
            //else
            //    checkBox15.Checked = false;
            if ( !string . IsNullOrEmpty ( row["idx" ] . ToString ( ) ) )
                id = Convert . ToInt64 ( row[ "idx" ] . ToString ( ) );
            wp = gridLookUpEdit1 . Text;
            gue = textBox14 . Text;
        }
        //窗体关闭
        private void R_FrmsiyeyiyinContract_FormClosing ( object sender ,FormClosingEventArgs e )
        {
            if ( toolSave.Enabled )
            {
                cancel( );
            }
        }
        //使用库存数量
        private void textBox3_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox3 );
        }
        private void textBox3_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox3 );
        }
        private void textBox3_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox3.Text != "" && !DateDayRegise.twelveFourNumber( textBox3 ) )
            {
                this.textBox3.Text = "";
                MessageBox.Show( "只允许输入整数部分最多八位,小数部分最多四位,如999999.9999,请重新输入" );
            }
        }
        //使用库存
        private void radioButton10_CheckedChanged ( object sender ,EventArgs e )
        {
            if ( radioButton10.Checked && ( ( ord == "实际" ) || !string.IsNullOrEmpty( textBox49.Text ) ) )
            {
                fc.yesOrNoOf( comboBox6.Text ,gridLookUpEdit1.Text ,textBox14.Text ,textBox19 ,textBox9 ,textBox53.Text );

                textBox20.Text = Math.Round( Convert.ToDecimal( Operation.MultiThrTbCbAdd( textBox53 ,textBox21 ,comboBox3 ,textBox19.Text ) ) ,4 ).ToString( );

                //if ( string.IsNullOrEmpty( textBox19.Text ) || textBox19.Text == "0" )
                //    textBox3.Text = "";
                //else
                textBox3.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTAdd( textBox53 ,textBox21 ,comboBox3 ) ) ,4 ).ToString( );
            }
        }
        //使用外购
        private void radioButton11_CheckedChanged ( object sender ,EventArgs e )
        {
            if ( radioButton11.Checked && ( ord == "实际" || !string.IsNullOrEmpty( textBox49.Text ) ) )
                get( );
            else
            {
                fc.yesOrNoOf( comboBox6.Text ,gridLookUpEdit1.Text ,textBox14.Text ,textBox19 ,textBox9 ,textBox53.Text );
                textBox20.Text = Math.Round( Convert.ToDecimal( Operation.MultiTwoTAdd( textBox53 ,textBox21 ,comboBox3 ) ) ,4 ).ToString( );
            }

        }
        void get ( )
        {
            string str = "";
            PQU100 = comboBox6.Text;
            PQU010 = gridLookUpEdit1.Text;
            PQU012 = textBox14.Text;
            //AC16=@AC16 AND        
            DataTable del = SqlHelper.ExecuteDataTable( "SELECT AC18,AC10+ISNULL(AC27,0)-ISNULL(SUM(AD12+ISNULL(AD21,0)),0) AC10 FROM R_PQAC A LEFT JOIN R_PQAD B ON A.AC18=B.AD01 WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05 GROUP BY AC18,AC10,ISNULL(AC27,0)  HAVING AC10+ISNULL(AC27,0)-ISNULL(SUM(AD12+ISNULL(AD21,0)),0)>0" ,new SqlParameter( "@AC02" ,PQU100 ) ,new SqlParameter( "@AC04" ,PQU010 ) ,new SqlParameter( "@AC05" ,PQU012 ) );
            if ( del.Rows.Count < 1 )
                str = "0";
            else if ( string.IsNullOrEmpty( del.Rows[0]["AC10"].ToString( ) ) )
                str = "0";
            else
                str = del.Rows[0]["AC10"].ToString( );

            textBox20.Text = Math.Round( Convert.ToDecimal( Operation.MultiThrTbCbAdd( textBox53 ,textBox21 ,comboBox3 ,str ) ) ,4 ).ToString( );
        }
        //使用外购数量
        private void textBox20_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textBox20 );
        }
        private void textBox20_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeTb( textBox20 );
        }
        private void textBox20_LostFocus ( object sender ,EventArgs e )
        {
            if ( textBox20.Text != "" && !DateDayRegise.tenForNumber( textBox20 ) )
            {
                this.textBox20.Text = "";
                MessageBox.Show( "只允许输入整数部分最多六位,小数部分最多四位,如999999.9999,请重新输入" );
            }
        }
        //产品数量
        private void textBox53_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //产品名称
        private void comboBox4_SelectedValueChanged ( object sender ,EventArgs e )
        {
            if ( ord == "计划" || string.IsNullOrEmpty( textBox49.Text ) )
            {
                if ( !string.IsNullOrEmpty( comboBox4.Text ) )
                    comboBox6.Text = comboBox4.SelectedValue.ToString( );
            }
        }
        #endregion

        #region 主体
        string sav = "", weihu = "";
        string PQU01 = "", PQU02 = "", PQU03 = "", PQU05 = "", PQU07 = "", PQU09 = "", PQU24 = "", PQU25 = "", PQU26 = "", PQU27 = "", PQU28 = "", PQU29 = "", PQU30 = "", PQU32 = "", PQU33 = "", PQU34 = "", PQU35 = "", PQU36 = "", PQU37 = "", PQU38 = "", PQU39 = "", PQU40 = "", PQU41 = "", PQU42 = "", PQU43 = "", PQU44 = "", PQU45 = "", PQU47 = "", PQU49 = "", PQU50 = "", PQU51 = "", PQU52 = "", PQU53 = "", PQU54 = "", PQU55 = "", PQU56 = "", PQU57 = "", PQU58 = "", PQU59 = "", PQU60 = "", PQU61 = "", PQU62 = "", PQU63 = "", PQU64 = "", PQU65 = "", PQU66 = "", PQU67 = "", PQU68 = "", PQU69 = "", PQU70 = "", PQU73 = "", PQU74 = "", PQU76 = "", PQU86 = "", PQU87 = "", PQU88 = "", PQU90 = "", PQU92 = "", PQU95 = "", PQU96 = "", PQU97 = "", PQU98 = "", PQU99 = "", PQU100 = "", PQU108 = "", PQU112 = "";



        DateTime PQU04 = MulaolaoBll . Drity . GetDt ( ), PQU06 = MulaolaoBll . Drity . GetDt ( ), PQU08 = MulaolaoBll . Drity . GetDt ( ), PQU31 = MulaolaoBll . Drity . GetDt ( ), PQU46 = MulaolaoBll . Drity . GetDt ( ), PQU48 = MulaolaoBll . Drity . GetDt ( ), PQU71 = MulaolaoBll . Drity . GetDt ( ), PQU75 = MulaolaoBll . Drity . GetDt ( ), PQU89 = MulaolaoBll . Drity . GetDt ( ), PQU91 = MulaolaoBll . Drity . GetDt ( ), PQU93 = MulaolaoBll . Drity . GetDt ( ), PQU94 = MulaolaoBll . Drity . GetDt ( );
        long PQU72 = 0, PQU77 = 0, PQU78 = 0, PQU79 = 0, PQU80 = 0, PQU81 = 0, PQU82 = 0, PQU83 = 0, PQU84 = 0, PQU85 = 0, PQU0101 = 0;
        //新增
        Order od = new Order( );
        string ord = "";
        void orde ( )
        {
            PQU03 = "";
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableTrue( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableTrue( pageList );
            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;

            textBox4.Enabled = false;
            dateTimePicker1.Enabled = dateTimePicker2.Enabled = dateTimePicker4.Enabled = false;
            label98.Visible = false;
            PQU97 = oddNumbers.purchaseContract( "SELECT MAX(AJ006) AJ006 FROM R_PQAJ" ,"AJ006" ,"R_343-" );
            sav = "1";
            weihu = "";
            label3.Visible = false;
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
                comboBox4.Enabled = comboBox6.Enabled = true;
                textBox53.Enabled = true;
                button15.Enabled = true;
                button5.Enabled = false;

                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
            }
            else if ( ord == "实际" )
            {
                orde( );

                comboBox4.Enabled = comboBox6.Enabled = false;
                textBox53.Enabled = false;
                button15.Enabled = false;
                button5.Enabled = true;

                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
            }
            else
            {
                MessageBox.Show( "请选择计划订单或实际订单" );
                sav = "1";
                PQU97 = "";
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

            if ( label3.Visible == true )
            {
                if ( Logins.number == "MLL-0001" )
                    deles( );
                else
                    MessageBox.Show( "单号:" + PQU97 + "的单据状态为执行,不允许删除" );
            }
            else
                deles( );
        }
        void deles ( )
        {
            if ( label3.Visible == true )
                stateOfOdd = "维护删除";
            else
            {
                if ( sav == "1" )
                    stateOfOdd = "新增删除";
                else
                    stateOfOdd = "更改删除";
            }

            result = bll.DeleteAll( PQU97 ,"R_343" ,"五金件(镀、烤漆)采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"删除" ,stateOfOdd );
            if ( result == false )
                MessageBox.Show( "删除数据失败" );
            else
            {
                MessageBox.Show( "成功删除数据" );
                PQU03 = "";
                Ergodic.SpliClear( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableFalse( pageList );
                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;

                toolSelect.Enabled = toolAdd.Enabled = toolPrint.Enabled = toolExport.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;

                textBox4.Enabled = false;
                label98.Visible = label3.Visible = false;
            }
        }
        //更改
        protected override void update ( )
        {
            base.update( );

            if ( label3.Visible == true )
                MessageBox.Show( "单号:" + PQU97 + "的单据状态为执行,不允许更改" );
            else
            {
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolReview.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;

                textBox4.Enabled = false;
                dateTimePicker1.Enabled = dateTimePicker2.Enabled = dateTimePicker4.Enabled = false;

                if ( string.IsNullOrEmpty( textBox49.Text ) )
                {
                    comboBox4.Enabled = comboBox6.Enabled = true;
                    textBox53.Enabled = true;
                    button15.Enabled = true;
                    button5.Enabled = false;
                }
                else
                {
                    comboBox4.Enabled = comboBox6.Enabled = false;
                    textBox53.Enabled = false;
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
            if ( textBox48.Text == "廖灵飞" )
                result = true;
            else
                result = false;
            if ( string.IsNullOrEmpty( textBox13.Text ) )
                over = false;
            else
                over = true;
            Reviews ( "PQU97" ,PQU97 ,"R_PQU" ,this ,PQU01 ,"R_343" ,result ,over ,null /*,"PQU07" ,"PQU92" ,"R_PQU" ,"PQU97" ,PQU97 ,ord ,textBox49.Text ,"R_343"*/);
            result = false;
            result = sp.reviewImple( "R_343" ,PQU97 );
            if ( result == true )
            {
                label3.Visible = true;
                try
                {
                    SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfCopy( "R_PQUC" ,"R_PQU" ,"PQU97" ,PQU97 ) );
                    WriteOfReceivablesTo( );
                }
                catch { }
            }
            else
                label3.Visible = false;
        }
        void WriteOfReceivablesTo ( )
        {
            DataTable receiva;
            MulaolaoLibrary.ProductCostSummaryLibrary modelAm = new MulaolaoLibrary.ProductCostSummaryLibrary( );
            receiva = bll.UpdateOfReceviable( PQU97 );
            if ( receiva != null && receiva.Rows.Count > 0 )
            {
                modelAm.AM002 = receiva.Rows[0]["PQU01"].ToString( );
                modelAm . AM209 = modelAm . AM211 = modelAm . AM225 = modelAm . AM227 = 0;
                modelAm.AM209 = string.IsNullOrEmpty( receiva.Compute( "SUM(PQ)" ,"PQU01='" + modelAm.AM002 + "' AND PQU107='F' AND PQU19='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(PQ)" ,"PQU01='" + modelAm.AM002 + "' AND PQU107='F' AND PQU19='外购'" ) );
                modelAm.AM211 = string.IsNullOrEmpty( receiva.Compute( "SUM(PQ)" ,"PQU01='" + modelAm.AM002 + "' AND PQU107='T' AND PQU19='外购'" ) .ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(PQ)" ,"PQU01='" + modelAm.AM002 + "' AND PQU107='T' AND PQU19='外购'" ) );
                modelAm . AM225 = string . IsNullOrEmpty ( receiva . Compute ( "SUM(PQ)" , "PQU01='" + modelAm . AM002 + "' AND PQU107='F' AND PQU19='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "SUM(PQ)" , "PQU01='" + modelAm . AM002 + "' AND PQU107='F' AND PQU19='库存'" ) );
                modelAm . AM227 = string . IsNullOrEmpty ( receiva . Compute ( "SUM(PQ)" , "PQU01='" + modelAm . AM002 + "' AND PQU107='T' AND PQU19='库存'" ) . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( receiva . Compute ( "SUM(PQ)" , "PQU01='" + modelAm . AM002 + "' AND PQU107='T' AND PQU19='库存'" ) );
                bll .UpdateOfRece( modelAm ,PQU97 );
            }
        }
        //打印
        bool result = false;
        void trueOrFalse ( )
        {
            PQU100 = comboBox6.Text;
            if ( ( string.IsNullOrEmpty( textBox49.Text ) && gridView1.GetDataRow( 0 )["PQU19"].ToString( ) == "外购" ) || ( !string.IsNullOrEmpty( textBox49.Text ) && gridView1.GetDataRow( 0 )["PQU19"].ToString( ) == "库存" ) )
            {
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    if ( sp.inOut( PQU97 ,gridView1.GetDataRow( i )["PQU10"].ToString( ) ,PQU100 ,gridView1.GetDataRow( i )["PQU12"].ToString( ) ) == false )
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

            if ( ( ord == "实际" || !string.IsNullOrEmpty( textBox49.Text ) ) && gridView1.GetDataRow( 0 )["PQU19"].ToString( ) == "外购" )
            {
                if ( label3.Visible == true )
                {
                    MulaolaoBll . ContractAddPrintTime . addTimeToContract ( "R_PQU" ,"PQU113" ,PQU97 ,"PQU97" );

                    CreateDataset( );
                    file = "";
                    file = System.Windows.Forms.Application.StartupPath;
                    report.Load( file + "\\R_343.frx" );
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
                    MulaolaoBll . ContractAddPrintTime . addTimeToContract ( "R_PQU" ,"PQU113" ,PQU97 ,"PQU97" );

                    CreateDataset ( );
                    file = "";
                    file = System.Windows.Forms.Application.StartupPath;
                    report.Load( file + "\\R_343.frx" );
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

            CreateDataset( );
            file = "";
            file = System.Windows.Forms.Application.StartupPath;
            report.Load( file + "\\R_343.frx" );
            report.RegisterData( RDataSet );
            report.Prepare( );
            XMLExport exprots = new XMLExport( );
        }
        //保存
        void saves ( )
        {
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolReview.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;

            textBox4.Enabled = false;

            copy = "";
            sav = "2";
            weihu = "";
            label98.Visible = false;
        }
        void updates ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "UPDATE R_PQU SET PQU01='{0}',PQU02='{1}',PQU03='{2}',PQU04='{3}',PQU05='{4}',PQU06='{5}',PQU07='{6}',PQU08='{7}',PQU09='{8}',PQU24='{9}',PQU25='{10}',PQU26='{11}',PQU27='{12}',PQU28='{13}',PQU29='{14}',PQU30='{15}',PQU31='{16}',PQU32='{17}',PQU33='{18}',PQU34='{19}',PQU35='{20}',PQU36='{21}',PQU37='{22}',PQU38='{23}',PQU39='{24}',PQU40='{25}',PQU41='{26}',PQU42='{27}',PQU43='{28}',PQU44='{29}',PQU45='{30}',PQU46='{31}',PQU47='{32}',PQU48='{33}',PQU49='{34}',PQU50='{35}',PQU51='{36}',PQU52='{37}',PQU53='{38}',PQU54='{39}',PQU55='{40}',PQU56='{41}',PQU57='{42}',PQU58='{43}',PQU59='{44}',PQU60='{45}',PQU61='{46}',PQU62='{47}',PQU63='{48}',PQU64='{49}',PQU65='{50}',PQU66='{51}',PQU67='{52}',PQU68='{53}',PQU69='{54}',PQU70='{55}',PQU71='{56}',PQU72='{57}',PQU73='{58}',PQU74='{59}',PQU75='{60}',PQU76='{61}',PQU77='{62}',PQU78='{63}',PQU79='{64}',PQU80='{65}',PQU81='{66}',PQU82='{67}',PQU83='{68}',PQU84='{69}',PQU85='{70}',PQU86='{71}',PQU87='{72}',PQU88='{73}',PQU89='{74}',PQU90='{75}',PQU91='{76}',PQU92='{77}',PQU93='{78}',PQU94='{79}',PQU95='{80}',PQU96='{81}',PQU98='{82}',PQU99='{83}',PQU100='{84}',PQU107='{85}',PQU108='{86}',PQU106='{88}',PQU112='{89}' WHERE PQU97='{87}'" ,PQU01 ,PQU02 ,PQU03 ,PQU04 ,PQU05 ,PQU06 ,PQU07 ,PQU08 ,PQU09 ,PQU24 ,PQU25 ,PQU26 ,PQU27 ,PQU28 ,PQU29 ,PQU30 ,PQU31 ,PQU32 ,PQU33 ,PQU34 ,PQU35 ,PQU36 ,PQU37 ,PQU38 ,PQU39 ,PQU40 ,PQU41 ,PQU42 ,PQU43 ,PQU44 ,PQU45 ,PQU46 ,PQU47 ,PQU48 ,PQU49 ,PQU50 ,PQU51 ,PQU52 ,PQU53 ,PQU54 ,PQU55 ,PQU56 ,PQU57 ,PQU58 ,PQU59 ,PQU60 ,PQU61 ,PQU62 ,PQU63 ,PQU64 ,PQU65 ,PQU66 ,PQU67 ,PQU68 ,PQU69 ,PQU70 ,PQU71 ,PQU72 ,PQU73 ,PQU74 ,PQU75 ,PQU76 ,PQU77 ,PQU78 ,PQU79 ,PQU80 ,PQU81 ,PQU82 ,PQU83 ,PQU84 ,PQU85 ,PQU86 ,PQU87 ,PQU88 ,PQU89 ,PQU90 ,PQU91 ,PQU92 ,PQU93 ,PQU94 ,PQU95 ,PQU96 ,PQU98 ,PQU99 ,PQU100 ,PQU1070 ,PQU108 ,PQU97 ,"" ,PQU112 );
            int count = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( count < 1 )
                MessageBox.Show( "录入数据失败" );
            else
            {
                MessageBox.Show( "成功录入数据" );
                try
                {
                    SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_343" ,"五金件(镀、烤漆)采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,PQU97 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"保存" ,stateOfOdd ) );
                    WriteOfReceivablesTo ( );
                }
                catch { }
                finally { saves( ); }
            }
        }
        protected override void save ( )
        {
            base . save ( );

            #region
            PQU03 = textBox2 . Tag == null ? string . Empty : textBox2 . Tag . ToString ( );
            PQU1070 = checkBox15 . Checked == true ? "T" : "F";
            PQU98 = comboBox4 . Text;
            PQU99 = textBox50 . Text;
            PQU01 = textBox49 . Text;
            PQU100 = comboBox6 . Text;
            PQU108 = lookUpEdit2 . Text;
            if ( !string . IsNullOrEmpty ( textBox53 . Text ) )
                PQU0101 = Convert . ToInt64 ( textBox53 . Text );
            else
                PQU0101 = 0;
            PQU04 = dateTimePicker14 . Value;
            PQU05 = textBox17 . Text;
            PQU06 = dateTimePicker1 . Value;
            PQU07 = textBox13 . Text;
            PQU08 = dateTimePicker2 . Value;
            PQU09 = textBox16 . Text;
            PQU24 = textBox15 . Text;
            PQU25 = textBox18 . Text;
            if ( checkBox36 . Checked )
            {
                PQU26 = "T";
            }
            else
            {
                PQU26 = "F";
            }
            if ( checkBox38 . Checked )
            {
                PQU27 = "T";
            }
            else
            {
                PQU27 = "F";
            }
            if ( checkBox39 . Checked )
            {
                PQU28 = "T";
            }
            else
            {
                PQU28 = "F";
            }
            if ( checkBox40 . Checked )
            {
                PQU29 = "T";
            }
            else
            {
                PQU29 = "F";
            }
            PQU30 = comboBox16 . Text;
            PQU31 = dateTimePicker5 . Value;
            if ( checkBox4 . Checked )
            {
                PQU32 = "T";
            }
            else
            {
                PQU32 = "F";
            }
            if ( checkBox7 . Checked )
            {
                PQU33 = "T";
            }
            else
            {
                PQU33 = "F";
            }
            if ( checkBox5 . Checked )
            {
                PQU34 = "T";
            }
            else
            {
                PQU34 = "F";
            }
            if ( checkBox6 . Checked )
            {
                PQU35 = "T";
            }
            else
            {
                PQU35 = "F";
            }
            if ( checkBox1 . Checked )
            {
                PQU36 = "T";
            }
            else
            {
                PQU36 = "F";
            }
            if ( checkBox2 . Checked )
            {
                PQU37 = "T";
            }
            else
            {
                PQU37 = "F";
            }
            if ( checkBox3 . Checked )
            {
                PQU38 = "T";
            }
            else
            {
                PQU38 = "F";
            }
            if ( checkBox8 . Checked )
            {
                PQU39 = "T";
            }
            else
            {
                PQU39 = "F";
            }
            if ( checkBox9 . Checked )
            {
                PQU40 = "T";
            }
            else
            {
                PQU40 = "F";
            }
            if ( checkBox10 . Checked )
            {
                PQU41 = "T";
            }
            else
            {
                PQU41 = "F";
            }
            if ( checkBox41 . Checked )
            {
                PQU42 = "T";
            }
            else
            {
                PQU42 = "F";
            }
            PQU43 = textBox26 . Text;
            PQU43 = textBox1 . Text;
            PQU45 = comboBox17 . Text;
            PQU46 = dateTimePicker6 . Value;
            PQU47 = comboBox18 . Text;
            PQU48 = dateTimePicker7 . Value;
            if ( checkBox11 . Checked )
            {
                PQU49 = "T";
            }
            else
            {
                PQU49 = "F";
            }
            if ( checkBox12 . Checked )
            {
                PQU50 = "T";
            }
            else
            {
                PQU50 = "F";
            }
            if ( checkBox13 . Checked )
            {
                PQU51 = "T";
            }
            else
            {
                PQU51 = "F";
            }
            if ( checkBox14 . Checked )
            {
                PQU52 = "T";
            }
            else
            {
                PQU52 = "F";
            }
            if ( checkBox17 . Checked )
            {
                PQU53 = "T";
            }
            else
            {
                PQU53 = "F";
            }
            if ( checkBox21 . Checked )
            {
                PQU54 = "T";
            }
            else
            {
                PQU54 = "F";
            }
            if ( checkBox26 . Checked )
            {
                PQU55 = "T";
            }
            else
            {
                PQU55 = "F";
            }
            if ( checkBox27 . Checked )
            {
                PQU56 = "T";
            }
            else
            {
                PQU56 = "F";
            }
            if ( checkBox19 . Checked )
            {
                PQU57 = "T";
            }
            else
            {
                PQU57 = "F";
            }
            if ( checkBox24 . Checked )
            {
                PQU58 = "T";
            }
            else
            {
                PQU58 = "F";
            }
            if ( checkBox30 . Checked )
            {
                PQU59 = "T";
            }
            else
            {
                PQU59 = "F";
            }
            if ( checkBox33 . Checked )
            {
                PQU60 = "T";
            }
            else
            {
                PQU60 = "F";
            }
            if ( checkBox35 . Checked )
            {
                PQU61 = "T";
            }
            else
            {
                PQU61 = "F";
            }
            if ( checkBox32 . Checked )
            {
                PQU62 = "T";
            }
            else
            {
                PQU62 = "F";
            }
            if ( checkBox31 . Checked )
            {
                PQU63 = "T";
            }
            else
            {
                PQU63 = "F";
            }
            if ( checkBox34 . Checked )
            {
                PQU64 = "T";
            }
            else
            {
                PQU64 = "F";
            }
            PQU65 = textBox30 . Text;
            if ( radioButton1 . Checked )
            {
                PQU66 = radioButton1 . Text;
            }
            else if ( radioButton2 . Checked )
            {
                PQU66 = radioButton2 . Text;
            }
            if ( radioButton3 . Checked )
            {
                PQU67 = radioButton3 . Text;
            }
            else if ( radioButton4 . Checked )
            {
                PQU67 = radioButton4 . Text;
            }
            if ( radioButton6 . Checked )
            {
                PQU68 = radioButton6 . Text;
                PQU69 = textBox24 . Text;
            }
            else if ( radioButton5 . Checked )
            {
                PQU68 = radioButton5 . Text;
            }
            PQU70 = textBox31 . Text;
            PQU71 = dateTimePicker8 . Value;
            if ( textBox33 . Text == "" )
            {
                PQU72 = 0;
            }
            else
            {
                PQU72 = Convert . ToInt64 ( textBox33 . Text );
            }
            if ( radioButton7 . Checked )
            {
                PQU73 = radioButton7 . Text;
            }
            else if ( radioButton8 . Checked )
            {
                PQU73 = radioButton8 . Text;
            }
            else if ( radioButton9 . Checked )
            {
                PQU73 = radioButton9 . Text;
                PQU76 = textBox35 . Text;
            }
            PQU74 = comboBox5 . Text;
            PQU75 = dateTimePicker9 . Value;
            if ( textBox36 . Text == "" )
            {
                PQU77 = 0;
            }
            else
            {
                PQU77 = Convert . ToInt64 ( textBox36 . Text );
            }
            if ( textBox37 . Text == "" )
            {
                PQU78 = 0;
            }
            else
            {
                PQU78 = Convert . ToInt64 ( textBox37 . Text );
            }
            if ( textBox38 . Text == "" )
            {
                PQU79 = 0;
            }
            else
            {
                PQU79 = Convert . ToInt64 ( textBox38 . Text );
            }
            if ( textBox39 . Text == "" )
            {
                PQU80 = 0;
            }
            else
            {
                PQU80 = Convert . ToInt64 ( textBox39 . Text );
            }
            if ( textBox40 . Text == "" )
            {
                PQU81 = 0;
            }
            else
            {
                PQU81 = Convert . ToInt64 ( textBox40 . Text );
            }
            if ( textBox41 . Text == "" )
            {
                PQU82 = 0;
            }
            else
            {
                PQU82 = Convert . ToInt64 ( textBox41 . Text );
            }
            if ( textBox42 . Text == "" )
            {
                PQU83 = 0;
            }
            else
            {
                PQU83 = Convert . ToInt64 ( textBox42 . Text );
            }
            if ( textBox43 . Text == "" )
            {
                PQU84 = 0;
            }
            else
            {
                PQU84 = Convert . ToInt64 ( textBox43 . Text );
            }
            if ( textBox44 . Text == "" )
            {
                PQU85 = 0;
            }
            else
            {
                PQU85 = Convert . ToInt64 ( textBox44 . Text );
            }
            PQU86 = textBox12 . Text;
            PQU87 = textBox45 . Text;
            PQU88 = textBox46 . Text;
            PQU89 = dateTimePicker10 . Value;
            PQU90 = textBox47 . Text;
            PQU91 = dateTimePicker11 . Value;
            PQU92 = textBox48 . Text;
            PQU93 = dateTimePicker12 . Value;
            PQU94 = dateTimePicker13 . Value;
            PQU112 = checkBox16 . Checked == true ? "T" : "F";
            #endregion

            PQU95 = textBox4 . Text;
            PQU96 = "";

            if ( string . IsNullOrEmpty ( textBox16 . Text ) )
            {
                MessageBox . Show ( "合同批号不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( lookUpEdit1 . Text ) )
            {
                MessageBox . Show ( "请选择联系人" );
                return;
            }
            if ( string . IsNullOrEmpty ( PQU03 ) )
            {
                MessageBox . Show ( "请选择供应商" );
                return;
            }
            PQU02 = lookUpEdit1 . EditValue . ToString ( );
            DataTable dro = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_PQU WHERE PQU97=@PQU97" ,new SqlParameter ( "@PQU97" ,PQU97 ) );

            if ( weihu == "1" )
            {
                if ( string . IsNullOrEmpty ( textBox4 . Text ) )
                    MessageBox . Show ( "请填写维护意见" );
                else
                {
                    if ( dro . Rows . Count < 1 )
                        MessageBox . Show ( "单号:" + PQU97 + "的记录不存在,请核实后再维护" );
                    else
                    {
                        PQU96 = dro . Rows [ 0 ] [ "PQU96" ] . ToString ( ) + "[" + Logins . username + MulaolaoBll . Drity . GetDt ( ) . ToString ( "yyyyMMdd" ) + "]";

                        StringBuilder strSql = new StringBuilder ( );
                        strSql . AppendFormat ( "UPDATE R_PQU SET PQU01='{0}',PQU02='{1}',PQU03='{2}',PQU04='{3}',PQU05='{4}',PQU06='{5}',PQU07='{6}',PQU08='{7}',PQU09='{8}',PQU24='{9}',PQU25='{10}',PQU26='{11}',PQU27='{12}',PQU28='{13}',PQU29='{14}',PQU30='{15}',PQU31='{16}',PQU32='{17}',PQU33='{18}',PQU34='{19}',PQU35='{20}',PQU36='{21}',PQU37='{22}',PQU38='{23}',PQU39='{24}',PQU40='{25}',PQU41='{26}',PQU42='{27}',PQU43='{28}',PQU44='{29}',PQU45='{30}',PQU46='{31}',PQU47='{32}',PQU48='{33}',PQU49='{34}',PQU50='{35}',PQU51='{36}',PQU52='{37}',PQU53='{38}',PQU54='{39}',PQU55='{40}',PQU56='{41}',PQU57='{42}',PQU58='{43}',PQU59='{44}',PQU60='{45}',PQU61='{46}',PQU62='{47}',PQU63='{48}',PQU64='{49}',PQU65='{50}',PQU66='{51}',PQU67='{52}',PQU68='{53}',PQU69='{54}',PQU70='{55}',PQU71='{56}',PQU72='{57}',PQU73='{58}',PQU74='{59}',PQU75='{60}',PQU76='{61}',PQU77='{62}',PQU78='{63}',PQU79='{64}',PQU80='{65}',PQU81='{66}',PQU82='{67}',PQU83='{68}',PQU84='{69}',PQU85='{70}',PQU86='{71}',PQU87='{72}',PQU88='{73}',PQU89='{74}',PQU90='{75}',PQU91='{76}',PQU92='{77}',PQU93='{78}',PQU94='{79}',PQU95='{80}',PQU96='{81}',PQU98='{82}',PQU99='{83}',PQU100='{84}',PQU107='{85}',PQU108='{86}',PQU112='{88}' WHERE PQU97='{87}'" ,PQU01 ,PQU02 ,PQU03 ,PQU04 ,PQU05 ,PQU06 ,PQU07 ,PQU08 ,PQU09 ,PQU24 ,PQU25 ,PQU26 ,PQU27 ,PQU28 ,PQU29 ,PQU30 ,PQU31 ,PQU32 ,PQU33 ,PQU34 ,PQU35 ,PQU36 ,PQU37 ,PQU38 ,PQU39 ,PQU40 ,PQU41 ,PQU42 ,PQU43 ,PQU44 ,PQU45 ,PQU46 ,PQU47 ,PQU48 ,PQU49 ,PQU50 ,PQU51 ,PQU52 ,PQU53 ,PQU54 ,PQU55 ,PQU56 ,PQU57 ,PQU58 ,PQU59 ,PQU60 ,PQU61 ,PQU62 ,PQU63 ,PQU64 ,PQU65 ,PQU66 ,PQU67 ,PQU68 ,PQU69 ,PQU70 ,PQU71 ,PQU72 ,PQU73 ,PQU74 ,PQU75 ,PQU76 ,PQU77 ,PQU78 ,PQU79 ,PQU80 ,PQU81 ,PQU82 ,PQU83 ,PQU84 ,PQU85 ,PQU86 ,PQU87 ,PQU88 ,PQU89 ,PQU90 ,PQU91 ,PQU92 ,PQU93 ,PQU94 ,PQU95 ,PQU96 ,PQU98 ,PQU99 ,PQU100 ,PQU1070 ,PQU108 ,PQU97 ,PQU112 );
                        int count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
                        if ( count < 1 )
                            MessageBox . Show ( "录入数据失败" );
                        else
                        {
                            MessageBox . Show ( "成功录入数据" );
                            try
                            {
                                stateOfOdd = "维护保存";
                                SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfComparation ( "R_343" ,"五金件(镀、烤漆)采购合同书" ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,PQU97 ,strSql . ToString ( ) . Replace ( "'" ,"''" ) ,"保存" ,stateOfOdd ) );
                                SqlHelper . ExecuteNonQuery ( MulaolaoBll . Drity . DrityOfCopy ( "R_PQUC" ,"R_PQU" ,"PQU97" ,PQU97 ) );
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
                if ( sav == "1" )
                    stateOfOdd = "新增保存";
                else
                    stateOfOdd = "更改保存";

                if ( dro . Rows . Count < 1 )
                {
                    saves ( );
                }
                else
                {
                    if ( copy == "1" )
                    {
                        if ( MulaolaoBll . WriteReceivableToGeneralLedger . ExistsSup ( PQU03 ) == false )
                        {
                            MessageBox . Show ( "供应商已注销,请核实" );
                            return;
                        }

                        stateOfOdd = "复制保存";
                        //AND PQU05=@PQU05
                        DataTable dyu = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_PQU WHERE PQU97!=@PQU97 " ,new SqlParameter ( "@PQU97" ,PQU97 ) /*,new SqlParameter( "@PQU05" ,PQU05 )*/ );
                        if ( dyu . Rows . Count < 1 )
                            updates ( );
                        else
                        {
                            int proNum = 0;

                            for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
                            {
                                proNum = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "PQU101" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView1 . GetDataRow ( i ) [ "PQU101" ] );
                                if ( proNum != PQU0101 )
                                {
                                    MessageBox . Show ( "产品数量不一致,请核实" );
                                    break;
                                }

                                //if ( dyu.Select( "PQU10='" + gridView1.GetDataRow( i )["PQU10"].ToString( ) + "' AND PQU12='" + gridView1.GetDataRow( i )["PQU12"].ToString( ) + "'AND PQU01='" + PQU01 + "'" ).Length > 0 )
                                //{
                                if ( ord == "计划" || string . IsNullOrEmpty ( textBox49 . Text ) )
                                {
                                    if ( dyu . Select ( "PQU10='" + gridView1 . GetDataRow ( i ) [ "PQU10" ] . ToString ( ) + "' AND PQU12='" + gridView1 . GetDataRow ( i ) [ "PQU12" ] . ToString ( ) + "'AND PQU100='" + PQU100 + "'" ) . Length > 0 )
                                    {
                                        if ( PQU09 . Length > 8 && PQU09 . Substring ( 0 ,8 ) == "MLL-0001" )
                                        {
                                            updates ( );
                                            break;
                                        }
                                        else
                                        {
                                            //\n\r开合同人:" + PQU05 + "
                                            MessageBox . Show ( "已经存在\n\r货号:" + PQU100 + "\n\r物料名称:" + gridView1 . GetDataRow ( i ) [ "PQU10" ] . ToString ( ) + "\n\r规格" + gridView1 . GetDataRow ( i ) [ "PQU12" ] . ToString ( ) + "\n\r的记录,请核实后再录入" );
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        updates ( );
                                        break;
                                    }
                                }
                                else if ( ord == "实际" || !string . IsNullOrEmpty ( textBox49 . Text ) )
                                {
                                    if ( yesOrNoHaveStock ( ) == false )
                                        return;

                                    if ( !string . IsNullOrEmpty ( textBox49 . Text ) )
                                    {
                                        if ( checkThisAnd509 ( ) == false )
                                            return;
                                    }

                                    if ( dyu . Select ( "PQU10='" + gridView1 . GetDataRow ( i ) [ "PQU10" ] . ToString ( ) + "' AND PQU12='" + gridView1 . GetDataRow ( i ) [ "PQU12" ] . ToString ( ) + "'AND PQU01='" + PQU01 + "'" ) . Length > 0 )
                                    {
                                        if ( PQU09 . Length > 8 && PQU09 . Substring ( 0 ,8 ) == "MLL-0001" )
                                        {
                                            updates ( );
                                            break;
                                        }
                                        else
                                        {
                                            //\n\r开合同人:" + PQU05 + "
                                            MessageBox . Show ( "已经存在\n\r流水号:" + PQU01 + "\n\r物料名称:" + gridView1 . GetDataRow ( i ) [ "PQU10" ] . ToString ( ) + "\n\r规格" + gridView1 . GetDataRow ( i ) [ "PQU12" ] . ToString ( ) + "\n\r的记录,请核实后再录入" );
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        updates ( );
                                        break;
                                    }
                                }
                                //}
                                //else if ( i == gridView1.RowCount - 1 )
                                //    updates( );
                            }
                        }
                    }
                    else
                        updates ( );
                }
            }
        }
        bool yesOrNoHaveStock ( )
        {
            result = true;
            //PQU19:使用库存OR外购
            //PQU101:产品数量
            //PQU10:物料名称
            //PQU12:规格
            //combobox6:货号
            if ( gridView1.RowCount > 0 && gridView1.GetDataRow( 0 )["PQU19"].ToString( ) == "库存" )
            {
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    result = fc.LibraryOf( comboBox6.Text ,gridView1.GetDataRow( i )["PQU101"].ToString( ) ,gridView1.GetDataRow( i )["PQU10"].ToString( ) ,gridView1.GetDataRow( i )["PQU12"].ToString( ) );
                    if ( result == false )
                    {
                        MessageBox.Show( "库存数量少于使用库存数量,请核实" );
                        break;
                    }
                    else if ( i == gridView1.RowCount - 1 )
                        result = true;
                }
            }
            return result;
        }
        bool checkThisAnd509 ( )
        {
            result = true;
            model . PQU01 = textBox49 . Text;
            for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
            {
                model . PQU10 = gridView1 . GetDataRow ( i ) [ "PQU10" ] . ToString ( );
                model . PQU12 = gridView1 . GetDataRow ( i ) [ "PQU12" ] . ToString ( );
                result = fc . check343And509 ( model );
                if ( result == false )
                {
                    MessageBox . Show ( "流水号:" + model . PQU01 + "\n\r部件名称:" + model . PQU10 + "\n\r规格尺寸:" + model . PQU12 + "\n\r与509不一致,请核实" );
                    break;
                }
            }
            return result;
        }
        //取消
        protected override void cancel ( )
        {
            base.cancel( );

            if ( sav == "1" && weihu != "1" )
            {
                PQU03 = "";
                Ergodic.SpliClear( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;

                toolSelect.Enabled = toolAdd.Enabled = toolPrint.Enabled = toolExport.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolMaintain.Enabled = toolReview.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                label98.Visible = false;
                try
                {
                    bll.DeleteAll( PQU97 ,"R_343" ,"五金件(镀、烤漆)采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"取消" ,"新增取消" );
                }
                catch { }
            }
            else if ( sav == "2" || weihu == "1" )
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
            }
            textBox4.Enabled = false;
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
        }
        //维护
        protected override void maintain ( )
        {
            base.maintain( );

            if ( label3.Visible == true )
            {
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;

                textBox4.Enabled = true;
                dateTimePicker1.Enabled = dateTimePicker2.Enabled = dateTimePicker4.Enabled = false;
                weihu = "1";
                if ( !string.IsNullOrEmpty( textBox49.Text ) )
                {
                    comboBox4.Enabled = comboBox6.Enabled = false;
                    textBox53.Enabled = false;
                    button15.Enabled = false;
                    button5.Enabled = true;
                }
                else
                {
                    comboBox4.Enabled = comboBox6.Enabled = true;
                    textBox53.Enabled = true;
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

            if ( label3.Visible == false )
            {
                MessageBox.Show( "非执行单据不能出库" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox4.Text ) )
            {
                MessageBox.Show( "产品名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox6.Text ) )
            {
                MessageBox.Show( "货号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox53.Text ) )
            {
                MessageBox.Show( "产品数量不可为空" );
                return;
            }
            if ( gridView1.GetDataRow( 0 )["PQU14"].ToString( ) == "外购" )
            {
                MessageBox.Show( "使用外购不能出库,请选择库存或更改状态" );
                return;
            }

            libraryTable = null;
            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                if ( libraryTable != null )
                    libraryTable.Rows.Add( new object[] { gridView1.GetDataRow( i )["PQU12"].ToString( ) ,gridView1.GetDataRow( i )["PQU10"].ToString( ) ,Convert.ToDecimal( gridView1.GetDataRow( i )["PQU18"].ToString( ) ) } );
                else
                {
                    libraryTable = new DataTable( "Datas" );
                    libraryTable.Columns.Add( "tOne" ,typeof( System.String ) );
                    libraryTable.Columns.Add( "tTwo" ,typeof( System.String ) );
                    libraryTable.Columns.Add( "tTre" ,typeof( System.Decimal ) );
                    libraryTable.Rows.Add( new object[] { gridView1.GetDataRow( i )["PQU12"].ToString( ) ,gridView1.GetDataRow( i )["PQU10"].ToString( ) ,Convert.ToDecimal( gridView1.GetDataRow( i )["PQU18"].ToString( ) ) } );
                }
            }
            if ( libraryTable.Rows.Count > 0 )
            {
                SelectAll.OutbandChoice outC = new SelectAll.OutbandChoice( );
                outC.libraryTable = libraryTable;
                outC.number = comboBox6.Text;
                outC.sign = "R_343";
                outC.oddNum = PQU97;
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
                    countSum = libraryTable.Select( "tTwo='" + gridView1.GetDataRow( i )["PQU12"].ToString( ) + gridView1.GetDataRow( i )["PQU10"].ToString( ) + "'" ).Length;
                    if ( countSum > 0 )
                    {
                        for ( int k = 0 ; k < countSum ; k++ )
                        {
                            if ( !speList.Contains( libraryTable.Select( "tTwo='" + gridView1.GetDataRow( i )["PQU12"].ToString( ) + gridView1.GetDataRow( i )["PQU10"].ToString( ) + "'" )[k]["tOne"].ToString( ) ) )
                                speList.Add( libraryTable.Select( "tTwo='" + gridView1.GetDataRow( i )["PQU12"].ToString( ) + gridView1.GetDataRow( i )["PQU10"].ToString( ) + "'" )[k]["tOne"].ToString( ) );
                        }
                        if ( speList.Count > 0 )
                        {
                            foreach ( string str in speList )
                            {
                                query = str;
                                count = libraryTable.Select( "tTwo='" + gridView1.GetDataRow( i )["PQU12"].ToString( ) + gridView1.GetDataRow( i )["PQU10"].ToString( ) + "' AND tOne='" + query + "'" )[0]["tTre"].ToString( );

                                result = fc . Library ( comboBox4 . Text ,comboBox6 . Text ,textBox49 . Text ,textBox53 . Text ,gridView1 . GetDataRow ( i ) [ "PQU10" ] . ToString ( ) ,gridView1 . GetDataRow ( i ) [ "PQU12" ] . ToString ( ) ,gridView1 . GetDataRow ( i ) [ "PQU21" ] . ToString ( ) ,gridView1 . GetDataRow ( i ) [ "PQU13" ] . ToString ( ) ,"" ,gridView1 . GetDataRow ( i ) [ "PQU16" ] . ToString ( ) ,/*gridView1.GetDataRow( i )["PQU18"].ToString( ) */count ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,PQU97 ,query . ToString ( ) ,lookUpEdit2 . Text );
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
                //fc . deleteOfLibrary ( speList ,PQU97 ,textBox49 . Text );
            }
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

            if ( label3.Visible == true )
            {
                if ( string . IsNullOrEmpty ( comboBox4 . Text ) )
                {
                    MessageBox . Show ( "产品名称不可为空" );
                    return;
                }
                if ( string . IsNullOrEmpty ( comboBox6 . Text ) )
                {
                    MessageBox . Show ( "货号不可为空" );
                    return;
                }
                if ( string . IsNullOrEmpty ( textBox53 . Text ) )
                {
                    MessageBox . Show ( "产品数量不可为空" );
                    return;
                }
                if ( gridView1 . GetDataRow ( 0 ) [ "PQU14" ] . ToString ( ) == "库存" )
                {
                    MessageBox . Show ( "库存无法入库,请选择外购或更改状态" );
                    return;
                }
                if ( gridView1 . GetDataRow ( 0 ) [ "PQU14" ] . ToString ( ) == "外购" && ( ord == "实际" ) || !string . IsNullOrEmpty ( textBox49 . Text ) )
                {
                    MessageBox . Show ( "实际订单不允许入库" );
                    return;
                }
                    string mt = "";
                for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
                {
                    if ( string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "PQU14" ] . ToString ( ) ) )
                        mt = gridView1 . GetDataRow ( i ) [ "PQU13" ] . ToString ( );
                    else
                    {
                        if ( Convert . ToInt64 ( textBox53 . Text ) == 0 )
                            mt = gridView1 . GetDataRow ( i ) [ "PQU13" ] . ToString ( );
                        else
                            mt = Math . Round ( Convert . ToDecimal ( Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "PQU13" ] . ToString ( ) ) + Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "PQU14" ] . ToString ( ) ) / Convert . ToInt64 ( textBox53 . Text ) ) ,7 ) . ToString ( );
                    }
                    result = fc . Storage ( comboBox4 . Text ,comboBox6 . Text ,textBox53 . Text ,gridView1 . GetDataRow ( i ) [ "PQU10" ] . ToString ( ) ,gridView1 . GetDataRow ( i ) [ "PQU12" ] . ToString ( ) ,gridView1 . GetDataRow ( i ) [ "PQU21" ] . ToString ( ) ,mt ,"" ,gridView1 . GetDataRow ( i ) [ "PQU16" ] . ToString ( ) ,gridView1 . GetDataRow ( i ) [ "PQU104" ] . ToString ( ) ,textBox17 . Text ,dateTimePicker2 . Value ,lookUpEdit1 . Text ,MulaolaoBll . Drity . GetDt ( ) ,PQU97 ,gridView1 . GetDataRow ( i ) [ "PQU109" ] . ToString ( ) ,gridView1 . GetDataRow ( i ) [ "PQU110" ] . ToString ( ) ,lookUpEdit2 . Text ,textBox2 . Text ,textBox10 . Text );
                    if ( result == false )
                    {
                        MessageBox . Show ( "入库失败" );
                        break;
                    }
                    else if ( i == gridView1 . RowCount - 1 )
                    {
                        MessageBox . Show ( "入库成功" );
                        try
                        {
                            for ( int k = 0 ; k < gridView1 . RowCount ; k++ )
                            {
                                model . IDX = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( gridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                                model . PQU109 = string . IsNullOrEmpty ( textBox53 . Text ) == true ? 0 : Convert . ToInt64 ( textBox53 . Text );
                                model . PQU110 = string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "PQU104" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "PQU104" ] . ToString ( ) );
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

            if ( label3.Visible == true )
                stateOfOdd = "维护复制";
            else
            {
                if ( sav == "1" )
                    stateOfOdd = "新增复制";
                else
                    stateOfOdd = "更改复制";
            }
            result = bll.Copy( PQU97 ,"R_343" ,"五金件(镀、烤漆)采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOfOdd );
            if ( result == false )
                MessageBox.Show( "复制失败,请重试" );
            else
            {
                PQU97 = oddNumbers.purchaseContract( "SELECT MAX(AJ006) AJ006 FROM R_PQAJ" ,"AJ006" ,"R_343-" );
                stateOfOdd = "更改复制单号";
                result = bll.CopyAll( PQU97 ,"R_343" ,"五金件(镀、烤漆)采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"复制" ,stateOfOdd );
                if ( result == false )
                {
                    MessageBox.Show( "复制失败,请重试" );
                    SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQU WHERE PQU97 IS NULL" );
                }
                else
                {
                    MessageBox.Show( "成功复制此表" );
                    Ergodic.SpliEnableTrue( spList );
                    Ergodic.TablePageEnableTrue( pageList );
                    Ergodic.FormEvery( this );
                    gridControl1.DataSource = null;
                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolReview.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                    toolSave.Enabled = toolCancel.Enabled = true;
                    textBox4.Enabled = false;
                    sav = "1";
                    ord = "";
                    copy = "1";
                    weihu = "";
                    label3.Visible = false;
                    dateTimePicker2.Enabled = dateTimePicker1.Enabled = dateTimePicker4.Enabled = false;
                    queryContent( );
                    button13_Click( null ,null );
                }
            }
        }
        #endregion
        
        #region 表格
        //DataTable bi;
        string PQU010 = "", PQU011 = "", PQU012 = "", PQU020 = "", PQU021 = "", PQU019 = "", PQU1070 = "";
        decimal PQU015 = 0M, PQU016 = 0M, PQU017 = 0M, PQU018 = 0, PQU0104 = 0, PQU013 = 0M;
        int PQU014 = 0;
        long id = 0;
        DateTime PQU022 = MulaolaoBll . Drity . GetDt ( ), PQU023 = MulaolaoBll . Drity . GetDt ( );
        //新建
        void getSet ( )
        {
            PQU03 = textBox2 . Tag == null ? string . Empty : textBox2 . Tag . ToString ( );
            PQU98 = comboBox4.Text;
            PQU100 = comboBox6.Text;
            PQU010 = gridLookUpEdit1.Text;
            PQU011 = comboBox14.Text;
            PQU012 = textBox14.Text;
            if ( !string.IsNullOrEmpty( textBox53.Text ) )
                PQU0101 = Convert.ToInt64( textBox53.Text );
            if ( !string.IsNullOrEmpty( textBox21.Text ) )
                PQU013 = Convert.ToDecimal( textBox21.Text );
            else
                PQU013 = 0;
            if ( !string.IsNullOrEmpty( comboBox3.Text ) )
                PQU014 = Convert.ToInt32( comboBox3.Text );
            else
                PQU014 = 0;
            if ( !string.IsNullOrEmpty( textBox11.Text ) )
                PQU015 = Convert.ToDecimal( textBox11.Text );
            else
                PQU015 = 0M;
            if ( !string.IsNullOrEmpty( comboBox7.Text ) )
                PQU016 = Convert.ToDecimal( comboBox7.Text );
            else
                PQU016 = 0M;
            if ( !string.IsNullOrEmpty( comboBox8.Text ) )
                PQU017 = Convert.ToDecimal( comboBox8.Text );
            else
                PQU017 = 0M;
            if ( radioButton10.Checked )
            {
                PQU019 = "库存";
                if ( string.IsNullOrEmpty( textBox3.Text ) )
                    PQU018 = 0;
                else
                    PQU018 = Convert.ToDecimal( textBox3.Text );
                PQU0104 = 0;
            }
            else if ( radioButton11.Checked )
            {
                PQU019 = "外购";
                if ( string.IsNullOrEmpty( textBox20.Text ) )
                    PQU0104 = 0;
                else
                    PQU0104 = Convert.ToDecimal( textBox20.Text );

                PQU018 = 0;
            }
            PQU020 = comboBox12.Text;
            PQU021 = comboBox10.Text;
            PQU022 = dateTimePicker3.Value;
            PQU023 = dateTimePicker4.Value;

        }
        void build ( )
        {
            DataTable dur = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQU WHERE PQU97=@PQU97 AND PQU10=@PQU10 AND PQU12=@PQU12" ,new SqlParameter( "@PQU97" ,PQU97 ) ,new SqlParameter( "@PQU10" ,PQU010 ) ,new SqlParameter( "@PQU12" ,PQU012 ) );
            if ( dur.Rows.Count < 1 )
            {
                int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQU (PQU10,PQU11,PQU12,PQU13,PQU14,PQU15,PQU16,PQU17,PQU18,PQU19,PQU20,PQU21,PQU22,PQU23,PQU97,PQU101,PQU100,PQU104,PQU03) VALUES (@PQU10,@PQU11,@PQU12,@PQU13,@PQU14,@PQU15,@PQU16,@PQU17,@PQU18,@PQU19,@PQU20,@PQU21,@PQU22,@PQU23,@PQU97,@PQU101,@PQU100,@PQU104,@PQU03)" ,new SqlParameter( "@PQU10" ,PQU010 ) ,new SqlParameter( "@PQU11" ,PQU011 ) ,new SqlParameter( "@PQU12" ,PQU012 ) ,new SqlParameter( "@PQU13" ,PQU013 ) ,new SqlParameter( "@PQU14" ,PQU014 ) ,new SqlParameter( "@PQU15" ,PQU015 ) ,new SqlParameter( "@PQU16" ,PQU016 ) ,new SqlParameter( "@PQU17" ,PQU017 ) ,new SqlParameter( "@PQU18" ,PQU018 ) ,new SqlParameter( "@PQU19" ,PQU019 ) ,new SqlParameter( "@PQU20" ,PQU020 ) ,new SqlParameter( "@PQU21" ,PQU021 ) ,new SqlParameter( "@PQU22" ,PQU022 ) ,new SqlParameter( "@PQU23" ,PQU023 ) ,new SqlParameter( "@PQU97" ,PQU97 ) ,new SqlParameter( "@PQU101" ,PQU0101 ) ,new SqlParameter( "@PQU100" ,PQU100 ) ,new SqlParameter( "@PQU104" ,PQU0104 ) ,new SqlParameter( "@PQU03" ,PQU03 ) );
                if ( count < 1 )
                    MessageBox.Show( "录入数据失败" );
                else
                {
                    MessageBox.Show( "成功录入数据" );
                    try
                    {
                        if ( label3.Visible == true )
                            stateOfOdd = "维护新建";
                        else
                        {
                            if ( sav == "1" )
                                stateOfOdd = "新增新建";
                            else
                                stateOfOdd = "更改新建";
                        }
                        StringBuilder strSql = new StringBuilder( );
                        strSql.AppendFormat( "INSERT INTO R_PQU (PQU10,PQU11,PQU12,PQU13,PQU14,PQU15,PQU16,PQU17,PQU18,PQU19,PQU20,PQU21,PQU22,PQU23,PQU97,PQU101,PQU100,PQU104,PQU03) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}')" ,PQU010 ,PQU011 ,PQU012 ,PQU013 ,PQU014 ,PQU015 ,PQU016 ,PQU017 ,PQU018 ,PQU019 ,PQU020 ,PQU021 ,PQU022 ,PQU023 ,PQU97 ,PQU0101 ,PQU100 ,PQU0104 ,PQU03 );
                        SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_343" ,"五金件(镀、烤漆)采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,PQU97 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"新建" ,stateOfOdd ) );
                    }
                    catch { }
                    finally
                    {
                        every( );
                        button13_Click( null ,null );
                    }
                }
            }
            else
                MessageBox.Show( "单号：" + PQU97 + "\n\r物料或部件名称：" + PQU010 + "\n\r的数据已经存在,请核实后再录入" );
        }
        void buildes ( )
        {
            DataTable da = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQU WHERE PQU100=@PQU100 AND PQU10=@PQU10 AND PQU12=@PQU12 AND PQU01='' AND PQU97=(SELECT MAX(PQU97) FROM R_PQU WHERE PQU100=@PQU100 AND PQU10=@PQU10 AND PQU12=@PQU12 AND PQU01='')" ,new SqlParameter( "@PQU100" ,PQU100 ) ,new SqlParameter( "@PQU10" ,PQU010 ) ,new SqlParameter( "@PQU11" ,PQU011 ) ,new SqlParameter( "@PQU12" ,PQU012 ) );
            if ( da.Rows.Count > 0 )
            {
                if ( da.Select( "PQU13='" + PQU013 + "'" ).Length <= 0 )
                    MessageBox.Show( "每套部件用量与计划不一致,应为:" + da.Rows[0]["PQU13"].ToString( ) + "" );
                else
                {
                    //if ( da.Select( "PQU15='" + PQU015 + "'" ).Length <= 0 )
                    //    MessageBox.Show( "原价与计划不一致,应为:" + da.Rows[0]["PQU15"].ToString( ) + "" );
                    //else
                    //{
                    if ( da.Select( "PQU16='" + PQU016 + "'" ).Length <= 0 )
                        MessageBox.Show( "现价与计划不一致,应为:" + da.Rows[0]["PQU16"].ToString( ) + "" );
                    else
                        build( );
                }
            }
            else
                build( );
        }
        void outSouces ( )
        {
            if ( radioButton10.Checked )
                MessageBox.Show( "只能开外购合同" );
            else
            {
                string sx = Math.Round( Convert.ToDecimal( Operation.MultiTwoTAdd( textBox53 ,textBox21 ,comboBox3 ) ) ,4 ).ToString( );
                if ( !string.IsNullOrEmpty( sx ) && !string.IsNullOrEmpty( textBox20.Text ) )
                {
                    if ( Convert.ToDecimal( sx ) != Convert.ToDecimal( textBox20.Text ) )
                        MessageBox.Show( "外购数量有误,请核实" );
                    else
                        buildes( );
                }
            }
        }
        void outSouce ( )
        {
            if ( radioButton10.Checked )
                MessageBox.Show( "只能开外购合同" );
            else
            {
                string sx = Math.Round( Convert.ToDecimal( Operation.MultiTwoTAdd( textBox53 ,textBox21 ,comboBox3 ) ) ,4 ).ToString( );
                if ( !string.IsNullOrEmpty( sx ) && !string.IsNullOrEmpty( textBox20.Text ) )
                {
                    if ( Convert.ToDecimal( sx ) != Convert.ToDecimal( textBox20.Text ) )
                        MessageBox.Show( "外购数量有误,请核实" );
                    else
                        build( );
                }
            }
        }
        void plan ( )
        {
            if ( radioButton11.Checked == true )
            {
                if ( Logins.number == "MLL-0001" )
                {
                    string sx = Math.Round( Convert.ToDecimal( Operation.MultiTwoTAdd( textBox53 ,textBox21 ,comboBox3 ) ) ,4 ).ToString( );
                    if ( !string.IsNullOrEmpty( sx ) && !string.IsNullOrEmpty( textBox20.Text ) )
                    {
                        if ( Convert.ToDecimal( sx ) != Convert.ToDecimal( textBox20.Text ) )
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
                if ( !string.IsNullOrEmpty( textBox19.Text ) && !string.IsNullOrEmpty( textBox3.Text ) )
                {
                    if ( Convert.ToDecimal( textBox19.Text ) < Convert.ToDecimal( textBox3.Text ) )
                        MessageBox.Show( "出库数量必须小于库存数量" );
                    //且出库数小于等于库存数量
                    else
                    {
                        string str = Math.Round( Convert.ToDecimal( Operation.MultiTwoTAdd( textBox53 ,textBox21 ,comboBox3 ) ) ,4 ).ToString( );
                        if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox3.Text ) )
                            MessageBox.Show( "出库数量有误,请核查" );
                        else
                            build( );
                    }
                }
            }
        }
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( comboBox6.Text ) )
            {
                MessageBox.Show( "货号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox16.Text ) )
            {
                MessageBox.Show( "合同批号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( PQU03 )  )
            {
                MessageBox.Show( "请选择供应商" );
                return;
            }
            if ( string.IsNullOrEmpty( gridLookUpEdit1.Text ) )
            {
                MessageBox.Show( "物料或部件名称不可为空" );
                return;
            }
            if ( radioButton10.Checked == false && radioButton11.Checked == false )
            {
                MessageBox.Show( "请选择外购或者库存" );
                return;
            }
            if ( dateTimePicker3.Value < MulaolaoBll . Drity . GetDt ( ).AddDays( 5 ) )
            {
                MessageBox.Show( "约定供期必须在当天的基础上延迟5天" );
                return;
            }
            getSet( );

            #region 计划  更改新建  无流水号
            if ( ord == "计划" || string.IsNullOrEmpty( textBox49.Text ) )
            {
                //计划可以开具多份
                //同货号、物料名称、规格是否已经开过计划订单
                DataTable yesNoAcPlan = SqlHelper.ExecuteDataTable( "SELECT AC03+ISNULL(AC26,0) AC03,AC18 FROM R_PQAC WHERE AC18=(SELECT MAX(AC18) FROM R_PQAC WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05)" ,new SqlParameter( "@AC02" ,PQU100 ) ,new SqlParameter( "@AC04" ,PQU010 ) ,new SqlParameter( "@AC05" ,PQU012 ) );
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
                            if ( PQU09.Length > 8 && PQU09.Substring( 0 ,8 ) == "MLL-0001" )
                                outSouces( );
                            else
                                MessageBox.Show( "此合同为补开,请找总经理处理" );
                        }
                    }
                    //无  只能开外购
                    else
                    {
                        //开合同人是否是MLL-0001
                        if ( PQU09.Length > 8 && PQU09.Substring( 0 ,8 ) == "MLL-0001" )
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
            else if ( ord == "实际" || !string.IsNullOrEmpty( textBox49.Text ) )
            {

                bool result = pc.PlanActual( PQU010 ,PQU012 ,PQU100 );
                bool vode = pc.PlanInDataBaseHardware( PQU01 ,PQU010 ,PQU012 );
                if ( result == true )
                {
                    if ( vode == true )
                        outSouce( );
                    else
                    {
                        if ( PQU09.Length > 8 && PQU09.Substring( 0 ,8 ) == "MLL-0001" )
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
                        if ( PQU09.Length > 8 && PQU09.Substring( 0 ,8 ) == "MLL-0001" )
                            plan( );
                        else
                            MessageBox.Show( "此单为超补,需要总经理处理" );
                    }
                }
            }
            #endregion
        }
        //编辑
        private void sucess ( )
        {
            //DataRow row;
            //int num = gridView1.FocusedRowHandle;
            //if ( sav == "1" )
            //{
            //    row = bi.Rows[num];
            //    row.BeginEdit( );
            //    row["PQU10"] = PQU010;
            //    row["PQU11"] = PQU011;
            //    row["PQU12"] = PQU012;
            //    row["PQU13"] = PQU013;
            //    row["PQU14"] = PQU014;
            //    row["PQU15"] = PQU015;
            //    row["PQU16"] = PQU016;
            //    row["PQU17"] = PQU017;
            //    row["PQU18"] = PQU018;
            //    row["PQU19"] = PQU019;
            //    row["PQU20"] = PQU020;
            //    row["PQU21"] = PQU021;
            //    row["PQU22"] = PQU022;
            //    row["PQU23"] = PQU023;
            //    row["PQU101"] = PQU0101;
            //    row["PQU104"] = PQU0104;
            //    row["PQU107"] = PQU1070;
            //    row.EndEdit( );
            //}
            //else if ( sav == "2" )
            //{
            //    row = dl.Rows[num];
            //    row.BeginEdit( );
            //    row["PQU10"] = PQU010;
            //    row["PQU11"] = PQU011;
            //    row["PQU12"] = PQU012;
            //    row["PQU13"] = PQU013;
            //    row["PQU14"] = PQU014;
            //    row["PQU15"] = PQU015;
            //    row["PQU16"] = PQU016;
            //    row["PQU17"] = PQU017;
            //    row["PQU18"] = PQU018;
            //    row["PQU19"] = PQU019;
            //    row["PQU20"] = PQU020;
            //    row["PQU21"] = PQU021;
            //    row["PQU22"] = PQU022;
            //    row["PQU23"] = PQU023;
            //    row["PQU101"] = PQU0101;
            //    row["PQU104"] = PQU0104;
            //    row["PQU107"] = PQU1070;
            //    row.EndEdit( );
            //}

            every( );
            button13_Click( null ,null );
        }
        void edit ( )
        {
            //PQU97=@PQU97 AND PQU10=@PQU10 AND PQU12=@PQU12
            int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQU SET PQU11=@PQU11,PQU13=@PQU13,PQU14=@PQU14,PQU15=@PQU15,PQU16=@PQU16,PQU17=@PQU17,PQU18=@PQU18,PQU19=@PQU19,PQU20=@PQU20,PQU21=@PQU21,PQU22=@PQU22,PQU23=@PQU23,PQU101=@PQU101,PQU104=@PQU104 WHERE PQU97=@PQU97 AND idx=@idx" /*,new SqlParameter( "@PQU97" ,PQU97 )*/ /*,new SqlParameter( "@PQU10" ,PQU010 )*/ ,new SqlParameter( "@PQU11" ,PQU011 ) /*,new SqlParameter( "@PQU12" ,PQU012 )*/ ,new SqlParameter( "@PQU13" ,PQU013 ) ,new SqlParameter( "@PQU14" ,PQU014 ) ,new SqlParameter( "@PQU15" ,PQU015 ) ,new SqlParameter( "@PQU16" ,PQU016 ) ,new SqlParameter( "@PQU17" ,PQU017 ) ,new SqlParameter( "@PQU18" ,PQU018 ) ,new SqlParameter( "@PQU19" ,PQU019 ) ,new SqlParameter( "@PQU20" ,PQU020 ) ,new SqlParameter( "@PQU21" ,PQU021 ) ,new SqlParameter( "@PQU22" ,PQU022 ) ,new SqlParameter( "@PQU23" ,PQU023 ) ,new SqlParameter( "@PQU101" ,PQU0101 ) ,new SqlParameter( "@PQU104" ,PQU0104 ) ,new SqlParameter( "@idx" ,id ) , new SqlParameter ( "@PQU97" , PQU97 ) );
            if ( count < 1 )
                MessageBox.Show( "编辑数据失败" );
            else
            {
                MessageBox.Show( "成功编辑数据" );
                try
                {
                    if ( label3.Visible == true )
                        stateOfOdd = "维护编辑";
                    else
                    {
                        if ( sav == "1" )
                            stateOfOdd = "新增编辑";
                        else
                            stateOfOdd = "更改编辑";
                    }
                    StringBuilder strSql = new StringBuilder( );//,PQU107='{14}'   ,PQU1070
                    strSql .AppendFormat( "UPDATE R_PQU SET PQU11='{0}',PQU13='{1}',PQU14='{2}',PQU15='{3}',PQU16='{4}',PQU17='{5}',PQU18='{6}',PQU19='{7}',PQU20='{8}',PQU21='{9}',PQU22='{10}',PQU23='{11}',PQU101='{12}',PQU104='{13}' WHERE PQU97='{14}' AND idx='{15}'" ,PQU011 ,PQU013 ,PQU014 ,PQU015 ,PQU016 ,PQU017 ,PQU018 ,PQU019 ,PQU020 ,PQU021 ,PQU022 ,PQU023 ,PQU0101 ,PQU0104 ,PQU97 ,id );
                    SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_343" ,"五金件(镀、烤漆)采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,PQU97 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"编辑" ,stateOfOdd ) );
                }
                catch { }
                finally { sucess( ); }
            }
        }
        void builds ( )
        {
            DataTable dop = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQU WHERE PQU97=@PQU97 AND PQU10=@PQU10 AND PQU12=@PQU12" ,new SqlParameter( "@PQU97" ,PQU97 ) ,new SqlParameter( "@PQU10" ,PQU010 ) ,new SqlParameter( "@PQU12" ,PQU012 ) );
            if ( dop.Rows.Count < 1 )
            {
                //PQU97=@PQU97 AND PQU10=@PQU010 AND PQU12=@PQU012  ,PQU107=@PQU107   ,new SqlParameter( "@PQU107" ,PQU1070 )
                int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQU SET PQU10=@PQU10,PQU11=@PQU11,PQU12=@PQU12,PQU13=@PQU13,PQU14=@PQU14,PQU15=@PQU15,PQU16=@PQU16,PQU17=@PQU17,PQU18=@PQU18,PQU19=@PQU19,PQU20=@PQU20,PQU21=@PQU21,PQU22=@PQU22,PQU23=@PQU23,PQU101=@PQU101,PQU104=@PQU104 WHERE PQU97=@PQU97 AND idx=@idx" /*,new SqlParameter( "@PQU97" ,PQU97 )*/ ,new SqlParameter( "@PQU10" ,PQU010 ) ,new SqlParameter( "@PQU11" ,PQU011 ) ,new SqlParameter( "@PQU12" ,PQU012 ) ,new SqlParameter( "@PQU13" ,PQU013 ) ,new SqlParameter( "@PQU14" ,PQU014 ) ,new SqlParameter( "@PQU15" ,PQU015 ) ,new SqlParameter( "@PQU16" ,PQU016 ) ,new SqlParameter( "@PQU17" ,PQU017 ) ,new SqlParameter( "@PQU18" ,PQU018 ) ,new SqlParameter( "@PQU19" ,PQU019 ) ,new SqlParameter( "@PQU20" ,PQU020 ) ,new SqlParameter( "@PQU21" ,PQU021 ) ,new SqlParameter( "@PQU22" ,PQU022 ) ,new SqlParameter( "@PQU23" ,PQU023 ) /*,new SqlParameter( "@PQU010" ,wp ) ,new SqlParameter( "@PQU012" ,gue )*/ ,new SqlParameter( "@PQU101" ,PQU0101 ) ,new SqlParameter( "@PQU104" ,PQU0104 ) ,new SqlParameter( "@idx" ,id ) , new SqlParameter ( "@PQU97" , PQU97 ) );
                if ( count < 1 )
                    MessageBox.Show( "编辑数据失败" );
                else
                {
                    MessageBox.Show( "成功编辑数据" );
                    try
                    {
                        if ( label3.Visible == true )
                            stateOfOdd = "维护编辑";
                        else
                        {
                            if ( sav == "1" )
                                stateOfOdd = "新增编辑";
                            else
                                stateOfOdd = "更改编辑";
                        }
                        StringBuilder strSql = new StringBuilder( );//,PQU107='{14}'   , PQU1070
                        strSql . AppendFormat ( "UPDATE R_PQU SET PQU11='{0}',PQU13='{1}',PQU14='{2}',PQU15='{3}',PQU16='{4}',PQU17='{5}',PQU18='{6}',PQU19='{7}',PQU20='{8}',PQU21='{9}',PQU22='{10}',PQU23='{11}',PQU101='{12}',PQU104='{13}' WHERE PQU97='{14}' AND idx='{15}'" , PQU011 , PQU013 , PQU014 , PQU015 , PQU016 , PQU017 , PQU018 , PQU019 , PQU020 , PQU021 , PQU022 , PQU023 , PQU0101 , PQU0104 ,PQU97 , id  );
                        SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_343" ,"五金件(镀、烤漆)采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,PQU97 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"编辑" ,stateOfOdd ) );
                    }
                    catch { }
                    finally
                    {
                        sucess( );
                    }
                }
            }
            else
                MessageBox.Show( "单号：" + PQU97 + "\n\r物料或部件名称：" + PQU010 + "\n\r规格:：" + PQU012 + "\n\r的数据已经存在,请核实后再编辑" );
        }
        void planOrActual ( )
        {
            if ( radioButton10.Checked )
            {
                if ( !string.IsNullOrEmpty( textBox19.Text ) && !string.IsNullOrEmpty( textBox3.Text ) )
                {
                    if ( Convert.ToDecimal( textBox19.Text ) < Convert.ToDecimal( textBox3.Text ) )
                        MessageBox.Show( "出库数量大于库存数量,请更改出库数量" );
                    else
                    {
                        string str = Math.Round( Convert.ToDecimal( Operation.MultiTwoTAdd( textBox53 ,textBox21 ,comboBox3 ) ) ,4 ).ToString( );
                        if ( !string.IsNullOrEmpty( str ) )
                        {
                            if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox3.Text ) )
                                MessageBox.Show( "出库数量有误,请核查" );
                            else
                                builds( );
                        }
                    }
                }
            }
            else
            {
                string str = Math.Round( Convert.ToDecimal( Operation. MultiTwoTbes ( textBox53 ,textBox21 ) ) ,4 ).ToString( );
                if ( !string.IsNullOrEmpty( str ) && !string.IsNullOrEmpty( textBox20.Text ) )
                {
                    if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox20.Text ) )
                        MessageBox.Show( "外购数量有误,请核查" );
                    else
                    {
                        if ( Logins.number == "MLL-0001" )
                            builds( );
                        else
                        {
                            if ( !string.IsNullOrEmpty( textBox19.Text ) && Convert.ToDecimal( textBox19.Text ) > 0 )
                                MessageBox.Show( "库存不为零,不能开外购合同" );
                            else
                                builds( );
                        }
                    }

                }
            }
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( comboBox6.Text ) )
            {
                MessageBox.Show( "货号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox16.Text ) )
            {
                MessageBox.Show( "合同批号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( gridLookUpEdit1.Text ) )
            {
                MessageBox.Show( "请选择物料或部件名称" );
                return;
            }
            if ( radioButton10.Checked == false && radioButton11.Checked == false )
            {
                MessageBox.Show( "请选择外购或者库存" );
                return;
            }
            getSet( );

            if ( PQU010 == wp && PQU012 == gue )
            {
                if ( radioButton10.Checked )
                {
                    if ( !string . IsNullOrEmpty ( textBox19 . Text ) && !string . IsNullOrEmpty ( textBox3 . Text ) )
                    {
                        if ( Convert . ToDecimal ( textBox19 . Text ) < Convert . ToDecimal ( textBox3 . Text ) )
                            MessageBox . Show ( "出库数量大于库存数量,请修改出库数量" );
                        else
                        {
                            string str = Math . Round ( Convert . ToDecimal ( Operation . MultiTwoTAdd ( textBox53 ,textBox21 ,comboBox3 ) ) ,4 ) . ToString ( );
                            if ( !string . IsNullOrEmpty ( str ) )
                            {
                                if ( Convert . ToDecimal ( str ) != Convert . ToDecimal ( textBox3 . Text ) )
                                    MessageBox . Show ( "出库数量有误,请核实" );
                                else
                                    edit ( );
                            }
                        }
                    }
                    //else
                    //{

                    //}
                }
                else
                {
                    string sx = Math.Round( Convert.ToDecimal( Operation.MultiTwoTAdd( textBox53 ,textBox21 ,comboBox3 ) ) ,4 ).ToString( );
                    if ( !string.IsNullOrEmpty( sx ) && !string.IsNullOrEmpty( textBox20.Text ) )
                    {
                        if ( Convert.ToDecimal( sx ) != Convert.ToDecimal( textBox20.Text ) )
                            MessageBox.Show( "外购数量有误,请核实" );
                        else
                        {
                            if ( Logins.number == "MLL-0001" )
                                edit( );
                            else
                            {
                                if ( !string.IsNullOrEmpty( textBox19.Text ) && textBox19.Text != "0" )
                                    MessageBox.Show( "库存不为零,不能开外购合同" );
                                else
                                    edit( );
                            }
                        }

                    }
                }
            }
            else
            {
                if ( ord == "计划" || string.IsNullOrEmpty( textBox49.Text ) )
                {
                    DataTable plan = SqlHelper.ExecuteDataTable( "SELECT AC03+ISNULL(AC26,0)-(SELECT SUM(AD05+ISNULL(AD20,0)) AD05 FROM R_PQAD  WHERE AC18=AD01) AD05  FROM R_PQAC WHERE AC18=(SELECT MAX(AC18) FROM R_PQAC WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05) GROUP BY AC03,AC18,ISNULL(AC26,0)" ,new SqlParameter( "@AC02" ,PQU100 ) ,new SqlParameter( "@AC04" ,PQU010 ) ,new SqlParameter( "@AC05" ,PQU012 ) );
                    if ( plan.Rows.Count > 0 && !string.IsNullOrEmpty( plan.Rows[0]["AD05"].ToString( ) ) && plan.Rows[0]["AD05"].ToString( ) != "0" )
                        //MessageBox.Show( "库存表中已经存在\n\r货号:" + PQU100 + "\n\r物料名称:" + PQU010 + "\n\r规格:" + PQU012 + "\n\r的记录,且入库数量大于出库数量。不允许新建此计划订单" );
                        planOrActual( );
                    else
                        planOrActual( );
                }
                else if ( ord == "实际" || !string.IsNullOrEmpty( textBox49.Text ) )
                {
                    //AND PQU05=@PQU05
                    DataTable dwo = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQU WHERE PQU01=@PQU01 AND PQU10=@PQU10 AND PQU12=@PQU12  AND PQU19=@PQU19" ,new SqlParameter( "@PQU10" ,PQU010 ) ,new SqlParameter( "@PQU12" ,PQU012 ) /*,new SqlParameter( "@PQU05" ,PQU05 )*/ ,new SqlParameter( "@PQU19" ,PQU019 ) ,new SqlParameter( "@PQU01" ,PQU01 ) );
                    if ( dwo.Rows.Count > 0 )
                    {
                        //开过的合同中是否包含此流水(针对可能合批)
                        for ( int k = 0 ; k < dwo.Rows.Count ; k++ )
                        {
                            if ( dwo.Rows[k]["PQU01"].ToString( ).Contains( PQU01 ) == true || PQU01.Contains( dwo.Rows[k]["PQU01"].ToString( ) ) == true )
                            {
                                if ( PQU09.Length > 8 && PQU09.Substring( 0 ,8 ) == "MLL-0001" )
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
        //删除
        private void dele ( )
        {      
            every ( );
            button13_Click( null ,null );
        }
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;
            PQU010 = gridLookUpEdit1.Text;
            PQU012 = textBox14.Text;
            if ( PQU010 == wp && PQU012 == gue )
            {
                int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQU WHERE PQU97=@PQU97 AND idx=@idx" ,new SqlParameter( "@idx" ,id ) , new SqlParameter ( "@PQU97" , PQU97 ) );
                if ( count < 1 )
                    MessageBox.Show( "删除数据失败" );
                else
                {
                    MessageBox.Show( "成功删除数据" );
                    try
                    {
                        if ( label3.Visible == true )
                            stateOfOdd = "维护删除";
                        else
                        {
                            if ( sav == "1" )
                                stateOfOdd = "新增删除";
                            else
                                stateOfOdd = "更改删除";
                        }
                        StringBuilder strSql = new StringBuilder( );
                        strSql.AppendFormat( "DELETE FROM R_PQU WHERE idx='{0}'" ,id );
                        SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_343" ,"五金件(镀、烤漆)采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,PQU97 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"删除" ,stateOfOdd ) );
                    }
                    catch { }
                    finally { dele( ); }
                }
            }
            else
            {
                DataTable dop = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQU WHERE PQU97=@PQU97 AND PQU10=@PQU10 AND PQU12=@PQU12" ,new SqlParameter( "@PQU97" ,PQU97 ) ,new SqlParameter( "@PQU10" ,PQU010 ) ,new SqlParameter( "@PQU12" ,PQU012 ) );
                if ( dop.Rows.Count > 0 )
                {
                    int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQU WHERE PQU97=@PQU97 AND idx=@idx" /*,new SqlParameter( "@PQU97" ,PQU97 ) ,new SqlParameter( "@PQU10" ,PQU010 ) ,new SqlParameter( "@PQU12" ,PQU012 )*/ ,new SqlParameter( "@idx" ,id ) , new SqlParameter ( "@PQU97" , PQU97 ) );
                    if ( count < 1 )
                        MessageBox.Show( "删除数据失败" );
                    else
                    {
                        MessageBox.Show( "成功删除数据" );
                        try
                        {
                            if ( label3.Visible == true )
                                stateOfOdd = "维护删除";
                            else
                            {
                                if ( sav == "1" )
                                    stateOfOdd = "新增删除";
                                else
                                    stateOfOdd = "更改删除";
                            }
                            StringBuilder strSql = new StringBuilder( );
                            strSql.AppendFormat( "DELETE FROM R_PQU WHERE idx='{0}'" ,id );
                            SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_343" ,"五金件(镀、烤漆)采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,PQU97 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"删除" ,stateOfOdd ) );
                        }
                        catch { }
                        finally { dele( ); }
                    }
                }
                else
                    MessageBox.Show( "不存在\n\r单号：" + PQU97 + "\n\r物料或部件名称：" + PQU010 + "\n\r规格：" + PQU012 + "\n\r的数据,请核实后再删除" );
            }
        }
        //Edit Batch
        SelectAll.NumberEditContract numQuery = new SelectAll.NumberEditContract( );
        private void button16_Click ( object sender ,EventArgs e )
        {
            numQuery.textBox1.Text = textBox53.Text;
            numQuery.StartPosition = FormStartPosition.CenterScreen;
            numQuery.PassDataBetweenForm += new SelectAll.NumberEditContract.PassDataBetweenFormHandler( numQuery_PassDataBetweenForm );
            numQuery.ShowDialog( );

            if ( numQu == "yes" )
            {
                if ( label3.Visible == true )
                    stateOfOdd = "维护批量编辑";
                else
                {
                    if ( sav == "1" )
                        stateOfOdd = "新增批量编辑";
                    else
                        stateOfOdd = "更改批量编辑";
                }
                /*textBox53 * textBox21 + comboBox3 - textBox19.Text*/
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    //model.PQU101 = string.IsNullOrEmpty( textBox53.Text ) == true ? 0 : Convert.ToInt64( textBox53.Text );
                    model.PQU13 = string.IsNullOrEmpty( gridView1.GetDataRow( i )["PQU13"].ToString( ) ) == true ? 0 : Convert.ToDecimal( gridView1.GetDataRow( i )["PQU13"].ToString( ) );
                    model.PQU14 = string.IsNullOrEmpty( gridView1.GetDataRow( i )["PQU14"].ToString( ) ) == true ? 0 : Convert.ToInt32( gridView1.GetDataRow( i )["PQU14"].ToString( ) );
                    model.PQU19 = gridView1.GetDataRow( i )["PQU19"].ToString( );
                    if ( model.PQU19 == "外购" )
                    {
                        model.PQU18 = PQU018 = 0;
                        model . PQU104 = PQU0104 = Math . Round ( Convert . ToDecimal ( model . PQU101 * model . PQU13 + model . PQU14 ) ,0 );
                    }
                    else if ( model.PQU19 == "库存" )
                    {
                        model.PQU104 = PQU0104 = 0;
                        model . PQU18 = PQU018 = Math . Round ( Convert . ToDecimal ( model . PQU101 * model . PQU13 + model . PQU14 ) ,0 );
                    }
                    else
                    {
                       model.PQU104= PQU0104 = 0;
                      model.PQU18=  PQU018 = 0;
                    }
                    model.IDX = string.IsNullOrEmpty( gridView1.GetDataRow( i )["idx"].ToString( ) ) == true ? 0 : Convert.ToInt32( gridView1.GetDataRow( i )["idx"].ToString( ) );
                    result = bll.UpdateBatch( model ,"R_343" ,"五金件(镀、烤漆)采购合同书" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,PQU97 ,"批量编辑" ,stateOfOdd );
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
            model.PQU101 = string.IsNullOrEmpty( e.ConOne ) == true ? 0 : Convert.ToInt64( e.ConOne );
        }
        //刷新
        private void button13_Click ( object sender ,EventArgs e )
        {
            dl = SqlHelper.ExecuteDataTable( "SELECT idx,PQU10,PQU101,PQU11,PQU12,PQU13,PQU14,PQU15,PQU16,PQU17,PQU18,PQU19,PQU20,PQU21,PQU22,PQU23,PQU104,PQU109,PQU110 FROM R_PQU WHERE PQU97=@PQU97 ORDER BY idx DESC" ,new SqlParameter( "@PQU97" ,PQU97 ) );
            gridControl1.DataSource = dl;

            every ( );
        }
        //实际收货日期
        yanpinSelect ys = new yanpinSelect( );
        private void button14_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox.Show( "流水号:" + PQU01 + "\n\r物料名称:" + gridLookUpEdit1.Text + "\n\r部件规格:" +textBox14.Text + "\n\r已经到货？" ,"提示" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
            {
                ys.ysOne = PQU97;
                ys.ysTwo = gridLookUpEdit1.Text;
                ys.ysThr = textBox14.Text;
                ys.ysFou = "";
                ys.ysFiv = "";
                ys.ysSix = "R_340";
                ys.StartPosition = FormStartPosition.CenterScreen;
                ys.ShowDialog( );
            }
        }
        #endregion    

    }
}
