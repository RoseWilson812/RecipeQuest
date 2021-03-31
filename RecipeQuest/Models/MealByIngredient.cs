using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeQuest.Models
{
    public class MealByIngredient
    {
        public string StrMeal { get; set; }
        public string StrMealThumb { get; set; }
        public string IdMeal { get; set; }

        public string SearchItem { get; set; }


        public MealByIngredient()
        {
        }
        public MealByIngredient(string meal, string mealImage, string mealId, string searchItem)
        {
            StrMeal = meal;
            StrMealThumb = mealImage;
            IdMeal = mealId;
            SearchItem = searchItem;

        }
    }
}
