namespace Check
{
    public class CheckPassword
    {
        private string _symbols1;
        private string _symbols2;
        private string _symbols3;
        private string _symbols4;
        private string _alphabet;

        private int _minLength;

        public CheckPassword()
        {
            _symbols1 = "qwertyuiopasdfghjklzxcvbnm";
            _symbols2 = "QWERTYUIOPASDFGHJKLZXCVBNM";
            _symbols3 = "!.,-_=:;@#$%";
            _symbols4 = "0123456789";

            _alphabet = _symbols1 + _symbols2 + _symbols3 + _symbols4;

            _minLength = 8;
        }

        public CheckPassword(string symbols1, string symbols2, string symbols3, string symbols4, int minLength)
        {
            _symbols1 = symbols1;
            _symbols2 = symbols2;
            _symbols3 = symbols3;
            _symbols4 = symbols4;
            
            _alphabet = _symbols1 + _symbols2 + _symbols3 + _symbols4;
            
            _minLength = minLength;
        }

        public bool MinLength(string password)
        {
            return password.Length >= _minLength;
        }

        public bool Difficult(string password)
        {
            var check1 = password.IndexOfAny(_symbols1.ToCharArray());
            var check2 = password.IndexOfAny(_symbols2.ToCharArray());
            var check3 = password.IndexOfAny(_symbols3.ToCharArray());
            var check4 = password.IndexOfAny(_symbols4.ToCharArray());

            return check1 != -1 && check2 != -1 && check3 != -1 && check4 != -1;
        }

        public bool CheckAlphabet(string password)
        {
            foreach (var symbol in password)
            {
                var check = _alphabet.Contains(symbol);
                if (!check)
                {
                    return false;
                }
            }

            return true;
        }
    }
}