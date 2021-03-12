using System;

namespace ShootingDice
{
    // A player that prompts the user to enter a number for a roll
    public class HumanPlayer : Player
    {
        public override void Play(Player other)
        {
            // Call roll for "this" object and for the "other" object
            int myRoll = -1;
            while (myRoll < 0)
            {
                Console.WriteLine("Please enter a number");
                string stringRoll = Console.ReadLine();
                bool tryConvert = int.TryParse(stringRoll, out myRoll);
                if (!tryConvert)
                {
                    myRoll = -1;
                }
                Console.WriteLine();
            }
            int otherRoll = other.Roll();

            Console.WriteLine($"You roll a {myRoll}");
            Console.WriteLine($"{other.Name} rolls a {otherRoll}");
            if (myRoll > otherRoll)
            {
                Console.WriteLine($"You Win!");
            }
            else if (myRoll < otherRoll)
            {
                Console.WriteLine($"{other.Name} Wins!");
            }
            else
            {
                // if the rolls are equal it's a tie
                Console.WriteLine("It's a tie");
            }
        }
    }
}