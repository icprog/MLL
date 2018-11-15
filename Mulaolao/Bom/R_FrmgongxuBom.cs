using System;
using System . Data;
using System . Windows . Forms;
using Mulaolao . Class;
using StudentMgr;
using System . Text;

namespace Mulaolao . Bom
{
    public partial class R_FrmgongxuBom : Form
    {
        public R_FrmgongxuBom (Form1 fm )
        {
            this. MdiParent = fm;
            InitializeComponent ( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this . gridView1 } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }

        DataTable da;
        DataRow row;
        private void R_FrmgongxuBom_Load ( object sender , EventArgs e )
        {
            GridViewMoHuSelect. SetFilter ( this. gridView1 );
            da = SqlHelper. ExecuteDataTable ( "SELECT idx,GX02,GX01,GX03,GX04,GX05 FROM R_PQAA ORDER BY GX05" );
            comboBox1. DataSource = da;
            comboBox1. DisplayMember = "GX02";
            comboBox1. ValueMember = "GX01";
            comboBox2.DataSource = da.DefaultView.ToTable( true ,"GX04" );
            comboBox2.DisplayMember = "GX04";

            gridControl1. DataSource = da;
        }

        private void comboBox1_SelectedValueChanged ( object sender , EventArgs e )
        {
            if ( comboBox1.Text != "" && da.Select( "GX02='" + comboBox1.Text + "'" ).Length > 0 )
            {
                textBox1.Text = comboBox1.SelectedValue.ToString( );
            }               
        }
        string GX2 = "", GX4 = "";
        int GX1 = 0, GX5 = 0,id=0;
        long GX3 = 0;
        //新建
        private void button1_Click ( object sender , EventArgs e )
        {
            if ( comboBox1. Text == "" )
                MessageBox. Show ( "请输入工序名称" );
            else
            {
                GX2 = comboBox1. Text;
                GX3 = string.IsNullOrEmpty( textBox2.Text ) == true ? 0 : Convert.ToInt64( textBox2.Text );
                GX4 = comboBox2.Text;
                GX5 = string.IsNullOrEmpty( textBox3.Text ) == true ? 0 : Convert.ToInt32( textBox3.Text );
                DataTable de = SqlHelper. ExecuteDataTable ( "SELECT * FROM R_PQAA WHERE GX02=@GX02" , new System. Data. SqlClient. SqlParameter ( "@GX02" , GX2 ) );
                if ( de. Rows. Count > 0 )
                {
                    MessageBox. Show ( "已经存在" + GX2 + "的工序名称，请核实后再录入" );
                }
                else
                {
                    DataTable dr = SqlHelper. ExecuteDataTable ( "SELECT  GX01 FROM R_PQAA ORDER BY GX01 DESC" );
                    if ( dr. Rows. Count < 1 )
                    {
                        GX1 = 10001;
                    }
                    else
                    {
                        GX1 = Convert. ToInt32 ( dr. Compute ( "MAX(GX01)" , "" ) ) + 1;
                        //GX1 = Convert. ToInt32 ( dr. Rows [0] ["GX01"]. ToString ( ) ) + 1;
                    }
                    
                    int count = SqlHelper. ExecuteNonQuery ( "INSERT INTO R_PQAA (GX01,GX02,GX03,GX04,GX05) VALUES (@GX01,@GX02,@GX03,@GX04,@GX05)" , new System. Data. SqlClient. SqlParameter ( "@GX01" , GX1 ) , new System. Data. SqlClient. SqlParameter ( "@GX02" , GX2 ) ,new System.Data.SqlClient.SqlParameter( "@GX03" ,GX3 ) ,new System.Data.SqlClient.SqlParameter( "@GX04" ,GX4 ) ,new System.Data.SqlClient.SqlParameter( "@GX05" ,GX5 ) );
                    if ( count < 1 )
                    {
                        MessageBox. Show ( "录入数据失败" );
                    }
                    else
                    {
                        MessageBox. Show ( "成功录入数据" );

                        DataRow row;
                        row = da. NewRow ( );
                        row ["GX01"] = GX1;
                        row ["GX02"] = GX2;
                        row["GX03"] = GX3;
                        row["GX04"] = GX4;
                        row["GX05"] = GX5;
                        da. Rows. Add ( row );
                    }
                }
            }
        }
        //编辑
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( comboBox1 . Text ) )
            {
                MessageBox . Show ( "请输入工序名称" );
                return;
            }
            GX2 = comboBox1 . Text;
            GX3 = string . IsNullOrEmpty ( textBox2 . Text ) == true ? 0 : Convert . ToInt64 ( textBox2 . Text );
            GX4 = comboBox2 . Text;
            GX5 = string . IsNullOrEmpty ( textBox3 . Text ) == true ? 0 : Convert . ToInt32 ( textBox3 . Text );
            GX1 = string . IsNullOrEmpty ( textBox1 . Text ) == true ? 0 : Convert . ToInt32 ( textBox1 . Text );

            if ( gOne . Equals ( GX2 ) )
            {
                int count = SqlHelper . ExecuteNonQuery ( "UPDATE R_PQAA SET GX03=@GX03,GX04=@GX04,GX05=@GX05 WHERE idx=@id" ,new System . Data . SqlClient . SqlParameter ( "@id" ,id ) ,new System . Data . SqlClient . SqlParameter ( "@GX03" ,GX3 ) ,new System . Data . SqlClient . SqlParameter ( "@GX04" ,GX4 ) ,new System . Data . SqlClient . SqlParameter ( "@GX05" ,GX5 ) );
                if ( count < 0 )
                    MessageBox . Show ( "编辑数据失败" );
                else
                {
                    MessageBox . Show ( "成功编辑数据" );

                    row = da . Select ( "idx=" + id + "" ) [ 0 ];
                    row . BeginEdit ( );
                    row [ "GX01" ] = GX1;
                    row [ "GX02" ] = GX2;
                    row [ "GX03" ] = GX3;
                    row [ "GX04" ] = GX4;
                    row [ "GX05" ] = GX5;
                    row . EndEdit ( );
                    gridControl1 . DataSource = da;
                    gridControl1 . RefreshDataSource ( );
                }
            }
            else
            {
                StringBuilder strSql = new StringBuilder ( );
                strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQAA A INNER JOIN R_PQW B ON A.GX02=B.GZ04 WHERE GX02='{0}' AND GZ39 IN ('执行','审核')" ,gOne );
                if ( SqlHelper . Exists ( strSql . ToString ( ) ) )
                {
                    MessageBox . Show ( "工序:" + gOne + "在317中已经存在,且已经执行,不允许变更" );
                    return;
                }
                strSql = new StringBuilder ( );
                strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQAA WHERE GX02='{0}'" ,GX2 );
                if ( SqlHelper . Exists ( strSql . ToString ( ) ) )
                {
                    MessageBox . Show ( "已经存在" + GX2 + "的工序名称，请核实后再编辑" );
                    return;
                }

                strSql = new StringBuilder ( );
                strSql . Append ( "" );
                int count = SqlHelper . ExecuteNonQuery ( "UPDATE R_PQAA SET GX02=@GX02,GX03=@GX03,GX04=@GX04,GX05=@GX05 WHERE idx=@idx" ,new System . Data . SqlClient . SqlParameter ( "@GX02" ,GX2 ) ,new System . Data . SqlClient . SqlParameter ( "@idx" ,id ) ,new System . Data . SqlClient . SqlParameter ( "@GX03" ,GX3 ) ,new System . Data . SqlClient . SqlParameter ( "@GX04" ,GX4 ) ,new System . Data . SqlClient . SqlParameter ( "@GX05" ,GX5 ) );
                if ( count < 0 )
                    MessageBox . Show ( "编辑数据失败" );
                else
                {
                    MessageBox . Show ( "成功编辑数据" );

                    row = da . Select ( "idx=" + id + "" ) [ 0 ];
                    row . BeginEdit ( );
                    row [ "GX01" ] = GX1;
                    row [ "GX02" ] = GX2;
                    row [ "GX03" ] = GX3;
                    row [ "GX04" ] = GX4;
                    row [ "GX05" ] = GX5;
                    row . EndEdit ( );
                    gridControl1 . DataSource = da;
                    gridControl1 . RefreshDataSource ( );
                }
            }
        }
        //删除
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( MessageBox . Show ( "确定删除此记录?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;
            if ( string . IsNullOrEmpty ( comboBox1 . Text ) )
            {
                MessageBox . Show ( "请选择需要删除的工序名称" );
                return;
            }

            GX1 = string . IsNullOrEmpty ( textBox1 . Text ) == true ? 0 : Convert . ToInt32 ( textBox1 . Text );
            GX2 = comboBox1 . Text;

            StringBuilder strSql = new StringBuilder ( );
            strSql . AppendFormat ( "SELECT COUNT(1) FROM R_PQAA A INNER JOIN R_PQW B ON A.GX02=B.GZ04 WHERE GX02='{0}' AND GZ39 IN ('执行','审核')" ,GX2 );
            if ( SqlHelper . Exists ( strSql . ToString ( ) ) )
            {
                MessageBox . Show ( "工序:" + GX2 + "在317中已经存在,且已经执行,不允许删除" );
                return;
            }

            strSql = new StringBuilder ( );
            strSql . AppendFormat ( "DELETE FROM R_PQAA WHERE GX01={0}" ,GX1 );

            int count = SqlHelper . ExecuteNonQuery ( strSql . ToString ( ) );
            if ( count < 0 )
                MessageBox . Show ( "删除数据失败" );
            else
            {
                MessageBox . Show ( "成功删除数据" );

                int num = gridView1 . FocusedRowHandle;
                da . Rows . RemoveAt ( num );
            }
        }
        //表
        string gOne = string.Empty,gTwo=string.Empty;
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            row = gridView1 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            comboBox1 . Text = row [ "GX02" ] . ToString ( );
            textBox1 . Text = row [ "GX01" ] . ToString ( );
            textBox2 . Text = row [ "GX03" ] . ToString ( );
            comboBox2 . Text = row [ "GX04" ] . ToString ( );
            textBox3 . Text = row [ "GX05" ] . ToString ( );
            id = string . IsNullOrEmpty ( row [ "idx" ] . ToString ( ) ) == true ? 0 : Convert . ToInt32 ( row [ "idx" ] . ToString ( ) );
            gOne = comboBox1 . Text;
            gTwo = comboBox2 . Text;
        }
        private void textBox2_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void textBox3_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDayRegise.intgra( e );
        }
        private void button4_Click ( object sender ,EventArgs e )
        {
            da = SqlHelper.ExecuteDataTable( "SELECT idx,GX02,GX01,GX03,GX04,GX05 FROM R_PQAA ORDER BY GX05" );
            gridControl1.DataSource = da;
        }
    }
}
