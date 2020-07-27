using System;
using System.Collections.Generic;
using System.Text;

namespace MealDB1.Entities.DTO
{
    public class IngredientByIdDTO
    {
        public int MealId { get; set; }
        public string MealName { get; set; }
        public Uri MealImageUrl { get; set; }
        public string MainIngredientName { get; set; }
        public Uri MainIngredientImageUrl { get; set; }
        public string MainIngredientDescription { get; set; }
    }
}
