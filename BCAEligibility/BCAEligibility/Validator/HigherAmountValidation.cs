using System;
using System.Linq;

namespace BCAEligibility.Validator
{
    public class HigherAmountValidation : IValidator
    {
        public IValidator successor { get; private set; }

        public void SetSuccessor(IValidator validator)
        {
            successor = validator;
        }
        public bool ValidateRequest(BCARequest bCARequest)
        {
            var result = false;
            if (IsValidAmount(bCARequest, DateTime.UtcNow))
            {
                result = true;
            }
            if (result && successor != null)
            {
                return successor.ValidateRequest(bCARequest);
            }
            return result;
        }
        private bool IsValidAmount(BCARequest bCARequest, DateTime today)
        {
            var result = false;
            var startperiod = today.AddMonths(-11);
            if (bCARequest.AmountRequested < 25000)
            {
                result = true;
            }
            else
            {
                var transactions = bCARequest.transactions.OrderByDescending(x => x.Date)
                               .GroupBy(item => new { Year = item.Date.Year, Month = item.Date.Month })
                               .Select(x => new { Year = x.Key.Year, Month = x.Key.Month, Avvg = x.Average(a => a.Value) });

                if (transactions.Count() > 11 &&
                   transactions.Skip(11).Take(1).Select(x => new { Year = x.Year }).FirstOrDefault().Year == startperiod.Year
                        && transactions.Skip(11).Take(1).Select(x => new { Month = x.Month }).FirstOrDefault().Month == startperiod.Month)
                {
                    result = true;
                }
            }
            return result;

        }



    }


}
