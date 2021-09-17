namespace ConsoleGame.Engine
{
    public class Game
    {
        private static IConsoleGameDisplay _display;
        private static IConsoleGameLoopHandler _gameLoopHandler;
        private static readonly System.Timers.Timer _gameLoopTimer = new System.Timers.Timer(Constants.DefaultTimerCallbackIntervalWaitMs);
        private static Task _userInputTask;
        private static bool _started = false;

        public Game(IConsoleGameDisplay display, IConsoleGameLoopHandler gameLoopHandler)
        {
            _display = display;
            _gameLoopHandler = gameLoopHandler;
        }

        /// <summary> Main game loop. </summary>
        public virtual void Loop(object? sender, System.Timers.ElapsedEventArgs e)
        {
            Prerender();
            Render();
        }


        public Action Prerender = () =>
        {
            _display.Reset();
            //_display.Store()
        };

        public Action Render = () =>
        {
            _display.Write();
        };

        /// <summary> Start the <see cref="Game"/>. </summary>
        public void Start()
        {
            //_display.WriteChar

            _started = true;
            _userInputTask = Task.Factory.StartNew(() => _gameLoopHandler.HandleUserInput());
            _gameLoopTimer.Elapsed += Loop;
            _gameLoopTimer.AutoReset = true;
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

    }
}