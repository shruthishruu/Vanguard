using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public abstract class EntityFactory
    {
        public abstract Entity CreateEntity(string type, Vector2 position, int width, int height, int orientation, Texture2D image);
    }
}
