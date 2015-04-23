using System;

namespace Practicum.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class InvalidDishesException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        public InvalidDishesException(string message)
            : base(message)
        {
        }
    }
}
