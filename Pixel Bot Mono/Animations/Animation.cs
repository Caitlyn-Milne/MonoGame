using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pixel_Bot_Mono {
    class Animation<T> : AbstractAnimation {
        T currentValue;
        T[] values;

        float animationSpeed;

        public delegate void ValueChangedDelegate(T _value);
        public ValueChangedDelegate onValueChanged;

        int currentIndex;
        double count = -0;

        public Animation(T[] _values, float _animationSpeed) {
            values = _values;
            animationSpeed = _animationSpeed;
        }

        public override void Reset() {
            currentIndex = 0;
            count = 0;
            currentValue = values[0];
        }

        public override void Progress() {
            double valueToAdd = Game1.GlobalGameTime.ElapsedGameTime.TotalSeconds / animationSpeed;
            count += valueToAdd;
            int index = (int)Math.Floor(count);
            if (index > values.Length - 1) {
                index = 0;
                count = 0;
            }
            if (index != currentIndex || count == valueToAdd) {
                onValueChanged?.Invoke(currentValue);
                currentIndex = index;
                currentValue = values[currentIndex];
            }
        }

    }
}
