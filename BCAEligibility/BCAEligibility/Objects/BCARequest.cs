using System.Collections.Generic;

namespace BCAEligibility
{
    public class BCARequest
    {
        public int AmountRequested { get; set; }
        public TimeInBusiness TimeInBusiness { get; set; }
        public List<Transactions> transactions = new List<Transactions>();
    }
}
