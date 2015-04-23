using Practicum.Entities;

namespace Practicum
{
    /// <summary>
    /// 
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// 
        /// </summary>
        IMeal Meal { get; }

        /// <summary>
        /// 
        /// </summary>
        void ValidateMeal();
    }
}
