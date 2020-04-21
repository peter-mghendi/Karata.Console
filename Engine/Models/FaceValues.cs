namespace Karata.Engine.Models
{
    // TODO Function to automatically assign these
    // TODO Find a way to have dynamic facevalues
    public enum FaceValues
    {
        Ace = 1,
        Two = 2, 
        Three = 4,
        Four = 8,
        Five = 16,
        Six = 32,
        Seven = 64,
        Eight = 128,
        Nine = 256,
        Ten = 512,
        Jester = 1024,
        Queen = 2048,
        King = 4196,
        Joker = 8192,
        Any = Ace | Two | Three | Four | Five | Six | Seven | Eight | Nine | Ten | Jester | Queen | King | Joker
    }
}