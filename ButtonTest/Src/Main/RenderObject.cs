using OpenTK;
using OpenTK.Graphics.OpenGL4;
using System;

namespace ButtonTest.Src.Main
{
    internal abstract class RenderObject : IDisposable
    {
        protected readonly int _vertexArray;
        protected readonly int _buffer;

        protected Vector3 _position, _rotation, _scale;

        public Vector3 Position => this._position;
        public Vector3 Rotation => this._rotation;
        public Vector3 Scale => this._scale;

        protected Matrix4 ModelView
        {
            get
            {
                Matrix4 translation = Matrix4.CreateTranslation(this._position);
                Matrix4 rotation = Matrix4.CreateRotationX(this._rotation.X) *
                    Matrix4.CreateRotationY(this._rotation.Y) *
                    Matrix4.CreateRotationZ(this._rotation.Z);
                Matrix4 scale = Matrix4.CreateScale(this._scale);
                return translation * rotation * scale;
            }
        }


        protected RenderObject(Vector3? position, Vector3? rotation, Vector3? scale)
        {
            this._vertexArray = GL.GenVertexArray();
            this._buffer = GL.GenBuffer();
            this._position = position ?? Vector3.Zero;
            this._rotation = rotation ?? Vector3.Zero;
            this._scale = scale ?? Vector3.One;
        }

        public virtual void Dispose()
        {
            GL.DeleteVertexArray(this._vertexArray);
            GL.DeleteBuffer(this._buffer);

            GC.SuppressFinalize(this);
        }

        public virtual void Draw(Matrix4 _) { }
    }
}
