using ConsoleGame.Engine.Services;

namespace ConsoleGame.Engine
{
    public class Game
    {
        #region properties & construction

        private static IConsoleGameDisplay _display;
        private static readonly System.Timers.Timer _gameLoopTimer = new System.Timers.Timer(Constants.DefaultTimerCallbackIntervalWaitMs);
        private static Task _userInputTask;
        private static bool _started = false;

        public Game(IConsoleGameDisplay display)
        {
            _display = display;
            _gameLoopTimer.Elapsed += TimerElapsed;
            _gameLoopTimer.AutoReset = true;

        }

        public Game(DisplaySettings settings)
        {
            _display = DefaultConsoleGameDisplay.Create(settings, DefaultConsoleGameScreenBuffer.Create(settings));
            _gameLoopTimer.Elapsed += TimerElapsed;
            _gameLoopTimer.AutoReset = true;
        }

        #endregion

        public Action Prerender = () => { _display.Reset(); };
        public Action Render = () => { _display.WriteContentsOfBuffer(); };
        public Action HandlerUserInput = () =>
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
        };

        /// <summary> Start the <see cref="Game"/>. </summary>
        public void Start()
        {
            _started = true;
            _userInputTask = Task.Factory.StartNew(() => HandlerUserInput);
            _gameLoopTimer.Start();

            // do nothing while we're waiting for input
            while (_started) { }

            Stop();
        }

        /// <summary> Stop the <see cref="Game"/>. </summary>
        public static void Stop()
        {
            _started = false;
            _gameLoopTimer.Stop();
            _gameLoopTimer.Dispose();
            _userInputTask.Dispose();
        }


        #region internal game functionality

        private void TimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Prerender();
            Render();
        }

        #endregion

    }
}