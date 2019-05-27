using OpenTK;
using OpenTK.Graphics;
using System.Runtime.InteropServices;

namespace ButtonTest.Src.Main
{
    internal struct Vertex
    {
        public static int Size = Marshal.SizeOf(typeof(Vertex));

        public Vector4 Position;
        public Color4 Color;

        public Vertex(Vector4 position, Color4 color)
        {
            this.Position = position;
            this.Color = color;
        }
    }
}
