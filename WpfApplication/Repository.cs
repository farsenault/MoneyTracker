using ClassLibrary;
using ClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace WpfApplication
{
    public class Repository : NotifyPropertyChangedBase
    {
        #region fields

        private string _filePath;

        #endregion

        #region properties

        public ObservableCollection<Account> Accounts { get; set; } = new ObservableCollection<Account>();

        public ObservableCollection<Transaction> Transactions { get; set; } = new ObservableCollection<Transaction>();

        public ObservableCollection<TransactionDetail> TransactionDetails { get; set; } = new ObservableCollection<TransactionDetail>();

        public ObservableCollection<Receipt> Receipts { get; set; } = new ObservableCollection<Receipt>();

        public ObservableCollection<ScheduledTransaction> ScheduledTransactions { get; set; } = new ObservableCollection<ScheduledTransaction>();

        public ObservableCollection<ScheduledTransactionDetail> ScheduledTransactionDetails { get; set; } = new ObservableCollection<ScheduledTransactionDetail>();

        public ObservableCollection<Category> Categories { get; set; } = new ObservableCollection<Category>();

        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        public string FilePath
        {
            get
            {
                return _filePath;
            }
            set
            {
                if (OnPropertyChanging(nameof(FilePath), _filePath, value))
                {
                    _filePath = value;
                    OnPropertyChanged(nameof(FilePath));
                }
            }
        }

        #endregion

        public bool Exists(ModelBase obj)
        {
            if (obj is Account)
            {
                return Accounts.Contains(obj);
            }
            else if (obj is Transaction)
            {
                return Transactions.Contains(obj);
            }
            else if (obj is TransactionDetail)
            {
                return TransactionDetails.Contains(obj);
            }
            else if (obj is Receipt)
            {
                return Receipts.Contains(obj);
            }
            else if (obj is ScheduledTransaction)
            {
                return ScheduledTransactions.Contains(obj);
            }
            else if (obj is ScheduledTransactionDetail)
            {
                return ScheduledTransactionDetails.Contains(obj);
            }
            else if (obj is Category)
            {
                return Categories.Contains(obj);
            }
            else if (obj is Product)
            {
                return Products.Contains(obj);
            }
            else
            {
                return false;
            }
        }

        public void Add(ModelBase obj)
        {
            if (obj is Account)
            {
                Accounts.Add(obj as Account);
            }
            else if (obj is Transaction)
            {
                Transactions.Add(obj as Transaction);

                foreach (var detail in ((Transaction)obj).Details)
                {
                    Add(detail);
                }
            }
            else if (obj is TransactionDetail)
            {
                TransactionDetails.Add(obj as TransactionDetail);
            }
            else if (obj is Receipt)
            {
                Receipts.Add(obj as Receipt);
            }
            else if (obj is ScheduledTransaction)
            {
                ScheduledTransactions.Add(obj as ScheduledTransaction);

                foreach (var detail in ((ScheduledTransaction)obj).Details)
                {
                    Add(detail);
                }
            }
            else if (obj is ScheduledTransactionDetail)
            {
                ScheduledTransactionDetails.Add(obj as ScheduledTransactionDetail);
            }
            else if (obj is Category)
            {
                Categories.Add(obj as Category);
            }
            else if (obj is Product)
            {
                Products.Add(obj as Product);
            }            
        }

        public void Remove(ModelBase obj)
        {
            if (obj is Account)
            {
                Accounts.Remove(obj as Account);

                var transactionIds = Transactions.SelectMany(t => t.Details).Where(t => t.AccountId == ((Account)obj).Id).Select(t => t.TransactionId);

                foreach (var transId in transactionIds)
                {
                    Remove(Transactions.FirstOrDefault(t => t.Id == transId));
                }

                foreach (var schedTrans in ScheduledTransactions.Where(t => t.FromAccountId == ((Account)obj).Id || t.ToAccountId == ((Account)obj).Id).ToList())
                {
                    Remove(schedTrans);
                }

            }
            else if (obj is Transaction)
            {
                Transactions.Remove(obj as Transaction);

                foreach (var detail in TransactionDetails.Where(t => t.TransactionId == ((Transaction)obj).Id).ToList())
                {
                    Remove(detail);
                }
            }
            else if (obj is TransactionDetail)
            {
                TransactionDetails.Remove(obj as TransactionDetail);
            }
            else if (obj is Receipt)
            {
                Receipts.Remove(obj as Receipt);
            }
            else if (obj is ScheduledTransaction)
            {
                ScheduledTransactions.Remove(obj as ScheduledTransaction);

                foreach (var detail in ScheduledTransactionDetails.Where(t => t.ScheduledTransactionId == ((ScheduledTransaction)obj).Id).ToList())
                {
                    Remove(detail);
                }
            }
            else if (obj is ScheduledTransactionDetail)
            {
                ScheduledTransactionDetails.Remove(obj as ScheduledTransactionDetail);
            }
            else if (obj is Category)
            {
                Categories.Remove(obj as Category);
            }
            else if (obj is Product)
            {
                Products.Remove(obj as Product);
            }
        }

        public Repository()
        {
            
        }        

        public Task SaveAsync(string filePath)
        {
            return Task.Run(() =>
            {
                string tmpFilePath = System.IO.Path.GetTempFileName();
                var serializer = new System.Xml.Serialization.XmlSerializer(GetType());
                using (var stream = System.IO.File.OpenWrite(tmpFilePath))
                {
                    serializer.Serialize(stream, this);
                }
                System.IO.File.Copy(tmpFilePath, filePath, true);
                FilePath = filePath;
            });
        }

        public static Task<Repository> LoadAsync(string filePath)
        {
            return Task.Run(() =>
            {
                var newRepo = new Repository();
                var serializer = new System.Xml.Serialization.XmlSerializer(Type.GetType("WpfApplication.Repository"));
                using (var stream = System.IO.File.OpenRead(filePath))
                {
                    newRepo = (Repository)serializer.Deserialize(stream);
                }
            
                foreach (var trans in newRepo.Transactions)
                {
                    trans.Details = new ObservableCollection<TransactionDetail>(newRepo.TransactionDetails.Where(t => t.TransactionId == trans.Id));

                    if (trans.ScheduledTransactionId.HasValue)
                    {
                        trans.ScheduledTransaction = newRepo.ScheduledTransactions.First(t => t.Id == trans.ScheduledTransactionId.Value);
                    }
                }
                foreach (var trans in newRepo.ScheduledTransactions)
                {
                    trans.Details = new ObservableCollection<ScheduledTransactionDetail>(newRepo.ScheduledTransactionDetails.Where(t => t.ScheduledTransactionId == trans.Id));
                }
                newRepo.UpdateAccountBalances(DateTime.Now.Date);
                newRepo.FilePath = filePath;

                return newRepo;
            });
        }

        public void UpdateAccountBalances(DateTime upToDate)
        {
            foreach (var acct in Accounts)
            {
                acct.Balance = CalculateAccountBalance(upToDate, acct);
            }
        }

        private decimal CalculateAccountBalance(DateTime upToDate, Account acct)
        {            
            return GetTransactionDetails(upToDate, acct).Sum(t => t.CreditAmount - t.DebitAmount);
        }

        private IEnumerable<TransactionDetail> GetTransactionDetails(DateTime upToDate, Account acct)
        {
            var transactionDetailsForAccount = TransactionDetails.Where(t => t.AccountId == acct.Id).ToList();
            var transactionIds = transactionDetailsForAccount.Select(t => t.TransactionId).Distinct();
            var transactionsForAccount = Transactions.Where(t => transactionIds.Contains(t.Id));
            var priorDatesTransactionIds = transactionsForAccount.Where(t => t.Date <= upToDate).Select(t => t.Id);

            return transactionDetailsForAccount.Where(t => priorDatesTransactionIds.Contains(t.TransactionId)).ToList();            
        }

        public IEnumerable<AccountBalance> CalculateSimulatedAccountBalances(DateTime beginDate, DateTime endDate, Account acct)
        {
            var result = new List<AccountBalance>();
            var postedDetails = GetTransactionDetails(endDate, acct).ToList();
            var postedTransactionIds = postedDetails.Select(t => t.TransactionId).Distinct().ToList();
            var postedTransactions = Transactions.Where(t => postedTransactionIds.Contains(t.Id)).ToList();
            var simulatedTransactions = ScheduledTransactions.Where(t => t.FromAccountId == acct.Id || t.ToAccountId == acct.Id).SelectMany(t => t.Simulate(beginDate, endDate)).ToList();            

            // remove simulated transactions that have hit          
            for (int i = simulatedTransactions.Count - 1; i >= 0; i--)
            {
                var simulatedTransaction = simulatedTransactions[i];

                if (simulatedTransaction.ScheduledTransactionId.HasValue)
                {
                    if (
                        postedTransactions.Any(
                            t =>
                                t.Date == simulatedTransaction.Date &&
                                t.ScheduledTransactionId == simulatedTransaction.ScheduledTransactionId))
                    {
                        simulatedTransactions.RemoveAt(i);
                    }
                }
            }

            var simulatedDetails = simulatedTransactions.SelectMany(t => t.Details.Where(td => td.AccountId == acct.Id)).ToList();
            var priorPostedTransactionIds = Transactions.Where(t => t.Date < beginDate && postedTransactionIds.Contains(t.Id)).Select(t => t.Id);
            var priorPostedDetails = postedDetails.Where(t => priorPostedTransactionIds.Contains(t.TransactionId));
            var priorSimulatedTransactionIds = simulatedTransactions.Where(t => t.Date < beginDate).Select(t => t.Id);
            var priorSimulatedDetails = simulatedDetails.Where(t => priorSimulatedTransactionIds.Contains(t.TransactionId));
            var balance = priorPostedDetails.Sum(t => t.CreditAmount - t.DebitAmount) +
                          priorSimulatedDetails.Sum(t => t.CreditAmount - t.DebitAmount);


            postedTransactions.RemoveAll(t => priorPostedTransactionIds.Contains(t.Id));
            postedDetails.RemoveAll(t => priorPostedDetails.Contains(t));
            simulatedTransactions.RemoveAll(t => priorSimulatedTransactionIds.Contains(t.Id));
            simulatedDetails.RemoveAll(t => priorSimulatedDetails.Contains(t));

            while (beginDate <= endDate)
            {
                var currentPostedTransactionIds = postedTransactions.Where(t => t.Date == beginDate).Select(t => t.Id);
                var currentSimulatedTransactionIds = simulatedTransactions.Where(t => t.Date == beginDate).Select(t => t.Id);
                var currentDetails = postedDetails.Where(t => currentPostedTransactionIds.Contains(t.TransactionId));
                var currentSimulatedDetails = simulatedDetails.Where(t => currentSimulatedTransactionIds.Contains(t.TransactionId));

                balance += (currentDetails.Sum(t => t.CreditAmount - t.DebitAmount) +
                            currentSimulatedDetails.Sum(t => t.CreditAmount - t.DebitAmount));

                result.Add(new AccountBalance() { Date = beginDate, Balance = balance, Transactions = simulatedTransactions.Where(t => t.Date == beginDate) .Union(postedTransactions.Where(t => t.Date == beginDate)).ToList() });

                beginDate = beginDate.AddDays(1);                
            }

            return result;
        }

        public AccountBalance CalculateSimulatedAccountBalance(DateTime upToDate, Account acct)
        {
            var postedDetails = GetTransactionDetails(upToDate, acct);
            var postedTransactionIds = postedDetails.Select(t => t.TransactionId).Distinct().ToList();
            var postedTransactions = Transactions.Where(t => postedTransactionIds.Contains(t.Id)).ToList();

            var scheduledTransactions = ScheduledTransactions.Where(t => t.FromAccountId == acct.Id || t.ToAccountId == acct.Id);
            var simulatedTransactions = scheduledTransactions.SelectMany(t => t.Simulate(upToDate, upToDate)).ToList();

            // remove simulated transactions that have hit          
            for (int i = simulatedTransactions.Count - 1; i >= 0; i--)
            {
                var simulatedTransaction = simulatedTransactions[i];

                if (simulatedTransaction.ScheduledTransactionId.HasValue)
                {
                    if (
                        postedTransactions.Any(
                            t =>
                                t.Date == simulatedTransaction.Date &&
                                t.ScheduledTransactionId == simulatedTransaction.ScheduledTransactionId))
                    {
                        simulatedTransactions.RemoveAt(i);
                    }
                }
            }

            var simulatedDetails = simulatedTransactions.SelectMany(t => t.Details.Where(td => td.AccountId == acct.Id));

            var balance = postedDetails.Sum(t => t.CreditAmount - t.DebitAmount) +
                          simulatedDetails.Sum(t => t.CreditAmount - t.DebitAmount);

            return new AccountBalance() {Balance = balance, Date = upToDate, Transactions = postedTransactions.Where(t => t.Date == upToDate).Union(simulatedTransactions.Where(t => t.Date == upToDate)).ToList() };
        }     
    }
}
