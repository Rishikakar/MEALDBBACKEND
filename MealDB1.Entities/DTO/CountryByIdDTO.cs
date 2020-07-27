using System;
using System.Collections.Generic;
using System.Text;

namespace MealDB1.Entities.DTO
{
  public  class CountryByIdDTO
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public Uri CountryImageUrl { get; set; }
        public string CountryDescription { get; set; }
        public int MealId { get; set; }
        public string MealName { get; set; }
        public Uri MealImageUrl { get; set; }
        public string MealDescription { get; set; }
    }
}
