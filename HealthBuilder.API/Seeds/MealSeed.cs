using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthBuilder.Core.Entities;
using HealthBuilder.Infrastructure;

namespace HealthBuilder.API.Seeds
{
    public partial class Seed
    {
        public static async Task SeedMeals(ApplicationContext context)
        {
            if (!context.Meals.Any())
            {
                var meals = new List<Meal>
                {
                    new Meal(){
                        Name = "Spaghetti Carbonara",
                        Calories = 413,
                        Carbohydrates = 34,
                        Fats = 46,
                        Proteins = 20,
                        Description = "Carbonara is an Italian pasta dish from Rome made with egg, hard cheese, cured pork, and black pepper. The dish arrived at its modern form, with its current name, in the middle of the 20th century.",
                        Mass = 400,
                        ImgSrc = "/meal-img/1.jpg"
                    },
                    new Meal(){
                        Name = "Dumplings",
                        Calories = 510,
                        Carbohydrates = 39,
                        Fats = 39,
                        Proteins = 22,
                        Description = "A dumpling is a delicious, bite-sized food that's made of savory ingredients wrapped in dough and cooked.",
                        Mass = 300,
                        ImgSrc = "/meal-img/2.jpg"
                    },
                    new Meal(){
                        Name = "Boiled Egg",
                        Calories = 70,
                        Carbohydrates = 0,
                        Fats = 65,
                        Proteins = 35,
                        Description = "An boiled boiled with uttermost accuracy, ideally with ideal internal viscosity and pleasantly hard on the outside ",
                        Mass = 70,
                        ImgSrc = "/meal-img/3.jpg"
                    },
                    new Meal(){
                        Name = "Creamy French Omelette",
                        Calories = 143,
                        Carbohydrates = 5,
                        Fats = 62,
                        Proteins = 33,
                        Description = "A dish created by gods, golden the light of the midsummer sun and bouncy like the clouds in the sky",
                        Mass = 300,
                        ImgSrc = "/meal-img/4.jpg"
                    },
                    new Meal(){
                        Name = "Pepperoni Pizza",
                        Calories = 444,
                        Carbohydrates = 38,
                        Fats = 46,
                        Proteins = 16,
                        Description = "A dough ball is all that it takes to overwrite a bad day with happiest experiences",
                        Mass = 400,
                        ImgSrc = "/meal-img/5.jpg"
                    },
                    new Meal(){
                        Name = "Pilaf",
                        Calories = 161,
                        Carbohydrates = 75,
                        Fats = 15,
                        Proteins = 10,
                        Description = "Steamy rice combined with flavourful lamb, soft carrot, golden onion and spicy pepper",
                        Mass = 400,
                        ImgSrc = "/meal-img/6.jpg"
                    },
                    new Meal(){
                        Name = "Big Tasty",
                        Calories = 878,
                        Carbohydrates = 24,
                        Fats = 54,
                        Proteins = 22,
                        Description = "No diet can withstand a blow from this creamy bad boy",
                        Mass = 350,
                        ImgSrc = "/meal-img/7.jpg"
                    },
                    new Meal(){
                        Name = "Mac Nuggets",
                        Calories = 255,
                        Carbohydrates = 28,
                        Fats = 54,
                        Proteins = 17,
                        Description = "Golden Boys are really your best company during a late night visit to MacDonalds after a good night out",
                        Mass = 200,
                        ImgSrc = "/meal-img/8.jpg"
                    },
                    new Meal(){
                        Name = "Caesar Salad",
                        Calories = 640,
                        Carbohydrates = 10,
                        Fats = 73,
                        Proteins = 17,
                        Description = "Really the best salad there is. Combines soft grilled chicken breasts with crunchy toasts and Parmegiano Regano",
                        Mass = 250,
                        ImgSrc = "/meal-img/9.jpg"
                    },
                    new Meal(){
                        Name = "Sweet Mashed Potatoes",
                        Calories = 131,
                        Carbohydrates = 28,
                        Fats = 54,
                        Proteins = 17,
                        Description = "Golden Boys are really your best company during a late night visit to MacDonalds after a good night out",
                        Mass = 130,
                        ImgSrc = "/meal-img/10.jpg"
                    },
                    new Meal(){
                        Name = "Mashed Potatoes",
                        Calories = 126,
                        Carbohydrates = 91,
                        Fats = 1,
                        Proteins = 8,
                        Description = "Sweet Potatoes boiled and mashed with sour cream and butter",
                        Mass = 130,
                        ImgSrc = "/meal-img/11.jpg"
                    },
                    new Meal(){
                        Name = "Apple Pie",
                        Calories = 296,
                        Carbohydrates = 56,
                        Fats = 40,
                        Proteins = 4,
                        Description = "A dessert that represents american traditions.",
                        Mass = 125,
                        ImgSrc = "/meal-img/12.jpg"
                    },
                    new Meal(){
                        Name = "Apfel Strudel",
                        Calories = 240,
                        Carbohydrates = 52,
                        Fats = 43,
                        Proteins = 5,
                        Description = "Best invention of Austrian nation. Period.",
                        Mass = 100,
                        ImgSrc = "/meal-img/13.jpg"
                    },
                    new Meal(){
                        Name = "Beef Steak",
                        Calories = 173,
                        Carbohydrates = 2,
                        Fats = 18,
                        Proteins = 80,
                        Description = "Man's gotta eat meat",
                        Mass = 100,
                        ImgSrc = "/meal-img/14.jpg"
                    }
                };
                await context.Meals.AddRangeAsync(meals);
                await context.SaveChangesAsync();
            }
        }
    }
}