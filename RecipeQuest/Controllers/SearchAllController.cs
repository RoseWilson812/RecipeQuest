using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RecipeQuest.Models;
using RecipeQuest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RecipeQuest.Controllers
{
    public class SearchAllController : Controller
    {

        public async Task<IActionResult> IndexAsync()
        {
            List<string> categoryName = new List<string>();
            List<string> originName = new List<string>();
            List<MealByIngredient> ingredientMeals = new List<MealByIngredient>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.themealdb.com/api/json/v1/1/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("categories.php");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    var jobject = JsonConvert.DeserializeObject<ApiCategoryRoot>(responseBody);

                    for (int i = 0; i < jobject.categories.Length; i++)
                    {
                        categoryName.Add(jobject.categories[i].strCategory);
                    }

                }
                else
                {
                    ViewBag.errorMsg = "Server error(categories) try again later.";
                    return View();
                }

            }
            categoryName.Sort();
            ViewBag.displayCategory = categoryName;


            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.themealdb.com/api/json/v1/1/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("list.php?a=list");

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    var jobject1 = JsonConvert.DeserializeObject<ApiOriginRoot>(responseBody);

                    for (int i = 0; i < jobject1.meals.Length; i++)
                    {
                        originName.Add(jobject1.meals[i].strArea);
                    }

                }
                else
                {
                    ViewBag.errorMsg = "Server error(origin) try again later.";
                    return View();
                }

            }
            originName.Sort();
            MealByIngredientViewModel mealByIngredientViewModel = new MealByIngredientViewModel(ingredientMeals, categoryName, originName);

            ViewBag.errorMsg = "";
            ViewBag.displayOrigin = originName;
            
            return View(mealByIngredientViewModel);
        }
        [HttpPost]
        public IActionResult Transfer(MealByIngredientViewModel mealByIngredientViewModel)
        {
            mealByIngredientViewModel.DisplayCategoryNames = new List<string>();
            mealByIngredientViewModel.DisplayCategoryNames = MealByIngredientViewModel.CategoryNames.GetRange(0, MealByIngredientViewModel.CategoryNames.Count);
            mealByIngredientViewModel.DisplayOriginNames = new List<string>();
            mealByIngredientViewModel.DisplayOriginNames = MealByIngredientViewModel.OriginNames.GetRange(0, MealByIngredientViewModel.OriginNames.Count);
            MealByIngredientViewModel.SearchIngredient = mealByIngredientViewModel.DisplaySearchIngredient;
            string mySearch = MealByIngredientViewModel.SearchIngredient;
            if (ModelState.IsValid)
            {

                return RedirectToAction("Index", "MealByIngredient", new { mySearch });
            }
            else
            {
                return RedirectToAction("SendError", "SearchAll", new { mealByIngredientViewModel });
                
            }
        }
        [HttpGet]
        [Route("/SearchAll/SendError/{mealByIngredientViewModel}")]

        public IActionResult SendError(MealByIngredientViewModel mealByIngredientViewModel)
        {
            mealByIngredientViewModel.DisplaySearchIngredient = MealByIngredientViewModel.SearchIngredient;
            if (MealByIngredientViewModel.SearchIngredient is null ||
               MealByIngredientViewModel.SearchIngredient == "")
            {
                ModelState.AddModelError("DisplaySearchIngredient",
                                    "An ingredient must be entered.");
            }
            else
            {
                ModelState.Clear();
            }
            mealByIngredientViewModel.DisplayCategoryNames = new List<string>();
            mealByIngredientViewModel.DisplayCategoryNames = MealByIngredientViewModel.CategoryNames.GetRange(0, MealByIngredientViewModel.CategoryNames.Count);
            mealByIngredientViewModel.DisplayOriginNames = new List<string>();
            mealByIngredientViewModel.DisplayOriginNames = MealByIngredientViewModel.OriginNames.GetRange(0, MealByIngredientViewModel.OriginNames.Count);
            
            ViewBag.errorMsg = "";
            return View("Index", mealByIngredientViewModel);

    
        }
    }
}
