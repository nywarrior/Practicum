using System;

namespace Practicum
{
    /// <summary>
    /// 
    /// </summary>
    public class Scanner : IScanner
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string ReadInputLine()
        {
            Console.Write("Input: ");
            var inputLine = Console.ReadLine();
            if (inputLine == null)
            {
                throw new InvalidOperationException("Input Line is Empty.");
            }
            // Convert input line to lower case for case insensitive matching.
            inputLine = inputLine.Trim();
            inputLine = inputLine.ToLowerInvariant();
            return inputLine;
        }
    }
}
