using System;
using System.Linq;
using Autofac;
using Practicum.Entities;
using Practicum.Exceptions;

namespace Practicum
{
    /// <summary>
    /// 
    /// </summary>
    public class Validator : IValidator
    { 
        private readonly IMeal _meal;

        /// <summary>
        /// 
        /// </summary>
        public Validator()
        {
            _meal = ContainerManager.Container.Resolve<IMeal>();
            if (_meal == null)
            {
                throw new InvalidOperationException("Cannot Resolve IMeal.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IMeal Meal
        {
            get { return _meal; }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ValidateMeal()
        {
            ValidateMealTime(_meal.MealTime);
            ValidateDishes();
        }

        private void ValidateDishes()
        {
            if ((!_meal.HasError) && (!_meal.Dishes.Any()))
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
