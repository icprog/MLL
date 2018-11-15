using Mulaolao . Class;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Base
{
    public partial class FormUserInfo :FormChild
    {
        MulaolaoLibrary.UserInfoEntity _model=null;
        MulaolaoBll.Bll.UserInfoBll _bll=null;
        DataTable tableView;DataRow row;
        bool result=false;
        string state=string.Empty;

        public FormUserInfo ( )
        {
            InitializeComponent ( );

            _model = new MulaolaoLibrary . UserInfoEntity ( );
            _bll = new MulaolaoBll . Bll . UserInfoBll ( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );

            toolReview . Text = "注销";
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            UnEnable ( );
        }
        
        private void FormUserInfo_Load ( object sender ,System . EventArgs e )
        {
            Sex . Items . AddRange ( new string [ ] { "" ,"男" ,"女" ,"其他" } );
            //textBox1 . Items . AddRange ( new string [ ] { "1" ,"2" ,"3" ,"4" ,"5" ,"6" ,"7" ,"8" ,"9" } );
            glUser . Items . AddRange ( new string [ ] { "" ,"是" ,"否" } );

            departName . Properties . DataSource = _bll . getTableDepart ( );
            departName . Properties . DisplayMember = "DAA002";
            departName . Properties . ValueMember = "DAA001";

            label3 . Visible = false;
        }

        protected override void select ( )
        {
            tableView = _bll . getTableView ( );
            gridControl1 . DataSource = tableView;

            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = true;
            toolSave . Enabled = toolCancel . Enabled = toolStorage . Enabled = toolPrint . Enabled = toolMaintain . Enabled = toolLibrary . Enabled = toolExport . Enabled = toolcopy . Enabled = false;

            base . select ( );
        }
        protected override void add ( )
        {
            Enable ( );
            Clear ( );

            state = "add";

            userNum . Text = _bll . getUserNum ( );

            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolStorage . Enabled = toolReview . Enabled = toolPrint . Enabled = toolMaintain . Enabled = toolLibrary . Enabled = toolExport . Enabled = toolcopy . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;
            label3 . Visible = false;

            base . add ( );
        }
        protected override void delete ( )
        {
            if ( string . IsNullOrEmpty ( userNum . Text ) )
            {
                MessageBox . Show ( "请选择需要删除的用户" );
                return;
            }

            if ( MessageBox . Show ( "确认删除?" ,"删除" ,MessageBoxButtons . OKCancel ) == DialogResult . Cancel )
                return;

            result = _bll . Delete ( userNum . Text );
            if ( result )
            {
                MessageBox . Show ( "删除成功" );
                tableView . Rows . Remove ( tableView . Select ( "DBA001='" + userNum . Text + "'" ) [ 0 ] );
                gridControl1 . RefreshDataSource ( );
                label3 . Visible = false;
            }
            else
                MessageBox . Show ( "删除失败,请重试" );

            base . delete ( );
        }
        protected override void update ( )
        {
            Enable ( );

            state = "edit";

            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolStorage . Enabled = toolReview . Enabled = toolPrint . Enabled = toolMaintain . Enabled = toolLibrary . Enabled = toolExport . Enabled = toolcopy . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;

            base . update ( );
        }
        protected override void save ( )
        {
            if ( string . IsNullOrEmpty ( userNum . Text ) )
                userNum . Text = _bll . getUserNum ( );

            if ( string . IsNullOrEmpty ( userName . Text ) )
            {
                MessageBox . Show ( "人员姓名不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( departNum . Text ) )
            {
                MessageBox . Show ( "请选择所属部门" );
                return;
            }
            if ( string . IsNullOrEmpty ( Tel . Text ) )
            {
                MessageBox . Show ( "手机号不可为空" );
                return;
            }

            getValue ( );

            result = _bll . Exists ( _model . DBA002 ,_model . DBA028 ,_model.DBA001);
            if ( result )
            {
                MessageBox . Show ( "已经存在相同姓名和电话号码的员工,请核实" );
                return;
            }

            if ( state . Equals ( "add" ) )
                result = _bll . Save ( _model );
            else
                result = _bll . Edit ( _model );

            if ( result )
            {
                MessageBox . Show ( "保存成功" );

                tableView = _bll . getTableView ( );
                gridControl1 . DataSource = tableView;

                UnEnable ( );

                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = toolStorage . Enabled = toolPrint . Enabled = toolMaintain . Enabled = toolLibrary . Enabled = toolExport . Enabled = toolcopy . Enabled = false;
            }
            else
                MessageBox . Show ( "保存失败" );

            base . save ( );
        }
        protected override void cancel ( )
        {
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = true;
            toolSave . Enabled = toolCancel . Enabled = toolStorage . Enabled = toolPrint . Enabled = toolMaintain . Enabled = toolLibrary . Enabled = toolExport . Enabled = toolcopy . Enabled = false;

            UnEnable ( );

            base . cancel ( );
        }
        protected override void revirw ( )
        {
            getValue ( );
            result = _bll . Exists ( _model . DBA001 );
            if ( result )
            {
                if ( toolReview . Text . Equals ( "注销" ) )
                {
                    _model . DBA002 = "注销";
                    _model . DBA043 = "T";
                }
                else
                {
                    _model . DBA002 = "反注销";
                    _model . DBA043 = "F";
                }

                result = _bll . EditConell ( _model . DBA001 ,_model . DBA043 );
                if ( result )
                {
                    MessageBox . Show ( _model . DBA002 + "成功" );
                    if ( _model . DBA002 . Equals ( "注销" ) )
                    {
                        toolReview . Text = "反注销";
                        label3 . Visible = true;
                    }
                    else
                    {
                        label3 . Visible = false;
                        toolReview . Text = "注销";
                    }

                    tableView = _bll . getTableView ( );
                    gridControl1 . DataSource = tableView;
                }
                else
                    MessageBox . Show ( _model . DBA002 + "失败" );
            }
            else
                MessageBox . Show ( "不存在此员工,请新建" );

            base . revirw ( );
        }

        void Enable ( )
        {
            userName . Enabled = userNum . Enabled = departName . Enabled = departNum . Enabled = Sex . Enabled = Tel . Enabled =glUser.Enabled= true;
        }
        void UnEnable ( )
        {
            userName . Enabled = userNum . Enabled = departName . Enabled = departNum . Enabled = Sex . Enabled = Tel . Enabled =glUser.Enabled= false;
        }
        void Clear ( )
        {
            userName . Text = userNum . Text = departName . Text = departNum . Text = textBox1 . Text = Sex . Text = Tel . Text =glUser.Text= string . Empty;
            departName . ItemIndex = -1;
        }

        void getValue ( )
        {
            _model . DBA001 = userNum . Text;
            _model . DBA002 = userName . Text;
            _model . DBA005 = departNum . Text;
            _model . DBA028 = Tel . Text;
            _model . DBA043 = "F";
            _model . DBA960 = Sex . Text;
            //_model . DBA961 = textBox1 . Text;
            _model . DBA006 = glUser . Text;
        }
        void editCol ( )
        {
            row [ "DBA001" ] = _model . DBA001;
            row [ "DBA002" ] = _model . DBA002;
            row [ "DBA005" ] = _model . DBA005;
            row [ "DBA006" ] = _model . DBA006;
            row [ "DBA028" ] = _model . DBA028;
            row [ "DBA960" ] = _model . DBA960;
            //row [ "DBA961" ] = _model . DBA961;
            row [ "DAA002" ] = departName . Text;
        }

        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            DataRow row = gridView1 . GetFocusedDataRow ( );
            if ( row == null )
                return;
            userNum . Text = row [ "DBA001" ] . ToString ( );
            userName . Text = row [ "DBA002" ] . ToString ( );
            departNum . Text = row [ "DBA005" ] . ToString ( );
            departName . Text = row [ "DAA002" ] . ToString ( );
            Tel . Text = row [ "DBA028" ] . ToString ( );
            Sex . Text = row [ "DBA960" ] . ToString ( );
            textBox1 . Text = row [ "DBA961" ] . ToString ( );
            glUser . Text = row [ "DBA006" ] . ToString ( );
            if ( !string . IsNullOrEmpty ( row [ "DBA043" ] . ToString ( ) ) )
            {
                _model . DBA043 = row [ "DBA043" ] . ToString ( );
                if ( _model . DBA043 . Equals ( "T" ) )
                {
                    label3 . Visible = true;
                    toolReview . Text = "反注销";
                }
                else
                {
                    label3 . Visible = false;
                    toolReview . Text = "注销";
                }
            }
        }
        private void gridView1_DoubleClick ( object sender ,System . EventArgs e )
        {
            xtraTabControl1 . SelectedTabPageIndex = 0;
        }
        private void departName_EditValueChanged ( object sender ,System . EventArgs e )
        {
            departNum . Text = departName . EditValue . ToString ( );
        }


    }
}



