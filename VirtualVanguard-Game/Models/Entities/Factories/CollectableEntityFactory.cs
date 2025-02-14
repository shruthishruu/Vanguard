using System;

namespace VirtualVanguard_Game.Models
{
    public class CollectableEntityFactory : EntityFactory
    {
        public override Entity CreateEntity(string type, Vector2 position, int width, int height, Texture2D image)
        {
            if (type == "Powerup")
            {
                return new PowerupEntity(x, y, width, height, image);
            }
            else if (type == "Bomb")
            {
                return new BombEntity(x, y, width, height, image);
            }
            else
            {
                throw new ArgumentException("Invalid collectable entity type");
            }
        }
    }
}
