using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WindowsInput;
using WindowsInput.Native;

namespace TwitchPlaysGames
{
    static class MovePerformer
    {
        private static readonly InputSimulator InputSimulator = new InputSimulator();

        /// <summary>
        /// Performs the list of virtualkeycodes given.
        /// The moves get pressed down at the same time, and released at the same time. (ex: [1,2] will press 1+2 at the same time)
        /// </summary>
        /// <param name="toInputKeys"></param>
        public static void PerformMoves(List<VirtualKeyCode[]> toInputKeys)
        {
            foreach (var InputKey in toInputKeys)
            {
                foreach (var Key in InputKey)
                {
                    InputSimulator.Keyboard.KeyDown(Key);
                }
            }

            InputSimulator.Keyboard.Sleep(16);

            foreach (var InputKey in toInputKeys)
            {
                foreach (var Key in InputKey)
                {
                    InputSimulator.Keyboard.KeyUp(Key);
                }
            }

            Thread.Sleep(83);
        }
    }
}
