using MealDB1.Entities;
using MealDB1.Entities.DTO;
using MealDB1.Entities.Model;
using MealDB1.Entities.Request;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace MealDB1.Repositories
{
    public class MealRepository : IMealRepository
    {
        private readonly MealDbContext _db;


        public MealRepository(MealDbContext db)
        {
            this._db = db;
        }

       

        public List<CountrysDTO> GetCountries()
        {
            List<CountrysDTO> countrys = new List<CountrysDTO>();
            var countries = _db.Country.ToList();
            foreach (var item in countries)
            {
                countrys.Add(new CountrysDTO()
                {
                    CountryName = item.CountryName,
                    CountryImageUrl = item.CountryImageUrl,
                    CountryId = item.Id
                });
            }
            return countrys;
        }
        public List<MealsDTO> GetSearchListByLetter(string search)
        {
            List<MealsDTO> MealsListByFirstLetter = new List<MealsDTO>();
            if (search != null)
            {
                var meals = _db.Meals.ToList();
                foreach (var item in meals)
                {
                    if (item.MealName.StartsWith(search.ToUpper()) || item.MealName.StartsWith(search.ToLower()))
                    {
                        MealsListByFirstLetter.Add(new MealsDTO()
                        {
                            MealName = item.MealName,
                            MealId = item.Id,
                            MealUrl = item.MealImageUrl,
                            MealDescription = item.MealDescription
                        }
                        );
                    }
                }
            }
            return MealsListByFirstLetter;
        }

        public List<CountryByIdDTO> GetCountryById(int countryId)
        {
            List<CountryByIdDTO> MealsBasedOnCountryId = new List<CountryByIdDTO>();
            var list = _db.Country.Include("Meals").Where(a => a.Id == countryId);
            foreach (var item in list)
            {
                MealsBasedOnCountryId.Add(new CountryByIdDTO()
                {
                    CountryId = item.Id,
                    CountryName = item.CountryName,
                    CountryImageUrl = item.CountryImageUrl,
                    CountryDescription = item.CountryDescription,
                    MealId = item.Meals.Id,
                    MealName = item.Meals.MealName,
                    MealImageUrl = item.Meals.MealImageUrl,
                    MealDescription = item.Meals.MealDescription
                });
            }
            return MealsBasedOnCountryId;
        }
        List<MealsDTO> IMealRepository.AllMeals()
        {
            List<MealsDTO> MealsList = new List<MealsDTO>();
            var meals = _db.Meals.ToList();
            foreach (var item in meals)
            {
                MealsList.Add(new MealsDTO()
                {
                    MealId = item.Id,
                    MealName = item.MealName,
                    MealDescription = item.MealDescription,
                    MealUrl = item.MealImageUrl
                });
            }
            return MealsList;
        }

        public List<IngredientByIdDTO> GetIngredientById(int ingredientId)
        {
            List<IngredientByIdDTO> MealsBasedOnIngredient = new List<IngredientByIdDTO>();
            var lists = _db.MainIngredients.Include("Meals").Where(a => a.Id == ingredientId);
            foreach (var item in lists)
            {
                try
                {
                    MealsBasedOnIngredient.Add(new IngredientByIdDTO()
                    {
                        MainIngredientName = item.MainIngredientName,
                        MainIngredientImageUrl = item.MainIngredientImageUrl,
                        MealName = item.Meals.MealName,
                        MealImageUrl = item.Meals.MealImageUrl,
                        MealId = item.Meals.Id,
                        MainIngredientDescription = item.MainIngredientDescription
                    });
                }
                catch
                {

                }

            }
            return MealsBasedOnIngredient;
        }

        public List<MealsDTO> GetLatestMeals()
        {
            List<MealsDTO> MealsList = new List<MealsDTO>();
            var meals = _db.Meals.ToList();
            int count = 0;
            foreach (var item in meals)
            {
                count++;
                if (count > meals.Count - 4)
                {
                    MealsList.Add(new MealsDTO()
                    {
                        MealId = item.Id,
                        MealName = item.MealName,
                        MealDescription = item.MealDescription,
                        MealUrl = item.MealImageUrl
                    });
                }
            }
            return MealsList;
        }

        public List<MainIngredientsDTO> GetMainIngredients()
        {
            var ingredients = _db.MainIngredients.ToList();
            List<MainIngredientsDTO> mainIngredients = new List<MainIngredientsDTO>();
            foreach (var item in ingredients)
            {
                mainIngredients.Add(new MainIngredientsDTO()
                {
                    MainIngredientName = item.MainIngredientName,
                    MainIngredientImageUrl = item.MainIngredientImageUrl,
                    MainIngredientId = item.Id
                });
            }
            return mainIngredients;
        }

        public List<MealByIdDTO> GetMealById(int mealId)
        {
            List<MealByIdDTO> meal = new List<MealByIdDTO>();
            var meals = _db.Meals.Include("MainIngredients").Where(a => a.Id == mealId).ToList();
            foreach (var item in meals)
            {
                meal.Add(new MealByIdDTO()
                {
                    MealName = item.MealName,
                    MealImageUrl = item.MealImageUrl,
                    MealDescription = item.MealDescription,
                    SubIngredientOne = item.SubIngredientOne,
                    SubIngredientTwo = item.SubIngredientTwo,
                    SubIngredientThree = item.SubIngredientThree,
                    SubIngredientFour = item.SubIngredientFour,
                    SubIngredientFive = item.SubIngredientFive,
                    SubIngredientSix = item.SubIngredientSix,
                    SubIngredientOneUrl = item.SubIngredientOneUrl,
                    SubIngredientTwoUrl = item.SubIngredientTwoUrl,
                    SubIngredientThreeUrl = item.SubIngredientThreeUrl,
                    SubIngredientFourUrl = item.SubIngredientFourUrl,
                    SubIngredientFiveUrl = item.SubIngredientFiveUrl,
                    SubIngredientSixUrl = item.SubIngredientSixUrl,
                    MainIngredientsId = item.MainIngredients.Id,
                    MainIngredientName = item.MainIngredients.MainIngredientName,
                    MainIngredientImageUrl = item.MainIngredients.MainIngredientImageUrl
                });
            }
            return meal;
        }

        public List<MealsDTO> GetRandomMeals()
        {
            List<MealsDTO> MealsList = new List<MealsDTO>();
            var meals = _db.Meals.ToList();
            int count = 0;
            int number = 0;
            List<int> listNumbers = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                do
                {
                    number = RandomNumberGenerator.GetInt32(meals.Count);
                } while (listNumbers.Contains(number) || number == 0);
                listNumbers.Add(number);
            }
            foreach (var item in meals)
            {
                if (listNumbers.Contains(item.Id))
                {
                    count++;
                    if (count <= 5)
                    {
                        MealsList.Add(new MealsDTO()
                        {
                            MealId = item.Id,
                            MealName = item.MealName,
                            MealDescription = item.MealDescription,
                            MealUrl = item.MealImageUrl
                        });
                    }
                }
            }
            return MealsList;
        }

        public List<MealsDTO> GetSearchedMeals(SearchRequestDTO request)
        {
            List<MealsDTO> MealsList = new List<MealsDTO>();
            if (request != null)
            {
                var meals = _db.Meals.ToList();
                foreach (var item in meals)
                {
                    if (item.MealName.Contains(request.SearchKeyWord))
                    {
                        MealsList.Add(new MealsDTO()
                        {
                            MealName = item.MealName,
                            MealId = item.Id,
                            MealUrl = item.MealImageUrl,
                            MealDescription = item.MealDescription
                        }
                        );
                    }
                }
            }
            return MealsList;
        }

       
        public bool DoRegisteration(RegistrationRequest request)
        {
            if (request != null)
            {
                UserInfo addingUser = new UserInfo();
                addingUser.UserFirstName = request.UserFirstName;
                addingUser.UserSecondName = request.UserSecondName;
                addingUser.UserEmail = request.UserEmail;
                addingUser.UserPassword = request.UserPassword;
                _db.UserInfos.Add(addingUser);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool ValidateLogin(LoginRequest request)
        {
            var log = _db.UserInfos.ToList();
            if (request != null)
            {
                LoginRequest login = new LoginRequest();
                login.LoginEmailId = request.LoginEmailId;
                login.LoginPassword = request.LoginPassword;
                foreach (var item in log)
                {
                    if (item.UserEmail == login.LoginEmailId && item.UserPassword == login.LoginPassword)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public List<MealsDTO> GetSearchList(string search)
        {
            List<MealsDTO> MealsList = new List<MealsDTO>();
            if (search != null)
            {
                var meals = _db.Meals.ToList();
                foreach (var item in meals)
                {
                    if (item.MealName.Contains(search))
                    {
                        MealsList.Add(new MealsDTO()
                        {
                            MealName = item.MealName,
                            MealId = item.Id,
                            MealUrl = item.MealImageUrl,
                            MealDescription = item.MealDescription
                        }
                        );
                    }
                }
            }
            return MealsList;
        }
        public bool AddMeal(AddMealRequestByAdmin requestByAdmin)
        {
            if (requestByAdmin != null)
            {
                Meals meals = new Meals();
                meals.MealName = requestByAdmin.MealName;
                meals.MealImageUrl = requestByAdmin.MealImageUrl;
                meals.MealDescription = requestByAdmin.MealDescription;
                meals.SubIngredientOne = requestByAdmin.SubIngredientOne;
                meals.SubIngredientOneUrl = requestByAdmin.SubIngredientOneUrl;
                meals.SubIngredientTwo = requestByAdmin.SubIngredientTwo;
                meals.SubIngredientThree = requestByAdmin.SubIngredientThree;
                meals.SubIngredientFour = requestByAdmin.SubIngredientFour;
                meals.SubIngredientFourUrl = requestByAdmin.SubIngredientFourUrl;
                meals.SubIngredientFive = requestByAdmin.SubIngredientFive;
                meals.SubIngredientFiveUrl = requestByAdmin.SubIngredientFiveUrl;
                meals.SubIngredientSix = requestByAdmin.SubIngredientSix;
                meals.SubIngredientSixUrl = requestByAdmin.SubIngredientSixUrl;
                meals.CountrysId = requestByAdmin.CountrysId;
                meals.MainIngredientsId = requestByAdmin.MainIngredientsId;
                _db.Meals.Add(meals);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool AddIngredient(AddIngredientRequestByAdmin request)
        {
            if (request != null)
            {
                MainIngredients addingIngredient = new MainIngredients();
                addingIngredient.MainIngredientDescription = request.MainIngredientDescription;
                addingIngredient.MainIngredientImageUrl = request.MainIngredientImage;
                addingIngredient.MainIngredientName = request.MainIngredientName;
                _db.MainIngredients.Add(addingIngredient);
                _db.SaveChanges();
                return true;
            }
            return false;
        }
        public List<MealsDTO> GetSearchedMealsByFirstLetter(SearchRequestDTO request)
        {
            List<MealsDTO> MealsListByFirstLetter = new List<MealsDTO>();
            if (request != null)
            {
                var meals = _db.Meals.ToList();
                foreach (var item in meals)
                {
                    if (item.MealName.StartsWith(request.SearchKeyWord.ToUpper()) || item.MealName.StartsWith(request.SearchKeyWord.ToLower()))
                    {
                        MealsListByFirstLetter.Add(new MealsDTO()
                        {
                            MealName = item.MealName,
                            MealId = item.Id,
                            MealUrl = item.MealImageUrl,
                            MealDescription = item.MealDescription
                        }
                        );
                    }
                }
            }
            return MealsListByFirstLetter;
        }
    }
}