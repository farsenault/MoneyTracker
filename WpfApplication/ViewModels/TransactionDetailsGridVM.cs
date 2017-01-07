using ClassLibrary.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WpfApplication.ViewModels
{
    public class TransactionDetailsGridVM : ViewModelBase
    {    
        public ICommand EditCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }

        public TransactionDetailsGridVM()//ObservableCollection<Transaction> transactions)//, ObservableCollection<Account> accounts)
        {            
            EditCommand = new Command((o) =>
            {
                //MainWindowVM.OpenReceiptEntryExecute(o as Transaction);
            });
            DeleteCommand = new Command((o) =>
            {
                if (PromptYesNoQuestion("Delete Transaction?"))
                {
                    //MainWindowVM.Repository.Remove(o as Transaction);
                }
            });
        }
    }
}
