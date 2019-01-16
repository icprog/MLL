using System;
using System . Data;
using System . Windows . Forms;
using Mulaolao . Class;

namespace Mulaolao . QuoForms
{
    public partial class r195 :DevExpress . XtraEditors . XtraForm
    {
        MulaolaoBll.Bll.QuoBll _bll=null;
        MulaolaoLibrary.ChanPinZhiBiaoLibrary model=null;

        public r195 ( MulaolaoLibrary . ChanPinZhiBiaoLibrary model  )
        {
            InitializeComponent ( );

            _bll = new MulaolaoBll . Bll . QuoBll ( );

            GridViewMoHuSelect . SetFilter ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { view ,View1 } );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { view ,View1 } );
            this . model = model;

            getInfo ( );
        
            setValue ( );
        }

        void getInfo ( )
        {
            DataTable tableOne = _bll . getTableFor195Info ( model . CP14 );
            txtCP06 . Properties . DataSource = tableOne;
            txtCP06 . Properties . DisplayMember = "CP06";
            txtCP06 . Properties . ValueMember = "CP06";

            DataTable tableTwo = _bll . getTableFor509GX ( );
            txtCP09 . Properties . DataSource = tableTwo;
            txtCP09 . Properties . DisplayMember = "GS35";
            txtCP09 . Properties . ValueMember = "GS35";
        }

        void setValue ( )
        {
            if ( model == null )
                return;
            txtCP06 . Text = model . CP06;
            txtCP07 . Text = model . CP07;
            txtCP09 . Text = model . CP09;
            txtCP11 . Text = model . CP10 . ToString ( );
            txtCP13 . Text = model . CP13 . ToString ( );
        }

        private void btnOk_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtCP06 . Text ) )
            {
                MessageBox . Show ( "零件名称不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( txtCP11 . Text ) )
            {
                MessageBox . Show ( "单价不可为空" );
                return;
            }
            decimal outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtCP11 . Text ) && decimal . TryParse ( txtCP11 . Text ,out outResult ) == false )
            {
                MessageBox . Show ( "单价应为数字" );
                return;
            }
            model . CP10 = outResult;
            if ( string . IsNullOrEmpty ( txtCP13 . Text ) )
            {
                MessageBox . Show ( "每套数量不可为空" );
                return;
            }
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtCP13 . Text ) && decimal . TryParse ( txtCP13 . Text ,out outResult ) == false )
            {
                MessageBox . Show ( "每套数量应为数字" );
                return;
            }
            model . CP13 = outResult;
            if ( string . IsNullOrEmpty ( txtCP09 . Text ) )
            {
                MessageBox . Show ( "工序不可为空" );
                return;
            }
            model . CP06 = txtCP06 . Text;
            model . CP07 = txtCP07 . Text;
            model . CP09 = txtCP09 . Text;

            this . DialogResult = DialogResult . OK;
        }

        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

        public MulaolaoLibrary . ChanPinZhiBiaoLibrary getModel
        {
            get
            {
                return model;
            }
        }

        private void txtCP06_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = view . GetFocusedDataRow ( );
            if ( row == null )
                return;
            txtCP07 . Text = row [ "CP07" ] . ToString ( );
            txtCP09 . Text = row [ "CP09" ] . ToString ( );
            txtCP13 . Text = row [ "CP13" ] . ToString ( );
            txtCP11 . Text = row [ "CP10" ] . ToString ( );
        }

    }
}