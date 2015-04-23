using System;

namespace Practicum.Entities.Exceptions
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
