using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pixel_Bot_Mono {
    class AssetLoader {

        static Texture2D SpriteSheet, Background;


        public static ContentManager contentManager;

        public static Texture2D GetBackground() {
            if (Background == null) {
                Background = contentManager.Load<Texture2D>("KennyArt/set2_tiles");
            }
            return Background;
        }

        public static Texture2D getSpriteSheet() {
            if (SpriteSheet == null) {
                SpriteSheet = contentManager.Load<Texture2D>("KennyArt/Sprites");
            }
            return SpriteSheet;
        } 

    }
}
