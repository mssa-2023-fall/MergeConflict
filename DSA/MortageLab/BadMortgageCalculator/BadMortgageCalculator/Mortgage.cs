using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadMortgageCalculator {
    public enum Terms { TenYear = 10, FifteenYear = 15, ThirtyYear = 30 }

    public class Mortgage {

        // ========== ATTRIBUTES ==========
        public string Address { get; private set; }
        public int Term { get; private set; }
        public double Principal { get; private set; }
        public double InterestRate { get; private set; }
        public DateTime OriginDate { get; private set; } = DateTime.Now;
        public List<Payment> Payments { get; private set; } = new List<Payment>();

        // ========== CONSTRUCTORS ==========

        public Mortgage(string address, DateTime originDate, List<Payment> payments, Terms term=Terms.ThirtyYear, double principal=0, double interestRate=0) {
            Address = address;
            Term = (int)term;
            Principal = principal;
            InterestRate = interestRate;
            OriginDate = originDate;
            Payments = payments;
        }

        // ========== METHODS ==========
        public void GetPayoffDates() { throw new NotImplementedException(); }
        public void RemainingPrincipalAtDate() { throw new NotImplementedException(); }
        // can use in payment class i think
        public void InterestPaidAtDate() { throw new NotImplementedException(); }
        public void GetAmortizationSchedule() { throw new NotImplementedException(); }
        public void ToJson() { throw new NotImplementedException(); }
    }
}
