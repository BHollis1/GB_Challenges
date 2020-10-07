using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Badges_Repository
{
    public enum DoorNames
    {
        A1,
        A2,
        A3,
        A4,
        A5,
        A6,
        A7,
        B1,
        B2,
        B3,
        B4,
        B5
    }
    
    public class Badges
    {

        public int BadegeID { get; set; }
        public DoorNames DoorID { get; set; }

        public Badges() { }

        public Badges (int badgeID, DoorNames doorNames)
        {
            BadegeID = badgeID;
            DoorID = doorNames;
        }

    }
}
