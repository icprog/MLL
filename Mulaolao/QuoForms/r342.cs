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
    public partial class r342 :DevExpress . XtraEditors . XtraForm
    {
        MulaolaoBll.Bll.QuoBll _bll=null;
        MulaolaoLibrary . CheMuJianContractLibrary model=null;

        public r342 ( MulaolaoLibrary . CheMuJianContractLibrary model )
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
            txtAF015 . Text = model . AF015;
            txtAF019 . Text = model . AF019 . ToString ( "0.######" );
            txtAF020 . Text = model . AF020 . ToString ( "0.######" );
            txtAF021 . Text = model . AF021 . ToString ( "0.######" );
            txtAF022 . Text = model . AF022 . ToString ( "0.######" );
            txtAF023 . Text = model . AF023 . ToString ( "0.######" );
            txtAF087 . Text = model . AF087 . ToString ( "0.######" );
            txtAF088 . Text = model . AF088 . ToString ( "0.######" );
        }

        void getInfo ( )
        {
            DataTable tableOne = _bll . getTableFor342Info ( model . AF009 );
            txtAF015 . Properties . DataSource = tableOne;
            txtAF015 . Properties . DisplayMember = "AF015";
            txtAF015 . Properties . ValueMember = "AF015";
        }

        private void txtAF015_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = View . GetFocusedDataRow ( );
            if ( row == null )
                return;
            txtAF019 . Text = row [ "AF019" ] . ToString ( );
            txtAF020 . Text = row [ "AF020" ] . ToString ( );
            txtAF021 . Text = row [ "AF021" ] . ToString ( );
            txtAF022 . Text = row [ "AF022" ] . ToString ( );
            txtAF023 . Text = row [ "AF023" ] . ToString ( );
            txtAF087 . Text = row [ "AF087" ] . ToString ( );
            txtAF088 . Text = row [ "AF088" ] . ToString ( );
        }

        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

        private void btnOk_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtAF015 . Text ) )
            {
                XtraMessageBox . Show ( "请选择物料或部件名称" );
                return;
            }
            model . AF015 = txtAF015 . Text;
            decimal outResult = 0M;
            if ( string . IsNullOrEmpty ( txtAF019 . Text ) )
            {
                XtraMessageBox . Show ( "每套用量不可为空" );
                return;
            }
            if ( decimal . TryParse ( txtAF019 . Text ,out outResult ) == false )
            {
                XtraMessageBox . Show ( "每套用量为数字" );
                return;
            }
            model . AF019 = outResult;
            outResult = 0M;
            if ( string . IsNullOrEmpty ( txtAF020 . Text ) )
            {
                XtraMessageBox . Show ( "长不可为空" );
                return;
            }
            if ( decimal . TryParse ( txtAF020 . Text ,out outResult ) == false )
            {
                XtraMessageBox . Show ( "长为数字" );
                return;
            }
            model . AF020 = outResult;
            outResult = 0M;
            if ( string . IsNullOrEmpty ( txtAF021 . Text ) )
            {
                XtraMessageBox . Show ( "宽不可为空" );
                return;
            }
            if ( decimal . TryParse ( txtAF021 . Text ,out outResult ) == false )
            {
                XtraMessageBox . Show ( "宽为数字" );
                return;
            }
            model . AF021 = outResult;
            outResult = 0M;
            if ( string . IsNullOrEmpty ( txtAF022 . Text ) )
            {
                XtraMessageBox . Show ( "高不可为空" );
                return;
            }
            if ( decimal . TryParse ( txtAF022 . Text ,out outResult ) == false )
            {
                XtraMessageBox . Show ( "高为数字" );
                return;
            }
            model . AF022 = outResult;
            outResult = 0M;
            if ( string . IsNullOrEmpty ( txtAF023 . Text ) )
            {
                XtraMessageBox . Show ( "每个单价不可为空" );
                return;
            }
            if ( decimal . TryParse ( txtAF023 . Text ,out outResult ) == false )
            {
                XtraMessageBox . Show ( "每个单价为数字" );
                return;
            }
            model . AF023 = outResult;
            outResult = 0M;
            if (!string.IsNullOrEmpty( txtAF087 . Text ) && decimal . TryParse ( txtAF087 . Text ,out outResult ) == false )
            {
                XtraMessageBox . Show ( "每立方米现价为数字" );
                return;
            }
            model . AF087 = outResult;
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtAF088 . Text ) && decimal . TryParse ( txtAF088 . Text ,out outResult ) == false )
            {
                XtraMessageBox . Show ( "每套成本现价为数字" );
                return;
            }
            model . AF088 = outResult;
            if ( string . IsNullOrEmpty ( txtAF018 . Text ) )
            {
                XtraMessageBox . Show ( "数量不可为空" );
                return;
            }
            long outResultLong = 0;
            if ( long . TryParse ( txtAF018 . Text ,out outResultLong ) == false )
            {
                XtraMessageBox . Show ( "数量为整数" );
                return;
            }
            if ( outResultLong <= 0 )
            {
                XtraMessageBox . Show ( "请填写数量" );
                return;
            }
            model . AF018 = outResultLong;
            this . DialogResult = DialogResult . OK;
        }


        public MulaolaoLibrary . CheMuJianContractLibrary getModel
        {
            get
            {
                return model;
            }
        }


    }
}