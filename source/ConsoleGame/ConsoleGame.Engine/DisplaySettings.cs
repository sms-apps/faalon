namespace ConsoleGame.Engine
{
    public struct DisplaySettings
    {
        public int Height {  get; set; }
        public int Width { get; set; }

        public DisplaySettings(int height, int width) : this()
        {
            Height = height;
            Width = width;
        }

    }
}
