using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public abstract class Entity
    {
        public Vector2 Position { get; set; }
        public int Width { get; }
        public int Height { get; }
        public Texture2D Image { get; }
        public Vector2 Orientation { get; set; }

        public Entity(Vector2 position, int width, int height, Vector2 orientation, Texture2D image)
        {
            Position = position;
            Width = width;
            Height = height;
            Image = image;
            Orientation = orientation;
        }
    }
}