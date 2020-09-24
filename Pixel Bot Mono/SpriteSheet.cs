using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pixel_Bot_Mono
{
    class SpriteSheet {
        Texture2D texture;
        Vector2 spriteSize;
        int spriteGapSize;
        public SpriteSheet(Texture2D _texture, Vector2 _spriteSize, int _spritesGapSize) {
            texture = _texture;
            spriteSize = _spriteSize;
            spriteGapSize = _spritesGapSize;
        }

        /// <summary>
        /// Converts position to a pixel location
        /// </summary>
        public Rectangle GetLocationForPosition(Vector2 _position) {
            Rectangle location = new Rectangle();
            location.Width = (int)spriteSize.X;
            location.Height = (int)spriteSize.Y;
            location.X =(int)Math.Floor(_position.X * (spriteSize.X + spriteGapSize));
            location.Y = (int)Math.Floor(_position.Y * (spriteSize.Y + spriteGapSize));
            return location;
        }
    }
}
