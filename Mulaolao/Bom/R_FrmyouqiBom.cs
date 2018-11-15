using System;
using System . Data;
using System . Data . SqlClient;
using System . Linq;
using System . Windows . Forms;
using Mulaolao . Class;
using StudentMgr;
using Mulaolao . Base;
using System . Collections . Generic;

namespace Mulaolao . Contract
{
    public partial class R_FrmyouqiBom : Form
    {
        MulaolaoBll.Bll.YouQiBomBll bll = null;
        MulaolaoLibrary.YouQiBomLibrary model = null;
        MulaolaoLibrary.YouQiBomHupLibrary _model = null;
        MulaolaoLibrary.PqjbEntity modelPqjb=null;
        MulaolaoLibrary.PqmdEntity modelPqmd=null;
        DataTable pqa, pqb,pqc,pqd,pqe,pqkz,pqas,pqjb,pqmd;
        R519batch btch = new R519batch( );
        int selectIdx=0,selectIdxMd;

        bool result = false;

        public R_FrmyouqiBom ( /*Form1 fm*/ )
        {
            //this.MdiParent = fm;
            InitializeComponent ( );

            GridViewMoHuSelect . SetFilter ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 ,gridView2 ,gridView3 ,gridView4 ,gridView5 ,gridView6 ,gridView7 ,gridView8 ,gridView9 ,View ,View1 } );

            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . gridView1 ,this . gridView2 ,this . gridView3 ,this . gridView4 ,this . gridView5 ,this . gridView6 ,this . gridView7 ,this . gridView8 ,this . gridView9 ,View ,View1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            //this . tabPage8 . Parent = null;
            //this . tabPage9 . Parent = null;
            bll = new MulaolaoBll . Bll . YouQiBomBll ( );
            model = new MulaolaoLibrary . YouQiBomLibrary ( );
            _model = new MulaolaoLibrary . YouQiBomHupLibrary ( );
            modelPqjb = new MulaolaoLibrary . PqjbEntity ( );
            modelPqmd = new MulaolaoLibrary . PqmdEntity ( );
        }

        private void R_FrmyouqiBom_Load( object sender, EventArgs e )
        {
            DataTable powers = bll.GetDataTablePower( Logins.number ,this.Text );
            if (powers != null && powers.Rows.Count > 0)
            {
                for (int i = 0; i < powers.Rows.Count; i++)
                {
                    //运行和查询权限
                    if (powers.Rows[i]["DBB003"].ToString( ) == "T" && powers.Rows[i]["DBB005"].ToString( ) == "T")
                        Ergodic.FormEverySpliEnableTrue( this);
                    else
                        Ergodic.FormEverySpliEnableFalse( this );
                }
            }            
        }

        private void R_FrmyouqiBom_Shown ( object sender ,EventArgs e )
        {
            #region 水帘机
            pqa = bll.GetDataTablePqa( );
            gridControl1.DataSource = pqa;
            DataTable com1 = bll.GetDataTablePqas( );
            DataTable comB1 = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQA01 FROM R_PQA" );
            if ( comB1.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < comB1.Rows.Count ; i++ )
                {
                    comboBox1.Items.Add( comB1.Rows[i]["PQA01"].ToString( ) );
                }
            }
            comboBox2.DataSource = com1.AsEnumerable( ).Select( p => p.Field<int>( "PQA02" ) ).OrderBy( p => p ).Distinct( ).ToList( );
            //comboBox2.DataSource = com1.DefaultView.ToTable( true ,"PQA02" );
            comboBox2.DisplayMember = "PQA02";
            comboBox3.DataSource = com1.AsEnumerable( ).Select( p => p.Field<decimal>( "PQA03" ) ).OrderBy( p => p ).Distinct( ).ToList( );
            //comboBox3.DataSource = com1.DefaultView.ToTable( true ,"PQA03" );
            comboBox3.DisplayMember = "PQA03";
            comboBox4.DataSource = com1.AsEnumerable( ).Select( p => p.Field<int>( "PQA04" ) ).OrderBy( p => p ).Distinct( ).ToList( );
            //comboBox4.DataSource = com1.DefaultView.ToTable( true ,"PQA04" );
            comboBox4.DisplayMember = "PQA04";
            comboBox5.DataSource = com1.AsEnumerable( ).Select( p => p.Field<int>( "PQA05" ) ).OrderBy( p => p ).Distinct( ).ToList( );
            //comboBox5.DataSource = com1.DefaultView.ToTable( true ,"PQA05" );
            comboBox5.DisplayMember = "PQA05";
            comboBox6.DataSource = com1.AsEnumerable( ).Select( p => p.Field<string>( "PQA06" ) ).OrderBy( p => p ).Distinct( ).ToList( );
            //comboBox6.DataSource = com1.DefaultView.ToTable( true ,"PQA06" );
            comboBox6.DisplayMember = "PQA06";
            comboBox7.DataSource = com1.AsEnumerable( ).Select( p => p.Field<string>( "PQA07" ) ).OrderBy( p => p ).Distinct( ).ToList( );
            //comboBox7.DataSource = com1.DefaultView.ToTable( true ,"PQA07" );
            comboBox7.DisplayMember = "PQA07";
            comboBox8.DataSource = com1.AsEnumerable( ).Select( p => p.Field<decimal>( "PQA08" ) ).OrderBy( p => p ).Distinct( ).ToList( );
            //comboBox8.DataSource = com1.DefaultView.ToTable( true ,"PQA08" );
            comboBox8.DisplayMember = "PQA08";
            comboBox9.DataSource = com1.AsEnumerable( ).Select( p => p.Field<decimal>( "PQA09" ) ).OrderBy( p => p ).Distinct( ).ToList( );
            //comboBox9.DataSource = com1.DefaultView.ToTable( true ,"PQA09" );
            comboBox9.DisplayMember = "PQA09";
            comboBox10.DataSource = com1.AsEnumerable( ).Select( p => p.Field<int>( "PQA10" ) ).OrderBy( p => p ).Distinct( ).ToList( );
            //comboBox10.DataSource = com1.DefaultView.ToTable( true ,"PQA10" );
            comboBox10.DisplayMember = "PQA10";
            comboBox52.DataSource = com1.AsEnumerable( ).Select( p => p.Field<string>( "PQA11" ) ).OrderBy( p => p ).Distinct( ).ToList( );
            //comboBox52.DataSource = com1.DefaultView.ToTable( true ,"PQA11" );
            comboBox52.DisplayMember = "PQA11";
            comboBox59.DataSource = com1.AsEnumerable( ).Select( p => p.Field<string>( "PQA12" ) ).OrderBy( p => p ).Distinct( ).ToList( );
            //comboBox59.DataSource = com1.DefaultView.ToTable( true ,"PQA12" );
            comboBox59.DisplayMember = "PQA12";
            #endregion
        }

        #region Event
        private void tabControl1_Selected ( object sender ,TabControlEventArgs e )
        {
            if ( e . TabPage == tabPage1 )
            {
                #region 涂布
                if ( pqc != null )
                    return;
                pqc = bll . GetDataTablePqc ( );
                gridControl3 . DataSource = pqc;
                DataTable com30 = bll . GetDataTablePqcs ( );
                DataTable comB30 = SqlHelper . ExecuteDataTable ( "SELECT DISTINCT PQC01 FROM R_PQC" );
                if ( comB30 . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < comB30 . Rows . Count ; i++ )
                    {
                        comboBox30 . Items . Add ( comB30 . Rows [ i ] [ "PQC01" ] . ToString ( ) );
                    }
                }
                //comboBox30.DataSource = com30.AsEnumerable( ).Select( p => p.Field<int>( "PQC01" ) ).OrderBy( p => p ).Distinct( ).ToList( );
                //comboBox30.DisplayMember = "PQC01";
                comboBox41 . DataSource = com30 . AsEnumerable ( ) . Select ( p => p . Field<string> ( "PQC02" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox41 . DisplayMember = "PQC02";
                comboBox17 . DataSource = com30 . AsEnumerable ( ) . Select ( p => p . Field<string> ( "PQC03" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox17 . DisplayMember = "PQC03";
                comboBox29 . DataSource = com30 . AsEnumerable ( ) . Select ( p => p . Field<int> ( "PQC04" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox29 . DisplayMember = "PQC04";
                comboBox28 . DataSource = com30 . AsEnumerable ( ) . Select ( p => p . Field<decimal> ( "PQC05" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox28 . DisplayMember = "PQC05";
                comboBox27 . DataSource = com30 . AsEnumerable ( ) . Select ( p => p . Field<decimal> ( "PQC06" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox27 . DisplayMember = "PQC06";
                comboBox26 . DataSource = com30 . AsEnumerable ( ) . Select ( p => p . Field<int> ( "PQC07" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox26 . DisplayMember = "PQC07";
                comboBox25 . DataSource = com30 . AsEnumerable ( ) . Select ( p => p . Field<string> ( "PQC08" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox25 . DisplayMember = "PQC08";
                comboBox24 . DataSource = com30 . AsEnumerable ( ) . Select ( p => p . Field<string> ( "PQC09" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox24 . DisplayMember = "PQC09";
                comboBox22 . DataSource = com30 . AsEnumerable ( ) . Select ( p => p . Field<decimal> ( "PQC11" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox22 . DisplayMember = "PQC11";
                comboBox21 . DataSource = com30 . AsEnumerable ( ) . Select ( p => p . Field<decimal> ( "PQC12" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox21 . DisplayMember = "PQC12";
                comboBox56 . DataSource = com30 . AsEnumerable ( ) . Select ( p => p . Field<string> ( "PQC13" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox56 . DisplayMember = "PQC13";
                comboBox57 . DataSource = com30 . AsEnumerable ( ) . Select ( p => p . Field<string> ( "PQC14" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox57 . DisplayMember = "PQC14";
                #endregion
            }
            else if ( e . TabPage == tabPage2 )
            {
                #region 静电
                if ( pqd != null )
                    return;
                pqd = bll . GetDataTablePqd ( );
                gridControl4 . DataSource = pqd;
                DataTable com40 = SqlHelper . ExecuteDataTable ( "SELECT DISTINCT PQD01 FROM R_PQD" );
                if ( com40 . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < com40 . Rows . Count ; i++ )
                    {
                        comboBox40 . Items . Add ( com40 . Rows [ i ] [ "PQD01" ] . ToString ( ) );
                    }
                }
                DataTable jin = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_PQD" );
                DataTable com39 = jin . DefaultView . ToTable ( true ,"PQD02" );
                if ( com39 . Rows . Count > 0 )
                {
                    comboBox39 . DataSource = com39;
                    comboBox39 . DisplayMember = "PQD02";
                }
                DataTable com38 = jin . DefaultView . ToTable ( true ,"PQD03" );
                if ( com38 . Rows . Count > 0 )
                {
                    comboBox38 . DataSource = com38;
                    comboBox38 . DisplayMember = "PQD03";
                }
                DataTable com37 = jin . DefaultView . ToTable ( true ,"PQD04" );
                if ( com37 . Rows . Count > 0 )
                {
                    comboBox37 . DataSource = com37;
                    comboBox37 . DisplayMember = "PQD04";
                }
                DataTable com36 = jin . DefaultView . ToTable ( true ,"PQD05" );
                if ( com36 . Rows . Count > 0 )
                {
                    comboBox36 . DataSource = com36;
                    comboBox36 . DisplayMember = "PQD05";
                }
                DataTable com35 = jin . DefaultView . ToTable ( true ,"PQD06" );
                if ( com35 . Rows . Count > 0 )
                {
                    comboBox35 . DataSource = com35;
                    comboBox35 . DisplayMember = "PQD06";
                }
                DataTable com34 = jin . DefaultView . ToTable ( true ,"PQD07" );
                if ( com34 . Rows . Count > 0 )
                {
                    comboBox34 . DataSource = com34;
                    comboBox34 . DisplayMember = "PQD07";
                }
                DataTable com33 = jin . DefaultView . ToTable ( true ,"PQD08" );
                if ( com33 . Rows . Count > 0 )
                {
                    comboBox33 . DataSource = com33;
                    comboBox33 . DisplayMember = "PQD08";
                }
                DataTable com32 = jin . DefaultView . ToTable ( true ,"PQD09" );
                if ( com32 . Rows . Count > 0 )
                {
                    comboBox32 . DataSource = com32;
                    comboBox32 . DisplayMember = "PQD09";
                }
                DataTable com31 = jin . DefaultView . ToTable ( true ,"PQD10" );
                if ( com31 . Rows . Count > 0 )
                {
                    comboBox31 . DataSource = com31;
                    comboBox31 . DisplayMember = "PQD10";
                }
                DataTable com53 = jin . DefaultView . ToTable ( true ,"PQD11" );
                if ( com53 . Rows . Count > 0 )
                {
                    comboBox53 . DataSource = com53;
                    comboBox53 . DisplayMember = "PQD11";
                }
                DataTable com58 = jin . DefaultView . ToTable ( true ,"PQD12" );
                if ( com58 . Rows . Count > 0 )
                {
                    comboBox58 . DataSource = com58;
                    comboBox58 . DisplayMember = "PQD12";
                }
                #endregion
            }
            else if ( e . TabPage == tabPage3 )
            {
                #region 滚漆
                if ( pqkz != null )
                    return;
                pqkz = bll . GetDataTable ( );
                gridControl6 . DataSource = pqkz;
                DataTable gunqi = bll . GetDataTableOnly ( );
                comboBox60 . DataSource = gunqi . AsEnumerable ( ) . Select ( p => p . Field<string> ( "KZ001" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox60 . DisplayMember = "KZ001";
                comboBox61 . DataSource = gunqi . AsEnumerable ( ) . Select ( p => p . Field<string> ( "KZ002" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox61 . DisplayMember = "KZ002";
                comboBox62 . DataSource = gunqi . AsEnumerable ( ) . Select ( p => p . Field<string> ( "KZ003" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox62 . DisplayMember = "KZ003";
                comboBox64 . DataSource = gunqi . AsEnumerable ( ) . Select ( p => p . Field<decimal> ( "KZ004" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox64 . DisplayMember = "KZ004";
                comboBox63 . DataSource = gunqi . AsEnumerable ( ) . Select ( p => p . Field<decimal> ( "KZ005" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox63 . DisplayMember = "KZ005";
                comboBox66 . DataSource = gunqi . AsEnumerable ( ) . Select ( p => p . Field<decimal> ( "KZ006" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox66 . DisplayMember = "KZ006";
                comboBox65 . DataSource = gunqi . AsEnumerable ( ) . Select ( p => p . Field<decimal> ( "KZ007" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox65 . DisplayMember = "KZ007";
                comboBox68 . DataSource = gunqi . AsEnumerable ( ) . Select ( p => p . Field<decimal> ( "KZ008" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox68 . DisplayMember = "KZ008";
                //comboBox67.DataSource = gunqi.AsEnumerable( ).Select( p => p.Field<decimal>( "KZ009" ) ).OrderBy( p => p ).Distinct( ).ToList( );
                //comboBox67.DisplayMember = "KZ009";
                comboBox69 . DataSource = gunqi . AsEnumerable ( ) . Select ( p => p . Field<string> ( "KZ010" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox69 . DisplayMember = "KZ010";
                comboBox70 . DataSource = gunqi . AsEnumerable ( ) . Select ( p => p . Field<string> ( "KZ011" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox70 . DisplayMember = "KZ011";
                //comboBox67.DataSource = gunqi.AsEnumerable( ).Select( p => p.Field<string>( "KZ012" ) ).OrderBy( p => p ).Distinct( ).ToList( );
                //comboBox67.DisplayMember = "KZ012";
                comboBox67 . DataSource = gunqi . DefaultView . ToTable ( true ,"KZ012" );
                comboBox67 . DisplayMember = "KZ012";
                #endregion
            }
            else if ( e . TabPage == tabPage4 )
            {
                #region 浸漆
                if ( pqe != null )
                    return;
                pqe = bll . GetDataTablePqe ( );
                gridControl5 . DataSource = pqe;
                DataTable com51 = SqlHelper . ExecuteDataTable ( "SELECT DISTINCT PQE01 FROM R_PQE" );
                if ( com51 . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < com51 . Rows . Count ; i++ )
                    {
                        comboBox51 . Items . Add ( com51 . Rows [ i ] [ "PQE01" ] . ToString ( ) );
                    }
                }
                DataTable jq = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_PQE" );
                DataTable com50 = jq . DefaultView . ToTable ( true ,"PQE02" );
                if ( com50 . Rows . Count > 0 )
                {
                    comboBox50 . DataSource = com50;
                    comboBox50 . DisplayMember = "PQE02";
                }
                DataTable com49 = jq . DefaultView . ToTable ( true ,"PQE03" );
                if ( com49 . Rows . Count > 0 )
                {
                    comboBox49 . DataSource = com49;
                    comboBox49 . DisplayMember = "PQE03";
                }
                DataTable com48 = jq . DefaultView . ToTable ( true ,"PQE04" );
                if ( com48 . Rows . Count > 0 )
                {
                    comboBox48 . DataSource = com48;
                    comboBox48 . DisplayMember = "PQE04";
                }
                DataTable com47 = jq . DefaultView . ToTable ( true ,"PQE05" );
                if ( com47 . Rows . Count > 0 )
                {
                    comboBox47 . DataSource = com47;
                    comboBox47 . DisplayMember = "PQE05";
                }
                DataTable com46 = jq . DefaultView . ToTable ( true ,"PQE06" );
                if ( com46 . Rows . Count > 0 )
                {
                    comboBox46 . DataSource = com46;
                    comboBox46 . DisplayMember = "PQE06";
                }
                DataTable com45 = jq . DefaultView . ToTable ( true ,"PQE07" );
                if ( com45 . Rows . Count > 0 )
                {
                    comboBox45 . DataSource = com45;
                    comboBox45 . DisplayMember = "PQE07";
                }
                DataTable com44 = jq . DefaultView . ToTable ( true ,"PQE08" );
                if ( com44 . Rows . Count > 0 )
                {
                    comboBox44 . DataSource = com44;
                    comboBox44 . DisplayMember = "PQE08";
                }
                DataTable com43 = jq . DefaultView . ToTable ( true ,"PQE09" );
                if ( com43 . Rows . Count > 0 )
                {
                    comboBox43 . DataSource = com43;
                    comboBox43 . DisplayMember = "PQE09";
                }
                DataTable com42 = jq . DefaultView . ToTable ( true ,"PQE10" );
                if ( com42 . Rows . Count > 0 )
                {
                    comboBox42 . DataSource = com42;
                    comboBox42 . DisplayMember = "PQE10";
                }
                DataTable com54 = jq . DefaultView . ToTable ( true ,"PQE11" );
                if ( com54 . Rows . Count > 0 )
                {
                    comboBox54 . DataSource = com54;
                    comboBox54 . DisplayMember = "PQE11";
                }
                DataTable com23 = jq . DefaultView . ToTable ( true ,"PQE12" );
                if ( com23 . Rows . Count > 0 )
                {
                    comboBox23 . DataSource = com23;
                    comboBox23 . DisplayMember = "PQE12";
                }
                #endregion
            }
            else if ( e . TabPage == tabPage5 )
            {
                #region 封边
                if ( pqb != null )
                    return;
                pqb = bll . GetDataTablePqb ( );
                gridControl2 . DataSource = pqb;
                DataTable com20 = SqlHelper . ExecuteDataTable ( "SELECT DISTINCT PQB01 FROM R_PQB" );
                if ( com20 . Rows . Count > 0 )
                {
                    for ( int i = 0 ; i < com20 . Rows . Count ; i++ )
                    {
                        comboBox20 . Items . Add ( com20 . Rows [ i ] [ "PQB01" ] . ToString ( ) );
                    }
                }
                DataTable fen = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_PQB" );
                DataTable com18 = fen . DefaultView . ToTable ( true ,"PQB03" );
                if ( com18 . Rows . Count > 0 )
                {
                    comboBox18 . DataSource = com18;
                    comboBox18 . DisplayMember = "PQB03";
                }
                DataTable com16 = fen . DefaultView . ToTable ( true ,"PQB04" );
                if ( com16 . Rows . Count > 0 )
                {
                    comboBox16 . DataSource = com16;
                    comboBox16 . DisplayMember = "PQB04";
                }
                DataTable com15 = fen . DefaultView . ToTable ( true ,"PQB05" );
                if ( com15 . Rows . Count > 0 )
                {
                    comboBox15 . DataSource = com15;
                    comboBox15 . DisplayMember = "PQB05";
                }
                DataTable com14 = fen . DefaultView . ToTable ( true ,"PQB06" );
                if ( com14 . Rows . Count > 0 )
                {
                    comboBox14 . DataSource = com14;
                    comboBox14 . DisplayMember = "PQB06";
                }
                DataTable com13 = fen . DefaultView . ToTable ( true ,"PQB11" );
                if ( com13 . Rows . Count > 0 )
                {
                    comboBox19 . DataSource = com13;
                    comboBox19 . DisplayMember = "PQB11";
                }
                DataTable com12 = fen . DefaultView . ToTable ( true ,"PQB08" );
                if ( com12 . Rows . Count > 0 )
                {
                    comboBox12 . DataSource = com12;
                    comboBox12 . DisplayMember = "PQB08";
                }
                DataTable com11 = fen . DefaultView . ToTable ( true ,"PQB09" );
                if ( com11 . Rows . Count > 0 )
                {
                    comboBox11 . DataSource = com11;
                    comboBox11 . DisplayMember = "PQB09";
                }
                DataTable com55 = fen . DefaultView . ToTable ( true ,"PQB10" );
                if ( com55 . Rows . Count > 0 )
                {
                    comboBox55 . DataSource = com55;
                    comboBox55 . DisplayMember = "PQB10";
                }
                DataTable com013 = fen . DefaultView . ToTable ( true ,"PQB12" );
                if ( com013 . Rows . Count > 0 )
                {
                    comboBox13 . DataSource = com013;
                    comboBox13 . DisplayMember = "PQB12";
                }
                #endregion
            }
            else if ( e . TabPage == tabPage7 )
            {
                #region 化学品辅料
                if ( pqas != null )
                    return;
                pqas = bll . GetDataTablePqase ( );
                gridControl7 . DataSource = pqas;
                DataTable hxp = bll . GetDataTablePqases ( );
                comboBox71 . DataSource = hxp . AsEnumerable ( ) . Select ( p => p . Field<string> ( "AS002" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox71 . DisplayMember = "AS002";
                comboBox72 . DataSource = hxp . AsEnumerable ( ) . Select ( p => p . Field<string> ( "AS003" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox72 . DisplayMember = "AS003";
                comboBox73 . DataSource = hxp . AsEnumerable ( ) . Select ( p => p . Field<string> ( "AS004" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox73 . DisplayMember = "AS004";
                comboBox74 . DataSource = hxp . AsEnumerable ( ) . Select ( p => p . Field<string> ( "AS005" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox74 . DisplayMember = "AS005";
                comboBox75 . DataSource = hxp . AsEnumerable ( ) . Select ( p => p . Field<string> ( "AS007" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox75 . DisplayMember = "AS007";
                comboBox76 . DataSource = hxp . AsEnumerable ( ) . Select ( p => p . Field<string> ( "AS006" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox76 . DisplayMember = "AS006";
                comboBox77 . DataSource = hxp . AsEnumerable ( ) . Select ( p => p . Field<string> ( "AS008" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox77 . DisplayMember = "AS008";
                comboBox78 . DataSource = hxp . AsEnumerable ( ) . Select ( p => p . Field<decimal> ( "AS009" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                comboBox78 . DisplayMember = "AS009";
                #endregion
            }
            else if ( e . TabPage == tabPage8 )
            {
                #region 胶板
                if ( pqjb != null )
                    return;
                pqjb = bll . getTable ( );
                gridControl8 . DataSource = pqjb;
                gridView8 . BestFitColumns ( );

                List<string> speStr = pqjb . AsEnumerable ( ) . Select ( p => p . Field<string> ( "QJB003" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                if ( speStr != null )
                {
                    foreach ( string item in speStr )
                    {
                        txtQJB003 . Properties . Items . Add ( item );
                    }
                }
                txtQJB013 . Properties . DataSource = bll . getGYS ( );
                txtQJB013 . Properties . DisplayMember = "DGA001";
                txtQJB013 . Properties . ValueMember = "DGA001";

                List<string> gysStr = pqjb . AsEnumerable ( ) . Select ( p => p . Field<string> ( "QJB002" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                if ( gysStr == null )
                    return;
                foreach ( string item in gysStr )
                {
                    txtQJB002 . Properties . Items . Add ( item );
                }
                #endregion
            }
            else if ( e . TabPage == tabPage9 )
            {
                #region 密度板
                if ( pqmd != null )
                    return;
                pqmd = bll . getTableMd ( );
                gridControl9 . DataSource = pqmd;
                gridView9 . BestFitColumns ( );

                List<string> speStr = pqmd . AsEnumerable ( ) . Select ( p => p . Field<string> ( "QMD003" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                if ( speStr != null )
                {
                    foreach ( string item in speStr )
                    {
                        txtQMD003 . Properties . Items . Add ( item );
                    }
                }
                txtQMD012 . Properties . DataSource = bll . getGYS ( );
                txtQMD012 . Properties . DisplayMember = "DGA001";
                txtQMD012 . Properties . ValueMember = "DGA001";

                List<string> gysStr = pqmd . AsEnumerable ( ) . Select ( p => p . Field<string> ( "QMD002" ) ) . OrderBy ( p => p ) . Distinct ( ) . ToList ( );
                if ( gysStr == null )
                    return;
                foreach ( string item in gysStr )
                {
                    txtQMD002 . Properties . Items . Add ( item );
                }
                #endregion
            }
        }
        #endregion

        #region 水帘机
        int PQA1 = 0, PQA2 = 0, PQA4 = 0, PQA5 = 0, PQA010 = 0;
        string PQA6 = "", PQA7 = "",PQA011="",PQA012="";
        decimal PQA3 = 0M, PQA8 = 0M, PQA9 = 0M;
        private void comboBox3_LostFocus( object sender, EventArgs e )
        {
            if (comboBox3.Text != "" && !DateDayRegise.foreTwoNum( comboBox3 ))
            {
                this.comboBox3.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多两位,如99.99,请重新输入" );
            }
        }
        private void comboBox5_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void comboBox8_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox8 );
        }
        private void comboBox8_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox8 );
        }
        private void comboBox8_LostFocus( object sender, EventArgs e )
        {
            if (comboBox8.Text != "" && !DateDayRegise.foreOneNum( comboBox8 ))
            {
                this.comboBox8.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如999.9,请重新输入" );
            }           
        }
        private void comboBox9_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox9 );
        }
        private void comboBox9_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox9 );
        }
        private void comboBox9_LostFocus( object sender, EventArgs e )
        {
            if (comboBox9.Text!=""&&!DateDayRegise.fiveThreeNum( comboBox9 ))
            {
                this.comboBox9.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多三位,如99.999,请重新输入" );
            }
        }
        private void comboBox10_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void comboBox4_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void gridView1_Click( object sender, EventArgs e )
        {
            if (gridView1.RowCount == 1)
            {
                comboBox1.Text = gridView1.GetFocusedRowCellValue( "PQA01" ).ToString( );
            }
        }
        string com1 = "", com2 = "", com3 = "", com4 = "", com5 = "", com6 = "", com7 = "", com8 = "", com9 = "", com10 = "", com11 = "", com12 = "";
        private void gridView1_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if ( e.FocusedRowHandle != -999997 )
            {
                if ( btch.plde == "1" )
                {
                    comboBox1.Text = gridView1.GetRowCellValue( 0 ,"PQA01" ).ToString( );
                    comboBox2.Text = gridView1.GetRowCellValue( 0 ,"PQA02" ).ToString( );
                    comboBox3.Text = gridView1.GetRowCellValue( 0 ,"PQA03" ).ToString( );
                    comboBox4.Text = gridView1.GetRowCellValue( 0 ,"PQA04" ).ToString( );
                    comboBox5.Text = gridView1.GetRowCellValue( 0 ,"PQA05" ).ToString( );
                    comboBox6.Text = gridView1.GetRowCellValue( 0 ,"PQA06" ).ToString( );
                    comboBox7.Text = gridView1.GetRowCellValue( 0 ,"PQA07" ).ToString( );
                    comboBox8.Text = gridView1.GetRowCellValue( 0 ,"PQA08" ).ToString( );
                    comboBox9.Text = gridView1.GetRowCellValue( 0 ,"PQA09" ).ToString( );
                    comboBox10.Text = gridView1.GetRowCellValue( 0 ,"PQA10" ).ToString( );
                    comboBox52.Text = gridView1.GetRowCellValue( 0 ,"PQA11" ).ToString( );
                    comboBox59.Text = gridView1.GetRowCellValue( 0 ,"PQA12" ).ToString( );
                    btch.plde = "";
                }
                else
                {
                    comboBox1.Text = gridView1.GetRowCellValue( e.FocusedRowHandle ,"PQA01" ).ToString( );
                    comboBox2.Text = gridView1.GetRowCellValue( e.FocusedRowHandle ,"PQA02" ).ToString( );
                    comboBox3.Text = gridView1.GetRowCellValue( e.FocusedRowHandle ,"PQA03" ).ToString( );
                    comboBox4.Text = gridView1.GetRowCellValue( e.FocusedRowHandle ,"PQA04" ).ToString( );
                    comboBox5.Text = gridView1.GetRowCellValue( e.FocusedRowHandle ,"PQA05" ).ToString( );
                    comboBox6.Text = gridView1.GetRowCellValue( e.FocusedRowHandle ,"PQA06" ).ToString( );
                    comboBox7.Text = gridView1.GetRowCellValue( e.FocusedRowHandle ,"PQA07" ).ToString( );
                    comboBox8.Text = gridView1.GetRowCellValue( e.FocusedRowHandle ,"PQA08" ).ToString( );
                    comboBox9.Text = gridView1.GetRowCellValue( e.FocusedRowHandle ,"PQA09" ).ToString( );
                    comboBox10.Text = gridView1.GetRowCellValue( e.FocusedRowHandle ,"PQA10" ).ToString( );
                    comboBox52.Text = gridView1.GetRowCellValue( e.FocusedRowHandle ,"PQA11" ).ToString( );
                    comboBox59.Text = gridView1.GetRowCellValue( e.FocusedRowHandle ,"PQA12" ).ToString( );
                }

                com1 = comboBox1.Text;
                com2 = comboBox2.Text;
                com3 = comboBox3.Text;
                com4 = comboBox4.Text;
                com5 = comboBox5.Text;
                com6 = comboBox6.Text;
                com7 = comboBox7.Text;
                com8 = comboBox8.Text;
                com9 = comboBox9.Text;
                com10 = comboBox10.Text;
                com11 = comboBox52.Text;
                com12 = comboBox59.Text;
            }
        }
        private void gridView1_CustomDrawRowIndicator( object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e )
        {
            //foreach (DevExpress.XtraGrid.Columns.GridColumn item in gridView1.Columns)
            //{
            //    item.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;   //筛选条件设置为包含  
            //}
        }
        private void comboBox3_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox3 );
        }
        private void comboBox3_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox3 );
        }        
        private void comboBox2_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void comboBox1_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void comboBox1_SelectedValueChanged ( object sender ,EventArgs e )
        {
            string com = comboBox1.Text;
            DataTable com1 = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQA WHERE PQA01=@PQA01" ,new SqlParameter( "@PQA01" ,com ) );
            if ( com1.Rows.Count > 0 )
            {
                comboBox2.Text = com1.Rows[0]["PQA02"].ToString( );
                comboBox3.Text = com1.Rows[0]["PQA03"].ToString( );
                comboBox4.Text = com1.Rows[0]["PQA04"].ToString( );
                comboBox5.Text = com1.Rows[0]["PQA05"].ToString( );
                comboBox6.Text = com1.Rows[0]["PQA06"].ToString( );
                comboBox7.Text = com1.Rows[0]["PQA07"].ToString( );
                comboBox8.Text = com1.Rows[0]["PQA08"].ToString( );
                comboBox9.Text = com1.Rows[0]["PQA09"].ToString( );
                comboBox10.Text = com1.Rows[0]["PQA10"].ToString( );
                comboBox52.Text = com1.Rows[0]["PQA11"].ToString( );
            }
        }
        private void comboBox1_TextChanged( object sender, EventArgs e )
        {
            /*
            string str = comboBox1.Text;
            DataTable comb = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQA WHERE PQA01=@PQA01", new SqlParameter( "@PQA01", str ) );
            if (comb.Rows.Count >0)
            {
                comboBox2.Text = comb.Rows[0]["PQA02"].ToString( );
                comboBox3.Text = comb.Rows[0]["PQA03"].ToString( );
                comboBox4.Text = comb.Rows[0]["PQA04"].ToString( );
                comboBox5.Text = comb.Rows[0]["PQA05"].ToString( );
                comboBox6.Text = comb.Rows[0]["PQA06"].ToString( );
                comboBox7.Text = comb.Rows[0]["PQA07"].ToString( );
                comboBox8.Text = comb.Rows[0]["PQA08"].ToString( );
                comboBox9.Text = comb.Rows[0]["PQA09"].ToString( );
                comboBox10.Text = comb.Rows[0]["PQA10"].ToString( );
                comboBox52.Text = comb.Rows[0]["PQA11"].ToString( );
            }
            */
        }
        private void comboBox1_LostFocus( object sender, EventArgs e )
        {
            if ( comboBox1.Text == "0" )
            {
                MessageBox.Show( "不允许输入0,请重新输入" );
                comboBox1.Text = "";
            }
        }
        //新建
        private void add_one ( )
        {
            PQA1 = Convert.ToInt32( comboBox1.Text );
            if ( comboBox2.Text != "" )
                PQA2 = Convert.ToInt32( comboBox2.Text );
            if ( comboBox3.Text != "" )
                PQA3 = Convert.ToDecimal( comboBox3.Text );
            if ( comboBox4.Text != "" )
                PQA4 = Convert.ToInt32( comboBox4.Text );
            if ( comboBox5.Text != "" )
                PQA5 = Convert.ToInt32( comboBox5.Text );
            PQA6 = comboBox6.Text;
            PQA7 = comboBox7.Text;
            if ( comboBox8.Text != "" )
                PQA8 = Convert.ToDecimal( comboBox8.Text );
            if ( comboBox9.Text != "" )
                PQA9 = Convert.ToDecimal( comboBox9.Text );
            if ( comboBox10.Text != "" )
                PQA010 = Convert.ToInt32( comboBox10.Text );
            PQA011 = comboBox52.Text;
            PQA012 = comboBox59.Text;
        }
        private void build_one ( )
        {
            DataRow row = pqa . NewRow ( );
            row [ "PQA01" ] = PQA1;
            row [ "PQA02" ] = PQA2;
            row [ "PQA03" ] = PQA3;
            row [ "PQA04" ] = PQA4;
            row [ "PQA05" ] = PQA5;
            row [ "PQA06" ] = PQA6;
            row [ "PQA07" ] = PQA7;
            row [ "PQA08" ] = PQA8;
            row [ "PQA09" ] = PQA9;
            row [ "PQA10" ] = PQA010;
            row [ "PQA11" ] = PQA011;
            row [ "PQA12" ] = PQA012;
            pqa . Rows . Add ( row );
            pqa . DefaultView . Sort = "PQA01 asc";

            //every_one( );
        }
        private void every_one ( )
        {
            comboBox1.Items.Clear( );
            DataTable com1 = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQA01 FROM R_PQA" );
            if ( com1.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < com1.Rows.Count ; i++ )
                    comboBox1.Items.Add( com1.Rows[i]["PQA01"].ToString( ) );
            }
            DataTable com = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQA" );
            DataTable com2 = com.DefaultView.ToTable( true ,"PQA02" );
            if ( com2.Rows.Count > 0 )
            {
                comboBox2.DataSource = com2;
                comboBox2.DisplayMember = "PQA02";
            }
            DataTable com3 = com.DefaultView.ToTable( true ,"PQA03" );
            if ( com3.Rows.Count > 0 )
            {
                comboBox3.DataSource = com3;
                comboBox3.DisplayMember = "PQA03";
            }
            DataTable com4 = com.DefaultView.ToTable( true ,"PQA04" );
            if ( com4.Rows.Count > 0 )
            {
                comboBox4.DataSource = com4;
                comboBox4.DisplayMember = "PQA04";
            }
            DataTable com5 = com.DefaultView.ToTable( true ,"PQA05" );
            if ( com5.Rows.Count > 0 )
            {
                comboBox5.DataSource = com5;
                comboBox5.DisplayMember = "PQA05";
            }
            DataTable com6 = com.DefaultView.ToTable( true ,"PQA06" );
            if ( com6.Rows.Count > 0 )
            {
                comboBox6.DataSource = com6;
                comboBox6.DisplayMember = "PQA06";
            }
            DataTable com7 = com.DefaultView.ToTable( true ,"PQA07" );
            if ( com7.Rows.Count > 0 )
            {
                comboBox7.DataSource = com7;
                comboBox7.DisplayMember = "PQA07";
            }
            DataTable com8 = com.DefaultView.ToTable( true ,"PQA08" );
            if ( com8.Rows.Count > 0 )
            {
                comboBox8.DataSource = com8;
                comboBox8.DisplayMember = "PQA08";
            }
            DataTable com9 = com.DefaultView.ToTable( true ,"PQA09" );
            if ( com9.Rows.Count > 0 )
            {
                comboBox9.DataSource = com9;
                comboBox9.DisplayMember = "PQA09";
            }
            DataTable com10 = com.DefaultView.ToTable( true ,"PQA10" );
            if ( com10.Rows.Count > 0 )
            {
                comboBox10.DataSource = com10;
                comboBox10.DisplayMember = "PQA10";
            }
            DataTable com52 = com.DefaultView.ToTable( true ,"PQA11" );
            if ( com52.Rows.Count > 0 )
            {
                comboBox52.DataSource = com52;
                comboBox52.DisplayMember = "PQA11";
            }
            DataTable com59 = com.DefaultView.ToTable( true ,"PQA12" );
            if ( com59.Rows.Count > 0 )
            {
                comboBox59.DataSource = com59;
                comboBox59.DisplayMember = "PQA12";
            }
        }
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( comboBox1.Text == "" )
                MessageBox.Show( "" + label1.Text + "不可为空" );
            else
            {
                add_one( );

                if ( pqa.Rows.Count < 1 )
                {
                    int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQA (PQA01,PQA02,PQA03,PQA04,PQA05,PQA06,PQA07,PQA08,PQA09,PQA10,PQA11,PQA12) VALUES (@PQA01,@PQA02,@PQA03,@PQA04,@PQA05,@PQA06,@PQA07,@PQA08,@PQA09,@PQA10,@PQA11,@PQA12)" ,new SqlParameter( "@PQA01" ,PQA1 ) ,new SqlParameter( "@PQA02" ,PQA2 ) ,new SqlParameter( "@PQA03" ,PQA3 ) ,new SqlParameter( "@PQA04" ,PQA4 ) ,new SqlParameter( "@PQA05" ,PQA5 ) ,new SqlParameter( "@PQA06" ,PQA6 ) ,new SqlParameter( "@PQA07" ,PQA7 ) ,new SqlParameter( "@PQA08" ,PQA8 ) ,new SqlParameter( "@PQA09" ,PQA9 ) ,new SqlParameter( "@PQA10" ,PQA010 ) ,new SqlParameter( "@PQA11" ,PQA011 ) ,new SqlParameter( "@PQA12" ,PQA012 ) );
                    if ( count < 1 )
                        MessageBox.Show( "录入数据失败" );
                    else
                    {

                        MessageBox.Show( "成功录入数据" );
                        //pqa = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQA ORDER BY PQA01" );
                        //gridControl1.DataSource = pqa;

                        build_one( );
                    }
                }
                else
                {
                    DataTable dpq = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQA WHERE PQA01=@PQA01 AND PQA02=@PQA02 AND PQA03=@PQA03 AND PQA04=@PQA04 AND PQA05=@PQA05 AND PQA06=@PQA06 AND PQA07=@PQA07 AND PQA08=@PQA08 AND PQA09=@PQA09 AND PQA10=@PQA10 AND PQA11=@PQA11 AND PQA12=@PQA12" ,new SqlParameter( "@PQA01" ,PQA1 ) ,new SqlParameter( "@PQA02" ,PQA2 ) ,new SqlParameter( "@PQA03" ,PQA3 ) ,new SqlParameter( "@PQA04" ,PQA4 ) ,new SqlParameter( "@PQA05" ,PQA5 ) ,new SqlParameter( "@PQA06" ,PQA6 ) ,new SqlParameter( "@PQA07" ,PQA7 ) ,new SqlParameter( "@PQA08" ,PQA8 ) ,new SqlParameter( "@PQA09" ,PQA9 ) ,new SqlParameter( "@PQA10" ,PQA010 ) ,new SqlParameter( "@PQA11" ,PQA011 ) ,new SqlParameter( "@PQA12" ,PQA012 ) );
                    if ( dpq.Rows.Count >= 1 )
                        MessageBox.Show( "" + label1.Text + ":" + PQA1 + " \n\r" + label2.Text + ":" + PQA2 + " \n\r" + label3.Text + ":" + PQA3 + " \n\r" + label4.Text + ":" + PQA4 + " \n\r" + label5.Text + ":" + PQA5 + " \n\r" + label6.Text + ":" + PQA6 + " \n\r" + label7.Text + ":" + PQA7 + " \n\r" + label8.Text + ":" + PQA8 + " \n\r" + label9.Text + ":" + PQA9 + " \n\r" + label10.Text + ":" + PQA010 + " \n\r" + label52.Text + ":" + PQA011 + " \n\r" + label59.Text + ":" + comboBox59.Text + "\n\r的数据已经存在,请核实后再录入" );
                    else
                    {
                        int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQA (PQA01,PQA02,PQA03,PQA04,PQA05,PQA06,PQA07,PQA08,PQA09,PQA10,PQA11,PQA12) VALUES (@PQA01,@PQA02,@PQA03,@PQA04,@PQA05,@PQA06,@PQA07,@PQA08,@PQA09,@PQA10,@PQA11,@PQA12)" ,new SqlParameter( "@PQA01" ,PQA1 ) ,new SqlParameter( "@PQA02" ,PQA2 ) ,new SqlParameter( "@PQA03" ,PQA3 ) ,new SqlParameter( "@PQA04" ,PQA4 ) ,new SqlParameter( "@PQA05" ,PQA5 ) ,new SqlParameter( "@PQA06" ,PQA6 ) ,new SqlParameter( "@PQA07" ,PQA7 ) ,new SqlParameter( "@PQA08" ,PQA8 ) ,new SqlParameter( "@PQA09" ,PQA9 ) ,new SqlParameter( "@PQA10" ,PQA010 ) ,new SqlParameter( "@PQA11" ,PQA011 ) ,new SqlParameter( "@PQA12" ,PQA012 ) );
                        if ( count < 1 )
                            MessageBox.Show( "录入数据失败" );
                        else
                        {
                            MessageBox.Show( "成功录入数据" );

                            //pqa = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQA ORDER BY PQA01" );
                            //gridControl1.DataSource = pqa;

                            build_one( );
                        }
                    }
                }
            }
        }
        //编辑
        private void button2_Click( object sender, EventArgs e )
        {
            if (pqa.Rows.Count < 1)
                MessageBox.Show( "没有数据,无法编辑" );
            else
            {
                if (comboBox1.Text == "")
                    MessageBox.Show( "" + label1.Text + "不可为空" );
                else
                {
                    add_one( );

                    int num = gridView1.FocusedRowHandle;

                    DataTable dpq = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQA WHERE PQA01=@PQA01 AND PQA02=@PQA02 AND PQA03=@PQA03 AND PQA04=@PQA04 AND PQA05=@PQA05 AND PQA06=@PQA06 AND PQA07=@PQA07 AND PQA08=@PQA08 AND PQA09=@PQA09 AND PQA10=@PQA10 AND PQA11=@PQA11 AND PQA12=@PQA12", new SqlParameter( "@PQA01", PQA1 ), new SqlParameter( "@PQA02", PQA2 ), new SqlParameter( "@PQA03", PQA3 ), new SqlParameter( "@PQA04", PQA4 ), new SqlParameter( "@PQA05", PQA5 ), new SqlParameter( "@PQA06", PQA6 ), new SqlParameter( "@PQA07", PQA7 ), new SqlParameter( "@PQA08", PQA8 ), new SqlParameter( "@PQA09", PQA9 ), new SqlParameter( "@PQA10", PQA010 ), new SqlParameter( "@PQA11", PQA011 ), new SqlParameter( "@PQA12", PQA012 ) );
                    if ( dpq.Rows.Count >= 1 )
                        MessageBox.Show( "" + label1.Text + ":" + PQA1 + " \n\r" + label2.Text + ":" + PQA2 + " \n\r" + label3.Text + ":" + PQA3 + " \n\r" + label4.Text + ":" + PQA4 + " \n\r" + label5.Text + ":" + PQA5 + " \n\r" + label6.Text + ":" + PQA6 + " \n\r" + label7.Text + ":" + PQA7 + " \n\r" + label8.Text + ":" + PQA8 + " \n\r" + label9.Text + ":" + PQA9 + " \n\r" + label10.Text + ":" + PQA010 + " \n\r" + label52.Text + ":" + PQA011 + "\n\r" + label59.Text + ":" + comboBox59.Text + " \n\r的数据已经存在,请核实后再编辑" );
                    else
                    {
                        int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQA SET PQA01=@PQA01,PQA02=@PQA02,PQA03=@PQA03,PQA04=@PQA04,PQA05=@PQA05,PQA06=@PQA06,PQA07=@PQA07,PQA08=@PQA08,PQA09=@PQA09,PQA10=@PQA10,PQA11=@PQA11,PQA12=@PQA12 WHERE PQA01=@PQ01 AND PQA02=@PQ02 AND PQA03=@PQ03 AND PQA04=@PQ04 AND PQA05=@PQ05 AND PQA06=@PQ06 AND PQA07=@PQ07 AND PQA08=@PQ08 AND PQA09=@PQ09 AND PQA10=@PQ10 AND PQA11=@PQ11 AND PQA12=@PQ12" ,new SqlParameter( "@PQ01" ,com1 ) ,new SqlParameter( "@PQ02" ,com2 ) ,new SqlParameter( "@PQ03" ,com3 ) ,new SqlParameter( "@PQ04" ,com4 ) ,new SqlParameter( "@PQ05" ,com5 ) ,new SqlParameter( "@PQ06" ,com6 ) ,new SqlParameter( "@PQ07" ,com7 ) ,new SqlParameter( "@PQ08" ,com8 ) ,new SqlParameter( "@PQ09" ,com9 ) ,new SqlParameter( "@PQ10" ,com10 ) ,new SqlParameter( "@PQ11" ,com11 ) ,new SqlParameter( "@PQ12" ,com12 ) ,new SqlParameter( "@PQA01" ,PQA1 ) ,new SqlParameter( "@PQA02" ,PQA2 ) ,new SqlParameter( "@PQA03" ,PQA3 ) ,new SqlParameter( "@PQA04" ,PQA4 ) ,new SqlParameter( "@PQA05" ,PQA5 ) ,new SqlParameter( "@PQA06" ,PQA6 ) ,new SqlParameter( "@PQA07" ,PQA7 ) ,new SqlParameter( "@PQA08" ,PQA8 ) ,new SqlParameter( "@PQA09" ,PQA9 ) ,new SqlParameter( "@PQA10" ,PQA010 ) ,new SqlParameter( "@PQA11" ,PQA011 ) ,new SqlParameter( "@PQA12" ,PQA012 ) );
                        if ( count < 1 )
                            MessageBox.Show( "数据编辑失败" );
                        else
                        {
                            row = null;
                            row = pqa.Rows[num];
                            row.BeginEdit( );
                            row["PQA01"] = PQA1;
                            row["PQA02"] = PQA2;
                            row["PQA03"] = PQA3;
                            row["PQA04"] = PQA4;
                            row["PQA05"] = PQA5;
                            row["PQA06"] = PQA6;
                            row["PQA07"] = PQA7;
                            row["PQA08"] = PQA8;
                            row["PQA09"] = PQA9;
                            row["PQA10"] = PQA010;
                            row["PQA11"] = PQA011;
                            row["PQA12"] = PQA012;
                            row.EndEdit( );

                            //pqa = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQA ORDER BY PQA01" );
                            //gridControl1.DataSource = pqa;

                            MessageBox.Show( "编辑数据成功" );

                            every_one( );
                        }
                    }                  
                }
            }
        }
        //删除
        private void button3_Click( object sender, EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==

            DialogResult . Cancel )
                return;
            int num = gridView1.FocusedRowHandle;
            if (pqa.Rows.Count < 1)
                MessageBox.Show( "没有数据,无法删除" );
            else
            {
                if (comboBox1.Text == "")
                    MessageBox.Show( "" + label1.Text + "不可为空" );
                else
                {
                    add_one( );

                    DataTable dpq = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQA WHERE PQA01=@PQA01 AND PQA02=@PQA02 AND PQA03=@PQA03 AND PQA04=@PQA04 AND PQA05=@PQA05 AND PQA06=@PQA06 AND PQA07=@PQA07 AND PQA08=@PQA08 AND PQA09=@PQA09 AND PQA10=@PQA10 AND PQA11=@PQA11 AND PQA12=@PQA12", new SqlParameter( "@PQA01", PQA1 ), new SqlParameter( "@PQA02", PQA2 ), new SqlParameter( "@PQA03", PQA3 ), new SqlParameter( "@PQA04", PQA4 ), new SqlParameter( "@PQA05", PQA5 ), new SqlParameter( "@PQA06", PQA6 ), new SqlParameter( "@PQA07", PQA7 ), new SqlParameter( "@PQA08", PQA8 ), new SqlParameter( "@PQA09", PQA9 ), new SqlParameter( "@PQA10", PQA010 ), new SqlParameter( "@PQA11", PQA011 ), new SqlParameter( "@PQA12", PQA012 ) );
                    if ( dpq.Rows.Count >= 1 )
                    {
                        int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQA WHERE PQA01=@PQA01 AND PQA02=@PQA02 AND PQA03=@PQA03 AND PQA04=@PQA04 AND PQA05=@PQA05 AND PQA06=@PQA06 AND PQA07=@PQA07 AND PQA08=@PQA08 AND PQA09=@PQA09 AND PQA10=@PQA10 AND PQA11=@PQA11 AND PQA12=@PQA12" ,new SqlParameter( "@PQA01" ,PQA1 ) ,new SqlParameter( "@PQA02" ,PQA2 ) ,new SqlParameter( "@PQA03" ,PQA3 ) ,new SqlParameter( "@PQA04" ,PQA4 ) ,new SqlParameter( "@PQA05" ,PQA5 ) ,new SqlParameter( "@PQA06" ,PQA6 ) ,new SqlParameter( "@PQA07" ,PQA7 ) ,new SqlParameter( "@PQA08" ,PQA8 ) ,new SqlParameter( "@PQA09" ,PQA9 ) ,new SqlParameter( "@PQA10" ,PQA010 ) ,new SqlParameter( "@PQA11" ,PQA011 ) ,new SqlParameter( "@PQA12" ,PQA012 ) );
                        if ( count < 1 )
                            MessageBox.Show( "删除数据失败" );
                        else
                        {
                            MessageBox.Show( "成功删除数据" );

                            pqa.Rows.RemoveAt( num );
                            every_one( );
                        }
                    }
                    else
                        MessageBox.Show( "不存在 \n\r" + label1.Text + ":" + PQA1 + " \n\r" + label2.Text + ":" + PQA2 + " \n\r" + label3.Text + ":" + PQA3 + " \n\r" + label4.Text + ":" + PQA4 + " \n\r" + label5.Text + ":" + PQA5 + " \n\r" + label6.Text + ":" + PQA6 + " \n\r" + label7.Text + ":" + PQA7 + " \n\r" + label8.Text + ":" + PQA8 + " \n\r" + label9.Text + ":" + PQA9 + " \n\r" + label10.Text + ":" + PQA010 + " \n\r" + label52.Text + ":" + PQA011 + " \n\r" + label59.Text + ":" + comboBox59.Text + "\n\r的数据,请核实后再删除" );
                }
            }
        }
        //刷新
        private void button16_Click( object sender, EventArgs e )
        {
            pqa = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQA ORDER BY PQA01" );
            gridControl1.DataSource = pqa;
        }
        //批量新建
        private void button23_Click( object sender, EventArgs e )
        {
            if (gridView1.RowCount > 0)
            {
                btch.pl = "s1";
                btch.textBox1.Text = gridView1.GetFocusedRowCellValue( "PQA08" ).ToString( );
                btch.textBox2.Text = gridView1.GetFocusedRowCellValue( "PQA06" ).ToString( );
                btch.textBox3.Text = gridView1.GetFocusedRowCellValue( "PQA11" ).ToString( );
                btch.textBox4.Text = gridView1.GetFocusedRowCellValue( "PQA07" ).ToString( );
                btch.textBox5.Text = gridView1.GetFocusedRowCellValue( "PQA05" ).ToString( );
                btch.textBox6.Text = gridView1.GetFocusedRowCellValue( "PQA12" ).ToString( );
                btch.StartPosition = FormStartPosition.CenterScreen;
                btch.ShowDialog( );
            }
            else
                MessageBox.Show( "没有数据,无法批量新建" );
        }
        //批量编辑
        private void button22_Click( object sender, EventArgs e )
        {
            if (gridView1.RowCount > 0)
            {
                btch.pl = "s2";
                btch.textBox1.Text = gridView1.GetFocusedRowCellValue( "PQA08" ).ToString( );
                btch.textBox2.Text = gridView1.GetFocusedRowCellValue( "PQA06" ).ToString( );
                btch.textBox3.Text = gridView1.GetFocusedRowCellValue( "PQA11" ).ToString( );
                btch.textBox4.Text = gridView1.GetFocusedRowCellValue( "PQA07" ).ToString( );
                btch.textBox5.Text = gridView1.GetFocusedRowCellValue( "PQA05" ).ToString( );
                btch.textBox6.Text = gridView1.GetFocusedRowCellValue( "PQA12" ).ToString( );
                btch.StartPosition = FormStartPosition.CenterScreen;
                btch.ShowDialog( );
            }
            else
                MessageBox.Show( "没有数据,无法批量编辑" );
        }
        //批量删除
        private void button21_Click( object sender, EventArgs e )
        {
            if (gridView1.RowCount > 0)
            {
                btch.pl = "s3";
                btch.textBox1.Text = gridView1.GetFocusedRowCellValue( "PQA08" ).ToString( );
                btch.textBox2.Text = gridView1.GetFocusedRowCellValue( "PQA06" ).ToString( );
                btch.textBox3.Text = gridView1.GetFocusedRowCellValue( "PQA11" ).ToString( );
                btch.textBox4.Text = gridView1.GetFocusedRowCellValue( "PQA07" ).ToString( );
                btch.textBox5.Text = gridView1.GetFocusedRowCellValue( "PQA05" ).ToString( );
                btch.textBox6.Text = gridView1.GetFocusedRowCellValue( "PQA12" ).ToString( );
                btch.StartPosition = FormStartPosition.CenterScreen;
                btch.ShowDialog( );
            }
            else
                MessageBox.Show( "没有数据,无法批量删除" );
        }
        #endregion

        #region 静电
        int PQD1 = 0, PQD2 = 0, PQD4 = 0, PQD5 = 0, PQD010 = 0;
        string PQD6 = "", PQD7 = "", PQD011 = "",PQD012="";
        decimal PQD3 = 0M, PQD8 = 0M, PQD9 = 0M;
        private void gridView4_Click( object sender, EventArgs e )
        {
            if (gridView4.RowCount == 1)
                comboBox40.Text = gridView4.GetFocusedRowCellValue( "PQD01" ).ToString( );
        }
        string com40 = "", com39 = "", com38 = "", com37 = "", com36 = "", com35 = "", com34 = "", com33 = "", com32 = "", com31 = "", com53 = "", com58 = "";
        private void gridView4_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (e.FocusedRowHandle != -999997)
            {
                if (btch.plde == "1")
                {
                    comboBox40.Text = gridView4.GetRowCellValue( 0, "PQD01" ).ToString( );
                    comboBox39.Text = gridView4.GetRowCellValue( 0, "PQD02" ).ToString( );
                    comboBox38.Text = gridView4.GetRowCellValue( 0, "PQD03" ).ToString( );
                    comboBox37.Text = gridView4.GetRowCellValue( 0, "PQD04" ).ToString( );
                    comboBox36.Text = gridView4.GetRowCellValue( 0, "PQD05" ).ToString( );
                    comboBox35.Text = gridView4.GetRowCellValue( 0, "PQD06" ).ToString( );
                    comboBox34.Text = gridView4.GetRowCellValue( 0, "PQD07" ).ToString( );
                    comboBox33.Text = gridView4.GetRowCellValue( 0, "PQD08" ).ToString( );
                    comboBox32.Text = gridView4.GetRowCellValue( 0, "PQD09" ).ToString( );
                    comboBox31.Text = gridView4.GetRowCellValue( 0, "PQD10" ).ToString( );
                    comboBox53.Text = gridView4.GetRowCellValue( 0, "PQD11" ).ToString( );
                    comboBox58.Text = gridView4.GetRowCellValue( 0, "PQD12" ).ToString( );
                    btch.plde = "";
                }
                else
                {
                    comboBox40.Text = gridView4.GetRowCellValue( e.FocusedRowHandle, "PQD01" ).ToString( );
                    comboBox39.Text = gridView4.GetRowCellValue( e.FocusedRowHandle, "PQD02" ).ToString( );
                    comboBox38.Text = gridView4.GetRowCellValue( e.FocusedRowHandle, "PQD03" ).ToString( );
                    comboBox37.Text = gridView4.GetRowCellValue( e.FocusedRowHandle, "PQD04" ).ToString( );
                    comboBox36.Text = gridView4.GetRowCellValue( e.FocusedRowHandle, "PQD05" ).ToString( );
                    comboBox35.Text = gridView4.GetRowCellValue( e.FocusedRowHandle, "PQD06" ).ToString( );
                    comboBox34.Text = gridView4.GetRowCellValue( e.FocusedRowHandle, "PQD07" ).ToString( );
                    comboBox33.Text = gridView4.GetRowCellValue( e.FocusedRowHandle, "PQD08" ).ToString( );
                    comboBox32.Text = gridView4.GetRowCellValue( e.FocusedRowHandle, "PQD09" ).ToString( );
                    comboBox31.Text = gridView4.GetRowCellValue( e.FocusedRowHandle, "PQD10" ).ToString( );
                    comboBox53.Text = gridView4.GetRowCellValue( e.FocusedRowHandle, "PQD11" ).ToString( );
                    comboBox58.Text = gridView4.GetRowCellValue( e.FocusedRowHandle, "PQD12" ).ToString( );
                }
                com40 = comboBox40.Text;
                com39 = comboBox39.Text;
                com38 = comboBox38.Text;
                com37 = comboBox37.Text;
                com36 = comboBox36.Text;
                com35 = comboBox35.Text;
                com34 = comboBox34.Text;
                com33 = comboBox33.Text;
                com32 = comboBox32.Text;
                com31 = comboBox31.Text;
                com53 = comboBox53.Text;
                com58 = comboBox58.Text;
            }
        }
        private void gridView4_CustomDrawRowIndicator( object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e )
        {
            //foreach (DevExpress.XtraGrid.Columns.GridColumn item in gridView4.Columns)
            //{
            //    item.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;   //筛选条件设置为包含  
            //}
        }
        private void comboBox31_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void comboBox32_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox32 );
        }
        private void comboBox32_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox32 );
        }
        private void comboBox32_LostFocus( object sender, EventArgs e )
        {
            if (comboBox32.Text != "" && !DateDayRegise.fiveThreeNum( comboBox32 ))
            {
                this.comboBox32.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多三位,如99.999,请重新输入" );
            }

        }
        private void comboBox33_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox33 );
        }
        private void comboBox33_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox33 );
        }
        private void comboBox33_LostFocus( object sender, EventArgs e )
        {
            if (comboBox33.Text != "" && !DateDayRegise.foreOneNum( comboBox33 ))
            {
                this.comboBox33.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如999.9,请重新输入" );
            }
        }
        private void comboBox36_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void comboBox37_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void comboBox38_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox38 );
        }
        private void comboBox38_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox38 );
        }
        private void comboBox38_LostFocus( object sender, EventArgs e )
        {
            if (comboBox38.Text != "" && !DateDayRegise.foreTwoNum( comboBox38 ))
            {
                this.comboBox38.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多两位,如99.99,请重新输入" );
            }
        }
        private void comboBox39_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void comboBox40_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void comboBox40_SelectedValueChanged( object sender, EventArgs e )
        {
            string com = comboBox40.Text;
            DataTable com1 = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQD WHERE PQD01=@PQD01", new SqlParameter( "@PQD01", com ) );
            if (com1.Rows.Count > 0)
            {
                comboBox39.Text = com1.Rows[0]["PQD02"].ToString( );
                comboBox38.Text = com1.Rows[0]["PQD03"].ToString( );
                comboBox37.Text = com1.Rows[0]["PQD04"].ToString( );
                comboBox36.Text = com1.Rows[0]["PQD05"].ToString( );
                comboBox35.Text = com1.Rows[0]["PQD06"].ToString( );
                comboBox34.Text = com1.Rows[0]["PQD07"].ToString( );
                comboBox33.Text = com1.Rows[0]["PQD08"].ToString( );
                comboBox32.Text = com1.Rows[0]["PQD09"].ToString( );
                comboBox31.Text = com1.Rows[0]["PQD10"].ToString( );
                comboBox53.Text = com1.Rows[0]["PQD11"].ToString( );
            }
        }
        private void comboBox40_TextChanged( object sender, EventArgs e )
        {
            string com = comboBox40.Text;
            DataTable com1 = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQD WHERE PQD01=@PQD01", new SqlParameter( "@PQD01", com ) );
            if (com1.Rows.Count >0)
            {
                comboBox39.Text = com1.Rows[0]["PQD02"].ToString( );
                comboBox38.Text = com1.Rows[0]["PQD03"].ToString( );
                comboBox37.Text = com1.Rows[0]["PQD04"].ToString( );
                comboBox36.Text = com1.Rows[0]["PQD05"].ToString( );
                comboBox35.Text = com1.Rows[0]["PQD06"].ToString( );
                comboBox34.Text = com1.Rows[0]["PQD07"].ToString( );
                comboBox33.Text = com1.Rows[0]["PQD08"].ToString( );
                comboBox32.Text = com1.Rows[0]["PQD09"].ToString( );
                comboBox31.Text = com1.Rows[0]["PQD10"].ToString( );
                comboBox53.Text = com1.Rows[0]["PQD11"].ToString( );
            }
        }
        private void comboBox40_LostFocus( object sender, EventArgs e )
        {
            if (comboBox40.Text == "0")
            {
                MessageBox.Show( "不允许输入0,请重新输入" );
                comboBox40.Text = "";
            }
        }
        //新建
        private void add_two ( )
        {
            PQD1 = Convert.ToInt32( comboBox40.Text );
            if ( comboBox39.Text != "" )
            {
                PQD2 = Convert.ToInt32( comboBox39.Text );
            }
            if ( comboBox38.Text != "" )
            {
                PQD3 = Convert.ToDecimal( comboBox38.Text );
            }
            if ( comboBox37.Text != "" )
            {
                PQD4 = Convert.ToInt32( comboBox37.Text );
            }
            if ( comboBox36.Text != "" )
            {
                PQD5 = Convert.ToInt32( comboBox36.Text );
            }
            PQD6 = comboBox35.Text;
            PQD7 = comboBox34.Text;
            if ( comboBox33.Text != "" )
            {
                PQD8 = Convert.ToDecimal( comboBox33.Text );
            }
            if ( comboBox32.Text != "" )
            {
                PQD9 = Convert.ToDecimal( comboBox32.Text );
            }
            if ( comboBox31.Text != "" )
            {
                PQD010 = Convert.ToInt32( comboBox31.Text );
            }
            PQD011 = comboBox53.Text;
            PQD012 = comboBox58.Text;
        }
        private void build_two ( )
        {
            row = null;
            row = pqd.NewRow( );
            row["PQD01"] = PQD1;
            row["PQD02"] = PQD2;
            row["PQD03"] = PQD3;
            row["PQD04"] = PQD4;
            row["PQD05"] = PQD5;
            row["PQD06"] = PQD6;
            row["PQD07"] = PQD7;
            row["PQD08"] = PQD8;
            row["PQD09"] = PQD9;
            row["PQD10"] = PQD010;
            row["PQD11"] = PQD011;
            row["PQD12"] = PQD012;
            pqd.Rows.Add( row );
            pqd.DefaultView.Sort = "PQD01 asc";

            every_two( );
        }
        private void every_two ( )
        {
            comboBox40.Items.Clear( );
            DataTable com40 = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQD01 FROM R_PQD" );
            if ( com40.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < com40.Rows.Count ; i++ )
                {
                    comboBox40.Items.Add( com40.Rows[i]["PQD01"].ToString( ) );
                }
            }
            DataTable jin = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQD" );
            DataTable com39 = jin.DefaultView.ToTable( true ,"PQD02" );
            if ( com39.Rows.Count > 0 )
            {
                comboBox39.DataSource = com39;
                comboBox39.DisplayMember = "PQD02";
            }
            DataTable com38 = jin.DefaultView.ToTable( true ,"PQD03" );
            if ( com38.Rows.Count > 0 )
            {
                comboBox38.DataSource = com38;
                comboBox38.DisplayMember = "PQD03";
            }
            DataTable com37 = jin.DefaultView.ToTable( true ,"PQD04" );
            if ( com37.Rows.Count > 0 )
            {
                comboBox37.DataSource = com37;
                comboBox37.DisplayMember = "PQD04";
            }
            DataTable com36 = jin.DefaultView.ToTable( true ,"PQD05" );
            if ( com36.Rows.Count > 0 )
            {
                comboBox36.DataSource = com36;
                comboBox36.DisplayMember = "PQD05";
            }
            DataTable com35 = jin.DefaultView.ToTable( true ,"PQD06" );
            if ( com35.Rows.Count > 0 )
            {
                comboBox35.DataSource = com35;
                comboBox35.DisplayMember = "PQD06";
            }
            DataTable com34 = jin.DefaultView.ToTable( true ,"PQD07" );
            if ( com34.Rows.Count > 0 )
            {
                comboBox34.DataSource = com34;
                comboBox34.DisplayMember = "PQD07";
            }
            DataTable com33 = jin.DefaultView.ToTable( true ,"PQD08" );
            if ( com33.Rows.Count > 0 )
            {
                comboBox33.DataSource = com33;
                comboBox33.DisplayMember = "PQD08";
            }
            DataTable com32 = jin.DefaultView.ToTable( true ,"PQD09" );
            if ( com32.Rows.Count > 0 )
            {
                comboBox32.DataSource = com32;
                comboBox32.DisplayMember = "PQD09";
            }
            DataTable com31 = jin.DefaultView.ToTable( true ,"PQD10" );
            if ( com31.Rows.Count > 0 )
            {
                comboBox31.DataSource = com31;
                comboBox31.DisplayMember = "PQD10";
            }
            DataTable com53 = jin.DefaultView.ToTable( true ,"PQD11" );
            if ( com53.Rows.Count > 0 )
            {
                comboBox53.DataSource = com53;
                comboBox53.DisplayMember = "PQD11";
            }
            DataTable com58 = jin.DefaultView.ToTable( true ,"PQD12" );
            if ( com58.Rows.Count > 0 )
            {
                comboBox58.DataSource = com58;
                comboBox58.DisplayMember = "PQD12";
            }
        }
        private void button12_Click( object sender, EventArgs e )
        {
            if (comboBox40.Text == "")
                MessageBox.Show( "" + label40.Text + "不可为空" );
            else
            {
                add_two( );
                
                if (pqd.Rows.Count < 1)
                {
                    int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQD (PQD01,PQD02,PQD03,PQD04,PQD05,PQD06,PQD07,PQD08,PQD09,PQD10,PQD11,PQD12) VALUES (@PQD01,@PQD02,@PQD03,@PQD04,@PQD05,@PQD06,@PQD07,@PQD08,@PQD09,@PQD10,@PQD11,@PQD12)", new SqlParameter( "@PQD01", PQD1 ), new SqlParameter( "@PQD02", PQD2 ), new SqlParameter( "@PQD03", PQD3 ), new SqlParameter( "@PQD04", PQD4 ), new SqlParameter( "@PQD05", PQD5 ), new SqlParameter( "@PQD06", PQD6 ), new SqlParameter( "@PQD07", PQD7 ), new SqlParameter( "@PQD08", PQD8 ), new SqlParameter( "@PQD09", PQD9 ), new SqlParameter( "@PQD10", PQD010 ), new SqlParameter( "@PQD11", PQD011 ), new SqlParameter( "@PQD12", PQD012 ) );
                    if (count < 1)
                        MessageBox.Show( "数据录入失败" );
                    else
                    {                      
                        MessageBox.Show( "成功录入数据" );
                        build_two( );   
                    }
                }
                else
                {
                    DataTable dpq = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQD WHERE PQD01=@PQD01 AND PQD02=@PQD02 AND PQD03=@PQD03 AND PQD04=@PQD04 AND PQD05=@PQD05 AND PQD06=@PQD06 AND PQD07=@PQD07 AND PQD08=@PQD08 AND PQD09=@PQD09 AND PQD10=@PQD10 AND PQD11=@PQD11 AND PQD12=@PQD12", new SqlParameter( "@PQD01", PQD1 ), new SqlParameter( "@PQD02", PQD2 ), new SqlParameter( "@PQD03", PQD3 ), new SqlParameter( "@PQD04", PQD4 ), new SqlParameter( "@PQD05", PQD5 ), new SqlParameter( "@PQD06", PQD6 ), new SqlParameter( "@PQD07", PQD7 ), new SqlParameter( "@PQD08", PQD8 ), new SqlParameter( "@PQD09", PQD9 ), new SqlParameter( "@PQD10", PQD010 ), new SqlParameter( "@PQD11", PQD011 ), new SqlParameter( "@PQD12", PQD012 ) );
                    if (dpq.Rows.Count>=1)
                        MessageBox.Show( "" + label40.Text + ":" + PQD1 + " \n\r" + label39.Text + ":" + PQD2 + " \n\r" + label38.Text + ":" + PQD3 + " \n\r" + label37.Text + ":" + PQD4 + " \n\r" + label36.Text + ":" + PQD5 + " \n\r" + label35.Text + ":" + PQD6 + " \n\r" + label34.Text + ":" + PQD7 + " \n\r" + label33.Text + ":" + PQD8 + " \n\r" + label32.Text + ":" + PQD9 + " \n\r" + label31.Text + ":" + PQD010 + " \n\r" + label53.Text + ":" + PQD011 + " \n\r"+label58.Text+":"+comboBox58.Text+"\n\r 的数据已经存在,请核实后再录入" );
                    else
                    {
                        int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQD (PQD01,PQD02,PQD03,PQD04,PQD05,PQD06,PQD07,PQD08,PQD09,PQD10,PQD11,PQD12) VALUES (@PQD01,@PQD02,@PQD03,@PQD04,@PQD05,@PQD06,@PQD07,@PQD08,@PQD09,@PQD10,@PQD11,@PQD12)", new SqlParameter( "@PQD01", PQD1 ), new SqlParameter( "@PQD02", PQD2 ), new SqlParameter( "@PQD03", PQD3 ), new SqlParameter( "@PQD04", PQD4 ), new SqlParameter( "@PQD05", PQD5 ), new SqlParameter( "@PQD06", PQD6 ), new SqlParameter( "@PQD07", PQD7 ), new SqlParameter( "@PQD08", PQD8 ), new SqlParameter( "@PQD09", PQD9 ), new SqlParameter( "@PQD10", PQD010 ), new SqlParameter( "@PQD11", PQD011 ), new SqlParameter( "@PQD12", PQD012 ) );
                        if (count < 1)
                            MessageBox.Show( "数据录入失败" );
                        else
                        {
                            MessageBox.Show( "成功录入数据" );

                            build_two( );
                        }
                    }
                }
            }
        }
        //编辑
        private void button11_Click( object sender, EventArgs e )
        {
            if (pqd.Rows.Count < 1)
                MessageBox.Show( "没有数据,无法编辑" );
            else
            {
                if (comboBox40.Text == "")
                    MessageBox.Show( "" + label40.Text + "不可为空" );
                else
                {
                    add_two( );

                    int num = gridView4.FocusedRowHandle;
                    DataTable dpq = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQD WHERE PQD01=@PQD01 AND PQD02=@PQD02 AND PQD03=@PQD03 AND PQD04=@PQD04 AND PQD05=@PQD05 AND PQD06=@PQD06 AND PQD07=@PQD07 AND PQD08=@PQD08 AND PQD09=@PQD09 AND PQD10=@PQD10 AND PQD11=@PQD11 AND PQD12=@PQD12", new SqlParameter( "@PQD01", PQD1 ), new SqlParameter( "@PQD02", PQD2 ), new SqlParameter( "@PQD03", PQD3 ), new SqlParameter( "@PQD04", PQD4 ), new SqlParameter( "@PQD05", PQD5 ), new SqlParameter( "@PQD06", PQD6 ), new SqlParameter( "@PQD07", PQD7 ), new SqlParameter( "@PQD08", PQD8 ), new SqlParameter( "@PQD09", PQD9 ), new SqlParameter( "@PQD10", PQD010 ), new SqlParameter( "@PQD11", PQD011 ), new SqlParameter( "@PQD12", PQD012 ) );
                    if (dpq.Rows.Count>=1)
                        MessageBox.Show( "" + label40.Text + ":" + PQD1 + " \n\r" + label39.Text + ":" + PQD2 + " \n\r" + label38.Text + ":" + PQD3 + " \n\r" + label37.Text + ":" + PQD4 + " \n\r" + label36.Text + ":" + PQD5 + " \n\r" + label35.Text + ":" + PQD6 + " \n\r" + label34.Text + ":" + PQD7 + " \n\r" + label33.Text + ":" + PQD8 + " \n\r" + label32.Text + ":" + PQD9 + " \n\r" + label31.Text + ":" + PQD010 + " \n\r" + label53.Text + ":" + PQD011 + " \n\r"+label58.Text+":"+comboBox58.Text+"\n\r 的数据已经存在,请核实后再编辑" );
                    else
                    {
                        int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQD SET PQD01=@PQD01,PQD02=@PQD02,PQD03=@PQD03,PQD04=@PQD04,PQD05=@PQD05,PQD06=@PQD06,PQD07=@PQD07,PQD08=@PQD08,PQD09=@PQD09,PQD10=@PQD10,PQD11=@PQD11,PQD12=@PQD12 WHERE PQD01=@PQ1 AND PQD02=@PQ2 AND PQD03=@PQ3 AND PQD04=@PQ4 AND PQD05=@PQ5 AND PQD06=@PQ6 AND PQD07=@PQ7 AND PQD08=@PQ8 AND PQD09=@PQ9 AND PQD10=@PQ10 AND PQD11=@PQ11 AND PQD12=@PQ12", new SqlParameter( "@PQ1", com40 ), new SqlParameter( "@PQ2", com39 ), new SqlParameter( "@PQ3", com38 ), new SqlParameter( "@PQ4", com37 ), new SqlParameter( "@PQ5", com36 ), new SqlParameter( "@PQ6", com35 ), new SqlParameter( "@PQ7", com34 ), new SqlParameter( "@PQ8", com33 ), new SqlParameter( "@PQ9", com32 ), new SqlParameter( "@PQ10", com31 ), new SqlParameter( "@PQ11", com53 ), new SqlParameter( "@PQ12", com58 ), new SqlParameter( "@PQD01", PQD1 ), new SqlParameter( "@PQD02", PQD2 ), new SqlParameter( "@PQD03", PQD3 ), new SqlParameter( "@PQD04", PQD4 ), new SqlParameter( "@PQD05", PQD5 ), new SqlParameter( "@PQD06", PQD6 ), new SqlParameter( "@PQD07", PQD7 ), new SqlParameter( "@PQD08", PQD8 ), new SqlParameter( "@PQD09", PQD9 ), new SqlParameter( "@PQD10", PQD010 ), new SqlParameter( "@PQD11", PQD011 ), new SqlParameter( "@PQD12", PQD012 ) );
                        if (count < 1)
                        {
                            MessageBox.Show( "数据编辑失败" );
                        }
                        else
                        {                         
                            MessageBox.Show( "数据编辑成功" );

                            row = null;
                            row = pqd.Rows[num];
                            row.BeginEdit( );
                            row["PQD01"] = PQD1;
                            row["PQD02"] = PQD2;
                            row["PQD03"] = PQD3;
                            row["PQD04"] = PQD4;
                            row["PQD05"] = PQD5;
                            row["PQD06"] = PQD6;
                            row["PQD07"] = PQD7;
                            row["PQD08"] = PQD8;
                            row["PQD09"] = PQD9;
                            row["PQD10"] = PQD010;
                            row["PQD11"] = PQD011;
                            row["PQD12"] = PQD012;
                            row.EndEdit( );
                            DataTable pqdo = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQD ORDER BY PQD01" );
                            gridControl4.DataSource = pqdo;
                            every_two( );
                        }
                    }
                }
            }
        }
        //删除
        private void button10_Click( object sender, EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==

            DialogResult . Cancel )
                return;
            if (pqd.Rows.Count < 1)
                MessageBox.Show( "没有数据,无法删除" );
            else
            {
                if (comboBox40.Text == "")
                    MessageBox.Show( "" + label40.Text + "不可为空" );
                else
                {
                    build_two( );

                    DataTable dpq = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQD WHERE PQD01=@PQD01 AND PQD02=@PQD02 AND PQD03=@PQD03 AND PQD04=@PQD04 AND PQD05=@PQD05 AND PQD06=@PQD06 AND PQD07=@PQD07 AND PQD08=@PQD08 AND PQD09=@PQD09 AND PQD10=@PQD10 AND PQD11=@PQD11 AND PQD12=@PQD12", new SqlParameter( "@PQD01", PQD1 ), new SqlParameter( "@PQD02", PQD2 ), new SqlParameter( "@PQD03", PQD3 ), new SqlParameter( "@PQD04", PQD4 ), new SqlParameter( "@PQD05", PQD5 ), new SqlParameter( "@PQD06", PQD6 ), new SqlParameter( "@PQD07", PQD7 ), new SqlParameter( "@PQD08", PQD8 ), new SqlParameter( "@PQD09", PQD9 ), new SqlParameter( "@PQD10", PQD010 ), new SqlParameter( "@PQD11", PQD011 ), new SqlParameter( "@PQD12", PQD012 ) );
                    if (pqd.Rows.Count>=1)
                    {                  
                        int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQD WHERE PQD01=@PQD01 AND PQD02=@PQD02 AND PQD03=@PQD03 AND PQD04=@PQD04 AND PQD05=@PQD05 AND PQD06=@PQD06 AND PQD07=@PQD07 AND PQD08=@PQD08 AND PQD09=@PQD09 AND PQD10=@PQD10 AND PQD11=@PQD11 AND PQD12=@PQD12", new SqlParameter( "@PQD01", PQD1 ), new SqlParameter( "@PQD02", PQD2 ), new SqlParameter( "@PQD03", PQD3 ), new SqlParameter( "@PQD04", PQD4 ), new SqlParameter( "@PQD05", PQD5 ), new SqlParameter( "@PQD06", PQD6 ), new SqlParameter( "@PQD07", PQD7 ), new SqlParameter( "@PQD08", PQD8 ), new SqlParameter( "@PQD09", PQD9 ), new SqlParameter( "@PQD10", PQD010 ), new SqlParameter( "@PQD11", PQD011 ), new SqlParameter( "@PQD12", PQD012 ) );
                        if (count < 1)
                            MessageBox.Show( "删除数据失败" );
                        else
                        {
                            
                            MessageBox.Show( "成功删除数据" );
                            int num = gridView4.FocusedRowHandle;
                            pqd.Rows.RemoveAt( num );
                            every_two( );
                        }
                    }
                    else
                        MessageBox.Show( "不存在 \n\r" + label40.Text + ":" + PQD1 + " \n\r" + label39.Text + ":" + PQD2 + " \n\r" + label38.Text + ":" + PQD3 + " \n\r" + label37.Text + ":" + PQD4 + " \n\r" + label36.Text + ":" + PQD5 + " \n\r" + label35.Text + ":" + PQD6 + " \n\r" + label34.Text + ":" + PQD7 + " \n\r" + label33.Text + ":" + PQD8 + " \n\r" + label32.Text + ":" + PQD9 + " \n\r" + label31.Text + ":" + PQD010 + " \n\r" + label53.Text + ":" + PQD011 + " \n\r" + label58.Text + ":" + comboBox58.Text + "\n\r 的数据,请核实后再删除" );
                }
            }
        }
        //刷新
        private void button17_Click( object sender, EventArgs e )
        {
            pqd = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQD ORDER BY PQD01" );
            gridControl4.DataSource = pqd;
        }
        //批量新建
        private void button26_Click( object sender, EventArgs e )
        {
            if (gridView4.RowCount > 0)
            {
                btch.pl = "j1";
                btch.textBox1.Text = gridView4.GetFocusedRowCellValue( "PQD08" ).ToString( );
                btch.textBox2.Text = gridView4.GetFocusedRowCellValue( "PQD06" ).ToString( );
                btch.textBox3.Text = gridView4.GetFocusedRowCellValue( "PQD11" ).ToString( );
                btch.textBox4.Text = gridView4.GetFocusedRowCellValue( "PQD07" ).ToString( );
                btch.textBox5.Text = gridView4.GetFocusedRowCellValue( "PQD05" ).ToString( );
                btch.textBox6.Text = gridView4.GetFocusedRowCellValue( "PQD12" ).ToString( );
                btch.StartPosition = FormStartPosition.CenterScreen;
                btch.ShowDialog( );
            }
            else
            {
                MessageBox.Show( "没有数据,无法批量新建" );
            }
        }
        //批量编辑
        private void button25_Click( object sender, EventArgs e )
        {
            if (gridView4.RowCount > 0)
            {
                btch.pl = "j2";
                btch.textBox1.Text = gridView4.GetFocusedRowCellValue( "PQD08" ).ToString( );
                btch.textBox2.Text = gridView4.GetFocusedRowCellValue( "PQD06" ).ToString( );
                btch.textBox3.Text = gridView4.GetFocusedRowCellValue( "PQD11" ).ToString( );
                btch.textBox4.Text = gridView4.GetFocusedRowCellValue( "PQD07" ).ToString( );
                btch.textBox5.Text = gridView4.GetFocusedRowCellValue( "PQD05" ).ToString( );
                btch.textBox6.Text = gridView4.GetFocusedRowCellValue( "PQD12" ).ToString( );
                btch.StartPosition = FormStartPosition.CenterScreen;
                btch.ShowDialog( );
            }
            else
            {
                MessageBox.Show( "没有数据,无法批量编辑" );
            }
        }
        //批量删除
        private void button24_Click( object sender, EventArgs e )
        {
            if (gridView4.RowCount > 0)
            {
                btch.pl = "j3";
                btch.textBox1.Text = gridView4.GetFocusedRowCellValue( "PQD08" ).ToString( );
                btch.textBox2.Text = gridView4.GetFocusedRowCellValue( "PQD06" ).ToString( );
                btch.textBox3.Text = gridView4.GetFocusedRowCellValue( "PQD11" ).ToString( );
                btch.textBox4.Text = gridView4.GetFocusedRowCellValue( "PQD07" ).ToString( );
                btch.textBox5.Text = gridView4.GetFocusedRowCellValue( "PQD05" ).ToString( );
                btch.textBox6.Text = gridView4.GetFocusedRowCellValue( "PQD12" ).ToString( );
                btch.StartPosition = FormStartPosition.CenterScreen;
                btch.ShowDialog( );
            }
            else
                MessageBox.Show( "没有数据,无法批量删除" );
        }
        #endregion

        #region 浸漆
        int PQE1 = 0, PQE2 = 0, PQE5 = 0, PQE010 = 0;
        decimal PQE3 = 0M, PQE4 = 0M, PQE8 = 0M, PQE9 = 0M;
        string PQE6 = "", PQE7 = "", PQE011 = "", PQE012 = "";
        private void comboBox51_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void comboBox50_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void comboBox49_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox49 );
        }
        private void comboBox49_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox49 );
        }
        private void comboBox49_LostFocus( object sender, EventArgs e )
        {
            if (comboBox49.Text != "" && !DateDayRegise.foreTwoNum( comboBox49 ))
            {
                this.comboBox49.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多两位,如99.99, 请重新输入" );
            }
        }
        private void comboBox48_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox48 );
        }
        private void comboBox48_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox48 );
        }
        private void comboBox48_LostFocus( object sender, EventArgs e )
        {
            if (comboBox48.Text != "" && !DateDayRegise.fiveThreeNum( comboBox48 ))
            {
                this.comboBox48.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多三位,如99.999, 请重新输入" );
            }
        }
        private void comboBox47_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void comboBox44_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox44 );
        }
        private void comboBox44_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox44 );
        }
        private void comboBox44_LostFocus( object sender, EventArgs e )
        {
            if (comboBox44.Text != "" && !DateDayRegise.foreOneNum( comboBox44 ))
            {
                this.comboBox44.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如999.9, 请重新输入" );
            }
        }
        private void comboBox43_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox43 );
        }
        private void comboBox43_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox43 );
        }
        private void comboBox43_LostFocus( object sender, EventArgs e )
        {
            if (comboBox43.Text != "" && !DateDayRegise.fiveThreeNum( comboBox43 ))
            {
                this.comboBox43.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多三位,如99.999, 请重新输入" );
            }
        }
        private void comboBox42_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        string comb51 = "", comb50 = "", comb49 = "", comb48 = "", comb47 = "", comb46 = "", comb45 = "", comb44 = "", comb43 = "", comb42 = "", comb54 = "", comb23 = "";
        private void gridView5_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (e.FocusedRowHandle != -999997)
            {
                if (btch.plde == "1")
                {
                    comboBox51.Text = gridView5.GetRowCellValue( 0, "PQE01" ).ToString( );
                    comboBox50.Text = gridView5.GetRowCellValue( 0, "PQE02" ).ToString( );
                    comboBox49.Text = gridView5.GetRowCellValue( 0, "PQE03" ).ToString( );
                    comboBox48.Text = gridView5.GetRowCellValue( 0, "PQE04" ).ToString( );
                    comboBox47.Text = gridView5.GetRowCellValue( 0, "PQE05" ).ToString( );
                    comboBox46.Text = gridView5.GetRowCellValue( 0, "PQE06" ).ToString( );
                    comboBox45.Text = gridView5.GetRowCellValue( 0, "PQE07" ).ToString( );
                    comboBox44.Text = gridView5.GetRowCellValue( 0, "PQE08" ).ToString( );
                    comboBox43.Text = gridView5.GetRowCellValue( 0, "PQE09" ).ToString( );
                    comboBox42.Text = gridView5.GetRowCellValue( 0, "PQE10" ).ToString( );
                    comboBox54.Text = gridView5.GetRowCellValue( 0, "PQE11" ).ToString( );
                    comboBox23.Text = gridView5.GetRowCellValue( 0, "PQE12" ).ToString( );
                    btch.plde = "";
                }
                else
                {
                    comboBox51.Text = gridView5.GetRowCellValue( e.FocusedRowHandle, "PQE01" ).ToString( );
                    comboBox50.Text = gridView5.GetRowCellValue( e.FocusedRowHandle, "PQE02" ).ToString( );
                    comboBox49.Text = gridView5.GetRowCellValue( e.FocusedRowHandle, "PQE03" ).ToString( );
                    comboBox48.Text = gridView5.GetRowCellValue( e.FocusedRowHandle, "PQE04" ).ToString( );
                    comboBox47.Text = gridView5.GetRowCellValue( e.FocusedRowHandle, "PQE05" ).ToString( );
                    comboBox46.Text = gridView5.GetRowCellValue( e.FocusedRowHandle, "PQE06" ).ToString( );
                    comboBox45.Text = gridView5.GetRowCellValue( e.FocusedRowHandle, "PQE07" ).ToString( );
                    comboBox44.Text = gridView5.GetRowCellValue( e.FocusedRowHandle, "PQE08" ).ToString( );
                    comboBox43.Text = gridView5.GetRowCellValue( e.FocusedRowHandle, "PQE09" ).ToString( );
                    comboBox42.Text = gridView5.GetRowCellValue( e.FocusedRowHandle, "PQE10" ).ToString( );
                    comboBox54.Text = gridView5.GetRowCellValue( e.FocusedRowHandle, "PQE11" ).ToString( );
                    comboBox23.Text = gridView5.GetRowCellValue( e.FocusedRowHandle, "PQE12" ).ToString( );
                }              
                comb51 = comboBox51.Text;
                comb50 = comboBox50.Text;
                comb49 = comboBox49.Text;
                comb48 = comboBox48.Text;
                comb47 = comboBox47.Text;
                comb46 = comboBox46.Text;
                comb45 = comboBox45.Text;
                comb44 = comboBox44.Text;
                comb43 = comboBox43.Text;
                comb42 = comboBox42.Text;
                comb54 = comboBox54.Text;
                comb23 = comboBox23.Text;
            }
        }
        private void gridView5_CustomDrawRowIndicator( object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e )
        {
            //foreach (DevExpress.XtraGrid.Columns.GridColumn item in gridView5.Columns)
            //{
            //    item.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;   //筛选条件设置为包含  
            //}
        }
        private void gridView5_Click( object sender, EventArgs e )
        {
            if (gridView5.RowCount == 1)
                comboBox51.Text = gridView5.GetFocusedRowCellValue( "PQE01" ).ToString( );
        }
        private void comboBox51_SelectedValueChanged( object sender, EventArgs e )
        {
            string com51 = comboBox51.Text;
            DataTable com = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQE WHERE PQE01=@PQE01", new SqlParameter( "@PQE01", com51 ) );
            if ( com.Rows.Count > 0 )
            {
                comboBox50.Text = com.Rows[0]["PQE02"].ToString( );
                comboBox49.Text = com.Rows[0]["PQE03"].ToString( );
                comboBox48.Text = com.Rows[0]["PQE04"].ToString( );
                comboBox47.Text = com.Rows[0]["PQE05"].ToString( );
                comboBox46.Text = com.Rows[0]["PQE06"].ToString( );
                comboBox45.Text = com.Rows[0]["PQE07"].ToString( );
                comboBox44.Text = com.Rows[0]["PQE08"].ToString( );
                comboBox43.Text = com.Rows[0]["PQE09"].ToString( );
                comboBox42.Text = com.Rows[0]["PQE10"].ToString( );
                comboBox54.Text = com.Rows[0]["PQE11"].ToString( );
            }
        }
        private void comboBox51_TextChanged( object sender, EventArgs e )
        {
            string com51 = comboBox51.Text;
            DataTable com = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQE WHERE PQE01=@PQE01", new SqlParameter( "@PQE01", com51 ) );
            if (com.Rows.Count >0)
            {
                comboBox50.Text = com.Rows[0]["PQE02"].ToString( );
                comboBox49.Text = com.Rows[0]["PQE03"].ToString( );
                comboBox48.Text = com.Rows[0]["PQE04"].ToString( );
                comboBox47.Text = com.Rows[0]["PQE05"].ToString( );
                comboBox46.Text = com.Rows[0]["PQE06"].ToString( );
                comboBox45.Text = com.Rows[0]["PQE07"].ToString( );
                comboBox44.Text = com.Rows[0]["PQE08"].ToString( );
                comboBox43.Text = com.Rows[0]["PQE09"].ToString( );
                comboBox42.Text = com.Rows[0]["PQE10"].ToString( );
                comboBox54.Text = com.Rows[0]["PQE11"].ToString( );
            }
        }
        private void comboBox51_LostFocus( object sender, EventArgs e )
        {
            if (comboBox51.Text == "0")
            {
                MessageBox.Show( "不允许输入0,请重新输入" );
                comboBox51.Text = "";
            }
        }
        //删除
        private void add_thr ( )
        {
            PQE1 = Convert.ToInt32( comboBox51.Text );
            if ( comboBox50.Text != "" )
            {
                PQE2 = Convert.ToInt32( comboBox50.Text );
            }
            if ( comboBox49.Text != "" )
            {
                PQE3 = Convert.ToDecimal( comboBox49.Text );
            }
            if ( comboBox48.Text != "" )
            {
                PQE4 = Convert.ToDecimal( comboBox48.Text );
            }
            if ( comboBox47.Text != "" )
            {
                PQE5 = Convert.ToInt32( comboBox47.Text );
            }
            PQE6 = comboBox46.Text;
            PQE7 = comboBox45.Text;
            if ( comboBox44.Text != "" )
            {
                PQE8 = Convert.ToDecimal( comboBox44.Text );
            }
            if ( comboBox43.Text != "" )
            {
                PQE9 = Convert.ToDecimal( comboBox43.Text );
            }
            if ( comboBox42.Text != "" )
            {
                PQE010 = Convert.ToInt32( comboBox42.Text );
            }
            PQE011 = comboBox54.Text;
            PQE012 = comboBox23.Text;
        }
        private void every_thr ( )
        {
            comboBox51.Items.Clear( );
            DataTable com51 = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQE01 FROM R_PQE" );
            if ( com51.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < com51.Rows.Count ; i++ )
                {
                    comboBox51.Items.Add( com51.Rows[i]["PQE01"].ToString( ) );
                }
            }
            DataTable jq = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQE" );
            DataTable com50 = jq.DefaultView.ToTable( true ,"PQE02" );
            if ( com50.Rows.Count > 0 )
            {
                comboBox50.DataSource = com50;
                comboBox50.DisplayMember = "PQE02";
            }
            DataTable com49 = jq.DefaultView.ToTable( true ,"PQE03" );
            if ( com49.Rows.Count > 0 )
            {
                comboBox49.DataSource = com49;
                comboBox49.DisplayMember = "PQE03";
            }
            DataTable com48 = jq.DefaultView.ToTable( true ,"PQE04" );
            if ( com48.Rows.Count > 0 )
            {
                comboBox48.DataSource = com48;
                comboBox48.DisplayMember = "PQE04";
            }
            DataTable com47 = jq.DefaultView.ToTable( true ,"PQE05" );
            if ( com47.Rows.Count > 0 )
            {
                comboBox47.DataSource = com47;
                comboBox47.DisplayMember = "PQE05";
            }
            DataTable com46 = jq.DefaultView.ToTable( true ,"PQE06" );
            if ( com46.Rows.Count > 0 )
            {
                comboBox46.DataSource = com46;
                comboBox46.DisplayMember = "PQE06";
            }
            DataTable com45 = jq.DefaultView.ToTable( true ,"PQE07" );
            if ( com45.Rows.Count > 0 )
            {
                comboBox45.DataSource = com45;
                comboBox45.DisplayMember = "PQE07";
            }
            DataTable com44 = jq.DefaultView.ToTable( true ,"PQE08" );
            if ( com44.Rows.Count > 0 )
            {
                comboBox44.DataSource = com44;
                comboBox44.DisplayMember = "PQE08";
            }
            DataTable com43 = jq.DefaultView.ToTable( true ,"PQE09" );
            if ( com43.Rows.Count > 0 )
            {
                comboBox43.DataSource = com43;
                comboBox43.DisplayMember = "PQE09";
            }
            DataTable com42 = jq.DefaultView.ToTable( true ,"PQE10" );
            if ( com42.Rows.Count > 0 )
            {
                comboBox42.DataSource = com42;
                comboBox42.DisplayMember = "PQE10";
            }
            DataTable com54 = jq.DefaultView.ToTable( true ,"PQE11" );
            if ( com54.Rows.Count > 0 )
            {
                comboBox54.DataSource = com54;
                comboBox54.DisplayMember = "PQE11";
            }
            DataTable com23 = jq.DefaultView.ToTable( true ,"PQE12" );
            if ( com23.Rows.Count > 0 )
            {
                comboBox23.DataSource = com23;
                comboBox23.DisplayMember = "PQE12";
            }
        }
        private void build_thr ( )
        {
            
            DataRow row = pqe.NewRow( );
            row["PQE01"] = PQE1;
            row["PQE02"] = PQE2;
            row["PQE03"] = PQE3;
            row["PQE04"] = PQE4;
            row["PQE05"] = PQE5;
            row["PQE06"] = PQE6;
            row["PQE07"] = PQE7;
            row["PQE08"] = PQE8;
            row["PQE09"] = PQE9;
            row["PQE10"] = PQE010;
            row["PQE11"] = PQE011;
            row["PQE12"] = PQE012;
            pqe.Rows.Add( row );
            pqe.DefaultView.Sort = "PQE01 asc";

            every_thr( );
        }
        private void button13_Click( object sender, EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==

            DialogResult . Cancel )
                return;
            if (pqe.Rows.Count < 1)
                MessageBox.Show( "没有数据,无法删除" );
            else
            {
                int num = gridView5.FocusedRowHandle;
                if (comboBox51.Text == "")
                    MessageBox.Show( "" + label51.Text + "不可为空" );
                else
                {
                    add_thr( );
                    DataTable dpq = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQE WHERE PQE01=@PQE01 AND PQE02=@PQE02 AND PQE03=@PQE03 AND PQE04=@PQE04 AND PQE05=@PQE05 AND PQE06=@PQE06 AND PQE07=@PQE07 AND PQE08=@PQE08 AND PQE09=@PQE09 AND PQE10=@PQE10 AND PQE11=@PQE11 AND PQE12=@PQE12", new SqlParameter( "@PQE01", PQE1 ), new SqlParameter( "@PQE02", PQE2 ), new SqlParameter( "@PQE03", PQE3 ), new SqlParameter( "@PQE04", PQE4 ), new SqlParameter( "@PQE05", PQE5 ), new SqlParameter( "@PQE06", PQE6 ), new SqlParameter( "@PQE07", PQE7 ), new SqlParameter( "@PQE08", PQE8 ), new SqlParameter( "@PQE09", PQE9 ), new SqlParameter( "@PQE10", PQE010 ), new SqlParameter( "@PQE11", PQE011 ), new SqlParameter( "@PQE12", PQE012 ) );

                    if (dpq.Rows.Count >= 1)
                    {
                        int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQE WHERE PQE01=@PQE01 AND PQE02=@PQE02 AND PQE03=@PQE03 AND PQE04=@PQE04 AND PQE05=@PQE05 AND PQE06=@PQE06 AND PQE07=@PQE07 AND PQE08=@PQE08 AND PQE09=@PQE09 AND PQE10=@PQE10 AND PQE11=@PQE11 AND PQE12=@PQE12", new SqlParameter( "@PQE01", PQE1 ), new SqlParameter( "@PQE02", PQE2 ), new SqlParameter( "@PQE03", PQE3 ), new SqlParameter( "@PQE04", PQE4 ), new SqlParameter( "@PQE05", PQE5 ), new SqlParameter( "@PQE06", PQE6 ), new SqlParameter( "@PQE07", PQE7 ), new SqlParameter( "@PQE08", PQE8 ), new SqlParameter( "@PQE09", PQE9 ), new SqlParameter( "@PQE10", PQE010 ), new SqlParameter( "@PQE11", PQE011 ), new SqlParameter( "@PQE12", PQE012 ) );
                        if (count < 1)
                            MessageBox.Show( "删除数据失败" );
                        else
                        {                         
                            MessageBox.Show( "成功删除数据" );
                            pqe.Rows.RemoveAt( num );

                            every_thr( );
                        }
                    }
                    else
                        MessageBox.Show( "不存在 \n\r" + label51.Text + ":" + PQE1 + " \n\r" + label50.Text + ":" + PQE2 + " \n\r" + label49.Text + ":" + PQE3 + " \n\r" + label48.Text + ":" + PQE4 + " \n\r" + label47.Text + ":" + PQE5 + " \n\r" + label46.Text + ":" + PQE6 + " \n\r" + label45.Text + ":" + PQE7 + " \n\r" + label44.Text + ":" + PQE8 + " \n\r" + label43.Text + ":" + PQE9 + " \n\r" + label42.Text + ":" + PQE010 + " \n\r" + label54.Text + ":" + PQE011 + " \n\r"+label23.Text+":"+comboBox23.Text+"\n\r 的数据,请核实后再删除" );
                }
            }
        }
        //编辑
        private void button14_Click( object sender, EventArgs e )
        {
            if (pqe.Rows.Count < 1)
                MessageBox.Show( "没有数据,无法变价" );
            else
            {
                if (comboBox51.Text == "")
                    MessageBox.Show( "" + label51.Text + "不可为空" );
                else
                {
                    add_thr( );

                    DataTable dpq = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQE WHERE PQE01=@PQE01 AND PQE02=@PQE02 AND PQE03=@PQE03 AND PQE04=@PQE04 AND PQE05=@PQE05 AND PQE06=@PQE06 AND PQE07=@PQE07 AND PQE08=@PQE08 AND PQE09=@PQE09 AND PQE10=@PQE10 AND PQE11=@PQE11 AND PQE12=@PQE12", new SqlParameter( "@PQE01", PQE1 ), new SqlParameter( "@PQE02", PQE2 ), new SqlParameter( "@PQE03", PQE3 ), new SqlParameter( "@PQE04", PQE4 ), new SqlParameter( "@PQE05", PQE5 ), new SqlParameter( "@PQE06", PQE6 ), new SqlParameter( "@PQE07", PQE7 ), new SqlParameter( "@PQE08", PQE8 ), new SqlParameter( "@PQE09", PQE9 ), new SqlParameter( "@PQE10", PQE010 ), new SqlParameter( "@PQE11", PQE011 ) ,new SqlParameter("@PQE12",PQE012));

                    if (dpq.Rows.Count >= 1)
                        MessageBox.Show( "" + label51.Text + ":" + PQE1 + " \n\r" + label50.Text + ":" + PQE2 + " \n\r" + label49.Text + ":" + PQE3 + " \n\r" + label48.Text + ":" + PQE4 + " \n\r" + label47.Text + ":" + PQE5 + " \n\r" + label46.Text + ":" + PQE6 + " \n\r" + label45.Text + ":" + PQE7 + " \n\r" + label44.Text + ":" + PQE8 + " \n\r" + label43.Text + ":" + PQE9 + " \n\r" + label42.Text + ":" + PQE010 + " \n\r" + label54.Text + ":" + PQE011 + " \n\r"+label23.Text+":"+comboBox23.Text+"\n\r 的数据已经存在,请核实后再编辑" );
                    else
                    {
                        int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQE SET PQE01=@PQE01,PQE02=@PQE02,PQE03=@PQE03,PQE04=@PQE04,PQE05=@PQE05,PQE06=@PQE06,PQE07=@PQE07,PQE08=@PQE08,PQE09=@PQE09,PQE10=@PQE10,PQE11=@PQE11, PQE12=@PQE12 WHERE PQE01=@PQ1 AND PQE02=@PQ2 AND PQE03=@PQ3 AND PQE04=@PQ4 AND PQE05=@PQ5 AND PQE06=@PQ6 AND PQE07=@PQ7 AND PQE08=@PQ8 AND PQE09=@PQ9 AND PQE10=@PQ10 AND PQE11=@PQ11 AND PQE12=@PQ12", new SqlParameter( "@PQ1", comb51 ), new SqlParameter( "@PQ2", comb50 ), new SqlParameter( "@PQ3", comb49 ), new SqlParameter( "@PQ4", comb48 ), new SqlParameter( "@PQ5", comb47 ), new SqlParameter( "@PQ6", comb46 ), new SqlParameter( "@PQ7", comb45 ), new SqlParameter( "@PQ8", comb44 ), new SqlParameter( "@PQ9", comb43 ), new SqlParameter( "@PQ10", comb42 ), new SqlParameter( "@PQ11", comb54 ), new SqlParameter( "@PQ12", comb23 ), new SqlParameter( "@PQE01", PQE1 ), new SqlParameter( "@PQE02", PQE2 ), new SqlParameter( "@PQE03", PQE3 ), new SqlParameter( "@PQE04", PQE4 ), new SqlParameter( "@PQE05", PQE5 ), new SqlParameter( "@PQE06", PQE6 ), new SqlParameter( "@PQE07", PQE7 ), new SqlParameter( "@PQE08", PQE8 ), new SqlParameter( "@PQE09", PQE9 ), new SqlParameter( "@PQE10", PQE010 ), new SqlParameter( "@PQE11", PQE011 ), new SqlParameter( "@PQE12", PQE012 ) );
                        if (count < 1)
                            MessageBox.Show( "数据编辑失败" );
                        else
                        {
                            
                            MessageBox.Show( "数据编辑成功" );
                            int num = gridView5.FocusedRowHandle;
                            DataRow row = pqe.Rows[num];
                            row.BeginEdit( );
                            row["PQE01"] = PQE1;
                            row["PQE02"] = PQE2;
                            row["PQE03"] = PQE3;
                            row["PQE04"] = PQE4;
                            row["PQE05"] = PQE5;
                            row["PQE06"] = PQE6;
                            row["PQE07"] = PQE7;
                            row["PQE08"] = PQE8;
                            row["PQE09"] = PQE9;
                            row["PQE10"] = PQE010;
                            row["PQE11"] = PQE011;
                            row["PQE12"] = PQE012;
                            row.EndEdit( );
                            DataTable pqeo = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQE ORDER BY PQE01" );
                            gridControl5.DataSource = pqeo;
                            every_thr( );
                        }
                    }
                }
            }
        }
        //新建
        private void button15_Click( object sender, EventArgs e )
        {
            if (comboBox51.Text == "")
                MessageBox.Show( "" + label51.Text + "不可为空" );
            else
            {
                add_thr( );

                if ( pqe.Rows.Count < 1 )
                {
                    int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQE (PQE01,PQE02,PQE03,PQE04,PQE05,PQE06,PQE07,PQE08,PQE09,PQE10,PQE11,PQE12) VALUES (@PQE01,@PQE02,@PQE03,@PQE04,@PQE05,@PQE06,@PQE07,@PQE08,@PQE09,@PQE10,@PQE11,@PQE12)" ,new SqlParameter( "@PQE01" ,PQE1 ) ,new SqlParameter( "@PQE02" ,PQE2 ) ,new SqlParameter( "@PQE03" ,PQE3 ) ,new SqlParameter( "@PQE04" ,PQE4 ) ,new SqlParameter( "@PQE05" ,PQE5 ) ,new SqlParameter( "@PQE06" ,PQE6 ) ,new SqlParameter( "@PQE07" ,PQE7 ) ,new SqlParameter( "@PQE08" ,PQE8 ) ,new SqlParameter( "@PQE09" ,PQE9 ) ,new SqlParameter( "@PQE10" ,PQE010 ) ,new SqlParameter( "@PQE11" ,PQE011 ) ,new SqlParameter( "@PQE12" ,PQE012 ) );
                    if ( count < 1 )
                        MessageBox.Show( "录入数据失败" );
                    else
                    {
                        MessageBox.Show( "成功录入数据" );

                        build_thr( );
                    }
                }
                else
                {
                    DataTable dpq = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQE WHERE PQE01=@PQE01 AND PQE02=@PQE02 AND PQE03=@PQE03 AND PQE04=@PQE04 AND PQE05=@PQE05 AND PQE06=@PQE06 AND PQE07=@PQE07 AND PQE08=@PQE08 AND PQE09=@PQE09 AND PQE10=@PQE10 AND PQE11=@PQE11 AND PQE12=@PQE12" ,new SqlParameter( "@PQE01" ,PQE1 ) ,new SqlParameter( "@PQE02" ,PQE2 ) ,new SqlParameter( "@PQE03" ,PQE3 ) ,new SqlParameter( "@PQE04" ,PQE4 ) ,new SqlParameter( "@PQE05" ,PQE5 ) ,new SqlParameter( "@PQE06" ,PQE6 ) ,new SqlParameter( "@PQE07" ,PQE7 ) ,new SqlParameter( "@PQE08" ,PQE8 ) ,new SqlParameter( "@PQE09" ,PQE9 ) ,new SqlParameter( "@PQE10" ,PQE010 ) ,new SqlParameter( "@PQE11" ,PQE011 ) ,new SqlParameter( "@PQE12" ,PQE012 ) );

                    if ( dpq.Rows.Count >= 1 )
                        MessageBox.Show( "" + label51.Text + ":" + PQE1 + " \n\r" + label50.Text + ":" + PQE2 + " \n\r" + label49.Text + ":" + PQE3 + " \n\r" + label48.Text + ":" + PQE4 + " \n\r" + label47.Text + ":" + PQE5 + " \n\r" + label46.Text + ":" + PQE6 + " \n\r" + label45.Text + ":" + PQE7 + " \n\r" + label44.Text + ":" + PQE8 + " \n\r" + label43.Text + ":" + PQE9 + " \n\r" + label42.Text + ":" + PQE010 + " \n\r" + label54.Text + ":" + PQE011 + " \n\r" + label23.Text + ":" + comboBox23.Text + "\n\r 的数据已经存在,请核实后再录入" );
                    else
                    {
                        int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQE (PQE01,PQE02,PQE03,PQE04,PQE05,PQE06,PQE07,PQE08,PQE09,PQE10,PQE11,PQE12) VALUES (@PQE01,@PQE02,@PQE03,@PQE04,@PQE05,@PQE06,@PQE07,@PQE08,@PQE09,@PQE10,@PQE11,@PQE12)" ,new SqlParameter( "@PQE01" ,PQE1 ) ,new SqlParameter( "@PQE02" ,PQE2 ) ,new SqlParameter( "@PQE03" ,PQE3 ) ,new SqlParameter( "@PQE04" ,PQE4 ) ,new SqlParameter( "@PQE05" ,PQE5 ) ,new SqlParameter( "@PQE06" ,PQE6 ) ,new SqlParameter( "@PQE07" ,PQE7 ) ,new SqlParameter( "@PQE08" ,PQE8 ) ,new SqlParameter( "@PQE09" ,PQE9 ) ,new SqlParameter( "@PQE10" ,PQE010 ) ,new SqlParameter( "@PQE11" ,PQE011 ) ,new SqlParameter( "@PQE12" ,PQE012 ) );
                        if ( count < 1 )
                            MessageBox.Show( "录入数据失败" );
                        else
                        {
                            MessageBox.Show( "成功录入数据" );
                            build_thr( );
                        }
                    }
                }
            }
        }
        //刷新
        private void button18_Click( object sender, EventArgs e )
        {
            pqe = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQE ORDER BY PQE01" );
            gridControl5.DataSource = pqe;
        }
        //批量新建
        private void button29_Click( object sender, EventArgs e )
        {
            if (gridView5.RowCount > 0)
            {
                btch.pl = "q1";
                btch.textBox1.Text = gridView5.GetFocusedRowCellValue( "PQE08" ).ToString( );
                btch.textBox2.Text = gridView5.GetFocusedRowCellValue( "PQE06" ).ToString( );
                btch.textBox3.Text = gridView5.GetFocusedRowCellValue( "PQE11" ).ToString( );
                btch.textBox4.Text = gridView5.GetFocusedRowCellValue( "PQE07" ).ToString( );
                btch.textBox5.Text = gridView5.GetFocusedRowCellValue( "PQE05" ).ToString( );
                btch.textBox6.Text = gridView5.GetFocusedRowCellValue( "PQE12" ).ToString( );
                btch.StartPosition = FormStartPosition.CenterScreen;
                btch.ShowDialog( );
            }
            else
                MessageBox.Show( "没有数据,无法批量新建" );
        }
        //批量编辑
        private void button28_Click( object sender, EventArgs e )
        {
            if (gridView5.RowCount > 0)
            {
                btch.pl = "q2";
                btch.textBox1.Text = gridView5.GetFocusedRowCellValue( "PQE08" ).ToString( );
                btch.textBox2.Text = gridView5.GetFocusedRowCellValue( "PQE06" ).ToString( );
                btch.textBox3.Text = gridView5.GetFocusedRowCellValue( "PQE11" ).ToString( );
                btch.textBox4.Text = gridView5.GetFocusedRowCellValue( "PQE07" ).ToString( );
                btch.textBox5.Text = gridView5.GetFocusedRowCellValue( "PQE05" ).ToString( );
                btch.textBox6.Text = gridView5.GetFocusedRowCellValue( "PQE12" ).ToString( );
                btch.StartPosition = FormStartPosition.CenterScreen;
                btch.ShowDialog( );
            }
            else
                MessageBox.Show( "没有数据,无法批量编辑" );
        }
        //批量删除
        private void button27_Click( object sender, EventArgs e )
        {
            if (gridView5.RowCount > 0)
            {
                btch.pl = "q3";
                btch.textBox1.Text = gridView5.GetFocusedRowCellValue( "PQE08" ).ToString( );
                btch.textBox2.Text = gridView5.GetFocusedRowCellValue( "PQE06" ).ToString( );
                btch.textBox3.Text = gridView5.GetFocusedRowCellValue( "PQE11" ).ToString( );
                btch.textBox4.Text = gridView5.GetFocusedRowCellValue( "PQE07" ).ToString( );
                btch.textBox5.Text = gridView5.GetFocusedRowCellValue( "PQE05" ).ToString( );
                btch.textBox6.Text = gridView5.GetFocusedRowCellValue( "PQE12" ).ToString( );
                btch.StartPosition = FormStartPosition.CenterScreen;
                btch.ShowDialog( );
            }
            else
                MessageBox.Show( "没有数据,无法批量删除" );
        }
        #endregion

        #region 封边
        int PQB4 = 0;
        decimal PQB1 = 0M, PQB3 = 0M, PQB8 = 0M, PQB9 = 0M, PQB011 = 0M;
        string PQB5 = "", PQB6 = "", PQB010 = "", PQB012 = "";
        private void comboBox20_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox20 );
        }
        private void comboBox20_TextChanged( object sender, EventArgs e )
        {
            ////若只有一位 第一位不能是.
            //if (comboBox20.Text.Length == 1 && comboBox20.Text.Substring( 0, 1 ) != "." && comboBox20.Text.Substring( 0, 1 ) != "0")
            //{
            //    string com20 = comboBox20.Text;
            //    DataTable com = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQB WHERE PQB01=@PQB01", new SqlParameter( "@PQB01", com20 ) );
            //    if (com.Rows.Count > 0)
            //    {
            //        comboBox19.Text = com.Rows[0]["PQB02"].ToString( );
            //        comboBox18.Text = com.Rows[0]["PQB03"].ToString( );
            //        comboBox16.Text = com.Rows[0]["PQB04"].ToString( );
            //        comboBox15.Text = com.Rows[0]["PQB05"].ToString( );
            //        comboBox14.Text = com.Rows[0]["PQB06"].ToString( );
            //        comboBox13.Text = com.Rows[0]["PQB07"].ToString( );
            //        comboBox12.Text = com.Rows[0]["PQB08"].ToString( );
            //        comboBox11.Text = com.Rows[0]["PQB09"].ToString( );
            //    }
            //}
            //else if (comboBox20.Text.Length == 1 && (comboBox20.Text.Substring( 0, 1 ) == "." || comboBox20.Text.Substring( 0, 1 ) == "0"))
            //{
            //    comboBox20.Text = "0.";
            //}
            //else if (comboBox20.Text.Length == 2 && comboBox20.Text.Substring( 0, 1 ) != "." && comboBox20.Text.Substring( 1, 1 ) != "." && comboBox20.Text.Substring( 0, 1 ) != "0")
            //{
            //    string com20 = comboBox20.Text;
            //    DataTable com = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQB WHERE PQB01=@PQB01", new SqlParameter( "@PQB01", com20 ) );
            //    if (com.Rows.Count > 0)
            //    {
            //        comboBox19.Text = com.Rows[0]["PQB02"].ToString( );
            //        comboBox18.Text = com.Rows[0]["PQB03"].ToString( );
            //        comboBox16.Text = com.Rows[0]["PQB04"].ToString( );
            //        comboBox15.Text = com.Rows[0]["PQB05"].ToString( );
            //        comboBox14.Text = com.Rows[0]["PQB06"].ToString( );
            //        comboBox13.Text = com.Rows[0]["PQB07"].ToString( );
            //        comboBox12.Text = com.Rows[0]["PQB08"].ToString( );
            //        comboBox11.Text = com.Rows[0]["PQB09"].ToString( );
            //    }
            //}
            //else if (comboBox20.Text.Length == 2 && comboBox20.Text.Substring( 0, 1 ) != "." && comboBox20.Text.Substring( 1, 1 ) == ".")
            //{
            //    if (comboBox20.Text.Length == 3 && comboBox20.Text.Substring( 1, 1 ) == "." && comboBox20.Text.Substring( 2, 1 ) != "." && comboBox20.Text.Substring( 1, 1 ) != "0")
            //    {
            //        string com20 = comboBox20.Text;
            //        DataTable com = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQB WHERE PQB01=@PQB01", new SqlParameter( "@PQB01", com20 ) );
            //        if (com.Rows.Count > 0)
            //        {
            //            comboBox19.Text = com.Rows[0]["PQB02"].ToString( );
            //            comboBox18.Text = com.Rows[0]["PQB03"].ToString( );
            //            comboBox16.Text = com.Rows[0]["PQB04"].ToString( );
            //            comboBox15.Text = com.Rows[0]["PQB05"].ToString( );
            //            comboBox14.Text = com.Rows[0]["PQB06"].ToString( );
            //            comboBox13.Text = com.Rows[0]["PQB07"].ToString( );
            //            comboBox12.Text = com.Rows[0]["PQB08"].ToString( );
            //            comboBox11.Text = com.Rows[0]["PQB09"].ToString( );
            //        }
            //    }
            //    else if (comboBox20.Text.Length == 3 && comboBox20.Text.Substring( 1, 1 ) == "." && comboBox20.Text.Substring( 2, 1 ) != "." && comboBox20.Text.Substring( 1, 1 ) == "0")
            //    {
            //        comboBox20.Text = "";
            //    }
            //    else if (comboBox20.Text.Length == 3 && comboBox20.Text.Substring( 1, 1 ) != "." && comboBox20.Text.Substring( 2, 1 ) == ".")
            //    {
            //        if (comboBox20.Text.Length == 4 && comboBox20.Text.Substring( 1, 1 ) != "." && comboBox20.Text.Substring( 2, 1 ) == "." && comboBox20.Text.Substring( 3, 1 ) != ".")
            //        {
            //            string com20 = comboBox20.Text;
            //            DataTable com = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQB WHERE PQB01=@PQB01", new SqlParameter( "@PQB01", com20 ) );
            //            if (com.Rows.Count > 0)
            //            {
            //                comboBox19.Text = com.Rows[0]["PQB02"].ToString( );
            //                comboBox18.Text = com.Rows[0]["PQB03"].ToString( );
            //                comboBox16.Text = com.Rows[0]["PQB04"].ToString( );
            //                comboBox15.Text = com.Rows[0]["PQB05"].ToString( );
            //                comboBox14.Text = com.Rows[0]["PQB06"].ToString( );
            //                comboBox13.Text = com.Rows[0]["PQB07"].ToString( );
            //                comboBox12.Text = com.Rows[0]["PQB08"].ToString( );
            //                comboBox11.Text = com.Rows[0]["PQB09"].ToString( );
            //            }
            //        }
            //    }               
            //}
            //else
            //{
            //    MessageBox.Show( "只允许最多输入两位整数,一位小数,一个小数点,如99.9" );
            //    comboBox20.Text = "";
            //}
        }
        private void comboBox20_SelectedValueChanged( object sender, EventArgs e )
        {
            string com20 = comboBox20.Text;
            DataTable com = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQB WHERE PQB01=@PQB01", new SqlParameter( "@PQB01", com20 ) );
            if (com.Rows.Count > 0)
            {
                comboBox18.Text = com.Rows[0]["PQB03"].ToString( );
                comboBox16.Text = com.Rows[0]["PQB04"].ToString( );
                comboBox15.Text = com.Rows[0]["PQB05"].ToString( );
                comboBox14.Text = com.Rows[0]["PQB06"].ToString( );
                comboBox19.Text = com.Rows[0]["PQB11"].ToString( );
                comboBox12.Text = com.Rows[0]["PQB08"].ToString( );
                comboBox11.Text = com.Rows[0]["PQB09"].ToString( );
                comboBox55.Text = com.Rows[0]["PQB10"].ToString( );
            }
        }
        private void comboBox20_LostFocus( object sender, EventArgs e )
        {
            if (comboBox20.Text != "" && !DateDayRegise.threeOneNum( comboBox20 ))
            {
                this.comboBox20.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多一位,如99.9, 请重新输入" );
            }
            if (comboBox20.Text == "0")
            {
                MessageBox.Show( "不允许输入0,请重新输入" );
                comboBox20.Text = "";
            }
        }
        private void comboBox18_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox18 );
        }
        private void comboBox18_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox18 );
        }
        private void comboBox18_LostFocus( object sender, EventArgs e )
        {
            if (comboBox18.Text != "" && !DateDayRegise.threeOneNum( comboBox18 ))
            {
                this.comboBox18.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多一位,如99.9, 请重新输入" );
            }
        }
        private void comboBox16_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void comboBox19_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox19 );
        }
        private void comboBox19_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox19 );
        }
        private void comboBox19_LostFocus( object sender, EventArgs e )
        {
            if (comboBox19.Text != "" && !DateDayRegise.threeOneNum( comboBox19 ))
            {
                this.comboBox19.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多一位,如99.9, 请重新输入" );
            }
        }
        private void comboBox12_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox12 );
        }
        private void comboBox12_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox12 );
        }
        private void comboBox12_LostFocus( object sender, EventArgs e )
        {
            if (comboBox12.Text != "" && !DateDayRegise.fiveThreeNum( comboBox12 ))
            {
                this.comboBox12.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多三位,如99.999, 请重新输入" );
            }
        }
        private void comboBox11_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox11 );
        }
        private void comboBox11_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox11 );
        }
        private void comboBox11_LostFocus( object sender, EventArgs e )
        {
            if (comboBox11.Text != "" && !DateDayRegise.foreOneNum( comboBox11 ))
            {
                this.comboBox11.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如999.9, 请重新输入" );
            }
        }
        string comb20 = "", comb18 = "",  comb16 = "", comb15 = "", comb14 = "", comb13 = "", comb12 = "", comb11 = "", comb55 = "",comb013="";
        private void gridView2_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (e.FocusedRowHandle != -999997)
            {
                if (btch.plde == "1")
                {
                    comboBox20.Text = gridView2.GetRowCellValue( 0, "PQB01" ).ToString( );
                    comboBox18.Text = gridView2.GetRowCellValue( 0, "PQB03" ).ToString( );
                    comboBox16.Text = gridView2.GetRowCellValue( 0, "PQB04" ).ToString( );
                    comboBox15.Text = gridView2.GetRowCellValue( 0, "PQB05" ).ToString( );
                    comboBox14.Text = gridView2.GetRowCellValue( 0, "PQB06" ).ToString( );
                    comboBox19.Text = gridView2.GetRowCellValue( 0, "PQB11" ).ToString( );
                    comboBox12.Text = gridView2.GetRowCellValue( 0, "PQB08" ).ToString( );
                    comboBox11.Text = gridView2.GetRowCellValue( 0, "PQB09" ).ToString( );
                    comboBox55.Text = gridView2.GetRowCellValue( 0, "PQB10" ).ToString( );
                    comboBox13.Text = gridView2.GetRowCellValue( 0, "PQB12" ).ToString( );
                    btch.plde = "";
                }
                else
                {
                    comboBox20.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQB01" ).ToString( );
                    comboBox18.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQB03" ).ToString( );
                    comboBox16.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQB04" ).ToString( );
                    comboBox15.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQB05" ).ToString( );
                    comboBox14.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQB06" ).ToString( );
                    comboBox19.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQB11" ).ToString( );
                    comboBox12.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQB08" ).ToString( );
                    comboBox11.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQB09" ).ToString( );
                    comboBox55.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQB10" ).ToString( );
                    comboBox13.Text = gridView2.GetRowCellValue( e.FocusedRowHandle, "PQB12" ).ToString( );
                }
                comb20 = comboBox20.Text;              
                comb18 = comboBox18.Text;
                comb16 = comboBox16.Text;
                comb15 = comboBox15.Text;
                comb14 = comboBox14.Text;
                comb13 = comboBox19.Text;
                comb12 = comboBox12.Text;
                comb11 = comboBox11.Text;
                comb55 = comboBox55.Text;
                comb013 = comboBox13.Text;
            }
        }
        private void gridView2_CustomDrawRowIndicator( object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e )
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn item in gridView2.Columns)
            {
                item.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;   //筛选条件设置为包含  
            }
        }
        private void gridView2_Click( object sender, EventArgs e )
        {
            if (gridView2.RowCount == 1)
                comboBox20.Text = gridView2.GetFocusedRowCellValue( "PQB01" ).ToString( );
        }
        //新建
        private void add_for ( )
        {
            PQB1 = Convert.ToDecimal( comboBox20.Text );

            if ( comboBox18.Text != "" )
            {
                PQB3 = Convert.ToDecimal( comboBox18.Text );
            }
            if ( comboBox16.Text != "" )
            {
                PQB4 = Convert.ToInt32( comboBox16.Text );
            }
            PQB5 = comboBox15.Text;
            PQB6 = comboBox14.Text;
            if ( comboBox19.Text != "" )
            {
                PQB011 = Convert.ToDecimal( comboBox19.Text );
            }
            if ( comboBox12.Text != "" )
            {
                PQB8 = Convert.ToDecimal( comboBox12.Text );
            }
            if ( comboBox11.Text != "" )
            {
                PQB9 = Convert.ToDecimal( comboBox11.Text );
            }
            PQB010 = comboBox55.Text;
            PQB012 = comboBox13.Text;
        }
        private void every_for ( )
        {
            comboBox20.Items.Clear( );
            DataTable com20 = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQB01 FROM R_PQB" );
            if ( com20.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < com20.Rows.Count ; i++ )
                    comboBox20.Items.Add( com20.Rows[i]["PQB01"].ToString( ) );
            }

            DataTable fen = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQB" );
            DataTable com18 = fen.DefaultView.ToTable( true ,"PQB03" );
            if ( com18.Rows.Count > 0 )
            {
                comboBox18.DataSource = com18;
                comboBox18.DisplayMember = "PQB03";
            }
            DataTable com16 = fen.DefaultView.ToTable( true ,"PQB04" );
            if ( com16.Rows.Count > 0 )
            {
                comboBox16.DataSource = com16;
                comboBox16.DisplayMember = "PQB04";
            }
            DataTable com15 = fen.DefaultView.ToTable( true ,"PQB05" );
            if ( com15.Rows.Count > 0 )
            {
                comboBox15.DataSource = com15;
                comboBox15.DisplayMember = "PQB05";
            }
            DataTable com14 = fen.DefaultView.ToTable( true ,"PQB06" );
            if ( com14.Rows.Count > 0 )
            {
                comboBox14.DataSource = com14;
                comboBox14.DisplayMember = "PQB06";
            }
            DataTable com13 = fen.DefaultView.ToTable( true ,"PQB11" );
            if ( com13.Rows.Count > 0 )
            {
                comboBox19.DataSource = com13;
                comboBox19.DisplayMember = "PQB11";
            }
            DataTable com12 = fen.DefaultView.ToTable( true ,"PQB08" );
            if ( com12.Rows.Count > 0 )
            {
                comboBox12.DataSource = com12;
                comboBox12.DisplayMember = "PQB08";
            }
            DataTable com11 = fen.DefaultView.ToTable( true ,"PQB09" );
            if ( com11.Rows.Count > 0 )
            {
                comboBox11.DataSource = com11;
                comboBox11.DisplayMember = "PQB09";
            }
            DataTable com55 = fen.DefaultView.ToTable( true ,"PQB10" );
            if ( com55.Rows.Count > 0 )
            {
                comboBox55.DataSource = com55;
                comboBox55.DisplayMember = "PQB10";
            }
            DataTable com013 = fen.DefaultView.ToTable( true ,"PQB12" );
            if ( com013.Rows.Count > 0 )
            {
                comboBox13.DataSource = com013;
                comboBox13.DisplayMember = "PQB12";
            }
        }
        private void build_for ( )
        {
            DataRow row = pqb.NewRow( );
            row["PQB01"] = PQB1;
            row["PQB03"] = PQB3;
            row["PQB04"] = PQB4;
            row["PQB05"] = PQB5;
            row["PQB06"] = PQB6;
            row["PQB11"] = PQB011;
            row["PQB08"] = PQB8;
            row["PQB09"] = PQB9;
            row["PQB10"] = PQB010;
            row["PQB12"] = PQB012;
            pqb.Rows.Add( row );
            pqb.DefaultView.Sort = "PQB01 asc";

            every_for( );
        }
        private void button6_Click( object sender, EventArgs e )
        {
            if (comboBox20.Text == "")
                MessageBox.Show( "" + label20.Text + "不可为空" );
            else
            {
                add_for( );

                if (pqb.Rows.Count < 1)
                {
                    int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQB (PQB01,PQB03,PQB04,PQB05,PQB06,PQB11,PQB08,PQB09,PQB10,PQB12) VALUES (@PQB01,@PQB03,@PQB04,@PQB05,@PQB06,@PQB11,@PQB08,@PQB09,@PQB10,@PQB12)", new SqlParameter( "@PQB01", PQB1 ),  new SqlParameter( "@PQB03", PQB3 ), new SqlParameter( "@PQB04", PQB4 ), new SqlParameter( "@PQB05", PQB5 ), new SqlParameter( "@PQB06", PQB6 ), new SqlParameter( "@PQB11", PQB011 ), new SqlParameter( "@PQB08", PQB8 ), new SqlParameter( "@PQB09", PQB9 ), new SqlParameter( "@PQB10", PQB010 ), new SqlParameter( "@PQB12", PQB012 ) );
                    if (count < 1)
                        MessageBox.Show( "录入数据失败" );
                    else
                    {   
                        MessageBox.Show( "成功录入数据" );
                        build_for( );   
                    }
                }
                else
                {
                    DataTable dpq = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQB WHERE PQB01=@PQB01 AND PQB03=@PQB03 AND PQB04=@PQB04 AND PQB05=@PQB05 AND PQB06=@PQB06 AND PQB11=@PQB11 AND PQB08=@PQB08 AND PQB09=@PQB09 AND PQB10=@PQB10 AND PQB12=@PQB12", new SqlParameter( "@PQB01", PQB1 ), new SqlParameter( "@PQB03", PQB3 ), new SqlParameter( "@PQB04", PQB4 ), new SqlParameter( "@PQB05", PQB5 ), new SqlParameter( "@PQB06", PQB6 ), new SqlParameter( "@PQB11", PQB011 ), new SqlParameter( "@PQB08", PQB8 ), new SqlParameter( "@PQB09", PQB9 ), new SqlParameter( "@PQB10", PQB010 ), new SqlParameter( "@PQB12", PQB012 ) );

                    if (dpq.Rows.Count >= 1)
                        MessageBox.Show( "" + label20.Text + ":" + PQB1 + " \n\r" + label18.Text + ":" + PQB3 + " \n\r" + label16.Text + ":" + PQB4 + " \n\r" + label15.Text + ":" + PQB5 + " \n\r" + label14.Text + ":" + PQB6 + " \n\r" + label19.Text + ":" + PQB011 + " \n\r" + label12.Text + ":" + PQB8 + " \n\r" + label11.Text + ":" + PQB9 + " \n\r" + label55.Text + ":" + PQB010 + " \n\r "+label13.Text+":"+comboBox13.Text+"\n\r的数据已经存在,请核实后再录入" );
                    else
                    {
                        int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQB (PQB01,PQB03,PQB04,PQB05,PQB06,PQB11,PQB08,PQB09,PQB10,PQB12) VALUES (@PQB01,@PQB03,@PQB04,@PQB05,@PQB06,@PQB11,@PQB08,@PQB09,@PQB10,@PQB12)", new SqlParameter( "@PQB01", PQB1 ), new SqlParameter( "@PQB03", PQB3 ), new SqlParameter( "@PQB04", PQB4 ), new SqlParameter( "@PQB05", PQB5 ), new SqlParameter( "@PQB06", PQB6 ), new SqlParameter( "@PQB11", PQB011 ), new SqlParameter( "@PQB08", PQB8 ), new SqlParameter( "@PQB09", PQB9 ), new SqlParameter( "@PQB10", PQB010 ), new SqlParameter( "@PQB12", PQB012 ) );
                        if (count < 1)
                            MessageBox.Show( "录入数据失败" );
                        else
                        {
                            MessageBox.Show( "成功录入数据" );
                            build_for( );
                        }
                    }
                }
            }
        }
        //编辑
        private void button5_Click( object sender, EventArgs e )
        {
            if (pqb.Rows.Count < 1)
                MessageBox.Show( "没有数据,无法编辑" );
            else
            {
                if (comboBox20.Text == "")
                    MessageBox.Show( "" + label20.Text + "不可为空" );
                else
                {
                    add_for( );

                    DataTable dpq = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQB WHERE PQB01=@PQB01 AND PQB03=@PQB03 AND PQB04=@PQB04 AND PQB05=@PQB05 AND PQB06=@PQB06 AND PQB11=@PQB11 AND PQB08=@PQB08 AND PQB09=@PQB09 AND PQB10=@PQB10 AND PQB12=@PQB12", new SqlParameter( "@PQB01", PQB1 ), new SqlParameter( "@PQB03", PQB3 ), new SqlParameter( "@PQB04", PQB4 ), new SqlParameter( "@PQB05", PQB5 ), new SqlParameter( "@PQB06", PQB6 ), new SqlParameter( "@PQB11", PQB011 ), new SqlParameter( "@PQB08", PQB8 ), new SqlParameter( "@PQB09", PQB9 ), new SqlParameter( "@PQB10", PQB010 ), new SqlParameter( "@PQB12", PQB012 ) );

                    if (dpq.Rows.Count >= 1)
                        MessageBox.Show( "" + label20.Text + ":" + PQB1 + " \n\r" + label18.Text + ":" + PQB3 + " \n\r" + label16.Text + ":" + PQB4 + " \n\r" + label15.Text + ":" + PQB5 + " \n\r" + label14.Text + ":" + PQB6 + " \n\r" + label19.Text + ":" + PQB011 + " \n\r" + label12.Text + ":" + PQB8 + " \n\r" + label11.Text + ":" + PQB9 + " \n\r" + label55.Text + ":" + PQB010 + " \n\r" + label13.Text + ":" + comboBox13.Text + " 的数据已经存在,请核实后再编辑" );
                    else
                    {
                        int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQB SET PQB01=@PQB01,PQB03=@PQB03,PQB04=@PQB04,PQB05=@PQB05,PQB06=@PQB06,PQB11=@PQB011,PQB08=@PQB08,PQB09=@PQB09,PQB10=@PQB10 , PQB12=@PQB12 WHERE PQB01=@PB1  AND PQB03=@PB3 AND PQB04=@PB4 AND PQB05=@PB5 AND PQB06=@PB6 AND PQB11=@PB11 AND PQB08=@PB8 AND PQB09=@PB9 AND PQB10=@PB10 AND PQB12=@PQ12", new SqlParameter( "@PQB01", PQB1 ), new SqlParameter( "@PQB03", PQB3 ), new SqlParameter( "@PQB04", PQB4 ), new SqlParameter( "@PQB05", PQB5 ), new SqlParameter( "@PQB06", PQB6 ), new SqlParameter( "@PQB011", PQB011 ), new SqlParameter( "@PQB08", PQB8 ), new SqlParameter( "@PQB09", PQB9 ), new SqlParameter( "@PQB10", PQB010 ), new SqlParameter( "@PQB12", PQB012 ), new SqlParameter( "@PB1", comb20 ), new SqlParameter( "@PB3", comb18 ), new SqlParameter( "@PB4", comb16 ), new SqlParameter( "@PB5", comb15 ), new SqlParameter( "@PB6", comb14 ), new SqlParameter( "@PB11", comb13 ), new SqlParameter( "@PB8", comb12 ), new SqlParameter( "@PB9", comb11 ), new SqlParameter( "@PB10", comb55 ), new SqlParameter( "@PQ12", comb013 ) );
                        if (count < 1)
                            MessageBox.Show( "更新数据失败" );
                        else
                        {
                            
                            MessageBox.Show( "更新数据成功" );
                            int num = gridView2.FocusedRowHandle;
                            DataRow row = pqb.Rows[num];
                            row.BeginEdit( );
                            row["PQB01"] = PQB1;
                            row["PQB03"] = PQB3;
                            row["PQB04"] = PQB4;
                            row["PQB05"] = PQB5;
                            row["PQB06"] = PQB6;
                            row["PQB11"] = PQB011;
                            row["PQB08"] = PQB8;
                            row["PQB09"] = PQB9;
                            row["PQB10"] = PQB010;
                            row["PQB12"] = PQB012;
                            row.EndEdit( );
                            DataTable pqbo = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQB ORDER BY PQB01" );
                            gridControl2.DataSource = pqbo;
                            every_for( );
                        }
                    }
                }
            }
        }
        //删除
        private void button4_Click( object sender, EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==

            DialogResult . Cancel )
                return;
            if (pqb.Rows.Count < 1)
                MessageBox.Show( "没有数据,无法删除" );
            else
            {
                if (comboBox20.Text == "")
                    MessageBox.Show( "" + label20.Text + "不可为空" );
                else
                {
                    add_for( );

                    DataTable dpq = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQB WHERE PQB01=@PQB01 AND PQB03=@PQB03 AND PQB04=@PQB04 AND PQB05=@PQB05 AND PQB06=@PQB06 AND PQB11=@PQB11 AND PQB08=@PQB08 AND PQB09=@PQB09 AND PQB10=@PQB10 AND PQB12=@PQB12", new SqlParameter( "@PQB01", PQB1 ), new SqlParameter( "@PQB03", PQB3 ), new SqlParameter( "@PQB04", PQB4 ), new SqlParameter( "@PQB05", PQB5 ), new SqlParameter( "@PQB06", PQB6 ), new SqlParameter( "@PQB11", PQB011 ), new SqlParameter( "@PQB08", PQB8 ), new SqlParameter( "@PQB09", PQB9 ), new SqlParameter( "@PQB10", PQB010 ), new SqlParameter( "@PQB12", PQB012 ) );

                    if (dpq.Rows.Count >= 1)
                    {
                        int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQB WHERE PQB01=@PQB01 AND PQB03=@PQB03 AND PQB04=@PQB04 AND PQB05=@PQB05 AND PQB06=@PQB06 AND PQB11=@PQB11 AND PQB08=@PQB08 AND PQB09=@PQB09 AND PQB10=@PQB10 AND PQB12=@PQB12", new SqlParameter( "@PQB01", PQB1 ),  new SqlParameter( "@PQB03", PQB3 ), new SqlParameter( "@PQB04", PQB4 ), new SqlParameter( "@PQB05", PQB5 ), new SqlParameter( "@PQB06", PQB6 ), new SqlParameter( "@PQB11", PQB011 ), new SqlParameter( "@PQB08", PQB8 ), new SqlParameter( "@PQB09", PQB9 ), new SqlParameter( "@PQB10", PQB010 ), new SqlParameter( "@PQB12", PQB012 ) );
                        if (count < 1)
                            MessageBox.Show( "删除数据失败" );
                        else
                        {
                            MessageBox.Show( "成功删除数据" );
                            int num = gridView2.FocusedRowHandle;
                            pqb.Rows.RemoveAt( num );
                            every_for( );
                        }
                    }
                    else
                        MessageBox.Show( "不存在 \n\r" + label20.Text + ":" + PQB1 + " \n\r" + label18.Text + ":" + PQB3 + " \n\r" + label16.Text + ":" + PQB4 + " \n\r" + label15.Text + ":" + PQB5 + " \n\r" + label14.Text + ":" + PQB6 + " \n\r" + label19.Text + ":" + PQB011 + " \n\r" + label12.Text + ":" + PQB8 + " \n\r" + label11.Text + ":" + PQB9 + " \n\r" + label55.Text + ":" + PQB010 + " \n\r" + label13.Text + ":" + comboBox13.Text + "\n\r 的数据,请核实后再删除" );
                }
            }
        }
        //刷新
        private void button19_Click( object sender, EventArgs e )
        {
            pqb = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQB ORDER BY PQB01" );
            gridControl2.DataSource = pqb;
        }
        //批量新建
        private void button32_Click( object sender, EventArgs e )
        {
            if (gridView2.RowCount > 0)
            {
                btch.pl = "f1";
                btch.textBox1.Text = gridView2.GetFocusedRowCellValue( "PQB09" ).ToString( );
                btch.textBox2.Text = gridView2.GetFocusedRowCellValue( "PQB05" ).ToString( );
                btch.textBox3.Text = gridView2.GetFocusedRowCellValue( "PQB10" ).ToString( );
                btch.textBox4.Text = gridView2.GetFocusedRowCellValue( "PQB06" ).ToString( );
                btch.textBox5.Text = gridView2.GetFocusedRowCellValue( "PQB04" ).ToString( );
                btch.textBox6.Text = gridView2.GetFocusedRowCellValue( "PQB12" ).ToString( );
                btch.textBox8.Text = gridView2.GetFocusedRowCellValue( "PQB08" ).ToString( );
                btch.StartPosition = FormStartPosition.CenterScreen;
                btch.ShowDialog( );
            }
            else
                MessageBox.Show( "没有数据,无法批量新建" );
        }
        //批量编辑
        private void button31_Click( object sender, EventArgs e )
        {
            if (gridView2.RowCount > 0)
            {
                btch.pl = "f2";
                btch.textBox1.Text = gridView2.GetFocusedRowCellValue( "PQB09" ).ToString( );
                btch.textBox2.Text = gridView2.GetFocusedRowCellValue( "PQB05" ).ToString( );
                btch.textBox3.Text = gridView2.GetFocusedRowCellValue( "PQB10" ).ToString( );
                btch.textBox4.Text = gridView2.GetFocusedRowCellValue( "PQB06" ).ToString( );
                btch.textBox5.Text = gridView2.GetFocusedRowCellValue( "PQB04" ).ToString( );
                btch.textBox6.Text = gridView2.GetFocusedRowCellValue( "PQB12" ).ToString( );
                btch.textBox8.Text = gridView2.GetFocusedRowCellValue( "PQB08" ).ToString( );
                btch.StartPosition = FormStartPosition.CenterScreen;
                btch.ShowDialog( );
            }
            else
                MessageBox.Show( "没有数据,无法批量编辑" );
        }
        //批量删除
        private void button30_Click( object sender, EventArgs e )
        {
            if (gridView2.RowCount > 0)
            {
                btch.pl = "f3";
                btch.textBox1.Text = gridView2.GetFocusedRowCellValue( "PQB09" ).ToString( );
                btch.textBox2.Text = gridView2.GetFocusedRowCellValue( "PQB05" ).ToString( );
                btch.textBox3.Text = gridView2.GetFocusedRowCellValue( "PQB10" ).ToString( );
                btch.textBox4.Text = gridView2.GetFocusedRowCellValue( "PQB06" ).ToString( );
                btch.textBox5.Text = gridView2.GetFocusedRowCellValue( "PQB04" ).ToString( );
                btch.textBox6.Text = gridView2.GetFocusedRowCellValue( "PQB12" ).ToString( );
                btch.textBox8.Text = gridView2.GetFocusedRowCellValue( "PQB08" ).ToString( );
                btch.StartPosition = FormStartPosition.CenterScreen;
                btch.ShowDialog( );
            }
            else
                MessageBox.Show( "没有数据,无法批量删除" );
        }
        #endregion

        #region 涂布  
        int PQC1 = 0, PQC4 = 0, PQC7 = 0;
        decimal  PQC5 = 0M, PQC6 = 0M, PQC011 = 0M, PQC012 = 0M;
        string PQC8 = "", PQC9 = "", PQC013 = "", PQC014 = "", PQC2 = "", PQC3 = "";
        private void comboBox30_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void comboBox30_TextChanged( object sender, EventArgs e )
        {
            string com30 = comboBox30.Text;
            DataTable com = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQC WHERE PQC01=@PQC01", new SqlParameter( "@PQC01", com30 ) );
            if (com.Rows.Count >0)
            {
                comboBox41.Text = com.Rows[0]["PQC02"].ToString( );
                comboBox17.Text = com.Rows[0]["PQC03"].ToString( );
                comboBox29.Text = com.Rows[0]["PQC04"].ToString( );
                comboBox28.Text = com.Rows[0]["PQC05"].ToString( );
                comboBox27.Text = com.Rows[0]["PQC06"].ToString( );
                comboBox26.Text = com.Rows[0]["PQC07"].ToString( );
                comboBox25.Text = com.Rows[0]["PQC08"].ToString( );
                comboBox24.Text = com.Rows[0]["PQC09"].ToString( );              
                comboBox22.Text = com.Rows[0]["PQC11"].ToString( );
                comboBox21.Text = com.Rows[0]["PQC12"].ToString( );
                comboBox56.Text = com.Rows[0]["PQC13"].ToString( );
                comboBox57.Text = com.Rows[0]["PQC14"].ToString( );
            }
        }
        private void comboBox30_SelectedValueChanged( object sender, EventArgs e )
        {
            string com30 = comboBox30.Text;
            DataTable com = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQC WHERE PQC01=@PQC01", new SqlParameter( "@PQC01", com30 ) );
            if (com.Rows.Count > 0)
            {
                comboBox41.Text = com.Rows[0]["PQC02"].ToString( );
                comboBox17.Text = com.Rows[0]["PQC03"].ToString( );
                comboBox29.Text = com.Rows[0]["PQC04"].ToString( );
                comboBox28.Text = com.Rows[0]["PQC05"].ToString( );
                comboBox27.Text = com.Rows[0]["PQC06"].ToString( );
                comboBox26.Text = com.Rows[0]["PQC07"].ToString( );
                comboBox25.Text = com.Rows[0]["PQC08"].ToString( );
                comboBox24.Text = com.Rows[0]["PQC09"].ToString( );
                comboBox22.Text = com.Rows[0]["PQC11"].ToString( );
                comboBox21.Text = com.Rows[0]["PQC12"].ToString( );
                comboBox56.Text = com.Rows[0]["PQC13"].ToString( );
                comboBox57.Text = com.Rows[0]["PQC14"].ToString( );
            }
        }
        private void comboBox30_LostFocus( object sender, EventArgs e )
        {
            if (comboBox30.Text == "0")
            {
                MessageBox.Show( "不允许输入0,请重新输入" );
                comboBox30.Text = "";
            }
        }
        private void gridView3_Click( object sender, EventArgs e )
        {
            if (gridView3.RowCount == 1)
                comboBox30.Text = gridView3.GetFocusedRowCellValue( "PQC01" ).ToString( );
        }
        string com30 = "", com41 = "", com17 = "", com29 = "", com28 = "", com27 = "", com26 = "", com25 = "", com24 = "", com22 = "", com21 = "", com56 = "", com57 = "";
        private void gridView3_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
             if(e.FocusedRowHandle!=-999997)
            {
                if (btch.plde == "1")
                {
                    comboBox30.Text = gridView3.GetRowCellValue( 0, "PQC01" ).ToString( );
                    comboBox41.Text = gridView3.GetRowCellValue( 0, "PQC02" ).ToString( );
                    comboBox17.Text = gridView3.GetRowCellValue( 0, "PQC03" ).ToString( );
                    comboBox29.Text = gridView3.GetRowCellValue( 0, "PQC04" ).ToString( );
                    comboBox28.Text = gridView3.GetRowCellValue( 0, "PQC05" ).ToString( );
                    comboBox27.Text = gridView3.GetRowCellValue( 0, "PQC06" ).ToString( );
                    comboBox26.Text = gridView3.GetRowCellValue( 0, "PQC07" ).ToString( );
                    comboBox25.Text = gridView3.GetRowCellValue( 0, "PQC08" ).ToString( );
                    comboBox24.Text = gridView3.GetRowCellValue( 0, "PQC09" ).ToString( );
                    comboBox22.Text = gridView3.GetRowCellValue( 0, "PQC11" ).ToString( );
                    comboBox21.Text = gridView3.GetRowCellValue( 0, "PQC12" ).ToString( );
                    comboBox56.Text = gridView3.GetRowCellValue( 0, "PQC13" ).ToString( );
                    comboBox57.Text = gridView3.GetRowCellValue( 0, "PQC14" ).ToString( );
                    btch.plde = "";
                }
                else
                {
                    comboBox30.Text = gridView3.GetRowCellValue( e.FocusedRowHandle, "PQC01" ).ToString( );
                    comboBox41.Text = gridView3.GetRowCellValue( e.FocusedRowHandle, "PQC02" ).ToString( );
                    comboBox17.Text = gridView3.GetRowCellValue( e.FocusedRowHandle, "PQC03" ).ToString( );
                    comboBox29.Text = gridView3.GetRowCellValue( e.FocusedRowHandle, "PQC04" ).ToString( );
                    comboBox28.Text = gridView3.GetRowCellValue( e.FocusedRowHandle, "PQC05" ).ToString( );
                    comboBox27.Text = gridView3.GetRowCellValue( e.FocusedRowHandle, "PQC06" ).ToString( );
                    comboBox26.Text = gridView3.GetRowCellValue( e.FocusedRowHandle, "PQC07" ).ToString( );
                    comboBox25.Text = gridView3.GetRowCellValue( e.FocusedRowHandle, "PQC08" ).ToString( );
                    comboBox24.Text = gridView3.GetRowCellValue( e.FocusedRowHandle, "PQC09" ).ToString( );
                    comboBox22.Text = gridView3.GetRowCellValue( e.FocusedRowHandle, "PQC11" ).ToString( );
                    comboBox21.Text = gridView3.GetRowCellValue( e.FocusedRowHandle, "PQC12" ).ToString( );
                    comboBox56.Text = gridView3.GetRowCellValue( e.FocusedRowHandle, "PQC13" ).ToString( );
                    comboBox57.Text = gridView3.GetRowCellValue( e.FocusedRowHandle, "PQC14" ).ToString( );
                }               
                com30 = comboBox30.Text;
                com41 = comboBox41.Text;
                com17 = comboBox17.Text;
                com29 = comboBox29.Text;
                com28 = comboBox28.Text;
                com27 = comboBox27.Text;
                com26 = comboBox26.Text;
                com25 = comboBox25.Text;
                com24 = comboBox24.Text;
                com22 = comboBox22.Text;
                com21 = comboBox21.Text;
                com56 = comboBox56.Text;
                com57 = comboBox57.Text;
            }
        }
        private void gridView3_CustomDrawRowIndicator( object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e )
        {
            foreach (DevExpress.XtraGrid.Columns.GridColumn item in gridView3.Columns)
            {
                item.OptionsFilter.AutoFilterCondition = DevExpress.XtraGrid.Columns.AutoFilterCondition.Contains;   //筛选条件设置为包含  
            }
        }
        private void comboBox41_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar!=45)
            {
                e.Handled = true;
                MessageBox.Show( "只允许输入区间整数,如10-20" );
            }
        }
        private void comboBox29_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void comboBox28_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox28 );
        }
        private void comboBox28_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox28 );
        }
        private void comboBox28_LostFocus( object sender, EventArgs e )
        {
            if (comboBox28.Text != "" && !DateDayRegise.foreTwoNum( comboBox28 ))
            {
                this.comboBox28.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多两位,如99.99, 请重新输入" );
            }
        }
        private void comboBox27_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox27 );
        }
        private void comboBox27_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox27 );
        }
        private void comboBox27_LostFocus( object sender, EventArgs e )
        {
            if (comboBox27.Text != "" && !DateDayRegise.fiveThreeNum( comboBox27 ))
            {
                this.comboBox27.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多三位,如99.999, 请重新输入" );
            }
        }
        private void comboBox26_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void comboBox22_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox22 );
        }
        private void comboBox22_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox22 );
        }
        private void comboBox22_LostFocus( object sender, EventArgs e )
        {
            if (comboBox22.Text != "" && !DateDayRegise.fiveThreeNum( comboBox22 ))
            {
                this.comboBox22.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多三位,如99.999, 请重新输入" );
            }
        }
        private void comboBox21_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox21 );
        }
        private void comboBox21_TextChanged( object sender, EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox21 );
        }
        private void comboBox21_LostFocus( object sender, EventArgs e )
        {
            if (comboBox21.Text != "" && !DateDayRegise.threeOneNum( comboBox21 ))
            {
                this.comboBox21.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多一位,如99.9, 请重新输入" );
            }
        }
        //新建
        private void add_fiv ( )
        {
            PQC1 = Convert.ToInt32( comboBox30.Text );
            PQC2 = comboBox41.Text;
            PQC3 = comboBox17.Text;
            if ( comboBox29.Text != "" )
            {
                PQC4 = Convert.ToInt32( comboBox29.Text );
            }
            if ( comboBox28.Text != "" )
            {
                PQC5 = Convert.ToDecimal( comboBox28.Text );
            }
            if ( comboBox27.Text != "" )
            {
                PQC6 = Convert.ToDecimal( comboBox27.Text );
            }
            if ( comboBox26.Text != "" )
            {
                PQC7 = Convert.ToInt32( comboBox26.Text );
            }
            PQC8 = comboBox25.Text;
            PQC9 = comboBox24.Text;

            if ( comboBox22.Text != "" )
            {
                PQC011 = Convert.ToDecimal( comboBox22.Text );
            }
            if ( comboBox21.Text != "" )
            {
                PQC012 = Convert.ToDecimal( comboBox21.Text );
            }
            PQC013 = comboBox56.Text;
            PQC014 = comboBox57.Text;
        }
        private void every_fiv ( )
        {
            comboBox30.Items.Clear( );
            DataTable com30 = SqlHelper.ExecuteDataTable( "SELECT DISTINCT PQC01 FROM R_PQC" );
            if ( com30.Rows.Count > 0 )
            {
                for ( int i = 0 ; i < com30.Rows.Count ; i++ )
                {
                    comboBox30.Items.Add( com30.Rows[i]["PQC01"].ToString( ) );
                }
            }
            DataTable tu = SqlHelper.ExecuteDataTable( "SELECT *  FROM R_PQC" );
            DataTable com41 = tu.DefaultView.ToTable( true ,"PQC02" );
            if ( com41.Rows.Count > 0 )
            {
                comboBox41.DataSource = com41;
                comboBox41.DisplayMember = "PQC02";
            }
            DataTable com17 = tu.DefaultView.ToTable( true ,"PQC03" );
            if ( com17.Rows.Count > 0 )
            {
                comboBox17.DataSource = com17;
                comboBox17.DisplayMember = "PQC03";
            }
            DataTable com29 = tu.DefaultView.ToTable( true ,"PQC04" );
            if ( com29.Rows.Count > 0 )
            {
                comboBox29.DataSource = com29;
                comboBox29.DisplayMember = "PQC04";
            }
            DataTable com28 = tu.DefaultView.ToTable( true ,"PQC05" );
            if ( com28.Rows.Count > 0 )
            {
                comboBox28.DataSource = com28;
                comboBox28.DisplayMember = "PQC05";
            }
            DataTable com27 = tu.DefaultView.ToTable( true ,"PQC06" );
            if ( com27.Rows.Count > 0 )
            {
                comboBox27.DataSource = com27;
                comboBox27.DisplayMember = "PQC06";
            }
            DataTable com26 = tu.DefaultView.ToTable( true ,"PQC07" );
            if ( com26.Rows.Count > 0 )
            {
                comboBox26.DataSource = com26;
                comboBox26.DisplayMember = "PQC07";
            }
            DataTable com25 = tu.DefaultView.ToTable( true ,"PQC08" );
            if ( com25.Rows.Count > 0 )
            {
                comboBox25.DataSource = com25;
                comboBox25.DisplayMember = "PQC08";
            }
            DataTable com24 = tu.DefaultView.ToTable( true ,"PQC09" );
            if ( com24.Rows.Count > 0 )
            {
                comboBox24.DataSource = com24;
                comboBox24.DisplayMember = "PQC09";
            }
            DataTable com22 = tu.DefaultView.ToTable( true ,"PQC11" );
            if ( com22.Rows.Count > 0 )
            {
                comboBox22.DataSource = com22;
                comboBox22.DisplayMember = "PQC11";
            }
            DataTable com21 = tu.DefaultView.ToTable( true ,"PQC12" );
            if ( com21.Rows.Count > 0 )
            {
                comboBox21.DataSource = com21;
                comboBox21.DisplayMember = "PQC12";
            }
            DataTable com56 = tu.DefaultView.ToTable( true ,"PQC13" );
            if ( com56.Rows.Count > 0 )
            {
                comboBox56.DataSource = com56;
                comboBox56.DisplayMember = "PQC13";
            }
            DataTable com57 = tu.DefaultView.ToTable( true ,"PQC14" );
            if ( com57.Rows.Count > 0 )
            {
                comboBox57.DataSource = com57;
                comboBox57.DisplayMember = "PQC14";
            }
        }
        private void build_fiv ( )
        {
            DataRow row = pqc.NewRow( );
            row["PQC01"] = PQC1;
            row["PQC02"] = PQC2;
            row["PQC03"] = PQC3;
            row["PQC04"] = PQC4;
            row["PQC05"] = PQC5;
            row["PQC06"] = PQC6;
            row["PQC07"] = PQC7;
            row["PQC08"] = PQC8;
            row["PQC09"] = PQC9;
            row["PQC11"] = PQC011;
            row["PQC12"] = PQC012;
            row["PQC13"] = PQC013;
            row["PQC14"] = PQC014;
            pqc.Rows.Add( row );
            pqc.DefaultView.Sort = "PQC01 asc";

            every_fiv( );
        }
        private void button9_Click( object sender, EventArgs e )
        {
            if (comboBox30.Text == "")
                MessageBox.Show( "" + label30.Text + "不可为空" );
            else
            {
                add_fiv( );
                if (pqc.Rows.Count < 1)
                {
                    int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQC (PQC01,PQC02,PQC03,PQC04,PQC05,PQC06,PQC07,PQC08,PQC09,PQC11,PQC12,PQC13,PQC14) VALUES (@PQC01,@PQC02,@PQC03,@PQC04,@PQC05,@PQC06,@PQC07,@PQC08,@PQC09,@PQC11,@PQC12,@PQC13,@PQC14)", new SqlParameter( "@PQC01", PQC1 ), new SqlParameter( "@PQC02", PQC2 ), new SqlParameter( "@PQC03", PQC3 ), new SqlParameter( "@PQC04", PQC4 ), new SqlParameter( "@PQC05", PQC5 ), new SqlParameter( "@PQC06", PQC6 ), new SqlParameter( "@PQC07", PQC7 ), new SqlParameter( "@PQC08", PQC8 ), new SqlParameter( "@PQC09", PQC9 ), new SqlParameter( "@PQC11", PQC011 ), new SqlParameter( "@PQC12", PQC012 ), new SqlParameter( "@PQC13", PQC013 ), new SqlParameter( "@PQC14", PQC014 ) );
                    if (count < 1)
                        MessageBox.Show( "录入数据失败" );
                    else
                    {
                        MessageBox.Show( "成功录入数据" );
                        build_fiv( );
                    }
                }
                else
                {
                    DataTable dpq = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQC WHERE PQC01=@PQC01 AND PQC02=@PQC02 AND PQC03=@PQC03 AND PQC04=@PQC04 AND PQC05=@PQC05 AND PQC06=@PQC06 AND PQC07=@PQC07 AND PQC08=@PQC08 AND PQC09=@PQC09 AND PQC11=@PQC11 AND PQC12=@PQC12 AND PQC13=@PQC13 AND PQC14=@PQC14", new SqlParameter( "@PQC01", PQC1 ), new SqlParameter( "@PQC02", PQC2 ), new SqlParameter( "@PQC03", PQC3 ), new SqlParameter( "@PQC04", PQC4 ), new SqlParameter( "@PQC05", PQC5 ), new SqlParameter( "@PQC06", PQC6 ), new SqlParameter( "@PQC07", PQC7 ), new SqlParameter( "@PQC08", PQC8 ), new SqlParameter( "@PQC09", PQC9 ), new SqlParameter( "@PQC11", PQC011 ), new SqlParameter( "@PQC12", PQC012 ), new SqlParameter( "@PQC13", PQC013 ), new SqlParameter( "@PQC14", PQC014 ) );

                    if (dpq.Rows.Count >= 1)
                        MessageBox.Show( "" + label30.Text + ":" + PQC1 + " \n\r" + label41.Text + ":" + PQC2 + " \n\r" + label17.Text + ":" + PQC3 + " \n\r" + label29.Text + ":" + PQC4 + " \n\r" + label28.Text + ":" + PQC5 + " \n\r" + label27.Text + ":" + PQC6 + " \n\r" + label26.Text + ":" + PQC7 + " \n\r" + label25.Text + ":" + PQC8 + " \n\r" + label24.Text + ":" + PQC9 + " \n\r" + label22.Text + ":" + PQC011 + " \n\r" + label21.Text + ":" + PQC012 + " \n\r" + label56.Text + ":" + PQC013 + " \n\r" + label57.Text + ":" + PQC014 + " \n\r 的数据已经存在,请核实后再录入" );
                    else
                    {
                        int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQC (PQC01,PQC02,PQC03,PQC04,PQC05,PQC06,PQC07,PQC08,PQC09,PQC11,PQC12,PQC13,PQC14) VALUES (@PQC01,@PQC02,@PQC03,@PQC04,@PQC05,@PQC06,@PQC07,@PQC08,@PQC09,@PQC11,@PQC12,@PQC13,@PQC14)", new SqlParameter( "@PQC01", PQC1 ), new SqlParameter( "@PQC02", PQC2 ), new SqlParameter( "@PQC03", PQC3 ), new SqlParameter( "@PQC04", PQC4 ), new SqlParameter( "@PQC05", PQC5 ), new SqlParameter( "@PQC06", PQC6 ), new SqlParameter( "@PQC07", PQC7 ), new SqlParameter( "@PQC08", PQC8 ), new SqlParameter( "@PQC09", PQC9 ),  new SqlParameter( "@PQC11", PQC011 ), new SqlParameter( "@PQC12", PQC012 ), new SqlParameter( "@PQC13", PQC013 ), new SqlParameter( "@PQC14", PQC014 ) );
                        if (count < 1)
                            MessageBox.Show( "录入数据失败" );
                        else
                        {
                            MessageBox.Show( "成功录入数据" );

                            build_fiv( );
                        }
                    }
                }
            }
        }
        //编辑
        private void button8_Click( object sender, EventArgs e )
        {
            if (pqc.Rows.Count < 1)
                MessageBox.Show( "没有数据,无法编译" );
            else
            {
                if (comboBox30.Text == "")
                    MessageBox.Show( "" + label30.Text + "不可为空" );
                else
                {
                    add_fiv( );

                    DataTable dpq = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQC WHERE PQC01=@PQC01 AND PQC02=@PQC02 AND PQC03=@PQC03 AND PQC04=@PQC04 AND PQC05=@PQC05 AND PQC06=@PQC06 AND PQC07=@PQC07 AND PQC08=@PQC08 AND PQC09=@PQC09 AND PQC11=@PQC11 AND PQC12=@PQC12 AND PQC13=@PQC13 AND PQC14=@PQC14", new SqlParameter( "@PQC01", PQC1 ), new SqlParameter( "@PQC02", PQC2 ), new SqlParameter( "@PQC03", PQC3 ), new SqlParameter( "@PQC04", PQC4 ), new SqlParameter( "@PQC05", PQC5 ), new SqlParameter( "@PQC06", PQC6 ), new SqlParameter( "@PQC07", PQC7 ), new SqlParameter( "@PQC08", PQC8 ), new SqlParameter( "@PQC09", PQC9 ), new SqlParameter( "@PQC11", PQC011 ), new SqlParameter( "@PQC12", PQC012 ), new SqlParameter( "@PQC13", PQC013 ), new SqlParameter( "@PQC14", PQC014 ) );

                    if (dpq.Rows.Count >= 1)
                        MessageBox.Show( "" + label30.Text + ":" + PQC1 + " \n\r" + label41.Text + ":" + PQC2 + " \n\r" + label17.Text + ":" + PQC3 + " \n\r" + label29.Text + ":" + PQC4 + " \n\r" + label28.Text + ":" + PQC5 + " \n\r" + label27.Text + ":" + PQC6 + " \n\r" + label26.Text + ":" + PQC7 + " \n\r" + label25.Text + "为" + PQC8 + " \n\r" + label24.Text + "为" + PQC9 + " \n\r" + label22.Text + ":" + PQC011 + " \n\r" + label21.Text + ":" + PQC012 + " \n\r" + label56.Text + ":" + PQC013 + " \n\r" + label57.Text + ":" + PQC014 + " \n\r 的数据已经存在,请核实后再编辑" );
                    else
                    {
                        int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQC SET PQC01=@PQC01,PQC02=@PQC02,PQC03=@PQC03,PQC04=@PQC04,PQC05=@PQC05,PQC06=@PQC06,PQC07=@PQC07,PQC08=@PQC08,PQC09=@PQC09,PQC11=@PQC11,PQC12=@PQC12,PQC13=@PQC13 ,PQC14=@PQC14 WHERE PQC01=@PC1 AND PQC02=@PC2 AND PQC03=@PC3 AND PQC04=@PC4 AND PQC05=@PC5 AND PQC06=@PC6 AND PQC07=@PC7 AND PQC08=@PC8 AND PQC09=@PC9  AND PQC11=@PC11 AND PQC12=@PC12 AND PQC13=@PC13 AND PQC14=@PC14", new SqlParameter( "@PC1", com30 ), new SqlParameter( "@PC2", com41 ), new SqlParameter( "@PC3", com17 ), new SqlParameter( "@PC4", com29 ), new SqlParameter( "@PC5", com28 ), new SqlParameter( "@PC6", com27 ), new SqlParameter( "@PC7", com26 ), new SqlParameter( "@PC8", com25 ), new SqlParameter( "@PC9", com24 ), new SqlParameter( "@PC11", com22 ), new SqlParameter( "@PC12", com21 ), new SqlParameter( "@PC13", com56 ), new SqlParameter( "@PC14", com57 ), new SqlParameter( "@PQC01", PQC1 ), new SqlParameter( "@PQC02", PQC2 ), new SqlParameter( "@PQC03", PQC3 ), new SqlParameter( "@PQC04", PQC4 ), new SqlParameter( "@PQC05", PQC5 ), new SqlParameter( "@PQC06", PQC6 ), new SqlParameter( "@PQC07", PQC7 ), new SqlParameter( "@PQC08", PQC8 ), new SqlParameter( "@PQC09", PQC9 ), new SqlParameter( "@PQC11", PQC011 ), new SqlParameter( "@PQC12", PQC012 ), new SqlParameter( "@PQC13", PQC013 ), new SqlParameter( "@PQC14", PQC014 ) );
                        if (count < 1)
                            MessageBox.Show( "数据编辑失败" );
                        else
                        {
                            MessageBox.Show( "数据编辑成功" );
                            int num = gridView3.FocusedRowHandle;
                            DataRow row = pqc.Rows[num];
                            row.BeginEdit( );
                            row["PQC01"] = PQC1;
                            row["PQC02"] = PQC2;
                            row["PQC03"] = PQC3;
                            row["PQC04"] = PQC4;
                            row["PQC05"] = PQC5;
                            row["PQC06"] = PQC6;
                            row["PQC07"] = PQC7;
                            row["PQC08"] = PQC8;
                            row["PQC09"] = PQC9;
                            row["PQC11"] = PQC011;
                            row["PQC12"] = PQC012;
                            row["PQC13"] = PQC013;
                            row["PQC14"] = PQC014;
                            row.EndEdit( );
                            DataTable pqco = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQC ORDER BY PQC01" );
                            gridControl3.DataSource = pqco;
                            every_fiv( );
                        }
                    }
                }
            }
        }
        //删除
        private void button7_Click( object sender, EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==

            DialogResult . Cancel )
                return;
            if (pqc.Rows.Count < 1)
                MessageBox.Show( "没有数据,无法删除" );
            else
            {
                if (comboBox30.Text == "")
                    MessageBox.Show( "" + label30.Text + "不可为空" );
                else
                {
                    add_fiv( );

                    DataTable dpq = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQC WHERE PQC01=@PQC01 AND PQC02=@PQC02 AND PQC03=@PQC03 AND PQC04=@PQC04 AND PQC05=@PQC05 AND PQC06=@PQC06 AND PQC07=@PQC07 AND PQC08=@PQC08 AND PQC09=@PQC09 AND PQC11=@PQC11 AND PQC12=@PQC12 AND PQC13=@PQC13 AND PQC14=@PQC14", new SqlParameter( "@PQC01", PQC1 ), new SqlParameter( "@PQC02", PQC2 ), new SqlParameter( "@PQC03", PQC3 ), new SqlParameter( "@PQC04", PQC4 ), new SqlParameter( "@PQC05", PQC5 ), new SqlParameter( "@PQC06", PQC6 ), new SqlParameter( "@PQC07", PQC7 ), new SqlParameter( "@PQC08", PQC8 ), new SqlParameter( "@PQC09", PQC9 ), new SqlParameter( "@PQC11", PQC011 ), new SqlParameter( "@PQC12", PQC012 ), new SqlParameter( "@PQC13", PQC013 ), new SqlParameter( "@PQC14", PQC014 ) );

                    if (dpq.Rows.Count >= 1)
                    {
                                      
                        int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQC WHERE PQC01=@PQC01 AND PQC02=@PQC02 AND PQC03=@PQC03 AND PQC04=@PQC04 AND PQC05=@PQC05 AND PQC06=@PQC06 AND PQC07=@PQC07 AND PQC08=@PQC08 AND PQC09=@PQC09 AND PQC11=@PQC11 AND PQC12=@PQC12 AND PQC13=@PQC13 AND PQC14=@PQC14", new SqlParameter( "@PQC01", PQC1 ), new SqlParameter( "@PQC02", PQC2 ), new SqlParameter( "@PQC03", PQC3 ), new SqlParameter( "@PQC04", PQC4 ), new SqlParameter( "@PQC05", PQC5 ), new SqlParameter( "@PQC06", PQC6 ), new SqlParameter( "@PQC07", PQC7 ), new SqlParameter( "@PQC08", PQC8 ), new SqlParameter( "@PQC09", PQC9 ), new SqlParameter( "@PQC11", PQC011 ), new SqlParameter( "@PQC12", PQC012 ), new SqlParameter( "@PQC13", PQC013 ), new SqlParameter( "@PQC14", PQC014 ) );
                        if (count < 1)
                            MessageBox.Show( "数据删除失败" );
                        else
                        {
                            MessageBox.Show( "数据删除成功" );
                            int num = gridView3.FocusedRowHandle;
                            pqc.Rows.RemoveAt( num );
                            every_fiv( );
                        }
                    }
                    else
                        MessageBox.Show( "不存在 \n\r" + label30.Text + ":" + PQC1 + " \n\r" + label41.Text + ":" + PQC2 + " \n\r" + label17.Text + ":" + PQC3 + " \n\r" + label29.Text + ":" + PQC4 + " \n\r" + label28.Text + ":" + PQC5 + " \n\r" + label27.Text + ":" + PQC6 + " \n\r" + label26.Text + ":" + PQC7 + " \n\r" + label25.Text + ":" + PQC8 + " \n\r" + label24.Text + ":" + PQC9 + " \n\r" + label22.Text + ":" + PQC011 + " \n\r" + label21.Text + ":" + PQC012 + " \n\r" + label56.Text + ":" + PQC013 + " \n\r" + label57.Text + ":" + PQC014 + " \n\r 的数据,请核实后再删除" );
                }
            }
        }
        //刷新
        private void button20_Click( object sender, EventArgs e )
        {
            pqc = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQC ORDER BY PQC01" );
            gridControl3.DataSource = pqc;
        }
        //批量新建
        private void button35_Click( object sender, EventArgs e )
        {
            if (gridView3.RowCount > 0)
            {
                btch.pl = "t1";
                btch.textBox1.Text = gridView3.GetFocusedRowCellValue( "PQC12" ).ToString( );
                btch.textBox2.Text = gridView3.GetFocusedRowCellValue( "PQC08" ).ToString( );
                btch.textBox3.Text = gridView3.GetFocusedRowCellValue( "PQC13" ).ToString( );
                btch.textBox4.Text = gridView3.GetFocusedRowCellValue( "PQC09" ).ToString( );
                btch.textBox5.Text = gridView3.GetFocusedRowCellValue( "PQC07" ).ToString( );
                btch.textBox6.Text = gridView3.GetFocusedRowCellValue( "PQC14" ).ToString( );
                btch.textBox7.Text = gridView3.GetFocusedRowCellValue( "PQC03" ).ToString( );
                btch.textBox8.Text = gridView3.GetFocusedRowCellValue( "PQC11" ).ToString( );
                btch.textBox9.Text = gridView3.GetFocusedRowCellValue( "PQC06" ).ToString( );
                btch.StartPosition = FormStartPosition.CenterScreen;
                btch.ShowDialog( );
            }
            else
                MessageBox.Show( "没有数据,无法批量新建" );
        }
        //批量编辑
        private void button34_Click( object sender, EventArgs e )
        {
            if (gridView3.RowCount > 0)
            {
                btch.pl = "t2";
                btch.textBox1.Text = gridView3.GetFocusedRowCellValue( "PQC12" ).ToString( );
                btch.textBox2.Text = gridView3.GetFocusedRowCellValue( "PQC08" ).ToString( );
                btch.textBox3.Text = gridView3.GetFocusedRowCellValue( "PQC13" ).ToString( );
                btch.textBox4.Text = gridView3.GetFocusedRowCellValue( "PQC09" ).ToString( );
                btch.textBox5.Text = gridView3.GetFocusedRowCellValue( "PQC07" ).ToString( );
                btch.textBox6.Text = gridView3.GetFocusedRowCellValue( "PQC14" ).ToString( );
                btch.textBox7.Text = gridView3.GetFocusedRowCellValue( "PQC03" ).ToString( );
                btch.textBox8.Text = gridView3.GetFocusedRowCellValue( "PQC11" ).ToString( );
                btch.textBox9.Text = gridView3.GetFocusedRowCellValue( "PQC06" ).ToString( );
                btch.StartPosition = FormStartPosition.CenterScreen;
                btch.ShowDialog( );
            }
            else
                MessageBox.Show( "没有数据,无法批量编辑" );
        }
        //批量删除
        private void button33_Click( object sender, EventArgs e )
        {

            if (gridView3.RowCount > 0)
            {
                btch.pl = "t3";
                btch.textBox1.Text = gridView3.GetFocusedRowCellValue( "PQC12" ).ToString( );
                btch.textBox2.Text = gridView3.GetFocusedRowCellValue( "PQC08" ).ToString( );
                btch.textBox3.Text = gridView3.GetFocusedRowCellValue( "PQC13" ).ToString( );
                btch.textBox4.Text = gridView3.GetFocusedRowCellValue( "PQC09" ).ToString( );
                btch.textBox5.Text = gridView3.GetFocusedRowCellValue( "PQC07" ).ToString( );
                btch.textBox6.Text = gridView3.GetFocusedRowCellValue( "PQC14" ).ToString( );
                btch.textBox7.Text = gridView3.GetFocusedRowCellValue( "PQC03" ).ToString( );
                btch.textBox8.Text = gridView3.GetFocusedRowCellValue( "PQC11" ).ToString( );
                btch.textBox9.Text = gridView3.GetFocusedRowCellValue( "PQC06" ).ToString( );
                btch.StartPosition = FormStartPosition.CenterScreen;
                btch.ShowDialog( );
            }
            else
                MessageBox.Show( "没有数据,无法批量删除" );
        }
        #endregion

        #region 滚漆
        private void comboBox64_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox64 );
        }
        private void comboBox64_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox64 );
        }
        private void comboBox64_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox64.Text != "" && !DateDayRegise.fiveForNum( comboBox64 ) )
            {
                this.comboBox64.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多一位,如9999.9,请重新输入" );
            }
        }
        private void comboBox63_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox63 );
        }
        private void comboBox63_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox63 );
        }
        private void comboBox63_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox63.Text != "" && !DateDayRegise.tenOneNumber( comboBox63 ) )
            {
                this.comboBox63.Text = "";
                MessageBox.Show( "只允许输入整数部分最多九位,小数部分最多一位,如999999999.9,请重新输入" );
            }
        }
        private void comboBox66_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox66 );
        }
        private void comboBox66_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox66 );
        }
        private void comboBox66_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox66.Text != "" && !DateDayRegise.sixThrNumberCb( comboBox66 ) )
            {
                this.comboBox66.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多三位,如999.999,请重新输入" );
            }
        }
        private void comboBox65_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox65 );
        }
        private void comboBox65_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox65 );
        }
        private void comboBox65_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox65.Text != "" && !DateDayRegise.sixThrNumberCb( comboBox65 ) )
            {
                this.comboBox65.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多三位,如999.999,请重新输入" );
            }
        }
        private void comboBox68_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox68 );
        }
        private void comboBox68_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox68 );
        }
        private void comboBox68_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox68.Text != "" && !DateDayRegise.sixThrNumberCb( comboBox68 ) )
            {
                this.comboBox68.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多三位,如999.999,请重新输入" );
            }
        }
        /*
        private void comboBox67_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox67 );
        }
        private void comboBox67_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox67 );
        }
        private void comboBox67_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox67.Text != "" && !DateDayRegise.sixThrNumberCb( comboBox67 ) )
            {
                this.comboBox67.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多三位,如999.999,请重新输入" );
            }
        }
        */
        private void gridView6_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView6.FocusedRowHandle >= 0 && gridView6.FocusedRowHandle <= gridView6.RowCount - 1 )
            {
                model.IDX = ( string.IsNullOrEmpty( gridView6.GetFocusedRowCellValue( "idx" ).ToString( ) ) ) == true ? 0 : Convert.ToInt32( gridView6.GetFocusedRowCellValue( "idx" ).ToString( ) );
                {
                    gridvAssing( );
                }
            }
        }
        void gridvAssing ( )
        {
            model = bll.GetModel( model.IDX );
            comboBox60.Text = model.KZ001;
            comboBox61.Text = model.KZ002;
            comboBox62.Text = model.KZ003;
            comboBox64.Text = model.KZ004.ToString( );
            comboBox63.Text = model.KZ005.ToString( );
            comboBox66.Text = model.KZ006.ToString( );
            comboBox65.Text = model.KZ007.ToString( );
            comboBox68.Text = model.KZ008.ToString( );
            //comboBox67.Text = model.KZ009.ToString( );
            comboBox69.Text = model.KZ010;
            comboBox70.Text = model.KZ011;
            comboBox67.Text = model.KZ012;
        }
        //Build
        DataRow row;
        void col ( )
        {
            row["KZ001"] = model.KZ001;
            row["KZ002"] = model.KZ002;
            row["KZ003"] = model.KZ003;
            row["KZ004"] = model.KZ004;
            row["KZ005"] = model.KZ005;
            row["KZ006"] = model.KZ006;
            row["KZ007"] = model.KZ007;
            row["KZ008"] = model.KZ008;
            //row["KZ009"] = model.KZ009;
            row["KZ010"] = model.KZ010;
            row["KZ011"] = model.KZ011;
            row["KZ012"] = model.KZ012;
        }
        void variable ( )
        {
            model.KZ001 = comboBox60.Text;
            model.KZ002 = comboBox61.Text;
            model.KZ003 = comboBox62.Text;
            model.KZ004 = string.IsNullOrEmpty( comboBox64.Text ) == true ? 0 : Convert.ToDecimal( comboBox64.Text );
            model.KZ005 = string.IsNullOrEmpty( comboBox63.Text ) == true ? 0 : Convert.ToDecimal( comboBox63.Text );
            model.KZ006 = string.IsNullOrEmpty( comboBox66.Text ) == true ? 0 : Convert.ToDecimal( comboBox66.Text );
            model.KZ007 = string.IsNullOrEmpty( comboBox65.Text ) == true ? 0 : Convert.ToDecimal( comboBox65.Text );
            model.KZ008 = string.IsNullOrEmpty( comboBox68.Text ) == true ? 0 : Convert.ToDecimal( comboBox68.Text );
            //model.KZ009 = string.IsNullOrEmpty( comboBox67.Text ) == true ? 0 : Convert.ToDecimal( comboBox67.Text );
            model.KZ010 = comboBox69.Text;
            model.KZ011 = comboBox70.Text;
            model.KZ012 = comboBox67.Text;
        }
        private void button42_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( comboBox60.Text ) )
            {
                MessageBox.Show( "色号与色板间不可为空" );
                return;
            }
            variable( );
            result = bll.Exists( model );
            if ( result == true )
            {
                MessageBox.Show( "已经存在\n\r色号与色板间:" + model.KZ001 + "\n\r油漆种类:" + model.KZ002 + "\n\r油漆品牌:" + model.KZ010 + "\n\r基材:" + model.KZ003 + "\n\r粒/斤:" + model.KZ004 + "\n\r油漆价格/kg:" + model.KZ005 + "\n\r滚漆成本计划价/斤:" + model.KZ006 + "\n\r滚漆工资计划价/斤:" + model.KZ007 + "\n\r委外价/斤:" + model.KZ008 + "\n\r零件规格:"+model.KZ011+ "\n\r零件体积区间cm³:" + model.KZ012 + "\n\r的记录" );
                return;
            }
            model.IDX = bll.Insert( model );
            if ( model.IDX > 0 )
            {
                MessageBox.Show( "成功录入数据" );
                row = pqkz.NewRow( );
                row["idx"] = model.IDX;
                col( );
                pqkz.Rows.Add( row );
            }
            else
                MessageBox.Show( "录入数据失败" );
        }
        //Edit
        private void button41_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( comboBox60.Text ) )
            {
                MessageBox.Show( "色号与色板间不可为空" );
                return;
            }
            variable( );
            result = bll.Exists( model );
            if ( result == true )
            {
                MessageBox.Show( "已经存在\n\r色号与色板间:" + model.KZ001 + "\n\r工价规格:" + model.KZ002 + "\n\r油漆品牌:" + model.KZ010 + "\n\r基材:" + model.KZ003 + "\n\r粒/斤:" + model.KZ004 + "\n\r油漆价格/kg:" + model.KZ005 + "\n\r滚漆成本计划价/斤:" + model.KZ006 + "\n\r滚漆工资计划价/斤:" + model.KZ007 + "\n\r委外价/斤:" + model.KZ008 + "\n\r零件规格:" + model.KZ011 + "\n\r零件体积区间cm³:" + model.KZ012 + "\n\r的记录" );
                return;
            }
            result = bll.Update( model );
            if ( result == true )
            {
                MessageBox.Show( "编辑数据成功" );
                row = pqkz.Rows[gridView6.FocusedRowHandle];
                row.BeginEdit( );
                col( );
                row.EndEdit( );
            }
            else
                MessageBox.Show( "编辑数据失败" );
        }
        //Delete
        private void button40_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==

            DialogResult . Cancel )
                return;
            result = bll.Delete( model.IDX );
            if ( result == true )
            {
                MessageBox.Show( "成功删除数据" );
                pqkz.Rows.RemoveAt( gridView6.FocusedRowHandle );
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        //Refresh
        private void button39_Click ( object sender ,EventArgs e )
        {
            pqkz = bll.GetDataTableGun( );
            gridControl6.DataSource = bll.GetDataTableGun( );
        }
        //BatchBuild
        private void button38_Click ( object sender ,EventArgs e )
        {
            SelectAll._519BatchGunQi batchGun = new SelectAll._519BatchGunQi( );
            batchGun.textBox1.Text = comboBox60.Text;
            batchGun.textBox2.Text = comboBox61.Text;
            batchGun.textBox3.Text = comboBox62.Text;
            batchGun.textBox4.Text = comboBox65.Text;
            batchGun.textBox5.Text = comboBox66.Text;
            batchGun.sign = "Build";
            batchGun.StartPosition = FormStartPosition.CenterScreen;
            batchGun.ShowDialog( );
        }
        //BatchEdit
        private void button37_Click ( object sender ,EventArgs e )
        {
            SelectAll._519BatchGunQi batchGun = new SelectAll._519BatchGunQi( );
            batchGun.textBox1.Text = comboBox60.Text;
            batchGun.textBox2.Text = comboBox61.Text;
            batchGun.textBox3.Text = comboBox62.Text;
            batchGun.textBox4.Text = comboBox65.Text;
            batchGun.textBox5.Text = comboBox66.Text;
            batchGun.sign = "Edit";
            batchGun.StartPosition = FormStartPosition.CenterScreen;
            batchGun.ShowDialog( );
        }
        //BatchDelete
        private void button36_Click ( object sender ,EventArgs e )
        {
            //SelectAll._519BatchGunQi batchGun = new SelectAll._519BatchGunQi( );
            //batchGun.textBox1.Text = comboBox60.Text;
            //batchGun.textBox2.Text = comboBox61.Text;
            //batchGun.textBox3.Text = comboBox62.Text;
            //batchGun.textBox4.Text = comboBox65.Text;
            //batchGun.textBox5.Text = comboBox66.Text;
            //batchGun.sign = "Delete";
            //batchGun.StartPosition = FormStartPosition.CenterScreen;
            //batchGun.ShowDialog( );

            if ( string . IsNullOrEmpty ( comboBox69 . Text ) )
            {
                MessageBox . Show ( "确认删除?" );
                return;
            }

            if ( !string . IsNullOrEmpty ( comboBox69 . Text ) )
            {
                if ( MessageBox . Show ( "确认删除油漆品牌是" + comboBox69 . Text + "的所有记录?" ,"删除" ,MessageBoxButtons . OKCancel ) != DialogResult . OK )
                    return;

            }
            result = bll . barchDelete ( comboBox69 . Text );
            if ( result )
            {
                MessageBox . Show ( "成功删除" );
                return;
            }
            else
                MessageBox . Show ( "删除失败" );
        }
        #endregion

        #region 化学品辅料
        private void button43_Click ( object sender ,EventArgs e )
        {
            SelectAll.YouqiBomAll query = new SelectAll.YouqiBomAll( );
            query.StartPosition = FormStartPosition.CenterScreen;
            query.PassDataBetweenForm += new SelectAll.YouqiBomAll.PassDataBetweenFormHandler( query_PassDataBetweenForm );
            query.ShowDialog( );
        }
        private void query_PassDataBetweenForm ( object sender ,PassDataWinFormEventArgs e )
        {
            textBox1.Text = e.ConOne;
        }
        private void comboBox78_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.fractionCb( e ,comboBox78 );
        }
        private void comboBox78_TextChanged ( object sender ,EventArgs e )
        {
            DateDayRegise.textChangeCb( comboBox78 );
        }
        private void comboBox78_LostFocus ( object sender ,EventArgs e )
        {
            if ( comboBox78.Text != "" && !DateDayRegise.sixTwoNumberCb( comboBox78 ) )
            {
                this.comboBox78.Text = "";
                MessageBox.Show( "只允许输入整数部分最多四位,小数部分最多两位,如9999.99, 请重新输入" );
            }
        }
        void asignVariable ( )
        {
            _model.AS001 = textBox1.Text;
            _model.AS002 = comboBox71.Text;
            _model.AS003 = comboBox72.Text;
            _model.AS004 = comboBox73.Text;
            _model.AS005 = comboBox74.Text;
            _model.AS006 = comboBox76.Text;
            _model.AS007 = comboBox75.Text;
            _model.AS008 = comboBox77.Text;
            _model.AS009 = string.IsNullOrEmpty( comboBox78.Text ) == true ? 0 : Convert.ToDecimal( comboBox78.Text );
        }
        void rowEdit ( )
        {
            row["AS001"] = _model.AS001;
            row["AS002"] = _model.AS002;
            row["AS003"] = _model.AS003;
            row["AS004"] = _model.AS004;
            row["AS005"] = _model.AS005;
            row["AS006"] = _model.AS006;
            row["AS007"] = _model.AS007;
            row["AS008"] = _model.AS008;
            row["AS009"] = _model.AS009;
        }
        private void gridView7_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView7.FocusedRowHandle >= 0 && gridView7.DataRowCount - 1 >= gridView7.FocusedRowHandle )
            {
                _model.IDX = string.IsNullOrEmpty( gridView7.GetFocusedRowCellValue( "idx" ).ToString( ) ) == true ? 0 : Convert.ToInt32( gridView7.GetFocusedRowCellValue( "idx" ).ToString( ) );
                assign( );
            }
        }
        string supplier = "", names = "", brand = "", colors = "", colorName = "";
        void assign ( )
        {
            _model = bll.GetModelSupplie( _model.IDX );
            if ( _model == null )
                return;
            textBox1.Text = _model.AS001;
            comboBox71.Text = _model.AS002;
            comboBox72.Text = _model.AS003;
            comboBox73.Text = _model.AS004;
            comboBox74.Text = _model.AS005;
            comboBox76.Text = _model.AS006;
            comboBox75.Text = _model.AS007;
            comboBox77.Text = _model.AS008;
            comboBox78.Text = _model.AS009.ToString( );
            supplier = _model.AS001;
            names = _model.AS002;
            brand = _model.AS003;
            colors = _model.AS006;
            colorName = _model.AS007;
        }
        //Build
        private void button46_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "供应商不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox71.Text ) )
            {
                MessageBox.Show( "辅料名称不可为空" );
                return;
            }
            asignVariable( );
            result = bll.ExistsOfSupplie( _model );
            if ( result == true )
            {
                MessageBox.Show( "供应商:"+_model.AS001+ "\n\r辅料名称:"+_model.AS002+ "\n\r品牌:" + _model.AS003 + "\n\r色名:" + _model.AS006 + "\n\r色号:" + _model.AS007 + "的记录已经存在,请核实" );
                return;
            }
            _model.IDX = bll.AddOfSupplie( _model );
            if ( _model.IDX > 0 )
            {
                MessageBox.Show( "成功录入数据" );
                row = pqas.NewRow( );
                row["idx"] = _model.IDX;
                rowEdit( );
                pqas.Rows.Add( row );
            }
            else
                MessageBox.Show( "录入数据失败" );
        }
        //Edit
        void edit_su ( )
        {
            int num = gridView7.FocusedRowHandle;
            result = bll.UpdateOfSupplie( _model );
            if ( result == true )
            {
                MessageBox.Show( "编辑数据成功" );
                row = pqas.Rows[num];
                row.BeginEdit( );
                rowEdit( );
                row.EndEdit( );
            }
            else
                MessageBox.Show( "编辑数据失败" );
        }
        private void button45_Click ( object sender ,EventArgs e )
        {
            if ( string.IsNullOrEmpty( textBox1.Text ) )
            {
                MessageBox.Show( "供应商不可为空" );
                return;
            }
            if ( string.IsNullOrEmpty( comboBox71.Text ) )
            {
                MessageBox.Show( "辅料名称不可为空" );
                return;
            }
            asignVariable( );
            if ( _model.AS001 == supplier && _model.AS002 == names && _model.AS003 == brand && _model.AS006 == colors && _model.AS007 == colorName )
                edit_su( );
            else
            {
                result = bll.ExistsOfSupplie( _model );
                if ( result == true )
                {
                    MessageBox.Show( "供应商:" + _model.AS001 + "\n\r辅料名称:" + _model.AS002 + "\n\r品牌:" + _model.AS003 + "\n\r色名:" + _model.AS006 + "\n\r色号:" + _model.AS007 + "的记录已经存在,请核实" );
                    return;
                }
                edit_su( );
            }
        }
        //Delete
        private void button44_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==

            DialogResult . Cancel )
                return;
            result = bll.DeleteOfSupplie( _model.IDX );
            if ( result == true )
            {
                MessageBox.Show( "删除数据成功" );
                pqas.Rows.RemoveAt( gridView7.FocusedRowHandle );
            }
            else
                MessageBox.Show( "删除数据失败" );
        }
        //Refresh
        private void button47_Click ( object sender ,EventArgs e )
        {
            pqas = bll.GetDataTablePqase( );
            gridControl7.DataSource = pqas;
        }
        #endregion

        #region 胶合板
        private void btnAdd_Click ( object sender ,EventArgs e )
        {
            if ( getValue ( ) == false )
                return;
            if ( bll . ExistsPQJB ( modelPqjb ) )
            {
                MessageBox . Show ( "已经存在规格标准:" + modelPqjb . QJB001 + "\n\r胶板品牌:" + modelPqjb . QJB002 + "\n\r胶板规格:" + modelPqjb . QJB003 + "\n\r层数:" + modelPqjb . QJB009 + "\n\r供应商:" + modelPqjb . QJB013 + "\n\r的数据,请核实" ,"提示" );
                return;
            }
            modelPqjb . idx = 0;
            modelPqjb . idx = bll . AddPQJB ( modelPqjb );
            if ( modelPqjb . idx > 0 )
            {
                MessageBox . Show ( "新增成功" );
                DataRow row = pqjb . NewRow ( );
                row [ "idx" ] = modelPqjb . idx;
                columnView ( row );
                pqjb . Rows . Add ( row );
                gridControl8 . RefreshDataSource ( );
                txtQJB001 . Tag = null;
            }
            else
                MessageBox . Show ( "新增失败" );
        }
        private void btnEdit_Click ( object sender ,EventArgs e )
        {
            if ( getValue ( ) == false )
                return;
            if ( modelPqjb . idx < 1 )
            {
                MessageBox . Show ( "请选择需要编辑的内容" );
                return;
            }
            if ( bll . ExistsPQJBEdit ( modelPqjb ) )
            {
                MessageBox . Show ( "已经存在规格标准:" + modelPqjb . QJB001 + "\n\r胶板品牌:" + modelPqjb . QJB002 + "\n\r胶板规格:" + modelPqjb . QJB003 + "\n\r层数:" + modelPqjb . QJB009 + "\n\r供应商:" + modelPqjb . QJB013 + "\n\r的数据,请核实" ,"提示" );
                return;
            }
            result = bll . EditPQJB ( modelPqjb );
            if ( result )
            {
                MessageBox . Show ( "成功编辑" );
                DataRow row = pqjb . Rows [ selectIdx ];
                row . BeginEdit ( );
                columnView ( row );
                row . EndEdit ( );
                gridControl8 . RefreshDataSource ( );
            }
            else
                MessageBox . Show ( "编辑失败,请重试" );

        }
        private void btnDelete_Click ( object sender ,EventArgs e )
        {
            if ( txtQJB001 . Tag == null )
                modelPqjb . idx = 0;
            else
                modelPqjb . idx = Convert . ToInt32 ( txtQJB001 . Tag );
            if ( modelPqjb . idx < 1 )
            {
                MessageBox . Show ( "请选择需要删除的数据" );
                return;
            }
            result = bll . DeletePQJB ( modelPqjb . idx );
            if ( result )
            {
                MessageBox . Show ( "成功删除" );
                pqjb . Rows . RemoveAt ( selectIdx );
                gridControl8 . RefreshDataSource ( );
            }
            else
                MessageBox . Show ( "删除失败" );

        }
        private void btnRef_Click ( object sender ,EventArgs e )
        {
            pqjb = bll . getTable ( );
            gridControl8 . DataSource = pqjb;
        }
        bool getValue ( )
        {
            if ( string . IsNullOrEmpty ( txtQJB001 . Text ) )
            {
                MessageBox . Show ( "请选择规格标准" );
                return false;
            }
            modelPqjb . QJB001 = txtQJB001 . Text;
            if ( string . IsNullOrEmpty ( txtQJB002 . Text ) )
            {
                MessageBox . Show ( "请选择品牌" );
                return false;
            }
            modelPqjb . QJB002 = txtQJB002 . Text;
            if ( string . IsNullOrEmpty ( txtQJB003 . Text ) )
            {
                MessageBox . Show ( "请填写或选择规格" );
                return false;
            }
            modelPqjb . QJB003 = txtQJB003 . Text;
            decimal outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtQJB004 . Text ) && decimal . TryParse ( txtQJB004 . Text ,out outResult ) == false )
            {
                MessageBox . Show ( "双清必须是数字" );
                return false;
            }
            modelPqjb . QJB004 = outResult;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtQJB005 . Text ) && decimal . TryParse ( txtQJB005 . Text ,out outResult ) == false )
            {
                MessageBox . Show ( "单整必须是数字" );
                return false;
            }
            modelPqjb . QJB005 = outResult;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtQJB006 . Text ) && decimal . TryParse ( txtQJB006 . Text ,out outResult ) == false )
            {
                MessageBox . Show ( "双整必须是数字" );
                return false;
            }
            modelPqjb . QJB006 = outResult;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtQJB007 . Text ) && decimal . TryParse ( txtQJB007 . Text ,out outResult ) == false )
            {
                MessageBox . Show ( "元/m3必须是数字" );
                return false;
            }
            modelPqjb . QJB007 = outResult;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtQJB008 . Text ) && decimal . TryParse ( txtQJB008 . Text ,out outResult ) == false )
            {
                MessageBox . Show ( "m³/张必须是数字" );
                return false;
            }
            modelPqjb . QJB008 = outResult;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtQJB009 . Text ) && decimal . TryParse ( txtQJB009 . Text ,out outResult ) == false )
            {
                MessageBox . Show ( "层数必须是数字" );
                return false;
            }
            modelPqjb . QJB009 = outResult;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtQJB010 . Text ) && decimal . TryParse ( txtQJB010 . Text ,out outResult ) == false )
            {
                MessageBox . Show ( "厚度必须是数字" );
                return false;
            }
            modelPqjb . QJB010 = outResult;
            modelPqjb . QJB011 = txtQJB011 . Text;
            modelPqjb . QJB012 = txtQJB012 . Text;
            if ( string . IsNullOrEmpty ( txtQJB013 . Text ) )
            {
                MessageBox . Show ( "请选择供应商" );
                return false;
            }
            modelPqjb . QJB013 = txtQJB013 . Text;
            modelPqjb . QJB014 = txtQJB014 . Text;
            modelPqjb . QJB015 = txtQJB015. Text;
            modelPqjb . QJB016 = txtQJB016 . Text;
            modelPqjb . QJB017 = txtQJB017 . Text;
            modelPqjb . QJB018 = txtQJB018 . Text;
            modelPqjb . QJB019 = txtQJB019 . Text;
            if ( txtQJB001 . Tag == null )
                modelPqjb . idx = 0;
            else
                modelPqjb . idx = Convert . ToInt32 ( txtQJB001 . Tag );

            return true;
        }
        void columnView ( DataRow row )
        {
            row [ "QJB001" ] = modelPqjb . QJB001;
            row [ "QJB002" ] = modelPqjb . QJB002;
            row [ "QJB003" ] = modelPqjb . QJB003;
            row [ "QJB004" ] = modelPqjb . QJB004;
            row [ "QJB005" ] = modelPqjb . QJB005;
            row [ "QJB006" ] = modelPqjb . QJB006;
            row [ "QJB007" ] = modelPqjb . QJB007;
            row [ "QJB008" ] = modelPqjb . QJB008;
            row [ "QJB009" ] = modelPqjb . QJB009;
            row [ "QJB010" ] = modelPqjb . QJB010;
            row [ "QJB011" ] = modelPqjb . QJB011;
            row [ "QJB012" ] = modelPqjb . QJB012;
            row [ "QJB013" ] = modelPqjb . QJB013;
            row [ "QJB014" ] = modelPqjb . QJB014;
            row [ "QJB015" ] = modelPqjb . QJB015;
            row [ "QJB016" ] = modelPqjb . QJB016;
            row [ "QJB017" ] = modelPqjb . QJB017;
            row [ "QJB018" ] = modelPqjb . QJB018;
            row [ "QJB019" ] = modelPqjb . QJB019;
        }
        private void gridView8_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            selectIdx = gridView8 . FocusedRowHandle;
            if ( selectIdx < 0 )
                return;
            DataRow row = gridView8 . GetDataRow ( selectIdx );
            txtQJB001 . Tag = row [ "idx" ] . ToString ( );
            txtQJB001 . Text = row [ "QJB001" ] . ToString ( );
            txtQJB002 . Text = row [ "QJB002" ] . ToString ( );
            txtQJB003 . Text = row [ "QJB003" ] . ToString ( );
            txtQJB004 . Text = row [ "QJB004" ] . ToString ( );
            txtQJB005 . Text = row [ "QJB005" ] . ToString ( );
            txtQJB006 . Text = row [ "QJB006" ] . ToString ( );
            txtQJB007 . Text = row [ "QJB007" ] . ToString ( );
            txtQJB008 . Text = row [ "QJB008" ] . ToString ( );
            txtQJB009 . Text = row [ "QJB009" ] . ToString ( );
            txtQJB010 . Text = row [ "QJB010" ] . ToString ( );
            txtQJB011 . Text = row [ "QJB011" ] . ToString ( );
            txtQJB012 . Text = row [ "QJB012" ] . ToString ( );
            txtQJB013 . Text = row [ "QJB013" ] . ToString ( );
            txtQJB014 . Text = row [ "QJB014" ] . ToString ( );
            txtQJB015 . Text = row [ "QJB015" ] . ToString ( );
            txtQJB016 . Text = row [ "QJB016" ] . ToString ( );
            txtQJB017 . Text = row [ "QJB017" ] . ToString ( );
            txtQJB018 . Text = row [ "QJB018" ] . ToString ( );
            txtQJB019 . Text = row [ "QJB019" ] . ToString ( );
        }
        private void txtQJB013_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = View . GetFocusedDataRow ( );
            if ( row == null )
                return;
            txtQJB014 . Text = row [ "DGA003" ] . ToString ( );
            txtQJB015 . Text = row [ "DGA017" ] . ToString ( );
            txtQJB016 . Text = row [ "DGA008" ] . ToString ( );
            txtQJB017 . Text = row [ "DGA012" ] . ToString ( );
            txtQJB018 . Text = row [ "DGA009" ] . ToString ( );
            txtQJB019 . Text = row [ "DGA011" ] . ToString ( );
        }
        private void txtQJB003_LostFocus ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtQJB003 . Text ) )
                return;
            if ( !txtQJB003 . Text . Contains ( "*" ) )
                return;
            string [ ] str = txtQJB003 . Text . Split ( '*' );
            if ( str . Length < 3 )
                return;
            txtQJB008 . Text = ( Convert . ToDecimal ( str [ 0 ] ) * Convert . ToDecimal ( str [ 1 ] ) * Convert . ToDecimal ( str [ 2 ] ) * Convert . ToDecimal ( 0.000001 ) ) . ToString ( );
        }
        #endregion

        #region 密度板
        private void btnA_Click ( object sender ,EventArgs e )
        {
            if ( getValueMD ( ) == false )
                return;
            if ( bll . ExistsPQMD ( modelPqmd ) )
            {
                MessageBox . Show ( "已经存在规格标准:" + modelPqmd . QMD001 + "\n\r品牌:" + modelPqmd . QMD002 + "\n\r规格:" + modelPqmd . QMD003 + "\n\r供应商:"+modelPqmd.QMD012+"\n\r的数据,请核实" ,"提示" );
                return;
            }
            modelPqmd . idx = 0;
            modelPqmd . idx = bll . AddPQMD ( modelPqmd );
            if ( modelPqmd . idx > 0 )
            {
                MessageBox . Show ( "新增成功" );
                DataRow row = pqmd . NewRow ( );
                row [ "idx" ] = modelPqmd . idx;
                columnViewMD ( row );
                pqmd . Rows . Add ( row );
                gridControl9 . RefreshDataSource ( );
                txtQMD001 . Tag = null;
            }
            else
                MessageBox . Show ( "新增失败" );

        }
        private void btnE_Click ( object sender ,EventArgs e )
        {
            if ( getValueMD ( ) == false )
                return;
            if ( modelPqmd . idx < 1 )
            {
                MessageBox . Show ( "请选择需要编辑的内容" );
                return;
            }
            if ( bll . ExistsPQMDE ( modelPqmd ) )
            {
                MessageBox . Show ( "已经存在规格标准:" + modelPqmd . QMD001 + "\n\r品牌:" + modelPqmd . QMD002 + "\n\r规格:" + modelPqmd . QMD003 + "\n\r供应商:" + modelPqmd . QMD012 + "\n\r的数据,请核实" ,"提示" );
                return;
            }
            result = bll . EditPQMD ( modelPqmd );
            if ( result )
            {
                MessageBox . Show ( "成功编辑" );
                DataRow row = pqmd . Rows [ selectIdxMd ];
                row . BeginEdit ( );
                columnViewMD ( row );
                row . EndEdit ( );
                gridControl9 . RefreshDataSource ( );
            }
            else
                MessageBox . Show ( "编辑失败,请重试" );
        }
        private void btnD_Click ( object sender ,EventArgs e )
        {
            if ( txtQMD001 . Tag == null )
                modelPqmd . idx = 0;
            else
                modelPqmd . idx = Convert . ToInt32 ( txtQMD001 . Tag );
            if ( modelPqmd . idx < 1 )
            {
                MessageBox . Show ( "请选择需要删除的数据" );
                return;
            }
            result = bll . DeletePQMD ( modelPqmd . idx );
            if ( result )
            {
                MessageBox . Show ( "成功删除" );
                pqmd . Rows . RemoveAt ( selectIdxMd );
                gridControl9 . RefreshDataSource ( );
            }
            else
                MessageBox . Show ( "删除失败" );
        }
        private void btnR_Click ( object sender ,EventArgs e )
        {
            pqmd = bll . getTableMd ( );
            gridControl9 . DataSource = pqmd;
        }
        private void txtQMD012_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = View1 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            txtQMD013 . Text = row [ "DGA003" ] . ToString ( );
            txtQMD014 . Text = row [ "DGA017" ] . ToString ( );
            txtQMD015 . Text = row [ "DGA008" ] . ToString ( );
            txtQMD016 . Text = row [ "DGA012" ] . ToString ( );
            txtQMD017 . Text = row [ "DGA009" ] . ToString ( );
            txtQMD018 . Text = row [ "DGA011" ] . ToString ( );
        }
        private void gridView9_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            selectIdxMd = gridView9 . FocusedRowHandle;
            if ( selectIdxMd < 0 )
                return;
            DataRow row = gridView9 . GetDataRow ( selectIdxMd );
            txtQMD001 . Tag = row [ "idx" ] . ToString ( );
            txtQMD001 . Text = row [ "QMD001" ] . ToString ( );
            txtQMD002 . Text = row [ "QMD002" ] . ToString ( );
            txtQMD003 . Text = row [ "QMD003" ] . ToString ( );
            //txtQMD004 . Text = row [ "QMD004" ] . ToString ( );
            //txtQMD005 . Text = row [ "QMD005" ] . ToString ( );
            txtQMD006 . Text = row [ "QMD006" ] . ToString ( );
            txtQMD007 . Text = row [ "QMD007" ] . ToString ( );
            txtQMD008 . Text = row [ "QMD008" ] . ToString ( );
            txtQMD009 . Text = row [ "QMD009" ] . ToString ( );
            txtQMD010 . Text = row [ "QMD010" ] . ToString ( );
            txtQMD011 . Text = row [ "QMD011" ] . ToString ( );
            txtQMD012 . Text = row [ "QMD012" ] . ToString ( );
            txtQMD013 . Text = row [ "QMD013" ] . ToString ( );
            txtQMD014 . Text = row [ "QMD014" ] . ToString ( );
            txtQMD015 . Text = row [ "QMD015" ] . ToString ( );
            txtQMD016 . Text = row [ "QMD016" ] . ToString ( );
            txtQMD017 . Text = row [ "QMD017" ] . ToString ( );
            txtQMD018 . Text = row [ "QMD018" ] . ToString ( );
        }
        bool  getValueMD ( )
        {
            if ( string . IsNullOrEmpty ( txtQMD001 . Text ) )
            {
                MessageBox . Show ( "请选择规格标准" );
                return false;
            }
            modelPqmd . QMD001 = txtQMD001 . Text;
            if ( string . IsNullOrEmpty ( txtQMD002 . Text ) )
            {
                MessageBox . Show ( "请选择品牌" );
                return false;
            }
            modelPqmd . QMD002 = txtQMD002 . Text;
            if ( string . IsNullOrEmpty ( txtQMD003 . Text ) )
            {
                MessageBox . Show ( "请填写或选择规格" );
                return false;
            }
            modelPqmd . QMD003 = txtQMD003 . Text;
            decimal outResult = 0M;
            //if ( !string . IsNullOrEmpty ( txtQMD004 . Text ) && decimal . TryParse ( txtQMD004 . Text ,out outResult ) == false )
            //{
            //    MessageBox . Show ( "E0必须是数字" );
            //    return false;
            //}
            modelPqmd . QMD004 = 0;
            //outResult = 0M;
            //if ( !string . IsNullOrEmpty ( txtQMD005 . Text ) && decimal . TryParse ( txtQMD005 . Text ,out outResult ) == false )
            //{
            //    MessageBox . Show ( "E1必须是数字" );
            //    return false;
            //}
            modelPqmd . QMD005 = 0;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtQMD006 . Text ) && decimal . TryParse ( txtQMD006 . Text ,out outResult ) == false )
            {
                MessageBox . Show ( "元/m3必须是数字" );
                return false;
            }
            modelPqmd . QMD006 = outResult;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtQMD007 . Text ) && decimal . TryParse ( txtQMD007 . Text ,out outResult ) == false )
            {
                MessageBox . Show ( "m3/张必须是数字" );
                return false;
            }
            modelPqmd . QMD007 = outResult;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtQMD008 . Text ) && decimal . TryParse ( txtQMD008 . Text ,out outResult ) == false )
            {
                MessageBox . Show ( "密度数必须是数字" );
                return false;
            }
            modelPqmd . QMD008 = outResult;
            modelPqmd . QMD009 = txtQMD009 . Text;
            modelPqmd . QMD010 = txtQMD010 . Text;
            modelPqmd . QMD011 = txtQMD011 . Text;
            if ( string . IsNullOrEmpty ( txtQMD012 . Text ) )
            {
                MessageBox . Show ( "请选择供应商" );
                return false;
            }
            modelPqmd . QMD012 = txtQMD012 . Text;
            modelPqmd . QMD013 = txtQMD013 . Text;
            modelPqmd . QMD014 = txtQMD014 . Text;
            modelPqmd . QMD015 = txtQMD015 . Text;
            modelPqmd . QMD016 = txtQMD016 . Text;
            modelPqmd . QMD017 = txtQMD017 . Text;
            modelPqmd . QMD018 = txtQMD018 . Text;


            if ( txtQMD001 . Tag == null )
                modelPqmd . idx = 0;
            else
                modelPqmd . idx = Convert . ToInt32 ( txtQMD001 . Tag );

            return true;
        }
        void columnViewMD ( DataRow row )
        {
            row [ "QMD001" ] = modelPqmd . QMD001;
            row [ "QMD002" ] = modelPqmd . QMD002;
            row [ "QMD003" ] = modelPqmd . QMD003;
            row [ "QMD004" ] = modelPqmd . QMD004;
            row [ "QMD005" ] = modelPqmd . QMD005;
            row [ "QMD006" ] = modelPqmd . QMD006;
            row [ "QMD007" ] = modelPqmd . QMD007;
            row [ "QMD008" ] = modelPqmd . QMD008;
            row [ "QMD009" ] = modelPqmd . QMD009;
            row [ "QMD010" ] = modelPqmd . QMD010;
            row [ "QMD011" ] = modelPqmd . QMD011;
            row [ "QMD012" ] = modelPqmd . QMD012;
            row [ "QMD013" ] = modelPqmd . QMD013;
            row [ "QMD014" ] = modelPqmd . QMD014;
            row [ "QMD015" ] = modelPqmd . QMD015;
            row [ "QMD016" ] = modelPqmd . QMD016;
            row [ "QMD017" ] = modelPqmd . QMD017;
            row [ "QMD018" ] = modelPqmd . QMD018;
        }
        private void txtQMD003_LostFocus ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtQMD003 . Text ) )
                return;
            if ( !txtQMD003 . Text . Contains ( "*" ) )
                return;
            string [ ] str = txtQMD003 . Text . Split ( '*' );
            if ( str . Length < 3 )
                return;
            txtQMD007 . Text = ( Convert . ToDecimal ( str [ 0 ] ) * Convert . ToDecimal ( str [ 1 ] ) * Convert . ToDecimal ( str [ 2 ] ) * Convert . ToDecimal ( 0.000001 ) ) . ToString ( );
        }
        #endregion

    }
}
