using System;
using System.Collections.Generic;
using System.Text;

namespace Pixel_Bot_Mono
{
    /// <summary>
    /// literally a class so i can have a list of animation
    /// </summary>
    abstract class AbstractAnimation {
        public abstract void Reset();
        public abstract void Progress();
    }
}
