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
    public partial class r341 :DevExpress . XtraEditors . XtraForm
    {
        MulaolaoBll.Bll.QuoBll _bll=null;
        MulaolaoLibrary.MuCaiContractLibrary model=null;

        public r341 ( MulaolaoLibrary . MuCaiContractLibrary model )
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
            txtPQV10 . Text = model . PQV10;
            txtPQV11 . Text = model . PQV11 . ToString ( "0.######" );
            txtPQV12 . Text = model . PQV12 . ToString ( "0.######" );
            txtPQV64 . Text = model . PQV64 . ToString ( "0.######" );
            txtPQV71 . Text = model . PQV71 . ToString ( "0.######" );
            txtPQV72 . Text = model . PQV72 . ToString ( "0.######" );
            txtPQV73 . Text = model . PQV73 . ToString ( "0.######" );
        }

        void getInfo ( )
        {
            DataTable tableOne = _bll . getTableFor341Info ( model . PQV04 );
            txtPQV10 . Properties . DataSource = tableOne;
            txtPQV10 . Properties . DisplayMember = "PQV10";
            txtPQV10 . Properties . ValueMember = "PQV10";
        }

        private void simpleButton2_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

        private void simpleButton1_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtPQV10 . Text ) )
            {
                XtraMessageBox . Show ( "请选择物料或部件名称" );
                return;
            }
            model . PQV10 = txtPQV10 . Text;
            if ( string . IsNullOrEmpty ( txtPQV11 . Text ) )
            {
                XtraMessageBox . Show ( "每立方米现价不可为空" );
                return;
            }
            decimal outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtPQV11 . Text ) && decimal . TryParse ( txtPQV11 . Text ,out outResult )==false )
            {
                XtraMessageBox . Show ( "每立方米现价为数字" );
                return;
            }
            model . PQV11 = outResult;
            if ( string . IsNullOrEmpty ( txtPQV12 . Text ) )
            {
                XtraMessageBox . Show ( "每立方米现价不可为空" );
                return;
            }
            int outResultInt = 0;
            if ( !string . IsNullOrEmpty ( txtPQV12 . Text ) && int . TryParse ( txtPQV12 . Text ,out outResultInt ) == false )
            {
                XtraMessageBox . Show ( "每套部件数量为整数" );
                return;
            }
            model . PQV12 = outResultInt;
            if ( string . IsNullOrEmpty ( txtPQV71 . Text ) )
            {
                XtraMessageBox . Show ( "长不可为空" );
                return;
            }
             outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtPQV71 . Text ) && decimal . TryParse ( txtPQV71 . Text ,out outResult ) == false )
            {
                XtraMessageBox . Show ( "长为数字" );
                return;
            }
            model . PQV71 = outResult;
            if ( string . IsNullOrEmpty ( txtPQV72 . Text ) )
            {
                XtraMessageBox . Show ( "宽不可为空" );
                return;
            }
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtPQV72 . Text ) && decimal . TryParse ( txtPQV72 . Text ,out outResult ) == false )
            {
                XtraMessageBox . Show ( "宽为数字" );
                return;
            }
            model . PQV72 = outResult;
            if ( string . IsNullOrEmpty ( txtPQV73 . Text ) )
            {
                XtraMessageBox . Show ( "高不可为空" );
                return;
            }
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtPQV73 . Text ) && decimal . TryParse ( txtPQV73 . Text ,out outResult ) == false )
            {
                XtraMessageBox . Show ( "高为数字" );
                return;
            }
            model . PQV73 = outResult;
            if ( string . IsNullOrEmpty ( txtPQV64 . Text ) )
            {
                XtraMessageBox . Show ( "数量不可为空" );
                return;
            }
            outResultInt = 0;
            if ( !string . IsNullOrEmpty ( txtPQV64 . Text ) && int . TryParse ( txtPQV64 . Text ,out outResultInt ) == false )
            {
                XtraMessageBox . Show ( "数量为整数" );
                return;
            }
            if ( outResultInt <= 0 )
            {
                XtraMessageBox . Show ( "请填写数量" );
                return;
            }
            model . PQV64 = outResultInt;
            this . DialogResult = DialogResult . OK;
        }

        public MulaolaoLibrary . MuCaiContractLibrary getModel
        {
            get
            {
                return model;
            }
        }

        private void txtPQV10_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = View . GetFocusedDataRow ( );
            if ( row == null )
                return;
            txtPQV11 . Text = row [ "PQV11" ] . ToString ( );
            txtPQV12 . Text = row [ "PQV12" ] . ToString ( );
            txtPQV71 . Text = row [ "PQV71" ] . ToString ( );
            txtPQV72 . Text = row [ "PQV72" ] . ToString ( );
            txtPQV73 . Text = row [ "PQV73" ] . ToString ( );
        }
    }
}