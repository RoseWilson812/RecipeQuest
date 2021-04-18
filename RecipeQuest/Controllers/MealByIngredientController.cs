using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RecipeQuest.Models;
using RecipeQuest.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RecipeQuest.Controllers
{
    public class MealByIngredientController : Controller
    {
        private readonly ILogger<MealByIngredientController> _logger;
        public static List<MealByIngredient> ingredientMealsList = new List<MealByIngredient>();



        public MealByIngredientController(ILogger<MealByIngredientController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("/MealByIngredient/Index/{mySearch}")]

        public async Task<IActionResult> IndexAsync(string mySearch)
        {
            List<MealByIngredient> ingredientMealsList = new List<MealByIngredient>();
            MealByIngredientViewModel mealByIngredientViewModel = new MealByIngredientViewModel();
            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri("https://www.themealdb.com/api/json/v1/1/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("filter.php?i=" + mySearch);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    var jobject = JsonConvert.DeserializeObject<ApiMealByIngredientRoot>(responseBody);
                    if (jobject.meals is null)
                    {
                        ViewBag.msg = "No meals matched this search";
                        ViewBag.errorMsg = "";
                       
                        MealByIngredientViewModel.SearchIngredient = mySearch;
                        mealByIngredientViewModel.DisplaySearchIngredient = mySearch;
                        return View("Index", mealByIngredientViewModel);
                    }
                    else
                    { 
                      for (int i = 0; i < jobject.meals.Length; i++)
                      {
                        MealByIngredient newMealByIngredient = new MealByIngredient
                        {
                            StrMeal = jobject.meals[i].strMeal,
                            StrMealThumb = jobject.meals[i].strMealThumb,
                            IdMeal = jobject.meals[i].idMeal,
                            SearchItem = mySearch,
                        };
                        ingredientMealsList.Add(newMealByIngredient);
                      }
                    }
                }
                else
                {
                    ViewBag.errorMsg = "Server error try again later.";
                    ViewBag.msg = "";
                    return View();
                }
            }

            ViewBag.errorMsg = "";
            ViewBag.msg = "";
            MealByIngredientViewModel.MealsByIngredientList = ingredientMealsList.GetRange(0, ingredientMealsList.Count);
            MealByIngredientViewModel.SearchIngredient = mySearch;
            return RedirectToAction("ShowList", "MealByIngredient", new { mealByIngredientViewModel });
        }

        [HttpGet]
        [Route("MealByIngredient/ShowList/{mealByIngredientViewModel}")]
        public IActionResult ShowList(MealByIngredientViewModel mealByIngredientViewModel)
        {
            if (MealByIngredientViewModel.MealsByIngredientList is null ||
                MealByIngredientViewModel.MealsByIngredientList.Count == 0)
            {
                return RedirectToAction("Index", "MealByIngredient", new { mySearch = MealByIngredientViewModel.SearchIngredient });
            }
            mealByIngredientViewModel.DisplayMealsByIngredientList = new List<MealByIngredient>();
            mealByIngredientViewModel.DisplayMealsByIngredientList = MealByIngredientViewModel.MealsByIngredientList.GetRange(0, MealByIngredientViewModel.MealsByIngredientList.Count);
            mealByIngredientViewModel.DisplaySearchIngredient = MealByIngredientViewModel.SearchIngredient;
            ViewBag.errorMsg = "";
            ViewBag.msg = "";
            return View("Index", mealByIngredientViewModel);
        }
    }
}
