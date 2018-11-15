using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Mulaolao.Class
{
    public static class PictureBoxOpen
    {
        //public static List<Form> Count(Form fr)
        //{
        //    List<Form> add = new List<Form>();
        //    add.Add(fr);
        //    return add;
        //}

        public static void picTure( OpenFileDialog od, PictureBox pi, string filePath )
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*jpg|*.JPG|*.GIF|*.GIF|*.BMP|*.BMP";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;//图片路径
                pi.ImageLocation = filePath;//找到的图片显示在picture上面

                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                //byte[] imageBytes = new byte[fs.Length];
                BinaryReader br = new BinaryReader(fs);
            }
        }
    }
}
