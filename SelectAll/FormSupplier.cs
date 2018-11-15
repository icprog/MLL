using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class FormSupplier :Form
    {
        public FormSupplier ( )
        {
            InitializeComponent ( );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { gridView1 } );
        }

        public delegate void PassDataBetweenFormHandler ( object sender ,PassDataWinFormEventArgs e );
        public event PassDataBetweenFormHandler PassDataBetweenForm;
        MulaolaoBll.Bll.DetailedDeductionBll _bll = new MulaolaoBll.Bll.DetailedDeductionBll( );
        
        private void FormSupplier_Load ( object sender ,EventArgs e )
        {
            DataTable tableQuery = _bll . GetDataTableGrid ( );
            tableQuery . Columns . Add ( "check" ,typeof ( System . Boolean ) );
            gridControl1 . DataSource = tableQuery;
        }
        
        //checkAll
        private void button18_Click ( object sender ,EventArgs e )
        {
            for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
            {
                gridView1 . GetDataRow ( i ) [ "check" ] = true;
                if ( !strList . Contains ( gridView1 . GetDataRow ( i ) [ "WZ004" ] . ToString ( ) ) )
                    strList . Add ( gridView1 . GetDataRow ( i ) [ "WZ004" ] . ToString ( ) );
            }
        }
        //unCheckAll
        private void button17_Click ( object sender ,EventArgs e )
        {
            for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
            {
                gridView1 . GetDataRow ( i ) [ "check" ] = false;
                if ( strList . Count > 0 && strList . Contains ( gridView1 . GetDataRow ( i ) [ "WZ004" ] . ToString ( ) ) )
                    strList . Remove ( gridView1 . GetDataRow ( i ) [ "WZ004" ] . ToString ( ) );
            }
        }
        //sure
        string cn1="",cn2="",cn3="",cn4="";
        private void button16_Click ( object sender ,EventArgs e )
        {
            count ( );
            if ( cou ( ) == false )
            {
                MessageBox . Show ( "请选择相同的供应商" );
                return;
            }

            PassDataWinFormEventArgs args = new PassDataWinFormEventArgs ( cn1 ,cn2 ,cn3 ,cn4 );
            if ( PassDataBetweenForm != null )
            {
                PassDataBetweenForm ( this ,args );
            }
            this . DialogResult = System . Windows . Forms . DialogResult . OK;
        }
        void count ( )
        {
            decimal one = 0M, two = 0M;
            string idxList = "";
            for ( int i = 0 ; i < gridView1 . DataRowCount ; i++ )
            {
                if ( gridView1 . GetDataRow ( i ) [ "check" ] . ToString ( ) == "True" )
                {
                    one += string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "WZ011" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "WZ011" ] . ToString ( ) );
                    two += string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "WZ012" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "WZ012" ] . ToString ( ) ) + ( string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "WZ013" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "WZ013" ] . ToString ( ) ) ) + ( string . IsNullOrEmpty ( gridView1 . GetDataRow ( i ) [ "WZ014" ] . ToString ( ) ) == true ? 0 : Convert . ToDecimal ( gridView1 . GetDataRow ( i ) [ "WZ014" ] . ToString ( ) ) );
                    if ( idxList == "" )
                        idxList = gridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( );
                    else
                        idxList += "," + gridView1 . GetDataRow ( i ) [ "idx" ] . ToString ( );
                }
            }
            cn1 = one . ToString ( );
            cn2 = two . ToString ( );
            cn3 = idxList;
        }
        bool cou ( )
        {
            bool result = true;
            string st = string . Empty;
            if ( strList . Count < 1 )
                return false;
            foreach ( string str in strList )
            {
                if ( st == "" )
                    st = str;
                else
                {
                    if ( !st . Equals ( str ) )
                    {
                        result = false;
                        break;
                    }
                }
            }
            cn4 = st;
            return result;
        }
        //cancel
        private void button15_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = System . Windows . Forms . DialogResult . Cancel;
        }
        List<string> strList=new List<string>();
        private void gridView1_RowClick ( object sender ,DevExpress . XtraGrid . Views . Grid . RowClickEventArgs e )
        {
            int num = gridView1 . FocusedRowHandle;
            if ( num >= 0 )
            {
                string name = gridView1 . GetDataRow ( num ) [ "WZ004" ] . ToString ( );
                if ( gridView1 . GetDataRow ( num ) [ "check" ] . ToString ( ) == "True" )
                {
                    gridView1 . GetDataRow ( num ) [ "check" ] = false;
                    if ( strList . Count > 0 && strList . Contains ( name ) )
                        strList . Remove ( name );
                }
                else
                {
                    gridView1 . GetDataRow ( num ) [ "check" ] = true;
                    if ( strList . Count < 1 )
                        strList . Add ( name );
                    else if ( !strList . Contains ( name ) )
                        strList . Add ( name );
                }
            }
        }

    }
}
