
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Pixel_Bot_Mono {
   public class Transform {

        public static List<Transform> transforms = new List<Transform>();

        public RectangleF SizeAndLocation = new RectangleF(0, 0, 0, 0);

        public Vector2 Location {
            get {
                return new Vector2(SizeAndLocation.X, SizeAndLocation.Y);
            }
            set {
                SizeAndLocation.X = value.X;
                SizeAndLocation.Y = value.Y;
            }
        }
        public Vector2 Size {
            get {
                return new Vector2(SizeAndLocation.Width, SizeAndLocation.Height);
            }
            set {
                SizeAndLocation.Width = value.X;
                SizeAndLocation.Height = value.Y;
            }
        }
        public static explicit operator Microsoft.Xna.Framework.Rectangle(Transform _transform){
            return new Microsoft.Xna.Framework.Rectangle(
                new Microsoft.Xna.Framework.Point((int)_transform.SizeAndLocation.X,(int)_transform.SizeAndLocation.Y), 
                new Microsoft.Xna.Framework.Point((int)_transform.SizeAndLocation.Width, (int)_transform.SizeAndLocation.Height));
        
        }
        public Transform() {
            if (this is Camera)
                return;
            transforms.Add(this);
        }
        public void Translate(Vector2 _direction) {
            Location += _direction;       
        }
    }
}
