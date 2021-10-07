using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaims_Repository
{
    public class ClaimsRepository
    {
        public Queue<Claims> _claimQueue = new Queue<Claims>();

        //C
        public void AddClaimToQueue(Claims content)
        {
            _claimQueue.Enqueue(content);

        }

        //R
        public Queue<Claims> ViewClaimsInQueue()
        {
            return _claimQueue;
        }

        //U

        //D
        public void RemoveClaimFromQueue(int claimID)
        {
            //Claims content = ViewClaimsInQueue(claimID);
            //claimQueue.Dequeue(content);
        }

    }
}
