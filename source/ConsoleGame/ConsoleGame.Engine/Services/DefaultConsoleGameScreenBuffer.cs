using ConsoleGame.Engine.Core;
using System.Text;

namespace ConsoleGame.Engine.Services
{
    public class DefaultConsoleGameScreenBuffer : IScreenBuffer
    {
        #region properties

        private static Dictionary<SimplePoint, char> _locations = new Dictionary<SimplePoint, char>();
        private static DisplaySettings _displaySettings;

        #endregion

        #region construction

        private DefaultConsoleGameScreenBuffer(DisplaySettings settings) => 
            _displaySettings = settings;

        public static DefaultConsoleGameScreenBuffer Create(DisplaySettings settings) => 
            new(settings);

        public void Clear()
        {
            _locations.Clear();
        }

        public string Retrieve()
        {
            StringBuilder result = new();

            for(int x = 0; x < _displaySettings.Width; x++)
            {
                for(int y = 0; y < _displaySettings.Height; y++)
                {
                    result.Append(
                        _locations.ContainsKey(new SimplePoint(x, y))
                            ? _locations[new SimplePoint(x, y)]
                            : _displaySettings.Background
                    );
                }
            }

            return result.ToString();
        }

        public void Store(char input, SimplePoint point)
        {
            _locations.Add(point, input);
        }

        public void Store(string input, SimplePoint point)
        {
            int x = point.X;
            input.ToCharArray().ToList().ForEach(c => Store(c, new SimplePoint(x++, point.Y)));
        }

        #endregion
    }
}
