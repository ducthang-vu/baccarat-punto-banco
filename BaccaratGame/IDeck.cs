namespace BaccaratGame
{
    public interface IDeck
    {
        int Count { get; }

        ICard DealCard();
    }
}