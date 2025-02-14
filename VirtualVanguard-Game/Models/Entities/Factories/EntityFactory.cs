using System;

namespace VirtualVanguard_Game.Models
{
    public abstract class EntityFactory
    {
        public abstract Entity CreateEntity(string type, Vector2 position, int width, int height, Texture2D image);
    }
}
