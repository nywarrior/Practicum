using System.Collections.Generic;
using Practicum.Entities;

namespace Practicum.Components
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOutputWriter
    {
        /// <summary>
        /// 
        /// </summary>
        void WriteOutput();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dishes"></param>
        /// <param name="hasError"></param>
        /// <returns></returns>
        string ComputeDishesString(List<Dish> dishes, bool hasError = false);
    }
}
