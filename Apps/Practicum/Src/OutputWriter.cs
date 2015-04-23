using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Practicum.Entities;

namespace Practicum
{
    public class OutputWriter : IOutputWriter
    {
        /// <summary>
        /// 
        /// </summary>
        public void WriteOutput()
        {
            var meal = Meal;
            var dishesString = ComputeDishesString(meal.Dishes, meal.HasError);
            var message = string.Format("Output: {0}", dishesString);
            Console.WriteLine(message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dishes"></param>
        /// <param name="hasError"></param>
        /// <returns></returns>
        public static string ComputeDishesString(List<Dish> dishes, bool hasError = false)
        {
            dishes.Sort();
            var stringBuilder = new StringBuilder();
            var i = 0;
            foreach (var dish in dishes)
            {
                if (i > 0)
                {
                    stringBuilder.Append(", ");
                }
                stringBuilder.Append(dish.DishValue.ToString().ToLowerInvariant());
                if (dish.Count > 1)
                {
                    stringBuilder.Append(string.Format("(x{0})", dish.Count));
                }
                i++;
            }
            var dishesString = stringBuilder.ToString();
            if (hasError)
            {
                if (!string.IsNullOrEmpty(dishesString))
                {
                    stringBuilder.Append(", ");
                }
                stringBuilder.Append("error");
                dishesString = stringBuilder.ToString();
            }
            return dishesString;
        }

        private static IMeal Meal
        {
            get
            {
                var meal = ContainerManager.Container.Resolve<IMeal>();
                if (meal == null)
                {
                    throw new InvalidOperationException("Cannot Resolve IMeal.");
                }
                return meal;
            }
        }
    }
}
