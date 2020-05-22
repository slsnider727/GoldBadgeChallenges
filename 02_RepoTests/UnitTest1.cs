using System;
using _02_Claims;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_RepoTests
{
    [TestClass]
    public class UnitTest1
    {
        public ClaimRepository _claimRepo = new ClaimRepository();
        [TestInitialize]
        public void SeedRepository()
        {
            Claim one = new Claim(1, ClaimType.Car, "rolled into a ditch", 500.00m, new DateTime(2020,04,23), new DateTime(2020,04,25));
            Claim two = new Claim(2, ClaimType.Home, "house fire in kitchen", 4000.00m, new DateTime(2018,04, 11), new DateTime (2018,04, 23));
            Claim three = new Claim(3, ClaimType.Theft, "stolen pancakes", 4.00m, new DateTime(2018,04,27), new DateTime(2019,05,29));

            _claimRepo.AddClaim(one);
            _claimRepo.AddClaim(two);
            _claimRepo.AddClaim(three);
        }
        [TestMethod]
        public void SeeAllClaimsShouldShowAllClaims()
        {
            _claimRepo.SeeAllClaims();
        }
        [TestMethod]
        public void EnterANewClaimShouldIncreaseCount()
        {
            int expected = 3;
            int actual = _claimRepo.GetAllClaims().Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetNextClaimShouldShowNextInQueue()
        {          
            int expected = 1;
            int actual = _claimRepo.GetNextClaim().ClaimID;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void DequeueShouldDecreaseCount()
        {
            _claimRepo.DequeueClaim();
            int expected = 2;
            int actual = _claimRepo.GetAllClaims().Count;
            Assert.AreEqual(expected, actual);
        }
    }
}
