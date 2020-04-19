using System.Collections.Generic;
using System;

namespace Karata.Utils
{
    static class InputUtils 
    {
        private const string defaultErrorPrompt = "ERROR! Invalid Value. Try again: ";
        private static string[] defaultSpecialChars = {"#"};

        public static int ReadSignedInt
        (
            string prompt = "Enter an Int32: ",
            string errorPrompt = defaultErrorPrompt,  
            int min = int.MinValue,
            int max = int.MaxValue, 
            bool error = false
        ) 
        {
            Console.Write(error? errorPrompt: prompt);
            return (!int.TryParse(Console.ReadLine(), out int output) || output < min || output > max) 
                ? ReadSignedInt(prompt, errorPrompt, min, max, true)
                : output;
        }

        public static uint ReadUnsignedInt
        (
            string prompt = "Enter a UInt32: ",
            string errorPrompt = defaultErrorPrompt,  
            uint min = uint.MinValue,
            uint max = uint.MaxValue, 
            bool error = false
        ) 
        {
            Console.Write(error? errorPrompt: prompt);
            return (!uint.TryParse(Console.ReadLine(), out uint output) || output < min || output > max) 
                ? ReadUnsignedInt(prompt, errorPrompt, min, max, true)
                : output;
        }

        public static List<string> ReadPlayString
        (
            string prompt = "Enter a play string: ",
            string errorPrompt = defaultErrorPrompt,
            uint max = uint.MaxValue,
            string[] endChars = null,
            List<string> playString = null,
            bool error = false
        )
        {
            Console.Write(error? errorPrompt: prompt);
            string input = Console.ReadLine().Trim();
            _ = playString ??= new List<string>();

            if(input.Equals("")) return playString;

            playString.Add(input);

            if (Array.Exists(endChars ??= defaultSpecialChars, x => x == input)) 
                return playString;

            if (uint.TryParse(input, out uint temp) && temp <= max)
                return ReadPlayString(prompt, errorPrompt, max, endChars, playString, false);

            return ReadPlayString(prompt, errorPrompt, max, endChars, playString, true);
        }
    }
}