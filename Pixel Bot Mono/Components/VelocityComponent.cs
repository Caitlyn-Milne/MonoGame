using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pixel_Bot_Mono
{
    public class VelocityComponent : Component {
        public float friction;
        public float gravity, gravityAcc;
        public Vector2 velocity;
        public VelocityComponent(ActorObject _parent):base(_parent){
        }

        public override void Update() {
            base.Update();
            velocity.Y = Vector2.Lerp(velocity, new Vector2(0, -gravity), gravityAcc * (float)Game1.GlobalGameTime.ElapsedGameTime.TotalSeconds).Y;      
        }

        public override void LateUpdate() {
            parentActor.Translate(velocity * (float)(Game1.GlobalGameTime.ElapsedGameTime.TotalMilliseconds/16));
        }



        public void AddForce(Vector2 _force) {
            velocity += _force;
        }

        
    }
}
