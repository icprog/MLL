using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Text;
using System . Linq;
using System . Windows . Forms;
using DevExpress . XtraEditors;
using Mulaolao . Class;

namespace Mulaolao . QuoForms
{
    public partial class r349 :DevExpress . XtraEditors . XtraForm
    {
        MulaolaoBll.Bll.QuoBll _bll=null;
        MulaolaoLibrary .WaiXianContractLibrary model=null;

        public r349 ( MulaolaoLibrary . WaiXianContractLibrary model )
        {
            InitializeComponent ( );

            _bll = new MulaolaoBll . Bll . QuoBll ( );

            GridViewMoHuSelect . SetFilter ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { View } );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { View } );

            this . model = model;

            setValue ( );
            getInfo ( );
        }

        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

        private void btnSure_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtWX10 . Text ) )
            {
                XtraMessageBox . Show ( "请选择零件" );return;
            }
            model . WX10 = txtWX10 . Text;
            if ( string . IsNullOrEmpty ( txtWX11 . Text ) )
            {
                XtraMessageBox . Show ( "规格不可为空" );
                return;
            }
            model . WX11 = txtWX11 . Text;
            if ( string . IsNullOrEmpty ( txtWX13 . Text ) )
            {
                XtraMessageBox . Show ( "现价不可为空" );
                return;
            }
            decimal outResult = 0M;
            if ( decimal . TryParse ( txtWX13 . Text,out outResult ) == false )
            {
                XtraMessageBox . Show ( "现价是数字" );
                return;
            }
            model . WX13 = outResult;
            if ( string . IsNullOrEmpty ( txtWX14 . Text ) )
            {
                XtraMessageBox . Show ( "每套用量不可为空" );
                return;
            }
            outResult = 0M;
            if ( decimal . TryParse ( txtWX14 . Text ,out outResult ) == false )
            {
                XtraMessageBox . Show ( "每套用量是数字" );
                return;
            }
            model . WX14 = outResult;
            if ( string . IsNullOrEmpty ( txtWX16 . Text ) )
            {
                XtraMessageBox . Show ( "数量不可为空" );
                return;
            }
            long outResultLong = 0;
            if ( long . TryParse ( txtWX16 . Text ,out outResultLong ) == false )
            {
                XtraMessageBox . Show ( "数量是数字" );
                return;
            }
            model . WX16 = outResultLong;
            this . DialogResult = DialogResult . OK;
        }

        void setValue ( )
        {
            txtWX10 . Text = model . WX10;
            txtWX11 . Text = model . WX11;
            txtWX13 . Text = Convert . ToDecimal ( model . WX13 ) . ToString ( "0.######" );
            txtWX14 . Text = Convert . ToDecimal ( model . WX14 ). ToString ( "0.######" );
            txtWX16 . Text = model . WX16 . ToString ( );
        }

        void getInfo ( )
        {
            DataTable tableOne = _bll . getTableFor349Info ( Convert . ToDateTime ( model . WX04 ) );
            txtWX10 . Properties . DataSource = tableOne;
            txtWX10 . Properties . DisplayMember = "WX10";
            txtWX10 . Properties . ValueMember = "WX10";
        }

        private void txtWX10_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = View . GetFocusedDataRow ( );
            if ( row == null )
                return;
            txtWX11 . Text = row [ "WX11" ] . ToString ( );
            txtWX13 . Text = row [ "WX13" ] . ToString ( );
            txtWX14 . Text = row [ "WX14" ] . ToString ( );
        }

        public MulaolaoLibrary . WaiXianContractLibrary getModel
        {
            get
            {
                return model;
            }
        }

    }
}