using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace ButtonTest.Src.Main
{
    internal class Polygons : RenderObject
    {
        protected readonly int _vertexLength;

        public Polygons(Vertex[] vertices, Vector3? position, Vector3? rotation, Vector3? scale)
            : base(position, rotation, scale)
        {
            _vertexLength = vertices.Length;

            GL.BindVertexArray(this._vertexArray);
            GL.BindBuffer(BufferTarget.ArrayBuffer, this._buffer);

            GL.EnableVertexArrayAttrib(this._vertexArray, 0);
            Logger.CheckError("1");
            GL.VertexArrayAttribBinding(this._vertexArray, 0, 0);
            Logger.CheckError("2");
            GL.VertexArrayAttribFormat(this._vertexArray,
                0,
                Vertex.Size,
                VertexAttribType.Float,
                false,
                0);
            Logger.CheckError("3");
            GL.EnableVertexArrayAttrib(this._vertexArray, 1);
            GL.VertexArrayAttribBinding(this._vertexArray, 1, 0);
            GL.VertexArrayAttribFormat(this._vertexArray,
                1,
                Vertex.Size,
                VertexAttribType.Float,
                false,
                16);

            GL.NamedBufferStorage(this._buffer, Vertex.Size * _vertexLength, vertices, BufferStorageFlags.MapWriteBit);
        }

        public override void Draw(Matrix4 projection)
        {
            Matrix4 translation = Matrix4.CreateTranslation(this._position);
            Matrix4 rotation = Matrix4.CreateRotationX(this._rotation.X) *
                Matrix4.CreateRotationY(this._rotation.Y) *
                Matrix4.CreateRotationZ(this._rotation.Z);
            Matrix4 scale = Matrix4.CreateScale(this._scale);
            Matrix4 modelview = translation * rotation * scale;

            GL.UniformMatrix4(20, false, ref modelview);
            GL.UniformMatrix4(21, false, ref projection);

            GL.BindVertexArray(this._vertexArray);
            GL.DrawArrays(PrimitiveType.Triangles, 0, _vertexLength);
        }
    }
}
