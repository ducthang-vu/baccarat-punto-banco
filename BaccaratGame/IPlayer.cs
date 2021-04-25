namespace BaccaratGame
{
    public interface IPlayer
    {
        int Credit { get; }
        string Name { get; }

        int addCredit(int quantity);
        int SubtractCredit(int quantity);
    }
}