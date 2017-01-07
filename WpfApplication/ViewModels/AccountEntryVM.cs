using ClassLibrary.Models;

namespace WpfApplication.ViewModels
{
    public class AccountEntryVM : ViewModelBase<Account>
    {
        public AccountEntryVM(Account model)
            : base(model)
        {

        }
    }
}
