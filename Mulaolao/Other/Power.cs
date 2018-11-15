using System;
using System . Data;
using System . Data . SqlClient;
using System . Windows . Forms;
using StudentMgr;
using Mulaolao . Class;

namespace Mulaolao . Other
{
    public partial class Power : Form
    {
        MulaolaoLibrary.PowerEntity _model=null;
        MulaolaoBll.Bll.PowerBll _bll=null;
        bool result=false;

        public Power( Form fm )
        {
            this.MdiParent = fm;
            InitializeComponent( );

            _model = new MulaolaoLibrary . PowerEntity ( );
            _bll = new MulaolaoBll . Bll . PowerBll ( );

            GridViewMoHuSelect . SetFilter ( searchLookUpEdit1View );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { this .gvPower  } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;
        }

        DataTable userInfo,proInfo,tableView;

        private void Power_Load ( object sender ,EventArgs e )
        {
            //查找所有的用户编码
            userInfo = _bll . getUserInfo ( );
            userName . Properties . DataSource = userInfo;
            userName . Properties . DisplayMember = "DBA002";
            userName . Properties . ValueMember = "DBA001";

            proInfo = _bll . getProInfo ( );
            proName . Properties . DataSource = proInfo;
            proName . Properties . DisplayMember = "CX02";
            proName . Properties . ValueMember = "CX01";
        }

        private void userNum_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( userInfo != null && userInfo . Rows . Count > 0 && !string . IsNullOrEmpty ( userName . EditValue . ToString ( ) ) )
            {
                DataRow row = searchLookUpEdit1View . GetFocusedDataRow ( );
                if ( row == null )
                    return;
                userNums . Text = row [ "DBA001" ] . ToString ( );
                depart . Text = row [ "DAA002" ] . ToString ( );
            }
        }

        private void proName_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( proInfo != null && proInfo . Rows . Count > 0 && !string . IsNullOrEmpty ( proName . EditValue . ToString ( ) ) )
                proNum . Text = proName . EditValue . ToString ( );
        }

        //运行
        private void checkBox1_CheckedChanged( object sender, EventArgs e )
        {
            if (checkBox1.Checked == false)
            {
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
                checkBox13.Checked = false;
                checkBox14.Checked = false;
                checkBox15.Checked = false;
            }
        }
        //查询
        private void checkBox4_CheckedChanged( object sender, EventArgs e )
        {
            if (checkBox4.Checked == false)
            {
                if (checkBox2.Checked == false)
                {
                    checkBox3.Checked = false;
                    checkBox5.Checked = false;
                    checkBox7.Checked = false;
                    checkBox9.Checked = false;
                }
            }
        }
        //新增
        private void checkBox2_CheckedChanged( object sender, EventArgs e )
        {
            if (checkBox4.Checked == false)
            {
                if (checkBox2.Checked == false)
                {
                    checkBox3.Checked = false;
                    checkBox5.Checked = false;
                    checkBox7.Checked = false;
                    checkBox9.Checked = false;
                }
            }
        }

        private void userNums_TextChanged ( object sender ,EventArgs e )
        {
            tableView = _bll . getTableView ( userNums . Text );
            gcPower . DataSource = tableView;
        }
        private void gvPower_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            DataRow row = gvPower . GetFocusedDataRow ( );
            if ( row == null )
                return;
            proName . EditValue = row [ "DBB002" ] . ToString ( );
            checkBox1 . Checked = string . IsNullOrEmpty ( row [ "DBB003" ] . ToString ( ) ) == true ? false : ( row [ "DBB003" ] . ToString ( ) . Trim ( ) . Equals ( "T" ) ? true : false );
            checkBox2 . Checked = string . IsNullOrEmpty ( row [ "DBB004" ] . ToString ( ) ) == true ? false : ( row [ "DBB004" ] . ToString ( ) . Trim ( ) . Equals ( "T" ) ? true : false );
            checkBox3 . Checked = string . IsNullOrEmpty ( row [ "DBB007" ] . ToString ( ) ) == true ? false : ( row [ "DBB007" ] . ToString ( ) . Trim ( ) . Equals ( "T" ) ? true : false );
            checkBox4 . Checked = string . IsNullOrEmpty ( row [ "DBB005" ] . ToString ( ) ) == true ? false : ( row [ "DBB005" ] . ToString ( ) . Trim ( ) . Equals ( "T" ) ? true : false );
            checkBox5 . Checked = string . IsNullOrEmpty ( row [ "DBB006" ] . ToString ( ) ) == true ? false : ( row [ "DBB006" ] . ToString ( ) . Trim ( ) . Equals ( "T" ) ? true : false );
            checkBox6 . Checked = string . IsNullOrEmpty ( row [ "DBB008" ] . ToString ( ) ) == true ? false : ( row [ "DBB008" ] . ToString ( ) . Trim ( ) . Equals ( "T" ) ? true : false );
            checkBox7 . Checked = string . IsNullOrEmpty ( row [ "DBB009" ] . ToString ( ) ) == true ? false : ( row [ "DBB009" ] . ToString ( ) . Trim ( ) . Equals ( "T" ) ? true : false );
            checkBox8 . Checked = string . IsNullOrEmpty ( row [ "DBB010" ] . ToString ( ) ) == true ? false : ( row [ "DBB010" ] . ToString ( ) . Trim ( ) . Equals ( "T" ) ? true : false );
            checkBox9 . Checked = string . IsNullOrEmpty ( row [ "DBB011" ] . ToString ( ) ) == true ? false : ( row [ "DBB011" ] . ToString ( ) . Trim ( ) . Equals ( "T" ) ? true : false );
            checkBox10 . Checked = string . IsNullOrEmpty ( row [ "DBB012" ] . ToString ( ) ) == true ? false : ( row [ "DBB012" ] . ToString ( ) . Trim ( ) . Equals ( "T" ) ? true : false );
            checkBox11 . Checked = string . IsNullOrEmpty ( row [ "DBB013" ] . ToString ( ) ) == true ? false : ( row [ "DBB013" ] . ToString ( ) . Trim ( ) . Equals ( "T" ) ? true : false );
            checkBox12 . Checked = string . IsNullOrEmpty ( row [ "DBB014" ] . ToString ( ) ) == true ? false : ( row [ "DBB014" ] . ToString ( ) . Trim ( ) . Equals ( "T" ) ? true : false );
            checkBox13 . Checked = string . IsNullOrEmpty ( row [ "DBB016" ] . ToString ( ) ) == true ? false : ( row [ "DBB016" ] . ToString ( ) . Trim ( ) . Equals ( "T" ) ? true : false );
            checkBox14 . Checked = string . IsNullOrEmpty ( row [ "DBB015" ] . ToString ( ) ) == true ? false : ( row [ "DBB015" ] . ToString ( ) . Trim ( ) . Equals ( "T" ) ? true : false );
            checkBox15 . Checked = string . IsNullOrEmpty ( row [ "DBB017" ] . ToString ( ) ) == true ? false : ( row [ "DBB017" ] . ToString ( ) . Trim ( ) . Equals ( "T" ) ? true : false );
        }
        

        //新建
        private void build ( )
        {
            _model . DBB001 = userNums . Text;
            _model . DBB002 = proNum . Text;
            _model . DBB003 = checkBox1 . Checked == true ? "T" : "F";
            _model . DBB004 = checkBox2 . Checked == true ? "T" : "F";
            _model . DBB007 = checkBox3 . Checked == true ? "T" : "F";
            _model . DBB005 = checkBox4 . Checked == true ? "T" : "F";
            _model . DBB006 = checkBox5 . Checked == true ? "T" : "F";
            _model . DBB008 = checkBox6 . Checked == true ? "T" : "F";
            _model . DBB009 = checkBox7 . Checked == true ? "T" : "F";
            _model . DBB010 = checkBox8 . Checked == true ? "T" : "F";
            _model . DBB011 = checkBox9 . Checked == true ? "T" : "F";
            _model . DBB012 = checkBox10 . Checked == true ? "T" : "F";
            _model . DBB013 = checkBox11 . Checked == true ? "T" : "F";
            _model . DBB014 = checkBox12 . Checked == true ? "T" : "F";
            _model . DBB016 = checkBox13 . Checked == true ? "T" : "F";
            _model . DBB015 = checkBox14 . Checked == true ? "T" : "F";
            _model . DBB017 = checkBox15 . Checked == true ? "T" : "F";           
        }
        private void button1_Click( object sender, EventArgs e )
        {
            build( );
            if ( tableView . Select ( "DBB002='" + _model . DBB002 + "'" ) . Length > 0 )
                MessageBox . Show ( "" + userNums . Text + "已经对程序编号:" + _model . DBB002 + "的权限做了配置,请直接更改" );
            else
            {
                result = _bll . Insert ( _model );
                if ( result == false )
                    MessageBox . Show ( "录入数据失败" );
                else
                {
                    MessageBox . Show ( "成功录入数据" );
                    DataRow row = tableView . NewRow ( );
                    row [ "DBB002" ] = _model.DBB002;
                    row [ "CX02" ] = proName . Text;
                    row [ "DBB003" ] = _model . DBB003;
                    row [ "DBB004" ] = _model . DBB004;
                    row [ "DBB005" ] = _model . DBB005;
                    row [ "DBB006" ] = _model . DBB006;
                    row [ "DBB007" ] = _model . DBB007;
                    row [ "DBB008" ] = _model . DBB008;
                    row [ "DBB009" ] = _model . DBB009;
                    row [ "DBB010" ] = _model . DBB010;
                    row [ "DBB011" ] = _model . DBB011;
                    row [ "DBB012" ] = _model . DBB012;
                    row [ "DBB013" ] = _model . DBB013;
                    row [ "DBB014" ] = _model . DBB014;
                    row [ "DBB015" ] = _model . DBB015;
                    row [ "DBB016" ] = _model . DBB016;
                    row [ "DBB017" ] = _model . DBB017;
                    tableView . Rows . Add ( row );
                    gcPower . RefreshDataSource ( );
                }
            }
        }
        //更新
        private void button2_Click ( object sender ,EventArgs e )
        {
            build ( );
            result = _bll . Edit ( _model );
            if ( result == false )
                MessageBox . Show ( "编辑失败,请重试" );
            else
            {
                MessageBox . Show ( "成功编辑" );
                DataRow row = tableView . Select ( "DBB001='" + _model . DBB001 + "' AND DBB002='" + _model . DBB002 + "'" ) [ 0 ];
                row . BeginEdit ( );
                row [ "DBB002" ] = _model . DBB002;
                row [ "CX02" ] = proName . Text;
                row [ "DBB003" ] = _model . DBB003;
                row [ "DBB004" ] = _model . DBB004;
                row [ "DBB005" ] = _model . DBB005;
                row [ "DBB006" ] = _model . DBB006;
                row [ "DBB007" ] = _model . DBB007;
                row [ "DBB008" ] = _model . DBB008;
                row [ "DBB009" ] = _model . DBB009;
                row [ "DBB010" ] = _model . DBB010;
                row [ "DBB011" ] = _model . DBB011;
                row [ "DBB012" ] = _model . DBB012;
                row [ "DBB013" ] = _model . DBB013;
                row [ "DBB014" ] = _model . DBB014;
                row [ "DBB015" ] = _model . DBB015;
                row [ "DBB016" ] = _model . DBB016;
                row [ "DBB017" ] = _model . DBB017;
                row . EndEdit ( );
                gcPower . RefreshDataSource ( );
            }
        }
        //删除
        private void button3_Click( object sender, EventArgs e )
        {
            build( );
            result = _bll . Delete ( _model );
            if ( result == false )
                MessageBox . Show ( "删除失败,请重试" );
            else
            {
                MessageBox . Show ( "成功删除" );
                tableView . Rows . Remove ( tableView . Select ( "DBB001='" + _model . DBB001 + "' AND DBB002='" + _model . DBB002 + "'" ) [ 0 ] );
                gcPower . RefreshDataSource ( );
            }
        }

    }
}
