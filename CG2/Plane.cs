using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tao.OpenGl;
using static Tao.OpenGl.Glu;
using static Tao.OpenGl.Gl;
using static Tao.FreeGlut.Glut;
using Tao.DevIl;
using Tao.Platform.Windows;

namespace CG2
{
    public class Plane
    {
        public double
             mainRadius = 0.25,
             mainHeight = 3.5;



        public void Draw()
        {
            GLUquadric quadObj;
            quadObj = gluNewQuadric();
            gluQuadricTexture(quadObj, GL_TRUE);
            gluQuadricDrawStyle(quadObj, GLU_FILL);
            //gluSphere(quadObj,0.7,32,32);


            //glColor3d(1, 1, 1);
            glScaled(0.5 + Camera.size, 0.5 + Camera.size, 0.5 + Camera.size);
            gluCylinder(quadObj, mainRadius, mainRadius, mainHeight, 32, 32);        //корпус
            glScaled(1, 1, -0.25);
            gluCylinder(quadObj, mainRadius, 0, mainHeight, 32, 32);                //нос
            glPushMatrix();
            glTranslated(0, 0, -mainHeight - 14);
            gluCylinder(quadObj, 0, mainRadius, mainHeight, 32, 32);
            glPopMatrix();
            gluDeleteQuadric(quadObj);
            //glColor3f(63, 0, 105);
            //glutSolidSphere(0.7,32,32);
            glColor3d(1, 1, 1);
            //glColor3f(0, 0, 105);
            //glScaled(1, 1, -0.25);

            //glScaled(1, 1, -2);
            glPolygonMode(GL_FRONT_AND_BACK, GL_FILL);
            //правое крыло 
            glBegin(GL_TRIANGLES);
            Triangle rightWing = new Triangle()
            {
                v1 = new Point { y = mainRadius, z = mainHeight - 9 },
                v2 = new Point { y = 2.25, z = mainHeight - 15.5 },
                v3 = new Point { y = mainRadius, z = mainHeight - 13.5 }
            };
            rightWing.Draw();
            glEnd();
            //левое крыло
            glBegin(GL_TRIANGLES);
            Triangle leftWing = new Triangle()
            {
                v1 = new Point { y = -mainRadius, z = mainHeight - 9 },
                v2 = new Point { y = -2.25, z = mainHeight - 15.5 },
                v3 = new Point { y = -mainRadius, z = mainHeight - 13.5 }
            };
            leftWing.Draw();
            glEnd();
            //glColor3d(0, 0, 1);
            //стабилизатор справа
            glBegin(GL_TRIANGLES);
            Triangle rightStab = new Triangle()
            {
                v1 = new Point { z = mainHeight - 18 },
                v2 = new Point { y = 1.00, z = mainHeight - 21.5 },
                v3 = new Point { z = mainHeight - 20.5 }
            };
            rightStab.Draw();
            glEnd();
            //стабилизатор слева
            glBegin(GL_TRIANGLES);
            Triangle leftStab = new Triangle()
            {
                v1 = new Point { z = mainHeight - 18 },
                v2 = new Point { y = -1.00, z = mainHeight - 21.5 },
                v3 = new Point { z = mainHeight - 20.5 }
            };
            leftStab.Draw();
            glEnd();
            //вертикальный стабилизатор
            glBegin(GL_TRIANGLES);
            Triangle vertStab = new Triangle()
            {
                v1 = new Point { z = -mainHeight - 10 },
                v2 = new Point { x = 1, z = mainHeight - 20.5 },
                v3 = new Point { z = mainHeight - 20.5 }
            };
            vertStab.Draw();
            glEnd();

            //glPushMatrix();
            //glTranslated(0, 0, -mainHeight-10.5);
            //glutSolidCone(mainRadius, -mainHeight, 32, 32);
            //glPopMatrix();
        }
    }
}