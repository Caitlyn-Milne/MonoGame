
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pixel_Bot_Mono
{
    class FollowCamera :Camera {
        public Transform target;

        public Vector2 offset;

        public float lerpAmount;

        public FollowCamera(Transform _target, Vector2 _offset, float _lerpAmount) : base() {
            target =  _target;
            offset = _offset;
            lerpAmount = _lerpAmount;
        }

        public override void Update() {
            Location =  Vector2.Lerp(Location, target.Location + offset, lerpAmount*(float)Game1.GlobalGameTime.ElapsedGameTime.TotalSeconds);

        }
    }
}
