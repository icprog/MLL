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
    public partial class r339 :DevExpress . XtraEditors . XtraForm
    {
        MulaolaoBll.Bll.QuoBll _bll=null;
        MulaolaoLibrary.YouQiLibrary model;

        public r339 ( MulaolaoLibrary . YouQiLibrary model )
        {
            InitializeComponent ( );

            this . model = model;
            _bll = new MulaolaoBll . Bll . QuoBll ( );

            GridViewMoHuSelect . SetFilter ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { View } );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { View } );

            setValue ( );
            getInfo ( );
        }

        void setValue ( )
        {
            txtYQ10 . Text = model . YQ10;
            txtYQ112 . Text = model . YQ112 . ToString ( );
            txtYQ119 . Text = model . YQ119;
            txtYQ19 . Text = model . YQ19 . ToString ( );
        }

        void getInfo ( )
        {
            DataTable table = _bll . getTableFor339Info ( model . YQ05 );
            txtYQ10 . Properties . DataSource = table;
            txtYQ10 . Properties . DisplayMember = "YQ10";
            txtYQ10 . Properties . ValueMember = "YQ10";
        }

        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

        private void btnSure_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtYQ10 . Text ) )
            {
                XtraMessageBox . Show ( "请选择零件名称" );
                return;
            }
            if ( string . IsNullOrEmpty ( txtYQ19 . Text ) )
            {
                XtraMessageBox . Show ( "请录入数量" );
                return;
            }
            int ourResult = 0;
            if ( int . TryParse ( txtYQ19 . Text ,out ourResult ) == false )
            {
                XtraMessageBox . Show ( "数量为整数" );
                return;
            }
            model . YQ19 = ourResult;
            model . YQ10 = txtYQ10 . Text;
            model . YQ119 = txtYQ119 . Text;
            if ( !string . IsNullOrEmpty ( txtYQ112 . Text ) && int . TryParse ( txtYQ112 . Text ,out ourResult ) == false )
            {
                XtraMessageBox . Show ( "每套部件数量为整数" );
                return;
            }
            model . YQ112 = ourResult;

            this . DialogResult = DialogResult . OK;
        }

        public MulaolaoLibrary . YouQiLibrary getModel
        {
            get
            {
                return model;
            }
        }

        private void txtYQ10_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = View . GetFocusedDataRow ( );
            if ( row == null )
                return;
            txtYQ112 . Text = row [ "YQ112" ] . ToString ( );
            txtYQ119 . Text = row [ "YQ119" ] . ToString ( );
        }

    }
}