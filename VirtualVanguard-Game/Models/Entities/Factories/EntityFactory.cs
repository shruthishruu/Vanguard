using System;

namespace VirtualVanguard_Game.Models
{
    public abstract class EntityFactory
    {
        public abstract Entity CreateEntity(string type, int x, int y, int width, int height, string imagePath);
    }
}
