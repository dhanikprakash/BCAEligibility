namespace BCAEligibility.Validator
{
    public class TimeInBusinessValidator : IValidator
    {
        public IValidator successor { get; private set; }
        public void SetSuccessor(IValidator validator)
        {
            successor = validator;
        }
        public bool ValidateRequest(BCARequest bCARequest)
        {
            var result = false;
            if (bCARequest.TimeInBusiness?.Years >= 1 || bCARequest.TimeInBusiness?.Months >= 12)
            {
                result = true;
            }
            if (result && successor != null)
            {
                return successor.ValidateRequest(bCARequest);
            }
            return result;
        }
    }
}
