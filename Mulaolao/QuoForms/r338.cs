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
    public partial class r338 :DevExpress . XtraEditors . XtraForm
    {
        MulaolaoBll.Bll.QuoBll _bll=null;
        MulaolaoLibrary.JiaoMiDuContractLibrary model=null;

        public r338 ( MulaolaoLibrary . JiaoMiDuContractLibrary model )
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

        private void btnOk_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtJM09 . Text ) )
            {
                XtraMessageBox . Show ( "请选择零件名称" );
                return;
            }
            model . JM09 = txtJM09 . Text;
            if ( string . IsNullOrEmpty ( txtJM10 . Text ) )
            {
                XtraMessageBox . Show ( "每张零件个数不可为空" );
                return;
            }
            decimal resultOut = 0M;
            if ( !string . IsNullOrEmpty ( txtJM10 . Text ) && decimal . TryParse ( txtJM10 . Text ,out resultOut ) == false )
            {
                XtraMessageBox . Show ( "每张零件个数是数字" );
                return;
            }
            model . JM10 = resultOut;
            if ( string . IsNullOrEmpty ( txtJM11 . Text ) )
            {
                XtraMessageBox . Show ( "每张单价不可为空" );
                return;
            }
            resultOut = 0M;
            if ( !string . IsNullOrEmpty ( txtJM11 . Text ) && decimal . TryParse ( txtJM11 . Text ,out resultOut ) == false )
            {
                XtraMessageBox . Show ( "每张单价是数字" );
                return;
            }
            model . JM11 = resultOut;
            if ( string . IsNullOrEmpty ( txtJM15 . Text ) )
            {
                XtraMessageBox . Show ( "数量不可为空" );
                return;
            }
            resultOut = 0M;
            if ( !string . IsNullOrEmpty ( txtJM15 . Text ) && decimal . TryParse ( txtJM15 . Text ,out resultOut ) == false )
            {
                XtraMessageBox . Show ( "数量是数字" );
                return;
            }
            model . JM15 = resultOut;
            if ( string . IsNullOrEmpty ( txtJM94 . Text ) )
            {
                XtraMessageBox . Show ( "长不可为空" );
                return;
            }
            resultOut = 0M;
            if ( !string . IsNullOrEmpty ( txtJM94 . Text ) && decimal . TryParse ( txtJM94 . Text ,out resultOut ) == false )
            {
                XtraMessageBox . Show ( "长是数字" );
                return;
            }
            model . JM94 = resultOut;
            if ( string . IsNullOrEmpty ( txtJM95 . Text ) )
            {
                XtraMessageBox . Show ( "宽不可为空" );
                return;
            }
            resultOut = 0M;
            if ( !string . IsNullOrEmpty ( txtJM95 . Text ) && decimal . TryParse ( txtJM95 . Text ,out resultOut ) == false )
            {
                XtraMessageBox . Show ( "宽是数字" );
                return;
            }
            model . JM95 = resultOut;
            if ( string . IsNullOrEmpty ( txtJM96 . Text ) )
            {
                XtraMessageBox . Show ( "高不可为空" );
                return;
            }
            resultOut = 0M;
            if ( !string . IsNullOrEmpty ( txtJM96 . Text ) && decimal . TryParse ( txtJM96 . Text ,out resultOut ) == false )
            {
                XtraMessageBox . Show ( "高是数字" );
                return;
            }
            model . JM96 = resultOut;
            resultOut = 0M;
            if ( !string . IsNullOrEmpty ( txtJM120 . Text ) && decimal . TryParse ( txtJM120 . Text ,out resultOut ) == false )
            {
                XtraMessageBox . Show ( "m³/单价是数字" );
                return;
            }
            model . JM120 = resultOut;

            this . DialogResult = DialogResult . OK;
        }

        public MulaolaoLibrary . JiaoMiDuContractLibrary getModel
        {
            get
            {
                return model;
            }
        }

        void setValue ( )
        {
            txtJM09 . Text = model . JM09;
            txtJM10 . Text = model . JM10 . ToString ( "0.######" );
            txtJM11 . Text = model . JM11 . ToString ( "0.######" );
            txtJM15 . Text = model . JM15 . ToString ( "0.######" );
            txtJM94 . Text = model . JM94 . ToString ( );
            txtJM95 . Text = model . JM95 . ToString ( );
            txtJM96 . Text = model . JM96 . ToString ( );
            txtJM120 . Text = Convert . ToDecimal ( model . JM120 ) . ToString ( "0.######" );
        }

        void getInfo ( )
        {
            DataTable tableOne = _bll . getTableFor338Info ( model . JM05 );
            txtJM09 . Properties . DataSource = tableOne;
            txtJM09 . Properties . DisplayMember = "JM09";
            txtJM09 . Properties . ValueMember = "JM09";
        }

        private void txtJM09_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = View . GetFocusedDataRow ( );
            if ( row == null )
                return;
            txtJM10 . Text = row [ "JM10" ] . ToString ( );
            txtJM11 . Text = row [ "JM11" ] . ToString ( );
            txtJM94 . Text = row [ "JM94" ] . ToString ( );
            txtJM95 . Text = row [ "JM95" ] . ToString ( );
            txtJM96 . Text = row [ "JM96" ] . ToString ( );
            txtJM120 . Text = row [ "JM120" ] . ToString ( );
        }

    }
}