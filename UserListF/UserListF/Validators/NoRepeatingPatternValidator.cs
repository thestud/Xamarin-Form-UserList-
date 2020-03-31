using System.Text.RegularExpressions;

namespace UserListF.Validators
{
    
    public class NoRepeatingPatternValidator : Validator
    {
        private string patternForMatches = @"([A-Za-z0-9]{2,})\1";
        public override bool validate(string toValidate)
        {
            Regex regexForMatches = new Regex(patternForMatches);

            MatchCollection matches = regexForMatches.Matches(toValidate);

            if(matches.Count > 0)
            {
                return false;
            } 

            return true; 
        }
    }
}