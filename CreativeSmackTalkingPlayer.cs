using System;
using System.Collections.Generic;

namespace ShootingDice
{
    // A SmackTalkingPlayer who randomly selects a taunt from a list to say to the other player
    public class CreativeSmackTalkingPlayer : Player
    {
        public string Taunt { get; set; }
        public List<string> Taunts = new List<string>(){
            "This is gonna hurt!",
            "Good luck, you're going to need it!",
            "Everyone has dreams, mine is to CRUSH YOU!"
        };
        public override void Play(Player other)
        {
            Random rnd = new Random();
            int randomTaunt = rnd.Next(0, 3);
            Taunt = Taunts[randomTaunt];

            Console.WriteLine($"{Name} says: {Taunt}");
            base.Play(other);
        }
    }
}