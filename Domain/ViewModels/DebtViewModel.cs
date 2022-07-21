using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.ViewModels
{
    public class DebtViewModel
    {
        public double sum_price { get; set; }
        public double discount { get; set; }
        public double paying_amount { get; set; }
        public double credit_amount { get; set; }
        public double credit_amount_payment { get; set; }

        public double payable_amount { get { return sum_price - discount; } }

        public double debt_by_paying { get { return payable_amount - paying_amount; } }

        public double debt_by_credit_amount { get { return credit_amount - credit_amount_payment; } }
    }
}
