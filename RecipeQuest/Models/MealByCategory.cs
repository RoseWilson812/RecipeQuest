using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeQuest.Models
{
    public class MealByCategory
    {
        public int Id { get; set; }
        public string StrMeal { get; set; }
        public string StrMealThumb { get; set; }
        public string IdMeal { get; set; }


        public MealByCategory()
        {
        }
        public MealByCategory(string meal, string mealImage, string mealId)
        {
            StrMeal = meal;
            StrMealThumb = mealImage;
            IdMeal = mealId;

        }
    }
}
