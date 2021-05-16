using System;
using System.Collections.Generic;using System.ComponentModel.DataAnnotations;


namespace RecipeQuest.ViewModels
{
    public class AddRecipeViewModel
    {
        public string IdMeal { get; set; }
        [Required(ErrorMessage = "Recipe Name is required!")]
        public string StrMeal { get; set; }
        [Required(ErrorMessage = "Category is required!")]
        public string StrCategory { get; set; }
        [Required(ErrorMessage = "Country of Origin is required!")]
        public string StrArea { get; set; }
        [Required(ErrorMessage = "Instructions are required!")]
        public string StrInstructions { get; set; }
        public string StrMealThumb { get; set; }
        [Required(ErrorMessage = "Ingredient1 is required!")]
        public string StrIngredient1 { get; set; }
        [Required(ErrorMessage = "Ingredient2 is required!")]
        public string StrIngredient2 { get; set; }
        public string StrIngredient3 { get; set; }
        public string StrIngredient4 { get; set; }
        public string StrIngredient5 { get; set; }
        public string StrIngredient6 { get; set; }
        public string StrIngredient7 { get; set; }
        public string StrIngredient8 { get; set; }
        public string StrIngredient9 { get; set; }
        public string StrIngredient10 { get; set; }
        public string StrIngredient11 { get; set; }
        public string StrIngredient12 { get; set; }
        public string StrIngredient13 { get; set; }
        public string StrIngredient14 { get; set; }
        public string StrIngredient15 { get; set; }
        public string StrIngredient16 { get; set; }
        public string StrIngredient17 { get; set; }
        public string StrIngredient18 { get; set; }
        public string StrIngredient19 { get; set; }
        public string StrIngredient20 { get; set; }
        public string UserId { get; set; }
        public string Routing { get; set; }
     





        public AddRecipeViewModel()
        {
        }

        public AddRecipeViewModel(string idMeal, string strMeal, string strCategory,
            string strArea, string strInstructions, string strMealThumb, string strIngredient1, string strIngredient2, string strIngredient3, string strIngredient4,
            string strIngredient5, string strIngredient6, string strIngredient7, string strIngredient8,
            string strIngredient9, string strIngredient10, string strIngredient11, string strIngredient12,
            string strIngredient13, string strIngredient14, string strIngredient15, string strIngredient16,
            string strIngredient17, string strIngredient18, string strIngredient19, string strIngredient20,
            string userId, string routing)

        {
            IdMeal = idMeal;
            StrMeal = strMeal;
            StrCategory = strCategory;
            StrArea = strArea;
            StrInstructions = strInstructions;
            StrMealThumb = strMealThumb;
            StrIngredient1 = strIngredient1;
            StrIngredient2 = strIngredient2;
            StrIngredient3 = strIngredient3;
            StrIngredient4 = strIngredient4;
            StrIngredient5 = strIngredient5;
            StrIngredient6 = strIngredient6;
            StrIngredient7 = strIngredient7;
            StrIngredient8 = strIngredient8;
            StrIngredient9 = strIngredient9;
            StrIngredient10 = strIngredient10;
            StrIngredient11 = strIngredient11;
            StrIngredient12 = strIngredient12;
            StrIngredient13 = strIngredient13;
            StrIngredient14 = strIngredient14;
            StrIngredient15 = strIngredient15;
            StrIngredient16 = strIngredient16;
            StrIngredient17 = strIngredient17;
            StrIngredient18 = strIngredient18;
            StrIngredient19 = strIngredient19;
            StrIngredient20 = strIngredient20;
            UserId = userId;
            Routing = routing;
        }
    }

}
