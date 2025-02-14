using System;

namespace VirtualVanguard_Game.Models
{
    public class EventManager : Control
    {
        private bool phase1Started = false;
        private bool phase2Started = false;
        private bool phase3Started = false;
        private bool phase4Started = false;
        EntityFactory entityFactory;
        public EventManager() { 
            entityFactory = new CharacterEntityFactory();
        }

        public override void Update()
        {
            Console.WriteLine("Updating EventManager without time.");
        }

        public void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
             double totalSeconds = gameTime.TotalGameTime.TotalSeconds;

             Console.WriteLine($"Total game time: {totalSeconds} seconds");

            if (totalSeconds >= 2 && totalSeconds < 2.1)
            {
                Console.WriteLine("Spawning Player...");
                entityFactory.CreateEntity("Player", 100, 200, 50, 50, "player.png");
            }

            if (totalSeconds >= 5 && totalSeconds < 5.1)
            {
                Console.WriteLine("Spawning Enemy...");
                entityFactory.CreateEntity("Enemy", 0, 0, 50, 50, "enemy.png");
            }

            if (totalSeconds >= 30 && totalSeconds < 30.1)
            {
                Console.WriteLine("Spawning Boss...");
                entityFactory.CreateEntity("Boss", 400, 100, 100, 100, "boss.png");
            }
             HandlePhaseTransitions(totalSeconds);

        }

        private void StartPhase1() {

        }
        private void StartPhase2() {
            
        }
        private void StartPhase3() {
            
        }
        private void StartPhase4() {
            
        }
        private void HandlePhaseTransitions(double elapsedTime)
        {
            if (elapsedTime >= 3 && elapsedTime < 33)
            {
                if (!phase1Started)
                {
                    Console.WriteLine("Starting Phase 1: Regular Grunts");
                    phase1Started = true;
                    StartPhase1();
                }
            }
            else if (elapsedTime >= 36 && elapsedTime < 86)
            {
                if (!phase2Started)
                {
                    Console.WriteLine("Starting Phase 2: First Boss Fight");
                    phase2Started = true;
                    StartPhase2();
                }
            }
            else if (elapsedTime >= 89 && elapsedTime < 120)
            {
                if (!phase3Started)
                {
                    Console.WriteLine("Starting Phase 3: Additional Grunts");
                    phase3Started = true;
                    StartPhase3();
                }
            }
            else if (elapsedTime >= 123 && elapsedTime < 173)
            {
                if (!phase4Started)
                {
                    Console.WriteLine("Starting Phase 4: Final Boss Fight");
                    phase4Started = true;
                    StartPhase4();
                }
            }
        }

    }

}
