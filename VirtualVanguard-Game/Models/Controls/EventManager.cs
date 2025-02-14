using System;
using System.Collections.Generic;
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

        private CharacterFactory characterFactory;

        public EventManager(CharacterFactory characterFactory)
        {
            this.characterFactory = characterFactory;
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
            for (int i = 0; i < 3; i++)
            {
                Vector2 position = new Vector2(i * 100 + 500, 0); // Example positions
                characterFactory.CreateEntity("Enemy", position, 50, 50, 0);
            }
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