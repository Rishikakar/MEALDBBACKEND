using System;
using System.Collections.Generic;
using System.Text;

namespace MealDB1.Entities.Request
{
   public class AddIngredientRequestByAdmin
    {
        public string MainIngredientDescription { get; set; }
        public Uri MainIngredientImage { get; set; }
        public string MainIngredientName { get; set; }
    }
}
