using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pixel_Bot_Mono {
    public abstract class ActorObject : Transform {

        protected Texture2D texture;

        protected Rectangle spriteLocation;

        public static List<ActorObject> ActorObjects = new List<ActorObject>();

        Color tint = Color.White;

        List<Component> components = new List<Component>();

        public ActorObject() :base(){
            ActorObjects.Add(this);
        }

        protected abstract Texture2D LoadTexture();

        public virtual void Update(GameTime _gameTime) {
            foreach (Component component in components) {
                component.Update();
            }
        }

        /// <summary>
        /// Called after update for processes that need code in otherr classes to already of been run
        /// </summary>
        public virtual void LateUpdate() {
            foreach (Component component in components) {
                component.LateUpdate();
            }
        }

        public virtual void Load() {
            texture = LoadTexture();
            spriteLocation = texture.Bounds;
        }

        public virtual void Draw(SpriteBatch _spriteBatch) {
            if (!Camera.currentCamera.SizeAndLocation.IntersectsWith(SizeAndLocation))
                return;
            _spriteBatch.Draw(texture, Game1.ConvertToScreenSpace(this), spriteLocation, tint);
        }

        public void AddComponent(Component component) {
            components.Add(component);
        }

    }
}
