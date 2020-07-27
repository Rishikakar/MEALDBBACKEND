using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace MealDB1.Entities.Request
{
   public class RegistrationRequest
    {
        public int Id { get; set; }
        public string UserFirstName { get; set; }
        public string UserSecondName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
    }
}
