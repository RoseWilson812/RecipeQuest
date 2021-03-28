using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RecipeQuest.Data;
using RecipeQuest.Models;
using RecipeQuest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace RecipeQuest.Controllers
{
    public class SearchFavoritesController : Microsoft.AspNetCore.Mvc.Controller
    {


        List<string> categoryName = new List<string>();
        List<string> originName = new List<string>();
        private RecipeDbContext context;

        public SearchFavoritesController(RecipeDbContext dbContext)
        {
            context = dbContext;
        }



        [Authorize]
        public IActionResult Index()
        {

            ClaimsPrincipal currentUser = this.User;
            var currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            List<Recipe> allRecipes = context.Recipes
                .Where(r => r.UserId == currentUserId).ToList();
            foreach (var rec in allRecipes)
            {
                if (categoryName.Contains(rec.StrCategory))
                {
                    if (originName.Contains(rec.StrArea))
                    {
                        break;
                    }
                    else
                    {
                        originName.Add(rec.StrArea);
                    }
                }
                else
                {
                    categoryName.Add(rec.StrCategory);
                    if (originName.Contains(rec.StrArea))
                    {
                        break;
                    }
                    else
                    {
                        originName.Add(rec.StrArea);
                    }
                }
            }

            ViewBag.errorMsg = "";
            categoryName.Sort();
            originName.Sort();
                       
            List<Recipe> sortedRecipes = allRecipes.OrderBy(recipe => recipe.StrMeal).ToList();
            List<Recipe> selectRecipe = new List<Recipe>();
            List<Recipe> searchRecipe = new List<Recipe>();
            List<Recipe> displayRecipe = new List<Recipe>();
            SearchFavoritesViewModel searchFavoritesViewModel =
                new SearchFavoritesViewModel(sortedRecipes, categoryName, originName,
                "", "", "", "", searchRecipe, selectRecipe, displayRecipe);

            return View(searchFavoritesViewModel);

        }
        [HttpGet]
        [Route("/SearchFavorites/SearchCategory/{myCat}")]
        public IActionResult SearchCategory(string myCat, SearchFavoritesViewModel searchFavoritesViewModel)
        {
            List<Recipe> searchRecipe = new List<Recipe>();
            SearchFavoritesViewModel.SelectedSearch = "Cat";
            SearchFavoritesViewModel.SelectedSearchItem = myCat;
            foreach (Recipe recipe in SearchFavoritesViewModel.UserRecipeList)
            {
                if (recipe.StrCategory == myCat)
                {
                    searchRecipe.Add(recipe);
                }
            }
            
            SearchFavoritesViewModel.SearchRecipeList = searchRecipe;
            searchFavoritesViewModel.DisplayRecipeList = searchRecipe;
            ViewBag.selectedSearchItem = SearchFavoritesViewModel.SelectedSearchItem;
            return View("SearchCategory", searchFavoritesViewModel);
        }

        [HttpGet]
        [Route("/SearchFavorites/SelectedCategoryMeal/{mealId}")]
        public IActionResult SelectedCategoryMeal(string mealId, SearchFavoritesViewModel searchFavoritesViewModel)
        {
            List<Recipe> selectRecipe = new List<Recipe>();
            searchFavoritesViewModel.SelectedMealId = mealId;
            
            foreach (Recipe recipe in SearchFavoritesViewModel.SearchRecipeList)
            {
                if (recipe.IdMeal == mealId)
                {
                    selectRecipe.Add(recipe);
                }
            }
            searchFavoritesViewModel.SelectedRecipe = selectRecipe;
            return View("Recipe", searchFavoritesViewModel);
        } 

        [HttpGet]
        [Route("/SearchFavorites/SearchOrigin/{myOrg}")]
        public IActionResult SearchOrigin(string myOrg, SearchFavoritesViewModel searchFavoritesViewModel)
        {
            List<Recipe> searchRecipe = new List<Recipe>();
            SearchFavoritesViewModel.SelectedSearch = "Org";
            SearchFavoritesViewModel.SelectedSearchItem = myOrg;
            foreach (Recipe recipe in SearchFavoritesViewModel.UserRecipeList)
            {
                if (recipe.StrArea == myOrg)
                {
                    searchRecipe.Add(recipe);
                }
            }
            SearchFavoritesViewModel.SearchRecipeList = searchRecipe;
            searchFavoritesViewModel.DisplayRecipeList = searchRecipe;
            ViewBag.selectedSearchItem = SearchFavoritesViewModel.SelectedSearchItem;
            return View("SearchOrigin", searchFavoritesViewModel);
        }

        [HttpGet]
        [Route("/SearchFavorites/SelectedOriginMeal/{mealId}")]
        public IActionResult SelectedOriginMeal(string mealId, SearchFavoritesViewModel searchFavoritesViewModel)
        {
            List<Recipe> selectRecipe = new List<Recipe>();
            searchFavoritesViewModel.SelectedMealId = mealId;

            foreach (Recipe recipe in SearchFavoritesViewModel.SearchRecipeList)
            {
                if (recipe.IdMeal == mealId)
                {
                    selectRecipe.Add(recipe);
                }
            }
            searchFavoritesViewModel.SelectedRecipe = selectRecipe;
            return View("Recipe", searchFavoritesViewModel);
        }

        [HttpPost]
        [Route("/SearchFavorites/DeleteRecipe/{id}")]
        public IActionResult DeleteRecipe(int id, SearchFavoritesViewModel searchFavoritesViewModel)
        {
            Recipe newRecipe = context.Recipes.Find(id);
            string saveCategory = newRecipe.StrCategory;
            string saveOrigin = newRecipe.StrCategory;
            context.Recipes.Remove(newRecipe);
            context.SaveChanges();
            SearchFavoritesViewModel.UserRecipeList.RemoveAll(Recipe => Recipe.Id == id);

            
                if (SearchFavoritesViewModel.SelectedSearch == "Cat")
                {
                    return RedirectToAction("SearchCategory", "SearchFavorites", new { myCat = SearchFavoritesViewModel.SelectedSearchItem });
                }
                else
                {
                    return RedirectToAction("SearchOrigin", "SearchFavorites", new { myOrg = SearchFavoritesViewModel.SelectedSearchItem });
                }
            
           
        }

        
    }
}

 
