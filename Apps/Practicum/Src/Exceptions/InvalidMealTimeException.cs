using System;

namespace Practicum.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class InvalidMealTimeException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public InvalidMealTimeException(string message)
            : base(message)
        {
        }
    }
}
