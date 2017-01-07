using ClassLibrary.Models;
using System;
using System.Collections.Generic;

namespace WpfApplication
{
    public class AccountBalance
    {
        public DateTime Date { get; set; }

        public decimal Balance { get; set; }

        public IEnumerable<Transaction> Transactions { get; set; }
    }
}
