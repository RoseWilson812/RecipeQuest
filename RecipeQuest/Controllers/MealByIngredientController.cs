using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
                else
                {
                    ViewBag.errorMsg = "Server error try again later.";
                    return View();
                }
            }
            ViewBag.errorMsg = "";
            
            MealByIngredientViewModel.MealsByIngredientList = ingredientMealsList.GetRange(0, ingredientMealsList.Count);
            
            return Redirect("/MealByIngredient/ShowList");
            
        }

        [HttpGet]
        public IActionResult ShowList(MealByIngredientViewModel mealByIngredientViewModel)
        {
            mealByIngredientViewModel.DisplayMealsByIngredientList = new List<MealByIngredient>();
            mealByIngredientViewModel.DisplayMealsByIngredientList = MealByIngredientViewModel.MealsByIngredientList.GetRange(0, MealByIngredientViewModel.MealsByIngredientList.Count);
            ViewBag.errorMsg = "";
            
            return View("Index", mealByIngredientViewModel);
        }
    }
}
