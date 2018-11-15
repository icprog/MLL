using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace text
{
    public partial class ProcessThread : Form
    {
        public ProcessThread ( )
        {
            InitializeComponent( );
        }

        delegate void AsynUpdateUI ( int temp );//建立一个委托来实现非创建控件的线程更新控件

        private void ProcessThread_Load ( object sender ,EventArgs e )
        {

        }

        private void button1_Click ( object sender ,EventArgs e )
        {
            int taskCount = 10000;
            this.progressBar1.Maximum = taskCount;
            this.progressBar1.Value = 0;
            DataWrite dataWrite = new DataWrite ( );//实例化一个写入数据的类
            dataWrite . UpdateUIDelegate += UpdateUIStatus;//绑定更新任务状态的委托
            dataWrite . TaskCallBack += Accomplish;//绑定完成任务要调用的委托

            Thread thread = new Thread( new ParameterizedThreadStart( dataWrite.Write ) );
            thread.IsBackground = true;
            thread.Start( taskCount );
        }
        private void UpdateUIStatus ( int temp )
        {
            if ( InvokeRequired )
            {
                this.Invoke( new AsynUpdateUI( delegate ( int s )
                  {
                      this.progressBar1.Value += s;
                      this.label2.Text = this.progressBar1.Value.ToString( ) + "/" + this.progressBar1.Maximum.ToString( );
                  } ) ,temp );
            }
            else
            {
                this.progressBar1.Value += temp;
                this.label2.Text = this.progressBar1.Value.ToString( ) + "/" + this.progressBar1.Maximum.ToString( );
            }
        }
        //完成任务时需要调用
        private void Accomplish ( )
        {
            //还可以进行其他的一些完任务完成之后的逻辑处理
            MessageBox.Show( "任务完成" );
        }
    }

    public class DataWrite
    {
        public delegate void UpdateUI ( int step );//声明一个更新主线程的委托
        public UpdateUI UpdateUIDelegate;

        public delegate void AccomplishTask ( );//声明一个在完成任务时通知主线程的委托
        public AccomplishTask TaskCallBack;

        public void Write ( object lineCount )
        {
            StreamWriter writeIO = new StreamWriter( "text.txt" ,false ,Encoding.GetEncoding( "gb2312" ) );
            string head = "编号,省,市";
            writeIO.Write( head );
            for ( int i = 0 ; i < ( int ) lineCount ; i++ )
            {
                writeIO.WriteLine( i.ToString( ) + ",湖南,衡阳" );
                //写入一条数据，调用更新主线程ui状态的委托
                UpdateUIDelegate( 1 );
            }
            //任务完成时通知主线程作出相应的处理
            TaskCallBack( );
            writeIO.Close( );
        }
    }
}
