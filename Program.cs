using System;
using System.Collections.Generic;
using System.Linq;

namespace ShootingDice
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SmackTalkingPlayer smackTalker = new SmackTalkingPlayer()
                {
                    Taunt = "You're about to lose a lot of money!"
                };
                smackTalker.Name = "Smack-Talkin Bob";

                OneHigherPlayer oneHigherPlayer = new OneHigherPlayer();
                oneHigherPlayer.Name = "One-High Sue";

                HumanPlayer humanPlayer = new HumanPlayer();
                humanPlayer.Name = "Wilma";

                Player bigRoller = new LargeDicePlayer();
                bigRoller.Name = "Bigun Rollsalot";

                CreativeSmackTalkingPlayer creativeSmackTalker = new CreativeSmackTalkingPlayer();
                creativeSmackTalker.Name = "Creative Charlie";

                SoreLoserPlayer soreLoser = new SoreLoserPlayer();
                soreLoser.Name = "Angry Sally";
                soreLoser.Play(smackTalker);

                Console.WriteLine("-------------------");

                List<Player> players = new List<Player>() {
                    smackTalker, oneHigherPlayer, humanPlayer, bigRoller, creativeSmackTalker
                };

                //PlayMany(players);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Angry Sally is quite mad since she lost. She broke the game");
            }
        }

        static void PlayMany(List<Player> players)
        {
            Console.WriteLine();
            Console.WriteLine("Let's play a bunch of times, shall we?");

            // We "order" the players by a random number
            // This has the effect of shuffling them randomly
            Random randomNumberGenerator = new Random();
            List<Player> shuffledPlayers = players.OrderBy(p => randomNumberGenerator.Next()).ToList();

            // We are going to match players against each other
            // This means we need an even number of players
            int maxIndex = shuffledPlayers.Count;
            if (maxIndex % 2 != 0)
            {
                maxIndex = maxIndex - 1;
            }

            // Loop over the players 2 at a time
            for (int i = 0; i < maxIndex; i += 2)
            {
                Console.WriteLine("-------------------");

                // Make adjacent players play noe another
                Player player1 = shuffledPlayers[i];
                Player player2 = shuffledPlayers[i + 1];
                player1.Play(player2);
            }
        }
    }
}