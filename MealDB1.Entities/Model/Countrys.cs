using System;
using System.Collections.Generic;
using System.Text;

namespace MealDB1.Entities.Model
{
   public class Countrys
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public Uri CountryImageUrl { get; set; }
        public string CountryDescription { get; set; }
        public Meals Meals { get; set; }
    }
}
