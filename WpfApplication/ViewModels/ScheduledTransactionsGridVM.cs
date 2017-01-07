using ClassLibrary.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WpfApplication.ViewModels
{
    public class ScheduledTransactionsGridVM : ViewModelBase
    {
        public ObservableCollection<ScheduledTransaction> ScheduledTransactions { get; private set; }

        public ObservableCollection<Account> Accounts { get; private set; }

        public ICommand EditCommand { get; private set; }

        public ICommand ApplyCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }

        public ScheduledTransactionsGridVM(ObservableCollection<ScheduledTransaction> scheduledTransactions, ObservableCollection<Account> accounts)
        {
            ScheduledTransactions = scheduledTransactions;
            Accounts = accounts;

            EditCommand = new Command((o) =>
            {

            });
            ApplyCommand = new Command((o) =>
            {

            });
            DeleteCommand = new Command((o) =>
            {
                if (PromptYesNoQuestion("Delete Scheduled Transaction?"))
                {
                    MainWindowVM.Repository.Remove(o as ScheduledTransaction);                    
                }
            });
        }
    }
}
