using System.Collections.Generic;

namespace VirtualVanguard_Game.Models
{
    public abstract class Entity
    {
        public List<Control> Controls { get; set; }
        public List<Boundary> Boundaries { get; set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Width { get; }
        public int Height { get; }
        public string ImagePath { get; }

        public Entity(int x, int y, int width, int height, string imagePath)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            ImagePath = imagePath;
            
            // Initialize lists to prevent NullReferenceException
            Boundaries = new List<Boundary>();
        }
    }
}