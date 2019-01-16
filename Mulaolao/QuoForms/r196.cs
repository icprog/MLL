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
    public partial class r196 :DevExpress . XtraEditors . XtraForm
    {
        MulaolaoBll.Bll.QuoBll _bll=null;
        MulaolaoLibrary.SiReYiYinContractLibrary model = null;

        public r196 ( MulaolaoLibrary . SiReYiYinContractLibrary model )
        {
            InitializeComponent ( );

            _bll = new MulaolaoBll . Bll . QuoBll ( );

            GridViewMoHuSelect . SetFilter ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { View ,View1 } );
            GrivColumnStyle . setColumnStyle ( new DevExpress . XtraGrid . Views . Grid . GridView [ ] { View ,View1 } );

            this . model = model;

            getInfo ( );
            setValue ( );
        }

        void getInfo ( )
        {
            DataTable tableOne = _bll . getTableFor196Info ( model . AH04 );
            txtAH10 . Properties . DataSource = tableOne;
            txtAH10 . Properties . DisplayMember = "AH10";
            txtAH10 . Properties . ValueMember = "AH10";

            DataTable tableTwo = _bll . getTableFor509GX ( );
            txtAH18 . Properties . DataSource = tableTwo;
            txtAH18 . Properties . DisplayMember = "GS35";
            txtAH18 . Properties . ValueMember = "GS35";
        }

        void setValue ( )
        {
            if ( model == null )
                return;
            txtAH10 . Text = model . AH10;
            txtAH11 . Text = model . AH11;
            txtAH18 . Text = model . AH18;
            txtAH13 . Text = model . AH13 . ToString ( );
            txtAH16 . Text = model . AH16 . ToString ( );
        }

        private void btnCancel_Click ( object sender ,EventArgs e )
        {
            this . DialogResult = DialogResult . Cancel;
        }

        private void btnSure_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( txtAH10 . Text ) )
            {
                MessageBox . Show ( "零件名称不可为空" );
                return;
            }
            if ( string . IsNullOrEmpty ( txtAH16 . Text ) )
            {
                MessageBox . Show ( "单价不可为空" );
                return;
            }
            decimal outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtAH16 . Text ) && decimal . TryParse ( txtAH16 . Text ,out outResult ) == false )
            {
                MessageBox . Show ( "单价应为数字" );
                return;
            }
            model . AH16 = outResult;
            if ( string . IsNullOrEmpty ( txtAH13 . Text ) )
            {
                MessageBox . Show ( "每套数量不可为空" );
                return;
            }
            outResult = 0M;
            if ( !string . IsNullOrEmpty ( txtAH13 . Text ) && decimal . TryParse ( txtAH13 . Text ,out outResult ) == false )
            {
                MessageBox . Show ( "每套数量应为数字" );
                return;
            }
            model . AH13 = outResult;
            if ( string . IsNullOrEmpty ( txtAH18 . Text ) )
            {
                MessageBox . Show ( "工序不可为空" );
                return;
            }
            model . AH10 = txtAH10 . Text;
            model . AH11 = txtAH11 . Text;
            model . AH18 = txtAH18 . Text;

            this . DialogResult = DialogResult . OK;
        }

        public MulaolaoLibrary . SiReYiYinContractLibrary getModel
        {
            get
            {
                return model;
            }
        }

        private void txtAH10_EditValueChanged ( object sender ,EventArgs e )
        {
            DataRow row = View . GetFocusedDataRow ( );
            if ( row == null )
                return;
            txtAH11 . Text = row [ "AH11" ] . ToString ( );
            txtAH18 . Text = row [ "AH18" ] . ToString ( );
            txtAH13 . Text = row [ "AH13" ] . ToString ( );
            txtAH16 . Text = row [ "AH16" ] . ToString ( );
        }

    }
}