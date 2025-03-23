using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace VirtualVanguard_Game.Models
{
    public class EventManager
    {
        private List<Phase> phases;
        private int currentPhaseIndex = 0;
        private BackgroundManager backgroundManager;
        private CharacterFactory characterFactory;
        private EntityManager entityManager;

        // List of Observers
        private List<IGameEventObserver> observers = new List<IGameEventObserver>();

        public EventManager(CharacterFactory characterFactory, EntityManager entityManager, BackgroundManager backgroundManager)
        {
            this.characterFactory = characterFactory;
            this.entityManager = entityManager;
            this.backgroundManager = backgroundManager;

            string filePath = "Content/event_script.json";
            LoadPhasesFromJson(filePath);
        }

        private void LoadPhasesFromJson(string filePath)
        {
            try
            {
                string jsonString = File.ReadAllText(filePath);
                var eventData = JsonSerializer.Deserialize<EventData>(jsonString);
                phases = eventData?.phases ?? new List<Phase>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading JSON: {ex.Message}");
                phases = new List<Phase>();
            }
        }

        public void Subscribe(IGameEventObserver observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(IGameEventObserver observer)
        {
            observers.Remove(observer);
        }

        public void Notify(GameEvent gameEvent)
        {
            foreach (var observer in observers)
            {
                observer.OnEvent(gameEvent);
            }
        }

        public void Update(GameTime gameTime)
        {
            double totalSeconds = gameTime.TotalGameTime.TotalSeconds;

            if (currentPhaseIndex < phases.Count && totalSeconds >= phases[currentPhaseIndex].time)
            {
                StartPhase(phases[currentPhaseIndex]);
                currentPhaseIndex++;
            }

            // Instead of directly checking win condition, notify observers
            Notify(new GameEvent("CheckWinCondition", new { gameTime, entities = entityManager.GetAllEntities() }));
        }

        private void StartPhase(Phase phase)
        {
            Console.WriteLine($"Starting Phase at {phase.time} seconds");

            if (phase.removeEnemies)
            {
                entityManager.RemoveEnemies();
            }
            backgroundManager.SetBackground(phase.background);

            foreach (var enemy in phase.enemies)
            {
                characterFactory.CreateEntity(enemy.type, new Vector2(enemy.x, enemy.y), enemy.width, enemy.height, new Vector2(enemy.orientation[0], enemy.orientation[1]));
            }

            // Notify observers that a new phase has started
            Notify(new GameEvent("PhaseStarted", phase));
        }
    }

    // JSON Data Structures
    public class EventData
    {
        public List<Phase> phases { get; set; }
    }

    public class Phase
    {
        public double time { get; set; }        // "time" in JSON
        public string background { get; set; }  // "background" in JSON
        public bool removeEnemies { get; set; } // "removeEnemies" in JSON
        public List<EnemyData> enemies { get; set; }
    }

    public class EnemyData
    {
        public string type { get; set; }   // "type" in JSON
        public float x { get; set; }       // "x" in JSON
        public float y { get; set; }       // "y" in JSON
        public int width { get; set; }     // "width" in JSON
        public int height { get; set; }    // "height" in JSON
        public List<int> orientation { get; set; } // "rotation" in JSON
    }
}
