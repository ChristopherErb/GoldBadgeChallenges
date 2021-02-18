using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe_Repo
{
    public class KomodoCafeRepo
    {
        private readonly List<KomodoCafeMenu> _directory = new List<KomodoCafeMenu>();

        public int mealNum
        {
            get
            {
                return _directory.Count();
            }
        }

        //Create
        //Read
        //Update
        //Delete


        //Adds content
        public bool AddContentToDirectory(KomodoCafeMenu content)
        {
            int startingCount = _directory.Count;
            _directory.Add(content);
            bool wasAdded = _directory.Count > startingCount;
            return wasAdded;
        }


        public List<KomodoCafeMenu> GetContents()
        {
            return _directory;
        }



        //Get information by meal number
        public KomodoCafeMenu getInfoByNumber(int MealNum)
        {

           foreach ( KomodoCafeMenu content in _directory)
            {
                if (MealNum == content.MealNum)
                {
                    return content;
                }

            }
            // console write this
            throw new Exception("You've picked an invalid meal number");
        }


       //Update Menu

        public bool UpdateExistingMenu(int originalNum, KomodoCafeMenu newNum)
        {
            KomodoCafeMenu oldNum = getInfoByNumber(originalNum);
            if (oldNum != null)
                {
                oldNum.MealNum = newNum.MealNum;
                oldNum.MealName = newNum.MealName;
                oldNum.Ingredients = newNum.Ingredients;
                oldNum.MealDesc = newNum.MealDesc;
                oldNum.Price = newNum.Price;
                return true;
                }

             return false;
         }


        //Delete Menu item

        public bool DeleteContent(int MealNum)
        {

            KomodoCafeMenu contentToDelete = getInfoByNumber(mealNum);
            return _directory.Remove(contentToDelete);

        }
       
    }
}
