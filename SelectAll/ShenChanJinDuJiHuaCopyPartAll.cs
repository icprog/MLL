using Mulaolao;
using Mulaolao . Class;
using System;
using System . Collections . Generic;
using System . Data;
using System . Windows . Forms;

namespace SelectAll
{
    public partial class ShenChanJinDuJiHuaCopyPartAll : Form
    {
        public ShenChanJinDuJiHuaCopyPartAll ( )
        {
            InitializeComponent( );

            GridViewMoHuSelect . SetFilter ( View1 );
        }
         
        public List<string> listIdx = new List<string>( );
        public MulaolaoLibrary.ShenChanJinDuJiHuaLibrary model = new MulaolaoLibrary.ShenChanJinDuJiHuaLibrary( );
        MulaolaoBll.Bll.ShenChanJinDuJiHuaBll bll = new MulaolaoBll.Bll.ShenChanJinDuJiHuaBll( );
        DataTable dt;
        bool result = false;
        public string sign = "", oddNum = "";

        private void ShenChanJinDuJiHuaCopyPartAll_Load ( object sender ,EventArgs e )
        {
            textBox1.Text = model.PQX14;
            textBox2.Text = model.PQX17;
            textBox3.Text = model.PQX36.ToString( );

            textBox11 . Text = model . PQX19 . ToString ( );

            dt = bll.GetDataTablePart( model.PQX01 );
            Edit1.Properties.DataSource = dt.DefaultView.ToTable( true ,"PQX14" );
            Edit1 . Properties . DisplayMember = "PQX14";
            Edit1 . Properties . ValueMember = "PQX14";
            lookUpEdit1 .Properties.DataSource = bll.GetDataTableWorkPro( );
            lookUpEdit1.Properties.DisplayMember = "GX02";
        }

        private void comboBox1_SelectedValueChanged ( object sender ,EventArgs e )
        {
            if ( !string.IsNullOrEmpty( Edit1.Text ) && dt.Select( "PQX14='" + Edit1 . Text + "'" ).Length > 0 )
            {
                textBox5.Text = dt.Select( "PQX14='" + Edit1 . Text + "'" )[0]["PQX36"].ToString( );
            }
        }

        private void button1_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( Edit1 . Text ) )
                MessageBox . Show ( "零件名称不可为空" );
            else
            {
                if ( string . IsNullOrEmpty ( textBox4 . Text ) )
                    MessageBox . Show ( "零件代码不可为空" );
                else
                {
                    int id = 0;
                    foreach ( string idx in listIdx )
                    {
                        if ( !string . IsNullOrEmpty ( idx ) )
                            id = Convert . ToInt32 ( idx );
                        model = bll . GetModel ( id );
                        model . PQX14 = Edit1 . Text;
                        model . PQX17 = textBox4 . Text;
                        decimal part = 0M;
                        decimal . TryParse ( textBox5 . Text ,out part );
                        model . PQX36 = Convert . ToInt32 ( Math . Round ( part ,0 ) );

                        if ( sign . Equals ( "copy" ) )
                        {
                            model . Idx = bll . Add ( model );
                            if ( model . Idx < 0 )
                            {
                                MessageBox . Show ( "复制失败" );
                                break;
                            }
                            else if ( idx == listIdx [ listIdx . Count - 1 ] . ToString ( ) )
                                MessageBox . Show ( "复制成功" );
                        }
                    }
                    if ( sign . Equals ( "edit" ) )
                    {
                        model . Idx = id;
                        string nameOfSpare = string . Empty, partCode = string . Empty;
                        int partNum = 0;
                        nameOfSpare = textBox1 . Text;
                        partCode = textBox2 . Text;
                        partNum = string . IsNullOrEmpty ( textBox3 . Text ) == true ? 0 : Convert . ToInt32 ( textBox3 . Text );
                        result = false;
                        result = bll . UpdateBatch ( model ,nameOfSpare ,partCode ,partNum );
                        if ( result == false )
                        {
                            MessageBox . Show ( "编辑失败" );
                        }
                        else
                            MessageBox . Show ( "编辑成功" );
                    }
                }
            }
            this . Close ( );
        }
        private void button2_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }
        private void button4_Click ( object sender ,EventArgs e )
        {
            model.PQX33 = oddNum;
            model.PQX30 = dateTimePicker1.Value;
            int dtSpan = ( dateTimePicker1 . Value - Convert . ToDateTime ( textBox6 . Text ) ) . Days;
            result = bll . UpdateDate ( model . PQX33 ,model . PQX30 ,dtSpan );
            if ( result == true )
                MessageBox.Show( "成功编辑数据,请刷新" );
            else
                MessageBox.Show( "编辑数据失败" );

            this.Close( );
        }
        private void button3_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }


        private void textBox8_KeyPress ( object sender ,KeyPressEventArgs e )
        {
            DateDay.intgra( e );
        }
        private void button6_Click ( object sender ,EventArgs e )
        {
            model.PQX33 = oddNum;
            model.PQX18 = string.IsNullOrEmpty( textBox8.Text ) == true ? 0 : Convert.ToInt32( textBox8.Text );
            result = bll.UpdateNum( model.PQX33 ,model.PQX18 );
            if ( result == true )
                MessageBox.Show( "成功编辑数据,请刷新" );
            else
                MessageBox.Show( "编辑数据失败" );
            this.Close( );
        }
        private void button5_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }

        private void button8_Click ( object sender ,EventArgs e )
        {
            result = bll.UpdateBatchWorkPro( textBox9.Text ,lookUpEdit1.Text );
            if ( result == true )
                MessageBox.Show( "成功编辑数据,请刷新" );
            else
                MessageBox.Show( "数据编辑失败" );
            this.Close( );
        }

        private void button10_Click ( object sender ,EventArgs e )
        {
            if ( string . IsNullOrEmpty ( textBox10 . Text ) )
            {
                MessageBox . Show ( "请输入部件工序道数" );
                return;
            }
            int x = 0;
            if ( int . TryParse ( textBox10 . Text ,out x ) == false )
            {
                MessageBox . Show ( "部件工序道数必须为整数" );
                return;
            }

            model . PQX19 = Convert . ToInt32 ( textBox10 . Text );
            result = bll . UpdateB ( model . PQX01 ,model . PQX14 ,model . PQX19 );
            if ( result == true )
                MessageBox . Show ( "成功编辑数据,请刷新" );
            else
                MessageBox . Show ( "编辑数据失败" );
            this . Close ( );

        }
        private void button9_Click ( object sender ,EventArgs e )
        {
            this . Close ( );
        }

        private void button7_Click ( object sender ,EventArgs e )
        {
            this.Close( );
        }
    }
}
