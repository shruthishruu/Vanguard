using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace VirtualVanguard_Game.Models
{
    public class EventManager
    {
        private bool phase1Started = false;
        private bool phase2Started = false;
        private bool phase3Started = false;
        private bool phase4Started = false;

        private EntityFactory characterFactory;
        private ContentManager content;

        // Textures for entities
        private Texture2D playerTexture;
        private Texture2D enemyTexture;
        private Texture2D bossTexture;

        public EventManager(ContentManager content)
        {
            this.content = content;
            characterFactory = new CharacterFactory();

            // Load textures during initialization
            playerTexture = content.Load<Texture2D>("testplayer");
            enemyTexture = content.Load<Texture2D>("testplayer");
            bossTexture = content.Load<Texture2D>("testplayer");
        }

        public void Update(GameTime gameTime)
        {
            double totalSeconds = gameTime.TotalGameTime.TotalSeconds;

            // Console.WriteLine($"Total game time: {totalSeconds} seconds");

            // Spawn entities based on time
            if (totalSeconds >= 2 && totalSeconds < 2.1)
            {
                Console.WriteLine("Spawning Player...");
                Vector2 playerPosition = new Vector2(100, 200);
                characterFactory.CreateEntity("Player", playerPosition, 50, 50, 0, playerTexture);
            }

            if (totalSeconds >= 5 && totalSeconds < 5.1)
            {
                Console.WriteLine("Spawning Enemy...");
                Vector2 enemyPosition = new Vector2(0, 0);
                characterFactory.CreateEntity("Enemy", enemyPosition, 50, 50, 0, enemyTexture);
            }

            if (totalSeconds >= 30 && totalSeconds < 30.1)
            {
                Console.WriteLine("Spawning Boss...");
                Vector2 bossPosition = new Vector2(400, 100);
                characterFactory.CreateEntity("Boss", bossPosition, 100, 100, 0, bossTexture);
            }

            // Handle phase transitions
            HandlePhaseTransitions(totalSeconds);
        }

        private void StartPhase1()
        {
            Console.WriteLine("Phase 1: Regular Grunts");
            // Add logic for Phase 1
        }

        private void StartPhase2()
        {
            Console.WriteLine("Phase 2: First Boss Fight");
            // Add logic for Phase 2
        }

        private void StartPhase3()
        {
            Console.WriteLine("Phase 3: Additional Grunts");
            // Add logic for Phase 3
        }

        private void StartPhase4()
        {
            Console.WriteLine("Phase 4: Final Boss Fight");
            // Add logic for Phase 4
        }

        private void HandlePhaseTransitions(double elapsedTime)
        {
            if (elapsedTime >= 3 && !phase1Started)
            {
                phase1Started = true;
                StartPhase1();
            }
            else if (elapsedTime >= 36 && !phase2Started)
            {
                phase2Started = true;
                StartPhase2();
            }
            else if (elapsedTime >= 89 && !phase3Started)
            {
                phase3Started = true;
                StartPhase3();
            }
            else if (elapsedTime >= 123 && !phase4Started)
            {
                phase4Started = true;
                StartPhase4();
            }
        }
    }
}