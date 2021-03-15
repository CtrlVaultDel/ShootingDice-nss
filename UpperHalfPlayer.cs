using System;

namespace ShootingDice
{
    // A Player whose role will always be in the upper half of their possible rolls
    public class UpperHalfPlayer : Player
    {
        public override int Roll()
        {
            // Return a random number that falls in the upper half range of the original dice size
            return new Random().Next((DiceSize / 2) + 1, DiceSize + 1);
        }
    }
}