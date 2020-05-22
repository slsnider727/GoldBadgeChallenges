using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class BadgeRepository
    {
        public Dictionary<int, List<string>> _badgeRepository = new Dictionary<int, List<string>>();

        //Determine if dictionary contains key
        public bool ContainsKey(int key)
        {
            bool keyExists = _badgeRepository.ContainsKey(key);
            if (keyExists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Create - Add badge to dictionary
        public void CreateNewBadge(int badgeID)
        {
            List<string> accessibleDoors = new List<string>();
            Badge myBadge = new Badge(badgeID, accessibleDoors);
            if (!ContainsKey(badgeID))
            {
                _badgeRepository.Add(myBadge.BadgeID, myBadge.AccessibleDoors);
            }
            else
            {
                Console.WriteLine("This badge already exists.");
            }
        }
        //Author Notes
        //List<string> doorsForBadge12345 = _badgeRepository[12345];
        //_badgeRepository[12345] This syntax refers to the List<string>; it refers to the VALUE.

        //Add Door Access to Badge
        public void AddAccessToBadge(int badgeID, string newDoor)
        {
            _badgeRepository[badgeID].Add(newDoor);
        }
        //Remove Door from existing badge
        public void RemoveDoorFromBadge(int badgeID, string door)
        {
            _badgeRepository[badgeID].Remove(door);
        }
        //Delete all doors from existing badge
        public void EraseAllAccess(int badgeID)
        {
            _badgeRepository[badgeID].Clear();
        }
        //Get all badges
        public Dictionary<int, List<string>> GetAllBadges()
        {
            return _badgeRepository;
        }
        //View all badges in console
        public void SeeAllBadges()
        {
            Console.WriteLine("Key\n");
            Console.WriteLine($"{"Badge ID",-12}{"Door Access"}");
            foreach (KeyValuePair<int, List<string>> badge in _badgeRepository)
            {
                Console.Write($"{badge.Key,-12}");
                string joined = string.Join(", ", badge.Value.ToArray());
                Console.Write($"{joined}\n");
            }
        }
        //Get badge's value list by ID
        public List<string> GetBadgeDoors(int badgeID)
        {
            List<string> doorsFromBadge = _badgeRepository[badgeID];
            return doorsFromBadge;
        }
        //Print one badge to console, for edit page so Admin can see what they're working with
        public void SeeOneBadge(int badgeID)
        {
            foreach (KeyValuePair<int, List<string>> badge in _badgeRepository)
            {
                if (badge.Key == badgeID)
                {
                    Console.WriteLine($"{badge.Key,-12}");
                    string joined = string.Join(", ", badge.Value.ToArray());
                    Console.Write($"{joined}\n");
                }
            }
        }
    }
}
