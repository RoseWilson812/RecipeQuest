using System;
using System.Collections.Generic;
using RecipeQuest.Models;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RecipeQuest.ViewModels
{
    public class RecipeViewModel
    {
        public string IdMeal { get; set; }
        public string StrMeal { get; set; }
        public string StrCategory { get; set; }
        public string StrArea { get; set; }
        [DataType(DataType.MultilineText)]
        public string StrInstructions { get; set; }
        public string StrMealThumb { get; set; }
        public string StrIngredient1 { get; set; }
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
        
        


        public RecipeViewModel()
        {
        }

        public RecipeViewModel(string idMeal, string strMeal, string strCategory,
            string strArea, string strInstructions, string strMealThumb, string strIngredient1, string strIngredient2, string strIngredient3, string strIngredient4,
            string strIngredient5, string strIngredient6, string strIngredient7, string strIngredient8,
            string strIngredient9, string strIngredient10, string strIngredient11, string strIngredient12,
            string strIngredient13, string strIngredient14, string strIngredient15, string strIngredient16,
            string strIngredient17, string strIngredient18, string strIngredient19, string strIngredient20,
            string strMeasure1, string strMeasure2, string strMeasure3, string strMeasure4, string strMeasure5,
            string strMeasure6, string strMeasure7, string strMeasure8, string strMeasure9, string strMeasure10,
            string strMeasure11, string strMeasure12, string strMeasure13, string strMeasure14, string strMeasure15,
            string strMeasure16, string strMeasure17, string strMeasure18, string strMeasure19, string strMeasure20)
           
        {
            IdMeal = idMeal;
            StrMeal = strMeal;
            StrCategory = strCategory;
            StrArea = strArea;
            StrInstructions = strInstructions;
            StrMealThumb = strMealThumb;
            StrIngredient1 = strMeasure1 + " " + strIngredient1;
            StrIngredient2 = strMeasure2 + " " + strIngredient2;
            StrIngredient3 = strMeasure3 + " " + strIngredient3;
            StrIngredient4 = strMeasure4 + " " + strIngredient4;
            StrIngredient5 = strMeasure5 + " " + strIngredient5;
            StrIngredient6 = strMeasure6 + " " + strIngredient6;
            StrIngredient7 = strMeasure7 + " " + strIngredient7;
            StrIngredient8 = strMeasure8 + " " + strIngredient8;
            StrIngredient9 = strMeasure9 + " " + strIngredient9;
            StrIngredient10 = strMeasure10 + " " + strIngredient10;
            StrIngredient11 = strMeasure11 + " " + strIngredient11;
            StrIngredient12 = strMeasure12 + " " + strIngredient12;
            StrIngredient13 = strMeasure13 + " " + strIngredient13;
            StrIngredient14 = strMeasure14 + " " + strIngredient14;
            StrIngredient15 = strMeasure15 + " " + strIngredient15;
            StrIngredient16 = strMeasure16 + " " + strIngredient16;
            StrIngredient17 = strMeasure17 + " " + strIngredient17;
            StrIngredient18 = strMeasure18 + " " + strIngredient18;
            StrIngredient19 = strMeasure19 + " " + strIngredient19;
            StrIngredient20 = strMeasure20 + " " + strIngredient20;
                    
        }
    }
}