using ClassLibrary.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WpfApplication.ViewModels
{
    public class TransactionsGridVM : ViewModelBase
    {        
        //public ObservableCollection<Transaction> Transactions { get; private set; }

        //public ObservableCollection<Account> Accounts { get; private set; }

        public ICommand EditCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }

        public TransactionsGridVM()//ObservableCollection<Transaction> transactions)//, ObservableCollection<Account> accounts)
        {
            //Transactions = transactions;
            //Accounts = accounts;

            EditCommand = new Command((o) =>
            {
                MainWindowVM.OpenReceiptEntryExecute(o as Transaction);
            });
            DeleteCommand = new Command((o) =>
            {
                if (PromptYesNoQuestion("Delete Transaction?"))
                {
                    MainWindowVM.Repository.Remove(o as Transaction);                                        
                }
            });
        }
    }
}
