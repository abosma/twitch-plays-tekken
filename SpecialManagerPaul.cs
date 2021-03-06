﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WindowsInput;
using WindowsInput.Native;

namespace TwitchPlaysGames
{
    class SpecialManagerPaul
    {
        /// TODO: Add SWU (sidewalk up) and SWD (sidewalk down). Also add ducking. Probably ducks for 30 frames (501 frames) so people can duck attacks.
        public List<string> SpeciaList = new List<string>
        {
            "unblockable",
            "combo1",
            "combo2",
            "combo3",
            "rageart",
            "rage drive",
            "deathfist",
            "demoman",
            "cds",
            "qcf",
            "qcb",
            "kbd",
            "ki",
            "ssu",
            "ssd",
            "start",
            "n",
            "ra",
            "rd",
        };

        /// <summary>
        /// Attempts to perform a special move if the input is part of the list above.
        /// Certain specials also include normal moves (ex: qcf2), in that case the remaining part of the string is returned and given to the MovePerformer.
        /// These are hardcoded values and timings. No way to do it dynamically.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="inputSimulator"></param>
        /// <param name="inputManager"></param>
        /// <returns>Returns the remaining input when appropiate, else returns an empty string.</returns>
        public string AttemptSpecial(string input, InputSimulator inputSimulator, InputManager inputManager)
        {
            string RemainingInput = "";
            string ToPerformSpecial = "";

            List<VirtualKeyCode[]> ForwardInput = inputManager.GetKeyCode("f");
            List<VirtualKeyCode[]> BackInput = inputManager.GetKeyCode("b");
            List<VirtualKeyCode[]> DownInput = inputManager.GetKeyCode("d");
            List<VirtualKeyCode[]> UpInput = inputManager.GetKeyCode("u");

            List<VirtualKeyCode[]> LPInput = inputManager.GetKeyCode("1");
            List<VirtualKeyCode[]> RPInput = inputManager.GetKeyCode("2");
            List<VirtualKeyCode[]> LKInput = inputManager.GetKeyCode("3");
            List<VirtualKeyCode[]> RKInput = inputManager.GetKeyCode("4");

            foreach (var Special in SpeciaList)
            {
                if (input.Contains(Special))
                {
                    RemainingInput = string.Join("",input.Split(Special, StringSplitOptions.RemoveEmptyEntries));
                    ToPerformSpecial = Special;
                    break;
                }

                if (input.Equals(Special))
                {
                    ToPerformSpecial = Special;
                    break;
                }
            }

            if (ToPerformSpecial.Equals("start"))
            {
                var StartInput = inputManager.GetKeyCode("start");

                inputSimulator.Keyboard.KeyDown(StartInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(StartInput[0][0]);

                return "";
            }

            if (ToPerformSpecial.Equals("n"))
            {
                Thread.Sleep(16);

                return RemainingInput;
            }

            if (ToPerformSpecial.Equals("unblockable"))
            {
                inputSimulator.Keyboard.KeyDown(BackInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(BackInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyDown(BackInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(BackInput[0][0]);
                inputSimulator.Keyboard.KeyDown(BackInput[0][0]);
                inputSimulator.Keyboard.KeyDown(LPInput[0][0]);
                inputSimulator.Keyboard.KeyDown(RPInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(BackInput[0][0]);
                inputSimulator.Keyboard.KeyUp(LPInput[0][0]);
                inputSimulator.Keyboard.KeyUp(RPInput[0][0]);

                return "";
            }

            if (ToPerformSpecial.Equals("ki"))
            {
                inputSimulator.Keyboard.KeyDown(LPInput[0][0]);
                inputSimulator.Keyboard.KeyDown(RPInput[0][0]);
                inputSimulator.Keyboard.KeyDown(LKInput[0][0]);
                inputSimulator.Keyboard.KeyDown(RKInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(LPInput[0][0]);
                inputSimulator.Keyboard.KeyUp(RPInput[0][0]);
                inputSimulator.Keyboard.KeyUp(LKInput[0][0]);
                inputSimulator.Keyboard.KeyUp(RKInput[0][0]);

                return "";
            }

            if (ToPerformSpecial.Equals("ssu"))
            {
                inputSimulator.Keyboard.KeyDown(UpInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(UpInput[0][0]);
                inputSimulator.Keyboard.Sleep(66);
                inputSimulator.Keyboard.KeyDown(UpInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(UpInput[0][0]);
                inputSimulator.Keyboard.Sleep(66);
                inputSimulator.Keyboard.KeyDown(BackInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(BackInput[0][0]);

                return RemainingInput;
            }

            if (ToPerformSpecial.Equals("ssd"))
            {
                inputSimulator.Keyboard.KeyDown(DownInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(DownInput[0][0]);
                inputSimulator.Keyboard.Sleep(66);
                inputSimulator.Keyboard.KeyDown(DownInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(DownInput[0][0]);
                inputSimulator.Keyboard.Sleep(66);
                inputSimulator.Keyboard.KeyDown(BackInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(BackInput[0][0]);

                Thread.Sleep(16);

                return RemainingInput;
            }

            if (ToPerformSpecial.Equals("combo1"))
            {
                inputSimulator.Keyboard.KeyDown(DownInput[0][0]);
                inputSimulator.Keyboard.KeyDown(ForwardInput[0][0]);
                inputSimulator.Keyboard.KeyDown(RPInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(DownInput[0][0]);
                inputSimulator.Keyboard.KeyUp(ForwardInput[0][0]);
                inputSimulator.Keyboard.KeyUp(RPInput[0][0]);
                inputSimulator.Keyboard.Sleep(600);
                inputSimulator.Keyboard.KeyDown(LKInput[0][0]);
                inputSimulator.Keyboard.Sleep(100);
                inputSimulator.Keyboard.KeyUp(LKInput[0][0]);
                inputSimulator.Keyboard.KeyDown(RPInput[0][0]);
                inputSimulator.Keyboard.Sleep(33);
                inputSimulator.Keyboard.KeyUp(RPInput[0][0]);
                inputSimulator.Keyboard.Sleep(533);
                inputSimulator.Keyboard.KeyDown(BackInput[0][0]);
                inputSimulator.Keyboard.Sleep(300);
                inputSimulator.Keyboard.KeyDown(RKInput[0][0]);
                inputSimulator.Keyboard.Sleep(33);
                inputSimulator.Keyboard.KeyUp(RKInput[0][0]);
                inputSimulator.Keyboard.KeyUp(BackInput[0][0]);
                inputSimulator.Keyboard.Sleep(766);
                inputSimulator.Keyboard.KeyDown(ForwardInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(ForwardInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyDown(ForwardInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(ForwardInput[0][0]);
                inputSimulator.Keyboard.Sleep(300);
                inputSimulator.Keyboard.KeyDown(DownInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyDown(ForwardInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(DownInput[0][0]);
                inputSimulator.Keyboard.KeyDown(RPInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(RPInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(ForwardInput[0][0]);

                Thread.Sleep(16);

                return "";
            }

            if (ToPerformSpecial.Equals("combo2"))
            {
                inputSimulator.Keyboard.KeyDown(UpInput[0][0]);
                inputSimulator.Keyboard.KeyDown(ForwardInput[0][0]);
                inputSimulator.Keyboard.KeyDown(LKInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(UpInput[0][0]);
                inputSimulator.Keyboard.KeyUp(ForwardInput[0][0]);
                inputSimulator.Keyboard.KeyUp(LKInput[0][0]);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyDown(RKInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(RKInput[0][0]);
                inputSimulator.Keyboard.Sleep(700);
                inputSimulator.Keyboard.KeyDown(LKInput[0][0]);
                inputSimulator.Keyboard.Sleep(100);
                inputSimulator.Keyboard.KeyUp(LKInput[0][0]);
                inputSimulator.Keyboard.KeyDown(RPInput[0][0]);
                inputSimulator.Keyboard.Sleep(33);
                inputSimulator.Keyboard.KeyUp(RPInput[0][0]);
                inputSimulator.Keyboard.Sleep(533);
                inputSimulator.Keyboard.KeyDown(BackInput[0][0]);
                inputSimulator.Keyboard.Sleep(300);
                inputSimulator.Keyboard.KeyDown(RKInput[0][0]);
                inputSimulator.Keyboard.Sleep(33);
                inputSimulator.Keyboard.KeyUp(RKInput[0][0]);
                inputSimulator.Keyboard.KeyUp(BackInput[0][0]);
                inputSimulator.Keyboard.Sleep(766);
                inputSimulator.Keyboard.KeyDown(ForwardInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(ForwardInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyDown(ForwardInput[0][0]);
                inputSimulator.Keyboard.Sleep(33);
                inputSimulator.Keyboard.KeyUp(ForwardInput[0][0]);
                inputSimulator.Keyboard.Sleep(300);
                inputSimulator.Keyboard.KeyDown(DownInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyDown(ForwardInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(DownInput[0][0]);
                inputSimulator.Keyboard.KeyDown(RPInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(RPInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(ForwardInput[0][0]);

                Thread.Sleep(16);

                return "";
            }

            if (ToPerformSpecial.Equals("combo3"))
            {
                inputSimulator.Keyboard.KeyDown(DownInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyDown(ForwardInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(DownInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyDown(LPInput[0][0]);
                inputSimulator.Keyboard.KeyUp(ForwardInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(LPInput[0][0]);
                inputSimulator.Keyboard.Sleep(700);
                inputSimulator.Keyboard.KeyDown(LKInput[0][0]);
                inputSimulator.Keyboard.Sleep(100);
                inputSimulator.Keyboard.KeyUp(LKInput[0][0]);
                inputSimulator.Keyboard.KeyDown(RPInput[0][0]);
                inputSimulator.Keyboard.Sleep(33);
                inputSimulator.Keyboard.KeyUp(RPInput[0][0]);
                inputSimulator.Keyboard.Sleep(533);
                inputSimulator.Keyboard.KeyDown(BackInput[0][0]);
                inputSimulator.Keyboard.Sleep(300);
                inputSimulator.Keyboard.KeyDown(RKInput[0][0]);
                inputSimulator.Keyboard.Sleep(33);
                inputSimulator.Keyboard.KeyUp(RKInput[0][0]);
                inputSimulator.Keyboard.KeyUp(BackInput[0][0]);
                inputSimulator.Keyboard.Sleep(766);
                inputSimulator.Keyboard.KeyDown(ForwardInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(ForwardInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyDown(ForwardInput[0][0]);
                inputSimulator.Keyboard.Sleep(33);
                inputSimulator.Keyboard.KeyUp(ForwardInput[0][0]);
                inputSimulator.Keyboard.Sleep(200);
                inputSimulator.Keyboard.KeyDown(DownInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyDown(ForwardInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(DownInput[0][0]);
                inputSimulator.Keyboard.KeyDown(RPInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(RPInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(ForwardInput[0][0]);

                Thread.Sleep(16);

                return "";
            }

            if (ToPerformSpecial.Equals("deathfist"))
            {
                var MoveInput = inputManager.GetKeyCode("2");
                
                inputSimulator.Keyboard.KeyDown(DownInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyDown(ForwardInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(DownInput[0][0]);
                inputSimulator.Keyboard.KeyDown(MoveInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(MoveInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(ForwardInput[0][0]);

                Thread.Sleep(500);

                return "";
            }

            if (ToPerformSpecial.Equals("demoman"))
            {
                inputSimulator.Keyboard.KeyDown(DownInput[0][0]);
                inputSimulator.Keyboard.KeyDown(RKInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(DownInput[0][0]);
                inputSimulator.Keyboard.KeyUp(RKInput[0][0]);
                inputSimulator.Keyboard.Sleep(33);
                inputSimulator.Keyboard.KeyDown(RPInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(RPInput[0][0]);
                inputSimulator.Keyboard.Sleep(500);
                inputSimulator.Keyboard.KeyDown(LPInput[0][0]);
                inputSimulator.Keyboard.KeyDown(RPInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(LPInput[0][0]);
                inputSimulator.Keyboard.KeyUp(RPInput[0][0]);

                Thread.Sleep(500);

                return "";
            }

            if (ToPerformSpecial.Equals("qcf"))
            {
                inputSimulator.Keyboard.KeyDown(DownInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyDown(ForwardInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(DownInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(ForwardInput[0][0]);

                return RemainingInput;
            }

            if (ToPerformSpecial.Equals("qcb"))
            {
                inputSimulator.Keyboard.KeyDown(DownInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyDown(BackInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(DownInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(BackInput[0][0]);

                return RemainingInput;
            }

            if (ToPerformSpecial.Equals("cds"))
            {
                inputSimulator.Keyboard.KeyDown(ForwardInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(ForwardInput[0][0]);
                inputSimulator.Keyboard.Sleep(33);
                inputSimulator.Keyboard.KeyDown(DownInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyDown(ForwardInput[0][0]);

                if (RemainingInput.Length > 0)
                {
                    var ToPerformInputs = inputManager.GetKeyCode(RemainingInput);
                    MovePerformer.PerformMoves(ToPerformInputs);
                    inputSimulator.Keyboard.Sleep(16);
                    inputSimulator.Keyboard.KeyUp(DownInput[0][0]);
                    inputSimulator.Keyboard.Sleep(16);
                    inputSimulator.Keyboard.KeyUp(ForwardInput[0][0]);

                    return "";
                }

                inputSimulator.Keyboard.KeyUp(DownInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(ForwardInput[0][0]);

                Thread.Sleep(66);

                return RemainingInput;
            }

            if (ToPerformSpecial.Equals("ragedrive") || ToPerformSpecial.Equals("rd"))
            {
                inputSimulator.Keyboard.KeyDown(DownInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyDown(ForwardInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(DownInput[0][0]);
                inputSimulator.Keyboard.KeyDown(LPInput[0][0]);
                inputSimulator.Keyboard.KeyDown(RPInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(LPInput[0][0]);
                inputSimulator.Keyboard.KeyUp(RPInput[0][0]);
                inputSimulator.Keyboard.KeyUp(ForwardInput[0][0]);

                Thread.Sleep(650);

                return "";
            }

            if (ToPerformSpecial.Equals("rageart") || ToPerformSpecial.Equals("ra"))
            {
                var RAButton = inputManager.GetKeyCode("ra");

                inputSimulator.Keyboard.KeyDown(RAButton[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(RAButton[0][0]);

                return "";
            }

            if (ToPerformSpecial.Equals("kbd"))
            {
                inputSimulator.Keyboard.KeyDown(BackInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(BackInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyDown(BackInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyDown(DownInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(DownInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(BackInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyDown(BackInput[0][0]);
                inputSimulator.Keyboard.Sleep(16);
                inputSimulator.Keyboard.KeyUp(BackInput[0][0]);

                Thread.Sleep(66);

                return "";
            }

            return input;
        }
    }
}
