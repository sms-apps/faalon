// See https://aka.ms/new-console-template for more information
using ConsoleGame.Engine;
using ConsoleGame.Engine.Services;

//var myGame = new MyGame(new ConsoleGame.Engine.DisplaySettings { Width = 50, Height = 25 }, ConsoleGameDisplay.Create( );
var display = DefaultConsoleGameDisplay.Create(new DisplaySettings(25, 50));
var gameLoopHandler = DefaultConsoleGameLoopHandler.Create(display);

var myGame = new MyGame(display, gameLoopHandler);
myGame.Start();

//Console.WriteLine("Hello, World!");
