using System;

namespace VirtualVanguard_Game.Models
{
    public class CollectableEntityFactory : EntityFactory
    {
        public override Entity CreateEntity(string type, int x, int y, int width, int height, string imagePath)
        {
            if (type == "Powerup")
            {
                return new PowerupEntity(x, y, width, height, imagePath);
            }
            else if (type == "Bomb")
            {
                return new BombEntity(x, y, width, height, imagePath);
            }
            else
            {
                throw new ArgumentException("Invalid collectable entity type");
            }
        }
    }
}
