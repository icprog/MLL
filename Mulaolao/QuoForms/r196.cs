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
            getInfo ( );
            this . model = model;
            setValue ( );
        }

        void getInfo ( )
        {
            DataTable tableOne = _bll . getTableFor196Info ( );
            txtAH10 . Properties . DataSource = tableOne;
            txtAH10 . Properties . DisplayMember = "CP06";
            txtAH10 . Properties . ValueMember = "CP06";

            //DataTable tableTwo = _bll . getTableFor509GX ( );
            //txtCP09 . Properties . DataSource = tableTwo;
            //txtCP09 . Properties . DisplayMember = "GS35";
            //txtCP09 . Properties . ValueMember = "GS35";
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


    }
}