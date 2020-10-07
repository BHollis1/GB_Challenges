using System;
using System.Collections.Generic;
using _02_ClaimsDept_Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_ClaimsDept_Tests
{
    [TestClass]
    public class ClaimRepositoryTests
    {
        [TestMethod]
        public void AddNewClaim_ShouldReturnCorrectBoolean()
        {
            Claims content = new Claims();
            ClaimsRepository repository = new ClaimsRepository();
            bool addResult = repository.AddNewClaim(content);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void GetClaims_ShouldReturnCorrectCollection()
        {
            Claims newClaim = new Claims();
            ClaimsRepository repo = new ClaimsRepository();
            repo.AddNewClaim(newClaim);

            Queue<Claims> listOfClaims = repo.GetClaims();

            bool repoHasClaims = listOfClaims.Contains(newClaim);
            Assert.IsTrue(repoHasClaims);
        
        }

        private ClaimsRepository _repo;
        private Claims _content;
        [TestInitialize]

        public void Arrange()
        {
            _repo = new ClaimsRepository();
            _content = new Claims(1, "Car", "Car accident on 465.", 400.00m, new DateTime(4 / 25 / 18), new DateTime(4 / 27 / 18), true);
            _repo.AddNewClaim(_content);
        }


        [TestMethod]
        public void GetClaimByID_ShouldReturnCorrectContent()
        {
            Claims searchResult = _repo.GetClaimByClaimID(1);
            Assert.AreEqual(_content, searchResult);
        }
        [TestMethod]
        public void UpdateExistingClaim_ShouldReturnTrue()
        {
            Claims updatedClaim = new Claims(1, "Car", "Car accident on 465.", 400.00m, new DateTime(4/25/18),new DateTime(4/27/18), true);
            bool updateResult = _repo.UpdateExistingClaim(1, updatedClaim);
            Assert.IsTrue(updateResult);
        }
    }
}



