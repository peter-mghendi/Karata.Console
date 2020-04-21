namespace Karata.Engine.Models
{
    interface ISuit
    {
        public SuitValues SuitValue { get; set; }
        public SuitColors SuitColor { get; }
    }
}