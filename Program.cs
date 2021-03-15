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
                // Says the same insult when they roll
                SmackTalkingPlayer smackTalker = new SmackTalkingPlayer()
                {
                    Taunt = "You're about to lose a lot of money!"
                };
                smackTalker.Name = "Smack-Talkin Bob";

                // Always rolls one higher than their opponent
                OneHigherPlayer oneHigherPlayer = new OneHigherPlayer();
                oneHigherPlayer.Name = "One-High Sue";

                // Allows the user to play by entering a number
                HumanPlayer humanPlayer = new HumanPlayer();
                humanPlayer.Name = "Wilma";

                // Rolls a "20-sided" die instead of 6
                Player bigRoller = new LargeDicePlayer();
                bigRoller.Name = "Bigun Rollsalot";

                // Chooses from a list of random insults when they are the primary roller
                CreativeSmackTalkingPlayer creativeSmackTalker = new CreativeSmackTalkingPlayer();
                creativeSmackTalker.Name = "Creative Charlie";

                // If they lose, they throw an exception
                SoreLoserPlayer soreLoser = new SoreLoserPlayer();
                soreLoser.Name = "Angry Sally";

                // Rolls the upperhalf of their possible rolls
                UpperHalfPlayer upperPlayer = new UpperHalfPlayer();
                upperPlayer.Name = "Uptop Eustice";

                // Rolls the upperhalf of their possible rolls
                // If they lose, they throw an exception
                SoreLoserUpperHalfPlayer soreUpperPlayer = new SoreLoserUpperHalfPlayer();
                soreUpperPlayer.Name = "Upperclass Sore Loser Larry";

                Console.WriteLine("-------------------");

                List<Player> players = new List<Player>() {
                    smackTalker,
                    oneHigherPlayer,
                    humanPlayer,
                    bigRoller,
                    creativeSmackTalker,
                    soreLoser,
                    upperPlayer,
                    soreUpperPlayer
                };

                PlayMany(players);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("A SoreLoser lost. They... broke the game");
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