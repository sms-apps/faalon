namespace ConsoleGame.Engine.Services
{
    public class DefaultConsoleGameLoopHandler : IConsoleGameLoopHandler
    {
        private DefaultConsoleGameLoopHandler() { }
        public static DefaultConsoleGameLoopHandler Create() => new DefaultConsoleGameLoopHandler();

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

        public void Prerender(IConsoleGameDisplay display)
        {
            //display.Reset();
            //display.Store()
        }

        public void Render(IConsoleGameDisplay display)
        {
            display.WriteContentsOfBuffer();
        }
    }
}
