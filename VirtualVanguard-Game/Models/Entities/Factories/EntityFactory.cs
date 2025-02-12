using System;

namespace Models
{
    abstract public class SpriteFactory
    {
        public abstract void CreateSprite(string type, int x, int y, int width, int height, string imagePath);
    }
}