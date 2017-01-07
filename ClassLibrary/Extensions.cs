using ClassLibrary.Models;
using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public static class Extensions
    {
        public static IEnumerable<Transaction> Simulate(this ScheduledTransaction scheduledTransaction, DateTime beginDate, DateTime endDate)
        {
            var result = new List<Transaction>();
            var currentDate = scheduledTransaction.Frequency.BeginDate.Date;

            while (currentDate <= endDate)
            {
                var trans = new Transaction()
                {
                    Date = currentDate,
                    Id = Guid.NewGuid(),
                    Memo = scheduledTransaction.Memo,
                    ScheduledTransactionId = scheduledTransaction.Id
                };

                foreach (var detail in scheduledTransaction.Details)
                {
                    trans.Details.Add(new TransactionDetail() { Id = Guid.NewGuid(), Reference = detail.Reference, AccountId = scheduledTransaction.FromAccountId, DebitAmount = detail.Amount, TransactionId = trans.Id });
                    trans.Details.Add(new TransactionDetail() { Id = Guid.NewGuid(), Reference = detail.Reference, AccountId = scheduledTransaction.ToAccountId, CreditAmount = detail.Amount, TransactionId = trans.Id });
                }

                result.Add(trans);

                if (scheduledTransaction.Frequency.IsDaily)
                {
                    currentDate = currentDate.AddDays(scheduledTransaction.Frequency.Value);
                }
                else if (scheduledTransaction.Frequency.IsWeekly)
                {
                    currentDate = currentDate.AddDays(scheduledTransaction.Frequency.Value * 7);
                }
                else if (scheduledTransaction.Frequency.IsMonthly)
                {
                    currentDate = currentDate.AddMonths(scheduledTransaction.Frequency.Value);
                }
            }

            return result;
        }
    }
}
