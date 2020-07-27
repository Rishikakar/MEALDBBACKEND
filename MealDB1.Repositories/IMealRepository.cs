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
        List<MealsDTO> allMeals();
        List<MealsDTO> getLatestMeals();
        List<MainIngredientsDTO> getMainIngredients();
        List<CountrysDTO> getCountries();
        List<MealsDTO> getRandomMeals();
        List<MealByIdDTO> getMealById(int mealId);
        List<IngredientByIdDTO> getIngredientById(int ingredientId);
        List<CountryByIdDTO> getCountryById(int countryId);
        bool doRegisteration(RegistrationRequest data);
        bool validateLogin(LoginRequest data);
        List<MealsDTO> getSearchedMeals(SearchRequestDTO data);
        List<MealsDTO> getSearchedMealsByFirstLetter(SearchRequestDTO data);
        List<MealsDTO> getSearchList(string search);
    }
}
