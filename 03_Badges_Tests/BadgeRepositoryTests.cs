using System;
using System.Collections.Generic;
using _03_Badges_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_Badges_Tests
{
    [TestClass]
    public class BadgeRepositoryTests
    {
        [TestMethod]
        public void AddContentToDictionary_ShouldReturnCorrectBoolean()
        {
            Badges content = new Badges();
            BadgesRepository repo = new BadgesRepository();

            bool addResult = _repo.AddContentToDictionary(content);
            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetContent_ShouldReturnCorrectCollection()
        {
            Badges newBadge = new Badges();
            BadgesRepository repository = new BadgesRepository();
            repository.AddContentToDictionary(newBadge);

            Dictionary<int, DoorNames> listOfContents = repository.GetContent();

            bool dictHasContent = listOfContents.ContainsKey(12345);
            Assert.IsTrue(dictHasContent);
        }
        private BadgesRepository _repo;
        private Badges _content;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgesRepository();
            _content = new Badges(12345, DoorNames.A1);
            _repo.AddContentToDictionary(_content);
        }

       

       

    }

}

