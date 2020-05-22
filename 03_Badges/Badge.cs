using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges
{
    public class Badge
    {
        public int BadgeID { get; set; }
        public List<string> AccessibleDoors { get; set; } = new List<string>();

        public Badge()
        {

        }
    public Badge(
        int badgeID,
        List<string> accessibleDoors)
    {
        BadgeID = badgeID;
        AccessibleDoors = accessibleDoors;
    }
    }
}
