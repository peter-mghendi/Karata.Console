using System;

namespace Karata.Utils
{
    static class InputUtils 
    {
        public static uint ReadUnsignedInt
        (
            string prompt = "Enter a UInt32: ",
            string errorPrompt = "ERROR! Invalid Value. Try again: ",  
            uint min = uint.MinValue,
            uint max = uint.MaxValue, 
            bool error = false
        ) {
            Console.Write(error? errorPrompt: prompt);
            return (!uint.TryParse(Console.ReadLine(), out uint output) || output < min || output > max) 
                ? ReadUnsignedInt(prompt, errorPrompt, min, max, true)
                : output;
        }
    }
}