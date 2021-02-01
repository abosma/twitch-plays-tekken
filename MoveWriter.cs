using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TwitchPlaysGames
{
    public static class MoveWriter
    {
        private static readonly List<string> ValidInputs = new List<string>
        {
            "df",
            "db",
            "uf",
            "ub",
            "u",
            "d",
            "f",
            "b",
            "1+3",
            "2+4",
            "1+4",
            "2+3",
            "1",
            "2",
            "3",
            "4",
            "accept",
            "decline",
            "ra",
            "n",
            "ki",
            "ssu",
            "ssd",
            "combo1",
            "combo2",
            "combo3",
            "deathfist",
            "demoman",
            "qcf",
            "qcb",
            "cds",
            "rd",
            "ra",
            "ragedrive",
            "rageart",
            "kbd",
            "combo",
            "start",
            "unblockable"
        };

        /// <summary>
        /// Checks if all of the inputs in the chat message are actual inputs.
        /// This is to prevent misuse of the "Last performed move" text on stream.
        /// Don't want people to spam naughty words right
        /// </summary>
        /// <param name="InputList"></param>
        public static void WriteMoveIfValid(List<string> InputList)
        {
            foreach (var Input in InputList)
            {
                // Splits between letters and numbers. This way I can check for ex: df1/2/3/4 all at once, instead of adding all different moves to the list. 
                var Result = Regex.Match(Input, @"([a-zA-Z]+)(\d+)");
                
                var FirstPartInput = Result.Groups[1].Value;
                var SecondPartInput = Result.Groups[2].Value;

                if (FirstPartInput.Length == 0 || SecondPartInput.Length == 0)
                {
                    if (ValidInputs.Contains(Input))
                    {
                        continue;
                    }

                    return;
                }

                if (ValidInputs.Contains(FirstPartInput) && ValidInputs.Contains(SecondPartInput))
                {
                    continue;
                }

                return;
            }

            File.WriteAllText(@"D:\Program Files (x86)\Git Projects\TwitchPlaysGames\inputs.txt", string.Join(",", InputList));
        }
    }
}
