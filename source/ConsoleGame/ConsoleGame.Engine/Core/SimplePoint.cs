namespace ConsoleGame.Engine.Core
{
    public struct SimplePoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public SimplePoint(int x, int y) : this()
        {
            X = x;
            Y = y;
        }
    }
}
