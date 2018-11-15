using Mulaolao . Class;
using StudentMgr;
using System;
using System . Collections . Generic;
using System . Data;
using System . Data . SqlClient;
using System . Drawing;
using System . IO;
using System . Windows . Forms;
using Mulaolao . Other;
using Mulaolao . Contract;
using Mulaolao . Base;
using Mulaolao . Raw_material_cost;
using FastReport;
using FastReport . Export . Xml;
using MulaolaoBll;

namespace Mulaolao.Procedure
{
    public partial class R_FrmProductarchives : FormChild
    {        
        public R_FrmProductarchives(/*Form fm*/ )
        {
            //this.MdiParent = fm;
            InitializeComponent();

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . gridView1 } );
            UserInfoMation . tableName = this . Name;
        }
        R_FrmImageAmplication ima = new R_FrmImageAmplication();
        //R_FrmCpda fc = new R_FrmCpda();
        GroupBox[] gb;
        DataTable sele;
        List<CheckBox> cbx = new List<CheckBox>( );
        private DataSet ADataSet;
        Report report = new Report( );

        private void R_FrmProductarchives_Load(object sender, EventArgs e)
        {
            Power( this );

            Ergodic.FormEvery( this );

            gb = new GroupBox[] { groupBox1,groupBox2,groupBox3,groupBox4,groupBox6,groupBox7,groupBox8,groupBox9,groupBox10,groupBox11,groupBox12,groupBox13,groupBox14,groupBox15,groupBox16,groupBox17,groupBox18};
            Ergodic.FormGroupboxEnableFalse( this, gb );
            textBox18.Enabled = false;

            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = btn1.Enabled = btn10.Enabled = btn11.Enabled = btn12.Enabled = btn13.Enabled = btn14.Enabled = btn15.Enabled = btn16.Enabled = btn17.Enabled = btn18.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = btn5.Enabled = btn6.Enabled = btn7.Enabled = btn8.Enabled = btn9.Enabled = button8.Enabled = button9.Enabled = button12.Enabled = false;

            #region
            DataTable dse = SqlHelper.ExecuteDataTable( "SELECT CP028, CP075, CP076, CP078, CP079, CP080, CP081, CP082, CP083, CP084, CP085, CP086, CP087, CP088, CP089, CP090, CP091, CP092, CP093, CP094, CP095, CP096, CP097, CP166,CP098, CP099, CP167, CP100, CP101, CP168, CP102, CP103, CP169, CP104, CP105, CP170, CP106, CP107, CP171, CP108, CP109, CP172, CP110, CP111, CP128, CP129, CP130, CP131,CP132, CP133, CP134, CP135, CP136, CP137, CP138, CP139, CP140, CP141, CP142, CP143, CP144, CP145, CP146, CP147, CP153, CP154 FROM R_PQM" );
            //输入国
            DataTable srg = dse.DefaultView.ToTable( true, "CP153" );
            comboBox2.DataSource = srg;
            comboBox2.DisplayMember = "CP153";
            //含水率
            DataTable hsl = dse.DefaultView.ToTable( true, "CP154" );
            comboBox1.DataSource = hsl;
            comboBox1.DisplayMember = "CP154";
            //AQL
            DataTable aql = dse.DefaultView.ToTable( true, "CP028" );
            comboBox59.DataSource = aql;
            comboBox59.DisplayMember = "CP028";
            //条形码1
            DataTable t1 = dse.DefaultView.ToTable( true, "CP075" );
            comboBox3.DataSource = t1;
            comboBox3.DisplayMember = "CP075";
            //条形码2
            DataTable t2 = dse.DefaultView.ToTable( true, "CP076" );
            comboBox3.DataSource = t2;
            comboBox3.DisplayMember = "CP076";
            //CE1
            DataTable ce1 = dse.DefaultView.ToTable( true, "CP078" );
            comboBox4.DataSource = ce1;
            comboBox4.DisplayMember = "CP078";
            //CE2
            DataTable ce2 = dse.DefaultView.ToTable( true, "CP079" );
            comboBox9.DataSource = ce2;
            comboBox9.DisplayMember = "CP079";
            //环保1
            DataTable hb1 = dse.DefaultView.ToTable( true, "CP080" );
            comboBox6.DataSource = hb1;
            comboBox6.DisplayMember = "CP080";
            //环保2
            DataTable hb2 = dse.DefaultView.ToTable( true, "CP081" );
            comboBox13.DataSource = hb2;
            comboBox13.DisplayMember = "CP081";
            //FSC1
            DataTable fsc1 = dse.DefaultView.ToTable( true, "CP082" );
            comboBox25.DataSource = fsc1;
            comboBox25.DisplayMember = "CP082";
            //FSC2
            DataTable fsc2 = dse.DefaultView.ToTable( true, "CP083" );
            comboBox24.DataSource = fsc2;
            comboBox24.DisplayMember = "CP083";
            //MADE1
            DataTable mad1 = dse.DefaultView.ToTable( true, "CP084" );
            comboBox15.DataSource = mad1;
            comboBox15.DisplayMember = "CP084";
            //MADE2
            DataTable mad2 = dse.DefaultView.ToTable( true, "CP085" );
            comboBox18.DataSource = mad2;
            comboBox18.DisplayMember = "CP085";
            //圆形标1
            DataTable yxb1 = dse.DefaultView.ToTable( true, "CP086" );
            comboBox5.DataSource = yxb1;
            comboBox5.DisplayMember = "CP086";
            //圆形标2
            DataTable yxb2 = dse.DefaultView.ToTable( true, "CP087" );
            comboBox11.DataSource = yxb2;
            comboBox11.DisplayMember = "CP087";
            //价格标签1
            DataTable jgb1 = dse.DefaultView.ToTable( true, "CP088" );
            comboBox16.DataSource = jgb1;
            comboBox16.DisplayMember = "CP088";
            //价格标签2
            DataTable jgb2 = dse.DefaultView.ToTable( true, "CP089" );
            comboBox23.DataSource = jgb2;
            comboBox23.DisplayMember = "CP089";
            //防霉标1
            DataTable fm1 = dse.DefaultView.ToTable( true, "CP090" );
            comboBox19.DataSource = fm1;
            comboBox19.DisplayMember = "CP090";
            //防霉标2
            DataTable fm2 = dse.DefaultView.ToTable( true, "CP091" );
            comboBox22.DataSource = fm2;
            comboBox22.DisplayMember = "CP091";
            //批次标1
            DataTable pc1 = dse.DefaultView.ToTable( true, "CP092" );
            comboBox14.DataSource = pc1;
            comboBox14.DisplayMember = "CP092";
            //批次标2
            DataTable pc2 = dse.DefaultView.ToTable( true, "CP093" );
            comboBox21.DataSource = pc2;
            comboBox21.DisplayMember = "CP093";
            //防伪标1
            DataTable fw1 = dse.DefaultView.ToTable( true, "CP094" );
            comboBox17.DataSource = fw1;
            comboBox17.DisplayMember = "CP094";
            //防伪标2
            DataTable fw2 = dse.DefaultView.ToTable( true, "CP095" );
            comboBox20.DataSource = fw2;
            comboBox20.DisplayMember = "CP095";
            //警告标1
            DataTable jg1 = dse.DefaultView.ToTable( true, "CP096" );
            comboBox7.DataSource = jg1;
            comboBox7.DisplayMember = "CP096";
            //警告标2
            DataTable jg2 = dse.DefaultView.ToTable( true, "CP097" );
            comboBox12.DataSource = jg2;
            comboBox12.DisplayMember = "CP097";
            //新增1
            DataTable xz1 = dse.DefaultView.ToTable( true, "CP166" );
            comboBox65.DataSource = xz1;
            comboBox65.DisplayMember = "CP166";
            //新增1-1
            DataTable xz11 = dse.DefaultView.ToTable( true, "CP098" );
            comboBox31.DataSource = xz11;
            comboBox31.DisplayMember = "CP098";
            //新增1-2
            DataTable xz12 = dse.DefaultView.ToTable( true, "CP099" );
            comboBox30.DataSource = xz12;
            comboBox30.DisplayMember = "CP099";
            //新增2
            DataTable xz2 = dse.DefaultView.ToTable( true, "CP167" );
            comboBox60.DataSource = xz2;
            comboBox60.DisplayMember = "CP167";
            //新增2-1
            DataTable xz21 = dse.DefaultView.ToTable( true, "CP100" );
            comboBox27.DataSource = xz21;
            comboBox27.DisplayMember = "CP100";
            //新增2-2
            DataTable xz22 = dse.DefaultView.ToTable( true, "CP101" );
            comboBox26.DataSource = xz22;
            comboBox26.DisplayMember = "CP101";
            //新增3
            DataTable xz3 = dse.DefaultView.ToTable( true, "CP168" );
            comboBox63.DataSource = xz3;
            comboBox63.DisplayMember = "CP168";
            //新增3-1
            DataTable xz31 = dse.DefaultView.ToTable( true, "CP102" );
            comboBox33.DataSource = xz31;
            comboBox33.DisplayMember = "CP102";
            //新增3-2
            DataTable xz32 = dse.DefaultView.ToTable( true, "CP103" );
            comboBox32.DataSource = xz32;
            comboBox32.DisplayMember = "CP103";
            //新增4
            DataTable xz4 = dse.DefaultView.ToTable( true, "CP169" );
            comboBox64.DataSource = xz4;
            comboBox64.DisplayMember = "CP169";
            //新增4-1
            DataTable xz41 = dse.DefaultView.ToTable( true, "CP104" );
            comboBox54.DataSource = xz41;
            comboBox54.DisplayMember = "CP104";
            //新增4-2
            DataTable xz42 = dse.DefaultView.ToTable( true, "CP105" );
            comboBox10.DataSource = xz42;
            comboBox10.DisplayMember = "CP105";
            //新增5
            DataTable xz5 = dse.DefaultView.ToTable( true, "CP170" );
            comboBox61.DataSource = xz5;
            comboBox61.DisplayMember = "CP170";
            //新增5-1
            DataTable xz51 = dse.DefaultView.ToTable( true, "CP106" );
            comboBox29.DataSource = xz51;
            comboBox29.DisplayMember = "CP106";
            //新增5-2
            DataTable xz52 = dse.DefaultView.ToTable( true, "CP107" );
            comboBox28.DataSource = xz52;
            comboBox28.DisplayMember = "CP107";
            //新增6
            DataTable xz6 = dse.DefaultView.ToTable( true, "CP171" );
            comboBox62.DataSource = xz6;
            comboBox62.DisplayMember = "CP171";
            //新增6-1
            DataTable xz61 = dse.DefaultView.ToTable( true, "CP108" );
            comboBox56.DataSource = xz61;
            comboBox56.DisplayMember = "CP108";
            //新增6-2
            DataTable xz62 = dse.DefaultView.ToTable( true, "CP109" );
            comboBox55.DataSource = xz62;
            comboBox55.DisplayMember = "CP109";
            //新增7
            DataTable xz7 = dse.DefaultView.ToTable( true, "CP172" );
            comboBox66.DataSource = xz7;
            comboBox66.DisplayMember = "CP172";
            //新增7-1
            DataTable xz71 = dse.DefaultView.ToTable( true, "CP110" );
            comboBox58.DataSource = xz71;
            comboBox58.DisplayMember = "CP110";
            //新增7-2
            DataTable xz72 = dse.DefaultView.ToTable( true, "CP111" );
            comboBox57.DataSource = xz72;
            comboBox57.DisplayMember = "CP111";
            //说明1张数
            DataTable s1z = dse.DefaultView.ToTable( true, "CP128" );
            comboBox34.DataSource = s1z;
            comboBox34.DisplayMember = "CP128";
            //说明书1纸张尺寸
            DataTable s1c = dse.DefaultView.ToTable( true, "CP129" );
            comboBox35.DataSource = s1c;
            comboBox35.DisplayMember = "CP129";
            //说明书1材质要求
            DataTable s1y = dse.DefaultView.ToTable( true, "CP130" );
            comboBox36.DataSource = s1y;
            comboBox36.DisplayMember = "CP130";
            //说明书1工艺
            DataTable s1g = dse.DefaultView.ToTable( true, "CP131" );
            comboBox37.DataSource = s1g;
            comboBox37.DisplayMember = "CP131";
            //说明书1颜色
            DataTable s1s = dse.DefaultView.ToTable( true, "CP132" );
            comboBox38.DataSource = s1s;
            comboBox38.DisplayMember = "CP132";
            //说明2张数
            DataTable s2z = dse.DefaultView.ToTable( true, "CP133" );
            comboBox43.DataSource = s2z;
            comboBox43.DisplayMember = "CP133";
            //说明书2纸张尺寸
            DataTable s2c = dse.DefaultView.ToTable( true, "CP134" );
            comboBox42.DataSource = s2c;
            comboBox42.DisplayMember = "CP134";
            //说明书2材质要求
            DataTable s2y = dse.DefaultView.ToTable( true, "CP135" );
            comboBox41.DataSource = s2y;
            comboBox41.DisplayMember = "CP135";
            //说明书2工艺
            DataTable s2g = dse.DefaultView.ToTable( true, "CP136" );
            comboBox40.DataSource = s2g;
            comboBox40.DisplayMember = "CP136";
            //说明书2颜色
            DataTable s2s = dse.DefaultView.ToTable( true, "CP137" );
            comboBox39.DataSource = s2s;
            comboBox39.DisplayMember = "CP137";
            //说明3张数
            DataTable s3z = dse.DefaultView.ToTable( true, "CP138" );
            comboBox48.DataSource = s3z;
            comboBox48.DisplayMember = "CP138";
            //说明书3纸张尺寸
            DataTable s3c = dse.DefaultView.ToTable( true, "CP139" );
            comboBox47.DataSource = s3c;
            comboBox47.DisplayMember = "CP139";
            //说明书3材质要求
            DataTable s3y = dse.DefaultView.ToTable( true, "CP140" );
            comboBox46.DataSource = s3y;
            comboBox46.DisplayMember = "CP140";
            //说明书3工艺
            DataTable s3g = dse.DefaultView.ToTable( true, "CP141" );
            comboBox45.DataSource = s3g;
            comboBox45.DisplayMember = "CP141";
            //说明书3颜色
            DataTable s3s = dse.DefaultView.ToTable( true, "CP142" );
            comboBox44.DataSource = s3s;
            comboBox44.DisplayMember = "CP142";
            //说明4张数
            DataTable s4z = dse.DefaultView.ToTable( true, "CP143" );
            comboBox53.DataSource = s4z;
            comboBox53.DisplayMember = "CP143";
            //说明书4纸张尺寸
            DataTable s4c = dse.DefaultView.ToTable( true, "CP144" );
            comboBox52.DataSource = s4c;
            comboBox52.DisplayMember = "CP144";
            //说明书4材质要求
            DataTable s4y = dse.DefaultView.ToTable( true, "CP145" );
            comboBox51.DataSource = s4y;
            comboBox51.DisplayMember = "CP145";
            //说明书4工艺
            DataTable s4g = dse.DefaultView.ToTable( true, "CP146" );
            comboBox50.DataSource = s4g;
            comboBox50.DisplayMember = "CP146";
            //说明书4颜色
            DataTable s4s = dse.DefaultView.ToTable( true, "CP147" );
            comboBox49.DataSource = s4s;
            comboBox49.DisplayMember = "CP147";
            #endregion
        }

        private void R_FrmProductarchives_Shown ( object sender ,EventArgs e )
        {
            CP001 = Merges.oddNum;
            if ( !string.IsNullOrEmpty( CP001 ) )
                autoQuery( );
            Merges.oddNum = "";
        }

        #region 打印 导出
        private void CreateDateSet( )
        {
            ADataSet = new DataSet( );
            CP001 = textB1.Text;
            DataTable print = SqlHelper.ExecuteDataTable( "SELECT PQF03,PQF04,DFA002,CP003,CP004,CP005,CP006,CP009,CP007,CP008,CP011,CP012,CP014,CP015,CP016,CP026,CP027,CP028,CP029,CP031,CP032, CP033, CP034, CP035, CP036, CP037, CP039, CP040, CP041, CP043, CP044, CP045, CP047, CP048, CP049, CP051, CP052, CP053, CP055,CP056, CP057, CP059, CP060, CP061, CP062, CP063, CP064, CP065, CP066, CP067, CP068, CP069, CP070, CP071, CP072, CP073, CP074, CP075, CP076, CP078, CP079,CP080, CP081, CP082, CP083, CP084, CP085, CP086, CP087, CP088, CP089, CP090, CP091, CP092, CP093, CP094, CP095, CP096, CP097, CP166, CP098, CP099, CP167, CP100, CP101,CP168, CP102, CP103, CP169, CP104, CP105, CP170, CP106, CP107, CP171, CP108, CP109, CP172, CP110, CP111, CP112, CP113, CP114, CP115, CP116, CP117, CP118, CP119,CP120, CP121, CP122, CP123, CP124, CP125, CP126, CP127, CP128, CP129, CP130, CP131, CP132, CP133, CP134, CP135, CP136, CP137, CP138, CP139, CP140, CP141, CP142, CP143,CP144, CP145, CP146, CP147, CP148, CP149, CP150, CP151, CP152, CP153, CP154, CP155,CP160,CP161,CP162,CP163,CP164,CP165,CP173,CP174,CP175 FROM R_PQM A, R_PQF B, TPADFA C WHERE A.CP001 = B.PQF01 AND B.PQF11 = C.DFA001 AND CP001=@CP001", new SqlParameter( "@CP001", CP001 ) );
            DataTable wl = SqlHelper.ExecuteDataTable( "SELECT CP156,CP157,CP158,CP159 FROM R_PQM WHERE CP001=@CP001", new SqlParameter( "@CP001", CP001 ) );
            print.TableName = "R_PQM";
            wl.TableName = "R_PQMS";
            ADataSet.Tables.Add( print );
            ADataSet.Tables.Add( wl );
        }
        #endregion

        #region 事件
        //流水号
        private void textB1_TextChanged( object sender, EventArgs e )
        {
            DataTable dlk = SqlHelper.ExecuteDataTable( "SELECT PQF03,PQF04,PQF11,DFA002 FROM R_PQF A,TPADFA B WHERE A.PQF11=B.DFA001 AND PQF01=@PQF01", new SqlParameter( "@PQF01", CP001 ) );
            if (dlk.Rows.Count < 1)
                MessageBox.Show( "没有流水号：" + CP001 + "的产品信息" );
            else
            {
                textB2.Text = dlk.Rows[0]["PQF04"].ToString( );
                textBox1.Text = dlk.Rows[0]["PQF03"].ToString( );
                textBox11.Text= dlk.Rows[0]["DFA002"].ToString( );
            }
        }
        //EN71
        private void che1_CheckedChanged( object sender, EventArgs e )
        {
            if (che1.Checked)
            {
                cbx.Add( che1 );
                if (cbx.Count > 2)
                {
                    foreach (CheckBox cb in cbx)
                    {
                        cb.Checked = false;
                    }
                    cbx.Clear( );
                    checkBox30.Checked = true;
                }
            }
        }
        //ASTM F963
        private void che2_CheckedChanged( object sender, EventArgs e )
        {
            if (che2.Checked)
            {
                cbx.Add( che2 );
                if (cbx.Count > 2)
                {
                    foreach (CheckBox cb in cbx)
                    {
                        cb.Checked = false;
                    }
                    cbx.Clear( );
                    checkBox30.Checked = true;
                }
            }
        }
        //ST2012
        private void che3_CheckedChanged( object sender, EventArgs e )
        {
            if (che3.Checked)
            {
                cbx.Add( che3 );
                if (cbx.Count > 2)
                {
                    foreach (CheckBox cb in cbx)
                    {
                        cb.Checked = false;
                    }
                    cbx.Clear( );
                    checkBox30.Checked = true;
                }
            }
        }
        //GB6675
        private void che4_CheckedChanged( object sender, EventArgs e )
        {
            if (che4.Checked)
            {
                cbx.Add( che4 );
                if (cbx.Count > 2)
                {
                    foreach (CheckBox cb in cbx)
                    {
                        cb.Checked = false;
                    }
                    cbx.Clear( );
                    checkBox30.Checked = true;
                }
            }
        }
        //全球
        private void checkBox30_CheckedChanged( object sender, EventArgs e )
        {
            if (checkBox30.Checked)
                che1.Checked = che2.Checked = che3.Checked = che4.Checked = che1.Enabled = che2.Enabled = che3.Enabled = che4.Enabled = false;
            else
                che1.Enabled = che2.Enabled = che3.Enabled = che4.Enabled = true;
        }
        //表格
        string cp056 = "", cp057 = "";
        private void gridView1_Click( object sender, EventArgs e )
        {
            if (gridView1.RowCount == 1)
            {
                textBox12.Text = gridView1.GetFocusedRowCellValue( "CP156" ).ToString( );
                textBox16.Text = gridView1.GetFocusedRowCellValue( "CP157" ).ToString( );
                textBox17.Text = gridView1.GetFocusedRowCellValue( "CP158" ).ToString( );
                cp056 = textBox12.Text;
                cp057 = textBox16.Text;
            }
        }
        private void gridView1_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (gridView1.RowCount < 1)
                Ergodic.GroupboxEvery( groupBox18 );
            else
            {
                textBox12.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "CP156" ).ToString( );
                textBox16.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "CP157" ).ToString( );
                textBox17.Text = gridView1.GetRowCellValue( e.FocusedRowHandle, "CP158" ).ToString( );
                cp056 = textBox12.Text;
                cp057 = textBox16.Text;
            }
        }
        //窗体关闭
        private void R_FrmProductarchives_FormClosing( object sender, FormClosingEventArgs e )
        {
            if (toolSave.Enabled)
            {
                cancel( );
            }                
        }
        //天地盖
        private void textB17_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //中包
        private void textB18_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        //大箱
        private void textB19_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textB25_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textB25 );
        }
        private void textB26_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textB26 );
        }
        private void textB27_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.fractionTb( e ,textB27 );
        }
        private void comboBox53_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void comboBox48_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void comboBox43_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void comboBox34_KeyPress( object sender, KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        #endregion

        #region 主体
        string sav = "", weihu = "";
        string CP001 = "", CP009 = "", CP007 = "", CP008 = "", CP011 = "", CP012 = "", CP014 = "", CP015 = "", CP016 = "", CP026 = "", CP027 = "", CP028 = "", CP029 = "", CP030 = "", CP031 = "", CP032 = "", CP033 = "", CP034 = "", CP035 = "", CP036 = "", CP037 = "", CP038 = "", CP039 = "", CP040 = "", CP041 = "", CP042 = "", CP043 = "", CP044 = "", CP045 = "", CP046 = "", CP047 = "", CP048 = "", CP049 = "", CP050 = "", CP051 = "", CP052 = "", CP053 = "", CP054 = "", CP055 = "", CP056 = "", CP057 = "", CP058 = "", CP059 = "", CP060 = "", CP061 = "", CP062 = "", CP063 = "", CP064 = "", CP065 = "", CP066 = "", CP067 = "", CP068 = "", CP069 = "", CP070 = "", CP071 = "", CP075 = "", CP076 = "", CP078 = "", CP079 = "", CP080 = "", CP081 = "", CP082 = "", CP083 = "", CP084 = "", CP085 = "", CP086 = "", CP087 = "", CP088 = "", CP089 = "", CP090 = "", CP091 = "", CP092 = "", CP093 = "", CP094 = "", CP095 = "", CP096 = "", CP097 = "", CP098 = "", CP099 = "", CP100 = "", CP101 = "", CP102 = "", CP103 = "", CP104 = "", CP105 = "", CP106 = "", CP107 = "", CP108 = "", CP109 = "", CP110 = "", CP111 = "", CP112 = "", CP113 = "", CP114 = "", CP116 = "", CP117 = "", CP118 = "", CP120 = "", CP121 = "", CP122 = "", CP124 = "", CP125 = "", CP126 = "", CP127 = "", CP129 = "", CP130 = "", CP131 = "", CP132 = "", CP134 = "", CP135 = "", CP136 = "", CP137 = "", CP139 = "", CP140 = "", CP141 = "", CP142 = "", CP144 = "", CP145 = "", CP146 = "", CP147 = "", CP152 = "", CP153 = "", CP154 = "", CP155 = "", CP0156 = "", CP0157 = "", CP0159 = "", CP166 = "", CP167 = "", CP168 = "", CP169 = "", CP170 = "", CP171 = "", CP172 = "", CP160 = "", CP161 = "", CP162 = "", CP163 = "", CP164 = "", CP165 = "", CP173 = "", CP174 = "", CP175 = "", CP176 = "", CP177 = "";

        int CP072 = 0, CP073 = 0, CP074 = 0, CP128 = 0, CP133 = 0, CP138 = 0, CP143 = 0, CP0158 = 0;
        decimal CP115 = 0M, CP119 = 0M, CP123 = 0M;
        //新增
        protected override void add( )
        {
            base.add( );
            Ergodic.FormGroupboxEnableTrue( this, gb );
            textBox18.Enabled = false;

            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = btn1.Enabled = btn10.Enabled = btn11.Enabled = btn12.Enabled = btn13.Enabled = btn14.Enabled = btn15.Enabled = btn16.Enabled = btn17.Enabled = btn18.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = btn5.Enabled = btn6.Enabled = btn7.Enabled = btn8.Enabled = btn9.Enabled = button8.Enabled = button9.Enabled = button12.Enabled = true;
            sav = "1";   
        }
        //删除
        protected override void delete ( )
        {
            base . delete ( );

            CP001 = textB1 . Text;
            DataTable del = SqlHelper . ExecuteDataTable ( "SELECT * FROM R_REVIEWS A,R_MLLCXMC B WHERE A.RES01=B.CX01 AND RES05='执行' AND RES06=@RES06 AND CX02=@CX02 " ,new SqlParameter ( "@RES06" ,CP001 ) ,new SqlParameter ( "@CX02" ,this . Text ) );

            if ( del != null && del . Rows . Count > 0 )
                MessageBox . Show ( "流水号:" + CP001 + "的单据状态为执行,不允许删除" );
            else
            {
                if ( CP001 == "" )
                    MessageBox . Show ( "请查询需要删除的信息" );
                else
                {
                    int count = SqlHelper . ExecuteNonQuery ( "DELETE FROM R_PQM WHERE CP001 =@CP001" ,new SqlParameter ( "@CP001" ,CP001 ) );
                    if ( count < 1 )
                    {
                        MessageBox . Show ( "数据删除失败" );
                    }
                    else
                    {
                        MessageBox . Show ( "成功删除数据" );

                        Ergodic . FormEvery ( this );
                        Ergodic . FormGroupboxEnableFalse ( this ,gb );
                        textBox18 . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolMaintain . Enabled = toolSave . Enabled = toolCancel . Enabled = false;
                        toolSelect . Enabled = toolAdd . Enabled = toolPrint . Enabled = toolExport . Enabled = true;
                        button1 . Enabled = button2 . Enabled = button3 . Enabled = button4 . Enabled = button5 . Enabled = button6 . Enabled = button7 . Enabled = btn1 . Enabled = btn10 . Enabled = btn11 . Enabled = btn12 . Enabled = btn13 . Enabled = btn14 . Enabled = btn15 . Enabled = btn16 . Enabled = btn17 . Enabled = btn18 . Enabled = btn2 . Enabled = btn3 . Enabled = btn4 . Enabled = btn5 . Enabled = btn6 . Enabled = btn7 . Enabled = btn8 . Enabled = btn9 . Enabled = button8 . Enabled = button9 . Enabled = button12 . Enabled = false;

                        try
                        {
                            SqlHelper . ExecuteNonQuery ( "DELETE FROM R_REVIEWS WHERE RES01=(SELECT CX01 FROM R_MLLCXMC WHERE CX02=@CX02) AND RES06=@RES06" ,new SqlParameter ( "@CX02" ,this . Text ) ,new SqlParameter ( "@RES06" ,CP001 ) );
                        }
                        catch { }
                    }
                }
            }
        }
        //更改
        protected override void update( )
        {
            base.update( );

            CP001 = textB1.Text;
            DataTable del = SqlHelper.ExecuteDataTable( "SELECT * FROM R_REVIEWS A,R_MLLCXMC B WHERE A.RES01=B.CX01 AND RES05='执行' AND RES06=@RES06 AND CX02=@CX02 ", new SqlParameter( "@RES06", CP001 ), new SqlParameter( "@CX02", this.Text ) );
            if (del != null && del.Rows.Count > 0)
                MessageBox.Show( "流水号:" + CP001 + "的单据状态为执行,不允许更改" );
            else
            {
                Ergodic.FormGroupboxEnableTrue( this, gb );

                textBox18.Enabled = false;

                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = false;
                toolSave.Enabled = toolCancel.Enabled = true;
                button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = btn1.Enabled = btn10.Enabled = btn11.Enabled = btn12.Enabled = btn13.Enabled = btn14.Enabled = btn15.Enabled = btn16.Enabled = btn17.Enabled = btn18.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = btn5.Enabled = btn6.Enabled = btn7.Enabled = btn8.Enabled = btn9.Enabled = button8.Enabled = button9.Enabled = button12.Enabled = false;
            }
        }
        //送审
        protected override void revirw( )
        {
            base.revirw( );

            Reviews( "CP001" ,textB1.Text ,"R_PQM" ,this ,"" ,"R_404" ,false ,false,MulaolaoBll . Drity . GetDt ( )/*,"" ,"" ,"" ,"" ,"" ,"" ,"","R_404"*/ ); 
        }
        //打印
        protected override void print( )
        {
            base.print( );
            CreateDateSet( );

            report.Load( Environment.CurrentDirectory + "\\cpdar_404.frx" );
            report.RegisterData( ADataSet );
            report.Show( );
            //report.Dispose( );
        }
        //导出
        protected override void export( )
        {
            base.export( );
            CreateDateSet( );

            report.Load( Environment.CurrentDirectory + "\\cpdar_404.frx" );
            report.RegisterData( ADataSet );
            report.Prepare( );
            XMLExport exprots = new XMLExport( );
            exprots.Export( report );
            //report.Dispose( );
        }
        //保存
        private void adds ( )
        {
            Ergodic.FormGroupboxEnableFalse( this ,gb );

            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = false;
            button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = btn1.Enabled = btn10.Enabled = btn11.Enabled = btn12.Enabled = btn13.Enabled = btn14.Enabled = btn15.Enabled = btn16.Enabled = btn17.Enabled = btn18.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = btn5.Enabled = btn6.Enabled = btn7.Enabled = btn8.Enabled = btn9.Enabled = button8.Enabled = button9.Enabled = button12.Enabled = false;
            textBox18.Enabled = false;
        }
        protected override void save( )
        {
            base.save( );

            if (CP001 == "")
                MessageBox.Show( "请选择流水号" );
            else
            {
                #region 产品图片 唛头  条形码 客户反馈
                CP009 = textBox10.Text;
                CP152 = textB31.Text;
                #endregion

                #region 产品要求 产品功能描述
                CP153 = comboBox2.Text;
                CP154 = comboBox1.Text;
                CP155 = textBox5.Text;
                if (che1.Checked)
                {
                    CP007 = "T";
                }
                if (che2.Checked)
                {
                    CP008 = "T";
                }
                if (che3.Checked)
                {
                    CP011 = "T";
                }
                if (che4.Checked)
                {
                    CP012 = "T";
                }
                if (checkBox30.Checked)
                {
                    CP014 = "T";
                }
                if (che5.Checked)
                {
                    CP015 = "T";
                }
                if (che6.Checked)
                {
                    CP016 = "T";
                }
                if (che7.Checked)
                {
                    CP026 = "T";
                }
                if (checkBox1.Checked)
                {
                    CP027 = textBox2.Text;
                }
                CP028 = comboBox59.Text;
                CP029 = textB7.Text;
                #endregion

                #region 材料类别  使用位置
                CP030 = label12.Text;
                CP031 = textB9.Text;
                if (checkBox12.Checked)
                {
                    CP032 = "T";
                }
                else
                {
                    CP032 = "F";
                }
                if (checkBox13.Checked)
                {
                    CP160 = "T";
                }
                else
                {
                    CP160 = "F";
                }
                CP033 = textBox14.Text;
                CP034 = label15.Text;
                CP035 = textB10.Text;
                if (checkBox14.Checked)
                {
                    CP036 = "T";
                }
                else
                {
                    CP036 = "F";
                }
                if (checkBox15.Checked)
                {
                    CP040 = "T";
                }
                else
                {
                    CP040 = "F";
                }
                if (checkBox16.Checked)
                {
                    CP161 = "T";
                }
                else
                {
                    CP161 = "F";
                }
                if (checkBox17.Checked)
                {
                    CP162 = "T";
                }
                else
                {
                    CP162 = "F";
                }
                CP037 = textBox15.Text;
                CP038 = label17.Text;
                CP039 = textB11.Text;
                CP041 = textBox15.Text;
                CP042 = label19.Text;
                CP043 = textB12.Text;
                CP044 = textBox3.Text;
                if (checkBox19.Checked)
                {
                    CP045 = "T";
                }
                else
                {
                    CP045 = "F";
                }
                if (checkBox18.Checked)
                {
                    CP163 = "T";
                }
                else
                {
                    CP163 = "F";
                }
                CP046 = label30.Text;
                CP047 = textB13.Text;
                CP048 = textBox4.Text;
                if (checkBox23.Checked)
                {
                    CP049 = "T";
                }
                else
                {
                    CP049 = "F";
                }
                if (checkBox22.Checked)
                {
                    CP146 = "T";
                }
                else
                {
                    CP146 = "F";
                }
                if (checkBox21.Checked)
                {
                    CP165 = "T";
                }
                else
                {
                    CP165 = "F";
                }
                if (checkBox20.Checked)
                {
                    CP173 = "T";
                }
                else
                {
                    CP173 = "F";
                }
                if (checkBox24.Checked)
                {
                    CP053 = "T";
                }
                else
                {
                    CP053 = "F";
                }
                if (checkBox25.Checked)
                {
                    CP174 = "T";
                }
                else
                {
                    CP174 = "F";
                }
                if (checkBox26.Checked)
                {
                    CP175 = "T";
                }
                else
                {
                    CP175 = "F";
                }
                CP050 = label32.Text;
                CP051 = textB14.Text;
                CP052 = textBox5.Text;
                CP054 = label32.Text;
                CP055 = textB15.Text;
                CP056 = textBox6.Text;
                CP057 = textBox8.Text;
                CP058 = label44.Text;
                CP059 = textB16.Text;
                CP060 = textBox7.Text;
                CP061 = textBox9.Text;
                #endregion

                #region 包装要求
                if (che35.Checked)
                {
                    CP062 = "T";
                }
                if (che36.Checked)
                {
                    CP063 = "T";
                }
                if (che37.Checked)
                {
                    CP064 = "T";
                }
                if (che38.Checked)
                {
                    CP065 = "T";
                }
                if (che39.Checked)
                {
                    CP066 = "T";
                }
                if (che40.Checked)
                {
                    CP067 = "T";
                }
                if (che41.Checked)
                {
                    CP068 = "T";
                }
                if (che42.Checked)
                {
                    CP069 = "T";
                }
                if (checkBox2.Checked)
                {
                    CP070 = "T";
                }
                if (checkBox3.Checked)
                {
                    CP072 = Convert.ToInt32( textB17.Text );
                }
                else
                {
                    checkBox2.Checked = false;
                }
                if (textB18.Text != "")
                {
                    CP073 = Convert.ToInt32( textB18.Text );
                }
                else
                {
                    CP073 = 0;
                }
                if (textB19.Text != "")
                {
                    CP074 = Convert.ToInt32( textB19.Text );
                }
                else
                {
                    CP074 = 0;
                }
                if (che43.Checked)
                {
                    CP075 = comboBox3.Text;
                    CP076 = comboBox8.Text;
                }
                if (che44.Checked)
                {
                    CP078 = comboBox4.Text;
                    CP079 = comboBox9.Text;
                }
                if (che45.Checked)
                {
                    CP080 = comboBox6.Text;
                    CP081 = comboBox13.Text;
                }
                if (checkBox6.Checked)
                {
                    CP082 = comboBox25.Text;
                    CP083 = comboBox24.Text;
                }
                if (che48.Checked)
                {
                    CP084 = comboBox15.Text;
                    CP085 = comboBox18.Text;
                }
                if (checkBox7.Checked)
                {
                    CP086 = comboBox5.Text;
                    CP087 = comboBox11.Text;
                }
                if (che49.Checked)
                {
                    CP088 = comboBox16.Text;
                    CP089 = comboBox23.Text;
                }
                if (checkBox5.Checked)
                {
                    CP090 = comboBox19.Text;
                    CP091 = comboBox22.Text;
                }
                if (che47.Checked)
                {
                    CP092 = comboBox14.Text;
                    CP093 = comboBox21.Text;
                }
                if (checkBox4.Checked)
                {
                    CP094 = comboBox17.Text;
                    CP095 = comboBox20.Text;
                }
                if (che46.Checked)
                {
                    CP096 = comboBox7.Text;
                    CP097 = comboBox12.Text;
                }               
                CP166 = comboBox65.Text;
                CP098 = comboBox31.Text;
                CP099 = comboBox30.Text;
                CP167 = comboBox60.Text;                
                CP100 = comboBox27.Text;
                CP101 = comboBox26.Text;
                CP168 = comboBox63.Text;
                CP102 = comboBox33.Text;
                CP103 = comboBox32.Text;
                CP169 = comboBox64.Text;            
                CP104 = comboBox54.Text;
                CP105 = comboBox10.Text;
                CP170 = comboBox61.Text;
                CP106 = comboBox29.Text;
                CP107 = comboBox28.Text;
                CP171 = comboBox62.Text;
                CP108 = comboBox56.Text;
                CP109 = comboBox55.Text;
                CP172 = comboBox66.Text;
                CP110 = comboBox58.Text;
                CP111 = comboBox57.Text;
                if (che61.Checked)
                {
                    CP112 = "T";
                }
                if (che62.Checked)
                {
                    CP113 = "T";
                }
                if (che63.Checked)
                {
                    CP114 = "T";
                }
                if (che64.Checked)
                {
                    CP115 = Convert.ToDecimal( textB25.Text );
                }
                if (che65.Checked)
                {
                    CP116 = "T";
                }
                if (che66.Checked)
                {
                    CP117 = "T";
                }
                if (che67.Checked)
                {
                    CP118 = "T";
                }
                if (che68.Checked)
                {
                    CP119 = Convert.ToDecimal( textB26.Text );
                }
                if (che69.Checked)
                {
                    CP120 = "T";
                }
                if (che70.Checked)
                {
                    CP121 = "T";
                }
                if (che71.Checked)
                {
                    CP122 = "T";
                }
                if (che72.Checked)
                {
                    CP123 = Convert.ToDecimal( textB27.Text );
                }
                if (che73.Checked)
                {
                    CP124 = "T";
                }
                if (che74.Checked)
                {
                    CP125 = "T";
                }
                if (che75.Checked)
                {
                    CP126 = "T";
                }
                if (che76.Checked)
                {
                    CP127 = textB28.Text;
                }
                if (comboBox34.Text != "")
                {
                    CP128 = Convert.ToInt32( comboBox34.Text );
                }
                else
                {
                    CP128 = 0;
                }
                CP129 = comboBox35.Text;
                CP130 = comboBox36.Text;
                CP131 = comboBox37.Text;
                CP132 = comboBox38.Text;
                if (comboBox43.Text != "")
                {
                    CP133 = Convert.ToInt32( comboBox43.Text );
                }
                else
                {
                    CP133 = 0;
                }
                CP134 = comboBox42.Text;
                CP135 = comboBox41.Text;
                CP136 = comboBox40.Text;
                CP137 = comboBox39.Text;
                if (comboBox48.Text != "")
                {
                    CP138 = Convert.ToInt32( comboBox48.Text );
                }
                else
                {
                    CP138 = 0;
                }
                CP139 = comboBox47.Text;
                CP140 = comboBox46.Text;
                CP141 = comboBox45.Text;
                CP142 = comboBox44.Text;
                if (comboBox53.Text != "")
                {
                    CP143 = Convert.ToInt32( comboBox53.Text );
                }
                else
                {
                    CP143 = 0;
                }
                CP144 = comboBox52.Text;
                CP145 = comboBox51.Text;
                CP146 = comboBox50.Text;
                CP147 = comboBox49.Text;
                #endregion

                CP176 = textBox18.Text;
                CP177 = "";

                DataTable dae = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQM WHERE CP001=@CP001", new SqlParameter( "@CP001", CP001 ) );
                if (weihu == "1")
                {
                    if (textBox18.Text == "")
                        MessageBox.Show( "请填写维护意见" );
                    else
                    {
                        if (dae.Rows.Count < 1)
                            MessageBox.Show( "没有流水号:" + CP001 + "的信息,请核实后再维护" );
                        else
                        {
                            CP177 = dae.Rows[0]["CP177"].ToString( ) + "[" + Logins.username + MulaolaoBll . Drity . GetDt ( ).ToString( "yyyyMMdd" ) + "]";
                            int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQM SET CP003=@CP003,CP004=@CP004,CP005=@CP005,CP006=@CP006,CP007=@CP007,CP008=@CP008,CP009=@CP009,CP011=@CP011,CP012=@CP012,CP014=@CP014,CP015=@CP015,CP016=@CP016,CP026=@CP026,CP027=@CP027,CP028=@CP028,CP029=@CP029,CP030=@CP030,CP031=@CP031,CP032=@CP032,CP033=@CP033,CP034=@CP034,CP035=@CP035,CP036=@CP036,CP037=@CP037,CP038=@CP038,CP039=@CP039,CP040=@CP040,CP041=@CP041,CP042=@CP042,CP043=@CP043,CP044=@CP044,CP045=@CP045,CP046=@CP046,CP047=@CP047,CP048=@CP048,CP049=@CP049,CP050=@CP050,CP051=@CP051,CP052=@CP052,CP053=@CP053,CP054=@CP054,CP055=@CP055, CP056=@CP056,CP057=@CP057,CP058=@CP058,CP059=@CP059,CP060=@CP060,CP061=@CP061,CP062=@CP062,CP063=@CP063,CP064=@CP064,CP065=@CP065,CP066=@CP066,CP067=@CP067,CP068=@CP068,CP069=@CP069,CP070=@CP070,CP071=@CP071,CP072=@CP072,CP073=@CP073,CP074=@CP074,CP075=@CP075,CP076=@CP076,CP078=@CP078,CP079=@CP079,CP080=@CP080,CP081=@CP081,CP082=@CP082,CP083=@CP083,CP084=@CP084,CP085=@CP085,CP086=@CP086,CP087=@CP087,CP088=@CP088,CP089=@CP089,CP090=@CP090,CP091=@CP091,CP092=@CP092,CP093=@CP093,CP094=@CP094,CP095=@CP095,CP096=@CP096,CP097=@CP097,CP098=@CP098,CP099=@CP099, CP100=@CP100,CP101=@CP101,CP102=@CP102,CP103=@CP103,CP104=@CP104,CP105=@CP105,CP106=@CP106,CP107=@CP107,CP108=@CP108,CP109=@CP109,CP110=@CP110,CP111=@CP111,CP112=@CP112,CP113=@CP113,CP114=@CP114,CP115=@CP115,CP116=@CP116,CP117=@CP117,CP118=@CP118,CP119=@CP119,CP120=@CP120,CP121=@CP121,CP122=@CP122,CP123=@CP123,CP124=@CP124,CP125=@CP125,CP126=@CP126,CP127=@CP127,CP128=@CP128,CP129=@CP129,CP130=@CP130,CP131=@CP131,CP132=@CP132,CP133=@CP133,CP134=@CP134,CP135=@CP135,CP136=@CP136,CP137=@CP137,CP138=@CP138,CP139=@CP139,CP140=@CP140,CP141=@CP141,CP142=@CP142,CP143=@CP143,CP144=@CP144,CP145=@CP145,CP146=@CP146,CP147=@CP147,CP148=@CP148,CP149=@CP149,CP150=@CP150,CP151=@CP151,CP152=@CP152,CP153=@CP153,CP154=@CP154,CP155=@CP155,CP166=@CP166,CP167=@CP167,CP168=@CP168,CP169=@CP169,CP170=@CP170,CP171=@CP171,CP172=@CP172,CP160=@CP160,CP161=@CP161,CP162=@CP162,CP163=@CP163,CP164=@CP164,CP165=@CP165,CP173=@CP173,CP174=@CP174,CP175=@CP175,CP176=@CP176,CP177=@CP177 WHERE CP001=@CP001" ,new SqlParameter( "@CP001" ,CP001 ) ,new SqlParameter( "@CP003" ,CP003 ) ,new SqlParameter( "@CP004" ,CP004 ) ,new SqlParameter( "@CP005" ,CP005 ) ,new SqlParameter( "@CP006" ,CP006 ) ,new SqlParameter( "@CP007" ,CP007 ) ,new SqlParameter( "@CP008" ,CP008 ) ,new SqlParameter( "@CP009" ,CP009 ) ,new SqlParameter( "@CP011" ,CP011 ) ,new SqlParameter( "@CP012" ,CP012 ) ,new SqlParameter( "@CP014" ,CP014 ) ,new SqlParameter( "@CP015" ,CP015 ) ,new SqlParameter( "@CP016" ,CP016 ) ,new SqlParameter( "@CP026" ,CP026 ) ,new SqlParameter( "@CP027" ,CP027 ) ,new SqlParameter( "@CP028" ,CP028 ) ,new SqlParameter( "@CP029" ,CP029 ) ,new SqlParameter( "@CP030" ,CP030 ) ,new SqlParameter( "@CP031" ,CP031 ) ,new SqlParameter( "@CP032" ,CP032 ) ,new SqlParameter( "@CP033" ,CP033 ) ,new SqlParameter( "@CP034" ,CP034 ) ,new SqlParameter( "@CP035" ,CP035 ) ,new SqlParameter( "@CP036" ,CP036 ) ,new SqlParameter( "@CP037" ,CP037 ) ,new SqlParameter( "@CP038" ,CP038 ) ,new SqlParameter( "@CP039" ,CP039 ) ,new SqlParameter( "@CP040" ,CP040 ) ,new SqlParameter( "@CP041" ,CP041 ) ,new SqlParameter( "@CP042" ,CP042 ) ,new SqlParameter( "@CP043" ,CP043 ) ,new SqlParameter( "@CP044" ,CP044 ) ,new SqlParameter( "@CP045" ,CP045 ) ,new SqlParameter( "@CP046" ,CP046 ) ,new SqlParameter( "@CP047" ,CP047 ) ,new SqlParameter( "@CP048" ,CP048 ) ,new SqlParameter( "@CP049" ,CP049 ) ,new SqlParameter( "@CP050" ,CP050 ) ,new SqlParameter( "@CP051" ,CP051 ) ,new SqlParameter( "@CP052" ,CP052 ) ,new SqlParameter( "@CP053" ,CP053 ) ,new SqlParameter( "@CP054" ,CP054 ) ,new SqlParameter( "@CP055" ,CP055 ) ,new SqlParameter( "@CP056" ,CP056 ) ,new SqlParameter( "@CP057" ,CP057 ) ,new SqlParameter( "@CP058" ,CP058 ) ,new SqlParameter( "@CP059" ,CP059 ) ,new SqlParameter( "@CP060" ,CP060 ) ,new SqlParameter( "@CP061" ,CP061 ) ,new SqlParameter( "@CP062" ,CP062 ) ,new SqlParameter( "@CP063" ,CP063 ) ,new SqlParameter( "@CP064" ,CP064 ) ,new SqlParameter( "@CP065" ,CP065 ) ,new SqlParameter( "@CP066" ,CP066 ) ,new SqlParameter( "@CP067" ,CP067 ) ,new SqlParameter( "@CP068" ,CP068 ) ,new SqlParameter( "@CP069" ,CP069 ) ,new SqlParameter( "@CP070" ,CP070 ) ,new SqlParameter( "@CP071" ,CP071 ) ,new SqlParameter( "@CP072" ,CP072 ) ,new SqlParameter( "@CP073" ,CP073 ) ,new SqlParameter( "@CP074" ,CP074 ) ,new SqlParameter( "@CP075" ,CP075 ) ,new SqlParameter( "@CP076" ,CP076 ) ,new SqlParameter( "@CP078" ,CP078 ) ,new SqlParameter( "@CP079" ,CP079 ) ,new SqlParameter( "@CP080" ,CP080 ) ,new SqlParameter( "@CP081" ,CP081 ) ,new SqlParameter( "@CP082" ,CP082 ) ,new SqlParameter( "@CP083" ,CP083 ) ,new SqlParameter( "@CP084" ,CP084 ) ,new SqlParameter( "@CP085" ,CP085 ) ,new SqlParameter( "@CP086" ,CP086 ) ,new SqlParameter( "@CP087" ,CP087 ) ,new SqlParameter( "@CP088" ,CP088 ) ,new SqlParameter( "@CP089" ,CP089 ) ,new SqlParameter( "@CP090" ,CP090 ) ,new SqlParameter( "@CP091" ,CP091 ) ,new SqlParameter( "@CP092" ,CP092 ) ,new SqlParameter( "@CP093" ,CP093 ) ,new SqlParameter( "@CP094" ,CP094 ) ,new SqlParameter( "@CP095" ,CP095 ) ,new SqlParameter( "@CP096" ,CP096 ) ,new SqlParameter( "@CP097" ,CP097 ) ,new SqlParameter( "@CP098" ,CP098 ) ,new SqlParameter( "@CP099" ,CP099 ) ,new SqlParameter( "@CP100" ,CP100 ) ,new SqlParameter( "@CP101" ,CP101 ) ,new SqlParameter( "@CP102" ,CP102 ) ,new SqlParameter( "@CP103" ,CP103 ) ,new SqlParameter( "@CP104" ,CP104 ) ,new SqlParameter( "@CP105" ,CP105 ) ,new SqlParameter( "@CP106" ,CP106 ) ,new SqlParameter( "@CP107" ,CP107 ) ,new SqlParameter( "@CP108" ,CP108 ) ,new SqlParameter( "@CP109" ,CP109 ) ,new SqlParameter( "@CP110" ,CP110 ) ,new SqlParameter( "@CP111" ,CP111 ) ,new SqlParameter( "@CP112" ,CP112 ) ,new SqlParameter( "@CP113" ,CP113 ) ,new SqlParameter( "@CP114" ,CP114 ) ,new SqlParameter( "@CP115" ,CP115 ) ,new SqlParameter( "@CP116" ,CP116 ) ,new SqlParameter( "@CP117" ,CP117 ) ,new SqlParameter( "@CP118" ,CP118 ) ,new SqlParameter( "@CP119" ,CP119 ) ,new SqlParameter( "@CP120" ,CP120 ) ,new SqlParameter( "@CP121" ,CP121 ) ,new SqlParameter( "@CP122" ,CP122 ) ,new SqlParameter( "@CP123" ,CP123 ) ,new SqlParameter( "@CP124" ,CP124 ) ,new SqlParameter( "@CP125" ,CP125 ) ,new SqlParameter( "@CP126" ,CP126 ) ,new SqlParameter( "@CP127" ,CP127 ) ,new SqlParameter( "@CP128" ,CP128 ) ,new SqlParameter( "@CP129" ,CP129 ) ,new SqlParameter( "@CP130" ,CP130 ) ,new SqlParameter( "@CP131" ,CP131 ) ,new SqlParameter( "@CP132" ,CP132 ) ,new SqlParameter( "@CP133" ,CP133 ) ,new SqlParameter( "@CP134" ,CP134 ) ,new SqlParameter( "@CP135" ,CP135 ) ,new SqlParameter( "@CP136" ,CP136 ) ,new SqlParameter( "@CP137" ,CP137 ) ,new SqlParameter( "@CP138" ,CP138 ) ,new SqlParameter( "@CP139" ,CP139 ) ,new SqlParameter( "@CP140" ,CP140 ) ,new SqlParameter( "@CP141" ,CP141 ) ,new SqlParameter( "@CP142" ,CP142 ) ,new SqlParameter( "@CP143" ,CP143 ) ,new SqlParameter( "@CP144" ,CP144 ) ,new SqlParameter( "@CP145" ,CP145 ) ,new SqlParameter( "@CP146" ,CP146 ) ,new SqlParameter( "@CP147" ,CP147 ) ,new SqlParameter( "@CP148" ,CP148 ) ,new SqlParameter( "@CP149" ,CP149 ) ,new SqlParameter( "@CP150" ,CP150 ) ,new SqlParameter( "@CP151" ,CP151 ) ,new SqlParameter( "@CP152" ,CP152 ) ,new SqlParameter( "@CP153" ,CP153 ) ,new SqlParameter( "@CP154" ,CP154 ) ,new SqlParameter( "@CP155" ,CP155 ) ,new SqlParameter( "@CP166" ,CP166 ) ,new SqlParameter( "@CP167" ,CP167 ) ,new SqlParameter( "@CP168" ,CP168 ) ,new SqlParameter( "@CP169" ,CP169 ) ,new SqlParameter( "@CP170" ,CP170 ) ,new SqlParameter( "@CP171" ,CP171 ) ,new SqlParameter( "@CP172" ,CP172 ) ,new SqlParameter( "@CP160" ,CP160 ) ,new SqlParameter( "@CP161" ,CP161 ) ,new SqlParameter( "@CP162" ,CP162 ) ,new SqlParameter( "@CP163" ,CP163 ) ,new SqlParameter( "@CP164" ,CP164 ) ,new SqlParameter( "@CP165" ,CP165 ) ,new SqlParameter( "@CP173" ,CP173 ) ,new SqlParameter( "@CP174" ,CP174 ) ,new SqlParameter( "@CP175" ,CP175 ) ,new SqlParameter( "@CP176" ,CP176 ) ,new SqlParameter( "@CP177" ,CP177 ) );
                            if (count < 1)
                                MessageBox.Show( "录入数据失败" );
                            else
                            {
                                MessageBox.Show( "成功录入数据" );
                                adds( );
                            }
                        }
                    }
                }
                else
                {
                    if (dae.Rows.Count < 1)
                    {
                        int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQM (CP001,CP003,CP004,CP005,CP006,CP009,CP007,CP008, CP011,CP012,CP014,CP015,CP016,CP026,CP027,CP028,CP029,CP030,CP031,CP032,CP033,CP034,CP035,CP036,CP037,CP038,CP039,CP040,CP041,CP042,CP043,CP044,CP045,CP046,CP047,CP048,CP049,CP050,CP051,CP052,CP053,CP054,CP055,CP056,CP057,CP058,CP059,CP060,CP061,CP062,CP063,CP064,CP065,CP066,CP067,CP068,CP069,CP070,CP071,CP072,CP073,CP074,CP075,CP076, CP078,CP079,CP080,CP081,CP082,CP083,CP084,CP085,CP086,CP087,CP088,CP089,CP090,CP091,CP092,CP093,CP094,CP095,CP096,CP097,CP098,CP099,CP100,CP101,CP102,CP103,CP104,CP105,CP106,CP107,CP108,CP109,CP110,CP111,CP112,CP113,CP114,CP115,CP116,CP117,CP118,CP119,CP120,CP121,CP122,CP123,CP124,CP125,CP126,CP127,CP128,CP129,CP130,CP131,CP132,CP133,CP134,CP135,CP136,CP137,CP138,CP139,CP140,CP141,CP142,CP143,CP144,CP145,CP146,CP147,CP148,CP149,CP150,CP151,CP152,CP153,CP154,CP155,CP166,CP167,CP168,CP169,CP170,CP171,CP172,CP160,CP161,CP162,CP163,CP164,CP165,CP173,CP174,CP175,CP176,CP177) VALUES (@CP001,@CP003,@CP004,@CP005,@CP006,@CP009,@CP007,@CP008,@CP011,@CP012,@CP014,@CP015,@CP016,@CP026,@CP027,@CP028,@CP029,@CP030,@CP031,@CP032,@CP033,@CP034,@CP035,@CP036,@CP037,@CP038,@CP039,@CP040,@CP041,@CP042,@CP043,@CP044,@CP045,@CP046,@CP047,@CP048,@CP049,@CP050,@CP051,@CP052,@CP053,@CP054,@CP055,@CP056,@CP057,@CP058,@CP059,@CP060,@CP061,@CP062,@CP063,@CP064,@CP065,@CP066,@CP067,@CP068,@CP069,@CP070,@CP071,@CP072,@CP073,@CP074,@CP075,@CP076,@CP078,@CP079,@CP080,@CP081,@CP082,@CP083,@CP084,@CP085,@CP086,@CP087,@CP088,@CP089,@CP090,@CP091,@CP092,@CP093,@CP094,@CP095,@CP096,@CP097,@CP098,@CP099,@CP100,@CP101,@CP102,@CP103,@CP104,@CP105,@CP106,@CP107,@CP108,@CP109,@CP110,@CP111,@CP112,@CP113,@CP114,@CP115,@CP116,@CP117,@CP118,@CP119,@CP120,@CP121,@CP122,@CP123,@CP124,@CP125,@CP126,@CP127,@CP128,@CP129,@CP130,@CP131,@CP132,@CP133,@CP134,@CP135,@CP136,@CP137,@CP138,@CP139,@CP140,@CP141,@CP142,@CP143,@CP144,@CP145,@CP146,@CP147,@CP148,@CP149,@CP150,@CP151,@CP152,@CP153,@CP154,@CP155,@CP166,@CP167,@CP168,@CP169,@CP170,@CP171,@CP172,@CP160,@CP161,@CP162,@CP163,@CP164,@CP165,@CP173,@CP174,@CP175,@CP176,@CP177)" ,new SqlParameter( "@CP001" ,CP001 ) ,new SqlParameter( "@CP003" ,CP003 ) ,new SqlParameter( "@CP004" ,CP004 ) ,new SqlParameter( "@CP005" ,CP005 ) ,new SqlParameter( "@CP006" ,CP006 ) ,new SqlParameter( "@CP007" ,CP007 ) ,new SqlParameter( "@CP008" ,CP008 ) ,new SqlParameter( "@CP009" ,CP009 ) ,new SqlParameter( "@CP011" ,CP011 ) ,new SqlParameter( "@CP012" ,CP012 ) ,new SqlParameter( "@CP014" ,CP014 ) ,new SqlParameter( "@CP015" ,CP015 ) ,new SqlParameter( "@CP016" ,CP016 ) ,new SqlParameter( "@CP026" ,CP026 ) ,new SqlParameter( "@CP027" ,CP027 ) ,new SqlParameter( "@CP028" ,CP028 ) ,new SqlParameter( "@CP029" ,CP029 ) ,new SqlParameter( "@CP030" ,CP030 ) ,new SqlParameter( "@CP031" ,CP031 ) ,new SqlParameter( "@CP032" ,CP032 ) ,new SqlParameter( "@CP033" ,CP033 ) ,new SqlParameter( "@CP034" ,CP034 ) ,new SqlParameter( "@CP035" ,CP035 ) ,new SqlParameter( "@CP036" ,CP036 ) ,new SqlParameter( "@CP037" ,CP037 ) ,new SqlParameter( "@CP038" ,CP038 ) ,new SqlParameter( "@CP039" ,CP039 ) ,new SqlParameter( "@CP040" ,CP040 ) ,new SqlParameter( "@CP041" ,CP041 ) ,new SqlParameter( "@CP042" ,CP042 ) ,new SqlParameter( "@CP043" ,CP043 ) ,new SqlParameter( "@CP044" ,CP044 ) ,new SqlParameter( "@CP045" ,CP045 ) ,new SqlParameter( "@CP046" ,CP046 ) ,new SqlParameter( "@CP047" ,CP047 ) ,new SqlParameter( "@CP048" ,CP048 ) ,new SqlParameter( "@CP049" ,CP049 ) ,new SqlParameter( "@CP050" ,CP050 ) ,new SqlParameter( "@CP051" ,CP051 ) ,new SqlParameter( "@CP052" ,CP052 ) ,new SqlParameter( "@CP053" ,CP053 ) ,new SqlParameter( "@CP054" ,CP054 ) ,new SqlParameter( "@CP055" ,CP055 ) ,new SqlParameter( "@CP056" ,CP056 ) ,new SqlParameter( "@CP057" ,CP057 ) ,new SqlParameter( "@CP058" ,CP058 ) ,new SqlParameter( "@CP059" ,CP059 ) ,new SqlParameter( "@CP060" ,CP060 ) ,new SqlParameter( "@CP061" ,CP061 ) ,new SqlParameter( "@CP062" ,CP062 ) ,new SqlParameter( "@CP063" ,CP063 ) ,new SqlParameter( "@CP064" ,CP064 ) ,new SqlParameter( "@CP065" ,CP065 ) ,new SqlParameter( "@CP066" ,CP066 ) ,new SqlParameter( "@CP067" ,CP067 ) ,new SqlParameter( "@CP068" ,CP068 ) ,new SqlParameter( "@CP069" ,CP069 ) ,new SqlParameter( "@CP070" ,CP070 ) ,new SqlParameter( "@CP071" ,CP071 ) ,new SqlParameter( "@CP072" ,CP072 ) ,new SqlParameter( "@CP073" ,CP073 ) ,new SqlParameter( "@CP074" ,CP074 ) ,new SqlParameter( "@CP075" ,CP075 ) ,new SqlParameter( "@CP076" ,CP076 ) ,new SqlParameter( "@CP078" ,CP078 ) ,new SqlParameter( "@CP079" ,CP079 ) ,new SqlParameter( "@CP080" ,CP080 ) ,new SqlParameter( "@CP081" ,CP081 ) ,new SqlParameter( "@CP082" ,CP082 ) ,new SqlParameter( "@CP083" ,CP083 ) ,new SqlParameter( "@CP084" ,CP084 ) ,new SqlParameter( "@CP085" ,CP085 ) ,new SqlParameter( "@CP086" ,CP086 ) ,new SqlParameter( "@CP087" ,CP087 ) ,new SqlParameter( "@CP088" ,CP088 ) ,new SqlParameter( "@CP089" ,CP089 ) ,new SqlParameter( "@CP090" ,CP090 ) ,new SqlParameter( "@CP091" ,CP091 ) ,new SqlParameter( "@CP092" ,CP092 ) ,new SqlParameter( "@CP093" ,CP093 ) ,new SqlParameter( "@CP094" ,CP094 ) ,new SqlParameter( "@CP095" ,CP095 ) ,new SqlParameter( "@CP096" ,CP096 ) ,new SqlParameter( "@CP097" ,CP097 ) ,new SqlParameter( "@CP098" ,CP098 ) ,new SqlParameter( "@CP099" ,CP099 ) ,new SqlParameter( "@CP100" ,CP100 ) ,new SqlParameter( "@CP101" ,CP101 ) ,new SqlParameter( "@CP102" ,CP102 ) ,new SqlParameter( "@CP103" ,CP103 ) ,new SqlParameter( "@CP104" ,CP104 ) ,new SqlParameter( "@CP105" ,CP105 ) ,new SqlParameter( "@CP106" ,CP106 ) ,new SqlParameter( "@CP107" ,CP107 ) ,new SqlParameter( "@CP108" ,CP108 ) ,new SqlParameter( "@CP109" ,CP109 ) ,new SqlParameter( "@CP110" ,CP110 ) ,new SqlParameter( "@CP111" ,CP111 ) ,new SqlParameter( "@CP112" ,CP112 ) ,new SqlParameter( "@CP113" ,CP113 ) ,new SqlParameter( "@CP114" ,CP114 ) ,new SqlParameter( "@CP115" ,CP115 ) ,new SqlParameter( "@CP116" ,CP116 ) ,new SqlParameter( "@CP117" ,CP117 ) ,new SqlParameter( "@CP118" ,CP118 ) ,new SqlParameter( "@CP119" ,CP119 ) ,new SqlParameter( "@CP120" ,CP120 ) ,new SqlParameter( "@CP121" ,CP121 ) ,new SqlParameter( "@CP122" ,CP122 ) ,new SqlParameter( "@CP123" ,CP123 ) ,new SqlParameter( "@CP124" ,CP124 ) ,new SqlParameter( "@CP125" ,CP125 ) ,new SqlParameter( "@CP126" ,CP126 ) ,new SqlParameter( "@CP127" ,CP127 ) ,new SqlParameter( "@CP128" ,CP128 ) ,new SqlParameter( "@CP129" ,CP129 ) ,new SqlParameter( "@CP130" ,CP130 ) ,new SqlParameter( "@CP131" ,CP131 ) ,new SqlParameter( "@CP132" ,CP132 ) ,new SqlParameter( "@CP133" ,CP133 ) ,new SqlParameter( "@CP134" ,CP134 ) ,new SqlParameter( "@CP135" ,CP135 ) ,new SqlParameter( "@CP136" ,CP136 ) ,new SqlParameter( "@CP137" ,CP137 ) ,new SqlParameter( "@CP138" ,CP138 ) ,new SqlParameter( "@CP139" ,CP139 ) ,new SqlParameter( "@CP140" ,CP140 ) ,new SqlParameter( "@CP141" ,CP141 ) ,new SqlParameter( "@CP142" ,CP142 ) ,new SqlParameter( "@CP143" ,CP143 ) ,new SqlParameter( "@CP144" ,CP144 ) ,new SqlParameter( "@CP145" ,CP145 ) ,new SqlParameter( "@CP146" ,CP146 ) ,new SqlParameter( "@CP147" ,CP147 ) ,new SqlParameter( "@CP148" ,CP148 ) ,new SqlParameter( "@CP149" ,CP149 ) ,new SqlParameter( "@CP150" ,CP150 ) ,new SqlParameter( "@CP151" ,CP151 ) ,new SqlParameter( "@CP152" ,CP152 ) ,new SqlParameter( "@CP153" ,CP153 ) ,new SqlParameter( "@CP154" ,CP154 ) ,new SqlParameter( "@CP155" ,CP155 ) ,new SqlParameter( "@CP166" ,CP166 ) ,new SqlParameter( "@CP167" ,CP167 ) ,new SqlParameter( "@CP168" ,CP168 ) ,new SqlParameter( "@CP169" ,CP169 ) ,new SqlParameter( "@CP170" ,CP170 ) ,new SqlParameter( "@CP171" ,CP171 ) ,new SqlParameter( "@CP172" ,CP172 ) ,new SqlParameter( "@CP160" ,CP160 ) ,new SqlParameter( "@CP161" ,CP161 ) ,new SqlParameter( "@CP162" ,CP162 ) ,new SqlParameter( "@CP163" ,CP163 ) ,new SqlParameter( "@CP164" ,CP164 ) ,new SqlParameter( "@CP165" ,CP165 ) ,new SqlParameter( "@CP173" ,CP173 ) ,new SqlParameter( "@CP174" ,CP174 ) ,new SqlParameter( "@CP175" ,CP175 ) ,new SqlParameter( "@CP176" ,CP176 ) ,new SqlParameter( "@CP177" ,CP177 ) );
                        if (count < 1)
                            MessageBox.Show( "录入数据失败" );
                        else
                        {
                            MessageBox.Show( "成功录入数据" );
                            adds( );
                        }
                    }
                    else
                    {
                        int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQM SET CP003=@CP003,CP004=@CP004,CP005=@CP005,CP006=@CP006,CP007=@CP007,CP008=@CP008,CP009=@CP009,CP011=@CP011,CP012=@CP012,CP014=@CP014,CP015=@CP015,CP016=@CP016,CP026=@CP026,CP027=@CP027,CP028=@CP028,CP029=@CP029,CP030=@CP030,CP031=@CP031,CP032=@CP032,CP033=@CP033,CP034=@CP034,CP035=@CP035,CP036=@CP036,CP037=@CP037,CP038=@CP038,CP039=@CP039,CP040=@CP040,CP041=@CP041,CP042=@CP042,CP043=@CP043,CP044=@CP044,CP045=@CP045,CP046=@CP046,CP047=@CP047,CP048=@CP048,CP049=@CP049,CP050=@CP050,CP051=@CP051,CP052=@CP052,CP053=@CP053,CP054=@CP054,CP055=@CP055, CP056=@CP056,CP057=@CP057,CP058=@CP058,CP059=@CP059,CP060=@CP060,CP061=@CP061,CP062=@CP062,CP063=@CP063,CP064=@CP064,CP065=@CP065,CP066=@CP066,CP067=@CP067,CP068=@CP068,CP069=@CP069,CP070=@CP070,CP071=@CP071,CP072=@CP072,CP073=@CP073,CP074=@CP074,CP075=@CP075,CP076=@CP076,CP078=@CP078,CP079=@CP079,CP080=@CP080,CP081=@CP081,CP082=@CP082,CP083=@CP083,CP084=@CP084,CP085=@CP085,CP086=@CP086,CP087=@CP087,CP088=@CP088,CP089=@CP089,CP090=@CP090,CP091=@CP091,CP092=@CP092,CP093=@CP093,CP094=@CP094,CP095=@CP095,CP096=@CP096,CP097=@CP097,CP098=@CP098,CP099=@CP099, CP100=@CP100,CP101=@CP101,CP102=@CP102,CP103=@CP103,CP104=@CP104,CP105=@CP105,CP106=@CP106,CP107=@CP107,CP108=@CP108,CP109=@CP109,CP110=@CP110,CP111=@CP111,CP112=@CP112,CP113=@CP113,CP114=@CP114,CP115=@CP115,CP116=@CP116,CP117=@CP117,CP118=@CP118,CP119=@CP119,CP120=@CP120,CP121=@CP121,CP122=@CP122,CP123=@CP123,CP124=@CP124,CP125=@CP125,CP126=@CP126,CP127=@CP127,CP128=@CP128,CP129=@CP129,CP130=@CP130,CP131=@CP131,CP132=@CP132,CP133=@CP133,CP134=@CP134,CP135=@CP135,CP136=@CP136,CP137=@CP137,CP138=@CP138,CP139=@CP139,CP140=@CP140,CP141=@CP141,CP142=@CP142,CP143=@CP143,CP144=@CP144,CP145=@CP145,CP146=@CP146,CP147=@CP147,CP148=@CP148,CP149=@CP149,CP150=@CP150,CP151=@CP151,CP152=@CP152,CP153=@CP153,CP154=@CP154,CP155=@CP155,CP166=@CP166,CP167=@CP167,CP168=@CP168,CP169=@CP169,CP170=@CP170,CP171=@CP171,CP172=@CP172,CP160=@CP160,CP161=@CP161,CP162=@CP162,CP163=@CP163,CP164=@CP164,CP165=@CP165,CP173=@CP173,CP174=@CP174,CP175=@CP175,CP176=@CP176,CP177=@CP177 WHERE CP001=@CP001" ,new SqlParameter( "@CP001" ,CP001 ) ,new SqlParameter( "@CP003" ,CP003 ) ,new SqlParameter( "@CP004" ,CP004 ) ,new SqlParameter( "@CP005" ,CP005 ) ,new SqlParameter( "@CP006" ,CP006 ) ,new SqlParameter( "@CP007" ,CP007 ) ,new SqlParameter( "@CP008" ,CP008 ) ,new SqlParameter( "@CP009" ,CP009 ) ,new SqlParameter( "@CP011" ,CP011 ) ,new SqlParameter( "@CP012" ,CP012 ) ,new SqlParameter( "@CP014" ,CP014 ) ,new SqlParameter( "@CP015" ,CP015 ) ,new SqlParameter( "@CP016" ,CP016 ) ,new SqlParameter( "@CP026" ,CP026 ) ,new SqlParameter( "@CP027" ,CP027 ) ,new SqlParameter( "@CP028" ,CP028 ) ,new SqlParameter( "@CP029" ,CP029 ) ,new SqlParameter( "@CP030" ,CP030 ) ,new SqlParameter( "@CP031" ,CP031 ) ,new SqlParameter( "@CP032" ,CP032 ) ,new SqlParameter( "@CP033" ,CP033 ) ,new SqlParameter( "@CP034" ,CP034 ) ,new SqlParameter( "@CP035" ,CP035 ) ,new SqlParameter( "@CP036" ,CP036 ) ,new SqlParameter( "@CP037" ,CP037 ) ,new SqlParameter( "@CP038" ,CP038 ) ,new SqlParameter( "@CP039" ,CP039 ) ,new SqlParameter( "@CP040" ,CP040 ) ,new SqlParameter( "@CP041" ,CP041 ) ,new SqlParameter( "@CP042" ,CP042 ) ,new SqlParameter( "@CP043" ,CP043 ) ,new SqlParameter( "@CP044" ,CP044 ) ,new SqlParameter( "@CP045" ,CP045 ) ,new SqlParameter( "@CP046" ,CP046 ) ,new SqlParameter( "@CP047" ,CP047 ) ,new SqlParameter( "@CP048" ,CP048 ) ,new SqlParameter( "@CP049" ,CP049 ) ,new SqlParameter( "@CP050" ,CP050 ) ,new SqlParameter( "@CP051" ,CP051 ) ,new SqlParameter( "@CP052" ,CP052 ) ,new SqlParameter( "@CP053" ,CP053 ) ,new SqlParameter( "@CP054" ,CP054 ) ,new SqlParameter( "@CP055" ,CP055 ) ,new SqlParameter( "@CP056" ,CP056 ) ,new SqlParameter( "@CP057" ,CP057 ) ,new SqlParameter( "@CP058" ,CP058 ) ,new SqlParameter( "@CP059" ,CP059 ) ,new SqlParameter( "@CP060" ,CP060 ) ,new SqlParameter( "@CP061" ,CP061 ) ,new SqlParameter( "@CP062" ,CP062 ) ,new SqlParameter( "@CP063" ,CP063 ) ,new SqlParameter( "@CP064" ,CP064 ) ,new SqlParameter( "@CP065" ,CP065 ) ,new SqlParameter( "@CP066" ,CP066 ) ,new SqlParameter( "@CP067" ,CP067 ) ,new SqlParameter( "@CP068" ,CP068 ) ,new SqlParameter( "@CP069" ,CP069 ) ,new SqlParameter( "@CP070" ,CP070 ) ,new SqlParameter( "@CP071" ,CP071 ) ,new SqlParameter( "@CP072" ,CP072 ) ,new SqlParameter( "@CP073" ,CP073 ) ,new SqlParameter( "@CP074" ,CP074 ) ,new SqlParameter( "@CP075" ,CP075 ) ,new SqlParameter( "@CP076" ,CP076 ) ,new SqlParameter( "@CP078" ,CP078 ) ,new SqlParameter( "@CP079" ,CP079 ) ,new SqlParameter( "@CP080" ,CP080 ) ,new SqlParameter( "@CP081" ,CP081 ) ,new SqlParameter( "@CP082" ,CP082 ) ,new SqlParameter( "@CP083" ,CP083 ) ,new SqlParameter( "@CP084" ,CP084 ) ,new SqlParameter( "@CP085" ,CP085 ) ,new SqlParameter( "@CP086" ,CP086 ) ,new SqlParameter( "@CP087" ,CP087 ) ,new SqlParameter( "@CP088" ,CP088 ) ,new SqlParameter( "@CP089" ,CP089 ) ,new SqlParameter( "@CP090" ,CP090 ) ,new SqlParameter( "@CP091" ,CP091 ) ,new SqlParameter( "@CP092" ,CP092 ) ,new SqlParameter( "@CP093" ,CP093 ) ,new SqlParameter( "@CP094" ,CP094 ) ,new SqlParameter( "@CP095" ,CP095 ) ,new SqlParameter( "@CP096" ,CP096 ) ,new SqlParameter( "@CP097" ,CP097 ) ,new SqlParameter( "@CP098" ,CP098 ) ,new SqlParameter( "@CP099" ,CP099 ) ,new SqlParameter( "@CP100" ,CP100 ) ,new SqlParameter( "@CP101" ,CP101 ) ,new SqlParameter( "@CP102" ,CP102 ) ,new SqlParameter( "@CP103" ,CP103 ) ,new SqlParameter( "@CP104" ,CP104 ) ,new SqlParameter( "@CP105" ,CP105 ) ,new SqlParameter( "@CP106" ,CP106 ) ,new SqlParameter( "@CP107" ,CP107 ) ,new SqlParameter( "@CP108" ,CP108 ) ,new SqlParameter( "@CP109" ,CP109 ) ,new SqlParameter( "@CP110" ,CP110 ) ,new SqlParameter( "@CP111" ,CP111 ) ,new SqlParameter( "@CP112" ,CP112 ) ,new SqlParameter( "@CP113" ,CP113 ) ,new SqlParameter( "@CP114" ,CP114 ) ,new SqlParameter( "@CP115" ,CP115 ) ,new SqlParameter( "@CP116" ,CP116 ) ,new SqlParameter( "@CP117" ,CP117 ) ,new SqlParameter( "@CP118" ,CP118 ) ,new SqlParameter( "@CP119" ,CP119 ) ,new SqlParameter( "@CP120" ,CP120 ) ,new SqlParameter( "@CP121" ,CP121 ) ,new SqlParameter( "@CP122" ,CP122 ) ,new SqlParameter( "@CP123" ,CP123 ) ,new SqlParameter( "@CP124" ,CP124 ) ,new SqlParameter( "@CP125" ,CP125 ) ,new SqlParameter( "@CP126" ,CP126 ) ,new SqlParameter( "@CP127" ,CP127 ) ,new SqlParameter( "@CP128" ,CP128 ) ,new SqlParameter( "@CP129" ,CP129 ) ,new SqlParameter( "@CP130" ,CP130 ) ,new SqlParameter( "@CP131" ,CP131 ) ,new SqlParameter( "@CP132" ,CP132 ) ,new SqlParameter( "@CP133" ,CP133 ) ,new SqlParameter( "@CP134" ,CP134 ) ,new SqlParameter( "@CP135" ,CP135 ) ,new SqlParameter( "@CP136" ,CP136 ) ,new SqlParameter( "@CP137" ,CP137 ) ,new SqlParameter( "@CP138" ,CP138 ) ,new SqlParameter( "@CP139" ,CP139 ) ,new SqlParameter( "@CP140" ,CP140 ) ,new SqlParameter( "@CP141" ,CP141 ) ,new SqlParameter( "@CP142" ,CP142 ) ,new SqlParameter( "@CP143" ,CP143 ) ,new SqlParameter( "@CP144" ,CP144 ) ,new SqlParameter( "@CP145" ,CP145 ) ,new SqlParameter( "@CP146" ,CP146 ) ,new SqlParameter( "@CP147" ,CP147 ) ,new SqlParameter( "@CP148" ,CP148 ) ,new SqlParameter( "@CP149" ,CP149 ) ,new SqlParameter( "@CP150" ,CP150 ) ,new SqlParameter( "@CP151" ,CP151 ) ,new SqlParameter( "@CP152" ,CP152 ) ,new SqlParameter( "@CP153" ,CP153 ) ,new SqlParameter( "@CP154" ,CP154 ) ,new SqlParameter( "@CP155" ,CP155 ) ,new SqlParameter( "@CP166" ,CP166 ) ,new SqlParameter( "@CP167" ,CP167 ) ,new SqlParameter( "@CP168" ,CP168 ) ,new SqlParameter( "@CP169" ,CP169 ) ,new SqlParameter( "@CP170" ,CP170 ) ,new SqlParameter( "@CP171" ,CP171 ) ,new SqlParameter( "@CP172" ,CP172 ) ,new SqlParameter( "@CP160" ,CP160 ) ,new SqlParameter( "@CP161" ,CP161 ) ,new SqlParameter( "@CP162" ,CP162 ) ,new SqlParameter( "@CP163" ,CP163 ) ,new SqlParameter( "@CP164" ,CP164 ) ,new SqlParameter( "@CP165" ,CP165 ) ,new SqlParameter( "@CP173" ,CP173 ) ,new SqlParameter( "@CP174" ,CP174 ) ,new SqlParameter( "@CP175" ,CP175 ) ,new SqlParameter( "@CP176" ,CP176 ) ,new SqlParameter( "@CP177" ,CP177 ) );
                        if (count < 1)
                            MessageBox.Show( "录入数据失败" );
                        else
                        {
                            MessageBox.Show( "成功录入数据" );
                            adds( );
                        }
                    }
                }             
            }
        }
        //取消
        protected override void cancel( )
        {
            base.cancel( );
            Ergodic.FormGroupboxEnableFalse( this, gb );
            textBox18.Enabled = false;

            if (sav == "1" && weihu!="1")
            {
                try
                {
                    if (gridView1.RowCount > 0)
                    {
                        CP001 = textB1.Text;
                        SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQM WHERE CP001=@CP001", new SqlParameter( "@CP001", CP001 ) );
                    }
                }
                catch { }
                finally
                {
                    toolSelect.Enabled = toolAdd.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = true;
                    toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolSave.Enabled = toolCancel.Enabled = false;

                    button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = btn1.Enabled = btn10.Enabled = btn11.Enabled = btn12.Enabled = btn13.Enabled = btn14.Enabled = btn15.Enabled = btn16.Enabled = btn17.Enabled = btn18.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = btn5.Enabled = btn6.Enabled = btn7.Enabled = btn8.Enabled = btn9.Enabled = button8.Enabled = button9.Enabled = button12.Enabled = false;
                }
            }
            else if (sav == "2" || weihu=="1")
            {
                toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = true;
                toolSave.Enabled = toolCancel.Enabled = false;
                button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = btn1.Enabled = btn10.Enabled = btn11.Enabled = btn12.Enabled = btn13.Enabled = btn14.Enabled = btn15.Enabled = btn16.Enabled = btn17.Enabled = btn18.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = btn5.Enabled = btn6.Enabled = btn7.Enabled = btn8.Enabled = btn9.Enabled = button8.Enabled = button9.Enabled = button12.Enabled = false;
            }            
        }
        //维护
        protected override void maintain( )
        {
            base.maintain( );
            CP001 = textB1.Text;
            DataTable del = SqlHelper.ExecuteDataTable( "SELECT RES03,RES05,RES06,DBA012,CX02 FROM TPADBA A,R_REVIEW B,R_REVIEWS C,R_MLLCXMC D WHERE A.DBA001=B.RE01 AND B.RE01=C.RES03 AND C.RES01=D.CX01 AND RES06=@RES06 AND CX02=@CX02", new SqlParameter( "@RES06", CP001 ), new SqlParameter( "@CX02", this.Text ) );
            if (del != null && del.Rows.Count > 0)
            {
                if (del.Select( "RES05='执行'" ).Length > 0)
                {
                    toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = false;
                    toolSave.Enabled = toolCancel.Enabled = true;
                    button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = btn1.Enabled = btn10.Enabled = btn11.Enabled = btn12.Enabled = btn13.Enabled = btn14.Enabled = btn15.Enabled = btn16.Enabled = btn17.Enabled = btn18.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = btn5.Enabled = btn6.Enabled = btn7.Enabled = btn8.Enabled = btn9.Enabled = true;
                    button8.Enabled = button9.Enabled = button12.Enabled = false;

                    Ergodic.FormGroupboxEnableTrue( this, gb );

                    weihu = "1";

                    textBox18.Enabled = true;
                }
                else
                    MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
            }
            else
                MessageBox.Show( "此单据没有被执行,只需更改即可,无需维护" );
        }
        #endregion

        #region 查询
        void autoQuery ( )
        {
            Ergodic.FormGroupboxEnableFalse( this ,gb );

            toolSelect.Enabled = toolAdd.Enabled = toolDelete.Enabled = toolUpdate.Enabled = toolReview.Enabled = toolPrint.Enabled = toolExport.Enabled = toolMaintain.Enabled = true;
            toolSave.Enabled = toolCancel.Enabled = button1.Enabled = button2.Enabled = button3.Enabled = button4.Enabled = button5.Enabled = button6.Enabled = button7.Enabled = btn1.Enabled = btn10.Enabled = btn11.Enabled = btn12.Enabled = btn13.Enabled = btn14.Enabled = btn15.Enabled = btn16.Enabled = btn17.Enabled = btn18.Enabled = btn2.Enabled = btn3.Enabled = btn4.Enabled = btn5.Enabled = btn6.Enabled = btn7.Enabled = btn8.Enabled = btn9.Enabled = button8.Enabled = button9.Enabled = button12.Enabled = false;

            textBox18.Enabled = false;

            sav = "2";

            DataTable dl = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQM WHERE CP001=@CP001" ,new SqlParameter( "@CP001" ,CP001 ) );
            if ( dl.Rows.Count < 1 )
                Ergodic.FormEvery( this );
            else
            {
                #region 产品图片 唛头  条形码 客户反馈
                textBox10.Text = dl.Rows[0]["CP009"].ToString( );
                textB31.Text = dl.Rows[0]["CP152"].ToString( );
                if ( ( ( byte[] ) dl.Rows[0]["CP003"] ).Length == 0 )
                {
                    pi1.Image = null;
                }
                else
                {
                    byte[] mybyte = ( byte[] ) dl.Rows[0]["CP003"];
                    MemoryStream ms = new MemoryStream( mybyte );
                    ms.Write( mybyte ,0 ,mybyte.Length );
                    ms.Position = 0;
                    ms.Seek( 0 ,SeekOrigin.Begin );
                    Image img = Image.FromStream( ms ,true );
                    pi1.Image = img;
                }
                if ( ( ( byte[] ) dl.Rows[0]["CP004"] ).Length == 0 )
                {
                    pi2.Image = null;
                }
                else
                {
                    byte[] mybyte = ( byte[] ) dl.Rows[0]["CP004"];
                    MemoryStream ms = new MemoryStream( mybyte );
                    ms.Write( mybyte ,0 ,mybyte.Length );
                    ms.Position = 0;
                    ms.Seek( 0 ,SeekOrigin.Begin );
                    Image img = Image.FromStream( ms ,true );
                    pi2.Image = img;
                }
                if ( ( ( byte[] ) dl.Rows[0]["CP005"] ).Length == 0 )
                {
                    pi3.Image = null;
                }
                else
                {
                    byte[] mybyte = ( byte[] ) dl.Rows[0]["CP005"];
                    MemoryStream ms = new MemoryStream( mybyte );
                    ms.Write( mybyte ,0 ,mybyte.Length );
                    ms.Position = 0;
                    ms.Seek( 0 ,SeekOrigin.Begin );
                    Image img = Image.FromStream( ms ,true );
                    pi3.Image = img;
                }
                if ( ( ( byte[] ) dl.Rows[0]["CP006"] ).Length == 0 )
                {
                    pi4.Image = null;
                }
                else
                {
                    byte[] mybyte = ( byte[] ) dl.Rows[0]["CP006"];
                    MemoryStream ms = new MemoryStream( mybyte );
                    ms.Write( mybyte ,0 ,mybyte.Length );
                    ms.Position = 0;
                    ms.Seek( 0 ,SeekOrigin.Begin );
                    Image img = Image.FromStream( ms ,true );
                    pi4.Image = img;
                }
                if ( ( ( byte[] ) dl.Rows[0]["CP148"] ).Length == 0 )
                {
                    pi5.Image = null;
                }
                else
                {
                    byte[] mybyte = ( byte[] ) dl.Rows[0]["CP148"];
                    MemoryStream ms = new MemoryStream( mybyte );
                    ms.Write( mybyte ,0 ,mybyte.Length );
                    ms.Position = 0;
                    ms.Seek( 0 ,SeekOrigin.Begin );
                    Image img = Image.FromStream( ms ,true );
                    pi5.Image = img;
                }
                if ( ( ( byte[] ) dl.Rows[0]["CP149"] ).Length == 0 )
                {
                    pi6.Image = null;
                }
                else
                {
                    byte[] mybyte = ( byte[] ) dl.Rows[0]["CP149"];
                    MemoryStream ms = new MemoryStream( mybyte );
                    ms.Write( mybyte ,0 ,mybyte.Length );
                    ms.Position = 0;
                    ms.Seek( 0 ,SeekOrigin.Begin );
                    Image img = Image.FromStream( ms ,true );
                    pi6.Image = img;
                }
                if ( ( ( byte[] ) dl.Rows[0]["CP150"] ).Length == 0 )
                {
                    pictureBox1.Image = null;
                }
                else
                {
                    byte[] mybyte = ( byte[] ) dl.Rows[0]["CP150"];
                    MemoryStream ms = new MemoryStream( mybyte );
                    ms.Write( mybyte ,0 ,mybyte.Length );
                    ms.Position = 0;
                    ms.Seek( 0 ,SeekOrigin.Begin );
                    Image img = Image.FromStream( ms ,true );
                    pictureBox1.Image = img;
                }
                if ( ( ( byte[] ) dl.Rows[0]["CP151"] ).Length == 0 )
                {
                    pictureBox2.Image = null;
                }
                else
                {
                    byte[] mybyte = ( byte[] ) dl.Rows[0]["CP151"];
                    MemoryStream ms = new MemoryStream( mybyte );
                    ms.Write( mybyte ,0 ,mybyte.Length );
                    ms.Position = 0;
                    ms.Seek( 0 ,SeekOrigin.Begin );
                    Image img = Image.FromStream( ms ,true );
                    pictureBox2.Image = img;
                }
                #endregion

                #region 产品要求 产品功能描述
                comboBox2.Text = dl.Rows[0]["CP153"].ToString( );
                comboBox1.Text = dl.Rows[0]["CP154"].ToString( );
                textBox5.Text = dl.Rows[0]["CP155"].ToString( );
                if ( dl.Rows[0]["CP007"].ToString( ) == "T" )
                {
                    che1.Checked = true;
                }
                else
                {
                    che1.Checked = false;
                }
                if ( dl.Rows[0]["CP008"].ToString( ) == "T" )
                {
                    che2.Checked = true;
                }
                else
                {
                    che2.Checked = false;
                }
                if ( dl.Rows[0]["CP011"].ToString( ) == "T" )
                {
                    che3.Checked = true;
                }
                else
                {
                    che3.Checked = false;
                }
                if ( dl.Rows[0]["CP012"].ToString( ) == "T" )
                {
                    che4.Checked = true;
                }
                else
                {
                    che4.Checked = false;
                }
                if ( dl.Rows[0]["CP014"].ToString( ) == "T" )
                {
                    checkBox30.Checked = true;
                }
                else
                {
                    checkBox30.Checked = false;
                }
                if ( dl.Rows[0]["CP015"].ToString( ) == "T" )
                {
                    che5.Checked = true;
                }
                else
                {
                    che5.Checked = false;
                }
                if ( dl.Rows[0]["CP016"].ToString( ) == "T" )
                {
                    che6.Checked = true;
                }
                else
                {
                    che6.Checked = false;
                }
                if ( dl.Rows[0]["CP026"].ToString( ) == "T" )
                {
                    che7.Checked = true;
                }
                else
                {
                    che7.Checked = false;
                }
                if ( dl.Rows[0]["CP027"].ToString( ) != "" )
                {
                    checkBox1.Checked = true;
                    textBox2.Text = dl.Rows[0]["CP027"].ToString( );
                }
                else
                {
                    checkBox1.Checked = false;
                }
                comboBox59.Text = dl.Rows[0]["CP028"].ToString( );
                textB7.Text = dl.Rows[0]["CP029"].ToString( );
                #endregion

                #region 材料类别  使用位置
                if ( dl.Rows[0]["CP030"].ToString( ) == label12.Text )
                {
                    textB9.Text = dl.Rows[0]["CP031"].ToString( );
                    if ( dl.Rows[0]["CP032"].ToString( ) == "T" )
                    {
                        checkBox12.Checked = true;
                    }
                    else
                    {
                        checkBox12.Checked = false;
                    }
                    if ( dl.Rows[0]["CP160"].ToString( ) == "T" )
                    {
                        checkBox13.Checked = true;
                    }
                    else
                    {
                        checkBox13.Checked = false;
                    }
                    textBox14.Text = dl.Rows[0]["CP033"].ToString( );
                }
                if ( dl.Rows[0]["CP034"].ToString( ) == label15.Text )
                {
                    textB10.Text = dl.Rows[0]["CP035"].ToString( );
                    if ( dl.Rows[0]["CP036"].ToString( ) == "T" )
                    {
                        checkBox14.Checked = true;
                    }
                    else
                    {
                        checkBox14.Checked = false;
                    }
                    if ( dl.Rows[0]["CP040"].ToString( ) == "T" )
                    {
                        checkBox15.Checked = true;
                    }
                    else
                    {
                        checkBox15.Checked = false;
                    }
                    if ( dl.Rows[0]["CP161"].ToString( ) == "T" )
                    {
                        checkBox16.Checked = true;
                    }
                    else
                    {
                        checkBox16.Checked = false;
                    }
                    if ( dl.Rows[0]["CP162"].ToString( ) == "T" )
                    {
                        checkBox17.Checked = true;
                    }
                    else
                    {
                        checkBox17.Checked = false;
                    }
                    textBox15.Text = dl.Rows[0]["CP037"].ToString( );
                }
                if ( dl.Rows[0]["CP038"].ToString( ) == label17.Text )
                {
                    textB11.Text = dl.Rows[0]["CP039"].ToString( );
                    if ( dl.Rows[0]["CP036"].ToString( ) == "T" )
                    {
                        checkBox14.Checked = true;
                    }
                    else
                    {
                        checkBox14.Checked = false;
                    }
                    if ( dl.Rows[0]["CP040"].ToString( ) == "T" )
                    {
                        checkBox15.Checked = true;
                    }
                    else
                    {
                        checkBox15.Checked = false;
                    }
                    if ( dl.Rows[0]["CP161"].ToString( ) == "T" )
                    {
                        checkBox16.Checked = true;
                    }
                    else
                    {
                        checkBox16.Checked = false;
                    }
                    if ( dl.Rows[0]["CP162"].ToString( ) == "T" )
                    {
                        checkBox17.Checked = true;
                    }
                    else
                    {
                        checkBox17.Checked = false;
                    }
                    textBox15.Text = dl.Rows[0]["CP041"].ToString( );
                }
                if ( dl.Rows[0]["CP042"].ToString( ) == label19.Text )
                {
                    textB12.Text = dl.Rows[0]["CP043"].ToString( );
                    textBox3.Text = dl.Rows[0]["CP044"].ToString( );
                    if ( dl.Rows[0]["CP045"].ToString( ) == "T" )
                    {
                        checkBox19.Checked = true;
                    }
                    else
                    {
                        checkBox19.Checked = false;
                    }
                    if ( dl.Rows[0]["CP163"].ToString( ) == "T" )
                    {
                        checkBox18.Checked = true;
                    }
                    else
                    {
                        checkBox18.Checked = false;
                    }
                }
                if ( dl.Rows[0]["CP046"].ToString( ) == label30.Text )
                {
                    textB13.Text = dl.Rows[0]["CP047"].ToString( );
                    textBox4.Text = dl.Rows[0]["CP048"].ToString( );
                    if ( dl.Rows[0]["CP049"].ToString( ) == "T" )
                    {
                        checkBox23.Checked = true;
                    }
                    else
                    {
                        checkBox23.Checked = false;
                    }
                    if ( dl.Rows[0]["CP146"].ToString( ) == "T" )
                    {
                        checkBox22.Checked = true;
                    }
                    else
                    {
                        checkBox22.Checked = false;
                    }
                    if ( dl.Rows[0]["CP165"].ToString( ) == "T" )
                    {
                        checkBox21.Checked = true;
                    }
                    else
                    {
                        checkBox21.Checked = false;
                    }
                    if ( dl.Rows[0]["CP173"].ToString( ) == "T" )
                    {
                        checkBox20.Checked = true;
                    }
                    else
                    {
                        checkBox20.Checked = false;
                    }
                }
                if ( dl.Rows[0]["CP050"].ToString( ) == label32.Text )
                {
                    textB14.Text = dl.Rows[0]["CP051"].ToString( );
                    textBox5.Text = dl.Rows[0]["CP052"].ToString( );
                    if ( dl.Rows[0]["CP053"].ToString( ) == "T" )
                    {
                        checkBox24.Checked = true;
                    }
                    else
                    {
                        checkBox24.Checked = false;
                    }
                    if ( dl.Rows[0]["CP174"].ToString( ) == "T" )
                    {
                        checkBox25.Checked = true;
                    }
                    else
                    {
                        checkBox25.Checked = false;
                    }
                    if ( dl.Rows[0]["CP175"].ToString( ) == "T" )
                    {
                        checkBox26.Checked = true;
                    }
                    else
                    {
                        checkBox26.Checked = false;
                    }
                }
                if ( dl.Rows[0]["CP054"].ToString( ) == label32.Text )
                {
                    textB15.Text = dl.Rows[0]["CP055"].ToString( );
                    textBox6.Text = dl.Rows[0]["CP056"].ToString( );
                    textBox8.Text = dl.Rows[0]["CP057"].ToString( );
                }
                if ( dl.Rows[0]["CP058"].ToString( ) == label44.Text )
                {
                    textB16.Text = dl.Rows[0]["CP059"].ToString( );
                    textBox7.Text = dl.Rows[0]["CP060"].ToString( );
                    textBox9.Text = dl.Rows[0]["CP061"].ToString( );
                }
                #endregion

                #region 包装要求
                if ( dl.Rows[0]["CP062"].ToString( ) == "T" )
                {
                    che35.Checked = true;
                }
                else
                {
                    che35.Checked = false;
                }
                if ( dl.Rows[0]["CP063"].ToString( ) == "T" )
                {
                    che36.Checked = true;
                }
                else
                {
                    che36.Checked = false;
                }
                if ( dl.Rows[0]["CP064"].ToString( ) == "T" )
                {
                    che37.Checked = true;
                }
                else
                {
                    che37.Checked = false;
                }
                if ( dl.Rows[0]["CP065"].ToString( ) == "T" )
                {
                    che38.Checked = true;
                }
                else
                {
                    che38.Checked = false;
                }
                if ( dl.Rows[0]["CP066"].ToString( ) == "T" )
                {
                    che39.Checked = true;
                }
                else
                {
                    che39.Checked = false;
                }
                if ( dl.Rows[0]["CP067"].ToString( ) == "T" )
                {
                    che40.Checked = true;
                }
                else
                {
                    che40.Checked = false;
                }
                if ( dl.Rows[0]["CP068"].ToString( ) == "T" )
                {
                    che41.Checked = true;
                }
                else
                {
                    che41.Checked = false;
                }
                if ( dl.Rows[0]["CP069"].ToString( ) == "T" )
                {
                    che42.Checked = true;
                }
                else
                {
                    che42.Checked = false;
                }
                if ( dl.Rows[0]["CP070"].ToString( ) == "T" )
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Checked = false;
                }
                if ( dl.Rows[0]["CP071"].ToString( ) != "" )
                {
                    checkBox3.Checked = true;
                    textB17.Text = dl.Rows[0]["CP072"].ToString( );
                }
                else
                {
                    checkBox2.Checked = false;
                }
                textB18.Text = dl.Rows[0]["CP073"].ToString( );
                textB19.Text = dl.Rows[0]["CP074"].ToString( );
                if ( dl.Rows[0]["CP075"].ToString( ) != "" || dl.Rows[0]["CP076"].ToString( ) != "" )
                {
                    che43.Checked = true;
                    comboBox3.Text = dl.Rows[0]["CP075"].ToString( );
                    comboBox8.Text = dl.Rows[0]["CP076"].ToString( );
                }
                else
                {
                    che43.Checked = false;
                    comboBox3.Text = "";
                    comboBox8.Text = "";
                }
                if ( dl.Rows[0]["CP078"].ToString( ) != "" || dl.Rows[0]["CP079"].ToString( ) != "" )
                {
                    che44.Checked = true;
                    comboBox4.Text = dl.Rows[0]["CP078"].ToString( );
                    comboBox9.Text = dl.Rows[0]["CP079"].ToString( );
                }
                else
                {
                    che44.Checked = false;
                    comboBox4.Text = "";
                    comboBox9.Text = "";
                }
                if ( dl.Rows[0]["CP080"].ToString( ) != "" || dl.Rows[0]["CP081"].ToString( ) != "" )
                {
                    che45.Checked = true;
                    comboBox6.Text = dl.Rows[0]["CP080"].ToString( );
                    comboBox13.Text = dl.Rows[0]["CP081"].ToString( );
                }
                else
                {
                    che45.Checked = false;
                    comboBox6.Text = "";
                    comboBox13.Text = "";
                }
                if ( dl.Rows[0]["CP082"].ToString( ) != "" || dl.Rows[0]["CP083"].ToString( ) != "" )
                {
                    checkBox6.Checked = true;
                    comboBox25.Text = dl.Rows[0]["CP082"].ToString( );
                    comboBox24.Text = dl.Rows[0]["CP083"].ToString( );
                }
                else
                {
                    checkBox6.Checked = false;
                    comboBox25.Text = "";
                    comboBox24.Text = "";
                }
                if ( dl.Rows[0]["CP084"].ToString( ) != "" || dl.Rows[0]["CP085"].ToString( ) != "" )
                {
                    che48.Checked = true;
                    comboBox15.Text = dl.Rows[0]["CP084"].ToString( );
                    comboBox18.Text = dl.Rows[0]["CP085"].ToString( );
                }
                else
                {
                    che48.Checked = false;
                    comboBox15.Text = "";
                    comboBox18.Text = "";
                }
                if ( dl.Rows[0]["CP086"].ToString( ) != "" || dl.Rows[0]["CP087"].ToString( ) != "" )
                {
                    checkBox7.Checked = true;
                    comboBox5.Text = dl.Rows[0]["CP086"].ToString( );
                    comboBox11.Text = dl.Rows[0]["CP087"].ToString( );
                }
                else
                {
                    checkBox7.Checked = false;
                    comboBox5.Text = "";
                    comboBox11.Text = "";
                }
                if ( dl.Rows[0]["CP088"].ToString( ) != "" || dl.Rows[0]["CP089"].ToString( ) != "" )
                {
                    che49.Checked = true;
                    comboBox16.Text = dl.Rows[0]["CP088"].ToString( );
                    comboBox23.Text = dl.Rows[0]["CP089"].ToString( );
                }
                else
                {
                    che49.Checked = false;
                    comboBox16.Text = "";
                    comboBox23.Text = "";
                }
                if ( dl.Rows[0]["CP090"].ToString( ) != "" || dl.Rows[0]["CP091"].ToString( ) != "" )
                {
                    checkBox5.Checked = true;
                    comboBox19.Text = dl.Rows[0]["CP090"].ToString( );
                    comboBox22.Text = dl.Rows[0]["CP091"].ToString( );
                }
                else
                {
                    checkBox5.Checked = false;
                    comboBox19.Text = "";
                    comboBox22.Text = "";
                }
                if ( dl.Rows[0]["CP092"].ToString( ) != "" || dl.Rows[0]["CP093"].ToString( ) != "" )
                {
                    che47.Checked = true;
                    comboBox14.Text = dl.Rows[0]["CP092"].ToString( );
                    comboBox21.Text = dl.Rows[0]["CP093"].ToString( );
                }
                else
                {
                    che47.Checked = false;
                    comboBox14.Text = "";
                    comboBox21.Text = "";
                }
                if ( dl.Rows[0]["CP094"].ToString( ) != "" || dl.Rows[0]["CP095"].ToString( ) != "" )
                {
                    checkBox4.Checked = true;
                    comboBox17.Text = dl.Rows[0]["CP094"].ToString( );
                    comboBox20.Text = dl.Rows[0]["CP095"].ToString( );
                }
                else
                {
                    checkBox4.Checked = false;
                    comboBox17.Text = "";
                    comboBox20.Text = "";
                }
                if ( dl.Rows[0]["CP096"].ToString( ) != "" || dl.Rows[0]["CP097"].ToString( ) != "" )
                {
                    che46.Checked = true;
                    comboBox7.Text = dl.Rows[0]["CP096"].ToString( );
                    comboBox12.Text = dl.Rows[0]["CP097"].ToString( );
                }
                else
                {
                    che46.Checked = false;
                    comboBox7.Text = "";
                    comboBox12.Text = "";
                }
                comboBox65.Text = dl.Rows[0]["CP166"].ToString( );
                comboBox31.Text = dl.Rows[0]["CP098"].ToString( );
                comboBox30.Text = dl.Rows[0]["CP099"].ToString( );
                comboBox60.Text = dl.Rows[0]["CP167"].ToString( );
                comboBox27.Text = dl.Rows[0]["CP100"].ToString( );
                comboBox26.Text = dl.Rows[0]["CP101"].ToString( );
                comboBox63.Text = dl.Rows[0]["CP168"].ToString( );
                comboBox33.Text = dl.Rows[0]["CP102"].ToString( );
                comboBox32.Text = dl.Rows[0]["CP103"].ToString( );
                comboBox64.Text = dl.Rows[0]["CP169"].ToString( );
                comboBox54.Text = dl.Rows[0]["CP104"].ToString( );
                comboBox10.Text = dl.Rows[0]["CP105"].ToString( );
                comboBox61.Text = dl.Rows[0]["CP170"].ToString( );
                comboBox29.Text = dl.Rows[0]["CP106"].ToString( );
                comboBox28.Text = dl.Rows[0]["CP107"].ToString( );
                comboBox62.Text = dl.Rows[0]["CP171"].ToString( );
                comboBox56.Text = dl.Rows[0]["CP108"].ToString( );
                comboBox55.Text = dl.Rows[0]["CP109"].ToString( );
                comboBox66.Text = dl.Rows[0]["CP172"].ToString( );
                comboBox58.Text = dl.Rows[0]["CP110"].ToString( );
                comboBox57.Text = dl.Rows[0]["CP111"].ToString( );
                if ( dl.Rows[0]["CP112"].ToString( ) == "T" )
                {
                    che61.Checked = true;
                }
                else
                {
                    che61.Checked = false;
                }
                if ( dl.Rows[0]["CP113"].ToString( ) == "T" )
                {
                    che62.Checked = true;
                }
                else
                {
                    che62.Checked = false;
                }
                if ( dl.Rows[0]["CP114"].ToString( ) == "T" )
                {
                    che63.Checked = true;
                }
                else
                {
                    che63.Checked = false;
                }
                if ( dl.Rows[0]["CP115"].ToString( ) != "" )
                {
                    che64.Checked = true;
                    textB25.Text = dl.Rows[0]["CP115"].ToString( );
                }
                else
                {
                    che64.Checked = false;
                    textB25.Text = "";
                }
                if ( dl.Rows[0]["CP116"].ToString( ) == "T" )
                {
                    che65.Checked = true;
                }
                else
                {
                    che65.Checked = false;
                }
                if ( dl.Rows[0]["CP117"].ToString( ) == "T" )
                {
                    che66.Checked = true;
                }
                else
                {
                    che66.Checked = false;
                }
                if ( dl.Rows[0]["CP118"].ToString( ) == "T" )
                {
                    che67.Checked = true;
                }
                else
                {
                    che67.Checked = false;
                }
                if ( dl.Rows[0]["CP119"].ToString( ) != "" )
                {
                    che68.Checked = true;
                    textB26.Text = dl.Rows[0]["CP119"].ToString( );
                }
                else
                {
                    che68.Checked = false;
                    textB26.Text = "";
                }
                if ( dl.Rows[0]["CP120"].ToString( ) == "T" )
                {
                    che69.Checked = true;
                }
                else
                {
                    che69.Checked = false;
                }
                if ( dl.Rows[0]["CP121"].ToString( ) == "T" )
                {
                    che70.Checked = true;
                }
                else
                {
                    che70.Checked = false;
                }
                if ( dl.Rows[0]["CP122"].ToString( ) == "T" )
                {
                    che71.Checked = true;
                }
                else
                {
                    che71.Checked = false;
                }
                if ( dl.Rows[0]["CP123"].ToString( ) != "" )
                {
                    che72.Checked = true;
                    textB27.Text = dl.Rows[0]["CP123"].ToString( );
                }
                else
                {
                    che72.Checked = false;
                    textB27.Text = "";
                }
                if ( dl.Rows[0]["CP124"].ToString( ) == "T" )
                {
                    che73.Checked = true;
                }
                else
                {
                    che73.Checked = false;
                }
                if ( dl.Rows[0]["CP125"].ToString( ) == "T" )
                {
                    che74.Checked = true;
                }
                else
                {
                    che74.Checked = false;
                }
                if ( dl.Rows[0]["CP126"].ToString( ) == "T" )
                {
                    che75.Checked = true;
                }
                else
                {
                    che75.Checked = false;
                }
                if ( dl.Rows[0]["CP127"].ToString( ) != "" )
                {
                    che76.Checked = true;
                    textB28.Text = dl.Rows[0]["CP127"].ToString( );
                }
                else
                {
                    che76.Checked = false;
                    textB28.Text = "";
                }
                comboBox34.Text = dl.Rows[0]["CP128"].ToString( );
                comboBox35.Text = dl.Rows[0]["CP129"].ToString( );
                comboBox36.Text = dl.Rows[0]["CP130"].ToString( );
                comboBox37.Text = dl.Rows[0]["CP131"].ToString( );
                comboBox38.Text = dl.Rows[0]["CP132"].ToString( );
                comboBox43.Text = dl.Rows[0]["CP133"].ToString( );
                comboBox42.Text = dl.Rows[0]["CP134"].ToString( );
                comboBox41.Text = dl.Rows[0]["CP135"].ToString( );
                comboBox40.Text = dl.Rows[0]["CP136"].ToString( );
                comboBox39.Text = dl.Rows[0]["CP137"].ToString( );
                comboBox48.Text = dl.Rows[0]["CP138"].ToString( );
                comboBox47.Text = dl.Rows[0]["CP139"].ToString( );
                comboBox46.Text = dl.Rows[0]["CP140"].ToString( );
                comboBox45.Text = dl.Rows[0]["CP141"].ToString( );
                comboBox44.Text = dl.Rows[0]["CP142"].ToString( );
                comboBox53.Text = dl.Rows[0]["CP143"].ToString( );
                comboBox52.Text = dl.Rows[0]["CP144"].ToString( );
                comboBox51.Text = dl.Rows[0]["CP145"].ToString( );
                comboBox50.Text = dl.Rows[0]["CP146"].ToString( );
                comboBox49.Text = dl.Rows[0]["CP147"].ToString( );
                #endregion

                textBox18.Text = dl.Rows[0]["CP176"].ToString( );

                sele = SqlHelper.ExecuteDataTable( "SELECT CP156,CP157,CP158,CP159 FROM R_PQM WHERE CP001=@CP001" ,new SqlParameter( "@CP001" ,CP001 ) );
                gridControl1.DataSource = sele;
            }
        }
        R_Frm369 r3 = new R_Frm369( );
        //查询
        protected override void select( )
        {
            base.select( );
        DataTable dt = SqlHelper.ExecuteDataTable( " SELECT * FROM R_PQM" );
            if (dt.Rows.Count < 1)
                MessageBox.Show( "没有数据" );
            else
            {
                DataTable ddg = SqlHelper.ExecuteDataTable( "SELECT CP001,PQF04 FROM R_PQM A,R_PQF B WHERE A.CP001=B.PQF01 ORDER BY CP001 DESC" );
                r3.gridControl1.DataSource = ddg;
                r3.r369 = "2";
                r3.PassDataBetweenForm += new R_Frm369.PassDataBetweenFormHandler( r3_PassDataBetweenForm );
                r3.StartPosition = FormStartPosition.CenterScreen;
                r3.ShowDialog( );
                if ( CP001 == "" )
                    MessageBox.Show( "您没有选择任何信息" );
                else
                    autoQuery( );
            }
        }
        private void r3_PassDataBetweenForm( object sender, PassDataWinFormEventArgs e )
        {
            CP001 = e.ConOne;
            textB1.Text = CP001;
            textB2.Text = e.ConTre;
        }
        Youqicaigou yq = new Youqicaigou( );
        //流水查询
        private void button7_Click( object sender, EventArgs e )
        {
            DataTable del = SqlHelper.ExecuteDataTable( "SELECT PQF01,PQF03,PQF04,PQF11,DFA002 FROM R_PQF A,TPADFA B,R_REVIEWS C,R_MLLCXMC D WHERE A.PQF11=B.DFA001 AND A.PQF01=C.RES06 AND C.RES01=D.CX01 AND D.CX02='订单销售合同(R_001)' AND C.RES05='执行' ORDER BY PQF01 DESC" );
            if (del.Rows.Count < 1)
            {
                MessageBox.Show( "没有产品信息" );
            }
            else
            {
                yq.gridControl1.DataSource = del;
                yq.sy = "4";
                yq.PassDataBetweenForm += new Youqicaigou.PassDataBetweenFormHandler( yq_PassDataBetweenForm );
                yq.StartPosition = FormStartPosition.CenterScreen;
                yq.ShowDialog();
            }
        }
        private void yq_PassDataBetweenForm( object sender, PassDataWinFormEventArgs e )
        {
            CP001 = e.ConOne;
            textB1.Text = e.ConOne;
            textBox1.Text = e.ConTwo;
            textB2.Text = e.ConTre;
            textBox11.Text = e.ConFiv;
        }
        //客供材料查询
        R_FrmPQP pqp = new R_FrmPQP( );
        private void button8_Click( object sender, EventArgs e )
        {
            if (CP001 == "")
            {
                MessageBox.Show( "请选择流水号" );
            }
            else
            {
                DataTable dq = SqlHelper.ExecuteDataTable( "SELECT GS07,GS08,GS10 FROM R_PQP WHERE GS01=@GS01", new SqlParameter( "@GS01", CP001 ) );
                if (dq.Rows.Count < 1)
                {
                    MessageBox.Show( "[产品每套成本改善控制表(R_509)]没有关于流水号:" + CP001 + "的产品信息" );
                }
                else
                {
                    pqp.gridControl1.DataSource = dq;
                    pqp.pqstr = "3";
                    pqp.PassDataBetweenForm += new R_FrmPQP.PassDataBetweenFormHandler( pqp_PassDataBetweenForm );
                    pqp.StartPosition = FormStartPosition.CenterScreen;
                    pqp.ShowDialog( );
                }
            }
        }
        private void pqp_PassDataBetweenForm( object sender, PassDataWinFormEventArgs e )
        {
            CP0156 = e.ConOne;
            textBox12.Text = e.ConOne;
            CP0157 = e.ConTwo;
            textBox16.Text = e.ConTwo;
            if (e.ConTre != "")
            {
                CP0158 = Convert.ToInt32( e.ConTre );
                textBox17.Text = e.ConTre;
            }
        }
        #endregion

        #region 图片
        byte[] CP003 = new byte[0];
        byte[] CP004 = new byte[0];
        byte[] CP005 = new byte[0];
        byte[] CP006 = new byte[0];
        byte[] CP148 = new byte[0];
        byte[] CP149 = new byte[0];
        byte[] CP150 = new byte[0];
        byte[] CP151 = new byte[0];
        //正视
        string filePath1 = "";
        private void btn1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath1 = ofd.FileName;//图片路径
                pi1.ImageLocation =filePath1;
                
                FileStream fs = new FileStream(filePath1, FileMode.Open,FileAccess.Read);
                //byte[] imageBytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader(fs);
                CP003 = br.ReadBytes((int)fs.Length);//图片转换成二进制流    
            }
        }
        private void btn2_Click( object sender, EventArgs e )
        {
            if (pi1.ImageLocation == "")
            {
                MessageBox.Show( "没有图片,不能放大" );
            }
            else
            {
                ima.pictureBox1.Image = pi1.Image;
                ima.ShowDialog( );
            }
        }
        private void btn3_Click( object sender, EventArgs e )
        {
            pi1.Image = null;
            CP003 = new byte[0];
        }
        //仰视
        string filePath2 = "";
        private void btn4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath2 = ofd.FileName;//图片路径
                pi2.ImageLocation = filePath2;

                FileStream fs = new FileStream(filePath2, FileMode.Open, FileAccess.Read);
                //byte[] imageBytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader(fs);
                CP004 = br.ReadBytes((int)fs.Length);//图片转换成二进制流    
            }        
        }
        private void btn5_Click( object sender, EventArgs e )
        {
            if (pi2.ImageLocation == "")
            {
                MessageBox.Show( "没有图片,不能放大" );
            }
            else
            {
                ima.pictureBox1.Image = pi2.Image;
                ima.ShowDialog( );
            }
        }
        private void btn6_Click( object sender, EventArgs e )
        {
            pi2.Image = null;
            CP004 = new byte[0];
        }
        //45°
        string filePath3 = "";
        private void btn7_Click(object sender, EventArgs e)
        {
            //Formcount.picTure(openFileDialog1, pi3, filePath3);
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath3 = ofd.FileName;//图片路径
                pi3.ImageLocation = filePath3;//找到的图片显示在picture上面

                FileStream fs = new FileStream(filePath3, FileMode.Open, FileAccess.Read);
                //byte[] imageBytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader(fs);
                CP005 = br.ReadBytes((int)fs.Length);//图片转换成二进制流    
            }
        }
        private void btn8_Click( object sender, EventArgs e )
        {
            if (pi3.ImageLocation == "")
            {
                MessageBox.Show( "没有图片,不能放大" );
            }
            else
            {
                ima.pictureBox1.Image = pi3.Image;
                ima.ShowDialog( );
            }
        }
        private void btn9_Click( object sender, EventArgs e )
        {
            pi3.Image = null;
            CP005 = new byte[0];
        }
        //完整包装
        string filePath4 = "";
        private void btn10_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath4 = ofd.FileName;//图片路径
                pi4.ImageLocation = filePath4;//找到的图片显示在picture上面

                FileStream fs = new FileStream(filePath4, FileMode.Open,FileAccess.Read);
                //byte[] imageBytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader(fs);
                CP006 = br.ReadBytes((int)fs.Length);//图片转换成二进制流    
            }
        }
        private void btn11_Click( object sender, EventArgs e )
        {
            if (pi4.ImageLocation == "")
            {
                MessageBox.Show( "没有图片,不能放大" );
            }
            else
            {
                ima.pictureBox1.Image = pi4.Image;
                ima.ShowDialog( );
            }
        }
        private void btn12_Click( object sender, EventArgs e )
        {
            pi4.Image = null;
            CP006 = new byte[0];
        }
        //正唛
        string filePath5 = "";
        private void btn13_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath5 = ofd.FileName;//图片路径
                pi5.ImageLocation = filePath5;//找到的图片显示在picture上面

                FileStream fs = new FileStream(filePath5, FileMode.Open,FileAccess.Read);
                //byte[] imageBytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader(fs);
                CP148 = br.ReadBytes((int)fs.Length);//图片转换成二进制流    
            }
        }
        private void btn14_Click( object sender, EventArgs e )
        {
            if (pi5.ImageLocation == "")
            {
                MessageBox.Show( "没有图片,不能放大" );
            }
            else
            {
                ima.pictureBox1.Image = pi5.Image;
                ima.ShowDialog( );
            }
        }
        private void btn15_Click( object sender, EventArgs e )
        {
            pi5.Image = null;
            CP148 = new byte[0];
        }
        //侧唛
        string filePath6 = "";
        private void btn16_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath6 = ofd.FileName;//图片路径
                pi6.ImageLocation = ofd.FileName;//找到的图片显示在picture上面

                FileStream fs = new FileStream(filePath6, FileMode.Open,FileAccess.Read);
                //byte[] imageBytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader(fs);
                CP149 = br.ReadBytes((int)fs.Length);//图片转换成二进制流    
            }
        }
        private void btn17_Click( object sender, EventArgs e )
        {
            if (pi6.ImageLocation == "")
            {
                MessageBox.Show( "没有图片,不能放大" );
            }
            else
            {
                ima.pictureBox1.Image = pi6.Image;
                ima.ShowDialog( );
            }
        }
        private void btn18_Click( object sender, EventArgs e )
        {
            pi6.Image = null;
            CP149 = new byte[0];
        }
        //彩盒
        string filePath7 = "";
        private void button3_Click( object sender, EventArgs e )
        {
            OpenFileDialog ofd = new OpenFileDialog( );
            ofd.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if (ofd.ShowDialog( ) == DialogResult.OK)
            {
                filePath7 = ofd.FileName;//图片路径
                pictureBox1.ImageLocation = ofd.FileName;//找到的图片显示在picture上面

                FileStream fs = new FileStream( filePath7, FileMode.Open, FileAccess.Read );
                //byte[] imageBytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader( fs );
                CP150 = br.ReadBytes( (int)fs.Length );//图片转换成二进制流    
            }
        }
        private void button2_Click( object sender, EventArgs e )
        {
            if (pictureBox1.ImageLocation == "")
            {
                MessageBox.Show( "没有图片,不能放大" );
            }
            else
            {
                ima.pictureBox1.Image = pictureBox1.Image;
                ima.ShowDialog( );
            }
        }
        private void button1_Click( object sender, EventArgs e )
        {
            pictureBox1.Image = null;
            CP150 = new byte[0];
        }
        //条形码
        string filePath8 = "";
        private void button4_Click( object sender, EventArgs e )
        {
            OpenFileDialog ofd = new OpenFileDialog( );
            ofd.Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png";
            if (ofd.ShowDialog( ) == DialogResult.OK)
            {
                filePath8 = ofd.FileName;//图片路径
                pictureBox2.ImageLocation = ofd.FileName;//找到的图片显示在picture上面

                FileStream fs = new FileStream( filePath8, FileMode.Open, FileAccess.Read );
                //byte[] imageBytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader( fs );
                CP151 = br.ReadBytes( (int)fs.Length );//图片转换成二进制流    
            }
        }
        private void button6_Click( object sender, EventArgs e )
        {
            if (pictureBox2.ImageLocation == "")
            {
                MessageBox.Show( "没有图片,不能放大" );
            }
            else
            {
                ima.pictureBox1.Image = pictureBox2.Image;
                ima.ShowDialog( );
            }
        }
        private void button5_Click( object sender, EventArgs e )
        {
            pictureBox2.Image = null;
            CP151 = new byte[0];
        }
        #endregion

        #region 表格
        DataTable biao;
        //删除
        private void button12_Click( object sender, EventArgs e )
        {
            if (textB1.Text == "")
                MessageBox.Show( "请选择流水号" );
            else
            {
                if (textBox12.Text == "")
                    MessageBox.Show( "请选择材料等信息" );
                else
                {
                    CP0156 = textBox12.Text;
                    CP0157 = textBox16.Text;
                    if (textBox17.Text != "")
                        CP0158 = Convert.ToInt32( textBox17.Text );
                    CP0159 = "客供";
                    DataTable dele = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQM WHERE CP001=@CP001 AND CP156=@CP156 AND CP157=@CP157", new SqlParameter( "@CP001", CP001 ), new SqlParameter( "@CP156", CP0156 ), new SqlParameter( "@CP157", CP0157 ) );
                    if ( dele.Rows.Count < 1 )
                        MessageBox.Show( "不存在\n\r流水号:" + CP001 + "\n\r材料名称:" + CP0156 + "\n\r规格:" + CP0157 + "\n\r的数据,请核实后再删除" );
                    else
                    {
                        int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQM WHERE CP001=@CP001 AND CP156=@CP156 AND CP157=@CP157" ,new SqlParameter( "@CP001" ,CP001 ) ,new SqlParameter( "@CP156" ,CP0156 ) ,new SqlParameter( "@CP157" ,CP0157 ) );
                        if ( count < 1 )
                            MessageBox.Show( "删除数据失败" );
                        else
                        {
                            MessageBox.Show( "成功删除数据" );

                            int num = gridView1.FocusedRowHandle;
                            if ( sav == "1" )
                            {
                                biao.Rows.RemoveAt( num );
                            }
                            else if ( sav == "2" )
                            {
                                sele.Rows.RemoveAt( num );
                            }
                        }
                    }
                }
            }
        }
        //新建
        private void button9_Click( object sender, EventArgs e )
        {
            if (textB1.Text == "")
                MessageBox.Show( "请选择流水号" );
            else
            {
                if (textBox12.Text == "")
                    MessageBox.Show( "请选择材料等信息" );
                else
                {
                    CP0156 = textBox12.Text;
                    CP0157 = textBox16.Text;
                    if (textBox17.Text != "")
                        CP0158 = Convert.ToInt32( textBox17.Text );
                    CP0159 = "客供";
                    DataTable dw = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQM WHERE CP001=@CP001 AND CP156=@CP156 AND CP157=@CP157", new SqlParameter( "@CP001", CP001 ), new SqlParameter( "@CP156", CP0156 ), new SqlParameter( "@CP157", CP0157 ) );
                    if (dw.Rows.Count < 1)
                    {
                        int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQM (CP001,CP156,CP157,CP158) VALUES (@CP001,@CP156,@CP157,@CP158)", new SqlParameter( "@CP001", CP001 ), new SqlParameter( "@CP156", CP0156 ), new SqlParameter( "@CP157", CP0157 ), new SqlParameter( "@CP158", CP0158 ) );
                        if (count < 1)
                            MessageBox.Show( "录入数据失败" );
                        else
                        {
                            MessageBox.Show( "成功录入数据" );
                            DataRow row;
                            if (sav == "1")
                            {
                                biao = SqlHelper.ExecuteDataTable( "SELECT CP156,CP157,CP158,CP159 FROM R_PQM WHERE CP001=@CP001", new SqlParameter( "@CP001", CP001 ) );
                                gridControl1.DataSource = biao;
                            }
                            else if (sav == "2")
                            {
                                row = sele.NewRow( );
                                row["CP156"] = CP0156;
                                row["CP157"] = CP0157;
                                row["CP158"] = CP0158;
                                row["CP159"] = CP0159;
                                sele.Rows.Add( row );
                            }
                        }
                    }
                    else
                        MessageBox.Show( "流水号:" + CP001 + "\n\r材料名称" + CP0156 + "\n\r规格:"+CP0157+"\n\r的数据已经存在,请核实后再录入" );
                }
            }
        }
        #endregion
    }
}
