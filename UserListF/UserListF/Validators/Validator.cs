using System.Text.RegularExpressions;

namespace UserListF.Validators
{
    public abstract class Validator
    {
        public abstract bool validate(string toValidate);
    }
}