using ClassLibrary;
using ClassLibrary.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApplication.UserControls;

namespace WpfApplication.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        #region fields

        private bool _isBusy;
        private DateTime _projectedBeginDate = new DateTime(2017, 1, 1).Date;
        private DateTime _projectedEndDate = new DateTime(2017, 12, 31).Date;
        private ObservableCollection<AccountBalance> _projectedBalances = new ObservableCollection<AccountBalance>();
        private ObservableCollection<Account> _accounts = new ObservableCollection<Account>();
        private Guid _selectedProjectedAccountId;
        private bool _isCalculatingProjection;
        private Repository _repository;
        private TransactionsGridVM _transactionsGridVM;
        private TransactionDetailsGridVM _transactionDetailsGridVM;
        private ScheduledTransactionsGridVM _scheduledTransactionsGridVM;
        private AccountsGridVM _accountsGridVM;

        #endregion

        #region properties

        public ICommand OpenAccountEntryCommand { get; private set; }

        public ICommand OpenCategoryEntryCommand { get; private set; }

        public ICommand OpenProductEntryCommand { get; private set; }

        public ICommand DeleteAccountCommand { get; private set; }

        public ICommand OpenReceiptEntryCommand { get; private set; }
      
        public ICommand SaveCommand { get; private set; }

        public ICommand SaveAsCommand { get; private set; }

        public ICommand OpenCommand { get; private set; }

        public ICommand ExitCommand { get; private set; }

        public ICommand CalculateProjectionCommand { get; private set; }

        public ICommand ApplyScheduledTransactionCommand { get; private set; }

        public DateTime ProjectedBeginDate
        {
            get
            {
                return _projectedBeginDate;
            }

            set
            {
                _projectedBeginDate = value;
                OnPropertyChanged(nameof(ProjectedBeginDate));
            }
        }

        public DateTime ProjectedEndDate
        {
            get
            {
                return _projectedEndDate;
            }

            set
            {
                _projectedEndDate = value;
                OnPropertyChanged(nameof(ProjectedEndDate));
            }
        }

        public ObservableCollection<AccountBalance> ProjectedBalances
        {
            get
            {
                return _projectedBalances;
            }

            set
            {
                _projectedBalances = value;
                OnPropertyChanged(nameof(ProjectedBalances));
            }
        }

        public ObservableCollection<Account> Accounts
        {
            get
            {
                return _accounts;
            }

            set
            {
                _accounts = value;
                OnPropertyChanged(nameof(Accounts));
            }
        }

        public Guid SelectedProjectedAccountId
        {
            get
            {
                return _selectedProjectedAccountId;
            }

            set
            {
                _selectedProjectedAccountId = value;
                OnPropertyChanged(nameof(SelectedProjectedAccountId));
            }
        }

        public bool IsCalculatingProjection
        {
            get
            {
                return _isCalculatingProjection;
            }

            set
            {
                _isCalculatingProjection = value;
                OnPropertyChanged(nameof(IsCalculatingProjection));
            }
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public Repository Repository
        {
            get
            {
                return _repository;
            }

            set
            {
                OnPropertyChanging(nameof(Repository), _repository, value);
                _repository = value;
                OnPropertyChanged(nameof(Repository));
            }
        }

        public TransactionsGridVM TransactionsGridVM
        {
            get
            {
                return _transactionsGridVM;
            }
            set
            {
                if (OnPropertyChanging(nameof(TransactionsGridVM), _transactionsGridVM, value))
                {
                    _transactionsGridVM = value;
                    OnPropertyChanged(nameof(TransactionsGridVM));
                }
            }
        }

        public TransactionDetailsGridVM TransactionDetailsGridVM
        {
            get
            {
                return _transactionDetailsGridVM;
            }
            set
            {
                if (OnPropertyChanging(nameof(TransactionDetailsGridVM), _transactionDetailsGridVM, value))
                {
                    _transactionDetailsGridVM = value;
                    OnPropertyChanged(nameof(TransactionDetailsGridVM));
                }
            }
        }

        public ScheduledTransactionsGridVM ScheduledTransactionsGridVM
        {
            get
            {
                return _scheduledTransactionsGridVM;
            }
            set
            {
                if (OnPropertyChanging(nameof(ScheduledTransactionsGridVM), _scheduledTransactionsGridVM, value))
                {
                    _scheduledTransactionsGridVM = value;
                    OnPropertyChanged(nameof(ScheduledTransactionsGridVM));
                }
            }
        }

        public AccountsGridVM AccountsGridVM
        {
            get
            {
                return _accountsGridVM;
            }

            set
            {
                if (OnPropertyChanging(nameof(AccountsGridVM), _accountsGridVM, value))
                {
                    _accountsGridVM = value;
                    OnPropertyChanged(nameof(AccountsGridVM));
                }
            }
        }

        #endregion

        public MainWindowVM()
        {
            MainWindowVM = this;
            Repository = new Repository();

            OpenAccountEntryCommand = new Command((o) => OpenAccountEntryExecute(o as Account ?? new Account()));
            OpenCategoryEntryCommand = new Command((o) => OpenCategoryEntryExecute(o as Category ?? new Category()));
            OpenProductEntryCommand = new Command((o) => OpenProductEntryExecute(o as Product ?? new Product()));
            DeleteAccountCommand = new Command((account) => DeleteAccountExecute(account as Account));
            OpenReceiptEntryCommand = new Command((o) => OpenReceiptEntryExecute(o as Transaction ?? new Transaction()));
            SaveCommand = new Command(async (o) => await SaveExecuteAsync(), (o) => !string.IsNullOrWhiteSpace(Repository.FilePath));
            SaveAsCommand = new Command(async (o) => await SaveAsExecuteAsync());
            OpenCommand = new Command(async (o) => await OpenExecuteAsync());
            CalculateProjectionCommand = new Command(async (o) => await CalculationProjectionExecuteAsync(), (o) => !IsCalculatingProjection);
            ExitCommand = new Command((o) => System.Windows.Application.Current.Shutdown());
            ApplyScheduledTransactionCommand = new Command((o) => ApplyScheduledTransactionExecute(o as ScheduledTransaction ?? new ScheduledTransaction()));
        }

        public void OpenAccountEntryExecute(Account account)
        {
            OpenObjectEntry(account);            
        }

        public void OpenCategoryEntryExecute(Category category)
        {           
            OpenObjectEntry(category);           
        }

        public void OpenProductEntryExecute(Product product)
        {
            OpenObjectEntry(product);           
        }

        public void OpenObjectEntry<T>(T obj) where T : ModelBase
        {
            var modelName = obj.GetType().Name;
            var win = new SaveWindow();
            var winVm = new SaveWindowVM();
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var controlType = assembly.GetType(string.Format("WpfApplication.UserControls.{0}Entry", modelName));
            var controlInstance = controlType.GetConstructor(new Type[] { }).Invoke(new object[] { }) as FrameworkElement;
            var vmType = assembly.GetType(string.Format("WpfApplication.ViewModels.{0}EntryVM", modelName));
            var vmInstance = vmType.GetConstructor(new Type[] { obj.GetType() }).Invoke(new object[] { obj });
            var exists = Repository.Exists(obj);

            winVm.IsSaveVisible = !exists;
            winVm.Save += (s, e) =>
            {
                if (!exists)
                {
                    Repository.Add(obj);
                }

                win.Close();
            };

            win.DataContext = winVm;
            controlInstance.DataContext = vmInstance;
            win.WindowContents = controlInstance;
            win.Title = string.Format("New {0}", modelName);
            win.SizeToContent = SizeToContent.WidthAndHeight;
            win.ShowDialog();
        }            

        private void DeleteAccountExecute(Account acct)
        {
            Repository.Accounts.Remove(acct);
        }

        public void OpenReceiptEntryExecute(Transaction trans)
        {
            var win = new SaveWindow();
            var winVm = new SaveWindowVM();
            var control = new TransactionEntry();
            var exists = Repository.Transactions.Contains(trans);
            var vm = new TransactionEntryVM(trans, Repository.Accounts.OrderBy(t => t.Name), Repository.Accounts.OrderBy(t => t.Name));            

            winVm.IsSaveVisible = !exists;

            winVm.Save += (s, e) =>
            {                
                if (!exists)
                {
                    Repository.Add(trans);                    
                }
                               
                Repository.UpdateAccountBalances(DateTime.Now.Date);

                win.Close();
            };

            win.SizeToContent = SizeToContent.WidthAndHeight;
            win.DataContext = winVm;
            control.DataContext = vm;
            win.WindowContents = control;
            win.ShowDialog();
        }

        private async Task SaveExecuteAsync()
        {
            IsBusy = true;
            try
            {
                await Repository.SaveAsync(Repository.FilePath);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task SaveAsExecuteAsync()
        {            
            var dlg = new SaveFileDialog();
            dlg.Filter = "XML File|*.xml";
            dlg.Title = "Save As...";
            dlg.AddExtension = true;

            if (System.IO.File.Exists(Repository.FilePath))
            {
                dlg.FileName = new System.IO.FileInfo(Repository.FilePath).Name;
            }

            if (dlg.ShowDialog() == true)
            {
                IsBusy = true;
                try
                {
                    await Repository.SaveAsync(dlg.FileName);
                }
                finally
                {
                    IsBusy = false;
                }
            }            
        }

        private async Task OpenExecuteAsync()
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "XML File|*.xml";
            dlg.Title = "Open...";

            if (dlg.ShowDialog() == true)
            {
                IsBusy = true;
                try
                {
                    var newRepo = await Repository.LoadAsync(dlg.FileName);
                    Repository = newRepo;
                }
                finally
                {
                    IsBusy = false;
                }
                OnPropertyChanged(nameof(Repository));
                RefreshAccounts();
            }
        }
        
        private async Task CalculationProjectionExecuteAsync()
        {
            IsCalculatingProjection = true;
            var result = await CalculateProjectionAsync(SelectedProjectedAccountId, ProjectedBeginDate, ProjectedEndDate);

            ProjectedBalances.Clear();

            foreach (var item in result)
            {
                ProjectedBalances.Add(item);
            }
            IsCalculatingProjection = false;
        }

        private void ApplyScheduledTransactionExecute(ScheduledTransaction schedTrans)
        {
            //var scheduledTransaction = o as ScheduledTransaction;

            //var win = new SaveWindow();
            //var winVm = new SaveWindowVM();
            //var control = new ReceiptEntry();
            //var vm = control.DataContext as ReceiptEntryVM;
            //var existingTransaction = o as Transaction;

            //var vendorAccounts = new ObservableCollection<AccountVM>();
            //var paymentAccounts = new ObservableCollection<AccountVM>();

            //foreach (var account in Repository.Accounts)
            //{
            //    var accountVM = new AccountVM() { Id = account.Id, Name = account.Name };

            //    vendorAccounts.Add(accountVM);
            //    paymentAccounts.Add(accountVM);
            //}

            //vm.VendorAccounts = vendorAccounts;
            //vm.PaymentAccounts = paymentAccounts;

            //if (existingTransaction != null)
            //{
            //    // TODO:
            //}
            //else
            //{
            //    vm.Id = Guid.NewGuid();
            //    vm.SelectedPaymentAccountId = scheduledTransaction.FromAccountId;
            //    vm.SelectedVendorAccountId = scheduledTransaction.ToAccountId;
            //    vm.IsSpecificDate = true;
            //    vm.Memo = scheduledTransaction.Memo;

            //    foreach (var detail in scheduledTransaction.Details)
            //    {
            //        vm.LineItems.Add(new ReceiptEntryLineItemVM() { Amount = detail.Amount, Item = detail.Reference });
            //    }
            //}

            //winVm.Save += (s, e) =>
            //{
            //    // map vm to model                 
            //    if (existingTransaction != null) // update existing
            //    {

            //    }
            //    else // insert new
            //    {
            //        if (vm.IsSpecificDate)
            //        {
            //            var receipt = new Receipt() { Id = vm.Id };
            //            var transaction = new Transaction() { Id = Guid.NewGuid(), Date = vm.Date, Memo = vm.Memo, ReceiptId = receipt.Id, ScheduledTransactionId = scheduledTransaction.Id };

            //            Repository.Receipts.Add(receipt);
            //            Repository.Transactions.Add(transaction);

            //            foreach (var lineItemVM in vm.LineItems)
            //            {
            //                var payFromDetail = new TransactionDetail() { Id = Guid.NewGuid(), TransactionId = transaction.Id, AccountId = vm.SelectedPaymentAccountId, DebitAmount = lineItemVM.Amount, Reference = lineItemVM.Item };
            //                var payToDetail = new TransactionDetail() { Id = Guid.NewGuid(), TransactionId = transaction.Id, AccountId = vm.SelectedVendorAccountId, CreditAmount = lineItemVM.Amount, Reference = lineItemVM.Item };

            //                Repository.TransactionDetails.Add(payFromDetail);
            //                Repository.TransactionDetails.Add(payToDetail);

            //                transaction.Details.Add(payFromDetail);
            //                transaction.Details.Add(payToDetail);
            //            }
            //        }
            //    }

            //    Repository.UpdateAccountBalances(DateTime.Now.Date);

            //    win.Close();
            //};

            //win.DataContext = winVm;
            //win.WindowContents = control;
            //win.ShowDialog();
        }
             
        private Task<IEnumerable<AccountBalance>> CalculateProjectionAsync(Guid accountId, DateTime beginDate, DateTime endDate)
        {
            return Task.Run(() =>
            {
                return Repository.CalculateSimulatedAccountBalances(beginDate, endDate,
                    Repository.Accounts.First(t => t.Id == accountId));
            });
        }

        private void RefreshAccounts()
        {
            Accounts.Clear();

            var currentDate = DateTime.Now.Date;

            foreach (var acct in Repository.Accounts)
            {
                Accounts.Add(new Account() {Id = acct.Id, Name = acct.Name, Type = acct.Type});
            }
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(Repository):
                    TransactionsGridVM = new TransactionsGridVM();
                    TransactionDetailsGridVM = new TransactionDetailsGridVM();
                    ScheduledTransactionsGridVM = new ScheduledTransactionsGridVM(Repository.ScheduledTransactions, Repository.Accounts);
                    AccountsGridVM = new AccountsGridVM(Repository.Accounts);
                    break;
            }
        }
    }
}
