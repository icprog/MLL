using StudentMgr;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Mulaolao.Class;
using Mulaolao.Bom;
using Mulaolao.Raw_material_cost;
using FastReport;
using FastReport.Export.Xml;
using Mulaolao.Schedule_control;
using Mulaolao.Other;
using System.Linq;
using Mulaolao.Contract.yesOrNoPlan;
using System.Text;
using System.Collections.Generic;

namespace Mulaolao.Contract
{
    public partial class R_Frmwaixiancontract : FormChild
    {
        public R_Frmwaixiancontract (/*Form fm*/ )
        {
            //this.MdiParent = fm;
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { bandedGridView1 ,View1 } );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . bandedGridView1 ,View1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }
        
        MulaolaoLibrary.WaiXianContractLibrary model = new MulaolaoLibrary.WaiXianContractLibrary( );
        MulaolaoBll.Bll.WaiXiancontractBll bll = new MulaolaoBll.Bll.WaiXiancontractBll( );
        Youqicaigou yu = new Youqicaigou( );
        DataTable bj, wpmc, biao, name,partTable;
        Report report = new Report( );
        DataSet RDataSet;
        Factory fc = new Factory( );
        SpecialPowers sp = new SpecialPowers( );
        yesOrNoPlanActual pc = new yesOrNoPlanActual( );
        string copy = "", file = "", numQu = "", stateOfOdd = "";
        int printCount=0;
        List<SplitContainer> spList = new List<SplitContainer>( ); List<TabPage> pageList = new List<TabPage>( );
        
        private void R_Frmwaixiancontract_Load ( object sender ,EventArgs e )
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

            textBox28.Enabled = false;

            label83.Visible = false;
            label98.Visible = false;

            name = bll.GetDataTablePerson( );
            lookUpEdit1.Properties.DataSource = name;
            lookUpEdit1.Properties.DisplayMember = "DBA002";
            lookUpEdit1.Properties.ValueMember = "DBA001";

            lookUpEdit2.Properties.DataSource = bll.GetDataTableWork( );
            lookUpEdit2.Properties.DisplayMember = "DBA002";
            lookUpEdit2.Properties.ValueMember = "DBA001";

            anOther( );

            comboBox10.Items.Clear( );
            comboBox10.Items.Add( "包装辅料" );
            comboBox10.Items.Add( "外箱" );
            comboBox10.Items.Add( "中包" );
            comboBox10.Items.Add( "内盒" );
            comboBox10.Items.Add( "彩盒" );

            if ( Logins . number == "MLL-0001" )
                checkBox13 . Visible = true;
            else
                checkBox13 . Visible = false;
        }

        private void R_Frmwaixiancontract_Shown ( object sender ,EventArgs e )
        {
            WX82 = Merges.oddNum;
            if ( !string.IsNullOrEmpty( WX82 ) )
                autoQuery( );
            Merges.oddNum = "";
        }

        #region Print
        private void CreateDataset ( int startIndex,int endIndex )
        {
            RDataSet = new DataSet( );

            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "WITH CET AS (SELECT ROW_NUMBER() OVER(ORDER BY WX82) ROW,WX10,WX20,WX77,WX86,WX14,WX18,WX19,WX12,WX13,CASE WHEN WX86 = 0 THEN 0 WHEN WX10='双瓦外箱' THEN CONVERT( DECIMAL( 11, 2 ), ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 / WX86 )WHEN WX10='小箱式' THEN CONVERT( DECIMAL( 11, 2 ), ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 / WX86 )WHEN WX10='牙膏式' THEN CONVERT( DECIMAL( 11, 2 ), ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 / WX86 )WHEN WX10='插口式' THEN CONVERT( DECIMAL( 11, 2 ), ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 / WX86 )WHEN WX10='天盖' THEN CONVERT( DECIMAL( 11, 2 ), ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 / WX86 )WHEN WX10='地盖' THEN CONVERT( DECIMAL( 11, 2 ), ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 / WX86 )WHEN WX10='折叠式' THEN CONVERT( DECIMAL( 11, 2 ), ((2*WX27 + 2*WX28 + WX29) * (1.5*WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 / WX86 )WHEN WX10 NOT IN ('双瓦外箱','小箱式','牙膏式','插口式','天盖','地盖','折叠式') THEN CONVERT( DECIMAL( 11, 2 ), ((WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 / WX86 )END U0,CASE  WHEN WX10='双瓦外箱' THEN CONVERT( DECIMAL( 11, 2 ), ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13 ) WHEN WX10='小箱式' THEN CONVERT( DECIMAL( 11, 2 ), ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13) WHEN WX10='牙膏式' THEN CONVERT( DECIMAL( 11, 2 ), ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13 )WHEN WX10='插口式' THEN CONVERT( DECIMAL( 11, 2 ), ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13 )WHEN WX10='天盖' THEN CONVERT( DECIMAL( 11, 2 ), ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13 )WHEN WX10='地盖' THEN CONVERT( DECIMAL( 11, 2 ), ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13 )WHEN WX10='折叠式' THEN CONVERT( DECIMAL( 11, 2 ), ((2*WX27 + 2*WX28 + WX29) * (1.5*WX30 + WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13 )WHEN WX10 NOT IN ('双瓦外箱','小箱式','牙膏式','插口式','天盖','地盖','折叠式') THEN CONVERT( DECIMAL( 11, 2 ), (WX23 + WX24) * (WX25 + WX26) * 0.0001 * WX13)END U1,WX15,CASE WHEN WX10='双瓦外箱' THEN ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='小箱式' THEN ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32) + (WX23 + WX24) * (WX25 + WX26)) * 0.0001 * WX13 * WX15 WHEN WX10='牙膏式' THEN ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='插口式' THEN ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='天盖' THEN ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='地盖' THEN ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10='折叠式' THEN ((2*WX27 + 2*WX28 + WX29) * (1.5*WX30 + WX31 + WX32) +(WX23 + WX24) * (WX25 + WX26)) * 0.0001*WX13* WX15 WHEN WX10 NOT IN ('双瓦外箱','小箱式','牙膏式','插口式','天盖','地盖','折叠式') THEN (WX23 + WX24) * (WX25 + WX26) * 0.0001 * WX13* WX15 END  U2,WX17,CONVERT( VARCHAR( 20 ), WX21, 102 ) WX21,CONVERT( VARCHAR( 20 ), WX22, 102 ) WX22,WX11, WX27, WX28, WX29,CASE WHEN WX10='双瓦外箱' THEN CONVERT( DECIMAL( 11, 1 ), WX27 + WX28 + WX29 ) WHEN WX10='小箱式' THEN CONVERT( DECIMAL( 11, 1 ), WX27 + WX28 + WX29 )  WHEN WX10='牙膏式' THEN CONVERT( DECIMAL( 11, 1 ), WX27 + 2*WX28 + WX29 )  WHEN WX10='插口式' THEN CONVERT( DECIMAL( 11, 1 ), WX27 + 2*WX28 + WX29 )  WHEN WX10='天盖' THEN CONVERT( DECIMAL( 11, 1 ), WX27 + 2*WX28 + WX29 ) WHEN WX10='地盖' THEN CONVERT( DECIMAL( 11, 1 ), WX27 + 2*WX28 + WX29 )  WHEN WX10='折叠式' THEN CONVERT( DECIMAL( 11, 1 ), 2*WX27 + 2*WX28 + WX29 )  WHEN WX10 NOT IN ('双瓦外箱','小箱式','牙膏式','插口式','天盖','地盖','折叠式') THEN 0 END U3,WX30, WX31, WX32, CASE WHEN WX10='双瓦外箱' THEN CONVERT( DECIMAL( 11, 1 ), WX30 + WX31 + WX32 )  WHEN WX10='小箱式' THEN CONVERT( DECIMAL( 11, 1 ), WX30 + WX31 + WX32 ) WHEN WX10='牙膏式' THEN CONVERT( DECIMAL( 11, 1 ), 2*WX30 + 2*WX31 + WX32 )  WHEN WX10='插口式' THEN CONVERT( DECIMAL( 11, 1 ), 2*WX30 + 2*WX31 + WX32 ) WHEN WX10='折叠式' THEN CONVERT( DECIMAL( 11, 1 ), 1.5*WX30 + WX31 + WX32 ) WHEN WX10='天盖' THEN CONVERT( DECIMAL( 11, 1 ), WX30 + 2*WX31 + WX32 ) WHEN WX10='地盖' THEN CONVERT( DECIMAL( 11, 1 ), WX30 + 2*WX31 + WX32 )  WHEN WX10 NOT IN ('双瓦外箱','小箱式','牙膏式','插口式','天盖','地盖','折叠式') THEN 0 END U4,CASE WHEN WX10='双瓦外箱' THEN CONVERT( DECIMAL( 11, 4 ), ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32)) * 0.0001 ) WHEN WX10='小箱式' THEN CONVERT( DECIMAL( 11, 4 ), ((WX27 + WX28 + WX29) * (WX30 + WX31 + WX32)) * 0.0001 ) WHEN WX10='牙膏式' THEN CONVERT( DECIMAL( 11, 4 ), ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32)) * 0.0001 ) WHEN WX10='插口式' THEN CONVERT( DECIMAL( 11, 4 ), ((WX27 + 2*WX28 + WX29) * (2*WX30 + 2*WX31 + WX32)) * 0.0001 ) WHEN WX10='天盖' THEN CONVERT( DECIMAL( 11, 4 ), ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32)) * 0.0001 ) WHEN WX10='地盖' THEN CONVERT( DECIMAL( 11, 4 ), ((WX27 + 2*WX28 + WX29) * (WX30 + 2*WX31 + WX32)) * 0.0001 ) WHEN WX10='折叠式' THEN CONVERT( DECIMAL( 11, 4 ), ((2*WX27 + 2*WX28 + WX29) * (1.5*WX30 + WX31 + WX32)) * 0.0001 )  WHEN WX10 NOT IN ('双瓦外箱','小箱式','牙膏式','插口式','天盖','地盖','折叠式') THEN 0 END U5,WX23, WX24, WX25, WX26,CONVERT( DECIMAL( 11, 4 ), ((WX23 + WX24) * (WX25 + WX26)) * 0.0001 ) U6 FROM R_PQT WHERE WX82 ='{0}') " ,WX82 );
            strSql . AppendFormat ( " SELECT * FROM CET WHERE ROW BETWEEN {0} AND {1}" ,startIndex ,endIndex );

            DataTable print = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );
            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "with cet as(SELECT ROW_NUMBER() OVER(ORDER BY WX82) ROW,DBA002,DBA028,DGA003,DGA017,DGA008,DGA009,DGA011,WX05,CONVERT(VARCHAR(20),WX06,102) WX06,WX07,CONVERT(VARCHAR(20),WX08,102) WX08,WX09, WX83, WX84, WX85, WX01, WX78, WX79, WX33, CONVERT( VARCHAR( 20 ), WX34, 102 ) WX34, WX35, WX36, WX37, WX38, WX41, WX39, WX40, WX51, WX42, WX43, WX44, WX45, WX46, WX47, WX48,WX49, WX50, WX52, WX53, WX54, CONVERT( VARCHAR( 20 ), WX55, 102 ) WX55, WX68, WX69, WX70, CONVERT( VARCHAR( 20 ), WX71, 102 ) WX71, WX72, CONVERT( VARCHAR( 20 ), WX73, 102 ) WX73,WX74, WX75, CONVERT( VARCHAR( 20 ), WX76, 102 ) WX76,WX91,WX82,ISNULL(WX90,0) WX90 FROM R_PQT A, TPADBA B, TPADGA C WHERE A.WX02 = B.DBA001 AND A.WX03 = C.DGA001 AND WX82 ='{0}')" ,WX82 );
            strSql . AppendFormat ( " select * from cet where ROW between {0} and {1}" ,startIndex ,endIndex );

            DataTable prints = SqlHelper . ExecuteDataTable ( strSql . ToString ( ) );

            print.TableName = "R_PQT";
            prints.TableName = "R_PQTS";
            RDataSet.Tables.Add( print );
            RDataSet.Tables.Add( prints );
        }
        #endregion

        #region Query
        void queryContent ( )
        {
            #region
            DataTable de = SqlHelper.ExecuteDataTable( "SELECT TOP 1 *,(SELECT DBA002 FROM TPADBA WHERE WX02=DBA001) DBA002 FROM R_PQT WHERE WX82=@WX82" ,new SqlParameter( "@WX82" ,WX82 ) );
            if ( de.Rows.Count > 0 )
            {
                lookUpEdit1.Text = de.Rows[0]["DBA002"].ToString( );
                textBox7.Text = de.Rows[0]["WX01"].ToString( );
                textBox1.Text =WX03= de.Rows[0]["WX03"].ToString( );
                comboBox7.Text = de.Rows[0]["WX83"].ToString( );
                textBox10.Text = de.Rows[0]["WX84"].ToString( );
                comboBox21.Text = de.Rows[0]["WX85"].ToString( );
                textBox8.Text = de.Rows[0]["WX86"].ToString( );
                lookUpEdit2.Text = de.Rows[0]["WX91"].ToString( );
                if ( !string . IsNullOrEmpty ( de . Rows [ 0 ] [ "WX04" ] . ToString ( ) ) )
                    dateTimePicker1 . Value = Convert . ToDateTime ( de . Rows [ 0 ] [ "WX04" ] . ToString ( ) );
                else
                    dateTimePicker1 . Value = DateTime . Now;
                textBox12.Text = de.Rows[0]["WX05"].ToString( );
                if ( !string.IsNullOrEmpty( de.Rows[0]["WX06"].ToString( ) ) )
                    dateTimePicker3.Value = Convert.ToDateTime( de.Rows[0]["WX06"].ToString( ) );
                else
                    dateTimePicker3 . Value = DateTime . Now;
                textBox11 .Text = de.Rows[0]["WX07"].ToString( );
                if ( !string.IsNullOrEmpty( de.Rows[0]["WX08"].ToString( ) ) )
                    dateTimePicker2.Value = Convert.ToDateTime( de.Rows[0]["WX08"].ToString( ) );
                else
                    dateTimePicker2 . Value = DateTime . Now;
                textBox14 .Text = de.Rows[0]["WX09"].ToString( );
                textBox13.Text = de.Rows[0]["WX78"].ToString( );
                textBox16.Text = de.Rows[0]["WX79"].ToString( );
                comboBox23.Text = de.Rows[0]["WX33"].ToString( );
                if ( !string.IsNullOrEmpty( de.Rows[0]["WX34"].ToString( ) ) )
                    dateTimePicker6.Value = Convert.ToDateTime( de.Rows[0]["WX34"].ToString( ) );
                else
                    dateTimePicker6 . Value = DateTime . Now;
                if ( de.Rows[0]["WX35"].ToString( ).Trim( ) == "在内" )
                {
                    radioButton1.Checked = true;
                }
                else if ( de.Rows[0]["WX35"].ToString( ).Trim( ) == "不在内" )
                {
                    radioButton2.Checked = true;
                }
                if ( de.Rows[0]["WX36"].ToString( ).Trim( ) == "有" )
                {
                    radioButton3.Checked = true;
                }
                else if ( de.Rows[0]["WX36"].ToString( ).Trim( ) == "没有" )
                {
                    radioButton4.Checked = true;
                }
                if ( de.Rows[0]["WX37"].ToString( ).Trim( ) == "已检测" )
                {
                    radioButton6.Checked = true;
                    textBox50.Text = de.Rows[0]["WX38"].ToString( );
                }
                else if ( de.Rows[0]["WX37"].ToString( ).Trim( ) == "未检测" )
                {
                    radioButton5.Checked = true;
                }
                textBox55.Text = de.Rows[0]["WX39"].ToString( );
                if ( de.Rows[0]["WX40"].ToString( ).Trim( ) == "合格" )
                {
                    radioButton7.Checked = true;
                }
                else if ( de.Rows[0]["WX40"].ToString( ).Trim( ) == "条件接收" )
                {
                    radioButton8.Checked = true;
                    textBox54.Text = de.Rows[0]["WX51"].ToString( );
                }
                else if ( de.Rows[0]["WX40"].ToString( ).Trim( ) == "退货" )
                {
                    radioButton9.Checked = true;
                }
                comboBox24.Text = de.Rows[0]["WX41"].ToString( );
                textBox21.Text = de.Rows[0]["WX42"].ToString( );
                textBox20.Text = de.Rows[0]["WX43"].ToString( );
                textBox19.Text = de.Rows[0]["WX44"].ToString( );
                textBox24.Text = de.Rows[0]["WX45"].ToString( );
                textBox23.Text = de.Rows[0]["WX46"].ToString( );
                textBox22.Text = de.Rows[0]["WX47"].ToString( );
                textBox65.Text = de.Rows[0]["WX48"].ToString( );
                textBox17.Text = de.Rows[0]["WX49"].ToString( );
                textBox18.Text = de.Rows[0]["WX50"].ToString( );
                comboBox25.Text = de.Rows[0]["WX52"].ToString( );
                comboBox26.Text = de.Rows[0]["WX53"].ToString( );
                comboBox27.Text = de.Rows[0]["WX54"].ToString( );
                if ( !string.IsNullOrEmpty( de.Rows[0]["WX55"].ToString( ) ) )
                    dateTimePicker7.Value = Convert.ToDateTime( de.Rows[0]["WX55"].ToString( ) );
                else
                    dateTimePicker7 . Value = DateTime . Now;
                if ( de.Rows[0]["WX56"].ToString( ).Trim( ) == "T" )
                {
                    checkBox1.Checked = true;
                }
                if ( de.Rows[0]["WX57"].ToString( ).Trim( ) == "T" )
                {
                    checkBox2.Checked = true;
                }
                if ( de.Rows[0]["WX58"].ToString( ).Trim( ) == "T" )
                {
                    checkBox4.Checked = true;
                }
                if ( de.Rows[0]["WX59"].ToString( ).Trim( ) == "T" )
                {
                    checkBox3.Checked = true;
                }
                if ( de.Rows[0]["WX60"].ToString( ).Trim( ) == "T" )
                {
                    checkBox5.Checked = true;
                }
                if ( de.Rows[0]["WX61"].ToString( ).Trim( ) == "T" )
                {
                    checkBox6.Checked = true;
                }
                if ( de.Rows[0]["WX62"].ToString( ).Trim( ) == "T" )
                {
                    checkBox10.Checked = true;
                }
                if ( de.Rows[0]["WX63"].ToString( ).Trim( ) == "T" )
                {
                    checkBox9.Checked = true;
                }
                if ( de.Rows[0]["WX64"].ToString( ).Trim( ) == "T" )
                {
                    checkBox8.Checked = true;
                }
                if ( de.Rows[0]["WX65"].ToString( ).Trim( ) == "T" )
                {
                    checkBox7.Checked = true;
                }
                if ( de.Rows[0]["WX66"].ToString( ).Trim( ) == "T" )
                {
                    checkBox11.Checked = true;
                }
                if ( de.Rows[0]["WX67"].ToString( ).Trim( ) == "T" )
                {
                    checkBox12.Checked = true;
                    textBox69.Text = de.Rows[0]["WX68"].ToString( );
                }
                textBox78.Text = de.Rows[0]["WX69"].ToString( );
                textBox77.Text = de.Rows[0]["WX70"].ToString( );
                if ( !string.IsNullOrEmpty( de.Rows[0]["WX71"].ToString( ) ) )
                    dateTimePicker8.Value = Convert.ToDateTime( de.Rows[0]["WX71"].ToString( ) );
                else
                    dateTimePicker8 . Value = DateTime . Now;
                textBox75 .Text = de.Rows[0]["WX72"].ToString( );
                if ( !string.IsNullOrEmpty( de.Rows[0]["WX73"].ToString( ) ) )
                    dateTimePicker9.Value = Convert.ToDateTime( de.Rows[0]["WX73"].ToString( ) );
                else
                    dateTimePicker9 . Value = DateTime . Now;
                textBox71 .Text = de.Rows[0]["WX74"].ToString( );
                textBox73.Text = de.Rows[0]["WX75"].ToString( );
                if ( !string.IsNullOrEmpty( de.Rows[0]["WX76"].ToString( ) ) )
                    dateTimePicker10.Value = Convert.ToDateTime( de.Rows[0]["WX76"].ToString( ) );
                else
                    dateTimePicker10 . Value = DateTime . Now;
                textBox28 .Text = de.Rows[0]["WX80"].ToString( );
                if ( de.Rows[0]["WX89"].ToString( ).Trim( ) == "复制" )
                    label98.Visible = true;
                else
                    label98.Visible = false;
                checkBox13 . Checked = de . Rows [ 0 ] [ "WX90" ] . ToString ( ) . Trim ( ) == "T" ? true : false;
                #endregion
                //,WX90
                //bj = SqlHelper.ExecuteDataTable( "SELECT idx,WX10,WX11,WX12,WX13,WX14,WX15,WX16,WX17,WX18,WX19,WX20,WX21,WX22,WX23,WX24,WX25,WX26,WX27,WX28,WX29,WX30,WX31,WX32,WX77,WX86,WX87,U3,U4,WX03 FROM R_PQT WHERE WX82=@WX82 ORDER BY idx DESC" ,new SqlParameter( "@WX82" ,WX82 ) );
                //gridControl1.DataSource = bj;

                //assginContrac( );


                button14_Click ( null ,null );
            }
        }
        void autoQuery ( )
        {
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableFalse( pageList );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;

            textBox28.Enabled = false;

            sav = "2";
            ord = "";
            queryContent( );
        }
        string WX010 = "", WX011 = "";
        //查询
        SelectAll.WaiXiancontractAll query = new SelectAll.WaiXiancontractAll( );
        protected override void select ( )
        {
            base.select( );

            //model = new MulaolaoLibrary.WaiXianContractLibrary( );
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.WaiXiancontractAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );

            if ( WX82 == "" )
                MessageBox.Show( "您没有选择任何信息" );
            else
                autoQuery( );
        }
        private void query_PassDataBetweenForm ( Object sender ,PassDataWinFormEventArgs e )
        {
            WX83 = e.ConOne;
            comboBox7.Text = e.ConOne;
            WX84 = e.ConTwo;
            textBox10.Text = e.ConTwo;
            WX01 = e.ConTre;
            textBox7.Text = e.ConTre;
            //WX02 = e.ConFor;
            //lookUpEdit1.Text = e.ConFiv;
            WX03 = e.ConSix;
            textBox1.Text = e.ConSev;
            if ( e.ConEgi == "执行" )
                label83.Visible = true;
            else
                label83.Visible = false;
            WX82 = e.ConNin;
            WX85 = e.ConTen;
            comboBox21.Text = e.ConTen;
            if ( string.IsNullOrEmpty( e.ConEleven ) )
                WX086 = 0;
            else
                WX086 = Convert.ToInt64( e.ConEleven );
            textBox8.Text = e.ConEleven;
        }
        R_FrmTPADGA tpadga = new R_FrmTPADGA( );
        //供应商查询
        private void button4_Click ( object sender ,EventArgs e )
        {
            DataTable did = SqlHelper.ExecuteDataTable( "SELECT DGA001,DGA003,DGA008,DGA011,DGA017,DGA009 FROM TPADGA WHERE DGA052='F'" );
            if ( did.Rows.Count < 1 )
            {
                MessageBox.Show( "没有供应商信息" );
            }
            else
            {
                tpadga.gridControl2.DataSource = did;
                tpadga.st = "4";
                tpadga.Text = "R_349 信息查询";
                tpadga.PassDataBetweenForm += new R_FrmTPADGA.PassDataBetweenFomrHandler( tpadga_PassDataBetweenForm );
                tpadga.StartPosition = FormStartPosition.CenterScreen;
                tpadga.ShowDialog( );
            }
        }
        private void tpadga_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            WX03 = e.ConOne;
            textBox1.Text = e.ConTwo;
            textBox5.Text = e.ConSix;
            textBox33.Text = e.ConTre;
            textBox6.Text = e.ConFor;
            textBox4.Text = e.ConFiv;
        }
        Youqicaigou yq = new Youqicaigou( );
        //流水号查询
        private void button5_Click ( object sender ,EventArgs e )
        {
            DataTable dhr = SqlHelper.ExecuteDataTable( "SELECT PQF01,PQF02,PQF03,PQF04,PQF06 FROM R_PQF A,R_REVIEWS B,R_MLLCXMC C WHERE A.PQF01 = B.RES06 AND B.RES01 = C.CX01 AND C.CX02 = '订单销售合同(R_001)' AND RES05 = '执行' ORDER BY PQF01 DESC" );
            if ( dhr.Rows.Count < 1 )
                MessageBox.Show( "没有产品信息" );
            else
            {
                dhr.Columns.Add( "check" ,System.Type.GetType( "System.Boolean" ) );
                yq.gridControl1.DataSource = dhr;
                yq.sy = "8";
                yq.Text = "R_349 信息查询";
                yq.PassDataBetweenForm += new Youqicaigou.PassDataBetweenFormHandler( yq_PassDataBetweenForm );
                yq.StartPosition = FormStartPosition.CenterScreen;
                yq.ShowDialog( );
            }
        }
        private void yq_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            WX01 = e.ConOne;
            textBox7.Text = e.ConOne;
            if ( e.ConTwo.IndexOf( "," ) > 0 )
                textBox10.Text = string.Join( "," ,e.ConTwo.Split( ',' ).Distinct( ).ToArray( ) );
            else
                textBox10.Text = e.ConTwo;
            WX84 = textBox10.Text;
            if ( e.ConTre.IndexOf( "," ) > 0 )
                comboBox21.Text = string.Join( "," ,e.ConTre.Split( ',' ).Distinct( ).ToArray( ) );
            else
                comboBox21.Text = e.ConTre;
            WX85 = comboBox21.Text;
            if ( e.ConFor.IndexOf( "," ) > 0 )
                comboBox7.Text = string.Join( "," ,e.ConFor.Split( ',' ).Distinct( ).ToArray( ) );
            else
                comboBox7.Text = e.ConFor;
            WX83 = comboBox7.Text;
            textBox8.Text = e.ConFiv;
            if ( string.IsNullOrEmpty( e.ConFiv ) )
                WX086 = 0;
            else
                WX086 = Convert.ToInt64( e.ConFiv );
        }
        //计划
        planeQuery pq = new planeQuery( );
        private void button16_Click ( object sender ,EventArgs e )
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
            textBox7.Text = "";
            WX83 = e.ConOne;
            comboBox7.Text = e.ConOne;
            WX85 = e.ConTwo;
            comboBox21.Text = e.ConTwo;
            if ( !string.IsNullOrEmpty( e.ConTre ) )
                WX086 = Convert.ToInt64( e.ConTre );
            else
                WX086 = 0;
            textBox8.Text = e.ConTre;
            textBox10.Text = "";
        }
        //物品名称查询
        R_FrmPQP pqp = new R_FrmPQP( );
        private void button6_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( WX01 ) )
                MessageBox.Show( "流水号不可为空" );
            else
            {
                DataTable dee = SqlHelper.ExecuteDataTable( "SELECT DISTINCT GS56,GS57,GS58 FROM R_PQP A,R_REVIEWS B,R_MLLCXMC C WHERE A.GS34=B.RES06 AND B.RES01=C.CX01 AND RES05='执行' AND CX02='产品每套成本改善控制表(R_509)' AND GS56 IS NOT NULL AND GS56!='' AND GS01=@GS01" ,new SqlParameter( "@GS01" ,WX01 ) );
                if ( dee.Rows.Count < 1 )
                    MessageBox.Show( "[产品每套成本改善控制表(R_509)]没有已经执行的信息,请录入或送审操作" );
                else
                {
                    pqp.gridControl1.DataSource = dee;
                    pqp.pqstr = "5";
                    pqp.Text = "R_349 信息查询";
                    pqp.PassDataBetweenForm += new R_FrmPQP.PassDataBetweenFormHandler( pqp_PassDataBetweenForm );
                    pqp.StartPosition = FormStartPosition.CenterScreen;
                    pqp.ShowDialog( );
                }
            }
        }
        private void pqp_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            WX010 = e.ConOne;
            Edit1.Text = e.ConOne;
            WX011 = e.ConTwo;
            txtSpe.Text = e.ConTwo;
            WX019 = e.ConTre;
            comboBox22.Text = e.ConTre;
        }
        #endregion

        #region Main
        string sav = "", weihu = "";
        string WX01 = "", WX02 = "", WX03 = "", WX05 = "", WX07 = "", WX09 = "", WX33 = "", WX35 = "", WX36 = "", WX37 = "", WX38 = "", WX40 = "", WX41 = "", WX51 = "", WX52 = "", WX53 = "", WX54 = "", WX56 = "", WX57 = "", WX58 = "", WX59 = "", WX60 = "", WX61 = "", WX62 = "", WX63 = "", WX64 = "", WX65 = "", WX66 = "", WX67 = "", WX68 = "", WX69 = "", WX70 = "", WX72 = "", WX74 = "", WX75 = "", WX78 = "", WX79 = "", WX80 = "", WX81 = "", WX82 = "", WX83 = "", WX84 = "", WX85 = "", WX91 = "",WX090="";
        DateTime WX04 = MulaolaoBll . Drity . GetDt ( ), WX06 = MulaolaoBll . Drity . GetDt ( ), WX08 = MulaolaoBll . Drity . GetDt ( ), WX34 = MulaolaoBll . Drity . GetDt ( ), WX55 = MulaolaoBll . Drity . GetDt ( ), WX71 = MulaolaoBll . Drity . GetDt ( ), WX73 = MulaolaoBll . Drity . GetDt ( ), WX76 = MulaolaoBll . Drity . GetDt ( );
        long WX39 = 0, WX42 = 0, WX43 = 0, WX44 = 0, WX45 = 0, WX46 = 0, WX47 = 0, WX48 = 0, WX49 = 0, WX50 = 0, WX086 = 0;
        //新增
        Order od = new Order( );
        string ord = "";
        void orde ( )
        {
            WX03 = "";
            Ergodic.SpliClear( spList );
            Ergodic.SpliEnableTrue( spList );
            Ergodic.TablePageEnableClear( pageList );
            Ergodic.TablePageEnableTrue( pageList );
            Ergodic.FormEvery( this );
            gridControl1.DataSource = null;

            textBox28.Enabled = false;

            sav = "1";

            label83.Visible = false;
            label98.Visible = false;
            dateTimePicker3.Enabled = dateTimePicker5.Enabled = dateTimePicker2.Enabled = false;

            WX82 = oddNumbers.purchaseContract( "SELECT MAX(AJ008) AJ008 FROM R_PQAJ" ,"AJ008" ,"R_349-" );
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
                comboBox7.Enabled = comboBox21.Enabled = true;
                textBox8.Enabled = true;
                button16.Enabled = true;
                button5.Enabled = false;
                //fc.productNumberRthr( comboBox7 );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
            }
            else if ( ord == "实际" )
            {
                orde( );

                comboBox7.Enabled = comboBox21.Enabled = false;
                textBox8.Enabled = false;
                button16.Enabled = false;
                button5.Enabled = true;
                //comboBox7.DataSource = null;
                //comboBox7.Items.Clear( );
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
            }
            else
            {
                MessageBox.Show( "请选择计划订单或实际订单" );
                sav = "1";
                WX82 = "";
                toolSelect.Enabled = toolAdd.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = false;
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

            if ( label83.Visible == true )
            {
                if ( Logins.number == "MLL-0001" )
                    deles( );
                else
                    MessageBox.Show( "单号:" + WX82 + "的单据状态为执行,不允许删除" );
            }
            else
                deles( );
        }
        void deles ( )
        {
            if ( label83.Visible == true )
                stateOfOdd = "维护删除";
            else
            {
                if ( sav == "1" )
                    stateOfOdd = "新增删除";
                else
                    stateOfOdd = "更改删除";
            }
            result = bll.DeleteAll( "R_349" ,"外箱、中包、彩盒、纸片（卡）等采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,WX82 ,"删除" ,stateOfOdd );
            if ( result == false )
                MessageBox.Show( "删除数据失败" );
            else
            {
                MessageBox.Show( "成功删除数据" );
                WX03 = "";
                Ergodic.SpliClear( spList );
                Ergodic.SpliEnableFalse( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.TablePageEnableFalse( pageList );
                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;

                toolSelect.Enabled = toolAdd.Enabled = toolPrint.Enabled = toolExport.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;

                textBox28.Enabled = false;
                label98.Visible = label83.Visible = false;
            }
        }
        //更改
        protected override void update ( )
        {
            base.update( );

            if ( label83.Visible == true )
                MessageBox.Show( "单号:" + WX82 + "的单据状态为执行,不允许更改" );
            else
            {
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );

                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;

                textBox28.Enabled = false;
                label98.Visible = false;
                dateTimePicker3.Enabled = dateTimePicker5.Enabled = dateTimePicker2.Enabled = false;
                if ( string.IsNullOrEmpty( textBox7.Text ) )
                {
                    comboBox7.Enabled = comboBox21.Enabled = true;
                    textBox8.Enabled = true;
                    button16.Enabled = true;
                    button5.Enabled = false;
                }
                else
                {
                    comboBox7.Enabled = comboBox21.Enabled = false;
                    textBox8.Enabled = false;
                    button16.Enabled = false;
                    button5.Enabled = true;
                }
            }
        }
        //送审
        protected override void revirw ( )
        {
            base.revirw( );
            bool result = false, over = false;
            if ( textBox73.Text == "廖灵飞" )
                result = true;
            else
                result = false;
            if ( string.IsNullOrEmpty( textBox11.Text ) )
                over = false;
            else
                over = true;
            Reviews( "WX82" ,WX82 ,"R_PQT" ,this ,WX01 ,"R_349" ,result ,over,null/*,"WX07" ,"WX75" ,"R_PQT" ,"WX82" ,WX82 ,ord ,textBox7.Text,"R_349"*/ );
            result = false;
            result = sp.reviewImple( "R_349" ,WX82 );
            if ( result == true )
            {
                label83.Visible = true;
                try
                {
                    SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfCopy( "R_PQTC" ,"R_PQT" ,"WX82" ,WX82 ) );
                    WriteOfReceivablesTo( );
                }
                catch { }
            }
            else
                label83.Visible = false;
        }
        void WriteOfReceivablesTo ( )
        {
            DataTable receiva;
            MulaolaoLibrary.ProductCostSummaryLibrary modelAm = new MulaolaoLibrary.ProductCostSummaryLibrary( );
            receiva = bll.GetDataTableOfReceiveable( WX82 );
            if ( receiva != null && receiva.Rows.Count > 0 )
            {
                modelAm.AM002 = receiva.Rows[0]["WX01"].ToString( );
                modelAm.AM130 = modelAm.AM133 = modelAm.AM136 = modelAm.AM138 = modelAm.AM139 = modelAm.AM142 = modelAm.AM144 = modelAm.AM145 = modelAm.AM148 = modelAm.AM150 = 0;
                modelAm.AM136 = string.IsNullOrEmpty( receiva.Compute( "SUM(PQ)" ,"WX01='" + modelAm.AM002 + "' and WX20='包装辅料' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(PQ)" ,"WX01='" + modelAm.AM002 + "' and WX20='包装辅料' AND WX90='F'" ) );
                modelAm.AM138 = string.IsNullOrEmpty( receiva.Compute( "SUM(PQ)" ,"WX01='" + modelAm.AM002 + "' and WX20='包装辅料' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(PQ)" ,"WX01='" + modelAm.AM002 + "' and WX20='包装辅料' AND WX90='T'" ) );
                modelAm.AM145 = string.IsNullOrEmpty( receiva.Compute( "SUM(PQ)" ,"WX01='" + modelAm.AM002 + "' and WX20='内盒' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(PQ)" ,"WX01='" + modelAm.AM002 + "' and WX20='内盒'  AND WX90='F'" ) );
                modelAm.AM133 = string.IsNullOrEmpty( receiva.Compute( "SUM(PQ)" ,"WX01='" + modelAm.AM002 + "' and WX20='内盒' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(PQ)" ,"WX01='" + modelAm.AM002 + "' and WX20='内盒'  AND WX90='T'" ) );
                modelAm.AM139 = string.IsNullOrEmpty( receiva.Compute( "SUM(PQ)" ,"WX01='" + modelAm.AM002 + "' and WX20='外箱' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(PQ)" ,"WX01='" + modelAm.AM002 + "' and WX20='外箱' AND WX90='F'" ) );
                modelAm.AM144 = string.IsNullOrEmpty( receiva.Compute( "SUM(PQ)" ,"WX01='" + modelAm.AM002 + "' and WX20='外箱' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(PQ)" ,"WX01='" + modelAm.AM002 + "' and WX20='外箱' AND WX90='T'" ) );
                modelAm.AM142 = string.IsNullOrEmpty( receiva.Compute( "SUM(PQ)" ,"WX01='" + modelAm.AM002 + "' and WX20='中包' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(PQ)" ,"WX01='" + modelAm.AM002 + "' and WX20='中包' AND WX90='F'" ) );
                modelAm.AM150 = string.IsNullOrEmpty( receiva.Compute( "SUM(PQ)" ,"WX01='" + modelAm.AM002 + "' and WX20='中包' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(PQ)" ,"WX01='" + modelAm.AM002 + "' and WX20='中包' AND WX90='T'" ) );
                modelAm.AM148 = string.IsNullOrEmpty( receiva.Compute( "SUM(PQ)" ,"WX01='" + modelAm.AM002 + "' and WX20='彩盒' AND WX90='F'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(PQ)" ,"WX01='" + modelAm.AM002 + "' and WX20='彩盒' AND WX90='F'" ) );
                modelAm.AM130 = string.IsNullOrEmpty( receiva.Compute( "SUM(PQ)" ,"WX01='" + modelAm.AM002 + "' and WX20='彩盒' AND WX90='T'" ).ToString( ) ) == true ? 0 : Convert.ToDecimal( receiva.Compute( "SUM(PQ)" ,"WX01='" + modelAm.AM002 + "' and WX20='彩盒' AND WX90='T'" ) );
                bll.UpdateOfReceivable( modelAm ,WX82 );
            }
        }
        //打印
        bool result = false;
        void trueOrFalse ( )
        {
            WX85 = comboBox21.Text;
            if ( ( string.IsNullOrEmpty( textBox7.Text ) && bandedGridView1.GetDataRow( 0 )["WX17"].ToString( ) == "外购" ) || ( !string.IsNullOrEmpty( textBox7.Text ) && bandedGridView1.GetDataRow( 0 )["WX17"].ToString( ) == "库存" ) )
            {
                for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                {
                    if ( sp.inOut( WX82 ,bandedGridView1.GetDataRow( i )["WX10"].ToString( ) ,WX85 ,bandedGridView1.GetDataRow( i )["WX11"].ToString( ) ) == false )
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
            //sp.panDuan( "WX07" ,"WX75" ,"R_PQT" ,"WX82" ,WX82 ,ord ,textBox7.Text,"R_349" );
            
            printCount = bandedGridView1 . DataRowCount;
            if ( printCount % 5 > 0 )
                printCount = printCount / 5 + 1;
            else
                printCount = printCount / 5;


            if ( ( ord == "实际" || !string.IsNullOrEmpty( textBox7.Text ) ) && bandedGridView1.GetDataRow( 0 )["WX17"].ToString( ) == "外购" )
            {
                if ( label83.Visible == true )
                {
                    MulaolaoBll . ContractAddPrintTime . addTimeToContract ( "R_PQT" ,"WX94" ,WX82 ,"WX82" );

                    printC ( );
                }
                else
                    MessageBox.Show( "非执行单据不能打印" );
            }
            else
            {
                trueOrFalse( );
                if ( result == true )
                {
                    MulaolaoBll . ContractAddPrintTime . addTimeToContract ( "R_PQT" ,"WX94" ,WX82 ,"WX82" );

                    printC ( );
                }
                else
                    MessageBox.Show( "没有出入库的单据不能打印" );
            }
        }
        void printC ( )
        {
            for ( int i = 0 ; i < printCount ; i++ )
            {
                CreateDataset ( i * 5 + 1 ,i * 5 + 5 );
                report . Load ( Application . StartupPath + "\\R_349.frx" );
                report . RegisterData ( RDataSet );
                report . Show ( );
            }
        }
        //导出
        protected override void export ( )
        {
            base.export( );

            printCount = bandedGridView1 . DataRowCount;
            if ( printCount % 5 > 0 )
                printCount = printCount / 5 + 1;
            else
                printCount = printCount / 5;

            for ( int i = 0 ; i < printCount ; i++ )
            {
                CreateDataset ( i * 5 + 1 ,i * 5 + 5 );
                file = "";
                file = System . Windows . Forms . Application . StartupPath;
                report . Load ( file + "\\R_349.frx" );
                report . RegisterData ( RDataSet );
                report . Prepare ( );
                XMLExport exprots = new XMLExport ( );
                exprots . Export ( report );
            }
        }
        //保存
        void saves ( )
        {
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolMaintain.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
            textBox28.Enabled = false;
            copy = "";
            sav = "2";
            weihu = "";
        }
        void updates ( )
        {
            StringBuilder strSql = new StringBuilder( );
            strSql.AppendFormat( "UPDATE R_PQT SET  WX01='{0}',WX02='{1}',WX03='{2}',WX04='{3}',WX05='{4}',WX06='{5}',WX07='{6}',WX08='{7}',WX09='{8}',WX33='{9}',WX34='{10}',WX35='{11}',WX36='{12}',WX37='{13}',WX38='{14}',WX39='{15}',WX40='{16}',WX41='{17}',WX42='{18}',WX43='{19}',WX44='{20}',WX45='{21}',WX46='{22}',WX47='{23}',WX48='{24}',WX49='{25}',WX50='{26}',WX51='{27}',WX52='{28}',WX53='{29}',WX54='{30}',WX55='{31}',WX56='{32}',WX57='{33}',WX58='{34}',WX59='{35}',WX60='{36}',WX61='{37}',WX62='{38}',WX63='{39}',WX64='{40}',WX65='{41}',WX66='{42}',WX67='{43}',WX68='{44}',WX69='{45}',WX70='{46}',WX71='{47}',WX72='{48}',WX73='{49}',WX74='{50}',WX75='{51}',WX76='{52}',WX78='{53}',WX79='{54}',WX80='{55}',WX81='{56}',WX83='{57}',WX84='{58}',WX85='{59}',WX90='{60}',WX91='{61}',WX89='' WHERE WX82='{62}'" ,WX01 ,WX02 ,WX03 ,WX04 ,WX05 ,WX06 ,WX07 ,WX08 ,WX09 ,WX33 ,WX34 ,WX35 ,WX36 ,WX37 ,WX38 ,WX39 ,WX40 ,WX41 ,WX42 ,WX43 ,WX44 ,WX45 ,WX46 ,WX47 ,WX48 ,WX49 ,WX50 ,WX51 ,WX52 ,WX53 ,WX54 ,WX55 ,WX56 ,WX57 ,WX58 ,WX59 ,WX60 ,WX61 ,WX62 ,WX63 ,WX64 ,WX65 ,WX66 ,WX67 ,WX68 ,WX69 ,WX70 ,WX71 ,WX72 ,WX73 ,WX74 ,WX75 ,WX76 ,WX78 ,WX79 ,WX80 ,WX81 ,WX83 ,WX84 ,WX85 ,WX090 ,WX91 ,WX82 );
            int count = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( count < 1 )
                MessageBox.Show( "录入数据失败" );
            else
            {
                MessageBox.Show( "成功录入数据" );
                try
                {
                    SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_349" ,"外箱、中包、彩盒、纸片（卡）等采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,WX82 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"保存" ,stateOfOdd ) );
                }
                catch { }
                finally { saves( ); }
            }
        }
        protected override void save ( )
        {
            base.save( );

            #region
            if ( Logins . number == "MLL-0001" )
                WX090 = checkBox13 . Checked == true ? "T" : "F";
            else
                WX090 = "F";
            WX01 = textBox7.Text;
            WX83 = comboBox7.Text;
            WX84 = textBox10.Text;
            WX85 = comboBox21.Text;
            WX91 = lookUpEdit2.Text;
            if ( !string.IsNullOrEmpty( textBox8.Text ) )
                WX086 = Convert.ToInt64( textBox8.Text );
            else
                WX086 = 0;
            WX04 = dateTimePicker1.Value;
            WX05 = textBox12.Text;
            WX06 = dateTimePicker3.Value;
            WX07 = textBox11.Text;
            WX08 = dateTimePicker2.Value;
            WX09 = textBox14.Text;
            WX78 = textBox13.Text;
            WX79 = textBox16.Text;
            WX33 = comboBox23.Text;
            WX34 = dateTimePicker6.Value;
            if ( radioButton1.Checked )
                WX35 = "在内";
            else if ( radioButton2.Checked )
                WX35 = "不在内";
            if ( radioButton3.Checked )
                WX36 = "有";
            else if ( radioButton4.Checked )
                WX36 = "没有";
            if ( radioButton6.Checked )
            {
                WX37 = "已检测";
                WX38 = textBox50.Text;
            }
            else if ( radioButton5.Checked )
                WX37 = "未检测";
            if ( textBox55.Text == "" )
                WX39 = 0;
            else
                WX39 = Convert.ToInt64( textBox55.Text );
            if ( radioButton7.Checked )
                WX40 = "合格";
            else if ( radioButton8.Checked )
            {
                WX40 = "条件接收";
                WX51 = textBox54.Text;
            }
            else if ( radioButton9.Checked )
                WX40 = "退货";
            WX41 = comboBox24.Text;
            if ( textBox21.Text == "" )
                WX42 = 0;
            else
                WX42 = Convert.ToInt64( textBox21.Text );
            if ( textBox20.Text == "" )
                WX43 = 0;
            else
                WX43 = Convert.ToInt64( textBox20.Text );
            if ( textBox19.Text == "" )
                WX44 = 0;
            else
                WX44 = Convert.ToInt64( textBox19.Text );
            if ( textBox24.Text == "" )
                WX45 = 0;
            else
                WX45 = Convert.ToInt64( textBox24.Text );
            if ( textBox23.Text == "" )
                WX46 = 0;
            else
                WX46 = Convert.ToInt64( textBox23.Text );
            if ( textBox22.Text == "" )
                WX47 = 0;
            else
                WX47 = Convert.ToInt64( textBox22.Text );
            if ( textBox65.Text == "" )
                WX48 = 0;
            else
                WX48 = Convert.ToInt64( textBox65.Text );
            if ( textBox17.Text == "" )
                WX49 = 0;
            else
                WX49 = Convert.ToInt64( textBox17.Text );
            if ( textBox18.Text == "" )
                WX50 = 0;
            else
                WX50 = Convert.ToInt64( textBox18.Text );
            WX52 = comboBox25.Text;
            WX53 = comboBox26.Text;
            WX54 = comboBox27.Text;
            WX55 = dateTimePicker7.Value;
            if ( checkBox1.Checked )
                WX56 = "T";
            else
                WX56 = "F";
            if ( checkBox2.Checked )
                WX57 = "T";
            else
                WX57 = "F";
            if ( checkBox4.Checked )
                WX58 = "T";
            else
                WX58 = "F";
            if ( checkBox3.Checked )
                WX59 = "T";
            else
                WX59 = "F";
            if ( checkBox5.Checked )
                WX60 = "T";
            else
                WX60 = "F";
            if ( checkBox6.Checked )
                WX61 = "T";
            else
                WX61 = "F";
            if ( checkBox10.Checked )
                WX62 = "T";
            else
                WX62 = "F";
            if ( checkBox9.Checked )
                WX63 = "T";
            else
                WX63 = "F";
            if ( checkBox8.Checked )
                WX64 = "T";
            else
                WX64 = "F";
            if ( checkBox7.Checked )
                WX65 = "T";
            else
                WX65 = "F";
            if ( checkBox11.Checked )
                WX66 = "T";
            else
                WX66 = "F";
            if ( checkBox12.Checked )
            {
                WX67 = "T";
                WX68 = textBox69.Text;
            }
            else
                WX67 = "F";
            WX69 = textBox78.Text;
            WX70 = textBox77.Text;
            WX71 = dateTimePicker8.Value;
            WX72 = textBox75.Text;
            WX73 = dateTimePicker9.Value;
            WX74 = textBox71.Text;
            WX75 = textBox73.Text;
            WX76 = dateTimePicker10.Value;
            #endregion

            if ( string.IsNullOrEmpty( textBox7.Text ) || ord == "计划" )
            {
                WX01 = "";
                WX84 = "";
            }
            WX80 = textBox28.Text;
            WX81 = "";

            if ( string . IsNullOrEmpty ( WX03 ) )
            {
                MessageBox . Show ( "请选择供应商" );
                return;
            }
            if ( textBox14.Text == "" )
                MessageBox.Show( "合同批号不可为空" );
            else
            {
                if ( string.IsNullOrEmpty( lookUpEdit1.Text ) )
                    MessageBox.Show( "请选择联系人" );
                else
                {
                    WX02 = lookUpEdit1.EditValue.ToString( );
                    DataTable dhj = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQT WHERE WX82=@WX82" ,new SqlParameter( "@WX82" ,WX82 ) );

                    if ( weihu == "1" )
                    {
                        if ( textBox28.Text == "" )
                            MessageBox.Show( "请填写维护意见" );
                        else
                        {
                            if ( dhj.Rows.Count < 1 )
                                MessageBox.Show( "单号:" + WX82 + "的记录不存在,请核实后再维护" );
                            else
                            {
                                WX81 = dhj.Rows[0]["WX81"].ToString( ) + "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";
                                stateOfOdd = "维护保存";
                                StringBuilder strSql = new StringBuilder( );
                                strSql.AppendFormat( "UPDATE R_PQT SET  WX01='{0}',WX02='{1}',WX03='{2}',WX04='{3}',WX05='{4}',WX06='{5}',WX07='{6}',WX08='{7}',WX09='{8}',WX33='{9}',WX34='{10}',WX35='{11}',WX36='{12}',WX37='{13}',WX38='{14}',WX39='{15}',WX40='{16}',WX41='{17}',WX42='{18}',WX43='{19}',WX44='{20}',WX45='{21}',WX46='{22}',WX47='{23}',WX48='{24}',WX49='{25}',WX50='{26}',WX51='{27}',WX52='{28}',WX53='{29}',WX54='{30}',WX55='{31}',WX56='{32}',WX57='{33}',WX58='{34}',WX59='{35}',WX60='{36}',WX61='{37}',WX62='{38}',WX63='{39}',WX64='{40}',WX65='{41}',WX66='{42}',WX67='{43}',WX68='{44}',WX69='{45}',WX70='{46}',WX71='{47}',WX72='{48}',WX73='{49}',WX74='{50}',WX75='{51}',WX76='{52}',WX78='{53}',WX79='{54}',WX80='{55}',WX81='{56}',WX83='{57}',WX84='{58}',WX85='{59}',WX90='{60}',WX91='{61}' WHERE WX82='{62}'" ,WX01 ,WX02 ,WX03 ,WX04 ,WX05 ,WX06 ,WX07 ,WX08 ,WX09 ,WX33 ,WX34 ,WX35 ,WX36 ,WX37 ,WX38 ,WX39 ,WX40 ,WX41 ,WX42 ,WX43 ,WX44 ,WX45 ,WX46 ,WX47 ,WX48 ,WX49 ,WX50 ,WX51 ,WX52 ,WX53 ,WX54 ,WX55 ,WX56 ,WX57 ,WX58 ,WX59 ,WX60 ,WX61 ,WX62 ,WX63 ,WX64 ,WX65 ,WX66 ,WX67 ,WX68 ,WX69 ,WX70 ,WX71 ,WX72 ,WX73 ,WX74 ,WX75 ,WX76 ,WX78 ,WX79 ,WX80 ,WX81 ,WX83 ,WX84 ,WX85 ,WX090 ,WX91 ,WX82 );
                                int count = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
                                if ( count < 1 )
                                    MessageBox.Show( "录入数据失败" );
                                else
                                {
                                    MessageBox.Show( "成功录入数据" );
                                    try
                                    {
                                        SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_349" ,"外箱、中包、彩盒、纸片（卡）等采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,WX82 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"保存" ,stateOfOdd ) );

                                        SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfCopy( "R_PQTC" ,"R_PQT" ,"WX82" ,WX82 ) );
                                        WriteOfReceivablesTo( );
                                    }
                                    catch { }
                                    finally { saves( ); }
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
                        if ( dhj.Rows.Count < 1 )
                        {
                            saves( );
                        }
                        else
                        {
                            if ( copy == "1" )
                            {
                                if ( MulaolaoBll . WriteReceivableToGeneralLedger . ExistsSup ( WX03 ) == false )
                                {
                                    MessageBox . Show ( "供应商已注销,请核实" );
                                    return;
                                }

                                stateOfOdd = "复制保存";
                                DataTable dyu = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQT WHERE WX82!=@WX82 " ,new SqlParameter( "@WX82" ,WX82 ) /* ,new SqlParameter( "@WX05" ,WX05 ) */);
                                if ( dyu.Rows.Count < 1 )
                                    updates( );
                                else
                                {
                                    int proNum = 0;
                                    for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                                    {
                                        proNum = string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "WX86" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( bandedGridView1 . GetDataRow ( i ) [ "WX86" ] );
                                        if ( proNum != WX086 )
                                        {
                                            MessageBox . Show ( "产品数量不一致,请核实" );
                                            return;
                                        }

                                        if ( ord == "计划" || string.IsNullOrEmpty( textBox7.Text ) )
                                        {
                                            if ( dyu.Select( "WX10='" + bandedGridView1.GetDataRow( i )["WX10"].ToString( ) + "' AND WX11='" + bandedGridView1.GetDataRow( i )["WX11"].ToString( ) + "'AND WX85='" + WX85 + "'" ).Length > 0 )
                                            {
                                                if ( WX09.Length > 8 && WX09.Substring( 0 ,8 ) == "MLL-0001" )
                                                {
                                                    updates( );
                                                    break;
                                                }
                                                else
                                                {
                                                    //\n\r开合同人:" + WX05 + "
                                                    MessageBox.Show( "已经存在\n\r货号:" + WX85 + "\n\r物料名称:" + bandedGridView1.GetDataRow( i )["WX10"].ToString( ) + "\n\r规格:" + bandedGridView1.GetDataRow( i )["WX11"].ToString( ) + "\n\r的单据,请核实后再录入" );
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                updates( );
                                                break;
                                            }
                                        }
                                        else if ( ord == "实际" || !string.IsNullOrEmpty( textBox7.Text ) )
                                        {
                                            if ( dyu.Select( "WX10='" + bandedGridView1.GetDataRow( i )["WX10"].ToString( ) + "' AND WX11='" + bandedGridView1.GetDataRow( i )["WX11"].ToString( ) + "'AND WX01='" + WX01 + "'" ).Length > 0 )
                                            {
                                                if ( WX09.Length > 8 && WX09.Substring( 0 ,8 ) == "MLL-0001" )
                                                {
                                                    updates( );
                                                    break;
                                                }
                                                else
                                                {
                                                    //\n\r开合同人:" + WX05 + "
                                                    MessageBox.Show( "已经存在\n\r流水号:" + WX01 + "\n\r物料名称:" + bandedGridView1.GetDataRow( i )["WX10"].ToString( ) + "\n\r规格:" + bandedGridView1.GetDataRow( i )["WX11"].ToString( ) + "\n\r的单据,请核实后再录入" );
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
            }
        }
        //取消
        protected override void cancel ( )
        {
            base.cancel( );

            if ( sav == "1" && weihu != "1" )
            {
                WX03 = "";
                Ergodic.SpliClear( spList );
                Ergodic.TablePageEnableClear( pageList );
                Ergodic.FormEvery( this );
                gridControl1.DataSource = null;

                toolSelect.Enabled = toolAdd.Enabled = toolPrint.Enabled = toolExport.Enabled = true;
                toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;

                label98.Visible = false;

                try
                {
                    bll.DeleteAll( "R_349" ,"外箱、中包、彩盒、纸片（卡）等采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,WX82 ,"取消" ,"新增取消" );
                }
                catch { }
            }
            else if ( sav == "2" || weihu == "1" )
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = true;
                toolMaintain.Enabled = toolSave.Enabled = toolCancel.Enabled = false;
            }
            Ergodic.SpliEnableFalse( spList );
            Ergodic.TablePageEnableFalse( pageList );
        }
        //维护
        protected override void maintain ( )
        {
            base.maintain( );

            if ( label83.Visible == true )
            {
                Ergodic.SpliEnableTrue( spList );
                Ergodic.TablePageEnableTrue( pageList );

                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
                textBox28.Enabled = true;

                weihu = "1";
                label83.Visible = true;
                dateTimePicker3.Enabled = dateTimePicker5.Enabled = dateTimePicker2.Enabled = false;
                if ( !string.IsNullOrEmpty( textBox7.Text ) )
                {
                    comboBox7.Enabled = comboBox21.Enabled = false;
                    textBox8.Enabled = false;
                    button16.Enabled = false;
                    button5.Enabled = true;
                }
                else
                {
                    comboBox7.Enabled = comboBox21.Enabled = true;
                    textBox8.Enabled = true;
                    button16.Enabled = true;
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

            if ( label83.Visible == true )
            {
                if ( string.IsNullOrEmpty( comboBox7.Text ) )
                    MessageBox.Show( "产品名称不可为空" );
                else
                {
                    if ( string.IsNullOrEmpty( comboBox21.Text ) )
                        MessageBox.Show( "货号不可为空" );
                    else
                    {
                        if ( string.IsNullOrEmpty( textBox8.Text ) )
                            MessageBox.Show( "产品数量不可为空" );
                        else
                        {
                            for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                            {
                                result = fc . Library ( comboBox7 . Text ,comboBox21 . Text ,textBox7 . Text ,textBox8 . Text ,bandedGridView1 . GetDataRow ( i ) [ "WX10" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "WX11" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "WX19" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "WX14" ] . ToString ( ) ,"" ,bandedGridView1 . GetDataRow ( i ) [ "WX13" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "WX16" ] . ToString ( ) ,Logins . username ,MulaolaoBll . Drity . GetDt ( ) ,WX82 ,lookUpEdit2 . Text );
                                if ( result == false )
                                {
                                    MessageBox.Show( "出库失败" );
                                    break;
                                }
                                else
                                    MessageBox.Show( "出库成功" );
                            }
                        }
                    }
                }
            }
            else
                MessageBox.Show( "非执行单据不能出库" );
        }
        //入库
        protected override void storage ( )
        {
            base.storage( );

            if ( label83.Visible == true )
            {
                if ( string . IsNullOrEmpty ( comboBox7 . Text ) )
                {
                    MessageBox . Show ( "产品名称不可为空" );
                    return;
                }
                if ( string . IsNullOrEmpty ( comboBox21 . Text ) )
                {
                    MessageBox . Show ( "货号不可为空" );
                    return;
                }
                if ( string . IsNullOrEmpty ( textBox8 . Text ) )
                {
                    MessageBox . Show ( "产品数量不可为空" );
                    return;
                }
                if ( bandedGridView1 . GetDataRow ( 0 ) [ "WX17" ] . ToString ( ) == "库存" )
                {
                    MessageBox . Show ( "库存无法入库,请选择外购或更改状态" );
                    return;
                }
                if ( bandedGridView1 . GetDataRow ( 0 ) [ "WX17" ] . ToString ( ) == "外购" && ( ord == "实际" || !string . IsNullOrEmpty ( textBox7 . Text ) ) )
                {
                    MessageBox . Show ( "实际订单不允许入库" );
                    return;
                }
                for ( int i = 0 ; i < bandedGridView1 . RowCount ; i++ )
                {
                    result = fc . Storage ( comboBox7 . Text ,comboBox21 . Text ,textBox8 . Text ,bandedGridView1 . GetDataRow ( i ) [ "WX10" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "WX11" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "WX19" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "WX14" ] . ToString ( ) ,"" ,bandedGridView1 . GetDataRow ( i ) [ "WX13" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "WX87" ] . ToString ( ) ,textBox12 . Text ,dateTimePicker2 . Value ,lookUpEdit1 . Text ,MulaolaoBll . Drity . GetDt ( ) ,WX82 ,bandedGridView1 . GetDataRow ( i ) [ "WX92" ] . ToString ( ) ,bandedGridView1 . GetDataRow ( i ) [ "WX93" ] . ToString ( ) ,lookUpEdit2 . Text ,textBox1 . Text ,textBox6 . Text );
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
                            for ( int k = 0 ; k < bandedGridView1 . RowCount ; k++ )
                            {
                                model . IDX = string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( bandedGridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( ) );
                                model . WX92 = string . IsNullOrEmpty ( textBox8 . Text ) == true ? 0 : Convert . ToInt64 ( textBox8 . Text );
                                model . WX93 = string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "WX87" ] . ToString ( ) ) == true ? 0 : Convert . ToInt64 ( bandedGridView1 . GetDataRow ( i ) [ "WX87" ] . ToString ( ) );
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

            string t1 = textBox1.Text;
            if ( label83.Visible == true )
                stateOfOdd = "维护复制";
            else
            {
                if ( sav == "1" )
                    stateOfOdd = "新增复制";
                else
                    stateOfOdd = "更改复制";
            }

            result = bll.Copy( "R_349" ,"外箱、中包、彩盒、纸片（卡）等采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,WX82 ,"复制" ,stateOfOdd );
            if ( result == false )
                MessageBox.Show( "复制失败,请重试" );
            else
            {
                WX82 = oddNumbers.purchaseContract( "SELECT MAX(AJ008) AJ008 FROM R_PQAJ" ,"AJ008" ,"R_349-" );
                stateOfOdd = "更改复制单号";
                result = bll.CopyAll( "R_349" ,"外箱、中包、彩盒、纸片（卡）等采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,WX82 ,"复制" ,stateOfOdd );
                if ( result == false )
                {
                    MessageBox.Show( "复制失败,请重试" );
                    SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQT WHERE WX82 IS NULL" );
                }
                else
                {
                    MessageBox.Show( "成功复制此表" );
                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = toolcopy.Enabled = toolLibrary.Enabled = toolStorage.Enabled = false;
                    toolSave.Enabled = toolCancel.Enabled = true;

                    textBox28.Enabled = false;
                    Ergodic.SpliEnableTrue( spList );
                    Ergodic.TablePageEnableTrue( pageList );
                    Ergodic.FormEvery( this );
                    gridControl1.DataSource = null;
                    label83.Visible = false;
                    dateTimePicker2.Enabled = dateTimePicker3.Enabled = dateTimePicker5.Enabled = false;
                    sav = "1";
                    ord = "";
                    copy = "1";
                    weihu = "";
                    queryContent( );
                    textBox1.Text = t1;
                }
            }
        }
        #endregion

        #region Event
        void assginContrac ( )
        {
            decimal val = 0.0001M;
            for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
            {
                if ( bandedGridView1.GetDataRow( i )["WX10"].ToString( ) == "双瓦外箱" || bandedGridView1.GetDataRow( i )["WX10"].ToString( ) == "小箱式" )
                {
                    if ( !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["WX27"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["WX28"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["WX29"].ToString( ) ) )
                        bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U3"] ,Convert.ToDecimal( bandedGridView1.GetDataRow( i )["WX27"].ToString( ) ) + Convert.ToDecimal( bandedGridView1.GetDataRow( i )["WX28"].ToString( ) ) + Convert.ToDecimal( bandedGridView1.GetDataRow( i )["WX29"].ToString( ) ) );
                    else
                        bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U3"] ,val );
                    if ( !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["WX30"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["WX31"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["WX32"].ToString( ) ) )
                        bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U4"] ,Convert.ToDecimal( bandedGridView1.GetDataRow( i )["WX30"].ToString( ) ) + Convert.ToDecimal( bandedGridView1.GetDataRow( i )["WX31"].ToString( ) ) + Convert.ToDecimal( bandedGridView1.GetDataRow( i )["WX32"].ToString( ) ) );
                    else
                        bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U4"] ,val );
                }
                else if ( bandedGridView1.GetDataRow( i )["WX10"].ToString( ) == "牙膏式" || bandedGridView1.GetDataRow( i )["WX10"].ToString( ) == "插口式" )
                {
                    if ( !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "WX27" ] . ToString ( ) ) && !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "WX28" ] . ToString ( ) ) && !string . IsNullOrEmpty ( bandedGridView1 . GetDataRow ( i ) [ "WX29" ] . ToString ( ) ) )
                        bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U3" ] ,Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "WX27" ] . ToString ( ) ) + 2 * Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "WX28" ] . ToString ( ) ) + Convert . ToDecimal ( bandedGridView1 . GetDataRow ( i ) [ "WX29" ] . ToString ( ) ) );
                    else
                        bandedGridView1 . SetRowCellValue ( i ,bandedGridView1 . Columns [ "U3" ] ,val );

                    if ( !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["WX30"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["WX31"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["WX32"].ToString( ) ) )
                        bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U4"] ,2 * Convert.ToDecimal( bandedGridView1.GetDataRow( i )["WX30"].ToString( ) ) + 2 * Convert.ToDecimal( bandedGridView1.GetDataRow( i )["WX31"].ToString( ) ) + Convert.ToDecimal( bandedGridView1.GetDataRow( i )["WX32"].ToString( ) ) );
                    else
                        bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U4"] ,val );
                }
                else if ( bandedGridView1.GetDataRow( i )["WX10"].ToString( ) == "折叠式" )
                {
                    if ( !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["WX27"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["WX28"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["WX29"].ToString( ) ) )
                        bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U3"] ,2 * Convert.ToDecimal( bandedGridView1.GetDataRow( i )["WX27"].ToString( ) ) + 2 * Convert.ToDecimal( bandedGridView1.GetDataRow( i )["WX28"].ToString( ) ) + Convert.ToDecimal( bandedGridView1.GetDataRow( i )["WX29"].ToString( ) ) );
                    else
                        bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U3"] ,val );
                    if ( !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["WX30"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["WX31"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["WX32"].ToString( ) ) )
                        bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U4"] ,Convert.ToDecimal( 1.5 ) * Convert.ToDecimal( bandedGridView1.GetDataRow( i )["WX30"].ToString( ) ) + Convert.ToDecimal( bandedGridView1.GetDataRow( i )["WX31"].ToString( ) ) + Convert.ToDecimal( bandedGridView1.GetDataRow( i )["WX32"].ToString( ) ) );
                    else
                        bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U4"] ,val );
                }
                else if ( bandedGridView1.GetDataRow( i )["WX10"].ToString( ) == "天盖" || bandedGridView1.GetDataRow( i )["WX10"].ToString( ) == "地盖" )
                {
                    if ( !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["WX27"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["WX28"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["WX29"].ToString( ) ) )
                        bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U3"] ,Convert.ToDecimal( bandedGridView1.GetDataRow( i )["WX27"].ToString( ) ) + 2 * Convert.ToDecimal( bandedGridView1.GetDataRow( i )["WX28"].ToString( ) ) + Convert.ToDecimal( bandedGridView1.GetDataRow( i )["WX29"].ToString( ) ) );
                    else
                        bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U3"] ,val );
                    if ( !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["WX30"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["WX31"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["WX32"].ToString( ) ) )
                        bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U4"] ,Convert.ToDecimal( bandedGridView1.GetDataRow( i )["WX30"].ToString( ) ) + 2 * Convert.ToDecimal( bandedGridView1.GetDataRow( i )["WX31"].ToString( ) ) + Convert.ToDecimal( bandedGridView1.GetDataRow( i )["WX32"].ToString( ) ) );
                    else
                        bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U4"] ,val );
                }
                else
                {
                    bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U3"] ,val );
                    bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U4"] ,val );
                    //if ( !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["U6"].ToString( ) ) && !string.IsNullOrEmpty( bandedGridView1.GetDataRow( i )["WX13"].ToString( ) ) )
                    //    bandedGridView1.SetRowCellValue( i ,bandedGridView1.Columns["U1"] ,Convert.ToDecimal( bandedGridView1.GetDataRow( i )["U6"].ToString( ) ) * Convert.ToDecimal( bandedGridView1.GetDataRow( i )["WX13"].ToString( ) ) );
                }
            }
        }
        void anOther ( )
        {
            DataTable dAn = SqlHelper.ExecuteDataTable( "SELECT WX23,WX41,WX52,WX53,WX54 FROM R_PQT" );
            comboBox23.DataSource = dAn.DefaultView.ToTable( true ,"WX23" );
            comboBox23.DisplayMember = "WX23";
            comboBox24.DataSource = dAn.DefaultView.ToTable( true ,"WX41" );
            comboBox24.DisplayMember = "WX41";
            comboBox25.DataSource = dAn.DefaultView.ToTable( true ,"WX52" );
            comboBox25.DisplayMember = "WX52";
            comboBox26.DataSource = dAn.DefaultView.ToTable( true ,"WX53" );
            comboBox26.DisplayMember = "WX53";
            comboBox27.DataSource = dAn.DefaultView.ToTable( true ,"WX54" );
            comboBox27.DisplayMember = "WX54";
        }
        //货号
        private void comboBox21_TextChanged ( object sender ,EventArgs e )
        {
           
            every( );
            previousOfPrice( );
        }
        void every ( )
        {
            WX85 = comboBox21 . Text;
            if ( string . IsNullOrEmpty ( textBox7 . Text ) )
                wpmc = SqlHelper . ExecuteDataTable ( "SELECT DISTINCT GS56 WX10,GS57 WX11,GS58 WX19,GS59 WX14 FROM R_PQP WHERE GS56 IS NOT NULL AND GS56!='' AND GS58=@GS48" ,new SqlParameter ( "@GS48" ,WX85 ) );
            else
            {
                WX01 = "";
                string [ ] str = textBox7 . Text . Split ( ',' );
                if ( str . Length < 1 )
                    WX01 = "";
                else
                {
                    foreach ( string s in str )
                    {
                        if ( WX01 == "" )
                            WX01 = "'" + s + "'";
                        else
                            WX01 = WX01 + "," + "'" + s + "'";
                    }
                }
                wpmc = SqlHelper . ExecuteDataTable ( "SELECT DISTINCT GS56 WX10,GS57 WX11,GS58 WX19,GS59 WX14 FROM R_PQP WHERE GS56 IS NOT NULL AND GS56!='' AND GS01 IN (" + WX01 + ")" );
            }

            if ( string.IsNullOrEmpty( textBox7.Text ) )
                biao = SqlHelper.ExecuteDataTable( "SELECT WX10,WX11,WX12,WX13,WX14,WX15,WX16,WX17,WX18,WX19,WX20,WX23,WX24,WX25,WX26,WX27,WX28,WX29,WX30,WX31,WX32,WX77 FROM R_PQT WHERE WX85=@WX85" ,new SqlParameter( "@WX85" ,WX85 ) );
            else
            {
                WX01 = "";
                string[] str = textBox7.Text.Split( ',' );
                if ( str.Length < 1 )
                    WX01 = "";
                else
                {
                    foreach ( string s in str )
                    {
                        if ( WX01 == "" )
                            WX01 = "'" + s + "'";
                        else
                            WX01 = WX01 + "," + "'" + s + "'";
                    }
                }
                biao = SqlHelper.ExecuteDataTable( "SELECT WX10,WX11,WX12,WX13,WX14,WX15,WX16,WX17,WX18,WX19,WX20,WX23,WX24,WX25,WX26,WX27,WX28,WX29,WX30,WX31,WX32,WX77 FROM R_PQT WHERE WX01 IN (" + WX01 + ")" );
            }
            if ( wpmc != null )
                biao.Merge( wpmc );
            //物料名称
            //DataTable elmc = biao.DefaultView.ToTable( true ,"WX10" );
            partTable = biao . DefaultView . ToTable ( true ,"WX10" ,"WX11","WX14" );
            Edit1 . Properties . DataSource = partTable;
            Edit1 . Properties . DisplayMember = "WX10";
            Edit1 . Properties . ValueMember = "WX10";
            //规格
            //txtSpe.DataSource = biao.DefaultView.ToTable( true ,"WX11" );
            //txtSpe.DisplayMember = "WX11";
            //单位
            comboBox22.DataSource = biao.DefaultView.ToTable( true ,"WX19" );
            comboBox22.DisplayMember = "WX19";
            //箱双m2卡单m2现价
            //DataTable xj = biao.DefaultView.ToTable(true ,"WX13");
            comboBox5.DataSource = biao.DefaultView.ToTable( true ,"WX13" );
            comboBox5.DisplayMember = "WX13";
            //每套物品数量
            //DataTable ml = biao.DefaultView.ToTable(true ,"WX14");
            //textBox36.DataSource = biao.DefaultView.ToTable( true ,"WX14" );
            //textBox36.DisplayMember = "WX14";
            //装箱率
            //DataTable zl = biao.DefaultView.ToTable(true ,"WX18");
            comboBox8.DataSource = biao.DefaultView.ToTable( true ,"WX18" );
            comboBox8.DisplayMember = "WX18";
            ////纸卡
            ////DataTable zk = biao.DefaultView.ToTable(true ,"WX20");
            //comboBox10.DataSource = biao.DefaultView.ToTable( true ,"WX20" );
            //comboBox10.DisplayMember = "WX20";
            //纸卡片长
            //DataTable zkc = biao.DefaultView.ToTable(true ,"WX23");
            comboBox20.DataSource = biao.DefaultView.ToTable( true ,"WX23" );
            comboBox20.DisplayMember = "WX23";
            //边
            //DataTable b = biao.DefaultView.ToTable(true ,"WX24");
            comboBox19.DataSource = biao.DefaultView.ToTable( true ,"WX24" );
            comboBox19.DisplayMember = "WX24";
            //宽
            //DataTable k = biao.DefaultView.ToTable(true ,"WX25");
            comboBox18.DataSource = biao.DefaultView.ToTable( true ,"WX25" );
            comboBox18.DisplayMember = "WX25";
            //边
            //DataTable kb = biao.DefaultView.ToTable(true ,"WX26");
            comboBox17.DataSource = biao.DefaultView.ToTable( true ,"WX26" );
            comboBox17.DisplayMember = "WX26";
            //纸箱盒长
            //DataTable zxc = biao.DefaultView.ToTable(true ,"WX27");
            comboBox13.DataSource = biao.DefaultView.ToTable( true ,"WX27" );
            comboBox13.DisplayMember = "WX27";
            //宽.高
            //DataTable kg = biao.DefaultView.ToTable(true ,"WX28");
            comboBox12.DataSource = biao.DefaultView.ToTable( true ,"WX28" );
            comboBox12.DisplayMember = "WX28";
            //边数据
            //DataTable bsj = biao.DefaultView.ToTable(true ,"WX29");
            comboBox11.DataSource = biao.DefaultView.ToTable( true ,"WX29" );
            comboBox11.DisplayMember = "WX29";
            //宽
            //DataTable ku = biao.DefaultView.ToTable(true ,"WX30");
            comboBox16.DataSource = biao.DefaultView.ToTable( true ,"WX30" );
            comboBox16.DisplayMember = "WX30";
            //高
            //DataTable ga = biao.DefaultView.ToTable(true ,"WX31");
            comboBox15.DataSource = biao.DefaultView.ToTable( true ,"WX31" );
            comboBox15.DisplayMember = "WX31";
            //边数据
            //DataTable bs = biao.DefaultView.ToTable(true ,"WX32");
            comboBox14.DataSource = biao.DefaultView.ToTable( true ,"WX32" );
            comboBox14.DisplayMember = "WX32";
            //材料要求
            comboBox27.DataSource = biao.DefaultView.ToTable( true ,"WX77" );
            comboBox27.DisplayMember = "WX77";
        }
        private void Edit1_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = View1 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            txtSpe . Text = row [ "WX11" ] . ToString ( );
            textBox36 . Text = row [ "WX14" ] . ToString ( );
            if ( !string . IsNullOrEmpty ( Edit1 . Text ) && biao . Select ( "WX10='" + Edit1 . Text + "'" ) . Length > 0 )
            {
                //txtSpe . Text = biao . Select ( "WX10='" + Edit1 . Text + "'" ) [ 0 ] [ "WX11" ] . ToString ( );
                comboBox22 . Text = biao . Select ( "WX10='" + Edit1 . Text + "'" ) [ 0 ] [ "WX19" ] . ToString ( );
                textBox15 . Text = biao . Select ( "WX10='" + Edit1 . Text + "'" ) [ 0 ] [ "WX12" ] . ToString ( );
                comboBox5 . Text = biao . Select ( "WX10='" + Edit1 . Text + "'" ) [ 0 ] [ "WX13" ] . ToString ( );
                //textBox36 . Text = biao . Select ( "WX10='" + Edit1 . Text + "'" ) [ 0 ] [ "WX14" ] . ToString ( );
                textBox25 . Text = biao . Select ( "WX10='" + Edit1 . Text + "'" ) [ 0 ] [ "WX15" ] . ToString ( );
                comboBox8 . Text = biao . Select ( "WX10='" + Edit1 . Text + "'" ) [ 0 ] [ "WX18" ] . ToString ( );
                comboBox10 . Text = biao . Select ( "WX10='" + Edit1 . Text + "'" ) [ 0 ] [ "WX20" ] . ToString ( );
                comboBox20 . Text = biao . Select ( "WX10='" + Edit1 . Text + "'" ) [ 0 ] [ "WX23" ] . ToString ( );
                comboBox19 . Text = biao . Select ( "WX10='" + Edit1 . Text + "'" ) [ 0 ] [ "WX24" ] . ToString ( );
                comboBox18 . Text = biao . Select ( "WX10='" + Edit1 . Text + "'" ) [ 0 ] [ "WX25" ] . ToString ( );
                comboBox17 . Text = biao . Select ( "WX10='" + Edit1 . Text + "'" ) [ 0 ] [ "WX26" ] . ToString ( );
                comboBox13 . Text = biao . Select ( "WX10='" + Edit1 . Text + "'" ) [ 0 ] [ "WX27" ] . ToString ( );
                comboBox12 . Text = biao . Select ( "WX10='" + Edit1 . Text + "'" ) [ 0 ] [ "WX28" ] . ToString ( );
                comboBox11 . Text = biao . Select ( "WX10='" + Edit1 . Text + "'" ) [ 0 ] [ "WX29" ] . ToString ( );
                comboBox16 . Text = biao . Select ( "WX10='" + Edit1 . Text + "'" ) [ 0 ] [ "WX30" ] . ToString ( );
                comboBox15 . Text = biao . Select ( "WX10='" + Edit1 . Text + "'" ) [ 0 ] [ "WX31" ] . ToString ( );
                comboBox14 . Text = biao . Select ( "WX10='" + Edit1 . Text + "'" ) [ 0 ] [ "WX32" ] . ToString ( );
                comboBox27 . Text = biao . Select ( "WX10='" + Edit1 . Text + "'" ) [ 0 ] [ "WX77" ] . ToString ( );
            }
            previousOfPrice ( );
        }
        void previousOfPrice ( )
        {
            if ( string.IsNullOrEmpty( comboBox21.Text ) || string.IsNullOrEmpty( Edit1 . Text ) )
                textBox15.Text = "0";
            else
            {
                DataTable dm = bll.GetDataTableOfPrice( comboBox21.Text ,Edit1 . Text );
                if ( dm != null && dm.Rows.Count > 0 )
                    textBox15.Text = dm.Rows[0]["WX13"].ToString( );
                else
                    textBox15.Text = "";
            }
        }
        //乙方
        private void textBox1_TextChanged ( object sender ,EventArgs e )
        {
            DataTable drt = SqlHelper.ExecuteDataTable( "SELECT DGA003,DGA011,DGA017,DGA009,DGA003,DGA008 FROM TPADGA WHERE DGA001=@DGA001" ,new SqlParameter( "@DGA001" ,WX03 ) );
            if ( drt.Rows.Count > 0 )
            {
                textBox1.Text = drt.Rows[0]["DGA003"].ToString( );
                textBox5.Text = drt.Rows[0]["DGA017"].ToString( );
                textBox6.Text = drt.Rows[0]["DGA009"].ToString( );
                textBox4.Text = drt.Rows[0]["DGA011"].ToString( );
                textBox33.Text = drt.Rows[0]["DGA008"].ToString( );
            }
        }
        //采购人
        private void lookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit1.EditValue != null )
            {
                WX02 = lookUpEdit1.EditValue.ToString( );
                textBox3.Text = name.Select( "DBA001='" + WX02 + "'" )[0]["DBA028"].ToString( );
            }
        }
        //箱双m2卡单m2现价
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
            if ( comboBox5.Text != "" && !DateDayRegise.sevenFour( comboBox5 ) )
            {
                this.comboBox5.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多四位,如999.9999,请重新输入" );
            }
        }

        //采购物品数量
        private void comboBox3_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //使用库存数量
        private void comboBox6_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //使用外购数量
        private void comboBox7_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //开合同人
        private void button7_Click ( object sender ,EventArgs e )
        {
            if ( textBox12.Text == "" )
            {
                textBox12.Text = Logins.username;
                WX05 = textBox12.Text;
                string[] str = new string[2];
                str = oddNumbers.contractBatch( "R_PQT" ,WX05 ,textBox12 ,textBox14 ,"WX09" );
                if ( str[0] == "" )
                    textBox12.Text = "";
                else
                    WX09 = str[1];
                textBox14.Text = str[1];
            }
            else if ( textBox12.Text != "" && textBox12.Text == Logins.username )
            {
                textBox12.Text = "";
                WX05 = textBox12.Text;
                WX09 = "";
                textBox14.Text = "";
            }
            if ( textBox78.Text == "" )
                textBox78.Text = Logins.username;
            else if ( textBox78.Text != "" && textBox78.Text == Logins.username )
                textBox78.Text = "";

            dateTimePicker3 . Value = DateTime . Now;
        }
        //成本员
        private void button8_Click ( object sender ,EventArgs e )
        {
            if ( textBox11.Text == "" )
                textBox11.Text = Logins.username;
            else if ( textBox11.Text != "" && textBox11.Text == Logins.username )
                textBox11.Text = "";

            dateTimePicker2 . Value = DateTime . Now;
        }
        //甲方代表
        private void button9_Click ( object sender ,EventArgs e )
        {

        }
        //乙方代表
        private void button10_Click ( object sender ,EventArgs e )
        {
            if ( textBox77.Text == "" )
            {
                textBox77.Text = Logins.username;
            }
            else if ( textBox77.Text != "" && textBox77.Text == Logins.username )
            {
                textBox77.Text = "";
            }
            dateTimePicker8.Value = MulaolaoBll . Drity . GetDt ( );
        }
        //业务经理
        private void button11_Click ( object sender ,EventArgs e )
        {
            if ( textBox75.Text == "" )
            {
                textBox75.Text = Logins.username;
            }
            else if ( textBox75.Text != "" && textBox75.Text == Logins.username )
            {
                textBox75.Text = "";
            }
            dateTimePicker9.Value = MulaolaoBll . Drity . GetDt ( );
        }
        //复核人
        private void button12_Click ( object sender ,EventArgs e )
        {
            if ( textBox71.Text == "" )
            {
                textBox71.Text = Logins.username;
            }
            else if ( textBox71.Text != "" && textBox71.Text == Logins.username )
            {
                textBox71.Text = "";
            }
        }
        //审批人
        private void button13_Click ( object sender ,EventArgs e )
        {
            if ( textBox73.Text == "" )
            {
                textBox73.Text = Logins.username;
            }
            else if ( textBox73.Text != "" && textBox73.Text == Logins.username )
            {
                textBox73.Text = "";
            }
            dateTimePicker10.Value = MulaolaoBll . Drity . GetDt ( );
        }
        //产品数量
        private void textBox8_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //窗体关闭
        private void R_Frmwaixiancontract_FormClosing ( object sender ,FormClosingEventArgs e )
        {
            if ( toolSave.Enabled )
            {
                cancel( );
            }
        }
        //装箱率
        private void comboBox8_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox8 );
        }
        private void comboBox8_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox8 );
        }
        private void comboBox8_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox8.Text != "" && !DateDayRegise.elevenSixNumber( comboBox8 ) )
            {
                this.comboBox8.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多四位,如99999.999999,请重新输入" );
            }
        }
        //长
        private void comboBox20_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox20 );
        }
        private void comboBox20_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox20 );
        }
        private void comboBox20_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox20.Text != "" && !DateDayRegise.fiveTwoNum( comboBox20 ) )
            {
                this.comboBox20.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多两位,如999.99,请重新输入" );
            }
        }
        //边
        private void comboBox19_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox19 );
        }
        private void comboBox19_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox19 );
        }
        private void comboBox19_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox19.Text != "" && !DateDayRegise.fiveTwoNum( comboBox19 ) )
            {
                this.comboBox19.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多两位,如999.99,请重新输入" );
            }
        }
        //宽
        private void comboBox18_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox18 );
        }
        private void comboBox18_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox18 );
        }
        private void comboBox18_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox18.Text != "" && !DateDayRegise.fiveTwoNum( comboBox18 ) )
            {
                this.comboBox18.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多两位,如999.99,请重新输入" );
            }
        }
        //边
        private void comboBox17_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox17 );
        }
        private void comboBox17_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox17 );
        }
        private void comboBox17_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox17.Text != "" && !DateDayRegise.fiveTwoNum( comboBox17 ) )
            {
                this.comboBox17.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多两位,如999.99,请重新输入" );
            }
        }
        //长
        private void comboBox13_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox13 );
        }
        private void comboBox13_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox13 );
        }
        private void comboBox13_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox13.Text != "" && !DateDayRegise.fiveTwoNum( comboBox13 ) )
            {
                this.comboBox13.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多两位,如999.99,请重新输入" );
            }
        }
        //宽.高
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
            if ( comboBox12.Text != "" && !DateDayRegise.fiveTwoNum( comboBox12 ) )
            {
                this.comboBox12.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多两位,如999.99,请重新输入" );
            }
        }
        //边数据
        private void comboBox11_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox11 );
        }
        private void comboBox11_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox11 );
        }
        private void comboBox11_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox11.Text != "" && !DateDayRegise.fiveTwoNum( comboBox11 ) )
            {
                this.comboBox11.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多两位,如999.99,请重新输入" );
            }
        }
        //宽
        private void comboBox16_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox16 );
        }
        private void comboBox16_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox16 );
        }
        private void comboBox16_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox16.Text != "" && !DateDayRegise.fiveTwoNum( comboBox16 ) )
            {
                this.comboBox16.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多两位,如999.99,请重新输入" );
            }
        }
        //高
        private void comboBox15_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox15 );
        }
        private void comboBox15_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox15 );
        }
        private void comboBox15_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox15.Text != "" && !DateDayRegise.fiveTwoNum( comboBox15 ) )
            {
                this.comboBox15.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多两位,如999.99,请重新输入" );
            }
        }
        //边数据
        private void comboBox14_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox14 );
        }
        private void comboBox14_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox14 );
        }
        private void comboBox14_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox14.Text != "" && !DateDayRegise.fiveTwoNum( comboBox14 ) )
            {
                this.comboBox14.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多两位,如999.99,请重新输入" );
            }
        }
        //AQL
        private void textBox21_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox20_KeyPress_1 ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox19_KeyPress_1 ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox24_KeyPress_1 ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox23_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox22_KeyPress_1 ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox65_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox17_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox18_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //抽查数量
        private void textBox55_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //表
        string wp = "", ge = "";
        private void bandedGridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            DataRow row = bandedGridView1 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            Edit1 . Text = row["WX10" ] . ToString ( );
            txtSpe . Text = row["WX11" ] . ToString ( );
            textBox15 . Text = row["WX12" ] . ToString ( );
            comboBox5 . Text = row["WX13" ] . ToString ( );
            textBox36 . Text = row["WX14" ] . ToString ( );
            textBox25 . Text = row["WX15" ] . ToString ( );
            comboBox8 . Text = 0 . ToString ( );
            comboBox8 . Text = row["WX18" ] . ToString ( );
            comboBox22 . Text = row["WX19" ] . ToString ( );
            comboBox10 . Text = row["WX20" ] . ToString ( );
            if ( !string . IsNullOrEmpty ( row["WX21" ] . ToString ( ) ) )
                dateTimePicker4 . Value = Convert . ToDateTime ( row["WX21" ] );
            if ( !string . IsNullOrEmpty ( row["WX22" ] . ToString ( ) ) )
                dateTimePicker5 . Value = Convert . ToDateTime ( row["WX22" ] );
            comboBox28 . Text = row["WX77" ] . ToString ( );
            comboBox20 . Text = row["WX23" ] . ToString ( );
            comboBox19 . Text = row["WX24" ] . ToString ( );
            comboBox18 . Text = row["WX25" ] . ToString ( );
            comboBox17 . Text = row["WX26" ] . ToString ( );
            comboBox13 . Text = row["WX27" ] . ToString ( );
            comboBox12 . Text = row["WX28" ] . ToString ( );
            comboBox11 . Text = row["WX29" ] . ToString ( );
            comboBox16 . Text = row["WX30" ] . ToString ( );
            comboBox15 . Text = row["WX31" ] . ToString ( );
            comboBox14 . Text = row["WX32" ] . ToString ( );
            WX03 = row["WX03" ] . ToString ( );
            if ( row["WX17" ] . ToString ( ).Equals( "库存") )
            {
                radioButton10 . Checked = true;
                radioButton10_CheckedChanged ( null ,null );
                textBox2 . Text = row["WX16" ] . ToString ( );
            }
            else if ( row["WX17" ] . ToString ( ) . Equals ( "外购") )
            {
                radioButton11 . Checked = true;
                radioButton11_CheckedChanged ( null ,null );
                textBox30 . Text = row["WX87" ] . ToString ( );
            }
            if ( !string . IsNullOrEmpty ( row["idx" ] . ToString ( ) ) )
                id = Convert . ToInt64 ( row["idx" ] . ToString ( ) );
            wp = Edit1 . Text;
            ge = txtSpe . Text;
        }
        //使用库存数量
        private void textBox2_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //使用库存
        private void radioButton10_CheckedChanged ( object sender ,EventArgs e )
        {
            if ( radioButton10.Checked && ( ord == "实际" || !string.IsNullOrEmpty( textBox7.Text ) ) )
            {
                fc.yesOrNo( comboBox21.Text ,Edit1 . Text ,txtSpe.Text ,textBox29 ,textBox9 ,textBox8.Text );

                //textBox30.Text = Math.Round( Convert.ToDecimal( Operation. MultiThrTbCb ( textBox8 ,comboBox8 ,textBox29.Text ) ) ,0 ).ToString( );
                textBox30 . Text = Math . Round ( Convert . ToDecimal ( Operation . MultiThrTbCs ( textBox8 ,textBox36 ,textBox29 . Text ) ) ,0 ) . ToString ( );

                if ( string . IsNullOrEmpty ( textBox29 . Text ) || textBox29 . Text == "0" )
                    textBox2 . Text = "";
                else
                    //textBox2.Text = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox8 ,comboBox8 ) ) ,0 ).ToString( );
                    textBox2 . Text = Math . Round ( Convert . ToDecimal ( Operation . MultiTwoTbCbes ( textBox8 ,comboBox5 ) ) ,0 ) . ToString ( );

                textBox25 . Text = Math . Round ( Convert . ToDecimal ( Operation . DivisionTc ( textBox8 ,comboBox8 ) ) ,0 ) . ToString ( );
            }
        }
        //使用外购数量
        private void textBox30_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //使用外购
        private void radioButton11_CheckedChanged ( object sender ,EventArgs e )
        {
            if ( radioButton11.Checked && ( ord == "实际" || !string.IsNullOrEmpty( textBox7.Text ) ) )
                get( );
            else
            {
                fc.yesOrNo( comboBox21.Text ,Edit1 . Text ,txtSpe.Text ,textBox29 ,textBox9 ,textBox8.Text );
                textBox30.Text = Math.Round( Convert.ToDecimal( Operation. MultiThrTbCs ( textBox8 ,textBox36 ,textBox29.Text ) ) ,0 ).ToString( );

                textBox25 . Text = Math . Round ( Convert . ToDecimal ( Operation . DivisionTc ( textBox8 ,comboBox8 ) ) ,0 ) . ToString ( );
            }

        }
        void get ( )
        {
            string str = "";
            WX85 = comboBox21.Text;
            WX010 = Edit1 . Text;
            WX011 = txtSpe.Text;
            //AC16=@AC16 AND
            DataTable del = SqlHelper.ExecuteDataTable( "SELECT AC10+ISNULL(AC27,0)-(SELECT SUM(AD12+ISNULL(AD21,0)) FROM R_PQAD WHERE AC18=AD01) AC10 FROM R_PQAC WHERE AC18=(SELECT MAX(AC18) AC18 FROM R_PQAC WHERE  AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05)" /*,new SqlParameter( "@AC16" ,WX82 )*/ ,new SqlParameter( "@AC02" ,WX85 ) ,new SqlParameter( "@AC04" ,WX010 ) ,new SqlParameter( "@AC05" ,WX011 ) );
            if ( del.Rows.Count < 1 )
                str = "0";
            else if ( string.IsNullOrEmpty( del.Rows[0]["AC10"].ToString( ) ) )
                str = "0";
            else
                str = del.Rows[0]["AC10"].ToString( );

            textBox30.Text = Math.Round( Convert.ToDecimal( Operation. MultiThrTbCs ( textBox8 ,textBox36 ,str ) ) ,0 ).ToString( );
        }
        //产品名称
        private void comboBox7_SelectedValueChanged ( object sender ,EventArgs e )
        {
            if ( ord == "计划" || string.IsNullOrEmpty( textBox7.Text ) )
            {
                if ( !string.IsNullOrEmpty( comboBox7.Text ) )
                    comboBox21.Text = comboBox7.SelectedValue.ToString( );
            }
        }
        #endregion

        #region Table
        decimal WX012 = 0M, WX013 = 0M, WX023 = 0M, WX024 = 0M, WX025 = 0, WX026 = 0, WX027 = 0M, WX028 = 0M, WX029 = 0M, WX030 = 0M, WX031 = 0M, WX032 = 0M, WX018 = 0M, WX014 = 0M;
        long WX015 = 0, WX016 = 0, WX087 = 0, id = 0;
        string WX019 = "", WX020 = "", WX077 = "", WX017 = "";
        DateTime WX021 = MulaolaoBll . Drity . GetDt ( ), WX022 = MulaolaoBll . Drity . GetDt ( );
        //新建
        void adds ( )
        {
            WX83 = comboBox7.Text;
            WX85 = comboBox21.Text;
            if ( string.IsNullOrEmpty( textBox8.Text ) )
                WX086 = 0;
            else
                WX086 = Convert.ToInt64( textBox8.Text );
            if ( string.IsNullOrEmpty( textBox15.Text ) )
                WX012 = 0M;
            else
                WX012 = Convert.ToDecimal( textBox15.Text );
            if ( string.IsNullOrEmpty( comboBox5.Text ) )
                WX013 = 0M;
            else
                WX013 = Convert.ToDecimal( comboBox5.Text );
            if ( string.IsNullOrEmpty( textBox36.Text ) )
                WX014 = 0;
            else
                WX014 = Convert.ToDecimal( textBox36.Text );
            if ( string.IsNullOrEmpty( textBox25.Text ) )
                WX015 = 0;
            else
                WX015 = Convert.ToInt64( textBox25.Text );
            if ( radioButton10.Checked )
            {
                WX017 = "库存";
                if ( string.IsNullOrEmpty( textBox2.Text ) )
                    WX016 = 0;
                else
                    WX016 = Convert.ToInt64( textBox2.Text );
                WX087 = 0;
            }
            else
            {
                WX017 = "外购";
                if ( string.IsNullOrEmpty( textBox30.Text ) )
                    WX087 = 0;
                else
                    WX087 = Convert.ToInt64( textBox30.Text );
                WX016 = 0;
            }
            if ( string.IsNullOrEmpty( comboBox8.Text ) )
                WX018 = 0;
            else
                WX018 = Convert.ToDecimal( comboBox8.Text );
            WX019 = comboBox22.Text;
            WX020 = comboBox10.Text;
            WX021 = dateTimePicker4.Value;
            WX022 = dateTimePicker5.Value;
            WX077 = comboBox28.Text;
            if ( string.IsNullOrEmpty( comboBox20.Text ) )
                WX023 = 0M;
            else
                WX023 = Convert.ToDecimal( comboBox20.Text );
            if ( string.IsNullOrEmpty( comboBox19.Text ) )
                WX024 = 0M;
            else
                WX024 = Convert.ToDecimal( comboBox19.Text );
            if ( string.IsNullOrEmpty( comboBox18.Text ) )
                WX025 = 0M;
            else
                WX025 = Convert.ToDecimal( comboBox18.Text );
            if ( string.IsNullOrEmpty( comboBox17.Text ) )
                WX026 = 0M;
            else
                WX026 = Convert.ToDecimal( comboBox17.Text );
            if ( string.IsNullOrEmpty( comboBox13.Text ) )
                WX027 = 0M;
            else
                WX027 = Convert.ToDecimal( comboBox13.Text );
            if ( string.IsNullOrEmpty( comboBox12.Text ) )
                WX028 = 0M;
            else
                WX028 = Convert.ToDecimal( comboBox12.Text );
            if ( string.IsNullOrEmpty( comboBox11.Text ) )
                WX029 = 0M;
            else
                WX029 = Convert.ToDecimal( comboBox11.Text );
            if ( string.IsNullOrEmpty( comboBox16.Text ) )
                WX030 = 0M;
            else
                WX030 = Convert.ToDecimal( comboBox16.Text );
            if ( string.IsNullOrEmpty( comboBox15.Text ) )
                WX031 = 0M;
            else
                WX031 = Convert.ToDecimal( comboBox15.Text );
            if ( string.IsNullOrEmpty( comboBox14.Text ) )
                WX032 = 0M;
            else
                WX032 = Convert.ToDecimal( comboBox14.Text );
            WX010 = Edit1.Text;
            WX011 = txtSpe.Text;

        }
        void build ( )
        {
            //DataRow row;
            DataTable dei = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQT WHERE WX82=@WX82 AND WX10=@WX10 AND WX11=@WX11" ,new SqlParameter( "@WX82" ,WX82 ) ,new SqlParameter( "@WX10" ,WX010 ) ,new SqlParameter( "@WX11" ,WX011 ) );
            if ( dei.Rows.Count < 1 )
            {
                StringBuilder strSql = new StringBuilder( );
                strSql.AppendFormat( "INSERT INTO R_PQT (WX82,WX10,WX11,WX12,WX13,WX14,WX15,WX16,WX17,WX18,WX19,WX20,WX21,WX22,WX23,WX24,WX25,WX26,WX27,WX28,WX29,WX30,WX31,WX32,WX77,WX83,WX85,WX86,WX87,WX03) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}','{27}','{28}','{29}')" ,WX82 ,WX010 ,WX011 ,WX012 ,WX013 ,WX014 ,WX015 ,WX016 ,WX017 ,WX018 ,WX019 ,WX020 ,WX021 ,WX022 ,WX023 ,WX024 ,WX025 ,WX026 ,WX027 ,WX028 ,WX029 ,WX030 ,WX031 ,WX032 ,WX077 ,WX83 ,WX85 ,WX086 ,WX087 ,WX03 );
                int count = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
                if ( count < 1 )
                    MessageBox.Show( "录入数据失败" );
                else
                {
                    MessageBox.Show( "成功录入数据" );
                    try
                    {
                        if ( label83.Visible == true )
                            stateOfOdd = "维护新建";
                        else
                        {
                            if ( sav == "1" )
                                stateOfOdd = "新增新建";
                            else
                                stateOfOdd = "更改新建";
                        }
                        SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_349" ,"外箱、中包、彩盒、纸片（卡）等采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,WX82 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"新建" ,stateOfOdd ) );
                    }
                    catch { }
                    finally {
                        every( );
                        assginContrac( );
                        button14_Click( null ,null );
                    }
                }
            }
            else
                MessageBox.Show( "单号：" + WX82 + "\n\r物品名称.式样形状流水号：" + WX010 + "\n\r规格：" + WX011 + "\n\r的数据已经存在,请核实后再录入" );
        }
        void buildes ( )
        {
            DataTable error = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQT WHERE WX85=@WX85 AND WX10=@WX10 AND WX11=@WX11 AND WX01='' AND WX82=(SELECT MAX(WX82) FROM R_PQT WHERE WX85=@WX85 AND WX10=@WX10 AND WX11=@WX11 AND WX01='')" ,new SqlParameter( "@WX85" ,WX85 ) ,new SqlParameter( "@WX10" ,WX010 ) ,new SqlParameter( "@WX11" ,WX011 ) );
            if ( error.Rows.Count > 0 )
            {
                if ( error.Select( "WX12='" + WX012 + "'" ).Length <= 0 )
                    MessageBox.Show( "箱双m2卡单m2原价与计划订单不一致,应为:" + error.Rows[0]["WX12"].ToString( ) + "" );
                else
                {
                    if ( error.Select( "WX13='" + WX013 + "'" ).Length <= 0 )
                        MessageBox.Show( "箱双m2卡单m2现价与计划订单不一致,应为:" + error.Rows[0]["WX13"].ToString( ) + "" );
                    else
                    {
                        if ( error.Select( "WX14='" + WX014 + "'" ).Length <= 0 )
                            MessageBox.Show( "每套物品数量与计划订单不一致,应为:" + error.Rows[0]["WX14"].ToString( ) + "" );
                        else
                        {
                            if ( error.Select( "WX18='" + WX018 + "'" ).Length <= 0 )
                                MessageBox.Show( "装箱率与计划订单不一致,应为:" + error.Rows[0]["WX18"].ToString( ) + "" );
                            else
                            {
                                if ( error.Select( "WX23='" + WX023 + "'" ).Length <= 0 )
                                    MessageBox.Show( "纸卡片长与计划订单不一致,应为:" + error.Rows[0]["WX23"].ToString( ) + "" );
                                else
                                {
                                    if ( error.Select( "WX24='" + WX024 + "'" ).Length <= 0 )
                                        MessageBox.Show( "纸卡片边与计划订单不一致,应为:" + error.Rows[0]["WX24"].ToString( ) + "" );
                                    else
                                    {
                                        if ( error.Select( "WX25='" + WX025 + "'" ).Length <= 0 )
                                            MessageBox.Show( "纸卡片宽与计划订单不一致,应为:" + error.Rows[0]["WX25"].ToString( ) + "" );
                                        else
                                        {
                                            if ( error.Select( "WX26='" + WX026 + "'" ).Length <= 0 )
                                                MessageBox.Show( "纸卡片边与计划订单不一致,应为:" + error.Rows[0]["WX26"].ToString( ) + "" );
                                            else
                                            {
                                                if ( error.Select( "WX27='" + WX027 + "'" ).Length <= 0 )
                                                    MessageBox.Show( "纸箱盒长与计划订单不一致,应为:" + error.Rows[0]["WX27"].ToString( ) + "" );
                                                else
                                                {
                                                    if ( error.Select( "WX28='" + WX028 + "'" ).Length <= 0 )
                                                        MessageBox.Show( "宽.高与计划订单不一致,应为:" + error.Rows[0]["WX28"].ToString( ) + "" );
                                                    else
                                                    {
                                                        if ( error.Select( "WX29='" + WX029 + "'" ).Length <= 0 )
                                                            MessageBox.Show( "边数据与计划订单不一致,应为:" + error.Rows[0]["WX29"].ToString( ) + "" );
                                                        else
                                                        {
                                                            if ( error.Select( "WX30='" + WX030 + "'" ).Length <= 0 )
                                                                MessageBox.Show( "宽与计划订单不一致,应为:" + error.Rows[0]["WX30"].ToString( ) + "" );
                                                            else
                                                            {
                                                                if ( error.Select( "WX31='" + WX031 + "'" ).Length <= 0 )
                                                                    MessageBox.Show( "高与计划订单不一致,应为:" + error.Rows[0]["WX31"].ToString( ) + "" );
                                                                else
                                                                {
                                                                    if ( error.Select( "WX32='" + WX032 + "'" ).Length <= 0 )
                                                                        MessageBox.Show( "边数据与计划订单不一致,应为:" + error.Rows[0]["WX32"].ToString( ) + "" );
                                                                    else
                                                                        build( );
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
                    }
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
                string sx = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox8 ,comboBox8 ) ) ,0 ).ToString( );
                if ( !string.IsNullOrEmpty( sx ) && !string.IsNullOrEmpty( textBox30.Text ) )
                {
                    if ( Convert.ToDecimal( sx ) != Convert.ToDecimal( textBox30.Text ) )
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
                string sx = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox8 ,comboBox8 ) ) ,0 ).ToString( );
                if ( !string.IsNullOrEmpty( sx ) && !string.IsNullOrEmpty( textBox30.Text ) )
                {
                    if ( Convert.ToDecimal( sx ) != Convert.ToDecimal( textBox30.Text ) )
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
                    string sx = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox8 ,comboBox8 ) ) ,0 ).ToString( );
                    if ( !string.IsNullOrEmpty( sx ) && !string.IsNullOrEmpty( textBox30.Text ) )
                    {
                        if ( Convert.ToDecimal( sx ) != Convert.ToDecimal( textBox30.Text ) )
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
                if ( !string.IsNullOrEmpty( textBox29.Text ) && !string.IsNullOrEmpty( textBox2.Text ) )
                {
                    if ( Convert.ToDecimal( textBox29.Text ) < Convert.ToDecimal( textBox2.Text ) )
                        MessageBox.Show( "出库数量必须小于库存数量" );
                    //且出库数小于等于库存数量
                    else
                    {
                        string str = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox8 ,comboBox8 ) ) ,0 ).ToString( );
                        if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox2.Text ) )
                            MessageBox.Show( "出库数量有误,请核查" );
                        else
                            buildes( );
                    }
                }
            }
        }
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( comboBox21.Text ) )
            {
                MessageBox.Show( "货号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( textBox14.Text ) )
            {
                MessageBox.Show( "合同批号不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( WX03 ) || string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "请选择供应商" );
                return;
            }
            if ( string.IsNullOrEmpty( Edit1.Text ) )
            {
                MessageBox.Show( "物品名称不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox10.Text ) )
            {
                MessageBox.Show( "类别不可以为空" );
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
            adds( );

            #region 计划  更改新建  无流水号
            if ( ord == "计划" || string.IsNullOrEmpty( textBox7.Text ) )
            {
                //计划可以开具多份
                //同货号、物料名称、规格是否已经开过计划订单
                DataTable yesNoAcPlan = SqlHelper.ExecuteDataTable( "SELECT AC03+ISNULL(AC26,0) AC03,AC18 FROM R_PQAC WHERE AC18=(SELECT MAX(AC18) FROM R_PQAC WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05)" ,new SqlParameter( "@AC02" ,WX85 ) ,new SqlParameter( "@AC04" ,WX010 ) ,new SqlParameter( "@AC05" ,WX011 ) );
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
                            if ( WX09.Length > 8 && WX09.Substring( 0 ,8 ) == "MLL-0001" )
                                outSouces( );
                            else
                                MessageBox.Show( "此合同为补开,请找总经理处理" );
                        }
                    }
                    //无  只能开外购
                    else
                    {
                        //开合同人是否是MLL-0001
                        if ( WX09.Length > 8 && WX09.Substring( 0 ,8 ) == "MLL-0001" )
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
            else if ( ord == "实际" || !string.IsNullOrEmpty( textBox7.Text ) )
            {
                
                bool result = pc.PlanActual( WX010 ,WX011 ,WX85 );
                bool vode = pc.PlanInDataBaseCarton( WX01 ,WX010 ,WX011 );
                if ( result == true )
                {
                    if ( vode == true )
                        outSouce( );
                    else
                    {
                        if ( WX09.Length > 8 && WX09.Substring( 0 ,8 ) == "MLL-0001" )
                            outSouce( );
                        else
                            MessageBox.Show( "此单为补开,需要总经理处理" );
                    }
                }
                else
                {
                    if ( vode == true )
                        plan( );
                    else
                    {
                        if ( WX09.Length > 8 && WX09.Substring( 0 ,8 ) == "MLL-0001" )
                            plan( );
                        else
                            MessageBox.Show( "此单为补开,需要总经理处理" );
                    }
                }
            }
            #endregion
        }
        //删除
        private void dele ()
        {
            every( );
            button14_Click( null ,null );
        }
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==

            DialogResult . Cancel )
                return;
            StringBuilder strSql = new StringBuilder( );
            if ( WX010 == wp && WX011 == ge )
            {
                strSql = new StringBuilder( );
                strSql . AppendFormat ( "DELETE FROM R_PQT WHERE WX82='{1}' AND idx='{0}'" , id , WX82 );
                int count = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
                if ( count < 1 )
                    MessageBox.Show( "删除数据失败" );
                else
                {
                    MessageBox.Show( "成功删除数据" );
                    try
                    {
                        if ( label83.Visible == true )
                            stateOfOdd = "维护删除";
                        else
                        {
                            if ( sav == "1" )
                                stateOfOdd = "新增删除";
                            else
                                stateOfOdd = "更改删除";
                        }
                        SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_349" ,"外箱、中包、彩盒、纸片（卡）等采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,WX82 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"删除" ,stateOfOdd ) );
                    }
                    catch { }
                    finally { dele( ); }
                }
            }
            else
            {
                DataTable der = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQT WHERE WX82=@WX82 AND WX10=@WX10 AND WX11=@WX11" ,new SqlParameter( "@WX82" ,WX82 ) ,new SqlParameter( "@WX10" ,wp ) ,new SqlParameter( "@WX11" ,ge ) );
                if ( der.Rows.Count < 1 )
                    MessageBox.Show( "不存在\n\r单号：" + WX82 + "\n\r物品名称.式样形状流水号：" + wp + "\n\r规格：" + ge + "\n\r的数据,请核实后再删除" );
                else
                {
                    strSql = new StringBuilder( );
                    strSql . AppendFormat ( "DELETE FROM R_PQT WHERE WX82='{1}' AND  idx='{0}'" , id , WX82 );
                    int count = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
                    if ( count < 1 )
                        MessageBox.Show( "删除数据失败" );
                    else
                    {
                        MessageBox.Show( "成功删除数据" );
                        try
                        {
                            if ( label83.Visible == true )
                                stateOfOdd = "维护删除";
                            else
                            {
                                if ( sav == "1" )
                                    stateOfOdd = "新增删除";
                                else
                                    stateOfOdd = "更改删除";
                            }
                            SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_349" ,"外箱、中包、彩盒、纸片（卡）等采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,WX82 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"删除" ,stateOfOdd ) );
                        }
                        catch { }
                        finally { dele( ); }
                    }
                }
            }
        }
        //编辑
        void up ()
        {
            every( );
            button14_Click( null ,null );
        }
        void edit ( )
        {
            StringBuilder strSql = new StringBuilder( );//,WX90='{29}'  WX090 , 
            strSql . AppendFormat ( "UPDATE R_PQT SET WX12='{0}',WX13='{1}',WX14='{2}',WX15='{3}',WX16='{4}',WX17='{5}',WX18='{6}',WX19='{7}',WX20='{8}',WX21='{9}',WX22='{10}',WX23='{11}',WX24='{12}',WX25='{13}',WX26='{14}',WX27='{15}',WX28='{16}',WX29='{17}',WX30='{18}',WX31='{19}',WX32='{20}',WX77='{21}',WX86='{22}',WX83='{23}',WX85='{24}',WX87='{25}',WX10='{27}',WX11='{28}' WHERE WX82='{29}' AND idx='{26}'" , WX012 , WX013 , WX014 , WX015 , WX016 , WX017 , WX018 , WX019 , WX020 , WX021 , WX022 , WX023 , WX024 , WX025 , WX026 , WX027 , WX028 , WX029 , WX030 , WX031 , WX032 , WX077 , WX086 , WX83 , WX85 , WX087 , id , WX010 , WX011 , WX82 );
            int count = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
            if ( count < 1 )
                MessageBox.Show( "数据编辑失败" );
            else
            {
                MessageBox.Show( "数据编辑成功" );

                try
                {
                    if ( label83.Visible == true )
                        stateOfOdd = "维护编辑";
                    else
                    {
                        if ( sav == "1" )
                            stateOfOdd = "新增编辑";
                        else
                            stateOfOdd = "更改编辑";
                    }
                    SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_349" ,"外箱、中包、彩盒、纸片（卡）等采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,WX82 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"编辑" ,stateOfOdd ) );
                }
                catch { }
                finally
                {
                    up( );
                    assginContrac( );
                }
            }
        }
        void builds ( )
        {
            DataTable dei = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQT WHERE WX82=@WX82 AND WX10=@WX10 AND WX11=@WX11" ,new SqlParameter( "@WX82" ,WX82 ) ,new SqlParameter( "@WX10" ,WX010 ) ,new SqlParameter( "@WX11" ,WX011 ) );
            if ( dei.Rows.Count < 1 )
            {
                StringBuilder strSql = new StringBuilder( );//,WX90='{29}'   WX090 ,
                strSql . AppendFormat ( "UPDATE R_PQT SET WX12='{0}',WX13='{1}',WX14='{2}',WX15='{3}',WX16='{4}',WX17='{5}',WX18='{6}',WX19='{7}',WX20='{8}',WX21='{9}',WX22='{10}',WX23='{11}',WX24='{12}',WX25='{13}',WX26='{14}',WX27='{15}',WX28='{16}',WX29='{17}',WX30='{18}',WX31='{19}',WX32='{20}',WX77='{21}',WX86='{22}',WX83='{23}',WX85='{24}',WX87='{25}',WX10='{27}',WX11='{28}' WHERE WX82='{29}' AND idx='{26}'" , WX012 , WX013 , WX014 , WX015 , WX016 , WX017 , WX018 , WX019 , WX020 , WX021 , WX022 , WX023 , WX024 , WX025 , WX026 , WX027 , WX028 , WX029 , WX030 , WX031 , WX032 , WX077 , WX086 , WX83 , WX85 , WX087 , id , WX010 , WX011 , WX82 );
                int count = SqlHelper.ExecuteNonQuery( strSql.ToString( ) );
                if ( count < 1 )
                    MessageBox.Show( "数据编辑失败" );
                else
                {
                    MessageBox.Show( "数据编辑成功" );
                    try
                    {
                        if ( label83.Visible == true )
                            stateOfOdd = "维护编辑";
                        else
                        {
                            if ( sav == "1" )
                                stateOfOdd = "新增编辑";
                            else
                                stateOfOdd = "更改编辑";
                        }
                        SqlHelper.ExecuteNonQuery( MulaolaoBll.Drity.DrityOfComparation( "R_349" ,"外箱、中包、彩盒、纸片（卡）等采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,WX82 ,strSql.ToString( ).Replace( "'" ,"''" ) ,"编辑" ,stateOfOdd ) );
                    }
                    catch { }
                    finally
                    {
                        up( );
                        assginContrac( );
                    }
                }
            }
            else
                MessageBox.Show( "单号：" + WX82 + "\n\r物品名称.式样形状流水号：" + WX010 + "\n\r规格：" + WX011 + "\n\r的数据已经存在,请核实后再录入" );
        }
        void planOrActual ( )
        {
            if ( radioButton10.Checked )
            {
                if ( !string.IsNullOrEmpty( textBox29.Text ) && !string.IsNullOrEmpty( textBox2.Text ) )
                {
                    if ( Convert.ToDecimal( textBox29.Text ) < Convert.ToDecimal( textBox2.Text ) )
                        MessageBox.Show( "出库数量大于库存数量,请更改出库数量" );
                    else
                    {
                        string str = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox8 ,comboBox8 ) ) ,0 ).ToString( );
                        if ( !string.IsNullOrEmpty( str ) )
                        {
                            if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox2.Text ) )
                                MessageBox.Show( "出库数量有误,请核查" );
                            else
                                builds( );
                        }
                    }
                }
            }
            else
            {
                string str = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox8 ,comboBox8 ) ) ,0 ).ToString( );
                if ( !string.IsNullOrEmpty( str ) && !string.IsNullOrEmpty( textBox30.Text ) )
                {
                    if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox30.Text ) )
                        MessageBox.Show( "外购数量有误,请核查" );
                    else
                    {
                        if ( Logins.number == "MLL-0001" )
                            builds( );
                        else
                        {
                            if ( !string.IsNullOrEmpty( textBox29.Text ) && Convert.ToDecimal( textBox29.Text ) > 0 )
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
            if ( string.IsNullOrEmpty( comboBox21.Text ) )
                MessageBox.Show( "货号不可为空" );
            else
            {
                if ( textBox14.Text == "" )
                    MessageBox.Show( "合同批号不可为空" );
                else
                {
                    if ( string.IsNullOrEmpty( Edit1.Text ) )
                        MessageBox.Show( "物品名称不可为空" );
                    else
                    {
                        if ( string.IsNullOrEmpty( comboBox10.Text ) )
                            MessageBox.Show( "类别不可以为空" );
                        else
                        {
                            if ( !radioButton10.Checked && !radioButton11.Checked )
                                MessageBox.Show( "请选择库存或者外购" );
                            else
                            {
                                //if ( dateTimePicker4.Value < MulaolaoBll . Drity . GetDt ( ).AddDays( 5 ) )
                                //    MessageBox.Show( "约定供期必须在当天的基础上延迟5天" );
                                //else
                                //{
                                adds( );

                                if ( WX010 == wp && WX011 == ge )
                                {
                                    if ( radioButton10.Checked )
                                    {
                                        if ( !string.IsNullOrEmpty( textBox29.Text ) && !string.IsNullOrEmpty( textBox2.Text ) )
                                        {
                                            if ( Convert.ToDecimal( textBox29.Text ) < Convert.ToDecimal( textBox2.Text ) )
                                                MessageBox.Show( "出库数量大于库存数量,请修改出库数量" );
                                            else
                                            {
                                                string str = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox8 ,comboBox8 ) ) ,0 ).ToString( );
                                                if ( !string.IsNullOrEmpty( str ) )
                                                {
                                                    if ( Convert.ToDecimal( str ) != Convert.ToDecimal( textBox2.Text ) )
                                                        MessageBox.Show( "出库数量有误,请核实" );
                                                    else
                                                        edit( );
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        string sx = Math.Round( Convert.ToDecimal( Operation.DivisionTc( textBox8 ,comboBox8 ) ) ,0 ).ToString( );
                                        if ( !string.IsNullOrEmpty( sx ) && !string.IsNullOrEmpty( textBox30.Text ) )
                                        {
                                            if ( Convert.ToDecimal( sx ) != Convert.ToDecimal( textBox30.Text ) )
                                                MessageBox.Show( "外购数量有误,请核实" );
                                            else
                                            {
                                                if ( Logins.number == "MLL-0001" )
                                                    edit( );
                                                else
                                                {
                                                    if ( !string.IsNullOrEmpty( textBox29.Text ) && textBox29.Text != "0" )
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
                                    if ( ord == "计划" || string.IsNullOrEmpty( textBox7.Text ) )
                                    {
                                        DataTable plan = SqlHelper.ExecuteDataTable( "SELECT AC03+ISNULL(AC26,0)-(SELECT SUM(AD05+ISNULL(AD20,0)) AD05 FROM R_PQAD  WHERE AC18=AD01) AD05  FROM R_PQAC WHERE AC18=(SELECT MAX(AC18) FROM R_PQAC WHERE AC02=@AC02 AND AC04=@AC04 AND AC05=@AC05) GROUP BY AC03,AC18,ISNULL(AC26,0)" ,new SqlParameter( "@AC02" ,WX85 ) ,new SqlParameter( "@AC04" ,WX010 ) ,new SqlParameter( "@AC05" ,WX011 ) );
                                        if ( plan.Rows.Count > 0 && !string.IsNullOrEmpty( plan.Rows[0]["AD05"].ToString( ) ) && plan.Rows[0]["AD05"].ToString( ) != "0" )
                                            //MessageBox.Show( "库存表中已经存在\n\r货号:" + WX85 + "\n\r物料名称:" + WX010 + "\n\r规格:" + WX011 + "\n\r的记录,且入库数量大于出库数量。不允许新建此计划订单" );
                                            planOrActual( );
                                        else
                                            planOrActual( );
                                    }
                                    else if ( ord == "实际" || !string.IsNullOrEmpty( textBox7.Text ) )
                                    {
                                        // AND WX05=@WX05
                                        DataTable dwo = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQT WHERE WX01=@WX01 AND WX10=@WX10 AND WX11=@WX11 AND WX17=@WX17" ,new SqlParameter( "@WX01" ,WX01 ) ,new SqlParameter( "@WX10" ,WX010 ) ,new SqlParameter( "@WX11" ,WX011 ) /*,new SqlParameter( "@WX05" ,WX05 )*/ ,new SqlParameter( "@WX17" ,WX017 ) );
                                        if ( dwo.Rows.Count > 0 )
                                        {
                                            //开过的合同中是否包含此流水(针对可能合批)
                                            for ( int k = 0 ; k < dwo.Rows.Count ; k++ )
                                            {
                                                if ( dwo.Rows[k]["WX01"].ToString( ).Contains( WX01 ) || WX01.Contains( dwo.Rows[k]["WX01"].ToString( ) ) )
                                                {
                                                    if ( WX09.Length > 0 && WX09.Substring( 0 ,8 ) == "MLL-0001" )
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
                            //}
                        }
                    }
                }
            }
        }
        //Edit Batch
        SelectAll.NumberEditContract numQuery = new SelectAll.NumberEditContract( );
        private void button17_Click ( object sender ,EventArgs e )
        {
            numQuery.textBox1.Text = textBox8.Text;
            numQuery.StartPosition = FormStartPosition.CenterScreen;
            numQuery.PassDataBetweenForm += new SelectAll.NumberEditContract.PassDataBetweenFormHandler( numQuery_PassDataBetweenForm );
            numQuery.ShowDialog( );

            if ( numQu == "yes" )
            {
                if ( label83.Visible == true )
                    stateOfOdd = "维护批量编辑";
                else
                {
                    if ( sav == "1" )
                        stateOfOdd = "新增批量编辑";
                    else
                        stateOfOdd = "更改批量编辑";
                }

                for ( int i = 0 ; i < bandedGridView1.RowCount ; i++ )
                {
                    DataRow row = bandedGridView1 . GetDataRow ( i );
                    if ( row == null )
                        continue;
                    //model.WX86 = string.IsNullOrEmpty( textBox8.Text ) == true ? 0 : Convert.ToInt64( textBox8.Text );
                    model.WX18 = string.IsNullOrEmpty( row["WX18"].ToString( ) ) == true ? 0 : Convert.ToDecimal( row [ "WX18"].ToString( ) );
                    model.WX17 = row [ "WX17"].ToString( );
                    model . IDX = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
                    if ( model . WX17 == "外购" )
                    {

                        model . WX16 = 0;
                        model . WX87 = model . WX15 = model . WX18 == 0 ? 0 : Convert . ToInt64 ( Math . Round ( model . WX86 / model . WX18 ,0 ) );
                    }
                    else if ( model . WX17 == "库存" )
                    {
                        model . WX16 = model . WX15 = model . WX18 == 0 ? 0 : Convert . ToInt64 ( Math . Round ( model . WX86 / model . WX18 ,0 ) );
                        model . WX87 = 0;
                    }
                    else
                    {
                        model . WX15 = model . WX18 == 0 ? 0 : Convert . ToInt64 ( Math . Round ( model . WX86 / model . WX18 ,0 ) );
                        model . WX16 = 0;
                        model . WX87 = 0;
                    }
                    result = false;
                    result = bll.UpdateBatch( model ,"R_349" ,"外箱、中包、彩盒、纸片（卡）等采购合同" ,Logins.username ,MulaolaoBll . Drity . GetDt ( ) ,"批量编辑" ,stateOfOdd ,WX82 );
                    if ( result == false )
                    {
                        MessageBox.Show( "编辑数据失败" );
                        break;
                    }
                    else if ( i == bandedGridView1.RowCount - 1 )
                    {
                        MessageBox.Show( "编辑数据成功" );
                        button14_Click( null ,null );
                    }
                }
            }
        }
        private void numQuery_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            numQu = e.ConTwo;
            model.WX86 = string.IsNullOrEmpty( e.ConOne ) == true ? 0 : Convert.ToInt64( e.ConOne );
        }
        //刷新
        private void button14_Click ( object sender ,EventArgs e )
        {
            //,WX90
            bj = SqlHelper.ExecuteDataTable( "SELECT idx,WX10,WX11,WX12,WX13,WX14,WX15,WX16,WX17,WX18,WX19,WX20,WX21,WX22,WX23,WX24,WX25,WX26,WX27,WX28,WX29,WX30,WX31,WX32,WX77,WX86,WX87,U3,U4,WX92,WX93,WX03 FROM R_PQT WHERE WX82=@WX82 ORDER BY idx DESC" ,new SqlParameter( "@WX82" ,WX82 ) );
            gridControl1.DataSource = bj;
            //bandedGridView1 . BestFitColumns ( );
            assginContrac( );

            //every ( );
        }
        //实际收货日期
        yanpinSelect ys = new yanpinSelect( );
        private void button15_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox.Show( "流水号:" + WX01 + "\n\r物料名称:" + Edit1.Text + "\n\r部件规格:" + txtSpe.Text + "\n\r已经到货？" ,"提示" ,MessageBoxButtons.OKCancel ) == DialogResult.OK )
            {
                ys.ysOne = WX01;
                ys.ysTwo = Edit1.Text;
                ys.ysThr = txtSpe.Text;
                ys.ysFou = "";
                ys.ysFiv = "";
                ys.ysSix = "R_349";
                ys.StartPosition = FormStartPosition.CenterScreen;
                ys.ShowDialog( );
            }
        }
        #endregion

    }
}
