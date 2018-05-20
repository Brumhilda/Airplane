using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Tao.OpenGl.Gl;
using static Tao.FreeGlut.Glut;
using System.Drawing;
using System.IO;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
using Tao.DevIl;

namespace CG2
{
    public static class Background
    {
        public static Bitmap background;// = new Bitmap(//@"C:\Users\Lisa\Documents\Visual Studio 2015\Projects\CG2\CG2\Images\Background.bmp");
        static IntPtr handle = background.GetHbitmap();
        public static void Display()
        {
            glPixelStorei(GL_UNPACK_ALIGNMENT, 1);
            glDrawPixels(background.Width, background.Height, GL_RGB, GL_UNSIGNED_BYTE, background.GetHbitmap());

        }

        public static byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }

    }
}
