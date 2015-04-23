using System;
using Autofac;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practicum.Components;
using Practicum.Entities;

namespace Practicum.Tests
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class ParserTest
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestParseMeal1()
        {
            const string inputLine = "morning,1,2,3";
            var parser = Parser;
            var meal = parser.ParseMeal(inputLine);
            var meal2 = ContainerManager.Container.Resolve<IMeal>();
            Assert.AreEqual(meal, meal2);
            Assert.AreEqual(MealTime.Morning, meal.MealTime);
            Assert.AreEqual(3, meal.Dishes.Count);
            var dish = meal.Dishes[0];
            Assert.AreEqual(DishType.Entree, dish.DishType);
            Assert.AreEqual(DishValue.Eggs, dish.DishValue);
            Assert.AreEqual(1, dish.Count); 
            dish = meal.Dishes[1];
            Assert.AreEqual(DishType.Side, dish.DishType);
            Assert.AreEqual(DishValue.Toast, dish.DishValue);
            Assert.AreEqual(1, dish.Count); 
            dish = meal.Dishes[2];
            Assert.AreEqual(DishType.Drink, dish.DishType);
            Assert.AreEqual(DishValue.Coffee, dish.DishValue);
            Assert.AreEqual(1, dish.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestParseMeal2()
        {
            const string inputLine = "morning, 2, 1, 3";
            var parser = Parser;
            var meal = parser.ParseMeal(inputLine);
            Assert.AreEqual(MealTime.Morning, meal.MealTime);
            Assert.AreEqual(3, meal.Dishes.Count);
            var dish = meal.Dishes[0];
            Assert.AreEqual(DishType.Entree, dish.DishType);
            Assert.AreEqual(DishValue.Eggs, dish.DishValue);
            Assert.AreEqual(1, dish.Count);
            dish = meal.Dishes[1];
            Assert.AreEqual(DishType.Side, dish.DishType);
            Assert.AreEqual(DishValue.Toast, dish.DishValue);
            Assert.AreEqual(1, dish.Count);
            dish = meal.Dishes[2];
            Assert.AreEqual(DishType.Drink, dish.DishType);
            Assert.AreEqual(DishValue.Coffee, dish.DishValue);
            Assert.AreEqual(1, dish.Count);
        }
        
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestParseMeal3()
        {
            const string inputLine = "morning, 1, 2, 3, 4";
            var parser = Parser;
            var meal = parser.ParseMeal(inputLine);
            Assert.AreEqual(MealTime.Morning, meal.MealTime);
            Assert.AreEqual(3, meal.Dishes.Count);
            var dish = meal.Dishes[0];
            Assert.AreEqual(DishType.Entree, dish.DishType);
            Assert.AreEqual(DishValue.Eggs, dish.DishValue);
            Assert.AreEqual(1, dish.Count);
            dish = meal.Dishes[1];
            Assert.AreEqual(DishType.Side, dish.DishType);
            Assert.AreEqual(DishValue.Toast, dish.DishValue);
            Assert.AreEqual(1, dish.Count);
            dish = meal.Dishes[2];
            Assert.AreEqual(DishType.Drink, dish.DishType);
            Assert.AreEqual(DishValue.Coffee, dish.DishValue);
            Assert.AreEqual(1, dish.Count);
            Assert.IsTrue(meal.HasError);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestParseMeal5()
        {
            const string inputLine = "night, 1, 2, 3, 4";
            var parser = Parser;
            var meal = parser.ParseMeal(inputLine);
            Assert.AreEqual(MealTime.Night, meal.MealTime);
            Assert.AreEqual(meal.Dishes.Count, 4);
            var dish = meal.Dishes[0];
            Assert.AreEqual(DishType.Entree, dish.DishType);
            Assert.AreEqual(DishValue.Steak, dish.DishValue);
            Assert.AreEqual(1, dish.Count);
            dish = meal.Dishes[1];
            Assert.AreEqual(DishType.Side, dish.DishType);
            Assert.AreEqual(DishValue.Potato, dish.DishValue);
            Assert.AreEqual(1, dish.Count);
            dish = meal.Dishes[2];
            Assert.AreEqual(DishType.Drink, dish.DishType);
            Assert.AreEqual(DishValue.Wine, dish.DishValue);
            Assert.AreEqual(1, dish.Count);
            dish = meal.Dishes[3];
            Assert.AreEqual(DishType.Dessert, dish.DishType);
            Assert.AreEqual(DishValue.Cake, dish.DishValue);
            Assert.AreEqual(1, dish.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestParseMeal6()
        {
            const string inputLine = "night, 1, 2, 2, 4";
            var parser = Parser;
            var meal = parser.ParseMeal(inputLine);
            Assert.AreEqual(MealTime.Night, meal.MealTime);
            Assert.AreEqual(3, meal.Dishes.Count);
            var dish = meal.Dishes[0];
            Assert.AreEqual(DishType.Entree, dish.DishType);
            Assert.AreEqual(DishValue.Steak, dish.DishValue);
            Assert.AreEqual(1, dish.Count);
            dish = meal.Dishes[1];
            Assert.AreEqual(DishType.Side, dish.DishType);
            Assert.AreEqual(DishValue.Potato, dish.DishValue);
            Assert.AreEqual(2, dish.Count);
            dish = meal.Dishes[2];
            Assert.AreEqual(DishType.Dessert, dish.DishType);
            Assert.AreEqual(DishValue.Cake, dish.DishValue);
            Assert.AreEqual(1, dish.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestParseMeal7()
        {
            const string inputLine = "night, 1, 2, 3, 5";
            var parser = Parser;
            var meal = parser.ParseMeal(inputLine);
            Assert.AreEqual(MealTime.Night, meal.MealTime);
            Assert.AreEqual(3, meal.Dishes.Count);
            var dish = meal.Dishes[0];
            Assert.AreEqual(DishType.Entree, dish.DishType);
            Assert.AreEqual(DishValue.Steak, dish.DishValue);
            Assert.AreEqual(1, dish.Count);
            dish = meal.Dishes[1];
            Assert.AreEqual(DishType.Side, dish.DishType);
            Assert.AreEqual(DishValue.Potato, dish.DishValue);
            Assert.AreEqual(dish.Count, 1);
            dish = meal.Dishes[2];
            Assert.AreEqual(DishType.Drink, dish.DishType);
            Assert.AreEqual(DishValue.Wine, dish.DishValue);
            Assert.AreEqual(1, dish.Count);
             Assert.IsTrue(meal.HasError);
        }
         
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestParseMeal8()
        {
            const string inputLine = "night, 1, 1, 2, 3, 5";
            var parser = Parser;
            var meal = parser.ParseMeal(inputLine);
            Assert.AreEqual(MealTime.Night, meal.MealTime);
            Assert.AreEqual(1, meal.Dishes.Count);
            var dish = meal.Dishes[0];
            Assert.AreEqual(DishType.Entree, dish.DishType);
            Assert.AreEqual(DishValue.Steak, dish.DishValue);
            Assert.AreEqual(1, dish.Count);
            Assert.IsTrue(meal.HasError);
        }

        private static IParser Parser
        {
            get
            {
                var parser = ContainerManager.Container.Resolve<IParser>();
                if (parser == null)
                {
                    throw new InvalidOperationException("Cannot Resolve IParser.");
                }
                return parser;
            }
        }
    }
}
