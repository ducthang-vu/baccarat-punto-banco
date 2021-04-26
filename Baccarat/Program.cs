using BaccaratGame;

namespace Baccarat
{
    class Program
    {
        static void Main(string[] args)
        {
            IGameManager gameManager = new GameManager();
            gameManager.Run();
        }
    }
}
