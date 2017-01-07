using ClassLibrary;
using ClassLibrary.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace WpfApplication.ViewModels
{
    public class AccountsGridVM : ViewModelBase
    {
        private Account _selectedItem;

        public ObservableCollection<Account> Accounts { get; private set; }

        public ICommand EditCommand { get; private set; }

        public ICommand DeleteCommand { get; private set; }

        public Account SelectedItem
        {
            get
            {
                return _selectedItem;
            }

            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public AccountsGridVM(ObservableCollection<Account> accounts)
        {
            Accounts = accounts;
                   
            EditCommand = new Command((o) => MainWindowVM.OpenAccountEntryExecute(o as Account));
            DeleteCommand = new Command((o) =>
            {
                if (PromptYesNoQuestion("Delete Account?"))
                {
                    MainWindowVM.Repository.Remove(o as ModelBase);                    
                }
            });
        }
    }
}
