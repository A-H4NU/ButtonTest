using OpenTK;
using System;

namespace ButtonTest.Src.Main.UserInteract
{
    internal abstract class UserInteract
    {
        public int InteractCount { get; private set; }

        protected RenderObject _appearance;

        public virtual EventHandler<InteractEventArgs> Interacted { get; protected set; }

        public virtual bool CanInteractedOn(Vector2 _) { return false; }

        public virtual void Interact(Vector2 _)
        {
            if (!CanInteractedOn(_)) return;
            InteractCount++;
            Interacted.Invoke(this, new InteractEventArgs(_));
        }

        public virtual void Draw(Matrix4 projection) => this._appearance?.Draw(projection);
    }
}
