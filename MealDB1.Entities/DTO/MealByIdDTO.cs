using System;
using System.Collections.Generic;
using System.Text;

namespace MealDB1.Entities.DTO
{
   public class MealByIdDTO
    {

        public string MealName { get; set; }
        public Uri MealImageUrl { get; set; }
        public string MealDescription { get; set; }
        public string SubIngredientOne { get; set; }
        public Uri SubIngredientOneUrl { get; set; }
        public string SubIngredientTwo { get; set; }
        public Uri SubIngredientTwoUrl { get; set; }
        public string SubIngredientThree { get; set; }
        public Uri SubIngredientThreeUrl { get; set; }
        public string SubIngredientFour { get; set; }
        public Uri SubIngredientFourUrl { get; set; }
        public string SubIngredientFive { get; set; }
        public Uri SubIngredientFiveUrl { get; set; }
        public string SubIngredientSix { get; set; }
        public Uri SubIngredientSixUrl { get; set; }
        public int MainIngredientsId { get; set; }
        public string MainIngredientName { get; set; }
        public Uri MainIngredientImageUrl { get; set; }
    }
}
