using Practicum.Entities;

namespace Practicum.Components
{
    /// <summary>
    /// 
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputLine"></param>
        IMeal ParseMeal(string inputLine);
    }
}
