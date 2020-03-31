using System.Text.RegularExpressions;

namespace UserListF.Validators
{
    public class StringValidator:Validator
    {
        public int MinLength = 5;
        public int MaxLength = 12; 

        private string pattern = @"^[\S\s]{5,12}$";
        
        public override bool validate(string toValidate)
        {
            Regex regex = new Regex(pattern);

            if (regex.IsMatch(toValidate))
            {
                return true;
            }
            
            return false; 
        } 
    }
}