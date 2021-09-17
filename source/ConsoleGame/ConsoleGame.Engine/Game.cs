using ConsoleGame.Engine.Services;

namespace ConsoleGame.Engine
{
    public class Game
    {
        #region properties & construction

        private static IConsoleGameDisplay _display;
        private static readonly System.Timers.Timer _gameLoopTimer = new System.Timers.Timer(Constants.DefaultTimerCallbackIntervalWaitMs);
        private static bool _started = false;

        public Game(IConsoleGameDisplay display)
        {
            _display = display ?? throw new ArgumentNullException(nameof(display));
        }

        public Game(DisplaySettings settings)
        {
            _display = DefaultConsoleGameDisplay.Create(settings, DefaultConsoleGameScreenBuffer.Create(settings));
            if (settings.Character.HasValue) _display.Buffer.Store(settings.Character.Value, new Core.SimplePoint(20, 10));
        }

        #endregion

        public Action Prerender = () => 
        { 
            // todo - who knows
        };

        public Action Render = () => 
        { 
            _display.WriteContentsOfBuffer(); 
        };

        protected virtual void HandleUserInput(ConsoleKey key)
        {
            switch (key)
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
                    Stop();
                    break;
            }
        }

        /// <summary> Start the <see cref="Game"/>. </summary>
        public void Start()
        {
            _started = true;

            _gameLoopTimer.Elapsed += GameLoop_TimerElapsed;
            _gameLoopTimer.AutoReset = true;
            _gameLoopTimer.Start();

            while (_started) HandleUserInput(Console.ReadKey(false).Key);

            _gameLoopTimer.Stop();
            _gameLoopTimer.Dispose();
            Environment.Exit(0);

        }

        /// <summary> Stop the <see cref="Game"/>. </summary>
        public static void Stop()
        {
            _started = false;
        }


        #region internal game functionality

        private void GameLoop_TimerElapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Prerender();
            Render();
        }

        #endregion

    }
}