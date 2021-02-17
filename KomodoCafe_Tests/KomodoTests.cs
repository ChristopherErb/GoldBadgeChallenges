using KomodoCafe_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace KomodoCafe_Tests
{
    [TestClass]
    public class KomodoTests

    {
        private KomodoCafeRepo _repo;
        private KomodoCafeMenu _menu;
        private KomodoCafeMenu burger;

        [TestInitialize]
        public void Seed()
        {
            _repo = new KomodoCafeRepo();
            burger = new KomodoCafeMenu(
                1, "BurgerMeal", "Big Burger Meal", "Flour, cow", 55.55m
                );
            KomodoCafeMenu Chicken = new KomodoCafeMenu(
                2,
                "Chicken Meal",
                "Spicky chicken sammich",
                "flour, chicken, spice",
                66.66m);
            _repo.AddContentToDirectory(burger);
            _repo.AddContentToDirectory(Chicken);
        }


        [TestMethod]
        public void DeletedContent_ShouldBeDeleted()
        {
            bool wasRemoved = _repo.DeleteContent(1);
            Assert.IsTrue(wasRemoved);
          //  bool wasAlsoRemoved = _repo.DeleteContent(2);
          //  Assert.IsFalse(wasAlsoRemoved);

        }

        [TestMethod]
        public void SetPrice_CorrectPrice()
        {

            KomodoCafeMenu content = new KomodoCafeMenu();
            content.Price = 66.66m;
            decimal expected = 66.66m;
            decimal actual = content.Price;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void SetNumber_CorrectNum()
        {

            KomodoCafeMenu content = new KomodoCafeMenu();
            content.MealNum = 1;
            int expected = 1;
            int actual = content.MealNum;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void SetName_CorrectName()
        {
            KomodoCafeMenu content = new KomodoCafeMenu();
            content.MealName = "Burger1";
            string expected = "Burger1";
            string actual = content.MealName;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void setIngred_CorrectIngred()
        {
            KomodoCafeMenu content = new KomodoCafeMenu();
            content.Ingredients = "Cow, Flour";
            string expected = "Cow, Flour";
            string actual = content.Ingredients;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void setDesc_CorrectDesc()
        {
            KomodoCafeMenu content = new KomodoCafeMenu();
            content.MealDesc = "Best Burger Ever";
            string expected = "Best Burger Ever";
            string actual = content.MealDesc;
            Assert.AreEqual(expected, actual);
        }






    }
}
