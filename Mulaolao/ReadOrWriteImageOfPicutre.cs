using System;
using System . Drawing;
using System . IO;
using System . Windows . Forms;

namespace Mulaolao
{
    public class ReadOrWriteImageOfPicutre
    {
        /// <summary>
        /// Get Image
        /// </summary>
        /// <param name="myByte"></param>
        /// <returns>Image</returns>
        public static Image ReadPicture ( byte [ ] myByte )
        {
            if ( myByte == null )
                return null;
            if ( myByte . Length == 0 )
                return null;
            else
            {
                MemoryStream ms = new MemoryStream ( myByte );
                ms . Write ( myByte ,0 ,myByte . Length );
                ms . Position = 0;
                ms . Seek ( 0 ,SeekOrigin . Begin );
                Image img = Image . FromStream ( ms ,true );
                return img;
            }
        }
        
        /// <summary>
        /// Read Picture To Column
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        public static byte [ ] ReadPicture ( PictureBox picture )
        {
            byte [ ] mybyte = new byte [ 0 ];
            string filePath = string . Empty;
            OpenFileDialog old = new OpenFileDialog ( );
            old . Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.emf";
            if ( old . ShowDialog ( ) == DialogResult . OK )
            {
                filePath = old . FileName;//获取图片路径
                picture . ImageLocation = filePath;

                FileStream fs = new FileStream ( filePath ,FileMode . Open ,FileAccess . Read );
                BinaryReader br = new BinaryReader ( fs );
                mybyte = br . ReadBytes ( ( int ) fs . Length );//图片转换成二进制流 
            }
            else
                mybyte = new byte [ 0 ];

            return mybyte;
        }

        public static byte [ ] ReadPicture ( DevExpress.XtraEditors.PictureEdit picture )
        {
            byte [ ] mybyte = new byte [ 0 ];
            string filePath = string . Empty;
            OpenFileDialog old = new OpenFileDialog ( );
            old . Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.emf";
            if ( old . ShowDialog ( ) == DialogResult . OK )
            {
                filePath = old . FileName;//获取图片路径
                //Bitmap bitmap = new Bitmap ( filePath );
                //Point pt = new Point ( bitmap . Size );
                //if ( pt . X > picture . Size . Width || pt . Y > picture . Size . Height )
                //{
                //    //图像充满图像框 并且图像维持比例
                //    picture . BackgroundImageLayout = ImageLayout . Stretch;
                //}
                //else
                //{
                //    //图像在图像框中
                //    picture . BackgroundImageLayout = ImageLayout . Stretch;
                //}
                // LoadAsync：非同步转入图像   
                picture . LoadAsync ( filePath );

                FileStream fs = new FileStream ( filePath ,FileMode . Open ,FileAccess . Read );
                BinaryReader br = new BinaryReader ( fs );
                mybyte = br . ReadBytes ( ( int ) fs . Length );//图片转换成二进制流 
            }
            else
                mybyte = new byte [ 0 ];

            return mybyte;
        }

        public static byte [ ] ReadColumn ( )
        {
            byte [ ] mybyte = new byte [ 0 ];
            string filePath = string . Empty;
            OpenFileDialog old = new OpenFileDialog ( );
            old . Filter = "图片文件|*.bmp;*.jpg;*.jpeg;*.gif;*.png;*.emf";
            if ( old . ShowDialog ( ) == DialogResult . OK )
            {
                filePath = old . FileName;//获取图片路径

                FileStream fs = new FileStream ( filePath ,FileMode . Open ,FileAccess . Read );
                BinaryReader br = new BinaryReader ( fs );
                mybyte = br . ReadBytes ( ( int ) fs . Length );//图片转换成二进制流 
            }
            else
                mybyte = new byte [ 0 ];

            return mybyte;
        }

        /// <summary>
        /// Clear To Picture Image
        /// </summary>
        /// <param name="picture"></param>
        public static void ClearPicture ( PictureBox picture )
        {
            picture . Image = null;
            picture . ImageLocation = string . Empty;
        }

    }
}
