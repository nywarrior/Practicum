using System;

namespace Practicum.Entities.Exceptions
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
