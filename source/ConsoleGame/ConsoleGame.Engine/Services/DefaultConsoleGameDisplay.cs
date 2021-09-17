using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleGame.Engine.Services
{
    public class DefaultConsoleGameDisplay : IConsoleGameDisplay
    {
        private static int Height;
        private static int Width;
        private static char[,] _screenBuffer;

        #region construction

        private DefaultConsoleGameDisplay(DisplaySettings settings)
        {
            Height = settings.Height;
            Width = settings.Width;
            _screenBuffer = new char[Width, Height];

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.CursorVisible = false;
                Console.SetWindowSize(1, 1);
                Console.SetBufferSize(Width, Height);
                Console.SetWindowSize(Width, Height);
            }
        }

        public static DefaultConsoleGameDisplay Create(DisplaySettings settings)
        {
            if (settings.Height < 0) throw new ArgumentOutOfRangeException(nameof(settings.Height));
            if (settings.Width < 0) throw new ArgumentOutOfRangeException(nameof(settings.Width));
            return new DefaultConsoleGameDisplay(settings);
        }

        #endregion construction

        public void Write(char c, int x, int y) => _screenBuffer[x, y] = c;

        public void Clear(char c = default)
        {
            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                    _screenBuffer[j, i] = c;
        }

        public string Buffer()
        {
            var sb = new StringBuilder();

            for (int i = 0; i < Width; i++)
                for (int j = 0; j < Height; j++)
                    sb.Append(_screenBuffer[i, j]);

            return sb.ToString();
        }

        public override string ToString() => Buffer();

        public void Write(string s, int line, int columnStart)
        {
            if (s.Length > Width - columnStart) throw new ArgumentOutOfRangeException(nameof(s));
            for(int i = 0; i < s.Length; i++) Write(s[i], columnStart + i, line);
        }
    }
}
