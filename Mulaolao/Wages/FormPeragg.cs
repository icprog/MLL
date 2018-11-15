using Mulaolao . Class;
using System;
using System . Data;
using System . Windows . Forms;

namespace Mulaolao . Wages
{
    public partial class FormPeragg :FormChild
    {
        MulaolaoLibrary.PeraggEntity _model=null;
        MulaolaoBll.Bll.PeraggBll _bll=null;
        DataTable tableView;
        bool result=false;string strWhere=string.Empty;
        
        public FormPeragg ( )
        {
            InitializeComponent ( );

            _model = new MulaolaoLibrary . PeraggEntity ( );
            _bll = new MulaolaoBll . Bll . PeraggBll ( );

            GridViewMoHuSelect . SetFilter ( gridView1 );
            Power ( this );
            controlUnEnable ( );

            lupPerson . Properties . DataSource = _bll . getUser ( );
            lupPerson . Properties . DisplayMember = "XZ004";

            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1  } );
            MulaolaoBll . UserInfoMation . tableName = this . Name;

            //lupPerson . EditValue = "黄贵洪";

            //toolStrip1 . Items . Remove ( toolReview );
            //toolStrip1 . Items . Remove ( toolExport );
            //toolStrip1 . Items . Remove ( toolPrint );
            //toolStrip1 . Items . Remove ( toolStorage );
            //toolStrip1 . Items . Remove ( toolLibrary );
            //toolStrip1 . Items . Remove ( toolCancel );
            //toolStrip1 . Items . Remove ( toolcopy );
            //toolStrip1 . Items . Remove ( toolMaintain );

        }
        
        #region Main
        protected override void select ( )
        {
            base . select ( );

            SelectAll . PeraggAll from = new SelectAll . PeraggAll ( "个人工资汇总查询" );
            if ( from . ShowDialog ( ) == System . Windows . Forms . DialogResult . OK )
            {
                _model . CA001 = from . getOddNum;
                strWhere = "1=1";
                strWhere += " AND CA001='" + _model . CA001 + "'";
                QueryTable ( );
                toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = false;
            }
        }
        protected override void add ( )
        {
            controlEnable ( );
            lupPerson . ItemIndex = -1;
            tableView = null;
            gridControl1 . DataSource = null;

            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolcopy . Enabled = toolLibrary . Enabled = toolStorage . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;

            base . add ( );
        }
        protected override void update ( )
        {
            base . update ( );

            controlEnable ( );
            toolSelect . Enabled = toolAdd . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = false;
            toolSave . Enabled = toolCancel . Enabled = true;
        }
        protected override void delete ( )
        {
            base . delete ( );

            if ( string . IsNullOrEmpty ( _model . CA001 ) )
            {
                MessageBox . Show ( "请选择需要删除的数据" );
                return ;
            }

            result = _bll . Delete ( _model . CA001 );
            if ( result )
            {
                MessageBox . Show ( "删除成功" );
                toolSelect . Enabled = toolAdd . Enabled = toolPrint . Enabled = toolExport . Enabled = true;
                toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolSave . Enabled = toolCancel . Enabled = false;
                controlUnEnable ( );
                gridControl1 . DataSource = null;
            }
            else
                MessageBox . Show ( "删除失败" );
        }
        protected override void save ( )
        {
            base . save ( );

            gridView1 . CloseEditor ( );
            gridView1 . UpdateCurrentRow ( );
            result = _bll . Save ( tableView );
            if ( result )
            {
                MessageBox . Show ( "保存成功" );
                toolSelect . Enabled = toolAdd . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = toolReview . Enabled = true;
                toolSave . Enabled = toolCancel . Enabled = false;
                controlUnEnable ( );
            }
            else
                MessageBox . Show ( "保存失败" );
        }
        protected override void cancel ( )
        {
            base . cancel ( );

            toolSelect . Enabled = toolAdd . Enabled = toolPrint . Enabled = toolExport . Enabled = toolMaintain . Enabled = true;
            toolSave . Enabled = toolCancel . Enabled = toolDelete . Enabled = toolUpdate . Enabled = toolReview . Enabled = false;
            controlUnEnable ( );
        }
        protected override void export ( )
        {
            ViewExport . ExportToExcel ( this . Text ,gridControl1 );

            base . export ( );
        }
        #endregion

        #region Method
        void controlUnEnable ( )
        {
            lupPerson . Enabled = false;
            dtp . Enabled = false;
            gridView1 . OptionsBehavior . Editable = false;
            btnRead . Enabled =btnBatchEdit.Enabled= false;
        }
        void controlEnable ( )
        {
            lupPerson . Enabled = true;
            dtp . Enabled = true;
            gridView1 . OptionsBehavior . Editable = true;
            btnRead . Enabled =btnBatchEdit.Enabled= true;
        }
        void QueryTable ( )
        {
            tableView = _bll . tableView ( strWhere );
            gridControl1 . DataSource = tableView;
            //string str= tableView . Rows [ 0 ] [ "CA016" ] . ToString ( ); ;
            if ( tableView != null && tableView . Rows . Count > 0 )
            {
                lupPerson . Text = tableView . Rows [ 0 ] [ "CA016" ] . ToString ( );
                dtp . Value = Convert . ToDateTime ( tableView . Rows [ 0 ] [ "CA017" ] . ToString ( ) + "-01-01" );
                _model . CA001 = tableView . Rows [ 0 ] [ "CA001" ] . ToString ( );
            }
            else
            {
                lupPerson . Text = string . Empty;
                dtp . Value = DateTime . Now;
                _model . CA001 = string . Empty;
            }
            assignMent ( );
        }
        void assignMent ( )
        {
            if ( gridView1 . DataRowCount > 0 )
            {
                decimal u5Sum = Convert . ToDecimal ( U5 . SummaryItem . SummaryValue );
                decimal u7Sum = Convert . ToDecimal ( U7 . SummaryItem . SummaryValue );
                decimal ca004Sum = Convert . ToDecimal ( CA004 . SummaryItem . SummaryValue );
                decimal ca005Sum = Convert . ToDecimal ( CA005 . SummaryItem . SummaryValue );
                decimal ca006Sum = Convert . ToDecimal ( CA006 . SummaryItem . SummaryValue );
                decimal ca007Sum = Convert . ToDecimal ( CA007 . SummaryItem . SummaryValue );
                decimal ca008Sum = Convert . ToDecimal ( CA008 . SummaryItem . SummaryValue );
                decimal ca011Sum = Convert . ToDecimal ( CA011 . SummaryItem . SummaryValue );
                decimal ca012Sum = Convert . ToDecimal ( CA012 . SummaryItem . SummaryValue );
                decimal ca013Sum = Convert . ToDecimal ( CA013 . SummaryItem . SummaryValue );
                decimal ca014Sum = Convert . ToDecimal ( CA014 . SummaryItem . SummaryValue );
                decimal ca015Sum = Convert . ToDecimal ( CA015 . SummaryItem . SummaryValue );
                decimal ca018Sum = Convert . ToDecimal ( CA018 . SummaryItem . SummaryValue );
                decimal ca019Sum = Convert . ToDecimal ( CA019 . SummaryItem . SummaryValue );
                U6 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( u5Sum + ca006Sum + ca007Sum + ca008Sum ,2 ) . ToString ( ) );
                U10 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,( ca011Sum + ca012Sum + ca013Sum + ca014Sum + ca015Sum + ca018Sum + ca019Sum ) . ToString ( ) );
                U11 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,( u5Sum + ca006Sum + ca007Sum + ca008Sum - ca011Sum - ca012Sum - ca013Sum - ca014Sum - ca015Sum ) . ToString ( ) );
                U8 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,Math . Round ( u5Sum + ca006Sum + ca007Sum + ca008Sum + u7Sum ,2 ) . ToString ( ) );
                U4 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,( ca004Sum + ca005Sum ) . ToString ( ) );
                U9 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,ca004Sum + ca005Sum == 0 ? 0 . ToString ( ) : Math . Round ( ( u5Sum + ca006Sum + ca007Sum + ca008Sum + u7Sum ) / ( ca004Sum + ca005Sum ) ,2 ) . ToString ( ) );
                U1 . SummaryItem . SetSummary ( DevExpress . Data . SummaryItemType . Custom ,ca004Sum + ca005Sum == 0 ? 0 . ToString ( ) : Math . Round ( ( u5Sum + ca006Sum + ca007Sum + ca008Sum ) / ( ca004Sum + ca005Sum ) ,2 ) . ToString ( ) );
            }
        }
        #endregion

        #region Click
        private void btnRead_Click ( object sender ,System . EventArgs e )
        {
            if ( string . IsNullOrEmpty ( lupPerson . Text ) )
            {
                MessageBox . Show ( "请选择人员姓名" );
                return;
            }

            result = _bll . GeneralTable ( lupPerson . Text ,dtp . Value . Year );
            if ( result )
            {
                MessageBox . Show ( "生成成功" );
                strWhere = "1=1";
                strWhere = strWhere + " AND CA016='" + lupPerson . Text + "' AND CA017='" + dtp . Value . Year + "'";
                QueryTable ( );
            }
            else
                MessageBox . Show ( "生成失败" );
        }
        private void btnBatchEdit_Click ( object sender ,EventArgs e )
        {
            DataRow row = gridView1 . GetDataRow ( 0 );
            
            if ( row != null )
            {
                _model . CA009 = string . IsNullOrEmpty ( row [ "CA009" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "CA009" ] . ToString ( ) );
                _model . CA010 = string . IsNullOrEmpty ( row [ "CA010" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( row [ "CA010" ] . ToString ( ) );
                if ( _model . CA009 > 0 )
                {
                    for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
                    {
                        gridView1 . SetRowCellValue ( i ,gridView1 . Columns [ "CA009" ] ,_model . CA009 );
                    }
                }
                if ( _model . CA010 > 0 )
                {
                    for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
                    {
                        gridView1 . SetRowCellValue ( i ,gridView1 . Columns [ "CA010" ] ,_model . CA010 );
                    }
                }
            }
        }
        #endregion

    }
}
