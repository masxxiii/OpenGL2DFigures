using System;
using System.Windows.Forms;
using OpenTK.Graphics.OpenGL;


namespace WindowsFormsApp1
{
    public partial class Laboratory_Work_5 : System.Windows.Forms.Form
    {
        //Matrix for figure_A
        double[,] figure_A = new double[,]
        {
            { 0, 0 },
            { 0, 0 },
            { 0, 0 },
            { 0, 0 },
            { 0, 0 },
            { 0, 0 },
            { 0, 0 },
            { 0, 0 },
            { 0, 0 },
            { 0, 0 },
            { 0, 0 },
            { 0, 0 },
            { 0, 0 }
        };

        //Matrix for figure_B
        double[,] figure_B = new double[,]
        {
            { 0, 0.2f },
            { 0.3f, 0.1f },
            { 0.15f, 0 },
            { 0.3f, -0.1},
            { 0, -0.2f },
            { 0f, 0.15f },
            { 0.15f, 0.15f },
            { 0.15f, -0.15f },
            { 0, -0.15f}
        };
        public Laboratory_Work_5()
        {
            InitializeComponent();
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            GL.Viewport(0, 0, controlWindow.Width, controlWindow.Height);
            GL.ClearColor(1f, 1f, 1f, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            draw_FigureA(A_xChange, A_yChange);
            draw_FigureB(B_xChange, B_yChange);
            controlWindow.SwapBuffers();
        }

        private void figureA_cords()
        {
            //Getting cords for octagon
            for (int i = 0; i < 8; i++)
            {
                double x = 0.2f * Math.Sin(2 * Math.PI * i / 8);
                double y = 0.2f * Math.Cos(2 * Math.PI * i / 8);
                for (int j = 0; j < 2; j++)
                {
                    if (j % 2 == 0)
                        figure_A[i, j] = x;
                    else
                        figure_A[i, j] = y;

                }
            }

            //Getting coordinates for square
            figure_A[8, 0] = figure_A[0, 0];
            figure_A[9, 0] = figure_A[2, 0];
            figure_A[10, 0] = figure_A[4, 0];
            figure_A[11, 0] = figure_A[6, 0];
            figure_A[8, 1] = figure_A[0, 1];
            figure_A[9, 1] = figure_A[2, 1];
            figure_A[10, 1] = figure_A[4, 1];
            figure_A[11, 1] = figure_A[6, 1];
        }

        private void draw_FigureA(double dx, double dy)
        {
            GL.LineWidth(3);
            GL.Color3(0.5f, 0f, 0.5f);
            GL.PushMatrix();
            GL.Translate(dx, dy, 0);
            GL.Rotate(rotating_direction_A, 0, 0, 1);
            GL.Scale(scale_A, scale_A, 1);

            //Drawing octagon
            GL.Begin(PrimitiveType.LineLoop);
            figureA_cords();
            for (int i = 0; i < 8; i++)
            {
                GL.Vertex2(figure_A[i, 0], figure_A[i, 1]);
            }
            GL.End();

            //Drawing square
            GL.Begin(PrimitiveType.Polygon);
            GL.Color3(1f, 0f, 0f);
            for (int i = 8; i < 12; i++)
            {
                GL.Vertex2(figure_A[i, 0], figure_A[i, 1]);
            }
            GL.End();

            //Drawing lines
            GL.LineWidth(1);
            GL.Color3(0f, 0f, 0f);
            GL.Begin(PrimitiveType.Lines);
            GL.Vertex2(figure_A[0, 0], figure_A[0, 1]);
            GL.Vertex2(figure_A[4, 0], figure_A[4, 1]);
            GL.Vertex2(figure_A[2, 0], figure_A[2, 1]);
            GL.Vertex2(figure_A[6, 0], figure_A[6, 1]);
            GL.End();

            //Drawing dots
            GL.PointSize(3f);
            GL.Begin(PrimitiveType.Points);
            GL.Color3(0f, 0f, 0f);
            for (int i = 0; i < 8; i++)
            {
                GL.Vertex2(figure_A[i, 0], figure_A[i, 1]);
            }
            GL.Vertex2(figure_A[12, 0], figure_A[12, 1]);
            GL.End();
            GL.PopMatrix();
        }

        private void draw_FigureB(double dx, double dy)
        {
            GL.LineWidth(1);
            GL.Color3(0f, 0f, 0f);
            GL.PushMatrix();
            GL.Translate(dx, dy, 0);
            GL.Rotate(rotating_direction_B, 0, 0, 1);
            GL.Scale(scale_B, scale_B, 1);

            //Drawing M-figure
            GL.Begin(PrimitiveType.LineLoop);
            for (int i = 0; i < 5; i++)
            {
                GL.Vertex2(figure_B[i, 0], figure_B[i, 1]);
            }
            GL.End();

            //Drawing rectangle
            GL.Begin(PrimitiveType.LineLoop);
            for (int i = 5; i < 9; i++)
            {
                GL.Vertex2(figure_B[i, 0], figure_B[i, 1]);
            }
            GL.End();

            //Drawing dots
            GL.PointSize(3f);
            GL.Begin(PrimitiveType.Points);
            GL.Color3(0f, 0f, 0f);
            GL.Vertex2(figure_B[0, 0], figure_B[0, 1]);
            GL.Vertex2(figure_B[4, 0], figure_B[4, 1]);
            GL.Vertex2(figure_B[6, 0], figure_B[6, 1]);
            GL.Vertex2(figure_B[7, 0], figure_B[7, 1]);
            GL.End();
            GL.PopMatrix();
        }

        double A_xChange = 0;
        double A_yChange = 0;
        double B_xChange = 0;
        double B_yChange = 0;
        double scale_A = 1;
        double scale_B = 1;

        bool rotatingA = false;
        bool rotatingB = false;

        //figure control
        private void controlWindow_KeyDown(object sender, KeyEventArgs e)
        {
            GL.Viewport(0, 0, controlWindow.Width, controlWindow.Height);
            GL.ClearColor(1f, 1f, 1f, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            //Control figure_A rotation
            if (e.KeyCode == Keys.Q)
            {
                timer1.Enabled = !timer1.Enabled;
                rotatingA = true;
            }
            if (e.KeyCode == Keys.E)
            {
                timer1.Enabled = !timer1.Enabled;
                rotatingA = false;
            }

            //Control figure_B rotation
            if (e.KeyCode == Keys.T)
            {
                timer2.Enabled = !timer2.Enabled;
                rotatingB = true;
            }
            if (e.KeyCode == Keys.U)
            {
                timer2.Enabled = !timer2.Enabled;
                rotatingB = false;
            }

            //Control figure_A rotation around figure_B
            if (e.KeyCode == Keys.O)
            {
                timer3.Enabled = !timer3.Enabled;
                rotatingA = true;
            }
            if (e.KeyCode == Keys.P)
            {
                timer3.Enabled = !timer3.Enabled;
                rotatingA = false;
            }

            //Control figure_A direction
            if (e.KeyCode == Keys.W)
            {
                A_yChange += 0.1;
                draw_FigureB(B_xChange, B_yChange);
                draw_FigureA(A_xChange, A_yChange);
                controlWindow.SwapBuffers();
            }
            if (e.KeyCode == Keys.S)
            {
                A_yChange -= 0.1;
                draw_FigureB(B_xChange, B_yChange);
                draw_FigureA(A_xChange, A_yChange);
                controlWindow.SwapBuffers();
            }
            if (e.KeyCode == Keys.D)
            {
                A_xChange += 0.1;
                draw_FigureB(B_xChange, B_yChange);
                draw_FigureA(A_xChange, A_yChange);
                controlWindow.SwapBuffers();
            }
            if (e.KeyCode == Keys.A)
            {
                A_xChange -= 0.1;
                draw_FigureB(B_xChange, B_yChange);
                draw_FigureA(A_xChange, A_yChange);
                controlWindow.SwapBuffers();
            }

            //Control figure_B direction
            if (e.KeyCode == Keys.J)
            {
                B_xChange += 0.1;
                draw_FigureA(A_xChange, A_yChange);
                draw_FigureB(B_xChange, B_yChange);
                controlWindow.SwapBuffers();
            }
            if (e.KeyCode == Keys.G)
            {
                B_xChange -= 0.1;
                draw_FigureA(A_xChange, A_yChange);
                draw_FigureB(B_xChange, B_yChange);
                controlWindow.SwapBuffers();
            }
            if (e.KeyCode == Keys.Y)
            {
                B_yChange += 0.1;
                draw_FigureA(A_xChange, A_yChange);
                draw_FigureB(B_xChange, B_yChange);
                controlWindow.SwapBuffers();
            }
            if (e.KeyCode == Keys.H)
            {
                B_yChange -= 0.1;
                draw_FigureA(A_xChange, A_yChange);
                draw_FigureB(B_xChange, B_yChange);
                controlWindow.SwapBuffers();
            }

            //Control figure_A scale
            if (e.KeyCode == Keys.Z)
            {
                scale_A += 0.1;
                draw_FigureA(A_xChange, A_yChange);
                draw_FigureB(B_xChange, B_yChange);
                controlWindow.SwapBuffers();
            }
            if (e.KeyCode == Keys.X)
            {
                scale_A -= 0.1;
                draw_FigureA(A_xChange, A_yChange);
                draw_FigureB(B_xChange, B_yChange);
                controlWindow.SwapBuffers();
            }

            //Control figure_B scale
            if (e.KeyCode == Keys.V)
            {
                scale_B += 0.1;
                draw_FigureA(A_xChange, A_yChange);
                draw_FigureB(B_xChange, B_yChange);
                controlWindow.SwapBuffers();
            }
            if (e.KeyCode == Keys.B)
            {
                scale_B -= 0.1;
                draw_FigureA(A_xChange, A_yChange);
                draw_FigureB(B_xChange, B_yChange);
                controlWindow.SwapBuffers();
            }
            GL.PopMatrix();
        }

        double rotating_direction_A = 0;
        double rotating_direction_B = 0;

        //Timer for figure_A rotating
        private void timer1_Tick(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, controlWindow.Width, controlWindow.Height);
            GL.ClearColor(1f, 1f, 1f, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            if (rotatingA)
                rotating_direction_A += 0.5;
            else
                rotating_direction_A -= 0.5;
            GL.PushMatrix();
            draw_FigureA(A_xChange, A_yChange);
            GL.PopMatrix();
            draw_FigureB(B_xChange, B_yChange);
            controlWindow.SwapBuffers();
        }

        //Timer for figure_B rotating
        private void timer2_Tick(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, controlWindow.Width, controlWindow.Height);
            GL.ClearColor(1f, 1f, 1f, 1);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            if (rotatingB)
                rotating_direction_B += 0.5;
            else
                rotating_direction_B -= 0.5;
            GL.PushMatrix();
            draw_FigureB(B_xChange, B_yChange);
            GL.PopMatrix();
            draw_FigureA(A_xChange, A_yChange);
            controlWindow.SwapBuffers();
        }

        //Timer for figure_A rotating around figure_B
        private void timer3_Tick(object sender, EventArgs e)
        {
            GL.Viewport(0, 0, controlWindow.Width, controlWindow.Height);
            GL.ClearColor(1f, 1f, 1f, 1);
            if (rotatingA)
                rotating_direction_A += 0.5;
            else
                rotating_direction_A -= 0.5;
            GL.PushMatrix();
            GL.Rotate(rotating_direction_A, 0, 0, 1);
            GL.Translate(-0.5, 0, 0);
            draw_FigureA(A_xChange, A_yChange);
            GL.PopMatrix();
            draw_FigureB(B_xChange, B_yChange);
            controlWindow.SwapBuffers();
        }
    }
}
