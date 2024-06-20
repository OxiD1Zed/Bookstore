using System.Text.RegularExpressions;

namespace Bookstore.common.data.services
{
    public class UserService
    {
        public bool ValidatingLogin(string login)
        {
            Regex hasEmail = new Regex(@"^\w+([.-]?\w+)+@\w+([-]?\w+)(\.\w{2,})$");
            return hasEmail.IsMatch(login);
        }

        public bool ValidatingPassword(string password)
        {
            return ValidatingPasswordsLength(password) &&
                ValidatingPasswordHasLowerChar(password) &&
                ValidatingPasswordHasUpperChar(password) &&
                ValidatingPasswordHasDigitChar(password) && 
                ValidatingPasswordHasSpecialSymbol(password);
        }

        public bool ValidatingPasswordsLength(string password)
        {
            Regex hasEightChars = new Regex(@"^.{8,}$");
            return hasEightChars.IsMatch(password);
        }

        public bool ValidatingPasswordHasUpperChar(string password)
        {
            Regex hasUpChar = new Regex(@"^.*[A-Z]{1,}.*$");
            return hasUpChar.IsMatch(password);
        }

        public bool ValidatingPasswordHasLowerChar(string password)
        {
            Regex hasLowChar = new Regex(@"^.*[a-z]{1,}.*$");
            return hasLowChar.IsMatch(password);
        }

        public bool ValidatingPasswordHasDigitChar(string password)
        {
            Regex hasDigit = new Regex(@"^.*\d{1,}.*$");
            return hasDigit.IsMatch(password);
        }

        public bool ValidatingPasswordHasSpecialSymbol(string password)
        {
            Regex hasSpecial = new Regex(@"^.*[!@#\$%\^\&*\)\(+=._-].*$");
            return hasSpecial.IsMatch(password);
        }
    }
}
