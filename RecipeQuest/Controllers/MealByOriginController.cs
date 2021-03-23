using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RecipeQuest.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RecipeQuest.Controllers
{
    public class MealByOriginController : Controller
    {
        private readonly ILogger<MealByOriginController> _logger;
        List<MealByOrigin> originMealsList = new List<MealByOrigin>();



        public MealByOriginController(ILogger<MealByOriginController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        [Route("/MealByOrigin/Index/{myOrg}")]

        public async Task<IActionResult> IndexAsync(string myOrg)
        {
            List<MealByOrigin> originMealsList = new List<MealByOrigin>();

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("https://www.themealdb.com/api/json/v1/1/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("filter.php?a=" + myOrg);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    var jobject = JsonConvert.DeserializeObject<ApiMealByOriginRoot>(responseBody);

                    for (int i = 0; i < jobject.meals.Length; i++)
                    {
                        MealByOrigin newMealByOrigin = new MealByOrigin
                        {
                            StrMeal = jobject.meals[i].strMeal,
                            StrMealThumb = jobject.meals[i].strMealThumb,
                            IdMeal = jobject.meals[i].idMeal,
                            SearchItem = myOrg,
                        };
                        originMealsList.Add(newMealByOrigin);
                    }

                }
                else
                {
                    ViewBag.errorMsg = "Server error try again later.";
                    return View();
                }
            }
            ViewBag.errorMsg = "";
            ViewBag.originSearched = myOrg;
            ViewBag.displayOriginMeals = originMealsList;
            return View();
        }
    }
}