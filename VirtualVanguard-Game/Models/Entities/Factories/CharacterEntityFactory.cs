using System;

namespace VirtualVanguard_Game.Models
{
    public class CharacterEntityFactory : EntityFactory
    {
        public override Entity CreateEntity(string type, Vector2 position, int width, int height, Texture2D image)
        {
            if (type == "Player")
            {
                return new PlayerEntity(x, y, width, height, image);
            }
            else if (type == "Enemy")
            {
                return new EnemyEntity(x, y, width, height, image);
            }
            else if (type == "Boss")
            {
                return new BossEntity(x, y, width, height, image);
            }
            else
            {
                throw new ArgumentException("Invalid character type");
            }
        }
    }
}