using System;

namespace Practicum.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public struct MealTimeDishType
    {
        public readonly MealTime MealTime;
        public readonly DishType DishType;

        // Constructor:
        public MealTimeDishType(MealTime mealTime, DishType dishType)
        {
            MealTime = mealTime;
            DishType = dishType;
        }

        // Override the ToString method:
        public override string ToString()
        {
            return (String.Format("({0},{1})", MealTime, DishType));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(Object obj)
        {
            return obj is MealTimeDishType && this == (MealTimeDishType)obj;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return MealTime.GetHashCode() ^ DishType.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator ==(MealTimeDishType x, MealTimeDishType y)
        {
            return x.MealTime == y.MealTime && x.DishType == y.DishType;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(MealTimeDishType x, MealTimeDishType y)
        {
            return !(x == y);
        }
    }
}
