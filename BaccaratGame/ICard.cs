namespace BaccaratGame
{
    public interface ICard
    {
        CardRank Rank { get; }
        CardSuit Suit { get; }

        string ToString();
    }
}