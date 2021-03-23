using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RecipeQuest.Data;
using RecipeQuest.Models;
using RecipeQuest.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace RecipeQuest.Controllers
{
    public class RecipeController : Controller
    {
        // parseMealId[0] = "Cat"(category) or "Ori"(origin),
        // parseMeadId[1] = selected search item from category or origin 
        // parseMealId[2] = mealId  
        string[] parseMealId = new string[3];
        
        List<Recipe> recipes = new List<Recipe>();
        private RecipeDbContext context;

        public RecipeController(RecipeDbContext dbContext)
        {
            context = dbContext;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("/Recipe/Index/{mealId}")]

        public async Task<IActionResult> IndexAsync(string mealId)
        {
            parseMealId = mealId.Split('|');
            using (
                                       
                var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://www.themealdb.com/api/json/v1/1/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("lookup.php?i=" + parseMealId[2]);
                
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    //dynamic json  = JsonConvert.DeserializeObject<Recipe>(responseBody);
                    var jobject = JsonConvert.DeserializeObject<ApiMealRoot>(responseBody);
                    
                   RecipeViewModel newRecipeViewModel = new RecipeViewModel(jobject.meals[0].idMeal,
                                  jobject.meals[0].strMeal,
                                  jobject.meals[0].strCategory,
                                  jobject.meals[0].strArea,
                                  jobject.meals[0].strInstructions,
                                  jobject.meals[0].strMealThumb,
                                  jobject.meals[0].strIngredient1,
                                  jobject.meals[0].strIngredient2,
                                  jobject.meals[0].strIngredient3,
                                  jobject.meals[0].strIngredient4,
                                  jobject.meals[0].strIngredient5,
                                  jobject.meals[0].strIngredient6,
                                  jobject.meals[0].strIngredient7,
                                  jobject.meals[0].strIngredient8,
                                  jobject.meals[0].strIngredient9,
                                  jobject.meals[0].strIngredient10,
                                  jobject.meals[0].strIngredient11,
                                  jobject.meals[0].strIngredient12,
                                  jobject.meals[0].strIngredient13,
                                  jobject.meals[0].strIngredient14,
                                  jobject.meals[0].strIngredient15,
                                  jobject.meals[0].strIngredient16,
                                  jobject.meals[0].strIngredient17,
                                  jobject.meals[0].strIngredient18,
                                  jobject.meals[0].strIngredient19,
                                  jobject.meals[0].strIngredient20,
                                  jobject.meals[0].strMeasure1,
                                  jobject.meals[0].strMeasure2,
                                  jobject.meals[0].strMeasure3,
                                  jobject.meals[0].strMeasure4,
                                  jobject.meals[0].strMeasure5,
                                  jobject.meals[0].strMeasure6,
                                  jobject.meals[0].strMeasure7,
                                  jobject.meals[0].strMeasure8,
                                  jobject.meals[0].strMeasure9,
                                  jobject.meals[0].strMeasure10,
                                  jobject.meals[0].strMeasure11,
                                  jobject.meals[0].strMeasure12,
                                  jobject.meals[0].strMeasure13,
                                  jobject.meals[0].strMeasure14,
                                  jobject.meals[0].strMeasure15,
                                  jobject.meals[0].strMeasure16,
                                  jobject.meals[0].strMeasure17,
                                  jobject.meals[0].strMeasure18,
                                  jobject.meals[0].strMeasure19,
                                  jobject.meals[0].strMeasure20,
                                  mealId
                                 
                        );
                        ViewBag.errorMsg = "";
                        return View(newRecipeViewModel);

                    
                }
                else
                {
                    ViewBag.errorMsg = "Server error try again later.";
                    return View();
                }

            }
                    
        }

        [HttpPost]
        [Route("/Recipe/Index/{IdMeal}")]

        [Authorize]
        public IActionResult SaveToFav(string IdMeal, Recipe newRecipe)
        {
            context.Recipes.Add(newRecipe);
            context.SaveChanges();
            ViewBag.errorMsg = "";
            parseMealId = IdMeal.Split('|');
            if (parseMealId[0] == "Cat" )
            {
                return RedirectToAction("Index", "MealByCategory", new { myCat = parseMealId[1] });
            } else
            {
                return RedirectToAction("Index", "MealByOrigin", new { myOrg = parseMealId[1] });
            }
            //return RedirectToAction("Index", "Recipe", new { mealId = IdMeal });
            //return RedirectToAction("Index", "SearchAll", new { area = "" });
        }
    }
}
