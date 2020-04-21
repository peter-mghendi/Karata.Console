namespace Karata.Engine.Models
{
    public enum SuitValues
    {
        Spades = 1,
        Hearts = 2,
        Clubs = 4,
        Diamonds = 8,
        Black = Spades | Clubs, 
        Red = Hearts | Diamonds,
        Any = Black | Red
    }
}