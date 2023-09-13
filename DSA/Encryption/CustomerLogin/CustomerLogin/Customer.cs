using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLogin {
    public class Customer {
        public string Email { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string EncryptedCreditCard { get; set; }

        public Customer(string Email, string Name, string PasswordHash, string Salt, string EncryptedCreditCard) {
            this.Email = Email;
            this.Name = Name;
            this.PasswordHash = PasswordHash;
            this.Salt = Salt;
            this.EncryptedCreditCard = EncryptedCreditCard;
        }
    }
}
