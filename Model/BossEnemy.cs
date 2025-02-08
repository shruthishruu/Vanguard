using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Models
{
    public class BossEnemy : Enemy
    {
        public int SpecialAttackCooldown { get; set; }

        public BossEnemy(Texture2D texture, Vector2 position, float speed, string name)
            : base(texture, position, speed, name)
        {
            SpecialAttackCooldown = 5; // Cooldown in seconds
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Boss-specific logic for special attacks
            if (SpecialAttackCooldown > 0)
            {
                SpecialAttackCooldown -= (int)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                // Perform a special attack
                SpecialAttackCooldown = 5; // Reset cooldown
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}


