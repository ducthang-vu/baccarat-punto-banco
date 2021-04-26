namespace BaccaratGame
{
    public interface IGameManager
    {
        IDeck Deck { get; }
        IPlayer Player { get; }

        void Run();
    }
}