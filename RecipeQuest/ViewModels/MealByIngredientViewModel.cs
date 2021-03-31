using RecipeQuest.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeQuest.ViewModels
{
    public class MealByIngredientViewModel
    {
        [Required(ErrorMessage = "An ingredient must be entered.")]
        public string DisplaySearchIngredient { get; set; }
        public static List<MealByIngredient> MealsByIngredientList { get; set; }
       
        public static List<string> CategoryNames { get; set; }
        public static List<string> OriginNames { get; set; }
        public List<MealByIngredient> DisplayMealsByIngredientList { get; set; }
        public List<string> DisplayCategoryNames { get; set; }
        public List<string> DisplayOriginNames { get; set; }

        public static string SearchIngredient { get; set; }
        public MealByIngredientViewModel()
        {
        }
        public MealByIngredientViewModel(List<MealByIngredient> possibleMeals, List<string> categoryNames, List<string> originNames)
        {
            
            MealsByIngredientList = new List<MealByIngredient>();
            MealsByIngredientList = possibleMeals.GetRange(0, possibleMeals.Count);
            CategoryNames = new List<string>();
            CategoryNames = categoryNames.GetRange(0, categoryNames.Count);
            OriginNames = new List<string>();
            OriginNames = originNames.GetRange(0, originNames.Count);
            DisplayCategoryNames = new List<string>();
            DisplayCategoryNames = categoryNames.GetRange(0, categoryNames.Count);
            DisplayMealsByIngredientList = new List<MealByIngredient>();
            DisplayMealsByIngredientList = possibleMeals.GetRange(0, possibleMeals.Count);
            DisplayOriginNames = new List<string>();
            DisplayOriginNames = originNames.GetRange(0, originNames.Count);
            
        }
    }
}
