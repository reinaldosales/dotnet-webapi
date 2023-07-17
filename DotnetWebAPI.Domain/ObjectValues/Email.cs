using System.Text.RegularExpressions;

namespace DotnetWebAPI.ObjectValues
{
    public class Email
    {
        protected Email() { }

        public Email(string address)
        {
            if (string.IsNullOrEmpty(address) || address.Length < 5)
                throw new ArgumentNullException("Email invalid");

            Address = address.ToLower().Trim();
            const string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

            if (!Regex.IsMatch(address, pattern))
                throw new ArgumentNullException("Email invalid");
        }

        public string Address { get; }
    }
}
