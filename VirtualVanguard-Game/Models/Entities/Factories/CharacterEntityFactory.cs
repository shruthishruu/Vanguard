using System;

namespace Models
{
    public class CharacterEntityFactory : EntityFactory
    {
        public override void CreateEntity(string type, int x, int y, int width, int height, string imagePath)
        {
            if (type == "Player")
            {
                new PlayerEntity(x, y, width, height, imagePath);
            }
            else if (type == "Enemy")
            {
                new EnemyEntity(x, y, width, height, imagePath);
            }
            else if (type == "Boss")
            {
                new BossEntity(x, y, width, height, imagePath);
            }
            else
            {
                throw new ArgumentException("Invalid character type");
            }
        }
    }
}