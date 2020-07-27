using System;
using System.Collections.Generic;
using System.Text;

namespace MealDB1.Entities.Model
{
  public  class UserInfo
    {
        public int Id { get; set; }
        public string UserFirstName { get; set; }
        public string UserSecondName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}
