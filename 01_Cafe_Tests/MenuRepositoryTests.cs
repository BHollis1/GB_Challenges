using System;
using System.Collections.Generic;
using _01_Cafe_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _01_Cafe_Tests
{
    [TestClass]
    public class MenuRepositoryTests
    {
        [TestMethod]
        public void AddNewMenuItems_ShouldReturnCorrectBoolean()
        {
            Menu newMenuItems = new Menu();
            MenuRepository repository = new MenuRepository();

            bool wasCreated = repository.AddNewMenuItems(newMenuItems);
            Assert.IsTrue(wasCreated);
        }
        [TestMethod]
        public void GetMenuItems_ShouldReturnAllItemsInCollection()
        {
            Menu newObject = new Menu();
            MenuRepository repo = new MenuRepository();
            repo.AddNewMenuItems(newObject);

            List<Menu> listOfMenuItems = repo.GetMenuItems();

            bool menuDirectoryHasNewItems = listOfMenuItems.Contains(newObject);
            Assert.IsTrue(menuDirectoryHasNewItems);
        }

        private MenuRepository _repo;
        private Menu _content;
        [TestInitialize]

        public void Arrange()
        {
            _repo = new MenuRepository();
            _content = new Menu(1, "Hamburger", "100% Angus Beef", "lettuce, mayo, onion, cheese, bacon, tomato, pickle", 6);
            _repo.AddNewMenuItems(_content);

        }
        [TestMethod]
        public void DeleteMenuItems_ShouldReturnTrue()
        {
            Menu foundMenuItem = _repo.GetMenuItemsByName("hamburger");
            bool removeMenuItem = _repo.DeleteMenuItemFromList("hamburger");
            Assert.IsTrue(removeMenuItem);

        }
    }
}

