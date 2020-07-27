using System;
using System.Collections.Generic;
using System.Text;

namespace MealDB1.Entities.Model
{
   public class MainIngredients
    {
        public int Id { get; set; }
        public string MainIngredientName { get; set; }
        public Uri MainIngredientImageUrl { get; set; }
        public string MainIngredientDescription { get; set; }

        public Meals Meals { get; set; }
    }
}
