using System;
using System.Collections.Generic;

namespace Practicum.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Meal : IMeal
    {
        public MealTime MealTime { get; set; }
        public List<Dish> Dishes { get; private set; }
        public bool HasError { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Meal()
        {
            MealTime = MealTime.None;
            Dishes = new List<Dish>();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear()
        {
            Dishes.Clear();
            MealTime = MealTime.None;
            HasError = false;
        }

        // Override the ToString method:
        public override string ToString()
        {
            return (String.Format("({0},{1})", MealTime, Dishes));
        }
    }
}
