using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pixel_Bot_Mono {
    public class PlayerController : Controller {
        VelocityComponent velocityComponent;


        Animator animator = new Animator();

        Animation<Rectangle> idleAnimation, runAnimation;

        SpriteSheet spriteSheet;

        float moveSpeed = 0.75f;

        public PlayerController() : base() {
            Size = new Vector2(4, 6.25f);
            Location = new Vector2(150,90);
            velocityComponent = new VelocityComponent(this);
            velocityComponent.gravity = 7.5f;
            velocityComponent.gravityAcc = 2.5f;
            
        }

        public override void Load() {
            base.Load();

            spriteSheet = new SpriteSheet(texture, new Vector2(64, 64), 10);


            idleAnimation = new Animation<Rectangle>(
                new Rectangle[] {
                      spriteSheet.GetLocationForPosition(new Vector2(24,7)),
                      spriteSheet.GetLocationForPosition(new Vector2(22,6)),
                      spriteSheet.GetLocationForPosition(new Vector2(22,6)),
                      spriteSheet.GetLocationForPosition(new Vector2(23,6)),
                      spriteSheet.GetLocationForPosition(new Vector2(22,6)),
                      spriteSheet.GetLocationForPosition(new Vector2(22,6)),
                      spriteSheet.GetLocationForPosition(new Vector2(24,7))
                },
                 0.5f
            );

            runAnimation = new Animation<Rectangle>(
                new Rectangle[] {
                    spriteSheet.GetLocationForPosition(new Vector2(24,6)),
                    spriteSheet.GetLocationForPosition(new Vector2(25,6)),
                    spriteSheet.GetLocationForPosition(new Vector2(26,6)),
                    spriteSheet.GetLocationForPosition(new Vector2(26,6)),
                    spriteSheet.GetLocationForPosition(new Vector2(25,6)),
                    spriteSheet.GetLocationForPosition(new Vector2(24,6)),
                 },
                0.05f
            );
            idleAnimation.onValueChanged += OnSpriteAnimationInvoked;
            runAnimation.onValueChanged += OnSpriteAnimationInvoked;

            animator.AddAnimation("idle", idleAnimation);
            animator.AddAnimation("run", runAnimation);
            animator.PlayAnimation("idle");
           

        }

        protected override Texture2D LoadTexture() {
            return AssetLoader.getSpriteSheet();
        }

        public override void Draw(SpriteBatch _spriteBatch) {
            base.Draw(_spriteBatch);
            /*Rectangle screenSpaceLocation  = Game1.ConvertToScreenSpace(this);
            Rectangle dropShadowLocation = screenSpaceLocation;
            dropShadowLocation.X -=(int)(0.5f * Game1.vw);
            _spriteBatch.Draw(texture, dropShadowLocation, spriteLocation, new Color(0, 0, 0, 100));
            _spriteBatch.Draw(texture, screenSpaceLocation, spriteLocation, Color.White);*/
        }
        public override void Update(GameTime _gametime) {
            base.Update(_gametime);
            if (Game1.KeyboardState.IsKeyDown(Keys.Left)) {
                Translate(new Vector2(-moveSpeed * ((float)_gametime.ElapsedGameTime.TotalMilliseconds / 16), 0));
                if (animator.IsPlaying("idle")) {
                    animator.StopAnimation("idle");
                    animator.PlayAnimation("run");
                }
            }
            else if (Game1.KeyboardState.IsKeyDown(Keys.Right)) {
                Translate(new Vector2(moveSpeed * ((float)_gametime.ElapsedGameTime.TotalMilliseconds / 16), 0));
                if (animator.IsPlaying("idle")) {
                    animator.StopAnimation("idle");
                    animator.PlayAnimation("run");
                }

            }
            else if(!animator.IsPlaying("idle")){
                animator.PlayAnimation("idle");
                animator.StopAnimation("run");
            }

            //TODO remove temp jump code
            if (Game1.KeyboardState.IsKeyDown(Keys.Space) && Location.Y == 0) {
                velocityComponent.velocity = new Vector2(velocityComponent.velocity.X, 0);
                velocityComponent.AddForce(new Vector2(0, 3));
            }

            animator.Progress();

         //   currentTexture = animator.currentTexture;
        }


        public void OnSpriteAnimationInvoked(Rectangle _rect) {
            spriteLocation = _rect;
        }

    }
}
