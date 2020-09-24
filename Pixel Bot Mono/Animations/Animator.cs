using Microsoft.VisualBasic.CompilerServices;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pixel_Bot_Mono
{
    class Animator {

        public Animator(){
        }

        Dictionary<string, AbstractAnimation> animations = new Dictionary<string, AbstractAnimation>();

        Dictionary<string, AbstractAnimation> playingAnimations = new Dictionary<string, AbstractAnimation>();

        public void AddAnimation(string _name, AbstractAnimation _animation) {
            animations.Add(_name, _animation);
        }

        public void Progress() {
            foreach (KeyValuePair<string, AbstractAnimation> animationKeyValuePair in playingAnimations) {
                animationKeyValuePair.Value.Progress();
            }
        }


        public bool PlayAnimation(string _name) {
            try {
                AbstractAnimation animation;
                if (!animations.TryGetValue(_name, out animation))
                    return false;
                if (!playingAnimations.ContainsKey(_name))
                    playingAnimations.Add(_name, animation);
                animation.Reset();
                return true;
            }
            catch {
                return false;
            }
        }
        public bool StopAnimation(string _name) {
            return playingAnimations.Remove(_name);
        }

        public bool IsPlaying(string _name) {
            return playingAnimations.ContainsKey(_name);
        }

    }
}
