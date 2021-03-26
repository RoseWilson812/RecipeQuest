using RecipeQuest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeQuest.ViewModels
{
    public class SearchFavoritesViewModel
    {
        public static List<Recipe> UserRecipeList { get; set; }
        public List<string> CategoryNameList { get; set; }
        public List<string> OriginNameList { get; set; }
        // Cat(category) or Org(origin)
        public static string SelectedSearch { get; set; }
        // an item within category or origin
        public static string SelectedSearchItem { get; set; }
        public string SelectedMealId { get; set; }
        public string ControllerRouting { get; set; }
        public static List<Recipe> SearchRecipeList { get; set; }
        public List<Recipe> SelectedRecipe { get; set; }
        public List<Recipe> DisplayRecipeList { get; set; }


        public SearchFavoritesViewModel() 
        {
        }
            
        public SearchFavoritesViewModel(List<Recipe> possibleRecipes,
            List<string> possibleCategories, List<string> possibleOrigins,
            string search, string searchItem, string mealId, string controllerRouting,
             List<Recipe> searchRecipes, List<Recipe> selectRecipes, List<Recipe> displayRecipes)
        {
            UserRecipeList = new List<Recipe>();
            UserRecipeList = possibleRecipes.GetRange(0, possibleRecipes.Count);

            CategoryNameList = new List<string>();
            CategoryNameList = possibleCategories.GetRange(0, possibleCategories.Count);

            OriginNameList = new List<string>();
            OriginNameList = possibleOrigins.GetRange(0, possibleOrigins.Count);

            SelectedSearch = search;
            SelectedSearchItem = searchItem;
            SelectedMealId = mealId;
            ControllerRouting = controllerRouting;

            SearchRecipeList = new List<Recipe>();
            SearchRecipeList = searchRecipes.GetRange(0, searchRecipes.Count);

            SelectedRecipe = new List<Recipe>();
            SelectedRecipe = selectRecipes.GetRange(0, selectRecipes.Count);

            DisplayRecipeList = new List<Recipe>();
            DisplayRecipeList = displayRecipes.GetRange(0, displayRecipes.Count);


        }
    }
}

