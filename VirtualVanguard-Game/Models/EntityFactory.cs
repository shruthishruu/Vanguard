using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace VirtualVanguard_Game.Models
{
    public abstract class EntityFactory
    {
        protected ContentManager Content;
        public EntityFactory(ContentManager content)
        {
            Content = content;
        }
        public abstract Entity CreateEntity(string type, Vector2 position, int width, int height, int orientation, Texture2D image);
    }
}
