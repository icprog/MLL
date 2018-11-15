using System;
using System . Data;
using System . Data . SqlClient;
using System . Windows . Forms;
using StudentMgr;
using Mulaolao . Class;

namespace Mulaolao . Base
{
    public partial class R519batch : Form
    {
        public R519batch( )
        {
            InitializeComponent( );

        }

        public string pl = "";
        public string plde = "";
        
        private void R519batch_Load( object sender, EventArgs e )
        {
            #region
            if (pl == "s1" || pl == "s2" || pl == "s3")
            {
                #region
                DataTable sl = SqlHelper.ExecuteDataTable( "SELECT PQA08,PQA06,PQA11,PQA07,PQA05,PQA12 FROM R_PQA" );
                //油漆价格/kg
                DataTable jgs = sl.DefaultView.ToTable( true, "PQA08" );
                comboBox2.DataSource = jgs;
                comboBox2.DisplayMember = "PQA08";
                //油漆种类
                DataTable zls = sl.DefaultView.ToTable( true, "PQA06" );
                comboBox3.DataSource = zls;
                comboBox3.DisplayMember = "PQA06";
                //油漆品牌
                DataTable pps = sl.DefaultView.ToTable( true, "PQA11" );
                comboBox5.DataSource = pps;
                comboBox5.DisplayMember = "PQA11";
                //颜色
                DataTable yss = sl.DefaultView.ToTable( true, "PQA07" );
                comboBox7.DataSource = yss;
                comboBox7.DisplayMember = "PQA07";
                //管理工资
                DataTable glgzs = sl.DefaultView.ToTable( true, "PQA05" );
                comboBox9.DataSource = glgzs;
                comboBox9.DisplayMember = "PQA05";
                //基材
                DataTable jcs = sl.DefaultView.ToTable( true, "PQA12" );
                comboBox11.DataSource = jcs;
                comboBox11.DisplayMember = "PQA12";
                #endregion
            }
            else if (pl == "j1" || pl == "j2" || pl == "j3")
            {
                #region
                DataTable jd = SqlHelper.ExecuteDataTable( "SELECT PQD08,PQD06,PQD11,PQD07,PQD05,PQD12 FROM R_PQD" );
                //油漆价格/kg
                DataTable jjgs = jd.DefaultView.ToTable( true, "PQD08" );
                comboBox2.DataSource = jjgs;
                comboBox2.DisplayMember = "PQD08";
                //油漆种类
                DataTable jzls = jd.DefaultView.ToTable( true, "PQD06" );
                comboBox3.DataSource = jzls;
                comboBox3.DisplayMember = "PQD06";
                //油漆品牌
                DataTable jpps = jd.DefaultView.ToTable( true, "PQD11" );
                comboBox5.DataSource = jpps;
                comboBox5.DisplayMember = "PQD11";
                //颜色
                DataTable jyss = jd.DefaultView.ToTable( true, "PQD07" );
                comboBox7.DataSource = jyss;
                comboBox7.DisplayMember = "PQD07";
                //管理工资
                DataTable jglgzs = jd.DefaultView.ToTable( true, "PQD05" );
                comboBox9.DataSource = jglgzs;
                comboBox9.DisplayMember = "PQD05";
                //基材
                DataTable jjcs = jd.DefaultView.ToTable( true, "PQD12" );
                comboBox11.DataSource = jjcs;
                comboBox11.DisplayMember = "PQD12";

                #endregion
            }
            else if (pl == "q1" || pl == "q2" || pl == "q3")
            {
                #region
                DataTable jq = SqlHelper.ExecuteDataTable( "SELECT PQE08,PQE06,PQE11,PQE07,PQE05,PQE12 FROM R_PQE" );
                //油漆价格/kg
                DataTable qjgs = jq.DefaultView.ToTable( true, "PQE08" );
                comboBox2.DataSource = qjgs;
                comboBox2.DisplayMember = "PQE08";
                //油漆种类
                DataTable qzls = jq.DefaultView.ToTable( true, "PQE06" );
                comboBox3.DataSource = qzls;
                comboBox3.DisplayMember = "PQE06";
                //油漆品牌
                DataTable qpps = jq.DefaultView.ToTable( true, "PQE11" );
                comboBox5.DataSource = qpps;
                comboBox5.DisplayMember = "PQE11";
                //颜色
                DataTable qyss = jq.DefaultView.ToTable( true, "PQE07" );
                comboBox7.DataSource = qyss;
                comboBox7.DisplayMember = "PQE07";
                //管理工资
                DataTable qglgzs = jq.DefaultView.ToTable( true, "PQE05" );
                comboBox9.DataSource = qglgzs;
                comboBox9.DisplayMember = "PQE05";
                //基材
                DataTable qjcs = jq.DefaultView.ToTable( true, "PQE12" );
                comboBox11.DataSource = qjcs;
                comboBox11.DisplayMember = "PQE12";
                #endregion
            }
            else if (pl == "f1" || pl == "f2" || pl == "f3")
            {
                #region
                DataTable fb = SqlHelper.ExecuteDataTable( "SELECT PQB09,PQB05,PQB10,PQB06,PQB04,PQB12,PQB08 FROM R_PQB" );
                //油漆价格/kg
                DataTable bjgs = fb.DefaultView.ToTable( true, "PQB09" );
                comboBox2.DataSource = bjgs;
                comboBox2.DisplayMember = "PQB09";
                //油漆种类
                DataTable bzls = fb.DefaultView.ToTable( true, "PQB05" );
                comboBox3.DataSource = bzls;
                comboBox3.DisplayMember = "PQB05";
                //油漆品牌
                DataTable bpps = fb.DefaultView.ToTable( true, "PQB10" );
                comboBox5.DataSource = bpps;
                comboBox5.DisplayMember = "PQB10";
                //颜色
                DataTable byss = fb.DefaultView.ToTable( true, "PQB06" );
                comboBox7.DataSource = byss;
                comboBox7.DisplayMember = "PQB06";
                //管理工资
                DataTable bglgzs = fb.DefaultView.ToTable( true, "PQB04" );
                comboBox9.DataSource = bglgzs;
                comboBox9.DisplayMember = "PQB04";
                //基材
                DataTable bjcs = fb.DefaultView.ToTable( true, "PQB12" );
                comboBox11.DataSource = bjcs;
                comboBox11.DisplayMember = "PQB12";
                //油漆单价/m²
                DataTable yqdj = fb.DefaultView.ToTable( true, "PQB08" );
                comboBox1.DataSource = yqdj;
                comboBox1.DisplayMember = "PQB08";
                #endregion
            }
            else if (pl == "t1" || pl == "t2" || pl == "t3")
            {
                #region
                DataTable tb = SqlHelper.ExecuteDataTable( "SELECT PQC12,PQC08,PQC13,PQC09,PQC07,PQC14,PQC03,PQC11,PQC06 FROM R_PQC" );
                //油漆价格/kg
                comboBox2.DataSource = tb.DefaultView.ToTable( true ,"PQC12" );
                comboBox2.DisplayMember = "PQC12";
                //油漆种类
                comboBox3.DataSource = tb.DefaultView.ToTable( true ,"PQC08" );
                comboBox3.DisplayMember = "PQC08";
                //油漆品牌
                comboBox5.DataSource = tb.DefaultView.ToTable( true ,"PQC13" );
                comboBox5.DisplayMember = "PQC13";
                //颜色
                comboBox7.DataSource = tb.DefaultView.ToTable( true ,"PQC09" );
                comboBox7.DisplayMember = "PQC09";
                //管理工资
                comboBox9.DataSource = tb.DefaultView.ToTable( true ,"PQC07" );
                comboBox9.DisplayMember = "PQC07";
                //基材
                comboBox11.DataSource = tb.DefaultView.ToTable( true ,"PQC14" );
                comboBox11.DisplayMember = "PQC14";
                //大小订单
                comboBox13.DataSource = tb.DefaultView.ToTable( true ,"PQC03" );
                comboBox13.DisplayMember = "PQC03";
                //油漆单价/m²
                comboBox1.DataSource = tb.DefaultView.ToTable( true ,"PQC11" );
                comboBox1.DisplayMember = "PQC11";
                //工资单价/m²
                comboBox4.DataSource = tb.DefaultView.ToTable( true ,"PQC06" );
                comboBox4.DisplayMember = "PQC06";
                #endregion
            }
            #endregion

            #region
            if (pl == "s1")
            {
                this.Text = "水帘机喷漆批量新建";
                comboBox13.Enabled = false;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox5.Enabled = true;
                comboBox7.Enabled = true;
                comboBox9.Enabled = true;
                comboBox11.Enabled = true;
                comboBox1.Enabled = false;
                comboBox4.Enabled = false;
            }
            else if (pl == "s2")
            {
                this.Text = "水帘机喷漆批量编辑";
                comboBox13.Enabled = false;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox5.Enabled = true;
                comboBox7.Enabled = true;
                comboBox9.Enabled = true;
                comboBox11.Enabled = true;
                comboBox1.Enabled = false;
                comboBox1.Enabled = false;
                comboBox4.Enabled = false;
            }
            else if (pl == "s3")
            {
                this.Text = "水帘机喷漆批量删除";
                comboBox13.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                comboBox5.Enabled = false;
                comboBox7.Enabled = false;
                comboBox9.Enabled = false;
                comboBox11.Enabled = false;
                comboBox1.Enabled = false;
                comboBox4.Enabled = false;
            }
            else if (pl == "j1")
            {
                this.Text = "静电喷涂批量新建";
                comboBox13.Enabled = false;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox5.Enabled = true;
                comboBox7.Enabled = true;
                comboBox9.Enabled = true;
                comboBox11.Enabled = true;
                comboBox1.Enabled = false;
                comboBox4.Enabled = false;
            }
            else if (pl == "j2")
            {
                this.Text = "静电喷涂批量编辑";
                comboBox13.Enabled = false;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox5.Enabled = true;
                comboBox7.Enabled = true;
                comboBox9.Enabled = true;
                comboBox11.Enabled = true;
                comboBox1.Enabled = false;
                comboBox4.Enabled = false;
            }
            else if (pl == "j3")
            {
                this.Text = "静电喷涂批量删除";
                comboBox13.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                comboBox5.Enabled = false;
                comboBox7.Enabled = false;
                comboBox9.Enabled = false;
                comboBox11.Enabled = false;
                comboBox1.Enabled = false;
                comboBox4.Enabled = false;
            }
            else if (pl == "q1")
            {
                this.Text = "浸漆批量新建";
                comboBox13.Enabled = false;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox5.Enabled = true;
                comboBox7.Enabled = true;
                comboBox9.Enabled = true;
                comboBox11.Enabled = true;
                comboBox1.Enabled = false;
                comboBox4.Enabled = false;
            }
            else if (pl == "q2")
            {
                this.Text = "浸漆批量编辑";
                comboBox13.Enabled = false;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox5.Enabled = true;
                comboBox7.Enabled = true;
                comboBox9.Enabled = true;
                comboBox11.Enabled = true;
                comboBox1.Enabled = false;
                comboBox4.Enabled = false;
            }
            else if (pl == "q3")
            {
                this.Text = "浸漆批量删除";
                comboBox13.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                comboBox5.Enabled = false;
                comboBox7.Enabled = false;
                comboBox9.Enabled = false;
                comboBox11.Enabled = false;
                comboBox1.Enabled = false;
                comboBox4.Enabled = false;
            }
            else if (pl == "f1")
            {
                this.Text = "封边批量新建";
                comboBox13.Enabled = false;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox5.Enabled = true;
                comboBox7.Enabled = true;
                comboBox9.Enabled = true;
                comboBox11.Enabled = true;
                comboBox1.Enabled = true;
                comboBox4.Enabled = false;
            }
            else if (pl == "f2")
            {
                this.Text = "封边批量编辑";
                comboBox13.Enabled = false;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox5.Enabled = true;
                comboBox7.Enabled = true;
                comboBox9.Enabled = true;
                comboBox11.Enabled = true;
                comboBox1.Enabled = true;
                comboBox4.Enabled = false;
            }
            else if (pl == "f3")
            {
                this.Text = "封边批量删除";
                comboBox13.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                comboBox5.Enabled = false;
                comboBox7.Enabled = false;
                comboBox9.Enabled = false;
                comboBox11.Enabled = false;
                comboBox1.Enabled = true;
                comboBox4.Enabled = false;
            }
            else if (pl == "t1")
            {
                this.Text = "涂布批量新建";
                comboBox13.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox5.Enabled = true;
                comboBox7.Enabled = true;
                comboBox9.Enabled = true;
                comboBox11.Enabled = true;
                comboBox1.Enabled = true;
                comboBox4.Enabled = true;
            }
            else if (pl == "t2")
            {
                this.Text = "涂布批量编辑";
                comboBox13.Enabled = true;
                comboBox2.Enabled = true;
                comboBox3.Enabled = true;
                comboBox5.Enabled = true;
                comboBox7.Enabled = true;
                comboBox9.Enabled = true;
                comboBox11.Enabled = true;
                comboBox1.Enabled = true;
                comboBox4.Enabled = true;
            }
            else if (pl == "t3")
            {
                this.Text = "涂布批量删除";
                comboBox13.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                comboBox5.Enabled = false;
                comboBox7.Enabled = false;
                comboBox9.Enabled = false;
                comboBox11.Enabled = false;
                comboBox1.Enabled = false;
                comboBox4.Enabled = false;
            }
            #endregion
        }

        decimal PQA08 = 0M, PQD08 = 0M, PQE08 = 0M, PQB09 = 0M, PQC12 = 0M, PQC06 = 0M;
        string PQA06 = "", PQA07 = "", PQA11 = "", PQA12 = "", PQD06 = "", PQD11 = "", PQD07 = "", PQD12 = "", PQE06 = "", PQE11 = "", PQE07 = "", PQE12 = "", PQB05 = "", PQB10 = "", PQB06 = "", PQB12 = "", PQC08 = "", PQC13 = "", PQC09 = "", PQC14 = "", PQC03 = "";
        int PQA05 = 0, PQD05 = 0, PQE05 = 0, PQB04 = 0, PQC07 = 0;

        decimal PQA8 = 0M, PQA3 = 0M, PQA9 = 0M, PQD3 = 0M, PQD8 = 0M, PQD9 = 0M, PQB011 = 0M, PQE3 = 0M, PQE4 = 0M, PQE8 = 0M, PQE9 = 0M, PQB1 = 0M, PQB3 = 0M, PQB7 = 0M, PQB8 = 0M, PQB9 = 0M, PQC5 = 0M, PQC6 = 0M, PQC011 = 0M, PQC012 = 0M, PQB08 = 0M, PQC11 = 0M;
        string PQA6 = "", PQA7 = "", PQA011 = "", PQA012 = "", PQD6 = "", PQD7 = "", PQD011 = "", PQD012 = "", PQE6 = "", PQE7 = "", PQE011 = "", PQE012 = "", PQB5 = "", PQB6 = "", PQB010 = "", PQB012 = "", PQC2 = "", PQC3 = "", PQC8 = "", PQC9 = "", PQC013 = "", PQC014 = "";
        int PQA1 = 0, PQA2 = 0, PQA4 = 0, PQA5 = 0, PQA010 = 0, PQD1 = 0, PQD2 = 0, PQD4 = 0, PQD5 = 0, PQD010 = 0, PQE1 = 0, PQE2 = 0, PQE5 = 0, PQE010 = 0, PQB4 = 0, PQC1 = 0, PQC4 = 0, PQC7 = 0;

        private void button1_Click( object sender, EventArgs e )
        {
            #region 水帘机
            if (textBox1.Text != "")
            {
                PQA08 = Convert.ToDecimal( textBox1.Text );
            }
            else
            {
                PQA08 = 0M;
            }
            PQA06 = textBox2.Text;
            PQA11 = textBox3.Text;
            PQA07 = textBox4.Text;
            if (textBox5.Text != "")
            {
                PQA05 = Convert.ToInt32( textBox5.Text );
            }
            else
            {
                PQA05 = 0;
            }
            PQA12 = textBox6.Text;
            if (comboBox2.Text != "")
            {
                PQA8 = Convert.ToDecimal( comboBox2.Text );
            }
            else
            {
                PQA8 = 0M;
            }
            PQA6 = comboBox3.Text;
            PQA011 = comboBox5.Text;
            PQA7 = comboBox7.Text;
            if (comboBox9.Text != "")
            {
                PQA5 = Convert.ToInt32( comboBox9.Text );
            }
            else
            {
                PQA5 = 0;
            }
            PQA012 = comboBox11.Text;
            #endregion

            #region 静电
            if (textBox1.Text != "")
            {
                PQD08 = Convert.ToDecimal( textBox1.Text );
            }
            else
            {
                PQD08 = 0M;
            }
            PQD06 = textBox2.Text;
            PQD11 = textBox3.Text;
            PQD07 = textBox4.Text;
            if (textBox5.Text != "")
            {
                PQD05 = Convert.ToInt32( textBox5.Text );
            }
            else
            {
                PQD05 = 0;
            }
            PQD12 = textBox6.Text;
            if (comboBox2.Text != "")
            {
                PQD8 = Convert.ToDecimal( comboBox2.Text );
            }
            else
            {
                PQD8 = 0M;
            }
            PQD6 = comboBox3.Text;
            PQD011 = comboBox5.Text;
            PQD7 = comboBox7.Text;
            if (comboBox9.Text != "")
            {
                PQD5 = Convert.ToInt32( comboBox9.Text );
            }
            else
            {
                PQD5 = 0;
            }
            PQD012 = comboBox11.Text;
            #endregion

            #region 浸漆
            if (textBox1.Text != "")
            {
                PQE08 = Convert.ToDecimal( textBox1.Text );
            }
            else
            {
                PQE08 = 0M;
            }
            PQE06 = textBox2.Text;
            PQE11 = textBox3.Text;
            PQE07 = textBox4.Text;
            if (textBox5.Text != "")
            {
                PQE05 = Convert.ToInt32( textBox5.Text );
            }
            else
            {
                PQE05 = 0;
            }
            PQE12 = textBox6.Text;
            if (comboBox2.Text != "")
            {
                PQE8 = Convert.ToDecimal( comboBox2.Text );
            }
            else
            {
                PQE8 = 0M;
            }
            PQE6 = comboBox3.Text;
            PQE011 = comboBox5.Text;
            PQE7 = comboBox7.Text;
            if (comboBox9.Text != "")
            {
                PQE5 = Convert.ToInt32( comboBox9.Text );
            }
            else
            {
                PQE5 = 0;
            }
            PQE012 = comboBox11.Text;
            #endregion
            
            #region 封边
            if (textBox1.Text != "")
            {
                PQB09 = Convert.ToDecimal( textBox1.Text );
            }
            else
            {
                PQB09 = 0M;
            }
            PQB05 = textBox2.Text;
            PQB10 = textBox3.Text;
            PQB06 = textBox4.Text;
            if (textBox5.Text != "")
            {
                PQB04 = Convert.ToInt32( textBox5.Text );
            }
            else
            {
                PQB04 = 0;
            }
            if (textBox8.Text != "")
            {
                PQB08 = Convert.ToDecimal( textBox8.Text );
            }
            else
            {
                PQB08 = 0M;
            }
            PQB12 = textBox6.Text;
            if (comboBox2.Text != "")
            {
                PQB9 = Convert.ToDecimal( comboBox2.Text );
            }
            else
            {
                PQB9= 0M;
            }
            PQB5 = comboBox3.Text;
            PQB010 = comboBox5.Text;
            PQB6 = comboBox7.Text;
            if (comboBox9.Text != "")
            {
                PQB4 = Convert.ToInt32( comboBox9.Text );
            }
            else
            {
                PQB4 = 0;
            }
            if (comboBox1.Text != "")
            {
                PQB8 = Convert.ToDecimal( comboBox1.Text );
            }
            else
            {
                PQB8 = 0M;
            }
            PQB012 = comboBox11.Text;
            #endregion

            #region 涂布
            if (textBox1.Text != "")
            {
                PQC12 = Convert.ToDecimal( textBox1.Text );
            }
            else
            {
                PQC12 = 0M;
            }
            PQC08 = textBox2.Text;
            PQC13 = textBox3.Text;
            PQC09 = textBox4.Text;
            if (textBox5.Text != "")
            {
                PQC07 = Convert.ToInt32( textBox5.Text );
            }
            else
            {
                PQC07 = 0;
            }
            if (textBox8.Text != "")
            {
                PQC11 = Convert.ToDecimal( textBox8.Text );
            }
            else
            {
                PQC11 = 0M;
            }
            PQC14 = textBox6.Text;
            PQC03 = textBox7.Text;
            if ( textBox9.Text != "" )
            {
                PQC06 = Convert.ToDecimal( textBox9.Text );
            }
            else
            {
                PQC06 = 0M;
            }
            if (comboBox2.Text != "")
            {
                PQC012 = Convert.ToDecimal( comboBox2.Text );
            }
            else
            {
                PQC012 = 0M;
            }
            PQC8 = comboBox3.Text;
            PQC013 = comboBox5.Text;
            PQC9 = comboBox7.Text;
            if (comboBox9.Text != "")
            {
                PQC7 = Convert.ToInt32( comboBox9.Text );
            }
            else
            {
                PQC7 = 0;
            }
            if (comboBox1.Text != "")
            {
                PQC011 = Convert.ToDecimal( comboBox1.Text );
            }
            else
            {
                PQC011 = 0M;
            }
            PQC014 = comboBox11.Text;
            PQC3 = comboBox13.Text;
            if ( comboBox4.Text != "" )
            {
                PQC6 = Convert.ToDecimal( comboBox4.Text );
            }
            else
            {
                PQC6 = 0M;
            }
            #endregion

            #region 水帘机 新建
            if (pl == "s1")
            {
                DataTable pqas = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQA ORDER BY PQA01" );
                
                if (PQA08 != PQA8 || PQA06 != PQA6 || PQA11 != PQA011 || PQA07 != PQA7 || PQA05 != PQA5 || PQA12 != PQA012)
                {
                    if (MessageBox.Show( "保留：\n\r" + label1.Text + "" + textBox1.Text + "\n\r" + label4.Text + "" + textBox2.Text + "\n\r" + label6.Text + "" + textBox3.Text + "\n\r" + label8.Text + "" + textBox4.Text + "\n\r" + label10.Text + "" + textBox5.Text + "\n\r" + label12.Text + "" + textBox6.Text + "\n\r\n\r新建：\n\r" + label1.Text + "" + comboBox2.Text + "\n\r" + label4.Text + "" + comboBox3.Text + "\n\r" + label6.Text + "" + comboBox5.Text + "\n\r" + label8.Text + "" + comboBox7.Text + "\n\r" + label10.Text + "" + comboBox9.Text + "\n\r" + label12.Text + "" + comboBox11.Text + "", "提示", MessageBoxButtons.OKCancel ) == DialogResult.OK)
                    {
                        DataTable dsele = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQA WHERE PQA08=@PQA08 AND PQA06=@PQA06 AND PQA11=@PQA11 AND PQA07=@PQA07 AND PQA05=@PQA05 AND PQA12=@PQA12", new SqlParameter( "@PQA08", PQA08 ), new SqlParameter( "@PQA06", PQA06 ), new SqlParameter( "@PQA11", PQA11 ), new SqlParameter( "@PQA07", PQA07 ), new SqlParameter( "@PQA05", PQA05 ), new SqlParameter( "@PQA12", PQA12 ) );
                        if (dsele.Rows.Count < 1)
                        {
                            MessageBox.Show( "没有查询到\n\r" + label1.Text + "" + PQA08 + "\n\r" + label4.Text + "" + PQA06 + "\n\r" + label6.Text + "" + PQA11 + "\n\r" + label8.Text + "" + PQA07 + "\n\r" + label10.Text + "" + PQA05 + "\n\r" + label12.Text + "" + PQA12 + "\n\r的数据,请核实后再操作" );
                        }
                        else
                        {
                                                     
                            for (int i = 0; i < dsele.Rows.Count; i++)
                            {
                                if (dsele.Rows[i]["PQA01"].ToString( ) != "")
                                    PQA1 = Convert.ToInt32( dsele.Rows[i]["PQA01"].ToString( ) );
                                else
                                    PQA1 = 0;
                                if (dsele.Rows[i]["PQA02"].ToString( ) != "")
                                    PQA2 = Convert.ToInt32( dsele.Rows[i]["PQA02"].ToString( ) );
                                else
                                    PQA2 = 0;
                                if (dsele.Rows[i]["PQA03"].ToString( ) != "")
                                    PQA3 = Convert.ToDecimal( dsele.Rows[i]["PQA03"].ToString( ) );
                                else
                                    PQA3 = 0M;
                                if (dsele.Rows[i]["PQA04"].ToString( ) != "")
                                    PQA4 = Convert.ToInt32( dsele.Rows[i]["PQA04"].ToString( ) );
                                else
                                    PQA4 = 0;
                                if (dsele.Rows[i]["PQA09"].ToString( ) != "")
                                    PQA9 = Convert.ToDecimal( dsele.Rows[i]["PQA09"].ToString( ) );
                                else
                                    PQA9 = 0M;
                                if (dsele.Rows[i]["PQA10"].ToString( ) != "")
                                    PQA010 = Convert.ToInt32( dsele.Rows[i]["PQA10"].ToString( ) );
                                else
                                    PQA010 = 0;

                                if (pqas != null && pqas.Select( "PQA01='" + PQA1 + "' AND PQA02='" + PQA2 + "' AND PQA03='" + PQA3 + "'AND PQA04='" + PQA4 + "' AND PQA05='" + PQA5 + "' AND PQA06='" + PQA6 + "' AND PQA07='" + PQA7 + "' AND PQA08='" + PQA8 + "' AND PQA09='" + PQA9 + "' AND PQA10='" + PQA010 + "' AND PQA11='" + PQA011 + "' AND PQA12='" + PQA012 + "'" ).Length > 0)

                                {
                                    MessageBox.Show( "已经存在\n\r个数/板:" + PQA1 + "\n\r小工工资/天:" + PQA2 + "\n\r小工日人数:" + PQA3 + "\n\r老师工资:" + PQA4 + "\n\r管理工资(%):" + PQA5 + "\n\r油漆种类:" + PQA6 + "\n\r颜色:" + PQA7 + "\n\r油漆价格/kg:" + PQA8 + "\n\r油漆单价/板:" + PQA9 + "\n\r板数/天:" + PQA010 + "\n\r油漆品牌:" + PQA011 + "\n\r基材:" + PQA012 + "\n\r的数据,请核实后再录入" );
                                }
                                else
                                {
                                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQA (PQA01,PQA02,PQA03,PQA04,PQA05,PQA06,PQA07,PQA08,PQA09,PQA10,PQA11,PQA12) VALUES (@PQA01,@PQA02,@PQA03,@PQA04,@PQA05,@PQA06,@PQA07,@PQA08,@PQA09,@PQA10,@PQA11,@PQA12)", new SqlParameter( "@PQA01", PQA1 ), new SqlParameter( "@PQA02", PQA2 ), new SqlParameter( "@PQA03", PQA3 ), new SqlParameter( "@PQA04", PQA4 ), new SqlParameter( "@PQA05", PQA5 ), new SqlParameter( "@PQA06", PQA6 ), new SqlParameter( "@PQA07", PQA7 ), new SqlParameter( "@PQA08", PQA8 ), new SqlParameter( "@PQA09", PQA9 ), new SqlParameter( "@PQA10", PQA010 ), new SqlParameter( "@PQA11", PQA011 ), new SqlParameter( "@PQA12", PQA012 ) );
                            }
                        }
                            MessageBox.Show( "批量新建数据成功" );
                        }
                        this.Close( );
                    }
                }
                else
                {
                    MessageBox.Show( "您没有修改任何项,请核查" );
                }
            }
            #endregion

            #region 水帘机 编辑
            else if (pl == "s2")
            {
                DataTable bianj = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQA WHERE PQA08=@PQA08 AND PQA06=@PQA06 AND PQA11=@PQA11 AND PQA07=@PQA07 AND PQA05=@PQA05 AND PQA12=@PQA12", new SqlParameter( "@PQA08", PQA8 ), new SqlParameter( "@PQA06", PQA6 ), new SqlParameter( "@PQA11", PQA011 ), new SqlParameter( "@PQA07", PQA7 ), new SqlParameter( "@PQA05", PQA5 ), new SqlParameter( "@PQA12", PQA012 ) );
                if (bianj.Rows.Count < 1)
                {
                    if (MessageBox.Show( "更改：\n\r" + label1.Text + "" + textBox1.Text + "---->" + comboBox2.Text + "\n\r" + label4.Text + "" + textBox2.Text + "---->" + comboBox3.Text + "\n\r" + label6.Text + "" + textBox3.Text + "---->" + comboBox5.Text + "\n\r" + label8.Text + "" + textBox4.Text + "---->" + comboBox7.Text + "\n\r" + label10.Text + "" + textBox5.Text + "---->" + comboBox9.Text + "\n\r" + label12.Text + "" + textBox6.Text + "---->" + comboBox11.Text + "", "提示", MessageBoxButtons.OKCancel ) == DialogResult.OK)
                    {
                        DataTable dsele = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQA WHERE PQA08=@PQA08 AND PQA06=@PQA06 AND PQA11=@PQA11 AND PQA07=@PQA07 AND PQA05=@PQA05 AND PQA12=@PQA12", new SqlParameter( "@PQA08", PQA08 ), new SqlParameter( "@PQA06", PQA06 ), new SqlParameter( "@PQA11", PQA11 ), new SqlParameter( "@PQA07", PQA07 ), new SqlParameter( "@PQA05", PQA05 ), new SqlParameter( "@PQA12", PQA12 ) );
                        if (dsele.Rows.Count < 1)
                        {
                            MessageBox.Show( "没有查询到\n\r" + label1.Text + "" + PQA08 + "\n\r" + label4.Text + "" + PQA06 + "\n\r" + label6.Text + "" + PQA11 + "\n\r" + label8.Text + "" + PQA07 + "\n\r" + label10.Text + "" + PQA05 + "\n\r" + label12.Text + "" + PQA12 + "\n\r的数据,请核实后再操作" );
                        }
                        else
                        {
                            int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQA SET PQA08=@PQA08,PQA06=@PQA06,PQA11=@PQA11,PQA07=@PQA07,PQA05=@PQA05,PQA12=@PQA12 WHERE PQA08=@PQA8 AND PQA06=@PQA6 AND PQA11=@PQA011 AND PQA07=@PQA7 AND PQA05=@PQA5 AND PQA12=@PQA012", new SqlParameter( "@PQA08", PQA8 ), new SqlParameter( "@PQA06", PQA6 ), new SqlParameter( "@PQA11", PQA011 ), new SqlParameter( "@PQA07", PQA7 ), new SqlParameter( "@PQA05", PQA5 ), new SqlParameter( "@PQA12", PQA012 ), new SqlParameter( "@PQA8", PQA08 ), new SqlParameter( "@PQA6", PQA06 ), new SqlParameter( "@PQA011", PQA11 ), new SqlParameter( "@PQA7", PQA07 ), new SqlParameter( "@PQA5", PQA05 ), new SqlParameter( "@PQA012", PQA12 ) );
                            if (count < 1)
                            {
                                MessageBox.Show( "批量编辑数据失败" );
                            }
                            else
                            {
                                MessageBox.Show( "批量编辑数据成功" );
                                this.Close( );
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show( "已经存在\n\r" + label1.Text + "" + comboBox2.Text + "\n\r" + label4.Text + "" + comboBox3.Text + "\n\r" + label6.Text + "" + comboBox5.Text + "\n\r" + label8.Text + "" + comboBox7.Text + "\n\r" + label10.Text + "" + comboBox9.Text + "\n\r" + label12.Text + "" + comboBox11.Text + "\n\r的数据,请核实后再操作" );
                }
            }
            #endregion

            #region 水帘机 删除
            else if (pl == "s3")
            {
                if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==

   DialogResult . Cancel )
                    return;
                DataTable bianj = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQA WHERE PQA08=@PQA08 AND PQA06=@PQA06 AND PQA11=@PQA11 AND PQA07=@PQA07 AND PQA05=@PQA05 AND PQA12=@PQA12", new SqlParameter( "@PQA08", PQA08 ), new SqlParameter( "@PQA06", PQA06 ), new SqlParameter( "@PQA11", PQA11 ), new SqlParameter( "@PQA07", PQA07 ), new SqlParameter( "@PQA05", PQA05 ), new SqlParameter( "@PQA12", PQA12 ) );
                if (bianj.Rows.Count > 0)
                {
                    if (MessageBox.Show( "删除：\n\r" + label1.Text + "" + textBox1.Text + "\n\r" + label4.Text + "" + textBox2.Text + "\n\r" + label6.Text + "" + textBox3.Text + "\n\r" + label8.Text + "" + textBox4.Text + "\n\r" + label10.Text + "" + textBox5.Text + "\n\r" + label12.Text + "" + textBox6.Text + "", "提示", MessageBoxButtons.OKCancel ) == DialogResult.OK)
                    {
                        int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQA WHERE PQA08=@PQA08 AND PQA06=@PQA06 AND PQA11=@PQA11 AND PQA07=@PQA07 AND PQA05=@PQA05 AND PQA12=@PQA12", new SqlParameter( "@PQA08", PQA08 ), new SqlParameter( "@PQA06", PQA06 ), new SqlParameter( "@PQA11", PQA11 ), new SqlParameter( "@PQA07", PQA07 ), new SqlParameter( "@PQA05", PQA05 ), new SqlParameter( "@PQA12", PQA12 ) );
                        if (count < 1)
                        {
                            MessageBox.Show( "批量删除数据失败" );
                        }
                        else
                        {
                            MessageBox.Show( "批量删除数据成功" );
                            plde = "1";
                            this.Close( );
                        }
                    }
                }
                else
                {
                    MessageBox.Show( "不存在\n\r" + label1.Text + "" + textBox1.Text + "\n\r" + label4.Text + "" + textBox2.Text + "\n\r" + label6.Text + "" + textBox3.Text + "\n\r" + label8.Text + "" + textBox4.Text + "\n\r" + label10.Text + "" + textBox5.Text + "\n\r" + label12.Text + "" + textBox6.Text + "\n\r的数据,请核实后再操作" );
                }
            }
            #endregion

            #region 静电 新建
            else if (pl == "j1")
            {
                DataTable pqds = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQD ORDER BY PQD01" );
                
                if (PQD08 != PQD8 || PQD06 != PQD6 || PQD11 != PQD011 || PQD07 != PQD7 || PQD05 != PQD5 || PQD12 != PQD012)
                {
                    if (MessageBox.Show( "保留：\n\r" + label1.Text + "" + textBox1.Text + "\n\r" + label4.Text + "" + textBox2.Text + "\n\r" + label6.Text + "" + textBox3.Text + "\n\r" + label8.Text + "" + textBox4.Text + "\n\r" + label10.Text + "" + textBox5.Text + "\n\r" + label12.Text + "" + textBox6.Text + "\n\r\n\r新建：\n\r" + label1.Text + "" + comboBox2.Text + "\n\r" + label4.Text + "" + comboBox3.Text + "\n\r" + label6.Text + "" + comboBox5.Text + "\n\r" + label8.Text + "" + comboBox7.Text + "\n\r" + label10.Text + "" + comboBox9.Text + "\n\r" + label12.Text + "" + comboBox11.Text + "", "提示", MessageBoxButtons.OKCancel ) == DialogResult.OK)
                    {
                        DataTable dsele = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQD WHERE PQD08=@PQD08 AND PQD06=@PQD06 AND PQD11=@PQD11 AND PQD07=@PQD07 AND PQD05=@PQD05 AND PQD12=@PQD12", new SqlParameter( "@PQD08", PQD08 ), new SqlParameter( "@PQD06", PQD06 ), new SqlParameter( "@PQD11", PQD11 ), new SqlParameter( "@PQD07", PQD07 ), new SqlParameter( "@PQD05", PQD05 ), new SqlParameter( "@PQD12", PQD12 ) );
                        if (dsele.Rows.Count < 1)
                        {
                            MessageBox.Show( "没有查询到\n\r" + label1.Text + "" + PQD08 + "\n\r" + label4.Text + "" + PQD06 + "\n\r" + label6.Text + "" + PQD11 + "\n\r" + label8.Text + "" + PQD07 + "\n\r" + label10.Text + "" + PQD05 + "\n\r" + label12.Text + "" + PQD12 + "\n\r的数据,请核实后再操作" );
                        }
                        else
                        {
                            for (int i = 0; i < dsele.Rows.Count; i++)
                            {
                                if (dsele.Rows[i]["PQD01"].ToString( ) != "")
                                    PQD1 = Convert.ToInt32( dsele.Rows[i]["PQD01"].ToString( ) );
                                else
                                    PQD1 = 0;
                                if (dsele.Rows[i]["PQD02"].ToString( ) != "")
                                    PQD2 = Convert.ToInt32( dsele.Rows[i]["PQD02"].ToString( ) );
                                else
                                    PQD2 = 0;
                                if (dsele.Rows[i]["PQD03"].ToString( ) != "")
                                    PQD3 = Convert.ToDecimal( dsele.Rows[i]["PQD03"].ToString( ) );
                                else
                                    PQD3 = 0M;
                                if (dsele.Rows[i]["PQD04"].ToString( ) != "")
                                    PQD4 = Convert.ToInt32( dsele.Rows[i]["PQD04"].ToString( ) );
                                else
                                    PQD4 = 0;
                                if (dsele.Rows[i]["PQD09"].ToString( ) != "")
                                    PQD9 = Convert.ToDecimal( dsele.Rows[i]["PQD09"].ToString( ) );
                                else
                                    PQD9 = 0M;
                                if (dsele.Rows[i]["PQD10"].ToString( ) != "")
                                    PQD010 = Convert.ToInt32( dsele.Rows[i]["PQD10"].ToString( ) );
                                else
                                    PQD010 = 0;

                                if (pqds!=null && pqds.Select( "PQD01='"+ PQD1 + "' AND PQD02='"+ PQD2 + "' AND PQD03='"+ PQD3 + "' AND PQD04='"+ PQD4 + "' AND PQD05='"+ PQD5 + "' AND PQD06='"+ PQD6 + "' AND PQD07='"+ PQD7 + "' AND PQD08='"+ PQD8 + "' AND PQD09='"+ PQD9 + "' AND PQD10='"+ PQD010 + "' AND PQD11='"+ PQD011 + "' AND PQD12='"+ PQD012 + "'" ).Length > 0)
                                {
                                    MessageBox.Show( "已经存在\n\r个数/板:" + PQD1 + "\n\r小工工资/天:" + PQD2 + "\n\r小工日人数:" + PQD3 + "\n\r老师工资:" + PQD4 + "\n\r管理工资(%):" + PQD5 + "\n\r油漆种类:" + PQD6 + "\n\r颜色:" + PQD7 + "\n\r油漆价格/kg:" + PQD8 + "\n\r油漆单价/板:" + PQD9 + "\n\r板数/天:" + PQD010 + "\n\r油漆品牌:" + PQD011 + "\n\r基材:" + PQD012 + "" );
                                }
                                else
                                {
                                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQD (PQD01,PQD02,PQD03,PQD04,PQD05,PQD06,PQD07,PQD08,PQD09,PQD10,PQD11,PQD12) VALUES (@PQD01,@PQD02,@PQD03,@PQD04,@PQD05,@PQD06,@PQD07,@PQD08,@PQD09,@PQD10,@PQD11,@PQD12)", new SqlParameter( "@PQD01", PQD1 ), new SqlParameter( "@PQD02", PQD2 ), new SqlParameter( "@PQD03", PQD3 ), new SqlParameter( "@PQD04", PQD4 ), new SqlParameter( "@PQD05", PQD5 ), new SqlParameter( "@PQD06", PQD6 ), new SqlParameter( "@PQD07", PQD7 ), new SqlParameter( "@PQD08", PQD8 ), new SqlParameter( "@PQD09", PQD9 ), new SqlParameter( "@PQD10", PQD010 ), new SqlParameter( "@PQD11", PQD011 ), new SqlParameter( "@PQD12", PQD012 ) );
                                }
                            }
                            MessageBox.Show( "批量新建数据成功" );
                        }
                        this.Close( );
                    }
                }
                else
                {
                    MessageBox.Show( "您没有修改任何项,请核查" );
                }
            }
            #endregion

            #region 静电 编辑
            else if (pl == "j2")
            {
                DataTable bianj = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQD WHERE PQD08=@PQD08 AND PQD06=@PQD06 AND PQD11=@PQD11 AND PQD07=@PQD07 AND PQD05=@PQD05 AND PQD12=@PQD12", new SqlParameter( "@PQD08", PQD8 ), new SqlParameter( "@PQD06", PQD6 ), new SqlParameter( "@PQD11", PQD011 ), new SqlParameter( "@PQD07", PQD7 ), new SqlParameter( "@PQD05", PQD5 ), new SqlParameter( "@PQD12", PQD012 ) );
                if (bianj.Rows.Count < 1)
                {
                    if (MessageBox.Show( "更改：\n\r" + label1.Text + "" + textBox1.Text + "---->" + comboBox2.Text + "\n\r" + label4.Text + "" + textBox2.Text + "---->" + comboBox3.Text + "\n\r" + label6.Text + "" + textBox3.Text + "---->" + comboBox5.Text + "\n\r" + label8.Text + "" + textBox4.Text + "---->" + comboBox7.Text + "\n\r" + label10.Text + "" + textBox5.Text + "---->" + comboBox9.Text + "\n\r" + label12.Text + "" + textBox6.Text + "---->" + comboBox11.Text + "", "提示", MessageBoxButtons.OKCancel ) == DialogResult.OK)
                    {
                        DataTable dsele = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQD WHERE PQD08=@PQD08 AND PQD06=@PQD06 AND PQD11=@PQD11 AND PQD07=@PQD07 AND PQD05=@PQD05 AND PQD12=@PQD12", new SqlParameter( "@PQD08", PQD08 ), new SqlParameter( "@PQD06", PQD06 ), new SqlParameter( "@PQD11", PQD11 ), new SqlParameter( "@PQD07", PQD07 ), new SqlParameter( "@PQD05", PQD05 ), new SqlParameter( "@PQD12", PQD12 ) );
                        if (dsele.Rows.Count < 1)
                        {
                            MessageBox.Show( "没有查询到\n\r" + label1.Text + "" + PQD08 + "\n\r" + label4.Text + "" + PQD06 + "\n\r" + label6.Text + "" + PQD11 + "\n\r" + label8.Text + "" + PQD07 + "\n\r" + label10.Text + "" + PQD05 + "\n\r" + label12.Text + "" + PQD12 + "\n\r的数据,请核实后再操作" );
                        }
                        else
                        {
                            int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQD SET PQD08=@PQD08,PQD06=@PQD06,PQD11=@PQD11,PQD07=@PQD07,PQD05=@PQD05,PQD12=@PQD12 WHERE PQD08=@PQD8 AND PQD06=@PQD6 AND PQD11=@PQD011 AND PQD07=@PQD7 AND PQD05=@PQD5 AND PQD12=@PQD012", new SqlParameter( "@PQD08", PQD8 ), new SqlParameter( "@PQD06", PQD6 ), new SqlParameter( "@PQD11", PQD011 ), new SqlParameter( "@PQD07", PQD7 ), new SqlParameter( "@PQD05", PQD5 ), new SqlParameter( "@PQD12", PQD012 ), new SqlParameter( "@PQD8", PQD08 ), new SqlParameter( "@PQD6", PQD06 ), new SqlParameter( "@PQD011", PQD11 ), new SqlParameter( "@PQD7", PQD07 ), new SqlParameter( "@PQD5", PQD05 ), new SqlParameter( "@PQD012", PQD12 ) );
                            if (count < 1)
                            {
                                MessageBox.Show( "批量编辑数据失败" );
                            }
                            else
                            {
                                MessageBox.Show( "批量编辑数据成功" );
                                this.Close( );
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show( "已经存在\n\r" + label1.Text + "" + comboBox2.Text + "\n\r" + label4.Text + "" + comboBox3.Text + "\n\r" + label6.Text + "" + comboBox5.Text + "\n\r" + label8.Text + "" + comboBox7.Text + "\n\r" + label10.Text + "" + comboBox9.Text + "\n\r" + label12.Text + "" + comboBox11.Text + "\n\r的数据,请核实后再操作" );
                }
            }
            #endregion

            #region 静电 删除
            else if (pl == "j3")
            {
                if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==

   DialogResult . Cancel )
                    return;
                DataTable bianj = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQD WHERE PQD08=@PQD08 AND PQD06=@PQD06 AND PQD11=@PQD11 AND PQD07=@PQD07 AND PQD05=@PQD05 AND PQD12=@PQD12", new SqlParameter( "@PQD08", PQD08 ), new SqlParameter( "@PQD06", PQD06 ), new SqlParameter( "@PQD11", PQD11 ), new SqlParameter( "@PQD07", PQD07 ), new SqlParameter( "@PQD05", PQD05 ), new SqlParameter( "@PQD12", PQD12 ) );
                if (bianj.Rows.Count > 0)
                {
                    if (MessageBox.Show( "删除：\n\r" + label1.Text + "" + textBox1.Text + "\n\r" + label4.Text + "" + textBox2.Text + "\n\r" + label6.Text + "" + textBox3.Text + "\n\r" + label8.Text + "" + textBox4.Text + "\n\r" + label10.Text + "" + textBox5.Text + "\n\r" + label12.Text + "" + textBox6.Text + "", "提示", MessageBoxButtons.OKCancel ) == DialogResult.OK)
                    {
                        int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQD WHERE PQD08=@PQD08 AND PQD06=@PQD06 AND PQD11=@PQD11 AND PQD07=@PQD07 AND PQD05=@PQD05 AND PQD12=@PQD12", new SqlParameter( "@PQD08", PQD08 ), new SqlParameter( "@PQD06", PQD06 ), new SqlParameter( "@PQD11", PQD11 ), new SqlParameter( "@PQD07", PQD07 ), new SqlParameter( "@PQD05", PQD05 ), new SqlParameter( "@PQD12", PQD12 ) );
                        if (count < 1)
                        {
                            MessageBox.Show( "批量删除数据失败" );
                        }
                        else
                        {
                            MessageBox.Show( "批量删除数据成功" );
                            plde = "1";
                            this.Close( );
                        }
                    }
                }
                else
                {
                    MessageBox.Show( "不存在\n\r" + label1.Text + "" + textBox1.Text + "\n\r" + label4.Text + "" + textBox2.Text + "\n\r" + label6.Text + "" + textBox3.Text + "\n\r" + label8.Text + "" + textBox4.Text + "\n\r" + label10.Text + "" + textBox5.Text + "\n\r" + label12.Text + "" + textBox6.Text + "\n\r的数据,请核实后再操作" );
                }
            }
            #endregion

            #region 浸漆 新建
            else if (pl == "q1")
            {
                DataTable pqes = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQE ORDER BY PQE01" );
                
                if (textBox1.Text != comboBox2.Text || textBox2.Text != comboBox3.Text || textBox3.Text != comboBox5.Text || textBox4.Text != comboBox7.Text || textBox5.Text != comboBox9.Text || textBox6.Text != comboBox11.Text)
                {
                    if (MessageBox.Show( "保留：\n\r" + label1.Text + "" + textBox1.Text + "\n\r" + label4.Text + "" + textBox2.Text + "\n\r" + label6.Text + "" + textBox3.Text + "\n\r" + label8.Text + "" + textBox4.Text + "\n\r" + label10.Text + "" + textBox5.Text + "\n\r" + label12.Text + "" + textBox6.Text + "\n\r\n\r新建：\n\r" + label1.Text + "" + comboBox2.Text + "\n\r" + label4.Text + "" + comboBox3.Text + "\n\r" + label6.Text + "" + comboBox5.Text + "\n\r" + label8.Text + "" + comboBox7.Text + "\n\r" + label10.Text + "" + comboBox9.Text + "\n\r" + label12.Text + "" + comboBox11.Text + "", "提示", MessageBoxButtons.OKCancel ) == DialogResult.OK)
                    {
                        DataTable dsele = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQE WHERE PQE08=@PQE08 AND PQE06=@PQE06 AND PQE11=@PQE11 AND PQE07=@PQE07 AND PQE05=@PQE05 AND PQE12=@PQE12", new SqlParameter( "@PQE08", PQE08 ), new SqlParameter( "@PQE06", PQE06 ), new SqlParameter( "@PQE11", PQE11 ), new SqlParameter( "@PQE07", PQE07 ), new SqlParameter( "@PQE05", PQE05 ), new SqlParameter( "@PQE12", PQE12 ) );
                        if (dsele.Rows.Count < 1)
                        {
                            MessageBox.Show( "没有查询到\n\r" + label1.Text + "" + PQE08 + "\n\r" + label4.Text + "" + PQE06 + "\n\r" + label6.Text + "" + PQE11 + "\n\r" + label8.Text + "" + PQE07 + "\n\r" + label10.Text + "" + PQE05 + "\n\r" + label12.Text + "" + PQE12 + "\n\r的数据,请核实后再操作" );
                        }
                        else
                        {
                            for (int i = 0; i < dsele.Rows.Count; i++)
                            {
                                if (dsele.Rows[i]["PQE01"].ToString( ) != "")
                                    PQE1 = Convert.ToInt32( dsele.Rows[i]["PQE01"].ToString( ) );
                                else
                                    PQE1 = 0;
                                if (dsele.Rows[i]["PQE02"].ToString( ) != "")
                                    PQE2 = Convert.ToInt32( dsele.Rows[i]["PQE02"].ToString( ) );
                                else
                                    PQE2 = 0;
                                if (dsele.Rows[i]["PQE03"].ToString( ) != "")
                                    PQE3 = Convert.ToDecimal( dsele.Rows[i]["PQE03"].ToString( ) );
                                else
                                    PQE3 = 0M;
                                if (dsele.Rows[i]["PQE04"].ToString( ) != "")
                                    PQE4 = Convert.ToDecimal( dsele.Rows[i]["PQE04"].ToString( ) );
                                else
                                    PQE4 = 0;
                                if (dsele.Rows[i]["PQE09"].ToString( ) != "")
                                    PQE9 = Convert.ToDecimal( dsele.Rows[i]["PQE09"].ToString( ) );
                                else
                                    PQE9 = 0M;
                                if (dsele.Rows[i]["PQE10"].ToString( ) != "")
                                    PQE010 = Convert.ToInt32( dsele.Rows[i]["PQE10"].ToString( ) );
                                else
                                    PQE010 = 0;
                                if (pqes != null && pqes.Select( "PQE01='" + PQE1 + "' AND PQE02='" + PQE2 + "' AND PQE03='" + PQE3 + "' AND PQE04='" + PQE4 + "' AND PQE05='" + PQE5 + "' AND PQE06='" + PQE6 + "' AND PQE07='" + PQE7 + "' AND PQE08='" + PQE8 + "' AND PQE09='" + PQE9 + "' AND PQE10='" + PQE010 + "' AND PQE11='" + PQE011 + "' AND PQE12='" + PQE012 + "'" ).Length > 0)
                                {
                                    MessageBox.Show( "已经存在\n\r个数/板:" + PQE1 + "\n\r小工工资/天:" + PQE2 + "\n\r小工日人数:" + PQE3 + "\n\r工资单价/片:" + PQE4 + "\n\r管理工资(%):" + PQE5 + "\n\r油漆种类:" + PQE6 + "\n\r颜色:" + PQE7 + "\n\r油漆价格/kg:" + PQE8 + "\n\r油漆单价/板:" + PQE9 + "\n\r板数/天:" + PQE010 + "\n\r油漆品牌:" + PQE011 + "\n\r基材:" + PQE012 + "" );
                                }
                                else
                                {
                                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQE (PQE01,PQE02,PQE03,PQE04,PQE05,PQE06,PQE07,PQE08,PQE09,PQE10,PQE11,PQE12) VALUES (@PQE01,@PQE02,@PQE03,@PQE04,@PQE05,@PQE06,@PQE07,@PQE08,@PQE09,@PQE10,@PQE11,@PQE12)", new SqlParameter( "@PQE01", PQE1 ), new SqlParameter( "@PQE02", PQE2 ), new SqlParameter( "@PQE03", PQE3 ), new SqlParameter( "@PQE04", PQE4 ), new SqlParameter( "@PQE05", PQE5 ), new SqlParameter( "@PQE06", PQE6 ), new SqlParameter( "@PQE07", PQE7 ), new SqlParameter( "@PQE08", PQE8 ), new SqlParameter( "@PQE09", PQE9 ), new SqlParameter( "@PQE10", PQE010 ), new SqlParameter( "@PQE11", PQE011 ), new SqlParameter( "@PQE12", PQE012 ) );
                                }
                            }
                            MessageBox.Show( "批量新建数据成功" );
                        }
                        this.Close( );
                    }
                }
                else
                {
                    MessageBox.Show( "您没有修改任何项,请核查" );
                }
            }
            #endregion

            #region 浸漆 编辑
            else if (pl == "q2")
            {
                DataTable bianj = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQE WHERE PQE08=@PQE08 AND PQE06=@PQE06 AND PQE11=@PQE11 AND PQE07=@PQE07 AND PQE05=@PQE05 AND PQE12=@PQE12", new SqlParameter( "@PQE08", PQE8 ), new SqlParameter( "@PQE06", PQE6 ), new SqlParameter( "@PQE11", PQE011 ), new SqlParameter( "@PQE07", PQE7 ), new SqlParameter( "@PQE05", PQE5 ), new SqlParameter( "@PQE12", PQE012 ) );
                if (bianj.Rows.Count < 1)
                {
                    if (MessageBox.Show( "更改：\n\r" + label1.Text + "" + textBox1.Text + "---->" + comboBox2.Text + "\n\r" + label4.Text + "" + textBox2.Text + "---->" + comboBox3.Text + "\n\r" + label6.Text + "" + textBox3.Text + "---->" + comboBox5.Text + "\n\r" + label8.Text + "" + textBox4.Text + "---->" + comboBox7.Text + "\n\r" + label10.Text + "" + textBox5.Text + "---->" + comboBox9.Text + "\n\r" + label12.Text + "" + textBox6.Text + "---->" + comboBox11.Text + "", "提示", MessageBoxButtons.OKCancel ) == DialogResult.OK)
                    {
                        DataTable dsele = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQE WHERE PQE08=@PQE08 AND PQE06=@PQE06 AND PQE11=@PQE11 AND PQE07=@PQE07 AND PQE05=@PQE05 AND PQE12=@PQE12", new SqlParameter( "@PQE08", PQE08 ), new SqlParameter( "@PQE06", PQE06 ), new SqlParameter( "@PQE11", PQE11 ), new SqlParameter( "@PQE07", PQE07 ), new SqlParameter( "@PQE05", PQE05 ), new SqlParameter( "@PQE12", PQE12 ) );
                        if (dsele.Rows.Count < 1)
                        {
                            MessageBox.Show( "没有查询到\n\r" + label1.Text + "" + PQE08 + "\n\r" + label4.Text + "" + PQE06 + "\n\r" + label6.Text + "" + PQE11 + "\n\r" + label8.Text + "" + PQE07 + "\n\r" + label10.Text + "" + PQE05 + "\n\r" + label12.Text + "" + PQE12 + "\n\r的数据,请核实后再操作" );
                        }
                        else
                        {
                            int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQE SET PQE08=@PQE08,PQE06=@PQE06,PQE11=@PQE11,PQE07=@PQE07,PQE05=@PQE05,PQE12=@PQE12 WHERE PQE08=@PQE8 AND PQE06=@PQE6 AND PQE11=@PQE011 AND PQE07=@PQE7 AND PQE05=@PQE5 AND PQE12=@PQE012", new SqlParameter( "@PQE08", PQE8 ), new SqlParameter( "@PQE06", PQE6 ), new SqlParameter( "@PQE11", PQE011 ), new SqlParameter( "@PQE07", PQE7 ), new SqlParameter( "@PQE05", PQE5 ), new SqlParameter( "@PQE12", PQE012 ), new SqlParameter( "@PQE8", PQE08 ), new SqlParameter( "@PQE6", PQE06 ), new SqlParameter( "@PQE011", PQE11 ), new SqlParameter( "@PQE7", PQE07 ), new SqlParameter( "@PQE5", PQE05 ), new SqlParameter( "@PQE012", PQE12 ) );
                            if (count < 1)
                            {
                                MessageBox.Show( "批量编辑数据失败" );
                            }
                            else
                            {
                                MessageBox.Show( "批量编辑数据成功" );
                                this.Close( );
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show( "已经存在\n\r" + label1.Text + "" + comboBox2.Text + "\n\r" + label4.Text + "" + comboBox3.Text + "\n\r" + label6.Text + "" + comboBox5.Text + "\n\r" + label8.Text + "" + comboBox7.Text + "\n\r" + label10.Text + "" + comboBox9.Text + "\n\r" + label12.Text + "" + comboBox11.Text + "\n\r的数据,请核实后再操作" );
                }
            }
            #endregion

            #region 浸漆 删除
            else if (pl == "q3")
            {
                if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==

   DialogResult . Cancel )
                    return;
                DataTable bianj = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQE WHERE PQE08=@PQE08 AND PQE06=@PQE06 AND PQE11=@PQE11 AND PQE07=@PQE07 AND PQE05=@PQE05 AND PQE12=@PQE12", new SqlParameter( "@PQE08", PQE08 ), new SqlParameter( "@PQE06", PQE06 ), new SqlParameter( "@PQE11", PQE11 ), new SqlParameter( "@PQE07", PQE07 ), new SqlParameter( "@PQE05", PQE05 ), new SqlParameter( "@PQE12", PQE12 ) );
                if (bianj.Rows.Count > 0)
                {
                    if (MessageBox.Show( "删除：\n\r" + label1.Text + "" + textBox1.Text + "\n\r" + label4.Text + "" + textBox2.Text + "\n\r" + label6.Text + "" + textBox3.Text + "\n\r" + label8.Text + "" + textBox4.Text + "\n\r" + label10.Text + "" + textBox5.Text + "\n\r" + label12.Text + "" + textBox6.Text + "", "提示", MessageBoxButtons.OKCancel ) == DialogResult.OK)
                    {
                        int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQE WHERE PQE08=@PQE08 AND PQE06=@PQE06 AND PQE11=@PQE11 AND PQE07=@PQE07 AND PQE05=@PQE05 AND PQE12=@PQE12", new SqlParameter( "@PQE08", PQE08 ), new SqlParameter( "@PQE06", PQE06 ), new SqlParameter( "@PQE11", PQE11 ), new SqlParameter( "@PQE07", PQE07 ), new SqlParameter( "@PQE05", PQE05 ), new SqlParameter( "@PQE12", PQE12 ) );
                        if (count < 1)
                        {
                            MessageBox.Show( "批量删除数据失败" );
                        }
                        else
                        {
                            MessageBox.Show( "批量删除数据成功" );
                            plde = "1";
                            this.Close( );
                        }
                    }
                }
                else
                {
                    MessageBox.Show( "不存在\n\r" + label1.Text + "" + textBox1.Text + "\n\r" + label4.Text + "" + textBox2.Text + "\n\r" + label6.Text + "" + textBox3.Text + "\n\r" + label8.Text + "" + textBox4.Text + "\n\r" + label10.Text + "" + textBox5.Text + "\n\r" + label12.Text + "" + textBox6.Text + "\n\r的数据,请核实后再操作" );
                }
            }
            #endregion

            #region 封边 新建
            else if (pl == "f1")
            {
                DataTable pqbs = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQB ORDER BY PQB01" );
                
                if (textBox1.Text != comboBox2.Text || textBox2.Text != comboBox3.Text || textBox3.Text != comboBox5.Text || textBox4.Text != comboBox7.Text || textBox5.Text != comboBox9.Text || textBox6.Text != comboBox11.Text || textBox8.Text!=comboBox1.Text)
                {
                    if (MessageBox.Show( "保留：\n\r" + label1.Text + "" + textBox1.Text + "\n\r" + label4.Text + "" + textBox2.Text + "\n\r" + label6.Text + "" + textBox3.Text + "\n\r" + label8.Text + "" + textBox4.Text + "\n\r" + label10.Text + "" + textBox5.Text + "\n\r" + label12.Text + "" + textBox6.Text + "\n\r"+label16.Text+""+ textBox8.Text + "\n\r\n\r新建：\n\r" + label1.Text + "" + comboBox2.Text + "\n\r" + label4.Text + "" + comboBox3.Text + "\n\r" + label6.Text + "" + comboBox5.Text + "\n\r" + label8.Text + "" + comboBox7.Text + "\n\r" + label10.Text + "" + comboBox9.Text + "\n\r" + label12.Text + "" + comboBox11.Text + "\n\r"+label16.Text+""+comboBox1.Text+"", "提示", MessageBoxButtons.OKCancel ) == DialogResult.OK)
                    {
                        DataTable dsele = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQB WHERE PQB09=@PQB09 AND PQB05=@PQB05 AND PQB10=@PQB10 AND PQB06=@PQB06 AND PQB04=@PQB04 AND PQB08=@PQB08 AND PQB12=@PQB12", new SqlParameter( "@PQB09", PQB09 ), new SqlParameter( "@PQB05", PQB05 ), new SqlParameter( "@PQB10", PQB10 ), new SqlParameter( "@PQB06", PQB06 ), new SqlParameter( "@PQB04", PQB04 ),new SqlParameter("@PQB08",PQB08), new SqlParameter( "@PQB12", PQB12 ) );
                        if (dsele.Rows.Count < 1)
                        {
                            MessageBox.Show( "没有查询到\n\r" + label1.Text + "" + PQB09 + "\n\r" + label4.Text + "" + PQB05 + "\n\r" + label6.Text + "" + PQB10 + "\n\r" + label8.Text + "" + PQB06 + "\n\r" + label10.Text + "" + PQB04 + "\n\r" + label12.Text + "" + PQB12 + "\n\r"+label16.Text+""+PQB08+"\n\r的数据,请核实后再操作" );
                        }
                        else
                        {
                            for (int i = 0; i < dsele.Rows.Count; i++)
                            {
                                if (dsele.Rows[i]["PQB01"].ToString( ) != "")
                                    PQB1 = Convert.ToDecimal( dsele.Rows[i]["PQB01"].ToString( ) );
                                else
                                    PQB1 = 0M;
                                if (dsele.Rows[i]["PQB03"].ToString( ) != "")
                                    PQB3 = Convert.ToDecimal( dsele.Rows[i]["PQB03"].ToString( ) );
                                else
                                    PQB3 = 0M;
                                if (dsele.Rows[i]["PQB07"].ToString( ) != "")
                                    PQB7 = Convert.ToDecimal( dsele.Rows[i]["PQB07"].ToString( ) );
                                else
                                    PQB7 = 0M;
                                if (dsele.Rows[i]["PQB11"].ToString( ) != "")
                                    PQB011 = Convert.ToDecimal( dsele.Rows[i]["PQB11"].ToString( ) );
                                else
                                    PQB011 = 0M;

                                if (pqbs!=null && pqbs.Select( "PQB01='" + PQB1 + "' AND PQB03='" + PQB3 + "' AND PQB04='" + PQB4 + "' AND PQB05='" + PQB5 + "' AND PQB06='" + PQB6 + "' AND PQB07='" + PQB7 + "' AND PQB08='" + PQB8 + "' AND PQB09='" + PQB9 + "' AND PQB10='" + PQB010 + "' AND PQB11='"+PQB011+"' AND  PQB12='" + PQB012 + "' " ).Length > 0)
                                {
                                    MessageBox.Show( "已经存在\n\r厚(cm):" + PQB1 + "\n\r工资单价/m²(一底一面):" + PQB3 + "\n\r管理工资(%):" + PQB4 + "\n\r油漆种类:" + PQB5 + "\n\r颜色:" + PQB6 + "\n\r油漆用量/m²:" + PQB7 + "\n\r油漆单价/m²:" + PQB8 + "\n\r油漆价格/kg:" + PQB9 + "\n\r油漆品牌:" + PQB010 + "\n\r工资单价/m²(两底一面):" + PQB011 + "\n\r基材:" + PQB012 + "\n\r" );
                                }
                                else
                                {
                                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQB (PQB01,PQB03,PQB04,PQB05,PQB06,PQB07,PQB08,PQB09,PQB10,PQB11,PQB12) VALUES (@PQB01,@PQB03,@PQB04,@PQB05,@PQB06,@PQB07,@PQB08,@PQB09,@PQB10,@PQB11,@PQB12)", new SqlParameter( "@PQB01", PQB1 ), new SqlParameter( "@PQB03", PQB3 ), new SqlParameter( "@PQB04", PQB4 ), new SqlParameter( "@PQB05", PQB5 ), new SqlParameter( "@PQB06", PQB6 ), new SqlParameter( "@PQB07", PQB7 ), new SqlParameter( "@PQB08", PQB8 ), new SqlParameter( "@PQB09", PQB9 ), new SqlParameter( "@PQB10", PQB010 ), new SqlParameter( "@PQB11", PQB011 ), new SqlParameter( "@PQB12", PQB012 ) );
                                }                               
                            }
                            MessageBox.Show( "批量新建数据成功" );
                        }
                        this.Close( );
                    }
                }
                else
                {
                    MessageBox.Show( "您没有修改任何项,请核查" );
                }
            }
            #endregion

            #region 封边 编辑
            else if (pl == "f2")
            {
                DataTable bianj = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQB WHERE PQB09=@PQB09 AND PQB05=@PQB05 AND PQB10=@PQB10 AND PQB06=@PQB06 AND PQB04=@PQB04 AND PQB08=@PQB08 AND PQB12=@PQB12", new SqlParameter( "@PQB09", PQB9 ), new SqlParameter( "@PQB05", PQB5 ), new SqlParameter( "@PQB10", PQB010 ), new SqlParameter( "@PQB06", PQB6 ), new SqlParameter( "@PQB04", PQB4 ), new SqlParameter( "@PQB08", PQB8 ), new SqlParameter( "@PQB12", PQB012 ) );
                if (bianj.Rows.Count < 1)
                {
                    if (MessageBox.Show( "更改：\n\r" + label1.Text + "" + textBox1.Text + "---->" + comboBox2.Text + "\n\r" + label4.Text + "" + textBox2.Text + "---->" + comboBox3.Text + "\n\r" + label6.Text + "" + textBox3.Text + "---->" + comboBox5.Text + "\n\r" + label8.Text + "" + textBox4.Text + "---->" + comboBox7.Text + "\n\r" + label10.Text + "" + textBox5.Text + "---->" + comboBox9.Text + "\n\r" + label12.Text + "" + textBox6.Text + "---->" + comboBox11.Text + "\n\r"+label16.Text+""+textBox8.Text+"---->"+comboBox1.Text+"", "提示", MessageBoxButtons.OKCancel ) == DialogResult.OK)
                    {
                        DataTable dsele = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQB WHERE PQB09=@PQB09 AND PQB05=@PQB05 AND PQB10=@PQB10 AND PQB06=@PQB06 AND PQB04=@PQB04 AND PQB08=@PQB08 AND PQB12=@PQB12", new SqlParameter( "@PQB09", PQB09 ), new SqlParameter( "@PQB05", PQB05 ), new SqlParameter( "@PQB10", PQB10 ), new SqlParameter( "@PQB06", PQB06 ), new SqlParameter( "@PQB04", PQB04 ),new SqlParameter("@PQB08",PQB08), new SqlParameter( "@PQB12", PQB12 ) );
                        if (dsele.Rows.Count < 1)
                        {
                            MessageBox.Show( "没有查询到\n\r" + label1.Text + "" + PQB09 + "\n\r" + label4.Text + "" + PQB05 + "\n\r" + label6.Text + "" + PQB10 + "\n\r" + label8.Text + "" + PQB06 + "\n\r" + label10.Text + "" + PQB04 + "\n\r" + label12.Text + "" + PQB12 + "\n\r" + label16.Text + "" + PQB08 + "\n\r的数据,请核实后再操作" );
                        }
                        else
                        {
                            int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQB SET PQB09=@PQB09,PQB05=@PQB05,PQB10=@PQB10,PQB06=@PQB06,PQB04=@PQB04,PQB08=@PQB08,PQB12=@PQB12 WHERE PQB09=@PQB9 AND PQB05=@PQB5 AND PQB10=@PQB010 AND PQB06=@PQB6 AND PQB04=@PQB4 AND PQB08=@PQB8 AND PQB12=@PQB012", new SqlParameter( "@PQB09", PQB9 ), new SqlParameter( "@PQB05", PQB5 ), new SqlParameter( "@PQB10", PQB010 ), new SqlParameter( "@PQB06", PQB6 ), new SqlParameter( "@PQB04", PQB4 ), new SqlParameter( "@PQB08", PQB8 ), new SqlParameter( "@PQB12", PQB012 ), new SqlParameter( "@PQB9", PQB09 ), new SqlParameter( "@PQB5", PQB05 ), new SqlParameter( "@PQB010", PQB10 ), new SqlParameter( "@PQB6", PQB06 ), new SqlParameter( "@PQB4", PQB04 ), new SqlParameter( "@PQB8", PQB08 ), new SqlParameter( "@PQB012", PQB12 ) );
                            if (count < 1)
                            {
                                MessageBox.Show( "批量编辑数据失败" );
                            }
                            else
                            {
                                MessageBox.Show( "批量编辑数据成功" );
                                this.Close( );
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show( "已经存在\n\r" + label1.Text + "" + comboBox2.Text + "\n\r" + label4.Text + "" + comboBox3.Text + "\n\r" + label6.Text + "" + comboBox5.Text + "\n\r" + label8.Text + "" + comboBox7.Text + "\n\r" + label10.Text + "" + comboBox9.Text + "\n\r" + label12.Text + "" + comboBox11.Text + "\n\r" + label16.Text + "" + comboBox1.Text + "\n\r的数据,请核实后再操作" );
                }
            }
            #endregion

            #region 封边 删除
            else if (pl == "f3")
            {
                if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==

   DialogResult . Cancel )
                    return;
                DataTable bianj = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQB WHERE PQB09=@PQB09 AND PQB05=@PQB05 AND PQB10=@PQB10 AND PQB06=@PQB06 AND PQB04=@PQB04 AND PQB08=@PQB08 AND PQB12=@PQB12", new SqlParameter( "@PQB09", PQB09 ), new SqlParameter( "@PQB05", PQB05 ), new SqlParameter( "@PQB10", PQB10 ), new SqlParameter( "@PQB06", PQB06 ), new SqlParameter( "@PQB04", PQB04 ), new SqlParameter( "@PQB08", PQB08 ), new SqlParameter( "@PQB12", PQB12 ) );
                if (bianj.Rows.Count > 0)
                {
                    if (MessageBox.Show( "删除：\n\r" + label1.Text + "" + textBox1.Text + "\n\r" + label4.Text + "" + textBox2.Text + "\n\r" + label6.Text + "" + textBox3.Text + "\n\r" + label8.Text + "" + textBox4.Text + "\n\r" + label10.Text + "" + textBox5.Text + "\n\r" + label12.Text + "" + textBox6.Text + "\n\r"+label16.Text+""+textBox8.Text+"", "提示", MessageBoxButtons.OKCancel ) == DialogResult.OK)
                    {
                        int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQB WHERE PQB09=@PQB09 AND PQB05=@PQB05 AND PQB10=@PQB10 AND PQB06=@PQB06 AND PQB04=@PQB04 AND PQB08=@PQB08 AND PQB12=@PQB12", new SqlParameter( "@PQB09", PQB09 ), new SqlParameter( "@PQB05", PQB05 ), new SqlParameter( "@PQB10", PQB10 ), new SqlParameter( "@PQB06", PQB06 ), new SqlParameter( "@PQB04", PQB04 ), new SqlParameter( "@PQB08", PQB08 ), new SqlParameter( "@PQB12", PQB12 ) );
                        if (count < 1)
                        {
                            MessageBox.Show( "批量删除数据失败" );
                        }
                        else
                        {
                            MessageBox.Show( "批量删除数据成功" );
                            plde = "1";
                            this.Close( );
                        }
                    }
                }
                else
                {
                    MessageBox.Show( "不存在\n\r" + label1.Text + "" + textBox1.Text + "\n\r" + label4.Text + "" + textBox2.Text + "\n\r" + label6.Text + "" + textBox3.Text + "\n\r" + label8.Text + "" + textBox4.Text + "\n\r" + label10.Text + "" + textBox5.Text + "\n\r" + label12.Text + "" + textBox6.Text + "\n\r" + label16.Text + "" + textBox8.Text + "\n\r的数据,请核实后再操作" );
                }
            }
            #endregion

            #region 涂布 新建
            else if (pl == "t1")
            {
                DataTable pqcs = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQC ORDER BY PQC01" );
                if (textBox1.Text != comboBox2.Text || textBox2.Text != comboBox3.Text || textBox3.Text != comboBox5.Text || textBox4.Text != comboBox7.Text || textBox5.Text != comboBox9.Text || textBox6.Text != comboBox11.Text|| textBox7.Text!=comboBox13.Text || textBox8.Text!=comboBox1.Text || textBox9.Text!=comboBox4.Text)
                {
                    if (MessageBox.Show( "保留：\n\r" + label1.Text + "" + textBox1.Text + "\n\r" + label4.Text + "" + textBox2.Text + "\n\r" + label6.Text + "" + textBox3.Text + "\n\r" + label8.Text + "" + textBox4.Text + "\n\r" + label10.Text + "" + textBox5.Text + "\n\r" + label12.Text + "" + textBox6.Text + "\n\r"+label14.Text+""+ textBox7.Text+"\n\r"+label16.Text+""+textBox8.Text+"\n\r"+label18.Text+""+textBox9.Text+"\n\r新建：\n\r" + label1.Text + "" + comboBox2.Text + "\n\r" + label4.Text + "" + comboBox3.Text + "\n\r" + label6.Text + "" + comboBox5.Text + "\n\r" + label8.Text + "" + comboBox7.Text + "\n\r" + label10.Text + "" + comboBox9.Text + "\n\r" + label12.Text + "" + comboBox11.Text + "\n\r"+label14.Text+""+comboBox13.Text+"\n\r"+label16.Text+""+comboBox1.Text+"\n\r"+label18.Text+""+comboBox4.Text+"", "提示", MessageBoxButtons.OKCancel ) == DialogResult.OK)
                    {
                        DataTable dsele = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQC WHERE PQC12=@PQC12 AND PQC08=@PQC08 AND PQC13=@PQC13 AND PQC09=@PQC09 AND PQC07=@PQC07 AND PQC14=@PQC14 AND PQC03=@PQC03 AND PQC11=@PQC11 AND PQC06=@PQC06", new SqlParameter( "@PQC12", PQC12 ), new SqlParameter( "@PQC08", PQC08 ), new SqlParameter( "@PQC13", PQC13 ), new SqlParameter( "@PQC09", PQC09 ), new SqlParameter( "@PQC07", PQC07 ), new SqlParameter( "@PQC14", PQC14 ), new SqlParameter( "@PQC03", PQC03 ), new SqlParameter( "@PQC11", PQC11 ) ,new SqlParameter( "@PQC06" ,PQC06 ) );
                        if (dsele.Rows.Count < 1)
                        {
                            MessageBox.Show( "没有查询到\n\r" + label1.Text + "" + PQC12 + "\n\r" + label4.Text + "" + PQC08 + "\n\r" + label6.Text + "" + PQC13 + "\n\r" + label8.Text + "" + PQC09 + "\n\r" + label10.Text + "" + PQC07 + "\n\r" + label12.Text + "" + PQC14 + "\n\r" + label14.Text + "" + PQC03 + "\n\r"+label16.Text+""+PQC11+"\n\r"+label18.Text+""+PQC06+"\n\r的数据,请核实后再操作" );
                        }
                        else
                        {
                            for (int i = 0; i < dsele.Rows.Count; i++)
                            {
                                if (dsele.Rows[i]["PQC01"].ToString( ) != "")
                                    PQC1 = Convert.ToInt32( dsele.Rows[i]["PQC01"].ToString( ) );
                                else
                                    PQC1 = 0;
                                PQC2 = dsele.Rows[i]["PQC02"].ToString( );
                                if (dsele.Rows[i]["PQC04"].ToString( ) != "")
                                    PQC4 = Convert.ToInt32( dsele.Rows[i]["PQC04"].ToString( ) );
                                else
                                    PQC4 = 0;
                                if (dsele.Rows[i]["PQC05"].ToString( ) != "")
                                    PQC5 = Convert.ToDecimal( dsele.Rows[i]["PQC05"].ToString( ) );
                                else
                                    PQC5 = 0M;

                                if (pqcs!=null && pqcs.Select( "PQC01='" + PQC1 + "' AND PQC02='"+PQC2+"' AND PQC03='" + PQC3 + "' AND PQC04='" + PQC4 + "' AND PQC05='" + PQC5 + "' AND PQC06='" + PQC6 + "' AND PQC07='" + PQC7 + "' AND PQC08='" + PQC8 + "' AND PQC09='" + PQC9 + "' AND PQC11='" + PQC011 + "' AND PQC12='" + PQC012 + "' AND PQC13='"+PQC013+"' AND PQC14='"+PQC014+"'" ).Length > 0)
                                {
                                    MessageBox.Show( "已经存在\n\r个数/板:" + PQC1 + "\n\r区间/m²:" + PQC2 + "\n\r大(小)订单:" + PQC3 + "\n\r小工工资/天:" + PQC4 + "\n\r小工日人数:" + PQC5 + "\n\r工资单价/m²:" + PQC6 + "\n\r管理工资(%):" + PQC7 + "\n\r油漆种类:" + PQC8 + "\n\r颜色:" + PQC9 + "\n\r油漆单价/m²:" + PQC011 + "\n\r油漆价格/kg:"+PQC012+"\n\r油漆品牌:"+PQC013+"\n\r基材:"+PQC014+"" );
                                }
                                else
                                {
                                    SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQC (PQC01,PQC02,PQC03,PQC04,PQC05,PQC06,PQC07,PQC08,PQC09,PQC11,PQC12,PQC13,PQC14) VALUES (@PQC01,@PQC02,@PQC03,@PQC04,@PQC05,@PQC06,@PQC07,@PQC08,@PQC09,@PQC11,@PQC12,@PQC13,@PQC14)", new SqlParameter( "@PQC01", PQC1 ), new SqlParameter( "@PQC02", PQC2 ), new SqlParameter( "@PQC03", PQC3 ), new SqlParameter( "@PQC04", PQC4 ), new SqlParameter( "@PQC05", PQC5 ), new SqlParameter( "@PQC06", PQC6 ), new SqlParameter( "@PQC07", PQC7 ), new SqlParameter( "@PQC08", PQC8 ), new SqlParameter( "@PQC09", PQC9 ), new SqlParameter( "@PQC11", PQC011 ), new SqlParameter( "@PQC12", PQC012 ), new SqlParameter( "@PQC13", PQC013 ), new SqlParameter( "@PQC14", PQC014 ) );
                                }
                            }
                            MessageBox.Show( "批量新建数据成功" );
                        }
                        this.Close( );
                    }
                }
                else
                {
                    MessageBox.Show( "您没有修改任何项,请核查" );
                }
            }
            #endregion

            #region 涂布 编辑
            else if (pl == "t2")
            {
                DataTable bianj = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQC WHERE PQC12=@PQC12 AND PQC08=@PQC08 AND PQC13=@PQC13 AND PQC09=@PQC09 AND PQC07=@PQC07 AND PQC14=@PQC14 AND PQC03=@PQC03 AND PQC11=@PQC11 AND PQC06=@PQC06" , new SqlParameter( "@PQC12", PQC012 ), new SqlParameter( "@PQC08", PQC8 ), new SqlParameter( "@PQC13", PQC013 ), new SqlParameter( "@PQC09", PQC9 ), new SqlParameter( "@PQC07", PQC7 ), new SqlParameter( "@PQC14", PQC014 ), new SqlParameter( "@PQC03", PQC3 ), new SqlParameter( "@PQC11", PQC011 ) ,new SqlParameter( "@PQC06" ,PQC6 ) );
                if (bianj.Rows.Count < 1)
                {
                    if (MessageBox.Show( "更改：\n\r" + label1.Text + "" + textBox1.Text + "---->" + comboBox2.Text + "\n\r" + label4.Text + "" + textBox2.Text + "---->" + comboBox3.Text + "\n\r" + label6.Text + "" + textBox3.Text + "---->" + comboBox5.Text + "\n\r" + label8.Text + "" + textBox4.Text + "---->" + comboBox7.Text + "\n\r" + label10.Text + "" + textBox5.Text + "---->" + comboBox9.Text + "\n\r" + label12.Text + "" + textBox6.Text + "---->" + comboBox11.Text + "\n\r"+label14.Text+""+ textBox7.Text+"---->"+comboBox13.Text+"\n\r"+label16.Text+""+textBox8.Text+"---->"+comboBox1.Text+"\n\r"+label18.Text+""+textBox9.Text+"---->"+comboBox4.Text+"", "提示", MessageBoxButtons.OKCancel ) == DialogResult.OK)
                    {
                        DataTable dsele = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQC WHERE PQC12=@PQC12 AND PQC08=@PQC08 AND PQC13=@PQC13 AND PQC09=@PQC09 AND PQC07=@PQC07 AND PQC14=@PQC14 AND PQC03=@PQC03 AND PQC11=@PQC11", new SqlParameter( "@PQC12", PQC12 ), new SqlParameter( "@PQC08", PQC08 ), new SqlParameter( "@PQC13", PQC13 ), new SqlParameter( "@PQC09", PQC09 ), new SqlParameter( "@PQC07", PQC07 ), new SqlParameter( "@PQC14", PQC14 ), new SqlParameter( "@PQC03", PQC03 ), new SqlParameter( "@PQC11", PQC11 ) ,new SqlParameter( "@PQC06" ,PQC06 ) );
                        if (dsele.Rows.Count < 1)
                        {
                            MessageBox.Show( "没有查询到\n\r" + label1.Text + "" + PQC12 + "\n\r" + label4.Text + "" + PQC08 + "\n\r" + label6.Text + "" + PQC13 + "\n\r" + label8.Text + "" + PQC09 + "\n\r" + label10.Text + "" + PQC07 + "\n\r" + label12.Text + "" + PQC14 + "\n\r" + label14.Text + "" + PQC03 + "\n\r" + label16.Text + "" + PQC11 + "\n\r"+label18.Text+""+PQC06+"\n\r的数据,请核实后再操作" );
                        }
                        else
                        {
                            int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQC SET PQC12=@PQC12,PQC08=@PQC08,PQC13=@PQC13,PQC09=@PQC09,PQC07=@PQC07,PQC14=@PQC14,PQC03=@PQC03,PQC11=@PQC11,PQC06=@PQC6 WHERE PQC12=@PQC012 AND PQC08=@PQC8 AND PQC13=@PQC013 AND PQC09=@PQC9 AND PQC07=@PQC7 AND PQC14=@PQC014 AND PQC03=@PQC3 AND PQC11=@PQC011 AND PQC06=@PQC06" ,new SqlParameter( "@PQC12" ,PQC012 ) ,new SqlParameter( "@PQC08" ,PQC8 ) ,new SqlParameter( "@PQC13" ,PQC013 ) ,new SqlParameter( "@PQC09" ,PQC9 ) ,new SqlParameter( "@PQC07" ,PQC7 ) ,new SqlParameter( "@PQC14" ,PQC014 ) ,new SqlParameter( "@PQC03" ,PQC3 ) ,new SqlParameter( "@PQC11" ,PQC011 ) ,new SqlParameter( "@PQC012" ,PQC12 ) ,new SqlParameter( "@PQC8" ,PQC08 ) ,new SqlParameter( "@PQC013" ,PQC13 ) ,new SqlParameter( "@PQC9" ,PQC09 ) ,new SqlParameter( "@PQC7" ,PQC07 ) ,new SqlParameter( "@PQC014" ,PQC14 ) ,new SqlParameter( "@PQC3" ,PQC03 ) ,new SqlParameter( "@PQC011" ,PQC11 ) ,new SqlParameter( "@PQC06" ,PQC06 ) ,new SqlParameter( "@PQC6" ,PQC6 ) );
                            if (count < 1)
                            {
                                MessageBox.Show( "批量编辑数据失败" );
                            }
                            else
                            {
                                MessageBox.Show( "批量编辑数据成功" );
                                this.Close( );
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show( "已经存在\n\r" + label1.Text + "" + comboBox2.Text + "\n\r" + label4.Text + "" + comboBox3.Text + "\n\r" + label6.Text + "" + comboBox5.Text + "\n\r" + label8.Text + "" + comboBox7.Text + "\n\r" + label10.Text + "" + comboBox9.Text + "\n\r" + label12.Text + "" + comboBox11.Text + "\n\r" + label14.Text + "" + comboBox13.Text + "\n\r" + label16.Text + "" + comboBox1.Text + "\n\r"+label18.Text+""+comboBox4.Text+"\n\r的数据,请核实后再操作" );
                }
            }
            #endregion

            #region 涂布 删除
            else if (pl == "t3")
            {
                if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) ==

   DialogResult . Cancel )
                    return;
                DataTable bianj = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQC WHERE PQC12=@PQC12 AND PQC08=@PQC08 AND PQC13=@PQC13 AND PQC09=@PQC09 AND PQC07=@PQC07 AND PQC14=@PQC14 AND PQC03=@PQC03 AND PQC11=@PQC11 AND PQC06=@PQC06" , new SqlParameter( "@PQC12", PQC12 ), new SqlParameter( "@PQC08", PQC08 ), new SqlParameter( "@PQC13", PQC13 ), new SqlParameter( "@PQC09", PQC09 ), new SqlParameter( "@PQC07", PQC07 ), new SqlParameter( "@PQC14", PQC14 ), new SqlParameter( "@PQC03", PQC03 ), new SqlParameter( "@PQC11", PQC11 ) ,new SqlParameter( "@PQC06" ,PQC06 ) );
                if (bianj.Rows.Count > 0)
                {
                    if (MessageBox.Show( "删除：\n\r" + label1.Text + "" + textBox1.Text + "\n\r" + label4.Text + "" + textBox2.Text + "\n\r" + label6.Text + "" + textBox3.Text + "\n\r" + label8.Text + "" + textBox4.Text + "\n\r" + label10.Text + "" + textBox5.Text + "\n\r" + label12.Text + "" + textBox6.Text + "\n\r"+label14.Text+""+ textBox7.Text+"\n\r"+label16.Text+""+textBox8.Text+"", "\n\r"+label18.Text+""+textBox9.Text+"提示", MessageBoxButtons.OKCancel ) == DialogResult.OK)
                    {
                        int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQC WHERE PQC12=@PQC12 AND PQC08=@PQC08 AND PQC13=@PQC13 AND PQC09=@PQC09 AND PQC07=@PQC07 AND PQC14=@PQC14 AND PQC03=@PQC03 AND PQC11=@PQC11  AND PQC06=@PQC06" , new SqlParameter( "@PQC12", PQC12 ), new SqlParameter( "@PQC08", PQC08 ), new SqlParameter( "@PQC13", PQC13 ), new SqlParameter( "@PQC09", PQC09 ), new SqlParameter( "@PQC07", PQC07 ), new SqlParameter( "@PQC14", PQC14 ), new SqlParameter( "@PQC03", PQC03 ), new SqlParameter( "@PQC11", PQC11 ) ,new SqlParameter( "@PQC06" ,PQC06 ) );
                        if (count < 1)
                        {
                            MessageBox.Show( "批量删除数据失败" );
                        }
                        else
                        {
                            MessageBox.Show( "批量删除数据成功" );
                            plde = "1";
                            this.Close( );
                        }
                    }
                }
                else
                {
                    MessageBox.Show( "不存在\n\r" + label1.Text + "" + textBox1.Text + "\n\r" + label4.Text + "" + textBox2.Text + "\n\r" + label6.Text + "" + textBox3.Text + "\n\r" + label8.Text + "" + textBox4.Text + "\n\r" + label10.Text + "" + textBox5.Text + "\n\r" + label12.Text + "" + textBox6.Text + "\n\r" + label14.Text + "" + textBox7.Text + "\n\r" + label16.Text + "" + textBox8.Text + "\n\r" + label18.Text + "" + textBox9.Text + "\n\r的数据,请核实后再操作" );
                }
            }
            #endregion
        }

        private void button3_Click( object sender, EventArgs e )
        {
            this.Close( );
        }

        #region
        //油漆价格/kg
        private void comboBox2_KeyPress( object sender, KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 46) && e.KeyChar != 8)
            {
                MessageBox.Show( "请输入数字" );
                e.Handled = true;
            }
            else if (char.IsPunctuation( e.KeyChar ))
            {
                if (comboBox2.Text.LastIndexOf( '.' ) != -1)
                {
                    e.Handled = true;
                    MessageBox.Show( "只能输入一个小数点" );
                }
            }
        }
        private void comboBox2_TextChanged( object sender, EventArgs e )
        {
            if (comboBox2.Text.Substring( 0 ) == ".")
            {
                comboBox2.Text = "0.";
                comboBox2.SelectionStart = 2;
            }
        }
        private void comboBox2_LostFocus( object sender, EventArgs e )
        {
            if (comboBox2.Text != "" && !DateDayRegise.foreOneNum( comboBox2 ))
            {
                this.comboBox2.Text = "";
                MessageBox.Show( "只允许输入整数部分最多三位,小数部分最多一位,如999.9,请重新输入" );
            }
        }
        //管理工资
        private void comboBox9_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
                MessageBox.Show( "只允许输入整数" );
            }
        }
        //油漆单价/m²
        private void comboBox1_TextChanged( object sender, EventArgs e )
        {
            if (comboBox1.Text.Substring( 0 ) == ".")
            {
                comboBox1.Text = "0.";
                comboBox1.SelectionStart = 2;
            }
        }
        private void comboBox1_KeyPress( object sender, KeyPressEventArgs e )
        {
            //e.KeyChar < 48 || e.KeyChar > 57表示0-9的数字
            //e.KeyChar != 46 表示小数点
            //e.KeyChar != 8 表示退格键
            //e.KeyChar != 3  e.KeyChar != 22 表示复制、粘贴
            if ((e.KeyChar < 48 || e.KeyChar > 57) && (e.KeyChar != 46) && e.KeyChar != 8)
            {
                MessageBox.Show( "请输入数字" );
                e.Handled = true;
            }
            else if (char.IsPunctuation( e.KeyChar ))
            {
                if (comboBox1.Text.LastIndexOf( '.' ) != -1)
                {
                    e.Handled = true;
                    MessageBox.Show( "只能输入一个小数点" );
                }
            }
        }
        private void comboBox1_LostFocus( object sender, EventArgs e )
        {
            if (comboBox1.Text != "" && !DateDayRegise.fiveThreeNum( comboBox1 ))
            {
                this.comboBox1.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多三位,如99.999,请重新输入" );
            }
        }
        //工资单价/m²
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
            if ( comboBox4.Text != "" && !DateDayRegise.fiveThreeNum( comboBox4 ) )
            {
                this.comboBox4.Text = "";
                MessageBox.Show( "只允许输入整数部分最多两位,小数部分最多三位,如99.999, 请重新输入" );
            }
        }
        #endregion
    }
}
