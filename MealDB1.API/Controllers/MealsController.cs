using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MealDB1.Entities.DTO;
using MealDB1.Entities.Request;
using MealDB1.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace MealDB1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealsController : ControllerBase
    {
        private readonly IMealRepository repository;
        public MealsController(IMealRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet("Meals")]
        public IActionResult Meals()
        {
            return Ok(repository.AllMeals());
        }
        [HttpGet("LatestMeals")]
        public IActionResult LatestMeals()
        {
            return Ok(repository.GetLatestMeals());
        }
        [HttpGet("MainIngredients")]
        public IActionResult MainIngredients()
        {
            return Ok(repository.GetMainIngredients());
        }
        [HttpGet("Countries")]
        public IActionResult Countries()
        {
            return Ok(repository.GetCountries());
        }
        [HttpGet("RandomMeals")]
        public IActionResult RandomMeals()
        {
            return Ok(repository.GetRandomMeals());
        }
        [HttpGet("MealById/{mealId}")]
        public IActionResult MealById(int mealId)
        {
            return Ok(repository.GetMealById(mealId));
        }
        [HttpGet("IngredientById/{ingredientId}")]
        public IActionResult IngredientById(int ingredientId)
        {
            return Ok(repository.GetIngredientById(ingredientId));
        }
        [HttpGet("CountryById/{countryId}")]
        public IActionResult CountryById(int countryId)
        {
            return Ok(repository.GetCountryById(countryId));
        }

        [HttpPost("Register")]
        [EnableCors]
        public IActionResult Register(RegistrationRequest data)
        {
            return Ok(repository.DoRegisteration(data));
        }
        [HttpPost("Login")]
        public IActionResult Login(LoginRequest data)
        {
            return Ok(repository.ValidateLogin(data));
        }
        [HttpPost("Search")]
        public IActionResult Search(SearchRequestDTO data)
        {
            return Ok(repository.GetSearchedMeals(data));
        }
       
        [HttpGet("searching/{search}")]
        public IActionResult Searching(string search)
        {
            return Ok(repository.GetSearchList(search));
        }
        [HttpPost("SearchByFirstLetter")]
        public IActionResult SearchByFirstLetter(SearchRequestDTO data)
        {
            return Ok(repository.GetSearchedMealsByFirstLetter(data));
        
        }
        [HttpPost("AdminInputForMeals")]
        public IActionResult AdminInputForMeals(AddMealRequestByAdmin data)
        {
            return Ok(repository.AddMeal(data));
        }
    }

}