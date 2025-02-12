using System;

namespace Models
{
    public class CollectableSpriteFactory : SpriteFactory
    {
        public override void CreateSprite(string type, int x, int y, int width, int height, string imagePath)
        {
            if (type == "Powerup")
            {
                new PowerupSprite(x, y, width, height, imagePath);
            }
            else if (type == "Bomb")
            {
                new BombSprite(x, y, width, height, imagePath);
            }
            else
            {
                throw new ArgumentException("Invalid powerup type");
            }
        }
    }
}