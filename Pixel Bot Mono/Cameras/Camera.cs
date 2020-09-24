using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Pixel_Bot_Mono {
    abstract class Camera : Transform{
        public static Camera currentCamera;
        public static List<Camera> Cameras = new List<Camera>();

        public Camera() {
            SizeAndLocation = new RectangleF(100,0,100,100);
            if (currentCamera == null) {
                currentCamera = this;
               
            }

        }

        public abstract void Update();
    }
}
