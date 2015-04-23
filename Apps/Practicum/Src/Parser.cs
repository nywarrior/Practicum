using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Practicum.Entities;

namespace Practicum
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
        private readonly IMeal _meal;

        /// <summary>
        /// 
        /// </summary>
        public Parser()
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
        /// <param name="inputLine"></param>
        public IMeal ParseMeal(string inputLine)
        {
            if (String.IsNullOrEmpty(inputLine))
            {
                throw new InvalidOperationException("Input Line is Empty.");
            }
            _meal.Clear();
            var words = inputLine.Split(WordDelimiter);
            if (!words.Any())
            {
                throw new InvalidOperationException("Input Line is Empty.");
            }
            ParseMealTime(words);
            ParseDishes(words);
            return _meal;
        }

        private void ParseDishes(IReadOnlyList<string> words)
        {
            var dishValueDishDictionary = new Dictionary<DishValue, Dish>();
            for (var i = 1; i < words.Count; i++)
            {
                var word = words[i];
                var dishType = ParseDishType(word);
                if (dishType == DishType.None)
                {
                    continue;
                }
                var dishValue = GetDishValue(_meal.MealTime, dishType);
                if (dishValue == DishValue.None)
                {
                    _meal.HasError = true;
                    break;
                }
                if (dishValueDishDictionary.ContainsKey(dishValue))
                {
                    var dish = dishValueDishDictionary[dishValue];
                    if (!(DishValueAllowMultipleOccurencesDictionary.ContainsKey(dishValue) && DishValueAllowMultipleOccurencesDictionary[dishValue]))
                    {
                        _meal.HasError = true;
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
            _meal.Dishes.Clear();
            foreach (var dish in dishValueDishDictionary.Values)
            {
                _meal.Dishes.Add(dish);
            } 
            _meal.Dishes.Sort();
        }

        private DishType ParseDishType(string word)
        {
            DishType dishType;
            var success = Enum.TryParse(word, out dishType);
            if (!success)
            {
                _meal.HasError = true;
            }
            return dishType;
        }

        private void ParseMealTime(IReadOnlyList<string> words)
        {
            var mealTypeString = words[0];
            switch (mealTypeString)
            {
                case "morning":
                    _meal.MealTime = MealTime.Morning;
                    break;
                case "night":
                    _meal.MealTime = MealTime.Night;
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
