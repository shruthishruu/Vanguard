using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Models;

namespace GameProject  
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Player player;
        private Enemy enemy;
        private BossEnemy bossEnemy;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";  
            IsMouseVisible = true;  
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Texture2D playerTexture = Content.Load<Texture2D>("playerTexture");
            Texture2D enemyTexture = Content.Load<Texture2D>("enemyTexture");
            Texture2D bossTexture = Content.Load<Texture2D>("bossTexture");

            player = new Player(playerTexture, new Vector2(100, 100), 200f);
            enemy = new Enemy(enemyTexture, new Vector2(200, 50), 100f, "Enemy1");
            bossEnemy = new BossEnemy(bossTexture, new Vector2(300, 0), 150f, "FinalBoss");
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            player.Update(gameTime);
            enemy.Update(gameTime);
            bossEnemy.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            player.Draw(spriteBatch);
            enemy.Draw(spriteBatch);
            bossEnemy.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
