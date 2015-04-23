using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Practicum.Entities;

namespace Practicum.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class Parser : IParser
    {
        private static readonly IDictionary<DishValue, bool> DishValueAllowMultipleOccurencesDictionary = new Dictionary
            <DishValue, bool>
        {
            {DishValue.Coffee, true},
            {DishValue.Potato, true}
        };

        private static readonly IDictionary<MealTimeDishType, DishValue> MealTimeDishTypeDictionary = new Dictionary
            <MealTimeDishType, DishValue>
        {
            {
                new MealTimeDishType(MealTime.Morning, DishType.Entree), DishValue.Eggs
            },
            {
                new MealTimeDishType(MealTime.Morning, DishType.Side), DishValue.Toast
            },
            {
                new MealTimeDishType(MealTime.Morning, DishType.Drink), DishValue.Coffee
            },
            {
                new MealTimeDishType(MealTime.Night, DishType.Entree), DishValue.Steak
            },
            {
                new MealTimeDishType(MealTime.Night, DishType.Side), DishValue.Potato
            },
            {
                new MealTimeDishType(MealTime.Night, DishType.Drink), DishValue.Wine
            },
            {
                new MealTimeDishType(MealTime.Night, DishType.Dessert), DishValue.Cake
            }
        };

        private const char WordDelimiter = ',';

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputLine"></param>
        public IMeal ParseMeal(string inputLine)
        {
            if (String.IsNullOrEmpty(inputLine))
            {
                throw new InvalidOperationException("Input Line is Empty.");
            }
            var meal = Meal;
            meal.Clear();
            var words = inputLine.Split(WordDelimiter);
            if (!words.Any())
            {
                throw new InvalidOperationException("Input Line is Empty.");
            }
            ParseMealTime(words);
            ParseDishes(words);
            return meal;
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

        private void ParseDishes(IReadOnlyList<string> words)
        {
            var meal = Meal;
            var dishValueDishDictionary = new Dictionary<DishValue, Dish>();
            for (var i = 1; i < words.Count; i++)
            {
                var word = words[i];
                var dishType = ParseDishType(word);
                if (dishType == DishType.None)
                {
                    continue;
                }
                var dishValue = GetDishValue(meal.MealTime, dishType);
                if (dishValue == DishValue.None)
                {
                    meal.HasError = true;
                    break;
                }
                if (dishValueDishDictionary.ContainsKey(dishValue))
                {
                    var dish = dishValueDishDictionary[dishValue];
                    if (!(DishValueAllowMultipleOccurencesDictionary.ContainsKey(dishValue) && DishValueAllowMultipleOccurencesDictionary[dishValue]))
                    {
                        meal.HasError = true;
                        break;
                    }
                    dish.Count += 1;
                }
                else
                {
                    var dish = new Dish { DishType = dishType, DishValue = dishValue };
                    dishValueDishDictionary[dishValue] = dish;
                }
            }
            meal.Dishes.Clear();
            foreach (var dish in dishValueDishDictionary.Values)
            {
                meal.Dishes.Add(dish);
            } 
            meal.Dishes.Sort();
        }

        private DishType ParseDishType(string word)
        {
            var meal = Meal;
            DishType dishType;
            var success = Enum.TryParse(word, out dishType);
            if (!success)
            {
                meal.HasError = true;
            }
            return dishType;
        }

        private void ParseMealTime(IReadOnlyList<string> words)
        {
            var meal = Meal;
            var mealTypeString = words[0];
            switch (mealTypeString)
            {
                case "morning":
                    meal.MealTime = MealTime.Morning;
                    break;
                case "night":
                    meal.MealTime = MealTime.Night;
                    break;
                default:
                    var message = String.Format("Invalid Meal Time: {0}", mealTypeString);
                    throw new InvalidOperationException(message);
            }
        }

        private static DishValue GetDishValue(MealTime mealTime, DishType dishType)
        {
            var key = new MealTimeDishType(mealTime, dishType);
            if (MealTimeDishTypeDictionary.ContainsKey(key))
            {
                return MealTimeDishTypeDictionary[key];
            }
            return DishValue.None;
        }
    }
}
