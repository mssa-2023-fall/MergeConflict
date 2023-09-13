using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLogin {
    public class BadDatabase {
        public Dictionary<string, Customer> DB { get; set; } = new();

        public void AddCustomer(string email, string name, string password, string creditCard) {
            const int KEY_SIZE = 64;

            var salt = GenerateSalt(KEY_SIZE);
            var passwordHash = GetPasswordHash(password, salt, KEY_SIZE);

            DB.Add(email, new Customer(email, name, Convert.ToHexString(passwordHash), Convert.ToHexString(salt), creditCard));
        }

        public Customer? GetCustomer(string email, string password) {
            DB.TryGetValue(email, out Customer? customer);
            if (customer != null) {
                if (CryptographicOperations.FixedTimeEquals(Convert.FromHexString(customer.PasswordHash), GetPasswordHash(password, Convert.FromHexString(customer.Salt), 64))) { 
                    return customer;
                }
            }
            return null;
        }

        private byte[] GetPasswordHash(string password, byte[] salt, int keySize) {
            const int ITERATIONS = 500_000;

            var hashAlgorithm = HashAlgorithmName.SHA512;

            return Rfc2898DeriveBytes.Pbkdf2(
                                    Encoding.UTF8.GetBytes(password),
                                    salt,
                                    ITERATIONS,
                                    hashAlgorithm,
                                    keySize);
        }

        private byte[] GenerateSalt(int keySize) { return RandomNumberGenerator.GetBytes(keySize); }
    }
}
