namespace VirtualVanguard_Game.Models
{
    public class GameEvent
    {
        public string EventType { get; }
        public object Data { get; }

        public GameEvent(string eventType, object data = null)
        {
            EventType = eventType;
            Data = data;
        }
    }
}