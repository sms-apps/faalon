namespace ConsoleGame.Engine
{
    public interface IConsoleGameDisplay
    {
        string Buffer { get; }

        void Clear(char c = default);
        void Reset();
        void Store(char c, int line, int column);
        void Store(string s, int line, int columnStart);
        void Write();

    }
}
