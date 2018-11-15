using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;

namespace SelectAll
{
    public partial class TeamLeaderRoutineCheckAll : FormBase
    {
        public TeamLeaderRoutineCheckAll ( )
        {
            InitializeComponent( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        //public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        //public event PassDataBetweenFormHandler PassDataBetweenForm;
        DataTable tableQuery;
        MulaolaoBll.Bll.TeamLeaderRoutineCheckBll _bll = new MulaolaoBll.Bll.TeamLeaderRoutineCheckBll( );

        private void TeamLeaderRoutineCheckAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            assignMent( );

            userControl11.OnPageChanged += new EventHandler( userControl11_OnPageChanged );
        }

        void userControl11_OnPageChanged ( object sender ,EventArgs e )
        {
            pageToDataTable( );
        }

        //Bind data source
        void assignMent ( )
        {
            lookUpEdit1.Properties.DataSource = _bll.GetDataTableOnly( );
            lookUpEdit1.Properties.DisplayMember = "QZ001";
        }

        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND QZ001='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( textBox1.Text ) )
                strWhere = strWhere + " AND QZ002='" + textBox1.Text + "'";
            pageToDataTable( );
        }

        //Bind data source and pageChange
        void pageToDataTable ( )
        {
            int count = _bll.GetCount( strWhere );
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            if ( userControl11.pageIndex <= 1 )
                tableQuery = _bll.GetDataTableByChange( strWhere ,0 ,userControl11.pageSize );
            else
                tableQuery = _bll.GetDataTableByChange( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            gridControl1.DataSource = tableQuery;
        }

        string[] str=new string[2];
        //Value
        string cn1 = "", cn2 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "QZ001" ).ToString( );
            cn2 = gridView1.GetFocusedRowCellValue( "RES05" ).ToString( );
            str [ 0 ] = cn1;
            str [ 1 ] = cn2;
            //PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 );
            //if ( PassDataBetweenForm != null )
            //{
            //    PassDataBetweenForm( this ,args );
            //}
            //this.Close( );
            this . DialogResult = System . Windows . Forms . DialogResult . OK;
        }

        public string [ ] strList
        {
            get
            {
                return str;
            }
        }

    }
}
