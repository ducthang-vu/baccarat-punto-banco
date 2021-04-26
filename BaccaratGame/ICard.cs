namespace BaccaratGame
{
    public interface ICard
    {
        CardRank Rank { get; }
        CardSuit Suit { get; }
        int Value { get;  }
        string ToString();
    }
}