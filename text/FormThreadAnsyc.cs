using System;
using System . Diagnostics;
using System . IO;
using System . Net;
using System . Text;
using System . Threading;
using System . Windows . Forms;

namespace text
{
    public partial class FormThreadAnsyc :Form
    {
        public FormThreadAnsyc ( )
        {
            InitializeComponent ( );
        }

        //同步
        private void button1_Click ( object sender ,EventArgs e )
        {
            Debug . WriteLine ( "【Debug】线程ID:" + Thread . CurrentThread . ManagedThreadId + "" );
            var request = WebRequest . Create ( "http://github.com" );//为了更好的演示,我们使用网速比较慢的外网
            request . GetResponse ( );//发送请求

            Debug . WriteLine ( "【Debug】线程ID:" + Thread . CurrentThread . ManagedThreadId + "" );
            label1 . Text = "执行完毕";
        }

        //异步APM
        private void button2_Click ( object sender ,EventArgs e )
        {
            //1.APM异步编程模型,Asynchronous Programming Model
            Debug . WriteLine ( "【Debug】主线程ID:" + Thread . CurrentThread . ManagedThreadId );

            var request = WebRequest . Create ( "https://github.com/" );
            request . BeginGetResponse ( new AsyncCallback ( t =>
              {
                  var response = request . EndGetResponse ( t );
                  var stream = response . GetResponseStream ( );

                  using ( StreamReader reader = new StreamReader ( stream ) )
                  {
                      StringBuilder sb = new StringBuilder ( );
                      while ( !reader . EndOfStream )
                      {
                          var content = reader . ReadLine ( );
                          sb . Append ( content );
                      }
                      Debug . WriteLine ( "【Debug】" + sb . ToString ( ) . Trim ( ) . Substring ( 0 ,100 ) + "..." );//只取返回内容的前100个字符
                      Debug . WriteLine ( "【Debug】异步线程ID：" + Thread . CurrentThread . ManagedThreadId );
                      label1 . Invoke ( ( Action ) ( ( ) =>
                              {
                                  label1 . Text = "执行完毕!";
                              } ) );//这里跨线程访问UI需要做处理
                  }
              } ),null);
        }

    }
}
