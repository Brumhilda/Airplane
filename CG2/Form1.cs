using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;
using static Tao.OpenGl.Glu;
using static Tao.OpenGl.Gl;
using static Tao.FreeGlut.Glut;
using Tao.DevIl;
using Tao.Platform.Windows;
using System.IO;
using System.Drawing.Imaging;


namespace CG2
{
    public partial class myForm : Form
    {
        Plane myPlane = new Plane();
        public static uint mGlTextureObject;
        public myForm()
        {
            InitializeComponent();
            simpleOpenGlControl1.InitializeContexts();
            this.KeyDown += new KeyEventHandler(Translate);
        }

        private void Translate(object sender, KeyEventArgs e)
        {
            Matrix.Make();
            switch (e.KeyCode)
            {
                case Keys.NumPad8:
                    Camera.Up();
                    break;
                case Keys.NumPad2:
                    Camera.Down();
                    break;
                case Keys.NumPad6:
                    Camera.Right();
                    break;
                case Keys.NumPad4:
                    Camera.Left();
                    break;
                case Keys.X:
                    Camera.RotateX();
                    break;
                case Keys.Y:
                    Camera.RotateY();
                    break;
                case Keys.Z:
                    Camera.RotateZ();
                    break;
                case Keys.Oemplus:
                    Camera.Closer();
                    break;
                case Keys.OemMinus:
                    Camera.Farther();
                    break;
                default:
                    Camera.Update();
                    break;
            }
            myPlane.Draw();
            simpleOpenGlControl1.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            glutInit();
            glutInitDisplayMode(GLUT_RGB | GLUT_DOUBLE | GLUT_DEPTH);
            glClearColor(0.2f, 0.3f, 0.7f, 1);
            glViewport(0, 0, simpleOpenGlControl1.Width, simpleOpenGlControl1.Height);
            Matrix.Make();
            InitialPosition();
            SetTexture();
            myPlane.Draw();
            simpleOpenGlControl1.Invalidate();

        }

        void SetTexture()
        {
            var bitmap = new Bitmap("1.jpg");
            glEnable(GL_TEXTURE_2D);
            glPixelStorei(GL_UNPACK_ALIGNMENT, 1);

            BitmapData data;
            Rectangle Rect = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            data = bitmap.LockBits(Rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
            glTexImage2D(GL_TEXTURE_2D, 0, 3,
                         data.Width,
                         data.Height,
                         0, GL_BGRA, GL_UNSIGNED_BYTE,
                         data.Scan0);
            bitmap.UnlockBits(data);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_NEAREST);
            glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_NEAREST);
        }

        void Display()
        {
            Bitmap background = new Bitmap("1.jpg");
            byte[] bitmap_mark = { 0x10, 0x10, 0x10, 0xFF, 0x10, 0x10, 0x10 };

            // Ñâîéñòâà ðàñïàêîâêè
            glPixelStorei(GL_UNPACK_ALIGNMENT, 1);
            // Ïîçèöèÿ âûâîäà ðàñòðà
            glRasterPos2d(0, 0);
            glPixelZoom(1, 1);
            //glBitmap(background.Width, background.Height,4,7,0,0,ImageToByteArray(background));
            // glPixelStorei(GL_UNPACK_ALIGNMENT, 1);
            byte[] b = ImageToByteArray(background);
            BitmapData data;
            Rectangle Rect = new Rectangle(0, 0, background.Width, background.Height);
            data = background.LockBits(Rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppRgb);
            glDrawPixels(data.Width, data.Height, GL_BGRA, GL_UNSIGNED_BYTE, data.Scan0);
            background.UnlockBits(data);

        }


        public byte[] ImageToByteArray(Bitmap imageIn)
        {
            var memoryStream = new MemoryStream();
            imageIn.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
            return memoryStream.ToArray();
        }

        void InitialPosition()
        {
            Camera.size = -0.2;
            Camera.angleY = 85;
            Camera.angleZ = 60;
            Camera.x = -0.6;
            Camera.Update();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("positions.txt", FileMode.Open);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("-Position-");
            sw.WriteLine("X:" + Camera.x);
            sw.WriteLine("Y:" + Camera.y);
            sw.WriteLine("Z:" + Camera.z);
            sw.WriteLine("angleX:" + Camera.angleX);
            sw.WriteLine("angleY:" + Camera.angleY);
            sw.WriteLine("angleZ:" + Camera.angleZ);
            sw.WriteLine("Size:" + Camera.size);
            sw.Close();
            fs.Close();
        }

        private void simpleOpenGlControl1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void simpleOpenGlControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trackBarZ_Scroll(object sender, EventArgs e)
        {
        }

        private void trackBarY_Scroll(object sender, EventArgs e)
        {
        }

        private void trackBarX_Scroll(object sender, EventArgs e)
        {
            // rotateX.ChangeAngle(0,trackBarX.Value);
            // Holst.angleX = rotateX.angle;
            // Holst.Make();
            //// Camera.Right();
            // myPlane.Draw();
            // simpleOpenGlControl1.Invalidate();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }


        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_4(object sender, EventArgs e)
        {
            Matrix.Make();
            Camera.x = -2.77E-17;
            Camera.y = -0.6;
            Camera.z = 0;
            Camera.angleX = 257;
            Camera.angleY = 720;
            Camera.angleZ = 448;
            Camera.size = -0.2;
            Camera.Update();
            myPlane.Draw();
            simpleOpenGlControl1.Invalidate();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Matrix.Make();
            Camera.x = -0.6;
            Camera.y = -0.2;
            Camera.z = 0;
            Camera.angleX = 257;
            Camera.angleY = 809;
            Camera.angleZ = 269;
            Camera.size = -0.2;
            Camera.Update();
            myPlane.Draw();
            simpleOpenGlControl1.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Matrix.Make();
            Camera.x = -0.1;
            Camera.y = 0.5;
            Camera.z = 0;
            Camera.angleX = 257;
            Camera.angleY = 1261;
            Camera.angleZ = 281;
            Camera.size = -0.2;
            Camera.Update();
            myPlane.Draw();
            simpleOpenGlControl1.Invalidate();
        }

        private void simpleOpenGlControl1_Load_1(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Matrix.Make();
            Camera.x = 0.2;
            Camera.y = 0.3;
            Camera.z = 0;
            Camera.angleX = 257;
            Camera.angleY = 943;
            Camera.angleZ = 448;
            Camera.size = -0.3;
            Camera.Update();
            myPlane.Draw();
            simpleOpenGlControl1.Invalidate();
        }
    }
}