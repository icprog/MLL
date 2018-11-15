using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Wages
{
    public partial class FormUserChange :Form
    {
        MulaolaoBll.Bll.ChanPinGongZiKaoQinBll bll = null;
        DataTable tableView,tableOrder;
        List<string> strList=new List<string>();
        bool result=false;
        
        public FormUserChange ( )
        {
            InitializeComponent ( );

            bll = new MulaolaoBll . Bll . ChanPinGongZiKaoQinBll ( );
            tableView = new DataTable ( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1  } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }

        private void FormUserChange_Load ( object sender ,EventArgs e )
        {
            DataTable dt = bll . GetDataTableLeader ( );
            comboBox1 . DataSource = dt . Copy ( );
            comboBox1 . DisplayMember = "DBA002";
            comboBox1 . ValueMember = "DBA001";
            comboBox2 . DataSource = dt . Copy ( );
            comboBox2 . DisplayMember = "DBA002";
            comboBox2 . ValueMember = "DBA001";

            tableOrder = bll . getTableOfPQW ( );
            comboBox3 . DataSource = tableOrder . DefaultView . ToTable ( true ,new string [ ] { "GZ16" ,"GZ32" } );
            comboBox3 . DisplayMember = "GZ16";
            comboBox3 . ValueMember = "GZ32";

            comboBox5 . DataSource = tableOrder . Copy ( ) . DefaultView . ToTable ( true ,new string [ ] { "GZ16" ,"GZ32" } );
            comboBox5 . DisplayMember = "GZ16";
            comboBox5 . ValueMember = "GZ32";

            comboBox6 . DataSource = tableOrder . DefaultView . ToTable ( true ,new string [ ] { "GZ37" ,"GZ38" } );
            comboBox6 . DisplayMember = "GZ37";
            comboBox6 . ValueMember = "GZ38";

            comboBox4 . DataSource = tableOrder . Copy ( ) . DefaultView . ToTable ( true ,new string [ ] { "GZ37" ,"GZ38" } );
            comboBox4 . DisplayMember = "GZ37";
            comboBox4 . ValueMember = "GZ38";

            DataTable tableC = bll . getTableOfPQWC ( );
            comboBox7 . DataSource = tableC;
            comboBox7 . DisplayMember = "GZ30";
            comboBox7 . ValueMember = "GZ31";

            comboBox8 . DataSource = tableC . Copy ( );
            comboBox8 . DisplayMember = "GZ30";
            comboBox8 . ValueMember = "GZ31";
        }

        //query
        private void btnQuery_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( comboBox1 . Text ) )
            {
                MessageBox . Show ( "请选择组长" );
                return;
            }
            tableView = bll . GetDataTableLeader ( comboBox1 . Text );
            gridControl1 . DataSource = tableView;
        }

        //change
        private void btnChange_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( comboBox1 . Text ) )
            {
                MessageBox . Show ( "请选择组长" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox2 . Text ) )
            {
                MessageBox . Show ( "请选择变更组长" );
                return;
            }
            strList . Clear ( );
            for ( int i = 0 ; i < gridView1 . RowCount ; i++ )
            {
                strList . Add ( gridView1 . GetDataRow ( i ) [ "DBA001" ] . ToString ( ) );
            }
            if ( strList . Count < 1 )
            {
                MessageBox . Show ( "请查询需要变更的人员信息" );
                return;
            }
            bool result = bll . changeUserForLeader ( comboBox2 . Text ,strList ,Logins . username );
            if ( result )
                MessageBox . Show ( "编辑成功" );
            else
                MessageBox . Show ( "编辑失败" );
        }

        //组长变更
        private void button2_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( comboBox3 . Text ) )
            {
                MessageBox . Show ( "请选择需要变更的组长" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox5 . Text ) )
            {
                MessageBox . Show ( "请选择变更组长" );
                return;
            }
            if ( comboBox5 . Text . Equals ( comboBox3 . Text ) )
            {
                MessageBox . Show ( "变更组长和被变更组长一致,请重新选择" );
                return;
            }


            if ( MessageBox . Show ( "确认变更,若统计员也需要变更,请先变更统计员,再变更组长?" ,"变更" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;

            result = bll . EditOrder ( comboBox5 . SelectedValue . ToString ( ) ,comboBox5 . Text ,comboBox3 . SelectedValue . ToString ( ) ,comboBox3 . Text );
            if ( result )
                MessageBox . Show ( "变更成功,请查询317数据" );
            else
                MessageBox . Show ( "变更失败,请重试" );
        }

        //统计员变更
        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( comboBox3 . Text ) )
            {
                MessageBox . Show ( "请选择需要变更的组长" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox4 . Text ) )
            {
                MessageBox . Show ( "请选择需要变更的统计员" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox6 . Text ) )
            {
                MessageBox . Show ( "请选择变更的统计员" );
                return;
            }
            if ( comboBox4 . Text . Equals ( comboBox6 . Text ) )
            {
                MessageBox . Show ( "变更统计员和被变更统计员一致,请重新选择" );
                return;
            }
            if ( MessageBox . Show ( "确认变更统计员?" ,"变更" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;

            result = bll . EditOrder ( comboBox3 . SelectedValue . ToString ( ) ,comboBox3 . Text ,comboBox6 . SelectedValue . ToString ( ) ,comboBox6 . Text ,comboBox4 . SelectedValue . ToString ( ) ,comboBox4 . Text );
            if ( result )
                MessageBox . Show ( "变更成功,请查询317数据" );
            else
                MessageBox . Show ( "变更失败,请重试" );
        }

        //车间主任变更
        private void button3_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( comboBox3 . Text ) )
            {
                MessageBox . Show ( "请选择需要变更的车间主任所属的组长" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox7 . Text ) )
            {
                MessageBox . Show ( "请选择需要变更的车间主任" );
                return;
            }
            if ( string . IsNullOrEmpty ( comboBox8 . Text ) )
            {
                MessageBox . Show ( "请选择变更的车间主任" );
                return;
            }
            if ( comboBox8 . Text . Equals ( comboBox7 . Text ) )
            {
                MessageBox . Show ( "需要变更的车间主任和变更的车间主任一致,请重新选择" );
                return;
            }

            result = bll . EditOrderC ( comboBox3 . SelectedValue . ToString ( ) ,comboBox3 . Text ,comboBox7 . SelectedValue . ToString ( ) ,comboBox7 . Text ,comboBox8 . SelectedValue . ToString ( ) ,comboBox8 . Text );
            if ( result )
                MessageBox . Show ( "变更成功,请查询317数据" );
            else
                MessageBox . Show ( "变更失败,请重试" );
        }

    }

}
