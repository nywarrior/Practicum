using System.Collections.Generic;

namespace Practicum.Entities
{
    public interface IMeal
    {
        MealTime MealTime { get; set; }
        List<Dish> Dishes { get; }
        bool HasError { get; set; }
        void Clear();
    }
}
