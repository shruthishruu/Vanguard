using Microsoft.Xna.Framework.Graphics;

namespace Models
{
    public class Sprite
    {
        public Texture2D Texture { get; set; }

        public Sprite(Texture2D texture)
        {
            Texture = texture;
        }
    }
}


