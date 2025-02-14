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
            characterFactory = new CharacterFactory(content);
        }

        public void Update(GameTime gameTime)
        {
            double totalSeconds = gameTime.TotalGameTime.TotalSeconds;

            // Handle phase transitions
            HandlePhaseTransitions(totalSeconds);
        }

        private void StartPhase1()
        {
            Console.WriteLine("Phase 1: Regular Grunts");
            
            // Spawn 3 grunts
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