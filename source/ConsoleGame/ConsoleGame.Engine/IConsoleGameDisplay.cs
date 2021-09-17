namespace ConsoleGame.Engine
{
    public interface IConsoleGameDisplay
    {
        string Buffer();
        void Write(char c, int line, int column);
        void Write(string s, int line, int columnStart);
    }
}
