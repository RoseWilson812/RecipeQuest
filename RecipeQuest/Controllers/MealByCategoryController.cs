using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RecipeQuest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RecipeQuest.Controllers
{
    public class MealByCategoryController : Controller
    {
        private readonly ILogger<MealByCategoryController> _logger;
        List<MealByCategory> categoryMealsList = new List<MealByCategory>();
        public string selectedCategory;


        public MealByCategoryController(ILogger<MealByCategoryController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("/MealByCategory/Index/{myCat}")]

        public async Task<IActionResult> IndexAsync(string myCat)
        {
            List<MealByCategory> categoryMealsList = new List<MealByCategory>();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://www.themealdb.com/api/json/v1/1/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("filter.php?c=" + myCat);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    var jobject = JsonConvert.DeserializeObject<ApiMealByCategoryRoot>(responseBody);

                    for (int i = 0; i < jobject.meals.Length; i++)
                    {
                        MealByCategory newMealByCategory = new MealByCategory
                        {
                            StrMeal = jobject.meals[i].strMeal,
                            StrMealThumb = jobject.meals[i].strMealThumb,
                            IdMeal = jobject.meals[i].idMeal,
                            SearchItem = myCat,
                        };
                        categoryMealsList.Add(newMealByCategory);
                    }

                }
                else
                {
                    ViewBag.errorMsg = "Server error try again later.";
                    return View();
                }
            }
            ViewBag.errorMsg = "";
            ViewBag.categorySearched = myCat;
            ViewBag.displayCategoryMeals = categoryMealsList;
            return View();
        }
    }
}
