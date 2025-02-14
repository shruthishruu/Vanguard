using System;
using Microsoft.Xna.Framework;
using VirtualVanguard_Game.Models;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Content;

namespace VirtualVanguard_Game.Models
{
    public class EventManager
    {
        private bool phase1Started = false;
        private bool phase2Started = false;
        private bool phase3Started = false;
        private bool phase4Started = false;
        private BackgroundManager backgroundManager;

        private CharacterFactory characterFactory;
        private EntityManager entityManager; // Add EntityManager for managing entities
        public EventManager(CharacterFactory characterFactory, EntityManager entityManager, BackgroundManager backgroundManager)
        {
            this.characterFactory = characterFactory;
            this.entityManager = entityManager; // Initialize EntityManager
            this.backgroundManager = backgroundManager;
        }

        public void Update(GameTime gameTime)
        {
            double totalSeconds = gameTime.TotalGameTime.TotalSeconds;

            // Handle phase transitions
            HandlePhaseTransitions(totalSeconds);
        }

        private void EndPhase()
        {
            Console.WriteLine("Ending Phase: Removing all enemies");

            // Remove all enemies
            entityManager.RemoveEnemies();
        }
        private void StartPhase1()
        {
            Console.WriteLine("Phase 1: Regular Grunts");
            backgroundManager.SetBackground("background1");

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
            backgroundManager.SetBackground("background2");

            // Spawn boss
            Vector2 position = new Vector2(400, 100);
            characterFactory.CreateEntity("Boss1", position, 100, 100, 0);
        }

        private void StartPhase3()
        {
            Console.WriteLine("Phase 3: Additional Grunts");
            backgroundManager.SetBackground("background3");

            // Add logic for Phase 3 (e.g., spawn more grunts)
            for (int i = 0; i < 5; i++)
            {
                Vector2 position = new Vector2(i * 100 + 300, 0); // Example positions
                characterFactory.CreateEntity("Enemy", position, 50, 50, 0);
            }
        }

        private void StartPhase4()
        {
            Console.WriteLine("Phase 4: Final Boss Fight");

            // Add logic for Phase 4 (e.g., spawn final boss)
            Vector2 position = new Vector2(400, 100);
            characterFactory.CreateEntity("Boss2", position, 150, 150, 0);
        }

        private void HandlePhaseTransitions(double elapsedTime)
        {
            if (elapsedTime >= 5 && !phase1Started) // Phase 1 starts at 3 seconds
            {
                phase1Started = true;
                StartPhase1();
            }
            else if (elapsedTime >= 10 && !phase2Started) // Phase 2 starts at 6 seconds
            {
                EndPhase(); // Remove Phase 1 enemies
                phase2Started = true;
                StartPhase2();
            }
            else if (elapsedTime >= 15 && !phase3Started) // Phase 3 starts at 9 seconds
            {
                EndPhase(); // Remove Phase 2 enemies
                phase3Started = true;
                StartPhase3();
            }
            else if (elapsedTime >= 20 && !phase4Started) // Phase 4 starts at 12 seconds
            {
                EndPhase(); // Remove Phase 3 enemies
                phase4Started = true;
                StartPhase4();
            }
        }
    }
}