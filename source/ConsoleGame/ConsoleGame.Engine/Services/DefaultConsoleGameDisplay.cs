using System.Drawing;
using System.Runtime.InteropServices;

namespace ConsoleGame.Engine.Services
{
    public class DefaultConsoleGameDisplay : IConsoleGameDisplay
    {
        private static IScreenBuffer _buffer;
        private static int Height;
        private static int Width;

        #region construction

        private DefaultConsoleGameDisplay(DisplaySettings settings, IScreenBuffer buffer)
        {
            _buffer = buffer;
            Height = settings.Height;
            Width = settings.Width;

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

        public static DefaultConsoleGameDisplay Create(DisplaySettings settings, IScreenBuffer buffer)
        {
            if (settings.Height < 0) throw new ArgumentOutOfRangeException(nameof(settings.Height));
            if (settings.Width < 0) throw new ArgumentOutOfRangeException(nameof(settings.Width));
            if (buffer == null) throw new ArgumentNullException(nameof(buffer));
            return new DefaultConsoleGameDisplay(settings, buffer);
        }

        #endregion construction

        public string Buffer => _buffer.Retrieve();

        public void Clear()
        {
            Console.Clear();
        }

        public void WriteContentsOfBuffer(bool clearBuffer = false)
        {
            Console.Write(_buffer.Retrieve());
            if (clearBuffer) _buffer.Clear();
        }

        public void Reset()
        {
            Clear();
            Console.SetCursorPosition(0, 0);
        }

        public void Write(char c, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }

        public void Write(string s, int line, int columnStart)
        {
            for(int i = 0; i < s.Length; i++) Write(s[i], columnStart + i, line);
        }

    }
}
