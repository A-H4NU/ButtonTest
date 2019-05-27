using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Input;
using System;
using System.Collections.Generic;

namespace ButtonTest.Src.Main
{
    internal class Game : GameWindow
    {
        private readonly string _title;

        private ShaderProgram _program;
        private List<Polygons> _vaos;
        private Matrix4 _projection;

        public Game(int width, int height, string title)
            : base(width, height)
        {
            this._title = title;
            this._vaos = new List<Polygons>();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.ClearColor(Color4.Brown);
            GL.Enable(EnableCap.DepthTest);
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Fill);

            this._program = new ShaderProgram();
            this._program.AddShader(ShaderType.VertexShader, @"src/shaders/vertex.vert");
            this._program.AddShader(ShaderType.FragmentShader, @"src/shaders/fragment.frag");
            this._program.Link();

            this._vaos.Add(new Polygons(ObjectFactory.Square(0.5f, Color4.Magenta), new Vector3(0, 0, 5), null, null));

            this._projection = this.CreateProjection(113);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(this.ClientRectangle);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            HandleKeyboad();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            this.Title = $"{this._title} - {this.RenderFrequency:F2} FPS";

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            foreach (Polygons vao in this._vaos)
            {
                vao.Draw(this._projection);
            }

            this.SwapBuffers();
        }

        public override void Exit()
        {
            Logger.Info("Exit Called");
            foreach (Polygons vao in this._vaos)
            {
                vao.Dispose();
            }
            this._program.Dispose();

            base.Exit();
        }

        private Matrix4 CreateProjection(float fov) => Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(fov), (float)this.Width / this.Height, 1, 1000);

        private void HandleKeyboad()
        {
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Key.Escape))
            {
                this.Exit();
            }
        }
    }
}
