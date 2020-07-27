using System;
using System.Collections.Generic;
using System.Text;

namespace MealDB1.Entities.DTO
{
    public class MealsDTO
    {
        public int MealId { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public Uri MealUrl { get; set; }
    }
}
