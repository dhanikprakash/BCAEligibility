namespace BCAEligibility.Validator
{
    public interface IValidator
    {
        IValidator successor { get; }
        void SetSuccessor(IValidator validator);
        bool ValidateRequest(BCARequest bCARequest);
    }
}
