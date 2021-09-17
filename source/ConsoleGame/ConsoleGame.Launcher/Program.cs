using ConsoleGame.Engine;
using ConsoleGame.Engine.Services;

var game = new Game(
    DefaultConsoleGameDisplay.Create(new DisplaySettings(25, 50, ' ')),
    DefaultConsoleGameLoopHandler.Create()
);

// overwrite one of the game methods with a nice lambda
// game.Prerender = () => {  };

game.Start();



