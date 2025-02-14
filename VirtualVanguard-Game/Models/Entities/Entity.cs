using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public abstract class Entity
    {
        public List<Control> Controls { get; set; }
        public List<Boundary> Boundaries { get; set; }
        public Vector2 Position { get; private set; }
        public int Width { get; }
        public int Height { get; }
        public Texture2D Image { get; }

        public Entity(Vector2 position, int width, int height, Texture2D image)
        {
            Position = position;
            Width = width;
            Height = height;
            Image = image;
            
            // Initialize lists to prevent NullReferenceException
            Boundaries = new List<Boundary>();
        }
    }
}