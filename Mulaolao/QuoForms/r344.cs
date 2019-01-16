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
    public partial class r344 :DevExpress . XtraEditors . XtraForm
    {
        MulaolaoLibrary.GunQiContractLibrary model;
        MulaolaoBll .Bll.QuoBll _bll=null;

        public r344 ( MulaolaoLibrary . GunQiContractLibrary model )
        {
            InitializeComponent ( );

            this . model = model;

            GridViewMoHuSelect . SetFilter ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { View } );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { View } );

            _bll = new MulaolaoBll . Bll . QuoBll ( );

            setValue ( );
            getInfo ( );
        }

        void setValue ( )
        {
            txtMZ016 . Text = model . MZ016;
            txtMZ018 . Text = model . MZ018;
            txtMZ021 . Text = model . MZ021 . ToString ( );
            txtMZ025 . Text = model . MZ025 . ToString ( );
            txtMZ105 . Text = model . MZ105 . ToString ( );
        }
        void getInfo ( )
        {
            DataTable table = _bll . getTableFor344Info ( model . MZ007 );
            txtMZ016 . Properties . DataSource = table;
            txtMZ016 . Properties . DisplayMember = "MZ016";
            txtMZ016 . Properties . ValueMember = "MZ016";
        }

        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

        private void btnSure_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtMZ016 . Text ) )
            {
                XtraMessageBox . Show ( "请选择零件名称" );
                return;
            }
            model . MZ016 = txtMZ016 . Text;
            decimal outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtMZ025 . Text ) && decimal . TryParse ( txtMZ025 . Text ,out outResult ) == false )
            {
                XtraMessageBox . Show ( "油漆单价是数字" );
                return;
            }
            model . MZ025 = outResult;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtMZ105 . Text ) && decimal . TryParse ( txtMZ105 . Text ,out outResult ) == false )
            {
                return;
            }
            model . MZ105 = outResult;
            int outResu = 0;
            if ( !string . IsNullOrEmpty ( txtMZ021 . Text ) && int . TryParse ( txtMZ021 . Text ,out outResu ) == false )
            {
                XtraMessageBox . Show ( "数量是整数" );
                return;
            }
            model . MZ021 = outResu;
            model . MZ018 = txtMZ018 . Text;

            this . DialogResult = DialogResult . OK;
        }

        private void txtMZ016_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = View . GetFocusedDataRow ( );
            if ( row == null )
                return;
            txtMZ018 . Text = row [ "MZ018" ] . ToString ( );
            txtMZ025 . Text = row [ "MZ025" ] . ToString ( );
        }

        private void txtMZ018_TextChanged ( object sender ,EventArgs e )
        {
            txtMZ105 . Text = Calcu344Spe . calculVolume ( txtMZ018 . Text ) . ToString ( );
        }

        public MulaolaoLibrary . GunQiContractLibrary getModel
        {
            get
            {
                return model;
            }
        }

    }
}