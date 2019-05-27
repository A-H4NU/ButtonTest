using OpenTK;
using OpenTK.Graphics;

namespace ButtonTest.Src.Main
{
    internal static class ObjectFactory
    {
        public static Vertex[] Rectangle (float width, float height, Color4 color)
        {
            width /= 2;
            height /= 2;

            return new Vertex[]
            {
                new Vertex(new Vector4(-width, +height, 0, 1), color),
                new Vertex(new Vector4(-width, -height, 0, 1), color),
                new Vertex(new Vector4(+width, +height, 0, 1), color),
                new Vertex(new Vector4(+width, +height, 0, 1), color),
                new Vertex(new Vector4(+width, -height, 0, 1), color),
                new Vertex(new Vector4(-width, -height, 0, 1), color),
            };
        }

        public static Vertex[] Square(float side, Color4 color)
        {
            return ObjectFactory.Rectangle(side, side, color);
        }
    }
}
