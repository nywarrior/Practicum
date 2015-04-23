﻿using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practicum.Entities;

namespace Practicum.UnitTests
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class OutputWriterTest
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestComputeDishesString1()
        {
            var dishes = new List<Dish>
            {
                new Dish{DishType=DishType.Entree,DishValue=DishValue.Eggs },
                new Dish{DishType=DishType.Side,DishValue=DishValue.Toast },
                new Dish{DishType=DishType.Drink,DishValue=DishValue.Coffee }
            };
            var dishesOutputString = OutputWriter.ComputeDishesString(dishes);
            Assert.AreEqual("eggs, toast, coffee", dishesOutputString);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestComputeDishesString2()
        {
            var dishes = new List<Dish>
            {
                new Dish{DishType=DishType.Entree,DishValue=DishValue.Eggs },
                new Dish{DishType=DishType.Side,DishValue=DishValue.Toast },
                new Dish{DishType=DishType.Drink,DishValue=DishValue.Coffee }
            };
            var dishesOutputString = OutputWriter.ComputeDishesString(dishes, hasError: true);
            Assert.AreEqual("eggs, toast, coffee, error", dishesOutputString);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestComputeDishesString3()
        {
            var dishes = new List<Dish>
            {
                new Dish{DishType=DishType.Entree,DishValue=DishValue.Steak },
                new Dish{DishType=DishType.Side,DishValue=DishValue.Potato,Count=2 },
                new Dish{DishType=DishType.Dessert,DishValue=DishValue.Cake }
            };
            var dishesOutputString = OutputWriter.ComputeDishesString(dishes);
            Assert.AreEqual("steak, potato(x2), cake", dishesOutputString);
        }
    }
}
