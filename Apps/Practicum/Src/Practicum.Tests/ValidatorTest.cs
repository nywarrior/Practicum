using System;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practicum.Entities;
using Practicum.Exceptions;

namespace Practicum.UnitTests
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class ValidatorTest
    {
        private readonly IValidator _validator;

        /// <summary>
        /// 
        /// </summary>
        public ValidatorTest()
        {
            _validator = ContainerManager.Container.Resolve<IValidator>();
            if (_validator == null)
            {
                throw new InvalidOperationException("Cannot Resolve IValidator.");
            } 
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidMealTimeException))]
        public void TestValidateMeal1()
        {
            // var meal = ContainerManager.Container.Resolve<IMeal>();
            var meal = _validator.Meal;
            meal.Clear();
            _validator.ValidateMeal();
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidDishesException))]
        public void TestValidateMeal2()
        {
            // TODO: Figure out why this returns a different Container instance.
            // var meal = ContainerManager.Container.Resolve<IMeal>();
            var meal = _validator.Meal;
            meal.Clear();
            meal.MealTime = MealTime.Morning;
            _validator.ValidateMeal();
        }
    }
}
