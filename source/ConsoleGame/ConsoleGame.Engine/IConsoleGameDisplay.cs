namespace ConsoleGame.Engine
{
    public interface IConsoleGameDisplay
    {
        IScreenBuffer Buffer { get; }
        DisplaySettings Settings { get; }

        void Clear();
        void WriteContentsOfBuffer(bool clearBuffer = false);
        void Reset();
        void Write(char c, int line, int column);
        void Write(string s, int line, int columnStart);

    }
}
