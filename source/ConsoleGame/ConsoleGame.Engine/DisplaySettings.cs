namespace ConsoleGame.Engine
{
    public struct DisplaySettings
    {
        public int Height {  get; set; }
        public int Width { get; set; }
        public char Background { get; set; }
        public char? Character { get; set; }

        public DisplaySettings(int height, int width, char background, char? character = null)
            : this()
        {
            if (height < 0) throw new ArgumentOutOfRangeException(nameof(height));
            if (width < 0) throw new ArgumentOutOfRangeException(nameof(width));

            Height = height;
            Width = width;
            Background = background;
            Character = character;
        }
    }
}
