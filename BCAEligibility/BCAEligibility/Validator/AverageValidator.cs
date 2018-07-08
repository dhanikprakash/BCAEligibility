using System.Linq;

namespace BCAEligibility.Validator
{
    public class AverageValidator : IValidator
    {
        public IValidator successor { get; private set; }
        public void SetSuccessor(IValidator validator)
        {
            this.successor = validator;
        }
        public bool ValidateRequest(BCARequest bCARequest)
        {
            var result = false;
            if (IsValidAverage(bCARequest))
            {
                result = true;
            }
            if (result && successor != null)
            {
                return successor.ValidateRequest(bCARequest);
            }
            return result;
        }

        private bool IsValidAverage(BCARequest bCARequest)
        {
            var transactions = bCARequest.transactions
                .GroupBy(item => new { Year = item.Date.Year, Month = item.Date.Month })
                .Select(x => new { Year = x.Key.Year, Month = x.Key.Month, Avvg = x.Average(a => a.Value)
                });
            return !transactions.Any(x => x.Avvg < bCARequest.AmountRequested);

        }
    }
}
