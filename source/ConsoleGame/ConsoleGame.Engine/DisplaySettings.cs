namespace ConsoleGame.Engine
{
    public struct DisplaySettings
    {
        public int Height {  get; set; }
        public int Width { get; set; }
        public char Background { get; set; }

        public DisplaySettings(int height, int width, char background) : this()
        {
            Height = height;
            Width = width;
            Background = background;
        }
    }
}
