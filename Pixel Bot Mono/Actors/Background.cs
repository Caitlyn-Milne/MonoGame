using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pixel_Bot_Mono {
    class Background : ActorObject {
        public override void Update(GameTime _gameTime) {
            Size = new Vector2(100, 100);
            Location = new Vector2(100, 0);
        }

        protected override Texture2D LoadTexture() {
            return AssetLoader.GetBackground();
        }
    }
}
