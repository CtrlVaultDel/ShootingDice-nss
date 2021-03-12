using System;

namespace ShootingDice
{
    // A Player who shouts a taunt every time they roll dice
    public class SmackTalkingPlayer : Player
    {
        public override void Play(Player other)
        {
            Console.WriteLine($"{this.Name} says: Everyone has dreams, mine is to CRUSH YOURS.");
            base.Play(other);
        }
    }
}