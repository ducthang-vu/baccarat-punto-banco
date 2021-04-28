namespace BaccaratGame
{
    /// <summary>
    /// A class extending the CardRank enum.
    /// </summary>
    public static class CardRankExtension
    {
        /// <summary>
        /// Get the interger value of a CardRank, accoring the baccarat rules.
        /// </summary>
        /// <param name="rank">The CardRank for which return a the integer value.</param>
        /// <returns></returns>
        public static int Value(this CardRank rank)
        {
            int numericValue = (int)rank;
            if (numericValue > 9) return 0;
            return numericValue;
        }
    }
}
