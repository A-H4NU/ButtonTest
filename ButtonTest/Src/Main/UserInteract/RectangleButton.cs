using OpenTK;
using OpenTK.Graphics;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ButtonTest.Src.Main.UserInteract
{
    class RectangleButton : Button
    {
        private RectangleF _area;

        public override EventHandler<InteractEventArgs> Interacted { get; protected set; }

        public RectangleButton(RectangleF area, Color4 color)
        {
            this._area = area;
            this._appearance = new Polygons(
                ObjectFactory.Rectangle(area.Width, area.Height, color),
                new Vector3(area.Location.X, area.Location.Y, 0),
                null,
                null);
        }

        public override bool CanInteractedOn(Vector2 mouse)
        {
            return _area.Contains(new PointF(mouse.X, mouse.Y));
        }

        public override void Interact(Vector2 mouse)
        {
            base.Interact(mouse);
        }
    }
}
