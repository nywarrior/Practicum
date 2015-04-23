using System;
using System.Collections.Generic;

namespace Practicum.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class Dish : IComparable<Dish>
    {
        private readonly IList<DishType> _sortedDishTypes = new List<DishType> { DishType.Entree, DishType.Side, DishType.Drink, DishType.Dessert };
        /// <summary>
        /// 
        /// </summary>
        public DishType DishType { get; set; }
        public DishValue DishValue { get; set; }
        public int Count { get; set; }

        public Dish()
        {
            Count = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Dish other)
        {
            var result = _sortedDishTypes.IndexOf(DishType).CompareTo(_sortedDishTypes.IndexOf(other.DishType));
            return result;
        }

        // Override the ToString method:
        public override string ToString()
        {
            return (String.Format("({0},{1})", DishType, DishValue));
        }
    }
}
