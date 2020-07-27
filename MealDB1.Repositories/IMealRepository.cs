using System;
using System.Collections.Generic;
using System.Text;
using MealDB1.Entities.DTO;
using MealDB1.Entities.Model;
using MealDB1.Entities.Request;

namespace MealDB1.Repositories
{
    public interface IMealRepository
    {
        List<MealsDTO> AllMeals();
        List<MealsDTO> GetLatestMeals();
        List<MainIngredientsDTO> GetMainIngredients();
        List<CountrysDTO> GetCountries();
        List<MealsDTO> GetRandomMeals();
        List<MealByIdDTO> GetMealById(int mealId);
        List<IngredientByIdDTO> GetIngredientById(int ingredientId);
        List<CountryByIdDTO> GetCountryById(int countryId);
        bool DoRegisteration(RegistrationRequest data);
        bool ValidateLogin(LoginRequest data);
        List<MealsDTO> GetSearchedMeals(SearchRequestDTO data);
       
        List<MealsDTO> GetSearchList(string search);
    }
}
