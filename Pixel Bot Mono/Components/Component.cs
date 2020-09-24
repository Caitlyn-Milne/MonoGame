using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pixel_Bot_Mono
{
    public abstract class Component {
        protected ActorObject parentActor;
        public Component(ActorObject _parent) {
            parentActor = _parent;
            parentActor.AddComponent(this);
        }
        public virtual void Update() {
        }

        /// <summary>
        /// Called after update for processes that need code in otherr classes to already of been run
        /// </summary>
        public virtual void LateUpdate() { }
    }
}
