using Mulaolao;
using Mulaolao . Class;
using SelectAll . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Threading . Tasks;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class ChanPinGongZiKaoQinAll : FormBase
    {
        public ChanPinGongZiKaoQinAll ( )
        {
            InitializeComponent( );
            GridViewMoHuSelect . SetFilter ( gridView1 );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }
        
        //public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        //public event PassDataBetweenFormHandler PassDataBetweenForm;
        
        MulaolaoBll.Bll.ChanPinGongZiKaoQinBll bll = new MulaolaoBll.Bll.ChanPinGongZiKaoQinBll( );
        DataTable da, tableQuery;
        public string nameOfTj;
        
        private void ChanPinGongZiKaoQinAll_Load ( object sender ,EventArgs e )
        {

            comboBox1 . Text = comboBox2 . Text = comboBox3 . Text = comboBox4 . Text = comboBox6 . Text = string . Empty;
            Task tk = new Task ( assignMent );
            tk . Start ( );
            //assignMent ( );

            userControl11.OnPageChanged += new EventHandler( userControl11_OnPageChanged );
        }
        
        void userControl11_OnPageChanged ( object sender ,EventArgs e )
        {
            pageToDataTable( );
        }

        //Bind data source
        void assignMent ( )
        {

            da = bll . GetDataTableOnly ( );
            if ( comboBox1 . InvokeRequired )
            {
                Action<string> actionDelete = ( x ) =>
                {
                    comboBox1 . DataSource = da . DefaultView . ToTable ( true ,"GZ29" );
                    comboBox1 . DisplayMember = "GZ29";
                };
                this . comboBox1 . Invoke ( actionDelete ,string . Empty );
            }

            if ( comboBox2 . InvokeRequired )
            {
                Action<string> actionDelete = ( x ) =>
                {
                    comboBox2 . DataSource = da . DefaultView . ToTable ( true ,"GZ01" );
                    comboBox2 . DisplayMember = "GZ01";
                };
                this . comboBox2 . Invoke ( actionDelete ,string . Empty );
            }

            if ( comboBox3 . InvokeRequired )
            {
                Action<string> actionDelete = ( x ) =>
                {
                    comboBox3 . DataSource = da . DefaultView . ToTable ( true ,"GZ22" );
                    comboBox3 . DisplayMember = "GZ22";
                };
                this . comboBox3 . Invoke ( actionDelete ,string . Empty );
            }

            if ( comboBox4 . InvokeRequired )
            {
                Action<string> actionDelete = ( x ) =>
                {
                    comboBox4 . DataSource = da . DefaultView . ToTable ( true ,"GZ23" );
                    comboBox4 . DisplayMember = "GZ23";
                };
                this . comboBox4 . Invoke ( actionDelete ,string . Empty );
            }

            if ( comboBox6 . InvokeRequired )
            {
                Action<string> actionDelete = ( x ) =>
                {
                    comboBox6 . DataSource = da . DefaultView . ToTable ( true ,"GZ03" );
                    comboBox6 . DisplayMember = "GZ03";
                };
                this . comboBox6 . Invoke ( actionDelete ,string . Empty );
            }

            if ( lookUpEdit1 . InvokeRequired )
            {
                Action<string> actionDelete = ( x ) =>
                {
                    lookUpEdit1 . Properties . DataSource = bll . GetDataTableTj ( );
                    lookUpEdit1 . Properties . DisplayMember = "GZ16";
                    lookUpEdit1 . Properties . ValueMember = "GZ32";
                };
                this . lookUpEdit1 . Invoke ( actionDelete ,string . Empty );
            }

        }

        //query queey
        private void comboBox1_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( da.DefaultView.ToTable( true ,"GZ29" ) ,comboBox1 ,"GZ29" );
            Cursor = Cursors.Default;
        }
        private void comboBox2_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( da.DefaultView.ToTable( true ,"GZ01" ) ,comboBox2 ,"GZ01" );
            Cursor = Cursors.Default;
        }
        private void comboBox3_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( da.DefaultView.ToTable( true ,"GZ22" ) ,comboBox3 ,"GZ22" );
            Cursor = Cursors.Default;
        }
        private void comboBox4_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( da.DefaultView.ToTable( true ,"GZ23" ) ,comboBox4 ,"GZ23" );
            Cursor = Cursors.Default;
        }
        private void comboBox6_TextUpdate ( object sender ,EventArgs e )
        {
            SailesCombobox cq = new SailesCombobox( );
            cq.comboboxQuery( da.DefaultView.ToTable( true ,"GZ03" ) ,comboBox6 ,"GZ03" );
            Cursor = Cursors.Default;
        }
        private void lookUpEdit1_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit1.EditValue != null )
            {
                lookUpEdit2.Properties.DataSource = bll.GetDataTableWorkPerSon( " GZ32='" + lookUpEdit1.EditValue.ToString( ) + "'" );
                lookUpEdit2.Properties.DisplayMember = "GZ02";
                lookUpEdit2.Properties.ValueMember = "GZ33";
                lookUpEdit3.Properties.DataSource = bll.GetDataTableLeadesr( lookUpEdit1.EditValue.ToString( ) );
                lookUpEdit3.Properties.DisplayMember = "GZ37";
                lookUpEdit3.Properties.ValueMember = "GZ38";
            }
        }
        private void lookUpEdit3_EditValueChanged ( object sender ,EventArgs e )
        {
            if ( lookUpEdit3.EditValue != null )
            {
                lookUpEdit2.Properties.DataSource = bll.GetDataTableWorkPerSon( " GZ38='" + lookUpEdit3.EditValue.ToString( ) + "'" );
                lookUpEdit2.Properties.DisplayMember = "GZ02";
                lookUpEdit2.Properties.ValueMember = "GZ33";
            }
        }
        //query
        string strWhere = "1=1";
        private void button1_Click ( object sender ,EventArgs e )
        {
            strWhere = "1=1";
            if ( !string . IsNullOrEmpty ( comboBox1 . Text ) )
                strWhere = strWhere + " AND GZ29='" + comboBox1 . Text + "'";
            if ( !string . IsNullOrEmpty ( comboBox2 . Text ) )
                strWhere = strWhere + " AND GZ01='" + comboBox2 . Text + "'";
            if ( !string . IsNullOrEmpty ( comboBox3 . Text ) )
                strWhere = strWhere + " AND GZ22='" + comboBox3 . Text + "'";
            if ( !string . IsNullOrEmpty ( comboBox4 . Text ) )
                strWhere = strWhere + " AND GZ23='" + comboBox4 . Text + "'";
            if ( !string . IsNullOrEmpty ( comboBox6 . Text ) )
                strWhere = strWhere + " AND GZ03='" + comboBox6 . Text + "'";
            if ( lookUpEdit1 . EditValue != null )
                strWhere = strWhere + " AND GZ32='" + lookUpEdit1 . EditValue . ToString ( ) + "'";
            if ( lookUpEdit2 . EditValue != null )
                strWhere = strWhere + " AND GZ33='" + lookUpEdit2 . EditValue . ToString ( ) + "'";
            if ( lookUpEdit3 . EditValue != null )
                strWhere = strWhere + " AND GZ38='" + lookUpEdit3 . EditValue . ToString ( ) + "'";
            if ( !string . IsNullOrEmpty ( dateEdit1 . Text ) )
                strWhere = strWhere + " AND GZ35='" + dateEdit1 . Text + "'";

            bool result = bll . ExistsTJ ( nameOfTj );
            if ( result == true )
                // AND idx NOT IN (SELECT FZ002 FROM R_PQFZ WHERE FZ001 IN (SELECT A.idx FROM R_PQEZ A,R_REVIEWS B WHERE A.EZ001=B.RES06 AND RES05='执行'))
                strWhere = strWhere + " AND GZ38='" + nameOfTj + "'";
            pageToDataTable ( );
        }

        //Bind data source and pageChange
        void pageToDataTable ( )
        {
            int count = 0;
            count = bll.GetChanPinCount( strWhere );
            userControl11.DrawCount( count );
            pageByChange( );
        }
        void pageByChange ( )
        {
            try
            {
                Task ts = new Task ( edit );
                ts . Start ( );
            }
            catch { }
            if ( userControl11.pageIndex <= 1 )
                tableQuery = bll.GetDataTableByChange( strWhere ,0 ,userControl11.pageSize );
            else
                tableQuery = bll.GetDataTableByChange( strWhere ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + 1 ,userControl11.pageSize * ( userControl11.pageIndex - 1 ) + userControl11.pageSize );
            tableQuery.Columns.Add( "check" ,Type.GetType( "System.Boolean" ) );
            gridControl1.DataSource = tableQuery;
        }


        void edit ( )
        {
            bll . Update ( );
        }

        //Clear
        private void button2_Click ( object sender ,EventArgs e )
        {
            comboBox1 . Text = comboBox2 . Text = comboBox3 . Text = comboBox4 . Text = comboBox6 . Text = dateEdit1 . Text = "";
            lookUpEdit1.EditValue = lookUpEdit2.EditValue =lookUpEdit3.EditValue= null;
            lookUpEdit1.ItemIndex = lookUpEdit2.ItemIndex = lookUpEdit3.ItemIndex=-1;
        }

        //Value
        string cn1 = "", cn2 = "", cn3 = "";
        private void gridView1_DoubleClick ( object sender ,EventArgs e )
        {
            cn1 = gridView1.GetFocusedRowCellValue( "GZ29" ).ToString( );
            cn2 = gridView1.GetFocusedRowCellValue( "GZ23" ).ToString( );
            cn3 = gridView1.GetFocusedRowCellValue( "RES05" ).ToString( );
            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,cn2 ,cn3 );
            //if ( PassDataBetweenForm != null )
            //{
            //    PassDataBetweenForm( this ,args );
            //}

            //this.Close( );
            this . DialogResult = DialogResult . OK;
        }

        private void gridView1_RowClick ( object sender ,DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e )
        {
            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                int num = gridView1.FocusedRowHandle;
                if ( gridView1.GetDataRow( num )["check"].ToString( ) == "True" )
                    gridView1.GetDataRow( num )["check"] = false;
                else
                    gridView1.GetDataRow( num )["check"] = true;
            }
        }

        //checkAll
        protected override void checkAll ( )
        {
            base.checkAll( );

            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    gridView1.GetDataRow( i )["check"] = true;
                }
            }
        }

        //unCheckAll
        protected override void unCheckAll ( )
        {
            base.unCheckAll( );

            if ( gridView1.FocusedRowHandle >= 0 && gridView1.FocusedRowHandle <= gridView1.RowCount - 1 )
            {
                for ( int i = 0 ; i < gridView1.RowCount ; i++ )
                {
                    gridView1.GetDataRow( i )["check"] = false;
                }
            }
        }

        //sure
        List<string> list = new List<string>( );
        protected override void sure ( )
        {
            base.sure( );

            for ( int i = 0 ; i < gridView1.RowCount ; i++ )
            {
                if ( gridView1.GetDataRow( i )["check"].ToString( ) == "True" )
                {
                    if ( !string.IsNullOrEmpty( gridView1.GetDataRow( i )["idx"].ToString( ) ) )
                    {
                        list.Add( gridView1.GetDataRow( i )["idx"].ToString( ) );
                    }
                    if ( gridView1.GetDataRow( i )["RES05"].ToString( ) == "执行" )
                    {
                        cn1 = "执行";
                    }
                }   
            }

            this . DialogResult = DialogResult . OK;
            //PassDataWinFormEventArgs args = new PassDataWinFormEventArgs( cn1 ,list );
            //if ( PassDataBetweenForm != null )
            //{
            //    PassDataBetweenForm( this ,args );
            //}
            //this.Close( );
        }

        public string getCn1
        {
            get
            {
                return cn1;
            }
        }
        public string getCn2
        {
            get
            {
                return cn2;
            }
        }
        public string getCn3
        {
            get
            {
                return cn3;
            }
        }

        public List<string> strList
        {
            get
            {
                return list;
            }
        }

        //queryAll
        private void button3_Click ( object sender , EventArgs e )
        {
            cn1 = "queryAll";

            this . DialogResult = DialogResult . OK;
            //PassDataWinFormEventArgs args = new PassDataWinFormEventArgs ( cn1 );
            //if ( PassDataBetweenForm != null )
            //{
            //    PassDataBetweenForm ( this , args );
            //}

            //this . Close ( );
        }
    }
}
