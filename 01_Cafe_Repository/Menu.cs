using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe_Repository
{
    public class Menu
    {
            public int MealNumber { get; set; }
            public string MealName { get; set; }
            public string MealDescription { get; set; }
            public string ListOfIngredients { get; set; }
            public decimal MealPrice { get; set; }
            public Menu() { }
            public Menu(int mealNum, string mealName, string mealDesc, string listOfIng, decimal mealPrice)
            {
                MealNumber = mealNum;
                MealName = mealName;
                MealDescription = mealDesc;
                ListOfIngredients = listOfIng;
                MealPrice = mealPrice;
            }
        }
    }

