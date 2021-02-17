using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repo.Content
{
    class Meal : KomodoCafeMenu
    {

        public Meal(
            int mealNum,
            string mealName,
            string mealDesc,
            string ingredients,
            decimal price)
            : base
                  (mealNum,
                  mealName,
                  mealDesc,
                  ingredients
                  , price)
        {
        
        //List of "ingredients" goes here if i can figure out how to put a list in

        }




    }
}
