namespace VirtualVanguard_Game.Models
{
    public interface IGameEventObserver
    {
        void OnEvent(GameEvent gameEvent);
    }
}