﻿namespace ConsoleGame.Engine
{
    public interface IConsoleGameLoopHandler
    {
        /// <summary> Happens when the user inputs an instruction (key, etc). </summary>
        void HandleUserInput();

        /// <summary> Handles any world changes. </summary>
        void Prerender(IConsoleGameDisplay display);

        /// <summary> Render whatever is in the display buffer to the screen. </summary>
        void Render(IConsoleGameDisplay display);
    }
}
