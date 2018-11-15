using Mulaolao;
using Mulaolao . Class;
using System;
using System . Data;

namespace SelectAll
{
    public partial class ShenChanJinDuJiHuaAll : FormBase
    {
        public ShenChanJinDuJiHuaAll ( )
        {
            InitializeComponent( );

            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
         
        //public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        //public event PassDataBetweenFormHandler PassDataBetweenForm;
        
        MulaolaoBll.Bll.ShenChanJinDuJiHuaBll bll = new MulaolaoBll.Bll.ShenChanJinDuJiHuaBll( );
        DataTable queryTable, queryOnly;

        private void ShenChanJinDuJiHuaAll_Load ( object sender ,EventArgs e )
        {
            GridViewMoHuSelect.SetFilter( gridView1 );
            assginMent( );

            userControl11.OnPageChanged += new EventHandler( userControl11_OnPageChanged );
        }

        void userControl11_OnPageChanged ( object sender ,EventArgs e )
        {
            pageToDataTable( );
        }

        //Bind to datasource
        void assginMent ( )
        {
            queryOnly = bll.GetDataTableOnly( );
            lookUpEdit1.Properties.DataSource = queryOnly.DefaultView.ToTable( true ,"PQX33" );
            lookUpEdit1.Properties.DisplayMember = "PQX33";
            lookUpEdit2.Properties.DataSource = queryOnly.DefaultView.ToTable( true ,"PQX01" );
            lookUpEdit2.Properties.DisplayMember = "PQX01";
            lookUpEdit3.Properties.DataSource = queryOnly.DefaultView.ToTable( true ,"PQX29" );
            lookUpEdit3.Properties.DisplayMember = "PQX29";
            lookUpEdit4.Properties.DataSource = queryOnly.DefaultView.ToTable( true ,"PQX31" );
            lookUpEdit4.Properties.DisplayMember = "PQX31";
            lookUpEdit5.Properties.DataSource = queryOnly.DefaultView.ToTable( true ,"PQX03" );
            lookUpEdit5.Properties.DisplayMember = "PQX03";
        }
        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string.IsNullOrEmpty( lookUpEdit1.Text ) )
                strWhere = strWhere + " AND PQX33='" + lookUpEdit1.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit2.Text ) )
                strWhere = strWhere + " AND PQX01='" + lookUpEdit2.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit3.Text ) )
                strWhere = strWhere + " AND PQX29='" + lookUpEdit3.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit4.Text ) )
                strWhere = strWhere + " AND PQX31='" + lookUpEdit4.Text + "'";
            if ( !string.IsNullOrEmpty( lookUpEdit5.Text ) )
                strWhere = strWhere + " AND PQX03='" + lookUpEdit5.Text + "'";
            if ( !string . IsNullOrEmpty ( dateEdit1 . Text ) )
                strWhere = strWhere + " AND SUBSTRING(CONVERT(VARCHAR,PQX30),0,5)='" + dateEdit1 . Text + "'";

            pageToDataTable ( );
        }


        //Bind data source and pageChange
        void pageToDataTable ( )
        {
            int count = bll.GetShenChanCount( strWhere );
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            if ( userControl11.pageIndex <= 1 )
                queryTable = bll.GetDataTableByPage( strWhere ,0 ,userControl11.pageSize );
            else
                queryTable = bll.GetDataTableByPage( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            gridControl1.DataSource = queryTable;
        }

        //Clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            lookUpEdit1.EditValue = lookUpEdit2.EditValue = lookUpEdit3.EditValue = lookUpEdit4.EditValue = lookUpEdit5.EditValue = null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex = lookUpEdit4.ItemIndex = lookUpEdit5.ItemIndex = -1;
            dateEdit1 . Text = string . Empty;
        }

        //Value
        string cn1 = "", cn2 = "", cn3 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "PQX33" ).ToString( );
            cn2 = gridView1.GetFocusedRowCellValue( "PQX31" ).ToString( );
            cn3 = gridView1.GetFocusedRowCellValue( "PQX01" ).ToString( );
            this . DialogResult = System . Windows . Forms . DialogResult . OK;
            //PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 );
            //if ( PassDataBetweenForm != null )
            //{
            //    PassDataBetweenForm( this ,args );
            //}
            //this.Close( );
        }

        public string getOdd
        {
            get
            {
                return cn1;
            }
        }

        public string getHNum
        {
            get
            {
                return cn2;
            }
        }

        public string Num
        {
            get
            {
                return cn3;
            }
        }

    }
}
