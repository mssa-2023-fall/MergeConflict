using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadMortgageCalculator {
    public class Payment {

        // ========== ATTRIBUTES ==========
        public DateTime Date { get; private set; }
        public double Principal { get; private set; }
        public double Interest { get; private set; }
        public double Total => Principal + Interest;

        // ========== CONSTRUCTORS ==========

        // using parent for principal/interest calc
        public Payment(double paymentAmount, Mortgage parent) {
            Date = DateTime.Now;
            // calculate how much is principal and interest
        }

        // not using parent for principal/interest calc
        public Payment(double principal, double interest) {
            Date = DateTime.Now;
            Principal = principal;
            Interest = interest;
        }

    }
}
