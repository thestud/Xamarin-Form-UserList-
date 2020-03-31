using System.Text.RegularExpressions;
using System; 

namespace UserListF.Validators
{
    public class LettersAndNumbersValidator : Validator
    {
        // A-Za-z0-9_@./#&+-
        // these should have worked, but don't
        // (?=.*\d)(?=.*[a-zA-Z]).
        // ^(?=.*[A-Za-z])(?=.*\d).$
        
        private string pattern1 = @"^([A-Za-z$-_]+)(\d+)$";
        private string pattern2 = @"^(\d+)([A-Za-z$-_]+)$";
        public override bool validate(string toValidate)
        {
            Regex regex = new Regex(pattern1);
            Regex regex2 = new Regex(pattern2);

            if (regex.IsMatch(toValidate))
            {
                return true;
            } else if(regex2.IsMatch(toValidate)) {
                return true; 
            }
            
            return false; 
        }
    }
}