using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Mulaolao.Class;
using System.Data.SqlClient;
using StudentMgr;
using Mulaolao.Contract.DefineFileds;

namespace Mulaolao.Schedule_control
{
    public partial class yanpinSelect : Form
    {
        public yanpinSelect( )
        {
            InitializeComponent();

        }

        private void yanpinSelect_Load( object sender, EventArgs e )
        {

        }

        MulaolaoLibrary.CheMuJianContractLibrary cmj = new MulaolaoLibrary.CheMuJianContractLibrary( );
        MulaolaoLibrary.SiReYiYinContractLibrary model = new MulaolaoLibrary.SiReYiYinContractLibrary( );
        public string ysOne = "", ysTwo = "", ysThr = "", ysFou = "", ysFiv = "", ysSix = "";

        //取消
        private void button2_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }
        //确认
        DateTime? JM105, PQV83, PQU105, PJ98, WX88, YQ110;
        private void button1_Click ( object sender ,EventArgs e )
        {
            int count = 0;
            if ( ysSix == "R_338" )
            {
                JM105 = dateTimePicker1.Value;
                count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQO SET JM105=@JM105 WHERE JM01=@JM01 AND JM09=@JM09 AND JM94=@JM94 AND JM95=@JM95 AND JM96=@JM96" ,new SqlParameter( "@JM105" ,JM105 ) ,new SqlParameter( "@JM01" ,ysOne ) ,new SqlParameter( "@JM09" ,ysTwo ) ,new SqlParameter( "@JM94" ,ysThr ) ,new SqlParameter( "@JM95" ,ysFou ) ,new SqlParameter( "@JM96" ,ysFiv ) );
                if ( count < 1 )
                    MessageBox.Show( "到货时间录入失败,请重新录入" );
                else
                    MessageBox.Show( "到货时间录入成功" );
            }
            else if ( ysSix == "R_341" )
            {
                PQV83 = dateTimePicker1.Value;
                count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQV SET PQV83=@PQV83 WHERE PQV76=@PQV76 AND PQV10=@PQV10 AND PQV66=@PQV66 AND PQV81=@PQV81 AND PQV67=@PQV67" ,new SqlParameter( "@PQV83" ,PQV83 ) ,new SqlParameter( "@PQV76" ,ysOne ) ,new SqlParameter( "@PQV10" ,ysTwo ) ,new SqlParameter( "@PQV66" ,ysThr ) ,new SqlParameter( "@PQV81" ,ysFou ) ,new SqlParameter( "@PQV67" ,ysFiv ) );
                if ( count < 1 )
                    MessageBox.Show( "到货时间录入失败,请重新录入" );
                else
                    MessageBox.Show( "到货时间录入成功" );
            }
            else if ( ysSix == "R_340" )
            {
                PQU105 = dateTimePicker1.Value;
                count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQU SET PQU105=@PQU105 WHERE PQU97=@PQU97 AND PQU10=@PQU10 AND PQU12=@PQU12" ,new SqlParameter( "@PQU105" ,PQU105 ) ,new SqlParameter( "@PQU97" ,ysOne ) ,new SqlParameter( "@PQU10" ,ysTwo ) ,new SqlParameter( "@PQU12" ,ysThr ) );
                if ( count < 1 )
                    MessageBox.Show( "到货时间录入失败,请重新录入" );
                else
                    MessageBox.Show( "到货时间录入成功" );
            }
            else if ( ysSix == "R_347" )
            {
                PJ98 = dateTimePicker1.Value;
                count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQS SET PJ98=@PJ98 WHERE PJ92=@PJ92 AND PJ09=@PJ09 AND PJ89=@PJ89" ,new SqlParameter( "@PJ98" ,PJ98 ) ,new SqlParameter( "@PJ92" ,ysOne ) ,new SqlParameter( "@PJ98" ,ysTwo ) ,new SqlParameter( "@PJ98" ,ysThr ) );
                if ( count < 1 )
                    MessageBox.Show( "到货时间录入失败,请重新录入" );
                else
                    MessageBox.Show( "到货时间录入成功" );
            }
            else if ( ysSix == "R_349" )
            {
                WX88 = dateTimePicker1.Value;
                count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQT SET WX88=@WX88 WHERE WX82=@WX82 AND WX10=@WX10 AND WX11=@WX11" ,new SqlParameter( "@WX88" ,WX88 ) ,new SqlParameter( "@WX82" ,ysOne ) ,new SqlParameter( "@WX10" ,ysTwo ) ,new SqlParameter( "@WX11" ,ysThr ) );
                if ( count < 1 )
                    MessageBox.Show( "到货时间录入失败,请重新录入" );
                else
                    MessageBox.Show( "到货时间录入成功" );
            }
            else if ( ysSix == "R_412" )
            {
                cmj.AF076 = dateTimePicker1.Value;
                count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQAF SET AF076=@AF076 WHERE AF001=@AF001 AND AF015=@AF015 AND AF020=@AF020 AND AF021=@AF021 AND AF022=@AF022" ,new SqlParameter( "@AF076" ,cmj.AF076 ) ,new SqlParameter( "@AF001" ,ysOne ) ,new SqlParameter( "@AF015" ,ysTwo ) ,new SqlParameter( "@AF020" ,ysThr ) ,new SqlParameter( "@AF021" ,ysFou ) ,new SqlParameter( "@AF022" ,ysFiv ) );
                if ( count < 1 )
                    MessageBox.Show( "到货时间录入失败,请重新录入" );
                else
                    MessageBox.Show( "到货时间录入成功" );
            }
            else if ( ysSix == "R_339" )
            {
                YQ110 = dateTimePicker1.Value;
                count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQI SET YQ110 WHERE YQ99=@YQ99 AND YQ10=@YQ10 AND YQ11=@YQ11 AND YQ12=@YQ12" ,new SqlParameter( "@YQ110" ,YQ110 ) ,new SqlParameter( "@YQ99" ,ysOne ) ,new SqlParameter( "@YQ10" ,ysTwo ) ,new SqlParameter( "@YQ11" ,ysThr ) ,new SqlParameter( "@YQ12" ,ysFou ) );
                if ( count < 1 )
                    MessageBox.Show( "到货时间录入失败,请重新录入" );
                else
                    MessageBox.Show( "到货时间录入成功" );
            }
            else if ( ysSix == "R_196" )
            {
                model.AH105 = dateTimePicker1.Value;
                count = SqlHelper.ExecuteNonQuery( "UPDATE R_PQAH SET AH105=@AH105 WHERE AH97=@AH97 AND AH10=@AH10 AND AH11=@AH11" ,new SqlParameter( "@AH105" ,model.AH105 ) ,new SqlParameter( "@AH97" ,ysOne ) ,new SqlParameter( "@AH10" ,ysTwo ) ,new SqlParameter( "@AH11" ,ysThr ) );
                if ( count < 1 )
                    MessageBox.Show( "到货时间录入失败,请重新录入" );
                else
                    MessageBox.Show( "到货时间录入成功" );
            }
            
            this.Close( );
        }
    }
}
