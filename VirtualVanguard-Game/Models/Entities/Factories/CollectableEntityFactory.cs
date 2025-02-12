using System;

namespace Models
{
    public class CollectableEntityFactory : EntityFactory
    {
        public override void CreateEntity(string type, int x, int y, int width, int height, string imagePath)
        {
            if (type == "Powerup")
            {
                new PowerupEntity(x, y, width, height, imagePath);
            }
            else if (type == "Bomb")
            {
                new BombEntity(x, y, width, height, imagePath);
            }
            else
            {
                throw new ArgumentException("Invalid powerup type");
            }
        }
    }
}