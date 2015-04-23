using System;
using System.Linq;
using Autofac;
using Practicum.Entities;
using Practicum.Entities.Exceptions;

namespace Practicum.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class Validator : IValidator
    {

        /// <summary>
        /// 
        /// </summary>
        public void ValidateMeal()
        {
            var meal = Meal;
            ValidateMealTime(meal.MealTime);
            ValidateDishes();
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

        private void ValidateDishes()
        {
            var meal = Meal;
            if ((!meal.HasError) && (!meal.Dishes.Any()))
            {
                var message = string.Format("Meals must have at least 1 valid dish.");
                throw new InvalidDishesException(message);
            }
        }

        private static void ValidateMealTime(MealTime mealTime)
        {
            if (mealTime == MealTime.None)
            {
                var message = string.Format("Invalid Meal Time: {0}", mealTime);
                throw new InvalidMealTimeException(message);
            }
        }
    }
}
