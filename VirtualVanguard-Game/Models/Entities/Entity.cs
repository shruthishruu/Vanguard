using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Models
{
    abstract public class Entity
    {
        public Entity(int x, int y, int width, int height, string imagePath)
        {
        }
        public List<System> Systems { get; set; }
        public List<Component> Components { get; set; }
    }
}