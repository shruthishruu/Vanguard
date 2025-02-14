using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class CollectableFactory : EntityFactory
    {
        public override Entity CreateEntity(string type, Vector2 position, int width, int height, int orientation, Texture2D image)
        {
            if (type == "Powerup")
            {
                
            }
            else if (type == "Bomb")
            {
                
            }
            else
            {
                throw new ArgumentException("Invalid collectable entity type");
            }
            return new Collectable(position, width, height, orientation, image);
        }
    }
}
