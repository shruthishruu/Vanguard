using System;

namespace Models
{
    public class CharacterSpriteFactory : SpriteFactory
    {
        public override void CreateSprite(string type, int x, int y, int width, int height, string imagePath)
        {
            if (type == "Player")
            {
                new PlayerSprite(x, y, width, height, imagePath);
            }
            else if (type == "Enemy")
            {
                new EnemySprite(x, y, width, height, imagePath);
            }
            else if (type == "Boss")
            {
                new BossSprite(x, y, width, height, imagePath);
            }
            else
            {
                throw new ArgumentException("Invalid character type");
            }
        }
    }
}