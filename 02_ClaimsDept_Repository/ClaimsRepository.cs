using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ClaimsDept_Repository
{
    public class ClaimsRepository
    {
        protected readonly Queue<Claims> _claimDirectory = new Queue<Claims>();
        public bool AddNewClaim(Claims content)
        {
            int startingCount = _claimDirectory.Count;
            _claimDirectory.Enqueue(content);
            bool wasAdded = (_claimDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }
        
        public Queue<Claims> GetClaims()
        {
            return _claimDirectory;
        }

        public Claims GetClaimByClaimID(int claimID)
        {
            foreach (Claims singleClaim in _claimDirectory)
            {
                if (singleClaim.ClaimID == claimID)
                {
                    return singleClaim;
                }
            }
            return null;
        }

        public bool UpdateExistingClaim(int originalClaimID, Claims newClaimInfo)
        {
            Claims oldClaimInfo = GetClaimByClaimID(originalClaimID);

            if (oldClaimInfo != null)
            {
                oldClaimInfo.ClaimID = newClaimInfo.ClaimID;
                oldClaimInfo.ClaimType = newClaimInfo.ClaimType;
                oldClaimInfo.Description = newClaimInfo.Description;
                oldClaimInfo.ClaimAmount = newClaimInfo.ClaimAmount;
                oldClaimInfo.DateOfIncident = newClaimInfo.DateOfIncident;
                oldClaimInfo.DateOfClaim = newClaimInfo.DateOfClaim;
                oldClaimInfo.IsValid = newClaimInfo.IsValid;

                return true;
            }
            {
                return false;
            }
        }







    }


}
    
