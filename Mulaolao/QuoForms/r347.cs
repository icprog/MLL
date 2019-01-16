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
    public partial class r347 :DevExpress . XtraEditors . XtraForm
    {
        MulaolaoBll.Bll.QuoBll _bll=null;
        MulaolaoLibrary .SuLiaoBuQiContractLibrary model=null;

        public r347 ( MulaolaoLibrary . SuLiaoBuQiContractLibrary model )
        {
            InitializeComponent ( );

            _bll = new MulaolaoBll . Bll . QuoBll ( );

            GridViewMoHuSelect . SetFilter ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { View } );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { View } );

            this . model = model;
            setValue ( );
            getInfo ( );
        }

        void setValue ( )
        {
            txtPJ09 . Text = model . PJ09;
            txtPJ11 . Text = Convert . ToDecimal ( model . PJ11 ) . ToString ( "0.######" );
            txtPJ12 . Text = Convert . ToDecimal ( model . PJ12 ) . ToString ( "0.######" );
            txtPJ89 . Text = model . PJ89;
            txtPJ97 . Text = Convert . ToDecimal ( model . PJ97 ) . ToString ( "0.######" );
        }

        void getInfo ( )
        {
            DataTable tableOne = _bll . getTableFor347Info ( Convert . ToDateTime ( model . PJ05 ) );
            txtPJ09 . Properties . DataSource = tableOne;
            txtPJ09 . Properties . DisplayMember = "PJ09";
            txtPJ09 . Properties . ValueMember = "PJ09";
        }

        private void btnCacnel_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

        private void btnSure_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtPJ09 . Text ) )
            {
                XtraMessageBox . Show ( "请选择物品名称" );
                return;
            }
            model . PJ09 = txtPJ09 . Text;
            if ( string . IsNullOrEmpty ( txtPJ89 . Text ) )
            {
                XtraMessageBox . Show ( "规格不可为空" );
                return;
            }
            model . PJ89 = txtPJ89 . Text;
            if ( string . IsNullOrEmpty ( txtPJ11 . Text ) )
            {
                XtraMessageBox . Show ( "每套用量不可为空" );
                return;
            }
            decimal outResult = 0M;
            if ( decimal . TryParse ( txtPJ11 . Text ,out outResult ) == false )
            {
                XtraMessageBox . Show ( "每套用量是数字" );
                return;
            }
            model . PJ11 = outResult;
            if ( string . IsNullOrEmpty ( txtPJ12 . Text ) )
            {
                XtraMessageBox . Show ( "现价不可为空" );
                return;
            }
            outResult = 0M;
            if ( decimal . TryParse ( txtPJ12 . Text ,out outResult ) == false )
            {
                XtraMessageBox . Show ( "现价是数字" );
                return;
            }
            model . PJ12 = outResult;
            if ( string . IsNullOrEmpty ( txtPJ97 . Text ) )
            {
                XtraMessageBox . Show ( "数量不可为空" );
                return;
            }
            outResult = 0M;
            if ( decimal . TryParse ( txtPJ97 . Text ,out outResult ) == false )
            {
                XtraMessageBox . Show ( "数量是数字" );
                return;
            }
            model . PJ97 = outResult;
            this . DialogResult = DialogResult . OK;
        }

        public MulaolaoLibrary . SuLiaoBuQiContractLibrary getModel
        {
            get
            {
                return model;
            }
        }

        private void txtPJ09_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = View . GetFocusedDataRow ( );
            if ( row == null )
                return;
            txtPJ11 . Text = row [ "PJ11" ] . ToString ( );
            txtPJ12 . Text = row [ "PJ12" ] . ToString ( );
            txtPJ89 . Text = row [ "PJ89" ] . ToString ( );
        }

    }
}