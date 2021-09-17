namespace ConsoleGame.Engine.Services
{
    public class DefaultConsoleGameLoopHandler : IConsoleGameLoopHandler
    {
        private readonly IConsoleGameDisplay _display;

        private DefaultConsoleGameLoopHandler(IConsoleGameDisplay display)
        {
            _display = display;
        }

        public static DefaultConsoleGameLoopHandler Create(IConsoleGameDisplay display)
        {
            if (display == null) throw new ArgumentNullException(nameof(display));
            return new DefaultConsoleGameLoopHandler(display);
        }

        public void HandleUserInput()
        {
            while (true)
            {
                var Key = Console.ReadKey().Key;

                switch (Key)
                {
                    case ConsoleKey.UpArrow:
                    case ConsoleKey.W:
                        break;

                    case ConsoleKey.LeftArrow:
                    case ConsoleKey.A:
                        break;

                    case ConsoleKey.DownArrow:
                    case ConsoleKey.S:
                        break;

                    case ConsoleKey.RightArrow:
                    case ConsoleKey.D:
                        break;

                    case ConsoleKey.Escape:
                        Environment.Exit(-1);
                        break;
                }
            }
        }

        public void HandleWorldChanges()
        {
            // todo - any world changes due to game or user input here
        }

        public void Render()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(_display.Buffer());
        }
    }
}
