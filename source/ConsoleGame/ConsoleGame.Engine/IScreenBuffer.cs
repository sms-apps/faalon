using ConsoleGame.Engine.Core;

namespace ConsoleGame.Engine
{
    public interface IScreenBuffer
    {
        void Clear();
        
        string Retrieve();
        //char Retrieve(SimplePoint point);
        //string Retrieve(SimplePoint point, int length);

        void Store(char input, SimplePoint point);
        void Store(string input, SimplePoint point);
    }
}
