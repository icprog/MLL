using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using StudentMgr;
using Mulaolao.Contract;
using Mulaolao.Class;

namespace Mulaolao.Raw_material_cost
{
    public partial class R_Frmhuaxuepicichenben : FormChild
    {
        public R_Frmhuaxuepicichenben( )
        {
            InitializeComponent( );
        }

        DataTable dg;

        private void R_Frmhuaxuepicichenben_Load( object sender, EventArgs e )
        {
            GroupBox[] gb = new GroupBox[] { groupBox1, groupBox2 };
            Ergodic.FormGroupboxEnableFalse( this, gb );

            toolSelect.Enabled = false;
            toolAdd.Enabled = false;
            toolDelete.Enabled = false;
            toolUpdate.Enabled = false;
            toolPrint.Enabled = true;
            toolReview.Enabled = false;
            toolExport.Enabled = true;
            toolSave.Enabled = false;
            toolCancel.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;

            DataTable da = SqlHelper.ExecuteDataTable( "SELECT YQ10,YQ11,YQ12,YQ22,YQ15,PY11,PY12,PY14,PY15,PY18,PQK09,PQK10 FROM R_PQY A,R_PQI B,R_PQK C WHERE A.PY33 = B.YQ100 AND B.YQ99 = C.PQK07" );
            gridControl1.DataSource = da;

            //喷漆人
            DataTable daq = SqlHelper.ExecuteDataTable( "SELECT DBA002 FROM TPADBA" );
            comboBox1.DataSource = daq;
            comboBox1.DisplayMember = "DBA002";
            //车间
            DataTable che = SqlHelper.ExecuteDataTable( "SELECT PQK04 FROM R_PQK" );
            comboBox2.DataSource = che;
            comboBox2.DisplayMember = "PQK04";
            //每板实际摆放个数
            DataTable shu = SqlHelper.ExecuteDataTable( "SELECT PQK08 FROM R_PQK" );
            comboBox3.DataSource = shu;
            comboBox3.DisplayMember = "PQK08";
            //专库库存量
            DataTable liang = SqlHelper.ExecuteDataTable( "SELECT PQK11 FROM R_PQK" );
            comboBox4.DataSource = liang;
            comboBox4.DisplayMember = "PQK11";
        }
        
        #region  查询
        R_Frmpenselect pl = new R_Frmpenselect( );
        R_Frmlinjian lj = new R_Frmlinjian( );
        string PY33 = "", PQK02 = "";
        //查询
        protected override void select( )
        {
            base.select( );
        
        DataTable dl = SqlHelper.ExecuteDataTable( "SELECT PQF01 ,PQF03 ,PQF04 ,PY33  FROM R_PQK A,R_PQF B,R_PQY C WHERE A.PQK02=B.PQF01 AND A.PQK07=C.PY33  AND A.idx=(SELECT MAX(idx) FROM R_PQK)" );
            if (dl.Rows.Count < 1)
            {
                MessageBox.Show( "没有数据" );
            }
            else
            {
                GroupBox[] gb = new GroupBox[] { groupBox1,groupBox2};
                Ergodic.FormGroupboxEnableFalse( this, gb );

                toolSelect.Enabled = true;
                toolAdd.Enabled = true;
                toolDelete.Enabled = true;
                toolUpdate.Enabled = true;
                toolPrint.Enabled = true;
                toolReview.Enabled = false;
                toolExport.Enabled = true;
                toolSave.Enabled = false;
                toolCancel.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
                button5.Enabled = false;
                button6.Enabled = false;
                button7.Enabled = false;

                pl.gridControl1.DataSource = dl;
                pl.str = "4";
                pl.PassDataBetweenForm += new R_Frmpenselect.PassDataBetweenFomrHandler( pl_PassDataBetweenForm );
                pl.StartPosition = FormStartPosition.CenterScreen;
                pl.ShowDialog( );

                if (textBox1.Text == "")
                {
                    MessageBox.Show( "您没有选择任何数据" );
                }
                else
                {
                    DataTable dt = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQK WHERE PQK02=@PQK02 AND PQK07=@PQK07 AND idx=(SELECT MAX(idx) FROM R_PQK)", new SqlParameter( "@PQK02", textBox1.Text ), new SqlParameter( "@PQK07", PY33 ) );
                    if (dt.Rows.Count < 1)
                    {
                        Ergodic.FormEvery( this );
                        gridControl1.DataSource = null;
                    }
                    else
                    {
                        comboBox1.Text = dt.Rows[0]["PQK03"].ToString( );
                        comboBox2.Text = dt.Rows[0]["PQK04"].ToString( );
                        dateTimePicker1.Value = Convert.ToDateTime( dt.Rows[0]["PQK05"] );
                        dateTimePicker2.Value = Convert.ToDateTime( dt.Rows[0]["PQK06"] );

                        DataTable di = SqlHelper.ExecuteDataTable( "SELECT DISTINCT YQ06 FROM R_PQI WHERE YQ99=@YQ99", new SqlParameter( "@YQ99", PY33 ) );
                        if (di.Rows.Count > 1)
                        {
                            textBox4.Text = di.Rows[0]["YQ06"].ToString( );
                        }

                         dg = SqlHelper.ExecuteDataTable( "SELECT  YQ10 ,YQ11 ,YQ12 ,PY22 ,PY10 , YQ15 , PY14 , PY18 , PY11 ,PY15 , PY12 , YQ14 , YQ13 ,YQ16 , PQK08 , PQK09 , PQK10 ,PQK11  FROM R_PQI A, R_PQY B, R_PQK C WHERE  A.YQ03 = B.PY01 AND C.PQK07 = B.PY25 AND PQK02 = @PQK02", new SqlParameter( "@PQK02", textBox1.Text ) );
                        if (dg.Rows.Count < 1)
                        {
                            gridControl1.DataSource = null;
                        }
                        else
                        {
                            gridControl1.DataSource = dg;
                        }
                    }
                }
            }
        }
        //流水号查询
        private void button1_Click( object sender, EventArgs e )
        {
            DataTable da = SqlHelper.ExecuteDataTable( "SELECT PQF01 ,PQF03 ,PQF04 ,YQ06  FROM R_PQI A,R_PQF B WHERE B.PQF01=A.YQ03" );
            if (da.Rows.Count < 1)
            {
                MessageBox.Show( "没有产品信息" );
            }
            else
            {
                pl.gridControl1.DataSource = da;
                pl.str = "3";
                pl.PassDataBetweenForm += new R_Frmpenselect.PassDataBetweenFomrHandler( pl_PassDataBetweenForm );
                pl.StartPosition = FormStartPosition.CenterScreen;
                pl.ShowDialog( );
            }
        }
        private void pl_PassDataBetweenForm( object sender, PassDataWinFormEventArgs e )
        {
            PQK02 = e.ConOne;
            textBox1.Text = e.ConOne;
            textBox2.Text = e.ConTwo;
            textBox3.Text = e.ConTre;
            textBox4.Text = e.ConFor;

            PY33 = e.ConFiv;
        }
        //零件查询
        private void button2_Click( object sender, EventArgs e )
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show( "请选择流水号等产品信息" );
            }
            else
            {
                DataTable de = SqlHelper.ExecuteDataTable( "SELECT  YQ10, YQ11, YQ12, PY22, PY10, YQ15, PY14, PY18, PY11, PY15, PY12, YQ14, YQ13, YQ16 FROM R_PQI A, R_PQY B WHERE A.YQ03 = B.PY01 AND YQ03 = @YQ03 ORDER BY YQ03 DESC", new SqlParameter( "@YQ03",textBox1.Text) );
                if (de.Rows.Count < 1)
                {
                    MessageBox.Show( "没有零件信息" );
                }
                else
                {
                    lj.gridControl1.DataSource = de;
                    lj.lin = "1";
                    lj.PassDataBetweenForm += new R_Frmlinjian.PassDataBetweenFormHandler( lj_PassDataBetweenForm );
                    lj.StartPosition = FormStartPosition.CenterScreen;
                    lj.ShowDialog( );
                }
            }
        }
        private void lj_PassDataBetweenForm( object sender, PassDataWinFormEventArgs e )
        {
            YQ010 = e.ConOne;
            YQ011 = e.ConTwo;
            YQ012 = e.ConTre;
            YQ013 = Convert.ToInt32( e.ConFor );
            YQ014 = Convert.ToDecimal( e.ConFiv );
            YQ015 = Convert.ToDecimal( e.ConSix );
            YQ016 = Convert.ToDecimal( e.ConSev );
            PY010 = Convert.ToInt64( e.ConEgi );
            PY011 = Convert.ToInt32( e.ConNin );
            PY012 = Convert.ToInt32( e.ConTen );
            PY014 = Convert.ToInt32( e.ConEleven );
            PY015 = Convert.ToInt32( e.ConTwelve );
            PY018 = Convert.ToInt32( e.ConThirteen );
            PY022 = e.ConFourteen;
            textBox5.Text = e.ConOne;
        }
        //实入库量查询
        private void button3_Click( object sender, EventArgs e )
        {

        }
        //实领部件总用漆量(kg)
        private void button4_Click( object sender, EventArgs e )
        {

        }
        #endregion

        #region  主体
        string saves = "";
        string PQK03 = "", PQK04 = "";
        DateTime PQK05 = System.DateTime.Now, PQK06 = System.DateTime.Now;
        //新增
        private void toolAdd_Click( object sender, EventArgs e )
        {
            toolSelect.Enabled = false;
            toolAdd.Enabled = false;
            toolDelete.Enabled = false;
            toolUpdate.Enabled = false;
            toolPrint.Enabled = true;
            toolReview.Enabled = false;
            toolExport.Enabled = true;
            toolSave.Enabled = true;
            toolCancel.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;

            saves = "1";
        }
        //删除
        protected override void delete( )
        {
            base.delete( );
        
            if (textBox1.Text == "")
            {
                MessageBox.Show( "流水号不可为空,请选择" );
            }
            else
            {
                int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQK WHERE PQK02=@PQK02", new SqlParameter( "@PQK02", textBox1.Text ) );
                if (count < 1)
                {
                    MessageBox.Show( "删除数据失败" );
                }
                else
                {
                    MessageBox.Show( "成功删除数据" );

                    Ergodic.FormEvery( this );
                    GroupBox[] gb = new GroupBox[] { groupBox1, groupBox2 };
                    Ergodic.FormGroupboxEnableFalse( this, gb );

                    toolSelect.Enabled = true;
                    toolAdd.Enabled = true;
                    toolDelete.Enabled = false;
                    toolUpdate.Enabled = false;
                    toolPrint.Enabled = true;
                    toolReview.Enabled = false;
                    toolExport.Enabled = true;
                    toolSave.Enabled = false;
                    toolCancel.Enabled = false;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    button5.Enabled = false;
                    button6.Enabled = false;
                    button7.Enabled = false;
                }
            }
        }
        //更改
        protected override void update( )
        {
            base.update( );
        
        toolSelect.Enabled = false;
            toolAdd.Enabled = false;
            toolDelete.Enabled = false;
            toolUpdate.Enabled = false;
            toolPrint.Enabled = true;
            toolReview.Enabled = false;
            toolExport.Enabled = true;
            toolSave.Enabled = true;
            toolCancel.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;

            saves = "2";
        }
        //送审
        protected override void revirw( )
        {
            base.revirw( );
        }
        //打印
        protected override void print( )
        {
            base.print( );
        }
        //保存
        protected override void save( )
        {
            base.save( );
        
            if (textBox1.Text == "")
            {
                MessageBox.Show( "请选择流水号" );
            }
            else
            {
                PQK03 = comboBox1.Text;
                PQK04 = comboBox2.Text;
                PQK05 = dateTimePicker1.Value;
                PQK06 = dateTimePicker2.Value;

                DataTable dae = SqlHelper.ExecuteDataTable( "SELECT * FROM R_PQK WHERE PQK02=@PQK02", new SqlParameter( "@PQK02", textBox1.Text ) );
                if (dae.Rows.Count < 1)
                {
                    int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQK (PQK02,PQK03,PQK04,PQK05,PQK06) VALUES (@PQK02,@PQK03,@PQK04,@PQK05,@PQK06)", new SqlParameter( "@PQK02", textBox1.Text ), new SqlParameter( "@PQK03", PQK03 ), new SqlParameter( "@PQK04", PQK04 ), new SqlParameter( "@PQK05", PQK05 ), new SqlParameter( "@PQK06", PQK06 ) );
                    if (count < 1)
                    {
                        MessageBox.Show( "录入数据失败" );
                    }
                    else
                    {
                        MessageBox.Show( "成功录入数据" );

                        GroupBox[] gb = new GroupBox[] { groupBox1, groupBox2 };
                        Ergodic.FormGroupboxEnableFalse( this, gb );

                        toolSelect.Enabled = true;
                        toolAdd.Enabled = true;
                        toolDelete.Enabled = false;
                        toolUpdate.Enabled = false;
                        toolPrint.Enabled = true;
                        toolReview.Enabled = false;
                        toolExport.Enabled = true;
                        toolSave.Enabled = false;
                        toolCancel.Enabled = false;
                        button1.Enabled = false;
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button5.Enabled = false;
                        button6.Enabled = false;
                        button7.Enabled = false;
                    }
                }
                else
                {
                    if (dae.Select( "PQK02='" + textBox1.Text + "'" ).Length > 0)
                    {
                        int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQK SET PQK03=@PQK03,PQK04=@PQK04,PQK05=@PQK05,PQK06=@PQK06 WHERE PQK02=@PQK02", new SqlParameter( "@PQK02", textBox1.Text ), new SqlParameter( "@PQK03", PQK03 ), new SqlParameter( "@PQK04", PQK04 ), new SqlParameter( "@PQK05", PQK05 ), new SqlParameter( "@PQK06", PQK06 ) );
                        if (count < 1)
                        {
                            MessageBox.Show( "录入数据失败" );
                        }
                        else
                        {
                            MessageBox.Show( "成功录入数据" );

                            GroupBox[] gb = new GroupBox[] { groupBox1, groupBox2 };
                            Ergodic.FormGroupboxEnableFalse( this, gb );

                            toolSelect.Enabled = true;
                            toolAdd.Enabled = true;
                            toolDelete.Enabled = false;
                            toolUpdate.Enabled = false;
                            toolPrint.Enabled = true;
                            toolReview.Enabled = false;
                            toolExport.Enabled = true;
                            toolSave.Enabled = false;
                            toolCancel.Enabled = false;
                            button1.Enabled = false;
                            button2.Enabled = false;
                            button3.Enabled = false;
                            button4.Enabled = false;
                            button5.Enabled = false;
                            button6.Enabled = false;
                            button7.Enabled = false;
                        }
                    }
                    else
                    {
                        int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQK (PQK02,PQK03,PQK04,PQK05,PQK06) VALUES (@PQK02,@PQK03,@PQK04,@PQK05,@PQK06)", new SqlParameter( "@PQK02", textBox1.Text ), new SqlParameter( "@PQK03", PQK03 ), new SqlParameter( "@PQK04", PQK04 ), new SqlParameter( "@PQK05", PQK05 ), new SqlParameter( "@PQK06", PQK06 ) );
                        if (count < 1)
                        {
                            MessageBox.Show( "录入数据失败" );
                        }
                        else
                        {
                            MessageBox.Show( "成功录入数据" );

                            GroupBox[] gb = new GroupBox[] { groupBox1, groupBox2 };
                            Ergodic.FormGroupboxEnableFalse( this, gb );

                            toolSelect.Enabled = true;
                            toolAdd.Enabled = true;
                            toolDelete.Enabled = false;
                            toolUpdate.Enabled = false;
                            toolPrint.Enabled = true;
                            toolReview.Enabled = false;
                            toolExport.Enabled = true;
                            toolSave.Enabled = false;
                            toolCancel.Enabled = false;
                            button1.Enabled = false;
                            button2.Enabled = false;
                            button3.Enabled = false;
                            button4.Enabled = false;
                            button5.Enabled = false;
                            button6.Enabled = false;
                            button7.Enabled = false;
                        }
                    }
                }
            }

        }
        //取消
        protected override void cancel( )
        {
            base.cancel( );
        
        GroupBox[] gb = new GroupBox[] { groupBox1, groupBox2 };
            Ergodic.FormGroupboxEnableFalse( this, gb );

            toolSelect.Enabled = true;
            toolAdd.Enabled = true;
            toolDelete.Enabled = false;
            toolUpdate.Enabled = false;
            toolPrint.Enabled = true;
            toolReview.Enabled = false;
            toolExport.Enabled = true;
            toolSave.Enabled = false;
            toolCancel.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
        }
        #endregion

        #region 表格
        int PQK8 = 0;
        long PQK9 = 0, PQK010 = 0, PQK011 = 0;
        string PQK7 = "";
        //新建
        private void button5_Click( object sender, EventArgs e )
        {
            PQK7 = textBox5.Text;
            if (comboBox3.Text != "")
            {
                PQK8 = Convert.ToInt32( comboBox3.Text );
            }
            if (textBox7.Text != "")
            {
                PQK9 = Convert.ToInt64( textBox7.Text );
            }
            if (textBox8.Text != "")
            {
                PQK010 = Convert.ToInt64( textBox8.Text );
            }
            if (comboBox4.Text != "")
            {
                PQK011 = Convert.ToInt64( comboBox4.Text );
            }     
            if (textBox1.Text == "")
            {
                MessageBox.Show( "流水号不可为空" );
            }
            else
            {
                int count = SqlHelper.ExecuteNonQuery( "INSERT INTO R_PQK (PQK02,PQK07,PQK08,PQK09,PQK10,PQK11) VALUES (@PQK02,@PQK07,@PQK08,@PQK09,@PQK10,@PQK11)", new SqlParameter( "@PQK02", textBox1.Text ),new SqlParameter("@PQK07",PQK7), new SqlParameter( "@PQK08", PQK8 ), new SqlParameter( "@PQK09", PQK9 ), new SqlParameter( "@PQK10", PQK010 ), new SqlParameter( "@PQK11", PQK011 ) );
                if (count < 1)
                {
                    MessageBox.Show( "录入数据失败" );
                }
                else
                {
                    DataRow row;
                    if (saves == "1")
                    {
                        DataTable dgh = SqlHelper.ExecuteDataTable( "SELECT  YQ10 ,YQ11 ,YQ12 ,PY22 ,PY10 , YQ15 , PY14 , PY18 , PY11 ,PY15 , PY12 , YQ14 , YQ13 ,YQ16 , PQK08 , PQK09 , PQK10 ,PQK11  FROM R_PQI A, R_PQY B, R_PQK C WHERE  A.YQ03 = B.PY01 AND C.PQK07 = B.PY25 AND PQK02 = @PQK02", new SqlParameter( "@PQK02", textBox1.Text ) );
                        gridControl1.DataSource = dgh;
                    }
                    else if (saves == "2")
                    {
                        row = dg.NewRow( );
                        row["YQ10"] = YQ010;
                        row["YQ11"] = YQ011;
                        row["YQ12"] = YQ012;
                        row["YQ13"] = YQ013;
                        row["YQ14"] = YQ014;
                        row["YQ15"] = YQ015;
                        row["YQ16"] = YQ016;
                        row["PY10"] = PY010;
                        row["PY11"] = PY011;
                        row["PY12"] = PY012;
                        row["PY14"] = PY014;
                        row["PY15"] = PY015;
                        row["PY18"] = PY018;
                        row["PY22"] = PY022;
                        row["PQK08"] = PQK8;
                        row["PQK09"] = PQK9;
                        row["PQK10"] = PQK010;
                        row["PQK11"] = PQK011;
                        dg.Rows.Add( row );
                    }
                    MessageBox.Show( "成功录入数据" );

                    //每板实际摆放个数
                    DataTable shu = SqlHelper.ExecuteDataTable( "SELECT PQK08 FROM R_PQK" );
                    comboBox3.DataSource = shu;
                    comboBox3.DisplayMember = "PQK08";
                    //专库库存量
                    DataTable liang = SqlHelper.ExecuteDataTable( "SELECT PQK11 FROM R_PQK" );
                    comboBox4.DataSource = liang;
                    comboBox4.DisplayMember = "PQK11";
                }
            }
        }
        //编辑
        private void button6_Click( object sender, EventArgs e )
        {
            PQK7 = textBox5.Text;
            if (comboBox3.Text != "")
            {
                PQK8 = Convert.ToInt32( comboBox3.Text );
            }
            if (textBox7.Text != "")
            {
                PQK9 = Convert.ToInt64( textBox7.Text );
            }
            if (textBox8.Text != "")
            {
                PQK010 = Convert.ToInt64( textBox8.Text );
            }
            if (comboBox4.Text != "")
            {
                PQK011 = Convert.ToInt64( comboBox4.Text );
            }
            int num = bandedGridView1.FocusedRowHandle;
            if (textBox1.Text == "")
            {
                MessageBox.Show( "流水号不可为空" );
            }
            else
            {
                int count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQK SET PQK07=@PQK7,PQK08=@PQK08,PQK09=@PQK09,PQK10=@PQK10,PQK11=@PQK11 WHERE PQK02=@PQK02 AND PQK07=@PQK07", new SqlParameter( "@PQK02", textBox1.Text ), new SqlParameter( "@PQK07", ljmc ),new SqlParameter("@PQK7",PQK7), new SqlParameter( "@PQK08", PQK8 ), new SqlParameter( "@PQK09", PQK9 ), new SqlParameter( "@PQK10", PQK010 ), new SqlParameter( "@PQK11", PQK011 ) );
                if (count < 1)
                {
                    MessageBox.Show( "编辑数据失败" );
                }
                else
                {
                    DataRow row;
                    if (saves == "1")
                    {
                        DataTable dgh = SqlHelper.ExecuteDataTable( "SELECT  YQ10 ,YQ11 ,YQ12 ,PY22 ,PY10 , YQ15 , PY14 , PY18 , PY11 ,PY15 , PY12 , YQ14 , YQ13 ,YQ16 , PQK08 , PQK09 , PQK10 ,PQK11  FROM R_PQI A, R_PQY B, R_PQK C WHERE  A.YQ03 = B.PY01 AND C.PQK07 = B.PY25 AND PQK02 = @PQK02", new SqlParameter( "@PQK02", textBox1.Text ) );
                        gridControl1.DataSource = dgh;                       
                    }
                    else if (saves == "2")
                    {
                        row = dg.Rows[num];
                        row.BeginEdit( );
                        row["YQ10"] = YQ010;
                        row["YQ11"] = YQ011;
                        row["YQ12"] = YQ012;
                        row["YQ13"] = YQ013;
                        row["YQ14"] = YQ014;
                        row["YQ15"] = YQ015;
                        row["YQ16"] = YQ016;
                        row["PY10"] = PY010;
                        row["PY11"] = PY011;
                        row["PY12"] = PY012;
                        row["PY14"] = PY014;
                        row["PY15"] = PY015;
                        row["PY18"] = PY018;
                        row["PY22"] = PY022;
                        row["PQK08"] = PQK8;
                        row["PQK09"] = PQK9;
                        row["PQK10"] = PQK010;
                        row["PQK11"] = PQK011;
                        row.EndEdit( );
                    }
                    MessageBox.Show( "编辑数据成功" );

                    //每板实际摆放个数
                    DataTable shu = SqlHelper.ExecuteDataTable( "SELECT PQK08 FROM R_PQK" );
                    comboBox3.DataSource = shu;
                    comboBox3.DisplayMember = "PQK08";
                    //专库库存量
                    DataTable liang = SqlHelper.ExecuteDataTable( "SELECT PQK11 FROM R_PQK" );
                    comboBox4.DataSource = liang;
                    comboBox4.DisplayMember = "PQK11";
                }
            }
        }
        //删除
        private void button7_Click( object sender, EventArgs e )
        {
            int num = bandedGridView1.FocusedRowHandle;
            if (textBox1.Text == "")
            {
                MessageBox.Show( "流水号不可为空" );
            }
            else
            {
                int count = SqlHelper.ExecuteNonQuery( "DELETE FROM R_PQK WHERE PQK02=@PQK02 AND PQK07=@PQK07", new SqlParameter( "@PQK02", PQK02 ), new SqlParameter( "@PQK07", ljmc ) );
                if (count < 1)
                {
                    MessageBox.Show( "删除数据失败" );
                }
                else
                {
                    if (saves == "1")
                    {
                        DataTable dgh = SqlHelper.ExecuteDataTable( "SELECT  YQ10 ,YQ11 ,YQ12 ,PY22 ,PY10 , YQ15 , PY14 , PY18 , PY11 ,PY15 , PY12 , YQ14 , YQ13 ,YQ16 , PQK08 , PQK09 , PQK10 ,PQK11  FROM R_PQI A, R_PQY B, R_PQK C WHERE  A.YQ03 = B.PY01 AND C.PQK07 = B.PY25 AND PQK02 = @PQK02", new SqlParameter( "@PQK02", textBox1.Text ) );
                        gridControl1.DataSource = dgh;
                    }
                    else if(saves=="2")
                    {
                        dg.Rows.RemoveAt( num );
                    }
                    MessageBox.Show( "成功删除数据" );

                    //每板实际摆放个数
                    DataTable shu = SqlHelper.ExecuteDataTable( "SELECT PQK08 FROM R_PQK" );
                    comboBox3.DataSource = shu;
                    comboBox3.DisplayMember = "PQK08";
                    //专库库存量
                    DataTable liang = SqlHelper.ExecuteDataTable( "SELECT PQK11 FROM R_PQK" );
                    comboBox4.DataSource = liang;
                    comboBox4.DisplayMember = "PQK11";
                }
            }
        }
        #endregion

        #region  事件
        string YQ010 = "", YQ011 = "", YQ012 = "", PY022 = "";
        int YQ013 = 0, PY011 = 0, PY012 = 0, PY014 = 0, PY015 = 0, PY018 = 0;
        decimal YQ014 = 0M, YQ015 = 0M, YQ016 = 0M;
        long PY010 = 0;
        //每板实际摆放个数
        private void comboBox3_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
                MessageBox.Show( "只允许输入整数" );
            }
        }
        //专库库存量
        private void comboBox4_KeyPress( object sender, KeyPressEventArgs e )
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8)
            {
                e.Handled = true;
                MessageBox.Show( "只允许输入整数" );
            }
        }

        string ljmc = "", gy = "";
        private void bandedGridView1_FocusedRowChanged( object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e )
        {
            if (bandedGridView1.RowCount < 1)
            {
                Ergodic.GroupboxEvery( groupBox2 );
            }
            else
            {
                textBox5.Text = bandedGridView1.GetRowCellValue( e.FocusedRowHandle, "YQ10" ).ToString( );
                comboBox3.Text = bandedGridView1.GetRowCellValue( e.FocusedRowHandle, "PQK08" ).ToString( );
                textBox7.Text = bandedGridView1.GetRowCellValue( e.FocusedRowHandle, "PQK09" ).ToString( );
                textBox8.Text = bandedGridView1.GetRowCellValue( e.FocusedRowHandle, "PQK10" ).ToString( );
                comboBox4.Text = bandedGridView1.GetRowCellValue( e.FocusedRowHandle, "PQK11" ).ToString( );
                ljmc = textBox5.Text;
                gy= bandedGridView1.GetRowCellValue( e.FocusedRowHandle, "YQ11" ).ToString( );
            }
        }
        private void bandedGridView1_Click( object sender, EventArgs e )
        {
            if (bandedGridView1.RowCount == 1)
            {
                textBox5.Text = bandedGridView1.GetFocusedRowCellValue( "YQ10" ).ToString( );
                comboBox3.Text = bandedGridView1.GetFocusedRowCellValue( "PQK08" ).ToString( );
                textBox7.Text = bandedGridView1.GetFocusedRowCellValue( "PQK09" ).ToString( );
                textBox8.Text = bandedGridView1.GetFocusedRowCellValue( "PQK10" ).ToString( );
                comboBox4.Text = bandedGridView1.GetFocusedRowCellValue( "PQK11" ).ToString( );
                ljmc = textBox5.Text;
                gy = bandedGridView1.GetFocusedRowCellValue( "YQ11" ).ToString( );
            }
        }
        #endregion
    }
}
