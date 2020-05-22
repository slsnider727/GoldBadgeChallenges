using System;
using System.Collections.Generic;
using _03_Badges;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_RepoTests
{
    [TestClass]
    public class UnitTest1
    {
        public BadgeRepository _badgeRepo = new BadgeRepository();

        [TestInitialize]
        public void SeedRepository()
        {
            _badgeRepo.CreateNewBadge(123);
            _badgeRepo.CreateNewBadge(55);
            _badgeRepo.CreateNewBadge(743);
            _badgeRepo.AddAccessToBadge(123, "A5");
            _badgeRepo.AddAccessToBadge(123, "B2");
            _badgeRepo.AddAccessToBadge(123, "B4");
            _badgeRepo.AddAccessToBadge(743, "B9");
        }
        [TestMethod]
        public void CreateNewBadgeShouldIncreaseDictionaryCount()
        {
            int actual = _badgeRepo.GetAllBadges().Count;
            int expected = 3;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void CreateNewBadgeShouldPreventDuplicate()
        {
            _badgeRepo.CreateNewBadge(123);
            int actual = _badgeRepo.GetAllBadges().Count;
            int expected = 3;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void AddAccessToBadgeShouldMakeBadgeValueCountIncrease()
        {
            _badgeRepo.AddAccessToBadge(55, "A5");
            int actual = _badgeRepo.GetBadgeDoors(55).Count;
            int expected = 1;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void RemoveDoorFromBadgeShouldReduceValueCount()
        {
            _badgeRepo.RemoveDoorFromBadge(123, "A5");
            int expected = 2;
            int actual = _badgeRepo.GetBadgeDoors(123).Count;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void EraseAllAccessShouldSetBadgeValueCountToZero()
        {
            _badgeRepo.EraseAllAccess(743);
            int actual = _badgeRepo.GetBadgeDoors(743).Count;
            int expected = 0;
            Assert.AreEqual(actual, expected);
        }
        [TestMethod]
        public void SeeAllBadgesShouldDisplayAllBadges()
        {
            _badgeRepo.SeeAllBadges();
        }
        [TestMethod]
        public void SeeOneBadgeShouldShowFoundBadge()
        {
            _badgeRepo.SeeOneBadge(55);
        }
    }
}
