using System;
using System.Collections.Generic;
using System.Text;

namespace RentalSports.Domain.Provider
{
    public class EncryptProvider
    {
        private readonly string _secret;

        const string format = "x2";

        public EncryptProvider(string secret)
        {
            _secret = secret;
        }

        public string EncryptPassword(string password)
        {
            var md5Cripto = System.Security.Cryptography.MD5.Create();
            var encryptedPassowrd = new StringBuilder();

            encryptedPassowrd.Clear();
            var hash = md5Cripto.ComputeHash(Encoding.Default.GetBytes(password + _secret));

            foreach (var h in hash)
                encryptedPassowrd.Append(h.ToString(format));

            return encryptedPassowrd.ToString();
        }

        public bool PasswordMatch(string password, string encryptedPassword)
        {
            string passwordToCompare = EncryptPassword(password);

            return passwordToCompare == encryptedPassword;
        }
    }
}
