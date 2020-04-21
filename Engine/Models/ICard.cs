namespace Karata.Engine.Models
{
    interface ICard: ISuit
    {
        public FaceValues FaceValue { get; set; }

        public string ToString(); // TODO Unnecessary?
    }
}