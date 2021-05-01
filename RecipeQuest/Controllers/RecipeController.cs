using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RecipeQuest.Data;
using RecipeQuest.Models;
using RecipeQuest.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;


namespace RecipeQuest.Controllers
{
    public class RecipeController : Microsoft.AspNetCore.Mvc.Controller
    {
        // parseMealId[0] = "Cat"(category), "Ori"(origin) or "Ing(ingredient),
        // parseMeadId[1] = selected search item from category or origin or ingredient 
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
            string initializeUserId = "";
            if (User.Identity.IsAuthenticated)
            {
                ClaimsPrincipal currentUser = this.User;
                var currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                initializeUserId = currentUserId;
            }      

            
            parseMealId = mealId.Split('|');
                        
            List<Recipe> saveRecipe = context.Recipes
            .Where(r => r.UserId == initializeUserId && r.IdMeal == parseMealId[2]).ToList();
            if (saveRecipe.Count > 0)
            {
                ViewBag.errorMsg = "";
                ViewBag.Result = "";
                ViewBag.alreadySavedMsg = "Recipe has already been saved";
                RecipeViewModel newRecipeViewModel = new RecipeViewModel();
                newRecipeViewModel.Routing = mealId;
                newRecipeViewModel.StrMeal = saveRecipe[0].StrMeal;
                return View(newRecipeViewModel);
            }
            else
            {
                ViewBag.Result = "";
                ViewBag.alreadySavedMsg = "";
            }     


            // mealId = searchSelect("Cat" or "Org" or "Ing") + "|" + SearchItem + "|" + IdMeal;
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
                    string route = parseMealId[0] + "|" + parseMealId[1] + "|" + parseMealId[2];
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
                                   initializeUserId,
                                   route

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
        [Route("/Recipe/SaveToFav/{mealId}")]
        
        public IActionResult SaveToFav(string mealId, Recipe newRecipe, RecipeViewModel newRecipeViewModel)
        {
            
            parseMealId = mealId.Split('|');
            newRecipe.IdMeal = parseMealId[2];
            List<Member> saveMember = context.Members
                .Where(m => m.UserId == newRecipe.UserId).ToList();
            if (saveMember.Count == 0)
            {
                Member newMember = new Member(newRecipe.UserId);
                saveMember.Add(newMember);
                context.Members.Add(newMember);
            }
                      
            context.Recipes.Add(newRecipe);
            var holdMemberRecipe = new MemberRecipe
            {
                Member = saveMember[0],
                Recipe = newRecipe
            };
            context.MemberRecipes.Add(holdMemberRecipe);
            
            context.SaveChanges();
            
            return RedirectToAction("SendView", "Recipe", new { routing = mealId }); 
        }

                
                
            
        [HttpGet]
        [Route("/Recipe/SendView/{routing}")]

        public IActionResult SendView(string routing)
        {
            //List<Recipe> saveRecipe = new List<Recipe>();
            string saveUserId = "";
            parseMealId = routing.Split('|');
            //newRecipe.IdMeal = parseMealId[2];
            if (User.Identity.IsAuthenticated)
                {
                ClaimsPrincipal currentUser = this.User;
                var currentUserId = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                saveUserId = currentUserId.ToString();
                }
                List<Recipe> saveRecipe = context.Recipes
                .Where(r => r.UserId == saveUserId && r.IdMeal == parseMealId[2]).ToList();

            ViewBag.errorMsg = "";
            ViewBag.Result = "Recipe Saved Succesfully";
            RecipeViewModel newRecipeViewModel = new RecipeViewModel();
            newRecipeViewModel.StrMeal = saveRecipe[0].StrMeal;
            newRecipeViewModel.Routing = routing;
            return View("Index", newRecipeViewModel);
        }


        [HttpGet]
        [Route("/Recipe/GoBack/{mealId}")]
        
        public IActionResult GoBack(string mealId)
        {
            parseMealId = mealId.Split('|');
            if (parseMealId[0] == "Cat")
            {
                return RedirectToAction("Index", "MealByCategory", new { myCat = parseMealId[1] });
            }
            else if (parseMealId[0] == "Org")
            {
                return RedirectToAction("Index", "MealByOrigin", new { myOrg = parseMealId[1] });
            }
            else  // == "Ing"
            {
                return RedirectToAction("Index", "MealByIngredient", new { mySearch = parseMealId[1] });
            }

        }
    }
}
