using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges_Repository
{
    public class BadgesRepository
    {
        private Dictionary<int, List<string>> _doorCodes = new Dictionary<int, List<string>>();
        

        //C
        public void AddNewbadge(Badges badge)
        {
            _doorCodes.Add(badge.BadgeID, badge.DoorAccess);
        }

        //R
        public Dictionary<int, List<string>> GetListOfbadges()
        {
            return _doorCodes;
        }
        
        //Get By badge number / used for update

        //U
        public void UpdateBadge(int badgeID, string doorAccess)
        {
            List<string> doors = _doorCodes[badgeID];

            doors.Add(doorAccess);
        }

        //D

        public void RemoveADoor(int badgeID, string doorAccess)
        {
            List<string> doors = _doorCodes[badgeID];
            doors.Remove(doorAccess);
        }
    }
}
