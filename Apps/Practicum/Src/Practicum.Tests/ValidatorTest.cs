using System;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practicum.Components;
using Practicum.Entities;
using Practicum.Entities.Exceptions;

namespace Practicum.Tests
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class ValidatorTest
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidMealTimeException))]
        public void TestValidateMeal1()
        {
            var meal = Meal;
            meal.Clear();
            var validator = Validator;
            validator.ValidateMeal();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidDishesException))]
        public void TestValidateMeal2()
        {
            var meal = Meal;
            meal.Clear();
            meal.MealTime = MealTime.Morning;
            var validator = Validator;
            validator.ValidateMeal();
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

        private static IValidator Validator
        {
            get
            {
                var validator = ContainerManager.Container.Resolve<IValidator>();
                if (validator == null)
                {
                    throw new InvalidOperationException("Cannot Resolve IValidator.");
                }
                return validator;
            }
        }
    }
}
