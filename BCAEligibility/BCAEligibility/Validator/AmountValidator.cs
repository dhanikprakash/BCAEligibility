namespace BCAEligibility.Validator
{
    public class AmountValidator : IValidator
    {
        public IValidator successor { get; private set; }
        public void SetSuccessor(IValidator validator)
        {
            successor = validator;
        }
        public bool ValidateRequest(BCARequest bCARequest)
        {
            var result = false;
            if (bCARequest.AmountRequested >= 5000 && bCARequest.AmountRequested < 50000)
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
