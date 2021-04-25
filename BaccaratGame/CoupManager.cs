using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaccaratGame
{
    public class CoupManager
    {
        readonly IPlayer Player;
        readonly ICoup Coup;

        private enum BetOption
        {
            Banker,
            Player,
            Tie
        }

        readonly Dictionary<BetOption, int> Pot = new() { 
            { BetOption.Banker, 0 },
            { BetOption.Player, 0 },
            { BetOption.Tie, 0 },
        };


        public CoupManager(IPlayer player, ICoup coup) 
        {
            Player = player;
            Coup = coup;

            Console.WriteLine("\n\t***NEW ROUND***\nWe are starting a new round!");

            setPot();
            Coup.DoInitialDeal();
            OutputCoupState();
            if (Coup.Result != CoupResult.Pending)
            {
                EndCoup();
            }
            else
            {
                Console.WriteLine("\nNo natural...");
                Coup.SupplementaryDeal();
                OutputCoupState();
                EndCoup();
            }
        }

        void SetPot(string prompt, BetOption actor)
        {
            Console.WriteLine($"\nDo you want to bet on the {prompt}? (enter any quantity)");
            while (true)
            {
                int quantity;
                try
                {
                    quantity = Convert.ToInt32(Console.ReadLine());
                    if (quantity < 0)
                    {
                        throw new FormatException("Negative intengers are not allowed.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please, enter a integer positive number.");
                    continue;
                }

                try
                {
                    Player.SubtractCredit(quantity);
                }
                catch (InvalidOperationException)
                {
                    Console.WriteLine($"Insufficient funds! You only have {Player.Credit} of credits. Try again.");
                    continue;
                }

                Pot[actor] = quantity;
                break;

            }
        }

        void setPot()
        {
            Console.WriteLine($"You have {Player.Credit} of credits.");
            SetPot("banker winning", BetOption.Banker);
            SetPot("player winning", BetOption.Player);
            SetPot("a tie", BetOption.Tie);
        }

        void EndCoup()
        {
            switch (Coup.Result)
            {
                case CoupResult.BankerWins:
                    Console.WriteLine("The banker wins.\n");
                    int betBanker = Pot[BetOption.Banker];
                    if (Convert.ToBoolean(betBanker))
                    {
                        int toBeAwarded = Pot[BetOption.Banker] * 19 / 20;
                        Console.WriteLine($"Congratulations! You have been awarded {betBanker + toBeAwarded}.");
                    }
                    break;
                case CoupResult.PlayerWins:
                    Console.WriteLine("The player wins.");
                    int betPlayer = Pot[BetOption.Player];
                    if (Convert.ToBoolean(betPlayer))
                    {
                        Console.WriteLine($"Congratulations! You have been awarded {2 * betPlayer}.");
                    }
                    break;
                case CoupResult.Tie:
                    Console.WriteLine("It's a tie.");
                    int betTie = Pot[BetOption.Tie];
                    if (Convert.ToBoolean(betTie))
                    {
                        Console.WriteLine($"Congratulations! You have been awarded {2 * betTie}.");
                    }
                    break;
            }
            
        }

        void OutputCoupState()
        {
            Console.WriteLine();

            Console.WriteLine("Banker's cards:");
            Coup.BankerCards.ForEach(Console.WriteLine);
            Console.WriteLine($"Banker's score is {Coup.BankerScore}.\n");

            Console.WriteLine("Player's cards:");
            Coup.PlayerCards.ForEach(Console.WriteLine);
            Console.WriteLine($"Player's score is {Coup.PlayerScore}.\n");
        }
    }
}
