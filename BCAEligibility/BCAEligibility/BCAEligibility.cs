using BCAEligibility.Validator;
using Newtonsoft.Json;

namespace BCAEligibility
{
    public class BCAEligibility
    {
        private AmountValidator amountValidator;
        private AverageValidator averageValidator;
        private TimeInBusinessValidator timeInBusinessValidator;
        private HigherAmountValidation higherAmountValidation;
        private BCARequest bcaRequest { get; set; }

        public BCAEligibility()
        {
            amountValidator = new AmountValidator();
            averageValidator = new AverageValidator();
            timeInBusinessValidator = new TimeInBusinessValidator();
            higherAmountValidation = new HigherAmountValidation();
            InitConfiguration();
        }

        private void InitConfiguration()
        {
            amountValidator.SetSuccessor(averageValidator);
            averageValidator.SetSuccessor(timeInBusinessValidator);
            timeInBusinessValidator.SetSuccessor(higherAmountValidation);
        }

        public string BCACheckEligibility(string jsonRequest)
        {
            bcaRequest = JsonConvert.DeserializeObject<BCARequest>(jsonRequest);
            var result = amountValidator.ValidateRequest(bcaRequest);
            return result ? "Eligible" : "Ineligible";
        }
    }



}
