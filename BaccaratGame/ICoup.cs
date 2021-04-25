using System.Collections.Generic;

namespace BaccaratGame
{
    public interface ICoup
    {
        List<ICard> BankerCards { get; }
        int BankerScore { get; }
        List<ICard> PlayerCards { get; }
        int PlayerScore { get; }
        CoupResult Result { get; }

        CoupResult DoInitialDeal();
        CoupResult SupplementaryDeal();
    }
}