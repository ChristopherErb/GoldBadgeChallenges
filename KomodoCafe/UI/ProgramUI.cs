using KomodoCafe_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    class ProgramUI
        //Create
        //Read
        //Update
        //Delete
    {
        private readonly KomodoCafeRepo _repo = new KomodoCafeRepo();

        public void Run()
        {
            //CurrentMenuList();
            RunMenu();
        }


        private void RunMenu()
        {
            bool menuRunning = true;
            while (menuRunning)
            {
                //create items
                //delete items
                //list of items
                Console.Clear();
                Console.WriteLine("Welcome to Komodo Cafe! \n" +
                    "Please enter the number of the option you'd like to select:\n"+
                    "0. Exit \n" +
                    "1. A list of current products\n" +
                    "2. Delete products\n" +
                    "3. Create a new product\n" +
                    "4. Update Existing product\n");
                string userSelection = Console.ReadLine();
                switch (userSelection)
                {
                    case "0":
                        menuRunning = false;
                        break;
                    case "1":
                        //List current products
                        DisplayEntireMenu();
                        break;
                    case "2":
                        //Delete a product
                        RemoveFromMenu();
                        break;
                    case "3":
                        //Create a new product
                        CreateMenuItem();
                        break;
                    case "4":
                        //update existing product
                        UpdateMenu();
                        break;



                }
            }
        }


      /*  MealNum = mealNum;
            MealName = mealName;
            MealDesc = mealDesc;
            Ingredients = ingredients;
            Price = price;*/


        //case 1

        private void DisplayEntireMenu()
        {
            Console.Clear();
            List<KomodoCafeMenu> listOfItems = _repo.GetContents();
            foreach (KomodoCafeMenu content in listOfItems)
            {
                DisplayMenu(content);
            }
            Console.ReadKey();
        }
        private void DisplayMenu (KomodoCafeMenu content)
        {
            Console.WriteLine(
                $"Number: {content.MealNum} \n"+
                $"Name: {content.MealName}\n"  +
                $"Description: {content.MealDesc}\n" + 
                $"Ingredients: {content.Ingredients}\n" +
                $"Price: {content.Price}\n");
        }


        //case 2

        private void RemoveFromMenu()
        {

            Console.Clear();
            Console.WriteLine("What is the number of the item you'd like to remove?");

            List<KomodoCafeMenu> listOfItems = _repo.GetContents();
            int count = 0;
            //shows list of meal numbers
            foreach (KomodoCafeMenu content in listOfItems)
            {
                count++;
                Console.WriteLine($"{count}.{content.MealNum}");
            }

            //prompt and select

            int targetMenuItem = int.Parse(Console.ReadLine());
            int targetIndex = targetMenuItem - 1;

            if(targetIndex >= 0 && targetIndex < listOfItems.Count)
            {
                KomodoCafeMenu desiredContent = listOfItems[targetIndex];

                if (_repo.DeleteContent(desiredContent.MealNum))
                {
                    Console.WriteLine($"Meal number {desiredContent.MealNum} was successfully removed");
                }
                else
                {
                    Console.WriteLine("Please enter a valid selection");
                }

            }
            else
            {
                Console.WriteLine("That meal ID doesn't exist");
            }
            Console.ReadKey();
        }

        //case 3
        private void CreateMenuItem()
        {
           Console.Clear();
            KomodoCafeMenu content = new KomodoCafeMenu();
            //Meal Number
            Console.WriteLine("Please enter the new item's number");
            content.MealNum = Convert.ToInt32(Console.ReadLine());
            //Meal Name
            Console.WriteLine("Please enter the item's name");
            content.MealName = Console.ReadLine();
            //Meal Description
            Console.WriteLine("Please describe the new item");
            content.MealDesc = Console.ReadLine();
            //Ingredients
            Console.WriteLine("Please list the ingredients for the new item");
            content.Ingredients = Console.ReadLine();
            //Price
            Console.WriteLine("Please list the price for the new item");
            content.Price = Convert.ToDecimal(Console.ReadLine());
            _repo.AddContentToDirectory(content);
        }

        //case 4

        private int getNumberFromUser()
        {
            Console.Clear();
            Console.WriteLine("Please enter a meal number");
            int MealNum = Convert.ToInt32
                (Console.ReadLine());
            return MealNum;
        }
        private void UpdateMenu()
        {
            KomodoCafeMenu content;
            do
            {
                int MealNum = getNumberFromUser();
                content = _repo.getInfoByNumber(MealNum);
                if (MealNum == 9)
                {
                    return;
                }
            }
            while (content == null);
            Console.WriteLine("Which would you like to update? \n" +
                "1. Meal Number \n" +
                "2. Meal Name \n" +
                "3. Meal Description \n" +
                "4. Meal Ingredients \n" +
                "5. Meal Price \n" );

            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Please enter the meal's new number");
                    int newMealNum = Convert.ToInt32(Console.ReadLine());
                    content.MealNum = newMealNum;
                    break;
                case 2:
                    Console.WriteLine("Pleae enter the meal's new name");
                    string newMealName = Console.ReadLine();
                    content.MealName = newMealName;
                    break;
                case 3:
                    Console.WriteLine("Please enter the meal's new description");
                    string newMealDesc = Console.ReadLine();
                    content.MealDesc = newMealDesc;
                    break;
                case 4:
                    Console.WriteLine("Please enter the meal's new ingredients");
                    string newMealInged = Console.ReadLine();
                    content.Ingredients = newMealInged;
                    break;
                case 5:
                    Console.WriteLine("Please enter the meal's new price");
                    decimal newMealPrice = Convert.ToDecimal(Console.ReadLine());
                    content.Price = newMealPrice;
                    break;
            }






        }






        }


    }

