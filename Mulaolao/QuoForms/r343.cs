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
    public partial class r343 :DevExpress . XtraEditors . XtraForm
    {
        MulaolaoBll.Bll.QuoBll _bll=null;
        MulaolaoLibrary.WuJinContractLibrary model;

        public r343 ( MulaolaoLibrary . WuJinContractLibrary model )
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
            txtPQU10 . Text = model . PQU10;
            txtPQU12 . Text = model . PQU12;
            txtPQU13 . Text = Convert . ToDecimal ( model . PQU13 ) . ToString ( "0.######" );
            txtPQU16 . Text = Convert . ToDecimal ( model . PQU16 ) . ToString ( "0.######" );
            txtPQU18 . Text = model . PQU18 . ToString ( );
        }

        void getInfo ( )
        {
            DataTable tableOne = _bll . getTableFor343Info ( Convert . ToDateTime ( model . PQU04 ) );
            txtPQU10 . Properties . DataSource = tableOne;
            txtPQU10 . Properties . DisplayMember = "PQU10";
            txtPQU10 . Properties . ValueMember = "PQU10";
        }

        private void simpleButton2_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

        private void simpleButton1_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtPQU10 . Text ) )
            {
                XtraMessageBox . Show ( "请选择部件名称" );
                return;
            }
            model . PQU10 = txtPQU10 . Text;
            if ( string . IsNullOrEmpty ( txtPQU12 . Text ) )
            {
                XtraMessageBox . Show ( "请录入规格尺寸" );
                return;
            }
            model . PQU12 = txtPQU12 . Text;
            if ( string . IsNullOrEmpty ( txtPQU13 . Text ) )
            {
                XtraMessageBox . Show ( "每套部件用量不可为空" );
                return;
            }
            decimal outResult = 0M;
            if ( decimal . TryParse ( txtPQU13 . Text ,out outResult ) == false )
            {
                XtraMessageBox . Show ( "每套部件用量为数字" );
                return;
            }
            model . PQU13 = outResult;
            if ( string . IsNullOrEmpty ( txtPQU16 . Text ) )
            {
                XtraMessageBox . Show ( "现价不可为空" );
                return;
            }
             outResult = 0M;
            if ( decimal . TryParse ( txtPQU16 . Text ,out outResult ) == false )
            {
                XtraMessageBox . Show ( "现价为数字" );
                return;
            }
            model . PQU16 = outResult;
            if ( string . IsNullOrEmpty ( txtPQU18 . Text ) )
            {
                XtraMessageBox . Show ( "数量不可为空" );
                return;
            }
            outResult = 0M;
            if ( decimal . TryParse ( txtPQU18 . Text ,out outResult ) == false )
            {
                XtraMessageBox . Show ( "数量为数字" );
                return;
            }
            model . PQU18 = outResult;
            this . DialogResult = DialogResult . OK;
        }

        public MulaolaoLibrary . WuJinContractLibrary getModel
        {
            get
            {
                return model;
            }
        }

        private void txtPQU10_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = View . GetFocusedDataRow ( );
            if ( row == null )
                return;
            txtPQU12 . Text = row [ "PQU12" ] . ToString ( );
            txtPQU13 . Text = row [ "PQU13" ] . ToString ( );
            txtPQU16 . Text = row [ "PQU16" ] . ToString ( );
        }

    }
}